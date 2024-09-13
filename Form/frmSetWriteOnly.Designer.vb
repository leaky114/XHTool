<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetWriteOnly
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
        Me.lvw文件列表 = New System.Windows.Forms.ListView()
        Me.ColumnHeader文件名 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader属性 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader模型路径 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader工程图 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader工程图属性 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader工程图路径 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cms右键菜单 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.读写tsmi = New System.Windows.Forms.ToolStripMenuItem()
        Me.移出tsmi = New System.Windows.Forms.ToolStripMenuItem()
        Me.清空tsmi = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn移出 = New System.Windows.Forms.Button()
        Me.btn清空 = New System.Windows.Forms.Button()
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.btn设置 = New System.Windows.Forms.Button()
        Me.btn导入当前部件 = New System.Windows.Forms.Button()
        Me.CheckBox全选 = New System.Windows.Forms.CheckBox()
        Me.CheckBox只读 = New System.Windows.Forms.CheckBox()
        Me.CheckBox模型 = New System.Windows.Forms.CheckBox()
        Me.CheckBox工程图 = New System.Windows.Forms.CheckBox()
        Me.CheckBox本部件 = New System.Windows.Forms.CheckBox()
        Me.cms右键菜单.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvw文件列表
        '
        Me.lvw文件列表.AllowColumnReorder = True
        Me.lvw文件列表.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvw文件列表.AutoArrange = False
        Me.lvw文件列表.BackColor = System.Drawing.SystemColors.Window
        Me.lvw文件列表.CheckBoxes = True
        Me.lvw文件列表.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader文件名, Me.ColumnHeader属性, Me.ColumnHeader模型路径, Me.ColumnHeader工程图, Me.ColumnHeader工程图属性, Me.ColumnHeader工程图路径})
        Me.lvw文件列表.ContextMenuStrip = Me.cms右键菜单
        Me.lvw文件列表.FullRowSelect = True
        Me.lvw文件列表.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvw文件列表.Location = New System.Drawing.Point(17, 13)
        Me.lvw文件列表.Name = "lvw文件列表"
        Me.lvw文件列表.Size = New System.Drawing.Size(1055, 381)
        Me.lvw文件列表.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvw文件列表.TabIndex = 44
        Me.lvw文件列表.TabStop = False
        Me.lvw文件列表.UseCompatibleStateImageBehavior = False
        Me.lvw文件列表.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader文件名
        '
        Me.ColumnHeader文件名.Text = "文件名"
        Me.ColumnHeader文件名.Width = 250
        '
        'ColumnHeader属性
        '
        Me.ColumnHeader属性.Text = "只读"
        '
        'ColumnHeader模型路径
        '
        Me.ColumnHeader模型路径.Text = "模型路径"
        Me.ColumnHeader模型路径.Width = 209
        '
        'ColumnHeader工程图
        '
        Me.ColumnHeader工程图.Text = "工程图"
        Me.ColumnHeader工程图.Width = 250
        '
        'ColumnHeader工程图属性
        '
        Me.ColumnHeader工程图属性.Text = "只读"
        '
        'ColumnHeader工程图路径
        '
        Me.ColumnHeader工程图路径.Text = "工程图路径"
        Me.ColumnHeader工程图路径.Width = 220
        '
        'cms右键菜单
        '
        Me.cms右键菜单.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.读写tsmi, Me.移出tsmi, Me.清空tsmi})
        Me.cms右键菜单.Name = "cmsRemove"
        Me.cms右键菜单.Size = New System.Drawing.Size(106, 70)
        '
        '读写tsmi
        '
        Me.读写tsmi.Name = "读写tsmi"
        Me.读写tsmi.Size = New System.Drawing.Size(105, 22)
        Me.读写tsmi.Text = "读-写"
        '
        '移出tsmi
        '
        Me.移出tsmi.Name = "移出tsmi"
        Me.移出tsmi.Size = New System.Drawing.Size(105, 22)
        Me.移出tsmi.Text = "移出"
        '
        '清空tsmi
        '
        Me.清空tsmi.Name = "清空tsmi"
        Me.清空tsmi.Size = New System.Drawing.Size(105, 22)
        Me.清空tsmi.Text = "清空"
        '
        'btn移出
        '
        Me.btn移出.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn移出.Location = New System.Drawing.Point(212, 418)
        Me.btn移出.Name = "btn移出"
        Me.btn移出.Size = New System.Drawing.Size(69, 28)
        Me.btn移出.TabIndex = 2
        Me.btn移出.Text = "移除"
        Me.btn移出.UseVisualStyleBackColor = True
        '
        'btn清空
        '
        Me.btn清空.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn清空.Location = New System.Drawing.Point(135, 418)
        Me.btn清空.Name = "btn清空"
        Me.btn清空.Size = New System.Drawing.Size(69, 28)
        Me.btn清空.TabIndex = 1
        Me.btn清空.Text = "清空"
        Me.btn清空.UseVisualStyleBackColor = True
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(1001, 418)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(69, 28)
        Me.btn关闭.TabIndex = 9
        Me.btn关闭.Text = "关闭"
        '
        'btn设置
        '
        Me.btn设置.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn设置.Location = New System.Drawing.Point(924, 418)
        Me.btn设置.Name = "btn设置"
        Me.btn设置.Size = New System.Drawing.Size(69, 28)
        Me.btn设置.TabIndex = 8
        Me.btn设置.Text = "设置"
        '
        'btn导入当前部件
        '
        Me.btn导入当前部件.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn导入当前部件.Location = New System.Drawing.Point(17, 418)
        Me.btn导入当前部件.Name = "btn导入当前部件"
        Me.btn导入当前部件.Size = New System.Drawing.Size(110, 28)
        Me.btn导入当前部件.TabIndex = 0
        Me.btn导入当前部件.Text = "导入当前部件"
        Me.btn导入当前部件.UseVisualStyleBackColor = True
        '
        'CheckBox全选
        '
        Me.CheckBox全选.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox全选.AutoSize = True
        Me.CheckBox全选.Checked = True
        Me.CheckBox全选.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox全选.Location = New System.Drawing.Point(304, 424)
        Me.CheckBox全选.Name = "CheckBox全选"
        Me.CheckBox全选.Size = New System.Drawing.Size(48, 16)
        Me.CheckBox全选.TabIndex = 3
        Me.CheckBox全选.Text = "全选"
        Me.CheckBox全选.UseVisualStyleBackColor = True
        '
        'CheckBox只读
        '
        Me.CheckBox只读.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox只读.AutoSize = True
        Me.CheckBox只读.Checked = True
        Me.CheckBox只读.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox只读.Location = New System.Drawing.Point(360, 424)
        Me.CheckBox只读.Name = "CheckBox只读"
        Me.CheckBox只读.Size = New System.Drawing.Size(48, 16)
        Me.CheckBox只读.TabIndex = 4
        Me.CheckBox只读.Text = "只读"
        Me.CheckBox只读.UseVisualStyleBackColor = True
        '
        'CheckBox模型
        '
        Me.CheckBox模型.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox模型.AutoSize = True
        Me.CheckBox模型.Checked = True
        Me.CheckBox模型.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox模型.Location = New System.Drawing.Point(416, 424)
        Me.CheckBox模型.Name = "CheckBox模型"
        Me.CheckBox模型.Size = New System.Drawing.Size(48, 16)
        Me.CheckBox模型.TabIndex = 5
        Me.CheckBox模型.Text = "模型"
        Me.CheckBox模型.UseVisualStyleBackColor = True
        '
        'CheckBox工程图
        '
        Me.CheckBox工程图.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox工程图.AutoSize = True
        Me.CheckBox工程图.Checked = True
        Me.CheckBox工程图.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox工程图.Location = New System.Drawing.Point(472, 424)
        Me.CheckBox工程图.Name = "CheckBox工程图"
        Me.CheckBox工程图.Size = New System.Drawing.Size(60, 16)
        Me.CheckBox工程图.TabIndex = 6
        Me.CheckBox工程图.Text = "工程图"
        Me.CheckBox工程图.UseVisualStyleBackColor = True
        '
        'CheckBox本部件
        '
        Me.CheckBox本部件.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox本部件.AutoSize = True
        Me.CheckBox本部件.Location = New System.Drawing.Point(852, 424)
        Me.CheckBox本部件.Name = "CheckBox本部件"
        Me.CheckBox本部件.Size = New System.Drawing.Size(60, 16)
        Me.CheckBox本部件.TabIndex = 7
        Me.CheckBox本部件.Text = "本部件"
        Me.CheckBox本部件.UseVisualStyleBackColor = True
        '
        'frmSetWriteOnly
        '
        Me.AcceptButton = Me.btn设置
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn关闭
        Me.ClientSize = New System.Drawing.Size(1084, 458)
        Me.Controls.Add(Me.CheckBox本部件)
        Me.Controls.Add(Me.CheckBox工程图)
        Me.Controls.Add(Me.CheckBox模型)
        Me.Controls.Add(Me.CheckBox只读)
        Me.Controls.Add(Me.CheckBox全选)
        Me.Controls.Add(Me.btn导入当前部件)
        Me.Controls.Add(Me.lvw文件列表)
        Me.Controls.Add(Me.btn移出)
        Me.Controls.Add(Me.btn清空)
        Me.Controls.Add(Me.btn关闭)
        Me.Controls.Add(Me.btn设置)
        Me.Name = "frmSetWriteOnly"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "批量只读"
        Me.TopMost = True
        Me.cms右键菜单.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ColumnHeader文件名 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn移出 As System.Windows.Forms.Button
    Friend WithEvents btn清空 As System.Windows.Forms.Button
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents btn设置 As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader属性 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader模型路径 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn导入当前部件 As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader工程图 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader工程图属性 As System.Windows.Forms.ColumnHeader
    Friend WithEvents CheckBox全选 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox只读 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox模型 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox工程图 As System.Windows.Forms.CheckBox
    Friend WithEvents ColumnHeader工程图路径 As System.Windows.Forms.ColumnHeader
    Friend WithEvents CheckBox本部件 As System.Windows.Forms.CheckBox
    Friend WithEvents cms右键菜单 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents 移出tsmi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 清空tsmi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lvw文件列表 As System.Windows.Forms.ListView
    Friend WithEvents 读写tsmi As System.Windows.Forms.ToolStripMenuItem
End Class
