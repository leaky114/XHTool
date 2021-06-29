
Imports Inventor

'//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
'// Use: Implements a simple user interaction. User picks up an entity and its type will be displayed.
'//
'//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
Public Class clsDrawVLine

    Private mApplication As Inventor.Application
    Private mInteractionEvents As InteractionEvents
    Private mSelectEvents As SelectEvents
    Private mMouseEvents As MouseEvents
    Private mMousePosition As MouseEvents


    Public Sub New(ByVal oApplication As Inventor.Application)

        mApplication = oApplication

        'Initialize events
        mInteractionEvents = mApplication.CommandManager.CreateInteractionEvents()
        mMouseEvents = mInteractionEvents.MouseEvents
        AddHandler mMouseEvents.OnMouseClick, AddressOf mMousePostion_Click
        mMouseEvents.MouseMoveEnabled = True
        mMouseEvents.PointInferenceEnabled = True


        'Remember to Start/Stop the interaction event
        mInteractionEvents.Start()

    End Sub



    'OnMouseClick(Button As MouseButtonEnum, ShiftKeys As ShiftStateEnum, ModelPosition As Point, ViewPosition As Point2d, view As View)
    Public Sub mMousePostion_Click(ByVal Button As MouseButtonEnum, ByVal ShiftKeys As ShiftStateEnum, ByVal ModelPosition As Point, ByVal ViewPosition As Point2d, ByVal view As View)

        Dim LineLenth As Double        '厘米为单位
        Dim sLineLenth As String

        Dim OPosition As Point


        OPosition = ModelPosition
        mInteractionEvents.Stop()

        Try

            sLineLenth = InputBox("输入直线长度(mm)。", "绘制直线")

            If sLineLenth = "" Then
                Exit Sub
            End If

            LineLenth = Val(sLineLenth)

            If (LineLenth > 0) Then
                LineLenth = LineLenth / 10
                'draw the sketch for the slot
                Dim planarSketch As PlanarSketch
                planarSketch = ThisApplication.ActiveEditObject

                Dim oline As SketchLine

                Dim transientGeometry As TransientGeometry

                transientGeometry = ThisApplication.TransientGeometry

                'start a transaction so the slot will be within a single undo step
                Dim createSlotTransaction As Transaction
                createSlotTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "绘制直线")

                'draw the lines and arcs that make up the shape of the slot

                oline = planarSketch.SketchLines.AddByTwoPoints(transientGeometry.CreatePoint2d(OPosition.X, OPosition.Y), _
                                                                 transientGeometry.CreatePoint2d(OPosition.X, OPosition.Y + LineLenth))


                planarSketch.DimensionConstraints.AddTwoPointDistance(oline.StartSketchPoint, oline.EndSketchPoint, DimensionOrientationEnum.kAlignedDim, transientGeometry.CreatePoint2d(OPosition.X + LineLenth * 0.5, OPosition.Y + 0.2))

                'end the transactio
                createSlotTransaction.End()

            Else

                MsgBox("请输入有效的长度。")

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'Private Sub mSelectEvents_OnSelect(ByVal JustSelectedEntities As Inventor.ObjectsEnumerator, ByVal SelectionDevice As Inventor.SelectionDeviceEnum, ByVal ModelPosition As Inventor.Point, ByVal ViewPosition As Inventor.Point2d, ByVal View As Inventor.View)

    '    If JustSelectedEntities.Count <> 0 Then

    '        Dim selectedObj As Object = JustSelectedEntities(1)
    '        System.Windows.Forms.MessageBox.Show("Selected Entity: " & TypeName(selectedObj), "Simple Interaction")

    '    End If

    'End Sub

    'Private Sub mInteractionEvents_OnTerminate()
    '    CleanUp()
    'End Sub

End Class