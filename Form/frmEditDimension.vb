Imports System.Windows.Forms
Imports Inventor
Imports System.Drawing

Public Class frmEditDimension

    Private strDimensionConstraintFileName As String
    Private strDimensionConstraintName As String
    Private strDimensionConstraintValue As String

    Private strDimensionConstraintValue3D As String   '三维还原值

    Private oDimensionConstraint As DimensionConstraint
    Private oDimensionConstraint3D As DimensionConstraint3D
    Private IsDimensionConstraint3D As Boolean  '是否为3维尺寸


    Private Sub btn选择一_Click(sender As Object, e As EventArgs) Handles btn选择一.Click
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument


        'oDimensionConstraint = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kSketchDimConstraintFilter, "选择要编辑的尺寸，ESC键取消")
        'If oDimensionConstraint Is Nothing Then       '取消选择
        '    Exit Sub
        'End If

        Dim oSelectSet As Object = Nothing

        oSelectSet = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kAllEntitiesFilter, "选择要编辑的尺寸，ESC键取消")

        If oSelectSet Is Nothing Then       '取消选择
            Me.Close()
            Exit Sub
        End If


        If TypeOf oSelectSet Is DimensionConstraint Then
            'MsgBox("2维草图")

            IsDimensionConstraint3D = False

            oDimensionConstraint = oSelectSet
            strDimensionConstraintName = oDimensionConstraint.Parameter.Name
            strDimensionConstraintValue = oDimensionConstraint.Parameter.Expression

            Me.Text = "编辑尺寸：" & strDimensionConstraintName
            txt参数.Text = strDimensionConstraintValue

            Select Case oDimensionConstraint.Parameter.Units
                Case "mm"
                    TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value * 10 - 50
                    TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value * 10 + 50
                    TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 10

                Case "cm"
                    TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value - 5
                    TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value + 5
                    TrackBar参数一.Value = oDimensionConstraint.Parameter.Value
                Case "deg"
                    TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value * 180 / Math.PI - 45
                    TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value * 180 / Math.PI + 45
                    TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 180 / Math.PI
            End Select

        ElseIf TypeOf oSelectSet Is DimensionConstraint3D Then
            'MsgBox("3维草图")

            IsDimensionConstraint3D = True

            oDimensionConstraint3D = oSelectSet
            strDimensionConstraintName = oDimensionConstraint3D.Parameter.Name
            strDimensionConstraintValue3D = oDimensionConstraint3D.Parameter.Expression

            Me.Text = "编辑尺寸：" & strDimensionConstraintName
            txt参数.Text = strDimensionConstraintValue3D

            Select Case oDimensionConstraint3D.Parameter.Units
                Case "mm"
                    TrackBar参数一.Minimum = oDimensionConstraint3D.Parameter.Value * 10 - 50
                    TrackBar参数一.Maximum = oDimensionConstraint3D.Parameter.Value * 10 + 50
                    TrackBar参数一.Value = oDimensionConstraint3D.Parameter.Value * 10

                Case "cm"
                    TrackBar参数一.Minimum = oDimensionConstraint3D.Parameter.Value - 5
                    TrackBar参数一.Maximum = oDimensionConstraint3D.Parameter.Value + 5
                    TrackBar参数一.Value = oDimensionConstraint3D.Parameter.Value
                Case "deg"
                    TrackBar参数一.Minimum = oDimensionConstraint3D.Parameter.Value * 180 / Math.PI - 45
                    TrackBar参数一.Maximum = oDimensionConstraint3D.Parameter.Value * 180 / Math.PI + 45
                    TrackBar参数一.Value = oDimensionConstraint3D.Parameter.Value * 180 / Math.PI
            End Select

        End If

       

    End Sub

    Private Sub TrackBar参数一_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar参数一.Scroll
        On Error Resume Next
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        If IsDimensionConstraint3D = False Then
            '二维草图
            Select Case oDimensionConstraint.Parameter.Units
                Case "mm"
                    oDimensionConstraint.Parameter.Value = TrackBar参数一.Value * 0.1
                Case "cm"
                    oDimensionConstraint.Parameter.Value = TrackBar参数一.Value
                Case "deg"
                    oDimensionConstraint.Parameter.Value = TrackBar参数一.Value * Math.PI / 180
            End Select

        Else
            '三维草图
            Select Case oDimensionConstraint3D.Parameter.Units
                Case "mm"
                    oDimensionConstraint3D.Parameter.Value = TrackBar参数一.Value * 0.1
                Case "cm"
                    oDimensionConstraint3D.Parameter.Value = TrackBar参数一.Value
                Case "deg"
                    oDimensionConstraint3D.Parameter.Value = TrackBar参数一.Value * Math.PI / 180
            End Select
        End If

        txt参数.Text = TrackBar参数一.Value

        oInventorDocument.Update()
        ThisApplication.ActiveView.Update()


    End Sub

    Private Sub btn还原_Click(sender As Object, e As EventArgs) Handles btn还原.Click
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument


        If IsDimensionConstraint3D = False Then
            '二维草图
            oDimensionConstraint.Parameter.Expression = strDimensionConstraintValue
            txt参数.Text = strDimensionConstraintValue

            Select Case oDimensionConstraint.Parameter.Units
                Case "mm"
                    TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value * 10 - 50
                    TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value * 10 + 50
                    TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 10
                Case "cm"
                    TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value - 5
                    TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value + 5
                    TrackBar参数一.Value = oDimensionConstraint.Parameter.Value
                Case "deg"
                    TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value * 180 / Math.PI - 45
                    TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value * 180 / Math.PI + 45
                    TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 180 / Math.PI
            End Select

        Else
            '三维草图
            oDimensionConstraint3D.Parameter.Expression = strDimensionConstraintValue3D
            txt参数.Text = strDimensionConstraintValue3D

            Select Case oDimensionConstraint3D.Parameter.Units
                Case "mm"
                    TrackBar参数一.Minimum = oDimensionConstraint3D.Parameter.Value * 10 - 50
                    TrackBar参数一.Maximum = oDimensionConstraint3D.Parameter.Value * 10 + 50
                    TrackBar参数一.Value = oDimensionConstraint3D.Parameter.Value * 10
                Case "cm"
                    TrackBar参数一.Minimum = oDimensionConstraint3D.Parameter.Value - 5
                    TrackBar参数一.Maximum = oDimensionConstraint3D.Parameter.Value + 5
                    TrackBar参数一.Value = oDimensionConstraint3D.Parameter.Value
                Case "deg"
                    TrackBar参数一.Minimum = oDimensionConstraint3D.Parameter.Value * 180 / Math.PI - 45
                    TrackBar参数一.Maximum = oDimensionConstraint3D.Parameter.Value * 180 / Math.PI + 45
                    TrackBar参数一.Value = oDimensionConstraint3D.Parameter.Value * 180 / Math.PI
            End Select

        End If


        oInventorDocument.Update()
        ThisApplication.ActiveView.Update()

    End Sub

    Private Sub frmChangeValue_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
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

            If IsDimensionConstraint3D = False Then
                '二维草图
                oDimensionConstraint.Parameter.Expression = strDimensionConstraintValue
            Else
                '三维草图
                oDimensionConstraint3D.Parameter.Expression = strDimensionConstraintValue3D
            End If

            oInventorDocument.Update()
            ThisApplication.ActiveView.Update()
            'End if
        Catch

        End Try

    End Sub

    Private Sub btn应用_Click(sender As Object, e As EventArgs) Handles btn应用.Click
        On Error Resume Next
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        If IsDimensionConstraint3D = False Then
            '二维草图
            strDimensionConstraintValue = txt参数.Text
            oDimensionConstraint.Parameter.Expression = txt参数.Text

            Select Case oDimensionConstraint.Parameter.Units
                Case "mm"
                    TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value * 10 - 50
                    TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value * 10 + 50
                    TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 10
                Case "cm"
                    TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value - 5
                    TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value + 5
                    TrackBar参数一.Value = oDimensionConstraint.Parameter.Value
                Case "deg"
                    TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value * 180 / Math.PI - 45
                    TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value * 180 / Math.PI + 45
                    TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 180 / Math.PI
            End Select

        Else
            '三维草图
            strDimensionConstraintValue3D = txt参数.Text
            oDimensionConstraint3D.Parameter.Expression = txt参数.Text

            Select Case oDimensionConstraint3D.Parameter.Units
                Case "mm"
                    TrackBar参数一.Minimum = oDimensionConstraint3D.Parameter.Value * 10 - 50
                    TrackBar参数一.Maximum = oDimensionConstraint3D.Parameter.Value * 10 + 50
                    TrackBar参数一.Value = oDimensionConstraint3D.Parameter.Value * 10
                Case "cm"
                    TrackBar参数一.Minimum = oDimensionConstraint3D.Parameter.Value - 5
                    TrackBar参数一.Maximum = oDimensionConstraint3D.Parameter.Value + 5
                    TrackBar参数一.Value = oDimensionConstraint3D.Parameter.Value
                Case "deg"
                    TrackBar参数一.Minimum = oDimensionConstraint3D.Parameter.Value * 180 / Math.PI - 45
                    TrackBar参数一.Maximum = oDimensionConstraint3D.Parameter.Value * 180 / Math.PI + 45
                    TrackBar参数一.Value = oDimensionConstraint3D.Parameter.Value * 180 / Math.PI
            End Select

        End If

        oInventorDocument.Update()
        ThisApplication.ActiveView.Update()

    End Sub

    Private Sub frmChangeValue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next

        ' 创建ToolTip控件并设置相关属性
        Dim toolTip As New ToolTip()
        toolTip.AutoPopDelay = 0
        toolTip.InitialDelay = 0
        toolTip.ReshowDelay = 500
        toolTip.SetToolTip(btn选择一, "选择一个尺寸")
        toolTip.SetToolTip(btn还原, "还原")
        toolTip.SetToolTip(btn应用, "应用")

        ' 从资源文件中加载图标并设置到Button控件的Image属性中
        btn选择一.Image = My.Resources.选择16.ToBitmap
        btn还原.Image = My.Resources.还原16.ToBitmap
        btn应用.Image = My.Resources.确定16.ToBitmap

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        ' 是否已经选择了尺寸
        Dim oSelectSet As Object = Nothing

        If oInventorDocument.SelectSet.Count = 0 Then
            'oDimensionConstraint = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kSketchDimConstraintFilter And SelectionFilterEnum.kSketch3DDimConstraintFilter, "选择要编辑的尺寸，ESC键取消")
            oSelectSet = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kAllEntitiesFilter, "选择要编辑的尺寸，ESC键取消")

            If oSelectSet Is Nothing Then       '取消选择
                Me.Close()
                Exit Sub
            End If
        Else
            oSelectSet = oInventorDocument.SelectSet(1)
        End If

        If TypeOf oSelectSet Is DimensionConstraint Then
            'MsgBox("2维草图")

            IsDimensionConstraint3D = False

            oDimensionConstraint = oSelectSet
            strDimensionConstraintName = oDimensionConstraint.Parameter.Name
            strDimensionConstraintValue = oDimensionConstraint.Parameter.Expression

            Me.Text = "编辑尺寸：" & strDimensionConstraintName
            txt参数.Text = strDimensionConstraintValue

            Select Case oDimensionConstraint.Parameter.Units
                Case "mm"
                    TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value * 10 - 50
                    TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value * 10 + 50
                    TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 10

                Case "cm"
                    TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value - 5
                    TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value + 5
                    TrackBar参数一.Value = oDimensionConstraint.Parameter.Value
                Case "deg"
                    TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value * 180 / Math.PI - 45
                    TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value * 180 / Math.PI + 45
                    TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 180 / Math.PI
            End Select

        ElseIf TypeOf oSelectSet Is DimensionConstraint3D Then
            'MsgBox("3维草图")

            IsDimensionConstraint3D = True

            oDimensionConstraint3D = oSelectSet
            strDimensionConstraintName = oDimensionConstraint3D.Parameter.Name
            strDimensionConstraintValue3D = oDimensionConstraint3D.Parameter.Expression

            Me.Text = "编辑尺寸：" & strDimensionConstraintName
            txt参数.Text = strDimensionConstraintValue3D

            Select Case oDimensionConstraint3D.Parameter.Units
                Case "mm"
                    TrackBar参数一.Minimum = oDimensionConstraint3D.Parameter.Value * 10 - 50
                    TrackBar参数一.Maximum = oDimensionConstraint3D.Parameter.Value * 10 + 50
                    TrackBar参数一.Value = oDimensionConstraint3D.Parameter.Value * 10

                Case "cm"
                    TrackBar参数一.Minimum = oDimensionConstraint3D.Parameter.Value - 5
                    TrackBar参数一.Maximum = oDimensionConstraint3D.Parameter.Value + 5
                    TrackBar参数一.Value = oDimensionConstraint3D.Parameter.Value
                Case "deg"
                    TrackBar参数一.Minimum = oDimensionConstraint3D.Parameter.Value * 180 / Math.PI - 45
                    TrackBar参数一.Maximum = oDimensionConstraint3D.Parameter.Value * 180 / Math.PI + 45
                    TrackBar参数一.Value = oDimensionConstraint3D.Parameter.Value * 180 / Math.PI
            End Select

        Else
            Me.Close()
            Exit Sub
        End If

        Me.Show()

    End Sub

    Private Sub txt参数_KeyDown(sender As Object, e As KeyEventArgs) Handles txt参数.KeyDown
        'MsgBox(e.KeyCode)

        If e.KeyCode = Keys.Enter Then

            Dim oInventorDocument As Inventor.Document
            oInventorDocument = ThisApplication.ActiveEditDocument

            If IsDimensionConstraint3D = False Then
                '二维草图
                oDimensionConstraint.Parameter.Expression = txt参数.Text

                Select Case oDimensionConstraint.Parameter.Units
                    Case "mm"
                        TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value * 10 - 50
                        TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value * 10 + 50
                        TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 10
                    Case "cm"
                        TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value - 5
                        TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value + 5
                        TrackBar参数一.Value = oDimensionConstraint.Parameter.Value
                    Case "deg"
                        TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value * 180 / Math.PI - 45
                        TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value * 180 / Math.PI + 45
                        TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 180 / Math.PI
                End Select
            Else
                '三维草图
                oDimensionConstraint3D.Parameter.Expression = txt参数.Text

                Select Case oDimensionConstraint3D.Parameter.Units
                    Case "mm"
                        TrackBar参数一.Minimum = oDimensionConstraint3D.Parameter.Value * 10 - 50
                        TrackBar参数一.Maximum = oDimensionConstraint3D.Parameter.Value * 10 + 50
                        TrackBar参数一.Value = oDimensionConstraint3D.Parameter.Value * 10
                    Case "cm"
                        TrackBar参数一.Minimum = oDimensionConstraint3D.Parameter.Value - 5
                        TrackBar参数一.Maximum = oDimensionConstraint3D.Parameter.Value + 5
                        TrackBar参数一.Value = oDimensionConstraint3D.Parameter.Value
                    Case "deg"
                        TrackBar参数一.Minimum = oDimensionConstraint3D.Parameter.Value * 180 / Math.PI - 45
                        TrackBar参数一.Maximum = oDimensionConstraint3D.Parameter.Value * 180 / Math.PI + 45
                        TrackBar参数一.Value = oDimensionConstraint3D.Parameter.Value * 180 / Math.PI
                End Select

            End If

            oInventorDocument.Update()
            ThisApplication.ActiveView.Update()

        End If
    End Sub

End Class
