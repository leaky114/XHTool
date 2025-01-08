Imports Inventor

Public Class clsGetRectAreaInDrawing
    Private WithEvents oInteractEvents As InteractionEvents
    Private WithEvents oMouseEvents As MouseEvents
    Private WithEvents oSelectEvents As SelectEvents

    Private m_button As MouseButtonEnum
    Private m_continue As Boolean

    Private oStartPoint As Inventor.Point2d
    Private oEndPoint As Inventor.Point2d

    Private oClientGraphics As ClientGraphics

    Private oRectangularPoint As RectangularPoint

    ''' <summary>
    ''' 在工程图里面用鼠标选择一个矩形范围
    ''' </summary>
    ''' <param name="Prompt"></param>
    ''' <param name="Button"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetRectAreaInDrawing(Prompt As String, button As MouseButtonEnum) As RectangularPoint
        oStartPoint = Nothing
        oEndPoint = Nothing
        m_button = button

        oInteractEvents = ThisApplication.CommandManager.CreateInteractionEvents

        oInteractEvents.SetCursor(CursorTypeEnum.kCursorBuiltInCrosshair)


        oMouseEvents = oInteractEvents.MouseEvents
        oMouseEvents.MouseMoveEnabled = False

        oSelectEvents = oInteractEvents.SelectEvents
        oSelectEvents.WindowSelectEnabled = True

        oInteractEvents.StatusBarText = Prompt

        oInteractEvents.Start()

        m_continue = True
        Do
            ThisApplication.UserInterfaceManager.DoEvents()
        Loop While m_continue

        oSelectEvents = Nothing
        oMouseEvents = Nothing

        oInteractEvents.Stop()


        oRectangularPoint.TopLeft = oStartPoint

        oRectangularPoint.TopRight = ThisApplication.TransientGeometry.CreatePoint2d(oEndPoint.X, oStartPoint.Y)

        oRectangularPoint.BottomRight = oEndPoint

        oRectangularPoint.BottomLeft = ThisApplication.TransientGeometry.CreatePoint2d(oStartPoint.X, oEndPoint.Y)

        oRectangularPoint.Length = Math.Abs(oRectangularPoint.TopLeft.X - oRectangularPoint.TopRight.X)

        oRectangularPoint.Width = Math.Abs(oRectangularPoint.TopLeft.Y - oRectangularPoint.BottomLeft.Y)

        oRectangularPoint.Center = ThisApplication.TransientGeometry.CreatePoint2d((oRectangularPoint.TopLeft.X + oRectangularPoint.TopRight.X) / 2, _
                                                                                   (oRectangularPoint.TopLeft.Y + oRectangularPoint.BottomLeft.Y) / 2)

        Return oRectangularPoint

    End Function

    Private Sub m_mouse_OnMouseDown(Button As MouseButtonEnum, ShiftKeys As ShiftStateEnum, ModelPosition As Point, _
                                     ViewPosition As Point2d, View As View) Handles oMouseEvents.OnMouseDown
        If Button = m_button Then
            oStartPoint = ThisApplication.TransientGeometry.CreatePoint2d(ModelPosition.X, ModelPosition.Y)


        End If

        'MsgBox(strPoints)

    End Sub

    Private Sub m_mouse_OnMouseUp(Button As MouseButtonEnum, ShiftKeys As ShiftStateEnum, ModelPosition As Point, _
                                    ViewPosition As Point2d, View As View) Handles oMouseEvents.OnMouseUp
        If Button = m_button Then
            oEndPoint = ThisApplication.TransientGeometry.CreatePoint2d(ModelPosition.X, ModelPosition.Y)

        End If
        'MsgBox(strPoints)

        m_continue = False
    End Sub

End Class
