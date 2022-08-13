<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGetPart
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnMoveOut = New System.Windows.Forms.Button()
        Me.lblDescribe = New System.Windows.Forms.Label()
        Me.lvwFileList = New System.Windows.Forms.ListView()
        Me.chFilename = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chNumber = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chWeight = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chArea = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.txtWeight = New System.Windows.Forms.TextBox()
        Me.txtArea = New System.Windows.Forms.TextBox()
        Me.btnCopyG = New System.Windows.Forms.Button()
        Me.btnCopyA = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(17, 342)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(65, 28)
        Me.btnAdd.TabIndex = 38
        Me.btnAdd.TabStop = False
        Me.btnAdd.Text = "添加"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnMoveOut
        '
        Me.btnMoveOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnMoveOut.Location = New System.Drawing.Point(90, 342)
        Me.btnMoveOut.Name = "btnMoveOut"
        Me.btnMoveOut.Size = New System.Drawing.Size(65, 28)
        Me.btnMoveOut.TabIndex = 37
        Me.btnMoveOut.Text = "移出"
        Me.btnMoveOut.UseVisualStyleBackColor = True
        '
        'lblDescribe
        '
        Me.lblDescribe.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDescribe.AutoSize = True
        Me.lblDescribe.Location = New System.Drawing.Point(15, 309)
        Me.lblDescribe.Name = "lblDescribe"
        Me.lblDescribe.Size = New System.Drawing.Size(221, 12)
        Me.lblDescribe.TabIndex = 36
        Me.lblDescribe.Text = "总质量：                    总面积："
        '
        'lvwFileList
        '
        Me.lvwFileList.AllowDrop = True
        Me.lvwFileList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwFileList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chFilename, Me.chNumber, Me.chWeight, Me.chArea})
        Me.lvwFileList.FullRowSelect = True
        Me.lvwFileList.Location = New System.Drawing.Point(12, 10)
        Me.lvwFileList.Name = "lvwFileList"
        Me.lvwFileList.Size = New System.Drawing.Size(436, 285)
        Me.lvwFileList.TabIndex = 35
        Me.lvwFileList.TabStop = False
        Me.lvwFileList.UseCompatibleStateImageBehavior = False
        Me.lvwFileList.View = System.Windows.Forms.View.Details
        '
        'chFilename
        '
        Me.chFilename.Text = "文件名"
        Me.chFilename.Width = 220
        '
        'chNumber
        '
        Me.chNumber.Text = "数量"
        Me.chNumber.Width = 50
        '
        'chWeight
        '
        Me.chWeight.Text = "质量"
        Me.chWeight.Width = 80
        '
        'chArea
        '
        Me.chArea.Text = "面积"
        Me.chArea.Width = 80
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.AutoSize = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(383, 342)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(65, 28)
        Me.btnClose.TabIndex = 34
        Me.btnClose.Text = "关闭"
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Location = New System.Drawing.Point(163, 342)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(65, 28)
        Me.btnClear.TabIndex = 39
        Me.btnClear.Text = "清空"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'txtWeight
        '
        Me.txtWeight.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWeight.Location = New System.Drawing.Point(62, 304)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(77, 21)
        Me.txtWeight.TabIndex = 40
        '
        'txtArea
        '
        Me.txtArea.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtArea.Location = New System.Drawing.Point(242, 306)
        Me.txtArea.Name = "txtArea"
        Me.txtArea.Size = New System.Drawing.Size(77, 21)
        Me.txtArea.TabIndex = 41
        '
        'btnCopyG
        '
        Me.btnCopyG.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopyG.Location = New System.Drawing.Point(147, 304)
        Me.btnCopyG.Name = "btnCopyG"
        Me.btnCopyG.Size = New System.Drawing.Size(24, 20)
        Me.btnCopyG.TabIndex = 42
        Me.btnCopyG.Text = "C"
        Me.btnCopyG.UseVisualStyleBackColor = True
        '
        'btnCopyA
        '
        Me.btnCopyA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopyA.Location = New System.Drawing.Point(325, 305)
        Me.btnCopyA.Name = "btnCopyA"
        Me.btnCopyA.Size = New System.Drawing.Size(24, 20)
        Me.btnCopyA.TabIndex = 43
        Me.btnCopyA.Text = "C"
        Me.btnCopyA.UseVisualStyleBackColor = True
        '
        'frmGetPart
        '
        Me.AcceptButton = Me.btnAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 378)
        Me.Controls.Add(Me.btnCopyA)
        Me.Controls.Add(Me.btnCopyG)
        Me.Controls.Add(Me.txtArea)
        Me.Controls.Add(Me.txtWeight)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnMoveOut)
        Me.Controls.Add(Me.lblDescribe)
        Me.Controls.Add(Me.lvwFileList)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGetPart"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "统计质量面积"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnMoveOut As System.Windows.Forms.Button
    Friend WithEvents lblDescribe As System.Windows.Forms.Label
    Friend WithEvents lvwFileList As System.Windows.Forms.ListView
    Friend WithEvents chFilename As System.Windows.Forms.ColumnHeader
    Friend WithEvents chNumber As System.Windows.Forms.ColumnHeader
    Friend WithEvents chWeight As System.Windows.Forms.ColumnHeader
    Friend WithEvents chArea As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents txtWeight As System.Windows.Forms.TextBox
    Friend WithEvents txtArea As System.Windows.Forms.TextBox
    Friend WithEvents btnCopyG As System.Windows.Forms.Button
    Friend WithEvents btnCopyA As System.Windows.Forms.Button

End Class
