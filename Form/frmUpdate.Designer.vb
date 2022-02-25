<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdate
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
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.lblLocalVersion = New System.Windows.Forms.Label()
        Me.lblNewVersion = New System.Windows.Forms.Label()
        Me.txtWhatNew = New System.Windows.Forms.TextBox()
        Me.chk检查更新 = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.Location = New System.Drawing.Point(214, 251)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(75, 28)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "确定"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(289, 251)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(75, 28)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "取消"
        '
        'lblLocalVersion
        '
        Me.lblLocalVersion.AutoSize = True
        Me.lblLocalVersion.Location = New System.Drawing.Point(29, 15)
        Me.lblLocalVersion.Name = "lblLocalVersion"
        Me.lblLocalVersion.Size = New System.Drawing.Size(65, 12)
        Me.lblLocalVersion.TabIndex = 2
        Me.lblLocalVersion.Text = "当前版本："
        '
        'lblNewVersion
        '
        Me.lblNewVersion.AutoSize = True
        Me.lblNewVersion.Location = New System.Drawing.Point(29, 40)
        Me.lblNewVersion.Name = "lblNewVersion"
        Me.lblNewVersion.Size = New System.Drawing.Size(77, 12)
        Me.lblNewVersion.TabIndex = 3
        Me.lblNewVersion.Text = "可更新新版："
        '
        'txtWhatNew
        '
        Me.txtWhatNew.BackColor = System.Drawing.SystemColors.Control
        Me.txtWhatNew.Location = New System.Drawing.Point(13, 64)
        Me.txtWhatNew.Multiline = True
        Me.txtWhatNew.Name = "txtWhatNew"
        Me.txtWhatNew.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtWhatNew.Size = New System.Drawing.Size(351, 170)
        Me.txtWhatNew.TabIndex = 4
        '
        'chk检查更新
        '
        Me.chk检查更新.AutoSize = True
        Me.chk检查更新.Checked = True
        Me.chk检查更新.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk检查更新.Location = New System.Drawing.Point(12, 256)
        Me.chk检查更新.Name = "chk检查更新"
        Me.chk检查更新.Size = New System.Drawing.Size(108, 16)
        Me.chk检查更新.TabIndex = 14
        Me.chk检查更新.Text = "启动时检查更新"
        Me.chk检查更新.UseVisualStyleBackColor = True
        '
        'frmUpdate
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(376, 284)
        Me.Controls.Add(Me.chk检查更新)
        Me.Controls.Add(Me.txtWhatNew)
        Me.Controls.Add(Me.lblNewVersion)
        Me.Controls.Add(Me.lblLocalVersion)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.Cancel_Button)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUpdate"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "更新"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents lblLocalVersion As System.Windows.Forms.Label
    Friend WithEvents lblNewVersion As System.Windows.Forms.Label
    Friend WithEvents txtWhatNew As System.Windows.Forms.TextBox
    Friend WithEvents chk检查更新 As System.Windows.Forms.CheckBox

End Class
