<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCExplorer
    Inherits System.Windows.Forms.UserControl

    'UserControl 重写释放以清理组件列表。
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCExplorer))
        Me.ToolStrip资源管理器 = New System.Windows.Forms.ToolStrip()
        Me.项目文件夹ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.当前文件夹ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.浏览文件ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.Pic缩略图 = New System.Windows.Forms.PictureBox()
        Me.Lvw文件列表 = New System.Windows.Forms.ListView()
        Me.文件名ColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.文件扩展名ColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.修改日期ColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.大小ColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.类型ColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList文件列表 = New System.Windows.Forms.ImageList(Me.components)
        Me.Btn向上 = New System.Windows.Forms.Button()
        Me.CMS文件列表 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.打开ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.插入到部件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.浏览文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.复制文件名ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.重命名ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.复制ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.删除ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.刷新ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.属性ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cmb过滤 = New System.Windows.Forms.ComboBox()
        Me.txt当前文件夹 = New System.Windows.Forms.TextBox()
        Me.ToolStrip资源管理器.SuspendLayout()
        CType(Me.Pic缩略图, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS文件列表.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip资源管理器
        '
        Me.ToolStrip资源管理器.AutoSize = False
        Me.ToolStrip资源管理器.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip资源管理器.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.项目文件夹ToolStripButton, Me.当前文件夹ToolStripButton, Me.浏览文件ToolStripButton})
        Me.ToolStrip资源管理器.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip资源管理器.Name = "ToolStrip资源管理器"
        Me.ToolStrip资源管理器.Size = New System.Drawing.Size(230, 39)
        Me.ToolStrip资源管理器.TabIndex = 40
        Me.ToolStrip资源管理器.Text = "ToolStrip1"
        '
        '项目文件夹ToolStripButton
        '
        Me.项目文件夹ToolStripButton.CheckOnClick = True
        Me.项目文件夹ToolStripButton.Image = CType(resources.GetObject("项目文件夹ToolStripButton.Image"), System.Drawing.Image)
        Me.项目文件夹ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.项目文件夹ToolStripButton.Name = "项目文件夹ToolStripButton"
        Me.项目文件夹ToolStripButton.Size = New System.Drawing.Size(72, 36)
        Me.项目文件夹ToolStripButton.Text = "项目文件夹"
        Me.项目文件夹ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.项目文件夹ToolStripButton.ToolTipText = "转到项目文件夹。"
        '
        '当前文件夹ToolStripButton
        '
        Me.当前文件夹ToolStripButton.Image = CType(resources.GetObject("当前文件夹ToolStripButton.Image"), System.Drawing.Image)
        Me.当前文件夹ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.当前文件夹ToolStripButton.Name = "当前文件夹ToolStripButton"
        Me.当前文件夹ToolStripButton.Size = New System.Drawing.Size(72, 36)
        Me.当前文件夹ToolStripButton.Text = "当前文件夹"
        Me.当前文件夹ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.当前文件夹ToolStripButton.ToolTipText = "转到当前文件夹。"
        '
        '浏览文件ToolStripButton
        '
        Me.浏览文件ToolStripButton.Image = CType(resources.GetObject("浏览文件ToolStripButton.Image"), System.Drawing.Image)
        Me.浏览文件ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.浏览文件ToolStripButton.Name = "浏览文件ToolStripButton"
        Me.浏览文件ToolStripButton.Size = New System.Drawing.Size(60, 36)
        Me.浏览文件ToolStripButton.Text = "浏览文件"
        Me.浏览文件ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.浏览文件ToolStripButton.ToolTipText = "浏览文件所在文件夹。"
        Me.浏览文件ToolStripButton.Visible = False
        '
        'Pic缩略图
        '
        Me.Pic缩略图.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pic缩略图.Location = New System.Drawing.Point(7, 394)
        Me.Pic缩略图.Name = "Pic缩略图"
        Me.Pic缩略图.Size = New System.Drawing.Size(213, 159)
        Me.Pic缩略图.TabIndex = 42
        Me.Pic缩略图.TabStop = False
        '
        'Lvw文件列表
        '
        Me.Lvw文件列表.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lvw文件列表.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.文件名ColumnHeader, Me.文件扩展名ColumnHeader, Me.修改日期ColumnHeader, Me.大小ColumnHeader, Me.类型ColumnHeader})
        Me.Lvw文件列表.FullRowSelect = True
        Me.Lvw文件列表.HideSelection = False
        Me.Lvw文件列表.Location = New System.Drawing.Point(6, 104)
        Me.Lvw文件列表.MultiSelect = False
        Me.Lvw文件列表.Name = "Lvw文件列表"
        Me.Lvw文件列表.Size = New System.Drawing.Size(213, 284)
        Me.Lvw文件列表.SmallImageList = Me.ImageList文件列表
        Me.Lvw文件列表.TabIndex = 43
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
        'ImageList文件列表
        '
        Me.ImageList文件列表.ImageStream = CType(resources.GetObject("ImageList文件列表.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList文件列表.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList文件列表.Images.SetKeyName(0, "Graph1")
        Me.ImageList文件列表.Images.SetKeyName(1, "Graph2")
        Me.ImageList文件列表.Images.SetKeyName(2, "Graph3")
        '
        'Btn向上
        '
        Me.Btn向上.Location = New System.Drawing.Point(6, 49)
        Me.Btn向上.Name = "Btn向上"
        Me.Btn向上.Size = New System.Drawing.Size(26, 26)
        Me.Btn向上.TabIndex = 46
        Me.Btn向上.UseVisualStyleBackColor = True
        '
        'CMS文件列表
        '
        Me.CMS文件列表.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.打开ToolStripMenuItem, Me.插入到部件ToolStripMenuItem, Me.浏览文件ToolStripMenuItem, Me.复制文件名ToolStripMenuItem, Me.ToolStripSeparator3, Me.重命名ToolStripMenuItem, Me.复制ToolStripMenuItem, Me.删除ToolStripMenuItem, Me.ToolStripSeparator4, Me.刷新ToolStripMenuItem, Me.属性ToolStripMenuItem})
        Me.CMS文件列表.Name = "CMS文件列表"
        Me.CMS文件列表.Size = New System.Drawing.Size(137, 214)
        '
        '打开ToolStripMenuItem
        '
        Me.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem"
        Me.打开ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.打开ToolStripMenuItem.Text = "打开"
        '
        '插入到部件ToolStripMenuItem
        '
        Me.插入到部件ToolStripMenuItem.Name = "插入到部件ToolStripMenuItem"
        Me.插入到部件ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.插入到部件ToolStripMenuItem.Text = "插入到部件"
        '
        '浏览文件ToolStripMenuItem
        '
        Me.浏览文件ToolStripMenuItem.Name = "浏览文件ToolStripMenuItem"
        Me.浏览文件ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.浏览文件ToolStripMenuItem.Text = "浏览文件"
        '
        '复制文件名ToolStripMenuItem
        '
        Me.复制文件名ToolStripMenuItem.Name = "复制文件名ToolStripMenuItem"
        Me.复制文件名ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.复制文件名ToolStripMenuItem.Text = "复制文件名"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(133, 6)
        '
        '重命名ToolStripMenuItem
        '
        Me.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem"
        Me.重命名ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.重命名ToolStripMenuItem.Text = "重命名"
        '
        '复制ToolStripMenuItem
        '
        Me.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem"
        Me.复制ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.复制ToolStripMenuItem.Text = "复制"
        '
        '删除ToolStripMenuItem
        '
        Me.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem"
        Me.删除ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.删除ToolStripMenuItem.Text = "删除"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(133, 6)
        '
        '刷新ToolStripMenuItem
        '
        Me.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem"
        Me.刷新ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.刷新ToolStripMenuItem.Text = "刷新"
        '
        '属性ToolStripMenuItem
        '
        Me.属性ToolStripMenuItem.Name = "属性ToolStripMenuItem"
        Me.属性ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.属性ToolStripMenuItem.Text = "属性"
        '
        'Cmb过滤
        '
        Me.Cmb过滤.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmb过滤.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb过滤.Location = New System.Drawing.Point(145, 12)
        Me.Cmb过滤.Name = "Cmb过滤"
        Me.Cmb过滤.Size = New System.Drawing.Size(74, 20)
        Me.Cmb过滤.TabIndex = 49
        '
        'txt当前文件夹
        '
        Me.txt当前文件夹.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt当前文件夹.Location = New System.Drawing.Point(38, 49)
        Me.txt当前文件夹.Multiline = True
        Me.txt当前文件夹.Name = "txt当前文件夹"
        Me.txt当前文件夹.ReadOnly = True
        Me.txt当前文件夹.Size = New System.Drawing.Size(181, 49)
        Me.txt当前文件夹.TabIndex = 50
        Me.txt当前文件夹.TabStop = False
        '
        'UCExplorer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txt当前文件夹)
        Me.Controls.Add(Me.Cmb过滤)
        Me.Controls.Add(Me.Btn向上)
        Me.Controls.Add(Me.Lvw文件列表)
        Me.Controls.Add(Me.Pic缩略图)
        Me.Controls.Add(Me.ToolStrip资源管理器)
        Me.Name = "UCExplorer"
        Me.Size = New System.Drawing.Size(230, 566)
        Me.ToolStrip资源管理器.ResumeLayout(False)
        Me.ToolStrip资源管理器.PerformLayout()
        CType(Me.Pic缩略图, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS文件列表.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip资源管理器 As Windows.Forms.ToolStrip
    Friend WithEvents 项目文件夹ToolStripButton As Windows.Forms.ToolStripButton
    Friend WithEvents 当前文件夹ToolStripButton As Windows.Forms.ToolStripButton
    Friend WithEvents 浏览文件ToolStripButton As Windows.Forms.ToolStripButton
    Friend WithEvents Pic缩略图 As Windows.Forms.PictureBox
    Friend WithEvents Lvw文件列表 As Windows.Forms.ListView
    Friend WithEvents 文件名ColumnHeader As Windows.Forms.ColumnHeader
    Friend WithEvents 文件扩展名ColumnHeader As Windows.Forms.ColumnHeader
    Friend WithEvents 修改日期ColumnHeader As Windows.Forms.ColumnHeader
    Friend WithEvents 大小ColumnHeader As Windows.Forms.ColumnHeader
    Friend WithEvents 类型ColumnHeader As Windows.Forms.ColumnHeader
    Friend WithEvents Btn向上 As Windows.Forms.Button
    Friend WithEvents ImageList文件列表 As Windows.Forms.ImageList
    Friend WithEvents CMS文件列表 As Windows.Forms.ContextMenuStrip
    Friend WithEvents 打开ToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents 插入到部件ToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents 浏览文件ToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents 复制文件名ToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As Windows.Forms.ToolStripSeparator
    Friend WithEvents 重命名ToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents 复制ToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents 删除ToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As Windows.Forms.ToolStripSeparator
    Friend WithEvents 刷新ToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents 属性ToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmb过滤 As Windows.Forms.ComboBox
    Friend WithEvents txt当前文件夹 As Windows.Forms.TextBox
End Class
