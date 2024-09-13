Imports Inventor
Imports Microsoft.VisualBasic
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports Microsoft.Win32
Imports stdole
Imports System.Drawing
'Imports System.Drawing.Image
Imports System.Runtime.InteropServices
Imports System.Windows.Forms


Public Class frmSwitchLables

    Private PictureBoxes() As PictureBox
    Private Labels() As Label

    Private strSelectFileFullName As String
    Private int图框控件数量 As Integer ' 设置PictureBox的数量
    Private int图框控件上限 As Integer   '控件数组上限

    Private Sub CenterForm()
        ' 获取屏幕的工作区域（排除了任务栏等）  
        Dim screenBounds As Rectangle = Screen.GetWorkingArea(Me)

        ' 计算窗口的起始位置  
        Dim startX As Integer = (screenBounds.Width - Me.Width) \ 2
        Dim startY As Integer = (screenBounds.Height - Me.Height) \ 2

        ' 设置窗口的位置  
        Me.Location = New Drawing.Point(startX, startY)
    End Sub

    Private Sub frmSwitchLables_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Dispose()
        End If
    End Sub

    Private Sub frmTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48

        'Dim stopwatch As New Stopwatch()
        'stopwatch.Start()  ' 开始计时

        Dim oInteraction As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        oInteraction.Start()
        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        ThisApplication.UserInterfaceManager.DoEvents()

        '加载图片
        LoadThumbnail()

        '布置图框位置
        SetLocation()

        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        oInteraction.Stop()

        '窗口居中
        CenterForm()

        'stopwatch.Stop()  ' 停止计时
        'Dim elapsedTime As TimeSpan = stopwatch.Elapsed  ' 获取经过的时间

        'Debug.Print(elapsedTime.TotalSeconds.ToString)

    End Sub


    Private Sub LoadThumbnail()

        int图框控件数量 = ThisApplication.Documents.VisibleDocuments.Count
        int图框控件上限 = int图框控件数量 - 1

        ReDim PictureBoxes(int图框控件上限)

        ReDim Labels(int图框控件上限)

        For i As Integer = 0 To int图框控件上限

            Dim strfilename As String
            strfilename = ThisApplication.Documents.VisibleDocuments.Item(i + 1).FullDocumentName

            If strfilename = Nothing Then
                strfilename = ThisApplication.Documents.VisibleDocuments.Item(i + 1).DisplayName
            End If

            Try
                Dim img As System.Drawing.Image
                img = GetImageFromView(ThisApplication.Documents.VisibleDocuments.Item(i + 1))

                PictureBoxes(i) = New PictureBox()

                With PictureBoxes(i)
                    .BorderStyle = BorderStyle.FixedSingle
                    .ContextMenuStrip = ContextMenuStrip右键
                    .Image = img
                    .Name = strfilename
                    .Size = New Size(int图框宽度, int图框高度)
                    .SizeMode = PictureBoxSizeMode.StretchImage

                End With

                Labels(i) = New Label()

                With Labels(i)
                    .AutoEllipsis = True
                    .AutoSize = False
                    .ForeColor = Drawing.Color.BlueViolet
                    .Font = New System.Drawing.Font("宋体", 9, FontStyle.Regular)
                    .Text = GetFileNameInfo(strfilename).FileName
                    .TextAlign = ContentAlignment.MiddleLeft
                    .Width = PictureBoxes(i).Width - 4
                    .Name = strfilename

                    Debug.Print(.Width & "  ----" & PictureBoxes(i).Width)

                End With

                Me.Controls.Add(Labels(i))
                Me.Controls.Add(PictureBoxes(i))

                AddHandler PictureBoxes(i).MouseClick, AddressOf PictureBox_MouseClick
                AddHandler PictureBoxes(i).MouseEnter, AddressOf PictureBox_MouseEnter
                AddHandler PictureBoxes(i).MouseLeave, AddressOf PictureBox_MouseLeave

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next

    End Sub


    '保存缩略图为jpg文件
    Private Function GetImageFromView(ByVal oInventorDocument As Inventor.Document) As Drawing.Image
        Dim tempFile As String = IO.Path.GetTempFileName()
        tempFile = IO.Path.ChangeExtension(tempFile, ".jpg")

        Dim oActiveView As Inventor.View
        oActiveView = oInventorDocument.Views.Item(1)

        Dim oCamera As Camera
        oCamera = oActiveView.Camera

        oCamera.SaveAsBitmap(tempFile, 400, 300)

        GetImageFromView = Image.FromFile(tempFile)

    End Function

    '布置图框位置
    Private Sub SetLocation()

        Dim int初始点X As Integer = 10   ' 初始横坐标位置
        Dim int初始点Y As Integer = 10 ' 初始纵坐标位置

        Me.SuspendLayout()

        PictureBoxes(0).Location = New Drawing.Point(int初始点X, int初始点Y)
        Labels(0).Location = New Drawing.Point(int初始点X + 2, int初始点Y + 2)

        For i As Integer = 1 To int图框控件上限
            int初始点X = int初始点X + int图框宽度 + int图框列间距 ' 更新横坐标位置

            If i Mod int每行数量 = 0 Then ' 判断是否到达每行的最后一个PictureBox
                int初始点X = 10 ' 重置横坐标位置
                int初始点Y = int初始点Y + int图框高度 + int图框行间距 ' 更新纵坐标位置
            End If

            PictureBoxes(i).Location = New Drawing.Point(int初始点X, int初始点Y)
            Labels(i).Location = New Drawing.Point(int初始点X + 2, int初始点Y + 2)
        Next

        ' 根据最后一行的picturebox控件坐标确定窗口的高度
        Dim lastRowIndex As Integer = Math.Ceiling(int图框控件数量 / int每行数量)

        'Dim lastRowint初始点Y As Integer = 

        Dim intWindowHeight As Integer = lastRowIndex * (int图框高度 + int图框行间距) + 10

        'Me.ClientSize = New Size(Me.ClientSize.Width, intWindowHeight)

        ' 根据最后一列的picturebox控件坐标确定窗口的宽度

        Dim intWindowWidth As Integer

        If int图框控件数量 > int每行数量 Then
            '有第二行
            intWindowWidth = int每行数量 * (int图框宽度 + int图框列间距) + 10
        Else
            intWindowWidth = int图框控件数量 * (int图框宽度 + int图框列间距) + 10
        End If

        Me.ClientSize = New Size(intWindowWidth, intWindowHeight)   ' Me.ClientSize.Height)

        Me.ResumeLayout(True)

    End Sub

    ' 添加 PictureBox 的 MouseDown 事件处理程序
    Private Sub PictureBox_MouseClick(sender As Object, e As MouseEventArgs)

        Dim oSelectedPictureBox As PictureBox = CType(sender, PictureBox)
        ' 在选中的 PictureBox 上画一个边框
        oSelectedPictureBox.BorderStyle = BorderStyle.FixedSingle

        'MessageBox.Show("你已选中 PictureBox: " & selectedPictureBox.Name)

        strSelectFileFullName = oSelectedPictureBox.Name()

        ThisApplication.Documents.ItemByName(strSelectFileFullName).Activate()

        Me.Dispose()

    End Sub

    '鼠标移进
    Private Sub PictureBox_MouseEnter(sender As Object, e As EventArgs)
        Dim oSelectedPictureBox As PictureBox = CType(sender, PictureBox)

        Dim index As Integer = Array.IndexOf(PictureBoxes, oSelectedPictureBox)

        Dim oSelectdLabel As Label = Labels(index)

        strSelectFileFullName = oSelectedPictureBox.Name()

        oSelectedPictureBox.Size = New Size(oSelectedPictureBox.Width + int图框列间距 \ 2, oSelectedPictureBox.Height + int图框行间距 \ 2)
        oSelectdLabel.Size = New Size(oSelectedPictureBox.Width - 4, oSelectdLabel.Height)


        Me.Text = "切换文档" & oSelectedPictureBox.Name
    End Sub

    '鼠标移出
    Private Sub PictureBox_MouseLeave(sender As Object, e As EventArgs)
        Dim oSelectedPictureBox As PictureBox = CType(sender, PictureBox)

        Dim index As Integer = Array.IndexOf(PictureBoxes, oSelectedPictureBox)

        Dim oSelectdLabel As Label = Labels(index)

        oSelectedPictureBox.Size = New Size(oSelectedPictureBox.Width - int图框列间距 \ 2, oSelectedPictureBox.Height - int图框行间距 \ 2)

        oSelectdLabel.Size = New Size(oSelectedPictureBox.Width - 4, oSelectdLabel.Height)

        Me.Text = "切换文档"
    End Sub

    '关闭文档
    Private Sub ToolStripMenuItem关闭_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem关闭文档.Click
        Me.TopMost = False

        ThisApplication.Documents.ItemByName(strSelectFileFullName).Close()

        Me.TopMost = True

        Me.SuspendLayout()

        For Each oPictureBox As PictureBox In PictureBoxes
            If oPictureBox.Name = strSelectFileFullName Then
                Me.Controls.Remove(oPictureBox)
            End If
        Next

        For Each oLabel As Label In Labels
            If oLabel.Name = strSelectFileFullName Then
                Me.Controls.Remove(oLabel)
            End If
        Next

        '判断是否还有可见打开的文档
        If ThisApplication.Documents.VisibleDocuments.Count > 1 Then
            int图框控件数量 = int图框控件数量 - 1
            SetLocation()
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Dispose()
        End If

    End Sub

    Private Sub ToolStripMenuItem设置_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem设置.Click
        'Dim frmSwitchLablesOption As New frmSwitchLablesOption
        'frmSwitchLablesOption.ShowDialog()

        txt每行数量.Text = int每行数量.ToString
        txt图框宽度.Text = int图框宽度.ToString
        txt图框高度.Text = int图框高度.ToString
        txt行间距.Text = int图框行间距.ToString
        txt列间距.Text = int图框列间距.ToString


        Dim windowWidth As Integer = Me.ClientSize.Width
        Dim windowHeight As Integer = Me.ClientSize.Height
        Dim groupBoxWidth As Integer = GroupBox设置.Width
        Dim groupBoxHeight As Integer = GroupBox设置.Height

        Dim x As Integer = (windowWidth - groupBoxWidth) / 2
        Dim y As Integer = (windowHeight - groupBoxHeight) / 2 + 12

        Panel设置.Location = New Drawing.Point(x, y)

        If Me.Height < 280 Then
            Me.Height = 280
        End If

        Panel设置.Show()

    End Sub

    Private Sub btn确定_Click(sender As Object, e As EventArgs) Handles btn确定.Click
        int每行数量 = txt每行数量.Text
        int图框宽度 = txt图框宽度.Text
        int图框高度 = txt图框高度.Text
        int图框行间距 = txt行间距.Text
        int图框列间距 = txt列间距.Text

        ini.WriteStrINI("切换文档", "每行数量", int每行数量.ToString, Inifile)
        ini.WriteStrINI("切换文档", "图框宽度", int图框宽度.ToString, Inifile)
        ini.WriteStrINI("切换文档", "图框高度", int图框高度.ToString, Inifile)
        ini.WriteStrINI("切换文档", "图框行间距", int图框行间距.ToString, Inifile)
        ini.WriteStrINI("切换文档", "图框列间距", int图框列间距.ToString, Inifile)

        Panel设置.Hide()

        For Each oPictureBox As PictureBox In PictureBoxes
            oPictureBox.Size = New Size(int图框宽度, int图框高度)
        Next

        SetLocation()

    End Sub

    Private Sub btn关闭_Click(sender As Object, e As EventArgs) Handles btn关闭.Click
        Panel设置.Hide()
    End Sub

    Private Sub ToolStripMenuItem退出_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem关闭窗口.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

End Class