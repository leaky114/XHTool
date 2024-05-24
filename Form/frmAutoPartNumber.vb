Imports System.Windows.Forms
Imports Inventor
Imports Microsoft
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.ObjectModel
Imports System.IO

Public Class frmAutoPartNumber

    '开始编号
    Private Sub btn开始_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn开始.Click

        Dim strOldFullFileName As String   '旧文件全名
        Dim strNewFullFileName As String   '新文件全名
        Dim oListViewItem As ListViewItem

        Try

            btn开始.Enabled = False
            Me.TopMost = False

            Dim oInteraction As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
            oInteraction.Start()
            oInteraction.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)


            For i = 0 To lvw文件列表.Items.Count - 1
                oListViewItem = lvw文件列表.Items(i)

                strOldFullFileName = oListViewItem.SubItems(3).Text & "\" & oListViewItem.Text & oListViewItem.SubItems(1).Text

                SetStatusBarText(strOldFullFileName)

                If oListViewItem.SubItems(2).Text = "" Then
                    GoTo 999
                End If
                strNewFullFileName = oListViewItem.SubItems(3).Text & "\" & oListViewItem.SubItems(2).Text & oListViewItem.SubItems(1).Text

                '同名不跳过
                If strOldFullFileName = strNewFullFileName Then
                    GoTo 999
                End If

                '打开旧文件,不显示
                Dim oOldInventorDocument As Inventor.Document
                oOldInventorDocument = ThisApplication.Documents.Open(strOldFullFileName, False)

                '另存为新文件
                oOldInventorDocument.SaveAs(strNewFullFileName, False)

                '关闭旧图
                oOldInventorDocument.Close()

                '后台打开文件，修改ipro
                Dim oNewInventorDocument As Inventor.Document
                oNewInventorDocument = ThisApplication.Documents.Open(strNewFullFileName, False)  '打开文件，不显示
                SetDocumentIpropertyFromFileNameSub(oNewInventorDocument, True) '设置Iproperty，打开文件后需关闭

                Dim oComponentOccurrences As Inventor.ComponentOccurrences
                oComponentOccurrences = ThisApplication.ActiveDocument.ComponentDefinition.Occurrences

                '全部替换为新文件
                For Each oComponentOccurrence As ComponentOccurrence In oComponentOccurrences
                    If oComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName = strOldFullFileName Then
                        oComponentOccurrence.Replace(strNewFullFileName, True)
                        Exit For
                    End If
                Next

                Dim strOldDrawingFullFileName As String
                strOldDrawingFullFileName = GetChangeExtension(strOldFullFileName, IDW)   '旧工程图

                If IsFileExsts(strOldDrawingFullFileName) = True Then

                    Dim strNewDrawingFullFileName As String

                    strNewDrawingFullFileName = GetChangeExtension(strNewFullFileName, IDW)   '新工程图
                    FileSystem.FileCopy(strOldDrawingFullFileName, strNewDrawingFullFileName)             '复制为新工程图

                    ReplaceFileReference(strNewDrawingFullFileName, strOldFullFileName, strNewFullFileName)

                End If

                ThisApplication.ActiveDocument.Update()

                '变更扩展名为old
                If chk备份文件.Checked = True Then
                    AddOldExtension(strOldFullFileName)
                    AddOldExtension(strOldDrawingFullFileName)
                End If
999:
            Next

            Me.TopMost = True
            SetStatusBarText("自动命名图号完成！")
            MsgBox("自动命名图号完成", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "自动命名图号")
            btn开始.Enabled = True

            oInteraction.SetCursor(CursorTypeEnum.kCursorTypeDefault)
            oInteraction.Stop()

        Catch ex As Exception
            Me.TopMost = True
            btn开始.Enabled = True
            MsgBox(ex.Message)
        End Try

    End Sub

    '关闭
    Private Sub btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click
        lvw文件列表.Items.Clear()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btn上移_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn上移.Click
        ListViewUp(lvw文件列表)
    End Sub

    Private Sub btn下移_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn下移.Click
        ListViewDown(lvw文件列表)
    End Sub

    ''排序
    'Private Sub lvw文件列表_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvw文件列表.ColumnClick
    '    '    if _ListViewSorter = clsListViewSorter.EnumSortOrder.Ascending Then
    '    '        Dim Sorter As New clsListViewSorter(e.Column, clsListViewSorter.EnumSortOrder.Descending)
    '    '        lvw文件列表.ListViewItemSorter = Sorter
    '    '        _ListViewSorter = clsListViewSorter.EnumSortOrder.Descending
    '    '    Else
    '    '        Dim Sorter As New clsListViewSorter(e.Column, clsListViewSorter.EnumSortOrder.Ascending)
    '    '        lvw文件列表.ListViewItemSorter = Sorter
    '    '        _ListViewSorter = clsListViewSorter.EnumSortOrder.Ascending
    '    '    End if


    'End Sub

    '列头点击事件处理程序
    Private Sub listView1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvw文件列表.ColumnClick
        ' 获取当前排序的列索引
        Dim columnIndex As Integer = e.Column

        ' 判断是否当前列为排序列
        If columnIndex = lvw文件列表.Sorting AndAlso lvw文件列表.Sorting <> SortOrder.None Then
            ' 如果当前列已经是排序列，则切换排序方式
            If lvw文件列表.Sorting = SortOrder.Ascending Then
                lvw文件列表.Sorting = SortOrder.Descending
            Else
                lvw文件列表.Sorting = SortOrder.Ascending
            End If
        Else
            ' 如果当前列不是排序列，则按默认升序排序
            lvw文件列表.Sorting = SortOrder.Ascending
        End If

        ' 设置当前排序列索引
        lvw文件列表.Sorting = columnIndex

        ''根据排序方式设置列头图像()
        'if lvw文件列表.Sorting = SortOrder.Ascending Then
        '    lvw文件列表.Columns(columnIndex).ImageKey = ""
        'Elseif lvw文件列表.Sorting = SortOrder.Descending Then
        '    lvw文件列表.Columns(columnIndex).ImageKey = ""
        'Else
        '    lvw文件列表.Columns(columnIndex).ImageKey = Nothing
        'End if

        ' 执行排序操作
        lvw文件列表.Sort()
    End Sub

    '键盘上下键移动
    Private Sub lvw文件列表_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvw文件列表.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                If e.Control Then
                    ListViewUp(lvw文件列表)
                    e.Handled = True
                End If
            Case Keys.Down
                If e.Control Then
                    ListViewDown(lvw文件列表)
                    e.Handled = True
                End If
            Case Keys.Delete
                ListViewDel(lvw文件列表)
        End Select
    End Sub

    '预览
    Private Sub btn预览_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn预览.Click
        Dim oListViewItem As ListViewItem
        Dim intAssNum As Integer
        Dim intPartNum As Integer
        Dim oStockNumPartName As StockNumPartName = Nothing
        Dim strBasicStockNum As String

        intAssNum = 1
        intPartNum = 1
        strBasicStockNum = txt基准图号.Text

        If (IsNumeric(txt零件变量.Text) = False) Or (IsNumeric(cmb部件变量.Text) = False) Then
            MsgBox("变量非数字！", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "错误")
            Exit Sub
        End If

        Dim intPartChange As Integer = Val(txt零件变量.Text)
        Dim intAmsChange As Integer = Val(cmb部件变量.Text)

        For i = 0 To lvw文件列表.Items.Count - 1
            oListViewItem = lvw文件列表.Items(i)
            If oListViewItem.SubItems(1).Text = IPT Then
                oStockNumPartName.图号 = Strings.Left(strBasicStockNum, Strings.Len(strBasicStockNum) - Strings.Len((intPartNum * intPartChange).ToString)) & intPartNum * intPartChange
                oStockNumPartName.零件名称 = GetStockNumPartName(oListViewItem.Text).零件名称
                oListViewItem.SubItems(2).Text = oStockNumPartName.图号 & oStockNumPartName.零件名称
                intPartNum = intPartNum + 1
            ElseIf oListViewItem.SubItems(1).Text = IAM Then
                oStockNumPartName.图号 = Strings.Left(strBasicStockNum, Strings.Len(strBasicStockNum) - Strings.Len((intAssNum * intAmsChange).ToString)) & intAssNum * intAmsChange
                oStockNumPartName.零件名称 = GetStockNumPartName(oListViewItem.Text).零件名称
                oListViewItem.SubItems(2).Text = oStockNumPartName.图号 & oStockNumPartName.零件名称
                intAssNum = intAssNum + 1
            End If
        Next

    End Sub

    Private Sub frmAutoPartNumber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument

        LoadAssBOM(oInventorAssemblyDocument, lvw文件列表)

        Dim toolTip As New ToolTip()
        toolTip.AutoPopDelay = 0
        toolTip.InitialDelay = 0
        toolTip.ReshowDelay = 500
        toolTip.SetToolTip(btn确定新文件名, "确定新文件名")
        toolTip.SetToolTip(chk备份文件, "将原文件扩展名变更为 old 文件")

        btn确定新文件名.Image = My.Resources.确定16.ToBitmap
    End Sub

    '载入数据函数
    Private Sub LoadAssBOM(ByVal oInventorAssemblyDocument As Inventor.AssemblyDocument, ByVal oListView As ListView)
        On Error Resume Next

        '基于bom结构化数据，可跳过参考的文件
        ' Set a reference to the BOM

        Dim oBOM As BOM

        Dim strInventorAssemblyFullFileName As String

        strInventorAssemblyFullFileName = oInventorAssemblyDocument.FullDocumentName

        Dim oStockNumPartName As StockNumPartName
        oStockNumPartName = GetStockNumPartName(strInventorAssemblyFullFileName)
        txt基准图号.Text = oStockNumPartName.图号

        oBOM = oInventorAssemblyDocument.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True

        'Set a reference to the "Structured" BOMView

        oListView.Items.Clear()

        oListView.BeginUpdate()

        '获取结构化的bom页面
        For Each oBOMView As BOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then

                For i = 1 To oBOMView.BOMRows.Count
                    ' Get the current row.
                    Dim oBOMRow As BOMRow
                    oBOMRow = oBOMView.BOMRows.Item(i)

                    Dim strFullFileName As String

                    strFullFileName = oBOMRow.ReferencedFileDescriptor.FullFileName

                    '测试文件
                    If InStr(strFullFileName, ContentCenterFiles) > 0 Then         '跳过零件库文件

                    Else
                        Debug.Print(strFullFileName)
                        Dim oFileNameInfo As FileNameInfo
                        oFileNameInfo = GetFileNameInfo(strFullFileName)

                        Dim oListViewItem As ListViewItem
                        oListViewItem = oListView.Items.Add(oFileNameInfo.OnlyName)
                        With oListViewItem
                            .SubItems.Add(oFileNameInfo.ExtensionName)
                            .SubItems.Add("")
                            .SubItems.Add(oFileNameInfo.Folder)
                        End With
                    End If

                Next
            End If
        Next

        oListView.EndUpdate()

    End Sub

    '移出项
    Private Sub ListViewDel(ByVal oListView As ListView)
        For i As Integer = oListView.SelectedIndices.Count - 1 To 0 Step -1
            oListView.Items.RemoveAt(oListView.SelectedIndices(i))
        Next
    End Sub

    Private Sub btn移出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn移出.Click
        ListViewDel(lvw文件列表)
    End Sub

    '重载数据
    Private Sub btn重载_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn重载.Click
        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument

        LoadAssBOM(oInventorAssemblyDocument, lvw文件列表)

    End Sub

    Private Sub btn确定新文件名_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn确定新文件名.Click
        If lvw文件列表.SelectedIndices.Count > 0 Then
            Dim index As Integer = lvw文件列表.SelectedIndices(0)
            lvw文件列表.Items(index).SubItems(2).Text = txt新文件名.Text
        End If

    End Sub

    Private Sub lvw文件列表_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvw文件列表.SelectedIndexChanged
        Try
            If lvw文件列表.SelectedIndices.Count > 0 Then
                Dim index As Integer = lvw文件列表.SelectedIndices(0)  '选中行的下一行索引
                If index < lvw文件列表.Items.Count Then
                    txt新文件名.Text = lvw文件列表.Items(index).SubItems(2).Text
                    Dim item As ListViewItem = lvw文件列表.Items(index)
                    Dim strOldFullFileName As String   '旧文件全名
                    strOldFullFileName = item.SubItems(3).Text & "\" & item.Text & item.SubItems(1).Text

                    Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
                    oInventorAssemblyDocument = ThisApplication.ActiveDocument

                    Dim strInventorAssemblyFullFileName As String
                    strInventorAssemblyFullFileName = oInventorAssemblyDocument.FullFileName

                    ' 获取装配定义
                    Dim oAssemblyComponentDefinition As AssemblyComponentDefinition
                    oAssemblyComponentDefinition = oInventorAssemblyDocument.ComponentDefinition

                    ' 获取装配子集
                    Dim oComponentOccurrences As ComponentOccurrences
                    oComponentOccurrences = oAssemblyComponentDefinition.Occurrences

                    '指定要选择的文件()
                    'Dim oDoc As Document
                    'oDoc = ThisApplication.Documents.ItemByName(OldFullFileName)

                    '遍历
                    For Each oComponentOccurrence As ComponentOccurrence In oComponentOccurrences
                        If oComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName = strOldFullFileName Then
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

    Private Sub lvw文件列表_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvw文件列表.DragDrop
        Dim oDraggedItem As ListViewItem
        oDraggedItem = e.Data.GetData(System.Windows.Forms.DataFormats.Serializable)

        Dim ptScreen As Drawing.Point = New Drawing.Point(e.X, e.Y)
        Dim pt As Drawing.Point = lvw文件列表.PointToClient(ptScreen)
        Dim TargetItem As ListViewItem
        TargetItem = lvw文件列表.GetItemAt(pt.X, pt.Y) '拖动的项将放置于该项之前
        If (TargetItem Is Nothing) Then
            Exit Sub
        End If
        lvw文件列表.Items.Insert(TargetItem.Index, oDraggedItem.Clone())
        lvw文件列表.Items.Remove(oDraggedItem)
    End Sub

    Private Sub lvwFileList_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvw文件列表.DragEnter
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub lvw文件列表_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvw文件列表.DragLeave
        lvw文件列表.InsertionMark.Index = -1
    End Sub

    Private Sub lvw文件列表_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvw文件列表.DragOver
        Dim ptScreen As Drawing.Point = New Drawing.Point(e.X, e.Y)
        Dim pt As Drawing.Point = lvw文件列表.PointToClient(ptScreen)

        Dim index As Integer = lvw文件列表.InsertionMark.NearestIndex(pt)
        lvw文件列表.InsertionMark.Index = index
    End Sub

    Private Sub lvw文件列表_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles lvw文件列表.ItemDrag
        lvw文件列表.InsertionMark.Color = System.Drawing.Color.ForestGreen
        lvw文件列表.DoDragDrop(e.Item, DragDropEffects.Move)

    End Sub

    Private Sub txt零件变量_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt零件变量.TextChanged
        If IsNumeric(txt零件变量.Text) = False Then
            MsgBox("非数字！", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "错误")
        End If
    End Sub

    '移除
    Private Sub tsmi移出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi移出.Click
        ListViewDel(lvw文件列表)
    End Sub

    '筛选移除
    Private Sub tsmi筛选移出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi筛选移出.Click
        Dim strFilter As String

        Me.TopMost = False

        Dim frmInputBox As New frmInputBox
999:
        With frmInputBox
            .txt输入.Text = ""
            .Text = "筛选文件"
            .lbl描述.Text = "输入需要移除的筛选字段，将移除包含字段的零部件。"
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With

        If (frmInputBox.DialogResult = Windows.Forms.DialogResult.OK) And (frmInputBox.txt输入.Text <> "") Then
            strFilter = frmInputBox.txt输入.Text
        Else
            Me.TopMost = True
            Exit Sub
        End If

        For Each oListViewItem As ListViewItem In lvw文件列表.Items
            Dim strInventorFullFileName As String  '工程图全文件名
            strInventorFullFileName = oListViewItem.Text

            Dim strInventorDrawingFileOnlyName As String
            strInventorDrawingFileOnlyName = GetFileNameInfo(strInventorFullFileName).OnlyName

            If InStr(strInventorDrawingFileOnlyName, strFilter) <> 0 Then
                oListViewItem.Remove()
            End If

        Next
        Me.TopMost = True
    End Sub

    '筛选保留
    Private Sub tsmi筛选保留_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi筛选保留.Click
        Dim strFilter As String
        Me.TopMost = False
        Dim frmInputBox As New frmInputBox
999:
        With frmInputBox
            .txt输入.Text = ""
            .Text = "筛选文件"
            .lbl描述.Text = "输入需要保留的筛选字段，将保留包含字段的工程图。"
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With

        If (frmInputBox.DialogResult = Windows.Forms.DialogResult.OK) And (frmInputBox.txt输入.Text <> "") Then
            strFilter = frmInputBox.txt输入.Text
        Else
            Me.TopMost = True
            Exit Sub
        End If

        For Each oListViewItem As ListViewItem In lvw文件列表.Items
            Dim strInventorFullFileName As String  '工程图全文件名
            strInventorFullFileName = oListViewItem.Text

            Dim strInventorDrawingFileOnlyName As String
            strInventorDrawingFileOnlyName = GetFileNameInfo(strInventorFullFileName).OnlyName

            If InStr(strInventorDrawingFileOnlyName, strFilter) = 0 Then
                oListViewItem.Remove()
            End If

        Next

        Me.TopMost = True
    End Sub
End Class