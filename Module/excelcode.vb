Imports Microsoft.Office.Interop

Module excelcode
    Public Excel_File_Name As String       'excel文件名
    Public Sheet_Name As String          '搜索的表
    Public Table_Arrays As String            '搜索的范围
    Public Col_Index_Num As String        '搜索列

    'VLOOKUP (lookup_value, table_array, col_index_num, [range_lookup])

    Public Function VLookUpValue(ByVal oExcel_File_Name As String, ByVal oStochNum As String, ByVal oSheet_Name As String, _
                                 ByVal oTable_Array As String, ByVal oCol_Index_Num As String, ByVal oRange_LookUp As Integer) As String

        VLookUpValue = Nothing

        Dim excelApp As Excel.Application
        excelApp = New Excel.Application
        excelApp.Visible = True
        Dim wb As Excel.Workbook = excelApp.Workbooks.Open(oExcel_File_Name)
        Dim sht As Excel.Worksheet
        sht = wb.Sheets(Sheet_Name)

        Dim userange As Excel.Range
        userange = sht.Range(oTable_Array)

        'Dim oCol_Index_Num(10) As String

        'oCol_Index_Num = Split(oCol_Index_Nums, ",")

        'For Each a In oCol_Index_Num
        VLookUpValue = excelApp.WorksheetFunction.VLookup(oStochNum, userange, oCol_Index_Num, oRange_LookUp)
        If VLookUpValue <> Nothing Then
            wb.Close()
            excelApp.Quit()

            '9.释放资源
            System.Runtime.InteropServices.Marshal.ReleaseComObject(userange)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(sht)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(wb)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp)

            Return VLookUpValue
        End If
        'Next

        '关闭文件
        wb.Close()
        ' 8.退出Excel程序
        excelApp.Quit()

        '9.释放资源
        System.Runtime.InteropServices.Marshal.ReleaseComObject(userange)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(sht)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(wb)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp)

        '方法来源 https://blog.csdn.net/hsyj_0001/article/details/7686364

        Return VLookUpValue

    End Function


    Public Function FindSrtingInSheet(ByVal Excel_File_Name As String, ByVal StochNum As String, ByVal Sheet_Name As String, _
                                ByVal Table_Arrays As String, ByVal Col_Index_Num As String, ByVal range_lookup As Integer) As String

        On Error Resume Next
        Dim excelApp As Excel.Application
        excelApp = New Excel.Application
        'excelApp.Visible = True
        Dim wb As Excel.Workbook = excelApp.Workbooks.Open(Excel_File_Name, 0, True)
        Dim sht As Excel.Worksheet
        sht = wb.Sheets(Sheet_Name)

        Dim userange As Excel.Range = Nothing

        Dim Table_Array(10) As String

        Table_Array = Split(Table_Arrays, ",")

        Dim MatchRow As Double

        For Each a In Table_Array
            userange = sht.Range(a & ":" & a)
            MatchRow = excelApp.WorksheetFunction.Match(StochNum, userange, 0)
            If MatchRow <> 0 Then
                Exit For
            End If
        Next

        Dim FindRow As String
        FindRow = Col_Index_Num & MatchRow
        Dim FindRowValue As String
        FindRowValue = sht.Range(FindRow).Value



        '关闭文件
        wb.Close()
        ' 8.退出Excel程序
        excelApp.Quit()

        '9.释放资源
        System.Runtime.InteropServices.Marshal.ReleaseComObject(userange)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(sht)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(wb)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp)

        Return FindRowValue
    End Function
End Module