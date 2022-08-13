Imports System.Windows.Forms
Imports Inventor.SelectionFilterEnum
Imports Inventor.SelectTypeEnum
Imports Inventor.DocumentTypeEnum
Imports Inventor
Imports Microsoft.Office.Interop
Imports stdole

Public Class frmInventoryCoding

    Private Sub btnLoadFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadFile.Click

        btnLoadFile.Enabled = False

        lvwFileListView.Items.Clear()

        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        If oInventorDocument.DocumentType <> kAssemblyDocumentObject Then
            MsgBox("该功能仅适用于部件", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim oAssemblyDocument As AssemblyDocument
        oAssemblyDocument = oInventorDocument

        '==============================================================================================
        '基于bom结构化数据，可跳过参考的文件
        ' Set a reference to the BOM
        Dim oBOM As BOM
        oBOM = oAssemblyDocument.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True
        oBOM.StructuredViewFirstLevelOnly = False

        'Set a reference to the "Structured" BOMView
        Dim oBOMView As BOMView

        lvwFileListView.BeginUpdate()

        '获取结构化的bom页面
        For Each oBOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                '遍历这个bom页面

                QueryBOMRowToLoadiPro(oBOMView.BOMRows, lvwFileListView)
            End If
        Next


        '设置标准件颜色
        For Each oListViewItem As ListViewItem In lvwFileListView.Items

            If Strings.Left(oListViewItem.Text, 2) = "GB" Then
                'oListViewItem.UseItemStyleForSubItems = False
                oListViewItem.BackColor = Drawing.Color.LightGreen
            End If
        Next


        lvwFileListView.EndUpdate()
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
        On Error Resume Next

        Dim i As Integer

        Dim intStepCount As Integer
        intStepCount = oBOMRows.Count

        'Create a new ProgressBar object.
        'Dim oProgressBar As Inventor.ProgressBar

        'oProgressBar = ThisApplication.CreateProgressBar(False, iStepCount, "当前文件： ")


        For i = 1 To intStepCount
            ' Get the current row.
            Dim oBOMRow As BOMRow
            oBOMRow = oBOMRows.Item(i)

            Dim strFullFileName As String
            strFullFileName = oBOMRow.ReferencedFileDescriptor.FullFileName

            '测试文件
            Debug.Print(strFullFileName)

            ' Set the message for the progress bar
            'oProgressBar.Message = oFullFileName

            If IsFileExsts(strFullFileName) = False Then   '跳过不存在的文件
                GoTo 999
            End If

            'If InStr(strFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
            '    GoTo 999
            'End If

            Dim oInventorDocument As Inventor.Document
            oInventorDocument = ThisApplication.Documents.Open(strFullFileName, False)  '打开文件，不显示


            Dim oStockNumPartName As StockNumPartName
            oStockNumPartName = GetPropitems(oInventorDocument)

            If IsItemInListView(olistiview, oStockNumPartName.StockNum) = False Then

                Dim oListViewItem As ListViewItem
                oListViewItem = lvwFileListView.Items.Add(oStockNumPartName.StockNum)

                With oListViewItem
                    .SubItems.Add(oStockNumPartName.PartName)
                    .SubItems.Add(oStockNumPartName.PartNum)
                    .SubItems.Add(strFullFileName)
                End With
                oInventorDocument.Close(True)
            End If

            If chkChild.Checked = True Then

                '遍历下一级
                If (Not oBOMRow.ChildRows Is Nothing) Then
                    Call QueryBOMRowToLoadiPro(oBOMRow.ChildRows, olistiview)
                End If
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

        Dim oExcelApplication As Excel.Application
        oExcelApplication = New Excel.Application
        oExcelApplication.Visible = False

        'Excel_File_Name = "E:\软件\Invenotr\Inventor编程\InventorAddIn\code\bin\最新物料编码.xls"

        Dim oWorkbook As Excel.Workbook = oExcelApplication.Workbooks.Open(ExcelFullFileName, 0, True)
        Dim oWorksheet As Excel.Worksheet = Nothing

        Dim oRange As Excel.Range = Nothing

        For Each oWorksheet In oWorkbook.Sheets
            'sht = wb.Sheets(Sheet_Name)
            'sht = wb.Sheets("物料")

            Dim arrTable(20) As String

            arrTable = Split(TableArrays, ",")

            Dim dblMatchRow As Double   '寻找到的行

            With prgProcess
                .Minimum = 0
                .Maximum = lvwFileListView.Items.Count
                .Value = 0
            End With

            For Each oListViewItem As ListViewItem In lvwFileListView.Items
                For Each strTable As String In arrTable
                    oRange = oWorksheet.Range(strTable & ":" & strTable)
                    dblMatchRow = 0
                    dblMatchRow = oExcelApplication.WorksheetFunction.Match(oListViewItem.Text, oRange, 0)

                    If dblMatchRow <> 0.0 Then

                        '当前值
                        Dim strNowRangeValue As String = oListViewItem.SubItems(2).Text

                        Dim strFindRange As String  '寻找的单元
                        Dim strFindRangeValue As String    '寻找的值

                        'FindRange = "B" & MatchRow
                        strFindRange = ColIndexNum & dblMatchRow
                        strFindRangeValue = oWorksheet.Range(strFindRange).Value

                        If strNowRangeValue <> strFindRangeValue Then
                            oListViewItem.SubItems(2).Text = strFindRangeValue
                            oListViewItem.UseItemStyleForSubItems = False
                            oListViewItem.SubItems(2).ForeColor = Drawing.Color.Red
                            Exit For
                        End If
                    End If
                Next

                prgProcess.Value = prgProcess.Value + 1
            Next
        Next
        '关闭文件
        oWorkbook.Close()
        ' 8.退出Excel程序
        oExcelApplication.Quit()

        '9.释放资源
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oRange)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oWorksheet)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oWorkbook)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcelApplication)

        btnSearchCoding.Enabled = True
    End Sub

    Private Sub btnWriteCoding_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWriteCoding.Click

        Dim oInventorDocument As Inventor.Document
        Dim strInventorFullFileName As String
        Dim strERPCoding As String

        btnWriteCoding.Enabled = False

        With prgProcess
            .Minimum = 0
            .Maximum = lvwFileListView.Items.Count
            .Value = 0
        End With

        For Each oListViewItem As ListViewItem In lvwFileListView.Items

            If oListViewItem.SubItems(2).ForeColor = Drawing.Color.Red Then
                oListViewItem.SubItems(2).ForeColor = Drawing.Color.Black  '写入后变为黑色
                strERPCoding = oListViewItem.SubItems(2).Text
                strInventorFullFileName = oListViewItem.SubItems(3).Text
                oInventorDocument = ThisApplication.Documents.Open(strInventorFullFileName, False)
                SetPropitem(oInventorDocument, Map_ERPCode, strERPCoding)
            End If

            prgProcess.Value = prgProcess.Value + 1
        Next

        btnWriteCoding.Enabled = True
    End Sub

    Private Sub lvwFileListView_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvwFileListView.ColumnClick
        If _ListViewSorter = clsListViewSorter.EnumSortOrder.Ascending Then
            Dim Sorter As New clsListViewSorter(e.Column, clsListViewSorter.EnumSortOrder.Descending)
            lvwFileListView.ListViewItemSorter = Sorter
            _ListViewSorter = clsListViewSorter.EnumSortOrder.Descending
        Else
            Dim Sorter As New clsListViewSorter(e.Column, clsListViewSorter.EnumSortOrder.Ascending)
            lvwFileListView.ListViewItemSorter = Sorter
            _ListViewSorter = clsListViewSorter.EnumSortOrder.Ascending
        End If

    End Sub

    Private Sub lvwFileListView_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lvwFileListView.MouseDoubleClick
        ThisApplication.Documents.Open(lvwFileListView.SelectedItems(0).SubItems(3).Text)
    End Sub

    Private Sub lvwFileListView_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwFileListView.SelectedIndexChanged
        Try
            If (lvwFileListView.SelectedIndices.Count > 0 And chkSelectPart.Checked = True) Then
                Dim index As Integer = lvwFileListView.SelectedIndices(0)  '选中行的下一行索引
                If index < lvwFileListView.Items.Count Then

                    Dim oListViewItem As ListViewItem = lvwFileListView.Items(index)
                    Dim strInventorFullFileName As String  '文件全名
                    strInventorFullFileName = oListViewItem.SubItems(3).Text

                    Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
                    oInventorAssemblyDocument = ThisApplication.ActiveDocument

                    'Dim strInventorAssemblyFullFileName As String
                    'strInventorAssemblyFullFileName = oInventorAssemblyDocument.FullFileName

                    ' 获取装配定义
                    Dim oAssemblyComponentDefinition As AssemblyComponentDefinition
                    oAssemblyComponentDefinition = oInventorAssemblyDocument.ComponentDefinition

                    ' 获取装配子集
                    Dim oComponentOccurrences As ComponentOccurrences
                    oComponentOccurrences = oAssemblyComponentDefinition.Occurrences

                    '遍历
                    For Each oComponentOccurrence As ComponentOccurrence In oComponentOccurrences
                        If oComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName = strInventorFullFileName Then
                            ThisApplication.CommandManager.DoSelect(oComponentOccurrence)
                        Else
                            ThisApplication.CommandManager.DoUnSelect(oComponentOccurrence)
                        End If
                    Next

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmInventoryCoding_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnLoadFile_Click(sender, e)
    End Sub
End Class