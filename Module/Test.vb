Imports Inventor
Imports Inventor.SelectionFilterEnum
Imports Inventor.DocumentTypeEnum
Imports Inventor.DrawingViewTypeEnum
Imports Inventor.PropertyTypeEnum

Module Test

    'Private Sub m_查询ERP编码_Buttondef_OnExecute() Handles m_查询ERP编码_Buttondef.OnExecute

    '    'Try
    '    SetStatusBarText()

    '    If IsInventorOpenDocument() = False Then
    '        Exit Sub
    '    End If

    '    Dim oInventorDocument As Inventor.Document      '当前文件
    '    oInventorDocument = ThisApplication.ActiveEditDocument

    '    Dim oPropSets As PropertySets
    '    Dim oPropSet As PropertySet
    '    Dim propitem As [Property]

    '    oPropSets = oInventorDocument.PropertySets
    '    oPropSet = oPropSets.Item(3)

    '    '获取iproperty
    '    'Dim oStockNumPartName As StockNumPartName = Nothing
    '    Dim strStochNum As String = Nothing
    '    Dim strPartNum As String = Nothing

    '    For Each propitem In oPropSet
    '        Select Case propitem.DisplayName
    '            Case Map_DrawingNnumber
    '                strStochNum = propitem.Value
    '                'PartNum = VLookUpValue(Excel_File_Name, StochNum, Sheet_Name, Table_Array, Col_Index_Num, 0)
    '                Exit For
    '        End Select
    '    Next

    '    strPartNum = FindSrtingInSheet(BasicExcelFullFileName, strStochNum, SheetName, TableArrays, ColIndexNum, 0)
    '    If strPartNum <> 0 Then
    '        MsgBox("查询到ERP编码：" & strPartNum, MsgBoxStyle.Information, "查询ERP编码")
    '        SetPropitem(oInventorDocument, Map_ERPCode, strPartNum)
    '    Else
    '        MsgBox("未查询到ERP编码。", MsgBoxStyle.Information)
    '    End If

    '    'Catch ex As Exception
    '    '    MsgBox(ex.Message)
    '    'End Try
    'End Sub

    '测试
    Public Function Test() As Boolean


    End Function

    '遍历组件下的文件，将其对应的工程图另存为dwg或Pdf
    Public Sub SaveIdwInAsmAsDwgOrPdfSub()

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

        Dim DwgOrPdf As String
        Select Case MsgBox("批量另存工程图文件为 Dwg或 Pdf 格式？ Dwg （是 Yes） ， Pdf（否 No）", MsgBoxStyle.YesNoCancel)
            Case MsgBoxResult.Yes
                DwgOrPdf = "DWG"
            Case MsgBoxResult.No
                DwgOrPdf = "PDF"
            Case Else
                Exit Sub
        End Select

        Dim FirstLevelOnly As Boolean
        Select Case MsgBox("模式：是-仅修改第一级零件   否-修改所有级别零件 ", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel)
            Case MsgBoxResult.Yes
                FirstLevelOnly = True
            Case MsgBoxResult.No
                FirstLevelOnly = False
            Case Else
                Exit Sub
        End Select

        '
        '==============================================================================================
        '基于bom结构化数据，可跳过参考的文件
        ' Set a reference to the BOM
        Dim oBOM As BOM
        oBOM = oInventorAssemblyDocument.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True

        'Set a reference to the "Structured" BOMView
        Dim oBOMView As BOMView

        '获取结构化的bom页面
        For Each oBOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then

                '遍历这个bom页面
                SaveIdwInAsmAsDwgOrPdfChildSub(oBOMView.BOMRows, FirstLevelOnly, DwgOrPdf)
            End If
        Next

    End Sub

    '遍历BOM结构，查询row文件.打开对应的idw，另存为dwg 或 Pdf
    Public Sub SaveIdwInAsmAsDwgOrPdfChildSub(ByVal oBOMRows As BOMRowsEnumerator, ByVal FirstLevelOnly As Boolean, CADorPDF As String)
        Dim i As Integer

        Dim iStepCount As Short
        iStepCount = oBOMRows.Count

        'Create a new ProgressBar object.
        Dim oProgressBar As Inventor.ProgressBar

        oProgressBar = ThisApplication.CreateProgressBar(False, iStepCount, "当前文件： ")

        For i = 1 To oBOMRows.Count
            ' Get the current row.
            Dim oRow As BOMRow
            oRow = oBOMRows.Item(i)

            Dim FileFullName As String

            FileFullName = oRow.ReferencedFileDescriptor.FullFileName

            '测试文件
            Debug.Print(FileFullName)

            ' Set the message for the progress bar
            oProgressBar.Message = FileFullName

            If IsFileExsts(FileFullName) = False Then   '跳过不存在的文件
                GoTo 999
            End If

            If InStr(FileFullName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                GoTo 999
            End If

            Dim strIdwFileFullName As String  '工程图全文件名


            strIdwFileFullName = GetChangeExtension(FileFullName, IDW)
            If IsFileExsts(strIdwFileFullName) = True Then



                Dim DwgPdfFullFileName As String        'dwgpdf 文件全文件名

                Select Case CADorPDF
                    Case "DWG"
                        DwgPdfFullFileName = GetChangeExtension(strIdwFileFullName, DWG)

                    Case "PDF"
                        DwgPdfFullFileName = GetChangeExtension(strIdwFileFullName, PDF)

                End Select

                IdwSaveAsDwgSub(strIdwFileFullName, DwgPdfFullFileName)


                '遍历下一级
                If (Not oRow.ChildRows Is Nothing) And FirstLevelOnly = False Then
                    Call SaveIdwInAsmAsDwgOrPdfChildSub(oRow.ChildRows, FirstLevelOnly, CADorPDF)
                End If
            End If
999:
            oProgressBar.UpdateProgress()
        Next

        oProgressBar.Close()

    End Sub


End Module