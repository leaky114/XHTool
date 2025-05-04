Imports Inventor

''' <summary>
''' 获取鼠标点击的点坐标
''' </summary>
''' <remarks></remarks>
Public Class ClsGetPoint
    Private WithEvents OInteractionEvents As InteractionEvents
    Private WithEvents OMouseEvents As MouseEvents
    Private m_position As Point2d
    Private m_button As MouseButtonEnum
    Private m_continue As Boolean

    ''' <summary>
    ''' 获取鼠标点击坐标
    ''' </summary>
    ''' <param name="StrInformation">提示信息</param>
    ''' <param name="button">鼠标点击的哪个键</param>
    ''' <returns></returns>
    Public Function GetDrawingPoint(StrInformation As String, button As MouseButtonEnum, m_Cursor As CursorTypeEnum) As Point2d
        m_position = Nothing
        m_button = button

        OInteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents


        OMouseEvents = OInteractionEvents.MouseEvents

        OInteractionEvents.StatusBarText = StrInformation

        OInteractionEvents.SetCursor(m_Cursor)
        OInteractionEvents.Start()

        m_continue = True
        Do
            ThisApplication.UserInterfaceManager.DoEvents()
        Loop While m_continue

        OInteractionEvents.Stop()

        GetDrawingPoint = m_position
    End Function

    Private Sub Mouse_OnMouseClick(Button As MouseButtonEnum, ShiftKeys As ShiftStateEnum, ModelPosition As Point,
                                     ViewPosition As Point2d, View As View) Handles OMouseEvents.OnMouseClick
        If Button = m_button Then
            m_position = ThisApplication.TransientGeometry.CreatePoint2d(ModelPosition.X, ModelPosition.Y)
        End If

        m_continue = False
    End Sub

End Class
