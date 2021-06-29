
Imports Inventor

'//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
'// Use: Implements a simple user interaction. User picks up an entity and its type will be displayed.
'//
'//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
Public Class clsDrawSlot

    Private mApplication As Inventor.Application
    Private mInteractionEvents As InteractionEvents
    Private mSelectEvents As SelectEvents
    Private mMouseEvents As MouseEvents
    Private mMousePosition As MouseEvents


    Public Sub New(ByVal oApplication As Inventor.Application)

        mApplication = oApplication

        'Initialize events
        mInteractionEvents = mApplication.CommandManager.CreateInteractionEvents()
        mSelectEvents = mInteractionEvents.SelectEvents
        mMouseEvents = mInteractionEvents.MouseEvents

        'Set event handler VB.Net Style
        AddHandler mSelectEvents.OnSelect, AddressOf Me.mSelectEvents_OnSelect
        AddHandler mInteractionEvents.OnTerminate, AddressOf Me.mInteractionEvents_OnTerminate

        'Clear filter and set new ones if needed
        mSelectEvents.ClearSelectionFilter()

        'Always Disable mouse move if not needed for performances
        mSelectEvents.MouseMoveEnabled = False
        mSelectEvents.Enabled = True
        mSelectEvents.SingleSelectEnabled = True

        AddHandler mMouseEvents.OnMouseClick, AddressOf mMousePostion_Click
        mMouseEvents.MouseMoveEnabled = True
        mMouseEvents.PointInferenceEnabled = True


        'Remember to Start/Stop the interaction event
        mInteractionEvents.Start()

    End Sub

    Public Sub CleanUp()

        'Remove handlers
        RemoveHandler mSelectEvents.OnSelect, AddressOf Me.mSelectEvents_OnSelect
        RemoveHandler mInteractionEvents.OnTerminate, AddressOf Me.mInteractionEvents_OnTerminate

        mSelectEvents = Nothing
        mInteractionEvents = Nothing

    End Sub


    'OnMouseClick(Button As MouseButtonEnum, ShiftKeys As ShiftStateEnum, ModelPosition As Point, ViewPosition As Point2d, view As View)
    Public Sub mMousePostion_Click(ByVal Button As MouseButtonEnum, ByVal ShiftKeys As ShiftStateEnum, ByVal ModelPosition As Point, _
                                   ByVal ViewPosition As Point2d, ByVal view As View)

        OPosition(0) = ModelPosition

        Dim planarSketch As PlanarSketch
        planarSketch = ThisApplication.ActiveEditObject

        Dim transientGeometry As TransientGeometry

        transientGeometry = ThisApplication.TransientGeometry

        'start a transaction so the slot will be within a single undo step
        Dim createSlotTransaction As Transaction
        createSlotTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "绘制槽孔")
        'If TempPoint(0) Is Nothing Then

        'Else
        '    TempPoint(0).Delete()
        'End If

        TempPoint(0) = planarSketch.SketchPoints.Add(transientGeometry.CreatePoint2d(OPosition(0).X, OPosition(0).Y))

        createSlotTransaction.End()


        mInteractionEvents.Stop()


    End Sub

    Private Sub mSelectEvents_OnSelect(ByVal JustSelectedEntities As Inventor.ObjectsEnumerator, ByVal SelectionDevice As Inventor.SelectionDeviceEnum, ByVal ModelPosition As Inventor.Point, ByVal ViewPosition As Inventor.Point2d, ByVal View As Inventor.View)

        If JustSelectedEntities.Count <> 0 Then

            Dim selectedObj As Object = JustSelectedEntities(1)
            System.Windows.Forms.MessageBox.Show("Selected Entity: " & TypeName(selectedObj), "Simple Interaction")

        End If

    End Sub

    Private Sub mInteractionEvents_OnTerminate()
        CleanUp()
    End Sub

End Class