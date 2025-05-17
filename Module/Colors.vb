Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Inventor
Imports Inventor.DocumentTypeEnum

Module Colors

    ''' <summary>
    '''生成随机颜色 
    ''' </summary>
    ''' <param name="count">颜色数量</param>
    ''' <returns>返回颜色list</returns>

    Public Function GenerateDistinctColors(count As Integer) As List(Of Inventor.Color)
        Dim colors As New List(Of Inventor.Color)()
        Dim rand As New Random(DateTime.Now.Millisecond)  ' 使用时间作为随机种子

        For i As Integer = 1 To count
            ' 生成0-255之间的随机RGB分量
            Dim r As Integer = rand.Next(0, 256)
            Dim g As Integer = rand.Next(0, 256)
            Dim b As Integer = rand.Next(0, 256)

            ' 创建Inventor颜色对象
            Dim color As Inventor.Color = ThisApplication.TransientObjects.CreateColor(r, g, b)
            colors.Add(color)
        Next

        Return colors
    End Function

    ''' <summary>
    ''' 同直径孔着色
    ''' </summary>
    Public Sub SameDiameterHoleColoring()
        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        If ThisApplication.ActiveDocumentType <> kPartDocumentObject Then
            MessageBox.Show("该功能仅适用于零件。", XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        Dim oInventorPartDocument As Inventor.PartDocument
        oInventorPartDocument = CType(ThisApplication.ActiveDocument, PartDocument)

        Dim CompDef As PartComponentDefinition = oInventorPartDocument.ComponentDefinition


        Dim msg As DialogResult = MessageBox.Show("孔着色。" & vbCrLf & vbCrLf & "是——孔着色" & vbCrLf & vbCrLf & "否——清除着色", XHTool，
                                       MessageBoxButtons.YesNoCancel， MessageBoxIcon.Question)
        Select Case msg
            Case DialogResult.Yes
                '全部还原默认
                For Each oFace As Face In CompDef.SurfaceBodies.Item(1).Faces
                    If oFace.SurfaceType = SurfaceTypeEnum.kCylinderSurface Then
                        Try
                            oFace.Appearance = oInventorPartDocument.Assets.Item("默认")
                        Catch ex As Exception
                            oFace.Appearance = oInventorPartDocument.Assets.Item("Default")
                        End Try
                    End If
                Next

            Case DialogResult.No
                '全部还原默认
                For Each oFace As Face In CompDef.SurfaceBodies.Item(1).Faces
                    If oFace.SurfaceType = SurfaceTypeEnum.kCylinderSurface Then
                        Try
                            oFace.Appearance = oInventorPartDocument.Assets.Item("默认")
                        Catch ex As Exception
                            oFace.Appearance = oInventorPartDocument.Assets.Item("Default")
                        End Try
                    End If
                Next


                '删除新建的 孔颜色asset
                For Each oAsset As Asset In oInventorPartDocument.Assets
                    If Strings.InStr(oAsset.DisplayName, "HoleRGB") = 1 Then
                        Try
                            oAsset.Delete()
                        Catch ex As Exception

                        End Try
                    End If
                Next
                SetStatusBarText("清除零件孔着色完成。")

                Exit Sub
            Case DialogResult.Cancel
                Exit Sub
        End Select

        'ThisApplication.UserInterfaceManager.DoEvents()
        'Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        'OInteractionEvents.Start()
        'OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)

        '删除新建的 孔颜色asset
        For Each oAsset As Asset In oInventorPartDocument.Assets
            If Strings.InStr(oAsset.DisplayName, "HoleRGB") = 1 Then
                Try
                    oAsset.Delete()
                Catch ex As Exception

                End Try
            End If
        Next

        'Create a list for storing objects
        Dim oFacesList As New List(Of Face)

        'Create a highlight Set.
        'Dim Set1 As HighlightSet = oInventorPartDocument.CreateHighlightSet

        ' 定义存储不同半径的集合
        Dim uniqueRadii As New Dictionary(Of Double, Boolean)

        'Loop through all faces.
        For Each oFace As Face In CompDef.SurfaceBodies.Item(1).Faces

            'Set1.AddItem(oFace)

            If oFace.SurfaceType = SurfaceTypeEnum.kCylinderSurface Then

                Dim oCreatedByFeature = oFace.CreatedByFeature

                Select Case oCreatedByFeature.Type
                    Case ObjectTypeEnum.kExtrudeFeatureObject    '拉伸
                        Dim oExtrudeFeature As ExtrudeFeature = CType（oCreatedByFeature， ExtrudeFeature）

                        Select Case oExtrudeFeature.Operation
                            Case PartFeatureOperationEnum.kNewBodyOperation， PartFeatureOperationEnum.kJoinOperation
                                Continue For
                        End Select

                    Case ObjectTypeEnum.kFaceFeatureObject '平板
                        Dim oFaceFeature As FaceFeature = CType（oCreatedByFeature， FaceFeature）


                        Continue For


                    Case ObjectTypeEnum.kRevolveFeatureObject   '旋转
                        Dim oRevolveFeature As RevolveFeature = CType（oCreatedByFeature， RevolveFeature）

                        Select Case oRevolveFeature.Operation
                            Case PartFeatureOperationEnum.kNewBodyOperation， PartFeatureOperationEnum.kJoinOperation
                                Continue For
                        End Select

                        'Case ObjectTypeEnum.kRectangularPatternFeatureObject   '矩形阵列
                        '    Dim oRectangularPatternFeature As RectangularPatternFeature = CType（oCreatedByFeature， RectangularPatternFeature）

                        '    'MessageBox.Show（oRectangularPatternFeature.Name）

                        '    For Each oPatternElement As FeaturePatternElement In oRectangularPatternFeature.PatternElements

                        '        Select Case oPatternElement.Type
                        '            Case ObjectTypeEnum.kExtrudeFeatureObject    '拉伸
                        '                Dim oExtrudeFeature As ExtrudeFeature = CType（oPatternElement， ExtrudeFeature）

                        '                Select Case oExtrudeFeature.Operation
                        '                    Case PartFeatureOperationEnum.kNewBodyOperation， PartFeatureOperationEnum.kJoinOperation
                        '                        Continue For
                        '                End Select
                        '        End Select

                        '    Next
                        'Case ObjectTypeEnum.kCircularPatternFeatureObject   '环形阵列
                        '    Dim oCircularPatternFeature As CircularPatternFeature = CType（oCreatedByFeature， CircularPatternFeature）


                End Select

                For Each oedge As Edge In oFace.Edges
                    If FourFive(oedge.StartVertex.Point.X - oedge.StopVertex.Point.X, 4) = 0 And FourFive(oedge.StartVertex.Point.Y - oedge.StopVertex.Point.Y, 4) = 0 And FourFive(oedge.StartVertex.Point.Z - oedge.StopVertex.Point.Z, 4) = 0 Then
                        Try
                            Dim oCylinder As Cylinder = oFace.Geometry
                            Dim douRadius As Double = FourFive(oCylinder.Radius, 4)

                            'Set1.AddItem(oFace)

                            oFacesList.Add(oFace)

                            If Not uniqueRadii.ContainsKey(douRadius) Then
                                uniqueRadii.Add(FourFive(douRadius, 4), True)
                            End If

                            Exit For
                        Catch

                        End Try
                    End If
                Next

            End If
        Next

        ' 将半径排序以便颜色分配
        Dim sortedRadii As New List(Of Double)(uniqueRadii.Keys)
        sortedRadii.Sort()

        ' 预定义颜色列表
        Dim predefinedColors As List(Of Inventor.Color) = GenerateDistinctColors(sortedRadii.Count)

        ' 创建半径到颜色的映射
        Dim colorMap As New Dictionary(Of Double, Inventor.Color)
        For i As Integer = 0 To sortedRadii.Count - 1
            Dim radius As Double = sortedRadii(i)
            Dim colorIndex As Integer = i Mod predefinedColors.Count
            colorMap(radius) = predefinedColors(colorIndex)
        Next

        For Each oFace As Face In oFacesList
            Dim oCylinder As Cylinder = oFace.Geometry
            Dim douRadius As Double = FourFive(oCylinder.Radius, 4)

            If colorMap.ContainsKey(douRadius) Then

                '获取半径对应的颜色
                Dim oFaceColor As Color = colorMap(douRadius)

                Dim docAssets As Assets
                docAssets = oInventorPartDocument.Assets

                Dim oAsset As Asset
                Dim strAssetName As String = "HoleRGB" & Strings.Format(oFaceColor.Red, "000") &
                Strings.Format(oFaceColor.Green, "000") & Strings.Format(oFaceColor.Blue, "000")

                Try
                    oAsset = oInventorPartDocument.Assets(strAssetName)
                Catch
                    oAsset = oInventorPartDocument.Assets.Add(AssetTypeEnum.kAssetTypeAppearance, "Metal", strAssetName, strAssetName)     'Generic

                    Dim BooleanAssetValue As BooleanAssetValue = oAsset.Item("common_Tint_toggle")
                    BooleanAssetValue.Value = True

                    Dim oColor As ColorAssetValue = oAsset.Item("common_Tint_color")
                    oColor.Value = oFaceColor

                End Try

                If Strings.InStr(oFace.Appearance.DisplayName, "HoleRGB"） = 0 Then
                    oFace.Appearance = oAsset
                End If

            End If

        Next

        ' 刷新视图以显示颜色更改
        ThisApplication.ActiveView.Update()

        'OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        'OInteractionEvents.Stop()

        'MessageBox.Show("零件孔着色完成。"， XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information)

        SetStatusBarText("零件孔着色完成。")

    End Sub

    ''' <summary>
    ''' 油路块孔着色
    ''' </summary>
    'Public Sub OilBlockHoleColoring（）
    '    If IsInventorOpenDocument() = False Then
    '        Exit Sub
    '    End If

    '    If ThisApplication.ActiveDocumentType <> kPartDocumentObject Then
    '        MessageBox.Show("该功能仅适用于零件。", XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Exit Sub
    '    End If

    '    Dim oInventorPartDocument As Inventor.PartDocument
    '    oInventorPartDocument = CType(ThisApplication.ActiveDocument, PartDocument)

    '    Dim CompDef As PartComponentDefinition = oInventorPartDocument.ComponentDefinition

    '    Dim oSelectFace As Face = Nothing

    '    If oInventorPartDocument.SelectSet.Count <> 0 Then
    '        For Each oSelect As Object In oInventorPartDocument.SelectSet
    '            If oSelect.Type = ObjectTypeEnum.kFaceObject Then
    '                oSelectFace = CType(oSelect, Face)
    '                Exit For
    '            End If
    '        Next
    '    End If

    '    Dim msg As DialogResult = MessageBox.Show("油路块孔着色。" & vbCrLf & vbCrLf & "是——油路块孔着色" & vbCrLf & vbCrLf & "否——清除着色", XHTool，
    '                                   MessageBoxButtons.YesNoCancel， MessageBoxIcon.Question)

    '    ' 是否已经选择了face
    '    If oSelectFace Is Nothing Then
    '        oSelectFace = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kPartFaceFilter, "选择着色的面，ESC键取消")
    '        If oSelectFace Is Nothing Then       '取消选择
    '            Exit Sub
    '        End If
    '    End If

    '    Dim oPartFeature As PartFeature = oSelectFace.CreatedByFeature
    '    ''MessageBox.Show(oPartFeature.Name)

    '    Dim oPartFeatureList As New List(Of PartFeature)
    '    Dim oUnAddFeatureNameList As New List(Of String)

    '    oUnAddFeatureNameList.Add("拉伸1")


    '    ThisApplication.UserInterfaceManager.DoEvents()
    '    Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
    '    OInteractionEvents.Start()
    '    OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)

    '    '获取
    '    oPartFeatureList = GetUseFaceFeature（oPartFeature， oPartFeatureList， oUnAddFeatureNameList）

    '    OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeDefault)
    '    OInteractionEvents.Stop()


    '    Debug.Print("---------------------------")
    '    For Each oo In oPartFeatureList
    '        Debug.Print(oo.Name)
    '    Next


    '    Dim oAsset As Asset = Nothing

    '    Select Case msg
    '        Case DialogResult.Yes
    '            oAsset = oInventorPartDocument.Assets.Item("紫罗兰色")
    '        Case DialogResult.No
    '            Try
    '                oAsset = oInventorPartDocument.Assets.Item("默认")
    '            Catch ex As Exception
    '                oAsset = oInventorPartDocument.Assets.Item("Default")
    '            End Try

    '        Case DialogResult.Cancel
    '            Exit Sub
    '    End Select

    '    '将特征集合设置颜色
    '    SetFeatureColor(oPartFeatureList, oAsset)

    'End Sub

    ''' <summary>
    ''' 获取与给定的特征相邻的特征列表
    ''' </summary>
    ''' <param name="oPartFeature">给定的特征</param>
    ''' <param name="oPartFeatureList">已添加的特征列表</param>
    ''' <param name="oUnAddFeatureNameList">忽略的特征列表</param>
    ''' <returns></returns>
    Public Function GetUseFaceFeature(ByVal oPartFeature As PartFeature， ByVal oPartFeatureList As List(Of PartFeature),
                                       ByVal oUnAddFeatureNameList As List(Of String)) As List(Of PartFeature)

        Dim oPartFeatureListCount = oPartFeatureList.Count

        For Each oFace As Face In oPartFeature.Faces
            For Each oEdge As Edge In oFace.Edges
                For Each oUseFace As Face In oEdge.Faces

                    Dim oUseFeature As PartFeature = oUseFace.CreatedByFeature

                    Debug.Print(oUseFeature.Name)

                    If oUnAddFeatureNameList.Contains(oUseFeature.Name) = False And oPartFeatureList.Contains(oUseFeature） = False Then
                        oPartFeatureList.Add(oUseFeature)
                        oPartFeatureList = GetUseFaceFeature(oUseFeature, oPartFeatureList, oUnAddFeatureNameList)
                    End If

                Next
            Next

        Next

        Return oPartFeatureList
    End Function

    ''' <summary>
    ''' 设置特征面外观
    ''' </summary>
    ''' <param name="oPartFeatureList">特征对象list</param>
    ''' <param name="oColorAsset">外观</param>
    Public Sub SetFeatureColor(ByVal oPartFeatureList As List(Of PartFeature), ByVal oColorAsset As Asset)
        Try
            For Each oPartFeature As PartFeature In oPartFeatureList
                For Each oFace As Face In oPartFeature.Faces
                    oFace.Appearance = oColorAsset
                Next
            Next

        Catch ex As Exception

        End Try

    End Sub


End Module
