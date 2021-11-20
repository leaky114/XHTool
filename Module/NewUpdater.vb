Imports FSLib.App.SimpleUpdater
Module NewUpdater

    Const InNewVisonTXT As String = "\\Likai-pc\发行版\2011\NewVersion.txt"
    Const GitWeb As String = "https://codechina.csdn.net/leaky114/inventoraddin"


    Public Sub UpDater1()
        Try

            '  Updater.CheckUpdateSimple("\\likai-pc\发行版\更新包\{0}", "update.xml")

            Dim UpdaterInstance = FSLib.App.SimpleUpdater.Updater.CreateUpdaterInstance()

            With UpdaterInstance.Context
                .UpdateDownloadUrl = "\\likai-pc\发行版\更新包\{0}"   '获得或设置用于更新的模板地址
                .UpdateInfoFileName = "update.xml"                      '获得或设置更新时使用的 XML 文件名

                .MultipleDownloadCount = 5                      '获得或设置同时下载的文件数，默认为 3

            End With

            '开始更新

            UpdaterInstance.BeginCheckUpdateInProcess()

            UpdaterInstance.Dispose()

        Catch ex As Exception


            'MsgBox(ex.Message)

        End Try
    End Sub

    Public Sub UpDater2(ByVal IsPutOutMsg As Boolean)
        Try

            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader(InNewVisonTXT)
            Dim NewVersion As String
            NewVersion = fileReader.ReadLine()
            fileReader.Close()
            'MsgBox(NewVersion)

            Dim MyVersion As String = _
            My.Application.Info.Version.Major & "." & _
            My.Application.Info.Version.Minor & "." & _
            Format(My.Application.Info.Version.Build, "00") & "." & _
           Format(My.Application.Info.Version.Revision, "00")

            'MsgBox(MyVersion)


            If NewVersion <> "" Then
                Dim shortMyversion As Long
                Dim shortNewVersion As Long

                shortMyversion = ShortVersion(MyVersion)
                shortNewVersion = ShortVersion(NewVersion)

                If shortNewVersion > shortMyversion Then
                    MsgBox("InventorAddIn插件" & vbCrLf & "当前版本：" & MyVersion & vbCrLf & "检查到 新版本：" & NewVersion, MsgBoxStyle.OkOnly, " 检查更新")

                    Dim simupdate As String

                    simupdate = My.Application.Info.DirectoryPath & "\simupdater.exe"
                    If IsFileExsts(simupdate) = True Then
                        Process.Start(simupdate)
                    Else
                        MsgBox("缺失升级程序 simupdater.exe，请到本软件仓库下载。", MsgBoxStyle.OkOnly, "检查更新")
                        Process.Start(GitWeb)
                    End If
                Else
                    If IsPutOutMsg = True Then
                        MsgBox("当前是最新版本。", MsgBoxStyle.OkOnly, "检查更新")
                    End If
                End If
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
            MsgBox("未链接到服务器。", MsgBoxStyle.OkOnly, "检查更新")
        End Try
    End Sub

    Public Function ShortVersion(ByVal LongVesion As String) As Long

        ShortVersion = Val(Strings.Replace(LongVesion, ".", ""))

        Return ShortVersion
    End Function

End Module
