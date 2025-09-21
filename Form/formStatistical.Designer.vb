Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormStatistical
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

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cms右键菜单 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmi移出 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi清空 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.btn清空 = New System.Windows.Forms.Button()
        Me.btn移出 = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btn复制长度 = New System.Windows.Forms.Button()
        Me.txt长度 = New System.Windows.Forms.TextBox()
        Me.lbl长度 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton10 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.btn选择面和边 = New System.Windows.Forms.Button()
        Me.btn复制焊缝长度 = New System.Windows.Forms.Button()
        Me.txt焊缝长度 = New System.Windows.Forms.TextBox()
        Me.lbl焊缝长度 = New System.Windows.Forms.Label()
        Me.lvw焊缝文件列表 = New System.Windows.Forms.ListView()
        Me.ch边位置 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch长度 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch系数 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch焊缝长度 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btn添加零部件 = New System.Windows.Forms.Button()
        Me.btn复制质量 = New System.Windows.Forms.Button()
        Me.txt总质量 = New System.Windows.Forms.TextBox()
        Me.btn选择零件 = New System.Windows.Forms.Button()
        Me.lbl总质量 = New System.Windows.Forms.Label()
        Me.lvw质量文件列表 = New System.Windows.Forms.ListView()
        Me.ch质量文件名 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch质量 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btn选择面 = New System.Windows.Forms.Button()
        Me.btn复制面积 = New System.Windows.Forms.Button()
        Me.txt面积 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lvw面积文件列表 = New System.Windows.Forms.ListView()
        Me.ch面积文件名 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch面积 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btn选择零部件2 = New System.Windows.Forms.Button()
        Me.cms右键菜单.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'cms右键菜单
        '
        Me.cms右键菜单.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi移出, Me.tsmi清空})
        Me.cms右键菜单.Name = "cmsRemove"
        Me.cms右键菜单.Size = New System.Drawing.Size(101, 48)
        '
        'tsmi移出
        '
        Me.tsmi移出.Name = "tsmi移出"
        Me.tsmi移出.Size = New System.Drawing.Size(100, 22)
        Me.tsmi移出.Text = "移出"
        '
        'tsmi清空
        '
        Me.tsmi清空.Name = "tsmi清空"
        Me.tsmi清空.Size = New System.Drawing.Size(100, 22)
        Me.tsmi清空.Text = "清空"
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.AutoSize = True
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(408, 410)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(65, 28)
        Me.btn关闭.TabIndex = 6
        Me.btn关闭.Text = "关闭"
        '
        'btn清空
        '
        Me.btn清空.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn清空.Location = New System.Drawing.Point(325, 410)
        Me.btn清空.Name = "btn清空"
        Me.btn清空.Size = New System.Drawing.Size(65, 28)
        Me.btn清空.TabIndex = 48
        Me.btn清空.Text = "清空"
        Me.btn清空.UseVisualStyleBackColor = True
        '
        'btn移出
        '
        Me.btn移出.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn移出.Location = New System.Drawing.Point(252, 410)
        Me.btn移出.Name = "btn移出"
        Me.btn移出.Size = New System.Drawing.Size(65, 28)
        Me.btn移出.TabIndex = 47
        Me.btn移出.Text = "移出"
        Me.btn移出.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btn复制长度)
        Me.TabPage2.Controls.Add(Me.txt长度)
        Me.TabPage2.Controls.Add(Me.lbl长度)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.btn选择面和边)
        Me.TabPage2.Controls.Add(Me.btn复制焊缝长度)
        Me.TabPage2.Controls.Add(Me.txt焊缝长度)
        Me.TabPage2.Controls.Add(Me.lbl焊缝长度)
        Me.TabPage2.Controls.Add(Me.lvw焊缝文件列表)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(463, 370)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "边长(焊缝)"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btn复制长度
        '
        Me.btn复制长度.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn复制长度.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn复制长度.Location = New System.Drawing.Point(426, 304)
        Me.btn复制长度.Name = "btn复制长度"
        Me.btn复制长度.Size = New System.Drawing.Size(25, 25)
        Me.btn复制长度.TabIndex = 58
        Me.btn复制长度.UseVisualStyleBackColor = True
        '
        'txt长度
        '
        Me.txt长度.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt长度.Location = New System.Drawing.Point(336, 306)
        Me.txt长度.Name = "txt长度"
        Me.txt长度.ReadOnly = True
        Me.txt长度.Size = New System.Drawing.Size(81, 21)
        Me.txt长度.TabIndex = 56
        Me.txt长度.TabStop = False
        '
        'lbl长度
        '
        Me.lbl长度.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl长度.AutoSize = True
        Me.lbl长度.Location = New System.Drawing.Point(265, 310)
        Me.lbl长度.Name = "lbl长度"
        Me.lbl长度.Size = New System.Drawing.Size(41, 12)
        Me.lbl长度.TabIndex = 57
        Me.lbl长度.Text = "长度："
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.RadioButton10)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.RadioButton5)
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Location = New System.Drawing.Point(44, 315)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(183, 45)
        Me.GroupBox1.TabIndex = 55
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "焊缝系数"
        '
        'RadioButton10
        '
        Me.RadioButton10.AutoSize = True
        Me.RadioButton10.Checked = True
        Me.RadioButton10.Location = New System.Drawing.Point(152, 21)
        Me.RadioButton10.Name = "RadioButton10"
        Me.RadioButton10.Size = New System.Drawing.Size(29, 16)
        Me.RadioButton10.TabIndex = 3
        Me.RadioButton10.TabStop = True
        Me.RadioButton10.Text = "1"
        Me.RadioButton10.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(103, 21)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(41, 16)
        Me.RadioButton1.TabIndex = 2
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "0.7"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Location = New System.Drawing.Point(57, 21)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(41, 16)
        Me.RadioButton5.TabIndex = 1
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Text = "0.5"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(12, 21)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(41, 16)
        Me.RadioButton3.TabIndex = 0
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "0.3"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'btn选择面和边
        '
        Me.btn选择面和边.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn选择面和边.Location = New System.Drawing.Point(9, 325)
        Me.btn选择面和边.Name = "btn选择面和边"
        Me.btn选择面和边.Size = New System.Drawing.Size(25, 25)
        Me.btn选择面和边.TabIndex = 54
        Me.btn选择面和边.UseVisualStyleBackColor = True
        '
        'btn复制焊缝长度
        '
        Me.btn复制焊缝长度.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn复制焊缝长度.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn复制焊缝长度.Location = New System.Drawing.Point(426, 337)
        Me.btn复制焊缝长度.Name = "btn复制焊缝长度"
        Me.btn复制焊缝长度.Size = New System.Drawing.Size(25, 25)
        Me.btn复制焊缝长度.TabIndex = 53
        Me.btn复制焊缝长度.UseVisualStyleBackColor = True
        '
        'txt焊缝长度
        '
        Me.txt焊缝长度.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt焊缝长度.Location = New System.Drawing.Point(336, 339)
        Me.txt焊缝长度.Name = "txt焊缝长度"
        Me.txt焊缝长度.ReadOnly = True
        Me.txt焊缝长度.Size = New System.Drawing.Size(81, 21)
        Me.txt焊缝长度.TabIndex = 50
        Me.txt焊缝长度.TabStop = False
        '
        'lbl焊缝长度
        '
        Me.lbl焊缝长度.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl焊缝长度.AutoSize = True
        Me.lbl焊缝长度.Location = New System.Drawing.Point(265, 343)
        Me.lbl焊缝长度.Name = "lbl焊缝长度"
        Me.lbl焊缝长度.Size = New System.Drawing.Size(65, 12)
        Me.lbl焊缝长度.TabIndex = 52
        Me.lbl焊缝长度.Text = "焊缝长度："
        '
        'lvw焊缝文件列表
        '
        Me.lvw焊缝文件列表.AllowDrop = True
        Me.lvw焊缝文件列表.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvw焊缝文件列表.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ch边位置, Me.ch长度, Me.ch系数, Me.ch焊缝长度})
        Me.lvw焊缝文件列表.ContextMenuStrip = Me.cms右键菜单
        Me.lvw焊缝文件列表.FullRowSelect = True
        Me.lvw焊缝文件列表.HideSelection = False
        Me.lvw焊缝文件列表.Location = New System.Drawing.Point(6, 6)
        Me.lvw焊缝文件列表.Name = "lvw焊缝文件列表"
        Me.lvw焊缝文件列表.Size = New System.Drawing.Size(450, 290)
        Me.lvw焊缝文件列表.TabIndex = 51
        Me.lvw焊缝文件列表.TabStop = False
        Me.lvw焊缝文件列表.UseCompatibleStateImageBehavior = False
        Me.lvw焊缝文件列表.View = System.Windows.Forms.View.Details
        '
        'ch边位置
        '
        Me.ch边位置.Text = "边位置"
        Me.ch边位置.Width = 250
        '
        'ch长度
        '
        Me.ch长度.Text = "长度"
        Me.ch长度.Width = 80
        '
        'ch系数
        '
        Me.ch系数.Text = "系数"
        Me.ch系数.Width = 50
        '
        'ch焊缝长度
        '
        Me.ch焊缝长度.Text = "焊缝长度"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btn添加零部件)
        Me.TabPage1.Controls.Add(Me.btn复制质量)
        Me.TabPage1.Controls.Add(Me.txt总质量)
        Me.TabPage1.Controls.Add(Me.btn选择零件)
        Me.TabPage1.Controls.Add(Me.lbl总质量)
        Me.TabPage1.Controls.Add(Me.lvw质量文件列表)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(463, 370)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "质量"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btn添加零部件
        '
        Me.btn添加零部件.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn添加零部件.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn添加零部件.Location = New System.Drawing.Point(45, 330)
        Me.btn添加零部件.Name = "btn添加零部件"
        Me.btn添加零部件.Size = New System.Drawing.Size(26, 26)
        Me.btn添加零部件.TabIndex = 53
        Me.btn添加零部件.TabStop = False
        Me.btn添加零部件.UseVisualStyleBackColor = True
        '
        'btn复制质量
        '
        Me.btn复制质量.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn复制质量.Location = New System.Drawing.Point(431, 330)
        Me.btn复制质量.Name = "btn复制质量"
        Me.btn复制质量.Size = New System.Drawing.Size(25, 25)
        Me.btn复制质量.TabIndex = 51
        Me.btn复制质量.UseVisualStyleBackColor = True
        '
        'txt总质量
        '
        Me.txt总质量.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt总质量.Location = New System.Drawing.Point(346, 332)
        Me.txt总质量.Name = "txt总质量"
        Me.txt总质量.ReadOnly = True
        Me.txt总质量.Size = New System.Drawing.Size(77, 21)
        Me.txt总质量.TabIndex = 47
        Me.txt总质量.TabStop = False
        '
        'btn选择零件
        '
        Me.btn选择零件.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn选择零件.Location = New System.Drawing.Point(10, 330)
        Me.btn选择零件.Name = "btn选择零件"
        Me.btn选择零件.Size = New System.Drawing.Size(26, 26)
        Me.btn选择零件.TabIndex = 44
        Me.btn选择零件.TabStop = False
        Me.btn选择零件.UseVisualStyleBackColor = True
        '
        'lbl总质量
        '
        Me.lbl总质量.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl总质量.AutoSize = True
        Me.lbl总质量.Location = New System.Drawing.Point(299, 336)
        Me.lbl总质量.Name = "lbl总质量"
        Me.lbl总质量.Size = New System.Drawing.Size(53, 12)
        Me.lbl总质量.TabIndex = 50
        Me.lbl总质量.Text = "总质量："
        '
        'lvw质量文件列表
        '
        Me.lvw质量文件列表.AllowDrop = True
        Me.lvw质量文件列表.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvw质量文件列表.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ch质量文件名, Me.ch质量})
        Me.lvw质量文件列表.ContextMenuStrip = Me.cms右键菜单
        Me.lvw质量文件列表.FullRowSelect = True
        Me.lvw质量文件列表.HideSelection = False
        Me.lvw质量文件列表.Location = New System.Drawing.Point(6, 6)
        Me.lvw质量文件列表.Name = "lvw质量文件列表"
        Me.lvw质量文件列表.Size = New System.Drawing.Size(450, 310)
        Me.lvw质量文件列表.TabIndex = 49
        Me.lvw质量文件列表.TabStop = False
        Me.lvw质量文件列表.UseCompatibleStateImageBehavior = False
        Me.lvw质量文件列表.View = System.Windows.Forms.View.Details
        '
        'ch质量文件名
        '
        Me.ch质量文件名.Text = "文件名"
        Me.ch质量文件名.Width = 330
        '
        'ch质量
        '
        Me.ch质量.Text = "质量"
        Me.ch质量.Width = 100
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(471, 396)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btn选择零部件2)
        Me.TabPage3.Controls.Add(Me.btn选择面)
        Me.TabPage3.Controls.Add(Me.btn复制面积)
        Me.TabPage3.Controls.Add(Me.txt面积)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Controls.Add(Me.lvw面积文件列表)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(463, 370)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "面积"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btn选择面
        '
        Me.btn选择面.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn选择面.Location = New System.Drawing.Point(10, 330)
        Me.btn选择面.Name = "btn选择面"
        Me.btn选择面.Size = New System.Drawing.Size(26, 26)
        Me.btn选择面.TabIndex = 57
        Me.btn选择面.UseVisualStyleBackColor = True
        '
        'btn复制面积
        '
        Me.btn复制面积.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn复制面积.Location = New System.Drawing.Point(425, 330)
        Me.btn复制面积.Name = "btn复制面积"
        Me.btn复制面积.Size = New System.Drawing.Size(25, 25)
        Me.btn复制面积.TabIndex = 56
        Me.btn复制面积.UseVisualStyleBackColor = True
        '
        'txt面积
        '
        Me.txt面积.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt面积.Location = New System.Drawing.Point(342, 332)
        Me.txt面积.Name = "txt面积"
        Me.txt面积.ReadOnly = True
        Me.txt面积.Size = New System.Drawing.Size(77, 21)
        Me.txt面积.TabIndex = 55
        Me.txt面积.TabStop = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(275, 336)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = " 总面积："
        '
        'lvw面积文件列表
        '
        Me.lvw面积文件列表.AllowDrop = True
        Me.lvw面积文件列表.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvw面积文件列表.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ch面积文件名, Me.ch面积})
        Me.lvw面积文件列表.ContextMenuStrip = Me.cms右键菜单
        Me.lvw面积文件列表.FullRowSelect = True
        Me.lvw面积文件列表.HideSelection = False
        Me.lvw面积文件列表.Location = New System.Drawing.Point(6, 6)
        Me.lvw面积文件列表.Name = "lvw面积文件列表"
        Me.lvw面积文件列表.Size = New System.Drawing.Size(450, 310)
        Me.lvw面积文件列表.TabIndex = 50
        Me.lvw面积文件列表.TabStop = False
        Me.lvw面积文件列表.UseCompatibleStateImageBehavior = False
        Me.lvw面积文件列表.View = System.Windows.Forms.View.Details
        '
        'ch面积文件名
        '
        Me.ch面积文件名.Text = "文件名"
        Me.ch面积文件名.Width = 330
        '
        'ch面积
        '
        Me.ch面积.Text = "面积"
        Me.ch面积.Width = 100
        '
        'btn选择零部件2
        '
        Me.btn选择零部件2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn选择零部件2.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn选择零部件2.Location = New System.Drawing.Point(45, 330)
        Me.btn选择零部件2.Name = "btn选择零部件2"
        Me.btn选择零部件2.Size = New System.Drawing.Size(26, 26)
        Me.btn选择零部件2.TabIndex = 58
        Me.btn选择零部件2.TabStop = False
        Me.btn选择零部件2.UseVisualStyleBackColor = True
        '
        'FormStatistical
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(495, 443)
        Me.Controls.Add(Me.btn清空)
        Me.Controls.Add(Me.btn移出)
        Me.Controls.Add(Me.btn关闭)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FormStatistical"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "统计"
        Me.cms右键菜单.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents btn清空 As System.Windows.Forms.Button
    Friend WithEvents btn移出 As System.Windows.Forms.Button
    Friend WithEvents cms右键菜单 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmi移出 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi清空 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioButton10 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents btn选择面和边 As Button
    Friend WithEvents btn复制焊缝长度 As Button
    Friend WithEvents txt焊缝长度 As TextBox
    Friend WithEvents lbl焊缝长度 As Label
    Friend WithEvents lvw焊缝文件列表 As ListView
    Friend WithEvents ch边位置 As ColumnHeader
    Friend WithEvents ch长度 As ColumnHeader
    Friend WithEvents ch系数 As ColumnHeader
    Friend WithEvents ch焊缝长度 As ColumnHeader
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents btn添加零部件 As Button
    Friend WithEvents btn复制质量 As Button
    Friend WithEvents txt总质量 As TextBox
    Friend WithEvents btn选择零件 As Button
    Friend WithEvents lbl总质量 As Label
    Friend WithEvents lvw质量文件列表 As ListView
    Friend WithEvents ch质量文件名 As ColumnHeader
    Friend WithEvents ch质量 As ColumnHeader
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents btn复制面积 As Button
    Friend WithEvents txt面积 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lvw面积文件列表 As ListView
    Friend WithEvents ch面积文件名 As ColumnHeader
    Friend WithEvents ch面积 As ColumnHeader
    Friend WithEvents btn选择面 As Button
    Friend WithEvents btn复制长度 As Button
    Friend WithEvents txt长度 As TextBox
    Friend WithEvents lbl长度 As Label
    Friend WithEvents btn选择零部件2 As Button
End Class
