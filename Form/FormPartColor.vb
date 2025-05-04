Imports System.Linq

Public Class FormPartColor
    Public ColorType As String

    Private Sub Frm_Color_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Icon = My.Resources.XHTool24

        '设置按钮图标
        Btn_Part.Image = My.Resources.零件32.ToBitmap
        Btn_Body.Image = My.Resources.实体32.ToBitmap
        Btn_Face.Image = My.Resources.面32.ToBitmap
        Btn_Select.Image = My.Resources.选择面和边32.ToBitmap

    End Sub

    Private Sub Btn_Part_Click(sender As Object, E As EventArgs) Handles Btn_Select.Click, Btn_Part.Click, Btn_Face.Click, Btn_Body.Click
        ColorType = sender.tag
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class