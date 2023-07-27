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

Module IptModule

    '打开对应的工程图
    Public Sub OpenIdwFile()

        On Error Resume Next

        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject And ThisApplication.ActiveDocumentType <> kPartDocumentObject Then
            MsgBox("该功能仅适用于零部件。", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        If oInventorDocument.SelectSet.Count <> 0 Then
            'For Each oSelect As Object In InventorDoc.SelectSet
            For Each ComponentOccurrence As ComponentOccurrence In oInventorDocument.SelectSet()
                oInventorDocument = ThisApplication.Documents.ItemByName(ComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName)
                OpenDrawingDocument(oInventorDocument)
                Exit Sub
            Next
        Else
            OpenDrawingDocument(oInventorDocument)
            Exit Sub
        End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    '另存为stp文件
    Public Sub AsmIptSaveAsStp()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject And ThisApplication.ActiveDocumentType <> kPartDocumentObject Then
                MsgBox("该功能仅适用于零部件。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim oInventorDocument As Inventor.Document
            oInventorDocument = ThisApplication.ActiveDocument

            Dim strInventorDocument As String
            strInventorDocument = oInventorDocument.FullFileName

            'If strInventorDocument = "" Then
            '    MsgBox("请先保存本零部件。", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            Dim strStpFullFileName As String        'cad 文件全文件名
            strStpFullFileName = GetChangeExtension(strInventorDocument, STP)
            strStpFullFileName = SetNewFile(strStpFullFileName, "STEP文件(*.stp)|*.stp")

            If strStpFullFileName = "取消" Then
                Exit Sub
            End If

            AsmIptSaveAsStpSub(oInventorDocument, strStpFullFileName)

            If IsFileExsts(strStpFullFileName) Then
                SetStatusBarText("另存为STEP完成")
                If MsgBox("是否打开文件： " & strStpFullFileName, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    System.Diagnostics.Process.Start(strStpFullFileName)
                End If
            Else
                SetStatusBarText("错误")
                MsgBox("错误。", MsgBoxStyle.Exclamation)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '另存为 stp文件子过程
    Public Sub AsmIptSaveAsStpSub(ByVal InventorDocument As Inventor.Document, ByVal strStepFullFileName As String)

        ' Get the STEP translator Add-In.
        Dim oSTEPTranslator As TranslatorAddIn
        oSTEPTranslator = ThisApplication.ApplicationAddIns.ItemById("{90AF7F40-0C01-11D5-8E83-0010B541CD80}")

        If oSTEPTranslator Is Nothing Then
            'MsgBox("无法转换为Step文件。")
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

            Call oSTEPTranslator.SaveCopyAs(InventorDocument, oContext, oOptions, oData)
        End If
    End Sub

End Module