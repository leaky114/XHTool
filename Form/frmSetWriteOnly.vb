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

Public Class frmSetWriteOnly

    '量产开始
    Private Sub btn确定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn确定.Click
        On Error Resume Next
        Dim strInventorDocumentFullFileName As String
        Dim strInventorDrawingFullFileName As String


        If lvw文件列表.Items.Count = 0 Then
            MsgBox("未添加文件。", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "批量另存为")
            Exit Sub
        End If


        For Each oListViewItem As ListViewItem In lvw文件列表.Items
            '当前项标记颜色
            'oListViewItem.ForeColor = Drawing.Color.BlueViolet

            If oListViewItem.Checked = True Then

                strInventorDocumentFullFileName = oListViewItem.SubItems(2).Text
                strInventorDrawingFullFileName = oListViewItem.SubItems(5).Text

                If CheckBox模型.Checked = True Then
                    SetFileReadOnly(strInventorDocumentFullFileName, CheckBox只读.Checked)
                End If

                If CheckBox工程图.Checked = True Then
                    SetFileReadOnly(strInventorDrawingFullFileName, CheckBox只读.Checked)
                End If


            End If
        Next

        btn导入当前部件_Click(sender, e)

        MsgBox("设置文件属性完成。", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)


    End Sub

    '关闭
    Private Sub btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click
        lvw文件列表.Items.Clear()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub


    '清空文件列表
    Private Sub btn清空列表_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn清空列表.Click
        lvw文件列表.Items.Clear()
    End Sub



    '移除选择列
    Private Sub btn移出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn移出.Click
        ListViewDel(lvw文件列表)
    End Sub

    Private Sub btn导入当前部件_Click(sender As Object, e As EventArgs) Handles btn导入当前部件.Click

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

        Dim oAssemblyDocument As AssemblyDocument
        oAssemblyDocument = oInventorDocument

        '===================================
        '基于bom结构化数据，可跳过参考的文件
        ' Set a reference to the BOM
        Dim oBOM As BOM
        oBOM = oAssemblyDocument.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True

        'Set a reference to the "Structured" BOMView
        Dim oBOMView As BOMView

        btn导入当前部件.Enabled = False
        'ThisApplication.Cursor  = Cursors.WaitCursor

        lvw文件列表.BeginUpdate()

        '获取结构化的bom页面
        For Each oBOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then
                '遍历这个bom页面
                QueryBOMRowToLoadFile(oBOMView.BOMRows, lvw文件列表)
            End If
        Next


        lvw文件列表.EndUpdate()
        btn导入当前部件.Enabled = True
        'ThisApplication.Cursor  = Cursors.Default


    End Sub

    Private Sub QueryBOMRowToLoadFile(ByVal oBOMRows As BOMRowsEnumerator, ByVal olistiview As ListView)
        Dim i As Integer

        Dim iStepCount As Short
        iStepCount = oBOMRows.Count

        'Create a new ProgressBar object.
        'Dim oProgressBar As Inventor.ProgressBar

        'oProgressBar = ThisApplication.CreateProgressBar(False, iStepCount, "当前文件： ")

        For i = 1 To oBOMRows.Count
            ' Get the current row.
            Dim oBOMRow As BOMRow
            oBOMRow = oBOMRows.Item(i)

            Dim oInventorDocumentFullFileName As String
            oInventorDocumentFullFileName = oBOMRow.ReferencedFileDescriptor.FullFileName

            If InStr(oInventorDocumentFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                GoTo 999
            End If

            If IsFileExsts(oInventorDocumentFullFileName) = False Then   '跳过不存在的文件
                GoTo 999
            End If

            Dim strInventorDocumentFileName As String
            strInventorDocumentFileName = GetFileNameInfo(oInventorDocumentFullFileName).FileName

            Dim strInventorDrawingFullFileName As String
            strInventorDrawingFullFileName = GetChangeExtension(oInventorDocumentFullFileName, IDW)
            Dim strInventorDrawingFileName As String
            strInventorDrawingFileName = GetFileNameInfo(strInventorDrawingFullFileName).FileName


            Dim oListViewItem As ListViewItem
            If IsItemInListView(lvw文件列表, strInventorDocumentFileName) = False Then


                oListViewItem = lvw文件列表.Items.Add(strInventorDocumentFileName)
                oListViewItem.Checked = True

                With oListViewItem

                    If GetFileReadOnly(oInventorDocumentFullFileName) = True Then
                        .SubItems.Add("只读")
                    Else
                        .SubItems.Add("可写")
                    End If

                    .SubItems.Add(oInventorDocumentFullFileName)

                    If IsFileExsts(strInventorDrawingFullFileName) = True Then
                        .SubItems.Add(strInventorDrawingFileName)
                        If GetFileReadOnly(strInventorDrawingFullFileName) = True Then
                            .SubItems.Add("只读")
                        Else
                            .SubItems.Add("可写")
                        End If

                        .SubItems.Add(strInventorDrawingFullFileName)
                    Else
                        .SubItems.Add("")
                    End If

                End With

            End If

            '遍历下一级
            If (Not oBOMRow.ChildRows Is Nothing) Then
                Call QueryBOMRowToLoadFile(oBOMRow.ChildRows, olistiview)
            End If

999:
            'oProgressBar.UpdateProgress()
        Next

        'oProgressBar.Close()

    End Sub

    '窗口打开自动加载当前部件
    Private Sub frmSetWriteOnly_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btn导入当前部件_Click(sender, e)
    End Sub

    Private Sub CheckBox全选_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox全选.CheckedChanged
        lvw文件列表.BeginUpdate()

        For Each oListViewItem As ListViewItem In lvw文件列表.Items
            oListViewItem.Checked = CheckBox全选.Checked
        Next

        lvw文件列表.EndUpdate()

    End Sub

    Private Sub CheckBox本部件_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox本部件.CheckedChanged
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        Dim strInventorDocumentFullFileName As String
        strInventorDocumentFullFileName = oInventorDocument.FullDocumentName

        SetFileReadOnly(strInventorDocumentFullFileName, CheckBox本部件.Checked)

    End Sub
End Class