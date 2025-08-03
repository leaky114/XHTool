

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAutoPartNumber
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
        Me.components = New System.ComponentModel.Container()
        Me.btn开始 = New System.Windows.Forms.Button()
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.btn上移 = New System.Windows.Forms.Button()
        Me.btn预览 = New System.Windows.Forms.Button()
        Me.btn下移 = New System.Windows.Forms.Button()
        Me.lvw文件列表 = New System.Windows.Forms.ListView()
        Me.ch状态 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch原文件名 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch类型 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch新图号 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch文件夹 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cms右键菜单 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmi锁定 = New System.Windows.Forms.ToolStripMenuItem()
        Me.锁定文件名ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.锁定图号ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.锁定名称ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi解锁 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi移出 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi筛选移出 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi筛选保留 = New System.Windows.Forms.ToolStripMenuItem()
        Me.txt基准图号 = New System.Windows.Forms.TextBox()
        Me.lbl基准图号 = New System.Windows.Forms.Label()
        Me.lbl部件增量 = New System.Windows.Forms.Label()
        Me.lbl零件增量 = New System.Windows.Forms.Label()
        Me.txt零件增量 = New System.Windows.Forms.TextBox()
        Me.btn移出 = New System.Windows.Forms.Button()
        Me.btn重载 = New System.Windows.Forms.Button()
        Me.lbl新文件名 = New System.Windows.Forms.Label()
        Me.txt新文件名 = New System.Windows.Forms.TextBox()
        Me.btn确定新文件名 = New System.Windows.Forms.Button()
        Me.chk备份文件 = New System.Windows.Forms.CheckBox()
        Me.txt部件增量 = New System.Windows.Forms.TextBox()
        Me.lbl零件初始值 = New System.Windows.Forms.Label()
        Me.txt零件初始值 = New System.Windows.Forms.TextBox()
        Me.chk部件初始值 = New System.Windows.Forms.CheckBox()
        Me.txt部件初始值 = New System.Windows.Forms.TextBox()
        Me.lbl井号数 = New System.Windows.Forms.Label()
        Me.lbl连接符 = New System.Windows.Forms.Label()
        Me.cmb连接符 = New System.Windows.Forms.ComboBox()
        Me.cms右键菜单.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn开始
        '
        Me.btn开始.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn开始.Location = New System.Drawing.Point(698, 401)
        Me.btn开始.Name = "btn开始"
        Me.btn开始.Size = New System.Drawing.Size(65, 28)
        Me.btn开始.TabIndex = 15
        Me.btn开始.Text = "开始"
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.AutoSize = True
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(771, 401)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(65, 28)
        Me.btn关闭.TabIndex = 16
        Me.btn关闭.Text = "关闭"
        '
        'btn上移
        '
        Me.btn上移.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn上移.Location = New System.Drawing.Point(16, 401)
        Me.btn上移.Name = "btn上移"
        Me.btn上移.Size = New System.Drawing.Size(65, 28)
        Me.btn上移.TabIndex = 10
        Me.btn上移.Text = "上移"
        Me.btn上移.UseVisualStyleBackColor = True
        '
        'btn预览
        '
        Me.btn预览.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn预览.Location = New System.Drawing.Point(308, 401)
        Me.btn预览.Name = "btn预览"
        Me.btn预览.Size = New System.Drawing.Size(65, 28)
        Me.btn预览.TabIndex = 14
        Me.btn预览.Text = "预览"
        Me.btn预览.UseVisualStyleBackColor = True
        '
        'btn下移
        '
        Me.btn下移.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn下移.Location = New System.Drawing.Point(89, 401)
        Me.btn下移.Name = "btn下移"
        Me.btn下移.Size = New System.Drawing.Size(65, 28)
        Me.btn下移.TabIndex = 11
        Me.btn下移.Text = "下移"
        Me.btn下移.UseVisualStyleBackColor = True
        '
        'lvw文件列表
        '
        Me.lvw文件列表.AllowDrop = True
        Me.lvw文件列表.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvw文件列表.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ch状态, Me.ch原文件名, Me.ch类型, Me.ch新图号, Me.ch文件夹})
        Me.lvw文件列表.ContextMenuStrip = Me.cms右键菜单
        Me.lvw文件列表.FullRowSelect = True
        Me.lvw文件列表.HideSelection = False
        Me.lvw文件列表.Location = New System.Drawing.Point(13, 12)
        Me.lvw文件列表.Name = "lvw文件列表"
        Me.lvw文件列表.Size = New System.Drawing.Size(823, 299)
        Me.lvw文件列表.TabIndex = 0
        Me.lvw文件列表.UseCompatibleStateImageBehavior = False
        Me.lvw文件列表.View = System.Windows.Forms.View.Details
        '
        'ch状态
        '
        Me.ch状态.Text = "状态"
        Me.ch状态.Width = 70
        '
        'ch原文件名
        '
        Me.ch原文件名.Text = "原文件名"
        Me.ch原文件名.Width = 180
        '
        'ch类型
        '
        Me.ch类型.Text = "类型"
        Me.ch类型.Width = 70
        '
        'ch新图号
        '
        Me.ch新图号.Text = "新图号"
        Me.ch新图号.Width = 180
        '
        'ch文件夹
        '
        Me.ch文件夹.Text = "文件夹"
        Me.ch文件夹.Width = 301
        '
        'cms右键菜单
        '
        Me.cms右键菜单.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi锁定, Me.tsmi解锁, Me.tsmi移出, Me.tsmi筛选移出, Me.tsmi筛选保留})
        Me.cms右键菜单.Name = "cmsRemove"
        Me.cms右键菜单.Size = New System.Drawing.Size(125, 114)
        '
        'tsmi锁定
        '
        Me.tsmi锁定.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.锁定文件名ToolStripMenuItem, Me.锁定图号ToolStripMenuItem, Me.锁定名称ToolStripMenuItem3})
        Me.tsmi锁定.Name = "tsmi锁定"
        Me.tsmi锁定.Size = New System.Drawing.Size(124, 22)
        Me.tsmi锁定.Text = "锁定"
        Me.tsmi锁定.ToolTipText = "锁定当前行，预览无效"
        '
        '锁定文件名ToolStripMenuItem
        '
        Me.锁定文件名ToolStripMenuItem.Name = "锁定文件名ToolStripMenuItem"
        Me.锁定文件名ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.锁定文件名ToolStripMenuItem.Text = "锁定文件名"
        '
        '锁定图号ToolStripMenuItem
        '
        Me.锁定图号ToolStripMenuItem.Name = "锁定图号ToolStripMenuItem"
        Me.锁定图号ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.锁定图号ToolStripMenuItem.Text = "锁定图号"
        '
        '锁定名称ToolStripMenuItem3
        '
        Me.锁定名称ToolStripMenuItem3.Name = "锁定名称ToolStripMenuItem3"
        Me.锁定名称ToolStripMenuItem3.Size = New System.Drawing.Size(180, 22)
        Me.锁定名称ToolStripMenuItem3.Text = "锁定名称"
        '
        'tsmi解锁
        '
        Me.tsmi解锁.Name = "tsmi解锁"
        Me.tsmi解锁.Size = New System.Drawing.Size(124, 22)
        Me.tsmi解锁.Text = "解锁"
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
        'txt基准图号
        '
        Me.txt基准图号.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt基准图号.Location = New System.Drawing.Point(79, 326)
        Me.txt基准图号.Name = "txt基准图号"
        Me.txt基准图号.Size = New System.Drawing.Size(134, 21)
        Me.txt基准图号.TabIndex = 1
        '
        'lbl基准图号
        '
        Me.lbl基准图号.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl基准图号.AutoSize = True
        Me.lbl基准图号.Location = New System.Drawing.Point(22, 330)
        Me.lbl基准图号.Name = "lbl基准图号"
        Me.lbl基准图号.Size = New System.Drawing.Size(53, 12)
        Me.lbl基准图号.TabIndex = 0
        Me.lbl基准图号.Text = "基准图号"
        '
        'lbl部件增量
        '
        Me.lbl部件增量.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl部件增量.AutoSize = True
        Me.lbl部件增量.Location = New System.Drawing.Point(568, 330)
        Me.lbl部件增量.Name = "lbl部件增量"
        Me.lbl部件增量.Size = New System.Drawing.Size(29, 12)
        Me.lbl部件增量.TabIndex = 26
        Me.lbl部件增量.Text = "增量"
        '
        'lbl零件增量
        '
        Me.lbl零件增量.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl零件增量.AutoSize = True
        Me.lbl零件增量.Location = New System.Drawing.Point(345, 330)
        Me.lbl零件增量.Name = "lbl零件增量"
        Me.lbl零件增量.Size = New System.Drawing.Size(29, 12)
        Me.lbl零件增量.TabIndex = 28
        Me.lbl零件增量.Text = "增量"
        '
        'txt零件增量
        '
        Me.txt零件增量.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt零件增量.Location = New System.Drawing.Point(376, 326)
        Me.txt零件增量.Name = "txt零件增量"
        Me.txt零件增量.Size = New System.Drawing.Size(33, 21)
        Me.txt零件增量.TabIndex = 3
        Me.txt零件增量.Text = "1"
        '
        'btn移出
        '
        Me.btn移出.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn移出.Location = New System.Drawing.Point(162, 401)
        Me.btn移出.Name = "btn移出"
        Me.btn移出.Size = New System.Drawing.Size(65, 28)
        Me.btn移出.TabIndex = 12
        Me.btn移出.Text = "移出"
        Me.btn移出.UseVisualStyleBackColor = True
        '
        'btn重载
        '
        Me.btn重载.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn重载.Location = New System.Drawing.Point(235, 401)
        Me.btn重载.Name = "btn重载"
        Me.btn重载.Size = New System.Drawing.Size(65, 28)
        Me.btn重载.TabIndex = 13
        Me.btn重载.Text = "重载"
        Me.btn重载.UseVisualStyleBackColor = True
        '
        'lbl新文件名
        '
        Me.lbl新文件名.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl新文件名.AutoSize = True
        Me.lbl新文件名.Location = New System.Drawing.Point(20, 362)
        Me.lbl新文件名.Name = "lbl新文件名"
        Me.lbl新文件名.Size = New System.Drawing.Size(53, 12)
        Me.lbl新文件名.TabIndex = 31
        Me.lbl新文件名.Text = "新文件名"
        '
        'txt新文件名
        '
        Me.txt新文件名.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt新文件名.Location = New System.Drawing.Point(79, 358)
        Me.txt新文件名.Name = "txt新文件名"
        Me.txt新文件名.Size = New System.Drawing.Size(361, 21)
        Me.txt新文件名.TabIndex = 7
        '
        'btn确定新文件名
        '
        Me.btn确定新文件名.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn确定新文件名.Location = New System.Drawing.Point(446, 355)
        Me.btn确定新文件名.Name = "btn确定新文件名"
        Me.btn确定新文件名.Size = New System.Drawing.Size(26, 26)
        Me.btn确定新文件名.TabIndex = 8
        Me.btn确定新文件名.UseVisualStyleBackColor = True
        '
        'chk备份文件
        '
        Me.chk备份文件.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chk备份文件.AutoSize = True
        Me.chk备份文件.Location = New System.Drawing.Point(511, 361)
        Me.chk备份文件.Name = "chk备份文件"
        Me.chk备份文件.Size = New System.Drawing.Size(72, 16)
        Me.chk备份文件.TabIndex = 9
        Me.chk备份文件.Text = "备份文件"
        Me.chk备份文件.UseVisualStyleBackColor = True
        '
        'txt部件增量
        '
        Me.txt部件增量.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt部件增量.Location = New System.Drawing.Point(601, 326)
        Me.txt部件增量.Name = "txt部件增量"
        Me.txt部件增量.Size = New System.Drawing.Size(61, 21)
        Me.txt部件增量.TabIndex = 6
        Me.txt部件增量.Text = "100"
        '
        'lbl零件初始值
        '
        Me.lbl零件初始值.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl零件初始值.AutoSize = True
        Me.lbl零件初始值.Location = New System.Drawing.Point(240, 330)
        Me.lbl零件初始值.Name = "lbl零件初始值"
        Me.lbl零件初始值.Size = New System.Drawing.Size(65, 12)
        Me.lbl零件初始值.TabIndex = 28
        Me.lbl零件初始值.Text = "零件初始值"
        '
        'txt零件初始值
        '
        Me.txt零件初始值.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt零件初始值.Location = New System.Drawing.Point(306, 326)
        Me.txt零件初始值.Name = "txt零件初始值"
        Me.txt零件初始值.Size = New System.Drawing.Size(33, 21)
        Me.txt零件初始值.TabIndex = 2
        Me.txt零件初始值.Text = "1"
        '
        'chk部件初始值
        '
        Me.chk部件初始值.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chk部件初始值.AutoSize = True
        Me.chk部件初始值.Location = New System.Drawing.Point(420, 328)
        Me.chk部件初始值.Name = "chk部件初始值"
        Me.chk部件初始值.Size = New System.Drawing.Size(84, 16)
        Me.chk部件初始值.TabIndex = 4
        Me.chk部件初始值.Text = "部件初始值"
        Me.chk部件初始值.UseVisualStyleBackColor = True
        '
        'txt部件初始值
        '
        Me.txt部件初始值.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt部件初始值.Location = New System.Drawing.Point(504, 326)
        Me.txt部件初始值.Name = "txt部件初始值"
        Me.txt部件初始值.Size = New System.Drawing.Size(61, 21)
        Me.txt部件初始值.TabIndex = 5
        Me.txt部件初始值.Text = "100"
        '
        'lbl井号数
        '
        Me.lbl井号数.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl井号数.AutoSize = True
        Me.lbl井号数.ForeColor = System.Drawing.Color.Red
        Me.lbl井号数.Location = New System.Drawing.Point(219, 330)
        Me.lbl井号数.Name = "lbl井号数"
        Me.lbl井号数.Size = New System.Drawing.Size(11, 12)
        Me.lbl井号数.TabIndex = 32
        Me.lbl井号数.Text = "0"
        '
        'lbl连接符
        '
        Me.lbl连接符.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl连接符.AutoSize = True
        Me.lbl连接符.Location = New System.Drawing.Point(674, 330)
        Me.lbl连接符.Name = "lbl连接符"
        Me.lbl连接符.Size = New System.Drawing.Size(41, 12)
        Me.lbl连接符.TabIndex = 33
        Me.lbl连接符.Text = "连接符"
        '
        'cmb连接符
        '
        Me.cmb连接符.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmb连接符.FormattingEnabled = True
        Me.cmb连接符.Items.AddRange(New Object() {"无", "空格", "短横线-", "下划线_"})
        Me.cmb连接符.Location = New System.Drawing.Point(721, 326)
        Me.cmb连接符.Name = "cmb连接符"
        Me.cmb连接符.Size = New System.Drawing.Size(78, 20)
        Me.cmb连接符.TabIndex = 34
        '
        'FormAutoPartNumber
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn关闭
        Me.ClientSize = New System.Drawing.Size(848, 443)
        Me.Controls.Add(Me.cmb连接符)
        Me.Controls.Add(Me.lbl连接符)
        Me.Controls.Add(Me.lbl井号数)
        Me.Controls.Add(Me.txt部件初始值)
        Me.Controls.Add(Me.chk部件初始值)
        Me.Controls.Add(Me.txt部件增量)
        Me.Controls.Add(Me.chk备份文件)
        Me.Controls.Add(Me.btn确定新文件名)
        Me.Controls.Add(Me.txt新文件名)
        Me.Controls.Add(Me.lbl新文件名)
        Me.Controls.Add(Me.btn重载)
        Me.Controls.Add(Me.btn移出)
        Me.Controls.Add(Me.lbl零件初始值)
        Me.Controls.Add(Me.lbl零件增量)
        Me.Controls.Add(Me.txt零件初始值)
        Me.Controls.Add(Me.txt零件增量)
        Me.Controls.Add(Me.lbl部件增量)
        Me.Controls.Add(Me.lbl基准图号)
        Me.Controls.Add(Me.txt基准图号)
        Me.Controls.Add(Me.lvw文件列表)
        Me.Controls.Add(Me.btn下移)
        Me.Controls.Add(Me.btn预览)
        Me.Controls.Add(Me.btn上移)
        Me.Controls.Add(Me.btn关闭)
        Me.Controls.Add(Me.btn开始)
        Me.Name = "FormAutoPartNumber"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "自动生成图号"
        Me.TopMost = True
        Me.cms右键菜单.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn开始 As System.Windows.Forms.Button
    Friend WithEvents btn上移 As System.Windows.Forms.Button
    Friend WithEvents btn预览 As System.Windows.Forms.Button
    Friend WithEvents btn下移 As System.Windows.Forms.Button
    Friend WithEvents lvw文件列表 As System.Windows.Forms.ListView
    Friend WithEvents ch原文件名 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch类型 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txt基准图号 As System.Windows.Forms.TextBox
    Friend WithEvents lbl基准图号 As System.Windows.Forms.Label
    Friend WithEvents lbl部件增量 As System.Windows.Forms.Label
    Friend WithEvents lbl零件增量 As System.Windows.Forms.Label
    Friend WithEvents txt零件增量 As System.Windows.Forms.TextBox
    Friend WithEvents ch文件夹 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn移出 As System.Windows.Forms.Button
    Friend WithEvents btn重载 As System.Windows.Forms.Button
    Friend WithEvents lbl新文件名 As System.Windows.Forms.Label
    Friend WithEvents txt新文件名 As System.Windows.Forms.TextBox
    Friend WithEvents btn确定新文件名 As System.Windows.Forms.Button
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents cms右键菜单 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmi移出 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi筛选移出 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi筛选保留 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chk备份文件 As System.Windows.Forms.CheckBox
    Friend WithEvents txt部件增量 As System.Windows.Forms.TextBox
    Friend WithEvents lbl零件初始值 As System.Windows.Forms.Label
    Friend WithEvents txt零件初始值 As System.Windows.Forms.TextBox
    Friend WithEvents chk部件初始值 As System.Windows.Forms.CheckBox
    Friend WithEvents txt部件初始值 As System.Windows.Forms.TextBox
    Friend WithEvents lbl井号数 As System.Windows.Forms.Label
    Friend WithEvents ch新图号 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch状态 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tsmi锁定 As ToolStripMenuItem
    Friend WithEvents lbl连接符 As Label
    Friend WithEvents cmb连接符 As ComboBox
    Friend WithEvents 锁定文件名ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 锁定图号ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 锁定名称ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents tsmi解锁 As ToolStripMenuItem
End Class
