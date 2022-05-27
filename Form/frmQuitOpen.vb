Imports System.Windows.Forms

Public Class frmQuitOpen

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click
        If lvwFileListView.SelectedItems.Count <> 0 Then
            'ThisApplication.Documents.Open(lvwFileListView.SelectedItems(0).Text)
            Process.Start(lvwFileListView.SelectedItems(0).Text)
        End If
         Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub lvwFileListView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwFileListView.SelectedIndexChanged
        If lvwFileListView.SelectedItems.Count <> 0 Then
            'ThisApplication.Documents.Open(lvwFileListView.SelectedItems(0).Text)
            Process.Start(lvwFileListView.SelectedItems(0).Text)
        End If
        Me.Close()
    End Sub
End Class
