Imports Inventor
Imports Inventor.DocumentTypeEnum
Imports Microsoft
Imports Microsoft.VisualBasic
Imports stdole
Imports System
Imports System.Collections.ObjectModel
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports System.Xml

Public Class frmPrint

    '批量打印开始
    Private Sub btn开始_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn开始.Click
        On Error Resume Next

        If lvw文件列表.Items.Count = 0 Then
            MsgBox("未添加工程图文件。", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "批量另存为")
            Exit Sub
        End If

        btn开始.Enabled = False

        Dim oInteraction As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        oInteraction.Start()
        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)

        Dim strPrinterName As String = ""
        strPrinterName = cmb打印机.Text

        'For i = 0 To lvwFileListView.Items.Count - 1

        For Each oListViewItem As ListViewItem In lvw文件列表.Items
            'lvwFileListView.Items(i).Selected = True
            oListViewItem.ForeColor = Drawing.Color.BlueViolet

            Me.Text = "批量打印  (第" & oListViewItem.Index + 1 & "张，共" & lvw文件列表.Items.Count & "张）"

            '打开文件
            Dim strInventorDrawingFullFileName As String  '工程图全文件名

            strInventorDrawingFullFileName = oListViewItem.Text

            If IsFileExsts(strInventorDrawingFullFileName) = False Then   '跳过不存在的文件
                GoTo 999
            End If

            'If InStr(InvDocFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
            '    GoTo 999
            'End If

            'Me.TopMost = False

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            '打开工程图
            oInventorDrawingDocument = ThisApplication.Documents.Open(strInventorDrawingFullFileName, True)

            'Me.TopMost = True

            '刷新sheets
            If chk刷新工程图.Checked = True Then
                SetStatusBarText("正在更新工程图 ...")
                oInventorDrawingDocument.Rebuild()
            End If

            'If oInventorDrawingDocument.Sheets Is Nothing Then GoTo 999
            'Dim oSheet As Inventor.Sheet
            'For Each oSheet In oInventorDrawingDocument.Sheets
            '    For Each oDwgView In oSheet.DrawingViews
            '        Do While oDwgView.IsUpdateComplete = False
            '            ThisApplication.UserInterfaceManager.DoEvents()
            '        Loop
            '    Next
            'Next

            '设置签字
            Dim strPrintDate As String
            strPrintDate = Today.Year & "." & Today.Month & "." & Today.Day
            If chk签字.Checked = True Then
                SetSign(oInventorDrawingDocument, EngineerName, strPrintDate, False)
            End If

            '打印文件
            PrintDrawing(oInventorDrawingDocument, strPrinterName, chk打印为黑色.Checked, nud份数.Value, chk匹配A3.Checked)

            'Me.TopMost = False

            Dim strIdwFullFileName As String
            strIdwFullFileName = oInventorDrawingDocument.FullFileName

            '另存为pdf
            If chk存为pdf.Checked = True Then
                Dim strPdfFullFileName As String        'pdf文件全文件名
                strIdwFullFileName = oInventorDrawingDocument.FullFileName
                strPdfFullFileName = GetChangeExtension(strIdwFullFileName, PDF)
                IdwSaveAsPdfSub(strIdwFullFileName, strPdfFullFileName)

            End If

            '另存为dwg
            If chk存为dwg.Checked = True Then
                Dim strDwgFullFileName As String        'cad 文件全文件名
                strIdwFullFileName = oInventorDrawingDocument.FullFileName
                strDwgFullFileName = GetChangeExtension(strIdwFullFileName, DWG)
                IdwSaveAsDwgSub(strIdwFullFileName, strDwgFullFileName)
            End If

            '保存文件
            If chk保存工程图.Checked = True Then
                oInventorDrawingDocument.Save2(True)
            End If

            '关闭文件
            If chk打印后关闭.Checked = True Then
                oInventorDrawingDocument.Close(True)
            End If

999:
        Next
        'MsgBox("批量打印工程图完成", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "批量打印")

        btn开始.Enabled = True

        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        oInteraction.Stop()

        SetStatusBarText("批量打印工程图完成")
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel

        If chk关闭窗口.Checked = True Then
            lvw文件列表.Items.Clear()
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Dispose()
        End If

    End Sub

    '关闭
    Private Sub btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click
        lvw文件列表.Items.Clear()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    '添加文件
    Private Sub btn添加文件_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn添加文件.Click

        Dim oOpenFileDialog As New OpenFileDialog

        lbl建议.Visible = False

        With oOpenFileDialog
            .Title = "打开"
            .FileName = ""
            .Filter = "AutoDesk Inventor 工程图文件(*.idw)|*.idw" '添加过滤文件
            .Multiselect = True '多开文件打开
            If .ShowDialog = Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                If .FileName <> "" Then '如果有选中文件

                    btn添加文件.Enabled = False
                    'ThisApplication.Cursor  = Cursors.WaitCursor

                    For Each strInventorDrawingFullFileName As String In .FileNames

                        If IsItemInListView(lvw文件列表, strInventorDrawingFullFileName) = False Then
                            lvw文件列表.Items.Add(strInventorDrawingFullFileName)
                        End If

                    Next

                    btn添加文件.Enabled = True
                    'ThisApplication.Cursor  = Cursors.Default
                End If
            Else
                Exit Sub
            End If

            Me.Text = "批量打印  (共" & lvw文件列表.Items.Count & "张）"

        End With
    End Sub

    '清空文件列表
    Private Sub btn清空列表_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn清空列表.Click
        lvw文件列表.Items.Clear()
        Me.Text = "批量打印"
    End Sub

    '添加文件夹
    Private Sub btn添加文件夹_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn添加文件夹.Click
        Dim strDestinationFolder As String = Nothing
        Dim oFileAttributes As FileAttributes
        Dim strPresentFolder As String = Nothing
        Dim oFolderBrowserDialog As New FolderBrowserDialog

        lbl建议.Visible = False

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

        btn添加文件夹.Enabled = False
        'ThisApplication.Cursor  = Cursors.WaitCursor

        '是否为文件夹，在其后添加 \，得到父文件夹
        oFileAttributes = FileSystem.GetAttr(strDestinationFolder)

        If oFileAttributes = FileAttributes.Directory Then
            strDestinationFolder = strDestinationFolder + "\"
            strPresentFolder = My.Computer.FileSystem.GetParentPath(strDestinationFolder)
        End If

        GetAllFile(strPresentFolder, strDestinationFolder, lvw文件列表, IDW)

        btn添加文件夹.Enabled = True
        'ThisApplication.Cursor  = Cursors.Default

        Me.Text = "批量打印  (共" & lvw文件列表.Items.Count & "张）"
    End Sub

    Private Sub frmPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oPrintDocument As New Printing.PrintDocument
        Dim strDefaultPrinter As String = oPrintDocument.PrinterSettings.PrinterName

        For Each strPrinterName As String In Printing.PrinterSettings.InstalledPrinters
            cmb打印机.Items.Add(strPrinterName)
            If strPrinterName = strDefaultPrinter Then
                cmb打印机.SelectedIndex = cmb打印机.Items.IndexOf(strPrinterName)
            End If
        Next

        For Each cmblist In cmb打印机.Items
            If cmblist = Printer Then
                cmb打印机.Text = Printer
            End If
        Next

        'If IsSign = 1 Then
        '    chk签字.Checked = True
        'Else
        '    chk签字.Checked = False
        'End If

        'If IsPaperA3 = 1 Then
        '    chk匹配A3.Checked = True
        'Else
        '    chk匹配A3.Checked = False
        'End If

        'Select Case SaveAsDawAndPdf
        '    Case "不另存"
        '        chk存为dwg.Checked = False
        '        chk存为pdf.Checked = False
        '    Case "另存为dwg"
        '        chk存为dwg.Checked = True
        '        chk存为pdf.Checked = False
        '    Case "另存为pdf"
        '        chk存为dwg.Checked = False
        '        chk存为pdf.Checked = True
        '    Case "另存为dwg和pdf"
        '        chk存为dwg.Checked = True
        '        chk存为pdf.Checked = True
        'End Select


        Dim binaryArray(PrintSetting.Length - 1) As String

        For i As Integer = 0 To PrintSetting.Length - 1
            binaryArray(i) = Strings.Mid(PrintSetting, i + 1, 1)
        Next

        chk匹配A3.Checked = IntToBool(binaryArray(0))
        chk签字.Checked = IntToBool(binaryArray(1))
        chk刷新工程图.Checked = IntToBool(binaryArray(2))
        chk存为pdf.Checked = IntToBool(binaryArray(3))
        chk关闭窗口.Checked = IntToBool(binaryArray(4))
        chk打印为黑色.Checked = IntToBool(binaryArray(5))
        chk打印后关闭.Checked = IntToBool(binaryArray(6))
        chk保存签字.Checked = IntToBool(binaryArray(7))
        chk保存工程图.Checked = IntToBool(binaryArray(8))
        chk存为dwg.Checked = IntToBool(binaryArray(9))

    End Sub

    Private Sub btn从部件导入_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn从部件导入.Click
        Dim oOpenFileDialog As New OpenFileDialog
        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument = Nothing

        lbl建议.Visible = False

        With oOpenFileDialog
            .Title = "打开"
            .Filter = "AutoDesk Inventor 部件(*.iam)|*.iam" '添加过滤文件
            .Multiselect = False  '多开文件打开
            .FileName = ""
            If .ShowDialog = Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                If .FileName <> "" Then '如果有选中文件
                    oInventorAssemblyDocument = ThisApplication.Documents.Open(.FileName)
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
        '            IdwFullFileName = GetNewExtensionFileName(FullFileName, idw)

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
        oBOM = oInventorAssemblyDocument.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True

        'Set a reference to the "Structured" BOMView
        Dim oBOMView As BOMView

        btn从部件导入.Enabled = False
        'ThisApplication.Cursor  = Cursors.WaitCursor

        lvw文件列表.BeginUpdate()

        '获取结构化的bom页面
        For Each oBOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                '遍历这个bom页面
                QueryBOMRowToLoadFile(oBOMView.BOMRows, lvw文件列表)
            End If
        Next

        lvw文件列表.EndUpdate()
        'ThisApplication.Cursor  = Cursors.Default
        btn从部件导入.Enabled = True
        Me.Text = "批量打印  (共" & lvw文件列表.Items.Count & "张）"
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
            strInventorDrawingFullFileName = GetChangeExtension(oFullFileName, IDW)

            If IsFileExsts(strInventorDrawingFullFileName) = False Then   '跳过不存在的文件
                GoTo 999
            End If

            'If InStr(oFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
            '    GoTo 999
            'End If

            If IsItemInListView(lvw文件列表, strInventorDrawingFullFileName) = False Then
                lvw文件列表.Items.Add(strInventorDrawingFullFileName)
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

    Private Sub btn导入已打开文件_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn导入已打开文件.Click
        Try
            lbl建议.Visible = False

            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            btn导入已打开文件.Enabled = False
            'ThisApplication.Cursor  = Cursors.WaitCursor

            For Each oInventorDocument As Inventor.Document In ThisApplication.Documents
                If oInventorDocument.DocumentType = DocumentTypeEnum.kDrawingDocumentObject Then

                    If IsItemInListView(lvw文件列表, oInventorDocument.FullDocumentName) = False Then
                        lvw文件列表.Items.Add(oInventorDocument.FullDocumentName)
                    End If

                End If
            Next

            btn导入已打开文件.Enabled = True
            'ThisApplication.Cursor  = Cursors.Default

            Me.Text = "批量打印  (共" & lvw文件列表.Items.Count & "张）"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '移除
    Private Sub tsmi移出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi移出.Click
        ListViewDel(lvw文件列表)
        Me.Text = "批量打印  (共" & lvw文件列表.Items.Count & "张）"
    End Sub

    '筛选移除
    Private Sub tsmi筛选移出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi筛选移出.Click
        Dim strFilter As String

        Me.TopMost = False

        Dim frmInputBox As New frmInputBox
999:
        With frmInputBox
            .txt输入.Text = ""
            .Text = "筛选文件"
            .lbl描述.Text = "输入需要移除的筛选字段，将移除包含字段的工程图。"
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With

        If (frmInputBox.DialogResult = Windows.Forms.DialogResult.OK) And (frmInputBox.txt输入.Text <> "") Then
            strFilter = frmInputBox.txt输入.Text
        Else
            Me.TopMost = True
            Exit Sub
        End If

        For Each oListViewItem As ListViewItem In lvw文件列表.Items
            Dim strInventorDrawingFullFileName As String  '工程图全文件名
            strInventorDrawingFullFileName = oListViewItem.Text

            Dim strInventorDrawingFileOnlyName As String
            strInventorDrawingFileOnlyName = GetFileNameInfo(strInventorDrawingFullFileName).OnlyName

            If InStr(strInventorDrawingFileOnlyName, strFilter) <> 0 Then
                oListViewItem.Remove()
            End If

        Next
        Me.Text = "批量打印  (共" & lvw文件列表.Items.Count & "张）"
        Me.TopMost = True
    End Sub

    '筛选保留
    Private Sub tsmi筛选保留_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi筛选保留.Click
        Dim strFilter As String
        Me.TopMost = False
        Dim frmInputBox As New frmInputBox
999:
        With frmInputBox
            .txt输入.Text = ""
            .Text = "筛选文件"
            .lbl描述.Text = "输入需要保留的筛选字段，将保留包含字段的工程图。"
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With

        If (frmInputBox.DialogResult = Windows.Forms.DialogResult.OK) And (frmInputBox.txt输入.Text <> "") Then
            strFilter = frmInputBox.txt输入.Text
        Else
            Me.TopMost = True
            Exit Sub
        End If

        For Each oListViewItem As ListViewItem In lvw文件列表.Items
            Dim strInventorDrawingFullFileName As String  '工程图全文件名
            strInventorDrawingFullFileName = oListViewItem.Text

            Dim strInventorDrawingFileOnlyName As String
            strInventorDrawingFileOnlyName = GetFileNameInfo(strInventorDrawingFullFileName).OnlyName

            If InStr(strInventorDrawingFileOnlyName, strFilter) = 0 Then
                oListViewItem.Remove()
            End If

        Next

        Me.Text = "批量打印  (共" & lvw文件列表.Items.Count & "张）"
        Me.TopMost = True
    End Sub

    Private Sub btn导入当前部件_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn导入当前部件.Click

        lbl建议.Visible = False

        lvw文件列表.Items.Clear()

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

        Dim oInventorAssemblyDocument As AssemblyDocument
        oInventorAssemblyDocument = oInventorDocument

        '===================================
        '基于bom结构化数据，可跳过参考的文件
        ' Set a reference to the BOM
        Dim oBOM As BOM
        oBOM = oInventorAssemblyDocument.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True

        'Set a reference to the "Structured" BOMView
        Dim oBOMView As BOMView

        btn导入当前部件.Enabled = False
        'ThisApplication.Cursor  = Cursors.WaitCursor

        lvw文件列表.BeginUpdate()

        '获取结构化的bom页面
        For Each oBOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                '遍历这个bom页面
                QueryBOMRowToLoadFile(oBOMView.BOMRows, lvw文件列表)
            End If
        Next

        lvw文件列表.EndUpdate()
        btn导入当前部件.Enabled = True
        'ThisApplication.Cursor  = Cursors.Default
        Me.Text = "批量打印  (共" & lvw文件列表.Items.Count & "张）"
    End Sub

    Private Sub lvw文件列表_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvw文件列表.MouseDoubleClick
        ThisApplication.Documents.Open(lvw文件列表.SelectedItems(0).Text)
    End Sub

    '拖入文件夹 和 文件
    Private Sub lvw文件列表_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvw文件列表.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then

            Dim File_lists() As String
            Dim File_Attribute As FileInfo

            Dim strDestinationFolder As String = Nothing
            Dim oFileAttributes As FileAttributes
            Dim strPresentFolder As String = Nothing

            lbl建议.Visible = False

            Me.Text = "批量打印  (共" & lvw文件列表.Items.Count & "张）"

            ' Assign the files to an array.
            File_lists = e.Data.GetData(DataFormats.FileDrop)
            ' Loop through the array and add the files to the list.
            lvw文件列表.BeginUpdate()

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

                        GetAllFile(strPresentFolder, strDestinationFolder, lvw文件列表, IDW)

                    Case Else
                        If IsItemInListView(lvw文件列表, strInventorDrawingFullFileName) = False Then
                            If LCaseGetFileExtension(strInventorDrawingFullFileName) = IDW Then
                                lvw文件列表.Items.Add(strInventorDrawingFullFileName)
                            End If
                        End If

                End Select
            Next

            lvw文件列表.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
            lvw文件列表.EndUpdate()
            Me.Text = "批量打印  (共" & lvw文件列表.Items.Count & "张）"
        End If
    End Sub

    '拖拽文件夹和文件
    Private Sub lvw文件列表_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvw文件列表.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub btn保存配置_Click(sender As Object, e As EventArgs) Handles btn保存配置.Click
        PrintSetting = BoolToInt(chk匹配A3.Checked) & BoolToInt(chk签字.Checked) & BoolToInt(chk刷新工程图.Checked) & _
             BoolToInt(chk存为pdf.Checked) & BoolToInt(chk关闭窗口.Checked) & BoolToInt(chk打印为黑色.Checked) & _
            BoolToInt(chk打印后关闭.Checked) & BoolToInt(chk保存签字.Checked) & BoolToInt(chk保存工程图.Checked) & BoolToInt(chk存为dwg.Checked)

        InAISettingXmlWriteSetting()
    End Sub
End Class