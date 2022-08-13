Imports Inventor
Imports Inventor.SelectionFilterEnum
Imports Inventor.DocumentTypeEnum
Imports Inventor.DrawingViewTypeEnum
Imports Inventor.PropertyTypeEnum
Imports Inventor.BOMStructureEnum
Imports Inventor.IOMechanismEnum
Imports System.Windows.Forms
Imports Inventor.PrintOrientationEnum
Imports System.Text
Imports System.Collections.ObjectModel
Imports Microsoft.Office.Interop.Excel.XlFileFormat
Imports Microsoft.Office.Interop

Module InventorBasic

    Public Structure StockNumPartName
        Dim IsGet As Boolean
        Dim StockNum As String    '
        Dim PartName As String      '
        Dim PartNum As String       '
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

    Public ContentCenterFiles As String  '零件库文件夹

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

    '声明并初始化变量
    Public _ListViewSorter As clsListViewSorter.EnumSortOrder = clsListViewSorter.EnumSortOrder.Ascending

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

    '更改零件/部件文件名
    Public Function RenameAssPartDocumentName(ByVal oInventorDocument As Inventor.Document, ByVal _
                                              oOldComponentOccurrence As ComponentOccurrence, ByVal strNewFileName As String) As Boolean

        Dim strOldFullFileName As String   '被替换的旧文件全名
        Dim strOldFileName As String   '被替换的旧文件仅文件名
        strOldFullFileName = oOldComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName
        strOldFileName = GetFileNameInfo(strOldFullFileName).OnlyName

        If IsFileExsts(strOldFullFileName) = False Then
            MsgBox("文件： " & strOldFullFileName & "不存在！", MsgBoxStyle.Critical, "修改文件名")
            Return True
            Exit Function
        End If

        'Dim oOccDef As PartComponentDefinition
        'oOccDef = OldOcc.Definition

        'If Not oOccDef.IsContentMember = False Then         '跳过零件库文件
        '    MsgBox(OldFullFileName & "为零件库文件", MsgBoxStyle.Information)
        '    'OldInventorDoc.Close()
        '    Return False
        '    Exit Function
        'End If

        If InStr(strOldFullFileName, ContentCenterFiles) > 0 Then         '跳过零件库文件
            MsgBox("无法修改资源中心文件： " & strOldFullFileName, MsgBoxStyle.Information, "修改文件名")
            'OldInventorDoc.Close()
            Return True
            Exit Function
        End If

        Select Case oOldComponentOccurrence.DefinitionDocumentType
            Case kPartDocumentObject, kAssemblyDocumentObject      '选择的是部件或零件
                Dim strNewFullFileName As String   '新文件全名

                '新图号
                'frmain.Focus()

                '取消输入
                If strNewFileName = "" Then
                    Return True
                    Exit Select
                End If

                '新旧文件名一致
                If strOldFileName = strNewFileName Then
                    MsgBox("未重新命名 ", MsgBoxStyle.Information, "修改文件名")
                    Return True
                    Exit Select
                End If

                '替换旧文件全名为新文件全名
                strNewFullFileName = GetNewFileName(strOldFullFileName, strNewFileName)

                '检查新文件是否存在
                If IsFileExsts(strNewFullFileName) = True Then
                    Select Case MsgBox("存在文件：" & strNewFullFileName & vbCrLf & "是-直接替换" & vbCrLf & "否-重新生成替换" & vbCrLf & "取消-退出重新命名 ", MsgBoxStyle.Information + MsgBoxStyle.YesNoCancel)
                        Case MsgBoxResult.Yes   '直接用新文件替换
                            '全部替换为新文件
                            If MsgBox("是否替换全部零件？", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.SystemModal) = MsgBoxResult.Yes Then
                                oOldComponentOccurrence.Replace(strNewFullFileName, True)
                            Else
                                oOldComponentOccurrence.Replace(strNewFullFileName, False)
                            End If
                            Return True
                        Case MsgBoxResult.No    '重新另存为新文件，再替换

                        Case MsgBoxResult.Cancel    '取消退出
                            Return False
                    End Select
                End If

                '打开旧文件,不显示
                Dim oOldInventorDocument As Inventor.Document
                oOldInventorDocument = ThisApplication.Documents.Open(strOldFullFileName, False)

                '另存为新文件
                oOldInventorDocument.SaveAs(strNewFullFileName, True)

                '关闭旧图
                oOldInventorDocument.Close()

                '全部替换为新文件
                If MsgBox("是否替换全部零件？", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.SystemModal + MsgBoxStyle.DefaultButton1) = MsgBoxResult.Yes Then
                    oOldComponentOccurrence.Replace(strNewFullFileName, True)
                Else
                    oOldComponentOccurrence.Replace(strNewFullFileName, False)
                End If

                ThisApplication.Documents.ItemByName(strOldFullFileName).Close()
                '后台打开文件，修改ipro
                oInventorDocument = ThisApplication.Documents.Open(strNewFullFileName, False)  '打开文件，不显示

                SetDocumentIpropertyFromFileName(oInventorDocument, True) '设置Iproperty，打开文件后需关闭

                Dim IsSaveAsOld As MsgBoxResult
                IsSaveAsOld = MsgBox("是否更改原文件为备份文件，扩展名增加 .old ？", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "备份文件")

                '是否有对应的工程图文件，同时复制后修改文件名和模型链接
                Dim strOldIdwFullFileName As String
                strOldIdwFullFileName = GetNewExtensionFileName(strOldFullFileName, IDW)   '旧工程图

                Dim strTempFullFileName As String       '更改旧模型文件的名字存档

                If IsFileExsts(strOldIdwFullFileName) = True Then
                    Dim strNewIdwFullFileName As String
                    strNewIdwFullFileName = GetNewExtensionFileName(strNewFullFileName, IDW)   '新工程图
                    FileSystem.FileCopy(strOldIdwFullFileName, strNewIdwFullFileName)             '复制为新工程图

                    'MsgBox("找到有对应的旧工程图，生成新的工程图，将打开，请链接到文件：" & vbCrLf & NewFullFileName & vbCrLf & "该文件名已复制，粘贴到对话框即可。", MsgBoxStyle.Information)
                    'Windows.Forms.Clipboard.SetText(NewFullFileName)
                    'ThisApplication.Documents.Open(NewIdwFullFileName, False)      '打开新的工程图，使其手动链接零件或部件
                    'ThisApplication.Documents.ItemByName(NewIdwFullFileName).Save2() '保存链接并关闭工程图
                    'ThisApplication.Documents.ItemByName(NewIdwFullFileName).Close()

                    oInventorDocument = ThisApplication.Documents.Open(strNewIdwFullFileName, False)  '打开文件，不显示
                    oInventorDocument.ReferencedDocumentDescriptors(1).ReferencedFileDescriptor.ReplaceReference(strNewFullFileName)
                    oInventorDocument.Save2()
                    oInventorDocument.Close()

                    If IsSaveAsOld = MsgBoxResult.Yes Then
                        strTempFullFileName = strOldIdwFullFileName & OLD    '暂时更改旧工程图文件的名字存档
                        ReFileName(strOldIdwFullFileName, strTempFullFileName)
                        'ReFileName(TempFullFileName, OldFullFileName)   '恢复旧零件或部件文件名
                    End If
                End If

                If IsSaveAsOld = MsgBoxResult.Yes Then
                    strTempFullFileName = strOldFullFileName & ".old"
                    ReFileName(strOldFullFileName, strTempFullFileName)
                End If
                Return True
            Case MsgBox("选择的文件不是零件或部件", MsgBoxStyle.Information)
                Return False
        End Select

    End Function

    '更改镜像零件文件名
    Public Function RenameMirrorAssPartDocumentName(ByVal oInventorDocument As Inventor.Document, ByVal _
        oOldComponentOccurrence As ComponentOccurrence, ByVal strNewFileName As String) As Boolean

        Dim strOldFullFileName As String   '被替换的旧文件全名
        strOldFullFileName = oOldComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName

        Dim strOldFileName As String   '被替换的旧文件仅文件名
        strOldFileName = GetFileNameInfo(strOldFullFileName).OnlyName

        If IsFileExsts(strOldFullFileName) = False Then
            MsgBox(strOldFullFileName & "不存在！", MsgBoxStyle.Critical)
            Return True
            Exit Function
        End If

        'Dim oOccDef As PartComponentDefinition
        'oOccDef = OldOcc.Definition

        'If Not oOccDef.IsContentMember = False Then         '跳过零件库文件
        '    MsgBox(OldFullFileName & "为零件库文件", MsgBoxStyle.Information)
        '    'OldInventorDoc.Close()
        '    Return False
        '    Exit Function
        'End If

        If InStr(strOldFullFileName, ContentCenterFiles) > 0 Then         '跳过零件库文件
            MsgBox(strOldFullFileName & "为零件库文件", MsgBoxStyle.Information)
            'OldInventorDoc.Close()
            Return True
            Exit Function
        End If

        'Select Case OldOcc.DefinitionDocumentType
        '    Case kPartDocumentObject, kAssemblyDocumentObject      '选择的是部件或零件
        Dim strNewFullFileName As String   '新文件全名
        'Dim NewFileName As String   '新文件仅文件名
        '新图号
        'frmain.Focus()
        'NewFileName = InputBox("重命名 " & OldFullFileName, "重命名", OldFileName)  '输入新文件名

        ''取消输入
        'If NewFileName = "" Then
        '    Return True
        '    Exit Select
        'End If

        '替换旧文件全名为新文件全名
        strNewFullFileName = GetNewFileName(strOldFullFileName, strNewFileName)

        '检查新文件是否存在
        If IsFileExsts(strNewFullFileName) = True Then
            Select Case MsgBox("存在文件：" & strNewFullFileName & " ，是-直接替换  否-重新生成替换  取消-退出重新命名 ", MsgBoxStyle.Information + MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes   '直接用新文件替换
                    '全部替换为新文件
                    If MsgBox("是否替换全部零件？", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.SystemModal) = MsgBoxResult.Yes Then
                        oOldComponentOccurrence.Replace(strNewFullFileName, True)
                    Else
                        oOldComponentOccurrence.Replace(strNewFullFileName, False)
                    End If

                    Return True
                Case MsgBoxResult.No    '重新另存为新文件，再替换

                Case MsgBoxResult.Cancel    '取消退出
                    Return False
            End Select
        End If

        '打开旧文件,不显示
        Dim oOldInventorDocument As Inventor.Document
        oOldInventorDocument = ThisApplication.Documents.Open(strOldFullFileName, False)

        '基础文件
        Dim strReferencedFullFileName As String
        Dim strReferencedFullFileNameTemp As String
        strReferencedFullFileName = oOldInventorDocument.ReferencedDocuments(1).FullFileName
        strReferencedFullFileNameTemp = strReferencedFullFileName & OLD

        '重命名基础文件
        ReFileName(strReferencedFullFileName, strReferencedFullFileNameTemp)

        '另存为新文件
        oOldInventorDocument.SaveAs(strNewFullFileName, True)

        '关闭旧图
        oOldInventorDocument.Close()

        '全部替换为新文件

        If MsgBox("是否替换全部零件？", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.SystemModal) = MsgBoxResult.Yes Then
            MsgBox("选择 " & strNewFullFileName & "  的基础文件！")
            oOldComponentOccurrence.Replace(strNewFullFileName, True)
        Else
            MsgBox("选择 " & strNewFullFileName & "  的基础文件！")
            oOldComponentOccurrence.Replace(strNewFullFileName, False)
        End If

        ThisApplication.Documents.ItemByName(strOldFullFileName).Close()
        '后台打开文件，修改ipro
        oInventorDocument = ThisApplication.Documents.Open(strNewFullFileName, False)  '打开文件，不显示

        SetDocumentIpropertyFromFileName(oInventorDocument, True) '设置Iproperty，打开文件后需关闭

        '还原早一个版本的文件()
        ReFileName(strReferencedFullFileNameTemp, strReferencedFullFileName)

        Return True
        '    Case MsgBox("选择的文件不是零件或部件", MsgBoxStyle.Information)
        'Return False
        'End Select

    End Function

    '根据文件名提取到iproperty  （  文件对象 ； 文件是否需打开，打开的文件用后要关闭）
    Public Function SetDocumentIpropertyFromFileName(ByVal oInventorDocument As Inventor.Document, ByVal IsNeedClose As Boolean) As Boolean
        Dim strFullFileName As String      '当前文件全名
        Dim strFileName As String

        strFullFileName = oInventorDocument.FullFileName
        strFileName = GetFileNameInfo(strFullFileName).OnlyName

        If InStr(strFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
            MsgBox("无法修改资源中心文件： " & strFullFileName, MsgBoxStyle.Information, "修改iProperty")

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
                    If oStockNumPartName.PartNum <> "" Then
                        propitem.Value = oStockNumPartName.PartNum
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

    '修改部件包含文件的iProperty   （ 部件文件对象 ； 文件是否需打开，打开的文件用后要关闭）
    Public Function SetDocumentsInAssIpropertyFromFileName(ByVal oAssemblyDocument As AssemblyDocument, ByVal IsNeedClose As Boolean) As Boolean
        ' 获取所有引用文档

        Dim FirstLevelOnly As Boolean

        Select Case MsgBox("修改模式：是-仅修改第一级零件   否-修改所有级别零件 ", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, "修改模式")
            Case MsgBoxResult.Yes
                'RefDocs = AsmDoc.ReferencedDocuments
                FirstLevelOnly = True
            Case MsgBoxResult.No
                'RefDocs = AsmDoc.AllReferencedDocuments
                FirstLevelOnly = False
            Case Else
                Return True
        End Select

        '==============================================================================================
        '基于bom结构化数据，可跳过参考的文件
        ' Set a reference to the BOM
        Dim oBOM As BOM
        oBOM = oAssemblyDocument.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True

        'Set a reference to the "Structured" BOMView
        Dim oBOMView As BOMView

        '获取结构化的bom页面
        For Each oBOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                '遍历这个bom页面
                QueryBOMRowToSetiPro(oBOMView.BOMRows, FirstLevelOnly)
            End If
        Next
        '==============================================================================================
        Return True
    End Function

    '遍历BOM结构，查询row文件修改ipro
    Public Sub QueryBOMRowToSetiPro(ByVal oBOMRows As BOMRowsEnumerator, ByVal FirstLevelOnly As Boolean)
        Dim i As Integer

        Dim intStepCount As Integer
        intStepCount = oBOMRows.Count

        'Create a new ProgressBar object.
        Dim oProgressBar As Inventor.ProgressBar

        oProgressBar = ThisApplication.CreateProgressBar(False, intStepCount, "当前文件： ")

        For i = 1 To oBOMRows.Count
            ' Get the current row.
            Dim oBOMRow As BOMRow
            oBOMRow = oBOMRows.Item(i)

            Dim strFullFileName As String

            strFullFileName = oBOMRow.ReferencedFileDescriptor.FullFileName

            '测试文件
            Debug.Print(strFullFileName)

            ' Set the message for the progress bar
            oProgressBar.Message = strFullFileName

            If IsFileExsts(strFullFileName) = False Then   '跳过不存在的文件
                GoTo 999
            End If

            If InStr(strFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                GoTo 999
            End If

            Dim oInventorDocument As Inventor.Document
            oInventorDocument = ThisApplication.Documents.Open(strFullFileName, False)  '打开文件，不显示

            SetDocumentIpropertyFromFileName(oInventorDocument, True) '设置Iproperty,打开文件后需关闭

            '遍历下一级
            If (Not oBOMRow.ChildRows Is Nothing) And FirstLevelOnly = False Then
                Call QueryBOMRowToSetiPro(oBOMRow.ChildRows, FirstLevelOnly)
            End If

999:
            oProgressBar.UpdateProgress()
        Next

        oProgressBar.Close()

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

        intAssNumberStep = Val(InputBox("输入部件文件的编号变化，部件XXX-0000000 下第一个部件为XXX-0000100 则 输入 100 "))
        If intAssNumberStep = 0 Then
            Return False
            Exit Function
        End If

        intPartNumberStep = Val(InputBox("输入零件文件的编号变化，部件XXX-0000000 下第一个零件为XXX-0000001 则 输入 1 "))
        If intPartNumberStep = 0 Then
            Return False
            Exit Function
        End If

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
            oOldComponentOccurrence = ThisApplication.CommandManager.Pick(kAssemblyOccurrenceFilter, "选择要编号的文件")

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
                    Select Case MsgBox("存在一个已命名图号的文件：" & FoundFile & " ，是-直接替换  否-重新生成替换 ", MsgBoxStyle.Information + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, "自动生成零件图号")
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
                SetDocumentIpropertyFromFileName(oNewInventorDocument, False) '设置Iproperty，打开文件后需关闭

                '是否有对应的工程图文件，同时复制后修改文件名和模型链接
                Dim strOldIdwFullFileName As String
                strOldIdwFullFileName = GetNewExtensionFileName(strOldFullFileName, IDW)   '旧工程图
                If IsFileExsts(strOldIdwFullFileName) = True Then
                    Dim strNewIdwFullFileName As String
                    strNewIdwFullFileName = GetNewExtensionFileName(strNewFullFileName, IDW)   '新工程图
                    FileSystem.FileCopy(strOldIdwFullFileName, strNewIdwFullFileName)             '复制为新工程图

                    Dim strTempFullFileName As String       '暂时更改旧文件名字
                    strTempFullFileName = strOldFullFileName & OLD
                    ReFileName(strOldFullFileName, strTempFullFileName)
                    MsgBox("找到有对应的旧工程图，生成新的工程图，将打开，请链接到文件：" & vbCrLf & strNewFullFileName & vbCrLf & "该文件名已复制，粘贴到对话框即可。", MsgBoxStyle.Information)
                    Windows.Forms.Clipboard.SetText(strNewFullFileName)
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

    '另存为dwg
    Public Function SaveAsDwg(ByVal oDrawingDocument As Inventor.DrawingDocument) As String
        Dim strIdwFullFileName As String         '工程图全文件名
        Dim strDwgFullFileName As String        'cad 文件全文件名

        strIdwFullFileName = oDrawingDocument.FullFileName
        strDwgFullFileName = Strings.Replace(strIdwFullFileName, LCaseGetFileExtension(strIdwFullFileName), ".dwg")

        If IsFileExsts(strDwgFullFileName) Then
            Dim msg As MsgBoxResult = MsgBox("已存在文件： " & strDwgFullFileName & "  是否覆盖（是）或另存为（否）？", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, "另存为Dwg")
            Select Case msg
                Case MsgBoxResult.Yes

                Case MsgBoxResult.No
                    Dim oSaveFileDialog As New SaveFileDialog
                    With oSaveFileDialog
                        .Title = "选择 dwg 文件"
                        .Filter = "AutoCAD文件(*.dwg)|*.dwg"
                        .InitialDirectory = GetParentFolder(oDrawingDocument.FullDocumentName)
                        If .ShowDialog = DialogResult.OK Then
                            strDwgFullFileName = .FileName
                        Else
                            Return "取消"
                        End If
                    End With
                Case MsgBoxResult.Cancel
                    Return "取消"
            End Select
        End If

        'IdwDoc.SaveAs(DwgFullFileName, True)

        'If IsFileExsts(DwgFullFileName) = False Then
        '    DwgFullFileName = Strings.Replace(DwgFullFileName, ".dwg", ".zip")
        'End If

        ' 获取对应的Translator.
        Dim oTranslatorAddIn As TranslatorAddIn
        oTranslatorAddIn = ThisApplication.ApplicationAddIns.ItemById("{C24E3AC2-122E-11D5-8E91-0010B541CD80}")

        ' 获取当前零件或装配文档.

        Dim oTransientObjects As TransientObjects
        oTransientObjects = ThisApplication.TransientObjects

        ' 设置导出文件
        Dim oTranslationContext As TranslationContext
        oTranslationContext = oTransientObjects.CreateTranslationContext
        oTranslationContext.Type = kFileBrowseIOMechanism

        ' 获取可操作的选项
        Dim oNameValueMap As NameValueMap
        oNameValueMap = oTransientObjects.CreateNameValueMap
        If oTranslatorAddIn.HasSaveCopyAsOptions(oDrawingDocument, oTranslationContext, oNameValueMap) Then
            ' 设置导出样式.
            oNameValueMap.Value("Solid") = True      ' 导出 solids.
            oNameValueMap.Value("Surface") = False   ' 导出 surfaces.
            oNameValueMap.Value("Sketch") = False    ' 导出 sketches.

            ' 设置导出DWG的版本.
            ' 23 = ACAD 2000
            ' 25 = ACAD 2004
            ' 27 = ACAD 2007
            ' 29 = ACAD 2010
            oNameValueMap.Value("DwgVersion") = 23
        End If

        ' 设置导出文件名.
        Dim oDataMedium As DataMedium
        oDataMedium = oTransientObjects.CreateDataMedium
        oDataMedium.FileName = strDwgFullFileName

        ' 调用SaveCopyAs
        Call oTranslatorAddIn.SaveCopyAs(oDrawingDocument, oTranslationContext, oNameValueMap, oDataMedium)

        Return strDwgFullFileName

    End Function

    '另存为pdf
    Public Function SaveAsPdf(ByVal InventorDocument As Inventor.Document) As String

        Dim strInventorFullFileName As String  '工程图全文件名
        Dim strPdfFullFileName As String        'pdf 文件全文件名

        strInventorFullFileName = InventorDocument.FullFileName
        strPdfFullFileName = Strings.Replace(strInventorFullFileName, LCaseGetFileExtension(strInventorFullFileName), ".pdf")

        If IsFileExsts(strPdfFullFileName) Then
            Dim msg As MsgBoxResult = MsgBox("已存在文件： " & strPdfFullFileName & "  是否覆盖（是）或另存为（否）？", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, "另存为Dwg")
            Select Case msg
                Case MsgBoxResult.Yes

                Case MsgBoxResult.No
                    Dim oSaveFileDialog As New SaveFileDialog
                    With oSaveFileDialog
                        .Title = "选择 Pdf 文件"
                        .Filter = "Adobe PDF文件(*.pdf)|*.pdf"
                        .InitialDirectory = GetParentFolder(InventorDocument.FullDocumentName)
                        If .ShowDialog = DialogResult.OK Then
                            strPdfFullFileName = .FileName
                        Else
                            Return "取消"
                        End If
                    End With
                Case MsgBoxResult.Cancel
                    Return "取消"
            End Select
        End If

        InventorDocument.SaveAs(strPdfFullFileName, True)

        Return strPdfFullFileName

    End Function

    '设置工程图自定义比例
    Public Function SetDrawingScale(ByVal oDrawingDocument As Inventor.DrawingDocument) As Boolean

        For Each oDrawingView As DrawingView In oDrawingDocument.Sheets(1).DrawingViews
            If GetViewType(oDrawingView) = "主视图" Then
                'View.Scale.ToString()
                Dim strPropertyName As String
                strPropertyName = Map_DrawingScale

                Dim strScale As String
                strScale = oDrawingView.ScaleString

                Dim pEachScale As [Property]

                Try
                    '若该iProperty已经存在，则直接修改其值
                    pEachScale = oDrawingDocument.PropertySets.Item("User Defined Properties").Item(strPropertyName)
                    pEachScale.Value = StrScale

                Catch
                    ' 若该iProperty不存在，则添加一个
                    oDrawingDocument.PropertySets.Item("User Defined Properties").Add(strScale, strPropertyName)
                End Try

                oDrawingDocument.Update()   '刷新数据

                Return True
            End If
        Next

        Return False
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

    '设置工程图自定义质量
    Public Function SetMass(ByVal oDrawingDocument As DrawingDocument) As Boolean
        Dim oPropertyName As String
        oPropertyName = "质量"

        Dim oInventorDocument As Inventor.Document

        Dim dblMass As Double = 0
        Dim TempdoubleMass As Double = 0
        For Each oInventorDocument In oDrawingDocument.ReferencedDocuments
            TempdoubleMass = GetMass(oInventorDocument)
            If TempdoubleMass > dblMass Then
                dblMass = TempdoubleMass
            End If
        Next

        Dim strMass As String
        strMass = dblMass.ToString

        Dim pEachScale As [Property]

        Try
            '若该iProperty已经存在，则直接修改其值
            pEachScale = oDrawingDocument.PropertySets.Item("User Defined Properties").Item(oPropertyName)
            pEachScale.Value = strMass

        Catch
            ' 若该iProperty不存在，则添加一个
            oDrawingDocument.PropertySets.Item("User Defined Properties").Add(strMass, oPropertyName)
        End Try

        oDrawingDocument.Update()   '刷新数据

        Return True

    End Function

    '获取视图类型
    Public Function GetViewType(ByVal oDrawingView As DrawingView) As String
        '遍历每个视图
        Select Case (oDrawingView.ViewType)
            Case kStandardDrawingViewType
                Return ("主视图")
            Case kAssociativeDraftDrawingViewType
                Return ("关联草图视图")
            Case kAuxiliaryDrawingViewType
                Return ("辅助视图")
            Case kCustomDrawingViewType
                Return ("自定义视图")
            Case kDefaultDrawingViewType
                Return ("缺省视图")
            Case kDetailDrawingViewType
                Return ("详细视图")
            Case kDraftDrawingViewType
                Return ("草图视图")
            Case kOLEAttachmentDrawingViewType
                Return ("OLE附着视图")
            Case kOverlayDrawingViewType
                Return ("覆盖视图")
            Case kProjectedDrawingViewType
                Return ("投影视图")
            Case kSectionDrawingViewType
                Return ("局部视图")
        End Select

        Return "无法识别"
    End Function

    '设置工程图自定义属性：对称件IPro
    Public Function SetDrawingMirPartIPro(ByVal oDrawingDocument As DrawingDocument) As Boolean
        Dim oSheet As Sheet
        oSheet = oDrawingDocument.ActiveSheet

        Dim oView As DrawingView
        oView = oSheet.DrawingViews.Item(1)

        Dim oRef As DocumentDescriptor
        oRef = oView.ReferencedDocumentDescriptor

        '获取本零件文件夹路径
        Dim strMirFileFullFileName As String
        Dim oOpenFileDialog As New OpenFileDialog
        With oOpenFileDialog
            .Multiselect = False
            .Title = "选择 ipt iam 文件"
            .Filter = "Inventor 文件(*.ipt;*.iam)|*.ipt;*.iam|Inventor 零件(*.ipt)|*.ipt|Inventor 部件(*.iam)|*.iam"
            .InitialDirectory = GetParentFolder(oRef.FullDocumentName)
            If .ShowDialog = DialogResult.OK Then
                strMirFileFullFileName = .FileName
            Else
                Return True
                Exit Function
            End If
        End With

        '获取镜像零件ipro
        Dim oStockNumPartName As StockNumPartName
        oStockNumPartName = GetStockNumPartName(strMirFileFullFileName)

        '设置ipro
        Dim pEachScale As [Property]
        Try
            '若该iProperty已经存在，则直接修改其值
            pEachScale = oDrawingDocument.PropertySets.Item("User Defined Properties").Item(Map_Mir_StochNum)
            pEachScale.Value = oStockNumPartName.StockNum

            pEachScale = oDrawingDocument.PropertySets.Item("User Defined Properties").Item(Map_Mir_PartName)
            pEachScale.Value = oStockNumPartName.PartName

        Catch
            ' 若该iProperty不存在，则添加一个
            oDrawingDocument.PropertySets.Item("User Defined Properties").Add(oStockNumPartName.StockNum, Map_Mir_StochNum)
            oDrawingDocument.PropertySets.Item("User Defined Properties").Add(oStockNumPartName.PartName, Map_Mir_PartName)
        End Try

        oDrawingDocument.Update()   '刷新数据

        Return True

    End Function

    '设置打印时间
    'Public Function SetPrintTime(ByVal IdwDoc As DrawingDocument, ByVal AddTime As Short) As Boolean
    '    Dim pEachScale As [Property]

    '    Dim Print_Day As String

    '    Print_Day = " "
    '    Select Case AddTime
    '        Case 0    '清除数据改为空白

    '        Case 1   '当前日写数据
    '            Print_Day = Today.Year & "." & Today.Month & "." & Today.Day
    '        Case 2      '自定义日期写数据
    '            Print_Day = Today.Year & "." & Today.Month & "." & Today.Day
    '            Print_Day = InputBox("输入日期", "日期", Print_Day)
    '    End Select

    '    Try
    '        '若该iProperty已经存在，则直接修改其值

    '        pEachScale = IdwDoc.PropertySets.Item("User Defined Properties").Item(Map_PrintDay)
    '        pEachScale.Value = Print_Day
    '    Catch
    '        ' 若该iProperty不存在，则添加一个
    '        IdwDoc.PropertySets.Item("User Defined Properties").Add(Print_Day, Map_PrintDay)
    '    End Try
    '    IdwDoc.Update()   '刷新数据
    '    Return True
    'End Function

    '设置签字
    Public Function SetSign(ByVal oDrawingDocument As DrawingDocument, ByVal EngineerName As String, ByVal strPrintDate As String, ByVal IsOPenPrintDialog As Boolean) As Boolean
        Dim oPropertySets As PropertySets
        Dim oPropertySet As PropertySet
        Dim propitem As [Property]

        oPropertySets = oDrawingDocument.PropertySets
        oPropertySet = oPropertySets.Item(3)

        For Each propitem In oPropertySet   '设置iproperty
            Select Case propitem.DisplayName
                Case "工程师"
                    propitem.Value = EngineerName
            End Select
        Next

        Dim pEachScale As [Property]

        Try
            '若该iProperty已经存在，则直接修改其值
            pEachScale = oDrawingDocument.PropertySets.Item("User Defined Properties").Item(Map_PrintDay)
            pEachScale.Value = strPrintDate
        Catch
            ' 若该iProperty不存在，则添加一个
            oDrawingDocument.PropertySets.Item("User Defined Properties").Add(strPrintDate, Map_PrintDay)
        End Try

        oDrawingDocument.Update()   '刷新数据

        '打开打印窗口()
        If IsOpenPrint = 1 And IsOPenPrintDialog = True Then
            Dim oCommmandbars As CommandControl
            For Each oCommmandbars In ThisApplication.UserInterfaceManager.FileBrowserControls
                If oCommmandbars.DisplayName = "打印" Then
                    Dim oCommandbarPrint As CommandControl
                    For Each oCommandbarPrint In oCommmandbars.ChildControls
                        If oCommandbarPrint.DisplayName = "打印" Then
                            oCommandbarPrint.ControlDefinition.Execute2(True)
                        End If
                    Next
                    Exit For
                End If
            Next
        End If

        Return True

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
                Case strpropitemName
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
                    oStockNumPartName.PartNum = propitem.Value
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
                    propitem.Value = oStockNumPartName.PartNum
            End Select
        Next

        oInventorDocument.Update()   '刷新数据

        Return True

    End Function


    '提取iproperty更改文件名
    Public Function GetIpropertyToRename(ByVal oInventorDoc As Inventor.Document, ByVal oOldComponentOccurrence As ComponentOccurrence) As Boolean
        Dim strOldFullFileName As String   '被替换的旧文件全名
        Dim strOldFileName As String   '被替换的旧文件仅文件名
        strOldFullFileName = oOldComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName
        strOldFileName = GetFileNameInfo(strOldFullFileName).OnlyName

        If IsFileExsts(strOldFullFileName) = False Then
            MsgBox("文件： " & strOldFullFileName & "不存在！", MsgBoxStyle.Critical, "修改文件名")
            Return True
            Exit Function
        End If

        If InStr(strOldFullFileName, ContentCenterFiles) > 0 Then         '跳过零件库文件
            MsgBox("无法修改资源中心文件： " & strOldFullFileName, MsgBoxStyle.Information, "修改文件名")
            'OldInventorDoc.Close()
            Return True
            Exit Function
        End If

        Select Case oOldComponentOccurrence.DefinitionDocumentType
            Case kPartDocumentObject, kAssemblyDocumentObject      '选择的是部件或零件
                Dim strNewFullFileName As String   '新文件全名
                Dim strNewFileName As String   '新文件仅文件名
                '新图号
                'frmain.Focus()
                '打开旧文件,不显示
                Dim oOldInventorDocument As Document
                oOldInventorDocument = ThisApplication.Documents.Open(strOldFullFileName, False)

                Dim oPropertySets As PropertySets
                Dim oPropertySe As PropertySet
                Dim propitem As [Property]

                oPropertySets = oOldInventorDocument.PropertySets
                oPropertySe = oPropertySets.Item(3)

                '获取iproperty
                Dim oStockNumPartName As StockNumPartName = Nothing
                For Each propitem In oPropertySe
                    Select Case propitem.DisplayName
                        Case Map_PartName
                            oStockNumPartName.PartName = propitem.Value
                        Case Map_DrawingNnumber
                            oStockNumPartName.StockNum = propitem.Value
                        Case "描述"
                            ' propitem.Value = ""
                    End Select
                Next

                '新文件名
                strNewFileName = oStockNumPartName.StockNum & oStockNumPartName.PartName

                '替换旧文件全名为新文件全名
                strNewFullFileName = GetNewFileName(strOldFullFileName, strNewFileName)

                If strNewFullFileName = strOldFullFileName Then
                    MsgBox("iProperty与文件名匹配，无需重命名文件！", MsgBoxStyle.Information)
                    '关闭旧图,不保存
                    oOldInventorDocument.Close(True)
                    Return True
                End If

                '检查新文件是否存在
                If IsFileExsts(strNewFullFileName) = True Then
                    Select Case MsgBox("存在文件：" & strNewFullFileName & " ，是-直接替换  否-重新生成替换  取消-退出重新命名 ", MsgBoxStyle.Information + MsgBoxStyle.YesNoCancel)
                        Case MsgBoxResult.Yes   '直接用新文件替换
                            '全部替换为新文件
                            'If MsgBox("是否替换全部零件？", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.SystemModal) = MsgBoxResult.Yes Then
                            oOldComponentOccurrence.Replace(strNewFullFileName, True)
                            'Else
                            'OldOcc.Replace(NewFullFileName, False)
                            'End If
                            oOldInventorDocument.Close(True)
                            Return True
                        Case MsgBoxResult.No    '重新另存为新文件，再替换

                        Case MsgBoxResult.Cancel    '取消退出
                            '关闭旧图
                            oOldInventorDocument.Close(True)
                            Return True
                    End Select
                End If

                '另存为新文件
                oOldInventorDocument.SaveAs(strNewFullFileName, True)

                '全部替换为新文件
                oOldComponentOccurrence.Replace(strNewFullFileName, True)

                '后台打开新文件，修改ipro
                Dim oNewInventorDocument As Inventor.Document
                oNewInventorDocument = ThisApplication.Documents.Open(strNewFullFileName, False)  '打开文件，不显示
                '设置新文件的Iproperty，打开文件后不关闭
                SetDocumentIpropertyFromFileName(oNewInventorDocument, False)

                '检查是否有对应的工程图文件，同时复制后修改文件名和模型链接
                Dim strOldDrawingFullFileName As String
                strOldDrawingFullFileName = GetNewExtensionFileName(strOldFullFileName, IDW)   '旧工程图

                If IsFileExsts(strOldDrawingFullFileName) = True Then
                    Dim strNewDrawingFullFileName As String
                    '新工程图
                    strNewDrawingFullFileName = GetNewExtensionFileName(strNewFullFileName, IDW)
                    '复制为新工程图
                    FileSystem.FileCopy(strOldDrawingFullFileName, strNewDrawingFullFileName)

                    Dim oNewDrawingDocument As Inventor.DrawingDocument
                    '打开新工程图文件，不显示
                    oNewDrawingDocument = ThisApplication.Documents.Open(strNewDrawingFullFileName, False)
                    '在新工程图中替换新的零件部件引用
                    oNewDrawingDocument.ReferencedDocumentDescriptors(1).ReferencedFileDescriptor.ReplaceReference(strNewFullFileName)
                    '保存关闭新工程图
                    oNewDrawingDocument.Save2()
                    oNewDrawingDocument.Close()
                    '关闭旧的零件部件
                    oOldInventorDocument.Close(True)
                    oNewInventorDocument.Close()
                End If

                Return True
            Case MsgBox("选择的文件不是零件或部件", MsgBoxStyle.Information)
                Return False
        End Select
    End Function

    '设置序号
    Public Function SetSerialNumber(ByVal oDrawingDocument As DrawingDocument) As Boolean
        Dim oActiveSheet As Sheet
        oActiveSheet = oDrawingDocument.ActiveSheet

        If oActiveSheet.PartsLists.Count = 0 Then
            MsgBox("该工程图无明细表", MsgBoxStyle.Critical)
            Return False
            Exit Function
        End If

        Dim intFirstBalloonNumber As Integer
        Dim intBalloonNumber As Integer
        intFirstBalloonNumber = InputBox("输入第一个序号：", "重建序号", "1")

        intBalloonNumber = intFirstBalloonNumber

        '        '设置序号为0
        'Dim partslistrow As Inventor.PartsListRow

        For Each oPartsList As Inventor.PartsListRow In oActiveSheet.PartsLists.Item(1).PartsListRows
            If oPartsList.Item(1).Value >= intFirstBalloonNumber Then
                oPartsList.Item(1).Value = 0
            End If
        Next

        '获取当前balloon的textstyle
        Dim OldBalloonTextStyl As String = oDrawingDocument.StylesManager.ActiveStandardStyle.ActiveObjectDefaults.BalloonStyle.TextStyle.Name

        '获取当前balloonstyle
        Dim oActiveBalloonStyle As BalloonStyle = oDrawingDocument.StylesManager.ActiveStandardStyle.ActiveObjectDefaults.BalloonStyle

        '新建 ZeroBalloonText
        Try
            If oDrawingDocument.StylesManager.TextStyles.Item("ZeroBalloonText") Is Nothing Then

            End If
        Catch ex As Exception
            Dim oZeroBalloonText As TextStyle
            oZeroBalloonText = oDrawingDocument.StylesManager.TextStyles.Item(OldBalloonTextStyl).Copy("ZeroBalloonText")

            Dim oZeroBalloonTextColor As Color = ThisApplication.TransientObjects.CreateColor(255, 0, 128)
            oZeroBalloonText.Color = oZeroBalloonTextColor
        End Try

        '设置当前balloon style 为新的 zeroballoonstyle
        oActiveBalloonStyle.TextStyle = oDrawingDocument.StylesManager.TextStyles.Item("ZeroBalloonText")

        ' '' ''
        ' '' ''        '点击每个序号组
        ' '' ''        Dim oBalloon As Balloon
        ' '' ''        For i = 1 To oActiveSheet.PartsLists.Item(1).PartsListRows.Count
        ' '' ''            oBalloon =   ThisApplication.CommandManager.Pick(kDrawingBalloonFilter, "选择引出序号")
        ' '' ''            '遍历序号组中的序号，不为0就设置序号，并加1，设置下一个，有序号则跳过
        ' '' ''            For Each oBalloonValueSet As BalloonValueSet In oBalloon.BalloonValueSets
        ' '' ''                If oBalloonValueSet.Value = 0 Then
        ' '' ''                    oBalloonValueSet.Value = i
        ' '' ''                    i = i + 1
        ' '' ''                End If
        ' '' ''            Next
        ' '' ''            '多加的1要减去
        ' '' ''            i = i - 1
        ' '' ''        Next

        '点击每个序号组
        Try
            Dim oBalloon As Balloon
            Do
                oBalloon = ThisApplication.CommandManager.Pick(kDrawingBalloonFilter, "选择引出序号")

                For Each oBalloonValueSet As BalloonValueSet In oBalloon.BalloonValueSets
                    'If (oBalloonValueSet.Value >= FirstBalloonNumber) Then
                    If oBalloonValueSet.Value = 0 Then
                        oBalloonValueSet.Value = intBalloonNumber
                        intBalloonNumber = intBalloonNumber + 1
                    End If
                Next
            Loop While True
        Catch ex As Exception

            'esc 退出后，还原balloon style
            oActiveBalloonStyle.TextStyle = oDrawingDocument.StylesManager.TextStyles.Item(OldBalloonTextStyl)

            Return True
        End Try
    End Function

    '检查序号完整性
    Public Function CheckSerialNumber(ByVal oDrawingDocument As DrawingDocument) As Boolean

        Dim oActiveSheet As Sheet
        oActiveSheet = oDrawingDocument.ActiveSheet

        If oActiveSheet.Balloons.Count = 0 Then
            MsgBox("该工程图无序号，请添加 序号", MsgBoxStyle.Critical)
            Return False
            Exit Function
        End If

        If oActiveSheet.PartsLists.Count = 0 Then
            MsgBox("该工程图无明细表，请插入一个 明细表 ", MsgBoxStyle.Critical)
            Return False
            Exit Function
        End If

        Dim oPartsListRows As PartsListRows = oActiveSheet.PartsLists.Item(1).PartsListRows

        Dim strList As String = ""

        '新建颜色
        Dim oColor As Color
        oColor = ThisApplication.TransientObjects.CreateColor(255, 0, 128)

        Dim strPartName As String
        For Each oPartsListRow As Inventor.PartsListRow In oPartsListRows

            If oPartsListRow.Ballooned = False Then
                strList = strList & oPartsListRow.Item(1).Value & " , "
            End If

            If oPartsListRow.ReferencedFiles.Count <> 0 Then
                strPartName = GetFileNameInfo(oPartsListRow.ReferencedFiles(1).FullFileName).OnlyName
                '设置颜色
                SetPartCorlor(oDrawingDocument, strPartName, oColor, oPartsListRow.Ballooned)
            End If


        Next

        If Strings.Len(strList) > 1 Then
            MsgBox("明细表：" & strList & " 无序号", MsgBoxStyle.Information, "检查序号完整性")
            Return False
        Else
            Return True
        End If

        'Return True
    End Function

    '设置工程图零件颜色(工程图，零件，颜色，是否有序号)
    Public Sub SetPartCorlor(ByVal oDrawingDocument As DrawingDocument, ByVal partStr As String, _
                             ByVal oColor As Color, ByVal oPartsListRowBallooned As Boolean)

        Dim oTransaction As Transaction
        Dim refAssyDef As ComponentDefinition = Nothing

        oTransaction = ThisApplication.TransactionManager.StartTransaction(oDrawingDocument, "Colorize [PART]")

        '遍历图纸
        For Each oSheet As Sheet In oDrawingDocument.Sheets
            '遍历视图
            For Each oDrawingView As DrawingView In oSheet.DrawingViews

                If oDrawingView.ReferencedDocumentDescriptor.ReferencedDocumentType = DocumentTypeEnum.kPresentationDocumentObject Then
                    refAssyDef = oDrawingView.ReferencedDocumentDescriptor.ReferencedDocument.ReferencedDocuments(1).ComponentDefinition
                ElseIf oDrawingView.ReferencedFile.DocumentType = DocumentTypeEnum.kAssemblyDocumentObject Then
                    refAssyDef = oDrawingView.ReferencedFile.DocumentDescriptor.ReferencedDocument.ComponentDefinition
                End If

                If (refAssyDef Is Nothing) Then
                    Continue For
                End If

                For Each oComponentOccurrence As ComponentOccurrence In refAssyDef.Occurrences
                    If oComponentOccurrence.Name Like partStr & ":*" Then

                        Try
                            Dim ViewCurves As DrawingCurvesEnumerator = oDrawingView.DrawingCurves(oComponentOccurrence)

                            If oPartsListRowBallooned = True Then
                                '已有序号，判断颜色属性
                                '设置颜色
                                Dim oBlackColor As Color = ThisApplication.TransientObjects.CreateColor(0, 0, 0)

                                For Each c As DrawingCurve In ViewCurves
                                    Select Case c.Color.ColorSourceType
                                        Case ColorSourceTypeEnum.kAutomaticColorSource, ColorSourceTypeEnum.kLayerColorSource
                                            Exit For
                                        Case ColorSourceTypeEnum.kOverrideColorSource
                                            c.Color = Nothing
                                            c.Color.ColorSourceType = ColorSourceTypeEnum.kLayerColorSource
                                            'c.Color = oBlackColor
                                    End Select
                                Next

                            Else
                                '没有序号，设置彩色
                                For Each c As DrawingCurve In ViewCurves
                                    c.Color = oColor
                                Next
                            End If

                        Catch ex As Exception
                        End Try
                    End If
                Next
            Next
        Next
        oTransaction.End()
    End Sub

    Public Function InsertSerialNumber(ByVal oDrawingDocument As DrawingDocument) As Boolean
        Dim oActiveSheet As Sheet
        oActiveSheet = oDrawingDocument.ActiveSheet

        If oActiveSheet.PartsLists.Count = 0 Then
            MsgBox("该工程图无明细表", MsgBoxStyle.Critical)
            Return False
            Exit Function
        End If

        Dim strFirstBalloonNumber As String

        strFirstBalloonNumber = InputBox("输入要插入的序号，并点击该序号的标注标识", "插入序号")

        If strFirstBalloonNumber = "" Then
            Return False
        End If

        Dim intFirstBalloonNumber As Integer
        intFirstBalloonNumber = Val(strFirstBalloonNumber)

        '点击被插入的序号标识
        Dim oBalloon As Balloon
        oBalloon = ThisApplication.CommandManager.Pick(kDrawingBalloonFilter, "选择被插入的引出序号标识")

        '  设置序号+1

        For Each oPartsListRow As Inventor.PartsListRow In oActiveSheet.PartsLists.Item(1).PartsListRows
            If oPartsListRow.Item(1).Value >= intFirstBalloonNumber Then
                oPartsListRow.Item(1).Value = oPartsListRow.Item(1).Value + 1
            End If
        Next

        '设置插入序号对应的标识
        For Each oBalloonValueSet As BalloonValueSet In oBalloon.BalloonValueSets
            If oBalloonValueSet.Value = 0 Then
                oBalloonValueSet.Value = intFirstBalloonNumber
            Else
                MsgBox("该标识数值不为0，请重新选择。", MsgBoxStyle.Information)
            End If
        Next

        Return True
    End Function

    '设置当前部件下级为虚拟件
    Public Function SetBOMStructuret(ByVal oAssemblyDocument As AssemblyDocument) As Boolean
        '设置结构类型
        Dim BOMStructureType As BOMStructureEnum

        Dim strBOMStructureType As String
        strBOMStructureType = InputBox("将本部件所属零部件设置为【普通件】或【虚拟件】。输入要设置的类型：" & vbCrLf & vbCrLf & _
                                       "1——普通件" & vbCrLf & vbCrLf & _
                                       "2——虚拟件" & vbCrLf & vbCrLf & _
                                       "3——外购件", _
                                       "设置虚拟件", 2)

        Select Case strBOMStructureType
            Case ""
                Return True
            Case "1"  '普通件
                BOMStructureType = kNormalBOMStructure
            Case "2"  '虚拟件
                BOMStructureType = kPhantomBOMStructure
            Case "3"  '外购件
                BOMStructureType = kPurchasedBOMStructure
        End Select

        ' Set a reference to the BOM
        Dim oBOM As BOM
        oBOM = oAssemblyDocument.ComponentDefinition.BOM

        ' Set the structured view to 'all levels'
        oBOM.StructuredViewFirstLevelOnly = False

        ' Make sure that the structured view is enabled.
        oBOM.StructuredViewEnabled = True

        ' Set a reference to the "Structured" BOMView

        '获取结构化的bom页面
        For Each oBOMView As BOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kModelDataBOMViewType Then
                '遍历这个bom页面
                SetPhantomBOMStructuretSub(oBOMView.BOMRows, BOMStructureType)
            End If
        Next
        Return True
    End Function

    '设置当前部件下级为虚拟件,遍历子程序
    Public Sub SetPhantomBOMStructuretSub(ByVal oBOMRows As BOMRowsEnumerator, ByVal BOMStructureType As BOMStructureEnum)
        Dim i As Long

        For i = 1 To oBOMRows.Count
            Dim oBOMRow As BOMRow
            oBOMRow = oBOMRows.Item(i)

            Dim oComponentDefinition As ComponentDefinition
            oComponentDefinition = oBOMRow.ComponentDefinitions.Item(1)

            Debug.Print(oComponentDefinition.Document.FullFileName)

            If InStr(oComponentDefinition.Document.FullFileName, ContentCenterFiles) > 0 Then         '跳过零件库文件
                Continue For
            End If


            ''      遍历下一级
            'If Not oBOMRow.ChildRows Is Nothing Then
            '    Call SetPhantomBOMStructuretSub(oBOMRow.ChildRows, BOMStructureType)
            'End If

            '跳过参考件
            If oBOMRow.BOMStructure <> kInseparableBOMStructure Then
                oBOMRow.BOMStructure = BOMStructureType
            End If
        Next

    End Sub

    '在尺寸前添加φ
    Public Function AddFai(ByVal oInventorDocument As Inventor.Document) As Boolean
        Dim oLinearGeneralDimension As LinearGeneralDimension    '选择的部件或零件

        Dim strDimension As String
        Dim strFai As String

        ' 是否已经选择了尺寸
        If oInventorDocument.SelectSet.Count <> 0 Then
            For Each oSelect As Object In oInventorDocument.SelectSet
                If oSelect.Type = ObjectTypeEnum.kLinearGeneralDimensionObject Then

                    '添加Φ，内部代号n
                    strFai = "<StyleOverride Font='AIGDT'>n</StyleOverride>"
                    strDimension = strFai & "<DimensionValue/>"
                    oSelect.Text.FormattedText = strDimension
                End If
            Next
        Else
            oLinearGeneralDimension = ThisApplication.CommandManager.Pick(kDrawingDefaultFilter, "选择要添加Φ的尺寸")
            If oLinearGeneralDimension Is Nothing Then       '取消选择
                Return True
                Exit Function
            End If

            strFai = "<StyleOverride Font='AIGDT'>n</StyleOverride>"
            strDimension = strFai & "<DimensionValue/>"
            oLinearGeneralDimension.Text.FormattedText = strDimension

        End If
        Return True

    End Function

    '检查模型是否有对应的工程图
    Public Function CheckIsInvHaveIdw(ByVal oAssemblyDocument As Inventor.AssemblyDocument, ByVal StrInName As String) As Boolean
        ' Set a reference to the BOM
        Dim oBOM As BOM
        oBOM = oAssemblyDocument.ComponentDefinition.BOM

        ' Set the structured view to 'all levels'
        oBOM.StructuredViewFirstLevelOnly = False

        ' Make sure that the structured view is enabled.
        oBOM.StructuredViewEnabled = True

        ' Set a reference to the "Structured" BOMView

        '获取结构化的bom页面
        For Each oBOMView As BOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                '遍历这个bom页面
                CheckIsInvHaveIdwSub(oBOMView.BOMRows, StrInName)
            End If
        Next
        Return True

    End Function

    '检查模型是否有对应的工程图
    Public Sub CheckIsInvHaveIdwSub(ByVal oBOMRows As BOMRowsEnumerator, ByVal strInName As String)
        Dim i As Long

        For i = 1 To oBOMRows.Count
            Dim oRow As BOMRow
            oRow = oBOMRows.Item(i)

            Dim oComponentDefinition As ComponentDefinition
            oComponentDefinition = oRow.ComponentDefinitions.Item(1)

            Debug.Print(oComponentDefinition.Document.FullFileName)

            Dim strInventorFullFileName As String   '模型文件


            strInventorFullFileName = oComponentDefinition.Document.FullFileName

            If IsFileExsts(strInventorFullFileName) = False Then   '跳过不存在的文件
                Continue For
            End If

            If InStr(strInventorFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                Continue For
            End If

            '检查收否含有指定的字符串
            If InStr(Strings.LCase(strInventorFullFileName), Strings.LCase(strInName)) = 0 Then
                Continue For
            End If

            Dim strDrawingFullFileName As String  '工程图全文件名
            strDrawingFullFileName = Strings.Replace(strInventorFullFileName, LCaseGetFileExtension(strInventorFullFileName), IDW)

            If IsFileExsts(strDrawingFullFileName) = False Then
                ThisApplication.Documents.Open(strInventorFullFileName)
            End If

            '      遍历下一级
            If Not oRow.ChildRows Is Nothing Then
                Call CheckIsInvHaveIdwSub(oRow.ChildRows, StrInName)
            End If

        Next

    End Sub

    '打开部件中所有子集对应的工程图 ，部件文件，指定的图号
    Public Function OpenAllDrwInAsm(ByVal oAssemblyDocument As Inventor.AssemblyDocument, ByVal strStockNum As String) As Boolean
        ' Set a reference to the BOM
        Dim oBOM As BOM
        oBOM = oAssemblyDocument.ComponentDefinition.BOM

        ' Set the structured view to 'all levels'
        oBOM.StructuredViewFirstLevelOnly = False

        ' Make sure that the structured view is enabled.
        oBOM.StructuredViewEnabled = True

        ' Set a reference to the "Structured" BOMView
        Dim oBOMView As BOMView

        '获取结构化的bom页面
        For Each oBOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                '遍历这个bom页面
                OpenAllDrwInAsmSub(oBOMView.BOMRows, strStockNum)
            End If
        Next
        Return True

    End Function

    '打开部件中所有子集对应的工程图
    Public Sub OpenAllDrwInAsmSub(ByVal oBOMRows As BOMRowsEnumerator, ByVal strStockNum As String)
        Dim i As Long

        For i = 1 To oBOMRows.Count
            Dim oBOMRow As BOMRow
            oBOMRow = oBOMRows.Item(i)

            Dim oComponentDefinition As ComponentDefinition
            oComponentDefinition = oBOMRow.ComponentDefinitions.Item(1)

            Debug.Print(oComponentDefinition.Document.FullFileName)

            Dim strInventorFullFileName As String   '模型文件

            strInventorFullFileName = oComponentDefinition.Document.FullFileName

            If IsFileExsts(strInventorFullFileName) = False Then   '跳过不存在的文件
                Continue For
            End If

            If InStr(strInventorFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                Continue For
            End If

            Dim strDrawingFullFileName As String  '工程图全文件名
            '获取对应工程图文件名
            strDrawingFullFileName = Strings.Replace(strInventorFullFileName, LCaseGetFileExtension(strInventorFullFileName), IDW)

            Select Case strStockNum
                Case ""     '打开全部
                    '存在对于工程图，打开它
                    If IsFileExsts(strDrawingFullFileName) = True Then
                        ThisApplication.Documents.Open(strDrawingFullFileName)
                    End If
                Case Else   '打开指定图号
                    If Strings.InStr(Strings.LCase(GetFileNameInfo(strInventorFullFileName).OnlyName), Strings.LCase(strStockNum)) = 0 Then
                        Exit Select
                    End If

                    If IsFileExsts(strDrawingFullFileName) = True Then
                        ThisApplication.Documents.Open(strDrawingFullFileName)
                    End If

            End Select

            '遍历下一级
            If Not oBOMRow.ChildRows Is Nothing Then
                Call OpenAllDrwInAsmSub(oBOMRow.ChildRows, strStockNum)
            End If

        Next

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
        strDrawingFullFileName = Strings.Replace(strInventorFullFileName, LCaseGetFileExtension(strInventorFullFileName), IDW)

        ''当前文件夹查询没有就 到父文件夹查询
        'If IsFileExsts(strDrawingFullFileName) = False Then
        '    SearchDrawingDocumentInPresentFolder(oInventorDocument, 3)
        'End If


        '查询到工程图
        If IsFileExsts(strDrawingFullFileName) Then
            ThisApplication.Documents.Open(strDrawingFullFileName)
        Else
            strDrawingFullFileName = SearchDrawingDocumentInPresentFolder(oInventorDocument, 3)
            If strDrawingFullFileName = "NULL" Then
                MsgBox(strInventorFullFileName & "没有对应的工程图。", MsgBoxStyle.Information, "打开工程图")
            Else
                ThisApplication.Documents.Open(strDrawingFullFileName)
            End If
        End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub

    '到父文件夹查询工程图  ，inventor 文档 ，向上查询的层级
    Public Function SearchDrawingDocumentInPresentFolder(ByVal oInventorDocument As Inventor.Document, ByVal intPresidentLevel As Integer) As String
        On Error Resume Next

        Dim strPrsentFolder As String   '父文件夹
        Dim strInventorFullFileName As String   '模型文件全名
        Dim strInventorFileName As String   '模型文件名
        'Dim strDrawingFullFileName As String  '工程图全文件名
        Dim strDrawingFileName As String '工程图名
        Dim i As Integer

        strInventorFullFileName = oInventorDocument.FullDocumentName
        strInventorFileName = GetFileNameInfo(strInventorFullFileName).SigleName

        strDrawingFileName = GetFileNameInfo(strInventorFullFileName).OnlyName + IDW

        i = 0

        strPrsentFolder = System.IO.Directory.GetParent(strInventorFullFileName).FullName
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



    '-------------------------------------------------------------------------------------------------------
    '批量替换部件下子集的名字
    ' 组件，被替换的文件名，替换的文件名
    Public Function ReplaceNameInAsm(ByVal oAssemblyDocument As Inventor.AssemblyDocument, ByVal strOldName As String, ByVal strNewName As String, _
                                     ByVal IsSaveAsOld As MsgBoxResult) As Boolean

        Dim strTempFullFileName As String       '更改旧模型文件的名字存档

        For Each oInventorDocument As Inventor.Document In oAssemblyDocument.ReferencedDocuments
            Dim strOldFullFileName As String   '被替换的旧文件全名
            Dim strOldFileName As String   '被替换的旧文件仅文件名

            Dim strNewFullFileName As String   '新文件全名
            Dim strNewFileName As String   '新文件名

            'InventorDoc = ThisApplication.Documents.ItemByName(OldFullFileName)

            strOldFullFileName = oInventorDocument.FullDocumentName

            If IsFileExsts(strOldFullFileName) = False Then   '跳过不存在的文件
                Continue For
            End If

            If InStr(strOldFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                Continue For
            End If

            strOldFileName = GetFileNameInfo(strOldFullFileName).SigleName

            '替换旧文件全名为新文件全名
            If InStr(strOldFileName, strOldName) Then
                strNewFileName = Replace(strOldFileName, strOldName, strNewName)
                strNewFullFileName = GetFileNameInfo(strOldFullFileName).Folder & "\" & strNewFileName

                '打开旧文件,不显示
                Dim OldInventorDocument As Inventor.Document
                OldInventorDocument = ThisApplication.Documents.Open(strOldFullFileName, False)

                '另存为新文件
                OldInventorDocument.SaveAs(strNewFullFileName, False)

                '关闭旧图
                OldInventorDocument.Close()

                '后台打开文件，修改ipro
                Dim oNewInventorDocument As Inventor.Document
                oNewInventorDocument = ThisApplication.Documents.Open(strNewFullFileName, False)  '打开文件，不显示
                SetDocumentIpropertyFromFileName(oNewInventorDocument, True) '设置Iproperty，打开文件后需关闭

                Dim oCO As Inventor.ComponentOccurrences
                oCO = oAssemblyDocument.ComponentDefinition.Occurrences

                '全部替换为新文件
                For Each ooCO As ComponentOccurrence In oCO
                    If ooCO.ReferencedDocumentDescriptor.FullDocumentName = strOldFullFileName Then
                        ooCO.Replace(strNewFullFileName, True)
                        Exit For
                    End If
                Next

                '是否有对应的工程图文件，同时复制后修改文件名和模型链接
                Dim oOldIdwFullFileName As String
                oOldIdwFullFileName = GetNewExtensionFileName(strOldFullFileName, IDW)   '旧工程图

                'Dim TempFullFileName As String       '更改旧模型文件的名字存档

                If IsFileExsts(oOldIdwFullFileName) = True Then
                    Dim oNewIdwFullFileName As String
                    oNewIdwFullFileName = GetNewExtensionFileName(strNewFullFileName, IDW)   '新工程图
                    FileSystem.FileCopy(oOldIdwFullFileName, oNewIdwFullFileName)             '复制为新工程图

                    'MsgBox("找到有对应的旧工程图，生成新的工程图，将打开，请链接到文件：" & vbCrLf & NewFullFileName & vbCrLf & "该文件名已复制，粘贴到对话框即可。", MsgBoxStyle.Information)
                    'Windows.Forms.Clipboard.SetText(NewFullFileName)
                    'ThisApplication.Documents.Open(NewIdwFullFileName, False)      '打开新的工程图，使其手动链接零件或部件
                    'ThisApplication.Documents.ItemByName(NewIdwFullFileName).Save2() '保存链接并关闭工程图
                    'ThisApplication.Documents.ItemByName(NewIdwFullFileName).Close()

                    oInventorDocument = ThisApplication.Documents.Open(oNewIdwFullFileName, False)  '打开文件，不显示
                    oInventorDocument.ReferencedDocumentDescriptors(1).ReferencedFileDescriptor.ReplaceReference(strNewFullFileName)
                    oInventorDocument.Save2()
                    oInventorDocument.Close()

                    If IsSaveAsOld = MsgBoxResult.Yes Then
                        strTempFullFileName = oOldIdwFullFileName & OLD  '暂时更改旧工程图文件的名字存档
                        ReFileName(oOldIdwFullFileName, strTempFullFileName)
                        'ReFileName(TempFullFileName, OldFullFileName)   '恢复旧零件或部件文件名
                    End If
                End If

                If IsSaveAsOld = MsgBoxResult.Yes Then
                    strTempFullFileName = strOldFullFileName & OLD  '暂时更改旧工程图文件的名字存档
                    ReFileName(strOldFullFileName, strTempFullFileName)
                End If

                '是部件的遍历新文件的子集
                oNewInventorDocument = ThisApplication.Documents.Open(strNewFullFileName, False)
                If oNewInventorDocument.DocumentType = kAssemblyDocumentObject Then
                    ReplaceNameInAsm(oNewInventorDocument, strOldName, strNewName, IsSaveAsOld)
                End If
                oNewInventorDocument.Close(True)

            End If
        Next

        Return True

    End Function

    '导出 bom 平面性
    Public Function ExportBOMAsFlat(ByVal oAssemblyDocument As Inventor.AssemblyDocument, ByVal strCsvFullFileName As String) As Boolean
        Dim FirstLevelOnly As Boolean

        FirstLevelOnly = False

        '==============================================================================================
        '基于bom结构化数据，可跳过参考的文件
        ' Set a reference to the BOM
        Dim oBOM As BOM
        oBOM = oAssemblyDocument.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True
        oBOM.StructuredViewFirstLevelOnly = False

        'Set a reference to the "Structured" BOMView
        Dim oBOMView As BOMView

        'Dim ColumnsTitle As String
        'ColumnsTitle = "库存编号|空格|零件代号|材料|质量|所属装配代号|数量|总数量|描述"

        Dim oStreamWriter As System.IO.StreamWriter
        If IsFileExsts(strCsvFullFileName) = False Then
            oStreamWriter = New IO.StreamWriter(strCsvFullFileName, False, System.Text.Encoding.Default)
        Else
            oStreamWriter = New IO.StreamWriter(strCsvFullFileName, True, System.Text.Encoding.Default)
        End If

        '写BOM表头
        Dim strColumnsTitle As String
        strColumnsTitle = "序号," & Strings.Replace(BOMTiTle, "|", ",")
        oStreamWriter.WriteLine(strColumnsTitle)
        oStreamWriter.Close()

        TotalItem = 1

        '获取结构化的bom页面
        For Each oBOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                '遍历这个bom页面
                QueryBOMRowPropertieToExcel(strCsvFullFileName, oBOMView.BOMRows, FirstLevelOnly, BOMTiTle, "0", 1)
            End If
        Next

        '转换excel文件格式
        '===========================================================================

        Dim strExcelFullFileName As String
        strExcelFullFileName = Strings.Replace(strCsvFullFileName, "csv", "xlsx")

        If IsFileExsts(strExcelFullFileName) Then
            DelFile(strExcelFullFileName, FileIO.RecycleOption.SendToRecycleBin)
        End If

        Dim oExcelApplication As Excel.Application
        oExcelApplication = New Excel.Application
        oExcelApplication.Visible = False

        Dim oWorkbook As Excel.Workbook
        oWorkbook = oExcelApplication.Workbooks.Open(strCsvFullFileName)

        '另存为xlsx格式
        DelFile(strExcelFullFileName, FileIO.RecycleOption.SendToRecycleBin)
        oWorkbook.SaveAs(strExcelFullFileName, xlWorkbookDefault)
        oWorkbook.Close(False)
        '删除 csv
        DelFile(strCsvFullFileName, FileIO.RecycleOption.SendToRecycleBin)

        oWorkbook = oExcelApplication.Workbooks.Open(strExcelFullFileName)

        Dim oWorksheet As Excel.Worksheet
        oWorksheet = oWorkbook.Worksheets(1)

        '设边框线
        'oWorksheet.Cells.Borders.LineStyle = 1
        '所有单元格列宽自动调整
        oWorksheet.Cells.EntireColumn.AutoFit()
        '所有单元格行高自动调整
        oWorksheet.Cells.EntireRow.AutoFit()

        oWorkbook.Close(True)
        '===========================================================================

        oExcelApplication.Quit()

        System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcelApplication)

        MsgBox("BOM导出到文件：" & vbCrLf & strExcelFullFileName, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "导出BOM")

        Process.Start(strExcelFullFileName)

        Return True

    End Function

    '在 bom平面性导出，遍历bom 行文件ipro
    Private Sub QueryBOMRowPropertieToExcel(ByVal strCsvFullFileName As String, ByVal oBOMRows As BOMRowsEnumerator, _
                                            ByVal FirstLevelOnly As Boolean, ByVal strColumnsTitle As String, _
                                            ByVal strLevel As String, ByVal intPresentNumber As Integer)
        On Error Resume Next

        Dim i As Short
        Dim j As Short
        Dim iStepCount As Short
        iStepCount = oBOMRows.Count

        'Create a new ProgressBar object.
        'Dim oProgressBar As Inventor.ProgressBar

        'oProgressBar = ThisApplication.CreateProgressBar(False, iStepCount, "当前文件： ")

        '赋值数组
        Dim oBOMRowData(2000, 1) As String

        ReDim oBOMRowData(oBOMRows.Count - 1, 1)

        For i = 1 To oBOMRows.Count
            oBOMRowData(i - 1, 0) = oBOMRows.Item(i).ItemNumber
            oBOMRowData(i - 1, 1) = oBOMRows.Item(i).ReferencedFileDescriptor.FullFileName
        Next

        '冒泡排序()

        Dim strTemp As String  '不定义变量类型,以自动适应数组Ar的类型
        Dim Flag As Boolean
        Dim n As Integer = oBOMRowData.Length / oBOMRowData.Rank - 1

        For i = 0 To n
            Flag = False
            '从第1个元素开始,比较每两个相邻元素的大小,让大元素下沉,小元素上浮
            '经过一轮循环,可使数组中最大元素下沉到数组最底部
            '进入下一轮循环,只对前 n - i 个元素进行相邻比较(已排到后面的不用比较)
            For j = 0 To n - i - 1
                '按文件名排序
                If GetFileNameInfo(oBOMRowData(j, 1)).OnlyName > GetFileNameInfo(oBOMRowData(j + 1, 1)).OnlyName Then
                    strTemp = oBOMRowData(j, 0)
                    oBOMRowData(j, 0) = oBOMRowData(j + 1, 0)
                    oBOMRowData(j + 1, 0) = strTemp

                    strTemp = oBOMRowData(j, 1)
                    oBOMRowData(j, 1) = oBOMRowData(j + 1, 1)
                    oBOMRowData(j + 1, 1) = strTemp

                    Flag = True '如果有排序行为，则设为 True
                End If
            Next
            If Flag = False Then '如未排序,说明已完成整个排序过程,退出
                Exit For
            End If
        Next

        '循环每一行
        For i = 0 To n
            '文件指针
            Dim strFilePointItemNumber As String

            strFilePointItemNumber = oBOMRowData(i, 1)

            '寻找指针的行，开始提取数据



            For j = 1 To oBOMRows.Count
                Dim oBOMRow As BOMRow
                oBOMRow = oBOMRows.Item(j)
                Dim strInventorFullFileName As String
                strInventorFullFileName = oBOMRow.ReferencedFileDescriptor.FullFileName

                If strInventorFullFileName = strFilePointItemNumber Then
                    ' Set the message for the progress bar
                    'oProgressBar.Message = InventorDocFullFileName
                    If IsFileExsts(strInventorFullFileName) = False Then   '跳过不存在的文件
                        GoTo 999
                    End If

                    '数据操作
                    '========================================
                    '测试文件
                    'Debug.Print(ItemNumber & ":" & InventorDocFullFileName)

                    Dim oInventorDocument As Inventor.Document

                    oInventorDocument = ThisApplication.Documents.Open(strInventorFullFileName, False)

                    SetStatusBarText(strInventorFullFileName)

                    Dim oPropertySets As PropertySets
                    Dim oPropertySet As PropertySet
                    oPropertySets = oInventorDocument.PropertySets
                    oPropertySet = oPropertySets.Item(3)

                    Dim arrColumnsTitle() As String
                    Dim arrColumnsTitleValue() As String
                    arrColumnsTitle = Split(strColumnsTitle, "|")

                    ReDim arrColumnsTitleValue(arrColumnsTitle.Length)

                    'kPartNumberDesignTrackingProperties    零件代号
                    'kStockNumberDesignTrackingProperties   库存编号

                    Dim propitem As [Property]
                    For k = 0 To arrColumnsTitle.Length - 1 Step 1
                        Select Case arrColumnsTitle(k)
                            Case "空格"
                                arrColumnsTitleValue(k) = ""
                            Case Map_PartName
                                arrColumnsTitleValue(k) = GetPropitem(oInventorDocument, Map_PartName)
                            Case Map_DrawingNnumber
                                arrColumnsTitleValue(k) = GetPropitem(oInventorDocument, Map_DrawingNnumber)
                            Case Map_Describe
                                arrColumnsTitleValue(k) = GetPropitem(oInventorDocument, Map_Describe)
                            Case Map_ERPCode
                                arrColumnsTitleValue(k) = GetPropitem(oInventorDocument, Map_ERPCode)
                            Case "材料"
                                Dim strMaterialName As String
                                If oInventorDocument.DocumentType = kPartDocumentObject Then
                                    'Dim IptDoc As PartDocument
                                    'IptDoc = oInventorDocument
                                    'strMaterialName = IptDoc.ComponentDefinition.Material.Name
                                    propitem = oPropertySet.ItemByPropId(Inventor.PropertiesForDesignTrackingPropertiesEnum.kMaterialDesignTrackingProperties)
                                    strMaterialName = propitem.Value
                                Else
                                    strMaterialName = ""
                                End If
                                arrColumnsTitleValue(k) = strMaterialName

                       
                            Case "质量"
                                Dim strMass As String
                                strMass = GetMass(oInventorDocument)
                                arrColumnsTitleValue(k) = strMass
                            Case "面积"
                                Dim strArea As String
                                strArea = GetArea(oInventorDocument)
                                arrColumnsTitleValue(k) = strArea
                            Case "数量"
                                arrColumnsTitleValue(k) = oBOMRow.ItemQuantity.ToString
                            Case "所属装配"
                                Dim StockNumPartName As StockNumPartName
                                StockNumPartName = GetStockNumPartName(oBOMRow.ReferencedFileDescriptor.Parent.FullFileName)
                                arrColumnsTitleValue(k) = StockNumPartName.StockNum & StockNumPartName.PartName
                            Case "所属装配代号"
                                Dim StockNumPartName As StockNumPartName
                                StockNumPartName = GetStockNumPartName(oBOMRow.ReferencedFileDescriptor.Parent.FullFileName)
                                arrColumnsTitleValue(k) = StockNumPartName.StockNum

                            Case "总数量"
                                arrColumnsTitleValue(k) = (oBOMRow.ItemQuantity * intPresentNumber).ToString

                            Case "缩略图"
                                'propitem = oPropSet.ItemByPropId(Inventor.PropertiesForDesignTrackingPropertiesEnum.kPartIconDesignTrackingProperties)
                                'Array_ColumnsTitleValue(k) = propitem.Value

                                'Case Map_Vendor

                                '    arrColumnsTitleValue(k) = GetPropitem(oInventorDocument, Map_Vendor)

                                'propitem = oPropertySet.ItemByPropId(Inventor.PropertiesForDesignTrackingPropertiesEnum.kVendorDesignTrackingProperties)
                                'arrColumnsTitleValue(k) = propitem.Value

                        End Select
                        arrColumnsTitleValue(k) = Strings.Replace(arrColumnsTitleValue(k), ",", "，")
                    Next k

                    oInventorDocument.Close(False)

                    Select Case oInventorDocument.DocumentType
                        Case kAssemblyDocumentObject
                            Threading.Thread.Sleep(500)
                        Case kPartDocumentObject
                            Threading.Thread.Sleep(200)
                    End Select

                    '集合数组数据
                    Dim strColumnsTitleValue As String
                    strColumnsTitleValue = TotalItem & "," & Join(arrColumnsTitleValue, ",")
                    TotalItem = TotalItem + 1

                    '测试数据
                    'Debug.Print(ColumnsTitleValue)

                    '写数据到文件
                    Dim IOS As System.IO.StreamWriter
                    If IsFileExsts(strCsvFullFileName) = False Then
                        IOS = New IO.StreamWriter(strCsvFullFileName, False, System.Text.Encoding.Default)
                    Else
                        IOS = New IO.StreamWriter(strCsvFullFileName, True, System.Text.Encoding.Default)
                    End If
                    IOS.WriteLine(strColumnsTitleValue)
                    IOS.Close()

                    '==========================================

999:
                    'oProgressBar.UpdateProgress()
                    Exit For
                End If

            Next j

        Next i

        'Debug.Print("==================================")
        '写数据到文件

        Dim oStreamWriter As System.IO.StreamWriter
        If IsFileExsts(strCsvFullFileName) = False Then
            oStreamWriter = New IO.StreamWriter(strCsvFullFileName, False, System.Text.Encoding.Default)
        Else
            oStreamWriter = New IO.StreamWriter(strCsvFullFileName, True, System.Text.Encoding.Default)
        End If
        '写空白行
        oStreamWriter.WriteLine("")
        oStreamWriter.Close()

        'For i = 1 To oBOMRows.Count
        '    ' Get the current row.
        '    Dim PointItemNumber As String

        '    If Level = "0" Then
        '        PointItemNumber = i
        '    Else
        '        PointItemNumber = Level & "." & i
        '    End If

        '            For j = 1 To oBOMRows.Count
        '                Dim oRow As BOMRow
        '                oRow = oBOMRows.Item(j)
        '                Dim ItemNumber As String
        '                ItemNumber = oRow.ItemNumber
        '                Dim DocFullFileName As String
        '                DocFullFileName = oRow.ReferencedFileDescriptor.FullFileName

        '                If ItemNumber = PointItemNumber Then
        '                    '测试文件
        '                    'Debug.Print(ItemNumber & ":" & DocFullFileName)
        '                    ' Set the message for the progress bar
        '                    'oProgressBar.Message = DocFullFileName
        '                    If IsFileExsts(DocFullFileName) = False Then   '跳过不存在的文件
        '                        GoTo 99
        '                    End If

        '                    '数据操作
        '                    '========================================

        '                    '==========================================

        '                    '遍历下一级
        '                    If (Not oRow.ChildRows Is Nothing) And FirstLevelOnly = False Then
        '                        Call QueryBOMRowPropertieToExcel(oCsv_File_Name, oRow.ChildRows, FirstLevelOnly, ColumnsTitle, PointItemNumber, oRow.ItemQuantity)
        '                    End If
        '99:
        '                    'oProgressBar.UpdateProgress()
        '                    Exit For
        '                End If

        '            Next j

        '        Next i

        For i = 0 To oBOMRowData.Length / 2 - 1
            For j = 1 To oBOMRows.Count
                Dim oBOMRow As BOMRow
                oBOMRow = oBOMRows.Item(j)
                Dim strItemNumber As String
                strItemNumber = oBOMRow.ItemNumber
                Dim strFullFileName As String
                strFullFileName = oBOMRow.ReferencedFileDescriptor.FullFileName

                If oBOMRowData(i, 1) = strFullFileName Then
                    '测试文件
                    'Debug.Print(ItemNumber & ":" & DocFullFileName)
                    ' Set the message for the progress bar
                    'oProgressBar.Message = DocFullFileName
                    'If IsFileExsts(DocFullFileName) = False Then   '跳过不存在的文件
                    '    GoTo 99
                    'End If

                    '数据操作
                    '========================================

                    '==========================================

                    '遍历下一级
                    If (Not oBOMRow.ChildRows Is Nothing) And FirstLevelOnly = False Then

                        '检查为自制件就展开子级
                        Dim strVendor As String

                        Dim oInventorDocument As Inventor.Document
                        oInventorDocument = ThisApplication.Documents.Open(strFullFileName, False)
                        strVendor = GetPropitem(oInventorDocument, Map_Vendor)

                        If strVendor = "自制件" Or strVendor = "" Then
                            Call QueryBOMRowPropertieToExcel(strCsvFullFileName, oBOMRow.ChildRows, FirstLevelOnly, strColumnsTitle, 0, oBOMRow.ItemQuantity * intPresentNumber)
                        End If


                    End If
99:
                    'oProgressBar.UpdateProgress()
                    Exit For
                End If

            Next j


        Next i

88:

        'oProgressBar.Close()

    End Sub

    '保存文件时的事件
    'Public Sub ThisApplicationEvents_OnOnSaveDocument(ByVal DocumentObject As Inventor._Document, _
    '                                                ByVal BeforeOrAfter As Inventor.EventTimingEnum, _
    '                                                 ByVal Context As Inventor.NameValueMap, _
    '                                                 ByRef HandlingCode As Inventor.HandlingCodeEnum) Handles ThisApplicationEvents.OnSaveDocument

    'End Sub

    '打开文件时的事件
    'Public Sub ThisApplicationEvents_OnOpenDocument(ByVal oInventorDocument As Inventor.Document, _
    '                                ByVal FullDocumentName As String, _
    '                               ByVal BeforeOrAfter As Inventor.EventTimingEnum, _
    '                              ByVal Context As Inventor.NameValueMap, _
    '                              ByRef HandlingCode As Inventor.HandlingCodeEnum) Handles ThisApplicationEvents.OnOpenDocument
    '    '当打开文件为工程图
    '    If oInventorDocument.DocumentType = kDrawingDocumentObject Then
    '        '写入主视图比例
    '        'If IsSetDrawingScale = 1 Then
    '        SetDrawingScale(oInventorDocument)
    '        'End If

    '        '写入零部件质量
    '        'If IsSetMass = 1 Then
    '        SetMass(oInventorDocument)
    '        'End If
    '    End If
    'End Sub

    '激活一个文档时的事件
    Public Sub ThisApplicationEvents_OnActivateDocument(ByVal oInventorDocument As Inventor.Document, _
                                                        ByVal BeforeOrAfter As Inventor.EventTimingEnum, _
                                                        ByVal Context As Inventor.NameValueMap, _
                                                        ByRef HandlingCode As Inventor.HandlingCodeEnum) Handles ThisApplicationEvents.OnActivateDocument
        '当打开文件为工程图
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

    '刷新引用
    Public Function RefreshShowName(ByVal oAssemblyDocument As Inventor.AssemblyDocument) As Boolean

        ' 获取装配定义
        Dim oAssemblyComponentDefinition As AssemblyComponentDefinition
        oAssemblyComponentDefinition = oAssemblyDocument.ComponentDefinition

        Dim strShortName1 As String
        Dim strShortName2 As String
        Dim strNumName As String
        Dim i As Integer
        For Each oOcc In oAssemblyComponentDefinition.Occurrences

            If InStr(oOcc.ReferencedDocumentDescriptor.FullDocumentName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                GoTo 999
            End If

            Debug.Print(oOcc.Name)
            Debug.Print(oOcc.ReferencedDocumentDescriptor.FullDocumentName)

            i = InStr(oOcc.Name, ":")
            strShortName1 = Strings.Left(oOcc.Name, i - 1)
            strNumName = Strings.Right(oOcc.Name, Len(oOcc.Name) - i + 1)
            strShortName2 = GetFileNameInfo(oOcc.ReferencedDocumentDescriptor.FullDocumentName).OnlyName
            If strShortName1 <> strShortName2 Then
                oOcc.Name = strShortName2 & strNumName
            End If
999:
        Next
        Return True
    End Function

    '对齐XYZ平面
    Public Function FlushXYZPlane() As Boolean

        Dim InventorDocument As Inventor.Document
        InventorDocument = ThisApplication.ActiveDocument

        Dim oAsmCompDef As AssemblyComponentDefinition
        oAsmCompDef = InventorDocument.ComponentDefinition

        ' Get references to the two occurrences to constrain.
        ' This arbitrarily gets the first and second occurrence.
        Dim oComponentOccurrence1 As ComponentOccurrence
        oComponentOccurrence1 = ThisApplication.CommandManager.Pick(kAssemblyLeafOccurrenceFilter, "选择第一个部件或零件")

        If oComponentOccurrence1 Is Nothing Then       '取消选择
            Exit Function
        End If

        Dim oComponentOccurrence2 As ComponentOccurrence
        oComponentOccurrence2 = ThisApplication.CommandManager.Pick(kAssemblyLeafOccurrenceFilter, "选择第二个部件或零件")

        If oComponentOccurrence2 Is Nothing Then       '取消选择
            Exit Function
        End If

        ' Get the XY plane from each occurrence.  This goes to the
        ' component definition of the part to get this information.
        ' This is the same as accessing the part document directly.
        ' The work plane obtained is in the context of the part,
        ' not the assembly.

        For i = 1 To 3
            Dim oPartPlane1 As WorkPlane
            oPartPlane1 = oComponentOccurrence1.Definition.WorkPlanes.Item(i)

            Dim oPartPlane2 As WorkPlane
            oPartPlane2 = oComponentOccurrence2.Definition.WorkPlanes.Item(i)

            ' Because we need the work plane in the context of the assembly
            ' we need to create proxies for the work planes.  The proxies
            ' represent the work planes in the context of the assembly.
            Dim oAsmPlane1 As WorkPlaneProxy = Nothing
            oComponentOccurrence1.CreateGeometryProxy(oPartPlane1, oAsmPlane1)

            Dim oAsmPlane2 As WorkPlaneProxy = Nothing
            oComponentOccurrence2.CreateGeometryProxy(oPartPlane2, oAsmPlane2)

            ' Create the constraint using the work plane proxies.
            Dim oMate As FlushConstraint

            oMate = oAsmCompDef.Constraints.AddFlushConstraint(oAsmPlane1, oAsmPlane2, 0)
        Next

        Return True
    End Function

    '获取未读取的文件所在部件并打开该部件   （ 部件文件对象 ； 文件是否需打开，打开的文件用后要关闭）
    Public Function GetUnkonwDocumentWithBOM(ByVal oAssemblyDocument As Inventor.AssemblyDocument, ByVal IsNeedClose As Boolean) As Boolean
        ' 获取所有引用文档
        Dim FirstLevelOnly As Boolean
        FirstLevelOnly = False

        '==============================================================================================
        '基于bom结构化数据，可跳过参考的文件
        ' Set a reference to the BOM
        Dim oBOM As BOM
        oBOM = oAssemblyDocument.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True

        'Set a reference to the "Structured" BOMView
        Dim oBOMView As BOMView

        '获取结构化的bom页面
        For Each oBOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kModelDataBOMViewType Then
                '遍历这个bom页面
                QueryBOMRowToOpenUnkonwDocument(oBOMView.BOMRows, FirstLevelOnly)
            End If
        Next
        '==============================================================================================
        Return True
    End Function

    '遍历BOM结构，获取未读取的文件所在部件并打开该部件
    Public Sub QueryBOMRowToOpenUnkonwDocument(ByVal oBOMRows As Inventor.BOMRowsEnumerator, ByVal FirstLevelOnly As Boolean)
        Dim i As Integer

        Dim intStepCount As Integer

        'Dim oBOMRows As BOMRowsEnumerator
        'oBOMRows = oBOM.oBOMView.BOMRows

        intStepCount = oBOMRows.Count

        'Create a new ProgressBar object.
        'Dim oProgressBar As Inventor.ProgressBar

        'oProgressBar = ThisApplication.CreateProgressBar(False, iStepCount, "当前文件： ")

        For i = 1 To oBOMRows.Count
            ' Get the current row.
            Dim oBOMRow As BOMRow
            oBOMRow = oBOMRows.Item(i)

            Dim strFullFileName As String

            strFullFileName = oBOMRow.ReferencedFileDescriptor.FullFileName

            '测试文件
            Debug.Print(strFullFileName)

            ' Set the message for the progress bar
            'oProgressBar.Message = FullFileName
            'If InStr(FullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
            '    GoTo 999
            'End If

            '文件不存在，就打开父级文件
            If IsFileExsts(strFullFileName) = False Then
                Dim oInventorDocument As Inventor.Document
                '父级文件名
                strFullFileName = oBOMRow.ReferencedFileDescriptor.Parent.FullFileName
                oInventorDocument = ThisApplication.Documents.Open(strFullFileName, True)  '打开文件，显示

            End If

            '遍历下一级
            If (Not oBOMRow.ChildRows Is Nothing) And FirstLevelOnly = False Then
                Call QueryBOMRowToOpenUnkonwDocument(oBOMRow.ChildRows, FirstLevelOnly)
            End If
999:
            'oProgressBar.UpdateProgress()
        Next

        'oProgressBar.Close()

    End Sub

    '尺寸精度圆整
    Public Function SetDrawingDimPrecision() As Boolean
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Function
            End If

            If ThisApplication.ActiveDocument.DocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图", MsgBoxStyle.Information)
                Exit Function
            End If

            Dim oDrawingDocument As Inventor.DrawingDocument
            oDrawingDocument = ThisApplication.ActiveDocument

            Dim oLinearGeneralDimension As LinearGeneralDimension    '选择的部件或零件

            ' 是否已经选择了尺寸
            If oDrawingDocument.SelectSet.Count <> 0 Then
                For Each oSelectSet As Object In oDrawingDocument.SelectSet
                    If oSelectSet.Type = ObjectTypeEnum.kLinearGeneralDimensionObject Then
                        oSelectSet.Precision = 0
                    End If
                Next
            Else
                oLinearGeneralDimension = ThisApplication.CommandManager.Pick(kDrawingDefaultFilter, "选择要添加Φ的尺寸")
                If oLinearGeneralDimension Is Nothing Then       '取消选择
                    Return True
                    Exit Function
                End If
                oLinearGeneralDimension.Precision = 0

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function


    '设置当前部件下级为虚拟件
    Public Function SetVendor(ByVal oInventorDocument As Inventor.Document) As Boolean
        '设置结构类型

        Dim strVendor As String
        strVendor = GetPropitem(oInventorDocument, Map_Vendor)

        Dim strVendorType As String
        strVendorType = InputBox("将本零部件采购来源。输入要设置的类型：" & vbCrLf & vbCrLf & _
                                       "1——自制件" & vbCrLf & vbCrLf & _
                                       "2——外协件" & vbCrLf & vbCrLf & _
                                        "3——外购件" & vbCrLf & vbCrLf & _
                                            "4——标准件" & vbCrLf & vbCrLf, "设置采购来源", strVendor)

        Select Case strVendorType
            Case ""
                Return True
            Case "1"
                strVendor = "自制件"
            Case "2"
                strVendor = "外协件"
            Case "3"
                strVendor = "外购件"
            Case "4"
                strVendor = "标准件"
        End Select

        SetPropitem(oInventorDocument, Map_Vendor, strVendor)

        Return True
    End Function
End Module