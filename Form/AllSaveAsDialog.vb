Imports System.Windows.Forms
Imports Inventor
Imports System
Imports System.IO
Imports Microsoft
Imports Microsoft.VisualBasic
Imports System.Collections.ObjectModel

Public Class AllSaveAsDialog

    '量产开始
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Dim oInventorDocument As Inventor.Document

        Dim DwgFullFileName As String = ""      'dwg 文件全文件名
        Dim PdfFullFileName As String = ""      'pdf 文件全文件名

        For Each oInventorDocument In ThisApplication.Documents
            If oInventorDocument.DocumentType = DocumentTypeEnum.kDrawingDocumentObject Then
                ListBox1.Items.Add(oInventorDocument.FullFileName)
            End If
        Next

        OK_Button.Enabled = False
        Cancel_Button.Enabled = False

        For i = 0 To ListBox1.Items.Count - 1
            oInventorDocument = ThisApplication.Documents.ItemByName(ListBox1.Items(i))

            Dim IdwFullFileName As String  '工程图全文件名
            IdwFullFileName = oInventorDocument.FullDocumentName

            ThisApplication.Documents.ItemByName(IdwFullFileName).Activate()

            'If IsFileExsts(IdwFullFileName) = False Then   '跳过不存在的文件
            '    GoTo 999
            'End If

            'If InStr(IdwFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
            '    GoTo 999
            'End If

            If RadioButton1.Checked = True Then
                DwgFullFileName = Strings.Replace(IdwFullFileName, LCaseGetFileExtension(IdwFullFileName), ".dwg")
                PdfFullFileName = Strings.Replace(IdwFullFileName, LCaseGetFileExtension(IdwFullFileName), ".pdf")
            End If

            If RadioButton2.Checked = True Then

                Dim Present_Folder As String       '指定文件夹
                Present_Folder = TextBox1.Text

                If IsDirectoryExists(Present_Folder) = True Then

                    DwgFullFileName = Strings.Replace(IdwFullFileName, GetFileNameInfo(IdwFullFileName).Folder, Present_Folder)
                    PdfFullFileName = Strings.Replace(IdwFullFileName, GetFileNameInfo(IdwFullFileName).Folder, Present_Folder)

                    DwgFullFileName = Strings.Replace(DwgFullFileName, LCaseGetFileExtension(IdwFullFileName), ".dwg")
                    PdfFullFileName = Strings.Replace(PdfFullFileName, LCaseGetFileExtension(IdwFullFileName), ".pdf")
                Else
                    MsgBox("指定文件夹不存在。", MsgBoxStyle.Critical, "全部另存为")
                    Exit Sub
                End If

            End If

            Dim SaveModel As Integer

            SaveModel = CheckBox1.CheckState + CheckBox2.CheckState * 2

            If SaveModel = 0 Then
                MsgBox("未选择另存为的文件类型！", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "批量另存为")
                Exit Sub
            End If

            Select Case SaveModel
                Case 1
                    oInventorDocument.SaveAs(DwgFullFileName, True)
                Case 2
                    oInventorDocument.SaveAs(PdfFullFileName, True)
                Case 3
                    oInventorDocument.SaveAs(DwgFullFileName, True)
                    oInventorDocument.SaveAs(PdfFullFileName, True)
            End Select

            If CheckBox3.Checked = True Then
                If CheckBox4.Checked = True Then
                    '保存文件
                    oInventorDocument.Save2(True)
                End If
                '关闭，不保存文件
                oInventorDocument.Close(True)
            End If
999:

        Next

        Me.Dispose()
    End Sub

    '关闭
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    '当前文件夹
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged

        If RadioButton1.Checked = True Then
            RadioButton2.Checked = False
            AddFolder.Enabled = False
            'Else
            '    RadioButton2.Checked = True
        End If

    End Sub

    '指定文件夹
    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Dim NeFolderBrowserDialog As New FolderBrowserDialog

        If RadioButton2.Checked = True Then
            RadioButton1.Checked = False
            AddFolder.Enabled = True

            Dim destinationFolder As String = Nothing
            Dim inf As FileAttributes
            Dim Present_Folder As String = Nothing

            destinationFolder = TextBox1.Text

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

            TextBox1.Text = destinationFolder

            'Else
            '    RadioButton2.Checked = True
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddFolder.Click
        Dim destinationFolder As String = Nothing
        Dim inf As FileAttributes
        Dim NewFolderBrowserDialog As New FolderBrowserDialog

        With NewFolderBrowserDialog
            .ShowNewFolderButton = False
            .Description = "添加文件夹"
            .RootFolder = System.Environment.SpecialFolder.Desktop
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                destinationFolder = .SelectedPath.ToString
            Else
                Exit Sub
            End If
        End With

        '是否为文件夹，在其后添加 \
        inf = FileSystem.GetAttr(destinationFolder)

        If inf = FileAttributes.Directory Then
            destinationFolder = destinationFolder + "\"
        End If

        TextBox1.Text = destinationFolder

    End Sub

End Class