Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms
Imports Inventor

Public Class FormOilBlockHoleColoring

    Private oPartFeatureList As New List(Of PartFeature)
    Private Sub FormOilBlockHoleColoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48
        ' 创建ToolTip控件并设置相关属性
        Dim toolTip As New ToolTip With {
            .AutoPopDelay = 0,
            .InitialDelay = 0,
            .ReshowDelay = 500
        }
        toolTip.SetToolTip(btn添加忽略特征, "添加忽略特征")
        toolTip.SetToolTip(btn移出忽略特征, "移出忽略特征")
        toolTip.SetToolTip(btn选择面, "选择着色面")

        ' 从资源文件中加载图标并设置到Button控件的Image属性中
        btn添加忽略特征.Image = My.Resources.选择一32.ToBitmap
        btn移出忽略特征.Image = My.Resources.删除32.ToBitmap
        btn选择面.Image = My.Resources.选择面和边32.ToBitmap

        Dim oDoc As PartDocument = ThisApplication.ActiveDocument

        Dim assetLib As AssetLibrary

        Try
            assetLib = ThisApplication.AssetLibraries.Item("Inventor Material Library")
        Catch ex As Exception
            assetLib = ThisApplication.AssetLibraries.Item("Inventor 材料库")
        End Try

        ThisApplication.ActiveMaterialLibrary = assetLib

        For Each AppearanceAsset As Asset In assetLib.AppearanceAssets
            cbo外观.Items.Add(AppearanceAsset.DisplayName)
        Next

        cbo外观.Text = "默认"

        SetWindowSizeAndCenter(Me, 0, 0)

    End Sub

    Private Sub Btn选择面_Click(sender As Object, e As EventArgs) Handles btn选择面.Click
        Dim oInventorPartDocument As Inventor.PartDocument
        oInventorPartDocument = CType(ThisApplication.ActiveDocument, PartDocument)

        Dim oSelectFace As Face = Nothing

        If oInventorPartDocument.SelectSet.Count <> 0 Then
            For Each oSelect As Object In oInventorPartDocument.SelectSet
                If oSelect.Type = ObjectTypeEnum.kFaceObject Then
                    oSelectFace = CType(oSelect, Face)
                    Exit For
                End If
            Next
        End If


        If oSelectFace Is Nothing Then
            oSelectFace = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kPartFaceFilter, "选择着色的面，ESC键取消")
            If oSelectFace Is Nothing Then       '取消选择
                Exit Sub
            End If
        End If

        Dim oPartFeature As PartFeature = oSelectFace.CreatedByFeature
        ''MessageBox.Show(oPartFeature.Name)

        'Dim oPartFeatureList As New List(Of PartFeature)
        Dim oUnAddFeatureNameList As New List(Of String)

        oUnAddFeatureNameList.AddRange(ListBox忽略特征.Items.Cast(Of String)())


        ThisApplication.UserInterfaceManager.DoEvents()
        Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        OInteractionEvents.Start()
        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)

        '获取
        oPartFeatureList = GetUseFaceFeature（oPartFeature， oPartFeatureList， oUnAddFeatureNameList）

        'Dim Set1 As HighlightSet = oInventorPartDocument.CreateHighlightSet

        'Debug.Print("---------------------------")
        For Each oPartFeature In oPartFeatureList
            Debug.Print(oPartFeature.Name)
            'Set1.AddItem(oPartFeature)
        Next

        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        OInteractionEvents.Stop()

        Me.TopMost = False

        Dim msg As DialogResult = MessageBox.Show("油路块孔着色。" & vbCrLf & vbCrLf & "是——油路块孔着色" & vbCrLf & vbCrLf & "否——清除着色", XHTool，
                                     MessageBoxButtons.YesNoCancel， MessageBoxIcon.Question)

        Me.TopMost = True

        Dim oAsset As Asset = Nothing

        Select Case msg
            Case DialogResult.Yes
                Dim oAssetName As String = cbo外观.Text

                Dim assetLib As AssetLibrary

                Try
                    assetLib = ThisApplication.AssetLibraries.Item("Inventor Material Library")
                Catch ex As Exception
                    assetLib = ThisApplication.AssetLibraries.Item("Inventor 材料库")
                End Try


                Dim libAsset As Asset
                libAsset = assetLib.AppearanceAssets.Item(oAssetName)

                Try
                    oAsset = libAsset.CopyTo(oInventorPartDocument)
                Catch ex As Exception
                    oAsset = oInventorPartDocument.Assets.Item(oAssetName)
                End Try



            Case DialogResult.No
                Try
                    oAsset = oInventorPartDocument.Assets.Item("默认")
                Catch ex As Exception
                    oAsset = oInventorPartDocument.Assets.Item("Default")
                End Try

            Case DialogResult.Cancel
                Exit Sub
        End Select

        SetFeatureColor(oPartFeatureList, oAsset)

        oPartFeatureList.Clear()

    End Sub

    Private Sub Btn关闭_Click(sender As Object, e As EventArgs) Handles btn关闭.Click, Me.Closing
        FormManager.CloseAndDisposeForm(Of FormOilBlockHoleColoring)()
    End Sub

    Private Sub Btn添加忽略特征_Click(sender As Object, e As EventArgs) Handles btn添加忽略特征.Click

        Dim oInventorPartDocument As Inventor.PartDocument
        oInventorPartDocument = CType(ThisApplication.ActiveDocument, PartDocument)

        Dim oSelectFeature As PartFeature
        Dim oSelectFeatureName As String

        If oInventorPartDocument.SelectSet.Count <> 0 Then
            For Each oSelect As Object In oInventorPartDocument.SelectSet
                If oSelect.Type = ObjectTypeEnum.kPartFeatureObject Then
                    oSelectFeature = CType(oSelect, PartFeature)

                    oSelectFeatureName = oSelectFeature.Name

                    If ListBox忽略特征.Items.Contains(oSelectFeatureName) = False Then
                        ListBox忽略特征.Items.Add(oSelectFeatureName)
                    End If

                End If
            Next
        Else
            oSelectFeature = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kPartFeatureFilter, "选择忽略的特征，ESC键取消")
            If oSelectFeature IsNot Nothing Then       '取消选择
                oSelectFeatureName = oSelectFeature.Name

                If ListBox忽略特征.Items.Contains(oSelectFeatureName) = False Then
                    ListBox忽略特征.Items.Add(oSelectFeatureName)
                End If

            End If
        End If

    End Sub

    Private Sub Btn移出忽略特征_Click(sender As Object, e As EventArgs) Handles btn移出忽略特征.Click
        If ListBox忽略特征.SelectedItems.Count = 1 Then
            ListBox忽略特征.Items.Remove(ListBox忽略特征.SelectedItem)
        End If
    End Sub


End Class