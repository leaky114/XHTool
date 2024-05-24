<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAutoPartNumber
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
        Me.btn开始 = New System.Windows.Forms.Button()
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.btn上移 = New System.Windows.Forms.Button()
        Me.btn预览 = New System.Windows.Forms.Button()
        Me.btn下移 = New System.Windows.Forms.Button()
        Me.lvw文件列表 = New System.Windows.Forms.ListView()
        Me.ch原文件名 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch类型 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch新文件名 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch文件夹 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cms右键菜单 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmi移出 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi筛选移出 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi筛选保留 = New System.Windows.Forms.ToolStripMenuItem()
        Me.txt基准图号 = New System.Windows.Forms.TextBox()
        Me.lbl基准图号 = New System.Windows.Forms.Label()
        Me.lbl部件变量 = New System.Windows.Forms.Label()
        Me.lbl零件变量 = New System.Windows.Forms.Label()
        Me.txt零件变量 = New System.Windows.Forms.TextBox()
        Me.cmb部件变量 = New System.Windows.Forms.ComboBox()
        Me.btn移出 = New System.Windows.Forms.Button()
        Me.btn重载 = New System.Windows.Forms.Button()
        Me.lbl新文件名 = New System.Windows.Forms.Label()
        Me.txt新文件名 = New System.Windows.Forms.TextBox()
        Me.btn确定新文件名 = New System.Windows.Forms.Button()
        Me.chk备份文件 = New System.Windows.Forms.CheckBox()
        Me.cms右键菜单.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn开始
        '
        Me.btn开始.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn开始.Location = New System.Drawing.Point(514, 391)
        Me.btn开始.Name = "btn开始"
        Me.btn开始.Size = New System.Drawing.Size(65, 28)
        Me.btn开始.TabIndex = 11
        Me.btn开始.Text = "开始"
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.AutoSize = True
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(587, 391)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(65, 28)
        Me.btn关闭.TabIndex = 12
        Me.btn关闭.Text = "关闭"
        '
        'btn上移
        '
        Me.btn上移.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn上移.Location = New System.Drawing.Point(16, 391)
        Me.btn上移.Name = "btn上移"
        Me.btn上移.Size = New System.Drawing.Size(65, 28)
        Me.btn上移.TabIndex = 6
        Me.btn上移.TabStop = False
        Me.btn上移.Text = "上移"
        Me.btn上移.UseVisualStyleBackColor = True
        '
        'btn预览
        '
        Me.btn预览.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn预览.Location = New System.Drawing.Point(308, 391)
        Me.btn预览.Name = "btn预览"
        Me.btn预览.Size = New System.Drawing.Size(65, 28)
        Me.btn预览.TabIndex = 10
        Me.btn预览.Text = "预览"
        Me.btn预览.UseVisualStyleBackColor = True
        '
        'btn下移
        '
        Me.btn下移.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn下移.Location = New System.Drawing.Point(89, 391)
        Me.btn下移.Name = "btn下移"
        Me.btn下移.Size = New System.Drawing.Size(65, 28)
        Me.btn下移.TabIndex = 7
        Me.btn下移.TabStop = False
        Me.btn下移.Text = "下移"
        Me.btn下移.UseVisualStyleBackColor = True
        '
        'lvw文件列表
        '
        Me.lvw文件列表.AllowDrop = True
        Me.lvw文件列表.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvw文件列表.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ch原文件名, Me.ch类型, Me.ch新文件名, Me.ch文件夹})
        Me.lvw文件列表.ContextMenuStrip = Me.cms右键菜单
        Me.lvw文件列表.FullRowSelect = True
        Me.lvw文件列表.Location = New System.Drawing.Point(13, 12)
        Me.lvw文件列表.Name = "lvw文件列表"
        Me.lvw文件列表.Size = New System.Drawing.Size(639, 287)
        Me.lvw文件列表.TabIndex = 0
        Me.lvw文件列表.TabStop = False
        Me.lvw文件列表.UseCompatibleStateImageBehavior = False
        Me.lvw文件列表.View = System.Windows.Forms.View.Details
        '
        'ch原文件名
        '
        Me.ch原文件名.Text = "原文件名"
        Me.ch原文件名.Width = 180
        '
        'ch类型
        '
        Me.ch类型.Text = "类型"
        Me.ch类型.Width = 50
        '
        'ch新文件名
        '
        Me.ch新文件名.Text = "新文件名"
        Me.ch新文件名.Width = 250
        '
        'ch文件夹
        '
        Me.ch文件夹.Text = "文件夹"
        Me.ch文件夹.Width = 250
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
        'txt基准图号
        '
        Me.txt基准图号.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt基准图号.Location = New System.Drawing.Point(79, 320)
        Me.txt基准图号.Name = "txt基准图号"
        Me.txt基准图号.Size = New System.Drawing.Size(134, 21)
        Me.txt基准图号.TabIndex = 1
        '
        'lbl基准图号
        '
        Me.lbl基准图号.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl基准图号.AutoSize = True
        Me.lbl基准图号.Location = New System.Drawing.Point(22, 324)
        Me.lbl基准图号.Name = "lbl基准图号"
        Me.lbl基准图号.Size = New System.Drawing.Size(53, 12)
        Me.lbl基准图号.TabIndex = 0
        Me.lbl基准图号.Text = "基准图号"
        '
        'lbl部件变量
        '
        Me.lbl部件变量.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl部件变量.AutoSize = True
        Me.lbl部件变量.Location = New System.Drawing.Point(219, 324)
        Me.lbl部件变量.Name = "lbl部件变量"
        Me.lbl部件变量.Size = New System.Drawing.Size(65, 12)
        Me.lbl部件变量.TabIndex = 26
        Me.lbl部件变量.Text = "部件变化量"
        '
        'lbl零件变量
        '
        Me.lbl零件变量.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl零件变量.AutoSize = True
        Me.lbl零件变量.Location = New System.Drawing.Point(397, 324)
        Me.lbl零件变量.Name = "lbl零件变量"
        Me.lbl零件变量.Size = New System.Drawing.Size(65, 12)
        Me.lbl零件变量.TabIndex = 28
        Me.lbl零件变量.Text = "零件变化量"
        '
        'txt零件变量
        '
        Me.txt零件变量.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt零件变量.Location = New System.Drawing.Point(478, 320)
        Me.txt零件变量.Name = "txt零件变量"
        Me.txt零件变量.Size = New System.Drawing.Size(73, 21)
        Me.txt零件变量.TabIndex = 3
        Me.txt零件变量.Text = "1"
        '
        'cmb部件变量
        '
        Me.cmb部件变量.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmb部件变量.FormattingEnabled = True
        Me.cmb部件变量.Items.AddRange(New Object() {"100", "10000"})
        Me.cmb部件变量.Location = New System.Drawing.Point(292, 320)
        Me.cmb部件变量.Name = "cmb部件变量"
        Me.cmb部件变量.Size = New System.Drawing.Size(99, 20)
        Me.cmb部件变量.TabIndex = 2
        Me.cmb部件变量.Text = "100"
        '
        'btn移出
        '
        Me.btn移出.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn移出.Location = New System.Drawing.Point(162, 391)
        Me.btn移出.Name = "btn移出"
        Me.btn移出.Size = New System.Drawing.Size(65, 28)
        Me.btn移出.TabIndex = 8
        Me.btn移出.Text = "移出"
        Me.btn移出.UseVisualStyleBackColor = True
        '
        'btn重载
        '
        Me.btn重载.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn重载.Location = New System.Drawing.Point(235, 391)
        Me.btn重载.Name = "btn重载"
        Me.btn重载.Size = New System.Drawing.Size(65, 28)
        Me.btn重载.TabIndex = 9
        Me.btn重载.Text = "重载"
        Me.btn重载.UseVisualStyleBackColor = True
        '
        'lbl新文件名
        '
        Me.lbl新文件名.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl新文件名.AutoSize = True
        Me.lbl新文件名.Location = New System.Drawing.Point(20, 352)
        Me.lbl新文件名.Name = "lbl新文件名"
        Me.lbl新文件名.Size = New System.Drawing.Size(53, 12)
        Me.lbl新文件名.TabIndex = 31
        Me.lbl新文件名.Text = "新文件名"
        '
        'txt新文件名
        '
        Me.txt新文件名.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt新文件名.Location = New System.Drawing.Point(79, 348)
        Me.txt新文件名.Name = "txt新文件名"
        Me.txt新文件名.Size = New System.Drawing.Size(361, 21)
        Me.txt新文件名.TabIndex = 4
        '
        'btn确定新文件名
        '
        Me.btn确定新文件名.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn确定新文件名.Location = New System.Drawing.Point(446, 345)
        Me.btn确定新文件名.Name = "btn确定新文件名"
        Me.btn确定新文件名.Size = New System.Drawing.Size(26, 26)
        Me.btn确定新文件名.TabIndex = 5
        Me.btn确定新文件名.UseVisualStyleBackColor = True
        '
        'chk备份文件
        '
        Me.chk备份文件.AutoSize = True
        Me.chk备份文件.Location = New System.Drawing.Point(566, 322)
        Me.chk备份文件.Name = "chk备份文件"
        Me.chk备份文件.Size = New System.Drawing.Size(72, 16)
        Me.chk备份文件.TabIndex = 32
        Me.chk备份文件.Text = "备份文件"
        Me.chk备份文件.UseVisualStyleBackColor = True
        '
        'frmAutoPartNumber
        '
        Me.AcceptButton = Me.btn确定新文件名
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn关闭
        Me.ClientSize = New System.Drawing.Size(664, 433)
        Me.Controls.Add(Me.chk备份文件)
        Me.Controls.Add(Me.btn确定新文件名)
        Me.Controls.Add(Me.txt新文件名)
        Me.Controls.Add(Me.lbl新文件名)
        Me.Controls.Add(Me.btn重载)
        Me.Controls.Add(Me.btn移出)
        Me.Controls.Add(Me.cmb部件变量)
        Me.Controls.Add(Me.lbl零件变量)
        Me.Controls.Add(Me.txt零件变量)
        Me.Controls.Add(Me.lbl部件变量)
        Me.Controls.Add(Me.lbl基准图号)
        Me.Controls.Add(Me.txt基准图号)
        Me.Controls.Add(Me.lvw文件列表)
        Me.Controls.Add(Me.btn下移)
        Me.Controls.Add(Me.btn预览)
        Me.Controls.Add(Me.btn上移)
        Me.Controls.Add(Me.btn关闭)
        Me.Controls.Add(Me.btn开始)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAutoPartNumber"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "自动命名图号"
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
    Friend WithEvents ch新文件名 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txt基准图号 As System.Windows.Forms.TextBox
    Friend WithEvents lbl基准图号 As System.Windows.Forms.Label
    Friend WithEvents lbl部件变量 As System.Windows.Forms.Label
    Friend WithEvents lbl零件变量 As System.Windows.Forms.Label
    Friend WithEvents txt零件变量 As System.Windows.Forms.TextBox
    Friend WithEvents ch文件夹 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmb部件变量 As System.Windows.Forms.ComboBox
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

End Class
