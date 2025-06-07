Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPaint
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
        Me.N_TopCoat = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.N_MiddleCoat = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.N_UnderCoat = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.l_TopCoatTotal = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.l_MiddleCoatTotal = New System.Windows.Forms.Label()
        Me.l_AreaTotal = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.l_UnderCoatTotal = New System.Windows.Forms.Label()
        Me.Btn_Enter = New System.Windows.Forms.Button()
        Me.Btn_Close = New System.Windows.Forms.Button()
        Me.R_Brush = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.R_Spray = New System.Windows.Forms.RadioButton()
        CType(Me.N_TopCoat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.N_MiddleCoat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.N_UnderCoat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'N_TopCoat
        '
        Me.N_TopCoat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.N_TopCoat.Location = New System.Drawing.Point(103, 98)
        Me.N_TopCoat.Margin = New System.Windows.Forms.Padding(4)
        Me.N_TopCoat.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.N_TopCoat.Name = "N_TopCoat"
        Me.N_TopCoat.Size = New System.Drawing.Size(115, 21)
        Me.N_TopCoat.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(226, 32)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 12)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "μm"
        '
        'N_MiddleCoat
        '
        Me.N_MiddleCoat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.N_MiddleCoat.Location = New System.Drawing.Point(103, 64)
        Me.N_MiddleCoat.Margin = New System.Windows.Forms.Padding(4)
        Me.N_MiddleCoat.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.N_MiddleCoat.Name = "N_MiddleCoat"
        Me.N_MiddleCoat.Size = New System.Drawing.Size(115, 21)
        Me.N_MiddleCoat.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(226, 68)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 12)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "μm"
        '
        'N_UnderCoat
        '
        Me.N_UnderCoat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.N_UnderCoat.Location = New System.Drawing.Point(103, 30)
        Me.N_UnderCoat.Margin = New System.Windows.Forms.Padding(4)
        Me.N_UnderCoat.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.N_UnderCoat.Name = "N_UnderCoat"
        Me.N_UnderCoat.Size = New System.Drawing.Size(115, 21)
        Me.N_UnderCoat.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(226, 101)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "μm"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 31)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "表面积："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 57)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "底漆用量："
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 83)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 12)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "中间漆用量："
        '
        'l_TopCoatTotal
        '
        Me.l_TopCoatTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.l_TopCoatTotal.AutoSize = True
        Me.l_TopCoatTotal.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.l_TopCoatTotal.Location = New System.Drawing.Point(108, 109)
        Me.l_TopCoatTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.l_TopCoatTotal.Name = "l_TopCoatTotal"
        Me.l_TopCoatTotal.Size = New System.Drawing.Size(12, 12)
        Me.l_TopCoatTotal.TabIndex = 1
        Me.l_TopCoatTotal.Text = "-"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 109)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 12)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "面漆用量："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 68)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "中间漆厚度："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 32)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "底漆厚度："
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.N_TopCoat)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.N_MiddleCoat)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.N_UnderCoat)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(12, 64)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(257, 133)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "干膜厚度"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 101)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "面漆厚度："
        '
        'l_MiddleCoatTotal
        '
        Me.l_MiddleCoatTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.l_MiddleCoatTotal.AutoSize = True
        Me.l_MiddleCoatTotal.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.l_MiddleCoatTotal.Location = New System.Drawing.Point(108, 83)
        Me.l_MiddleCoatTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.l_MiddleCoatTotal.Name = "l_MiddleCoatTotal"
        Me.l_MiddleCoatTotal.Size = New System.Drawing.Size(12, 12)
        Me.l_MiddleCoatTotal.TabIndex = 1
        Me.l_MiddleCoatTotal.Text = "-"
        '
        'l_AreaTotal
        '
        Me.l_AreaTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.l_AreaTotal.AutoSize = True
        Me.l_AreaTotal.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.l_AreaTotal.Location = New System.Drawing.Point(108, 31)
        Me.l_AreaTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.l_AreaTotal.Name = "l_AreaTotal"
        Me.l_AreaTotal.Size = New System.Drawing.Size(12, 12)
        Me.l_AreaTotal.TabIndex = 1
        Me.l_AreaTotal.Text = "-"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.l_TopCoatTotal)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.l_MiddleCoatTotal)
        Me.GroupBox3.Controls.Add(Me.l_AreaTotal)
        Me.GroupBox3.Controls.Add(Me.l_UnderCoatTotal)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox3.Location = New System.Drawing.Point(12, 205)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(257, 138)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "计算结果"
        '
        'l_UnderCoatTotal
        '
        Me.l_UnderCoatTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.l_UnderCoatTotal.AutoSize = True
        Me.l_UnderCoatTotal.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.l_UnderCoatTotal.Location = New System.Drawing.Point(108, 57)
        Me.l_UnderCoatTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.l_UnderCoatTotal.Name = "l_UnderCoatTotal"
        Me.l_UnderCoatTotal.Size = New System.Drawing.Size(12, 12)
        Me.l_UnderCoatTotal.TabIndex = 1
        Me.l_UnderCoatTotal.Text = "-"
        '
        'Btn_Enter
        '
        Me.Btn_Enter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Enter.Location = New System.Drawing.Point(118, 352)
        Me.Btn_Enter.Name = "Btn_Enter"
        Me.Btn_Enter.Size = New System.Drawing.Size(73, 33)
        Me.Btn_Enter.TabIndex = 13
        Me.Btn_Enter.Text = "计算"
        Me.Btn_Enter.UseVisualStyleBackColor = True
        '
        'Btn_Close
        '
        Me.Btn_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Btn_Close.Location = New System.Drawing.Point(197, 352)
        Me.Btn_Close.Name = "Btn_Close"
        Me.Btn_Close.Size = New System.Drawing.Size(73, 33)
        Me.Btn_Close.TabIndex = 14
        Me.Btn_Close.Text = "关闭"
        Me.Btn_Close.UseVisualStyleBackColor = True
        '
        'R_Brush
        '
        Me.R_Brush.AutoSize = True
        Me.R_Brush.Location = New System.Drawing.Point(110, 20)
        Me.R_Brush.Name = "R_Brush"
        Me.R_Brush.Size = New System.Drawing.Size(47, 16)
        Me.R_Brush.TabIndex = 0
        Me.R_Brush.Text = "刷涂"
        Me.R_Brush.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.R_Brush)
        Me.GroupBox1.Controls.Add(Me.R_Spray)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(257, 45)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "施工方式"
        '
        'R_Spray
        '
        Me.R_Spray.AutoSize = True
        Me.R_Spray.Checked = True
        Me.R_Spray.Location = New System.Drawing.Point(14, 20)
        Me.R_Spray.Name = "R_Spray"
        Me.R_Spray.Size = New System.Drawing.Size(47, 16)
        Me.R_Spray.TabIndex = 0
        Me.R_Spray.TabStop = True
        Me.R_Spray.Text = "喷涂"
        Me.R_Spray.UseVisualStyleBackColor = True
        '
        'FormPaint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(282, 397)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Btn_Enter)
        Me.Controls.Add(Me.Btn_Close)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(298, 436)
        Me.Name = "FormPaint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "油漆用量"
        CType(Me.N_TopCoat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.N_MiddleCoat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.N_UnderCoat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents N_TopCoat As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents N_MiddleCoat As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents N_UnderCoat As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents l_TopCoatTotal As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents l_MiddleCoatTotal As Label
    Friend WithEvents l_AreaTotal As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents l_UnderCoatTotal As Label
    Friend WithEvents Btn_Enter As Button
    Friend WithEvents Btn_Close As Button
    Friend WithEvents R_Brush As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents R_Spray As RadioButton
End Class
