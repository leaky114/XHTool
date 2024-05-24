<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSaveAll
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
        Me.btn确定 = New System.Windows.Forms.Button()
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.grp文件类型 = New System.Windows.Forms.GroupBox()
        Me.chk工程图 = New System.Windows.Forms.CheckBox()
        Me.chk零件图 = New System.Windows.Forms.CheckBox()
        Me.chk部件 = New System.Windows.Forms.CheckBox()
        Me.rdo全部保存 = New System.Windows.Forms.RadioButton()
        Me.rdo全部保存并关闭 = New System.Windows.Forms.RadioButton()
        Me.rdo全部关闭 = New System.Windows.Forms.RadioButton()
        Me.grp执行操作 = New System.Windows.Forms.GroupBox()
        Me.grp文件类型.SuspendLayout()
        Me.grp执行操作.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn确定
        '
        Me.btn确定.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn确定.Location = New System.Drawing.Point(20, 245)
        Me.btn确定.Name = "btn确定"
        Me.btn确定.Size = New System.Drawing.Size(65, 28)
        Me.btn确定.TabIndex = 2
        Me.btn确定.Text = "确定"
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(93, 245)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(65, 28)
        Me.btn关闭.TabIndex = 3
        Me.btn关闭.Text = "关闭"
        '
        'grp文件类型
        '
        Me.grp文件类型.Controls.Add(Me.chk工程图)
        Me.grp文件类型.Controls.Add(Me.chk零件图)
        Me.grp文件类型.Controls.Add(Me.chk部件)
        Me.grp文件类型.Location = New System.Drawing.Point(22, 13)
        Me.grp文件类型.Name = "grp文件类型"
        Me.grp文件类型.Size = New System.Drawing.Size(135, 102)
        Me.grp文件类型.TabIndex = 0
        Me.grp文件类型.TabStop = False
        Me.grp文件类型.Text = "文件类型"
        '
        'chk工程图
        '
        Me.chk工程图.AutoSize = True
        Me.chk工程图.Checked = True
        Me.chk工程图.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk工程图.Location = New System.Drawing.Point(23, 71)
        Me.chk工程图.Name = "chk工程图"
        Me.chk工程图.Size = New System.Drawing.Size(60, 16)
        Me.chk工程图.TabIndex = 2
        Me.chk工程图.Text = "工程图"
        Me.chk工程图.UseVisualStyleBackColor = True
        '
        'chk零件图
        '
        Me.chk零件图.AutoSize = True
        Me.chk零件图.Checked = True
        Me.chk零件图.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk零件图.Location = New System.Drawing.Point(23, 44)
        Me.chk零件图.Name = "chk零件图"
        Me.chk零件图.Size = New System.Drawing.Size(48, 16)
        Me.chk零件图.TabIndex = 1
        Me.chk零件图.Text = "零件"
        Me.chk零件图.UseVisualStyleBackColor = True
        '
        'chk部件
        '
        Me.chk部件.AutoSize = True
        Me.chk部件.Checked = True
        Me.chk部件.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk部件.Location = New System.Drawing.Point(23, 17)
        Me.chk部件.Name = "chk部件"
        Me.chk部件.Size = New System.Drawing.Size(48, 16)
        Me.chk部件.TabIndex = 0
        Me.chk部件.Text = "部件"
        Me.chk部件.UseVisualStyleBackColor = True
        '
        'rdo全部保存
        '
        Me.rdo全部保存.AutoSize = True
        Me.rdo全部保存.Checked = True
        Me.rdo全部保存.Location = New System.Drawing.Point(23, 23)
        Me.rdo全部保存.Name = "rdo全部保存"
        Me.rdo全部保存.Size = New System.Drawing.Size(71, 16)
        Me.rdo全部保存.TabIndex = 0
        Me.rdo全部保存.TabStop = True
        Me.rdo全部保存.Text = "全部保存"
        Me.rdo全部保存.UseVisualStyleBackColor = True
        '
        'rdo全部保存并关闭
        '
        Me.rdo全部保存并关闭.AutoSize = True
        Me.rdo全部保存并关闭.Location = New System.Drawing.Point(23, 47)
        Me.rdo全部保存并关闭.Name = "rdo全部保存并关闭"
        Me.rdo全部保存并关闭.Size = New System.Drawing.Size(95, 16)
        Me.rdo全部保存并关闭.TabIndex = 1
        Me.rdo全部保存并关闭.TabStop = True
        Me.rdo全部保存并关闭.Text = "全部保存关闭"
        Me.rdo全部保存并关闭.UseVisualStyleBackColor = True
        '
        'rdo全部关闭
        '
        Me.rdo全部关闭.AutoSize = True
        Me.rdo全部关闭.Location = New System.Drawing.Point(23, 71)
        Me.rdo全部关闭.Name = "rdo全部关闭"
        Me.rdo全部关闭.Size = New System.Drawing.Size(71, 16)
        Me.rdo全部关闭.TabIndex = 2
        Me.rdo全部关闭.TabStop = True
        Me.rdo全部关闭.Text = "全部关闭"
        Me.rdo全部关闭.UseVisualStyleBackColor = True
        '
        'grp执行操作
        '
        Me.grp执行操作.Controls.Add(Me.rdo全部关闭)
        Me.grp执行操作.Controls.Add(Me.rdo全部保存并关闭)
        Me.grp执行操作.Controls.Add(Me.rdo全部保存)
        Me.grp执行操作.Location = New System.Drawing.Point(22, 125)
        Me.grp执行操作.Name = "grp执行操作"
        Me.grp执行操作.Size = New System.Drawing.Size(132, 103)
        Me.grp执行操作.TabIndex = 1
        Me.grp执行操作.TabStop = False
        Me.grp执行操作.Text = "执行操作"
        '
        'frmSaveAll
        '
        Me.AcceptButton = Me.btn确定
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn关闭
        Me.ClientSize = New System.Drawing.Size(172, 280)
        Me.Controls.Add(Me.btn确定)
        Me.Controls.Add(Me.btn关闭)
        Me.Controls.Add(Me.grp执行操作)
        Me.Controls.Add(Me.grp文件类型)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSaveAll"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "全部保存"
        Me.TopMost = True
        Me.grp文件类型.ResumeLayout(False)
        Me.grp文件类型.PerformLayout()
        Me.grp执行操作.ResumeLayout(False)
        Me.grp执行操作.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn确定 As System.Windows.Forms.Button
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents grp文件类型 As System.Windows.Forms.GroupBox
    Friend WithEvents chk零件图 As System.Windows.Forms.CheckBox
    Friend WithEvents chk部件 As System.Windows.Forms.CheckBox
    Friend WithEvents chk工程图 As System.Windows.Forms.CheckBox
    Friend WithEvents rdo全部保存 As System.Windows.Forms.RadioButton
    Friend WithEvents rdo全部保存并关闭 As System.Windows.Forms.RadioButton
    Friend WithEvents rdo全部关闭 As System.Windows.Forms.RadioButton
    Friend WithEvents grp执行操作 As System.Windows.Forms.GroupBox

End Class
