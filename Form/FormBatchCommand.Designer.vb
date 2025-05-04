Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBatchCommand
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lvw文件列表 = New System.Windows.Forms.ListView()
        Me.ColumnHeader文件名 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.清空列表ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.已打开文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.当前部件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.添加文件夹ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.添加文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.转换为钣金ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.转换为零件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.创建展开ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.获取钣金厚度ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.lvw文件列表.FullRowSelect = True
        Me.lvw文件列表.HideSelection = False
        Me.lvw文件列表.Location = New System.Drawing.Point(113, 12)
        Me.lvw文件列表.Name = "lvw文件列表"
        Me.lvw文件列表.Size = New System.Drawing.Size(634, 342)
        Me.lvw文件列表.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvw文件列表.TabIndex = 37
        Me.lvw文件列表.UseCompatibleStateImageBehavior = False
        Me.lvw文件列表.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader文件名
        '
        Me.ColumnHeader文件名.Text = "文件名(双击打开)"
        Me.ColumnHeader文件名.Width = 600
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MenuStrip1.GripMargin = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.清空列表ToolStripMenuItem, Me.已打开文件ToolStripMenuItem, Me.当前部件ToolStripMenuItem, Me.添加文件夹ToolStripMenuItem, Me.添加文件ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(99, 370)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.MenuStrip1.Size = New System.Drawing.Size(660, 25)
        Me.MenuStrip1.TabIndex = 38
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '清空列表ToolStripMenuItem
        '
        Me.清空列表ToolStripMenuItem.Name = "清空列表ToolStripMenuItem"
        Me.清空列表ToolStripMenuItem.Size = New System.Drawing.Size(68, 21)
        Me.清空列表ToolStripMenuItem.Text = "清空列表"
        '
        '已打开文件ToolStripMenuItem
        '
        Me.已打开文件ToolStripMenuItem.Name = "已打开文件ToolStripMenuItem"
        Me.已打开文件ToolStripMenuItem.Size = New System.Drawing.Size(80, 21)
        Me.已打开文件ToolStripMenuItem.Text = "已打开文件"
        Me.已打开文件ToolStripMenuItem.ToolTipText = "导入已打开文件。"
        '
        '当前部件ToolStripMenuItem
        '
        Me.当前部件ToolStripMenuItem.Name = "当前部件ToolStripMenuItem"
        Me.当前部件ToolStripMenuItem.Size = New System.Drawing.Size(68, 21)
        Me.当前部件ToolStripMenuItem.Text = "当前部件"
        Me.当前部件ToolStripMenuItem.ToolTipText = "导入当前部件。"
        '
        '添加文件夹ToolStripMenuItem
        '
        Me.添加文件夹ToolStripMenuItem.Name = "添加文件夹ToolStripMenuItem"
        Me.添加文件夹ToolStripMenuItem.Size = New System.Drawing.Size(80, 21)
        Me.添加文件夹ToolStripMenuItem.Text = "添加文件夹"
        '
        '添加文件ToolStripMenuItem
        '
        Me.添加文件ToolStripMenuItem.Name = "添加文件ToolStripMenuItem"
        Me.添加文件ToolStripMenuItem.Size = New System.Drawing.Size(68, 21)
        Me.添加文件ToolStripMenuItem.Text = "添加文件"
        '
        'MenuStrip2
        '
        Me.MenuStrip2.AutoSize = False
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Left
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.转换为钣金ToolStripMenuItem, Me.转换为零件ToolStripMenuItem, Me.创建展开ToolStripMenuItem, Me.获取钣金厚度ToolStripMenuItem})
        Me.MenuStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Padding = New System.Windows.Forms.Padding(0)
        Me.MenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip2.Size = New System.Drawing.Size(99, 395)
        Me.MenuStrip2.TabIndex = 39
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        '转换为钣金ToolStripMenuItem
        '
        Me.转换为钣金ToolStripMenuItem.Name = "转换为钣金ToolStripMenuItem"
        Me.转换为钣金ToolStripMenuItem.Size = New System.Drawing.Size(80, 21)
        Me.转换为钣金ToolStripMenuItem.Text = "转换为钣金"
        '
        '转换为零件ToolStripMenuItem
        '
        Me.转换为零件ToolStripMenuItem.Name = "转换为零件ToolStripMenuItem"
        Me.转换为零件ToolStripMenuItem.Size = New System.Drawing.Size(80, 21)
        Me.转换为零件ToolStripMenuItem.Text = "转换为零件"
        '
        '创建展开ToolStripMenuItem
        '
        Me.创建展开ToolStripMenuItem.Name = "创建展开ToolStripMenuItem"
        Me.创建展开ToolStripMenuItem.Size = New System.Drawing.Size(68, 21)
        Me.创建展开ToolStripMenuItem.Text = "创建展开"
        '
        '获取钣金厚度ToolStripMenuItem
        '
        Me.获取钣金厚度ToolStripMenuItem.Name = "获取钣金厚度ToolStripMenuItem"
        Me.获取钣金厚度ToolStripMenuItem.Size = New System.Drawing.Size(92, 21)
        Me.获取钣金厚度ToolStripMenuItem.Text = "获取钣金厚度"
        '
        'FormBatchCommand
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 395)
        Me.Controls.Add(Me.lvw文件列表)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.MenuStrip2)
        Me.MainMenuStrip = Me.MenuStrip2
        Me.Name = "FormBatchCommand"
        Me.Text = "FormBatchCommand"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvw文件列表 As ListView
    Friend WithEvents ColumnHeader文件名 As ColumnHeader
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 添加文件ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 添加文件夹ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 当前部件ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 已打开文件ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 清空列表ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents 转换为钣金ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 转换为零件ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 创建展开ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 获取钣金厚度ToolStripMenuItem As ToolStripMenuItem
End Class
