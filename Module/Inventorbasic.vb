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
Imports System.DateTime
Imports System.Environment
Imports System.Collections.Generic


Module InventorBasic

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
            WorkSpaceFloder = ThisApplication.DesignProjectManager.ActiveDesignProject.WorkspacePath

            Dim strFileName As String
            strFileName = InputBox("查询文件夹：" & WorkSpaceFloder & vbCrLf & vbCrLf & "输入文件名")

            If strFileName = "" Then
                Exit Sub
            End If

            Dim strSearchFileName As String
            Dim strExtension As String

            If Strings.InStr(strFileName, ".") = 0 Then
                strSearchFileName = strFileName
                strExtension = ""
            Else
                Dim arraystrName As String() = Strings.Split(strFileName, ".")
                strSearchFileName = arraystrName(0)
                strExtension = "." & arraystrName(1)
            End If

            Dim arrayFullFileName As List(Of String)
            arrayFullFileName = FindFileInFolder(WorkSpaceFloder, strSearchFileName, strExtension)

            If arrayFullFileName.Count = 0 Then
                MsgBox("未找到文件：" & strFileName, MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim strFullFileName As String = Nothing

            Dim frmQuitOpen As New frmQuitOpen
            frmQuitOpen.lvw文件列表.CheckBoxes = True
            frmQuitOpen.btn多选打开.Visible = True

            For Each strFullFileName In arrayFullFileName
                If Strings.InStr(strFullFileName, "OldVersions") = 0 Then
                    frmQuitOpen.lvw文件列表.Items.Add(strFullFileName)
                End If
            Next

            Select Case frmQuitOpen.lvw文件列表.Items.Count
                Case 0

                Case 1
                    strQuitOpenSelectFileFullName = strFullFileName

                    Dim strFileExtensionName As String = Nothing
                    strFileExtensionName = LCase(GetFileNameInfo(strQuitOpenSelectFileFullName).ExtensionName)

                    Select Case strFileExtensionName
                        Case IAM, IPT, IDW
                            str模型匹配检查标记 = 1
                            ThisApplication.Documents.Open(strQuitOpenSelectFileFullName)
                        Case Else
                            Process.Start(strQuitOpenSelectFileFullName)
                    End Select


                Case Else
                    frmQuitOpen.ShowDialog()

                    Dim strFileExtensionName As String = Nothing
                    strFileExtensionName = LCase(GetFileNameInfo(strQuitOpenSelectFileFullName).ExtensionName)

                    Select Case strFileExtensionName
                        Case IAM, IPT, IDW
                            str模型匹配检查标记 = 1
                            ThisApplication.Documents.Open(strQuitOpenSelectFileFullName)
                        Case Else
                            Process.Start(strQuitOpenSelectFileFullName)
                    End Select

                    frmQuitOpen.Close()
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


            Select Case ThisApplication.ActiveDocumentType
                Case kDrawingDocumentObject    '工程图
                    Dim strDocumentFullName As String
                    strDocumentFullName = ThisApplication.ActiveDocument.FullDocumentName
                    If IsFileExsts(strDocumentFullName) = True Then    '工程图已存在
                        With ThisApplication.ActiveDocument
                            .Save2(True)
                            .Close()
                        End With
                    Else
                        Dim oInventorDrawingDocument As Inventor.DrawingDocument
                        oInventorDrawingDocument = ThisApplication.ActiveDocument

                        For Each oReferencedDocument In oInventorDrawingDocument.ReferencedDocumentDescriptors
                            If IsFileExsts(oReferencedDocument.FullDocumentName) = True Then


                                Dim strFilter As String = "Inventor 工程图文件(*.idw)|*.idw" '添加过滤文件
                                Dim strInitialDirectory As String = GetDirectoryName2(oReferencedDocument.FullDocumentName)

                                Dim arrayFullFileName As List(Of String)
                                arrayFullFileName = OpenFileDialog(strFilter, False, strInitialDirectory)

                                If arrayFullFileName Is Nothing Then
                                    Exit Sub
                                End If

                                Dim strNewFullFileName As String
                                strNewFullFileName = arrayFullFileName.Item(0).ToString

                                oInventorDrawingDocument.SaveAs(strNewFullFileName, False)
                                oInventorDrawingDocument.Save2()

                                'Dim oSaveFileDialog As New SaveFileDialog  '声名新open 窗口
                                'With oSaveFileDialog
                                '    .Title = "保存"
                                '    .Filter = "Inventor 工程图文件(*.idw)|*.idw" '添加过滤文件
                                '    .AddExtension = True
                                '    .CheckPathExists = True
                                '    .InitialDirectory = GetDirectoryName2(oReferencedDocument.FullDocumentName)
                                '    .FileName = GetFileNameInfo(oReferencedDocument.FullDocumentName).OnlyName
                                '    If .ShowDialog = System.Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                                '        Dim strNewFullFileName As String

                                '        strNewFullFileName = .FileName
                                '        oInventorDrawingDocument.SaveAs(strNewFullFileName, False)
                                '        oInventorDrawingDocument.Save2()

                                '    End If

                                'End With
                            End If
                        Next
                    End If

                Case Else   '非工程图
                    With ThisApplication.ActiveDocument
                        .Save2(True)
                        .Close()
                    End With
            End Select

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
            oInventorDocument.Close(True)
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

            Dim strFolderPath As String
            strFolderPath = GetDirectoryName2(oInventorDocument.FullDocumentName)

            Process.Start(strFolderPath)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '还原旧图
    Public Sub RestoreOldVersion()
        Dim strFilter As String =  "Autodesk Inventor 旧文件(*.old)|*.old" '添加过滤文件

        Dim arrayFullFileName As List(Of String)
        arrayFullFileName = OpenFileDialog(strFilter, True)

        If arrayFullFileName Is Nothing Then
            Exit Sub
        End If

        Dim strNewFullFileName As String
        For Each strOldFullFileName As String In arrayFullFileName
            strNewFullFileName = Left(strOldFullFileName, Strings.Len(strOldFullFileName) - 4)
            Rename(strOldFullFileName, strNewFullFileName)
        Next

    End Sub

    '清理旧版文件
    Public Sub CleanUpLegacyFiles()
        Try

            Dim strDestinationDirectory As String = Nothing
            'Dim oFileAttributes As FileAttributes

            Dim WorkSpaceFloder As String
            WorkSpaceFloder = ThisApplication.FileLocations.Workspace

            strDestinationDirectory = OpenFolderDialog(WorkSpaceFloder)

            If strDestinationDirectory Is Nothing Then
                Exit Sub
            End If

            Dim intDeleteRecycleOption As Integer
            Select Case MsgBox("是否永久删除旧文件，而不是移动到回收站？", MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question + MsgBoxStyle.YesNo, "删除文件")
                Case MsgBoxResult.Yes
                    intDeleteRecycleOption = FileIO.RecycleOption.DeletePermanently
                Case MsgBoxResult.No
                    intDeleteRecycleOption = FileIO.RecycleOption.SendToRecycleBin
            End Select

            '是否为文件夹，在其后添加 \
            'oFileAttributes = Microsoft.VisualBasic.FileSystem.GetAttr(strDestinationDirectory)

            'If oFileAttributes = FileAttributes.Directory Then
            '    strDestinationDirectory = strDestinationDirectory + "\"
            'End If

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

        SetPropitem(oInventorDocument, Map_DrawingNnumber, oStockNumPartName.图号)
        SetPropitem(oInventorDocument, Map_PartName, oStockNumPartName.零件名称)


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

        'Dim oInteraction As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents

        'oInteraction.Start()
        'oInteraction.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
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
        'oInteraction.Stop()
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
        '    if s = "" Then
        '        Exit Do
        '    End if
        'Loop Until (CheckCharType(s) = "Unicode字符")

        ''判断图号情况
        'Select Case True       '第一个字符为汉字
        '    Case i = 2
        '        BasicNumber = InputBox("部件 " & FullFileName & "  无图号，输入图号", "输入图号", "")
        '        if BasicNumber.ToString = "" Then
        '            Return False
        '            Exit Function
        '        End if
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
        strBasicNumber = oStockNumPartName.图号

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
        'if intAssNumberStep = 0 Then
        '    Return False
        '    Exit Function
        'End if

        'intPartNumberStep = Convert.ToInt16(InputBox("输入零件文件的编号变化，部件XXX-0000000 下第一个零件为XXX-0000001 则 输入 1 "))
        'if intPartNumberStep = 0 Then
        '    Return False
        '    Exit Function
        'End if

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
                If InStr(GetFileNameInfo(FoundFile).FileName, oOldFileNameInfo.FileName) > 1 Then  '存在一个已命名图号的文件
                    Select Case MsgBox("存在一个已命名图号的文件：" & FoundFile & vbCrLf & vbCrLf & _
                                       " ，是-直接替换  否-重新生成替换 ", MsgBoxStyle.Information + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1)
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
                    MsgBox("找到有对应的旧工程图，生成新的工程图，将打开，请链接到文件：" & vbCrLf & _
                           strNewFullFileName & vbCrLf & "该文件名已复制，粘贴到对话框即可。", MsgBoxStyle.Information)
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


    ''' <summary>
    '''     获取单个property
    ''' </summary>
    ''' <param name="oInventorDocument">文档</param>
    ''' <param name="strPropitemName">显示的名称</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPropitem(ByVal oInventorDocument As Inventor.Document, ByVal strPropitemName As String) As String
        Dim oPropertySets As PropertySets
        Dim oPropertySet As PropertySet
        Dim propitem As [Property]

        '=============================================================================
        '采用学徒服务器, 速度更快
        'Dim apprentice As Inventor.ApprenticeServerComponent
        'apprentice = New Inventor.ApprenticeServerComponent

        'Dim apprenticeDoc As Inventor.ApprenticeServerDocument
        'apprenticeDoc = apprentice.Open(oInventorDocument.FullDocumentName)

        'oPropertySets = apprenticeDoc.PropertySets

        '=============================================================================

        oPropertySets = oInventorDocument.PropertySets

        For Each oPropertySet In oPropertySets
            '获取iproperty
            Dim StockNumPartName As StockNumPartName = Nothing
            For Each propitem In oPropertySet
                Select Case propitem.DisplayName
                    Case strPropitemName
                        Return propitem.Value
                End Select
            Next
        Next

        'oInventorDocument.Update()   '刷新数据

        Return ""

    End Function

    ''' <summary>
    ''' 设置单个propitem
    ''' </summary>
    ''' <param name="oInventorDocument">文档</param>
    ''' <param name="strPropitemName">显示名称</param>
    ''' <param name="strPropitemValue">值</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetPropitem(ByVal oInventorDocument As Inventor.Document, ByVal strPropitemName As String, ByVal strPropitemValue As String) As Boolean
        Dim oPropertySets As PropertySets
        Dim oPropertySet As PropertySet
        Dim propitem As [Property]

        '=============================================================================
        '采用学徒服务器, 速度更快
        'Dim apprentice As Inventor.ApprenticeServerComponent
        'apprentice = New Inventor.ApprenticeServerComponent

        'Dim apprenticeDoc As Inventor.ApprenticeServerDocument
        'apprenticeDoc = apprentice.Open(oInventorDocument.FullDocumentName)

        'oPropertySets = apprenticeDoc.PropertySets

        '=============================================================================
        oPropertySets = oInventorDocument.PropertySets

        For Each oPropertySet In oPropertySets
            For Each propitem In oPropertySet
                Select Case propitem.DisplayName
                    Case strPropitemName
                        propitem.Value = strPropitemValue
                        oInventorDocument.Update()   '刷新数据
                        Return True

                End Select
            Next
        Next

        'apprenticeDoc.PropertySets.FlushToFile()
        'apprenticeDoc.Close()

    End Function

    ''' <summary>
    '''   获取 StockNumPartName
    ''' </summary>
    ''' <param name="oInventorDocument">文档</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPropitems(ByVal oInventorDocument As Inventor.Document) As StockNumPartName
        Dim oPropertySets As PropertySets
        Dim oPropertySet As PropertySet
        Dim propitem As [Property]

        '=============================================================================
        '采用学徒服务器, 速度更快
        'Dim apprentice As Inventor.ApprenticeServerComponent
        'apprentice = New Inventor.ApprenticeServerComponent

        'Dim apprenticeDoc As Inventor.ApprenticeServerDocument
        'apprenticeDoc = apprentice.Open(oInventorDocument.FullDocumentName)

        'oPropertySets = apprenticeDoc.PropertySets

        '=============================================================================

        Dim oStockNumPartName As StockNumPartName = Nothing

        oPropertySets = oInventorDocument.PropertySets

        For Each oPropertySet In oPropertySets
            For Each propitem In oPropertySet
                Select Case propitem.DisplayName
                    Case Map_PartName
                        oStockNumPartName.零件名称 = propitem.Value
                    Case Map_DrawingNnumber
                        oStockNumPartName.图号 = propitem.Value
                    Case Map_ERPCode
                        oStockNumPartName.ERP编码 = propitem.Value
                End Select
            Next
        Next

        'oInventorDocument.Update()   '刷新数据

        Return oStockNumPartName

    End Function

    ''' <summary>
    ''' 设置 StockNumPartName
    ''' </summary>
    ''' <param name="oInventorDocument">文档</param>
    ''' <param name="oStockNumPartName">值</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetPropitems(ByVal oInventorDocument As Inventor.Document, ByVal oStockNumPartName As StockNumPartName) As Boolean
        Dim oPropertySets As PropertySets
        Dim oPropertySet As PropertySet
        Dim propitem As [Property]

        ''=============================================================================
        '' 采用学徒服务器，速度更快
        'Dim apprentice As Inventor.ApprenticeServerComponent
        'apprentice = New Inventor.ApprenticeServerComponent

        'Dim apprenticeDoc As Inventor.ApprenticeServerDocument
        'apprenticeDoc = apprentice.Open(oInventorDocument.FullDocumentName)

        'oPropertySets = apprenticeDoc.PropertySets

        ''=============================================================================
        oPropertySets = oInventorDocument.PropertySets

        For Each oPropertySet In oPropertySets
            For Each propitem In oPropertySet
                Select Case propitem.DisplayName
                    Case Map_PartName
                        propitem.Value = oStockNumPartName.零件名称
                    Case Map_DrawingNnumber
                        propitem.Value = oStockNumPartName.图号
                    Case Map_ERPCode
                        propitem.Value = oStockNumPartName.ERP编码
                End Select
            Next
        Next

        'apprenticeDoc.PropertySets.FlushToFile()
        oInventorDocument.Update()   '刷新数据

        Return True

    End Function


    ''' <summary>
    ''' 设置一个自定义Propitem
    ''' </summary>
    ''' <param name="oInventorDocument">文档</param>
    ''' <param name="strUserPropitemName">名字</param>
    ''' <param name="strUserPropitemValue">值</param>
    ''' <remarks></remarks>
    Public Sub SetUserPropitem(ByVal oInventorDocument As Inventor.Document, ByVal strUserPropitemName As String, ByVal strUserPropitemValue As String)
        Dim pEachScale As [Property]

        Try
            '若该iProperty已经存在，则直接修改其值
            pEachScale = oInventorDocument.PropertySets.Item("User Defined Properties").Item(strUserPropitemName)
            pEachScale.Value = strUserPropitemValue
        Catch
            ' 若该iProperty不存在，则添加一个
            oInventorDocument.PropertySets.Item("User Defined Properties").Add(strUserPropitemName, strUserPropitemValue)
        End Try

        oInventorDocument.Update()   '刷新数据

    End Sub


    ''' <summary>
    ''' 获取一个一个自定义Propitem
    ''' </summary>
    ''' <param name="oInventorDocument">文档</param>
    ''' <param name="strUserPropitemName">名字</param>
    ''' <returns>值，若无为nothing</returns>
    ''' <remarks></remarks>
    Public Function GetUserPropitem(ByVal oInventorDocument As Inventor.Document, ByVal strUserPropitemName As String) As String
        Dim pEachScale As [Property]
        Dim strUserPropitemValue As String = Nothing
        Try
            '若该iProperty已经存在，则直接修改其值
            pEachScale = oInventorDocument.PropertySets.Item("User Defined Properties").Item(strUserPropitemName)
            strUserPropitemValue = pEachScale.Value
        Catch
            strUserPropitemValue = Nothing
        End Try

        Return strUserPropitemValue

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

        '获取iproperty
        Dim strStochNum As String = Nothing
        Dim strPartNum As String = Nothing

        strStochNum = GetPropitem(oInventorDocument, Map_DrawingNnumber)

        strPartNum = FindSrtingInSheet(BasicExcelFullFileName, strStochNum, SheetName, TableArrays, ColIndexNum, 0)
        If strPartNum <> 0 Then
            MsgBox("查询到ERP编码：" & strPartNum, MsgBoxStyle.Information)
            SetPropitem(oInventorDocument, Map_ERPCode, strPartNum)
        Else
            MsgBox("未查询到ERP编码。", MsgBoxStyle.Information)
        End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    '查找变更扩展名后为文件（原文件名，变更后的扩展名）
    Public Function GetChangeExtensionDocument(ByVal strFullDocumentName As String, ByVal strExtension As String) As String
        'On Error Resume Next

        Dim strChangeExtensionDocument As String
        strChangeExtensionDocument = GetChangeExtension(strFullDocumentName, strExtension)

        '查询到工程图
        '同一文件夹找到工程图
        If IsFileExsts(strChangeExtensionDocument) Then
            Return strChangeExtensionDocument
        Else
            '当前文件夹返回3层父文件夹找
            Dim strParentFolderPath As String
            strParentFolderPath = GetFileNameInfo(strFullDocumentName).Folder
            strParentFolderPath = GetParentFolderPath(strParentFolderPath, Val(str查找文件夹层数))

            strFullDocumentName = GetChangeExtension(strFullDocumentName, strExtension)
            Dim strInventorDocumentName As String = GetFileName2(strFullDocumentName)

            Dim arrayFullFileName As List(Of String)
            arrayFullFileName = FindFileInFolder(strParentFolderPath, strInventorDocumentName)

            If arrayFullFileName.Count > 0 Then
                strChangeExtensionDocument = arrayFullFileName(0)
            Else
                strChangeExtensionDocument = ""
            End If

            'strDrawingFullFileName = SearchDocumentInPresentDirectory(strInventorDocumentFullDocumentName, Val(str查找文件夹层数))
            Return strChangeExtensionDocument
        End If
    End Function

    ''到父文件夹查询文件  ，原文档 ，向上查询的层级，对应的扩展名
    'Public Function SearchDocumentInPresentDirectory(ByVal strFullFileName As String, _
    '                                                     ByVal intPresidentLevel As Integer) As String
    '    On Error Resume Next

    '    Dim strPrsentDirectory As String   '父文件夹
    '    Dim strInventorFileName As String   '文件名
    '    Dim strFileNameWithNewExtensionName As String '对应的变更扩展名后的文件名
    '    Dim i As Integer

    '    'strInventorFullFileName = oInventorDocument.FullDocumentName
    '    strInventorFileName = GetFileName2(strFullFileName)

    '    strFileNameWithNewExtensionName = GetFileNameWithoutExtension2(strFullFileName) & strExtension

    '    i = 0

    '    strPrsentDirectory = System.IO.Directory.GetParent(strFullFileName).FullName

    '    'Dim startingDirectory As String = "C:\Pathto\A" ' 替换为你的起始目录路径
    '    'Dim fileName As String = "B.txt" ' 替换为你要查找的文件名
    '    'Dim maxLevels As Integer = 3 ' 替换为最大向上查找的层数
    '    Dim strFindFile As String = FindFile(strPrsentDirectory, strFileNameWithNewExtensionName, Val(str查找文件夹层数))

    '    If strFindFile IsNot Nothing Then
    '        Return strFindFile
    '    Else
    '        Return "NULL"
    '    End If


    'End Function



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

        'if oDef1.Pressed = True Then
        '    SetFileReadOnly(strInventorDocumentFullDocumentName, False)
        '    oDef1.Pressed = False
        'Else
        '    SetFileReadOnly(strInventorDocumentFullDocumentName, True)
        '    oDef1.Pressed = True
        'End if

    End Sub

    Public Sub OpenFilesWithList()
        'Dim oOpenFileDialog As New OpenFileDialog '声名新open 窗口

        'With oOpenFileDialog
        '    .Title = "打开"
        '    .Filter = "文本文件(*.txt)|*.txt" '添加过滤文件
        '    .Multiselect = False
        '    If .ShowDialog = System.Windows.Forms.DialogResult.OK Then '如果打开窗口OK
        '        If .FileName <> "" Then '如果有选中文件
        '            strListFile = .FileName
        '        End If
        '    End If
        'End With


        Dim strFilter As String = Nothing
        strFilter = "文本文件(*.txt)|*.txt" '添加过滤文件

        Dim strInitialDirectory As String = Microsoft.VisualBasic.FileIO.SpecialDirectories.Desktop

        Dim arrayFullFileName As List(Of String)
        arrayFullFileName = OpenFileDialog(strFilter, False, strInitialDirectory)

        If arrayFullFileName Is Nothing Then
            Exit Sub
        End If

        Dim strListFileName As String = Nothing
        strListFileName = arrayFullFileName.Item(0).ToString

        If strListFileName = "" Then
            Exit Sub
        End If

        Dim WorkSpaceFloder As String
        WorkSpaceFloder = ThisApplication.DesignProjectManager.ActiveDesignProject.WorkspacePath

        Using sr As StreamReader = New StreamReader(strListFileName)
            Dim strFileName As String
            While Not sr.EndOfStream
                strFileName = sr.ReadLine()

                If strFileName = "" Then
                    Continue While
                End If

                If IsFileExsts(strFileName) = True Then
                    '完整文件名就直接打开
                    ThisApplication.Documents.Open(strFileName)
                Else
                    '仅文件名就查询本项目

                    Dim strSearchFileName As String
                    Dim strExtension As String

                    If Strings.InStr(strFileName, ".") = 0 Then
                        strSearchFileName = strFileName
                        strExtension = ""
                    Else
                        Dim arraystrName As String() = Strings.Split(strFileName, ".")
                        strSearchFileName = arraystrName(0)
                        strExtension = "." & arraystrName(1)
                    End If

                    arrayFullFileName = FindFileInFolder(WorkSpaceFloder, strSearchFileName, strExtension)

                    If arrayFullFileName.Count > 0 Then
                        For Each strFullFileName As String In arrayFullFileName
                            '旧版文件就退出，查询下一个文件 
                            If InStr(strFullFileName, "OldVersions") <> 0 Then
                                Continue For
                            End If

                            If (GetFileExtensionLCase(strFullFileName) = IPT Or GetFileExtensionLCase(strFullFileName) = IAM) Then
                                ThisApplication.Documents.Open(strFullFileName)
                            End If
                        Next
                    End If

                End If
            End While
        End Using

        MsgBox("按列表打开文件完成。", MsgBoxStyle.Information)

    End Sub

    Public Sub SaveFilessList()

        ' 获取当前日期和时间
        Dim currentDate As DateTime = DateTime.Now
        ' 格式化日期和时间为字符串
        Dim strListFileName As String = currentDate.ToString("yyyyMMdd_HHmmss") & ".txt"

        Dim strFileFullName As String

        ' 创建一个新的文本文件，文件名为日期+时间
        Using writer As StreamWriter = New StreamWriter(IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop, strListFileName))
            ' 使用StreamWriter将字符串写入文件

            For Each oInventorDocument As Inventor.Document In ThisApplication.Documents.VisibleDocuments
                strFileFullName = oInventorDocument.FullFileName
                writer.WriteLine(strFileFullName)
            Next
        End Using
        MsgBox("保存当前打开的文件到列表：" & strListFileName, MsgBoxStyle.Information)
    End Sub
End Module