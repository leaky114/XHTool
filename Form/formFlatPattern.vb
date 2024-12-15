Imports Inventor
Imports Inventor.DocumentTypeEnum
Imports System.Collections.Generic
Imports System.Drawing
Imports stdole
Imports Inventor.ViewOrientationTypeEnum
Imports Inventor.DrawingViewStyleEnum
Imports System.Windows.Forms

Public Class formFlatPattern
    Private intViewOrientation As ViewOrientationTypeEnum

    ''' <summary>
    ''' 展开图信息
    ''' </summary>
    ''' <remarks>文件名，材料，数量</remarks>
    Private Structure FlatInfor
        Dim FileName As String
        Dim Metial As String
        Dim Number As String
    End Structure

    ''' <summary>
    ''' 获取零件的展开图信息
    ''' </summary>
    ''' <param name="oInventorPartDocument">零件对象</param>
    ''' <remarks></remarks>
    Private Function GetPartFlatInformation(ByVal oInventorPartDocument As Inventor.PartDocument) As FlatInfor
        Dim oFlatInfo As FlatInfor
        oFlatInfo.Number = GetPropitem(oInventorPartDocument, Map_DrawingNnumber)
        oFlatInfo.FileName = GetPropitem(oInventorPartDocument, Map_PartName)

        Dim strMaterial As String = oInventorPartDocument.ComponentDefinition.Material.Name.ToString
        oFlatInfo.Metial = strMaterial

        Return oFlatInfo

    End Function

    ''' <summary>
    ''' 添加展开图信息到工程图
    ''' </summary>
    ''' <param name="oInventorDrawingDocument">被添加的工程图</param>
    ''' <param name="oInventorPartDocument">被添加的零件</param>
    ''' <param name="oFlatInfor" >添加的信息</param>
    ''' <remarks></remarks>
    Private Sub AddPartFlatInforToIdw(ByVal oInventorDrawingDocument As Inventor.DrawingDocument, ByVal oInventorPartDocument As Inventor.PartDocument, ByVal oFlatInfor As FlatInfor)

        Dim oSheet As Sheet
        oSheet = oInventorDrawingDocument.ActiveSheet

        Dim oGeneralNotes As GeneralNotes
        oGeneralNotes = oSheet.DrawingNotes.GeneralNotes

        Dim oTG As TransientGeometry
        oTG = ThisApplication.TransientGeometry

        Dim strFontName As String
        strFontName = ini.GetStrFromINI("技术要求", "字体", "仿宋", IniFile)

        Dim strFormattedText As String

        Dim oGeneralNote As GeneralNote = Nothing

        '添加零件的文件名
        Dim oPoint2d As Point2d = Nothing
        oPoint2d = GetDrawingPoint("单击确定插入文件名的位置。")
        If oPoint2d Is Nothing Then
            Exit Sub
        Else
            strFormattedText = GetFormattedText(oFlatInfor.FileName, strFontName, Val(str工艺文字高 * 0.1).ToString)
            oGeneralNote = oGeneralNotes.AddFitted(oPoint2d, strFormattedText)
        End If


        '添加零件的材质
        oPoint2d = GetDrawingPoint("单击确定插入材质的位置。")
        If oPoint2d Is Nothing Then
            Exit Sub
        Else
            strFormattedText = GetFormattedText(oFlatInfor.Metial, strFontName, Val(str工艺文字高 * 0.1).ToString)
            oGeneralNote = oGeneralNotes.AddFitted(oPoint2d, strFormattedText)
        End If

        '添加数量
        oPoint2d = GetDrawingPoint("单击确定插入数量的位置。")
        If oPoint2d Is Nothing Then
            Exit Sub
        Else
            strFormattedText = GetFormattedText(oFlatInfor.Number, strFontName, Val(str工艺文字高 * 0.1).ToString)   '乘 0.1  毫米转换为分米
            oGeneralNote = oGeneralNotes.AddFitted(oPoint2d, strFormattedText)
        End If

    End Sub

    ''' <summary>
    '''返回格式文字 
    ''' </summary>
    ''' <param name="strText">文字</param>
    ''' <param name="strFont">字体</param>
    ''' <param name="strFontSize">字体大小,单位 mm </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFormattedText(ByVal strText As String, ByVal strFont As String, ByVal strFontSize As String) As String
        '   <StyleOverride Font='隶书'   FontSize=2>技术要求</StyleOverride>
        '  '     <StyleOverride Font='隶书'>技术要求</StyleOverride><Br/>

        Dim str1 As String = "<StyleOverride Font='"
        Dim str2 As String = "' FontSize='"
        Dim str3 As String = "'>"
        Dim str4 As String = "</StyleOverride>"
        GetFormattedText = str1 & strFont & str2 & strFontSize & str3 & strText & str4
    End Function

    ''' <summary>
    ''' 添加展开图到工程图
    ''' </summary>
    ''' <param name="oInventorDrawingDocument">被添加的工程图</param>
    ''' <param name="oInventorPartDocument">被添加的零件</param>
    ''' <remarks></remarks>
    Private Sub AddPartFlatViewToIdw(ByVal oInventorDrawingDocument As Inventor.DrawingDocument, ByVal oInventorPartDocument As Inventor.PartDocument)
        'On Error Resume Next

        'Check to see if part is a sheetmetal part
        If (oInventorPartDocument.SubType <> "{9C464203-9BAE-11D3-8BAD-0060B0CE6BB4}") Then
            Exit Sub
        End If

        Dim oSMDef As SheetMetalComponentDefinition
        oSMDef = oInventorPartDocument.ComponentDefinition
        If oSMDef.HasFlatPattern = False Then
            'create flat pattern
            ThisApplication.ScreenUpdating = False
            oSMDef.Unfold()
            oSMDef.FlatPattern.ExitEdit()
            ThisApplication.ScreenUpdating = True
        End If

        Dim oFlatPattern As FlatPattern
        Dim douFlatExtent_X As Double    '"展开长"  转换单位为mm
        Dim douFlatExtent_Y As Double       '展开宽
        oFlatPattern = oSMDef.FlatPattern

        Dim douScale As Double = 1

        Dim oBaseViewOptions As NameValueMap = ThisApplication.TransientObjects.CreateNameValueMap

        oBaseViewOptions.Add("SheetMetalFoldedModel", False)

        'Dim oPoint2d As Point2d = Nothing
        'oPoint2d = GetDrawingPoint("单击确定插入展开图的位置。")


        Dim oRectangularPoint As RectangularPoint

        Dim oclsGetRectAreaInDrawing As clsGetRectAreaInDrawing
        oclsGetRectAreaInDrawing = New clsGetRectAreaInDrawing

        oRectangularPoint = oclsGetRectAreaInDrawing.GetRectAreaInDrawing("选择展开图绘制范围。", MouseButtonEnum.kLeftMouseButton)

        Dim dou工艺图范围X As Double = oRectangularPoint.Length * 10
        Dim dou工艺图范围Y As Double = oRectangularPoint.Width * 10

        Dim oSheet As Sheet = oInventorDrawingDocument.ActiveSheet
        Dim oView展开视图 As DrawingView = oSheet.DrawingViews.AddBaseView(oInventorPartDocument, oRectangularPoint.Center, douScale,
                ViewOrientationTypeEnum.kDefaultViewOrientation,
                DrawingViewStyleEnum.kHiddenLineRemovedDrawingViewStyle,
                , , oBaseViewOptions)

        douFlatExtent_X = oFlatPattern.Length * 10
        douFlatExtent_Y = oFlatPattern.Width * 10


        '比较X，y ，旋转90度
        If douFlatExtent_X < douFlatExtent_Y Then
            oView展开视图.RotateByAngle(Math.PI / 2)

            Dim intFlatExtentsTemp As Double
            intFlatExtentsTemp = douFlatExtent_X
            douFlatExtent_X = douFlatExtent_Y
            douFlatExtent_Y = intFlatExtentsTemp

        End If


        '比较视图与图框宽度
        Dim douScaleWidth As Double
        douScaleWidth = douFlatExtent_X / douFlatExtent_X

        Select Case douScaleWidth
            Case Is >= 1   '图框内宽大于视图宽度
                douScaleWidth = Int(douScaleWidth)
            Case Is >= 0.618
                douScaleWidth = Int(1 / douScaleWidth + 2.6)
                douScaleWidth = 1 / douScaleWidth
            Case Else
                douScaleWidth = Int(1 / douScaleWidth + 3.6)
                douScaleWidth = 1 / douScaleWidth
        End Select

        Dim douScaleHeight As Double
        douScaleHeight = dou工艺图范围Y / douFlatExtent_Y

        Select Case douScaleHeight
            Case Is >= 1
                douScaleHeight = Int(douScaleHeight)
            Case Is >= 0.618
                douScaleHeight = Int(1 / douScaleHeight + 2.6)
                douScaleHeight = 1 / douScaleHeight
            Case Else
                douScaleHeight = Int(1 / douScaleHeight + 3.6)
                douScaleHeight = 1 / douScaleHeight
        End Select

        '比较高宽2个方向的比例，选择一个小的值。
        douScale = Math.Min(douScaleHeight, douScaleWidth)

        oView展开视图.Scale = douScale
        oInventorDrawingDocument.Update()


        SetBendEdgeType(oInventorDrawingDocument)

        If str展开图隐藏螺纹特征 = "1" Then
            oView展开视图.DisplayThreadFeatures = False
        Else
            oView展开视图.DisplayThreadFeatures = True
        End If

        '//Create New Drawing Sketch

        Dim oSketch As DrawingSketch
        oSketch = oView展开视图.Sketches.Add

        Dim oTG As TransientGeometry = ThisApplication.TransientGeometry

        ' //Create 2 points in the sheet space
        Dim oSheetPoint1 As Point2d
        oSheetPoint1 = oTG.CreatePoint2d(oView展开视图.Left, oView展开视图.Top)

        Dim oSheetPoint2 As Point2d
        oSheetPoint2 = oTG.CreatePoint2d(oView展开视图.Left + oView展开视图.Width, oView展开视图.Top)

        Dim oSheetPoint3 As Point2d
        oSheetPoint3 = oTG.CreatePoint2d(oView展开视图.Left, oView展开视图.Top)

        Dim oSheetPoint4 As Point2d
        oSheetPoint4 = oTG.CreatePoint2d(oView展开视图.Left, oView展开视图.Top - oView展开视图.Height)

        '//Convert points In sketch space
        Dim oInSketchPoint1 As Point2d
        oInSketchPoint1 = oSketch.SheetToSketchSpace(oSheetPoint1)

        Dim oInSketchPoint2 As Point2d
        oInSketchPoint2 = oSketch.SheetToSketchSpace(oSheetPoint2)

        Dim oInSketchPoint3 As Point2d
        oInSketchPoint3 = oSketch.SheetToSketchSpace(oSheetPoint3)

        Dim oInSketchPoint4 As Point2d
        oInSketchPoint4 = oSketch.SheetToSketchSpace(oSheetPoint4)

        '//Edit sketch
        oSketch.Edit()

        '//Create 2 sketch points
        Dim oSketchPoint1 As SketchPoint
        oSketchPoint1 = oSketch.SketchPoints.Add(oInSketchPoint1, False)

        Dim oSketchPoint2 As SketchPoint
        oSketchPoint2 = oSketch.SketchPoints.Add(oInSketchPoint2, False)

        Dim oSketchPoint3 As SketchPoint
        oSketchPoint3 = oSketch.SketchPoints.Add(oInSketchPoint3, False)

        Dim oSketchPoint4 As SketchPoint
        oSketchPoint4 = oSketch.SketchPoints.Add(oInSketchPoint4, False)

        '//Set position For the Text
        Dim oHeight2 As Double = (oFlatPattern.Length) ' * douScale
        Dim oWidth2 As Double = (oFlatPattern.Width)   '* douScale

        'X方向长度
        Dim oTextPosition As Point2d
        oTextPosition = oTG.CreatePoint2d(0, -oHeight2 / 2 - 3)

        'Y方向长度
        Dim oTextPosition2 As Point2d
        oTextPosition2 = oTG.CreatePoint2d(oWidth2 / 2 + 3, 0)

        '//Create dimension In sketch
        oSketch.DimensionConstraints.AddTwoPointDistance(oSketchPoint1, oSketchPoint2, Inventor.DimensionOrientationEnum.kAlignedDim, oTextPosition, False)
        oSketch.DimensionConstraints.AddTwoPointDistance(oSketchPoint3, oSketchPoint4, Inventor.DimensionOrientationEnum.kAlignedDim, oTextPosition2, False)

        '//Close sketch
        oSketch.ExitEdit()

        oInventorDrawingDocument.ActiveSheet.DrawingDimensions.GeneralDimensions.Retrieve(oSketch)

    End Sub

    ''' <summary>
    ''' 添加折弯图到工艺图
    ''' </summary>
    ''' <param name="oInventorDrawingDocument">被添加的工程图</param>
    ''' <param name="oInventorPartDocument">被添加的零件</param>
    ''' <param name="ViewOrientationType">视图的方向</param>
    ''' <remarks></remarks>
    Private Sub AddPartZheWanViewToIdw(ByVal oInventorDrawingDocument As Inventor.DrawingDocument, _
                                   ByVal oInventorPartDocument As Inventor.PartDocument, _
                                   ByVal ViewOrientationType As Inventor.ViewOrientationTypeEnum)

        'Dim oPoint2d As Point2d = Nothing
        'oPoint2d = GetDrawingPoint("单击确定插入折弯图的位置。")

        Dim ooRectangularPoint As RectangularPoint

        Dim oclsGetRectAreaInDrawing As clsGetRectAreaInDrawing
        oclsGetRectAreaInDrawing = New clsGetRectAreaInDrawing

        ooRectangularPoint = oclsGetRectAreaInDrawing.GetRectAreaInDrawing("选择折弯图绘制范围。", MouseButtonEnum.kLeftMouseButton)

        Dim dou工艺图范围X As Double = ooRectangularPoint.Length * 10
        Dim dou工艺图范围Y As Double = ooRectangularPoint.Width * 10


        Dim oBaseViewOptions As NameValueMap = ThisApplication.TransientObjects.CreateNameValueMap
        Dim oTG As TransientGeometry = ThisApplication.TransientGeometry

        '初始比例
        Dim douScale As Double = 1
        oBaseViewOptions.Add("SheetMetalFoldedModel", False)

        Dim oSheet As Sheet = oInventorDrawingDocument.Sheets.Item(1)

        Dim oView折弯视图 As DrawingView
        oView折弯视图 = oSheet.DrawingViews.AddBaseView(oInventorPartDocument, ooRectangularPoint.Center, douScale, ViewOrientationType, _
                                                   IIf(str样式 = "显示隐藏线", DrawingViewStyleEnum.kHiddenLineDrawingViewStyle, _
                                                       DrawingViewStyleEnum.kHiddenLineRemovedDrawingViewStyle))

        Dim douView_X As Double    '宽度  转换单位为mm
        Dim douView_Y As Double       '高度

        douView_X = oView折弯视图.Width * 10
        douView_Y = oView折弯视图.Height * 10


        '比较视图与图框宽度
        Dim douScaleWidth As Double
        douScaleWidth = dou工艺图范围X / douView_X

        Select Case douScaleWidth
            Case Is >= 1   '图框内宽大于视图宽度
                douScaleWidth = Int(douScaleWidth)
            Case Is >= 0.618
                douScaleWidth = Int(1 / douScaleWidth + 2.6)
                douScaleWidth = 1 / douScaleWidth
            Case Else
                douScaleWidth = Int(1 / douScaleWidth + 3.6)
                douScaleWidth = 1 / douScaleWidth
        End Select

        Dim douScaleHeight As Double
        douScaleHeight = dou工艺图范围Y / douView_Y

        Select Case douScaleHeight
            Case Is >= 1
                douScaleHeight = Int(douScaleHeight)
            Case Is >= 0.618
                douScaleHeight = Int(1 / douScaleHeight + 2.6)
                douScaleHeight = 1 / douScaleHeight
            Case Else
                douScaleHeight = Int(1 / douScaleHeight + 3.6)
                douScaleHeight = 1 / douScaleHeight
        End Select

        '比较高宽2个方向的比例，选择一个小的值。
        douScale = Math.Min(douScaleHeight, douScaleWidth)

        oView折弯视图.Scale = douScale
        oInventorDrawingDocument.Update()

        oView折弯视图.Scale = douScale

        oInventorDrawingDocument.Update()
    End Sub

    Private Sub btn添加展开图_Click(sender As Object, e As EventArgs) Handles btn添加展开图.Click

        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
            MsgBox("请切换到工程图。", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim oInventorDrawingDocument As Inventor.DrawingDocument
        oInventorDrawingDocument = ThisApplication.ActiveDocument

        Dim oInventorPartDocument As Inventor.PartDocument

        Dim strInventorPartDocumentFullFileName As String = txt位置.Text

        If IsFileExsts(strInventorPartDocumentFullFileName) = False Then
            MsgBox("未选择零件。", MsgBoxStyle.Information)
            Exit Sub
        End If

        Try
            oInventorPartDocument = ThisApplication.Documents.ItemByName(strInventorPartDocumentFullFileName)
        Catch
            oInventorPartDocument = ThisApplication.Documents.Open(strInventorPartDocumentFullFileName, False)
        End Try

        Dim oFlatInfor As FlatInfor
        oFlatInfor.FileName = txt图号.Text.ToString & txt文件名.Text.ToString
        oFlatInfor.Metial = txt材质.Text.ToString
        oFlatInfor.Number = cbo数量.Text.ToString

        '添加展开图信息
        AddPartFlatInforToIdw(oInventorDrawingDocument, oInventorPartDocument, oFlatInfor)

        '添加展开图
        AddPartFlatViewToIdw(oInventorDrawingDocument, oInventorPartDocument)

        '添加折弯图
        If rdo不插入.Checked = False Then
            AddPartZheWanViewToIdw(oInventorDrawingDocument, oInventorPartDocument, intViewOrientation)
        End If

        'Select Case cbo视图方向.Text
        '    Case "前"

        '    Case "后"
        'AddPartZheWanViewToIdw(oInventorDrawingDocument, oInventorPartDocument, kBackViewOrientation)
        '    Case "左"
        'AddPartZheWanViewToIdw(oInventorDrawingDocument, oInventorPartDocument, kLeftViewOrientation)
        '    Case "右"
        'AddPartZheWanViewToIdw(oInventorDrawingDocument, oInventorPartDocument, kRightViewOrientation)
        '    Case "上"
        'AddPartZheWanViewToIdw(oInventorDrawingDocument, oInventorPartDocument, kTopViewOrientation)
        '    Case "下"
        'AddPartZheWanViewToIdw(oInventorDrawingDocument, oInventorPartDocument, kBottomViewOrientation)
        '    Case Else
        'Exit Sub
        'End Select

        oInventorPartDocument.Close(True)
    End Sub



    Private Sub btn从部件选择_Click(sender As Object, e As EventArgs) Handles btn从部件选择.Click
        If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
            MsgBox("请切换到部件。", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument

        If oInventorAssemblyDocument.SelectSet.Count = 0 Then
            MsgBox("在部件中选择一个零件。", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim oComponentOccurrence As ComponentOccurrence = oInventorAssemblyDocument.SelectSet(1)

        If oComponentOccurrence Is Nothing Then
            MsgBox("请选择一个零件。", MsgBoxStyle.Information)
            Exit Sub
        End If

        If oComponentOccurrence.DefinitionDocumentType = kPartDocumentObject Then
            Dim oInventorPartDocument As Inventor.PartDocument
            Dim strInventorPartDocumentFullFileName As String

            strInventorPartDocumentFullFileName = oComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName

            oInventorPartDocument = ThisApplication.Documents.Open(strInventorPartDocumentFullFileName)

            CreateFlat(oInventorPartDocument)

            Dim oFlatInfo As FlatInfor
            oFlatInfo = GetPartFlatInformation(oInventorPartDocument)

            txt图号.Text = oFlatInfo.Number
            txt文件名.Text = oFlatInfo.FileName
            txt材质.Text = oFlatInfo.Metial
            txt位置.Text = oInventorPartDocument.FullDocumentName

            intViewOrientation = kFrontViewOrientation

            'SetViewToPictureBox(oInventorPartDocument, PictureBox1)

        Else
            MsgBox("请选择一个零件。", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub btn打开零件_Click(sender As Object, e As EventArgs) Handles btn打开零件.Click
        Dim strFilter As String = Nothing

        strFilter = "Autodesk Inventor 零件(*.ipt)|*.ipt" '添加过滤文件    

        Dim oFileList As List(Of String)
        oFileList = OpenFileDialog(strFilter, False)

        If oFileList Is Nothing Then
            Exit Sub
        End If
        Dim strInventorPartDocumentFullFileName As String = oFileList.Item(0).ToString

        Dim oInventorPartDocument As Inventor.PartDocument
        oInventorPartDocument = ThisApplication.Documents.Open(strInventorPartDocumentFullFileName)

        CreateFlat(oInventorPartDocument)

        Dim oFlatInfo As FlatInfor
        oFlatInfo = GetPartFlatInformation(oInventorPartDocument)

        txt图号.Text = oFlatInfo.Number
        txt文件名.Text = oFlatInfo.FileName
        txt材质.Text = oFlatInfo.Metial
        txt位置.Text = oInventorPartDocument.FullDocumentName

        intViewOrientation = kFrontViewOrientation

        'SetViewToPictureBox(oInventorPartDocument, PictureBox1)
    End Sub

    Private Sub btn向上1_Click(sender As Object, e As EventArgs) Handles btn向上1.Click
        Dim strTemp As String
        strTemp = txt图号.Text
        txt图号.Text = txt文件名.Text
        txt文件名.Text = strTemp
    End Sub



    Private Sub frmFlatPattern_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btn向上1.Image = My.Resources.交换16.ToBitmap

    End Sub

    ''' <summary>
    ''' 设置img 到picture
    ''' </summary>
    ''' <param name="oInventorDocument">零件对象</param>
    ''' <param name="oPictureBox">图框对象</param>
    ''' <remarks></remarks>
    Private Sub SetViewToPictureBox(ByVal oInventorDocument As Inventor.Document, oPictureBox As PictureBox)
        Dim img As System.Drawing.Image
        img = GetImageFormOneView(oInventorDocument, intViewOrientation)
        oPictureBox.Image = img
    End Sub

    ''' <summary>
    ''' 获取视图
    ''' </summary>
    ''' <param name="oInventorDocument">零件文档对象</param>
    ''' <param name="ViewOrientationType">视图枚举值</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetImageFormOneView(ByVal oInventorDocument As Inventor.Document, _
                                        ByVal ViewOrientationType As Inventor.ViewOrientationTypeEnum) As Drawing.Image

        Dim tempFile As String = IO.Path.GetTempFileName()
        tempFile = IO.Path.ChangeExtension(tempFile, ".jpg")

        ThisApplication.Documents.Open(oInventorDocument.FullDocumentName, False)

        Dim oCamera As Camera

        oCamera = ThisApplication.ActiveView.Camera
        oCamera.ViewOrientationType = ViewOrientationType

        oCamera.Apply()

        oCamera.SaveAsBitmap(tempFile, 400, 300)

        GetImageFormOneView = Image.FromFile(tempFile)

    End Function

    Private Sub rdo前视图_CheckedChanged(sender As Object, e As EventArgs) Handles rdo前视图.CheckedChanged, rdo后视图.CheckedChanged, _
        rdo左视图.CheckedChanged, rdo右视图.CheckedChanged, rdo上视图.CheckedChanged, rdo下视图.CheckedChanged

        Dim oradio As RadioButton
        oradio = sender

        Select Case oradio.Text
            Case "前视图"
                intViewOrientation = kFrontViewOrientation
            Case "后视图"
                intViewOrientation = kBackViewOrientation
            Case "左视图"
                intViewOrientation = kLeftViewOrientation
            Case "右视图"
                intViewOrientation = kRightViewOrientation
            Case "上视图"
                intViewOrientation = kTopViewOrientation
            Case "下视图"
                intViewOrientation = kBottomViewOrientation
            Case "不插入"
                intViewOrientation = 0
        End Select

        Dim oCamera As Camera
        Try
            oCamera = ThisApplication.ActiveView.Camera
            oCamera.ViewOrientationType = intViewOrientation

            oCamera.Apply()
        Catch ex As Exception

        End Try

    End Sub


End Class