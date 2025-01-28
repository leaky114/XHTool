Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPartColor
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Btn_Part = New System.Windows.Forms.Button()
        Me.Btn_Body = New System.Windows.Forms.Button()
        Me.Btn_Face = New System.Windows.Forms.Button()
        Me.Btn_Select = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Btn_Part
        '
        Me.Btn_Part.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Part.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Part.Location = New System.Drawing.Point(12, 12)
        Me.Btn_Part.Name = "Btn_Part"
        Me.Btn_Part.Size = New System.Drawing.Size(183, 43)
        Me.Btn_Part.TabIndex = 0
        Me.Btn_Part.Tag = "Part"
        Me.Btn_Part.Text = "零件"
        Me.Btn_Part.UseVisualStyleBackColor = True
        '
        'Btn_Body
        '
        Me.Btn_Body.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Body.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Body.Location = New System.Drawing.Point(12, 61)
        Me.Btn_Body.Name = "Btn_Body"
        Me.Btn_Body.Size = New System.Drawing.Size(183, 43)
        Me.Btn_Body.TabIndex = 1
        Me.Btn_Body.Tag = "Body"
        Me.Btn_Body.Text = "实体"
        Me.Btn_Body.UseVisualStyleBackColor = True
        '
        'Btn_Face
        '
        Me.Btn_Face.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Face.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Face.Location = New System.Drawing.Point(12, 110)
        Me.Btn_Face.Name = "Btn_Face"
        Me.Btn_Face.Size = New System.Drawing.Size(183, 43)
        Me.Btn_Face.TabIndex = 2
        Me.Btn_Face.Tag = "Face"
        Me.Btn_Face.Text = "面"
        Me.Btn_Face.UseVisualStyleBackColor = True
        '
        'Btn_Select
        '
        Me.Btn_Select.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Select.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Select.Location = New System.Drawing.Point(12, 159)
        Me.Btn_Select.Name = "Btn_Select"
        Me.Btn_Select.Size = New System.Drawing.Size(183, 43)
        Me.Btn_Select.TabIndex = 3
        Me.Btn_Select.Tag = "Select"
        Me.Btn_Select.Text = "选择"
        Me.Btn_Select.UseVisualStyleBackColor = True
        '
        'FormPartColor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(207, 215)
        Me.Controls.Add(Me.Btn_Select)
        Me.Controls.Add(Me.Btn_Face)
        Me.Controls.Add(Me.Btn_Body)
        Me.Controls.Add(Me.Btn_Part)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(223, 254)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(223, 254)
        Me.Name = "FormPartColor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "着色类型"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Btn_Part As Button
    Friend WithEvents Btn_Body As Button
    Friend WithEvents Btn_Face As Button
    Friend WithEvents Btn_Select As Button
End Class
