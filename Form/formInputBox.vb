Imports Inventor
Imports Inventor.DocumentTypeEnum
Imports Inventor.SelectionFilterEnum
Imports System.Windows.Forms

Public Class FormInputBox

    Private Sub Btn取消_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn取消.Click, Me.Closing, btn确定.Click
        FormManager.CloseAndDisposeForm(Of FormInputBox)()
    End Sub

    Private Sub FrmInputBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48
        txt输入.SelectAll()
    End Sub

    Private Sub Btn复制_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn复制.Click
        If txt输入.Text <> Nothing Then
            My.Computer.Clipboard.SetText(txt输入.Text)
        End If
    End Sub

    Private Sub Btn粘贴_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn粘贴.Click
        txt输入.Text = My.Computer.Clipboard.GetText
    End Sub

    Private Sub Btn其他_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn其他.Click
        btn其他.Enabled = False

        Select Case btn其他.Text

            Case "查询编码"
                SetStatusBarText()

                If IsInventorOpenDocument() = False Then
                    Exit Sub
                End If

                Dim oInventorDocument As Inventor.Document      '当前文件
                oInventorDocument = ThisApplication.ActiveEditDocument

                '获取iproperty

                Dim strStochNum As String
                Dim strPartNum As String

                strStochNum = GetPropitem(oInventorDocument, Map_DrawingNnumber)

                strPartNum = FindSrtingInSheet(BasicExcelFullFileName, strStochNum, SheetName, TableArrays, ColIndexNum, 0)
                If strPartNum <> 0 Then
                    ' MessageBox.Show("查询到ERP编码：" & strPartNum, MsgBoxStyle.OkOnly, "查询ERP编码")
                    'SetPropitem(oInventorDocument, Map_ERPCode, strPartNum)
                    Select Case txt输入.Text
                        Case ""
                            txt输入.Text = strPartNum
                        Case Else
                            If txt输入.Text <> strPartNum Then
                                If MessageBox.Show("查询到不同的ERP编码：" & strPartNum & "，是否更新？", XHTool，
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                    txt输入.Text = strPartNum
                                End If
                            End If
                    End Select
                Else
                    MessageBox.Show(”未查询到ERP编码。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

        End Select

        btn其他.Enabled = True
    End Sub

    Private Sub Txt输入_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt输入.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            btn确定.PerformClick()
        End If
    End Sub

End Class