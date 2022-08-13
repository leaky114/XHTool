Imports System.Windows.Forms
Imports Inventor

Public Class frmChangeIpro

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        SetPropitem(oInventorDocument, Map_DrawingNnumber, txtNum.Text)
        SetPropitem(oInventorDocument, Map_PartName, txtFileName.Text)
        SetPropitem(oInventorDocument, Map_Describe, txtDescribe.Text)

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
        ''Dim oStockNumPartName As StockNumPartName = Nothing
        For Each propitem In oPropSet
            Select Case propitem.DisplayName
                Case Map_DrawingNnumber
                    txtNum.Text = propitem.Value
                Case Map_PartName
                    txtFileName.Text = propitem.Value
                Case Map_Describe
                    txtDescribe.Text = propitem.Value
            End Select
        Next

    End Sub

    Private Sub btnUp1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp1.Click
        Dim strTemp As String
        strTemp = txtNum.Text
        txtNum.Text = txtFileName.Text
        txtFileName.Text = strTemp
    End Sub

    Private Sub btnUp2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp2.Click
        Dim strTemp As String
        strTemp = txtFileName.Text
        txtFileName.Text = txtDescribe.Text
        txtDescribe.Text = strTemp
    End Sub

End Class