
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Inventor
Public Class FormFaceColoring
    Private Sub FormFaceColor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48
        ' 创建ToolTip控件并设置相关属性
        Dim toolTip As New ToolTip With {
            .AutoPopDelay = 0,
            .InitialDelay = 0,
            .ReshowDelay = 500
        }
        toolTip.SetToolTip(Btn选择颜色, "选择面设置颜色")
        toolTip.SetToolTip(btn选择特征, "选择特征着色")
        toolTip.SetToolTip(btn选择面, "选择面着色")
        toolTip.SetToolTip(btn清除着色, "选择清除着色")
        toolTip.SetToolTip(btn清除全部, "清除全部着色")

        ' 从资源文件中加载图标并设置到Button控件的Image属性中
        Btn选择颜色.Image = My.Resources.色卡16.ToBitmap
        btn选择特征.Image = My.Resources.选择特征16.ToBitmap
        btn选择面.Image = My.Resources.选择面和边32.ToBitmap
        btn清除着色.Image = My.Resources.删除16.ToBitmap
        btn清除全部.Image = My.Resources.清空列表16.ToBitmap

        Dim oDoc As PartDocument = ThisApplication.ActiveDocument

        Dim assetLib As AssetLibrary

        Try
            assetLib = ThisApplication.AssetLibraries.Item("Inventor Material Library")
        Catch ex As Exception
            assetLib = ThisApplication.AssetLibraries.Item("Inventor 材料库")
        End Try

        ThisApplication.ActiveMaterialLibrary = assetLib

        For Each AppearanceAsset As Asset In assetLib.AppearanceAssets
            cmb外观.Items.Add(AppearanceAsset.DisplayName)
        Next

        cmb外观.Text = "默认"

    End Sub

    Private Sub Btn选择面_Click(sender As Object, e As EventArgs) Handles btn选择面.click
        Dim oInventorPartDocument As Inventor.PartDocument
        oInventorPartDocument = CType(ThisApplication.ActiveDocument, PartDocument)

        Dim oAssetName As String = cmb外观.Text

        Dim assetLib As AssetLibrary

        Try
            assetLib = ThisApplication.AssetLibraries.Item("Inventor Material Library")
        Catch ex As Exception
            assetLib = ThisApplication.AssetLibraries.Item("Inventor 材料库")
        End Try


        Dim libAsset As Asset
        libAsset = assetLib.AppearanceAssets.Item(oAssetName)


        Dim oAsset As Asset
        Try
            oAsset = libAsset.CopyTo(oInventorPartDocument)
        Catch ex As Exception
            oAsset = oInventorPartDocument.Assets.Item(oAssetName)
        End Try


        Dim oSelectFace As Face = Nothing

        If oInventorPartDocument.SelectSet.Count <> 0 Then
            For Each oSelect As Object In oInventorPartDocument.SelectSet
                If oSelect.Type = ObjectTypeEnum.kFaceObject Then
                    oSelectFace = CType(oSelect, Face)

                    oSelectFace.Appearance = oAsset

                End If
            Next
            Exit Sub
        End If

        If oSelectFace Is Nothing Then

            Try
                Do
                    oSelectFace = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kPartFaceFilter, "选择着色的面，ESC键取消")

                    oSelectFace.Appearance = oAsset


                Loop Until oSelectFace Is Nothing
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub Btn清除着色_Click(sender As Object, e As EventArgs) Handles btn清除着色.Click
        Dim oInventorPartDocument As Inventor.PartDocument
        oInventorPartDocument = CType(ThisApplication.ActiveDocument, PartDocument)


        Dim oAsset As Asset

        Try
            oAsset = oInventorPartDocument.Assets.Item("默认")
        Catch ex As Exception
            oAsset = oInventorPartDocument.Assets.Item("Default")
        End Try

        Dim oSelect As Object
        Dim oSelectFace As Face = Nothing
        Dim oSelectPartFeature As PartFeature
        Dim oPartFeatureList As New List(Of PartFeature)

        If oInventorPartDocument.SelectSet.Count <> 0 Then
            For Each oSelect In oInventorPartDocument.SelectSet

                Select Case oSelect.Type
                    Case ObjectTypeEnum.kFaceObject
                        oSelectFace = CType(oSelect, Face)
                        oSelectFace.Appearance = oAsset
                    Case Else
                        Try
                            oSelectPartFeature = CType(oSelect, PartFeature)
                            oPartFeatureList.Add(oSelectPartFeature)
                        Catch ex As Exception

                        End Try
                End Select

            Next

            SetFeatureColor(oPartFeatureList, oAsset)
            oPartFeatureList.Clear()

            Exit Sub
        End If


        Try
            Do
                oSelect = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kPartDefaultFilter, "选择清除着色的特征或面，ESC键取消")
                Select Case oSelect.Type
                    Case ObjectTypeEnum.kFaceObject
                        oSelectFace = CType(oSelect, Face)
                        oSelectFace.Appearance = oAsset
                    Case Else
                        Try
                            oSelectPartFeature = CType(oSelect, PartFeature)
                            oPartFeatureList.Add(oSelectPartFeature)
                            SetFeatureColor(oPartFeatureList, oAsset)
                            oPartFeatureList.Clear()
                        Catch ex As Exception

                        End Try
                End Select

            Loop Until oSelectFace Is Nothing
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Btn清除全部_Click(sender As Object, e As EventArgs) Handles btn清除全部.Click

        Dim oInventorPartDocument As Inventor.PartDocument
        oInventorPartDocument = CType(ThisApplication.ActiveDocument, PartDocument)

        Dim oAsset As Asset

        Try
            oAsset = oInventorPartDocument.Assets.Item("默认")
        Catch ex As Exception
            oAsset = oInventorPartDocument.Assets.Item("Default")
        End Try


        Dim CompDef As PartComponentDefinition = oInventorPartDocument.ComponentDefinition

        For Each oFace As Face In CompDef.SurfaceBodies.Item(1).Faces
            oFace.Appearance = oAsset
        Next


    End Sub

    Private Sub Btn选择特征_Click(sender As Object, e As EventArgs) Handles btn选择特征.Click
        Dim oInventorPartDocument As Inventor.PartDocument
        oInventorPartDocument = CType(ThisApplication.ActiveDocument, PartDocument)

        Dim oAssetName As String = cmb外观.Text

        Dim assetLib As AssetLibrary

        Try
            assetLib = ThisApplication.AssetLibraries.Item("Inventor Material Library")
        Catch ex As Exception
            assetLib = ThisApplication.AssetLibraries.Item("Inventor 材料库")
        End Try


        Dim libAsset As Asset
        libAsset = assetLib.AppearanceAssets.Item(oAssetName)


        Dim oAsset As Asset
        Try
            oAsset = libAsset.CopyTo(oInventorPartDocument)
        Catch ex As Exception
            oAsset = oInventorPartDocument.Assets.Item(oAssetName)
        End Try


        Dim oSelectPartFeature As PartFeature = Nothing

        Dim oPartFeatureList As New List(Of PartFeature)

        If oInventorPartDocument.SelectSet.Count <> 0 Then
            For Each oSelect As Object In oInventorPartDocument.SelectSet
                Try
                    oSelectPartFeature = CType(oSelect, PartFeature)
                    oPartFeatureList.Add(oSelectPartFeature)
                Catch ex As Exception

                End Try

            Next

            SetFeatureColor(oPartFeatureList, oAsset)
            oPartFeatureList.Clear()

            Exit Sub
        End If

        If oSelectPartFeature Is Nothing Then

            Try
                Do
                    oSelectPartFeature = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kPartFeatureFilter, "选择着色的特征，ESC键取消")

                    oPartFeatureList.Add(oSelectPartFeature)
                    SetFeatureColor(oPartFeatureList, oAsset)
                    oPartFeatureList.Clear()

                Loop Until oSelectPartFeature Is Nothing
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub Btn选择颜色_Click(sender As Object, e As EventArgs) Handles Btn选择颜色.Click

        Dim oSelectFace As Face
        Dim oAsset As Asset
        Try
            Do
                oSelectFace = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kPartFaceFilter, "选择着色的面，ESC键取消")

                oAsset = oSelectFace.Appearance

                cmb外观.Text = oAsset.DisplayName

            Loop Until oSelectFace IsNot Nothing
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FormFaceColoring_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        FormManager.CloseAndDisposeForm(Of FormAbout)()
    End Sub
End Class