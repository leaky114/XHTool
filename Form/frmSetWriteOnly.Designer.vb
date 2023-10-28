<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetWriteOnly
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
        Me.lvw文件列表 = New System.Windows.Forms.ListView()
        Me.ColumnHeader文件名 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader属性 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader模型路径 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader工程图 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader工程图属性 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader工程图路径 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btn移出 = New System.Windows.Forms.Button()
        Me.btn清空列表 = New System.Windows.Forms.Button()
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.btn开始 = New System.Windows.Forms.Button()
        Me.btn导入当前部件 = New System.Windows.Forms.Button()
        Me.CheckBox全选 = New System.Windows.Forms.CheckBox()
        Me.CheckBox只读 = New System.Windows.Forms.CheckBox()
        Me.CheckBox模型 = New System.Windows.Forms.CheckBox()
        Me.CheckBox工程图 = New System.Windows.Forms.CheckBox()
        Me.CheckBox本部件 = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'lvw文件列表
        '
        Me.lvw文件列表.AllowColumnReorder = True
        Me.lvw文件列表.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvw文件列表.AutoArrange = False
        Me.lvw文件列表.CheckBoxes = True
        Me.lvw文件列表.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader文件名, Me.ColumnHeader属性, Me.ColumnHeader模型路径, Me.ColumnHeader工程图, Me.ColumnHeader工程图属性, Me.ColumnHeader工程图路径})
        Me.lvw文件列表.FullRowSelect = True
        Me.lvw文件列表.Location = New System.Drawing.Point(17, 13)
        Me.lvw文件列表.Name = "lvw文件列表"
        Me.lvw文件列表.Size = New System.Drawing.Size(1038, 324)
        Me.lvw文件列表.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvw文件列表.TabIndex = 44
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
        'btn移出
        '
        Me.btn移出.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn移出.Location = New System.Drawing.Point(212, 361)
        Me.btn移出.Name = "btn移出"
        Me.btn移出.Size = New System.Drawing.Size(69, 28)
        Me.btn移出.TabIndex = 43
        Me.btn移出.Text = "移除"
        Me.btn移出.UseVisualStyleBackColor = True
        '
        'btn清空列表
        '
        Me.btn清空列表.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn清空列表.Location = New System.Drawing.Point(135, 361)
        Me.btn清空列表.Name = "btn清空列表"
        Me.btn清空列表.Size = New System.Drawing.Size(69, 28)
        Me.btn清空列表.TabIndex = 41
        Me.btn清空列表.Text = "清空列表"
        Me.btn清空列表.UseVisualStyleBackColor = True
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(998, 361)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(57, 28)
        Me.btn关闭.TabIndex = 39
        Me.btn关闭.Text = "关闭"
        '
        'btn开始
        '
        Me.btn开始.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn开始.Location = New System.Drawing.Point(935, 361)
        Me.btn开始.Name = "btn开始"
        Me.btn开始.Size = New System.Drawing.Size(57, 28)
        Me.btn开始.TabIndex = 40
        Me.btn开始.Text = "开始"
        '
        'btn导入当前部件
        '
        Me.btn导入当前部件.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn导入当前部件.Location = New System.Drawing.Point(17, 361)
        Me.btn导入当前部件.Name = "btn导入当前部件"
        Me.btn导入当前部件.Size = New System.Drawing.Size(110, 28)
        Me.btn导入当前部件.TabIndex = 45
        Me.btn导入当前部件.Text = "导入当前部件"
        Me.btn导入当前部件.UseVisualStyleBackColor = True
        '
        'CheckBox全选
        '
        Me.CheckBox全选.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox全选.AutoSize = True
        Me.CheckBox全选.Location = New System.Drawing.Point(304, 367)
        Me.CheckBox全选.Name = "CheckBox全选"
        Me.CheckBox全选.Size = New System.Drawing.Size(48, 16)
        Me.CheckBox全选.TabIndex = 46
        Me.CheckBox全选.Text = "全选"
        Me.CheckBox全选.UseVisualStyleBackColor = True
        '
        'CheckBox只读
        '
        Me.CheckBox只读.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox只读.AutoSize = True
        Me.CheckBox只读.Location = New System.Drawing.Point(360, 367)
        Me.CheckBox只读.Name = "CheckBox只读"
        Me.CheckBox只读.Size = New System.Drawing.Size(48, 16)
        Me.CheckBox只读.TabIndex = 47
        Me.CheckBox只读.Text = "只读"
        Me.CheckBox只读.UseVisualStyleBackColor = True
        '
        'CheckBox模型
        '
        Me.CheckBox模型.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox模型.AutoSize = True
        Me.CheckBox模型.Location = New System.Drawing.Point(416, 367)
        Me.CheckBox模型.Name = "CheckBox模型"
        Me.CheckBox模型.Size = New System.Drawing.Size(48, 16)
        Me.CheckBox模型.TabIndex = 48
        Me.CheckBox模型.Text = "模型"
        Me.CheckBox模型.UseVisualStyleBackColor = True
        '
        'CheckBox工程图
        '
        Me.CheckBox工程图.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox工程图.AutoSize = True
        Me.CheckBox工程图.Location = New System.Drawing.Point(472, 367)
        Me.CheckBox工程图.Name = "CheckBox工程图"
        Me.CheckBox工程图.Size = New System.Drawing.Size(60, 16)
        Me.CheckBox工程图.TabIndex = 49
        Me.CheckBox工程图.Text = "工程图"
        Me.CheckBox工程图.UseVisualStyleBackColor = True
        '
        'CheckBox本部件
        '
        Me.CheckBox本部件.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox本部件.AutoSize = True
        Me.CheckBox本部件.Location = New System.Drawing.Point(855, 367)
        Me.CheckBox本部件.Name = "CheckBox本部件"
        Me.CheckBox本部件.Size = New System.Drawing.Size(60, 16)
        Me.CheckBox本部件.TabIndex = 50
        Me.CheckBox本部件.Text = "本部件"
        Me.CheckBox本部件.UseVisualStyleBackColor = True
        '
        'frmSetWriteOnly
        '
        Me.AcceptButton = Me.btn开始
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn关闭
        Me.ClientSize = New System.Drawing.Size(1067, 401)
        Me.Controls.Add(Me.CheckBox本部件)
        Me.Controls.Add(Me.CheckBox工程图)
        Me.Controls.Add(Me.CheckBox模型)
        Me.Controls.Add(Me.CheckBox只读)
        Me.Controls.Add(Me.CheckBox全选)
        Me.Controls.Add(Me.btn导入当前部件)
        Me.Controls.Add(Me.lvw文件列表)
        Me.Controls.Add(Me.btn移出)
        Me.Controls.Add(Me.btn清空列表)
        Me.Controls.Add(Me.btn关闭)
        Me.Controls.Add(Me.btn开始)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSetWriteOnly"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "批量只读"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvw文件列表 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader文件名 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn移出 As System.Windows.Forms.Button
    Friend WithEvents btn清空列表 As System.Windows.Forms.Button
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents btn开始 As System.Windows.Forms.Button
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
End Class
