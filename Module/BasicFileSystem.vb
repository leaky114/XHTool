Imports System.IO
Imports System.Text
Imports System.Text.Encoding
Imports System.IO.FileStream
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.FileIO
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

Module BasicFileSystem

    '文件名结构
    Public Structure FileNameInfo
        Public Folder As String     '文件夹
        Public SigleName As String  '文件名+扩展名
        Public OnlyName As String  '仅文件名
        Public ExtensionName As String  '扩展名
    End Structure

    '读取文件(文件名)
    Public Function ReadTextFile(ByVal strFullFileName As String) As String
        Dim oStreamReader As New StreamReader(strFullFileName, Encoding.Default)
        Dim FileText = oStreamReader.ReadToEnd()
        oStreamReader.Close()
        Return FileText
    End Function

    '判断文件是否存在(文件名)
    Public Function IsFileExsts(ByVal strFullFileName As String) As Boolean
        IsFileExsts = My.Computer.FileSystem.FileExists(strFullFileName)
    End Function

    '判断文件夹是否存在(文件夹)
    Public Function IsDirectoryExists(ByVal strDirectoryFullName As String) As Boolean
        IsDirectoryExists = My.Computer.FileSystem.DirectoryExists(strDirectoryFullName)
    End Function

    '获取文件所在文件夹(文件名)
    Public Function GetParentFolder(ByVal strFullFileName As String) As String
        If IsFileExsts(strFullFileName) = True Then
            GetParentFolder = My.Computer.FileSystem.GetFileInfo(strFullFileName).DirectoryName
        Else
            Dim i As Integer
            Dim strTemp As String
            strTemp = strFullFileName
            i = InStrRev(strTemp, "\")
            GetParentFolder = Strings.Left(strTemp, i - 1)
        End If
    End Function

    '从全名中取出文件名,含扩展名(文件名)
    Public Function GetSingleName(ByVal strFullFileName As String) As String
        If IsFileExsts(strFullFileName) = True Then
            GetSingleName = My.Computer.FileSystem.GetName(strFullFileName)
        Else
            Dim p As Integer
            p = InStrRev(strFullFileName, "\")
            If p > 0 Then
                GetSingleName = Strings.Right(strFullFileName, Strings.Len(strFullFileName) - p)
            Else
                GetSingleName = ""
            End If
        End If

    End Function

    '从全名中取出文件名简称,去除路径及扩展名(文件名)
    Public Function GetOnlyname(ByVal strFullFileName As String) As String
        If IsFileExsts(strFullFileName) = True Then
            Dim strFileName As String
            Dim strFileExtension As String

            strFileName = My.Computer.FileSystem.GetName(strFullFileName)
            strFileExtension = My.Computer.FileSystem.GetFileInfo(strFullFileName).Extension
            GetOnlyname = Microsoft.VisualBasic.Strings.Replace(strFileName, strFileExtension, "")
        Else
            Dim i As Integer
            Dim strTemp As String
            strTemp = strFullFileName
            i = InStrRev(strTemp, "\")
            strTemp = Strings.Right(strTemp, Len(strTemp) - i)
            i = InStrRev(strTemp, ".")
            strTemp = Strings.Left(strTemp, i - 1)
            GetOnlyname = strTemp
        End If
    End Function

    '大写扩展名(文件名)
    Public Function UCaseGetFileExtension(ByVal strFullFileName As String) As String
        If IsFileExsts(strFullFileName) = True Then
            UCaseGetFileExtension = UCase(My.Computer.FileSystem.GetFileInfo(strFullFileName).Extension)
        Else
            Dim i As Integer
            Dim strTemp As String
            strTemp = strFullFileName
            i = InStrRev(strTemp, ".")
            strTemp = Strings.Right(strTemp, Len(strTemp) - i + 1)
            UCaseGetFileExtension = UCase(strTemp)
        End If
    End Function

    '小写扩展名(文件名)
    Public Function LCaseGetFileExtension(ByVal strFullFileName As String) As String
        If IsFileExsts(strFullFileName) = True Then
            LCaseGetFileExtension = LCase(My.Computer.FileSystem.GetFileInfo(strFullFileName).Extension)
        Else
            Dim i As Integer
            Dim strTemp As String
            strTemp = strFullFileName
            i = InStrRev(strTemp, ".")
            strTemp = Strings.Right(strTemp, Len(strTemp) - i + 1)
            LCaseGetFileExtension = LCase(strTemp)
        End If
    End Function

    '获取filenameinfo结构(文件名)
    Public Function GetFileNameInfo(ByVal strFullFileName As String) As FileNameInfo
        Dim FNI As FileNameInfo = Nothing
        If IsFileExsts(strFullFileName) = True Then
            FNI.Folder = My.Computer.FileSystem.GetFileInfo(strFullFileName).DirectoryName
            FNI.SigleName = My.Computer.FileSystem.GetName(strFullFileName)
            FNI.ExtensionName = My.Computer.FileSystem.GetFileInfo(strFullFileName).Extension  '这里有大小写问题
            FNI.OnlyName = Microsoft.VisualBasic.Strings.Replace(FNI.SigleName, FNI.ExtensionName, "")
        Else
            Dim i As Integer
            i = InStrRev(strFullFileName, "\")
            FNI.Folder = Strings.Left(strFullFileName, i - 1)

            FNI.SigleName = Strings.Right(strFullFileName, Strings.Len(strFullFileName) - Strings.Len(FNI.Folder) - 1)

            i = InStr(FNI.SigleName, ".")
            FNI.OnlyName = Left(FNI.SigleName, i - 1)
            FNI.ExtensionName = LCase(Strings.Right(FNI.SigleName, Strings.Len(FNI.SigleName) - Strings.Len(FNI.OnlyName)))
        End If
        Return FNI
    End Function

    '重命名(旧文件名,新文件名)
    Public Function ReFileName(ByVal strOldFullFileName As String, ByVal strNewFullFileName As String) As Boolean
        If IsFileExsts(strNewFullFileName) = False And IsFileExsts(strOldFullFileName) = True Then
            My.Computer.FileSystem.RenameFile(strOldFullFileName, GetSingleName(strNewFullFileName))
            ReFileName = IsFileExsts(strNewFullFileName)
        Else
            ReFileName = False
        End If
    End Function

    '只变更文件名，不操作，仅返回新的文件名
    Public Function GetNewFileName(ByVal strOldFullFileName As String, ByVal strNewFileName As String) As String
        Dim oFileNameInfo As FileNameInfo
        oFileNameInfo = GetFileNameInfo(strOldFullFileName)

        Dim strParentFolder As String
        strParentFolder = oFileNameInfo.Folder  'GetParentFolder(OldFullFileName)

        Dim strExtensionName As String
        strExtensionName = oFileNameInfo.ExtensionName

        GetNewFileName = strParentFolder & "\" & strNewFileName & strExtensionName

        Return GetNewFileName

    End Function

    '只变更扩展名，不操作，仅返回新的文件名
    Public Function GetNewExtensionFileName(ByVal strOldFullFileName As String, ByVal strNewExtensionName As String) As String
        Dim oFileNameInfo As FileNameInfo
        oFileNameInfo = GetFileNameInfo(strOldFullFileName)

        Dim strParentFolder As String   '文件夹
        strParentFolder = oFileNameInfo.Folder  'GetParentFolder(OldFullFileName)

        Dim OnlyName As String     '仅文件名
        OnlyName = oFileNameInfo.OnlyName

        GetNewExtensionFileName = strParentFolder & "\" & OnlyName & strNewExtensionName

        Return GetNewExtensionFileName

    End Function

    '判断2个文件是否在同一文件夹(第一个文件名,第二个文件名)
    Public Function IsInSameFolder(ByVal strOneFullFileName As String, ByVal strTowFullFileName As String) As Boolean
        Dim strOneFileFolder As String
        Dim strTowFileForlder As String
        strOneFileFolder = GetParentFolder(strOneFullFileName)
        strTowFileForlder = GetParentFolder(strTowFullFileName)
        If strOneFileFolder = strTowFileForlder Then
            IsInSameFolder = True
        Else
            IsInSameFolder = False
        End If
    End Function


    '删除一个文件(文件名,是否删除到回收站选项)
    Public Function DelFile(ByVal strFullFileName As String, ByVal oRecycleOption As FileIO.RecycleOption) As Boolean
        If IsFileExsts(strFullFileName) Then
            My.Computer.FileSystem.DeleteFile(strFullFileName, FileIO.UIOption.OnlyErrorDialogs, oRecycleOption, FileIO.UICancelOption.ThrowException)
        End If
        DelFile = IsFileExsts(strFullFileName) Xor True
    End Function

    '仅删除一个文件夹中的文件(文件夹)
    Public Function DelOnlyFileInForlder(ByVal strFolder As String) As Boolean
        If My.Computer.FileSystem.DirectoryExists(strFolder) Then
            For Each f As String In My.Computer.FileSystem.GetFiles(strFolder)
                DelFile(f, FileIO.RecycleOption.SendToRecycleBin)
            Next
        End If
    End Function

    '删除文件夹(文件夹)
    Public Function DelFolder(ByVal strFolder As String, ByVal intDeleteRecycleOption As Integer) As Boolean
        If My.Computer.FileSystem.DirectoryExists(strFolder) Then
            My.Computer.FileSystem.DeleteDirectory(strFolder, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, intDeleteRecycleOption)
            DelFolder = IsDirectoryExists(strFolder)
        Else
            DelFolder = False
        End If
    End Function

    '移动文件(源文件名,目标文件名)
    Public Function ReMoveFile(ByVal strSourceFileName As String, ByVal strDestinationFileName As String) As Boolean
        Dim strDestinationFolder As String
        strDestinationFolder = GetParentFolder(strDestinationFileName)
        If IsDirectoryExists(strDestinationFolder) = False Then
            My.Computer.FileSystem.CreateDirectory(strDestinationFolder)
        End If
        My.Computer.FileSystem.MoveFile(strSourceFileName, strDestinationFileName, True)
        Return IsFileExsts(strDestinationFileName)
    End Function

    '移动文件到文件夹(源文件名,目标文件夹)
    Public Function ReMoveFileToFolder(ByVal strSourceFileName As String, ByVal strDestinationFolder As String) As Boolean
        Dim strDestinationFileName As String
        If IsDirectoryExists(strDestinationFolder) = False Then
            My.Computer.FileSystem.CreateDirectory(strDestinationFolder)
        End If

        strDestinationFileName = strDestinationFolder & "\" & GetSingleName(strSourceFileName)
        If strSourceFileName <> strDestinationFileName Then
            My.Computer.FileSystem.MoveFile(strSourceFileName, strDestinationFileName, True)
        End If
        Return IsFileExsts(strDestinationFileName)
    End Function

    '扫描文件夹
    Public Sub GetAllFile(ByVal strBootFolder As String, ByVal strSourceFolder As String, ByVal olistbox As Object) ' ListBox)
        ' 源文件夹父文件夹 ,源文件夹 , 目标文件夹
        Dim strDir As String() = System.IO.Directory.GetDirectories(strSourceFolder)
        Dim strFile As String() = System.IO.Directory.GetFiles(strSourceFolder)
        Dim oFileInfo As FileInfo
        Dim i As Integer
        'If strDir.Length > 0 Then
        '    For i = 0 To strDir.Length - 1
        '        Debug.Print(strDir(i))
        '    Next
        'End If

        If strFile.Length > 0 Then
            For i = 0 To strFile.Length - 1
                'Debug.Print(strFile(i))
                oFileInfo = My.Computer.FileSystem.GetFileInfo(strFile(i))
                If (LCase(oFileInfo.Extension) = idw) And (Strings.InStr(oFileInfo.FullName, "OldVersions") = 0) Then
                    If IsItemInListView(olistbox, oFileInfo.FullName) = False Then
                        olistbox.Items.Add(oFileInfo.FullName)
                    End If
                End If
            Next
        End If
        If strDir.Length > 0 Then
            For i = 0 To strDir.Length - 1
                GetAllFile(strBootFolder, strDir(i), olistbox)
            Next
        End If
    End Sub

    '删除旧文件
    Public Sub DelOldFile(ByVal strBootFolder As String, ByVal DeletePermanently As Boolean)
        '  目标文件夹
        Dim strDir As String() = System.IO.Directory.GetDirectories(strBootFolder)
        Dim i As Integer

        On Error Resume Next
        If strDir.Length > 0 Then
            For i = 0 To strDir.Length - 1
                Debug.Print(strDir(i))
                Dim oDirectoryInfo As DirectoryInfo
                oDirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(strDir(i))
                If oDirectoryInfo.Name = "OldVersions" Then
                    '按文件删除，速度太慢，改为直接删除文件夹
                    Dim arrFile As String() = System.IO.Directory.GetFiles(strDir(i))

                    For Each strFullFileName As String In arrFile
                        SetStatusBarText(strFullFileName)
                        Select Case DeletePermanently
                            Case True   '永久删除
                                DelFile(strFullFileName, FileIO.RecycleOption.DeletePermanently)
                            Case False  '删除到垃圾箱
                                DelFile(strFullFileName, FileIO.RecycleOption.SendToRecycleBin)
                        End Select

                    Next

                End If
                DelOldFile(strDir(i), DeletePermanently)
            Next

        End If

    End Sub

    '删除旧文件夹   (  目标文件夹)
    Public Sub DelOldDirectory(ByVal strBootFolder As String, ByVal DeleteRecycleOption As Integer)
        On Error Resume Next

        Dim strDir As String() = System.IO.Directory.GetDirectories(strBootFolder)
        Dim i As Integer

        If strDir.Length > 0 Then
            For i = 0 To strDir.Length - 1
                Debug.Print(strDir(i))
                Dim oDirectoryInfo As DirectoryInfo
                oDirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(strDir(i))
                If oDirectoryInfo.Name = "OldVersions" Then

                    '按文件夹名删除
                    Dim strDirectoryName As String
                    strDirectoryName = oDirectoryInfo.FullName

                    SetStatusBarText(strDirectoryName)

                    DelFolder(strDirectoryName, DeleteRecycleOption)

                End If
                DelOldDirectory(strDir(i), DeleteRecycleOption)
            Next

        End If
    End Sub

    '检查 listview中是否存在重复项，再添加
    Public Function IsItemInListView(ByVal oListiView As ListView, ByVal strItem As String) As Boolean

        For Each oListViewItem As ListViewItem In oListiView.Items
            If oListViewItem.Text = strItem Then
                ISItemInListView = True
                Exit Function
            End If
        Next
        ISItemInListView = False

    End Function

    '移出 listview 中的选择项
    Public Sub ListViewDel(ByVal oListView As ListView)
        For i As Integer = oListView.SelectedIndices.Count - 1 To 0 Step -1
            oListView.Items.RemoveAt(oListView.SelectedIndices(i))
        Next
    End Sub

End Module
