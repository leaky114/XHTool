<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditDimension
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

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TrackBar参数一 = New System.Windows.Forms.TrackBar()
        Me.txt参数一 = New System.Windows.Forms.TextBox()
        Me.btn选择一 = New System.Windows.Forms.Button()
        Me.btn还原 = New System.Windows.Forms.Button()
        Me.btn确定 = New System.Windows.Forms.Button()
        CType(Me.TrackBar参数一, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrackBar参数一
        '
        Me.TrackBar参数一.AutoSize = False
        Me.TrackBar参数一.LargeChange = 1
        Me.TrackBar参数一.Location = New System.Drawing.Point(12, 52)
        Me.TrackBar参数一.Maximum = 50
        Me.TrackBar参数一.Minimum = -50
        Me.TrackBar参数一.Name = "TrackBar参数一"
        Me.TrackBar参数一.Size = New System.Drawing.Size(256, 20)
        Me.TrackBar参数一.TabIndex = 13
        Me.TrackBar参数一.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'txt参数一
        '
        Me.txt参数一.Location = New System.Drawing.Point(66, 18)
        Me.txt参数一.Name = "txt参数一"
        Me.txt参数一.Size = New System.Drawing.Size(93, 21)
        Me.txt参数一.TabIndex = 12
        '
        'btn选择一
        '
        Me.btn选择一.Location = New System.Drawing.Point(12, 14)
        Me.btn选择一.Name = "btn选择一"
        Me.btn选择一.Size = New System.Drawing.Size(36, 32)
        Me.btn选择一.TabIndex = 11
        Me.btn选择一.UseVisualStyleBackColor = True
        '
        'btn还原
        '
        Me.btn还原.Location = New System.Drawing.Point(178, 14)
        Me.btn还原.Name = "btn还原"
        Me.btn还原.Size = New System.Drawing.Size(36, 32)
        Me.btn还原.TabIndex = 14
        Me.btn还原.UseVisualStyleBackColor = True
        '
        'btn确定
        '
        Me.btn确定.Location = New System.Drawing.Point(226, 14)
        Me.btn确定.Name = "btn确定"
        Me.btn确定.Size = New System.Drawing.Size(36, 32)
        Me.btn确定.TabIndex = 15
        Me.btn确定.UseVisualStyleBackColor = True
        '
        'frmEditDimension
        '
        Me.AcceptButton = Me.btn确定
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(274, 83)
        Me.Controls.Add(Me.btn确定)
        Me.Controls.Add(Me.btn还原)
        Me.Controls.Add(Me.TrackBar参数一)
        Me.Controls.Add(Me.txt参数一)
        Me.Controls.Add(Me.btn选择一)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditDimension"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "编辑尺寸"
        Me.TopMost = True
        CType(Me.TrackBar参数一, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrackBar参数一 As System.Windows.Forms.TrackBar
    Friend WithEvents txt参数一 As System.Windows.Forms.TextBox
    Friend WithEvents btn选择一 As System.Windows.Forms.Button
    Friend WithEvents btn还原 As System.Windows.Forms.Button
    Friend WithEvents btn确定 As System.Windows.Forms.Button

End Class
