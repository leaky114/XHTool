Imports System.Windows.Forms

Public Class frmQuitOpen

    Private Sub lvw文件列表_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvw文件列表.MouseDoubleClick

        If (lvw文件列表.SelectedItems.Count <> 0) And (e.Button = System.Windows.Forms.MouseButtons.Left) Then
            Dim strFullFileName As String
            strFullFileName = lvw文件列表.SelectedItems(0).Text
            Me.Hide()
            Select Case LCase(GetFileNameInfo(strFullFileName).ExtensionName)
                Case IAM, IPT, IDW
                    ThisApplication.Documents.Open(strFullFileName)
                Case Else
                    Process.Start(lvw文件列表.SelectedItems(0).Text)
            End Select

        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Dispose()

    End Sub

    Private Sub btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

End Class