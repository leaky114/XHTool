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
        Me.lstFileList = New System.Windows.Forms.ListBox()
        Me.btnAddFile = New System.Windows.Forms.Button()
        Me.btnClearList = New System.Windows.Forms.Button()
        Me.btnAddFolder = New System.Windows.Forms.Button()
        Me.chkDwg = New System.Windows.Forms.CheckBox()
        Me.chkPdf = New System.Windows.Forms.CheckBox()
        Me.chkPic = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStart.Location = New System.Drawing.Point(232, 349)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(57, 33)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "开始"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(295, 349)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(57, 33)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "关闭"
        '
        'lstFileList
        '
        Me.lstFileList.FormattingEnabled = True
        Me.lstFileList.HorizontalScrollbar = True
        Me.lstFileList.ItemHeight = 12
        Me.lstFileList.Location = New System.Drawing.Point(12, 10)
        Me.lstFileList.Name = "lstFileList"
        Me.lstFileList.Size = New System.Drawing.Size(340, 304)
        Me.lstFileList.TabIndex = 15
        '
        'btnAddFile
        '
        Me.btnAddFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddFile.Location = New System.Drawing.Point(9, 349)
        Me.btnAddFile.Name = "btnAddFile"
        Me.btnAddFile.Size = New System.Drawing.Size(69, 33)
        Me.btnAddFile.TabIndex = 0
        Me.btnAddFile.Text = "添加文件"
        Me.btnAddFile.UseVisualStyleBackColor = True
        '
        'btnClearList
        '
        Me.btnClearList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClearList.Location = New System.Drawing.Point(161, 349)
        Me.btnClearList.Name = "btnClearList"
        Me.btnClearList.Size = New System.Drawing.Size(69, 33)
        Me.btnClearList.TabIndex = 20
        Me.btnClearList.Text = "清除列表"
        Me.btnClearList.UseVisualStyleBackColor = True
        '
        'btnAddFolder
        '
        Me.btnAddFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddFolder.Location = New System.Drawing.Point(79, 349)
        Me.btnAddFolder.Name = "btnAddFolder"
        Me.btnAddFolder.Size = New System.Drawing.Size(81, 33)
        Me.btnAddFolder.TabIndex = 21
        Me.btnAddFolder.Text = "添加文件夹"
        Me.btnAddFolder.UseVisualStyleBackColor = True
        '
        'chkDwg
        '
        Me.chkDwg.AutoSize = True
        Me.chkDwg.Location = New System.Drawing.Point(21, 321)
        Me.chkDwg.Name = "chkDwg"
        Me.chkDwg.Size = New System.Drawing.Size(90, 16)
        Me.chkDwg.TabIndex = 22
        Me.chkDwg.Text = "AutoCAD.dwg"
        Me.chkDwg.UseVisualStyleBackColor = True
        '
        'chkPdf
        '
        Me.chkPdf.AutoSize = True
        Me.chkPdf.Location = New System.Drawing.Point(136, 321)
        Me.chkPdf.Name = "chkPdf"
        Me.chkPdf.Size = New System.Drawing.Size(78, 16)
        Me.chkPdf.TabIndex = 23
        Me.chkPdf.Text = "Adobe.pdf"
        Me.chkPdf.UseVisualStyleBackColor = True
        '
        'chkPic
        '
        Me.chkPic.AutoSize = True
        Me.chkPic.Enabled = False
        Me.chkPic.Location = New System.Drawing.Point(232, 321)
        Me.chkPic.Name = "chkPic"
        Me.chkPic.Size = New System.Drawing.Size(72, 16)
        Me.chkPic.TabIndex = 24
        Me.chkPic.Text = "图片.jpg"
        Me.chkPic.UseVisualStyleBackColor = True
        '
        'frmSaveAs
        '
        Me.AcceptButton = Me.btnStart
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(364, 391)
        Me.Controls.Add(Me.chkPic)
        Me.Controls.Add(Me.chkPdf)
        Me.Controls.Add(Me.chkDwg)
        Me.Controls.Add(Me.btnAddFolder)
        Me.Controls.Add(Me.btnClearList)
        Me.Controls.Add(Me.btnAddFile)
        Me.Controls.Add(Me.lstFileList)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnStart)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSaveAs"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "工程图批量另存"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lstFileList As System.Windows.Forms.ListBox
    Friend WithEvents btnAddFile As System.Windows.Forms.Button
    Friend WithEvents btnClearList As System.Windows.Forms.Button
    Friend WithEvents btnAddFolder As System.Windows.Forms.Button
    Friend WithEvents chkDwg As System.Windows.Forms.CheckBox
    Friend WithEvents chkPdf As System.Windows.Forms.CheckBox
    Friend WithEvents chkPic As System.Windows.Forms.CheckBox

End Class
