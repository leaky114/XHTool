<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formMovesSpecifiedFile
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

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formMovesSpecifiedFile))
        Me.ToolStrip文档格式 = New System.Windows.Forms.ToolStrip()
        Me.筛选ToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.应用ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.重载ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.Lvw文件列表 = New System.Windows.Forms.ListView()
        Me.ColumnHeader当前文件 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader目标文件 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip文档格式.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip文档格式
        '
        Me.ToolStrip文档格式.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip文档格式.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip文档格式.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip文档格式.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.筛选ToolStripTextBox, Me.重载ToolStripButton, Me.应用ToolStripButton})
        Me.ToolStrip文档格式.Location = New System.Drawing.Point(-2, 395)
        Me.ToolStrip文档格式.Name = "ToolStrip文档格式"
        Me.ToolStrip文档格式.Size = New System.Drawing.Size(277, 40)
        Me.ToolStrip文档格式.TabIndex = 39
        Me.ToolStrip文档格式.Text = "ToolStrip1"
        '
        '筛选ToolStripTextBox
        '
        Me.筛选ToolStripTextBox.AutoSize = False
        Me.筛选ToolStripTextBox.Name = "筛选ToolStripTextBox"
        Me.筛选ToolStripTextBox.Size = New System.Drawing.Size(200, 23)
        '
        '应用ToolStripButton
        '
        Me.应用ToolStripButton.Image = CType(resources.GetObject("应用ToolStripButton.Image"), System.Drawing.Image)
        Me.应用ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.应用ToolStripButton.Name = "应用ToolStripButton"
        Me.应用ToolStripButton.Size = New System.Drawing.Size(36, 37)
        Me.应用ToolStripButton.Text = "应用"
        Me.应用ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        '重载ToolStripButton
        '
        Me.重载ToolStripButton.CheckOnClick = True
        Me.重载ToolStripButton.Image = CType(resources.GetObject("重载ToolStripButton.Image"), System.Drawing.Image)
        Me.重载ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.重载ToolStripButton.Name = "重载ToolStripButton"
        Me.重载ToolStripButton.Size = New System.Drawing.Size(36, 37)
        Me.重载ToolStripButton.Text = "重载"
        Me.重载ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Lvw文件列表
        '
        Me.Lvw文件列表.AllowColumnReorder = True
        Me.Lvw文件列表.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lvw文件列表.AutoArrange = False
        Me.Lvw文件列表.BackColor = System.Drawing.SystemColors.Window
        Me.Lvw文件列表.CheckBoxes = True
        Me.Lvw文件列表.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader当前文件, Me.ColumnHeader目标文件})
        Me.Lvw文件列表.FullRowSelect = True
        Me.Lvw文件列表.GridLines = True
        Me.Lvw文件列表.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.Lvw文件列表.Location = New System.Drawing.Point(12, 12)
        Me.Lvw文件列表.Name = "Lvw文件列表"
        Me.Lvw文件列表.Size = New System.Drawing.Size(734, 380)
        Me.Lvw文件列表.SmallImageList = Me.ImageList1
        Me.Lvw文件列表.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.Lvw文件列表.TabIndex = 46
        Me.Lvw文件列表.TabStop = False
        Me.Lvw文件列表.UseCompatibleStateImageBehavior = False
        Me.Lvw文件列表.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader当前文件
        '
        Me.ColumnHeader当前文件.Text = "当前文件"
        Me.ColumnHeader当前文件.Width = 353
        '
        'ColumnHeader目标文件
        '
        Me.ColumnHeader目标文件.Text = "目标文件"
        Me.ColumnHeader目标文件.Width = 322
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "部件16.ico")
        Me.ImageList1.Images.SetKeyName(1, "零件16.ico")
        Me.ImageList1.Images.SetKeyName(2, "工程图16.ico")
        '
        'frmMovesSpecifiedFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(758, 435)
        Me.Controls.Add(Me.Lvw文件列表)
        Me.Controls.Add(Me.ToolStrip文档格式)
        Me.Name = "frmMovesSpecifiedFile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "移动文件"
        Me.ToolStrip文档格式.ResumeLayout(False)
        Me.ToolStrip文档格式.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip文档格式 As System.Windows.Forms.ToolStrip
    Friend WithEvents 筛选ToolStripTextBox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents 应用ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents 重载ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents Lvw文件列表 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader当前文件 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader目标文件 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class
