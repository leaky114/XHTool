Imports System.Drawing
Imports System.Windows.Forms

Public Class frmOption

    Private Sub btn添加_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn添加.Click
        'If txtBOM导出项.Text = "" Then
        '    txtBOM导出项.Text = cbo添加.Text
        'Else

        '//先获取复制文本
        Dim newstr As String = cbo添加.Text

        If newstr = "| (分隔符)" Then
            newstr = "|"
        End If


        '//获取textBox2 中的光标
        Dim index As Integer = txtBOM导出项.SelectionStart
        txtBOM导出项.Text = txtBOM导出项.Text.Insert(index, newstr)
        txtBOM导出项.SelectionStart = index + newstr.Length
        txtBOM导出项.Focus()
        'End If

    End Sub

    Private Sub btn取消_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn取消.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()

    End Sub

    Private Sub btn清除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn清除.Click
        txtBOM导出项.Clear()
    End Sub

    Private Sub btn确定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn确定.Click
        If cbo图号.Text = cbo文件名.Text Then
            MsgBox("映射设置相同！", MsgBoxStyle.Exclamation, "设置")
            Exit Sub
        End If

        Map_DrawingNnumber = cbo图号.Text
        Map_PartName = cbo文件名.Text
        Map_ERPCode = cbo存货编码.Text
        Map_Vendor = cbo供应商.Text
        Map_Mir_StochNum = txt图号映射.Text
        Map_Mir_PartName = txt文件名映射.Text
        Map_DrawingScale = txt比例.Text
        Map_PrintDay = txt打印日期.Text
        EngineerName = txt工程师.Text
        BOMTiTle = txtBOM导出项.Text
        Map_Mass = txt图号.Text

        BasicExcelFullFileName = txt基础数据文件.Text
        TableArrays = txt查找范围.Text
        ColIndexNum = txt查询列.Text

        '打印签字
        Select Case chk签字后打印.Checked
            Case False
                IsOpenPrint = "-1"
            Case True
                IsOpenPrint = "1"
        End Select

        '同时签字
        Select Case chk同时签字.Checked
            Case False
                IsDayAndName = "-1"
            Case True
                IsDayAndName = "1"
        End Select

        '打开工程图时写入
        Select Case chk保存比例.Checked
            Case False
                IsSetDrawingScale = "-1"
            Case True
                IsSetDrawingScale = "1"
        End Select

        '打开工程图时写入
        Select Case chk保存质量.Checked
            Case False
                IsSetMass = "-1"
            Case True
                IsSetMass = "1"
        End Select

        '启动检查更新
        Select Case chk检查更新.Checked
            Case False
                CheckUpdate = "-1"
            Case True
                CheckUpdate = "1"
        End Select

        '质量精度：
        Select Case cbo质量精度.Text
            Case "", "0"
                Mass_Accuracy = "0"
            Case "0.1"
                Mass_Accuracy = "1"
            Case "0.01"
                Mass_Accuracy = "2"
            Case "0.001"
                Mass_Accuracy = "3"
        End Select

        '面积精度：
        Select Case cbo面积精度.Text
            Case "", "0"
                Area_Accuracy = "0"
            Case "0.1"
                Area_Accuracy = "1"
            Case "0.01"
                Area_Accuracy = "2"
            Case "0.001"
                Area_Accuracy = "3"
            Case "0.0001"
                Area_Accuracy = "4"
            Case "0.00001"
                Area_Accuracy = "5"
            Case "0.000001"
                Area_Accuracy = "6"
        End Select

        'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapStochNum", Map_DrawingNnumber)
        'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapPartName", Map_PartName)
        'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapPartNum", Map_ERPCode)

        'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapMirStochNum", Map_Mir_StochNum)
        'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapMirPartName", Map_Mir_PartName)

        'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapDrawingScale", Map_DrawingScale)
        'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "IsSetDrawingScale", IsSetDrawingScale)

        'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapMass", Map_Mass)
        'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "IsSetMass", IsSetMass)

        'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapPrintDay", Map_PrintDay)
        'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "IsOpenPrint", IsOpenPrint)
        'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "EngineerName", EngineerName)
        'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "IsDayAndName", IsDayAndName)

        'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "BOMTiTle", BOMTiTle)
        'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "Mass_Accuracy", Mass_Accuracy)
        'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "Area_Accuracy", Area_Accuracy)

        'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "CheckUpdate", CheckUpdate)

        'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "Excel_File_Name", ExcelFullFileName)
        'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "Sheet_Name", SheetName)
        'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "Table_Array", TableArrays)
        'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "Col_Index_Num", ColIndexNum)

        Printer = cmb打印机.Text

        '匹配A3
        Select Case chk匹配A3纸.Checked
            Case False
                IsPaperA3 = "-1"
            Case True
                IsPaperA3 = "1"
        End Select

        '签字
        Select Case chk签字.Checked
            Case False
                IsSign = "-1"
            Case True
                IsSign = "1"
        End Select

        '另存为
        SaveAsDawAndPdf = cbo另存为.Text

        TitleBlockIdwDoc = txt图框模板文件.Text

        WrXml.InAISettingXmlWriteSetting()

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub btn图框配置_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn图框配置.Click
        Dim FPath As String = My.Application.Info.DirectoryPath & IIf(Strings.Right(My.Application.Info.DirectoryPath, 1) = "\", "TitleBlock.ini", "\TitleBlock.ini")
        Process.Start("NOTEPAD.EXE", FPath)
    End Sub

    Private Sub btn打开erp数据库_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn打开erp数据库.Click

        'If IsFileExsts(txt自定义数据文件.Text) = True Then
        '    Process.Start(txt自定义数据文件.Text)
        'End If

        If IsFileExsts(BasicExcelFullFileName) = True Then
            Process.Start(BasicExcelFullFileName)
        Else
            'excel文件不存在，到服务器下载
            Dim documentURL As String
            documentURL = Server & ServerExcelFileName

            If IsFileExsts(documentURL) = True Then
                Dim wc As New System.Net.WebClient
                wc.DownloadFile(documentURL, BasicExcelFullFileName)
                Process.Start(BasicExcelFullFileName)
            End If

        End If
    End Sub

    Private Sub btn配置文件_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn配置文件.Click
        Dim FPath As String = My.Application.Info.DirectoryPath & IIf(Strings.Right(My.Application.Info.DirectoryPath, 1) = "\", "InAISetting.xml", "\InAISetting.xml")
        Process.Start("NOTEPAD.EXE", FPath)
    End Sub

    Private Sub btn还原_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn还原.Click
        txtBOM导出项.Text = BOMTiTle
    End Sub

    Private Sub btn更新数据库_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn更新数据库.Click
        '更新数据库文件
        'excel文件不存在，到服务器下载
        Dim documentURL As String
        documentURL = Server & ServerExcelFileName

        If IsFileExsts(documentURL) = True Then
            Dim wc As New System.Net.WebClient
            wc.DownloadFile(documentURL, BasicExcelFullFileName)
            'Process.Start(BasicExcelFullFileName)

        End If
        MsgBox("更新数据库文件完成！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "更新数据库")
    End Sub

    Private Sub frmOption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '初始化映射
        cbo图号.Text = Map_DrawingNnumber
        cbo文件名.Text = Map_PartName
        cbo存货编码.Text = Map_ERPCode
        cbo供应商.Text = Map_Vendor

        cbo添加.Text = cbo添加.Items(0)

        Select Case Mass_Accuracy
            Case "0"
                cbo质量精度.Text = "0"
            Case "1"
                cbo质量精度.Text = "0.1"
            Case "2"
                cbo质量精度.Text = "0.01"
            Case "3"
                cbo质量精度.Text = "0.001"
        End Select

        Select Case Area_Accuracy
            Case "0"
                cbo面积精度.Text = "0"
            Case "1"
                cbo面积精度.Text = "0.1"
            Case "2"
                cbo面积精度.Text = "0.01"
            Case "3"
                cbo面积精度.Text = "0.001"
            Case "4"
                cbo面积精度.Text = "0.0001"
            Case "5"
                cbo面积精度.Text = "0.00001"
            Case "6"
                cbo面积精度.Text = "0.000001"
        End Select

        txt图号映射.Text = Map_Mir_StochNum
        txt文件名映射.Text = Map_Mir_PartName
        txt比例.Text = Map_DrawingScale
        txt打印日期.Text = Map_PrintDay
        txt工程师.Text = EngineerName
        txtBOM导出项.Text = BOMTiTle
        txt图号.Text = Map_Mass

        Select Case IsOpenPrint
            Case "-1"
                chk签字后打印.Checked = False
            Case "1"
                chk签字后打印.Checked = True
        End Select

        Select Case IsDayAndName
            Case "-1"
                chk同时签字.Checked = False
            Case "1"
                chk同时签字.Checked = True
        End Select

        Select Case IsSetDrawingScale
            Case "-1"
                chk保存比例.Checked = False
            Case "1"
                chk保存比例.Checked = True
        End Select

        Select Case IsSetMass
            Case "-1"
                chk保存质量.Checked = False
            Case "1"
                chk保存质量.Checked = True
        End Select

        Select Case CheckUpdate
            Case "-1"
                chk检查更新.Checked = False
            Case "1"
                chk检查更新.Checked = True
        End Select

        txt基础数据文件.Text = BasicExcelFullFileName
        txt查找范围.Text = TableArrays
        txt查询列.Text = ColIndexNum

        '默认打印机
        Dim oPrintDocument As New Printing.PrintDocument
        Dim strDefaultPrinter As String = oPrintDocument.PrinterSettings.PrinterName

        cmb打印机.Items.Clear()
        For Each strPrinterName As String In Printing.PrinterSettings.InstalledPrinters
            cmb打印机.Items.Add(strPrinterName)
            If strPrinterName = strDefaultPrinter Then
                cmb打印机.SelectedIndex = cmb打印机.Items.IndexOf(strPrinterName)
            End If
        Next

        For Each cmblist In cmb打印机.Items
            If cmblist = Printer Then
                cmb打印机.Text = Printer
            End If
        Next

        '匹配A3
        Select Case IsPaperA3
            Case -1
                chk匹配A3纸.Checked = False
            Case 1
                chk匹配A3纸.Checked = True
        End Select

        '签字
        Select Case IsSign
            Case -1
                chk签字.Checked = False
            Case 1
                chk签字.Checked = True
        End Select

        '另存为
        cbo另存为.Text = SaveAsDawAndPdf

        txt图框模板文件.Text = TitleBlockIdwDoc

    End Sub
    Private Sub txt基础数据文件_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txt基础数据文件.DoubleClick
        'If e.Button = System.Windows.Forms.MouseButtons.Left Then

        '    Dim oOpenFileDialog As New OpenFileDialog
        '    With oOpenFileDialog
        '        .Title = "打开"
        '        .FileName = ""
        '        .InitialDirectory = GetFileNameInfo(BasicExcelFullFileName).Folder
        '        .Filter = "Excel(*.xlsx;*.xls)|*.xlsx;*.xls" '添加过滤文件
        '        .Multiselect = False '多开文件打开
        '        .CheckFileExists = False
        '        If .ShowDialog = System.Windows.Forms.DialogResult.OK Then '如果打开窗口OK
        '            If .FileName <> "" Then '如果有选中文件
        '                txt基础数据文件.Text = .FileName
        '            End If
        '        Else
        '            Exit Sub
        '        End If
        '    End With
        'End If
    End Sub

    'Private Sub txt基础数据文件_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt基础数据文件.MouseHover
    '    Dim k As ToolTip

    '    k = New ToolTip()
    '    k.AutoPopDelay = 2000 '显示出气泡后的延时时间（毫秒）
    '    k.InitialDelay = 50 '出现前的延时（毫秒）
    '    k.ToolTipTitle = "" '提示信息标题
    '    k.SetToolTip(txt基础数据文件, "双击更改文件") '提示信息内容
    'End Sub

    Private Sub btn选择工程图模板_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn选择工程图模板.Click
        Dim oOpenFileDialog As New OpenFileDialog
        With oOpenFileDialog
            .Title = "打开"
            .FileName = ""
            .InitialDirectory = ThisApplication.FileOptions.DefaultTemplateDrawingStandard
            .Filter = "Inventor工程图文件(*.idw)|*.idw" '添加过滤文件
            .Multiselect = False '多开文件打开
            .CheckFileExists = True
            If .ShowDialog = System.Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                If .FileName <> "" Then '如果有选中文件
                    txt图框模板文件.Text = .FileName
                    TitleBlockIdwDoc = .FileName
                End If
            Else
                Exit Sub
            End If
        End With
    End Sub


    Private Sub btn选择erp数据库_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn选择erp数据库.Click
        Dim oOpenFileDialog As New OpenFileDialog
        With oOpenFileDialog
            .Title = "打开"
            .FileName = ""
            .InitialDirectory = GetFileNameInfo(BasicExcelFullFileName).Folder
            .Filter = "Excel(*.xlsx;*.xls)|*.xlsx;*.xls" '添加过滤文件
            .Multiselect = False '多开文件打开
            .CheckFileExists = False
            If .ShowDialog = System.Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                If .FileName <> "" Then '如果有选中文件
                    txt基础数据文件.Text = .FileName
                    BasicExcelFullFileName = .FileName
                End If
            Else
                Exit Sub
            End If
        End With

    End Sub
End Class