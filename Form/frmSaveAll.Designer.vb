<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSaveAll
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
        Me.grpType = New System.Windows.Forms.GroupBox()
        Me.chkIdw = New System.Windows.Forms.CheckBox()
        Me.chkPart = New System.Windows.Forms.CheckBox()
        Me.chkAsm = New System.Windows.Forms.CheckBox()
        Me.rdoSaveAll = New System.Windows.Forms.RadioButton()
        Me.rdoAllSaveClose = New System.Windows.Forms.RadioButton()
        Me.rdoAllClose = New System.Windows.Forms.RadioButton()
        Me.grpDo = New System.Windows.Forms.GroupBox()
        Me.grpType.SuspendLayout()
        Me.grpDo.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnOK.Location = New System.Drawing.Point(20, 247)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(65, 25)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "确定"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(93, 247)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(65, 25)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "取消"
        '
        'grpType
        '
        Me.grpType.Controls.Add(Me.chkIdw)
        Me.grpType.Controls.Add(Me.chkPart)
        Me.grpType.Controls.Add(Me.chkAsm)
        Me.grpType.Location = New System.Drawing.Point(22, 13)
        Me.grpType.Name = "grpType"
        Me.grpType.Size = New System.Drawing.Size(135, 102)
        Me.grpType.TabIndex = 1
        Me.grpType.TabStop = False
        Me.grpType.Text = "文件类型"
        '
        'chkIdw
        '
        Me.chkIdw.AutoSize = True
        Me.chkIdw.Checked = True
        Me.chkIdw.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIdw.Location = New System.Drawing.Point(23, 71)
        Me.chkIdw.Name = "chkIdw"
        Me.chkIdw.Size = New System.Drawing.Size(60, 16)
        Me.chkIdw.TabIndex = 2
        Me.chkIdw.Text = "工程图"
        Me.chkIdw.UseVisualStyleBackColor = True
        '
        'chkPart
        '
        Me.chkPart.AutoSize = True
        Me.chkPart.Checked = True
        Me.chkPart.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPart.Location = New System.Drawing.Point(23, 44)
        Me.chkPart.Name = "chkPart"
        Me.chkPart.Size = New System.Drawing.Size(48, 16)
        Me.chkPart.TabIndex = 1
        Me.chkPart.Text = "零件"
        Me.chkPart.UseVisualStyleBackColor = True
        '
        'chkAsm
        '
        Me.chkAsm.AutoSize = True
        Me.chkAsm.Checked = True
        Me.chkAsm.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAsm.Location = New System.Drawing.Point(23, 17)
        Me.chkAsm.Name = "chkAsm"
        Me.chkAsm.Size = New System.Drawing.Size(48, 16)
        Me.chkAsm.TabIndex = 0
        Me.chkAsm.Text = "部件"
        Me.chkAsm.UseVisualStyleBackColor = True
        '
        'rdoSaveAll
        '
        Me.rdoSaveAll.AutoSize = True
        Me.rdoSaveAll.Checked = True
        Me.rdoSaveAll.Location = New System.Drawing.Point(23, 23)
        Me.rdoSaveAll.Name = "rdoSaveAll"
        Me.rdoSaveAll.Size = New System.Drawing.Size(71, 16)
        Me.rdoSaveAll.TabIndex = 0
        Me.rdoSaveAll.TabStop = True
        Me.rdoSaveAll.Text = "全部保存"
        Me.rdoSaveAll.UseVisualStyleBackColor = True
        '
        'rdoAllSaveClose
        '
        Me.rdoAllSaveClose.AutoSize = True
        Me.rdoAllSaveClose.Location = New System.Drawing.Point(23, 47)
        Me.rdoAllSaveClose.Name = "rdoAllSaveClose"
        Me.rdoAllSaveClose.Size = New System.Drawing.Size(95, 16)
        Me.rdoAllSaveClose.TabIndex = 1
        Me.rdoAllSaveClose.TabStop = True
        Me.rdoAllSaveClose.Text = "全部保存关闭"
        Me.rdoAllSaveClose.UseVisualStyleBackColor = True
        '
        'rdoAllClose
        '
        Me.rdoAllClose.AutoSize = True
        Me.rdoAllClose.Location = New System.Drawing.Point(23, 71)
        Me.rdoAllClose.Name = "rdoAllClose"
        Me.rdoAllClose.Size = New System.Drawing.Size(71, 16)
        Me.rdoAllClose.TabIndex = 2
        Me.rdoAllClose.TabStop = True
        Me.rdoAllClose.Text = "全部关闭"
        Me.rdoAllClose.UseVisualStyleBackColor = True
        '
        'grpDo
        '
        Me.grpDo.Controls.Add(Me.rdoAllClose)
        Me.grpDo.Controls.Add(Me.rdoAllSaveClose)
        Me.grpDo.Controls.Add(Me.rdoSaveAll)
        Me.grpDo.Location = New System.Drawing.Point(22, 125)
        Me.grpDo.Name = "grpDo"
        Me.grpDo.Size = New System.Drawing.Size(132, 103)
        Me.grpDo.TabIndex = 2
        Me.grpDo.TabStop = False
        Me.grpDo.Text = "执行操作"
        '
        'frmSaveAll
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(172, 280)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.grpDo)
        Me.Controls.Add(Me.grpType)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSaveAll"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "全部保存"
        Me.grpType.ResumeLayout(False)
        Me.grpType.PerformLayout()
        Me.grpDo.ResumeLayout(False)
        Me.grpDo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents grpType As System.Windows.Forms.GroupBox
    Friend WithEvents chkPart As System.Windows.Forms.CheckBox
    Friend WithEvents chkAsm As System.Windows.Forms.CheckBox
    Friend WithEvents chkIdw As System.Windows.Forms.CheckBox
    Friend WithEvents rdoSaveAll As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAllSaveClose As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAllClose As System.Windows.Forms.RadioButton
    Friend WithEvents grpDo As System.Windows.Forms.GroupBox

End Class
