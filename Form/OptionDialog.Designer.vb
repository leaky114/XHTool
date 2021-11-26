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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ComboBox6 = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Button清除 = New System.Windows.Forms.Button
        Me.Button还原 = New System.Windows.Forms.Button
        Me.Button添加 = New System.Windows.Forms.Button
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.ComboBox4 = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.ComboBox5 = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.CheckBox4 = New System.Windows.Forms.CheckBox
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.CheckBox5 = New System.Windows.Forms.CheckBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.TextBox9 = New System.Windows.Forms.TextBox
        Me.TextBox10 = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TextBox11 = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
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
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"零件代号", "库存编号", "描述"})
        Me.ComboBox1.Location = New System.Drawing.Point(85, 20)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(87, 20)
        Me.ComboBox1.TabIndex = 1
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"零件代号", "库存编号", "描述"})
        Me.ComboBox2.Location = New System.Drawing.Point(85, 49)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(87, 20)
        Me.ComboBox2.TabIndex = 2
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
        Me.GroupBox1.Controls.Add(Me.ComboBox6)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ComboBox2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(191, 101)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "IPro映射"
        '
        'ComboBox6
        '
        Me.ComboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox6.FormattingEnabled = True
        Me.ComboBox6.Items.AddRange(New Object() {"成本中心", "描述"})
        Me.ComboBox6.Location = New System.Drawing.Point(86, 75)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(86, 20)
        Me.ComboBox6.TabIndex = 6
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
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 129)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(191, 75)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "对称零件IPro映射"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(77, 45)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(95, 21)
        Me.TextBox2.TabIndex = 6
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(77, 18)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(95, 21)
        Me.TextBox1.TabIndex = 5
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
        Me.GroupBox4.Controls.Add(Me.CheckBox2)
        Me.GroupBox4.Controls.Add(Me.TextBox5)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.CheckBox1)
        Me.GroupBox4.Controls.Add(Me.TextBox4)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Location = New System.Drawing.Point(217, 14)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(207, 98)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "签字："
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(128, 77)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(72, 16)
        Me.CheckBox2.TabIndex = 10
        Me.CheckBox2.Text = "同时签字"
        Me.CheckBox2.UseVisualStyleBackColor = True
        Me.CheckBox2.Visible = False
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(83, 47)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(98, 21)
        Me.TextBox5.TabIndex = 9
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
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(14, 77)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(108, 16)
        Me.CheckBox1.TabIndex = 7
        Me.CheckBox1.Text = "签字后打开打印"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(83, 20)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(98, 21)
        Me.TextBox4.TabIndex = 6
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
        Me.GroupBox5.Controls.Add(Me.Button清除)
        Me.GroupBox5.Controls.Add(Me.Button还原)
        Me.GroupBox5.Controls.Add(Me.Button添加)
        Me.GroupBox5.Controls.Add(Me.ComboBox3)
        Me.GroupBox5.Controls.Add(Me.TextBox6)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Location = New System.Drawing.Point(16, 214)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(584, 84)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "BOM导出项目："
        '
        'Button清除
        '
        Me.Button清除.Location = New System.Drawing.Point(77, 47)
        Me.Button清除.Name = "Button清除"
        Me.Button清除.Size = New System.Drawing.Size(53, 25)
        Me.Button清除.TabIndex = 10
        Me.Button清除.Text = "清除"
        Me.Button清除.UseVisualStyleBackColor = True
        '
        'Button还原
        '
        Me.Button还原.Location = New System.Drawing.Point(14, 47)
        Me.Button还原.Name = "Button还原"
        Me.Button还原.Size = New System.Drawing.Size(53, 25)
        Me.Button还原.TabIndex = 9
        Me.Button还原.Text = "还原"
        Me.Button还原.UseVisualStyleBackColor = True
        '
        'Button添加
        '
        Me.Button添加.Location = New System.Drawing.Point(466, 45)
        Me.Button添加.Name = "Button添加"
        Me.Button添加.Size = New System.Drawing.Size(53, 25)
        Me.Button添加.TabIndex = 8
        Me.Button添加.Text = "添加"
        Me.Button添加.UseVisualStyleBackColor = True
        '
        'ComboBox3
        '
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"材料", "空格", "存货编号", "零件代号", "成本中心", "描述", "数量", "所属装配", "所属装配代号", "文件路径", "文件名", "质量", "面积", "总数量"})
        Me.ComboBox3.Location = New System.Drawing.Point(272, 50)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(170, 20)
        Me.ComboBox3.TabIndex = 7
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(86, 19)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(433, 21)
        Me.TextBox6.TabIndex = 6
        Me.TextBox6.Text = "库存编号|空格|零件代号|材料|质量|所属装配代号|数量|总数量|描述"
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
        'ComboBox4
        '
        Me.ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Items.AddRange(New Object() {"0", "0.1", "0.01", "0.001"})
        Me.ComboBox4.Location = New System.Drawing.Point(80, 20)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(66, 20)
        Me.ComboBox4.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(151, 40)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "比例："
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(80, 17)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(64, 21)
        Me.TextBox3.TabIndex = 6
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CheckBox3)
        Me.GroupBox3.Controls.Add(Me.TextBox3)
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
        Me.GroupBox6.Controls.Add(Me.ComboBox5)
        Me.GroupBox6.Controls.Add(Me.Label10)
        Me.GroupBox6.Controls.Add(Me.ComboBox4)
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.Location = New System.Drawing.Point(435, 14)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(165, 96)
        Me.GroupBox6.TabIndex = 11
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "精度设置"
        '
        'ComboBox5
        '
        Me.ComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Items.AddRange(New Object() {"0", "0.1", "0.01", "0.001", "0.0001", "0.00001"})
        Me.ComboBox5.Location = New System.Drawing.Point(80, 50)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(66, 20)
        Me.ComboBox5.TabIndex = 12
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
        Me.GroupBox7.Controls.Add(Me.TextBox7)
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
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(66, 17)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(112, 21)
        Me.TextBox7.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(12, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(215, 40)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "比例："
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Checked = True
        Me.CheckBox5.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox5.Location = New System.Drawing.Point(25, 406)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(108, 16)
        Me.CheckBox5.TabIndex = 13
        Me.CheckBox5.Text = "启动时检查更新"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.TextBox11)
        Me.GroupBox8.Controls.Add(Me.Label16)
        Me.GroupBox8.Controls.Add(Me.TextBox10)
        Me.GroupBox8.Controls.Add(Me.Label15)
        Me.GroupBox8.Controls.Add(Me.TextBox9)
        Me.GroupBox8.Controls.Add(Me.Label14)
        Me.GroupBox8.Controls.Add(Me.Button1)
        Me.GroupBox8.Controls.Add(Me.TextBox8)
        Me.GroupBox8.Controls.Add(Me.Label13)
        Me.GroupBox8.Location = New System.Drawing.Point(16, 308)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(582, 76)
        Me.GroupBox8.TabIndex = 14
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "ERP查询"
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
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(77, 19)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(433, 21)
        Me.TextBox8.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(532, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(33, 20)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
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
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(75, 48)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(69, 21)
        Me.TextBox9.TabIndex = 11
        Me.TextBox9.Text = "物料"
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(234, 48)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(89, 21)
        Me.TextBox10.TabIndex = 13
        Me.TextBox10.Text = "A:G"
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
        'TextBox11
        '
        Me.TextBox11.Location = New System.Drawing.Point(401, 50)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(89, 21)
        Me.TextBox11.TabIndex = 15
        Me.TextBox11.Text = "2,4"
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
        'OptionDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(618, 444)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.CheckBox5)
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
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button添加 As System.Windows.Forms.Button
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Button还原 As System.Windows.Forms.Button
    Friend WithEvents Button清除 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox5 As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ComboBox6 As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label

End Class
