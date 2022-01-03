<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iPopertiesDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.addfile = New System.Windows.Forms.Button()
        Me.clearlist = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DateTimeP = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DoubleP = New System.Windows.Forms.TextBox()
        Me.PropertyName = New System.Windows.Forms.TextBox()
        Me.StringP = New System.Windows.Forms.TextBox()
        Me.StringRadioButton = New System.Windows.Forms.RadioButton()
        Me.BoolRadioButton = New System.Windows.Forms.RadioButton()
        Me.DateRadioButton = New System.Windows.Forms.RadioButton()
        Me.DoubleRadioButton = New System.Windows.Forms.RadioButton()
        Me.BoolP = New System.Windows.Forms.CheckBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.Location = New System.Drawing.Point(169, 189)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(57, 33)
        Me.OK_Button.TabIndex = 1
        Me.OK_Button.Text = "开始"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(230, 189)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(57, 33)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "关闭"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 12
        Me.ListBox1.Location = New System.Drawing.Point(12, 190)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(271, 148)
        Me.ListBox1.TabIndex = 15
        Me.ListBox1.Visible = False
        '
        'addfile
        '
        Me.addfile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.addfile.Location = New System.Drawing.Point(12, 189)
        Me.addfile.Name = "addfile"
        Me.addfile.Size = New System.Drawing.Size(69, 33)
        Me.addfile.TabIndex = 0
        Me.addfile.Text = "添加文件"
        Me.addfile.UseVisualStyleBackColor = True
        Me.addfile.Visible = False
        '
        'clearlist
        '
        Me.clearlist.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.clearlist.Location = New System.Drawing.Point(86, 189)
        Me.clearlist.Name = "clearlist"
        Me.clearlist.Size = New System.Drawing.Size(69, 33)
        Me.clearlist.TabIndex = 20
        Me.clearlist.Text = "清除列表"
        Me.clearlist.UseVisualStyleBackColor = True
        Me.clearlist.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DateTimeP)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.DoubleP)
        Me.TabPage2.Controls.Add(Me.PropertyName)
        Me.TabPage2.Controls.Add(Me.StringP)
        Me.TabPage2.Controls.Add(Me.StringRadioButton)
        Me.TabPage2.Controls.Add(Me.BoolRadioButton)
        Me.TabPage2.Controls.Add(Me.DateRadioButton)
        Me.TabPage2.Controls.Add(Me.DoubleRadioButton)
        Me.TabPage2.Controls.Add(Me.BoolP)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(267, 146)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "自定义"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DateTimeP
        '
        Me.DateTimeP.Location = New System.Drawing.Point(81, 115)
        Me.DateTimeP.Name = "DateTimeP"
        Me.DateTimeP.Size = New System.Drawing.Size(127, 21)
        Me.DateTimeP.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "特性名"
        '
        'DoubleP
        '
        Me.DoubleP.Location = New System.Drawing.Point(81, 87)
        Me.DoubleP.Name = "DoubleP"
        Me.DoubleP.Size = New System.Drawing.Size(127, 21)
        Me.DoubleP.TabIndex = 4
        '
        'PropertyName
        '
        Me.PropertyName.Location = New System.Drawing.Point(81, 9)
        Me.PropertyName.Name = "PropertyName"
        Me.PropertyName.Size = New System.Drawing.Size(127, 21)
        Me.PropertyName.TabIndex = 12
        '
        'StringP
        '
        Me.StringP.Location = New System.Drawing.Point(81, 36)
        Me.StringP.Name = "StringP"
        Me.StringP.Size = New System.Drawing.Size(127, 21)
        Me.StringP.TabIndex = 2
        '
        'StringRadioButton
        '
        Me.StringRadioButton.AutoSize = True
        Me.StringRadioButton.Location = New System.Drawing.Point(15, 43)
        Me.StringRadioButton.Name = "StringRadioButton"
        Me.StringRadioButton.Size = New System.Drawing.Size(47, 16)
        Me.StringRadioButton.TabIndex = 6
        Me.StringRadioButton.TabStop = True
        Me.StringRadioButton.Text = "字串"
        Me.StringRadioButton.UseVisualStyleBackColor = True
        '
        'BoolRadioButton
        '
        Me.BoolRadioButton.AutoSize = True
        Me.BoolRadioButton.Location = New System.Drawing.Point(15, 67)
        Me.BoolRadioButton.Name = "BoolRadioButton"
        Me.BoolRadioButton.Size = New System.Drawing.Size(59, 16)
        Me.BoolRadioButton.TabIndex = 7
        Me.BoolRadioButton.TabStop = True
        Me.BoolRadioButton.Text = "布尔值"
        Me.BoolRadioButton.UseVisualStyleBackColor = True
        '
        'DateRadioButton
        '
        Me.DateRadioButton.AutoSize = True
        Me.DateRadioButton.Location = New System.Drawing.Point(15, 115)
        Me.DateRadioButton.Name = "DateRadioButton"
        Me.DateRadioButton.Size = New System.Drawing.Size(47, 16)
        Me.DateRadioButton.TabIndex = 9
        Me.DateRadioButton.TabStop = True
        Me.DateRadioButton.Text = "日期"
        Me.DateRadioButton.UseVisualStyleBackColor = True
        '
        'DoubleRadioButton
        '
        Me.DoubleRadioButton.AutoSize = True
        Me.DoubleRadioButton.Location = New System.Drawing.Point(15, 91)
        Me.DoubleRadioButton.Name = "DoubleRadioButton"
        Me.DoubleRadioButton.Size = New System.Drawing.Size(47, 16)
        Me.DoubleRadioButton.TabIndex = 8
        Me.DoubleRadioButton.TabStop = True
        Me.DoubleRadioButton.Text = "实数"
        Me.DoubleRadioButton.UseVisualStyleBackColor = True
        '
        'BoolP
        '
        Me.BoolP.AutoSize = True
        Me.BoolP.Location = New System.Drawing.Point(83, 64)
        Me.BoolP.Name = "BoolP"
        Me.BoolP.Size = New System.Drawing.Size(102, 16)
        Me.BoolP.TabIndex = 3
        Me.BoolP.Text = "True 或 False"
        Me.BoolP.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TextBox1)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.ComboBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(267, 146)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "项目"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(70, 39)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(143, 21)
        Me.TextBox1.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "数  据："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "项目名："
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"零件代号", "库存编号", "描述", "修订号", "项目", "设计人", "工程师", "批准人", "成本中心", "预估成本", "供应商", "Web链接"})
        Me.ComboBox1.Location = New System.Drawing.Point(70, 10)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(145, 20)
        Me.ComboBox1.TabIndex = 18
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(275, 172)
        Me.TabControl1.TabIndex = 19
        '
        'iPopertiesDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(299, 231)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.clearlist)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.addfile)
        Me.Controls.Add(Me.ListBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "iPopertiesDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "量产iPoperties"
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents addfile As System.Windows.Forms.Button
    Friend WithEvents clearlist As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DateTimeP As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DoubleP As System.Windows.Forms.TextBox
    Friend WithEvents PropertyName As System.Windows.Forms.TextBox
    Friend WithEvents StringP As System.Windows.Forms.TextBox
    Friend WithEvents StringRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents BoolRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents DateRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents DoubleRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents BoolP As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl

End Class
