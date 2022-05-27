<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAutoPartNumber
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
        Me.btnMoveUp = New System.Windows.Forms.Button()
        Me.btnReview = New System.Windows.Forms.Button()
        Me.btnMoveDown = New System.Windows.Forms.Button()
        Me.lvwFile = New System.Windows.Forms.ListView()
        Me.chOriginalFileName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chNewFileName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chFolder = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtBasicNum = New System.Windows.Forms.TextBox()
        Me.lblBasicNum = New System.Windows.Forms.Label()
        Me.lblAmsChange = New System.Windows.Forms.Label()
        Me.lblPartChange = New System.Windows.Forms.Label()
        Me.txtPartChange = New System.Windows.Forms.TextBox()
        Me.cmbAmsChange = New System.Windows.Forms.ComboBox()
        Me.btnMoveOut = New System.Windows.Forms.Button()
        Me.btnReLoad = New System.Windows.Forms.Button()
        Me.lblNewFileName = New System.Windows.Forms.Label()
        Me.txtNewFileName = New System.Windows.Forms.TextBox()
        Me.btnSelectall = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStart.Location = New System.Drawing.Point(511, 385)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(65, 28)
        Me.btnStart.TabIndex = 5
        Me.btnStart.Text = "开始"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.AutoSize = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(584, 385)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(65, 28)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "关闭"
        '
        'btnMoveUp
        '
        Me.btnMoveUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMoveUp.Location = New System.Drawing.Point(93, 385)
        Me.btnMoveUp.Name = "btnMoveUp"
        Me.btnMoveUp.Size = New System.Drawing.Size(65, 28)
        Me.btnMoveUp.TabIndex = 0
        Me.btnMoveUp.TabStop = False
        Me.btnMoveUp.Text = "上移"
        Me.btnMoveUp.UseVisualStyleBackColor = True
        '
        'btnReview
        '
        Me.btnReview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReview.Location = New System.Drawing.Point(385, 385)
        Me.btnReview.Name = "btnReview"
        Me.btnReview.Size = New System.Drawing.Size(65, 28)
        Me.btnReview.TabIndex = 4
        Me.btnReview.Text = "预览"
        Me.btnReview.UseVisualStyleBackColor = True
        '
        'btnMoveDown
        '
        Me.btnMoveDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMoveDown.Location = New System.Drawing.Point(166, 385)
        Me.btnMoveDown.Name = "btnMoveDown"
        Me.btnMoveDown.Size = New System.Drawing.Size(65, 28)
        Me.btnMoveDown.TabIndex = 21
        Me.btnMoveDown.TabStop = False
        Me.btnMoveDown.Text = "下移"
        Me.btnMoveDown.UseVisualStyleBackColor = True
        '
        'lvwFile
        '
        Me.lvwFile.AllowDrop = True
        Me.lvwFile.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwFile.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chOriginalFileName, Me.chType, Me.chNewFileName, Me.chFolder})
        Me.lvwFile.FullRowSelect = True
        Me.lvwFile.Location = New System.Drawing.Point(13, 12)
        Me.lvwFile.Name = "lvwFile"
        Me.lvwFile.Size = New System.Drawing.Size(636, 281)
        Me.lvwFile.TabIndex = 22
        Me.lvwFile.TabStop = False
        Me.lvwFile.UseCompatibleStateImageBehavior = False
        Me.lvwFile.View = System.Windows.Forms.View.Details
        '
        'chOriginalFileName
        '
        Me.chOriginalFileName.Text = "原文件名"
        Me.chOriginalFileName.Width = 150
        '
        'chType
        '
        Me.chType.Text = "类型"
        Me.chType.Width = 50
        '
        'chNewFileName
        '
        Me.chNewFileName.Text = "新文件名"
        Me.chNewFileName.Width = 250
        '
        'chFolder
        '
        Me.chFolder.Text = "文件夹"
        Me.chFolder.Width = 250
        '
        'txtBasicNum
        '
        Me.txtBasicNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtBasicNum.Location = New System.Drawing.Point(79, 315)
        Me.txtBasicNum.Name = "txtBasicNum"
        Me.txtBasicNum.Size = New System.Drawing.Size(134, 21)
        Me.txtBasicNum.TabIndex = 0
        '
        'lblBasicNum
        '
        Me.lblBasicNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBasicNum.AutoSize = True
        Me.lblBasicNum.Location = New System.Drawing.Point(22, 318)
        Me.lblBasicNum.Name = "lblBasicNum"
        Me.lblBasicNum.Size = New System.Drawing.Size(53, 12)
        Me.lblBasicNum.TabIndex = 25
        Me.lblBasicNum.Text = "基准代号"
        '
        'lblAmsChange
        '
        Me.lblAmsChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAmsChange.AutoSize = True
        Me.lblAmsChange.Location = New System.Drawing.Point(219, 318)
        Me.lblAmsChange.Name = "lblAmsChange"
        Me.lblAmsChange.Size = New System.Drawing.Size(65, 12)
        Me.lblAmsChange.TabIndex = 26
        Me.lblAmsChange.Text = "部件变化量"
        '
        'lblPartChange
        '
        Me.lblPartChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPartChange.AutoSize = True
        Me.lblPartChange.Location = New System.Drawing.Point(397, 318)
        Me.lblPartChange.Name = "lblPartChange"
        Me.lblPartChange.Size = New System.Drawing.Size(65, 12)
        Me.lblPartChange.TabIndex = 28
        Me.lblPartChange.Text = "零件变化量"
        '
        'txtPartChange
        '
        Me.txtPartChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPartChange.Location = New System.Drawing.Point(478, 315)
        Me.txtPartChange.Name = "txtPartChange"
        Me.txtPartChange.Size = New System.Drawing.Size(73, 21)
        Me.txtPartChange.TabIndex = 2
        Me.txtPartChange.Text = "1"
        '
        'cmbAmsChange
        '
        Me.cmbAmsChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbAmsChange.FormattingEnabled = True
        Me.cmbAmsChange.Items.AddRange(New Object() {"100", "10000"})
        Me.cmbAmsChange.Location = New System.Drawing.Point(292, 315)
        Me.cmbAmsChange.Name = "cmbAmsChange"
        Me.cmbAmsChange.Size = New System.Drawing.Size(99, 20)
        Me.cmbAmsChange.TabIndex = 2
        Me.cmbAmsChange.Text = "100"
        '
        'btnMoveOut
        '
        Me.btnMoveOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMoveOut.Location = New System.Drawing.Point(239, 385)
        Me.btnMoveOut.Name = "btnMoveOut"
        Me.btnMoveOut.Size = New System.Drawing.Size(65, 28)
        Me.btnMoveOut.TabIndex = 29
        Me.btnMoveOut.Text = "移出"
        Me.btnMoveOut.UseVisualStyleBackColor = True
        '
        'btnReLoad
        '
        Me.btnReLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReLoad.Location = New System.Drawing.Point(312, 385)
        Me.btnReLoad.Name = "btnReLoad"
        Me.btnReLoad.Size = New System.Drawing.Size(65, 28)
        Me.btnReLoad.TabIndex = 30
        Me.btnReLoad.Text = "重载"
        Me.btnReLoad.UseVisualStyleBackColor = True
        '
        'lblNewFileName
        '
        Me.lblNewFileName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblNewFileName.AutoSize = True
        Me.lblNewFileName.Location = New System.Drawing.Point(20, 346)
        Me.lblNewFileName.Name = "lblNewFileName"
        Me.lblNewFileName.Size = New System.Drawing.Size(53, 12)
        Me.lblNewFileName.TabIndex = 31
        Me.lblNewFileName.Text = "新文件名"
        '
        'txtNewFileName
        '
        Me.txtNewFileName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtNewFileName.Location = New System.Drawing.Point(79, 342)
        Me.txtNewFileName.Name = "txtNewFileName"
        Me.txtNewFileName.Size = New System.Drawing.Size(361, 21)
        Me.txtNewFileName.TabIndex = 32
        '
        'btnSelectall
        '
        Me.btnSelectall.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectall.Location = New System.Drawing.Point(20, 385)
        Me.btnSelectall.Name = "btnSelectall"
        Me.btnSelectall.Size = New System.Drawing.Size(65, 28)
        Me.btnSelectall.TabIndex = 33
        Me.btnSelectall.TabStop = False
        Me.btnSelectall.Text = "全选"
        Me.btnSelectall.UseVisualStyleBackColor = True
        Me.btnSelectall.Visible = False
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(446, 340)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(25, 25)
        Me.btnOK.TabIndex = 34
        Me.btnOK.Text = "√"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmAutoPartNumber
        '
        Me.AcceptButton = Me.btnStart
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(661, 427)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnSelectall)
        Me.Controls.Add(Me.txtNewFileName)
        Me.Controls.Add(Me.lblNewFileName)
        Me.Controls.Add(Me.btnReLoad)
        Me.Controls.Add(Me.btnMoveOut)
        Me.Controls.Add(Me.cmbAmsChange)
        Me.Controls.Add(Me.lblPartChange)
        Me.Controls.Add(Me.txtPartChange)
        Me.Controls.Add(Me.lblAmsChange)
        Me.Controls.Add(Me.lblBasicNum)
        Me.Controls.Add(Me.txtBasicNum)
        Me.Controls.Add(Me.lvwFile)
        Me.Controls.Add(Me.btnMoveDown)
        Me.Controls.Add(Me.btnReview)
        Me.Controls.Add(Me.btnMoveUp)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnStart)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAutoPartNumber"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "自动命名图号"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnMoveUp As System.Windows.Forms.Button
    Friend WithEvents btnReview As System.Windows.Forms.Button
    Friend WithEvents btnMoveDown As System.Windows.Forms.Button
    Friend WithEvents lvwFile As System.Windows.Forms.ListView
    Friend WithEvents chOriginalFileName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chType As System.Windows.Forms.ColumnHeader
    Friend WithEvents chNewFileName As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtBasicNum As System.Windows.Forms.TextBox
    Friend WithEvents lblBasicNum As System.Windows.Forms.Label
    Friend WithEvents lblAmsChange As System.Windows.Forms.Label
    Friend WithEvents lblPartChange As System.Windows.Forms.Label
    Friend WithEvents txtPartChange As System.Windows.Forms.TextBox
    Friend WithEvents chFolder As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmbAmsChange As System.Windows.Forms.ComboBox
    Friend WithEvents btnMoveOut As System.Windows.Forms.Button
    Friend WithEvents btnReLoad As System.Windows.Forms.Button
    Friend WithEvents lblNewFileName As System.Windows.Forms.Label
    Friend WithEvents txtNewFileName As System.Windows.Forms.TextBox
    Friend WithEvents btnSelectall As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button

End Class
