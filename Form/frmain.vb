Imports Inventor
Imports Inventor.SelectionFilterEnum
Imports Inventor.DocumentTypeEnum
Imports System.Windows.Forms
Imports System
Imports System.IO
Imports Microsoft
Imports Microsoft.VisualBasic
Imports System.Collections.ObjectModel



Public Class frmain
    Private HideSide As Short '隐藏边的位置，0为未隐藏，1为上边，2为左边

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

        '初始化图号文件名映射
        Map_StochNum = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapStochNum", "库存编号")
        Map_PartName = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapPartName", "零件代号")
        Map_PartNum = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapPartNum", "成本中心")

        '初始化对称件图号文件名映射
        Map_Mir_StochNum = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapMirStochNum", "对称件图号")
        Map_Mir_PartName = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapMirPartName", "对称件名称")

        '初始化比例映射
        Map_DrawingScale = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapDrawingScale", "比例")

        '初始化打印时间映射
        Map_PrintDay = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapPrintDay", "打印日期")
        IsOpenPrint = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "IsOpenPrint", "-1")
        IsDayAndName = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "IsDayAndName", "-1")

        '工程师
        EngineerName = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "EngineerName", "")

        'BOM导出表头
        BOMTiTle = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "BOMTiTle", "存货编号|空格|零件代号|材料|质量|所属装配代号|数量|总数量|描述")
        If BOMTiTle Is Nothing Then
            BOMTiTle = "库存编号|空格|零件代号|材料|质量|所属装配代号|数量|总数量|描述"
        End If

        '质量精度
        Mass_Accuracy = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "Mass_Accuracy", "2")
        If Mass_Accuracy Is Nothing Then
            Mass_Accuracy = "2"
        End If


        '面积精度
        Area_Accuracy = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "Area_Accuracy", "4")
        If Area_Accuracy Is Nothing Then
            Area_Accuracy = "4"
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
        Try
            If IsInventorOpenDoc() = False Then
                Exit Sub
            End If

            ReSetLabel()

            Dim InventorDoc As Inventor.Document      '当前文件
            'InventorDoc = ThisApplication.ActiveDocument
            InventorDoc = ThisApplication.ActiveEditDocument

            If SetDocumentIpropertyFromFileName(InventorDoc, False) Then
                ToolStripStatusLabel1.Text = "获取编辑中的文件名修改ipropty完成"
                'MsgBox("获取编辑中的文件名修改ipropty完成", MsgBoxStyle.Information)
            Else
                ToolStripStatusLabel1.Text = "错误"
                MsgBox("错误", MsgBoxStyle.Exclamation)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '获取当前部件中的文件名修改ipropty
    Private Sub Button获取部件修改ipropty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button获取部件修改ipropty.Click
        Try
            If IsInventorOpenDoc() = False Then
                Exit Sub
            End If

            ReSetLabel()

            Dim InventorDoc As Inventor.Document     '当前文件
            InventorDoc = ThisApplication.ActiveDocument

            If InventorDoc.DocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件", MsgBoxStyle.Information)
                Exit Sub
            End If

            If SetDocumentsInAssIpropertyFromFileName(InventorDoc, False) Then
                ToolStripStatusLabel1.Text = "获取当前部件中的文件名修改ipropty完成"
                'MsgBox("获取当前部件中的文件名修改ipropty完成", MsgBoxStyle.Information)

            Else
                ToolStripStatusLabel1.Text = "错误"
                MsgBox("错误", MsgBoxStyle.Exclamation)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '更改零件/部件文件名
    Private Sub Button更改零件部件文件名_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button更改零件部件文件名.Click
        Try
            SetStatusBarText()

            If IsInventorOpenDoc() = False Then
                Exit Sub
            End If

            Dim InventorDoc As Inventor.Document
            InventorDoc = ThisApplication.ActiveDocument

            If InventorDoc.DocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件", MsgBoxStyle.Information, "修改文件名")
                Exit Sub
            End If

            Dim OldOcc As ComponentOccurrence   '选择的部件或零件

            If InventorDoc.SelectSet.Count <> 0 Then
                'For Each oSelect As Object In InventorDoc.SelectSet
                OldOcc = InventorDoc.SelectSet(1)
                'Next
            Else
            OldOcc = ThisApplication.CommandManager.Pick(kAssemblyOccurrenceFilter, "选择要更改文件名的零件或部件")
            End If

            If OldOcc Is Nothing Then       '取消选择
                Exit Sub
            End If


            Select Case OldOcc.DefinitionDocumentType
                Case kAssemblyDocumentObject, kPartDocumentObject

                    Dim OldFullFileName As String   '被替换的旧文件全名
                    Dim OldFileName As String   '被替换的旧文件仅文件名
                    OldFullFileName = OldOcc.ReferencedDocumentDescriptor.FullDocumentName
                    OldFileName = GetFileNameInfo(OldFullFileName).ONlyName

                    Dim NewFileName As String   '新文件仅文件名
                    NewFileName = InputBox("重命名 " & OldFullFileName, "重命名", OldFileName)  '输入新文件名

                    If RenameAssPartDocumentName(InventorDoc, OldOcc, NewFileName) Then
                        SetStatusBarText("更改零件/部件文件名完成")
                        'MsgBox("更改零件/部件文件名完成", MsgBoxStyle.Information)

                    Else
                        SetStatusBarText("错误")
                        MsgBox("错误", MsgBoxStyle.Exclamation)

                    End If
                Case Else

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '提取iproperty更改文件名
    Private Sub Button提取iproperty更改文件名_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button提取iproperty更改文件名.Click
        Try
            SetStatusBarText()

            If IsInventorOpenDoc() = False Then
                Exit Sub
            End If

            '判断是否为 assdoc
            Dim InventorDoc As Inventor.Document

            InventorDoc = ThisApplication.ActiveDocument

            If InventorDoc.DocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim OldOcc As ComponentOccurrence   '选择的部件或零件
            OldOcc = ThisApplication.CommandManager.Pick(kAssemblyOccurrenceFilter, "选择要更改文件名的的零件或部件")

            If OldOcc Is Nothing Then       '取消选择
                Exit Sub
            End If

            If GetIpropertyToRename(InventorDoc, OldOcc) Then
                SetStatusBarText("提取iproperty更改文件名完成")
                'MsgBox("提取iproperty更改文件名完成", MsgBoxStyle.Information)

            Else
                SetStatusBarText("错误")
                MsgBox("错误", MsgBoxStyle.Exclamation)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    '自动生成零件号
    Private Sub Button自动生成零件图号_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button自动生成零件图号.Click
        Try
            If IsInventorOpenDoc() = False Then
                Exit Sub
            End If

            IsAutoSetPartName = True

            ReSetLabel()

            Dim InventorDoc As Inventor.Document     '当前文件
            InventorDoc = ThisApplication.ActiveDocument

            If InventorDoc.DocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件", MsgBoxStyle.Information)
                Exit Sub
            End If

            If AutoSetPartNumber(InventorDoc) Then
                ToolStripStatusLabel1.Text = "自动生成零件图号完成"
            Else
                ToolStripStatusLabel1.Text = "错误"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '更改镜像零件/部件文件名
    Private Sub Button更改镜像零件文件名_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button更改镜像零件文件名.Click
        Try
            SetStatusBarText()

            If IsInventorOpenDoc() = False Then
                Exit Sub
            End If

            Dim InventorDoc As Inventor.Document
            InventorDoc = ThisApplication.ActiveDocument

            If InventorDoc.DocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim OldOcc As ComponentOccurrence   '选择的部件或零件

            If InventorDoc.SelectSet.Count <> 0 Then
                'For Each oSelect As Object In InventorDoc.SelectSet
                OldOcc = InventorDoc.SelectSet(1)
                'Next
            Else
                OldOcc = ThisApplication.CommandManager.Pick(kAssemblyOccurrenceFilter, "选择要更改文件名的零件或部件")
            End If

            If OldOcc Is Nothing Then       '取消选择
                Exit Sub
            End If

            Select Case OldOcc.DefinitionDocumentType
                Case kPartDocumentObject, kAssemblyDocumentObject      '选择的是部件或零件
                    Dim OldFullFileName As String   '被替换的旧文件全名
                    Dim OldFileName As String   '被替换的旧文件仅文件名
                    OldFullFileName = OldOcc.ReferencedDocumentDescriptor.FullDocumentName
                    OldFileName = GetFileNameInfo(OldFullFileName).ONlyName

                    Dim NewFileName As String   '新文件仅文件名
                    NewFileName = InputBox("镜像文件重命名 " & OldFullFileName, "镜像文件重命名", OldFileName)  '输入新文件名

                    '取消输入
                    If NewFileName = "" Then
                        Exit Sub
                    End If

                    If RenameMirrorAssPartDocumentName(InventorDoc, OldOcc, NewFileName) Then
                        SetStatusBarText("更改镜像零件/部件文件名完成")
                        'MsgBox("更改零件/部件文件名完成", MsgBoxStyle.Information)

                    Else
                        SetStatusBarText("错误")
                        MsgBox("错误", MsgBoxStyle.Exclamation)

                    End If
                Case MsgBox("选择的文件不是零件或部件", MsgBoxStyle.Information)

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '帮助
    Private Sub 帮助ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 帮助ToolStripMenuItem.Click
        Dim HelpMessage As String = "窗口在左和上边缘自动隐藏      当前版本：" & System.Windows.Forms.Application.ProductVersion

        MsgBox(HelpMessage, MsgBoxStyle.Information)

    End Sub

    '设置窗口
    Private Sub 设置ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 设置ToolStripMenuItem.Click
        OptionDialog.ShowDialog()
    End Sub


    '另存为cad dwg

    Private Sub 另存为DWGToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 另存为DWGToolStripMenuItem.Click
        Try
            SetStatusBarText()

            If IsInventorOpenDoc() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocument.DocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim IdwDoc As DrawingDocument
            IdwDoc = ThisApplication.ActiveDocument

            Dim DwgFullFileName As String

            DwgFullFileName = SaveAsDwg(IdwDoc)

            Select Case DwgFullFileName
                Case "非工程图"
                    SetStatusBarText("该文件非工程图。")
                    Exit Sub
                Case "取消"
                    SetStatusBarText("取消。")
                    Exit Sub
            End Select


            If IsFileExsts(DwgFullFileName) Then
                SetStatusBarText("另存为CAD-DWG完成")
                If MsgBox("是否打开文件： " & DwgFullFileName, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    System.Diagnostics.Process.Start(DwgFullFileName)
                End If
            Else
                SetStatusBarText("错误")
                MsgBox("错误", MsgBoxStyle.Exclamation)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '另存为pdf
    Private Sub 另存为PDFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 另存为PDFToolStripMenuItem.Click
        Try
            SetStatusBarText()

            If IsInventorOpenDoc() = False Then
                Exit Sub
            End If

            Dim InventorDoc As Document
            InventorDoc = ThisApplication.ActiveDocument
            Dim PdfFullFileName As String

            PdfFullFileName = SaveAsPdf(InventorDoc)

            If PdfFullFileName = "取消" Then
                SetStatusBarText("另存为PDF完成")
                Exit Sub
            End If

            If IsFileExsts(PdfFullFileName) Then
                SetStatusBarText("另存为PDF完成")
                If MsgBox("是否打开文件： " & PdfFullFileName, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    System.Diagnostics.Process.Start(PdfFullFileName)
                End If
            Else
                SetStatusBarText("错误")
                MsgBox("错误", MsgBoxStyle.Exclamation)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '设置工程图比例
    Private Sub 比例ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 比例ToolStripMenuItem.Click
        Try
            If IsInventorOpenDoc() = False Then
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
        Try
            SetStatusBarText()

            If IsInventorOpenDoc() = False Then
                Exit Sub
            End If

            Dim IdwDoc As DrawingDocument
            IdwDoc = ThisApplication.ActiveDocument

            If SetDrawingMirPartIPro(IdwDoc) Then
                SetStatusBarText("设置工程图自定义属性：对称件IPro")
                'MsgBox("设置工程图自定义属性：对称件IPro", MsgBoxStyle.Information)
            Else
                SetStatusBarText("错误")
                MsgBox("错误", MsgBoxStyle.Exclamation)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

   
    '设置自定义属性，签字
    Private Sub 签字ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 签字ToolStripMenuItem1.Click
        Try
            SetStatusBarText()

            If IsInventorOpenDoc() = False Then
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
    Private Sub 清除签字ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 清除签字ToolStripMenuItem.Click
        Try
            SetStatusBarText()

            If IsInventorOpenDoc() = False Then
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
    Private Sub 自定义签字ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 自定义签字ToolStripMenuItem.Click
        Dim SignDialog As SignDialog
        SignDialog = New SignDialog
        SignDialog.ShowDialog()
    End Sub

    '保存文件并关闭
    Private Sub 保存关闭ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 保存关闭ToolStripMenuItem.Click
        Try
            If IsInventorOpenDoc() = False Then
                Exit Sub
            End If

            With ThisApplication.ActiveDocument
                .Save2(True)
                .Close()
            End With


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '打开自定义属性窗口
    Private Sub 自定义属性ToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 自定义属性ToolStripMenuItem.Click
        iPopertiesDialog.ShowDialog()
    End Sub

    '退出程序
    Private Sub 退出ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 退出ToolStripMenuItem.Click
        Me.Dispose()
    End Sub

    '新建序号
    Private Sub 新建序号ToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 新建序号ToolStripMenuItem.Click
        Try
            SetStatusBarText()

            If IsInventorOpenDoc() = False Then
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
    Private Sub 检查序号完整性ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 检查序号完整性ToolStripMenuItem.Click
        Try
            SetStatusBarText()

            If IsInventorOpenDoc() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocument.DocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim IdwDoc As DrawingDocument
            IdwDoc = ThisApplication.ActiveDocument

            If CheckSerialNumber(IdwDoc) Then
                SetStatusBarText("检查序号完整性完成")
                MsgBox("检查序号完整性完成", MsgBoxStyle.Information)
            Else
                'SetStatusBarText("错误")
                'MsgBox("错误", MsgBoxStyle.Exclamation)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    ' 导出BOM平面性
    Private Sub 导出BOM平面性ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 导出BOM平面性ToolStripMenuItem.Click

        'Try
        If IsInventorOpenDoc() = False Then
            Exit Sub
        End If

        Dim AsmDoc As AssemblyDocument

        AsmDoc = ThisApplication.ActiveDocument

        If AsmDoc.DocumentType <> kAssemblyDocumentObject Then
            MsgBox("该功能仅适用于部件")
            Exit Sub
        End If

        ReSetLabel()

        Dim ExcelFullFileName As String

        ExcelFullFileName = My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & GetFileNameInfo(AsmDoc.FullFileName).ONlyName & "导出BOM.csv"

        If IsFileExsts(ExcelFullFileName) = True Then
            DelFile(ExcelFullFileName, FileIO.RecycleOption.SendToRecycleBin)
        End If

        If ExportBOMAsFlat(AsmDoc, ExcelFullFileName) Then
            ToolStripStatusLabel1.Text = " 导出BOM平面性完成"
            'MsgBox("设置工程图自定义属性：比例完成", MsgBoxStyle.Information)

        Else
            ToolStripStatusLabel1.Text = "错误"
            'MsgBox("错误", MsgBoxStyle.Exclamation)

        End If
        Process.Start(ExcelFullFileName)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    ' 打开文件所在文件夹
    Private Sub 打开文件所在文件夹ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 打开文件所在文件夹ToolStripMenuItem.Click
        Try
            If IsInventorOpenDoc() = False Then
                Exit Sub
            End If

            Dim IdwDoc As Inventor.Document
            Dim DocFileNameInfo As FileNameInfo
            IdwDoc = ThisApplication.ActiveDocument

            DocFileNameInfo = GetFileNameInfo(IdwDoc.FullDocumentName)

            Process.Start(DocFileNameInfo.Folder)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub 批量另存ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 批量另存ToolStripMenuItem.Click
        SaveAsDialog.ShowDialog()
    End Sub

    Private Sub 设置BOM结构ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 设置BOM结构ToolStripMenuItem.Click
        Try
            SetStatusBarText()

            If IsInventorOpenDoc() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocument.DocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim AsmDoc As AssemblyDocument
            AsmDoc = ThisApplication.ActiveDocument

            If SetBOMStructuret(AsmDoc) Then
                SetStatusBarText(" 设置BOM结构完成")
                'MsgBox("设置工程图自定义属性：比例完成", MsgBoxStyle.Information)
            Else
                SetStatusBarText("错误")
                'MsgBox("错误", MsgBoxStyle.Exclamation)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    '测试
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
     
        Try



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    '保存文件缩略图
    Private Sub SaveThumbnail()

        Dim invPartDoc As Document = ThisApplication.ActiveDocument
        Dim ifilename As String = invPartDoc.FullDocumentName


        Dim apprentice As New ApprenticeServerComponent
        Dim doc As ApprenticeServerDocument
        doc = apprentice.Open(ifilename)
        Dim thumbnail As stdole.IPictureDisp
        thumbnail = doc.Thumbnail
        'Dim img As Image = Microsoft.VisualBasic.Compatibility.VB6.IPictureDispToImage(thumbnail)
        'PictureBox1.Image = img



    End Sub


    '获取未读取的文件所在部件并打开该部件
    Private Sub GetUnkonwDocument()
        Try
            If IsInventorOpenDoc() = False Then
                Exit Sub
            End If

            ReSetLabel()

            Dim InventorDoc As Inventor.Document     '当前文件
            InventorDoc = ThisApplication.ActiveDocument

            If InventorDoc.DocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件", MsgBoxStyle.Information)
                Exit Sub
            End If

            If GetUnkonwDocumentWithBOM(InventorDoc, False) Then
                ToolStripStatusLabel1.Text = "获取当前部件中的文件名修改ipropty完成"
                'MsgBox("获取当前部件中的文件名修改ipropty完成", MsgBoxStyle.Information)

            Else
                ToolStripStatusLabel1.Text = "错误"
                MsgBox("错误", MsgBoxStyle.Exclamation)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


End Class
