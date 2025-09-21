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
Imports System.Collections.Generic

Module IptModule

    ''' <summary>
    ''' 打开对应的工程图
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub OpenIdwFile()

        On Error Resume Next

        SetStatusBarText()

        if IsInventorOpenDocument() = False Then
            Exit Sub
        End if

        if ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject And ThisApplication.ActiveDocumentType <> kPartDocumentObject Then
            MessageBox.Show("该功能仅适用于零部件。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）
            Exit Sub
        End if

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        str模型匹配检查标记 = 1

        Dim strInventorDocumenFullDocumentName As String
        Dim strDrawingFullDocumentName As String

        If oInventorDocument.SelectSet.Count <> 0 Then
            'For Each oSelect As Object In InventorDoc.SelectSet
            For Each ComponentOccurrence As ComponentOccurrence In oInventorDocument.SelectSet()
                oInventorDocument = ThisApplication.Documents.ItemByName(ComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName)

                strInventorDocumenFullDocumentName = oInventorDocument.FullDocumentName
                strDrawingFullDocumentName = GetChangeExtensionDocument(strInventorDocumenFullDocumentName, IDW)


                If IsFileExists(strDrawingFullDocumentName) = True Then
                    ThisApplication.Documents.Open(strDrawingFullDocumentName)
                Else
                    If MessageBox.Show($"没有找到：{vbCrLf}{oInventorDocument.FullDocumentName}{vbCrLf}对应的工程图，是否查找 AutoCad Dwg 文件？", XHTool，
                                       MessageBoxButtons.YesNo， MessageBoxIcon.Question） = DialogResult.Yes Then

                        strDrawingFullDocumentName = GetChangeExtensionDocument(strInventorDocumenFullDocumentName, DWG)

                        If IsFileExists(strDrawingFullDocumentName) = True Then
                            ProcessStart(strDrawingFullDocumentName)
                        Else
                            MessageBox.Show($"{oInventorDocument.FullDocumentName} {vbCrLf}没有对应的 AutoCad Dwg 文件。", XHTool，
                                            MessageBoxButtons.OK， MessageBoxIcon.Information）
                        End If
                    End If
                End If
            Next

        Else
            strInventorDocumenFullDocumentName = oInventorDocument.FullDocumentName
            strDrawingFullDocumentName = GetChangeExtensionDocument(strInventorDocumenFullDocumentName, IDW)

            If IsFileExists(strDrawingFullDocumentName) = True Then
                ThisApplication.Documents.Open(strDrawingFullDocumentName)
            Else
                If IsFileExists(strDrawingFullDocumentName) = True Then
                    ThisApplication.Documents.Open(strDrawingFullDocumentName)
                Else
                    If MessageBox.Show($”{oInventorDocument.FullDocumentName}{vbCrLf}{vbCrLf}没有对应的工程图，是否查找 AutoCad Dwg 文件？", XHTool，
                                       MessageBoxButtons.YesNo， MessageBoxIcon.Error） = DialogResult.Yes Then

                        strDrawingFullDocumentName = GetChangeExtensionDocument(strInventorDocumenFullDocumentName, DWG)

                        If IsFileExists(strDrawingFullDocumentName) = True Then
                            ProcessStart(strDrawingFullDocumentName)
                        Else
                            MessageBox.Show($"没有找到：{vbCrLf}{oInventorDocument.FullDocumentName}{vbCrLf}对应的AutoCad.Dwg文件。", XHTool，
                                             MessageBoxButtons.OK， MessageBoxIcon.Information）
                        End If
                    End If
                End If
            End If

        End If

        str模型匹配检查标记 = 1

        'Catch ex As Exception
        '       MessageBox.Show(ex.Message, xhtool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    ''' <summary>
    ''' 零部件另存为新的文件，并链接工程图
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AsmIptDocumentSaveAs()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject And ThisApplication.ActiveDocumentType <> kPartDocumentObject Then
                MessageBox.Show("该功能仅适用于零部件。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）
                Exit Sub
            End If

            Dim oInventorDocument As Inventor.Document
            oInventorDocument = ThisApplication.ActiveEditDocument

            Dim strOldInventorDocumentFullName As String
            strOldInventorDocumentFullName = oInventorDocument.FullFileName


            Dim strOldInventorDocumentExtensionName As String
            strOldInventorDocumentExtensionName = GetFileExtensionLCase(strOldInventorDocumentFullName)

            Dim strFilter As String = Nothing
            Select Case strOldInventorDocumentExtensionName
                Case IAM
                    strFilter = "Autodesk Inventor 部件(*.iam)|*.iam"
                Case IPT
                    strFilter = "Autodesk Inventor 零件(*.ipt)|*.ipt"

            End Select

            '新零部件文件名
            Dim strNewInventorDocumentFullName As String
            strNewInventorDocumentFullName = GetChangeFileName（strOldInventorDocumentFullName, GetFileNameWithoutExtension2(strOldInventorDocumentFullName) & "-副本")

            Dim oFileList As List(Of String)
            oFileList = SaveFileDialog(strFilter, False, strNewInventorDocumentFullName)

            If oFileList Is Nothing Then
                Exit Sub
            End If

            strNewInventorDocumentFullName = oFileList.Item(0).ToString

            'If strNewInventorDocumentFullName = strOldInventorDocumentFullName Then
            '     MessageBox.Show("请选择不同的零部件文件。", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            ''判断新文件是否存在，是否需要覆盖
            'If IsFileExists(strNewInventorDocumentFullName) = True Then
            '    If  MessageBox.Show("存在零部件：" & vbCrLf & vbCrLf & strNewInventorDocumentFullName & vbCrLf & vbCrLf & " 是否覆盖？", _
            '              MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            '    Else
            '        Exit Sub
            '    End If
            'End If

            IO.File.Copy(strOldInventorDocumentFullName, strNewInventorDocumentFullName, True)
            SetFileReadOnly(strNewInventorDocumentFullName, False)


            Dim strOldInventorDrawingDocumentFullName As String
            strOldInventorDrawingDocumentFullName = GetChangeExtension(strOldInventorDocumentFullName, IDW)

            If IsFileExists(strOldInventorDrawingDocumentFullName) = True Then
                Dim strNewInventorDrawingDocumentFullName As String
                strNewInventorDrawingDocumentFullName = GetChangeExtension(strNewInventorDocumentFullName, IDW)

                IO.File.Copy(strOldInventorDrawingDocumentFullName, strNewInventorDrawingDocumentFullName, True)
                SetFileReadOnly(strNewInventorDrawingDocumentFullName, False)

                '替换工程图模型参考
                ReplaceFileReference(strNewInventorDrawingDocumentFullName, strOldInventorDocumentFullName, strNewInventorDocumentFullName)

            End If

            Dim oNewInventorDocument As Inventor.Document = ThisApplication.Documents.Open(strNewInventorDocumentFullName)
            SetDocumentIpropertyFromFileNameSub(oNewInventorDocument, False)

        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ''' <summary>
    ''' 另存为stp文件
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AsmIptSaveAsStp()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject And ThisApplication.ActiveDocumentType <> kPartDocumentObject Then
                MessageBox.Show("该功能仅适用于零部件。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）
                Exit Sub
            End If

            Dim oInventorDocument As Inventor.Document
            oInventorDocument = ThisApplication.ActiveEditDocument

            Dim strInventorDocument As String
            strInventorDocument = oInventorDocument.FullFileName

            'if strInventorDocument = "" Then
            '     MessageBox.Show("请先保存本零部件。", MsgBoxStyle.Information)
            '    Exit Sub
            'End if


            Dim strStpFullFileName As String        'ipt文件全文件名

            If str另存到子文件夹 = "1" Then
                Dim strChildDirectory As String

                strChildDirectory = GetDirectoryName2(strInventorDocument)
                strChildDirectory = IO.Path.Combine(strChildDirectory, "Stp")

                If IsDirectoryExists(strChildDirectory) = False Then
                    IO.Directory.CreateDirectory(strChildDirectory)
                End If
                strStpFullFileName = IO.Path.Combine(strChildDirectory,
                                                      GetFileNameInfo(strInventorDocument).OnlyName & STP)
            Else
                strStpFullFileName = GetChangeExtension(strInventorDocument, STP)
            End If

            strStpFullFileName = SetNewFile(strStpFullFileName, "STEP文件(*.stp)|*.stp")

            If strStpFullFileName = "" Then
                Exit Sub
            End If

            AsmIptSaveAsStpSub(oInventorDocument, strStpFullFileName, True)

            If IsFileExists(strStpFullFileName) Then
                SetStatusBarText("另存为STEP完成")
                If MessageBox.Show($"是否打开文件：{strStpFullFileName}？“, XHTool， MessageBoxButtons.YesNo， MessageBoxIcon.Question） = DialogResult.Yes Then
                    ProcessStart(strStpFullFileName)
                End If
            Else
                SetStatusBarText(XHTool)
                MessageBox.Show("另存为STEP错误。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    ''' <summary>
    '''   另存为 stp文件子过程
    ''' </summary>
    ''' <param name="InventorDocument">文件对象</param>
    ''' <param name="strStepFullFileName">stp文件名</param>
    ''' <param name="IsReplace">是否覆盖</param>
    ''' <remarks></remarks>
    Public Sub AsmIptSaveAsStpSub(ByVal InventorDocument As Inventor.Document, ByVal strStepFullFileName As String, ByVal IsReplace As Boolean)

        If IsFileExists(strStepFullFileName) And IsReplace = False Then
            Exit Sub
        End If

        ' Get the STEP translator Add-In.
        Dim oSTEPTranslator As TranslatorAddIn
        oSTEPTranslator = ThisApplication.ApplicationAddIns.ItemById("{90AF7F40-0C01-11D5-8E83-0010B541CD80}")

        If oSTEPTranslator Is Nothing Then
            ' MessageBox.Show("无法转换为Step文件。")
            Exit Sub
        End If

        Dim oContext As TranslationContext
        oContext = ThisApplication.TransientObjects.CreateTranslationContext
        Dim oOptions As NameValueMap
        oOptions = ThisApplication.TransientObjects.CreateNameValueMap
        If oSTEPTranslator.HasSaveCopyAsOptions(ThisApplication.ActiveDocument, oContext, oOptions) Then
            ' Set application protocol.
            ' 2 = AP 203 - Configuration Controlled Design
            ' 3 = AP 214 - Automotive Design
            oOptions.Value("ApplicationProtocolType") = 3

            ' Other options...
            'oOptions.Value("Author") = ""
            'oOptions.Value("Authorization") = ""
            'oOptions.Value("Description") = ""
            'oOptions.Value("Organization") = ""

            oContext.Type = kFileBrowseIOMechanism

            Dim oData As DataMedium
            oData = ThisApplication.TransientObjects.CreateDataMedium
            oData.FileName = strStepFullFileName

            oSTEPTranslator.SaveCopyAs(InventorDocument, oContext, oOptions, oData)
        End If
    End Sub

    ''' <summary>
    ''' 替换衍生
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ReplaceDerivedPart()
        SetStatusBarText()

        if IsInventorOpenDocument() = False Then
            Exit Sub
        End if

        'if ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
        '     MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End if

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        if (Not LevelOfDetailIsMaster(oInventorDocument)) Then Return

        Dim docToReplace As Document = FindDocToReplace(oInventorDocument)
        if (docToReplace Is Nothing) Then Return

        Dim replacementFileName As String = SelectReplacementFilename(docToReplace.DisplayName)

        if (String.IsNullOrEmpty(replacementFileName)) Then Return
        if (String.Equals(docToReplace.FullFileName, replacementFileName, StringComparison.OrdinalIgnoreCase)) Then Return

        Dim replacementPart As Document = ThisApplication.Documents.Open(replacementFileName, False)
        Dim doReplace As Boolean = True
        if (replacementPart.InternalName <> docToReplace.InternalName) Then
            MessageBox.Show($"更换零件 {replacementPart.DisplayName} 似乎与原始零件关系不密切，因此无法使用。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error)
            doReplace = False
        End if
        replacementPart.ReleaseReference()

        if (Not doReplace) Then Return

        Dim fileNameToReplace As String = docToReplace.FullFileName
        ReplaceReferences(oInventorDocument, fileNameToReplace, replacementFileName)
        oInventorDocument.Update()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="oInventorDocument"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FindDocToReplace(oInventorDocument As Inventor.Document) As Inventor.Document
        Dim basePartList As New List(Of Inventor.Document)
        if (oInventorDocument.DocumentType = DocumentTypeEnum.kPartDocumentObject) Then
            AddBaseParts(basePartList, oInventorDocument)
        Else
            For Each refDoc As Inventor.Document In oInventorDocument.AllReferencedDocuments
                if (refDoc.DocumentType = DocumentTypeEnum.kPartDocumentObject) Then
                    AddBaseParts(basePartList, refDoc)
                End if
            Next
        End if
        if (basePartList.Count = 0) Then
            MessageBox.Show($"在文档中未找到基本零件： {oInventorDocument.DisplayName}。"， XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf (basePartList.Count = 1) Then
            Return basePartList(0)
        Else
            Dim partNameList As New List(Of String)
            For Each baseDoc As Document In basePartList
                partNameList.Add(baseDoc.DisplayName)
            Next
            'Dim selectedName As String = InputListBox("选择要替换的零件", partNameList, partNameList(0), "替换零件", "零件").ToString()
            Dim selectedIndex As Integer = 0 ' partNameList.IndexOf(selectedName)
            Return basePartList(selectedIndex)
        End if
        Return Nothing
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="basePartList"></param>
    ''' <param name="doc"></param>
    ''' <remarks></remarks>
    Public Sub AddBaseParts(ByVal basePartList As List(Of Document), ByVal doc As Document)
        For Each refDoc As Document In doc.ReferencedDocuments
            if (refDoc.DocumentType = DocumentTypeEnum.kPartDocumentObject AndAlso Not IsiPartMember(refDoc)) Then
                if (Not basePartList.Contains(refDoc)) Then
                    basePartList.Add(refDoc)
                End if
            End if
        Next
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="doc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function IsiPartMember(ByVal doc As Document) As Boolean
        if (doc.DocumentType <> DocumentTypeEnum.kPartDocumentObject) Then Return False
        Dim partDoc As PartDocument = DirectCast(doc, PartDocument)
        Return partDoc.ComponentDefinition.IsiPartMember
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="filenameToReplace"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function SelectReplacementFilename(ByVal filenameToReplace As String) As String
        Dim oFileDlg As Inventor.FileDialog = Nothing
        ThisApplication.CreateFileDialog(oFileDlg)
        oFileDlg.Filter = "零件文件 (*.ipt)|*.ipt"
        oFileDlg.DialogTitle = "替换 " & filenameToReplace
        'oFileDlg.InitialDirectory = ThisDoc.Path
        oFileDlg.CancelError = False
        Try
            oFileDlg.ShowOpen()
            Return oFileDlg.FileName
        Catch
        End Try
        Return String.Empty
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="oInventorDocument"></param>
    ''' <param name="fileNameToReplace"></param>
    ''' <param name="replacementFileName"></param>
    ''' <remarks></remarks>
    Public Sub ReplaceReferences(ByVal oInventorDocument As Document, ByVal fileNameToReplace As String, ByVal replacementFileName As String)
        ReplaceReferencesInOneDoc(oInventorDocument, fileNameToReplace, replacementFileName)

        For Each subDoc As Document In oInventorDocument.AllReferencedDocuments
            If (String.Equals(subDoc.FullFileName, fileNameToReplace, StringComparison.OrdinalIgnoreCase) OrElse _
             String.Equals(subDoc.FullFileName, replacementFileName, StringComparison.OrdinalIgnoreCase)) Then
                Continue For
            End If
            ReplaceReferencesInOneDoc(subDoc, fileNameToReplace, replacementFileName)
        Next
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="doc"></param>
    ''' <param name="fileNameToReplace"></param>
    ''' <param name="replacementFileName"></param>
    ''' <remarks></remarks>
    Sub ReplaceReferencesInOneDoc(ByVal doc As Document, ByVal fileNameToReplace As String, ByVal replacementFileName As String)
        For Each docDesc As DocumentDescriptor In doc.ReferencedDocumentDescriptors
            Dim desc As FileDescriptor = docDesc.ReferencedFileDescriptor
            if (desc.ReferenceMissing) Then Continue For
            Console.WriteLine("Referenced RelativeFileName = " & desc.RelativeFileName)
            Trace.WriteLine("Referenced RelativeFileName = " & desc.RelativeFileName)
            if (String.Equals(desc.FullFileName, fileNameToReplace, StringComparison.OrdinalIgnoreCase)) Then
                desc.ReplaceReference(replacementFileName)
                Exit For
            End if
        Next
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="oInventorDocument"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function LevelOfDetailIsMaster(oInventorDocument As Inventor.Document) As Boolean
        Dim assemDoc As AssemblyDocument = TryCast(oInventorDocument, AssemblyDocument)
        if (assemDoc Is Nothing) Then Return True

        Dim repMgr As RepresentationsManager = assemDoc.ComponentDefinition.RepresentationsManager

        Dim lodType As LevelOfDetailEnum = repMgr.ActiveLevelOfDetailRepresentation.LevelOfDetail
        if (lodType <> LevelOfDetailEnum.kMasterLevelOfDetail) Then
            MessageBox.Show("此规则只能在主要详细等级中运行。", XHTool， MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End if
        Return True
    End Function


    ''' <summary>
    '''  检查钣金件厚度匹配
    ''' </summary>
    Public Sub CheckSteelThicknessInPart()

        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> DocumentTypeEnum.kPartDocumentObject Then
                  MessageBox.Show(”该功能仅适用于零件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim oInventorPartDocument As Inventor.PartDocument
            oInventorPartDocument = ThisApplication.ActiveDocument

            Dim IsMatching As Boolean
            IsMatching = CheckSteelThicknessSub(oInventorPartDocument)

            Select Case IsMatching
                Case True
                    MessageBox.Show("材料设置与厚度匹配。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information）
                Case False
                    MessageBox.Show("材料设置与厚度不匹配。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）
            End Select

        Catch

        End Try
    End Sub

    ''' <summary>
    ''' 检查钣金件厚度匹配子过程
    ''' </summary>
    ''' <param name="oInventorPartDocument">检查的零件</param>
    ''' <returns></returns>
    Public Function CheckSteelThicknessSub(ByVal oInventorPartDocument As Inventor.PartDocument) As Boolean
        On Error Resume Next

        If (oInventorPartDocument.SubType <> "{9C464203-9BAE-11D3-8BAD-0060B0CE6BB4}") Then
            ' MessageBox.Show("本零件非钣金件，退出检查。")
            Return True
        End If

        Dim oSheetMetalComponentDefinition As Inventor.SheetMetalComponentDefinition
        oSheetMetalComponentDefinition = oInventorPartDocument.ComponentDefinition

        Dim strThickness As String
        strThickness = (oSheetMetalComponentDefinition.Thickness.Value * 10).ToString

        Dim strMaterialName As String
        strMaterialName = oInventorPartDocument.ComponentDefinition.Material.Name.ToString()

        Dim strMaterials() As String = Split(str钣金厚度前缀, ",")

        Dim strTemp As String
        Dim IsMatching As Boolean = False

        For Each strMaterial As String In strMaterials
            strTemp = strMaterial & strThickness

            If Strings.InStr(strMaterialName.ToLower, strTemp.ToLower) <> 0 Then
                IsMatching = True
                Exit For
            Else
                IsMatching = False
            End If
        Next

        Return IsMatching

    End Function

    ''' <summary>
    ''' 在草图中单击，获取一个点
    ''' </summary>
    ''' <param name="StrInformation">鼠标提示文字</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetLineInSketch(ByVal StrInformation As String, CenterPoint2d As Point2d) As Point2d
        Dim oGetLineInSketch As New ClsGetLineInSketch
        Dim oPoint As Point2d

        Do
            oPoint = oGetLineInSketch.GetLineInSketch(StrInformation, MouseButtonEnum.kLeftMouseButton, CenterPoint2d)
            If oPoint IsNot Nothing Then
                ' MessageBox.Show("Click is at " & Strings.Format(pnt.X, "0.0000") & ", " & Strings.Format(pnt.Y, "0.0000"))
                Return oPoint
            End If
        Loop While oPoint IsNot Nothing

        Return Nothing
    End Function

    ''' <summary>
    ''' 设置基础数量为每个
    ''' </summary>
    Public Sub SetBaseQuantityByEach()

        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject And ThisApplication.ActiveDocumentType <> kPartDocumentObject Then
            MessageBox.Show("该功能仅适用于零部件。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）
            Exit Sub
        End If

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        Try
            oInventorDocument.ComponentDefinition.BOMQuantity.SetBaseQuantity(BOMQuantityTypeEnum.kEachBOMQuantity)

            If TypeOf (oInventorDocument) Is AssemblyDocument Then

                Dim oInventorAssemblyDocument As AssemblyDocument = CType(oInventorDocument, AssemblyDocument)
                oInventorAssemblyDocument.ComponentDefinition.BOMQuantity.SetBaseQuantity(BOMQuantityTypeEnum.kEachBOMQuantity)

                ' 获取所有引用文档
                Dim oInventorDocumentsEnumerator As Inventor.DocumentsEnumerator
                oInventorDocumentsEnumerator = oInventorAssemblyDocument.AllReferencedDocuments

                For Each oInventorDocument In oInventorDocumentsEnumerator
                    oInventorDocument.ComponentDefinition.BOMQuantity.SetBaseQuantity(BOMQuantityTypeEnum.kEachBOMQuantity)
                Next

            End If

            MessageBox.Show("设置基础数量为【每个】完成。", XHTool, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ''' <summary>
    ''' 让镜像文件从基础文件复制材料
    ''' </summary>
    Public Sub CopyMaterialFromBasicPart()
        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        If ThisApplication.ActiveDocumentType <> kPartDocumentObject Then
            MessageBox.Show("该功能仅适用于零件。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）
            Exit Sub
        End If

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        Dim oInventorPartDocument As Inventor.PartDocument
        oInventorPartDocument = CType（oInventorDocument, PartDocument)

        If oInventorPartDocument.ReferencedDocumentDescriptors.Count = 0 Then
            MessageBox.Show("未找到基础文件。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）
            Return
        End If

        Dim oInventorBasicPartDocument As Inventor.PartDocument
        oInventorBasicPartDocument = oInventorPartDocument.ReferencedDocumentDescriptors.Item(1).ReferencedDocument

        If oInventorBasicPartDocument Is Nothing Then
            MessageBox.Show("未找到基础文件。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）
            Return
        End If

        Debug.Print(oInventorBasicPartDocument.FullDocumentName)

        Dim strMaterialName As String
        strMaterialName = oInventorBasicPartDocument.ComponentDefinition.Material.Name.ToString()

        Debug.Print(strMaterialName)

        Dim oMaterial As Inventor.Material
        oMaterial = oInventorPartDocument.Materials.Item(strMaterialName)
        oInventorPartDocument.ComponentDefinition.Material = oMaterial

        '如果不是钣金件，退出
        If (oInventorPartDocument.SubType <> "{9C464203-9BAE-11D3-8BAD-0060B0CE6BB4}") Then
            MessageBox.Show("复制材料完成。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information）
            Return
        End If

        If (oInventorBasicPartDocument.SubType <> "{9C464203-9BAE-11D3-8BAD-0060B0CE6BB4}") Then
            MessageBox.Show("复制材料完成。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information）
            Return
        End If

        Dim oBasicSheetMetalComponentDefinition As Inventor.SheetMetalComponentDefinition
        oBasicSheetMetalComponentDefinition = oInventorBasicPartDocument.ComponentDefinition

        Dim strBasicThickness As String
        strBasicThickness = oBasicSheetMetalComponentDefinition.Thickness.Expression

        Dim oSheetMetalComponentDefinition As Inventor.SheetMetalComponentDefinition
        oSheetMetalComponentDefinition = oInventorPartDocument.ComponentDefinition

        oSheetMetalComponentDefinition.UseSheetMetalStyleThickness = False
        oSheetMetalComponentDefinition.Thickness.Expression = strBasicThickness

        MessageBox.Show("复制材料完成。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information）


    End Sub

End Module