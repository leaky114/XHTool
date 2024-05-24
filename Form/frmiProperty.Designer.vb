<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmiProperty
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            if disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End if
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmiProperty))
        Me.btn确定 = New System.Windows.Forms.Button()
        Me.btn取消 = New System.Windows.Forms.Button()
        Me.lbl图号 = New System.Windows.Forms.Label()
        Me.txt图号 = New System.Windows.Forms.TextBox()
        Me.txt文件名 = New System.Windows.Forms.TextBox()
        Me.btn向上1 = New System.Windows.Forms.Button()
        Me.btn向上2 = New System.Windows.Forms.Button()
        Me.cbo描述 = New System.Windows.Forms.ComboBox()
        Me.cbo材料 = New System.Windows.Forms.ComboBox()
        Me.lbl文件名 = New System.Windows.Forms.Label()
        Me.lbl描述 = New System.Windows.Forms.Label()
        Me.lbl材料 = New System.Windows.Forms.Label()
        Me.lblERP编码 = New System.Windows.Forms.Label()
        Me.btn查询 = New System.Windows.Forms.Button()
        Me.txtERP编码 = New System.Windows.Forms.TextBox()
        Me.lbl供应商 = New System.Windows.Forms.Label()
        Me.cbo供应商 = New System.Windows.Forms.ComboBox()
        Me.txt价格 = New System.Windows.Forms.TextBox()
        Me.lbl价格 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt位置 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btn确定
        '
        Me.btn确定.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn确定.Location = New System.Drawing.Point(169, 265)
        Me.btn确定.Name = "btn确定"
        Me.btn确定.Size = New System.Drawing.Size(65, 28)
        Me.btn确定.TabIndex = 10
        Me.btn确定.Text = "确定"
        '
        'btn取消
        '
        Me.btn取消.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn取消.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn取消.Location = New System.Drawing.Point(242, 265)
        Me.btn取消.Name = "btn取消"
        Me.btn取消.Size = New System.Drawing.Size(65, 28)
        Me.btn取消.TabIndex = 11
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
        Me.txt图号.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt图号.Location = New System.Drawing.Point(79, 18)
        Me.txt图号.Name = "txt图号"
        Me.txt图号.Size = New System.Drawing.Size(185, 21)
        Me.txt图号.TabIndex = 0
        '
        'txt文件名
        '
        Me.txt文件名.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt文件名.Location = New System.Drawing.Point(79, 49)
        Me.txt文件名.Name = "txt文件名"
        Me.txt文件名.Size = New System.Drawing.Size(185, 21)
        Me.txt文件名.TabIndex = 1
        '
        'btn向上1
        '
        Me.btn向上1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn向上1.Location = New System.Drawing.Point(275, 25)
        Me.btn向上1.Name = "btn向上1"
        Me.btn向上1.Size = New System.Drawing.Size(26, 26)
        Me.btn向上1.TabIndex = 7
        Me.btn向上1.UseVisualStyleBackColor = True
        '
        'btn向上2
        '
        Me.btn向上2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn向上2.Location = New System.Drawing.Point(275, 63)
        Me.btn向上2.Name = "btn向上2"
        Me.btn向上2.Size = New System.Drawing.Size(26, 26)
        Me.btn向上2.TabIndex = 8
        Me.btn向上2.UseVisualStyleBackColor = True
        '
        'cbo描述
        '
        Me.cbo描述.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo描述.FormattingEnabled = True
        Me.cbo描述.Items.AddRange(New Object() {"", "见本图", "无图", "无图,×", "无图,L="})
        Me.cbo描述.Location = New System.Drawing.Point(79, 78)
        Me.cbo描述.Name = "cbo描述"
        Me.cbo描述.Size = New System.Drawing.Size(185, 20)
        Me.cbo描述.TabIndex = 2
        '
        'cbo材料
        '
        Me.cbo材料.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo材料.FormattingEnabled = True
        Me.cbo材料.Location = New System.Drawing.Point(79, 106)
        Me.cbo材料.Name = "cbo材料"
        Me.cbo材料.Size = New System.Drawing.Size(185, 20)
        Me.cbo材料.Sorted = True
        Me.cbo材料.TabIndex = 3
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
        'lblERP编码
        '
        Me.lblERP编码.AutoSize = True
        Me.lblERP编码.Location = New System.Drawing.Point(12, 140)
        Me.lblERP编码.Name = "lblERP编码"
        Me.lblERP编码.Size = New System.Drawing.Size(65, 12)
        Me.lblERP编码.TabIndex = 12
        Me.lblERP编码.Text = "E   R  P："
        '
        'btn查询
        '
        Me.btn查询.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn查询.Location = New System.Drawing.Point(275, 133)
        Me.btn查询.Name = "btn查询"
        Me.btn查询.Size = New System.Drawing.Size(26, 26)
        Me.btn查询.TabIndex = 9
        Me.btn查询.UseVisualStyleBackColor = True
        '
        'txtERP编码
        '
        Me.txtERP编码.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtERP编码.Location = New System.Drawing.Point(79, 136)
        Me.txtERP编码.Name = "txtERP编码"
        Me.txtERP编码.Size = New System.Drawing.Size(185, 21)
        Me.txtERP编码.TabIndex = 4
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
        'cbo供应商
        '
        Me.cbo供应商.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo供应商.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo供应商.FormattingEnabled = True
        Me.cbo供应商.Items.AddRange(New Object() {"", "标准件", "看板件", "外购件", "外协件", "自制件"})
        Me.cbo供应商.Location = New System.Drawing.Point(80, 167)
        Me.cbo供应商.Name = "cbo供应商"
        Me.cbo供应商.Size = New System.Drawing.Size(183, 20)
        Me.cbo供应商.TabIndex = 5
        '
        'txt价格
        '
        Me.txt价格.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt价格.Location = New System.Drawing.Point(80, 200)
        Me.txt价格.Name = "txt价格"
        Me.txt价格.Size = New System.Drawing.Size(185, 21)
        Me.txt价格.TabIndex = 6
        '
        'lbl价格
        '
        Me.lbl价格.AutoSize = True
        Me.lbl价格.Location = New System.Drawing.Point(13, 204)
        Me.lbl价格.Name = "lbl价格"
        Me.lbl价格.Size = New System.Drawing.Size(65, 12)
        Me.lbl价格.TabIndex = 17
        Me.lbl价格.Text = "价    格："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 233)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "位    置："
        '
        'txt位置
        '
        Me.txt位置.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt位置.Location = New System.Drawing.Point(78, 229)
        Me.txt位置.Name = "txt位置"
        Me.txt位置.ReadOnly = True
        Me.txt位置.Size = New System.Drawing.Size(231, 21)
        Me.txt位置.TabIndex = 19
        Me.txt位置.TabStop = False
        Me.txt位置.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmiProperty
        '
        Me.AcceptButton = Me.btn确定
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn取消
        Me.ClientSize = New System.Drawing.Size(321, 303)
        Me.Controls.Add(Me.txt位置)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt价格)
        Me.Controls.Add(Me.lbl价格)
        Me.Controls.Add(Me.cbo供应商)
        Me.Controls.Add(Me.lbl供应商)
        Me.Controls.Add(Me.txtERP编码)
        Me.Controls.Add(Me.btn查询)
        Me.Controls.Add(Me.lblERP编码)
        Me.Controls.Add(Me.lbl材料)
        Me.Controls.Add(Me.lbl描述)
        Me.Controls.Add(Me.lbl文件名)
        Me.Controls.Add(Me.cbo材料)
        Me.Controls.Add(Me.cbo描述)
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
        Me.Name = "frmiProperty"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "iProperty+"
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
    Friend WithEvents cbo描述 As System.Windows.Forms.ComboBox
    Friend WithEvents cbo材料 As System.Windows.Forms.ComboBox
    Friend WithEvents lbl文件名 As System.Windows.Forms.Label
    Friend WithEvents lbl描述 As System.Windows.Forms.Label
    Friend WithEvents lbl材料 As System.Windows.Forms.Label
    Friend WithEvents lblERP编码 As System.Windows.Forms.Label
    Friend WithEvents btn查询 As System.Windows.Forms.Button
    Friend WithEvents txtERP编码 As System.Windows.Forms.TextBox
    Friend WithEvents lbl供应商 As System.Windows.Forms.Label
    Friend WithEvents cbo供应商 As System.Windows.Forms.ComboBox
    Friend WithEvents txt价格 As System.Windows.Forms.TextBox
    Friend WithEvents lbl价格 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt位置 As System.Windows.Forms.TextBox

End Class
