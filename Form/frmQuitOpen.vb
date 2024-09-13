Imports System.Windows.Forms

Public Class frmQuitOpen

    Private Sub lvw文件列表_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvw文件列表.MouseDoubleClick

        if (lvw文件列表.SelectedItems.Count <> 0) And (e.Button = System.Windows.Forms.MouseButtons.Left) Then
            strQuitOpenSelectFileFullName = lvw文件列表.SelectedItems(0).Text

            Me.Hide()
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'Me.Dispose()

    End Sub

    Private Sub btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub btn多选打开_Click(sender As Object, e As EventArgs) Handles btn多选打开.Click
        Me.Hide()

        For Each oSelectedItem As ListViewItem In lvw文件列表.CheckedItems

            strQuitOpenSelectFileFullName = oSelectedItem.Text
            Dim strFileExtensionName As String = Nothing
            strFileExtensionName = LCase(GetFileNameInfo(strQuitOpenSelectFileFullName).ExtensionName)

            Select Case strFileExtensionName
                Case IAM, IPT, IDW
                    str模型匹配检查标记 = 1
                    ThisApplication.Documents.Open(strQuitOpenSelectFileFullName)
                Case Else
                    Process.Start(strQuitOpenSelectFileFullName)
            End Select

        Next

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub frmQuitOpen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48
    End Sub

End Class