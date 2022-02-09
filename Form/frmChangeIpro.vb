Imports System.Windows.Forms
Imports Inventor

Public Class frmChangeIpro

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        SetPropitem(oInventorDocument, Map_StochNum, txtNum.Text)
        SetPropitem(oInventorDocument, Map_PartName, txtFileName.Text)
        SetPropitem(oInventorDocument, "描述", txtDescribe.Text)

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmChangeIpro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        Dim oPropSets As PropertySets
        Dim oPropSet As PropertySet
        Dim propitem As [Property]

        oPropSets = oInventorDocument.PropertySets
        oPropSet = oPropSets.Item(3)

        '获取iproperty
        Dim StockNumPartName As StockNumPartName = Nothing
        For Each propitem In oPropSet
            Select Case propitem.DisplayName
                Case Map_StochNum
                    txtNum.Text = propitem.Value
                Case Map_PartName
                    txtFileName.Text = propitem.Value
                Case "描述"
                    txtDescribe.Text = propitem.Value
            End Select
        Next

    End Sub

    Private Sub btnUp1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp1.Click
        Dim Str_TempText As String
        Str_TempText = txtNum.Text
        txtNum.Text = txtFileName.Text
        txtFileName.Text = Str_TempText
    End Sub

    Private Sub btnUp2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp2.Click
        Dim Str_TempText As String
        Str_TempText = txtFileName.Text
        txtFileName.Text = txtDescribe.Text
        txtDescribe.Text = Str_TempText
    End Sub

End Class