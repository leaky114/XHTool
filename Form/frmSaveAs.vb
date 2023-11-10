Imports Inventor
Imports Microsoft
Imports Microsoft.VisualBasic
'Imports Microsoft.VisualBasic.Compatibility
Imports stdole
Imports System
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Windows.Forms

Public Class frmSaveAs

    '量产开始
    Private Sub btn开始_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn开始.Click
        On Error Resume Next
        Dim strDwgFullFileName As String = Nothing         'dwg 文件全文件名
        Dim strPdfFullFileName As String = Nothing         'pdf 文件全文件名
        Dim strJpgFullFileName As String = Nothing      'jpg文件全文件名
        Dim strStpFullFileName As String = Nothing      'stp文件全文件名
        Dim strInventorFullFileName As String = Nothing   '文档文件名

        If lvw文件列表.Items.Count = 0 Then
            MsgBox("未添加文件。", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "批量另存为")
            Exit Sub
        End If

        Dim oInteraction As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        oInteraction.Start()
        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)

        For i = 0 To lvw文件列表.Items.Count - 1
            '当前项标记颜色
            lvw文件列表.Items(i).ForeColor = Drawing.Color.BlueViolet

            strInventorFullFileName = lvw文件列表.Items(i).Text

            If IsFileExsts(strInventorFullFileName) = False Then   '跳过不存在的文件
                GoTo 999
            End If

            'If InStr(InvDocFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
            '    GoTo 999
            'End If

            Dim intSaveModel As Integer

            intSaveModel = chkDwg.CheckState + chkPdf.CheckState * 2 + chkStep.CheckState * 4

            If intSaveModel = 0 Then
                MsgBox("未选择另存为的文件类型！", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "批量另存为")
                Exit Sub
            End If

            '当前文件夹
            If rdo当前文件夹.Checked = True Then
                strDwgFullFileName = GetChangeExtension(strInventorFullFileName, DWG)   'Strings.Replace(strInventorFullFileName, LCaseGetFileExtension(strInventorFullFileName), ".dwg")
                strPdfFullFileName = GetChangeExtension(strInventorFullFileName, PDF) 'Strings.Replace(strInventorFullFileName, LCaseGetFileExtension(strInventorFullFileName), ".pdf")
                strStpFullFileName = GetChangeExtension(strInventorFullFileName, STP) ' Strings.Replace(strInventorFullFileName, LCaseGetFileExtension(strInventorFullFileName), ".bmp")
            End If

            '同一文件夹
            If rdo同一文件夹.Checked = True Then

                Dim Present_Folder As String       '指定文件夹
                Present_Folder = txt文件夹路径.Text

                If IsDirectoryExists(Present_Folder) = False Then
                    IO.Directory.CreateDirectory(Present_Folder)
                    'Exit Sub
                End If

                'strDwgFullFileName = Strings.Replace(strInventorFullFileName, GetParentFolder(strInventorFullFileName), Present_Folder)
                'strPdfFullFileName = Strings.Replace(strInventorFullFileName, GetParentFolder(strInventorFullFileName), Present_Folder)
                'strJpgFullFileName = Strings.Replace(strInventorFullFileName, GetParentFolder(strInventorFullFileName), Present_Folder)

                strDwgFullFileName = Present_Folder & "\" & GetOnlyname(strInventorFullFileName) & DWG
                strPdfFullFileName = Present_Folder & "\" & GetOnlyname(strInventorFullFileName) & PDF
                strStpFullFileName = Present_Folder & "\" & GetOnlyname(strInventorFullFileName) & STP

            End If

            Dim oInventorDocument As Inventor.Document

            Select Case intSaveModel
                Case 1
                    oInventorDocument = ThisApplication.Documents.Open(strInventorFullFileName, True)
                    'oInventorDocument.SaveAs(strDwgFullFileName, True)
                    IdwSaveAsDwgSub(strInventorFullFileName, strDwgFullFileName)
                    oInventorDocument.Close(True)
                Case 2
                    oInventorDocument = ThisApplication.Documents.Open(strInventorFullFileName, True)
                    oInventorDocument.SaveAs(strPdfFullFileName, True)
                    oInventorDocument.Close(True)
                Case 3
                    oInventorDocument = ThisApplication.Documents.Open(strInventorFullFileName, True)
                    oInventorDocument.SaveAs(strDwgFullFileName, True)
                    oInventorDocument.SaveAs(strPdfFullFileName, True)
                    oInventorDocument.Close(True)

                Case 4
                    oInventorDocument = ThisApplication.Documents.Open(strInventorFullFileName, True)
                    oInventorDocument.SaveAs(strStpFullFileName, True)
                    oInventorDocument.Close(True)
            End Select

            '关闭，不保存文件

            'lvwFileListView.Items(i).Text = strInventorDrawingFullFileName & "        完成"
999:
        Next

        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        oInteraction.Stop()

        MsgBox("批量另存完成。", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "批量另存")



    End Sub

    '关闭
    Private Sub btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click
        lvw文件列表.Items.Clear()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    '添加文件
    Private Sub btn添加文件_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn添加文件.Click
        '打开文件
        Dim oOpenFileDialog As New OpenFileDialog '声名新open 窗口

        With oOpenFileDialog
            .Title = "打开"
            If chkStep.Checked = True Then
                .Filter = "AutoDesk Inventor 零件(*.ipt)|*.ipt" '添加过滤文件
            Else
                .Filter = "AutoDesk Inventor 工程图(*.idw)|*.idw" '添加过滤文件
            End If

            .Multiselect = True '多开文件打开
            If .ShowDialog = Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                If .FileName <> "" Then '如果有选中文件

                    btn添加文件.Enabled = False
                    'ThisApplication.Cursor  = Cursors.WaitCursor

                    For Each strFullFileName As String In .FileNames
                        lvw文件列表.Items.Add(strFullFileName)
                    Next

                    btn添加文件.Enabled = True
                    'ThisApplication.Cursor  = Cursors.Default

                End If
            Else
                Exit Sub
            End If
        End With
    End Sub

    '清空文件列表
    Private Sub btn清空列表_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn清空列表.Click
        lvw文件列表.Items.Clear()
    End Sub

    '添加文件夹
    Private Sub btn添加文件夹_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn添加文件夹.Click
        Dim strDestinationFolder As String = Nothing
        Dim oFileAttributes As FileAttributes
        Dim strPresentFolder As String = Nothing
        Dim oFolderBrowserDialog As New FolderBrowserDialog

        With oFolderBrowserDialog
            .ShowNewFolderButton = False
            .Description = "添加文件夹"
            .RootFolder = System.Environment.SpecialFolder.Desktop
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                strDestinationFolder = .SelectedPath
            Else
                Exit Sub
            End If
        End With

        btn添加文件夹.Enabled = False
        'ThisApplication.Cursor  = Cursors.WaitCursor

        '是否为文件夹，在其后添加 \，得到父文件夹
        oFileAttributes = FileSystem.GetAttr(strDestinationFolder)

        If oFileAttributes = FileAttributes.Directory Then
            strDestinationFolder = strDestinationFolder + "\"
            strPresentFolder = My.Computer.FileSystem.GetParentPath(strDestinationFolder)
        End If

        Dim strExtension As String
        If chkStep.Checked = True Then
            strExtension = IPT
        Else
            strExtension = IDW
        End If

        Dim oInteraction As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        oInteraction.Start()
        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)

        GetAllFile(strPresentFolder, strDestinationFolder, lvw文件列表, strExtension)

        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        oInteraction.Stop()
        btn添加文件夹.Enabled = True


    End Sub

    '当前文件夹
    Private Sub rdo当前文件夹_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo当前文件夹.CheckedChanged

        If rdo当前文件夹.Checked = True Then
            rdo同一文件夹.Checked = False
            txt文件夹路径.Enabled = False
            btn设置文件夹.Enabled = False
        End If

    End Sub

    '指定文件夹
    Private Sub rdo同一文件夹_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo同一文件夹.CheckedChanged

        If rdo同一文件夹.Checked = True Then
            rdo当前文件夹.Checked = False
            txt文件夹路径.Enabled = True
            btn设置文件夹.Enabled = True
            'Else
            '    RadioButton2.Checked = True
        End If

    End Sub

    '移除选择列
    Private Sub btn移出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn移出.Click
        ListViewDel(lvw文件列表)
    End Sub

    '选择文件夹
    Private Sub btn设置文件夹_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn设置文件夹.Click
        Dim strDestinationFolder As String = Nothing
        Dim oFileAttributes As FileAttributes
        Dim strPresentFolder As String = Nothing
        Dim oFolderBrowserDialog As New FolderBrowserDialog

        strPresentFolder = txt文件夹路径.Text

        If IsDirectoryExists(strPresentFolder) = False Then
            strPresentFolder = System.Environment.SpecialFolder.MyComputer
        End If

        With oFolderBrowserDialog
            .Description = "选择文件夹"
            .ShowNewFolderButton = True
            .SelectedPath = strPresentFolder
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                strDestinationFolder = .SelectedPath
            Else
                Exit Sub
            End If
        End With

        '是否为文件夹，在其后添加 \
        oFileAttributes = FileSystem.GetAttr(strDestinationFolder)

        If oFileAttributes = FileAttributes.Directory Then
            strDestinationFolder = strDestinationFolder + "\"
        End If

        txt文件夹路径.Text = strDestinationFolder
    End Sub

    Private Sub chkDwg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDwg.CheckedChanged
        If chkDwg.Checked = True Then
            chkStep.Checked = False
        End If
    End Sub

    Private Sub chkPdf_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPdf.CheckedChanged
        If chkPdf.Checked = True Then
            chkStep.Checked = False
        End If
    End Sub

    Private Sub chkStep_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStep.CheckedChanged
        If chkStep.Checked = True Then
            chkDwg.Checked = False
            chkPdf.Checked = False
        End If

    End Sub

    Private Sub frmSaveAs_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class