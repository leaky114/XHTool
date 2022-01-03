Imports System.Windows.Forms
Imports Inventor.SelectionFilterEnum
Imports Inventor.SelectTypeEnum
Imports Inventor.DocumentTypeEnum
Imports Inventor
Imports Microsoft.Office.Interop

Public Class InventoryCoding

 
    Private Sub loadfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loadfile.Click

        loadfile.Enabled = False
        ListView1.Items.Clear()

        SetStatusBarText()

        If IsInventorOpenDoc() = False Then
            Exit Sub
        End If

        Dim oAssemblyDocument As AssemblyDocument

        oAssemblyDocument = ThisApplication.ActiveDocument

        If oAssemblyDocument.DocumentType <> kAssemblyDocumentObject Then
            MsgBox("该功能仅适用于部件")
            Exit Sub
        End If

        ' 获取所有引用文档
        Dim oAllReferencedDocuments As DocumentsEnumerator
        oAllReferencedDocuments = oAssemblyDocument.AllReferencedDocuments

        With ProgressBar1
            .Minimum = 0
            .Maximum = oAllReferencedDocuments.Count
            .Value = 0
        End With


        ' 遍历这些文档


        For Each ReferencedDocument As Document In oAllReferencedDocuments
            Debug.Print(ReferencedDocument.DisplayName)
            Dim oStockNumPartName As StockNumPartName
            oStockNumPartName = GetPropitems(ReferencedDocument)

            Dim LVI As ListViewItem
            LVI = ListView1.Items.Add(oStockNumPartName.StockNum)
            LVI.SubItems.Add(oStockNumPartName.PartName)
            LVI.SubItems.Add(oStockNumPartName.PartNum)
            LVI.SubItems.Add(ReferencedDocument.FullDocumentName)

            ProgressBar1.Value = ProgressBar1.Value + 1
        Next

        loadfile.Enabled = True

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        On Error Resume Next
        'PartNum = FindSrtingInSheet(Excel_File_Name, StochNum, Sheet_Name, Table_Array, Col_Index_Num, 0)
        OK_Button.Enabled = False

        Dim excelApp As Excel.Application
        excelApp = New Excel.Application

        'excelApp.Visible = True
        'Excel_File_Name = "E:\软件\Invenotr\Inventor编程\InventorAddIn\code\bin\最新物料编码.xls"

        Dim wb As Excel.Workbook = excelApp.Workbooks.Open(Excel_File_Name, 0, True)
        Dim sht As Excel.Worksheet

        sht = wb.Sheets(Sheet_Name)
        sht = wb.Sheets("物料")

        Dim userange As Excel.Range = Nothing

        Dim Table_Array(10) As String

        Table_Array = Split("A,C,D,E", ",")

        Dim MatchRow As Double   '寻找到的行

        With ProgressBar1
            .Minimum = 0
            .Maximum = ListView1.Items.Count
            .Value = 0
        End With

        For Each LVI As ListViewItem In ListView1.Items
            For Each a In Table_Array
                userange = sht.Range(a & ":" & a)
                MatchRow = 0
                MatchRow = excelApp.WorksheetFunction.Match(LVI.Text, userange, 0)

                If MatchRow <> 0.0 Then

                    '当前值
                    Dim NowRangeValue As String = LVI.SubItems(2).Text

                    Dim FindRange As String  '寻找的单元
                    Dim FindRangeValue As String    '寻找的值

                    'FindRange = "B" & MatchRow
                    FindRange = Col_Index_Num & MatchRow
                    FindRangeValue = sht.Range(FindRange).Value

                    If NowRangeValue <> FindRangeValue Then
                        LVI.SubItems(2).Text = FindRangeValue
                        LVI.UseItemStyleForSubItems = False
                        LVI.SubItems(2).ForeColor = Drawing.Color.Red
                        Exit For
                    End If
                End If
            Next

            ProgressBar1.Value = ProgressBar1.Value + 1
        Next

        '关闭文件
        wb.Close()
        ' 8.退出Excel程序
        excelApp.Quit()

        '9.释放资源
        System.Runtime.InteropServices.Marshal.ReleaseComObject(userange)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(sht)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(wb)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp)

        OK_Button.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim oInventorDocument As Inventor.Document
        Dim FullDocumentName As String
        Dim oCoding As String

        Button1.Enabled = False

        With ProgressBar1
            .Minimum = 0
            .Maximum = ListView1.Items.Count
            .Value = 0
        End With

        For Each LVI As ListViewItem In ListView1.Items

            If LVI.SubItems(2).ForeColor = Drawing.Color.Red Then
                LVI.SubItems(2).ForeColor = Drawing.Color.Black  '写入后变为黑色
                oCoding = LVI.SubItems(2).Text
                FullDocumentName = LVI.SubItems(3).Text
                oInventorDocument = ThisApplication.Documents.Open(FullDocumentName, False)
                SetPropitem(oInventorDocument, "成本中心", oCoding)
            End If

            ProgressBar1.Value = ProgressBar1.Value + 1
        Next

        Button1.Enabled = True
    End Sub


End Class