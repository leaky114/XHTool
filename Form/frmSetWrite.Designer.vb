<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetWrite
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
        Me.btn载入当前部件 = New System.Windows.Forms.Button()
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.cms文件列表右键菜单 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.列表读写tsmi = New System.Windows.Forms.ToolStripMenuItem()
        Me.列表全部只读tsmi = New System.Windows.Forms.ToolStripMenuItem()
        Me.列表全部可写tsmi = New System.Windows.Forms.ToolStripMenuItem()
        Me.列表打开tsmi = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.TreeV文件树 = New System.Windows.Forms.TreeView()
        Me.cms文件树右键菜单 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.树读写tsmi = New System.Windows.Forms.ToolStripMenuItem()
        Me.树全部只读tsmi = New System.Windows.Forms.ToolStripMenuItem()
        Me.树全部可写tsmi = New System.Windows.Forms.ToolStripMenuItem()
        Me.树打开tsmi = New System.Windows.Forms.ToolStripMenuItem()
        Me.树全部展开tsmi = New System.Windows.Forms.ToolStripMenuItem()
        Me.树全部收拢tsmi = New System.Windows.Forms.ToolStripMenuItem()
        Me.树清空tsmi = New System.Windows.Forms.ToolStripMenuItem()
        Me.Lvw文件列表 = New System.Windows.Forms.ListView()
        Me.ColumnHeader文件名 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader文件路径 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chk隐藏工程图 = New System.Windows.Forms.CheckBox()
        Me.cbo筛选文件 = New System.Windows.Forms.ComboBox()
        Me.cms文件列表右键菜单.SuspendLayout()
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        Me.cms文件树右键菜单.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn载入当前部件
        '
        Me.btn载入当前部件.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn载入当前部件.Location = New System.Drawing.Point(8, 460)
        Me.btn载入当前部件.Name = "btn载入当前部件"
        Me.btn载入当前部件.Size = New System.Drawing.Size(110, 28)
        Me.btn载入当前部件.TabIndex = 10
        Me.btn载入当前部件.Text = "载入当前部件"
        Me.btn载入当前部件.UseVisualStyleBackColor = True
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(905, 455)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(69, 28)
        Me.btn关闭.TabIndex = 12
        Me.btn关闭.Text = "关闭"
        '
        'cms文件列表右键菜单
        '
        Me.cms文件列表右键菜单.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.列表读写tsmi, Me.列表全部只读tsmi, Me.列表全部可写tsmi, Me.列表打开tsmi})
        Me.cms文件列表右键菜单.Name = "cmsRemove"
        Me.cms文件列表右键菜单.Size = New System.Drawing.Size(125, 92)
        '
        '列表读写tsmi
        '
        Me.列表读写tsmi.Name = "列表读写tsmi"
        Me.列表读写tsmi.Size = New System.Drawing.Size(124, 22)
        Me.列表读写tsmi.Text = "读-写"
        Me.列表读写tsmi.ToolTipText = "设置选择的文件读-写"
        '
        '列表全部只读tsmi
        '
        Me.列表全部只读tsmi.Name = "列表全部只读tsmi"
        Me.列表全部只读tsmi.Size = New System.Drawing.Size(124, 22)
        Me.列表全部只读tsmi.Text = "全部只读"
        Me.列表全部只读tsmi.ToolTipText = "设置列表文件全部只读"
        '
        '列表全部可写tsmi
        '
        Me.列表全部可写tsmi.Name = "列表全部可写tsmi"
        Me.列表全部可写tsmi.Size = New System.Drawing.Size(124, 22)
        Me.列表全部可写tsmi.Text = "全部可写"
        Me.列表全部可写tsmi.ToolTipText = "设置列表文件全部可写"
        '
        '列表打开tsmi
        '
        Me.列表打开tsmi.Name = "列表打开tsmi"
        Me.列表打开tsmi.Size = New System.Drawing.Size(124, 22)
        Me.列表打开tsmi.Text = "打开"
        Me.列表打开tsmi.ToolTipText = "打开选择的文件"
        '
        'SplitContainer
        '
        Me.SplitContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer.Location = New System.Drawing.Point(8, 8)
        Me.SplitContainer.Name = "SplitContainer"
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.Controls.Add(Me.TreeV文件树)
        Me.SplitContainer.Panel1MinSize = 50
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(Me.Lvw文件列表)
        Me.SplitContainer.Panel2MinSize = 50
        Me.SplitContainer.Size = New System.Drawing.Size(966, 441)
        Me.SplitContainer.SplitterDistance = 250
        Me.SplitContainer.TabIndex = 13
        Me.SplitContainer.Text = "SplitContainer1"
        '
        'TreeV文件树
        '
        Me.TreeV文件树.ContextMenuStrip = Me.cms文件树右键菜单
        Me.TreeV文件树.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeV文件树.Location = New System.Drawing.Point(0, 0)
        Me.TreeV文件树.Name = "TreeV文件树"
        Me.TreeV文件树.ShowNodeToolTips = True
        Me.TreeV文件树.Size = New System.Drawing.Size(250, 441)
        Me.TreeV文件树.TabIndex = 0
        '
        'cms文件树右键菜单
        '
        Me.cms文件树右键菜单.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.树读写tsmi, Me.树全部只读tsmi, Me.树全部可写tsmi, Me.树打开tsmi, Me.树全部展开tsmi, Me.树全部收拢tsmi, Me.树清空tsmi})
        Me.cms文件树右键菜单.Name = "cmsRemove"
        Me.cms文件树右键菜单.Size = New System.Drawing.Size(125, 158)
        '
        '树读写tsmi
        '
        Me.树读写tsmi.Name = "树读写tsmi"
        Me.树读写tsmi.Size = New System.Drawing.Size(124, 22)
        Me.树读写tsmi.Text = "读-写"
        Me.树读写tsmi.ToolTipText = "设置选择的文件读-写"
        '
        '树全部只读tsmi
        '
        Me.树全部只读tsmi.Name = "树全部只读tsmi"
        Me.树全部只读tsmi.Size = New System.Drawing.Size(124, 22)
        Me.树全部只读tsmi.Text = "全部只读"
        Me.树全部只读tsmi.ToolTipText = "设置列表文件全部只读"
        '
        '树全部可写tsmi
        '
        Me.树全部可写tsmi.Name = "树全部可写tsmi"
        Me.树全部可写tsmi.Size = New System.Drawing.Size(124, 22)
        Me.树全部可写tsmi.Text = "全部可写"
        Me.树全部可写tsmi.ToolTipText = "设置列表文件全部可写"
        '
        '树打开tsmi
        '
        Me.树打开tsmi.Name = "树打开tsmi"
        Me.树打开tsmi.Size = New System.Drawing.Size(124, 22)
        Me.树打开tsmi.Text = "打开"
        Me.树打开tsmi.ToolTipText = "打开选择的文件"
        '
        '树全部展开tsmi
        '
        Me.树全部展开tsmi.Name = "树全部展开tsmi"
        Me.树全部展开tsmi.Size = New System.Drawing.Size(124, 22)
        Me.树全部展开tsmi.Text = "全部展开"
        '
        '树全部收拢tsmi
        '
        Me.树全部收拢tsmi.Name = "树全部收拢tsmi"
        Me.树全部收拢tsmi.Size = New System.Drawing.Size(124, 22)
        Me.树全部收拢tsmi.Text = "全部收拢"
        '
        '树清空tsmi
        '
        Me.树清空tsmi.Name = "树清空tsmi"
        Me.树清空tsmi.Size = New System.Drawing.Size(124, 22)
        Me.树清空tsmi.Text = "清空"
        '
        'Lvw文件列表
        '
        Me.Lvw文件列表.AllowColumnReorder = True
        Me.Lvw文件列表.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lvw文件列表.AutoArrange = False
        Me.Lvw文件列表.BackColor = System.Drawing.SystemColors.Window
        Me.Lvw文件列表.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader文件名, Me.ColumnHeader文件路径})
        Me.Lvw文件列表.ContextMenuStrip = Me.cms文件列表右键菜单
        Me.Lvw文件列表.FullRowSelect = True
        Me.Lvw文件列表.GridLines = True
        Me.Lvw文件列表.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.Lvw文件列表.Location = New System.Drawing.Point(1, 0)
        Me.Lvw文件列表.Name = "Lvw文件列表"
        Me.Lvw文件列表.Size = New System.Drawing.Size(706, 441)
        Me.Lvw文件列表.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.Lvw文件列表.TabIndex = 45
        Me.Lvw文件列表.TabStop = False
        Me.Lvw文件列表.UseCompatibleStateImageBehavior = False
        Me.Lvw文件列表.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader文件名
        '
        Me.ColumnHeader文件名.Text = "文件名"
        Me.ColumnHeader文件名.Width = 300
        '
        'ColumnHeader文件路径
        '
        Me.ColumnHeader文件路径.Text = "文件路径"
        Me.ColumnHeader文件路径.Width = 350
        '
        'chk隐藏工程图
        '
        Me.chk隐藏工程图.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chk隐藏工程图.AutoSize = True
        Me.chk隐藏工程图.Location = New System.Drawing.Point(274, 467)
        Me.chk隐藏工程图.Name = "chk隐藏工程图"
        Me.chk隐藏工程图.Size = New System.Drawing.Size(84, 16)
        Me.chk隐藏工程图.TabIndex = 14
        Me.chk隐藏工程图.Text = "隐藏工程图"
        Me.chk隐藏工程图.UseVisualStyleBackColor = True
        '
        'cbo筛选文件
        '
        Me.cbo筛选文件.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbo筛选文件.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo筛选文件.FormattingEnabled = True
        Me.cbo筛选文件.Items.AddRange(New Object() {"全部文件", "只读文件", "可写文件"})
        Me.cbo筛选文件.Location = New System.Drawing.Point(137, 463)
        Me.cbo筛选文件.Name = "cbo筛选文件"
        Me.cbo筛选文件.Size = New System.Drawing.Size(106, 20)
        Me.cbo筛选文件.TabIndex = 35
        '
        'frmSetWrite
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn关闭
        Me.ClientSize = New System.Drawing.Size(986, 495)
        Me.Controls.Add(Me.cbo筛选文件)
        Me.Controls.Add(Me.chk隐藏工程图)
        Me.Controls.Add(Me.SplitContainer)
        Me.Controls.Add(Me.btn载入当前部件)
        Me.Controls.Add(Me.btn关闭)
        Me.Name = "frmSetWrite"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "设置只读"
        Me.cms文件列表右键菜单.ResumeLayout(False)
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer.ResumeLayout(False)
        Me.cms文件树右键菜单.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn载入当前部件 As System.Windows.Forms.Button
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents cms文件列表右键菜单 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents 列表读写tsmi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents TreeV文件树 As System.Windows.Forms.TreeView
    Friend WithEvents Lvw文件列表 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader文件名 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader文件路径 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cms文件树右键菜单 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents 树全部展开tsmi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 树全部收拢tsmi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chk隐藏工程图 As System.Windows.Forms.CheckBox
    Friend WithEvents cbo筛选文件 As System.Windows.Forms.ComboBox
    Friend WithEvents 列表打开tsmi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 树打开tsmi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 树清空tsmi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 列表全部只读tsmi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 树读写tsmi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 树全部只读tsmi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 列表全部可写tsmi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 树全部可写tsmi As System.Windows.Forms.ToolStripMenuItem
End Class
