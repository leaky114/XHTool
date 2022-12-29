<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangeIpro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChangeIpro))
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblNum = New System.Windows.Forms.Label()
        Me.txtNum = New System.Windows.Forms.TextBox()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.btnUp1 = New System.Windows.Forms.Button()
        Me.btnUp2 = New System.Windows.Forms.Button()
        Me.cmbDescribe = New System.Windows.Forms.ComboBox()
        Me.cmbMaterialName = New System.Windows.Forms.ComboBox()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.lblDescribe = New System.Windows.Forms.Label()
        Me.lblMaterialName = New System.Windows.Forms.Label()
        Me.lblERPCode = New System.Windows.Forms.Label()
        Me.btnSearchERPCode = New System.Windows.Forms.Button()
        Me.txtERPCode = New System.Windows.Forms.TextBox()
        Me.lblSupplier = New System.Windows.Forms.Label()
        Me.cmbSupplier = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(149, 218)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(65, 28)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "确定"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(222, 218)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(65, 28)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "取消"
        '
        'lblNum
        '
        Me.lblNum.AutoSize = True
        Me.lblNum.Location = New System.Drawing.Point(12, 22)
        Me.lblNum.Name = "lblNum"
        Me.lblNum.Size = New System.Drawing.Size(65, 12)
        Me.lblNum.TabIndex = 1
        Me.lblNum.Text = "图    号："
        '
        'txtNum
        '
        Me.txtNum.Location = New System.Drawing.Point(79, 20)
        Me.txtNum.Name = "txtNum"
        Me.txtNum.Size = New System.Drawing.Size(164, 21)
        Me.txtNum.TabIndex = 2
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(79, 49)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(164, 21)
        Me.txtFileName.TabIndex = 3
        '
        'btnUp1
        '
        Me.btnUp1.Location = New System.Drawing.Point(254, 25)
        Me.btnUp1.Name = "btnUp1"
        Me.btnUp1.Size = New System.Drawing.Size(23, 27)
        Me.btnUp1.TabIndex = 5
        Me.btnUp1.Text = "↑"
        Me.btnUp1.UseVisualStyleBackColor = True
        '
        'btnUp2
        '
        Me.btnUp2.Location = New System.Drawing.Point(254, 63)
        Me.btnUp2.Name = "btnUp2"
        Me.btnUp2.Size = New System.Drawing.Size(23, 27)
        Me.btnUp2.TabIndex = 6
        Me.btnUp2.Text = "↑"
        Me.btnUp2.UseVisualStyleBackColor = True
        '
        'cmbDescribe
        '
        Me.cmbDescribe.FormattingEnabled = True
        Me.cmbDescribe.Items.AddRange(New Object() {"", "见本图", "无图", "无图,×", "无图,L=", "8.8级", "12.9级"})
        Me.cmbDescribe.Location = New System.Drawing.Point(79, 78)
        Me.cmbDescribe.Name = "cmbDescribe"
        Me.cmbDescribe.Size = New System.Drawing.Size(164, 20)
        Me.cmbDescribe.TabIndex = 7
        '
        'cmbMaterialName
        '
        Me.cmbMaterialName.FormattingEnabled = True
        Me.cmbMaterialName.Location = New System.Drawing.Point(79, 106)
        Me.cmbMaterialName.Name = "cmbMaterialName"
        Me.cmbMaterialName.Size = New System.Drawing.Size(164, 20)
        Me.cmbMaterialName.Sorted = True
        Me.cmbMaterialName.TabIndex = 8
        '
        'lblFileName
        '
        Me.lblFileName.AutoSize = True
        Me.lblFileName.Location = New System.Drawing.Point(12, 53)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(65, 12)
        Me.lblFileName.TabIndex = 9
        Me.lblFileName.Text = "文 件 名："
        '
        'lblDescribe
        '
        Me.lblDescribe.AutoSize = True
        Me.lblDescribe.Location = New System.Drawing.Point(12, 82)
        Me.lblDescribe.Name = "lblDescribe"
        Me.lblDescribe.Size = New System.Drawing.Size(65, 12)
        Me.lblDescribe.TabIndex = 10
        Me.lblDescribe.Text = "描    述："
        '
        'lblMaterialName
        '
        Me.lblMaterialName.AutoSize = True
        Me.lblMaterialName.Location = New System.Drawing.Point(12, 110)
        Me.lblMaterialName.Name = "lblMaterialName"
        Me.lblMaterialName.Size = New System.Drawing.Size(65, 12)
        Me.lblMaterialName.TabIndex = 11
        Me.lblMaterialName.Text = "材    料："
        '
        'lblERPCode
        '
        Me.lblERPCode.AutoSize = True
        Me.lblERPCode.Location = New System.Drawing.Point(12, 140)
        Me.lblERPCode.Name = "lblERPCode"
        Me.lblERPCode.Size = New System.Drawing.Size(65, 12)
        Me.lblERPCode.TabIndex = 12
        Me.lblERPCode.Text = "E   R  P："
        '
        'btnSearchERPCode
        '
        Me.btnSearchERPCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSearchERPCode.Location = New System.Drawing.Point(247, 132)
        Me.btnSearchERPCode.Name = "btnSearchERPCode"
        Me.btnSearchERPCode.Size = New System.Drawing.Size(40, 28)
        Me.btnSearchERPCode.TabIndex = 13
        Me.btnSearchERPCode.Text = "查询"
        Me.btnSearchERPCode.UseVisualStyleBackColor = True
        '
        'txtERPCode
        '
        Me.txtERPCode.Location = New System.Drawing.Point(79, 136)
        Me.txtERPCode.Name = "txtERPCode"
        Me.txtERPCode.Size = New System.Drawing.Size(164, 21)
        Me.txtERPCode.TabIndex = 14
        '
        'lblSupplier
        '
        Me.lblSupplier.AutoSize = True
        Me.lblSupplier.Location = New System.Drawing.Point(12, 171)
        Me.lblSupplier.Name = "lblSupplier"
        Me.lblSupplier.Size = New System.Drawing.Size(65, 12)
        Me.lblSupplier.TabIndex = 15
        Me.lblSupplier.Text = "供 应 商："
        '
        'cmbSupplier
        '
        Me.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSupplier.FormattingEnabled = True
        Me.cmbSupplier.Items.AddRange(New Object() {"", "标准件", "看板件", "外购件", "外协件", "自制件"})
        Me.cmbSupplier.Location = New System.Drawing.Point(80, 169)
        Me.cmbSupplier.Name = "cmbSupplier"
        Me.cmbSupplier.Size = New System.Drawing.Size(162, 20)
        Me.cmbSupplier.TabIndex = 16
        '
        'frmChangeIpro
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(301, 256)
        Me.Controls.Add(Me.cmbSupplier)
        Me.Controls.Add(Me.lblSupplier)
        Me.Controls.Add(Me.txtERPCode)
        Me.Controls.Add(Me.btnSearchERPCode)
        Me.Controls.Add(Me.lblERPCode)
        Me.Controls.Add(Me.lblMaterialName)
        Me.Controls.Add(Me.lblDescribe)
        Me.Controls.Add(Me.lblFileName)
        Me.Controls.Add(Me.cmbMaterialName)
        Me.Controls.Add(Me.cmbDescribe)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnUp2)
        Me.Controls.Add(Me.btnUp1)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.txtNum)
        Me.Controls.Add(Me.lblNum)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChangeIpro"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "iProperty"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblNum As System.Windows.Forms.Label
    Friend WithEvents txtNum As System.Windows.Forms.TextBox
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents btnUp1 As System.Windows.Forms.Button
    Friend WithEvents btnUp2 As System.Windows.Forms.Button
    Friend WithEvents cmbDescribe As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMaterialName As System.Windows.Forms.ComboBox
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents lblDescribe As System.Windows.Forms.Label
    Friend WithEvents lblMaterialName As System.Windows.Forms.Label
    Friend WithEvents lblERPCode As System.Windows.Forms.Label
    Friend WithEvents btnSearchERPCode As System.Windows.Forms.Button
    Friend WithEvents txtERPCode As System.Windows.Forms.TextBox
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents cmbSupplier As System.Windows.Forms.ComboBox

End Class
