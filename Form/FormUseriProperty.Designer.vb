<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUseriProperty
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
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.btn确定 = New System.Windows.Forms.Button()
        Me.重新读取 = New System.Windows.Forms.Button()
        Me.btn配置文件 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(225, 224)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(70, 28)
        Me.btn关闭.TabIndex = 5
        Me.btn关闭.Text = "关闭"
        '
        'btn确定
        '
        Me.btn确定.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn确定.Location = New System.Drawing.Point(147, 224)
        Me.btn确定.Name = "btn确定"
        Me.btn确定.Size = New System.Drawing.Size(70, 28)
        Me.btn确定.TabIndex = 4
        Me.btn确定.Text = "确定"
        '
        '重新读取
        '
        Me.重新读取.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.重新读取.Location = New System.Drawing.Point(12, 224)
        Me.重新读取.Name = "重新读取"
        Me.重新读取.Size = New System.Drawing.Size(70, 28)
        Me.重新读取.TabIndex = 6
        Me.重新读取.Text = "重新读取"
        '
        'btn配置文件
        '
        Me.btn配置文件.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn配置文件.Location = New System.Drawing.Point(88, 225)
        Me.btn配置文件.Name = "btn配置文件"
        Me.btn配置文件.Size = New System.Drawing.Size(26, 26)
        Me.btn配置文件.TabIndex = 7
        Me.btn配置文件.UseVisualStyleBackColor = True
        '
        'FormUseriProperty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(307, 264)
        Me.Controls.Add(Me.btn配置文件)
        Me.Controls.Add(Me.重新读取)
        Me.Controls.Add(Me.btn关闭)
        Me.Controls.Add(Me.btn确定)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FormUseriProperty"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "iProperty-自定义"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents btn确定 As System.Windows.Forms.Button
    Friend WithEvents 重新读取 As System.Windows.Forms.Button
    Friend WithEvents btn配置文件 As System.Windows.Forms.Button
End Class
