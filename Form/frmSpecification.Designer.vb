<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSpecification
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
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.GroupBox基础数据 = New System.Windows.Forms.GroupBox()
        Me.ToolStrip基础数据 = New System.Windows.Forms.ToolStrip()
        Me.配置文件ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.保存基础数据ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.添加基础数据ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.修改基础数据ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.删除基础数据ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.TreeView基础数据树 = New System.Windows.Forms.TreeView()
        Me.lst基础数据列表 = New System.Windows.Forms.ListBox()
        Me.GroupBox技术要求 = New System.Windows.Forms.GroupBox()
        Me.GroupBox导入自定义 = New System.Windows.Forms.GroupBox()
        Me.btn取消导入 = New System.Windows.Forms.Button()
        Me.btn确定导入 = New System.Windows.Forms.Button()
        Me.txt导入文本 = New System.Windows.Forms.TextBox()
        Me.ToolStrip自定义数据 = New System.Windows.Forms.ToolStrip()
        Me.新建自定义ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.保存自定义ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.导入ToolStripButton = New System.Windows.Forms.ToolStripSplitButton()
        Me.导入文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.导输入文本ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.添加自定义ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.插入自定义ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.修改自定义ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.删除自定义ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripSeparator()
        Me.编号ToolStripButton = New System.Windows.Forms.ToolStripSplitButton()
        Me.自动编号ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.去除编号ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.字体ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.间距ToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.上移ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.下移ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.TreeView自定义 = New System.Windows.Forms.TreeView()
        Me.lst技术要求文本 = New System.Windows.Forms.ListBox()
        Me.txt标题文本 = New System.Windows.Forms.TextBox()
        Me.btn插入 = New System.Windows.Forms.Button()
        Me.GroupBox基础数据.SuspendLayout
        Me.ToolStrip基础数据.SuspendLayout
        Me.GroupBox技术要求.SuspendLayout
        Me.GroupBox导入自定义.SuspendLayout
        Me.ToolStrip自定义数据.SuspendLayout
        Me.SuspendLayout
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(533, 491)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(75, 28)
        Me.btn关闭.TabIndex = 3
        Me.btn关闭.Text = "关闭"
        '
        'GroupBox基础数据
        '
        Me.GroupBox基础数据.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.GroupBox基础数据.Controls.Add(Me.ToolStrip基础数据)
        Me.GroupBox基础数据.Controls.Add(Me.TreeView基础数据树)
        Me.GroupBox基础数据.Controls.Add(Me.lst基础数据列表)
        Me.GroupBox基础数据.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox基础数据.Name = "GroupBox基础数据"
        Me.GroupBox基础数据.Size = New System.Drawing.Size(596, 204)
        Me.GroupBox基础数据.TabIndex = 0
        Me.GroupBox基础数据.TabStop = false
        Me.GroupBox基础数据.Text = "基础数据"
        '
        'ToolStrip基础数据
        '
        Me.ToolStrip基础数据.Font = New System.Drawing.Font("宋体", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134,Byte))
        Me.ToolStrip基础数据.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.配置文件ToolStripButton, Me.保存基础数据ToolStripButton, Me.ToolStripSeparator2, Me.添加基础数据ToolStripButton, Me.修改基础数据ToolStripButton, Me.删除基础数据ToolStripButton})
        Me.ToolStrip基础数据.Location = New System.Drawing.Point(3, 17)
        Me.ToolStrip基础数据.Name = "ToolStrip基础数据"
        Me.ToolStrip基础数据.Size = New System.Drawing.Size(590, 25)
        Me.ToolStrip基础数据.TabIndex = 0
        Me.ToolStrip基础数据.Text = "ToolStrip2"
        '
        '配置文件ToolStripButton
        '
        Me.配置文件ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.配置文件ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.配置文件ToolStripButton.Name = "配置文件ToolStripButton"
        Me.配置文件ToolStripButton.Size = New System.Drawing.Size(33, 22)
        Me.配置文件ToolStripButton.Text = "文件"
        Me.配置文件ToolStripButton.ToolTipText = "打开配置文件"
        '
        '保存基础数据ToolStripButton
        '
        Me.保存基础数据ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.保存基础数据ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.保存基础数据ToolStripButton.Name = "保存基础数据ToolStripButton"
        Me.保存基础数据ToolStripButton.Size = New System.Drawing.Size(33, 22)
        Me.保存基础数据ToolStripButton.Text = "保存"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        '添加基础数据ToolStripButton
        '
        Me.添加基础数据ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.添加基础数据ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.添加基础数据ToolStripButton.Name = "添加基础数据ToolStripButton"
        Me.添加基础数据ToolStripButton.Size = New System.Drawing.Size(33, 22)
        Me.添加基础数据ToolStripButton.Text = "添加"
        '
        '修改基础数据ToolStripButton
        '
        Me.修改基础数据ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.修改基础数据ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.修改基础数据ToolStripButton.Name = "修改基础数据ToolStripButton"
        Me.修改基础数据ToolStripButton.Size = New System.Drawing.Size(33, 22)
        Me.修改基础数据ToolStripButton.Text = "修改"
        '
        '删除基础数据ToolStripButton
        '
        Me.删除基础数据ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.删除基础数据ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.删除基础数据ToolStripButton.Name = "删除基础数据ToolStripButton"
        Me.删除基础数据ToolStripButton.Size = New System.Drawing.Size(33, 22)
        Me.删除基础数据ToolStripButton.Text = "删除"
        '
        'TreeView基础数据树
        '
        Me.TreeView基础数据树.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.TreeView基础数据树.Location = New System.Drawing.Point(13, 44)
        Me.TreeView基础数据树.Name = "TreeView基础数据树"
        Me.TreeView基础数据树.Size = New System.Drawing.Size(141, 151)
        Me.TreeView基础数据树.TabIndex = 1
        '
        'lst基础数据列表
        '
        Me.lst基础数据列表.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lst基础数据列表.FormattingEnabled = true
        Me.lst基础数据列表.HorizontalScrollbar = true
        Me.lst基础数据列表.ItemHeight = 12
        Me.lst基础数据列表.Location = New System.Drawing.Point(174, 45)
        Me.lst基础数据列表.Name = "lst基础数据列表"
        Me.lst基础数据列表.Size = New System.Drawing.Size(410, 148)
        Me.lst基础数据列表.TabIndex = 2
        '
        'GroupBox技术要求
        '
        Me.GroupBox技术要求.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.GroupBox技术要求.Controls.Add(Me.GroupBox导入自定义)
        Me.GroupBox技术要求.Controls.Add(Me.ToolStrip自定义数据)
        Me.GroupBox技术要求.Controls.Add(Me.TreeView自定义)
        Me.GroupBox技术要求.Controls.Add(Me.lst技术要求文本)
        Me.GroupBox技术要求.Controls.Add(Me.txt标题文本)
        Me.GroupBox技术要求.Location = New System.Drawing.Point(12, 237)
        Me.GroupBox技术要求.Name = "GroupBox技术要求"
        Me.GroupBox技术要求.Size = New System.Drawing.Size(596, 249)
        Me.GroupBox技术要求.TabIndex = 1
        Me.GroupBox技术要求.TabStop = false
        Me.GroupBox技术要求.Text = "技术要求"
        '
        'GroupBox导入自定义
        '
        Me.GroupBox导入自定义.Controls.Add(Me.btn取消导入)
        Me.GroupBox导入自定义.Controls.Add(Me.btn确定导入)
        Me.GroupBox导入自定义.Controls.Add(Me.txt导入文本)
        Me.GroupBox导入自定义.Location = New System.Drawing.Point(6, 45)
        Me.GroupBox导入自定义.Name = "GroupBox导入自定义"
        Me.GroupBox导入自定义.Size = New System.Drawing.Size(590, 198)
        Me.GroupBox导入自定义.TabIndex = 19
        Me.GroupBox导入自定义.TabStop = false
        Me.GroupBox导入自定义.Text = "导入"
        Me.GroupBox导入自定义.Visible = false
        '
        'btn取消导入
        '
        Me.btn取消导入.Location = New System.Drawing.Point(504, 159)
        Me.btn取消导入.Name = "btn取消导入"
        Me.btn取消导入.Size = New System.Drawing.Size(75, 28)
        Me.btn取消导入.TabIndex = 2
        Me.btn取消导入.Text = "取消"
        Me.btn取消导入.UseVisualStyleBackColor = true
        '
        'btn确定导入
        '
        Me.btn确定导入.Location = New System.Drawing.Point(423, 159)
        Me.btn确定导入.Name = "btn确定导入"
        Me.btn确定导入.Size = New System.Drawing.Size(75, 28)
        Me.btn确定导入.TabIndex = 1
        Me.btn确定导入.Text = "确定"
        Me.btn确定导入.UseVisualStyleBackColor = true
        '
        'txt导入文本
        '
        Me.txt导入文本.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txt导入文本.Location = New System.Drawing.Point(16, 18)
        Me.txt导入文本.Multiline = true
        Me.txt导入文本.Name = "txt导入文本"
        Me.txt导入文本.Size = New System.Drawing.Size(558, 125)
        Me.txt导入文本.TabIndex = 1
        '
        'ToolStrip自定义数据
        '
        Me.ToolStrip自定义数据.Font = New System.Drawing.Font("宋体", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134,Byte))
        Me.ToolStrip自定义数据.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.新建自定义ToolStripButton, Me.保存自定义ToolStripButton, Me.导入ToolStripButton, Me.ToolStripSeparator1, Me.添加自定义ToolStripButton, Me.插入自定义ToolStripButton, Me.修改自定义ToolStripButton, Me.删除自定义ToolStripButton, Me.ToolStripButton6, Me.编号ToolStripButton, Me.字体ToolStripButton, Me.间距ToolStripTextBox, Me.上移ToolStripButton, Me.下移ToolStripButton})
        Me.ToolStrip自定义数据.Location = New System.Drawing.Point(3, 17)
        Me.ToolStrip自定义数据.Name = "ToolStrip自定义数据"
        Me.ToolStrip自定义数据.Size = New System.Drawing.Size(590, 25)
        Me.ToolStrip自定义数据.TabIndex = 0
        Me.ToolStrip自定义数据.Text = "ToolStrip1"
        '
        '新建自定义ToolStripButton
        '
        Me.新建自定义ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.新建自定义ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.新建自定义ToolStripButton.Name = "新建自定义ToolStripButton"
        Me.新建自定义ToolStripButton.Size = New System.Drawing.Size(33, 22)
        Me.新建自定义ToolStripButton.Text = "新建"
        '
        '保存自定义ToolStripButton
        '
        Me.保存自定义ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.保存自定义ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.保存自定义ToolStripButton.Name = "保存自定义ToolStripButton"
        Me.保存自定义ToolStripButton.Size = New System.Drawing.Size(33, 22)
        Me.保存自定义ToolStripButton.Text = "保存"
        '
        '导入ToolStripButton
        '
        Me.导入ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.导入ToolStripButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.导入文件ToolStripMenuItem, Me.导输入文本ToolStripMenuItem})
        Me.导入ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.导入ToolStripButton.Name = "导入ToolStripButton"
        Me.导入ToolStripButton.Size = New System.Drawing.Size(45, 22)
        Me.导入ToolStripButton.Text = "导入"
        Me.导入ToolStripButton.ToolTipText = "从文本导入"
        '
        '导入文件ToolStripMenuItem
        '
        Me.导入文件ToolStripMenuItem.Name = "导入文件ToolStripMenuItem"
        Me.导入文件ToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.导入文件ToolStripMenuItem.Text = "导入文件"
        Me.导入文件ToolStripMenuItem.ToolTipText = "从文本文件导入，每行对应导入"
        '
        '导输入文本ToolStripMenuItem
        '
        Me.导输入文本ToolStripMenuItem.Name = "导输入文本ToolStripMenuItem"
        Me.导输入文本ToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.导输入文本ToolStripMenuItem.Text = "导入文本"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        '添加自定义ToolStripButton
        '
        Me.添加自定义ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.添加自定义ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.添加自定义ToolStripButton.Name = "添加自定义ToolStripButton"
        Me.添加自定义ToolStripButton.Size = New System.Drawing.Size(33, 22)
        Me.添加自定义ToolStripButton.Text = "添加"
        '
        '插入自定义ToolStripButton
        '
        Me.插入自定义ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.插入自定义ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.插入自定义ToolStripButton.Name = "插入自定义ToolStripButton"
        Me.插入自定义ToolStripButton.Size = New System.Drawing.Size(33, 22)
        Me.插入自定义ToolStripButton.Text = "插入"
        Me.插入自定义ToolStripButton.ToolTipText = "插入基础数据"
        '
        '修改自定义ToolStripButton
        '
        Me.修改自定义ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.修改自定义ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.修改自定义ToolStripButton.Name = "修改自定义ToolStripButton"
        Me.修改自定义ToolStripButton.Size = New System.Drawing.Size(33, 22)
        Me.修改自定义ToolStripButton.Text = "修改"
        '
        '删除自定义ToolStripButton
        '
        Me.删除自定义ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.删除自定义ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.删除自定义ToolStripButton.Name = "删除自定义ToolStripButton"
        Me.删除自定义ToolStripButton.Size = New System.Drawing.Size(33, 22)
        Me.删除自定义ToolStripButton.Text = "删除"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(6, 25)
        '
        '编号ToolStripButton
        '
        Me.编号ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.编号ToolStripButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.自动编号ToolStripMenuItem, Me.去除编号ToolStripMenuItem})
        Me.编号ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.编号ToolStripButton.Name = "编号ToolStripButton"
        Me.编号ToolStripButton.Size = New System.Drawing.Size(45, 22)
        Me.编号ToolStripButton.Text = "编号"
        '
        '自动编号ToolStripMenuItem
        '
        Me.自动编号ToolStripMenuItem.Name = "自动编号ToolStripMenuItem"
        Me.自动编号ToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.自动编号ToolStripMenuItem.Text = "自动编号"
        '
        '去除编号ToolStripMenuItem
        '
        Me.去除编号ToolStripMenuItem.Name = "去除编号ToolStripMenuItem"
        Me.去除编号ToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.去除编号ToolStripMenuItem.Text = "去除编号"
        '
        '字体ToolStripButton
        '
        Me.字体ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.字体ToolStripButton.Font = New System.Drawing.Font("仿宋", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134,Byte))
        Me.字体ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.字体ToolStripButton.Name = "字体ToolStripButton"
        Me.字体ToolStripButton.Size = New System.Drawing.Size(33, 22)
        Me.字体ToolStripButton.Text = "仿宋"
        '
        '间距ToolStripTextBox
        '
        Me.间距ToolStripTextBox.Name = "间距ToolStripTextBox"
        Me.间距ToolStripTextBox.Size = New System.Drawing.Size(30, 25)
        Me.间距ToolStripTextBox.Text = "1.5"
        Me.间距ToolStripTextBox.ToolTipText = "间距"
        '
        '上移ToolStripButton
        '
        Me.上移ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.上移ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.上移ToolStripButton.Name = "上移ToolStripButton"
        Me.上移ToolStripButton.Size = New System.Drawing.Size(33, 22)
        Me.上移ToolStripButton.Text = "上移"
        Me.上移ToolStripButton.ToolTipText = "选择行向上移动"
        '
        '下移ToolStripButton
        '
        Me.下移ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.下移ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.下移ToolStripButton.Name = "下移ToolStripButton"
        Me.下移ToolStripButton.Size = New System.Drawing.Size(33, 22)
        Me.下移ToolStripButton.Text = "下移"
        Me.下移ToolStripButton.ToolTipText = "选择行向下移动"
        '
        'TreeView自定义
        '
        Me.TreeView自定义.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.TreeView自定义.Location = New System.Drawing.Point(13, 45)
        Me.TreeView自定义.Name = "TreeView自定义"
        Me.TreeView自定义.Size = New System.Drawing.Size(141, 189)
        Me.TreeView自定义.TabIndex = 17
        '
        'lst技术要求文本
        '
        Me.lst技术要求文本.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lst技术要求文本.FormattingEnabled = true
        Me.lst技术要求文本.HorizontalScrollbar = true
        Me.lst技术要求文本.ItemHeight = 12
        Me.lst技术要求文本.Location = New System.Drawing.Point(174, 72)
        Me.lst技术要求文本.Name = "lst技术要求文本"
        Me.lst技术要求文本.Size = New System.Drawing.Size(410, 160)
        Me.lst技术要求文本.TabIndex = 1
        '
        'txt标题文本
        '
        Me.txt标题文本.Location = New System.Drawing.Point(174, 45)
        Me.txt标题文本.Name = "txt标题文本"
        Me.txt标题文本.Size = New System.Drawing.Size(97, 21)
        Me.txt标题文本.TabIndex = 11
        Me.txt标题文本.Text = "技术要求："
        '
        'btn插入
        '
        Me.btn插入.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btn插入.Location = New System.Drawing.Point(452, 492)
        Me.btn插入.Name = "btn插入"
        Me.btn插入.Size = New System.Drawing.Size(75, 28)
        Me.btn插入.TabIndex = 2
        Me.btn插入.Text = "插入"
        '
        'frmSpecification
        '
        Me.AcceptButton = Me.btn插入
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 12!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn关闭
        Me.ClientSize = New System.Drawing.Size(620, 531)
        Me.Controls.Add(Me.GroupBox技术要求)
        Me.Controls.Add(Me.GroupBox基础数据)
        Me.Controls.Add(Me.btn关闭)
        Me.Controls.Add(Me.btn插入)
        Me.MaximizeBox = false
        Me.Name = "frmSpecification"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "技术要求"
        Me.GroupBox基础数据.ResumeLayout(False)
        Me.GroupBox基础数据.PerformLayout
        Me.ToolStrip基础数据.ResumeLayout(false)
        Me.ToolStrip基础数据.PerformLayout
        Me.GroupBox技术要求.ResumeLayout(false)
        Me.GroupBox技术要求.PerformLayout
        Me.GroupBox导入自定义.ResumeLayout(false)
        Me.GroupBox导入自定义.PerformLayout
        Me.ToolStrip自定义数据.ResumeLayout(false)
        Me.ToolStrip自定义数据.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents GroupBox基础数据 As System.Windows.Forms.GroupBox
    Friend WithEvents lst基础数据列表 As System.Windows.Forms.ListBox
    Friend WithEvents TreeView基础数据树 As System.Windows.Forms.TreeView
    Friend WithEvents GroupBox技术要求 As System.Windows.Forms.GroupBox
    Friend WithEvents txt标题文本 As System.Windows.Forms.TextBox
    Friend WithEvents lst技术要求文本 As System.Windows.Forms.ListBox
    Friend WithEvents TreeView自定义 As System.Windows.Forms.TreeView
    Friend WithEvents ToolStrip自定义数据 As System.Windows.Forms.ToolStrip
    Friend WithEvents 新建自定义ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 保存自定义ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 添加自定义ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 插入自定义ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 修改自定义ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 删除自定义ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 字体ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn插入 As System.Windows.Forms.Button
    Friend WithEvents ToolStrip基础数据 As System.Windows.Forms.ToolStrip
    Friend WithEvents 保存基础数据ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 添加基础数据ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 修改基础数据ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 删除基础数据ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 编号ToolStripButton As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents 自动编号ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 去除编号ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 间距ToolStripTextBox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents 配置文件ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 上移ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 下移ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox导入自定义 As System.Windows.Forms.GroupBox
    Friend WithEvents txt导入文本 As System.Windows.Forms.TextBox
    Friend WithEvents 导入ToolStripButton As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents 导入文件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 导输入文本ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn取消导入 As System.Windows.Forms.Button
    Friend WithEvents btn确定导入 As System.Windows.Forms.Button

End Class
