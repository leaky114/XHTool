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
Imports System.Collections.Generic

Public Class FormBatchPrint
    Private IsStopPrint As Double '中断打印标记

    '批量打印开始
    Private Sub Btn开始_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn开始.Click
        On Error Resume Next

        If lvw文件列表.Items.Count = 0 Then
            MessageBox.Show(”未添加工程图文件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        OInteractionEvents.Start()
        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        ThisApplication.UserInterfaceManager.DoEvents()

        Dim strPrinterName As String = ""
        strPrinterName = cmb打印机.Text

        btn开始.Enabled = False
        IsStopPrint = False

        str模型匹配检查标记 = 3

        For Each oListViewItem As ListViewItem In lvw文件列表.Items

            System.Windows.Forms.Application.DoEvents()

            If IsStopPrint = True Then
                Exit For
            End If

            oListViewItem.ForeColor = Drawing.Color.BlueViolet

            Me.Text = "批量打印  (第" & oListViewItem.Index + 1 & "张，共" & lvw文件列表.Items.Count & "张）"

            '打开文件
            Dim strInventorDrawingDocumentFullFileName As String  '工程图全文件名

            strInventorDrawingDocumentFullFileName = oListViewItem.Text

            If IsFileExists(strInventorDrawingDocumentFullFileName) = False Then   '跳过不存在的文件
                Continue For
            End If

            'if InStr(InvDocFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
            '    GoTo 999
            'End if

            'Me.TopMost = False

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            '打开工程图

            oInventorDrawingDocument = ThisApplication.Documents.Open(strInventorDrawingDocumentFullFileName, True)

            'Me.TopMost = True

            '刷新sheets
            If chk刷新工程图.Checked = True Then
                SetStatusBarText("正在更新工程图 ...")
                oInventorDrawingDocument.Rebuild()
            End If

            'if oInventorDrawingDocument.Sheets Is Nothing Then GoTo 999
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

            If IsShortData = 1 Then
                strPrintDate = Strings.Mid(Today.Year, 3, 2) & "." & Today.Month & "." & Today.Day
            Else
                strPrintDate = Today.Year & "." & Today.Month & "." & Today.Day
            End If

            If chk签字.Checked = True Then
                SetSign(oInventorDrawingDocument, EngineerName, strPrintDate, False)
            End If

            '打印文件
            PrintDrawing(oInventorDrawingDocument, strPrinterName, chk打印为黑色.Checked, nud份数.Value, cmb纸张尺寸.Text)


            '另存为pdf
            If chk存为pdf.Checked = True Then
                Dim strPdfFullFileName As String        'pdf文件全文件名

                If str另存到子文件夹 = "1" Then
                    Dim strChildDirectory As String

                    strChildDirectory = IO.Path.Combine(GetDirectoryName2(strInventorDrawingDocumentFullFileName), "PDF")

                    If IsDirectoryExists(strChildDirectory) = False Then
                        IO.Directory.CreateDirectory(strChildDirectory)
                    End If
                    strPdfFullFileName = IO.Path.Combine(strChildDirectory, GetFileNameInfo(strInventorDrawingDocumentFullFileName).OnlyName & PDF)
                Else
                    strPdfFullFileName = GetChangeExtension(strInventorDrawingDocumentFullFileName, PDF)
                End If

                IdwSaveAsPdfSub(strInventorDrawingDocumentFullFileName, strPdfFullFileName， True)

            End If

            '另存为dwg
            If chk存为dwg.Checked = True Then
                Dim strDwgFullFileName As String

                If str另存到子文件夹 = "1" Then
                    Dim strChildDirectory As String

                    strChildDirectory = IO.Path.Combine(GetDirectoryName2(strInventorDrawingDocumentFullFileName), "Dwg")
                    If IsDirectoryExists(strChildDirectory) = False Then
                        IO.Directory.CreateDirectory(strChildDirectory)
                    End If
                    strDwgFullFileName = IO.Path.Combine(strChildDirectory, GetFileNameInfo(strInventorDrawingDocumentFullFileName).OnlyName & DWG)
                Else
                    strDwgFullFileName = GetChangeExtension(strInventorDrawingDocumentFullFileName, DWG)
                End If

                IdwSaveAsDwgSub(strInventorDrawingDocumentFullFileName, strDwgFullFileName, True)

            End If


            If chk保存签字.Checked = False Then
                SetSign(oInventorDrawingDocument, "", "", False)
            End If

            '保存文件
            If chk保存工程图.Checked = True Then
                oInventorDrawingDocument.Save2(True)
            End If

            '关闭文件
            If chk打印后关闭.Checked = True Then
                oInventorDrawingDocument.Close(True)
            End If

        Next
        ' MessageBox.Show("批量打印工程图完成", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "批量打印")

        str模型匹配检查标记 = 1

        btn开始.Enabled = True

        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        OInteractionEvents.Stop()

        SetStatusBarText("批量打印工程图完成")

        If chk关闭窗口.Checked = True Then
            FormManager.CloseAndDisposeForm(Of FormBatchPrint)()
        End If

    End Sub

    '关闭
    Private Sub Btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click, Me.Closing
        FormManager.CloseAndDisposeForm(Of FormBatchPrint)()
    End Sub

    '添加文件
    Private Sub Btn添加文件_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn添加文件.Click
        Me.TopMost = False

        Dim strFilter As String = "Autodesk Inventor 工程图(*.idw)|*.idw" '添加过滤文件

        Dim strFile = IO.Path.Combine(ThisApplication.FileLocations.Workspace, "选择工程图文件")

        Dim oFileList As List(Of String)
        oFileList = OpenFileDialog(strFilter, True, strFile)

        If oFileList Is Nothing Then
            Exit Sub
        End If

        lbl建议.Visible = False

        For Each strInventorDrawingDocumentFullFileName In oFileList
            If IsItemInListView(lvw文件列表, strInventorDrawingDocumentFullFileName) = False Then
                lvw文件列表.Items.Add(strInventorDrawingDocumentFullFileName)
            End If
        Next

        Me.Text = "批量打印  (共" & lvw文件列表.Items.Count & "张）"

    End Sub

    '清空文件列表
    Private Sub Btn清空列表_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn清空列表.Click
        lvw文件列表.Items.Clear()
        Me.Text = "批量打印"
    End Sub

    '添加文件夹
    Private Sub Btn添加文件夹_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn添加文件夹.Click
        Me.TopMost = False

        Dim strFile = IO.Path.Combine(ThisApplication.FileLocations.Workspace, "选择一个文件确定文件夹")
        Dim strDestinationFolder As String = OpenFolderDialog(strFile)

        If strDestinationFolder Is Nothing Then
            Exit Sub
        End If

        lbl建议.Visible = False

        Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        OInteractionEvents.Start()
        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        ThisApplication.UserInterfaceManager.DoEvents()

        GetAllFile(strDestinationFolder, lvw文件列表, IDW)

        OInteractionEvents.Stop()

        Me.Text = "批量打印  (共" & lvw文件列表.Items.Count & "张）"
    End Sub

    Private Sub FrmPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48

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

        cmb纸张尺寸.Text = ini.GetStrFromINI("打印", "纸张尺寸"， ”A3“, IniFile)

        Dim binaryArray(PrintSetting.Length - 1) As String

        For i As Integer = 0 To PrintSetting.Length - 1
            binaryArray(i) = Strings.Mid(PrintSetting, i + 1, 1)
        Next

        chk签字.Checked = IntToBool(binaryArray(1))
        chk刷新工程图.Checked = IntToBool(binaryArray(2))
        chk存为pdf.Checked = IntToBool(binaryArray(3))
        chk关闭窗口.Checked = IntToBool(binaryArray(4))
        chk打印为黑色.Checked = IntToBool(binaryArray(5))
        chk打印后关闭.Checked = IntToBool(binaryArray(6))
        chk保存签字.Checked = IntToBool(binaryArray(7))
        chk保存工程图.Checked = IntToBool(binaryArray(8))
        chk存为dwg.Checked = IntToBool(binaryArray(9))

        SetWindowSizeAndCenter(Me)

    End Sub

    Private Sub Btn从部件导入_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn从部件导入.Click
        Me.TopMost = False

        Dim strFilter As String = "Autodesk Inventor 部件(*.iam)|*.iam" '添加过滤文件

        Dim strFile = IO.Path.Combine(ThisApplication.FileLocations.Workspace, "选择部件文件")

        Dim oFileList As List(Of String)
        oFileList = OpenFileDialog(strFilter, False, strFile)

        If oFileList Is Nothing Then
            Exit Sub
        End If

        lbl建议.Visible = False

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.Documents.Open(oFileList.Item(0).ToString)

        LoadBOM(oInventorAssemblyDocument, lvw文件列表)

        Me.Text = "批量打印  (共" & lvw文件列表.Items.Count & "张）"
        Me.TopMost = True
        Me.TopMost = False

    End Sub
    ''' <summary>
    ''' 载入数据函数
    ''' </summary>
    ''' <param name="oInventorAssemblyDocument">被载入的部件</param>
    ''' <param name="oListView">加载到ListView控件</param>
    ''' <remarks></remarks>
    Private Sub LoadBOM(ByVal oInventorAssemblyDocument As Inventor.AssemblyDocument, ByVal oListView As ListView)
        On Error Resume Next

        Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        OInteractionEvents.Start()
        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        ThisApplication.UserInterfaceManager.DoEvents()

        oListView.BeginUpdate()

        Dim oBOM As BOM
        oBOM = oInventorAssemblyDocument.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True

        '获取结构化的bom页面
        For Each oBOMView As BOMView In oBOM.BOMViews
            '基于bom结构化数据，可跳过参考的文件
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                LoadBOMSub(oBOMView.BOMRows, oListView)
                Exit For
            End If
        Next

        oListView.EndUpdate()

        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        OInteractionEvents.Stop()
    End Sub

    ''' <summary>
    ''' 从BOM加载文件列表
    ''' </summary>
    ''' <param name="oBOMRows">被加载的BOMs对象</param>
    ''' <param name="olistiview">加载到ListView对象</param>
    ''' <remarks></remarks>
    Private Sub LoadBOMSub(ByVal oBOMRows As BOMRowsEnumerator, ByVal olistiview As ListView)

        For Each oBOMRow As BOMRow In oBOMRows
            Dim strDocumentFullFileName As String = oBOMRow.ComponentDefinitions(1).Document.FullFileName

            '测试文件
            Debug.Print(strDocumentFullFileName)

            ' Set the message for the progress bar
            'oProgressBar.Message = oFullFileName

            Dim strInventorDrawingFullFileName As String
            strInventorDrawingFullFileName = GetChangeExtension(strDocumentFullFileName, IDW)

            If IsFileExists(strInventorDrawingFullFileName) = False Then   '跳过不存在的文件
                Continue For
            End If

            'if InStr(oFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
            '    GoTo 999
            'End if

            If IsItemInListView(olistiview, strInventorDrawingFullFileName) = False Then
                olistiview.Items.Add(strInventorDrawingFullFileName)
            End If

            '遍历下一级
            If (oBOMRow.ChildRows IsNot Nothing) Then
                Call LoadBOMSub(oBOMRow.ChildRows, olistiview)
            End If

999:
            'oProgressBar.UpdateProgress()
        Next

        'oProgressBar.Close()

    End Sub

    Private Sub Btn导入已打开文件_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn导入已打开文件.Click
        Try
            lbl建议.Visible = False

            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            btn导入已打开文件.Enabled = False
            'ThisApplication.Cursor  = Cursors.WaitCursor

            For Each oInventorDocument As Inventor.Document In ThisApplication.Documents.VisibleDocuments
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
            MessageBox.Show(ex.Message, xhtool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '移除
    Private Sub Tsmi移出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi移出.Click
        ListViewDel(lvw文件列表)
        Me.Text = "批量打印  (共" & lvw文件列表.Items.Count & "张）"
    End Sub

    '筛选移除
    Private Sub Tsmi筛选移出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi筛选移出.Click
        Me.TopMost = False
        Dim strFilter As String
        Dim frmInputBox As New FormInputBox
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
    Private Sub Tsmi筛选保留_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi筛选保留.Click
        Me.TopMost = False
        Dim strFilter As String
        Dim frmInputBox As New FormInputBox
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

    Private Sub Btn导入当前部件_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn导入当前部件.Click

        lbl建议.Visible = False

        'lvw文件列表.Items.Clear()

        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        If oInventorDocument.DocumentType <> kAssemblyDocumentObject Then
            MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim oInventorAssemblyDocument As AssemblyDocument
        oInventorAssemblyDocument = CType(oInventorDocument, AssemblyDocument)

        LoadBOM(oInventorAssemblyDocument, lvw文件列表)

        Me.Text = "批量打印  (共" & lvw文件列表.Items.Count & "张）"

    End Sub

    Private Sub Lvw文件列表_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvw文件列表.MouseDoubleClick
        ThisApplication.Documents.Open(lvw文件列表.SelectedItems(0).Text)
    End Sub

    '拖入文件夹 和 文件
    Private Sub Lvw文件列表_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvw文件列表.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then

            Dim File_lists() As String
            Dim File_Attribute As FileInfo

            Dim strDestinationFolder As String = Nothing
            'Dim oFileAttributes As FileAttributes
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

                        GetAllFile(strDestinationFolder, lvw文件列表, IDW)

                    Case Else
                        If IsItemInListView(lvw文件列表, strInventorDrawingFullFileName) = False Then
                            If GetFileExtensionLCase(strInventorDrawingFullFileName) = IDW Then
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
    Private Sub Lvw文件列表_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvw文件列表.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub Btn保存配置_Click(sender As Object, e As EventArgs) Handles btn保存配置.Click
        PrintSetting = "0" & BoolToInt(chk签字.Checked) & BoolToInt(chk刷新工程图.Checked) &
             BoolToInt(chk存为pdf.Checked) & BoolToInt(chk关闭窗口.Checked) & BoolToInt(chk打印为黑色.Checked) &
            BoolToInt(chk打印后关闭.Checked) & BoolToInt(chk保存签字.Checked) & BoolToInt(chk保存工程图.Checked) & BoolToInt(chk存为dwg.Checked)

        ini.WriteStrINI("打印", "纸张尺寸", cmb纸张尺寸.Text, IniFile)
        ini.WriteStrINI("打印", "PrintSetting", PrintSetting, IniFile)

    End Sub

    Private Sub Btn中断_Click(sender As Object, e As EventArgs) Handles btn中断.Click
        IsStopPrint = True
    End Sub

End Class