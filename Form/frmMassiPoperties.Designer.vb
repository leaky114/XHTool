<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMassiPoperties
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn开始 = New System.Windows.Forms.Button()
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.lst文件列表 = New System.Windows.Forms.ListBox()
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
        Me.cmb项目名 = New System.Windows.Forms.ComboBox()
        Me.tab1 = New System.Windows.Forms.TabControl()
        Me.tp自定义.SuspendLayout()
        Me.tp项目.SuspendLayout()
        Me.tab1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn开始
        '
        Me.btn开始.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn开始.Location = New System.Drawing.Point(159, 189)
        Me.btn开始.Name = "btn开始"
        Me.btn开始.Size = New System.Drawing.Size(70, 28)
        Me.btn开始.TabIndex = 1
        Me.btn开始.Text = "开始"
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(237, 189)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(70, 28)
        Me.btn关闭.TabIndex = 1
        Me.btn关闭.Text = "关闭"
        '
        'lst文件列表
        '
        Me.lst文件列表.FormattingEnabled = True
        Me.lst文件列表.ItemHeight = 12
        Me.lst文件列表.Location = New System.Drawing.Point(12, 226)
        Me.lst文件列表.Name = "lst文件列表"
        Me.lst文件列表.Size = New System.Drawing.Size(271, 148)
        Me.lst文件列表.TabIndex = 15
        Me.lst文件列表.Visible = False
        '
        'btn添加文件
        '
        Me.btn添加文件.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn添加文件.Location = New System.Drawing.Point(3, 189)
        Me.btn添加文件.Name = "btn添加文件"
        Me.btn添加文件.Size = New System.Drawing.Size(70, 28)
        Me.btn添加文件.TabIndex = 0
        Me.btn添加文件.Text = "添加文件"
        Me.btn添加文件.UseVisualStyleBackColor = True
        Me.btn添加文件.Visible = False
        '
        'btn清除列表
        '
        Me.btn清除列表.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn清除列表.Location = New System.Drawing.Point(81, 189)
        Me.btn清除列表.Name = "btn清除列表"
        Me.btn清除列表.Size = New System.Drawing.Size(70, 28)
        Me.btn清除列表.TabIndex = 20
        Me.btn清除列表.Text = "清除列表"
        Me.btn清除列表.UseVisualStyleBackColor = True
        Me.btn清除列表.Visible = False
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
        Me.tp自定义.Size = New System.Drawing.Size(286, 146)
        Me.tp自定义.TabIndex = 1
        Me.tp自定义.Text = "自定义"
        Me.tp自定义.UseVisualStyleBackColor = True
        '
        'dtp日期
        '
        Me.dtp日期.Location = New System.Drawing.Point(81, 115)
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
        Me.txt特性名.Location = New System.Drawing.Point(81, 9)
        Me.txt特性名.Name = "txt特性名"
        Me.txt特性名.Size = New System.Drawing.Size(127, 21)
        Me.txt特性名.TabIndex = 12
        '
        'txt字符串
        '
        Me.txt字符串.Location = New System.Drawing.Point(81, 36)
        Me.txt字符串.Name = "txt字符串"
        Me.txt字符串.Size = New System.Drawing.Size(127, 21)
        Me.txt字符串.TabIndex = 2
        '
        'rdo字符串
        '
        Me.rdo字符串.AutoSize = True
        Me.rdo字符串.Location = New System.Drawing.Point(15, 43)
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
        Me.rdo布尔值.Location = New System.Drawing.Point(15, 67)
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
        Me.rdo实数.Location = New System.Drawing.Point(15, 91)
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
        Me.Bool布尔值.Location = New System.Drawing.Point(83, 64)
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
        Me.tp项目.Controls.Add(Me.cmb项目名)
        Me.tp项目.Location = New System.Drawing.Point(4, 22)
        Me.tp项目.Name = "tp项目"
        Me.tp项目.Padding = New System.Windows.Forms.Padding(3)
        Me.tp项目.Size = New System.Drawing.Size(286, 146)
        Me.tp项目.TabIndex = 0
        Me.tp项目.Text = "项目"
        Me.tp项目.UseVisualStyleBackColor = True
        '
        'txt数据
        '
        Me.txt数据.Location = New System.Drawing.Point(70, 39)
        Me.txt数据.Name = "txt数据"
        Me.txt数据.Size = New System.Drawing.Size(143, 21)
        Me.txt数据.TabIndex = 21
        '
        'lbl数据
        '
        Me.lbl数据.AutoSize = True
        Me.lbl数据.Location = New System.Drawing.Point(12, 41)
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
        'cmb项目名
        '
        Me.cmb项目名.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb项目名.FormattingEnabled = True
        Me.cmb项目名.Items.AddRange(New Object() {"零件代号", "库存编号", "描述", "修订号", "项目", "设计人", "工程师", "批准人", "成本中心", "预估成本", "供应商", "Web链接"})
        Me.cmb项目名.Location = New System.Drawing.Point(70, 10)
        Me.cmb项目名.Name = "cmb项目名"
        Me.cmb项目名.Size = New System.Drawing.Size(145, 20)
        Me.cmb项目名.TabIndex = 18
        '
        'tab1
        '
        Me.tab1.Controls.Add(Me.tp项目)
        Me.tab1.Controls.Add(Me.tp自定义)
        Me.tab1.Location = New System.Drawing.Point(12, 12)
        Me.tab1.Name = "tab1"
        Me.tab1.SelectedIndex = 0
        Me.tab1.Size = New System.Drawing.Size(294, 172)
        Me.tab1.TabIndex = 19
        '
        'frmMassiPoperties
        '
        Me.AcceptButton = Me.btn开始
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn关闭
        Me.ClientSize = New System.Drawing.Size(317, 229)
        Me.Controls.Add(Me.btn关闭)
        Me.Controls.Add(Me.btn开始)
        Me.Controls.Add(Me.btn清除列表)
        Me.Controls.Add(Me.tab1)
        Me.Controls.Add(Me.btn添加文件)
        Me.Controls.Add(Me.lst文件列表)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMassiPoperties"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "量产iProperty"
        Me.TopMost = True
        Me.tp自定义.ResumeLayout(False)
        Me.tp自定义.PerformLayout()
        Me.tp项目.ResumeLayout(False)
        Me.tp项目.PerformLayout()
        Me.tab1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn开始 As System.Windows.Forms.Button
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents lst文件列表 As System.Windows.Forms.ListBox
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
    Friend WithEvents cmb项目名 As System.Windows.Forms.ComboBox
    Friend WithEvents tab1 As System.Windows.Forms.TabControl

End Class
