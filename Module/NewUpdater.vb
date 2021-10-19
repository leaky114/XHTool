Imports FSLib.App.SimpleUpdater
Module NewUpdater

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
<<<<<<< HEAD
            MsgBox(ex.Message)
=======
            'MsgBox(ex.Message)
>>>>>>> c3706ff (新增重新BOM序号与排序)
        End Try
    End Sub

    Public Sub UpDater2()
        Try
            Dim simupdate As String = "\\Likai-pc\发行版\2011\NewVersion.txt"

            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader(simupdate)
            Dim NewVersion As String
            NewVersion = fileReader.ReadLine()

            'MsgBox(NewVersion)

            Dim MyVersion As String = _
            My.Application.Info.Version.Major & "." & _
            My.Application.Info.Version.Minor & "." & _
            My.Application.Info.Version.Build & "." & _
            My.Application.Info.Version.Revision

            'MsgBox(MyVersion)

            If NewVersion <> "" Then
<<<<<<< HEAD
                If NewVersion <> MyVersion Then

=======
                Dim shortMyversion As Long
                Dim shortNewVersion As Long

                shortMyversion = ShortVersion(MyVersion)
                shortNewVersion = ShortVersion(NewVersion)

                If shortNewVersion > shortMyversion Then
                    MsgBox("InventorAddIn插件" & vbCrLf & "当前版本：" & MyVersion & vbCrLf & "检查到 新版本：" & NewVersion, MsgBoxStyle.OkOnly, " 检查更新")
>>>>>>> c3706ff (新增重新BOM序号与排序)
                    simupdate = My.Application.Info.DirectoryPath & "\simupdater.exe"
                    Process.Start(simupdate)

                End If
            End If
        Catch ex As Exception
<<<<<<< HEAD
            MsgBox(ex.Message)

        End Try



    End Sub
=======
            'MsgBox(ex.Message)

        End Try

    End Sub

    Public Function ShortVersion(ByVal LongVesion As String) As Long

        ShortVersion = Val(Strings.Replace(LongVesion, ".", ""))

        Return ShortVersion
    End Function

>>>>>>> c3706ff (新增重新BOM序号与排序)
End Module
