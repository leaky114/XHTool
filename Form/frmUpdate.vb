Imports System.Windows.Forms
'Imports FSLib.App.SimpleUpdater
Imports System.IO

Public Class frmUpdate

    Const InNewVison As String = "\\Likai-pc\发行版\2011\NewVersion.txt"
    Const ChangeLog As String = "\\Likai-pc\发行版\2011\CHANGELOG"

    Const GitWeb As String = "https://gitcode.net/leaky114/inventoraddin"

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
       
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub frmUpdate_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Select Case CheckUpdate
                Case "-1"
                    chk检查更新.Checked = False
                Case "1"
                    chk检查更新.Checked = True
            End Select


            Dim MyVersion As String = _
            My.Application.Info.Version.Major & "." & _
            My.Application.Info.Version.Minor & "." & _
            Format(My.Application.Info.Version.Build, "00") & "." & _
           Format(My.Application.Info.Version.Revision, "00")



            'MsgBox(MyVersion)

            If NewVersion Is Nothing Then
                'MsgBox("未链接到服务器。", MsgBoxStyle.OkOnly, "检查更新")
                Me.Close()
            Else
                Dim shortMyversion As Long
                Dim shortNewVersion As Long

                shortMyversion = ShortVersion(MyVersion)
                shortNewVersion = ShortVersion(NewVersion)

                If shortNewVersion > shortMyversion Then
                    'MsgBox("InventorAddIn插件" & vbCrLf & "当前版本：" & MyVersion & vbCrLf & "检查到 新版本：" & NewVersion, MsgBoxStyle.OkOnly, " 检查更新")
                    lblLocalVersion.Text = "当前版本：" & MyVersion
                    lblNewVersion.Text = "可更新版：" & NewVersion

                    '读取更新日志
                    Dim readText As String = File.ReadAllText(ChangeLog)
                    txtWhatNew.Text = readText
                    'Me.ShowDialog()
                Else
                    If IsShowUpdateMsg = True Then
                        MsgBox("当前为最新版。", MsgBoxStyle.OkOnly, "检查更新")
                    End If
                    Me.Close()
                End If

            End If
        Catch ex As Exception

            'MsgBox(ex.Message)
            'MsgBox("未链接到服务器。", MsgBoxStyle.OkOnly, "检查更新")
            Me.Close()
        End Try
    End Sub

    Public Sub CheckPmhker()

        Dim strTempFile As String
        strTempFile = GetHtmlFromPmhker()

        If strTempFile = "0" Then
            Exit Sub
        End If
        '分析网页，得到 新的版本文件和更新包文件
        Dim strUrl(1) As String
        strUrl = GetUpdateInfo(strTempFile)

        Dim strNewVison As String
        strNewVison = GetNewVison2(strUrl(0))

        If strNewVison <> "Null" Then
            If MsgBox("发现新版 XiHanTool，版本号" & strNewVison & "，是否更新？", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                strTempFile = System.IO.Path.Combine(IO.Path.GetTempPath, "UpdateZip.txt")

                If Not System.IO.File.Exists(strTempFile) Then
                    ' 创建一个新的文件
                    System.IO.File.Create(strTempFile).Dispose()
                End If

                ' 写入更新包地址文件中
                System.IO.File.WriteAllText(strTempFile, strUrl(1))


                strTempFile = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "UpdaterForInAI.exe")

                Process.Start(strTempFile)
            End If
        End If

    End Sub

    Public Function GetHtmlFromPmhker() As String
        Const pmhker = "https://www.pmhker.com/article/75.html"

        Dim strTempFile As String = Path.Combine(IO.Path.GetTempPath, "pmhker.txt")

        DownNetFile(pmhker, strTempFile)

        Dim fileInfo As New FileInfo(strTempFile)

        ' 获取文件大小（以字节为单位）
        Dim fileSize As Long = fileInfo.Length

        If fileSize < 100 Then
            strTempFile = "0"
        End If

        Return strTempFile

    End Function

    Public Function GetUpdateInfo(ByVal strTempFile As String) As String()
        On Error Resume Next
        Dim strUrl(1) As String
        Dim content As String = System.IO.File.ReadAllText(strTempFile)

        Dim startKeyword As String = "附件2：<a href="""
        Dim endKeyword As String = """ download=""NewVersion.txt"">NewVersion.txt</a>"
        Dim startIndex As Integer = content.IndexOf(startKeyword) + startKeyword.Length
        Dim endIndex As Integer = content.IndexOf(endKeyword)
        Dim strNewVison As String

        strNewVison = content.Substring(startIndex, endIndex - startIndex).Trim()

        startKeyword = "附件3：<a href="""
        endKeyword = """ download=""Updata.zip"">Updata.zip</a>"
        startIndex = content.IndexOf(startKeyword) + startKeyword.Length
        endIndex = content.IndexOf(endKeyword)
        Dim strUpdatazip As String

        strUpdatazip = content.Substring(startIndex, endIndex - startIndex).Trim()

        strUrl = {strNewVison, strUpdatazip}

        Return strUrl

    End Function

    Public Sub DownNetFile(ByVal nUrl As String, ByVal nFile As String)
        On Error Resume Next
        Dim XmlHttp As Object
        Dim B() As Byte

        XmlHttp = CreateObject("Microsoft.XMLHTTP")

        XmlHttp.Open("GET", nUrl, False)

        XmlHttp.Send()

        If XmlHttp.ReadyState = 4 Then
            B = XmlHttp.ResponseBody
            My.Computer.FileSystem.WriteAllBytes(nFile, B, False)
        End If
        XmlHttp = Nothing

    End Sub

    Public Function GetNewVison2(ByVal strUrlNewVison As String) As String
        Dim strTempFile As String

        '下载本版文件
        strTempFile = IO.Path.GetTempPath & "NewVison.txt"

        DownNetFile(strUrlNewVison, strTempFile)

        Dim fileReader As System.IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader(strTempFile)

        NewVersion = fileReader.ReadLine()

        '比较版本
        Dim MyVersion As String   '本地版本
        MyVersion = My.Application.Info.Version.Major &
        Strings.Format(My.Application.Info.Version.Minor, "00") &
     Strings.Format(My.Application.Info.Version.Build, "00") &
     Strings.Format(My.Application.Info.Version.Revision, "00")

        If NewVersion <> "" Then
            'Dim shortMyversion As Long
            'Dim shortNewVersion As Long

            'shortMyversion = ShortVersion(MyVersion)
            'shortNewVersion = ShortVersion(NewVersion)

            If NewVersion > MyVersion Then
                Return NewVersion
            Else
                Return "Null"
            End If
        Else
            Return "Null"
        End If

    End Function
End Class
