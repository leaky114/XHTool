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
Imports System.Collections.Generic
Imports Microsoft.Office.Interop.Excel
Imports Sheets = Inventor.Sheets
Imports System.Linq

Module IdwModule

    ''' <summary>
    ''' idw另存为dwg
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub IdwSaveAsDwg()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MessageBox.Show(”该功能仅适用于工程图。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            Dim strInventorDrawingDocumentFullFileName As String
            strInventorDrawingDocumentFullFileName = oInventorDrawingDocument.FullFileName

            If IsFileExists(strInventorDrawingDocumentFullFileName) = False Then
                ' MessageBox.Show("请先保存本工程图。", MsgBoxStyle.Information)
                'Exit Sub

                strInventorDrawingDocumentFullFileName = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop,
                                                                         oInventorDrawingDocument.DisplayName & IDW)
                oInventorDrawingDocument.SaveAs(strInventorDrawingDocumentFullFileName, False)

            End If

            Dim strDwgFullFileName As String        'cad 文件全文件名

            If str另存到子文件夹 = "1" Then
                Dim strChildDirectory As String

                strChildDirectory = GetDirectoryName2(strInventorDrawingDocumentFullFileName)
                strChildDirectory = IO.Path.Combine(strChildDirectory, "Dwg")

                If IsDirectoryExists(strChildDirectory) = False Then
                    IO.Directory.CreateDirectory(strChildDirectory)
                End If
                strDwgFullFileName = IO.Path.Combine(strChildDirectory,
                                                      GetFileNameInfo(strInventorDrawingDocumentFullFileName).OnlyName & DWG)
            Else
                strDwgFullFileName = GetChangeExtension(strInventorDrawingDocumentFullFileName, DWG)
            End If

            strDwgFullFileName = SetNewFile(strDwgFullFileName, "AutoCAD文件(*.dwg)|*.dwg")


            'If Strings.InStr(strDwgFullFileName, "取消") = 1 Then
            '    strDwgFullFileName = Strings.Replace(strDwgFullFileName, "取消", "")
            '    Process.Start(strDwgFullFileName)
            '    Exit Sub
            'End If

            If strDwgFullFileName = “” Then
                Exit Sub
            End If

            IdwSaveAsDwgSub(strInventorDrawingDocumentFullFileName, strDwgFullFileName)

            If IsFileExists(strDwgFullFileName) Then
                SetStatusBarText("另存为DWG完成")
                If MessageBox.Show("是否打开文件： " & strDwgFullFileName, XHTool， MessageBoxButtons.YesNo， MessageBoxIcon.Question） = DialogResult.Yes Then
                    System.Diagnostics.Process.Start(strDwgFullFileName)
                End If
            Else
                SetStatusBarText(XHTool)
                MessageBox.Show("另存为DWG错误。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '另存为dwg子过程
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strInventorDrawingDocumentFullFileName"></param>
    ''' <param name="strDwgFullFileName"></param>
    ''' <remarks></remarks>
    Public Sub IdwSaveAsDwgSub(ByVal strInventorDrawingDocumentFullFileName As String, ByVal strDwgFullFileName As String)

        'IdwDoc.SaveAs(DwgFullFileName, True)

        'if IsFileExists(DwgFullFileName) = False Then
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
        oTranslatorAddIn.SaveCopyAs(oInventorDrawingDocument, oTranslationContext, oNameValueMap, oDataMedium)

    End Sub

    '另存为pdf
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub IdwSaveAsPdf()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MessageBox.Show(”该功能仅适用于工程图。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument


            Dim strInventorDrawingDocumentFullFileName As String
            strInventorDrawingDocumentFullFileName = oInventorDrawingDocument.FullFileName

            If IsFileExists(strInventorDrawingDocumentFullFileName) = False Then
                ' MessageBox.Show("请先保存本工程图。", MsgBoxStyle.Information)
                'Exit Sub

                strInventorDrawingDocumentFullFileName = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Temp,
                                                                           oInventorDrawingDocument.DisplayName & IDW)
                oInventorDrawingDocument.SaveAs(strInventorDrawingDocumentFullFileName, False)
            End If

            Dim strPdfFullFileName As String        'pdf文件全文件名

            If str另存到子文件夹 = "1" Then
                Dim strChildDirectory As String
                strChildDirectory = GetDirectoryName2(strInventorDrawingDocumentFullFileName)
                strChildDirectory = IO.Path.Combine(strChildDirectory, "PDF")
                If IsDirectoryExists(strChildDirectory) = False Then
                    IO.Directory.CreateDirectory(strChildDirectory)
                End If
                strPdfFullFileName = IO.Path.Combine(strChildDirectory,
                                                        GetFileNameInfo(strInventorDrawingDocumentFullFileName).OnlyName & PDF)
            Else
                strPdfFullFileName = GetChangeExtension(strInventorDrawingDocumentFullFileName, PDF)
            End If

            strPdfFullFileName = SetNewFile(strPdfFullFileName, "Adobe PDF文件(*.pdf)|*.pdf")

            'If Strings.InStr(strPdfFullFileName, "取消") = 1 Then
            '    strPdfFullFileName = Strings.Replace(strPdfFullFileName, "取消", "")
            '    Process.Start(strPdfFullFileName)
            '    Exit Sub
            'End If

            If strPdfFullFileName = “” Then
                Exit Sub
            End If

            IdwSaveAsPdfSub(strInventorDrawingDocumentFullFileName, strPdfFullFileName)

            If IsFileExists(strPdfFullFileName) Then
                SetStatusBarText("另存为Pdf文件完成")
                If MessageBox.Show("是否打开文件： " & strPdfFullFileName, XHTool，
                                   MessageBoxButtons.YesNo， MessageBoxIcon.Question) = DialogResult.Yes Then
                    System.Diagnostics.Process.Start(strPdfFullFileName)
                End If
            Else
                SetStatusBarText(XHTool)
                MessageBox.Show("另存为pdf错误。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    '另存为pdf子过程
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strInventorDrawingDocumentFullFileName"></param>
    ''' <param name="strPdfFullFileName"></param>
    ''' <remarks></remarks>

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

            'For Each iss In oOptions
            '    Debug.Print(iss)
            'Next

            'oOptions.Value("Remove_Line_Weights") = 0
            'oOptions.Value("Vector_Resolution") = 400
            'oOptions.Value("Sheet_Range") = kPrintAllSheets
            'oOptions.Value("Custom_Begin_Sheet") = 2
            'oOptions.Value("Custom_End_Sheet") = 4

        End If

        'Set the destination file name
        oDataMedium.FileName = strPdfFullFileName

        'Publish document.
        PDFAddIn.SaveCopyAs(oInventorDrawingDocument, oContext, oOptions, oDataMedium)

    End Sub


    ''' <summary>
    '''  在尺寸前添加φ
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub AddDiameter()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MessageBox.Show(”该功能仅适用于工程图。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' 尺寸精度圆整
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Function DimensionRounding() As Boolean
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Function
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MessageBox.Show(”该功能仅适用于工程图。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function


    ''' <summary>
    ''' 设置全部标注文字居中
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub CenterAllDimensions()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MessageBox.Show(”该功能仅适用于工程图。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                    'oarrangeDims.Add(oDrawingDim)
                End If
            Next

            'oSheet.DrawingDimensions.Arrange(oarrangeDims)

            oTransaction.End()
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    ''' <summary>
    ''' 设置选择的标注文字居中
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub CenterDimensions()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MessageBox.Show(”该功能仅适用于工程图。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                    oDrawingDim = ThisApplication.CommandManager.Pick(kDrawingDimensionFilter, "选择要文字居中的尺寸，ESC键取消")
                    If TypeOf oDrawingDim Is LinearGeneralDimension Or TypeOf oDrawingDim Is AngularGeneralDimension Then
                        oDrawingDim.CenterText()
                    End If

                Loop Until (oDrawingDim Is Nothing)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' 设置对称件iProperty
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDrawingMirPartIPro()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MessageBox.Show(”该功能仅适用于工程图。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            If SetDrawingMirPartIProSub(oInventorDrawingDocument) Then
                SetStatusBarText("设置工程图自定义属性：对称件IPro")
                ' MessageBox.Show("设置工程图自定义属性：对称件IPro", MsgBoxStyle.Information)
            Else
                SetStatusBarText(XHTool)
                MessageBox.Show("设置对称件iProperty错误。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning）

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' 设置工程图自定义属性
    ''' </summary>
    ''' <param name="oInventorDrawingDocument">需要添加的工程图</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetDrawingMirPartIProSub(ByVal oInventorDrawingDocument As Inventor.DrawingDocument) As Boolean
        Dim oSheet As Sheet
        oSheet = oInventorDrawingDocument.ActiveSheet

        If oSheet.DrawingViews.Count = 0 Then
            MessageBox.Show("先添加一个视图。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning）
            Return False
        End If

        Dim oView As DrawingView
        oView = oSheet.DrawingViews.Item(1)

        Dim oRef As DocumentDescriptor
        oRef = oView.ReferencedDocumentDescriptor

        '获取本零件文件夹路径
        Dim strMirFileFullFileName As String

        Dim strFilter As String = "Autodesk Inventor 文件(*.ipt;*.iam)|*.ipt;*.iam|Autodesk Inventor 零件(*.ipt)|*.ipt|Autodesk Inventor 部件(*.iam)|*.iam"

        Dim strFile = IO.Path.Combine(GetDirectoryName2(oRef.FullDocumentName), "选择文件")

        Dim oFileList As List(Of String)
        oFileList = OpenFileDialog(strFilter, False, strFile)

        If oFileList Is Nothing Then
            Return True
        Else
            strMirFileFullFileName = oFileList.Item(0).ToString
        End If

        '获取镜像零件ipro
        Dim oStockNumPartName As StockNumPartName

        '从文件名获取
        'oStockNumPartName = GetStockNumPartName(strMirFileFullFileName)

        '读取文件iProperty
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.Documents.Open(strMirFileFullFileName, False)
        oStockNumPartName = GetPropitems(oInventorDocument)
        oInventorDocument.Close(False)

        On Error Resume Next

        '设置ipro
        Dim pEachScale As [Property]
        'Try
        '若该iProperty已经存在，则直接修改其值
        pEachScale = oInventorDrawingDocument.PropertySets.Item("User Defined Properties").Item(Map_Mir_StochNum)
        pEachScale.Value = oStockNumPartName.图号

        pEachScale = oInventorDrawingDocument.PropertySets.Item("User Defined Properties").Item(Map_Mir_PartName)
        pEachScale.Value = oStockNumPartName.零件名称

        pEachScale = oInventorDrawingDocument.PropertySets.Item("User Defined Properties").Item(Map_Mir_ERPCode)
        pEachScale.Value = oStockNumPartName.ERP编码

        'Catch
        ' 若该iProperty不存在，则添加一个
        oInventorDrawingDocument.PropertySets.Item("User Defined Properties").Add(oStockNumPartName.图号, Map_Mir_StochNum)
        oInventorDrawingDocument.PropertySets.Item("User Defined Properties").Add(oStockNumPartName.零件名称, Map_Mir_PartName)
        oInventorDrawingDocument.PropertySets.Item("User Defined Properties").Add(oStockNumPartName.ERP编码, Map_Mir_ERPCode)
        'End Try

        If MessageBox.Show("是否添加对称件说明标签？", XHTool， MessageBoxButtons.YesNo， MessageBoxIcon.Question） = DialogResult.Yes Then
            ' Set a reference to the GeneralNotes object
            Dim oGeneralNotes As GeneralNotes
            oGeneralNotes = oSheet.DrawingNotes.GeneralNotes

            Dim strFormattedText As String

            Dim strFontName As String
            strFontName = ini.GetStrFromINI("技术要求", "字体", "仿宋", IniFile)

            Dim strTitle As String

            strTitle = "对称件:<Property Document='drawing' PropertySet='User Defined Properties' Property='" &
                Map_Mir_StochNum & "' FormatID='{D5CDD505-2E9C-101B-9397-08002B2CF9AE}'>" & Map_Mir_StochNum &
                "</Property><Property Document='drawing' PropertySet='User Defined Properties' Property='" & Map_Mir_PartName &
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

            Dim oPoint2d As Point2d

            oPoint2d = GetPointInDrawing("单击确定插入标签位置。") ' ThisApplication.TransientGeometry.CreatePoint2d(ModelPosition.X, ModelPosition.Y)


            Dim oGeneralNote As GeneralNote
            oGeneralNote = oGeneralNotes.AddFitted(oPoint2d, strFormattedText)

        End If

        oInventorDrawingDocument.Update()   '刷新数据

        Return True

    End Function


    ''' <summary>
    ''' 替换图框和标题栏
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub ReplaceBorderTitleBlock()
        On Error Resume Next

        'Try
        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
            MessageBox.Show(”该功能仅适用于工程图。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim oInventorDrawingDocument As Inventor.DrawingDocument
        oInventorDrawingDocument = ThisApplication.ActiveDocument

        If IsFileExists(str工程图模板) = False Then
            MessageBox.Show("找不到模板文件：" & str工程图模板 & "，重新设置。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning）

            Dim strFileName As String
            Dim strFilter As String = "Inventor工程图文件(*.idw;*.dwg)|*.idw;*.dwg" '添加过滤文件
            Dim strFile = IO.Path.Combine(ThisApplication.FileLocations.TemplatesPath, "选择模板文件")

            Dim oFileList As List(Of String)
            oFileList = OpenFileDialog(strFilter, False, strFile)

            If oFileList Is Nothing Then
                Exit Sub
            Else
                strFileName = oFileList(0).ToString
                str工程图模板 = strFileName
            End If

        End If

        Dim strTitleBlock As String
        strTitleBlock = IO.Path.Combine(My.Application.Info.DirectoryPath, "TitleBlock.ini")

        If IsFileExists(strTitleBlock) = False Then
            MessageBox.Show("无配置文件,请手动配置！", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning）

            Dim file As New StreamWriter(strTitleBlock)
            file.WriteLine("#号行勿修改,文件编码 ANSI")
            file.WriteLine("#Border 默认图框")
            file.WriteLine("#Border = NX")
            file.WriteLine("#Title旧的和新的对映表")
            file.WriteLine("#SH(-零件 = NX - 零件)")
            file.Close()

            Process.Start(strTitleBlock)

            Exit Sub
        End If

        str模型匹配检查 = 0

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
                '         s =  MessageBox.Show("Title Block Def Named '" & oTBDef.Name & "' is referenced, and will not be deleted.", vbOKOnly + vbInformation, "CAN'T BE DELETED")
            End If
        Next

        Dim oTitleBlockInventorDrawingDocument As Inventor.DrawingDocument

        oTitleBlockInventorDrawingDocument = ThisApplication.Documents.Open(str工程图模板, False)

        Dim oTemplateTitleBlockDefinitions As TitleBlockDefinitions
        oTemplateTitleBlockDefinitions = oTitleBlockInventorDrawingDocument.TitleBlockDefinitions

        Dim oTemplateTitleBlockDefinition As TitleBlockDefinition

        'str模型匹配检查标记 = 3

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

        str模型匹配检查 = 1

        MessageBox.Show("替换图框标题栏完成。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information）

        'Catch ex As Exception
        '       MessageBox.Show(ex.Message, xhtool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub



    ''' <summary>
    ''' 替换模型参考
    ''' </summary>
    ''' <param name="strNewIdwFullFileName">工程图文档</param>
    ''' <param name="strRefToRemove">原文档</param>
    ''' <param name="strRefToInclude">新文档</param>
    ''' <remarks></remarks>

    Public Sub ReplaceFileReference(ByVal strNewIdwFullFileName As String, ByVal strRefToRemove As String, ByVal strRefToInclude As String)
        'oInventorDocument.ReferencedDocumentDescriptors(1).ReferencedFileDescriptor.ReplaceReference(strNewFullFileName)
        ThisApplication.SilentOperation = True

        Dim oInventorDrawingDocument As Inventor.DrawingDocument
        oInventorDrawingDocument = ThisApplication.Documents.Open(strNewIdwFullFileName, False)  '打开文件，不显示

        For Each oDocumentDescriptor As DocumentDescriptor In oInventorDrawingDocument.ReferencedDocumentDescriptors
            If oDocumentDescriptor.FullDocumentName = strRefToRemove Then
                oDocumentDescriptor.ReferencedFileDescriptor.ReplaceReference(strRefToInclude)
            End If
        Next

        Try
            oInventorDrawingDocument.Update()
            oInventorDrawingDocument.Save2(True)
            oInventorDrawingDocument.Close()
            ThisApplication.SilentOperation = False
        Catch ex As Exception
            ThisApplication.SilentOperation = False
        End Try



    End Sub


    ''' <summary>
    ''' 设置工程图自定义比例
    ''' </summary>
    ''' <param name="oDrawingDocument">工程图对象></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' 设置工程图自定义质量
    ''' </summary>
    ''' <param name="oDrawingDocument">工程图对象</param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Function SetMass(ByVal oDrawingDocument As DrawingDocument) As Boolean
        Dim oPropertyName As String
        oPropertyName = "质量"

        Dim oInventorDocument As Inventor.Document

        Dim dblMass As Double = 0
        Dim TempdoubleMass As Double
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

    ''' <summary>
    ''' 获取视图类型
    ''' </summary>
    ''' <param name="oDrawingView">工程图视图对象</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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


    ''' <summary>
    ''' 设置签字
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetUpSigning()

        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MessageBox.Show("该功能仅适用于工程图。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning）
                Exit Sub
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            Dim strPrint_Day As String

            strPrint_Day = Today.Year & "." & Today.Month & "." & Today.Day

            If SetSign(oInventorDrawingDocument, EngineerName, strPrint_Day, True) Then
                SetStatusBarText("设置工程图属性：签字完成")
            Else
                SetStatusBarText(XHTool)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    ''' <summary>
    ''' 清除签字
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub ClearSignature()

        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MessageBox.Show("该功能仅适用于工程图。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning）
                Exit Sub
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            If SetSign(oInventorDrawingDocument, "", "", False) Then
                SetStatusBarText("清除工程图属性，签字完成")
            Else
                SetStatusBarText(XHTool)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    ''' <summary>
    ''' 设置签字
    ''' </summary>
    ''' <param name="oDrawingDocument">工程图对象</param>
    ''' <param name="EngineerName">工程师</param>
    ''' <param name="strPrintDate">日期</param>
    ''' <param name="IsOPenPrintDialog">是否打开打印窗口</param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Function SetSign(ByVal oDrawingDocument As DrawingDocument, ByVal EngineerName As String, ByVal strPrintDate As String, ByVal IsOPenPrintDialog As Boolean) As Boolean

        '设置工程师
        SetPropitem(oDrawingDocument, "工程师", EngineerName)

        '设置打印日期
        SetUserPropitem(oDrawingDocument, Map_PrintDay, strPrintDate)

        '打开打印窗口()
        If IsOpenPrint = 1 And IsOPenPrintDialog = True Then
            ThisApplication.CommandManager.ControlDefinitions.Item("AppFilePrintCmd").Execute2(True)
        End If

        Return True

    End Function





    ''' <summary>
    '''打印文档 
    ''' </summary>
    ''' <param name="oInventorDrawingDocument">打印文档</param>
    ''' <param name="sPrinterName">打印机名称</param>
    ''' <param name="IsBlack">是否黑色</param>
    ''' <param name="intCopies">打印份数</param>
    ''' <param name="IsA3">适配A3</param>
    ''' <remarks></remarks>
    Public Sub PrintDrawing(ByVal oInventorDrawingDocument As Inventor.DrawingDocument, ByVal sPrinterName As String, ByVal IsBlack As Boolean,
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

    ''' <summary>
    ''' 快速打印
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub QuitPrint()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MessageBox.Show("该功能仅适用于工程图。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning）
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

                strChildDirectory = IO.Path.Combine(GetDirectoryName2(strInventorDrawingDocumentFullFileName), "Dwg")
                If IsDirectoryExists(strChildDirectory) = False Then
                    IO.Directory.CreateDirectory(strChildDirectory)
                End If
                strDwgFullFileName = IO.Path.Combine(strChildDirectory, GetFileNameInfo(strInventorDrawingDocumentFullFileName).OnlyName & DWG)

                strChildDirectory = IO.Path.Combine(GetDirectoryName2(strInventorDrawingDocumentFullFileName), "PDF")
                If IsDirectoryExists(strChildDirectory) = False Then
                    IO.Directory.CreateDirectory(strChildDirectory)
                End If
                strPdfFullFileName = IO.Path.Combine(strChildDirectory, GetFileNameInfo(strInventorDrawingDocumentFullFileName).OnlyName & PDF)
            Else

                strDwgFullFileName = GetChangeExtension(strInventorDrawingDocumentFullFileName, DWG)
                strPdfFullFileName = GetChangeExtension(strInventorDrawingDocumentFullFileName, PDF)
            End If


            Select Case SaveAsDawAndPdf
                Case "另存为dwg和pdf"
                    strDwgFullFileName = SetNewFile(strDwgFullFileName, "AutoCAD文件(*.dwg)|*.dwg")

                    If strDwgFullFileName = "" Then
                    Else
                        IdwSaveAsDwgSub(strInventorDrawingDocumentFullFileName, strDwgFullFileName)
                    End If

                    strPdfFullFileName = SetNewFile(strPdfFullFileName, "Adobe PDF文件(*.pdf)|*.pdf")

                    If strPdfFullFileName = "" Then

                    Else
                        IdwSaveAsPdfSub(strInventorDrawingDocumentFullFileName, strPdfFullFileName)
                    End If

                Case "另存为dwg"
                    strDwgFullFileName = SetNewFile(strDwgFullFileName, "AutoCAD文件(*.dwg)|*.dwg")
                    If strDwgFullFileName = "" Then
                    Else
                        IdwSaveAsDwgSub(strInventorDrawingDocumentFullFileName, strDwgFullFileName)
                    End If

                Case "另存为pdf"
                    strPdfFullFileName = SetNewFile(strPdfFullFileName, "Adobe PDF文件(*.pdf)|*.pdf")
                    If strPdfFullFileName = "" Then

                    Else
                        IdwSaveAsPdfSub(strInventorDrawingDocumentFullFileName, strPdfFullFileName)
                    End If

            End Select

            '清除签字
            SetSign(oInventorDrawingDocument, "", "", False)

        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ''' <summary>
    ''' 创建展开图
    ''' </summary>
    ''' <remarks></remarks>
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

        If IsFileExists(str展开图模板) = False Then
            Dim oOpenFileDialog As New OpenFileDialog '声名新open 窗口

            MessageBox.Show("未找到展开图模板：" & vbCrLf & str展开图模板 & vbCrLf & "请选择展开图模板文件。", XHTool，
                            MessageBoxButtons.OK， MessageBoxIcon.Warning）

            With oOpenFileDialog
                .Title = "打开展开图模板文件"
                .Filter = "Autodesk Inventor 工程图 (*.idw)|*.idw" '添加过滤文件
                .Multiselect = False  '多开文件打开
                If .ShowDialog = System.Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                    If .FileName <> "" Then '如果有选中文件
                        str展开图模板 = .FileName
                        ini.WriteStrINI("展开图", "展开图模板", str展开图模板, IniFile)
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End With

        End If

        Dim strInventorDrawingFolder As String = Nothing
        Select Case MessageBox.Show("是否指定保存展开图文件夹？不指定则保存到当前文件夹。", XHTool，
                                    MessageBoxButtons.YesNoCancel， MessageBoxIcon.Question, MessageBoxDefaultButton.Button1）
            Case DialogResult.Yes
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

            Case DialogResult.No
                strInventorDrawingFolder = "当前文件夹"
            Case DialogResult.Cancel
                Exit Sub
        End Select


        Dim IsClose As Boolean = False

        'Select Case  MessageBox.Show("创建展开图后是否关闭？", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)
        '    Case MsgBoxResult.Yes
        '        IsClose = True
        '    Case MsgBoxResult.No
        '        IsClose = False
        '    Case MsgBoxResult.Cancel
        '        Exit Sub
        'End Select

        Select Case oInventorDocument.DocumentType
            Case kAssemblyDocumentObject

                If MessageBox.Show("将为部件中的钣金件创建展开图？", XHTool， MessageBoxButtons.YesNo， MessageBoxIcon.Question） = DialogResult.No Then
                    Exit Sub
                End If

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

                        For Each oBOMRow As BOMRow In oBOMView.BOMRows

                            Dim oComponentDefinitions As Inventor.ComponentDefinitionsEnumerator
                            oComponentDefinitions = oBOMRow.ComponentDefinitions

                            Dim oComponentDefinition As ComponentDefinition
                            oComponentDefinition = oComponentDefinitions.Item(1)

                            Dim strDocumentFullFileName As String
                            strDocumentFullFileName = oComponentDefinition.Document.FullDocumentName

                            '测试文件
                            Debug.Print(strDocumentFullFileName)


                            If IsFileExists(strDocumentFullFileName) = False Then   '跳过不存在的文件
                                GoTo 999
                            End If

                            If InStr(strDocumentFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                                GoTo 999
                            End If

                            If oComponentDefinition.Document.documenttype = DocumentTypeEnum.kPartDocumentObject Then

                                'oInventorPartDocument = ThisApplication.Documents.Open(strDocumentFullFileName, False)  '打开文件，不显示

                                oInventorPartDocument = ThisApplication.Documents.ItemByName(strDocumentFullFileName)
                                CreateFlatDrawingDocumentSub(oInventorPartDocument, str展开图模板, strInventorDrawingFolder, IsClose)

                            End If
999:
                        Next
                    End If
                Next
                MessageBox.Show("钣金件批量生成展开图完成。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information）

            Case kPartDocumentObject
                oInventorPartDocument = oInventorDocument
                CreateFlatDrawingDocumentSub(oInventorPartDocument, str展开图模板, strInventorDrawingFolder, IsClose)
        End Select

        'Catch ex As Exception
        '       MessageBox.Show(ex.Message, xhtool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

    End Sub

    ''' <summary>
    ''' 创建钣金展开模式
    ''' </summary>
    ''' <param name="oInventorDocument"></param>
    ''' <remarks></remarks>
    Public Sub CreateFlat(ByVal oInventorDocument As Inventor.PartDocument)
        ' Check for a non-part document 
        If oInventorDocument.DocumentType <> kPartDocumentObject Then
            MessageBox.Show(”该文档不是零件“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' The Active document must be a Sheet metal Part
        If oInventorDocument.SubType <> "{9C464203-9BAE-11D3-8BAD-0060B0CE6BB4}" Then
            MessageBox.Show(”该文档不是钣金件“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim oCompDef As SheetMetalComponentDefinition
        oCompDef = oInventorDocument.ComponentDefinition

        'CREATE FLAT PATTERN IF DOESN'T EXIST
        If oCompDef.Type = ObjectTypeEnum.kSheetMetalComponentDefinitionObject Then
            ThisApplication.ScreenUpdating = False
            oCompDef.Unfold()
            ThisApplication.ScreenUpdating = True
            'oDoc.ComponentDefinition.FlatPattern.Edit()
            oCompDef.FlatPattern.ExitEdit()
        End If

    End Sub

    ''' <summary>
    ''' 创建展开图sub
    ''' </summary>
    ''' <param name="oInventorDocument">零件对象</param>
    ''' <param name="strBasicIdwFileFullName">工程图模板文档</param>
    ''' <param name="strInventorDrawingFolder">保存的文件夹</param>
    ''' <param name="IsClose">是否关闭</param>
    ''' <remarks></remarks>
    Public Sub CreateFlatDrawingDocumentSub(ByVal oInventorDocument As Inventor.PartDocument, ByVal strBasicIdwFileFullName As String,
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

        SetBendEdgeType(oInventorDrawingDocument)

        If str展开图隐藏螺纹特征 = "1" Then
            oBaseView.DisplayThreadFeatures = False
        Else
            oBaseView.DisplayThreadFeatures = True
        End If

        Dim strInventorDocumentFullFileName As String
        strInventorDocumentFullFileName = oInventorDocument.FullFileName

        Dim oFileNameInfo As FileNameInfo
        oFileNameInfo = GetFileNameInfo(strInventorDocumentFullFileName)

        If strInventorDrawingFolder = "当前文件夹" Then
            strInventorDrawingFolder = oFileNameInfo.Folder
        End If

        strInventorDrawingFolder = IO.Path.Combine(strInventorDrawingFolder, "钣金展开")
        If IsDirectoryExists(strInventorDrawingFolder) = False Then
            IO.Directory.CreateDirectory(strInventorDrawingFolder)
        End If

        Dim strInventorDrawingDocumentFullFileName As String

        strInventorDrawingDocumentFullFileName = IO.Path.Combine(strInventorDrawingFolder, oFileNameInfo.OnlyName & "-展开.idw")

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

    ''' <summary>
    ''' 设置折弯线 线性，颜色，宽度
    ''' </summary>
    ''' <param name="oInventorDrawingDocument">需要设置的工程图</param>
    ''' <remarks></remarks>
    Public Sub SetBendEdgeType(ByVal oInventorDrawingDocument As Inventor.DrawingDocument)
        'Dim oDoc As DrawingDocument
        Dim oSheet As Sheet
        Dim oView As DrawingView
        Dim oCurve As DrawingCurve
        Dim oBendNote As BendNote

        'oDoc = ThisApplication.ActiveDocument
        oSheet = oInventorDrawingDocument.ActiveSheet

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

    ''' <summary>
    ''' 十六进制颜色到rgb
    ''' </summary>
    ''' <param name="hexColor">十六进制颜色</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' 返回线型枚举数据
    ''' </summary>
    ''' <param name="strLineType">线型名称</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' 创建工程图
    ''' </summary>
    ''' <remarks></remarks>
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


        If IsFileExists(str工程图模板) = False Then
            Dim oOpenFileDialog As New OpenFileDialog '声名新open 窗口

            MessageBox.Show("未找到工程图模板：" & vbCrLf & str工程图模板 & vbCrLf & "请选择工程图模板文件。", XHTool，
                            MessageBoxButtons.OK， MessageBoxIcon.Warning）

            Dim strFilter As String = "Autodesk Inventor 工程图 (*.idw)|*.idw" '添加过滤文件

            Dim strFile = IO.Path.Combine(ThisApplication.FileLocations.TemplatesPath, "选择模板文件")

            Dim oFileList As List(Of String)
            oFileList = OpenFileDialog(strFilter, False, strFile)

            If oFileList Is Nothing Then
                Exit Sub
            End If

            str工程图模板 = oFileList.Item(0).ToString
            ini.WriteStrINI("工程图", "工程图模板", str工程图模板, IniFile)


        End If

        Dim strInventorDrawingFolder As String = "当前文件夹"

        'Select Case  MessageBox.Show("是否指定保存工程图文件夹？不指定则保存到当前文件夹。", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)
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

        'Select Case  MessageBox.Show("创建工程图后是否关闭？", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)
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

                '                            if IsFileExists(strFullFileName) = False Then   '跳过不存在的文件
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
                '                 MessageBox.Show("批量生成工程图完成。", MsgBoxStyle.Information)

            Case kPartDocumentObject
                oInventorPartDocument = oInventorDocument
                CreatNewDrawingDocumentSub(oInventorPartDocument, str工程图模板, strInventorDrawingFolder, IsClose)
        End Select

    End Sub

    ''' <summary>
    ''' 创建工程图图sub
    ''' </summary>
    ''' <param name="oInventorDocument"></param>
    ''' <param name="strBasicIdwFileFullName"></param>
    ''' <param name="strInventorDrawingFolder"></param>
    ''' <param name="IsClose"></param>
    ''' <remarks></remarks>
    Public Sub CreatNewDrawingDocumentSub(ByVal oInventorDocument As Inventor.Document, ByVal strBasicIdwFileFullName As String,
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
        If IsFileExists(strInventorDrawingDocumentFullFileName) = True Then
            If MessageBox.Show("确定打开已存在工程图：" & strInventorDrawingDocumentFullFileName, XHTool，
                               MessageBoxButtons.YesNo， MessageBoxIcon.Question） = DialogResult.Yes Then
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
        oView前视图 = oSheet.DrawingViews.AddBaseView(oInventorDocument, oCentralPoint, douScale, ViewOrientationTypeEnum.kFrontViewOrientation,
                                                   IIf(str样式 = "显示隐藏线", DrawingViewStyleEnum.kHiddenLineDrawingViewStyle,
                                                       DrawingViewStyleEnum.kHiddenLineRemovedDrawingViewStyle))
        oView前视图.Name = "前视图"
        oView前视图.DisplayThreadFeatures = IIf(str螺纹特征 = "1", True, False)
        oView前视图.DisplayTangentEdges = IIf(str相切边 = "1", True, False)

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
                If MessageBox.Show("是否将图框设置为 A3-横向？", XHTool，
                                   MessageBoxButtons.YesNo， MessageBoxIcon.Question） = DialogResult.Yes Then   '询问是否将图框改为横向
                    oSheet.Size = DrawingSheetSizeEnum.kA3DrawingSheetSize
                    oSheet.Orientation = PageOrientationTypeEnum.kLandscapePageOrientation
                Else
                    oSheet.Size = DrawingSheetSizeEnum.kA4DrawingSheetSize
                    oSheet.Orientation = PageOrientationTypeEnum.kPortraitPageOrientation
                End If
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


        oCentralPoint = ThisApplication.TransientGeometry.CreatePoint2d(
            (oView前视图.Position.X - (douDrawingViewLeftEdge + douDrawingViewWidth * 0.5 - (oSheet.Width + str页边距.short左边距 * 0.1 - str页边距.short右边距 * 0.1) * 0.5)),
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
        If IsFileExists(strInventorDrawingDocumentFullFileName) = True Then
            Select Case MessageBox.Show("存在文件：" & strInventorDrawingDocumentFullFileName & "，是否覆盖？", XHTool，
                                         MessageBoxButtons.YesNoCancel， MessageBoxIcon.Question）
                Case DialogResult.Yes
                    'DelFile(strInventorDrawingDocumentFullFileName, FileIO.RecycleOption.SendToRecycleBin)
                    oInventorDrawingDocument.SaveAs(strInventorDrawingDocumentFullFileName, False)
                    oInventorDrawingDocument.Save2()
                Case DialogResult.No
                    Dim oSaveFileDialog As New SaveFileDialog


                    Dim strFilter As String = "Autodesk Inventor 工程图 (*.idw)|*.idw" '添加过滤文件

                    Dim strFile = GetFileNameWithoutExtension2(strInventorDrawingDocumentFullFileName)

                    Dim oFileList As List(Of String)
                    oFileList = SaveFileDialog(strFilter, False, strFile)

                    If oFileList Is Nothing Then
                        Exit Sub
                    End If

                    strInventorDrawingDocumentFullFileName = oFileList.Item(0).ToString

                    'With oSaveFileDialog
                    '    .Title = "保存工程图文件"
                    '    .Filter = "Autodesk Inventor 工程图 (*.idw)|*.idw" '添加过滤文件
                    '    If .ShowDialog = System.Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                    '        If .FileName <> "" Then '如果有选中文件
                    '            strInventorDrawingDocumentFullFileName = .FileName
                    '        Else
                    '            Exit Sub
                    '        End If
                    '    Else
                    '        Exit Sub
                    '    End If
                    'End With

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

    ''' <summary>
    ''' 查询设置新标题栏
    ''' </summary>
    ''' <param name="oInventorDrawingDocument"></param>
    ''' <param name="oDocumentType"></param>
    ''' <remarks></remarks>

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


    ''' <summary>
    ''' 检查工程图匹配
    ''' </summary>
    ''' <param name="oInventorDrawingDocument"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckDrawingDocumentNameToReferencedDocument(ByVal oInventorDrawingDocument As Inventor.DrawingDocument) As Boolean

        For Each oReferencedDocument In oInventorDrawingDocument.ReferencedDocumentDescriptors
            If GetFileNameInfo(oReferencedDocument.FullDocumentName).OnlyName.ToLower =
                GetFileNameInfo(oInventorDrawingDocument.FullDocumentName).OnlyName.ToLower Then
                Return True
            End If
        Next
        Return False

    End Function


    ''' <summary>
    ''' 工程图另存为，并查找替换同名零部件
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub DrawingDocumentSaveAs()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MessageBox.Show("该功能仅适用于工程图。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning）
                Exit Sub
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            '定义旧工程图对应的零部件
            Dim strOldInventorDocumentFullName As String
            strOldInventorDocumentFullName = oInventorDrawingDocument.AllReferencedDocuments(1).FullDocumentName

            Dim strOldInventorDocumentExtensionName As String
            strOldInventorDocumentExtensionName = GetFileExtensionLCase(strOldInventorDocumentFullName)

            '新工程图文件名


            Dim strFilter As String = Nothing

            Select Case strOldInventorDocumentExtensionName
                Case IAM
                    strFilter = "Autodesk Inventor 部件(*.iam)|*.iam"
                Case IPT
                    strFilter = "Autodesk Inventor 零件(*.ipt)|*.ipt"
                Case Else
                    Exit Sub
            End Select

            Dim strFile As String = IO.Path.Combine(GetDirectoryName2(strOldInventorDocumentFullName), "选择工程图链接的零部件")

            Dim oFileList As List(Of String)
            oFileList = OpenFileDialog(strFilter, False, strFile)

            If oFileList Is Nothing Then
                Exit Sub
            End If

            '新零部件文件名
            Dim strNewInventorDocumentFullName As String = oFileList.Item(0).ToString

            If strNewInventorDocumentFullName = strOldInventorDocumentFullName Then
                MessageBox.Show("请选择不同的零部件文件。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning）
                Exit Sub
            End If


            '新工程图文件名
            Dim strNewInventorDrawingDocumentFullName As String
            strNewInventorDrawingDocumentFullName = GetChangeExtension(strNewInventorDocumentFullName, IDW)

            '判断新工程图是否存在，是否需要覆盖
            If IsFileExists(strNewInventorDrawingDocumentFullName) = True Then
                If MessageBox.Show("存在工程图：" & vbCrLf & vbCrLf & strNewInventorDrawingDocumentFullName & vbCrLf & vbCrLf & " 是否覆盖？",
                         XHTool， MessageBoxButtons.YesNo， MessageBoxIcon.Question） = DialogResult.Yes Then
                Else
                    Exit Sub
                End If

            End If

            '另存为新工程图
            oInventorDrawingDocument.SaveAs(strNewInventorDrawingDocumentFullName, True)

            '获取新工程图文件属性
            'Dim oFileNameInfo As FileNameInfo
            'oFileNameInfo = GetFileNameInfo(strNewInventorDrawingDocumentFullName)

            '定义新工程图对应的零部件
            'Dim oNewInventorDocument As Inventor.Document = Nothing


            '查找新零部件
            'strNewInventorDocumentFullName = GetChangeExtensionDocument(strNewInventorDrawingDocumentFullName, strOldInventorDocumentExtensionName)  ', Val(str查找文件夹层数), IPT)

            'If strNewInventorDocumentFullName = "NULL" Then
            '    strNewInventorDocumentFullName = SearchDocumentInPresentDirectory(strNewInventorDrawingDocumentFullName)    ', Val(str查找文件夹层数), IAM)
            'End If

            'If strNewInventorDocumentFullName = "" Then
            '    'ThisApplication.Documents.Open(strNewInventorDrawingDocumentFullName, True)
            '     MessageBox.Show("未找到" & oFileNameInfo.FileName & "对应的零部件文件。")
            '    Exit Sub
            'End If

            '替换工程图模型参考
            ReplaceFileReference(strNewInventorDrawingDocumentFullName, strOldInventorDocumentFullName, strNewInventorDocumentFullName)
            ThisApplication.Documents.Open(strNewInventorDrawingDocumentFullName, True)


        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub

    ''' <summary>
    ''' 断开工程图链接
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub BreakDrawingDocumentLink()

        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
            MessageBox.Show("该功能仅适用于工程图。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning）
            Exit Sub
        End If

        Dim oInventorDrawingDocument As Inventor.DrawingDocument
        oInventorDrawingDocument = ThisApplication.ActiveDocument


        Dim strDrawingDocumentFileName As String = oInventorDrawingDocument.FullDocumentName

        For i = 1 To oInventorDrawingDocument.ReferencedDocuments.Count
            Dim ModelDocumentName As String = oInventorDrawingDocument.ReferencedDocuments(i).FullDocumentName
            If IO.File.Exists(ModelDocumentName) Then
                '建立一个临时文件
                Dim NewModelDocumentName As String = IO.Path.ChangeExtension(IO.Path.GetTempFileName, IO.Path.GetExtension(ModelDocumentName))
                '复制模型到临时文件
                IO.File.Copy(ModelDocumentName, NewModelDocumentName)
                '替换模型
                Dim oFD As FileDescriptor = oInventorDrawingDocument.File.ReferencedFileDescriptors(i)
                oFD.ReplaceReference(NewModelDocumentName)
                '删除被替换的模型
                IO.File.Delete(NewModelDocumentName)
                '重新打开工程图文件
                oInventorDrawingDocument.Save()
                oInventorDrawingDocument.Close()

                ThisApplication.Documents.Open(strDrawingDocumentFileName)

            End If
        Next
        MessageBox.Show("断开链接完成！", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information）
    End Sub

    ''' <summary>
    ''' 在展开图纸标记螺纹
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub MarkCircleInFlatDrawing()

        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
            MessageBox.Show("该功能仅适用于工程图。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning）
            Exit Sub
        End If

        '撤销功能
        Dim oTransaction As Transaction
        oTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "My Transaction")

        Dim oInventorDrawingDocument As Inventor.DrawingDocument
        oInventorDrawingDocument = ThisApplication.ActiveDocument
        Dim oSheet As Sheet
        oSheet = oInventorDrawingDocument.ActiveSheet

        Dim oView As DrawingView
        oView = oSheet.DrawingViews.Item(1)

        '螺纹中心数组
        Dim oarryArc2dCentorPoints(100) As Point2d
        Dim oarryArc2dCentorPoint As Point2d

        Dim i As Integer
        i = 0

        Dim oDrawingCurve As DrawingCurve

        Dim oSegment As DrawingCurveSegment

        Dim oArc2d As Arc2d
        Dim oArc2dCentorPoint As Point2d

        Dim oCircle2d As Circle2d
        Dim oCircle2dCentorPoint As Point2d

        Dim oRadius As Double
        Dim oDiameter As Double

        oView.DisplayThreadFeatures = True

        '找所有螺纹圆弧
        For Each oDrawingCurve In oView.DrawingCurves
            If oDrawingCurve.ProjectedCurveType = Curve2dTypeEnum.kCircularArcCurve2d Then

                oSegment = oDrawingCurve.Segments.Item(1)
                oArc2d = oSegment.Geometry

                oRadius = oArc2d.Radius  '厘米
                oDiameter = oRadius * 20   '毫米

                If Left(oArc2d.StartAngle, 5) = "4.537" Or Left(oArc2d.StartAngle, 5) = "3.316" Then '4.537是起点标记
                    If FourFive(oDiameter, 2) < Val(str标记孔径上限) Then
                        oArc2dCentorPoint = oArc2d.Center
                        oarryArc2dCentorPoints(i) = oArc2dCentorPoint   ' oDrawingCurve.CenterPoint
                        i = i + 1
                    End If
                End If
            End If
        Next

        For Each oDrawingCurve In oView.DrawingCurves
            If oDrawingCurve.ProjectedCurveType = Curve2dTypeEnum.kCircleCurve2d Then

                oSegment = oDrawingCurve.Segments.Item(1)
                oCircle2d = oSegment.Geometry

                For Each oarryArc2dCentorPoint In oarryArc2dCentorPoints

                    If oarryArc2dCentorPoint Is Nothing Then
                        Exit For
                    End If

                    oCircle2dCentorPoint = oCircle2d.Center

                    '找到与圆弧同心的圆
                    If (Left(oCircle2dCentorPoint.X, 5) = Left(oarryArc2dCentorPoint.X, 5)) And (Left(oCircle2dCentorPoint.Y, 5) = Left(oarryArc2dCentorPoint.Y, 5)) Then

                        oRadius = oCircle2d.Radius  '厘米
                        '跳过半径是0.01的圆
                        If oRadius <> 0.01 Then
                            oSegment.Visible = False
                        End If

                    End If
                Next
            End If
        Next


        Dim osketch As DrawingSketch

        '删除旧的孔标记草图
        For Each osketch In oSheet.Sketches
            If osketch.Name = "孔标记" Then
                osketch.Delete()
            End If
        Next

        osketch = oSheet.Sketches.Add
        'osketch = oView.Sketches.Add
        osketch.Name = "孔标记"

        osketch.Edit()

        Dim oSketchCircle As SketchCircle

        For Each oarryArc2dCentorPoint In oarryArc2dCentorPoints

            If oarryArc2dCentorPoint Is Nothing Then
                Exit For
            End If

            '添加一个草图圆
            oSketchCircle = osketch.SketchCircles.AddByCenterRadius(oarryArc2dCentorPoint, 0.01)

            'If oSketchPoint(i) Is Nothing Then
            '    Exit For
            'End If
            'Dim ent As SketchEntity
            'ent = osketch.SketchCircles.AddByProjectingEntity(oSketchPoint(i)) ', 1)
            ''oSketchCircle =

            '设置草图圆的颜色
            oSketchCircle.OverrideColor = ThisApplication.TransientObjects.CreateColor(255, 0, 128)
        Next

        osketch.ExitEdit()

        oView.DisplayThreadFeatures = False

        oTransaction.End()


        'If str展开图隐藏螺纹特征 = "1" Then
        '    oView.DisplayThreadFeatures = False
        'Else
        '    oView.DisplayThreadFeatures = True
        'End If

        ''Dim oSketchPoint(500) As Circle2d

        'Dim oCentorPoint2d(500) As Point2d
        'Dim i As Integer = 0

        'Dim oDrawingCurve As DrawingCurve

        'Dim oSegment As DrawingCurveSegment
        'Dim oCircle As Circle2d
        'Dim oRadius As Double
        'Dim oDiameter As Double

        ''Dim oArc As Arc2d

        'For Each oDrawingCurve In oView.DrawingCurves
        '    If oDrawingCurve.CurveType = CurveTypeEnum.kCircleCurve Then

        '        'oDrawingCurve.Color = ThisApplication.TransientObjects.CreateColor(255, 0, 128)

        '        oSegment = oDrawingCurve.Segments.Item(1)

        '        'If oDrawingCurve.Segments.Item(1).GeometryType = Curve2dTypeEnum.kCircleCurve2d Then
        '        oCircle = oSegment.Geometry
        '        oRadius = oCircle.Radius
        '        oDiameter = 20 * oRadius

        '        If oDiameter < str标记孔直径 Then
        '            '小于指定直径，添加到草图孔标记数组，并隐藏本圆

        '            oCentorPoint2d(i) = oCircle.Center ' oDrawingCurve.CenterPoint
        '            i = i + 1

        '            'oSketchPoint(i) = oCircle

        '            'ElseIf oDrawingCurve.Segments.Item(1).GeometryType = Curve2dTypeEnum.kCircularArcCurve2d Then
        '            '    oArc = oDrawingCurve.Segments.Item(1).Geometry
        '            '    oRadius = oArc.Radius
        '            'End If

        '            Debug.Print(oRadius)

        '            '隐藏圆()
        '            oSegment.Visible = False

        '            'For Each oDrawCurveSegment As DrawingCurveSegment In oDrawingCurve.Segments
        '            '    oDrawCurveSegment.Visible = False
        '            'Next
        '        End If
        '    End If

        'Next

        ''新建一个草图，标记孔

        'Dim osketch As DrawingSketch

        ''删除旧的孔标记草图
        'For Each osketch In oSheet.Sketches
        '    If osketch.Name = "孔标记" Then
        '        osketch.Delete()
        '    End If
        'Next

        'osketch = oSheet.Sketches.Add
        ''osketch = oView.Sketches.Add
        'osketch.Name = "孔标记"

        'osketch.Edit()

        'Dim oSketchCircle As SketchCircle
        'For i = 0 To 499

        '    If oCentorPoint2d(i) Is Nothing Then
        '        Exit For
        '    End If

        '    '添加一个草图圆
        '    oSketchCircle = osketch.SketchCircles.AddByCenterRadius(oCentorPoint2d(i), 0.01)

        '    'If oSketchPoint(i) Is Nothing Then
        '    '    Exit For
        '    'End If
        '    'Dim ent As SketchEntity
        '    'ent = osketch.SketchCircles.AddByProjectingEntity(oSketchPoint(i)) ', 1)
        '    ''oSketchCircle = 

        '    '设置草图圆的颜色
        '    oSketchCircle.OverrideColor = ThisApplication.TransientObjects.CreateColor(255, 0, 128)
        'Next

        'osketch.ExitEdit()


    End Sub

    ''' <summary>
    ''' 保存工程图文件为dxf
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub IdwSaveAsDxf()
        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
            MessageBox.Show("该功能仅适用于工程图。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning）
            Exit Sub
        End If

        Dim oInventorDrawingDocument As Inventor.DrawingDocument
        oInventorDrawingDocument = ThisApplication.ActiveDocument


        Dim oInventorDocument As Inventor.Document
        oInventorDocument = oInventorDrawingDocument.ReferencedDocumentDescriptors.Item(1).ReferencedDocument

        If TypeOf oInventorDocument IsNot PartDocument Then
            MessageBox.Show(”该功能仅适用于零件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        Dim oInventorPartDocument As Inventor.PartDocument
        oInventorPartDocument = oInventorDrawingDocument.ReferencedDocumentDescriptors.Item(1).ReferencedDocument

        Dim strMaterial As String
        strMaterial = RemoveInvalidFileNameChars(oInventorPartDocument.ComponentDefinition.Material.Name.ToString())

        Dim strInventorDrawingDocumentFullFileName As String
        strInventorDrawingDocumentFullFileName = oInventorDrawingDocument.FullFileName

        Dim strDxfFullFileName As String = Nothing


        Select Case str图号材质
            Case "无材质"
                strDxfFullFileName = GetChangeExtension(strInventorDrawingDocumentFullFileName, DXF)
            Case "材质前缀"
                strDxfFullFileName = IO.Path.Combine(GetDirectoryName2(strInventorDrawingDocumentFullFileName),
                                                     strMaterial & "-" & GetFileNameWithoutExtension2(strInventorDrawingDocumentFullFileName) & DXF)
            Case "材质后缀"
                strDxfFullFileName = IO.Path.Combine(GetDirectoryName2(strInventorDrawingDocumentFullFileName),
                                                      GetFileNameWithoutExtension2(strInventorDrawingDocumentFullFileName) & "-" & strMaterial & DXF)
        End Select

        If str另存到子文件夹 = "1" Then
            Dim strChildDirectory As String

            strChildDirectory = GetDirectoryName2(strInventorDrawingDocumentFullFileName)
            strChildDirectory = IO.Path.Combine(strChildDirectory, "Dxf")

            If IsDirectoryExists(strChildDirectory) = False Then
                IO.Directory.CreateDirectory(strChildDirectory)
            End If
            strDxfFullFileName = IO.Path.Combine(strChildDirectory, GetFileNameInfo(strDxfFullFileName).FileName)
        End If

        IdwSaveAsDwgSub(strInventorDrawingDocumentFullFileName, strDxfFullFileName)
    End Sub

    ''' <summary>
    ''' 在工程图里单击，获取一个点
    ''' </summary>
    ''' <param name="StrInformation">鼠标提示文字</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPointInDrawing(ByVal StrInformation As String) As Point2d
        Dim oGetDrawingPoint As New clsGetPoint
        Dim oPoint2d As Point2d

        Do
            oPoint2d = oGetDrawingPoint.GetDrawingPoint(StrInformation, MouseButtonEnum.kLeftMouseButton, CursorTypeEnum.kCursorBuiltInCrosshair)
            If oPoint2d IsNot Nothing Then
                ' MessageBox.Show("当前坐标： " & Strings.Format(oPoint2d.X, "0.0000") & ", " & Strings.Format(oPoint2d.Y, "0.0000"))
                Return oPoint2d
            End If
        Loop While oPoint2d IsNot Nothing

        Return Nothing
    End Function

    ''' <summary>
    ''' 工程图转换图形
    ''' </summary>
    ''' <param name="oInventorDrawingDocument">工程图文件</param>
    ''' <param name="strPictureFullFileName">图形文件名</param>
    Public Sub ExportToBitmap(ByVal oInventorDrawingDocument As DrawingDocument, ByVal strPictureFullFileName As String)
        '执行系统命令(最大化显示图纸)
        If oInventorDrawingDocument.Views.Count = 0 Then oInventorDrawingDocument.Views.Add()
        oInventorDrawingDocument.Activate()
        Dim oTheCol As ControlDefinition = ThisApplication.CommandManager.ControlDefinitions("AppZoomAllCmd")
        '改变图纸背景颜色为白色
        Dim o_sheetColor As Inventor.Color = oInventorDrawingDocument.SheetSettings.SheetColor
        Dim o_tmpsheetColor As Inventor.Color = oInventorDrawingDocument.SheetSettings.SheetColor
        o_tmpsheetColor.Blue = 255 : o_tmpsheetColor.Green = 255 : o_tmpsheetColor.Red = 255
        oInventorDrawingDocument.SheetSettings.SheetColor = o_tmpsheetColor

        Dim oSheet As Sheet
        Dim k As Integer = 1
        For Each oSheet In oInventorDrawingDocument.Sheets
            oSheet.Activate()
            oTheCol.Execute()
            Dim cam As Camera = ThisApplication.ActiveView.Camera
            cam.SaveAsBitmap(strPictureFullFileName, oInventorDrawingDocument.ActiveSheet.Width * 100, oInventorDrawingDocument.ActiveSheet.Height * 100)
            k += 1

        Next

        '恢复图纸背景颜色
        oInventorDrawingDocument.SheetSettings.SheetColor = o_sheetColor

    End Sub

    ''' <summary>
    ''' 设置图框大小,,A0，A1，A2，A3，A4  ， A4为竖向，其余为横向
    ''' </summary>
    ''' <param name="intDrawingSheetSizeEnum">图框大小 </param>
    ''' <remarks></remarks>
    Public Sub SetDrawingSize(ByVal intDrawingSheetSizeEnum As DrawingSheetSizeEnum)

        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
            MessageBox.Show("该功能仅适用于工程图。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning）
            Exit Sub
        End If

        Dim oInventorDrawingDocument As Inventor.DrawingDocument
        oInventorDrawingDocument = ThisApplication.ActiveDocument

        Dim oSheet As Sheet
        oSheet = oInventorDrawingDocument.ActiveSheet

        oSheet.Size = intDrawingSheetSizeEnum

        Select Case intDrawingSheetSizeEnum
            Case DrawingSheetSizeEnum.kA4DrawingSheetSize
                oSheet.Orientation = PageOrientationTypeEnum.kPortraitPageOrientation
            Case Else
                oSheet.Orientation = PageOrientationTypeEnum.kLandscapePageOrientation
        End Select

        oSheet.Update()

    End Sub


    'Public Function GetRectAreaInDrawing(ByVal StrInformation As String) As String
    '    Dim oGetRectAreaInDrawing As New clsGetRectAreaInDrawing
    '    Dim strPoints As String

    '    Do
    '        strPoints = oGetRectAreaInDrawing.GetRectAreaInDrawing(StrInformation, MouseButtonEnum.kLeftMouseButton)
    '        If Not strPoints Is Nothing Then
    '            ' MessageBox.Show("Click is at " & Strings.Format(pnt.X, "0.0000") & ", " & Strings.Format(pnt.Y, "0.0000"))
    '            Return strPoints
    '        End If
    '    Loop While Not strPoints Is Nothing

    '    Return Nothing
    'End Function

    ''' <summary>
    ''' 添加工程图阵列尺寸
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AddArrayDimension()
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        Dim oSelectSet1 As Object
        Dim oSelectSet2 As Object

        oSelectSet1 = oInventorDocument.SelectSet.Item(1)  '  ThisApplication.CommandManager.Pick(SelectionFilterEnum.kDrawingDimensionFilter, "选择阵列尺寸，ESC键取消")

        If TypeOf oSelectSet1 IsNot DrawingDimension Then
            Exit Sub
        End If

        If oSelectSet1 Is Nothing Then       '取消选择
            Exit Sub
        End If

        oSelectSet2 = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kDrawingDimensionFilter, "选择基准尺寸，ESC键取消")

        If oSelectSet2 Is Nothing Then       '取消选择
            Exit Sub
        End If

        Dim oDrawingDimension As DrawingDimension = oSelectSet2   '基准尺寸
        Dim strText2 As String
        strText2 = oDrawingDimension.Text.Text

        Dim oDrawingDimensions As DrawingDimension = oSelectSet1   '阵列尺寸

        Dim strText1 As String
        Dim strFormattedText1 As String

        strText1 = oDrawingDimensions.Text.Text

        Dim douNumber As Double
        douNumber = Val(strText1) / Val(strText2)

        Dim intNunber As Integer
        intNunber = Int(Val(strText1) / Val(strText2))

        If douNumber <> intNunber Then
            MessageBox.Show("基准尺寸非整数个。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning）
            Exit Sub
        End If

        strFormattedText1 = oDrawingDimensions.Text.FormattedText

        strFormattedText1 = strText2 & "×" & intNunber.ToString & "=" & strFormattedText1

        oDrawingDimensions.Text.FormattedText = strFormattedText1
    End Sub


    ''' <summary>
    ''' 在工程图中选择一个curve，查询所在的零件，选择这个零件的所有 curve
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SelectPartCurveInDrawing()

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        If oInventorDocument.SelectSet.Count = 0 Then
            Exit Sub
        End If

        Dim oSelectSet1 As Object
        oSelectSet1 = oInventorDocument.SelectSet.Item(1)

        If TypeOf oSelectSet1 IsNot DrawingCurveSegment Then
            Exit Sub
        End If

        'Select drawing curve of the part
        'Dim oPick As DrawingCurveSegment
        'oPick = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kDrawingCurveSegmentFilter, "选择一个工程图边。")

        'Get assembly occurrene which the selected DrawingCurveSegment belongs to

        Dim oDrawingCurveSegment As DrawingCurveSegment
        'oDrawingCurveSegment = oPick

        oDrawingCurveSegment = CType(oSelectSet1, DrawingCurveSegment)

        Dim oDrawingCurve As DrawingCurve
        oDrawingCurve = oDrawingCurveSegment.Parent

        Dim someProxy As Object 'changed
        someProxy = oDrawingCurve.ModelGeometry

        Dim partOcc As ComponentOccurrence
        partOcc = someProxy.ContainingOccurrence

        'Get AssemblyDocument referenced by DrawingView
        Dim oDrawingView As DrawingView 'needs to be checked
        oDrawingView = oDrawingCurve.Parent

        Dim oDrawingViewAssemblyDocument As AssemblyDocument
        oDrawingViewAssemblyDocument = oDrawingView.ReferencedDocumentDescriptor.ReferencedDocument

        'Get all occurrences which has the same ComponentDefinition
        Dim allInstancesOfPartOcc As ComponentOccurrencesEnumerator
        allInstancesOfPartOcc = oDrawingViewAssemblyDocument.ComponentDefinition.Occurrences.AllLeafOccurrences(partOcc.Definition)

        'Get all DrawingCurveSegments of each part instance
        'and convert them to ObjectCollection
        Dim occDrawingCurvesCollection As ObjectCollection
        occDrawingCurvesCollection = ThisApplication.TransientObjects.CreateObjectCollection()

        Dim occ As ComponentOccurrence

        For Each occ In allInstancesOfPartOcc
            Dim occDrawingCurves As DrawingCurvesEnumerator
            occDrawingCurves = oDrawingView.DrawingCurves(occ)

            Dim occDrawingCurve As DrawingCurve
            For Each occDrawingCurve In occDrawingCurves

                Dim occDrawingCurveSegment As DrawingCurveSegment
                For Each occDrawingCurveSegment In occDrawingCurve.Segments
                    occDrawingCurvesCollection.Add(occDrawingCurveSegment)
                Next
            Next
        Next

        'Do something useful with occDrawingCurvesCollection

        'Select all DrawingCurveSegments of the occ in the DrawingView
        Dim drawingDoc As DrawingDocument
        drawingDoc = oDrawingView.Parent.Parent

        drawingDoc.SelectSet.SelectMultiple(occDrawingCurvesCollection)


    End Sub

    Public Sub AutoColor_VA2()

        '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        'Step 0:  find PartDocument from the selected curve segment
        '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

        ' Get a drawing curve segment selection from the user
        Dim oCS As DrawingCurveSegment
        oCS = ThisApplication.CommandManager.Pick(
              SelectionFilterEnum.kDrawingCurveSegmentFilter, "选装工程图线段。")

        If oCS Is Nothing Then
            Exit Sub
        End If

        Dim oCurve As DrawingCurve
        oCurve = oCS.Parent

        Dim oEdge As Edge
        If TypeOf oCurve.ModelGeometry Is EdgeProxy Then
            'we have assembly document
            oEdge = oCurve.ModelGeometry.NativeObject
        Else
            'we have part document
            oEdge = oCurve.ModelGeometry
        End If

        Dim oBody As SurfaceBody
        oBody = oEdge.Parent

        Dim oDef As PartComponentDefinition
        oDef = oBody.Parent

        Dim SelectedFile As Inventor.PartDocument
        SelectedFile = oDef.Document

        '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        'step 1. Get drawing view that contains selected drawing curve segment
        '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        Dim oDrawView As DrawingView
        oDrawView = oCurve.Parent



        '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        ' step 2. Get the active drawing document.
        '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        Dim oDrawDoc As DrawingDocument
        oDrawDoc = ThisApplication.ActiveDocument
        Dim oSheet As Sheet
        oSheet = oDrawDoc.ActiveSheet

        'for objects to be moved to specified layer
        Dim oColl As ObjectCollection
        oColl = ThisApplication.TransientObjects.CreateObjectCollection

        Dim oDocDesc As DocumentDescriptor
        oDocDesc = oDrawView.ReferencedDocumentDescriptor
        ' Verify that the selected drawing view is of an assembly.
        If oDocDesc.ReferencedDocumentType <> kAssemblyDocumentObject Then
            MessageBox.Show("请选装一个部件模型。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning）
            Exit Sub
        End If
        Dim oAssyDoc As AssemblyDocument
        oAssyDoc = oDocDesc.ReferencedDocument

        '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        'step 3.  filter required docs
        '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        Dim oRefDocs As DocumentsEnumerator
        oRefDocs = oAssyDoc.AllReferencedDocuments

        'On Error Resume Next
        Dim Fname As String
        Fname = SelectedFile.FullFileName
        Fname = Left(Fname, InStrRev(Fname, ".") - 1)  '.ipt cut
        Fname = Right(Fname, Len(Fname) - InStrRev(Fname, "\")) ' cut the front part
        ' If Len(Fname) = 0 Then
        'Fname = InputBox("Give me search string", "File Name")
        If Len(Fname) = 0 Then Exit Sub
        'End If


        Dim oDoc As Inventor.Document
        For Each oDoc In oRefDocs

            'Criteria depends on your requirements:
            'substring from filename, custom iProperty value, parameter value, etc.

            If InStr(oDoc.FullFileName, Fname) > 0 Then
                'this is required document
                Debug.Print(oDoc.FullFileName) 'debug print only

                'find all occurrences for every part found
                Dim oOccEnum As ComponentOccurrencesEnumerator
                oOccEnum = oAssyDoc.ComponentDefinition.Occurrences _
                    .AllReferencedOccurrences(oDoc)

                Dim oOcc As ComponentOccurrence

                For Each oOcc In oOccEnum

                    Dim oCurveUnum As DrawingCurvesEnumerator
                    oCurveUnum = oDrawView.DrawingCurves(oOcc)

                    'Dim oCurve As DrawingCurve
                    Dim oSegment As DrawingCurveSegment

                    'add segments to collection to be moved to required layer
                    For Each oCurve In oCurveUnum
                        For Each oSegment In oCurve.Segments
                            Call oColl.Add(oSegment)
                        Next
                    Next

                Next 'oOcc
            End If

        Next  'oDoc



        'step 4.
        'move found curves to desired layer

        'create layer (if it doesn't exist), set color and styles
        Dim oLayer As Layer
        On Error Resume Next
        oLayer = oDrawDoc.StylesManager.Layers.Item("HANGERS")
        If oLayer Is Nothing Then
            oLayer = oDrawDoc.StylesManager.Layers _
                  .Item("Sketch Geometry (ISO)").Copy("HANGERS")
            'define color
            Dim oColor As Color
            oColor = ThisApplication.TransientObjects.CreateColor(128, 128, 255)
            oLayer.Color = oColor
        End If

        'change layer for curves collection
        Call oSheet.ChangeLayer(oColl, oLayer)

        oSheet.Update()

    End Sub 'AutoColor_VA2


    ''' <summary>
    ''' 删除工程图错误的标注
    ''' </summary>
    Public Sub ClearErrorTagging()

        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If


        '撤销功能
        Dim oTransaction As Transaction
        oTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "My Transaction")


        Select Case ThisApplication.ActiveDocumentType
            Case DocumentTypeEnum.kAssemblyDocumentObject     '部件 禁止错误的约束
                Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
                oInventorAssemblyDocument = ThisApplication.ActiveDocument

                For Each oAssemblyConstraint As AssemblyConstraint In oInventorAssemblyDocument.ComponentDefinition.Constraints
                    Select Case oAssemblyConstraint.HealthStatus.ToString
                        Case HealthStatusEnum.kDriverLostHealth.ToString, HealthStatusEnum.kInconsistentHealth.ToString
                            oAssemblyConstraint.Suppressed = True

                    End Select
                Next

            Case DocumentTypeEnum.kDrawingDocumentObject     '工程图删除错误的尺寸，序号，焊接
                Dim oInventorDrawingDocument As Inventor.DrawingDocument
                oInventorDrawingDocument = ThisApplication.ActiveDocument

                Dim oSheet As Sheet
                oSheet = oInventorDrawingDocument.ActiveSheet

                '遍历图纸中的所有 尺寸
                For Each oDrawingDim As DrawingDimension In oSheet.DrawingDimensions
                    If oDrawingDim.Attached = False Then
                        oDrawingDim.Delete()
                    End If
                Next

                '遍历图纸中的所有  序号
                For Each oBalloon As Balloon In oSheet.Balloons
                    If oBalloon.Attached = False Then
                        oBalloon.Delete()
                    End If
                Next

                ' 遍历图纸中的所有  十字中心线
                For Each oCentermark As Centermark In oSheet.Centermarks
                    If oCentermark.Attached = False Then
                        oCentermark.Delete()
                    End If
                Next

                ' 遍历图纸中的所有  中心线
                For Each oCenterLine As Centerline In oSheet.Centerlines
                    If oCenterLine.Attached = False Then
                        oCenterLine.Delete()
                    End If
                Next


                ' 遍历图纸中的所有 特征注释
                For Each note As LeaderNote In oSheet.DrawingNotes.LeaderNotes
                    ' Dim t = note.Leader.AllNodes.Count
                    If (note.Leader.HasRootNode = False) Then
                        ' This happens if the leader has been deleted.
                    Else
                        'Dim attachedNodeList = note.Leader.AllNodes.Cast(Of LeaderNode).Where(Function(n) n.AttachedEntity IsNot Nothing).ToList()

                        ' 第一步：获取原始节点集合
                        Dim allNodes As IEnumerable = note.Leader.AllNodes

                        ' 第二步：将节点转换为 LeaderNode 类型
                        Dim castedNodes As IEnumerable(Of LeaderNode) = allNodes.Cast(Of LeaderNode)()

                        ' 第三步：过滤具有附加实体的节点
                        Dim filteredNodes As IEnumerable(Of LeaderNode) = castedNodes.Where(Function(n) n.AttachedEntity IsNot Nothing)

                        ' 第四步：转换为列表
                        Dim attachedNodeList As List(Of LeaderNode) = filteredNodes.ToList()


                        If (attachedNodeList.Count = 0) Then
                            note.Delete()
                        End If
                    End If
                Next

                ' 遍历图纸中的所有 特征注释
                For Each oDrawingNote As DrawingNote In oSheet.DrawingNotes
                    Debug.Print(TypeName(oDrawingNote))

                    Select Case TypeName(oDrawingNote)
                        Case "BendNote"            '折弯
                            Dim oBendNote As BendNote
                            oBendNote = CType(oDrawingNote, BendNote)

                        'oBendNote.Delete()

                        Case "ChamferNote"              '倒角
                            Dim oChamferNote As ChamferNote
                            oChamferNote = CType(oDrawingNote, ChamferNote)

                        'oChamferNote.Delete()

                        Case "GeneralNote"                  '文本
                            Dim oGeneralNote As GeneralNote
                            oGeneralNote = CType(oDrawingNote, GeneralNote)

                        Case ""

                        Case ""

                    End Select
                Next

                '遍历图纸中的符号
                For Each oSurfaceTextureSymbol As SurfaceTextureSymbol In oSheet.SurfaceTextureSymbols
                    'oSurfaceTextureSymbol.Delete()
                Next


        End Select

        oTransaction.End()

    End Sub
End Module