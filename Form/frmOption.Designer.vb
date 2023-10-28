<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOption
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
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
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage常规 = New System.Windows.Forms.TabPage()
        Me.btn图框配置 = New System.Windows.Forms.Button()
        Me.btn配置文件 = New System.Windows.Forms.Button()
        Me.GroupBox快速打印 = New System.Windows.Forms.GroupBox()
        Me.cbo另存为 = New System.Windows.Forms.ComboBox()
        Me.cmb打印机 = New System.Windows.Forms.ComboBox()
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
        Me.TabPage文件 = New System.Windows.Forms.TabPage()
        Me.GroupBox图框模板 = New System.Windows.Forms.GroupBox()
        Me.btn选择工程图模板 = New System.Windows.Forms.Button()
        Me.txt图框模板文件 = New System.Windows.Forms.TextBox()
        Me.lbl模板工程图 = New System.Windows.Forms.Label()
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
        Me.TabControl.SuspendLayout()
        Me.TabPage常规.SuspendLayout()
        Me.GroupBox快速打印.SuspendLayout()
        Me.GroupBox质量映射.SuspendLayout()
        Me.GroupBox精度设置.SuspendLayout()
        Me.GroupBox签字.SuspendLayout()
        Me.GroupBox比例映射.SuspendLayout()
        Me.GroupBox对称零件iProperty映射.SuspendLayout()
        Me.GroupBoxiProperty映射.SuspendLayout()
        Me.TabPage文件.SuspendLayout()
        Me.GroupBox图框模板.SuspendLayout()
        Me.GroupBoxERP查询.SuspendLayout()
        Me.GroupBoxBOM导出项目.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn确定
        '
        Me.btn确定.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn确定.Location = New System.Drawing.Point(460, 333)
        Me.btn确定.Name = "btn确定"
        Me.btn确定.Size = New System.Drawing.Size(75, 28)
        Me.btn确定.TabIndex = 0
        Me.btn确定.Text = "确定"
        '
        'btn取消
        '
        Me.btn取消.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn取消.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn取消.Location = New System.Drawing.Point(551, 333)
        Me.btn取消.Name = "btn取消"
        Me.btn取消.Size = New System.Drawing.Size(75, 28)
        Me.btn取消.TabIndex = 1
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
        Me.chk检查更新.TabIndex = 13
        Me.chk检查更新.Text = "启动时检查更新"
        Me.chk检查更新.UseVisualStyleBackColor = True
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage常规)
        Me.TabControl.Controls.Add(Me.TabPage文件)
        Me.TabControl.Location = New System.Drawing.Point(5, 10)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(624, 316)
        Me.TabControl.TabIndex = 21
        '
        'TabPage常规
        '
        Me.TabPage常规.Controls.Add(Me.btn图框配置)
        Me.TabPage常规.Controls.Add(Me.btn配置文件)
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
        'btn图框配置
        '
        Me.btn图框配置.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn图框配置.Location = New System.Drawing.Point(89, 254)
        Me.btn图框配置.Name = "btn图框配置"
        Me.btn图框配置.Size = New System.Drawing.Size(89, 28)
        Me.btn图框配置.TabIndex = 24
        Me.btn图框配置.Text = "图框配置文件"
        Me.btn图框配置.UseVisualStyleBackColor = True
        '
        'btn配置文件
        '
        Me.btn配置文件.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn配置文件.Location = New System.Drawing.Point(6, 254)
        Me.btn配置文件.Name = "btn配置文件"
        Me.btn配置文件.Size = New System.Drawing.Size(75, 28)
        Me.btn配置文件.TabIndex = 23
        Me.btn配置文件.Text = "配置文件"
        Me.btn配置文件.UseVisualStyleBackColor = True
        '
        'GroupBox快速打印
        '
        Me.GroupBox快速打印.Controls.Add(Me.cbo另存为)
        Me.GroupBox快速打印.Controls.Add(Me.cmb打印机)
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
        Me.cbo另存为.TabIndex = 38
        '
        'cmb打印机
        '
        Me.cmb打印机.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb打印机.FormattingEnabled = True
        Me.cmb打印机.Location = New System.Drawing.Point(57, 23)
        Me.cmb打印机.Name = "cmb打印机"
        Me.cmb打印机.Size = New System.Drawing.Size(141, 20)
        Me.cmb打印机.Sorted = True
        Me.cmb打印机.TabIndex = 37
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
        Me.chk匹配A3纸.TabIndex = 36
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
        Me.chk签字.TabIndex = 35
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
        Me.chk保存质量.Location = New System.Drawing.Point(18, 42)
        Me.chk保存质量.Name = "chk保存质量"
        Me.chk保存质量.Size = New System.Drawing.Size(120, 16)
        Me.chk保存质量.TabIndex = 7
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
        Me.lbl质量.TabIndex = 4
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
        Me.cbo面积精度.TabIndex = 12
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
        Me.cbo质量精度.TabIndex = 10
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
        Me.chk同时签字.TabIndex = 10
        Me.chk同时签字.Text = "同时签字"
        Me.chk同时签字.UseVisualStyleBackColor = True
        Me.chk同时签字.Visible = False
        '
        'txt工程师
        '
        Me.txt工程师.Location = New System.Drawing.Point(83, 47)
        Me.txt工程师.Name = "txt工程师"
        Me.txt工程师.Size = New System.Drawing.Size(98, 21)
        Me.txt工程师.TabIndex = 9
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
        Me.chk签字后打印.TabIndex = 7
        Me.chk签字后打印.Text = "签字后打开打印"
        Me.chk签字后打印.UseVisualStyleBackColor = True
        '
        'txt打印日期
        '
        Me.txt打印日期.Location = New System.Drawing.Point(83, 20)
        Me.txt打印日期.Name = "txt打印日期"
        Me.txt打印日期.Size = New System.Drawing.Size(98, 21)
        Me.txt打印日期.TabIndex = 6
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
        Me.chk保存比例.Location = New System.Drawing.Point(18, 42)
        Me.chk保存比例.Name = "chk保存比例"
        Me.chk保存比例.Size = New System.Drawing.Size(120, 16)
        Me.chk保存比例.TabIndex = 7
        Me.chk保存比例.Text = "保存工程图时写入"
        Me.chk保存比例.UseVisualStyleBackColor = True
        Me.chk保存比例.Visible = False
        '
        'txt比例
        '
        Me.txt比例.Location = New System.Drawing.Point(54, 17)
        Me.txt比例.Name = "txt比例"
        Me.txt比例.Size = New System.Drawing.Size(64, 21)
        Me.txt比例.TabIndex = 6
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
        Me.txt文件名映射.TabIndex = 6
        '
        'txt图号映射
        '
        Me.txt图号映射.Location = New System.Drawing.Point(77, 22)
        Me.txt图号映射.Name = "txt图号映射"
        Me.txt图号映射.Size = New System.Drawing.Size(95, 21)
        Me.txt图号映射.TabIndex = 5
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
        Me.cbo供应商.Items.AddRange(New Object() {"供应商", "成本中心", "描述"})
        Me.cbo供应商.Location = New System.Drawing.Point(85, 105)
        Me.cbo供应商.Name = "cbo供应商"
        Me.cbo供应商.Size = New System.Drawing.Size(86, 20)
        Me.cbo供应商.TabIndex = 8
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
        Me.cbo存货编码.Items.AddRange(New Object() {"成本中心", "描述"})
        Me.cbo存货编码.Location = New System.Drawing.Point(85, 75)
        Me.cbo存货编码.Name = "cbo存货编码"
        Me.cbo存货编码.Size = New System.Drawing.Size(86, 20)
        Me.cbo存货编码.TabIndex = 6
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
        Me.cbo文件名.Items.AddRange(New Object() {"零件代号", "库存编号", "描述"})
        Me.cbo文件名.Location = New System.Drawing.Point(85, 49)
        Me.cbo文件名.Name = "cbo文件名"
        Me.cbo文件名.Size = New System.Drawing.Size(87, 20)
        Me.cbo文件名.TabIndex = 2
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
        Me.cbo图号.Items.AddRange(New Object() {"零件代号", "库存编号", "描述"})
        Me.cbo图号.Location = New System.Drawing.Point(85, 20)
        Me.cbo图号.Name = "cbo图号"
        Me.cbo图号.Size = New System.Drawing.Size(87, 20)
        Me.cbo图号.TabIndex = 1
        '
        'TabPage文件
        '
        Me.TabPage文件.Controls.Add(Me.GroupBox图框模板)
        Me.TabPage文件.Controls.Add(Me.GroupBoxERP查询)
        Me.TabPage文件.Controls.Add(Me.GroupBoxBOM导出项目)
        Me.TabPage文件.Location = New System.Drawing.Point(4, 22)
        Me.TabPage文件.Name = "TabPage文件"
        Me.TabPage文件.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage文件.Size = New System.Drawing.Size(616, 290)
        Me.TabPage文件.TabIndex = 1
        Me.TabPage文件.Text = "文件"
        Me.TabPage文件.UseVisualStyleBackColor = True
        '
        'GroupBox图框模板
        '
        Me.GroupBox图框模板.Controls.Add(Me.btn选择工程图模板)
        Me.GroupBox图框模板.Controls.Add(Me.txt图框模板文件)
        Me.GroupBox图框模板.Controls.Add(Me.lbl模板工程图)
        Me.GroupBox图框模板.Location = New System.Drawing.Point(6, 200)
        Me.GroupBox图框模板.Name = "GroupBox图框模板"
        Me.GroupBox图框模板.Size = New System.Drawing.Size(594, 58)
        Me.GroupBox图框模板.TabIndex = 23
        Me.GroupBox图框模板.TabStop = False
        Me.GroupBox图框模板.Text = "图框模板"
        '
        'btn选择工程图模板
        '
        Me.btn选择工程图模板.Location = New System.Drawing.Point(518, 17)
        Me.btn选择工程图模板.Name = "btn选择工程图模板"
        Me.btn选择工程图模板.Size = New System.Drawing.Size(52, 25)
        Me.btn选择工程图模板.TabIndex = 17
        Me.btn选择工程图模板.Text = "选择"
        Me.btn选择工程图模板.UseVisualStyleBackColor = True
        '
        'txt图框模板文件
        '
        Me.txt图框模板文件.Location = New System.Drawing.Point(102, 19)
        Me.txt图框模板文件.Name = "txt图框模板文件"
        Me.txt图框模板文件.Size = New System.Drawing.Size(408, 21)
        Me.txt图框模板文件.TabIndex = 8
        '
        'lbl模板工程图
        '
        Me.lbl模板工程图.AutoSize = True
        Me.lbl模板工程图.Location = New System.Drawing.Point(7, 23)
        Me.lbl模板工程图.Name = "lbl模板工程图"
        Me.lbl模板工程图.Size = New System.Drawing.Size(77, 12)
        Me.lbl模板工程图.TabIndex = 7
        Me.lbl模板工程图.Text = "模板工程图："
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
        Me.btn选择erp数据库.Size = New System.Drawing.Size(52, 25)
        Me.btn选择erp数据库.TabIndex = 19
        Me.btn选择erp数据库.Text = "选择"
        Me.btn选择erp数据库.UseVisualStyleBackColor = True
        '
        'btn更新数据库
        '
        Me.btn更新数据库.Location = New System.Drawing.Point(423, 51)
        Me.btn更新数据库.Name = "btn更新数据库"
        Me.btn更新数据库.Size = New System.Drawing.Size(82, 25)
        Me.btn更新数据库.TabIndex = 18
        Me.btn更新数据库.Text = "更新数据库"
        Me.btn更新数据库.UseVisualStyleBackColor = True
        '
        'btn打开erp数据库
        '
        Me.btn打开erp数据库.Location = New System.Drawing.Point(518, 51)
        Me.btn打开erp数据库.Name = "btn打开erp数据库"
        Me.btn打开erp数据库.Size = New System.Drawing.Size(52, 25)
        Me.btn打开erp数据库.TabIndex = 17
        Me.btn打开erp数据库.Text = "打开"
        Me.btn打开erp数据库.UseVisualStyleBackColor = True
        '
        'txt查询列
        '
        Me.txt查询列.Location = New System.Drawing.Point(306, 54)
        Me.txt查询列.Name = "txt查询列"
        Me.txt查询列.Size = New System.Drawing.Size(89, 21)
        Me.txt查询列.TabIndex = 15
        '
        'lblERP列
        '
        Me.lblERP列.AutoSize = True
        Me.lblERP列.Location = New System.Drawing.Point(251, 58)
        Me.lblERP列.Name = "lblERP列"
        Me.lblERP列.Size = New System.Drawing.Size(47, 12)
        Me.lblERP列.TabIndex = 14
        Me.lblERP列.Text = "ERP列："
        '
        'txt查找范围
        '
        Me.txt查找范围.Location = New System.Drawing.Point(139, 54)
        Me.txt查找范围.Name = "txt查找范围"
        Me.txt查找范围.Size = New System.Drawing.Size(89, 21)
        Me.txt查找范围.TabIndex = 13
        '
        'lbl查询列
        '
        Me.lbl查询列.AutoSize = True
        Me.lbl查询列.Location = New System.Drawing.Point(72, 58)
        Me.lbl查询列.Name = "lbl查询列"
        Me.lbl查询列.Size = New System.Drawing.Size(53, 12)
        Me.lbl查询列.TabIndex = 12
        Me.lbl查询列.Text = "查询列："
        '
        'txt基础数据文件
        '
        Me.txt基础数据文件.Location = New System.Drawing.Point(102, 19)
        Me.txt基础数据文件.Name = "txt基础数据文件"
        Me.txt基础数据文件.Size = New System.Drawing.Size(408, 21)
        Me.txt基础数据文件.TabIndex = 8
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
        Me.btn清除.TabIndex = 10
        Me.btn清除.Text = "清除"
        Me.btn清除.UseVisualStyleBackColor = True
        '
        'btn还原
        '
        Me.btn还原.Location = New System.Drawing.Point(14, 47)
        Me.btn还原.Name = "btn还原"
        Me.btn还原.Size = New System.Drawing.Size(53, 25)
        Me.btn还原.TabIndex = 9
        Me.btn还原.Text = "还原"
        Me.btn还原.UseVisualStyleBackColor = True
        '
        'btn添加
        '
        Me.btn添加.Location = New System.Drawing.Point(525, 47)
        Me.btn添加.Name = "btn添加"
        Me.btn添加.Size = New System.Drawing.Size(53, 25)
        Me.btn添加.TabIndex = 8
        Me.btn添加.Text = "添加"
        Me.btn添加.UseVisualStyleBackColor = True
        '
        'cbo添加
        '
        Me.cbo添加.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo添加.FormattingEnabled = True
        Me.cbo添加.Items.AddRange(New Object() {"| (分隔符)", "材料", "成本中心", "供应商", "空格", "库存编号", "零件代号", "面积", "描述", "数量", "所属装配", "所属装配代号", "文件路径", "文件名", "质量", "总数量", "总质量"})
        Me.cbo添加.Location = New System.Drawing.Point(335, 50)
        Me.cbo添加.Name = "cbo添加"
        Me.cbo添加.Size = New System.Drawing.Size(170, 20)
        Me.cbo添加.TabIndex = 7
        '
        'txtBOM导出项
        '
        Me.txtBOM导出项.Location = New System.Drawing.Point(86, 19)
        Me.txtBOM导出项.Name = "txtBOM导出项"
        Me.txtBOM导出项.Size = New System.Drawing.Size(496, 21)
        Me.txtBOM导出项.TabIndex = 6
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
        Me.TabControl.ResumeLayout(False)
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
        Me.TabPage文件.ResumeLayout(False)
        Me.GroupBox图框模板.ResumeLayout(False)
        Me.GroupBox图框模板.PerformLayout()
        Me.GroupBoxERP查询.ResumeLayout(False)
        Me.GroupBoxERP查询.PerformLayout()
        Me.GroupBoxBOM导出项目.ResumeLayout(False)
        Me.GroupBoxBOM导出项目.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn确定 As System.Windows.Forms.Button
    Friend WithEvents btn取消 As System.Windows.Forms.Button
    Friend WithEvents chk检查更新 As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage常规 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox快速打印 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo另存为 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb打印机 As System.Windows.Forms.ComboBox
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
    Friend WithEvents TabPage文件 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox图框模板 As System.Windows.Forms.GroupBox
    Friend WithEvents btn选择工程图模板 As System.Windows.Forms.Button
    Friend WithEvents txt图框模板文件 As System.Windows.Forms.TextBox
    Friend WithEvents lbl模板工程图 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxERP查询 As System.Windows.Forms.GroupBox
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
    Friend WithEvents btn图框配置 As System.Windows.Forms.Button
    Friend WithEvents btn配置文件 As System.Windows.Forms.Button
    Friend WithEvents btn选择erp数据库 As System.Windows.Forms.Button

End Class
