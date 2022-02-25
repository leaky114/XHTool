Imports System.Windows.Forms
Imports Inventor.SelectionFilterEnum
Imports Inventor.SelectTypeEnum
Imports Inventor.DocumentTypeEnum
Imports Inventor
Imports Microsoft.Office.Interop

Public Class frmInventoryCoding


    Private Sub btnLoadFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadFile.Click

        btnLoadFile.Enabled = False
        lvwFileList.Items.Clear()

        SetStatusBarText()

        If IsInventorOpenDoc() = False Then
            Exit Sub
        End If

        Dim oAssemblyDocument As AssemblyDocument

        oAssemblyDocument = ThisApplication.ActiveDocument

        If oAssemblyDocument.DocumentType <> kAssemblyDocumentObject Then
            MsgBox("该功能仅适用于部件")
            Exit Sub
        End If

        '==============================================================================================
        '基于bom结构化数据，可跳过参考的文件
        ' Set a reference to the BOM
        Dim oBOM As BOM
        oBOM = oAssemblyDocument.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True

        'Set a reference to the "Structured" BOMView
        Dim oBOMView As BOMView

        '获取结构化的bom页面
        For Each oBOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                '遍历这个bom页面
                QueryBOMRowToLoadiPro(oBOMView.BOMRows, lvwFileList)
            End If
        Next
        '==============================================================================================


        '' 获取所有引用文档
        'Dim oAllReferencedDocuments As DocumentsEnumerator
        'oAllReferencedDocuments = oAssemblyDocument.AllReferencedDocuments

        'With prgProcess
        '    .Minimum = 0
        '    .Maximum = oAllReferencedDocuments.Count
        '    .Value = 0
        'End With


        ' 遍历这些文档

        'For Each ReferencedDocument As Document In oAllReferencedDocuments
        '    Debug.Print(ReferencedDocument.DisplayName)
        '    Dim oStockNumPartName As StockNumPartName
        '    oStockNumPartName = GetPropitems(ReferencedDocument)

        '    Dim LVI As ListViewItem
        '    LVI = lvwFileList.Items.Add(oStockNumPartName.StockNum)
        '    LVI.SubItems.Add(oStockNumPartName.PartName)
        '    LVI.SubItems.Add(oStockNumPartName.PartNum)
        '    LVI.SubItems.Add(ReferencedDocument.FullDocumentName)

        '    prgProcess.Value = prgProcess.Value + 1
        'Next

        btnLoadFile.Enabled = True

    End Sub

    Public Sub QueryBOMRowToLoadiPro(ByVal oBOMRows As BOMRowsEnumerator, olistiview As ListView)
        Dim i As Integer

        Dim iStepCount As Short
        iStepCount = oBOMRows.Count

        'Create a new ProgressBar object.
        'Dim oProgressBar As Inventor.ProgressBar

        'oProgressBar = ThisApplication.CreateProgressBar(False, iStepCount, "当前文件： ")

        For i = 1 To oBOMRows.Count
            ' Get the current row.
            Dim oBOMRow As BOMRow
            oBOMRow = oBOMRows.Item(i)

            Dim oFullFileName As String
            oFullFileName = oBOMRow.ReferencedFileDescriptor.FullFileName

            '测试文件
            Debug.Print(oFullFileName)

            ' Set the message for the progress bar
            'oProgressBar.Message = oFullFileName

            If IsFileExsts(oFullFileName) = False Then   '跳过不存在的文件
                GoTo 999
            End If

            If InStr(oFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                GoTo 999
            End If

            Dim oInventorDocument As Inventor.Document
            oInventorDocument = ThisApplication.Documents.Open(oFullFileName, False)  '打开文件，不显示


            Dim oStockNumPartName As StockNumPartName
            oStockNumPartName = GetPropitems(oInventorDocument)

            Dim LVI As ListViewItem
            LVI = lvwFileList.Items.Add(oStockNumPartName.StockNum)
            LVI.SubItems.Add(oStockNumPartName.PartName)
            LVI.SubItems.Add(oStockNumPartName.PartNum)
            LVI.SubItems.Add(oFullFileName)
            oInventorDocument.Close(True)
           

            '遍历下一级
            If (Not oBOMRow.ChildRows Is Nothing) Then
                Call QueryBOMRowToLoadiPro(oBOMRow.ChildRows, olistiview)
            End If

999:
            'oProgressBar.UpdateProgress()
        Next

        'oProgressBar.Close()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSearchCoding_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchCoding.Click

        On Error Resume Next
        'PartNum = FindSrtingInSheet(Excel_File_Name, StochNum, Sheet_Name, Table_Array, Col_Index_Num, 0)
        btnSearchCoding.Enabled = False

        Dim excelApp As Excel.Application
        excelApp = New Excel.Application

        'excelApp.Visible = True
        'Excel_File_Name = "E:\软件\Invenotr\Inventor编程\InventorAddIn\code\bin\最新物料编码.xls"

        Dim wb As Excel.Workbook = excelApp.Workbooks.Open(Excel_File_Name, 0, True)
        Dim sht As Excel.Worksheet = Nothing

        Dim userange As Excel.Range = Nothing

        For Each sht In wb.Sheets
            'sht = wb.Sheets(Sheet_Name)
            'sht = wb.Sheets("物料")

            Dim Table_Array(10) As String

            Table_Array = Split("A,C,D,E", ",")

            Dim MatchRow As Double   '寻找到的行

            With prgProcess
                .Minimum = 0
                .Maximum = lvwFileList.Items.Count
                .Value = 0
            End With

            For Each LVI As ListViewItem In lvwFileList.Items
                For Each a In Table_Array
                    userange = sht.Range(a & ":" & a)
                    MatchRow = 0
                    MatchRow = excelApp.WorksheetFunction.Match(LVI.Text, userange, 0)

                    If MatchRow <> 0.0 Then

                        '当前值
                        Dim NowRangeValue As String = LVI.SubItems(2).Text

                        Dim FindRange As String  '寻找的单元
                        Dim FindRangeValue As String    '寻找的值

                        'FindRange = "B" & MatchRow
                        FindRange = Col_Index_Num & MatchRow
                        FindRangeValue = sht.Range(FindRange).Value

                        If NowRangeValue <> FindRangeValue Then
                            LVI.SubItems(2).Text = FindRangeValue
                            LVI.UseItemStyleForSubItems = False
                            LVI.SubItems(2).ForeColor = Drawing.Color.Red
                            Exit For
                        End If
                    End If
                Next

                prgProcess.Value = prgProcess.Value + 1
            Next
        Next
        '关闭文件
        wb.Close()
        ' 8.退出Excel程序
        excelApp.Quit()

        '9.释放资源
        System.Runtime.InteropServices.Marshal.ReleaseComObject(userange)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(sht)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(wb)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp)

        btnSearchCoding.Enabled = True
    End Sub

    Private Sub btnWriteCoding_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWriteCoding.Click

        Dim oInventorDocument As Inventor.Document
        Dim FullDocumentName As String
        Dim oCoding As String

        btnWriteCoding.Enabled = False

        With prgProcess
            .Minimum = 0
            .Maximum = lvwFileList.Items.Count
            .Value = 0
        End With

        For Each LVI As ListViewItem In lvwFileList.Items

            If LVI.SubItems(2).ForeColor = Drawing.Color.Red Then
                LVI.SubItems(2).ForeColor = Drawing.Color.Black  '写入后变为黑色
                oCoding = LVI.SubItems(2).Text
                FullDocumentName = LVI.SubItems(3).Text
                oInventorDocument = ThisApplication.Documents.Open(FullDocumentName, False)
                SetPropitem(oInventorDocument, "成本中心", oCoding)
            End If

            prgProcess.Value = prgProcess.Value + 1
        Next

        btnWriteCoding.Enabled = True
    End Sub

    Private Sub lvwFileList_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lvwFileList.MouseDoubleClick
        ThisApplication.Documents.Open(lvwFileList.SelectedItems(0).SubItems(3).Text)
    End Sub

End Class