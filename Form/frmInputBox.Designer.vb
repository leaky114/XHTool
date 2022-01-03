<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInputBox
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
        Me.btn确定 = New System.Windows.Forms.Button()
        Me.btn取消 = New System.Windows.Forms.Button()
        Me.lbl描述 = New System.Windows.Forms.Label()
        Me.txt输入 = New System.Windows.Forms.TextBox()
        Me.pic图标 = New System.Windows.Forms.PictureBox()
        Me.btn复制 = New System.Windows.Forms.Button()
        Me.btn粘贴 = New System.Windows.Forms.Button()
        Me.btn其他 = New System.Windows.Forms.Button()
        CType(Me.pic图标, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn确定
        '
        Me.btn确定.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn确定.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btn确定.Location = New System.Drawing.Point(283, 125)
        Me.btn确定.Name = "btn确定"
        Me.btn确定.Size = New System.Drawing.Size(65, 28)
        Me.btn确定.TabIndex = 0
        Me.btn确定.Text = "确定"
        '
        'btn取消
        '
        Me.btn取消.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn取消.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn取消.Location = New System.Drawing.Point(356, 125)
        Me.btn取消.Name = "btn取消"
        Me.btn取消.Size = New System.Drawing.Size(65, 28)
        Me.btn取消.TabIndex = 1
        Me.btn取消.Text = "取消"
        '
        'lbl描述
        '
        Me.lbl描述.Location = New System.Drawing.Point(77, 9)
        Me.lbl描述.Name = "lbl描述"
        Me.lbl描述.Size = New System.Drawing.Size(343, 63)
        Me.lbl描述.TabIndex = 1
        Me.lbl描述.Text = "Label1"
        '
        'txt输入
        '
        Me.txt输入.Location = New System.Drawing.Point(79, 87)
        Me.txt输入.Name = "txt输入"
        Me.txt输入.Size = New System.Drawing.Size(341, 21)
        Me.txt输入.TabIndex = 0
        '
        'pic图标
        '
        Me.pic图标.Location = New System.Drawing.Point(11, 13)
        Me.pic图标.Name = "pic图标"
        Me.pic图标.Size = New System.Drawing.Size(45, 45)
        Me.pic图标.TabIndex = 3
        Me.pic图标.TabStop = False
        '
        'btn复制
        '
        Me.btn复制.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn复制.Location = New System.Drawing.Point(10, 125)
        Me.btn复制.Name = "btn复制"
        Me.btn复制.Size = New System.Drawing.Size(65, 28)
        Me.btn复制.TabIndex = 4
        Me.btn复制.Text = "复制"
        Me.btn复制.UseVisualStyleBackColor = True
        '
        'btn粘贴
        '
        Me.btn粘贴.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn粘贴.Location = New System.Drawing.Point(83, 125)
        Me.btn粘贴.Name = "btn粘贴"
        Me.btn粘贴.Size = New System.Drawing.Size(65, 28)
        Me.btn粘贴.TabIndex = 5
        Me.btn粘贴.Text = "粘贴"
        Me.btn粘贴.UseVisualStyleBackColor = True
        '
        'btn其他
        '
        Me.btn其他.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn其他.Location = New System.Drawing.Point(156, 125)
        Me.btn其他.Name = "btn其他"
        Me.btn其他.Size = New System.Drawing.Size(65, 28)
        Me.btn其他.TabIndex = 6
        Me.btn其他.Text = "其他可变"
        Me.btn其他.UseVisualStyleBackColor = True
        Me.btn其他.Visible = False
        '
        'frmInputBox
        '
        Me.AcceptButton = Me.btn确定
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn取消
        Me.ClientSize = New System.Drawing.Size(443, 161)
        Me.Controls.Add(Me.btn其他)
        Me.Controls.Add(Me.btn粘贴)
        Me.Controls.Add(Me.btn复制)
        Me.Controls.Add(Me.btn确定)
        Me.Controls.Add(Me.pic图标)
        Me.Controls.Add(Me.btn取消)
        Me.Controls.Add(Me.txt输入)
        Me.Controls.Add(Me.lbl描述)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInputBox"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "InputBoxDialog"
        CType(Me.pic图标, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn确定 As System.Windows.Forms.Button
    Friend WithEvents btn取消 As System.Windows.Forms.Button
    Friend WithEvents lbl描述 As System.Windows.Forms.Label
    Friend WithEvents txt输入 As System.Windows.Forms.TextBox
    Friend WithEvents pic图标 As System.Windows.Forms.PictureBox
    Friend WithEvents btn复制 As System.Windows.Forms.Button
    Friend WithEvents btn粘贴 As System.Windows.Forms.Button
    Friend WithEvents btn其他 As System.Windows.Forms.Button

End Class
