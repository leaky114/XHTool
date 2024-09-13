Imports Inventor
Imports Inventor.SelectionFilterEnum
Imports Inventor.DocumentTypeEnum
Imports Inventor.ViewOrientationTypeEnum
Imports Inventor.DrawingViewStyleEnum
Imports Inventor.ObjectTypeEnum

Imports System.Windows.Forms
Imports System
Imports System.IO
Imports Microsoft
Imports Microsoft.VisualBasic
Imports System.Collections.ObjectModel
Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports System.Net



Public Class frmain

    Public Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)

    Private HideSide As Short '隐藏边的位置，0为未隐藏，1为上边，2为左边

   

    '测试
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        'Dim oSelectSet As Object = Nothing

        'If oInventorDocument.SelectSet.Count <> 0 Then
        '    'For Each oSelect As Object In InventorDoc.SelectSet
        '    oSelectSet = oInventorDocument.SelectSet(1)
        'Else

        '    oSelectSet = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kAllEntitiesFilter, "选择要编辑的尺寸，ESC键取消")

        '    If oSelectSet Is Nothing Then       '取消选择
        '        Me.Close()
        '        Exit Sub
        '    End If
        'End If


        'Select Case oSelectSet.type
        '    Case kAngleConstraintObject, kAssemblySymmetryConstraintObject, kCompositeConstraintObject, kCustomConstraintObject, _
        '        kFlushConstraintObject, kInsertConstraintObject, kMateConstraintObject, kTangentConstraintObject, kTransitionalConstraintObject

        '        MsgBox("约束")
        '    Case kTwoPointDistanceDimConstraintObject, kDiameterDimConstraintObject
        '        MsgBox("2维尺寸")
        '    Case kDimensionConstraints3DObject, kLineLengthDimConstraint3DObject
        '        MsgBox("3维尺寸")
        '    Case kBendConstraintObject, kTwoLineAngleDimConstraint3DObject
        '        MsgBox("折弯尺寸")
        '    Case kPlanarSketchObject
        '        MsgBox("2维草图")

        '    Case kSketch3DObject
        '        MsgBox("3维草图")

        '    Case Else

        'End Select
        'frmSwitchLables.Show()

        '' 创建进度条
        'Dim progressBar As Inventor.ProgressBar = ThisApplication.CreateProgressBar(True, 10, "Progress Bar Demo")
        'progressBar.Message = "Processing..."

        '' 更新进度条
        'For i = 1 To 10
        '    progressBar.UpdateProgress()
        '    System.Threading.Thread.Sleep(1000)
        'Next

        '' 隐藏并销毁进度条
        'progressBar.Close()

        'Dim oMiniToolbar As clsMiniToolbar = New clsMiniToolbar


        'Dim oDoc As DrawingDocument
        'oDoc = ThisApplication.ActiveDocument

        'Dim oSheet As Sheet
        'oSheet = oDoc.ActiveSheet

        'Dim oCurve1 As DrawingCurve
        'oCurve1 = oDoc.SelectSet(1).Parent

        'Dim oCurve2 As DrawingCurve
        'oCurve2 = oDoc.SelectSet(2).Parent

        'Dim oIntent1 As GeometryIntent
        'oIntent1 = oSheet.CreateGeometryIntent(oCurve1)

        'Dim oIntent2 As GeometryIntent
        'oIntent2 = oSheet.CreateGeometryIntent(oCurve2)

        'Dim oPt As Point2d
        'oPt = ThisApplication.TransientGeometry.CreatePoint2d(15, 15)

        'Dim oLinDim As LinearGeneralDimension
        'oLinDim = oSheet.DrawingDimensions.GeneralDimensions.AddLinear(oPt, oIntent1, oIntent2)

        'Dim oInventorDrawingDocument As Inventor.DrawingDocument
        'oInventorDrawingDocument = ThisApplication.ActiveDocument

        ''Dim oSheet As Sheet
        ''oSheet = oInventorDrawingDocument.ActiveSheet

        'Dim selectedLines1 As DrawingCurveSegment
        'Dim selectedLines2 As DrawingCurveSegment
        'Dim selectedLines3 As DrawingCurveSegment
        'Dim selectedLines4 As DrawingCurveSegment

        'selectedLines1 = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kDrawingCurveSegmentFilter, "选择第一条线")
        'selectedLines2 = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kDrawingCurveSegmentFilter, "选择第二条线")
        'selectedLines3 = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kDrawingCurveSegmentFilter, "选择第三条线")
        'selectedLines4 = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kDrawingCurveSegmentFilter, "选择第四条线")

        'Dim line1 As LineSegment = CType(selectedLines1, Inventor.LineSegment)
        'Dim line2 As LineSegment = CType(selectedLines2, Inventor.LineSegment)
        'Dim line3 As LineSegment = CType(selectedLines3, Inventor.LineSegment)
        'Dim line4 As LineSegment = CType(selectedLines4, Inventor.LineSegment)

        '' 获取 l1, l2 的交点 p1
        'Dim intersectionPoint1 As Point2d = line1.IntersectWithCurve(line2)

        '' 获取 l3, l4 的交点 p2
        'Dim intersectionPoint2 As Point2d = line3.IntersectWithCurve(line4)

        '' 计算并标注 p1, p2 的距离尺寸
        'Dim distance As Double = intersectionPoint1.DistanceTo(intersectionPoint2)
        'Dim annotation As DimensionConstraint = oInventorDrawingDocument.ActiveSheet. _
        '    DimensionConstraints.AddTwoPointDistance(selectedLines1.StartPoint, selectedLines3.StartPoint, _
        '                                          DimensionOrientationEnum.kAlignedDim, distance)

        '' 刷新文档
        'oInventorDrawingDocument.Update()

        ''Dim oLinDim As LinearGeneralDimension
        ''oLinDim = oSheet.DrawingDimensions.GeneralDimensions.AddLinear(oSketchPoint1, oIntent1, oIntent2)

        'For Each openForm As Form In System.Windows.Forms.Application.OpenForms
        '    If openForm.Name = "切换文档" Then
        '        ' 如果找到了，就激活这个窗口
        '        openForm.Activate()
        '        Exit Sub
        '    End If
        'Next

        'frmSwitchLables.Show()

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        On Error Resume Next

        'Dim oPropertySets As PropertySets
        'Dim oPropertySet As PropertySet
        'Dim propitem As [Property]

        '=============================================================================
        '采用学徒服务器, 速度更快
        'Dim apprentice As Inventor.ApprenticeServerComponent
        'apprentice = New Inventor.ApprenticeServerComponent

        'Dim apprenticeDoc As Inventor.ApprenticeServerDocument
        'apprenticeDoc = apprentice.Open(oInventorDocument.FullDocumentName)

        'oPropertySets = apprenticeDoc.PropertySets

        '=============================================================================

        'Dim oInventorDocument = ThisApplication.ActiveDocument
        'oPropertySets = oInventorDocument.PropertySets

        'For Each oPropertySet In oPropertySets
        '    For Each propitem In oPropertySet
        '        Debug.Print(propitem.PropId & "," & propitem.DisplayName & "," & propitem.Name)
        '    Next
        '    Debug.Print("--------------------")
        'Next

        'Dim drawing As DrawingDocument
        'drawing = ThisApplication.ActiveDocument

        'Dim drawingView As DrawingView
        'drawingView = drawing.ActiveSheet.DrawingViews(1)


        'Dim part As PartDocument
        'part = drawingView.ReferencedDocumentDescriptor.ReferencedDocument

        'Dim partDef As PartComponentDefinition
        'partDef = part.ComponentDefinition

        'Dim holeFeature As HoleFeature

        'Dim holeDrawingCurves As DrawingCurvesEnumerator

        'Dim holeDrawingCurve As DrawingCurve
        'Dim drawingCurveSegment As DrawingCurveSegment

        'For Each holeFeature In partDef.Features.HoleFeatures

        '    If holeFeature.HoleType = HoleTypeEnum.kDrilledHole Then


        '        holeDrawingCurves = drawingView.DrawingCurves(holeFeature)

        '        For Each holeDrawingCurve In holeDrawingCurves
        '            For Each drawingCurveSegment In holeDrawingCurve.Segments
        '                Debug.Print(drawingCurveSegment.StartPoint.X)

        '            Next
        '        Next
        '    End If
        'Next


        'Dim drawing As DrawingDocument = ThisApplication.ActiveDocument

        'Dim drawingView As DrawingView = drawing.ActiveSheet.DrawingViews(1)
        'Dim part As PartDocument = drawingView.ReferencedDocumentDescriptor.ReferencedDocument
        'Dim partDef As PartComponentDefinition = part.ComponentDefinition


        'For Each holeFeature As HoleFeature In partDef.Features.HoleFeatures

        '    If holeFeature.HoleType <> HoleTypeEnum.kDrilledHole Then
        '        Continue For
        '    End If

        '    'Get the biggest circles of holeFeature in drawing view
        '    Dim biggestCircles As New List(Of DrawingCurveSegment)
        '    Dim biggestCircleRadius As Double = 0

        '    Dim holeDrawingCurves = drawingView.DrawingCurves(holeFeature)

        '    For Each holeDrawingCurve As DrawingCurve In holeDrawingCurves
        '        For Each drawingCurveSegment As DrawingCurveSegment In holeDrawingCurve.Segments
        '            Dim circle2d = TryCast(drawingCurveSegment.Geometry, Circle2d)
        '            If circle2d Is Nothing Then Exit For
        '            If circle2d.Radius > biggestCircleRadius Then
        '                biggestCircles.Clear()
        '                biggestCircleRadius = circle2d.Radius
        '                biggestCircles.Add(drawingCurveSegment)
        '            ElseIf circle2d.Radius = biggestCircleRadius Then
        '                biggestCircles.Add(drawingCurveSegment)

        '            End If
        '        Next
        '    Next

        '    'Hide 
        '    For Each biggestCircle As DrawingCurveSegment In biggestCircles
        '        biggestCircle.Visible = False
        '    Next
        'Next



        'NewUpdater.Shell_XHUpdater()

        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        'On Error Resume Next
        'Dim oCommandManager As CommandManager
        'Dim oUserInterfaceManager As UserInterfaceManager
        ''Dim oIPictureDisp32 As Object  '大图标
        ''Dim oIPictureDisp8 As Object   '小图标

        'Dim smallPicture As stdole.IPictureDisp
        'Dim largePicture As stdole.IPictureDisp

        ''Try
        'oCommandManager = ThisApplication.CommandManager
        'oUserInterfaceManager = ThisApplication.UserInterfaceManager

        'if oUserInterfaceManager.InterfaceStyle = InterfaceStyleEnum.kRibbonInterface Then
        '    Dim oRibbon As Inventor.Ribbon
        '    Dim oRibbonTab As Inventor.RibbonTab
        '    Dim oRibbonPanel As Inventor.RibbonPanel

        '    Dim oButtonDefinitions As Inventor.ObjectCollection
        '    oButtonDefinitions = ThisApplication.TransientObjects.CreateObjectCollection



        '    '部件环境
        '    oRibbon = oUserInterfaceManager.Ribbons.Item("Assembly")

        '    oRibbonTab = oRibbon.RibbonTabs.Item("id_TabAssemble")

        'End if

        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        'Dim oInventorDocument As Inventor.Document
        'oInventorDocument = ThisApplication.ActiveEditDocument

        'For Each o As Inventor.Document In oInventorDocument.ReferencingDocuments
        '    Debug.Print(o.FullDocumentName)
        'Next

        'On Error Resume Next

        'Dim t As System.IO.StreamWriter = New System.IO.StreamWriter("d:\inventor.txt")

        'For i = 1 To ThisApplication.UserInterfaceManager.Ribbons.Count
        '    Dim partRibbon As Ribbon = ThisApplication.UserInterfaceManager.Ribbons.Item(i)
        '    t.Write(i & Space(4) & partRibbon.InternalName & vbCrLf)

        '    For j = 1 To partRibbon.RibbonTabs.Count
        '        Dim toolsTab As RibbonTab = partRibbon.RibbonTabs.Item(j)
        '        t.Write(Space(4) & j & Space(4) & toolsTab.InternalName & Space(4) & toolsTab.DisplayName & vbCrLf)

        '        For k = 1 To toolsTab.RibbonPanels.Count
        '            Dim Ribbon_Panel As RibbonPanel = toolsTab.RibbonPanels.Item(k)
        '            t.Write(Space(8) & k & Space(4) & Ribbon_Panel.InternalName & Space(4) & Ribbon_Panel.DisplayName & vbCrLf)

        '            For ii = 1 To Ribbon_Panel.CommandControls.Count
        '                Dim commandcontrol As CommandControl = Ribbon_Panel.CommandControls.Item(ii)
        '                t.Write(Space(16) & ii & Space(4) & commandcontrol.InternalName & Space(4) & commandcontrol.DisplayName.Replace(Chr(13), "").Replace(Chr(10), "") & vbCrLf)

        '                For jj = 1 To commandcontrol.ChildControls.Count
        '                    Dim commandchildcontrol As CommandControl = commandcontrol.ChildControls.Item(jj)
        '                    t.Write(Space(24) & jj & Space(4) & commandchildcontrol.InternalName & Space(4) & commandchildcontrol.InternalName & Space(4) & commandchildcontrol.DisplayName.Replace(Chr(13), "").Replace(Chr(10), "") & vbCrLf)
        '                    commandchildcontrol = Nothing
        '                Next
        '                commandcontrol = Nothing
        '            Next
        '            Ribbon_Panel = Nothing
        '        Next
        '        toolsTab = Nothing
        '    Next
        '    partRibbon = Nothing
        'Next
        't.Close()

        'SetBendEdgeType()

        'ReplaceDerivedPart()

        '=====================
        'AddAssemblyBrowserFolder()


        'SuppressAllUnhealthConstraints()

        'DrawingDocumentSaveAs()

        'Dim oribbon As Ribbon
        'oribbon = ThisApplication.UserInterfaceManager.Ribbons.Item("Assembly")

        ''工具选项卡
        ''oRibbonTab = oRibbon.RibbonTabs.Item("id_TabTools")

        ''装配选项卡
        'Dim oRibbonTab As RibbonTab
        'oRibbonTab = oRibbon.RibbonTabs.Item("id_TabAssemble")

        'Dim oRibbonPanel As RibbonPanel
        'oRibbonPanel = oRibbonTab.RibbonPanels.Item("id_PanelA_ToolsMeasure")

        'Dim oCommandControl As CommandControl
        'For Each oCommandControl In oRibbonPanel.CommandControls
        '    Debug.Print(oCommandControl.InternalName)
        'Next


        'oCommandControl = oRibbonPanel.CommandControls.Item("InName驱动测量")

        'oRibbonPanel.SlideoutControls.AddCopy(oCommandControl)

    End Sub

    Private Sub frmain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        End
    End Sub

    Private Sub frmain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Icon = My.Resources.XHTool48

        Dim m_quitInventor As Boolean = False
        'Try to get an active instance of Inventor
        Try
            ThisApplication = System.Runtime.InteropServices.Marshal.GetActiveObject("Inventor.Application")
        Catch ex As Exception

        End Try

        ' if not active, create a new Inventor session
        If ThisApplication Is Nothing Then

            Dim ThisApplicationType As Type = System.Type.GetTypeFromProgID("Inventor.Application")
            ThisApplication = System.Activator.CreateInstance(ThisApplicationType)

            m_quitInventor = True
            ThisApplication.Visible = True
        End If
        ReSetLabel()


        'Me.Location.Y = 318 '初始化高度，不要落在Timer1触发事件高度内，否则启动时就触发了，窗体会上移，很不方便使用
        '初始化时钟定时器
        With Timer1
            .Interval = 80     '设置Timer1间隔，1000代表一秒
            .Enabled = True
        End With

        'Timer1.Enabled = False

        With Timer2
            .Interval = 80     '设置Timer1间隔，1000代表一秒
            .Enabled = False
        End With

        ContentCenterFiles = ThisApplication.FileOptions.ContentCenterPath  '初始化零件库
        Debug.Print(ContentCenterFiles)


        Inifile = IO.Path.Combine(My.Application.Info.DirectoryPath, "InAISetting.ini")

        If IsFileExsts(Inifile) = False Then
            '初始化默认值
            WrXml.InAISettingDefaultValue()

            '获取自定义值
            'WrXml.InAISettingXmlReadSetting()

            WrIni.InAISettingIniWriteSetting()
        End If

        WrIni.InAISettingIniReadSetting()

        '更新数据库文件
        If BasicExcelFullFileName = "" Then
            BasicExcelFullFileName = IO.Path.Combine(My.Application.Info.DirectoryPath, "最新物料编码.xlsx")
            'MsgBox(Excel_File_Name)
        End If

        Dim documentURL As String
        documentURL = "\\Likai-pc\发行版\更新包\最新物料编码.xlsx"

        If IsFileExsts(documentURL) = True Then
            Dim wc As New System.Net.WebClient
            'wc.DownloadFile(documentURL, BasicExcelFullFileName)
        End If
        'End if

        '下载帮助文件
        documentURL = "\\Likai-pc\发行版\安装包\帮助.docx"

        Dim strHelpFullFileName As String
        strHelpFullFileName = IO.Path.Combine(My.Application.Info.DirectoryPath, "帮助.docx")

        If IsFileExsts(documentURL) = True Then
            Dim wc As New System.Net.WebClient
            wc.DownloadFile(documentURL, strHelpFullFileName)
        End If

        'clsRightMouse()
        'If SharedVariable.Exists("ShowAll") Then Return
        'SharedVariable("ShowAll") = "ShowAll"

        'Dim mybutton As New clsRightMouse(ThisApplication)

        '生成工具栏
        'BuildToolBar()

    End Sub

    Private Sub ReSetLabel()
        ToolStripStatusLabel1.Text = ""
    End Sub

    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    '上边隐藏
    '    if Me.Location.Y < 20 And HideSide <> 2 Then '判断当前窗体位置，如果窗体位置y值小于50那么再进行鼠标位置判断决定是否上移
    '        if Control.MousePosition.X < Me.Location.X Or Control.MousePosition.X > Me.Location.X + Me.Width Or Control.MousePosition.Y < Me.Location.Y Or Control.MousePosition.Y > Me.Location.Y + Height Then
    '            '判断鼠标位置在窗体外，则执行如下程序，注意在判断表达式中不要用等号，否则窗体会闪烁
    '            Me.Location = New System.Drawing.Point(Me.Location.X, 3 - Me.Height) '上边预留3个格供Timer2触发事件用，不留将无法把鼠标移到已隐藏的窗体上
    '            Timer2.Enabled = True
    '            Timer1.Enabled = False
    '            Me.TopMost = True '将上移后的窗体置顶
    '            HideSide = 1
    '        End if
    '    End if

    '    '左边隐藏
    '    if Me.Location.X < 20 And HideSide <> 1 Then '判断当前窗体位置，如果窗体位置y值小于50那么再进行鼠标位置判断决定是否上移
    '        if Control.MousePosition.X < Me.Location.X Or Control.MousePosition.X > Me.Location.X + Me.Width Or Control.MousePosition.Y < Me.Location.Y Or Control.MousePosition.Y > Me.Location.Y + Height Then
    '            '判断鼠标位置在窗体外，则执行如下程序，注意在判断表达式中不要用等号，否则窗体会闪烁
    '            Me.Location = New System.Drawing.Point(3 - Me.Width, Me.Location.Y) '上边预留3个格供Timer2触发事件用，不留将无法把鼠标移到已隐藏的窗体上
    '            Timer2.Enabled = True
    '            Timer1.Enabled = False
    '            Me.TopMost = True '将上移后的窗体置顶
    '            HideSide = 2
    '        End if
    '    End if

    'End Sub

    'Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
    '    if Control.MousePosition.X > Me.Location.X And Control.MousePosition.X < Me.Location.X + Me.Width And Control.MousePosition.Y > Me.Location.Y And Control.MousePosition.Y < Me.Location.Y + Height And HideSide <> 0 Then
    '        '判断鼠标位置在窗体内，则执行如下程序，注意在判断表达式中不要用等号，否则窗体会闪烁
    '        if HideSide = 1 Then
    '            Me.Location = New System.Drawing.Point(Me.Location.X, 0) '靠边显示窗体
    '        Elseif HideSide = 2 Then
    '            Me.Location = New System.Drawing.Point(0, Me.Location.Y) '靠边显示窗体
    '        End if
    '        Timer2.Enabled = False
    '        Timer1.Enabled = True
    '        HideSide = 0
    '    End if
    'End Sub

    '窗口大小发生变化
    Private Sub frmain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Timer1.Enabled = False
            Timer2.Enabled = False
        ElseIf Me.WindowState = FormWindowState.Normal Then
            Me.ResumeLayout()
            Timer1.Enabled = True
        End If
    End Sub

    '获取编辑中的文件名修改ipropty
    Private Sub Butto获取文件名修改ipropty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button获取文件名修改ipropty.Click
        SetDocumentIpropertyFromFileName()
    End Sub

    '获取当前部件中的文件名修改ipropty
    Private Sub Button获取部件修改ipropty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button获取部件修改ipropty.Click
        SetDocumentsInAssIpropertyFromFileName()
    End Sub

    '更改零件/部件文件名
    Private Sub Button更改零件部件文件名_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button更改零件部件文件名.Click
        RenameAssPartDocumentName()

    End Sub

    '更改镜像零件/部件文件名
    Private Sub Button更改镜像零件文件名_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button更改镜像零件文件名.Click
        RenameMirrorAssPartDocumentName()

    End Sub

    '帮助
    Private Sub 帮助ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 帮助ToolStripMenuItem.Click
        'Dim HelpMessage As String = "窗口在左和上边缘自动隐藏      当前版本：" & System.Windows.Forms.Application.ProductVersion

        'MsgBox(HelpMessage, MsgBoxStyle.Information)
        Dim strHelpFullFileName As String
        strHelpFullFileName = IO.Path.Combine(My.Application.Info.DirectoryPath, "帮助.pdf")
        If IsFileExsts(strHelpFullFileName) = True Then
            Process.Start(strHelpFullFileName)
        End If
    End Sub

    '设置窗口
    Private Sub 设置ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 设置ToolStripMenuItem.Click
        FrmOptionshow()
    End Sub


    '另存为cad dwg

    Private Sub 另存为DWGToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        IdwSaveAsDwg()
    End Sub

    Private Sub 另存为PDFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        IdwSaveAsPdf()
    End Sub

    '设置工程图比例
    Private Sub 比例ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            SetStatusBarText()

            If ThisApplication.ActiveDocument.DocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim IdwDoc As DrawingDocument
            IdwDoc = ThisApplication.ActiveDocument

            If SetDrawingScale(IdwDoc) Then
                ToolStripStatusLabel1.Text = "设置工程图自定义属性：比例完成"
                'MsgBox("设置工程图自定义属性：比例完成", MsgBoxStyle.Information)
            Else
                ToolStripStatusLabel1.Text = "错误"
                MsgBox("错误", MsgBoxStyle.Exclamation)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '设置工程图自定义属性：对称件IPro
    Private Sub 对称件IProToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 对称件IProToolStripMenuItem.Click
        SetDrawingMirPartIPro()
    End Sub

    '设置自定义属性，签字
    Private Sub 签字ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocument.DocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim IdwDoc As DrawingDocument
            IdwDoc = ThisApplication.ActiveDocument

            Dim Print_Day As String

            Print_Day = Today.Year & "." & Today.Month & "." & Today.Day

            If SetSign(IdwDoc, EngineerName, Print_Day, True) Then
                SetStatusBarText("设置工程图属性：签字完成")
            Else
                SetStatusBarText("错误")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '清除自定义属性，签字
    Private Sub 清除签字ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocument.DocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim IdwDoc As DrawingDocument
            IdwDoc = ThisApplication.ActiveDocument

            If SetSign(IdwDoc, "", "", False) Then
                SetStatusBarText("清除工程图属性，签字完成")
            Else
                SetStatusBarText("错误")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '自定义签字
    Private Sub 自定义签字ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim SignDialog As frmSign
        SignDialog = New frmSign
        SignDialog.ShowDialog()
    End Sub

    Private Sub 保存关闭ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 保存关闭ToolStripMenuItem.Click
        SaveClose()
    End Sub

    '打开自定义属性窗口
    Private Sub 自定义属性ToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmMassiPoperties.ShowDialog()
    End Sub

    '退出程序
    Private Sub 退出ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 退出ToolStripMenuItem.Click
        Me.Dispose()
    End Sub

    '新建序号
    Private Sub 新建序号ToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocument.DocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim IdwDoc As DrawingDocument
            IdwDoc = ThisApplication.ActiveDocument

            '设置为一个动作，可一次撤销
            Dim transientGeometry As TransientGeometry
            transientGeometry = ThisApplication.TransientGeometry
            'start a transaction so the slot will be within a single undo step
            Dim createSlotTransaction As Transaction
            createSlotTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "重新设置序号")

            If SetSerialNumber(IdwDoc) Then
                SetStatusBarText("重新设置序号完成")
                'MsgBox("设置工程图自定义属性：比例完成", MsgBoxStyle.Information)
            Else
                SetStatusBarText("错误")
                'MsgBox("错误", MsgBoxStyle.Exclamation)

            End If

            'end the transactio
            createSlotTransaction.End()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '检查序号完整性
    Private Sub 检查序号完整性ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CheckSerialNumber()
    End Sub

    ' 导出BOM平面性
    Private Sub 导出BOM平面性ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ExportBOMAsFlat()
    End Sub



    Private Sub 打开文件所在文件夹ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 打开文件所在文件夹ToolStripMenuItem.Click
        OpenFolderwithDocument()
    End Sub

    Private Sub 批量另存ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmFormatConversion.ShowDialog()
    End Sub

    Private Sub 设置虚拟件ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 设置虚拟件ToolStripMenuItem.Click

        SetBOMStructuret()

    End Sub


    ''保存文件缩略图
    'Private Sub SaveThumbnail()

    '    Dim invPartDoc As Document = ThisApplication.ActiveDocument
    '    Dim ifilename As String = invPartDoc.FullDocumentName

    '    Dim apprentice As New ApprenticeServerComponent
    '    Dim doc As ApprenticeServerDocument
    '    doc = apprentice.Open(ifilename)
    '    Dim thumbnail As stdole.IPictureDisp
    '    thumbnail = doc.Thumbnail
    '    'Dim img As Image = Microsoft.VisualBasic.Compatibility.VB6.IPictureDispToImage(thumbnail)
    '    'PictureBox1.Image = img

    'End Sub

    Private Sub 打印ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmPrint.Show()
    End Sub

    Private Sub 导入ERPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmImportCodeToIam.ShowDialog()
    End Sub

    Private Sub 查询ERPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmSearchERPCode.ShowDialog()
    End Sub

    Private Sub 导入ERP到BOMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmImportCodeToBomExcel.Show()
    End Sub

    Private Sub 替换图框ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 替换图框ToolStripMenuItem.Click
        ReplaceBorderTitleBlock()
    End Sub

    Private Sub 查找缺失部件ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查找缺失部件ToolStripMenuItem.Click
        GetAsmMissDocument()
    End Sub

    Private Sub 距离对齐ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 距离对齐ToolStripMenuItem.Click
        AlignComponentsInTheCenter()
    End Sub

    Private Sub 另存为DWGToolStripMenuItem_Click(sender As Object, e As EventArgs)
        IdwSaveAsDwg()
    End Sub

    Private Sub 快速打开ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 快速打开ToolStripMenuItem.Click
        QuitOpen()
    End Sub

    Private Sub 关闭ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 关闭ToolStripMenuItem.Click
        CloseDocument()
    End Sub

    Private Sub 保存关闭所有文件ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 保存关闭所有文件ToolStripMenuItem.Click
        FrmSaveCloseAllDocumentShow()
    End Sub


    Private Sub 检查是否有工程图ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 检查是否有工程图ToolStripMenuItem.Click
        CheckIsInvHaveIdw()
    End Sub

    Private Sub 对齐原始坐标面ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 对齐原始坐标面ToolStripMenuItem.Click
        FlushXYZPlane()
    End Sub

    Private Sub 移动指定文件ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 移动指定文件ToolStripMenuItem.Click
        MovesSpecifiedFile()
    End Sub

    Private Sub 提取iproperty更改文件名ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 提取iproperty更改文件名ToolStripMenuItem.Click
        GetIpropertyToRename()
    End Sub

    Private Sub 设置随机颜色ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 设置随机颜色ToolStripMenuItem.Click
        SetRandomColor()
    End Sub

    Private Sub 清除颜色ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 清除颜色ToolStripMenuItem.Click
        ClearRandomColor()
    End Sub

    Private Sub 全部可见ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 全部可见ToolStripMenuItem.Click
        OneKeyShowAll()
    End Sub
    Private Sub 生成图号ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 生成图号ToolStripMenuItem.Click
        FrmAutoPartNumberShow()
    End Sub

    Private Sub 技术要求ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 技术要求ToolStripMenuItem.Click
        FrmSpecificationShow()
    End Sub

    Private Sub 添加直径ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 添加直径ToolStripMenuItem.Click
        AddDiameter()
    End Sub

    Private Sub 尺寸圆整ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 尺寸圆整ToolStripMenuItem.Click
        DimensionRounding()
    End Sub

    Private Sub 尺寸居中ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 尺寸居中ToolStripMenuItem.Click
        CenterDimensions()
    End Sub

    Private Sub 全部居中ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 全部居中ToolStripMenuItem.Click
        CenterAllDimensions()
    End Sub

    Private Sub 检查序号完整性ToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles 检查序号完整性ToolStripMenuItem.Click
        CheckSerialNumber()
    End Sub

    Private Sub 新建序号ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 新建序号ToolStripMenuItem.Click
        CreateNewSequenceNumber()
    End Sub

    Private Sub 自动重建序号ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 自动重建序号ToolStripMenuItem.Click
        RebuildRingSerialNumber()
    End Sub

    Private Sub 重写BOM序号ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 重写BOM序号ToolStripMenuItem.Click
        ReWriteBOM()
    End Sub

    Private Sub 查询ERP编码ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 查询ERP编码ToolStripMenuItem.Click
        FrmSearchERPCodeShow()
    End Sub

    Private Sub ERP反查ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ERP反查ToolStripMenuItem.Click
        FrmReverseCheckERPCodesShow()
    End Sub

    Private Sub 导出BOM平面性ToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles 导出BOM平面性ToolStripMenuItem.Click
        ExportBOMAsFlat()
    End Sub

    Private Sub 导入ERPToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles 导入ERPToolStripMenuItem.Click
        FrmImportERPCodeToIamShow()
    End Sub

    Private Sub 导入ERP到BOMToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles 导入ERP到BOMToolStripMenuItem.Click
        FrmImportERPCodeToExcelshow()
    End Sub

    Private Sub 打开数据文件ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开数据文件ToolStripMenuItem.Click
        OpenBasicExcel()
    End Sub

    Private Sub 签字ToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles 签字ToolStripMenuItem1.Click
        SetUpSigning()
    End Sub

    Private Sub 清除签字ToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles 清除签字ToolStripMenuItem.Click
        ClearSignature()
    End Sub

    Private Sub 自定义签字ToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles 自定义签字ToolStripMenuItem.Click
        FrmCustomSignatureShow()
    End Sub

    Private Sub 快速打印ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 快速打印ToolStripMenuItem.Click
        QuitPrint()
    End Sub

    Private Sub 批量打印ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 批量打印ToolStripMenuItem.Click
        FrmBulkPrintShow()
    End Sub


    Private Sub 格式转换ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 格式转换ToolStripMenuItem.Click
        FrmAllSaveAsShow()
    End Sub

    Private Sub 还原旧图ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 还原旧图ToolStripMenuItem.Click
        RestoreOldVersion()
    End Sub

    Private Sub 清理旧版文件ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 清理旧版文件ToolStripMenuItem.Click
        CleanUpLegacyFiles()
    End Sub

    Private Sub 尺寸ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 尺寸ToolStripMenuItem.Click

    End Sub

    Private Sub 另存为PDFToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles 另存为PDFToolStripMenuItem.Click
        IdwSaveAsPdf()
    End Sub

    Private Sub 另存为DWGToolStripMenuItem_Click_2(sender As Object, e As EventArgs) Handles 另存为DWGToolStripMenuItem.Click
        IdwSaveAsDwg()
    End Sub

    Private Sub 打开指定工程图ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开指定工程图ToolStripMenuItem.Click
        OpenAllDrwInAsm()
    End Sub

    Private Sub 另存为STPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 另存为STPToolStripMenuItem.Click
        AsmIptSaveAsStp()
    End Sub

    Private Sub ButtoniProperty_Click(sender As Object, e As EventArgs) Handles ButtoniProperty.Click
        FrmChangeIproShow()
    End Sub

    Private Sub 量产iPropertyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 量产iPropertyToolStripMenuItem.Click
        frmMassiPopertiesshow()
    End Sub


    Private Sub 批量替换文件名ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 批量替换文件名ToolStripMenuItem.Click
        ReplaceNameInAsm()
    End Sub

    Private Sub 同步目录树ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 同步目录树ToolStripMenuItem.Click
        RefreshTreeShowName()
    End Sub


    Private Sub 设置只读ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 设置只读ToolStripMenuItem.Click
        FrmSetWriteOnlyShow()
    End Sub

    Private WithEvents m_快速打开_Buttondef As ButtonDefinition

    Private Sub AddPanelToToolsTab()
        ' Get the ribbon associated with the part document
        Dim oPartRibbon As Ribbon
        oPartRibbon = ThisApplication.UserInterfaceManager.Ribbons.Item("Part")

        ' Get the "Tools" tab
        Dim oTab As RibbonTab
        oTab = oPartRibbon.RibbonTabs.Item("id_TabTools")

        ' Create a panel named "Update", positioned after the "Measure" panel in the Tools tab.
        Dim oPanel As RibbonPanel
        oPanel = oTab.RibbonPanels.Item("id_PanelP_ToolsOptions")

        ' Get the update commands
        Dim oDef1 As ButtonDefinition
        oDef1 = ThisApplication.CommandManager.ControlDefinitions.Item("InName文件只读")


        Dim oDefs As ObjectCollection
        oDefs = ThisApplication.TransientObjects.CreateObjectCollection

        oDefs.Add(oDef1)

        ' Create a split button control
        'Call oPanel.CommandControls.AddButton(oDef1)

        If oDef1.Pressed = True Then
            oDef1.Pressed = False
        Else
            oDef1.Pressed = True
        End If

        ' Get the rebuild command



    End Sub

    Private Sub 动画设计ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 动画设计ToolStripMenuItem.Click
        FrmPlayerShow()
    End Sub

    Private Sub 标准件可见性ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 标准件可见性ToolStripMenuItem.Click
        SetStandIptVisible()
    End Sub

    Private Sub 替换为库文件ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 替换为库文件ToolStripMenuItem.Click
        ReplaceWithContentCenterFile()
    End Sub

    Private Sub 动态尺寸ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 动态尺寸ToolStripMenuItem.Click
        FrmEditDimensionShow()
    End Sub

    Private Sub 生成展开图ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 创建展开图ToolStripMenuItem.Click
        CreateFlatDrawingDocument()
    End Sub

    Private Sub 查找替换ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 查找替换ToolStripMenuItem.Click
        FindAndReplace()
    End Sub

    Private Sub 生成工程图ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 创建工程图ToolStripMenuItem.Click
        CreatNewDrawingDocument()
    End Sub

    Private Sub 驱动测量ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 驱动测量ToolStripMenuItem.Click
        FrmDim2ObjectShow()

    End Sub

    Private Sub 抑制错误约束ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 抑制错误约束ToolStripMenuItem.Click
        SuppressAllUnhealthConstraints()
    End Sub

    Private Sub 统计焊缝ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 统计焊缝ToolStripMenuItem.Click
        FrmStatisticalShow()

    End Sub

    Private Sub 保存为图片ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 保存为图片ToolStripMenuItem.Click
        CreatJpg()
    End Sub

    Private Sub 打开列表ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开列表ToolStripMenuItem.Click
        OpenFilesWithList()
    End Sub

    Private Sub 保存列表ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 保存列表ToolStripMenuItem.Click
        SaveFilessList()

    End Sub

    Private Sub 替换基础文件ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 替换基础文件ToolStripMenuItem.Click
        ReplaceDerivedPart()
    End Sub

    Private Sub 打开工程图ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开工程图ToolStripMenuItem.Click
        OpenIdwFile()
    End Sub

    Private Sub 关于2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 关于2ToolStripMenuItem.Click
        Dim frmAbout As New frmAbout
        frmAbout.ShowDialog()
    End Sub

    Private Sub 断开链接ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 断开链接ToolStripMenuItem.Click

    End Sub

    Private Sub 标记孔径ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 标记孔径ToolStripMenuItem.Click
        MarkCircleInFlatDrawing()
    End Sub

    Private Sub 另存为DXFToolStripMenuIte_Click(sender As Object, e As EventArgs) Handles 另存为DXFToolStripMenuIte.Click
        IdwSaveAsDxf()
    End Sub

    Private Sub 另存为工程图ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 另存为工程图ToolStripMenuItem.Click
        DrawingDocumentSaveAs()
    End Sub
End Class