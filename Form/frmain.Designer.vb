<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmain
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理部件列表。
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmain))
        Me.Button更改零件部件文件名 = New System.Windows.Forms.Button
        Me.Button获取文件名修改ipropty = New System.Windows.Forms.Button
        Me.Button获取部件修改ipropty = New System.Windows.Forms.Button
        Me.Button自动生成零件图号 = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Button更改镜像零件文件名 = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Button提取iproperty更改文件名 = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.打开文件所在文件夹ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.保存关闭ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.另存为PDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.退出ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.部件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.导出BOM平面性ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.设置BOM结构ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.零件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.工程图ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.另存为DWGToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.比例ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.对称件IProToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.序号ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.检查序号完整性ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.新建序号ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.签字ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.签字ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.清除签字ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.自定义签字ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.工具ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.设置ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.量产ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.自定义属性ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.批量另存ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.关于ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.帮助ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Button1 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button更改零件部件文件名
        '
        Me.Button更改零件部件文件名.Location = New System.Drawing.Point(143, 26)
        Me.Button更改零件部件文件名.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button更改零件部件文件名.Name = "Button更改零件部件文件名"
        Me.Button更改零件部件文件名.Size = New System.Drawing.Size(56, 44)
        Me.Button更改零件部件文件名.TabIndex = 2
        Me.Button更改零件部件文件名.Text = "更改零件/部件文件名"
        Me.Button更改零件部件文件名.UseVisualStyleBackColor = True
        '
        'Button获取文件名修改ipropty
        '
        Me.Button获取文件名修改ipropty.Location = New System.Drawing.Point(5, 26)
        Me.Button获取文件名修改ipropty.Name = "Button获取文件名修改ipropty"
        Me.Button获取文件名修改ipropty.Size = New System.Drawing.Size(66, 44)
        Me.Button获取文件名修改ipropty.TabIndex = 0
        Me.Button获取文件名修改ipropty.Text = "获取文件名修改ipropty"
        Me.Button获取文件名修改ipropty.UseVisualStyleBackColor = True
        '
        'Button获取部件修改ipropty
        '
        Me.Button获取部件修改ipropty.Location = New System.Drawing.Point(74, 26)
        Me.Button获取部件修改ipropty.Name = "Button获取部件修改ipropty"
        Me.Button获取部件修改ipropty.Size = New System.Drawing.Size(66, 44)
        Me.Button获取部件修改ipropty.TabIndex = 1
        Me.Button获取部件修改ipropty.Text = "获取部件修改ipropty"
        Me.Button获取部件修改ipropty.UseVisualStyleBackColor = True
        '
        'Button自动生成零件图号
        '
        Me.Button自动生成零件图号.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button自动生成零件图号.Location = New System.Drawing.Point(278, 26)
        Me.Button自动生成零件图号.Name = "Button自动生成零件图号"
        Me.Button自动生成零件图号.Size = New System.Drawing.Size(56, 44)
        Me.Button自动生成零件图号.TabIndex = 4
        Me.Button自动生成零件图号.Text = "自动生成零件图号"
        Me.Button自动生成零件图号.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 84)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(598, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(583, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "说明"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Button更改镜像零件文件名
        '
        Me.Button更改镜像零件文件名.Location = New System.Drawing.Point(340, 26)
        Me.Button更改镜像零件文件名.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button更改镜像零件文件名.Name = "Button更改镜像零件文件名"
        Me.Button更改镜像零件文件名.Size = New System.Drawing.Size(56, 44)
        Me.Button更改镜像零件文件名.TabIndex = 5
        Me.Button更改镜像零件文件名.Text = "更改镜像零件文件名"
        Me.Button更改镜像零件文件名.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button提取iproperty更改文件名
        '
        Me.Button提取iproperty更改文件名.Location = New System.Drawing.Point(202, 26)
        Me.Button提取iproperty更改文件名.Name = "Button提取iproperty更改文件名"
        Me.Button提取iproperty更改文件名.Size = New System.Drawing.Size(73, 44)
        Me.Button提取iproperty更改文件名.TabIndex = 3
        Me.Button提取iproperty更改文件名.Text = "提取iproperty更改文件名"
        Me.Button提取iproperty更改文件名.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.文件ToolStripMenuItem, Me.部件ToolStripMenuItem, Me.零件ToolStripMenuItem, Me.工程图ToolStripMenuItem, Me.工具ToolStripMenuItem, Me.关于ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(598, 25)
        Me.MenuStrip1.TabIndex = 17
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '文件ToolStripMenuItem
        '
        Me.文件ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.打开文件所在文件夹ToolStripMenuItem, Me.保存关闭ToolStripMenuItem, Me.另存为PDFToolStripMenuItem, Me.ToolStripSeparator1, Me.退出ToolStripMenuItem})
        Me.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem"
        Me.文件ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.文件ToolStripMenuItem.Text = "文件"
        '
        '打开文件所在文件夹ToolStripMenuItem
        '
        Me.打开文件所在文件夹ToolStripMenuItem.Name = "打开文件所在文件夹ToolStripMenuItem"
        Me.打开文件所在文件夹ToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.打开文件所在文件夹ToolStripMenuItem.Text = "打开文件所在文件夹"
        '
        '保存关闭ToolStripMenuItem
        '
        Me.保存关闭ToolStripMenuItem.Name = "保存关闭ToolStripMenuItem"
        Me.保存关闭ToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.保存关闭ToolStripMenuItem.Text = "保存关闭"
        '
        '另存为PDFToolStripMenuItem
        '
        Me.另存为PDFToolStripMenuItem.Name = "另存为PDFToolStripMenuItem"
        Me.另存为PDFToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.另存为PDFToolStripMenuItem.Text = "另存为PDF"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(181, 6)
        '
        '退出ToolStripMenuItem
        '
        Me.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem"
        Me.退出ToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.退出ToolStripMenuItem.Text = "退出"
        '
        '部件ToolStripMenuItem
        '
        Me.部件ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.导出BOM平面性ToolStripMenuItem, Me.设置BOM结构ToolStripMenuItem})
        Me.部件ToolStripMenuItem.Name = "部件ToolStripMenuItem"
        Me.部件ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.部件ToolStripMenuItem.Text = "部件"
        '
        '导出BOM平面性ToolStripMenuItem
        '
        Me.导出BOM平面性ToolStripMenuItem.Name = "导出BOM平面性ToolStripMenuItem"
        Me.导出BOM平面性ToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.导出BOM平面性ToolStripMenuItem.Text = "导出BOM层次"
        '
        '设置BOM结构ToolStripMenuItem
        '
        Me.设置BOM结构ToolStripMenuItem.Name = "设置BOM结构ToolStripMenuItem"
        Me.设置BOM结构ToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.设置BOM结构ToolStripMenuItem.Text = "设置BOM结构"
        '
        '零件ToolStripMenuItem
        '
        Me.零件ToolStripMenuItem.Name = "零件ToolStripMenuItem"
        Me.零件ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.零件ToolStripMenuItem.Text = "零件"
        '
        '工程图ToolStripMenuItem
        '
        Me.工程图ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.另存为DWGToolStripMenuItem, Me.比例ToolStripMenuItem, Me.对称件IProToolStripMenuItem, Me.序号ToolStripMenuItem, Me.签字ToolStripMenuItem})
        Me.工程图ToolStripMenuItem.Name = "工程图ToolStripMenuItem"
        Me.工程图ToolStripMenuItem.Size = New System.Drawing.Size(56, 21)
        Me.工程图ToolStripMenuItem.Text = "工程图"
        '
        '另存为DWGToolStripMenuItem
        '
        Me.另存为DWGToolStripMenuItem.Name = "另存为DWGToolStripMenuItem"
        Me.另存为DWGToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.另存为DWGToolStripMenuItem.Text = "另存为DWG"
        '
        '比例ToolStripMenuItem
        '
        Me.比例ToolStripMenuItem.Name = "比例ToolStripMenuItem"
        Me.比例ToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.比例ToolStripMenuItem.Text = "比例"
        '
        '对称件IProToolStripMenuItem
        '
        Me.对称件IProToolStripMenuItem.Name = "对称件IProToolStripMenuItem"
        Me.对称件IProToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.对称件IProToolStripMenuItem.Text = "对称件IPro"
        '
        '序号ToolStripMenuItem
        '
        Me.序号ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.检查序号完整性ToolStripMenuItem, Me.新建序号ToolStripMenuItem})
        Me.序号ToolStripMenuItem.Name = "序号ToolStripMenuItem"
        Me.序号ToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.序号ToolStripMenuItem.Text = "序号"
        '
        '检查序号完整性ToolStripMenuItem
        '
        Me.检查序号完整性ToolStripMenuItem.Name = "检查序号完整性ToolStripMenuItem"
        Me.检查序号完整性ToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.检查序号完整性ToolStripMenuItem.Text = "检查序号完整性"
        '
        '新建序号ToolStripMenuItem
        '
        Me.新建序号ToolStripMenuItem.Name = "新建序号ToolStripMenuItem"
        Me.新建序号ToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.新建序号ToolStripMenuItem.Text = "新建序号"
        '
        '签字ToolStripMenuItem
        '
        Me.签字ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.签字ToolStripMenuItem1, Me.清除签字ToolStripMenuItem, Me.自定义签字ToolStripMenuItem})
        Me.签字ToolStripMenuItem.Name = "签字ToolStripMenuItem"
        Me.签字ToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.签字ToolStripMenuItem.Text = "签字"
        '
        '签字ToolStripMenuItem1
        '
        Me.签字ToolStripMenuItem1.Name = "签字ToolStripMenuItem1"
        Me.签字ToolStripMenuItem1.Size = New System.Drawing.Size(136, 22)
        Me.签字ToolStripMenuItem1.Text = "签字"
        '
        '清除签字ToolStripMenuItem
        '
        Me.清除签字ToolStripMenuItem.Name = "清除签字ToolStripMenuItem"
        Me.清除签字ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.清除签字ToolStripMenuItem.Text = "清除签字"
        '
        '自定义签字ToolStripMenuItem
        '
        Me.自定义签字ToolStripMenuItem.Name = "自定义签字ToolStripMenuItem"
        Me.自定义签字ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.自定义签字ToolStripMenuItem.Text = "自定义签字"
        '
        '工具ToolStripMenuItem
        '
        Me.工具ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.设置ToolStripMenuItem, Me.量产ToolStripMenuItem})
        Me.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem"
        Me.工具ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.工具ToolStripMenuItem.Text = "工具"
        '
        '设置ToolStripMenuItem
        '
        Me.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem"
        Me.设置ToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.设置ToolStripMenuItem.Text = "设置"
        '
        '量产ToolStripMenuItem
        '
        Me.量产ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.自定义属性ToolStripMenuItem, Me.批量另存ToolStripMenuItem})
        Me.量产ToolStripMenuItem.Name = "量产ToolStripMenuItem"
        Me.量产ToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.量产ToolStripMenuItem.Text = "量产"
        '
        '自定义属性ToolStripMenuItem
        '
        Me.自定义属性ToolStripMenuItem.Name = "自定义属性ToolStripMenuItem"
        Me.自定义属性ToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.自定义属性ToolStripMenuItem.Text = "iPoperties"
        '
        '批量另存ToolStripMenuItem
        '
        Me.批量另存ToolStripMenuItem.Name = "批量另存ToolStripMenuItem"
        Me.批量另存ToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.批量另存ToolStripMenuItem.Text = "批量另存..."
        '
        '关于ToolStripMenuItem
        '
        Me.关于ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.帮助ToolStripMenuItem})
        Me.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem"
        Me.关于ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.关于ToolStripMenuItem.Text = "关于"
        '
        '帮助ToolStripMenuItem
        '
        Me.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem"
        Me.帮助ToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.帮助ToolStripMenuItem.Text = "帮助"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(413, 31)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(173, 39)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "测试"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(565, 124)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(170, 152)
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'frmain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(598, 106)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button更改镜像零件文件名)
        Me.Controls.Add(Me.Button提取iproperty更改文件名)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Button获取文件名修改ipropty)
        Me.Controls.Add(Me.Button自动生成零件图号)
        Me.Controls.Add(Me.Button获取部件修改ipropty)
        Me.Controls.Add(Me.Button更改零件部件文件名)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.Name = "frmain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "批量替换部件中子集文件名"
        Me.TopMost = True
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button更改零件部件文件名 As System.Windows.Forms.Button
    Friend WithEvents Button获取文件名修改ipropty As System.Windows.Forms.Button
    Friend WithEvents Button获取部件修改ipropty As System.Windows.Forms.Button
    Friend WithEvents Button自动生成零件图号 As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Button更改镜像零件文件名 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button提取iproperty更改文件名 As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents 文件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 保存关闭ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 关于ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 帮助ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 工具ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 设置ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 另存为PDFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 工程图ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 对称件IProToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 比例ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 签字ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 签字ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 清除签字ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 自定义签字ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 量产ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 自定义属性ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 退出ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 序号ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 新建序号ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 检查序号完整性ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 部件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 零件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 另存为DWGToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 导出BOM平面性ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 打开文件所在文件夹ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 批量另存ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 设置BOM结构ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
