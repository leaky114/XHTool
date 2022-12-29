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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblDescribe = New System.Windows.Forms.Label()
        Me.txtInPut = New System.Windows.Forms.TextBox()
        Me.picICON = New System.Windows.Forms.PictureBox()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.btnPaste = New System.Windows.Forms.Button()
        Me.btnOther = New System.Windows.Forms.Button()
        CType(Me.picICON, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(283, 125)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(65, 28)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "确定"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(356, 125)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(65, 28)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "取消"
        '
        'lblDescribe
        '
        Me.lblDescribe.Location = New System.Drawing.Point(77, 9)
        Me.lblDescribe.Name = "lblDescribe"
        Me.lblDescribe.Size = New System.Drawing.Size(343, 63)
        Me.lblDescribe.TabIndex = 1
        Me.lblDescribe.Text = "Label1"
        '
        'txtInPut
        '
        Me.txtInPut.Location = New System.Drawing.Point(79, 87)
        Me.txtInPut.Name = "txtInPut"
        Me.txtInPut.Size = New System.Drawing.Size(341, 21)
        Me.txtInPut.TabIndex = 0
        '
        'picICON
        '
        Me.picICON.Location = New System.Drawing.Point(11, 13)
        Me.picICON.Name = "picICON"
        Me.picICON.Size = New System.Drawing.Size(45, 45)
        Me.picICON.TabIndex = 3
        Me.picICON.TabStop = False
        '
        'btnCopy
        '
        Me.btnCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCopy.Location = New System.Drawing.Point(10, 125)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(65, 28)
        Me.btnCopy.TabIndex = 4
        Me.btnCopy.Text = "复制"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'btnPaste
        '
        Me.btnPaste.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPaste.Location = New System.Drawing.Point(83, 125)
        Me.btnPaste.Name = "btnPaste"
        Me.btnPaste.Size = New System.Drawing.Size(65, 28)
        Me.btnPaste.TabIndex = 5
        Me.btnPaste.Text = "粘贴"
        Me.btnPaste.UseVisualStyleBackColor = True
        '
        'btnOther
        '
        Me.btnOther.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOther.Location = New System.Drawing.Point(156, 125)
        Me.btnOther.Name = "btnOther"
        Me.btnOther.Size = New System.Drawing.Size(65, 28)
        Me.btnOther.TabIndex = 6
        Me.btnOther.Text = "其他可变"
        Me.btnOther.UseVisualStyleBackColor = True
        Me.btnOther.Visible = False
        '
        'frmInputBox
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(443, 161)
        Me.Controls.Add(Me.btnOther)
        Me.Controls.Add(Me.btnPaste)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.picICON)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtInPut)
        Me.Controls.Add(Me.lblDescribe)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInputBox"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "InputBoxDialog"
        CType(Me.picICON, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblDescribe As System.Windows.Forms.Label
    Friend WithEvents txtInPut As System.Windows.Forms.TextBox
    Friend WithEvents picICON As System.Windows.Forms.PictureBox
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents btnPaste As System.Windows.Forms.Button
    Friend WithEvents btnOther As System.Windows.Forms.Button

End Class
