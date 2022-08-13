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
        Me.lvwFileListView = New System.Windows.Forms.ListView()
        Me.chType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chCoding = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chFileName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSearchCoding = New System.Windows.Forms.Button()
        Me.btnWriteCoding = New System.Windows.Forms.Button()
        Me.prgProcess = New System.Windows.Forms.ProgressBar()
        Me.btnLoadFile = New System.Windows.Forms.Button()
        Me.chkChild = New System.Windows.Forms.CheckBox()
        Me.chkSelectPart = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'lvwFileListView
        '
        Me.lvwFileListView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwFileListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chType, Me.chName, Me.chCoding, Me.chFileName})
        Me.lvwFileListView.FullRowSelect = True
        Me.lvwFileListView.Location = New System.Drawing.Point(12, 13)
        Me.lvwFileListView.MultiSelect = False
        Me.lvwFileListView.Name = "lvwFileListView"
        Me.lvwFileListView.Size = New System.Drawing.Size(730, 370)
        Me.lvwFileListView.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvwFileListView.TabIndex = 0
        Me.lvwFileListView.UseCompatibleStateImageBehavior = False
        Me.lvwFileListView.View = System.Windows.Forms.View.Details
        '
        'chType
        '
        Me.chType.Text = "规格(图号)"
        Me.chType.Width = 200
        '
        'chName
        '
        Me.chName.Text = "存货名称"
        Me.chName.Width = 146
        '
        'chCoding
        '
        Me.chCoding.Text = "存货编码"
        Me.chCoding.Width = 103
        '
        'chFileName
        '
        Me.chFileName.Text = "文件(双击打开)"
        Me.chFileName.Width = 258
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.AutoSize = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(671, 389)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(69, 28)
        Me.btnClose.TabIndex = 32
        Me.btnClose.Text = "关闭"
        '
        'btnSearchCoding
        '
        Me.btnSearchCoding.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearchCoding.Location = New System.Drawing.Point(517, 389)
        Me.btnSearchCoding.Name = "btnSearchCoding"
        Me.btnSearchCoding.Size = New System.Drawing.Size(69, 28)
        Me.btnSearchCoding.TabIndex = 31
        Me.btnSearchCoding.Text = "查询"
        '
        'btnWriteCoding
        '
        Me.btnWriteCoding.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWriteCoding.Location = New System.Drawing.Point(594, 389)
        Me.btnWriteCoding.Name = "btnWriteCoding"
        Me.btnWriteCoding.Size = New System.Drawing.Size(69, 28)
        Me.btnWriteCoding.TabIndex = 34
        Me.btnWriteCoding.Text = "写入"
        Me.btnWriteCoding.UseVisualStyleBackColor = True
        '
        'prgProcess
        '
        Me.prgProcess.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.prgProcess.Location = New System.Drawing.Point(12, 392)
        Me.prgProcess.Name = "prgProcess"
        Me.prgProcess.Size = New System.Drawing.Size(243, 24)
        Me.prgProcess.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.prgProcess.TabIndex = 35
        '
        'btnLoadFile
        '
        Me.btnLoadFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoadFile.Location = New System.Drawing.Point(440, 389)
        Me.btnLoadFile.Name = "btnLoadFile"
        Me.btnLoadFile.Size = New System.Drawing.Size(69, 28)
        Me.btnLoadFile.TabIndex = 36
        Me.btnLoadFile.Text = "装载"
        '
        'chkChild
        '
        Me.chkChild.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkChild.AutoSize = True
        Me.chkChild.Location = New System.Drawing.Point(360, 395)
        Me.chkChild.Name = "chkChild"
        Me.chkChild.Size = New System.Drawing.Size(72, 16)
        Me.chkChild.TabIndex = 38
        Me.chkChild.Text = "包含子集"
        Me.chkChild.UseVisualStyleBackColor = True
        '
        'chkSelectPart
        '
        Me.chkSelectPart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSelectPart.AutoSize = True
        Me.chkSelectPart.Location = New System.Drawing.Point(282, 395)
        Me.chkSelectPart.Name = "chkSelectPart"
        Me.chkSelectPart.Size = New System.Drawing.Size(72, 16)
        Me.chkSelectPart.TabIndex = 39
        Me.chkSelectPart.Text = "提示选择"
        Me.chkSelectPart.UseVisualStyleBackColor = True
        '
        'frmInventoryCoding
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(754, 428)
        Me.Controls.Add(Me.chkSelectPart)
        Me.Controls.Add(Me.chkChild)
        Me.Controls.Add(Me.btnLoadFile)
        Me.Controls.Add(Me.prgProcess)
        Me.Controls.Add(Me.btnWriteCoding)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSearchCoding)
        Me.Controls.Add(Me.lvwFileListView)
        Me.MaximizeBox = False
        Me.Name = "frmInventoryCoding"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "导入ERP编码"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvwFileListView As System.Windows.Forms.ListView
    Friend WithEvents chCoding As System.Windows.Forms.ColumnHeader
    Friend WithEvents chName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chType As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSearchCoding As System.Windows.Forms.Button
    Friend WithEvents chFileName As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnWriteCoding As System.Windows.Forms.Button
    Friend WithEvents prgProcess As System.Windows.Forms.ProgressBar
    Friend WithEvents btnLoadFile As System.Windows.Forms.Button
    Friend WithEvents chkChild As System.Windows.Forms.CheckBox
    Friend WithEvents chkSelectPart As System.Windows.Forms.CheckBox
End Class
