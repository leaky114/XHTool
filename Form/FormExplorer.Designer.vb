Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormExplorer
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
    Friend WithEvents ImageList文件列表 As System.Windows.Forms.ImageList

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormExplorer))
        Me.ImageList文件列表 = New System.Windows.Forms.ImageList(Me.components)
        Me.Lvw文件列表 = New System.Windows.Forms.ListView()
        Me.文件名ColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.文件扩展名ColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.修改日期ColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.大小ColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.类型ColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Txt过滤栏 = New System.Windows.Forms.TextBox()
        Me.Cmb过滤 = New System.Windows.Forms.ComboBox()
        Me.Btn向上 = New System.Windows.Forms.Button()
        Me.项目文件夹ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.新建文件夹ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.打开ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.删除ToolStripDropDownButton = New System.Windows.Forms.ToolStripDropDownButton()
        Me.回收ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.永久删除ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.插入ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip资源管理器 = New System.Windows.Forms.ToolStrip()
        Me.当前文件夹ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.定位ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.旧版ToolStripDropDownButton = New System.Windows.Forms.ToolStripDropDownButton()
        Me.设置旧版ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.还原旧版ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cmb当前文件夹 = New System.Windows.Forms.ComboBox()
        Me.CMS文件列表 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.打开ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.插入到部件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.定位文件位置ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.复制ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.删除ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.属性ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Txt搜索栏 = New System.Windows.Forms.TextBox()
        Me.lbl搜索栏 = New System.Windows.Forms.Label()
        Me.lbl过滤栏 = New System.Windows.Forms.Label()
        Me.Btn过滤 = New System.Windows.Forms.Button()
        Me.Btn搜索 = New System.Windows.Forms.Button()
        Me.重命名ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip资源管理器.SuspendLayout()
        Me.CMS文件列表.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList文件列表
        '
        Me.ImageList文件列表.ImageStream = CType(resources.GetObject("ImageList文件列表.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList文件列表.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList文件列表.Images.SetKeyName(0, "Graph1")
        Me.ImageList文件列表.Images.SetKeyName(1, "Graph2")
        Me.ImageList文件列表.Images.SetKeyName(2, "Graph3")
        '
        'Lvw文件列表
        '
        Me.Lvw文件列表.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lvw文件列表.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.文件名ColumnHeader, Me.文件扩展名ColumnHeader, Me.修改日期ColumnHeader, Me.大小ColumnHeader, Me.类型ColumnHeader})
        Me.Lvw文件列表.FullRowSelect = True
        Me.Lvw文件列表.HideSelection = False
        Me.Lvw文件列表.Location = New System.Drawing.Point(12, 108)
        Me.Lvw文件列表.MultiSelect = False
        Me.Lvw文件列表.Name = "Lvw文件列表"
        Me.Lvw文件列表.Size = New System.Drawing.Size(708, 370)
        Me.Lvw文件列表.SmallImageList = Me.ImageList文件列表
        Me.Lvw文件列表.TabIndex = 0
        Me.Lvw文件列表.UseCompatibleStateImageBehavior = False
        Me.Lvw文件列表.View = System.Windows.Forms.View.Details
        '
        '文件名ColumnHeader
        '
        Me.文件名ColumnHeader.Text = "文件名"
        Me.文件名ColumnHeader.Width = 230
        '
        '文件扩展名ColumnHeader
        '
        Me.文件扩展名ColumnHeader.Text = "文件扩展名"
        Me.文件扩展名ColumnHeader.Width = 80
        '
        '修改日期ColumnHeader
        '
        Me.修改日期ColumnHeader.Text = "修改日期"
        Me.修改日期ColumnHeader.Width = 125
        '
        '大小ColumnHeader
        '
        Me.大小ColumnHeader.Text = "大小"
        Me.大小ColumnHeader.Width = 100
        '
        '类型ColumnHeader
        '
        Me.类型ColumnHeader.Text = "类型"
        '
        'Txt过滤栏
        '
        Me.Txt过滤栏.Location = New System.Drawing.Point(353, 74)
        Me.Txt过滤栏.Name = "Txt过滤栏"
        Me.Txt过滤栏.Size = New System.Drawing.Size(194, 21)
        Me.Txt过滤栏.TabIndex = 42
        '
        'Cmb过滤
        '
        Me.Cmb过滤.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmb过滤.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb过滤.Location = New System.Drawing.Point(597, 74)
        Me.Cmb过滤.Name = "Cmb过滤"
        Me.Cmb过滤.Size = New System.Drawing.Size(123, 20)
        Me.Cmb过滤.TabIndex = 43
        '
        'Btn向上
        '
        Me.Btn向上.Location = New System.Drawing.Point(8, 40)
        Me.Btn向上.Name = "Btn向上"
        Me.Btn向上.Size = New System.Drawing.Size(26, 26)
        Me.Btn向上.TabIndex = 44
        Me.Btn向上.UseVisualStyleBackColor = True
        '
        '项目文件夹ToolStripButton
        '
        Me.项目文件夹ToolStripButton.CheckOnClick = True
        Me.项目文件夹ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.项目文件夹ToolStripButton.Image = CType(resources.GetObject("项目文件夹ToolStripButton.Image"), System.Drawing.Image)
        Me.项目文件夹ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.项目文件夹ToolStripButton.Name = "项目文件夹ToolStripButton"
        Me.项目文件夹ToolStripButton.Size = New System.Drawing.Size(36, 36)
        Me.项目文件夹ToolStripButton.Text = "项目文件夹"
        Me.项目文件夹ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.项目文件夹ToolStripButton.ToolTipText = "转到项目文件夹。"
        '
        '新建文件夹ToolStripButton
        '
        Me.新建文件夹ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.新建文件夹ToolStripButton.Image = CType(resources.GetObject("新建文件夹ToolStripButton.Image"), System.Drawing.Image)
        Me.新建文件夹ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.新建文件夹ToolStripButton.Name = "新建文件夹ToolStripButton"
        Me.新建文件夹ToolStripButton.Size = New System.Drawing.Size(36, 36)
        Me.新建文件夹ToolStripButton.Text = "新建文件夹"
        Me.新建文件夹ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.新建文件夹ToolStripButton.ToolTipText = "新建文件夹。"
        '
        '打开ToolStripButton
        '
        Me.打开ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.打开ToolStripButton.Image = CType(resources.GetObject("打开ToolStripButton.Image"), System.Drawing.Image)
        Me.打开ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.打开ToolStripButton.Name = "打开ToolStripButton"
        Me.打开ToolStripButton.Size = New System.Drawing.Size(36, 36)
        Me.打开ToolStripButton.Text = "打开"
        Me.打开ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.打开ToolStripButton.ToolTipText = "打开所选项目。"
        '
        '删除ToolStripDropDownButton
        '
        Me.删除ToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.删除ToolStripDropDownButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.回收ToolStripMenuItem, Me.永久删除ToolStripMenuItem})
        Me.删除ToolStripDropDownButton.Image = CType(resources.GetObject("删除ToolStripDropDownButton.Image"), System.Drawing.Image)
        Me.删除ToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.删除ToolStripDropDownButton.Name = "删除ToolStripDropDownButton"
        Me.删除ToolStripDropDownButton.Size = New System.Drawing.Size(45, 36)
        Me.删除ToolStripDropDownButton.Text = "删除"
        Me.删除ToolStripDropDownButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        '回收ToolStripMenuItem
        '
        Me.回收ToolStripMenuItem.Name = "回收ToolStripMenuItem"
        Me.回收ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.回收ToolStripMenuItem.Text = "回收"
        Me.回收ToolStripMenuItem.ToolTipText = "将所选项目移动到回收站。"
        '
        '永久删除ToolStripMenuItem
        '
        Me.永久删除ToolStripMenuItem.Name = "永久删除ToolStripMenuItem"
        Me.永久删除ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.永久删除ToolStripMenuItem.Text = "永久删除"
        Me.永久删除ToolStripMenuItem.ToolTipText = "永久删除所选项目。"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        '插入ToolStripButton
        '
        Me.插入ToolStripButton.CheckOnClick = True
        Me.插入ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.插入ToolStripButton.Image = CType(resources.GetObject("插入ToolStripButton.Image"), System.Drawing.Image)
        Me.插入ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.插入ToolStripButton.Name = "插入ToolStripButton"
        Me.插入ToolStripButton.Size = New System.Drawing.Size(36, 36)
        Me.插入ToolStripButton.Text = "插入"
        Me.插入ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.插入ToolStripButton.ToolTipText = "插入所选项目到部件。"
        '
        'ToolStrip资源管理器
        '
        Me.ToolStrip资源管理器.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip资源管理器.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip资源管理器.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.项目文件夹ToolStripButton, Me.当前文件夹ToolStripButton, Me.定位ToolStripButton, Me.新建文件夹ToolStripButton, Me.ToolStripSeparator1, Me.打开ToolStripButton, Me.删除ToolStripDropDownButton, Me.ToolStripSeparator2, Me.插入ToolStripButton, Me.旧版ToolStripDropDownButton})
        Me.ToolStrip资源管理器.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip资源管理器.Name = "ToolStrip资源管理器"
        Me.ToolStrip资源管理器.Size = New System.Drawing.Size(732, 39)
        Me.ToolStrip资源管理器.TabIndex = 39
        Me.ToolStrip资源管理器.Text = "ToolStrip1"
        '
        '当前文件夹ToolStripButton
        '
        Me.当前文件夹ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.当前文件夹ToolStripButton.Image = CType(resources.GetObject("当前文件夹ToolStripButton.Image"), System.Drawing.Image)
        Me.当前文件夹ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.当前文件夹ToolStripButton.Name = "当前文件夹ToolStripButton"
        Me.当前文件夹ToolStripButton.Size = New System.Drawing.Size(36, 36)
        Me.当前文件夹ToolStripButton.Text = "当前文件夹"
        Me.当前文件夹ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.当前文件夹ToolStripButton.ToolTipText = "转到当前文件夹。"
        '
        '定位ToolStripButton
        '
        Me.定位ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.定位ToolStripButton.Image = CType(resources.GetObject("定位ToolStripButton.Image"), System.Drawing.Image)
        Me.定位ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.定位ToolStripButton.Name = "定位ToolStripButton"
        Me.定位ToolStripButton.Size = New System.Drawing.Size(36, 36)
        Me.定位ToolStripButton.Text = "定位"
        Me.定位ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.定位ToolStripButton.ToolTipText = "定位所选项目。"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        '旧版ToolStripDropDownButton
        '
        Me.旧版ToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.旧版ToolStripDropDownButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.设置旧版ToolStripMenuItem, Me.还原旧版ToolStripMenuItem})
        Me.旧版ToolStripDropDownButton.Image = CType(resources.GetObject("旧版ToolStripDropDownButton.Image"), System.Drawing.Image)
        Me.旧版ToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.旧版ToolStripDropDownButton.Name = "旧版ToolStripDropDownButton"
        Me.旧版ToolStripDropDownButton.Size = New System.Drawing.Size(45, 36)
        Me.旧版ToolStripDropDownButton.Text = "旧版"
        Me.旧版ToolStripDropDownButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        '设置旧版ToolStripMenuItem
        '
        Me.设置旧版ToolStripMenuItem.Name = "设置旧版ToolStripMenuItem"
        Me.设置旧版ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.设置旧版ToolStripMenuItem.Text = "设置旧版"
        Me.设置旧版ToolStripMenuItem.ToolTipText = "设置所选项目为旧版。"
        '
        '还原旧版ToolStripMenuItem
        '
        Me.还原旧版ToolStripMenuItem.Name = "还原旧版ToolStripMenuItem"
        Me.还原旧版ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.还原旧版ToolStripMenuItem.Text = "还原旧版"
        Me.还原旧版ToolStripMenuItem.ToolTipText = "还原所选旧版为正常文件。"
        '
        'Cmb当前文件夹
        '
        Me.Cmb当前文件夹.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmb当前文件夹.Location = New System.Drawing.Point(40, 43)
        Me.Cmb当前文件夹.Name = "Cmb当前文件夹"
        Me.Cmb当前文件夹.Size = New System.Drawing.Size(680, 20)
        Me.Cmb当前文件夹.TabIndex = 45
        '
        'CMS文件列表
        '
        Me.CMS文件列表.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.打开ToolStripMenuItem, Me.插入到部件ToolStripMenuItem, Me.定位文件位置ToolStripMenuItem, Me.ToolStripSeparator3, Me.重命名ToolStripMenuItem, Me.复制ToolStripMenuItem, Me.删除ToolStripMenuItem, Me.ToolStripSeparator4, Me.属性ToolStripMenuItem})
        Me.CMS文件列表.Name = "CMS文件列表"
        Me.CMS文件列表.Size = New System.Drawing.Size(181, 192)
        '
        '打开ToolStripMenuItem
        '
        Me.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem"
        Me.打开ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.打开ToolStripMenuItem.Text = "打开"
        '
        '插入到部件ToolStripMenuItem
        '
        Me.插入到部件ToolStripMenuItem.Name = "插入到部件ToolStripMenuItem"
        Me.插入到部件ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.插入到部件ToolStripMenuItem.Text = "插入到部件"
        '
        '定位文件位置ToolStripMenuItem
        '
        Me.定位文件位置ToolStripMenuItem.Name = "定位文件位置ToolStripMenuItem"
        Me.定位文件位置ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.定位文件位置ToolStripMenuItem.Text = "定位文件位置"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(177, 6)
        '
        '复制ToolStripMenuItem
        '
        Me.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem"
        Me.复制ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.复制ToolStripMenuItem.Text = "复制"
        '
        '删除ToolStripMenuItem
        '
        Me.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem"
        Me.删除ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.删除ToolStripMenuItem.Text = "删除"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(177, 6)
        '
        '属性ToolStripMenuItem
        '
        Me.属性ToolStripMenuItem.Name = "属性ToolStripMenuItem"
        Me.属性ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.属性ToolStripMenuItem.Text = "属性"
        '
        'Txt搜索栏
        '
        Me.Txt搜索栏.Location = New System.Drawing.Point(59, 74)
        Me.Txt搜索栏.Name = "Txt搜索栏"
        Me.Txt搜索栏.Size = New System.Drawing.Size(194, 21)
        Me.Txt搜索栏.TabIndex = 46
        '
        'lbl搜索栏
        '
        Me.lbl搜索栏.AutoSize = True
        Me.lbl搜索栏.Location = New System.Drawing.Point(12, 78)
        Me.lbl搜索栏.Name = "lbl搜索栏"
        Me.lbl搜索栏.Size = New System.Drawing.Size(41, 12)
        Me.lbl搜索栏.TabIndex = 47
        Me.lbl搜索栏.Text = "搜索栏"
        '
        'lbl过滤栏
        '
        Me.lbl过滤栏.AutoSize = True
        Me.lbl过滤栏.Location = New System.Drawing.Point(305, 78)
        Me.lbl过滤栏.Name = "lbl过滤栏"
        Me.lbl过滤栏.Size = New System.Drawing.Size(41, 12)
        Me.lbl过滤栏.TabIndex = 48
        Me.lbl过滤栏.Text = "过滤栏"
        '
        'Btn过滤
        '
        Me.Btn过滤.Location = New System.Drawing.Point(552, 71)
        Me.Btn过滤.Name = "Btn过滤"
        Me.Btn过滤.Size = New System.Drawing.Size(26, 26)
        Me.Btn过滤.TabIndex = 49
        Me.Btn过滤.UseVisualStyleBackColor = True
        '
        'Btn搜索
        '
        Me.Btn搜索.Location = New System.Drawing.Point(262, 71)
        Me.Btn搜索.Name = "Btn搜索"
        Me.Btn搜索.Size = New System.Drawing.Size(26, 26)
        Me.Btn搜索.TabIndex = 50
        Me.Btn搜索.UseVisualStyleBackColor = True
        '
        '重命名ToolStripMenuItem
        '
        Me.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem"
        Me.重命名ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.重命名ToolStripMenuItem.Text = "重命名"
        '
        'FormExplorer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 490)
        Me.Controls.Add(Me.Btn搜索)
        Me.Controls.Add(Me.Btn过滤)
        Me.Controls.Add(Me.lbl过滤栏)
        Me.Controls.Add(Me.lbl搜索栏)
        Me.Controls.Add(Me.Txt搜索栏)
        Me.Controls.Add(Me.Cmb当前文件夹)
        Me.Controls.Add(Me.Btn向上)
        Me.Controls.Add(Me.Cmb过滤)
        Me.Controls.Add(Me.Txt过滤栏)
        Me.Controls.Add(Me.ToolStrip资源管理器)
        Me.Controls.Add(Me.Lvw文件列表)
        Me.Name = "FormExplorer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "资源管理器"
        Me.ToolStrip资源管理器.ResumeLayout(False)
        Me.ToolStrip资源管理器.PerformLayout()
        Me.CMS文件列表.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Lvw文件列表 As Windows.Forms.ListView
    Friend WithEvents 文件名ColumnHeader As Windows.Forms.ColumnHeader
    Friend WithEvents 修改日期ColumnHeader As Windows.Forms.ColumnHeader
    Friend WithEvents 大小ColumnHeader As Windows.Forms.ColumnHeader
    Friend WithEvents Txt过滤栏 As Windows.Forms.TextBox
    Friend WithEvents Cmb过滤 As Windows.Forms.ComboBox
    Friend WithEvents 文件扩展名ColumnHeader As Windows.Forms.ColumnHeader
    Friend WithEvents Btn向上 As Windows.Forms.Button
    Friend WithEvents 类型ColumnHeader As Windows.Forms.ColumnHeader
    Friend WithEvents 项目文件夹ToolStripButton As Windows.Forms.ToolStripButton
    Friend WithEvents 新建文件夹ToolStripButton As Windows.Forms.ToolStripButton
    Friend WithEvents 打开ToolStripButton As Windows.Forms.ToolStripButton
    Friend WithEvents 删除ToolStripDropDownButton As Windows.Forms.ToolStripDropDownButton
    Friend WithEvents 回收ToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents 永久删除ToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents 插入ToolStripButton As Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip资源管理器 As Windows.Forms.ToolStrip
    Friend WithEvents Cmb当前文件夹 As Windows.Forms.ComboBox
    Friend WithEvents 当前文件夹ToolStripButton As Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As Windows.Forms.ToolStripSeparator
    Friend WithEvents 旧版ToolStripDropDownButton As ToolStripDropDownButton
    Friend WithEvents 设置旧版ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 还原旧版ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CMS文件列表 As ContextMenuStrip
    Friend WithEvents 打开ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 插入到部件ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 定位文件位置ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents 复制ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 删除ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents 属性ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 定位ToolStripButton As ToolStripButton
    Friend WithEvents Txt搜索栏 As TextBox
    Friend WithEvents lbl搜索栏 As Label
    Friend WithEvents lbl过滤栏 As Label
    Friend WithEvents Btn过滤 As Button
    Friend WithEvents Btn搜索 As Button
    Friend WithEvents 重命名ToolStripMenuItem As ToolStripMenuItem
End Class
