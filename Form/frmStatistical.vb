Imports Inventor
Imports Inventor.DocumentTypeEnum
Imports Inventor.SelectionFilterEnum
Imports Inventor.SelectTypeEnum
Imports System.Windows.Forms

Public Class frmStatistical

    Private dblSumMass As Double = 0
    Private dblSumArea As Double = 0
    Private dou长度系数 As Double

   


    Private Sub frmStatisticalWeight_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim toolTip As New ToolTip()
        toolTip.AutoPopDelay = 0
        toolTip.InitialDelay = 0
        toolTip.ReshowDelay = 500
        toolTip.SetToolTip(btn复制焊缝长度, "复制焊缝长度")
        toolTip.SetToolTip(btn选择面和边, "选择面和边")



        btn复制焊缝长度.Image = My.Resources.复制16.ToBitmap
        btn选择面和边.Image = My.Resources.选择面和边32.ToBitmap

        RadioButton10.Checked = True
        dou长度系数 = 1
        '============================================================================================
        '选择切换到 选择面和边
        'ThisApplication.UserInterfaceManager.Ribbons("Assembly").QuickAccessControls.Item("ID_QAT_Assembly_Select").ChildControls.Item("PartSelectFacesAndEdgePriorityCmd").ControlDefinition.Execute()

        toolTip.AutoPopDelay = 0
        toolTip.InitialDelay = 0
        toolTip.ReshowDelay = 500
        toolTip.SetToolTip(btn选择零件, "选择零件")
        toolTip.SetToolTip(btn复制质量, "复制质量")
        toolTip.SetToolTip(btn复制面积, "复制面积")

        btn选择零件.Image = My.Resources.选择面和边32.ToBitmap
        btn复制面积.Image = My.Resources.复制16.ToBitmap
        btn复制质量.Image = My.Resources.复制16.ToBitmap

        txt质量.Text = "0"
        txt面积.Text = "0"

    End Sub

    '移出
    Private Sub btn移出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn移出.Click
        Select Case TabControl1.SelectedTab.Text
            Case "质量和面积"
                ListViewDel(lvw质量文件列表)
                Dim dblSumMass As Double = 0
                Dim dblSumArea As Double = 0

                For Each oListViewItem As ListViewItem In lvw质量文件列表.Items
                    dblSumMass = dblSumMass + oListViewItem.SubItems(1).Text * oListViewItem.SubItems(2).Text
                    dblSumArea = dblSumArea + oListViewItem.SubItems(1).Text * oListViewItem.SubItems(3).Text
                Next

                txt质量.Text = dblSumMass
                txt面积.Text = dblSumArea

            Case "焊缝"

                ListViewDel(lvw焊缝文件列表)
                Dim dbl焊缝总长度 As Double = 0

                For Each oListViewItem As ListViewItem In lvw焊缝文件列表.Items
                    dbl焊缝总长度 = dbl焊缝总长度 + oListViewItem.SubItems(3).Text
                Next

                txt焊缝长度.Text = dbl焊缝总长度.ToString

        End Select


    End Sub

    '清空
    Private Sub btn清空_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn清空.Click
        lvw质量文件列表.Items.Clear()
        lvw焊缝文件列表.Items.Clear()

        txt质量.Text = 0
        txt面积.Text = 0
        txt焊缝长度.Text = 0

    End Sub

    '退出
    Private Sub btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    '复制总质量到剪贴板
    Private Sub btn复制质量_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn复制质量.Click
        My.Computer.Clipboard.SetText(txt质量.Text)
    End Sub

    '复制总面积到剪贴板
    Private Sub btn复制面积_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn复制面积.Click
        My.Computer.Clipboard.SetText(txt面积.Text)
    End Sub

    '复制焊缝长度到剪贴板
    Private Sub btn复制焊缝长度_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn复制焊缝长度.Click
        My.Computer.Clipboard.SetText(txt焊缝长度.Text)
    End Sub



    '质量面积选择零件
    Private Sub btn选择零件_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn选择零件.Click

        Try
            Dim oPart As ComponentOccurrence

            Do
                oPart = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kAssemblyOccurrenceFilter, "选择一个零件，ESC键取消")


                Dim oListViewItem As ListViewItem
                'LVI = ListView1.Items.Add(FNI.ONlyName)
                oListViewItem = lvw质量文件列表.Items.Add(oPart.Name)

                Dim intQuantity As Integer = 1
                '数量 = InputBox("输入数量", "数量", "1")
                oListViewItem.SubItems.Add(intQuantity)

                'Dim InventorDoc2 As Inventor.Document
                'InventorDoc2 = ThisApplication.Documents.Open(FullFileName, False)
                'LVI.SubItems.Add(GetMass(InventorDoc2) * 数量)
                'LVI.SubItems.Add(GetArea(InventorDoc2) * 数量)

                Dim dblMass As Double
                dblMass = oPart.MassProperties.Mass
                dblMass = dblMass + 0.00000001

                Dim intMassAccuracy As Integer
                intMassAccuracy = Val(Mass_Accuracy)
                dblMass = Math.Round(dblMass, intMassAccuracy)

                Dim dblArea As Double
                dblArea = oPart.MassProperties.Area / 10000
                dblArea = dblArea + 0.00000001

                Dim Val_Area_Accuracy As Integer
                Val_Area_Accuracy = Val(Area_Accuracy)
                dblArea = Math.Round(dblArea, Val_Area_Accuracy)

                oListViewItem.SubItems.Add(dblMass * intQuantity)
                oListViewItem.SubItems.Add(dblArea * intQuantity)

                For Each LVI As ListViewItem In lvw质量文件列表.Items
                    dblSumMass = dblSumMass + LVI.SubItems(1).Text * LVI.SubItems(2).Text
                    dblSumArea = dblSumArea + LVI.SubItems(1).Text * LVI.SubItems(3).Text
                Next

                txt质量.Text = dblSumMass.ToString
                txt面积.Text = dblSumArea.ToString


            Loop While True



        Catch ex As Exception


        End Try


        ''Try
        'SetStatusBarText()

        'if IsInventorOpenDocument() = False Then
        '    Exit Sub
        'End if

        'Dim oInventorDocument As Inventor.Document
        'oInventorDocument = ThisApplication.ActiveDocument

        'if oInventorDocument.DocumentType <> kAssemblyDocumentObject Then
        '    MsgBox("该功能仅适用于部件", MsgBoxStyle.Information, "统计质量面积")
        '    Exit Sub
        'End if

        'Dim oSelectSet As Inventor.SelectSet
        'oSelectSet = oInventorDocument.SelectSet

        'if oSelectSet.Count = 0 Then
        '    MsgBox("请先选择零部件", MsgBoxStyle.OkOnly, "统计质量面积")
        '    Exit Sub
        'End if


        ''Dim Types As ObjectTypeEnum() = [Enum].GetValues(GetType(ObjectTypeEnum))

        'Dim oPart As ComponentOccurrence

        'For Each oSelect As Object In oSelectSet
        '    'For Each Type As ObjectTypeEnum In Types
        '    if oSelect.Type = Inventor.ObjectTypeEnum.kComponentOccurrenceObject Then
        '        oPart = oSelect


        '        Dim oListViewItem As ListViewItem
        '        'LVI = ListView1.Items.Add(FNI.ONlyName)
        '        oListViewItem = lvw文件列表.Items.Add(oSelect.name)

        '        Dim intQuantity As Integer = 1
        '        '数量 = InputBox("输入数量", "数量", "1")
        '        oListViewItem.SubItems.Add(intQuantity)

        '        'Dim InventorDoc2 As Inventor.Document
        '        'InventorDoc2 = ThisApplication.Documents.Open(FullFileName, False)
        '        'LVI.SubItems.Add(GetMass(InventorDoc2) * 数量)
        '        'LVI.SubItems.Add(GetArea(InventorDoc2) * 数量)

        '        Dim dblMass As Double
        '        dblMass = oSelect.MassProperties.mass
        '        dblMass = dblMass + 0.00000001

        '        Dim intMassAccuracy As Integer
        '        intMassAccuracy = Val(Mass_Accuracy)
        '        dblMass = Math.Round(dblMass, intMassAccuracy)

        '        Dim dblArea As Double
        '        dblArea = oSelect.MassProperties.area / 10000
        '        dblArea = dblArea + 0.00000001

        '        Dim Val_Area_Accuracy As Integer
        '        Val_Area_Accuracy = Val(Area_Accuracy)
        '        dblArea = Math.Round(dblArea, Val_Area_Accuracy)

        '        oListViewItem.SubItems.Add(dblMass * intQuantity)
        '        oListViewItem.SubItems.Add(dblArea * intQuantity)

        '        'Exit For
        '    End if
        '    'Next
        'Next


        'Dim dblSumMass As Double = 0
        'Dim dblSumArea As Double = 0

        'For Each LVI As ListViewItem In lvw文件列表.Items
        '    dblSumMass = dblSumMass + LVI.SubItems(1).Text * LVI.SubItems(2).Text
        '    dblSumArea = dblSumArea + LVI.SubItems(1).Text * LVI.SubItems(3).Text
        'Next

        'txt质量.Text = dblSumMass.ToString
        'txt面积.Text = dblSumArea.ToString

        ''Catch ex As Exception
        ''    MsgBox(ex.Message)
        ''End Try
    End Sub

   

    Private Sub btn选择面和边_Click(sender As Object, e As EventArgs) Handles btn选择面和边.Click
        'For Each oCommandControl As CommandControl In ThisApplication.UserInterfaceManager.Ribbons("Assembly").QuickAccessControls

        '    Debug.Print(oCommandControl.DisplayName & "-------" & oCommandControl.InternalName)

        '    if oCommandControl.InternalName = "ID_QAT_Assembly_Select" Then

        '        For Each o As CommandControl In oCommandControl.ChildControls

        '            Debug.Print(o.DisplayName & "-------" & o.InternalName)

        '        Next
        '    End if
        'Next

        'ThisApplication.UserInterfaceManager.Ribbons("Assembly").QuickAccessControls.Item("ID_QAT_Assembly_Select").ChildControls.Item("PartSelectFacesAndEdgePriorityCmd").ControlDefinition.Execute()



        'For Each oContrl In Me.GroupBox1.Controls
        '    if TypeOf oContrl Is RadioButton Then
        '        Dim oRadioButton As RadioButton = CType(oContrl, RadioButton)
        '        ' 检查RadioButton是否被选中
        '        if oRadioButton.Checked Then
        '            dou长度系数 = Val(oRadioButton.Text)
        '            Exit For
        '        End if
        '    End if
        'Next

        Dim dbl焊缝总长度 As Double

        Try
            Dim oedge As Edge
            Do
                oedge = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kPartEdgeFilter, "选择一条边，ESC键取消")


                Dim oListViewItem As ListViewItem


                Dim oEval As CurveEvaluator = oedge.Evaluator
                Dim oMin, oMax, oLength As Double
                oEval.GetParamExtents(oMin, oMax)
                oEval.GetLengthAtParam(oMin, oMax, oLength)

                Dim UoM As UnitsOfMeasure = ThisApplication.ActiveDocument.UnitsOfMeasure
                'MsgBox(UoM.GetStringFromValue(oLength, UoM.LengthUnits))

                Dim dou边长度 = UoM.GetStringFromValue(oLength, UoM.LengthUnits)
                Dim dou焊缝长度 = Val(dou边长度) * dou长度系数

                Dim oSurfaceBodyProxy As SurfaceBodyProxy
                oSurfaceBodyProxy = oedge.Parent

                Dim oComponentOccurrence As ComponentOccurrence
                oComponentOccurrence = oSurfaceBodyProxy.Parent


                oListViewItem = lvw焊缝文件列表.Items.Add(oComponentOccurrence.Name)
                oListViewItem.SubItems.Add(dou边长度.ToString)
                oListViewItem.SubItems.Add(dou长度系数.ToString)
                oListViewItem.SubItems.Add(dou焊缝长度.ToString)

                For Each LVI As ListViewItem In lvw焊缝文件列表.Items
                    dbl焊缝总长度 = dbl焊缝总长度 + LVI.SubItems(3).Text
                Next

                txt焊缝长度.Text = dbl焊缝总长度.ToString

            Loop While True
        Catch ex As Exception


        End Try

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        dou长度系数 = 0.3
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        dou长度系数 = 0.5
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        dou长度系数 = 0.7
    End Sub

    Private Sub RadioButton10_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton10.CheckedChanged
        dou长度系数 = 1
    End Sub

End Class