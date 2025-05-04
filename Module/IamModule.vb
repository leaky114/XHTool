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
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Linq
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
                MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'Return False
                Exit Sub
            End If

            Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
            oInventorAssemblyDocument = ThisApplication.ActiveDocument

            Dim strPartDrawingNnumber As String

            Dim frmInputBox As New FormInputBox
999:
            strPartDrawingNnumber = GetPropitem(oInventorAssemblyDocument, Map_DrawingNnumber)
            strPartDrawingNnumber = RemoveTrailingZeros(strPartDrawingNnumber)

            With frmInputBox
                .txt输入.Text = strPartDrawingNnumber
                .Text = "检查包含指定字符的工程图"
                .lbl描述.Text = "输入要检查的部分图号。"     '  & vbCrLf & "如要检查全部AAA-BBB000下的零件是否有工程图，输入AAA-BBB即可。"
                .StartPosition = FormStartPosition.CenterScreen
                strPartDrawingNnumber = .txt输入.Text
                .txt输入.SelectAll()
                .ShowDialog()
            End With

            strPartDrawingNnumber = frmInputBox.txt输入.Text

            If (frmInputBox.DialogResult = System.Windows.Forms.DialogResult.OK) And (strPartDrawingNnumber <> "") Then
                If CheckIsInvHaveIdwSub(oInventorAssemblyDocument, frmInputBox.txt输入.Text) Then
                    MessageBox.Show("检查是否有工程图完成，打开了未找到工程图对应的模型文件。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information)
                Else
                    SetStatusBarText(XHTool)
                    ' MessageBox.Show(XHTool, MsgBoxStyle.Exclamation)
                End If
            ElseIf frmInputBox.DialogResult = System.Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            Else
                MessageBox.Show("请输入部分图号。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning)
                SetStatusBarText(XHTool)
                GoTo 999
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ''' <summary>
    ''' '检查部件是否有对应的工程图
    ''' </summary>
    ''' <param name="oInventorAssemblyDocument">部件文档对象</param>
    ''' <param name="StrInName">需要查找的字符串</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' 检查部件是否有对应的工程图遍历子过程
    ''' </summary>
    ''' <param name="oBOMRows">遍历的BOM</param>
    ''' <param name="strInName">需要查找的字符串</param>
    ''' <remarks></remarks>
    Public Sub CheckIsInvHaveIdwChildSub(ByVal oBOMRows As BOMRowsEnumerator, ByVal strInName As String)
        For Each oRow As BOMRow In oBOMRows
            Dim oComponentDefinition As ComponentDefinition
            oComponentDefinition = oRow.ComponentDefinitions.Item(1)

            Dim oInventorDocument As Inventor.Document
            oInventorDocument = oComponentDefinition.Document

            Dim strInventorFullFileName As String   '模型文件
            strInventorFullFileName = oInventorDocument.FullFileName

            Dim strInventorFileName As String   '模型文件
            strInventorFileName = GetFileNameWithExtension(strInventorFullFileName)

            If IsFileExists(strInventorFullFileName) = False Then   '跳过不存在的文件
                Continue For
            End If

            If InStr(strInventorFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                Continue For
            End If

            '检查收否含有指定的字符串
            If InStr(Strings.LCase(strInventorFileName), Strings.LCase(strInName)) = 0 Then
                Continue For
            End If

            Dim strDrawingFullFileName As String  '工程图全文件名
            strDrawingFullFileName = Strings.Replace(strInventorFullFileName, GetFileExtensionLCase(strInventorFullFileName), IDW)

            If IsFileExists(strDrawingFullFileName) = False Then
                ThisApplication.Documents.Open(strInventorFullFileName)
            End If

            '      遍历下一级
            If oRow.ChildRows IsNot Nothing Then
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
                MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'Return False
                Exit Sub
            End If

            Dim oInventorFile As Inventor.File
            oInventorFile = ThisApplication.ActiveDocument.File

            If GetMissDocumentSub(oInventorFile) Then
                SetStatusBarText("查找缺失文件的部件完成")
            Else
                SetStatusBarText(XHTool)
                ' MessageBox.Show(XHTool, MsgBoxStyle.Exclamation)

            End If
            MessageBox.Show("查找缺失文件的部件完成。", XHTool, MessageBoxButtons.OK， MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' 获取未读取的文件所在部件并打开该部件  
    ''' </summary>
    ''' <param name="oInventorFile">部件文件对象</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetMissDocumentSub(ByVal oInventorFile As Inventor.File) As Boolean
        For Each oFileDescriptor As FileDescriptor In oInventorFile.ReferencedFileDescriptors

            'Debug.Print(oFileDescriptor.FullFileName)

            If Not oFileDescriptor.ReferenceMissing Then
                ' Since the ReferenceMissing has returned False, the ReferencedFile will return a File
                ' Recurse unless this is a foreign file reference
                If Not oFileDescriptor.ReferencedFileType = FileTypeEnum.kForeignFileType Then
                    GetMissDocumentSub(oFileDescriptor.ReferencedFile)
                End If
            Else
                Dim oPresentFullFileName As String
                oPresentFullFileName = oFileDescriptor.Parent.FullFileName
                If IsFileExists(oPresentFullFileName) Then
                    ThisApplication.Documents.Open(oPresentFullFileName, True)
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
            MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
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


            FlushXYZPlaneSub(InventorDocument, oComponentOccurrence1, oComponentOccurrence2)


            SetStatusBarText("对齐原始坐标面")

            'end the transactio
            createSlotTransaction.End()
        Catch ex As Exception
            SetStatusBarText(XHTool)
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function


    ''' <summary>
    ''' 对齐原始坐标面
    ''' </summary>
    ''' <param name="OInventorAssemblyDocument">操作的部件</param>
    ''' <param name="oComponentOccurrence1">第一个组件</param>
    ''' <param name="oComponentOccurrence2">第二个组件</param>
    ''' <param name="IsDelMate">对齐后是否删除约束，默认不删除</param>
    Public Sub FlushXYZPlaneSub(ByVal OInventorAssemblyDocument As Inventor.AssemblyDocument,
                                     ByVal oComponentOccurrence1 As ComponentOccurrence,
                                     ByVal oComponentOccurrence2 As ComponentOccurrence, Optional ByVal IsDelMate As Boolean = False)
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

            oMate = OInventorAssemblyDocument.ComponentDefinition.Constraints.AddFlushConstraint(oAsmPlane1, oAsmPlane2, 0)

            If IsDelMate = True Then
                oMate.Delete()
            End If

        Next


    End Sub



    '移动指定文件
    Public Sub MovesSpecifiedFile()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'Return False
                Exit Sub
            End If

            Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
            oInventorAssemblyDocument = ThisApplication.ActiveDocument
999:
            Dim frmInputBox As New FormInputBox

            Dim strSearchNnumber As String
            strSearchNnumber = GetPropitem(oInventorAssemblyDocument, Map_DrawingNnumber)
            strSearchNnumber = RemoveTrailingZeros(strSearchNnumber)

            With frmInputBox
                .txt输入.Text = strSearchNnumber
                .Text = "移动文件"
                .lbl描述.Text = "将保存并关闭当前文档，移动包含指定的字符文件名的文件到当前部件文件夹。"
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
            End With

            If frmInputBox.DialogResult = System.Windows.Forms.DialogResult.OK And frmInputBox.txt输入.Text <> "" Then
                strSearchNnumber = frmInputBox.txt输入.Text
            ElseIf frmInputBox.DialogResult = System.Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            Else
                MessageBox.Show("请输入部分图号。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning)
                SetStatusBarText(XHTool)
                GoTo 999
                Exit Sub
            End If

            ' 获取所有引用文档
            Dim oInventorDocumentsEnumerator As Inventor.DocumentsEnumerator
            oInventorDocumentsEnumerator = oInventorAssemblyDocument.AllReferencedDocuments

            ' 遍历这些文档

            Dim strReferencedFullFileNames() As String

            ReDim strReferencedFullFileNames(oInventorDocumentsEnumerator.Count - 1)

            Dim i As Integer = 0

            For Each oInventorDocument As Inventor.Document In oInventorDocumentsEnumerator
                Debug.Print(oInventorDocument.FullFileName)
                strReferencedFullFileNames(i) = oInventorDocument.FullFileName
                i += 1
            Next

            Dim strInventorAssemblyDocumentFullFileName As String
            strInventorAssemblyDocumentFullFileName = oInventorAssemblyDocument.FullDocumentName

            '组件所在文件夹
            Dim strInventorAssemblyFileFolder As String
            strInventorAssemblyFileFolder = GetFileNameInfo(strInventorAssemblyDocumentFullFileName).Folder

            '保存关闭组件
            oInventorAssemblyDocument.Close()

            For Each strReferencedFullFileName As String In strReferencedFullFileNames

                ThisApplication.StatusBarText = strReferencedFullFileName

                Dim strReferencedFileName As String
                strReferencedFileName = GetFileNameWithExtension(strReferencedFullFileName)

                '对比文件名
                If InStr(strReferencedFileName, strSearchNnumber) <> 0 Then

                    Dim strNewReferencedFullFileName As String
                    strNewReferencedFullFileName = IO.Path.Combine(strInventorAssemblyFileFolder, strReferencedFileName)

                    If IsFileExists(strNewReferencedFullFileName) Then
                        If MessageBox.Show("存在文件：" & strNewReferencedFullFileName & "，是否覆盖？", XHTool， MessageBoxButtons.YesNo，
                                           MessageBoxIcon.Question) = DialogResult.Yes Then
                        Else
                            Continue For
                        End If
                    End If

                    SetStatusBarText("正在移动：" & strReferencedFullFileName & " 到 " & strInventorAssemblyFileFolder)
                    ReMoveFileToFolder(strReferencedFullFileName, strInventorAssemblyFileFolder)

                    Dim strInventorDrawingFullFileName As String
                    strInventorDrawingFullFileName = GetChangeExtension(strReferencedFullFileName, IDW)

                    If IsFileExists(strInventorDrawingFullFileName) = True Then
                        Dim strNewReferencedDrawingFullFileName As String = Nothing
                        strNewReferencedDrawingFullFileName = GetChangeExtension(strNewReferencedDrawingFullFileName, IDW)

                        If IsFileExists(strNewReferencedDrawingFullFileName) Then
                            If MessageBox.Show("存在文件：" & strNewReferencedDrawingFullFileName & "，是否覆盖？", XHTool，
                                                MessageBoxButtons.YesNo， MessageBoxIcon.Question) = DialogResult.Yes Then
                            Else
                                Continue For
                            End If

                        End If
                        SetStatusBarText("正在移动：" & strInventorDrawingFullFileName & " 到 " & strInventorAssemblyFileFolder)
                        ReMoveFileToFolder(strInventorDrawingFullFileName, strInventorAssemblyFileFolder)
                    End If

                End If
            Next

            If MessageBox.Show("移动指定文件完成，是否重新打开 " & strInventorAssemblyDocumentFullFileName, XHTool，
                                                MessageBoxButtons.YesNo， MessageBoxIcon.Question) = DialogResult.Yes Then
                ThisApplication.Documents.Open(strInventorAssemblyDocumentFullFileName)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                ' MessageBox.Show("提取iproperty更改文件名完成", MsgBoxStyle.Information)
            Else
                SetStatusBarText(XHTool)
                MessageBox.Show("提取iproperty更改文件名错误。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '提取iproperty更改文件名
    Public Function GetIpropertyToRenameSub(ByVal oInventorDocument As Inventor.Document, ByVal oOldComponentOccurrence As ComponentOccurrence) As Boolean
        Dim strOldFullFileName As String   '被替换的旧文件全名
        Dim strOldFileName As String   '被替换的旧文件仅文件名
        strOldFullFileName = oOldComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName
        strOldFileName = GetFileNameInfo(strOldFullFileName).OnlyName

        If IsFileExists(strOldFullFileName) = False Then
            MessageBox.Show("文件： " & strOldFullFileName & "不存在！", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning)
            Return True
            Exit Function
        End If

        If InStr(strOldFullFileName, ContentCenterFiles) > 0 Then         '跳过零件库文件
            MessageBox.Show("无法修改资源中心文件： " & strOldFullFileName, XHTool, MessageBoxButtons.OK， MessageBoxIcon.Warning)
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
                            oStockNumPartName.零件名称 = propitem.Value
                        Case Map_DrawingNnumber
                            oStockNumPartName.图号 = propitem.Value
                        Case "描述"
                            ' propitem.Value = ""
                    End Select
                Next

                '新文件名
                strNewFileName = oStockNumPartName.图号 & oStockNumPartName.零件名称

                '替换旧文件全名为新文件全名
                strNewFullFileName = GetChangeFileName(strOldFullFileName, strNewFileName)

                If strNewFullFileName = strOldFullFileName Then
                    MessageBox.Show("iProperty与文件名匹配，无需重命名文件！", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information)
                    '关闭旧图,不保存
                    oOldInventorDocument.Close(True)
                    Return True
                End If

                '检查新文件是否存在
                If IsFileExists(strNewFullFileName) = True Then
                    Select Case MessageBox.Show("存在文件：" & strNewFullFileName & " ，是-直接替换  否-重新生成替换  取消-退出重新命名 ", XHTool，
                                                MessageBoxButtons.YesNoCancel， MessageBoxIcon.Question)
                        Case DialogResult.Yes  '直接用新文件替换
                            '全部替换为新文件
                            'if  MessageBox.Show("是否替换全部零件？", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.SystemModal) = MsgBoxResult.Yes Then
                            oOldComponentOccurrence.Replace(strNewFullFileName, True)
                            'Else
                            'OldOcc.Replace(NewFullFileName, False)
                            'End if
                            oOldInventorDocument.Close(True)
                            Return True
                        Case DialogResult.No    '重新另存为新文件，再替换

                        Case DialogResult.Cancel   '取消退出
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

                If IsFileExists(strOldDrawingFullFileName) = True Then
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
            Case MessageBox.Show("选择的文件不是零件或部件", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning)
                Return False
        End Select
    End Function



    ''' <summary>
    ''' 设置随机颜色
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetClearRandomColor()

        Select Case MessageBox.Show("设置随机颜色。" & vbCrLf & vbCrLf & "是——设置随机颜色" & vbCrLf & vbCrLf & "否——清除随机颜色", XHTool，
                                       MessageBoxButtons.YesNoCancel， MessageBoxIcon.Question)
            Case DialogResult.Yes
                SetRandomColor()
            Case DialogResult.No
                ClearRandomColor()
        End Select

    End Sub


    '设值随机颜色
    Public Sub SetRandomColor()

        'Try
        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
            MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
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


        Dim oName = "随机色"
        Dim oInventorPartDocument As Inventor.PartDocument = Nothing
        Dim oAppearance As Asset = Nothing
        '每个零件添加颜色

        On Error Resume Next

        For Each oInventorDocument As Inventor.Document In oInventorAssemblyDocument.AllReferencedDocuments
            If oInventorDocument.DocumentType = kPartDocumentObject Then
                oInventorPartDocument = oInventorDocument
                oAppearance = oInventorPartDocument.ActiveAppearance
                If Not oAppearance.DisplayName = oName Then
                    '尝试是否存在“配置色”外观
                    oAppearance = oInventorPartDocument.AppearanceAssets.Item(oName)
                    '如果名字不存在则，创建名为"配置色"的新外观(没有多状态的零件)
                    oAppearance = oInventorPartDocument.Assets.Add(kAssetTypeAppearance, "Generic", "Appearances", oName)
                    '将新外观设置为激活状态
                    oInventorPartDocument.ActiveAppearance = oAppearance
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
            oInventorPartDocument.Close(False)
        Next
        oInventorAssemblyDocument.Document.Rebuild()
        oTransaction.End()
        ThisApplication.ScreenUpdating = True

        ThisApplication.CommandManager.ControlDefinitions.Item("AppZoomAllCmd").Execute()

        'Catch ex As Exception
        '       MessageBox.Show(ex.Message, xhtool, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'Return False
            Exit Sub
        End If

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument

        '设置为一个动作, 可一次撤销
        Dim oTransaction As Transaction
        oTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "My Transaction")

        ThisApplication.ScreenUpdating = False

        Dim oName = "随机色"

        Dim oAppearance As Asset = Nothing
        '每个零件添加颜色

        On Error Resume Next

        For Each oInventorDocument In oInventorAssemblyDocument.AllReferencedDocuments
            If oInventorDocument.DocumentType = kPartDocumentObject Then
                Dim oModelStates = oInventorDocument.ComponentDefinition.ModelStates
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
                    oInventorDocument.AppearanceSourceType = AppearanceSourceTypeEnum.kMaterialAppearance
                End If

                If oInventorDocument.AppearanceAssets.Item(oName).IsUsed = False Then
                    oInventorDocument.AppearanceAssets.Item(oName).Delete()
                End If
            End If
        Next

        oInventorAssemblyDocument.Document.Rebuild()
        oTransaction.End()
        ThisApplication.ScreenUpdating = True

        Call ThisApplication.CommandManager.ControlDefinitions.Item("AppZoomAllCmd").Execute()

        'Catch ex As Exception
        '       MessageBox.Show(ex.Message, xhtool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    '设置当前部件下级为虚拟件
    Public Sub SetBOMStructuret()

        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
            oInventorAssemblyDocument = ThisApplication.ActiveDocument

            If SetBOMStructuretsub(oInventorAssemblyDocument) Then
                SetStatusBarText(" 设置BOM结构完成")
                ' MessageBox.Show("设置工程图自定义属性：比例完成", MsgBoxStyle.Information)
            Else
                SetStatusBarText(XHTool)
                ' MessageBox.Show(XHTool, MsgBoxStyle.Exclamation)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '设置当前部件下级为虚拟件
    Public Function SetBOMStructuretsub(ByVal oInventorAssemblyDocument As Inventor.AssemblyDocument) As Boolean
        '设置结构类型
        Dim BOMStructureType As BOMStructureEnum

        Dim strBOMStructureType As String
        strBOMStructureType = InputBox("将本部件所属零部件设置为【普通件】或【虚拟件】。输入要设置的类型：" & vbCrLf & vbCrLf &
                                       "1——普通件" & vbCrLf & vbCrLf &
                                       "2——虚拟件" & vbCrLf & vbCrLf &
                                       "3——外购件",
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
            'if Not oBOMRow.ChildRows Is Nothing Then
            '    Call SetPhantomBOMStructuretSub(oBOMRow.ChildRows, BOMStructureType)
            'End if

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
                MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else
                Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
                oInventorAssemblyDocument = ThisApplication.ActiveDocument

                Dim strCsvFullFileName As String

                strCsvFullFileName = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop, GetFileNameInfo(oInventorAssemblyDocument.FullFileName).OnlyName & "导出BOM.csv")

                If IsFileExists(strCsvFullFileName) = True Then
                    DeleteFile2(strCsvFullFileName, FileIO.RecycleOption.SendToRecycleBin)
                End If

                Dim IsExpandOutSourcedParts As Boolean

                Select Case MessageBox.Show("是否展开外协件、外购件？", XHTool,
                                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    Case DialogResult.Yes
                        IsExpandOutSourcedParts = True
                    Case DialogResult.No
                        IsExpandOutSourcedParts = False
                    Case DialogResult.Cancel
                        Exit Sub
                End Select

                Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
                OInteractionEvents.Start()
                OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
                'System.Threading.Thread.Sleep(5000)

                ExportBOMAsFlatSub(oInventorAssemblyDocument, strCsvFullFileName, IsExpandOutSourcedParts)

                'OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeDefault)
                OInteractionEvents.Stop()

                SetStatusBarText(" 导出BOM平面性完成")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ''' <summary>
    ''' 导出 bom 平面性
    ''' </summary>
    ''' <param name="oInventorAssemblyDocument">部件对象</param>
    ''' <param name="strCsvFullFileName">excel文件</param>
    ''' <param name="IsExpandOutSourcedParts">是否展开外协外购件</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExportBOMAsFlatSub(ByVal oInventorAssemblyDocument As Inventor.AssemblyDocument, ByVal strCsvFullFileName As String,
                                    ByVal IsExpandOutSourcedParts As Boolean) As Boolean


        'Dim stopwatch As New Stopwatch()
        'stopwatch.Start()  ' 开始计时


        If IsFileExists(strCsvFullFileName) = True Then
            DeleteFile2(strCsvFullFileName, FileIO.RecycleOption.SendToRecycleBin)
        End If

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


        '写BOM表头
        Dim strColumnsTitle As String
        strColumnsTitle = "序号," & Strings.Replace(BOMTiTle, "|", ",")

        Debug.Print(strColumnsTitle & vbCrLf)

        Using oStreamWriter As New StreamWriter(strCsvFullFileName, False, oEncoding)   ' Encoding.Default)
            oStreamWriter.WriteLine(strColumnsTitle)
        End Using

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
        strExcelFullFileName = BasicFileSystem.GetChangeExtension(strCsvFullFileName, "xlsx")

        If IsFileExists(strExcelFullFileName) Then
            DeleteFile2(strExcelFullFileName, FileIO.RecycleOption.SendToRecycleBin)
        End If

        Dim oExcelApplication As Excel.Application
        oExcelApplication = New Excel.Application With {
            .Visible = False
        }

        Dim oWorkbook As Excel.Workbook
        oWorkbook = oExcelApplication.Workbooks.Open(strCsvFullFileName)

        '另存为xlsx格式
        DeleteFile2(strExcelFullFileName, FileIO.RecycleOption.SendToRecycleBin)
        oWorkbook.SaveAs(strExcelFullFileName, Excel.XlFileFormat.xlWorkbookDefault)
        oWorkbook.Close(False)



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

        'stopwatch.Stop()  ' 停止计时
        'Dim elapsedTime As TimeSpan = stopwatch.Elapsed  ' 获取经过的时间
        'Debug.Print(elapsedTime.TotalSeconds.ToString)


        '删除 csv
        DeleteFile2(strCsvFullFileName, FileIO.RecycleOption.SendToRecycleBin)

        SetStatusBarText("BOM导出到文件：" & vbCrLf & strExcelFullFileName)
        MessageBox.Show("BOM导出到文件：" & vbCrLf & strExcelFullFileName, XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information)

        Try
            Process.Start(strExcelFullFileName)
        Catch ex As Exception
            Process.Start("excel.exe", strExcelFullFileName)
        End Try


        Return True

    End Function


    ''' <summary>
    ''' 在 bom平面性导出，子程序
    ''' </summary>
    ''' <param name="strCsvFullFileName">excel文件</param>
    ''' <param name="oBOMRows">遍历bom </param>
    ''' <param name="FirstLevelOnly"></param>
    ''' <param name="strColumnsTitle">表头</param>
    ''' <param name="strLevel">bom的层级</param>
    ''' <param name="intPresentNumber">父级</param>
    ''' <param name="IsExpandOutSourcedParts">是否展开外协外购</param>
    ''' <remarks></remarks>
    Private Sub QueryBOMRowPropertieToExcel(ByVal strCsvFullFileName As String, ByVal oBOMRows As BOMRowsEnumerator,
                                            ByVal FirstLevelOnly As Boolean, ByVal strColumnsTitle As String,
                                            ByVal strLevel As String, ByVal intPresentNumber As Integer,
                                            ByVal IsExpandOutSourcedParts As Boolean)

        On Error Resume Next

        Dim i As Short
        Dim j As Short
        Dim iStepCount As Short
        iStepCount = oBOMRows.Count

        'Create a new ProgressBar object.
        'Dim oProgressBar As Inventor.ProgressBar

        'oProgressBar = ThisApplication.CreateProgressBar(False, iStepCount, "当前文件： ")

        '赋值数组
        Dim oBOMRowData(1, 1) As String

        ReDim oBOMRowData(oBOMRows.Count - 1, 1)

        Dim oBOMRow As BOMRow

        For i = 1 To oBOMRows.Count
            oBOMRow = oBOMRows.Item(i)
            oBOMRowData(i - 1, 0) = oBOMRow.ItemNumber
            oBOMRowData(i - 1, 1) = oBOMRow.ComponentDefinitions(1).Document.FullFileName
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


        '写数据到文件
        'Dim OStreamWriter As System.IO.StreamWriter

        Using OStreamWriter As New StreamWriter(strCsvFullFileName, True, oEncoding)

            '循环每一行
            For i = 0 To n
                '文件指针
                Dim strFilePointItemNumber As String

                strFilePointItemNumber = oBOMRowData(i, 1)

                '寻找指针的行，开始提取数据

                For j = 1 To oBOMRows.Count
                    oBOMRow = oBOMRows.Item(j)

                    Dim oComponentDefinitions As Inventor.ComponentDefinitionsEnumerator
                    oComponentDefinitions = oBOMRow.ComponentDefinitions

                    Dim oComponentDefinition As ComponentDefinition
                    oComponentDefinition = oComponentDefinitions.Item(1)

                    Dim strDocumentFullFileName As String
                    strDocumentFullFileName = oComponentDefinition.Document.FullDocumentName

                    '测试文件
                    Debug.Print(strDocumentFullFileName & vbCrLf)


                    If strDocumentFullFileName = strFilePointItemNumber Then
                        ' Set the message for the progress bar
                        'oProgressBar.Message = InventorDocFullFileName
                        If IsFileExists(strDocumentFullFileName) = False Then   '跳过不存在的文件
                            GoTo 999
                        End If

                        '数据操作
                        '========================================
                        '测试文件
                        'Debug.Print(ItemNumber & ":" & InventorDocFullFileName)

                        Dim oInventorDocument As Inventor.Document

                        oInventorDocument = ThisApplication.Documents.ItemByName(strDocumentFullFileName)

                        SetStatusBarText(strDocumentFullFileName)

                        Dim arrColumnsTitle() As String
                        Dim arrColumnsTitleValue() As String
                        arrColumnsTitle = Split(strColumnsTitle, "|")

                        ReDim arrColumnsTitleValue(arrColumnsTitle.Length)

                        'kPartNumberDesignTrackingProperties    零件代号
                        'kStockNumberDesignTrackingProperties   库存编号

                        Dim oPropertySets As PropertySets
                        Dim oPropertySet As PropertySet
                        oPropertySets = oInventorDocument.PropertySets
                        oPropertySet = oPropertySets.Item(3)

                        Dim propitem As [Property]
                        For k = 0 To arrColumnsTitle.Length - 1 Step 1
                            Select Case arrColumnsTitle(k)
                                Case "项目序号"
                                    arrColumnsTitleValue(k) = oBOMRow.ItemNumber.ToString
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
                                    'Dim strMass As String
                                    'strMass = GetMass(oInventorDocument).ToString
                                    'arrColumnsTitleValue(k) = strMass
                                    arrColumnsTitleValue(k) = FourFive(GetPropitem(oInventorDocument, "质量") * 0.001, Mass_Accuracy)
                                Case "面积"
                                    'Dim strArea As String
                                    'strArea = GetArea(oInventorDocument)
                                    'arrColumnsTitleValue(k) = strArea

                                    arrColumnsTitleValue(k) = FourFive(GetPropitem(oInventorDocument, "曲面面积"), Area_Accuracy)

                                Case "数量"
                                    arrColumnsTitleValue(k) = oBOMRow.ItemQuantity.ToString

                                Case "所属装配"
                                    Dim StockNumPartName As StockNumPartName
                                    StockNumPartName = GetStockNumPartName(oBOMRow.ReferencedFileDescriptor.Parent.FullFileName)
                                    arrColumnsTitleValue(k) = StockNumPartName.图号 & StockNumPartName.零件名称

                                Case "所属装配代号"
                                    Dim strParentInventorDocument As String
                                    strParentInventorDocument = oBOMRow.ReferencedFileDescriptor.Parent.FullFileName

                                    Dim oParentInventorDocument As Inventor.Document
                                    oParentInventorDocument = ThisApplication.Documents.ItemByName(strParentInventorDocument)
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
                                Case Map_Price    '成本
                                    arrColumnsTitleValue(k) = GetPropitem(oInventorDocument, Map_Price)

                                Case "总成本"
                                    arrColumnsTitleValue(k) = (GetPropitem(oInventorDocument, Map_Price) * oBOMRow.ItemQuantity * intPresentNumber).ToString
                                Case "文件名"
                                    arrColumnsTitleValue(k) = GetFileNameWithExtension(oInventorDocument.FullDocumentName)
                                Case "文件路径"
                                    arrColumnsTitleValue(k) = oInventorDocument.FullDocumentName
                                Case "Web"
                                    arrColumnsTitleValue(k) = GetPropitem(oInventorDocument, "目录 Web 链接")
                                Case Else   '其他 iproperty
                                    arrColumnsTitleValue(k) = GetPropitem(oInventorDocument, arrColumnsTitle(k))
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
                        TotalItem += 1

                        '测试数据
                        Debug.Print(strColumnsTitleValue & vbCrLf)


                        'If IsFileExists(strCsvFullFileName) = False Then
                        '    IOS = New IO.StreamWriter(strCsvFullFileName, False, System.Text.Encoding.Unicode)
                        'Else
                        'OStreamWriter = New StreamWriter(strCsvFullFileName, True, Encoding.UTF8)
                        'End If
                        OStreamWriter.WriteLine(strColumnsTitleValue)
                        'IOS.Close()

                        '==========================================

999:
                        'oProgressBar.UpdateProgress()
                        Exit For
                    End If

                Next j

            Next i

            'Debug.Print("==================================")
            '写数据到文件

            'Dim oStreamWriter As System.IO.StreamWriter
            'If IsFileExists(strCsvFullFileName) = False Then
            '    oStreamWriter = New IO.StreamWriter(strCsvFullFileName, False, System.Text.Encoding.Default)
            'Else
            'OStreamWriter = New StreamWriter(strCsvFullFileName, True, Encoding.UTF8)
            'End If
            '写空白行
            OStreamWriter.WriteLine("")

            'OStreamWriter.Close()

        End Using

        For i = 0 To oBOMRowData.Length / 2 - 1
            For j = 1 To oBOMRows.Count
                oBOMRow = oBOMRows.Item(j)

                Dim strItemNumber As String
                strItemNumber = oBOMRow.ItemNumber


                Dim oComponentDefinitions As Inventor.ComponentDefinitionsEnumerator
                oComponentDefinitions = oBOMRow.ComponentDefinitions

                Dim oComponentDefinition As ComponentDefinition
                oComponentDefinition = oComponentDefinitions.Item(1)

                Dim strDocumentFullFileName As String
                strDocumentFullFileName = oComponentDefinition.Document.FullDocumentName


                If oBOMRowData(i, 1) = strDocumentFullFileName Then
                    '测试文件
                    'Debug.Print(ItemNumber & ":" & DocFullFileName)
                    ' Set the message for the progress bar
                    'oProgressBar.Message = DocFullFileName
                    'if IsFileExists(DocFullFileName) = False Then   '跳过不存在的文件
                    '    GoTo 99
                    'End if

                    '数据操作
                    '========================================

                    '==========================================

                    '遍历下一级
                    If (oBOMRow.ChildRows IsNot Nothing) And FirstLevelOnly = False Then

                        '检查为自制件就展开子级
                        Dim strVendor As String

                        Dim oInventorDocument As Inventor.Document
                        oInventorDocument = ThisApplication.Documents.ItemByName(strDocumentFullFileName)

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
            MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument

        Dim strPartDrawingNnumber As String

        strPartDrawingNnumber = GetPropitem(oInventorAssemblyDocument, Map_DrawingNnumber)
        strPartDrawingNnumber = RemoveTrailingZeros(strPartDrawingNnumber)

999:
        Dim frmInputBox As New FormInputBox
        With frmInputBox
            .txt输入.Text = strPartDrawingNnumber
            .Text = "打开指定工程图"
            .lbl描述.Text = "输入包含指定的字段的图号。" & vbCrLf & "如要打开 AAA-BBB000.aim 下的工程图，输入AAA-BBB即可。"
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With

        strPartDrawingNnumber = frmInputBox.txt输入.Text

        If (frmInputBox.DialogResult = System.Windows.Forms.DialogResult.OK) And (strPartDrawingNnumber <> "") Then
            If OpenAllDrwInAsmSub(oInventorAssemblyDocument, strPartDrawingNnumber) Then
                MessageBox.Show("打开了部件所有子集对应的工程图。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information)
            Else
                SetStatusBarText(XHTool)
            End If
        ElseIf frmInputBox.DialogResult = System.Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            MessageBox.Show("请输入部分图号。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning)
            SetStatusBarText(XHTool)
            GoTo 999
            Exit Sub
        End If
        'Catch ex As Exception
        '       MessageBox.Show(ex.Message, xhtool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

    End Sub

    '打开部件中所有子集对应的工程图 ，部件文件，指定的图号
    Public Function OpenAllDrwInAsmSub(ByVal oInventorAssemblyDocument As Inventor.AssemblyDocument, ByVal StrInName As String) As Boolean
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
                OpenAllDrwInAsmChildSub(oBOMView.BOMRows, StrInName)

            End If
        Next
        Return True

    End Function

    '打开部件中所有子集对应的工程图
    Public Sub OpenAllDrwInAsmChildSub(ByVal oBOMRows As BOMRowsEnumerator, ByVal StrInName As String)
        On Error Resume Next
        Dim i As Long

        For i = 1 To oBOMRows.Count
            Dim oBOMRow As BOMRow
            oBOMRow = oBOMRows.Item(i)

            Dim oComponentDefinition As ComponentDefinition
            oComponentDefinition = oBOMRow.ComponentDefinitions.Item(1)

            Debug.Print(oComponentDefinition.Document.FullFileName)

            Dim oInventorDocument As Inventor.Document
            oInventorDocument = oComponentDefinition.Document

            Dim strInventorFullFileName As String   '模型文件
            strInventorFullFileName = oInventorDocument.FullFileName

            Dim strInventorFileName As String   '模型文件
            strInventorFileName = GetFileNameWithExtension(strInventorFullFileName)

            If IsFileExists(strInventorFullFileName) = False Then   '跳过不存在的文件
                Continue For
            End If

            If InStr(strInventorFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                Continue For
            End If

            ''检查收否含有指定的字符串
            'If InStr(Strings.LCase(strInventorFileName), Strings.LCase(StrInName)) = 0 Then
            '    Continue For
            'End If

            Dim strDrawingFullFileName As String  '工程图全文件名
            '获取对应工程图文件名
            strDrawingFullFileName = GetChangeExtension(strInventorFullFileName, IDW)

            str模型匹配检查标记 = 1

            Select Case StrInName
                Case ""     '打开全部
                    '存在对于工程图，打开它
                    If IsFileExists(strDrawingFullFileName) = True Then
                        ThisApplication.Documents.Open(strDrawingFullFileName)
                    End If
                Case Else   '打开指定图号
                    If InStr(Strings.LCase(strInventorFileName), Strings.LCase(StrInName)) = 0 Then
                        Exit Select
                    End If

                    If IsFileExists(strDrawingFullFileName) = True Then
                        ThisApplication.Documents.Open(strDrawingFullFileName)
                    End If

            End Select

            str模型匹配检查标记 = 3

            '遍历下一级
            If oBOMRow.ChildRows IsNot Nothing Then
                Call OpenAllDrwInAsmChildSub(oBOMRow.ChildRows, StrInName)
            End If

        Next

    End Sub

    '更改文件名的零件或部件
    Public Sub RenamePartFileNameInAssembly()
        'Try
        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
            MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                strNewFileName = InputBox("重命名" & vbCrLf & vbCrLf & strOldFullFileNameName,   , strOldDocumentName)  '输入新文件名

                If strNewFileName = “” Then
                    Exit Sub
                End If

                Debug.Print(DateAndTime.Now)

                If Is检查重复图号 = "1" Then
                    Dim WorkSpaceFloder As String
                    WorkSpaceFloder = ThisApplication.DesignProjectManager.ActiveDesignProject.WorkspacePath

                    Dim strchkNewFileName As String

                    strchkNewFileName = strNewFileName & GetFileNameInfo(strOldFullFileNameName).ExtensionName

                    Dim arrFullFileName As String()
                    arrFullFileName = Directory.GetFiles(WorkSpaceFloder, strchkNewFileName, SearchOption.AllDirectories)

                    If arrFullFileName.Length = 0 Then
                        '没找到重复文件

                    Else
                        If MessageBox.Show("当前项目存在:" & vbCrLf & vbCrLf & arrFullFileName(0) & vbCrLf & vbCrLf & "是否退出？", XHTool，
                                            MessageBoxButtons.YesNo， MessageBoxIcon.Question， MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                            Exit Sub
                        End If
                    End If
                End If

                Debug.Print(DateAndTime.Now)

                If RenamePartFileNameInAssemblySub(oInventorAssemblyDocument, oOldComponentOccurrence, strNewFileName) Then
                    SetStatusBarText("更改零件/部件文件名完成")
                    ' MessageBox.Show("更改零件/部件文件名完成", MsgBoxStyle.Information)
                Else
                    SetStatusBarText(XHTool)
                    MessageBox.Show("更改零件/部件文件名错误", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error)
                End If
            Case Else

        End Select

        'Catch ex As Exception
        '       MessageBox.Show(ex.Message, xhtool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

    End Sub

    ''' <summary>
    ''' 更改零件/部件文件名子过程
    ''' </summary>
    ''' <param name="oInventorDocument">部件</param>
    ''' <param name="oOldComponentOccurrence">部件中需要更改文件名的组件</param>
    ''' <param name="strNewFileName">新的文件名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RenamePartFileNameInAssemblySub(ByVal oInventorDocument As Inventor.Document,
                                              ByVal oOldComponentOccurrence As ComponentOccurrence,
                                              ByVal strNewFileName As String) As Boolean

        Dim strOldFullFileName As String   '被替换的旧文件全名
        Dim strOldFileName As String   '被替换的旧文件仅文件名
        strOldFullFileName = oOldComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName
        strOldFileName = GetFileNameInfo(strOldFullFileName).OnlyName

        If IsFileExists(strOldFullFileName) = False Then
            MessageBox.Show("文件： " & strOldFullFileName & "不存在！", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning)
            Return True
            Exit Function
        End If

        'Dim oOccDef As PartComponentDefinition
        'oOccDef = OldOcc.Definition

        'if Not oOccDef.IsContentMember = False Then         '跳过零件库文件
        '     MessageBox.Show(OldFullFileName & "为零件库文件", MsgBoxStyle.Information)
        '    'OldInventorDoc.Close()
        '    Return False
        '    Exit Function
        'End if

        If InStr(strOldFullFileName, ContentCenterFiles) > 0 Then         '跳过零件库文件
            MessageBox.Show("无法修改资源中心文件： " & strOldFullFileName, XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning)
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
                End If

                '新旧文件名一致
                If strOldFileName = strNewFileName Then
                    MessageBox.Show("新旧文件名一致，请重新命名。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning)
                    Return True
                End If

                '替换旧文件全名为新文件全名
                strNewFullFileName = GetChangeFileName(strOldFullFileName, strNewFileName)

                '检查新文件是否存在
                If IsFileExists(strNewFullFileName) = True Then
                    Select Case MessageBox.Show("存在文件：" & vbCrLf & vbCrLf & strNewFullFileName & vbCrLf & vbCrLf &
                                       "是-直接替换" & vbCrLf & "否-重新生成替换" & vbCrLf & "取消-退出重新命名 ", XHTool，
                                         MessageBoxButtons.YesNoCancel， MessageBoxIcon.Question)
                        Case DialogResult.Yes  '直接用新文件替换
                            '全部替换为新文件
                            If MessageBox.Show("是否替换全部零件？", XHTool, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                oOldComponentOccurrence.Replace(strNewFullFileName, True)
                            Else
                                oOldComponentOccurrence.Replace(strNewFullFileName, False)
                            End If
                            Return True
                        Case DialogResult.No   '重新另存为新文件，再替换

                        Case DialogResult.Cancel    '取消退出
                            Return False
                    End Select
                End If

                Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
                OInteractionEvents.Start()
                OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
                ThisApplication.UserInterfaceManager.DoEvents()


                '打开旧文件,不显示
                SetStatusBarText("打开" & strOldFullFileName)
                Dim oOldInventorDocument As Inventor.Document
                oOldInventorDocument = ThisApplication.Documents.ItemByName(strOldFullFileName)



                '关闭存在的新文件
                CloseFile(strNewFullFileName)

                '另存为新文件
                SetStatusBarText("保存" & strNewFullFileName)
                oOldInventorDocument.SaveAs(strNewFullFileName, True)

                '关闭旧图
                oOldInventorDocument.Close()

                '全部替换为新文件
                SetStatusBarText("替换文件")
                If MessageBox.Show("是否替换全部零件？", XHTool, MessageBoxButtons.YesNo，
                                   MessageBoxIcon.Question， MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                    oOldComponentOccurrence.Replace(strNewFullFileName, True)
                Else
                    oOldComponentOccurrence.Replace(strNewFullFileName, False)
                End If

                ThisApplication.Documents.ItemByName(strOldFullFileName).Close()
                '后台打开文件，修改ipro

                oInventorDocument = ThisApplication.Documents.Open(strNewFullFileName, False)  '打开文件，不显示

                SetStatusBarText("设置新文件 IProperty。")

                SetPropitem(oInventorDocument, Map_ERPCode, "")
                SetDocumentIpropertyFromFileNameSub(oInventorDocument, True) '设置Iproperty，打开文件后需关闭

                Dim IsSaveAsOld As DialogResult
                IsSaveAsOld = MessageBox.Show("是否更改原文件为备份文件，扩展名增加 .old ？", XHTool， MessageBoxButtons.YesNo，
                                              MessageBoxIcon.Question， MessageBoxDefaultButton.Button2)

                '是否有对应的工程图文件，同时复制后修改文件名和模型链接
                Dim strOldIdwFullFileName As String

                'Dim strTempFullFileName As String       '更改旧模型文件的名字存档

                strOldIdwFullFileName = GetChangeExtension(strOldFullFileName, IDW)   '旧工程图

                If IsFileExists(strOldIdwFullFileName) = False Then
                    strOldIdwFullFileName = GetChangeExtensionDocument(oInventorDocument.FullDocumentName, IDW)
                End If

                If IsFileExists(strOldIdwFullFileName) = True Then

                    SetStatusBarText("复制新工程图。")

                    Dim strNewIdwFullFileName As String
                    strNewIdwFullFileName = GetChangeExtension(strNewFullFileName, IDW)   '新工程图

                    If IsFileExists(strNewIdwFullFileName) = True Then
                        If MessageBox.Show("存在旧的工程图：" & vbCrLf & vbCrLf & strNewIdwFullFileName & "，是否重新生成?", XHTool，
                                  MessageBoxButtons.YesNo， MessageBoxIcon.Question) = DialogResult.Yes Then  '选择覆盖

                            DeleteFile2(strNewIdwFullFileName, FileIO.RecycleOption.SendToRecycleBin)   '删除旧的新文件名 文件
                            FileSystem.FileCopy(strOldIdwFullFileName, strNewIdwFullFileName)             '复制为新工程图
                        Else
                            '不复制为新文件，用旧文件
                        End If
                    Else
                        FileSystem.FileCopy(strOldIdwFullFileName, strNewIdwFullFileName)             '复制为新工程图
                    End If

                    '替换工程图模型参考
                    ReplaceFileReference(strNewIdwFullFileName, strOldFullFileName, strNewFullFileName)

                    If (IsSaveAsOld = DialogResult.Yes) And (str变更工程图扩展名 = "1") Then
                        AddOldExtension(strOldIdwFullFileName)
                    End If

999:
                End If

                If IsSaveAsOld = DialogResult.Yes Then
                    AddOldExtension(strOldFullFileName)
                End If


                '刷新浏览器引用
                oOldComponentOccurrence.Name = ""

                '刷新引用
                'RefreshTreeNodeNameSub(ThisApplication.ActiveDocument)

                OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeDefault)
                OInteractionEvents.Stop()

                Return True
            Case MessageBox.Show("选择的文件不是零件或部件。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning)
                Return False
        End Select

    End Function

    '更改镜像零件/部件文件名
    Public Sub RenameMirrorPartFileNameInAssembly()
        'Try
        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
            MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                NewFileName = InputBox("镜像文件重命名 " & vbCrLf & vbCrLf & OldFullFileName, "", OldFileName)  '输入新文件名

                '取消输入
                If NewFileName = "" Then
                    Exit Sub
                End If

                If RenameMirrorPartFileNameInAssemblySub(oInventorAssemblyDocument, OldOcc, NewFileName) Then
                    SetStatusBarText("更改镜像零件/部件文件名完成")
                    ' MessageBox.Show("更改零件/部件文件名完成", MsgBoxStyle.Information)

                    '刷新引用
                    'RefreshTreeNodeNameSub(oInventorAssemblyDocument)
                Else
                    SetStatusBarText(XHTool)
                    MessageBox.Show("更改镜像零件/部件文件名错误。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）

                End If
            Case MessageBox.Show("选择的文件不是零件或部件。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning)

        End Select
        'Catch ex As Exception
        '       MessageBox.Show(ex.Message, xhtool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub


    ''' <summary>
    ''' 更改镜像零件文件名子过程
    ''' </summary>
    ''' <param name="oInventorDocument">部件文档</param>
    ''' <param name="oOldComponentOccurrence">需要更改的文档</param>
    ''' <param name="strNewFileName">新的文件名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Function RenameMirrorPartFileNameInAssemblySub(ByVal oInventorDocument As Inventor.Document,
                                                    ByVal oOldComponentOccurrence As ComponentOccurrence,
                                                    ByVal strNewFileName As String) As Boolean

        Dim strOldFullFileName As String   '被替换的旧文件全名
        strOldFullFileName = oOldComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName

        Dim strOldFileName As String   '被替换的旧文件仅文件名
        strOldFileName = GetFileNameInfo(strOldFullFileName).OnlyName

        If IsFileExists(strOldFullFileName) = False Then
            MessageBox.Show(strOldFullFileName & "不存在！", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning)
            Return True
            Exit Function
        End If

        'Dim oOccDef As PartComponentDefinition
        'oOccDef = OldOcc.Definition

        'if Not oOccDef.IsContentMember = False Then         '跳过零件库文件
        '     MessageBox.Show(OldFullFileName & "为零件库文件", MsgBoxStyle.Information)
        '    'OldInventorDoc.Close()
        '    Return False
        '    Exit Function
        'End if

        If InStr(strOldFullFileName, ContentCenterFiles) > 0 Then         '跳过零件库文件
            MessageBox.Show(strOldFullFileName & "为零件库文件，不支持更改名字。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning)
            'OldInventorDoc.Close()
            Return True
            Exit Function
        End If

        'Select Case OldOcc.DefinitionDocumentType
        '    Case kPartDocumentObject, kAssemblyDocumentObject      '选择的是部件或零件
        Dim strNewFullFileName As String   '新文件全名

        '替换旧文件全名为新文件全名
        strNewFullFileName = GetChangeFileName(strOldFullFileName, strNewFileName)

        '检查新文件是否存在
        If IsFileExists(strNewFullFileName) = True Then
            Select Case MessageBox.Show("存在文件：" & vbCrLf & vbCrLf & strNewFullFileName & vbCrLf & vbCrLf &
                               "是-直接替换" & vbCrLf & "否-重新生成替换" & vbCrLf & "取消-退出重新命名 ", XHTool，
                                MessageBoxButtons.YesNoCancel， MessageBoxIcon.Question)
                Case DialogResult.Yes   '直接用新文件替换
                    '全部替换为新文件
                    If MessageBox.Show("是否替换全部零件？", XHTool， MessageBoxButtons.YesNo， MessageBoxIcon.Question) = DialogResult.Yes Then
                        oOldComponentOccurrence.Replace(strNewFullFileName, True)
                    Else
                        oOldComponentOccurrence.Replace(strNewFullFileName, False)
                    End If

                    Return True
                Case DialogResult.No     '重新另存为新文件，再替换

                Case DialogResult.Cancel     '取消退出
                    Return False
            End Select
        End If

        '打开旧文件,不显示
        Dim oOldInventorDocument As Inventor.Document
        oOldInventorDocument = ThisApplication.Documents.ItemByName(strOldFullFileName)         'Open(strOldFullFileName, False)

        '=========================================================
        '另存为新文件
        oOldInventorDocument.SaveAs(strNewFullFileName, True)

        Dim oNewInventorDocument As Inventor.Document
        oNewInventorDocument = ThisApplication.Documents.Open(strNewFullFileName, False)

        '操作新文件，开始替换新基础文件
        If (Not LevelOfDetailIsMaster(oNewInventorDocument)) Then Return False


        Dim docToReplace As Inventor.Document = FindDocToReplace(oNewInventorDocument)
        If (docToReplace Is Nothing) Then Return False

        MessageBox.Show("选择 " & vbCrLf & vbCrLf & strNewFullFileName & "  的基础文件！", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information)
        Dim ReplacementFileName As String = SelectReplacementFilename(docToReplace.DisplayName)

        If (String.IsNullOrEmpty(ReplacementFileName)) Then Return False
        If (String.Equals(docToReplace.FullFileName, ReplacementFileName, StringComparison.OrdinalIgnoreCase)) Then Return False

        Dim ReplacementPart As Inventor.Document = ThisApplication.Documents.Open(ReplacementFileName, False)

        Dim doReplace As Boolean = True
        If (ReplacementPart.InternalName <> docToReplace.InternalName) Then
            MessageBox.Show("更换零件 (" & ReplacementPart.DisplayName & ") 似乎与原始零件关系不密切，因此无法使用。",
            XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            doReplace = False
        End If
        ReplacementPart.ReleaseReference()

        If (Not doReplace) Then Return False

        Dim FileNameToReplace As String = docToReplace.FullFileName
        ReplaceReferences(oNewInventorDocument, FileNameToReplace, ReplacementFileName)
        oOldInventorDocument.Update()

        '关闭旧图
        'oOldInventorDocument.Close()


        '全部替换为新文件

        If MessageBox.Show("是否替换全部零件？", XHTool， MessageBoxButtons.YesNo， MessageBoxIcon.Question） = DialogResult.Yes Then
            oOldComponentOccurrence.Replace(strNewFullFileName, True)
        Else
            oOldComponentOccurrence.Replace(strNewFullFileName, False)
        End If

        'ThisApplication.Documents.ItemByName(strOldFullFileName).Close()

        '后台打开文件，修改ipro
        'oInventorDocument = ThisApplication.Documents.Open(strNewFullFileName, False)  '打开文件，不显示

        SetDocumentIpropertyFromFileNameSub(oNewInventorDocument, True) '设置Iproperty，打开文件后需关闭

        '还原早一个版本的文件()
        'ReFileName(strReferencedFullFileNameTemp, strReferencedFullFileName)

        Return True
        '    Case  MessageBox.Show("选择的文件不是零件或部件", MsgBoxStyle.Information)
        'Return False
        'End Select

    End Function

    '更改镜像零件文件名
    Public Function RenameMirrorAssPartDocumentName(ByVal oInventorDocument As Inventor.Document,
                                                    ByVal oOldComponentOccurrence As ComponentOccurrence,
                                                    ByVal strNewFileName As String) As Boolean

        Dim strOldFullFileName As String   '被替换的旧文件全名
        strOldFullFileName = oOldComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName

        Dim strOldFileName As String   '被替换的旧文件仅文件名
        strOldFileName = GetFileNameInfo(strOldFullFileName).OnlyName

        If IsFileExists(strOldFullFileName) = False Then
            MessageBox.Show(strOldFullFileName & "不存在！", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning)
            Return True
            Exit Function
        End If

        'Dim oOccDef As PartComponentDefinition
        'oOccDef = OldOcc.Definition


        If InStr(strOldFullFileName, ContentCenterFiles) > 0 Then         '跳过零件库文件
            MessageBox.Show(strOldFullFileName & "为零件库文件。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning)
            'OldInventorDoc.Close()
            Return True
            Exit Function
        End If

        'Select Case OldOcc.DefinitionDocumentType
        '    Case kPartDocumentObject, kAssemblyDocumentObject      '选择的是部件或零件
        Dim strNewFullFileName As String   '新文件全名

        '替换旧文件全名为新文件全名
        strNewFullFileName = GetChangeFileName(strOldFullFileName, strNewFileName)

        '检查新文件是否存在
        If IsFileExists(strNewFullFileName) = True Then
            Select Case MessageBox.Show("存在文件：" & strNewFullFileName & vbCrLf & "是-直接替换" & vbCrLf & "否-重新生成替换" & vbCrLf & "取消-退出重新命名 ",
                                        XHTool， MessageBoxButtons.YesNoCancel， MessageBoxIcon.Question）
                Case DialogResult.Yes   '直接用新文件替换
                    '全部替换为新文件
                    If MessageBox.Show("是否替换全部零件？", XHTool， MessageBoxButtons.YesNo， MessageBoxIcon.Question) = DialogResult.Yes Then
                        oOldComponentOccurrence.Replace(strNewFullFileName, True)
                    Else
                        oOldComponentOccurrence.Replace(strNewFullFileName, False)
                    End If

                    Return True
                Case DialogResult.No    '重新另存为新文件，再替换

                Case DialogResult.Cancel    '取消退出
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

        If MessageBox.Show("是否替换全部零件？", XHTool， MessageBoxButtons.YesNo， MessageBoxIcon.Question) = DialogResult.Yes Then
            MessageBox.Show("选择 " & strNewFullFileName & "  的基础文件！", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information）
            oOldComponentOccurrence.Replace(strNewFullFileName, True)
        Else
            MessageBox.Show("选择 " & strNewFullFileName & "  的基础文件！", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information）
            oOldComponentOccurrence.Replace(strNewFullFileName, False)
        End If

        ThisApplication.Documents.ItemByName(strOldFullFileName).Close()
        '后台打开文件，修改ipro
        oInventorDocument = ThisApplication.Documents.Open(strNewFullFileName, False)  '打开文件，不显示

        SetDocumentIpropertyFromFileNameSub(oInventorDocument, True) '设置Iproperty，打开文件后需关闭

        '还原早一个版本的文件()
        ReFileName(strReferencedFullFileNameTemp, strReferencedFullFileName)

        Return True
        '    Case  MessageBox.Show("选择的文件不是零件或部件", MsgBoxStyle.Information)
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
                MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim strOldFileName As String
            Dim strNewFileName As String

            strOldFileName = InputBox("输入：查找的内容")
            If strOldFileName = "" Then
                Exit Sub
            End If

            strNewFileName = InputBox("输入：替换的内容")
            If strNewFileName = "" Then
                Exit Sub
            End If

            'OldName = "GT140"
            'NewName = "GT240"

            Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
            oInventorAssemblyDocument = ThisApplication.ActiveDocument

            Dim IsSaveAsOld As DialogResult
            IsSaveAsOld = MessageBox.Show("是否更改原文件为备份文件，扩展名增加 .old ？", XHTool， MessageBoxButtons.YesNo， MessageBoxIcon.Question， MessageBoxDefaultButton.Button2)

            ReplaceNameInAsmSub(oInventorAssemblyDocument, strOldFileName, strNewFileName, IsSaveAsOld)

            MessageBox.Show("部件替换文件名完成。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ''' <summary>
    ''' 批量替换部件下子集的名字子过程
    ''' </summary>
    ''' <param name="oInventorAssemblyDocument">  组件</param>
    ''' <param name="strOldName">被替换的文件名</param>
    ''' <param name="strNewName">替换的文件名</param>
    ''' <param name="IsSaveAsOld">旧文件是否更改为.old</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReplaceNameInAsmSub(ByVal oInventorAssemblyDocument As Inventor.AssemblyDocument, ByVal strOldName As String,
                                        ByVal strNewName As String, ByVal IsSaveAsOld As Boolean) As Boolean

        'Dim strTempFullFileName As String       '更改旧模型文件的名字存档

        For Each oInventorDocument As Inventor.Document In oInventorAssemblyDocument.ReferencedDocuments
            Dim strOldFullFileName As String   '被替换的旧文件全名
            Dim strOldFileName As String   '被替换的旧文件仅文件名

            Dim strNewFullFileName As String   '新文件全名
            Dim strNewFileName As String   '新文件名

            'InventorDoc = ThisApplication.Documents.ItemByName(OldFullFileName)

            strOldFullFileName = oInventorDocument.FullDocumentName

            If IsFileExists(strOldFullFileName) = False Then   '跳过不存在的文件
                Continue For
            End If

            If InStr(strOldFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                Continue For
            End If

            strOldFileName = GetFileNameInfo(strOldFullFileName).FileName

            '替换旧文件全名为新文件全名
            If InStr(strOldFileName, strOldName) Then
                strNewFileName = Replace(strOldFileName, strOldName, strNewName)
                strNewFullFileName = IO.Path.Combine(GetFileNameInfo(strOldFullFileName).Folder, strNewFileName)

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

                If IsFileExists(oOldIdwFullFileName) = True Then
                    Dim oNewIdwFullFileName As String
                    oNewIdwFullFileName = GetChangeExtension(strNewFullFileName, IDW)   '新工程图
                    FileSystem.FileCopy(oOldIdwFullFileName, oNewIdwFullFileName)             '复制为新工程图

                    ' MessageBox.Show("找到有对应的旧工程图，生成新的工程图，将打开，请链接到文件：" & vbCrLf & NewFullFileName & vbCrLf & "该文件名已复制，粘贴到对话框即可。", MsgBoxStyle.Information)
                    'Windows.Forms.Clipboard.SetText(NewFullFileName)
                    'ThisApplication.Documents.Open(NewIdwFullFileName, False)      '打开新的工程图，使其手动链接零件或部件
                    'ThisApplication.Documents.ItemByName(NewIdwFullFileName).Save2() '保存链接并关闭工程图
                    'ThisApplication.Documents.ItemByName(NewIdwFullFileName).Close()

                    oInventorDocument = ThisApplication.Documents.Open(oNewIdwFullFileName, False)  '打开文件，不显示
                    oInventorDocument.ReferencedDocumentDescriptors(1).ReferencedFileDescriptor.ReplaceReference(strNewFullFileName)
                    oInventorDocument.Save2()
                    oInventorDocument.Close()

                    If IsSaveAsOld = True Then  '暂时更改旧工程图文件的名字存档
                        AddOldExtension(oOldIdwFullFileName)
                    End If
                End If

                If IsSaveAsOld = True Then
                    AddOldExtension(strOldFullFileName)
                End If

                '是部件的遍历新文件的子集
                oNewInventorDocument = ThisApplication.Documents.Open(strNewFullFileName, False)
                If oNewInventorDocument.DocumentType = kAssemblyDocumentObject Then
                    ReplaceNameInAsmSub(oNewInventorDocument, strOldName, strNewName, IsSaveAsOld)
                End If
                oNewInventorDocument.Close(True)

            End If
        Next

        '保存主部件文件
        oInventorAssemblyDocument.Save2(True)

        Return True

    End Function

    '刷新引用
    Public Sub RefreshTreeNodeName()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
            oInventorAssemblyDocument = ThisApplication.ActiveDocument

            If RefreshTreeNodeNameSub(oInventorAssemblyDocument) Then
                SetStatusBarText("刷新引用完成")
                MessageBox.Show("刷新引用完成。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information)
            Else
                SetStatusBarText(XHTool)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '刷新引用
    Public Function RefreshTreeNodeNameSub(ByVal oInventorAssemblyDocument As Inventor.AssemblyDocument) As Boolean

        '        ' 获取装配定义
        '        Dim oAssemblyComponentDefinition As AssemblyComponentDefinition
        '        oAssemblyComponentDefinition = oInventorAssemblyDocument.ComponentDefinition

        '        Dim strShortName1 As String
        '        Dim strShortName2 As String
        '        Dim strNumName As String
        '        Dim i As Integer
        '        For Each oOcc In oAssemblyComponentDefinition.Occurrences

        '            If InStr(oOcc.ReferencedDocumentDescriptor.FullDocumentName, ContentCenterFiles) > 0 Then    '跳过零件库文件
        '                GoTo 999
        '            End If

        '            Debug.Print(oOcc.Name)
        '            Debug.Print(oOcc.ReferencedDocumentDescriptor.FullDocumentName)

        '            i = InStr(oOcc.Name, ":")
        '            strShortName1 = Strings.Left(oOcc.Name, i - 1)
        '            strNumName = Strings.Right(oOcc.Name, Len(oOcc.Name) - i + 1)
        '            strShortName2 = GetFileNameInfo(oOcc.ReferencedDocumentDescriptor.FullDocumentName).OnlyName
        '            If strShortName1 <> strShortName2 Then
        '                oOcc.Name = strShortName2 & strNumName
        '            End If
        '999:
        '        Next
        '        Return True

        Debug.Print(Now)

        If oInventorAssemblyDocument.DocumentType = kAssemblyDocumentObject Then
            Dim oComponentDefinition As ComponentDefinition = oInventorAssemblyDocument.ComponentDefinition
            For Each oComponentOccurrence As ComponentOccurrence In oComponentDefinition.Occurrences
                Try
                    If Not oComponentOccurrence.Suppressed Then
                        oComponentOccurrence.Name = ""
                        Dim oDocument As Document = oComponentOccurrence.Definition.Document

                        '跳过零件库文件
                        If InStr(oComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName, ContentCenterFiles) > 0 Then
                            Continue For
                        End If

                        oDocument.DisplayName = ""
                        If oComponentOccurrence.SubOccurrences.Count > 0 Then
                            If Not oDocument.FullDocumentName.Contains("设计加速器") Then
                                RefreshTreeNodeNameChildSub(oComponentOccurrence)
                            End If
                        End If
                    End If
                Catch ex As Exception
                End Try
            Next

        ElseIf oInventorAssemblyDocument.DocumentType = kPartDocumentObject Then
            oInventorAssemblyDocument.DisplayName = ""
        End If

        Debug.Print(Now)

    End Function


    Public Sub RefreshTreeNodeNameChildSub(oComponentOccurrence As ComponentOccurrence)
        For Each oSubComponentOccurrence As ComponentOccurrence In oComponentOccurrence.SubOccurrences
            Try
                If Not oSubComponentOccurrence.Suppressed Then
                    oSubComponentOccurrence.Name = ""
                    Dim oDocument As Document = oSubComponentOccurrence.Definition.Document
                    oDocument.DisplayName = ""

                    '跳过零件库文件
                    If InStr(oComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName, ContentCenterFiles) > 0 Then
                        Continue For
                    End If

                    If oSubComponentOccurrence.SubOccurrences.Count > 0 Then
                        If Not oDocument.FullDocumentName.Contains("设计加速器") Then
                            RefreshTreeNodeNameChildSub(oSubComponentOccurrence)
                        End If
                    End If
                End If
            Catch ex As Exception

            End Try
        Next
    End Sub


    '一键全部可见
    Public Sub OneKeyShowAll()

        Try
            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            SetStatusBarText()

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'Return False
                Exit Sub
            End If

            Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
            oInventorAssemblyDocument = ThisApplication.ActiveDocument

            '关闭屏幕更新
            'ThisApplication.ScreenUpdating = False

            Dim oCompocc As ComponentOccurrence

            Dim IsVisible As Boolean

            Select Case MessageBox.Show("设置标准件可见性。" & vbCrLf & vbCrLf & "是——全部可见" & vbCrLf & vbCrLf & "否——全部隐藏", XHTool,
                             MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    IsVisible = True
                Case DialogResult.No
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
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
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


                        Dim oComponentDefinitions As Inventor.ComponentDefinitionsEnumerator
                        oComponentDefinitions = oBOMRow.ComponentDefinitions

                        Dim oComponentDefinition As ComponentDefinition
                        oComponentDefinition = oComponentDefinitions.Item(1)

                        Dim strDocumentFullFileName As String
                        strDocumentFullFileName = oComponentDefinition.Document.FullDocumentName

                        '测试文件
                        Debug.Print(strDocumentFullFileName)


                        SetStatusBarText(strDocumentFullFileName)

                        If IsFileExists(strDocumentFullFileName) = False Then   '跳过不存在的文件
                            Continue For
                        End If

                        If InStr(strDocumentFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                            Continue For
                        End If

                        Dim oFileNameInfo As FileNameInfo
                        oFileNameInfo = GetFileNameInfo(strDocumentFullFileName)

                        Dim arrFullFileName As String()
                        Dim strContentCenterFileFullFileName As String = Nothing
                        arrFullFileName = Directory.GetFiles(ContentCenterFiles, oFileNameInfo.FileName, SearchOption.AllDirectories)

                        If arrFullFileName.Length <> 0 Then
                            strContentCenterFileFullFileName = arrFullFileName(0)

                            Dim oCompocc As ComponentOccurrence
                            For Each oCompocc In oInventorAssemblyDocument.ComponentDefinition.Occurrences
                                If oCompocc.ReferencedDocumentDescriptor.FullDocumentName = strDocumentFullFileName Then
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

            MessageBox.Show("替换为库文件完成。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information）

        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    '查找替换
    Public Sub FindAndReplace()

        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
            MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            oOldComponentOccurrence = ThisApplication.CommandManager.Pick(kAssemblyOccurrenceFilter, "选择要替换的未加载零件或部件")
        End If

        If oOldComponentOccurrence Is Nothing Then       '取消选择
            Exit Sub
        End If

        Dim WorkSpaceFloder As String
        WorkSpaceFloder = ThisApplication.DesignProjectManager.ActiveDesignProject.WorkspacePath

        Select Case oOldComponentOccurrence.DefinitionDocumentType
            Case kAssemblyDocumentObject, kPartDocumentObject

                Dim strOldFullDocumentName As String
                strOldFullDocumentName = oOldComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName

                Dim strDrawingNnumber As String
                Try
                    strDrawingNnumber = GetPropitem(oOldComponentOccurrence.Definition.Document, Map_DrawingNnumber)

                    If strDrawingNnumber = "" Then
                        strDrawingNnumber = GetFileNameWithoutExtension2(strOldFullDocumentName)
                    End If

                Catch ex As Exception
                    strDrawingNnumber = GetFileNameWithoutExtension2(strOldFullDocumentName)
                End Try

                Dim strOldDocumentName As String

                strOldDocumentName = InputBox("替换的文件：" & GetFileNameWithExtension(strOldFullDocumentName), "查找替换", strDrawingNnumber)

                If strOldDocumentName = "" Then
                    Exit Sub
                Else
                    strOldDocumentName = "*" & strOldDocumentName & "*" & GetFileExtensionLCase(strOldFullDocumentName)
                End If

                Dim arrFullFileName As String()

                '查找当前项目
                arrFullFileName = Directory.GetFiles(ContentCenterFiles, strOldDocumentName, SearchOption.AllDirectories)

                '查找零件库
                If arrFullFileName.Length = 0 Then
                    arrFullFileName = Directory.GetFiles(WorkSpaceFloder, strOldDocumentName, SearchOption.AllDirectories)
                End If

                If arrFullFileName.Length = 0 Then
                    MessageBox.Show("未找到文件：" & strOldDocumentName, XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning）
                    Exit Sub
                End If

                Dim strFullFileName As String

                Dim frmQuitOpen As New FormQuitOpen

                For Each strFullFileName In arrFullFileName
                    If InStr(strFullFileName, "OldVersions") = 0 Then
                        Dim lvi As ListViewItem = frmQuitOpen.lvw文件列表.Items.Add(strFullFileName)

                        '同一个文件标注为蓝色
                        If strFullFileName = strOldFullDocumentName Then
                            lvi.ForeColor = System.Drawing.Color.RoyalBlue
                        End If

                    End If
                Next

                Select Case frmQuitOpen.lvw文件列表.Items.Count
                    Case 0

                        'Case 1
                        '     MessageBox.Show("未找到同名文件", MsgBoxStyle.Information)
                        '    Dim strFileExtensionName As String = Nothing
                        '    strFileExtensionName = LCase(GetFileNameInfo(strFullFileName).ExtensionName)

                        '    Select Case strFileExtensionName
                        '        Case IAM, IPT
                        '            oOldComponentOccurrence.Replace(strFullFileName, True)


                        '    End Select
                        '    frmQuitOpen.Close()
                    Case Else

                        strQuitOpenSelectFileFullName = Nothing
                        frmQuitOpen.ShowDialog()

                        If strQuitOpenSelectFileFullName Is Nothing Then
                            Exit Sub
                        End If

                        Select Case MessageBox.Show("是否全部替换为" & strQuitOpenSelectFileFullName & "？", XHTool， MessageBoxButtons.YesNoCancel， MessageBoxIcon.Question)
                            Case DialogResult.Yes
                                oOldComponentOccurrence.Replace(strQuitOpenSelectFileFullName, True)
                                ' MessageBox.Show("替换完成！", MsgBoxStyle.Information)
                            Case DialogResult.No
                                oOldComponentOccurrence.Replace(strQuitOpenSelectFileFullName, False)
                                ' MessageBox.Show("替换完成！", MsgBoxStyle.Information)
                            Case Else

                        End Select

                End Select

            Case Else

        End Select

    End Sub

    '抑制全部错误的约束
    Public Sub SuppressAllUnhealthConstraints()
        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
            MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument

        Dim oConstraint As AssemblyConstraint
        For Each oConstraint In oInventorAssemblyDocument.ComponentDefinition.Constraints
            If oConstraint.HealthStatus = HealthStatusEnum.kInconsistentHealth Then
                oConstraint.Suppressed = True
            End If
        Next
        MessageBox.Show("抑制错误的约束完成！", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information)
    End Sub

    Public Sub CreatJpg()
        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        'If (ThisApplication.ActiveDocumentType = kAssemblyDocumentObject) And (ThisApplication.ActiveDocumentType = kPartDocumentObject) Then
        '     MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Exit Sub
        'End If

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        Dim strJpgFileDirectory As String

        strJpgFileDirectory = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop, "截图")

        If IsDirectoryExists(strJpgFileDirectory) Then
            IO.Directory.CreateDirectory(strJpgFileDirectory)
        End If

        Dim strJpgFileFullName As String
        strJpgFileFullName = IO.Path.Combine(strJpgFileDirectory, GetFileNameWithExtension(oInventorDocument.FullDocumentName) & ".jpg")

        CreatJpgSub(oInventorDocument, strJpgFileFullName)

        MessageBox.Show("保持文件到：" & strJpgFileFullName, XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information）
    End Sub
    Public Sub CreatJpgSub(ByVal oInventorDocument As Inventor.Document, ByVal strJpgFileFullName As String)

        oInventorDocument.Activate()

        Dim oActiveView As Inventor.View
        oActiveView = ThisApplication.ActiveView

        Dim oCamera As Camera
        oCamera = oActiveView.Camera

        'oCamera.ViewOrientationType = kTopViewOrientation
        'oCamera.Apply

        'ThisApplication.ActiveView.Fit()

        oActiveView.SaveAsBitmap(strJpgFileFullName, 1000, 800)

    End Sub


    'Public Sub PackAndGo(ByVal strSourceFile As String, ByVal strDestinationFolder As String, ByVal strProjectFile As String)
    '    Dim oPacknGoComp As New PackAndGoLib.PackAndGoComponent

    '    Dim oPacknGo As PackAndGoLib.PackAndGo
    '    'oPacknGo = oPacknGoComp.CreatePackAndGo(ThisApplication.ActiveDocument.FullDocumentName, "C:\Users\likai\Desktop\新建文件夹")
    '    oPacknGo = oPacknGoComp.CreatePackAndGo(strSourceFile, strDestinationFolder)

    '    ' Set the design project. This defaults to the current active project.
    '    oPacknGo.ProjectFile = strProjectFile

    '    Dim sRefFiles = New String() {}
    '    Dim sMissFiles = New Object

    '    ' Set the options
    '    oPacknGo.SkipLibraries = True
    '    oPacknGo.SkipStyles = True
    '    oPacknGo.SkipTemplates = True
    '    oPacknGo.CollectWorkgroups = False
    '    oPacknGo.KeepFolderHierarchy = True
    '    oPacknGo.IncludeLinkedFiles = True

    '    ' Get the referenced files
    '    oPacknGo.SearchForReferencedFiles(sRefFiles, sMissFiles)

    '    ' Add the referenced files for package
    '    oPacknGo.AddFilesToPackage(sRefFiles)

    '    ' Start the pack and go to create the package
    '    oPacknGo.CreatePackage()
    'End Sub



    '关闭自适应
    Public Sub Turn_Off_Adaptivity()
        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
            MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            oOldComponentOccurrence = ThisApplication.CommandManager.Pick(kAssemblyOccurrenceFilter, "选择要关闭自适应的零件或部件")
        End If

        If oOldComponentOccurrence Is Nothing Then       '取消选择
            Exit Sub
        End If

        Dim oInventorDocument As Inventor.Document

        ''iterates through each file and turns off adaptivity for all adaptive files
        For Each oInventorDocument In oInventorAssemblyDocument.AllReferencedDocuments
            Try
                If oInventorDocument.FullDocumentName = oOldComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName Then
                    If oInventorDocument.ModelingSettings.AdaptivelyUsedInAssembly = True Then
                        oInventorDocument.ModelingSettings.AdaptivelyUsedInAssembly = False
                    End If
                    Exit For
                End If
            Catch
            End Try
        Next

        ' MessageBox.Show("关闭自适应完成！", MsgBoxStyle.Information)

    End Sub


    ''' <summary>
    ''' 选择部件中的文件浏览器组件
    ''' </summary>
    ''' <param name="strComponentDefinition">被选择的组件全名</param>
    ''' <remarks></remarks>
    Public Sub SelectAssemblyComponentDefinition(ByVal strComponentDefinition As String)
        Try
            Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
            oInventorAssemblyDocument = ThisApplication.ActiveDocument

            ' 获取装配定义
            Dim oAssemblyComponentDefinition As AssemblyComponentDefinition
            oAssemblyComponentDefinition = oInventorAssemblyDocument.ComponentDefinition

            ' 获取装配子集
            Dim oComponentOccurrences As ComponentOccurrences
            oComponentOccurrences = oAssemblyComponentDefinition.Occurrences

            '遍历
            For Each oComponentOccurrence As ComponentOccurrence In oComponentOccurrences
                If oComponentOccurrence.Definition.Document.fullDocumentName = strComponentDefinition Then
                    ThisApplication.CommandManager.DoSelect(oComponentOccurrence)
                Else
                    ThisApplication.CommandManager.DoUnSelect(oComponentOccurrence)
                End If
            Next


        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' 打开被选择零件的上级部件
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub OpenParentAssembly()
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        Dim oComponentOccurrence As ComponentOccurrence

        oInventorDocument.SelectSet.Clear()

        'If oInventorDocument.SelectSet.Count = 0 Then
        oComponentOccurrence = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kAssemblyLeafOccurrenceFilter, "选择一个零件，ESC键取消")
        If oComponentOccurrence Is Nothing Then
            Exit Sub
        End If
        'Else
        '    'oSelectSet = oInventorDocument.SelectSet.Item(1)
        '    'If TypeOf oSelectSet Is ComponentOccurrence Then
        '    '    oComponentOccurrence = CType(oSelectSet, ComponentOccurrence)
        '    'Else
        '    Exit Sub
        '    'End If
        'End If

        Dim oParentInventorDocument As Inventor.Document

        oParentInventorDocument = oComponentOccurrence.ReferencedDocumentDescriptor.Parent

        Dim strParentAssemblyFullFileName As String
        strParentAssemblyFullFileName = oParentInventorDocument.FullDocumentName

        Debug.Print(strParentAssemblyFullFileName)

        ThisApplication.Documents.Open(strParentAssemblyFullFileName, True)

        SelectAssemblyComponentDefinition(oComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName)

    End Sub

    ''' <summary>
    ''' 克隆插入组件
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CloneComponentAndInsertConstraint()
        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
            MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument

        Dim oSelectSets As SelectSet
        oSelectSets = oInventorAssemblyDocument.SelectSet

        '获取被选择的组件列表
        Dim oSourceComponentList As New List(Of ComponentOccurrence)

        If oSelectSets.Count = 0 Then

            Dim oclsWindowSelection As New ClsWindowSelection
            oSourceComponentList = oclsWindowSelection.WindowSelect()

            If oSourceComponentList Is Nothing Then
                Exit Sub
            End If

        Else
            For Each oSelectedEntity As Object In oSelectSets
                ' 检查是否为 ComponentOccurrence 类型
                If TypeOf oSelectedEntity Is ComponentOccurrence Then
                    Dim oComponent As ComponentOccurrence = CType(oSelectedEntity, ComponentOccurrence)
                    oSourceComponentList.Add(oComponent)
                Else
                    ' 可选：提示用户排除了非组件的选择项
                    '  MessageBox.Show($"已跳过非组件对象：{oSelectedEntity.ToString()}")
                End If
            Next
        End If


        '从源组件中选择第一个数量仅一个的组件

        Dim oOneSourceComponentOccurrence As ComponentOccurrence = Nothing

        ' 1. 统计每个文件完整路径的出现次数
        Dim filePathCountDict As New Dictionary(Of String, Integer)
        For Each oComponentOccurrence As ComponentOccurrence In oSourceComponentList
            If oComponentOccurrence.Definition IsNot Nothing AndAlso
               oComponentOccurrence.Definition.Document IsNot Nothing Then
                ' 获取文件的完整路径
                Dim filePath As String = oComponentOccurrence.Definition.Document.FullFileName
                If Not String.IsNullOrEmpty(filePath) Then
                    If filePathCountDict.ContainsKey(filePath) Then
                        filePathCountDict(filePath) += 1
                    Else
                        filePathCountDict(filePath) = 1
                    End If
                End If
            End If
        Next

        ' 2. 遍历列表，找到第一个文件路径唯一的组件
        For Each oComponentOccurrence As ComponentOccurrence In oSourceComponentList
            If oComponentOccurrence.Definition IsNot Nothing AndAlso
               oComponentOccurrence.Definition.Document IsNot Nothing Then
                Dim filePath As String = oComponentOccurrence.ReferencedFileDescriptor.FullFileName
                If Not String.IsNullOrEmpty(filePath) AndAlso
                   filePathCountDict(filePath) = 1 Then
                    oOneSourceComponentOccurrence = oComponentOccurrence
                    Exit For ' 找到第一个后立即退出
                End If
            End If
        Next

        ' 3. 结果检查
        If oOneSourceComponentOccurrence Is Nothing Then
            ' 未找到符合条件的组件
            MessageBox.Show("选择的组件中无数量为一的，无法与源组件对齐，退出本功能。"， XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            ' 成功找到唯一文件路径的组件
            ' MessageBox.Show("唯一文件路径：" & oOneSourceComponentOccurrence.ReferencedFileDescriptor.FullFileName)
        End If


        Dim douOffset As Double      '插入偏移
        If Not Double.TryParse(InputBox("输入偏移量：", "复制插入", 0), douOffset) Then
            MessageBox.Show("偏移量必须为数字。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning)
            Exit Sub
        End If
        '输入的单位是cm ，转换为 mm
        douOffset *= 0.1


        Dim oEdgeOne As Edge      '源组件中选择的圆边
        Dim oEdgeTwo As Edge        ' 插入约束的圆边
        Dim oEdgeThree As Edge = Nothing   ' 复制组件中与 oedgeone 对应的圆边


        Dim oEdgeHSet As HighlightSet = oInventorAssemblyDocument.CreateHighlightSet   '选择圆边的高亮
        oEdgeHSet.Color = ThisApplication.TransientObjects.CreateColor(255, 165, 0）   '橙色

998：

        oEdgeOne = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kPartEdgeCircularFilter, "请在源零件中选择一个插入约束的圆(弧)，ESC键取消。")
        If oEdgeOne Is Nothing Then       '取消选择
            oEdgeHSet.Clear()
            Exit Sub
        End If

        Select Case oEdgeOne.GeometryType
            Case CurveTypeEnum.kCircleCurve, CurveTypeEnum.kCircularArcCurve
                oEdgeHSet.AddItem(oEdgeOne)
            Case Else
                Exit Sub
        End Select

        '判断选择的边是否属于选择的组件
        Dim IsEdgeOneInComponentOccurrence As Boolean = False

        Dim oEdgeOneComponentOccurrence As ComponentOccurrence = oEdgeOne.ContainingOccurrence    '选择的第一个圆的源组件


        ' 扩展目标组件列表：将子部件展开为所有子零件
        Dim oSourceExpandedComponentList As New List(Of ComponentOccurrence)()
        For Each oComponentOccurrence As ComponentOccurrence In oSourceComponentList
            oSourceExpandedComponentList.AddRange(GetAllLeafOccurrences(oComponentOccurrence))
        Next


        If oSourceExpandedComponentList.Any(Function(comp) comp Is oEdgeOneComponentOccurrence) Then
            IsEdgeOneInComponentOccurrence = True
        Else
            IsEdgeOneInComponentOccurrence = False
        End If

        If IsEdgeOneInComponentOccurrence = False Then
            oEdgeHSet.Clear()
            MessageBox.Show("选择的圆(弧)不属于被复制的组件。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning）
            GoTo 998
        End If

        Dim oSourceCenter As Point     '源圆心
        Dim oSourceRadius As Double     '源半径

        oSourceCenter = oEdgeOne.Geometry.center
        oSourceRadius = oEdgeOne.Geometry.radius


        '复制选择的组件
        ThisApplication.CommandManager.ControlDefinitions.Item("AppCopyCmd").Execute()
        oInventorAssemblyDocument.SelectSet.Clear()


        '撤销功能
        Dim oTransaction As Transaction
        oTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "My Transaction")

        Do

            ' 重新添加高亮（假设 oEdgeOne 仍有效）
            If oEdgeHSet IsNot Nothing AndAlso oEdgeOne IsNot Nothing Then
                oEdgeHSet.AddItem(oEdgeOne)
            End If

            oEdgeTwo = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kPartEdgeCircularFilter, "请选择插入位置的圆(弧)，ESC键取消。")
            If oEdgeTwo Is Nothing Then       '取消选择

                '刷新浏览器
                ThisApplication.ScreenUpdating = True
                oInventorAssemblyDocument.Update()
                oInventorAssemblyDocument.BrowserPanes.ActivePane.Refresh()
                Exit Do
            End If

            'oHSet.AddItem(oEdgeTwo)

            ThisApplication.ScreenUpdating = False

            '记录粘贴前的组件数量
            Dim originalOccCount As Integer = oInventorAssemblyDocument.ComponentDefinition.Occurrences.Count

            '粘贴选择的组件
            ThisApplication.CommandManager.ControlDefinitions.Item("AppPasteCmd").Execute()

            Dim oOneCloneComponent As ComponentOccurrence = Nothing     '克隆组件

            '获取被粘贴的的组件列表
            Dim oCloneComponentList As New List(Of ComponentOccurrence)
            For i = originalOccCount + 1 To oInventorAssemblyDocument.ComponentDefinition.Occurrences.Count
                oCloneComponentList.Add(oInventorAssemblyDocument.ComponentDefinition.Occurrences.Item(i))
            Next



            '用仅一个的组件名对比 新粘贴的组件名 ，获取数量为一的的组件
            For Each oComponentOccurrence In oCloneComponentList
                If oComponentOccurrence.ReferencedFileDescriptor.FullFileName =
                    oOneSourceComponentOccurrence.ReferencedFileDescriptor.FullFileName Then

                    oOneCloneComponent = oComponentOccurrence

                    Exit For
                End If
            Next


            '对齐源组件和 粘贴 的组件
            FlushXYZPlaneSub(oInventorAssemblyDocument, oOneSourceComponentOccurrence, oOneCloneComponent, True)

            Dim oComponentCenter As Point     '组件圆心
            Dim oComponentRadius As Double    '组件半径

            Dim oColneComponentEdges As Edges

            ' 扩展目标组件列表：将子部件展开为所有子零件
            Dim oCloneExpandedComponentListAs As New List(Of ComponentOccurrence)

            For Each oComponentOccurrence As ComponentOccurrence In oCloneComponentList
                oCloneExpandedComponentListAs.AddRange(GetAllLeafOccurrences(oComponentOccurrence))
            Next

            For Each oComponentOccurrence As ComponentOccurrence In oCloneExpandedComponentListAs
                If oComponentOccurrence.ReferencedFileDescriptor.FullFileName = oEdgeOneComponentOccurrence.ReferencedFileDescriptor.FullFileName Then
                    For i = 1 To oComponentOccurrence.SurfaceBodies.Count
                        oColneComponentEdges = oComponentOccurrence.SurfaceBodies.Item(i).Edges

                        For Each oEdge As Edge In oColneComponentEdges
                            Select Case oEdge.GeometryType
                                Case CurveTypeEnum.kCircleCurve
                                    oComponentCenter = oEdge.Geometry.center
                                    oComponentRadius = oEdge.Geometry.radius
                                Case CurveTypeEnum.kCircularArcCurve
                                    oComponentCenter = oEdge.Geometry.center
                                    oComponentRadius = oEdge.Geometry.radius
                                Case Else
                                    Continue For
                            End Select

                            If FourFive(oSourceCenter.DistanceTo(oComponentCenter), 5) = 0 And FourFive(oSourceRadius - oComponentRadius, 5) = 0 Then
                                oEdgeThree = oEdge
                                GoTo 999
                            End If
                        Next

                    Next
                End If
            Next

999:

            If oEdgeThree Is Nothing Then
                MessageBox.Show("未找到匹配的圆形边。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning）
                Continue Do
            End If

            oInventorAssemblyDocument.ComponentDefinition.Constraints.AddInsertConstraint(oEdgeTwo, oEdgeThree, True, douOffset)    'oConstraint.AxesOpposed, oConstraint.Distance.Expression)

            '刷新浏览器

            oEdgeHSet.Clear()
            ThisApplication.ScreenUpdating = True
            oInventorAssemblyDocument.Update()
            oInventorAssemblyDocument.BrowserPanes.ActivePane.Refresh()

        Loop While (True)


        oTransaction.End()
    End Sub


    ' 递归获取所有叶子节点（零件层级的 ComponentOccurrence）
    Private Function GetAllLeafOccurrences(occurrence As ComponentOccurrence) As List(Of ComponentOccurrence)
        Dim leafOccurrences As New List(Of ComponentOccurrence)()

        ' 判断当前组件是零件还是子部件
        Dim partDef As PartComponentDefinition
        Dim assemblyDef As AssemblyComponentDefinition

        Try
            partDef = CType(occurrence.Definition, PartComponentDefinition)
            ' 如果是零件，直接添加到列表
            leafOccurrences.Add(occurrence)
        Catch ex As Exception
            Try
                assemblyDef = CType(occurrence.Definition, AssemblyComponentDefinition)
                ' 如果是子部件，遍历所有子组件
                For Each subOccurrence As ComponentOccurrence In occurrence.SubOccurrences
                    leafOccurrences.AddRange(GetAllLeafOccurrences(subOccurrence))
                Next
            Catch
                ' 其他类型（如不可展开的组件）
            End Try
        End Try

        Return leafOccurrences
    End Function

    ''' <summary>
    ''' 在部件中打开选择的组件
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub OpenSelectComponentOccurrences()
        On Error Resume Next

        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
            MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument

        Dim strInventorDocumenFullDocumentName As String
        Dim oComponentOccurrence As ComponentOccurrence

        If oInventorAssemblyDocument.SelectSet.Count <> 0 Then
            For Each oSelect As Object In oInventorAssemblyDocument.SelectSet
                If TypeOf (oSelect) Is ComponentOccurrence Then
                    oComponentOccurrence = CType(oSelect, ComponentOccurrence)

                    strInventorDocumenFullDocumentName = oComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName
                    If IsFileExists(strInventorDocumenFullDocumentName) = True Then
                        oInventorAssemblyDocument = ThisApplication.Documents.Open(strInventorDocumenFullDocumentName, True)
                    End If
                End If
            Next
        End If


    End Sub

    ''' <summary>
    ''' 在部件中检查钣金厚度匹配
    ''' </summary>
    Public Sub CheckSteelThicknessInAssembly()
        On Error Resume Next

        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
            MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument


        ' 获取装配定义
        Dim oAssemblyComponentDefinition As AssemblyComponentDefinition
        oAssemblyComponentDefinition = oInventorAssemblyDocument.ComponentDefinition

        ' 获取装配子集
        Dim oComponentOccurrences As ComponentOccurrences
        oComponentOccurrences = oAssemblyComponentDefinition.Occurrences

        '遍历

        Dim oInventorPartDocument As Inventor.PartDocument
        Dim strInventorPartDocumentFullFileName As String

        For Each oComponentOccurrence As ComponentOccurrence In oComponentOccurrences.AllLeafOccurrences
            strInventorPartDocumentFullFileName = oComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName

            'Debug.Print(strInventorPartDocumentFullFileName)

            If IsFileExists(strInventorPartDocumentFullFileName) = True Then
                oInventorPartDocument = ThisApplication.Documents.Open(strInventorPartDocumentFullFileName, False)

                Dim IsMatching As Boolean
                IsMatching = CheckSteelThicknessSub(oInventorPartDocument)

                'oInventorPartDocument.Close()

                Select Case IsMatching
                    Case True

                    Case False
                        ThisApplication.Documents.Open(oInventorPartDocument.FullDocumentName)
                End Select


            End If
        Next

        MessageBox.Show("检查钣金厚度匹配完成，已打开不匹配的零件。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information)
    End Sub
End Module