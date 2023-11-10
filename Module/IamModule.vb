Imports Inventor
Imports Inventor.AssetTypeEnum
Imports Inventor.BOMStructureEnum
Imports Inventor.DocumentTypeEnum
Imports Inventor.DrawingViewTypeEnum
Imports Inventor.IOMechanismEnum
Imports Inventor.PrintOrientationEnum
Imports Inventor.PropertyTypeEnum
Imports Inventor.SelectionFilterEnum
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel.XlCellType
Imports Microsoft.Office.Interop.Excel.XlFileFormat
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Module IamModule

    '检查是否有工程图
    Public Sub CheckIsInvHaveIdw()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                'Return False
                Exit Sub
            End If

            Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
            oInventorAssemblyDocument = ThisApplication.ActiveDocument

            Dim strPartDrawingNnumber As String

            Dim frmInputBox As New frmInputBox
999:
            With frmInputBox
                .txt输入.Text = GetPropitem(oInventorAssemblyDocument, Map_DrawingNnumber)

                .Text = "检查包号指定字符的工程图"
                .lbl描述.Text = "输入要检查的部分图号的。" & vbCrLf & "如要检查全部AAA-BBB000下的零件是否有工程图，输入AAA-BBB即可。"
                .StartPosition = FormStartPosition.CenterScreen
                strPartDrawingNnumber = .txt输入.Text
                .txt输入.SelectAll()
                .ShowDialog()
            End With

            If (frmInputBox.DialogResult = System.Windows.Forms.DialogResult.OK) And (strPartDrawingNnumber <> "") Then
                If CheckIsInvHaveIdwSub(oInventorAssemblyDocument, frmInputBox.txt输入.Text) Then
                    MsgBox("检查是否有工程图完成，打开了未找到工程图对应的模型文件。", MsgBoxStyle.Information)
                Else
                    SetStatusBarText("错误")
                    'MsgBox("错误", MsgBoxStyle.Exclamation)
                End If
            ElseIf frmInputBox.DialogResult = System.Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            Else
                MsgBox("请输入部分图号！", MsgBoxStyle.Information)
                SetStatusBarText("错误")
                GoTo 999
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '检查模型是否有对应的工程图
    Public Function CheckIsInvHaveIdwSub(ByVal oInventorAssemblyDocument As Inventor.AssemblyDocument, ByVal StrInName As String) As Boolean
        ' Set a reference to the BOM
        Dim oBOM As BOM
        oBOM = oInventorAssemblyDocument.ComponentDefinition.BOM

        ' Set the structured view to 'all levels'
        oBOM.StructuredViewFirstLevelOnly = False

        ' Make sure that the structured view is enabled.
        oBOM.StructuredViewEnabled = True

        ' Set a reference to the "Structured" BOMView

        '获取结构化的bom页面
        For Each oBOMView As BOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                '遍历这个bom页面
                CheckIsInvHaveIdwChildSub(oBOMView.BOMRows, StrInName)
            End If
        Next
        Return True

    End Function

    '检查模型是否有对应的工程图遍历子过程
    Public Sub CheckIsInvHaveIdwChildSub(ByVal oBOMRows As BOMRowsEnumerator, ByVal strInName As String)
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
                Call CheckIsInvHaveIdwChildSub(oRow.ChildRows, strInName)
            End If

        Next

    End Sub

    '查找缺失文件
    Public Sub GetAsmMissDocument()
        Try
            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            SetStatusBarText()

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                'Return False
                Exit Sub
            End If

            Dim oInventorFile As Inventor.File
            oInventorFile = ThisApplication.ActiveDocument.File

            If GetMissDocumentSub(oInventorFile) Then
                SetStatusBarText("查找缺失文件的部件完成")
            Else
                SetStatusBarText("错误")
                'MsgBox("错误", MsgBoxStyle.Exclamation)

            End If
            MsgBox("查找缺失文件的部件完成。", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '获取未读取的文件所在部件并打开该部件   （ 部件文件对象 ）
    Public Function GetMissDocumentSub(ByVal oInventorFile As Inventor.File) As Boolean
        Dim oFileDescriptor As FileDescriptor
        For Each oFileDescriptor In oInventorFile.ReferencedFileDescriptors

            'Debug.Print(oFileDescriptor.FullFileName)

            If Not oFileDescriptor.ReferenceMissing Then
                ' Since the ReferenceMissing has returned False, the ReferencedFile will return a File
                ' Recurse unless this is a foreign file reference
                If Not oFileDescriptor.ReferencedFileType = FileTypeEnum.kForeignFileType Then
                    GetMissDocumentSub(oFileDescriptor.ReferencedFile)
                End If
            Else
                Dim oPresentFile As String
                oPresentFile = oFileDescriptor.Parent.FullFileName
                If IsFileExsts(oPresentFile) Then
                    ThisApplication.Documents.Open(oPresentFile, True)
                End If
            End If
        Next
        Return True
    End Function

    '距离居中对齐
    Public Sub AlignComponentsInTheCenter()
        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        SetStatusBarText()

        If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
            MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
            'Return False
            Exit Sub
        End If

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument

        Try
            Dim oHSet1 As HighlightSet
            oHSet1 = oInventorAssemblyDocument.CreateHighlightSet()
            oHSet1.Color = ThisApplication.TransientObjects.CreateColor(58, 107, 114)

            Dim oHSet2 As HighlightSet
            oHSet2 = oInventorAssemblyDocument.CreateHighlightSet()
            oHSet2.Color = ThisApplication.TransientObjects.CreateColor(114, 114, 69)

            ' 选取零部件 b 的两个面 b1，b2
            Dim b1 As Inventor.Face
            b1 = ThisApplication.CommandManager.Pick(kPartFaceFilter, "选择零部件一的第一个面，ESC键取消。")
            If b1 Is Nothing Then
                oHSet1.Clear()
                oHSet2.Clear()
                Exit Sub
            Else
                oHSet1.AddItem(b1)
            End If

            Dim b2 As Inventor.Face
            b2 = ThisApplication.CommandManager.Pick(kPartFaceFilter, "选择零部件一的第二个面，ESC键取消。")
            If b2 Is Nothing Then
                oHSet1.Clear()
                oHSet2.Clear()
                Exit Sub
            Else
                oHSet2.AddItem(b2)
            End If

            ' 比较两个面的法线向量
            Dim Plane1 As Inventor.Plane
            Dim Plane2 As Inventor.Plane

            Plane1 = b1.Geometry
            Plane2 = b2.Geometry

            Dim L1 As Double
            If Plane1.IsParallelTo(Plane2) Then
                L1 = ThisApplication.MeasureTools.GetMinimumDistance(b1, b2)
            Else
                oHSet1.Clear()
                oHSet2.Clear()
                Exit Sub
            End If

            ' 选取零部件 c 的两个面 c1，c2
            Dim c1 As Inventor.Face
            c1 = ThisApplication.CommandManager.Pick(kPartFaceFilter, "选择零部件二的第一个面，ESC键取消。")
            If c1 Is Nothing Then
                oHSet1.Clear()
                oHSet2.Clear()
                Exit Sub
            Else
                oHSet1.AddItem(c1)
            End If

            Dim c2 As Inventor.Face
            c2 = ThisApplication.CommandManager.Pick(kPartFaceFilter, "选择零部件二的第二个面，ESC键取消。")
            If c2 Is Nothing Then
                oHSet1.Clear()
                oHSet2.Clear()
                Exit Sub
            Else
                oHSet2.AddItem(c2)
            End If

            Plane1 = c1.Geometry
            Plane2 = c2.Geometry

            Dim L2 As Double
            If Plane1.IsParallelTo(Plane2) Then
                L2 = ThisApplication.MeasureTools.GetMinimumDistance(c1, c2)
            Else
                oHSet1.Clear()
                oHSet2.Clear()
                Exit Sub
            End If

            ' 计算偏移距离

            Dim offset As Double = (L2 - L1) * 0.5

            ' 选取 b1 平面和 c1 平面

            ' 放置约束
            Dim oAsmCompDef As AssemblyComponentDefinition
            oAsmCompDef = ThisApplication.ActiveDocument.ComponentDefinition

            '先用平面对齐
            Dim oMate As Inventor.FlushConstraint
            oMate = oAsmCompDef.Constraints.AddFlushConstraint(b1, c1, offset)

            '检查平面对齐是否正确，不正确用配合
            If oMate.HealthStatus <> HealthStatusEnum.kUpToDateHealth Then
                oMate.Delete()
                Dim oMate2 As Inventor.MateConstraint
                oMate2 = oAsmCompDef.Constraints.AddMateConstraint(b1, c1, -offset)
            End If

            oHSet1.Clear()
            oHSet2.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '对齐XYZ平面
    Public Function FlushXYZPlane() As Boolean

        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Function
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                'Return False
                Exit Function
            End If

            Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
            oInventorAssemblyDocument = ThisApplication.ActiveDocument

            '设置为一个动作, 可一次撤销
            Dim transientGeometry As TransientGeometry
            transientGeometry = ThisApplication.TransientGeometry
            'start a transaction so the slot will be within a single undo step
            Dim createSlotTransaction As Transaction
            createSlotTransaction = ThisApplication.TransactionManager.StartTransaction(oInventorAssemblyDocument, "选择零部件")

            Dim InventorDocument As Inventor.Document
            InventorDocument = ThisApplication.ActiveDocument

            Dim oAsmCompDef As AssemblyComponentDefinition
            oAsmCompDef = InventorDocument.ComponentDefinition

            ' Get references to the two occurrences to constrain.
            ' This arbitrarily gets the first and second occurrence.
            Dim oComponentOccurrence1 As ComponentOccurrence
            oComponentOccurrence1 = ThisApplication.CommandManager.Pick(kAssemblyLeafOccurrenceFilter, "选择第一个部件或零件，ESC键取消")

            If oComponentOccurrence1 Is Nothing Then       '取消选择
                Exit Function
            End If

            Dim oComponentOccurrence2 As ComponentOccurrence
            oComponentOccurrence2 = ThisApplication.CommandManager.Pick(kAssemblyLeafOccurrenceFilter, "选择第二个部件或零件，ESC键取消")

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
            SetStatusBarText("对齐原始坐标面")

            'end the transactio
            createSlotTransaction.End()
        Catch ex As Exception
            SetStatusBarText("错误")
            MsgBox(ex.Message)
        End Try

    End Function

    '移动指定文件
    Public Sub MovesSpecifiedFile()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                'Return False
                Exit Sub
            End If

            Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
            oInventorAssemblyDocument = ThisApplication.ActiveDocument
999:
            Dim frmInputBox As New frmInputBox

            With frmInputBox
                .txt输入.Text = GetPropitem(oInventorAssemblyDocument, Map_DrawingNnumber)
                .Text = "移动文件"
                .lbl描述.Text = "将保存并关闭当前文档，移动指定的文件到当前部件文件夹。" & vbCrLf & "输入从第一个图号开始的筛选字段。"
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
            End With

            Dim strFilter As String
            If frmInputBox.DialogResult = System.Windows.Forms.DialogResult.OK And frmInputBox.txt输入.Text <> "" Then
                strFilter = frmInputBox.txt输入.Text
            ElseIf frmInputBox.DialogResult = System.Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            Else
                MsgBox("请输入部分图号！", MsgBoxStyle.Information)
                SetStatusBarText("错误")
                GoTo 999
                Exit Sub
            End If

            ' 获取所有引用文档
            Dim oInventorDocumentsEnumerator As Inventor.DocumentsEnumerator
            oInventorDocumentsEnumerator = oInventorAssemblyDocument.AllReferencedDocuments

            ' 遍历这些文档

            Dim arrReferencedFullFileName(2000) As String

            ReDim arrReferencedFullFileName(oInventorDocumentsEnumerator.Count - 1)

            Dim i As Integer = 0

            For Each oInventorDocument In oInventorDocumentsEnumerator
                Debug.Print(oInventorDocument.FullFileName)
                arrReferencedFullFileName(i) = oInventorDocument.FullFileName
                i = i + 1
            Next

            Dim strInventorAssemblyFullFileName As String
            strInventorAssemblyFullFileName = oInventorAssemblyDocument.FullDocumentName

            '组件所在文件夹
            Dim srtInventorAssemblyFileFolder As String
            srtInventorAssemblyFileFolder = GetFileNameInfo(strInventorAssemblyFullFileName).Folder

            '保存关闭组件
            oInventorAssemblyDocument.Close()

            Dim oFileNameInfo As FileNameInfo

            For Each strReferencedFullFileName As String In arrReferencedFullFileName

                ThisApplication.StatusBarText = strReferencedFullFileName
                oFileNameInfo = GetFileNameInfo(strReferencedFullFileName)

                If InStr(oFileNameInfo.OnlyName, strFilter) = 1 Then
                    ReMoveFileToFolder(strReferencedFullFileName, srtInventorAssemblyFileFolder)

                    Dim strInventorDrawingFullFileName As String
                    strInventorDrawingFullFileName = GetChangeExtension(strReferencedFullFileName, IDW)

                    If IsFileExsts(strInventorDrawingFullFileName) = True Then
                        ReMoveFileToFolder(strInventorDrawingFullFileName, srtInventorAssemblyFileFolder)
                    End If

                End If
            Next

            If MsgBox("移动指定文件完成，是否重新打开 " & strInventorAssemblyFullFileName, MsgBoxStyle.YesNo + MsgBoxStyle.Question, "移动文件") = MsgBoxResult.Yes Then
                ThisApplication.Documents.Open(strInventorAssemblyFullFileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '提取iPro修改文件名
    Public Sub GetIpropertyToRename()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                'Return False
                Exit Sub
            End If

            Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
            oInventorAssemblyDocument = ThisApplication.ActiveDocument

            Dim oOldComponentOccurrence As ComponentOccurrence   '选择的部件或零件

            If oInventorAssemblyDocument.SelectSet.Count <> 0 Then
                'For Each oSelect As Object In InventorDoc.SelectSet
                oOldComponentOccurrence = oInventorAssemblyDocument.SelectSet(1)
                'Next
            Else
                oOldComponentOccurrence = ThisApplication.CommandManager.Pick(kAssemblyOccurrenceFilter, "选择要更改文件名的的零件或部件")
            End If

            If oOldComponentOccurrence Is Nothing Then       '取消选择
                Exit Sub
            End If

            If GetIpropertyToRenameSub(oInventorAssemblyDocument, oOldComponentOccurrence) Then
                SetStatusBarText("提取iproperty更改文件名完成")
                'MsgBox("提取iproperty更改文件名完成", MsgBoxStyle.Information)
            Else
                SetStatusBarText("错误")
                MsgBox("错误。", MsgBoxStyle.Exclamation)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '提取iproperty更改文件名
    Public Function GetIpropertyToRenameSub(ByVal oInventorDocument As Inventor.Document, ByVal oOldComponentOccurrence As ComponentOccurrence) As Boolean
        Dim strOldFullFileName As String   '被替换的旧文件全名
        Dim strOldFileName As String   '被替换的旧文件仅文件名
        strOldFullFileName = oOldComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName
        strOldFileName = GetFileNameInfo(strOldFullFileName).OnlyName

        If IsFileExsts(strOldFullFileName) = False Then
            MsgBox("文件： " & strOldFullFileName & "不存在！", MsgBoxStyle.Critical)
            Return True
            Exit Function
        End If

        If InStr(strOldFullFileName, ContentCenterFiles) > 0 Then         '跳过零件库文件
            MsgBox("无法修改资源中心文件： " & strOldFullFileName, MsgBoxStyle.Information)
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
                SetDocumentIpropertyFromFileNameSub(oNewInventorDocument, False)

                '检查是否有对应的工程图文件，同时复制后修改文件名和模型链接
                Dim strOldDrawingFullFileName As String
                strOldDrawingFullFileName = GetChangeExtension(strOldFullFileName, IDW)   '旧工程图

                If IsFileExsts(strOldDrawingFullFileName) = True Then
                    Dim strNewDrawingFullFileName As String
                    '新工程图
                    strNewDrawingFullFileName = GetChangeExtension(strNewFullFileName, IDW)
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

    '设值随机颜色
    Public Sub SetRandomColor()

        'Try
        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
            MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
            'Return False
            Exit Sub
        End If

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument

        '设置为一个动作, 可一次撤销
        'Dim transientGeometry As TransientGeometry
        'transientGeometry = ThisApplication.TransientGeometry

        Dim oTransaction As Transaction
        oTransaction = ThisApplication.TransactionManager.StartTransaction(oInventorAssemblyDocument, "My Transaction")

        ThisApplication.ScreenUpdating = False

        Dim osubdoc As Document
        Dim oName = "随机色"
        Dim oDoc As PartDocument = Nothing
        Dim oAppearance As Asset = Nothing
        '每个零件添加颜色

        On Error Resume Next

        For Each osubdoc In oInventorAssemblyDocument.AllReferencedDocuments
            If osubdoc.DocumentType = kPartDocumentObject Then
                oDoc = ThisApplication.Documents.Open(osubdoc.FullDocumentName, False)
                oAppearance = oDoc.ActiveAppearance
                If Not oAppearance.DisplayName = oName Then
                    '尝试是否存在“配置色”外观
                    oAppearance = oDoc.AppearanceAssets.Item(oName)
                    '如果名字不存在则，创建名为"配置色"的新外观(没有多状态的零件)
                    oAppearance = oDoc.Assets.Add(kAssetTypeAppearance, "Generic", "Appearances", oName)
                    '将新外观设置为激活状态
                    oDoc.ActiveAppearance = oAppearance
                    Err.Clear()
                End If
            End If
            '设置颜色
            Dim oColor As ColorAssetValue
            oColor = oAppearance.Item("generic_diffuse")
            Dim rng, rng1, rng2 As Integer

            rng = Math.Round(Rnd() * 255)
            rng1 = Math.Round(Rnd() * 255)
            rng2 = Math.Round(Rnd() * 255)
            oColor.Value = ThisApplication.TransientObjects.CreateColor(rng, rng1, rng2)
            oDoc.Close(False)
        Next
        oInventorAssemblyDocument.Document.Rebuild()
        oTransaction.End()
        ThisApplication.ScreenUpdating = True

        ThisApplication.CommandManager.ControlDefinitions.Item("AppZoomAllCmd").Execute()

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub

    '清除随机颜色
    Public Sub ClearRandomColor()
        'Try

        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
            MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
            'Return False
            Exit Sub
        End If

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument

        '设置为一个动作, 可一次撤销
        Dim oTransaction As Transaction
        oTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "My Transaction")

        ThisApplication.ScreenUpdating = False

        Dim osubdoc As Document
        Dim oName = "随机色"
        Dim oDoc As PartDocument = Nothing
        Dim oAppearance As Asset = Nothing
        '每个零件添加颜色

        On Error Resume Next

        For Each osubdoc In oInventorAssemblyDocument.AllReferencedDocuments
            If osubdoc.DocumentType = kPartDocumentObject Then
                Dim oModelStates = osubdoc.ComponentDefinition.ModelStates
                Dim icount = oModelStates.count
                If icount > 1 Then '多零件状态判断
                    For i = 1 To icount Step 1
                        ' 设置外观“源材料外观”
                        oModelStates.Item(i).Activate()
                        oModelStates.Item(i).FactoryDocument.AppearanceSourceType = AppearanceSourceTypeEnum.kMaterialAppearance
                        If oModelStates.Item(i).FactoryDocument.AppearanceAssets.Item(oName).IsUsed = False Then
                            oModelStates.Item(i).FactoryDocument.AppearanceAssets.Item(oName).Delete()
                        End If
                    Next
                Else '如果零件没有零件状态
                    '设置外观“源材料外观
                    osubdoc.AppearanceSourceType = AppearanceSourceTypeEnum.kMaterialAppearance
                End If

                If osubdoc.AppearanceAssets.Item(oName).IsUsed = False Then
                    osubdoc.AppearanceAssets.Item(oName).Delete()
                End If
            End If
        Next

        oInventorAssemblyDocument.Document.Rebuild()
        oTransaction.End()
        ThisApplication.ScreenUpdating = True

        Call ThisApplication.CommandManager.ControlDefinitions.Item("AppZoomAllCmd").Execute()

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

   

    '打开部件中所有子集对应的工程图 ，部件文件，指定的图号
    Public Function OpenAllDrwInAsmSub(ByVal oInventorAssemblyDocument As Inventor.AssemblyDocument, ByVal strStockNum As String) As Boolean
        ' Set a reference to the BOM
        Dim oBOM As BOM
        oBOM = oInventorAssemblyDocument.ComponentDefinition.BOM

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
                OpenAllDrwInAsmChildSub(oBOMView.BOMRows, strStockNum)

            End If
        Next
        Return True

    End Function

    '打开部件中所有子集对应的工程图
    Public Sub OpenAllDrwInAsmChildSub(ByVal oBOMRows As BOMRowsEnumerator, ByVal strStockNum As String)
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
                Call OpenAllDrwInAsmChildSub(oBOMRow.ChildRows, strStockNum)
            End If

        Next

    End Sub

    '设置当前部件下级为虚拟件
    Public Sub SetBOMStructuret()

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

            If SetBOMStructuretsub(oInventorAssemblyDocument) Then
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

    '设置当前部件下级为虚拟件
    Public Function SetBOMStructuretsub(ByVal oInventorAssemblyDocument As Inventor.AssemblyDocument) As Boolean
        '设置结构类型
        Dim BOMStructureType As BOMStructureEnum

        Dim strBOMStructureType As String
        strBOMStructureType = InputBox("将本部件所属零部件设置为【普通件】或【虚拟件】。输入要设置的类型：" & vbCrLf & vbCrLf & _
                                       "1——普通件" & vbCrLf & vbCrLf & _
                                       "2——虚拟件" & vbCrLf & vbCrLf & _
                                       "3——外购件", _
                                       "设置虚拟件", 2)

        If IsNumeric(strBOMStructureType) = False Then
            Return False
        End If

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
        oBOM = oInventorAssemblyDocument.ComponentDefinition.BOM

        ' Set the structured view to 'all levels'
        oBOM.StructuredViewFirstLevelOnly = False

        ' Make sure that the structured view is enabled.
        oBOM.StructuredViewEnabled = True

        ' Set a reference to the "Structured" BOMView

        '获取结构化的bom页面
        For Each oBOMView As BOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kModelDataBOMViewType Then
                '遍历这个bom页面
                SetPhantomBOMStructuretChildSub(oBOMView.BOMRows, BOMStructureType)
            End If
        Next
        Return True
    End Function

    '设置当前部件下级为虚拟件,遍历子程序
    Public Sub SetPhantomBOMStructuretChildSub(ByVal oBOMRows As BOMRowsEnumerator, ByVal BOMStructureType As BOMStructureEnum)
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

    '导出平面BOM
    Public Sub ExportBOMAsFlat()

        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            Else
                Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
                oInventorAssemblyDocument = ThisApplication.ActiveDocument

                Dim strCsvFullFileName As String

                strCsvFullFileName = My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & GetFileNameInfo(oInventorAssemblyDocument.FullFileName).OnlyName & "导出BOM.csv"

                If IsFileExsts(strCsvFullFileName) = True Then
                    DelFile(strCsvFullFileName, FileIO.RecycleOption.SendToRecycleBin)
                End If

                Dim IsExpandOutSourcedParts As Boolean

                Select Case MsgBox("是否展开外协件、外购件？", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, "导出BOM")

                    Case MsgBoxResult.Yes
                        IsExpandOutSourcedParts = True
                    Case MsgBoxResult.No
                        IsExpandOutSourcedParts = False
                    Case MsgBoxResult.Cancel
                        Exit Sub
                End Select

                Dim oInteraction As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
                oInteraction.Start()
                oInteraction.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
                'System.Threading.Thread.Sleep(5000)

                ExportBOMAsFlatSub(oInventorAssemblyDocument, strCsvFullFileName, IsExpandOutSourcedParts)

                oInteraction.SetCursor(CursorTypeEnum.kCursorTypeDefault)
                oInteraction.Stop()

                SetStatusBarText(" 导出BOM平面性完成")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '导出 bom 平面性
    Public Function ExportBOMAsFlatSub(ByVal oInventorAssemblyDocument As Inventor.AssemblyDocument, ByVal strCsvFullFileName As String, _
                                    ByVal IsExpandOutSourcedParts As Boolean) As Boolean
        Dim FirstLevelOnly As Boolean

        FirstLevelOnly = False

        '==============================================================================================
        '基于bom结构化数据，可跳过参考的文件
        ' Set a reference to the BOM
        Dim oBOM As BOM
        oBOM = oInventorAssemblyDocument.ComponentDefinition.BOM
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
                QueryBOMRowPropertieToExcel(strCsvFullFileName, oBOMView.BOMRows, FirstLevelOnly, BOMTiTle, "0", 1, IsExpandOutSourcedParts)
            End If
        Next

        '转换excel文件格式
        '===========================================================================
        SetStatusBarText("开始转换文件...")

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

        SetStatusBarText("开始设置表格格式...")

        oWorkbook = oExcelApplication.Workbooks.Open(strExcelFullFileName)

        Dim oWorksheet As Excel.Worksheet
        oWorksheet = oWorkbook.Worksheets(1)

        '设边框线

        Dim oRange As Excel.Range
        Dim lastCell As Excel.Range
        lastCell = oWorksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell)
        oRange = oWorksheet.Range("A1", lastCell)
        oRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous

        '所有单元格列宽自动调整
        oWorksheet.Cells.EntireColumn.AutoFit()
        '所有单元格行高自动调整
        oWorksheet.Cells.EntireRow.AutoFit()

        oWorkbook.Close(True)
        '===========================================================================

        oExcelApplication.Quit()

        System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcelApplication)

        SetStatusBarText("BOM导出到文件：" & vbCrLf & strExcelFullFileName)
        MsgBox("BOM导出到文件：" & vbCrLf & strExcelFullFileName, MsgBoxStyle.Information)

        Process.Start(strExcelFullFileName)

        Return True

    End Function

    '在 bom平面性导出，子程序，遍历bom 行文件ipro
    Private Sub QueryBOMRowPropertieToExcel(ByVal strCsvFullFileName As String, ByVal oBOMRows As BOMRowsEnumerator, _
                                            ByVal FirstLevelOnly As Boolean, ByVal strColumnsTitle As String, _
                                            ByVal strLevel As String, ByVal intPresentNumber As Integer, ByVal IsExpandOutSourcedParts As Boolean)

        On Error Resume Next

        Dim i As Short
        Dim j As Short
        Dim iStepCount As Short
        iStepCount = oBOMRows.Count

        'Create a new ProgressBar object.
        'Dim oProgressBar As Inventor.ProgressBar

        'oProgressBar = ThisApplication.CreateProgressBar(False, iStepCount, "当前文件： ")

        '赋值数组
        Dim oBOMRowData(5000, 1) As String

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
                            Case Map_PartName      '映射文件名
                                arrColumnsTitleValue(k) = GetPropitem(oInventorDocument, Map_PartName)
                            Case Map_DrawingNnumber   '映射图号
                                arrColumnsTitleValue(k) = GetPropitem(oInventorDocument, Map_DrawingNnumber)
                            Case Map_Describe      '映射描述
                                arrColumnsTitleValue(k) = GetPropitem(oInventorDocument, Map_Describe)
                            Case Map_ERPCode       '映射erp编码
                                arrColumnsTitleValue(k) = GetPropitem(oInventorDocument, Map_ERPCode)
                            Case Map_Vendor  '映射供应商
                                arrColumnsTitleValue(k) = GetPropitem(oInventorDocument, Map_Vendor)
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
                                strMass = GetMass(oInventorDocument).ToString
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
                                'Dim StockNumPartName As StockNumPartName
                                'StockNumPartName = GetStockNumPartName(oBOMRow.ReferencedFileDescriptor.Parent.FullFileName)
                                'arrColumnsTitleValue(k) = StockNumPartName.StockNum

                                Dim oParentInventorDocument As Inventor.Document

                                oParentInventorDocument = ThisApplication.Documents.Open(oBOMRow.ReferencedFileDescriptor.Parent.FullFileName, False)
                                arrColumnsTitleValue(k) = GetPropitem(oParentInventorDocument, Map_DrawingNnumber)

                            Case "总数量"
                                arrColumnsTitleValue(k) = (oBOMRow.ItemQuantity * intPresentNumber).ToString

                            Case "缩略图"
                                'propitem = oPropSet.ItemByPropId(Inventor.PropertiesForDesignTrackingPropertiesEnum.kPartIconDesignTrackingProperties)
                                'Array_ColumnsTitleValue(k) = propitem.Value

                                'Case Map_Vendor

                                '    arrColumnsTitleValue(k) = GetPropitem(oInventorDocument, Map_Vendor)

                                'propitem = oPropertySet.ItemByPropId(Inventor.PropertiesForDesignTrackingPropertiesEnum.kVendorDesignTrackingProperties)
                                'arrColumnsTitleValue(k) = propitem.Value

                            Case "总质量"
                                arrColumnsTitleValue(k) = (GetMass(oInventorDocument) * oBOMRow.ItemQuantity * intPresentNumber).ToString

                        End Select
                        arrColumnsTitleValue(k) = Strings.Replace(arrColumnsTitleValue(k), ",", "，")
                    Next k

                    'oInventorDocument.Close(False)

                    Select Case oInventorDocument.DocumentType
                        Case kAssemblyDocumentObject
                            Threading.Thread.Sleep(300)
                        Case kPartDocumentObject
                            Threading.Thread.Sleep(100)
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

                        Select Case IsExpandOutSourcedParts
                            Case True   '展开全部子级
                                Call QueryBOMRowPropertieToExcel(strCsvFullFileName, oBOMRow.ChildRows, FirstLevelOnly, strColumnsTitle, 0, oBOMRow.ItemQuantity * intPresentNumber, IsExpandOutSourcedParts)
                            Case False    '仅展开自制件或空白
                                If strVendor = "自制件" Or strVendor = "" Then
                                    Call QueryBOMRowPropertieToExcel(strCsvFullFileName, oBOMRow.ChildRows, FirstLevelOnly, strColumnsTitle, 0, oBOMRow.ItemQuantity * intPresentNumber, IsExpandOutSourcedParts)
                                End If
                        End Select

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

    '打开指定工程图
    Public Sub OpenAllDrwInAsm()
        'Try
        On Error Resume Next

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

        Dim strPartDrawingNnumber As String
999:
        Dim frmInputBox As New frmInputBox
        With frmInputBox
            .txt输入.Text = GetPropitem(oInventorAssemblyDocument, Map_DrawingNnumber)
            .Text = "打开指定工程图"
            .lbl描述.Text = "输入包含指定的字段的图号。" & vbCrLf & "如要打开 AAA-BBB000.aim 下的工程图，输入AAA-BBB即可。"
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            strPartDrawingNnumber = .txt输入.Text
        End With

        If (frmInputBox.DialogResult = System.Windows.Forms.DialogResult.OK) And (strPartDrawingNnumber <> "") Then
            If OpenAllDrwInAsmSub(oInventorAssemblyDocument, frmInputBox.txt输入.Text) Then
                MsgBox("打开了部件所有子集对应的工程图。", MsgBoxStyle.Information)
            Else
                SetStatusBarText("错误")
            End If
        ElseIf frmInputBox.DialogResult = System.Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            MsgBox("请输入部分图号！", MsgBoxStyle.Information)
            SetStatusBarText("错误")
            GoTo 999
            Exit Sub
        End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub

    '更改文件名的零件或部件
    Public Sub RenameAssPartDocumentName()
        'Try
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

        Dim oOldComponentOccurrence As ComponentOccurrence   '选择的部件或零件

        If oInventorAssemblyDocument.SelectSet.Count <> 0 Then
            'For Each oSelect As Object In InventorDoc.SelectSet
            oOldComponentOccurrence = oInventorAssemblyDocument.SelectSet(1)
            'Next
        Else
            oOldComponentOccurrence = ThisApplication.CommandManager.Pick(kAssemblyOccurrenceFilter, "选择要更改文件名的零件或部件")
        End If

        If oOldComponentOccurrence Is Nothing Then       '取消选择
            Exit Sub
        End If

        Select Case oOldComponentOccurrence.DefinitionDocumentType
            Case kAssemblyDocumentObject, kPartDocumentObject

                Dim strOldFullFileNameName As String   '被替换的旧文件全名
                Dim strOldDocumentName As String   '被替换的旧文件仅文件名
                strOldFullFileNameName = oOldComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName
                strOldDocumentName = GetFileNameInfo(strOldFullFileNameName).OnlyName

                Dim strNewFileName As String   '新文件仅文件名
                strNewFileName = InputBox("重命名 " & strOldFullFileNameName, "重命名", strOldDocumentName)  '输入新文件名

                If RenameAssPartDocumentNameSub(oInventorAssemblyDocument, oOldComponentOccurrence, strNewFileName) Then
                    SetStatusBarText("更改零件/部件文件名完成")
                    'MsgBox("更改零件/部件文件名完成", MsgBoxStyle.Information)
                Else
                    SetStatusBarText("错误")
                    MsgBox("错误。", MsgBoxStyle.Exclamation)

                End If
            Case Else

        End Select
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub

    '更改零件/部件文件名子过程
    Public Function RenameAssPartDocumentNameSub(ByVal oInventorDocument As Inventor.Document, _
                                              ByVal oOldComponentOccurrence As ComponentOccurrence, _
                                              ByVal strNewFileName As String) As Boolean

        Dim strOldFullFileName As String   '被替换的旧文件全名
        Dim strOldFileName As String   '被替换的旧文件仅文件名
        strOldFullFileName = oOldComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName
        strOldFileName = GetFileNameInfo(strOldFullFileName).OnlyName

        If IsFileExsts(strOldFullFileName) = False Then
            MsgBox("文件： " & strOldFullFileName & "不存在！", MsgBoxStyle.Critical)
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
            MsgBox("无法修改资源中心文件： " & strOldFullFileName, MsgBoxStyle.Information)
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
                    MsgBox("未重新命名 ", MsgBoxStyle.Information)
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
                CloseFile(strNewFullFileName)

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

                SetDocumentIpropertyFromFileNameSub(oInventorDocument, True) '设置Iproperty，打开文件后需关闭

                Dim IsSaveAsOld As MsgBoxResult
                IsSaveAsOld = MsgBox("是否更改原文件为备份文件，扩展名增加 .old ？", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)

                '是否有对应的工程图文件，同时复制后修改文件名和模型链接
                Dim strOldIdwFullFileName As String

                Dim strTempFullFileName As String       '更改旧模型文件的名字存档
                strOldIdwFullFileName = GetChangeExtension(strOldFullFileName, IDW)   '旧工程图

                If IsFileExsts(strOldIdwFullFileName) = False Then
                    strOldIdwFullFileName = SearchDrawingDocumentInPresentFolder(oInventorDocument.FullDocumentName, 3, IDW)
                End If

                If IsFileExsts(strOldIdwFullFileName) = True Then
                    Dim strNewIdwFullFileName As String
                    strNewIdwFullFileName = GetChangeExtension(strNewFullFileName, IDW)   '新工程图

                    If IsFileExsts(strNewIdwFullFileName) = True Then
                        If MsgBox("存在旧的工程图：" & strNewIdwFullFileName & "，是否重新生成?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then  '选择覆盖
                            DelFile(strNewIdwFullFileName, FileIO.RecycleOption.SendToRecycleBin)   '删除旧的新文件名 文件
                            FileSystem.FileCopy(strOldIdwFullFileName, strNewIdwFullFileName)             '复制为新工程图
                        Else
                            '不复制为新文件，用旧文件
                        End If
                    Else
                        FileSystem.FileCopy(strOldIdwFullFileName, strNewIdwFullFileName)             '复制为新工程图
                    End If

                    '替换工程图模型参考
                    ReplaceFileReference(strNewIdwFullFileName, strOldFullFileName, strNewFullFileName)

                    If IsSaveAsOld = MsgBoxResult.Yes Then
                        strTempFullFileName = strOldIdwFullFileName & OLD    '暂时更改旧工程图文件的名字存档
                        ReFileName(strOldIdwFullFileName, strTempFullFileName)
                        'ReFileName(TempFullFileName, OldFullFileName)   '恢复旧零件或部件文件名
                    End If

999:
                End If

                If IsSaveAsOld = MsgBoxResult.Yes Then
                    strTempFullFileName = strOldFullFileName & ".old"
                    ReFileName(strOldFullFileName, strTempFullFileName)
                End If
                Return True
            Case MsgBox("选择的文件不是零件或部件。", MsgBoxStyle.Information)
                Return False
        End Select

    End Function

    '更改镜像零件/部件文件名
    Public Sub RenameMirrorAssPartDocumentName()
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

            Dim OldOcc As ComponentOccurrence   '选择的部件或零件

            If oInventorAssemblyDocument.SelectSet.Count <> 0 Then
                'For Each oSelect As Object In InventorDoc.SelectSet
                OldOcc = oInventorAssemblyDocument.SelectSet(1)
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
                    OldFileName = GetFileNameInfo(OldFullFileName).OnlyName

                    Dim NewFileName As String   '新文件仅文件名
                    NewFileName = InputBox("镜像文件重命名 " & OldFullFileName, "镜像文件重命名", OldFileName)  '输入新文件名

                    '取消输入
                    If NewFileName = "" Then
                        Exit Sub
                    End If

                    If RenameMirrorAssPartDocumentNameSub(oInventorAssemblyDocument, OldOcc, NewFileName) Then
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

    '更改镜像零件文件名子过程
    Public Function RenameMirrorAssPartDocumentNameSub(ByVal oInventorDocument As Inventor.Document, _
                                                    ByVal oOldComponentOccurrence As ComponentOccurrence, _
                                                    ByVal strNewFileName As String) As Boolean

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

        SetDocumentIpropertyFromFileNameSub(oInventorDocument, True) '设置Iproperty，打开文件后需关闭

        '还原早一个版本的文件()
        ReFileName(strReferencedFullFileNameTemp, strReferencedFullFileName)

        Return True
        '    Case MsgBox("选择的文件不是零件或部件", MsgBoxStyle.Information)
        'Return False
        'End Select

    End Function

    '更改镜像零件文件名
    Public Function RenameMirrorAssPartDocumentName(ByVal oInventorDocument As Inventor.Document, _
                                                    ByVal oOldComponentOccurrence As ComponentOccurrence, _
                                                    ByVal strNewFileName As String) As Boolean

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

        SetDocumentIpropertyFromFileNameSub(oInventorDocument, True) '设置Iproperty，打开文件后需关闭

        '还原早一个版本的文件()
        ReFileName(strReferencedFullFileNameTemp, strReferencedFullFileName)

        Return True
        '    Case MsgBox("选择的文件不是零件或部件", MsgBoxStyle.Information)
        'Return False
        'End Select

    End Function

    '批量替换部件下子集的名字
    Public Sub ReplaceNameInAsm()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim strOldFileName As String
            Dim strNewFileName As String

            strOldFileName = InputBox("输入：查找的内容")
            If strOldFileName = "" Then
                Exit Sub
            End If

            strNewFileName = InputBox("输入：替换为")
            If strNewFileName = "" Then
                Exit Sub
            End If

            'OldName = "GT140"
            'NewName = "GT240"

            Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
            oInventorAssemblyDocument = ThisApplication.ActiveDocument

            Dim IsSaveAsOld As MsgBoxResult
            IsSaveAsOld = MsgBox("是否更改原文件为备份文件，扩展名增加 .old ？", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "备份文件")

            ReplaceNameInAsmSub(oInventorAssemblyDocument, strOldFileName, strNewFileName, IsSaveAsOld)

            MsgBox("部件替换文件名完成。", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '批量替换部件下子集的名字子过程     组件，被替换的文件名，替换的文件名
    Public Function ReplaceNameInAsmSub(ByVal oInventorAssemblyDocument As Inventor.AssemblyDocument, ByVal strOldName As String, ByVal strNewName As String, _
                                     ByVal IsSaveAsOld As MsgBoxResult) As Boolean

        Dim strTempFullFileName As String       '更改旧模型文件的名字存档

        For Each oInventorDocument As Inventor.Document In oInventorAssemblyDocument.ReferencedDocuments
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
                SetDocumentIpropertyFromFileNameSub(oNewInventorDocument, True) '设置Iproperty，打开文件后需关闭

                Dim oCO As Inventor.ComponentOccurrences
                oCO = oInventorAssemblyDocument.ComponentDefinition.Occurrences

                '全部替换为新文件
                For Each ooCO As ComponentOccurrence In oCO
                    If ooCO.ReferencedDocumentDescriptor.FullDocumentName = strOldFullFileName Then
                        ooCO.Replace(strNewFullFileName, True)
                        Exit For
                    End If
                Next

                '是否有对应的工程图文件，同时复制后修改文件名和模型链接
                Dim oOldIdwFullFileName As String
                oOldIdwFullFileName = GetChangeExtension(strOldFullFileName, IDW)   '旧工程图

                'Dim TempFullFileName As String       '更改旧模型文件的名字存档

                If IsFileExsts(oOldIdwFullFileName) = True Then
                    Dim oNewIdwFullFileName As String
                    oNewIdwFullFileName = GetChangeExtension(strNewFullFileName, IDW)   '新工程图
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
                    ReplaceNameInAsmSub(oNewInventorDocument, strOldName, strNewName, IsSaveAsOld)
                End If
                oNewInventorDocument.Close(True)

            End If
        Next

        Return True

    End Function

    '刷新引用
    Public Sub RefreshShowName()
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

            If RefreshShowNameSub(oInventorAssemblyDocument) Then
                SetStatusBarText("刷新引用完成")
                MsgBox("刷新引用完成。", MsgBoxStyle.Information)
            Else
                SetStatusBarText("错误")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '刷新引用
    Public Function RefreshShowNameSub(ByVal oInventorAssemblyDocument As Inventor.AssemblyDocument) As Boolean

        ' 获取装配定义
        Dim oAssemblyComponentDefinition As AssemblyComponentDefinition
        oAssemblyComponentDefinition = oInventorAssemblyDocument.ComponentDefinition

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


    '一键全部可见
    Public Sub OneKeyShowAll()

        Try
            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            SetStatusBarText()

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                'Return False
                Exit Sub
            End If

            Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
            oInventorAssemblyDocument = ThisApplication.ActiveDocument

            '关闭屏幕更新
            ThisApplication.ScreenUpdating = False

            Dim oAsmDocDef As AssemblyComponentDefinition
            oAsmDocDef = oInventorAssemblyDocument.ComponentDefinition

            Dim oViewRepper As RepresentationsManager
            oViewRepper = oAsmDocDef.RepresentationsManager

            Dim actView As DesignViewRepresentation
            actView = oViewRepper.ActiveDesignViewRepresentation
            actView.ShowAll()

            '打开屏幕更新
            ThisApplication.ScreenUpdating = True

            '刷新浏览器
            oInventorAssemblyDocument.BrowserPanes.ActivePane.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    '设置标准件可见性
    Public Sub SetStandIptVisible()
        Try
            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            SetStatusBarText()

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                'Return False
                Exit Sub
            End If

            Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
            oInventorAssemblyDocument = ThisApplication.ActiveDocument

            '关闭屏幕更新
            'ThisApplication.ScreenUpdating = False

            Dim oCompocc As ComponentOccurrence

            Dim IsVisible As Boolean

            Select Case MsgBox("设置标准件可见性。" & vbCrLf & vbCrLf & "是——全部可见" & vbCrLf & vbCrLf & "否——全部隐藏", MsgBoxStyle.Information + MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes
                    IsVisible = True
                Case MsgBoxResult.No
                    IsVisible = False
                Case Else
                    GoTo 999
            End Select

            For Each oCompocc In oInventorAssemblyDocument.ComponentDefinition.Occurrences
                If oCompocc.Definition.BOMStructure = kPurchasedBOMStructure Then
                    oCompocc.Visible = IsVisible
                End If
            Next

999:
            ''打开屏幕更新
            'ThisApplication.ScreenUpdating = True

            '刷新浏览器
            oInventorAssemblyDocument.BrowserPanes.ActivePane.Refresh()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '替换为库文件
    Public Sub ReplaceWithContentCenterFile()
        Try
            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            SetStatusBarText()

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                'Return False
                Exit Sub
            End If

            Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
            oInventorAssemblyDocument = ThisApplication.ActiveDocument

            '关闭屏幕更新
            'ThisApplication.ScreenUpdating = False

            '==============================================================================================
            '基于bom结构化数据，可跳过参考的文件
            ' Set a reference to the BOM
            Dim oBOM As BOM
            oBOM = oInventorAssemblyDocument.ComponentDefinition.BOM
            oBOM.StructuredViewEnabled = True
            oBOM.StructuredViewFirstLevelOnly = True

            'Set a reference to the "Structured" BOMView
            Dim oBOMView As BOMView

            '获取结构化的bom页面
            For Each oBOMView In oBOM.BOMViews
                If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                    '遍历这个bom页面

                    'Dim i As Integer
                    'Dim intStepCount As Integer
                    'intStepCount = oBOMView.BOMRows.Count

                    Dim oBOMRow As BOMRow   '每一行bom

                    For Each oBOMRow In oBOMView.BOMRows

                        Dim strFullFileName As String

                        strFullFileName = oBOMRow.ReferencedFileDescriptor.FullFileName

                        '测试文件
                        Debug.Print(strFullFileName)


                        SetStatusBarText(strFullFileName)

                        If IsFileExsts(strFullFileName) = False Then   '跳过不存在的文件
                            Continue For
                        End If

                        If InStr(strFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                            Continue For
                        End If

                        Dim oFileNameInfo As FileNameInfo
                        oFileNameInfo = GetFileNameInfo(strFullFileName)

                        Dim arrFullFileName As String()
                        Dim strContentCenterFileFullFileName As String = Nothing
                        arrFullFileName = Directory.GetFiles(ContentCenterFiles, oFileNameInfo.SigleName, SearchOption.AllDirectories)

                        If arrFullFileName.Length <> 0 Then
                            strContentCenterFileFullFileName = arrFullFileName(0)

                            Dim oCompocc As ComponentOccurrence
                            For Each oCompocc In oInventorAssemblyDocument.ComponentDefinition.Occurrences
                                If oCompocc.ReferencedDocumentDescriptor.FullDocumentName = strFullFileName Then
                                    oCompocc.Replace(strContentCenterFileFullFileName, False)
                                End If
                            Next
                        End If

                    Next

                End If
            Next
            '==============================================================================================


            ''打开屏幕更新
            'ThisApplication.ScreenUpdating = True

            '刷新浏览器
            oInventorAssemblyDocument.BrowserPanes.ActivePane.Refresh()

            MsgBox("替换为库文件完成。", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub


    '创建展开图
    Public Sub CreateFlat()
        On Error Resume Next

        'Try
        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        SetStatusBarText()

        Dim oInventorDocument As Inventor.Document
        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        Dim oInventorPartDocument As Inventor.PartDocument

        oInventorDocument = ThisApplication.ActiveDocument

        Dim strBasicIdwFileFullName As String
        strBasicIdwFileFullName = TitleBlockIdwDoc    '工程图模板

        If IsFileExsts(strBasicIdwFileFullName) = False Then
            Dim oOpenFileDialog As New OpenFileDialog '声名新open 窗口

            MsgBox("未找到工程图模板：" & vbCrLf & strBasicIdwFileFullName & vbCrLf & "请选择工程图模板文件。", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

            With oOpenFileDialog
                .Title = "打开工程图模板文件"
                .Filter = "AutoDesk Inventor 工程图 (*.idw)|*.idw" '添加过滤文件
                .Multiselect = False  '多开文件打开
                If .ShowDialog = System.Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                    If .FileName <> "" Then '如果有选中文件
                        strBasicIdwFileFullName = .FileName
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End With

        End If

        Dim strInventorDrawingFolder As String = Nothing
        Select Case MsgBox("是否指定保存展开图文件夹？不指定则保存到当前文件夹。", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)
            Case MsgBoxResult.Yes
                Dim oFolderBrowserDialog As New FolderBrowserDialog

                With oFolderBrowserDialog
                    .ShowNewFolderButton = False
                    .Description = "选择文件夹"
                    .RootFolder = System.Environment.SpecialFolder.Desktop
                    If .ShowDialog = DialogResult.OK Then
                        strInventorDrawingFolder = .SelectedPath
                    Else
                        Exit Sub
                    End If
                End With

            Case MsgBoxResult.No
                strInventorDrawingFolder = "当前文件夹"
            Case MsgBoxResult.Cancel
                Exit Sub
        End Select


        Dim IsClose As Boolean
        Select Case MsgBox("创建工程图后是否关闭？", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)
            Case MsgBoxResult.Yes
                IsClose = True
            Case MsgBoxResult.No
                IsClose = False
            Case MsgBoxResult.Cancel
                Exit Sub
        End Select

        Select Case oInventorDocument.DocumentType
            Case kAssemblyDocumentObject

                oInventorAssemblyDocument = oInventorDocument

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
                        Dim i As Integer

                        Dim intStepCount As Integer
                        intStepCount = oBOMView.BOMRows.Count

                        For i = 1 To intStepCount
                            ' Get the current row.
                            Dim oBOMRow As BOMRow
                            oBOMRow = oBOMView.BOMRows.Item(i)

                            Dim strFullFileName As String
                            strFullFileName = oBOMRow.ReferencedFileDescriptor.FullFileName

                            '测试文件
                            Debug.Print(strFullFileName)

                            ' Set the message for the progress bar
                            'oProgressBar.Message = oFullFileName

                            If IsFileExsts(strFullFileName) = False Then   '跳过不存在的文件
                                GoTo 999
                            End If

                            If InStr(strFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                                GoTo 999
                            End If

                            If oBOMRow.ReferencedFileDescriptor.ReferencedFileType = FileTypeEnum.kPartFileType Then

                                'oInventorPartDocument = ThisApplication.Documents.Open(strFullFileName, False)  '打开文件，不显示

                                oInventorPartDocument = ThisApplication.Documents.ItemByName(strFullFileName)
                                CreateFlatSub(oInventorPartDocument, strBasicIdwFileFullName, strInventorDrawingFolder, IsClose)
                            End If
999:
                        Next
                    End If
                Next
                MsgBox("钣金件批量生成展开图完成。", MsgBoxStyle.Information)

            Case kPartDocumentObject
                oInventorPartDocument = oInventorDocument
                CreateFlatSub(oInventorPartDocument, strBasicIdwFileFullName, strInventorDrawingFolder, IsClose)
        End Select



        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub

    '创建展开图sub
    Public Sub CreateFlatSub(ByVal oInventorDocument As Inventor.PartDocument, ByVal strBasicIdwFileFullName As String, _
                             ByVal strInventorDrawingFolder As String, ByVal IsClose As Boolean)
        On Error Resume Next

        Dim oBaseViewOptions As NameValueMap = ThisApplication.TransientObjects.CreateNameValueMap
        Dim oTG As TransientGeometry = ThisApplication.TransientGeometry
        Dim oPoint As Point2d

        'Check to see if part is a sheetmetal part
        If (oInventorDocument.SubType <> "{9C464203-9BAE-11D3-8BAD-0060B0CE6BB4}") Then
            Exit Sub
        End If

        Dim oSMDef As SheetMetalComponentDefinition
        oSMDef = oInventorDocument.ComponentDefinition
        If oSMDef.HasFlatPattern = False Then
            'create flat pattern
            ThisApplication.ScreenUpdating = False
            oSMDef.Unfold()
            oSMDef.FlatPattern.ExitEdit()
            ThisApplication.ScreenUpdating = True
        End If

        Dim oFlatPattern As FlatPattern
        Dim intFlatExtentsLength As Double    '"展开长"  转换单位为mm
        Dim intFlatExtentsWidth As Double       '展开宽
        oFlatPattern = oSMDef.FlatPattern
        intFlatExtentsLength = oFlatPattern.Length * 10
        intFlatExtentsWidth = oFlatPattern.Width * 10


        Dim douScale As Double
        If intFlatExtentsLength > intFlatExtentsWidth Then
            douScale = 150 / intFlatExtentsLength
        Else
            douScale = 150 / intFlatExtentsWidth
        End If

        If douScale > 1 Then
            douScale = 1
        End If

        oPoint = oTG.CreatePoint2d(12, 18)

        oBaseViewOptions.Add("SheetMetalFoldedModel", False)

        Dim oInventorDrawingDocument As Inventor.DrawingDocument

        oInventorDrawingDocument = ThisApplication.Documents.Add(DocumentTypeEnum.kDrawingDocumentObject, strBasicIdwFileFullName)
        Dim oSheet As Sheet = oInventorDrawingDocument.ActiveSheet
        Dim oBaseView As DrawingView = oSheet.DrawingViews.AddBaseView(oInventorDocument, oPoint, douScale,
                ViewOrientationTypeEnum.kDefaultViewOrientation,
                DrawingViewStyleEnum.kHiddenLineRemovedDrawingViewStyle,
                , , oBaseViewOptions)

        Dim strInventorDocumentFullFileName As String
        strInventorDocumentFullFileName = oInventorDocument.FullFileName

        Dim oFileNameInfo As FileNameInfo
        oFileNameInfo = GetFileNameInfo(strInventorDocumentFullFileName)

        If strInventorDrawingFolder = "当前文件夹" Then
            strInventorDrawingFolder = oFileNameInfo.Folder
        End If

        strInventorDrawingFolder = strInventorDrawingFolder & "\钣金展开\"
        If IsDirectoryExists(strInventorDrawingFolder) = False Then
            IO.Directory.CreateDirectory(strInventorDrawingFolder)
        End If

        Dim strInventorDrawingDocumentFullFileName As String

        strInventorDrawingDocumentFullFileName = strInventorDrawingFolder & oFileNameInfo.OnlyName & "-展开.idw"

        If GetFileReadOnly(strInventorDocumentFullFileName) = False Then
            oInventorDocument.Save2()
        End If


        oInventorDrawingDocument.SaveAs(strInventorDrawingDocumentFullFileName, False)
        oInventorDrawingDocument.Save2()

        If IsClose = True Then
            oInventorDrawingDocument.Close()
        End If
        ''oInventorDocument.Close()
    End Sub

End Module