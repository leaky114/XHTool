Imports Inventor

Public Class clsGetPoint
    Private WithEvents m_interaction As InteractionEvents
    Private WithEvents m_mouse As MouseEvents
    Private m_position As Point2d
    Private m_button As MouseButtonEnum
    Private m_continue As Boolean


    Public Function GetDrawingPoint(Prompt As String, button As MouseButtonEnum) As Point2d
        m_position = Nothing
        m_button = button

        m_interaction = ThisApplication.CommandManager.CreateInteractionEvents
        m_mouse = m_interaction.MouseEvents

        m_interaction.StatusBarText = Prompt

        m_interaction.Start()

        m_continue = True
        Do
            ThisApplication.UserInterfaceManager.DoEvents()
        Loop While m_continue

        m_interaction.Stop()

        GetDrawingPoint = m_position
    End Function


    Private Sub m_mouse_OnMouseClick(Button As MouseButtonEnum, ShiftKeys As ShiftStateEnum, ModelPosition As Point, _
                                     ViewPosition As Point2d, View As View) Handles m_mouse.OnMouseClick
        If Button = m_button Then
            m_position = ThisApplication.TransientGeometry.CreatePoint2d(ModelPosition.X, ModelPosition.Y)
        End If

        m_continue = False
    End Sub
End Class
