Imports System.IO
Imports System.Text
Imports System.Text.Encoding
Imports System.IO.FileStream
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.FileIO
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

Module BasicFileSystem

    ''' <summary>
    ''' 文件名结构
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure FileNameInfo
        Public Folder As String     '文件夹
        Public FileName As String  '文件名+扩展名
        Public OnlyName As String  '仅文件名
        Public ExtensionName As String  '扩展名
    End Structure

    ''' <summary>
    ''' 读取文件
    ''' </summary>
    ''' <param name="strFullFileName">文件名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadTextFile(ByVal strFullFileName As String) As String
        Dim oStreamReader As New StreamReader(strFullFileName, Encoding.Default)
        Dim FileText = oStreamReader.ReadToEnd()
        oStreamReader.Close()
        Return FileText
    End Function

    ''' <summary>
    ''' 判断文件是否存在
    ''' </summary>
    ''' <param name="strFullFileName">文件名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsFileExsts(ByVal strFullFileName As String) As Boolean
        IsFileExsts = IO.File.Exists(strFullFileName)
    End Function

    ''' <summary>
    ''' 判断文件夹是否存在
    ''' </summary>
    ''' <param name="strDirectoryFullName">文件夹</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsDirectoryExists(ByVal strDirectoryFullName As String) As Boolean
        IsDirectoryExists = IO.Directory.Exists(strDirectoryFullName)
    End Function

    ''' <summary>
    ''' 获取文件所在文件夹
    ''' </summary>
    ''' <param name="strFullFileName">文件名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDirectoryName2(ByVal strFullFileName As String) As String
        GetDirectoryName2 = Path.GetDirectoryName(strFullFileName)
    End Function

    ''' <summary>
    ''' 从全名中取出文件名,含扩展名
    ''' </summary>
    ''' <param name="strFullFileName">文件名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFileNameWithExtension(ByVal strFullFileName As String) As String
        GetFileNameWithExtension = Path.GetFileName(strFullFileName)
    End Function

    ''' <summary>
    ''' 从全名中取出文件名简称,去除路径及扩展名
    ''' </summary>
    ''' <param name="strFullFileName">文件名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFileNameWithoutExtension2(ByVal strFullFileName As String) As String
        GetFileNameWithoutExtension2 = Path.GetFileNameWithoutExtension(strFullFileName)
    End Function

    ''' <summary>
    ''' 获取大写扩展名
    ''' </summary>
    ''' <param name="strFullFileName">文件名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFileExtensionUCase(ByVal strFullFileName As String) As String
        GetFileExtensionUCase = IO.Path.GetExtension(strFullFileName).ToUpper
    End Function

    ''' <summary>
    ''' 获取小写扩展名
    ''' </summary>
    ''' <param name="strFullFileName">文件名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFileExtensionLCase(ByVal strFullFileName As String) As String
        GetFileExtensionLCase = IO.Path.GetExtension(strFullFileName).ToLower
    End Function

    ''' <summary>
    ''' 获取filenameinfo结构
    ''' </summary>
    ''' <param name="strFullFileName">文件名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFileNameInfo(ByVal strFullFileName As String) As FileNameInfo
        Dim FNI As FileNameInfo = Nothing
        With FNI
            .Folder = GetDirectoryName2(strFullFileName)
            .FileName = GetFileNameWithExtension(strFullFileName)
            .ExtensionName = GetFileExtensionLCase(strFullFileName)
            .OnlyName = GetFileNameWithoutExtension2(strFullFileName)
        End With

        Return FNI
    End Function

    ''' <summary>
    ''' 重命名
    ''' </summary>
    ''' <param name="strOldFullFileName">旧文件名</param>
    ''' <param name="strNewFullFileName">新文件名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReFileName(ByVal strOldFullFileName As String, ByVal strNewFullFileName As String) As Boolean
        If File.Exists(strOldFullFileName) AndAlso Not File.Exists(strNewFullFileName) Then
            System.IO.File.Move(strOldFullFileName, strNewFullFileName)
            ReFileName = IsFileExsts(strNewFullFileName)
        Else
            ReFileName = False
        End If

    End Function

    ''' <summary>
    ''' 替换旧文件名，仅返回新文件名
    ''' </summary>
    ''' <param name="strOldFullFileName">旧文件名</param>
    ''' <param name="strNewFileName">新文件名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetChangeFileName(ByVal strOldFullFileName As String, ByVal strNewFileName As String) As String
        Dim oFileNameInfo As FileNameInfo
        oFileNameInfo = GetFileNameInfo(strOldFullFileName)

        GetChangeFileName = IO.Path.Combine(oFileNameInfo.Folder, strNewFileName & oFileNameInfo.ExtensionName)

        Return GetChangeFileName
    End Function

    ''' <summary>
    '''  替换文件夹路径，返回新文件名
    ''' </summary>
    ''' <param name="strOldFullFileName">旧文件名</param>
    ''' <param name="strNewDirectoryName">新文件名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetChangeDirectoryFileName(ByVal strOldFullFileName As String, ByVal strNewDirectoryName As String) As String
        Dim strOldFileName As String
        strOldFileName = IO.Path.GetFileName(strOldFullFileName)

        GetChangeDirectoryFileName = IO.Path.Combine(strNewDirectoryName, strOldFileName)
        Return GetChangeDirectoryFileName
    End Function


    ''' <summary>
    ''' 检查文件夹是否存在，否则就创建它
    ''' </summary>
    ''' <param name="strFolderPath">文件夹路径</param>
    ''' <remarks></remarks>
    Public Function EnsureDirectoryExists(ByVal strFolderPath As String) As Boolean
        If Not Directory.Exists(strFolderPath) Then
            Directory.CreateDirectory(strFolderPath)
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' 只变更扩展名，不操作，仅返回新的文件名
    ''' </summary>
    ''' <param name="strOldFullFileName">旧文件名</param>
    ''' <param name="strNewExtensionName">新文件名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetChangeExtension(ByVal strOldFullFileName As String, ByVal strNewExtensionName As String) As String
        GetChangeExtension = IO.Path.ChangeExtension(strOldFullFileName, strNewExtensionName)
    End Function

    ''' <summary>
    ''' 判断2个文件是否在同一文件夹
    ''' </summary>
    ''' <param name="strOneFullFileName">第一个文件名</param>
    ''' <param name="strTowFullFileName">第二个文件名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsInSameDirectory(ByVal strOneFullFileName As String, ByVal strTowFullFileName As String) As Boolean
        Dim strOneFileDirectory As String
        Dim strTowFileDirectory As String
        strOneFileDirectory = Path.GetDirectoryName(strOneFullFileName)
        strTowFileDirectory = Path.GetDirectoryName(strTowFullFileName)
        If strOneFileDirectory.ToLower = strTowFileDirectory.ToLower Then
            IsInSameDirectory = True
        Else
            IsInSameDirectory = False
        End If
    End Function

    ''' <summary>
    ''' 删除一个文件
    ''' </summary>
    ''' <param name="strFullFileName">文件名</param>
    ''' <param name="oRecycleOption">是否删除到回收站选项</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteFile2(ByVal strFullFileName As String, ByVal oRecycleOption As FileIO.RecycleOption) As Boolean
        If IsFileExsts(strFullFileName) Then
            Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(strFullFileName, FileIO.UIOption.OnlyErrorDialogs, oRecycleOption, FileIO.UICancelOption.ThrowException)
        End If
        DeleteFile2 = IsFileExsts(strFullFileName) Xor True
    End Function

    ''' <summary>
    ''' 仅删除一个文件夹中的文件
    ''' </summary>
    ''' <param name="strFolder">文件夹</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DelOnlyFileInForlder(ByVal strFolder As String) As Boolean
        If Directory.Exists(strFolder) Then
            For Each file As String In IO.Directory.GetFiles(strFolder)
                DeleteFile2(file, FileIO.RecycleOption.SendToRecycleBin)
            Next
        End If
    End Function

    ''' <summary>
    ''' 删除文件夹
    ''' </summary>
    ''' <param name="strFolder">文件夹</param>
    ''' <param name="intDeleteRecycleOption">是否删除到回收站选项</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DelFolder(ByVal strFolder As String, ByVal intDeleteRecycleOption As Integer) As Boolean
        If IsDirectoryExists(strFolder) Then
            Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(strFolder, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, intDeleteRecycleOption)
            DelFolder = IsDirectoryExists(strFolder)
        Else
            DelFolder = False
        End If
    End Function

    ''' <summary>
    ''' 移动文件
    ''' </summary>
    ''' <param name="strSourceFileName">源文件名</param>
    ''' <param name="strDestinationFileName">目标文件名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReMoveFile(ByVal strSourceFileName As String, ByVal strDestinationFileName As String) As Boolean
        Dim strDestinationFolder As String
        strDestinationFolder = GetDirectoryName2(strDestinationFileName)

        If Not IO.Directory.Exists(strDestinationFolder) Then
            IO.Directory.CreateDirectory(strDestinationFolder)
        End If
        IO.File.Move(strSourceFileName, strDestinationFileName)
        Return IsFileExsts(strDestinationFileName)
    End Function

    ''' <summary>
    ''' 移动文件到文件夹
    ''' </summary>
    ''' <param name="sourceFilePath">源文件名</param>
    ''' <param name="targetFolderPath">目标文件夹</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' 扫描文件夹
    ''' </summary>
    ''' <param name="strSourceFolder">源文件夹父文件夹</param>
    ''' <param name="olistbox">返回的list对象</param>
    ''' <param name="strExtension">扩展名筛选</param>
    ''' <remarks></remarks>
    Public Sub GetAllFile(ByVal strSourceFolder As String, ByVal olistbox As Object, Optional ByVal strExtension As String = "")
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


    ''' <summary>
    ''' 删除旧文件
    ''' </summary>
    ''' <param name="strBootFolder">目标文件夹</param>
    ''' <param name="DeletePermanently">是否永久删除</param>
    ''' <remarks></remarks>
    Public Sub DelOldFile(ByVal strBootFolder As String, ByVal DeletePermanently As Boolean)
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


    ''' <summary>
    ''' 删除旧文件夹
    ''' </summary>
    ''' <param name="strBootFolder">目标文件夹</param>
    ''' <param name="DeleteRecycleOption">是否删除到回收站选项</param>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' 检查 listview中是否存在重复项，再添加
    ''' </summary>
    ''' <param name="oListiView">ListView对象</param>
    ''' <param name="strItem">检查的项目</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' 移出 listview 中的选择项
    ''' </summary>
    ''' <param name="oListView">ListView对象</param>
    ''' <remarks></remarks>
    Public Sub ListViewDel(ByVal oListView As ListView)
        If oListView.SelectedItems.Count > 0 Then
            ' 遍历 ListView 中的所有选择项。
            For Each item As ListViewItem In oListView.SelectedItems
                ' 从 ListView 中移除选择项。
                oListView.Items.Remove(item)
            Next
        End If
    End Sub

    ''' <summary>
    ''' 选择一个新文件
    ''' </summary>
    ''' <param name="strFullFileName">预先指定的文件</param>
    ''' <param name="strFilter">扩展名筛选</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' 设置文件只读属性
    ''' </summary>
    ''' <param name="strFullFileName">文件名</param>
    ''' <param name="bIsReadOnly">是否只读</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' 获取文件只读属性
    ''' </summary>
    ''' <param name="strFullFileName">文件名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFileReadOnly(ByVal strFullFileName As String) As Boolean
        Dim myFile As New FileInfo(strFullFileName)
        GetFileReadOnly = myFile.IsReadOnly
    End Function

    ''' <summary>
    ''' 将文件扩展名加  old
    ''' </summary>
    ''' <param name="strFullName">文件名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AddOldExtension(ByVal strFullName As String) As Boolean
        Dim strOldFullName As String
        strOldFullName = strFullName & OLD

        If IsFileExsts(strOldFullName) = True Then
            DeleteFile2(strOldFullName, RecycleOption.SendToRecycleBin)
        End If

        ReFileName(strFullName, strOldFullName)

    End Function

    ''' <summary>
    ''' 在文件夹A中查找文件B，若找不到B，就在文件夹A的父文件夹中查询B，但又给定了一个参数L，表示只向上查找L层父目录，直到找到B
    ''' </summary>
    ''' <param name="folder">指定的文件夹</param>
    ''' <param name="filename">查找的文件名</param>
    ''' <param name="maxLevels">向上的层数</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' 在文件夹中按扩展名查找所有文件
    ''' </summary>
    ''' <param name="strFolderPath">文件夹</param>
    ''' <param name="strExtension">扩展名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' 查找文件
    ''' </summary>
    ''' <param name="strFolderPath">文件夹</param>
    ''' <param name="strSearchFileName">文件名</param>
    ''' <param name="strExtension">扩展名,可省略</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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
                If GetFileNameWithExtension(strFileFullFileName) = strFileName Then
                    strFullFileNames.Add(strFileFullFileName)
                End If
            Next

        End If

        Return strFullFileNames

    End Function


    ''' <summary>
    '''  返回第n层父文件夹路径
    ''' </summary>
    ''' <param name="strFolderPath">指定文件夹</param>
    ''' <param name="intParentLevel">返回层数</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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
    ''' <param name="strMultiSelectEnabled">是否可多选,True:多选；False：不多选</param>
    ''' <param name="strInitialDirectory">初始目录</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function OpenFileDialog(Optional ByVal strFilter As String = "所以文件 (*.*)|*.*", Optional ByVal strMultiSelectEnabled As Boolean = True, _
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
            .Filter = "所有文件 (*.*)|*.*"
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
    Public Function SaveFileDialog(Optional ByVal strFilter As String = "所有文件 (*.*)|*.*", Optional ByVal strMultiSelectEnabled As Boolean = True, _
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


    Function GetEncoding(ByVal str As String) As Encoding
        Dim utf8 As New System.Text.UTF8Encoding()
        Dim ascii As New System.Text.ASCIIEncoding()
        Dim Unicode As New System.Text.UnicodeEncoding

        If utf8.GetByteCount(str) = str.Length Then
            Return utf8
        ElseIf ascii.GetByteCount(str) = str.Length Then
            Return ascii
        ElseIf Unicode.GetByteCount(str) = str.Length Then
            Return Unicode
        Else
            Return Encoding.Default
        End If
    End Function

    Function GetFileEncoding(ByVal filePath As String) As Encoding
        Using reader As New StreamReader(filePath, True)
            Dim byteBuffer As Byte() = New Byte(reader.BaseStream.Length - 1) {}
            reader.BaseStream.Read(byteBuffer, 0, byteBuffer.Length)

            Dim utf8 As New UTF8Encoding()
            Dim ascii As New ASCIIEncoding()
            Dim Unicode As New UnicodeEncoding()

            If utf8.GetString(byteBuffer).Length = reader.BaseStream.Length Then
                Return Encoding.UTF8
            ElseIf ascii.GetString(byteBuffer).Length = reader.BaseStream.Length Then
                Return Encoding.ASCII
            ElseIf Unicode.GetString(byteBuffer).Length = reader.BaseStream.Length Then
                Return Encoding.Unicode
            Else
                Return Encoding.Default
            End If
        End Using
    End Function

End Module