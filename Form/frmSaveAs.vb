Imports System.Windows.Forms
Imports Inventor
Imports System
Imports System.IO
Imports Microsoft
Imports Microsoft.VisualBasic
Imports System.Collections.ObjectModel
'Imports Microsoft.VisualBasic.Compatibility
Imports stdole

Public Class frmSaveAs

    '量产开始
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        If lstFileList.Items.Count = 0 Then
            MsgBox("未添加工程图文件。", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "批量另存为")
            Exit Sub
        End If

        For i = 0 To lstFileList.Items.Count - 1
            lstFileList.SelectedIndex = i
            '打开文件
            Dim InvDocFullFileName As String  '工程图全文件名

            InvDocFullFileName = lstFileList.Items(i)

            If IsFileExsts(InvDocFullFileName) = False Then   '跳过不存在的文件
                GoTo 999
            End If

            If InStr(InvDocFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                GoTo 999
            End If

            Dim DwgFullFileName As String        'dwg 文件全文件名
            Dim PdfFullFileName As String        'pdf 文件全文件名
            Dim JpgFullFileName As String      'jpg文件全文件名

            DwgFullFileName = Strings.Replace(InvDocFullFileName, LCaseGetFileExtension(InvDocFullFileName), ".dwg")
            PdfFullFileName = Strings.Replace(InvDocFullFileName, LCaseGetFileExtension(InvDocFullFileName), ".pdf")
            JpgFullFileName = Strings.Replace(InvDocFullFileName, LCaseGetFileExtension(InvDocFullFileName), ".bmp")

            Dim SaveModel As Integer

            SaveModel = chkDwg.CheckState + chkPdf.CheckState * 2 + chkPic.CheckState * 4

            If SaveModel = 0 Then
                MsgBox("未选择另存为的文件类型！", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "批量另存为")
                Exit Sub
            End If

            Dim oInventorDocument As Inventor.Document
            oInventorDocument = ThisApplication.Documents.Open(InvDocFullFileName, True)

            Select Case SaveModel
                Case 1
                    oInventorDocument.SaveAs(DwgFullFileName, True)
                Case 2
                    oInventorDocument.SaveAs(PdfFullFileName, True)
                Case 3
                    oInventorDocument.SaveAs(DwgFullFileName, True)
                    oInventorDocument.SaveAs(PdfFullFileName, True)
                Case 4
                Case 5
                Case 6
                Case 7
            End Select

            oInventorDocument.Close(True)

999:
        Next
        MsgBox("批量另存文件完成", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "批量另存为")
        lstFileList.Items.Clear()

    End Sub

    '关闭
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        lstFileList.Items.Clear()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    '添加文件
    Private Sub btnAddFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFile.Click
        '打开文件
        Dim oOpenFileDialog As New OpenFileDialog '声名新open 窗口

        With oOpenFileDialog
            .Title = "打开"
            .Filter = "AutoDesk Inventor 工程图文件(*.idw)|*.idw" '添加过滤文件
            .Multiselect = True '多开文件打开
            If .ShowDialog = Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                If .FileName <> "" Then '如果有选中文件
                    For Each FullFileName As String In .FileNames
                        lstFileList.Items.Add(FullFileName)
                    Next
                End If
            Else
                Exit Sub
            End If
        End With
    End Sub

    '清空文件列表
    Private Sub btnClearList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearList.Click
        lstFileList.Items.Clear()
    End Sub

    '添加文件夹
    Private Sub btnAddFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFolder.Click
        Dim destinationFolder As String = Nothing
        Dim inf As FileAttributes
        Dim Present_Folder As String = Nothing
        Dim oFolderBrowserDialog As New FolderBrowserDialog

        With oFolderBrowserDialog
            .ShowNewFolderButton = False
            .Description = "添加文件夹"
            .RootFolder = System.Environment.SpecialFolder.Desktop
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
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

        GetAllFile(Present_Folder, destinationFolder, lstFileList)

    End Sub

End Class