<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGetPart
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
        Me.lbl描述 = New System.Windows.Forms.Label()
        Me.lvw文件列表 = New System.Windows.Forms.ListView()
        Me.ch文件名 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch数量 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch质量 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch面积 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.btn清空 = New System.Windows.Forms.Button()
        Me.txt质量 = New System.Windows.Forms.TextBox()
        Me.txt面积 = New System.Windows.Forms.TextBox()
        Me.btn复制质量 = New System.Windows.Forms.Button()
        Me.btn复制面积 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn添加
        '
        Me.btn添加.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn添加.Location = New System.Drawing.Point(17, 342)
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
        Me.btn移出.Location = New System.Drawing.Point(90, 342)
        Me.btn移出.Name = "btn移出"
        Me.btn移出.Size = New System.Drawing.Size(65, 28)
        Me.btn移出.TabIndex = 37
        Me.btn移出.Text = "移出"
        Me.btn移出.UseVisualStyleBackColor = True
        '
        'lbl描述
        '
        Me.lbl描述.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl描述.AutoSize = True
        Me.lbl描述.Location = New System.Drawing.Point(15, 309)
        Me.lbl描述.Name = "lbl描述"
        Me.lbl描述.Size = New System.Drawing.Size(221, 12)
        Me.lbl描述.TabIndex = 36
        Me.lbl描述.Text = "总质量：                    总面积："
        '
        'lvw文件列表
        '
        Me.lvw文件列表.AllowDrop = True
        Me.lvw文件列表.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvw文件列表.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ch文件名, Me.ch数量, Me.ch质量, Me.ch面积})
        Me.lvw文件列表.FullRowSelect = True
        Me.lvw文件列表.Location = New System.Drawing.Point(12, 10)
        Me.lvw文件列表.Name = "lvw文件列表"
        Me.lvw文件列表.Size = New System.Drawing.Size(436, 285)
        Me.lvw文件列表.TabIndex = 35
        Me.lvw文件列表.TabStop = False
        Me.lvw文件列表.UseCompatibleStateImageBehavior = False
        Me.lvw文件列表.View = System.Windows.Forms.View.Details
        '
        'ch文件名
        '
        Me.ch文件名.Text = "文件名"
        Me.ch文件名.Width = 220
        '
        'ch数量
        '
        Me.ch数量.Text = "数量"
        Me.ch数量.Width = 50
        '
        'ch质量
        '
        Me.ch质量.Text = "质量"
        Me.ch质量.Width = 80
        '
        'ch面积
        '
        Me.ch面积.Text = "面积"
        Me.ch面积.Width = 80
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.AutoSize = True
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(383, 342)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(65, 28)
        Me.btn关闭.TabIndex = 34
        Me.btn关闭.Text = "关闭"
        '
        'btn清空
        '
        Me.btn清空.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn清空.Location = New System.Drawing.Point(163, 342)
        Me.btn清空.Name = "btn清空"
        Me.btn清空.Size = New System.Drawing.Size(65, 28)
        Me.btn清空.TabIndex = 39
        Me.btn清空.Text = "清空"
        Me.btn清空.UseVisualStyleBackColor = True
        '
        'txt质量
        '
        Me.txt质量.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt质量.Location = New System.Drawing.Point(62, 304)
        Me.txt质量.Name = "txt质量"
        Me.txt质量.Size = New System.Drawing.Size(77, 21)
        Me.txt质量.TabIndex = 40
        '
        'txt面积
        '
        Me.txt面积.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt面积.Location = New System.Drawing.Point(242, 306)
        Me.txt面积.Name = "txt面积"
        Me.txt面积.Size = New System.Drawing.Size(77, 21)
        Me.txt面积.TabIndex = 41
        '
        'btn复制质量
        '
        Me.btn复制质量.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn复制质量.Location = New System.Drawing.Point(147, 304)
        Me.btn复制质量.Name = "btn复制质量"
        Me.btn复制质量.Size = New System.Drawing.Size(24, 20)
        Me.btn复制质量.TabIndex = 42
        Me.btn复制质量.Text = "C"
        Me.btn复制质量.UseVisualStyleBackColor = True
        '
        'btn复制面积
        '
        Me.btn复制面积.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn复制面积.Location = New System.Drawing.Point(325, 305)
        Me.btn复制面积.Name = "btn复制面积"
        Me.btn复制面积.Size = New System.Drawing.Size(24, 20)
        Me.btn复制面积.TabIndex = 43
        Me.btn复制面积.Text = "C"
        Me.btn复制面积.UseVisualStyleBackColor = True
        '
        'frmGetPart
        '
        Me.AcceptButton = Me.btn添加
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn关闭
        Me.ClientSize = New System.Drawing.Size(461, 378)
        Me.Controls.Add(Me.btn复制面积)
        Me.Controls.Add(Me.btn复制质量)
        Me.Controls.Add(Me.txt面积)
        Me.Controls.Add(Me.txt质量)
        Me.Controls.Add(Me.btn清空)
        Me.Controls.Add(Me.btn添加)
        Me.Controls.Add(Me.btn移出)
        Me.Controls.Add(Me.lbl描述)
        Me.Controls.Add(Me.lvw文件列表)
        Me.Controls.Add(Me.btn关闭)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGetPart"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "统计质量面积"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn添加 As System.Windows.Forms.Button
    Friend WithEvents btn移出 As System.Windows.Forms.Button
    Friend WithEvents lbl描述 As System.Windows.Forms.Label
    Friend WithEvents lvw文件列表 As System.Windows.Forms.ListView
    Friend WithEvents ch文件名 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch数量 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch质量 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch面积 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents btn清空 As System.Windows.Forms.Button
    Friend WithEvents txt质量 As System.Windows.Forms.TextBox
    Friend WithEvents txt面积 As System.Windows.Forms.TextBox
    Friend WithEvents btn复制质量 As System.Windows.Forms.Button
    Friend WithEvents btn复制面积 As System.Windows.Forms.Button

End Class
