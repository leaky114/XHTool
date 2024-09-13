<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSwitchLables
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
        Me.components = New System.ComponentModel.Container()
        Me.ContextMenuStrip右键 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem关闭文档 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem关闭窗口 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem设置 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel设置 = New System.Windows.Forms.Panel()
        Me.GroupBox设置 = New System.Windows.Forms.GroupBox()
        Me.txt列间距 = New System.Windows.Forms.TextBox()
        Me.txt行间距 = New System.Windows.Forms.TextBox()
        Me.txt图框高度 = New System.Windows.Forms.TextBox()
        Me.txt图框宽度 = New System.Windows.Forms.TextBox()
        Me.txt每行数量 = New System.Windows.Forms.TextBox()
        Me.lbl列间距 = New System.Windows.Forms.Label()
        Me.lbl行间距 = New System.Windows.Forms.Label()
        Me.lbl图框高度 = New System.Windows.Forms.Label()
        Me.lbl图框宽度 = New System.Windows.Forms.Label()
        Me.lbl每行数量 = New System.Windows.Forms.Label()
        Me.btn确定 = New System.Windows.Forms.Button()
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.ContextMenuStrip右键.SuspendLayout()
        Me.Panel设置.SuspendLayout()
        Me.GroupBox设置.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip右键
        '
        Me.ContextMenuStrip右键.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem关闭文档, Me.ToolStripMenuItem关闭窗口, Me.ToolStripMenuItem设置})
        Me.ContextMenuStrip右键.Name = "ContextMenuStrip右键"
        Me.ContextMenuStrip右键.Size = New System.Drawing.Size(125, 70)
        '
        'ToolStripMenuItem关闭文档
        '
        Me.ToolStripMenuItem关闭文档.Name = "ToolStripMenuItem关闭文档"
        Me.ToolStripMenuItem关闭文档.Size = New System.Drawing.Size(124, 22)
        Me.ToolStripMenuItem关闭文档.Text = "关闭文档"
        '
        'ToolStripMenuItem关闭窗口
        '
        Me.ToolStripMenuItem关闭窗口.Name = "ToolStripMenuItem关闭窗口"
        Me.ToolStripMenuItem关闭窗口.Size = New System.Drawing.Size(124, 22)
        Me.ToolStripMenuItem关闭窗口.Text = "关闭窗口"
        '
        'ToolStripMenuItem设置
        '
        Me.ToolStripMenuItem设置.Name = "ToolStripMenuItem设置"
        Me.ToolStripMenuItem设置.Size = New System.Drawing.Size(124, 22)
        Me.ToolStripMenuItem设置.Text = "设置"
        '
        'Panel设置
        '
        Me.Panel设置.Controls.Add(Me.GroupBox设置)
        Me.Panel设置.Location = New System.Drawing.Point(235, 68)
        Me.Panel设置.Name = "Panel设置"
        Me.Panel设置.Size = New System.Drawing.Size(220, 260)
        Me.Panel设置.TabIndex = 2
        Me.Panel设置.Visible = False
        '
        'GroupBox设置
        '
        Me.GroupBox设置.Controls.Add(Me.txt列间距)
        Me.GroupBox设置.Controls.Add(Me.txt行间距)
        Me.GroupBox设置.Controls.Add(Me.txt图框高度)
        Me.GroupBox设置.Controls.Add(Me.txt图框宽度)
        Me.GroupBox设置.Controls.Add(Me.txt每行数量)
        Me.GroupBox设置.Controls.Add(Me.lbl列间距)
        Me.GroupBox设置.Controls.Add(Me.lbl行间距)
        Me.GroupBox设置.Controls.Add(Me.lbl图框高度)
        Me.GroupBox设置.Controls.Add(Me.lbl图框宽度)
        Me.GroupBox设置.Controls.Add(Me.lbl每行数量)
        Me.GroupBox设置.Controls.Add(Me.btn确定)
        Me.GroupBox设置.Controls.Add(Me.btn关闭)
        Me.GroupBox设置.Location = New System.Drawing.Point(15, 10)
        Me.GroupBox设置.Name = "GroupBox设置"
        Me.GroupBox设置.Size = New System.Drawing.Size(190, 240)
        Me.GroupBox设置.TabIndex = 2
        Me.GroupBox设置.TabStop = False
        Me.GroupBox设置.Text = "设置"
        '
        'txt列间距
        '
        Me.txt列间距.Location = New System.Drawing.Point(86, 160)
        Me.txt列间距.Name = "txt列间距"
        Me.txt列间距.Size = New System.Drawing.Size(77, 21)
        Me.txt列间距.TabIndex = 29
        '
        'txt行间距
        '
        Me.txt行间距.Location = New System.Drawing.Point(86, 126)
        Me.txt行间距.Name = "txt行间距"
        Me.txt行间距.Size = New System.Drawing.Size(77, 21)
        Me.txt行间距.TabIndex = 28
        '
        'txt图框高度
        '
        Me.txt图框高度.Location = New System.Drawing.Point(86, 92)
        Me.txt图框高度.Name = "txt图框高度"
        Me.txt图框高度.Size = New System.Drawing.Size(77, 21)
        Me.txt图框高度.TabIndex = 27
        '
        'txt图框宽度
        '
        Me.txt图框宽度.Location = New System.Drawing.Point(86, 58)
        Me.txt图框宽度.Name = "txt图框宽度"
        Me.txt图框宽度.Size = New System.Drawing.Size(77, 21)
        Me.txt图框宽度.TabIndex = 26
        '
        'txt每行数量
        '
        Me.txt每行数量.Location = New System.Drawing.Point(86, 24)
        Me.txt每行数量.Name = "txt每行数量"
        Me.txt每行数量.Size = New System.Drawing.Size(77, 21)
        Me.txt每行数量.TabIndex = 25
        '
        'lbl列间距
        '
        Me.lbl列间距.AutoSize = True
        Me.lbl列间距.BackColor = System.Drawing.SystemColors.Window
        Me.lbl列间距.Location = New System.Drawing.Point(15, 164)
        Me.lbl列间距.Name = "lbl列间距"
        Me.lbl列间距.Size = New System.Drawing.Size(65, 12)
        Me.lbl列间距.TabIndex = 24
        Me.lbl列间距.Text = "列 间 距："
        '
        'lbl行间距
        '
        Me.lbl行间距.AutoSize = True
        Me.lbl行间距.Location = New System.Drawing.Point(15, 130)
        Me.lbl行间距.Name = "lbl行间距"
        Me.lbl行间距.Size = New System.Drawing.Size(65, 12)
        Me.lbl行间距.TabIndex = 23
        Me.lbl行间距.Text = "行 间 距："
        '
        'lbl图框高度
        '
        Me.lbl图框高度.AutoSize = True
        Me.lbl图框高度.Location = New System.Drawing.Point(15, 96)
        Me.lbl图框高度.Name = "lbl图框高度"
        Me.lbl图框高度.Size = New System.Drawing.Size(65, 12)
        Me.lbl图框高度.TabIndex = 22
        Me.lbl图框高度.Text = "图框高度："
        '
        'lbl图框宽度
        '
        Me.lbl图框宽度.AutoSize = True
        Me.lbl图框宽度.Location = New System.Drawing.Point(15, 62)
        Me.lbl图框宽度.Name = "lbl图框宽度"
        Me.lbl图框宽度.Size = New System.Drawing.Size(65, 12)
        Me.lbl图框宽度.TabIndex = 21
        Me.lbl图框宽度.Text = "图框宽度："
        '
        'lbl每行数量
        '
        Me.lbl每行数量.AutoSize = True
        Me.lbl每行数量.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lbl每行数量.Location = New System.Drawing.Point(15, 28)
        Me.lbl每行数量.Name = "lbl每行数量"
        Me.lbl每行数量.Size = New System.Drawing.Size(65, 12)
        Me.lbl每行数量.TabIndex = 20
        Me.lbl每行数量.Text = "每行数量："
        '
        'btn确定
        '
        Me.btn确定.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn确定.Location = New System.Drawing.Point(19, 196)
        Me.btn确定.Name = "btn确定"
        Me.btn确定.Size = New System.Drawing.Size(65, 25)
        Me.btn确定.TabIndex = 18
        Me.btn确定.Text = "确定"
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(92, 196)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(65, 25)
        Me.btn关闭.TabIndex = 19
        Me.btn关闭.Text = "取消"
        '
        'frmSwitchLables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(684, 411)
        Me.Controls.Add(Me.Panel设置)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSwitchLables"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.TopMost = True
        Me.ContextMenuStrip右键.ResumeLayout(False)
        Me.Panel设置.ResumeLayout(False)
        Me.GroupBox设置.ResumeLayout(False)
        Me.GroupBox设置.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip右键 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem关闭文档 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem设置 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem关闭窗口 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel设置 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox设置 As System.Windows.Forms.GroupBox
    Friend WithEvents txt列间距 As System.Windows.Forms.TextBox
    Friend WithEvents txt行间距 As System.Windows.Forms.TextBox
    Friend WithEvents txt图框高度 As System.Windows.Forms.TextBox
    Friend WithEvents txt图框宽度 As System.Windows.Forms.TextBox
    Friend WithEvents txt每行数量 As System.Windows.Forms.TextBox
    Friend WithEvents lbl列间距 As System.Windows.Forms.Label
    Friend WithEvents lbl行间距 As System.Windows.Forms.Label
    Friend WithEvents lbl图框高度 As System.Windows.Forms.Label
    Friend WithEvents lbl图框宽度 As System.Windows.Forms.Label
    Friend WithEvents lbl每行数量 As System.Windows.Forms.Label
    Friend WithEvents btn确定 As System.Windows.Forms.Button
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
End Class
