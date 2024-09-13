<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSwitchLablesOption
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
        Me.btn确定 = New System.Windows.Forms.Button()
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.lbl行间距 = New System.Windows.Forms.Label()
        Me.lbl图框高度 = New System.Windows.Forms.Label()
        Me.lbl图框宽度 = New System.Windows.Forms.Label()
        Me.lbl每行数量 = New System.Windows.Forms.Label()
        Me.lbl列间距 = New System.Windows.Forms.Label()
        Me.txt每行数量 = New System.Windows.Forms.TextBox()
        Me.txt图框宽度 = New System.Windows.Forms.TextBox()
        Me.txt图框高度 = New System.Windows.Forms.TextBox()
        Me.txt行间距 = New System.Windows.Forms.TextBox()
        Me.txt列间距 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btn确定
        '
        Me.btn确定.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn确定.Location = New System.Drawing.Point(42, 190)
        Me.btn确定.Name = "btn确定"
        Me.btn确定.Size = New System.Drawing.Size(65, 25)
        Me.btn确定.TabIndex = 5
        Me.btn确定.Text = "确定"
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(115, 190)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(65, 25)
        Me.btn关闭.TabIndex = 6
        Me.btn关闭.Text = "取消"
        '
        'lbl行间距
        '
        Me.lbl行间距.AutoSize = True
        Me.lbl行间距.Location = New System.Drawing.Point(22, 122)
        Me.lbl行间距.Name = "lbl行间距"
        Me.lbl行间距.Size = New System.Drawing.Size(65, 12)
        Me.lbl行间距.TabIndex = 11
        Me.lbl行间距.Text = "行 间 距："
        '
        'lbl图框高度
        '
        Me.lbl图框高度.AutoSize = True
        Me.lbl图框高度.Location = New System.Drawing.Point(22, 88)
        Me.lbl图框高度.Name = "lbl图框高度"
        Me.lbl图框高度.Size = New System.Drawing.Size(65, 12)
        Me.lbl图框高度.TabIndex = 10
        Me.lbl图框高度.Text = "图框高度："
        '
        'lbl图框宽度
        '
        Me.lbl图框宽度.AutoSize = True
        Me.lbl图框宽度.Location = New System.Drawing.Point(22, 54)
        Me.lbl图框宽度.Name = "lbl图框宽度"
        Me.lbl图框宽度.Size = New System.Drawing.Size(65, 12)
        Me.lbl图框宽度.TabIndex = 9
        Me.lbl图框宽度.Text = "图框宽度："
        '
        'lbl每行数量
        '
        Me.lbl每行数量.AutoSize = True
        Me.lbl每行数量.Location = New System.Drawing.Point(22, 20)
        Me.lbl每行数量.Name = "lbl每行数量"
        Me.lbl每行数量.Size = New System.Drawing.Size(65, 12)
        Me.lbl每行数量.TabIndex = 8
        Me.lbl每行数量.Text = "每行数量："
        '
        'lbl列间距
        '
        Me.lbl列间距.AutoSize = True
        Me.lbl列间距.Location = New System.Drawing.Point(22, 156)
        Me.lbl列间距.Name = "lbl列间距"
        Me.lbl列间距.Size = New System.Drawing.Size(65, 12)
        Me.lbl列间距.TabIndex = 12
        Me.lbl列间距.Text = "列 间 距："
        '
        'txt每行数量
        '
        Me.txt每行数量.Location = New System.Drawing.Point(93, 16)
        Me.txt每行数量.Name = "txt每行数量"
        Me.txt每行数量.Size = New System.Drawing.Size(77, 21)
        Me.txt每行数量.TabIndex = 13
        '
        'txt图框宽度
        '
        Me.txt图框宽度.Location = New System.Drawing.Point(93, 50)
        Me.txt图框宽度.Name = "txt图框宽度"
        Me.txt图框宽度.Size = New System.Drawing.Size(77, 21)
        Me.txt图框宽度.TabIndex = 14
        '
        'txt图框高度
        '
        Me.txt图框高度.Location = New System.Drawing.Point(93, 84)
        Me.txt图框高度.Name = "txt图框高度"
        Me.txt图框高度.Size = New System.Drawing.Size(77, 21)
        Me.txt图框高度.TabIndex = 15
        '
        'txt行间距
        '
        Me.txt行间距.Location = New System.Drawing.Point(93, 118)
        Me.txt行间距.Name = "txt行间距"
        Me.txt行间距.Size = New System.Drawing.Size(77, 21)
        Me.txt行间距.TabIndex = 16
        '
        'txt列间距
        '
        Me.txt列间距.Location = New System.Drawing.Point(93, 152)
        Me.txt列间距.Name = "txt列间距"
        Me.txt列间距.Size = New System.Drawing.Size(77, 21)
        Me.txt列间距.TabIndex = 17
        '
        'frmSwitchLablesOption
        '
        Me.AcceptButton = Me.btn确定
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn关闭
        Me.ClientSize = New System.Drawing.Size(192, 227)
        Me.Controls.Add(Me.txt列间距)
        Me.Controls.Add(Me.txt行间距)
        Me.Controls.Add(Me.txt图框高度)
        Me.Controls.Add(Me.txt图框宽度)
        Me.Controls.Add(Me.txt每行数量)
        Me.Controls.Add(Me.lbl列间距)
        Me.Controls.Add(Me.lbl行间距)
        Me.Controls.Add(Me.lbl图框高度)
        Me.Controls.Add(Me.lbl图框宽度)
        Me.Controls.Add(Me.lbl每行数量)
        Me.Controls.Add(Me.btn确定)
        Me.Controls.Add(Me.btn关闭)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSwitchLablesOption"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "属性"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn确定 As System.Windows.Forms.Button
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents lbl行间距 As System.Windows.Forms.Label
    Friend WithEvents lbl图框高度 As System.Windows.Forms.Label
    Friend WithEvents lbl图框宽度 As System.Windows.Forms.Label
    Friend WithEvents lbl每行数量 As System.Windows.Forms.Label
    Friend WithEvents lbl列间距 As System.Windows.Forms.Label
    Friend WithEvents txt每行数量 As System.Windows.Forms.TextBox
    Friend WithEvents txt图框宽度 As System.Windows.Forms.TextBox
    Friend WithEvents txt图框高度 As System.Windows.Forms.TextBox
    Friend WithEvents txt行间距 As System.Windows.Forms.TextBox
    Friend WithEvents txt列间距 As System.Windows.Forms.TextBox
End Class
