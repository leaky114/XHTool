<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBorderTitle
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
        Me.cmb边框 = New System.Windows.Forms.ComboBox()
        Me.GroupBox边框 = New System.Windows.Forms.GroupBox()
        Me.GroupBox标题栏 = New System.Windows.Forms.GroupBox()
        Me.lvw标题栏对应表 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmb新标题栏 = New System.Windows.Forms.ComboBox()
        Me.cmb旧标题栏 = New System.Windows.Forms.ComboBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打开旧模板ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打开新模板ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.保存配置ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打开配置文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.列表ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.添加ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.删除ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox边框.SuspendLayout()
        Me.GroupBox标题栏.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmb边框
        '
        Me.cmb边框.FormattingEnabled = True
        Me.cmb边框.Location = New System.Drawing.Point(15, 20)
        Me.cmb边框.Name = "cmb边框"
        Me.cmb边框.Size = New System.Drawing.Size(125, 20)
        Me.cmb边框.TabIndex = 1
        '
        'GroupBox边框
        '
        Me.GroupBox边框.Controls.Add(Me.cmb边框)
        Me.GroupBox边框.Location = New System.Drawing.Point(12, 34)
        Me.GroupBox边框.Name = "GroupBox边框"
        Me.GroupBox边框.Size = New System.Drawing.Size(296, 59)
        Me.GroupBox边框.TabIndex = 2
        Me.GroupBox边框.TabStop = False
        Me.GroupBox边框.Text = "边框"
        '
        'GroupBox标题栏
        '
        Me.GroupBox标题栏.Controls.Add(Me.lvw标题栏对应表)
        Me.GroupBox标题栏.Controls.Add(Me.cmb新标题栏)
        Me.GroupBox标题栏.Controls.Add(Me.cmb旧标题栏)
        Me.GroupBox标题栏.Location = New System.Drawing.Point(12, 103)
        Me.GroupBox标题栏.Name = "GroupBox标题栏"
        Me.GroupBox标题栏.Size = New System.Drawing.Size(296, 191)
        Me.GroupBox标题栏.TabIndex = 3
        Me.GroupBox标题栏.TabStop = False
        Me.GroupBox标题栏.Text = "标题栏"
        '
        'lvw标题栏对应表
        '
        Me.lvw标题栏对应表.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvw标题栏对应表.FullRowSelect = True
        Me.lvw标题栏对应表.HideSelection = False
        Me.lvw标题栏对应表.Location = New System.Drawing.Point(21, 54)
        Me.lvw标题栏对应表.Name = "lvw标题栏对应表"
        Me.lvw标题栏对应表.Size = New System.Drawing.Size(262, 126)
        Me.lvw标题栏对应表.TabIndex = 5
        Me.lvw标题栏对应表.UseCompatibleStateImageBehavior = False
        Me.lvw标题栏对应表.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "旧标题栏"
        Me.ColumnHeader1.Width = 120
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "新标题栏"
        Me.ColumnHeader2.Width = 120
        '
        'cmb新标题栏
        '
        Me.cmb新标题栏.FormattingEnabled = True
        Me.cmb新标题栏.Location = New System.Drawing.Point(158, 20)
        Me.cmb新标题栏.Name = "cmb新标题栏"
        Me.cmb新标题栏.Size = New System.Drawing.Size(125, 20)
        Me.cmb新标题栏.TabIndex = 2
        '
        'cmb旧标题栏
        '
        Me.cmb旧标题栏.FormattingEnabled = True
        Me.cmb旧标题栏.Location = New System.Drawing.Point(15, 20)
        Me.cmb旧标题栏.Name = "cmb旧标题栏"
        Me.cmb旧标题栏.Size = New System.Drawing.Size(125, 20)
        Me.cmb旧标题栏.TabIndex = 1
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.文件ToolStripMenuItem, Me.列表ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(332, 25)
        Me.MenuStrip1.TabIndex = 6
        '
        '文件ToolStripMenuItem
        '
        Me.文件ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.打开旧模板ToolStripMenuItem, Me.打开新模板ToolStripMenuItem, Me.保存配置ToolStripMenuItem, Me.打开配置文件ToolStripMenuItem})
        Me.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem"
        Me.文件ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.文件ToolStripMenuItem.Text = "文件"
        '
        '打开旧模板ToolStripMenuItem
        '
        Me.打开旧模板ToolStripMenuItem.Name = "打开旧模板ToolStripMenuItem"
        Me.打开旧模板ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.打开旧模板ToolStripMenuItem.Text = "打开旧模板"
        '
        '打开新模板ToolStripMenuItem
        '
        Me.打开新模板ToolStripMenuItem.Name = "打开新模板ToolStripMenuItem"
        Me.打开新模板ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.打开新模板ToolStripMenuItem.Text = "打开新模板"
        '
        '保存配置ToolStripMenuItem
        '
        Me.保存配置ToolStripMenuItem.Name = "保存配置ToolStripMenuItem"
        Me.保存配置ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.保存配置ToolStripMenuItem.Text = "保存配置"
        '
        '打开配置文件ToolStripMenuItem
        '
        Me.打开配置文件ToolStripMenuItem.Name = "打开配置文件ToolStripMenuItem"
        Me.打开配置文件ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.打开配置文件ToolStripMenuItem.Text = "打开配置文件"
        '
        '列表ToolStripMenuItem
        '
        Me.列表ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.添加ToolStripMenuItem, Me.删除ToolStripMenuItem})
        Me.列表ToolStripMenuItem.Name = "列表ToolStripMenuItem"
        Me.列表ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.列表ToolStripMenuItem.Text = "列表"
        '
        '添加ToolStripMenuItem
        '
        Me.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem"
        Me.添加ToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.添加ToolStripMenuItem.Text = "添加"
        '
        '删除ToolStripMenuItem
        '
        Me.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem"
        Me.删除ToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.删除ToolStripMenuItem.Text = "删除"
        '
        'FormBorderTitle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 312)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.GroupBox标题栏)
        Me.Controls.Add(Me.GroupBox边框)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FormBorderTitle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "图框标题栏"
        Me.GroupBox边框.ResumeLayout(False)
        Me.GroupBox标题栏.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmb边框 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox边框 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox标题栏 As System.Windows.Forms.GroupBox
    Friend WithEvents cmb旧标题栏 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb新标题栏 As System.Windows.Forms.ComboBox
    Friend WithEvents lvw标题栏对应表 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents 文件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 打开旧模板ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 打开新模板ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 列表ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 添加ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 删除ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 保存配置ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 打开配置文件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
