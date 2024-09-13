Imports Inventor
Imports Inventor.DocumentTypeEnum
Imports Inventor.SelectionFilterEnum
Imports System.Windows.Forms

Public NotInheritable Class frmSearchERPCode

    Private Sub btn查询编码_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn查询编码.Click
        Dim strDrawingNo As String
        'Dim strERPCode As String

        btn查询编码.Enabled = False
        Me.Height = 156
        txtERP编码.Text = ""

        strDrawingNo = Replace(txt规格图号.Text, vbCrLf, "")
        strDrawingNo = Trim(strDrawingNo)

        if strDrawingNo = "" Then
            btn查询编码.Enabled = True
            Exit Sub
        End if

        'strERPCode = FindSrtingInSheet(BasicExcelFullFileName, strDrawingNo, SheetName, TableArrays, ColIndexNum, 0)

        'if strERPCode <> 0 Then
        '    txtERPCode.Text = strERPCode
        'Else
        '    txtERPCode.Text = "未查询到ERP编码。"
        'End if

        Dim arraystrERPCode() As String

        Dim oInteraction As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        oInteraction.Start()
        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        ThisApplication.UserInterfaceManager.DoEvents()

        arraystrERPCode = FindAllSrtingInSheet(BasicExcelFullFileName, strDrawingNo, TableArrays, ColIndexNum, 0)

        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        oInteraction.Stop()

        if arraystrERPCode(0) Is Nothing Then
            txtERP编码.Text = "未查询到ERP编码。"
            btn查询编码.Enabled = True
            Exit Sub
        End if

        if arraystrERPCode(1) Is Nothing Then
            txtERP编码.Text = arraystrERPCode(0)
            btn查询编码.Enabled = True
            Exit Sub
        End if

        lvw编码列表.Items.Clear()

        Dim oListViewItem As ListViewItem
        For Each strERPCode As String  In arraystrERPCode
            If strERPCode Xor Nothing Then

                oListViewItem = lvw编码列表.Items.Add(strDrawingNo)
                With oListViewItem
                    .SubItems.Add(strERPCode)
                End With
            End If
        Next

        Me.Height = 280
        btn查询编码.Enabled = True
        btn复制编码.Focus()

    End Sub

    Private Sub btn粘贴到规格_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn粘贴到规格.Click
        txt规格图号.Text = My.Computer.Clipboard.GetText
        btn查询编码.Focus()
    End Sub

    Private Sub btn复制编码_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn复制编码.Click
        if txtERP编码.Text <> Nothing Then
            My.Computer.Clipboard.SetText(txtERP编码.Text)
        End if
    End Sub

    Private Sub btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub frmSearchERPCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48
        Me.Height = 156
    End Sub

    'Private Sub txt规格图号_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt规格图号.KeyPress
    '    if Asc(e.KeyChar) = Keys.Enter Then
    '        btn查询编码.PerformClick()
    '    End if
    'End Sub

    Private Sub lvw编码列表_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvw编码列表.SelectedIndexChanged
        if lvw编码列表.SelectedIndices.Count > 0 Then
            Dim index As Integer = lvw编码列表.SelectedIndices(0)  '选中行的下一行索引
            txtERP编码.Text = lvw编码列表.Items(index).SubItems(1).Text
        End if

    End Sub
End Class