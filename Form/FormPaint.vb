Public Class FormPaint

    Private Sub Btn_Enter_Click(sender As Object, e As EventArgs) Handles Btn_Enter.Click
        Dim Areas() As String = l_AreaTotal.Text.Split(" ")
        Print(Areas(0))

    End Sub

    ''' <summary>
    ''' 计算用量
    ''' </summary>
    ''' <param name="sArea">面积</param>
    Public Sub Print(ByVal sArea As Double)
        l_UnderCoatTotal.Text = "0 L"
        l_MiddleCoatTotal.Text = "0 L"
        l_TopCoatTotal.Text = "0 L"

        Dim Weight As Double
        Weight = sArea * N_UnderCoat.Value / 1000 * 150% 'kg
        If R_Spray.Checked Then Weight /= 50%
        If R_Brush.Checked Then Weight /= 90%
        l_UnderCoatTotal.Text = Math.Round(Weight, 2) & " L"

        Weight = sArea * N_MiddleCoat.Value / 1000 * 150% 'kg
        If R_Spray.Checked Then Weight /= 50%
        If R_Brush.Checked Then Weight /= 90%
        l_MiddleCoatTotal.Text = Math.Round(Weight, 2) & " L"

        Weight = sArea * N_TopCoat.Value / 1000 * 150% 'kg
        If R_Spray.Checked Then Weight /= 50%
        If R_Brush.Checked Then Weight /= 90%
        l_TopCoatTotal.Text = Math.Round(Weight, 2) & " L"
    End Sub

    Private Sub Btn_Close_Click(sender As Object, e As EventArgs) Handles Btn_Close.Click, Me.Closing
        FormManager.CloseAndDisposeForm(Of FormPaint)()

    End Sub
End Class