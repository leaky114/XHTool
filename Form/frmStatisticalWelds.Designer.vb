<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStatisticalWelds
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
        Me.btn移出 = New System.Windows.Forms.Button()
        Me.lbl描述 = New System.Windows.Forms.Label()
        Me.lvw文件列表 = New System.Windows.Forms.ListView()
        Me.ch边位置 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch长度 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch系数 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch焊缝长度 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.btn清空 = New System.Windows.Forms.Button()
        Me.txt焊缝长度 = New System.Windows.Forms.TextBox()
        Me.btn复制焊缝长度 = New System.Windows.Forms.Button()
        Me.btn选择面和边 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton10 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn移出
        '
        Me.btn移出.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn移出.Location = New System.Drawing.Point(289, 333)
        Me.btn移出.Name = "btn移出"
        Me.btn移出.Size = New System.Drawing.Size(60, 28)
        Me.btn移出.TabIndex = 1
        Me.btn移出.Text = "移出"
        Me.btn移出.UseVisualStyleBackColor = True
        '
        'lbl描述
        '
        Me.lbl描述.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl描述.AutoSize = True
        Me.lbl描述.Location = New System.Drawing.Point(54, 293)
        Me.lbl描述.Name = "lbl描述"
        Me.lbl描述.Size = New System.Drawing.Size(77, 12)
        Me.lbl描述.TabIndex = 36
        Me.lbl描述.Text = "总焊缝长度："
        '
        'lvw文件列表
        '
        Me.lvw文件列表.AllowDrop = True
        Me.lvw文件列表.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvw文件列表.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ch边位置, Me.ch长度, Me.ch系数, Me.ch焊缝长度})
        Me.lvw文件列表.FullRowSelect = True
        Me.lvw文件列表.Location = New System.Drawing.Point(12, 10)
        Me.lvw文件列表.Name = "lvw文件列表"
        Me.lvw文件列表.Size = New System.Drawing.Size(489, 262)
        Me.lvw文件列表.TabIndex = 35
        Me.lvw文件列表.TabStop = False
        Me.lvw文件列表.UseCompatibleStateImageBehavior = False
        Me.lvw文件列表.View = System.Windows.Forms.View.Details
        '
        'ch边位置
        '
        Me.ch边位置.Text = "边位置"
        Me.ch边位置.Width = 200
        '
        'ch长度
        '
        Me.ch长度.DisplayIndex = 2
        Me.ch长度.Text = "长度"
        Me.ch长度.Width = 80
        '
        'ch系数
        '
        Me.ch系数.DisplayIndex = 1
        Me.ch系数.Text = "系数"
        Me.ch系数.Width = 50
        '
        'ch焊缝长度
        '
        Me.ch焊缝长度.Text = "焊缝长度"
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.AutoSize = True
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(436, 333)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(60, 28)
        Me.btn关闭.TabIndex = 5
        Me.btn关闭.Text = "关闭"
        '
        'btn清空
        '
        Me.btn清空.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn清空.Location = New System.Drawing.Point(357, 333)
        Me.btn清空.Name = "btn清空"
        Me.btn清空.Size = New System.Drawing.Size(60, 28)
        Me.btn清空.TabIndex = 2
        Me.btn清空.Text = "清空"
        Me.btn清空.UseVisualStyleBackColor = True
        '
        'txt焊缝长度
        '
        Me.txt焊缝长度.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt焊缝长度.Location = New System.Drawing.Point(133, 289)
        Me.txt焊缝长度.Name = "txt焊缝长度"
        Me.txt焊缝长度.ReadOnly = True
        Me.txt焊缝长度.Size = New System.Drawing.Size(106, 21)
        Me.txt焊缝长度.TabIndex = 3
        Me.txt焊缝长度.TabStop = False
        '
        'btn复制焊缝长度
        '
        Me.btn复制焊缝长度.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn复制焊缝长度.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn复制焊缝长度.Location = New System.Drawing.Point(248, 287)
        Me.btn复制焊缝长度.Name = "btn复制焊缝长度"
        Me.btn复制焊缝长度.Size = New System.Drawing.Size(25, 25)
        Me.btn复制焊缝长度.TabIndex = 42
        Me.btn复制焊缝长度.UseVisualStyleBackColor = True
        '
        'btn选择面和边
        '
        Me.btn选择面和边.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn选择面和边.Location = New System.Drawing.Point(19, 287)
        Me.btn选择面和边.Name = "btn选择面和边"
        Me.btn选择面和边.Size = New System.Drawing.Size(25, 25)
        Me.btn选择面和边.TabIndex = 46
        Me.btn选择面和边.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.RadioButton10)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.RadioButton5)
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 325)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(249, 45)
        Me.GroupBox1.TabIndex = 47
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "焊缝系数"
        '
        'RadioButton10
        '
        Me.RadioButton10.AutoSize = True
        Me.RadioButton10.Checked = True
        Me.RadioButton10.Location = New System.Drawing.Point(174, 21)
        Me.RadioButton10.Name = "RadioButton10"
        Me.RadioButton10.Size = New System.Drawing.Size(29, 16)
        Me.RadioButton10.TabIndex = 3
        Me.RadioButton10.TabStop = True
        Me.RadioButton10.Text = "1"
        Me.RadioButton10.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(120, 21)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(41, 16)
        Me.RadioButton1.TabIndex = 2
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "0.7"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Location = New System.Drawing.Point(66, 21)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(41, 16)
        Me.RadioButton5.TabIndex = 1
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Text = "0.5"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(12, 21)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(41, 16)
        Me.RadioButton3.TabIndex = 0
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "0.3"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'frmStatisticalWelds
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 381)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn选择面和边)
        Me.Controls.Add(Me.btn复制焊缝长度)
        Me.Controls.Add(Me.txt焊缝长度)
        Me.Controls.Add(Me.btn清空)
        Me.Controls.Add(Me.btn移出)
        Me.Controls.Add(Me.lbl描述)
        Me.Controls.Add(Me.lvw文件列表)
        Me.Controls.Add(Me.btn关闭)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStatisticalWelds"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "统计焊缝"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn移出 As System.Windows.Forms.Button
    Friend WithEvents lbl描述 As System.Windows.Forms.Label
    Friend WithEvents lvw文件列表 As System.Windows.Forms.ListView
    Friend WithEvents ch边位置 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch系数 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch长度 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents btn清空 As System.Windows.Forms.Button
    Friend WithEvents txt焊缝长度 As System.Windows.Forms.TextBox
    Friend WithEvents btn复制焊缝长度 As System.Windows.Forms.Button
    Friend WithEvents ch焊缝长度 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn选择面和边 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton10 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton

End Class
