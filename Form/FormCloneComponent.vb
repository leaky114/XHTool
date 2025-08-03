Imports System.Collections.Generic
Imports System.ComponentModel
Imports Inventor

Public Class FormCloneComponent
    Dim oInventorAssemblyDocument As Inventor.AssemblyDocument

    '获取被选择的组件列表
    Dim oSourceComponentList As New List(Of ComponentOccurrence)
    Dim oEdgeOne As Edge      '源组件中选择的圆边
    Dim oEdgeTwo As Edge        ' 插入约束的圆边
    Dim oEdgeThree As Edge = Nothing   ' 复制组件中与 oedgeone 对应的圆边

    Dim oOneSourceComponentOccurrence As ComponentOccurrence = Nothing

    '判断选择的边是否属于选择的组件
    Dim IsEdgeOneInComponentOccurrence As Boolean = False

    Dim oEdgeOneComponentOccurrence As ComponentOccurrence   '选择的第一个圆的源组件

    Dim oSourceCenter As Inventor.Point     '源圆心
    Dim oSourceRadius As Double     '源半径

    Dim oEdgeHSet As HighlightSet

    Dim oInsertConstraintList As New List(Of InsertConstraint)

    Private Sub FormCloneComponent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48
        ' 创建ToolTip控件并设置相关属性
        Dim toolTip As New ToolTip With {
            .AutoPopDelay = 0,
            .InitialDelay = 0,
            .ReshowDelay = 500
        }
        toolTip.SetToolTip(btn选择现有组件, "选择需要复制的源组件。")
        toolTip.SetToolTip(btn选择组件圆弧, "请在源零件中选择一个插入约束的圆(弧)，ESC键取消。")
        toolTip.SetToolTip(btn插入组件圆弧, "请选择插入位置的圆(弧)，ESC键取消。")
        toolTip.SetToolTip(btn插入反向, "插入约束反向。")


        btn选择现有组件.Image = My.Resources.选择零部件16.ToBitmap
        btn选择组件圆弧.Image = My.Resources.选择一32.ToBitmap
        btn插入组件圆弧.Image = My.Resources.选择二32.ToBitmap
        btn插入反向.Image = My.Resources.插入反向32.ToBitmap

        oInventorAssemblyDocument = ThisApplication.ActiveDocument

        oSourceComponentList.Clear()

        Dim oSelectSets As SelectSet
        oSelectSets = oInventorAssemblyDocument.SelectSet

        For Each oSelectedEntity As Object In oSelectSets
            ' 检查是否为 ComponentOccurrence 类型
            If TypeOf oSelectedEntity Is ComponentOccurrence Then
                Dim oComponent As ComponentOccurrence = CType(oSelectedEntity, ComponentOccurrence)
                oSourceComponentList.Add(oComponent)
            Else
                ' 可选：提示用户排除了非组件的选择项
                '  MessageBox.Show($"已跳过非组件对象：{oSelectedEntity.ToString()}")
            End If
        Next

        lbl组件数量.Text = $"已选择{oSourceComponentList.Count}“

        Me.Show()

        If chk自动下一步.Checked = True And oSourceComponentList.Count <> 0 Then
            btn选择组件圆弧.Enabled = True
            btn选择组件圆弧_Click(sender, e)
        End If

        If chk自动下一步.Checked = True And oSourceComponentList.Count = 0 Then
            btn选择现有组件_Click(sender, e)
        End If


    End Sub

    Private Sub btn关闭_Click(sender As Object, e As EventArgs) Handles btn关闭.Click
        FormManager.CloseAndDisposeForm(Of FormCloneComponent)()
        'Me.Close()
    End Sub

    Private Sub btn选择现有组件_Click(sender As Object, e As EventArgs) Handles btn选择现有组件.Click
        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument

        oSourceComponentList = Nothing

        Dim oSelectSets As SelectSet
        oSelectSets = oInventorAssemblyDocument.SelectSet

        ''获取被选择的组件列表
        'Dim oSourceComponentList As New List(Of ComponentOccurrence)

        If oSelectSets.Count = 0 Then

            Dim oclsWindowSelection As New ClsWindowSelection
            oSourceComponentList = oclsWindowSelection.WindowSelect()

            If oSourceComponentList Is Nothing Then
                Exit Sub
            End If
            'MessageBox.Show("选择复制的组件。"， XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information)
            'Exit Sub
        Else
            For Each oSelectedEntity As Object In oSelectSets
                ' 检查是否为 ComponentOccurrence 类型
                If TypeOf oSelectedEntity Is ComponentOccurrence Then
                    Dim oComponent As ComponentOccurrence = CType(oSelectedEntity, ComponentOccurrence)
                    oSourceComponentList.Add(oComponent)
                Else
                    ' 可选：提示用户排除了非组件的选择项
                    '  MessageBox.Show($"已跳过非组件对象：{oSelectedEntity.ToString()}")
                End If
            Next
        End If

        btn选择组件圆弧.Enabled = True
        lbl组件数量.Text = $"已选择{oSourceComponentList.Count}“

        For Each occ As ComponentOccurrence In oSourceComponentList
            ThisApplication.CommandManager.DoSelect(occ)
        Next

        '复制选择的组件
        ThisApplication.CommandManager.ControlDefinitions.Item("AppCopyCmd").Execute()

        If chk自动下一步.Checked = True Then
            btn选择组件圆弧.Enabled = True
            btn选择组件圆弧_Click(sender, e)
        End If
    End Sub

    Private Sub btn选择组件圆弧_Click(sender As Object, e As EventArgs) Handles btn选择组件圆弧.Click
        'Dim oOneSourceComponentOccurrence As ComponentOccurrence = Nothing

        Try

            ' 1. 统计每个文件完整路径的出现次数
            Dim filePathCountDict As New Dictionary(Of String, Integer)
            For Each oComponentOccurrence As ComponentOccurrence In oSourceComponentList
                If oComponentOccurrence.Definition IsNot Nothing AndAlso
                   oComponentOccurrence.Definition.Document IsNot Nothing Then
                    ' 获取文件的完整路径
                    Dim filePath As String = oComponentOccurrence.Definition.Document.FullFileName
                    If Not String.IsNullOrEmpty(filePath) Then
                        If filePathCountDict.ContainsKey(filePath) Then
                            filePathCountDict(filePath) += 1
                        Else
                            filePathCountDict(filePath) = 1
                        End If
                    End If
                End If
            Next

            ' 2. 遍历列表，找到第一个文件路径唯一的组件
            For Each oComponentOccurrence As ComponentOccurrence In oSourceComponentList
                If oComponentOccurrence.Definition IsNot Nothing AndAlso
                   oComponentOccurrence.Definition.Document IsNot Nothing Then
                    Dim filePath As String = oComponentOccurrence.ReferencedFileDescriptor.FullFileName
                    If Not String.IsNullOrEmpty(filePath) AndAlso
                       filePathCountDict(filePath) = 1 Then
                        oOneSourceComponentOccurrence = oComponentOccurrence
                        Exit For ' 找到第一个后立即退出
                    End If
                End If
            Next

            ' 3. 结果检查
            If oOneSourceComponentOccurrence Is Nothing Then
                ' 未找到符合条件的组件
                MessageBox.Show("选择的组件中无数量为一的，无法与源组件对齐，退出本功能。"， XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)

                Exit Sub
            Else
                ' 成功找到唯一文件路径的组件
                ' MessageBox.Show("唯一文件路径：" & oOneSourceComponentOccurrence.ReferencedFileDescriptor.FullFileName)
            End If

            oEdgeHSet = oInventorAssemblyDocument.CreateHighlightSet   '选择圆边的高亮
            oEdgeHSet.Color = ThisApplication.TransientObjects.CreateColor(255, 165, 0）   '橙色

            oEdgeOne = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kPartEdgeCircularFilter, "请在源零件中选择一个插入约束的圆(弧)，ESC键取消。")
            If oEdgeOne Is Nothing Then       '取消选择
                oEdgeHSet.Clear()
                Exit Sub
            End If

            Select Case oEdgeOne.GeometryType
                Case CurveTypeEnum.kCircleCurve, CurveTypeEnum.kCircularArcCurve
                    oEdgeHSet.AddItem(oEdgeOne)
                Case Else
                    Exit Sub
            End Select

            '判断选择的边是否属于选择的组件
            Dim IsEdgeOneInComponentOccurrence As Boolean = False

            oEdgeOneComponentOccurrence = oEdgeOne.ContainingOccurrence    '选择的第一个圆的源组件


            ' 扩展目标组件列表：将子部件展开为所有子零件
            Dim oSourceExpandedComponentList As New List(Of ComponentOccurrence)()
            For Each oComponentOccurrence As ComponentOccurrence In oSourceComponentList
                oSourceExpandedComponentList.AddRange(GetAllLeafOccurrences(oComponentOccurrence))
            Next


            If oSourceExpandedComponentList.Any(Function(comp) comp Is oEdgeOneComponentOccurrence) Then
                IsEdgeOneInComponentOccurrence = True
            Else
                IsEdgeOneInComponentOccurrence = False
            End If

            If IsEdgeOneInComponentOccurrence = False Then
                oEdgeHSet.Clear()
                MessageBox.Show("选择的圆(弧)不属于被复制的组件。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）
                Exit Sub
            End If

            'Dim oSourceCenter As Inventor.Point     '源圆心
            'Dim oSourceRadius As Double     '源半径

            oSourceCenter = oEdgeOne.Geometry.center
            oSourceRadius = oEdgeOne.Geometry.radius

            btn插入组件圆弧.Enabled = True
        Catch

        End Try

        If chk自动下一步.Checked = True Then
            btn插入组件圆弧_Click(sender, e)
        End If

    End Sub

    Private Sub btn插入组件圆弧_Click(sender As Object, e As EventArgs) Handles btn插入组件圆弧.Click

        ''复制选择的组件
        'ThisApplication.CommandManager.ControlDefinitions.Item("AppCopyCmd").Execute()
        'oInventorAssemblyDocument.SelectSet.Clear()
        oInsertConstraintList.Clear()

        Dim douOffset As Double = txt偏移量.Text     '插入偏移
        'If Not Double.TryParse(InputBox("输入偏移量：", "复制插入", 0), douOffset) Then
        '    MessageBox.Show("偏移量必须为数字。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error)
        '    Exit Sub
        'End If
        '输入的单位是cm ，转换为 mm
        douOffset *= 0.1

        '撤销功能
        Dim oTransaction As Transaction
        oTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "My Transaction")

        Try

            Do

                ' 重新添加高亮（假设 oEdgeOne 仍有效）
                If oEdgeHSet IsNot Nothing AndAlso oEdgeOne IsNot Nothing Then
                    oEdgeHSet.AddItem(oEdgeOne)
                End If

                oEdgeTwo = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kPartEdgeCircularFilter, "请选择插入位置的圆(弧)，ESC键取消。")
                If oEdgeTwo Is Nothing Then       '取消选择

                    '刷新浏览器
                    ThisApplication.ScreenUpdating = True
                    oInventorAssemblyDocument.Update()
                    oInventorAssemblyDocument.BrowserPanes.ActivePane.Refresh()
                    Exit Do
                End If

                'oHSet.AddItem(oEdgeTwo)

                ThisApplication.ScreenUpdating = False

                '记录粘贴前的组件数量
                Dim originalOccCount As Integer = oInventorAssemblyDocument.ComponentDefinition.Occurrences.Count

                '粘贴选择的组件
                ThisApplication.CommandManager.ControlDefinitions.Item("AppPasteCmd").Execute()
                oInventorAssemblyDocument.BrowserPanes.ActivePane.Refresh()

                Dim oOneCloneComponent As ComponentOccurrence = Nothing     '克隆组件

                '获取被粘贴的的组件列表
                Dim oCloneComponentList As New List(Of ComponentOccurrence)
                For i = originalOccCount + 1 To oInventorAssemblyDocument.ComponentDefinition.Occurrences.Count
                    oCloneComponentList.Add(oInventorAssemblyDocument.ComponentDefinition.Occurrences.Item(i))
                Next

                '用仅一个的组件名对比 新粘贴的组件名 ，获取数量为一的的组件
                For Each oComponentOccurrence In oCloneComponentList
                    If oComponentOccurrence.ReferencedFileDescriptor.FullFileName =
                    oOneSourceComponentOccurrence.ReferencedFileDescriptor.FullFileName Then
                        oOneCloneComponent = oComponentOccurrence
                        Exit For
                    End If
                Next

                '对齐源组件和 粘贴 的组件
                If FlushXYZPlaneSub(oInventorAssemblyDocument, oOneSourceComponentOccurrence, oOneCloneComponent, True) = False Then
                    ThisApplication.CommandManager.ControlDefinitions.Item("AppUndoCmd").Execute()
                    Exit Do
                End If

                Dim oComponentCenter As Inventor.Point     '组件圆心
                Dim oComponentRadius As Double    '组件半径
                Dim oColneComponentEdges As Edges

                ' 扩展目标组件列表：将子部件展开为所有子零件
                Dim oCloneExpandedComponentListAs As New List(Of ComponentOccurrence)

                For Each oComponentOccurrence As ComponentOccurrence In oCloneComponentList
                    oCloneExpandedComponentListAs.AddRange(GetAllLeafOccurrences(oComponentOccurrence))
                Next

                For Each oComponentOccurrence As ComponentOccurrence In oCloneExpandedComponentListAs
                    If oComponentOccurrence.ReferencedFileDescriptor.FullFileName = oEdgeOneComponentOccurrence.ReferencedFileDescriptor.FullFileName Then
                        For i = 1 To oComponentOccurrence.SurfaceBodies.Count
                            oColneComponentEdges = oComponentOccurrence.SurfaceBodies.Item(i).Edges

                            For Each oEdge As Edge In oColneComponentEdges
                                Select Case oEdge.GeometryType
                                    Case CurveTypeEnum.kCircleCurve
                                        oComponentCenter = oEdge.Geometry.center
                                        oComponentRadius = oEdge.Geometry.radius
                                    Case CurveTypeEnum.kCircularArcCurve
                                        oComponentCenter = oEdge.Geometry.center
                                        oComponentRadius = oEdge.Geometry.radius
                                    Case Else
                                        Continue For
                                End Select

                                If FourFive(oSourceCenter.DistanceTo(oComponentCenter), 5) = 0 And FourFive(oSourceRadius - oComponentRadius, 5) = 0 Then
                                    oEdgeThree = oEdge
                                    GoTo 999
                                End If
                            Next

                        Next
                    End If
                Next

999:

                If oEdgeThree Is Nothing Then
                    MessageBox.Show("未找到匹配的圆形边。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）
                    Continue Do
                End If

                oInsertConstraintList.Add(oInventorAssemblyDocument.ComponentDefinition.Constraints.AddInsertConstraint(oEdgeTwo, oEdgeThree,
                                                                                                                   True, douOffset))
                '刷新浏览器

                oEdgeHSet.Clear()
                ThisApplication.ScreenUpdating = True
                oInventorAssemblyDocument.Update()
            Loop While (True)

        Catch

        End Try

        oEdgeHSet.Clear()
        oTransaction.End()

        ThisApplication.ScreenUpdating = True
        oInventorAssemblyDocument.Update()
        oInventorAssemblyDocument.BrowserPanes.ActivePane.Refresh()

    End Sub

    Private Sub btn插入方向_Click(sender As Object, e As EventArgs) Handles btn插入反向.Click
        '撤销功能
        Dim oTransaction As Transaction
        oTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "My Transaction")

        ThisApplication.ScreenUpdating = False

        For Each oInsertConstraint As InsertConstraint In oInsertConstraintList
            oInsertConstraint.ConvertToInsertConstraint(oInsertConstraint.EntityOne, oInsertConstraint.EntityTwo,
                                                        oInsertConstraint.AxesOpposed Xor True, oInsertConstraint.Distance.Value)
        Next

        oTransaction.End()
        ThisApplication.ScreenUpdating = True
        oInventorAssemblyDocument.Update()

    End Sub

    Private Sub txt偏移量_KeyDown(sender As Object, e As KeyEventArgs) Handles txt偏移量.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            '撤销功能
            Dim oTransaction As Transaction
            oTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "My Transaction")

            ThisApplication.ScreenUpdating = False
            For Each oInsertConstraint As InsertConstraint In oInsertConstraintList
                oInsertConstraint.Distance.Value = Convert.ToInt32(txt偏移量.Text) * 0.1
            Next

            oTransaction.End()

            ThisApplication.ScreenUpdating = True
            oInventorAssemblyDocument.Update()

        End If
    End Sub

End Class