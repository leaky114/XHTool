<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormiPropertyToFileName
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lvw文件列表 = New System.Windows.Forms.ListView()
        Me.ch文件名 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch图号 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch名称 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch新文件名 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch文件路径 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.btn确定新文件名 = New System.Windows.Forms.Button()
        Me.btn开始 = New System.Windows.Forms.Button()
        Me.btn导入BOM = New System.Windows.Forms.Button()
        Me.btn导出BOM = New System.Windows.Forms.Button()
        Me.lbl名称 = New System.Windows.Forms.Label()
        Me.btn交换 = New System.Windows.Forms.Button()
        Me.txt文件名 = New System.Windows.Forms.TextBox()
        Me.txt图号 = New System.Windows.Forms.TextBox()
        Me.lbl图号 = New System.Windows.Forms.Label()
        Me.加载BOM = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lvw文件列表
        '
        Me.lvw文件列表.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvw文件列表.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ch文件名, Me.ch图号, Me.ch名称, Me.ch新文件名, Me.ch文件路径})
        Me.lvw文件列表.FullRowSelect = True
        Me.lvw文件列表.HideSelection = False
        Me.lvw文件列表.Location = New System.Drawing.Point(12, 12)
        Me.lvw文件列表.MultiSelect = False
        Me.lvw文件列表.Name = "lvw文件列表"
        Me.lvw文件列表.Size = New System.Drawing.Size(804, 381)
        Me.lvw文件列表.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvw文件列表.TabIndex = 8
        Me.lvw文件列表.TabStop = False
        Me.lvw文件列表.UseCompatibleStateImageBehavior = False
        Me.lvw文件列表.View = System.Windows.Forms.View.Details
        '
        'ch文件名
        '
        Me.ch文件名.Text = "文件名"
        Me.ch文件名.Width = 200
        '
        'ch图号
        '
        Me.ch图号.Text = "图号"
        Me.ch图号.Width = 120
        '
        'ch名称
        '
        Me.ch名称.Text = "名称"
        Me.ch名称.Width = 120
        '
        'ch新文件名
        '
        Me.ch新文件名.Text = "新文件名"
        Me.ch新文件名.Width = 200
        '
        'ch文件路径
        '
        Me.ch文件路径.Text = "文件路径(双击打开)"
        Me.ch文件路径.Width = 300
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.AutoSize = True
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(747, 434)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(69, 28)
        Me.btn关闭.TabIndex = 9
        Me.btn关闭.Text = "关闭"
        '
        'btn确定新文件名
        '
        Me.btn确定新文件名.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn确定新文件名.Location = New System.Drawing.Point(445, 398)
        Me.btn确定新文件名.Name = "btn确定新文件名"
        Me.btn确定新文件名.Size = New System.Drawing.Size(26, 26)
        Me.btn确定新文件名.TabIndex = 30
        Me.btn确定新文件名.UseVisualStyleBackColor = True
        '
        'btn开始
        '
        Me.btn开始.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn开始.Location = New System.Drawing.Point(676, 434)
        Me.btn开始.Name = "btn开始"
        Me.btn开始.Size = New System.Drawing.Size(65, 28)
        Me.btn开始.TabIndex = 32
        Me.btn开始.Text = "开始"
        '
        'btn导入BOM
        '
        Me.btn导入BOM.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn导入BOM.Location = New System.Drawing.Point(172, 434)
        Me.btn导入BOM.Name = "btn导入BOM"
        Me.btn导入BOM.Size = New System.Drawing.Size(65, 28)
        Me.btn导入BOM.TabIndex = 34
        Me.btn导入BOM.TabStop = False
        Me.btn导入BOM.Text = "导入BOM"
        Me.btn导入BOM.UseVisualStyleBackColor = True
        '
        'btn导出BOM
        '
        Me.btn导出BOM.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn导出BOM.Location = New System.Drawing.Point(96, 434)
        Me.btn导出BOM.Name = "btn导出BOM"
        Me.btn导出BOM.Size = New System.Drawing.Size(65, 28)
        Me.btn导出BOM.TabIndex = 33
        Me.btn导出BOM.TabStop = False
        Me.btn导出BOM.Text = "导出BOM"
        Me.btn导出BOM.UseVisualStyleBackColor = True
        '
        'lbl名称
        '
        Me.lbl名称.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl名称.AutoSize = True
        Me.lbl名称.Location = New System.Drawing.Point(275, 405)
        Me.lbl名称.Name = "lbl名称"
        Me.lbl名称.Size = New System.Drawing.Size(41, 12)
        Me.lbl名称.TabIndex = 39
        Me.lbl名称.Text = "名称："
        '
        'btn交换
        '
        Me.btn交换.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn交换.Location = New System.Drawing.Point(239, 398)
        Me.btn交换.Name = "btn交换"
        Me.btn交换.Size = New System.Drawing.Size(26, 26)
        Me.btn交换.TabIndex = 38
        Me.btn交换.UseVisualStyleBackColor = True
        '
        'txt文件名
        '
        Me.txt文件名.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt文件名.Location = New System.Drawing.Point(323, 401)
        Me.txt文件名.Name = "txt文件名"
        Me.txt文件名.Size = New System.Drawing.Size(116, 21)
        Me.txt文件名.TabIndex = 42
        '
        'txt图号
        '
        Me.txt图号.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt图号.Location = New System.Drawing.Point(65, 401)
        Me.txt图号.Name = "txt图号"
        Me.txt图号.Size = New System.Drawing.Size(168, 21)
        Me.txt图号.TabIndex = 43
        '
        'lbl图号
        '
        Me.lbl图号.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl图号.AutoSize = True
        Me.lbl图号.Location = New System.Drawing.Point(18, 405)
        Me.lbl图号.Name = "lbl图号"
        Me.lbl图号.Size = New System.Drawing.Size(41, 12)
        Me.lbl图号.TabIndex = 37
        Me.lbl图号.Text = "图号："
        '
        '加载BOM
        '
        Me.加载BOM.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.加载BOM.Location = New System.Drawing.Point(20, 434)
        Me.加载BOM.Name = "加载BOM"
        Me.加载BOM.Size = New System.Drawing.Size(65, 28)
        Me.加载BOM.TabIndex = 41
        Me.加载BOM.TabStop = False
        Me.加载BOM.Text = "加载BOM"
        Me.加载BOM.UseVisualStyleBackColor = True
        '
        'FormiPropertyToFileName
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(828, 471)
        Me.Controls.Add(Me.加载BOM)
        Me.Controls.Add(Me.lbl名称)
        Me.Controls.Add(Me.btn交换)
        Me.Controls.Add(Me.txt文件名)
        Me.Controls.Add(Me.txt图号)
        Me.Controls.Add(Me.lbl图号)
        Me.Controls.Add(Me.btn导入BOM)
        Me.Controls.Add(Me.btn导出BOM)
        Me.Controls.Add(Me.btn开始)
        Me.Controls.Add(Me.btn确定新文件名)
        Me.Controls.Add(Me.btn关闭)
        Me.Controls.Add(Me.lvw文件列表)
        Me.Name = "FormiPropertyToFileName"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "iProperty重命名"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvw文件列表 As New System.Windows.Forms.ListView
    Friend WithEvents ch文件名 As New System.Windows.Forms.ColumnHeader
    Friend WithEvents ch图号 As New System.Windows.Forms.ColumnHeader
    Friend WithEvents ch名称 As New System.Windows.Forms.ColumnHeader
    Friend WithEvents ch新文件名 As New System.Windows.Forms.ColumnHeader
    Friend WithEvents ch文件路径 As New System.Windows.Forms.ColumnHeader
    Friend WithEvents btn关闭 As New System.Windows.Forms.Button
    Friend WithEvents btn确定新文件名 As New System.Windows.Forms.Button
    Friend WithEvents btn开始 As New System.Windows.Forms.Button
    Friend WithEvents btn导入BOM As New System.Windows.Forms.Button
    Friend WithEvents btn导出BOM As New System.Windows.Forms.Button
    Friend WithEvents lbl名称 As New System.Windows.Forms.Label
    Friend WithEvents btn交换 As New System.Windows.Forms.Button
    Friend WithEvents lbl图号 As New System.Windows.Forms.Label
    Friend WithEvents 加载BOM As New System.Windows.Forms.Button
    Friend WithEvents txt文件名 As Windows.Forms.TextBox
    Friend WithEvents txt图号 As Windows.Forms.TextBox
End Class
