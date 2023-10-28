<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrint))
        Me.btn开始 = New System.Windows.Forms.Button()
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.btn添加文件 = New System.Windows.Forms.Button()
        Me.btn清空列表 = New System.Windows.Forms.Button()
        Me.btn添加文件夹 = New System.Windows.Forms.Button()
        Me.lbl建议 = New System.Windows.Forms.Label()
        Me.grp选项 = New System.Windows.Forms.GroupBox()
        Me.btn保存配置 = New System.Windows.Forms.Button()
        Me.chk关闭窗口 = New System.Windows.Forms.CheckBox()
        Me.chk刷新工程图 = New System.Windows.Forms.CheckBox()
        Me.chk保存工程图 = New System.Windows.Forms.CheckBox()
        Me.chk保存签字 = New System.Windows.Forms.CheckBox()
        Me.chk存为dwg = New System.Windows.Forms.CheckBox()
        Me.chk存为pdf = New System.Windows.Forms.CheckBox()
        Me.chk打印后关闭 = New System.Windows.Forms.CheckBox()
        Me.lbl份数 = New System.Windows.Forms.Label()
        Me.lbl打印机 = New System.Windows.Forms.Label()
        Me.nud份数 = New System.Windows.Forms.NumericUpDown()
        Me.cmb打印机 = New System.Windows.Forms.ComboBox()
        Me.chk匹配A3 = New System.Windows.Forms.CheckBox()
        Me.chk签字 = New System.Windows.Forms.CheckBox()
        Me.chk打印为黑色 = New System.Windows.Forms.CheckBox()
        Me.btn从部件导入 = New System.Windows.Forms.Button()
        Me.btn导入已打开文件 = New System.Windows.Forms.Button()
        Me.lvw文件列表 = New System.Windows.Forms.ListView()
        Me.ColumnHeader文件名 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cms右键菜单 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmi移出 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi筛选移出 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi筛选保留 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn导入当前部件 = New System.Windows.Forms.Button()
        Me.grp选项.SuspendLayout()
        CType(Me.nud份数, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms右键菜单.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn开始
        '
        Me.btn开始.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn开始.Location = New System.Drawing.Point(671, 443)
        Me.btn开始.Name = "btn开始"
        Me.btn开始.Size = New System.Drawing.Size(86, 28)
        Me.btn开始.TabIndex = 1
        Me.btn开始.TabStop = False
        Me.btn开始.Text = "开始打印"
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(769, 443)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(57, 28)
        Me.btn关闭.TabIndex = 1
        Me.btn关闭.TabStop = False
        Me.btn关闭.Text = "关闭"
        '
        'btn添加文件
        '
        Me.btn添加文件.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn添加文件.Location = New System.Drawing.Point(116, 443)
        Me.btn添加文件.Name = "btn添加文件"
        Me.btn添加文件.Size = New System.Drawing.Size(85, 28)
        Me.btn添加文件.TabIndex = 1
        Me.btn添加文件.Text = "添加文件"
        Me.btn添加文件.UseVisualStyleBackColor = True
        '
        'btn清空列表
        '
        Me.btn清空列表.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn清空列表.Location = New System.Drawing.Point(570, 443)
        Me.btn清空列表.Name = "btn清空列表"
        Me.btn清空列表.Size = New System.Drawing.Size(85, 28)
        Me.btn清空列表.TabIndex = 3
        Me.btn清空列表.Text = "清除列表"
        Me.btn清空列表.UseVisualStyleBackColor = True
        '
        'btn添加文件夹
        '
        Me.btn添加文件夹.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn添加文件夹.Location = New System.Drawing.Point(217, 443)
        Me.btn添加文件夹.Name = "btn添加文件夹"
        Me.btn添加文件夹.Size = New System.Drawing.Size(85, 28)
        Me.btn添加文件夹.TabIndex = 2
        Me.btn添加文件夹.Text = "添加文件夹"
        Me.btn添加文件夹.UseVisualStyleBackColor = True
        '
        'lbl建议
        '
        Me.lbl建议.BackColor = System.Drawing.SystemColors.Window
        Me.lbl建议.Font = New System.Drawing.Font("微软雅黑", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl建议.ForeColor = System.Drawing.Color.Red
        Me.lbl建议.Location = New System.Drawing.Point(75, 144)
        Me.lbl建议.Name = "lbl建议"
        Me.lbl建议.Size = New System.Drawing.Size(686, 49)
        Me.lbl建议.TabIndex = 32
        Me.lbl建议.Text = "建议打开模型提高程序加载工程图的效率！"
        '
        'grp选项
        '
        Me.grp选项.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grp选项.Controls.Add(Me.btn保存配置)
        Me.grp选项.Controls.Add(Me.chk关闭窗口)
        Me.grp选项.Controls.Add(Me.chk刷新工程图)
        Me.grp选项.Controls.Add(Me.chk保存工程图)
        Me.grp选项.Controls.Add(Me.chk保存签字)
        Me.grp选项.Controls.Add(Me.chk存为dwg)
        Me.grp选项.Controls.Add(Me.chk存为pdf)
        Me.grp选项.Controls.Add(Me.chk打印后关闭)
        Me.grp选项.Controls.Add(Me.lbl份数)
        Me.grp选项.Controls.Add(Me.lbl打印机)
        Me.grp选项.Controls.Add(Me.nud份数)
        Me.grp选项.Controls.Add(Me.cmb打印机)
        Me.grp选项.Controls.Add(Me.chk匹配A3)
        Me.grp选项.Controls.Add(Me.chk签字)
        Me.grp选项.Controls.Add(Me.chk打印为黑色)
        Me.grp选项.Location = New System.Drawing.Point(12, 333)
        Me.grp选项.Name = "grp选项"
        Me.grp选项.Size = New System.Drawing.Size(815, 82)
        Me.grp选项.TabIndex = 33
        Me.grp选项.TabStop = False
        Me.grp选项.Text = "选项"
        '
        'btn保存配置
        '
        Me.btn保存配置.Location = New System.Drawing.Point(723, 37)
        Me.btn保存配置.Name = "btn保存配置"
        Me.btn保存配置.Size = New System.Drawing.Size(86, 28)
        Me.btn保存配置.TabIndex = 47
        Me.btn保存配置.Text = "保存配置"
        Me.btn保存配置.UseVisualStyleBackColor = True
        '
        'chk关闭窗口
        '
        Me.chk关闭窗口.AutoSize = True
        Me.chk关闭窗口.Checked = True
        Me.chk关闭窗口.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk关闭窗口.Location = New System.Drawing.Point(635, 25)
        Me.chk关闭窗口.Name = "chk关闭窗口"
        Me.chk关闭窗口.Size = New System.Drawing.Size(72, 16)
        Me.chk关闭窗口.TabIndex = 46
        Me.chk关闭窗口.Text = "退出打印"
        Me.chk关闭窗口.UseVisualStyleBackColor = True
        '
        'chk刷新工程图
        '
        Me.chk刷新工程图.AutoSize = True
        Me.chk刷新工程图.Location = New System.Drawing.Point(432, 25)
        Me.chk刷新工程图.Name = "chk刷新工程图"
        Me.chk刷新工程图.Size = New System.Drawing.Size(84, 16)
        Me.chk刷新工程图.TabIndex = 45
        Me.chk刷新工程图.Text = "刷新工程图"
        Me.chk刷新工程图.UseVisualStyleBackColor = True
        '
        'chk保存工程图
        '
        Me.chk保存工程图.AutoSize = True
        Me.chk保存工程图.Location = New System.Drawing.Point(432, 53)
        Me.chk保存工程图.Name = "chk保存工程图"
        Me.chk保存工程图.Size = New System.Drawing.Size(84, 16)
        Me.chk保存工程图.TabIndex = 44
        Me.chk保存工程图.Text = "保存工程图"
        Me.chk保存工程图.UseVisualStyleBackColor = True
        '
        'chk保存签字
        '
        Me.chk保存签字.AutoSize = True
        Me.chk保存签字.Location = New System.Drawing.Point(344, 53)
        Me.chk保存签字.Name = "chk保存签字"
        Me.chk保存签字.Size = New System.Drawing.Size(72, 16)
        Me.chk保存签字.TabIndex = 43
        Me.chk保存签字.Text = "保存签字"
        Me.chk保存签字.UseVisualStyleBackColor = True
        '
        'chk存为dwg
        '
        Me.chk存为dwg.AutoSize = True
        Me.chk存为dwg.Location = New System.Drawing.Point(528, 53)
        Me.chk存为dwg.Name = "chk存为dwg"
        Me.chk存为dwg.Size = New System.Drawing.Size(90, 16)
        Me.chk存为dwg.TabIndex = 42
        Me.chk存为dwg.Text = "同步存为Dwg"
        Me.chk存为dwg.UseVisualStyleBackColor = True
        '
        'chk存为pdf
        '
        Me.chk存为pdf.AutoSize = True
        Me.chk存为pdf.Location = New System.Drawing.Point(528, 25)
        Me.chk存为pdf.Name = "chk存为pdf"
        Me.chk存为pdf.Size = New System.Drawing.Size(90, 16)
        Me.chk存为pdf.TabIndex = 41
        Me.chk存为pdf.Text = "同步存为Pdf"
        Me.chk存为pdf.UseVisualStyleBackColor = True
        '
        'chk打印后关闭
        '
        Me.chk打印后关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chk打印后关闭.AutoSize = True
        Me.chk打印后关闭.Checked = True
        Me.chk打印后关闭.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk打印后关闭.Location = New System.Drawing.Point(248, 53)
        Me.chk打印后关闭.Name = "chk打印后关闭"
        Me.chk打印后关闭.Size = New System.Drawing.Size(84, 16)
        Me.chk打印后关闭.TabIndex = 39
        Me.chk打印后关闭.Text = "打印后关闭"
        Me.chk打印后关闭.UseVisualStyleBackColor = True
        '
        'lbl份数
        '
        Me.lbl份数.AutoSize = True
        Me.lbl份数.Location = New System.Drawing.Point(16, 53)
        Me.lbl份数.Name = "lbl份数"
        Me.lbl份数.Size = New System.Drawing.Size(29, 12)
        Me.lbl份数.TabIndex = 38
        Me.lbl份数.Text = "份数"
        '
        'lbl打印机
        '
        Me.lbl打印机.AutoSize = True
        Me.lbl打印机.Location = New System.Drawing.Point(14, 22)
        Me.lbl打印机.Name = "lbl打印机"
        Me.lbl打印机.Size = New System.Drawing.Size(41, 12)
        Me.lbl打印机.TabIndex = 37
        Me.lbl打印机.Text = "打印机"
        '
        'nud份数
        '
        Me.nud份数.Location = New System.Drawing.Point(54, 50)
        Me.nud份数.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nud份数.Name = "nud份数"
        Me.nud份数.Size = New System.Drawing.Size(46, 21)
        Me.nud份数.TabIndex = 36
        Me.nud份数.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cmb打印机
        '
        Me.cmb打印机.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb打印机.FormattingEnabled = True
        Me.cmb打印机.Location = New System.Drawing.Point(60, 21)
        Me.cmb打印机.Name = "cmb打印机"
        Me.cmb打印机.Size = New System.Drawing.Size(174, 20)
        Me.cmb打印机.Sorted = True
        Me.cmb打印机.TabIndex = 35
        '
        'chk匹配A3
        '
        Me.chk匹配A3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chk匹配A3.AutoSize = True
        Me.chk匹配A3.Checked = True
        Me.chk匹配A3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk匹配A3.Location = New System.Drawing.Point(248, 25)
        Me.chk匹配A3.Name = "chk匹配A3"
        Me.chk匹配A3.Size = New System.Drawing.Size(72, 16)
        Me.chk匹配A3.TabIndex = 34
        Me.chk匹配A3.Text = "匹配A3纸"
        Me.chk匹配A3.UseVisualStyleBackColor = True
        '
        'chk签字
        '
        Me.chk签字.AutoSize = True
        Me.chk签字.Checked = True
        Me.chk签字.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk签字.Location = New System.Drawing.Point(344, 25)
        Me.chk签字.Name = "chk签字"
        Me.chk签字.Size = New System.Drawing.Size(48, 16)
        Me.chk签字.TabIndex = 33
        Me.chk签字.Text = "签字"
        Me.chk签字.UseVisualStyleBackColor = True
        '
        'chk打印为黑色
        '
        Me.chk打印为黑色.AutoSize = True
        Me.chk打印为黑色.Checked = True
        Me.chk打印为黑色.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk打印为黑色.Location = New System.Drawing.Point(150, 53)
        Me.chk打印为黑色.Name = "chk打印为黑色"
        Me.chk打印为黑色.Size = New System.Drawing.Size(84, 16)
        Me.chk打印为黑色.TabIndex = 32
        Me.chk打印为黑色.Text = "打印为黑色"
        Me.chk打印为黑色.UseVisualStyleBackColor = True
        '
        'btn从部件导入
        '
        Me.btn从部件导入.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn从部件导入.Location = New System.Drawing.Point(15, 443)
        Me.btn从部件导入.Name = "btn从部件导入"
        Me.btn从部件导入.Size = New System.Drawing.Size(85, 28)
        Me.btn从部件导入.TabIndex = 0
        Me.btn从部件导入.Text = "从部件导入"
        Me.btn从部件导入.UseVisualStyleBackColor = True
        '
        'btn导入已打开文件
        '
        Me.btn导入已打开文件.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn导入已打开文件.Location = New System.Drawing.Point(444, 443)
        Me.btn导入已打开文件.Name = "btn导入已打开文件"
        Me.btn导入已打开文件.Size = New System.Drawing.Size(110, 28)
        Me.btn导入已打开文件.TabIndex = 34
        Me.btn导入已打开文件.Text = "导入已打开文件"
        Me.btn导入已打开文件.UseVisualStyleBackColor = True
        '
        'lvw文件列表
        '
        Me.lvw文件列表.AllowColumnReorder = True
        Me.lvw文件列表.AllowDrop = True
        Me.lvw文件列表.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvw文件列表.AutoArrange = False
        Me.lvw文件列表.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader文件名})
        Me.lvw文件列表.ContextMenuStrip = Me.cms右键菜单
        Me.lvw文件列表.FullRowSelect = True
        Me.lvw文件列表.Location = New System.Drawing.Point(15, 11)
        Me.lvw文件列表.Name = "lvw文件列表"
        Me.lvw文件列表.Size = New System.Drawing.Size(812, 306)
        Me.lvw文件列表.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvw文件列表.TabIndex = 36
        Me.lvw文件列表.UseCompatibleStateImageBehavior = False
        Me.lvw文件列表.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader文件名
        '
        Me.ColumnHeader文件名.Text = "文件名(双击打开)"
        Me.ColumnHeader文件名.Width = 792
        '
        'cms右键菜单
        '
        Me.cms右键菜单.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi移出, Me.tsmi筛选移出, Me.tsmi筛选保留})
        Me.cms右键菜单.Name = "cmsRemove"
        Me.cms右键菜单.Size = New System.Drawing.Size(125, 70)
        '
        'tsmi移出
        '
        Me.tsmi移出.Name = "tsmi移出"
        Me.tsmi移出.Size = New System.Drawing.Size(124, 22)
        Me.tsmi移出.Text = "移出"
        '
        'tsmi筛选移出
        '
        Me.tsmi筛选移出.Name = "tsmi筛选移出"
        Me.tsmi筛选移出.Size = New System.Drawing.Size(124, 22)
        Me.tsmi筛选移出.Text = "筛选移出"
        '
        'tsmi筛选保留
        '
        Me.tsmi筛选保留.Name = "tsmi筛选保留"
        Me.tsmi筛选保留.Size = New System.Drawing.Size(124, 22)
        Me.tsmi筛选保留.Text = "筛选保留"
        '
        'btn导入当前部件
        '
        Me.btn导入当前部件.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn导入当前部件.Location = New System.Drawing.Point(318, 443)
        Me.btn导入当前部件.Name = "btn导入当前部件"
        Me.btn导入当前部件.Size = New System.Drawing.Size(110, 28)
        Me.btn导入当前部件.TabIndex = 37
        Me.btn导入当前部件.Text = "导入当前部件"
        Me.btn导入当前部件.UseVisualStyleBackColor = True
        '
        'frmPrint
        '
        Me.AcceptButton = Me.btn导入已打开文件
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn关闭
        Me.ClientSize = New System.Drawing.Size(840, 480)
        Me.Controls.Add(Me.btn导入当前部件)
        Me.Controls.Add(Me.btn导入已打开文件)
        Me.Controls.Add(Me.btn从部件导入)
        Me.Controls.Add(Me.grp选项)
        Me.Controls.Add(Me.lbl建议)
        Me.Controls.Add(Me.btn添加文件夹)
        Me.Controls.Add(Me.btn清空列表)
        Me.Controls.Add(Me.btn添加文件)
        Me.Controls.Add(Me.btn关闭)
        Me.Controls.Add(Me.btn开始)
        Me.Controls.Add(Me.lvw文件列表)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmPrint"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "批量打印"
        Me.TopMost = True
        Me.grp选项.ResumeLayout(False)
        Me.grp选项.PerformLayout()
        CType(Me.nud份数, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms右键菜单.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn开始 As System.Windows.Forms.Button
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents btn清空列表 As System.Windows.Forms.Button
    Friend WithEvents btn添加文件夹 As System.Windows.Forms.Button
    Friend WithEvents lbl建议 As System.Windows.Forms.Label
    Friend WithEvents grp选项 As System.Windows.Forms.GroupBox
    Friend WithEvents cmb打印机 As System.Windows.Forms.ComboBox
    Friend WithEvents chk匹配A3 As System.Windows.Forms.CheckBox
    Friend WithEvents chk签字 As System.Windows.Forms.CheckBox
    Friend WithEvents chk打印为黑色 As System.Windows.Forms.CheckBox
    Friend WithEvents nud份数 As System.Windows.Forms.NumericUpDown
    Friend WithEvents lbl份数 As System.Windows.Forms.Label
    Friend WithEvents lbl打印机 As System.Windows.Forms.Label
    Friend WithEvents btn添加文件 As System.Windows.Forms.Button
    Friend WithEvents btn从部件导入 As System.Windows.Forms.Button
    Friend WithEvents btn导入已打开文件 As System.Windows.Forms.Button
    Friend WithEvents lvw文件列表 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader文件名 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chk打印后关闭 As System.Windows.Forms.CheckBox
    Friend WithEvents cms右键菜单 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmi筛选移出 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi筛选保留 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi移出 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chk存为pdf As System.Windows.Forms.CheckBox
    Friend WithEvents chk存为dwg As System.Windows.Forms.CheckBox
    Friend WithEvents btn导入当前部件 As System.Windows.Forms.Button
    Friend WithEvents chk保存签字 As System.Windows.Forms.CheckBox
    Friend WithEvents chk刷新工程图 As System.Windows.Forms.CheckBox
    Friend WithEvents chk保存工程图 As System.Windows.Forms.CheckBox
    Friend WithEvents chk关闭窗口 As System.Windows.Forms.CheckBox
    Friend WithEvents btn保存配置 As System.Windows.Forms.Button

End Class
