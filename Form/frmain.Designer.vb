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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmain))
        Me.Button更改零件部件文件名 = New System.Windows.Forms.Button()
        Me.Button获取文件名修改ipropty = New System.Windows.Forms.Button()
        Me.Button获取部件修改ipropty = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Button更改镜像零件文件名 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.快速打开ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.保存关闭ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.关闭ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打开文件所在文件夹ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.保存关闭所有文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.退出ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.零部件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打开工程图ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.检查是否有工程图ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打开指定工程图ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.查找缺失部件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.距离对齐ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.对齐原始坐标面ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.移动指定文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.提取iproperty更改文件名ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.批量替换文件名ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.随机颜色ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.设置随机颜色ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.清除颜色ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.全部可见ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.生成图号ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.设置虚拟件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.设置只读ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.标准件可见性ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.替换为库文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.动态尺寸ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.创建展开图ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.创建工程图ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.查找替换ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.抑制错误约束ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.工程图ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.对称件IProToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.替换图框ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.技术要求ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.另存为PDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.另存为DWGToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.另存为STPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.尺寸ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.添加直径ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.尺寸圆整ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.尺寸居中ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.全部居中ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.序号ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.检查序号完整性ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.新建序号ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.自动重建序号ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.重写BOM序号ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.签字ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.签字ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.清除签字ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.自定义签字ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打印ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.快速打印ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.批量打印ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ERPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.查询ERP编码ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ERP反查ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.导出BOM平面性ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.导入ERPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.导入ERP到BOMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打开数据文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.工具ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.设置ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.工程图批量另存为ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.还原旧图ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.清理旧版文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.量产iPropertyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.刷新引用ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.统计焊缝ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.动画设计ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.驱动测量ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.关于ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.帮助ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ButtoniProperty = New System.Windows.Forms.Button()
        Me.保存为图片ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.按列表打开ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
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
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 96)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(536, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(521, 17)
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
        Me.Button更改镜像零件文件名.Location = New System.Drawing.Point(205, 28)
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
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.文件ToolStripMenuItem, Me.零部件ToolStripMenuItem, Me.工程图ToolStripMenuItem, Me.尺寸ToolStripMenuItem, Me.序号ToolStripMenuItem, Me.签字ToolStripMenuItem, Me.打印ToolStripMenuItem, Me.ERPToolStripMenuItem, Me.工具ToolStripMenuItem, Me.关于ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(536, 25)
        Me.MenuStrip1.TabIndex = 17
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '文件ToolStripMenuItem
        '
        Me.文件ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.快速打开ToolStripMenuItem, Me.按列表打开ToolStripMenuItem, Me.保存关闭ToolStripMenuItem, Me.关闭ToolStripMenuItem, Me.打开文件所在文件夹ToolStripMenuItem, Me.保存关闭所有文件ToolStripMenuItem, Me.ToolStripSeparator1, Me.退出ToolStripMenuItem})
        Me.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem"
        Me.文件ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.文件ToolStripMenuItem.Text = "文件"
        '
        '快速打开ToolStripMenuItem
        '
        Me.快速打开ToolStripMenuItem.Name = "快速打开ToolStripMenuItem"
        Me.快速打开ToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.快速打开ToolStripMenuItem.Text = "快速打开"
        '
        '保存关闭ToolStripMenuItem
        '
        Me.保存关闭ToolStripMenuItem.Name = "保存关闭ToolStripMenuItem"
        Me.保存关闭ToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.保存关闭ToolStripMenuItem.Text = "保存关闭"
        '
        '关闭ToolStripMenuItem
        '
        Me.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem"
        Me.关闭ToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.关闭ToolStripMenuItem.Text = "关闭"
        '
        '打开文件所在文件夹ToolStripMenuItem
        '
        Me.打开文件所在文件夹ToolStripMenuItem.Name = "打开文件所在文件夹ToolStripMenuItem"
        Me.打开文件所在文件夹ToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.打开文件所在文件夹ToolStripMenuItem.Text = "打开文件所在文件夹"
        '
        '保存关闭所有文件ToolStripMenuItem
        '
        Me.保存关闭所有文件ToolStripMenuItem.Name = "保存关闭所有文件ToolStripMenuItem"
        Me.保存关闭所有文件ToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.保存关闭所有文件ToolStripMenuItem.Text = "保存关闭所有文件"
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
        '零部件ToolStripMenuItem
        '
        Me.零部件ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.打开工程图ToolStripMenuItem, Me.检查是否有工程图ToolStripMenuItem, Me.打开指定工程图ToolStripMenuItem, Me.ToolStripSeparator3, Me.查找缺失部件ToolStripMenuItem, Me.距离对齐ToolStripMenuItem, Me.对齐原始坐标面ToolStripMenuItem, Me.移动指定文件ToolStripMenuItem, Me.ToolStripSeparator4, Me.提取iproperty更改文件名ToolStripMenuItem, Me.批量替换文件名ToolStripMenuItem, Me.随机颜色ToolStripMenuItem, Me.全部可见ToolStripMenuItem, Me.生成图号ToolStripMenuItem, Me.设置虚拟件ToolStripMenuItem, Me.设置只读ToolStripMenuItem, Me.标准件可见性ToolStripMenuItem, Me.替换为库文件ToolStripMenuItem, Me.动态尺寸ToolStripMenuItem, Me.创建展开图ToolStripMenuItem, Me.创建工程图ToolStripMenuItem, Me.查找替换ToolStripMenuItem, Me.抑制错误约束ToolStripMenuItem, Me.保存为图片ToolStripMenuItem})
        Me.零部件ToolStripMenuItem.Name = "零部件ToolStripMenuItem"
        Me.零部件ToolStripMenuItem.Size = New System.Drawing.Size(56, 21)
        Me.零部件ToolStripMenuItem.Text = "零部件"
        '
        '打开工程图ToolStripMenuItem
        '
        Me.打开工程图ToolStripMenuItem.Name = "打开工程图ToolStripMenuItem"
        Me.打开工程图ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.打开工程图ToolStripMenuItem.Text = "打开工程图"
        '
        '检查是否有工程图ToolStripMenuItem
        '
        Me.检查是否有工程图ToolStripMenuItem.Name = "检查是否有工程图ToolStripMenuItem"
        Me.检查是否有工程图ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.检查是否有工程图ToolStripMenuItem.Text = "检查是否有工程图"
        '
        '打开指定工程图ToolStripMenuItem
        '
        Me.打开指定工程图ToolStripMenuItem.Name = "打开指定工程图ToolStripMenuItem"
        Me.打开指定工程图ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.打开指定工程图ToolStripMenuItem.Text = "打开指定工程图"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(211, 6)
        '
        '查找缺失部件ToolStripMenuItem
        '
        Me.查找缺失部件ToolStripMenuItem.Name = "查找缺失部件ToolStripMenuItem"
        Me.查找缺失部件ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.查找缺失部件ToolStripMenuItem.Text = "查找缺失文件"
        '
        '距离对齐ToolStripMenuItem
        '
        Me.距离对齐ToolStripMenuItem.Name = "距离对齐ToolStripMenuItem"
        Me.距离对齐ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.距离对齐ToolStripMenuItem.Text = "距离对齐"
        '
        '对齐原始坐标面ToolStripMenuItem
        '
        Me.对齐原始坐标面ToolStripMenuItem.Name = "对齐原始坐标面ToolStripMenuItem"
        Me.对齐原始坐标面ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.对齐原始坐标面ToolStripMenuItem.Text = "对齐原始坐标面"
        '
        '移动指定文件ToolStripMenuItem
        '
        Me.移动指定文件ToolStripMenuItem.Name = "移动指定文件ToolStripMenuItem"
        Me.移动指定文件ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.移动指定文件ToolStripMenuItem.Text = "移动指定文件"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(211, 6)
        '
        '提取iproperty更改文件名ToolStripMenuItem
        '
        Me.提取iproperty更改文件名ToolStripMenuItem.Name = "提取iproperty更改文件名ToolStripMenuItem"
        Me.提取iproperty更改文件名ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.提取iproperty更改文件名ToolStripMenuItem.Text = "提取iproperty更改文件名"
        '
        '批量替换文件名ToolStripMenuItem
        '
        Me.批量替换文件名ToolStripMenuItem.Name = "批量替换文件名ToolStripMenuItem"
        Me.批量替换文件名ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.批量替换文件名ToolStripMenuItem.Text = "批量替换文件名"
        '
        '随机颜色ToolStripMenuItem
        '
        Me.随机颜色ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.设置随机颜色ToolStripMenuItem, Me.清除颜色ToolStripMenuItem})
        Me.随机颜色ToolStripMenuItem.Name = "随机颜色ToolStripMenuItem"
        Me.随机颜色ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.随机颜色ToolStripMenuItem.Text = "随机颜色"
        '
        '设置随机颜色ToolStripMenuItem
        '
        Me.设置随机颜色ToolStripMenuItem.Name = "设置随机颜色ToolStripMenuItem"
        Me.设置随机颜色ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.设置随机颜色ToolStripMenuItem.Text = "设置颜色"
        '
        '清除颜色ToolStripMenuItem
        '
        Me.清除颜色ToolStripMenuItem.Name = "清除颜色ToolStripMenuItem"
        Me.清除颜色ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.清除颜色ToolStripMenuItem.Text = "清除颜色"
        '
        '全部可见ToolStripMenuItem
        '
        Me.全部可见ToolStripMenuItem.Name = "全部可见ToolStripMenuItem"
        Me.全部可见ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.全部可见ToolStripMenuItem.Text = "全部可见"
        '
        '生成图号ToolStripMenuItem
        '
        Me.生成图号ToolStripMenuItem.Name = "生成图号ToolStripMenuItem"
        Me.生成图号ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.生成图号ToolStripMenuItem.Text = "生成图号"
        '
        '设置虚拟件ToolStripMenuItem
        '
        Me.设置虚拟件ToolStripMenuItem.Name = "设置虚拟件ToolStripMenuItem"
        Me.设置虚拟件ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.设置虚拟件ToolStripMenuItem.Text = "设置虚拟件"
        '
        '设置只读ToolStripMenuItem
        '
        Me.设置只读ToolStripMenuItem.Name = "设置只读ToolStripMenuItem"
        Me.设置只读ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.设置只读ToolStripMenuItem.Text = "设置只读"
        '
        '标准件可见性ToolStripMenuItem
        '
        Me.标准件可见性ToolStripMenuItem.Name = "标准件可见性ToolStripMenuItem"
        Me.标准件可见性ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.标准件可见性ToolStripMenuItem.Text = "标准件可见"
        '
        '替换为库文件ToolStripMenuItem
        '
        Me.替换为库文件ToolStripMenuItem.Name = "替换为库文件ToolStripMenuItem"
        Me.替换为库文件ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.替换为库文件ToolStripMenuItem.Text = "替换为库文件"
        '
        '动态尺寸ToolStripMenuItem
        '
        Me.动态尺寸ToolStripMenuItem.Name = "动态尺寸ToolStripMenuItem"
        Me.动态尺寸ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.动态尺寸ToolStripMenuItem.Text = "动态尺寸"
        '
        '创建展开图ToolStripMenuItem
        '
        Me.创建展开图ToolStripMenuItem.Name = "创建展开图ToolStripMenuItem"
        Me.创建展开图ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.创建展开图ToolStripMenuItem.Text = "创建展开图"
        '
        '创建工程图ToolStripMenuItem
        '
        Me.创建工程图ToolStripMenuItem.Name = "创建工程图ToolStripMenuItem"
        Me.创建工程图ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.创建工程图ToolStripMenuItem.Text = "创建工程图"
        '
        '查找替换ToolStripMenuItem
        '
        Me.查找替换ToolStripMenuItem.Name = "查找替换ToolStripMenuItem"
        Me.查找替换ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.查找替换ToolStripMenuItem.Text = "查找替换"
        '
        '抑制错误约束ToolStripMenuItem
        '
        Me.抑制错误约束ToolStripMenuItem.Name = "抑制错误约束ToolStripMenuItem"
        Me.抑制错误约束ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.抑制错误约束ToolStripMenuItem.Text = "抑制错误约束"
        '
        '工程图ToolStripMenuItem
        '
        Me.工程图ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.对称件IProToolStripMenuItem, Me.替换图框ToolStripMenuItem, Me.技术要求ToolStripMenuItem, Me.另存为PDFToolStripMenuItem, Me.另存为DWGToolStripMenuItem, Me.另存为STPToolStripMenuItem})
        Me.工程图ToolStripMenuItem.Name = "工程图ToolStripMenuItem"
        Me.工程图ToolStripMenuItem.Size = New System.Drawing.Size(56, 21)
        Me.工程图ToolStripMenuItem.Text = "工程图"
        '
        '对称件IProToolStripMenuItem
        '
        Me.对称件IProToolStripMenuItem.Name = "对称件IProToolStripMenuItem"
        Me.对称件IProToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.对称件IProToolStripMenuItem.Text = "对称件IPro"
        '
        '替换图框ToolStripMenuItem
        '
        Me.替换图框ToolStripMenuItem.Name = "替换图框ToolStripMenuItem"
        Me.替换图框ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.替换图框ToolStripMenuItem.Text = "替换图框"
        '
        '技术要求ToolStripMenuItem
        '
        Me.技术要求ToolStripMenuItem.Name = "技术要求ToolStripMenuItem"
        Me.技术要求ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.技术要求ToolStripMenuItem.Text = "技术要求"
        '
        '另存为PDFToolStripMenuItem
        '
        Me.另存为PDFToolStripMenuItem.Name = "另存为PDFToolStripMenuItem"
        Me.另存为PDFToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.另存为PDFToolStripMenuItem.Text = "另存为PDF"
        '
        '另存为DWGToolStripMenuItem
        '
        Me.另存为DWGToolStripMenuItem.Name = "另存为DWGToolStripMenuItem"
        Me.另存为DWGToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.另存为DWGToolStripMenuItem.Text = "另存为DWG"
        '
        '另存为STPToolStripMenuItem
        '
        Me.另存为STPToolStripMenuItem.Name = "另存为STPToolStripMenuItem"
        Me.另存为STPToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.另存为STPToolStripMenuItem.Text = "另存为STP"
        '
        '尺寸ToolStripMenuItem
        '
        Me.尺寸ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.添加直径ToolStripMenuItem, Me.尺寸圆整ToolStripMenuItem, Me.尺寸居中ToolStripMenuItem, Me.全部居中ToolStripMenuItem})
        Me.尺寸ToolStripMenuItem.Name = "尺寸ToolStripMenuItem"
        Me.尺寸ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.尺寸ToolStripMenuItem.Text = "尺寸"
        '
        '添加直径ToolStripMenuItem
        '
        Me.添加直径ToolStripMenuItem.Name = "添加直径ToolStripMenuItem"
        Me.添加直径ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.添加直径ToolStripMenuItem.Text = "添加直径"
        '
        '尺寸圆整ToolStripMenuItem
        '
        Me.尺寸圆整ToolStripMenuItem.Name = "尺寸圆整ToolStripMenuItem"
        Me.尺寸圆整ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.尺寸圆整ToolStripMenuItem.Text = "尺寸圆整"
        '
        '尺寸居中ToolStripMenuItem
        '
        Me.尺寸居中ToolStripMenuItem.Name = "尺寸居中ToolStripMenuItem"
        Me.尺寸居中ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.尺寸居中ToolStripMenuItem.Text = "尺寸居中"
        '
        '全部居中ToolStripMenuItem
        '
        Me.全部居中ToolStripMenuItem.Name = "全部居中ToolStripMenuItem"
        Me.全部居中ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.全部居中ToolStripMenuItem.Text = "全部居中"
        '
        '序号ToolStripMenuItem
        '
        Me.序号ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.检查序号完整性ToolStripMenuItem, Me.新建序号ToolStripMenuItem, Me.自动重建序号ToolStripMenuItem, Me.重写BOM序号ToolStripMenuItem})
        Me.序号ToolStripMenuItem.Name = "序号ToolStripMenuItem"
        Me.序号ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
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
        '自动重建序号ToolStripMenuItem
        '
        Me.自动重建序号ToolStripMenuItem.Name = "自动重建序号ToolStripMenuItem"
        Me.自动重建序号ToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.自动重建序号ToolStripMenuItem.Text = "自动重建序号"
        '
        '重写BOM序号ToolStripMenuItem
        '
        Me.重写BOM序号ToolStripMenuItem.Name = "重写BOM序号ToolStripMenuItem"
        Me.重写BOM序号ToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.重写BOM序号ToolStripMenuItem.Text = "重写BOM序号"
        '
        '签字ToolStripMenuItem
        '
        Me.签字ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.签字ToolStripMenuItem1, Me.清除签字ToolStripMenuItem, Me.自定义签字ToolStripMenuItem})
        Me.签字ToolStripMenuItem.Name = "签字ToolStripMenuItem"
        Me.签字ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.签字ToolStripMenuItem.Text = "签字"
        '
        '签字ToolStripMenuItem1
        '
        Me.签字ToolStripMenuItem1.Name = "签字ToolStripMenuItem1"
        Me.签字ToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.签字ToolStripMenuItem1.Text = "签字"
        '
        '清除签字ToolStripMenuItem
        '
        Me.清除签字ToolStripMenuItem.Name = "清除签字ToolStripMenuItem"
        Me.清除签字ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.清除签字ToolStripMenuItem.Text = "清除签字"
        '
        '自定义签字ToolStripMenuItem
        '
        Me.自定义签字ToolStripMenuItem.Name = "自定义签字ToolStripMenuItem"
        Me.自定义签字ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.自定义签字ToolStripMenuItem.Text = "自定义签字"
        '
        '打印ToolStripMenuItem
        '
        Me.打印ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.快速打印ToolStripMenuItem, Me.批量打印ToolStripMenuItem})
        Me.打印ToolStripMenuItem.Name = "打印ToolStripMenuItem"
        Me.打印ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.打印ToolStripMenuItem.Text = "打印"
        '
        '快速打印ToolStripMenuItem
        '
        Me.快速打印ToolStripMenuItem.Name = "快速打印ToolStripMenuItem"
        Me.快速打印ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.快速打印ToolStripMenuItem.Text = "快速打印"
        '
        '批量打印ToolStripMenuItem
        '
        Me.批量打印ToolStripMenuItem.Name = "批量打印ToolStripMenuItem"
        Me.批量打印ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.批量打印ToolStripMenuItem.Text = "批量打印"
        '
        'ERPToolStripMenuItem
        '
        Me.ERPToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.查询ERP编码ToolStripMenuItem, Me.ERP反查ToolStripMenuItem, Me.ToolStripSeparator2, Me.导出BOM平面性ToolStripMenuItem, Me.导入ERPToolStripMenuItem, Me.导入ERP到BOMToolStripMenuItem, Me.打开数据文件ToolStripMenuItem})
        Me.ERPToolStripMenuItem.Name = "ERPToolStripMenuItem"
        Me.ERPToolStripMenuItem.Size = New System.Drawing.Size(42, 21)
        Me.ERPToolStripMenuItem.Text = "ERP"
        '
        '查询ERP编码ToolStripMenuItem
        '
        Me.查询ERP编码ToolStripMenuItem.Name = "查询ERP编码ToolStripMenuItem"
        Me.查询ERP编码ToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.查询ERP编码ToolStripMenuItem.Text = "查询ERP编码"
        '
        'ERP反查ToolStripMenuItem
        '
        Me.ERP反查ToolStripMenuItem.Name = "ERP反查ToolStripMenuItem"
        Me.ERP反查ToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.ERP反查ToolStripMenuItem.Text = "ERP反查"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(161, 6)
        '
        '导出BOM平面性ToolStripMenuItem
        '
        Me.导出BOM平面性ToolStripMenuItem.Name = "导出BOM平面性ToolStripMenuItem"
        Me.导出BOM平面性ToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.导出BOM平面性ToolStripMenuItem.Text = "导出BOM"
        '
        '导入ERPToolStripMenuItem
        '
        Me.导入ERPToolStripMenuItem.Name = "导入ERPToolStripMenuItem"
        Me.导入ERPToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.导入ERPToolStripMenuItem.Text = "导入ERP编码"
        '
        '导入ERP到BOMToolStripMenuItem
        '
        Me.导入ERP到BOMToolStripMenuItem.Name = "导入ERP到BOMToolStripMenuItem"
        Me.导入ERP到BOMToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.导入ERP到BOMToolStripMenuItem.Text = "导入ERP到BOM"
        '
        '打开数据文件ToolStripMenuItem
        '
        Me.打开数据文件ToolStripMenuItem.Name = "打开数据文件ToolStripMenuItem"
        Me.打开数据文件ToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.打开数据文件ToolStripMenuItem.Text = "打开数据文件"
        '
        '工具ToolStripMenuItem
        '
        Me.工具ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.设置ToolStripMenuItem, Me.工程图批量另存为ToolStripMenuItem, Me.还原旧图ToolStripMenuItem, Me.清理旧版文件ToolStripMenuItem, Me.量产iPropertyToolStripMenuItem, Me.刷新引用ToolStripMenuItem, Me.统计焊缝ToolStripMenuItem, Me.动画设计ToolStripMenuItem, Me.驱动测量ToolStripMenuItem})
        Me.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem"
        Me.工具ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.工具ToolStripMenuItem.Text = "工具"
        '
        '设置ToolStripMenuItem
        '
        Me.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem"
        Me.设置ToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.设置ToolStripMenuItem.Text = "设置"
        '
        '工程图批量另存为ToolStripMenuItem
        '
        Me.工程图批量另存为ToolStripMenuItem.Name = "工程图批量另存为ToolStripMenuItem"
        Me.工程图批量另存为ToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.工程图批量另存为ToolStripMenuItem.Text = "工程图批量另存为"
        '
        '还原旧图ToolStripMenuItem
        '
        Me.还原旧图ToolStripMenuItem.Name = "还原旧图ToolStripMenuItem"
        Me.还原旧图ToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.还原旧图ToolStripMenuItem.Text = "还原旧图"
        '
        '清理旧版文件ToolStripMenuItem
        '
        Me.清理旧版文件ToolStripMenuItem.Name = "清理旧版文件ToolStripMenuItem"
        Me.清理旧版文件ToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.清理旧版文件ToolStripMenuItem.Text = "清理旧版文件"
        '
        '量产iPropertyToolStripMenuItem
        '
        Me.量产iPropertyToolStripMenuItem.Name = "量产iPropertyToolStripMenuItem"
        Me.量产iPropertyToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.量产iPropertyToolStripMenuItem.Text = "量产iProperty"
        '
        '刷新引用ToolStripMenuItem
        '
        Me.刷新引用ToolStripMenuItem.Name = "刷新引用ToolStripMenuItem"
        Me.刷新引用ToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.刷新引用ToolStripMenuItem.Text = "刷新引用"
        '
        '统计焊缝ToolStripMenuItem
        '
        Me.统计焊缝ToolStripMenuItem.Name = "统计焊缝ToolStripMenuItem"
        Me.统计焊缝ToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.统计焊缝ToolStripMenuItem.Text = "统计"
        '
        '动画设计ToolStripMenuItem
        '
        Me.动画设计ToolStripMenuItem.Name = "动画设计ToolStripMenuItem"
        Me.动画设计ToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.动画设计ToolStripMenuItem.Text = "动画设计"
        '
        '驱动测量ToolStripMenuItem
        '
        Me.驱动测量ToolStripMenuItem.Name = "驱动测量ToolStripMenuItem"
        Me.驱动测量ToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.驱动测量ToolStripMenuItem.Text = "驱动测量"
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
        Me.Button1.Location = New System.Drawing.Point(329, 29)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(78, 39)
        Me.Button1.TabIndex = 18
        Me.Button1.TabStop = False
        Me.Button1.Text = "测试"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(422, 29)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(78, 39)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "测试二"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ButtoniProperty
        '
        Me.ButtoniProperty.Location = New System.Drawing.Point(267, 28)
        Me.ButtoniProperty.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtoniProperty.Name = "ButtoniProperty"
        Me.ButtoniProperty.Size = New System.Drawing.Size(56, 44)
        Me.ButtoniProperty.TabIndex = 21
        Me.ButtoniProperty.Text = "iProperty"
        Me.ButtoniProperty.UseVisualStyleBackColor = True
        '
        '保存为图片ToolStripMenuItem
        '
        Me.保存为图片ToolStripMenuItem.Name = "保存为图片ToolStripMenuItem"
        Me.保存为图片ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.保存为图片ToolStripMenuItem.Text = "保存为图片"
        '
        '按列表打开ToolStripMenuItem
        '
        Me.按列表打开ToolStripMenuItem.Name = "按列表打开ToolStripMenuItem"
        Me.按列表打开ToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.按列表打开ToolStripMenuItem.Text = "按列表打开"
        '
        'frmain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 118)
        Me.Controls.Add(Me.ButtoniProperty)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button更改镜像零件文件名)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Button获取文件名修改ipropty)
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button更改零件部件文件名 As System.Windows.Forms.Button
    Friend WithEvents Button获取文件名修改ipropty As System.Windows.Forms.Button
    Friend WithEvents Button获取部件修改ipropty As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Button更改镜像零件文件名 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents 文件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 保存关闭ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 关于ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 帮助ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 工具ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 设置ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 工程图ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 对称件IProToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 退出ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 零部件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 打开文件所在文件夹ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 设置虚拟件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents 替换图框ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents 查找缺失部件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 距离对齐ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 快速打开ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 提取iproperty更改文件名ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 随机颜色ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 设置随机颜色ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 清除颜色ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 技术要求ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ERPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 查询ERP编码ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ERP反查ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 工程图批量另存为ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 还原旧图ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 清理旧版文件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 导入ERP到BOMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 关闭ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 保存关闭所有文件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 打开工程图ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 全部可见ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 检查是否有工程图ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 生成图号ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 导出BOM平面性ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 导入ERPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 对齐原始坐标面ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 移动指定文件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ButtoniProperty As System.Windows.Forms.Button
    Friend WithEvents 打开数据文件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 序号ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 检查序号完整性ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 新建序号ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 自动重建序号ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 重写BOM序号ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 签字ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 签字ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 清除签字ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 自定义签字ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 打印ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 快速打印ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 批量打印ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 尺寸ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 添加直径ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 尺寸圆整ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 尺寸居中ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 全部居中ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 另存为PDFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 另存为DWGToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 打开指定工程图ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 另存为STPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 量产iPropertyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 批量替换文件名ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 刷新引用ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 设置只读ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 动画设计ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 标准件可见性ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 替换为库文件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 动态尺寸ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 创建展开图ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 查找替换ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 创建工程图ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 驱动测量ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 抑制错误约束ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 统计焊缝ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 保存为图片ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 按列表打开ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
