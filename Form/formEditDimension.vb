Imports System.Windows.Forms
Imports Inventor
Imports System.Drawing
Imports Inventor.SelectionFilterEnum
Imports Inventor.ObjectTypeEnum

Public Class FormEditDimension

    Private strCurrentName As String   '当前值的名称

    Private strCurrentDimensionValue As String       '二维还原值
    Private strCurrentDimensionValue3D As String   '三维还原值
    Private strCurrentBendValue As String   '折弯还原值
    Private strCurrentConstraintValue As String '约束还原值

    Private oFeatureDimension As FeatureDimension    '特征尺寸
    Private oDimensionConstraint As DimensionConstraint      '二维尺寸
    Private oDimensionConstraint3D As DimensionConstraint3D    '三维尺寸
    Private oBendConstraint As BendConstraint     '折弯尺寸

    Dim oFlushConstraint As FlushConstraint     '表面对齐
    Dim oMateConstraint As MateConstraint       '配合
    Dim oAngleConstraint As AngleConstraint      '角度
    Dim oInsertConstraint As InsertConstraint   '插入
    Dim oTangentConstraint As TangentConstraint   '相切

    Private oSelectType As SelectType  '当前尺寸属性

    Private oPlanarSketch As Object

    Private IsSketchShow As Boolean  '草图可见

    Const intStep As Integer = 10   '游标的最值 ，单位 cm

    Enum SelectType
        二维草图 = 0
        三维草图 = 1
        二维草图尺寸 = 2
        三维草图尺寸 = 3
        折弯尺寸 = 4
        平面对齐约束 = 5
        配合约束 = 6
        角度约束 = 7
        插入约束 = 8
        相切约束 = 9
        特征尺寸 = 10
    End Enum

    Private Sub Btn选择一_Click(sender As Object, e As EventArgs) Handles btn选择一.Click
        SelectDiameter()
    End Sub

    Private Sub TrackBar参数一_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar参数一.Scroll
        On Error Resume Next
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        Select Case oSelectType
            Case SelectType.特征尺寸
                Select Case oFeatureDimension.Parameter.Units
                    Case "mm"
                        oFeatureDimension.Parameter.Value = TrackBar参数一.Value * 0.1
                    Case "cm"
                        oFeatureDimension.Parameter.Value = TrackBar参数一.Value
                    Case "deg"
                        oFeatureDimension.Parameter.Value = TrackBar参数一.Value * Math.PI / 180
                End Select

                oFeatureDimension.Parent.FeatureDimensions.Show()

            Case SelectType.二维草图尺寸
                '二维草图
                Select Case oDimensionConstraint.Parameter.Units
                    Case "mm"
                        oDimensionConstraint.Parameter.Value = TrackBar参数一.Value * 0.1
                    Case "cm"
                        oDimensionConstraint.Parameter.Value = TrackBar参数一.Value
                    Case "deg"
                        oDimensionConstraint.Parameter.Value = TrackBar参数一.Value * Math.PI / 180
                End Select
            Case SelectType.三维草图尺寸
                '三维草图
                Select Case oDimensionConstraint3D.Parameter.Units
                    Case "mm"
                        oDimensionConstraint3D.Parameter.Value = TrackBar参数一.Value * 0.1
                    Case "cm"
                        oDimensionConstraint3D.Parameter.Value = TrackBar参数一.Value
                    Case "deg"
                        oDimensionConstraint3D.Parameter.Value = TrackBar参数一.Value * Math.PI / 180
                End Select
            Case SelectType.折弯尺寸
                Select Case oBendConstraint.Radius.Units
                    Case "mm"
                        oBendConstraint.Radius.Value = TrackBar参数一.Value * 0.1
                    Case "cm"
                        oBendConstraint.Radius.Value = TrackBar参数一.Value
                End Select
            Case SelectType.插入约束
                Select Case oInsertConstraint.Distance.Units
                    Case "mm"
                        oInsertConstraint.Distance.Value = TrackBar参数一.Value * 0.1
                    Case "cm"
                        oInsertConstraint.Distance.Value = TrackBar参数一.Value
                    Case "deg"
                        oInsertConstraint.Distance.Value = TrackBar参数一.Value * Math.PI / 180
                End Select
            Case SelectType.角度约束
                Select Case oAngleConstraint.Angle.Units
                    Case "mm"
                        oAngleConstraint.Angle.Value = TrackBar参数一.Value * 0.1
                    Case "cm"
                        oAngleConstraint.Angle.Value = TrackBar参数一.Value
                    Case "deg"
                        oAngleConstraint.Angle.Value = TrackBar参数一.Value * Math.PI / 180
                End Select
            Case SelectType.配合约束
                Select Case oMateConstraint.Offset.Units
                    Case "mm"
                        oMateConstraint.Offset.Value = TrackBar参数一.Value * 0.1
                    Case "cm"
                        oMateConstraint.Offset.Value = TrackBar参数一.Value
                    Case "deg"
                        oMateConstraint.Offset.Value = TrackBar参数一.Value * Math.PI / 180
                End Select
            Case SelectType.平面对齐约束
                Select Case oFlushConstraint.Offset.Units
                    Case "mm"
                        oFlushConstraint.Offset.Value = TrackBar参数一.Value * 0.1
                    Case "cm"
                        oFlushConstraint.Offset.Value = TrackBar参数一.Value
                    Case "deg"
                        oFlushConstraint.Offset.Value = TrackBar参数一.Value * Math.PI / 180
                End Select
            Case SelectType.相切约束
                Select Case oTangentConstraint.Offset.Units
                    Case "mm"
                        oTangentConstraint.Offset.Value = TrackBar参数一.Value * 0.1

                    Case "cm"
                        oTangentConstraint.Offset.Value = TrackBar参数一.Value
                End Select
        End Select

        txt参数.Text = TrackBar参数一.Value

        oInventorDocument.Update()
        ThisApplication.ActiveView.Update()

        If oSelectType = SelectType.特征尺寸 Then
            oFeatureDimension.Parent.FeatureDimensions.Show()
        End If

    End Sub

    Private Sub Btn还原_Click(sender As Object, e As EventArgs) Handles btn还原.Click
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        Select Case oSelectType
            Case SelectType.特征尺寸
                oFeatureDimension.Parameter.Expression = strCurrentDimensionValue
                txt参数.Text = strCurrentDimensionValue

                Select Case oFeatureDimension.Parameter.Units
                    Case "mm"
                        TrackBar参数一.Minimum = oFeatureDimension.Parameter.Value * 10 - intStep * 10
                        TrackBar参数一.Maximum = oFeatureDimension.Parameter.Value * 10 + intStep * 10
                        TrackBar参数一.Value = oFeatureDimension.Parameter.Value * 10
                    Case "cm"
                        TrackBar参数一.Minimum = oFeatureDimension.Parameter.Value - intStep
                        TrackBar参数一.Maximum = oFeatureDimension.Parameter.Value + intStep
                        TrackBar参数一.Value = oFeatureDimension.Parameter.Value
                    Case "deg"
                        TrackBar参数一.Minimum = oFeatureDimension.Parameter.Value * 180 / Math.PI - 45
                        TrackBar参数一.Maximum = oFeatureDimension.Parameter.Value * 180 / Math.PI + 45
                        TrackBar参数一.Value = oFeatureDimension.Parameter.Value * 180 / Math.PI
                End Select

            Case SelectType.二维草图尺寸
                '二维草图
                oDimensionConstraint.Parameter.Expression = strCurrentDimensionValue
                txt参数.Text = strCurrentDimensionValue

                Select Case oDimensionConstraint.Parameter.Units
                    Case "mm"
                        TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value * 10 - intStep * 10
                        TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value * 10 + intStep * 10
                        TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 10
                    Case "cm"
                        TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value - intStep
                        TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value + intStep
                        TrackBar参数一.Value = oDimensionConstraint.Parameter.Value
                    Case "deg"
                        TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value * 180 / Math.PI - 45
                        TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value * 180 / Math.PI + 45
                        TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 180 / Math.PI
                End Select
            Case SelectType.三维草图尺寸
                '三维草图
                oDimensionConstraint3D.Parameter.Expression = strCurrentDimensionValue3D
                txt参数.Text = strCurrentDimensionValue3D

                Select Case oDimensionConstraint3D.Parameter.Units
                    Case "mm"
                        TrackBar参数一.Minimum = oDimensionConstraint3D.Parameter.Value * 10 - intStep * 10
                        TrackBar参数一.Maximum = oDimensionConstraint3D.Parameter.Value * 10 + intStep * 10
                        TrackBar参数一.Value = oDimensionConstraint3D.Parameter.Value * 10
                    Case "cm"
                        TrackBar参数一.Minimum = oDimensionConstraint3D.Parameter.Value - intStep
                        TrackBar参数一.Maximum = oDimensionConstraint3D.Parameter.Value + intStep
                        TrackBar参数一.Value = oDimensionConstraint3D.Parameter.Value
                    Case "deg"
                        TrackBar参数一.Minimum = oDimensionConstraint3D.Parameter.Value * 180 / Math.PI - 45
                        TrackBar参数一.Maximum = oDimensionConstraint3D.Parameter.Value * 180 / Math.PI + 45
                        TrackBar参数一.Value = oDimensionConstraint3D.Parameter.Value * 180 / Math.PI
                End Select
            Case SelectType.折弯尺寸
                oBendConstraint.Radius.Expression = strCurrentBendValue
                txt参数.Text = strCurrentBendValue

                Select Case oBendConstraint.Radius.Units
                    Case "mm"
                        TrackBar参数一.Minimum = oBendConstraint.Radius.Value * 10 - intStep * 10
                        TrackBar参数一.Maximum = oBendConstraint.Radius.Value + intStep * 10
                        TrackBar参数一.Value = oBendConstraint.Radius.Value * 10

                    Case "cm"
                        TrackBar参数一.Minimum = oBendConstraint.Radius.Value - intStep
                        TrackBar参数一.Maximum = oBendConstraint.Radius.Value + intStep
                        TrackBar参数一.Value = oBendConstraint.Radius.Value
                End Select
            Case SelectType.插入约束
                oInsertConstraint.Distance.Expression = strCurrentConstraintValue
                txt参数.Text = strCurrentConstraintValue

                Select Case oInsertConstraint.Distance.Units
                    Case "mm"
                        TrackBar参数一.Minimum = oInsertConstraint.Distance.Value * 10 - intStep * 10
                        TrackBar参数一.Maximum = oInsertConstraint.Distance.Value * 10 + intStep * 10
                        TrackBar参数一.Value = oInsertConstraint.Distance.Value * 10
                    Case "cm"
                        TrackBar参数一.Minimum = oInsertConstraint.Distance.Value - intStep
                        TrackBar参数一.Maximum = oInsertConstraint.Distance.Value + intStep
                        TrackBar参数一.Value = oInsertConstraint.Distance.Value
                End Select

            Case SelectType.角度约束
                oAngleConstraint.Angle.Expression = strCurrentConstraintValue
                txt参数.Text = strCurrentConstraintValue

                TrackBar参数一.Minimum = oAngleConstraint.Angle.Value * 180 / Math.PI - 90
                TrackBar参数一.Maximum = oAngleConstraint.Angle.Value * 180 / Math.PI + 90
                TrackBar参数一.Value = oAngleConstraint.Angle.Value * 180 / Math.PI

            Case SelectType.配合约束
                oMateConstraint.Offset.Expression = strCurrentConstraintValue
                txt参数.Text = strCurrentConstraintValue

                Select Case oMateConstraint.Offset.Units
                    Case "mm"
                        TrackBar参数一.Minimum = oMateConstraint.Offset.Value * 10 - intStep * 10
                        TrackBar参数一.Maximum = oMateConstraint.Offset.Value * 10 + intStep * 10
                        TrackBar参数一.Value = oMateConstraint.Offset.Value * 10
                    Case "cm"
                        TrackBar参数一.Minimum = oMateConstraint.Offset.Value - intStep
                        TrackBar参数一.Maximum = oMateConstraint.Offset.Value + intStep
                        TrackBar参数一.Value = oMateConstraint.Offset.Value

                End Select

            Case SelectType.平面对齐约束
                oFlushConstraint.Offset.Expression = strCurrentConstraintValue
                txt参数.Text = strCurrentConstraintValue

                Select Case oFlushConstraint.Offset.Units
                    Case "mm"
                        TrackBar参数一.Minimum = oFlushConstraint.Offset.Value * 10 - intStep * 10
                        TrackBar参数一.Maximum = oFlushConstraint.Offset.Value * 10 + intStep * 10
                        TrackBar参数一.Value = oFlushConstraint.Offset.Value * 10
                    Case "cm"
                        TrackBar参数一.Minimum = oFlushConstraint.Offset.Value - intStep
                        TrackBar参数一.Maximum = oFlushConstraint.Offset.Value + intStep
                        TrackBar参数一.Value = oFlushConstraint.Offset.Value
                End Select

            Case SelectType.相切约束
                oTangentConstraint.Offset.Expression = strCurrentConstraintValue
                txt参数.Text = strCurrentConstraintValue

                Select Case oTangentConstraint.Offset.Units
                    Case "mm"
                        TrackBar参数一.Minimum = oTangentConstraint.Offset.Value * 10 - intStep * 10
                        TrackBar参数一.Maximum = oTangentConstraint.Offset.Value * 10 + intStep * 10
                        TrackBar参数一.Value = oTangentConstraint.Offset.Value * 10
                    Case "cm"
                        TrackBar参数一.Minimum = oTangentConstraint.Offset.Value - intStep
                        TrackBar参数一.Maximum = oTangentConstraint.Offset.Value + intStep
                        TrackBar参数一.Value = oTangentConstraint.Offset.Value
                End Select
        End Select

        oInventorDocument.Update()
        ThisApplication.ActiveView.Update()

        If oSelectType = SelectType.特征尺寸 Then
            oFeatureDimension.Parent.FeatureDimensions.Show()
        End If

    End Sub

    Private Sub FormEditDimension_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Try

            'If (oDimensionConstraint Is Nothing) And (oDimensionConstraint3D Is Nothing) Then
            '    Exit Sub
            'End If

            ''参考尺寸退出，不更新尺寸
            'If (oDimensionConstraint.Parameter.ParameterType = ParameterTypeEnum.kReferenceParameter) And (oDimensionConstraint3D.Parameter.ParameterType = ParameterTypeEnum.kReferenceParameter) Then
            '    Exit Sub
            'End If

            Dim oInventorDocument As Inventor.Document
            oInventorDocument = ThisApplication.ActiveEditDocument

            Select Case oSelectType
                Case SelectType.插入约束
                    oInsertConstraint.Distance.Expression = strCurrentConstraintValue

                Case SelectType.二维草图

                Case SelectType.二维草图尺寸
                    oDimensionConstraint.Parameter.Expression = strCurrentDimensionValue

                Case SelectType.角度约束
                    oAngleConstraint.Angle.Expression = strCurrentConstraintValue

                Case SelectType.配合约束
                    oMateConstraint.Offset.Expression = strCurrentConstraintValue

                Case SelectType.平面对齐约束
                    oFlushConstraint.Offset.Expression = strCurrentConstraintValue

                Case SelectType.三维草图

                Case SelectType.三维草图尺寸
                    oDimensionConstraint3D.Parameter.Expression = strCurrentDimensionValue3D

                Case SelectType.折弯尺寸
                    oBendConstraint.Radius.Expression = strCurrentBendValue
            End Select

            oInventorDocument.Update()
            ThisApplication.ActiveView.Update()
        Catch

        End Try

        FormManager.CloseAndDisposeForm(Of FormEditDimension)()

    End Sub

    Private Sub Btn应用_Click(sender As Object, e As EventArgs) Handles btn应用.Click
        On Error Resume Next
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        Select Case oSelectType
            Case SelectType.特征尺寸
                strCurrentDimensionValue = txt参数.Text
                oFeatureDimension.Parameter.Expression = txt参数.Text

                Select Case oFeatureDimension.Parameter.Units
                    Case "mm"
                        TrackBar参数一.Minimum = TrackBar参数一.Value - intStep * 10
                        TrackBar参数一.Maximum = TrackBar参数一.Value + intStep * 10

                        TrackBar参数一.Value = oFeatureDimension.Parameter.Value * 10

                    Case "cm"
                        TrackBar参数一.Value = oFeatureDimension.Parameter.Value
                        TrackBar参数一.Minimum = TrackBar参数一.Value - intStep
                        TrackBar参数一.Maximum = TrackBar参数一.Value + intStep

                    Case "deg"
                        TrackBar参数一.Value = oFeatureDimension.Parameter.Value * 180 / Math.PI
                        TrackBar参数一.Minimum = TrackBar参数一.Value - 90
                        TrackBar参数一.Maximum = TrackBar参数一.Value + 90
                End Select


            Case SelectType.二维草图尺寸
                '二维草图
                strCurrentDimensionValue = txt参数.Text
                oDimensionConstraint.Parameter.Expression = txt参数.Text

                Select Case oDimensionConstraint.Parameter.Units
                    Case "mm"
                        TrackBar参数一.Minimum = TrackBar参数一.Value - intStep * 10
                        TrackBar参数一.Maximum = TrackBar参数一.Value + intStep * 10

                        TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 10

                    Case "cm"
                        TrackBar参数一.Value = oDimensionConstraint.Parameter.Value
                        TrackBar参数一.Minimum = TrackBar参数一.Value - intStep
                        TrackBar参数一.Maximum = TrackBar参数一.Value + intStep

                    Case "deg"
                        TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 180 / Math.PI
                        TrackBar参数一.Minimum = TrackBar参数一.Value - 90
                        TrackBar参数一.Maximum = TrackBar参数一.Value + 90
                End Select

            Case SelectType.折弯尺寸
                strCurrentBendValue = txt参数.Text
                oBendConstraint.Radius.Expression = txt参数.Text

                Select Case oBendConstraint.Radius.Units
                    Case "mm"
                        TrackBar参数一.Value = oBendConstraint.Radius.Value * 10
                        TrackBar参数一.Minimum = TrackBar参数一.Value - intStep * 10
                        TrackBar参数一.Maximum = TrackBar参数一.Value + intStep * 10

                    Case "cm"
                        TrackBar参数一.Value = oBendConstraint.Radius.Value
                        TrackBar参数一.Minimum = TrackBar参数一.Value - intStep
                        TrackBar参数一.Maximum = TrackBar参数一.Value + intStep
                End Select

            Case SelectType.三维草图尺寸
                strCurrentDimensionValue3D = txt参数.Text
                oDimensionConstraint3D.Parameter.Expression = txt参数.Text

                Select Case oDimensionConstraint3D.Parameter.Units
                    Case "mm"
                        TrackBar参数一.Value = oDimensionConstraint3D.Parameter.Value * 10
                        TrackBar参数一.Minimum = TrackBar参数一.Value - intStep * 10
                        TrackBar参数一.Maximum = TrackBar参数一.Value + intStep * 10

                    Case "cm"
                        TrackBar参数一.Value = oDimensionConstraint3D.Parameter.Value
                        TrackBar参数一.Minimum = TrackBar参数一.Value - intStep
                        TrackBar参数一.Maximum = TrackBar参数一.Value + intStep
                    Case "deg"
                        TrackBar参数一.Value = oDimensionConstraint3D.Parameter.Value * 180 / Math.PI
                        TrackBar参数一.Minimum = TrackBar参数一.Value - 90
                        TrackBar参数一.Maximum = TrackBar参数一.Value + 90

                End Select

            Case SelectType.插入约束
                strCurrentConstraintValue = txt参数.Text
                oInsertConstraint.Distance.Expression = txt参数.Text

                Select Case oInsertConstraint.Distance.Units
                    Case "mm"
                        TrackBar参数一.Value = oInsertConstraint.Distance.Value * 10
                        TrackBar参数一.Minimum = TrackBar参数一.Value - intStep * 10
                        TrackBar参数一.Maximum = TrackBar参数一.Value + intStep * 10

                    Case "cm"
                        TrackBar参数一.Value = oInsertConstraint.Distance.Value
                        TrackBar参数一.Minimum = TrackBar参数一.Value - intStep
                        TrackBar参数一.Maximum = TrackBar参数一.Value + intStep
                End Select

            Case SelectType.角度约束
                strCurrentConstraintValue = txt参数.Text
                oAngleConstraint.Angle.Expression = txt参数.Text

                TrackBar参数一.Value = oAngleConstraint.Angle.Value * 180 / Math.PI
                TrackBar参数一.Minimum = TrackBar参数一.Value - 90
                TrackBar参数一.Maximum = TrackBar参数一.Value + 90


            Case SelectType.配合约束
                strCurrentConstraintValue = txt参数.Text
                oMateConstraint.Offset.Expression = txt参数.Text

                Select Case oMateConstraint.Offset.Units
                    Case "mm"
                        TrackBar参数一.Value = oMateConstraint.Offset.Value * 10
                        TrackBar参数一.Minimum = TrackBar参数一.Value - intStep * 10
                        TrackBar参数一.Maximum = TrackBar参数一.Value + intStep * 10

                    Case "cm"
                        TrackBar参数一.Value = oMateConstraint.Offset.Value
                        TrackBar参数一.Minimum = TrackBar参数一.Value - intStep
                        TrackBar参数一.Maximum = TrackBar参数一.Value + intStep

                End Select

            Case SelectType.平面对齐约束
                strCurrentConstraintValue = txt参数.Text
                oFlushConstraint.Offset.Expression = txt参数.Text

                Select Case oFlushConstraint.Offset.Units
                    Case "mm"
                        TrackBar参数一.Value = oFlushConstraint.Offset.Value * 10
                        TrackBar参数一.Minimum = TrackBar参数一.Value - intStep * 10
                        TrackBar参数一.Maximum = TrackBar参数一.Value + intStep * 10

                    Case "cm"
                        TrackBar参数一.Value = oFlushConstraint.Offset.Value
                        TrackBar参数一.Minimum = TrackBar参数一.Value - intStep
                        TrackBar参数一.Maximum = TrackBar参数一.Value + intStep
                End Select
            Case SelectType.相切约束
                strCurrentConstraintValue = txt参数.Text
                oTangentConstraint.Offset.Expression = txt参数.Text

                Select Case oTangentConstraint.Offset.Units
                    Case "mm"
                        TrackBar参数一.Value = oTangentConstraint.Offset.Value * 10
                        TrackBar参数一.Minimum = TrackBar参数一.Value - intStep * 10
                        TrackBar参数一.Maximum = TrackBar参数一.Value + intStep * 10

                    Case "cm"
                        TrackBar参数一.Value = oTangentConstraint.Offset.Value
                        TrackBar参数一.Minimum = TrackBar参数一.Value - intStep
                        TrackBar参数一.Maximum = TrackBar参数一.Value + intStep
                End Select

        End Select

        lbl最小值.Text = TrackBar参数一.Minimum.ToString
        lbl最大值.Text = TrackBar参数一.Maximum.ToString

        oInventorDocument.Update()
        ThisApplication.ActiveView.Update()

        If oSelectType = SelectType.特征尺寸 Then
            oFeatureDimension.Parent.FeatureDimensions.Show()
        End If

    End Sub

    Private Sub FrmChangeValue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next

        Me.Icon = My.Resources.XHTool48

        ' 创建ToolTip控件并设置相关属性
        Dim toolTip As New ToolTip With {
            .AutoPopDelay = 0,
            .InitialDelay = 0,
            .ReshowDelay = 500
        }
        toolTip.SetToolTip(btn选择一, "选择一个尺寸")
        toolTip.SetToolTip(btn还原, "还原")
        toolTip.SetToolTip(btn应用, "应用")
        toolTip.SetToolTip(btn显示隐藏草图, "显示/隐藏尺寸所在的草图")

        ' 从资源文件中加载图标并设置到Button控件的Image属性中
        btn选择一.Image = My.Resources.选择16.ToBitmap
        btn还原.Image = My.Resources.还原16.ToBitmap
        btn应用.Image = My.Resources.确定16.ToBitmap
        btn显示隐藏草图.Image = My.Resources.可见16.ToBitmap

        If SelectDiameter() = True Then

        Else
            FormManager.CloseAndDisposeForm(Of FormEditDimension)()
            Exit Sub
        End If
        Me.Show()

    End Sub

    Private Sub Txt参数_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt参数.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Btn应用_Click(sender, e)
        End If
    End Sub

    Private Sub Btn显示隐藏草图_Click(sender As Object, e As EventArgs) Handles btn显示隐藏草图.Click
        If IsSketchShow = True Then
            oPlanarSketch.Visible = False
            IsSketchShow = False
            btn显示隐藏草图.Image = My.Resources.可见16.ToBitmap
        Else
            oPlanarSketch.Visible = True
            IsSketchShow = True
            btn显示隐藏草图.Image = My.Resources.不可见16.ToBitmap
        End If
    End Sub

    ''' <summary>
    ''' 选择尺寸、约束或草图
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SelectDiameter() As Boolean
        On Error Resume Next

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        Dim oSelectSet As Object = Nothing

        If oInventorDocument.SelectSet.Count > 0 Then
            oSelectSet = oInventorDocument.SelectSet(1)
        Else
            oSelectSet = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kAllEntitiesFilter, "选择要编辑的 草图、尺寸、约束，ESC键取消")

            If oSelectSet Is Nothing Then       '取消选择
                Me.Close()
                Exit Function
            End If
        End If

        If TypeOf oSelectSet Is FeatureDimension Then       '特征尺寸
            oSelectType = SelectType.特征尺寸

            oFeatureDimension = CType(oSelectSet, FeatureDimension)

            strCurrentName = oFeatureDimension.Parameter.Name
            strCurrentDimensionValue = oFeatureDimension.Parameter.Expression

            Me.Text = "编辑尺寸：" & strCurrentName
            txt参数.Text = strCurrentDimensionValue

            Select Case oFeatureDimension.Parameter.Units
                Case "mm"
                    TrackBar参数一.Minimum = oFeatureDimension.Parameter.Value * 10 - intStep * 10
                    TrackBar参数一.Maximum = oFeatureDimension.Parameter.Value * 10 + intStep * 10
                    TrackBar参数一.Value = oFeatureDimension.Parameter.Value * 10

                Case "cm"
                    TrackBar参数一.Minimum = oFeatureDimension.Parameter.Value - intStep
                    TrackBar参数一.Maximum = oFeatureDimension.Parameter.Value + intStep
                    TrackBar参数一.Value = oFeatureDimension.Parameter.Value

                Case "deg"
                    TrackBar参数一.Minimum = oFeatureDimension.Parameter.Value * 180 / Math.PI - 90
                    TrackBar参数一.Maximum = oFeatureDimension.Parameter.Value * 180 / Math.PI + 90
                    TrackBar参数一.Value = oFeatureDimension.Parameter.Value * 180 / Math.PI

            End Select

        ElseIf TypeOf oSelectSet Is DimensionConstraint Then
            ' MessageBox.Show("2维草图")

            btn显示隐藏草图.Enabled = True
            btn显示隐藏草图.Image = My.Resources.不可见16.ToBitmap
            IsSketchShow = True

            oSelectType = SelectType.二维草图尺寸

            oDimensionConstraint = CType(oSelectSet, DimensionConstraint)

            oPlanarSketch = oDimensionConstraint.Parent

            strCurrentName = oDimensionConstraint.Parameter.Name
            strCurrentDimensionValue = oDimensionConstraint.Parameter.Expression

            Me.Text = "编辑尺寸：" & strCurrentName
            txt参数.Text = strCurrentDimensionValue

            Select Case oDimensionConstraint.Parameter.Units
                Case "mm"
                    TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value * 10 - intStep * 10
                    TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value * 10 + intStep * 10
                    TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 10

                Case "cm"
                    TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value - intStep
                    TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value + intStep
                    TrackBar参数一.Value = oDimensionConstraint.Parameter.Value

                Case "deg"
                    TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value * 180 / Math.PI - 90
                    TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value * 180 / Math.PI + 90
                    TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 180 / Math.PI

            End Select

        ElseIf TypeOf oSelectSet Is DimensionConstraint3D Then
            ' MessageBox.Show("3维草图")
            btn显示隐藏草图.Enabled = True
            btn显示隐藏草图.Image = My.Resources.不可见16.ToBitmap
            IsSketchShow = True

            oSelectType = SelectType.三维草图尺寸

            oDimensionConstraint3D = oSelectSet

            oPlanarSketch = oDimensionConstraint3D.Parent

            strCurrentName = oDimensionConstraint3D.Parameter.Name
            strCurrentDimensionValue3D = oDimensionConstraint3D.Parameter.Expression

            Me.Text = "编辑尺寸：" & strCurrentName
            txt参数.Text = strCurrentDimensionValue3D

            Select Case oDimensionConstraint3D.Parameter.Units
                Case "mm"
                    TrackBar参数一.Minimum = oDimensionConstraint3D.Parameter.Value * 10 - intStep * 10
                    TrackBar参数一.Maximum = oDimensionConstraint3D.Parameter.Value * 10 + intStep * 10
                    TrackBar参数一.Value = oDimensionConstraint3D.Parameter.Value * 10

                Case "cm"
                    TrackBar参数一.Minimum = oDimensionConstraint3D.Parameter.Value - intStep
                    TrackBar参数一.Maximum = oDimensionConstraint3D.Parameter.Value + intStep
                    TrackBar参数一.Value = oDimensionConstraint3D.Parameter.Value

                Case "deg"
                    TrackBar参数一.Minimum = oDimensionConstraint3D.Parameter.Value * 180 / Math.PI - 90
                    TrackBar参数一.Maximum = oDimensionConstraint3D.Parameter.Value * 180 / Math.PI + 90
                    TrackBar参数一.Value = oDimensionConstraint3D.Parameter.Value * 180 / Math.PI

            End Select

            lbl最小值.Text = TrackBar参数一.Minimum.ToString
            lbl最大值.Text = TrackBar参数一.Maximum.ToString


        ElseIf TypeOf oSelectSet Is Inventor.Sketch3D Then
            oSelectType = SelectType.三维草图

            oPlanarSketch = oSelectSet
            oPlanarSketch.Visible = True

            btn显示隐藏草图.Enabled = True
            IsSketchShow = True
            btn显示隐藏草图.Image = My.Resources.不可见16.ToBitmap

        ElseIf TypeOf oSelectSet Is Inventor.Sketch Then
            oSelectType = SelectType.二维草图

            oPlanarSketch = oSelectSet
            oPlanarSketch.Visible = True

            IsSketchShow = True
            btn显示隐藏草图.Enabled = True
            btn显示隐藏草图.Image = My.Resources.不可见16.ToBitmap

        ElseIf TypeOf oSelectSet Is BendConstraint Then
            ' MessageBox.Show("折弯尺寸")
            btn显示隐藏草图.Enabled = False

            oSelectType = SelectType.折弯尺寸

            oBendConstraint = oSelectSet

            oPlanarSketch = oBendConstraint.Parent

            strCurrentName = oBendConstraint.Radius.Name
            strCurrentBendValue = oBendConstraint.Radius.Expression

            Me.Text = "编辑尺寸：" & strCurrentName
            txt参数.Text = strCurrentBendValue

            Select Case oBendConstraint.Radius.Units
                Case "mm"
                    TrackBar参数一.Minimum = oBendConstraint.Radius.Value * 10 - intStep * 10
                    TrackBar参数一.Maximum = oBendConstraint.Radius.Value * 10 + intStep * 10
                    TrackBar参数一.Value = oBendConstraint.Radius.Value * 10

                Case "cm"
                    TrackBar参数一.Minimum = oBendConstraint.Radius.Value - intStep
                    TrackBar参数一.Maximum = oBendConstraint.Radius.Value + intStep
                    TrackBar参数一.Value = oBendConstraint.Radius.Value

            End Select
        ElseIf TypeOf oSelectSet Is FlushConstraint Then
            ' MessageBox.Show("平面对齐约束")
            btn显示隐藏草图.Enabled = False

            oSelectType = SelectType.平面对齐约束

            oFlushConstraint = oSelectSet

            strCurrentName = oFlushConstraint.Offset.Name
            strCurrentConstraintValue = oFlushConstraint.Offset.Expression

            Me.Text = "编辑尺寸：" & strCurrentName
            txt参数.Text = strCurrentConstraintValue

            Select Case oFlushConstraint.Offset.Units
                Case "mm"
                    TrackBar参数一.Minimum = oFlushConstraint.Offset.Value * 10 - intStep * 10
                    TrackBar参数一.Maximum = oFlushConstraint.Offset.Value * 10 + intStep * 10
                    TrackBar参数一.Value = oFlushConstraint.Offset.Value * 10
                Case "cm"
                    TrackBar参数一.Minimum = oFlushConstraint.Offset.Value - intStep
                    TrackBar参数一.Maximum = oFlushConstraint.Offset.Value + intStep
                    TrackBar参数一.Value = oFlushConstraint.Offset.Value
            End Select

        ElseIf TypeOf oSelectSet Is MateConstraint Then
            ' MessageBox.Show("配合约束")
            btn显示隐藏草图.Enabled = False

            oSelectType = SelectType.配合约束

            oMateConstraint = oSelectSet

            strCurrentName = oMateConstraint.Offset.Name
            strCurrentConstraintValue = oMateConstraint.Offset.Expression

            Me.Text = "编辑尺寸：" & strCurrentName
            txt参数.Text = strCurrentConstraintValue

            Select Case oMateConstraint.Offset.Units
                Case "mm"
                    TrackBar参数一.Minimum = oMateConstraint.Offset.Value * 10 - intStep * 10
                    TrackBar参数一.Maximum = oMateConstraint.Offset.Value * 10 + intStep * 10
                    TrackBar参数一.Value = oMateConstraint.Offset.Value * 10
                Case "cm"
                    TrackBar参数一.Minimum = oMateConstraint.Offset.Value - intStep
                    TrackBar参数一.Maximum = oMateConstraint.Offset.Value + intStep
                    TrackBar参数一.Value = oMateConstraint.Offset.Value

            End Select

        ElseIf TypeOf oSelectSet Is AngleConstraint Then
            ' MessageBox.Show("角度约束")
            btn显示隐藏草图.Enabled = False

            oSelectType = SelectType.角度约束

            oAngleConstraint = oSelectSet

            strCurrentName = oAngleConstraint.Angle.Name
            strCurrentConstraintValue = oAngleConstraint.Angle.Value * 180 / Math.PI

            Me.Text = "编辑尺寸：" & strCurrentName
            txt参数.Text = strCurrentConstraintValue

            TrackBar参数一.Minimum = oAngleConstraint.Angle.Value * 180 / Math.PI - 90
            TrackBar参数一.Maximum = oAngleConstraint.Angle.Value * 180 / Math.PI + 90
            TrackBar参数一.Value = oAngleConstraint.Angle.Value * 180 / Math.PI

        ElseIf TypeOf oSelectSet Is Inventor.InsertConstraint Then
            ' MessageBox.Show("插入约束")
            btn显示隐藏草图.Enabled = False

            oSelectType = SelectType.插入约束

            oInsertConstraint = oSelectSet

            strCurrentName = oInsertConstraint.Distance.Name
            strCurrentConstraintValue = oInsertConstraint.Distance.Expression

            Me.Text = "编辑尺寸：" & strCurrentName
            txt参数.Text = strCurrentConstraintValue

            Select Case oInsertConstraint.Distance.Units
                Case "mm"

                    TrackBar参数一.Minimum = oInsertConstraint.Distance.Value * 10 - intStep * 10
                    TrackBar参数一.Maximum = oInsertConstraint.Distance.Value * 10 + intStep * 10
                    TrackBar参数一.Value = oInsertConstraint.Distance.Value * 10
                Case "cm"

                    TrackBar参数一.Minimum = oInsertConstraint.Distance.Value - intStep
                    TrackBar参数一.Maximum = oInsertConstraint.Distance.Value + intStep
                    TrackBar参数一.Value = oInsertConstraint.Distance.Value
            End Select

        ElseIf TypeOf oSelectSet Is TangentConstraint Then
            btn显示隐藏草图.Enabled = False

            oSelectType = SelectType.相切约束

            oTangentConstraint = oSelectSet

            strCurrentName = oTangentConstraint.Offset.Name
            strCurrentConstraintValue = oTangentConstraint.Offset.Expression

            Me.Text = "编辑尺寸：" & strCurrentName
            txt参数.Text = strCurrentConstraintValue

            Select Case oTangentConstraint.Offset.Units
                Case "mm"
                    TrackBar参数一.Minimum = oTangentConstraint.Offset.Value * 10 - intStep * 10
                    TrackBar参数一.Maximum = oTangentConstraint.Offset.Value * 10 + intStep * 10
                    TrackBar参数一.Value = oTangentConstraint.Offset.Value * 10
                Case "cm"

                    TrackBar参数一.Minimum = oTangentConstraint.Offset.Value - intStep
                    TrackBar参数一.Maximum = oTangentConstraint.Offset.Value + intStep
                    TrackBar参数一.Value = oTangentConstraint.Offset.Value
            End Select

        ElseIf TypeOf oSelectSet Is FaceFeature Then        '平板特征
            Dim oFaceFeature As FaceFeature
            oFaceFeature = CType(oSelectSet, FaceFeature)
            oFaceFeature.FeatureDimensions.Show()

        ElseIf TypeOf oSelectSet Is FlangeFeature Then       '凸缘特征
            Dim oFlangeFeature As FlangeFeature
            oFlangeFeature = CType(oSelectSet, FlangeFeature)
            oFlangeFeature.FeatureDimensions.Show()

        ElseIf TypeOf oSelectSet Is CutFeature Then          '剪切特征
            Dim oCutFeature As CutFeature
            oCutFeature = CType(oSelectSet, CutFeature)
            oCutFeature.FeatureDimensions.Show()

        ElseIf TypeOf oSelectSet Is CornerChamferFeature Then  '倒角
            Dim oCornerChamferFeature As CornerChamferFeature
            oCornerChamferFeature = CType(oSelectSet, CornerChamferFeature)
            oCornerChamferFeature.FeatureDimensions.Show()


        ElseIf TypeOf oSelectSet Is ChamferFeature Then  '倒角
            Dim oChamferFeature As ChamferFeature
            oChamferFeature = CType(oSelectSet, ChamferFeature)
            oChamferFeature.FeatureDimensions.Show()

        ElseIf TypeOf oSelectSet Is CornerRoundFeature Then                '圆角
            Dim oCornerRoundFeature As CornerRoundFeature
            oCornerRoundFeature = CType(oSelectSet, CornerRoundFeature)
            oCornerRoundFeature.FeatureDimensions.Show()

        ElseIf TypeOf oSelectSet Is FilletFeature Then '三维圆角
            Dim oFilletFeature As FilletFeature
            oFilletFeature = CType(oSelectSet, FilletFeature)
            oFilletFeature.FeatureDimensions.Show()

        ElseIf TypeOf oSelectSet Is ContourFlangeFeature Then '异形板
            Dim oContourFlangeFeature As ContourFlangeFeature
            oContourFlangeFeature = CType(oSelectSet, ContourFlangeFeature)
            oContourFlangeFeature.FeatureDimensions.Show()

        ElseIf TypeOf oSelectSet Is SweepFeature Then  '扫掠
            Dim oSweepFeature As SweepFeature
            oSweepFeature = CType(oSelectSet, SweepFeature)
            oSweepFeature.FeatureDimensions.Show()

        ElseIf TypeOf oSelectSet Is ExtrudeFeature Then '拉伸
            Dim oExtrudeFeature As ExtrudeFeature
            oExtrudeFeature = CType(oSelectSet, ExtrudeFeature)
            oExtrudeFeature.FeatureDimensions.Show()

        ElseIf TypeOf oSelectSet Is HoleFeature Then '孔
            Dim oHoleFeature As HoleFeature
            oHoleFeature = CType(oSelectSet, HoleFeature)
            oHoleFeature.FeatureDimensions.Show()

        ElseIf TypeOf oSelectSet Is RevolveFeature Then '旋转
            Dim oRevolveFeature As RevolveFeature
            oRevolveFeature = CType(oSelectSet, RevolveFeature)
            oRevolveFeature.FeatureDimensions.Show()

        ElseIf TypeOf oSelectSet Is LoftFeature Then '放样
            Dim oLoftFeature As LoftFeature
            oLoftFeature = CType(oSelectSet, LoftFeature)
            oLoftFeature.FeatureDimensions.Show()

        ElseIf TypeOf oSelectSet Is ShellFeature Then  '抽壳
            Dim oShellFeature As ShellFeature
            oShellFeature = CType(oSelectSet, ShellFeature)
            oShellFeature.FeatureDimensions.Show()

        Else
            Return False
        End If

        lbl最小值.Text = TrackBar参数一.Minimum.ToString
        lbl最大值.Text = TrackBar参数一.Maximum.ToString

        Return True
    End Function


End Class
