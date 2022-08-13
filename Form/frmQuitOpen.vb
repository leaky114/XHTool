Imports System.Windows.Forms

Public Class frmQuitOpen

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click
        If lvwFileListView.SelectedItems.Count <> 0 Then
            Dim strFullFileName As String
            strFullFileName = lvwFileListView.SelectedItems(0).Text
            Select Case GetFileNameInfo(strFullFileName).ExtensionName
                Case ".iam", ".ipt", ".idw"
                    ThisApplication.Documents.Open(strFullFileName)
                Case Else
                    Process.Start(lvwFileListView.SelectedItems(0).Text)
            End Select
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub lvwFileListView_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvwFileListView.MouseDoubleClick
        If lvwFileListView.SelectedItems.Count <> 0 Then
            Dim strFullFileName As String
            strFullFileName = lvwFileListView.SelectedItems(0).Text
            Select Case LCase(GetFileNameInfo(strFullFileName).ExtensionName)
                Case ".iam", ".ipt", ".idw"
                    ThisApplication.Documents.Open(strFullFileName)
                Case Else
                    Process.Start(lvwFileListView.SelectedItems(0).Text)
            End Select
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


End Class
