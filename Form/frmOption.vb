Imports System.Drawing
Imports System.Windows.Forms

Public Class frmOption

    Private Sub btn添加_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn添加.Click
        'if txtBOM导出项.Text = "" Then
        '    txtBOM导出项.Text = cbo添加.Text
        'Else

        '//先获取复制文本
        Dim newstr As String = cbo添加.Text

        if newstr = "| (分隔符)" Then
            newstr = "|"
        End if


        '//获取textBox2 中的光标
        Dim index As Integer = txtBOM导出项.SelectionStart
        txtBOM导出项.Text = txtBOM导出项.Text.Insert(index, newstr)
        txtBOM导出项.SelectionStart = index + newstr.Length
        txtBOM导出项.Focus()
        'End if

    End Sub

    Private Sub btn取消_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn取消.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()

    End Sub

    Private Sub btn清除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn清除.Click
        txtBOM导出项.Clear()
    End Sub

    Private Sub btn确定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn确定.Click
        if cbo图号.Text = cbo文件名.Text Then
            MsgBox("映射设置相同！", MsgBoxStyle.Exclamation, "设置")
            Exit Sub
        End if

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

        str变更工程图扩展名 = Iif(chk备份工程图.Checked, "1", "-1")
        str另存到子文件夹 = IIf(chk另存到子文件夹.Checked, "1", "-1")
        str查找文件夹层数 = NUD查找文件夹层数.Value
        Is检查重复图号 = IIf(chk检查重复图号.Checked, "1", "-1")


        str模型匹配检查 = Iif(chk模型匹配检查.Checked, "1", "-1")
        str逆时针序号 = Iif(chk逆时针序号.Checked, "1", "-1")


        '打印签字
        IsOpenPrint = Iif(chk签字后打印.Checked, "1", "-1")


        '同时签字
        IsDayAndName = Iif(chk同时签字.Checked, "1", "-1")


        '打开工程图时写入

        IsSetDrawingScale = Iif(chk保存比例.Checked, "1", "-1")


        '打开工程图时写入

        IsSetMass = Iif(chk保存质量.Checked, "1", "-1")


        '启动检查更新
        CheckUpdate = Iif(chk检查更新.Checked, "1", "-1")


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

        Printer = cbo打印机.Text

        '匹配A3
        IsPaperA3 = Iif(chk匹配A3纸.Checked, "1", "-1")

        '签字
        IsSign = Iif(chk签字.Checked, "1", "-1")


        '另存为
        SaveAsDawAndPdf = cbo另存为.Text


        str展开图模板 = txt展开图模板.Text
        str向上线宽 = cbo向上线宽.Text
        str向下线宽 = cbo向下线宽.Text

        str向上线型 = cbo向上线型.Text
        str向下线型 = cbo向下线型.Text

        str展开图标注 = Iif(chk展开图标注.Checked, "1", "-1")


        str工程图模板 = txt工程图模板.Text
        str自动展开图 = Iif(chk钣金自动展开.Checked, "1", "-1")
        str第三视角 = Iif(chk第三视角.Checked, "1", "-1")
        str相切边 = Iif(chk相切边.Checked, "1", "-1")
        str螺纹特征 = Iif(chk螺纹特征.Checked, "1", "-1")
        str标注尺寸 = Iif(chk标注尺寸.Checked, "1", "-1")
        str样式 = Iif(rdo不显示隐藏线.Checked, "不显示隐藏线", "显示隐藏线")


        str选择视图.str左视图 = Iif(chk左视图.Checked, "1", "-1")
        str选择视图.str右视图 = Iif(chk右视图.Checked, "1", "-1")
        str选择视图.str俯视图 = Iif(chk俯视图.Checked, "1", "-1")
        str选择视图.str仰视图 = Iif(chk仰视图.Checked, "1", "-1")

        str页边距.short上边距 = NumericUpDown页边距上.Value
        str页边距.short下边距 = NumericUpDown页边距下.Value
        str页边距.short左边距 = NumericUpDown页边距左.Value
        str页边距.short右边距 = NumericUpDown页边距右.Value

        str部件图框 = txt部件图框.Text
        str零件图框 = txt零件图框.Text

        WrIni.InAISettingIniWriteSetting()
        'WrXml.InAISettingXmlWriteSetting()

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub btn图框配置_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn图框配置.Click
        Dim FPath As String = My.Application.Info.DirectoryPath & Iif(Strings.Right(My.Application.Info.DirectoryPath, 1) = "\", "TitleBlock.ini", "\TitleBlock.ini")
        Process.Start("NOTEPAD.EXE", FPath)
    End Sub

    Private Sub btn打开erp数据库_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn打开erp数据库.Click

        'if IsFileExsts(txt自定义数据文件.Text) = True Then
        '    Process.Start(txt自定义数据文件.Text)
        'End if

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
        Dim FPath As String = My.Application.Info.DirectoryPath & Iif(Strings.Right(My.Application.Info.DirectoryPath, 1) = "\", "InAISetting.ini", "\InAISetting.ini")
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


        chk签字后打印.Checked = IIf(IsOpenPrint = "1", True, False)

        chk同时签字.Checked = IIf(IsDayAndName = "1", True, False)

        chk保存比例.Checked = IIf(IsSetDrawingScale = "1", True, False)

        chk保存质量.Checked = IIf(IsSetMass = "1", True, False)

        chk检查更新.Checked = IIf(CheckUpdate = "1", True, False)

        txt基础数据文件.Text = BasicExcelFullFileName
        txt查找范围.Text = TableArrays
        txt查询列.Text = ColIndexNum

        chk备份工程图.Checked = IIf(str变更工程图扩展名 = "1", True, False)
        chk另存到子文件夹.Checked = IIf(str另存到子文件夹 = "1", True, False)
        NUD查找文件夹层数.Value = str查找文件夹层数
        chk检查重复图号.Checked = IIf(Is检查重复图号 = "1", True, False)


        chk模型匹配检查.Checked = IIf(str模型匹配检查 = "1", True, False)
        chk逆时针序号.Checked = IIf(str逆时针序号 = "1", True, False)


        '默认打印机
        Dim oPrintDocument As New Printing.PrintDocument
        Dim strDefaultPrinter As String = oPrintDocument.PrinterSettings.PrinterName

        cbo打印机.Items.Clear()
        For Each strPrinterName As String In Printing.PrinterSettings.InstalledPrinters
            cbo打印机.Items.Add(strPrinterName)
            If strPrinterName = strDefaultPrinter Then
                cbo打印机.SelectedIndex = cbo打印机.Items.IndexOf(strPrinterName)
            End If
        Next

        For Each cmblist In cbo打印机.Items
            If cmblist = Printer Then
                cbo打印机.Text = Printer
            End If
        Next

        '匹配A3
        chk匹配A3纸.Checked = IIf(IsPaperA3 = "1", True, False)

        '签字
        chk签字.Checked = IIf(IsSign = "1", True, False)

        '另存为
        cbo另存为.Text = SaveAsDawAndPdf


        txt展开图模板.Text = str展开图模板
        btn向上颜色.BackColor = ColorTranslator.FromHtml(str向上颜色)
        btn向下颜色.BackColor = ColorTranslator.FromHtml(str向下颜色)

        cbo向上线宽.Text = str向上线宽
        cbo向下线宽.Text = str向下线宽

        cbo向上线型.Text = str向上线型
        cbo向下线型.Text = str向下线型

        chk展开图标注.Checked = IIf(str展开图标注 = "1", True, False)


        txt工程图模板.Text = str工程图模板
        chk钣金自动展开.Checked = IIf(str自动展开图 = "1", True, False)
        chk第三视角.Checked = IIf(str第三视角 = "1", True, False)
        chk相切边.Checked = IIf(str相切边 = "1", True, False)
        chk螺纹特征.Checked = IIf(str螺纹特征 = "1", True, False)
        chk标注尺寸.Checked = IIf(str标注尺寸 = "1", True, False)

        rdo显示隐藏线.Checked = IIf(str样式 = "显示隐藏线", True, False)
        rdo不显示隐藏线.Checked = rdo显示隐藏线.Checked Xor True

        chk左视图.Checked = Iif(str选择视图.str左视图 = "1", True, False)
        chk右视图.Checked = Iif(str选择视图.str右视图 = "1", True, False)
        chk俯视图.Checked = Iif(str选择视图.str俯视图 = "1", True, False)
        chk仰视图.Checked = Iif(str选择视图.str仰视图 = "1", True, False)

        NumericUpDown页边距上.Value = Val(str页边距.short上边距)
        NumericUpDown页边距下.Value = Val(str页边距.short下边距)
        NumericUpDown页边距左.Value = Val(str页边距.short左边距)
        NumericUpDown页边距右.Value = Val(str页边距.short右边距)

        txt部件图框.Text = str部件图框
        txt零件图框.Text = str零件图框

        '==================================================================
        Dim toolTip As New ToolTip()
        toolTip.AutoPopDelay = 0
        toolTip.InitialDelay = 0
        toolTip.ReshowDelay = 500
        toolTip.SetToolTip(chk备份工程图, "更改零部件文件名时，工程图扩展名添加  .old")
        toolTip.SetToolTip(chk模型匹配检查, "打开工程图时检查文件名是否与引用的模型文件一致")
        toolTip.SetToolTip(btn选择erp数据库, "选择ERP数据库文件")
        toolTip.SetToolTip(btn选择工程图模板, "选择工程图模板文件")
        toolTip.SetToolTip(btn展开图模板, "选择展开图模板文件")
        toolTip.SetToolTip(chk另存到子文件夹, "另存dwg，pdf文件到子文件夹 \CAD\ 或 \PDF\下")
        toolTip.SetToolTip(chk逆时针序号, "按逆时针自动重建序号")
        toolTip.SetToolTip(NUD查找文件夹层数, "设置查找文件时，向上父文件夹的层数")
        toolTip.SetToolTip(chk检查重复图号, "更改文件名时，在当前项目文件夹下，检查图号是否重复")

        btn选择erp数据库.Image = My.Resources.快速打开16.ToBitmap
        btn选择工程图模板.Image = My.Resources.快速打开16.ToBitmap
        btn展开图模板.Image = My.Resources.快速打开16.ToBitmap




    End Sub
    Private Sub txt基础数据文件_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txt基础数据文件.DoubleClick
        'if e.Button = System.Windows.Forms.MouseButtons.Left Then

        '    Dim oOpenFileDialog As New OpenFileDialog
        '    With oOpenFileDialog
        '        .Title = "打开"
        '        .FileName = ""
        '        .InitialDirectory = GetFileNameInfo(BasicExcelFullFileName).Folder
        '        .Filter = "Excel(*.xlsx;*.xls)|*.xlsx;*.xls" '添加过滤文件
        '        .Multiselect = False '多开文件打开
        '        .CheckFileExists = False
        '        if .ShowDialog = System.Windows.Forms.DialogResult.OK Then '如果打开窗口OK
        '            if .FileName <> "" Then '如果有选中文件
        '                txt基础数据文件.Text = .FileName
        '            End if
        '        Else
        '            Exit Sub
        '        End if
        '    End With
        'End if
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
            .Title = "打开工程图模板"
            .FileName = ""
            .InitialDirectory = ThisApplication.FileOptions.DefaultTemplateDrawingStandard
            .Filter = "Inventor工程图文件(*.idw)|*.idw" '添加过滤文件
            .Multiselect = False '多开文件打开
            .CheckFileExists = True
            if .ShowDialog = System.Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                if .FileName <> "" Then '如果有选中文件
                    txt工程图模板.Text = .FileName
                    str工程图模板 = .FileName
                End if
            Else
                Exit Sub
            End if
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
            if .ShowDialog = System.Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                if .FileName <> "" Then '如果有选中文件
                    txt基础数据文件.Text = .FileName
                    BasicExcelFullFileName = .FileName
                End if
            Else
                Exit Sub
            End if
        End With

    End Sub

    Private Sub btn颜色上_Click(sender As Object, e As EventArgs) Handles btn向上颜色.Click
        Dim colorDialog As New ColorDialog()
        if colorDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedColor As Color = colorDialog.Color
            btn向上颜色.BackColor = selectedColor
            str向上颜色 = String.Format("#{0:X2}{1:X2}{2:X2}", selectedColor.R, selectedColor.G, selectedColor.B)
        End if
    End Sub

    Private Sub btn颜色下_Click(sender As Object, e As EventArgs) Handles btn向下颜色.Click
        Dim colorDialog As New ColorDialog()
        if colorDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedColor As Color = colorDialog.Color
            btn向下颜色.BackColor = selectedColor
            str向下颜色 = String.Format("#{0:X2}{1:X2}{2:X2}", selectedColor.R, selectedColor.G, selectedColor.B)
        End if
    End Sub

    Private Sub btn展开图模板_Click(sender As Object, e As EventArgs) Handles btn展开图模板.Click
        Dim oOpenFileDialog As New OpenFileDialog
        With oOpenFileDialog
            .Title = "打开展开图模板"
            .FileName = ""
            .InitialDirectory = ThisApplication.FileOptions.DefaultTemplateDrawingStandard
            .Filter = "Inventor工程图文件(*.idw)|*.idw" '添加过滤文件
            .Multiselect = False '多开文件打开
            .CheckFileExists = True
            if .ShowDialog = System.Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                if .FileName <> "" Then '如果有选中文件
                    txt展开图模板.Text = .FileName
                    str展开图模板 = .FileName
                End if
            Else
                Exit Sub
            End if
        End With
    End Sub

End Class