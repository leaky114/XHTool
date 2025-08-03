Imports System.Windows.Forms
Imports Inventor
Imports Microsoft
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Text.RegularExpressions
Imports Path = System.IO.Path
Imports System.Collections.Generic

Public Class FormCleanUpRedundantFiles

    Private currentSortColumn As Integer = -1
    Private sortOrder As SortOrder = SortOrder.None
    Private manualOrderMode As Boolean = False ' 标记手动排序模式

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

    Private Sub FormCleanUpRedundantFiles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48

        Dim toolTip As New ToolTip With {
            .AutoPopDelay = 0,
            .InitialDelay = 0,
            .ReshowDelay = 500
        }

        查询ToolStripButton.Image = My.Resources.查询16.ToBitmap
        全选清理项ToolStripButton.Image = My.Resources.全部选择16.ToBitmap
        清理ToolStripButton.Image = My.Resources.清空列表16.ToBitmap
        关闭ToolStripButton.Image = My.Resources.关闭16.ToBitmap

        SetWindowSizeAndCenter(Me)

        查询ToolStripButton_Click(sender, e)

    End Sub

    Private Sub 查询ToolStripButton_Click(sender As Object, e As EventArgs) Handles 查询ToolStripButton.Click

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument

        Dim strInventorAssemblyDocumentFullFileName As String
        strInventorAssemblyDocumentFullFileName = oInventorAssemblyDocument.FullDocumentName

        Dim strInventorAssemblyDocumentName As String
        strInventorAssemblyDocumentName = GetFileNameWithExtension(strInventorAssemblyDocumentFullFileName)

        Dim strInventorAssemblyDocumentNamePath As String
        strInventorAssemblyDocumentNamePath = GetDirectoryName2(strInventorAssemblyDocumentFullFileName)

        lvw文件列表.Items.Clear()
        lvw文件列表.BeginUpdate()

        Try
            ' 验证目录存在
            If Not Directory.Exists(strInventorAssemblyDocumentNamePath) Then
                MessageBox.Show($"目录不存在: {strInventorAssemblyDocumentNamePath}", XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' 获取多种类型的文件（不区分大小写）
            Dim oFiles As IEnumerable = GetFilesByExtensions(strInventorAssemblyDocumentNamePath, IAM, IPT, IDW)

            ' 显示结果
            'Console.WriteLine($"找到 {files.Count} 个文件：")

            For Each strFilePath As String In oFiles

                Dim oFileNameInfo As FileNameInfo
                oFileNameInfo = GetFileNameInfo(strFilePath)

                Dim oListViewItem As ListViewItem
                oListViewItem = lvw文件列表.Items.Add(oFileNameInfo.FileName)
                With oListViewItem
                    .SubItems.Add("")
                    .SubItems.Add(strFilePath)
                End With
            Next

        Catch ex As UnauthorizedAccessException
            'Console.WriteLine($"无访问权限: {strFolderPath}")
        Catch ex As Exception
            'Console.WriteLine($"发生错误: {ex.Message}")
        End Try


        Dim strUseDocumentList As New List(Of String)

        strUseDocumentList.Add(Strings.UCase(strInventorAssemblyDocumentFullFileName))


        ' 遍历这些文档 
        Dim strInventorDocumentFullFileName As String
        Dim strInventorDrawingDocumentFullFileName As String

        strInventorDrawingDocumentFullFileName = GetChangeExtension(strInventorAssemblyDocumentFullFileName, IDW)
        If IsFileExists(strInventorDrawingDocumentFullFileName) = True Then
            strUseDocumentList.Add(Strings.UCase(strInventorDrawingDocumentFullFileName))
        End If


        Dim oRefDocs As DocumentsEnumerator
        oRefDocs = oInventorAssemblyDocument.AllReferencedDocuments



        For Each oRefDoc As Document In oRefDocs
            '   Debug.Print oRefDoc.DisplayName 
            strInventorDocumentFullFileName = oRefDoc.FullDocumentName
            strUseDocumentList.Add(Strings.UCase(strInventorDocumentFullFileName))

            strInventorDrawingDocumentFullFileName = GetChangeExtension(strInventorDocumentFullFileName, IDW)

            If IsFileExists(strInventorDrawingDocumentFullFileName) = True Then
                strUseDocumentList.Add(Strings.UCase(strInventorDrawingDocumentFullFileName))
            End If

        Next

        Dim strFullFileName As String

        For Each oListViewItem As ListViewItem In lvw文件列表.Items
            strFullFileName = Strings.UCase(oListViewItem.SubItems（2）.Text)

            If strUseDocumentList.Contains(strFullFileName) = True Then
                oListViewItem.Checked = True

                oListViewItem.SubItems(1).Text = $"{strInventorAssemblyDocumentName}的引用。"

                If GetFileExtensionLCase(strFullFileName) = IDW Then
                    strInventorDocumentFullFileName = GetChangeExtension(strFullFileName, IAM)


                    If IsFileExists(strInventorDocumentFullFileName) = False Then
                        strInventorDocumentFullFileName = GetChangeExtension(strFullFileName, IPT)
                    End If


                    oListViewItem.SubItems(1).Text = $"{GetFileNameWithExtension(strInventorDocumentFullFileName)}的引用。"

                End If
            Else
                oListViewItem.SubItems(1).Text = "未查询到引用，可清除。"
            End If
        Next

        Try
            ' 遍历所有项目
            For Each oListViewItem As ListViewItem In lvw文件列表.Items
                ' 反转勾选状态
                oListViewItem.Checked = Not oListViewItem.Checked
            Next
        Finally
            ' 确保始终恢复重绘
            lvw文件列表.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent)
            lvw文件列表.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent)
            lvw文件列表.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent)
            lvw文件列表.EndUpdate()

        End Try


    End Sub

    ''' <summary>
    ''' 返回文件夹中指定扩展名的文件
    ''' </summary>
    ''' <param name="folderPath">文件夹路径</param>
    ''' <param name="extensions">扩展名</param>
    ''' <returns></returns>
    Public Function GetFilesByExtensions(folderPath As String, ParamArray extensions As String()) As IEnumerable(Of String)
        ' 处理空扩展名情况
        If extensions Is Nothing OrElse extensions.Length = 0 Then
            Return Directory.EnumerateFiles(folderPath)
        End If

        ' 标准化扩展名
        Dim extSet = New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        For Each ext In extensions
            Dim normalized = If(ext.StartsWith("."), ext, "." & ext)
            extSet.Add(normalized)
        Next

        ' 搜索文件
        Return Directory.EnumerateFiles(folderPath) _
            .Where(Function(f) extSet.Contains(Path.GetExtension(f)))
    End Function
    Private Sub 清理ToolStripButton_Click(sender As Object, e As EventArgs) Handles 清理ToolStripButton.Click
        Dim strFullFileName As String = ""

        For Each oListViewItem As ListViewItem In lvw文件列表.Items
            strFullFileName = oListViewItem.SubItems（2）.Text

            If oListViewItem.Checked = True And IsFileExists(strFullFileName） = True Then
                AddOldExtension(strFullFileName)
                oListViewItem.Remove()
            End If
        Next
        MessageBox.Show("清理冗余文件完成。", XHTool, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Private Sub 关闭ToolStripButton_Click(sender As Object, e As EventArgs) Handles 关闭ToolStripButton.Click
        FormManager.CloseAndDisposeForm(Of FormCleanUpRedundantFiles)()
    End Sub

    Private Sub 全选清理项ToolStripButton_Click(sender As Object, e As EventArgs) Handles 全选清理项ToolStripButton.Click
        For Each oListViewItem As ListViewItem In lvw文件列表.Items
            If oListViewItem.SubItems(1).Text = "未查询到引用，可清除。" Then
                oListViewItem.Checked = True
            End If
        Next
    End Sub

End Class