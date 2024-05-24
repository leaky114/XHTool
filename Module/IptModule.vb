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

    '打开对应的工程图
    Public Sub OpenIdwFile()

        On Error Resume Next

        SetStatusBarText()

        if IsInventorOpenDocument() = False Then
            Exit Sub
        End if

        if ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject And ThisApplication.ActiveDocumentType <> kPartDocumentObject Then
            MsgBox("该功能仅适用于零部件。", MsgBoxStyle.Information)
            Exit Sub
        End if

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        if oInventorDocument.SelectSet.Count <> 0 Then
            'For Each oSelect As Object In InventorDoc.SelectSet
            For Each ComponentOccurrence As ComponentOccurrence In oInventorDocument.SelectSet()
                oInventorDocument = ThisApplication.Documents.ItemByName(ComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName)
                OpenDrawingDocument(oInventorDocument)
                Exit Sub
            Next
        Else
            OpenDrawingDocument(oInventorDocument)
            Exit Sub
        End if

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    '另存为stp文件
    Public Sub AsmIptSaveAsStp()
        Try
            SetStatusBarText()

            if IsInventorOpenDocument() = False Then
                Exit Sub
            End if

            if ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject And ThisApplication.ActiveDocumentType <> kPartDocumentObject Then
                MsgBox("该功能仅适用于零部件。", MsgBoxStyle.Information)
                Exit Sub
            End if

            Dim oInventorDocument As Inventor.Document
            oInventorDocument = ThisApplication.ActiveEditDocument

            Dim strInventorDocument As String
            strInventorDocument = oInventorDocument.FullFileName

            'if strInventorDocument = "" Then
            '    MsgBox("请先保存本零部件。", MsgBoxStyle.Information)
            '    Exit Sub
            'End if

            Dim strStpFullFileName As String        'cad 文件全文件名
            strStpFullFileName = GetChangeExtension(strInventorDocument, STP)
            strStpFullFileName = SetNewFile(strStpFullFileName, "STEP文件(*.stp)|*.stp")

            if strStpFullFileName = "取消" Then
                Exit Sub
            End if

            AsmIptSaveAsStpSub(oInventorDocument, strStpFullFileName)

            if IsFileExsts(strStpFullFileName) Then
                SetStatusBarText("另存为STEP完成")
                if MsgBox("是否打开文件： " & strStpFullFileName, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    System.Diagnostics.Process.Start(strStpFullFileName)
                End if
            Else
                SetStatusBarText("错误")
                MsgBox("错误。", MsgBoxStyle.Exclamation)

            End if
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '另存为 stp文件子过程
    Public Sub AsmIptSaveAsStpSub(ByVal InventorDocument As Inventor.Document, ByVal strStepFullFileName As String)

        ' Get the STEP translator Add-In.
        Dim oSTEPTranslator As TranslatorAddIn
        oSTEPTranslator = ThisApplication.ApplicationAddIns.ItemById("{90AF7F40-0C01-11D5-8E83-0010B541CD80}")

        if oSTEPTranslator Is Nothing Then
            'MsgBox("无法转换为Step文件。")
            Exit Sub
        End if

        Dim oContext As TranslationContext
        oContext = ThisApplication.TransientObjects.CreateTranslationContext
        Dim oOptions As NameValueMap
        oOptions = ThisApplication.TransientObjects.CreateNameValueMap
        if oSTEPTranslator.HasSaveCopyAsOptions(ThisApplication.ActiveDocument, oContext, oOptions) Then
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

            Call oSTEPTranslator.SaveCopyAs(InventorDocument, oContext, oOptions, oData)
        End if
    End Sub

    '替换衍生
    Public Sub ReplaceDerivedPart()
        SetStatusBarText()

        if IsInventorOpenDocument() = False Then
            Exit Sub
        End if

        'if ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
        '    MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
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
            MessageBox.Show("更换零件 (" & replacementPart.DisplayName & ") 似乎与原始零件关系不密切，因此无法使用.", _
            "基础零件替换器", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            doReplace = False
        End if
        replacementPart.ReleaseReference()

        if (Not doReplace) Then Return

        Dim fileNameToReplace As String = docToReplace.FullFileName
        ReplaceReferences(oInventorDocument, fileNameToReplace, replacementFileName)
        oInventorDocument.Update()
    End Sub

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
            MessageBox.Show("在文档中未找到基本零件: " & oInventorDocument.DisplayName, "基础零件替换器")
        Elseif (basePartList.Count = 1) Then
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

    Public Sub AddBaseParts(ByVal basePartList As List(Of Document), ByVal doc As Document)
        For Each refDoc As Document In doc.ReferencedDocuments
            if (refDoc.DocumentType = DocumentTypeEnum.kPartDocumentObject AndAlso Not IsiPartMember(refDoc)) Then
                if (Not basePartList.Contains(refDoc)) Then
                    basePartList.Add(refDoc)
                End if
            End if
        Next
    End Sub

    Function IsiPartMember(ByVal doc As Document) As Boolean
        if (doc.DocumentType <> DocumentTypeEnum.kPartDocumentObject) Then Return False
        Dim partDoc As PartDocument = DirectCast(doc, PartDocument)
        Return partDoc.ComponentDefinition.IsiPartMember
    End Function

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

    Sub ReplaceReferences(ByVal oInventorDocument As Document, ByVal fileNameToReplace As String, ByVal replacementFileName As String)
        ReplaceReferencesInOneDoc(oInventorDocument, fileNameToReplace, replacementFileName)

        For Each subDoc As Document In oInventorDocument.AllReferencedDocuments
            if (String.Equals(subDoc.FullFileName, fileNameToReplace, StringComparison.OrdinalIgnoreCase) OrElse _
             String.Equals(subDoc.FullFileName, replacementFileName, StringComparison.OrdinalIgnoreCase)) Then
                Continue For
            End if
            ReplaceReferencesInOneDoc(subDoc, fileNameToReplace, replacementFileName)
        Next
    End Sub

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

    Function LevelOfDetailIsMaster(oInventorDocument As Inventor.Document) As Boolean
        Dim assemDoc As AssemblyDocument = TryCast(oInventorDocument, AssemblyDocument)
        if (assemDoc Is Nothing) Then Return True

        Dim repMgr As RepresentationsManager = assemDoc.ComponentDefinition.RepresentationsManager

        Dim lodType As LevelOfDetailEnum = repMgr.ActiveLevelOfDetailRepresentation.LevelOfDetail
        if (lodType <> LevelOfDetailEnum.kMasterLevelOfDetail) Then
            MessageBox.Show("此规则只能在主要详细等级中运行.", "基础零件替换器")
            Return False
        End if
        Return True
    End Function


End Module