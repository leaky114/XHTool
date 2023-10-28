Imports Inventor
Imports Inventor.SelectionFilterEnum
Imports Inventor.DocumentTypeEnum
Imports System.Windows.Forms
Imports System
Imports System.IO
Imports Microsoft
Imports Microsoft.VisualBasic
Imports System.Collections.ObjectModel
Imports System.Runtime.InteropServices

Public Class frmain

    Public Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)

    Private HideSide As Short '隐藏边的位置，0为未隐藏，1为上边，2为左边


    '测试
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click


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

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'AddPanelToToolsTab()
        'If NewUpdater.GetGitVersion = "New" Then
        '    If MsgBox("检查到InAI新版：" & NewVersion & "，是否下载？", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "更新") = MsgBoxResult.Yes Then
        '        Process.Start("https://github.com/leaky114/InAI/tree/master/Release")
        '    End If
        'End If
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

        'If oUserInterfaceManager.InterfaceStyle = InterfaceStyleEnum.kRibbonInterface Then
        '    Dim oRibbon As Inventor.Ribbon
        '    Dim oRibbonTab As Inventor.RibbonTab
        '    Dim oRibbonPanel As Inventor.RibbonPanel

        '    Dim oButtonDefinitions As Inventor.ObjectCollection
        '    oButtonDefinitions = ThisApplication.TransientObjects.CreateObjectCollection



        '    '部件环境
        '    oRibbon = oUserInterfaceManager.Ribbons.Item("Assembly")

        '    oRibbonTab = oRibbon.RibbonTabs.Item("id_TabAssemble")

        'End If

        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


    End Sub


    Private Sub frmain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        End
    End Sub

    Private Sub frmain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim m_quitInventor As Boolean = False
        'Try to get an active instance of Inventor
        Try
            ThisApplication = System.Runtime.InteropServices.Marshal.GetActiveObject("Inventor.Application")
        Catch ex As Exception

        End Try

        ' If not active, create a new Inventor session
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

        '初始化默认值
        WrXml.InAISettingDefaultValue()

        '获取自定义值
        WrXml.InAISettingXmlReadSetting()

        '更新数据库文件
        If BasicExcelFullFileName = "" Then
            BasicExcelFullFileName = My.Application.Info.DirectoryPath & "\最新物料编码.xlsx"
            'MsgBox(Excel_File_Name)
        End If

        Dim documentURL As String
        documentURL = "\\Likai-pc\发行版\更新包\最新物料编码.xlsx"

        If IsFileExsts(documentURL) = True Then
            Dim wc As New System.Net.WebClient
            'wc.DownloadFile(documentURL, BasicExcelFullFileName)
        End If
        'End If

        '下载帮助文件
        documentURL = "\\Likai-pc\发行版\安装包\帮助.docx"

        Dim strHelpFullFileName As String
        strHelpFullFileName = My.Application.Info.DirectoryPath & "\帮助.docx"

        If IsFileExsts(documentURL) = True Then
            Dim wc As New System.Net.WebClient
            wc.DownloadFile(documentURL, strHelpFullFileName)
        End If

        '生成工具栏
        'BuildToolBar()

    End Sub

    Private Sub ReSetLabel()
        ToolStripStatusLabel1.Text = ""
    End Sub

    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    '上边隐藏
    '    If Me.Location.Y < 20 And HideSide <> 2 Then '判断当前窗体位置，如果窗体位置y值小于50那么再进行鼠标位置判断决定是否上移
    '        If Control.MousePosition.X < Me.Location.X Or Control.MousePosition.X > Me.Location.X + Me.Width Or Control.MousePosition.Y < Me.Location.Y Or Control.MousePosition.Y > Me.Location.Y + Height Then
    '            '判断鼠标位置在窗体外，则执行如下程序，注意在判断表达式中不要用等号，否则窗体会闪烁
    '            Me.Location = New System.Drawing.Point(Me.Location.X, 3 - Me.Height) '上边预留3个格供Timer2触发事件用，不留将无法把鼠标移到已隐藏的窗体上
    '            Timer2.Enabled = True
    '            Timer1.Enabled = False
    '            Me.TopMost = True '将上移后的窗体置顶
    '            HideSide = 1
    '        End If
    '    End If

    '    '左边隐藏
    '    If Me.Location.X < 20 And HideSide <> 1 Then '判断当前窗体位置，如果窗体位置y值小于50那么再进行鼠标位置判断决定是否上移
    '        If Control.MousePosition.X < Me.Location.X Or Control.MousePosition.X > Me.Location.X + Me.Width Or Control.MousePosition.Y < Me.Location.Y Or Control.MousePosition.Y > Me.Location.Y + Height Then
    '            '判断鼠标位置在窗体外，则执行如下程序，注意在判断表达式中不要用等号，否则窗体会闪烁
    '            Me.Location = New System.Drawing.Point(3 - Me.Width, Me.Location.Y) '上边预留3个格供Timer2触发事件用，不留将无法把鼠标移到已隐藏的窗体上
    '            Timer2.Enabled = True
    '            Timer1.Enabled = False
    '            Me.TopMost = True '将上移后的窗体置顶
    '            HideSide = 2
    '        End If
    '    End If

    'End Sub

    'Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
    '    If Control.MousePosition.X > Me.Location.X And Control.MousePosition.X < Me.Location.X + Me.Width And Control.MousePosition.Y > Me.Location.Y And Control.MousePosition.Y < Me.Location.Y + Height And HideSide <> 0 Then
    '        '判断鼠标位置在窗体内，则执行如下程序，注意在判断表达式中不要用等号，否则窗体会闪烁
    '        If HideSide = 1 Then
    '            Me.Location = New System.Drawing.Point(Me.Location.X, 0) '靠边显示窗体
    '        ElseIf HideSide = 2 Then
    '            Me.Location = New System.Drawing.Point(0, Me.Location.Y) '靠边显示窗体
    '        End If
    '        Timer2.Enabled = False
    '        Timer1.Enabled = True
    '        HideSide = 0
    '    End If
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


    ''提取iproperty更改文件名
    'Private Sub Button提取iproperty更改文件名_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        SetStatusBarText()

    '        If IsInventorOpenDocument() = False Then
    '            Exit Sub
    '        End If

    '        '判断是否为 assdoc
    '        Dim InventorDoc As Inventor.Document

    '        InventorDoc = ThisApplication.ActiveDocument

    '        If InventorDoc.DocumentType <> kAssemblyDocumentObject Then
    '            MsgBox("该功能仅适用于部件", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If

    '        Dim OldOcc As ComponentOccurrence   '选择的部件或零件
    '        OldOcc = ThisApplication.CommandManager.Pick(kAssemblyOccurrenceFilter, "选择要更改文件名的的零件或部件")

    '        If OldOcc Is Nothing Then       '取消选择
    '            Exit Sub
    '        End If

    '        If GetIpropertyToRenameSub(InventorDoc, OldOcc) Then
    '            SetStatusBarText("提取iproperty更改文件名完成")
    '            'MsgBox("提取iproperty更改文件名完成", MsgBoxStyle.Information)

    '        Else
    '            SetStatusBarText("错误")
    '            MsgBox("错误", MsgBoxStyle.Exclamation)

    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    ''自动生成零件号
    'Private Sub Button自动生成零件图号_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        If IsInventorOpenDocument() = False Then
    '            Exit Sub
    '        End If

    '        IsAutoSetPartName = True

    '        ReSetLabel()

    '        Dim InventorDoc As Inventor.Document     '当前文件
    '        InventorDoc = ThisApplication.ActiveDocument

    '        If InventorDoc.DocumentType <> kAssemblyDocumentObject Then
    '            MsgBox("该功能仅适用于部件", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If

    '        If AutoSetPartNumber(InventorDoc) Then
    '            ToolStripStatusLabel1.Text = "自动生成零件图号完成"
    '        Else
    '            ToolStripStatusLabel1.Text = "错误"
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    '更改镜像零件/部件文件名
    Private Sub Button更改镜像零件文件名_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button更改镜像零件文件名.Click
        RenameMirrorAssPartDocumentName()
    End Sub


   

    '帮助
    Private Sub 帮助ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 帮助ToolStripMenuItem.Click
        Dim HelpMessage As String = "窗口在左和上边缘自动隐藏      当前版本：" & System.Windows.Forms.Application.ProductVersion

        MsgBox(HelpMessage, MsgBoxStyle.Information)

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
        frmSaveAs.ShowDialog()
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

    ''获取未读取的文件所在部件并打开该部件
    'Private Sub GetUnkonwDocument()
    '    Try
    '        If IsInventorOpenDocument() = False Then
    '            Exit Sub
    '        End If

    '        ReSetLabel()

    '        Dim InventorDoc As Inventor.Document     '当前文件
    '        InventorDoc = ThisApplication.ActiveDocument

    '        If InventorDoc.DocumentType <> kAssemblyDocumentObject Then
    '            MsgBox("该功能仅适用于部件", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If

    '        If GetMissDocumentSub(InventorDoc) Then
    '            ToolStripStatusLabel1.Text = "获取当前部件中的文件名修改ipropty完成"
    '            'MsgBox("获取当前部件中的文件名修改ipropty完成", MsgBoxStyle.Information)

    '        Else
    '            ToolStripStatusLabel1.Text = "错误"
    '            MsgBox("错误", MsgBoxStyle.Exclamation)

    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
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

    Private Sub 打开工程图ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开工程图ToolStripMenuItem.Click
        OpenIdwFile()
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
        FrmQueryERPcodeshow()
    End Sub

    Private Sub ERP反查ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ERP反查ToolStripMenuItem.Click
        ReverseCheckERPCodesshow()
    End Sub

    Private Sub 导出BOM平面性ToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles 导出BOM平面性ToolStripMenuItem.Click
        ExportBOMAsFlat()
    End Sub

    Private Sub 导入ERPToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles 导入ERPToolStripMenuItem.Click
        FrmImportCodeToIamShow()
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


    Private Sub 工程图批量另存为ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 工程图批量另存为ToolStripMenuItem.Click
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

    Private Sub 刷新引用ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 刷新引用ToolStripMenuItem.Click
        RefreshShowName()
    End Sub

    Private Sub 统计面积质量ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 统计面积质量ToolStripMenuItem.Click
        frmGetPartshow()
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
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim frmPlayer As New frmPlayer
            frmPlayer.Show()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub 标准件可见性ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 标准件可见性ToolStripMenuItem.Click
        SetStandIptVisible()
    End Sub

    Private Sub 替换为库文件ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 替换为库文件ToolStripMenuItem.Click
        ReplaceWithContentCenterFile()
    End Sub

    Private Sub 编辑尺寸ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 编辑尺寸ToolStripMenuItem.Click
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If


            If ThisApplication.ActiveEditDocument.DocumentType <> kPartDocumentObject Then
                MsgBox("该功能仅适用于零件。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim frmEditDimension As New frmEditDimension
            frmEditDimension.Show()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub 生成展开图ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 生成展开图ToolStripMenuItem.Click
        CreateFlat()
    End Sub
End Class