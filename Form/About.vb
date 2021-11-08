
Imports FSLib.App.SimpleUpdater

Public NotInheritable Class About

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Me.LabelProductName.Text = String.Format("产品 {0}", My.Application.Info.ProductName)
        Me.LabelVersion.Text = String.Format("版本 {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = String.Format("版权 {0}", My.Application.Info.Copyright)
        Me.LabelCompanyName.Text = String.Format("公司 {0}", My.Application.Info.CompanyName)
        Me.TextBoxDescription.Text = My.Application.Info.Description & vbCrLf & _
                                      vbCrLf & _
                                    My.Application.Info.DirectoryPath
    End Sub

    Private Sub OKButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Try
        '    Dim simupdate As String

        '    simupdate = My.Application.Info.DirectoryPath & "\simupdater.exe"
        '    Process.Start(simupdate)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    NewUpdater.UpDater2(True)
    End Sub
End Class
