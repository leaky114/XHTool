Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPantone
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
        Me.components = New System.ComponentModel.Container()
        Me.Img_Color = New System.Windows.Forms.ImageList(Me.components)
        Me.Tol_ColorList = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.Com_ColorList = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.Com_Type = New System.Windows.Forms.ToolStripComboBox()
        Me.Tol_ColorFilter = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.Txt_Filter = New System.Windows.Forms.ToolStripTextBox()
        Me.Tol_ColorSet = New System.Windows.Forms.ToolStrip()
        Me.Btn_Close = New System.Windows.Forms.ToolStripButton()
        Me.Btn_Color = New System.Windows.Forms.ToolStripButton()
        Me.Btn_Random = New System.Windows.Forms.ToolStripButton()
        Me.Tol_ColorBar = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.Txt_R = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.Txt_G = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.Txt_B = New System.Windows.Forms.ToolStripTextBox()
        Me.Btn_Custom = New System.Windows.Forms.ToolStripButton()
        Me.Lst_Color = New System.Windows.Forms.ListView()
        Me.Tol_ColorAsset = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripLabel()
        Me.Btn_Refresh = New System.Windows.Forms.ToolStripButton()
        Me.Btn_Clear = New System.Windows.Forms.ToolStripButton()
        Me.Btn_Print = New System.Windows.Forms.ToolStripButton()
        Me.Tre_Asset = New System.Windows.Forms.TreeView()
        Me.img_Tree = New System.Windows.Forms.ImageList(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Tol_ColorList.SuspendLayout()
        Me.Tol_ColorFilter.SuspendLayout()
        Me.Tol_ColorSet.SuspendLayout()
        Me.Tol_ColorBar.SuspendLayout()
        Me.Tol_ColorAsset.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Img_Color
        '
        Me.Img_Color.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.Img_Color.ImageSize = New System.Drawing.Size(16, 16)
        Me.Img_Color.TransparentColor = System.Drawing.Color.Transparent
        '
        'Tol_ColorList
        '
        Me.Tol_ColorList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Tol_ColorList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.Com_ColorList, Me.ToolStripLabel6, Me.Com_Type})
        Me.Tol_ColorList.Location = New System.Drawing.Point(0, 0)
        Me.Tol_ColorList.Name = "Tol_ColorList"
        Me.Tol_ColorList.Size = New System.Drawing.Size(506, 25)
        Me.Tol_ColorList.TabIndex = 3
        Me.Tol_ColorList.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(32, 22)
        Me.ToolStripLabel1.Text = "色卡"
        '
        'Com_ColorList
        '
        Me.Com_ColorList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Com_ColorList.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Com_ColorList.Name = "Com_ColorList"
        Me.Com_ColorList.Size = New System.Drawing.Size(250, 25)
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(32, 22)
        Me.ToolStripLabel6.Text = "类型"
        '
        'Com_Type
        '
        Me.Com_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Com_Type.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.Com_Type.Name = "Com_Type"
        Me.Com_Type.Size = New System.Drawing.Size(100, 25)
        '
        'Tol_ColorFilter
        '
        Me.Tol_ColorFilter.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Tol_ColorFilter.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.Txt_Filter})
        Me.Tol_ColorFilter.Location = New System.Drawing.Point(0, 25)
        Me.Tol_ColorFilter.Name = "Tol_ColorFilter"
        Me.Tol_ColorFilter.Size = New System.Drawing.Size(506, 25)
        Me.Tol_ColorFilter.TabIndex = 4
        Me.Tol_ColorFilter.Text = "ToolStrip2"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(32, 22)
        Me.ToolStripLabel2.Text = "查找"
        '
        'Txt_Filter
        '
        Me.Txt_Filter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Filter.Name = "Txt_Filter"
        Me.Txt_Filter.Size = New System.Drawing.Size(300, 25)
        '
        'Tol_ColorSet
        '
        Me.Tol_ColorSet.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Tol_ColorSet.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Tol_ColorSet.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Btn_Close, Me.Btn_Color, Me.Btn_Random})
        Me.Tol_ColorSet.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.Tol_ColorSet.Location = New System.Drawing.Point(0, 537)
        Me.Tol_ColorSet.Name = "Tol_ColorSet"
        Me.Tol_ColorSet.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Tol_ColorSet.Size = New System.Drawing.Size(506, 24)
        Me.Tol_ColorSet.TabIndex = 5
        Me.Tol_ColorSet.Text = "ToolStrip3"
        '
        'Btn_Close
        '
        Me.Btn_Close.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Close.Name = "Btn_Close"
        Me.Btn_Close.Size = New System.Drawing.Size(36, 21)
        Me.Btn_Close.Text = "关闭"
        Me.Btn_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Btn_Color
        '
        Me.Btn_Color.Enabled = False
        Me.Btn_Color.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Color.Name = "Btn_Color"
        Me.Btn_Color.Size = New System.Drawing.Size(36, 21)
        Me.Btn_Color.Text = "着色"
        Me.Btn_Color.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Btn_Random
        '
        Me.Btn_Random.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Random.Name = "Btn_Random"
        Me.Btn_Random.Size = New System.Drawing.Size(36, 21)
        Me.Btn_Random.Text = "随机"
        Me.Btn_Random.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Tol_ColorBar
        '
        Me.Tol_ColorBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Tol_ColorBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Tol_ColorBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel3, Me.Txt_R, Me.ToolStripLabel5, Me.Txt_G, Me.ToolStripLabel4, Me.Txt_B, Me.Btn_Custom})
        Me.Tol_ColorBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.Tol_ColorBar.Location = New System.Drawing.Point(0, 513)
        Me.Tol_ColorBar.Name = "Tol_ColorBar"
        Me.Tol_ColorBar.Size = New System.Drawing.Size(506, 24)
        Me.Tol_ColorBar.TabIndex = 6
        Me.Tol_ColorBar.Text = "ToolStrip4"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(57, 17)
        Me.ToolStripLabel3.Text = "R(0-255)"
        '
        'Txt_R
        '
        Me.Txt_R.Name = "Txt_R"
        Me.Txt_R.Size = New System.Drawing.Size(50, 23)
        Me.Txt_R.Text = "0"
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(58, 17)
        Me.ToolStripLabel5.Text = "G(0-255)"
        '
        'Txt_G
        '
        Me.Txt_G.Name = "Txt_G"
        Me.Txt_G.Size = New System.Drawing.Size(50, 23)
        Me.Txt_G.Text = "0"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(57, 17)
        Me.ToolStripLabel4.Text = "B(0-255)"
        '
        'Txt_B
        '
        Me.Txt_B.Name = "Txt_B"
        Me.Txt_B.Size = New System.Drawing.Size(50, 23)
        Me.Txt_B.Text = "0"
        '
        'Btn_Custom
        '
        Me.Btn_Custom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Btn_Custom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Custom.Name = "Btn_Custom"
        Me.Btn_Custom.Size = New System.Drawing.Size(48, 21)
        Me.Btn_Custom.Text = "自定义"
        '
        'Lst_Color
        '
        Me.Lst_Color.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lst_Color.HideSelection = False
        Me.Lst_Color.Location = New System.Drawing.Point(0, 50)
        Me.Lst_Color.Name = "Lst_Color"
        Me.Lst_Color.Size = New System.Drawing.Size(506, 463)
        Me.Lst_Color.SmallImageList = Me.Img_Color
        Me.Lst_Color.TabIndex = 7
        Me.Lst_Color.UseCompatibleStateImageBehavior = False
        Me.Lst_Color.View = System.Windows.Forms.View.List
        '
        'Tol_ColorAsset
        '
        Me.Tol_ColorAsset.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Tol_ColorAsset.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel7, Me.Btn_Refresh, Me.Btn_Clear, Me.Btn_Print})
        Me.Tol_ColorAsset.Location = New System.Drawing.Point(0, 0)
        Me.Tol_ColorAsset.Name = "Tol_ColorAsset"
        Me.Tol_ColorAsset.Size = New System.Drawing.Size(354, 25)
        Me.Tol_ColorAsset.TabIndex = 0
        Me.Tol_ColorAsset.Text = "ToolStrip5"
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripLabel7.Text = "文档外观"
        '
        'Btn_Refresh
        '
        Me.Btn_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Refresh.Name = "Btn_Refresh"
        Me.Btn_Refresh.Size = New System.Drawing.Size(36, 22)
        Me.Btn_Refresh.Text = "刷新"
        Me.Btn_Refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Btn_Clear
        '
        Me.Btn_Clear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Clear.Name = "Btn_Clear"
        Me.Btn_Clear.Size = New System.Drawing.Size(60, 22)
        Me.Btn_Clear.Text = "清理冗余"
        Me.Btn_Clear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Btn_Print
        '
        Me.Btn_Print.Enabled = False
        Me.Btn_Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Print.Name = "Btn_Print"
        Me.Btn_Print.Size = New System.Drawing.Size(60, 22)
        Me.Btn_Print.Text = "油漆用量"
        Me.Btn_Print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Tre_Asset
        '
        Me.Tre_Asset.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tre_Asset.ImageIndex = 0
        Me.Tre_Asset.ImageList = Me.img_Tree
        Me.Tre_Asset.Location = New System.Drawing.Point(0, 25)
        Me.Tre_Asset.Name = "Tre_Asset"
        Me.Tre_Asset.SelectedImageIndex = 0
        Me.Tre_Asset.Size = New System.Drawing.Size(354, 536)
        Me.Tre_Asset.TabIndex = 1
        '
        'img_Tree
        '
        Me.img_Tree.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.img_Tree.ImageSize = New System.Drawing.Size(16, 16)
        Me.img_Tree.TransparentColor = System.Drawing.Color.Transparent
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Lst_Color)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tol_ColorFilter)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tol_ColorList)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tol_ColorBar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tol_ColorSet)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Tre_Asset)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Tol_ColorAsset)
        Me.SplitContainer1.Size = New System.Drawing.Size(864, 561)
        Me.SplitContainer1.SplitterDistance = 506
        Me.SplitContainer1.TabIndex = 8
        '
        'FormPantone
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(864, 561)
        Me.Controls.Add(Me.SplitContainer1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(880, 600)
        Me.Name = "FormPantone"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "色卡"
        Me.Tol_ColorList.ResumeLayout(False)
        Me.Tol_ColorList.PerformLayout()
        Me.Tol_ColorFilter.ResumeLayout(False)
        Me.Tol_ColorFilter.PerformLayout()
        Me.Tol_ColorSet.ResumeLayout(False)
        Me.Tol_ColorSet.PerformLayout()
        Me.Tol_ColorBar.ResumeLayout(False)
        Me.Tol_ColorBar.PerformLayout()
        Me.Tol_ColorAsset.ResumeLayout(False)
        Me.Tol_ColorAsset.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Img_Color As ImageList
    Friend WithEvents Tol_ColorList As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents Com_ColorList As ToolStripComboBox
    Friend WithEvents Tol_ColorFilter As ToolStrip
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents Txt_Filter As ToolStripTextBox
    Friend WithEvents Tol_ColorSet As ToolStrip
    Friend WithEvents Btn_Close As ToolStripButton
    Friend WithEvents Btn_Color As ToolStripButton
    Friend WithEvents Btn_Random As ToolStripButton
    Friend WithEvents Tol_ColorBar As ToolStrip
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents Txt_R As ToolStripTextBox
    Friend WithEvents ToolStripLabel5 As ToolStripLabel
    Friend WithEvents Txt_G As ToolStripTextBox
    Friend WithEvents ToolStripLabel4 As ToolStripLabel
    Friend WithEvents Txt_B As ToolStripTextBox
    Friend WithEvents Lst_Color As ListView
    Friend WithEvents Btn_Custom As ToolStripButton
    Friend WithEvents ToolStripLabel6 As ToolStripLabel
    Friend WithEvents Com_Type As ToolStripComboBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Tre_Asset As TreeView
    Friend WithEvents Tol_ColorAsset As ToolStrip
    Friend WithEvents Btn_Clear As ToolStripButton
    Friend WithEvents Btn_Refresh As ToolStripButton
    Friend WithEvents ToolStripLabel7 As ToolStripLabel
    Friend WithEvents img_Tree As ImageList
    Friend WithEvents Btn_Print As ToolStripButton
End Class
