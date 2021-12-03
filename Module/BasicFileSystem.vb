Imports System.IO
Imports System.Text
Imports System.Text.Encoding
Imports System.IO.FileStream
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.FileIO

Module BasicFileSystem

    '文件名结构
    Public Structure FileNameInfo
        Public Folder As String     '文件夹
        Public SigleName As String  '文件名+扩展名
        Public ONlyName As String  '仅文件名
        Public ExtensionName As String  '扩展名
    End Structure

    '读取文件(文件名)
    Public Function ReadTextFile(ByVal FullFileName As String) As String
        Dim File As New StreamReader(FullFileName, Encoding.Default)
        Dim FileText = File.ReadToEnd()
        File.Close()
        Return FileText
    End Function

    '判断文件是否存在(文件名)
    Public Function IsFileExsts(ByVal FullFileName As String) As Boolean
        IsFileExsts = My.Computer.FileSystem.FileExists(FullFileName)
    End Function

    '判断文件夹是否存在(文件夹)
    Public Function IsDirectoryExists(ByVal DirectoryFullName As String) As Boolean
        IsDirectoryExists = My.Computer.FileSystem.DirectoryExists(DirectoryFullName)
    End Function

    '获取文件所在文件夹(文件名)
    Public Function GetParentFolder(ByVal FullFileName As String) As String
        If IsFileExsts(FullFileName) = True Then
            GetParentFolder = My.Computer.FileSystem.GetFileInfo(FullFileName).DirectoryName
        Else
            Dim i As Integer
            Dim OnlyS As String
            OnlyS = FullFileName
            i = InStrRev(OnlyS, "\")
            OnlyS = Strings.Left(OnlyS, i - 1)
            GetParentFolder = OnlyS
        End If
    End Function

    '从全名中取出文件名,含扩展名(文件名)
    Public Function GetSingleName(ByVal FullFileName As String) As String
        If IsFileExsts(FullFileName) = True Then
            GetSingleName = My.Computer.FileSystem.GetName(FullFileName)
        Else
            Dim p As Short
            p = InStrRev(FullFileName, "\")
            If p > 0 Then
                GetSingleName = Strings.Right(FullFileName, Strings.Len(FullFileName) - p)
            Else
                GetSingleName = ""
            End If
        End If

    End Function

    '从全名中取出文件名简称,去除路径及扩展名(文件名)
    Public Function GetOnlyname(ByVal FullFileName As String) As String
        If IsFileExsts(FullFileName) = True Then
            Dim FileName As String
            Dim FileExtension As String

            FileName = My.Computer.FileSystem.GetName(FullFileName)
            FileExtension = My.Computer.FileSystem.GetFileInfo(FullFileName).Extension
            GetOnlyname = Microsoft.VisualBasic.Strings.Replace(FileName, FileExtension, "")
        Else
            Dim i As Integer
            Dim OnlyS As String
            OnlyS = FullFileName
            i = InStrRev(OnlyS, "\")
            OnlyS = Strings.Right(OnlyS, Len(OnlyS) - i)
            i = InStrRev(OnlyS, ".")
            OnlyS = Strings.Left(OnlyS, i - 1)
            GetOnlyname = OnlyS
        End If
    End Function

    '大写扩展名(文件名)
    Public Function UCaseGetFileExtension(ByVal FullFileName As String) As String
        If IsFileExsts(FullFileName) = True Then
            UCaseGetFileExtension = UCase(My.Computer.FileSystem.GetFileInfo(FullFileName).Extension)
        Else
            Dim i As Integer
            Dim OnlyS As String
            OnlyS = FullFileName
            i = InStrRev(OnlyS, ".")
            OnlyS = Strings.Right(OnlyS, Len(OnlyS) - i + 1)
            UCaseGetFileExtension = UCase(OnlyS)
        End If
    End Function

    '小写扩展名(文件名)
    Public Function LCaseGetFileExtension(ByVal FullFileName As String) As String
        If IsFileExsts(FullFileName) = True Then
            LCaseGetFileExtension = LCase(My.Computer.FileSystem.GetFileInfo(FullFileName).Extension)
        Else
            Dim i As Integer
            Dim OnlyS As String
            OnlyS = FullFileName
            i = InStrRev(OnlyS, ".")
            OnlyS = Strings.Right(OnlyS, Len(OnlyS) - i + 1)
            LCaseGetFileExtension = LCase(OnlyS)
        End If
    End Function

    '获取filenameinfo结构(文件名)
    Public Function GetFileNameInfo(ByVal FullFileName As String) As FileNameInfo
        Dim FNI As FileNameInfo = Nothing
        If IsFileExsts(FullFileName) = True Then
            FNI.Folder = My.Computer.FileSystem.GetFileInfo(FullFileName).DirectoryName
            FNI.SigleName = My.Computer.FileSystem.GetName(FullFileName)
            FNI.ExtensionName = My.Computer.FileSystem.GetFileInfo(FullFileName).Extension  '这里有大小写问题
            FNI.ONlyName = Microsoft.VisualBasic.Strings.Replace(FNI.SigleName, FNI.ExtensionName, "")
        Else
            Dim i As Integer
            i = InStrRev(FullFileName, "\")
            FNI.Folder = Strings.Left(FullFileName, i - 1)

            FNI.SigleName = Strings.Right(FullFileName, Strings.Len(FullFileName) - Strings.Len(FNI.Folder) - 1)

            i = InStr(FNI.SigleName, ".")
            FNI.ONlyName = Left(FNI.SigleName, i - 1)
            FNI.ExtensionName = LCase(Strings.Right(FNI.SigleName, Strings.Len(FNI.SigleName) - Strings.Len(FNI.ONlyName)))
        End If
        Return FNI
    End Function

    '重命名(旧文件名,新文件名)
    Public Function ReFileName(ByVal OldFullFileName As String, ByVal NewFullFileName As String) As Boolean
        If IsFileExsts(NewFullFileName) = False And IsFileExsts(OldFullFileName) = True Then
            My.Computer.FileSystem.RenameFile(OldFullFileName, GetSingleName(NewFullFileName))
            ReFileName = IsFileExsts(NewFullFileName)
        Else
            ReFileName = False
        End If
    End Function

    '只变更文件名，不操作，仅返回新的文件名
    Public Function GetNewFileName(ByVal OldFullFileName As String, ByVal NewFileName As String) As String
        Dim FNI As FileNameInfo
        FNI = GetFileNameInfo(OldFullFileName)

        Dim ParentFolder As String
        ParentFolder = FNI.Folder  'GetParentFolder(OldFullFileName)

        Dim ExtensionName As String
        ExtensionName = FNI.ExtensionName

        GetNewFileName = ParentFolder & "\" & NewFileName & ExtensionName

        Return GetNewFileName

    End Function

    '只变更扩展名，不操作，仅返回新的文件名
    Public Function GetNewExtensionFileName(ByVal OldFullFileName As String, ByVal NewExtensionName As String) As String
        Dim FNI As FileNameInfo
        FNI = GetFileNameInfo(OldFullFileName)

        Dim ParentFolder As String   '文件夹
        ParentFolder = FNI.Folder  'GetParentFolder(OldFullFileName)

        Dim OnlyName As String     '仅文件名
        OnlyName = FNI.ONlyName

        GetNewExtensionFileName = ParentFolder & "\" & OnlyName & NewExtensionName

        Return GetNewExtensionFileName

    End Function

    '判断2个文件是否在同一文件夹(第一个文件名,第二个文件名)
    Public Function IsInSameFolder(ByVal OneFile As String, ByVal TowFile As String) As Boolean
        Dim OneFileFolder As String
        Dim TowFileForlder As String
        OneFileFolder = GetParentFolder(OneFile)
        TowFileForlder = GetParentFolder(TowFile)
        If OneFileFolder = TowFileForlder Then
            IsInSameFolder = True
        Else
            IsInSameFolder = False
        End If
    End Function

    '删除一个文件(文件名,是否删除到回收站选项)
    Public Function DelFile(ByVal FullFileName As String, ByVal RecycleOption As FileIO.RecycleOption) As Boolean
        If IsFileExsts(FullFileName) Then
            My.Computer.FileSystem.DeleteFile(FullFileName, FileIO.UIOption.OnlyErrorDialogs, RecycleOption, FileIO.UICancelOption.DoNothing)
        End If
        DelFile = IsFileExsts(FullFileName) Xor True
    End Function

    '仅删除一个文件夹中的文件(文件夹)
    Public Function DelOnlyFileInForlder(ByVal Folder As String) As Boolean
        If My.Computer.FileSystem.DirectoryExists(Folder) Then
            For Each f As String In My.Computer.FileSystem.GetFiles(Folder)
                DelFile(f, FileIO.RecycleOption.SendToRecycleBin)
            Next
        End If
        Return True
    End Function

    '删除文件夹(文件夹)
    Public Function DelFolder(ByVal Folder As String, ByVal DeleteRecycleOption As Integer) As Boolean
        If My.Computer.FileSystem.DirectoryExists(Folder) Then
            My.Computer.FileSystem.DeleteDirectory(Folder, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, DeleteRecycleOption)
            DelFolder = IsDirectoryExists(Folder)
        Else
            DelFolder = False
        End If
    End Function

    '移动文件(源文件名,目标文件名)
    Public Function ReMoveFile(ByVal SourceFileName As String, ByVal DestinationFileName As String) As Boolean
        Dim DestinationFolder As String
        DestinationFolder = GetParentFolder(DestinationFileName)
        If IsDirectoryExists(DestinationFolder) = False Then
            My.Computer.FileSystem.CreateDirectory(DestinationFolder)
        End If
        My.Computer.FileSystem.MoveFile(SourceFileName, DestinationFileName, True)
        Return IsFileExsts(DestinationFileName)
    End Function

    '移动文件到文件夹(源文件名,目标文件夹)
    Public Function ReMoveFileToFolder(ByVal SourceFileName As String, ByVal DestinationFolder As String) As Boolean
        Dim DestinationFileName As String
        If IsDirectoryExists(DestinationFolder) = False Then
            My.Computer.FileSystem.CreateDirectory(DestinationFolder)
        End If

        DestinationFileName = DestinationFolder & "\" & GetSingleName(SourceFileName)
        If SourceFileName <> DestinationFileName Then
            My.Computer.FileSystem.MoveFile(SourceFileName, DestinationFileName, True)
        End If
        Return IsFileExsts(DestinationFileName)
    End Function

    '扫描文件夹
    Public Sub GetAllFile(ByVal Boot_Folder As String, ByVal Source_Folder As String, ByVal olistbox As Object)
        ' 源文件夹父文件夹 ,源文件夹 , 目标文件夹
        Dim strDir As String() = System.IO.Directory.GetDirectories(Source_Folder)
        Dim strFile As String() = System.IO.Directory.GetFiles(Source_Folder)
        Dim File_Attribute As FileInfo
        Dim i As Integer
        'If strDir.Length > 0 Then
        '    For i = 0 To strDir.Length - 1
        '        Debug.Print(strDir(i))
        '    Next
        'End If

        If strFile.Length > 0 Then
            For i = 0 To strFile.Length - 1
                'Debug.Print(strFile(i))
                File_Attribute = My.Computer.FileSystem.GetFileInfo(strFile(i))
                If (LCase(File_Attribute.Extension) = IDW) And (Strings.InStr(File_Attribute.FullName, "OldVersions") = 0) Then
                    olistbox.Items.Add(File_Attribute.FullName)
                End If
            Next
        End If
        If strDir.Length > 0 Then
            For i = 0 To strDir.Length - 1
                GetAllFile(Boot_Folder, strDir(i), olistbox)
            Next
        End If
    End Sub

    '删除旧文件
    Public Sub DelOldFile(ByVal Boot_Folder As String, ByVal DeletePermanently As Boolean)
        '  目标文件夹
        Dim strDir As String() = System.IO.Directory.GetDirectories(Boot_Folder)
        Dim i As Integer

        On Error Resume Next
        If strDir.Length > 0 Then
            For i = 0 To strDir.Length - 1
                Debug.Print(strDir(i))
                Dim inf As DirectoryInfo
                inf = My.Computer.FileSystem.GetDirectoryInfo(strDir(i))
                If inf.Name = "OldVersions" Then
                    '按文件删除，速度太慢，改为直接删除文件夹
                    'Dim strFile As String() = System.IO.Directory.GetFiles(strDir(i))

                    'For Each f As String In strFile
                    '    SetStatusBarText(f)
                    '    Select Case DeletePermanently
                    '        Case True   '永久删除
                    '            DelFile(f, FileIO.RecycleOption.DeletePermanently)
                    '        Case False  '删除到垃圾箱
                    '            DelFile(f, FileIO.RecycleOption.SendToRecycleBin)
                    '    End Select

                    'Next

                    '按文件夹名删除
                    Dim directoryname As String
                    directoryname = inf.FullName
                    SetStatusBarText(directoryname)

                    Select Case DeletePermanently
                        Case True   '永久删除
                            DelFolder(directoryname, FileIO.RecycleOption.DeletePermanently)

                        Case False  '删除到垃圾箱
                            DelFolder(directoryname, FileIO.RecycleOption.SendToRecycleBin)
                    End Select

                End If
                DelOldFile(strDir(i), DeletePermanently)
            Next

        End If

    End Sub

    '删除旧文件夹   (  目标文件夹)
    Public Sub DelOldDirectory(ByVal Boot_Folder As String, ByVal DeleteRecycleOption As Integer)
        On Error Resume Next

        Dim strDir As String() = System.IO.Directory.GetDirectories(Boot_Folder)
        Dim i As Integer

        SetStatusBarText("扫描文件夹.......")

        If strDir.Length > 0 Then
            For i = 0 To strDir.Length - 1
                Debug.Print(strDir(i))
                Dim inf As DirectoryInfo
                inf = My.Computer.FileSystem.GetDirectoryInfo(strDir(i))
                If inf.Name = "OldVersions" Then

                    '按文件夹名删除
                    Dim DirectoryName As String
                    DirectoryName = inf.FullName

                    SetStatusBarText(DirectoryName)

                    DelFolder(DirectoryName, DeleteRecycleOption)

                End If
                DelOldDirectory(strDir(i), DeleteRecycleOption)
            Next

        End If
    End Sub

End Module