Imports System.Windows.Forms
Imports Inventor

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

        If strERPCode = "" Then
            btn编码反查.Enabled = True
            Exit Sub
        End If

        Dim arraystrinfo() As String

        Dim oInteraction As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        oInteraction.Start()
        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        ThisApplication.UserInterfaceManager.DoEvents()

        arraystrinfo = ERPCodeSearch(BasicExcelFullFileName, strERPCode, TableArrays, ColIndexNum, 0)

        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        oInteraction.Stop()
    

        If arraystrinfo(0) Is Nothing Then
            txt返回值.Text = "未查询到ERP编码。"
            Me.Height = 280
            btn编码反查.Enabled = True
            Exit Sub
        End If

        For Each strinfo As String In arraystrinfo
            If txt返回值.Text = "" Then
                txt返回值.Text = strinfo
            Else
                If strinfo Is Nothing Then
                Else
                    txt返回值.Text = txt返回值.Text & vbCrLf & strinfo
                End If
            End If
        Next

        Me.Height = 280
        btn编码反查.Enabled = True

    End Sub

    Private Sub frmERPCodeSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48
        Me.Height = 124
    End Sub

End Class