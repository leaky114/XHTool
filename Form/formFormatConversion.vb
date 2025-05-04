Imports Inventor
Imports Microsoft
Imports Microsoft.VisualBasic
'Imports Microsoft.VisualBasic.Compatibility
Imports stdole
Imports System
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Windows.Forms
Imports Inventor.DocumentTypeEnum
Imports System.Collections.Generic

Public Class FormFormatConversion

    ''' <summary>
    ''' 加载文件列表到Listview
    ''' </summary>
    ''' <param name="oListView">listview 控件</param>
    ''' <param name="oFileList">文件列表</param>
    ''' <param name="IsContainIdw">是否添加工程图</param>
    ''' <param name="IsContainIpt">是否添加零部件</param>
    ''' <remarks></remarks>
    Private Sub AddFilesInListView(ByVal oListView As ListView, ByVal oFileList As List(Of String),
                                      ByVal IsContainIdw As Boolean, ByVal IsContainIpt As Boolean)
        Dim strExtension As String

        For Each strInventorDocumentFullFileName As String In oFileList
            If IsItemInListView(oListView, strInventorDocumentFullFileName) = True Then
                Continue For
            End If

            If Strings.InStr(strInventorDocumentFullFileName, "OldVersions") <> 0 Then
                Continue For
            End If

            If IsFileExIsts(strInventorDocumentFullFileName) = False Then   '跳过不存在的文件
                Continue For
            End If

            If InStr(strInventorDocumentFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                Continue For
            End If

            strExtension = GetFileExtensionLCase(strInventorDocumentFullFileName)

            Select Case strExtension
                Case IPT, IAM
                    If IsContainIpt = True Then
                        oListView.Items.Add(strInventorDocumentFullFileName)
                    End If
                Case IDW
                    If IsContainIdw = True Then
                        oListView.Items.Add(strInventorDocumentFullFileName)
                    End If
            End Select

        Next

    End Sub

    '添加文件
    Private Sub 添加文件ToolStripButton_Click(sender As Object, e As EventArgs) Handles 添加文件ToolStripButton.Click

        Dim strFilter As String = "Autodesk Inventor文件(*.idw;*.iam;*.ipt)|*.idw;*.iam;*.ipt"


        If 零部件ToolStripButton.Checked = True And 工程图ToolStripButton.Checked = True Then
            strFilter = "Autodesk Inventor文件(*.idw;*.iam;*.ipt)|*.idw;*.iam;*.ipt" '添加过滤文件
        ElseIf 零部件ToolStripButton.Checked = True Then
            strFilter = "Autodesk Inventor 零部件(*.iam;*.ipt)|*.iam;*.ipt|Autodesk Inventor 零件(*.ipt)|*.ipt|Autodesk Inventor 部件(*.iam)|*.iam"
        ElseIf 工程图ToolStripButton.Checked = True Then
            strFilter = "Autodesk Inventor 工程图(*.idw)|*.idw" '添加过滤文件
        End If

        Dim strFile = IO.Path.Combine(ThisApplication.FileLocations.Workspace, "选择文件")
        Dim oFileList As List(Of String)
        oFileList = OpenFileDialog(strFilter, True, strFile）

        If oFileList Is Nothing Then
            Exit Sub
        End If

        AddFilesInListView(Lvw文件列表, oFileList, 工程图ToolStripButton.Checked, 零部件ToolStripButton.Checked)

    End Sub

    '添加文件夹
    Private Sub 添加文件夹ToolStripButton_Click(sender As Object, e As EventArgs) Handles 添加文件夹ToolStripButton.Click
        Dim strFile = IO.Path.Combine(ThisApplication.FileLocations.Workspace, "选择一个文件确定文件夹")
        Dim strDestinationFolder As String = OpenFolderDialog(strFile)

        If strDestinationFolder Is Nothing Then
            Exit Sub
        End If

        Dim strExtension As String
        Dim oFileList As List(Of String)

        If 零部件ToolStripButton.Checked = True Then
            strExtension = IPT
            oFileList = GetAllFilesByExtension(strDestinationFolder, strExtension)

            AddFilesInListView(Lvw文件列表, oFileList, 工程图ToolStripButton.Checked, 零部件ToolStripButton.Checked)

            strExtension = IAM
            oFileList = GetAllFilesByExtension(strDestinationFolder, strExtension)

            AddFilesInListView(Lvw文件列表, oFileList, 工程图ToolStripButton.Checked, 零部件ToolStripButton.Checked)

        End If

        If 工程图ToolStripButton.Checked = True Then
            strExtension = IDW
            oFileList = GetAllFilesByExtension(strDestinationFolder, strExtension)

            AddFilesInListView(Lvw文件列表, oFileList, 工程图ToolStripButton.Checked, 零部件ToolStripButton.Checked)

        End If

    End Sub

    '选择文件夹
    Private Sub 浏览ToolStripButton_Click(sender As Object, e As EventArgs) Handles 浏览ToolStripButton.Click
        Dim strFile = IO.Path.Combine(ThisApplication.FileLocations.Workspace, "选择一个文件确定文件夹")
        Dim strDestinationFolder As String = OpenFolderDialog(strFile)

        If strDestinationFolder Is Nothing Then
            Exit Sub
        End If

        指定文件夹ToolStripTextBox.Text = strDestinationFolder
    End Sub

    Private Sub FrmSaveAs_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Icon = My.Resources.XHTool48

        Dim toolTip As New ToolTip With {
            .AutoPopDelay = 0,
            .InitialDelay = 0,
            .ReshowDelay = 500
        }

        工程图ToolStripButton.Image = My.Resources.工程图16.ToBitmap
        零部件ToolStripButton.Image = My.Resources.部件16.ToBitmap
        移出文件ToolStripButton.Image = My.Resources.移出文件16.ToBitmap
        清空列表ToolStripButton.Image = My.Resources.清空列表16.ToBitmap
        静默转换ToolStripButton.Image = My.Resources.静默16.ToBitmap
        转换后关闭ToolStripButton.Image = My.Resources.关闭文件16.ToBitmap

        添加文件ToolStripButton.Image = My.Resources.打开文件16.ToBitmap
        添加文件夹ToolStripButton.Image = My.Resources.打开文件夹16.ToBitmap
        从部件导入ToolStripButton.Image = My.Resources.部件16.ToBitmap
        导入当前部件ToolStripButton.Image = My.Resources.当前部件16.ToBitmap
        导入已打开的文件ToolStripButton.Image = My.Resources.内存文件16.ToBitmap

        DWGToolStripButton.Image = My.Resources.文件Dwg16.ToBitmap
        DXFToolStripButton.Image = My.Resources.文件Dxf16.ToBitmap
        PDFToolStripButton.Image = My.Resources.文件Pdf16.ToBitmap
        JPGToolStripButton.Image = My.Resources.图片16.ToBitmap

        STPToolStripButton.Image = My.Resources.零件16.ToBitmap
        XTToolStripButton.Image = My.Resources.零件16.ToBitmap

        格式分类ToolStripButton.Image = My.Resources.格式分类16.ToBitmap
        指定文件夹ToolStripButton.Image = My.Resources.打开文件夹16.ToBitmap
        浏览ToolStripButton.Image = My.Resources.查询16.ToBitmap

        开始转换ToolStripButton2.Image = My.Resources.格式转换16.ToBitmap
        关闭ToolStripButton.Image = My.Resources.关闭16.ToBitmap

        Lvw文件列表.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

        SetWindowSizeAndCenter(Me)

    End Sub

    '移除选择列
    Private Sub 移出文件ToolStripButton_Click(sender As Object, e As EventArgs) Handles 移出文件ToolStripButton.Click, tsmi移出.Click
        ListViewDel(Lvw文件列表)
    End Sub


    Private Sub Lvw文件列表_DragDrop(sender As Object, e As DragEventArgs) Handles Lvw文件列表.DragDrop

        Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())

        Dim strExtension As String

        For Each strDestinationFileFolder As String In filePaths

            If IO.Directory.Exists(strDestinationFileFolder) Then

                Dim oFileList As List(Of String)

                If 零部件ToolStripButton.Checked = True Then
                    strExtension = IPT
                    oFileList = GetAllFilesByExtension(strDestinationFileFolder, strExtension)

                    AddFilesInListView(Lvw文件列表, oFileList, 工程图ToolStripButton.Checked, 零部件ToolStripButton.Checked)

                    'For Each strFullFileName As String In oFileList
                    '    If Strings.InStr(strFullFileName, "OldVersions") = 0 Then
                    '        If IsItemInListView(lvw文件列表, strFullFileName) = False Then
                    '            lvw文件列表.Items.Add(strFullFileName)
                    '        End If
                    '    End If
                    'Next

                    strExtension = IAM
                    oFileList = GetAllFilesByExtension(strDestinationFileFolder, strExtension)

                    AddFilesInListView(Lvw文件列表, oFileList, 工程图ToolStripButton.Checked, 零部件ToolStripButton.Checked)

                    'For Each strFullFileName As String In oFileList
                    '    If Strings.InStr(strFullFileName, "OldVersions") = 0 Then
                    '        If IsItemInListView(lvw文件列表, strFullFileName) = False Then
                    '            lvw文件列表.Items.Add(strFullFileName)
                    '        End If
                    '    End If
                    'Next
                End If

                If 工程图ToolStripButton.Checked = True Then
                    strExtension = IDW
                    oFileList = GetAllFilesByExtension(strDestinationFileFolder, strExtension)

                    AddFilesInListView(Lvw文件列表, oFileList, 工程图ToolStripButton.Checked, 零部件ToolStripButton.Checked)

                    'For Each strFullFileName As String In oFileList
                    '    If Strings.InStr(strFullFileName, "OldVersions") = 0 Then
                    '        If IsItemInListView(lvw文件列表, strFullFileName) = False Then
                    '            lvw文件列表.Items.Add(strFullFileName)
                    '        End If
                    '    End If
                    'Next
                End If


            ElseIf IO.File.Exists(strDestinationFileFolder) Then

                If Strings.InStr(strDestinationFileFolder, "OldVersions") <> 0 Then
                    Continue For
                End If

                If IsItemInListView(Lvw文件列表, strDestinationFileFolder) = False Then

                    strExtension = GetFileExtensionLCase(strDestinationFileFolder)

                    Select Case strExtension
                        Case IPT, IAM
                            If 零部件ToolStripButton.Checked = True Then
                                Lvw文件列表.Items.Add(strDestinationFileFolder)
                            End If
                        Case IDW
                            If 工程图ToolStripButton.Checked = True Then
                                Lvw文件列表.Items.Add(strDestinationFileFolder)
                            End If

                    End Select

                End If

            End If

        Next

    End Sub

    Private Sub Lvw文件列表_DragEnter(sender As Object, e As DragEventArgs) Handles Lvw文件列表.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub Lvw文件列表_KeyDown(sender As Object, e As KeyEventArgs) Handles Lvw文件列表.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                ListViewDel(Lvw文件列表)
        End Select
    End Sub

    '清空文件列表
    Private Sub 清空列表ToolStripButton_Click(sender As Object, e As EventArgs) Handles 清空列表ToolStripButton.Click, tsmi清空.Click
        Lvw文件列表.Items.Clear()
    End Sub

    Private Sub 工程图ToolStripButton_Click(sender As Object, e As EventArgs) Handles 工程图ToolStripButton.Click
        If 工程图ToolStripButton.Checked = True Then
            DWGToolStripButton.Enabled = True
            DXFToolStripButton.Enabled = True
            PDFToolStripButton.Enabled = True
            JPGToolStripButton.Enabled = True

            添加文件ToolStripButton.Enabled = True
            添加文件夹ToolStripButton.Enabled = True

            从部件导入ToolStripButton.Enabled = True
            导入当前部件ToolStripButton.Enabled = True
            导入已打开的文件ToolStripButton.Enabled = True

        Else
            DWGToolStripButton.Checked = False
            DXFToolStripButton.Checked = False
            PDFToolStripButton.Checked = False
            JPGToolStripButton.Checked = False

            DWGToolStripButton.Enabled = False
            DXFToolStripButton.Enabled = False
            PDFToolStripButton.Enabled = False
            JPGToolStripButton.Enabled = False

            添加文件ToolStripButton.Enabled = 零部件ToolStripButton.Checked
            添加文件夹ToolStripButton.Enabled = 零部件ToolStripButton.Checked

            从部件导入ToolStripButton.Enabled = 零部件ToolStripButton.Checked
            导入当前部件ToolStripButton.Enabled = 零部件ToolStripButton.Checked
            导入已打开的文件ToolStripButton.Enabled = 零部件ToolStripButton.Checked
        End If
    End Sub

    Private Sub 零部件ToolStripButton_Click(sender As Object, e As EventArgs) Handles 零部件ToolStripButton.Click
        If 零部件ToolStripButton.Checked = True Then
            JPGToolStripButton.Enabled = True
            STPToolStripButton.Enabled = True
            XTToolStripButton.Enabled = True

            添加文件ToolStripButton.Enabled = True
            添加文件夹ToolStripButton.Enabled = True

            从部件导入ToolStripButton.Enabled = True
            导入当前部件ToolStripButton.Enabled = True
            导入已打开的文件ToolStripButton.Enabled = True

        Else
            JPGToolStripButton.Checked = False
            STPToolStripButton.Checked = False
            XTToolStripButton.Checked = False
            JPGToolStripButton.Enabled = False
            STPToolStripButton.Enabled = False
            XTToolStripButton.Enabled = False

            添加文件ToolStripButton.Enabled = 工程图ToolStripButton.Checked
            添加文件夹ToolStripButton.Enabled = 工程图ToolStripButton.Checked

            从部件导入ToolStripButton.Enabled = 工程图ToolStripButton.Checked
            导入当前部件ToolStripButton.Enabled = 工程图ToolStripButton.Checked
            导入已打开的文件ToolStripButton.Enabled = 工程图ToolStripButton.Checked
        End If
    End Sub

    Private Sub 指定文件夹ToolStripButton_Click(sender As Object, e As EventArgs) Handles 指定文件夹ToolStripButton.Click
        浏览ToolStripButton.Enabled = 指定文件夹ToolStripButton.Checked
    End Sub

    Private Sub 导入已打开的文件ToolStripButton_Click(sender As Object, e As EventArgs) Handles 导入已打开的文件ToolStripButton.Click
        Dim oInventorDocument As Inventor.Document
        Dim strInventorDocumentFullFileName As String

        If ThisApplication.Documents.VisibleDocuments.Count = 0 Then
            Exit Sub
        End If

        For Each oInventorDocument In ThisApplication.Documents.VisibleDocuments
            strInventorDocumentFullFileName = oInventorDocument.FullFileName
            If IsItemInListView(Lvw文件列表, strInventorDocumentFullFileName) = False Then

                If GetFileExtensionLCase(strInventorDocumentFullFileName) = IDW And 工程图ToolStripButton.Checked = True Then
                    Lvw文件列表.Items.Add(strInventorDocumentFullFileName)
                End If

                If GetFileExtensionLCase(strInventorDocumentFullFileName) = IPT And 零部件ToolStripButton.Checked = True Then
                    Lvw文件列表.Items.Add(strInventorDocumentFullFileName)
                End If

                If GetFileExtensionLCase(strInventorDocumentFullFileName) = IAM And 零部件ToolStripButton.Checked = True Then
                    Lvw文件列表.Items.Add(strInventorDocumentFullFileName)
                End If

            End If

        Next

    End Sub

    Private Sub 导入当前部件ToolStripButton_Click(sender As Object, e As EventArgs) Handles 导入当前部件ToolStripButton.Click

        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        If oInventorDocument.DocumentType <> kAssemblyDocumentObject Then
            MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim oInventorAssemblyDocument As AssemblyDocument
        oInventorAssemblyDocument = oInventorDocument

        LoadBOM(oInventorAssemblyDocument, Lvw文件列表, 工程图ToolStripButton.Checked, 零部件ToolStripButton.Checked)

        Me.TopMost = True
        Me.TopMost = False
    End Sub

    ''' <summary>
    ''' 从文件加载BOM
    ''' </summary>
    ''' <param name="oInventorAssemblyDocument">部件对象</param>
    ''' <param name="olistiview">加载到listview对象</param>
    ''' <param name="IsContainIdw">是否加载工程图</param>
    ''' <param name="IsContainIpt">是否加载零部件</param>
    ''' <remarks></remarks>
    Private Sub LoadBOM(ByVal oInventorAssemblyDocument As AssemblyDocument, ByVal olistiview As ListView,
                                     ByVal IsContainIdw As Boolean, ByVal IsContainIpt As Boolean)
        Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        OInteractionEvents.Start()
        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)

        ThisApplication.UserInterfaceManager.DoEvents()
        '===================================
        '基于bom结构化数据，可跳过参考的文件
        Dim oBOM As BOM
        oBOM = oInventorAssemblyDocument.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True

        Lvw文件列表.BeginUpdate()

        '获取结构化的bom页面
        For Each oBOMView As BOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                '遍历这个bom页面
                LoadBOMSub(oBOMView.BOMRows, olistiview, IsContainIdw, IsContainIpt)
                Exit For
            End If
        Next

        Lvw文件列表.EndUpdate()

        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        OInteractionEvents.Stop()

    End Sub

    ''' <summary>
    '''从BOM加载数据 
    ''' </summary>
    ''' <param name="oBOMRows">被加载的BOMs对象</param>
    ''' <param name="olistiview">加载到listview对象</param>
    ''' <param name="IsContainIdw">是否加载工程图</param>
    ''' <param name="IsContainIpt">是否加载零部件</param>
    ''' <remarks></remarks>
    Private Sub LoadBOMSub(ByVal oBOMRows As BOMRowsEnumerator, ByVal olistiview As ListView,
                                      ByVal IsContainIdw As Boolean, ByVal IsContainIpt As Boolean)
        'Create a new ProgressBar object.
        'Dim oProgressBar As Inventor.ProgressBar
        'oProgressBar = ThisApplication.CreateProgressBar(False, iStepCount, "当前文件： ")
        'On Error Resume Next

        Dim strInventorDocumentFullFileNames As New List(Of String)()

        For Each oBomRow As BOMRow In oBOMRows
            Dim strInventorDocumentFullFileName As String = oBomRow.ComponentDefinitions(1).Document.FullFileName

            Debug.Print(strInventorDocumentFullFileName)

            If IsContainIpt Then
                strInventorDocumentFullFileNames.Add(strInventorDocumentFullFileName)
            End If

            If IsContainIdw = True Then
                Dim strDrawingFullName As String
                strDrawingFullName = GetChangeExtensionDocument(strInventorDocumentFullFileName, IDW)
                If strDrawingFullName <> "" Then
                    strInventorDocumentFullFileNames.Add(strDrawingFullName)
                End If
            End If

        Next

        AddFilesInListView(olistiview, strInventorDocumentFullFileNames, IsContainIdw, IsContainIpt)

        For Each oBomrow As BOMRow In oBOMRows
            '遍历下一级
            If (oBomrow.ChildRows IsNot Nothing) Then
                LoadBOMSub(oBomrow.ChildRows, olistiview, IsContainIdw, IsContainIpt)
            End If

999:
            'oProgressBar.UpdateProgress()
        Next

    End Sub

    Private Sub 从部件导入ToolStripButton_Click(sender As Object, e As EventArgs) Handles 从部件导入ToolStripButton.Click
        SetStatusBarText()

        Dim strFilter As String
        strFilter = "Autodesk Inventor 部件(*.iam)|*.iam" '添加过滤文件

        Dim strFile = IO.Path.Combine(ThisApplication.FileLocations.Workspace, "选择部件文件")

        Dim oFileList As List(Of String)
        oFileList = OpenFileDialog(strFilter, True, strFile)

        If oFileList Is Nothing Then
            Exit Sub
        End If

        Dim oInventorAssemblyDocument As AssemblyDocument

        For Each strFullFileName As String In oFileList
            oInventorAssemblyDocument = ThisApplication.Documents.Open(strFullFileName.ToString, True)
            LoadBOM(oInventorAssemblyDocument, Lvw文件列表, 工程图ToolStripButton.Checked, 零部件ToolStripButton.Checked)
        Next

        Me.TopMost = True
        Me.TopMost = False
    End Sub

    Private Sub 开始转换ToolStripButton2_Click(sender As Object, e As EventArgs) Handles 开始转换ToolStripButton2.Click
        On Error Resume Next
        Dim strFormatFullFileName As String = Nothing         'dwg 文件全文件名
        Dim strInventorDocumentFullFileName As String = Nothing   '文档文件名

        If Lvw文件列表.Items.Count = 0 Then
            MessageBox.Show(”未添加文件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If



        Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        OInteractionEvents.Start()
        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        ThisApplication.UserInterfaceManager.DoEvents()
        ThisApplication.SilentOperation = True

        str模型匹配检查标记 = 3

        Dim intCount As Integer = 0

        With 进度ToolStripProgressBar
            .Minimum = 0
            .Maximum = Lvw文件列表.Items.Count
            .Value = 0
            .Height = 20
        End With

        For Each oListViewItem As ListViewItem In Lvw文件列表.Items
            System.Windows.Forms.Application.DoEvents()
            ThisApplication.UserInterfaceManager.DoEvents()

            '当前项标记颜色
            'oListViewItem.ForeColor = Drawing.Color.BlueViolet

            ' 将itemToSelect设置为选中状态
            Lvw文件列表.SelectedItems.Clear() ' 清除所有已选中的项
            Lvw文件列表.FocusedItem = oListViewItem ' 设置焦点到要选中的项
            oListViewItem.Selected = True

            strInventorDocumentFullFileName = oListViewItem.Text

            If IsFileExIsts(strInventorDocumentFullFileName) = False Then   '跳过不存在的文件
                Continue For
            End If

            'if InStr(InvDocFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
            '    GoTo 999
            'End if

            str模型匹配检查标记 = 3

            Dim oInventorDocument As Inventor.Document
            oInventorDocument = ThisApplication.Documents.Open(strInventorDocumentFullFileName, 静默转换ToolStripButton.Checked Xor True)

            Dim oFileNameInfo As FileNameInfo
            oFileNameInfo = GetFileNameInfo(strInventorDocumentFullFileName)

            Dim strFormatFulFileName As String
            Dim oFormatFileNameInfo As FileNameInfo
            oFormatFileNameInfo = oFileNameInfo

            Dim strNewFolder As String = ""
            If 指定文件夹ToolStripButton.Checked = True Then
                strNewFolder = 指定文件夹ToolStripTextBox.Text
            Else
                strNewFolder = oFileNameInfo.Folder
            End If

            If 格式分类ToolStripButton.Checked = True Then

                Select Case oInventorDocument.DocumentType
                    Case kDrawingDocumentObject
                        If DWGToolStripButton.Checked = True Then
                            oFormatFileNameInfo.Folder = IO.Path.Combine(strNewFolder, "Dwg")

                            If IsDirectoryExists(oFormatFileNameInfo.Folder) = False Then
                                IO.Directory.CreateDirectory(oFormatFileNameInfo.Folder)
                            End If

                            strFormatFulFileName = IO.Path.Combine(oFormatFileNameInfo.Folder, oFormatFileNameInfo.OnlyName & DWG)

                            IdwSaveAsDwgSub(oInventorDocument.FullDocumentName, strFormatFulFileName)
                        End If

                        If DXFToolStripButton.Checked = True Then
                            oFormatFileNameInfo.Folder = IO.Path.Combine(strNewFolder, "Dxf")

                            If IsDirectoryExists(oFormatFileNameInfo.Folder) = False Then
                                IO.Directory.CreateDirectory(oFormatFileNameInfo.Folder)
                            End If

                            strFormatFulFileName = IO.Path.Combine(oFormatFileNameInfo.Folder, oFormatFileNameInfo.OnlyName & DXF)

                            IdwSaveAsDwgSub(oInventorDocument.FullDocumentName, strFormatFulFileName)
                        End If

                        If PDFToolStripButton.Checked = True Then
                            oFormatFileNameInfo.Folder = IO.Path.Combine(strNewFolder, "Pdf")

                            If IsDirectoryExists(oFormatFileNameInfo.Folder) = False Then
                                IO.Directory.CreateDirectory(oFormatFileNameInfo.Folder)
                            End If

                            strFormatFulFileName = IO.Path.Combine(oFormatFileNameInfo.Folder, oFormatFileNameInfo.OnlyName & PDF)

                            IdwSaveAsPdfSub(oInventorDocument.FullDocumentName, strFormatFulFileName)
                        End If

                        If JPGToolStripButton.Checked = True Then
                            oFormatFileNameInfo.Folder = IO.Path.Combine(strNewFolder, "Jpg")

                            If IsDirectoryExists(oFormatFileNameInfo.Folder) = False Then
                                IO.Directory.CreateDirectory(oFormatFileNameInfo.Folder)
                            End If

                            strFormatFulFileName = IO.Path.Combine(oFormatFileNameInfo.Folder, oFormatFileNameInfo.FileName & ".jpg")

                            ExportToBitmap(oInventorDocument, strFormatFulFileName)

                        End If

                    Case kAssemblyDocumentObject, kPartDocumentObject

                        If STPToolStripButton.Checked = True Then

                            oFormatFileNameInfo.Folder = IO.Path.Combine(strNewFolder, "Stp")
                            If IsDirectoryExists(oFormatFileNameInfo.Folder) = False Then
                                IO.Directory.CreateDirectory(oFormatFileNameInfo.Folder)
                            End If

                            strFormatFulFileName = IO.Path.Combine(oFormatFileNameInfo.Folder, oFormatFileNameInfo.OnlyName & STP)

                            AsmIptSaveAsStpSub(oInventorDocument, strFormatFulFileName)
                        End If

                        If XTToolStripButton.Checked = True Then
                            oFormatFileNameInfo.Folder = IO.Path.Combine(strNewFolder, "X_T")

                            If IsDirectoryExists(oFormatFileNameInfo.Folder) = False Then
                                IO.Directory.CreateDirectory(oFormatFileNameInfo.Folder)
                            End If

                            strFormatFulFileName = IO.Path.Combine(oFormatFileNameInfo.Folder, oFormatFileNameInfo.OnlyName & ".x_t")

                            AsmIptSaveAsStpSub(oInventorDocument, strFormatFulFileName)
                        End If

                        If JPGToolStripButton.Checked = True Then
                            oFormatFileNameInfo.Folder = IO.Path.Combine(strNewFolder, "Jpg")

                            If IsDirectoryExists(oFormatFileNameInfo.Folder) = False Then
                                IO.Directory.CreateDirectory(oFormatFileNameInfo.Folder)
                            End If

                            strFormatFulFileName = IO.Path.Combine(oFormatFileNameInfo.Folder, oFormatFileNameInfo.FileName & ".jpg")

                            CreatJpgSub(oInventorDocument, strFormatFulFileName)

                        End If

                End Select
            Else
                Select Case oInventorDocument.DocumentType
                    Case kDrawingDocumentObject
                        If DWGToolStripButton.Checked = True Then
                            strFormatFulFileName = IO.Path.Combine(oFormatFileNameInfo.Folder, oFormatFileNameInfo.OnlyName & DWG)

                            IdwSaveAsDwgSub(oInventorDocument.FullDocumentName, strFormatFulFileName)
                        End If

                        If DXFToolStripButton.Checked = True Then
                            strFormatFulFileName = IO.Path.Combine(oFormatFileNameInfo.Folder, oFormatFileNameInfo.OnlyName & DXF)

                            IdwSaveAsDwgSub(oInventorDocument.FullDocumentName, strFormatFulFileName)
                        End If

                        If PDFToolStripButton.Checked = True Then
                            strFormatFulFileName = IO.Path.Combine(oFormatFileNameInfo.Folder, oFormatFileNameInfo.OnlyName & PDF)

                            IdwSaveAsPdfSub(oInventorDocument.FullDocumentName, strFormatFulFileName)
                        End If

                        If JPGToolStripButton.Checked = True Then
                            strFormatFulFileName = IO.Path.Combine(oFormatFileNameInfo.Folder, oFormatFileNameInfo.FileName & ".jpg")

                            ExportToBitmap(oInventorDocument, strFormatFulFileName)

                        End If

                    Case kAssemblyDocumentObject, kPartDocumentObject

                        If STPToolStripButton.Checked = True Then
                            strFormatFulFileName = IO.Path.Combine(oFormatFileNameInfo.Folder, oFormatFileNameInfo.OnlyName & STP)
                            AsmIptSaveAsStpSub(oInventorDocument, strFormatFulFileName)

                        End If

                        If XTToolStripButton.Checked = True Then
                            strFormatFulFileName = IO.Path.Combine(oFormatFileNameInfo.Folder, oFormatFileNameInfo.OnlyName & ".x_t")

                            AsmIptSaveAsStpSub(oInventorDocument, strFormatFulFileName)
                        End If

                        If JPGToolStripButton.Checked = True Then

                            strFormatFulFileName = IO.Path.Combine(oFormatFileNameInfo.Folder, oFormatFileNameInfo.FileName & ".jpg")

                            CreatJpgSub(oInventorDocument, strFormatFulFileName)

                        End If

                End Select

            End If

            '关闭，不保存文件

            If 转换后关闭ToolStripButton.Checked = True Then
                oInventorDocument.Close(True)
            End If

            'lvwFileListView.Items(i).Text = strInventorDrawingFullFileName & "        完成"
999:
            intCount += 1
            进度ToolStripProgressBar.Value = intCount
        Next

        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        OInteractionEvents.Stop()
        ThisApplication.SilentOperation = False

        str模型匹配检查标记 = 1

        MessageBox.Show(”格式转换完成。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub 关闭ToolStripButton_Click(sender As Object, e As EventArgs) Handles 关闭ToolStripButton.Click, Me.Closing
        FormManager.CloseAndDisposeForm(Of formFormatConversion)()
    End Sub

End Class