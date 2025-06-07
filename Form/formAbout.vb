'Imports FSLib.App.SimpleUpdater

Public NotInheritable Class FormAbout



    Private Sub FrmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' 设置此窗体的标题。
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("关于 {0}", ApplicationTitle)

        Me.Icon = My.Resources.XHTool24
        Me.picWeiXin.Image = My.Resources.微信打赏

        Me.lblProductName.Text = String.Format("产品 {0}", My.Application.Info.ProductName)
        Me.lblVersion.Text = String.Format("版本 {0}", My.Application.Info.Version.ToString)
        Me.lblCopyright.Text = String.Format("版权 {0}", My.Application.Info.Copyright)
        Me.lblCompanyName.Text = String.Format("公司 {0}", My.Application.Info.CompanyName)
        Me.txtDescription.Text = $“{My.Application.Info.Description}{vbCrLf}{IO.Path.Combine(My.Application.Info.DirectoryPath, My.Application.Info.AssemblyName & ".dll")}”

        '释放更新程序
        'NewUpdater.CreateUpdateExe()

        '检查释放有新版本
        'Select Case NewUpdater.CheckNewVesion()
        '    Case "New"
        '        With btnCheckUpdate
        '            .Text = "当前为最新版"
        '            .Visible = False
        '        End With

        '    Case Else
        '        btnCheckUpdate.Text = "检查到新版" & NewVersion
        'End Select

    End Sub

    Private Sub Btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click, Me.Closing
        FormManager.CloseAndDisposeForm(Of formAbout)()
    End Sub

    Private Sub Btn检查更新_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn检查更新.Click

        NewUpdater.Shell_XHUpdater("1")

        Me.Close()

    End Sub

    Private Sub LblGitCode_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblGitCode.LinkClicked
        ProcessStart(Github)
    End Sub

    Private Sub LblBilibili_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblBilibili.LinkClicked
        ProcessStart(Bilibili)
    End Sub
End Class