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
Imports Microsoft.VisualBasic.FileIO
Imports System.Timers

Public Class FormMain


    ' Windows API 声明
    Private Declare Function FindWindowEx Lib "user32" Alias "FindWindowExA" (
    ByVal hWndParent As Long,
    ByVal hWndChildAfter As Long,
    ByVal lpszClass As String,
    ByVal lpszWindow As String
) As Long

    Private Declare Function GetWindowLong Lib "user32" Alias "GetWindowLongA" (
    ByVal hWnd As Long,
    ByVal nIndex As Long
) As Long

    Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (
    ByVal hWnd As Long,
    ByVal nIndex As Long,
    ByVal dwNewLong As Long
) As Long

    Private Const GWL_STYLE As Long = (-16)
    Private Const TVS_HASBUTTONS As Long = &H1
    Private Const TVS_HASLINES As Long = &H2
    Private Const TVS_LINESATROOT As Long = &H4


    Public Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)

    Private HideSide As Short '隐藏边的位置，0为未隐藏，1为上边，2为左边

    'Private WithEvents m_timer As System.Timers.Timer    '计时器


    Public Sub CreateLineWithMidpoint()

        Try
            ' 验证当前文档为零件文档
            Dim oInventorDocument As Inventor.Document = TryCast(ThisApplication.ActiveDocument, PartDocument)
            If oInventorDocument Is Nothing Then
                MessageBox.Show(”请打开零件文档。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' 获取当前激活草图
            Dim oSketch As Sketch = ThisApplication.ActiveEditObject
            If oSketch Is Nothing Then
                MessageBox.Show(”请先激活草图。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If


            ' 创建二维点对象（基于草图局部坐标系）
            Dim tg As TransientGeometry = ThisApplication.TransientGeometry

            Dim oPoint2d As Point2d
            oPoint2d = GetPointInDrawing("选择中心点。")
            If oPoint2d Is Nothing Then
                Exit Sub
            End If

            Dim oCenterPoint2d As Point2d = oPoint2d

            oPoint2d = GetLineInSketch("选择一个端点。", oCenterPoint2d)
            If oPoint2d Is Nothing Then
                Exit Sub
            End If

            Dim oStartPoint2d As Point2d = oPoint2d


            Dim oEndPoint2d As Point2d = tg.CreatePoint2d(
        2 * oCenterPoint2d.X - oStartPoint2d.X,
        2 * oCenterPoint2d.Y - oStartPoint2d.Y
    )

            ' 创建连接两点的直线
            Dim oSketchLine As SketchLine = oSketch.SketchLines.AddByTwoPoints(oStartPoint2d, oEndPoint2d)


            Dim deltaX As Double = oEndPoint2d.X - oStartPoint2d.X
            Dim deltaY As Double = oEndPoint2d.Y - oStartPoint2d.Y

            ' 计算原始角度（-180°到180°）
            Dim angle_rad As Double = Math.Atan2(deltaY, deltaX)
            Dim angle_deg As Double = angle_rad * 180 / Math.PI

            ' 标准化到0-180°
            If angle_deg < 0 Then
                angle_deg += 360
            End If
            angle_deg = angle_deg Mod 180


            ' 添加约束
            Const HORIZONTAL_TOLERANCE As Double = 5
            Const VERTICAL_TOLERANCE As Double = 5

            If (angle_deg >= 0 AndAlso angle_deg <= HORIZONTAL_TOLERANCE) OrElse
       (angle_deg >= 180 - HORIZONTAL_TOLERANCE AndAlso angle_deg <= 180) Then
                ' 水平约束
                oSketch.GeometricConstraints.AddHorizontal(oSketchLine)

            ElseIf angle_deg >= 90 - VERTICAL_TOLERANCE AndAlso angle_deg <= 90 + VERTICAL_TOLERANCE Then
                ' 垂直约束
                oSketch.GeometricConstraints.AddVertical(oSketchLine)
            Else

            End If

            ThisApplication.ActiveView.Update()

        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    '测试
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        '  CreateLineWithMidpoint()
        Dim UiRessourceDocker As DockableWindows = ThisApplication.UserInterfaceManager.DockableWindows

        For Each oChildDockableWindows As DockableWindow In UiRessourceDocker

            If oChildDockableWindows.InternalName = "cheatsheet" Then
                oChildDockableWindows.Visible = False
                oChildDockableWindows.Delete()
                Exit For
            End If

        Next

        Dim cheatSheetWindow As DockableWindow = UiRessourceDocker.Add("214234234", "CheatSheet", "Cheat Sheet")
        cheatSheetWindow.Visible = True
        cheatSheetWindow.DockingState = DockingStateEnum.kDockRight

        Dim oCheatSheet As New FormiProperty

        oCheatSheet.FormBorderStyle = FormBorderStyle.None
        cheatSheetWindow.AddChild(oCheatSheet.Handle)


    End Sub



    'CheckSteelThicknessInAssembly()

    'If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
    '     MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Exit Sub
    'End If

    'Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
    'oInventorAssemblyDocument = ThisApplication.ActiveDocument


    '' 获取装配定义
    'Dim oAssemblyComponentDefinition As AssemblyComponentDefinition
    'oAssemblyComponentDefinition = oInventorAssemblyDocument.ComponentDefinition

    '' 获取装配子集
    'Dim oComponentOccurrences As ComponentOccurrences
    'oComponentOccurrences = oAssemblyComponentDefinition.Occurrences

    ''遍历

    'Dim oInventorPartDocument As Inventor.PartDocument
    'Dim strInventorPartDocumentFullFileName As String

    'For Each oComponentOccurrence As ComponentOccurrence In oComponentOccurrences.AllLeafOccurrences
    '    strInventorPartDocumentFullFileName = oComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName

    '    'Debug.Print(strInventorPartDocumentFullFileName)

    '    oInventorPartDocument = ThisApplication.Documents.Open(strInventorPartDocumentFullFileName, False)


    'Next

    ' MessageBox.Show("检查钣金厚度匹配完成，已打开不匹配的零件。", MsgBoxStyle.Information)

    'Dim oInventorDrawingDocument As Inventor.DrawingDocument
    'oInventorDrawingDocument = ThisApplication.ActiveDocument

    'Dim strParentAssemblyFullFileName As String
    'strParentAssemblyFullFileName = oInventorDrawingDocument.FullDocumentName

    'Debug.Print(strParentAssemblyFullFileName)

    'Dim oSelectSet1 As Object = Nothing

    'oSelectSet1 = oInventorDocument.SelectSet.Item(1)

    'If Not TypeOf oSelectSet1 Is ComponentOccurrence Then
    '    Exit Sub
    'End If

    'If oSelectSet1 Is Nothing Then       '取消选择
    '    Exit Sub
    'End If

    'Dim oComponentOccurrence As ComponentOccurrence
    'oComponentOccurrence = CType(oSelectSet1, ComponentOccurrence)

    'Dim oParentInventorDocument As Inventor.Document

    'oParentInventorDocument = oComponentOccurrence.ReferencedDocumentDescriptor.Parent

    'Dim strParentAssemblyFullFileName As String
    'strParentAssemblyFullFileName = oParentInventorDocument.FullDocumentName

    'Debug.Print(strParentAssemblyFullFileName)

    'ThisApplication.Documents.Open(strParentAssemblyFullFileName, True)




    'oDrawingDimensions.Text.FormattedText = strFormattedText1

    'Select Case oSelectSet.type
    '    Case kAngleConstraintObject, kAssemblySymmetryConstraintObject, kCompositeConstraintObject, kCustomConstraintObject, _
    '        kFlushConstraintObject, kInsertConstraintObject, kMateConstraintObject, kTangentConstraintObject, kTransitionalConstraintObject

    '         MessageBox.Show("约束")
    '    Case kTwoPointDistanceDimConstraintObject, kDiameterDimConstraintObject
    '         MessageBox.Show("2维尺寸")
    '    Case kDimensionConstraints3DObject, kLineLengthDimConstraint3DObject
    '         MessageBox.Show("3维尺寸")
    '    Case kBendConstraintObject, kTwoLineAngleDimConstraint3DObject
    '         MessageBox.Show("折弯尺寸")
    '    Case kPlanarSketchObject
    '         MessageBox.Show("2维草图")

    '    Case kSketch3DObject
    '         MessageBox.Show("3维草图")

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



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click



        'CopyMaterialFromBasicPart()

        'SetBaseQuantityByEach()

        '  CreatePartsList(ThisApplication.ActiveDocument)


        'FormFaceColoringShow()


        'CheckDrawingDocumentNameToReferencedDocument(ThisApplication.ActiveDocument)

        'Dim oUserInterfaceMgr As UserInterfaceManager
        'oUserInterfaceMgr = ThisApplication.UserInterfaceManager

        'Try
        '    oUserInterfaceMgr.DockableWindows.Item("TestWindowInternalName").Delete()
        'Catch ex As Exception

        'End Try

        '' Create a new dockable window
        'Dim oWindow As DockableWindow
        'oWindow = oUserInterfaceMgr.DockableWindows.Add("SampleClientId", "TestWindowInternalName", "文件浏览器")

        '' Get the hwnd of the dialog to be added as a child
        '' CHANGE THIS VALUE!
        'Dim hwnd As Long
        'hwnd = 4851096

        '' Add the dialog as a child to the dockable window
        'oWindow.AddChild(hwnd)

        '' Don't allow docking to top and bottom
        'oWindow.DisabledDockingStates = DockingStateEnum.kDockTop + DockingStateEnum.kDockBottom

        '' Make the window visible
        'oWindow.ShowTitleBar = True
        'oWindow.Visible = True

        'Dim oCheatSheet As New FormAbout
        'oWindow.AddChild(oCheatSheet.Handle.ToInt64)


        'CloneComponentAndInsertConstraint()
        'SelectPartNodeInBrowserNode()
        'OpenSelectComponentOccurrences()
        'FormExplorerShow()
        '        FormPantoneShow()

        'FormBatchCommandShow()


        'On Error Resume Next

        'Dim obutton As clsRightMouseTurnOffAdaptivity
        'obutton = New clsRightMouseTurnOffAdaptivity()

        'SetDrawingSize(DrawingSheetSizeEnum.kA4DrawingSheetSize)


        ' 获取所有引用文档
        'Dim oAssemblyDocument As Inventor.AssemblyDocument
        'oAssemblyDocument = ThisApplication.ActiveDocument

        'Dim oAllReferencedDocuments As DocumentsEnumerator
        'oAllReferencedDocuments = oAssemblyDocument.AllReferencedDocuments

        'Dim oProgressBar As Inventor.ProgressBar
        'oProgressBar = ThisApplication.CreateProgressBar(False, oAllReferencedDocuments.Count, "Test Progress")

        ''遍历这些文档()

        'For Each ReferencedDocument As Document In oAllReferencedDocuments
        '    Debug.Print(ReferencedDocument.DisplayName)
        '    oProgressBar.Message = ReferencedDocument.FullDocumentName
        '    oProgressBar.UpdateProgress()
        'Next

        'oProgressBar.Close()
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

    End Sub

    Private Sub Frmain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Windows.Forms.Application.Exit()
    End Sub

    Private Sub Frmain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
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


        IniFile = IO.Path.Combine(My.Application.Info.DirectoryPath, "InAISetting.ini")

        If IsFileExists(IniFile) = False Then
            '初始化默认值
            'WrXml.InAISettingDefaultValue()

            '获取自定义值
            'WrXml.InAISettingXmlReadSetting()

            WrIni.InAISettingIniWriteSetting()
        End If

        WrIni.InAISettingIniReadSetting()


        m_timer = New System.Timers.Timer
        m_timer.Interval = Integer.Parse(str保存间隔时间 * 1000 * 60)            ' Set timer for 10 minutes (600000 milliseconds)
        m_timer.AutoReset = True
        'm_timer.Start()

        '更新数据库文件
        If BasicExcelFullFileName = "" Then
            BasicExcelFullFileName = IO.Path.Combine(My.Application.Info.DirectoryPath, "最新物料编码.xlsx")
            ' MessageBox.Show(Excel_File_Name)
        End If

        Dim documentURL As String
        documentURL = "\\Likai-pc\发行版\更新包\最新物料编码.xlsx"

        If IsFileExists(documentURL) = True Then
            Dim wc As New System.Net.WebClient
            'wc.DownloadFile(documentURL, BasicExcelFullFileName)
        End If
        'End if

        '下载帮助文件
        documentURL = "\\Likai-pc\发行版\安装包\帮助.docx"

        Dim strHelpFullFileName As String
        strHelpFullFileName = IO.Path.Combine(My.Application.Info.DirectoryPath, "帮助.docx")

        If IsFileExists(documentURL) = True Then
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
    Private Sub Frmain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
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
        RenamePartFileNameInAssembly()

    End Sub

    '更改镜像零件/部件文件名
    Private Sub Button更改镜像零件文件名_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button更改镜像零件文件名.Click
        RenameMirrorPartFileNameInAssembly()

    End Sub

    '帮助
    Private Sub 帮助ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 帮助ToolStripMenuItem.Click
        'Dim HelpMessage As String = "窗口在左和上边缘自动隐藏      当前版本：" & System.Windows.Forms.Application.ProductVersion

        ' MessageBox.Show(HelpMessage, MsgBoxStyle.Information)
        Dim strHelpFullFileName As String
        strHelpFullFileName = IO.Path.Combine(My.Application.Info.DirectoryPath, "帮助.pdf")
        If IsFileExists(strHelpFullFileName) = True Then
            ProcessStart(strHelpFullFileName)
        Else
            ProcessStart(Bilibili)
        End If
    End Sub

    '设置窗口
    Private Sub 选项ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 选项ToolStripMenuItem.Click
        FormOptionshow()
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
                MessageBox.Show(”该功能仅适用于工程图。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim IdwDoc As DrawingDocument
            IdwDoc = ThisApplication.ActiveDocument

            If SetDrawingScale(IdwDoc) Then
                ToolStripStatusLabel1.Text = "设置工程图自定义属性：比例完成"
                ' MessageBox.Show("设置工程图自定义属性：比例完成", MsgBoxStyle.Information)
            Else
                ToolStripStatusLabel1.Text = XHTool
                MessageBox.Show(”设置工程图比例错误。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                MessageBox.Show(”该功能仅适用于工程图。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim IdwDoc As DrawingDocument
            IdwDoc = ThisApplication.ActiveDocument

            Dim Print_Day As String

            Print_Day = Today.Year & "." & Today.Month & "." & Today.Day

            If SetSign(IdwDoc, EngineerName, Print_Day, True) Then
                SetStatusBarText("设置工程图属性：签字完成")
            Else
                SetStatusBarText(XHTool)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                MessageBox.Show(”该功能仅适用于工程图。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim IdwDoc As DrawingDocument
            IdwDoc = ThisApplication.ActiveDocument

            If SetSign(IdwDoc, "", "", False) Then
                SetStatusBarText("清除工程图属性，签字完成")
            Else
                SetStatusBarText(XHTool)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '自定义签字
    Private Sub 自定义签字ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim SignDialog As FormCustomSignature
        SignDialog = New FormCustomSignature
        SignDialog.ShowDialog()
    End Sub

    Private Sub 保存关闭ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 保存关闭ToolStripMenuItem.Click
        SaveClose()
    End Sub

    '打开自定义属性窗口
    Private Sub 自定义属性ToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        formBatchiPoperties.ShowDialog()
    End Sub

    '退出程序
    Private Sub 退出ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 退出ToolStripMenuItem.Click
        Me.Dispose()
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
        FormFormatConversion.ShowDialog()
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
        FormBulkPrintShow()
    End Sub

    Private Sub 导入ERPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormImportCodeToIam.ShowDialog()
    End Sub

    Private Sub 查询ERPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormSearchERPCode.ShowDialog()
    End Sub

    Private Sub 导入ERP到BOMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormImportCodeToBomExcel.Show()
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
        FormSaveCloseAllDocumentShow()
    End Sub


    Private Sub 检查是否有工程图ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 检查是否有工程图ToolStripMenuItem.Click
        CheckIsInvHaveIdw()
    End Sub

    Private Sub 对齐原始坐标面ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 对齐原始坐标面ToolStripMenuItem.Click
        FlushXYZPlane()
    End Sub

    Private Sub 移动指定文件ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 移动指定文件ToolStripMenuItem.Click
        'MovesSpecifiedFile()

        FormMovesSpecifiedFileShow()
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
        FormAutoPartNumberShow()
    End Sub


    Private Sub 技术要求ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 技术要求ToolStripMenuItem.Click
        FormSpecificationShow()
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
        FormSearchERPCodeShow()
    End Sub

    Private Sub ERP反查ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ERP反查ToolStripMenuItem.Click
        FormReverseCheckERPCodesShow()
    End Sub

    Private Sub 导出BOM平面性ToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles 导出BOM平面性ToolStripMenuItem.Click
        ExportBOMAsFlat()
    End Sub

    Private Sub 导入ERPToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles 导入ERPToolStripMenuItem.Click
        FormImportERPCodeToIamShow()
    End Sub

    Private Sub 导入ERP到BOMToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles 导入ERP到BOMToolStripMenuItem.Click
        FormImportERPCodeToExcelshow()
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
        FormCustomSignatureShow()
    End Sub

    Private Sub 快速打印ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 快速打印ToolStripMenuItem.Click
        QuitPrint()
    End Sub

    Private Sub 批量打印ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 批量打印ToolStripMenuItem.Click
        FormBulkPrintShow()
    End Sub


    Private Sub 格式转换ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 格式转换ToolStripMenuItem.Click
        FormFormatConversionShow()
    End Sub

    Private Sub 还原旧图ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 还原旧图ToolStripMenuItem.Click
        RestoreOldVersion()
    End Sub

    Private Sub 清理旧版文件ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 清理旧版文件ToolStripMenuItem.Click
        CleanUpLegacyFiles()
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
        FormiPropertyShow()
    End Sub

    Private Sub 量产iPropertyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 量产iPropertyToolStripMenuItem.Click
        FormMassiPopertiesshow()
    End Sub


    Private Sub 批量替换文件名ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 批量替换文件名ToolStripMenuItem.Click
        'ReplaceNameInAsm()

        FormBatchChangeFileNamesShow()

    End Sub

    Private Sub 同步目录树ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 同步目录树ToolStripMenuItem.Click
        RefreshTreeNodeName()
    End Sub

    Private Sub 设置只读ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 设置只读ToolStripMenuItem.Click
        FormSetReadOnlyShow()
    End Sub

    Private Sub 动画设计ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 动画设计ToolStripMenuItem.Click
        FormPlayerShow()
    End Sub

    Private Sub 标准件可见性ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 标准件可见性ToolStripMenuItem.Click
        SetStandIptVisible()
    End Sub

    Private Sub 替换为库文件ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 替换为库文件ToolStripMenuItem.Click
        ReplaceWithContentCenterFile()
    End Sub

    Private Sub 动态尺寸ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 动态尺寸ToolStripMenuItem.Click
        FormEditDimensionShow()
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
        FormDim2ObjectShow()

    End Sub

    Private Sub 抑制错误约束ToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'SuppressAllUnhealthConstraints()
    End Sub

    Private Sub 统计焊缝ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 统计焊缝ToolStripMenuItem.Click
        FormStatisticalShow()

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
        FormAboutShow()
    End Sub

    Private Sub 断开链接ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 断开链接ToolStripMenuItem.Click

    End Sub

    Private Sub 标记孔径ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 标记孔径ToolStripMenuItem.Click
        MarkCircleInFlatDrawing()
    End Sub

    Private Sub 另存为DXFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 另存为DXFToolStripMenuItem.Click
        IdwSaveAsDxf()
    End Sub

    Private Sub 工程图另存为副本ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 工程图另存为副本ToolStripMenuItem.Click
        DrawingDocumentSaveAs()
    End Sub

    Private Sub 创建工艺图ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 创建工艺图ToolStripMenuItem.Click
        FormFlatPatternShow()
    End Sub

    Private Sub 切换文档ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 切换文档ToolStripMenuItem.Click
        FormSwitchLablesShow()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If ThisApplication.ActiveDocument.SelectSet.Count = 0 Then
            Exit Sub
        End If

        Dim oSelectObject = ThisApplication.ActiveDocument.SelectSet(1)
        Dim strTypeName As String
        strTypeName = TypeName(oSelectObject)

        Debug.Print(strTypeName)
        MessageBox.Show(strTypeName)

        Select Case strTypeName
            Case "Face"
                Dim oface As Face = CType(oSelectObject, Face)

                Try
                    Dim oThreadInfo As ThreadInfo
                    oThreadInfo = oface.ThreadInfos.Item(1)
                    MessageBox.Show(oThreadInfo.NominalSize)

                    Exit Sub
                Catch

                End Try


                If oface.SurfaceType = SurfaceTypeEnum.kCylinderSurface Then

                    For Each oedge As Edge In oface.Edges
                        If FourFive(oedge.StartVertex.Point.X - oedge.StopVertex.Point.X, 4) = 0 And FourFive(oedge.StartVertex.Point.Y - oedge.StopVertex.Point.Y, 4) = 0 And FourFive(oedge.StartVertex.Point.Z - oedge.StopVertex.Point.Z, 4) = 0 Then
                            Try
                                Dim Cyl As Cylinder = oface.Geometry
                                Dim CylRadius As Double = Cyl.Radius
                                MessageBox.Show(CylRadius)
                                Exit For
                            Catch

                            End Try
                        End If
                    Next
                End If

            Case "Edge"
                Dim oEdge As Edge = CType(oSelectObject, Edge)



        End Select

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 菜单工具ToolStripMenuItem.Click
        FormNetTool.Show()
    End Sub

    Private Sub 自定义iPropertyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 自定义iPropertyToolStripMenuItem.Click
        FormUseriPropertyShow()
    End Sub

    Private Sub 另存为副本ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 另存为副本ToolStripMenuItem.Click
        AsmIptDocumentSaveAs()
    End Sub

    Private Sub 克隆组件ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 克隆组件ToolStripMenuItem.Click
        CloneComponentAndInsertConstraint()
    End Sub

    Private Sub 在浏览器中查找ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 在浏览器中查找ToolStripMenuItem.Click
        SelectPartNodeInBrowserNode()
    End Sub

    Private Sub 打开父部件ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开父部件ToolStripMenuItem.Click
        OpenParentAssembly()
    End Sub

    Private Sub 打开选择的组件ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开选择的组件ToolStripMenuItem.Click
        OpenSelectComponentOccurrences()
    End Sub

    Public Sub TestGetDrawingPoint()
        Dim getPoint As New ClsGetPoint
        Dim pnt1 As Point2d
        Dim pnt2 As Point2d
        Do
            pnt1 = getPoint.GetDrawingPoint("Click the desired location", MouseButtonEnum.kLeftMouseButton, CursorTypeEnum.kCursorBuiltInCrosshair)
            If pnt1 IsNot Nothing Then

                Dim lineLen As Double
                lineLen = InputBox("Enter the length of line")

                Dim line_orientation As String
                line_orientation = InputBox("Type H(Horizontal) or V(Vertical)")

                line_orientation = UCase(line_orientation)

                Dim hor_Alignment As String
                Dim ver_Alignment As String

                If line_orientation = "H" Then
                    hor_Alignment = InputBox("Type L(Left) or R(Right)")
                    hor_Alignment = UCase(hor_Alignment)

                    If hor_Alignment = "L" Then
                        pnt2 = ThisApplication.TransientGeometry.CreatePoint2d(pnt1.X - lineLen, pnt1.Y)
                    ElseIf hor_Alignment = "R" Then
                        pnt2 = ThisApplication.TransientGeometry.CreatePoint2d(pnt1.X + lineLen, pnt1.Y)
                    Else
                        MessageBox.Show("Invalid entry for horizantal alignment")
                    End If
                ElseIf line_orientation = "V" Then
                    ver_Alignment = InputBox("Type U(Upward) or D(Downward)")
                    ver_Alignment = UCase(ver_Alignment)

                    If ver_Alignment = "U" Then
                        pnt2 = ThisApplication.TransientGeometry.CreatePoint2d(pnt1.X, pnt1.Y + lineLen)
                    ElseIf ver_Alignment = "D" Then
                        pnt2 = ThisApplication.TransientGeometry.CreatePoint2d(pnt1.X, pnt1.Y - lineLen)
                    Else
                        MessageBox.Show("Invalid entry for vertical alignment")
                    End If
                Else
                    MessageBox.Show("Invalid Entry for line orientation")
                End If


            End If
        Loop While pnt1 IsNot Nothing
    End Sub

    Private Sub 钣金厚度检查ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 钣金厚度检查ToolStripMenuItem.Click
        CheckSteelThicknessInPart()
    End Sub

    Private Sub 清净世界ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 清净世界ToolStripMenuItem.Click
        ClearErrorTagging()
    End Sub


    Private Sub 检查钣金厚度ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 检查钣金厚度ToolStripMenuItem.Click

        CheckSteelThicknessInAssembly()

    End Sub

    Private Sub 资源管理器ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 资源管理器ToolStripMenuItem.Click
        FormExplorerShow()
    End Sub

    Private Sub 修改序号ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 修改序号ToolStripMenuItem.Click
        ModifySerialNumber()
    End Sub

    Private Sub 批量BOM命名ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 批量BOM命名ToolStripMenuItem.Click
        FormiPropertyToFileNameShow()
    End Sub

    Private Sub 设置孔颜色ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 设置孔颜色ToolStripMenuItem.Click
        SameDiameterHoleColoring（）
    End Sub

    Private Sub 油路块着色ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 油路块着色ToolStripMenuItem.Click
        FormOilBlockHoleColoringShow()
    End Sub

    Private Sub 清理冗余五年级ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 清理冗余五年级ToolStripMenuItem.Click
        FormCleanUpRedundantFilesShow()
    End Sub

    Private Sub 复制材料ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 复制材料ToolStripMenuItem.Click
        CopyMaterialFromBasicPart()
    End Sub
End Class