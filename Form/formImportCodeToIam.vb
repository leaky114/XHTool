Imports Inventor
Imports Inventor.DocumentTypeEnum
Imports Inventor.SelectionFilterEnum
Imports Inventor.SelectTypeEnum
Imports Microsoft.Office.Interop
Imports stdole
Imports System
Imports System.Windows.Forms

Public Class FormImportCodeToIam

    Private currentSortColumn As Integer = -1 ' 记录当前排序列
    Private sortOrder As SortOrder = SortOrder.None ' 记录当前排序方向
    Private Sub Btn装载_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn装载.Click
        lvw文件列表.Items.Clear()

        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Me.Dispose()
            Exit Sub
        End If

        If ThisApplication.ActiveEditDocument.DocumentType <> kAssemblyDocumentObject Then
            MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveEditDocument

        LoadBOM(oInventorAssemblyDocument, lvw文件列表, chk展开子级.Checked, chk展开外协.Checked)

        Me.Text = "导入ERP编码 ( 共" & lvw文件列表.Items.Count & "个文件)"
    End Sub


    ''' <summary>
    ''' 加载BOM
    ''' </summary>
    ''' <param name="oInventorAssemblyDocument">部件对象</param>
    ''' <param name="oListView">listview对象</param>
    ''' <param name="IsExpandChild">是否展开子集</param>
    ''' <param name="IsExpandOutsourcedParts">是否展开外协</param>
    ''' <remarks></remarks>
    Private Sub LoadBOM(ByVal oInventorAssemblyDocument As Inventor.AssemblyDocument,
                        ByVal oListView As ListView, ByVal IsExpandChild As Boolean,
                        ByVal IsExpandOutsourcedParts As Boolean)

        Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        OInteractionEvents.Start()
        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        ThisApplication.UserInterfaceManager.DoEvents()

        '==============================================================================================
        '基于bom结构化数据，可跳过参考的文件
        ' Set a reference to the BOM
        Dim oBOM As BOM
        oBOM = oInventorAssemblyDocument.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True
        oBOM.StructuredViewFirstLevelOnly = False

        'Set a reference to the "Structured" BOMView
        Dim oBOMView As BOMView

        oListView.BeginUpdate()

        '获取结构化的bom页面
        For Each oBOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                '遍历这个bom页面

                LoadBOMSub(oBOMView.BOMRows, oListView, IsExpandChild, IsExpandOutsourcedParts)

                Exit For
            End If
        Next

        '设置标准件颜色
        For Each oListViewItem As ListViewItem In oListView.Items

            If Strings.Left(oListViewItem.Text, 2) = "GB" Or Strings.Left(oListViewItem.Text, 2) = "JB" Then
                'oListViewItem.UseItemStyleForSubItems = False
                oListViewItem.BackColor = System.Drawing.Color.LightGreen
            End If
        Next

        oListView.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.ColumnContent)


        oListView.EndUpdate()

        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        OInteractionEvents.Stop()

    End Sub

    ''' <summary>
    ''' 从BOM加载文件ipro
    ''' </summary>
    ''' <param name="oBOMRows">BOMs对象</param>
    ''' <param name="olistiview">加载到listview对象</param>
    ''' <param name="IsExpandChild">是否加载子集</param>
    ''' <param name="IsExpandOutsourcedParts">是否展开外协件</param>
    ''' <remarks></remarks>
    Private Sub LoadBOMSub(ByVal oBOMRows As BOMRowsEnumerator, ByVal olistiview As ListView, ByVal IsExpandChild As Boolean, ByVal IsExpandOutsourcedParts As Boolean)
        On Error Resume Next

        'oProgressBar = ThisApplication.CreateProgressBar(False, iStepCount, "当前文件： ")

        For Each oBOMRow As BOMRow In oBOMRows
            Dim strInventorDocumentFullFileName As String = oBOMRow.ComponentDefinitions(1).Document.FullFileName

            '测试文件
            Debug.Print(strInventorDocumentFullFileName)

            SetStatusBarText(strInventorDocumentFullFileName)

            If IsFileExIsts(strInventorDocumentFullFileName) = False Then   '跳过不存在的文件
                'GoTo 999
                Continue For
            End If

            'if InStr(strInventorFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
            '    GoTo 999
            'End if

            Dim oInventorDocument As Inventor.Document
            oInventorDocument = ThisApplication.Documents.ItemByName(strInventorDocumentFullFileName)

            Dim oStockNumPartName As StockNumPartName
            oStockNumPartName = GetPropitems(oInventorDocument)

            '获取供应商
            Dim strVendor As String
            strVendor = GetPropitem(oInventorDocument, Map_Vendor)

            If IsItemInListView(olistiview, strInventorDocumentFullFileName) = False Then

                Dim oListViewItem As ListViewItem
                oListViewItem = lvw文件列表.Items.Add(oStockNumPartName.图号)

                With oListViewItem
                    .SubItems.Add(oStockNumPartName.零件名称)
                    .SubItems.Add(oStockNumPartName.ERP编码)
                    .SubItems.Add(strVendor)
                    .SubItems.Add(strInventorDocumentFullFileName)
                End With

                oInventorDocument.Close(True)
            End If

            '是否选择了展开子集
            If (oBOMRow.ChildRows IsNot Nothing) And IsExpandChild = True Then
                Select Case strVendor
                    Case "外协件"
                        If IsExpandOutsourcedParts = True Then
                            Call LoadBOMSub(oBOMRow.ChildRows, olistiview, IsExpandChild, IsExpandOutsourcedParts)
                            'Else
                            '    Call QueryBOMRowToLoadiPro(oBOMRow.ChildRows, olistiview, IsExpandChild, IsExpandOutsourcedParts)
                        End If
                    Case "外购件"
                        GoTo 999
                    Case Else
                        Call LoadBOMSub(oBOMRow.ChildRows, olistiview, IsExpandChild, IsExpandOutsourcedParts)
                End Select
            End If

999:
            'oProgressBar.UpdateProgress()
        Next

        'oProgressBar.Close()

    End Sub

    Private Sub Btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click, Me.Closing
        FormManager.CloseAndDisposeForm(Of FormImportCodeToIam)()
    End Sub

    Private Sub Btn查询_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn查询.Click
        On Error Resume Next
        'PartNum = FindSrtingInSheet(Excel_File_Name, StochNum, Sheet_Name, Table_Array, Col_Index_Num, 0)
        btn查询.Enabled = False

        Me.TopMost = False

        Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        OInteractionEvents.Start()
        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        ThisApplication.UserInterfaceManager.DoEvents()


        Dim oExcelApplication As Excel.Application
        oExcelApplication = New Excel.Application With {
            .Visible = False
        }

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

                SetStatusBarText(oListViewItem.SubItems(4).Text)

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
                                'Me.TopMost = False
                                If MessageBox.Show($"{oListViewItem.Text}({strNowRangeValue})查询到新的编码： {strFindRangeValue} ，是否替换？", XHTool,
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                    oListViewItem.SubItems(2).Text = strFindRangeValue
                                    oListViewItem.UseItemStyleForSubItems = False
                                    oListViewItem.SubItems(2).ForeColor = Drawing.Color.DarkOrange
                                    'Me.TopMost = True
                                    Exit For
                                Else
                                    'Me.TopMost = True
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

        Me.TopMost = True

        'OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        OInteractionEvents.Stop()

    End Sub

    Private Sub Btn写入_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn写入.Click
        On Error Resume Next

        Dim oInventorDocument As Inventor.Document
        Dim strInventorDocumentFullFileName As String
        Dim strERPCoding As String

        btn写入.Enabled = False

        Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        OInteractionEvents.Start()
        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        ThisApplication.UserInterfaceManager.DoEvents()

        With prg进度条
            .Minimum = 0
            .Maximum = lvw文件列表.Items.Count
            .Value = 0
        End With

        For Each oListViewItem As ListViewItem In lvw文件列表.Items

            SetStatusBarText(oListViewItem.SubItems(4).Text)

            If oListViewItem.SubItems(2).ForeColor = Drawing.Color.Red Or oListViewItem.SubItems(2).ForeColor = Drawing.Color.DarkOrange Then
                oListViewItem.SubItems(2).ForeColor = Drawing.Color.Black  '写入后变为黑色
                strERPCoding = oListViewItem.SubItems(2).Text
                strInventorDocumentFullFileName = oListViewItem.SubItems(4).Text
                'oInventorDocument = ThisApplication.Documents.Open(strInventorFullFileName, False)

                oInventorDocument = ThisApplication.Documents.ItemByName(strInventorDocumentFullFileName)

                SetPropitem(oInventorDocument, Map_ERPCode, strERPCoding)
            End If

            prg进度条.Value = prg进度条.Value + 1
        Next

        btn写入.Enabled = True

        'OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        OInteractionEvents.Stop()

    End Sub

    Private Sub Lvw文件列表_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvw文件列表.ColumnClick

        ' 如果点击的是同一列
        If e.Column = currentSortColumn Then
            ' 切换排序方向
            If SortOrder = SortOrder.Ascending Then
                SortOrder = SortOrder.Descending
            Else
                SortOrder = SortOrder.Ascending
            End If
        Else ' 点击新列
            currentSortColumn = e.Column
            SortOrder = SortOrder.Ascending ' 默认新列按升序排序
        End If

        ' 设置排序图标
        lvw文件列表.ListViewItemSorter = New ListViewColumnSorter(e.Column, SortOrder)
        lvw文件列表.Sort()

        ' 更新列头排序图标
        UpdateSortIcon(lvw文件列表)

    End Sub

    ''' <summary>
    '''  更新列头排序图标
    ''' </summary>
    ''' <param name="oListView">listview对象</param>
    Private Sub UpdateSortIcon(ByVal oListView As ListView)
        ' 清除所有列头图标
        For Each col As ColumnHeader In oListView.Columns
            col.Text = col.Text.Replace(" ↑", "").Replace(" ↓", "")
        Next

        ' 为当前排序列添加图标
        If currentSortColumn >= 0 Then
            Dim arrow = If(sortOrder = SortOrder.Ascending, " ↑", " ↓")
            oListView.Columns(currentSortColumn).Text += arrow
        End If
    End Sub

    Private Sub Lvw文件列表_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvw文件列表.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim strInventorFullFileName As String
            strInventorFullFileName = lvw文件列表.SelectedItems(0).SubItems(4).Text
            ThisApplication.Documents.Open(strInventorFullFileName)
        End If
    End Sub

    Private Sub Lvw文件列表_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvw文件列表.SelectedIndexChanged
        Try
            If lvw文件列表.SelectedIndices.Count > 0 Then
                Dim index As Integer = lvw文件列表.SelectedIndices(0)  '选中行的下一行索引
                If index < lvw文件列表.Items.Count Then

                    Dim oListViewItem As ListViewItem = lvw文件列表.Items(index)
                    Dim strInventorDocumentFullFileName As String  '文件全名
                    strInventorDocumentFullFileName = oListViewItem.SubItems(4).Text

                    SelectAssemblyComponentDefinition(strInventorDocumentFullFileName)

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, xhtool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FrmInventoryCoding_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48

        lvw文件列表.Items.Clear()

        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Me.Dispose()
            Exit Sub
        End If

        If ThisApplication.ActiveEditDocument.DocumentType <> kAssemblyDocumentObject Then
            MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Me.Dispose()
            Exit Sub
        End If

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveEditDocument

        LoadBOM(oInventorAssemblyDocument, lvw文件列表, chk展开子级.Checked, chk展开外协.Checked)

        Me.Text = "导入ERP编码 ( 共" & lvw文件列表.Items.Count & "个文件)"

        SetWindowSizeAndCenter(Me)

    End Sub

    Private Sub ContextMenuStrip右键菜单_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ContextMenuStrip右键菜单.ItemClicked
        Try
            If (lvw文件列表.SelectedIndices.Count > 0) Then

                Dim strInventorDocumentFullFileName As String
                strInventorDocumentFullFileName = lvw文件列表.SelectedItems(0).SubItems(4).Text

                Dim oInventorDocument As Inventor.Document     '当前文件
                'oInventorDocument = ThisApplication.Documents.Open(strInventorFullFileName, False)
                oInventorDocument = ThisApplication.Documents.ItemByName(strInventorDocumentFullFileName)

                Dim strVendor As String

                Select Case e.ClickedItem.Name
                    Case "ToolStrip清空供应商"
                        strVendor = ""
                    Case Else
                        strVendor = Strings.Right(e.ClickedItem.Text, 3)
                End Select

                SetPropitem(oInventorDocument, Map_Vendor, strVendor)

                lvw文件列表.SelectedItems(0).SubItems(3).Text = strVendor
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, xhtool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class