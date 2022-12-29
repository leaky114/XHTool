Imports System.Windows.Forms
Imports Inventor
Imports Inventor.SelectionFilterEnum
Imports Inventor.DocumentTypeEnum

Public Class frmInputBox

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmInputBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtInPut.Focus()
    End Sub

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        If txtInPut.Text <> Nothing Then
            My.Computer.Clipboard.SetText(txtInPut.Text)
        End If
    End Sub

    Private Sub btnPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaste.Click
        txtInPut.Text = My.Computer.Clipboard.GetText
    End Sub

    Private Sub btnOther_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOther.Click
        btnOther.Enabled = False

        Select Case btnOther.Text

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
                    Select Case txtInPut.Text
                        Case ""
                            txtInPut.Text = strPartNum
                        Case Else
                            If txtInPut.Text <> strPartNum Then
                                If MsgBox("查询到不同的ERP编码：" & strPartNum & "，是否更新？", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "") = MsgBoxResult.Yes Then
                                    txtInPut.Text = strPartNum
                                End If
                            End If
                    End Select
                Else
                    MsgBox("未查询到ERP编码。", MsgBoxStyle.OkOnly, "查询ERP编码")
                End If

        End Select

        btnOther.Enabled = True
    End Sub
End Class