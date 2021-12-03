Imports System.Windows.Forms
Imports Inventor.SelectionFilterEnum
Imports Inventor.SelectTypeEnum
Imports Inventor.DocumentTypeEnum
Imports Inventor

Public Class GetPartDialog

    '添加
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'Try
        SetStatusBarText()

        If IsInventorOpenDoc() = False Then
            Exit Sub
        End If

        Dim InventorDoc As Inventor.Document
        InventorDoc = ThisApplication.ActiveDocument

        If InventorDoc.DocumentType <> kAssemblyDocumentObject Then
            MsgBox("该功能仅适用于部件", MsgBoxStyle.Information, "统计质量面积")
            Exit Sub
        End If

        Dim oSelectSet As Inventor.SelectSet
        oSelectSet = InventorDoc.SelectSet

        If oSelectSet.Count = 0 Then
            MsgBox("请先选择零部件", MsgBoxStyle.OkOnly, "统计质量面积")
            Exit Sub
        End If

        For Each oSelect As Object In InventorDoc.SelectSet
            'Dim
            'If (oSelect.GetType Is ) = True Then
            'Dim FullFileName As String
            'Dim FNI As FileNameInfo

            'FullFileName = oSelect.name

            'FNI = GetFileNameInfo(FullFileName)

            Dim LVI As ListViewItem
            'LVI = ListView1.Items.Add(FNI.ONlyName)
            LVI = ListView1.Items.Add(oSelect.name)

            Dim 数量 As Integer = 1
            '数量 = InputBox("输入数量", "数量", "1")
            LVI.SubItems.Add(数量)

            'Dim InventorDoc2 As Inventor.Document
            'InventorDoc2 = ThisApplication.Documents.Open(FullFileName, False)
            'LVI.SubItems.Add(GetMass(InventorDoc2) * 数量)
            'LVI.SubItems.Add(GetArea(InventorDoc2) * 数量)

            Dim valMass As Double
            valMass = oSelect.MassProperties.mass
            valMass = valMass + 0.00000001

            Dim Val_Mass_Accuracy As Integer
            Val_Mass_Accuracy = Val(Mass_Accuracy)
            valMass = Math.Round(valMass, Val_Mass_Accuracy)

            Dim valArea As Double
            valArea = oSelect.MassProperties.area / 10000
            valArea = valArea + 0.00000001

            Dim Val_Area_Accuracy As Integer
            Val_Area_Accuracy = Val(Area_Accuracy)
            valArea = Math.Round(valArea, Val_Area_Accuracy)

            LVI.SubItems.Add(valMass * 数量)
            LVI.SubItems.Add(valArea * 数量)
            'End If
        Next

        Dim SumMass As Double = 0
        Dim SumArea As Double = 0

        For Each LVI As ListViewItem In ListView1.Items
            SumMass = SumMass + LVI.SubItems(1).Text * LVI.SubItems(2).Text
            SumArea = SumArea + LVI.SubItems(1).Text * LVI.SubItems(3).Text
        Next

        TextBox1.Text = SumMass
        TextBox2.Text = SumArea

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    '移出
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ListViewDel(ListView1)
        Dim SumMass As Double = 0
        Dim SumArea As Double = 0

        For Each LVI As ListViewItem In ListView1.Items
            SumMass = SumMass + LVI.SubItems(1).Text * LVI.SubItems(2).Text
            SumArea = SumArea + LVI.SubItems(1).Text * LVI.SubItems(3).Text
        Next

        TextBox1.Text = SumMass
        TextBox2.Text = SumArea
    End Sub

    '退出
    Private Sub Cancel_Button_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        ListView1.Items.Clear()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    '移出项
    Private Sub ListViewDel(ByVal ListView As ListView)
        For i As Integer = ListView.SelectedIndices.Count - 1 To 0 Step -1
            ListView.Items.RemoveAt(ListView.SelectedIndices(i))
        Next
    End Sub

    '清空
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ListView1.Items.Clear()
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

    '复制总质量到剪贴板
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Computer.Clipboard.SetText(TextBox1.Text)
    End Sub

    '复制总面积到剪贴板
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        My.Computer.Clipboard.SetText(TextBox2.Text)
    End Sub

    Private Sub GetPartDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class