<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFlatPattern
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt位置 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt材质 = New System.Windows.Forms.TextBox()
        Me.cmb数量 = New System.Windows.Forms.ComboBox()
        Me.lbl数量 = New System.Windows.Forms.Label()
        Me.lbl材料 = New System.Windows.Forms.Label()
        Me.lbl文件名 = New System.Windows.Forms.Label()
        Me.btn向上1 = New System.Windows.Forms.Button()
        Me.txt文件名 = New System.Windows.Forms.TextBox()
        Me.txt图号 = New System.Windows.Forms.TextBox()
        Me.lbl图号 = New System.Windows.Forms.Label()
        Me.btn从部件选择 = New System.Windows.Forms.Button()
        Me.btn打开零件 = New System.Windows.Forms.Button()
        Me.btn添加展开图 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdo不插入 = New System.Windows.Forms.RadioButton()
        Me.rdo下视图 = New System.Windows.Forms.RadioButton()
        Me.rdo上视图 = New System.Windows.Forms.RadioButton()
        Me.rdo右视图 = New System.Windows.Forms.RadioButton()
        Me.rdo左视图 = New System.Windows.Forms.RadioButton()
        Me.rdo后视图 = New System.Windows.Forms.RadioButton()
        Me.rdo前视图 = New System.Windows.Forms.RadioButton()
        Me.btn选择当前零件 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt位置)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt材质)
        Me.GroupBox1.Controls.Add(Me.cmb数量)
        Me.GroupBox1.Controls.Add(Me.lbl数量)
        Me.GroupBox1.Controls.Add(Me.lbl材料)
        Me.GroupBox1.Controls.Add(Me.lbl文件名)
        Me.GroupBox1.Controls.Add(Me.btn向上1)
        Me.GroupBox1.Controls.Add(Me.txt文件名)
        Me.GroupBox1.Controls.Add(Me.txt图号)
        Me.GroupBox1.Controls.Add(Me.lbl图号)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(282, 193)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "数据"
        '
        'txt位置
        '
        Me.txt位置.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt位置.Location = New System.Drawing.Point(62, 122)
        Me.txt位置.Multiline = True
        Me.txt位置.Name = "txt位置"
        Me.txt位置.ReadOnly = True
        Me.txt位置.Size = New System.Drawing.Size(211, 65)
        Me.txt位置.TabIndex = 32
        Me.txt位置.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "位  置："
        '
        'txt材质
        '
        Me.txt材质.Location = New System.Drawing.Point(63, 86)
        Me.txt材质.Name = "txt材质"
        Me.txt材质.Size = New System.Drawing.Size(77, 21)
        Me.txt材质.TabIndex = 2
        '
        'cmb数量
        '
        Me.cmb数量.FormattingEnabled = True
        Me.cmb数量.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"})
        Me.cmb数量.Location = New System.Drawing.Point(220, 85)
        Me.cmb数量.Name = "cmb数量"
        Me.cmb数量.Size = New System.Drawing.Size(50, 20)
        Me.cmb数量.TabIndex = 3
        Me.cmb数量.Text = "1"
        '
        'lbl数量
        '
        Me.lbl数量.AutoSize = True
        Me.lbl数量.Location = New System.Drawing.Point(164, 90)
        Me.lbl数量.Name = "lbl数量"
        Me.lbl数量.Size = New System.Drawing.Size(53, 12)
        Me.lbl数量.TabIndex = 28
        Me.lbl数量.Text = "数  量："
        '
        'lbl材料
        '
        Me.lbl材料.AutoSize = True
        Me.lbl材料.Location = New System.Drawing.Point(11, 90)
        Me.lbl材料.Name = "lbl材料"
        Me.lbl材料.Size = New System.Drawing.Size(53, 12)
        Me.lbl材料.TabIndex = 27
        Me.lbl材料.Text = "材  料："
        '
        'lbl文件名
        '
        Me.lbl文件名.AutoSize = True
        Me.lbl文件名.Location = New System.Drawing.Point(11, 57)
        Me.lbl文件名.Name = "lbl文件名"
        Me.lbl文件名.Size = New System.Drawing.Size(53, 12)
        Me.lbl文件名.TabIndex = 26
        Me.lbl文件名.Text = "文件名："
        '
        'btn向上1
        '
        Me.btn向上1.Location = New System.Drawing.Point(211, 19)
        Me.btn向上1.Name = "btn向上1"
        Me.btn向上1.Size = New System.Drawing.Size(26, 26)
        Me.btn向上1.TabIndex = 25
        Me.btn向上1.UseVisualStyleBackColor = True
        '
        'txt文件名
        '
        Me.txt文件名.Location = New System.Drawing.Point(64, 53)
        Me.txt文件名.Name = "txt文件名"
        Me.txt文件名.Size = New System.Drawing.Size(137, 21)
        Me.txt文件名.TabIndex = 1
        '
        'txt图号
        '
        Me.txt图号.Location = New System.Drawing.Point(64, 22)
        Me.txt图号.Name = "txt图号"
        Me.txt图号.Size = New System.Drawing.Size(137, 21)
        Me.txt图号.TabIndex = 0
        '
        'lbl图号
        '
        Me.lbl图号.AutoSize = True
        Me.lbl图号.Location = New System.Drawing.Point(11, 26)
        Me.lbl图号.Name = "lbl图号"
        Me.lbl图号.Size = New System.Drawing.Size(53, 12)
        Me.lbl图号.TabIndex = 23
        Me.lbl图号.Text = "图  号："
        '
        'btn从部件选择
        '
        Me.btn从部件选择.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn从部件选择.Location = New System.Drawing.Point(14, 211)
        Me.btn从部件选择.Name = "btn从部件选择"
        Me.btn从部件选择.Size = New System.Drawing.Size(80, 28)
        Me.btn从部件选择.TabIndex = 4
        Me.btn从部件选择.Text = "从部件选择"
        Me.btn从部件选择.UseVisualStyleBackColor = True
        '
        'btn打开零件
        '
        Me.btn打开零件.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn打开零件.Location = New System.Drawing.Point(102, 211)
        Me.btn打开零件.Name = "btn打开零件"
        Me.btn打开零件.Size = New System.Drawing.Size(80, 28)
        Me.btn打开零件.TabIndex = 5
        Me.btn打开零件.Text = "打开零件"
        Me.btn打开零件.UseVisualStyleBackColor = True
        '
        'btn添加展开图
        '
        Me.btn添加展开图.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn添加展开图.Location = New System.Drawing.Point(326, 210)
        Me.btn添加展开图.Name = "btn添加展开图"
        Me.btn添加展开图.Size = New System.Drawing.Size(80, 28)
        Me.btn添加展开图.TabIndex = 6
        Me.btn添加展开图.Text = "插入工艺图"
        Me.btn添加展开图.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.rdo不插入)
        Me.GroupBox2.Controls.Add(Me.rdo下视图)
        Me.GroupBox2.Controls.Add(Me.rdo上视图)
        Me.GroupBox2.Controls.Add(Me.rdo右视图)
        Me.GroupBox2.Controls.Add(Me.rdo左视图)
        Me.GroupBox2.Controls.Add(Me.rdo后视图)
        Me.GroupBox2.Controls.Add(Me.rdo前视图)
        Me.GroupBox2.Location = New System.Drawing.Point(306, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(100, 193)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "折弯视图"
        '
        'rdo不插入
        '
        Me.rdo不插入.AutoSize = True
        Me.rdo不插入.Location = New System.Drawing.Point(25, 167)
        Me.rdo不插入.Name = "rdo不插入"
        Me.rdo不插入.Size = New System.Drawing.Size(59, 16)
        Me.rdo不插入.TabIndex = 1
        Me.rdo不插入.Text = "不插入"
        Me.rdo不插入.UseVisualStyleBackColor = True
        '
        'rdo下视图
        '
        Me.rdo下视图.AutoSize = True
        Me.rdo下视图.Location = New System.Drawing.Point(25, 143)
        Me.rdo下视图.Name = "rdo下视图"
        Me.rdo下视图.Size = New System.Drawing.Size(59, 16)
        Me.rdo下视图.TabIndex = 0
        Me.rdo下视图.TabStop = True
        Me.rdo下视图.Text = "下视图"
        Me.rdo下视图.UseVisualStyleBackColor = True
        '
        'rdo上视图
        '
        Me.rdo上视图.AutoSize = True
        Me.rdo上视图.Location = New System.Drawing.Point(25, 119)
        Me.rdo上视图.Name = "rdo上视图"
        Me.rdo上视图.Size = New System.Drawing.Size(59, 16)
        Me.rdo上视图.TabIndex = 0
        Me.rdo上视图.TabStop = True
        Me.rdo上视图.Text = "上视图"
        Me.rdo上视图.UseVisualStyleBackColor = True
        '
        'rdo右视图
        '
        Me.rdo右视图.AutoSize = True
        Me.rdo右视图.Location = New System.Drawing.Point(25, 95)
        Me.rdo右视图.Name = "rdo右视图"
        Me.rdo右视图.Size = New System.Drawing.Size(59, 16)
        Me.rdo右视图.TabIndex = 0
        Me.rdo右视图.TabStop = True
        Me.rdo右视图.Text = "右视图"
        Me.rdo右视图.UseVisualStyleBackColor = True
        '
        'rdo左视图
        '
        Me.rdo左视图.AutoSize = True
        Me.rdo左视图.Location = New System.Drawing.Point(25, 71)
        Me.rdo左视图.Name = "rdo左视图"
        Me.rdo左视图.Size = New System.Drawing.Size(59, 16)
        Me.rdo左视图.TabIndex = 0
        Me.rdo左视图.TabStop = True
        Me.rdo左视图.Text = "左视图"
        Me.rdo左视图.UseVisualStyleBackColor = True
        '
        'rdo后视图
        '
        Me.rdo后视图.AutoSize = True
        Me.rdo后视图.Location = New System.Drawing.Point(25, 47)
        Me.rdo后视图.Name = "rdo后视图"
        Me.rdo后视图.Size = New System.Drawing.Size(59, 16)
        Me.rdo后视图.TabIndex = 0
        Me.rdo后视图.TabStop = True
        Me.rdo后视图.Text = "后视图"
        Me.rdo后视图.UseVisualStyleBackColor = True
        '
        'rdo前视图
        '
        Me.rdo前视图.AutoSize = True
        Me.rdo前视图.Checked = True
        Me.rdo前视图.Location = New System.Drawing.Point(25, 23)
        Me.rdo前视图.Name = "rdo前视图"
        Me.rdo前视图.Size = New System.Drawing.Size(59, 16)
        Me.rdo前视图.TabIndex = 0
        Me.rdo前视图.TabStop = True
        Me.rdo前视图.Text = "前视图"
        Me.rdo前视图.UseVisualStyleBackColor = True
        '
        'btn选择当前零件
        '
        Me.btn选择当前零件.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn选择当前零件.Location = New System.Drawing.Point(189, 211)
        Me.btn选择当前零件.Name = "btn选择当前零件"
        Me.btn选择当前零件.Size = New System.Drawing.Size(95, 28)
        Me.btn选择当前零件.TabIndex = 23
        Me.btn选择当前零件.Text = "选择当前零件"
        Me.btn选择当前零件.UseVisualStyleBackColor = True
        '
        'FormFlatPattern
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 253)
        Me.Controls.Add(Me.btn选择当前零件)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btn添加展开图)
        Me.Controls.Add(Me.btn打开零件)
        Me.Controls.Add(Me.btn从部件选择)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FormFlatPattern"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "工艺图"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmb数量 As System.Windows.Forms.ComboBox
    Friend WithEvents lbl数量 As System.Windows.Forms.Label
    Friend WithEvents lbl材料 As System.Windows.Forms.Label
    Friend WithEvents lbl文件名 As System.Windows.Forms.Label
    Friend WithEvents btn向上1 As System.Windows.Forms.Button
    Friend WithEvents txt文件名 As System.Windows.Forms.TextBox
    Friend WithEvents txt图号 As System.Windows.Forms.TextBox
    Friend WithEvents lbl图号 As System.Windows.Forms.Label
    Friend WithEvents btn从部件选择 As System.Windows.Forms.Button
    Friend WithEvents btn打开零件 As System.Windows.Forms.Button
    Friend WithEvents btn添加展开图 As System.Windows.Forms.Button
    Friend WithEvents txt材质 As System.Windows.Forms.TextBox
    Friend WithEvents txt位置 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdo不插入 As System.Windows.Forms.RadioButton
    Friend WithEvents rdo下视图 As System.Windows.Forms.RadioButton
    Friend WithEvents rdo上视图 As System.Windows.Forms.RadioButton
    Friend WithEvents rdo右视图 As System.Windows.Forms.RadioButton
    Friend WithEvents rdo左视图 As System.Windows.Forms.RadioButton
    Friend WithEvents rdo后视图 As System.Windows.Forms.RadioButton
    Friend WithEvents rdo前视图 As System.Windows.Forms.RadioButton
    Friend WithEvents btn选择当前零件 As System.Windows.Forms.Button
End Class
