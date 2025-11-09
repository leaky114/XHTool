Imports Inventor
Imports Inventor.DocumentTypeEnum
Imports Inventor.SelectionFilterEnum
Imports Inventor.SelectTypeEnum
Imports System.Collections.Generic
Imports System.Windows.Forms

Public Class FormStatistical

    Private dblSumMass As Double
    Private dblSumArea As Double
    Private dblSumLength As Double
    Private dblSumHanFengLength As Double

    Private dou长度系数 As Double

    Private oMassList As List(Of ComponentOccurrence)
    Private oEdgeList As List(Of Edge)

    Private oAreaList As List(Of Face)

    Private oEdgeHSet100 As HighlightSet
    Private oEdgeHSet70 As HighlightSet
    Private oEdgeHSet50 As HighlightSet
    Private oEdgeHSet30 As HighlightSet

    Private oFaceHSet As HighlightSet
    Private oComponentOccurrenceHSet As HighlightSet

    Private strFullDocumentName As String

    Private Sub FrmStatisticalWeight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48
        Me.TopMost = True

        Dim toolTip As New ToolTip With {
            .AutoPopDelay = 0,
            .InitialDelay = 0,
            .ReshowDelay = 500
        }

        toolTip.SetToolTip(btn选择零件, "选择添加零件")
        toolTip.SetToolTip(btn添加零部件, "添加已选择的零部件")
        toolTip.SetToolTip(btn复制质量, "复制质量")

        toolTip.SetToolTip(btn选择面和边, "选择添加面和边")
        toolTip.SetToolTip(btn复制长度, "复制长度")
        toolTip.SetToolTip(btn复制焊缝长度, "复制焊缝长度")

        toolTip.SetToolTip(btn选择面, "选择添加面")
        toolTip.SetToolTip(btn选择零部件2, "选择添加零件")

        toolTip.SetToolTip(btn复制面积, "复制面积")

        btn选择零件.Image = My.Resources.选择面和边16.ToBitmap
        btn添加零部件.Image = My.Resources.添加16.ToBitmap
        btn复制质量.Image = My.Resources.复制16.ToBitmap

        btn选择面和边.Image = My.Resources.选择面和边16.ToBitmap
        btn复制长度.Image = My.Resources.复制16.ToBitmap
        btn复制焊缝长度.Image = My.Resources.复制16.ToBitmap

        btn选择面.Image = My.Resources.选择面和边16.ToBitmap
        btn选择零部件2.Image = My.Resources.添加16.ToBitmap
        btn复制面积.Image = My.Resources.复制16.ToBitmap


        RadioButton10.Checked = True
        dou长度系数 = 1
        '============================================================================================
        '选择切换到 选择面和边
        'ThisApplication.UserInterfaceManager.Ribbons("Assembly").QuickAccessControls.Item("ID_QAT_Assembly_Select").ChildControls.Item("PartSelectFacesAndEdgePriorityCmd").ControlDefinition.Execute()

        txt总质量.Text = "0"
        txt面积.Text = "0"
        txt长度.Text = "0"
        txt焊缝长度.Text = "0"

        dblSumMass = 0
        dblSumLength = 0
        dblSumHanFengLength = 0
        dblSumArea = 0

        strFullDocumentName = ThisApplication.ActiveDocument.File.FullFileName

        oEdgeHSet100 = ThisApplication.ActiveDocument.CreateHighlightSet()
        oEdgeHSet100.Color = ThisApplication.TransientObjects.CreateColor(255, 0, 0)

        oEdgeHSet70 = ThisApplication.ActiveDocument.CreateHighlightSet()
        oEdgeHSet70.Color = ThisApplication.TransientObjects.CreateColor(255， 165， 0)

        oEdgeHSet50 = ThisApplication.ActiveDocument.CreateHighlightSet()
        oEdgeHSet50.Color = ThisApplication.TransientObjects.CreateColor(255， 0， 255)

        oEdgeHSet30 = ThisApplication.ActiveDocument.CreateHighlightSet()
        oEdgeHSet30.Color = ThisApplication.TransientObjects.CreateColor(0， 255， 255)

        oFaceHSet = ThisApplication.ActiveDocument.CreateHighlightSet()
        oFaceHSet.Color = ThisApplication.TransientObjects.CreateColor(46, 139, 87)

        oComponentOccurrenceHSet = ThisApplication.ActiveDocument.CreateHighlightSet()
        oComponentOccurrenceHSet.Color = ThisApplication.TransientObjects.CreateColor(0, 191, 255)

    End Sub

    '移出
    Private Sub Btn移出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn移出.Click, tsmi移出.Click
        Select Case TabControl1.SelectedTab.Text
            Case "质量"
                ListViewDel(lvw质量文件列表)
                Dim dblSumMass As Double = 0
                Dim dblSumArea As Double = 0

                For Each oListViewItem As ListViewItem In lvw质量文件列表.Items
                    dblSumMass = dblSumMass + oListViewItem.SubItems(1).Text
                    'dblSumArea = dblSumArea + oListViewItem.SubItems(3).Text
                Next

                txt总质量.Text = dblSumMass.ToString
                'txt面积.Text = dblSumArea

            Case "边长(焊缝)"

                ListViewDel(lvw焊缝文件列表)

                dblSumLength = 0
                dblSumHanFengLength = 0

                For Each LVI As ListViewItem In lvw焊缝文件列表.Items
                    dblSumLength = dblSumLength + Val(LVI.SubItems(1).Text)
                    dblSumHanFengLength = dblSumHanFengLength + Val(LVI.SubItems(3).Text)
                Next

                txt长度.Text = dblSumLength.ToString
                txt焊缝长度.Text = dblSumHanFengLength.ToString

            Case "面积"
                ListViewDel(lvw面积文件列表)
                dblSumArea = 0

                For Each LVI As ListViewItem In lvw面积文件列表.Items
                    dblSumArea = dblSumArea + Val(LVI.SubItems(1).Text)

                Next

                txt面积.Text = dblSumArea.ToString
        End Select


    End Sub

    '清空
    Private Sub Btn清空_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn清空.Click, tsmi清空.Click
        Select Case TabControl1.SelectedTab.Text
            Case "质量"
                lvw质量文件列表.Items.Clear()
                dblSumMass = 0
                txt总质量.Text = 0

            Case "边长(焊缝)"
                lvw焊缝文件列表.Items.Clear()
                dblSumLength = 0
                dblSumHanFengLength = 0
                txt长度.Text = 0
                txt焊缝长度.Text = 0

                oFaceHSet.Clear()
            Case "面积"
                lvw面积文件列表.Items.Clear()
                dblSumArea = 0
                txt面积.Text = 0

        End Select

        oEdgeHSet100.Clear()
        oEdgeHSet70.Clear()
        oEdgeHSet50.Clear()
        oEdgeHSet30.Clear()
        oFaceHSet.Clear()
        oComponentOccurrenceHSet.Clear

    End Sub

    '退出
    Private Sub Btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click, Me.Closing
        Btn清空_Click（sender, e)
        FormManager.CloseAndDisposeForm(Of FormStatistical)()
    End Sub

    '复制总质量到剪贴板
    Private Sub Btn复制质量_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn复制质量.Click
        My.Computer.Clipboard.SetText(txt总质量.Text)
    End Sub

    '复制总面积到剪贴板
    Private Sub Btn复制面积_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.Computer.Clipboard.SetText(txt面积.Text)
    End Sub

    '复制焊缝长度到剪贴板
    Private Sub Btn复制焊缝长度_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn复制焊缝长度.Click
        My.Computer.Clipboard.SetText(txt焊缝长度.Text)
    End Sub

    '复制长度到剪贴板
    Private Sub btn复制长度_Click(sender As Object, e As EventArgs) Handles btn复制长度.Click
        My.Computer.Clipboard.SetText(txt长度.Text)
    End Sub


    '质量面积选择零件
    Private Sub Btn选择零件_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn选择零件.Click
        Try
            If ThisApplication.ActiveDocument.File.FullFileName <> strFullDocumentName Then
                oFaceHSet = ThisApplication.ActiveDocument.CreateHighlightSet()
                strFullDocumentName = ThisApplication.ActiveDocument.File.FullFileName
                Btn清空_Click(sender, e)
            End If
        Catch ex As Exception

        End Try

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

                Dim dblMass As Double
                dblMass = FourFive(oComponentOccurrence.MassProperties.Mass, Mass_Accuracy)

                oListViewItem.SubItems.Add(dblMass * intQuantity)

                dblSumMass = 0

                oComponentOccurrenceHSet.AddItem(oComponentOccurrence)

                For Each LVI As ListViewItem In lvw质量文件列表.Items
                    dblSumMass = dblSumMass + LVI.SubItems(1).Text    ' * LVI.SubItems(1).Text
                Next

                txt总质量.Text = dblSumMass.ToString

            Loop While True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btn选择面和边_Click(sender As Object, e As EventArgs) Handles btn选择面和边.Click
        Try
            If ThisApplication.ActiveDocument.File.FullFileName <> strFullDocumentName Then
                oFaceHSet = ThisApplication.ActiveDocument.CreateHighlightSet()
                strFullDocumentName = ThisApplication.ActiveDocument.File.FullFileName
                Btn清空_Click(sender, e)
            End If
        Catch ex As Exception

        End Try


        If ThisApplication.ActiveDocumentType = DocumentTypeEnum.kAssemblyDocumentObject Then

            Try
                Dim oedge As Edge
                Do
                    oedge = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kPartEdgeFilter, "选择一条边，ESC键取消")

                    Select Case dou长度系数
                        Case 1
                            If IsInSelectObject(oEdgeHSet100, oedge) = True Then
                                Continue Do
                            Else
                                oEdgeHSet100.AddItem(oedge)
                            End If
                        Case 0.7
                            If IsInSelectObject(oEdgeHSet70, oedge) = True Then
                                Continue Do
                            Else
                                oEdgeHSet70.AddItem(oedge)
                            End If
                        Case 0.5
                            If IsInSelectObject(oEdgeHSet50, oedge) = True Then
                                Continue Do
                            Else
                                oEdgeHSet50.AddItem(oedge)
                            End If
                        Case 0.3
                            If IsInSelectObject(oEdgeHSet30, oedge) = True Then
                                Continue Do
                            Else
                                oEdgeHSet30.AddItem(oedge)
                            End If
                    End Select

                    Dim oListViewItem As ListViewItem

                    Dim oEval As CurveEvaluator = oedge.Evaluator
                    Dim oMin, oMax, oLength As Double
                    oEval.GetParamExtents(oMin, oMax)
                    oEval.GetLengthAtParam(oMin, oMax, oLength)

                    'Dim UoM As UnitsOfMeasure = ThisApplication.ActiveDocument.UnitsOfMeasure
                    ' MessageBox.Show(UoM.GetStringFromValue(oLength, UoM.LengthUnits))

                    'Dim dou边长度 = UoM.GetStringFromValue(FourFive(oLength, Mass_Accuracy), UoM.LengthUnits)
                    Dim dou边长度 As Double = FourFive(oLength * 10, Mass_Accuracy)
                    Dim dou焊缝长度 As Double = FourFive(dou边长度 * dou长度系数, Mass_Accuracy）

                    Dim oSurfaceBodyProxy As SurfaceBodyProxy
                    oSurfaceBodyProxy = oedge.Parent

                    Dim oComponentOccurrence As ComponentOccurrence
                    oComponentOccurrence = oSurfaceBodyProxy.Parent

                    Dim strListViewItem As String = oComponentOccurrence.Name

                    oListViewItem = lvw焊缝文件列表.Items.Add(strListViewItem)
                    oListViewItem.SubItems.Add(dou边长度.ToString)
                    oListViewItem.SubItems.Add(dou长度系数.ToString)
                    oListViewItem.SubItems.Add(dou焊缝长度.ToString)

                    dblSumLength = 0
                    dblSumHanFengLength = 0

                    For Each LVI As ListViewItem In lvw焊缝文件列表.Items
                        dblSumLength = dblSumLength + Val(LVI.SubItems(1).Text)
                        dblSumHanFengLength = dblSumHanFengLength + Val(LVI.SubItems(3).Text)
                    Next

                    txt长度.Text = dblSumLength.ToString
                    txt焊缝长度.Text = dblSumHanFengLength.ToString

                Loop While True

            Catch ex As Exception

            End Try

        ElseIf ThisApplication.ActiveDocumentType = DocumentTypeEnum.kPartDocumentObject Then
            Try
                Dim oedge As Edge
                Do
                    oedge = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kPartEdgeFilter, "选择一条边，ESC键取消")

                    Select Case dou长度系数
                        Case 1
                            If IsInSelectObject(oEdgeHSet100, oedge) = True Then
                                Continue Do
                            Else
                                oEdgeHSet100.AddItem(oedge)
                            End If
                        Case 0.7
                            If IsInSelectObject(oEdgeHSet70, oedge) = True Then
                                Continue Do
                            Else
                                oEdgeHSet70.AddItem(oedge)
                            End If
                        Case 0.5
                            If IsInSelectObject(oEdgeHSet50, oedge) = True Then
                                Continue Do
                            Else
                                oEdgeHSet50.AddItem(oedge)
                            End If
                        Case 0.3
                            If IsInSelectObject(oEdgeHSet30, oedge) = True Then
                                Continue Do
                            Else
                                oEdgeHSet30.AddItem(oedge)
                            End If
                    End Select

                    Dim oListViewItem As ListViewItem

                    Dim oEval As CurveEvaluator = oedge.Evaluator
                    Dim oMin, oMax, oLength As Double
                    oEval.GetParamExtents(oMin, oMax)
                    oEval.GetLengthAtParam(oMin, oMax, oLength)

                    'Dim UoM As UnitsOfMeasure = ThisApplication.ActiveDocument.UnitsOfMeasure
                    ' MessageBox.Show(UoM.GetStringFromValue(oLength, UoM.LengthUnits))

                    Dim dou边长度 As Double = FourFive(oLength * 10, Mass_Accuracy)     ' UoM.GetStringFromValue(oLength, UoM.LengthUnits)
                    Dim dou焊缝长度 As Double = FourFive(dou边长度 * dou长度系数, Mass_Accuracy）

                    'Dim oSurfaceBodyProxy As SurfaceBodyProxy
                    'oSurfaceBodyProxy = oedge.Parent

                    'Dim oComponentOccurrence As ComponentOccurrence
                    'oComponentOccurrence = oSurfaceBodyProxy.Parent

                    Dim strListViewItem As String = oedge.Parent.CreatedByFeature.Name

                    oListViewItem = lvw焊缝文件列表.Items.Add(strListViewItem)
                    oListViewItem.SubItems.Add(dou边长度.ToString)
                    oListViewItem.SubItems.Add(dou长度系数.ToString)
                    oListViewItem.SubItems.Add(dou焊缝长度.ToString)

                    dblSumLength = 0
                    dblSumHanFengLength = 0

                    For Each LVI As ListViewItem In lvw焊缝文件列表.Items
                        dblSumLength = dblSumLength + Val(LVI.SubItems(1).Text)
                        dblSumHanFengLength = dblSumHanFengLength + Val(LVI.SubItems(3).Text)
                    Next

                    txt长度.Text = dblSumLength.ToString
                    txt焊缝长度.Text = dblSumHanFengLength.ToString

                Loop While True

            Catch ex As Exception

            End Try


        End If

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
            If oInventorDocument.File.FullFileName <> strFullDocumentName Then
                oFaceHSet = oInventorDocument.CreateHighlightSet()
                strFullDocumentName = oInventorDocument.File.FullFileName
                Btn清空_Click(sender, e)
            End If
        Catch ex As Exception

        End Try

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
                        'douArea = oComponentOccurrence.MassProperties.Area / 10000
                        intQuantity = 1

                        AddOccurrenceToListView(lvw质量文件列表, strName, intQuantity, douMass, douArea)

                    Case ObjectTypeEnum.kRectangularOccurrencePatternObject       '矩形阵列
                        ' MessageBox.Show(ObjectTypeEnum.kRectangularOccurrencePatternObject)


                        oRectangularOccurrencePattern = CType(oSelectObject, RectangularOccurrencePattern)
                        intQuantity = oRectangularOccurrencePattern.ColumnCount.Value * oRectangularOccurrencePattern.RowCount.Value

                        For Each OccurrencePatternElementObject As OccurrencePatternElement In oRectangularOccurrencePattern.OccurrencePatternElements
                            strName = OccurrencePatternElementObject.Occurrences.Item(1).Name
                            douMass = OccurrencePatternElementObject.Occurrences.Item(1).MassProperties.Mass
                            'douArea = OccurrencePatternElementObject.Occurrences.Item(1).MassProperties.Area / 10000
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
                            'douArea = OccurrencePatternElementObject.Occurrences.Item(1).MassProperties.Area / 10000
                            intQuantity = 1
                            AddOccurrenceToListView(lvw质量文件列表, strName, intQuantity, douMass, douArea)
                        Next

                End Select


            Next

        Catch

        End Try

        dblSumMass = 0
        'dblSumArea = 0


        For Each LVI As ListViewItem In lvw质量文件列表.Items
            dblSumMass = dblSumMass + LVI.SubItems(1).Text
            'dblSumArea = dblSumArea + LVI.SubItems(3).Text
        Next

        txt总质量.Text = dblSumMass.ToString
        'txt面积.Text = dblSumArea.ToString

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
    Private Sub AddOccurrenceToListView(ByVal oListView As ListView, ByVal strFileName As String, ByVal intQuantity As Integer,
                                        ByVal douMass As Double, douArea As Double)
        Dim oListViewItem As ListViewItem
        'LVI = ListView1.Items.Add(FNI.ONlyName)

        If IsItemInListView(oListView, strFileName) = True Then
            Exit Sub
        End If

        oListViewItem = oListView.Items.Add(strFileName)

        douMass = FourFive(douMass, Mass_Accuracy)
        oListViewItem.SubItems.Add(douMass * intQuantity)

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
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn选择面_Click(sender As Object, e As EventArgs) Handles btn选择面.Click
        Try
            If ThisApplication.ActiveDocument.File.FullFileName <> strFullDocumentName Then
                oFaceHSet = ThisApplication.ActiveDocument.CreateHighlightSet()
                strFullDocumentName = ThisApplication.ActiveDocument.File.FullFileName
                Btn清空_Click(sender, e)
            End If
        Catch ex As Exception

        End Try

        Try
            Do
                If ThisApplication.ActiveDocumentType = DocumentTypeEnum.kAssemblyDocumentObject Then
                    Dim oFaceProxy As FaceProxy
                    oFaceProxy = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kPartFaceFilter, "选择一个面，ESC键取消")

                    If IsInSelectObject(oFaceHSet, oFaceProxy) = True Then
                        Continue Do
                    End If


                    'Dim UoM As UnitsOfMeasure = ThisApplication.ActiveDocument.UnitsOfMeasure
                    ' MessageBox.Show(UoM.GetStringFromValue(oLength, UoM.LengthUnits))

                    'Dim strFaceArea As String = UoM.GetStringFromValue(FourFive(oFaceProxy.Evaluator.Area, Mass_Accuracy), UoM.LengthUnits)

                    Dim strFaceArea As String = FourFive(oFaceProxy.Evaluator.Area * 100, Area_Accuracy)

                    Dim oSurfaceBodyProxy As SurfaceBodyProxy
                    oSurfaceBodyProxy = oFaceProxy.Parent

                    Dim oComponentOccurrence As ComponentOccurrence
                    oComponentOccurrence = oSurfaceBodyProxy.Parent

                    Dim oListViewItem As ListViewItem

                    oListViewItem = lvw面积文件列表.Items.Add(oComponentOccurrence.Name)
                    oListViewItem.SubItems.Add(strFaceArea)

                    oFaceHSet.AddItem(oFaceProxy)

                    dblSumArea = 0
                    For Each LVI As ListViewItem In lvw面积文件列表.Items
                        dblSumArea = dblSumArea + Val(LVI.SubItems(1).Text)
                    Next
                    txt面积.Text = dblSumArea.ToString

                ElseIf ThisApplication.ActiveDocumentType = DocumentTypeEnum.kPartDocumentObject Then

                    Dim oFace As Face
                    oFace = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kPartFaceFilter, "选择一个面，ESC键取消")

                    If IsInSelectObject(oFaceHSet, oFace) = True Then
                        Continue Do
                    End If

                    'Dim UoM As UnitsOfMeasure = ThisApplication.ActiveDocument.UnitsOfMeasure
                    ' MessageBox.Show(UoM.GetStringFromValue(oLength, UoM.LengthUnits))

                    'Dim strFaceArea As String = UoM.GetStringFromValue(FourFive(oFace.Evaluator.Area, Mass_Accuracy), UoM.LengthUnits)

                    Dim strFaceArea As String = FourFive(oFace.Evaluator.Area, Area_Accuracy)

                    Dim oListViewItem As ListViewItem
                    oListViewItem = lvw面积文件列表.Items.Add(oFace.CreatedByFeature.Name.ToString)
                    oListViewItem.SubItems.Add(strFaceArea.ToString)

                    oFaceHSet.AddItem(oFace)
                End If

                dblSumArea = 0
                For Each LVI As ListViewItem In lvw面积文件列表.Items
                    dblSumArea = dblSumArea + Val(LVI.SubItems(1).Text)
                Next

                txt面积.Text = ConvertArea(dblSumArea)


            Loop While True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Try
            If oFaceHSet.Count <> 0 Then
                oFaceHSet.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn选择零部件2_Click(sender As Object, e As EventArgs) Handles btn选择零部件2.Click
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        If oInventorDocument.SelectSet.Count = 0 Then
            Exit Sub
        End If

        Debug.Print(oInventorDocument.SelectSet.Item(1).Type)

        Try
            If oInventorDocument.File.FullFileName <> strFullDocumentName Then
                oFaceHSet = oInventorDocument.CreateHighlightSet()
                strFullDocumentName = oInventorDocument.File.FullFileName
                Btn清空_Click(sender, e)
            End If
        Catch ex As Exception

        End Try

        Dim oListViewItem As ListViewItem = Nothing
        Dim dblArea As Double
        Dim intQuantity As Integer = 1

        Try
            Dim oComponentOccurrence As ComponentOccurrence = Nothing
            Dim oRectangularOccurrencePattern As RectangularOccurrencePattern
            Dim oCircularOccurrencePattern As CircularOccurrencePattern

            For Each oSelectObject In oInventorDocument.SelectSet

                Debug.Print(oSelectObject.type)



                Select Case oSelectObject.Type

                    Case ObjectTypeEnum.kComponentOccurrenceObject          '组件
                        ' MessageBox.Show(ObjectTypeEnum.kComponentOccurrenceObject)
                        oComponentOccurrence = CType(oSelectObject, ComponentOccurrence)

                        If IsItemInListView(lvw面积文件列表, oComponentOccurrence.Name) Then
                            Continue For
                        End If

                        oListViewItem = lvw面积文件列表.Items.Add(oComponentOccurrence.Name)

                        dblArea = FourFive(oComponentOccurrence.MassProperties.Area * 100, Mass_Accuracy)
                        oListViewItem.SubItems.Add(dblArea * intQuantity)
                        oComponentOccurrenceHSet.AddItem(oComponentOccurrence)


                    Case ObjectTypeEnum.kRectangularOccurrencePatternObject       '矩形阵列
                        ' MessageBox.Show(ObjectTypeEnum.kRectangularOccurrencePatternObject)


                        oRectangularOccurrencePattern = CType(oSelectObject, RectangularOccurrencePattern)


                        For Each OccurrencePatternElementObject As OccurrencePatternElement In oRectangularOccurrencePattern.OccurrencePatternElements


                            oListViewItem = lvw面积文件列表.Items.Add(OccurrencePatternElementObject.Occurrences.Item(1).Name )

                            dblArea = FourFive(OccurrencePatternElementObject.Occurrences.Item(1).MassProperties.Area * 100, Mass_Accuracy)
                            oListViewItem.SubItems.Add(dblArea * intQuantity)
                            oComponentOccurrenceHSet.AddItem(oComponentOccurrence)


                        Next

                    Case ObjectTypeEnum.kCircularOccurrencePatternObject     '环形阵列
                        ' MessageBox.Show(ObjectTypeEnum.kRectangularOccurrencePatternObject)


                        oCircularOccurrencePattern = CType(oSelectObject, CircularOccurrencePattern)

                        'intQuantity = oCircularOccurrencePattern.ElementCount.Value

                        For Each OccurrencePatternElementObject As OccurrencePatternElement In oCircularOccurrencePattern.OccurrencePatternElements

                            oListViewItem = lvw面积文件列表.Items.Add(OccurrencePatternElementObject.Occurrences.Item(1).Name)

                            dblArea = FourFive(OccurrencePatternElementObject.Occurrences.Item(1).MassProperties.Area * 100, Mass_Accuracy)
                            oListViewItem.SubItems.Add(dblArea * intQuantity)
                            oComponentOccurrenceHSet.AddItem(oComponentOccurrence)

                        Next

                End Select


            Next

            dblSumArea = 0
            For Each LVI As ListViewItem In lvw面积文件列表.Items
                dblSumArea = dblSumArea + Val(LVI.SubItems(1).Text)
            Next

            txt面积.Text = ConvertArea(dblSumArea)


            Exit Sub
        Catch ex As Exception

        End Try

        '没有已选择的组件就鼠标选择
        Try
            Dim oComponentOccurrence As ComponentOccurrence

            Do
                oComponentOccurrence = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kAssemblyLeafOccurrenceFilter, "选择一个零件，ESC键取消")

                'LVI = ListView1.Items.Add(FNI.ONlyName)

                If IsItemInListView(lvw面积文件列表, oComponentOccurrence.Name) Then
                    Continue Do
                End If

                oListViewItem = lvw面积文件列表.Items.Add(oComponentOccurrence.Name)


                Dim oInventorPartDocument As Inventor.PartDocument
                oInventorPartDocument = oComponentOccurrence.Definition.Document

                dblArea = FourFive(oInventorPartDocument.ComponentDefinition.MassProperties.Area * 100, Mass_Accuracy)

                oListViewItem.SubItems.Add(dblArea * intQuantity)

                oComponentOccurrenceHSet.AddItem(oComponentOccurrence)

                dblSumArea = 0
                For Each LVI As ListViewItem In lvw面积文件列表.Items
                    dblSumArea = dblSumArea + Val(LVI.SubItems(1).Text)
                Next

                txt面积.Text = ConvertArea(dblSumArea)

            Loop While True

        Catch ex As Exception

        End Try
    End Sub


    ''' <summary>
    ''' 根据数字大小自动决定转换的单位：
    ''' </summary>
    ''' <param name="areaInMM2">面积，单位平方毫米</param>
    ''' <returns></returns>
    Private Function ConvertArea(ByVal areaInMM2 As Double) As String
        Dim douArea As Double
        Dim strUnit As String

        If areaInMM2 < 1 Then
            douArea = areaInMM2
            strUnit = "mm²"
        ElseIf areaInMM2 < 10000 Then
            douArea = FourFive(areaInMM2 / 100, Area_Accuracy) ' 转换为 cm²
            strUnit = "cm²"
        ElseIf areaInMM2 < 1000000 Then
            douArea = FourFive(areaInMM2 / 10000, Area_Accuracy) ' 转换为 dm²
            strUnit = "dm²"
        Else
            douArea = FourFive(areaInMM2 / 1000000, Area_Accuracy) ' 转换为 m²
            strUnit = "m²"
        End If

        Return String.Format("{0} {1}", douArea, strUnit)
    End Function

    ''' <summary>
    ''' 检查对选是否已选择
    ''' </summary>
    ''' <param name="oCheckObjectList">已选择列表</param>
    ''' <param name="oCheckObject">被检查对象</param>
    ''' <returns></returns>
    Private Function IsInSelectObject(ByVal oCheckObjectList As Object, ByVal oCheckObject As Object) As Boolean
        For Each oObject As Object In oCheckObjectList
            If oObject Is oCheckObject Then
                Return True
            End If
        Next
        Return False
    End Function

End Class