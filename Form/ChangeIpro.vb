Imports System.Windows.Forms
Imports Inventor

Public Class ChangeIproDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim InventorDoc As Document
        InventorDoc = ThisApplication.ActiveEditDocument

        SetPropitem(InventorDoc, Map_StochNum, TextBox1.Text)
        SetPropitem(InventorDoc, Map_PartName, TextBox2.Text)
        SetPropitem(InventorDoc, "描述", TextBox3.Text)

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ChangeIpro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim InventorDoc As Document
        InventorDoc = ThisApplication.ActiveEditDocument

        Dim oPropSets As PropertySets
        Dim oPropSet As PropertySet
        Dim propitem As [Property]

        oPropSets = InventorDoc.PropertySets
        oPropSet = oPropSets.Item(3)

        '获取iproperty
        Dim StockNumPartName As StockNumPartName = Nothing
        For Each propitem In oPropSet
            Select Case propitem.DisplayName
                Case Map_StochNum
                    TextBox1.Text = propitem.Value
                Case Map_PartName
                    TextBox2.Text = propitem.Value
                Case "描述"
                    TextBox3.Text = propitem.Value
            End Select
        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Str_TempText As String
        Str_TempText = TextBox1.Text
        TextBox1.Text = TextBox2.Text
        TextBox2.Text = Str_TempText
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Str_TempText As String
        Str_TempText = TextBox2.Text
        TextBox2.Text = TextBox3.Text
        TextBox3.Text = Str_TempText
    End Sub

    
End Class
