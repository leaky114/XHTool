Imports Inventor
Imports Inventor.DocumentTypeEnum
Imports Inventor.SelectionFilterEnum
Imports Inventor.SelectTypeEnum
Imports Microsoft.Office.Interop
Imports stdole
Imports System
Imports System.Windows.Forms

Public Class frmImportCodeToIam

    Private Sub btn装载_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn装载.Click

        lvw文件列表.Items.Clear()

        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Me.Dispose()
            Exit Sub
        End If

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        If oInventorDocument.DocumentType <> kAssemblyDocumentObject Then
            MsgBox("该功能仅适用于部件", MsgBoxStyle.Information)
            'Me.Dispose()
            Exit Sub
        End If

        btn装载.Enabled = False

        Dim oInteraction As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        oInteraction.Start()
        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
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

        lvw文件列表.BeginUpdate()

        '获取结构化的bom页面
        For Each oBOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                '遍历这个bom页面

                QueryBOMRowToLoadiPro(oBOMView.BOMRows, lvw文件列表, chk展开子级.Checked, chk展开外协.Checked)
            End If
        Next

        '设置标准件颜色
        For Each oListViewItem As ListViewItem In lvw文件列表.Items

            If Strings.Left(oListViewItem.Text, 2) = "GB" Or Strings.Left(oListViewItem.Text, 2) = "JB" Then
                'oListViewItem.UseItemStyleForSubItems = False
                oListViewItem.BackColor = System.Drawing.Color.LightGreen
            End If
        Next

        lvw文件列表.EndUpdate()
        Me.Text = "导入ERP编码 ( 共" & lvw文件列表.Items.Count & "个文件)"

        oInteraction.Stop()

        btn装载.Enabled = True


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

    End Sub

    Private Sub QueryBOMRowToLoadiPro(ByVal oBOMRows As BOMRowsEnumerator, ByVal olistiview As ListView, ByVal IsExpandChild As Boolean, ByVal IsExpandOutsourcedParts As Boolean)
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

            '获取供应商
            Dim strVendor As String
            strVendor = GetPropitem(oInventorDocument, Map_Vendor)

            If IsItemInListView(olistiview, oStockNumPartName.StockNum) = False Then

                Dim oListViewItem As ListViewItem
                oListViewItem = lvw文件列表.Items.Add(oStockNumPartName.StockNum)

                With oListViewItem
                    .SubItems.Add(oStockNumPartName.PartName)
                    .SubItems.Add(oStockNumPartName.ERPCode)
                    .SubItems.Add(strVendor)
                    .SubItems.Add(strFullFileName)
                End With

                oInventorDocument.Close(True)
            End If

            '是否选择了展开子集
            If (Not oBOMRow.ChildRows Is Nothing) And IsExpandChild = True Then
                Select Case strVendor
                    Case "外协件"
                        If IsExpandOutsourcedParts = True Then
                            Call QueryBOMRowToLoadiPro(oBOMRow.ChildRows, olistiview, IsExpandChild, IsExpandOutsourcedParts)
                            'Else
                            '    Call QueryBOMRowToLoadiPro(oBOMRow.ChildRows, olistiview, IsExpandChild, IsExpandOutsourcedParts)
                        End If
                    Case "外购件"
                        GoTo 999
                    Case Else
                        Call QueryBOMRowToLoadiPro(oBOMRow.ChildRows, olistiview, IsExpandChild, IsExpandOutsourcedParts)
                End Select
            End If

999:
            'oProgressBar.UpdateProgress()
        Next

        'oProgressBar.Close()

    End Sub

    Private Sub btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub btn查询_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn查询.Click
        On Error Resume Next
        'PartNum = FindSrtingInSheet(Excel_File_Name, StochNum, Sheet_Name, Table_Array, Col_Index_Num, 0)
        btn查询.Enabled = False


        Dim oInteraction As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        oInteraction.Start()
        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        'System.Threading.Thread.Sleep(5000)

        Dim oExcelApplication As Excel.Application
        oExcelApplication = New Excel.Application
        oExcelApplication.Visible = False

        'Excel_File_Name = "E:\软件\Invenotr\Inventor编程\InventorAddIn\code\bin\最新物料编码.xls"

        Dim oWorkbook As Excel.Workbook = oExcelApplication.Workbooks.Open(BasicExcelFullFileName, 0, True)
        Dim oWorksheet As Excel.Worksheet = Nothing

        Dim oRange As Excel.Range = Nothing

        For Each oWorksheet In oWorkbook.Sheets
            'sht = wb.Sheets(Sheet_Name)
            'sht = wb.Sheets("物料")

            Dim arrTable(20) As String

            arrTable = Split(TableArrays, ",")

            Dim dblMatchRow As Double   '寻找到的行

            With prg进度条
                .Minimum = 0
                .Maximum = lvw文件列表.Items.Count
                .Value = 0
            End With

            For Each oListViewItem As ListViewItem In lvw文件列表.Items
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

                        If strNowRangeValue = "" Then      '当前erp编码为空值
                            oListViewItem.SubItems(2).Text = strFindRangeValue
                            oListViewItem.UseItemStyleForSubItems = False
                            oListViewItem.SubItems(2).ForeColor = Drawing.Color.Red
                            Exit For
                        Else
                            If strNowRangeValue = strFindRangeValue Then   '查询值等于当前值
                                Exit For
                            Else
                                Me.TopMost = False
                                If MsgBox(oListViewItem.Text & "(" & strNowRangeValue & ") 查询到新的编码：" & vbCrLf & strFindRangeValue & vbCrLf & "是否替换？", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                    oListViewItem.SubItems(2).Text = strFindRangeValue
                                    oListViewItem.UseItemStyleForSubItems = False
                                    oListViewItem.SubItems(2).ForeColor = Drawing.Color.DarkOrange
                                    Me.TopMost = True
                                    Exit For
                                Else
                                    Me.TopMost = True
                                    Exit For
                                End If

                            End If
                        End If


                    End If
                Next

                prg进度条.Value = prg进度条.Value + 1
            Next
        Next
        '关闭文件
        oWorkbook.Saved = True
        oWorkbook.Close()
        ' 8.退出Excel程序
        oExcelApplication.Quit()

        '9.释放资源
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oRange)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oWorksheet)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oWorkbook)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcelApplication)

        '10.调用GC的垃圾收集方法
        GC.Collect()
        GC.WaitForPendingFinalizers()

        btn查询.Enabled = True
        oInteraction.Stop()
    End Sub

    Private Sub btn写入_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn写入.Click
        On Error Resume Next

        Dim oInventorDocument As Inventor.Document
        Dim strInventorFullFileName As String
        Dim strERPCoding As String

        btn写入.Enabled = False

        Dim oInteraction As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        oInteraction.Start()
        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        'System.Threading.Thread.Sleep(5000)
        '

        With prg进度条
            .Minimum = 0
            .Maximum = lvw文件列表.Items.Count
            .Value = 0
        End With

        For Each oListViewItem As ListViewItem In lvw文件列表.Items

            If oListViewItem.SubItems(2).ForeColor = Drawing.Color.Red Or oListViewItem.SubItems(2).ForeColor = Drawing.Color.DarkOrange Then
                oListViewItem.SubItems(2).ForeColor = Drawing.Color.Black  '写入后变为黑色
                strERPCoding = oListViewItem.SubItems(2).Text
                strInventorFullFileName = oListViewItem.SubItems(4).Text
                oInventorDocument = ThisApplication.Documents.Open(strInventorFullFileName, False)
                SetPropitem(oInventorDocument, Map_ERPCode, strERPCoding)
            End If

            prg进度条.Value = prg进度条.Value + 1
        Next

        btn写入.Enabled = True
        oInteraction.Stop()
    End Sub

    Private Sub lvw文件列表_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvw文件列表.ColumnClick
        If _ListViewSorter = clsListViewSorter.EnumSortOrder.Ascending Then
            Dim Sorter As New clsListViewSorter(e.Column, clsListViewSorter.EnumSortOrder.Descending)
            lvw文件列表.ListViewItemSorter = Sorter
            _ListViewSorter = clsListViewSorter.EnumSortOrder.Descending
        Else
            Dim Sorter As New clsListViewSorter(e.Column, clsListViewSorter.EnumSortOrder.Ascending)
            lvw文件列表.ListViewItemSorter = Sorter
            _ListViewSorter = clsListViewSorter.EnumSortOrder.Ascending
        End If

    End Sub

    Private Sub lvw文件列表_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvw文件列表.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim strInventorFullFileName As String
            strInventorFullFileName = lvw文件列表.SelectedItems(0).SubItems(4).Text
            ThisApplication.Documents.Open(strInventorFullFileName)
        End If
    End Sub

    Private Sub lvw文件列表_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvw文件列表.SelectedIndexChanged
        Try
            If (lvw文件列表.SelectedIndices.Count > 0 And chk提示选择.Checked = True) Then
                Dim index As Integer = lvw文件列表.SelectedIndices(0)  '选中行的下一行索引
                If index < lvw文件列表.Items.Count Then

                    Dim oListViewItem As ListViewItem = lvw文件列表.Items(index)
                    Dim strInventorFullFileName As String  '文件全名
                    strInventorFullFileName = oListViewItem.SubItems(4).Text

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
        btn装载_Click(sender, e)
    End Sub

    Private Sub ContextMenuStrip右键菜单_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ContextMenuStrip右键菜单.ItemClicked
        Try
            If (lvw文件列表.SelectedIndices.Count > 0) Then

                Dim strInventorFullFileName As String
                strInventorFullFileName = lvw文件列表.SelectedItems(0).SubItems(4).Text

                Dim oInventorDocument As Inventor.Document     '当前文件
                oInventorDocument = ThisApplication.Documents.Open(strInventorFullFileName, False)

                Dim strVendor As String
                strVendor = Strings.Right(e.ClickedItem.Text, 3)
                SetPropitem(oInventorDocument, Map_Vendor, strVendor)

                lvw文件列表.SelectedItems(0).SubItems(3).Text = strVendor
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class