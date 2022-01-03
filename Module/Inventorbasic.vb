Imports Inventor
Imports Inventor.AssetTypeEnum
Imports Inventor.BOMStructureEnum
Imports Inventor.DocumentTypeEnum
Imports Inventor.DrawingViewTypeEnum
Imports Inventor.IOMechanismEnum
Imports Inventor.PrintOrientationEnum
Imports Inventor.PropertyTypeEnum
Imports Inventor.SelectionFilterEnum
Imports Microsoft
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel.XlCellType
Imports Microsoft.Office.Interop.Excel.XlFileFormat
Imports Microsoft.VisualBasic
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Module InventorBasic

    Public Structure StockNumPartName
        Dim IsGet As Boolean
        Dim StockNum As String    '
        Dim PartName As String      '
        Dim ERPCode As String       '
    End Structure

    Public Structure BalloonDate
        Dim Balloon As Balloon
        Dim Position As Point2d
    End Structure

    Public ThisApplication As Inventor.Application

    'Public ThisApprenticeApp As Inventor.ApprenticeServerComponent   '学徒服务器

    Public WithEvents ThisApplicationEvents As ApplicationEvents

    Public ClientID As String

    Public DWG As String = ".dwg"
    Public IAM As String = ".iam"
    Public IPT As String = ".ipt"
    Public IDW As String = ".idw"
    Public OLD As String = ".old"
    Public PDF As String = ".pdf"
    Public STP As String = ".stp"

    Public ContentCenterFiles As String  '零件库文件夹

    Public DisplayVersion As String

    Public IsAutoSetPartName As Boolean  'true 为进行中，false则退出进程

    Public Map_DrawingNnumber As String   '映射图号
    Public Map_PartName As String   '映射文件名
    Public Map_ERPCode As String    '映射存货编码
    Public Map_Describe As String = "描述"     '映射描述

    Public Map_Mir_StochNum As String   '映射对称件图号
    Public Map_Mir_PartName As String   '映射对称件文件名

    Public Map_DrawingScale As String '映射比例
    Public Map_Mass As String '映射质量

    Public Map_PrintDay As String '映射打印时间
    Public IsOpenPrint As String    '设置打印时间后是否进入打印预览
    Public IsDayAndName As String   '同时签字

    Public EngineerName As String '工程师

    Public Map_Vendor As String '供应商

    Public BOMTiTle As String       '导出BOM用的项目

    Public Mass_Accuracy As String '质量精度
    Public Area_Accuracy As String  '面积精度

    Public IsSetDrawingScale As String    '打开工程图时是否写 比例 到ipro   是赋值为1
    Public IsSetMass As String   '打开工程图时是否写 质量 到ipro  是赋值为1

    Public CheckUpdate As String    '启动检查更新

    Public TotalItem As Integer 'BOM序号

    Public OPosition(9) As Point   '点
    Public TempPoint(9) As SketchPoint   '临时绘制的点

    Public IsShowUpdateMsg As Boolean    '检查更新时是否显示是最新版本的msgbox

    '默认打印设值
    Public Printer As String   '默认打印机

    Public IsPaperA3 As Integer   '1：匹配A3纸，0：按原图纸大小打印
    Public IsSign As Integer       '1：签字，0：不签字
    Public SaveAsDawAndPdf As String

    '标题栏模板
    Public TitleBlockIdwDoc As String

    '声明并初始化变量
    Public _ListViewSorter As clsListViewSorter.EnumSortOrder = clsListViewSorter.EnumSortOrder.Ascending


    '-------------------------------------------------------------------------------------------------------

    '保存文件时的事件
    'Public Sub ThisApplicationEvents_OnOnSaveDocument(ByVal DocumentObject As Inventor._Document, _
    '                                                ByVal BeforeOrAfter As Inventor.EventTimingEnum, _
    '                                                 ByVal Context As Inventor.NameValueMap, _
    '                                                 ByRef HandlingCode As Inventor.HandlingCodeEnum) Handles ThisApplicationEvents.OnSaveDocument

    'End Sub

    '打开文件时的事件
    Public Sub ThisApplicationEvents_OnOpenDocument(ByVal oInventorDocument As Inventor.Document, _
                                    ByVal FullDocumentName As String, _
                                   ByVal BeforeOrAfter As Inventor.EventTimingEnum, _
                                  ByVal Context As Inventor.NameValueMap, _
                                  ByRef HandlingCode As Inventor.HandlingCodeEnum) Handles ThisApplicationEvents.OnOpenDocument


        '视图全部缩放，这个功能有问题，取消
        'ThisApplication.CommandManager.ControlDefinitions.Item("AppZoomAllCmd").Execute()


        '当打开文件为工程图()
        If oInventorDocument.DocumentType = kDrawingDocumentObject Then
            '写入主视图比例
            'If IsSetDrawingScale = 1 Then
            SetDrawingScale(oInventorDocument)
            'End If

            '写入零部件质量
            'If IsSetMass = 1 Then
            SetMass(oInventorDocument)
            'End If
        End If

      



    End Sub

    '激活一个文档时的事件
    Public Sub ThisApplicationEvents_OnActivateDocument(ByVal oInventorDocument As Inventor.Document, _
                                                        ByVal BeforeOrAfter As Inventor.EventTimingEnum, _
                                                        ByVal Context As Inventor.NameValueMap, _
                                                        ByRef HandlingCode As Inventor.HandlingCodeEnum) Handles ThisApplicationEvents.OnActivateDocument

        '在标题栏中显示当前文档路径()
        ThisApplication.Caption = GetFileNameInfo(oInventorDocument.FullDocumentName).Folder & "\"


        '获取文件只读属性
        Dim oDef1 As ButtonDefinition
        oDef1 = ThisApplication.CommandManager.ControlDefinitions.Item("InName文件只读")

        oDef1.Pressed = GetFileReadOnly(oInventorDocument.FullDocumentName)
    End Sub









    '-------------------------------------------------------------------------------
    Public Sub SetStatusBarText(Optional ByVal StatusBarText As String = "就绪")
        ThisApplication.StatusBarText = StatusBarText
    End Sub

    'inventor是否打开文件,未打开文件返回false
    Public Function IsInventorOpenDocument() As Boolean
        Try
            If ThisApplication.FileManager.Files.Count = 0 Then
                MsgBox("未打开文件", MsgBoxStyle.Critical)
                Return False
                Exit Function
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    '快速打开
    Public Sub QuitOpen()
        Try
            SetStatusBarText()

            Dim WorkSpaceFloder As String
            WorkSpaceFloder = ThisApplication.FileLocations.Workspace & "\"

            Dim strFileName As String
            strFileName = InputBox("查询文件夹：" & WorkSpaceFloder & vbCrLf & vbCrLf & "输入文件名", "快速打开")

            If strFileName = "" Then
                Exit Sub
            End If

            strFileName = "*" & strFileName & "*.*"

            Dim arrFullFileName As String()
            arrFullFileName = Directory.GetFiles(WorkSpaceFloder, strFileName, SearchOption.AllDirectories)

            If arrFullFileName.Length = 0 Then
                MsgBox("未找到文件：" & strFileName, MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim strFullFileName As String = Nothing

            Dim frmQuitOpen As New frmQuitOpen

            For Each strFullFileName In arrFullFileName
                If InStr(strFullFileName, "OldVersions") = 0 Then
                    frmQuitOpen.lvw文件列表.Items.Add(strFullFileName)
                End If
            Next

            Select Case frmQuitOpen.lvw文件列表.Items.Count
                Case 0

                Case 1
                    Dim strFileExtensionName As String = Nothing
                    strFileExtensionName = LCase(GetFileNameInfo(strFullFileName).ExtensionName)

                    Select Case strFileExtensionName
                        Case IAM, IPT, IDW
                            ThisApplication.Documents.Open(strFullFileName)
                        Case Else
                            Process.Start(strFullFileName)
                    End Select
                    frmQuitOpen.Close()
                Case Else
                    frmQuitOpen.ShowDialog()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '保存文件并关闭
    Public Sub SaveClose()
        Try
            If IsInventorOpenDocument() = False Then
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

    '关闭文档
    Public Sub CloseDocument()

        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            Dim oInventorDocument As Inventor.Document
            oInventorDocument = ThisApplication.ActiveDocument
            oInventorDocument.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ' 打开文件所在文件夹
    Public Sub OpenFolderwithDocument()
        Try
            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            Dim oInventorDocument As Inventor.Document
            oInventorDocument = ThisApplication.ActiveDocument

            Dim DocFileNameInfo As FileNameInfo
            DocFileNameInfo = GetFileNameInfo(oInventorDocument.FullDocumentName)

            Process.Start(DocFileNameInfo.Folder)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '还原旧图
    Public Sub RestoreOldVersion()

        '打开文件
        Dim oOpenFileDialog As New OpenFileDialog '声名新open 窗口

        With oOpenFileDialog
            .Title = "打开"
            .Filter = "AutoDesk Inventor 旧文件(*.old)|*.old" '添加过滤文件
            .Multiselect = True '多开文件打开
            If .ShowDialog = System.Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                If .FileName <> "" Then '如果有选中文件
                    Dim strNewFullFileName As String
                    For Each strOldFullFileName As String In .FileNames
                        strNewFullFileName = Left(strOldFullFileName, Strings.Len(strOldFullFileName) - 4)
                        Rename(strOldFullFileName, strNewFullFileName)
                    Next
                End If
                MsgBox("更改旧文件名完成。")
            End If
        End With

    End Sub

    '清理旧版文件
    Public Sub CleanUpLegacyFiles()
        Try

            Dim strDestinationDirectory As String = Nothing
            Dim oFileAttributes As FileAttributes
            Dim strPresent_Folder As String = Nothing

            Dim oFolderBrowserDialog As New FolderBrowserDialog

            With oFolderBrowserDialog
                .ShowNewFolderButton = False
                .Description = "选择文件夹"
                .RootFolder = System.Environment.SpecialFolder.Desktop
                If .ShowDialog = DialogResult.OK Then
                    strDestinationDirectory = .SelectedPath
                Else
                    Exit Sub
                End If
            End With

            'If DestinationDirectory = "" Then
            '    Exit Sub
            'End If

            Dim intDeleteRecycleOption As Integer
            Select Case MsgBox("是否永久删除旧文件，而不是移动到回收站？", MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question + MsgBoxStyle.YesNo, "删除文件")
                Case MsgBoxResult.Yes
                    intDeleteRecycleOption = FileIO.RecycleOption.DeletePermanently
                Case MsgBoxResult.No
                    intDeleteRecycleOption = FileIO.RecycleOption.SendToRecycleBin
            End Select

            '是否为文件夹，在其后添加 \
            oFileAttributes = Microsoft.VisualBasic.FileSystem.GetAttr(strDestinationDirectory)

            If oFileAttributes = FileAttributes.Directory Then
                strDestinationDirectory = strDestinationDirectory + "\"
            End If

            DelOldDirectory(strDestinationDirectory, intDeleteRecycleOption)

            SetStatusBarText("就绪")
            MsgBox("清理旧版本文件完成！", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '获取编辑中的文件名修改ipropty
    Public Sub SetDocumentIpropertyFromFileName()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then   '没有打开文件，退出
                Exit Sub
            End If

            Dim oInventorDocument As Inventor.Document      '当前文件
            oInventorDocument = ThisApplication.ActiveEditDocument

            If SetDocumentIpropertyFromFileNameSub(oInventorDocument, False) = True Then
                SetStatusBarText("获取编辑中的文件名修改iProperty完成")
                'MsgBox("获取编辑中的文件名修改iProperty完成", MsgBoxStyle.Information)
            Else
                SetStatusBarText("错误")
                MsgBox("错误。", MsgBoxStyle.Exclamation)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '根据文件名提取到iproperty  （  文件对象 ； 打开的文件用后要关闭）
    Public Function SetDocumentIpropertyFromFileNameSub(ByVal oInventorDocument As Inventor.Document, ByVal IsNeedClose As Boolean) As Boolean
        Dim strFullFileName As String      '当前文件全名
        Dim strFileName As String

        strFullFileName = oInventorDocument.FullFileName
        strFileName = GetFileNameInfo(strFullFileName).OnlyName

        If InStr(strFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
            MsgBox("无法修改资源中心文件： " & strFullFileName, MsgBoxStyle.Information)
            Return True
            Exit Function
        End If

        Dim oStockNumPartName As StockNumPartName
        oStockNumPartName = GetStockNumPartName(strFullFileName)

        Dim oPropertySets As PropertySets
        Dim oPropertySet As PropertySet
        Dim propitem As [Property]
        oPropertySets = oInventorDocument.PropertySets
        oPropertySet = oPropertySets.Item(3)

        For Each propitem In oPropertySet    '设置iproperty
            Select Case propitem.DisplayName
                Case Map_PartName
                    If oStockNumPartName.PartName <> "" Then
                        propitem.Value = oStockNumPartName.PartName
                    End If
                Case Map_DrawingNnumber
                    If oStockNumPartName.StockNum <> "" Then
                        propitem.Value = oStockNumPartName.StockNum
                    End If
                Case Map_ERPCode
                    If oStockNumPartName.ERPCode <> "" Then
                        propitem.Value = oStockNumPartName.ERPCode
                    End If
                Case "描述"
                    ' propitem.Value = ""
            End Select
        Next
999:
        '是否为打开的文件，是的话就关闭
        If IsNeedClose = True Then
            oInventorDocument.Close(True)
        End If
        Return True
    End Function

    '获取当前部件中的文件名修改ipropty
    Public Sub SetDocumentsInAssIpropertyFromFileName()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
            oInventorAssemblyDocument = ThisApplication.ActiveDocument

            If SetDocumentsInAssIpropertyFromFileNameSub(oInventorAssemblyDocument, False) = True Then
                SetStatusBarText("获取当前部件中的子集文件名修改iProperty完成")
                MsgBox("获取当前部件中的文件名修改iProperty完成。", MsgBoxStyle.Information)
            Else
                SetStatusBarText("错误")
                'MsgBox("错误", MsgBoxStyle.Exclamation)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '修改部件包含文件的iProperty   （ 部件文件对象 ； 文件是否需打开，打开的文件用后要关闭）
    Public Function SetDocumentsInAssIpropertyFromFileNameSub(ByVal oInventorAssemblyDocument As Inventor.AssemblyDocument, ByVal IsNeedClose As Boolean) As Boolean
        ' 获取所有引用文档

        Dim FirstLevelOnly As Boolean

        Select Case MsgBox("修改模式：" & vbCrLf & "是-仅修改第一级零件 " & vbCrLf & "否-修改所有级别零件 ", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel)
            Case MsgBoxResult.Yes
                'RefDocs = AsmDoc.ReferencedDocuments
                FirstLevelOnly = True
            Case MsgBoxResult.No
                'RefDocs = AsmDoc.AllReferencedDocuments
                FirstLevelOnly = False
            Case Else
                Return False
        End Select

        Dim oInteraction As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        oInteraction.Start()
        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        'System.Threading.Thread.Sleep(5000)
        'oInteraction.Stop()

        '==============================================================================================
        '基于bom结构化数据，可跳过参考的文件
        ' Set a reference to the BOM
        Dim oBOM As BOM
        oBOM = oInventorAssemblyDocument.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True
        oBOM.StructuredViewFirstLevelOnly = False

        'Set a reference to the "Structured" BOMView
        Dim oBOMView As BOMView

        '获取结构化的bom页面
        For Each oBOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                '遍历这个bom页面

                SetDocumentsInAssIpropertyFromFileNameChildSub(oBOMView.BOMRows, FirstLevelOnly)
            End If
        Next
        '==============================================================================================
        oInteraction.Stop()
        Return True
    End Function

    '遍历BOM结构，查询row文件修改ipro
    Public Sub SetDocumentsInAssIpropertyFromFileNameChildSub(ByVal oBOMRows As BOMRowsEnumerator, ByVal FirstLevelOnly As Boolean)
        Dim i As Integer

        Dim intStepCount As Integer
        intStepCount = oBOMRows.Count

        'Create a new ProgressBar object.
        'Dim oProgressBar As Inventor.ProgressBar

        'oProgressBar = ThisApplication.CreateProgressBar(False, intStepCount, "当前文件： ")

        For i = 1 To oBOMRows.Count
            ' Get the current row.
            Dim oBOMRow As BOMRow
            oBOMRow = oBOMRows.Item(i)

            Dim strFullFileName As String

            strFullFileName = oBOMRow.ReferencedFileDescriptor.FullFileName

            '测试文件
            Debug.Print(strFullFileName)

            ' Set the message for the progress bar
            'oProgressBar.Message = strFullFileName

            SetStatusBarText(strFullFileName)

            If IsFileExsts(strFullFileName) = False Then   '跳过不存在的文件
                GoTo 999
            End If

            If InStr(strFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                GoTo 999
            End If

            Select Case Strings.Left(GetFileNameInfo(strFullFileName).OnlyName, 2)    '跳过标准件
                Case "GB", "JB"
                    GoTo 999
            End Select

            Dim oInventorDocument As Inventor.Document
            oInventorDocument = ThisApplication.Documents.Open(strFullFileName, False)  '打开文件，不显示

            SetDocumentIpropertyFromFileNameSub(oInventorDocument, True) '设置Iproperty,打开文件后需关闭

            '遍历下一级
            If (Not oBOMRow.ChildRows Is Nothing) And FirstLevelOnly = False Then
                Call SetDocumentsInAssIpropertyFromFileNameChildSub(oBOMRow.ChildRows, FirstLevelOnly)
            End If

999:
            'oProgressBar.UpdateProgress()
        Next

        'oProgressBar.Close()

    End Sub

    '自动生成零件图号（部件文件对象；进度条）
    Public Function AutoSetPartNumber(ByVal oAssemblyDocument As AssemblyDocument) As Boolean
        'With ProgressBar
        '    .Minimum = 0
        '    '.Maximum = AsmDoc.ReferencedDocuments.Count
        '    .Value = 0
        'End With
        Dim strFullFileName As String      '当前部件全名
        Dim strFileName As String      '当前部件名
        Dim strBasicNumber As String   '当前部件图号

        '部件全文件名 和 仅文件名
        strFullFileName = oAssemblyDocument.FullFileName
        strFileName = GetFileNameInfo(strFullFileName).OnlyName

        'Dim i As Integer
        'Dim s As String

        ''获取汉字的位置
        'i = 1
        'Do
        '    s = Mid(FileName, i, 1)
        '    i = i + 1
        '    If s = "" Then
        '        Exit Do
        '    End If
        'Loop Until (CheckCharType(s) = "Unicode字符")

        ''判断图号情况
        'Select Case True       '第一个字符为汉字
        '    Case i = 2
        '        BasicNumber = InputBox("部件 " & FullFileName & "  无图号，输入图号", "输入图号", "")
        '        If BasicNumber.ToString = "" Then
        '            Return False
        '            Exit Function
        '        End If
        '    Case s = ""  '无汉字
        '        BasicNumber = GetFileNameInfo(FullFileName).ONlyName
        '    Case Else       '正常情况
        '        BasicNumber = Left(FileName, i - 2)
        'End Select

        Dim oStockNumPartName As StockNumPartName
        '获取图号和零件名
        oStockNumPartName = GetStockNumPartName(strFullFileName)
        '未获取图号，退出
        If oStockNumPartName.IsGet = False Then
            Return False
        End If
        '基本图号
        strBasicNumber = oStockNumPartName.StockNum

        Dim intPartNumberStep As Integer   '零件图号变化步长
        Dim intAssNumberStep As Integer    '部件图号变化步长

        If Integer.TryParse(InputBox("输入部件文件的编号变化，部件XXX-0000000 下第一个部件为XXX-0000100 则 输入 100 "), intAssNumberStep) Then
        Else
            MsgBox("输入字符串不是一个整数！", MsgBoxStyle.Question)
            Return False
        End If

        If Integer.TryParse(InputBox("输入零件文件的编号变化，部件XXX-0000000 下第一个零件为XXX-0000001 则 输入 1  "), intPartNumberStep) Then
        Else
            MsgBox("输入字符串不是一个整数！", MsgBoxStyle.Question)
            Return False
        End If

        'intAssNumberStep = Convert.ToInt16(InputBox("输入部件文件的编号变化，部件XXX-0000000 下第一个部件为XXX-0000100 则 输入 100 "))
        'If intAssNumberStep = 0 Then
        '    Return False
        '    Exit Function
        'End If

        'intPartNumberStep = Convert.ToInt16(InputBox("输入零件文件的编号变化，部件XXX-0000000 下第一个零件为XXX-0000001 则 输入 1 "))
        'If intPartNumberStep = 0 Then
        '    Return False
        '    Exit Function
        'End If

        '重命名还是续命名
        Dim PartNumberItem As Integer     '第几个零件文件
        Dim AssNumberItem As Integer   '第几个部件文件

        If MsgBox("是否续编部件文件名？", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            'Dim BasicOcc As ComponentOccurrence   '选择续编的的部件或零件
            'Dim BasicFullFileName As String   '续编的文档全名
            'Dim BasicFileName As String       '续编的文件名
            'BasicOcc =   ThisApplication.CommandManager.Pick(kAssemblyOccurrenceFilter, "选择续编的部件文件")
            'BasicFullFileName = BasicOcc.ReferencedDocumentDescriptor.FullDocumentName
            'BasicFileName = GetStockNumPartName(BasicFullFileName).StockNum
            'AssNumberItem = (Val(BasicFileName) - Val(BasicNumber)) / AssNumberStep
            AssNumberItem = Val(InputBox("输入续编部件文件的文件名，部件XXX-0000200 则 输入 200 ", "续编部件", "")) / intAssNumberStep
        Else
            '重0开始命名，不续编
            AssNumberItem = 0
        End If

        If MsgBox("是否续编零件文件名？", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            'Dim BasicOcc As ComponentOccurrence   '选择续编的的部件或零件
            'Dim BasicFullFileName As String   '续编的文档全名
            'Dim BasicFileName As String       '续编的文件名
            'BasicOcc =   ThisApplication.CommandManager.Pick(kAssemblyOccurrenceFilter, "选择续编的零件文件")
            'BasicFullFileName = BasicOcc.ReferencedDocumentDescriptor.FullDocumentName
            'BasicFileName = GetStockNumPartName(BasicFullFileName).StockNum
            'Dim a As Double = GetNumbers(BasicFileName)
            'Dim b As Double = GetNumbers(BasicNumber)
            'PartNumberItem = (a - b) / PartNumberStep
            PartNumberItem = Val(InputBox("输入续编零件文件的文件名，零件XXX-0000105 则 输入 5 ", "续编零件", "")) / intPartNumberStep
        Else
            '重0开始命名，不续编
            PartNumberItem = 0
        End If

        Dim oOldComponentOccurrence As ComponentOccurrence   '选择的部件或零件

        Dim oOldInventorDocument As Document   '旧的文档
        Dim strOldFullFileName As String   '旧的文档全名
        Dim strOldFileName As String       '旧的文件名
        Dim oOldFileNameInfo As FileNameInfo

        Dim oNewInventorDocument As Document
        Dim strNewFullFileName As String       '新的文档全名
        Dim strNewFileName As String           '新的文档名
        Dim strNewStockNum As String = Nothing      '新的图号

        ' 获取所有引用文档
        Dim oDocumentsEnumerator As DocumentsEnumerator
        oDocumentsEnumerator = oAssemblyDocument.ReferencedDocuments

        ' 遍历这些文档
        Do
            oOldComponentOccurrence = ThisApplication.CommandManager.Pick(kAssemblyOccurrenceFilter, "选择要编号的文件，ESC键取消")

            If oOldComponentOccurrence Is Nothing Then       '取消选择
                Exit Do
            End If

            strOldFullFileName = oOldComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName      '旧文件全文件名
            oOldFileNameInfo = GetFileNameInfo(strOldFullFileName)
            strOldFileName = oOldFileNameInfo.OnlyName     '旧文件 仅文件名

            If IsFileExsts(strOldFullFileName) = False Then   '跳过不存在的文件
                MsgBox(strOldFullFileName & "不存在", MsgBoxStyle.Critical)
                GoTo 999
            End If

            If InStr(strOldFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                MsgBox(strOldFullFileName & "为零件库文件", MsgBoxStyle.Information)
                'OldInventorDoc.Close()
                GoTo 999
            End If

            '如果旧文件目录下有一个文件名相同的已有零件号的文件，是否替换或者重新命名当前文件
            For Each FoundFile As String In My.Computer.FileSystem.GetFiles(oOldFileNameInfo.Folder, FileIO.SearchOption.SearchTopLevelOnly) ' OldFileInfo.ExtensionName)
                If InStr(GetFileNameInfo(FoundFile).SigleName, oOldFileNameInfo.SigleName) > 1 Then  '存在一个已命名图号的文件
                    Select Case MsgBox("存在一个已命名图号的文件：" & FoundFile & " ，是-直接替换  否-重新生成替换 ", MsgBoxStyle.Information + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1)
                        Case MsgBoxResult.Yes   '替换文件
                            oOldComponentOccurrence.Replace(FoundFile, True)
                            GoTo 999
                        Case MsgBoxResult.No    '重新命名

                    End Select
                    Exit For
                End If
            Next

            If IsAutoSetPartName = False Then
                Exit Do
            End If

            If CheckCharType(Strings.Left(strOldFileName, 1)) = "Unicode字符" Then  '第一个为中文就编号
                Select Case oOldComponentOccurrence.ReferencedDocumentDescriptor.ReferencedDocumentType      '零件和部件分别计数
                    Case kPartDocumentObject     '零件
                        PartNumberItem = PartNumberItem + 1     '第几个文件
                        strNewStockNum = Strings.Left(strBasicNumber, (Strings.Len(strBasicNumber)) - Len((intPartNumberStep * PartNumberItem).ToString))   '获取不改变的前部分图号
                        strNewStockNum = strNewStockNum & (intPartNumberStep * PartNumberItem).ToString    '获取全图号

                    Case kAssemblyDocumentObject    '部件
                        AssNumberItem = AssNumberItem + 1
                        strNewStockNum = Strings.Left(strBasicNumber, (Strings.Len(strBasicNumber)) - Len((intAssNumberStep * AssNumberItem).ToString))
                        strNewStockNum = strNewStockNum & (intAssNumberStep * AssNumberItem).ToString
                    Case Else

                End Select

                strNewFileName = strNewStockNum & strOldFileName     '获取全文件名
                strNewFullFileName = GetNewFileName(strOldFullFileName, strNewFileName)  '替换旧文件全名为新文件全名

                '后台打开旧文件，另存为新文件
                oOldInventorDocument = ThisApplication.Documents.Open(strOldFullFileName, False)
                oOldInventorDocument.SaveAs(strNewFullFileName, True)  '另存为新图号文件
                oOldInventorDocument.Close()

                '替换旧文件
                oOldComponentOccurrence.Replace(strNewFullFileName, True)

                '后台打开新文件，修改ipro
                oNewInventorDocument = ThisApplication.Documents.Open(strNewFullFileName, False)  '打开文件，不显示
                SetDocumentIpropertyFromFileNameSub(oNewInventorDocument, False) '设置Iproperty，打开文件后需关闭

                '是否有对应的工程图文件，同时复制后修改文件名和模型链接
                Dim strOldIdwFullFileName As String
                strOldIdwFullFileName = GetChangeExtension(strOldFullFileName, IDW)   '旧工程图
                If IsFileExsts(strOldIdwFullFileName) = True Then
                    Dim strNewIdwFullFileName As String
                    strNewIdwFullFileName = GetChangeExtension(strNewFullFileName, IDW)   '新工程图
                    FileSystem.FileCopy(strOldIdwFullFileName, strNewIdwFullFileName)             '复制为新工程图

                    Dim strTempFullFileName As String       '暂时更改旧文件名字
                    strTempFullFileName = strOldFullFileName & OLD
                    ReFileName(strOldFullFileName, strTempFullFileName)
                    MsgBox("找到有对应的旧工程图，生成新的工程图，将打开，请链接到文件：" & vbCrLf & strNewFullFileName & vbCrLf & "该文件名已复制，粘贴到对话框即可。", MsgBoxStyle.Information)
                    System.Windows.Forms.Clipboard.SetText(strNewFullFileName)
                    ThisApplication.Documents.Open(strNewIdwFullFileName, False)      '打开新的工程图，使其手动链接零件或部件
                    ThisApplication.Documents.ItemByName(strNewIdwFullFileName).Save2() '保存链接并关闭工程图
                    ThisApplication.Documents.ItemByName(strNewIdwFullFileName).Close()

                    'ReFileName(TempFullFileName, OldFullFileName)   '恢复旧零件或部件文件名

                End If
            Else
                MsgBox(strOldFullFileName & "可能已有图号", MsgBoxStyle.Information)
            End If
999:
            'TSProgressBar.Value = TSProgressBar.Value + 1
        Loop While True
        Return True
    End Function

    '获取零部件质量
    Public Function GetMass(ByVal oInventorDocument As Inventor.Document) As Double
        Dim dblvalMass As Double
        If oInventorDocument.DocumentType = kPartDocumentObject Then
            Dim oPartDocument As Inventor.PartDocument
            oPartDocument = oInventorDocument
            dblvalMass = oPartDocument.ComponentDefinition.MassProperties.Mass
        ElseIf oInventorDocument.DocumentType = kAssemblyDocumentObject Then
            Dim oAssemblyDocument As Inventor.AssemblyDocument
            oAssemblyDocument = oInventorDocument
            dblvalMass = oAssemblyDocument.ComponentDefinition.MassProperties.Mass
        Else
            dblvalMass = 0
        End If

        dblvalMass = dblvalMass + 0.00000001

        Dim intValMassAccuracy As Integer

        intValMassAccuracy = Val(Mass_Accuracy)
        dblvalMass = Math.Round(dblvalMass, intValMassAccuracy)

        Return dblvalMass
    End Function

    '获取零部件面积
    Public Function GetArea(ByVal oInventorDocument As Inventor.Document) As Double
        Dim dblArea As Double
        If oInventorDocument.DocumentType = kPartDocumentObject Then
            Dim oPartDocument As Inventor.PartDocument
            oPartDocument = oInventorDocument
            dblArea = oPartDocument.ComponentDefinition.MassProperties.Area / 10 ^ 4
        ElseIf oInventorDocument.DocumentType = kAssemblyDocumentObject Then
            Dim oAssemblyDocument As Inventor.AssemblyDocument
            oAssemblyDocument = oInventorDocument
            dblArea = oAssemblyDocument.ComponentDefinition.MassProperties.Area / 10 ^ 4
        Else
            dblArea = 0
        End If

        dblArea = dblArea + 0.00000001

        Dim intValAreaAccuracy As Integer
        intValAreaAccuracy = Val(Area_Accuracy)
        dblArea = Math.Round(dblArea, intValAreaAccuracy)

        Return dblArea
    End Function

    '获取单个描述
    Public Function GetPropitem(ByVal oInventorDocument As Inventor.Document, ByVal strPropitemName As String) As String
        Dim oPropertySets As PropertySets
        Dim oPropertySet As PropertySet
        Dim propitem As [Property]

        oPropertySets = oInventorDocument.PropertySets
        oPropertySet = oPropertySets.Item(3)

        '获取iproperty
        Dim StockNumPartName As StockNumPartName = Nothing
        For Each propitem In oPropertySet
            Select Case propitem.DisplayName
                Case strPropitemName
                    Return propitem.Value
            End Select
        Next

        'oInventorDocument.Update()   '刷新数据

        Return ""

    End Function

    '设置单个propitem
    Public Function SetPropitem(ByVal oInventorDocument As Inventor.Document, ByVal strPropitemName As String, ByVal strPropitemValue As String) As Boolean
        Dim oPropertySets As PropertySets
        Dim oPropertySet As PropertySet
        Dim propitem As [Property]

        oPropertySets = oInventorDocument.PropertySets
        oPropertySet = oPropertySets.Item(3)

        '获取iproperty
        Dim StockNumPartName As StockNumPartName = Nothing
        For Each propitem In oPropertySet
            Select Case propitem.DisplayName
                Case strPropitemName
                    propitem.Value = strPropitemValue
            End Select
        Next

        oInventorDocument.Update()   '刷新数据

        Return True

    End Function

    '获取 StockNumPartName
    Public Function GetPropitems(ByVal oInventorDocument As Inventor.Document) As StockNumPartName
        Dim oPropertySets As PropertySets
        Dim oPropertySet As PropertySet
        Dim propitem As [Property]

        oPropertySets = oInventorDocument.PropertySets
        oPropertySet = oPropertySets.Item(3)

        Dim oStockNumPartName As StockNumPartName = Nothing

        For Each propitem In oPropertySet
            Select Case propitem.DisplayName
                Case Map_PartName
                    oStockNumPartName.PartName = propitem.Value
                Case Map_DrawingNnumber
                    oStockNumPartName.StockNum = propitem.Value
                Case Map_ERPCode
                    oStockNumPartName.ERPCode = propitem.Value
            End Select
        Next

        oInventorDocument.Update()   '刷新数据

        Return oStockNumPartName

    End Function

    '设置 StockNumPartName
    Public Function SetPropitems(ByVal oInventorDocument As Inventor.Document, ByVal oStockNumPartName As StockNumPartName) As Boolean
        Dim oPropertySets As PropertySets
        Dim oPropertySet As PropertySet
        Dim propitem As [Property]

        oPropertySets = oInventorDocument.PropertySets
        oPropertySet = oPropertySets.Item(3)

        For Each propitem In oPropertySet
            Select Case propitem.DisplayName
                Case Map_PartName
                    propitem.Value = oStockNumPartName.PartName
                Case Map_DrawingNnumber
                    propitem.Value = oStockNumPartName.StockNum
                Case Map_ERPCode
                    propitem.Value = oStockNumPartName.ERPCode
            End Select
        Next

        oInventorDocument.Update()   '刷新数据

        Return True

    End Function

    '查询erp编码
    Public Sub QueryERPcode()
        'Try
        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        Dim oInventorDocument As Inventor.Document      '当前文件
        oInventorDocument = ThisApplication.ActiveEditDocument

        Dim oPropSets As PropertySets
        Dim oPropSet As PropertySet
        Dim propitem As [Property]

        oPropSets = oInventorDocument.PropertySets
        oPropSet = oPropSets.Item(3)

        '获取iproperty
        'Dim oStockNumPartName As StockNumPartName = Nothing
        Dim strStochNum As String = Nothing
        Dim strPartNum As String = Nothing

        For Each propitem In oPropSet
            Select Case propitem.DisplayName
                Case Map_DrawingNnumber
                    strStochNum = propitem.Value
                    'PartNum = VLookUpValue(Excel_File_Name, StochNum, Sheet_Name, Table_Array, Col_Index_Num, 0)
                    Exit For
            End Select
        Next

        strPartNum = FindSrtingInSheet(BasicExcelFullFileName, strStochNum, SheetName, TableArrays, ColIndexNum, 0)
        If strPartNum <> 0 Then
            MsgBox("查询到ERP编码：" & strPartNum, MsgBoxStyle.Information, "查询ERP编码")
            SetPropitem(oInventorDocument, Map_ERPCode, strPartNum)
        Else
            MsgBox("未查询到ERP编码。", MsgBoxStyle.Information)
        End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    '打开活动文件对应的工程图
    Public Sub OpenDrawingDocument(ByVal oInventorDocument As Inventor.Document)
        On Error Resume Next
        SetStatusBarText()

        'If IsInventorOpenDocument() = False Then
        '    Exit Sub
        'End If

        'If ThisApplication.ActiveDocument.DocumentType = kDrawingDocumentObject Then
        '    MsgBox("该功能仅适用于部件或零件", MsgBoxStyle.Information)
        '    'Return False
        '    Exit Sub
        'End If

        Dim strInventorFullFileName As String   '模型文件
        strInventorFullFileName = oInventorDocument.FullDocumentName

        Dim strDrawingFullFileName As String  '工程图全文件名
        strDrawingFullFileName = GetChangeExtension(strInventorFullFileName, IDW)

        ''当前文件夹查询没有就 到父文件夹查询
        'If IsFileExsts(strDrawingFullFileName) = False Then
        '    SearchDrawingDocumentInPresentFolder(oInventorDocument, 3, IDW)
        'End If

        '查询到工程图
        If IsFileExsts(strDrawingFullFileName) Then
            ThisApplication.Documents.Open(strDrawingFullFileName)
        Else
            strDrawingFullFileName = SearchDrawingDocumentInPresentFolder(oInventorDocument.FullDocumentName, 3, IDW)
            If strDrawingFullFileName = "NULL" Then
                If MsgBox(strInventorFullFileName & "没有对应的工程图，是否查找AutoCad文件？", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                    strDrawingFullFileName = SearchDrawingDocumentInPresentFolder(oInventorDocument.FullDocumentName, 3, DWG)
                    If strDrawingFullFileName = "NULL" Then
                        MsgBox(strInventorFullFileName & "没有对应的AutoCad文件！", MsgBoxStyle.Information)
                    Else
                        Process.Start(strDrawingFullFileName)
                    End If
                End If
            Else
                ThisApplication.Documents.Open(strDrawingFullFileName)
            End If
        End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub

    '到父文件夹查询工程图  ，inventor 文档 ，向上查询的层级
    Public Function SearchDrawingDocumentInPresentFolder(ByVal strFullFileName As String, _
                                                         ByVal intPresidentLevel As Integer, _
                                                         ByVal strExtension As String) As String
        On Error Resume Next

        Dim strPrsentFolder As String   '父文件夹
        'Dim strInventorFullFileName As String   '模型文件全名
        Dim strInventorFileName As String   '模型文件名
        'Dim strDrawingFullFileName As String  '工程图全文件名
        Dim strDrawingFileName As String '工程图名
        Dim i As Integer

        'strInventorFullFileName = oInventorDocument.FullDocumentName
        strInventorFileName = GetSingleName(strFullFileName)

        strDrawingFileName = GetOnlyname(strFullFileName) & strExtension

        i = 0

        strPrsentFolder = System.IO.Directory.GetParent(strFullFileName).FullName
        Do
            If IsDirectoryExists(strPrsentFolder) = True Then
                strPrsentFolder = System.IO.Directory.GetParent(strPrsentFolder).FullName
                i = i + 1
            Else
                Exit Do
            End If
        Loop While (i <> intPresidentLevel)

        Dim arrFiles As ReadOnlyCollection(Of String)
        arrFiles = My.Computer.FileSystem.GetFiles(strPrsentFolder, FileIO.SearchOption.SearchAllSubDirectories, strDrawingFileName)

        If arrFiles Is Nothing Then
            Return "NULL"
        End If

        If arrFiles.Count = 0 Then
            Return "NULL"
        End If

        For Each strDrawingFullFileName As String In arrFiles
            If IsFileExsts(strDrawingFullFileName) = True Then
                Return strDrawingFullFileName
                Exit For
            End If
        Next

    End Function

   

    '关闭指定文件名的文档
    Public Sub CloseFile(ByVal FileFullName As String)
        If IsFileExsts(FileFullName) = False Then
            Exit Sub
        Else
            '遍历Inventor中打开的文档
            For Each oInventorDocument As Inventor.Document In ThisApplication.Documents
                '获取IPT文件路径
                Dim docPath As String = oInventorDocument.FullFileName
                '比较文件路径是否一致
                If FileFullName.Equals(docPath, StringComparison.OrdinalIgnoreCase) Then
                    '关闭文件
                    oInventorDocument.Close()
                    Exit Sub
                End If

            Next
        End If
    End Sub

    '单击设置文件只读属性
    Public Sub SetWriteOnly()
        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        Dim oInventorDocument As Inventor.Document      '当前文件
        oInventorDocument = ThisApplication.ActiveEditDocument

        Dim strInventorDocumentFullDocumentName As String
        strInventorDocumentFullDocumentName = oInventorDocument.FullDocumentName

        Dim oDef1 As ButtonDefinition
        oDef1 = ThisApplication.CommandManager.ControlDefinitions.Item("InName文件只读")

        oDef1.Pressed = oDef1.Pressed Xor True
        SetFileReadOnly(strInventorDocumentFullDocumentName, oDef1.Pressed)

        'If oDef1.Pressed = True Then
        '    SetFileReadOnly(strInventorDocumentFullDocumentName, False)
        '    oDef1.Pressed = False
        'Else
        '    SetFileReadOnly(strInventorDocumentFullDocumentName, True)
        '    oDef1.Pressed = True
        'End If

    End Sub

End Module