<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBatchChangeFileNames
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
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.lbl图号 = New System.Windows.Forms.Label()
        Me.txt搜索字符串 = New System.Windows.Forms.TextBox()
        Me.txt替换为 = New System.Windows.Forms.TextBox()
        Me.lbl文件名 = New System.Windows.Forms.Label()
        Me.lbl描述 = New System.Windows.Forms.Label()
        Me.lbl材料 = New System.Windows.Forms.Label()
        Me.txt添加前缀 = New System.Windows.Forms.TextBox()
        Me.txt添加后缀 = New System.Windows.Forms.TextBox()
        Me.chk备份文件 = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'btn确定
        '
        Me.btn确定.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn确定.Location = New System.Drawing.Point(128, 150)
        Me.btn确定.Name = "btn确定"
        Me.btn确定.Size = New System.Drawing.Size(65, 28)
        Me.btn确定.TabIndex = 5
        Me.btn确定.Text = "确定"
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(201, 150)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(65, 28)
        Me.btn关闭.TabIndex = 6
        Me.btn关闭.Text = "关闭"
        '
        'lbl图号
        '
        Me.lbl图号.AutoSize = True
        Me.lbl图号.Location = New System.Drawing.Point(12, 22)
        Me.lbl图号.Name = "lbl图号"
        Me.lbl图号.Size = New System.Drawing.Size(77, 12)
        Me.lbl图号.TabIndex = 1
        Me.lbl图号.Text = "搜索字符串："
        '
        'txt搜索字符串
        '
        Me.txt搜索字符串.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt搜索字符串.Location = New System.Drawing.Point(101, 18)
        Me.txt搜索字符串.Name = "txt搜索字符串"
        Me.txt搜索字符串.Size = New System.Drawing.Size(168, 21)
        Me.txt搜索字符串.TabIndex = 0
        '
        'txt替换为
        '
        Me.txt替换为.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt替换为.Location = New System.Drawing.Point(101, 49)
        Me.txt替换为.Name = "txt替换为"
        Me.txt替换为.Size = New System.Drawing.Size(168, 21)
        Me.txt替换为.TabIndex = 1
        '
        'lbl文件名
        '
        Me.lbl文件名.AutoSize = True
        Me.lbl文件名.Location = New System.Drawing.Point(12, 53)
        Me.lbl文件名.Name = "lbl文件名"
        Me.lbl文件名.Size = New System.Drawing.Size(77, 12)
        Me.lbl文件名.TabIndex = 9
        Me.lbl文件名.Text = "替  换  为："
        '
        'lbl描述
        '
        Me.lbl描述.AutoSize = True
        Me.lbl描述.Location = New System.Drawing.Point(12, 82)
        Me.lbl描述.Name = "lbl描述"
        Me.lbl描述.Size = New System.Drawing.Size(83, 12)
        Me.lbl描述.TabIndex = 10
        Me.lbl描述.Text = "添 加 前 缀："
        '
        'lbl材料
        '
        Me.lbl材料.AutoSize = True
        Me.lbl材料.Location = New System.Drawing.Point(12, 110)
        Me.lbl材料.Name = "lbl材料"
        Me.lbl材料.Size = New System.Drawing.Size(83, 12)
        Me.lbl材料.TabIndex = 11
        Me.lbl材料.Text = "添 加 后 缀："
        '
        'txt添加前缀
        '
        Me.txt添加前缀.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt添加前缀.Location = New System.Drawing.Point(101, 82)
        Me.txt添加前缀.Name = "txt添加前缀"
        Me.txt添加前缀.Size = New System.Drawing.Size(168, 21)
        Me.txt添加前缀.TabIndex = 2
        '
        'txt添加后缀
        '
        Me.txt添加后缀.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt添加后缀.Location = New System.Drawing.Point(101, 110)
        Me.txt添加后缀.Name = "txt添加后缀"
        Me.txt添加后缀.Size = New System.Drawing.Size(168, 21)
        Me.txt添加后缀.TabIndex = 3
        '
        'chk备份文件
        '
        Me.chk备份文件.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chk备份文件.AutoSize = True
        Me.chk备份文件.Location = New System.Drawing.Point(14, 157)
        Me.chk备份文件.Name = "chk备份文件"
        Me.chk备份文件.Size = New System.Drawing.Size(72, 16)
        Me.chk备份文件.TabIndex = 4
        Me.chk备份文件.Text = "备份文件"
        Me.chk备份文件.UseVisualStyleBackColor = True
        '
        'FormBatchChangeFileNames
        '
        Me.AcceptButton = Me.btn确定
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn关闭
        Me.ClientSize = New System.Drawing.Size(280, 186)
        Me.Controls.Add(Me.chk备份文件)
        Me.Controls.Add(Me.txt添加前缀)
        Me.Controls.Add(Me.lbl材料)
        Me.Controls.Add(Me.lbl描述)
        Me.Controls.Add(Me.lbl文件名)
        Me.Controls.Add(Me.btn确定)
        Me.Controls.Add(Me.btn关闭)
        Me.Controls.Add(Me.txt添加后缀)
        Me.Controls.Add(Me.txt替换为)
        Me.Controls.Add(Me.txt搜索字符串)
        Me.Controls.Add(Me.lbl图号)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FormBatchChangeFileNames"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "批量重命名"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn确定 As System.Windows.Forms.Button
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents lbl图号 As System.Windows.Forms.Label
    Friend WithEvents txt搜索字符串 As System.Windows.Forms.TextBox
    Friend WithEvents txt替换为 As System.Windows.Forms.TextBox
    Friend WithEvents lbl文件名 As System.Windows.Forms.Label
    Friend WithEvents lbl描述 As System.Windows.Forms.Label
    Friend WithEvents lbl材料 As System.Windows.Forms.Label
    Friend WithEvents txt添加前缀 As System.Windows.Forms.TextBox
    Friend WithEvents txt添加后缀 As System.Windows.Forms.TextBox
    Friend WithEvents chk备份文件 As System.Windows.Forms.CheckBox

End Class
