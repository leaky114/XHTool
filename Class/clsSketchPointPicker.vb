Imports Inventor
Imports System.Windows.Forms

Public Class SketchPointPicker

    Private sketch As Sketch
    Private pointA As Point2d
    Private pointB As Point2d
    Private invApp As Inventor.Application
    Private statusText As String
    Private tempGraphics As TransientGeometry
    Private tempLineNode As GraphicsNode

    Private WithEvents OInteractionEvents As InteractionEvents
    Private WithEvents OMouseEvents As MouseEvents

    Private m_position As Point2d
    Private m_button As MouseButtonEnum
    Private m_continue As Boolean
    Private oIntGraphics As InteractionGraphics

    Private oStartPoint As Point
    Private oEndPoint As Point

    Public Sub New()
        invApp = ThisApplication
        Initialize()
    End Sub

    Private Sub Initialize()
        ' 验证当前文档为零件文档
        Dim oDoc As PartDocument = TryCast(invApp.ActiveDocument, PartDocument)
        If oDoc Is Nothing Then
            MessageBox.Show(”请打开零件文档。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' 获取当前激活草图
        sketch = ThisApplication.ActiveEditObject
        If sketch Is Nothing Then
            MessageBox.Show(”请先激活草图。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' 初始化临时图形
        tempGraphics = invApp.TransientGeometry


        m_position = Nothing
        m_button = MouseButtonEnum.kLeftMouseButton
        oInteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        oMouseEvents = oInteractionEvents.MouseEvents
        oMouseEvents.MouseMoveEnabled = True

        oInteractionEvents.StatusBarText = ""
        oInteractionEvents.Start()

        m_continue = True
        Do
            ThisApplication.UserInterfaceManager.DoEvents()
        Loop While m_continue

        oInteractionEvents.Stop()



    End Sub

    Private Sub OnMouseMove(ByVal Button As Inventor.MouseButtonEnum, ByVal ShiftKeys As Inventor.ShiftStateEnum,
                            ByVal ModelPosition As Inventor.Point, ByVal ViewPosition As Inventor.Point2d, ByVal View As Inventor.View) _
                            Handles oMouseEvents.OnMouseMove
        ' 实时显示鼠标位置的草图坐标
        Dim sketchPoint As Point2d = sketch.ModelToSketchSpace(ModelPosition)
        invApp.StatusBarText = statusText & " - 当前坐标: (" & sketchPoint.X.ToString("F2") & ", " & sketchPoint.Y.ToString("F2") & ")"

        If pointA IsNot Nothing Then
            ' 清除之前的临时线段
            If tempLineNode IsNot Nothing Then
                tempLineNode.Delete()
                tempLineNode = Nothing
            End If

            ' 创建从点A到当前鼠标位置的临时线段
            Dim line As LineSegment2d = tempGraphics.CreateLineSegment2d(pointA, sketchPoint)
            tempLineNode = invApp.ActiveView.GraphicsManager.CreateGraphicsNode()
            tempLineNode.AddLineSegment(line)
            tempLineNode.Visible = True
        End If
    End Sub

    Private Sub OnMouseClick(ByVal Button As Inventor.MouseButtonEnum, ByVal ShiftKeys As Inventor.ShiftStateEnum,
                             ByVal ModelPosition As Inventor.Point, ByVal ViewPosition As Inventor.Point2d, ByVal View As Inventor.View) _
        Handles oMouseEvents.OnMouseClick
        If Button = Inventor.MouseButtonEnum.kLeftMouseButton Then
            Dim sketchPoint As Point2d = sketch.ModelToSketchSpace(ModelPosition)

            If pointA Is Nothing Then
                ' 选择中点A
                pointA = sketchPoint
                statusText = "请用鼠标左键点击选择端点B"
                invApp.StatusBarText = statusText
            ElseIf pointB Is Nothing Then
                ' 选择端点B
                pointB = sketchPoint
                CreateLine()
                ClearTempGraphics()

                invApp.StatusBarText = "线段创建成功！"
            End If
        End If
    End Sub

    Private Sub CreateLine()
        ' 计算另一端点C
        Dim oTG As TransientGeometry = invApp.TransientGeometry
        Dim pointC As Point2d = oTG.CreatePoint2d(
            2 * pointA.X - pointB.X,
            2 * pointA.Y - pointB.Y
        )

        ' 创建线段BC
        Dim line As SketchLine = sketch.SketchLines.AddByTwoPoints(pointB, pointC)

        ' 添加中点约束（可选）
        sketch.GeometricConstraints.AddMidpointConstraint(line, pointA)
    End Sub

    Private Sub ClearTempGraphics()
        ' 清除临时图形
        If tempLineNode IsNot Nothing Then
            tempLineNode.Delete()
            tempLineNode = Nothing
        End If
    End Sub
End Class

