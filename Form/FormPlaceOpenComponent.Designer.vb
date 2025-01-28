Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPlaceOpenComponent
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
        Me.ListBox零部件 = New System.Windows.Forms.ListBox()
        Me.btn插入到部件 = New System.Windows.Forms.Button()
        Me.PictureBox缩略图 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox缩略图, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListBox零部件
        '
        Me.ListBox零部件.FormattingEnabled = True
        Me.ListBox零部件.ItemHeight = 12
        Me.ListBox零部件.Location = New System.Drawing.Point(12, 12)
        Me.ListBox零部件.Name = "ListBox零部件"
        Me.ListBox零部件.Size = New System.Drawing.Size(211, 256)
        Me.ListBox零部件.TabIndex = 0
        '
        'btn插入到部件
        '
        Me.btn插入到部件.Location = New System.Drawing.Point(352, 280)
        Me.btn插入到部件.Name = "btn插入到部件"
        Me.btn插入到部件.Size = New System.Drawing.Size(101, 34)
        Me.btn插入到部件.TabIndex = 2
        Me.btn插入到部件.Text = "插入到部件"
        Me.btn插入到部件.UseVisualStyleBackColor = True
        '
        'PictureBox缩略图
        '
        Me.PictureBox缩略图.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox缩略图.Location = New System.Drawing.Point(246, 12)
        Me.PictureBox缩略图.Name = "PictureBox缩略图"
        Me.PictureBox缩略图.Size = New System.Drawing.Size(238, 259)
        Me.PictureBox缩略图.TabIndex = 1
        Me.PictureBox缩略图.TabStop = False
        '
        'FormPlaceOpenComponent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 331)
        Me.Controls.Add(Me.btn插入到部件)
        Me.Controls.Add(Me.PictureBox缩略图)
        Me.Controls.Add(Me.ListBox零部件)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPlaceOpenComponent"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "插入打开的零部件"
        CType(Me.PictureBox缩略图, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListBox零部件 As ListBox
    Friend WithEvents btn插入到部件 As Button
    Friend WithEvents PictureBox缩略图 As PictureBox
End Class
