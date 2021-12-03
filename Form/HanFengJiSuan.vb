Imports System.Windows.Forms

Public Class HanFengJiSuan

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim 焊缝数 As Integer = Val(TextBox1.Text)
        Dim 焊缝长 As Integer = Val(TextBox2.Text)
        Dim 间距 As Integer = Val(TextBox3.Text)
        Dim 总长 As Integer = Val(TextBox4.Text)

        For Each c As Control In Me.Controls
            If TypeOf (c) Is RadioButton Then
                Dim cc As RadioButton = c
                If cc.Checked = True Then
                    Select Case cc.Name
                        Case "RadioButton1"
                            焊缝数 = Int((总长 + 间距) / (焊缝长 + 间距))
                            TextBox1.Text = 焊缝数
                        Case "RadioButton2"
                            焊缝长 = (总长 + 间距) \ 焊缝数 - 间距
                            TextBox2.Text = 焊缝长
                        Case "RadioButton3"
                            间距 = (总长 - 焊缝长 * 焊缝数) \ (焊缝数 - 1)
                            TextBox3.Text = 间距
                        Case "RadioButton4"
                            总长 = (焊缝长 + 间距) * 焊缝数 - 间距
                            TextBox4.Text = 总长
                    End Select
                End If
            End If
        Next
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class