Imports Microsoft.Office.Interop

Module excelcode
    Public Excel_File_Name As String       'excel文件名
    Public Sheet_Name As String          '搜索的表
    Public Table_Array As String            '搜索的范围
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

End Module