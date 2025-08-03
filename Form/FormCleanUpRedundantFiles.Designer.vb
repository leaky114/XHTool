

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCleanUpRedundantFiles
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCleanUpRedundantFiles))
        Me.lvw文件列表 = New System.Windows.Forms.ListView()
        Me.ch目录文件 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch说明 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch文件路径 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.工具栏ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.关闭ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.清理ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.全选清理项ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.查询ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.工具栏ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvw文件列表
        '
        Me.lvw文件列表.AllowDrop = True
        Me.lvw文件列表.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvw文件列表.CheckBoxes = True
        Me.lvw文件列表.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ch目录文件, Me.ch说明, Me.ch文件路径})
        Me.lvw文件列表.FullRowSelect = True
        Me.lvw文件列表.HideSelection = False
        Me.lvw文件列表.Location = New System.Drawing.Point(9, 12)
        Me.lvw文件列表.MultiSelect = False
        Me.lvw文件列表.Name = "lvw文件列表"
        Me.lvw文件列表.Size = New System.Drawing.Size(756, 374)
        Me.lvw文件列表.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvw文件列表.TabIndex = 0
        Me.lvw文件列表.UseCompatibleStateImageBehavior = False
        Me.lvw文件列表.View = System.Windows.Forms.View.Details
        '
        'ch目录文件
        '
        Me.ch目录文件.Text = "目录文件"
        Me.ch目录文件.Width = 250
        '
        'ch说明
        '
        Me.ch说明.Text = "说明"
        Me.ch说明.Width = 180
        '
        'ch文件路径
        '
        Me.ch文件路径.Text = "文件路径"
        Me.ch文件路径.Width = 320
        '
        '工具栏ToolStrip
        '
        Me.工具栏ToolStrip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.工具栏ToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.工具栏ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.工具栏ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.关闭ToolStripButton, Me.清理ToolStripButton, Me.全选清理项ToolStripButton, Me.查询ToolStripButton})
        Me.工具栏ToolStrip.Location = New System.Drawing.Point(618, 394)
        Me.工具栏ToolStrip.Name = "工具栏ToolStrip"
        Me.工具栏ToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.工具栏ToolStrip.Size = New System.Drawing.Size(147, 40)
        Me.工具栏ToolStrip.TabIndex = 43
        Me.工具栏ToolStrip.Text = "开始转换"
        '
        '关闭ToolStripButton
        '
        Me.关闭ToolStripButton.CheckOnClick = True
        Me.关闭ToolStripButton.Image = CType(resources.GetObject("关闭ToolStripButton.Image"), System.Drawing.Image)
        Me.关闭ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.关闭ToolStripButton.Name = "关闭ToolStripButton"
        Me.关闭ToolStripButton.Size = New System.Drawing.Size(36, 37)
        Me.关闭ToolStripButton.Text = "关闭"
        Me.关闭ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        '清理ToolStripButton
        '
        Me.清理ToolStripButton.Image = CType(resources.GetObject("清理ToolStripButton.Image"), System.Drawing.Image)
        Me.清理ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.清理ToolStripButton.Name = "清理ToolStripButton"
        Me.清理ToolStripButton.Size = New System.Drawing.Size(36, 37)
        Me.清理ToolStripButton.Text = "清理"
        Me.清理ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        '全选清理项ToolStripButton
        '
        Me.全选清理项ToolStripButton.Image = CType(resources.GetObject("全选清理项ToolStripButton.Image"), System.Drawing.Image)
        Me.全选清理项ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.全选清理项ToolStripButton.Name = "全选清理项ToolStripButton"
        Me.全选清理项ToolStripButton.Size = New System.Drawing.Size(36, 37)
        Me.全选清理项ToolStripButton.Text = "全选"
        Me.全选清理项ToolStripButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.全选清理项ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.全选清理项ToolStripButton.ToolTipText = "全选可清理项"
        '
        '查询ToolStripButton
        '
        Me.查询ToolStripButton.Image = CType(resources.GetObject("查询ToolStripButton.Image"), System.Drawing.Image)
        Me.查询ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.查询ToolStripButton.Name = "查询ToolStripButton"
        Me.查询ToolStripButton.Size = New System.Drawing.Size(36, 37)
        Me.查询ToolStripButton.Text = "查询"
        Me.查询ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.查询ToolStripButton.ToolTipText = "查询冗余文件"
        '
        'FormCleanUpRedundantFiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 443)
        Me.Controls.Add(Me.工具栏ToolStrip)
        Me.Controls.Add(Me.lvw文件列表)
        Me.Name = "FormCleanUpRedundantFiles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "清理冗余文件"
        Me.TopMost = True
        Me.工具栏ToolStrip.ResumeLayout(False)
        Me.工具栏ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvw文件列表 As System.Windows.Forms.ListView
    Friend WithEvents ch说明 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch文件路径 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch目录文件 As System.Windows.Forms.ColumnHeader
    Friend WithEvents 工具栏ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents 查询ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 清理ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 关闭ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 全选清理项ToolStripButton As System.Windows.Forms.ToolStripButton
End Class
