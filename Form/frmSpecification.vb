Imports Inventor
Imports Inventor.DocumentTypeEnum
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class frmSpecification
    Private boolIsBasicChange As Boolean
    Private boolIsUserChange As Boolean
    Private strSpecificationIni As String

    Private oPoint2d As Point2d

    Private Sub btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub frmSpecification_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next

        Me.Icon = My.Resources.XHTool48

        '加载间距

        间距ToolStripTextBox.Text = ini.GetStrFromINI("技术要求", "行距", "1.5", IniFile)

        字体ToolStripButton.Text = ini.GetStrFromINI("技术要求", "字体", "仿宋", IniFile)

        '加载配置文件
        strSpecificationIni = IO.Path.Combine(My.Application.Info.DirectoryPath, "Specification.ini")

        if IsFileExsts(strSpecificationIni) = False Then
            MsgBox("未找到配置文件 Specification.ini", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "技术要求")
            Exit Sub
        End if

        Dim oPrasentNode As TreeNode

        Dim intNumber As Integer
        Dim strNode As String

        'oPrasentNode = TreeView基础数据树.Nodes.Add("通用技术标准")
        intNumber = 1
        strNode = GetStrFromINI("通用技术标准", intNumber.ToString, "", strSpecificationIni)
        Do While (strNode <> "")
            TreeView基础数据树.Nodes.Add(strNode)
            intNumber = intNumber + 1
            strNode = GetStrFromINI("通用技术标准", intNumber.ToString, "", strSpecificationIni)
        Loop
        TreeView基础数据树.ExpandAll()
        boolIsBasicChange = False

        'oPrasentNode = TreeView自定义.Nodes.Add("技术要求")
        intNumber = 1
        strNode = GetStrFromINI("技术要求", intNumber.ToString, "", strSpecificationIni)
        Do While (strNode <> "")
            TreeView自定义.Nodes.Add(strNode)
            intNumber = intNumber + 1
            strNode = GetStrFromINI("技术要求", intNumber.ToString, "", strSpecificationIni)
        Loop

        TreeView自定义.ExpandAll()
        boolIsUserChange = False

    End Sub

    Private Sub TreeView基础数据树_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView基础数据树.NodeMouseClick
        if e.Node.Text = "通用技术标准" Or e.Node.Text = "技术要求" Then
            Exit Sub
        End if

        if boolIsBasicChange = True Then
            if MsgBox(TreeView基础数据树.SelectedNode.Text & "  已修改，是否保存？", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then
                保存基础数据ToolStripButton.PerformClick()
            End if
        End if

        lst基础数据列表.Items.Clear()

        Dim strChildNodeName As String
        Dim strChildNodeValue As String
        Dim intNumber As Integer
        intNumber = 1

        strChildNodeName = e.Node.Text

        GroupBox基础数据.Text = "基础数据 > " & strChildNodeName

        strChildNodeValue = GetStrFromINI(strChildNodeName, intNumber.ToString, "", strSpecificationIni)
        Do While (strChildNodeValue <> "")
            lst基础数据列表.Items.Add(strChildNodeValue)
            intNumber = intNumber + 1
            strChildNodeValue = GetStrFromINI(strChildNodeName, intNumber.ToString, "", strSpecificationIni)
        Loop

        boolIsBasicChange = False
    End Sub

    Private Sub 删除自定义ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 删除自定义ToolStripButton.Click
        if lst技术要求文本.SelectedItems.Count <> 0 Then
            lst技术要求文本.Items.Remove(lst技术要求文本.SelectedItems.Item(0))
            boolIsUserChange = True
        End if
    End Sub

    Private Sub 添加自定义ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 添加自定义ToolStripButton.Click
        Dim strChildNodeValue As String
        Me.TopMost = False
        strChildNodeValue = InputBox("输入技术要求。 ", "技术要求")
        if strChildNodeValue <> "" Then
            lst技术要求文本.Items.Add(strChildNodeValue)
            boolIsUserChange = True
        End if
        Me.TopMost = True
    End Sub

    Private Sub 修改自定义ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 修改自定义ToolStripButton.Click
        Dim strChildNodeValue As String

        if lst技术要求文本.SelectedItems.Count <> 0 Then
            strChildNodeValue = lst技术要求文本.SelectedItems(0).ToString
        Else
            Exit Sub
        End if
        Me.TopMost = False
        strChildNodeValue = InputBox("输入技术要求。 ", "技术要求", strChildNodeValue)
        if strChildNodeValue <> "" Then
            lst技术要求文本.Items(lst技术要求文本.SelectedIndex) = strChildNodeValue
            boolIsUserChange = True
        End if
        Me.TopMost = True
    End Sub

    Private Sub 保存基础数据ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 保存基础数据ToolStripButton.Click
        Dim strChildNodeName As String
        Dim strChildNodeValue As String
        Dim intNumber As Integer
        intNumber = 1

        strChildNodeName = TreeView基础数据树.SelectedNode.Text

        strChildNodeValue = GetStrFromINI(strChildNodeName, intNumber.ToString, "", strSpecificationIni)
        Do While (strChildNodeValue <> "")
            EraseSection(strChildNodeName, strSpecificationIni)
            intNumber = intNumber + 1
            strChildNodeValue = GetStrFromINI(strChildNodeName, intNumber.ToString, "", strSpecificationIni)
        Loop

        For intNumber = 1 To lst基础数据列表.Items.Count
            strChildNodeValue = lst基础数据列表.Items(intNumber - 1).ToString
            WriteStrINI(strChildNodeName, intNumber.ToString, strChildNodeValue, strSpecificationIni)
        Next

        boolIsBasicChange = False
    End Sub

    Private Sub 修改基础数据ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 修改基础数据ToolStripButton.Click
        Dim strChildNodeValue As String
        Me.TopMost = False
        if lst基础数据列表.SelectedItems.Count <> 0 Then
            strChildNodeValue = lst基础数据列表.SelectedItems(0).ToString
        Else
            Me.TopMost = True
            Exit Sub
        End if

        strChildNodeValue = InputBox("输入技术要求。 ", "技术要求", strChildNodeValue)
        if strChildNodeValue <> "" Then
            lst基础数据列表.Items(lst基础数据列表.SelectedIndex) = strChildNodeValue
            boolIsBasicChange = True
        End if
        Me.TopMost = True
    End Sub

    Private Sub 删除基础数据ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 删除基础数据ToolStripButton.Click
        if lst基础数据列表.SelectedItems.Count <> 0 Then
            lst基础数据列表.Items.Remove(lst基础数据列表.SelectedItems.Item(0))
            boolIsBasicChange = True
        End if
    End Sub

    Private Sub 添加基础数据ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 添加基础数据ToolStripButton.Click
        Dim strChildNodeValue As String

        Me.TopMost = False
        strChildNodeValue = InputBox("输入技术要求。 ", "技术要求")
        if strChildNodeValue <> "" Then
            lst基础数据列表.Items.Add(strChildNodeValue)
            boolIsBasicChange = True
        End if
        Me.TopMost = True
    End Sub

    Private Sub 保存自定义ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 保存自定义ToolStripButton.Click
        Dim strChildNodeName As String
        Dim strChildNodeValue As String
        Dim intNumber As Integer
        intNumber = 1

        strChildNodeName = TreeView自定义.SelectedNode.Text

        strChildNodeValue = GetStrFromINI(strChildNodeName, intNumber.ToString, "", strSpecificationIni)
        Do While (strChildNodeValue <> "")
            EraseSection(strChildNodeName, strSpecificationIni)
            intNumber = intNumber + 1
            strChildNodeValue = GetStrFromINI(strChildNodeName, intNumber.ToString, "", strSpecificationIni)
        Loop

        For intNumber = 1 To lst技术要求文本.Items.Count
            strChildNodeValue = lst技术要求文本.Items(intNumber - 1).ToString
            WriteStrINI(strChildNodeName, intNumber.ToString, strChildNodeValue, strSpecificationIni)
        Next

        boolIsUserChange = False
    End Sub

    Private Sub 插入自定义ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 插入自定义ToolStripButton.Click

        Dim strChildNodeValue As String

        if lst基础数据列表.SelectedItems.Count <> 0 Then
            strChildNodeValue = lst基础数据列表.SelectedItems(0).ToString
            lst技术要求文本.Items.Add(strChildNodeValue)
            boolIsUserChange = True
        Else
            MsgBox("请选择基础数据。", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "技术要求")
            Exit Sub
        End if

    End Sub

    Private Sub TreeView自定义_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView自定义.NodeMouseClick
        if e.Node.Text = "通用技术标准" Or e.Node.Text = "技术要求" Then
            Exit Sub
        End if

        if boolIsUserChange = True Then
            if MsgBox(TreeView自定义.SelectedNode.Text & "  已修改，是否保存？", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then
                保存自定义ToolStripButton.PerformClick()
            End if
        End if

        lst技术要求文本.Items.Clear()

        Dim strChildNodeName As String
        Dim strChildNodeValue As String
        Dim intNumber As Integer
        intNumber = 1

        strChildNodeName = e.Node.Text

        GroupBox技术要求.Text = "技术要求 > " & strChildNodeName

        strChildNodeValue = GetStrFromINI(strChildNodeName, intNumber.ToString, "", strSpecificationIni)
        Do While (strChildNodeValue <> "")
            lst技术要求文本.Items.Add(strChildNodeValue)
            intNumber = intNumber + 1
            strChildNodeValue = GetStrFromINI(strChildNodeName, intNumber.ToString, "", strSpecificationIni)
        Loop

        boolIsUserChange = False
    End Sub

    Private Sub 新建自定义ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 新建自定义ToolStripButton.Click
        Dim strChildNodeName As String

        Me.TopMost = False

        strChildNodeName = InputBox("输入新技术要求名称！", "技术要求")

        if strChildNodeName <> "" Then
            TreeView自定义.Nodes.Add(strChildNodeName)
            if boolIsUserChange = True Then
                if MsgBox(TreeView自定义.SelectedNode.Text & "  已修改，是否保存？", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then
                    保存自定义ToolStripButton.PerformClick()
                End if
            End if
            lst技术要求文本.Items.Clear()

            Dim strChildNodeValue As String
            Dim intNumber As Integer
            intNumber = 1

            strChildNodeName = "技术要求"
            EraseSection(strChildNodeName, strSpecificationIni)

            '重写列表
            For intNumber = 1 To TreeView自定义.Nodes.Count
                strChildNodeValue = TreeView自定义.Nodes.Item(intNumber - 1).Text
                WriteStrINI(strChildNodeName, intNumber.ToString, strChildNodeValue, strSpecificationIni)
            Next

            boolIsUserChange = False

        End if

        Me.TopMost = True

    End Sub

    Private Sub 自动编号ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 自动编号ToolStripMenuItem.Click
        Dim strFlag As String
        Dim strChildNodeValue As String
        Dim intNumber As Integer

        For intNumber = 1 To lst技术要求文本.Items.Count
            strChildNodeValue = lst技术要求文本.Items(intNumber - 1).ToString
            strFlag = intNumber.ToString & "."
            if Strings.Left(strChildNodeValue, 2) <> strFlag Then
                strChildNodeValue = strFlag & strChildNodeValue
                lst技术要求文本.Items(intNumber - 1) = strChildNodeValue
            End if
        Next
        boolIsUserChange = True
    End Sub

    Private Sub 去除编号ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 去除编号ToolStripMenuItem.Click
        Dim strFlag As String
        Dim strChildNodeValue As String
        Dim intNumber As Integer

        For intNumber = 1 To lst技术要求文本.Items.Count
            strChildNodeValue = lst技术要求文本.Items(intNumber - 1).ToString
            strFlag = intNumber.ToString & "."
            if Strings.Left(strChildNodeValue, 2) = strFlag Then
                strChildNodeValue = Strings.Replace(strChildNodeValue, strFlag, "")
                lst技术要求文本.Items(intNumber - 1) = strChildNodeValue
            End if
        Next
        boolIsUserChange = True
    End Sub

    Private Sub 字体ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 字体ToolStripButton.Click
        Dim oFontDialog As New FontDialog
        With oFontDialog
            if .ShowDialog = System.Windows.Forms.DialogResult.OK Then
                字体ToolStripButton.Font = .Font
                字体ToolStripButton.Text = .Font.Name
            End if
        End With
    End Sub

    Private Sub btn插入_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn插入.Click
        SetStatusBarText()

        if IsInventorOpenDocument() = False Then
            Exit Sub
        End if

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        If oInventorDocument.DocumentType <> kDrawingDocumentObject Then
            MsgBox("该功能仅适用于工程图", MsgBoxStyle.Information)
            Exit Sub
        End If

        '间距设置ini
        ini.WriteStrINI("技术要求", "行距", 间距ToolStripTextBox.Text, IniFile)
        ini.WriteStrINI("技术要求", "字体", 字体ToolStripButton.Text, IniFile)

        '-----------------------------------------
        'Dim oInventorDocument As Inventor.Document
        'oInventorDocument = ThisApplication.ActiveDocument

        Dim oInventorDrawingDocument As Inventor.DrawingDocument
        Dim oActiveSheet As Sheet

        oInventorDrawingDocument = oInventorDocument
        oActiveSheet = oInventorDrawingDocument.ActiveSheet

        ' Set a reference to the GeneralNotes object
        Dim oGeneralNotes As GeneralNotes
        oGeneralNotes = oActiveSheet.DrawingNotes.GeneralNotes

        Dim oTG As TransientGeometry
        oTG = ThisApplication.TransientGeometry

        ' Create text with simple string as input. Since this doesn't use
        ' any text overrides, it will default to the active text style.

        Dim strFormattedText As String

        Dim strFontName As String
        strFontName = 字体ToolStripButton.Text

        Dim strTitle As String
        strTitle = txt标题文本.Text

        Dim str1 As String = "<StyleOverride Font='"
        Dim str2 As String = "'>"
        Dim str3 As String = ""
        Dim str4 As String = "</StyleOverride>"
        Dim str5 As String = "<Br/>"

        '     <StyleOverride Font='隶书'>技术要求</StyleOverride><Br/>

        strFormattedText = str1 & strFontName & str2 & strTitle & str4

        Dim strChildNodeValue As String
        For intNumber = 1 To lst技术要求文本.Items.Count
            strChildNodeValue = lst技术要求文本.Items(intNumber - 1).ToString

            strChildNodeValue = str1 & strFontName & str2 & strChildNodeValue & str4

            strFormattedText = strFormattedText & str5 & strChildNodeValue
        Next

        Me.Hide()

        Dim oPoint2d As Point2d

        oPoint2d = GetDrawingPoint() ' ThisApplication.TransientGeometry.CreatePoint2d(ModelPosition.X, ModelPosition.Y)

        Dim oGeneralNote As GeneralNote = Nothing

        Dim douLineSpacing As Double
        douLineSpacing = Val(间距ToolStripTextBox.Text)

        oGeneralNote = oGeneralNotes.AddFitted(oPoint2d, strFormattedText)
        oGeneralNote.LineSpacing = douLineSpacing

        Me.Show()
        Me.TopMost = True
        Me.TopMost = False

    End Sub

    Private Sub oMouse_OnMouseDown(Button As MouseButtonEnum, ShiftKeys As ShiftStateEnum, ModelPosition As Point, _
                                   ViewPosition As Point2d, View As Inventor.View)


        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        Dim oInventorDrawingDocument As Inventor.DrawingDocument
        Dim oActiveSheet As Sheet

        oInventorDrawingDocument = oInventorDocument
        oActiveSheet = oInventorDrawingDocument.ActiveSheet

        ' Set a reference to the GeneralNotes object
        Dim oGeneralNotes As GeneralNotes
        oGeneralNotes = oActiveSheet.DrawingNotes.GeneralNotes

        Dim oTG As TransientGeometry
        oTG = ThisApplication.TransientGeometry

        ' Create text with simple string as input. Since this doesn't use
        ' any text overrides, it will default to the active text style.

        Dim strFormattedText As String

        Dim strFontName As String
        strFontName = 字体ToolStripButton.Text

        Dim strTitle As String
        strTitle = txt标题文本.Text

        Dim str1 As String = "<StyleOverride Font='"
        Dim str2 As String = "'>"
        Dim str3 As String = ""
        Dim str4 As String = "</StyleOverride>"
        Dim str5 As String = "<Br/>"

        '     <StyleOverride Font='隶书'>技术要求</StyleOverride><Br/>

        strFormattedText = str1 & strFontName & str2 & strTitle & str4

        Dim strChildNodeValue As String
        For intNumber = 1 To lst技术要求文本.Items.Count
            strChildNodeValue = lst技术要求文本.Items(intNumber - 1).ToString

            strChildNodeValue = str1 & strFontName & str2 & strChildNodeValue & str4

            strFormattedText = strFormattedText & str5 & strChildNodeValue
        Next

        Me.TopMost = False
        Me.Hide()

        Dim oPoint2d As Point2d

        oPoint2d = ThisApplication.TransientGeometry.CreatePoint2d(ModelPosition.X, ModelPosition.Y)

        Dim oGeneralNote As GeneralNote = Nothing

        Dim douLineSpacing As Double
        douLineSpacing = Val(间距ToolStripTextBox.Text)

        oGeneralNote = oGeneralNotes.AddFitted(oPoint2d, strFormattedText)
        oGeneralNote.LineSpacing = douLineSpacing

        Me.Show()

    End Sub

    Private Sub 配置文件ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 配置文件ToolStripButton.Click
        Process.Start("NOTEPAD.EXE", strSpecificationIni)
    End Sub

    Private Sub 上移ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 上移ToolStripButton.Click
        if ListBoxUp(lst技术要求文本) = True Then
            boolIsUserChange = True
        End if
    End Sub

    Private Sub 下移ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 下移ToolStripButton.Click
        if ListBoxDown(lst技术要求文本) = True Then
            boolIsUserChange = True
        End if
    End Sub

    Private Sub 导入文本ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 导输入文本ToolStripMenuItem.Click
        txt导入文本.Clear()
        GroupBox导入自定义.Visible = True
    End Sub

    Private Sub 导入文件ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 导入文件ToolStripMenuItem.Click
        Dim strFilter As String = "文本文档(*.txt)|*.txt" '添加过滤文件
        Dim strInitialDirectory = Microsoft.VisualBasic.FileIO.SpecialDirectories.Desktop

        Dim arrayFullFileName As List(Of String)
        arrayFullFileName = OpenFileDialog(strFilter, False, strInitialDirectory)

        If arrayFullFileName Is Nothing Then
            Exit Sub
        End If

        Dim strTextFileFullName As String = Nothing
        strTextFileFullName = arrayFullFileName.Item(0).ToString

        Dim arrstrReader() As String
        arrstrReader = System.IO.File.ReadAllLines(strTextFileFullName)
        For Each stringReader As String In arrstrReader
            lst技术要求文本.Items.Add(stringReader)
        Next

        boolIsUserChange = True

    End Sub

    Private Sub btn确定导入_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn确定导入.Click
        Dim strTempFileName As String
        strTempFileName = My.Computer.FileSystem.GetTempFileName()

        My.Computer.FileSystem.WriteAllText(strTempFileName, txt导入文本.Text, True)

        Dim arrstrReader() As String
        arrstrReader = System.IO.File.ReadAllLines(strTempFileName)
        For Each stringReader As String In arrstrReader
            lst技术要求文本.Items.Add(stringReader)
        Next

        boolIsUserChange = True

        txt导入文本.Clear()
        GroupBox导入自定义.Visible = False
    End Sub

    Private Sub btn取消导入_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn取消导入.Click
        txt导入文本.Clear()
        GroupBox导入自定义.Visible = False
    End Sub
End Class