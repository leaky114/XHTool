Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormOilBlockHoleColoring
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
        Me.GroupBox忽略特征 = New System.Windows.Forms.GroupBox()
        Me.btn移出忽略特征 = New System.Windows.Forms.Button()
        Me.btn添加忽略特征 = New System.Windows.Forms.Button()
        Me.ListBox忽略特征 = New System.Windows.Forms.ListBox()
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.btn选择面 = New System.Windows.Forms.Button()
        Me.cbo外观 = New System.Windows.Forms.ComboBox()
        Me.GroupBox忽略特征.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox忽略特征
        '
        Me.GroupBox忽略特征.Controls.Add(Me.btn移出忽略特征)
        Me.GroupBox忽略特征.Controls.Add(Me.btn添加忽略特征)
        Me.GroupBox忽略特征.Controls.Add(Me.ListBox忽略特征)
        Me.GroupBox忽略特征.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox忽略特征.Name = "GroupBox忽略特征"
        Me.GroupBox忽略特征.Size = New System.Drawing.Size(148, 181)
        Me.GroupBox忽略特征.TabIndex = 2
        Me.GroupBox忽略特征.TabStop = False
        Me.GroupBox忽略特征.Text = "忽略特征"
        '
        'btn移出忽略特征
        '
        Me.btn移出忽略特征.Location = New System.Drawing.Point(46, 137)
        Me.btn移出忽略特征.Name = "btn移出忽略特征"
        Me.btn移出忽略特征.Size = New System.Drawing.Size(32, 32)
        Me.btn移出忽略特征.TabIndex = 4
        Me.btn移出忽略特征.UseVisualStyleBackColor = True
        '
        'btn添加忽略特征
        '
        Me.btn添加忽略特征.Location = New System.Drawing.Point(11, 137)
        Me.btn添加忽略特征.Name = "btn添加忽略特征"
        Me.btn添加忽略特征.Size = New System.Drawing.Size(32, 32)
        Me.btn添加忽略特征.TabIndex = 3
        Me.btn添加忽略特征.UseVisualStyleBackColor = True
        '
        'ListBox忽略特征
        '
        Me.ListBox忽略特征.FormattingEnabled = True
        Me.ListBox忽略特征.ItemHeight = 12
        Me.ListBox忽略特征.Location = New System.Drawing.Point(6, 20)
        Me.ListBox忽略特征.Name = "ListBox忽略特征"
        Me.ListBox忽略特征.Size = New System.Drawing.Size(136, 112)
        Me.ListBox忽略特征.TabIndex = 2
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(87, 231)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(75, 28)
        Me.btn关闭.TabIndex = 4
        Me.btn关闭.Text = "关闭"
        '
        'btn选择面
        '
        Me.btn选择面.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn选择面.Location = New System.Drawing.Point(18, 227)
        Me.btn选择面.Name = "btn选择面"
        Me.btn选择面.Size = New System.Drawing.Size(32, 32)
        Me.btn选择面.TabIndex = 7
        Me.btn选择面.UseVisualStyleBackColor = True
        '
        'cbo外观
        '
        Me.cbo外观.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo外观.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbo外观.FormattingEnabled = True
        Me.cbo外观.Location = New System.Drawing.Point(12, 199)
        Me.cbo外观.Name = "cbo外观"
        Me.cbo外观.Size = New System.Drawing.Size(141, 20)
        Me.cbo外观.Sorted = True
        Me.cbo外观.TabIndex = 8
        '
        'FormOilBlockHoleColoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(174, 271)
        Me.Controls.Add(Me.cbo外观)
        Me.Controls.Add(Me.btn选择面)
        Me.Controls.Add(Me.btn关闭)
        Me.Controls.Add(Me.GroupBox忽略特征)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormOilBlockHoleColoring"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "油路块孔着色"
        Me.TopMost = True
        Me.GroupBox忽略特征.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub


    Friend WithEvents GroupBox忽略特征 As GroupBox
    Friend WithEvents ListBox忽略特征 As ListBox
    Friend WithEvents btn关闭 As Button
    Friend WithEvents btn移出忽略特征 As Button
    Friend WithEvents btn添加忽略特征 As Button
    Friend WithEvents btn选择面 As Button
    Friend WithEvents cbo外观 As ComboBox
End Class
