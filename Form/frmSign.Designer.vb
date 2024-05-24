<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSign
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
        Me.lbl工程师 = New System.Windows.Forms.Label()
        Me.lbl日期 = New System.Windows.Forms.Label()
        Me.txt工程师 = New System.Windows.Forms.TextBox()
        Me.dtp日期 = New System.Windows.Forms.DateTimePicker()
        Me.chk签字后打印 = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'btn确定
        '
        Me.btn确定.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn确定.Location = New System.Drawing.Point(74, 109)
        Me.btn确定.Name = "btn确定"
        Me.btn确定.Size = New System.Drawing.Size(65, 25)
        Me.btn确定.TabIndex = 3
        Me.btn确定.Text = "确定"
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(147, 109)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(65, 25)
        Me.btn关闭.TabIndex = 4
        Me.btn关闭.Text = "取消"
        '
        'lbl工程师
        '
        Me.lbl工程师.AutoSize = True
        Me.lbl工程师.Location = New System.Drawing.Point(12, 9)
        Me.lbl工程师.Name = "lbl工程师"
        Me.lbl工程师.Size = New System.Drawing.Size(53, 12)
        Me.lbl工程师.TabIndex = 1
        Me.lbl工程师.Text = "工程师："
        '
        'lbl日期
        '
        Me.lbl日期.AutoSize = True
        Me.lbl日期.Location = New System.Drawing.Point(12, 35)
        Me.lbl日期.Name = "lbl日期"
        Me.lbl日期.Size = New System.Drawing.Size(47, 12)
        Me.lbl日期.TabIndex = 2
        Me.lbl日期.Text = "日 期："
        '
        'txt工程师
        '
        Me.txt工程师.Location = New System.Drawing.Point(67, 5)
        Me.txt工程师.Name = "txt工程师"
        Me.txt工程师.Size = New System.Drawing.Size(136, 21)
        Me.txt工程师.TabIndex = 0
        '
        'dtp日期
        '
        Me.dtp日期.Location = New System.Drawing.Point(64, 35)
        Me.dtp日期.Name = "dtp日期"
        Me.dtp日期.Size = New System.Drawing.Size(139, 21)
        Me.dtp日期.TabIndex = 1
        '
        'chk签字后打印
        '
        Me.chk签字后打印.AutoSize = True
        Me.chk签字后打印.Location = New System.Drawing.Point(12, 72)
        Me.chk签字后打印.Name = "chk签字后打印"
        Me.chk签字后打印.Size = New System.Drawing.Size(84, 16)
        Me.chk签字后打印.TabIndex = 2
        Me.chk签字后打印.Text = "签字后打印"
        Me.chk签字后打印.UseVisualStyleBackColor = True
        '
        'frmSign
        '
        Me.AcceptButton = Me.btn确定
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn关闭
        Me.ClientSize = New System.Drawing.Size(226, 142)
        Me.Controls.Add(Me.btn确定)
        Me.Controls.Add(Me.chk签字后打印)
        Me.Controls.Add(Me.btn关闭)
        Me.Controls.Add(Me.dtp日期)
        Me.Controls.Add(Me.txt工程师)
        Me.Controls.Add(Me.lbl日期)
        Me.Controls.Add(Me.lbl工程师)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSign"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " 签字"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn确定 As System.Windows.Forms.Button
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents lbl工程师 As System.Windows.Forms.Label
    Friend WithEvents lbl日期 As System.Windows.Forms.Label
    Friend WithEvents txt工程师 As System.Windows.Forms.TextBox
    Friend WithEvents dtp日期 As System.Windows.Forms.DateTimePicker
    Friend WithEvents chk签字后打印 As System.Windows.Forms.CheckBox

End Class
