<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDim2Object
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
        Me.btn正向 = New System.Windows.Forms.Button()
        Me.btn选择一项 = New System.Windows.Forms.Button()
        Me.btn选择二项 = New System.Windows.Forms.Button()
        Me.GroupBox选择两项 = New System.Windows.Forms.GroupBox()
        Me.RadioButton角度 = New System.Windows.Forms.RadioButton()
        Me.lbl距离 = New System.Windows.Forms.Label()
        Me.RadioButton距离 = New System.Windows.Forms.RadioButton()
        Me.GroupBox设置约束 = New System.Windows.Forms.GroupBox()
        Me.lbl位置 = New System.Windows.Forms.Label()
        Me.btn暂停 = New System.Windows.Forms.Button()
        Me.txt步长 = New System.Windows.Forms.TextBox()
        Me.lbl步长 = New System.Windows.Forms.Label()
        Me.txt结束 = New System.Windows.Forms.TextBox()
        Me.lbl结束 = New System.Windows.Forms.Label()
        Me.txt开始 = New System.Windows.Forms.TextBox()
        Me.lbl开始 = New System.Windows.Forms.Label()
        Me.btn反向 = New System.Windows.Forms.Button()
        Me.btn确定约束 = New System.Windows.Forms.Button()
        Me.oListView = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btn导出 = New System.Windows.Forms.Button()
        Me.GroupBox选择两项.SuspendLayout()
        Me.GroupBox设置约束.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn正向
        '
        Me.btn正向.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn正向.Location = New System.Drawing.Point(83, 84)
        Me.btn正向.Name = "btn正向"
        Me.btn正向.Size = New System.Drawing.Size(26, 26)
        Me.btn正向.TabIndex = 5
        Me.btn正向.UseVisualStyleBackColor = True
        '
        'btn选择一项
        '
        Me.btn选择一项.Location = New System.Drawing.Point(12, 25)
        Me.btn选择一项.Name = "btn选择一项"
        Me.btn选择一项.Size = New System.Drawing.Size(32, 32)
        Me.btn选择一项.TabIndex = 6
        Me.btn选择一项.UseVisualStyleBackColor = True
        '
        'btn选择二项
        '
        Me.btn选择二项.Location = New System.Drawing.Point(54, 25)
        Me.btn选择二项.Name = "btn选择二项"
        Me.btn选择二项.Size = New System.Drawing.Size(32, 32)
        Me.btn选择二项.TabIndex = 7
        Me.btn选择二项.UseVisualStyleBackColor = True
        '
        'GroupBox选择两项
        '
        Me.GroupBox选择两项.Controls.Add(Me.RadioButton角度)
        Me.GroupBox选择两项.Controls.Add(Me.lbl距离)
        Me.GroupBox选择两项.Controls.Add(Me.RadioButton距离)
        Me.GroupBox选择两项.Controls.Add(Me.btn选择一项)
        Me.GroupBox选择两项.Controls.Add(Me.btn选择二项)
        Me.GroupBox选择两项.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox选择两项.Name = "GroupBox选择两项"
        Me.GroupBox选择两项.Size = New System.Drawing.Size(285, 73)
        Me.GroupBox选择两项.TabIndex = 11
        Me.GroupBox选择两项.TabStop = False
        Me.GroupBox选择两项.Text = "选择两项"
        '
        'RadioButton角度
        '
        Me.RadioButton角度.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton角度.AutoSize = True
        Me.RadioButton角度.Location = New System.Drawing.Point(220, 46)
        Me.RadioButton角度.Name = "RadioButton角度"
        Me.RadioButton角度.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton角度.TabIndex = 15
        Me.RadioButton角度.Text = "角度"
        Me.RadioButton角度.UseVisualStyleBackColor = True
        '
        'lbl距离
        '
        Me.lbl距离.AutoSize = True
        Me.lbl距离.Location = New System.Drawing.Point(103, 35)
        Me.lbl距离.Name = "lbl距离"
        Me.lbl距离.Size = New System.Drawing.Size(41, 12)
        Me.lbl距离.TabIndex = 8
        Me.lbl距离.Text = "距离："
        '
        'RadioButton距离
        '
        Me.RadioButton距离.AutoSize = True
        Me.RadioButton距离.Checked = True
        Me.RadioButton距离.Location = New System.Drawing.Point(220, 20)
        Me.RadioButton距离.Name = "RadioButton距离"
        Me.RadioButton距离.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton距离.TabIndex = 9
        Me.RadioButton距离.TabStop = True
        Me.RadioButton距离.Text = "距离"
        Me.RadioButton距离.UseVisualStyleBackColor = True
        '
        'GroupBox设置约束
        '
        Me.GroupBox设置约束.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox设置约束.Controls.Add(Me.lbl位置)
        Me.GroupBox设置约束.Controls.Add(Me.btn暂停)
        Me.GroupBox设置约束.Controls.Add(Me.txt步长)
        Me.GroupBox设置约束.Controls.Add(Me.lbl步长)
        Me.GroupBox设置约束.Controls.Add(Me.txt结束)
        Me.GroupBox设置约束.Controls.Add(Me.lbl结束)
        Me.GroupBox设置约束.Controls.Add(Me.txt开始)
        Me.GroupBox设置约束.Controls.Add(Me.lbl开始)
        Me.GroupBox设置约束.Controls.Add(Me.btn反向)
        Me.GroupBox设置约束.Controls.Add(Me.btn正向)
        Me.GroupBox设置约束.Controls.Add(Me.btn确定约束)
        Me.GroupBox设置约束.Location = New System.Drawing.Point(16, 99)
        Me.GroupBox设置约束.Name = "GroupBox设置约束"
        Me.GroupBox设置约束.Size = New System.Drawing.Size(281, 121)
        Me.GroupBox设置约束.TabIndex = 12
        Me.GroupBox设置约束.TabStop = False
        Me.GroupBox设置约束.Text = "设置约束"
        '
        'lbl位置
        '
        Me.lbl位置.AutoSize = True
        Me.lbl位置.Location = New System.Drawing.Point(57, 33)
        Me.lbl位置.Name = "lbl位置"
        Me.lbl位置.Size = New System.Drawing.Size(29, 12)
        Me.lbl位置.TabIndex = 21
        Me.lbl位置.Text = "位置"
        '
        'btn暂停
        '
        Me.btn暂停.Font = New System.Drawing.Font("宋体", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn暂停.Location = New System.Drawing.Point(50, 84)
        Me.btn暂停.Name = "btn暂停"
        Me.btn暂停.Size = New System.Drawing.Size(26, 26)
        Me.btn暂停.TabIndex = 20
        Me.btn暂停.UseVisualStyleBackColor = True
        '
        'txt步长
        '
        Me.txt步长.Location = New System.Drawing.Point(202, 87)
        Me.txt步长.Name = "txt步长"
        Me.txt步长.Size = New System.Drawing.Size(63, 21)
        Me.txt步长.TabIndex = 19
        Me.txt步长.Text = "1"
        '
        'lbl步长
        '
        Me.lbl步长.AutoSize = True
        Me.lbl步长.Location = New System.Drawing.Point(163, 91)
        Me.lbl步长.Name = "lbl步长"
        Me.lbl步长.Size = New System.Drawing.Size(29, 12)
        Me.lbl步长.TabIndex = 18
        Me.lbl步长.Text = "步长"
        '
        'txt结束
        '
        Me.txt结束.Location = New System.Drawing.Point(202, 55)
        Me.txt结束.Name = "txt结束"
        Me.txt结束.Size = New System.Drawing.Size(63, 21)
        Me.txt结束.TabIndex = 17
        '
        'lbl结束
        '
        Me.lbl结束.AutoSize = True
        Me.lbl结束.Location = New System.Drawing.Point(163, 59)
        Me.lbl结束.Name = "lbl结束"
        Me.lbl结束.Size = New System.Drawing.Size(29, 12)
        Me.lbl结束.TabIndex = 16
        Me.lbl结束.Text = "结束"
        '
        'txt开始
        '
        Me.txt开始.Location = New System.Drawing.Point(94, 55)
        Me.txt开始.Name = "txt开始"
        Me.txt开始.Size = New System.Drawing.Size(63, 21)
        Me.txt开始.TabIndex = 15
        '
        'lbl开始
        '
        Me.lbl开始.AutoSize = True
        Me.lbl开始.Location = New System.Drawing.Point(55, 59)
        Me.lbl开始.Name = "lbl开始"
        Me.lbl开始.Size = New System.Drawing.Size(29, 12)
        Me.lbl开始.TabIndex = 14
        Me.lbl开始.Text = "开始"
        '
        'btn反向
        '
        Me.btn反向.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn反向.Location = New System.Drawing.Point(17, 84)
        Me.btn反向.Name = "btn反向"
        Me.btn反向.Size = New System.Drawing.Size(26, 26)
        Me.btn反向.TabIndex = 13
        Me.btn反向.UseVisualStyleBackColor = True
        '
        'btn确定约束
        '
        Me.btn确定约束.Location = New System.Drawing.Point(12, 26)
        Me.btn确定约束.Name = "btn确定约束"
        Me.btn确定约束.Size = New System.Drawing.Size(32, 32)
        Me.btn确定约束.TabIndex = 7
        Me.btn确定约束.UseVisualStyleBackColor = True
        '
        'oListView
        '
        Me.oListView.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.oListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.oListView.FullRowSelect = True
        Me.oListView.Location = New System.Drawing.Point(331, 12)
        Me.oListView.MultiSelect = False
        Me.oListView.Name = "oListView"
        Me.oListView.Size = New System.Drawing.Size(180, 178)
        Me.oListView.TabIndex = 13
        Me.oListView.UseCompatibleStateImageBehavior = False
        Me.oListView.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "位置"
        Me.ColumnHeader1.Width = 70
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "距离/角度"
        Me.ColumnHeader2.Width = 70
        '
        'btn导出
        '
        Me.btn导出.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn导出.Location = New System.Drawing.Point(443, 197)
        Me.btn导出.Name = "btn导出"
        Me.btn导出.Size = New System.Drawing.Size(62, 28)
        Me.btn导出.TabIndex = 14
        Me.btn导出.Text = "导出"
        Me.btn导出.UseVisualStyleBackColor = True
        '
        'frmDim2Object
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(522, 235)
        Me.Controls.Add(Me.btn导出)
        Me.Controls.Add(Me.oListView)
        Me.Controls.Add(Me.GroupBox设置约束)
        Me.Controls.Add(Me.GroupBox选择两项)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDim2Object"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "驱动测量"
        Me.TopMost = True
        Me.GroupBox选择两项.ResumeLayout(False)
        Me.GroupBox选择两项.PerformLayout()
        Me.GroupBox设置约束.ResumeLayout(False)
        Me.GroupBox设置约束.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn正向 As System.Windows.Forms.Button
    Friend WithEvents btn选择一项 As System.Windows.Forms.Button
    Friend WithEvents btn选择二项 As System.Windows.Forms.Button
    Friend WithEvents GroupBox选择两项 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox设置约束 As System.Windows.Forms.GroupBox
    Friend WithEvents btn反向 As System.Windows.Forms.Button
    Friend WithEvents btn确定约束 As System.Windows.Forms.Button
    Friend WithEvents txt步长 As System.Windows.Forms.TextBox
    Friend WithEvents lbl步长 As System.Windows.Forms.Label
    Friend WithEvents txt结束 As System.Windows.Forms.TextBox
    Friend WithEvents lbl结束 As System.Windows.Forms.Label
    Friend WithEvents txt开始 As System.Windows.Forms.TextBox
    Friend WithEvents lbl开始 As System.Windows.Forms.Label
    Friend WithEvents btn暂停 As System.Windows.Forms.Button
    Friend WithEvents lbl距离 As System.Windows.Forms.Label
    Friend WithEvents lbl位置 As System.Windows.Forms.Label
    Friend WithEvents oListView As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn导出 As System.Windows.Forms.Button
    Friend WithEvents RadioButton角度 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton距离 As System.Windows.Forms.RadioButton
End Class
