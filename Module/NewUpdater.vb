'Imports FSLib.App.SimpleUpdater
Imports System.Windows.Forms
Module NewUpdater

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
            Dim NewVersionInfo As String = "\\Likai-pc\发行版\更新包\NewVersion.txt"

            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader(NewVersionInfo)

            NewVersion = fileReader.ReadLine()

            'MsgBox(NewVersion)

            MyVersion = My.Application.Info.Version.Minor & _
          Format(My.Application.Info.Version.Build, "00") & _
          Format(My.Application.Info.Version.Revision, "00")

            'MsgBox(MyVersion)

            If NewVersion <> "" Then
                Dim shortMyversion As Long
                Dim shortNewVersion As Long

                shortMyversion = ShortVersion(MyVersion)
                shortNewVersion = ShortVersion(NewVersion)

                If shortNewVersion > shortMyversion Then
                    'MsgBox("InventorAddIn插件" & vbCrLf & "当前版本：" & MyVersion & vbCrLf & "检查到 新版本：" & NewVersion, MsgBoxStyle.OkOnly, " 检查更新")
                    'simupdate = My.Application.Info.DirectoryPath & "\simupdater.exe"
                    'Process.Start(simupdate)

                    'btnCheckUpDate.Text = "检查到新版" & NewVersion

                    'Return NewVersion
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

            strSimpleUpdater = ThisApplication.InstallPath & "\Bin\SimpleUpdater.exe"

            If IsFileExsts(strSimpleUpdater) = False Then
                Dim strNewSimpleUpdater As String = "\\Likai-pc\发行版\更新包\SimpleUpdater.exe"
                My.Computer.Network.DownloadFile(strNewSimpleUpdater, strSimpleUpdater)
            End If

            MyVersion = _
                   My.Application.Info.Version.Major & "." & _
                   My.Application.Info.Version.Minor & "." & _
                 Format(My.Application.Info.Version.Build, "00") & "." & _
                 Format(My.Application.Info.Version.Revision, "00")

            Dim DisplayVersion As String
            DisplayVersion = ThisApplication.SoftwareVersion.DisplayVersion

            Select Case DisplayVersion
                Case Is >= 2015
                    DisplayVersion = 2015
                Case Is >= 2011
                    DisplayVersion = 2011
            End Select

            Dim strArguments As String

            'SimpleUpdater.exe /startupdate /cv "1.2.3.4" /url "\\likai-pc\发行版\更新包\2015\{0}" /infofile "update.xml" /p "Inventor.exe" /hideCheckUI

            strArguments = "/startupdate /cv """ & MyVersion & """ /url  ""\\likai-pc\发行版\更新包\" & DisplayVersion & "\{0}"" /infofile ""update.xml""  /p ""Inventor.exe"" /hideCheckUI"

            If IsFileExsts(strSimpleUpdater) = True Then
                Process.Start(strSimpleUpdater, strArguments)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Public Function CreateUpdateExe() As Boolean
    '    Try

    '        Dim path As String = ThisApplication.InstallPath & "Bin\SimpleUpdater.exe" '文件释放路径

    '        If IsFileExsts(path) = False Then

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
    '        End If

    '        'MessageBox.Show("资源释放成功")
    '        Return True
    '    Catch ex As Exception
    '        'MessageBox.Show("资源释放失败！Result=" + ex.Message)
    '    End Try
    'End Function

End Module