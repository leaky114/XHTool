Imports Inventor
Imports Inventor.AssetTypeEnum
Imports Inventor.BOMStructureEnum
Imports Inventor.DocumentTypeEnum
Imports Inventor.DrawingViewTypeEnum
Imports Inventor.IOMechanismEnum
Imports Inventor.PrintOrientationEnum
Imports Inventor.PropertyTypeEnum
Imports Inventor.SelectionFilterEnum
Imports Inventor.ViewOrientationTypeEnum
Imports Inventor.DrawingViewStyleEnum
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel.XlCellType
Imports Microsoft.Office.Interop.Excel.XlFileFormat
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Module IdwModule

    'idw另存为dwg
    Public Sub IdwSaveAsDwg()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            Dim strInventorDrawingDocumentFullFileName As String
            strInventorDrawingDocumentFullFileName = oInventorDrawingDocument.FullFileName

            If IsFileExsts(strInventorDrawingDocumentFullFileName) = False Then
                'MsgBox("请先保存本工程图。", MsgBoxStyle.Information)
                'Exit Sub

                strInventorDrawingDocumentFullFileName = My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & oInventorDrawingDocument.DisplayName & IDW
                oInventorDrawingDocument.SaveAs(strInventorDrawingDocumentFullFileName, False)

            End If

            Dim strDwgFullFileName As String        'cad 文件全文件名

            If str另存到子文件夹 = "1" Then
                Dim strChildDirectory As String
                strChildDirectory = GetDirectoryName2(strInventorDrawingDocumentFullFileName) & "\CAD\"
                If IsDirectoryExists(strChildDirectory) = False Then
                    IO.Directory.CreateDirectory(strChildDirectory)
                End If
                strDwgFullFileName = strChildDirectory & GetFileNameInfo(strInventorDrawingDocumentFullFileName).OnlyName & DWG
            Else
                strDwgFullFileName = GetChangeExtension(strInventorDrawingDocumentFullFileName, DWG)
            End If

            strDwgFullFileName = SetNewFile(strDwgFullFileName, "AutoCAD文件(*.dwg)|*.dwg")



            If Strings.InStr(strDwgFullFileName, "取消") = 1 Then
                strDwgFullFileName = Strings.Replace(strDwgFullFileName, "取消", "")
                Process.Start(strDwgFullFileName)
                Exit Sub
            End If

            IdwSaveAsDwgSub(strInventorDrawingDocumentFullFileName, strDwgFullFileName)

            If IsFileExsts(strDwgFullFileName) Then
                SetStatusBarText("另存为DWG完成")
                If MsgBox("是否打开文件： " & strDwgFullFileName, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    System.Diagnostics.Process.Start(strDwgFullFileName)
                End If
            Else
                SetStatusBarText("错误")
                MsgBox("错误。", MsgBoxStyle.Exclamation)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '另存为dwg子过程
    Public Sub IdwSaveAsDwgSub(ByVal strInventorDrawingDocumentFullFileName As String, ByVal strDwgFullFileName As String)

        'IdwDoc.SaveAs(DwgFullFileName, True)

        'if IsFileExsts(DwgFullFileName) = False Then
        '    DwgFullFileName = Strings.Replace(DwgFullFileName, ".dwg", ".zip")
        'End if

        Dim oInventorDrawingDocument As Inventor.DrawingDocument

        If strInventorDrawingDocumentFullFileName = "" Then
            oInventorDrawingDocument = ThisApplication.ActiveDocument
        Else
            oInventorDrawingDocument = ThisApplication.Documents.ItemByName(strInventorDrawingDocumentFullFileName)
        End If

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
        If oTranslatorAddIn.HasSaveCopyAsOptions(oInventorDrawingDocument, oTranslationContext, oNameValueMap) Then
            ' 设置导出样式.
            oNameValueMap.Value("Solid") = True      ' 导出 solids.
            oNameValueMap.Value("Surface") = False   ' 导出 surfaces.
            oNameValueMap.Value("Sketch") = False    ' 导出 sketches.

            ' 设置导出DWG的版本.
            ' 23 = ACAD 2000
            ' 25 = ACAD 2004
            ' 27 = ACAD 2007
            ' 29 = ACAD 2010
            oNameValueMap.Value("DwgVersion") = 25
        End If

        ' 设置导出文件名.
        Dim oDataMedium As DataMedium
        oDataMedium = oTransientObjects.CreateDataMedium
        oDataMedium.FileName = strDwgFullFileName

        ' 调用SaveCopyAs
        Call oTranslatorAddIn.SaveCopyAs(oInventorDrawingDocument, oTranslationContext, oNameValueMap, oDataMedium)

    End Sub

    '另存为pdf
    Public Sub IdwSaveAsPdf()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument


            Dim strInventorDrawingDocumentFullFileName As String
            strInventorDrawingDocumentFullFileName = oInventorDrawingDocument.FullFileName

            If IsFileExsts(strInventorDrawingDocumentFullFileName) = False Then
                'MsgBox("请先保存本工程图。", MsgBoxStyle.Information)
                'Exit Sub

                strInventorDrawingDocumentFullFileName = My.Computer.FileSystem.SpecialDirectories.Temp & "\" & oInventorDrawingDocument.DisplayName & IDW
                oInventorDrawingDocument.SaveAs(strInventorDrawingDocumentFullFileName, False)
            End If

            Dim strPdfFullFileName As String        'pdf文件全文件名

            If str另存到子文件夹 = "1" Then
                Dim strChildDirectory As String
                strChildDirectory = GetDirectoryName2(strInventorDrawingDocumentFullFileName) & "\PDF\"
                If IsDirectoryExists(strChildDirectory) = False Then
                    IO.Directory.CreateDirectory(strChildDirectory)
                End If
                strPdfFullFileName = strChildDirectory & GetFileNameInfo(strInventorDrawingDocumentFullFileName).OnlyName & PDF
            Else
                strPdfFullFileName = GetChangeExtension(strInventorDrawingDocumentFullFileName, PDF)
            End If

            strPdfFullFileName = SetNewFile(strPdfFullFileName, "Adobe PDF文件(*.pdf)|*.pdf")

            If Strings.InStr(strPdfFullFileName, "取消") = 1 Then
                strPdfFullFileName = Strings.Replace(strPdfFullFileName, "取消", "")
                Process.Start(strPdfFullFileName)
                Exit Sub
            End If

            IdwSaveAsPdfSub(strInventorDrawingDocumentFullFileName, strPdfFullFileName)

            If IsFileExsts(strPdfFullFileName) Then
                SetStatusBarText("另存为Pdf文件完成")
                If MsgBox("是否打开文件： " & strPdfFullFileName, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    System.Diagnostics.Process.Start(strPdfFullFileName)
                End If
            Else
                SetStatusBarText("错误")
                MsgBox("错误。", MsgBoxStyle.Exclamation)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '另存为pdf子过程
    Public Sub IdwSaveAsPdfSub(ByVal strInventorDrawingDocumentFullFileName As String, ByVal strPdfFullFileName As String)

        Dim oInventorDrawingDocument As Inventor.DrawingDocument

        If strInventorDrawingDocumentFullFileName = "" Then
            oInventorDrawingDocument = ThisApplication.ActiveDocument
        Else
            oInventorDrawingDocument = ThisApplication.Documents.ItemByName(strInventorDrawingDocumentFullFileName)
        End If


        ' Get the PDF translator Add-In.
        Dim PDFAddIn As TranslatorAddIn
        PDFAddIn = ThisApplication.ApplicationAddIns.ItemById("{0AC6FD96-2F4D-42CE-8BE0-8AEA580399E4}")

        'Set a reference to the active document (the document to be published).

        Dim oContext As TranslationContext
        oContext = ThisApplication.TransientObjects.CreateTranslationContext
        oContext.Type = kFileBrowseIOMechanism

        ' Create a NameValueMap object
        Dim oOptions As NameValueMap
        oOptions = ThisApplication.TransientObjects.CreateNameValueMap

        ' Create a DataMedium object
        Dim oDataMedium As DataMedium
        oDataMedium = ThisApplication.TransientObjects.CreateDataMedium

        ' Check whether the translator has 'SaveCopyAs' options
        If PDFAddIn.HasSaveCopyAsOptions(oInventorDrawingDocument, oContext, oOptions) Then

            ' Options for drawings...

            oOptions.Value("All_Color_AS_Black") = 0

            'oOptions.Value("Remove_Line_Weights") = 0
            'oOptions.Value("Vector_Resolution") = 400
            'oOptions.Value("Sheet_Range") = kPrintAllSheets
            'oOptions.Value("Custom_Begin_Sheet") = 2
            'oOptions.Value("Custom_End_Sheet") = 4

        End If

        'Set the destination file name
        oDataMedium.FileName = strPdfFullFileName

        'Publish document.
        Call PDFAddIn.SaveCopyAs(oInventorDrawingDocument, oContext, oOptions, oDataMedium)

    End Sub

    '在尺寸前添加φ
    Public Sub AddDiameter()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            Dim oLinearGeneralDimension As LinearGeneralDimension    '选择的部件或零件

            Dim strDimension As String
            Dim strFai As String

            ' 是否已经选择了尺寸
            If oInventorDrawingDocument.SelectSet.Count <> 0 Then
                For Each oSelect As Object In oInventorDrawingDocument.SelectSet
                    If oSelect.Type = ObjectTypeEnum.kLinearGeneralDimensionObject Then

                        '添加Φ, 内部代号n
                        strFai = "<StyleOverride Font='AIGDT'>n</StyleOverride>"
                        strDimension = strFai & "<DimensionValue/>"
                        oSelect.Text.FormattedText = strDimension

                    End If
                Next
            Else
                oLinearGeneralDimension = ThisApplication.CommandManager.Pick(kDrawingDefaultFilter, "选择要添加Φ的尺寸，ESC键取消")
                If oLinearGeneralDimension Is Nothing Then       '取消选择
                    Exit Sub
                End If

                strFai = "<StyleOverride Font='AIGDT'>n</StyleOverride>"
                strDimension = strFai & "<DimensionValue/>"
                oLinearGeneralDimension.Text.FormattedText = strDimension

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '尺寸精度圆整
    Public Function DimensionRounding() As Boolean
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Function
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
                Exit Function
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            Dim oLinearGeneralDimension As LinearGeneralDimension    '选择的部件或零件

            ' 是否已经选择了尺寸
            If oInventorDrawingDocument.SelectSet.Count <> 0 Then
                For Each oSelectSet As Object In oInventorDrawingDocument.SelectSet
                    If oSelectSet.Type = ObjectTypeEnum.kLinearGeneralDimensionObject Then
                        oSelectSet.Precision = 0
                    End If
                Next
            Else
                oLinearGeneralDimension = ThisApplication.CommandManager.Pick(kDrawingDefaultFilter, "选择要圆整的尺寸，ESC键取消")
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

    '设置全部标注文字居中
    Public Sub CenterAllDimensions()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            ' Set a reference to the active sheet
            Dim oSheet As Sheet
            oSheet = oInventorDrawingDocument.ActiveSheet

            Dim oDrawingDim As DrawingDimension

            ' Iterate over all dimensions in the drawing and
            ' center them if they are linear or angular.

            '撤销功能
            Dim oTransaction As Transaction
            oTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "My Transaction")

            Dim oarrangeDims = ThisApplication.TransientObjects.CreateObjectCollection

            For Each oDrawingDim In oSheet.DrawingDimensions

                If TypeOf oDrawingDim Is LinearGeneralDimension Or TypeOf oDrawingDim Is AngularGeneralDimension Then
                    oDrawingDim.CenterText()
                    oarrangeDims.Add(oDrawingDim)
                End If
            Next

            oSheet.DrawingDimensions.Arrange(oarrangeDims)

            oTransaction.End()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '设置选择的标注文字居中
    Public Sub CenterDimensions()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            Dim oDrawingDim As DrawingDimension    '选择的尺寸标注

            ' 是否已经选择了尺寸
            If oInventorDrawingDocument.SelectSet.Count <> 0 Then
                For Each oSelectSet As Object In oInventorDrawingDocument.SelectSet
                    If TypeOf oSelectSet Is LinearGeneralDimension Or TypeOf oSelectSet Is AngularGeneralDimension Then
                        oSelectSet.CenterText()
                    End If
                Next
            Else
                '循环选择设置，直到esc键取消选择
                Do
                    oDrawingDim = ThisApplication.CommandManager.Pick(kDrawingDimensionFilter, "选择要文字居中的尺寸，ESC键取消。")
                    If TypeOf oDrawingDim Is LinearGeneralDimension Or TypeOf oDrawingDim Is AngularGeneralDimension Then
                        oDrawingDim.CenterText()
                    End If

                Loop Until (oDrawingDim Is Nothing)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '设置对称件iProperty
    Public Sub SetDrawingMirPartIPro()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            If SetDrawingMirPartIProSub(oInventorDrawingDocument) Then
                SetStatusBarText("设置工程图自定义属性：对称件IPro")
                'MsgBox("设置工程图自定义属性：对称件IPro", MsgBoxStyle.Information)
            Else
                SetStatusBarText("错误")
                MsgBox("错误。", MsgBoxStyle.Exclamation)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '设置工程图自定义属性：对称件IPro
    Public Function SetDrawingMirPartIProSub(ByVal oInventorDrawingDocument As Inventor.DrawingDocument) As Boolean
        Dim oSheet As Sheet
        oSheet = oInventorDrawingDocument.ActiveSheet

        If oSheet.DrawingViews.Count = 0 Then
            MsgBox("先添加一个视图。", MsgBoxStyle.Information)
            Return False
        End If

        Dim oView As DrawingView
        oView = oSheet.DrawingViews.Item(1)

        Dim oRef As DocumentDescriptor
        oRef = oView.ReferencedDocumentDescriptor



        '获取本零件文件夹路径
        Dim strMirFileFullFileName As String
        Dim oOpenFileDialog As New OpenFileDialog
        With oOpenFileDialog
            .Multiselect = False
            .Title = "设置镜像工程图iPro"
            .Filter = "Inventor 文件(*.ipt;*.iam)|*.ipt;*.iam|Inventor 零件(*.ipt)|*.ipt|Inventor 部件(*.iam)|*.iam"
            .InitialDirectory = GetDirectoryName2(oRef.FullDocumentName)
            If .ShowDialog = DialogResult.OK Then
                strMirFileFullFileName = .FileName
            Else
                Return True
                Exit Function
            End If
        End With

        '获取镜像零件ipro
        Dim oStockNumPartName As StockNumPartName

        '从文件名获取
        'oStockNumPartName = GetStockNumPartName(strMirFileFullFileName)

        '读取文件iProperty
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.Documents.Open(strMirFileFullFileName, False)
        oStockNumPartName = GetPropitems(oInventorDocument)
        oInventorDocument.Close(False)


        '设置ipro
        Dim pEachScale As [Property]
        Try
            '若该iProperty已经存在，则直接修改其值
            pEachScale = oInventorDrawingDocument.PropertySets.Item("User Defined Properties").Item(Map_Mir_StochNum)
            pEachScale.Value = oStockNumPartName.图号

            pEachScale = oInventorDrawingDocument.PropertySets.Item("User Defined Properties").Item(Map_Mir_PartName)
            pEachScale.Value = oStockNumPartName.零件名称

        Catch
            ' 若该iProperty不存在，则添加一个
            oInventorDrawingDocument.PropertySets.Item("User Defined Properties").Add(oStockNumPartName.图号, Map_Mir_StochNum)
            oInventorDrawingDocument.PropertySets.Item("User Defined Properties").Add(oStockNumPartName.零件名称, Map_Mir_PartName)
        End Try

        If MsgBox("是否添加对称件说明标签？", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then


            ' Set a reference to the GeneralNotes object
            Dim oGeneralNotes As GeneralNotes
            oGeneralNotes = oSheet.DrawingNotes.GeneralNotes

            Dim strFormattedText As String

            Dim strFontName As String
            strFontName = "仿宋"

            Dim strTitle As String

            strTitle = "对称件:<Property Document='drawing' PropertySet='User Defined Properties' Property='" & _
                Map_Mir_StochNum & "' FormatID='{D5CDD505-2E9C-101B-9397-08002B2CF9AE}'>" & Map_Mir_StochNum & _
                "</Property><Property Document='drawing' PropertySet='User Defined Properties' Property='" & Map_Mir_PartName & _
                "' FormatID='{D5CDD505-2E9C-101B-9397-08002B2CF9AE}'>" & Map_Mir_PartName & "</Property>,此图为左件"

            'strTitle = "对称件：" & oStockNumPartName.StockNum & oStockNumPartName.零件名称

            Dim str1 As String = "<StyleOverride Font='"
            Dim str2 As String = "'>"
            Dim str3 As String = ""
            Dim str4 As String = "</StyleOverride>"
            Dim str5 As String = "<Br/>"

            '     <StyleOverride Font='隶书'>技术要求</StyleOverride><Br/>

            strFormattedText = str1 & strFontName & str2 & strTitle & str4

            Dim oTG As TransientGeometry
            oTG = ThisApplication.TransientGeometry

            Dim oGeneralNote As GeneralNote
            oGeneralNote = oGeneralNotes.AddFitted(oTG.CreatePoint2d(4, 10), strFormattedText)

        End If

        oInventorDrawingDocument.Update()   '刷新数据

        Return True

    End Function

    '替换图框和标题栏
    Public Sub ReplaceBorderTitleBlock()
        On Error Resume Next

        'Try
        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
            MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim oInventorDrawingDocument As Inventor.DrawingDocument
        oInventorDrawingDocument = ThisApplication.ActiveDocument

        If IsFileExsts(str工程图模板) = False Then
            MsgBox("找不到模板文件：" & str工程图模板, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "错误")
            'TitleBlockIdwDoc = My.Application.Info.DirectoryPath
            'Process.Start(TitleBlockIdwDoc)
            'TitleBlockIdwDoc = ThisApplication.FileOptions.TemplatesPath
            'Process.Start(TitleBlockIdwDoc)
            Exit Sub
        End If

        Dim strTitleBlock As String
        strTitleBlock = My.Application.Info.DirectoryPath & "\TitleBlock.ini"

        If IsFileExsts(strTitleBlock) = False Then
            MsgBox("无配置文件,请手动配置！", MsgBoxStyle.Information)

            Dim file As New StreamWriter(strTitleBlock)
            file.WriteLine("#号行勿修改")
            file.WriteLine("#Border 默认图框")
            file.WriteLine("#Border = NX")
            file.WriteLine("#Title旧的和新的对映表")
            file.WriteLine("#SH(-零件 = NX - 零件)")
            file.Close()

            Process.Start(strTitleBlock)

            Exit Sub
        End If

        '撤销功能
        Dim oTransaction As Transaction
        oTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "My Transaction")

        Dim oSheets As Sheets
        oSheets = oInventorDrawingDocument.Sheets

        Dim oSheet As Sheet

        Dim strOldTitleBlockName As String = Nothing

        '删除旧图框和标题栏
        For Each oSheet In oSheets
            oSheet.Activate()
            strOldTitleBlockName = oSheet.TitleBlock.Name
            oSheet.TitleBlock.Delete()
            oSheet.Border.Delete()
        Next

        '复制新标题栏
        'Re-Activate the first sheet again
        oSheets.Item(1).Activate()
        'Attempt to delete all TitleBlockDefinitions
        Dim oTitleBlockDefinitions As TitleBlockDefinitions
        oTitleBlockDefinitions = oInventorDrawingDocument.TitleBlockDefinitions

        Dim oTitleBlockDefinition As TitleBlockDefinition
        For Each oTitleBlockDefinition In oTitleBlockDefinitions
            If oTitleBlockDefinition.IsReferenced = False Then
                oTitleBlockDefinition.Delete()
            ElseIf oTitleBlockDefinition.IsReferenced = True Then
                '         s = MsgBox("Title Block Def Named '" & oTBDef.Name & "' is referenced, and will not be deleted.", vbOKOnly + vbInformation, "CAN'T BE DELETED")
            End If
        Next

        Dim oTitleBlockInventorDrawingDocument As Inventor.DrawingDocument

        int模型匹配检查标记 = 2
        'MsgBox(int模型匹配检查标记)

        oTitleBlockInventorDrawingDocument = ThisApplication.Documents.Open(str工程图模板, False)


        Dim oTemplateTitleBlockDefinitions As TitleBlockDefinitions
        oTemplateTitleBlockDefinitions = oTitleBlockInventorDrawingDocument.TitleBlockDefinitions

        Dim oTemplateTitleBlockDefinition As TitleBlockDefinition

        Dim oNewTitleBlockDefinition As TitleBlockDefinition = Nothing
        For Each oTemplateTitleBlockDefinition In oTemplateTitleBlockDefinitions
            'if oTemplateTitleBlockDefinition.Name = "NX-零件" Then
            oNewTitleBlockDefinition = oTemplateTitleBlockDefinition.CopyTo(oInventorDrawingDocument, True)
            'End if
        Next

        '复制新图框
        Dim oTemplateBorderDefinitions As BorderDefinitions
        oTemplateBorderDefinitions = oTitleBlockInventorDrawingDocument.BorderDefinitions

        Dim oTemplateBorderDefinition As BorderDefinition

        Dim oNewBorderDefinition As BorderDefinition = Nothing

        For Each oTemplateBorderDefinition In oTemplateBorderDefinitions
            'if oTemplateBorderDefinition.Name = "NX" Then
            oNewBorderDefinition = oTemplateBorderDefinition.CopyTo(oInventorDrawingDocument, True)
            'End if
        Next

        Dim strNewBorder As String = Nothing
        Dim strNewTitleBlockName As String = Nothing

        Dim intFreeFile As Integer
        intFreeFile = FreeFile()

        Dim strLine As String

        Microsoft.VisualBasic.FileOpen(intFreeFile, strTitleBlock, OpenMode.Input, OpenAccess.Default, OpenShare.Default)

        Do While Not EOF(intFreeFile)
            strLine = LineInput(intFreeFile)

            '跳过注释
            If Strings.Left(strLine, 1) = "#" Then
                Continue Do
            End If

            '获取新的图框名
            If Strings.Left(strLine, 6) = "Border" Then
                strNewBorder = Strings.Replace(strLine, "Border=", "")
                Continue Do
            End If

            '对比到旧的title
            If Strings.InStr(strLine, strOldTitleBlockName) = 1 Then
                strOldTitleBlockName = strOldTitleBlockName & "="
                strNewTitleBlockName = Strings.Replace(strLine, strOldTitleBlockName, "")
                Exit Do
            End If

        Loop
        FileClose(intFreeFile)

        oNewTitleBlockDefinition = oInventorDrawingDocument.TitleBlockDefinitions.Item(strNewTitleBlockName)
        oNewBorderDefinition = oInventorDrawingDocument.BorderDefinitions.Item(strNewBorder)

        For Each oSheet In oSheets
            oSheet.Activate()
            oSheet.AddTitleBlock(oNewTitleBlockDefinition, TitleBlockLocationEnum.kBottomRightPosition)
            oSheet.AddBorder(oNewBorderDefinition)
        Next

        oTitleBlockInventorDrawingDocument.Close(True)
        oSheets.Item(1).Activate()

        oTransaction.End()


        int模型匹配检查标记 = 0
        'MsgBox(int模型匹配检查标记)

        MsgBox("替换图框标题栏完成。", MsgBoxStyle.Information)

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    '检查序号完整性
    Public Function CheckSerialNumber() As Boolean
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Function
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
                Exit Function
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            Dim oActiveSheet As Sheet
            oActiveSheet = oInventorDrawingDocument.ActiveSheet

            If oActiveSheet.Balloons.Count = 0 Then
                MsgBox("该工程图无序号，请添加【序号】。", MsgBoxStyle.Critical)
                Exit Function
            End If

            If oActiveSheet.PartsLists.Count = 0 Then
                MsgBox("该工程图无明细表，请插入一个【明细表】。", MsgBoxStyle.Critical)
                Exit Function
            End If

            Dim oPartsListRows As PartsListRows = oActiveSheet.PartsLists.Item(1).PartsListRows

            Dim strList As String = ""

            '撤销功能
            Dim oTransaction As Transaction
            oTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "My Transaction")

            Dim oInteraction As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
            oInteraction.Start()
            oInteraction.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)

            '新建颜色
            Dim oColor As Color
            oColor = ThisApplication.TransientObjects.CreateColor(255, 0, 128)

            'ThisApplication.ScreenUpdating = False

            Dim strPartName As String
            For Each oPartsListRow As Inventor.PartsListRow In oPartsListRows
                If oPartsListRow.Ballooned = False Then
                    strList = strList & oPartsListRow.Item(1).Value & " , "
                End If

                If oPartsListRow.ReferencedFiles.Count <> 0 Then
                    strPartName = GetFileNameInfo(oPartsListRow.ReferencedFiles(1).FullFileName).OnlyName
                    SetStatusBarText("正在描绘：" & oPartsListRow.ReferencedFiles(1).FullFileName)
                    '设置颜色
                    SetPartCorlor(oInventorDrawingDocument, strPartName, oColor, oPartsListRow.Ballooned)
                End If
            Next


            'ThisApplication.ScreenUpdating = True

            oInteraction.SetCursor(CursorTypeEnum.kCursorTypeDefault)
            oInteraction.Stop()

            If Strings.Len(strList) > 1 Then
                MsgBox("明细表：" & strList & " 无序号。", MsgBoxStyle.Information)
            Else
                MsgBox("检查序号完成。", MsgBoxStyle.Information)
            End If

            oTransaction.End() '事务结束，完成修改操作
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Return True
    End Function

    '设置工程图零件颜色(工程图，零件，颜色，是否有序号)
    Public Sub SetPartCorlor(ByVal oInventorDrawingDocument As Inventor.DrawingDocument, ByVal partStr As String, _
                             ByVal oColor As Color, ByVal oPartsListRowBallooned As Boolean)

        Dim oTransaction As Transaction
        Dim refAssyDef As ComponentDefinition = Nothing

        oTransaction = ThisApplication.TransactionManager.StartTransaction(oInventorDrawingDocument, "Colorize [PART]")

        '遍历图纸
        For Each oSheet As Sheet In oInventorDrawingDocument.Sheets
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
                                            c.LineWeight = c.Segments(1).Layer.LineWeight
                                            'c.Color = oBlackColor
                                    End Select
                                Next
                            Else
                                '没有序号，设置彩色
                                For Each c As DrawingCurve In ViewCurves
                                    c.Color = oColor
                                    c.LineWeight = c.Segments(1).Layer.LineWeight
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

    '自动重建序号
    Public Function RebuildRingSerialNumber() As Boolean
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Function
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
                Exit Function
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            '设置为一个动作，可一次撤销
            Dim transientGeometry As TransientGeometry
            transientGeometry = ThisApplication.TransientGeometry
            'start a transaction so the slot will be within a single undo step

            '撤销功能
            Dim oTransaction As Transaction
            oTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "My Transaction")

            Dim oActiveSheet As Sheet
            oActiveSheet = oInventorDrawingDocument.ActiveSheet

            If oActiveSheet.PartsLists.Count = 0 Then
                MsgBox("该工程图无明细表。", MsgBoxStyle.Critical)
                Return False
                Exit Function
            End If

            Dim userInput As String = InputBox("输入第一个序号", "自动新建序号", 1)

            Dim intFirstBalloonNumber As Integer
            If String.IsNullOrEmpty(userInput) Then
                Return False
                Exit Function
            Else
                Integer.TryParse(userInput, intFirstBalloonNumber)
            End If

            '开始设置序号

            Dim intBalloonNumber As Integer
            intBalloonNumber = intFirstBalloonNumber

            '获取当前balloon的textstyle
            Dim OldBalloonTextStyl As String = oInventorDrawingDocument.StylesManager.ActiveStandardStyle.ActiveObjectDefaults.BalloonStyle.TextStyle.Name

            '获取当前balloonstyle
            Dim oActiveBalloonStyle As BalloonStyle = oInventorDrawingDocument.StylesManager.ActiveStandardStyle.ActiveObjectDefaults.BalloonStyle

            '新建 ZeroBalloonText
            Try
                If oInventorDrawingDocument.StylesManager.TextStyles.Item("ZeroBalloonText") Is Nothing Then

                End If
            Catch ex As Exception
                Dim oZeroBalloonText As TextStyle
                oZeroBalloonText = oInventorDrawingDocument.StylesManager.TextStyles.Item(OldBalloonTextStyl).Copy("ZeroBalloonText")

                Dim oZeroBalloonTextColor As Color = ThisApplication.TransientObjects.CreateColor(255, 0, 128)
                oZeroBalloonText.Color = oZeroBalloonTextColor
            End Try

            '设置当前balloon style 为新的 zeroballoonstyle
            oActiveBalloonStyle.TextStyle = oInventorDrawingDocument.StylesManager.TextStyles.Item("ZeroBalloonText")

            Try
                Dim oDrawingView As DrawingView
                Do

                    oDrawingView = ThisApplication.CommandManager.Pick(kDrawingViewFilter, "选择一个视图，ESC键取消")

                    '100个临时balloon
                    Dim arrayTempBalloonDate(99) As BalloonDate
                    'MsgBox(oDrawingView.Name)

                    '视图中心点
                    Dim oCenterPoint2d As Point2d
                    oCenterPoint2d = oDrawingView.Position

                    Dim i As Integer = 0

                    '获取当前视图中的balloon
                    Dim oBalloon As Balloon
                    For Each oBalloon In oActiveSheet.Balloons

                        ThisApplication.ScreenUpdating = False

                        For Each oBalloonValueSet As BalloonValueSet In oBalloon.BalloonValueSets
                            If oBalloonValueSet.Value >= intBalloonNumber Then
                                oBalloonValueSet.Value = 0
                            End If
                        Next

                        ThisApplication.ScreenUpdating = True

                        If oBalloon.ParentView.Name = oDrawingView.Name Then

                            arrayTempBalloonDate(i).Balloon = oBalloon
                            arrayTempBalloonDate(i).Position = oBalloon.Position
                            arrayTempBalloonDate(i).Position.X = oBalloon.Position.X - oCenterPoint2d.X
                            arrayTempBalloonDate(i).Position.Y = oBalloon.Position.Y - oCenterPoint2d.Y
                            i = i + 1
                        End If

                    Next

                    '获取视图包含的balloon个数
                    Dim intArrayBalloonDateLength As Integer
                    intArrayBalloonDateLength = Array.IndexOf(arrayTempBalloonDate, Nothing)

                    '重新定义balloon数组
                    Array.Resize(arrayTempBalloonDate, intArrayBalloonDateLength)

                    'MsgBox(“”)

                    For i = 0 To intArrayBalloonDateLength - 1
                        Debug.Print(arrayTempBalloonDate(i).Position.X & "       " & arrayTempBalloonDate(i).Position.Y)
                    Next

                    Debug.Print("")

                    Dim j As Integer
                    Dim tempBalloondate As BalloonDate

                    '=============================================
                    '按X值开始排序

                    'For i = 0 To intArrayBalloonDateLength - 1
                    '    For j = 0 To intArrayBalloonDateLength - 2
                    '        if arrayTempBalloonDate(j).Position.X > arrayTempBalloonDate(j + 1).Position.X Then
                    '            tempBalloondate = arrayTempBalloonDate(j)
                    '            arrayTempBalloonDate(j) = arrayTempBalloonDate(j + 1)
                    '            arrayTempBalloonDate(j + 1) = tempBalloondate
                    '        End if
                    '    Next
                    'Next
                    '=============================================
                    '按极角排序

                    Select Case str逆时针序号
                        Case "-1"
                            For i = 0 To intArrayBalloonDateLength - 1
                                For j = 0 To intArrayBalloonDateLength - 2
                                    If Math.Atan2(arrayTempBalloonDate(j).Position.Y, arrayTempBalloonDate(j).Position.X) < _
                                        Math.Atan2(arrayTempBalloonDate(j + 1).Position.Y, arrayTempBalloonDate(j + 1).Position.X) Then
                                        tempBalloondate = arrayTempBalloonDate(j)
                                        arrayTempBalloonDate(j) = arrayTempBalloonDate(j + 1)
                                        arrayTempBalloonDate(j + 1) = tempBalloondate
                                    End If
                                Next
                            Next
                        Case "1"     '顺时针序号
                            For i = 0 To intArrayBalloonDateLength - 1
                                For j = 0 To intArrayBalloonDateLength - 2
                                    If Math.Atan2(arrayTempBalloonDate(j).Position.Y, arrayTempBalloonDate(j).Position.X) > _
                                        Math.Atan2(arrayTempBalloonDate(j + 1).Position.Y, arrayTempBalloonDate(j + 1).Position.X) Then
                                        tempBalloondate = arrayTempBalloonDate(j)
                                        arrayTempBalloonDate(j) = arrayTempBalloonDate(j + 1)
                                        arrayTempBalloonDate(j + 1) = tempBalloondate
                                    End If
                                Next
                            Next


                    End Select
                    '=============================================
                    For i = 0 To intArrayBalloonDateLength - 1
                        Debug.Print(arrayTempBalloonDate(i).Position.X & "       " & arrayTempBalloonDate(i).Position.Y)
                    Next

                    '重新写序号
                    Dim ofirstballoon As Balloon
                    ofirstballoon = ThisApplication.CommandManager.Pick(kDrawingBalloonFilter, "选择第一个序号，ESC键取消")

                    '选择的balloon在数组中的位置
                    Dim intfirstballoon As Integer

                    For j = 0 To intArrayBalloonDateLength - 1
                        If arrayTempBalloonDate(j).Balloon Is ofirstballoon Then
                            intfirstballoon = j
                        End If
                    Next

                    For j = intfirstballoon To intArrayBalloonDateLength - 1
                        oBalloon = arrayTempBalloonDate(j).Balloon
                        For Each oBalloonValueSet As BalloonValueSet In oBalloon.BalloonValueSets
                            If oBalloonValueSet.Value = 0 Then
                                oBalloonValueSet.Value = intBalloonNumber
                                intBalloonNumber = intBalloonNumber + 1
                            End If
                        Next
                    Next j

                    For j = 0 To intfirstballoon
                        oBalloon = arrayTempBalloonDate(j).Balloon
                        For Each oBalloonValueSet As BalloonValueSet In oBalloon.BalloonValueSets
                            If oBalloonValueSet.Value = 0 Then
                                oBalloonValueSet.Value = intBalloonNumber
                                intBalloonNumber = intBalloonNumber + 1
                            End If
                        Next
                    Next j

                    'end the transactio

                Loop While True
            Catch ex As Exception

                'esc 退出后，还原balloon style
                oActiveBalloonStyle.TextStyle = oInventorDrawingDocument.StylesManager.TextStyles.Item(OldBalloonTextStyl)

            End Try

            SetStatusBarText("重建序号完成")
            'MsgBox("设置工程图自定义属性：比例完成", MsgBoxStyle.Information)

            If MsgBox("明细栏是否排序？", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then

                oActiveSheet = oInventorDrawingDocument.ActiveSheet

                If oActiveSheet.PartsLists.Count = 0 Then
                    MsgBox("该工程图无明细表。", MsgBoxStyle.Critical)
                    Exit Function
                End If

                For Each oInventorPartsListRow As Inventor.PartsListRow In oActiveSheet.PartsLists.Item(1).PartsListRows
                    oInventorPartsListRow.SaveItemOverridesToBOM()
                Next

                oActiveSheet.PartsLists(1).Sort("序号", True)
            End If

            '事务结束，完成修改操作
            oTransaction.End()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    '新建序号
    Public Sub CreateNewSequenceNumber()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            '撤销功能
            Dim oTransaction As Transaction
            oTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "My Transaction")

            'start a transaction so the slot will be within a single undo step
            Dim createSlotTransaction As Transaction
            createSlotTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "重新设置序号")

            Dim oActiveSheet As Sheet
            oActiveSheet = oInventorDrawingDocument.ActiveSheet

            If oActiveSheet.PartsLists.Count = 0 Then
                MsgBox("该工程图无明细表", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim strFirstBalloonNumber As String = InputBox("输入第一个序号", "重建序号", 1)
            Dim intFirstBalloonNumber As Integer

            If String.IsNullOrEmpty(strFirstBalloonNumber) Then
                Exit Sub
            Else
                Integer.TryParse(strFirstBalloonNumber, intFirstBalloonNumber)
            End If

            Dim intBalloonNumber As Integer
            intBalloonNumber = intFirstBalloonNumber

            '        '设置序号为0
            'Dim partslistrow As Inventor.PartsListRow

            ThisApplication.ScreenUpdating = False

            For Each oPartsList As Inventor.PartsListRow In oActiveSheet.PartsLists.Item(1).PartsListRows
                If oPartsList.Item(1).Value >= intFirstBalloonNumber Then
                    oPartsList.Item(1).Value = 0
                End If
            Next

            ThisApplication.ScreenUpdating = True

            '获取当前balloon的textstyle
            Dim OldBalloonTextStyl As String = oInventorDrawingDocument.StylesManager.ActiveStandardStyle.ActiveObjectDefaults.BalloonStyle.TextStyle.Name

            '获取当前balloonstyle
            Dim oActiveBalloonStyle As BalloonStyle = oInventorDrawingDocument.StylesManager.ActiveStandardStyle.ActiveObjectDefaults.BalloonStyle

            '新建 ZeroBalloonText
            Try
                If oInventorDrawingDocument.StylesManager.TextStyles.Item("ZeroBalloonText") Is Nothing Then

                End If
            Catch ex As Exception
                Dim oZeroBalloonText As TextStyle
                oZeroBalloonText = oInventorDrawingDocument.StylesManager.TextStyles.Item(OldBalloonTextStyl).Copy("ZeroBalloonText")

                Dim oZeroBalloonTextColor As Color = ThisApplication.TransientObjects.CreateColor(255, 0, 128)
                oZeroBalloonText.Color = oZeroBalloonTextColor
            End Try

            '设置当前balloon style 为新的 zeroballoonstyle
            oActiveBalloonStyle.TextStyle = oInventorDrawingDocument.StylesManager.TextStyles.Item("ZeroBalloonText")

            ' '' ''
            ' '' ''        '点击每个序号组
            ' '' ''        Dim oBalloon As Balloon
            ' '' ''        For i = 1 To oActiveSheet.PartsLists.Item(1).PartsListRows.Count
            ' '' ''            oBalloon =   ThisApplication.CommandManager.Pick(kDrawingBalloonFilter, "选择引出序号")
            ' '' ''            '遍历序号组中的序号，不为0就设置序号，并加1，设置下一个，有序号则跳过
            ' '' ''            For Each oBalloonValueSet As BalloonValueSet In oBalloon.BalloonValueSets
            ' '' ''                if oBalloonValueSet.Value = 0 Then
            ' '' ''                    oBalloonValueSet.Value = i
            ' '' ''                    i = i + 1
            ' '' ''                End if
            ' '' ''            Next
            ' '' ''            '多加的1要减去
            ' '' ''            i = i - 1
            ' '' ''        Next

            '点击每个序号组
            Try
                Dim oBalloon As Balloon
                Do
                    oBalloon = ThisApplication.CommandManager.Pick(kDrawingBalloonFilter, "选择引出序号，ESC键取消")

                    For Each oBalloonValueSet As BalloonValueSet In oBalloon.BalloonValueSets
                        'if (oBalloonValueSet.Value >= FirstBalloonNumber) Then
                        If oBalloonValueSet.Value = 0 Then
                            oBalloonValueSet.Value = intBalloonNumber
                            intBalloonNumber = intBalloonNumber + 1
                        End If
                    Next
                Loop While True
            Catch ex As Exception

                'esc 退出后，还原balloon style
                oActiveBalloonStyle.TextStyle = oInventorDrawingDocument.StylesManager.TextStyles.Item(OldBalloonTextStyl)

            End Try

            If MsgBox("是否重写BOM序号？", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "重新序号") = vbYes Then

                oActiveSheet = oInventorDrawingDocument.ActiveSheet

                If oActiveSheet.PartsLists.Count = 0 Then
                    MsgBox("该工程图无明细表。", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                For Each oInventorPartsListRow As Inventor.PartsListRow In oActiveSheet.PartsLists.Item(1).PartsListRows
                    oInventorPartsListRow.SaveItemOverridesToBOM()
                Next

                oActiveSheet.PartsLists(1).Sort("序号", True)
            End If

            oTransaction.End() '事务结束，完成修改操作
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub

    '重写BOM序号
    Public Sub ReWriteBOM()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            Dim oActiveSheet As Sheet
            oActiveSheet = oInventorDrawingDocument.ActiveSheet

            If oActiveSheet.PartsLists.Count = 0 Then
                MsgBox("该工程图无明细表。", MsgBoxStyle.Critical)
                Exit Sub
            End If

            For Each oInventorPartsListRow As Inventor.PartsListRow In oActiveSheet.PartsLists.Item(1).PartsListRows
                oInventorPartsListRow.SaveItemOverridesToBOM()
            Next

            oActiveSheet.PartsLists(1).Sort("序号", True)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '替换模型参考（工程图文档，原文档，新文档）
    Public Sub ReplaceFileReference(ByVal strNewIdwFullFileName As String, ByVal strRefToRemove As String, ByVal strRefToInclude As String)
        'oInventorDocument.ReferencedDocumentDescriptors(1).ReferencedFileDescriptor.ReplaceReference(strNewFullFileName)

        Dim oInventorDrawingDocument As Inventor.DrawingDocument
        oInventorDrawingDocument = ThisApplication.Documents.Open(strNewIdwFullFileName, False)  '打开文件，不显示

        For Each oDocumentDescriptor As DocumentDescriptor In oInventorDrawingDocument.ReferencedDocumentDescriptors
            If oDocumentDescriptor.FullDocumentName = strRefToRemove Then
                oDocumentDescriptor.ReferencedFileDescriptor.ReplaceReference(strRefToInclude)
            End If
        Next
        oInventorDrawingDocument.Update()
        oInventorDrawingDocument.Save2()
        oInventorDrawingDocument.Close(False)

    End Sub

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
                    pEachScale.Value = strScale
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
    Public Sub SetUpSigning()

        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            Dim strPrint_Day As String

            strPrint_Day = Today.Year & "." & Today.Month & "." & Today.Day

            If SetSign(oInventorDrawingDocument, EngineerName, strPrint_Day, True) Then
                SetStatusBarText("设置工程图属性：签字完成")
            Else
                SetStatusBarText("错误")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '清除签字
    Public Sub ClearSignature()

        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            If SetSign(oInventorDrawingDocument, "", "", False) Then
                SetStatusBarText("清除工程图属性，签字完成")
            Else
                SetStatusBarText("错误")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '设置签字函数
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

    '设置序号
    Public Function SetSerialNumber(ByVal oInventorDrawingDocument As DrawingDocument) As Boolean

    End Function

    '插入序号
    Public Sub InsertSerialNumber()

        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            Dim oInventorDocument As Inventor.Document
            oInventorDocument = ThisApplication.ActiveDocument

            If oInventorDocument.DocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = oInventorDocument

            '设置为一个动作，可一次撤销
            Dim oTransientGeometry As TransientGeometry
            oTransientGeometry = ThisApplication.TransientGeometry
            'start a transaction so the slot will be within a single undo step

            Dim createSlotTransaction As Transaction
            createSlotTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "插入序号")

            Dim oActiveSheet As Sheet
            oActiveSheet = oInventorDrawingDocument.ActiveSheet

            If oActiveSheet.PartsLists.Count = 0 Then
                MsgBox("该工程图无明细表。", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim strFirstBalloonNumber As String
            Dim intFirstBalloonNumber As Integer

            strFirstBalloonNumber = InputBox("输入要插入的序号，并点击该序号的标注标识", "插入序号")

            If String.IsNullOrEmpty(strFirstBalloonNumber) Then
            Else
                Integer.TryParse(strFirstBalloonNumber, intFirstBalloonNumber)
            End If

            '点击被插入的序号标识
            Dim oBalloon As Balloon
            oBalloon = ThisApplication.CommandManager.Pick(kDrawingBalloonFilter, "选择被插入的引出序号标识，ESC取消")

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

            'end the transactio
            createSlotTransaction.End()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    '打印文档，打印机名称,适配A3
    Public Sub PrintDrawing(ByVal oInventorDrawingDocument As Inventor.DrawingDocument, ByVal sPrinterName As String, ByVal IsBlack As Boolean, _
                             ByVal intCopies As Integer, ByVal IsA3 As Boolean)

        ' Set a reference to the print manager object of the active document.
        ' This will fail if a drawing document is not active.
        Dim oDrawingPrintManagerr As DrawingPrintManager

        oDrawingPrintManagerr = oInventorDrawingDocument.PrintManager

        With oDrawingPrintManagerr
            ' Get the name of the printer that will be used.
            .Printer = sPrinterName

            '所有颜色打印为黑色
            If IsBlack = True Then
                .AllColorsAsBlack = True
            Else
                .AllColorsAsBlack = False
            End If

            .ColorMode = PrintColorModeEnum.kPrintDefaultColorMode

            '份数
            .NumberOfCopies = intCopies

            ' Set to print using portrait orientation.
            .Orientation = PrintOrientationEnum.kDefaultOrientation

            '最佳比例
            .ScaleMode = PrintScaleModeEnum.kPrintBestFitScale

            '设置为默认纸张大小

            ' 如果是打印到打印机，修正为A3
            If IsA3 = True Then
                Select Case oInventorDrawingDocument.ActiveSheet.Size
                    Case DrawingSheetSizeEnum.kA4DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA4
                    Case DrawingSheetSizeEnum.kA3DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA3
                    Case DrawingSheetSizeEnum.kA2DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA3
                    Case DrawingSheetSizeEnum.kA1DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA3
                    Case DrawingSheetSizeEnum.kA0DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA3
                End Select
            Else
                '设置为默认纸张大小
                Select Case oInventorDrawingDocument.ActiveSheet.Size
                    Case DrawingSheetSizeEnum.kA4DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA4
                    Case DrawingSheetSizeEnum.kA3DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA3
                    Case DrawingSheetSizeEnum.kA2DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA2
                    Case DrawingSheetSizeEnum.kA1DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA1
                    Case DrawingSheetSizeEnum.kA0DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA0
                End Select

            End If

            '最佳比例
            .ScaleMode = PrintScaleModeEnum.kPrintBestFitScale

            '设置方向
            Select Case oInventorDrawingDocument.ActiveSheet.Orientation
                Case PageOrientationTypeEnum.kLandscapePageOrientation
                    .Orientation = PrintOrientationEnum.kLandscapeOrientation
                Case PageOrientationTypeEnum.kPortraitPageOrientation
                    .Orientation = PrintOrientationEnum.kPortraitOrientation
            End Select

            ' Set to print all sheets.
            .PrintRange = PrintRangeEnum.kPrintAllSheets

            ' 打印
            .SubmitPrint()

        End With
    End Sub

    '快速打印
    Public Sub QuitPrint()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            '设置签字
            Dim strPrintDate As String
            strPrintDate = Today.Year & "." & Today.Month & "." & Today.Day
            If IsSign = 1 Then
                SetSign(oInventorDrawingDocument, EngineerName, strPrintDate, False)
            End If

            '打印文件
            PrintDrawing(oInventorDrawingDocument, Printer, True, 1, IsPaperA3)

            '另存为
            Dim strInventorDrawingDocumentFullFileName As String
            strInventorDrawingDocumentFullFileName = oInventorDrawingDocument.FullFileName


            Dim strDwgFullFileName As String        'cad 文件全文件名
            Dim strPdfFullFileName As String        'pdf 文件全文件名

            If str另存到子文件夹 = "1" Then
                Dim strChildDirectory As String

                strChildDirectory = GetDirectoryName2(strInventorDrawingDocumentFullFileName) & "\CAD\"
                If IsDirectoryExists(strChildDirectory) = False Then
                    IO.Directory.CreateDirectory(strChildDirectory)
                End If
                strDwgFullFileName = strChildDirectory & GetFileNameInfo(strInventorDrawingDocumentFullFileName).OnlyName & DWG

                strChildDirectory = GetDirectoryName2(strInventorDrawingDocumentFullFileName) & "\PDF\"
                If IsDirectoryExists(strChildDirectory) = False Then
                    IO.Directory.CreateDirectory(strChildDirectory)
                End If
                strPdfFullFileName = strChildDirectory & GetFileNameInfo(strInventorDrawingDocumentFullFileName).OnlyName & PDF
            Else

                strDwgFullFileName = GetChangeExtension(strInventorDrawingDocumentFullFileName, DWG)
                strPdfFullFileName = GetChangeExtension(strInventorDrawingDocumentFullFileName, PDF)
            End If


            Select Case SaveAsDawAndPdf
                Case "另存为dwg和pdf"
                    strDwgFullFileName = SetNewFile(strDwgFullFileName, "AutoCAD文件(*.dwg)|*.dwg")
                    IdwSaveAsDwgSub(strInventorDrawingDocumentFullFileName, strDwgFullFileName)

                    strPdfFullFileName = SetNewFile(strPdfFullFileName, "Adobe PDF文件(*.pdf)|*.pdf")
                    IdwSaveAsPdfSub(strInventorDrawingDocumentFullFileName, strPdfFullFileName)

                Case "另存为dwg"
                    strDwgFullFileName = SetNewFile(strDwgFullFileName, "AutoCAD文件(*.dwg)|*.dwg")
                    IdwSaveAsDwgSub(strInventorDrawingDocumentFullFileName, strDwgFullFileName)

                Case "另存为pdf"
                    strPdfFullFileName = SetNewFile(strPdfFullFileName, "Adobe PDF文件(*.pdf)|*.pdf")
                    IdwSaveAsPdfSub(strInventorDrawingDocumentFullFileName, strPdfFullFileName)

            End Select

            '清除签字
            SetSign(oInventorDrawingDocument, "", "", False)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '创建展开图
    Public Sub CreateFlatDrawingDocument()
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

        If IsFileExsts(str展开图模板) = False Then
            Dim oOpenFileDialog As New OpenFileDialog '声名新open 窗口

            MsgBox("未找到展开图模板：" & vbCrLf & str展开图模板 & vbCrLf & "请选择展开图模板文件。", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

            With oOpenFileDialog
                .Title = "打开展开图模板文件"
                .Filter = "AutoDesk Inventor 工程图 (*.idw)|*.idw" '添加过滤文件
                .Multiselect = False  '多开文件打开
                If .ShowDialog = System.Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                    If .FileName <> "" Then '如果有选中文件
                        str展开图模板 = .FileName
                        ini.WriteStrINI("展开图", "展开图模板", str展开图模板, Inifile)
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


        Dim IsClose As Boolean = False

        'Select Case MsgBox("创建展开图后是否关闭？", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)
        '    Case MsgBoxResult.Yes
        '        IsClose = True
        '    Case MsgBoxResult.No
        '        IsClose = False
        '    Case MsgBoxResult.Cancel
        '        Exit Sub
        'End Select

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
                                CreateFlatDrawingDocumentSub(oInventorPartDocument, str展开图模板, strInventorDrawingFolder, IsClose)
                            End If
999:
                        Next
                    End If
                Next
                MsgBox("钣金件批量生成展开图完成。", MsgBoxStyle.Information)

            Case kPartDocumentObject
                oInventorPartDocument = oInventorDocument
                CreateFlatDrawingDocumentSub(oInventorPartDocument, str展开图模板, strInventorDrawingFolder, IsClose)
        End Select

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub

    '创建展开图sub
    Public Sub CreateFlatDrawingDocumentSub(ByVal oInventorDocument As Inventor.PartDocument, ByVal strBasicIdwFileFullName As String, _
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

        SetBendEdgeType()

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

        CreateDrawingDocumentTitleBlock(oInventorDrawingDocument, oInventorDocument.DocumentType)

        oInventorDrawingDocument.SaveAs(strInventorDrawingDocumentFullFileName, False)
        oInventorDrawingDocument.Save2()

        If IsClose = True Then
            oInventorDrawingDocument.Close()
        End If
        ''oInventorDocument.Close()
    End Sub


    '设置折弯线 线性，颜色，宽度
    Public Sub SetBendEdgeType()

        Dim oDoc As DrawingDocument
        Dim oSheet As Sheet
        Dim oView As DrawingView
        Dim oCurve As DrawingCurve
        Dim oBendNote As BendNote

        oDoc = ThisApplication.ActiveDocument
        oSheet = oDoc.ActiveSheet

        On Error Resume Next

        For Each oView In oSheet.DrawingViews
            For Each oCurve In oView.DrawingCurves
                Select Case oCurve.EdgeType
                    Case Inventor.DrawingEdgeTypeEnum.kBendDownEdge
                        oCurve.Color = HexColorToRGB(str向下颜色)
                        oCurve.LineWeight = Val(str向下线宽) * 0.1
                        oCurve.LineType = GetLineType(str向下线型)

                        If str展开图标注 = "1" Then
                            oBendNote = oSheet.DrawingNotes.BendNotes.Add(oCurve)
                        End If

                    Case Inventor.DrawingEdgeTypeEnum.kBendUpEdge
                        ' Create the bend note
                        oCurve.Color = HexColorToRGB(str向上颜色)
                        oCurve.LineWeight = Val(str向上线宽) * 0.1
                        oCurve.LineType = GetLineType(str向上线型)

                        If str展开图标注 = "1" Then
                            oBendNote = oSheet.DrawingNotes.BendNotes.Add(oCurve)
                        End If
                End Select
            Next 'oCurve
        Next 'oView
    End Sub

    '十六进制颜色到rgb
    Public Function HexColorToRGB(ByVal hexColor As String) As Inventor.Color
        Dim r, g, b As Integer

        If hexColor.StartsWith("#") Then
            hexColor = hexColor.Substring(1)
        End If

        If hexColor.Length = 6 Then
            r = CInt("&H" & hexColor.Substring(0, 2))
            g = CInt("&H" & hexColor.Substring(2, 2))
            b = CInt("&H" & hexColor.Substring(4, 2))
            HexColorToRGB = ThisApplication.TransientObjects.CreateColor(r, g, b)
        ElseIf hexColor.Length = 3 Then
            r = CInt("&H" & hexColor.Substring(0, 1) & hexColor.Substring(0, 1))
            g = CInt("&H" & hexColor.Substring(1, 1) & hexColor.Substring(1, 1))
            b = CInt("&H" & hexColor.Substring(2, 1) & hexColor.Substring(2, 1))
            HexColorToRGB = ThisApplication.TransientObjects.CreateColor(r, g, b)
        Else
            Throw New ArgumentException("Invalid hex color format")
        End If

    End Function

    '返回线型枚举数据
    Public Function GetLineType(ByVal strLineType As String) As LineTypeEnum

        Select Case strLineType
            Case "实线"
                GetLineType = LineTypeEnum.kContinuousLineType
            Case "虚线"
                GetLineType = LineTypeEnum.kDashedHiddenLineType
            Case "间隔虚线"
                GetLineType = LineTypeEnum.kDashedHiddenLineType
            Case "点长划线"
                GetLineType = LineTypeEnum.kDashDottedLineType
            Case "双点长划线"
                GetLineType = LineTypeEnum.kDashedDoubleDottedLineType
            Case "三点长划线"
                GetLineType = LineTypeEnum.kDashedTripleDottedLineType
            Case "点线"
                GetLineType = LineTypeEnum.kChainLineType
            Case "长点划线"
                GetLineType = LineTypeEnum.kLongDashDottedLineType
            Case "双长点划线"
                GetLineType = LineTypeEnum.kLongDashedDoubleDottedLineType
            Case "双点划线"
                GetLineType = LineTypeEnum.kDoubleDashedDottedLineType
            Case "点划线"

            Case "点双划线"

            Case "双点双划线"

            Case "三点划线"

            Case "三点双划线"

            Case Else
                GetLineType = LineTypeEnum.kContinuousLineType
        End Select

        Return GetLineType

    End Function

    '创建工程图
    Public Sub CreatNewDrawingDocument()
        'On Error Resume Next

        'Try
        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        SetStatusBarText()

        Dim oInventorDocument As Inventor.Document
        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        Dim oInventorPartDocument As Inventor.PartDocument

        oInventorDocument = ThisApplication.ActiveDocument


        If IsFileExsts(str工程图模板) = False Then
            Dim oOpenFileDialog As New OpenFileDialog '声名新open 窗口

            MsgBox("未找到工程图模板：" & vbCrLf & str工程图模板 & vbCrLf & "请选择工程图模板文件。", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

            With oOpenFileDialog
                .Title = "打开工程图模板文件"
                .Filter = "AutoDesk Inventor 工程图 (*.idw)|*.idw" '添加过滤文件
                .Multiselect = False  '多开文件打开
                If .ShowDialog = System.Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                    If .FileName <> "" Then '如果有选中文件
                        str工程图模板 = .FileName
                        ini.WriteStrINI("工程图", "工程图模板", str工程图模板, Inifile)
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End With

        End If

        Dim strInventorDrawingFolder As String = "当前文件夹"

        'Select Case MsgBox("是否指定保存工程图文件夹？不指定则保存到当前文件夹。", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)
        '    Case MsgBoxResult.Yes
        '        Dim oFolderBrowserDialog As New FolderBrowserDialog

        '        With oFolderBrowserDialog
        '            .ShowNewFolderButton = False
        '            .Description = "选择文件夹"
        '            .RootFolder = System.Environment.SpecialFolder.Desktop
        '            if .ShowDialog = DialogResult.OK Then
        '                strInventorDrawingFolder = .SelectedPath
        '            Else
        '                Exit Sub
        '            End if
        '        End With

        '    Case MsgBoxResult.No
        'strInventorDrawingFolder = "当前文件夹"
        '    Case MsgBoxResult.Cancel
        'Exit Sub
        'End Select


        Dim IsClose As Boolean = False

        'Select Case MsgBox("创建工程图后是否关闭？", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)
        '    Case MsgBoxResult.Yes
        '        IsClose = True
        '    Case MsgBoxResult.No
        '        IsClose = False
        '    Case MsgBoxResult.Cancel
        '        Exit Sub
        'End Select

        Select Case oInventorDocument.DocumentType
            Case kAssemblyDocumentObject
                oInventorAssemblyDocument = oInventorDocument

                CreatNewDrawingDocumentSub(oInventorAssemblyDocument, str工程图模板, strInventorDrawingFolder, IsClose)

                '==============================================================================================
                '基于bom结构化数据，可跳过参考的文件
                ' Set a reference to the BOM
                '                Dim oBOM As BOM
                '                oBOM = oInventorAssemblyDocument.ComponentDefinition.BOM
                '                oBOM.StructuredViewEnabled = True
                '                oBOM.StructuredViewFirstLevelOnly = False

                '                'Set a reference to the "Structured" BOMView
                '                Dim oBOMView As BOMView

                '                '获取结构化的bom页面
                '                For Each oBOMView In oBOM.BOMViews
                '                    if oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                '                        '遍历这个bom页面
                '                        Dim i As Integer

                '                        Dim intStepCount As Integer
                '                        intStepCount = oBOMView.BOMRows.Count

                '                        For i = 1 To intStepCount
                '                            ' Get the current row.
                '                            Dim oBOMRow As BOMRow
                '                            oBOMRow = oBOMView.BOMRows.Item(i)

                '                            Dim strFullFileName As String
                '                            strFullFileName = oBOMRow.ReferencedFileDescriptor.FullFileName

                '                            '测试文件
                '                            Debug.Print(strFullFileName)

                '                            ' Set the message for the progress bar
                '                            'oProgressBar.Message = oFullFileName

                '                            if IsFileExsts(strFullFileName) = False Then   '跳过不存在的文件
                '                                GoTo 999
                '                            End if

                '                            if InStr(strFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                '                                GoTo 999
                '                            End if

                '                            if oBOMRow.ReferencedFileDescriptor.ReferencedFileType = FileTypeEnum.kPartFileType Then

                '                                'oInventorPartDocument = ThisApplication.Documents.Open(strFullFileName, False)  '打开文件，不显示

                '                                oInventorPartDocument = ThisApplication.Documents.ItemByName(strFullFileName)
                '                                CreateIdwSub(oInventorPartDocument, strBasicIdwFileFullName, strInventorDrawingFolder, IsClose)
                '                            End if
                '999:
                '                        Next
                '                    End if
                '                Next
                '                MsgBox("批量生成工程图完成。", MsgBoxStyle.Information)

            Case kPartDocumentObject
                oInventorPartDocument = oInventorDocument
                CreatNewDrawingDocumentSub(oInventorPartDocument, str工程图模板, strInventorDrawingFolder, IsClose)
        End Select

    End Sub

    '创建工程图图sub
    Public Sub CreatNewDrawingDocumentSub(ByVal oInventorDocument As Inventor.Document, ByVal strBasicIdwFileFullName As String, _
                             ByVal strInventorDrawingFolder As String, ByVal IsClose As Boolean)
        On Error Resume Next

        Dim oBaseViewOptions As NameValueMap = ThisApplication.TransientObjects.CreateNameValueMap
        Dim oTG As TransientGeometry = ThisApplication.TransientGeometry


        '初始比例
        Dim douScale As Double = 1 / 20

        Dim strInventorDocumentFullFileName As String
        strInventorDocumentFullFileName = oInventorDocument.FullFileName

        'Dim oFileNameInfo As FileNameInfo
        'oFileNameInfo = GetFileNameInfo(strInventorDocumentFullFileName)

        'if strInventorDrawingFolder = "当前文件夹" Then
        '    strInventorDrawingFolder = oFileNameInfo.Folder
        'End if

        'strInventorDrawingFolder = strInventorDrawingFolder & "\工程图\"
        'if IsDirectoryExists(strInventorDrawingFolder) = False Then
        '    IO.Directory.CreateDirectory(strInventorDrawingFolder)
        'End if

        Dim strInventorDrawingDocumentFullFileName As String

        strInventorDrawingDocumentFullFileName = GetChangeExtension(strInventorDocumentFullFileName, IDW)

        '如果工程图存在就打开工程图，不创建新的工程图
        If IsFileExsts(strInventorDrawingDocumentFullFileName) = True Then
            If MsgBox("确定打开已存在工程图：" & strInventorDrawingDocumentFullFileName, MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ThisApplication.Documents.Open(strInventorDrawingDocumentFullFileName)
                Exit Sub
            End If

        End If

        '============================================

        ' Now you will create a new drawing file from the selected template
        Dim oInventorDrawingDocument As DrawingDocument
        oInventorDrawingDocument = ThisApplication.Documents.Add(DocumentTypeEnum.kDrawingDocumentObject, strBasicIdwFileFullName, True)

        'Now activate the drawing

        oInventorDrawingDocument.Activate()
        Dim oSheet As Sheet = oInventorDrawingDocument.Sheets.Item(1)

        ' Now take the center point of the sheet
        Dim oCentralPoint As Point2d
        oCentralPoint = ThisApplication.TransientGeometry.CreatePoint2d((oSheet.Width + str页边距.short左边距 * 0.1 - str页边距.short右边距 * 0.1) * 0.5, (oSheet.Height - str页边距.short上边距 * 0.1 + str页边距.short下边距 * 0.1) * 0.5)

        'Now place the base view at the center point of the sheet
        Dim oView前视图 As DrawingView
        oView前视图 = oSheet.DrawingViews.AddBaseView(oInventorDocument, oCentralPoint, douScale, ViewOrientationTypeEnum.kFrontViewOrientation, _
                                                   Iif(str样式 = "显示隐藏线", DrawingViewStyleEnum.kHiddenLineDrawingViewStyle, _
                                                       DrawingViewStyleEnum.kHiddenLineRemovedDrawingViewStyle))
        oView前视图.Name = "前视图"
        oView前视图.DisplayThreadFeatures = Iif(str螺纹特征 = "1", True, False)
        oView前视图.DisplayTangentEdges = Iif(str相切边 = "1", True, False)

        'Create projected views in arbitrary locations

        Dim Point2D左视图 As Point2d = ThisApplication.TransientGeometry.CreatePoint2d(oView前视图.Center.X + 10, oView前视图.Center.Y)
        Dim Point2D右视图 As Point2d = ThisApplication.TransientGeometry.CreatePoint2d(oView前视图.Center.X - 10, oView前视图.Center.Y)
        Dim Point2D俯视图 As Point2d = ThisApplication.TransientGeometry.CreatePoint2d(oView前视图.Center.X, oView前视图.Center.Y - 10)
        Dim Point2D仰视图 As Point2d = ThisApplication.TransientGeometry.CreatePoint2d(oView前视图.Center.X, oView前视图.Center.Y + 10)


        Dim oView左视图 As DrawingView = Nothing
        If str选择视图.str左视图 = "1" Then
            oView左视图 = oSheet.DrawingViews.AddProjectedView(oView前视图, Point2D左视图, DrawingViewStyleEnum.kFromBaseDrawingViewStyle)
            oView左视图.Name = "左视图"
        End If

        Dim oView右视图 As DrawingView = Nothing
        If str选择视图.str右视图 = "1" Then
            oView右视图 = oSheet.DrawingViews.AddProjectedView(oView前视图, Point2D右视图, DrawingViewStyleEnum.kFromBaseDrawingViewStyle)
            oView右视图.Name = "右视图"
        End If

        Dim oView俯视图 As DrawingView = Nothing
        If str选择视图.str俯视图 = "1" Then
            oView俯视图 = oSheet.DrawingViews.AddProjectedView(oView前视图, Point2D俯视图, DrawingViewStyleEnum.kFromBaseDrawingViewStyle)
            oView俯视图.Name = "俯视图"
        End If

        Dim oView仰视图 As DrawingView = Nothing
        If str选择视图.str仰视图 = "1" Then
            oView仰视图 = oSheet.DrawingViews.AddProjectedView(oView前视图, Point2D仰视图, DrawingViewStyleEnum.kFromBaseDrawingViewStyle)
            oView仰视图.Name = "仰视图"
        End If

        '======================
        '还原1：1比例
        oView前视图.Scale = 1

        '视图间隔
        Dim oSep As Double = 2

        '更新视图排列
        If str选择视图.str左视图 = "1" Then
            oView左视图.Position = ThisApplication.TransientGeometry.CreatePoint2d(oView前视图.Center.X + oView前视图.Width / 2 + oSep + oView左视图.Width / 2, oView左视图.Center.Y)
        End If

        If str选择视图.str右视图 = "1" Then
            oView右视图.Position = ThisApplication.TransientGeometry.CreatePoint2d(oView前视图.Center.X - oView前视图.Width / 2 - oSep - oView右视图.Width / 2, oView右视图.Center.Y)
        End If

        If str选择视图.str俯视图 = "1" Then
            oView俯视图.Position = ThisApplication.TransientGeometry.CreatePoint2d(oView俯视图.Center.X, oView前视图.Center.Y - oView前视图.Height / 2 - oSep - oView俯视图.Height / 2)
        End If

        If str选择视图.str仰视图 = "1" Then
            oView仰视图.Position = ThisApplication.TransientGeometry.CreatePoint2d(oView仰视图.Center.X, oView前视图.Center.Y + oView前视图.Height / 2 + oSep + oView仰视图.Height / 2)
        End If

        '===============================================

        '找左右上下边界
        Dim douDrawingViewLeftEdge As Double = oView前视图.Left
        Dim douDrawingViewRightEdge As Double = oView前视图.Left + oView前视图.Width
        Dim douDrawingViewTopEdge As Double = oView前视图.Top
        Dim douDrawingViewBottonEdge As Double = oView前视图.Top - oView前视图.Height

        If str选择视图.str左视图 = "1" Then        '有左视图为右边界
            douDrawingViewRightEdge = oView左视图.Left + oView左视图.Width
        End If

        If str选择视图.str右视图 = "1" Then    '有右视图为左边界
            douDrawingViewLeftEdge = oView右视图.Left
        End If

        If str选择视图.str俯视图 = "1" Then        '俯视图为底边
            douDrawingViewBottonEdge = oView俯视图.Top - oView俯视图.Height
        End If

        If str选择视图.str仰视图 = "1" Then    '仰视图为顶边
            douDrawingViewTopEdge = oView仰视图.Top
        End If

        Dim douDrawingViewWidth As Double        '视图总宽
        Dim douDrawingViewHeight As Double       '视图总高   

        douDrawingViewWidth = douDrawingViewRightEdge - douDrawingViewLeftEdge
        douDrawingViewHeight = douDrawingViewTopEdge - douDrawingViewBottonEdge

        Dim douDrawingViewWidthDividedHeight As Double
        douDrawingViewWidthDividedHeight = douDrawingViewWidth / douDrawingViewHeight


        '根据宽比高，大于2为A3，否则为A4

        Select Case douDrawingViewWidthDividedHeight
            Case Is > 2         '设置为a3，横向
                oSheet.Size = DrawingSheetSizeEnum.kA3DrawingSheetSize
                oSheet.Orientation = PageOrientationTypeEnum.kLandscapePageOrientation
            Case Else
                oSheet.Size = DrawingSheetSizeEnum.kA4DrawingSheetSize
                oSheet.Orientation = PageOrientationTypeEnum.kPortraitPageOrientation
        End Select


        '根据页面A3或A4设置图框内宽
        Dim douPaperWidth As Double
        Dim douPaperHeight As Double

        Select Case oSheet.Size
            Case DrawingSheetSizeEnum.kA4DrawingSheetSize
                douPaperWidth = (210 - str页边距.short左边距 - str页边距.short右边距) * 0.1
                douPaperHeight = (297 - str页边距.short上边距 - str页边距.short下边距) * 0.1
            Case DrawingSheetSizeEnum.kA3DrawingSheetSize
                douPaperWidth = (420 - str页边距.short左边距 - str页边距.short右边距) * 0.1
                douPaperHeight = (297 - str页边距.short上边距 - str页边距.short下边距) * 0.1
            Case DrawingSheetSizeEnum.kA2DrawingSheetSize

        End Select

        '比较视图与图框宽度
        Dim douScaleWidth As Double
        douScaleWidth = douPaperWidth / douDrawingViewWidth


        Select Case douScaleWidth
            Case Is >= 1   '图框内宽大于视图宽度
                douScaleWidth = Int(douScaleWidth)
            Case Is >= 0.618
                douScaleWidth = Int(1 / douScaleWidth + 2.6)
                douScaleWidth = 1 / douScaleWidth
            Case Else
                douScaleWidth = Int(1 / douScaleWidth + 3.6)
                douScaleWidth = 1 / douScaleWidth
        End Select

        Dim douScaleHeight As Double
        douScaleHeight = douPaperHeight / douDrawingViewHeight

        Select Case douScaleHeight
            Case Is >= 1
                douScaleHeight = Int(douScaleHeight)
            Case Is >= 0.618
                douScaleHeight = Int(1 / douScaleHeight + 2.6)
                douScaleHeight = 1 / douScaleHeight
            Case Else
                douScaleHeight = Int(1 / douScaleHeight + 3.6)
                douScaleHeight = 1 / douScaleHeight
        End Select

        '比较高宽2个方向的比例，选择一个小的值。
        douScale = Math.Min(douScaleHeight, douScaleWidth)

        oView前视图.Scale = douScale
        oInventorDrawingDocument.Update()

        '找左右上下边界
        douDrawingViewLeftEdge = oView前视图.Left
        douDrawingViewRightEdge = oView前视图.Left + oView前视图.Width
        douDrawingViewTopEdge = oView前视图.Top
        douDrawingViewBottonEdge = oView前视图.Top - oView前视图.Height

        '刷新后重新排列位置
        If str选择视图.str左视图 = "1" Then
            oView左视图.Position = ThisApplication.TransientGeometry.CreatePoint2d(oView前视图.Center.X + oView前视图.Width / 2 + oSep + oView左视图.Width / 2, oView左视图.Center.Y)
            douDrawingViewRightEdge = oView左视图.Left + oView左视图.Width
        End If


        If str选择视图.str右视图 = "1" Then
            oView右视图.Position = ThisApplication.TransientGeometry.CreatePoint2d(oView前视图.Center.X - oView前视图.Width / 2 - oSep - oView右视图.Width / 2, oView右视图.Center.Y)
            douDrawingViewLeftEdge = oView右视图.Left
        End If


        If str选择视图.str俯视图 = "1" Then
            oView俯视图.Position = ThisApplication.TransientGeometry.CreatePoint2d(oView俯视图.Center.X, oView前视图.Center.Y - oView前视图.Height / 2 - oSep - oView俯视图.Height / 2)
            douDrawingViewBottonEdge = oView俯视图.Top - oView俯视图.Height
        End If


        If str选择视图.str仰视图 = "1" Then
            oView仰视图.Position = ThisApplication.TransientGeometry.CreatePoint2d(oView仰视图.Center.X, oView前视图.Center.Y + oView前视图.Height / 2 + oSep + oView仰视图.Height / 2)
            douDrawingViewTopEdge = oView仰视图.Top
        End If

        douDrawingViewWidth = douDrawingViewRightEdge - douDrawingViewLeftEdge
        douDrawingViewHeight = douDrawingViewTopEdge - douDrawingViewBottonEdge


        oCentralPoint = ThisApplication.TransientGeometry.CreatePoint2d( _
            (oView前视图.Position.X - (douDrawingViewLeftEdge + douDrawingViewWidth * 0.5 - (oSheet.Width + str页边距.short左边距 * 0.1 - str页边距.short右边距 * 0.1) * 0.5)), _
                           (oView前视图.Position.Y - (douDrawingViewBottonEdge + douDrawingViewHeight * 0.5 - (oSheet.Height + str页边距.short下边距 * 0.1 - str页边距.short上边距 * 0.1) * 0.5)))

        oView前视图.Position = oCentralPoint

        '==================================================
        '重建视图位置
        '标注尺寸
        If str标注尺寸 = "1" Then oSheet.DrawingDimensions.GeneralDimensions.Retrieve(oView前视图)

        If str选择视图.str左视图 = "1" Then
            oView左视图.Position = ThisApplication.TransientGeometry.CreatePoint2d(oView前视图.Center.X + oView前视图.Width / 2 + oSep + oView左视图.Width / 2, oView左视图.Center.Y)
            If str标注尺寸 = "1" Then oSheet.DrawingDimensions.GeneralDimensions.Retrieve(oView左视图)
        End If

        If str选择视图.str右视图 = "1" Then
            oView右视图.Position = ThisApplication.TransientGeometry.CreatePoint2d(oView前视图.Center.X - oView前视图.Width / 2 - oSep - oView右视图.Width / 2, oView右视图.Center.Y)
            If str标注尺寸 = "1" Then oSheet.DrawingDimensions.GeneralDimensions.Retrieve(oView右视图)
        End If

        If str选择视图.str俯视图 = "1" Then
            oView俯视图.Position = ThisApplication.TransientGeometry.CreatePoint2d(oView俯视图.Center.X, oView前视图.Center.Y - oView前视图.Height / 2 - oSep - oView俯视图.Height / 2)
            If str标注尺寸 = "1" Then oSheet.DrawingDimensions.GeneralDimensions.Retrieve(oView俯视图)
        End If

        If str选择视图.str仰视图 = "1" Then
            oView仰视图.Position = ThisApplication.TransientGeometry.CreatePoint2d(oView仰视图.Center.X, oView前视图.Center.Y + oView前视图.Height / 2 + oSep + oView仰视图.Height / 2)
            If str标注尺寸 = "1" Then oSheet.DrawingDimensions.GeneralDimensions.Retrieve(oView仰视图)
        End If



        '查询设置新标题栏
        CreateDrawingDocumentTitleBlock(oInventorDrawingDocument, oInventorDocument.DocumentType)

        oInventorDrawingDocument.Update()

        '保存工程图
        If IsFileExsts(strInventorDrawingDocumentFullFileName) = True Then
            Select Case MsgBox("存在文件：" & strInventorDrawingDocumentFullFileName & "，是否覆盖？", MsgBoxStyle.Information + MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes
                    'DelFile(strInventorDrawingDocumentFullFileName, FileIO.RecycleOption.SendToRecycleBin)
                    oInventorDrawingDocument.SaveAs(strInventorDrawingDocumentFullFileName, False)
                    oInventorDrawingDocument.Save2()
                Case MsgBoxResult.No
                    Dim oSaveFileDialog As New SaveFileDialog

                    With oSaveFileDialog
                        .Title = "保存工程图文件"
                        .Filter = "AutoDesk Inventor 工程图 (*.idw)|*.idw" '添加过滤文件
                        If .ShowDialog = System.Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                            If .FileName <> "" Then '如果有选中文件
                                strInventorDrawingDocumentFullFileName = .FileName
                            Else
                                Exit Sub
                            End If
                        Else
                            Exit Sub
                        End If
                    End With
                    oInventorDrawingDocument.SaveAs(strInventorDrawingDocumentFullFileName, False)
                    oInventorDrawingDocument.Save2()
                Case MsgBoxResult.Cancel

            End Select
        Else
            oInventorDrawingDocument.SaveAs(strInventorDrawingDocumentFullFileName, False)
            oInventorDrawingDocument.Save2()
        End If



        '=======================================

        'if GetFileReadOnly(strInventorDocumentFullFileName) = False Then
        '    oInventorDocument.Save2()
        'End if

        '下面的暂时不要
        ''if IsClose = True Then
        ''    oInventorDrawingDocument.Close()
        ''End if
        ' ''oInventorDocument.Close()
    End Sub

    '查询设置新标题栏
    Public Sub CreateDrawingDocumentTitleBlock(ByVal oInventorDrawingDocument As Inventor.DrawingDocument, ByVal oDocumentType As Inventor.DocumentTypeEnum)
        '新的标题栏名字
        Dim strNewTitleBlockName As String = Nothing

        '根据源文件类型得到图框名称
        Select Case oDocumentType
            Case kAssemblyDocumentObject
                strNewTitleBlockName = str部件图框
            Case kPartDocumentObject
                strNewTitleBlockName = str零件图框
        End Select

        Dim oTitleBlockDefinition As TitleBlockDefinition

        For Each oTitleBlockDefinition In oInventorDrawingDocument.TitleBlockDefinitions
            '在工程图中查找新的标题栏名字，找到就删除原来的标题，添加新的标题栏
            If oTitleBlockDefinition.Name = strNewTitleBlockName Then
                '删除旧标题栏
                oInventorDrawingDocument.ActiveSheet.TitleBlock.Delete()
                oInventorDrawingDocument.ActiveSheet.AddTitleBlock(oTitleBlockDefinition)
                Exit Sub
            End If
        Next

    End Sub

    '检查工程图匹配
    Public Function CheckDrawingDocumentNameToReferencedDocument(ByVal oInventorDrawingDocument As Inventor.DrawingDocument) As Boolean

        For Each oReferencedDocument In oInventorDrawingDocument.ReferencedDocumentDescriptors
            If GetFileNameInfo(oReferencedDocument.FullDocumentName).OnlyName = GetFileNameInfo(oInventorDrawingDocument.FullDocumentName).OnlyName Then
                Return True
            End If
        Next
        Return False

    End Function

    '工程图另存为，并查找替换同名零部件
    Public Sub DrawingDocumentSaveAs()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            '定义旧工程图对应的零部件
            Dim oOldInventorDocument As Inventor.Document = Nothing
            Dim strOldInventorDocumentFullName As String = Nothing
            strOldInventorDocumentFullName = oInventorDrawingDocument.AllReferencedDocuments(1).FullDocumentName


            '新工程图文件名
            Dim oNewInventorDrawingDocumentFullName As Inventor.DrawingDocument = Nothing
            Dim strNewInventorDrawingDocumentFullName As String = Nothing

            Dim oSaveFileDialog As New SaveFileDialog
            With oSaveFileDialog
                .Title = "另存为"
                .FileName = ""
                .InitialDirectory = GetFileNameInfo(oInventorDrawingDocument.FullDocumentName).Folder
                .Filter = "Inventor工程图文件(*.idw)|*.idw" '添加过滤文件

                If .ShowDialog = System.Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                    If .FileName <> "" Then '如果有选中文件
                        strNewInventorDrawingDocumentFullName = .FileName
                    End If
                Else
                    Exit Sub
                End If

                '另存为新工程图
                oInventorDrawingDocument.SaveAs(strNewInventorDrawingDocumentFullName, True)

                '获取新工程图文件属性
                Dim oFileNameInfo As FileNameInfo
                oFileNameInfo = GetFileNameInfo(strNewInventorDrawingDocumentFullName)

                '定义新工程图对应的零部件
                Dim oNewInventorDocument As Inventor.Document = Nothing
                Dim strNewInventorDocumentFullName As String = Nothing


                '查找新零部件
                strNewInventorDocumentFullName = SearchDocumentInPresentDirectory(strNewInventorDrawingDocumentFullName, Val(str查找文件夹层数), IPT)

                If strNewInventorDocumentFullName = "NULL" Then
                    strNewInventorDocumentFullName = SearchDocumentInPresentDirectory(strNewInventorDrawingDocumentFullName, Val(str查找文件夹层数), IAM)
                End If

                If strNewInventorDocumentFullName = "NULL" Then
                    'ThisApplication.Documents.Open(strNewInventorDrawingDocumentFullName, True)
                    MsgBox("未找到" & oFileNameInfo.FileName & "对应的零部件文件。")
                    Exit Sub
                End If

                '替换工程图模型参考
                ReplaceFileReference(strNewInventorDrawingDocumentFullName, strOldInventorDocumentFullName, strNewInventorDocumentFullName)
                ThisApplication.Documents.Open(strNewInventorDrawingDocumentFullName, True)

            End With


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

End Module