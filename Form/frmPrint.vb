Imports System.Windows.Forms
Imports Inventor
Imports System
Imports System.IO
Imports Microsoft
Imports Microsoft.VisualBasic
Imports System.Collections.ObjectModel
Imports stdole
Imports System.Drawing
Imports Inventor.DocumentTypeEnum

Public Class frmPrint

    '批量打印开始
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        On Error Resume Next

        If lvwFileListView.Items.Count = 0 Then
            MsgBox("未添加工程图文件。", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "批量另存为")
            Exit Sub
        End If

        btnStart.Enabled = False

        Dim strPrinterName As String = ""
        strPrinterName = cmbPrinter.Text

        'For i = 0 To lvwFileListView.Items.Count - 1

        For Each oListViewItem As ListViewItem In lvwFileListView.Items
            'lvwFileListView.Items(i).Selected = True
            oListViewItem.Selected = True

            Me.Text = "批量打印  (第" & oListViewItem.Index + 1 & "张，共" & lvwFileListView.Items.Count & "张）"

            '打开文件
            Dim strInventorDrawingFullFileName As String  '工程图全文件名

            strInventorDrawingFullFileName = oListViewItem.Text

            If IsFileExsts(strInventorDrawingFullFileName) = False Then   '跳过不存在的文件
                GoTo 999
            End If

            'If InStr(InvDocFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
            '    GoTo 999
            'End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            '打开工程图
            oInventorDrawingDocument = ThisApplication.Documents.Open(strInventorDrawingFullFileName, True)
            oInventorDrawingDocument.Update()

            '刷新sheets

            If oInventorDrawingDocument.Sheets Is Nothing Then GoTo 999

            SetStatusBarText("正在更新工程图 ......")

            Dim oSheet As Inventor.Sheet
            For Each oSheet In oInventorDrawingDocument.Sheets
                For Each oDwgView In oSheet.DrawingViews
                    Do While oDwgView.IsUpdateComplete = False
                        ThisApplication.UserInterfaceManager.DoEvents()
                    Loop
                Next
            Next

            '保存文件
            oInventorDrawingDocument.Save()

            '设置签字
            Dim strPrintDate As String
            strPrintDate = Today.Year & "." & Today.Month & "." & Today.Day
            If chkSign.Checked = True Then
                SetSign(oInventorDrawingDocument, EngineerName, strPrintDate, False)
            End If

            '打印文件
            PrintDrawing(oInventorDrawingDocument, strPrinterName)

            '另存为pdf
            If chkSaveAsPdf.Checked = True Then
                SaveAsPdf(oInventorDrawingDocument)
            End If

            '另存为dwg
            If chkSaveAsDwg.Checked = True Then
                SaveAsDwg(oInventorDrawingDocument)
            End If

            If chkSaveSign.Checked = False Then
                '清除签字
                SetSign(oInventorDrawingDocument, "", "", False)
            Else
                '保存签字
                oInventorDrawingDocument.Save2(True)
            End If

            '关闭文件
            If chkClose.Checked = True Then
                oInventorDrawingDocument.Close(True)
            End If

999:
        Next
        'MsgBox("批量打印工程图完成", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "批量打印")

        lvwFileListView.Items.Clear()
        btnStart.Enabled = True
        SetStatusBarText("批量打印工程图完成")
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    '关闭
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        lvwFileListView.Items.Clear()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    '添加文件
    Private Sub btnAddFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFile.Click

        Dim oOpenFileDialog As New OpenFileDialog

        lblsuggest.Visible = False

        With oOpenFileDialog
            .Title = "打开"
            .FileName = ""
            .Filter = "AutoDesk Inventor 工程图文件(*.idw)|*.idw" '添加过滤文件
            .Multiselect = True '多开文件打开
            If .ShowDialog = Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                If .FileName <> "" Then '如果有选中文件

                    btnAddFile.Enabled = False
                    'ThisApplication.Cursor  = Cursors.WaitCursor

                    For Each strInventorDrawingFullFileName As String In .FileNames

                        If IsItemInListView(lvwFileListView, strInventorDrawingFullFileName) = False Then
                            lvwFileListView.Items.Add(strInventorDrawingFullFileName)
                        End If

                    Next

                    btnAddFile.Enabled = True
                    'ThisApplication.Cursor  = Cursors.Default
                End If
            Else
                Exit Sub
            End If

            Me.Text = "批量打印  (共" & lvwFileListView.Items.Count & "张）"

        End With
    End Sub

    '清空文件列表
    Private Sub btnClearList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearList.Click
        lvwFileListView.Items.Clear()
        Me.Text = "批量打印"
    End Sub

    '添加文件夹
    Private Sub btnAddFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFolder.Click
        Dim strDestinationFolder As String = Nothing
        Dim oFileAttributes As FileAttributes
        Dim strPresentFolder As String = Nothing
        Dim oFolderBrowserDialog As New FolderBrowserDialog

        lblsuggest.Visible = False

        With oFolderBrowserDialog
            .ShowNewFolderButton = False
            .Description = "添加文件夹"
            .RootFolder = System.Environment.SpecialFolder.Desktop
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                strDestinationFolder = .SelectedPath
            Else
                Exit Sub
            End If
        End With

        btnAddFolder.Enabled = False
        'ThisApplication.Cursor  = Cursors.WaitCursor

        '是否为文件夹，在其后添加 \，得到父文件夹
        oFileAttributes = FileSystem.GetAttr(strDestinationFolder)

        If oFileAttributes = FileAttributes.Directory Then
            strDestinationFolder = strDestinationFolder + "\"
            strPresentFolder = My.Computer.FileSystem.GetParentPath(strDestinationFolder)
        End If

        GetAllFile(strPresentFolder, strDestinationFolder, lvwFileListView)

        btnAddFolder.Enabled = True
        'ThisApplication.Cursor  = Cursors.Default

        Me.Text = "批量打印  (共" & lvwFileListView.Items.Count & "张）"
    End Sub

    '打印文档，打印机名称
    Private Sub PrintDrawing(ByVal oInventorDrawingDocument As Inventor.DrawingDocument, ByVal sPrinterName As String)

        ' Set a reference to the print manager object of the active document.
        ' This will fail if a drawing document is not active.
        Dim oDrawingPrintManagerr As DrawingPrintManager

        oDrawingPrintManagerr = oInventorDrawingDocument.PrintManager

        With oDrawingPrintManagerr
            ' Get the name of the printer that will be used.
            .Printer = sPrinterName

            '所有颜色打印为黑色
            If chkBlack.Checked = True Then
                .AllColorsAsBlack = True
            Else
                .AllColorsAsBlack = False
            End If

            .ColorMode = PrintColorModeEnum.kPrintDefaultColorMode

            '份数
            .NumberOfCopies = nudCopies.Value

            ' Set to print using portrait orientation.
            .Orientation = PrintOrientationEnum.kDefaultOrientation

            '最佳比例
            .ScaleMode = PrintScaleModeEnum.kPrintBestFitScale

            '设置为默认纸张大小

            ' 如果是打印到打印机，修正为A3
            If chkPaperA3.Checked = True Then
                Select Case oInventorDrawingDocument.ActiveSheet.Size
                    Case DrawingSheetSizeEnum.kA4DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA4
                    Case DrawingSheetSizeEnum.kA3DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA3
                    Case DrawingSheetSizeEnum.kA2DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA3
                    Case DrawingSheetSizeEnum.kA1DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA3
                    Case DrawingSheetSizeEnum.kA0DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA3
                End Select
            Else
                '设置为默认纸张大小
                Select Case oInventorDrawingDocument.ActiveSheet.Size
                    Case DrawingSheetSizeEnum.kA4DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA4
                    Case DrawingSheetSizeEnum.kA3DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA3
                    Case DrawingSheetSizeEnum.kA2DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA2
                    Case DrawingSheetSizeEnum.kA1DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA1
                    Case DrawingSheetSizeEnum.kA0DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA0
                End Select

            End If

            '最佳比例
            .ScaleMode = PrintScaleModeEnum.kPrintBestFitScale

            '设置方向
            Select Case oInventorDrawingDocument.ActiveSheet.Orientation
                Case PageOrientationTypeEnum.kLandscapePageOrientation
                    .Orientation = PrintOrientationEnum.kLandscapeOrientation
                Case PageOrientationTypeEnum.kPortraitPageOrientation
                    .Orientation = PrintOrientationEnum.kPortraitOrientation
            End Select

            ' Set to print all sheets.
            .PrintRange = PrintRangeEnum.kPrintAllSheets

            ' 打印
            .SubmitPrint()

        End With
    End Sub

    Private Sub frmPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oPrintDocument As New Printing.PrintDocument
        Dim strDefaultPrinter As String = oPrintDocument.PrinterSettings.PrinterName

        For Each strPrinterName As String In Printing.PrinterSettings.InstalledPrinters
            cmbPrinter.Items.Add(strPrinterName)
            If strPrinterName = strDefaultPrinter Then
                cmbPrinter.SelectedIndex = cmbPrinter.Items.IndexOf(strPrinterName)
            End If
        Next
    End Sub

    Private Sub btnLoadAsm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadAsm.Click
        Dim oOpenFileDialog As New OpenFileDialog
        Dim oAssemblyDocument As Inventor.AssemblyDocument = Nothing

        lblsuggest.Visible = False

        With oOpenFileDialog
            .Title = "打开"
            .Filter = "AutoDesk Inventor 部件(*.iam)|*.iam" '添加过滤文件
            .Multiselect = False  '多开文件打开
            .FileName = ""
            If .ShowDialog = Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                If .FileName <> "" Then '如果有选中文件
                    oAssemblyDocument = ThisApplication.Documents.Open(.FileName)
                End If
            Else
                Exit Sub
            End If
        End With

        '        ' 获取所有引用文档
        '        Dim oAllReferencedDocuments As DocumentsEnumerator
        '        oAllReferencedDocuments = AssDoc.AllReferencedDocuments

        '        ' 遍历这些文档

        '        For Each ReferencedDocument As Inventor.Document In oAllReferencedDocuments

        '            Dim FullFileName As String
        '            FullFileName = ReferencedDocument.FullDocumentName

        '            Dim IdwFullFileName As String
        '            IdwFullFileName = GetNewExtensionFileName(FullFileName, ".idw")

        '            If IsFileExsts(IdwFullFileName) = False Then   '跳过不存在的文件
        '                GoTo 999
        '            End If

        '            If InStr(FullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
        '                GoTo 999
        '            End If

        '            lvwFileListView.Items.Add(IdwFullFileName)

        '999:
        '        Next

        '===================================
        '基于bom结构化数据，可跳过参考的文件
        ' Set a reference to the BOM
        Dim oBOM As BOM
        oBOM = oAssemblyDocument.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True

        'Set a reference to the "Structured" BOMView
        Dim oBOMView As BOMView

        btnLoadAsm.Enabled = False
        'ThisApplication.Cursor  = Cursors.WaitCursor

        lvwFileListView.BeginUpdate()

        '获取结构化的bom页面
        For Each oBOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                '遍历这个bom页面
                QueryBOMRowToLoadFile(oBOMView.BOMRows, lvwFileListView)
            End If
        Next

        lvwFileListView.EndUpdate()
        'ThisApplication.Cursor  = Cursors.Default
        btnLoadAsm.Enabled = True
        Me.Text = "批量打印  (共" & lvwFileListView.Items.Count & "张）"
    End Sub

    Private Sub QueryBOMRowToLoadFile(ByVal oBOMRows As BOMRowsEnumerator, ByVal olistiview As ListView)
        Dim i As Integer

        Dim iStepCount As Short
        iStepCount = oBOMRows.Count

        'Create a new ProgressBar object.
        'Dim oProgressBar As Inventor.ProgressBar

        'oProgressBar = ThisApplication.CreateProgressBar(False, iStepCount, "当前文件： ")

        For i = 1 To oBOMRows.Count
            ' Get the current row.
            Dim oBOMRow As BOMRow
            oBOMRow = oBOMRows.Item(i)

            Dim oFullFileName As String
            oFullFileName = oBOMRow.ReferencedFileDescriptor.FullFileName

            '测试文件
            Debug.Print(oFullFileName)

            ' Set the message for the progress bar
            'oProgressBar.Message = oFullFileName

            Dim strInventorDrawingFullFileName As String
            strInventorDrawingFullFileName = GetNewExtensionFileName(oFullFileName, ".idw")

            If IsFileExsts(strInventorDrawingFullFileName) = False Then   '跳过不存在的文件
                GoTo 999
            End If

            'If InStr(oFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
            '    GoTo 999
            'End If

            If IsItemInListView(lvwFileListView, strInventorDrawingFullFileName) = False Then
                lvwFileListView.Items.Add(strInventorDrawingFullFileName)
            End If

            '遍历下一级
            If (Not oBOMRow.ChildRows Is Nothing) Then
                Call QueryBOMRowToLoadFile(oBOMRow.ChildRows, olistiview)
            End If

999:
            'oProgressBar.UpdateProgress()
        Next

        'oProgressBar.Close()

    End Sub

    Private Sub btnLoadIdw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadIdw.Click
        Try
            lblsuggest.Visible = False

            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            btnLoadIdw.Enabled = False
            'ThisApplication.Cursor  = Cursors.WaitCursor

            For Each oInventorDocument As Inventor.Document In ThisApplication.Documents
                If oInventorDocument.DocumentType = DocumentTypeEnum.kDrawingDocumentObject Then

                    If IsItemInListView(lvwFileListView, oInventorDocument.FullDocumentName) = False Then
                        lvwFileListView.Items.Add(oInventorDocument.FullDocumentName)
                    End If

                End If
            Next

            btnLoadIdw.Enabled = True
            'ThisApplication.Cursor  = Cursors.Default

            Me.Text = "批量打印  (共" & lvwFileListView.Items.Count & "张）"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '移除
    Private Sub tsmiRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiRemove.Click
        ListViewDel(lvwFileListView)
        Me.Text = "批量打印  (共" & lvwFileListView.Items.Count & "张）"
    End Sub

    '筛选移除
    Private Sub tsmiRemoveFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiRemoveFilter.Click
        Dim strFilter As String

        Dim frmInputBox As New frmInputBox
999:
        With frmInputBox
            .txtInPut.Text = ""
            .Text = "筛选文件"
            .lblDescribe.Text = "按图号输入筛选字段。"
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With

        If (frmInputBox.DialogResult = Windows.Forms.DialogResult.OK) And (frmInputBox.txtInPut.Text <> "") Then
            strFilter = frmInputBox.txtInPut.Text
        Else
            Exit Sub
        End If

        For Each oListViewItem As ListViewItem In lvwFileListView.Items
            Dim strInventorDrawingFullFileName As String  '工程图全文件名
            strInventorDrawingFullFileName = oListViewItem.Text

            Dim strInventorDrawingFileOnlyName As String
            strInventorDrawingFileOnlyName = GetFileNameInfo(strInventorDrawingFullFileName).OnlyName

            If InStr(strInventorDrawingFileOnlyName, strFilter) <> 0 Then
                oListViewItem.Remove()
            End If

        Next
        Me.Text = "批量打印  (共" & lvwFileListView.Items.Count & "张）"
    End Sub

    '筛选保留
    Private Sub tsmiSaveFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiSaveFilter.Click
        Dim strFilter As String

        Dim frmInputBox As New frmInputBox
999:
        With frmInputBox
            .txtInPut.Text = ""
            .Text = "筛选文件"
            .lblDescribe.Text = "按图号输入筛选字段。"
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With

        If (frmInputBox.DialogResult = Windows.Forms.DialogResult.OK) And (frmInputBox.txtInPut.Text <> "") Then
            strFilter = frmInputBox.txtInPut.Text
        Else
            Exit Sub
        End If

        For Each oListViewItem As ListViewItem In lvwFileListView.Items
            Dim strInventorDrawingFullFileName As String  '工程图全文件名
            strInventorDrawingFullFileName = oListViewItem.Text

            Dim strInventorDrawingFileOnlyName As String
            strInventorDrawingFileOnlyName = GetFileNameInfo(strInventorDrawingFullFileName).OnlyName

            If InStr(strInventorDrawingFileOnlyName, strFilter) = 0 Then
                oListViewItem.Remove()
            End If

        Next

        Me.Text = "批量打印  (共" & lvwFileListView.Items.Count & "张）"
    End Sub

    Private Sub btnLoadActiveAsm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadActiveAsm.Click

        lblsuggest.Visible = False

        lvwFileListView.Items.Clear()

        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        If oInventorDocument.DocumentType <> kAssemblyDocumentObject Then
            MsgBox("该功能仅适用于部件", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim oAssemblyDocument As AssemblyDocument
        oAssemblyDocument = oInventorDocument

        '===================================
        '基于bom结构化数据，可跳过参考的文件
        ' Set a reference to the BOM
        Dim oBOM As BOM
        oBOM = oAssemblyDocument.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True

        'Set a reference to the "Structured" BOMView
        Dim oBOMView As BOMView

        btnLoadActiveAsm.Enabled = False
        'ThisApplication.Cursor  = Cursors.WaitCursor

        lvwFileListView.BeginUpdate()

        '获取结构化的bom页面
        For Each oBOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                '遍历这个bom页面
                QueryBOMRowToLoadFile(oBOMView.BOMRows, lvwFileListView)
            End If
        Next

        lvwFileListView.EndUpdate()
        btnLoadActiveAsm.Enabled = True
        'ThisApplication.Cursor  = Cursors.Default
        Me.Text = "批量打印  (共" & lvwFileListView.Items.Count & "张）"
    End Sub

    Private Sub lvwFileListView_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvwFileListView.MouseDoubleClick
        ThisApplication.Documents.Open(lvwFileListView.SelectedItems(0).Text)
    End Sub

    '拖入文件夹 和 文件
    Private Sub lvwFileListView_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvwFileListView.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then

            Dim File_lists() As String
            Dim File_Attribute As FileInfo

            Dim strDestinationFolder As String = Nothing
            Dim oFileAttributes As FileAttributes
            Dim strPresentFolder As String = Nothing

            lblsuggest.Visible = False

            Me.Text = "批量打印  (共" & lvwFileListView.Items.Count & "张）"

            ' Assign the files to an array.
            File_lists = e.Data.GetData(DataFormats.FileDrop)
            ' Loop through the array and add the files to the list.
            lvwFileListView.BeginUpdate()

            For Each strInventorDrawingFullFileName As String In File_lists
                File_Attribute = My.Computer.FileSystem.GetFileInfo(strInventorDrawingFullFileName)

                Select Case File_Attribute.Attributes
                    Case FileAttributes.Device

                    Case FileAttributes.Directory
                        strDestinationFolder = strInventorDrawingFullFileName

                        oFileAttributes = FileSystem.GetAttr(strDestinationFolder)

                        If oFileAttributes = FileAttributes.Directory Then
                            strDestinationFolder = strDestinationFolder + "\"
                            strPresentFolder = My.Computer.FileSystem.GetParentPath(strDestinationFolder)
                        End If

                        GetAllFile(strPresentFolder, strDestinationFolder, lvwFileListView)

                    Case Else
                        If IsItemInListView(lvwFileListView, strInventorDrawingFullFileName) = False Then
                            If LCaseGetFileExtension(strInventorDrawingFullFileName) = IDW Then
                                lvwFileListView.Items.Add(strInventorDrawingFullFileName)
                            End If
                        End If

                End Select
            Next

            lvwFileListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
            lvwFileListView.EndUpdate()
            Me.Text = "批量打印  (共" & lvwFileListView.Items.Count & "张）"
        End If
    End Sub

    '拖拽文件夹和文件
    Private Sub lvwFileListView_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvwFileListView.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub
End Class