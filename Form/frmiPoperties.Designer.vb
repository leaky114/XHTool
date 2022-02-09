<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmiPoperties
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
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lstFileLIst = New System.Windows.Forms.ListBox()
        Me.btnAddFile = New System.Windows.Forms.Button()
        Me.btnClearList = New System.Windows.Forms.Button()
        Me.tpCustom = New System.Windows.Forms.TabPage()
        Me.BoolP = New System.Windows.Forms.CheckBox()
        Me.rdoDouble = New System.Windows.Forms.RadioButton()
        Me.rdoDate = New System.Windows.Forms.RadioButton()
        Me.rdoBool = New System.Windows.Forms.RadioButton()
        Me.rdoString = New System.Windows.Forms.RadioButton()
        Me.txtString = New System.Windows.Forms.TextBox()
        Me.txtProperty = New System.Windows.Forms.TextBox()
        Me.txtDouble = New System.Windows.Forms.TextBox()
        Me.lblProperty = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.tpProject = New System.Windows.Forms.TabPage()
        Me.cmbProject = New System.Windows.Forms.ComboBox()
        Me.lblProject = New System.Windows.Forms.Label()
        Me.lblData = New System.Windows.Forms.Label()
        Me.txtData = New System.Windows.Forms.TextBox()
        Me.tab1 = New System.Windows.Forms.TabControl()
        Me.tpCustom.SuspendLayout()
        Me.tpProject.SuspendLayout()
        Me.tab1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStart.Location = New System.Drawing.Point(169, 189)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(57, 33)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "开始"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(230, 189)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(57, 33)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "关闭"
        '
        'lstFileLIst
        '
        Me.lstFileLIst.FormattingEnabled = True
        Me.lstFileLIst.ItemHeight = 12
        Me.lstFileLIst.Location = New System.Drawing.Point(12, 190)
        Me.lstFileLIst.Name = "lstFileLIst"
        Me.lstFileLIst.Size = New System.Drawing.Size(271, 148)
        Me.lstFileLIst.TabIndex = 15
        Me.lstFileLIst.Visible = False
        '
        'btnAddFile
        '
        Me.btnAddFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddFile.Location = New System.Drawing.Point(12, 189)
        Me.btnAddFile.Name = "btnAddFile"
        Me.btnAddFile.Size = New System.Drawing.Size(69, 33)
        Me.btnAddFile.TabIndex = 0
        Me.btnAddFile.Text = "添加文件"
        Me.btnAddFile.UseVisualStyleBackColor = True
        Me.btnAddFile.Visible = False
        '
        'btnClearList
        '
        Me.btnClearList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClearList.Location = New System.Drawing.Point(86, 189)
        Me.btnClearList.Name = "btnClearList"
        Me.btnClearList.Size = New System.Drawing.Size(69, 33)
        Me.btnClearList.TabIndex = 20
        Me.btnClearList.Text = "清除列表"
        Me.btnClearList.UseVisualStyleBackColor = True
        Me.btnClearList.Visible = False
        '
        'tpCustom
        '
        Me.tpCustom.Controls.Add(Me.dtpDate)
        Me.tpCustom.Controls.Add(Me.lblProperty)
        Me.tpCustom.Controls.Add(Me.txtDouble)
        Me.tpCustom.Controls.Add(Me.txtProperty)
        Me.tpCustom.Controls.Add(Me.txtString)
        Me.tpCustom.Controls.Add(Me.rdoString)
        Me.tpCustom.Controls.Add(Me.rdoBool)
        Me.tpCustom.Controls.Add(Me.rdoDate)
        Me.tpCustom.Controls.Add(Me.rdoDouble)
        Me.tpCustom.Controls.Add(Me.BoolP)
        Me.tpCustom.Location = New System.Drawing.Point(4, 22)
        Me.tpCustom.Name = "tpCustom"
        Me.tpCustom.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCustom.Size = New System.Drawing.Size(267, 146)
        Me.tpCustom.TabIndex = 1
        Me.tpCustom.Text = "自定义"
        Me.tpCustom.UseVisualStyleBackColor = True
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
        'rdoDouble
        '
        Me.rdoDouble.AutoSize = True
        Me.rdoDouble.Location = New System.Drawing.Point(15, 91)
        Me.rdoDouble.Name = "rdoDouble"
        Me.rdoDouble.Size = New System.Drawing.Size(47, 16)
        Me.rdoDouble.TabIndex = 8
        Me.rdoDouble.TabStop = True
        Me.rdoDouble.Text = "实数"
        Me.rdoDouble.UseVisualStyleBackColor = True
        '
        'rdoDate
        '
        Me.rdoDate.AutoSize = True
        Me.rdoDate.Location = New System.Drawing.Point(15, 115)
        Me.rdoDate.Name = "rdoDate"
        Me.rdoDate.Size = New System.Drawing.Size(47, 16)
        Me.rdoDate.TabIndex = 9
        Me.rdoDate.TabStop = True
        Me.rdoDate.Text = "日期"
        Me.rdoDate.UseVisualStyleBackColor = True
        '
        'rdoBool
        '
        Me.rdoBool.AutoSize = True
        Me.rdoBool.Location = New System.Drawing.Point(15, 67)
        Me.rdoBool.Name = "rdoBool"
        Me.rdoBool.Size = New System.Drawing.Size(59, 16)
        Me.rdoBool.TabIndex = 7
        Me.rdoBool.TabStop = True
        Me.rdoBool.Text = "布尔值"
        Me.rdoBool.UseVisualStyleBackColor = True
        '
        'rdoString
        '
        Me.rdoString.AutoSize = True
        Me.rdoString.Location = New System.Drawing.Point(15, 43)
        Me.rdoString.Name = "rdoString"
        Me.rdoString.Size = New System.Drawing.Size(47, 16)
        Me.rdoString.TabIndex = 6
        Me.rdoString.TabStop = True
        Me.rdoString.Text = "字串"
        Me.rdoString.UseVisualStyleBackColor = True
        '
        'txtString
        '
        Me.txtString.Location = New System.Drawing.Point(81, 36)
        Me.txtString.Name = "txtString"
        Me.txtString.Size = New System.Drawing.Size(127, 21)
        Me.txtString.TabIndex = 2
        '
        'txtProperty
        '
        Me.txtProperty.Location = New System.Drawing.Point(81, 9)
        Me.txtProperty.Name = "txtProperty"
        Me.txtProperty.Size = New System.Drawing.Size(127, 21)
        Me.txtProperty.TabIndex = 12
        '
        'txtDouble
        '
        Me.txtDouble.Location = New System.Drawing.Point(81, 87)
        Me.txtDouble.Name = "txtDouble"
        Me.txtDouble.Size = New System.Drawing.Size(127, 21)
        Me.txtDouble.TabIndex = 4
        '
        'lblProperty
        '
        Me.lblProperty.AutoSize = True
        Me.lblProperty.Location = New System.Drawing.Point(17, 15)
        Me.lblProperty.Name = "lblProperty"
        Me.lblProperty.Size = New System.Drawing.Size(41, 12)
        Me.lblProperty.TabIndex = 13
        Me.lblProperty.Text = "特性名"
        '
        'dtpDate
        '
        Me.dtpDate.Location = New System.Drawing.Point(81, 115)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(127, 21)
        Me.dtpDate.TabIndex = 11
        '
        'tpProject
        '
        Me.tpProject.Controls.Add(Me.txtData)
        Me.tpProject.Controls.Add(Me.lblData)
        Me.tpProject.Controls.Add(Me.lblProject)
        Me.tpProject.Controls.Add(Me.cmbProject)
        Me.tpProject.Location = New System.Drawing.Point(4, 22)
        Me.tpProject.Name = "tpProject"
        Me.tpProject.Padding = New System.Windows.Forms.Padding(3)
        Me.tpProject.Size = New System.Drawing.Size(267, 146)
        Me.tpProject.TabIndex = 0
        Me.tpProject.Text = "项目"
        Me.tpProject.UseVisualStyleBackColor = True
        '
        'cmbProject
        '
        Me.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProject.FormattingEnabled = True
        Me.cmbProject.Items.AddRange(New Object() {"零件代号", "库存编号", "描述", "修订号", "项目", "设计人", "工程师", "批准人", "成本中心", "预估成本", "供应商", "Web链接"})
        Me.cmbProject.Location = New System.Drawing.Point(70, 10)
        Me.cmbProject.Name = "cmbProject"
        Me.cmbProject.Size = New System.Drawing.Size(145, 20)
        Me.cmbProject.TabIndex = 18
        '
        'lblProject
        '
        Me.lblProject.AutoSize = True
        Me.lblProject.Location = New System.Drawing.Point(12, 14)
        Me.lblProject.Name = "lblProject"
        Me.lblProject.Size = New System.Drawing.Size(53, 12)
        Me.lblProject.TabIndex = 19
        Me.lblProject.Text = "项目名："
        '
        'lblData
        '
        Me.lblData.AutoSize = True
        Me.lblData.Location = New System.Drawing.Point(12, 41)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(53, 12)
        Me.lblData.TabIndex = 20
        Me.lblData.Text = "数  据："
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(70, 39)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(143, 21)
        Me.txtData.TabIndex = 21
        '
        'tab1
        '
        Me.tab1.Controls.Add(Me.tpProject)
        Me.tab1.Controls.Add(Me.tpCustom)
        Me.tab1.Location = New System.Drawing.Point(12, 12)
        Me.tab1.Name = "tab1"
        Me.tab1.SelectedIndex = 0
        Me.tab1.Size = New System.Drawing.Size(275, 172)
        Me.tab1.TabIndex = 19
        '
        'frmiPoperties
        '
        Me.AcceptButton = Me.btnStart
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(299, 231)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.btnClearList)
        Me.Controls.Add(Me.tab1)
        Me.Controls.Add(Me.btnAddFile)
        Me.Controls.Add(Me.lstFileLIst)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmiPoperties"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "量产iPoperties"
        Me.tpCustom.ResumeLayout(False)
        Me.tpCustom.PerformLayout()
        Me.tpProject.ResumeLayout(False)
        Me.tpProject.PerformLayout()
        Me.tab1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lstFileLIst As System.Windows.Forms.ListBox
    Friend WithEvents btnAddFile As System.Windows.Forms.Button
    Friend WithEvents btnClearList As System.Windows.Forms.Button
    Friend WithEvents tpCustom As System.Windows.Forms.TabPage
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblProperty As System.Windows.Forms.Label
    Friend WithEvents txtDouble As System.Windows.Forms.TextBox
    Friend WithEvents txtProperty As System.Windows.Forms.TextBox
    Friend WithEvents txtString As System.Windows.Forms.TextBox
    Friend WithEvents rdoString As System.Windows.Forms.RadioButton
    Friend WithEvents rdoBool As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDate As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDouble As System.Windows.Forms.RadioButton
    Friend WithEvents BoolP As System.Windows.Forms.CheckBox
    Friend WithEvents tpProject As System.Windows.Forms.TabPage
    Friend WithEvents txtData As System.Windows.Forms.TextBox
    Friend WithEvents lblData As System.Windows.Forms.Label
    Friend WithEvents lblProject As System.Windows.Forms.Label
    Friend WithEvents cmbProject As System.Windows.Forms.ComboBox
    Friend WithEvents tab1 As System.Windows.Forms.TabControl

End Class
