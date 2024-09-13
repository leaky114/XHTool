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

Public Class frmFormatConversion

    Private Sub AddFilesInListView(ByVal oListView As ListView, ByVal oFileList As List(Of String), _
                                      ByVal IsContainIdw As Boolean, ByVal IsContainIpt As Boolean)
        Dim strExtension As String

        For Each strFullFileName As String In oFileList

            If Strings.InStr(strFullFileName, "OldVersions") <> 0 Then
                Continue For
            End If

            If IsFileExsts(strFullFileName) = False Then   '跳过不存在的文件
                Continue For
            End If

            If InStr(strFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                Continue For
            End If

            strExtension = GetFileExtensionLCase(strFullFileName)

            Select Case strExtension
                Case IPT, IAM
                    If IsContainIpt = True Then
                        oListView.Items.Add(strFullFileName)
                    End If
                Case IDW
                    If IsContainIdw = True Then
                        oListView.Items.Add(strFullFileName)
                    End If

            End Select

        Next

    End Sub

    '量产开始
    Private Sub btn转换_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn转换.Click
        On Error Resume Next
        Dim strFormatFullFileName As String = Nothing         'dwg 文件全文件名
        Dim strInventorFullFileName As String = Nothing   '文档文件名

        If lvw文件列表.Items.Count = 0 Then
            MsgBox("未添加文件。", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Exit Sub
        End If


        ThisApplication.SilentOperation = True

        Dim oInteraction As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        oInteraction.Start()
        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        ThisApplication.UserInterfaceManager.DoEvents()

        str模型匹配检查标记 = 3

        ThisApplication.SilentOperation = True

        For Each oListViewItem As ListViewItem In lvw文件列表.Items
            System.Windows.Forms.Application.DoEvents()
            ThisApplication.UserInterfaceManager.DoEvents()

            '当前项标记颜色
            'oListViewItem.ForeColor = Drawing.Color.BlueViolet

            ' 将itemToSelect设置为选中状态
            lvw文件列表.SelectedItems.Clear() ' 清除所有已选中的项
            lvw文件列表.FocusedItem = oListViewItem ' 设置焦点到要选中的项
            oListViewItem.Selected = True

            strInventorFullFileName = oListViewItem.Text


            If IsFileExsts(strInventorFullFileName) = False Then   '跳过不存在的文件
                Continue For
            End If

            'if InStr(InvDocFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
            '    GoTo 999
            'End if

            PublicParameters.str模型匹配检查标记 = 3

            Dim oInventorDocument As Inventor.Document
            oInventorDocument = ThisApplication.Documents.Open(strInventorFullFileName, 静默转换ToolStripButton.Checked Xor True)

            Dim oFileNameInfo As FileNameInfo
            oFileNameInfo = GetFileNameInfo(strInventorFullFileName)

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
        Next

        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        oInteraction.Stop()

        str模型匹配检查标记 = 1

        MsgBox("格式转换完成。", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)


    End Sub

    '关闭
    Private Sub btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click
        lvw文件列表.Items.Clear()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    '添加文件
    Private Sub 添加文件ToolStripButton_Click(sender As Object, e As EventArgs) Handles 添加文件ToolStripButton.Click

        Dim strFilter As String = Nothing

        If 零部件ToolStripButton.Checked = True And 工程图ToolStripButton.Checked = True Then
            strFilter = "Autodesk Inventor文件(*.idw;*.iam;*.ipt)|*.idw;*.iam;*.ipt" '添加过滤文件
        ElseIf 零部件ToolStripButton.Checked = True Then
            strFilter = "Autodesk Inventor 零部件(*.iam;*.ipt)|*.iam;*.ipt|Autodesk Inventor 零(*.ipt)|*.ipt|Autodesk Inventor 部件(*.iam)|*.iam" '添加过滤文件    "AutoCAD Inventor 文件(*.idw;*.iam;*.ipt)|*.idw;*.iam;*.ipt" 
        ElseIf 工程图ToolStripButton.Checked = True Then
            strFilter = "Autodesk Inventor 工程图(*.idw)|*.idw" '添加过滤文件
        End If

        Dim oFileList As List(Of String)
        oFileList = OpenFileDialog(strFilter, True)

        If oFileList Is Nothing Then
            Exit Sub
        End If

        AddFilesInListView(lvw文件列表, oFileList, 工程图ToolStripButton.Checked, 零部件ToolStripButton.Checked)

    End Sub

    '添加文件夹
    Private Sub 添加文件夹ToolStripButton_Click(sender As Object, e As EventArgs) Handles 添加文件夹ToolStripButton.Click
        Dim strDestinationFolder As String = Nothing
        strDestinationFolder = OpenFolderDialog()

        If strDestinationFolder Is Nothing Then
            Exit Sub
        End If

        Dim strExtension As String
        Dim oFileList As List(Of String) = Nothing

        If 零部件ToolStripButton.Checked = True Then
            strExtension = IPT
            oFileList = GetAllFilesByExtension(strDestinationFolder, strExtension)

            AddFilesInListView(lvw文件列表, oFileList, 工程图ToolStripButton.Checked, 零部件ToolStripButton.Checked)

            strExtension = IAM
            oFileList = GetAllFilesByExtension(strDestinationFolder, strExtension)

            AddFilesInListView(lvw文件列表, oFileList, 工程图ToolStripButton.Checked, 零部件ToolStripButton.Checked)

        End If

        If 工程图ToolStripButton.Checked = True Then
            strExtension = IDW
            oFileList = GetAllFilesByExtension(strDestinationFolder, strExtension)

            AddFilesInListView(lvw文件列表, oFileList, 工程图ToolStripButton.Checked, 零部件ToolStripButton.Checked)

        End If

    End Sub

    '当前文件夹
    Private Sub rdo当前文件夹_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If 格式分类ToolStripButton.Checked = True Then
            指定文件夹ToolStripButton.Checked = False
            指定文件夹ToolStripTextBox.Enabled = False
            浏览ToolStripButton.Enabled = False
        End If

    End Sub

    '指定文件夹
    Private Sub rdo同一文件夹_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If 指定文件夹ToolStripButton.Checked = True Then
            格式分类ToolStripButton.Checked = False
            指定文件夹ToolStripTextBox.Enabled = True
            浏览ToolStripButton.Enabled = True
            'Else
            '    RadioButton2.Checked = True
        End If

    End Sub

    '选择文件夹
    Private Sub 浏览ToolStripButton_Click(sender As Object, e As EventArgs) Handles 浏览ToolStripButton.Click
        Dim strInitialDirectory = ThisApplication.FileLocations.Workspace

        Dim strDestinationFolder As String = Nothing
        strDestinationFolder = OpenFolderDialog(strInitialDirectory)

        If strDestinationFolder Is Nothing Then
            Exit Sub
        End If

        指定文件夹ToolStripTextBox.Text = strDestinationFolder
    End Sub

    Private Sub frmSaveAs_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Icon = My.Resources.XHTool48

        Dim toolTip As New ToolTip()
        toolTip.AutoPopDelay = 0
        toolTip.InitialDelay = 0
        toolTip.ReshowDelay = 500

        工程图ToolStripButton.Image = My.Resources.工程图16.ToBitmap
        零部件ToolStripButton.Image = My.Resources.部件16.ToBitmap
        移出文件ToolStripButton.Image = My.Resources.移出文件16.ToBitmap
        清空列表ToolStripButton.Image = My.Resources.清空列表16.ToBitmap
        静默转换ToolStripButton.Image = My.Resources.静默16.ToBitmap
        转换后关闭ToolStripButton.Image = My.Resources.关闭文档16.ToBitmap

        添加文件ToolStripButton.Image = My.Resources.打开文件16.ToBitmap
        添加文件夹ToolStripButton.Image = My.Resources.打开文件夹16.ToBitmap
        从部件导入ToolStripButton.Image = My.Resources.部件16.ToBitmap
        导入当前部件ToolStripButton.Image = My.Resources.当前部件16.ToBitmap
        导入已打开的文件ToolStripButton.Image = My.Resources.内存文件16.ToBitmap

        DWGToolStripButton.Image = My.Resources.另存为Dwg16.ToBitmap
        DXFToolStripButton.Image = My.Resources.另存为Dxf16.ToBitmap
        PDFToolStripButton.Image = My.Resources.另存为Pdf16.ToBitmap
        JPGToolStripButton.Image = My.Resources.图片16.ToBitmap

        STPToolStripButton.Image = My.Resources.零件16.ToBitmap
        XTToolStripButton.Image = My.Resources.零件16.ToBitmap

        格式分类ToolStripButton.Image = My.Resources.格式分类16.ToBitmap
        指定文件夹ToolStripButton.Image = My.Resources.打开文件夹16.ToBitmap
        浏览ToolStripButton.Image = My.Resources.查询16.ToBitmap

        lvw文件列表.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

    End Sub

    '移除选择列
    Private Sub 移出文件ToolStripButton_Click(sender As Object, e As EventArgs) Handles 移出文件ToolStripButton.Click
        ListViewDel(lvw文件列表)
    End Sub

    Private Sub tsmi移出_Click(sender As Object, e As EventArgs) Handles tsmi移出.Click
        移出文件ToolStripButton_Click(sender, e)
    End Sub

    Private Sub lvw文件列表_DragDrop(sender As Object, e As DragEventArgs) Handles lvw文件列表.DragDrop

        Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())

        Dim strExtension As String

        For Each strDestinationFileFolder As String In filePaths

            If IO.Directory.Exists(strDestinationFileFolder) Then

                Dim oFileList As List(Of String) = Nothing

                If 零部件ToolStripButton.Checked = True Then
                    strExtension = IPT
                    oFileList = GetAllFilesByExtension(strDestinationFileFolder, strExtension)

                    AddFilesInListView(lvw文件列表, oFileList, 工程图ToolStripButton.Checked, 零部件ToolStripButton.Checked)

                    'For Each strFullFileName As String In oFileList
                    '    If Strings.InStr(strFullFileName, "OldVersions") = 0 Then
                    '        If IsItemInListView(lvw文件列表, strFullFileName) = False Then
                    '            lvw文件列表.Items.Add(strFullFileName)
                    '        End If
                    '    End If
                    'Next

                    strExtension = IAM
                    oFileList = GetAllFilesByExtension(strDestinationFileFolder, strExtension)

                    AddFilesInListView(lvw文件列表, oFileList, 工程图ToolStripButton.Checked, 零部件ToolStripButton.Checked)

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

                    AddFilesInListView(lvw文件列表, oFileList, 工程图ToolStripButton.Checked, 零部件ToolStripButton.Checked)

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

                If IsItemInListView(lvw文件列表, strDestinationFileFolder) = False Then

                    strExtension = GetFileExtensionLCase(strDestinationFileFolder)

                    Select Case strExtension
                        Case IPT, IAM
                            If 零部件ToolStripButton.Checked = True Then
                                lvw文件列表.Items.Add(strDestinationFileFolder)
                            End If
                        Case IDW
                            If 工程图ToolStripButton.Checked = True Then
                                lvw文件列表.Items.Add(strDestinationFileFolder)
                            End If

                    End Select

                End If



            End If

        Next

    End Sub

    Private Sub lvw文件列表_DragEnter(sender As Object, e As DragEventArgs) Handles lvw文件列表.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub


    Private Sub lvw文件列表_KeyDown(sender As Object, e As KeyEventArgs) Handles lvw文件列表.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                ListViewDel(lvw文件列表)
        End Select
    End Sub

    '清空文件列表
    Private Sub 清空列表ToolStripButton_Click(sender As Object, e As EventArgs) Handles 清空列表ToolStripButton.Click
        lvw文件列表.Items.Clear()
    End Sub

    Private Sub tsmi清空_Click(sender As Object, e As EventArgs) Handles tsmi清空.Click
        清空列表ToolStripButton_Click(sender, e)
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
        Dim strFullFileName As String

        If ThisApplication.Documents.VisibleDocuments.Count = 0 Then
            Exit Sub
        End If

        For Each oInventorDocument In ThisApplication.Documents.VisibleDocuments
            strFullFileName = oInventorDocument.FullDocumentName
            If IsItemInListView(lvw文件列表, strFullFileName) = False Then

                If GetFileExtensionLCase(strFullFileName) = IDW And 工程图ToolStripButton.Checked = True Then
                    lvw文件列表.Items.Add(strFullFileName)
                End If

                If GetFileExtensionLCase(strFullFileName) = IPT And 零部件ToolStripButton.Checked = True Then
                    lvw文件列表.Items.Add(strFullFileName)
                End If

                If GetFileExtensionLCase(strFullFileName) = IAM And 零部件ToolStripButton.Checked = True Then
                    lvw文件列表.Items.Add(strFullFileName)
                End If

            End If

        Next

    End Sub

    Private Sub 导入当前部件ToolStripButton_Click(sender As Object, e As EventArgs) Handles 导入当前部件ToolStripButton.Click

        lvw文件列表.Items.Clear()

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

        Dim oInventorAssemblyDocument As AssemblyDocument
        oInventorAssemblyDocument = oInventorDocument

        Dim oInteraction As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        oInteraction.Start()
        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        ThisApplication.UserInterfaceManager.DoEvents()
        '===================================
        '基于bom结构化数据，可跳过参考的文件
        ' Set a reference to the BOM
        Dim oBOM As BOM
        oBOM = oInventorAssemblyDocument.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True

        'Set a reference to the "Structured" BOMView
        Dim oBOMView As BOMView

        'ThisApplication.Cursor  = Cursors.WaitCursor

        lvw文件列表.BeginUpdate()

        '获取结构化的bom页面
        For Each oBOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                '遍历这个bom页面
                QueryBOMRowToLoadFile(oBOMView.BOMRows, lvw文件列表, 工程图ToolStripButton.Checked, 零部件ToolStripButton.Checked)
            End If
        Next

        lvw文件列表.EndUpdate()

        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        oInteraction.Stop()

    End Sub

    Private Sub QueryBOMRowToLoadFile(ByVal oBOMRows As BOMRowsEnumerator, ByVal olistiview As ListView, _
                                      ByVal IsContainIdw As Boolean, ByVal IsContainIpt As Boolean)
        'Create a new ProgressBar object.
        'Dim oProgressBar As Inventor.ProgressBar
        'oProgressBar = ThisApplication.CreateProgressBar(False, iStepCount, "当前文件： ")


        Dim strFullFileNames As New List(Of String)()


        For Each oBomRow As BOMRow In oBOMRows
            Dim strDocumentFullFileName As String = oBomRow.ReferencedFileDescriptor.FullFileName

            If IsContainIpt Then
                strFullFileNames.Add(strDocumentFullFileName)
            End If


            If IsContainIdw = True Then
                Dim strDrawingFullName As String
                strDrawingFullName = GetChangeExtensionDocument(strDocumentFullFileName, IDW)
                If strDrawingFullName <> "" Then
                    strFullFileNames.Add(strDrawingFullName)
                End If
            End If

        Next

        AddFilesInListView(olistiview, strFullFileNames, IsContainIdw, IsContainIpt)

        For Each oBomrow As BOMRow In oBOMRows
            '遍历下一级
            If (Not oBomrow.ChildRows Is Nothing) Then
                Call QueryBOMRowToLoadFile(oBomrow.ChildRows, olistiview, IsContainIdw, IsContainIpt)
            End If

999:
            'oProgressBar.UpdateProgress()
        Next

    End Sub

    Private Sub 从部件导入ToolStripButton_Click(sender As Object, e As EventArgs) Handles 从部件导入ToolStripButton.Click
        Dim oInteraction As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        oInteraction.Start()
        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        ThisApplication.UserInterfaceManager.DoEvents()

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument = Nothing
        Dim strFilter As String = Nothing

        strFilter = "Autodesk Inventor 部件(*.iam)|*.iam" '添加过滤文件

        Dim arrayFullFileName As List(Of String)
        arrayFullFileName = OpenFileDialog(strFilter, False)

        If arrayFullFileName Is Nothing Then
            Exit Sub
        End If

        oInventorAssemblyDocument = ThisApplication.Documents.Open(arrayFullFileName.Item(0).ToString)

        '===================================
        '基于bom结构化数据，可跳过参考的文件
        ' Set a reference to the BOM
        Dim oBOM As BOM
        oBOM = oInventorAssemblyDocument.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True

        'Set a reference to the "Structured" BOMView
        Dim oBOMView As BOMView

        lvw文件列表.BeginUpdate()

        '获取结构化的bom页面
        For Each oBOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                '遍历这个bom页面
                QueryBOMRowToLoadFile(oBOMView.BOMRows, lvw文件列表, 工程图ToolStripButton.Checked, 零部件ToolStripButton.Checked)
            End If
        Next

        lvw文件列表.EndUpdate()

        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        oInteraction.Stop()

    End Sub


End Class