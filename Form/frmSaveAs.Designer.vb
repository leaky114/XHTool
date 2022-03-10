<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSaveAs
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
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnAddFile = New System.Windows.Forms.Button()
        Me.btnClearList = New System.Windows.Forms.Button()
        Me.btnAddFolder = New System.Windows.Forms.Button()
        Me.chkDwg = New System.Windows.Forms.CheckBox()
        Me.chkPdf = New System.Windows.Forms.CheckBox()
        Me.chkPic = New System.Windows.Forms.CheckBox()
        Me.txtString = New System.Windows.Forms.TextBox()
        Me.rdoSameFolder = New System.Windows.Forms.RadioButton()
        Me.rdoLocal = New System.Windows.Forms.RadioButton()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnOpenFolder = New System.Windows.Forms.Button()
        Me.lvwFileListView = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout
        '
        'btnStart
        '
        Me.btnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnStart.Location = New System.Drawing.Point(385, 298)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(57, 28)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "开始"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(448, 298)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(57, 28)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "关闭"
        '
        'btnAddFile
        '
        Me.btnAddFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnAddFile.Location = New System.Drawing.Point(23, 298)
        Me.btnAddFile.Name = "btnAddFile"
        Me.btnAddFile.Size = New System.Drawing.Size(69, 28)
        Me.btnAddFile.TabIndex = 0
        Me.btnAddFile.Text = "添加文件"
        Me.btnAddFile.UseVisualStyleBackColor = true
        '
        'btnClearList
        '
        Me.btnClearList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnClearList.Location = New System.Drawing.Point(189, 298)
        Me.btnClearList.Name = "btnClearList"
        Me.btnClearList.Size = New System.Drawing.Size(69, 28)
        Me.btnClearList.TabIndex = 20
        Me.btnClearList.Text = "清除列表"
        Me.btnClearList.UseVisualStyleBackColor = true
        '
        'btnAddFolder
        '
        Me.btnAddFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnAddFolder.Location = New System.Drawing.Point(100, 298)
        Me.btnAddFolder.Name = "btnAddFolder"
        Me.btnAddFolder.Size = New System.Drawing.Size(81, 28)
        Me.btnAddFolder.TabIndex = 21
        Me.btnAddFolder.Text = "添加文件夹"
        Me.btnAddFolder.UseVisualStyleBackColor = true
        '
        'chkDwg
        '
        Me.chkDwg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.chkDwg.AutoSize = true
        Me.chkDwg.Location = New System.Drawing.Point(20, 245)
        Me.chkDwg.Name = "chkDwg"
        Me.chkDwg.Size = New System.Drawing.Size(90, 16)
        Me.chkDwg.TabIndex = 22
        Me.chkDwg.Text = "AutoCAD.dwg"
        Me.chkDwg.UseVisualStyleBackColor = true
        '
        'chkPdf
        '
        Me.chkPdf.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.chkPdf.AutoSize = true
        Me.chkPdf.Location = New System.Drawing.Point(135, 245)
        Me.chkPdf.Name = "chkPdf"
        Me.chkPdf.Size = New System.Drawing.Size(78, 16)
        Me.chkPdf.TabIndex = 23
        Me.chkPdf.Text = "Adobe.pdf"
        Me.chkPdf.UseVisualStyleBackColor = true
        '
        'chkPic
        '
        Me.chkPic.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.chkPic.AutoSize = true
        Me.chkPic.Enabled = false
        Me.chkPic.Location = New System.Drawing.Point(231, 245)
        Me.chkPic.Name = "chkPic"
        Me.chkPic.Size = New System.Drawing.Size(72, 16)
        Me.chkPic.TabIndex = 24
        Me.chkPic.Text = "图片.jpg"
        Me.chkPic.UseVisualStyleBackColor = true
        Me.chkPic.Visible = false
        '
        'txtString
        '
        Me.txtString.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.txtString.Location = New System.Drawing.Point(20, 267)
        Me.txtString.Name = "txtString"
        Me.txtString.Size = New System.Drawing.Size(445, 21)
        Me.txtString.TabIndex = 29
        '
        'rdoSameFolder
        '
        Me.rdoSameFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.rdoSameFolder.AutoSize = true
        Me.rdoSameFolder.Location = New System.Drawing.Point(416, 245)
        Me.rdoSameFolder.Name = "rdoSameFolder"
        Me.rdoSameFolder.Size = New System.Drawing.Size(95, 16)
        Me.rdoSameFolder.TabIndex = 28
        Me.rdoSameFolder.Text = "同一个文件夹"
        Me.rdoSameFolder.UseVisualStyleBackColor = true
        '
        'rdoLocal
        '
        Me.rdoLocal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.rdoLocal.AutoSize = true
        Me.rdoLocal.Checked = true
        Me.rdoLocal.Location = New System.Drawing.Point(318, 245)
        Me.rdoLocal.Name = "rdoLocal"
        Me.rdoLocal.Size = New System.Drawing.Size(83, 16)
        Me.rdoLocal.TabIndex = 27
        Me.rdoLocal.TabStop = true
        Me.rdoLocal.Text = "当前文件夹"
        Me.rdoLocal.UseVisualStyleBackColor = true
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnRemove.Location = New System.Drawing.Point(266, 298)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(69, 28)
        Me.btnRemove.TabIndex = 30
        Me.btnRemove.Text = "移除"
        Me.btnRemove.UseVisualStyleBackColor = true
        '
        'btnOpenFolder
        '
        Me.btnOpenFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnOpenFolder.Location = New System.Drawing.Point(471, 267)
        Me.btnOpenFolder.Name = "btnOpenFolder"
        Me.btnOpenFolder.Size = New System.Drawing.Size(34, 21)
        Me.btnOpenFolder.TabIndex = 31
        Me.btnOpenFolder.Text = "..."
        Me.btnOpenFolder.UseVisualStyleBackColor = true
        '
        'lvwFileListView
        '
        Me.lvwFileListView.AllowColumnReorder = true
        Me.lvwFileListView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lvwFileListView.AutoArrange = false
        Me.lvwFileListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lvwFileListView.FullRowSelect = true
        Me.lvwFileListView.Location = New System.Drawing.Point(12, 12)
        Me.lvwFileListView.Name = "lvwFileListView"
        Me.lvwFileListView.Size = New System.Drawing.Size(493, 217)
        Me.lvwFileListView.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvwFileListView.TabIndex = 37
        Me.lvwFileListView.UseCompatibleStateImageBehavior = false
        Me.lvwFileListView.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "文件名"
        Me.ColumnHeader1.Width = 650
        '
        'frmSaveAs
        '
        Me.AcceptButton = Me.btnStart
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 12!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(517, 340)
        Me.Controls.Add(Me.lvwFileListView)
        Me.Controls.Add(Me.btnOpenFolder)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.txtString)
        Me.Controls.Add(Me.rdoSameFolder)
        Me.Controls.Add(Me.rdoLocal)
        Me.Controls.Add(Me.chkPic)
        Me.Controls.Add(Me.chkPdf)
        Me.Controls.Add(Me.chkDwg)
        Me.Controls.Add(Me.btnAddFolder)
        Me.Controls.Add(Me.btnClearList)
        Me.Controls.Add(Me.btnAddFile)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnStart)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmSaveAs"
        Me.ShowIcon = false
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "工程图批量另存"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnAddFile As System.Windows.Forms.Button
    Friend WithEvents btnClearList As System.Windows.Forms.Button
    Friend WithEvents btnAddFolder As System.Windows.Forms.Button
    Friend WithEvents chkDwg As System.Windows.Forms.CheckBox
    Friend WithEvents chkPdf As System.Windows.Forms.CheckBox
    Friend WithEvents chkPic As System.Windows.Forms.CheckBox
    Friend WithEvents txtString As System.Windows.Forms.TextBox
    Friend WithEvents rdoSameFolder As System.Windows.Forms.RadioButton
    Friend WithEvents rdoLocal As System.Windows.Forms.RadioButton
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnOpenFolder As System.Windows.Forms.Button
    Friend WithEvents lvwFileListView As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader

End Class
