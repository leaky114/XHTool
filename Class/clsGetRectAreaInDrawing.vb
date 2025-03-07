Imports Inventor

Public Class ClsGetRectAreaInDrawing
    Private WithEvents OInteractEvents As InteractionEvents
    Private WithEvents OMouseEvents As MouseEvents
    Private WithEvents OSelectEvents As SelectEvents

    Private m_button As MouseButtonEnum
    Private m_continue As Boolean

    Private oStartPoint As Inventor.Point2d
    Private oEndPoint As Inventor.Point2d

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

        OInteractEvents = ThisApplication.CommandManager.CreateInteractionEvents

        OInteractEvents.SetCursor(CursorTypeEnum.kCursorBuiltInCrosshair)


        OMouseEvents = OInteractEvents.MouseEvents
        OMouseEvents.MouseMoveEnabled = False

        OSelectEvents = OInteractEvents.SelectEvents
        OSelectEvents.WindowSelectEnabled = True

        OInteractEvents.StatusBarText = Prompt

        OInteractEvents.Start()

        m_continue = True
        Do
            ThisApplication.UserInterfaceManager.DoEvents()
        Loop While m_continue

        OSelectEvents = Nothing
        OMouseEvents = Nothing

        OInteractEvents.Stop()


        oRectangularPoint.TopLeft = oStartPoint

        oRectangularPoint.TopRight = ThisApplication.TransientGeometry.CreatePoint2d(oEndPoint.X, oStartPoint.Y)

        oRectangularPoint.BottomRight = oEndPoint

        oRectangularPoint.BottomLeft = ThisApplication.TransientGeometry.CreatePoint2d(oStartPoint.X, oEndPoint.Y)

        oRectangularPoint.Length = Math.Abs(oRectangularPoint.TopLeft.X - oRectangularPoint.TopRight.X)

        oRectangularPoint.Width = Math.Abs(oRectangularPoint.TopLeft.Y - oRectangularPoint.BottomLeft.Y)

        oRectangularPoint.Center = ThisApplication.TransientGeometry.CreatePoint2d((oRectangularPoint.TopLeft.X + oRectangularPoint.TopRight.X) / 2,
                                                                                   (oRectangularPoint.TopLeft.Y + oRectangularPoint.BottomLeft.Y) / 2)

        Return oRectangularPoint

    End Function

    Private Sub Mouse_OnMouseDown(Button As MouseButtonEnum, ShiftKeys As ShiftStateEnum, ModelPosition As Point,
                                     ViewPosition As Point2d, View As View) Handles OMouseEvents.OnMouseDown
        If Button = m_button Then
            oStartPoint = ThisApplication.TransientGeometry.CreatePoint2d(ModelPosition.X, ModelPosition.Y)


        End If

        'MsgBox(strPoints)

    End Sub

    Private Sub Mouse_OnMouseUp(Button As MouseButtonEnum, ShiftKeys As ShiftStateEnum, ModelPosition As Point,
                                    ViewPosition As Point2d, View As View) Handles OMouseEvents.OnMouseUp
        If Button = m_button Then
            oEndPoint = ThisApplication.TransientGeometry.CreatePoint2d(ModelPosition.X, ModelPosition.Y)

        End If
        'MsgBox(strPoints)

        m_continue = False
    End Sub

End Class
