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

Public Class formMovesSpecifiedFile

    Private Sub frmMovesSpecifiedFile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48

        Dim toolTip As New ToolTip()
        toolTip.AutoPopDelay = 0
        toolTip.InitialDelay = 0
        toolTip.ReshowDelay = 500

        应用ToolStripButton.Image = My.Resources.确定16.ToBitmap
        重载ToolStripButton.Image = My.Resources.部件16.ToBitmap

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

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = oInventorDocument

        Dim frmInputBox As New formInputBox

        Dim strSearch As String
        strSearch = GetPropitem(oInventorAssemblyDocument, Map_DrawingNnumber)
        strSearch = RemoveTrailingZeros(strSearch)

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
        '    MsgBox("请输入部分图号！", MsgBoxStyle.Information)
        '    SetStatusBarText("错误")
        'End If

        筛选ToolStripTextBox.Text = strSearch

        LoadReferenced(oInventorAssemblyDocument, Lvw文件列表, strSearch)

        SetWindowSizeAndCenter(Me, 0.6, 0.6)

    End Sub

    Private Sub LoadReferenced(ByVal oInventorAssemblyDocument As AssemblyDocument, ByVal oListView As ListView, ByVal strSearch As String)
        ' 获取所有引用文档
        Dim oInventorDocumentsEnumerator As Inventor.DocumentsEnumerator
        oInventorDocumentsEnumerator = oInventorAssemblyDocument.AllReferencedDocuments

        Dim strInventorAssemblyDocumentFullFileName As String
        strInventorAssemblyDocumentFullFileName = oInventorAssemblyDocument.FullDocumentName

        '组件所在文件夹
        Dim strInventorAssemblyFileFolder As String
        strInventorAssemblyFileFolder = GetFileNameInfo(strInventorAssemblyDocumentFullFileName).Folder ' 遍历这些文档


        Dim oInteraction As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        oInteraction.Start()
        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        ThisApplication.UserInterfaceManager.DoEvents()

        oListView.Items.Clear()
        oListView.BeginUpdate()

        For Each oInventorDocument As Inventor.Document In oInventorDocumentsEnumerator
            'Debug.Print(oInventorDocument.FullFileName)
            'strReferencedFullFileNames(i) = oInventorDocument.FullFileName
            'i = i + 1

            Dim strOldFullFileName As String
            strOldFullFileName = oInventorDocument.FullFileName

            If IsFileExsts(strOldFullFileName) = False Then   '跳过不存在的文件
                Continue For
            End If

            If InStr(strOldFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                Continue For
            End If


            Dim strOldFileName As String

            strOldFileName = GetFileNameWithoutExtension2(strOldFullFileName)
            If InStr(strOldFileName, strSearch) = 0 Then
                Continue For
            End If

            Dim strNewFullFileName As String
            strNewFullFileName = GetChangeDirectoryFileName(strOldFullFileName, strInventorAssemblyFileFolder)

            Dim oListViewItem As ListViewItem = Nothing

            Select Case GetFileExtensionLCase(strOldFullFileName)
                Case IAM
                    oListViewItem = oListView.Items.Add(strOldFullFileName, 0)
                Case IPT
                    oListViewItem = oListView.Items.Add(strOldFullFileName, 1)
            End Select

            oListViewItem.SubItems.Add(strNewFullFileName)


            Dim strOldDrawingFullFileName As String
            strOldDrawingFullFileName = GetChangeExtension(strOldFullFileName, IDW)


            If IsFileExsts(strOldDrawingFullFileName) = True Then

                Dim strNewDrawingFullFileName As String
                strNewDrawingFullFileName = GetChangeExtension(strNewFullFileName, IDW)

                oListViewItem = oListView.Items.Add(strOldDrawingFullFileName, 2)

                oListViewItem.SubItems.Add(strNewDrawingFullFileName)

            End If


        Next

        oListView.EndUpdate()

        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        oInteraction.Stop()

    End Sub

    Private Sub 应用ToolStripButton_Click(sender As Object, e As EventArgs) Handles 应用ToolStripButton.Click
        Dim strOldFullFileName As String
        Dim strNewFullFileName As String

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        Dim strInventorAssemblyDocumentFullFileName As String = oInventorDocument.FullFileName

        MsgBox("将关闭部件" & strInventorAssemblyDocumentFullFileName, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

        oInventorDocument.Close()

        For Each oListViewItem As ListViewItem In Lvw文件列表.Items
            strOldFullFileName = oListViewItem.Text.ToString
            strNewFullFileName = oListViewItem.SubItems(1).Text.ToString

            ReMoveFile(strOldFullFileName, strNewFullFileName)

        Next

        If MsgBox("移动指定文件完成，是否重新打开 " & strInventorAssemblyDocumentFullFileName, MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            ThisApplication.Documents.Open(strInventorAssemblyDocumentFullFileName)
        End If

    End Sub

    Private Sub 重载ToolStripButton_Click(sender As Object, e As EventArgs) Handles 重载ToolStripButton.Click
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        If oInventorDocument.DocumentType <> kAssemblyDocumentObject Then
            MsgBox("该功能仅适用于部件", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = oInventorDocument

        Dim strSearch As String = 筛选ToolStripTextBox.Text.ToString

        LoadReferenced(oInventorAssemblyDocument, Lvw文件列表, strSearch)

    End Sub

End Class