Imports FSLib.App.SimpleUpdater

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
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub btnCheckUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckUpdate.Click
        'Try
        '    Dim simupdate As String

        '    simupdate = My.Application.Info.DirectoryPath & "\simupdater.exe"
        '    Process.Start(simupdate)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        'NewUpdater.UpDater2(True)

        'IsShowUpdateMsg = True
        'Dim frmupdate As New frmUpdate
        'frmupdate.ShowDialog()

        If NewUpdater.CreateInAIUpdate() = True Then
            NewUpdater.Update3()
        End If
    End Sub

    Private Sub btnGit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGit.Click
        Process.Start(GitWeb)
    End Sub
End Class