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
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnAddFile = New System.Windows.Forms.Button()
        Me.btnClearList = New System.Windows.Forms.Button()
        Me.btnAddFolder = New System.Windows.Forms.Button()
        Me.lblsuggest = New System.Windows.Forms.Label()
        Me.grpOption = New System.Windows.Forms.GroupBox()
        Me.chkSaveSign = New System.Windows.Forms.CheckBox()
        Me.chkSaveAsDwg = New System.Windows.Forms.CheckBox()
        Me.chkSaveAsPdf = New System.Windows.Forms.CheckBox()
        Me.chkClose = New System.Windows.Forms.CheckBox()
        Me.lblCopies = New System.Windows.Forms.Label()
        Me.lblPrinter = New System.Windows.Forms.Label()
        Me.nudCopies = New System.Windows.Forms.NumericUpDown()
        Me.cmbPrinter = New System.Windows.Forms.ComboBox()
        Me.chkPaperA3 = New System.Windows.Forms.CheckBox()
        Me.chkSign = New System.Windows.Forms.CheckBox()
        Me.chkBlack = New System.Windows.Forms.CheckBox()
        Me.btnLoadAsm = New System.Windows.Forms.Button()
        Me.btnLoadIdw = New System.Windows.Forms.Button()
        Me.lvwFileListView = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmsRemove = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiRemove = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiRemoveFilter = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiSaveFilter = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnLoadActiveAsm = New System.Windows.Forms.Button()
        Me.grpOption.SuspendLayout()
        CType(Me.nudCopies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsRemove.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStart.Location = New System.Drawing.Point(785, 478)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(86, 28)
        Me.btnStart.TabIndex = 1
        Me.btnStart.TabStop = False
        Me.btnStart.Text = "开始打印"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(879, 478)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(57, 28)
        Me.btnClose.TabIndex = 1
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "关闭"
        '
        'btnAddFile
        '
        Me.btnAddFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddFile.Location = New System.Drawing.Point(116, 478)
        Me.btnAddFile.Name = "btnAddFile"
        Me.btnAddFile.Size = New System.Drawing.Size(85, 28)
        Me.btnAddFile.TabIndex = 1
        Me.btnAddFile.Text = "添加文件"
        Me.btnAddFile.UseVisualStyleBackColor = True
        '
        'btnClearList
        '
        Me.btnClearList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClearList.Location = New System.Drawing.Point(570, 478)
        Me.btnClearList.Name = "btnClearList"
        Me.btnClearList.Size = New System.Drawing.Size(85, 28)
        Me.btnClearList.TabIndex = 3
        Me.btnClearList.Text = "清除列表"
        Me.btnClearList.UseVisualStyleBackColor = True
        '
        'btnAddFolder
        '
        Me.btnAddFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddFolder.Location = New System.Drawing.Point(217, 478)
        Me.btnAddFolder.Name = "btnAddFolder"
        Me.btnAddFolder.Size = New System.Drawing.Size(85, 28)
        Me.btnAddFolder.TabIndex = 2
        Me.btnAddFolder.Text = "添加文件夹"
        Me.btnAddFolder.UseVisualStyleBackColor = True
        '
        'lblsuggest
        '
        Me.lblsuggest.BackColor = System.Drawing.SystemColors.Window
        Me.lblsuggest.Font = New System.Drawing.Font("宋体", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblsuggest.ForeColor = System.Drawing.Color.Red
        Me.lblsuggest.Location = New System.Drawing.Point(70, 159)
        Me.lblsuggest.Name = "lblsuggest"
        Me.lblsuggest.Size = New System.Drawing.Size(686, 49)
        Me.lblsuggest.TabIndex = 32
        Me.lblsuggest.Text = "建议打开模型提高程序加载工程图的效率！"
        '
        'grpOption
        '
        Me.grpOption.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpOption.Controls.Add(Me.chkSaveSign)
        Me.grpOption.Controls.Add(Me.chkSaveAsDwg)
        Me.grpOption.Controls.Add(Me.chkSaveAsPdf)
        Me.grpOption.Controls.Add(Me.chkClose)
        Me.grpOption.Controls.Add(Me.lblCopies)
        Me.grpOption.Controls.Add(Me.lblPrinter)
        Me.grpOption.Controls.Add(Me.nudCopies)
        Me.grpOption.Controls.Add(Me.cmbPrinter)
        Me.grpOption.Controls.Add(Me.chkPaperA3)
        Me.grpOption.Controls.Add(Me.chkSign)
        Me.grpOption.Controls.Add(Me.chkBlack)
        Me.grpOption.Location = New System.Drawing.Point(13, 410)
        Me.grpOption.Name = "grpOption"
        Me.grpOption.Size = New System.Drawing.Size(922, 60)
        Me.grpOption.TabIndex = 33
        Me.grpOption.TabStop = False
        Me.grpOption.Text = "选项"
        '
        'chkSaveSign
        '
        Me.chkSaveSign.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkSaveSign.AutoSize = True
        Me.chkSaveSign.Location = New System.Drawing.Point(482, 26)
        Me.chkSaveSign.Name = "chkSaveSign"
        Me.chkSaveSign.Size = New System.Drawing.Size(72, 16)
        Me.chkSaveSign.TabIndex = 43
        Me.chkSaveSign.Text = "保存签字"
        Me.chkSaveSign.UseVisualStyleBackColor = True
        '
        'chkSaveAsDwg
        '
        Me.chkSaveAsDwg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkSaveAsDwg.AutoSize = True
        Me.chkSaveAsDwg.Location = New System.Drawing.Point(815, 26)
        Me.chkSaveAsDwg.Name = "chkSaveAsDwg"
        Me.chkSaveAsDwg.Size = New System.Drawing.Size(90, 16)
        Me.chkSaveAsDwg.TabIndex = 42
        Me.chkSaveAsDwg.Text = "同步存为Dwg"
        Me.chkSaveAsDwg.UseVisualStyleBackColor = True
        '
        'chkSaveAsPdf
        '
        Me.chkSaveAsPdf.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkSaveAsPdf.AutoSize = True
        Me.chkSaveAsPdf.Location = New System.Drawing.Point(724, 26)
        Me.chkSaveAsPdf.Name = "chkSaveAsPdf"
        Me.chkSaveAsPdf.Size = New System.Drawing.Size(90, 16)
        Me.chkSaveAsPdf.TabIndex = 41
        Me.chkSaveAsPdf.Text = "同步存为Pdf"
        Me.chkSaveAsPdf.UseVisualStyleBackColor = True
        '
        'chkClose
        '
        Me.chkClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkClose.AutoSize = True
        Me.chkClose.Checked = True
        Me.chkClose.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkClose.Location = New System.Drawing.Point(632, 26)
        Me.chkClose.Name = "chkClose"
        Me.chkClose.Size = New System.Drawing.Size(84, 16)
        Me.chkClose.TabIndex = 39
        Me.chkClose.Text = "打印后关闭"
        Me.chkClose.UseVisualStyleBackColor = True
        '
        'lblCopies
        '
        Me.lblCopies.AutoSize = True
        Me.lblCopies.Location = New System.Drawing.Point(247, 25)
        Me.lblCopies.Name = "lblCopies"
        Me.lblCopies.Size = New System.Drawing.Size(29, 12)
        Me.lblCopies.TabIndex = 38
        Me.lblCopies.Text = "份数"
        '
        'lblPrinter
        '
        Me.lblPrinter.AutoSize = True
        Me.lblPrinter.Location = New System.Drawing.Point(14, 22)
        Me.lblPrinter.Name = "lblPrinter"
        Me.lblPrinter.Size = New System.Drawing.Size(41, 12)
        Me.lblPrinter.TabIndex = 37
        Me.lblPrinter.Text = "打印机"
        '
        'nudCopies
        '
        Me.nudCopies.Location = New System.Drawing.Point(285, 22)
        Me.nudCopies.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudCopies.Name = "nudCopies"
        Me.nudCopies.Size = New System.Drawing.Size(46, 21)
        Me.nudCopies.TabIndex = 36
        Me.nudCopies.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cmbPrinter
        '
        Me.cmbPrinter.FormattingEnabled = True
        Me.cmbPrinter.Location = New System.Drawing.Point(60, 21)
        Me.cmbPrinter.Name = "cmbPrinter"
        Me.cmbPrinter.Size = New System.Drawing.Size(174, 20)
        Me.cmbPrinter.Sorted = True
        Me.cmbPrinter.TabIndex = 35
        '
        'chkPaperA3
        '
        Me.chkPaperA3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPaperA3.AutoSize = True
        Me.chkPaperA3.Checked = True
        Me.chkPaperA3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPaperA3.Location = New System.Drawing.Point(558, 26)
        Me.chkPaperA3.Name = "chkPaperA3"
        Me.chkPaperA3.Size = New System.Drawing.Size(72, 16)
        Me.chkPaperA3.TabIndex = 34
        Me.chkPaperA3.Text = "匹配A3纸"
        Me.chkPaperA3.UseVisualStyleBackColor = True
        '
        'chkSign
        '
        Me.chkSign.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkSign.AutoSize = True
        Me.chkSign.Checked = True
        Me.chkSign.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSign.Location = New System.Drawing.Point(433, 26)
        Me.chkSign.Name = "chkSign"
        Me.chkSign.Size = New System.Drawing.Size(48, 16)
        Me.chkSign.TabIndex = 33
        Me.chkSign.Text = "签字"
        Me.chkSign.UseVisualStyleBackColor = True
        '
        'chkBlack
        '
        Me.chkBlack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkBlack.AutoSize = True
        Me.chkBlack.Checked = True
        Me.chkBlack.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBlack.Location = New System.Drawing.Point(349, 26)
        Me.chkBlack.Name = "chkBlack"
        Me.chkBlack.Size = New System.Drawing.Size(84, 16)
        Me.chkBlack.TabIndex = 32
        Me.chkBlack.Text = "打印为黑色"
        Me.chkBlack.UseVisualStyleBackColor = True
        '
        'btnLoadAsm
        '
        Me.btnLoadAsm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLoadAsm.Location = New System.Drawing.Point(15, 478)
        Me.btnLoadAsm.Name = "btnLoadAsm"
        Me.btnLoadAsm.Size = New System.Drawing.Size(85, 28)
        Me.btnLoadAsm.TabIndex = 0
        Me.btnLoadAsm.Text = "从部件导入"
        Me.btnLoadAsm.UseVisualStyleBackColor = True
        '
        'btnLoadIdw
        '
        Me.btnLoadIdw.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLoadIdw.Location = New System.Drawing.Point(444, 478)
        Me.btnLoadIdw.Name = "btnLoadIdw"
        Me.btnLoadIdw.Size = New System.Drawing.Size(110, 28)
        Me.btnLoadIdw.TabIndex = 34
        Me.btnLoadIdw.Text = "导入已打开文件"
        Me.btnLoadIdw.UseVisualStyleBackColor = True
        '
        'lvwFileListView
        '
        Me.lvwFileListView.AllowColumnReorder = True
        Me.lvwFileListView.AllowDrop = True
        Me.lvwFileListView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwFileListView.AutoArrange = False
        Me.lvwFileListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lvwFileListView.ContextMenuStrip = Me.cmsRemove
        Me.lvwFileListView.FullRowSelect = True
        Me.lvwFileListView.Location = New System.Drawing.Point(15, 11)
        Me.lvwFileListView.Name = "lvwFileListView"
        Me.lvwFileListView.Size = New System.Drawing.Size(922, 390)
        Me.lvwFileListView.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvwFileListView.TabIndex = 36
        Me.lvwFileListView.UseCompatibleStateImageBehavior = False
        Me.lvwFileListView.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "文件名(双击打开)"
        Me.ColumnHeader1.Width = 978
        '
        'cmsRemove
        '
        Me.cmsRemove.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiRemove, Me.tsmiRemoveFilter, Me.tsmiSaveFilter})
        Me.cmsRemove.Name = "cmsRemove"
        Me.cmsRemove.Size = New System.Drawing.Size(125, 70)
        '
        'tsmiRemove
        '
        Me.tsmiRemove.Name = "tsmiRemove"
        Me.tsmiRemove.Size = New System.Drawing.Size(124, 22)
        Me.tsmiRemove.Text = "移除"
        '
        'tsmiRemoveFilter
        '
        Me.tsmiRemoveFilter.Name = "tsmiRemoveFilter"
        Me.tsmiRemoveFilter.Size = New System.Drawing.Size(124, 22)
        Me.tsmiRemoveFilter.Text = "筛选移除"
        '
        'tsmiSaveFilter
        '
        Me.tsmiSaveFilter.Name = "tsmiSaveFilter"
        Me.tsmiSaveFilter.Size = New System.Drawing.Size(124, 22)
        Me.tsmiSaveFilter.Text = "筛选保留"
        '
        'btnLoadActiveAsm
        '
        Me.btnLoadActiveAsm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLoadActiveAsm.Location = New System.Drawing.Point(318, 478)
        Me.btnLoadActiveAsm.Name = "btnLoadActiveAsm"
        Me.btnLoadActiveAsm.Size = New System.Drawing.Size(110, 28)
        Me.btnLoadActiveAsm.TabIndex = 37
        Me.btnLoadActiveAsm.Text = "导入当前部件"
        Me.btnLoadActiveAsm.UseVisualStyleBackColor = True
        '
        'frmPrint
        '
        Me.AcceptButton = Me.btnLoadIdw
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(950, 515)
        Me.Controls.Add(Me.btnLoadActiveAsm)
        Me.Controls.Add(Me.btnLoadIdw)
        Me.Controls.Add(Me.btnLoadAsm)
        Me.Controls.Add(Me.grpOption)
        Me.Controls.Add(Me.lblsuggest)
        Me.Controls.Add(Me.btnAddFolder)
        Me.Controls.Add(Me.btnClearList)
        Me.Controls.Add(Me.btnAddFile)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.lvwFileListView)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmPrint"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "批量打印"
        Me.grpOption.ResumeLayout(False)
        Me.grpOption.PerformLayout()
        CType(Me.nudCopies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsRemove.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnClearList As System.Windows.Forms.Button
    Friend WithEvents btnAddFolder As System.Windows.Forms.Button
    Friend WithEvents lblsuggest As System.Windows.Forms.Label
    Friend WithEvents grpOption As System.Windows.Forms.GroupBox
    Friend WithEvents cmbPrinter As System.Windows.Forms.ComboBox
    Friend WithEvents chkPaperA3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkSign As System.Windows.Forms.CheckBox
    Friend WithEvents chkBlack As System.Windows.Forms.CheckBox
    Friend WithEvents nudCopies As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblCopies As System.Windows.Forms.Label
    Friend WithEvents lblPrinter As System.Windows.Forms.Label
    Friend WithEvents btnAddFile As System.Windows.Forms.Button
    Friend WithEvents btnLoadAsm As System.Windows.Forms.Button
    Friend WithEvents btnLoadIdw As System.Windows.Forms.Button
    Friend WithEvents lvwFileListView As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chkClose As System.Windows.Forms.CheckBox
    Friend WithEvents cmsRemove As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiRemoveFilter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiSaveFilter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiRemove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkSaveAsPdf As System.Windows.Forms.CheckBox
    Friend WithEvents chkSaveAsDwg As System.Windows.Forms.CheckBox
    Friend WithEvents btnLoadActiveAsm As System.Windows.Forms.Button
    Friend WithEvents chkSaveSign As System.Windows.Forms.CheckBox

End Class
