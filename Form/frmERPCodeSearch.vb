Imports System.Windows.Forms

Public Class frmERPCodeSearch

    Private Sub btn粘贴_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn粘贴.Click
        txtERP编码.Text = My.Computer.Clipboard.GetText
        btn编码反查.Focus()
    End Sub

    Private Sub btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub btn编码反查_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn编码反查.Click

        Dim strERPCode As String

        btn编码反查.Enabled = False
        Me.Height = 124

        txt返回值.Clear()

        strERPCode = Replace(txtERP编码.Text, vbCrLf, "")
        strERPCode = Trim(strERPCode)

        if strERPCode = "" Then
            btn编码反查.Enabled = True
            Exit Sub
        End if

        Dim arraystrinfo() As String

        arraystrinfo = ERPCodeSearch(BasicExcelFullFileName, strERPCode, TableArrays, ColIndexNum, 0)

        if arraystrinfo(0) Is Nothing Then
            txt返回值.Text = "未查询到ERP编码。"
            Me.Height = 280
            btn编码反查.Enabled = True
            Exit Sub
        End if

        For Each strinfo As String In arraystrinfo
            if txt返回值.Text = "" Then
                txt返回值.Text = strinfo
            Else
                if strinfo Is Nothing Then
                Else
                    txt返回值.Text = txt返回值.Text & vbCrLf & strinfo
                End if
            End if
        Next

        'oInteraction.Stop()
        Me.Height = 280
        btn编码反查.Enabled = True

    End Sub

    Private Sub frmERPCodeSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Height = 124
    End Sub

End Class