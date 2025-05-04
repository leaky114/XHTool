Imports Inventor
Imports Inventor.DocumentTypeEnum
Imports Inventor.SelectionFilterEnum
Imports Inventor.SelectTypeEnum
Imports System.Windows.Forms

Public Class FormStatistical

    Private dblSumMass As Double = 0
    Private dblSumArea As Double = 0
    Private dou长度系数 As Double

    Private oHSet As HighlightSet

    Private Sub FrmStatisticalWeight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48
        Me.TopMost = True

        Dim toolTip As New ToolTip With {
            .AutoPopDelay = 0,
            .InitialDelay = 0,
            .ReshowDelay = 500
        }
        toolTip.SetToolTip(btn复制焊缝长度, "复制焊缝长度")
        toolTip.SetToolTip(btn选择面和边, "选择面和边")
        toolTip.SetToolTip(btn添加零部件, "添加已选择的零部件")

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
        btn添加零部件.Image = My.Resources.添加16.ToBitmap

        txt质量.Text = "0"
        txt面积.Text = "0"

        oHSet = ThisApplication.ActiveDocument.CreateHighlightSet()
        oHSet.Color = ThisApplication.TransientObjects.CreateColor(255, 0, 0)

    End Sub

    '移出
    Private Sub Btn移出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn移出.Click, tsmi移出.Click
        Select Case TabControl1.SelectedTab.Text
            Case "质量和面积"
                ListViewDel(lvw质量文件列表)
                Dim dblSumMass As Double = 0
                Dim dblSumArea As Double = 0

                For Each oListViewItem As ListViewItem In lvw质量文件列表.Items
                    dblSumMass = dblSumMass + oListViewItem.SubItems(2).Text
                    dblSumArea = dblSumArea + oListViewItem.SubItems(3).Text
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
    Private Sub Btn清空_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn清空.Click, tsmi清空.Click
        Select Case TabControl1.SelectedTab.Text
            Case "质量和面积"
                lvw质量文件列表.Items.Clear()
                dblSumMass = 0
                txt质量.Text = 0
                txt面积.Text = 0

            Case "焊缝"
                lvw焊缝文件列表.Items.Clear()
                dblSumArea = 0
                txt焊缝长度.Text = 0
                oHSet.Clear()

        End Select

    End Sub

    '退出
    Private Sub Btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click, Me.Closing
        Btn清空_Click（sender, e)
        FormManager.CloseAndDisposeForm(Of FormStatistical)()
    End Sub

    '复制总质量到剪贴板
    Private Sub Btn复制质量_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn复制质量.Click
        My.Computer.Clipboard.SetText(txt质量.Text)
    End Sub

    '复制总面积到剪贴板
    Private Sub Btn复制面积_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn复制面积.Click
        My.Computer.Clipboard.SetText(txt面积.Text)
    End Sub

    '复制焊缝长度到剪贴板
    Private Sub Btn复制焊缝长度_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn复制焊缝长度.Click
        My.Computer.Clipboard.SetText(txt焊缝长度.Text)
    End Sub

    '质量面积选择零件
    Private Sub Btn选择零件_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn选择零件.Click

        Try
            Dim oComponentOccurrence As ComponentOccurrence

            Do
                oComponentOccurrence = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kAssemblyOccurrenceFilter, "选择一个零件，ESC键取消")

                Dim oListViewItem As ListViewItem
                'LVI = ListView1.Items.Add(FNI.ONlyName)

                If IsItemInListView(lvw质量文件列表, oComponentOccurrence.Name) Then
                    Continue Do
                End If

                oListViewItem = lvw质量文件列表.Items.Add(oComponentOccurrence.Name)

                Dim intQuantity As Integer = 1
                '数量 = InputBox("输入数量", "数量", "1")
                oListViewItem.SubItems.Add(intQuantity)

                'Dim InventorDoc2 As Inventor.Document
                'InventorDoc2 = ThisApplication.Documents.Open(FullFileName, False)
                'LVI.SubItems.Add(GetMass(InventorDoc2) * 数量)
                'LVI.SubItems.Add(GetArea(InventorDoc2) * 数量)

                Dim dblMass As Double
                dblMass = oComponentOccurrence.MassProperties.Mass
                dblMass = dblMass + 0.00000001

                Dim intMassAccuracy As Integer
                intMassAccuracy = Val(Mass_Accuracy)
                dblMass = Math.Round(dblMass, intMassAccuracy)

                Dim dblArea As Double
                dblArea = oComponentOccurrence.MassProperties.Area / 10000
                dblArea = dblArea + 0.00000001

                Dim Val_Area_Accuracy As Integer
                Val_Area_Accuracy = Val(Area_Accuracy)
                dblArea = Math.Round(dblArea, Val_Area_Accuracy)

                oListViewItem.SubItems.Add(dblMass * intQuantity)
                oListViewItem.SubItems.Add(dblArea * intQuantity)

                dblSumMass = 0
                dblSumArea = 0

                For Each LVI As ListViewItem In lvw质量文件列表.Items
                    dblSumMass = dblSumMass + LVI.SubItems(1).Text * LVI.SubItems(2).Text
                    dblSumArea = dblSumArea + LVI.SubItems(1).Text * LVI.SubItems(3).Text
                Next

                txt质量.Text = dblSumMass.ToString
                txt面积.Text = dblSumArea.ToString

            Loop While True




        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btn选择面和边_Click(sender As Object, e As EventArgs) Handles btn选择面和边.Click

        Dim dbl焊缝总长度 As Double

        Try
            Dim oedge As Edge
            Do
                oedge = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kPartEdgeFilter, "选择一条边，ESC键取消")

                oHSet.AddItem(oedge)

                Dim oListViewItem As ListViewItem

                Dim oEval As CurveEvaluator = oedge.Evaluator
                Dim oMin, oMax, oLength As Double
                oEval.GetParamExtents(oMin, oMax)
                oEval.GetLengthAtParam(oMin, oMax, oLength)

                Dim UoM As UnitsOfMeasure = ThisApplication.ActiveDocument.UnitsOfMeasure
                ' MessageBox.Show(UoM.GetStringFromValue(oLength, UoM.LengthUnits))

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

                dbl焊缝总长度 = 0

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

    Private Sub Btn添加零部件_Click(sender As Object, e As EventArgs) Handles btn添加零部件.Click
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        If oInventorDocument.SelectSet.Count = 0 Then
            Exit Sub
        End If

        Debug.Print(oInventorDocument.SelectSet.Item(1).Type)

        Try
            'For Each oComponentOccurrence As ComponentOccurrence In oInventorDocument.SelectSet
            Dim intQuantity As Integer = Nothing

            Dim strName As String = Nothing
            Dim douMass As Double = Nothing
            Dim douArea As Double = Nothing

            Dim oComponentOccurrence As ComponentOccurrence
            Dim oRectangularOccurrencePattern As RectangularOccurrencePattern
            Dim oCircularOccurrencePattern As CircularOccurrencePattern

            For Each oSelectObject In oInventorDocument.SelectSet

                Debug.Print(oSelectObject.type)

                Select Case oSelectObject.Type

                    Case ObjectTypeEnum.kComponentOccurrenceObject          '组件
                        ' MessageBox.Show(ObjectTypeEnum.kComponentOccurrenceObject)
                        oComponentOccurrence = CType(oSelectObject, ComponentOccurrence)
                        strName = oComponentOccurrence.Name
                        douMass = oComponentOccurrence.MassProperties.Mass
                        douArea = oComponentOccurrence.MassProperties.Area / 10000
                        intQuantity = 1

                        AddOccurrenceToListView(lvw质量文件列表, strName, intQuantity, douMass, douArea)

                    Case ObjectTypeEnum.kRectangularOccurrencePatternObject       '矩形阵列
                        ' MessageBox.Show(ObjectTypeEnum.kRectangularOccurrencePatternObject)


                        oRectangularOccurrencePattern = CType(oSelectObject, RectangularOccurrencePattern)
                        intQuantity = oRectangularOccurrencePattern.ColumnCount.Value * oRectangularOccurrencePattern.RowCount.Value

                        For Each OccurrencePatternElementObject As OccurrencePatternElement In oRectangularOccurrencePattern.OccurrencePatternElements
                            strName = OccurrencePatternElementObject.Occurrences.Item(1).Name
                            douMass = OccurrencePatternElementObject.Occurrences.Item(1).MassProperties.Mass
                            douArea = OccurrencePatternElementObject.Occurrences.Item(1).MassProperties.Area / 10000
                            intQuantity = 1
                            AddOccurrenceToListView(lvw质量文件列表, strName, intQuantity, douMass, douArea)
                        Next

                    Case ObjectTypeEnum.kCircularOccurrencePatternObject     '环形阵列
                        ' MessageBox.Show(ObjectTypeEnum.kRectangularOccurrencePatternObject)


                        oCircularOccurrencePattern = CType(oSelectObject, CircularOccurrencePattern)
                        intQuantity = oCircularOccurrencePattern.ElementCount.Value

                        For Each OccurrencePatternElementObject As OccurrencePatternElement In oCircularOccurrencePattern.OccurrencePatternElements
                            strName = OccurrencePatternElementObject.Occurrences.Item(1).Name
                            douMass = OccurrencePatternElementObject.Occurrences.Item(1).MassProperties.Mass
                            douArea = OccurrencePatternElementObject.Occurrences.Item(1).MassProperties.Area / 10000
                            intQuantity = 1
                            AddOccurrenceToListView(lvw质量文件列表, strName, intQuantity, douMass, douArea)
                        Next

                End Select


            Next

        Catch

        End Try

        dblSumArea = 0
        dblSumMass = 0

        For Each LVI As ListViewItem In lvw质量文件列表.Items
            dblSumMass = dblSumMass + LVI.SubItems(2).Text
            dblSumArea = dblSumArea + LVI.SubItems(3).Text
        Next

        txt质量.Text = dblSumMass.ToString
        txt面积.Text = dblSumArea.ToString

    End Sub

    ''' <summary>
    ''' 添加组建到listview
    ''' </summary>
    ''' <param name="oListView">listview对象</param>
    ''' <param name="strFileName">组件名</param>
    ''' <param name="intQuantity">组件数量</param>
    ''' <param name="douMass">组件重量</param>
    ''' <param name="douArea">组件面积</param>
    ''' <remarks></remarks>
    Private Sub AddOccurrenceToListView(ByVal oListView As ListView, ByVal strFileName As String, ByVal intQuantity As Integer, _
                                        ByVal douMass As Double, douArea As Double)
        Dim oListViewItem As ListViewItem
        'LVI = ListView1.Items.Add(FNI.ONlyName)

        If IsItemInListView(oListView, strFileName) = True Then
            Exit Sub
        End If

        oListViewItem = oListView.Items.Add(strFileName)

        oListViewItem.SubItems.Add(intQuantity)

        'Dim InventorDoc2 As Inventor.Document
        'InventorDoc2 = ThisApplication.Documents.Open(FullFileName, False)
        'LVI.SubItems.Add(GetMass(InventorDoc2) * 数量)
        'LVI.SubItems.Add(GetArea(InventorDoc2) * 数量)

        douMass = douMass + 0.00000001

        Dim intMassAccuracy As Integer
        intMassAccuracy = Val(Mass_Accuracy)
        douMass = Math.Round(douMass, intMassAccuracy)


        douArea = douArea + 0.00000001

        Dim Val_Area_Accuracy As Integer
        Val_Area_Accuracy = Val(Area_Accuracy)
        douArea = Math.Round(douArea, Val_Area_Accuracy)

        oListViewItem.SubItems.Add(douMass * intQuantity)
        oListViewItem.SubItems.Add(douArea * intQuantity)
    End Sub

    Private Sub Lvw质量文件列表_KeyDown(sender As Object, e As KeyEventArgs) Handles lvw质量文件列表.KeyDown
        Select Case e.KeyCode
            'Case Keys.Up
            '    If e.Control Then
            '        ListViewUp(lvw文件列表)
            '        e.Handled = True
            '    End If
            'Case Keys.Down
            '    If e.Control Then
            '        ListViewDown(lvw文件列表)
            '        e.Handled = True
            '    End If
            Case Keys.Delete
                ListViewDel(lvw质量文件列表)
        End Select
    End Sub

    Private Sub Lvw焊缝文件列表_KeyDown(sender As Object, e As KeyEventArgs) Handles lvw焊缝文件列表.KeyDown
        Select Case e.KeyCode
            'Case Keys.Up
            '    If e.Control Then
            '        ListViewUp(lvw文件列表)
            '        e.Handled = True
            '    End If
            'Case Keys.Down
            '    If e.Control Then
            '        ListViewDown(lvw文件列表)
            '        e.Handled = True
            '    End If
            Case Keys.Delete
                ListViewDel(lvw焊缝文件列表)
        End Select
    End Sub


    Private Sub Lvw质量文件列表_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvw质量文件列表.SelectedIndexChanged
        Try
            If lvw质量文件列表.SelectedIndices.Count > 0 Then
                Dim index As Integer = lvw质量文件列表.SelectedIndices(0)  '选中行的下一行索引
                If index < lvw质量文件列表.Items.Count Then

                    Dim item As ListViewItem = lvw质量文件列表.Items(index)

                    Dim strDisplayName As String   '旧文件全名
                    strDisplayName = item.Text

                    Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
                    oInventorAssemblyDocument = ThisApplication.ActiveDocument

                    'Dim strInventorAssemblyFullFileName As String
                    'strInventorAssemblyFullFileName = oInventorAssemblyDocument.FullFileName

                    ' 获取装配定义
                    Dim oAssemblyComponentDefinition As AssemblyComponentDefinition
                    oAssemblyComponentDefinition = oInventorAssemblyDocument.ComponentDefinition

                    ' 获取装配子集
                    Dim oComponentOccurrences As ComponentOccurrences
                    oComponentOccurrences = oAssemblyComponentDefinition.Occurrences

                    '指定要选择的文件()
                    'Dim oDoc As Document
                    'oDoc = ThisApplication.Documents.ItemByName(OldFullFileName)

                    '遍历
                    For Each oComponentOccurrence As ComponentOccurrence In oComponentOccurrences

                        If oComponentOccurrence.Name = strDisplayName Then
                            ThisApplication.CommandManager.DoSelect(oComponentOccurrence)
                        Else
                            ThisApplication.CommandManager.DoUnSelect(oComponentOccurrence)
                        End If

                    Next

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, xhtool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class