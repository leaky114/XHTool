<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSaveAs
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn确定 = New System.Windows.Forms.Button()
        Me.btn关闭 = New System.Windows.Forms.Button()
        Me.btn添加文件 = New System.Windows.Forms.Button()
        Me.btn清空列表 = New System.Windows.Forms.Button()
        Me.btn添加文件夹 = New System.Windows.Forms.Button()
        Me.chkDwg = New System.Windows.Forms.CheckBox()
        Me.chkPdf = New System.Windows.Forms.CheckBox()
        Me.chkStep = New System.Windows.Forms.CheckBox()
        Me.txt文件夹路径 = New System.Windows.Forms.TextBox()
        Me.rdo同一文件夹 = New System.Windows.Forms.RadioButton()
        Me.rdo当前文件夹 = New System.Windows.Forms.RadioButton()
        Me.btn移出 = New System.Windows.Forms.Button()
        Me.btn设置文件夹 = New System.Windows.Forms.Button()
        Me.lvw文件列表 = New System.Windows.Forms.ListView()
        Me.ColumnHeader文件名 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'btn确定
        '
        Me.btn确定.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn确定.Location = New System.Drawing.Point(385, 298)
        Me.btn确定.Name = "btn确定"
        Me.btn确定.Size = New System.Drawing.Size(57, 28)
        Me.btn确定.TabIndex = 10
        Me.btn确定.Text = "确定"
        '
        'btn关闭
        '
        Me.btn关闭.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn关闭.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn关闭.Location = New System.Drawing.Point(448, 298)
        Me.btn关闭.Name = "btn关闭"
        Me.btn关闭.Size = New System.Drawing.Size(57, 28)
        Me.btn关闭.TabIndex = 11
        Me.btn关闭.Text = "关闭"
        '
        'btn添加文件
        '
        Me.btn添加文件.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn添加文件.Location = New System.Drawing.Point(23, 298)
        Me.btn添加文件.Name = "btn添加文件"
        Me.btn添加文件.Size = New System.Drawing.Size(69, 28)
        Me.btn添加文件.TabIndex = 6
        Me.btn添加文件.Text = "添加文件"
        Me.btn添加文件.UseVisualStyleBackColor = True
        '
        'btn清空列表
        '
        Me.btn清空列表.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn清空列表.Location = New System.Drawing.Point(189, 298)
        Me.btn清空列表.Name = "btn清空列表"
        Me.btn清空列表.Size = New System.Drawing.Size(69, 28)
        Me.btn清空列表.TabIndex = 8
        Me.btn清空列表.Text = "清空列表"
        Me.btn清空列表.UseVisualStyleBackColor = True
        '
        'btn添加文件夹
        '
        Me.btn添加文件夹.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn添加文件夹.Location = New System.Drawing.Point(100, 298)
        Me.btn添加文件夹.Name = "btn添加文件夹"
        Me.btn添加文件夹.Size = New System.Drawing.Size(81, 28)
        Me.btn添加文件夹.TabIndex = 7
        Me.btn添加文件夹.Text = "添加文件夹"
        Me.btn添加文件夹.UseVisualStyleBackColor = True
        '
        'chkDwg
        '
        Me.chkDwg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkDwg.AutoSize = True
        Me.chkDwg.Checked = True
        Me.chkDwg.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDwg.Location = New System.Drawing.Point(20, 245)
        Me.chkDwg.Name = "chkDwg"
        Me.chkDwg.Size = New System.Drawing.Size(90, 16)
        Me.chkDwg.TabIndex = 0
        Me.chkDwg.Text = "AutoCAD.dwg"
        Me.chkDwg.UseVisualStyleBackColor = True
        '
        'chkPdf
        '
        Me.chkPdf.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPdf.AutoSize = True
        Me.chkPdf.Location = New System.Drawing.Point(135, 245)
        Me.chkPdf.Name = "chkPdf"
        Me.chkPdf.Size = New System.Drawing.Size(78, 16)
        Me.chkPdf.TabIndex = 1
        Me.chkPdf.Text = "Adobe.pdf"
        Me.chkPdf.UseVisualStyleBackColor = True
        '
        'chkStep
        '
        Me.chkStep.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkStep.AutoSize = True
        Me.chkStep.Location = New System.Drawing.Point(231, 245)
        Me.chkStep.Name = "chkStep"
        Me.chkStep.Size = New System.Drawing.Size(72, 16)
        Me.chkStep.TabIndex = 2
        Me.chkStep.Text = "Step文件"
        Me.chkStep.UseVisualStyleBackColor = True
        '
        'txt文件夹路径
        '
        Me.txt文件夹路径.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt文件夹路径.Location = New System.Drawing.Point(20, 267)
        Me.txt文件夹路径.Name = "txt文件夹路径"
        Me.txt文件夹路径.ReadOnly = True
        Me.txt文件夹路径.Size = New System.Drawing.Size(445, 21)
        Me.txt文件夹路径.TabIndex = 29
        Me.txt文件夹路径.TabStop = False
        '
        'rdo同一文件夹
        '
        Me.rdo同一文件夹.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rdo同一文件夹.AutoSize = True
        Me.rdo同一文件夹.Location = New System.Drawing.Point(416, 245)
        Me.rdo同一文件夹.Name = "rdo同一文件夹"
        Me.rdo同一文件夹.Size = New System.Drawing.Size(95, 16)
        Me.rdo同一文件夹.TabIndex = 4
        Me.rdo同一文件夹.Text = "同一个文件夹"
        Me.rdo同一文件夹.UseVisualStyleBackColor = True
        '
        'rdo当前文件夹
        '
        Me.rdo当前文件夹.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rdo当前文件夹.AutoSize = True
        Me.rdo当前文件夹.Checked = True
        Me.rdo当前文件夹.Location = New System.Drawing.Point(318, 245)
        Me.rdo当前文件夹.Name = "rdo当前文件夹"
        Me.rdo当前文件夹.Size = New System.Drawing.Size(83, 16)
        Me.rdo当前文件夹.TabIndex = 3
        Me.rdo当前文件夹.TabStop = True
        Me.rdo当前文件夹.Text = "当前文件夹"
        Me.rdo当前文件夹.UseVisualStyleBackColor = True
        '
        'btn移出
        '
        Me.btn移出.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn移出.Location = New System.Drawing.Point(266, 298)
        Me.btn移出.Name = "btn移出"
        Me.btn移出.Size = New System.Drawing.Size(69, 28)
        Me.btn移出.TabIndex = 9
        Me.btn移出.Text = "移除"
        Me.btn移出.UseVisualStyleBackColor = True
        '
        'btn设置文件夹
        '
        Me.btn设置文件夹.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn设置文件夹.Location = New System.Drawing.Point(471, 264)
        Me.btn设置文件夹.Name = "btn设置文件夹"
        Me.btn设置文件夹.Size = New System.Drawing.Size(26, 26)
        Me.btn设置文件夹.TabIndex = 5
        Me.btn设置文件夹.UseVisualStyleBackColor = True
        '
        'lvw文件列表
        '
        Me.lvw文件列表.AllowColumnReorder = True
        Me.lvw文件列表.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvw文件列表.AutoArrange = False
        Me.lvw文件列表.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader文件名})
        Me.lvw文件列表.FullRowSelect = True
        Me.lvw文件列表.Location = New System.Drawing.Point(12, 12)
        Me.lvw文件列表.Name = "lvw文件列表"
        Me.lvw文件列表.Size = New System.Drawing.Size(493, 217)
        Me.lvw文件列表.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvw文件列表.TabIndex = 37
        Me.lvw文件列表.UseCompatibleStateImageBehavior = False
        Me.lvw文件列表.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader文件名
        '
        Me.ColumnHeader文件名.Text = "文件名"
        Me.ColumnHeader文件名.Width = 650
        '
        'frmSaveAs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn关闭
        Me.ClientSize = New System.Drawing.Size(517, 340)
        Me.Controls.Add(Me.lvw文件列表)
        Me.Controls.Add(Me.btn设置文件夹)
        Me.Controls.Add(Me.btn移出)
        Me.Controls.Add(Me.txt文件夹路径)
        Me.Controls.Add(Me.rdo同一文件夹)
        Me.Controls.Add(Me.rdo当前文件夹)
        Me.Controls.Add(Me.chkStep)
        Me.Controls.Add(Me.chkPdf)
        Me.Controls.Add(Me.chkDwg)
        Me.Controls.Add(Me.btn添加文件夹)
        Me.Controls.Add(Me.btn清空列表)
        Me.Controls.Add(Me.btn添加文件)
        Me.Controls.Add(Me.btn关闭)
        Me.Controls.Add(Me.btn确定)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSaveAs"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "批量另存"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn确定 As System.Windows.Forms.Button
    Friend WithEvents btn关闭 As System.Windows.Forms.Button
    Friend WithEvents btn添加文件 As System.Windows.Forms.Button
    Friend WithEvents btn清空列表 As System.Windows.Forms.Button
    Friend WithEvents btn添加文件夹 As System.Windows.Forms.Button
    Friend WithEvents chkDwg As System.Windows.Forms.CheckBox
    Friend WithEvents chkPdf As System.Windows.Forms.CheckBox
    Friend WithEvents chkStep As System.Windows.Forms.CheckBox
    Friend WithEvents txt文件夹路径 As System.Windows.Forms.TextBox
    Friend WithEvents rdo同一文件夹 As System.Windows.Forms.RadioButton
    Friend WithEvents rdo当前文件夹 As System.Windows.Forms.RadioButton
    Friend WithEvents btn移出 As System.Windows.Forms.Button
    Friend WithEvents btn设置文件夹 As System.Windows.Forms.Button
    Friend WithEvents lvw文件列表 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader文件名 As System.Windows.Forms.ColumnHeader

End Class
