<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventoryCoding
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
        Me.lvwFileList = New System.Windows.Forms.ListView()
        Me.chType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chCoding = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chFileName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSearchCoding = New System.Windows.Forms.Button()
        Me.btnWriteCoding = New System.Windows.Forms.Button()
        Me.prgProcess = New System.Windows.Forms.ProgressBar()
        Me.btnLoadFile = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lvwFileList
        '
        Me.lvwFileList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwFileList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chType, Me.chName, Me.chCoding, Me.chFileName})
        Me.lvwFileList.FullRowSelect = True
        Me.lvwFileList.Location = New System.Drawing.Point(12, 13)
        Me.lvwFileList.Name = "lvwFileList"
        Me.lvwFileList.Size = New System.Drawing.Size(569, 254)
        Me.lvwFileList.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvwFileList.TabIndex = 0
        Me.lvwFileList.UseCompatibleStateImageBehavior = False
        Me.lvwFileList.View = System.Windows.Forms.View.Details
        '
        'chType
        '
        Me.chType.Text = "规格(图号)"
        Me.chType.Width = 150
        '
        'chName
        '
        Me.chName.Text = "存货名称"
        Me.chName.Width = 120
        '
        'chCoding
        '
        Me.chCoding.Text = "存货编码"
        Me.chCoding.Width = 80
        '
        'chFileName
        '
        Me.chFileName.Text = "文件"
        Me.chFileName.Width = 200
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.AutoSize = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(510, 277)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(69, 28)
        Me.btnClose.TabIndex = 32
        Me.btnClose.Text = "关闭"
        '
        'btnSearchCoding
        '
        Me.btnSearchCoding.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearchCoding.Location = New System.Drawing.Point(356, 277)
        Me.btnSearchCoding.Name = "btnSearchCoding"
        Me.btnSearchCoding.Size = New System.Drawing.Size(69, 28)
        Me.btnSearchCoding.TabIndex = 31
        Me.btnSearchCoding.Text = "查询"
        '
        'btnWriteCoding
        '
        Me.btnWriteCoding.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWriteCoding.Location = New System.Drawing.Point(433, 277)
        Me.btnWriteCoding.Name = "btnWriteCoding"
        Me.btnWriteCoding.Size = New System.Drawing.Size(69, 28)
        Me.btnWriteCoding.TabIndex = 34
        Me.btnWriteCoding.Text = "写入"
        Me.btnWriteCoding.UseVisualStyleBackColor = True
        '
        'prgProcess
        '
        Me.prgProcess.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.prgProcess.Location = New System.Drawing.Point(12, 280)
        Me.prgProcess.Name = "prgProcess"
        Me.prgProcess.Size = New System.Drawing.Size(261, 24)
        Me.prgProcess.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.prgProcess.TabIndex = 35
        '
        'btnLoadFile
        '
        Me.btnLoadFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoadFile.Location = New System.Drawing.Point(279, 277)
        Me.btnLoadFile.Name = "btnLoadFile"
        Me.btnLoadFile.Size = New System.Drawing.Size(69, 28)
        Me.btnLoadFile.TabIndex = 36
        Me.btnLoadFile.Text = "装载"
        '
        'frmInventoryCoding
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 322)
        Me.Controls.Add(Me.btnLoadFile)
        Me.Controls.Add(Me.prgProcess)
        Me.Controls.Add(Me.btnWriteCoding)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSearchCoding)
        Me.Controls.Add(Me.lvwFileList)
        Me.MaximizeBox = False
        Me.Name = "frmInventoryCoding"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "导入存货编码"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvwFileList As System.Windows.Forms.ListView
    Friend WithEvents chCoding As System.Windows.Forms.ColumnHeader
    Friend WithEvents chName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chType As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSearchCoding As System.Windows.Forms.Button
    Friend WithEvents chFileName As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnWriteCoding As System.Windows.Forms.Button
    Friend WithEvents prgProcess As System.Windows.Forms.ProgressBar
    Friend WithEvents btnLoadFile As System.Windows.Forms.Button
End Class
