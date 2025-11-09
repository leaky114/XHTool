Imports System.Windows.Forms
Imports Inventor
Imports Microsoft
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Text.RegularExpressions

Public Class FormAutoPartNumber


    Private currentSortColumn As Integer = -1
    Private sortOrder As SortOrder = SortOrder.None
    Private manualOrderMode As Boolean = False ' 标记手动排序模式
    ' 在类级别声明标志变量
    Private isHandlingTextChange As Boolean = False


    '开始编号
    Private Sub Btn开始_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn开始.Click
        Try

            btn开始.Enabled = False
            Me.TopMost = False

            ThisApplication.SilentOperation = True

            Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
            OInteractionEvents.Start()
            OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
            ThisApplication.UserInterfaceManager.DoEvents()

            str模型匹配检查标记 = 3

            For Each oListViewItem As ListViewItem In lvw文件列表.Items
                RenameWithLisViewItem(oListViewItem)
            Next

            For Each oListViewItem As ListViewItem In lvw文件列表.Items
                If oListViewItem.Text = "存在新文件" Then
                    RenameWithLisViewItem(oListViewItem)
                End If
            Next

            For i As Integer = lvw文件列表.Items.Count - 1 To 0 Step -1
                Dim oListViewItem As ListViewItem = lvw文件列表.Items(i)
                If oListViewItem.Text = "存在新文件" Then
                    RenameWithLisViewItem(oListViewItem)
                End If
            Next

            'Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
            'oInventorAssemblyDocument = ThisApplication.ActiveDocument
            'LoadBOM(oInventorAssemblyDocument, lvw文件列表)

            OInteractionEvents.Stop()

            btn开始.Enabled = True
            str模型匹配检查标记 = 1

            SetStatusBarText("自动命名图号完成！")
            MessageBox.Show("自动命名图号完成。", XHTool, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.TopMost = True

        Catch ex As Exception
            btn开始.Enabled = True
            str模型匹配检查标记 = 1
            Me.TopMost = True

        End Try

    End Sub

    ''' <summary>
    ''' 引入 olistviewitem 的数据重命名文件
    ''' </summary>
    ''' <param name="oListViewItem">Litsviewitem对象</param>
    Private Sub RenameWithLisViewItem(ByVal oListViewItem As ListViewItem)

        Dim strOldFullFileName As String   '旧文件全名
        Dim strNewFullFileName As String   '新文件全名

        Dim OldFileNameInfo As FileNameInfo
        Dim NewFileNameInfo As FileNameInfo


        OldFileNameInfo.Folder = oListViewItem.SubItems(4).Text
        OldFileNameInfo.FileName = oListViewItem.SubItems(1).Text & oListViewItem.SubItems(2).Text

        strOldFullFileName = IO.Path.Combine(OldFileNameInfo.Folder, OldFileNameInfo.FileName)

        SetStatusBarText(strOldFullFileName)

        If oListViewItem.SubItems(3).Text = "" Then
            Exit Sub
        End If

        NewFileNameInfo.Folder = oListViewItem.SubItems(4).Text
        NewFileNameInfo.FileName = oListViewItem.SubItems(3).Text & oListViewItem.SubItems(2).Text

        strNewFullFileName = IO.Path.Combine(NewFileNameInfo.Folder, NewFileNameInfo.FileName)

        '同名不跳过
        If strOldFullFileName = strNewFullFileName Then
            Exit Sub
        End If

        '旧文件不存在，跳过
        If IsFileExists(strOldFullFileName) = False Then
            Exit Sub
        End If

        '有新文件存在
        If IsFileExists(strNewFullFileName) = True Then
            'MessageBox.Show($"已存在文件：{NewFileNameInfo.FileName }。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error)
            oListViewItem.Text = "存在新文件"
            Exit Sub
        End If

        Dim oOldInventorDocument As Inventor.Document
        oOldInventorDocument = ThisApplication.Documents.ItemByName(strOldFullFileName)

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
            '判断是否是文件，有可能是焊接，跳过
            If oComponentOccurrence.ReferencedDocumentDescriptor Is Nothing Then

            Else
                If oComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName = strOldFullFileName Then
                    oComponentOccurrence.Replace(strNewFullFileName, True)
                    Exit For
                End If
            End If
        Next

        Dim strOldDrawingFullFileName As String
        strOldDrawingFullFileName = GetChangeExtension(strOldFullFileName, IDW)   '旧工程图

        If IsFileExists(strOldDrawingFullFileName) = True Then
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

        oListViewItem.Text = "完成"

    End Sub

    '关闭
    Private Sub Btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click, Me.Closing
        FormManager.CloseAndDisposeForm(Of FormAutoPartNumber)()
    End Sub

    Private Sub Btn上移_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn上移.Click
        ' 进入手动排序模式
        manualOrderMode = True

        lvw文件列表.BeginUpdate()

        ' 清除排序状态
        currentSortColumn = -1
        sortOrder = SortOrder.None
        lvw文件列表.ListViewItemSorter = Nothing
        UpdateSortIcon(lvw文件列表)


        ListViewUp(lvw文件列表)
        lvw文件列表.EndUpdate()
    End Sub

    Private Sub Btn下移_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn下移.Click

        ' 进入手动排序模式
        manualOrderMode = True

        lvw文件列表.BeginUpdate()

        ' 清除排序状态
        currentSortColumn = -1
        sortOrder = SortOrder.None
        lvw文件列表.ListViewItemSorter = Nothing
        UpdateSortIcon(lvw文件列表)


        ListViewDown(lvw文件列表)
        lvw文件列表.EndUpdate()
    End Sub

    ''排序
    'Private Sub Lvw文件列表_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvw文件列表.ColumnClick
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
    Private Sub ListView1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvw文件列表.ColumnClick

        ' 重置手动排序模式
        manualOrderMode = False

        ' 更新排序列和排序方向
        If e.Column = currentSortColumn Then
            sortOrder = If(sortOrder = SortOrder.Ascending, SortOrder.Descending, SortOrder.Ascending)
        Else
            currentSortColumn = e.Column
            sortOrder = SortOrder.Ascending
        End If

        ' 执行排序
        lvw文件列表.ListViewItemSorter = New ListViewColumnSorter(currentSortColumn, sortOrder)
        lvw文件列表.Sort()

        ' 更新列头图标
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

    '键盘上下键移动
    Private Sub Lvw文件列表_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvw文件列表.KeyDown
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
    Private Sub Btn预览_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn预览.Click

        ' 通用basename（从输入获取）
        Dim basenamePattern As String = txt基准图号.Text  ' 默认示例，实际应从文本框获取

        If basenamePattern = "" Then
            MessageBox.Show("请输入基准图号。", XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' 验证basename是否包含占位符
        If Not Regex.IsMatch(basenamePattern, "#{2,}") Then
            MessageBox.Show($"基准图号必须包含至少2个连续的#作为占位符。{vbCrLf }例如：ABC###；ABC.##.WG", XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        If (IsNumeric(txt零件初始值.Text) = False) Or (IsNumeric(txt零件增量.Text) = False) Or
            (IsNumeric(txt部件初始值.Text) = False) Or (IsNumeric(txt部件增量.Text) = False) Then
            MessageBox.Show("变量非数字。", XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        ' 定义计数器变量
        Dim iptCounter As Integer = Val(txt零件初始值.Text.ToString) ' .ipt文件计数器
        Dim iamCounter As Integer = Val(txt部件初始值.Text.ToString) ' .iam文件计数器

        Dim iptStep As Integer = Val(txt零件增量.Text.ToString) ' .ipt文件增量
        Dim iamStep As Integer = Val(txt部件增量.Text.ToString) ' .iam文件增量

        Dim ConnectionCharacter As String

        Select Case cmb连接符.Text
            Case "无"
                ConnectionCharacter = “”
            Case "空格"
                ConnectionCharacter = “ ”
            Case “短横线-”
                ConnectionCharacter = “-”
            Case "下划线_"
                ConnectionCharacter = “_”
            Case Else
                ConnectionCharacter = cmb连接符.Text
        End Select


        If chk部件初始值.Checked = False Then     '不区分iam 和 ipt
            ' 遍历ListView所有项
            For Each oListViewItem As ListViewItem In lvw文件列表.Items
                Dim originalName As String = oListViewItem.SubItems(1).Text
                Dim parth As String = oListViewItem.SubItems(3).Text

                Dim partname As String = GetStockNumPartName(IO.Path.Combine(parth, originalName)).零件名称

                Dim extension As String = oListViewItem.SubItems(2).Text
                Dim currentNumber As Integer

                ' 根据扩展名确定计数规则
                Select Case extension
                    Case IPT, IAM
                        currentNumber = iptCounter
                        iptCounter += iptStep

                        'Case IAM
                        '    currentNumber = iamCounter
                        '    iamCounter += iamStep

                    Case Else
                        ' 跳过不支持的文件类型
                        Continue For
                End Select

                ' 生成新文件名
                Dim strNewFileName As String
                Dim strNewNumber As String = currentNumber
                Dim strNewName As String = partname

                strNewFileName = oListViewItem.SubItems(3).Text
                If strNewFileName <> "" Then
                    If cmb连接符.Text = "无" Then
                        strNewNumber = Strings.Left(strNewFileName, Strings.Len(basenamePattern))
                        strNewName = Strings.Mid(strNewFileName, Strings.Len(basenamePattern) + 1)
                    Else
                        ' 使用 Split 按分隔符拆分（限制最多拆成2部分，防止名称中含下划线）

                        Dim parts() As String = strNewFileName.Split(New Char() {ConnectionCharacter}, 2)
                        If parts.Length >= 1 Then
                            strNewNumber = parts(0)  ' 第一部分始终是图号
                        End If

                        If parts.Length >= 2 Then
                            strNewName = parts(1)           ' 第二部分是名称
                        End If

                    End If
                End If

                    Select Case oListViewItem.Text
                    Case "锁定文件名"
                        strNewFileName = oListViewItem.SubItems(3).Text.ToString
                    Case "锁定图号"
                        strNewFileName = strNewFileName.Replace(strNewName, partname)

                    Case "锁定名称"
                        strNewFileName = GenerateFileName(basenamePattern, currentNumber, strNewName, extension, ConnectionCharacter)
                    Case Else
                        strNewFileName = GenerateFileName(basenamePattern, currentNumber, partname, extension, ConnectionCharacter)
                End Select

                ' 更新ListView项
                oListViewItem.SubItems(3).Text = strNewFileName
            Next


        Else
            ' 遍历ListView所有项
            For Each oListViewItem As ListViewItem In lvw文件列表.Items

                Dim originalName As String = oListViewItem.SubItems(1).Text
                Dim parth As String = oListViewItem.SubItems(3).Text
                Dim partname As String = GetStockNumPartName(IO.Path.Combine(parth, originalName)).零件名称
                Dim extension As String = oListViewItem.SubItems(2).Text
                Dim currentNumber As Integer


                ' 根据扩展名确定计数规则
                Select Case extension
                    Case IPT
                        currentNumber = iptCounter
                        iptCounter += iptStep

                    Case IAM
                        currentNumber = iamCounter
                        iamCounter += iamStep

                    Case Else
                        ' 跳过不支持的文件类型
                        Continue For
                End Select

                ' 生成新文件名
                Dim strNewFileName As String
                Dim strNewNumber As String = currentNumber
                Dim strNewName As String = partname

                strNewFileName = oListViewItem.SubItems(3).Text
                If strNewFileName <> "" Then
                    If cmb连接符.Text = "无" Then
                        strNewNumber = Strings.Left(strNewFileName, Strings.Len(basenamePattern))
                        strNewName = Strings.Mid(strNewFileName, Strings.Len(basenamePattern) + 1)
                    Else
                        ' 使用 Split 按分隔符拆分（限制最多拆成2部分，防止名称中含下划线）

                        Dim parts() As String = strNewFileName.Split(New Char() {ConnectionCharacter}, 2)
                        If parts.Length >= 1 Then
                            strNewNumber = parts(0)  ' 第一部分始终是图号
                        End If

                        If parts.Length >= 2 Then
                            strNewName = parts(1)           ' 第二部分是名称
                        End If

                    End If
                End If

                Select Case oListViewItem.Text
                    Case "锁定文件名"
                        strNewFileName = oListViewItem.SubItems(3).Text.ToString
                    Case "锁定图号"
                        strNewFileName = strNewFileName.Replace(strNewName, partname)

                    Case "锁定名称"
                        strNewFileName = GenerateFileName(basenamePattern, currentNumber, strNewName, extension, ConnectionCharacter)
                    Case Else
                        strNewFileName = GenerateFileName(basenamePattern, currentNumber, partname, extension, ConnectionCharacter)
                End Select

                ' 更新ListView项
                oListViewItem.SubItems(3).Text = strNewFileName

            Next

        End If

        lvw文件列表.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.ColumnContent)

    End Sub


    ' 生成文件名的方法
    Private Function GenerateFileName(ByVal pattern As String, ByVal number As Integer, ByVal partname As String, ByVal extension As String， ByVal ConnectionCharacter As String) As String
        ' 查找占位符
        Dim match As Match = Regex.Match(pattern, "#{2,}")
        If Not match.Success Then Return pattern & extension

        Dim placeholder As String = match.Value
        Dim placeholderStart As Integer = match.Index
        Dim placeholderLength As String = placeholder.Length

        ' 格式化数字部分
        Dim numberPart As String = number.ToString().PadLeft(placeholderLength, "0"c)

        ' 构建新文件名
        Dim newBaseName As String = pattern.Substring(0, placeholderStart) &
                                  numberPart &
                                  pattern.Substring(placeholderStart + placeholderLength)

        Return newBaseName & ConnectionCharacter & partname ' & extension
    End Function

    Private Sub FrmAutoPartNumber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48

        Dim toolTip As New ToolTip With {
            .AutoPopDelay = 0,
            .InitialDelay = 0,
            .ReshowDelay = 500
        }
        toolTip.SetToolTip(lbl基准图号, "基准图号需要包含至少2个连续的#作为占位符。如ABC-###，ABC.###.外购")
        toolTip.SetToolTip(btn确定新文件名, "确定新文件名。")
        toolTip.SetToolTip(chk备份文件, "将原文件扩展名变更为 old 文件。")
        toolTip.SetToolTip(chk部件初始值, "选中时将部件和零件分别处理。")

        btn确定新文件名.Image = My.Resources.确定16.ToBitmap

        txt零件初始值.Text = "1"
        txt零件增量.Text = "1"
        txt部件初始值.Text = "100"
        txt部件增量.Text = "100"

        cmb连接符.Text = "无"

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument

        LoadBOM(oInventorAssemblyDocument, lvw文件列表)

        SetWindowSizeAndCenter(Me)

    End Sub

    ''' <summary>
    ''' 载入数据函数
    ''' </summary>
    ''' <param name="oInventorAssemblyDocument">被载入的部件</param>
    ''' <param name="oListView">加载到ListView控件</param>
    ''' <remarks></remarks>
    Private Sub LoadBOM(ByVal oInventorAssemblyDocument As Inventor.AssemblyDocument, ByVal oListView As ListView)
        On Error Resume Next

        Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        OInteractionEvents.Start()
        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        ThisApplication.UserInterfaceManager.DoEvents()

        Dim strInventorAssemblyFullFileName As String

        strInventorAssemblyFullFileName = oInventorAssemblyDocument.File.FullFileName

        'Dim oStockNumPartName As StockNumPartName
        'oStockNumPartName = GetStockNumPartName(strInventorAssemblyFullFileName)
        'txt基准图号.Text = GenerateBasePattern（oStockNumPartName.图号）

        txt基准图号.Text = GenerateBasePattern（GetPropitem(oInventorAssemblyDocument, Map_DrawingNnumber)）

        oListView.Items.Clear()
        oListView.BeginUpdate()

        Dim oBOM As BOM
        oBOM = oInventorAssemblyDocument.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True

        '获取结构化的bom页面
        For Each oBOMView As BOMView In oBOM.BOMViews
            '基于bom结构化数据，可跳过参考的文件
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                For Each oBOMRow As BOMRow In oBOMView.BOMRows
                    Dim strDocumentFullFileName As String = oBOMRow.ComponentDefinitions(1).Document.File.FullFileName
                    '测试文件
                    Debug.Print(strDocumentFullFileName)

                    If InStr(strDocumentFullFileName, ContentCenterFiles) > 0 Then         '跳过零件库文件

                    Else
                        Dim oFileNameInfo As FileNameInfo
                        oFileNameInfo = GetFileNameInfo(strDocumentFullFileName)

                        Dim oListViewItem As ListViewItem
                        oListViewItem = oListView.Items.Add("就绪")
                        With oListViewItem
                            .SubItems.Add(oFileNameInfo.OnlyName)
                            .SubItems.Add(oFileNameInfo.ExtensionName)
                            .SubItems.Add("")
                            .SubItems.Add(oFileNameInfo.Folder)
                        End With
                    End If
                Next

                Exit For
            End If
        Next

        lvw文件列表.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.ColumnContent)

        oListView.EndUpdate()

        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        OInteractionEvents.Stop()
    End Sub


    ''' <summary>
    ''' 获取基准图号，将尾部的0变为#
    ''' </summary>
    ''' <param name="input"></param>
    ''' <returns></returns>
    Public Function GenerateBasePattern(input As String) As String
        ' 如果字符串为空或最右边字符不是0，直接返回原字符串
        If String.IsNullOrEmpty(input) OrElse input(input.Length - 1) <> "0"c Then
            Return input
        End If

        ' 从右向左查找连续0的起始位置
        Dim endIndex As Integer = input.Length - 1
        Dim startIndex As Integer = endIndex

        ' 向左遍历直到找到非0字符或到达字符串开头
        While startIndex >= 0 AndAlso input(startIndex) = "0"c
            startIndex -= 1
        End While

        ' 调整起始位置（因为循环结束时startIndex指向第一个非0字符或-1）
        startIndex += 1

        ' 计算连续0的数量
        Dim zeroCount As Integer = endIndex - startIndex + 1

        ' 替换连续0为相同数量的#
        If zeroCount > 0 Then
            Return input.Substring(0, startIndex) & New String("#"c, zeroCount) & input.Substring(endIndex + 1)
        End If

        Return input
    End Function

    '移出项
    Private Sub Btn移出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn移出.Click, tsmi移出.Click
        ListViewDel(lvw文件列表)
    End Sub

    '重载数据
    Private Sub Btn重载_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn重载.Click
        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument

        LoadBOM(oInventorAssemblyDocument, lvw文件列表)

    End Sub




    Private Sub Btn确定新文件名_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn确定新文件名.Click
        If lvw文件列表.SelectedIndices.Count > 0 Then
            Dim index As Integer = lvw文件列表.SelectedIndices(0)
            lvw文件列表.Items(index).SubItems(3).Text = txt新文件名.Text
        End If

    End Sub

    Private Sub Lvw文件列表_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvw文件列表.SelectedIndexChanged
        Try
            If lvw文件列表.SelectedIndices.Count > 0 Then
                Dim index As Integer = lvw文件列表.SelectedIndices(0)  '选中行的下一行索引
                If index < lvw文件列表.Items.Count Then

                    txt新文件名.Text = lvw文件列表.Items(index).SubItems(3).Text

                    Dim item As ListViewItem = lvw文件列表.Items(index)

                    Dim strDocumentFullFileName As String   '旧文件全名
                    strDocumentFullFileName = IO.Path.Combine(item.SubItems(4).Text, item.SubItems(1).Text & item.SubItems(2).Text)

                    SelectAssemblyComponentDefinition(strDocumentFullFileName)

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Lvw文件列表_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvw文件列表.DragDrop

        ' 进入手动排序模式
        manualOrderMode = True

        ' 清除排序状态
        currentSortColumn = -1
        sortOrder = SortOrder.None
        lvw文件列表.ListViewItemSorter = Nothing
        UpdateSortIcon(lvw文件列表)


        Dim oDraggedItem As ListViewItem
        oDraggedItem = e.Data.GetData(System.Windows.Forms.DataFormats.Serializable)

        Dim ptScreen As New Drawing.Point(e.X, e.Y)
        Dim pt As Drawing.Point = lvw文件列表.PointToClient(ptScreen)
        Dim TargetItem As ListViewItem
        TargetItem = lvw文件列表.GetItemAt(pt.X, pt.Y) '拖动的项将放置于该项之前
        If (TargetItem Is Nothing) Then
            Exit Sub
        End If
        lvw文件列表.Items.Insert(TargetItem.Index, oDraggedItem.Clone())
        lvw文件列表.Items.Remove(oDraggedItem)
    End Sub

    Private Sub LvwFileList_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvw文件列表.DragEnter
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub Lvw文件列表_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvw文件列表.DragLeave
        lvw文件列表.InsertionMark.Index = -1
    End Sub

    Private Sub Lvw文件列表_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvw文件列表.DragOver
        Dim ptScreen As New Drawing.Point(e.X, e.Y)
        Dim pt As Drawing.Point = lvw文件列表.PointToClient(ptScreen)

        Dim index As Integer = lvw文件列表.InsertionMark.NearestIndex(pt)
        lvw文件列表.InsertionMark.Index = index
    End Sub

    Private Sub Lvw文件列表_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles lvw文件列表.ItemDrag
        lvw文件列表.InsertionMark.Color = System.Drawing.Color.ForestGreen
        lvw文件列表.DoDragDrop(e.Item, DragDropEffects.Move)

    End Sub



    '筛选移除
    Private Sub Tsmi筛选移出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi筛选移出.Click
        Dim strFilter As String

        Dim frmInputBox As New FormInputBox

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

    End Sub

    '筛选保留
    Private Sub Tsmi筛选保留_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi筛选保留.Click
        Dim strFilter As String
        Dim frmInputBox As New FormInputBox

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

    End Sub

    Private Sub Txt新文件名_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt新文件名.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Btn确定新文件名_Click(sender, e)
        End If
    End Sub

    Private Sub txt零件初始值_TextChanged(sender As Object, e As KeyPressEventArgs) Handles txt零件初始值.KeyPress, txt零件增量.KeyPress,
        txt部件初始值.KeyPress, txt部件增量.KeyPress

        ' 允许控制键（退格、删除、Tab等）
        If Char.IsControl(e.KeyChar) Then
            Return
        End If

        ' 只允许输入数字
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True ' 阻止非数字输入
        End If

    End Sub

    ''' <summary>
    ''' 获取从尾部开始#的个数
    ''' </summary>
    ''' <param name="input"></param>
    ''' <returns></returns>
    Public Function CountTrailingHashes(input As String) As Integer
        If String.IsNullOrEmpty(input) Then Return 0

        Dim count As Integer = 0
        For i As Integer = input.Length - 1 To 0 Step -1
            If input(i) = "#"c Then
                count += 1
            Else
                Exit For
            End If
        Next

        Return count
    End Function

    Private Sub txt基准图号_TextChanged(sender As Object, e As EventArgs) Handles txt基准图号.TextChanged
        lbl井号数.Text = CountTrailingHashes(txt基准图号.Text.ToString)
    End Sub

    Private Sub tsmi解锁_Click(sender As Object, e As EventArgs) Handles tsmi解锁.Click
        If lvw文件列表.SelectedItems.Count > 0 Then
            ' 遍历 ListView 中的所有选择项。
            For Each oListViewItem As ListViewItem In lvw文件列表.SelectedItems
                oListViewItem.Text = "就绪"
            Next
        End If
    End Sub

    Private Sub 锁定文件名ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 锁定文件名ToolStripMenuItem.Click，
        锁定图号ToolStripMenuItem.Click， 锁定名称ToolStripMenuItem3.Click
        Dim strOperator As String

        Select Case sender.ToString
            Case "锁定文件名"
                strOperator = "锁定文件名"
            Case "锁定图号"
                strOperator = "锁定图号"
            Case "锁定名称"
                strOperator = "锁定名称"
            Case Else
                Exit Sub
        End Select

        If lvw文件列表.SelectedItems.Count > 0 Then
            ' 遍历 ListView 中的所有选择项。
            For Each oListViewItem As ListViewItem In lvw文件列表.SelectedItems
                oListViewItem.Text = strOperator
            Next
        End If


    End Sub

    Private Sub cmb连接符_TextChanged(sender As Object, e As EventArgs) Handles cmb连接符.TextChanged

        Dim ConnectionCharacter As String

        Select Case cmb连接符.Text
            Case "无"
                ConnectionCharacter = ""
                Exit Sub
            Case "空格"
                ConnectionCharacter = " "
            Case "短横线-"
                ConnectionCharacter = "-"
            Case "下划线_"
                ConnectionCharacter = "_"
            Case Else
                ConnectionCharacter = cmb连接符.Text
        End Select

        If Strings.InStr(txt基准图号.Text, ConnectionCharacter) <> 0 Then
            If isHandlingTextChange = False Then ' 设置处理标志
                MessageBox.Show("基准图号包含分隔符，请重新设置。", "XHTool", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmb连接符.Text = "无"
                isHandlingTextChange = True  ' 重置处理标志
            Else
                cmb连接符.Text = "无"
                isHandlingTextChange = False ' 重置处理标志
            End If
        End If
    End Sub

End Class