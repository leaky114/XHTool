'Imports FSLib.App.SimpleUpdater
Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Module NewUpdater

    Public Server As String  '服务器，包含/
    Public ServerExcelFileName As String  '服务器的excel
    Public SimpleUpdater As String
    Public NewVersionTxt As String

    Public NewVersion As String
    Public MyVersion As String

    'Public Sub UpDater1()
    '    Try

    '        '  Updater.CheckUpdateSimple("\\likai-pc\发行版\更新包\{0}", "update.xml")

    '        Dim UpdaterInstance = FSLib.App.SimpleUpdater.Updater.CreateUpdaterInstance()

    '        With UpdaterInstance.Context
    '            .UpdateDownloadUrl = "\\likai-pc\发行版\更新包\{0}"   '获得或设置用于更新的模板地址
    '            .UpdateInfoFileName = "update.xml"                      '获得或设置更新时使用的 XML 文件名

    '            .MultipleDownloadCount = 5                      '获得或设置同时下载的文件数，默认为 3

    '        End With

    '        '开始更新

    '        UpdaterInstance.BeginCheckUpdateInProcess()
    '        UpdaterInstance.Dispose()

    '    Catch ex As Exception
    '        'MsgBox(ex.Message)
    '    End Try
    'End Sub

    Public Function CheckNewVesion() As String
        Try
            Dim NewVersionInfo As String

            If Strings.Right(Server, 1) = "\" Then
                NewVersionInfo = Server & NewVersionTxt
            Else
                NewVersionInfo = Server & "\" & NewVersionTxt
            End If

            'Dim fileReader As System.IO.StreamReader
            'fileReader = My.Computer.FileSystem.OpenTextFileReader(NewVersionInfo)
            'NewVersion = fileReader.ReadLine()
            'fileReader.Close()
            'fileReader.Dispose()

            NewVersion = System.IO.File.ReadAllText(NewVersionInfo)
            'MsgBox(NewVersion)

            MyVersion = My.Application.Info.Version.Major &
        Format(My.Application.Info.Version.Minor, "00") &
    Format(My.Application.Info.Version.Build, "00") &
    Format(My.Application.Info.Version.Revision, "00")

            'MsgBox(MyVersion)

            If NewVersion <> "" Then
                'Dim shortMyversion As Long
                'Dim shortNewVersion As Long

                'shortMyversion = ShortVersion(MyVersion)
                'shortNewVersion = ShortVersion(NewVersion)

                If NewVersion > MyVersion Then
                    Return "New"
                Else
                    Return "Null"
                End If
            Else
                Return "Null"
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return "Null"
        End Try

    End Function

    Public Function ShortVersion(ByVal LongVesion As String) As Long

        ShortVersion = Val(Strings.Replace(LongVesion, ".", ""))

        Return ShortVersion
    End Function

    Public Sub UpDate3()
        Try
            Dim strSimpleUpdater As String

            strSimpleUpdater = My.Application.Info.DirectoryPath

            If Strings.Right(strSimpleUpdater, 1) = "\" Then
                strSimpleUpdater = strSimpleUpdater & SimpleUpdater
            Else
                strSimpleUpdater = strSimpleUpdater & "\" & SimpleUpdater
            End If

            If IsFileExsts(strSimpleUpdater) = False Then
                Dim strNewSimpleUpdater As String = Server & SimpleUpdater
                My.Computer.Network.DownloadFile(strNewSimpleUpdater, strSimpleUpdater)
            End If

            MyVersion = _
                  My.Application.Info.Version.Major & "." & _
                  My.Application.Info.Version.Minor & "." & _
                My.Application.Info.Version.Build & "." & _
               My.Application.Info.Version.Revision


            Select Case DisplayVersion
                'Case Is >= 2016
                '    DisplayVersion = 2016
                Case Is >= 2015
                    DisplayVersion = 2015
                Case Is >= 2011
                    DisplayVersion = 2011
            End Select

            Dim strArguments As String

            'SimpleUpdater.exe /startupdate /cv "1.2.3.4" /url "\\likai-pc\发行版\更新包\2015\{0}" /infofile "update.xml" /p "Inventor.exe" /hideCheckUI

            strArguments = "/startupdate /cv """ & MyVersion & """  /url """ & Server & DisplayVersion & "\{0}"" /infofile ""update.xml""  /p ""Inventor.exe"" /hideCheckUI"

            If IsFileExsts(strSimpleUpdater) = True Then
                Process.Start(strSimpleUpdater, strArguments)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function GetGitVersion() As String
        On Error Resume Next
        Dim strGitVersionText As String = "https://gitcode.net/leaky114/inventoraddin/-/raw/master/Release/NewVison.txt?inline=false"

        'Dim strGitVersionText As String = "https://github.com/leaky114/InAI/blob/master/Release/NewVison.txt"

        Dim strLocalVersionText As String

        strLocalVersionText = My.Application.Info.DirectoryPath

        If Strings.Right(strLocalVersionText, 1) = "\" Then
            strLocalVersionText = strLocalVersionText & "NewVison.txt"
        Else
            strLocalVersionText = strLocalVersionText & "\NewVison.txt"
        End If

        'My.Computer.Network.DownloadFile(strGitVersionText, strLocalVersionText)

        DownNetFile(strGitVersionText, strLocalVersionText)

        Dim fileReader As System.IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader(strLocalVersionText)

        NewVersion = fileReader.ReadLine()

        'MsgBox(NewVersion)

        MyVersion = My.Application.Info.Version.Major &
          Format(My.Application.Info.Version.Minor, "00") &
      Format(My.Application.Info.Version.Build, "00") &
      Format(My.Application.Info.Version.Revision, "00")

        'MsgBox(MyVersion)

        If NewVersion <> "" Then
            'Dim shortMyversion As Long
            'Dim shortNewVersion As Long

            'shortMyversion = ShortVersion(MyVersion)
            'shortNewVersion = ShortVersion(NewVersion)

            If NewVersion > MyVersion Then
                Return "New"
            Else

                Return "Null"
            End If
        Else
            Return "Null"
        End If

    End Function

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

End Module