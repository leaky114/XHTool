Imports Microsoft.Office.Interop
Imports System.Windows.Forms
Imports Inventor
Imports System.Collections.Generic

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

        If IsFileExsts(strBomExcelFile) = False Then
            MsgBox("BOM文件错误！", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "导入ERP编码")
            Exit Sub
        End If

        Dim oInteraction As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        oInteraction.Start()
        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        ThisApplication.UserInterfaceManager.DoEvents()

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

        Dim arrayTable(20) As String
        arrayTable = Split(TableArrays, ",")

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
                    For Each strTable As String In arrayTable
                        oExcelRange = oExcelWorksheet.Range(strTable & ":" & strTable)
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

                'lbl进度文件.Text = "当前零件： " & strDrawingNo & "——" & strERPCode

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

        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        oInteraction.Stop()

        MsgBox("写入ERP编码完成！", MsgBoxStyle.OkOnly, "导入ERP编码")

        Process.Start(strBomExcelFile)
    End Sub

    Private Sub btn打开excel文件_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn打开excel文件.Click
        Dim strFilter As String = Nothing
        strFilter = "Excel 工作薄(*.xlsx;*.xls)|*.xlsx;*.xls" '添加过滤文件

        Dim strInitialDirectory As String = Microsoft.VisualBasic.FileIO.SpecialDirectories.Desktop

        Dim arrayFullFileName As List(Of String)
        arrayFullFileName = OpenFileDialog(strFilter, False, strInitialDirectory)

        If arrayFullFileName Is Nothing Then
            Exit Sub
        Else
            txtExcel文件.Text = arrayFullFileName.Item(0).ToString
        End If

    End Sub

    Private Sub frmImportCodeToBomExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48
        Dim toolTip As New ToolTip()
        toolTip.AutoPopDelay = 0
        toolTip.InitialDelay = 0
        toolTip.ReshowDelay = 500
        toolTip.SetToolTip(btn打开excel文件, "打开Excel文件")
        btn打开excel文件.Image = My.Resources.打开文件16.ToBitmap
    End Sub
End Class