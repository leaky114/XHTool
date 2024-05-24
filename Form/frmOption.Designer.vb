<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOption
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            if disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End if
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn确定 = New System.Windows.Forms.Button()
        Me.btn取消 = New System.Windows.Forms.Button()
        Me.chk检查更新 = New System.Windows.Forms.CheckBox()
        Me.TabPage模型 = New System.Windows.Forms.TabPage()
        Me.chk检查重复图号 = New System.Windows.Forms.CheckBox()
        Me.lbl查找文件夹层数 = New System.Windows.Forms.Label()
        Me.NUD查找文件夹层数 = New System.Windows.Forms.NumericUpDown()
        Me.chk另存到子文件夹 = New System.Windows.Forms.CheckBox()
        Me.chk备份工程图 = New System.Windows.Forms.CheckBox()
        Me.btn图框配置 = New System.Windows.Forms.Button()
        Me.btn配置文件 = New System.Windows.Forms.Button()
        Me.GroupBoxERP查询 = New System.Windows.Forms.GroupBox()
        Me.btn选择erp数据库 = New System.Windows.Forms.Button()
        Me.btn更新数据库 = New System.Windows.Forms.Button()
        Me.btn打开erp数据库 = New System.Windows.Forms.Button()
        Me.txt查询列 = New System.Windows.Forms.TextBox()
        Me.lblERP列 = New System.Windows.Forms.Label()
        Me.txt查找范围 = New System.Windows.Forms.TextBox()
        Me.lbl查询列 = New System.Windows.Forms.Label()
        Me.txt基础数据文件 = New System.Windows.Forms.TextBox()
        Me.lbl基础数据文件 = New System.Windows.Forms.Label()
        Me.GroupBoxBOM导出项目 = New System.Windows.Forms.GroupBox()
        Me.btn清除 = New System.Windows.Forms.Button()
        Me.btn还原 = New System.Windows.Forms.Button()
        Me.btn添加 = New System.Windows.Forms.Button()
        Me.cbo添加 = New System.Windows.Forms.ComboBox()
        Me.txtBOM导出项 = New System.Windows.Forms.TextBox()
        Me.lblBOM导出项目 = New System.Windows.Forms.Label()
        Me.TabPage常规 = New System.Windows.Forms.TabPage()
        Me.GroupBox快速打印 = New System.Windows.Forms.GroupBox()
        Me.cbo另存为 = New System.Windows.Forms.ComboBox()
        Me.cbo打印机 = New System.Windows.Forms.ComboBox()
        Me.chk匹配A3纸 = New System.Windows.Forms.CheckBox()
        Me.chk签字 = New System.Windows.Forms.CheckBox()
        Me.lbl打印机 = New System.Windows.Forms.Label()
        Me.GroupBox质量映射 = New System.Windows.Forms.GroupBox()
        Me.chk保存质量 = New System.Windows.Forms.CheckBox()
        Me.txt图号 = New System.Windows.Forms.TextBox()
        Me.lbl质量 = New System.Windows.Forms.Label()
        Me.GroupBox精度设置 = New System.Windows.Forms.GroupBox()
        Me.cbo面积精度 = New System.Windows.Forms.ComboBox()
        Me.lbl面积精度 = New System.Windows.Forms.Label()
        Me.cbo质量精度 = New System.Windows.Forms.ComboBox()
        Me.lbl质量精度 = New System.Windows.Forms.Label()
        Me.GroupBox签字 = New System.Windows.Forms.GroupBox()
        Me.chk同时签字 = New System.Windows.Forms.CheckBox()
        Me.txt工程师 = New System.Windows.Forms.TextBox()
        Me.lbl工程师 = New System.Windows.Forms.Label()
        Me.chk签字后打印 = New System.Windows.Forms.CheckBox()
        Me.txt打印日期 = New System.Windows.Forms.TextBox()
        Me.lbl打印日期 = New System.Windows.Forms.Label()
        Me.GroupBox比例映射 = New System.Windows.Forms.GroupBox()
        Me.chk保存比例 = New System.Windows.Forms.CheckBox()
        Me.txt比例 = New System.Windows.Forms.TextBox()
        Me.lbl比例 = New System.Windows.Forms.Label()
        Me.GroupBox对称零件iProperty映射 = New System.Windows.Forms.GroupBox()
        Me.txt文件名映射 = New System.Windows.Forms.TextBox()
        Me.txt图号映射 = New System.Windows.Forms.TextBox()
        Me.lbl对称件文件名 = New System.Windows.Forms.Label()
        Me.lbl对称件图号 = New System.Windows.Forms.Label()
        Me.GroupBoxiProperty映射 = New System.Windows.Forms.GroupBox()
        Me.cbo供应商 = New System.Windows.Forms.ComboBox()
        Me.lbl采购来源 = New System.Windows.Forms.Label()
        Me.cbo存货编码 = New System.Windows.Forms.ComboBox()
        Me.lbl存货编码 = New System.Windows.Forms.Label()
        Me.lbl文件名 = New System.Windows.Forms.Label()
        Me.cbo文件名 = New System.Windows.Forms.ComboBox()
        Me.lbl图号 = New System.Windows.Forms.Label()
        Me.cbo图号 = New System.Windows.Forms.ComboBox()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage工程图 = New System.Windows.Forms.TabPage()
        Me.chk逆时针序号 = New System.Windows.Forms.CheckBox()
        Me.chk模型匹配检查 = New System.Windows.Forms.CheckBox()
        Me.GroupBox标题栏 = New System.Windows.Forms.GroupBox()
        Me.txt零件图框 = New System.Windows.Forms.TextBox()
        Me.txt部件图框 = New System.Windows.Forms.TextBox()
        Me.lbl零件图框 = New System.Windows.Forms.Label()
        Me.lbl部件图框 = New System.Windows.Forms.Label()
        Me.GroupBox页边距 = New System.Windows.Forms.GroupBox()
        Me.NumericUpDown页边距右 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown页边距左 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown页边距下 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown页边距上 = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox视图 = New System.Windows.Forms.GroupBox()
        Me.chk标注尺寸 = New System.Windows.Forms.CheckBox()
        Me.lbl前视图 = New System.Windows.Forms.Label()
        Me.chk左视图 = New System.Windows.Forms.CheckBox()
        Me.chk俯视图 = New System.Windows.Forms.CheckBox()
        Me.chk右视图 = New System.Windows.Forms.CheckBox()
        Me.chk仰视图 = New System.Windows.Forms.CheckBox()
        Me.chk螺纹特征 = New System.Windows.Forms.CheckBox()
        Me.rdo显示隐藏线 = New System.Windows.Forms.RadioButton()
        Me.rdo不显示隐藏线 = New System.Windows.Forms.RadioButton()
        Me.chk相切边 = New System.Windows.Forms.CheckBox()
        Me.chk钣金自动展开 = New System.Windows.Forms.CheckBox()
        Me.chk第三视角 = New System.Windows.Forms.CheckBox()
        Me.GroupBox工程图模板 = New System.Windows.Forms.GroupBox()
        Me.btn选择工程图模板 = New System.Windows.Forms.Button()
        Me.txt工程图模板 = New System.Windows.Forms.TextBox()
        Me.lbl模板工程图 = New System.Windows.Forms.Label()
        Me.TabPage展开图 = New System.Windows.Forms.TabPage()
        Me.GroupBox展开图模板 = New System.Windows.Forms.GroupBox()
        Me.btn展开图模板 = New System.Windows.Forms.Button()
        Me.txt展开图模板 = New System.Windows.Forms.TextBox()
        Me.lbl展开图模板 = New System.Windows.Forms.Label()
        Me.chk展开图标注 = New System.Windows.Forms.CheckBox()
        Me.GroupBox下 = New System.Windows.Forms.GroupBox()
        Me.cbo向下线宽 = New System.Windows.Forms.ComboBox()
        Me.cbo向下线型 = New System.Windows.Forms.ComboBox()
        Me.lbl颜色下 = New System.Windows.Forms.Label()
        Me.btn向下颜色 = New System.Windows.Forms.Button()
        Me.lbl线宽下 = New System.Windows.Forms.Label()
        Me.lbl线型下 = New System.Windows.Forms.Label()
        Me.GroupBox上 = New System.Windows.Forms.GroupBox()
        Me.cbo向上线宽 = New System.Windows.Forms.ComboBox()
        Me.cbo向上线型 = New System.Windows.Forms.ComboBox()
        Me.lbl颜色上 = New System.Windows.Forms.Label()
        Me.btn向上颜色 = New System.Windows.Forms.Button()
        Me.lbl线宽上 = New System.Windows.Forms.Label()
        Me.lbl线型上 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabPage模型.SuspendLayout()
        CType(Me.NUD查找文件夹层数, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxERP查询.SuspendLayout()
        Me.GroupBoxBOM导出项目.SuspendLayout()
        Me.TabPage常规.SuspendLayout()
        Me.GroupBox快速打印.SuspendLayout()
        Me.GroupBox质量映射.SuspendLayout()
        Me.GroupBox精度设置.SuspendLayout()
        Me.GroupBox签字.SuspendLayout()
        Me.GroupBox比例映射.SuspendLayout()
        Me.GroupBox对称零件iProperty映射.SuspendLayout()
        Me.GroupBoxiProperty映射.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.TabPage工程图.SuspendLayout()
        Me.GroupBox标题栏.SuspendLayout()
        Me.GroupBox页边距.SuspendLayout()
        CType(Me.NumericUpDown页边距右, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown页边距左, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown页边距下, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown页边距上, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox视图.SuspendLayout()
        Me.GroupBox工程图模板.SuspendLayout()
        Me.TabPage展开图.SuspendLayout()
        Me.GroupBox展开图模板.SuspendLayout()
        Me.GroupBox下.SuspendLayout()
        Me.GroupBox上.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn确定
        '
        Me.btn确定.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn确定.Location = New System.Drawing.Point(460, 333)
        Me.btn确定.Name = "btn确定"
        Me.btn确定.Size = New System.Drawing.Size(75, 28)
        Me.btn确定.TabIndex = 1
        Me.btn确定.Text = "确定"
        '
        'btn取消
        '
        Me.btn取消.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn取消.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn取消.Location = New System.Drawing.Point(551, 333)
        Me.btn取消.Name = "btn取消"
        Me.btn取消.Size = New System.Drawing.Size(75, 28)
        Me.btn取消.TabIndex = 2
        Me.btn取消.Text = "取消"
        '
        'chk检查更新
        '
        Me.chk检查更新.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chk检查更新.AutoSize = True
        Me.chk检查更新.Checked = True
        Me.chk检查更新.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk检查更新.Location = New System.Drawing.Point(25, 339)
        Me.chk检查更新.Name = "chk检查更新"
        Me.chk检查更新.Size = New System.Drawing.Size(108, 16)
        Me.chk检查更新.TabIndex = 3
        Me.chk检查更新.Text = "启动时检查更新"
        Me.chk检查更新.UseVisualStyleBackColor = True
        '
        'TabPage模型
        '
        Me.TabPage模型.Controls.Add(Me.chk检查重复图号)
        Me.TabPage模型.Controls.Add(Me.lbl查找文件夹层数)
        Me.TabPage模型.Controls.Add(Me.NUD查找文件夹层数)
        Me.TabPage模型.Controls.Add(Me.chk另存到子文件夹)
        Me.TabPage模型.Controls.Add(Me.chk备份工程图)
        Me.TabPage模型.Controls.Add(Me.btn图框配置)
        Me.TabPage模型.Controls.Add(Me.btn配置文件)
        Me.TabPage模型.Controls.Add(Me.GroupBoxERP查询)
        Me.TabPage模型.Controls.Add(Me.GroupBoxBOM导出项目)
        Me.TabPage模型.Location = New System.Drawing.Point(4, 22)
        Me.TabPage模型.Name = "TabPage模型"
        Me.TabPage模型.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage模型.Size = New System.Drawing.Size(616, 290)
        Me.TabPage模型.TabIndex = 1
        Me.TabPage模型.Text = "模型"
        Me.TabPage模型.UseVisualStyleBackColor = True
        '
        'chk检查重复图号
        '
        Me.chk检查重复图号.AutoSize = True
        Me.chk检查重复图号.Location = New System.Drawing.Point(218, 204)
        Me.chk检查重复图号.Name = "chk检查重复图号"
        Me.chk检查重复图号.Size = New System.Drawing.Size(96, 16)
        Me.chk检查重复图号.TabIndex = 27
        Me.chk检查重复图号.Text = "检查重复图号"
        Me.chk检查重复图号.UseVisualStyleBackColor = True
        '
        'lbl查找文件夹层数
        '
        Me.lbl查找文件夹层数.AutoSize = True
        Me.lbl查找文件夹层数.Location = New System.Drawing.Point(319, 206)
        Me.lbl查找文件夹层数.Name = "lbl查找文件夹层数"
        Me.lbl查找文件夹层数.Size = New System.Drawing.Size(89, 12)
        Me.lbl查找文件夹层数.TabIndex = 26
        Me.lbl查找文件夹层数.Text = "查找文件夹层数"
        '
        'NUD查找文件夹层数
        '
        Me.NUD查找文件夹层数.Location = New System.Drawing.Point(410, 202)
        Me.NUD查找文件夹层数.Name = "NUD查找文件夹层数"
        Me.NUD查找文件夹层数.Size = New System.Drawing.Size(31, 21)
        Me.NUD查找文件夹层数.TabIndex = 25
        Me.NUD查找文件夹层数.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NUD查找文件夹层数.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'chk另存到子文件夹
        '
        Me.chk另存到子文件夹.AutoSize = True
        Me.chk另存到子文件夹.Location = New System.Drawing.Point(105, 204)
        Me.chk另存到子文件夹.Name = "chk另存到子文件夹"
        Me.chk另存到子文件夹.Size = New System.Drawing.Size(108, 16)
        Me.chk另存到子文件夹.TabIndex = 24
        Me.chk另存到子文件夹.Text = "另存到子文件夹"
        Me.chk另存到子文件夹.UseVisualStyleBackColor = True
        '
        'chk备份工程图
        '
        Me.chk备份工程图.AutoSize = True
        Me.chk备份工程图.Location = New System.Drawing.Point(16, 204)
        Me.chk备份工程图.Name = "chk备份工程图"
        Me.chk备份工程图.Size = New System.Drawing.Size(84, 16)
        Me.chk备份工程图.TabIndex = 23
        Me.chk备份工程图.Text = "备份工程图"
        Me.chk备份工程图.UseVisualStyleBackColor = True
        '
        'btn图框配置
        '
        Me.btn图框配置.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn图框配置.Location = New System.Drawing.Point(92, 248)
        Me.btn图框配置.Name = "btn图框配置"
        Me.btn图框配置.Size = New System.Drawing.Size(89, 28)
        Me.btn图框配置.TabIndex = 1
        Me.btn图框配置.Text = "图框配置文件"
        Me.btn图框配置.UseVisualStyleBackColor = True
        '
        'btn配置文件
        '
        Me.btn配置文件.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn配置文件.Location = New System.Drawing.Point(9, 248)
        Me.btn配置文件.Name = "btn配置文件"
        Me.btn配置文件.Size = New System.Drawing.Size(75, 28)
        Me.btn配置文件.TabIndex = 0
        Me.btn配置文件.Text = "配置文件"
        Me.btn配置文件.UseVisualStyleBackColor = True
        '
        'GroupBoxERP查询
        '
        Me.GroupBoxERP查询.Controls.Add(Me.btn选择erp数据库)
        Me.GroupBoxERP查询.Controls.Add(Me.btn更新数据库)
        Me.GroupBoxERP查询.Controls.Add(Me.btn打开erp数据库)
        Me.GroupBoxERP查询.Controls.Add(Me.txt查询列)
        Me.GroupBoxERP查询.Controls.Add(Me.lblERP列)
        Me.GroupBoxERP查询.Controls.Add(Me.txt查找范围)
        Me.GroupBoxERP查询.Controls.Add(Me.lbl查询列)
        Me.GroupBoxERP查询.Controls.Add(Me.txt基础数据文件)
        Me.GroupBoxERP查询.Controls.Add(Me.lbl基础数据文件)
        Me.GroupBoxERP查询.Location = New System.Drawing.Point(6, 108)
        Me.GroupBoxERP查询.Name = "GroupBoxERP查询"
        Me.GroupBoxERP查询.Size = New System.Drawing.Size(594, 84)
        Me.GroupBoxERP查询.TabIndex = 22
        Me.GroupBoxERP查询.TabStop = False
        Me.GroupBoxERP查询.Text = "ERP查询"
        '
        'btn选择erp数据库
        '
        Me.btn选择erp数据库.Location = New System.Drawing.Point(518, 16)
        Me.btn选择erp数据库.Name = "btn选择erp数据库"
        Me.btn选择erp数据库.Size = New System.Drawing.Size(26, 26)
        Me.btn选择erp数据库.TabIndex = 0
        Me.btn选择erp数据库.UseVisualStyleBackColor = True
        '
        'btn更新数据库
        '
        Me.btn更新数据库.Location = New System.Drawing.Point(407, 51)
        Me.btn更新数据库.Name = "btn更新数据库"
        Me.btn更新数据库.Size = New System.Drawing.Size(82, 25)
        Me.btn更新数据库.TabIndex = 5
        Me.btn更新数据库.Text = "更新数据库"
        Me.btn更新数据库.UseVisualStyleBackColor = True
        '
        'btn打开erp数据库
        '
        Me.btn打开erp数据库.Location = New System.Drawing.Point(502, 51)
        Me.btn打开erp数据库.Name = "btn打开erp数据库"
        Me.btn打开erp数据库.Size = New System.Drawing.Size(82, 25)
        Me.btn打开erp数据库.TabIndex = 6
        Me.btn打开erp数据库.Text = "打开数据库"
        Me.btn打开erp数据库.UseVisualStyleBackColor = True
        '
        'txt查询列
        '
        Me.txt查询列.Location = New System.Drawing.Point(242, 53)
        Me.txt查询列.Name = "txt查询列"
        Me.txt查询列.Size = New System.Drawing.Size(89, 21)
        Me.txt查询列.TabIndex = 4
        '
        'lblERP列
        '
        Me.lblERP列.AutoSize = True
        Me.lblERP列.Location = New System.Drawing.Point(187, 57)
        Me.lblERP列.Name = "lblERP列"
        Me.lblERP列.Size = New System.Drawing.Size(47, 12)
        Me.lblERP列.TabIndex = 3
        Me.lblERP列.Text = "ERP列："
        '
        'txt查找范围
        '
        Me.txt查找范围.Location = New System.Drawing.Point(75, 53)
        Me.txt查找范围.Name = "txt查找范围"
        Me.txt查找范围.Size = New System.Drawing.Size(89, 21)
        Me.txt查找范围.TabIndex = 2
        '
        'lbl查询列
        '
        Me.lbl查询列.AutoSize = True
        Me.lbl查询列.Location = New System.Drawing.Point(8, 57)
        Me.lbl查询列.Name = "lbl查询列"
        Me.lbl查询列.Size = New System.Drawing.Size(53, 12)
        Me.lbl查询列.TabIndex = 1
        Me.lbl查询列.Text = "查询列："
        '
        'txt基础数据文件
        '
        Me.txt基础数据文件.Location = New System.Drawing.Point(102, 19)
        Me.txt基础数据文件.Name = "txt基础数据文件"
        Me.txt基础数据文件.ReadOnly = True
        Me.txt基础数据文件.Size = New System.Drawing.Size(408, 21)
        Me.txt基础数据文件.TabIndex = 8
        Me.txt基础数据文件.TabStop = False
        '
        'lbl基础数据文件
        '
        Me.lbl基础数据文件.AutoSize = True
        Me.lbl基础数据文件.Location = New System.Drawing.Point(7, 23)
        Me.lbl基础数据文件.Name = "lbl基础数据文件"
        Me.lbl基础数据文件.Size = New System.Drawing.Size(89, 12)
        Me.lbl基础数据文件.TabIndex = 7
        Me.lbl基础数据文件.Text = "基础数据文件："
        '
        'GroupBoxBOM导出项目
        '
        Me.GroupBoxBOM导出项目.Controls.Add(Me.btn清除)
        Me.GroupBoxBOM导出项目.Controls.Add(Me.btn还原)
        Me.GroupBoxBOM导出项目.Controls.Add(Me.btn添加)
        Me.GroupBoxBOM导出项目.Controls.Add(Me.cbo添加)
        Me.GroupBoxBOM导出项目.Controls.Add(Me.txtBOM导出项)
        Me.GroupBoxBOM导出项目.Controls.Add(Me.lblBOM导出项目)
        Me.GroupBoxBOM导出项目.Location = New System.Drawing.Point(6, 16)
        Me.GroupBoxBOM导出项目.Name = "GroupBoxBOM导出项目"
        Me.GroupBoxBOM导出项目.Size = New System.Drawing.Size(594, 84)
        Me.GroupBoxBOM导出项目.TabIndex = 21
        Me.GroupBoxBOM导出项目.TabStop = False
        Me.GroupBoxBOM导出项目.Text = "BOM导出"
        '
        'btn清除
        '
        Me.btn清除.Location = New System.Drawing.Point(77, 47)
        Me.btn清除.Name = "btn清除"
        Me.btn清除.Size = New System.Drawing.Size(53, 25)
        Me.btn清除.TabIndex = 2
        Me.btn清除.Text = "清除"
        Me.btn清除.UseVisualStyleBackColor = True
        '
        'btn还原
        '
        Me.btn还原.Location = New System.Drawing.Point(14, 47)
        Me.btn还原.Name = "btn还原"
        Me.btn还原.Size = New System.Drawing.Size(53, 25)
        Me.btn还原.TabIndex = 1
        Me.btn还原.Text = "还原"
        Me.btn还原.UseVisualStyleBackColor = True
        '
        'btn添加
        '
        Me.btn添加.Location = New System.Drawing.Point(525, 47)
        Me.btn添加.Name = "btn添加"
        Me.btn添加.Size = New System.Drawing.Size(53, 25)
        Me.btn添加.TabIndex = 4
        Me.btn添加.Text = "添加"
        Me.btn添加.UseVisualStyleBackColor = True
        '
        'cbo添加
        '
        Me.cbo添加.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo添加.FormattingEnabled = True
        Me.cbo添加.Items.AddRange(New Object() {"| (分隔符)", "材料", "成本", "成本中心", "供应商", "空格", "库存编号", "零件代号", "面积", "描述", "数量", "所属装配", "所属装配代号", "文件路径", "文件名", "质量", "总成本", "总数量", "总质量"})
        Me.cbo添加.Location = New System.Drawing.Point(335, 50)
        Me.cbo添加.Name = "cbo添加"
        Me.cbo添加.Size = New System.Drawing.Size(170, 20)
        Me.cbo添加.Sorted = True
        Me.cbo添加.TabIndex = 3
        '
        'txtBOM导出项
        '
        Me.txtBOM导出项.Location = New System.Drawing.Point(86, 19)
        Me.txtBOM导出项.Name = "txtBOM导出项"
        Me.txtBOM导出项.Size = New System.Drawing.Size(496, 21)
        Me.txtBOM导出项.TabIndex = 0
        Me.txtBOM导出项.Text = "库存编号|成本中心|零件代号|材料|质量|所属装配代号|数量|总数量|描述"
        '
        'lblBOM导出项目
        '
        Me.lblBOM导出项目.AutoSize = True
        Me.lblBOM导出项目.Location = New System.Drawing.Point(7, 22)
        Me.lblBOM导出项目.Name = "lblBOM导出项目"
        Me.lblBOM导出项目.Size = New System.Drawing.Size(83, 12)
        Me.lblBOM导出项目.TabIndex = 4
        Me.lblBOM导出项目.Text = "BOM导出项目："
        '
        'TabPage常规
        '
        Me.TabPage常规.Controls.Add(Me.GroupBox快速打印)
        Me.TabPage常规.Controls.Add(Me.GroupBox质量映射)
        Me.TabPage常规.Controls.Add(Me.GroupBox精度设置)
        Me.TabPage常规.Controls.Add(Me.GroupBox签字)
        Me.TabPage常规.Controls.Add(Me.GroupBox比例映射)
        Me.TabPage常规.Controls.Add(Me.GroupBox对称零件iProperty映射)
        Me.TabPage常规.Controls.Add(Me.GroupBoxiProperty映射)
        Me.TabPage常规.Location = New System.Drawing.Point(4, 22)
        Me.TabPage常规.Name = "TabPage常规"
        Me.TabPage常规.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage常规.Size = New System.Drawing.Size(616, 290)
        Me.TabPage常规.TabIndex = 0
        Me.TabPage常规.Text = "常规"
        Me.TabPage常规.UseVisualStyleBackColor = True
        '
        'GroupBox快速打印
        '
        Me.GroupBox快速打印.Controls.Add(Me.cbo另存为)
        Me.GroupBox快速打印.Controls.Add(Me.cbo打印机)
        Me.GroupBox快速打印.Controls.Add(Me.chk匹配A3纸)
        Me.GroupBox快速打印.Controls.Add(Me.chk签字)
        Me.GroupBox快速打印.Controls.Add(Me.lbl打印机)
        Me.GroupBox快速打印.Location = New System.Drawing.Point(400, 124)
        Me.GroupBox快速打印.Name = "GroupBox快速打印"
        Me.GroupBox快速打印.Size = New System.Drawing.Size(207, 121)
        Me.GroupBox快速打印.TabIndex = 22
        Me.GroupBox快速打印.TabStop = False
        Me.GroupBox快速打印.Text = "快速打印"
        '
        'cbo另存为
        '
        Me.cbo另存为.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo另存为.FormattingEnabled = True
        Me.cbo另存为.Items.AddRange(New Object() {"不另存", "另存为dwg", "另存为pdf", "另存为dwg和pdf"})
        Me.cbo另存为.Location = New System.Drawing.Point(10, 83)
        Me.cbo另存为.Name = "cbo另存为"
        Me.cbo另存为.Size = New System.Drawing.Size(142, 20)
        Me.cbo另存为.TabIndex = 3
        '
        'cbo打印机
        '
        Me.cbo打印机.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo打印机.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbo打印机.FormattingEnabled = True
        Me.cbo打印机.Location = New System.Drawing.Point(57, 23)
        Me.cbo打印机.Name = "cbo打印机"
        Me.cbo打印机.Size = New System.Drawing.Size(141, 20)
        Me.cbo打印机.Sorted = True
        Me.cbo打印机.TabIndex = 0
        '
        'chk匹配A3纸
        '
        Me.chk匹配A3纸.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chk匹配A3纸.AutoSize = True
        Me.chk匹配A3纸.Checked = True
        Me.chk匹配A3纸.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk匹配A3纸.Location = New System.Drawing.Point(14, 55)
        Me.chk匹配A3纸.Name = "chk匹配A3纸"
        Me.chk匹配A3纸.Size = New System.Drawing.Size(72, 16)
        Me.chk匹配A3纸.TabIndex = 1
        Me.chk匹配A3纸.Text = "匹配A3纸"
        Me.chk匹配A3纸.UseVisualStyleBackColor = True
        '
        'chk签字
        '
        Me.chk签字.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chk签字.AutoSize = True
        Me.chk签字.Checked = True
        Me.chk签字.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk签字.Location = New System.Drawing.Point(104, 55)
        Me.chk签字.Name = "chk签字"
        Me.chk签字.Size = New System.Drawing.Size(48, 16)
        Me.chk签字.TabIndex = 2
        Me.chk签字.Text = "签字"
        Me.chk签字.UseVisualStyleBackColor = True
        '
        'lbl打印机
        '
        Me.lbl打印机.AutoSize = True
        Me.lbl打印机.Location = New System.Drawing.Point(8, 26)
        Me.lbl打印机.Name = "lbl打印机"
        Me.lbl打印机.Size = New System.Drawing.Size(53, 12)
        Me.lbl打印机.TabIndex = 9
        Me.lbl打印机.Text = "打印机："
        '
        'GroupBox质量映射
        '
        Me.GroupBox质量映射.Controls.Add(Me.chk保存质量)
        Me.GroupBox质量映射.Controls.Add(Me.txt图号)
        Me.GroupBox质量映射.Controls.Add(Me.lbl质量)
        Me.GroupBox质量映射.Location = New System.Drawing.Point(218, 86)
        Me.GroupBox质量映射.Name = "GroupBox质量映射"
        Me.GroupBox质量映射.Size = New System.Drawing.Size(163, 68)
        Me.GroupBox质量映射.TabIndex = 21
        Me.GroupBox质量映射.TabStop = False
        Me.GroupBox质量映射.Text = "质量映射"
        '
        'chk保存质量
        '
        Me.chk保存质量.AutoSize = True
        Me.chk保存质量.Checked = True
        Me.chk保存质量.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk保存质量.Location = New System.Drawing.Point(18, 44)
        Me.chk保存质量.Name = "chk保存质量"
        Me.chk保存质量.Size = New System.Drawing.Size(120, 16)
        Me.chk保存质量.TabIndex = 1
        Me.chk保存质量.Text = "保存工程图时写入"
        Me.chk保存质量.UseVisualStyleBackColor = True
        Me.chk保存质量.Visible = False
        '
        'txt图号
        '
        Me.txt图号.Location = New System.Drawing.Point(54, 18)
        Me.txt图号.Name = "txt图号"
        Me.txt图号.Size = New System.Drawing.Size(64, 21)
        Me.txt图号.TabIndex = 6
        '
        'lbl质量
        '
        Me.lbl质量.AutoSize = True
        Me.lbl质量.Location = New System.Drawing.Point(12, 22)
        Me.lbl质量.Name = "lbl质量"
        Me.lbl质量.Size = New System.Drawing.Size(41, 12)
        Me.lbl质量.TabIndex = 0
        Me.lbl质量.Text = "质量："
        '
        'GroupBox精度设置
        '
        Me.GroupBox精度设置.Controls.Add(Me.cbo面积精度)
        Me.GroupBox精度设置.Controls.Add(Me.lbl面积精度)
        Me.GroupBox精度设置.Controls.Add(Me.cbo质量精度)
        Me.GroupBox精度设置.Controls.Add(Me.lbl质量精度)
        Me.GroupBox精度设置.Location = New System.Drawing.Point(218, 160)
        Me.GroupBox精度设置.Name = "GroupBox精度设置"
        Me.GroupBox精度设置.Size = New System.Drawing.Size(165, 85)
        Me.GroupBox精度设置.TabIndex = 0
        Me.GroupBox精度设置.TabStop = False
        Me.GroupBox精度设置.Text = "精度设置"
        '
        'cbo面积精度
        '
        Me.cbo面积精度.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo面积精度.FormattingEnabled = True
        Me.cbo面积精度.Items.AddRange(New Object() {"0", "0.1", "0.01", "0.001", "0.0001", "0.00001"})
        Me.cbo面积精度.Location = New System.Drawing.Point(80, 52)
        Me.cbo面积精度.Name = "cbo面积精度"
        Me.cbo面积精度.Size = New System.Drawing.Size(66, 20)
        Me.cbo面积精度.TabIndex = 1
        '
        'lbl面积精度
        '
        Me.lbl面积精度.AutoSize = True
        Me.lbl面积精度.Location = New System.Drawing.Point(11, 55)
        Me.lbl面积精度.Name = "lbl面积精度"
        Me.lbl面积精度.Size = New System.Drawing.Size(65, 12)
        Me.lbl面积精度.TabIndex = 11
        Me.lbl面积精度.Text = "面积精度："
        '
        'cbo质量精度
        '
        Me.cbo质量精度.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo质量精度.FormattingEnabled = True
        Me.cbo质量精度.Items.AddRange(New Object() {"0", "0.1", "0.01", "0.001"})
        Me.cbo质量精度.Location = New System.Drawing.Point(80, 22)
        Me.cbo质量精度.Name = "cbo质量精度"
        Me.cbo质量精度.Size = New System.Drawing.Size(66, 20)
        Me.cbo质量精度.TabIndex = 0
        '
        'lbl质量精度
        '
        Me.lbl质量精度.AutoSize = True
        Me.lbl质量精度.Location = New System.Drawing.Point(11, 26)
        Me.lbl质量精度.Name = "lbl质量精度"
        Me.lbl质量精度.Size = New System.Drawing.Size(65, 12)
        Me.lbl质量精度.TabIndex = 9
        Me.lbl质量精度.Text = "质量精度："
        '
        'GroupBox签字
        '
        Me.GroupBox签字.Controls.Add(Me.chk同时签字)
        Me.GroupBox签字.Controls.Add(Me.txt工程师)
        Me.GroupBox签字.Controls.Add(Me.lbl工程师)
        Me.GroupBox签字.Controls.Add(Me.chk签字后打印)
        Me.GroupBox签字.Controls.Add(Me.txt打印日期)
        Me.GroupBox签字.Controls.Add(Me.lbl打印日期)
        Me.GroupBox签字.Location = New System.Drawing.Point(400, 10)
        Me.GroupBox签字.Name = "GroupBox签字"
        Me.GroupBox签字.Size = New System.Drawing.Size(207, 102)
        Me.GroupBox签字.TabIndex = 19
        Me.GroupBox签字.TabStop = False
        Me.GroupBox签字.Text = "签字"
        '
        'chk同时签字
        '
        Me.chk同时签字.AutoSize = True
        Me.chk同时签字.Location = New System.Drawing.Point(128, 77)
        Me.chk同时签字.Name = "chk同时签字"
        Me.chk同时签字.Size = New System.Drawing.Size(72, 16)
        Me.chk同时签字.TabIndex = 3
        Me.chk同时签字.Text = "同时签字"
        Me.chk同时签字.UseVisualStyleBackColor = True
        Me.chk同时签字.Visible = False
        '
        'txt工程师
        '
        Me.txt工程师.Location = New System.Drawing.Point(83, 46)
        Me.txt工程师.Name = "txt工程师"
        Me.txt工程师.Size = New System.Drawing.Size(98, 21)
        Me.txt工程师.TabIndex = 1
        '
        'lbl工程师
        '
        Me.lbl工程师.AutoSize = True
        Me.lbl工程师.Location = New System.Drawing.Point(12, 50)
        Me.lbl工程师.Name = "lbl工程师"
        Me.lbl工程师.Size = New System.Drawing.Size(53, 12)
        Me.lbl工程师.TabIndex = 8
        Me.lbl工程师.Text = "工程师："
        '
        'chk签字后打印
        '
        Me.chk签字后打印.AutoSize = True
        Me.chk签字后打印.Location = New System.Drawing.Point(14, 77)
        Me.chk签字后打印.Name = "chk签字后打印"
        Me.chk签字后打印.Size = New System.Drawing.Size(108, 16)
        Me.chk签字后打印.TabIndex = 2
        Me.chk签字后打印.Text = "签字后打开打印"
        Me.chk签字后打印.UseVisualStyleBackColor = True
        '
        'txt打印日期
        '
        Me.txt打印日期.Location = New System.Drawing.Point(83, 19)
        Me.txt打印日期.Name = "txt打印日期"
        Me.txt打印日期.Size = New System.Drawing.Size(98, 21)
        Me.txt打印日期.TabIndex = 0
        '
        'lbl打印日期
        '
        Me.lbl打印日期.AutoSize = True
        Me.lbl打印日期.Location = New System.Drawing.Point(12, 23)
        Me.lbl打印日期.Name = "lbl打印日期"
        Me.lbl打印日期.Size = New System.Drawing.Size(65, 12)
        Me.lbl打印日期.TabIndex = 4
        Me.lbl打印日期.Text = "打印日期："
        '
        'GroupBox比例映射
        '
        Me.GroupBox比例映射.Controls.Add(Me.chk保存比例)
        Me.GroupBox比例映射.Controls.Add(Me.txt比例)
        Me.GroupBox比例映射.Controls.Add(Me.lbl比例)
        Me.GroupBox比例映射.Location = New System.Drawing.Point(218, 10)
        Me.GroupBox比例映射.Name = "GroupBox比例映射"
        Me.GroupBox比例映射.Size = New System.Drawing.Size(163, 68)
        Me.GroupBox比例映射.TabIndex = 18
        Me.GroupBox比例映射.TabStop = False
        Me.GroupBox比例映射.Text = "比例映射"
        '
        'chk保存比例
        '
        Me.chk保存比例.AutoSize = True
        Me.chk保存比例.Checked = True
        Me.chk保存比例.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk保存比例.Location = New System.Drawing.Point(18, 44)
        Me.chk保存比例.Name = "chk保存比例"
        Me.chk保存比例.Size = New System.Drawing.Size(120, 16)
        Me.chk保存比例.TabIndex = 1
        Me.chk保存比例.Text = "保存工程图时写入"
        Me.chk保存比例.UseVisualStyleBackColor = True
        Me.chk保存比例.Visible = False
        '
        'txt比例
        '
        Me.txt比例.Location = New System.Drawing.Point(54, 18)
        Me.txt比例.Name = "txt比例"
        Me.txt比例.Size = New System.Drawing.Size(64, 21)
        Me.txt比例.TabIndex = 0
        '
        'lbl比例
        '
        Me.lbl比例.AutoSize = True
        Me.lbl比例.Location = New System.Drawing.Point(12, 22)
        Me.lbl比例.Name = "lbl比例"
        Me.lbl比例.Size = New System.Drawing.Size(41, 12)
        Me.lbl比例.TabIndex = 4
        Me.lbl比例.Text = "比例："
        '
        'GroupBox对称零件iProperty映射
        '
        Me.GroupBox对称零件iProperty映射.Controls.Add(Me.txt文件名映射)
        Me.GroupBox对称零件iProperty映射.Controls.Add(Me.txt图号映射)
        Me.GroupBox对称零件iProperty映射.Controls.Add(Me.lbl对称件文件名)
        Me.GroupBox对称零件iProperty映射.Controls.Add(Me.lbl对称件图号)
        Me.GroupBox对称零件iProperty映射.Location = New System.Drawing.Point(6, 159)
        Me.GroupBox对称零件iProperty映射.Name = "GroupBox对称零件iProperty映射"
        Me.GroupBox对称零件iProperty映射.Size = New System.Drawing.Size(191, 86)
        Me.GroupBox对称零件iProperty映射.TabIndex = 17
        Me.GroupBox对称零件iProperty映射.TabStop = False
        Me.GroupBox对称零件iProperty映射.Text = "对称零件iProperty映射"
        '
        'txt文件名映射
        '
        Me.txt文件名映射.Location = New System.Drawing.Point(77, 52)
        Me.txt文件名映射.Name = "txt文件名映射"
        Me.txt文件名映射.Size = New System.Drawing.Size(95, 21)
        Me.txt文件名映射.TabIndex = 1
        '
        'txt图号映射
        '
        Me.txt图号映射.Location = New System.Drawing.Point(77, 22)
        Me.txt图号映射.Name = "txt图号映射"
        Me.txt图号映射.Size = New System.Drawing.Size(95, 21)
        Me.txt图号映射.TabIndex = 0
        '
        'lbl对称件文件名
        '
        Me.lbl对称件文件名.AutoSize = True
        Me.lbl对称件文件名.Location = New System.Drawing.Point(21, 55)
        Me.lbl对称件文件名.Name = "lbl对称件文件名"
        Me.lbl对称件文件名.Size = New System.Drawing.Size(53, 12)
        Me.lbl对称件文件名.TabIndex = 4
        Me.lbl对称件文件名.Text = "文件名："
        '
        'lbl对称件图号
        '
        Me.lbl对称件图号.AutoSize = True
        Me.lbl对称件图号.Location = New System.Drawing.Point(21, 26)
        Me.lbl对称件图号.Name = "lbl对称件图号"
        Me.lbl对称件图号.Size = New System.Drawing.Size(53, 12)
        Me.lbl对称件图号.TabIndex = 3
        Me.lbl对称件图号.Text = "图  号："
        '
        'GroupBoxiProperty映射
        '
        Me.GroupBoxiProperty映射.Controls.Add(Me.cbo供应商)
        Me.GroupBoxiProperty映射.Controls.Add(Me.lbl采购来源)
        Me.GroupBoxiProperty映射.Controls.Add(Me.cbo存货编码)
        Me.GroupBoxiProperty映射.Controls.Add(Me.lbl存货编码)
        Me.GroupBoxiProperty映射.Controls.Add(Me.lbl文件名)
        Me.GroupBoxiProperty映射.Controls.Add(Me.cbo文件名)
        Me.GroupBoxiProperty映射.Controls.Add(Me.lbl图号)
        Me.GroupBoxiProperty映射.Controls.Add(Me.cbo图号)
        Me.GroupBoxiProperty映射.Location = New System.Drawing.Point(6, 10)
        Me.GroupBoxiProperty映射.Name = "GroupBoxiProperty映射"
        Me.GroupBoxiProperty映射.Size = New System.Drawing.Size(191, 143)
        Me.GroupBoxiProperty映射.TabIndex = 16
        Me.GroupBoxiProperty映射.TabStop = False
        Me.GroupBoxiProperty映射.Text = "iProperty映射"
        '
        'cbo供应商
        '
        Me.cbo供应商.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo供应商.FormattingEnabled = True
        Me.cbo供应商.Items.AddRange(New Object() {"零件代号", "库存编号", "描述", "项目", "成本中心", "预估成本", "供应商"})
        Me.cbo供应商.Location = New System.Drawing.Point(85, 105)
        Me.cbo供应商.Name = "cbo供应商"
        Me.cbo供应商.Size = New System.Drawing.Size(86, 20)
        Me.cbo供应商.TabIndex = 3
        '
        'lbl采购来源
        '
        Me.lbl采购来源.AutoSize = True
        Me.lbl采购来源.Location = New System.Drawing.Point(21, 108)
        Me.lbl采购来源.Name = "lbl采购来源"
        Me.lbl采购来源.Size = New System.Drawing.Size(65, 12)
        Me.lbl采购来源.TabIndex = 7
        Me.lbl采购来源.Text = "采购来源："
        '
        'cbo存货编码
        '
        Me.cbo存货编码.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo存货编码.FormattingEnabled = True
        Me.cbo存货编码.Items.AddRange(New Object() {"零件代号", "库存编号", "描述", "项目", "成本中心", "预估成本", "供应商"})
        Me.cbo存货编码.Location = New System.Drawing.Point(85, 75)
        Me.cbo存货编码.Name = "cbo存货编码"
        Me.cbo存货编码.Size = New System.Drawing.Size(86, 20)
        Me.cbo存货编码.TabIndex = 2
        '
        'lbl存货编码
        '
        Me.lbl存货编码.AutoSize = True
        Me.lbl存货编码.Location = New System.Drawing.Point(21, 80)
        Me.lbl存货编码.Name = "lbl存货编码"
        Me.lbl存货编码.Size = New System.Drawing.Size(65, 12)
        Me.lbl存货编码.TabIndex = 5
        Me.lbl存货编码.Text = "存货编码："
        '
        'lbl文件名
        '
        Me.lbl文件名.AutoSize = True
        Me.lbl文件名.Location = New System.Drawing.Point(21, 52)
        Me.lbl文件名.Name = "lbl文件名"
        Me.lbl文件名.Size = New System.Drawing.Size(53, 12)
        Me.lbl文件名.TabIndex = 4
        Me.lbl文件名.Text = "文件名："
        '
        'cbo文件名
        '
        Me.cbo文件名.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo文件名.FormattingEnabled = True
        Me.cbo文件名.Items.AddRange(New Object() {"零件代号", "库存编号", "描述", "项目", "成本中心", "预估成本", "供应商"})
        Me.cbo文件名.Location = New System.Drawing.Point(85, 49)
        Me.cbo文件名.Name = "cbo文件名"
        Me.cbo文件名.Size = New System.Drawing.Size(87, 20)
        Me.cbo文件名.TabIndex = 1
        '
        'lbl图号
        '
        Me.lbl图号.AutoSize = True
        Me.lbl图号.Location = New System.Drawing.Point(21, 24)
        Me.lbl图号.Name = "lbl图号"
        Me.lbl图号.Size = New System.Drawing.Size(53, 12)
        Me.lbl图号.TabIndex = 3
        Me.lbl图号.Text = "图  号："
        '
        'cbo图号
        '
        Me.cbo图号.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo图号.FormattingEnabled = True
        Me.cbo图号.Items.AddRange(New Object() {"零件代号", "库存编号", "描述", "项目", "成本中心", "预估成本", "供应商"})
        Me.cbo图号.Location = New System.Drawing.Point(85, 20)
        Me.cbo图号.Name = "cbo图号"
        Me.cbo图号.Size = New System.Drawing.Size(87, 20)
        Me.cbo图号.TabIndex = 0
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage常规)
        Me.TabControl.Controls.Add(Me.TabPage模型)
        Me.TabControl.Controls.Add(Me.TabPage工程图)
        Me.TabControl.Controls.Add(Me.TabPage展开图)
        Me.TabControl.Location = New System.Drawing.Point(2, 11)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(624, 316)
        Me.TabControl.TabIndex = 0
        '
        'TabPage工程图
        '
        Me.TabPage工程图.Controls.Add(Me.chk逆时针序号)
        Me.TabPage工程图.Controls.Add(Me.chk模型匹配检查)
        Me.TabPage工程图.Controls.Add(Me.GroupBox标题栏)
        Me.TabPage工程图.Controls.Add(Me.GroupBox页边距)
        Me.TabPage工程图.Controls.Add(Me.GroupBox视图)
        Me.TabPage工程图.Controls.Add(Me.GroupBox工程图模板)
        Me.TabPage工程图.Location = New System.Drawing.Point(4, 22)
        Me.TabPage工程图.Name = "TabPage工程图"
        Me.TabPage工程图.Size = New System.Drawing.Size(616, 290)
        Me.TabPage工程图.TabIndex = 2
        Me.TabPage工程图.Text = "工程图"
        Me.TabPage工程图.UseVisualStyleBackColor = True
        '
        'chk逆时针序号
        '
        Me.chk逆时针序号.AutoSize = True
        Me.chk逆时针序号.Location = New System.Drawing.Point(430, 249)
        Me.chk逆时针序号.Name = "chk逆时针序号"
        Me.chk逆时针序号.Size = New System.Drawing.Size(84, 16)
        Me.chk逆时针序号.TabIndex = 34
        Me.chk逆时针序号.Text = "逆时针序号"
        Me.chk逆时针序号.UseVisualStyleBackColor = True
        '
        'chk模型匹配检查
        '
        Me.chk模型匹配检查.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chk模型匹配检查.AutoSize = True
        Me.chk模型匹配检查.Checked = True
        Me.chk模型匹配检查.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk模型匹配检查.Location = New System.Drawing.Point(430, 222)
        Me.chk模型匹配检查.Name = "chk模型匹配检查"
        Me.chk模型匹配检查.Size = New System.Drawing.Size(96, 16)
        Me.chk模型匹配检查.TabIndex = 33
        Me.chk模型匹配检查.Text = "模型匹配检查"
        Me.chk模型匹配检查.UseVisualStyleBackColor = True
        '
        'GroupBox标题栏
        '
        Me.GroupBox标题栏.Controls.Add(Me.txt零件图框)
        Me.GroupBox标题栏.Controls.Add(Me.txt部件图框)
        Me.GroupBox标题栏.Controls.Add(Me.lbl零件图框)
        Me.GroupBox标题栏.Controls.Add(Me.lbl部件图框)
        Me.GroupBox标题栏.Location = New System.Drawing.Point(430, 80)
        Me.GroupBox标题栏.Name = "GroupBox标题栏"
        Me.GroupBox标题栏.Size = New System.Drawing.Size(171, 123)
        Me.GroupBox标题栏.TabIndex = 32
        Me.GroupBox标题栏.TabStop = False
        Me.GroupBox标题栏.Text = "标题栏"
        '
        'txt零件图框
        '
        Me.txt零件图框.Location = New System.Drawing.Point(47, 55)
        Me.txt零件图框.Name = "txt零件图框"
        Me.txt零件图框.Size = New System.Drawing.Size(113, 21)
        Me.txt零件图框.TabIndex = 1
        '
        'txt部件图框
        '
        Me.txt部件图框.Location = New System.Drawing.Point(47, 22)
        Me.txt部件图框.Name = "txt部件图框"
        Me.txt部件图框.Size = New System.Drawing.Size(113, 21)
        Me.txt部件图框.TabIndex = 0
        '
        'lbl零件图框
        '
        Me.lbl零件图框.AutoSize = True
        Me.lbl零件图框.Location = New System.Drawing.Point(6, 55)
        Me.lbl零件图框.Name = "lbl零件图框"
        Me.lbl零件图框.Size = New System.Drawing.Size(41, 12)
        Me.lbl零件图框.TabIndex = 9
        Me.lbl零件图框.Text = "零件："
        '
        'lbl部件图框
        '
        Me.lbl部件图框.AutoSize = True
        Me.lbl部件图框.Location = New System.Drawing.Point(6, 25)
        Me.lbl部件图框.Name = "lbl部件图框"
        Me.lbl部件图框.Size = New System.Drawing.Size(41, 12)
        Me.lbl部件图框.TabIndex = 8
        Me.lbl部件图框.Text = "部件："
        '
        'GroupBox页边距
        '
        Me.GroupBox页边距.Controls.Add(Me.NumericUpDown页边距右)
        Me.GroupBox页边距.Controls.Add(Me.NumericUpDown页边距左)
        Me.GroupBox页边距.Controls.Add(Me.NumericUpDown页边距下)
        Me.GroupBox页边距.Controls.Add(Me.NumericUpDown页边距上)
        Me.GroupBox页边距.Controls.Add(Me.Label2)
        Me.GroupBox页边距.Location = New System.Drawing.Point(13, 213)
        Me.GroupBox页边距.Name = "GroupBox页边距"
        Me.GroupBox页边距.Size = New System.Drawing.Size(391, 57)
        Me.GroupBox页边距.TabIndex = 31
        Me.GroupBox页边距.TabStop = False
        Me.GroupBox页边距.Text = "页边距"
        '
        'NumericUpDown页边距右
        '
        Me.NumericUpDown页边距右.Location = New System.Drawing.Point(330, 23)
        Me.NumericUpDown页边距右.Name = "NumericUpDown页边距右"
        Me.NumericUpDown页边距右.Size = New System.Drawing.Size(49, 21)
        Me.NumericUpDown页边距右.TabIndex = 3
        Me.NumericUpDown页边距右.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'NumericUpDown页边距左
        '
        Me.NumericUpDown页边距左.Location = New System.Drawing.Point(232, 23)
        Me.NumericUpDown页边距左.Name = "NumericUpDown页边距左"
        Me.NumericUpDown页边距左.Size = New System.Drawing.Size(49, 21)
        Me.NumericUpDown页边距左.TabIndex = 2
        Me.NumericUpDown页边距左.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'NumericUpDown页边距下
        '
        Me.NumericUpDown页边距下.Location = New System.Drawing.Point(134, 23)
        Me.NumericUpDown页边距下.Name = "NumericUpDown页边距下"
        Me.NumericUpDown页边距下.Size = New System.Drawing.Size(49, 21)
        Me.NumericUpDown页边距下.TabIndex = 1
        Me.NumericUpDown页边距下.Value = New Decimal(New Integer() {35, 0, 0, 0})
        '
        'NumericUpDown页边距上
        '
        Me.NumericUpDown页边距上.Location = New System.Drawing.Point(36, 23)
        Me.NumericUpDown页边距上.Name = "NumericUpDown页边距上"
        Me.NumericUpDown页边距上.Size = New System.Drawing.Size(49, 21)
        Me.NumericUpDown页边距上.TabIndex = 0
        Me.NumericUpDown页边距上.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(311, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "上               下              左              右"
        '
        'GroupBox视图
        '
        Me.GroupBox视图.Controls.Add(Me.chk标注尺寸)
        Me.GroupBox视图.Controls.Add(Me.lbl前视图)
        Me.GroupBox视图.Controls.Add(Me.chk左视图)
        Me.GroupBox视图.Controls.Add(Me.chk俯视图)
        Me.GroupBox视图.Controls.Add(Me.chk右视图)
        Me.GroupBox视图.Controls.Add(Me.chk仰视图)
        Me.GroupBox视图.Controls.Add(Me.chk螺纹特征)
        Me.GroupBox视图.Controls.Add(Me.rdo显示隐藏线)
        Me.GroupBox视图.Controls.Add(Me.rdo不显示隐藏线)
        Me.GroupBox视图.Controls.Add(Me.chk相切边)
        Me.GroupBox视图.Controls.Add(Me.chk钣金自动展开)
        Me.GroupBox视图.Controls.Add(Me.chk第三视角)
        Me.GroupBox视图.Location = New System.Drawing.Point(11, 80)
        Me.GroupBox视图.Name = "GroupBox视图"
        Me.GroupBox视图.Size = New System.Drawing.Size(413, 123)
        Me.GroupBox视图.TabIndex = 30
        Me.GroupBox视图.TabStop = False
        Me.GroupBox视图.Text = "视图"
        '
        'chk标注尺寸
        '
        Me.chk标注尺寸.AutoSize = True
        Me.chk标注尺寸.Location = New System.Drawing.Point(193, 24)
        Me.chk标注尺寸.Name = "chk标注尺寸"
        Me.chk标注尺寸.Size = New System.Drawing.Size(72, 16)
        Me.chk标注尺寸.TabIndex = 2
        Me.chk标注尺寸.Text = "标注尺寸"
        Me.chk标注尺寸.UseVisualStyleBackColor = True
        '
        'lbl前视图
        '
        Me.lbl前视图.AutoSize = True
        Me.lbl前视图.Location = New System.Drawing.Point(296, 59)
        Me.lbl前视图.Name = "lbl前视图"
        Me.lbl前视图.Size = New System.Drawing.Size(41, 12)
        Me.lbl前视图.TabIndex = 43
        Me.lbl前视图.Text = "前视图"
        '
        'chk左视图
        '
        Me.chk左视图.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk左视图.AutoSize = True
        Me.chk左视图.Location = New System.Drawing.Point(227, 57)
        Me.chk左视图.Name = "chk左视图"
        Me.chk左视图.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chk左视图.Size = New System.Drawing.Size(60, 16)
        Me.chk左视图.TabIndex = 8
        Me.chk左视图.Text = "左视图"
        Me.chk左视图.UseVisualStyleBackColor = True
        '
        'chk俯视图
        '
        Me.chk俯视图.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk俯视图.AutoSize = True
        Me.chk俯视图.Location = New System.Drawing.Point(289, 95)
        Me.chk俯视图.Name = "chk俯视图"
        Me.chk俯视图.Size = New System.Drawing.Size(60, 16)
        Me.chk俯视图.TabIndex = 9
        Me.chk俯视图.Text = "俯视图"
        Me.chk俯视图.UseVisualStyleBackColor = True
        '
        'chk右视图
        '
        Me.chk右视图.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk右视图.AutoSize = True
        Me.chk右视图.Location = New System.Drawing.Point(343, 57)
        Me.chk右视图.Name = "chk右视图"
        Me.chk右视图.Size = New System.Drawing.Size(60, 16)
        Me.chk右视图.TabIndex = 10
        Me.chk右视图.Text = "右视图"
        Me.chk右视图.UseVisualStyleBackColor = True
        '
        'chk仰视图
        '
        Me.chk仰视图.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk仰视图.AutoSize = True
        Me.chk仰视图.Location = New System.Drawing.Point(289, 24)
        Me.chk仰视图.Name = "chk仰视图"
        Me.chk仰视图.Size = New System.Drawing.Size(60, 16)
        Me.chk仰视图.TabIndex = 7
        Me.chk仰视图.Text = "仰视图"
        Me.chk仰视图.UseVisualStyleBackColor = True
        '
        'chk螺纹特征
        '
        Me.chk螺纹特征.AutoSize = True
        Me.chk螺纹特征.Location = New System.Drawing.Point(111, 54)
        Me.chk螺纹特征.Name = "chk螺纹特征"
        Me.chk螺纹特征.Size = New System.Drawing.Size(72, 16)
        Me.chk螺纹特征.TabIndex = 6
        Me.chk螺纹特征.Text = "螺纹特征"
        Me.chk螺纹特征.UseVisualStyleBackColor = True
        '
        'rdo显示隐藏线
        '
        Me.rdo显示隐藏线.AutoSize = True
        Me.rdo显示隐藏线.Location = New System.Drawing.Point(111, 86)
        Me.rdo显示隐藏线.Name = "rdo显示隐藏线"
        Me.rdo显示隐藏线.Size = New System.Drawing.Size(83, 16)
        Me.rdo显示隐藏线.TabIndex = 5
        Me.rdo显示隐藏线.TabStop = True
        Me.rdo显示隐藏线.Text = "显示隐藏线"
        Me.rdo显示隐藏线.UseVisualStyleBackColor = True
        '
        'rdo不显示隐藏线
        '
        Me.rdo不显示隐藏线.AutoSize = True
        Me.rdo不显示隐藏线.Location = New System.Drawing.Point(10, 86)
        Me.rdo不显示隐藏线.Name = "rdo不显示隐藏线"
        Me.rdo不显示隐藏线.Size = New System.Drawing.Size(95, 16)
        Me.rdo不显示隐藏线.TabIndex = 4
        Me.rdo不显示隐藏线.TabStop = True
        Me.rdo不显示隐藏线.Text = "不显示隐藏线"
        Me.rdo不显示隐藏线.UseVisualStyleBackColor = True
        '
        'chk相切边
        '
        Me.chk相切边.AutoSize = True
        Me.chk相切边.Location = New System.Drawing.Point(111, 24)
        Me.chk相切边.Name = "chk相切边"
        Me.chk相切边.Size = New System.Drawing.Size(60, 16)
        Me.chk相切边.TabIndex = 1
        Me.chk相切边.Text = "相切边"
        Me.chk相切边.UseVisualStyleBackColor = True
        '
        'chk钣金自动展开
        '
        Me.chk钣金自动展开.AutoSize = True
        Me.chk钣金自动展开.Location = New System.Drawing.Point(9, 24)
        Me.chk钣金自动展开.Name = "chk钣金自动展开"
        Me.chk钣金自动展开.Size = New System.Drawing.Size(96, 16)
        Me.chk钣金自动展开.TabIndex = 0
        Me.chk钣金自动展开.Text = "钣金自动展开"
        Me.chk钣金自动展开.UseVisualStyleBackColor = True
        '
        'chk第三视角
        '
        Me.chk第三视角.AutoSize = True
        Me.chk第三视角.Location = New System.Drawing.Point(9, 54)
        Me.chk第三视角.Name = "chk第三视角"
        Me.chk第三视角.Size = New System.Drawing.Size(72, 16)
        Me.chk第三视角.TabIndex = 3
        Me.chk第三视角.Text = "第三视角"
        Me.chk第三视角.UseVisualStyleBackColor = True
        '
        'GroupBox工程图模板
        '
        Me.GroupBox工程图模板.Controls.Add(Me.btn选择工程图模板)
        Me.GroupBox工程图模板.Controls.Add(Me.txt工程图模板)
        Me.GroupBox工程图模板.Controls.Add(Me.lbl模板工程图)
        Me.GroupBox工程图模板.Location = New System.Drawing.Point(11, 14)
        Me.GroupBox工程图模板.Name = "GroupBox工程图模板"
        Me.GroupBox工程图模板.Size = New System.Drawing.Size(594, 58)
        Me.GroupBox工程图模板.TabIndex = 24
        Me.GroupBox工程图模板.TabStop = False
        Me.GroupBox工程图模板.Text = "工程图模板"
        '
        'btn选择工程图模板
        '
        Me.btn选择工程图模板.Location = New System.Drawing.Point(518, 17)
        Me.btn选择工程图模板.Name = "btn选择工程图模板"
        Me.btn选择工程图模板.Size = New System.Drawing.Size(25, 25)
        Me.btn选择工程图模板.TabIndex = 0
        Me.btn选择工程图模板.UseVisualStyleBackColor = True
        '
        'txt工程图模板
        '
        Me.txt工程图模板.Location = New System.Drawing.Point(80, 19)
        Me.txt工程图模板.Name = "txt工程图模板"
        Me.txt工程图模板.ReadOnly = True
        Me.txt工程图模板.Size = New System.Drawing.Size(420, 21)
        Me.txt工程图模板.TabIndex = 8
        Me.txt工程图模板.TabStop = False
        '
        'lbl模板工程图
        '
        Me.lbl模板工程图.AutoSize = True
        Me.lbl模板工程图.Location = New System.Drawing.Point(7, 23)
        Me.lbl模板工程图.Name = "lbl模板工程图"
        Me.lbl模板工程图.Size = New System.Drawing.Size(77, 12)
        Me.lbl模板工程图.TabIndex = 7
        Me.lbl模板工程图.Text = "工程图模板："
        '
        'TabPage展开图
        '
        Me.TabPage展开图.Controls.Add(Me.GroupBox展开图模板)
        Me.TabPage展开图.Controls.Add(Me.chk展开图标注)
        Me.TabPage展开图.Controls.Add(Me.GroupBox下)
        Me.TabPage展开图.Controls.Add(Me.GroupBox上)
        Me.TabPage展开图.Location = New System.Drawing.Point(4, 22)
        Me.TabPage展开图.Name = "TabPage展开图"
        Me.TabPage展开图.Size = New System.Drawing.Size(616, 290)
        Me.TabPage展开图.TabIndex = 3
        Me.TabPage展开图.Text = "展开图"
        Me.TabPage展开图.UseVisualStyleBackColor = True
        '
        'GroupBox展开图模板
        '
        Me.GroupBox展开图模板.Controls.Add(Me.btn展开图模板)
        Me.GroupBox展开图模板.Controls.Add(Me.txt展开图模板)
        Me.GroupBox展开图模板.Controls.Add(Me.lbl展开图模板)
        Me.GroupBox展开图模板.Location = New System.Drawing.Point(11, 14)
        Me.GroupBox展开图模板.Name = "GroupBox展开图模板"
        Me.GroupBox展开图模板.Size = New System.Drawing.Size(594, 58)
        Me.GroupBox展开图模板.TabIndex = 25
        Me.GroupBox展开图模板.TabStop = False
        Me.GroupBox展开图模板.Text = "展开图模板"
        '
        'btn展开图模板
        '
        Me.btn展开图模板.Location = New System.Drawing.Point(518, 17)
        Me.btn展开图模板.Name = "btn展开图模板"
        Me.btn展开图模板.Size = New System.Drawing.Size(25, 25)
        Me.btn展开图模板.TabIndex = 0
        Me.btn展开图模板.UseVisualStyleBackColor = True
        '
        'txt展开图模板
        '
        Me.txt展开图模板.Location = New System.Drawing.Point(80, 19)
        Me.txt展开图模板.Name = "txt展开图模板"
        Me.txt展开图模板.ReadOnly = True
        Me.txt展开图模板.Size = New System.Drawing.Size(420, 21)
        Me.txt展开图模板.TabIndex = 8
        '
        'lbl展开图模板
        '
        Me.lbl展开图模板.AutoSize = True
        Me.lbl展开图模板.Location = New System.Drawing.Point(7, 23)
        Me.lbl展开图模板.Name = "lbl展开图模板"
        Me.lbl展开图模板.Size = New System.Drawing.Size(77, 12)
        Me.lbl展开图模板.TabIndex = 7
        Me.lbl展开图模板.Text = "工程图模板："
        '
        'chk展开图标注
        '
        Me.chk展开图标注.AutoSize = True
        Me.chk展开图标注.Location = New System.Drawing.Point(26, 229)
        Me.chk展开图标注.Name = "chk展开图标注"
        Me.chk展开图标注.Size = New System.Drawing.Size(84, 16)
        Me.chk展开图标注.TabIndex = 0
        Me.chk展开图标注.Text = "展开图标注"
        Me.chk展开图标注.UseVisualStyleBackColor = True
        '
        'GroupBox下
        '
        Me.GroupBox下.Controls.Add(Me.cbo向下线宽)
        Me.GroupBox下.Controls.Add(Me.cbo向下线型)
        Me.GroupBox下.Controls.Add(Me.lbl颜色下)
        Me.GroupBox下.Controls.Add(Me.btn向下颜色)
        Me.GroupBox下.Controls.Add(Me.lbl线宽下)
        Me.GroupBox下.Controls.Add(Me.lbl线型下)
        Me.GroupBox下.Location = New System.Drawing.Point(278, 80)
        Me.GroupBox下.Name = "GroupBox下"
        Me.GroupBox下.Size = New System.Drawing.Size(234, 130)
        Me.GroupBox下.TabIndex = 1
        Me.GroupBox下.TabStop = False
        Me.GroupBox下.Text = "下"
        '
        'cbo向下线宽
        '
        Me.cbo向下线宽.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo向下线宽.FormattingEnabled = True
        Me.cbo向下线宽.Items.AddRange(New Object() {"0.18", "0.25", "0.35", "0.5", "0.7", "1", "1.4", "2"})
        Me.cbo向下线宽.Location = New System.Drawing.Point(64, 52)
        Me.cbo向下线宽.Name = "cbo向下线宽"
        Me.cbo向下线宽.Size = New System.Drawing.Size(140, 20)
        Me.cbo向下线宽.TabIndex = 1
        '
        'cbo向下线型
        '
        Me.cbo向下线型.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo向下线型.FormattingEnabled = True
        Me.cbo向下线型.Items.AddRange(New Object() {"点长划线", "双点长划线", "三点长划线"})
        Me.cbo向下线型.Location = New System.Drawing.Point(64, 19)
        Me.cbo向下线型.Name = "cbo向下线型"
        Me.cbo向下线型.Size = New System.Drawing.Size(140, 20)
        Me.cbo向下线型.TabIndex = 0
        '
        'lbl颜色下
        '
        Me.lbl颜色下.AutoSize = True
        Me.lbl颜色下.Location = New System.Drawing.Point(16, 90)
        Me.lbl颜色下.Name = "lbl颜色下"
        Me.lbl颜色下.Size = New System.Drawing.Size(29, 12)
        Me.lbl颜色下.TabIndex = 3
        Me.lbl颜色下.Text = "颜色"
        '
        'btn向下颜色
        '
        Me.btn向下颜色.Location = New System.Drawing.Point(65, 82)
        Me.btn向下颜色.Name = "btn向下颜色"
        Me.btn向下颜色.Size = New System.Drawing.Size(38, 26)
        Me.btn向下颜色.TabIndex = 2
        Me.btn向下颜色.UseVisualStyleBackColor = True
        '
        'lbl线宽下
        '
        Me.lbl线宽下.AutoSize = True
        Me.lbl线宽下.Location = New System.Drawing.Point(16, 58)
        Me.lbl线宽下.Name = "lbl线宽下"
        Me.lbl线宽下.Size = New System.Drawing.Size(29, 12)
        Me.lbl线宽下.TabIndex = 1
        Me.lbl线宽下.Text = "线宽"
        '
        'lbl线型下
        '
        Me.lbl线型下.AutoSize = True
        Me.lbl线型下.Location = New System.Drawing.Point(16, 26)
        Me.lbl线型下.Name = "lbl线型下"
        Me.lbl线型下.Size = New System.Drawing.Size(29, 12)
        Me.lbl线型下.TabIndex = 0
        Me.lbl线型下.Text = "线型"
        '
        'GroupBox上
        '
        Me.GroupBox上.Controls.Add(Me.cbo向上线宽)
        Me.GroupBox上.Controls.Add(Me.cbo向上线型)
        Me.GroupBox上.Controls.Add(Me.lbl颜色上)
        Me.GroupBox上.Controls.Add(Me.btn向上颜色)
        Me.GroupBox上.Controls.Add(Me.lbl线宽上)
        Me.GroupBox上.Controls.Add(Me.lbl线型上)
        Me.GroupBox上.Location = New System.Drawing.Point(11, 80)
        Me.GroupBox上.Name = "GroupBox上"
        Me.GroupBox上.Size = New System.Drawing.Size(234, 130)
        Me.GroupBox上.TabIndex = 0
        Me.GroupBox上.TabStop = False
        Me.GroupBox上.Text = "上"
        '
        'cbo向上线宽
        '
        Me.cbo向上线宽.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo向上线宽.FormattingEnabled = True
        Me.cbo向上线宽.Items.AddRange(New Object() {"0.18", "0.25", "0.35", "0.5", "0.7", "1", "1.4", "2"})
        Me.cbo向上线宽.Location = New System.Drawing.Point(65, 54)
        Me.cbo向上线宽.Name = "cbo向上线宽"
        Me.cbo向上线宽.Size = New System.Drawing.Size(140, 20)
        Me.cbo向上线宽.TabIndex = 1
        '
        'cbo向上线型
        '
        Me.cbo向上线型.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo向上线型.FormattingEnabled = True
        Me.cbo向上线型.Items.AddRange(New Object() {"点长划线", "双点长划线", "三点长划线"})
        Me.cbo向上线型.Location = New System.Drawing.Point(65, 22)
        Me.cbo向上线型.Name = "cbo向上线型"
        Me.cbo向上线型.Size = New System.Drawing.Size(140, 20)
        Me.cbo向上线型.TabIndex = 0
        '
        'lbl颜色上
        '
        Me.lbl颜色上.AutoSize = True
        Me.lbl颜色上.Location = New System.Drawing.Point(16, 90)
        Me.lbl颜色上.Name = "lbl颜色上"
        Me.lbl颜色上.Size = New System.Drawing.Size(29, 12)
        Me.lbl颜色上.TabIndex = 3
        Me.lbl颜色上.Text = "颜色"
        '
        'btn向上颜色
        '
        Me.btn向上颜色.Location = New System.Drawing.Point(65, 83)
        Me.btn向上颜色.Name = "btn向上颜色"
        Me.btn向上颜色.Size = New System.Drawing.Size(38, 26)
        Me.btn向上颜色.TabIndex = 2
        Me.btn向上颜色.UseVisualStyleBackColor = True
        '
        'lbl线宽上
        '
        Me.lbl线宽上.AutoSize = True
        Me.lbl线宽上.Location = New System.Drawing.Point(16, 58)
        Me.lbl线宽上.Name = "lbl线宽上"
        Me.lbl线宽上.Size = New System.Drawing.Size(29, 12)
        Me.lbl线宽上.TabIndex = 1
        Me.lbl线宽上.Text = "线宽"
        '
        'lbl线型上
        '
        Me.lbl线型上.AutoSize = True
        Me.lbl线型上.Location = New System.Drawing.Point(16, 26)
        Me.lbl线型上.Name = "lbl线型上"
        Me.lbl线型上.Size = New System.Drawing.Size(29, 12)
        Me.lbl线型上.TabIndex = 0
        Me.lbl线型上.Text = "线型"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 12)
        Me.Label1.TabIndex = 7
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(103, 59)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(408, 21)
        Me.TextBox1.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(519, 57)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(52, 25)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "选择"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmOption
        '
        Me.AcceptButton = Me.btn确定
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn取消
        Me.ClientSize = New System.Drawing.Size(638, 370)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.btn确定)
        Me.Controls.Add(Me.btn取消)
        Me.Controls.Add(Me.chk检查更新)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOption"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "应用程序选项"
        Me.TopMost = True
        Me.TabPage模型.ResumeLayout(False)
        Me.TabPage模型.PerformLayout()
        CType(Me.NUD查找文件夹层数, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxERP查询.ResumeLayout(False)
        Me.GroupBoxERP查询.PerformLayout()
        Me.GroupBoxBOM导出项目.ResumeLayout(False)
        Me.GroupBoxBOM导出项目.PerformLayout()
        Me.TabPage常规.ResumeLayout(False)
        Me.GroupBox快速打印.ResumeLayout(False)
        Me.GroupBox快速打印.PerformLayout()
        Me.GroupBox质量映射.ResumeLayout(False)
        Me.GroupBox质量映射.PerformLayout()
        Me.GroupBox精度设置.ResumeLayout(False)
        Me.GroupBox精度设置.PerformLayout()
        Me.GroupBox签字.ResumeLayout(False)
        Me.GroupBox签字.PerformLayout()
        Me.GroupBox比例映射.ResumeLayout(False)
        Me.GroupBox比例映射.PerformLayout()
        Me.GroupBox对称零件iProperty映射.ResumeLayout(False)
        Me.GroupBox对称零件iProperty映射.PerformLayout()
        Me.GroupBoxiProperty映射.ResumeLayout(False)
        Me.GroupBoxiProperty映射.PerformLayout()
        Me.TabControl.ResumeLayout(False)
        Me.TabPage工程图.ResumeLayout(False)
        Me.TabPage工程图.PerformLayout()
        Me.GroupBox标题栏.ResumeLayout(False)
        Me.GroupBox标题栏.PerformLayout()
        Me.GroupBox页边距.ResumeLayout(False)
        Me.GroupBox页边距.PerformLayout()
        CType(Me.NumericUpDown页边距右, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown页边距左, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown页边距下, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown页边距上, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox视图.ResumeLayout(False)
        Me.GroupBox视图.PerformLayout()
        Me.GroupBox工程图模板.ResumeLayout(False)
        Me.GroupBox工程图模板.PerformLayout()
        Me.TabPage展开图.ResumeLayout(False)
        Me.TabPage展开图.PerformLayout()
        Me.GroupBox展开图模板.ResumeLayout(False)
        Me.GroupBox展开图模板.PerformLayout()
        Me.GroupBox下.ResumeLayout(False)
        Me.GroupBox下.PerformLayout()
        Me.GroupBox上.ResumeLayout(False)
        Me.GroupBox上.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn确定 As System.Windows.Forms.Button
    Friend WithEvents btn取消 As System.Windows.Forms.Button
    Friend WithEvents chk检查更新 As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage模型 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBoxERP查询 As System.Windows.Forms.GroupBox
    Friend WithEvents btn选择erp数据库 As System.Windows.Forms.Button
    Friend WithEvents btn更新数据库 As System.Windows.Forms.Button
    Friend WithEvents btn打开erp数据库 As System.Windows.Forms.Button
    Friend WithEvents txt查询列 As System.Windows.Forms.TextBox
    Friend WithEvents lblERP列 As System.Windows.Forms.Label
    Friend WithEvents txt查找范围 As System.Windows.Forms.TextBox
    Friend WithEvents lbl查询列 As System.Windows.Forms.Label
    Friend WithEvents txt基础数据文件 As System.Windows.Forms.TextBox
    Friend WithEvents lbl基础数据文件 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxBOM导出项目 As System.Windows.Forms.GroupBox
    Friend WithEvents btn清除 As System.Windows.Forms.Button
    Friend WithEvents btn还原 As System.Windows.Forms.Button
    Friend WithEvents btn添加 As System.Windows.Forms.Button
    Friend WithEvents cbo添加 As System.Windows.Forms.ComboBox
    Friend WithEvents txtBOM导出项 As System.Windows.Forms.TextBox
    Friend WithEvents lblBOM导出项目 As System.Windows.Forms.Label
    Friend WithEvents TabPage常规 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox快速打印 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo另存为 As System.Windows.Forms.ComboBox
    Friend WithEvents cbo打印机 As System.Windows.Forms.ComboBox
    Friend WithEvents chk匹配A3纸 As System.Windows.Forms.CheckBox
    Friend WithEvents chk签字 As System.Windows.Forms.CheckBox
    Friend WithEvents lbl打印机 As System.Windows.Forms.Label
    Friend WithEvents GroupBox质量映射 As System.Windows.Forms.GroupBox
    Friend WithEvents chk保存质量 As System.Windows.Forms.CheckBox
    Friend WithEvents txt图号 As System.Windows.Forms.TextBox
    Friend WithEvents lbl质量 As System.Windows.Forms.Label
    Friend WithEvents GroupBox精度设置 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo面积精度 As System.Windows.Forms.ComboBox
    Friend WithEvents lbl面积精度 As System.Windows.Forms.Label
    Friend WithEvents cbo质量精度 As System.Windows.Forms.ComboBox
    Friend WithEvents lbl质量精度 As System.Windows.Forms.Label
    Friend WithEvents GroupBox签字 As System.Windows.Forms.GroupBox
    Friend WithEvents chk同时签字 As System.Windows.Forms.CheckBox
    Friend WithEvents txt工程师 As System.Windows.Forms.TextBox
    Friend WithEvents lbl工程师 As System.Windows.Forms.Label
    Friend WithEvents chk签字后打印 As System.Windows.Forms.CheckBox
    Friend WithEvents txt打印日期 As System.Windows.Forms.TextBox
    Friend WithEvents lbl打印日期 As System.Windows.Forms.Label
    Friend WithEvents GroupBox比例映射 As System.Windows.Forms.GroupBox
    Friend WithEvents chk保存比例 As System.Windows.Forms.CheckBox
    Friend WithEvents txt比例 As System.Windows.Forms.TextBox
    Friend WithEvents lbl比例 As System.Windows.Forms.Label
    Friend WithEvents GroupBox对称零件iProperty映射 As System.Windows.Forms.GroupBox
    Friend WithEvents txt文件名映射 As System.Windows.Forms.TextBox
    Friend WithEvents txt图号映射 As System.Windows.Forms.TextBox
    Friend WithEvents lbl对称件文件名 As System.Windows.Forms.Label
    Friend WithEvents lbl对称件图号 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxiProperty映射 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo供应商 As System.Windows.Forms.ComboBox
    Friend WithEvents lbl采购来源 As System.Windows.Forms.Label
    Friend WithEvents cbo存货编码 As System.Windows.Forms.ComboBox
    Friend WithEvents lbl存货编码 As System.Windows.Forms.Label
    Friend WithEvents lbl文件名 As System.Windows.Forms.Label
    Friend WithEvents cbo文件名 As System.Windows.Forms.ComboBox
    Friend WithEvents lbl图号 As System.Windows.Forms.Label
    Friend WithEvents cbo图号 As System.Windows.Forms.ComboBox
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage工程图 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox工程图模板 As System.Windows.Forms.GroupBox
    Friend WithEvents btn选择工程图模板 As System.Windows.Forms.Button
    Friend WithEvents txt工程图模板 As System.Windows.Forms.TextBox
    Friend WithEvents lbl模板工程图 As System.Windows.Forms.Label
    Friend WithEvents btn图框配置 As System.Windows.Forms.Button
    Friend WithEvents btn配置文件 As System.Windows.Forms.Button
    Friend WithEvents TabPage展开图 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox上 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl颜色上 As System.Windows.Forms.Label
    Friend WithEvents btn向上颜色 As System.Windows.Forms.Button
    Friend WithEvents lbl线宽上 As System.Windows.Forms.Label
    Friend WithEvents lbl线型上 As System.Windows.Forms.Label
    Friend WithEvents GroupBox下 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl颜色下 As System.Windows.Forms.Label
    Friend WithEvents btn向下颜色 As System.Windows.Forms.Button
    Friend WithEvents lbl线宽下 As System.Windows.Forms.Label
    Friend WithEvents lbl线型下 As System.Windows.Forms.Label
    Friend WithEvents chk展开图标注 As System.Windows.Forms.CheckBox
    Friend WithEvents cbo向上线型 As System.Windows.Forms.ComboBox
    Friend WithEvents cbo向上线宽 As System.Windows.Forms.ComboBox
    Friend WithEvents cbo向下线宽 As System.Windows.Forms.ComboBox
    Friend WithEvents cbo向下线型 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox视图 As System.Windows.Forms.GroupBox
    Friend WithEvents chk相切边 As System.Windows.Forms.CheckBox
    Friend WithEvents chk钣金自动展开 As System.Windows.Forms.CheckBox
    Friend WithEvents chk第三视角 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox页边距 As System.Windows.Forms.GroupBox
    Friend WithEvents NumericUpDown页边距上 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown页边距右 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown页边距左 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown页边距下 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rdo显示隐藏线 As System.Windows.Forms.RadioButton
    Friend WithEvents rdo不显示隐藏线 As System.Windows.Forms.RadioButton
    Friend WithEvents chk螺纹特征 As System.Windows.Forms.CheckBox
    Friend WithEvents chk左视图 As System.Windows.Forms.CheckBox
    Friend WithEvents chk仰视图 As System.Windows.Forms.CheckBox
    Friend WithEvents chk俯视图 As System.Windows.Forms.CheckBox
    Friend WithEvents chk右视图 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox标题栏 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox展开图模板 As System.Windows.Forms.GroupBox
    Friend WithEvents btn展开图模板 As System.Windows.Forms.Button
    Friend WithEvents txt展开图模板 As System.Windows.Forms.TextBox
    Friend WithEvents lbl展开图模板 As System.Windows.Forms.Label
    Friend WithEvents lbl前视图 As System.Windows.Forms.Label
    Friend WithEvents lbl零件图框 As System.Windows.Forms.Label
    Friend WithEvents lbl部件图框 As System.Windows.Forms.Label
    Friend WithEvents txt零件图框 As System.Windows.Forms.TextBox
    Friend WithEvents txt部件图框 As System.Windows.Forms.TextBox
    Friend WithEvents chk标注尺寸 As System.Windows.Forms.CheckBox
    Friend WithEvents chk模型匹配检查 As System.Windows.Forms.CheckBox
    Friend WithEvents chk备份工程图 As System.Windows.Forms.CheckBox
    Friend WithEvents chk另存到子文件夹 As System.Windows.Forms.CheckBox
    Friend WithEvents chk逆时针序号 As System.Windows.Forms.CheckBox
    Friend WithEvents lbl查找文件夹层数 As System.Windows.Forms.Label
    Friend WithEvents NUD查找文件夹层数 As System.Windows.Forms.NumericUpDown
    Friend WithEvents chk检查重复图号 As System.Windows.Forms.CheckBox

End Class
