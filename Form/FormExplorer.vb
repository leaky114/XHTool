Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.IO.File
Imports Microsoft.VisualBasic.FileIO
Imports System.Linq
Imports System.Drawing
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Collections.Specialized

Public Class FormExplorer

    ' 声明Win32 API
    Private Const SHGFI_USEFILEATTRIBUTES As UInteger = &H10
    Private Const FILE_ATTRIBUTE_DIRECTORY As UInteger = &H10
    Private Const SHOP_FILEPATH As Integer = &H4

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)>
    Private Structure SHFILEINFO
        Public hIcon As IntPtr
        Public iIcon As Integer
        Public dwAttributes As UInteger
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)>
        Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)>
        Public szTypeName As String
    End Structure

    <DllImport("shell32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SHGetFileInfo(
        ByVal pszPath As String,
        ByVal dwFileAttributes As UInteger,
        ByRef psfi As SHFILEINFO,
        ByVal cbSizeFileInfo As UInteger,
        ByVal uFlags As UInteger
    ) As IntPtr
    End Function


    <DllImport("shell32.dll", CharSet:=CharSet.Auto)>
    Public Shared Sub SHObjectProperties(
        hWnd As IntPtr,
        dwFlags As Integer,
        <MarshalAs(UnmanagedType.LPWStr)> pszObjectName As String,
        <MarshalAs(UnmanagedType.LPWStr)> pszPropertyPage As String
    )
    End Sub


    <DllImport("user32.dll")>
    Private Shared Function SendMessage(
                                       hWnd As IntPtr,
                                        msg As Integer,
                                        wParam As Integer,
                                        lParam As Integer
                                        ) As Integer
    End Function


    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)>
    Public Structure SHELLEXECUTEINFO
        Public cbSize As Integer
        Public fMask As UInteger
        Public hwnd As IntPtr
        <MarshalAs(UnmanagedType.LPTStr)> Public lpVerb As String
        <MarshalAs(UnmanagedType.LPTStr)> Public lpFile As String
        <MarshalAs(UnmanagedType.LPTStr)> Public lpParameters As String
        <MarshalAs(UnmanagedType.LPTStr)> Public lpDirectory As String
        Public nShow As Integer
        Public hInstApp As IntPtr
        Public lpIDList As IntPtr
        <MarshalAs(UnmanagedType.LPTStr)> Public lpClass As String
        Public hkeyClass As IntPtr
        Public dwHotKey As UInteger
        Public hIcon As IntPtr
        Public hProcess As IntPtr
    End Structure

    <DllImport("shell32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function ShellExecuteEx(ByRef lpExecInfo As SHELLEXECUTEINFO) As Boolean
    End Function

    Private Const SW_SHOW As Integer = 5
    Private Const SEE_MASK_INVOKEIDLIST As UInteger = &HC

    Private Sub SetDoubleBuffered(ByVal ctrl As Control)
        SendMessage(ctrl.Handle, &H1000 + 127, 1, 0)
    End Sub

    ' 在类级别添加图标缓存字典
    Private iconCache As New Dictionary(Of String, Integer)()

    ' 缓存所有文件和文件夹项
    Private AllItems As New List(Of ListViewItem)()

    ' 当前文件夹路径
    Private strCurrentDirectory As String

    ' 定义标志常量
    Private Const SHGFI_TYPENAME As Integer = &H400

    Private Const LVM_SETEXTENDEDLISTVIEWSTYLE As Integer = &H1036
    Private Const LVS_EX_DOUBLEBUFFER As Integer = &H10000

    Private previousHoverItem As ListViewItem = Nothing
    Private currentHoverItem As ListViewItem = Nothing

    ''' <summary>
    ''' 获取图标index
    ''' </summary>
    ''' <param name="fullPath"></param>
    ''' <param name="isFolder"></param>
    ''' <returns></returns>
    Private Function GetIconIndex(ByVal fullPath As String, ByVal isFolder As Boolean, ByVal oImageList As ImageList) As Integer
        Dim cacheKey As String = If(isFolder, "FOLDER", Path.GetExtension(fullPath).ToLower())

        If iconCache.ContainsKey(cacheKey) Then
            Return iconCache(cacheKey)
        End If

        ' 将图标添加到ImageList
        Using icon As Icon = Icon.ExtractAssociatedIcon(fullPath)
            oImageList.Images.Add(icon)
        End Using

        Dim index As Integer = oImageList.Images.Count - 1
        iconCache.Add(cacheKey, index)


        Return index
    End Function

    ''' <summary>
    ''' 加载文件夹内容
    ''' </summary>
    ''' <param name="strFolderPath">文件夹路径</param>
    ''' <param name="oListView">listview 文件列表</param>
    ''' <param name="oImageList">imagelist 图标</param>
    ''' <param name="oComboBox">combobox 扩展名筛选</param>
    Public Sub LoadFolderAllContents(ByVal strFolderPath As String, ByVal oListView As ListView, ByVal oImageList As ImageList, ByVal oComboBox As ComboBox)
        ' 清空所有缓存和控件
        oListView.Items.Clear()
        oComboBox.Items.Clear()
        AllItems.Clear()
        oImageList.Images.Clear()
        iconCache.Clear()

        '' 添加默认文件夹图标到缓存（确保第一个图标位置）
        'Using folderIcon As Icon = GetFolderIcon()
        '    imageList.Images.Add(folderIcon)
        '    iconCache.Add("FOLDER", 0)
        'End Using

        '' 获取文件目录信息
        On Error Resume Next

        Dim oDirectoryInfo As New DirectoryInfo(strFolderPath)

        ' 先加载文件夹
        'For Each strDir In dirInfo.GetDirectories()
        '    AddItemToList(strDir.FullName, True, strDir.Name, "Folder", strDir.LastWriteTime, 0)
        'Next

        ' 再加载文件

        For Each oFileInfo In oDirectoryInfo.GetFiles("*.*", IO.SearchOption.AllDirectories)
            If Strings.InStr(oFileInfo.FullName, "\OldVersions\") <> 0 Then
                Continue For
            End If
            AddItemToList(oFileInfo.FullName, False, oFileInfo.Name, oFileInfo.Extension, oFileInfo.LastWriteTime, oFileInfo.Length, True)
        Next


        'ProcessFilesAndDirectories(folderPath, listView, imageList, comboBox)

        'ProcessFilesFast(folderPath, listView, imageList, comboBox)

        ' 加载排序后的扩展名
        Dim extensions = oDirectoryInfo.GetFiles("*.*", IO.SearchOption.AllDirectories).Select(Function(f) f.Extension.ToLower().Substring(1）).Distinct().OrderBy(Function(e) e).ToArray()

        oComboBox.Items.Add("所有")
        oComboBox.Items.AddRange(extensions)
        oComboBox.SelectedIndex = 0

        oListView.Columns.Item(0).Width = -1
        oListView.Columns.Item(4).Width = -1
        oListView.Columns.Item(0).Width = oListView.Columns.Item(0).Width + 20

    End Sub

    'Public Sub ProcessFilesAndDirectories(folderPath As String, listView As ListView, imageList As ImageList, comboBox As ComboBox)
    '    Try
    '        ' 处理当前目录中的文件

    '        ' 获取文件目录信息
    '        Dim dirInfo As New DirectoryInfo(folderPath)

    '        For Each strFile In dirInfo.GetFiles()
    '            AddItemToList(strFile.FullName, False, strFile.Name, strFile.Extension, strFile.LastWriteTime, strFile.Length, True)

    '        Next

    '        ' 递归处理子目录
    '        For Each subDirectory In Directory.GetDirectories(folderPath)
    '            ProcessFilesAndDirectories(subDirectory, listView, imageList, comboBox)
    '        Next
    '    Catch ex As UnauthorizedAccessException
    '        ' 记录或忽略无法访问的目录
    '        Console.WriteLine("无权访问目录: " & folderPath)
    '    Catch ex As Exception
    '        ' 处理其他可能的异常
    '        Console.WriteLine("错误: " & ex.Message)
    '    End Try
    'End Sub


    'Public Sub ProcessFilesFast(rootPath As String, listView As ListView, imageList As ImageList, comboBox As ComboBox)
    '    Dim dirInfo As New DirectoryInfo(rootPath)

    '    Try
    '        ' 延迟加载所有目录文件（高效遍历）
    '        For Each oFile In dirInfo.EnumerateFiles("*.*", IO.SearchOption.AllDirectories)
    '            ' 处理文件（例如输出路径）
    '            AddItemToList(oFile.FullName, False, oFile.Name, oFile.Extension, oFile.LastWriteTime, oFile.Length, True)
    '        Next
    '    Catch ex As UnauthorizedAccessException
    '        ' 通过递归补漏无权限目录
    '        HandleUnauthorizedDir(rootPath, listView, imageList, comboBox)
    '    End Try
    'End Sub

    'Private Sub HandleUnauthorizedDir(baseDir As String, listView As ListView, imageList As ImageList, comboBox As ComboBox)
    '    Try
    '        ' 先处理当前层文件
    '        For Each strFile In Directory.EnumerateFiles(baseDir)
    '            Dim ofile As FileInfo = New FileInfo(strFile)
    '            AddItemToList(ofile.FullName, False, ofile.Name, ofile.Extension, ofile.LastWriteTime, ofile.Length, True)
    '        Next

    '        ' 再逐层处理子目录
    '        For Each subDir In Directory.EnumerateDirectories(baseDir)
    '            ProcessFilesFast(subDir, listView, imageList, comboBox) ' 递归深度可控
    '        Next
    '    Catch ex As UnauthorizedAccessException
    '        Console.WriteLine($"跳过无权限目录: {baseDir}")
    '    End Try
    'End Sub


    ''' <summary>
    ''' 加载文件夹内容
    ''' </summary>
    ''' <param name="strFolderPath">文件夹路径</param>
    ''' <param name="oListView">listview 文件列表</param>
    ''' <param name="oImageList">imagelist 图标</param>
    ''' <param name="oComboBox">combobox 扩展名筛选</param>
    Public Sub LoadFolderContents(ByVal strfolderPath As String, ByVal oListView As ListView, ByVal oImageList As ImageList, ByVal oComboBox As ComboBox)
        ' 清空所有缓存和控件
        oListView.Items.Clear()
        oComboBox.Items.Clear()
        AllItems.Clear()
        oImageList.Images.Clear()
        iconCache.Clear()

        ' 添加默认文件夹图标到缓存（确保第一个图标位置）
        Using folderIcon As Icon = GetFolderIcon()
            oImageList.Images.Add(folderIcon)
            iconCache.Add("FOLDER", 0)
        End Using

        ' 获取文件目录信息
        Dim oDirectoryInfo As New DirectoryInfo(strfolderPath)

        ' 先加载文件夹
        For Each strDir In oDirectoryInfo.GetDirectories()
            AddItemToList(strDir.FullName, True, strDir.Name, "Folder", strDir.LastWriteTime, 0, False)
        Next

        ' 再加载文件
        For Each oFileInfo In oDirectoryInfo.GetFiles()
            AddItemToList(oFileInfo.FullName, False, oFileInfo.Name, oFileInfo.Extension, oFileInfo.LastWriteTime, oFileInfo.Length, False)
        Next

        ' 加载排序后的扩展名
        Dim extensions = oDirectoryInfo.GetFiles().Select(Function(f) f.Extension.ToLower().Substring(1）).Distinct().OrderBy(Function(e) e).ToArray()

        oComboBox.Items.Add("所有")
        oComboBox.Items.AddRange(extensions)
        oComboBox.SelectedIndex = 0

        oListView.Columns.Item(0).Width = -1
        oListView.Columns.Item(4).Width = -1
        oListView.Columns.Item(0).Width = oListView.Columns.Item(0).Width + 20

    End Sub

    ''' <summary>
    ''' 获取文件夹图标
    ''' </summary>
    Private Function GetFolderIcon() As Icon
        'Dim shell32Path As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "shell32.dll")
        'Return Icon.ExtractAssociatedIcon(shell32Path)

        Return My.Resources.新建文件夹16
    End Function

    ''' <summary>
    ''' 格式化文件大小
    ''' </summary>
    ''' <param name="bytes"></param>
    ''' <returns></returns>
    Private Function FormatSize(ByVal bytes As Long) As String
        Dim units = {"B", "KB", "MB", "GB"}
        Dim size = CDbl(bytes)
        Dim unitIndex = 0

        While size >= 1024 AndAlso unitIndex < units.Length - 1
            size /= 1024
            unitIndex += 1
        End While

        Select Case unitIndex
            Case 0 ' B单位
                Return $"{CInt(size)} {units(unitIndex)}"
            Case 1 ' KB单位
                Dim integerPart As Integer = CInt(Math.Floor(size))
                Return $"{integerPart + 1} {units(unitIndex)}"
            Case Else ' MB/GB单位
                Return $"{size:N2} {units(unitIndex)}"
        End Select
    End Function

    ''' <summary>
    ''' 添加项目到列表
    ''' </summary>
    ''' <param name="fullPath">文件完整路径</param>
    ''' <param name="isFolder">是否文件夹标记</param>
    ''' <param name="name">文件夹</param>
    ''' <param name="extension">扩展名</param>
    ''' <param name="lastWriteTime">修改日期</param>
    ''' <param name="size">文件大小</param>
    ''' <param name="isSearch">是否为搜索模式</param>
    Private Sub AddItemToList(
      ByVal fullPath As String,
        ByVal isFolder As Boolean,
      ByVal name As String,
       ByVal extension As String,
      ByVal lastWriteTime As DateTime,
       ByVal size As Long,
      ByVal isSearch As Boolean)

        ' 获取图标
        Dim iconIndex = GetIconIndex(fullPath, isFolder, ImageList文件列表)

        ' 创建 ListViewItem

        Dim item As New ListViewItem(name)
        If isSearch = True Then
            item.Text = fullPath
        End If

        On Error Resume Next

        item.ImageIndex = iconIndex
        item.SubItems.Add(If(isFolder, "", extension.Substring(1)))
        item.SubItems.Add(lastWriteTime.ToString("yyyy/MM/dd HH:mm"))
        '        item.SubItems.Add(If(isFolder, "", (size / 1024).ToString("N0") & " KB"))
        item.SubItems.Add(If(isFolder, "", FormatSize(size)))
        item.SubItems.Add(If(isFolder, "文件夹", GetFileTypeDescription(extension)))

        ' 添加到缓存
        AllItems.Add(item)
    End Sub

    ''' <summary>
    ''' 文件类型描述
    ''' </summary>
    ''' <param name="strExtension"></param>
    ''' <returns></returns>
    Private Function GetFileTypeDescription(ByVal strExtension As String) As String
        Dim shinfo As New SHFILEINFO()
        SHGetFileInfo(
            strExtension,
            FileAttributes.Normal,
            shinfo,
            CUInt(Marshal.SizeOf(shinfo)),
            SHGFI_USEFILEATTRIBUTES Or SHGFI_TYPENAME)

        Return If(shinfo.szTypeName.StartsWith("."), "未知类型", shinfo.szTypeName)
    End Function


    ''' <summary>
    '''      过滤功能
    ''' </summary>
    ''' <param name="strTextFilter"></param>
    ''' <param name="strExtensionFilter"></param>
    Private Sub FilterListView(strTextFilter As String, strExtensionFilter As String)
        Lvw文件列表.Items.Clear()
        For Each item In AllItems
            Dim nameMatch = item.Text.IndexOf(strTextFilter, StringComparison.OrdinalIgnoreCase) >= 0
            Dim isFolder = item.SubItems(4).Text = "文件夹"
            Dim extMatch = strExtensionFilter = "所有" OrElse
                          item.SubItems(1).Text.Equals(strExtensionFilter, StringComparison.OrdinalIgnoreCase)

            If nameMatch AndAlso (isFolder OrElse extMatch) Then
                Lvw文件列表.Items.Add(CType(item.Clone(), ListViewItem))
            End If
        Next
    End Sub


    '============================================================================

    ''' <summary>
    ''' 获取父文件夹路径
    ''' </summary>
    ''' <param name="strFolderPath">需要获取父文件夹的路径</param>
    ''' <returns></returns>
    Public Function GetParentFolderPath(ByVal strFolderPath As String) As String
        If String.IsNullOrEmpty(strFolderPath) Then
            Return String.Empty
        End If

        Try
            ' 规范化为完整路径（自动处理相对路径和多余斜杠）
            Dim fullPath As String = Path.GetFullPath(strFolderPath)

            ' 判断是否为根目录
            If IsRootDirectory(fullPath) Then
                Return String.Empty ' 根目录无父目录，返回空字符串
            End If

            ' 获取父目录
            Dim parentDir As DirectoryInfo = Directory.GetParent(fullPath)

            If parentDir IsNot Nothing Then
                Return parentDir.FullName
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            ' 处理无效路径（如格式错误或权限不足）
            Return String.Empty
        End Try
    End Function

    ''' <summary>
    ''' 判断路径是否为根目录
    ''' </summary>
    ''' <param name="strFolderPath">需要判断的目录</param>
    ''' <returns></returns>
    Private Function IsRootDirectory(ByVal strFolderPath As String) As Boolean
        ' 移除末尾的斜杠（统一格式）
        strFolderPath = strFolderPath.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)

        ' 本地驱动器根目录（如 "C:\"）
        If strFolderPath.Length = 3 AndAlso strFolderPath(1) = ":"c AndAlso strFolderPath(2) = Path.DirectorySeparatorChar Then
            Return True
        End If

        ' 网络路径根目录（如 "\\server\share"）
        If strFolderPath.StartsWith("\\") Then
            Dim parts As String() = strFolderPath.Split(New Char() {Path.DirectorySeparatorChar}, StringSplitOptions.RemoveEmptyEntries)
            If parts.Length = 2 Then ' 网络根目录格式为 \\server\share
                Return True
            End If
        End If

        Return False
    End Function

    ''' <summary>
    ''' 删除文件或文件夹
    ''' </summary>
    '''  <param name="olistView">被选择的项</param>
    ''' <param name="IsMoveToRecycleBin">是否移动到回收站</param>

    Private Sub DeleteItem(ByRef oListView As ListView, ByVal IsMoveToRecycleBin As Boolean)


        If Lvw文件列表.SelectedItems.Count = 0 Then Return

        For Each oListViewItem As ListViewItem In Lvw文件列表.SelectedItems


            'Dim selectedItem = oListView.SelectedItems(0)
            Dim strSelectPath = Path.Combine(strCurrentDirectory, oListViewItem.Text)

            Try
                If Directory.Exists(strSelectPath) Then
                    ' 删除文件夹
                    If IsMoveToRecycleBin Then
                        Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(strSelectPath, UIOption.AllDialogs, RecycleOption.SendToRecycleBin)
                    Else
                        Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(strSelectPath, UIOption.AllDialogs, RecycleOption.DeletePermanently)
                    End If
                ElseIf File.Exists(strSelectPath) Then
                    ' 删除文件
                    If IsMoveToRecycleBin Then
                        Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(strSelectPath, UIOption.AllDialogs, RecycleOption.SendToRecycleBin)
                    Else
                        Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(strSelectPath, UIOption.AllDialogs, RecycleOption.DeletePermanently)
                    End If
                End If
            Catch ex As Exception

            End Try

            Try
                If Directory.Exists(strSelectPath) Then
                    Exit Sub
                ElseIf File.Exists(strSelectPath) Then
                    Exit Sub
                End If

            Catch ex As Exception

            End Try


            For Each item In AllItems
                If item.Text = oListViewItem.Text Then
                    AllItems.Remove(item)
                    Exit For
                End If
            Next

            oListViewItem.Remove()

        Next

    End Sub

    '------------------------------------------

    Private Sub FormExplorer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Icon = My.Resources.XHTool48
        'Me.TopMost = True

        Dim toolTip As New ToolTip With {
            .AutoPopDelay = 0,
            .InitialDelay = 0,
            .ReshowDelay = 500
        }
        toolTip.SetToolTip(Btn向上, "上级目录。")
        toolTip.SetToolTip(Cmb当前文件夹, "当前文件夹。")
        toolTip.SetToolTip（Btn搜索， “搜索，显示全部子文件中包含字符的文件。”）
        toolTip.SetToolTip(Btn过滤, "过滤，仅显示包含字符的文件。")


        项目文件夹ToolStripButton.Image = My.Resources.主页16.ToBitmap
        当前文件夹ToolStripButton.Image = My.Resources.资源管理器16.ToBitmap
        浏览文件ToolStripButton.Image = My.Resources.打开文件夹16.ToBitmap
        新建文件夹ToolStripButton.Image = My.Resources.新建文件夹16.ToBitmap
        打开ToolStripButton.Image = My.Resources.打开16.ToBitmap
        删除ToolStripDropDownButton.Image = My.Resources.删除16.ToBitmap
        回收ToolStripMenuItem.Image = My.Resources.回收16.ToBitmap
        永久删除ToolStripMenuItem.Image = My.Resources.删除16.ToBitmap
        插入ToolStripButton.Image = My.Resources.插入16.ToBitmap
        旧版ToolStripDropDownButton.Image = My.Resources.还原旧版文件16.ToBitmap
        Btn向上.Image = My.Resources.向上16.ToBitmap
        Btn搜索.Image = My.Resources.查询16.ToBitmap
        Btn过滤.Image = My.Resources.过滤16.ToBitmap

        ' 初始化筛选组合框
        Cmb过滤.Items.Add("所有")
        Cmb过滤.SelectedIndex = 0


        With ImageList文件列表
            .ColorDepth = ColorDepth.Depth32Bit ' 设置颜色深度
        End With

        With Lvw文件列表
            .View = View.Details
            .SmallImageList = ImageList文件列表
            .FullRowSelect = True
            .ContextMenuStrip = CMS文件列表
            .OwnerDraw = True
            .MultiSelect = True
        End With

        EnableDoubleBuffering(Lvw文件列表)

        SetDoubleBuffered(Lvw文件列表)

        If ThisApplication.ActiveDocument IsNot Nothing Then
            strCurrentDirectory = GetFileNameInfo(ThisApplication.ActiveDocument.FullDocumentName).Folder
        End If
        If IsDirectoryExists(strCurrentDirectory) = False Then
            Dim strWorkspacePath As String = ThisApplication.DesignProjectManager.ActiveDesignProject.WorkspacePath

            If IsDirectoryExists(strWorkspacePath) = True Then
                strCurrentDirectory = strWorkspacePath
            Else
                strCurrentDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            End If

        End If

        Dim strFilter As String = Cmb过滤.Text

        If Directory.Exists(strCurrentDirectory) Then
            LoadFolderContents(strCurrentDirectory, Lvw文件列表, ImageList文件列表, Cmb过滤)

            '加载父文件夹到 Cmb当前文件夹 
            AddFolderPathToComboBox(strCurrentDirectory， Cmb当前文件夹)

            Cmb当前文件夹.SelectedIndex = 0

            状态ToolStripStatusLabel.Text = Lvw文件列表.Items.Count & "个项目"

        Else
            MessageBox.Show("文件夹路径不存在！", XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        SetWindowSizeAndCenter(Me, 0.4, 0.5)

    End Sub

    Private Sub Btn向上_Click(sender As Object, e As EventArgs) Handles Btn向上.Click

        Dim strParentDirectory = GetParentFolderPath(strCurrentDirectory)

        If strParentDirectory = "" Then
            Exit Sub
        Else
            strCurrentDirectory = strParentDirectory
        End If

        Dim strFilter As String = Cmb过滤.Text
        LoadFolderContents(strCurrentDirectory, Lvw文件列表, ImageList文件列表, Cmb过滤)
        Cmb当前文件夹.Text = strCurrentDirectory
    End Sub

    Private Sub 项目文件夹ToolStripButton_Click(sender As Object, e As EventArgs) Handles 项目文件夹ToolStripButton.Click
        Dim strWorkspacePath As String = ThisApplication.DesignProjectManager.ActiveDesignProject.WorkspacePath

        If IsDirectoryExists(strWorkspacePath) = True Then
            strCurrentDirectory = strWorkspacePath
        Else
            strCurrentDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
        End If

        LoadFolderContents(strCurrentDirectory, Lvw文件列表, ImageList文件列表, Cmb过滤)

        '加载父文件夹到 Cmb当前文件夹 
        AddFolderPathToComboBox(strCurrentDirectory， Cmb当前文件夹)

        Cmb当前文件夹.SelectedIndex = 0
        状态ToolStripStatusLabel.Text = Lvw文件列表.Items.Count & "个项目"
    End Sub

    Private Sub 新建文件夹ToolStripButton_Click(sender As Object, e As EventArgs) Handles 新建文件夹ToolStripButton.Click
        Me.TopMost = False

        Dim folderName = "新建文件夹"

        If Lvw文件列表.SelectedItems.Count <> 0 Then
            Dim selectedItem = Lvw文件列表.SelectedItems(0)
            Dim strSelectPath = Path.Combine(strCurrentDirectory, selectedItem.Text)

            If Directory.Exists(strSelectPath) Then


            ElseIf File.Exists(strSelectPath) Then
                folderName = GetFileNameWithoutExtension2(strSelectPath)
            End If

        End If

        folderName = InputBox("请输入文件夹名称：", "新建文件夹", folderName)

        Me.TopMost = True

        If String.IsNullOrEmpty(folderName) Then Return

        Dim newFolderPath = Path.Combine(strCurrentDirectory, folderName)

        Try
            Directory.CreateDirectory(newFolderPath)
            Dim strFilter As String = Cmb过滤.Text
            LoadFolderContents(strCurrentDirectory, Lvw文件列表, ImageList文件列表, Cmb过滤)
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub 打开ToolStripButton_Click(sender As Object, e As EventArgs) Handles 打开ToolStripButton.Click, Lvw文件列表.MouseDoubleClick, 打开ToolStripMenuItem.Click
        ' 双击打开文件或文件夹
        If Lvw文件列表.SelectedItems.Count = 0 Then Return


        For Each oListViewItem As ListViewItem In Lvw文件列表.SelectedItems

            'Dim selectedItem = oListView.SelectedItems(0)
            Dim strSelectPath = Path.Combine(strCurrentDirectory, oListViewItem.Text)


            If Directory.Exists(strSelectPath) Then
                ' 双击文件夹：进入文件夹
                strCurrentDirectory = strSelectPath

                Dim strFilter As String = Cmb过滤.Text
                LoadFolderContents(strCurrentDirectory, Lvw文件列表, ImageList文件列表, Cmb过滤)
                Cmb当前文件夹.Text = strCurrentDirectory

                '加载父文件夹到 Cmb当前文件夹 
                AddFolderPathToComboBox(strCurrentDirectory， Cmb当前文件夹)

                Exit For

            ElseIf File.Exists(strSelectPath) Then
                ' 双击文件：打开文件
                Try

                    Select Case GetFileExtensionLCase(strSelectPath)
                        Case IAM, IPT, IDW, ".ipn"
                            ThisApplication.Documents.Open(strSelectPath)
                        Case Else
                            Process.Start(strSelectPath)
                    End Select


                Catch ex As Exception
                    MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

        Next
    End Sub

    Private Sub 回收ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 回收ToolStripMenuItem.Click, 删除ToolStripMenuItem.Click
        DeleteItem(Lvw文件列表, IsMoveToRecycleBin:=True)
    End Sub

    Private Sub 永久删除ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 永久删除ToolStripMenuItem.Click
        DeleteItem(Lvw文件列表, IsMoveToRecycleBin:=False)
    End Sub

    Private Sub 插入ToolStripButton_Click(sender As Object, e As EventArgs) Handles 插入ToolStripButton.Click, 插入到部件ToolStripMenuItem.Click
        If Lvw文件列表.SelectedItems.Count = 0 Then Return

        Dim selectedItem = Lvw文件列表.SelectedItems(0)
        Dim strSelectPath = Path.Combine(strCurrentDirectory, selectedItem.Text)

        Select Case GetFileExtensionLCase(strSelectPath)
            Case IAM, IPT
                If ThisApplication.ActiveDocumentType <> Inventor.DocumentTypeEnum.kAssemblyDocumentObject Then
                    Exit Sub
                End If

                If ThisApplication.ActiveDocument.FullDocumentName = strSelectPath Then
                    Exit Sub
                End If

                ThisApplication.CommandManager.PostPrivateEvent(Inventor.PrivateEventTypeEnum.kFileNameEvent, strSelectPath)
                ThisApplication.CommandManager.ControlDefinitions.Item("AssemblyPlaceComponentCmd").Execute()

        End Select

    End Sub

    Private Sub Txt过滤栏_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt过滤栏.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            FilterListView(Txt过滤栏.Text, Cmb过滤.Text)
            状态ToolStripStatusLabel.Text = Lvw文件列表.Items.Count & "个项目"
        End If
    End Sub

    Private Sub Txt搜索栏_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt搜索栏.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            LoadFolderAllContents(strCurrentDirectory, Lvw文件列表, ImageList文件列表, Cmb过滤)

            FilterListView(Txt搜索栏.Text, Cmb过滤.Text)

            状态ToolStripStatusLabel.Text = Lvw文件列表.Items.Count & "个项目"
        End If
    End Sub

    Private Sub Cmb过滤_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb过滤.SelectedIndexChanged
        FilterListView(Txt过滤栏.Text, Cmb过滤.Text)
        状态ToolStripStatusLabel.Text = Lvw文件列表.Items.Count & "个项目"
    End Sub

    Private Sub Cmb当前文件夹_KeyDown(sender As Object, e As KeyEventArgs) Handles Cmb当前文件夹.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            strCurrentDirectory = Cmb当前文件夹.Text.Trim()

            If Directory.Exists(strCurrentDirectory) Then
                LoadFolderContents(strCurrentDirectory, Lvw文件列表, ImageList文件列表, Cmb过滤)

                '加载父文件夹到 Cmb当前文件夹 
                AddFolderPathToComboBox(strCurrentDirectory， Cmb当前文件夹)
            End If
        End If
    End Sub

    Private Sub Cmb当前文件夹_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb当前文件夹.SelectedIndexChanged
        If strCurrentDirectory = Cmb当前文件夹.SelectedItem.ToString.Trim Then Exit Sub

        strCurrentDirectory = Cmb当前文件夹.SelectedItem.ToString

        If Directory.Exists(strCurrentDirectory) Then
            LoadFolderContents(strCurrentDirectory, Lvw文件列表, ImageList文件列表, Cmb过滤)

            '加载父文件夹到 Cmb当前文件夹 
            AddFolderPathToComboBox(strCurrentDirectory， Cmb当前文件夹)

            Cmb当前文件夹.SelectedIndex = 0
        End If
    End Sub

    ''' <summary>
    ''' 添加 文件夹到Cmb当前文件夹
    ''' </summary>
    ''' <param name="targetFolder"></param>
    ''' <param name="oComBoBox"></param>
    Private Sub AddFolderPathToComboBox(ByVal targetFolder As String, oComBoBox As ComboBox)

        oComBoBox.Items.Clear()

        ' 步骤1: 添加目标文件夹及其所有父文件夹的完整路径
        Dim CurrentDir As New DirectoryInfo(targetFolder)
        Dim existingPaths As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase) ' 用于去重

        ' 从当前文件夹逐级向上遍历到根目录
        Do
            Dim path As String = CurrentDir.FullName
            If Not existingPaths.Contains(path) Then
                oComBoBox.Items.Add(path)
                existingPaths.Add(path)
            End If
            CurrentDir = CurrentDir.Parent
        Loop While CurrentDir IsNot Nothing

        ' 步骤2: 添加所有磁盘驱动器路径（排除已存在的根目录）
        Dim driveList As New List(Of String)

        For Each drive As DriveInfo In DriveInfo.GetDrives()
            Try
                ' 获取驱动器根目录（例如 "C:\"）
                Dim rootPath As String = drive.Name.TrimEnd(Path.DirectorySeparatorChar) & Path.DirectorySeparatorChar
                If Not existingPaths.Contains(rootPath) Then
                    driveList.Add(rootPath)
                    existingPaths.Add(rootPath)
                End If
            Catch ex As Exception
                ' 忽略无法访问的驱动器（如未就绪的U盘）
            End Try
        Next

        ' 按字母顺序排序驱动器路径并添加到 ComboBox
        driveList.Sort()
        For Each drivePath In driveList
            oComBoBox.Items.Add(drivePath)
        Next

        ' 默认选中第一个项（当前文件夹）
        If oComBoBox.Items.Count > 0 Then
            oComBoBox.SelectedIndex = 0
        End If

    End Sub
    '以下是 listview 设置背景色

    ''' <summary>
    ''' 启用双缓冲的核心方法
    ''' </summary>
    ''' <param name="oListView"></param>
    Private Sub EnableDoubleBuffering(oListView As ListView)
        SendMessage(oListView.Handle, LVM_SETEXTENDEDLISTVIEWSTYLE, LVS_EX_DOUBLEBUFFER, LVS_EX_DOUBLEBUFFER)
    End Sub

    ''' <summary>
    '''  智能颜色更新方法
    ''' </summary>
    '''  <param name="oListView"></param>
    Private Sub UpdateItemColor(oListView As ListView)
        ' 当悬停项变化时执行
        If currentHoverItem IsNot previousHoverItem Then
            ' 使用BeginUpdate暂停重绘
            oListView.BeginUpdate()

            Try
                ' 恢复前一个项的颜色（如果存在且未被选中）
                If previousHoverItem IsNot Nothing AndAlso Not previousHoverItem.Selected Then
                    previousHoverItem.BackColor = oListView.BackColor
                End If

                ' 设置新悬停项颜色（如果存在且未被选中）
                If currentHoverItem IsNot Nothing AndAlso Not currentHoverItem.Selected Then
                    currentHoverItem.BackColor = Color.FromArgb（204， 232， 255）
                End If

                previousHoverItem = currentHoverItem
            Finally
                ' 确保恢复重绘
                oListView.EndUpdate()
            End Try
        End If
    End Sub

    ''' <summary>
    '''  鼠标移动事件（优化版）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Lvw文件列表_MouseMove(sender As Object, e As MouseEventArgs) Handles Lvw文件列表.MouseMove
        Dim hitInfo = Lvw文件列表.HitTest(e.Location)
        currentHoverItem = hitInfo.Item
        UpdateItemColor(Lvw文件列表)
    End Sub

    ''' <summary>
    ''' ' 鼠标离开事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Lvw文件列表_MouseLeave(sender As Object, e As EventArgs) Handles Lvw文件列表.MouseLeave
        currentHoverItem = Nothing
        UpdateItemColor(Lvw文件列表)
    End Sub


    ''' <summary>
    '''      自定义绘制（关键消除闪烁）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Lvw文件列表_DrawSubItem(sender As Object, e As DrawListViewSubItemEventArgs) Handles Lvw文件列表.DrawSubItem
        ' 绘制背景（保持原有逻辑）
        If e.Item.Selected Then
            e.Graphics.FillRectangle(New SolidBrush(SystemColors.Highlight), e.Bounds)
        ElseIf e.Item Is currentHoverItem Then
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb（204， 232， 255）), e.Bounds)
        Else
            e.Graphics.FillRectangle(New SolidBrush(Lvw文件列表.BackColor), e.Bounds)
        End If

        ' 仅在第一列绘制图标
        If e.ColumnIndex = 0 Then
            Dim iconRect As New Rectangle(e.Bounds.Left + 2,
                                    e.Bounds.Top + (e.Bounds.Height - Lvw文件列表.SmallImageList.ImageSize.Height) \ 2,
                                    Lvw文件列表.SmallImageList.ImageSize.Width,
                                    Lvw文件列表.SmallImageList.ImageSize.Height)

            ' 绘制图标
            If e.Item.ImageIndex >= 0 Then
                Lvw文件列表.SmallImageList.Draw(e.Graphics,
                                        iconRect.Location,
                                        e.Item.ImageIndex)
            End If

            ' 调整文本绘制区域
            Dim textRect = New Rectangle(iconRect.Right + 4,
                                   e.Bounds.Top,
                                   e.Bounds.Width - iconRect.Width - 6,
                                   e.Bounds.Height)
            TextRenderer.DrawText(e.Graphics,
                            e.SubItem.Text,
                            e.SubItem.Font,
                            textRect,
                            If(e.Item.Selected, Drawing.SystemColors.HighlightText, Lvw文件列表.ForeColor),
                            TextFormatFlags.VerticalCenter Or TextFormatFlags.Left)
        Else
            ' 其他列保持原有文本绘制
            TextRenderer.DrawText(e.Graphics,
                            e.SubItem.Text,
                            e.SubItem.Font,
                            e.Bounds,
                            If(e.Item.Selected, Drawing.SystemColors.HighlightText, Lvw文件列表.ForeColor),
                            TextFormatFlags.VerticalCenter Or TextFormatFlags.Left)
        End If
    End Sub

    ''' <summary>
    ''' 确保表头正确绘制
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Lvw文件列表_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles Lvw文件列表.DrawColumnHeader
        e.DrawDefault = True
    End Sub


    ''' <summary>
    ''' 处理选中状态变化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Lvw文件列表_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Lvw文件列表.SelectedIndexChanged
        Lvw文件列表.BeginUpdate()
        For Each item As ListViewItem In Lvw文件列表.Items
            If item.Selected Then
                item.BackColor = Drawing.SystemColors.Highlight
            ElseIf item Is currentHoverItem Then
                item.BackColor = Drawing.Color.FromArgb（204， 232， 255）
            Else
                item.BackColor = Lvw文件列表.BackColor
            End If
        Next
        Lvw文件列表.EndUpdate()
    End Sub

    Private Sub 当前文件夹ToolStripButton_Click(sender As Object, e As EventArgs) Handles 当前文件夹ToolStripButton.Click

        If ThisApplication.ActiveDocument IsNot Nothing Then
            strCurrentDirectory = GetFileNameInfo(ThisApplication.ActiveDocument.FullDocumentName).Folder
        End If

        If IsDirectoryExists(strCurrentDirectory) = False Then
            Dim strWorkspacePath As String = ThisApplication.DesignProjectManager.ActiveDesignProject.WorkspacePath

            If IsDirectoryExists(strWorkspacePath) = True Then
                strCurrentDirectory = strWorkspacePath
            Else
                strCurrentDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            End If

        End If

        LoadFolderContents(strCurrentDirectory, Lvw文件列表, ImageList文件列表, Cmb过滤)

        '加载父文件夹到 Cmb当前文件夹 
        AddFolderPathToComboBox(strCurrentDirectory， Cmb当前文件夹)

        Cmb当前文件夹.SelectedIndex = 0
        状态ToolStripStatusLabel.Text = Lvw文件列表.Items.Count & "个项目"

    End Sub

    Private Sub 设置旧版ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 设置旧版ToolStripMenuItem.Click
        If Lvw文件列表.SelectedItems.Count = 0 Then Return

        For Each oListViewItem As ListViewItem In Lvw文件列表.SelectedItems

            'Dim selectedItem = oListView.SelectedItems(0)
            Dim strSelectPath = Path.Combine(strCurrentDirectory, oListViewItem.Text)

            If Directory.Exists(strSelectPath) Then

            ElseIf File.Exists(strSelectPath) Then
                Try
                    If MessageBox.Show("确定将文件：" & strSelectPath & " 设置为旧版？", XHTool, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                        = DialogResult.No Then
                        Exit Sub
                    End If

                    Dim stroldFileName As String = Path.Combine(strCurrentDirectory, oListViewItem.Text & ".old")
                    Rename(strSelectPath, stroldFileName)
                    LoadFolderContents(strCurrentDirectory, Lvw文件列表, ImageList文件列表, Cmb过滤)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

        Next
    End Sub

    Private Sub 还原旧版ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 还原旧版ToolStripMenuItem.Click
        If Lvw文件列表.SelectedItems.Count = 0 Then Return

        For Each oListViewItem As ListViewItem In Lvw文件列表.SelectedItems

            'Dim selectedItem = oListView.SelectedItems(0)
            Dim strSelectPath = Path.Combine(strCurrentDirectory, oListViewItem.Text)

            If Directory.Exists(strSelectPath) Then

            ElseIf File.Exists(strSelectPath) Then

                Try

                    If Strings.Right（strSelectPath, 4).ToLower <> ".old" Then
                        MessageBox.Show(”仅支持 .old 文件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    Dim stroldFileName As String = Strings.Left(strSelectPath, Strings.Len(strSelectPath) - 4)
                    Rename(strSelectPath, stroldFileName)
                    LoadFolderContents(strCurrentDirectory, Lvw文件列表, ImageList文件列表, Cmb过滤)

                Catch ex As Exception
                    MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Next
    End Sub

    Private Sub 浏览文件ToolStripButton_Click(sender As Object, e As EventArgs) Handles 浏览文件ToolStripButton.Click， 浏览文件ToolStripMenuItem.Click

        Process.Start(strCurrentDirectory)


    End Sub

    Private Sub 属性ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 属性ToolStripMenuItem.Click
        If Lvw文件列表.SelectedItems.Count = 0 Then Return

        Dim selectedItem = Lvw文件列表.SelectedItems(0)
        Dim strSelectPath = Path.Combine(strCurrentDirectory, selectedItem.Text)


        Try
            Dim sei As New SHELLEXECUTEINFO()
            sei.cbSize = Marshal.SizeOf(sei)
            sei.fMask = SEE_MASK_INVOKEIDLIST
            sei.lpVerb = "properties"
            sei.lpFile = strSelectPath
            sei.nShow = SW_SHOW
            sei.hwnd = Me.Handle

            If Not ShellExecuteEx(sei) Then
                MessageBox.Show("无法打开属性窗口！", XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub 复制ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 复制ToolStripMenuItem.Click
        If Lvw文件列表.SelectedItems.Count = 0 Then Return

        Try
            ' 创建一个StringCollection存储文件路径
            Dim filePaths As New StringCollection()

            ' 遍历所有选中的ListView项
            For Each oListViewItem As ListViewItem In Lvw文件列表.SelectedItems
                Dim filePath As String = Path.Combine(strCurrentDirectory, oListViewItem.Text) ' 假设文件名直接存储在Text属性中
                filePaths.Add(filePath)
            Next

            ' 将文件路径集合复制到剪贴板（支持粘贴到资源管理器）
            Clipboard.SetFileDropList(filePaths)

        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub Btn搜索_Click(sender As Object, e As EventArgs) Handles Btn搜索.Click
        LoadFolderAllContents(strCurrentDirectory, Lvw文件列表, ImageList文件列表, Cmb过滤)

        FilterListView(Txt搜索栏.Text, Cmb过滤.Text)

        状态ToolStripStatusLabel.Text = Lvw文件列表.Items.Count & "个项目"
    End Sub

    Private Sub Btn过滤_Click(sender As Object, e As EventArgs) Handles Btn过滤.Click
        FilterListView(Txt过滤栏.Text, Cmb过滤.Text)
        状态ToolStripStatusLabel.Text = Lvw文件列表.Items.Count & "个项目"
    End Sub

    Private Sub 重命名ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 重命名ToolStripMenuItem.Click
        If Lvw文件列表.SelectedItems.Count = 0 Then Return

        Dim selectedItem = Lvw文件列表.SelectedItems(0)

        Dim strOldName As String = selectedItem.Text

        '当前选择项的路径
        Dim strSelectPath As String = IO.Path.Combine(strCurrentDirectory, strOldName)

        Dim strNewName As String = InputBox("输入新的名字："， “重命名”, strOldName)

        If strNewName = "" Or strNewName = strOldName Then
            Exit Sub
        End If

        Dim strNewPath As String = IO.Path.Combine(strCurrentDirectory, strNewName)

        Try
            If Directory.Exists(strSelectPath) Then
                IO.Directory.Move(strSelectPath, strNewPath)
            ElseIf File.Exists(strSelectPath) Then
                BasicFileSystem.ReFileName(strSelectPath, strNewPath)
            End If
        Catch ex As Exception

        End Try

        Try
            If Directory.Exists(strSelectPath) Then
                Exit Sub
            ElseIf File.Exists(strSelectPath) Then
                Exit Sub
            End If

        Catch ex As Exception

        End Try


        For Each item In AllItems
            If item.Text = Lvw文件列表.SelectedItems(0).Text Then

                If Directory.Exists(strNewPath) Then
                    item.Text = strNewName
                    Lvw文件列表.SelectedItems(0).Text = strNewName
                ElseIf File.Exists(strNewPath) Then
                    item.Text = GetFileNameWithExtension(strNewPath)
                    Lvw文件列表.SelectedItems(0).Text = item.Text
                End If

                Exit For
            End If
        Next


    End Sub

    Private Sub 复制文件名ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 复制文件名ToolStripMenuItem.Click
        If Lvw文件列表.SelectedItems.Count = 0 Then Return

        Dim selectedItem = Lvw文件列表.SelectedItems(0)
        Dim strSelectPath = selectedItem.Text

        Clipboard.SetData(DataFormats.Text, CType(strSelectPath, Object))

    End Sub

    Private Sub 刷新ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 刷新ToolStripMenuItem.Click
        LoadFolderContents(strCurrentDirectory, Lvw文件列表, ImageList文件列表, Cmb过滤)
        AddFolderPathToComboBox(strCurrentDirectory， Cmb当前文件夹)

        Cmb当前文件夹.SelectedIndex = 0
        状态ToolStripStatusLabel.Text = Lvw文件列表.Items.Count & "个项目"
    End Sub


    Private Sub CMS文件列表_Opening(sender As Object, e As CancelEventArgs) Handles CMS文件列表.Opening
        ' 获取当前选中的项数量
        Dim selectedCount As Integer = Lvw文件列表.SelectedItems.Count
        If selectedCount = 1 Then
            插入到部件ToolStripMenuItem.Enabled = True
            复制文件名ToolStripMenuItem.Enabled = True
            重命名ToolStripMenuItem.Enabled = True
            属性ToolStripMenuItem.Enabled = True
        Else
            插入到部件ToolStripMenuItem.Enabled = False
            复制文件名ToolStripMenuItem.Enabled = False
            重命名ToolStripMenuItem.Enabled = False
            属性ToolStripMenuItem.Enabled = False

        End If

    End Sub

    Private Sub Lvw文件列表_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles Lvw文件列表.ItemDrag
        Dim selectedFiles As New List(Of String)

        If Lvw文件列表.SelectedItems.Count = 0 Then Return

        For Each oListViewItem As ListViewItem In Lvw文件列表.SelectedItems
            Dim strSelectPath = Path.Combine(strCurrentDirectory, oListViewItem.Text)
            If IsFileExists(strSelectPath) = True Then

                Select Case GetFileExtensionLCase(strSelectPath)
                    Case IAM, IPT, IDW, IPN
                        selectedFiles.Add(strSelectPath)
                    Case Else

                End Select

            End If
        Next

        If selectedFiles.Count > 0 Then
            Dim data As New DataObject(DataFormats.FileDrop, selectedFiles.ToArray())
            Lvw文件列表.DoDragDrop(data, DragDropEffects.Copy)
        End If
    End Sub

End Class
