Imports Microsoft.Office.Interop
Imports System.Windows.Forms

Public NotInheritable Class frmImportCodeToBomExcel

    Private Sub btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub btn导入_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn导入.Click
        On Error Resume Next

        Dim strBomExcelFile As String
        Dim intLastLine As Integer
        Dim strDataColumn As String
        Dim strReturnColumn As String

        strBomExcelFile = txtExcel文件.Text

        if IsFileExsts(strBomExcelFile) = False Then
            MsgBox("BOM文件错误！", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "导入ERP编码")
            Exit Sub
        End if

        btn导入.Enabled = False
        Me.UseWaitCursor = True

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

                lbl进度文件.Text = "当前零件： " & strDrawingNo

                Debug.Print(strDrawingNo)

                For Each oExcelWorksheet In oExcelWorkbook.Sheets
                    Dim intMatchRow As Integer = Nothing
                    Dim strFindRowValue As String = Nothing
                    For Each a In Table_Array
                        oExcelRange = oExcelWorksheet.Range(a & ":" & a)
                        intMatchRow = oExcelApplication.WorksheetFunction.Match(strDrawingNo, oExcelRange, 0)
                        if intMatchRow <> 0 Then
                            Exit For
                        End if
                    Next

                    if intMatchRow <> 0 Then
                        Dim strFindRow As String
                        strFindRow = ColIndexNum & intMatchRow
                        strERPCode = oExcelWorksheet.Range(strFindRow).Value
                    Else
                        strERPCode = ""
                    End if
                Next

                'lbl进度文件.Text = "当前零件： " & strDrawingNo & "——" & strERPCode

                Debug.Print(strERPCode)
                if strERPCode <> "" Then
                    strRangeName = strReturnColumn & i
                    oBOMRange = oBOMWorksheet.Range(strRangeName)
                    oBOMRange.Value = strERPCode
                End if
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

        Me.UseWaitCursor = False
        btn导入.Enabled = True

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
            if .ShowDialog = System.Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                if .FileName <> "" Then '如果有选中文件
                    txtExcel文件.Text = .FileName
                    btn导入.Focus()
                End if
            Else
                Exit Sub
            End if
        End With
    End Sub

    Private Sub frmImportCodeToBomExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim toolTip As New ToolTip()
        toolTip.AutoPopDelay = 0
        toolTip.InitialDelay = 0
        toolTip.ReshowDelay = 500
        toolTip.SetToolTip(btn打开excel文件, "打开Excel文件")
        btn打开excel文件.Image = My.Resources.快速打开16.ToBitmap
    End Sub
End Class