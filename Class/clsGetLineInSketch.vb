Imports Inventor

''' <summary>
''' 获取鼠标点击的点坐标
''' </summary>
''' <remarks></remarks>
Public Class ClsGetLineInSketch

    Private WithEvents OInteractionEvents As InteractionEvents
    Private WithEvents OMouseEvents As MouseEvents

    Private m_position As Point2d
    Private m_button As MouseButtonEnum
    Private m_continue As Boolean
    Private oIntGraphics As InteractionGraphics

    Private oCenterPoint As Point
    Private oStartPoint As Point
    Private oEndPoint As Point

    ''' <summary>
    ''' 获取鼠标点击坐标
    ''' </summary>
    ''' <param name="Prompt">提示信息</param>
    ''' <param name="button">鼠标点击的哪个键</param>
    ''' <param name="oCenterPoint2d"> 中心点</param>
    ''' <returns></returns>
    Public Function GetLineInSketch(Prompt As String, button As MouseButtonEnum, oCenterPoint2d As Point2d) As Point2d
        m_position = Nothing
        m_button = button

        oCenterPoint = ThisApplication.TransientGeometry.CreatePoint(oCenterPoint2d.X, oCenterPoint2d.Y, 0)


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

        Dim oEndPoint2d As Point2d
        oEndPoint2d = ThisApplication.TransientGeometry.CreatePoint2d(oEndPoint.X, oEndPoint.Y)

        Return oEndPoint2d


    End Function

    Private Sub OMouseEvents_OnMouseDown(ByVal Button As MouseButtonEnum, ByVal ShiftKeys As ShiftStateEnum,
                                         ByVal ModelPosition As Point, ByVal ViewPosition As Point2d,
                                         ByVal View As View) Handles OMouseEvents.OnMouseDown


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

        oCenterPoint = Nothing
        oStartPoint = Nothing
        oEndPoint = ModelPosition

        m_continue = False


    End Sub

    Private Sub OMouseEvents_OnMouseMove(ByVal Button As MouseButtonEnum, ByVal ShiftKeys As ShiftStateEnum,
                                         ByVal ModelPosition As Point, ByVal ViewPosition As Point2d,
                                         ByVal View As View) Handles OMouseEvents.OnMouseMove
        On Error Resume Next

        Dim oInteractionGraphics As InteractionGraphics = OInteractionEvents.InteractionGraphics
        Dim oDataSets As GraphicsDataSets = oInteractionGraphics.GraphicsDataSets
        Dim oClientGraphics As ClientGraphics = oInteractionGraphics.OverlayClientGraphics

        Dim oLineStripNode As GraphicsNode


        oLineStripNode = oClientGraphics.Item(1)
            oLineStripNode.Delete()
        oInteractionGraphics.UpdateOverlayGraphics(ThisApplication.ActiveView)


        oStartPoint = ModelPosition

        OInteractionEvents.StatusBarText = "选择第二点"

        oEndPoint = ThisApplication.TransientGeometry.CreatePoint(
        2 * oCenterPoint.X - oStartPoint.X,
        2 * oCenterPoint.Y - oStartPoint.Y, 0)


        DrawPreviewLine()


    End Sub

    Private Sub OInteractionEvents_OnTerminate() Handles OInteractionEvents.OnTerminate
        ThisApplication.ActiveView.Update()
    End Sub


    ''' <summary>
    ''' 绘制预览
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DrawPreviewLine()

        'Dim oInventorDrawingDocument As Document = ThisApplication.ActiveDocument

        Dim oInteractionGraphics As InteractionGraphics = OInteractionEvents.InteractionGraphics

        Dim oDataSets As GraphicsDataSets = oInteractionGraphics.GraphicsDataSets

        ' Set a reference to the transient geometry object for use later.
        Dim oTransGeom As TransientGeometry = ThisApplication.TransientGeometry

        ' Create a coordinate set.
        Dim oCoordSet As GraphicsCoordinateSet = oDataSets.CreateCoordinateSet(1)

        ' Create an array that contains coordinates that define a set
        ' of outwardly spiraling points.
        Dim oPointCoords(5) As Double

        oPointCoords(0) = oStartPoint.X
        oPointCoords(1) = oStartPoint.Y
        oPointCoords(2) = 0

        oPointCoords(3) = oEndPoint.X
        oPointCoords(4) = oEndPoint.Y
        oPointCoords(5) = 0


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
        oColorSet.Add(1, 0, 255, 0)

        ' Assign the color set to the line strip.
        oLineStrip.ColorSet = oColorSet
        oLineStrip.LineDefinitionSpace = LineDefinitionSpaceEnum.kModelSpace
        oLineStrip.LineWeight = 0.02

        ' The two spirals are currently on top of each other so translate the
        ' new one in the x direction so they're side by side.
        Dim oMatrix As Matrix = oLineStripNode.Transformation
        oMatrix.SetTranslation(oTransGeom.CreateVector(0, 0, 0))
        oLineStripNode.Transformation = oMatrix

        ' Update the view to see the resulting spiral.
        oInteractionGraphics.UpdateOverlayGraphics(ThisApplication.ActiveView)

    End Sub

End Class
