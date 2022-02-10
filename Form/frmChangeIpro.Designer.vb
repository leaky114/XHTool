<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangeIpro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChangeIpro))
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblDescribe = New System.Windows.Forms.Label()
        Me.txtNum = New System.Windows.Forms.TextBox()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.txtDescribe = New System.Windows.Forms.TextBox()
        Me.btnUp1 = New System.Windows.Forms.Button()
        Me.btnUp2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnOK.Location = New System.Drawing.Point(152, 112)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(65, 28)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "确定"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(225, 112)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(65, 28)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "取消"
        '
        'lblDescribe
        '
        Me.lblDescribe.AutoSize = True
        Me.lblDescribe.Location = New System.Drawing.Point(28, 26)
        Me.lblDescribe.Name = "lblDescribe"
        Me.lblDescribe.Size = New System.Drawing.Size(65, 60)
        Me.lblDescribe.TabIndex = 1
        Me.lblDescribe.Text = "图    号：" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "文 件 名：" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "描    述："
        '
        'txtNum
        '
        Me.txtNum.Location = New System.Drawing.Point(93, 20)
        Me.txtNum.Name = "txtNum"
        Me.txtNum.Size = New System.Drawing.Size(164, 21)
        Me.txtNum.TabIndex = 2
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(93, 47)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(164, 21)
        Me.txtFileName.TabIndex = 3
        '
        'txtDescribe
        '
        Me.txtDescribe.Location = New System.Drawing.Point(93, 74)
        Me.txtDescribe.Name = "txtDescribe"
        Me.txtDescribe.Size = New System.Drawing.Size(164, 21)
        Me.txtDescribe.TabIndex = 4
        '
        'btnUp1
        '
        Me.btnUp1.Location = New System.Drawing.Point(263, 25)
        Me.btnUp1.Name = "btnUp1"
        Me.btnUp1.Size = New System.Drawing.Size(23, 27)
        Me.btnUp1.TabIndex = 5
        Me.btnUp1.Text = "↑"
        Me.btnUp1.UseVisualStyleBackColor = True
        '
        'btnUp2
        '
        Me.btnUp2.Location = New System.Drawing.Point(263, 63)
        Me.btnUp2.Name = "btnUp2"
        Me.btnUp2.Size = New System.Drawing.Size(23, 27)
        Me.btnUp2.TabIndex = 6
        Me.btnUp2.Text = "↑"
        Me.btnUp2.UseVisualStyleBackColor = True
        '
        'frmChangeIpro
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(304, 145)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnUp2)
        Me.Controls.Add(Me.btnUp1)
        Me.Controls.Add(Me.txtDescribe)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.txtNum)
        Me.Controls.Add(Me.lblDescribe)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChangeIpro"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "调整IPro数据顺序"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblDescribe As System.Windows.Forms.Label
    Friend WithEvents txtNum As System.Windows.Forms.TextBox
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents txtDescribe As System.Windows.Forms.TextBox
    Friend WithEvents btnUp1 As System.Windows.Forms.Button
    Friend WithEvents btnUp2 As System.Windows.Forms.Button

End Class
