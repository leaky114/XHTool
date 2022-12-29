'Imports FSLib.App.SimpleUpdater

Public NotInheritable Class frmAbout

    Const GitWeb As String = "https://gitcode.net/leaky114/inventoraddin"

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' 设置此窗体的标题。
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("关于 {0}", ApplicationTitle)
        ' 初始化“关于”对话框显示的所有文字。
        ' TODO: 在项目的“应用程序”窗格中自定义此应用程序的程序集信息
        '    属性对话框(在“项目”菜单下)。
        Me.lblProductName.Text = String.Format("产品 {0}", My.Application.Info.ProductName)
        Me.lblVersion.Text = String.Format("版本 {0}", My.Application.Info.Version.ToString)
        Me.lblCopyright.Text = String.Format("版权 {0}", My.Application.Info.Copyright)
        Me.lblCompanyName.Text = String.Format("公司 {0}", My.Application.Info.CompanyName)
        Me.txtDescription.Text = My.Application.Info.Description & vbCrLf & _
                                      vbCrLf & _
                                    My.Application.Info.DirectoryPath & "\" & My.Application.Info.AssemblyName & ".dll"

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

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnCheckUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckUpdate.Click

        '启动更新程序
        NewUpdater.UpDate3()

        'IsShowUpdateMsg = True
        'Dim frmupdate As New frmUpdate
        'frmupdate.ShowDialog()

        'If NewUpdater.CreateUpdate() = True Then
        'NewUpdater.Update3()
        ''End If
        Me.Close()

    End Sub

    Private Sub btnGit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGit.Click
        Process.Start(GitWeb)
    End Sub
End Class