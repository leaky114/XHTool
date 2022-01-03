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
        Me.btn确定 = New System.Windows.Forms.Button()
        Me.btn取消 = New System.Windows.Forms.Button()
        Me.lbl图号 = New System.Windows.Forms.Label()
        Me.txt图号 = New System.Windows.Forms.TextBox()
        Me.txt文件名 = New System.Windows.Forms.TextBox()
        Me.btn向上1 = New System.Windows.Forms.Button()
        Me.btn向上2 = New System.Windows.Forms.Button()
        Me.cmb描述 = New System.Windows.Forms.ComboBox()
        Me.cmb材料 = New System.Windows.Forms.ComboBox()
        Me.lbl文件名 = New System.Windows.Forms.Label()
        Me.lbl描述 = New System.Windows.Forms.Label()
        Me.lbl材料 = New System.Windows.Forms.Label()
        Me.lblERPCode = New System.Windows.Forms.Label()
        Me.btn查询 = New System.Windows.Forms.Button()
        Me.txtERPCode = New System.Windows.Forms.TextBox()
        Me.lbl供应商 = New System.Windows.Forms.Label()
        Me.cmb供应商 = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btn确定
        '
        Me.btn确定.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn确定.Location = New System.Drawing.Point(149, 211)
        Me.btn确定.Name = "btn确定"
        Me.btn确定.Size = New System.Drawing.Size(65, 28)
        Me.btn确定.TabIndex = 0
        Me.btn确定.Text = "确定"
        '
        'btn取消
        '
        Me.btn取消.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn取消.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn取消.Location = New System.Drawing.Point(222, 211)
        Me.btn取消.Name = "btn取消"
        Me.btn取消.Size = New System.Drawing.Size(65, 28)
        Me.btn取消.TabIndex = 1
        Me.btn取消.Text = "取消"
        '
        'lbl图号
        '
        Me.lbl图号.AutoSize = True
        Me.lbl图号.Location = New System.Drawing.Point(12, 22)
        Me.lbl图号.Name = "lbl图号"
        Me.lbl图号.Size = New System.Drawing.Size(65, 12)
        Me.lbl图号.TabIndex = 1
        Me.lbl图号.Text = "图    号："
        '
        'txt图号
        '
        Me.txt图号.Location = New System.Drawing.Point(79, 20)
        Me.txt图号.Name = "txt图号"
        Me.txt图号.Size = New System.Drawing.Size(164, 21)
        Me.txt图号.TabIndex = 0
        '
        'txt文件名
        '
        Me.txt文件名.Location = New System.Drawing.Point(79, 49)
        Me.txt文件名.Name = "txt文件名"
        Me.txt文件名.Size = New System.Drawing.Size(164, 21)
        Me.txt文件名.TabIndex = 1
        '
        'btn向上1
        '
        Me.btn向上1.Location = New System.Drawing.Point(254, 25)
        Me.btn向上1.Name = "btn向上1"
        Me.btn向上1.Size = New System.Drawing.Size(23, 27)
        Me.btn向上1.TabIndex = 7
        Me.btn向上1.Text = "↑"
        Me.btn向上1.UseVisualStyleBackColor = True
        '
        'btn向上2
        '
        Me.btn向上2.Location = New System.Drawing.Point(254, 63)
        Me.btn向上2.Name = "btn向上2"
        Me.btn向上2.Size = New System.Drawing.Size(23, 27)
        Me.btn向上2.TabIndex = 8
        Me.btn向上2.Text = "↑"
        Me.btn向上2.UseVisualStyleBackColor = True
        '
        'cmb描述
        '
        Me.cmb描述.FormattingEnabled = True
        Me.cmb描述.Items.AddRange(New Object() {"", "见本图", "无图", "无图,×", "无图,L=", "8.8级", "12.9级"})
        Me.cmb描述.Location = New System.Drawing.Point(79, 78)
        Me.cmb描述.Name = "cmb描述"
        Me.cmb描述.Size = New System.Drawing.Size(164, 20)
        Me.cmb描述.TabIndex = 3
        '
        'cmb材料
        '
        Me.cmb材料.FormattingEnabled = True
        Me.cmb材料.Location = New System.Drawing.Point(79, 106)
        Me.cmb材料.Name = "cmb材料"
        Me.cmb材料.Size = New System.Drawing.Size(164, 20)
        Me.cmb材料.Sorted = True
        Me.cmb材料.TabIndex = 4
        '
        'lbl文件名
        '
        Me.lbl文件名.AutoSize = True
        Me.lbl文件名.Location = New System.Drawing.Point(12, 53)
        Me.lbl文件名.Name = "lbl文件名"
        Me.lbl文件名.Size = New System.Drawing.Size(65, 12)
        Me.lbl文件名.TabIndex = 9
        Me.lbl文件名.Text = "文 件 名："
        '
        'lbl描述
        '
        Me.lbl描述.AutoSize = True
        Me.lbl描述.Location = New System.Drawing.Point(12, 82)
        Me.lbl描述.Name = "lbl描述"
        Me.lbl描述.Size = New System.Drawing.Size(65, 12)
        Me.lbl描述.TabIndex = 10
        Me.lbl描述.Text = "描    述："
        '
        'lbl材料
        '
        Me.lbl材料.AutoSize = True
        Me.lbl材料.Location = New System.Drawing.Point(12, 110)
        Me.lbl材料.Name = "lbl材料"
        Me.lbl材料.Size = New System.Drawing.Size(65, 12)
        Me.lbl材料.TabIndex = 11
        Me.lbl材料.Text = "材    料："
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
        'btn查询
        '
        Me.btn查询.Location = New System.Drawing.Point(249, 129)
        Me.btn查询.Name = "btn查询"
        Me.btn查询.Size = New System.Drawing.Size(40, 28)
        Me.btn查询.TabIndex = 13
        Me.btn查询.Text = "查询"
        Me.btn查询.UseVisualStyleBackColor = True
        '
        'txtERPCode
        '
        Me.txtERPCode.Location = New System.Drawing.Point(79, 136)
        Me.txtERPCode.Name = "txtERPCode"
        Me.txtERPCode.Size = New System.Drawing.Size(164, 21)
        Me.txtERPCode.TabIndex = 5
        '
        'lbl供应商
        '
        Me.lbl供应商.AutoSize = True
        Me.lbl供应商.Location = New System.Drawing.Point(12, 171)
        Me.lbl供应商.Name = "lbl供应商"
        Me.lbl供应商.Size = New System.Drawing.Size(65, 12)
        Me.lbl供应商.TabIndex = 15
        Me.lbl供应商.Text = "供 应 商："
        '
        'cmb供应商
        '
        Me.cmb供应商.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb供应商.FormattingEnabled = True
        Me.cmb供应商.Items.AddRange(New Object() {"", "标准件", "看板件", "外购件", "外协件", "自制件"})
        Me.cmb供应商.Location = New System.Drawing.Point(80, 169)
        Me.cmb供应商.Name = "cmb供应商"
        Me.cmb供应商.Size = New System.Drawing.Size(162, 20)
        Me.cmb供应商.TabIndex = 6
        '
        'frmChangeIpro
        '
        Me.AcceptButton = Me.btn确定
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn取消
        Me.ClientSize = New System.Drawing.Size(301, 249)
        Me.Controls.Add(Me.cmb供应商)
        Me.Controls.Add(Me.lbl供应商)
        Me.Controls.Add(Me.txtERPCode)
        Me.Controls.Add(Me.btn查询)
        Me.Controls.Add(Me.lblERPCode)
        Me.Controls.Add(Me.lbl材料)
        Me.Controls.Add(Me.lbl描述)
        Me.Controls.Add(Me.lbl文件名)
        Me.Controls.Add(Me.cmb材料)
        Me.Controls.Add(Me.cmb描述)
        Me.Controls.Add(Me.btn确定)
        Me.Controls.Add(Me.btn取消)
        Me.Controls.Add(Me.btn向上2)
        Me.Controls.Add(Me.btn向上1)
        Me.Controls.Add(Me.txt文件名)
        Me.Controls.Add(Me.txt图号)
        Me.Controls.Add(Me.lbl图号)
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
    Friend WithEvents btn确定 As System.Windows.Forms.Button
    Friend WithEvents btn取消 As System.Windows.Forms.Button
    Friend WithEvents lbl图号 As System.Windows.Forms.Label
    Friend WithEvents txt图号 As System.Windows.Forms.TextBox
    Friend WithEvents txt文件名 As System.Windows.Forms.TextBox
    Friend WithEvents btn向上1 As System.Windows.Forms.Button
    Friend WithEvents btn向上2 As System.Windows.Forms.Button
    Friend WithEvents cmb描述 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb材料 As System.Windows.Forms.ComboBox
    Friend WithEvents lbl文件名 As System.Windows.Forms.Label
    Friend WithEvents lbl描述 As System.Windows.Forms.Label
    Friend WithEvents lbl材料 As System.Windows.Forms.Label
    Friend WithEvents lblERPCode As System.Windows.Forms.Label
    Friend WithEvents btn查询 As System.Windows.Forms.Button
    Friend WithEvents txtERPCode As System.Windows.Forms.TextBox
    Friend WithEvents lbl供应商 As System.Windows.Forms.Label
    Friend WithEvents cmb供应商 As System.Windows.Forms.ComboBox

End Class
