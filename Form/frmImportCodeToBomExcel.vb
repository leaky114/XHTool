Imports Microsoft.Office.Interop
Imports System.Windows.Forms

Public NotInheritable Class frmImportCodeToBomExcel

    Private Sub btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub 确定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn确定.Click
        On Error Resume Next

        Dim strBomExcelFile As String
        Dim intLastLine As Integer
        Dim strDataColumn As String
        Dim strReturnColumn As String

        strBomExcelFile = txtExcel文件.Text

        If IsFileExsts(strBomExcelFile) = False Then
            MsgBox("BOM文件错误！", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "导入ERP编码")
            Exit Sub
        End If

        btn确定.Enabled = False
        'ThisApplication.Cursor  = Cursors.WaitCursor

        intLastLine = txt最后行.Text
        strDataColumn = cmb查找列.Text
        strReturnColumn = cmb写入列.Text

        Dim oExcelApplication As Excel.Application
        oExcelApplication = New Excel.Application
        oExcelApplication.Visible = False

        'bom表文件
        Dim oBOMWorkbook As Excel.Workbook = oExcelApplication.Workbooks.Open(strBomExcelFile)
        Dim oBOMWorksheet As Excel.Worksheet = Nothing
        Dim oBOMRange As Excel.Range = Nothing

        '数据库文件
        Dim oExcelWorkbook As Excel.Workbook = oExcelApplication.Workbooks.Open(BasicExcelFullFileName)
        Dim oExcelWorksheet As Excel.Worksheet = Nothing
        Dim oExcelRange As Excel.Range = Nothing

        Dim strRangeName As String
        Dim strDrawingNo As String

        Dim strERPCode As String = Nothing

        Dim Table_Array(10) As String
        Table_Array = Split(TableArrays, ",")

        For Each oBOMWorksheet In oBOMWorkbook.Sheets

            prgProcess.Minimum = 0
            prgProcess.Maximum = intLastLine
            For i = 1 To intLastLine
                prgProcess.Value = i
                strERPCode = ""
                strRangeName = strDataColumn & i
                oBOMRange = oBOMWorksheet.Range(strRangeName)
                strDrawingNo = oBOMRange.Text.ToString

                Debug.Print(strDrawingNo)

                For Each oExcelWorksheet In oExcelWorkbook.Sheets
                    Dim intMatchRow As Integer = Nothing
                    Dim strFindRowValue As String = Nothing
                    For Each a In Table_Array
                        oExcelRange = oExcelWorksheet.Range(a & ":" & a)
                        intMatchRow = oExcelApplication.WorksheetFunction.Match(strDrawingNo, oExcelRange, 0)
                        If intMatchRow <> 0 Then
                            Exit For
                        End If
                    Next

                    If intMatchRow <> 0 Then
                        Dim strFindRow As String
                        strFindRow = ColIndexNum & intMatchRow
                        strERPCode = oExcelWorksheet.Range(strFindRow).Value
                    Else
                        strERPCode = ""
                    End If
                Next

                Debug.Print(strERPCode)
                If strERPCode <> "" Then
                    strRangeName = strReturnColumn & i
                    oBOMRange = oBOMWorksheet.Range(strRangeName)
                    oBOMRange.Value = strERPCode
                End If
            Next

        Next

        oBOMWorkbook.Save()

        '关闭文件
        oBOMWorkbook.Close()
        oExcelWorkbook.Close()
        ' 8.退出Excel程序
        oExcelApplication.Quit()

        '9.释放资源
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcelRange)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oBOMRange)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oBOMWorksheet)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcelWorksheet)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oBOMWorkbook)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcelApplication)

        '10.调用GC的垃圾收集方法
        GC.Collect()
        GC.WaitForPendingFinalizers()

        MsgBox("写入ERP编码完成！", MsgBoxStyle.OkOnly, "导入ERP编码")

        btn确定.Enabled = True

        Process.Start(strBomExcelFile)
    End Sub

    Private Sub btn打开excel文件_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn打开excel文件.Click
        Dim oOpenFileDialog As New OpenFileDialog
        With oOpenFileDialog
            .Title = "打开"
            .FileName = ""
            .InitialDirectory = System.Environment.SpecialFolder.Desktop
            .Filter = "Excel 工作薄(*.xlsx;*.xls)|*.xlsx;*.xls" '添加过滤文件
            .Multiselect = False '多开文件打开
            If .ShowDialog = System.Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                If .FileName <> "" Then '如果有选中文件
                    txtExcel文件.Text = .FileName
                End If
            Else
                Exit Sub
            End If
        End With
    End Sub

    Private Sub frmImportCodeToBomExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class