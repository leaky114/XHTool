Imports System.Windows.Forms
Imports Inventor
Imports System
Imports System.IO
Imports Microsoft
Imports Microsoft.VisualBasic
Imports System.Collections.ObjectModel
'Imports Microsoft.VisualBasic.Compatibility
Imports stdole

Public Class SaveAsDialog

    '量产开始
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If ListBox1.Items.Count = 0 Then
            MsgBox("未添加工程图文件。", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "批量另存为")
            Exit Sub
        End If

        For i = 0 To ListBox1.Items.Count - 1
            ListBox1.SelectedIndex = i
            '打开文件
            Dim InvDocFullFileName As String  '工程图全文件名

            InvDocFullFileName = ListBox1.Items(i)

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

            SaveModel = CheckBox1.CheckState + CheckBox2.CheckState * 2 + CheckBox3.CheckState * 4

            If SaveModel = 0 Then
                MsgBox("未选择另存为的文件类型！", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "批量另存为")
                Exit Sub
            End If

            Dim InvDoc As Inventor.Document
            InvDoc = ThisApplication.Documents.Open(InvDocFullFileName, True)

            Select Case SaveModel
                Case 1
                    InvDoc.SaveAs(DwgFullFileName, True)
                Case 2
                    InvDoc.SaveAs(PdfFullFileName, True)
                Case 3
                    InvDoc.SaveAs(DwgFullFileName, True)
                    InvDoc.SaveAs(PdfFullFileName, True)
                Case 4
                Case 5
                Case 6
                Case 7
            End Select

            InvDoc.Close(True)

999:
        Next
        MsgBox("批量另存文件完成", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "批量另存为")
        ListBox1.Items.Clear()

    End Sub

    '关闭
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        ListBox1.Items.Clear()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    '添加文件
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '打开文件
        Dim NewOpenFileDialog As New OpenFileDialog '声名新open 窗口

        With NewOpenFileDialog
            .Title = "打开"
            .Filter = "AutoDesk Inventor 工程图文件(*.idw)|*.idw" '添加过滤文件
            .Multiselect = True '多开文件打开
            If .ShowDialog = Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                If .FileName <> "" Then '如果有选中文件
                    For Each FullFileName As String In .FileNames
                        ListBox1.Items.Add(FullFileName)
                    Next
                End If
            Else
                Exit Sub
            End If
        End With
    End Sub

    '清空文件列表
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ListBox1.Items.Clear()
    End Sub

    '添加文件夹
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim destinationFolder As String = Nothing
        Dim inf As FileAttributes
        Dim Present_Folder As String = Nothing
        Dim NewFolderBrowserDialog As New FolderBrowserDialog

        With NewFolderBrowserDialog
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

        GetAllFile(Present_Folder, destinationFolder, ListBox1)

    End Sub

End Class