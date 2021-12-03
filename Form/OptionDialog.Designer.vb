<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionDialog
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.cbo图号 = New System.Windows.Forms.ComboBox()
        Me.cbo文件名 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbo存货编码 = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txt文件名映射 = New System.Windows.Forms.TextBox()
        Me.txt图号映射 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chk签字 = New System.Windows.Forms.CheckBox()
        Me.txt工程师 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chk签字后打印 = New System.Windows.Forms.CheckBox()
        Me.txt打印日期 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btn清除 = New System.Windows.Forms.Button()
        Me.btn还原 = New System.Windows.Forms.Button()
        Me.btn添加 = New System.Windows.Forms.Button()
        Me.cbo添加 = New System.Windows.Forms.ComboBox()
        Me.txtBOM导出项 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbo质量精度 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt比例 = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cbo面积精度 = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.txt图号 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chk检查更新 = New System.Windows.Forms.CheckBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.txt查询列 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt查找范围 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt数据表 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnexcel文件 = New System.Windows.Forms.Button()
        Me.txtexcel文件 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(413, 392)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(193, 42)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(7, 7)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(81, 28)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "确定"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(105, 7)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(78, 28)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "取消"
        '
        'cbo图号
        '
        Me.cbo图号.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo图号.FormattingEnabled = True
        Me.cbo图号.Items.AddRange(New Object() {"零件代号", "库存编号", "描述"})
        Me.cbo图号.Location = New System.Drawing.Point(85, 20)
        Me.cbo图号.Name = "cbo图号"
        Me.cbo图号.Size = New System.Drawing.Size(87, 20)
        Me.cbo图号.TabIndex = 1
        '
        'cbo文件名
        '
        Me.cbo文件名.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo文件名.FormattingEnabled = True
        Me.cbo文件名.Items.AddRange(New Object() {"零件代号", "库存编号", "描述"})
        Me.cbo文件名.Location = New System.Drawing.Point(85, 49)
        Me.cbo文件名.Name = "cbo文件名"
        Me.cbo文件名.Size = New System.Drawing.Size(87, 20)
        Me.cbo文件名.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "图  号："
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbo存货编码)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbo文件名)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbo图号)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(191, 101)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "IPro映射"
        '
        'cbo存货编码
        '
        Me.cbo存货编码.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo存货编码.FormattingEnabled = True
        Me.cbo存货编码.Items.AddRange(New Object() {"成本中心", "描述"})
        Me.cbo存货编码.Location = New System.Drawing.Point(86, 75)
        Me.cbo存货编码.Name = "cbo存货编码"
        Me.cbo存货编码.Size = New System.Drawing.Size(86, 20)
        Me.cbo存货编码.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(22, 77)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 12)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "存货编码："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "文件名："
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txt文件名映射)
        Me.GroupBox2.Controls.Add(Me.txt图号映射)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 129)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(191, 75)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "对称零件IPro映射"
        '
        'txt文件名映射
        '
        Me.txt文件名映射.Location = New System.Drawing.Point(77, 45)
        Me.txt文件名映射.Name = "txt文件名映射"
        Me.txt文件名映射.Size = New System.Drawing.Size(95, 21)
        Me.txt文件名映射.TabIndex = 6
        '
        'txt图号映射
        '
        Me.txt图号映射.Location = New System.Drawing.Point(77, 18)
        Me.txt图号映射.Name = "txt图号映射"
        Me.txt图号映射.Size = New System.Drawing.Size(95, 21)
        Me.txt图号映射.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "文件名："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "图  号："
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chk签字)
        Me.GroupBox4.Controls.Add(Me.txt工程师)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.chk签字后打印)
        Me.GroupBox4.Controls.Add(Me.txt打印日期)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Location = New System.Drawing.Point(217, 14)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(207, 98)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "签字："
        '
        'chk签字
        '
        Me.chk签字.AutoSize = True
        Me.chk签字.Location = New System.Drawing.Point(128, 77)
        Me.chk签字.Name = "chk签字"
        Me.chk签字.Size = New System.Drawing.Size(72, 16)
        Me.chk签字.TabIndex = 10
        Me.chk签字.Text = "同时签字"
        Me.chk签字.UseVisualStyleBackColor = True
        Me.chk签字.Visible = False
        '
        'txt工程师
        '
        Me.txt工程师.Location = New System.Drawing.Point(83, 47)
        Me.txt工程师.Name = "txt工程师"
        Me.txt工程师.Size = New System.Drawing.Size(98, 21)
        Me.txt工程师.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "工程师："
        '
        'chk签字后打印
        '
        Me.chk签字后打印.AutoSize = True
        Me.chk签字后打印.Location = New System.Drawing.Point(14, 77)
        Me.chk签字后打印.Name = "chk签字后打印"
        Me.chk签字后打印.Size = New System.Drawing.Size(108, 16)
        Me.chk签字后打印.TabIndex = 7
        Me.chk签字后打印.Text = "签字后打开打印"
        Me.chk签字后打印.UseVisualStyleBackColor = True
        '
        'txt打印日期
        '
        Me.txt打印日期.Location = New System.Drawing.Point(83, 20)
        Me.txt打印日期.Name = "txt打印日期"
        Me.txt打印日期.Size = New System.Drawing.Size(98, 21)
        Me.txt打印日期.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "打印日期："
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btn清除)
        Me.GroupBox5.Controls.Add(Me.btn还原)
        Me.GroupBox5.Controls.Add(Me.btn添加)
        Me.GroupBox5.Controls.Add(Me.cbo添加)
        Me.GroupBox5.Controls.Add(Me.txtBOM导出项)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Location = New System.Drawing.Point(16, 214)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(584, 84)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "BOM导出项目："
        '
        'btn清除
        '
        Me.btn清除.Location = New System.Drawing.Point(77, 47)
        Me.btn清除.Name = "btn清除"
        Me.btn清除.Size = New System.Drawing.Size(53, 25)
        Me.btn清除.TabIndex = 10
        Me.btn清除.Text = "清除"
        Me.btn清除.UseVisualStyleBackColor = True
        '
        'btn还原
        '
        Me.btn还原.Location = New System.Drawing.Point(14, 47)
        Me.btn还原.Name = "btn还原"
        Me.btn还原.Size = New System.Drawing.Size(53, 25)
        Me.btn还原.TabIndex = 9
        Me.btn还原.Text = "还原"
        Me.btn还原.UseVisualStyleBackColor = True
        '
        'btn添加
        '
        Me.btn添加.Location = New System.Drawing.Point(466, 45)
        Me.btn添加.Name = "btn添加"
        Me.btn添加.Size = New System.Drawing.Size(53, 25)
        Me.btn添加.TabIndex = 8
        Me.btn添加.Text = "添加"
        Me.btn添加.UseVisualStyleBackColor = True
        '
        'cbo添加
        '
        Me.cbo添加.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo添加.FormattingEnabled = True
        Me.cbo添加.Items.AddRange(New Object() {"材料", "空格", "存货编号", "零件代号", "成本中心", "描述", "数量", "所属装配", "所属装配代号", "文件路径", "文件名", "质量", "面积", "总数量"})
        Me.cbo添加.Location = New System.Drawing.Point(272, 50)
        Me.cbo添加.Name = "cbo添加"
        Me.cbo添加.Size = New System.Drawing.Size(170, 20)
        Me.cbo添加.TabIndex = 7
        '
        'txtBOM导出项
        '
        Me.txtBOM导出项.Location = New System.Drawing.Point(86, 19)
        Me.txtBOM导出项.Name = "txtBOM导出项"
        Me.txtBOM导出项.Size = New System.Drawing.Size(433, 21)
        Me.txtBOM导出项.TabIndex = 6
        Me.txtBOM导出项.Text = "库存编号|空格|零件代号|材料|质量|所属装配代号|数量|总数量|描述"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 12)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "BOM导出项目："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 12)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "质量精度："
        '
        'cbo质量精度
        '
        Me.cbo质量精度.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo质量精度.FormattingEnabled = True
        Me.cbo质量精度.Items.AddRange(New Object() {"0", "0.1", "0.01", "0.001"})
        Me.cbo质量精度.Location = New System.Drawing.Point(80, 20)
        Me.cbo质量精度.Name = "cbo质量精度"
        Me.cbo质量精度.Size = New System.Drawing.Size(66, 20)
        Me.cbo质量精度.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(151, 40)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "比例："
        '
        'txt比例
        '
        Me.txt比例.Location = New System.Drawing.Point(80, 17)
        Me.txt比例.Name = "txt比例"
        Me.txt比例.Size = New System.Drawing.Size(64, 21)
        Me.txt比例.TabIndex = 6
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CheckBox3)
        Me.GroupBox3.Controls.Add(Me.txt比例)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(435, 129)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(163, 68)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "比例映射："
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Checked = True
        Me.CheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox3.Location = New System.Drawing.Point(18, 42)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(120, 16)
        Me.CheckBox3.TabIndex = 7
        Me.CheckBox3.Text = "保存工程图时写入"
        Me.CheckBox3.UseVisualStyleBackColor = True
        Me.CheckBox3.Visible = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cbo面积精度)
        Me.GroupBox6.Controls.Add(Me.Label10)
        Me.GroupBox6.Controls.Add(Me.cbo质量精度)
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.Location = New System.Drawing.Point(435, 14)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(165, 96)
        Me.GroupBox6.TabIndex = 11
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "精度设置"
        '
        'cbo面积精度
        '
        Me.cbo面积精度.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo面积精度.FormattingEnabled = True
        Me.cbo面积精度.Items.AddRange(New Object() {"0", "0.1", "0.01", "0.001", "0.0001", "0.00001"})
        Me.cbo面积精度.Location = New System.Drawing.Point(80, 50)
        Me.cbo面积精度.Name = "cbo面积精度"
        Me.cbo面积精度.Size = New System.Drawing.Size(66, 20)
        Me.cbo面积精度.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 54)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 12)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "面积精度："
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.CheckBox4)
        Me.GroupBox7.Controls.Add(Me.txt图号)
        Me.GroupBox7.Controls.Add(Me.Label11)
        Me.GroupBox7.Location = New System.Drawing.Point(217, 129)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(204, 68)
        Me.GroupBox7.TabIndex = 12
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "质量映射："
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Checked = True
        Me.CheckBox4.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox4.Location = New System.Drawing.Point(18, 42)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(120, 16)
        Me.CheckBox4.TabIndex = 7
        Me.CheckBox4.Text = "保存工程图时写入"
        Me.CheckBox4.UseVisualStyleBackColor = True
        Me.CheckBox4.Visible = False
        '
        'txt图号
        '
        Me.txt图号.Location = New System.Drawing.Point(66, 17)
        Me.txt图号.Name = "txt图号"
        Me.txt图号.Size = New System.Drawing.Size(112, 21)
        Me.txt图号.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(12, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(215, 40)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "比例："
        '
        'chk检查更新
        '
        Me.chk检查更新.AutoSize = True
        Me.chk检查更新.Checked = True
        Me.chk检查更新.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk检查更新.Location = New System.Drawing.Point(25, 406)
        Me.chk检查更新.Name = "chk检查更新"
        Me.chk检查更新.Size = New System.Drawing.Size(108, 16)
        Me.chk检查更新.TabIndex = 13
        Me.chk检查更新.Text = "启动时检查更新"
        Me.chk检查更新.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.txt查询列)
        Me.GroupBox8.Controls.Add(Me.Label16)
        Me.GroupBox8.Controls.Add(Me.txt查找范围)
        Me.GroupBox8.Controls.Add(Me.Label15)
        Me.GroupBox8.Controls.Add(Me.txt数据表)
        Me.GroupBox8.Controls.Add(Me.Label14)
        Me.GroupBox8.Controls.Add(Me.btnexcel文件)
        Me.GroupBox8.Controls.Add(Me.txtexcel文件)
        Me.GroupBox8.Controls.Add(Me.Label13)
        Me.GroupBox8.Location = New System.Drawing.Point(16, 308)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(582, 76)
        Me.GroupBox8.TabIndex = 14
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "ERP查询"
        '
        'txt查询列
        '
        Me.txt查询列.Location = New System.Drawing.Point(401, 50)
        Me.txt查询列.Name = "txt查询列"
        Me.txt查询列.Size = New System.Drawing.Size(89, 21)
        Me.txt查询列.TabIndex = 15
        Me.txt查询列.Text = "2"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(346, 54)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 12)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "查询列："
        '
        'txt查找范围
        '
        Me.txt查找范围.Location = New System.Drawing.Point(234, 48)
        Me.txt查找范围.Name = "txt查找范围"
        Me.txt查找范围.Size = New System.Drawing.Size(89, 21)
        Me.txt查找范围.TabIndex = 13
        Me.txt查找范围.Text = "A:G"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(167, 52)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 12)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "查询范围："
        '
        'txt数据表
        '
        Me.txt数据表.Location = New System.Drawing.Point(75, 48)
        Me.txt数据表.Name = "txt数据表"
        Me.txt数据表.Size = New System.Drawing.Size(69, 21)
        Me.txt数据表.TabIndex = 11
        Me.txt数据表.Text = "物料"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 52)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 12)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "数 据 表："
        '
        'btnexcel文件
        '
        Me.btnexcel文件.Location = New System.Drawing.Point(532, 19)
        Me.btnexcel文件.Name = "btnexcel文件"
        Me.btnexcel文件.Size = New System.Drawing.Size(33, 20)
        Me.btnexcel文件.TabIndex = 9
        Me.btnexcel文件.Text = "..."
        Me.btnexcel文件.UseVisualStyleBackColor = True
        '
        'txtexcel文件
        '
        Me.txtexcel文件.Location = New System.Drawing.Point(77, 19)
        Me.txtexcel文件.Name = "txtexcel文件"
        Me.txtexcel文件.Size = New System.Drawing.Size(433, 21)
        Me.txtexcel文件.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 12)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "Excel文件："
        '
        'OptionDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(618, 444)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.chk检查更新)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OptionDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "设置"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents cbo图号 As System.Windows.Forms.ComboBox
    Friend WithEvents cbo文件名 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt文件名映射 As System.Windows.Forms.TextBox
    Friend WithEvents txt图号映射 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chk签字后打印 As System.Windows.Forms.CheckBox
    Friend WithEvents txt打印日期 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chk签字 As System.Windows.Forms.CheckBox
    Friend WithEvents txt工程师 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtBOM导出项 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btn添加 As System.Windows.Forms.Button
    Friend WithEvents cbo添加 As System.Windows.Forms.ComboBox
    Friend WithEvents btn还原 As System.Windows.Forms.Button
    Friend WithEvents btn清除 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbo质量精度 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt比例 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo面积精度 As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents txt图号 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbo存货编码 As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chk检查更新 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents btnexcel文件 As System.Windows.Forms.Button
    Friend WithEvents txtexcel文件 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt查找范围 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt数据表 As System.Windows.Forms.TextBox
    Friend WithEvents txt查询列 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label

End Class
