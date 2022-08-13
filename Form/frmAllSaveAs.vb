Imports System.Windows.Forms
Imports Inventor
Imports System
Imports System.IO
Imports Microsoft
Imports Microsoft.VisualBasic
Imports System.Collections.ObjectModel

Public Class frmAllSaveAs

    '量产开始
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click

        Dim oInventorDocument As Inventor.Document

        Dim strPdfFullFileName As String = ""      'dwg 文件全文件名
        Dim strDwgFullFileName As String = ""      'pdf 文件全文件名

        For Each oInventorDocument In ThisApplication.Documents
            If oInventorDocument.DocumentType = DocumentTypeEnum.kDrawingDocumentObject Then
                lstFileList.Items.Add(oInventorDocument.FullFileName)
            End If
        Next

        btnStart.Enabled = False
        btnClose.Enabled = False

        For i = 0 To lstFileList.Items.Count - 1
            oInventorDocument = ThisApplication.Documents.ItemByName(lstFileList.Items(i))

            Dim strInventorDrawingFullFileName As String '工程图全文件名
            strInventorDrawingFullFileName = oInventorDocument.FullDocumentName

            ThisApplication.Documents.ItemByName(strInventorDrawingFullFileName).Activate()

            'If IsFileExsts(IdwFullFileName) = False Then   '跳过不存在的文件
            '    GoTo 999
            'End If

            'If InStr(IdwFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
            '    GoTo 999
            'End If

            If rdoLocal.Checked = True Then
                strPdfFullFileName = Strings.Replace(strInventorDrawingFullFileName, LCaseGetFileExtension(strInventorDrawingFullFileName), ".dwg")
                strDwgFullFileName = Strings.Replace(strInventorDrawingFullFileName, LCaseGetFileExtension(strInventorDrawingFullFileName), ".pdf")
            End If

            If rdoSameFolder.Checked = True Then

                Dim strPresent_Folder As String       '指定文件夹
                strPresent_Folder = txtString.Text

                If IsDirectoryExists(strPresent_Folder) = True Then

                    strPdfFullFileName = Strings.Replace(strInventorDrawingFullFileName, GetFileNameInfo(strInventorDrawingFullFileName).Folder, strPresent_Folder)
                    strDwgFullFileName = Strings.Replace(strInventorDrawingFullFileName, GetFileNameInfo(strInventorDrawingFullFileName).Folder, strPresent_Folder)

                    strPdfFullFileName = Strings.Replace(strPdfFullFileName, LCaseGetFileExtension(strInventorDrawingFullFileName), ".dwg")
                    strDwgFullFileName = Strings.Replace(strDwgFullFileName, LCaseGetFileExtension(strInventorDrawingFullFileName), ".pdf")
                Else
                    MsgBox("指定文件夹不存在。", MsgBoxStyle.Critical, "全部另存为")
                    Exit Sub
                End If

            End If

            Dim intSaveModel As Integer

            intSaveModel = chkfwg.CheckState + chkpdf.CheckState * 2

            If intSaveModel = 0 Then
                MsgBox("未选择另存为的文件类型！", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "批量另存为")
                Exit Sub
            End If

            Select Case intSaveModel
                Case 1
                    oInventorDocument.SaveAs(strPdfFullFileName, True)
                Case 2
                    oInventorDocument.SaveAs(strDwgFullFileName, True)
                Case 3
                    oInventorDocument.SaveAs(strPdfFullFileName, True)
                    oInventorDocument.SaveAs(strDwgFullFileName, True)
            End Select

            If chkCloseFile.Checked = True Then
                If chkSaveFile.Checked = True Then
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
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    '当前文件夹
    Private Sub rdoLocal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoLocal.CheckedChanged

        If rdoLocal.Checked = True Then
            rdoSameFolder.Checked = False
            btnAddFolder.Enabled = False
            txtString.Enabled = False
          
        End If

    End Sub

    '指定文件夹
    Private Sub rdoSameFolder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoSameFolder.CheckedChanged
        Dim oNeFolderBrowserDialog As New FolderBrowserDialog

        If rdoSameFolder.Checked = True Then
            rdoLocal.Checked = False
            btnAddFolder.Enabled = True

            Dim strDestinationFolder As String = Nothing
            Dim oFileAttributes As FileAttributes

            strDestinationFolder = txtString.Text

            If IsDirectoryExists(strDestinationFolder) = False Then
                strDestinationFolder = System.Environment.SpecialFolder.MyComputer
            End If

            With oNeFolderBrowserDialog
                .Description = "选择文件夹"
                .ShowNewFolderButton = True
                .SelectedPath = strDestinationFolder
                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    strDestinationFolder = .SelectedPath
                Else
                    Exit Sub
                End If
            End With

            '是否为文件夹，在其后添加 \
            oFileAttributes = FileSystem.GetAttr(strDestinationFolder)

            If oFileAttributes = FileAttributes.Directory Then
                strDestinationFolder = strDestinationFolder + "\"
            End If

            txtString.Text = strDestinationFolder

            'Else
            '    RadioButton2.Checked = True
        End If

    End Sub

    Private Sub btnAddFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFolder.Click
        Dim strDestinationFolder As String = Nothing
        Dim oFileAttributes As FileAttributes
        Dim oNewFolderBrowserDialog As New FolderBrowserDialog

        With oNewFolderBrowserDialog
            .ShowNewFolderButton = False
            .Description = "添加文件夹"
            .RootFolder = System.Environment.SpecialFolder.Desktop
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                strDestinationFolder = .SelectedPath.ToString
            Else
                Exit Sub
            End If
        End With

        '是否为文件夹，在其后添加 \
        oFileAttributes = FileSystem.GetAttr(strDestinationFolder)

        If oFileAttributes = FileAttributes.Directory Then
            strDestinationFolder = strDestinationFolder + "\"
        End If

        txtString.Text = strDestinationFolder

    End Sub

End Class