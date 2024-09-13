Public Class frmSwitchLablesOption

    Private Sub btn关闭_Click(sender As Object, e As EventArgs) Handles btn关闭.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub frmSwitchLablesOption_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt每行数量.Text = int每行数量.ToString
        txt图框宽度.Text = int图框宽度.ToString
        txt图框高度.Text = int图框高度.ToString
        txt行间距.Text = int图框行间距.ToString
        txt列间距.Text = int图框列间距.ToString
    End Sub

    Private Sub btn确定_Click(sender As Object, e As EventArgs) Handles btn确定.Click
        int每行数量 = txt每行数量.Text
        int图框宽度 = txt图框宽度.Text
        int图框高度 = txt图框高度.Text
        int图框行间距 = txt行间距.Text
        int图框列间距 = txt列间距.Text

        ini.WriteStrINI("切换文档", "每行数量", int每行数量.ToString, Inifile)
        ini.WriteStrINI("切换文档", "图框宽度", int图框宽度.ToString, Inifile)
        ini.WriteStrINI("切换文档", "图框高度", int图框高度.ToString, Inifile)
        ini.WriteStrINI("切换文档", "图框行间距", int图框行间距.ToString, Inifile)
        ini.WriteStrINI("切换文档", "图框列间距", int图框列间距.ToString, Inifile)

        Me.Dispose()
    End Sub

    Private Sub txt每行数量_TextChanged(sender As Object, e As EventArgs) Handles txt每行数量.TextChanged
        If IsNumeric(txt每行数量.Text) = False Then
            MsgBox("非数字！", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "错误")
        End If
    End Sub

    Private Sub txt图框宽度_TextChanged(sender As Object, e As EventArgs) Handles txt图框宽度.TextChanged
        If IsNumeric(txt图框宽度.Text) = False Then
            MsgBox("非数字！", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "错误")
        End If
    End Sub

    Private Sub txt图框高度_TextChanged(sender As Object, e As EventArgs) Handles txt图框高度.TextChanged
        If IsNumeric(txt图框高度.Text) = False Then
            MsgBox("非数字！", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "错误")
        End If
    End Sub

    Private Sub txt行间距_TextChanged(sender As Object, e As EventArgs) Handles txt行间距.TextChanged
        If IsNumeric(txt行间距.Text) = False Then
            MsgBox("非数字！", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "错误")
        End If
    End Sub

    Private Sub txt列间距_TextChanged(sender As Object, e As EventArgs) Handles txt列间距.TextChanged
        If IsNumeric(txt列间距.Text) = False Then
            MsgBox("非数字！", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "错误")
        End If
    End Sub

  
End Class