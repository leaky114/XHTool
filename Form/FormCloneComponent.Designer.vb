<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCloneComponent
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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
        Me.btn选择现有组件 = New System.Windows.Forms.Button()
        Me.btn选择组件圆弧 = New System.Windows.Forms.Button()
        Me.txt偏移量 = New System.Windows.Forms.TextBox()
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.btn插入组件圆弧 = New System.Windows.Forms.Button()
        Me.lbl现有组件 = New System.Windows.Forms.Label()
        Me.lbl组件圆弧 = New System.Windows.Forms.Label()
        Me.lbl插入的圆弧 = New System.Windows.Forms.Label()
        Me.btn插入反向 = New System.Windows.Forms.Button()
        Me.lbl插入方向 = New System.Windows.Forms.Label()
        Me.lbl偏移量 = New System.Windows.Forms.Label()
        Me.lbl组件数量 = New System.Windows.Forms.Label()
        Me.chk自动下一步 = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'btn选择现有组件
        '
        Me.btn选择现有组件.Location = New System.Drawing.Point(98, 7)
        Me.btn选择现有组件.Name = "btn选择现有组件"
        Me.btn选择现有组件.Size = New System.Drawing.Size(32, 32)
        Me.btn选择现有组件.TabIndex = 8
        Me.btn选择现有组件.UseVisualStyleBackColor = True
        '
        'btn选择组件圆弧
        '
        Me.btn选择组件圆弧.Enabled = False
        Me.btn选择组件圆弧.Location = New System.Drawing.Point(98, 45)
        Me.btn选择组件圆弧.Name = "btn选择组件圆弧"
        Me.btn选择组件圆弧.Size = New System.Drawing.Size(32, 32)
        Me.btn选择组件圆弧.TabIndex = 9
        Me.btn选择组件圆弧.UseVisualStyleBackColor = True
        '
        'txt偏移量
        '
        Me.txt偏移量.Location = New System.Drawing.Point(98, 168)
        Me.txt偏移量.Name = "txt偏移量"
        Me.txt偏移量.Size = New System.Drawing.Size(48, 21)
        Me.txt偏移量.TabIndex = 10
        Me.txt偏移量.Text = "0"
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(136, 212)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(70, 28)
        Me.btn关闭.TabIndex = 12
        Me.btn关闭.Text = "关闭"
        '
        'btn插入组件圆弧
        '
        Me.btn插入组件圆弧.Enabled = False
        Me.btn插入组件圆弧.Location = New System.Drawing.Point(98, 83)
        Me.btn插入组件圆弧.Name = "btn插入组件圆弧"
        Me.btn插入组件圆弧.Size = New System.Drawing.Size(32, 32)
        Me.btn插入组件圆弧.TabIndex = 13
        Me.btn插入组件圆弧.UseVisualStyleBackColor = True
        '
        'lbl现有组件
        '
        Me.lbl现有组件.AutoSize = True
        Me.lbl现有组件.Location = New System.Drawing.Point(12, 17)
        Me.lbl现有组件.Name = "lbl现有组件"
        Me.lbl现有组件.Size = New System.Drawing.Size(53, 12)
        Me.lbl现有组件.TabIndex = 14
        Me.lbl现有组件.Text = "现有组件"
        '
        'lbl组件圆弧
        '
        Me.lbl组件圆弧.AutoSize = True
        Me.lbl组件圆弧.Location = New System.Drawing.Point(12, 55)
        Me.lbl组件圆弧.Name = "lbl组件圆弧"
        Me.lbl组件圆弧.Size = New System.Drawing.Size(65, 12)
        Me.lbl组件圆弧.TabIndex = 15
        Me.lbl组件圆弧.Text = "组件圆(弧)"
        '
        'lbl插入的圆弧
        '
        Me.lbl插入的圆弧.AutoSize = True
        Me.lbl插入的圆弧.Location = New System.Drawing.Point(12, 93)
        Me.lbl插入的圆弧.Name = "lbl插入的圆弧"
        Me.lbl插入的圆弧.Size = New System.Drawing.Size(77, 12)
        Me.lbl插入的圆弧.TabIndex = 16
        Me.lbl插入的圆弧.Text = "插入的圆(弧)"
        '
        'btn插入反向
        '
        Me.btn插入反向.Location = New System.Drawing.Point(98, 121)
        Me.btn插入反向.Name = "btn插入反向"
        Me.btn插入反向.Size = New System.Drawing.Size(32, 32)
        Me.btn插入反向.TabIndex = 17
        Me.btn插入反向.UseVisualStyleBackColor = True
        '
        'lbl插入方向
        '
        Me.lbl插入方向.AutoSize = True
        Me.lbl插入方向.Location = New System.Drawing.Point(12, 131)
        Me.lbl插入方向.Name = "lbl插入方向"
        Me.lbl插入方向.Size = New System.Drawing.Size(53, 12)
        Me.lbl插入方向.TabIndex = 18
        Me.lbl插入方向.Text = "插入方向"
        '
        'lbl偏移量
        '
        Me.lbl偏移量.AutoSize = True
        Me.lbl偏移量.Location = New System.Drawing.Point(12, 169)
        Me.lbl偏移量.Name = "lbl偏移量"
        Me.lbl偏移量.Size = New System.Drawing.Size(53, 12)
        Me.lbl偏移量.TabIndex = 19
        Me.lbl偏移量.Text = "偏 移 量"
        '
        'lbl组件数量
        '
        Me.lbl组件数量.AutoSize = True
        Me.lbl组件数量.ForeColor = System.Drawing.Color.Red
        Me.lbl组件数量.Location = New System.Drawing.Point(140, 17)
        Me.lbl组件数量.Name = "lbl组件数量"
        Me.lbl组件数量.Size = New System.Drawing.Size(47, 12)
        Me.lbl组件数量.TabIndex = 20
        Me.lbl组件数量.Text = "已选择0"
        '
        'chk自动下一步
        '
        Me.chk自动下一步.AutoSize = True
        Me.chk自动下一步.Checked = True
        Me.chk自动下一步.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk自动下一步.Location = New System.Drawing.Point(14, 219)
        Me.chk自动下一步.Name = "chk自动下一步"
        Me.chk自动下一步.Size = New System.Drawing.Size(84, 16)
        Me.chk自动下一步.TabIndex = 21
        Me.chk自动下一步.Text = "自动下一步"
        Me.chk自动下一步.UseVisualStyleBackColor = True
        '
        'FormCloneComponent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(221, 252)
        Me.Controls.Add(Me.chk自动下一步)
        Me.Controls.Add(Me.lbl组件数量)
        Me.Controls.Add(Me.lbl偏移量)
        Me.Controls.Add(Me.lbl插入方向)
        Me.Controls.Add(Me.btn插入反向)
        Me.Controls.Add(Me.lbl插入的圆弧)
        Me.Controls.Add(Me.lbl组件圆弧)
        Me.Controls.Add(Me.lbl现有组件)
        Me.Controls.Add(Me.btn插入组件圆弧)
        Me.Controls.Add(Me.btn关闭)
        Me.Controls.Add(Me.txt偏移量)
        Me.Controls.Add(Me.btn选择现有组件)
        Me.Controls.Add(Me.btn选择组件圆弧)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCloneComponent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "复制组件"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn选择现有组件 As Button
    Friend WithEvents btn选择组件圆弧 As Button
    Friend WithEvents txt偏移量 As Windows.Forms.TextBox
    Friend WithEvents btn关闭 As Button
    Friend WithEvents btn插入组件圆弧 As Button
    Friend WithEvents lbl现有组件 As Label
    Friend WithEvents lbl组件圆弧 As Label
    Friend WithEvents lbl插入的圆弧 As Label
    Friend WithEvents btn插入反向 As Button
    Friend WithEvents lbl插入方向 As Label
    Friend WithEvents lbl偏移量 As Label
    Friend WithEvents lbl组件数量 As Label
    Friend WithEvents chk自动下一步 As CheckBox
End Class
