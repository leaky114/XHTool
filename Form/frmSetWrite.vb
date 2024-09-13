Imports Inventor
Imports Inventor.DocumentTypeEnum
Imports Microsoft
Imports Microsoft.VisualBasic
Imports stdole
Imports System
Imports System.Collections.ObjectModel
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

Public Class frmSetWrite
    Private imageList As New ImageList()
    Private strCurrentAssemblyDocumentFulFileName As String

    Private Sub btn关闭_Click(sender As Object, e As EventArgs) Handles btn关闭.Click
        Lvw文件列表.Items.Clear()
        TreeV文件树.Nodes.Clear()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub btn载入当前部件_Click(sender As Object, e As EventArgs) Handles btn载入当前部件.Click
        LoadIAM(Lvw文件列表, TreeV文件树)
    End Sub

    Private Sub frmSetWrite_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48

        Dim imageList As New ImageList()
        imageList.Images.Add(My.Resources.部件16.ToBitmap)

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        LoadIAM(Lvw文件列表, TreeV文件树)

        cbo筛选文件.SelectedIndex = cbo筛选文件.Items.IndexOf("全部文件")

    End Sub

    Private Sub LoadIAM(ByVal oListView As ListView, ByVal oTreeView As TreeView)

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = oInventorDocument

        strCurrentAssemblyDocumentFulFileName = oInventorAssemblyDocument.FullDocumentName

        Dim oInteraction As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        oInteraction.Start()
        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        ThisApplication.UserInterfaceManager.DoEvents()

        oTreeView.BeginUpdate()
        oListView.BeginUpdate()

        Dim oTreeNode As TreeNode
        oTreeNode = oTreeView.Nodes.Add(GetFileName2(strCurrentAssemblyDocumentFulFileName))

        If GetFileReadOnly(strCurrentAssemblyDocumentFulFileName) = True Then
            oTreeNode.ForeColor = Drawing.Color.DimGray
        Else
            oTreeNode.ForeColor = Drawing.Color.BlueViolet
        End If

        oTreeNode.ToolTipText = strCurrentAssemblyDocumentFulFileName

        LoadFileToTreeView(strCurrentAssemblyDocumentFulFileName, oTreeNode)

        LoadFileToListView(strCurrentAssemblyDocumentFulFileName, oListView)

        oTreeView.EndUpdate()
        oListView.EndUpdate()

        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        oInteraction.Stop()

    End Sub

    Private Sub LoadFileToTreeView(ByVal strAssemblyDocumentFulFileName As String, ByVal oTreeNode As TreeNode)
        Dim oAssemblyDocument As Inventor.AssemblyDocument

        oAssemblyDocument = ThisApplication.Documents.ItemByName(strAssemblyDocumentFulFileName)
        '===================================
        '基于bom结构化数据，可跳过参考的文件
        ' Set a reference to the BOM
        Dim oBOM As BOM
        oBOM = oAssemblyDocument.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True
        oBOM.StructuredViewFirstLevelOnly = False

        'Set a reference to the "Structured" BOMView
        Dim oBOMView As BOMView

        oTreeNode.TreeView.BeginUpdate()

        '获取结构化的bom页面
        For Each oBOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                '遍历这个bom页面
                QueryBOMRowToLoadFileToTreeView(oBOMView.BOMRows, oTreeNode)
            End If
        Next

        oTreeNode.TreeView.Sort()
        oTreeNode.TreeView.EndUpdate()

    End Sub
    Private Sub QueryBOMRowToLoadFileToTreeView(ByVal oBOMRows As BOMRowsEnumerator, ByVal oTreeNode As TreeNode)
        For Each oBomRow As BOMRow In oBOMRows

            Dim oInventorDocumentFullFileName As String
            oInventorDocumentFullFileName = oBomRow.ReferencedFileDescriptor.FullFileName

            If InStr(oInventorDocumentFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                Continue For
            End If

            If IsFileExsts(oInventorDocumentFullFileName) = False Then   '跳过不存在的文件
                Continue For
            End If

            Dim strInventorDocumentFileName As String
            strInventorDocumentFileName = GetFileNameInfo(oInventorDocumentFullFileName).FileName

            Dim oChildTreeNode As TreeNode = Nothing
            If GetFileExtensionLCase(strInventorDocumentFileName) = IAM Then
                oChildTreeNode = oTreeNode.Nodes.Add(strInventorDocumentFileName)
                oChildTreeNode.ToolTipText = oInventorDocumentFullFileName
                oChildTreeNode.ImageIndex = 0

                If GetFileReadOnly(oInventorDocumentFullFileName) = True Then
                    oChildTreeNode.ForeColor = Drawing.Color.DimGray
                Else
                    oChildTreeNode.ForeColor = Drawing.Color.BlueViolet
                End If

            End If

            ''遍历下一级
            If (Not oBomRow.ChildRows Is Nothing) Then
                Call QueryBOMRowToLoadFileToTreeView(oBomRow.ChildRows, oChildTreeNode)
            End If

        Next
    End Sub

    Private Sub LoadFileToListView(ByVal strAssemblyDocumentFulFileName As String, ByVal oListView As ListView)
        Dim oAssemblyDocument As Inventor.AssemblyDocument

        oAssemblyDocument = ThisApplication.Documents.ItemByName(strAssemblyDocumentFulFileName)
        '===================================
        '基于bom结构化数据，可跳过参考的文件
        ' Set a reference to the BOM
        Dim oBOM As BOM
        oBOM = oAssemblyDocument.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True
        oBOM.StructuredViewFirstLevelOnly = False

        'Set a reference to the "Structured" BOMView
        Dim oBOMView As BOMView

        oListView.Items.Clear()
        oListView.BeginUpdate()

        '获取结构化的bom页面
        For Each oBOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                '遍历这个bom页面
                QueryBOMRowToLoadFileToListView(oBOMView.BOMRows, oListView)
            End If
        Next

        oListView.EndUpdate()

    End Sub

    Private Sub QueryBOMRowToLoadFileToListView(ByVal oBOMRows As BOMRowsEnumerator, ByVal oListView As ListView)

        For Each oBomRow As BOMRow In oBOMRows

            Dim oInventorDocumentFullFileName As String
            oInventorDocumentFullFileName = oBomRow.ReferencedFileDescriptor.FullFileName

            If InStr(oInventorDocumentFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                Continue For
            End If

            If IsFileExsts(oInventorDocumentFullFileName) = False Then   '跳过不存在的文件
                Continue For
            End If

            Dim strInventorDocumentFileName As String
            strInventorDocumentFileName = GetFileNameInfo(oInventorDocumentFullFileName).FileName

            Dim oListViewItem As ListViewItem
            Dim oListViewSubItem As ListViewItem.ListViewSubItem

            If IsItemInListView(oListView, strInventorDocumentFileName) = False Then

                oListViewItem = oListView.Items.Add(strInventorDocumentFileName)

                'oListViewItem.UseItemStyleForSubItems = False

                '根据模型文是否只读设置字颜色
                If GetFileReadOnly(oInventorDocumentFullFileName) = True Then
                    oListViewItem.ForeColor = Drawing.Color.DimGray
                    oListViewSubItem = oListViewItem.SubItems.Add(oInventorDocumentFullFileName)
                    'oListViewSubItem.ForeColor = Drawing.Color.DimGray
                Else
                    oListViewItem.ForeColor = Drawing.Color.BlueViolet
                    oListViewSubItem = oListViewItem.SubItems.Add(oInventorDocumentFullFileName)
                    'oListViewSubItem.ForeColor = Drawing.Color.Black
                End If

                '找工程图，添加项目，设置颜色
                Dim strInventorDrawingFullFileName As String
                strInventorDrawingFullFileName = GetChangeExtension(oInventorDocumentFullFileName, IDW)

                If IsFileExsts(strInventorDrawingFullFileName) = True Then
                    Dim strInventorDrawingFileName As String
                    strInventorDrawingFileName = GetFileNameInfo(strInventorDrawingFullFileName).FileName

                    oListViewItem = oListView.Items.Add(strInventorDrawingFileName)

                    If GetFileReadOnly(strInventorDrawingFullFileName) = True Then
                        oListViewItem.ForeColor = Drawing.Color.DimGray
                        oListViewSubItem = oListViewItem.SubItems.Add(strInventorDrawingFullFileName)
                        'oListViewSubItem.ForeColor = Drawing.Color.DimGray
                    Else
                        oListViewItem.ForeColor = Drawing.Color.BlueViolet
                        oListViewSubItem = oListViewItem.SubItems.Add(strInventorDrawingFullFileName)
                        'oListViewSubItem.ForeColor = Drawing.Color.Black
                    End If
                Else

                End If

            End If

            ''遍历下一级
            'If (Not oBomRow.ChildRows Is Nothing) Then
            '    Call QueryBOMRowToLoadFile(oBomRow.ChildRows, oListView, oTreeView)
            'End If

        Next

    End Sub

    Private Sub TreeV文件树_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeV文件树.AfterSelect
        strCurrentAssemblyDocumentFulFileName = e.Node.ToolTipText
        LoadFileToListView(strCurrentAssemblyDocumentFulFileName, Lvw文件列表)
    End Sub

    Private Sub chk隐藏工程图_CheckedChanged(sender As Object, e As EventArgs) Handles chk隐藏工程图.CheckedChanged
        For Each oListViewItem As ListViewItem In Lvw文件列表.Items
            Dim oInventorDocumentFullFileName As String
            oInventorDocumentFullFileName = oListViewItem.SubItems(1).Text

            If chk隐藏工程图.Checked = True Then
                '隐藏工程图
                If GetFileExtensionLCase(oInventorDocumentFullFileName) = IDW Then
                    oListViewItem.Remove()
                End If
            Else
                '根据列表重新加载工程图
                Dim strInventorDrawingFullFileName As String
                strInventorDrawingFullFileName = GetChangeExtension(oInventorDocumentFullFileName, IDW)

                Dim strInventorDrawingFileName As String
                strInventorDrawingFileName = GetFileNameInfo(strInventorDrawingFullFileName).FileName

                If IsFileExsts(strInventorDrawingFullFileName) = True Then
                    oListViewItem = Lvw文件列表.Items.Add(strInventorDrawingFileName)

                    Dim oListViewSubItem As ListViewItem.ListViewSubItem

                    If GetFileReadOnly(strInventorDrawingFullFileName) = True Then
                        oListViewItem.ForeColor = Drawing.Color.DimGray
                        oListViewSubItem = oListViewItem.SubItems.Add(strInventorDrawingFullFileName)
                        oListViewSubItem.ForeColor = Drawing.Color.DimGray
                    Else
                        oListViewItem.ForeColor = Drawing.Color.BlueViolet
                        oListViewSubItem = oListViewItem.SubItems.Add(strInventorDrawingFullFileName)
                        oListViewSubItem.ForeColor = Drawing.Color.BlueViolet
                    End If
                Else

                End If
            End If

        Next
    End Sub

    Private Sub cbo筛选文件_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo筛选文件.SelectedIndexChanged

        Select Case cbo筛选文件.Text
            Case "全部文件"
                LoadFileToListView(strCurrentAssemblyDocumentFulFileName, Lvw文件列表)

            Case "只读文件"
                LoadFileToListView(strCurrentAssemblyDocumentFulFileName, Lvw文件列表)

                For Each oListViewItem As ListViewItem In Lvw文件列表.Items
                    Dim oInventorDocumentFullFileName As String
                    oInventorDocumentFullFileName = oListViewItem.SubItems(1).Text
                    '隐藏只读文件
                    If GetFileReadOnly(oInventorDocumentFullFileName) = False Then
                        oListViewItem.Remove()
                    End If

                Next
            Case "可写文件"
                LoadFileToListView(strCurrentAssemblyDocumentFulFileName, Lvw文件列表)

                For Each oListViewItem As ListViewItem In Lvw文件列表.Items
                    Dim oInventorDocumentFullFileName As String
                    oInventorDocumentFullFileName = oListViewItem.SubItems(1).Text
                    '隐藏只读文件
                    If GetFileReadOnly(oInventorDocumentFullFileName) = True Then
                        oListViewItem.Remove()
                    End If

                Next


        End Select

    End Sub

    Private Sub 列表打开tsmi_Click(sender As Object, e As EventArgs) Handles 列表打开tsmi.Click
        If Lvw文件列表.SelectedItems.Count <> 0 Then
            Dim strInventorDocumentFullFileName As String
            For Each oListViewItem As ListViewItem In Lvw文件列表.SelectedItems
                strInventorDocumentFullFileName = oListViewItem.SubItems(1).Text
                ThisApplication.Documents.Open(strInventorDocumentFullFileName)
            Next
        End If
    End Sub

    Private Sub 列表读写tsmi_Click(sender As Object, e As EventArgs) Handles 列表读写tsmi.Click
        If Lvw文件列表.SelectedItems.Count <> 0 Then
            Dim strInventorDocumentFullFileName As String
            For Each oListViewItem As ListViewItem In Lvw文件列表.SelectedItems

                strInventorDocumentFullFileName = oListViewItem.SubItems(1).Text
                Select Case GetFileReadOnly(strInventorDocumentFullFileName)
                    Case True     '只读变可写
                        SetFileReadOnly(strInventorDocumentFullFileName, False)
                        oListViewItem.ForeColor = Drawing.Color.BlueViolet

                        Dim oTreeNode As TreeNode
                        oTreeNode = FindTreeNodeByToolTipText(TreeV文件树, strInventorDocumentFullFileName)
                        If oTreeNode Is Nothing Then

                        Else
                            oTreeNode.ForeColor = Drawing.Color.BlueViolet
                        End If

                    Case False   '可行变只读
                        SetFileReadOnly(strInventorDocumentFullFileName, True)
                        oListViewItem.ForeColor = Drawing.Color.DimGray

                        Dim oTreeNode As TreeNode
                        oTreeNode = FindTreeNodeByToolTipText(TreeV文件树, strInventorDocumentFullFileName)
                        If oTreeNode Is Nothing Then

                        Else
                            oTreeNode.ForeColor = Drawing.Color.DimGray
                        End If


                End Select
            Next
        End If
    End Sub

    Private Sub 树打开tsmi_Click(sender As Object, e As EventArgs) Handles 树打开tsmi.Click
        If IsFileExsts(strCurrentAssemblyDocumentFulFileName) = True Then
            ThisApplication.Documents.Open(strCurrentAssemblyDocumentFulFileName)
        End If
    End Sub

    Private Sub 树全部展开tsmi_Click(sender As Object, e As EventArgs) Handles 树全部展开tsmi.Click
        TreeV文件树.ExpandAll()
    End Sub

    Private Sub 树全部收拢tsmi_Click(sender As Object, e As EventArgs) Handles 树全部收拢tsmi.Click
        TreeV文件树.CollapseAll()
    End Sub

    Private Sub 树清空tsmi_Click(sender As Object, e As EventArgs) Handles 树清空tsmi.Click
        TreeV文件树.Nodes.Clear()
        Lvw文件列表.Items.Clear()
        strCurrentAssemblyDocumentFulFileName = ""
    End Sub

    Private Sub 列表全部只读tsmi_Click(sender As Object, e As EventArgs) Handles 列表全部只读tsmi.Click
        Dim strInventorDocumentFullFileName As String
        For Each oListViewItem As ListViewItem In Lvw文件列表.Items
            strInventorDocumentFullFileName = oListViewItem.SubItems(1).Text
            SetFileReadOnly(strInventorDocumentFullFileName, True)
            oListViewItem.ForeColor = Drawing.Color.DimGray

            Dim oTreeNode As TreeNode
            oTreeNode = FindTreeNodeByToolTipText(TreeV文件树, strInventorDocumentFullFileName)
            If oTreeNode Is Nothing Then

            Else
                oTreeNode.ForeColor = Drawing.Color.DimGray
            End If

        Next

    End Sub

    Private Sub 树读写tsmi_Click(sender As Object, e As EventArgs) Handles 树读写tsmi.Click
        If IsFileExsts(strCurrentAssemblyDocumentFulFileName) = True Then
            Select Case GetFileReadOnly(strCurrentAssemblyDocumentFulFileName)
                Case True     '只读变可写
                    SetFileReadOnly(strCurrentAssemblyDocumentFulFileName, False)
                    TreeV文件树.SelectedNode.ForeColor = Drawing.Color.BlueViolet

                Case False   '可行变只读
                    SetFileReadOnly(strCurrentAssemblyDocumentFulFileName, True)
                    TreeV文件树.SelectedNode.ForeColor = Drawing.Color.DimGray
            End Select
        End If
    End Sub

    Public Function FindTreeNodeByToolTipText(ByVal oTreeView As TreeView, ByVal strToolTipText As String) As TreeNode
        ' 初始化返回值为Nothing，表示如果没有找到匹配的节点  
        Dim result As TreeNode = Nothing

        ' 定义一个递归函数来遍历所有节点  
        Dim FindNode As Func(Of TreeNode, TreeNode) = Function(node As TreeNode)
                                                          ' 检查当前节点的ToolTipText是否匹配  

                                                          If node.ToolTipText = strToolTipText Then
                                                              ' 如果匹配，设置result并停止递归  
                                                              result = node
                                                              Return Nothing
                                                          End If

                                                          ' 如果没有找到匹配的节点，则递归检查所有子节点  
                                                          For Each childNode As TreeNode In node.Nodes
                                                              Dim foundNode As TreeNode = FindNode(childNode)
                                                              If foundNode IsNot Nothing Then
                                                                  ' 如果在子节点中找到了匹配的节点，则返回该节点  
                                                                  Return foundNode
                                                              End If
                                                          Next

                                                          ' 如果没有找到匹配的节点，则返回Nothing  
                                                          Return Nothing
                                                      End Function

        ' 从TreeView的根节点开始查找  
        For Each oTreeNode As TreeNode In oTreeView.Nodes
            FindNode(oTreeNode)
            ' 返回找到的节点（如果有的话）  
            Return result
        Next

        Return result
    End Function

    Private Sub 树全部只读tsmi_Click(sender As Object, e As EventArgs) Handles 树全部只读tsmi.Click
        列表全部只读tsmi_Click(sender, e)
    End Sub

    Private Sub 列表全部可写tsmi_Click(sender As Object, e As EventArgs) Handles 列表全部可写tsmi.Click
        Dim strInventorDocumentFullFileName As String
        For Each oListViewItem As ListViewItem In Lvw文件列表.Items
            strInventorDocumentFullFileName = oListViewItem.SubItems(1).Text
            SetFileReadOnly(strInventorDocumentFullFileName, False)
            oListViewItem.ForeColor = Drawing.Color.BlueViolet

            Dim oTreeNode As TreeNode
            oTreeNode = FindTreeNodeByToolTipText(TreeV文件树, strInventorDocumentFullFileName)
            If oTreeNode Is Nothing Then

            Else
                oTreeNode.ForeColor = Drawing.Color.BlueViolet
            End If

        Next
    End Sub

    Private Sub 树全部可写tsmi_Click(sender As Object, e As EventArgs) Handles 树全部可写tsmi.Click
        列表全部可写tsmi_Click(sender, e)
    End Sub
End Class