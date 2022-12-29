Imports System.Windows.Forms
Imports Inventor
Imports System
Imports System.IO
Imports Microsoft
Imports Microsoft.VisualBasic
Imports System.Collections.ObjectModel

Public Class frmAutoPartNumber

    '开始编号
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click

        Dim strOldFullFileName As String   '旧文件全名
        Dim strNewFullFileName As String   '新文件全名
        Dim oListViewItem As ListViewItem

        Try

            btnStart.Enabled = False
            'ThisApplication.Cursor  = Cursors.WaitCursor

            For i = 0 To lvwFileListView.Items.Count - 1
                oListViewItem = lvwFileListView.Items(i)

                strOldFullFileName = oListViewItem.SubItems(3).Text & "\" & oListViewItem.Text & oListViewItem.SubItems(1).Text

                If oListViewItem.SubItems(2).Text = "" Then
                    GoTo 999
                End If
                strNewFullFileName = oListViewItem.SubItems(3).Text & "\" & oListViewItem.SubItems(2).Text & oListViewItem.SubItems(1).Text

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
                SetDocumentIpropertyFromFileName(oNewInventorDocument, True) '设置Iproperty，打开文件后需关闭

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
                strOldDrawingFullFileName = GetNewExtensionFileName(strOldFullFileName, ".idw")   '旧工程图

                If IsFileExsts(strOldDrawingFullFileName) = True Then

                    Dim strNewDrawingFullFileName As String

                    strNewDrawingFullFileName = GetNewExtensionFileName(strNewFullFileName, ".idw")   '新工程图
                    FileSystem.FileCopy(strOldDrawingFullFileName, strNewDrawingFullFileName)             '复制为新工程图

                    Dim oInventorDrawingDocument As Inventor.DrawingDocument
                    oInventorDrawingDocument = ThisApplication.Documents.Open(strNewDrawingFullFileName, False)  '打开文件，不显示

                    ReplaceFileReference(oInventorDrawingDocument, strOldFullFileName, strNewFullFileName)

                    'With oInventorDrawingDocument
                    '    .ReferencedDocumentDescriptors(1).ReferencedFileDescriptor.ReplaceReference(strNewFullFileName)
                    '    .Save2()
                    '    .Close()
                    'End With

                End If

                ThisApplication.ActiveDocument.Update()

999:
            Next

            Me.TopMost = False
            SetStatusBarText("自动命名图号完成！")
            MsgBox("自动命名图号完成", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "自动命名图号")
            btnStart.Enabled = True
            'ThisApplication.Cursor  = Cursors.Default

        Catch ex As Exception
            btnStart.Enabled = True
            MsgBox(ex.Message)
        End Try

    End Sub

    '关闭
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        lvwFileListView.Items.Clear()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    '上移
    Private Sub ListViewUp(ByVal oListView As ListView)
        Dim index As Integer
        Dim oListViewItem As ListViewItem
        If oListView.SelectedItems.Count < 1 Then
            Exit Sub
        End If
        index = oListView.SelectedIndices(0)
        If index = 0 Then
            Exit Sub
        End If
        oListViewItem = oListView.Items(index)
        oListView.Items.Insert(index - 1, oListViewItem.Clone())
        oListView.Items.RemoveAt(index + 1)
        oListView.Items.Item(index - 1).Selected = True
    End Sub

    Private Sub btnMoveUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveUp.Click
        ListViewUp(lvwFileListView)
    End Sub

    '下移
    Private Sub ListViewDown(ByVal oListView As ListView)
        Dim index As Integer
        Dim oListViewItem As ListViewItem
        If oListView.SelectedItems.Count < 1 Then
            Exit Sub
        End If
        index = oListView.SelectedIndices(0)
        If index = oListView.Items.Count - 1 Then
            Exit Sub
        End If
        oListViewItem = oListView.Items(index)
        oListView.Items.Insert(index + 2, oListViewItem.Clone())
        oListView.Items.RemoveAt(index)
        oListView.Items.Item(index + 1).Selected = True
    End Sub

    Private Sub btnMoveDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveDown.Click
        ListViewDown(lvwFileListView)
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

    'Private Sub ListView1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragDrop
    '    '判断是否选择拖放的项，

    '    If ListView1.SelectedItems.Count = 0 Then
    '        Exit Sub
    '    End If

    '    '定义项的坐标点
    '    Dim cp As System.Drawing.Point
    '    cp = ListView1.PointToClient(New System.Drawing.Point(e.X, e.Y))
    '    Dim dragToItem As ListViewItem
    '    dragToItem = ListView1.GetItemAt(cp.X, cp.Y)

    '    If dragToItem Is Nothing Then
    '        Exit Sub
    '    End If

    '    Dim dragIndex As Integer = dragToItem.Index
    '    Dim sel As ListViewItem()
    '    ReDim sel(ListView1.SelectedItems.Count)

    '    For i = 0 To ListView1.SelectedItems.Count
    '        sel(i) = ListView1.SelectedItems(i)
    '    Next

    '    For i = 0 To sel.GetLength(0)
    '        Dim dragItem As ListViewItem
    '        dragItem = sel(i)
    '        Dim itemIndex As Integer = dragIndex

    '        If (itemIndex = dragItem.Index) Then
    '            Exit Sub
    '        End If

    '        If (dragItem.Index < itemIndex) Then
    '            Exit Sub
    '        Else
    '            itemIndex = dragIndex + i
    '            Dim insertItem As ListViewItem = dragItem.Clone()
    '            ListView1.Items.Insert(itemIndex, insertItem)
    '            ListView1.Items.Remove(dragItem)
    '        End If

    '    Next

    'End Sub

    'Private Sub ListView1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragEnter
    '    For i = 0 To e.Data.GetFormats().Length - 1
    '        If (e.Data.GetFormats.Equals("System.Windows.Forms.ListView+SelectedListViewItemCollection")) Then
    '            e.Effect = DragDropEffects.Move
    '        End If
    '    Next
    'End Sub

    'Private Sub ListView1_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles ListView1.ItemDrag
    '    ListView1.DoDragDrop(ListView1.SelectedItems, DragDropEffects.Move)
    'End Sub

    '键盘上下键移动
    Private Sub lvwFileListView_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvwFileListView.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                If e.Control Then
                    ListViewUp(lvwFileListView)
                    e.Handled = True
                End If
            Case Keys.Down
                If e.Control Then
                    ListViewDown(lvwFileListView)
                    e.Handled = True
                End If
            Case Keys.Delete
                ListViewDel(lvwFileListView)
        End Select
    End Sub

    '预览
    Private Sub btnReview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReview.Click
        Dim oListViewItem As ListViewItem
        Dim intAssNum As Integer
        Dim intPartNum As Integer
        Dim oStockNumPartName As StockNumPartName = Nothing
        Dim strBasicStockNum As String

        intAssNum = 1
        intPartNum = 1
        strBasicStockNum = txtBasicNum.Text

        If (IsNumeric(txtPartChange.Text) = False) Or (IsNumeric(cmbAmsChange.Text) = False) Then
            MsgBox("变量非数字！", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "错误")
            Exit Sub
        End If

        Dim intPartChange As Integer = Val(txtPartChange.Text)
        Dim intAmsChange As Integer = Val(cmbAmsChange.Text)

        For i = 0 To lvwFileListView.Items.Count - 1
            oListViewItem = lvwFileListView.Items(i)
            If oListViewItem.SubItems(1).Text = ".ipt" Then
                oStockNumPartName.StockNum = Strings.Left(strBasicStockNum, Strings.Len(strBasicStockNum) - Strings.Len((intPartNum * intPartChange).ToString)) & intPartNum * intPartChange
                oStockNumPartName.PartName = oListViewItem.Text
                oListViewItem.SubItems(2).Text = oStockNumPartName.StockNum & oStockNumPartName.PartName
                intPartNum = intPartNum + 1
            ElseIf oListViewItem.SubItems(1).Text = ".iam" Then
                oStockNumPartName.StockNum = Strings.Left(strBasicStockNum, Strings.Len(strBasicStockNum) - Strings.Len((intAssNum * intAmsChange).ToString)) & intAssNum * intAmsChange
                oStockNumPartName.PartName = oListViewItem.Text
                oListViewItem.SubItems(2).Text = oStockNumPartName.StockNum & oStockNumPartName.PartName
                intAssNum = intAssNum + 1
            End If
        Next
    End Sub

    Private Sub frmAutoPartNumber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument
        LoadAssBOM(oInventorAssemblyDocument, lvwFileListView)
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
        txtBasicNum.Text = oStockNumPartName.StockNum

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

    Private Sub btnMoveOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveOut.Click
        ListViewDel(lvwFileListView)
    End Sub

    '重载数据
    Private Sub btnReLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReLoad.Click
        Dim oAssemblyDocument As AssemblyDocument
        oAssemblyDocument = ThisApplication.ActiveDocument
        LoadAssBOM(oAssemblyDocument, lvwFileListView)
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If lvwFileListView.SelectedIndices.Count > 0 Then
            Dim index As Integer = lvwFileListView.SelectedIndices(0)
            lvwFileListView.Items(index).SubItems(2).Text = txtNewFileName.Text
        End If

    End Sub

    Private Sub lvwFileListView_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwFileListView.SelectedIndexChanged
        Try
            If lvwFileListView.SelectedIndices.Count > 0 Then
                Dim index As Integer = lvwFileListView.SelectedIndices(0)  '选中行的下一行索引
                If index < lvwFileListView.Items.Count Then
                    txtNewFileName.Text = lvwFileListView.Items(index).SubItems(2).Text
                    Dim item As ListViewItem = lvwFileListView.Items(index)
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

    Private Sub lvwFileListView_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvwFileListView.DragDrop
        Dim oDraggedItem As ListViewItem
        oDraggedItem = e.Data.GetData(System.Windows.Forms.DataFormats.Serializable)

        Dim ptScreen As Drawing.Point = New Drawing.Point(e.X, e.Y)
        Dim pt As Drawing.Point = lvwFileListView.PointToClient(ptScreen)
        Dim TargetItem As ListViewItem
        TargetItem = lvwFileListView.GetItemAt(pt.X, pt.Y) '拖动的项将放置于该项之前
        If (TargetItem Is Nothing) Then
            Exit Sub
        End If
        lvwFileListView.Items.Insert(TargetItem.Index, oDraggedItem.Clone())
        lvwFileListView.Items.Remove(oDraggedItem)
    End Sub

    Private Sub lvwFileList_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvwFileListView.DragEnter
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub lvwFileListView_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwFileListView.DragLeave
        lvwFileListView.InsertionMark.Index = -1
    End Sub

    Private Sub lvwFileListView_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvwFileListView.DragOver
        Dim ptScreen As Drawing.Point = New Drawing.Point(e.X, e.Y)
        Dim pt As Drawing.Point = lvwFileListView.PointToClient(ptScreen)

        Dim index As Integer = lvwFileListView.InsertionMark.NearestIndex(pt)
        lvwFileListView.InsertionMark.Index = index
    End Sub

    Private Sub lvwFileListView_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles lvwFileListView.ItemDrag
        lvwFileListView.InsertionMark.Color = System.Drawing.Color.ForestGreen
        lvwFileListView.DoDragDrop(e.Item, DragDropEffects.Move)

    End Sub

    Private Sub txtPartChange_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPartChange.TextChanged
        If IsNumeric(txtPartChange.Text) = False Then
            MsgBox("非数字！", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "错误")
        End If
    End Sub

End Class