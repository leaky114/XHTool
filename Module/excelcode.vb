Imports Microsoft.Office.Interop

Module excelcode
    Public ExcelFullFileName As String       'excel文件名
    Public SheetName As String          '搜索的表
    Public TableArrays As String            '搜索的范围
    Public ColIndexNum As String        '搜索列

    'VLOOKUP (lookup_value, table_array, col_index_num, [range_lookup])

    Public Function VLookUpValue(ByVal strExcelFileName As String, ByVal strStochNum As String, ByVal strSheetName As String, _
                                 ByVal strTableArray As String, ByVal strColIndexNum As String, ByVal intRangeLookUp As Integer) As String

        VLookUpValue = Nothing

        Dim oExcelApplication As Excel.Application
        oExcelApplication = New Excel.Application
        oExcelApplication.Visible = False

        Dim oWorkbook As Excel.Workbook = oExcelApplication.Workbooks.Open(strExcelFileName)
        Dim oWorksheet As Excel.Worksheet
        oWorksheet = oWorkbook.Sheets(SheetName)

        Dim oRange As Excel.Range
        oRange = oWorksheet.Range(strTableArray)

        'Dim oCol_Index_Num(10) As String

        'oCol_Index_Num = Split(oCol_Index_Nums, ",")

        'For Each a In oCol_Index_Num
        VLookUpValue = oExcelApplication.WorksheetFunction.VLookup(strStochNum, oRange, strColIndexNum, intRangeLookUp)
        If VLookUpValue <> Nothing Then
            oWorkbook.Close()
            oExcelApplication.Quit()

            '9.释放资源
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRange)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oWorksheet)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oWorkbook)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcelApplication)

            Return VLookUpValue
        End If
        'Next

        '关闭文件
        oWorkbook.Close()
        ' 8.退出Excel程序
        oExcelApplication.Quit()

        '9.释放资源
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oRange)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oWorksheet)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oWorkbook)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcelApplication)

        '方法来源 https://blog.csdn.net/hsyj_0001/article/details/7686364

        Return VLookUpValue

    End Function


    Public Function FindSrtingInSheet(ByVal strExcelFileName As String, ByVal strStochNum As String, ByVal strSheetName As String, _
                                ByVal strTableArrays As String, ByVal strColIndexNum As String, ByVal intRangeLookup As Integer) As String

        On Error Resume Next
        Dim oExcelApplication As Excel.Application
        oExcelApplication = New Excel.Application
        oExcelApplication.Visible = False

        Dim oWorkbook As Excel.Workbook = oExcelApplication.Workbooks.Open(strExcelFileName)
        Dim oWorksheet As Excel.Worksheet
        oWorksheet = oWorkbook.Sheets(SheetName)

        Dim oRange As Excel.Range
        oRange = oWorksheet.Range(strTableArrays)

        Dim Table_Array(10) As String

        Table_Array = Split(strTableArrays, ",")

        Dim MatchRow As Double

        Dim strFindRowValue As String = Nothing
        For Each sht In oWorkbook.Sheets
            For Each a In Table_Array
                oRange = sht.Range(a & ":" & a)
                MatchRow = oExcelApplication.WorksheetFunction.Match(strStochNum, oRange, 0)
                If MatchRow <> 0 Then
                    Exit For
                End If
            Next

            Dim strFindRow As String
            strFindRow = strColIndexNum & MatchRow

            strFindRowValue = sht.Range(strFindRow).Value
        Next


        '关闭文件
        oWorkbook.Close()
        ' 8.退出Excel程序
        oExcelApplication.Quit()

        '9.释放资源
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oRange)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oWorksheet)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oWorkbook)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcelApplication)

        Return strFindRowValue
    End Function
End Module