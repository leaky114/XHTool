Imports System.Windows.Forms
Imports Inventor.SelectionFilterEnum
Imports Inventor.SelectTypeEnum
Imports Inventor.DocumentTypeEnum
Imports Inventor

Public Class frmGetPart

    '添加
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        'Try
        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        If oInventorDocument.DocumentType <> kAssemblyDocumentObject Then
            MsgBox("该功能仅适用于部件", MsgBoxStyle.Information, "统计质量面积")
            Exit Sub
        End If

        Dim oSelectSet As Inventor.SelectSet
        oSelectSet = oInventorDocument.SelectSet

        If oSelectSet.Count = 0 Then
            MsgBox("请先选择零部件", MsgBoxStyle.OkOnly, "统计质量面积")
            Exit Sub
        End If

        For Each oSelect As Object In oInventorDocument.SelectSet
            'Dim
            'If (oSelect.GetType Is ) = True Then
            'Dim FullFileName As String
            'Dim FNI As FileNameInfo

            'FullFileName = oSelect.name

            'FNI = GetFileNameInfo(FullFileName)

            Dim oListViewItem As ListViewItem
            'LVI = ListView1.Items.Add(FNI.ONlyName)
            oListViewItem = lvwFileList.Items.Add(oSelect.name)

            Dim intQuantity As Integer = 1
            '数量 = InputBox("输入数量", "数量", "1")
            oListViewItem.SubItems.Add(intQuantity)

            'Dim InventorDoc2 As Inventor.Document
            'InventorDoc2 = ThisApplication.Documents.Open(FullFileName, False)
            'LVI.SubItems.Add(GetMass(InventorDoc2) * 数量)
            'LVI.SubItems.Add(GetArea(InventorDoc2) * 数量)

            Dim dblMass As Double
            dblMass = oSelect.MassProperties.mass
            dblMass = dblMass + 0.00000001

            Dim intMassAccuracy As Integer
            intMassAccuracy = Val(Mass_Accuracy)
            dblMass = Math.Round(dblMass, intMassAccuracy)

            Dim dblArea As Double
            dblArea = oSelect.MassProperties.area / 10000
            dblArea = dblArea + 0.00000001

            Dim Val_Area_Accuracy As Integer
            Val_Area_Accuracy = Val(Area_Accuracy)
            dblArea = Math.Round(dblArea, Val_Area_Accuracy)

            oListViewItem.SubItems.Add(dblMass * intQuantity)
            oListViewItem.SubItems.Add(dblArea * intQuantity)
            'End If
        Next

        Dim dblSumMass As Double = 0
        Dim dblSumArea As Double = 0

        For Each LVI As ListViewItem In lvwFileList.Items
            dblSumMass = dblSumMass + LVI.SubItems(1).Text * LVI.SubItems(2).Text
            dblSumArea = dblSumArea + LVI.SubItems(1).Text * LVI.SubItems(3).Text
        Next

        txtWeight.Text = dblSumMass.ToString
        txtArea.Text = dblSumArea.ToString

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    '移出
    Private Sub btnMoveOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveOut.Click
        ListViewDel(lvwFileList)
        Dim dblSumMass As Double = 0
        Dim dblSumArea As Double = 0

        For Each oListViewItem As ListViewItem In lvwFileList.Items
            dblSumMass = dblSumMass + oListViewItem.SubItems(1).Text * oListViewItem.SubItems(2).Text
            dblSumArea = dblSumArea + oListViewItem.SubItems(1).Text * oListViewItem.SubItems(3).Text
        Next

        txtWeight.Text = dblSumMass
        txtArea.Text = dblSumArea
    End Sub

    '退出
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        lvwFileList.Items.Clear()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    '移出项
    Private Sub ListViewDel(ByVal ListView As ListView)
        For i As Integer = ListView.SelectedIndices.Count - 1 To 0 Step -1
            ListView.Items.RemoveAt(ListView.SelectedIndices(i))
        Next
    End Sub

    '清空
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        lvwFileList.Items.Clear()
        txtWeight.Clear()
        txtArea.Clear()
    End Sub

    '复制总质量到剪贴板
    Private Sub btnCopyG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyG.Click
        My.Computer.Clipboard.SetText(txtWeight.Text)
    End Sub

    '复制总面积到剪贴板
    Private Sub btnCopyA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyA.Click
        My.Computer.Clipboard.SetText(txtArea.Text)
    End Sub
End Class