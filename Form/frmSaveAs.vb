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
        Dim DwgFullFileName As String = Nothing         'dwg 文件全文件名
        Dim PdfFullFileName As String = Nothing         'pdf 文件全文件名
        Dim JpgFullFileName As String = Nothing      'jpg文件全文件名
        Dim IdwFullFileName As String = Nothing   '工程图全文件名

        If lvwFileListView.Items.Count = 0 Then
            MsgBox("未添加工程图文件。", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "批量另存为")
            Exit Sub
        End If

        For i = 0 To lvwFileListView.Items.Count - 1

            'lvwFileListView.SelectedIndices.Item = i
            '打开文件


            IdwFullFileName = lvwFileListView.Items(i).Text

            If IsFileExsts(IdwFullFileName) = False Then   '跳过不存在的文件
                GoTo 999
            End If

            'If InStr(InvDocFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
            '    GoTo 999
            'End If


            Dim SaveModel As Integer

            SaveModel = chkDwg.CheckState + chkPdf.CheckState * 2 + chkPic.CheckState * 4

            If SaveModel = 0 Then
                MsgBox("未选择另存为的文件类型！", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "批量另存为")
                Exit Sub
            End If

            '当前文件夹
            If rdoLocal.Checked = True Then
                DwgFullFileName = Strings.Replace(IdwFullFileName, LCaseGetFileExtension(IdwFullFileName), ".dwg")
                PdfFullFileName = Strings.Replace(IdwFullFileName, LCaseGetFileExtension(IdwFullFileName), ".pdf")
                JpgFullFileName = Strings.Replace(IdwFullFileName, LCaseGetFileExtension(IdwFullFileName), ".bmp")
            End If


            '同一文件夹
            If rdoSameFolder.Checked = True Then

                Dim Present_Folder As String       '指定文件夹
                Present_Folder = txtString.Text

                If IsDirectoryExists(Present_Folder) = True Then

                    DwgFullFileName = Strings.Replace(IdwFullFileName, GetFileNameInfo(IdwFullFileName).Folder, Present_Folder)
                    PdfFullFileName = Strings.Replace(IdwFullFileName, GetFileNameInfo(IdwFullFileName).Folder, Present_Folder)
                    'JpgFullFileName = Strings.Replace(IdwFullFileName, GetFileNameInfo(IdwFullFileName).Folder, Present_Folder)

                    DwgFullFileName = Strings.Replace(DwgFullFileName, LCaseGetFileExtension(IdwFullFileName), ".dwg")
                    PdfFullFileName = Strings.Replace(PdfFullFileName, LCaseGetFileExtension(IdwFullFileName), ".pdf")
                    'JpgFullFileName = Strings.Replace(DwgFullFileName, LCaseGetFileExtension(IdwFullFileName), ".bmp")

                Else
                    MsgBox("指定文件夹不存在。", MsgBoxStyle.Critical, "全部另存为")
                    Exit Sub
                End If

            End If

            Dim oInventorDocument As Inventor.Document
            oInventorDocument = ThisApplication.Documents.Open(IdwFullFileName)

            Select Case SaveModel
                Case 1
                    oInventorDocument.SaveAs(DwgFullFileName, True)
                Case 2
                    oInventorDocument.SaveAs(PdfFullFileName, True)
                Case 3
                    oInventorDocument.SaveAs(DwgFullFileName, True)
                    oInventorDocument.SaveAs(PdfFullFileName, True)
            End Select


            '关闭，不保存文件
            oInventorDocument.Close(True)

999:

        Next

        Me.Dispose()
    End Sub

    '关闭
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        lvwFileListView.Items.Clear()
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
                        lvwFileListView.Items.Add(FullFileName)
                    Next
                End If
            Else
                Exit Sub
            End If
        End With
    End Sub

    '清空文件列表
    Private Sub btnClearList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearList.Click
        lvwFileListView.Items.Clear()
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

        GetAllFile(Present_Folder, destinationFolder, lvwFileListView)

    End Sub

    '当前文件夹
    Private Sub rdoLocal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoLocal.CheckedChanged

        If rdoLocal.Checked = True Then
            rdoSameFolder.Checked = False
            txtString.Enabled = False
            btnOpenFolder.Enabled = False
        End If

    End Sub

    '指定文件夹
    Private Sub rdoSameFolder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoSameFolder.CheckedChanged


        If rdoSameFolder.Checked = True Then
            rdoLocal.Checked = False
            txtString.Enabled = True
            btnOpenFolder.Enabled = True
            'Else
            '    RadioButton2.Checked = True
        End If

    End Sub

    '移除选择列
    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        ListViewDel(lvwFileListView)
    End Sub

    '选择文件夹
    Private Sub btnOpenFolder_Click(sender As System.Object, e As System.EventArgs) Handles btnOpenFolder.Click
        Dim destinationFolder As String = Nothing
        Dim inf As FileAttributes
        Dim Present_Folder As String = Nothing

        Dim NeFolderBrowserDialog As New FolderBrowserDialog

        destinationFolder = txtString.Text

        If IsDirectoryExists(destinationFolder) = False Then
            destinationFolder = System.Environment.SpecialFolder.MyComputer
        End If

        With NeFolderBrowserDialog
            .Description = "选择文件夹"
            .ShowNewFolderButton = True
            .SelectedPath = destinationFolder
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                destinationFolder = .SelectedPath
            Else
                Exit Sub
            End If
        End With

        '是否为文件夹，在其后添加 \
        inf = FileSystem.GetAttr(destinationFolder)

        If inf = FileAttributes.Directory Then
            destinationFolder = destinationFolder + "\"
        End If

        txtString.Text = destinationFolder
    End Sub
End Class