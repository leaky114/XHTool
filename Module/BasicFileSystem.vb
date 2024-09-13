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
        Public FileName As String  '文件名+扩展名
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
        IsFileExsts = IO.File.Exists(strFullFileName)
    End Function

    '判断文件夹是否存在(文件夹)
    Public Function IsDirectoryExists(ByVal strDirectoryFullName As String) As Boolean
        IsDirectoryExists = IO.Directory.Exists(strDirectoryFullName)
    End Function

    '获取文件所在文件夹(文件名)
    Public Function GetDirectoryName2(ByVal strFullFileName As String) As String
        GetDirectoryName2 = IO.Path.GetDirectoryName(strFullFileName)
    End Function

    '从全名中取出文件名,含扩展名(文件名)
    Public Function GetFileName2(ByVal strFullFileName As String) As String
        GetFileName2 = IO.Path.GetFileName(strFullFileName)
    End Function

    '从全名中取出文件名简称,去除路径及扩展名(文件名)
    Public Function GetFileNameWithoutExtension2(ByVal strFullFileName As String) As String
        GetFileNameWithoutExtension2 = IO.Path.GetFileNameWithoutExtension(strFullFileName)
    End Function

    '大写扩展名(文件名)
    Public Function GetFileExtensionUCase(ByVal strFullFileName As String) As String
        GetFileExtensionUCase = IO.Path.GetExtension(strFullFileName).ToUpper
    End Function

    '小写扩展名(文件名)
    Public Function GetFileExtensionLCase(ByVal strFullFileName As String) As String
        GetFileExtensionLCase = IO.Path.GetExtension(strFullFileName).ToLower
    End Function

    '获取filenameinfo结构(文件名)
    Public Function GetFileNameInfo(ByVal strFullFileName As String) As FileNameInfo
        Dim FNI As FileNameInfo = Nothing
        With FNI
            .Folder = GetDirectoryName2(strFullFileName)
            .FileName = GetFileName2(strFullFileName)
            .ExtensionName = GetFileExtensionLCase(strFullFileName)
            .OnlyName = GetFileNameWithoutExtension2(strFullFileName)
        End With

        Return FNI
    End Function

    '重命名(旧文件名,新文件名)
    Public Function ReFileName(ByVal strOldFullFileName As String, ByVal strNewFullFileName As String) As Boolean
        If IsFileExsts(strNewFullFileName) = False And IsFileExsts(strOldFullFileName) = True Then
            System.IO.File.Move(strOldFullFileName, strNewFullFileName)
            ReFileName = IsFileExsts(strNewFullFileName)
        Else
            ReFileName = False
        End If

    End Function

    '只变更文件名，不操作，仅返回新的文件名
    Public Function GetNewFileName(ByVal strOldFullFileName As String, ByVal strNewFileName As String) As String
        Dim strDirectoryPath As String = Path.GetDirectoryName(strOldFullFileName)
        Dim strExtension As String = Path.GetExtension(strOldFullFileName)

        GetNewFileName = Path.Combine(strDirectoryPath, strNewFileName + strExtension)

        Return GetNewFileName

    End Function

    '只变更扩展名，不操作，仅返回新的文件名
    Public Function GetChangeExtension(ByVal strOldFullFileName As String, ByVal strNewExtensionName As String) As String
        GetChangeExtension = IO.Path.ChangeExtension(strOldFullFileName, strNewExtensionName)
    End Function

    '判断2个文件是否在同一文件夹(第一个文件名,第二个文件名)
    Public Function IsInSameDirectory(ByVal strOneFullFileName As String, ByVal strTowFullFileName As String) As Boolean
        Dim strOneFileDirectory As String
        Dim strTowFileDirectory As String
        strOneFileDirectory = GetDirectoryName2(strOneFullFileName)
        strTowFileDirectory = GetDirectoryName2(strTowFullFileName)
        If strOneFileDirectory = strTowFileDirectory Then
            IsInSameDirectory = True
        Else
            IsInSameDirectory = False
        End If
    End Function

    '删除一个文件(文件名,是否删除到回收站选项)
    Public Function DeleteFile2(ByVal strFullFileName As String, ByVal oRecycleOption As FileIO.RecycleOption) As Boolean
        If IsFileExsts(strFullFileName) Then
            Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(strFullFileName, FileIO.UIOption.OnlyErrorDialogs, oRecycleOption, FileIO.UICancelOption.ThrowException)
        End If
        DeleteFile2 = IsFileExsts(strFullFileName) Xor True
    End Function

    '仅删除一个文件夹中的文件(文件夹)
    Public Function DelOnlyFileInForlder(ByVal strFolder As String) As Boolean
        If IsDirectoryExists(strFolder) Then
            For Each file As String In IO.Directory.GetFiles(strFolder)
                DeleteFile2(file, FileIO.RecycleOption.SendToRecycleBin)
            Next
        End If
    End Function

    '删除文件夹(文件夹)
    Public Function DelFolder(ByVal strFolder As String, ByVal intDeleteRecycleOption As Integer) As Boolean
        If IsDirectoryExists(strFolder) Then
            Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(strFolder, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, intDeleteRecycleOption)
            DelFolder = IsDirectoryExists(strFolder)
        Else
            DelFolder = False
        End If
    End Function

    '移动文件(源文件名,目标文件名)
    Public Function ReMoveFile(ByVal strSourceFileName As String, ByVal strDestinationFileName As String) As Boolean
        Dim strDestinationFolder As String
        strDestinationFolder = GetDirectoryName2(strDestinationFileName)

        If Not IO.Directory.Exists(strDestinationFolder) Then
            IO.Directory.CreateDirectory(strDestinationFolder)
        End If
        IO.File.Move(strSourceFileName, strDestinationFileName)
        Return IsFileExsts(strDestinationFileName)
    End Function

    '移动文件到文件夹(源文件名,目标文件夹)
    Public Function ReMoveFileToFolder(ByVal sourceFilePath As String, ByVal targetFolderPath As String) As Boolean

        If Not IO.Directory.Exists(targetFolderPath) Then
            IO.Directory.CreateDirectory(targetFolderPath)
        End If

        Dim targetFilePath As String = IO.Path.Combine(targetFolderPath, IO.Path.GetFileName(sourceFilePath))

        If sourceFilePath <> targetFolderPath Then
            IO.File.Move(sourceFilePath, targetFilePath)
        End If

        Return IsFileExsts(targetFilePath)

    End Function

    '扫描文件夹
    Public Sub GetAllFile(ByVal strSourceFolder As String, ByVal olistbox As Object, Optional ByVal strExtension As String = "")
        ' 源文件夹父文件夹 ,源文件夹 , 目标文件夹
        On Error Resume Next

        Dim strDir As String() = System.IO.Directory.GetDirectories(strSourceFolder)
        Dim strFile As String() = System.IO.Directory.GetFiles(strSourceFolder, "*.*", IO.SearchOption.AllDirectories)
        Dim oFileInfo As FileInfo
        Dim i As Integer
        'if strDir.Length > 0 Then
        '    For i = 0 To strDir.Length - 1
        '        Debug.Print(strDir(i))
        '    Next
        'End if

        If strFile.Length > 0 Then
            For i = 0 To strFile.Length - 1
                'Debug.Print(strFile(i))
                oFileInfo = My.Computer.FileSystem.GetFileInfo(strFile(i))
                If (LCase(oFileInfo.Extension) = strExtension) And (Strings.InStr(oFileInfo.FullName, "OldVersions") = 0) Then
                    If IsItemInListView(olistbox, oFileInfo.FullName) = False Then
                        olistbox.Items.Add(oFileInfo.FullName)
                    End If
                End If
            Next
        End If
        'If strDir.Length > 0 Then
        '    For i = 0 To strDir.Length - 1
        '        GetAllFile(strBootFolder, strDir(i), olistbox, strExtension)
        '    Next
        'End If
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
                                DeleteFile2(strFullFileName, FileIO.RecycleOption.DeletePermanently)
                            Case False  '删除到垃圾箱
                                DeleteFile2(strFullFileName, FileIO.RecycleOption.SendToRecycleBin)
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

        For Each folder As String In strDir
            Debug.Print(folder)
            Dim oDirectoryInfo As DirectoryInfo
            oDirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(folder)
            If oDirectoryInfo.Name = "OldVersions" Then

                '按文件夹名删除
                Dim strDirectoryName As String
                strDirectoryName = oDirectoryInfo.FullName

                SetStatusBarText(strDirectoryName)

                DelFolder(strDirectoryName, DeleteRecycleOption)

            End If
            DelOldDirectory(folder, DeleteRecycleOption)
        Next

    End Sub

    '检查 listview中是否存在重复项，再添加
    Public Function IsItemInListView(ByVal oListiView As ListView, ByVal strItem As String) As Boolean

        '检查为空值时跳过
        If strItem = "" Then
            Return False
        End If

        If oListiView.FindItemWithText(strItem) Is Nothing Then
            Return False
        Else
            Return True
        End If

        'For Each oListViewItem As ListViewItem In oListiView.Items
        '    If oListViewItem.Text = strItem Then
        '        IsItemInListView = True
        '        Exit Function
        '    End If
        'Next
        'IsItemInListView = False

    End Function

    '移出 listview 中的选择项
    Public Sub ListViewDel(ByVal oListView As ListView)
        If oListView.SelectedItems.Count > 0 Then
            ' 遍历 ListView 中的所有选择项。
            For Each item As ListViewItem In oListView.SelectedItems
                ' 从 ListView 中移除选择项。
                oListView.Items.Remove(item)
            Next
        End If
    End Sub


    Public Function SetNewFile(ByVal strFullFileName As String, ByVal strFilter As String) As String
        If IsFileExsts(strFullFileName) = True Then
            Dim msg As MsgBoxResult = MsgBox("已存在文件： " & strFullFileName & "  覆盖（是），另存为（否），打开(取消)？", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel)
            Select Case msg
                Case MsgBoxResult.Yes
                    Return strFullFileName
                Case MsgBoxResult.No
                    Dim oSaveFileDialog As New SaveFileDialog
                    With oSaveFileDialog
                        .Title = "选择文件"
                        .Filter = strFilter  ' "AutoCAD文件(*.dwg)|*.dwg"
                        .InitialDirectory = GetDirectoryName2(strFullFileName)
                        If .ShowDialog = DialogResult.OK Then
                            strFullFileName = .FileName
                            Return strFullFileName
                        Else
                            Return strFullFileName
                        End If
                    End With
                Case MsgBoxResult.Cancel
                    strFullFileName = "取消" & strFullFileName
                    Return strFullFileName
            End Select
        Else
            Return strFullFileName
        End If

        Return strFullFileName

    End Function

    '设置文件只读属性
    Public Function SetFileReadOnly(ByVal strFullFileName As String, ByVal bIsReadOnly As Boolean) As Boolean
        If IsFileExsts(strFullFileName) = False Then
            Return False
        End If

        Dim myFile As New FileInfo(strFullFileName)
        If bIsReadOnly = True Then  '设置
            myFile.Attributes = FileAttributes.ReadOnly
            Return True
        Else    'false为可写
            myFile.Attributes = FileAttributes.Normal
            Return True
        End If
    End Function

    '获取文件只读属性
    Public Function GetFileReadOnly(ByVal strFullFileName As String) As Boolean
        Dim myFile As New FileInfo(strFullFileName)
        GetFileReadOnly = myFile.IsReadOnly
    End Function

    '将文件扩展名加  old
    Public Function AddOldExtension(ByVal strFullName As String) As Boolean
        Dim strOldFullName As String
        strOldFullName = strFullName & OLD

        If IsFileExsts(strOldFullName) = True Then
            DeleteFile2(strOldFullName, RecycleOption.SendToRecycleBin)
        End If

        ReFileName(strFullName, strOldFullName)

    End Function

    '在文件夹A中查找文件B，若找不到B，就在文件夹A的父文件夹中查询B，但又给定了一个参数L，表示只向上查找L层父目录，直到找到B
    Public Function FindFile(ByVal folder As String, ByVal filename As String, ByVal maxLevels As Integer) As String
        ' 检查当前目录
        Dim files As String() = Directory.GetFiles(folder, filename)
        If files.Length > 0 Then
            Return Path.Combine(folder, filename)
        End If

        ' 检查子目录
        Dim subFolders As String() = Directory.GetDirectories(folder)
        For Each subFolder As String In subFolders
            Dim foundPath As String = FindFile(subFolder, filename, maxLevels - 1)
            If foundPath IsNot Nothing Then
                Return foundPath
            End If
        Next

        ' 检查父目录
        If maxLevels > 0 Then
            Dim parentPath As String = Path.GetDirectoryName(folder)
            If parentPath <> folder Then
                Return FindFile(parentPath, filename, maxLevels - 1)
            End If
        End If

        Return Nothing


    End Function

    '按行读取UTF8格式的txt文本 ，如果不UTF8格式，则先转换格式为UTF8
    Public Sub ReadUTF8Txt()
        Dim filePath As String = "example.txt"
        Dim encoding As Encoding = GetFileEncoding(filePath)

        If encoding IsNot encoding.UTF8 Then
            ConvertToUTF8(filePath, encoding)
            encoding = encoding.UTF8
        End If

        Using sr As StreamReader = New StreamReader(filePath, encoding)
            Dim line As String
            While Not sr.EndOfStream
                line = sr.ReadLine()
                Console.WriteLine(line)
            End While
        End Using
    End Sub

    Public Function GetFileEncoding(ByVal filePath As String) As Encoding
        Using fs As FileStream = File.OpenRead(filePath)
            Dim buffer As Byte() = New Byte(3) {}
            fs.Read(buffer, 0, 4)
            fs.Close()

            If buffer(0) = &HEF AndAlso buffer(1) = &HBB AndAlso buffer(2) = &HBF Then
                Return Encoding.UTF8
            ElseIf buffer(0) = &HFF AndAlso buffer(1) = &HFE AndAlso buffer(2) = &H0 AndAlso buffer(3) = &H0 Then
                Return Encoding.Unicode
            ElseIf buffer(0) = &HFE AndAlso buffer(1) = &HFF AndAlso buffer(2) = &H0 AndAlso buffer(3) = &H0 Then
                Return Encoding.BigEndianUnicode
            Else
                Return Encoding.Default
            End If
        End Using
    End Function

    Public Sub ConvertToUTF8(ByVal filePath As String, ByVal originalEncoding As Encoding)
        Dim utf8Content As String = ""
        Using sr As StreamReader = New StreamReader(filePath, originalEncoding)
            utf8Content = sr.ReadToEnd()
        End Using

        Using sw As StreamWriter = New StreamWriter(filePath, False, Encoding.UTF8)
            sw.Write(utf8Content)
        End Using
    End Sub

    '在文件夹中按扩展名查找所有文件
    Function GetAllFilesByExtension(ByVal strFolderPath As String, ByVal strExtension As String) As List(Of String)
        On Error Resume Next
        Dim arrayFullFileNames As String()
        arrayFullFileNames = Directory.GetFiles(strFolderPath, "*" & strExtension, System.IO.SearchOption.AllDirectories)

        Dim strFullFileNames As New List(Of String)()
        For Each strFileFullFileName As String In arrayFullFileNames
            strFullFileNames.Add(strFileFullFileName)
        Next

        Return strFullFileNames
    End Function

    '查找文件 （文件夹；文件名；扩展名,可省略）
    Function FindFileInFolder(ByVal strFolderPath As String, Optional ByVal strSearchFileName As String = "", Optional ByVal strExtension As String = "") _
        As List(Of String)
        On Error Resume Next

        Dim arrayFullFileNames As String()

        Dim strFullFileNames As New List(Of String)()


        If strExtension = "" Then   '无扩展名
            arrayFullFileNames = IO.Directory.GetFiles(strFolderPath, "*" & strSearchFileName & "*.*", IO.SearchOption.AllDirectories)

            For Each strFileFullFileName As String In arrayFullFileNames
                strFullFileNames.Add(strFileFullFileName)
            Next


        Else    '有扩展名
            arrayFullFileNames = IO.Directory.GetFiles(strFolderPath, "*" & strSearchFileName & "*" & strExtension, IO.SearchOption.AllDirectories)
            Dim strFileName = strSearchFileName & strExtension
            strFileName = Trim(strFileName)

            For Each strFileFullFileName As String In arrayFullFileNames
                If GetFileName2(strFileFullFileName) = strFileName Then
                    strFullFileNames.Add(strFileFullFileName)
                End If
            Next

        End If

        Return strFullFileNames

    End Function

    '返回第n层父文件夹路径

    Function GetParentFolderPath(ByVal strFolderPath As String, ByVal intParentLevel As Integer) As String
        Dim strCurrentPath As String = strFolderPath
        If intParentLevel > strFolderPath.Split("\").Length Then
            strCurrentPath = Path.GetPathRoot(strFolderPath) ' 返回根目录
            Return strCurrentPath
        End If

        For i As Integer = 1 To intParentLevel - 1
            strCurrentPath = Path.GetDirectoryName(strCurrentPath)
        Next

        Return strCurrentPath
    End Function

    ''' <summary>
    ''' 打开选择文件对话框
    ''' </summary>
    ''' <param name="strFilter">扩展名列表</param>
    ''' <param name="strMultiSelectEnabled">是否可多选</param>
    ''' <param name="strInitialDirectory">初始目录</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function OpenFileDialog(Optional ByVal strFilter As String = "All Files (*.*)|*.*", Optional ByVal strMultiSelectEnabled As Boolean = True, _
                                   Optional ByVal strInitialDirectory As String = "") As List(Of String)
        Dim oOpenFileDialog As Inventor.FileDialog = Nothing

        ThisApplication.CreateFileDialog(oOpenFileDialog)

        oOpenFileDialog.Filter = strFilter '添加过滤文件
        oOpenFileDialog.DialogTitle = "打开"
        oOpenFileDialog.MultiSelectEnabled = strMultiSelectEnabled
        oOpenFileDialog.InitialDirectory = strInitialDirectory
        oOpenFileDialog.CancelError = False
        oOpenFileDialog.InsertMode = False

        oOpenFileDialog.ShowOpen()

        If oOpenFileDialog.FileName <> "" Then  '如果有选中文件

            On Error Resume Next
            Dim arrayFullFileNames As String()
            arrayFullFileNames = Split(oOpenFileDialog.FileName, "|")

            Dim strFullFileNames As New List(Of String)()
            For Each strFileFullFileName As String In arrayFullFileNames
                strFullFileNames.Add(strFileFullFileName)
            Next

            Return strFullFileNames
        Else

        End If


    End Function

    ''' <summary>
    ''' 通过打开选择文件对话框选择的文件确定文件夹
    ''' </summary>
    ''' <param name="strInitialDirectory">初始目录</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function OpenFolderDialog(Optional ByVal strInitialDirectory As String = "") As String
        Dim oOpenFileDialog As Inventor.FileDialog = Nothing

        ThisApplication.CreateFileDialog(oOpenFileDialog)

        With oOpenFileDialog
            .Filter = "All Files (*.*)|*.*"
            .DialogTitle = "从文件选择文件夹"
            .MultiSelectEnabled = False
            .InitialDirectory = strInitialDirectory
            .CancelError = False
            .InsertMode = False
            .ShowOpen()

            If .FileName <> "" Then  '如果有选中文件

                On Error Resume Next
                'Dim arrayFullFileNames As String()
                'arrayFullFileNames = Split(.FileName, "|")

                'Dim strFullFileNames As New List(Of String)()
                'For Each strFileFullFileName As String In arrayFullFileNames
                '    strFullFileNames.Add(strFileFullFileName)
                'Next
                Dim strFullFileName As String
                strFullFileName = .FileName

                Dim strFolderPath As String

                strFolderPath = IO.Path.GetDirectoryName(strFullFileName)

                Return strFolderPath
            Else

            End If

        End With
    End Function


    ''' <summary>
    ''' 打开选择文件对话框
    ''' </summary>
    ''' <param name="strFilter">扩展名列表</param>
    ''' <param name="strMultiSelectEnabled">是否可多选</param>
    ''' <param name="strInitialDirectory">初始目录</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SaveFileDialog(Optional ByVal strFilter As String = "All Files (*.*)|*.*", Optional ByVal strMultiSelectEnabled As Boolean = True, _
                                   Optional ByVal strInitialDirectory As String = "") As List(Of String)
        Dim oOpenFileDialog As Inventor.FileDialog = Nothing

        ThisApplication.CreateFileDialog(oOpenFileDialog)

        oOpenFileDialog.Filter = strFilter '添加过滤文件
        oOpenFileDialog.DialogTitle = "保存"
        oOpenFileDialog.MultiSelectEnabled = strMultiSelectEnabled
        oOpenFileDialog.InitialDirectory = strInitialDirectory
        oOpenFileDialog.CancelError = False
        oOpenFileDialog.InsertMode = False

        oOpenFileDialog.ShowSave()

        If oOpenFileDialog.FileName <> "" Then  '如果有选中文件

            On Error Resume Next
            Dim arrayFullFileNames As String()
            arrayFullFileNames = Split(oOpenFileDialog.FileName, "|")

            Dim strFullFileNames As New List(Of String)()
            For Each strFileFullFileName As String In arrayFullFileNames
                strFullFileNames.Add(strFileFullFileName)
            Next

            Return strFullFileNames
        Else

        End If


    End Function
End Module