<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchERPCode
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
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.txtERP编码 = New System.Windows.Forms.TextBox()
        Me.txt规格图号 = New System.Windows.Forms.TextBox()
        Me.lbl规格图号 = New System.Windows.Forms.Label()
        Me.lblERP编码 = New System.Windows.Forms.Label()
        Me.btn查询编码 = New System.Windows.Forms.Button()
        Me.btn粘贴到规格 = New System.Windows.Forms.Button()
        Me.btn复制编码 = New System.Windows.Forms.Button()
        Me.lvw编码列表 = New System.Windows.Forms.ListView()
        Me.ColumnHeader规格 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader编码 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(274, 85)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(65, 28)
        Me.btn关闭.TabIndex = 3
        Me.btn关闭.Text = "关闭"
        '
        'txtERP编码
        '
        Me.txtERP编码.Location = New System.Drawing.Point(85, 50)
        Me.txtERP编码.Name = "txtERP编码"
        Me.txtERP编码.Size = New System.Drawing.Size(164, 21)
        Me.txtERP编码.TabIndex = 8
        '
        'txt规格图号
        '
        Me.txt规格图号.Location = New System.Drawing.Point(85, 16)
        Me.txt规格图号.Name = "txt规格图号"
        Me.txt规格图号.Size = New System.Drawing.Size(164, 21)
        Me.txt规格图号.TabIndex = 0
        '
        'lbl规格图号
        '
        Me.lbl规格图号.AutoSize = True
        Me.lbl规格图号.Location = New System.Drawing.Point(12, 19)
        Me.lbl规格图号.Name = "lbl规格图号"
        Me.lbl规格图号.Size = New System.Drawing.Size(77, 12)
        Me.lbl规格图号.TabIndex = 5
        Me.lbl规格图号.Text = "规格(图号)："
        '
        'lblERP编码
        '
        Me.lblERP编码.AutoSize = True
        Me.lblERP编码.Location = New System.Drawing.Point(12, 54)
        Me.lblERP编码.Name = "lblERP编码"
        Me.lblERP编码.Size = New System.Drawing.Size(59, 12)
        Me.lblERP编码.TabIndex = 9
        Me.lblERP编码.Text = "ERP编码："
        '
        'btn查询编码
        '
        Me.btn查询编码.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn查询编码.Location = New System.Drawing.Point(203, 85)
        Me.btn查询编码.Name = "btn查询编码"
        Me.btn查询编码.Size = New System.Drawing.Size(65, 28)
        Me.btn查询编码.TabIndex = 1
        Me.btn查询编码.Text = "查询编码"
        Me.btn查询编码.UseVisualStyleBackColor = True
        '
        'btn粘贴到规格
        '
        Me.btn粘贴到规格.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn粘贴到规格.Location = New System.Drawing.Point(258, 12)
        Me.btn粘贴到规格.Name = "btn粘贴到规格"
        Me.btn粘贴到规格.Size = New System.Drawing.Size(81, 28)
        Me.btn粘贴到规格.TabIndex = 0
        Me.btn粘贴到规格.Text = "粘贴到规格"
        Me.btn粘贴到规格.UseVisualStyleBackColor = True
        '
        'btn复制编码
        '
        Me.btn复制编码.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn复制编码.Location = New System.Drawing.Point(258, 47)
        Me.btn复制编码.Name = "btn复制编码"
        Me.btn复制编码.Size = New System.Drawing.Size(81, 28)
        Me.btn复制编码.TabIndex = 2
        Me.btn复制编码.Text = "复制编码"
        Me.btn复制编码.UseVisualStyleBackColor = True
        '
        'lvw编码列表
        '
        Me.lvw编码列表.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvw编码列表.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader规格, Me.ColumnHeader编码})
        Me.lvw编码列表.FullRowSelect = True
        Me.lvw编码列表.Location = New System.Drawing.Point(21, 124)
        Me.lvw编码列表.Name = "lvw编码列表"
        Me.lvw编码列表.Size = New System.Drawing.Size(332, 116)
        Me.lvw编码列表.TabIndex = 10
        Me.lvw编码列表.UseCompatibleStateImageBehavior = False
        Me.lvw编码列表.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader规格
        '
        Me.ColumnHeader规格.Text = "规格"
        Me.ColumnHeader规格.Width = 200
        '
        'ColumnHeader编码
        '
        Me.ColumnHeader编码.Text = "ERP编码"
        Me.ColumnHeader编码.Width = 100
        '
        'frmSearchERPCode
        '
        Me.AcceptButton = Me.btn粘贴到规格
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn关闭
        Me.ClientSize = New System.Drawing.Size(365, 251)
        Me.Controls.Add(Me.lvw编码列表)
        Me.Controls.Add(Me.btn粘贴到规格)
        Me.Controls.Add(Me.btn复制编码)
        Me.Controls.Add(Me.btn查询编码)
        Me.Controls.Add(Me.lblERP编码)
        Me.Controls.Add(Me.btn关闭)
        Me.Controls.Add(Me.txtERP编码)
        Me.Controls.Add(Me.txt规格图号)
        Me.Controls.Add(Me.lbl规格图号)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearchERPCode"
        Me.Padding = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "查询ERP编码"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents txtERP编码 As System.Windows.Forms.TextBox
    Friend WithEvents txt规格图号 As System.Windows.Forms.TextBox
    Friend WithEvents lbl规格图号 As System.Windows.Forms.Label
    Friend WithEvents lblERP编码 As System.Windows.Forms.Label
    Friend WithEvents btn查询编码 As System.Windows.Forms.Button
    Friend WithEvents btn粘贴到规格 As System.Windows.Forms.Button
    Friend WithEvents btn复制编码 As System.Windows.Forms.Button
    Friend WithEvents lvw编码列表 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader规格 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader编码 As System.Windows.Forms.ColumnHeader

End Class
