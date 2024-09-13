<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFormatConversion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFormatConversion))
        Me.btn转换 = New System.Windows.Forms.Button()
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.Lvw文件列表 = New System.Windows.Forms.ListView()
        Me.ColumnHeader文件名 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cms右键菜单 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmi移出 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi清空 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip文档格式 = New System.Windows.Forms.ToolStrip()
        Me.文档格式ToolStripButton = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripSeparator()
        Me.工程图ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.零部件ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.移出文件ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.清空列表ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.静默转换ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.转换后关闭ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.加载方式ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.加载方式ToolStripButton = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.添加文件ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.添加文件夹ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.从部件导入ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.导入当前部件ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.导入已打开的文件ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.转换格式ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.转换格式ToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DWGToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.DXFToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PDFToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.JPGToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.STPToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.XTToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.目录设置ToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.格式分类ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.指定文件夹ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.浏览ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.指定文件夹ToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.cms右键菜单.SuspendLayout()
        Me.ToolStrip文档格式.SuspendLayout()
        Me.加载方式ToolStrip.SuspendLayout()
        Me.转换格式ToolStrip.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn转换
        '
        Me.btn转换.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn转换.Location = New System.Drawing.Point(660, 471)
        Me.btn转换.Name = "btn转换"
        Me.btn转换.Size = New System.Drawing.Size(57, 28)
        Me.btn转换.TabIndex = 10
        Me.btn转换.Text = "转换"
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(731, 471)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(57, 28)
        Me.btn关闭.TabIndex = 11
        Me.btn关闭.Text = "关闭"
        '
        'Lvw文件列表
        '
        Me.Lvw文件列表.AllowColumnReorder = True
        Me.Lvw文件列表.AllowDrop = True
        Me.Lvw文件列表.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lvw文件列表.AutoArrange = False
        Me.Lvw文件列表.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader文件名})
        Me.Lvw文件列表.ContextMenuStrip = Me.cms右键菜单
        Me.Lvw文件列表.FullRowSelect = True
        Me.Lvw文件列表.Location = New System.Drawing.Point(12, 163)
        Me.Lvw文件列表.Name = "Lvw文件列表"
        Me.Lvw文件列表.Size = New System.Drawing.Size(776, 300)
        Me.Lvw文件列表.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.Lvw文件列表.TabIndex = 37
        Me.Lvw文件列表.UseCompatibleStateImageBehavior = False
        Me.Lvw文件列表.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader文件名
        '
        Me.ColumnHeader文件名.Text = "文件名"
        Me.ColumnHeader文件名.Width = 753
        '
        'cms右键菜单
        '
        Me.cms右键菜单.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi移出, Me.tsmi清空})
        Me.cms右键菜单.Name = "cmsRemove"
        Me.cms右键菜单.Size = New System.Drawing.Size(101, 48)
        '
        'tsmi移出
        '
        Me.tsmi移出.Name = "tsmi移出"
        Me.tsmi移出.Size = New System.Drawing.Size(100, 22)
        Me.tsmi移出.Text = "移出"
        '
        'tsmi清空
        '
        Me.tsmi清空.Name = "tsmi清空"
        Me.tsmi清空.Size = New System.Drawing.Size(100, 22)
        Me.tsmi清空.Text = "清空"
        '
        'ToolStrip文档格式
        '
        Me.ToolStrip文档格式.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip文档格式.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.文档格式ToolStripButton, Me.ToolStripButton1, Me.工程图ToolStripButton, Me.零部件ToolStripButton, Me.ToolStripSeparator5, Me.移出文件ToolStripButton, Me.清空列表ToolStripButton, Me.静默转换ToolStripButton, Me.转换后关闭ToolStripButton})
        Me.ToolStrip文档格式.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip文档格式.Name = "ToolStrip文档格式"
        Me.ToolStrip文档格式.Size = New System.Drawing.Size(800, 40)
        Me.ToolStrip文档格式.TabIndex = 38
        Me.ToolStrip文档格式.Text = "ToolStrip1"
        '
        '文档格式ToolStripButton
        '
        Me.文档格式ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.文档格式ToolStripButton.Image = CType(resources.GetObject("文档格式ToolStripButton.Image"), System.Drawing.Image)
        Me.文档格式ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.文档格式ToolStripButton.Name = "文档格式ToolStripButton"
        Me.文档格式ToolStripButton.Size = New System.Drawing.Size(56, 37)
        Me.文档格式ToolStripButton.Text = "文档格式"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(6, 40)
        '
        '工程图ToolStripButton
        '
        Me.工程图ToolStripButton.CheckOnClick = True
        Me.工程图ToolStripButton.Image = CType(resources.GetObject("工程图ToolStripButton.Image"), System.Drawing.Image)
        Me.工程图ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.工程图ToolStripButton.Name = "工程图ToolStripButton"
        Me.工程图ToolStripButton.Size = New System.Drawing.Size(48, 37)
        Me.工程图ToolStripButton.Text = "工程图"
        Me.工程图ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        '零部件ToolStripButton
        '
        Me.零部件ToolStripButton.CheckOnClick = True
        Me.零部件ToolStripButton.Image = CType(resources.GetObject("零部件ToolStripButton.Image"), System.Drawing.Image)
        Me.零部件ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.零部件ToolStripButton.Name = "零部件ToolStripButton"
        Me.零部件ToolStripButton.Size = New System.Drawing.Size(48, 37)
        Me.零部件ToolStripButton.Text = "零部件"
        Me.零部件ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 40)
        '
        '移出文件ToolStripButton
        '
        Me.移出文件ToolStripButton.Image = CType(resources.GetObject("移出文件ToolStripButton.Image"), System.Drawing.Image)
        Me.移出文件ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.移出文件ToolStripButton.Name = "移出文件ToolStripButton"
        Me.移出文件ToolStripButton.Size = New System.Drawing.Size(60, 37)
        Me.移出文件ToolStripButton.Text = "移出文件"
        Me.移出文件ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.移出文件ToolStripButton.ToolTipText = "移出选择的文件"
        '
        '清空列表ToolStripButton
        '
        Me.清空列表ToolStripButton.Image = CType(resources.GetObject("清空列表ToolStripButton.Image"), System.Drawing.Image)
        Me.清空列表ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.清空列表ToolStripButton.Name = "清空列表ToolStripButton"
        Me.清空列表ToolStripButton.Size = New System.Drawing.Size(60, 37)
        Me.清空列表ToolStripButton.Text = "清空列表"
        Me.清空列表ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        '静默转换ToolStripButton
        '
        Me.静默转换ToolStripButton.CheckOnClick = True
        Me.静默转换ToolStripButton.Image = CType(resources.GetObject("静默转换ToolStripButton.Image"), System.Drawing.Image)
        Me.静默转换ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.静默转换ToolStripButton.Name = "静默转换ToolStripButton"
        Me.静默转换ToolStripButton.Size = New System.Drawing.Size(60, 37)
        Me.静默转换ToolStripButton.Text = "静默转换"
        Me.静默转换ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.静默转换ToolStripButton.ToolTipText = "打开但不显示文档"
        '
        '转换后关闭ToolStripButton
        '
        Me.转换后关闭ToolStripButton.CheckOnClick = True
        Me.转换后关闭ToolStripButton.Image = CType(resources.GetObject("转换后关闭ToolStripButton.Image"), System.Drawing.Image)
        Me.转换后关闭ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.转换后关闭ToolStripButton.Name = "转换后关闭ToolStripButton"
        Me.转换后关闭ToolStripButton.Size = New System.Drawing.Size(72, 37)
        Me.转换后关闭ToolStripButton.Text = "转换后关闭"
        Me.转换后关闭ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.转换后关闭ToolStripButton.ToolTipText = "转换后关闭文件"
        '
        '加载方式ToolStrip
        '
        Me.加载方式ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.加载方式ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.加载方式ToolStripButton, Me.ToolStripSeparator1, Me.添加文件ToolStripButton, Me.添加文件夹ToolStripButton, Me.从部件导入ToolStripButton, Me.导入当前部件ToolStripButton, Me.导入已打开的文件ToolStripButton})
        Me.加载方式ToolStrip.Location = New System.Drawing.Point(0, 40)
        Me.加载方式ToolStrip.Name = "加载方式ToolStrip"
        Me.加载方式ToolStrip.Size = New System.Drawing.Size(800, 40)
        Me.加载方式ToolStrip.TabIndex = 39
        Me.加载方式ToolStrip.Text = "加载方式"
        '
        '加载方式ToolStripButton
        '
        Me.加载方式ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.加载方式ToolStripButton.Image = CType(resources.GetObject("加载方式ToolStripButton.Image"), System.Drawing.Image)
        Me.加载方式ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.加载方式ToolStripButton.Name = "加载方式ToolStripButton"
        Me.加载方式ToolStripButton.Size = New System.Drawing.Size(56, 37)
        Me.加载方式ToolStripButton.Text = "加载方式"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        '添加文件ToolStripButton
        '
        Me.添加文件ToolStripButton.Enabled = False
        Me.添加文件ToolStripButton.Image = CType(resources.GetObject("添加文件ToolStripButton.Image"), System.Drawing.Image)
        Me.添加文件ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.添加文件ToolStripButton.Name = "添加文件ToolStripButton"
        Me.添加文件ToolStripButton.Size = New System.Drawing.Size(60, 37)
        Me.添加文件ToolStripButton.Text = "添加文件"
        Me.添加文件ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        '添加文件夹ToolStripButton
        '
        Me.添加文件夹ToolStripButton.Enabled = False
        Me.添加文件夹ToolStripButton.Image = CType(resources.GetObject("添加文件夹ToolStripButton.Image"), System.Drawing.Image)
        Me.添加文件夹ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.添加文件夹ToolStripButton.Name = "添加文件夹ToolStripButton"
        Me.添加文件夹ToolStripButton.Size = New System.Drawing.Size(72, 37)
        Me.添加文件夹ToolStripButton.Text = "添加文件夹"
        Me.添加文件夹ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        '从部件导入ToolStripButton
        '
        Me.从部件导入ToolStripButton.Enabled = False
        Me.从部件导入ToolStripButton.Image = CType(resources.GetObject("从部件导入ToolStripButton.Image"), System.Drawing.Image)
        Me.从部件导入ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.从部件导入ToolStripButton.Name = "从部件导入ToolStripButton"
        Me.从部件导入ToolStripButton.Size = New System.Drawing.Size(72, 37)
        Me.从部件导入ToolStripButton.Text = "从部件导入"
        Me.从部件导入ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        '导入当前部件ToolStripButton
        '
        Me.导入当前部件ToolStripButton.Enabled = False
        Me.导入当前部件ToolStripButton.Image = CType(resources.GetObject("导入当前部件ToolStripButton.Image"), System.Drawing.Image)
        Me.导入当前部件ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.导入当前部件ToolStripButton.Name = "导入当前部件ToolStripButton"
        Me.导入当前部件ToolStripButton.Size = New System.Drawing.Size(84, 37)
        Me.导入当前部件ToolStripButton.Text = "导入当前部件"
        Me.导入当前部件ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        '导入已打开的文件ToolStripButton
        '
        Me.导入已打开的文件ToolStripButton.Enabled = False
        Me.导入已打开的文件ToolStripButton.Image = CType(resources.GetObject("导入已打开的文件ToolStripButton.Image"), System.Drawing.Image)
        Me.导入已打开的文件ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.导入已打开的文件ToolStripButton.Name = "导入已打开的文件ToolStripButton"
        Me.导入已打开的文件ToolStripButton.Size = New System.Drawing.Size(108, 37)
        Me.导入已打开的文件ToolStripButton.Text = "导入已打开的文件"
        Me.导入已打开的文件ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        '转换格式ToolStrip
        '
        Me.转换格式ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.转换格式ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.转换格式ToolStripLabel, Me.ToolStripSeparator2, Me.DWGToolStripButton, Me.DXFToolStripButton, Me.PDFToolStripButton, Me.JPGToolStripButton, Me.STPToolStripButton, Me.XTToolStripButton})
        Me.转换格式ToolStrip.Location = New System.Drawing.Point(0, 80)
        Me.转换格式ToolStrip.Name = "转换格式ToolStrip"
        Me.转换格式ToolStrip.Size = New System.Drawing.Size(800, 40)
        Me.转换格式ToolStrip.TabIndex = 40
        Me.转换格式ToolStrip.Text = "转换格式"
        '
        '转换格式ToolStripLabel
        '
        Me.转换格式ToolStripLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.转换格式ToolStripLabel.Image = CType(resources.GetObject("转换格式ToolStripLabel.Image"), System.Drawing.Image)
        Me.转换格式ToolStripLabel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.转换格式ToolStripLabel.Name = "转换格式ToolStripLabel"
        Me.转换格式ToolStripLabel.Size = New System.Drawing.Size(56, 37)
        Me.转换格式ToolStripLabel.Text = "转换格式"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'DWGToolStripButton
        '
        Me.DWGToolStripButton.CheckOnClick = True
        Me.DWGToolStripButton.Enabled = False
        Me.DWGToolStripButton.Image = CType(resources.GetObject("DWGToolStripButton.Image"), System.Drawing.Image)
        Me.DWGToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DWGToolStripButton.Name = "DWGToolStripButton"
        Me.DWGToolStripButton.Size = New System.Drawing.Size(42, 37)
        Me.DWGToolStripButton.Text = "DWG"
        Me.DWGToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'DXFToolStripButton
        '
        Me.DXFToolStripButton.CheckOnClick = True
        Me.DXFToolStripButton.Enabled = False
        Me.DXFToolStripButton.Image = CType(resources.GetObject("DXFToolStripButton.Image"), System.Drawing.Image)
        Me.DXFToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DXFToolStripButton.Name = "DXFToolStripButton"
        Me.DXFToolStripButton.Size = New System.Drawing.Size(35, 37)
        Me.DXFToolStripButton.Text = "DXF"
        Me.DXFToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'PDFToolStripButton
        '
        Me.PDFToolStripButton.CheckOnClick = True
        Me.PDFToolStripButton.Enabled = False
        Me.PDFToolStripButton.Image = CType(resources.GetObject("PDFToolStripButton.Image"), System.Drawing.Image)
        Me.PDFToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PDFToolStripButton.Name = "PDFToolStripButton"
        Me.PDFToolStripButton.Size = New System.Drawing.Size(34, 37)
        Me.PDFToolStripButton.Text = "PDF"
        Me.PDFToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'JPGToolStripButton
        '
        Me.JPGToolStripButton.CheckOnClick = True
        Me.JPGToolStripButton.Enabled = False
        Me.JPGToolStripButton.Image = CType(resources.GetObject("JPGToolStripButton.Image"), System.Drawing.Image)
        Me.JPGToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.JPGToolStripButton.Name = "JPGToolStripButton"
        Me.JPGToolStripButton.Size = New System.Drawing.Size(33, 37)
        Me.JPGToolStripButton.Text = "JPG"
        Me.JPGToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'STPToolStripButton
        '
        Me.STPToolStripButton.CheckOnClick = True
        Me.STPToolStripButton.Enabled = False
        Me.STPToolStripButton.Image = CType(resources.GetObject("STPToolStripButton.Image"), System.Drawing.Image)
        Me.STPToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.STPToolStripButton.Name = "STPToolStripButton"
        Me.STPToolStripButton.Size = New System.Drawing.Size(33, 37)
        Me.STPToolStripButton.Text = "STP"
        Me.STPToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'XTToolStripButton
        '
        Me.XTToolStripButton.CheckOnClick = True
        Me.XTToolStripButton.Enabled = False
        Me.XTToolStripButton.Image = CType(resources.GetObject("XTToolStripButton.Image"), System.Drawing.Image)
        Me.XTToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.XTToolStripButton.Name = "XTToolStripButton"
        Me.XTToolStripButton.Size = New System.Drawing.Size(32, 37)
        Me.XTToolStripButton.Text = "X_T"
        Me.XTToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.目录设置ToolStripLabel, Me.ToolStripSeparator4, Me.格式分类ToolStripButton, Me.指定文件夹ToolStripButton, Me.浏览ToolStripButton, Me.指定文件夹ToolStripTextBox})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 120)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(800, 40)
        Me.ToolStrip1.TabIndex = 41
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        '目录设置ToolStripLabel
        '
        Me.目录设置ToolStripLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.目录设置ToolStripLabel.Image = CType(resources.GetObject("目录设置ToolStripLabel.Image"), System.Drawing.Image)
        Me.目录设置ToolStripLabel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.目录设置ToolStripLabel.Name = "目录设置ToolStripLabel"
        Me.目录设置ToolStripLabel.Size = New System.Drawing.Size(56, 37)
        Me.目录设置ToolStripLabel.Text = "目录设置"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 40)
        '
        '格式分类ToolStripButton
        '
        Me.格式分类ToolStripButton.Checked = True
        Me.格式分类ToolStripButton.CheckOnClick = True
        Me.格式分类ToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked
        Me.格式分类ToolStripButton.Image = CType(resources.GetObject("格式分类ToolStripButton.Image"), System.Drawing.Image)
        Me.格式分类ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.格式分类ToolStripButton.Name = "格式分类ToolStripButton"
        Me.格式分类ToolStripButton.Size = New System.Drawing.Size(60, 37)
        Me.格式分类ToolStripButton.Text = "格式分类"
        Me.格式分类ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.格式分类ToolStripButton.ToolTipText = "按格式分类到子文件夹"
        '
        '指定文件夹ToolStripButton
        '
        Me.指定文件夹ToolStripButton.CheckOnClick = True
        Me.指定文件夹ToolStripButton.Image = CType(resources.GetObject("指定文件夹ToolStripButton.Image"), System.Drawing.Image)
        Me.指定文件夹ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.指定文件夹ToolStripButton.Name = "指定文件夹ToolStripButton"
        Me.指定文件夹ToolStripButton.Size = New System.Drawing.Size(72, 37)
        Me.指定文件夹ToolStripButton.Text = "指定文件夹"
        Me.指定文件夹ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        '浏览ToolStripButton
        '
        Me.浏览ToolStripButton.Enabled = False
        Me.浏览ToolStripButton.Image = CType(resources.GetObject("浏览ToolStripButton.Image"), System.Drawing.Image)
        Me.浏览ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.浏览ToolStripButton.Name = "浏览ToolStripButton"
        Me.浏览ToolStripButton.Size = New System.Drawing.Size(36, 37)
        Me.浏览ToolStripButton.Text = "浏览"
        Me.浏览ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.浏览ToolStripButton.ToolTipText = "浏览指定文件夹"
        '
        '指定文件夹ToolStripTextBox
        '
        Me.指定文件夹ToolStripTextBox.Enabled = False
        Me.指定文件夹ToolStripTextBox.Name = "指定文件夹ToolStripTextBox"
        Me.指定文件夹ToolStripTextBox.Size = New System.Drawing.Size(550, 40)
        '
        'frmFormatConversion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn关闭
        Me.ClientSize = New System.Drawing.Size(800, 511)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.转换格式ToolStrip)
        Me.Controls.Add(Me.加载方式ToolStrip)
        Me.Controls.Add(Me.ToolStrip文档格式)
        Me.Controls.Add(Me.Lvw文件列表)
        Me.Controls.Add(Me.btn关闭)
        Me.Controls.Add(Me.btn转换)
        Me.Name = "frmFormatConversion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "格式转换"
        Me.cms右键菜单.ResumeLayout(False)
        Me.ToolStrip文档格式.ResumeLayout(False)
        Me.ToolStrip文档格式.PerformLayout()
        Me.加载方式ToolStrip.ResumeLayout(False)
        Me.加载方式ToolStrip.PerformLayout()
        Me.转换格式ToolStrip.ResumeLayout(False)
        Me.转换格式ToolStrip.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn转换 As System.Windows.Forms.Button
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents Lvw文件列表 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader文件名 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cms右键菜单 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmi移出 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi清空 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip文档格式 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 工程图ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 零部件ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 文档格式ToolStripButton As System.Windows.Forms.ToolStripLabel
    Friend WithEvents 加载方式ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents 加载方式ToolStripButton As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 添加文件ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 添加文件夹ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 从部件导入ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 导入当前部件ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 导入已打开的文件ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 转换格式ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents 转换格式ToolStripLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DWGToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DXFToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PDFToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents JPGToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents STPToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents XTToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents 目录设置ToolStripLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 格式分类ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 指定文件夹ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 浏览ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 移出文件ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 清空列表ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 指定文件夹ToolStripTextBox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents 静默转换ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 转换后关闭ToolStripButton As System.Windows.Forms.ToolStripButton

End Class
