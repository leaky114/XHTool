<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMassiPoperties
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btn确定 = New System.Windows.Forms.Button()
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.btn添加文件 = New System.Windows.Forms.Button()
        Me.btn清除列表 = New System.Windows.Forms.Button()
        Me.tp自定义 = New System.Windows.Forms.TabPage()
        Me.dtp日期 = New System.Windows.Forms.DateTimePicker()
        Me.lbl特性名 = New System.Windows.Forms.Label()
        Me.txt实数 = New System.Windows.Forms.TextBox()
        Me.txt特性名 = New System.Windows.Forms.TextBox()
        Me.txt字符串 = New System.Windows.Forms.TextBox()
        Me.rdo字符串 = New System.Windows.Forms.RadioButton()
        Me.rdo布尔值 = New System.Windows.Forms.RadioButton()
        Me.rdo日期 = New System.Windows.Forms.RadioButton()
        Me.rdo实数 = New System.Windows.Forms.RadioButton()
        Me.Bool布尔值 = New System.Windows.Forms.CheckBox()
        Me.tp项目 = New System.Windows.Forms.TabPage()
        Me.txt数据 = New System.Windows.Forms.TextBox()
        Me.lbl数据 = New System.Windows.Forms.Label()
        Me.lbl项目名 = New System.Windows.Forms.Label()
        Me.cbo项目名 = New System.Windows.Forms.ComboBox()
        Me.tab1 = New System.Windows.Forms.TabControl()
        Me.lvw文件列表 = New System.Windows.Forms.ListView()
        Me.ColumnHeader文件名 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cms右键菜单 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmi移出 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi筛选移出 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi筛选保留 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn导入已打开文件 = New System.Windows.Forms.Button()
        Me.btn添加文件夹 = New System.Windows.Forms.Button()
        Me.tp自定义.SuspendLayout()
        Me.tp项目.SuspendLayout()
        Me.tab1.SuspendLayout()
        Me.cms右键菜单.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn确定
        '
        Me.btn确定.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn确定.Location = New System.Drawing.Point(327, 460)
        Me.btn确定.Name = "btn确定"
        Me.btn确定.Size = New System.Drawing.Size(70, 28)
        Me.btn确定.TabIndex = 2
        Me.btn确定.Text = "确定"
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(405, 460)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(70, 28)
        Me.btn关闭.TabIndex = 3
        Me.btn关闭.Text = "关闭"
        '
        'btn添加文件
        '
        Me.btn添加文件.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn添加文件.Location = New System.Drawing.Point(266, 318)
        Me.btn添加文件.Name = "btn添加文件"
        Me.btn添加文件.Size = New System.Drawing.Size(91, 28)
        Me.btn添加文件.TabIndex = 0
        Me.btn添加文件.Text = "添加文件"
        Me.btn添加文件.UseVisualStyleBackColor = True
        '
        'btn清除列表
        '
        Me.btn清除列表.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn清除列表.Location = New System.Drawing.Point(389, 358)
        Me.btn清除列表.Name = "btn清除列表"
        Me.btn清除列表.Size = New System.Drawing.Size(70, 28)
        Me.btn清除列表.TabIndex = 1
        Me.btn清除列表.Text = "清除列表"
        Me.btn清除列表.UseVisualStyleBackColor = True
        '
        'tp自定义
        '
        Me.tp自定义.Controls.Add(Me.dtp日期)
        Me.tp自定义.Controls.Add(Me.lbl特性名)
        Me.tp自定义.Controls.Add(Me.txt实数)
        Me.tp自定义.Controls.Add(Me.txt特性名)
        Me.tp自定义.Controls.Add(Me.txt字符串)
        Me.tp自定义.Controls.Add(Me.rdo字符串)
        Me.tp自定义.Controls.Add(Me.rdo布尔值)
        Me.tp自定义.Controls.Add(Me.rdo日期)
        Me.tp自定义.Controls.Add(Me.rdo实数)
        Me.tp自定义.Controls.Add(Me.Bool布尔值)
        Me.tp自定义.Location = New System.Drawing.Point(4, 22)
        Me.tp自定义.Name = "tp自定义"
        Me.tp自定义.Padding = New System.Windows.Forms.Padding(3)
        Me.tp自定义.Size = New System.Drawing.Size(240, 146)
        Me.tp自定义.TabIndex = 1
        Me.tp自定义.Text = "自定义"
        Me.tp自定义.UseVisualStyleBackColor = True
        '
        'dtp日期
        '
        Me.dtp日期.Location = New System.Drawing.Point(81, 113)
        Me.dtp日期.Name = "dtp日期"
        Me.dtp日期.Size = New System.Drawing.Size(127, 21)
        Me.dtp日期.TabIndex = 11
        '
        'lbl特性名
        '
        Me.lbl特性名.AutoSize = True
        Me.lbl特性名.Location = New System.Drawing.Point(17, 15)
        Me.lbl特性名.Name = "lbl特性名"
        Me.lbl特性名.Size = New System.Drawing.Size(41, 12)
        Me.lbl特性名.TabIndex = 13
        Me.lbl特性名.Text = "特性名"
        '
        'txt实数
        '
        Me.txt实数.Location = New System.Drawing.Point(81, 87)
        Me.txt实数.Name = "txt实数"
        Me.txt实数.Size = New System.Drawing.Size(127, 21)
        Me.txt实数.TabIndex = 4
        '
        'txt特性名
        '
        Me.txt特性名.Location = New System.Drawing.Point(81, 11)
        Me.txt特性名.Name = "txt特性名"
        Me.txt特性名.Size = New System.Drawing.Size(127, 21)
        Me.txt特性名.TabIndex = 12
        '
        'txt字符串
        '
        Me.txt字符串.Location = New System.Drawing.Point(81, 35)
        Me.txt字符串.Name = "txt字符串"
        Me.txt字符串.Size = New System.Drawing.Size(127, 21)
        Me.txt字符串.TabIndex = 2
        '
        'rdo字符串
        '
        Me.rdo字符串.AutoSize = True
        Me.rdo字符串.Location = New System.Drawing.Point(15, 37)
        Me.rdo字符串.Name = "rdo字符串"
        Me.rdo字符串.Size = New System.Drawing.Size(47, 16)
        Me.rdo字符串.TabIndex = 6
        Me.rdo字符串.TabStop = True
        Me.rdo字符串.Text = "字串"
        Me.rdo字符串.UseVisualStyleBackColor = True
        '
        'rdo布尔值
        '
        Me.rdo布尔值.AutoSize = True
        Me.rdo布尔值.Location = New System.Drawing.Point(15, 63)
        Me.rdo布尔值.Name = "rdo布尔值"
        Me.rdo布尔值.Size = New System.Drawing.Size(59, 16)
        Me.rdo布尔值.TabIndex = 7
        Me.rdo布尔值.TabStop = True
        Me.rdo布尔值.Text = "布尔值"
        Me.rdo布尔值.UseVisualStyleBackColor = True
        '
        'rdo日期
        '
        Me.rdo日期.AutoSize = True
        Me.rdo日期.Location = New System.Drawing.Point(15, 115)
        Me.rdo日期.Name = "rdo日期"
        Me.rdo日期.Size = New System.Drawing.Size(47, 16)
        Me.rdo日期.TabIndex = 9
        Me.rdo日期.TabStop = True
        Me.rdo日期.Text = "日期"
        Me.rdo日期.UseVisualStyleBackColor = True
        '
        'rdo实数
        '
        Me.rdo实数.AutoSize = True
        Me.rdo实数.Location = New System.Drawing.Point(15, 89)
        Me.rdo实数.Name = "rdo实数"
        Me.rdo实数.Size = New System.Drawing.Size(47, 16)
        Me.rdo实数.TabIndex = 8
        Me.rdo实数.TabStop = True
        Me.rdo实数.Text = "实数"
        Me.rdo实数.UseVisualStyleBackColor = True
        '
        'Bool布尔值
        '
        Me.Bool布尔值.AutoSize = True
        Me.Bool布尔值.Location = New System.Drawing.Point(83, 63)
        Me.Bool布尔值.Name = "Bool布尔值"
        Me.Bool布尔值.Size = New System.Drawing.Size(102, 16)
        Me.Bool布尔值.TabIndex = 3
        Me.Bool布尔值.Text = "True 或 False"
        Me.Bool布尔值.UseVisualStyleBackColor = True
        '
        'tp项目
        '
        Me.tp项目.Controls.Add(Me.txt数据)
        Me.tp项目.Controls.Add(Me.lbl数据)
        Me.tp项目.Controls.Add(Me.lbl项目名)
        Me.tp项目.Controls.Add(Me.cbo项目名)
        Me.tp项目.Location = New System.Drawing.Point(4, 22)
        Me.tp项目.Name = "tp项目"
        Me.tp项目.Padding = New System.Windows.Forms.Padding(3)
        Me.tp项目.Size = New System.Drawing.Size(240, 146)
        Me.tp项目.TabIndex = 0
        Me.tp项目.Text = "项目"
        Me.tp项目.UseVisualStyleBackColor = True
        '
        'txt数据
        '
        Me.txt数据.Location = New System.Drawing.Point(70, 39)
        Me.txt数据.Name = "txt数据"
        Me.txt数据.Size = New System.Drawing.Size(143, 21)
        Me.txt数据.TabIndex = 1
        '
        'lbl数据
        '
        Me.lbl数据.AutoSize = True
        Me.lbl数据.Location = New System.Drawing.Point(12, 43)
        Me.lbl数据.Name = "lbl数据"
        Me.lbl数据.Size = New System.Drawing.Size(53, 12)
        Me.lbl数据.TabIndex = 20
        Me.lbl数据.Text = "数  据："
        '
        'lbl项目名
        '
        Me.lbl项目名.AutoSize = True
        Me.lbl项目名.Location = New System.Drawing.Point(12, 14)
        Me.lbl项目名.Name = "lbl项目名"
        Me.lbl项目名.Size = New System.Drawing.Size(53, 12)
        Me.lbl项目名.TabIndex = 19
        Me.lbl项目名.Text = "项目名："
        '
        'cbo项目名
        '
        Me.cbo项目名.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo项目名.FormattingEnabled = True
        Me.cbo项目名.Items.AddRange(New Object() {"零件代号", "库存编号", "描述", "修订号", "项目", "设计人", "工程师", "批准人", "成本中心", "预估成本", "供应商", "Web链接"})
        Me.cbo项目名.Location = New System.Drawing.Point(70, 10)
        Me.cbo项目名.Name = "cbo项目名"
        Me.cbo项目名.Size = New System.Drawing.Size(145, 20)
        Me.cbo项目名.TabIndex = 0
        '
        'tab1
        '
        Me.tab1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tab1.Controls.Add(Me.tp项目)
        Me.tab1.Controls.Add(Me.tp自定义)
        Me.tab1.Location = New System.Drawing.Point(12, 316)
        Me.tab1.Name = "tab1"
        Me.tab1.SelectedIndex = 0
        Me.tab1.Size = New System.Drawing.Size(248, 172)
        Me.tab1.TabIndex = 4
        '
        'lvw文件列表
        '
        Me.lvw文件列表.AllowColumnReorder = True
        Me.lvw文件列表.AllowDrop = True
        Me.lvw文件列表.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvw文件列表.AutoArrange = False
        Me.lvw文件列表.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader文件名})
        Me.lvw文件列表.ContextMenuStrip = Me.cms右键菜单
        Me.lvw文件列表.FullRowSelect = True
        Me.lvw文件列表.Location = New System.Drawing.Point(12, 12)
        Me.lvw文件列表.Name = "lvw文件列表"
        Me.lvw文件列表.Size = New System.Drawing.Size(461, 286)
        Me.lvw文件列表.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvw文件列表.TabIndex = 37
        Me.lvw文件列表.UseCompatibleStateImageBehavior = False
        Me.lvw文件列表.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader文件名
        '
        Me.ColumnHeader文件名.Text = "文件名(双击打开)"
        Me.ColumnHeader文件名.Width = 441
        '
        'cms右键菜单
        '
        Me.cms右键菜单.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi移出, Me.tsmi筛选移出, Me.tsmi筛选保留})
        Me.cms右键菜单.Name = "cmsRemove"
        Me.cms右键菜单.Size = New System.Drawing.Size(125, 70)
        '
        'tsmi移出
        '
        Me.tsmi移出.Name = "tsmi移出"
        Me.tsmi移出.Size = New System.Drawing.Size(124, 22)
        Me.tsmi移出.Text = "移出"
        '
        'tsmi筛选移出
        '
        Me.tsmi筛选移出.Name = "tsmi筛选移出"
        Me.tsmi筛选移出.Size = New System.Drawing.Size(124, 22)
        Me.tsmi筛选移出.Text = "筛选移出"
        '
        'tsmi筛选保留
        '
        Me.tsmi筛选保留.Name = "tsmi筛选保留"
        Me.tsmi筛选保留.Size = New System.Drawing.Size(124, 22)
        Me.tsmi筛选保留.Text = "筛选保留"
        '
        'btn导入已打开文件
        '
        Me.btn导入已打开文件.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn导入已打开文件.Location = New System.Drawing.Point(266, 358)
        Me.btn导入已打开文件.Name = "btn导入已打开文件"
        Me.btn导入已打开文件.Size = New System.Drawing.Size(103, 28)
        Me.btn导入已打开文件.TabIndex = 41
        Me.btn导入已打开文件.Text = "导入已打开文件"
        Me.btn导入已打开文件.UseVisualStyleBackColor = True
        '
        'btn添加文件夹
        '
        Me.btn添加文件夹.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn添加文件夹.Location = New System.Drawing.Point(368, 318)
        Me.btn添加文件夹.Name = "btn添加文件夹"
        Me.btn添加文件夹.Size = New System.Drawing.Size(91, 28)
        Me.btn添加文件夹.TabIndex = 39
        Me.btn添加文件夹.Text = "添加文件夹"
        Me.btn添加文件夹.UseVisualStyleBackColor = True
        '
        'frmMassiPoperties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn关闭
        Me.ClientSize = New System.Drawing.Size(485, 500)
        Me.Controls.Add(Me.btn导入已打开文件)
        Me.Controls.Add(Me.btn添加文件夹)
        Me.Controls.Add(Me.lvw文件列表)
        Me.Controls.Add(Me.btn关闭)
        Me.Controls.Add(Me.btn确定)
        Me.Controls.Add(Me.btn清除列表)
        Me.Controls.Add(Me.tab1)
        Me.Controls.Add(Me.btn添加文件)
        Me.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Name = "frmMassiPoperties"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "量产iProperty"
        Me.tp自定义.ResumeLayout(False)
        Me.tp自定义.PerformLayout()
        Me.tp项目.ResumeLayout(False)
        Me.tp项目.PerformLayout()
        Me.tab1.ResumeLayout(False)
        Me.cms右键菜单.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn确定 As System.Windows.Forms.Button
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents btn添加文件 As System.Windows.Forms.Button
    Friend WithEvents btn清除列表 As System.Windows.Forms.Button
    Friend WithEvents tp自定义 As System.Windows.Forms.TabPage
    Friend WithEvents dtp日期 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl特性名 As System.Windows.Forms.Label
    Friend WithEvents txt实数 As System.Windows.Forms.TextBox
    Friend WithEvents txt特性名 As System.Windows.Forms.TextBox
    Friend WithEvents txt字符串 As System.Windows.Forms.TextBox
    Friend WithEvents rdo字符串 As System.Windows.Forms.RadioButton
    Friend WithEvents rdo布尔值 As System.Windows.Forms.RadioButton
    Friend WithEvents rdo日期 As System.Windows.Forms.RadioButton
    Friend WithEvents rdo实数 As System.Windows.Forms.RadioButton
    Friend WithEvents Bool布尔值 As System.Windows.Forms.CheckBox
    Friend WithEvents tp项目 As System.Windows.Forms.TabPage
    Friend WithEvents txt数据 As System.Windows.Forms.TextBox
    Friend WithEvents lbl数据 As System.Windows.Forms.Label
    Friend WithEvents lbl项目名 As System.Windows.Forms.Label
    Friend WithEvents cbo项目名 As System.Windows.Forms.ComboBox
    Friend WithEvents tab1 As System.Windows.Forms.TabControl
    Friend WithEvents lvw文件列表 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader文件名 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn导入已打开文件 As System.Windows.Forms.Button
    Friend WithEvents btn添加文件夹 As System.Windows.Forms.Button
    Friend WithEvents cms右键菜单 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmi移出 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi筛选移出 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi筛选保留 As System.Windows.Forms.ToolStripMenuItem

End Class
