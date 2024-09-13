''Imports FSLib.App.SimpleUpdater
Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.IO


Module NewUpdater
    Public Server As String  '服务器，包含/
    Public ServerExcelFileName As String  '服务器的excel
    Public SimpleUpdater As String  '局域网更新程序
    Public NewVersionTxt As String  '局域网版本文件

    Const pmhker = "https://www.pmhker.com/article/75.html"

    Public Sub Shell_XHUpdater()
        '获取本地插件版本
        Dim strOldVersion As String

        strOldVersion = My.Application.Info.Version.Major & "." & _
            My.Application.Info.Version.Minor & "." & _
            Format(My.Application.Info.Version.Build, "00") & "." & _
           Format(My.Application.Info.Version.Revision, "00")

        '写本地版本文件
        Dim strTempFile As String = IO.Path.Combine(IO.Path.GetTempPath, "OldVison.txt")

        ' 使用Using语句确保资源被正确释放
        Using writer As StreamWriter = New StreamWriter(strTempFile)
            ' 将字符串写入文件
            writer.Write(strOldVersion)
        End Using

        '启动升级程序
        strTempFile = Path.Combine(My.Application.Info.DirectoryPath, "XHUpdater.exe")

        If IsFileExsts(strTempFile) = True Then
            Process.Start(strTempFile)
        Else
            MsgBox("未找到升级程序  XHUpdater.exe，请到 www.pmhker.com 重新下载安装文件！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information)

            'Process.Start(pmhker)
        End If


    End Sub



    ''Public NewVersion As String


    'Public Function Check_NewVison() As Boolean
    '    '检查局域网更新
    '    'If Check_LAN() = True Then
    '    '    Exit Function
    '    'End If

    '    '检查互联网更新
    '    Check_Internet()
    'End Function

    ''检查局域网更新
    'Public Function Check_LAN() As Boolean
    '    On Error Resume Next

    '    '检查局域网共享目录
    '    If IO.Directory.Exists(Server) = False Then
    '        Return False
    '    End If

    '    '设置局域网新版文件地址
    '    Dim strTempFile As String
    '    strTempFile = IO.Path.Combine(Server, NewVersionTxt)

    '    '检查新版文件地址
    '    If IO.File.Exists(strTempFile) = False Then
    '        Return False
    '    End If

    '    '读取新版文件
    '    Dim fileReader As System.IO.StreamReader
    '    fileReader = My.Computer.FileSystem.OpenTextFileReader(strTempFile)

    '    Dim strNewVersion As String
    '    strNewVersion = fileReader.ReadLine()

    '    '未获取版本，退出
    '    If strNewVersion Is Nothing Then
    '        Return False
    '    End If

    '    '获取本地插件版本
    '    Dim strOldVersion As String

    '    strOldVersion = My.Application.Info.Version.Major & "." & _
    '        My.Application.Info.Version.Minor & "." & _
    '        Format(My.Application.Info.Version.Build, "00") & "." & _
    '       Format(My.Application.Info.Version.Revision, "00")

    '    '获取无.的版本号
    '    Dim intNewVersion As Integer
    '    Dim intOldVersion As Integer
    '    intNewVersion = Val(Strings.Replace(strNewVersion, ".", ""))
    '    intOldVersion = Val(Strings.Replace(strOldVersion, ".", ""))

    '    '比较版本
    '    If intNewVersion > intOldVersion Then

    '        Dim strSimpleUpdater As String  ' = "SimpleUpdater.exe"

    '        strSimpleUpdater = Path.Combine(My.Application.Info.DirectoryPath, SimpleUpdater)

    '        If IsFileExsts(strSimpleUpdater) = False Then
    '            Dim strNewSimpleUpdater As String = Server & SimpleUpdater
    '            My.Computer.Network.DownloadFile(strNewSimpleUpdater, strSimpleUpdater)
    '        End If

    '        Dim DisplayVersion As String = 2015

    '        Dim strArguments As String

    '        'SimpleUpdater.exe /startupdate /cv "1.2.3.4" /url "\\likai-pc\发行版\更新包\2015\{0}" /infofile "update.xml" /p "Inventor.exe" /hideCheckUI

    '        strArguments = "/startupdate /cv """ & strOldVersion & """  /url """ & Server & DisplayVersion & "\{0}"" /infofile ""update.xml""  /p ""Inventor.exe"" /hideCheckUI"

    '        Process.Start(strSimpleUpdater, strArguments)

    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function


    'Public Function Check_Internet() As Boolean
    '    Dim strTempFile As String

    '    '下载捡得有网页
    '    'strTempFile = GetHtmlFromPmhker()

    '    strTempFile = Path.Combine(IO.Path.GetTempPath, "pmhker.txt")

    '    '没有下载到就退出
    '    If strTempFile = "0" Then
    '        Return False
    '    End If

    '    '分析网页，得到 新的版本文件和更新包文件
    '    Dim strUrl(1) As String
    '    strUrl = GetUpdateInfo(strTempFile)

    '    '获取网络版本
    '    Dim strNewVersion As String
    '    strNewVersion = GetWebNewVison(strUrl(0))

    '    '获取本地插件版本
    '    Dim strOldVersion As String

    '    strOldVersion = My.Application.Info.Version.Major & "." & _
    '        My.Application.Info.Version.Minor & "." & _
    '        Format(My.Application.Info.Version.Build, "00") & "." & _
    '       Format(My.Application.Info.Version.Revision, "00")

    '    '获取无.的版本号
    '    Dim intNewVersion As Integer
    '    Dim intOldVersion As Integer
    '    intNewVersion = Val(Strings.Replace(strNewVersion, ".", ""))
    '    intOldVersion = Val(Strings.Replace(strOldVersion, ".", ""))

    '    '比较版本
    '    If intNewVersion > intOldVersion Then
    '        If MsgBox("发现新版 XHTool，版本号" & strNewVersion & "，是否更新？", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

    '            strTempFile = Path.Combine(My.Application.Info.DirectoryPath, "Updata.zip")

    '            DownNetFile(strUrl(1), strTempFile)

    '            strTempFile = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "UpdaterForInAI.exe")


    '            Process.Start(strTempFile)
    '        End If
    '    End If

    '    Return True
    'End Function

    'Public Function GetWebNewVison(ByVal strUrlNewVison As String) As String
    '    Dim strTempFile As String

    '    '下载本版文件
    '    strTempFile = IO.Path.GetTempPath & "NewVison.txt"

    '    DownNetFile(strUrlNewVison, strTempFile)

    '    If IsFileExsts(strTempFile) = False Then
    '        Return "0"
    '    End If

    '    Dim fileReader As System.IO.StreamReader
    '    fileReader = My.Computer.FileSystem.OpenTextFileReader(strTempFile)

    '    Dim NewVersion As String = fileReader.ReadLine()

    '    Return NewVersion

    '    '   '比较版本
    '    '   Dim MyVersion As String   '本地版本
    '    '   MyVersion = My.Application.Info.Version.Major &
    '    '   Strings.Format(My.Application.Info.Version.Minor, "00") &
    '    'Strings.Format(My.Application.Info.Version.Build, "00") &
    '    'Strings.Format(My.Application.Info.Version.Revision, "00")

    '    '   If NewVersion <> "" Then
    '    '       'Dim shortMyversion As Long
    '    '       'Dim shortNewVersion As Long

    '    '       'shortMyversion = ShortVersion(MyVersion)
    '    '       'shortNewVersion = ShortVersion(NewVersion)

    '    '       If NewVersion > MyVersion Then
    '    '           Return NewVersion
    '    '       Else
    '    '           Return "Null"
    '    '       End If
    '    '   Else
    '    '       Return "Null"
    '    '   End If

    'End Function

    'Public Function GetHtmlFromPmhker() As String
    '    Const pmhker = "https://www.pmhker.com/article/75.html"

    '    Dim strTempFile As String = Path.Combine(IO.Path.GetTempPath, "pmhker.txt")

    '    DownNetFile(pmhker, strTempFile)

    '    Dim fileInfo As New FileInfo(strTempFile)

    '    ' 获取文件大小（以字节为单位）
    '    Dim fileSize As Long = fileInfo.Length

    '    If fileSize < 100 Then
    '        strTempFile = "0"
    '    End If

    '    Return strTempFile

    'End Function

    ''分析网页信息
    'Public Function GetUpdateInfo(ByVal strTempFile As String) As String()
    '    On Error Resume Next
    '    Dim strUrl(1) As String
    '    Dim content As String = System.IO.File.ReadAllText(strTempFile)

    '    Dim startKeyword As String = "附件2：<a href="""
    '    Dim endKeyword As String = """ download=""NewVersion.txt"">NewVersion.txt</a>"
    '    Dim startIndex As Integer = content.IndexOf(startKeyword) + startKeyword.Length
    '    Dim endIndex As Integer = content.IndexOf(endKeyword)
    '    Dim strNewVison As String

    '    strNewVison = content.Substring(startIndex, endIndex - startIndex).Trim()

    '    startKeyword = "附件3：<a href="""
    '    endKeyword = """ download=""Updata.zip"">Updata.zip</a>"
    '    startIndex = content.IndexOf(startKeyword) + startKeyword.Length
    '    endIndex = content.IndexOf(endKeyword)
    '    Dim strUpdatazip As String

    '    strUpdatazip = content.Substring(startIndex, endIndex - startIndex).Trim()

    '    strUrl = {strNewVison, strUpdatazip}

    '    Return strUrl

    'End Function


    ''Public Sub CheckPmhker()
    ''    Dim strTempFile As String

    ''    '分析网页，得到 新的版本文件和更新包文件
    ''    Dim strUrl(1) As String
    ''    strUrl = GetUpdateInfo(strTempFile)

    ''    Dim strNewVison As String
    ''    strNewVison = GetNewVison2(strUrl(0))

    ''    If strNewVison <> "Null" Then
    ''        If MsgBox("发现新版 XiHanTool，版本号" & strNewVison & "，是否更新？", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
    ''            strTempFile = System.IO.Path.Combine(IO.Path.GetTempPath, "UpdateZip.txt")

    ''            If Not System.IO.File.Exists(strTempFile) Then
    ''                ' 创建一个新的文件
    ''                System.IO.File.Create(strTempFile).Dispose()
    ''            End If

    ''            ' 写入更新包地址文件中
    ''            System.IO.File.WriteAllText(strTempFile, strUrl(1))


    ''            strTempFile = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "UpdaterForInAI.exe")

    ''            Process.Start(strTempFile)
    ''        End If
    ''    End If

    ''End Sub

    ''下载文件
    'Public Sub DownNetFile(ByVal nUrl As String, ByVal nFile As String)
    '    On Error Resume Next
    '    Dim XmlHttp As Object
    '    Dim B() As Byte

    '    XmlHttp = CreateObject("Microsoft.XMLHTTP")

    '    XmlHttp.Open("GET", nUrl, False)

    '    XmlHttp.Send()

    '    If XmlHttp.ReadyState = 4 Then
    '        B = XmlHttp.ResponseBody
    '        My.Computer.FileSystem.WriteAllBytes(nFile, B, False)
    '    End If
    '    XmlHttp = Nothing

    'End Sub


End Module

'Module NewUpdater



'    'Public Sub UpDater1()
'    '    Try

'    '        '  Updater.CheckUpdateSimple("\\likai-pc\发行版\更新包\{0}", "update.xml")

'    '        Dim UpdaterInstance = FSLib.App.SimpleUpdater.Updater.CreateUpdaterInstance()

'    '        With UpdaterInstance.Context
'    '            .UpdateDownloadUrl = "\\likai-pc\发行版\更新包\{0}"   '获得或设置用于更新的模板地址
'    '            .UpdateInfoFileName = "update.xml"                      '获得或设置更新时使用的 XML 文件名

'    '            .MultipleDownloadCount = 5                      '获得或设置同时下载的文件数，默认为 3

'    '        End With

'    '        '开始更新

'    '        UpdaterInstance.BeginCheckUpdateInProcess()
'    '        UpdaterInstance.Dispose()

'    '    Catch ex As Exception
'    '        'MsgBox(ex.Message)
'    '    End Try
'    'End Sub

'    Public Function CheckNewVesion() As String
'        Try
'            Dim NewVersionInfo As String

'            If Strings.Right(Server, 1) = "\" Then
'                NewVersionInfo = Server & NewVersionTxt
'            Else
'                NewVersionInfo = Server & "\" & NewVersionTxt
'            End If

'            'Dim fileReader As System.IO.StreamReader
'            'fileReader = My.Computer.FileSystem.OpenTextFileReader(NewVersionInfo)
'            'NewVersion = fileReader.ReadLine()
'            'fileReader.Close()
'            'fileReader.Dispose()

'            NewVersion = System.IO.File.ReadAllText(NewVersionInfo)
'            'MsgBox(NewVersion)

'            MyVersion = My.Application.Info.Version.Major &
'        Format(My.Application.Info.Version.Minor, "00") &
'    Format(My.Application.Info.Version.Build, "00") &
'    Format(My.Application.Info.Version.Revision, "00")

'            'MsgBox(MyVersion)

'            If NewVersion <> "" Then
'                'Dim shortMyversion As Long
'                'Dim shortNewVersion As Long

'                'shortMyversion = ShortVersion(MyVersion)
'                'shortNewVersion = ShortVersion(NewVersion)

'                If NewVersion > MyVersion Then
'                    Return "New"
'                Else
'                    Return "Null"
'                End If
'            Else
'                Return "Null"
'            End If
'        Catch ex As Exception
'            'MsgBox(ex.Message)
'            Return "Null"
'        End Try

'    End Function

'    Public Function ShortVersion(ByVal LongVesion As String) As Long

'        ShortVersion = Val(Strings.Replace(LongVesion, ".", ""))

'        Return ShortVersion
'    End Function

'    Public Sub UpDate3()
'        Try
'            Dim strSimpleUpdater As String

'            strSimpleUpdater = My.Application.Info.DirectoryPath

'            If Strings.Right(strSimpleUpdater, 1) = "\" Then
'                strSimpleUpdater = strSimpleUpdater & SimpleUpdater
'            Else
'                strSimpleUpdater = strSimpleUpdater & "\" & SimpleUpdater
'            End If

'            If IsFileExsts(strSimpleUpdater) = False Then
'                Dim strNewSimpleUpdater As String = Server & SimpleUpdater
'                My.Computer.Network.DownloadFile(strNewSimpleUpdater, strSimpleUpdater)
'            End If

'            MyVersion = _
'                  My.Application.Info.Version.Major & "." & _
'                  My.Application.Info.Version.Minor & "." & _
'                My.Application.Info.Version.Build & "." & _
'               My.Application.Info.Version.Revision


'            Select Case DisplayVersion
'                'Case Is >= 2016
'                '    DisplayVersion = 2016
'                Case Is >= 2015
'                    DisplayVersion = 2015
'                Case Is >= 2011
'                    DisplayVersion = 2011
'            End Select

'            Dim strArguments As String

'            'SimpleUpdater.exe /startupdate /cv "1.2.3.4" /url "\\likai-pc\发行版\更新包\2015\{0}" /infofile "update.xml" /p "Inventor.exe" /hideCheckUI

'            strArguments = "/startupdate /cv """ & MyVersion & """  /url """ & Server & DisplayVersion & "\{0}"" /infofile ""update.xml""  /p ""Inventor.exe"" /hideCheckUI"

'            If IsFileExsts(strSimpleUpdater) = True Then
'                Process.Start(strSimpleUpdater, strArguments)
'            End If

'        Catch ex As Exception
'            MsgBox(ex.Message)
'        End Try
'    End Sub

'    Public Function GetGitVersion() As String
'        On Error Resume Next
'        Dim strGitVersionText As String = "https://gitcode.net/leaky114/inventoraddin/-/raw/master/Release/NewVison.txt?inline=false"

'        'Dim strGitVersionText As String = "https://github.com/leaky114/InAI/blob/master/Release/NewVison.txt"

'        Dim strLocalVersionText As String

'        strLocalVersionText = My.Application.Info.DirectoryPath

'        If Strings.Right(strLocalVersionText, 1) = "\" Then
'            strLocalVersionText = strLocalVersionText & "NewVison.txt"
'        Else
'            strLocalVersionText = strLocalVersionText & "\NewVison.txt"
'        End If

'        'My.Computer.Network.DownloadFile(strGitVersionText, strLocalVersionText)

'        DownNetFile(strGitVersionText, strLocalVersionText)

'        Dim fileReader As System.IO.StreamReader
'        fileReader = My.Computer.FileSystem.OpenTextFileReader(strLocalVersionText)

'        NewVersion = fileReader.ReadLine()

'        'MsgBox(NewVersion)

'        MyVersion = My.Application.Info.Version.Major &
'          Format(My.Application.Info.Version.Minor, "00") &
'      Format(My.Application.Info.Version.Build, "00") &
'      Format(My.Application.Info.Version.Revision, "00")

'        'MsgBox(MyVersion)

'        If NewVersion <> "" Then
'            'Dim shortMyversion As Long
'            'Dim shortNewVersion As Long

'            'shortMyversion = ShortVersion(MyVersion)
'            'shortNewVersion = ShortVersion(NewVersion)

'            If NewVersion > MyVersion Then
'                Return "New"
'            Else

'                Return "Null"
'            End If
'        Else
'            Return "Null"
'        End If

'    End Function

'Public Function CreateUpdateExe() As Boolean
'    Try

'        Dim path As String = ThisApplication.InstallPath & "Bin\SimpleUpdater.exe" '文件释放路径

'        if IsFileExsts(path) = False Then

'            Dim resources As System.Resources.ResourceManager = My.Resources.ResourceManager
'            Dim b() As Byte = resources.GetObject("SimpleUpdaterexe")
'            Dim s As IO.Stream
'            s = IO.File.Create(path)
'            s.Write(b, 0, b.Length)
'            s.Close()

'            'path = ThisApplication.InstallPath & "Bin\SimpleUpdater.exe.config" '文件释放路径

'            'b = resources.GetObject("SimpleUpdaterexeconfig")
'            's = IO.File.Create(path)
'            's.Write(b, 0, b.Length)
'            's.Close()
'        End if

'        'MessageBox.Show("资源释放成功")
'        Return True
'    Catch ex As Exception
'        'MessageBox.Show("资源释放失败！Result=" + ex.Message)
'    End Try
'End Function



'End Module