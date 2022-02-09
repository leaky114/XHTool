<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSign
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
        Me.lblEngineer = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.txtEngineer = New System.Windows.Forms.TextBox()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.chkSignPrint = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnOK.Location = New System.Drawing.Point(74, 109)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(65, 25)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "确定"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(147, 109)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(65, 25)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "取消"
        '
        'lblEngineer
        '
        Me.lblEngineer.AutoSize = True
        Me.lblEngineer.Location = New System.Drawing.Point(12, 9)
        Me.lblEngineer.Name = "lblEngineer"
        Me.lblEngineer.Size = New System.Drawing.Size(53, 12)
        Me.lblEngineer.TabIndex = 1
        Me.lblEngineer.Text = "工程师："
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(12, 35)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(47, 12)
        Me.lblDate.TabIndex = 2
        Me.lblDate.Text = "日 期："
        '
        'txtEngineer
        '
        Me.txtEngineer.Location = New System.Drawing.Point(67, 5)
        Me.txtEngineer.Name = "txtEngineer"
        Me.txtEngineer.Size = New System.Drawing.Size(136, 21)
        Me.txtEngineer.TabIndex = 3
        '
        'dtpDate
        '
        Me.dtpDate.Location = New System.Drawing.Point(64, 35)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(139, 21)
        Me.dtpDate.TabIndex = 4
        '
        'chkSignPrint
        '
        Me.chkSignPrint.AutoSize = True
        Me.chkSignPrint.Location = New System.Drawing.Point(12, 72)
        Me.chkSignPrint.Name = "chkSignPrint"
        Me.chkSignPrint.Size = New System.Drawing.Size(84, 16)
        Me.chkSignPrint.TabIndex = 5
        Me.chkSignPrint.Text = "签字后打印"
        Me.chkSignPrint.UseVisualStyleBackColor = True
        '
        'frmSign
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(226, 142)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.chkSignPrint)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.txtEngineer)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblEngineer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSign"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = " 签字"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblEngineer As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents txtEngineer As System.Windows.Forms.TextBox
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkSignPrint As System.Windows.Forms.CheckBox

End Class
