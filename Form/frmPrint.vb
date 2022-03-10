Imports System.Windows.Forms
Imports Inventor
Imports System
Imports System.IO
Imports Microsoft
Imports Microsoft.VisualBasic
Imports System.Collections.ObjectModel
Imports stdole
Imports System.Drawing

Public Class frmPrint

    '批量打印开始
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        If lvwFileListView.Items.Count = 0 Then
            MsgBox("未添加工程图文件。", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "批量另存为")
            Exit Sub
        End If

        Dim sPrinterName As String = ""
        sPrinterName = cmbPrinter.Text

        'For i = 0 To lvwFileListView.Items.Count - 1

        For Each olistviewitem As ListViewItem In lvwFileListView.Items
            'lvwFileListView.Items(i).Selected = True
            olistviewitem.Selected = True
            '打开文件
            Dim InvDocFullFileName As String  '工程图全文件名

            InvDocFullFileName = olistviewitem.Text

            If IsFileExsts(InvDocFullFileName) = False Then   '跳过不存在的文件
                GoTo 999
            End If

            'If InStr(InvDocFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
            '    GoTo 999
            'End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            '打开工程图
            oInventorDrawingDocument = ThisApplication.Documents.Open(InvDocFullFileName, True)

            '保存文件
            If chkSave.Checked = True Then
                oInventorDrawingDocument.Save2(True)
            End If

            '设置签字
            Dim Print_Day As String
            Print_Day = Today.Year & "." & Today.Month & "." & Today.Day
            If chkSign.CheckState = CheckState.Checked Then
                SetSign(oInventorDrawingDocument, EngineerName, Print_Day, False)
            End If

            '打印文件
            PrintDrawing(oInventorDrawingDocument, sPrinterName)

            '关闭文件
            If chkClose.Checked = True Then
                oInventorDrawingDocument.Close(True)
            End If

999:
        Next
        'MsgBox("批量打印工程图完成", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "批量打印")

        lvwFileListView.Items.Clear()
        SetStatusBarText("批量打印工程图完成")

    End Sub

    '关闭
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        lvwFileListView.Items.Clear()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    '添加文件
    Private Sub btnAddFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFile.Click

        Dim NewOpenFileDialog As New OpenFileDialog

        lblsuggest.Visible = False

        With NewOpenFileDialog
            .Title = "打开"
            .FileName = ""
            .Filter = "AutoDesk Inventor 工程图文件(*.idw)|*.idw" '添加过滤文件
            .Multiselect = True '多开文件打开
            If .ShowDialog = Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                If .FileName <> "" Then '如果有选中文件
                    For Each IdwFullFileName As String In .FileNames

                        AddItemToListView(lvwFileListView, IdwFullFileName)

                    Next
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
        Dim destinationFolder As String = Nothing
        Dim inf As FileAttributes
        Dim Present_Folder As String = Nothing
        Dim oFolderBrowserDialog As New FolderBrowserDialog

        lblsuggest.Visible = False

        With oFolderBrowserDialog
            .ShowNewFolderButton = False
            .Description = "添加文件夹"
            .RootFolder = System.Environment.SpecialFolder.Desktop
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                destinationFolder = .SelectedPath
            Else
                Exit Sub
            End If
        End With

        '是否为文件夹，在其后添加 \，得到父文件夹
        inf = FileSystem.GetAttr(destinationFolder)

        If inf = FileAttributes.Directory Then
            destinationFolder = destinationFolder + "\"
            Present_Folder = My.Computer.FileSystem.GetParentPath(destinationFolder)
        End If

        GetAllFile(Present_Folder, destinationFolder, lvwFileListView)

        Me.Text = "批量打印  (共" & lvwFileListView.Items.Count & "张）"
    End Sub

    '打印文档，打印机名称
    Private Sub PrintDrawing(ByVal oInventorDrawingDocument As Inventor.DrawingDocument, ByVal sPrinterName As String)

        ' Set a reference to the print manager object of the active document.
        ' This will fail if a drawing document is not active.
        Dim oPrintMgr As DrawingPrintManager

        oPrintMgr = oInventorDrawingDocument.PrintManager

        With oPrintMgr
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
        Dim prtdoc As New Printing.PrintDocument
        Dim strDefaultPrinter As String = prtdoc.PrinterSettings.PrinterName

        Dim strPrinter As String
        For Each strPrinter In Printing.PrinterSettings.InstalledPrinters
            cmbPrinter.Items.Add(strPrinter)
            If strPrinter = strDefaultPrinter Then
                cmbPrinter.SelectedIndex = cmbPrinter.Items.IndexOf(strPrinter)
            End If
        Next strPrinter
    End Sub

    Private Sub btnLoadAsm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadAsm.Click
        Dim oOpenFileDialog As New OpenFileDialog
        Dim AssDoc As AssemblyDocument = Nothing

        lblsuggest.Visible = False

        With oOpenFileDialog
            .Title = "打开"
            .Filter = "AutoDesk Inventor 部件(*.iam)|*.iam" '添加过滤文件
            .Multiselect = False  '多开文件打开
            .FileName = ""
            If .ShowDialog = Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                If .FileName <> "" Then '如果有选中文件
                    AssDoc = ThisApplication.Documents.Open(.FileName)
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
        oBOM = AssDoc.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True

        'Set a reference to the "Structured" BOMView
        Dim oBOMView As BOMView

        Me.Cursor = Cursors.WaitCursor

        lvwFileListView.BeginUpdate()

        '获取结构化的bom页面
        For Each oBOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                '遍历这个bom页面
                QueryBOMRowToLoadFile(oBOMView.BOMRows, lvwFileListView)
            End If
        Next

        lvwFileListView.EndUpdate()
        Me.Cursor = Cursors.Default
        Me.Text = "批量打印  (共" & lvwFileListView.Items.Count & "张）"
    End Sub

    Private Sub QueryBOMRowToLoadFile(ByVal oBOMRows As BOMRowsEnumerator, olistiview As ListView)
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

            Dim IdwFullFileName As String
            IdwFullFileName = GetNewExtensionFileName(oFullFileName, ".idw")

            If IsFileExsts(IdwFullFileName) = False Then   '跳过不存在的文件
                GoTo 999
            End If

            If InStr(oFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                GoTo 999
            End If

            AddItemToListView(lvwFileListView, IdwFullFileName)

            '遍历下一级
            If (Not oBOMRow.ChildRows Is Nothing) Then
                Call QueryBOMRowToLoadFile(oBOMRow.ChildRows, olistiview)
            End If

999:
            'oProgressBar.UpdateProgress()
        Next

        'oProgressBar.Close()

    End Sub


    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

  

    Private Sub btnLoadIdw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadIdw.Click
        Try
            lblsuggest.Visible = False

            SetStatusBarText()

            If IsInventorOpenDoc() = False Then
                Exit Sub
            End If

            For Each oInventorDocument As Inventor.Document In ThisApplication.Documents
                If oInventorDocument.DocumentType = DocumentTypeEnum.kDrawingDocumentObject Then

                    AddItemToListView(lvwFileListView, oInventorDocument.FullDocumentName)

                End If
            Next
            Me.Text = "批量打印  (共" & lvwFileListView.Items.Count & "张）"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

   
    '移除
    Private Sub tsmiRemove_Click(sender As System.Object, e As System.EventArgs) Handles tsmiRemove.Click
        ListViewDel(lvwFileListView)
        Me.Text = "批量打印  (共" & lvwFileListView.Items.Count & "张）"
    End Sub


    '筛选移除
    Private Sub tsmiRemoveFilter_Click(sender As System.Object, e As System.EventArgs) Handles tsmiRemoveFilter.Click
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
            Dim InvDocFullFileName As String  '工程图全文件名
            InvDocFullFileName = oListViewItem.Text

            Dim InvDocFullFileONlyName As String
            InvDocFullFileONlyName = GetFileNameInfo(InvDocFullFileName).ONlyName

            If InStr(InvDocFullFileONlyName, strFilter) <> 0 Then
                oListViewItem.Remove()
            End If

        Next
        Me.Text = "批量打印  (共" & lvwFileListView.Items.Count & "张）"
    End Sub


    '筛选保留
    Private Sub tsmiSaveFilter_Click(sender As System.Object, e As System.EventArgs) Handles tsmiSaveFilter.Click
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
            Dim InvDocFullFileName As String  '工程图全文件名
            InvDocFullFileName = oListViewItem.Text

            Dim InvDocFullFileONlyName As String
            InvDocFullFileONlyName = GetFileNameInfo(InvDocFullFileName).ONlyName

            If InStr(InvDocFullFileONlyName, strFilter) = 0 Then
                oListViewItem.Remove()
            End If

        Next

        Me.Text = "批量打印  (共" & lvwFileListView.Items.Count & "张）"
    End Sub



End Class