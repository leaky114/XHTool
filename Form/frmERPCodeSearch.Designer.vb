<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmERPCodeSearch
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
        Me.btn粘贴 = New System.Windows.Forms.Button()
        Me.btn编码反查 = New System.Windows.Forms.Button()
        Me.lblERP编码 = New System.Windows.Forms.Label()
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.txtERP编码 = New System.Windows.Forms.TextBox()
        Me.txt返回值 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btn粘贴
        '
        Me.btn粘贴.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn粘贴.Location = New System.Drawing.Point(257, 10)
        Me.btn粘贴.Name = "btn粘贴"
        Me.btn粘贴.Size = New System.Drawing.Size(81, 28)
        Me.btn粘贴.TabIndex = 10
        Me.btn粘贴.Text = "粘贴"
        Me.btn粘贴.UseVisualStyleBackColor = True
        '
        'btn编码反查
        '
        Me.btn编码反查.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn编码反查.Location = New System.Drawing.Point(186, 54)
        Me.btn编码反查.Name = "btn编码反查"
        Me.btn编码反查.Size = New System.Drawing.Size(81, 28)
        Me.btn编码反查.TabIndex = 11
        Me.btn编码反查.Text = "编码反查"
        '
        'lblERP编码
        '
        Me.lblERP编码.AutoSize = True
        Me.lblERP编码.Location = New System.Drawing.Point(9, 16)
        Me.lblERP编码.Name = "lblERP编码"
        Me.lblERP编码.Size = New System.Drawing.Size(59, 12)
        Me.lblERP编码.TabIndex = 14
        Me.lblERP编码.Text = "ERP编码："
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(273, 54)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(65, 28)
        Me.btn关闭.TabIndex = 12
        Me.btn关闭.Text = "关闭"
        '
        'txtERP编码
        '
        Me.txtERP编码.Location = New System.Drawing.Point(82, 12)
        Me.txtERP编码.Name = "txtERP编码"
        Me.txtERP编码.Size = New System.Drawing.Size(164, 21)
        Me.txtERP编码.TabIndex = 0
        '
        'txt返回值
        '
        Me.txt返回值.Location = New System.Drawing.Point(17, 97)
        Me.txt返回值.Multiline = True
        Me.txt返回值.Name = "txt返回值"
        Me.txt返回值.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txt返回值.Size = New System.Drawing.Size(320, 131)
        Me.txt返回值.TabIndex = 15
        '
        'frmERPCodeSearch
        '
        Me.AcceptButton = Me.btn编码反查
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn关闭
        Me.ClientSize = New System.Drawing.Size(350, 240)
        Me.Controls.Add(Me.txt返回值)
        Me.Controls.Add(Me.btn粘贴)
        Me.Controls.Add(Me.btn编码反查)
        Me.Controls.Add(Me.lblERP编码)
        Me.Controls.Add(Me.btn关闭)
        Me.Controls.Add(Me.txtERP编码)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmERPCodeSearch"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ERP编码反查"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn粘贴 As System.Windows.Forms.Button
    Friend WithEvents btn编码反查 As System.Windows.Forms.Button
    Friend WithEvents lblERP编码 As System.Windows.Forms.Label
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents txtERP编码 As System.Windows.Forms.TextBox
    Friend WithEvents txt返回值 As System.Windows.Forms.TextBox

End Class
