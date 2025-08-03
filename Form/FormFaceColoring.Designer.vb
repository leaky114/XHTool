Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormFaceColoring
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
        Me.btn清除着色 = New System.Windows.Forms.Button()
        Me.btn选择面 = New System.Windows.Forms.Button()
        Me.cmb外观 = New System.Windows.Forms.ComboBox()
        Me.btn清除全部 = New System.Windows.Forms.Button()
        Me.btn选择特征 = New System.Windows.Forms.Button()
        Me.Btn选择颜色 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn清除着色
        '
        Me.btn清除着色.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn清除着色.Location = New System.Drawing.Point(250, 5)
        Me.btn清除着色.Name = "btn清除着色"
        Me.btn清除着色.Size = New System.Drawing.Size(32, 32)
        Me.btn清除着色.TabIndex = 11
        Me.btn清除着色.UseVisualStyleBackColor = True
        '
        'btn选择面
        '
        Me.btn选择面.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn选择面.Location = New System.Drawing.Point(213, 5)
        Me.btn选择面.Name = "btn选择面"
        Me.btn选择面.Size = New System.Drawing.Size(32, 32)
        Me.btn选择面.TabIndex = 9
        Me.btn选择面.UseVisualStyleBackColor = True
        '
        'cmb外观
        '
        Me.cmb外观.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb外观.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb外观.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmb外观.FormattingEnabled = True
        Me.cmb外观.Location = New System.Drawing.Point(12, 12)
        Me.cmb外观.Name = "cmb外观"
        Me.cmb外观.Size = New System.Drawing.Size(121, 20)
        Me.cmb外观.Sorted = True
        Me.cmb外观.TabIndex = 13
        '
        'btn清除全部
        '
        Me.btn清除全部.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn清除全部.Location = New System.Drawing.Point(287, 5)
        Me.btn清除全部.Name = "btn清除全部"
        Me.btn清除全部.Size = New System.Drawing.Size(32, 32)
        Me.btn清除全部.TabIndex = 12
        Me.btn清除全部.UseVisualStyleBackColor = True
        '
        'btn选择特征
        '
        Me.btn选择特征.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn选择特征.Location = New System.Drawing.Point(176, 5)
        Me.btn选择特征.Name = "btn选择特征"
        Me.btn选择特征.Size = New System.Drawing.Size(32, 32)
        Me.btn选择特征.TabIndex = 14
        Me.btn选择特征.UseVisualStyleBackColor = True
        '
        'Btn选择颜色
        '
        Me.Btn选择颜色.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn选择颜色.Location = New System.Drawing.Point(139, 5)
        Me.Btn选择颜色.Name = "Btn选择颜色"
        Me.Btn选择颜色.Size = New System.Drawing.Size(32, 32)
        Me.Btn选择颜色.TabIndex = 15
        Me.Btn选择颜色.UseVisualStyleBackColor = True
        '
        'FormFaceColoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 44)
        Me.Controls.Add(Me.Btn选择颜色)
        Me.Controls.Add(Me.btn选择特征)
        Me.Controls.Add(Me.btn清除着色)
        Me.Controls.Add(Me.btn选择面)
        Me.Controls.Add(Me.cmb外观)
        Me.Controls.Add(Me.btn清除全部)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFaceColoring"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "面着色"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn清除着色 As Button
    Friend WithEvents btn选择面 As Button
    Friend WithEvents cmb外观 As ComboBox
    Friend WithEvents btn清除全部 As Button
    Friend WithEvents btn选择特征 As Button
    Friend WithEvents Btn选择颜色 As Button
End Class
