Imports System.Windows.Forms

Public Class formQuitOpen

    Private Sub lvw文件列表_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvw文件列表.MouseDoubleClick

        If (lvw文件列表.SelectedItems.Count <> 0) And (e.Button = System.Windows.Forms.MouseButtons.Left) Then
            strQuitOpenSelectFileFullName = lvw文件列表.SelectedItems(0).Text

            Me.Hide()
        End If

        FormManager.CloseAndDisposeForm(Of formQuitOpen)()

    End Sub

    Private Sub btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click, Me.Closing
        FormManager.CloseAndDisposeForm(Of formQuitOpen)()
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

        FormManager.CloseAndDisposeForm(Of formQuitOpen)()
    End Sub

    Private Sub frmQuitOpen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48
        SetWindowSizeAndCenter(Me, 0.5, 0.32)
    End Sub


End Class