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
            strDwgFullFileName = GetChangeExtension(strInventorDrawingDocumentFullFileName, DWG)
            strDwgFullFileName = SetNewFile(strDwgFullFileName, "AutoCAD文件(*.dwg)|*.dwg")

            If strDwgFullFileName = "取消" Then
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

        'If IsFileExsts(DwgFullFileName) = False Then
        '    DwgFullFileName = Strings.Replace(DwgFullFileName, ".dwg", ".zip")
        'End If

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

            strPdfFullFileName = GetChangeExtension(strInventorDrawingDocumentFullFileName, PDF)
            strPdfFullFileName = SetNewFile(strPdfFullFileName, "Adobe PDF文件(*.pdf)|*.pdf")

            If strPdfFullFileName = "取消" Then
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

            For Each oDrawingDim In oSheet.DrawingDimensions

                If TypeOf oDrawingDim Is LinearGeneralDimension Or TypeOf oDrawingDim Is AngularGeneralDimension Then

                    oDrawingDim.CenterText()

                End If
            Next

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
                        Call oSelectSet.CenterText()
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
            pEachScale.Value = oStockNumPartName.StockNum

            pEachScale = oInventorDrawingDocument.PropertySets.Item("User Defined Properties").Item(Map_Mir_PartName)
            pEachScale.Value = oStockNumPartName.PartName

        Catch
            ' 若该iProperty不存在，则添加一个
            oInventorDrawingDocument.PropertySets.Item("User Defined Properties").Add(oStockNumPartName.StockNum, Map_Mir_StochNum)
            oInventorDrawingDocument.PropertySets.Item("User Defined Properties").Add(oStockNumPartName.PartName, Map_Mir_PartName)
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

            'strTitle = "对称件：" & oStockNumPartName.StockNum & oStockNumPartName.PartName

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

        If IsFileExsts(TitleBlockIdwDoc) = False Then
            MsgBox("找不到模板文件：" & TitleBlockIdwDoc, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "错误")
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
        oTitleBlockInventorDrawingDocument = ThisApplication.Documents.Open(TitleBlockIdwDoc, False)

        Dim oTemplateTitleBlockDefinitions As TitleBlockDefinitions
        oTemplateTitleBlockDefinitions = oTitleBlockInventorDrawingDocument.TitleBlockDefinitions

        Dim oTemplateTitleBlockDefinition As TitleBlockDefinition

        Dim oNewTitleBlockDefinition As TitleBlockDefinition = Nothing
        For Each oTemplateTitleBlockDefinition In oTemplateTitleBlockDefinitions
            'If oTemplateTitleBlockDefinition.Name = "NX-零件" Then
            oNewTitleBlockDefinition = oTemplateTitleBlockDefinition.CopyTo(oInventorDrawingDocument, True)
            'End If
        Next

        '复制新图框
        Dim oTemplateBorderDefinitions As BorderDefinitions
        oTemplateBorderDefinitions = oTitleBlockInventorDrawingDocument.BorderDefinitions

        Dim oTemplateBorderDefinition As BorderDefinition

        Dim oNewBorderDefinition As BorderDefinition = Nothing

        For Each oTemplateBorderDefinition In oTemplateBorderDefinitions
            'If oTemplateBorderDefinition.Name = "NX" Then
            oNewBorderDefinition = oTemplateBorderDefinition.CopyTo(oInventorDrawingDocument, True)
            'End If
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
                    '        If arrayTempBalloonDate(j).Position.X > arrayTempBalloonDate(j + 1).Position.X Then
                    '            tempBalloondate = arrayTempBalloonDate(j)
                    '            arrayTempBalloonDate(j) = arrayTempBalloonDate(j + 1)
                    '            arrayTempBalloonDate(j + 1) = tempBalloondate
                    '        End If
                    '    Next
                    'Next
                    '=============================================
                    '按极角排序
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
                    oBalloon = ThisApplication.CommandManager.Pick(kDrawingBalloonFilter, "选择引出序号，ESC键取消")

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
            strDwgFullFileName = GetChangeExtension(strInventorDrawingDocumentFullFileName, DWG)

            Dim strPdfFullFileName As String        'pdf 文件全文件名
            strPdfFullFileName = GetChangeExtension(strInventorDrawingDocumentFullFileName, PDF)

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

End Module