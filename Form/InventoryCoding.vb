Imports System.Windows.Forms
Imports Inventor.SelectionFilterEnum
Imports Inventor.SelectTypeEnum
Imports Inventor.DocumentTypeEnum
Imports Inventor
Imports Microsoft.Office.Interop

Public Class InventoryCoding

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        SetStatusBarText()

        ListView1.Items.Clear()

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

        ' 遍历这些文档

        For Each ReferencedDocument As Document In oAllReferencedDocuments
            Debug.Print(ReferencedDocument.DisplayName)
            Dim oStockNumPartName As StockNumPartName
            oStockNumPartName = GetPropitems(ReferencedDocument)

            Dim LVI As ListViewItem
            LVI = ListView1.Items.Add(oStockNumPartName.PartNum)
            LVI.SubItems.Add(oStockNumPartName.StockNum)
            LVI.SubItems.Add(oStockNumPartName.PartName)
            LVI.SubItems.Add(ReferencedDocument.FullDocumentName)
        Next

      
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        On Error Resume Next
        'PartNum = FindSrtingInSheet(Excel_File_Name, StochNum, Sheet_Name, Table_Array, Col_Index_Num, 0)

        Dim excelApp As Excel.Application
        excelApp = New Excel.Application
        'excelApp.Visible = True

        Excel_File_Name = "E:\软件\Invenotr\Inventor编程\InventorAddIn\code\bin\最新物料编码.xls"
        Dim wb As Excel.Workbook = excelApp.Workbooks.Open(Excel_File_Name, 0, True)
        Dim sht As Excel.Worksheet
        sht = wb.Sheets("物料")

        Dim userange As Excel.Range = Nothing

        Dim Table_Array(10) As String

        Table_Array = Split("A,C,D,E", ",")

        Dim MatchRow As Double


        For Each LVI As ListViewItem In ListView1.Items
            For Each a In Table_Array
                userange = sht.Range(a & ":" & a)
                MatchRow = 0
                MatchRow = excelApp.WorksheetFunction.Match(LVI.SubItems(1).Text, userange, 0)
                If MatchRow <> 0 Then
                    Dim FindRow As String
                    FindRow = "B" & MatchRow
                    Dim FindRowValue As String
                    FindRowValue = sht.Range(FindRow).Value
                    LVI.Text = FindRowValue
                    Exit For
                End If
            Next
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

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim oInventorDocument As Inventor.Document
        Dim FullDocumentName As String
        Dim oCoding As String


        For Each LVI As ListViewItem In ListView1.Items
            oCoding = LVI.Text
            FullDocumentName = LVI.SubItems(3).Text
            If oCoding <> "" Then
                oInventorDocument = ThisApplication.Documents.Open(FullDocumentName, False)
                SetPropitem(oInventorDocument, "成本中心", oCoding)
            End If
        Next

        MsgBox("ok")
    End Sub
End Class