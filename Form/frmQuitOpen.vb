Imports System.Windows.Forms

Public Class frmQuitOpen

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click
        If lvwFileListView.SelectedItems.Count <> 0 Then
            ThisApplication.Documents.Open(lvwFileListView.SelectedItems(0).Text)
        End If
         Me.DialogResult = System.Windows.Forms.DialogResult.OK
        me.close
    End Sub
End Class
