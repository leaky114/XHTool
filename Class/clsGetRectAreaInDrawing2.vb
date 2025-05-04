Imports Inventor
Imports System.Math

Public Class ClsGetRectAreaInDrawing2
    Private WithEvents OInteractionEvents As InteractionEvents
    Private WithEvents OMouseEvents As MouseEvents

    Private m_position As Point2d
    Private m_button As MouseButtonEnum
    Private m_continue As Boolean
    Private oIntGraphics As InteractionGraphics

    Private oStartPoint As Point
    Private oEndPoint As Point
    'Private oMovePoint As Point2d

    Private oRectangularPoint As RectangularPoint


    ''' <summary>
    ''' 在工程图里面用鼠标获取一个矩形范围
    ''' </summary>
    ''' <param name="Prompt"></param>
    ''' <param name="Button"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetRectAreaInDrawing(Prompt As String, Button As MouseButtonEnum) As RectangularPoint
        m_position = Nothing
        m_button = Button
        OInteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorBuiltInCrosshair)

        OMouseEvents = OInteractionEvents.MouseEvents

        OMouseEvents.MouseMoveEnabled = True

        OInteractionEvents.StatusBarText = Prompt
        OInteractionEvents.Start()

        m_continue = True
        Do
            ThisApplication.UserInterfaceManager.DoEvents()
        Loop While m_continue

        OInteractionEvents.Stop()

        Return oRectangularPoint

    End Function

    Private Sub OMouseEvents_OnMouseDown(ByVal Button As MouseButtonEnum, ByVal ShiftKeys As ShiftStateEnum,
                                         ByVal ModelPosition As Point, ByVal ViewPosition As Point2d,
                                         ByVal View As View) Handles OMouseEvents.OnMouseDown

        If oStartPoint Is Nothing Then
            oStartPoint = ModelPosition
        Else

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            On Error Resume Next

            Dim oInteractionGraphics As InteractionGraphics = OInteractionEvents.InteractionGraphics
            Dim oDataSets As GraphicsDataSets = oInteractionGraphics.GraphicsDataSets
            Dim oClientGraphics As ClientGraphics = oInteractionGraphics.OverlayClientGraphics
            Dim oLineStripNode As GraphicsNode = oClientGraphics.Item(1)

            If Err.Number = 0 Then
                On Error GoTo 0
                ' An existing client graphics object was successfully obtained so clean up.
                oLineStripNode.Delete()

                oInteractionGraphics.UpdateOverlayGraphics(ThisApplication.ActiveView)

                ' update the display to see the results.
                'ThisApplication.ActiveView.Update()
            End If


            oStartPoint = Nothing
            oEndPoint = Nothing

            m_continue = False
        End If

    End Sub

    Private Sub OMouseEvents_OnMouseMove(ByVal Button As MouseButtonEnum, ByVal ShiftKeys As ShiftStateEnum, ByVal ModelPosition As Point,
                                         ByVal ViewPosition As Point2d, ByVal View As View) Handles OMouseEvents.OnMouseMove
        'On Error Resume Next

        If oStartPoint IsNot Nothing Then


            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            On Error Resume Next

            Dim oInteractionGraphics As InteractionGraphics = OInteractionEvents.InteractionGraphics
            Dim oDataSets As GraphicsDataSets = oInteractionGraphics.GraphicsDataSets
            Dim oClientGraphics As ClientGraphics = oInteractionGraphics.OverlayClientGraphics
            Dim oLineStripNode As GraphicsNode = oClientGraphics.Item(1)

            If Err.Number = 0 Then
                On Error GoTo 0
                ' An existing client graphics object was successfully obtained so clean up.
                oLineStripNode.Delete()

                oInteractionGraphics.UpdateOverlayGraphics(ThisApplication.ActiveView)

                ' update the display to see the results.
                'ThisApplication.ActiveView.Update()
            End If


            oEndPoint = ModelPosition

            OInteractionEvents.StatusBarText = "选择第二点"

            oRectangularPoint.TopLeft = oStartPoint

            oRectangularPoint.TopRight = ThisApplication.TransientGeometry.CreatePoint(oEndPoint.X, oStartPoint.Y)

            oRectangularPoint.BottomRight = oEndPoint

            oRectangularPoint.BottomLeft = ThisApplication.TransientGeometry.CreatePoint(oStartPoint.X, oEndPoint.Y)

            oRectangularPoint.Length = Math.Abs(oRectangularPoint.TopLeft.X - oRectangularPoint.TopRight.X)

            oRectangularPoint.Width = Math.Abs(oRectangularPoint.TopLeft.Y - oRectangularPoint.BottomLeft.Y)

            oRectangularPoint.Center = ThisApplication.TransientGeometry.CreatePoint(
                (oRectangularPoint.TopLeft.X + oRectangularPoint.TopRight.X) / 2,
                (oRectangularPoint.TopLeft.Y + oRectangularPoint.BottomLeft.Y) / 2)

            DrawPreviewRectangle()

        End If
    End Sub

    Private Sub OInteractionEvents_OnTerminate() Handles OInteractionEvents.OnTerminate
        ThisApplication.ActiveView.Update()
    End Sub


    ''' <summary>
    ''' 绘制预览
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DrawPreviewRectangle()

        'Dim oInventorDrawingDocument As Document = ThisApplication.ActiveDocument

        Dim oInteractionGraphics As InteractionGraphics = OInteractionEvents.InteractionGraphics

        Dim oDataSets As GraphicsDataSets = oInteractionGraphics.GraphicsDataSets

        ' Set a reference to the transient geometry object for use later.
        Dim oTransGeom As TransientGeometry = ThisApplication.TransientGeometry

        ' Create a coordinate set.
        Dim oCoordSet As GraphicsCoordinateSet = oDataSets.CreateCoordinateSet(1)

        ' Create an array that contains coordinates that define a set
        ' of outwardly spiraling points.
        Dim oPointCoords(14) As Double

        oPointCoords(0) = oRectangularPoint.TopLeft.X
        oPointCoords(1) = oRectangularPoint.TopLeft.Y
        oPointCoords(2) = oRectangularPoint.TopLeft.Z

        oPointCoords(3) = oRectangularPoint.TopRight.X
        oPointCoords(4) = oRectangularPoint.TopRight.Y
        oPointCoords(5) = oRectangularPoint.TopRight.Z

        oPointCoords(6) = oRectangularPoint.BottomRight.X
        oPointCoords(7) = oRectangularPoint.BottomRight.Y
        oPointCoords(8) = oRectangularPoint.BottomRight.Z

        oPointCoords(9) = oRectangularPoint.BottomLeft.X
        oPointCoords(10) = oRectangularPoint.BottomLeft.Y
        oPointCoords(11) = oRectangularPoint.BottomLeft.Z

        oPointCoords(12) = oPointCoords(0)
        oPointCoords(13) = oPointCoords(1)
        oPointCoords(14) = oPointCoords(2)


        ' Assign the points into the coordinate set.
        oCoordSet.PutCoordinates(oPointCoords)

        ' Create the ClientGraphics object.
        Dim oClientGraphics As ClientGraphics = oInteractionGraphics.OverlayClientGraphics

        ' Create another graphics node for a line strip.
        Dim oLineStripNode As GraphicsNode = oClientGraphics.AddNode(1)

        ' Create a LineStripGraphics object within the new node.
        Dim oLineStrip As LineStripGraphics = oLineStripNode.AddLineStripGraphics

        ' Assign the same coordinate set to the line strip.
        oLineStrip.CoordinateSet = oCoordSet

        ' Create a color set to use in defining a explicit color to the line strip.
        Dim oColorSet As GraphicsColorSet = oDataSets.CreateColorSet(1)

        ' Add a single color to the set that is red.
        oColorSet.Add(1, 255, 0, 0)

        ' Assign the color set to the line strip.
        oLineStrip.ColorSet = oColorSet
        oLineStrip.LineDefinitionSpace = LineDefinitionSpaceEnum.kModelSpace
        oLineStrip.LineWeight = 0.06

        ' The two spirals are currently on top of each other so translate the
        ' new one in the x direction so they're side by side.
        Dim oMatrix As Matrix = oLineStripNode.Transformation
        oMatrix.SetTranslation(oTransGeom.CreateVector(0, 0, 0))
        oLineStripNode.Transformation = oMatrix

        ' Update the view to see the resulting spiral.
        oInteractionGraphics.UpdateOverlayGraphics(ThisApplication.ActiveView)

    End Sub


End Class
