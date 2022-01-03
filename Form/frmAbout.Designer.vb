<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblCopyright = New System.Windows.Forms.Label()
        Me.lblCompanyName = New System.Windows.Forms.Label()
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.picZhiFuBao = New System.Windows.Forms.PictureBox()
        Me.picWeiXin = New System.Windows.Forms.PictureBox()
        Me.btn检查更新 = New System.Windows.Forms.Button()
        Me.lblGitCode = New System.Windows.Forms.LinkLabel()
        Me.lblBilibili = New System.Windows.Forms.LinkLabel()
        CType(Me.picZhiFuBao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picWeiXin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(274, 238)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(75, 28)
        Me.btn关闭.TabIndex = 40
        Me.btn关闭.Text = "关闭"
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(124, 35)
        Me.lblVersion.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.lblVersion.MaximumSize = New System.Drawing.Size(0, 16)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(29, 12)
        Me.lblVersion.TabIndex = 39
        Me.lblVersion.Text = "版本"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCopyright
        '
        Me.lblCopyright.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCopyright.AutoSize = True
        Me.lblCopyright.Location = New System.Drawing.Point(124, 61)
        Me.lblCopyright.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.lblCopyright.MaximumSize = New System.Drawing.Size(0, 16)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(29, 12)
        Me.lblCopyright.TabIndex = 38
        Me.lblCopyright.Text = "版权"
        Me.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCompanyName
        '
        Me.lblCompanyName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCompanyName.AutoSize = True
        Me.lblCompanyName.Location = New System.Drawing.Point(124, 86)
        Me.lblCompanyName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.lblCompanyName.MaximumSize = New System.Drawing.Size(0, 16)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Size = New System.Drawing.Size(53, 12)
        Me.lblCompanyName.TabIndex = 37
        Me.lblCompanyName.Text = "公司名称"
        Me.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProductName
        '
        Me.lblProductName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProductName.AutoSize = True
        Me.lblProductName.Location = New System.Drawing.Point(124, 11)
        Me.lblProductName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.lblProductName.MaximumSize = New System.Drawing.Size(0, 16)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(53, 12)
        Me.lblProductName.TabIndex = 36
        Me.lblProductName.Text = "产品名称"
        Me.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Location = New System.Drawing.Point(127, 107)
        Me.txtDescription.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDescription.Size = New System.Drawing.Size(219, 107)
        Me.txtDescription.TabIndex = 41
        Me.txtDescription.TabStop = False
        Me.txtDescription.Text = "说明 :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(在运行时，将用应用程序的程序集信息替换这些标签的文本。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "在"
        '
        'picZhiFuBao
        '
        Me.picZhiFuBao.Image = Global.InventorAddIn.My.Resources.Resources.支付宝
        Me.picZhiFuBao.InitialImage = Nothing
        Me.picZhiFuBao.Location = New System.Drawing.Point(14, 126)
        Me.picZhiFuBao.Name = "picZhiFuBao"
        Me.picZhiFuBao.Size = New System.Drawing.Size(100, 100)
        Me.picZhiFuBao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picZhiFuBao.TabIndex = 43
        Me.picZhiFuBao.TabStop = False
        '
        'picWeiXin
        '
        Me.picWeiXin.Image = Global.InventorAddIn.My.Resources.Resources.微信
        Me.picWeiXin.InitialImage = Nothing
        Me.picWeiXin.Location = New System.Drawing.Point(14, 12)
        Me.picWeiXin.Name = "picWeiXin"
        Me.picWeiXin.Size = New System.Drawing.Size(100, 100)
        Me.picWeiXin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picWeiXin.TabIndex = 42
        Me.picWeiXin.TabStop = False
        '
        'btn检查更新
        '
        Me.btn检查更新.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn检查更新.Location = New System.Drawing.Point(184, 238)
        Me.btn检查更新.Name = "btn检查更新"
        Me.btn检查更新.Size = New System.Drawing.Size(75, 28)
        Me.btn检查更新.TabIndex = 44
        Me.btn检查更新.Text = "检查更新"
        Me.btn检查更新.UseVisualStyleBackColor = True
        '
        'lblGitCode
        '
        Me.lblGitCode.AutoSize = True
        Me.lblGitCode.Location = New System.Drawing.Point(21, 248)
        Me.lblGitCode.Name = "lblGitCode"
        Me.lblGitCode.Size = New System.Drawing.Size(47, 12)
        Me.lblGitCode.TabIndex = 46
        Me.lblGitCode.TabStop = True
        Me.lblGitCode.Text = "GitCode"
        '
        'lblBilibili
        '
        Me.lblBilibili.AutoSize = True
        Me.lblBilibili.Location = New System.Drawing.Point(88, 248)
        Me.lblBilibili.Name = "lblBilibili"
        Me.lblBilibili.Size = New System.Drawing.Size(53, 12)
        Me.lblBilibili.TabIndex = 47
        Me.lblBilibili.TabStop = True
        Me.lblBilibili.Text = "Bilibili"
        '
        'frmAbout
        '
        Me.AcceptButton = Me.btn检查更新
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn关闭
        Me.ClientSize = New System.Drawing.Size(358, 275)
        Me.Controls.Add(Me.lblBilibili)
        Me.Controls.Add(Me.lblGitCode)
        Me.Controls.Add(Me.btn检查更新)
        Me.Controls.Add(Me.picZhiFuBao)
        Me.Controls.Add(Me.picWeiXin)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.btn关闭)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblCopyright)
        Me.Controls.Add(Me.lblCompanyName)
        Me.Controls.Add(Me.lblProductName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.Padding = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "关于"
        CType(Me.picZhiFuBao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picWeiXin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblCopyright As System.Windows.Forms.Label
    Friend WithEvents lblCompanyName As System.Windows.Forms.Label
    Friend WithEvents lblProductName As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents picWeiXin As System.Windows.Forms.PictureBox
    Friend WithEvents picZhiFuBao As System.Windows.Forms.PictureBox
    Friend WithEvents btn检查更新 As System.Windows.Forms.Button
    Friend WithEvents lblGitCode As System.Windows.Forms.LinkLabel
    Friend WithEvents lblBilibili As System.Windows.Forms.LinkLabel

End Class
