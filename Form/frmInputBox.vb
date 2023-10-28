Imports Inventor
Imports Inventor.DocumentTypeEnum
Imports Inventor.SelectionFilterEnum
Imports System.Windows.Forms

Public Class frmInputBox

    Private Sub btn确定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn确定.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btn取消_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn取消.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmInputBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txt输入.SelectAll()
    End Sub

    Private Sub btn复制_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn复制.Click
        If txt输入.Text <> Nothing Then
            My.Computer.Clipboard.SetText(txt输入.Text)
        End If
    End Sub

    Private Sub btn粘贴_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn粘贴.Click
        txt输入.Text = My.Computer.Clipboard.GetText
    End Sub

    Private Sub btn其他_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn其他.Click
        btn其他.Enabled = False

        Select Case btn其他.Text

            Case "查询编码"
                SetStatusBarText()

                If IsInventorOpenDocument() = False Then
                    Exit Sub
                End If

                Dim oInventorDocument As Inventor.Document      '当前文件
                oInventorDocument = ThisApplication.ActiveEditDocument

                Dim oPropSets As PropertySets
                Dim oPropSet As PropertySet
                Dim propitem As [Property]

                oPropSets = oInventorDocument.PropertySets
                oPropSet = oPropSets.Item(3)

                '获取iproperty
                'Dim oStockNumPartName As StockNumPartName = Nothing
                Dim strStochNum As String = Nothing
                Dim strPartNum As String = Nothing

                For Each propitem In oPropSet
                    Select Case propitem.DisplayName
                        Case Map_DrawingNnumber
                            strStochNum = propitem.Value
                            'PartNum = VLookUpValue(Excel_File_Name, StochNum, Sheet_Name, Table_Array, Col_Index_Num, 0)
                            Exit For
                    End Select
                Next

                strPartNum = FindSrtingInSheet(BasicExcelFullFileName, strStochNum, SheetName, TableArrays, ColIndexNum, 0)
                If strPartNum <> 0 Then
                    'MsgBox("查询到ERP编码：" & strPartNum, MsgBoxStyle.OkOnly, "查询ERP编码")
                    'SetPropitem(oInventorDocument, Map_ERPCode, strPartNum)
                    Select Case txt输入.Text
                        Case ""
                            txt输入.Text = strPartNum
                        Case Else
                            If txt输入.Text <> strPartNum Then
                                If MsgBox("查询到不同的ERP编码：" & strPartNum & "，是否更新？", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "") = MsgBoxResult.Yes Then
                                    txt输入.Text = strPartNum
                                End If
                            End If
                    End Select
                Else
                    MsgBox("未查询到ERP编码。", MsgBoxStyle.OkOnly, "查询ERP编码")
                End If

        End Select

        btn其他.Enabled = True
    End Sub

    Private Sub txt输入_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt输入.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            btn确定.PerformClick()
        End If
    End Sub

End Class