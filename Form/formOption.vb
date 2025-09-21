Imports System.Drawing
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Inventor
Imports System.ComponentModel
Imports System.Text

Public Class FormOption

    Inherits Form

    Private Sub Btn添加_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn添加.Click
        'if txtBOM导出项.Text = "" Then
        '    txtBOM导出项.Text = cbo添加.Text
        'Else

        '//先获取复制文本
        Dim newstr As String = cmb添加.Text

        If newstr = "| (分隔符)" Then
            newstr = "|"
        End If


        '//获取textBox2 中的光标
        Dim index As Integer = txtBOM导出项.SelectionStart
        txtBOM导出项.Text = txtBOM导出项.Text.Insert(index, newstr)
        txtBOM导出项.SelectionStart = index + newstr.Length
        txtBOM导出项.Focus()
        'End if

    End Sub



    Private Sub Btn清除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn清除.Click
        txtBOM导出项.Clear()
    End Sub

    Private Sub Btn确定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn确定.Click
        If cmb图号.Text = cmb文件名.Text Then
            MessageBox.Show("映射设置相同。", XHTool, MessageBoxButtons.OK， MessageBoxIcon.Error)
            Exit Sub
        End If

        Map_DrawingNnumber = cmb图号.Text
        Map_PartName = cmb文件名.Text
        Map_ERPCode = cmb存货编码.Text
        Map_Vendor = cmb供应商.Text
        str连接符 = cmb连接符.Text

        Select Case str连接符
            Case "无"
                char连接符 = “”
            Case "空格"
                char连接符 = “ ”
            Case "点."
                char连接符 = “.”
            Case "短横线-"
                char连接符 = “-”
            Case "下划线_"
                char连接符 = “_”
        End Select

        Map_Mir_StochNum = txt对称件图号映射.Text
        Map_Mir_PartName = txt对称件文件名映射.Text
        Map_Mir_ERPCode = txt对称件编码映射.Text

        Map_DrawingScale = txt比例.Text
        Map_PrintDay = txt打印日期.Text
        EngineerName = txt工程师.Text
        BOMTiTle = txtBOM导出项.Text
        Map_Mass = txt图号.Text


        oEncoding = IIf(chk使用UTF8编码.Checked, Encoding.UTF8, Encoding.Default)
        strEncoding = IIf(chk使用UTF8编码.Checked, "UTF8", "Default")


        BasicExcelFullFileName = txt基础数据文件.Text
        TableArrays = txt查找范围.Text
        ColIndexNum = txt查询列.Text

        str变更工程图扩展名 = IIf(chk备份工程图.Checked, "1", "-1")
        str另存到子文件夹 = IIf(chk另存到子文件夹.Checked, "1", "-1")
        str查找文件夹层数 = NUD查找文件夹层数.Value
        Is检查重复图号 = IIf(chk检查重复图号.Checked, "1", "-1")

        str去除后缀表 = txt去除后缀.Text

        str模型匹配检查 = IIf(chk模型匹配检查.Checked, "1", "-1")
        str逆时针序号 = IIf(chk逆时针序号.Checked, "1", "-1")
        str强制横向 = IIf(chk强制横向.Checked, "1", "-1")

        str钣金厚度检查 = IIf(chk钣金厚度检查.Checked, "1", "-1")
        str钣金厚度前缀 = txt钣金厚度前缀.Text

        '打印签字
        IsOpenPrint = IIf(chk签字后打印.Checked, "1", "-1")

        '同时签字
        IsDayAndName = IIf(chk同时签字.Checked, "1", "-1")

        IsShortData = IIf(chk短日期.Checked, "1"， “-1")

        '打开工程图时写入

        'IsSetDrawingScale = Iif(chk保存比例.Checked, "1", "-1")


        '打开工程图时写入

        'IsSetMass = Iif(chk保存质量.Checked, "1", "-1")


        '启动检查更新
        CheckUpdate = IIf(chk检查更新.Checked, "1", "-1")


        '质量精度：
        Select Case cmb质量精度.Text
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
        Select Case cmb面积精度.Text
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

        Printer = cmb打印机.Text

        '匹配A3
        IsPaperA3 = IIf(chk匹配A3纸.Checked, "1", "-1")

        '签字
        IsSign = IIf(chk签字.Checked, "1", "-1")


        '另存为
        SaveAsDawAndPdf = cmb另存为.Text


        str展开图模板 = txt展开图模板.Text
        str向上线宽 = cmb向上线宽.Text
        str向下线宽 = cmb向下线宽.Text

        str向上线型 = cmb向上线型.Text
        str向下线型 = cmb向下线型.Text

        str展开图标注 = IIf(chk展开图标注.Checked, "1", "-1")

        str展开图隐藏螺纹特征 = IIf(chk展开图隐藏螺纹特征.Checked, "1", "-1")
        str标记孔径上限 = txt标记孔径上限.Text
        'str导出DXF = IIf(chk导出DXF.Checked, "1", "-1")
        str图号材质 = cmb图号材质.Text

        str工艺文字高 = txt工艺文字高.Text

        str保存展开图到指定文件夹 = IIf(chk保存展开图到指定文件夹.Checked, "1", "-1")

        str工程图模板 = txt工程图模板.Text
        str自动展开图 = IIf(chk钣金自动展开.Checked, "1", "-1")
        str第三视角 = IIf(chk第三视角.Checked, "1", "-1")
        str相切边 = IIf(chk相切边.Checked, "1", "-1")
        str螺纹特征 = IIf(chk工程图螺纹特征.Checked, "1", "-1")
        str标注尺寸 = IIf(chk标注尺寸.Checked, "1", "-1")
        str样式 = IIf(rdo不显示隐藏线.Checked, "不显示隐藏线", "显示隐藏线")


        str选择视图.str左视图 = IIf(chk左视图.Checked, "1", "-1")
        str选择视图.str右视图 = IIf(chk右视图.Checked, "1", "-1")
        str选择视图.str俯视图 = IIf(chk俯视图.Checked, "1", "-1")
        str选择视图.str仰视图 = IIf(chk仰视图.Checked, "1", "-1")
        str页边距.short上边距 = NumericUpDown页边距上.Value
        str页边距.short下边距 = NumericUpDown页边距下.Value
        str页边距.short左边距 = NumericUpDown页边距左.Value
        str页边距.short右边距 = NumericUpDown页边距右.Value

        str部件图框 = txt部件图框.Text
        str零件图框 = txt零件图框.Text


        strLargeSmallIconSets = “”
        For Each item As ListViewItem In lvw设置图标大小.Items
            strLargeSmallIconSets = strLargeSmallIconSets & item.SubItems(1).Text.ToString & ","
        Next

        intPitcureWidth = txt宽度.Text
        intPitcureHeight = txt高度.Text

        '自动保存
        str启用自动保存 = IIf(chk启用自动保存.Checked, "1", "-1")
        str保存文档类型 = cmb保存文档.Text
        str保存间隔时间 = cmb时间间隔.Text


        If str启用自动保存 = "1" Then
            m_timer.Interval = Integer.Parse(str保存间隔时间 * 60 * 1000)
            m_timer.Start()
        Else
            m_timer.Stop()
        End If

        WrIni.InAISettingIniWriteSetting()


        'WrXml.InAISettingXmlWriteSetting()

        FormManager.CloseAndDisposeForm(Of FormOption)()

    End Sub

    Private Sub Btn打开erp数据库_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn打开erp数据库.Click

        'if IsFileExists(txt自定义数据文件.Text) = True Then
        '  ProcessStart(txt自定义数据文件.Text)
        'End if

        If IsFileExists(BasicExcelFullFileName) = True Then
            ProcessStart(BasicExcelFullFileName)
        Else
            'excel文件不存在，到服务器下载
            Dim documentURL As String
            documentURL = Server & ServerExcelFileName

            If IsFileExists(documentURL) = True Then
                Dim wc As New System.Net.WebClient
                wc.DownloadFile(documentURL, BasicExcelFullFileName)
                ProcessStart(BasicExcelFullFileName)
            End If

        End If
    End Sub

    Private Sub Btn还原_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn还原.Click
        txtBOM导出项.Text = BOMTiTle
    End Sub

    Private Sub Btn更新数据库_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn更新数据库.Click
        '更新数据库文件
        'excel文件不存在，到服务器下载
        Dim documentURL As String
        documentURL = Server & ServerExcelFileName

        If IsFileExists(documentURL) = True Then
            Dim wc As New System.Net.WebClient
            wc.DownloadFile(documentURL, BasicExcelFullFileName)
            'Process.Start(BasicExcelFullFileName)

        End If
        MessageBox.Show("更新数据库文件完成。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information)
    End Sub

    Private Sub FrmOption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48

        Dim strArryLargeSmallIconNames As String() = strLargeSmallIconNames.Split(","c)

        Dim strArryLargeSmallIconSets As String() = strLargeSmallIconSets.Split(","c)
        Dim i As Integer = 0

        For Each strLargeSmallIconName As String In strArryLargeSmallIconNames
            Dim oListViewItem As ListViewItem
            oListViewItem = lvw设置图标大小.Items.Add(strLargeSmallIconName)
            oListViewItem.SubItems.Add(strArryLargeSmallIconSets(i)）
            i = i + 1
        Next

        '加载配置文件
        Dim strComboBoxs As String
        Dim arraystrComboBox() As String
        Dim strComboBox As String

        strComboBoxs = GetStrFromINI("iProperty", "图号列表", "库存编号,零件代号,描述,标题,主题", IniFile)
        arraystrComboBox = Split(strComboBoxs, ",")
        For Each strComboBox In arraystrComboBox
            If cmb图号.FindString(strComboBox) = -1 Then
                cmb图号.Items.Add(strComboBox)
            End If
        Next

        strComboBoxs = GetStrFromINI("iProperty", "文件名列表", "库存编号,零件代号,描述,标题,主题", IniFile)
        arraystrComboBox = Split(strComboBoxs, ",")
        For Each strComboBox In arraystrComboBox
            If cmb文件名.FindString(strComboBox) = -1 Then
                cmb文件名.Items.Add(strComboBox)
            End If
        Next

        '初始化映射
        cmb图号.Text = Map_DrawingNnumber
        cmb文件名.Text = Map_PartName
        cmb存货编码.Text = Map_ERPCode
        cmb供应商.Text = Map_Vendor
        cmb连接符.Text = str连接符

        Dim items As String() = {"| (分隔符)", "BOM 表结构", "Web 链接", "版本", "标题", "材料", "成本中心", "创建日期", "单位", "单位数量", "工程核准人",
            "工程师", "工程师核准日期", "供应商", "关键词", "基础单位", "基础数量", "检测人", "检测日期", "库存编号", "类别", "零部件类型", "零件代号", "描述",
            "批准人", "设计人", "设计状态", "数量", "体积", "文件路径", "文件名称", "项目", "项数量", "预估成本", "制造核准人", "制造者核准日期", "质量", "主管",
            "主题", "注释", "状态", "作者", "材料", "成本", "空格", "面积", "所属装配", "所属装配代号", "项目序号", "总成本", "总数量", "总质量"}

        ' 将数组添加到ComboBox
        cmb添加.Items.AddRange(items)
        cmb添加.DropDownStyle = ComboBoxStyle.DropDownList
        cmb添加.Sorted = True    ' 保持原始顺序
        cmb添加.SelectedIndex = 0   ' 默认选择第一项


        Select Case Mass_Accuracy
            Case "0"
                cmb质量精度.Text = "0"
            Case "1"
                cmb质量精度.Text = "0.1"
            Case "2"
                cmb质量精度.Text = "0.01"
            Case "3"
                cmb质量精度.Text = "0.001"
        End Select

        Select Case Area_Accuracy
            Case "0"
                cmb面积精度.Text = "0"
            Case "1"
                cmb面积精度.Text = "0.1"
            Case "2"
                cmb面积精度.Text = "0.01"
            Case "3"
                cmb面积精度.Text = "0.001"
            Case "4"
                cmb面积精度.Text = "0.0001"
            Case "5"
                cmb面积精度.Text = "0.00001"
            Case "6"
                cmb面积精度.Text = "0.000001"
        End Select

        txt对称件图号映射.Text = Map_Mir_StochNum
        txt对称件文件名映射.Text = Map_Mir_PartName
        txt对称件编码映射.Text = Map_Mir_ERPCode

        txt比例.Text = Map_DrawingScale
        txt打印日期.Text = Map_PrintDay
        txt工程师.Text = EngineerName
        txtBOM导出项.Text = BOMTiTle
        txt图号.Text = Map_Mass
        chk使用UTF8编码.Checked = IIf(strEncoding = “UTF8”, True, False)


        chk签字后打印.Checked = IIf(IsOpenPrint = "1", True, False)
        chk同时签字.Checked = IIf(IsDayAndName = "1", True, False)
        chk短日期.Checked = IIf(IsShortData = "1", True, False)

        'chk保存质量.Checked = IIf(IsSetMass = "1", True, False)

        chk检查更新.Checked = IIf(CheckUpdate = "1", True, False)

        txt基础数据文件.Text = BasicExcelFullFileName
        txt查找范围.Text = TableArrays
        txt查询列.Text = ColIndexNum

        chk备份工程图.Checked = IIf(str变更工程图扩展名 = "1", True, False)
        chk另存到子文件夹.Checked = IIf(str另存到子文件夹 = "1", True, False)
        NUD查找文件夹层数.Value = str查找文件夹层数
        chk检查重复图号.Checked = IIf(Is检查重复图号 = "1", True, False)
        txt去除后缀.Text = str去除后缀表

        chk模型匹配检查.Checked = IIf(str模型匹配检查 = "1", True, False)
        chk逆时针序号.Checked = IIf(str逆时针序号 = "1", True, False)
        chk强制横向.Checked = IIf(str强制横向 = "1", True, False)


        chk钣金厚度检查.Checked = IIf(str钣金厚度检查 = "1", True, False)
        txt钣金厚度前缀.Text = str钣金厚度前缀


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
        chk匹配A3纸.Checked = IIf(IsPaperA3 = "1", True, False)

        '签字
        chk签字.Checked = IIf(IsSign = "1", True, False)

        '另存为
        cmb另存为.Text = SaveAsDawAndPdf


        txt展开图模板.Text = str展开图模板
        btn向上颜色.BackColor = ColorTranslator.FromHtml(str向上颜色)
        btn向下颜色.BackColor = ColorTranslator.FromHtml(str向下颜色)

        cmb向上线宽.Text = str向上线宽
        cmb向下线宽.Text = str向下线宽

        cmb向上线型.Text = str向上线型
        cmb向下线型.Text = str向下线型

        chk展开图标注.Checked = IIf(str展开图标注 = "1", True, False)
        chk展开图隐藏螺纹特征.Checked = IIf(str展开图隐藏螺纹特征 = "1", True, False)
        txt标记孔径上限.Text = str标记孔径上限
        'chk导出DXF.Checked = IIf(str导出DXF = "1", True, False)
        cmb图号材质.Text = str图号材质
        txt工艺文字高.Text = str工艺文字高

        chk保存展开图到指定文件夹.Checked = IIf(str保存展开图到指定文件夹 = "1", True, False)

        txt工程图模板.Text = str工程图模板
        chk钣金自动展开.Checked = IIf(str自动展开图 = "1", True, False)
        chk第三视角.Checked = IIf(str第三视角 = "1", True, False)
        chk相切边.Checked = IIf(str相切边 = "1", True, False)
        chk工程图螺纹特征.Checked = IIf(str螺纹特征 = "1", True, False)
        chk标注尺寸.Checked = IIf(str标注尺寸 = "1", True, False)

        rdo显示隐藏线.Checked = IIf(str样式 = "显示隐藏线", True, False)
        rdo不显示隐藏线.Checked = rdo显示隐藏线.Checked Xor True

        chk左视图.Checked = IIf(str选择视图.str左视图 = "1", True, False)
        chk右视图.Checked = IIf(str选择视图.str右视图 = "1", True, False)
        chk俯视图.Checked = IIf(str选择视图.str俯视图 = "1", True, False)
        chk仰视图.Checked = IIf(str选择视图.str仰视图 = "1", True, False)

        NumericUpDown页边距上.Value = Val(str页边距.short上边距)
        NumericUpDown页边距下.Value = Val(str页边距.short下边距)
        NumericUpDown页边距左.Value = Val(str页边距.short左边距)
        NumericUpDown页边距右.Value = Val(str页边距.short右边距)

        txt部件图框.Text = str部件图框
        txt零件图框.Text = str零件图框

        txt宽度.Text = intPitcureWidth
        txt高度.Text = intPitcureHeight

        chk启用自动保存.Checked = IIf(str启用自动保存 = “1”, True, False)
        cmb保存文档.Text = str保存文档类型


        If cmb时间间隔.Items.Contains(str保存间隔时间) = False Then
            cmb时间间隔.Items.Add(str保存间隔时间)
        End If


        ' 获取当前项并转换为整数排序
        Dim sortedItems = cmb时间间隔.Items.Cast(Of String)() _
                   .OrderBy(Function(s) Integer.Parse(s)) _
                   .ToList()

        ' 清空并重新添加排序后的项
        cmb时间间隔.Items.Clear()
        For Each item In sortedItems
            cmb时间间隔.Items.Add(item)
        Next

        cmb时间间隔.Text = str保存间隔时间



        '==================================================================
        Dim toolTip As New Windows.Forms.ToolTip With {
            .AutoPopDelay = 0,
            .InitialDelay = 0,
            .ReshowDelay = 500
        }
        toolTip.SetToolTip(chk备份工程图, "重命名文件时，工程图扩展名添加  .old")
        toolTip.SetToolTip(chk模型匹配检查, "打开工程图时检查文件名是否与引用的模型文件一致")
        toolTip.SetToolTip(btn选择erp数据库, "选择ERP数据库文件")
        toolTip.SetToolTip(btn选择工程图模板, "选择工程图模板文件")
        toolTip.SetToolTip(btn展开图模板, "选择展开图模板文件")
        toolTip.SetToolTip(chk另存到子文件夹, "另存dwg，pdf文件到子文件夹 \Dwg\ 或 \Pdf\")
        toolTip.SetToolTip(chk逆时针序号, "按逆时针自动重建序号")
        toolTip.SetToolTip(NUD查找文件夹层数, "设置查找文件时，向上父文件夹的层数")
        toolTip.SetToolTip(chk检查重复图号, "重命名文件时，在当前项目文件夹下，检查图号是否重复")
        toolTip.SetToolTip(lbl去除后缀, "提取文件名时，去除后缀，用‘,’分割")
        toolTip.SetToolTip(lbl标记孔径上限, "标记螺纹的最大值，保留2位小数")
        toolTip.SetToolTip(chk钣金厚度检查, "打开零件为钣金时，检查钣金厚度值与材料厚度是否一致，在列表中添加材质")
        toolTip.SetToolTip(lvw设置图标大小, "双击列表行切换图标大小")
        toolTip.SetToolTip(chk强制横向, "强制生成的工程图图框为横向")


        btn选择erp数据库.Image = My.Resources.打开文件16.ToBitmap
        btn选择工程图模板.Image = My.Resources.打开文件16.ToBitmap
        btn展开图模板.Image = My.Resources.打开文件16.ToBitmap

    End Sub
    Private Sub Txt基础数据文件_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txt基础数据文件.DoubleClick
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

    'Private Sub Txt基础数据文件_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt基础数据文件.MouseHover
    '    Dim k As ToolTip

    '    k = New ToolTip()
    '    k.AutoPopDelay = 2000 '显示出气泡后的延时时间（毫秒）
    '    k.InitialDelay = 50 '出现前的延时（毫秒）
    '    k.ToolTipTitle = "" '提示信息标题
    '    k.SetToolTip(txt基础数据文件, "双击更改文件") '提示信息内容
    'End Sub

    Private Sub Btn选择工程图模板_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn选择工程图模板.Click
        Dim strFileName As String
        Dim strFilter As String = "Inventor工程图文件(*.idw;*.dwg)|*.idw;*.dwg" '添加过滤文件
        Dim strFile = IO.Path.Combine(ThisApplication.FileLocations.TemplatesPath, "选择模板文件")

        Dim oFileList As List(Of String)
        oFileList = OpenFileDialog(strFilter, False, strFile)

        If oFileList Is Nothing Then
            Exit Sub
        Else
            strFileName = oFileList(0).ToString

            txt工程图模板.Text = strFileName
            str工程图模板 = strFileName
        End If


    End Sub

    Private Sub Btn选择erp数据库_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn选择erp数据库.Click
        Dim strFilter As String = Nothing
        strFilter = "Excel 工作薄(*.xlsx;*.xls;*.xlsb)|*.xlsx;*.xls;*.xlsb" '添加过滤文件

        Dim strFile As String = IO.Path.Combine(My.Application.Info.DirectoryPath, "选择Excel文件")

        Dim oFileList As List(Of String)
        oFileList = OpenFileDialog(strFilter, False, strFile)

        If oFileList Is Nothing Then
            Exit Sub
        Else
            txt基础数据文件.Text = oFileList.Item(0).ToString
        End If

    End Sub

    Private Sub Btn颜色上_Click(sender As Object, e As EventArgs) Handles btn向上颜色.Click
        Dim colorDialog As New ColorDialog()
        If colorDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedColor As Drawing.Color = colorDialog.Color
            btn向上颜色.BackColor = selectedColor
            str向上颜色 = String.Format("#{0:X2}{1:X2}{2:X2}", selectedColor.R, selectedColor.G, selectedColor.B)
        End If
    End Sub

    Private Sub Btn颜色下_Click(sender As Object, e As EventArgs) Handles btn向下颜色.Click
        Dim colorDialog As New ColorDialog()
        If colorDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedColor As Drawing.Color = colorDialog.Color
            btn向下颜色.BackColor = selectedColor
            str向下颜色 = String.Format("#{0:X2}{1:X2}{2:X2}", selectedColor.R, selectedColor.G, selectedColor.B)
        End If
    End Sub

    Private Sub Btn展开图模板_Click(sender As Object, e As EventArgs) Handles btn展开图模板.Click

        Dim strFileName As String
        Dim strFilter As String = "Inventor工程图文件(*.idw;*.dwg)|*.idw;*.dwg" '添加过滤文件
        Dim strFile = IO.Path.Combine(ThisApplication.FileLocations.TemplatesPath, "选择模板文件")

        Dim oFileList As List(Of String)
        oFileList = OpenFileDialog(strFilter, False, strFile)

        If oFileList Is Nothing Then
            Exit Sub
        Else
            strFileName = oFileList(0).ToString

            txt展开图模板.Text = strFileName
            str展开图模板 = strFileName
        End If

    End Sub


    Private Sub ToolStripMenuItem全局_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem全局.Click
        Dim FPath As String = IO.Path.Combine(My.Application.Info.DirectoryPath, "InAISetting.ini")

        ProcessStart(FPath)
    End Sub

    Private Sub ToolStripMenuItem图框替换_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem图框替换.Click

        FormBorderTitleShow()
        Me.Close()

    End Sub

    Private Sub ToolStripMenuItem安装目录_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem安装目录.Click
        Dim strAppPath As String
        strAppPath = My.Application.Info.DirectoryPath
        ProcessStart(strAppPath)
    End Sub

    Private Sub Btn配置文件_MouseClick(sender As Object, e As MouseEventArgs) Handles btn配置文件.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' 计算按钮的左下角位置
            Dim buttonLocation As Drawing.Point = btn配置文件.PointToScreen(New Drawing.Point(0, btn配置文件.Height))
            ' 显示 ContextMenuStrip
            ContextMenuStrip配置文件.Show(buttonLocation)
        End If
    End Sub

    Private Sub Lvw设置图标大小_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvw设置图标大小.MouseDoubleClick
        Dim oListViewItem As ListViewItem
        If lvw设置图标大小.SelectedItems.Count > 0 Then
            oListViewItem = lvw设置图标大小.SelectedItems(0)
            If oListViewItem.SubItems(1).Text = "大" Then
                oListViewItem.SubItems(1).Text = "小"
            Else
                oListViewItem.SubItems(1).Text = "大"
            End If

        End If
    End Sub
    Private Sub Btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click
        FormManager.CloseAndDisposeForm(Of FormOption)()
    End Sub

End Class