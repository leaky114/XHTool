<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlayer
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

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn添加 = New System.Windows.Forms.Button()
        Me.btn移出 = New System.Windows.Forms.Button()
        Me.lvw文件列表 = New System.Windows.Forms.ListView()
        Me.ch约束名称 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch抑制 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch开始 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch结束 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch步长 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch延时 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.btn清空 = New System.Windows.Forms.Button()
        Me.btn应用 = New System.Windows.Forms.Button()
        Me.txt开始 = New System.Windows.Forms.TextBox()
        Me.txt结束 = New System.Windows.Forms.TextBox()
        Me.txt步长 = New System.Windows.Forms.TextBox()
        Me.CheckBox抑制 = New System.Windows.Forms.CheckBox()
        Me.txt延时 = New System.Windows.Forms.TextBox()
        Me.btn确定编辑 = New System.Windows.Forms.Button()
        Me.btn预览 = New System.Windows.Forms.Button()
        Me.btn选择约束 = New System.Windows.Forms.Button()
        Me.ch运动 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'btn添加
        '
        Me.btn添加.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn添加.Location = New System.Drawing.Point(17, 336)
        Me.btn添加.Name = "btn添加"
        Me.btn添加.Size = New System.Drawing.Size(65, 28)
        Me.btn添加.TabIndex = 38
        Me.btn添加.TabStop = False
        Me.btn添加.Text = "添加"
        Me.btn添加.UseVisualStyleBackColor = True
        '
        'btn移出
        '
        Me.btn移出.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn移出.Location = New System.Drawing.Point(90, 336)
        Me.btn移出.Name = "btn移出"
        Me.btn移出.Size = New System.Drawing.Size(65, 28)
        Me.btn移出.TabIndex = 37
        Me.btn移出.Text = "移出"
        Me.btn移出.UseVisualStyleBackColor = True
        '
        'lvw文件列表
        '
        Me.lvw文件列表.AllowDrop = True
        Me.lvw文件列表.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvw文件列表.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ch约束名称, Me.ch抑制, Me.ch运动, Me.ch开始, Me.ch结束, Me.ch步长, Me.ch延时})
        Me.lvw文件列表.FullRowSelect = True
        Me.lvw文件列表.Location = New System.Drawing.Point(12, 55)
        Me.lvw文件列表.Name = "lvw文件列表"
        Me.lvw文件列表.Size = New System.Drawing.Size(632, 263)
        Me.lvw文件列表.TabIndex = 35
        Me.lvw文件列表.TabStop = False
        Me.lvw文件列表.UseCompatibleStateImageBehavior = False
        Me.lvw文件列表.View = System.Windows.Forms.View.Details
        '
        'ch约束名称
        '
        Me.ch约束名称.Text = "约束名称"
        Me.ch约束名称.Width = 120
        '
        'ch抑制
        '
        Me.ch抑制.Text = "抑制"
        Me.ch抑制.Width = 50
        '
        'ch开始
        '
        Me.ch开始.Text = "开始"
        Me.ch开始.Width = 100
        '
        'ch结束
        '
        Me.ch结束.Text = "结束"
        Me.ch结束.Width = 100
        '
        'ch步长
        '
        Me.ch步长.Text = "步长"
        Me.ch步长.Width = 100
        '
        'ch延时
        '
        Me.ch延时.Text = "延时(s)"
        Me.ch延时.Width = 100
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.AutoSize = True
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(578, 336)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(65, 28)
        Me.btn关闭.TabIndex = 34
        Me.btn关闭.Text = "关闭"
        '
        'btn清空
        '
        Me.btn清空.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn清空.Location = New System.Drawing.Point(163, 336)
        Me.btn清空.Name = "btn清空"
        Me.btn清空.Size = New System.Drawing.Size(65, 28)
        Me.btn清空.TabIndex = 39
        Me.btn清空.Text = "清空"
        Me.btn清空.UseVisualStyleBackColor = True
        '
        'btn应用
        '
        Me.btn应用.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn应用.AutoSize = True
        Me.btn应用.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn应用.Location = New System.Drawing.Point(496, 336)
        Me.btn应用.Name = "btn应用"
        Me.btn应用.Size = New System.Drawing.Size(65, 28)
        Me.btn应用.TabIndex = 40
        Me.btn应用.Text = "应用"
        '
        'txt开始
        '
        Me.txt开始.Location = New System.Drawing.Point(202, 19)
        Me.txt开始.Name = "txt开始"
        Me.txt开始.Size = New System.Drawing.Size(72, 21)
        Me.txt开始.TabIndex = 44
        '
        'txt结束
        '
        Me.txt结束.Location = New System.Drawing.Point(298, 19)
        Me.txt结束.Name = "txt结束"
        Me.txt结束.Size = New System.Drawing.Size(72, 21)
        Me.txt结束.TabIndex = 45
        '
        'txt步长
        '
        Me.txt步长.Location = New System.Drawing.Point(391, 19)
        Me.txt步长.Name = "txt步长"
        Me.txt步长.Size = New System.Drawing.Size(72, 21)
        Me.txt步长.TabIndex = 46
        '
        'CheckBox抑制
        '
        Me.CheckBox抑制.AutoSize = True
        Me.CheckBox抑制.Location = New System.Drawing.Point(139, 20)
        Me.CheckBox抑制.Name = "CheckBox抑制"
        Me.CheckBox抑制.Size = New System.Drawing.Size(48, 16)
        Me.CheckBox抑制.TabIndex = 48
        Me.CheckBox抑制.Text = "抑制"
        Me.CheckBox抑制.UseVisualStyleBackColor = True
        '
        'txt延时
        '
        Me.txt延时.Location = New System.Drawing.Point(488, 19)
        Me.txt延时.Name = "txt延时"
        Me.txt延时.Size = New System.Drawing.Size(72, 21)
        Me.txt延时.TabIndex = 49
        '
        'btn确定编辑
        '
        Me.btn确定编辑.Location = New System.Drawing.Point(573, 12)
        Me.btn确定编辑.Name = "btn确定编辑"
        Me.btn确定编辑.Size = New System.Drawing.Size(59, 30)
        Me.btn确定编辑.TabIndex = 50
        Me.btn确定编辑.Text = "确定"
        Me.btn确定编辑.UseVisualStyleBackColor = True
        '
        'btn预览
        '
        Me.btn预览.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn预览.AutoSize = True
        Me.btn预览.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn预览.Location = New System.Drawing.Point(245, 336)
        Me.btn预览.Name = "btn预览"
        Me.btn预览.Size = New System.Drawing.Size(65, 28)
        Me.btn预览.TabIndex = 51
        Me.btn预览.Text = "预览"
        '
        'btn选择约束
        '
        Me.btn选择约束.Location = New System.Drawing.Point(19, 15)
        Me.btn选择约束.Name = "btn选择约束"
        Me.btn选择约束.Size = New System.Drawing.Size(108, 26)
        Me.btn选择约束.TabIndex = 52
        Me.btn选择约束.Text = "选择约束"
        Me.btn选择约束.UseVisualStyleBackColor = True
        '
        'ch运动
        '
        Me.ch运动.Text = "运动"
        '
        'frmPlayer
        '
        Me.AcceptButton = Me.btn添加
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(656, 372)
        Me.Controls.Add(Me.btn选择约束)
        Me.Controls.Add(Me.btn预览)
        Me.Controls.Add(Me.btn确定编辑)
        Me.Controls.Add(Me.txt延时)
        Me.Controls.Add(Me.CheckBox抑制)
        Me.Controls.Add(Me.txt步长)
        Me.Controls.Add(Me.txt结束)
        Me.Controls.Add(Me.txt开始)
        Me.Controls.Add(Me.btn应用)
        Me.Controls.Add(Me.btn清空)
        Me.Controls.Add(Me.btn添加)
        Me.Controls.Add(Me.btn移出)
        Me.Controls.Add(Me.lvw文件列表)
        Me.Controls.Add(Me.btn关闭)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPlayer"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "动画"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn添加 As System.Windows.Forms.Button
    Friend WithEvents btn移出 As System.Windows.Forms.Button
    Friend WithEvents lvw文件列表 As System.Windows.Forms.ListView
    Friend WithEvents ch约束名称 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch抑制 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch开始 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch结束 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents btn清空 As System.Windows.Forms.Button
    Friend WithEvents btn应用 As System.Windows.Forms.Button
    Friend WithEvents ch步长 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch延时 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txt开始 As System.Windows.Forms.TextBox
    Friend WithEvents txt结束 As System.Windows.Forms.TextBox
    Friend WithEvents txt步长 As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox抑制 As System.Windows.Forms.CheckBox
    Friend WithEvents txt延时 As System.Windows.Forms.TextBox
    Friend WithEvents btn确定编辑 As System.Windows.Forms.Button
    Friend WithEvents btn预览 As System.Windows.Forms.Button
    Friend WithEvents btn选择约束 As System.Windows.Forms.Button
    Friend WithEvents ch运动 As System.Windows.Forms.ColumnHeader

End Class
