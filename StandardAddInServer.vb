
Imports Inventor
Imports Inventor.DocumentTypeEnum
Imports Inventor.SelectionFilterEnum
Imports Microsoft
Imports Microsoft.VisualBasic
Imports Microsoft.Win32
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Drawing
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Net
Imports System

Namespace InventorAddIn

    <ProgIdAttribute("InventorAddIn.StandardAddInServer"), _
    GuidAttribute("0a8e6d1d-68ec-48be-9e61-32779d2aae77")> _
    Public Class StandardAddInServer
        Implements Inventor.ApplicationAddInServer

        Private WithEvents m_uiEvents As UserInterfaceEvents
        Private WithEvents m_userInputEvents As UserInputEvents

#Region "Data Member"

        '============================================================
        '定义 按钮
        '
        Private WithEvents m_ERP反查_Buttondef As ButtonDefinition
        Private WithEvents m_按列表打开文件_Buttondef As ButtonDefinition
        Private WithEvents m_帮助_Buttondef As ButtonDefinition
        Private WithEvents m_保存为列表_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_保存关闭_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_保存关闭所有部件_Buttondef As ButtonDefinition
        Private WithEvents m_标准件可见性_Buttondef As ButtonDefinition
        Private WithEvents m_部件替换文件名_Buttondef As ButtonDefinition
        Private WithEvents m_插入序号_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_查询ERP编码_Buttondef As ButtonDefinition
        Private WithEvents m_查找缺失文件的部件_Buttondef As ButtonDefinition
        Private WithEvents m_查找替换_Buttondef As ButtonDefinition
        Private WithEvents m_尺寸居中_Buttondef As ButtonDefinition
        Private WithEvents m_尺寸圆整_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_创建工程图_Buttondef As ButtonDefinition
        Private WithEvents m_创建截屏_Buttondef As ButtonDefinition
        Private WithEvents m_创建展开图_Buttondef As ButtonDefinition
        Private WithEvents m_打开ERP数据文件_Buttondef As ButtonDefinition
        Private WithEvents m_打开工程图_Buttondef As ButtonDefinition
        Private WithEvents m_打开全部工程图_Buttondef As ButtonDefinition
        Private WithEvents m_打开文件夹_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_打开指定工程图_Buttondef As ButtonDefinition
        Private WithEvents m_导出平面BOM_Buttondef As ButtonDefinition
        Private WithEvents m_导入ERP编码_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_导入ERP到BOM_Buttondef As ButtonDefinition
        Private WithEvents m_动态尺寸_Buttondef As ButtonDefinition
        Private WithEvents m_对齐原始坐标面_Buttondef As ButtonDefinition
        Private WithEvents m_更改材料_Buttondef As ButtonDefinition
        Private WithEvents m_更改镜像文件名_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_更改文件名_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_工程图批量另存为_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_关闭文档_Buttondef As ButtonDefinition
        Private WithEvents m_关于_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_还原旧图_Buttondef As ButtonDefinition
        Private WithEvents m_技术要求_Buttondef As ButtonDefinition
        Private WithEvents m_检查是否有工程图_Buttondef As ButtonDefinition
        Private WithEvents m_检查序号完整性_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_标记展开图螺纹_Buttondef As ButtonDefinition
        Private WithEvents m_居中对齐_Buttondef As ButtonDefinition
        Private WithEvents m_快速打开_Buttondef As ButtonDefinition
        Private WithEvents m_快速打印_Buttondef As ButtonDefinition
        Private WithEvents m_量产iPropertys_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_另存工程图_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_另存为Dwg_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_另存为Dxf_Buttondef As ButtonDefinition
        Private WithEvents m_另存为Pdf_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_另存为Stp_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_批量打印_Buttondef As ButtonDefinition
        Private WithEvents m_切换文档_Buttondef As ButtonDefinition
        Private WithEvents m_清除签字_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_清除日期_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_清除随机颜色_Buttondef As ButtonDefinition
        Private WithEvents m_清理旧版文件_Buttondef As ButtonDefinition
        Private WithEvents m_驱动测量_Buttondef As ButtonDefinition
        Private WithEvents m_全部尺寸居中_Buttondef As ButtonDefinition
        Private WithEvents m_全部可见_Buttondef As ButtonDefinition
        Private WithEvents m_全部另存为_Buttondef As ButtonDefinition
        Private WithEvents m_设值随机颜色_Buttondef As ButtonDefinition
        Private WithEvents m_设置_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_设置BOM结构_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_设置比例_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_设置对称件iProperty_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_设置签字_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_设置日期_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_设置只读_Buttondef As ButtonDefinition
        Private WithEvents m_输入查询ERP编码_Buttondef As ButtonDefinition
        Private WithEvents m_刷新引用_Buttondef As ButtonDefinition
        Private WithEvents m_提取iPro修改文件名_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_替换图框标题栏_Buttondef As ButtonDefinition
        Private WithEvents m_替换为库文件_Buttondef As ButtonDefinition
        Private WithEvents m_替换衍生_Buttondef As ButtonDefinition
        Private WithEvents m_添加直径_Buttondef As ButtonDefinition
        Private WithEvents m_统计_Buttondef As ButtonDefinition
        Private WithEvents m_新建序号_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_修改部件iProperty_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_修改文件iProperty_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_移动指定文件_Buttondef As ButtonDefinition
        Private WithEvents m_抑制全部错误的约束_Buttondef As ButtonDefinition
        Private WithEvents m_只读属性_Buttondef As ButtonDefinition
        Private WithEvents m_重写BOM序号_Buttondef As ButtonDefinition
        Private WithEvents m_自定义IPro_Buttondef As ButtonDefinition
        Private WithEvents m_自定义签字_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_自定义日期_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_自动生成图号_Buttondef As Inventor.ButtonDefinition
        Private WithEvents m_自动重建序号_Buttondef As ButtonDefinition
        Private WithEvents m_关闭自适应_Buttondef As ButtonDefinition

        '================================================================================

#End Region

        ' Inventor application object.
        'Private   ThisApplication As Inventor.Application

#Region "ApplicationAddInServer Members"

        Public Sub Activate(ByVal addInSiteObject As Inventor.ApplicationAddInSite, ByVal firstTime As Boolean) Implements Inventor.ApplicationAddInServer.Activate

            ' This method is called by Inventor when it loads the AddIn.
            ' The AddInSiteObject provides access to the Inventor Application object.
            ' The FirstTime flag indicates if the AddIn is loaded for the first time.
            'On Error Resume Next

            ' Initialize AddIn members.
            ThisApplication = addInSiteObject.Application

            '打开文件时事件
            ThisApplicationEvents = ThisApplication.ApplicationEvents
            AddHandler ThisApplicationEvents.OnOpenDocument, AddressOf ThisApplicationEvents_OnOpenDocument
            AddHandler ThisApplicationEvents.OnActivateDocument, AddressOf ThisApplicationEvents_OnActivateDocument
            'AddHandler ThisApplicationEvents.OnSaveDocument, AddressOf ThisApplicationEvents_OnOnSaveDocument

            ' TODO:  Add ApplicationAddInServer.Activate implementation.
            ' e.g. event initialization, command creation etc.

            '当前inventor 版本
            DisplayVersion = ThisApplication.SoftwareVersion.DisplayVersion

            '初始化零件库
            ContentCenterFiles = ThisApplication.FileOptions.ContentCenterPath
            'MsgBox(ContentCenterFiles)

            '初始化模型匹配检查标记
            str模型匹配检查标记 = 1

            Inifile = IO.Path.Combine(My.Application.Info.DirectoryPath, "InAISetting.ini")
            If IsFileExsts(IniFile) = False Then
                '初始化默认值
                'WrXml.InAISettingDefaultValue()

                '获取自定义值
                'WrXml.InAISettingXmlReadSetting()

                WrIni.InAISettingIniWriteSetting()
            End If

            WrIni.InAISettingIniReadSetting()

            '检查更新
            'NewUpdater.Shell_XHUpdater()

            If CheckUpdate = "1" Then
                NewUpdater.Shell_XHUpdater()
            End If

            'NewUpdater.UpDater2(False)

            ''IsShowUpdateMsg = False
            ''Dim frmupdate As New frmUpdate
            ''frmupdate.Visible = False
            ''frmupdate.ShowDialog()

            ''If NewUpdater.CreateUpdate() = True Then

            'If NewUpdater.GetGitVersion = "New" Then
            '    'If MsgBox("检查到InAI新版：" & NewVersion & "，是否下载？", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "更新") = MsgBoxResult.Yes Then
            '    '    'Process.Start("https://github.com/leaky114/InAI/tree/master/Release")
            '    '    'Process.Start("https://www.aliyundrive.com/s/C3CerE58Fkn")

            '    '    Dim strUpdaterForInAI As String
            '    '    strUpdaterForInAI = My.Application.Info.DirectoryPath & "\UpdaterForInAI.exe"

            '    '    If IsFileExsts(strUpdaterForInAI) = False Then
            '    '        Dim strNetUpdaterForInAI As String = ""
            '    '        DownNetFile(strNetUpdaterForInAI, strUpdaterForInAI)
            '    '    End If

            '    '    Process.Start(strUpdaterForInAI)

            '    'End If



            'End If

            'If NewUpdater.CheckNewVesion = "New" Then

            '    '释放更新程序
            '    'NewUpdater.CreateUpdateExe()

            '    NewUpdater.UpDate3()

            'End If


            '更新数据库文件
            If IsFileExsts(BasicExcelFullFileName) = False Then
                BasicExcelFullFileName = IO.Path.Combine(My.Application.Info.DirectoryPath, ServerExcelFileName)
            End If

            If BasicExcelFullFileName = "" Then
                BasicExcelFullFileName = IO.Path.Combine(My.Application.Info.DirectoryPath, ServerExcelFileName)
                'MsgBox(Excel_File_Name)
            End If

            Dim documentURL As String
            documentURL = Server & ServerExcelFileName

            If IsFileExsts(documentURL) = True Then
                Dim wc As New System.Net.WebClient
                wc.DownloadFile(documentURL, BasicExcelFullFileName)
            End If
            'End If

            '下载帮助文件
            documentURL = Server & "帮助.pdf"

            Dim strHelpFullFileName As String
            strHelpFullFileName = IO.Path.Combine(My.Application.Info.DirectoryPath, "帮助.pdf")

            If IsFileExsts(documentURL) = True Then
                Dim wc As New System.Net.WebClient
                wc.DownloadFile(documentURL, strHelpFullFileName)
            End If

            '创建按钮
            CreatUI(firstTime)

            'Catch ex As Exception
            '    MsgBox(ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation)

            'End Try


        End Sub

#Region "建立UI"
        Public Sub CreatUI(ByVal bfirstTime As Boolean)
            On Error Resume Next
            Dim oCommandManager As CommandManager
            Dim oUserInterfaceManager As UserInterfaceManager
            'Dim oIPictureDisp32 As Object  '大图标
            'Dim oIPictureDisp8 As Object   '小图标

            Dim smallPicture As stdole.IPictureDisp
            Dim largePicture As stdole.IPictureDisp

            'Try
            oCommandManager = ThisApplication.CommandManager
            oUserInterfaceManager = ThisApplication.UserInterfaceManager

            'clientId = Me.GetType().GUID.ToString("B")
            ClientID = AddInGuid(GetType(StandardAddInServer))
            '---------------------------------------------------------------------------------------
            'create button's definition here
            'm_修改文件iProperty_Buttondef = New 修改文件iProperty_Button("修改文件iProperty", "InName修改文件iProperty", _
            '                       CommandTypesEnum.kShapeEditCmdType, clientId, , , , , )
            '1
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.修改文件iProperty16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.修改文件iProperty32.ToBitmap)

            m_修改文件iProperty_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("提取iProperty", "InName修改文件iProperty", _
                                  CommandTypesEnum.kShapeEditCmdType, ClientID, , "以第一个汉字为标识，提取文件名中的图号和名称，根据【iProperty映射】的设置，写入【iProperty】【项目】中的字段。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '2
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.修改部件iProperty16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.修改部件iProperty32.ToBitmap)
            m_修改部件iProperty_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("提取部件iProperty", "InName修改部件iProperty", _
                                  CommandTypesEnum.kShapeEditCmdType, ClientID, "", "根据【BOM表】【结构化】的数据，设置下一级或所有级文件的iProperty。注意：将忽略零件库和参考文件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '3
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.更改文件名16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.更改文件名32.ToBitmap)
            m_更改文件名_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("更改文件名", "InName更改文件名", _
                                  CommandTypesEnum.kShapeEditCmdType, ClientID, "", "在部件文件中选择一个文件，修改其文件名，将替换选中的文件或全部文件。若在与文件同一文件夹中存在其同名工程图，将生成新的工程图。注意：将忽略零件库。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '4
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.提取iPro修改文件名16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.提取iPro修改文件名32.ToBitmap)
            m_提取iPro修改文件名_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("提取iPro修改文件名", "InName提取iPro修改文件名", _
                   CommandTypesEnum.kShapeEditCmdType, ClientID, "", "在部件文件中选择一个文件，根据【iProperty映射】设置，提取【iProperty】【项目】中的字段，修改选取文件的文件名。与【修改部件iProperty】反向。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '5
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.生成图号16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.生成图号32.ToBitmap)
            m_自动生成图号_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("自动生成图号", "InName自动生成图号", _
                  CommandTypesEnum.kShapeEditCmdType, ClientID, "", "根据第一级部件的图号，设置子级部件或零件的图号变化规则，重命名其文件名。对于新设计先命名后图号特别有用。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '6
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.更改镜像文件名16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.更改镜像文件名32.ToBitmap)
            m_更改镜像文件名_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("更改镜像文件名", "InName更改镜像文件名", _
                  CommandTypesEnum.kShapeEditCmdType, ClientID, "", "在部件中选择一个是镜像生成的文件，修改其文件名，将原基础文件改为临时文件，重新手动指定其基础文件，后还原基础文件。对于基础文件和镜像文件都需修改的文件很有用。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '7
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.关闭文档16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.关闭文档32.ToBitmap)
            m_关闭文档_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("关闭", "InName关闭当前文档", _
                                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "关闭当前文档。 ", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.打开文件夹16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.打开文件夹32.ToBitmap)
            ' Create the button definition.
            m_打开文件夹_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("打开文件夹", "InName打开文件夹", _
                           CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开当前文件所在的文件夹。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '8
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.保存关闭16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.保存关闭32.ToBitmap)
            m_保存关闭_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("保存关闭", "InName保存关闭", _
                   CommandTypesEnum.kShapeEditCmdType, ClientID, "", "保存并关闭当前打开的文件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '9
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.另存为Pdf16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.另存为Pdf32.ToBitmap)
            m_另存为Pdf_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("另存为Pdf", "InName另存为Pdf", _
              CommandTypesEnum.kShapeEditCmdType, ClientID, "", "将当前文件另存为Pdf格式。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '10
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.另存为Dwg16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.另存为Dwg32.ToBitmap)
            m_另存为Dwg_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("另存为Dwg", "InName另存为Dwg", _
               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "将当前文件另存为Dwg格式。可能 因为设置的不同而是 Zip 格式的，也将其打开。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '11
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.设置BOM结构16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.设置BOM结构32.ToBitmap)
            m_设置BOM结构_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("设置虚拟件", "InName设置BOM结构", _
                  CommandTypesEnum.kShapeEditCmdType, ClientID, "", "在部件中使用，输入序号，将部件的所有子级设置为对应的BOM结构。对与液压管等特别有用。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '12
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.设置比例16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.设置比例32.ToBitmap)
            m_设置比例_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("设置比例", "InName设置比例", _
                   CommandTypesEnum.kShapeEditCmdType, ClientID, "", "获取工程图主视图的比例，根据【比例映射】的设置，写入【iProperty】【自定义】字段。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '13
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.对称件iProperty16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.对称件iProperty32.ToBitmap)
            m_设置对称件iProperty_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("对称件iProperty", "InName对称件iProperty", _
                                  CommandTypesEnum.kShapeEditCmdType, ClientID, "", "选择一个文件，根据【对称件iProperty映射】的设置，将其iProperty写入【iProperty】【自定义】字段。对于对称件的工程图很有用。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '14
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.检查序号完整性16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.检查序号完整性32.ToBitmap)
            m_检查序号完整性_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("检查序号完整性", "InName检查序号完整性", _
                           CommandTypesEnum.kShapeEditCmdType, ClientID, "", "检查工程图的序号是否标注完整。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '15
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.新建序号16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.新建序号32.ToBitmap)
            m_新建序号_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("新建序号", "InName新建序号", _
                  CommandTypesEnum.kShapeEditCmdType, ClientID, "", "重新对工程图的序号进行变化，使寻找序号更简便。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '16
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.设置日期16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.设置日期32.ToBitmap)
            m_设置日期_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("设置日期", "InName设置日期", _
                                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "根据【签字】【打印日期】的设置，将当前日期写入【iProperty】【自定义】字段。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '17
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.替换衍生32.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.替换衍生16.ToBitmap)
            m_替换衍生_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("替换基础文件", "InName替换基础文件", _
              CommandTypesEnum.kShapeEditCmdType, ClientID, "", "替换衍生零件的基础文件，请选择一个新的基础文件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '18
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.抑制约束16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.抑制约束16.ToBitmap)
            m_抑制全部错误的约束_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("抑制错误约束", "InName自定义日期", _
           CommandTypesEnum.kShapeEditCmdType, ClientID, "", " 抑制全部错误的约束", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '19
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.设置签字16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.设置签字32.ToBitmap)
            m_设置签字_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("设置签字", "InName设置签字", _
                     CommandTypesEnum.kShapeEditCmdType, ClientID, "", "根据【签字】【工程师】的设置，将当前日期写入【iProperty】【自定义】字段。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '20
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.清除签字16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.清除签字32.ToBitmap)
            m_清除签字_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("清除签字", "InName清除签字", _
               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '21
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.自定义签字16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.自定义签字32.ToBitmap)
            m_自定义签字_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("自定义签字", "InName自定义签字", _
                  CommandTypesEnum.kShapeEditCmdType, ClientID, "", "", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '22
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.设置16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.设置32.ToBitmap)
            m_设置_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("设置", "InName设置", _
                     CommandTypesEnum.kShapeEditCmdType, ClientID, "打开【设置】窗口，对配置进行设置。", "", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '23
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.量产iPropertys16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.量产iPropertys32.ToBitmap)
            m_量产iPropertys_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("量产iProperty", "InName量产iProperty", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开【量产iProperty】窗口，对多个文件设置【iProperty】。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '24
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.格式转换16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.格式转换32.ToBitmap)
            m_工程图批量另存为_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("格式转换", "InName格式转换", _
                 CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开【格式转换】窗口，批量转换Inventor文件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '25
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.关于16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.关于32.ToBitmap)
            m_关于_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("关于", "InName关于", _
                 CommandTypesEnum.kShapeEditCmdType, ClientID, "", "", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '26
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.保存全部16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.保存全部32.ToBitmap)
            m_保存关闭所有部件_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("保存关闭所有部件", "InName保存关闭所有部件", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "保存并关闭打开的所有部件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '27
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.查询16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.查询32.ToBitmap)
            m_输入查询ERP编码_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("查询ERP编码", "InName输入查询ERP编码", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "输入图号或名称查询ERP编码。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '28
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.标题栏16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.标题栏32.ToBitmap)
            m_替换图框标题栏_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("替换图框标题栏", "InName替换图框标题栏", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "以Inventor安装文件夹下的 模板.idw 文件为基础，替换图框标题栏。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '29
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.自动重建序号16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.自动重建序号32.ToBitmap)
            m_自动重建序号_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("自动重建序号", "InName自动重建序号", _
               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "按极角排序（环形）自动重建序号。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '30
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.创建展开16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.创建展开16.ToBitmap)
            m_创建展开图_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("创建展开图", "InName创建展开图", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "在部件中批量或在零件中创建钣金零件展开图，保存到子目录《钣金展开》。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '31
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.刷新引用16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.刷新引用32.ToBitmap)
            m_刷新引用_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("刷新引用", "InName刷新引用", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "刷新浏览器中的引用名称。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '32
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.清理旧版文件16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.清理旧版文件32.ToBitmap)
            m_清理旧版文件_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("清理旧版文件", "InName清理旧版文件", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "扫描指定路径下的旧版文件，删除之。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '33
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.添加直径16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.添加直径32.ToBitmap)
            m_添加直径_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("添加直径", "InName添加直径", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "在尺寸前添加 Φ。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '35
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.检查是否有工程图16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.检查是否有工程图32.ToBitmap)
            m_检查是否有工程图_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("检查是否有工程图", "InName检查是否有工程图", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "检查部件中指定图号的文件是否有对应的工程图。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '36
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.工程图16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.工程图32.ToBitmap)
            m_打开全部工程图_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("打开全部工程图", "InName打开全部工程图", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开部件中所有子级对应的工程图。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '37
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.部件替换文件名16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.部件替换文件名32.ToBitmap)
            m_部件替换文件名_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("批量替换文件名", "InName部件替换文件名", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "批量替换部件中子集文件的文件名。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '38
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.导出平面BOM16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.导出平面BOM32.ToBitmap)
            m_导出平面BOM_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("导出平面BOM", "InName导出平面BOM", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "根据BOM导出项目，导出平面性的BOM为Excel文件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '39
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.还原旧图16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.还原旧图32.ToBitmap)
            m_还原旧图_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("还原旧图", "InName还原旧图", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "还原更改文件名后的 .old 文件为原始文件名。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '40
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.工程图16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.工程图32.ToBitmap)
            m_另存工程图_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("另存工程图", "InName另存工程图", _
                                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "另存工程图，并查询对应的零部件，替换之。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.帮助16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.帮助32.ToBitmap)
            m_帮助_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("帮助", "InName帮助", _
                                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开帮助文件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '36
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.工程图16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.工程图32.ToBitmap)
            m_打开指定工程图_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("打开指定工程图", "InName打开指定工程图", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开部件中所有包含指定图号子级的对应的工程图。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '41
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.移动指定文件16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.移动指定文件32.ToBitmap)
            m_移动指定文件_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("移动指定文件", "InName移动指定文件", _
               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "移到组件中指定前缀的零件和组件到当前组件所在文件夹。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '42
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.对齐原始坐标面16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.对齐原始坐标面32.ToBitmap)
            m_对齐原始坐标面_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("对齐坐标系", "InName对齐原始坐标面", _
               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "选择部件中的两个部件或零件，使其原始坐标面对齐。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '43
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.查找缺失文件的部件16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.查找缺失文件的部件32.ToBitmap)
            m_查找缺失文件的部件_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("查找缺失文件的部件", "InName查找缺失文件的部件", _
               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "查找当前部件中缺失的文件，并打开缺失文件的父级部件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '44
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.统计16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.统计32.ToBitmap)
            m_统计_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("统计", "InName统计", _
               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "选择部件中的部件或零件，统计总质量，面积，焊缝。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '45
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.IPro16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.IPro32.ToBitmap)
            m_自定义IPro_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("iProperty+", "InName自定义IPro", _
               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "自定义设置iProperty。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '44:
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.创建工程图16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.创建工程图32.ToBitmap)
            m_创建工程图_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("创建工程图", "InName创建工程图", _
               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "创建一个工程图，需要设置一个模板文件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '47
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.尺寸圆整16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.尺寸圆整32.ToBitmap)
            m_尺寸圆整_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("尺寸圆整", "InName尺寸圆整", _
               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "四舍五入尺寸小数位到个位。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '48
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.导入材料编码16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.导入材料编码32.ToBitmap)
            m_导入ERP编码_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("导入ERP编码到模型", "InName导入存货编码", _
               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "导入ERP编码。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '49
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.设置材料编码16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.设置材料编码32.ToBitmap)
            m_ERP反查_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("ERP编码反查", "InNameERP反查", _
               CommandTypesEnum.kShapeEditCmdType, ClientID, "", "输入ERP编码，查询数据。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '50
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.工程图16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.工程图32.ToBitmap)
            m_打开工程图_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("打开工程图", "InName打开工程图", _
              CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开当前文件或部件中选择的文件对应的工程图。 ", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '51
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.批量打印16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.批量打印32.ToBitmap)
            m_批量打印_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("批量打印", "InName批量打印", _
              CommandTypesEnum.kShapeEditCmdType, ClientID, "", "批量打印工程图。 ", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '52
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.重写BOM16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.重写BOM32.ToBitmap)
            m_重写BOM序号_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("重写BOM序号", "InName重写BOM序号", _
              CommandTypesEnum.kShapeEditCmdType, ClientID, "", "重写BOM序号并按序号升序排序。 ", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '53:
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.查询16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.查询32.ToBitmap)
            m_查询ERP编码_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("查询ERP编码", "InName查询ERP编码", _
              CommandTypesEnum.kShapeEditCmdType, ClientID, "", "在Excel数据表中查询ERP编码。 ", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '54
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.打开ERP数据文件16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.打开ERP数据文件32.ToBitmap)
            m_打开ERP数据文件_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("打开ERP数据文件", "InName打开ERP数据文件", _
              CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开ERP数据文件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '55
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.打开文件16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.打开文件32.ToBitmap)
            m_快速打开_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("快速打开", "InName快速打开", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "在当前项目中快速打开指定文件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '56
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.导入ERP到BOM16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.导入ERP到BOM32.ToBitmap)
            m_导入ERP到BOM_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("导入ERP编码到BOM", "InName导入ERP到BOM", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "导入ERP编码到Excel格式BOM文件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            '57
            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.快速打印16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.快速打印32.ToBitmap)
            m_快速打印_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("快速打印", "InName快速打印", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "按默认设值立即打印本工程图。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.设值随机颜色16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.设值随机颜色32.ToBitmap)
            m_设值随机颜色_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("设值随机颜色", "InName设值随机颜色", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "设值部件中零件为随机颜色。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.清除随机颜色16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.清除随机颜色32.ToBitmap)
            m_清除随机颜色_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("清除随机颜色", "InName清除随机颜色", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "清除部件中零件的随机颜色。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.技术要求16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.技术要求32.ToBitmap)
            m_技术要求_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("技术要求", "InName技术要求", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开技术要求。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.居中对齐16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.居中对齐32.ToBitmap)
            m_居中对齐_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("距离对齐", "InName距离对齐", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "已两个零件的两组平行边的距离为偏移量，添加平齐约束。", _
                smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.尺寸居中16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.尺寸居中32.ToBitmap)
            m_尺寸居中_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("尺寸居中", "InName尺寸居中", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "将选择的尺寸文本居中。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.全部尺寸居中16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.全部尺寸居中32.ToBitmap)
            m_全部尺寸居中_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("全部居中", "InName全部尺寸居中", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "将全部尺寸文本居中。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.可见16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.可见32.ToBitmap)
            m_全部可见_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("全部可见", "InName全部可见", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "一键显示所有零部件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.可写16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.可写32.ToBitmap)
            m_设置只读_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("设置只读", "InName设置只读", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开设置只读窗口。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.可写16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.可写32.ToBitmap)
            m_只读属性_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("文件只读", "InName文件只读", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "单击设置当前编辑文件属性，被按下时为文件只读。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.标准件可见性16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.标准件可见性32.ToBitmap)
            m_标准件可见性_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("标准件可见性", "InName标准件可见性", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "一键显示隐藏所有标准件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.替换为库文件16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.替换为库文件32.ToBitmap)
            m_替换为库文件_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("替换为库文件", "InName替换为库文件", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "将组件中的自定义标准件替换为库文件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.编辑尺寸16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.编辑尺寸32.ToBitmap)
            m_动态尺寸_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("动态尺寸", "InName动态尺寸", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "动态编辑草图尺寸，实时更新到模型。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.查找替换16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.查找替换32.ToBitmap)
            m_查找替换_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("查找替换", "InName查找替换", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "在部件中选择一个零部件，查询当前项目和资源中心文件夹，替换相同文件名的文件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.驱动测量16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.驱动测量32.ToBitmap)
            m_驱动测量_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("驱动测量", "InName驱动测量", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "先选择2个对象，再选择1个尺寸驱动，动态测量2个对象之间的最小距离。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.创建截图16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.创建截图32.ToBitmap)
            m_创建截屏_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("创建截屏", "InName创建截屏", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "创建截屏图，保存到 ..桌面\截图 文件夹。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.按列表打开16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.按列表打开32.ToBitmap)
            m_按列表打开文件_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("按列表打开文件", "InName按列表打开文件", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开一个txt文本文件，按行读取文件名，在当前项目中查找并打开。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.打开文件16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.打开文件32.ToBitmap)
            m_切换文档_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("切换文档", "InName切换文档", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "打开一个文档选择窗口。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.另存为Dxf16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.另存为dxf32.ToBitmap)
            m_另存为Dxf_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("另存为Dxf", "InName另存为Dxf", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "将当前文件另存为Dxf格式。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.标记展开图螺纹16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.标记展开图螺纹32.ToBitmap)
            m_标记展开图螺纹_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("简化孔", "InName简化展开图孔", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "简化钣金展开图中孔的螺纹，按直径转换为标记孔。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.按列表打开32.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.按列表打开32.ToBitmap)
            m_保存为列表_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("保存为列表", "InName保存为列表", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "将当前激活的文件路径保存为列表，下次批量打开。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.自适应32.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.自适应32.ToBitmap)
            m_关闭自适应_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("关闭自适应", "InName关闭自适应", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "关闭选择零部件的自适应。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)

            smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.其他格式16.ToBitmap)
            largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.其他格式32.ToBitmap)
            m_另存为Stp_Buttondef = oCommandManager.ControlDefinitions.AddButtonDefinition("另存为Stp", "InName另存为Stp", _
                CommandTypesEnum.kShapeEditCmdType, ClientID, "", "零部件另存为Stp文件。", smallPicture, largePicture, ButtonDisplayEnum.kDisplayTextInLearningMode)



            If bfirstTime Then

                '==========================================

                If oUserInterfaceManager.InterfaceStyle = InterfaceStyleEnum.kRibbonInterface Then
                    Dim oRibbon As Inventor.Ribbon
                    Dim oRibbonTab As Inventor.RibbonTab
                    Dim oRibbonPanel As Inventor.RibbonPanel

                    Dim oButtonDefinitions As Inventor.ObjectCollection
                    oButtonDefinitions = ThisApplication.TransientObjects.CreateObjectCollection
                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    '启动环境
                    oRibbon = oUserInterfaceManager.Ribbons.Item("ZeroDoc")
                    '快速入门
                    oRibbonTab = oRibbon.RibbonTabs.Item("id_GetStarted")       '
                    oRibbonPanel = oRibbonTab.RibbonPanels.Add(XHTool, "ShinMaywaAssemblyPanel", ClientID)

                    oRibbonPanel.CommandControls.AddButton(m_快速打开_Buttondef, True)
                    oRibbonPanel.CommandControls.AddButton(m_按列表打开文件_Buttondef, True)

                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_输入查询ERP编码_Buttondef)
                    oButtonDefinitions.Add(m_ERP反查_Buttondef)
                    oButtonDefinitions.Add(m_导入ERP到BOM_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_输入查询ERP编码_Buttondef, oButtonDefinitions, False)

                    oRibbonPanel.CommandControls.AddButton(m_技术要求_Buttondef, False)

                    '==========================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_设置_Buttondef)
                    oButtonDefinitions.Add(m_工程图批量另存为_Buttondef)
                    oButtonDefinitions.Add(m_批量打印_Buttondef)
                    oButtonDefinitions.Add(m_还原旧图_Buttondef)
                    oButtonDefinitions.Add(m_清理旧版文件_Buttondef)

                    oButtonDefinitions.Add(m_帮助_Buttondef)
                    oButtonDefinitions.Add(m_关于_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_设置_Buttondef, oButtonDefinitions, False)
                    '==========================================

                    '工具
                    oRibbonTab = oRibbon.RibbonTabs.Item("id_TabTools")
                    oRibbonPanel = oRibbonTab.RibbonPanels.Add(XHTool, "ShinMaywaAssemblyPanel", ClientID)

                    oRibbonPanel.CommandControls.AddButton(m_快速打开_Buttondef, True)

                    oRibbonPanel.CommandControls.AddButton(m_输入查询ERP编码_Buttondef, False)
                    oRibbonPanel.CommandControls.AddButton(m_ERP反查_Buttondef, False)

                    '==========================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_设置_Buttondef)
                    oButtonDefinitions.Add(m_保存为列表_Buttondef)
                    oButtonDefinitions.Add(m_工程图批量另存为_Buttondef)
                    oButtonDefinitions.Add(m_批量打印_Buttondef)
                    oButtonDefinitions.Add(m_还原旧图_Buttondef)
                    oButtonDefinitions.Add(m_清理旧版文件_Buttondef)
                    oButtonDefinitions.Add(m_导入ERP到BOM_Buttondef)
                    oButtonDefinitions.Add(m_帮助_Buttondef)
                    oButtonDefinitions.Add(m_关于_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_设置_Buttondef, oButtonDefinitions, False)
                    '==========================================

                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    '部件环境
                    oRibbon = oUserInterfaceManager.Ribbons.Item("Assembly")

                    '工具选项卡
                    'oRibbonTab = oRibbon.RibbonTabs.Item("id_TabTools")

                    '装配选项卡
                    oRibbonTab = oRibbon.RibbonTabs.Item("id_TabAssemble")

                    '在零部件栏添加
                    oRibbonPanel = oRibbonTab.RibbonPanels.Item("id_PanelA_AssembleComponent")

                    oRibbonPanel.CommandControls("AssemblyReplaceSplit").ChildControls.AddButton(m_查找替换_Buttondef)

                    '在关系栏添加
                    oRibbonPanel = oRibbonTab.RibbonPanels.Item("id_PanelA_AssembleRelationships")

                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_对齐原始坐标面_Buttondef)
                    oButtonDefinitions.Add(m_居中对齐_Buttondef)
                    oButtonDefinitions.Add(m_抑制全部错误的约束_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_对齐原始坐标面_Buttondef, oButtonDefinitions, False)


                    '在测量栏添加
                    oRibbonPanel = oRibbonTab.RibbonPanels.Item("id_PanelA_ToolsMeasure")
                    oRibbonPanel.CommandControls.AddButton(m_驱动测量_Buttondef)

                    ' Create a new panel on the Assemble tab.

                    oRibbonPanel = oRibbonTab.RibbonPanels.Add(XHTool, "ShinMaywaAssemblyPanel", ClientID)
                    ' Add the buttons to the tab, with the first and last ones being large and the other two small.


                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_快速打开_Buttondef)
                    oButtonDefinitions.Add(m_按列表打开文件_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_快速打开_Buttondef, oButtonDefinitions, True)


                    '==========================================
                    oButtonDefinitions.Clear()
                    oRibbonPanel.CommandControls.AddButton(m_保存关闭_Buttondef, True)
                    oRibbonPanel.CommandControls.AddButton(m_关闭文档_Buttondef, True)
                    'oRibbonPanel.CommandControls.AddButton(m_打开工程图_Buttondef, True)
                    '==============================================

                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_打开工程图_Buttondef)
                    oButtonDefinitions.Add(m_创建工程图_Buttondef)
                    oButtonDefinitions.Add(m_创建展开图_Buttondef)
                    oButtonDefinitions.Add(m_创建截屏_Buttondef)
                    oButtonDefinitions.Add(m_另存为Stp_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_打开工程图_Buttondef, oButtonDefinitions, True)

                    '==========================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_修改文件iProperty_Buttondef)
                    oButtonDefinitions.Add(m_修改部件iProperty_Buttondef)
                    'oButtonDefinitions.Add(m_设置描述_Buttondef)
                    'oButtonDefinitions.Add(m_设置采购来源_Buttondef)
                    oButtonDefinitions.Add(m_自定义IPro_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_修改文件iProperty_Buttondef, oButtonDefinitions, True)

                    '==========================================

                    oRibbonPanel.CommandControls.AddButton(m_只读属性_Buttondef, False)
                    oRibbonPanel.CommandControls.AddButton(m_动态尺寸_Buttondef, False)

                    '==========================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_检查是否有工程图_Buttondef)
                    'oButtonDefinitions.Add(m_打开全部工程图_Buttondef)
                    oButtonDefinitions.Add(m_打开指定工程图_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_检查是否有工程图_Buttondef, oButtonDefinitions, False)

                    '==========================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_更改文件名_Buttondef)
                    oButtonDefinitions.Add(m_更改镜像文件名_Buttondef)
                    oButtonDefinitions.Add(m_提取iPro修改文件名_Buttondef)
                    oButtonDefinitions.Add(m_部件替换文件名_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_更改文件名_Buttondef, oButtonDefinitions, False)
                    '==========================================

                    'oRibbonPanel.CommandControls.AddButton(m_编辑尺寸_Buttondef, False)

                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_输入查询ERP编码_Buttondef)
                    oButtonDefinitions.Add(m_ERP反查_Buttondef)
                    oButtonDefinitions.Add(m_导出平面BOM_Buttondef)
                    oButtonDefinitions.Add(m_导入ERP编码_Buttondef)
                    oButtonDefinitions.Add(m_导入ERP到BOM_Buttondef)
                    oButtonDefinitions.Add(m_打开ERP数据文件_Buttondef)

                    oRibbonPanel.CommandControls.AddPopup(m_输入查询ERP编码_Buttondef, oButtonDefinitions, False)

                    '==========================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_打开文件夹_Buttondef)
                    oButtonDefinitions.Add(m_保存关闭所有部件_Buttondef)

                    oButtonDefinitions.Add(m_移动指定文件_Buttondef)
                    oButtonDefinitions.Add(m_查找缺失文件的部件_Buttondef)

                    oButtonDefinitions.Add(m_设置只读_Buttondef)

                    oButtonDefinitions.Add(m_关闭自适应_Buttondef)

                    oButtonDefinitions.Add(m_全部可见_Buttondef)
                    oButtonDefinitions.Add(m_标准件可见性_Buttondef)

                    oButtonDefinitions.Add(m_设值随机颜色_Buttondef)
                    oButtonDefinitions.Add(m_清除随机颜色_Buttondef)

                    oButtonDefinitions.Add(m_自动生成图号_Buttondef)
                    oButtonDefinitions.Add(m_设置BOM结构_Buttondef)

                    oButtonDefinitions.Add(m_替换为库文件_Buttondef)

                    oButtonDefinitions.Add(m_刷新引用_Buttondef)

                    oButtonDefinitions.Add(m_统计_Buttondef)

                    'oButtonDefinitions.Add(m_切换文档_Buttondef)

                    oRibbonPanel.CommandControls.AddPopup(m_打开文件夹_Buttondef, oButtonDefinitions, False)

                    '==========================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_设置_Buttondef)
                    oButtonDefinitions.Add(m_保存为列表_Buttondef)
                    oButtonDefinitions.Add(m_量产iPropertys_Buttondef)
                    oButtonDefinitions.Add(m_工程图批量另存为_Buttondef)
                    oButtonDefinitions.Add(m_批量打印_Buttondef)
                    oButtonDefinitions.Add(m_还原旧图_Buttondef)
                    oButtonDefinitions.Add(m_清理旧版文件_Buttondef)
                    oButtonDefinitions.Add(m_帮助_Buttondef)
                    oButtonDefinitions.Add(m_关于_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_设置_Buttondef, oButtonDefinitions, False)
                    '==========================================

                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    '零件环境
                    oRibbon = oUserInterfaceManager.Ribbons.Item("Part")

                    '工具选项卡
                    'oRibbonTab = oRibbon.RibbonTabs.Item("id_TabTools")

                    '模型选项卡
                    oRibbonTab = oRibbon.RibbonTabs.Item("id_TabModel")

                    oRibbonPanel = oRibbonTab.RibbonPanels.Add(XHTool, "ShinMaywaPartPanel", ClientID)

                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_快速打开_Buttondef)
                    oButtonDefinitions.Add(m_按列表打开文件_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_快速打开_Buttondef, oButtonDefinitions, True)


                    '==========================================
                    oButtonDefinitions.Clear()
                    oRibbonPanel.CommandControls.AddButton(m_保存关闭_Buttondef, True)
                    oRibbonPanel.CommandControls.AddButton(m_关闭文档_Buttondef, True)
                    'oRibbonPanel.CommandControls.AddButton(m_打开工程图_Buttondef, True)

                    '==============================================

                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_打开工程图_Buttondef)
                    oButtonDefinitions.Add(m_创建工程图_Buttondef)
                    oButtonDefinitions.Add(m_创建截屏_Buttondef)
                    oButtonDefinitions.Add(m_另存为Stp_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_打开工程图_Buttondef, oButtonDefinitions, True)

                    '==========================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_修改文件iProperty_Buttondef)
                    oButtonDefinitions.Add(m_自定义IPro_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_修改文件iProperty_Buttondef, oButtonDefinitions, True)

                    '=======================================================
                    oRibbonPanel.CommandControls.AddButton(m_只读属性_Buttondef, False)
                    oRibbonPanel.CommandControls.AddButton(m_动态尺寸_Buttondef, False)

                    '===================================================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_输入查询ERP编码_Buttondef)
                    oButtonDefinitions.Add(m_ERP反查_Buttondef)
                    oButtonDefinitions.Add(m_导入ERP到BOM_Buttondef)
                    oButtonDefinitions.Add(m_打开ERP数据文件_Buttondef)

                    oRibbonPanel.CommandControls.AddPopup(m_输入查询ERP编码_Buttondef, oButtonDefinitions, False)

                    '===================================================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_打开文件夹_Buttondef)
                    oButtonDefinitions.Add(m_保存关闭所有部件_Buttondef)
                    oButtonDefinitions.Add(m_创建展开图_Buttondef)
                    oButtonDefinitions.Add(m_替换衍生_Buttondef)

                    oRibbonPanel.CommandControls.AddPopup(m_打开文件夹_Buttondef, oButtonDefinitions, False)

                    '========================================================

                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_设置_Buttondef)
                    oButtonDefinitions.Add(m_保存为列表_Buttondef)
                    oButtonDefinitions.Add(m_量产iPropertys_Buttondef)
                    oButtonDefinitions.Add(m_工程图批量另存为_Buttondef)
                    oButtonDefinitions.Add(m_批量打印_Buttondef)
                    oButtonDefinitions.Add(m_还原旧图_Buttondef)
                    oButtonDefinitions.Add(m_清理旧版文件_Buttondef)
                    oButtonDefinitions.Add(m_帮助_Buttondef)
                    oButtonDefinitions.Add(m_关于_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_设置_Buttondef, oButtonDefinitions, False)
                    '=============================================================

                    '钣金选项卡+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    oRibbonTab = oRibbon.RibbonTabs.Item("id_TabSheetMetal")

                    oRibbonPanel = oRibbonTab.RibbonPanels.Add(XHTool, "ShinMaywaPartPanel", ClientID)

                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_快速打开_Buttondef)
                    oButtonDefinitions.Add(m_按列表打开文件_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_快速打开_Buttondef, oButtonDefinitions, True)


                    '==========================================
                    oButtonDefinitions.Clear()
                    oRibbonPanel.CommandControls.AddButton(m_保存关闭_Buttondef, True)
                    oRibbonPanel.CommandControls.AddButton(m_关闭文档_Buttondef, True)
                    'oRibbonPanel.CommandControls.AddButton(m_打开工程图_Buttondef, True)

                    '==============================================

                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_打开工程图_Buttondef)
                    oButtonDefinitions.Add(m_创建工程图_Buttondef)
                    oButtonDefinitions.Add(m_创建展开图_Buttondef)
                    oButtonDefinitions.Add(m_创建截屏_Buttondef)
                    oButtonDefinitions.Add(m_另存为Stp_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_打开工程图_Buttondef, oButtonDefinitions, True)

                    '==========================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_修改文件iProperty_Buttondef)
                    oButtonDefinitions.Add(m_自定义IPro_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_修改文件iProperty_Buttondef, oButtonDefinitions, True)

                    '==========================================
                    oRibbonPanel.CommandControls.AddButton(m_只读属性_Buttondef, False)

                    oRibbonPanel.CommandControls.AddButton(m_动态尺寸_Buttondef, False)

                    '===================================================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_输入查询ERP编码_Buttondef)
                    oButtonDefinitions.Add(m_ERP反查_Buttondef)
                    oButtonDefinitions.Add(m_导入ERP到BOM_Buttondef)
                    oButtonDefinitions.Add(m_打开ERP数据文件_Buttondef)

                    oRibbonPanel.CommandControls.AddPopup(m_输入查询ERP编码_Buttondef, oButtonDefinitions, False)

                    '===================================================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_打开文件夹_Buttondef)
                    oButtonDefinitions.Add(m_保存关闭所有部件_Buttondef)

                    oButtonDefinitions.Add(m_替换衍生_Buttondef)

                    oRibbonPanel.CommandControls.AddPopup(m_打开文件夹_Buttondef, oButtonDefinitions, False)

                    '========================================================

                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_设置_Buttondef)
                    oButtonDefinitions.Add(m_保存为列表_Buttondef)
                    oButtonDefinitions.Add(m_量产iPropertys_Buttondef)
                    oButtonDefinitions.Add(m_工程图批量另存为_Buttondef)
                    oButtonDefinitions.Add(m_批量打印_Buttondef)
                    oButtonDefinitions.Add(m_还原旧图_Buttondef)
                    oButtonDefinitions.Add(m_清理旧版文件_Buttondef)
                    oButtonDefinitions.Add(m_帮助_Buttondef)
                    oButtonDefinitions.Add(m_关于_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_设置_Buttondef, oButtonDefinitions, False)
                    '=============================================================

                    '二维草图+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    oRibbonTab = oRibbon.RibbonTabs.Item("id_TabSketch")

                    oRibbonPanel = oRibbonTab.RibbonPanels.Add(XHTool, "ShinMaywaSketchPanel", ClientID)
                    oRibbonPanel.CommandControls.AddButton(m_动态尺寸_Buttondef, False)



                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    '工程图环境
                    oRibbon = oUserInterfaceManager.Ribbons.Item("Drawing")
                    'oRibbonTab = oRibbon.RibbonTabs.Item("id_TabPlaceViews")

                    '在放置视图选项卡中添加

                    oRibbonTab = oRibbon.RibbonTabs.Item("id_TabPlaceViews")
                    oRibbonPanel = oRibbonTab.RibbonPanels.Add(XHTool, "ShinMaywaDrawingPanel", ClientID)

                    oRibbonPanel.CommandControls.AddButton(m_快速打开_Buttondef, True)

                    '==========================================
                    oButtonDefinitions.Clear()
                    oRibbonPanel.CommandControls.AddButton(m_保存关闭_Buttondef, True)
                    oRibbonPanel.CommandControls.AddButton(m_关闭文档_Buttondef, True)
                    oRibbonPanel.CommandControls.AddButton(m_打开文件夹_Buttondef, True)

                    '==========================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_修改文件iProperty_Buttondef)
                    oButtonDefinitions.Add(m_自定义IPro_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_修改文件iProperty_Buttondef, oButtonDefinitions, True)
                    '==========================================

                    oRibbonPanel.CommandControls.AddButton(m_只读属性_Buttondef, False)
                    '==========================================

                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_另存为Dwg_Buttondef)
                    oButtonDefinitions.Add(m_另存为Pdf_Buttondef)
                    oButtonDefinitions.Add(m_另存工程图_Buttondef)
                    oButtonDefinitions.Add(m_另存为Dxf_Buttondef)
                    oButtonDefinitions.Add(m_标记展开图螺纹_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_另存为Dwg_Buttondef, oButtonDefinitions, False)
                    '==========================================

                    '==========================================
                    '日期popup  '签字popup
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_设置签字_Buttondef)
                    oButtonDefinitions.Add(m_清除签字_Buttondef)
                    oButtonDefinitions.Add(m_自定义签字_Buttondef)

                    oRibbonPanel.CommandControls.AddPopup(m_设置签字_Buttondef, oButtonDefinitions, False)
                    '==========================================

                    '==========================================

                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_快速打印_Buttondef)
                    oButtonDefinitions.Add(m_批量打印_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_快速打印_Buttondef, oButtonDefinitions, False)

                    '==========================================

                    ''在工具选项卡中添加
                    'oRibbonTab = oRibbon.RibbonTabs.Item("id_TabTools")
                    'oRibbonPanel = oRibbonTab.RibbonPanels.Add("InAI", "ShinMaywaDrawingPanel", ClientID)

                    '==========================================
                    'oButtonDefinitions.Clear()
                    'oRibbonPanel.CommandControls.AddButton(m_保存关闭_Buttondef, True)
                    'oRibbonPanel.CommandControls.AddButton(m_关闭文档_Buttondef, True)
                    'oRibbonPanel.CommandControls.AddButton(m_打开文件夹_Buttondef, True)
                    '==========================================

                    '==========================================
                    'oButtonDefinitions.Clear()
                    'oButtonDefinitions.Add(m_修改文件iProperty_Buttondef)
                    'oButtonDefinitions.Add(m_自定义IPro_Buttondef)
                    'oRibbonPanel.CommandControls.AddPopup(m_修改文件iProperty_Buttondef, oButtonDefinitions, True)
                    '==========================================

                    '==========================================
                    'oButtonDefinitions.Clear()
                    'oButtonDefinitions.Add(m_另存为Dwg_Buttondef)
                    'oButtonDefinitions.Add(m_另存为Pdf_Buttondef)
                    ''oButtonDefinitions.Add(m_全部另存为_Buttondef)
                    'oRibbonPanel.CommandControls.AddPopup(m_另存为Dwg_Buttondef, oButtonDefinitions, False)
                    '==========================================

                    '==========================================

                    '----------------------------------------------------------------------------------
                    ''日期popup  '签字popup
                    'oButtonDefinitions.Clear()

                    'oButtonDefinitions.Add(m_设置签字_Buttondef)
                    'oButtonDefinitions.Add(m_清除签字_Buttondef)
                    'oButtonDefinitions.Add(m_自定义签字_Buttondef)

                    'oRibbonPanel.CommandControls.AddPopup(m_设置签字_Buttondef, oButtonDefinitions, False)

                    '----------------------------------------------------------------------------------
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_打开文件夹_Buttondef)
                    oButtonDefinitions.Add(m_保存关闭所有部件_Buttondef)

                    oRibbonPanel.CommandControls.AddPopup(m_打开文件夹_Buttondef, oButtonDefinitions, False)
                    '==========================================
                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_设置_Buttondef)
                    oButtonDefinitions.Add(m_保存为列表_Buttondef)
                    oButtonDefinitions.Add(m_保存关闭所有部件_Buttondef)
                    oButtonDefinitions.Add(m_量产iPropertys_Buttondef)
                    oButtonDefinitions.Add(m_工程图批量另存为_Buttondef)
                    'oButtonDefinitions.Add(m_批量打印_Buttondef)
                    oButtonDefinitions.Add(m_还原旧图_Buttondef)
                    oButtonDefinitions.Add(m_清理旧版文件_Buttondef)
                    oButtonDefinitions.Add(m_帮助_Buttondef)
                    oButtonDefinitions.Add(m_关于_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_设置_Buttondef, oButtonDefinitions, False)
                    '==========================================

                    '在标注选项卡中添加
                    oRibbonTab = oRibbon.RibbonTabs.Item("id_TabAnnotate")
                    '在尺寸栏添加
                    oRibbonPanel = oRibbonTab.RibbonPanels.Item("id_PanelD_AnnotateDimension")

                    oRibbonPanel.CommandControls.AddButton(m_添加直径_Buttondef)
                    oRibbonPanel.CommandControls.AddButton(m_尺寸圆整_Buttondef)

                    oRibbonPanel.CommandControls.AddButton(m_尺寸居中_Buttondef)
                    oRibbonPanel.CommandControls.AddButton(m_全部尺寸居中_Buttondef)

                    '在表格栏添加
                    oRibbonPanel = oRibbonTab.RibbonPanels.Item("id_PanelD_AnnotateTable")
                    oRibbonPanel.CommandControls.AddButton(m_设置对称件iProperty_Buttondef)

                    oRibbonPanel.CommandControls.AddButton(m_替换图框标题栏_Buttondef, False)
                    oRibbonPanel.CommandControls.AddButton(m_技术要求_Buttondef, False)

                    oButtonDefinitions.Clear()
                    oButtonDefinitions.Add(m_检查序号完整性_Buttondef)
                    oButtonDefinitions.Add(m_新建序号_Buttondef)
                    oButtonDefinitions.Add(m_自动重建序号_Buttondef)
                    oButtonDefinitions.Add(m_重写BOM序号_Buttondef)
                    oRibbonPanel.CommandControls.AddPopup(m_检查序号完整性_Buttondef, oButtonDefinitions, False)

                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++





                ElseIf oUserInterfaceManager.InterfaceStyle = InterfaceStyleEnum.kClassicInterface Then

                End If
            End If


            'If bfirstTime Then ' Get the part features command bar.
            '    Dim CommandBar As Inventor.CommandBar

            '    ' Add a button to the command bar, defaulting to the end position.
            '    '部件环境
            '    CommandBar = ThisApplication.UserInterfaceManager.CommandBars.Item("AMxAssemblyPanelCmdBar")

            '    CommandBar.Controls.AddButton(m_修改文件iProperty_Buttondef)
            '    ''零件环境
            '    CommandBar = ThisApplication.UserInterfaceManager.CommandBars.Item("PMxPartFeatureCmdBar")
            '    ''工程图环境
            '    CommandBar = ThisApplication.UserInterfaceManager.CommandBars.Item("DLxDrawingAnnotationPanelCmdBar")

            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try
        End Sub

#End Region

#Region "以下按钮事件"
        '------------------------------------------------------
        Private Sub m_修改文件iProperty_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_修改文件iProperty_Buttondef.OnExecute
            SetDocumentIpropertyFromFileName()
        End Sub

        Private Sub m_修改部件iProperty_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_修改部件iProperty_Buttondef.OnExecute
            SetDocumentsInAssIpropertyFromFileName()
        End Sub

        Private Sub m_更改文件名_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_更改文件名_Buttondef.OnExecute
            RenameAssPartDocumentName()
        End Sub

        Private Sub m_提取iPro修改文件名_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_提取iPro修改文件名_Buttondef.OnExecute
            GetIpropertyToRename()

        End Sub

        Private Sub m_自动生成图号_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_自动生成图号_Buttondef.OnExecute
            FrmAutoPartNumberShow()
        End Sub

        Private Sub m_更改镜像文件名_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_更改镜像文件名_Buttondef.OnExecute
            RenameMirrorAssPartDocumentName()
        End Sub

        Private Sub m_打开文件夹_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_打开文件夹_Buttondef.OnExecute
            OpenFolderwithDocument()
        End Sub

        Private Sub m_保存关闭_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_保存关闭_Buttondef.OnExecute
            SaveClose()
        End Sub

        Private Sub m_另存为Pdf_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_另存为Pdf_Buttondef.OnExecute
            IdwSaveAsPdf()
        End Sub

        Private Sub m_另存为Dwg_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_另存为Dwg_Buttondef.OnExecute
            IdwSaveAsDwg()
        End Sub

        Private Sub m_设置BOM结构_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_设置BOM结构_Buttondef.OnExecute
            SetBOMStructuret()
        End Sub

        Private Sub m_设置对称件iProperty_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_设置对称件iProperty_Buttondef.OnExecute
            SetDrawingMirPartIPro()
        End Sub

        Private Sub m_序号完整性_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_检查序号完整性_Buttondef.OnExecute
            CheckSerialNumber()
        End Sub

        Private Sub m_新建序号_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_新建序号_Buttondef.OnExecute
            CreateNewSequenceNumber()
        End Sub

        Private Sub m_设置签字_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_设置签字_Buttondef.OnExecute
            SetUpSigning()
        End Sub

        Private Sub m_清除签字_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_清除签字_Buttondef.OnExecute
            ClearSignature()
        End Sub

        Private Sub m_自定义签字_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_自定义签字_Buttondef.OnExecute
            FrmCustomSignatureShow()
        End Sub

        Private Sub m_设置_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_设置_Buttondef.OnExecute
            FrmOptionshow()
        End Sub

        Private Sub m_量产iPropertys_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_量产iPropertys_Buttondef.OnExecute
            frmMassiPopertiesshow()
        End Sub

        Private Sub m_批量打印_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_批量打印_Buttondef.OnExecute
            FrmBulkPrintShow()
        End Sub

        Private Sub m_工程图批量另存为_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_工程图批量另存为_Buttondef.OnExecute
            FrmAllSaveAsShow()
        End Sub

        Private Sub m_还原旧图_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_还原旧图_Buttondef.OnExecute
            RestoreOldVersion()
        End Sub

        Private Sub m_关于_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_关于_Buttondef.OnExecute
            Dim frmAbout As New frmAbout
            frmAbout.ShowDialog()
        End Sub

        Private Sub m_帮助_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_帮助_Buttondef.OnExecute
            Dim strHelpFullFileName As String
            strHelpFullFileName = IO.Path.Combine(My.Application.Info.DirectoryPath, "帮助.pdf")
            Process.Start(strHelpFullFileName)
        End Sub

        Private Sub m_保存关闭所有部件_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_保存关闭所有部件_Buttondef.OnExecute
            FrmSaveCloseAllDocumentShow()
        End Sub

        Private Sub m_关闭文档_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_关闭文档_Buttondef.OnExecute
            CloseDocument()
        End Sub

        Private Sub m_添加直径_Buttondef_OnExecute() Handles m_添加直径_Buttondef.OnExecute
            AddDiameter()
        End Sub

        Private Sub m_检查是否有工程图_Buttondef_OnExecute() Handles m_检查是否有工程图_Buttondef.OnExecute
            CheckIsInvHaveIdw()
        End Sub

        Private Sub m_打开指定工程图_Buttondef_OnExecute() Handles m_打开指定工程图_Buttondef.OnExecute
            OpenAllDrwInAsm()
        End Sub

        Private Sub m_部件替换文件名_Buttondef_OnExecute() Handles m_部件替换文件名_Buttondef.OnExecute
            ReplaceNameInAsm()
        End Sub

        ' 导出BOM平面性
        Private Sub m_导出平面BOM_Buttondef_OnExecute() Handles m_导出平面BOM_Buttondef.OnExecute
            ExportBOMAsFlat()
        End Sub

        ' 刷新引用名称
        Private Sub m_刷新引用_Buttondef_OnExecute() Handles m_刷新引用_Buttondef.OnExecute
            RefreshTreeShowName()
        End Sub

        Private Sub m_清理旧版文件_Buttondef_OnExecute() Handles m_清理旧版文件_Buttondef.OnExecute
            CleanUpLegacyFiles()
        End Sub

        Private Sub m_移动指定文件_Buttondef_OnExecute() Handles m_移动指定文件_Buttondef.OnExecute
            MovesSpecifiedFile()

        End Sub

        Private Sub m_对齐原始坐标面_Buttondef_OnExecute() Handles m_对齐原始坐标面_Buttondef.OnExecute
            FlushXYZPlane()
        End Sub

        Private Sub m_查找缺失文件的部件_Buttondef_OnExecute() Handles m_查找缺失文件的部件_Buttondef.OnExecute
            GetAsmMissDocument()
        End Sub

        Private Sub m_统计_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_统计_Buttondef.OnExecute
            FrmStatisticalShow()
        End Sub

        Private Sub m_自定义IPro_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_自定义IPro_Buttondef.OnExecute
            FrmChangeIproShow()
        End Sub

        Private Sub m_尺寸圆整_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_尺寸圆整_Buttondef.OnExecute
            DimensionRounding()
        End Sub

        Private Sub m_导入ERP编码_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_导入ERP编码_Buttondef.OnExecute
            FrmImportERPCodeToIamShow()
        End Sub

        Private Sub m_打开工程图_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_打开工程图_Buttondef.OnExecute
            OpenIdwFile()
        End Sub

        'BOM表保存新的替换项和按序号排序
        Private Sub m_重写BOM序号_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_重写BOM序号_Buttondef.OnExecute
            ReWriteBOM()
        End Sub

        Private Sub m_打开ERP数据文件_Buttondef_OnExecute() Handles m_打开ERP数据文件_Buttondef.OnExecute
            OpenBasicExcel()
        End Sub

        Private Sub m_输入查询ERP编码_Buttondef_OnExecute() Handles m_输入查询ERP编码_Buttondef.OnExecute
            FrmSearchERPCodeShow()
        End Sub

        Private Sub m_导入ERP到BOM_Buttondef_OnExecute() Handles m_导入ERP到BOM_Buttondef.OnExecute
            FrmImportERPCodeToExcelshow()
        End Sub

        Private Sub m_快速打开_Buttondef_OnExecute() Handles m_快速打开_Buttondef.OnExecute
            QuitOpen()
        End Sub

        Private Sub m_自动重建序号_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_自动重建序号_Buttondef.OnExecute
            RebuildRingSerialNumber()
        End Sub

        Private Sub m_替换图框标题栏_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_替换图框标题栏_Buttondef.OnExecute
            ReplaceBorderTitleBlock()
        End Sub

        Private Sub m_快速打印_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_快速打印_Buttondef.OnExecute
            QuitPrint()
        End Sub

        Private Sub m_ERP反查_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_ERP反查_Buttondef.OnExecute
            FrmReverseCheckERPCodesShow()
        End Sub

        Private Sub m_设值随机颜色_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_设值随机颜色_Buttondef.OnExecute
            SetRandomColor()
        End Sub

        Private Sub m_清除随机颜色_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_清除随机颜色_Buttondef.OnExecute
            ClearRandomColor()
        End Sub

        Private Sub m_技术要求_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_技术要求_Buttondef.OnExecute
            FrmSpecificationShow()
        End Sub

        Private Sub m_居中对齐_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_居中对齐_Buttondef.OnExecute
            AlignComponentsInTheCenter()
        End Sub

        Private Sub m_全部尺寸居中_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_全部尺寸居中_Buttondef.OnExecute
            CenterAllDimensions()
        End Sub

        Private Sub m_尺寸居中_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_尺寸居中_Buttondef.OnExecute
            CenterDimensions()
        End Sub

        Private Sub m_全部可见_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_全部可见_Buttondef.OnExecute
            OneKeyShowAll()
        End Sub

        Private Sub m_设置只读_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_设置只读_Buttondef.OnExecute
            FrmSetWriteOnlyShow()
        End Sub

        Private Sub m_只读属性_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_只读属性_Buttondef.OnExecute
            SetWriteOnly()
        End Sub

        Private Sub m_标准件可见性_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_标准件可见性_Buttondef.OnExecute
            SetStandIptVisible()
        End Sub

        Private Sub m_替换为库文件_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_替换为库文件_Buttondef.OnExecute
            ReplaceWithContentCenterFile()
        End Sub

        Private Sub m_动态尺寸_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_动态尺寸_Buttondef.OnExecute
            FrmEditDimensionShow()
        End Sub

        Private Sub m_创建展开图_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_创建展开图_Buttondef.OnExecute
            CreateFlatDrawingDocument()
        End Sub

        Private Sub m_查找替换_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_查找替换_Buttondef.OnExecute
            FindAndReplace()
        End Sub

        Private Sub m_替换衍生_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_替换衍生_Buttondef.OnExecute
            ReplaceDerivedPart()
        End Sub

        Private Sub m_创建工程图_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_创建工程图_Buttondef.OnExecute
            CreatNewDrawingDocument()
        End Sub

        Private Sub m_抑制全部错误的约束_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_抑制全部错误的约束_Buttondef.OnExecute
            SuppressAllUnhealthConstraints()
        End Sub

        Private Sub m_驱动测量_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_驱动测量_Buttondef.OnExecute
            FrmDim2ObjectShow()
        End Sub

        Private Sub m_另存工程图_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_另存工程图_Buttondef.OnExecute
            DrawingDocumentSaveAs()
        End Sub

        Private Sub m_创建截屏_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_创建截屏_Buttondef.OnExecute
            CreatJpg()
        End Sub

        Private Sub m_按列表打开文件_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_按列表打开文件_Buttondef.OnExecute
            OpenFilesWithList()
        End Sub

        Private Sub m_切换文档_Buttondef_Buttondef_OnExecute(ByVal Context As Inventor.NameValueMap) Handles m_切换文档_Buttondef.OnExecute
            FrmSwitchLablesShow()
        End Sub

        Private Sub m_另存为Dxf_Buttondef_OnExecute(Context As NameValueMap) Handles m_另存为Dxf_Buttondef.OnExecute
            IdwSaveAsDxf()
        End Sub

        Private Sub m_标记展开图螺纹_Buttondef_OnExecute(Context As NameValueMap) Handles m_标记展开图螺纹_Buttondef.OnExecute
            MarkCircleInFlatDrawing()
        End Sub

        Private Sub m_保存为列表_Buttondef_OnExecute(Context As NameValueMap) Handles m_保存为列表_Buttondef.OnExecute
            SaveFilessList()
        End Sub

        Private Sub m_关闭自适应_Buttondef_OnExecute(Context As NameValueMap) Handles m_关闭自适应_Buttondef.OnExecute
            Turn_Off_Adaptivity()
        End Sub

        Private Sub m_另存为Stp_Buttondef_OnExecute(Context As NameValueMap) Handles m_另存为Stp_Buttondef.OnExecute
            AsmIptSaveAsStp()
        End Sub

#End Region
        '==================================================================================
        ''
        '
        '===============================================

        Public Sub Deactivate() Implements Inventor.ApplicationAddInServer.Deactivate

            ' This method is called by Inventor when the AddIn is unloaded.
            ' The AddIn will be unloaded either manually by the user or
            ' when the Inventor session is terminated.

            ' TODO:  Add ApplicationAddInServer.Deactivate implementation

            ' Release objects.
            Marshal.ReleaseComObject(ThisApplication)
            ThisApplication = Nothing

            System.GC.WaitForPendingFinalizers()
            System.GC.Collect()

        End Sub

        Public ReadOnly Property Automation() As Object Implements Inventor.ApplicationAddInServer.Automation

            ' This property is provided to allow the AddIn to expose an API
            ' of its own to other programs. Typically, this  would be done by
            ' implementing the AddIn's API interface in a class and returning
            ' that class object through this property.

            Get
                Return Nothing
            End Get

        End Property

        Public Sub ExecuteCommand(ByVal commandID As Integer) Implements Inventor.ApplicationAddInServer.ExecuteCommand

            ' Note:this method is now obsolete, you should use the
            ' ControlDefinition functionality for implementing commands.

        End Sub

#End Region

#Region "COM Registration"

        ' Registers this class as an AddIn for Inventor.
        ' This function is called when the assembly is registered for COM.
        <ComRegisterFunctionAttribute()> _
        Public Shared Sub Register(ByVal t As Type)

            Dim clssRoot As RegistryKey = Registry.ClassesRoot
            Dim clsid As RegistryKey = Nothing
            Dim subKey As RegistryKey = Nothing

            Try
                clsid = clssRoot.CreateSubKey("CLSID\" + AddInGuid(t))
                clsid.SetValue(Nothing, "InventorAddIn")
                subKey = clsid.CreateSubKey("Implemented Categories\{39AD2B5C-7A29-11D6-8E0A-0010B541CAA8}")
                subKey.Close()

                subKey = clsid.CreateSubKey("Settings")
                subKey.SetValue("AddInType", "Standard")
                subKey.SetValue("LoadOnStartUp", "1")

                'subKey.SetValue("SupportedSoftwareVersionLessThan", "")
                subKey.SetValue("SupportedSoftwareVersionGreaterThan", "14..")
                'subKey.SetValue("SupportedSoftwareVersionEqualTo", "")
                'subKey.SetValue("SupportedSoftwareVersionNotEqualTo", "")
                'subKey.SetValue("Hidden", "0")
                'subKey.SetValue("UserUnloadable", "1")
                subKey.SetValue("Version", 0)
                subKey.Close()

                subKey = clsid.CreateSubKey("Description")
                subKey.SetValue(Nothing, "InventorAddIn")
            Catch ex As Exception
                System.Diagnostics.Trace.Assert(False)
            Finally
                If Not subKey Is Nothing Then subKey.Close()
                If Not clsid Is Nothing Then clsid.Close()
                If Not clssRoot Is Nothing Then clssRoot.Close()
            End Try

        End Sub

        ' Unregisters this class as an AddIn for Inventor.
        ' This function is called when the assembly is unregistered.
        <ComUnregisterFunctionAttribute()> _
        Public Shared Sub Unregister(ByVal t As Type)

            Dim clssRoot As RegistryKey = Registry.ClassesRoot
            Dim clsid As RegistryKey = Nothing

            Try
                clssRoot = Microsoft.Win32.Registry.ClassesRoot
                clsid = clssRoot.OpenSubKey("CLSID\" + AddInGuid(t), True)
                clsid.SetValue(Nothing, "")
                clsid.DeleteSubKeyTree("Implemented Categories\{39AD2B5C-7A29-11D6-8E0A-0010B541CAA8}")
                clsid.DeleteSubKeyTree("Settings")
                clsid.DeleteSubKeyTree("Description")
            Catch
            Finally
                If Not clsid Is Nothing Then clsid.Close()
                If Not clssRoot Is Nothing Then clssRoot.Close()
            End Try

        End Sub

        ' This property uses reflection to get the value for the GuidAttribute attached to the class.
        Public Shared ReadOnly Property AddInGuid(ByVal t As Type) As String

            Get
                Dim guid As String = ""
                Try
                    Dim customAttributes() As Object = t.GetCustomAttributes(GetType(GuidAttribute), False)
                    Dim guidAttribute As GuidAttribute = CType(customAttributes(0), GuidAttribute)
                    guid = "{" + guidAttribute.Value.ToString() + "}"
                Finally
                    AddInGuid = guid
                End Try
            End Get

        End Property

#End Region

  
    
    End Class

End Namespace