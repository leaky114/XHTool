Imports System.Windows.Forms
Imports Inventor
Imports System
Imports System.IO
Imports Microsoft
Imports Microsoft.VisualBasic
Imports System.Collections.ObjectModel

Public Class AutoPartNumberDialog

    '开始编号
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Dim OldFullFileName As String   '旧文件全名
        Dim NewFullFileName As String   '新文件全名
        Dim LVI As ListViewItem

        Try

            OK_Button.Enabled = False

            For i = 0 To ListView1.Items.Count - 1
                LVI = ListView1.Items(i)

                OldFullFileName = LVI.SubItems(3).Text & "\" & LVI.Text & LVI.SubItems(1).Text

                If LVI.SubItems(2).Text = "" Then
                    GoTo 999
                End If
                NewFullFileName = LVI.SubItems(3).Text & "\" & LVI.SubItems(2).Text & LVI.SubItems(1).Text

                '打开旧文件,不显示
                Dim OldInventorDocument As Inventor.Document
                OldInventorDocument = ThisApplication.Documents.Open(OldFullFileName, False)

                '另存为新文件
                OldInventorDocument.SaveAs(NewFullFileName, False)

                '关闭旧图
                OldInventorDocument.Close()

                '后台打开文件，修改ipro
                Dim NewInventorDocument As Inventor.Document
                NewInventorDocument = ThisApplication.Documents.Open(NewFullFileName, False)  '打开文件，不显示
                SetDocumentIpropertyFromFileName(NewInventorDocument, True) '设置Iproperty，打开文件后需关闭

                Dim oCO As Inventor.ComponentOccurrences
                oCO = ThisApplication.ActiveDocument.ComponentDefinition.Occurrences

                '全部替换为新文件
                For Each ooCO As ComponentOccurrence In oCO
                    If ooCO.ReferencedDocumentDescriptor.FullDocumentName = OldFullFileName Then
                        ooCO.Replace(NewFullFileName, True)
                        Exit For
                    End If
                Next

                Dim OldIdwFullFileName As String
                OldIdwFullFileName = GetNewExtensionFileName(OldFullFileName, ".idw")   '旧工程图
                If IsFileExsts(OldIdwFullFileName) = True Then
                    Dim NewIdwFullFileName As String
                    NewIdwFullFileName = GetNewExtensionFileName(NewFullFileName, ".idw")   '新工程图
                    FileSystem.FileCopy(OldIdwFullFileName, NewIdwFullFileName)             '复制为新工程图

                    Dim oInventorDrawingDocument As Inventor.DrawingDocument
                    oInventorDrawingDocument = ThisApplication.Documents.Open(NewIdwFullFileName, False)  '打开文件，不显示
                    oInventorDrawingDocument.ReferencedDocumentDescriptors(1).ReferencedFileDescriptor.ReplaceReference(NewFullFileName)
                    oInventorDrawingDocument.Save2()
                    oInventorDrawingDocument.Close()

                End If

                ThisApplication.ActiveDocument.Update()

999:
            Next

            MsgBox("自动命名图号完成", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "自动命名图号")
            OK_Button.Enabled = True

        Catch ex As Exception
            OK_Button.Enabled = True
            MsgBox(ex.Message)
        End Try

    End Sub

    '关闭
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        ListView1.Items.Clear()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    '上移
    Private Sub ListViewUp(ByVal ListView As ListView)
        Dim index As Integer
        Dim tmp As ListViewItem
        If ListView.SelectedItems.Count < 1 Then
            Exit Sub
        End If
        index = ListView.SelectedIndices(0)
        If index = 0 Then
            Exit Sub
        End If
        tmp = ListView.Items(index)
        ListView.Items.Insert(index - 1, tmp.Clone())
        ListView.Items.RemoveAt(index + 1)
        ListView.Items.Item(index - 1).Selected = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles moveup.Click
        ListViewUp(ListView1)
    End Sub

    '下移
    Private Sub ListViewDown(ByVal ListView As ListView)
        Dim index As Integer
        Dim tmp As ListViewItem
        If ListView.SelectedItems.Count < 1 Then
            Exit Sub
        End If
        index = ListView.SelectedIndices(0)
        If index = ListView.Items.Count - 1 Then
            Exit Sub
        End If
        tmp = ListView.Items(index)
        ListView.Items.Insert(index + 2, tmp.Clone())
        ListView.Items.RemoveAt(index)
        ListView.Items.Item(index + 1).Selected = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles movedown.Click
        ListViewDown(ListView1)
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
    Private Sub ListView1_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListView1.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                If e.Control Then
                    ListViewUp(ListView1)
                    e.Handled = True
                End If
            Case Keys.Down
                If e.Control Then
                    ListViewDown(ListView1)
                    e.Handled = True
                End If
            Case Keys.Delete
                ListViewDel(ListView1)
        End Select
    End Sub

    '预览
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles review.Click
        Dim LVI As ListViewItem
        Dim AssNum As Integer
        Dim PartNum As Integer
        Dim StockNumPartName As StockNumPartName = Nothing
        Dim BasicStockNumn As String

        AssNum = 1
        PartNum = 1
        BasicStockNumn = TextBox1.Text

        For i = 0 To ListView1.Items.Count - 1
            LVI = ListView1.Items(i)
            If LVI.SubItems(1).Text = ".ipt" Then
                StockNumPartName.StockNum = Strings.Left(BasicStockNumn, Strings.Len(BasicStockNumn) - Strings.Len((PartNum * Val(TextBox3.Text)).ToString)) & PartNum * Val(TextBox3.Text)
                StockNumPartName.PartName = LVI.Text
                LVI.SubItems(2).Text = StockNumPartName.StockNum & StockNumPartName.PartName
                PartNum = PartNum + 1
            ElseIf LVI.SubItems(1).Text = ".iam" Then
                StockNumPartName.StockNum = Strings.Left(BasicStockNumn, Strings.Len(BasicStockNumn) - Strings.Len((AssNum * Val(ComboBox1.Text)).ToString)) & AssNum * Val(ComboBox1.Text)
                StockNumPartName.PartName = LVI.Text
                LVI.SubItems(2).Text = StockNumPartName.StockNum & StockNumPartName.PartName
                AssNum = AssNum + 1
            End If
        Next
    End Sub

    Private Sub AutoPartNumber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument
        LoadAssBOM(oInventorAssemblyDocument, ListView1)
    End Sub

    '载入数据函数
    Private Sub LoadAssBOM(ByVal oInventorAssemblyDocument As Inventor.AssemblyDocument, ByVal LV As ListView)

        '基于bom结构化数据，可跳过参考的文件
        ' Set a reference to the BOM

        Dim oBOM As BOM

        Dim AssFullFileName As String

        AssFullFileName = oInventorAssemblyDocument.FullFileName

        Dim oStockNumPartName As StockNumPartName
        oStockNumPartName = GetStockNumPartName(AssFullFileName)
        TextBox1.Text = oStockNumPartName.StockNum

        oBOM = oInventorAssemblyDocument.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True

        'Set a reference to the "Structured" BOMView

        LV.Items.Clear()

        '获取结构化的bom页面
        For Each oBOMView As BOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then

                For i = 1 To oBOMView.BOMRows.Count
                    ' Get the current row.
                    Dim oRow As BOMRow
                    oRow = oBOMView.BOMRows.Item(i)

                    Dim FullFileName As String

                    FullFileName = oRow.ReferencedFileDescriptor.FullFileName

                    '测试文件
                    If InStr(FullFileName, ContentCenterFiles) > 0 Then         '跳过零件库文件

                    Else
                        Debug.Print(FullFileName)
                        Dim FNI As FileNameInfo
                        FNI = GetFileNameInfo(FullFileName)

                        Dim LVI As ListViewItem
                        LVI = LV.Items.Add(FNI.ONlyName)
                        LVI.SubItems.Add(FNI.ExtensionName)
                        LVI.SubItems.Add("")
                        LVI.SubItems.Add(FNI.Folder)
                    End If

                Next
            End If
        Next

    End Sub

    '移出项
    Private Sub ListViewDel(ByVal ListView As ListView)
        For i As Integer = ListView.SelectedIndices.Count - 1 To 0 Step -1
            ListView.Items.RemoveAt(ListView.SelectedIndices(i))
        Next
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles moveout.Click
        ListViewDel(ListView1)
    End Sub

    '重载数据
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reload.Click
        Dim AsmDoc As AssemblyDocument
        AsmDoc = ThisApplication.ActiveDocument
        LoadAssBOM(AsmDoc, ListView1)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If ListView1.SelectedIndices.Count > 0 Then
            Dim index As Integer = ListView1.SelectedIndices(0)
            ListView1.Items(index).SubItems(2).Text = TextBox2.Text
        End If

    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            If ListView1.SelectedIndices.Count > 0 Then
                Dim index As Integer = ListView1.SelectedIndices(0)  '选中行的下一行索引
                If index < ListView1.Items.Count Then
                    TextBox2.Text = ListView1.Items(index).SubItems(2).Text
                    Dim item As ListViewItem = ListView1.Items(index)
                    Dim OldFullFileName As String   '旧文件全名
                    OldFullFileName = item.SubItems(3).Text & "\" & item.Text & item.SubItems(1).Text

                    Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
                    Dim AssFullFileName As String

                    oInventorAssemblyDocument = ThisApplication.ActiveDocument
                    AssFullFileName = oInventorAssemblyDocument.FullFileName

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
                        If oComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName = OldFullFileName Then
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

    Private Sub ListView1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragDrop
        Dim draggedItem As ListViewItem
        draggedItem = e.Data.GetData(System.Windows.Forms.DataFormats.Serializable)

        Dim ptScreen As Drawing.Point = New Drawing.Point(e.X, e.Y)
        Dim pt As Drawing.Point = ListView1.PointToClient(ptScreen)
        Dim TargetItem As ListViewItem
        TargetItem = ListView1.GetItemAt(pt.X, pt.Y) '拖动的项将放置于该项之前
        If (TargetItem Is Nothing) Then
            Exit Sub
        End If
        ListView1.Items.Insert(TargetItem.Index, draggedItem.Clone())
        ListView1.Items.Remove(draggedItem)
    End Sub

    Private Sub ListView1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragEnter
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub ListView1_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DragLeave
        ListView1.InsertionMark.Index = -1
    End Sub

    Private Sub ListView1_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragOver
        Dim ptScreen As Drawing.Point = New Drawing.Point(e.X, e.Y)
        Dim pt As Drawing.Point = ListView1.PointToClient(ptScreen)

        Dim index As Integer = ListView1.InsertionMark.NearestIndex(pt)
        ListView1.InsertionMark.Index = index
    End Sub

    Private Sub ListView1_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles ListView1.ItemDrag
        ListView1.InsertionMark.Color = System.Drawing.Color.ForestGreen
        ListView1.DoDragDrop(e.Item, DragDropEffects.Move)

    End Sub

End Class