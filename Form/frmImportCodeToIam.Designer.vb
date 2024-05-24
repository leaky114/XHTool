<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportCodeToIam
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
        Me.components = New System.ComponentModel.Container()
        Me.lvw文件列表 = New System.Windows.Forms.ListView()
        Me.ch图号 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch名称 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch编码 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch供应商 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch文件名 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip右键菜单 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStrip设置为标准件 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip设置为看板件 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip设置为外购件 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip设置为外协件 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip清空供应商 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.btn查询 = New System.Windows.Forms.Button()
        Me.btn写入 = New System.Windows.Forms.Button()
        Me.prg进度条 = New System.Windows.Forms.ProgressBar()
        Me.btn装载 = New System.Windows.Forms.Button()
        Me.chk展开子级 = New System.Windows.Forms.CheckBox()
        Me.chk提示选择 = New System.Windows.Forms.CheckBox()
        Me.chk展开外协 = New System.Windows.Forms.CheckBox()
        Me.ContextMenuStrip右键菜单.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvw文件列表
        '
        Me.lvw文件列表.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvw文件列表.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ch图号, Me.ch名称, Me.ch编码, Me.ch供应商, Me.ch文件名})
        Me.lvw文件列表.ContextMenuStrip = Me.ContextMenuStrip右键菜单
        Me.lvw文件列表.FullRowSelect = True
        Me.lvw文件列表.Location = New System.Drawing.Point(12, 12)
        Me.lvw文件列表.MultiSelect = False
        Me.lvw文件列表.Name = "lvw文件列表"
        Me.lvw文件列表.Size = New System.Drawing.Size(799, 357)
        Me.lvw文件列表.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvw文件列表.TabIndex = 7
        Me.lvw文件列表.TabStop = False
        Me.lvw文件列表.UseCompatibleStateImageBehavior = False
        Me.lvw文件列表.View = System.Windows.Forms.View.Details
        '
        'ch图号
        '
        Me.ch图号.Text = "规格(图号)"
        Me.ch图号.Width = 200
        '
        'ch名称
        '
        Me.ch名称.Text = "存货名称"
        Me.ch名称.Width = 146
        '
        'ch编码
        '
        Me.ch编码.Text = "存货编码"
        Me.ch编码.Width = 70
        '
        'ch供应商
        '
        Me.ch供应商.Text = "供应商"
        '
        'ch文件名
        '
        Me.ch文件名.Text = "文件(双击打开)"
        Me.ch文件名.Width = 250
        '
        'ContextMenuStrip右键菜单
        '
        Me.ContextMenuStrip右键菜单.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStrip设置为标准件, Me.ToolStrip设置为看板件, Me.ToolStrip设置为外购件, Me.ToolStrip设置为外协件, Me.ToolStrip清空供应商})
        Me.ContextMenuStrip右键菜单.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip右键菜单.Size = New System.Drawing.Size(149, 114)
        '
        'ToolStrip设置为标准件
        '
        Me.ToolStrip设置为标准件.Name = "ToolStrip设置为标准件"
        Me.ToolStrip设置为标准件.Size = New System.Drawing.Size(148, 22)
        Me.ToolStrip设置为标准件.Text = "设置为标准件"
        '
        'ToolStrip设置为看板件
        '
        Me.ToolStrip设置为看板件.Name = "ToolStrip设置为看板件"
        Me.ToolStrip设置为看板件.Size = New System.Drawing.Size(148, 22)
        Me.ToolStrip设置为看板件.Text = "设置为看板件"
        '
        'ToolStrip设置为外购件
        '
        Me.ToolStrip设置为外购件.Name = "ToolStrip设置为外购件"
        Me.ToolStrip设置为外购件.Size = New System.Drawing.Size(148, 22)
        Me.ToolStrip设置为外购件.Text = "设置为外购件"
        '
        'ToolStrip设置为外协件
        '
        Me.ToolStrip设置为外协件.Name = "ToolStrip设置为外协件"
        Me.ToolStrip设置为外协件.Size = New System.Drawing.Size(148, 22)
        Me.ToolStrip设置为外协件.Text = "设置为外协件"
        '
        'ToolStrip清空供应商
        '
        Me.ToolStrip清空供应商.Name = "ToolStrip清空供应商"
        Me.ToolStrip清空供应商.Size = New System.Drawing.Size(148, 22)
        Me.ToolStrip清空供应商.Text = "清空供应商"
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.AutoSize = True
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(740, 387)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(69, 28)
        Me.btn关闭.TabIndex = 6
        Me.btn关闭.Text = "关闭"
        '
        'btn查询
        '
        Me.btn查询.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn查询.Location = New System.Drawing.Point(586, 387)
        Me.btn查询.Name = "btn查询"
        Me.btn查询.Size = New System.Drawing.Size(69, 28)
        Me.btn查询.TabIndex = 1
        Me.btn查询.Text = "查询"
        '
        'btn写入
        '
        Me.btn写入.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn写入.Location = New System.Drawing.Point(663, 387)
        Me.btn写入.Name = "btn写入"
        Me.btn写入.Size = New System.Drawing.Size(69, 28)
        Me.btn写入.TabIndex = 2
        Me.btn写入.Text = "写入"
        Me.btn写入.UseVisualStyleBackColor = True
        '
        'prg进度条
        '
        Me.prg进度条.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.prg进度条.Location = New System.Drawing.Point(12, 389)
        Me.prg进度条.Name = "prg进度条"
        Me.prg进度条.Size = New System.Drawing.Size(243, 24)
        Me.prg进度条.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.prg进度条.TabIndex = 35
        '
        'btn装载
        '
        Me.btn装载.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn装载.Location = New System.Drawing.Point(509, 387)
        Me.btn装载.Name = "btn装载"
        Me.btn装载.Size = New System.Drawing.Size(69, 28)
        Me.btn装载.TabIndex = 0
        Me.btn装载.Text = "装载"
        '
        'chk展开子级
        '
        Me.chk展开子级.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk展开子级.AutoSize = True
        Me.chk展开子级.Location = New System.Drawing.Point(429, 393)
        Me.chk展开子级.Name = "chk展开子级"
        Me.chk展开子级.Size = New System.Drawing.Size(72, 16)
        Me.chk展开子级.TabIndex = 5
        Me.chk展开子级.Text = "展开子级"
        Me.chk展开子级.UseVisualStyleBackColor = True
        '
        'chk提示选择
        '
        Me.chk提示选择.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk提示选择.AutoSize = True
        Me.chk提示选择.Location = New System.Drawing.Point(264, 393)
        Me.chk提示选择.Name = "chk提示选择"
        Me.chk提示选择.Size = New System.Drawing.Size(72, 16)
        Me.chk提示选择.TabIndex = 3
        Me.chk提示选择.Text = "提示选择"
        Me.chk提示选择.UseVisualStyleBackColor = True
        '
        'chk展开外协
        '
        Me.chk展开外协.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk展开外协.AutoSize = True
        Me.chk展开外协.Location = New System.Drawing.Point(346, 393)
        Me.chk展开外协.Name = "chk展开外协"
        Me.chk展开外协.Size = New System.Drawing.Size(72, 16)
        Me.chk展开外协.TabIndex = 4
        Me.chk展开外协.Text = "展开外协"
        Me.chk展开外协.UseVisualStyleBackColor = True
        '
        'frmImportCodeToIam
        '
        Me.AcceptButton = Me.btn装载
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn关闭
        Me.ClientSize = New System.Drawing.Size(823, 425)
        Me.Controls.Add(Me.chk展开外协)
        Me.Controls.Add(Me.chk提示选择)
        Me.Controls.Add(Me.chk展开子级)
        Me.Controls.Add(Me.btn装载)
        Me.Controls.Add(Me.prg进度条)
        Me.Controls.Add(Me.btn写入)
        Me.Controls.Add(Me.btn关闭)
        Me.Controls.Add(Me.btn查询)
        Me.Controls.Add(Me.lvw文件列表)
        Me.MaximizeBox = False
        Me.Name = "frmImportCodeToIam"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "导入ERP编码"
        Me.TopMost = True
        Me.ContextMenuStrip右键菜单.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvw文件列表 As System.Windows.Forms.ListView
    Friend WithEvents ch编码 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch名称 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch图号 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents btn查询 As System.Windows.Forms.Button
    Friend WithEvents ch文件名 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn写入 As System.Windows.Forms.Button
    Friend WithEvents prg进度条 As System.Windows.Forms.ProgressBar
    Friend WithEvents btn装载 As System.Windows.Forms.Button
    Friend WithEvents chk展开子级 As System.Windows.Forms.CheckBox
    Friend WithEvents chk提示选择 As System.Windows.Forms.CheckBox
    Friend WithEvents ch供应商 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenuStrip右键菜单 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStrip设置为外购件 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chk展开外协 As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStrip设置为外协件 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip设置为标准件 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip设置为看板件 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip清空供应商 As System.Windows.Forms.ToolStripMenuItem
End Class
