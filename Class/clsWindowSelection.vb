Imports System.Collections.Generic
Imports Inventor

Public Class ClsWindowSelection
    Private WithEvents OInteractEvents As InteractionEvents
    Private WithEvents OSelectEvents As SelectEvents
    Private bTooltipEnabled As Boolean
    Public SelectedObjects As ObjectsEnumerator
    Private stillSelecting As Boolean = True

    Public Function WindowSelect() As List(Of ComponentOccurrence)
        oInteractEvents = ThisApplication.CommandManager.CreateInteractionEvents
        oInteractEvents.InteractionDisabled = False
        oSelectEvents = oInteractEvents.SelectEvents

        'filters for only parts/ leaf occurrences
        oSelectEvents.AddSelectionFilter(SelectionFilterEnum.kAssemblyLeafOccurrenceFilter)
        oSelectEvents.WindowSelectEnabled = True
        bTooltipEnabled = ThisApplication.GeneralOptions.ShowCommandPromptTooltips
        ThisApplication.GeneralOptions.ShowCommandPromptTooltips = True

        OInteractEvents.StatusBarText = "选择组件，ESC键完成。"
        OInteractEvents.Start()
        While stillSelecting
            ThisApplication.UserInterfaceManager.DoEvents()
        End While


        If SelectedObjects Is Nothing Then
            Return Nothing
        End If

        '获取被选择的组件列表
        Dim oSourceComponentList As New List(Of ComponentOccurrence)

        For Each SelectedObject In SelectedObjects
            oSourceComponentList.Add(SelectedObject)
        Next

        Return oSourceComponentList

    End Function

    Private Sub OInteractEvents_OnTerminate() Handles OInteractEvents.OnTerminate
        ThisApplication.GeneralOptions.ShowCommandPromptTooltips = bTooltipEnabled
        'oSelectEvents = Nothing
        OInteractEvents = Nothing
        stillSelecting = False

    End Sub

    Private Sub OSelectEvents_OnSelect(ByVal JustSelectedEntities As ObjectsEnumerator,
        ByVal SelectionDevice As SelectionDeviceEnum, ByVal ModelPosition As Point,
        ByVal ViewPosition As Point2d, ByVal View As View) Handles OSelectEvents.OnSelect

        SelectedObjects = OSelectEvents.SelectedEntities
    End Sub

    Private Sub OSelectEvents_OnUnSelect(UnSelectedEntities As ObjectsEnumerator,
        SelectionDevice As SelectionDeviceEnum, ModelPosition As Point,
        ViewPosition As Point2d, View As View) Handles OSelectEvents.OnUnSelect

        SelectedObjects = OSelectEvents.SelectedEntities
    End Sub
End Class
