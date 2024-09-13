<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStatistical
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

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btn添加零部件 = New System.Windows.Forms.Button()
        Me.btn复制面积 = New System.Windows.Forms.Button()
        Me.btn复制质量 = New System.Windows.Forms.Button()
        Me.txt面积 = New System.Windows.Forms.TextBox()
        Me.txt质量 = New System.Windows.Forms.TextBox()
        Me.btn选择零件 = New System.Windows.Forms.Button()
        Me.lbl描述 = New System.Windows.Forms.Label()
        Me.lvw质量文件列表 = New System.Windows.Forms.ListView()
        Me.ch文件名 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch数量 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch质量 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch面积 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton10 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.btn选择面和边 = New System.Windows.Forms.Button()
        Me.btn复制焊缝长度 = New System.Windows.Forms.Button()
        Me.txt焊缝长度 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lvw焊缝文件列表 = New System.Windows.Forms.ListView()
        Me.ch边位置 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch长度 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch系数 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch焊缝长度 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.btn清空 = New System.Windows.Forms.Button()
        Me.btn移出 = New System.Windows.Forms.Button()
        Me.cms右键菜单 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmi移出 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi清空 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.cms右键菜单.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(471, 396)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btn添加零部件)
        Me.TabPage1.Controls.Add(Me.btn复制面积)
        Me.TabPage1.Controls.Add(Me.btn复制质量)
        Me.TabPage1.Controls.Add(Me.txt面积)
        Me.TabPage1.Controls.Add(Me.txt质量)
        Me.TabPage1.Controls.Add(Me.btn选择零件)
        Me.TabPage1.Controls.Add(Me.lbl描述)
        Me.TabPage1.Controls.Add(Me.lvw质量文件列表)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(463, 370)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "质量和面积"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btn添加零部件
        '
        Me.btn添加零部件.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn添加零部件.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn添加零部件.Location = New System.Drawing.Point(53, 329)
        Me.btn添加零部件.Name = "btn添加零部件"
        Me.btn添加零部件.Size = New System.Drawing.Size(26, 26)
        Me.btn添加零部件.TabIndex = 53
        Me.btn添加零部件.TabStop = False
        Me.btn添加零部件.UseVisualStyleBackColor = True
        '
        'btn复制面积
        '
        Me.btn复制面积.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn复制面积.Location = New System.Drawing.Point(421, 330)
        Me.btn复制面积.Name = "btn复制面积"
        Me.btn复制面积.Size = New System.Drawing.Size(25, 25)
        Me.btn复制面积.TabIndex = 52
        Me.btn复制面积.UseVisualStyleBackColor = True
        '
        'btn复制质量
        '
        Me.btn复制质量.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn复制质量.Location = New System.Drawing.Point(243, 330)
        Me.btn复制质量.Name = "btn复制质量"
        Me.btn复制质量.Size = New System.Drawing.Size(25, 25)
        Me.btn复制质量.TabIndex = 51
        Me.btn复制质量.UseVisualStyleBackColor = True
        '
        'txt面积
        '
        Me.txt面积.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt面积.Location = New System.Drawing.Point(338, 332)
        Me.txt面积.Name = "txt面积"
        Me.txt面积.ReadOnly = True
        Me.txt面积.Size = New System.Drawing.Size(77, 21)
        Me.txt面积.TabIndex = 48
        Me.txt面积.TabStop = False
        '
        'txt质量
        '
        Me.txt质量.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt质量.Location = New System.Drawing.Point(158, 332)
        Me.txt质量.Name = "txt质量"
        Me.txt质量.ReadOnly = True
        Me.txt质量.Size = New System.Drawing.Size(77, 21)
        Me.txt质量.TabIndex = 47
        Me.txt质量.TabStop = False
        '
        'btn选择零件
        '
        Me.btn选择零件.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn选择零件.Location = New System.Drawing.Point(9, 329)
        Me.btn选择零件.Name = "btn选择零件"
        Me.btn选择零件.Size = New System.Drawing.Size(26, 26)
        Me.btn选择零件.TabIndex = 44
        Me.btn选择零件.TabStop = False
        Me.btn选择零件.UseVisualStyleBackColor = True
        '
        'lbl描述
        '
        Me.lbl描述.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl描述.AutoSize = True
        Me.lbl描述.Location = New System.Drawing.Point(111, 336)
        Me.lbl描述.Name = "lbl描述"
        Me.lbl描述.Size = New System.Drawing.Size(221, 12)
        Me.lbl描述.TabIndex = 50
        Me.lbl描述.Text = "总质量：                    总面积："
        '
        'lvw质量文件列表
        '
        Me.lvw质量文件列表.AllowDrop = True
        Me.lvw质量文件列表.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvw质量文件列表.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ch文件名, Me.ch数量, Me.ch质量, Me.ch面积})
        Me.lvw质量文件列表.ContextMenuStrip = Me.cms右键菜单
        Me.lvw质量文件列表.FullRowSelect = True
        Me.lvw质量文件列表.Location = New System.Drawing.Point(6, 6)
        Me.lvw质量文件列表.Name = "lvw质量文件列表"
        Me.lvw质量文件列表.Size = New System.Drawing.Size(450, 310)
        Me.lvw质量文件列表.TabIndex = 49
        Me.lvw质量文件列表.TabStop = False
        Me.lvw质量文件列表.UseCompatibleStateImageBehavior = False
        Me.lvw质量文件列表.View = System.Windows.Forms.View.Details
        '
        'ch文件名
        '
        Me.ch文件名.Text = "文件名"
        Me.ch文件名.Width = 220
        '
        'ch数量
        '
        Me.ch数量.Text = "数量"
        Me.ch数量.Width = 50
        '
        'ch质量
        '
        Me.ch质量.Text = "质量"
        Me.ch质量.Width = 80
        '
        'ch面积
        '
        Me.ch面积.Text = "面积"
        Me.ch面积.Width = 80
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.btn选择面和边)
        Me.TabPage2.Controls.Add(Me.btn复制焊缝长度)
        Me.TabPage2.Controls.Add(Me.txt焊缝长度)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.lvw焊缝文件列表)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(463, 370)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "焊缝"
        Me.TabPage2.UseVisualStyleBackColor = True
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
        Me.btn复制焊缝长度.Location = New System.Drawing.Point(426, 325)
        Me.btn复制焊缝长度.Name = "btn复制焊缝长度"
        Me.btn复制焊缝长度.Size = New System.Drawing.Size(25, 25)
        Me.btn复制焊缝长度.TabIndex = 53
        Me.btn复制焊缝长度.UseVisualStyleBackColor = True
        '
        'txt焊缝长度
        '
        Me.txt焊缝长度.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt焊缝长度.Location = New System.Drawing.Point(311, 327)
        Me.txt焊缝长度.Name = "txt焊缝长度"
        Me.txt焊缝长度.ReadOnly = True
        Me.txt焊缝长度.Size = New System.Drawing.Size(106, 21)
        Me.txt焊缝长度.TabIndex = 50
        Me.txt焊缝长度.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(232, 331)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 12)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "总焊缝长度："
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
        Me.ch边位置.Width = 200
        '
        'ch长度
        '
        Me.ch长度.DisplayIndex = 2
        Me.ch长度.Text = "长度"
        Me.ch长度.Width = 80
        '
        'ch系数
        '
        Me.ch系数.DisplayIndex = 1
        Me.ch系数.Text = "系数"
        Me.ch系数.Width = 50
        '
        'ch焊缝长度
        '
        Me.ch焊缝长度.Text = "焊缝长度"
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
        'frmStatistical
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(495, 443)
        Me.Controls.Add(Me.btn清空)
        Me.Controls.Add(Me.btn移出)
        Me.Controls.Add(Me.btn关闭)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmStatistical"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "统计"
        Me.TopMost = True
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.cms右键菜单.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btn复制面积 As System.Windows.Forms.Button
    Friend WithEvents btn复制质量 As System.Windows.Forms.Button
    Friend WithEvents txt面积 As System.Windows.Forms.TextBox
    Friend WithEvents txt质量 As System.Windows.Forms.TextBox
    Friend WithEvents btn选择零件 As System.Windows.Forms.Button
    Friend WithEvents lbl描述 As System.Windows.Forms.Label
    Friend WithEvents lvw质量文件列表 As System.Windows.Forms.ListView
    Friend WithEvents ch文件名 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch数量 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch质量 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch面积 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton10 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents btn选择面和边 As System.Windows.Forms.Button
    Friend WithEvents btn复制焊缝长度 As System.Windows.Forms.Button
    Friend WithEvents txt焊缝长度 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvw焊缝文件列表 As System.Windows.Forms.ListView
    Friend WithEvents ch边位置 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch长度 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch系数 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch焊缝长度 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn清空 As System.Windows.Forms.Button
    Friend WithEvents btn移出 As System.Windows.Forms.Button
    Friend WithEvents btn添加零部件 As System.Windows.Forms.Button
    Friend WithEvents cms右键菜单 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmi移出 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi清空 As System.Windows.Forms.ToolStripMenuItem
End Class
