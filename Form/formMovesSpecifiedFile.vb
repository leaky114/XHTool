Imports Inventor
Imports Microsoft
Imports Microsoft.VisualBasic
'Imports Microsoft.VisualBasic.Compatibility
Imports stdole
Imports System
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Windows.Forms
Imports Inventor.DocumentTypeEnum
Imports System.Collections.Generic
Imports System.ComponentModel

Public Class FormMovesSpecifiedFile
    Private Sub FormMovesSpecifiedFile_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        FormManager.CloseAndDisposeForm(Of formMovesSpecifiedFile)()
    End Sub

    Private Sub FrmMovesSpecifiedFile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48

        'Dim toolTip As New ToolTip()
        'toolTip.AutoPopDelay = 0
        'toolTip.InitialDelay = 0
        'toolTip.ReshowDelay = 500

        应用ToolStripButton.Image = My.Resources.确定16.ToBitmap
        筛选ToolStripButton.Image = My.Resources.部件16.ToBitmap
        全部选择ToolStripButton.Image = My.Resources.全部选择16.ToBitmap
        全部取消ToolStripButton.Image = My.Resources.全部取消16.ToBitmap
        反向选择ToolStripButton.Image = My.Resources.反向选择16.ToBitmap

        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        If oInventorDocument.DocumentType <> kAssemblyDocumentObject Then
            MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = oInventorDocument

        Dim frmInputBox As New formInputBox

        Dim strSearch As String
        strSearch = GetPropitem(oInventorAssemblyDocument, Map_DrawingNnumber)
        strSearch = RemoveTrailingZeros(strSearch)    '去除末尾的0
        strSearch = Strings.LCase(strSearch)          '转换为小写

        'With frmInputBox
        '    .txt输入.Text = strSearchNnumber
        '    .Text = "移动文件"
        '    .lbl描述.Text = "将保存并关闭当前文档，移动包含指定的字符文件名的文件到当前部件文件夹。"
        '    .StartPosition = FormStartPosition.CenterScreen
        '    .ShowDialog()
        'End With

        'If frmInputBox.DialogResult = System.Windows.Forms.DialogResult.OK And frmInputBox.txt输入.Text <> "" Then
        '    strSearchNnumber = frmInputBox.txt输入.Text
        'ElseIf frmInputBox.DialogResult = System.Windows.Forms.DialogResult.Cancel Then
        '    Exit Sub
        'Else
        '     MessageBox.Show("请输入部分图号！", MsgBoxStyle.Information)
        '    SetStatusBarText(XHTool)
        'End If

        筛选ToolStripTextBox.Text = strSearch

        LoadReferenced(oInventorAssemblyDocument, Lvw文件列表, strSearch)

        SetWindowSizeAndCenter(Me)

    End Sub


    ''' <summary>
    ''' 加载文件
    ''' </summary>
    ''' <param name="oInventorAssemblyDocument">部件文件对象</param>
    ''' <param name="oListView">listview 对象</param>
    ''' <param name="strSearch">筛选器字符</param>
    Private Sub LoadReferenced(ByVal oInventorAssemblyDocument As AssemblyDocument, ByVal oListView As ListView, ByVal strSearch As String)
        ' 获取所有引用文档
        Dim oInventorDocumentsEnumerator As Inventor.DocumentsEnumerator
        oInventorDocumentsEnumerator = oInventorAssemblyDocument.AllReferencedDocuments

        Dim strInventorAssemblyDocumentFullFileName As String
        strInventorAssemblyDocumentFullFileName = oInventorAssemblyDocument.FullDocumentName

        '组件所在文件夹
        Dim strInventorAssemblyFileFolder As String
        strInventorAssemblyFileFolder = GetFileNameInfo(strInventorAssemblyDocumentFullFileName).Folder ' 遍历这些文档


        Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        OInteractionEvents.Start()
        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        ThisApplication.UserInterfaceManager.DoEvents()

        oListView.Items.Clear()
        oListView.BeginUpdate()

        For Each oInventorDocument As Inventor.Document In oInventorDocumentsEnumerator
            'Debug.Print(oInventorDocument.FullFileName)
            'strReferencedFullFileNames(i) = oInventorDocument.FullFileName
            'i = i + 1

            Dim strOldFullFileName As String
            strOldFullFileName = oInventorDocument.FullFileName

            If IsFileExists(strOldFullFileName) = False Then   '跳过不存在的文件
                Continue For
            End If

            If InStr(strOldFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                Continue For
            End If


            Dim strOldFileName As String

            strOldFileName = GetFileNameWithoutExtension2(strOldFullFileName)
            strOldFileName = Strings.LCase(strOldFileName)

            If InStr(strOldFileName, strSearch) = 0 Then
                Continue For
            End If

            Dim strNewFullFileName As String
            strNewFullFileName = GetChangeDirectoryFileName(strOldFullFileName, strInventorAssemblyFileFolder)

            If strNewFullFileName = strOldFullFileName Then    '新旧文件一样跳过
                Continue For
            End If

            Dim oListViewItem As ListViewItem = Nothing

            Select Case GetFileExtensionLCase(strOldFullFileName)
                Case IAM
                    oListViewItem = oListView.Items.Add(strOldFullFileName, 0)
                Case IPT
                    oListViewItem = oListView.Items.Add(strOldFullFileName, 1)
            End Select


            oListViewItem.SubItems.Add(strNewFullFileName)

            If IsFileExists(strNewFullFileName) = True Then
                oListViewItem.UseItemStyleForSubItems = False
                oListViewItem.SubItems(1).ForeColor = Drawing.Color.Red
                oListViewItem.SubItems.Add(“跳过”)
            End If


            Dim strOldDrawingFullFileName As String
            strOldDrawingFullFileName = GetChangeExtension(strOldFullFileName, IDW)

            If IsFileExists(strOldDrawingFullFileName) = True Then
                Dim strNewDrawingFullFileName As String
                strNewDrawingFullFileName = GetChangeExtension(strNewFullFileName, IDW)
                oListViewItem = oListView.Items.Add(strOldDrawingFullFileName, 2)
                oListViewItem.SubItems.Add(strNewDrawingFullFileName)

            End If
        Next

        oListView.EndUpdate()

        'OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        OInteractionEvents.Stop()

    End Sub

    Private Sub 应用ToolStripButton_Click(sender As Object, e As EventArgs) Handles 应用ToolStripButton.Click
        If MessageBox.Show("确定移动文件？", XHTool, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Exit Sub
        End If


        Dim strOldFullFileName As String
        Dim strNewFullFileName As String

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        Dim strInventorAssemblyDocumentFullFileName As String = oInventorDocument.FullFileName

        MessageBox.Show("将关闭部件：" & strInventorAssemblyDocumentFullFileName, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Information)

        oInventorDocument.Close()

        For Each oListViewItem As ListViewItem In Lvw文件列表.Items
            If oListViewItem.Checked = True Then
                strOldFullFileName = oListViewItem.Text.ToString
                strNewFullFileName = oListViewItem.SubItems(1).Text.ToString

                If IsFileExists(strNewFullFileName) = False Then   '目标文件不存在，直接移动
                    ReMoveFile(strOldFullFileName, strNewFullFileName)
                Else   '目标文件存在，判读方法
                    If oListViewItem.SubItems(2).Text.ToString = "覆盖" Then
                        BasicFileSystem.DeleteFile2(strNewFullFileName, FileIO.RecycleOption.SendToRecycleBin)
                        ReMoveFile(strOldFullFileName, strNewFullFileName）
                    Else

                    End If
                End If

            End If
        Next

        If MessageBox.Show("移动文件完成，是否重新打开？" & strInventorAssemblyDocumentFullFileName, XHTool, MessageBoxButtons.YesNo，
                           MessageBoxIcon.Question） = DialogResult.Yes Then
            ThisApplication.Documents.Open(strInventorAssemblyDocumentFullFileName)
        End If

        FormManager.CloseAndDisposeForm(Of FormMovesSpecifiedFile)()

    End Sub

    Private Sub 筛选ToolStripButton_Click(sender As Object, e As EventArgs) Handles 筛选ToolStripButton.Click
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        If oInventorDocument.DocumentType <> kAssemblyDocumentObject Then
            MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = oInventorDocument

        Dim strSearch As String = 筛选ToolStripTextBox.Text.ToString

        LoadReferenced(oInventorAssemblyDocument, Lvw文件列表, strSearch)

        Me.TopMost = True
        Me.TopMost = False

    End Sub

    Private Sub 全部选择ToolStripButton_Click(sender As Object, e As EventArgs) Handles 全部选择ToolStripButton.Click
        For Each oListViewItem As ListViewItem In Lvw文件列表.Items
            oListViewItem.Checked = True
        Next
    End Sub

    Private Sub 全部取消ToolStripButton_Click(sender As Object, e As EventArgs) Handles 全部取消ToolStripButton.Click
        For Each oListViewItem As ListViewItem In Lvw文件列表.Items
            oListViewItem.Checked = False
        Next
    End Sub

    Private Sub 反向选择ToolStripButton_Click(sender As Object, e As EventArgs) Handles 反向选择ToolStripButton.Click
        For Each oListViewItem As ListViewItem In Lvw文件列表.Items
            oListViewItem.Checked = True Xor oListViewItem.Checked
        Next
    End Sub

    Private Sub Lvw文件列表_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Lvw文件列表.MouseDoubleClick
        If Lvw文件列表.SelectedItems.Count = 0 Then
            Exit Sub
        End If


        Dim oListViewItem As ListViewItem = Lvw文件列表.SelectedItems(0)


        If e.Button = Windows.Forms.MouseButtons.Left Then
            Try
                Dim strMethod As String = oListViewItem.SubItems(2).Text

                Select Case strMethod
                    Case ”跳过“
                        strMethod = "覆盖"
                    Case "覆盖"
                        strMethod = "跳过"
                End Select

                oListViewItem.SubItems(2).Text = strMethod


            Catch ex As Exception

            End Try
            oListViewItem.Checked = oListViewItem.Checked Xor True

        End If
    End Sub


End Class