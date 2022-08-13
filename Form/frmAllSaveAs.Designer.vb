<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAllSaveAs
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
        Me.chkfwg = New System.Windows.Forms.CheckBox()
        Me.chkpdf = New System.Windows.Forms.CheckBox()
        Me.btnAddFolder = New System.Windows.Forms.Button()
        Me.rdoLocal = New System.Windows.Forms.RadioButton()
        Me.rdoSameFolder = New System.Windows.Forms.RadioButton()
        Me.txtString = New System.Windows.Forms.TextBox()
        Me.chkCloseFile = New System.Windows.Forms.CheckBox()
        Me.lstFileList = New System.Windows.Forms.ListBox()
        Me.chkSaveFile = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStart.Location = New System.Drawing.Point(305, 92)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(90, 28)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "开始"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(403, 92)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(90, 28)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "关闭"
        '
        'chkfwg
        '
        Me.chkfwg.AutoSize = True
        Me.chkfwg.Location = New System.Drawing.Point(23, 12)
        Me.chkfwg.Name = "chkfwg"
        Me.chkfwg.Size = New System.Drawing.Size(90, 16)
        Me.chkfwg.TabIndex = 22
        Me.chkfwg.Text = "AutoCAD.dwg"
        Me.chkfwg.UseVisualStyleBackColor = True
        '
        'chkpdf
        '
        Me.chkpdf.AutoSize = True
        Me.chkpdf.Location = New System.Drawing.Point(186, 12)
        Me.chkpdf.Name = "chkpdf"
        Me.chkpdf.Size = New System.Drawing.Size(78, 16)
        Me.chkpdf.TabIndex = 23
        Me.chkpdf.Text = "Adobe.pdf"
        Me.chkpdf.UseVisualStyleBackColor = True
        '
        'btnAddFolder
        '
        Me.btnAddFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddFolder.Location = New System.Drawing.Point(8, 92)
        Me.btnAddFolder.Name = "btnAddFolder"
        Me.btnAddFolder.Size = New System.Drawing.Size(90, 28)
        Me.btnAddFolder.TabIndex = 21
        Me.btnAddFolder.Text = "添加文件夹"
        Me.btnAddFolder.UseVisualStyleBackColor = True
        Me.btnAddFolder.Visible = False
        '
        'rdoLocal
        '
        Me.rdoLocal.AutoSize = True
        Me.rdoLocal.Checked = True
        Me.rdoLocal.Location = New System.Drawing.Point(23, 34)
        Me.rdoLocal.Name = "rdoLocal"
        Me.rdoLocal.Size = New System.Drawing.Size(83, 16)
        Me.rdoLocal.TabIndex = 24
        Me.rdoLocal.TabStop = True
        Me.rdoLocal.Text = "当前文件夹"
        Me.rdoLocal.UseVisualStyleBackColor = True
        '
        'rdoSameFolder
        '
        Me.rdoSameFolder.AutoSize = True
        Me.rdoSameFolder.Location = New System.Drawing.Point(186, 34)
        Me.rdoSameFolder.Name = "rdoSameFolder"
        Me.rdoSameFolder.Size = New System.Drawing.Size(95, 16)
        Me.rdoSameFolder.TabIndex = 25
        Me.rdoSameFolder.Text = "同一个文件夹"
        Me.rdoSameFolder.UseVisualStyleBackColor = True
        '
        'txtString
        '
        Me.txtString.Location = New System.Drawing.Point(12, 56)
        Me.txtString.Name = "txtString"
        Me.txtString.Size = New System.Drawing.Size(473, 21)
        Me.txtString.TabIndex = 26
        '
        'chkCloseFile
        '
        Me.chkCloseFile.AutoSize = True
        Me.chkCloseFile.Checked = True
        Me.chkCloseFile.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCloseFile.Location = New System.Drawing.Point(334, 12)
        Me.chkCloseFile.Name = "chkCloseFile"
        Me.chkCloseFile.Size = New System.Drawing.Size(72, 16)
        Me.chkCloseFile.TabIndex = 27
        Me.chkCloseFile.Text = "关闭文件"
        Me.chkCloseFile.UseVisualStyleBackColor = True
        '
        'lstFileList
        '
        Me.lstFileList.FormattingEnabled = True
        Me.lstFileList.ItemHeight = 12
        Me.lstFileList.Location = New System.Drawing.Point(161, 90)
        Me.lstFileList.Name = "lstFileList"
        Me.lstFileList.Size = New System.Drawing.Size(122, 28)
        Me.lstFileList.TabIndex = 29
        Me.lstFileList.Visible = False
        '
        'chkSaveFile
        '
        Me.chkSaveFile.AutoSize = True
        Me.chkSaveFile.Checked = True
        Me.chkSaveFile.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSaveFile.Location = New System.Drawing.Point(334, 35)
        Me.chkSaveFile.Name = "chkSaveFile"
        Me.chkSaveFile.Size = New System.Drawing.Size(72, 16)
        Me.chkSaveFile.TabIndex = 30
        Me.chkSaveFile.Text = "保存文件"
        Me.chkSaveFile.UseVisualStyleBackColor = True
        '
        'frmAllSaveAs
        '
        Me.AcceptButton = Me.btnStart
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(501, 127)
        Me.Controls.Add(Me.chkSaveFile)
        Me.Controls.Add(Me.lstFileList)
        Me.Controls.Add(Me.chkCloseFile)
        Me.Controls.Add(Me.txtString)
        Me.Controls.Add(Me.rdoSameFolder)
        Me.Controls.Add(Me.rdoLocal)
        Me.Controls.Add(Me.chkpdf)
        Me.Controls.Add(Me.chkfwg)
        Me.Controls.Add(Me.btnAddFolder)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnStart)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAllSaveAs"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "全部另存为"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents chkfwg As System.Windows.Forms.CheckBox
    Friend WithEvents chkpdf As System.Windows.Forms.CheckBox
    Friend WithEvents btnAddFolder As System.Windows.Forms.Button
    Friend WithEvents rdoLocal As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSameFolder As System.Windows.Forms.RadioButton
    Friend WithEvents txtString As System.Windows.Forms.TextBox
    Friend WithEvents chkCloseFile As System.Windows.Forms.CheckBox
    Friend WithEvents lstFileList As System.Windows.Forms.ListBox
    Friend WithEvents chkSaveFile As System.Windows.Forms.CheckBox

End Class
