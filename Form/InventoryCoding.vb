Imports System.Windows.Forms
Imports Inventor.SelectionFilterEnum
Imports Inventor.SelectTypeEnum
Imports Inventor.DocumentTypeEnum
Imports Inventor
Imports Microsoft.Office.Interop

Public Class InventoryCoding

    Private Sub 开始导入数据ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 开始导入数据ToolStripMenuItem.Click
        SetStatusBarText()

        If IsInventorOpenDoc() = False Then
            Exit Sub
        End If

        Dim AsmDoc As AssemblyDocument

        AsmDoc = ThisApplication.ActiveDocument

        If AsmDoc.DocumentType <> kAssemblyDocumentObject Then
            MsgBox("该功能仅适用于部件")
            Exit Sub
        End If

         ' 获取所有引用文档 
        Dim oRefDocs As DocumentsEnumerator
        oRefDocs = AsmDoc.AllReferencedDocuments

        ' 遍历这些文档 
        Dim oRefDoc As Document
        For Each oRefDoc In oRefDocs
            Debug.Print(oRefDoc.DisplayName)
            Dim StockNumPartName As StockNumPartName
            StockNumPartName = GetStockNumPartName(oRefDoc.FullDocumentName)
            ToolStripStatusLabel1.Text = oRefDoc.FullDocumentName
            For Each LVI As ListViewItem In ListView1.Items
                Dim ss As String    '替换/\符号
                LVI.Selected = True
                ss = Strings.Replace(LVI.SubItems(2).Text, "/", "-")
                ss = Strings.Replace(ss, "\", "-")
                If StockNumPartName.StockNum = ss Then
                    StockNumPartName.StockNum = GetPropitem(oRefDoc, Map_StochNum)
                    If StockNumPartName.PartNum = "" Then
                        SetPropitem(oRefDoc, Map_PartNum, LVI.Text)
                        Exit For
                    ElseIf StockNumPartName.PartNum <> LVI.Text Then
                        If MsgBox("替换文件：" & oRefDoc.FullDocumentName & vbCrLf & "原库存编码:" & StockNumPartName.PartNum & vbCrLf & "为新编码：" & LVI.Text & "？", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "替换") = MsgBoxResult.Yes Then
                            SetPropitem(oRefDoc, Map_PartNum, LVI.Text)
                            Exit For
                        End If
                    End If

                End If
            Next

        Next
        SetStatusBarText("导入数据完成")
        MsgBox("导入数据完成！")
    End Sub

    Private Sub 导入Excel文件ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 导入Excel文件ToolStripMenuItem.Click


        Dim ExcelFullFileName As String = Nothing

        '打开文件
        Dim opfile As New OpenFileDialog '声名新open 窗口

        opfile.Title = "打开"
        opfile.Filter = "Excel文件|*.xls;*.xlsx" '添加过滤文件
        opfile.Multiselect = False
        If opfile.ShowDialog = Windows.Forms.DialogResult.OK Then '如果打开窗口OK
            If opfile.FileName <> "" Then '如果有选中文件
                ExcelFullFileName = opfile.FileName
            End If
        Else
            Exit Sub
        End If

        If Lead_InventoryCoding(ExcelFullFileName, ListView1) Then
            SetStatusBarText("导入存货编码完成")
        Else
            SetStatusBarText("错误")
        End If
        'Process.Start(ExcelFullFileName)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub 清空列表ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 清空列表ToolStripMenuItem.Click
        ListView1.Items.Clear()
    End Sub

    Private Sub 退出ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 退出ToolStripMenuItem.Click
        Me.Close()
    End Sub

    '
    Public Function Lead_InventoryCoding(ByVal ExcelFullFileName As String, ByVal LV As ListView) As Boolean

        Dim exapp As Excel.Application  '应用程序
        Dim exbook As Excel.Workbook    '工作薄
        Dim exsheet As Excel.Worksheet  '工作表
        Dim exrange As Excel.Range      '单元格
        Dim exrangevalue As String   '单元格值

        exapp = New Microsoft.Office.Interop.Excel.Application
        exapp.Visible = False
        exbook = exapp.Workbooks.Open(ExcelFullFileName)

        '赋值数组
        Dim oBOMRowData(10000, 3) As String
        Dim k As Integer = 0

        Dim LVI As ListViewItem = Nothing

        '遍历每个工作表

        Dim i As Integer = 0
        Dim j As Integer


        LV.Items.Clear()

        For Each exsheet In exbook.Sheets
            exrange = exsheet.Range("A1")   '目标A1
            exrangevalue = exrange.Value    'A1的值

            Dim rangetitle As String            '赋值单元格
            Dim ranggetitles() As String = {"A", "B", "C"}

            Do Until exrangevalue = Nothing
                For j = 0 To ranggetitles.Length - 1
                    rangetitle = ranggetitles(j) & Trim(Str(1 + i))     '指定单元格
                    exrange = exsheet.Range(rangetitle)
                    exrangevalue = exrange.Value
                    oBOMRowData(k, j) = exrangevalue
                Next



                i = i + 1
                k = k + 1
            Loop
        Next

        exbook.Close()

        For i = 0 To 9999
            If oBOMRowData(i, 0) = Nothing Then
                Exit For
            End If
            LVI = LV.Items.Add(oBOMRowData(i, 0))
            LVI.SubItems.Add(oBOMRowData(i, 1))
            LVI.SubItems.Add(oBOMRowData(i, 2))
        Next



        '删除空项
        'For Each LVI In LV.Items
        '    If LVI.Text = "" Then
        '        LVI.Remove()
        '    End If
        'Next

        '删除同一项
        On Error Resume Next
        With LV
            i = 0
            While i < .Items.Count

                For j = .Items.Count To i + 1 Step -1
                    Dim a As String
                    Dim b As String
                    a = .Items(i).Text & "|" & .Items(i).SubItems(1).Text & "|" & .Items(i).SubItems(2).Text
                    b = .Items(j).Text & "|" & .Items(j).SubItems(1).Text & "|" & .Items(j).SubItems(2).Text
                    If a = b Then
                        .Items(j).Remove()
                    End If
                Next j
                i = i + 1
            End While
        End With

        Return True
    End Function
End Class