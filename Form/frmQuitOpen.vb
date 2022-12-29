Imports System.Windows.Forms

Public Class frmQuitOpen

    Private Sub lvwFileListView_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvwFileListView.MouseDoubleClick

        If (lvwFileListView.SelectedItems.Count <> 0) And (e.Button = System.Windows.Forms.MouseButtons.Left) Then
            Dim strFullFileName As String
            strFullFileName = lvwFileListView.SelectedItems(0).Text
            Me.Hide()
            Select Case LCase(GetFileNameInfo(strFullFileName).ExtensionName)
                Case ".iam", ".ipt", ".idw"
                    ThisApplication.Documents.Open(strFullFileName)
                Case Else
                    Process.Start(lvwFileListView.SelectedItems(0).Text)
            End Select

        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Dispose()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

End Class