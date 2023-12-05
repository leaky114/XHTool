<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportCodeToBomExcel
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
        Me.btn导入 = New System.Windows.Forms.Button()
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.txt最后行 = New System.Windows.Forms.TextBox()
        Me.cmb查找列 = New System.Windows.Forms.ComboBox()
        Me.cmb写入列 = New System.Windows.Forms.ComboBox()
        Me.lbl最后行 = New System.Windows.Forms.Label()
        Me.lbl查找列 = New System.Windows.Forms.Label()
        Me.lbl写入列 = New System.Windows.Forms.Label()
        Me.txtExcel文件 = New System.Windows.Forms.TextBox()
        Me.btn打开excel文件 = New System.Windows.Forms.Button()
        Me.prgProcess = New System.Windows.Forms.ProgressBar()
        Me.lbl进度文件 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btn导入
        '
        Me.btn导入.Location = New System.Drawing.Point(360, 97)
        Me.btn导入.Name = "btn导入"
        Me.btn导入.Size = New System.Drawing.Size(65, 28)
        Me.btn导入.TabIndex = 1
        Me.btn导入.Text = "导入"
        '
        'btn关闭
        '
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(435, 97)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(65, 28)
        Me.btn关闭.TabIndex = 2
        Me.btn关闭.Text = "关闭"
        '
        'txt最后行
        '
        Me.txt最后行.Location = New System.Drawing.Point(3, 12)
        Me.txt最后行.Name = "txt最后行"
        Me.txt最后行.Size = New System.Drawing.Size(44, 21)
        Me.txt最后行.TabIndex = 14
        Me.txt最后行.Text = "200"
        '
        'cmb查找列
        '
        Me.cmb查找列.FormattingEnabled = True
        Me.cmb查找列.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J"})
        Me.cmb查找列.Location = New System.Drawing.Point(168, 12)
        Me.cmb查找列.Name = "cmb查找列"
        Me.cmb查找列.Size = New System.Drawing.Size(46, 20)
        Me.cmb查找列.Sorted = True
        Me.cmb查找列.TabIndex = 15
        Me.cmb查找列.Text = "B"
        '
        'cmb写入列
        '
        Me.cmb写入列.FormattingEnabled = True
        Me.cmb写入列.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J"})
        Me.cmb写入列.Location = New System.Drawing.Point(314, 12)
        Me.cmb写入列.Name = "cmb写入列"
        Me.cmb写入列.Size = New System.Drawing.Size(46, 20)
        Me.cmb写入列.Sorted = True
        Me.cmb写入列.TabIndex = 16
        Me.cmb写入列.Text = "C"
        '
        'lbl最后行
        '
        Me.lbl最后行.AutoSize = True
        Me.lbl最后行.Location = New System.Drawing.Point(53, 17)
        Me.lbl最后行.Name = "lbl最后行"
        Me.lbl最后行.Size = New System.Drawing.Size(41, 12)
        Me.lbl最后行.TabIndex = 17
        Me.lbl最后行.Text = "最后行"
        '
        'lbl查找列
        '
        Me.lbl查找列.AutoSize = True
        Me.lbl查找列.Location = New System.Drawing.Point(121, 17)
        Me.lbl查找列.Name = "lbl查找列"
        Me.lbl查找列.Size = New System.Drawing.Size(41, 12)
        Me.lbl查找列.TabIndex = 18
        Me.lbl查找列.Text = "查找列"
        '
        'lbl写入列
        '
        Me.lbl写入列.AutoSize = True
        Me.lbl写入列.Location = New System.Drawing.Point(267, 17)
        Me.lbl写入列.Name = "lbl写入列"
        Me.lbl写入列.Size = New System.Drawing.Size(41, 12)
        Me.lbl写入列.TabIndex = 19
        Me.lbl写入列.Text = "写入列"
        '
        'txtExcel文件
        '
        Me.txtExcel文件.Location = New System.Drawing.Point(3, 48)
        Me.txtExcel文件.Name = "txtExcel文件"
        Me.txtExcel文件.Size = New System.Drawing.Size(402, 21)
        Me.txtExcel文件.TabIndex = 20
        Me.txtExcel文件.Text = "选择Bom表Excel文件"
        '
        'btn打开excel文件
        '
        Me.btn打开excel文件.Location = New System.Drawing.Point(416, 47)
        Me.btn打开excel文件.Name = "btn打开excel文件"
        Me.btn打开excel文件.Size = New System.Drawing.Size(49, 25)
        Me.btn打开excel文件.TabIndex = 0
        Me.btn打开excel文件.Text = "打开"
        Me.btn打开excel文件.UseVisualStyleBackColor = True
        '
        'prgProcess
        '
        Me.prgProcess.Location = New System.Drawing.Point(3, 100)
        Me.prgProcess.Name = "prgProcess"
        Me.prgProcess.Size = New System.Drawing.Size(312, 22)
        Me.prgProcess.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.prgProcess.TabIndex = 22
        '
        'lbl进度文件
        '
        Me.lbl进度文件.AutoSize = True
        Me.lbl进度文件.Location = New System.Drawing.Point(9, 76)
        Me.lbl进度文件.Name = "lbl进度文件"
        Me.lbl进度文件.Size = New System.Drawing.Size(65, 12)
        Me.lbl进度文件.TabIndex = 23
        Me.lbl进度文件.Text = "当前零件："
        '
        'frmImportCodeToBomExcel
        '
        Me.AcceptButton = Me.btn打开excel文件
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn关闭
        Me.ClientSize = New System.Drawing.Size(503, 133)
        Me.Controls.Add(Me.lbl进度文件)
        Me.Controls.Add(Me.prgProcess)
        Me.Controls.Add(Me.btn打开excel文件)
        Me.Controls.Add(Me.txtExcel文件)
        Me.Controls.Add(Me.lbl写入列)
        Me.Controls.Add(Me.lbl查找列)
        Me.Controls.Add(Me.lbl最后行)
        Me.Controls.Add(Me.cmb写入列)
        Me.Controls.Add(Me.cmb查找列)
        Me.Controls.Add(Me.txt最后行)
        Me.Controls.Add(Me.btn导入)
        Me.Controls.Add(Me.btn关闭)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmImportCodeToBomExcel"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "导入ERP编码到Bom表"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn导入 As System.Windows.Forms.Button
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents txt最后行 As System.Windows.Forms.TextBox
    Friend WithEvents cmb查找列 As System.Windows.Forms.ComboBox
    Friend WithEvents cmb写入列 As System.Windows.Forms.ComboBox
    Friend WithEvents lbl最后行 As System.Windows.Forms.Label
    Friend WithEvents lbl查找列 As System.Windows.Forms.Label
    Friend WithEvents lbl写入列 As System.Windows.Forms.Label
    Friend WithEvents txtExcel文件 As System.Windows.Forms.TextBox
    Friend WithEvents btn打开excel文件 As System.Windows.Forms.Button
    Friend WithEvents prgProcess As System.Windows.Forms.ProgressBar
    Friend WithEvents lbl进度文件 As System.Windows.Forms.Label

End Class
