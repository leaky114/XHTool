Imports Microsoft.Office.Interop

Module excelcode
    Public Excel_File_Name As String       'excel文件名
    Public Sheet_Name As String          '搜索的表
    Public Table_Array As String            '搜索的范围
    Public Col_Index_Num As String        '搜索列

    'VLOOKUP (lookup_value, table_array, col_index_num, [range_lookup])

    Public Function VLookUpValue(ByVal oExcel_File_Name As String, ByVal oStochNum As String, ByVal oSheet_Name As String, _
                                 ByVal oTable_Array As String, ByVal oCol_Index_Num As String, ByVal oRange_LookUp As Integer) As String

        Dim xlApp As Excel.Application
        xlApp = New Excel.Application
        Dim wb As Excel.Workbook = xlApp.Workbooks.Open(oExcel_File_Name)
        Dim sht As Excel.Worksheet
        sht = wb.Sheets(Sheet_Name)

        Dim userange As Excel.Range
        userange = sht.Range(oTable_Array)

        VLookUpValue = xlApp.WorksheetFunction.VLookup(oStochNum, userange, oCol_Index_Num, oRange_LookUp)


        Return VLookUpValue
    End Function
End Module
