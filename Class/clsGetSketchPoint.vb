Imports Inventor

''' <summary>
''' 获取鼠标点击的点坐标
''' </summary>
''' <remarks></remarks>
Public Class ClsGetSketchPoint
    Private WithEvents OInteractionEvents As InteractionEvents
    Private WithEvents OMouseEvents As MouseEvents

    Private m_position As Point
    Private m_button As MouseButtonEnum
    Private m_continue As Boolean

    ''' <summary>
    ''' 获取鼠标点击坐标
    ''' </summary>
    ''' <param name="StrInformation">提示信息</param>
    ''' <param name="button">鼠标点击的哪个键</param>
    ''' <returns></returns>
    Public Function GetSketchPoint(StrInformation As String, button As MouseButtonEnum) As Inventor.Point
        m_position = Nothing
        m_button = button

        OInteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        OMouseEvents = OInteractionEvents.MouseEvents

        OInteractionEvents.StatusBarText = StrInformation

        OInteractionEvents.Start()

        m_continue = True
        Do
            ThisApplication.UserInterfaceManager.DoEvents()
        Loop While m_continue

        OInteractionEvents.Stop()

        Return m_position
    End Function

    Private Sub Mouse_OnMouseClick(Button As MouseButtonEnum, ShiftKeys As ShiftStateEnum, ModelPosition As Point,
                                     ViewPosition As Point2d, View As View) Handles OMouseEvents.OnMouseClick
        If Button = m_button Then
            m_position = ThisApplication.TransientGeometry.CreatePoint(ModelPosition.X, ModelPosition.Y, ModelPosition.Z)
        End If

        m_continue = False
    End Sub

End Class
