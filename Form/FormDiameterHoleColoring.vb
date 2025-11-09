
Imports System.Collections.Generic
Imports System.IO
Imports System.Text
Imports Inventor
Imports Microsoft.VisualBasic

Public Class FormDiameterHoleColoring

    Private Sub ColorLabel_Click(sender As Object, e As EventArgs) Handles _
        displayLbl3.Click, displayLbl4.Click, displayLbl5.Click,
        displayLbl6.Click, displayLbl8.Click, displayLbl10.Click,
        displayLbl12.Click, displayLbl14.Click, displayLbl16.Click


        Dim clickedLabel As Label = DirectCast(sender, Label)
        Using ocolorDialog As New System.Windows.Forms.ColorDialog()
            ocolorDialog.Color = clickedLabel.BackColor
            ocolorDialog.FullOpen = True

            If ocolorDialog.ShowDialog() = DialogResult.OK Then
                clickedLabel.BackColor = ocolorDialog.Color
                clickedLabel.Text = ColorToHex(ocolorDialog.Color)

                ini.WriteStrINI("自定义孔颜色"， "D" & Strings.Replace(clickedLabel.Name, "displayLbl", "")， clickedLabel.Text, IniFile)

            End If
        End Using

    End Sub

    Private Sub btn随机颜色_Click(sender As Object, e As EventArgs) Handles btn随机颜色.Click

        Dim oInventorPartDocument As Inventor.PartDocument
        oInventorPartDocument = CType(ThisApplication.ActiveDocument, Inventor.PartDocument)

        Dim CompDef As PartComponentDefinition = oInventorPartDocument.ComponentDefinition

        ThisApplication.UserInterfaceManager.DoEvents()
        Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        OInteractionEvents.Start()
        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)

        ClearColor(oInventorPartDocument)


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

        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        OInteractionEvents.Stop()

        'MessageBox.Show("零件孔着色完成。"， XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information)

        SetStatusBarText("零件孔着色完成。")



    End Sub

    Private Sub btn自定义颜色_Click(sender As Object, e As EventArgs) Handles btn自定义颜色.Click
        Dim oInventorPartDocument As Inventor.PartDocument
        oInventorPartDocument = CType(ThisApplication.ActiveDocument, Inventor.PartDocument)

        Dim CompDef As PartComponentDefinition = oInventorPartDocument.ComponentDefinition

        ThisApplication.UserInterfaceManager.DoEvents()
        Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        OInteractionEvents.Start()
        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)

        ClearColor(oInventorPartDocument)

        For Each lbl As Label In Me.Controls.OfType(Of Label)()
            ' 处理每个背景色 Label
            If Strings.Left(lbl.Name, 10) = "displayLbl" Then
                SetUserColorAssets(oInventorPartDocument, Strings.Replace(lbl.Name, “displayLbl”， “”), lbl.Text.ToString)
            End If
        Next

        Dim Set1 As HighlightSet = oInventorPartDocument.CreateHighlightSet

        Dim douDiameter As Double

        For Each oFace As Face In CompDef.SurfaceBodies.Item(1).Faces

            'Set1.AddItem(oFace)

            If oFace.SurfaceType = SurfaceTypeEnum.kCylinderSurface Then

                Dim oCreatedByFeature = oFace.CreatedByFeature


                Select Case oCreatedByFeature.Type
                    Case ObjectTypeEnum.kHoleFeatureObject   '孔
                        Dim oHoleFeature As HoleFeature = CType(oCreatedByFeature, HoleFeature)

                        Select Case oHoleFeature.HoleType

                            Case HoleTypeEnum.kCounterBoreHole

                            Case HoleTypeEnum.kCounterSinkHole

                            Case HoleTypeEnum.kDrilledHole

                                If oHoleFeature.HoleDiameter IsNot Nothing Then  '通孔
                                    douDiameter = FourFive(oHoleFeature.HoleDiameter.Value, 4) * 10
                                ElseIf oHoleFeature.TapInfo IsNot Nothing Then    '螺纹孔
                                    Dim oTappedInfo As HoleTapInfo
                                    oTappedInfo = oHoleFeature.TapInfo

                                    douDiameter = FourFive(oTappedInfo.NominalSize, 4)
                                End If

                            Case HoleTypeEnum.kSpotFaceHole

                        End Select


                        SetColorByRadius（oInventorPartDocument, oFace， douDiameter）
                            Continue For
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

                            douDiameter = FourFive(oCylinder.Radius, 4) * 20

                            'Set1.AddItem(oFace)

                            SetColorByRadius（oInventorPartDocument, oFace， douDiameter）

                            Exit For
                        Catch

                        End Try
                    End If
                Next

            End If

        Next

        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        OInteractionEvents.Stop()

    End Sub


    ''' <summary>
    ''' 按直径设置颜色
    ''' </summary>
    ''' <param name="oInventorPartDocument">零件对象</param>
    ''' <param name="oFace">面</param>
    ''' <param name="douDiameter">直径</param>

    Public Sub SetColorByRadius(ByVal oInventorPartDocument As PartDocument, ByVal oFace As Face, ByVal douDiameter As Double)


        Dim docAssets As Assets
        docAssets = oInventorPartDocument.Assets

        Dim oAsset As Asset

        Select Case douDiameter
            Case Is >= 20
                Exit Sub
            Case Is ＞=16
                douDiameter = 16
            Case Is ＞= 14
                douDiameter = 14
            Case Is ＞= 12
                douDiameter = 12
            Case Is ＞= 10
                douDiameter = 10
            Case Is ＞= 8
                douDiameter = 8
            Case Is ＞= 6
                douDiameter = 6
            Case Is >= 5
                douDiameter = 5
            Case Is ＞= 4
                douDiameter = 4
            Case Is ＞= 3
                douDiameter = 3
        End Select

        Dim strAssetName As String = $"直径{douDiameter}"

        Try
            oAsset = oInventorPartDocument.Assets(strAssetName)
            oFace.Appearance = oAsset
        Catch

        End Try

    End Sub

    Private Sub btn清除颜色_Click(sender As Object, e As EventArgs) Handles btn清除颜色.Click

        Dim oInventorPartDocument As Inventor.PartDocument
        oInventorPartDocument = CType(ThisApplication.ActiveDocument, Inventor.PartDocument)

        ThisApplication.UserInterfaceManager.DoEvents()
        Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        OInteractionEvents.Start()
        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)

        ClearColor(oInventorPartDocument)

        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        OInteractionEvents.Stop()

        SetStatusBarText("清除零件孔着色完成。")
    End Sub

    ''' <summary>
    ''' 清除颜色
    ''' </summary>
    ''' <param name="oInventorPartDocument"></param>
    Public Sub ClearColor(ByVal oInventorPartDocument As PartDocument)

        Dim CompDef As PartComponentDefinition = oInventorPartDocument.ComponentDefinition

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
            If Strings.InStr(oAsset.DisplayName, "HoleRGB") = 1 Or Strings.InStr(oAsset.DisplayName, "直径") = 1 Then
                Try
                    oAsset.Delete()
                Catch ex As Exception

                End Try
            End If
        Next


    End Sub

    Private Sub btn关闭_Click(sender As Object, e As EventArgs) Handles btn关闭.Click
        Me.Close()
    End Sub

    Private Sub FormDiameterHoleColoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48

        LoadColorsFromIni()


    End Sub


    ''' <summary>
    ''' 保存16进制颜色到配置文件
    ''' </summary>
    Private Sub SaveColorsToIni()
        Try
            For Each oLabel As Label In Me.Controls.OfType(Of Label)()
                ' 处理每个背景色 Label
                If Strings.Left(oLabel.Name, 10) = "displayLbl" Then
                    ini.WriteStrINI("自定义孔颜色"， "D" & Strings.Replace(oLabel.Name, "displayLbl", "")， oLabel.Text, IniFile)
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("保存颜色设置时出错: " & ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ''' <summary>
    ''' 从配置文件加载16进制颜色
    ''' </summary>
    Private Sub LoadColorsFromIni()
        Try
            For Each oLabel As Label In Me.Controls.OfType(Of Label)()
                ' 处理每个背景色 Label
                If Strings.Left(oLabel.Name, 10) = "displayLbl" Then
                    Dim strHexColor As String
                    strHexColor = ini.GetStrFromINI("自定义孔颜色", "D" & Strings.Replace(oLabel.Name, "displayLbl", ""), "", IniFile)
                    If strHexColor <> "" Then
                        Dim oBackColor As Drawing.Color = HexToColor(strHexColor)
                        oLabel.BackColor = oBackColor
                        oLabel.Text = strHexColor
                    End If
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("加载颜色设置时出错: " & ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class