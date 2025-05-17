Imports Inventor
Imports Inventor.DocumentTypeEnum
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Text

Public Class FormSpecification
    Private boolIsBasicChange As Boolean
    Private boolIsUserChange As Boolean
    Private strSpecificationIni As String

    Private oPoint2d As Point2d

    Private Sub Btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click, Me.Closing
        FormManager.CloseAndDisposeForm(Of FormSpecification)()
    End Sub

    Private Sub FrmSpecification_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next

        Me.Icon = My.Resources.XHTool48

        '加载间距

        间距ToolStripTextBox.Text = ini.GetStrFromINI("技术要求", "行距", "1.5", IniFile)

        字体ToolStripButton.Text = ini.GetStrFromINI("技术要求", "字体", "仿宋", IniFile)

        '加载配置文件
        strSpecificationIni = IO.Path.Combine(My.Application.Info.DirectoryPath, "Specification.ini")

        If IsFileExists(strSpecificationIni) = False Then
            MessageBox.Show("未找到配置文件 Specification.ini", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim oPrasentNode As TreeNode

        Dim intNumber As Integer
        Dim strNode As String

        'oPrasentNode = TreeView基础数据树.Nodes.Add("通用技术标准")
        intNumber = 1
        strNode = GetStrFromINI("通用技术标准", intNumber.ToString, "", strSpecificationIni)
        Do While (strNode <> "")
            TreeView基础数据树.Nodes.Add(strNode)
            intNumber += 1
            strNode = GetStrFromINI("通用技术标准", intNumber.ToString, "", strSpecificationIni)
        Loop
        TreeView基础数据树.ExpandAll()
        boolIsBasicChange = False

        'oPrasentNode = TreeView自定义.Nodes.Add("技术要求")
        intNumber = 1
        strNode = GetStrFromINI("技术要求", intNumber.ToString, "", strSpecificationIni)
        Do While (strNode <> "")
            TreeView自定义.Nodes.Add(strNode)
            intNumber += 1
            strNode = GetStrFromINI("技术要求", intNumber.ToString, "", strSpecificationIni)
        Loop

        TreeView自定义.ExpandAll()
        boolIsUserChange = False

    End Sub

    Private Sub TreeView基础数据树_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView基础数据树.NodeMouseClick
        If e.Node.Text = "通用技术标准" Or e.Node.Text = "技术要求" Then
            Exit Sub
        End If

        If boolIsBasicChange = True Then
            If MessageBox.Show(TreeView基础数据树.SelectedNode.Text & "  已修改，是否保存？", XHTool，
                               MessageBoxButtons.YesNo， MessageBoxIcon.Question) = DialogResult.Yes Then
                保存基础数据ToolStripButton.PerformClick()
            End If
        End If

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
            intNumber += 1
            strChildNodeValue = GetStrFromINI(strChildNodeName, intNumber.ToString, "", strSpecificationIni)
        Loop

        boolIsBasicChange = False
    End Sub

    Private Sub 删除自定义ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 删除自定义ToolStripButton.Click
        If lst技术要求文本.SelectedItems.Count <> 0 Then
            lst技术要求文本.Items.Remove(lst技术要求文本.SelectedItems.Item(0))
            boolIsUserChange = True
        End If
    End Sub

    Private Sub 添加自定义ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 添加自定义ToolStripButton.Click
        Dim strChildNodeValue As String
        Me.TopMost = False
        strChildNodeValue = InputBox("输入技术要求。 ", "技术要求")
        If strChildNodeValue <> "" Then
            lst技术要求文本.Items.Add(strChildNodeValue)
            boolIsUserChange = True
        End If
        Me.TopMost = True
    End Sub

    Private Sub 修改自定义ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 修改自定义ToolStripButton.Click
        Dim strChildNodeValue As String

        If lst技术要求文本.SelectedItems.Count <> 0 Then
            strChildNodeValue = lst技术要求文本.SelectedItems(0).ToString
        Else
            Exit Sub
        End If
        Me.TopMost = False
        strChildNodeValue = InputBox("输入技术要求。 ", "技术要求", strChildNodeValue)
        If strChildNodeValue <> "" Then
            lst技术要求文本.Items(lst技术要求文本.SelectedIndex) = strChildNodeValue
            boolIsUserChange = True
        End If
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
            intNumber += 1
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
        If lst基础数据列表.SelectedItems.Count <> 0 Then
            strChildNodeValue = lst基础数据列表.SelectedItems(0).ToString
        Else
            Me.TopMost = True
            Exit Sub
        End If

        strChildNodeValue = InputBox("输入技术要求。 ", "技术要求", strChildNodeValue)
        If strChildNodeValue <> "" Then
            lst基础数据列表.Items(lst基础数据列表.SelectedIndex) = strChildNodeValue
            boolIsBasicChange = True
        End If
        Me.TopMost = True
    End Sub

    Private Sub 删除基础数据ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 删除基础数据ToolStripButton.Click
        If lst基础数据列表.SelectedItems.Count <> 0 Then
            lst基础数据列表.Items.Remove(lst基础数据列表.SelectedItems.Item(0))
            boolIsBasicChange = True
        End If
    End Sub

    Private Sub 添加基础数据ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 添加基础数据ToolStripButton.Click
        Dim strChildNodeValue As String

        Me.TopMost = False
        strChildNodeValue = InputBox("输入技术要求。 ", "技术要求")
        If strChildNodeValue <> "" Then
            lst基础数据列表.Items.Add(strChildNodeValue)
            boolIsBasicChange = True
        End If
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
            intNumber += 1
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

        If lst基础数据列表.SelectedItems.Count <> 0 Then
            strChildNodeValue = lst基础数据列表.SelectedItems(0).ToString
            lst技术要求文本.Items.Add(strChildNodeValue)
            boolIsUserChange = True
        Else
            MessageBox.Show("请选择基础数据。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning)
            Exit Sub
        End If

    End Sub

    Private Sub TreeView自定义_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView自定义.NodeMouseClick
        If e.Node.Text = "通用技术标准" Or e.Node.Text = "技术要求" Then
            Exit Sub
        End If

        If boolIsUserChange = True Then
            If MessageBox.Show(TreeView自定义.SelectedNode.Text & "  已修改，是否保存？", XHTool，
                               MessageBoxButtons.YesNo， MessageBoxIcon.Question) = DialogResult.Yes Then
                保存自定义ToolStripButton.PerformClick()
            End If
        End If

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
            intNumber += 1
            strChildNodeValue = GetStrFromINI(strChildNodeName, intNumber.ToString, "", strSpecificationIni)
        Loop

        boolIsUserChange = False
    End Sub

    Private Sub 新建自定义ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 新建自定义ToolStripButton.Click
        Dim strChildNodeName As String

        Me.TopMost = False

        strChildNodeName = InputBox("输入新技术要求名称！", "技术要求")

        If strChildNodeName <> "" Then
            TreeView自定义.Nodes.Add(strChildNodeName)
            If boolIsUserChange = True Then
                If MessageBox.Show(TreeView自定义.SelectedNode.Text & "  已修改，是否保存？", XHTool，
                                   MessageBoxButtons.YesNo， MessageBoxIcon.Question) = DialogResult.Yes Then
                    保存自定义ToolStripButton.PerformClick()
                End If
            End If
            lst技术要求文本.Items.Clear()

            Dim strChildNodeValue As String
            Dim intNumber As Integer

            strChildNodeName = "技术要求"
            EraseSection(strChildNodeName, strSpecificationIni)

            '重写列表
            For intNumber = 1 To TreeView自定义.Nodes.Count
                strChildNodeValue = TreeView自定义.Nodes.Item(intNumber - 1).Text
                WriteStrINI(strChildNodeName, intNumber.ToString, strChildNodeValue, strSpecificationIni)
            Next

            boolIsUserChange = False

        End If

        Me.TopMost = True

    End Sub

    Private Sub 自动编号ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 自动编号ToolStripMenuItem.Click
        Dim strFlag As String
        Dim strChildNodeValue As String
        Dim intNumber As Integer

        For intNumber = 1 To lst技术要求文本.Items.Count
            strChildNodeValue = lst技术要求文本.Items(intNumber - 1).ToString
            strFlag = intNumber.ToString & "."
            If Strings.Left(strChildNodeValue, 2) <> strFlag Then
                strChildNodeValue = strFlag & strChildNodeValue
                lst技术要求文本.Items(intNumber - 1) = strChildNodeValue
            End If
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
            If Strings.Left(strChildNodeValue, 2) = strFlag Then
                strChildNodeValue = Strings.Replace(strChildNodeValue, strFlag, "")
                lst技术要求文本.Items(intNumber - 1) = strChildNodeValue
            End If
        Next
        boolIsUserChange = True
    End Sub

    Private Sub 字体ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 字体ToolStripButton.Click
        Dim oFontDialog As New FontDialog
        With oFontDialog
            If .ShowDialog = System.Windows.Forms.DialogResult.OK Then
                字体ToolStripButton.Font = .Font
                字体ToolStripButton.Text = .Font.Name
            End If
        End With
    End Sub

    Private Sub Btn插入_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn插入.Click
        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        If oInventorDocument.DocumentType <> kDrawingDocumentObject Then
            MessageBox.Show(”该功能仅适用于工程图。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        '间距设置ini
        ini.WriteStrINI("技术要求", "行距", 间距ToolStripTextBox.Text, IniFile)
        ini.WriteStrINI("技术要求", "字体", 字体ToolStripButton.Text, IniFile)

        '-----------------------------------------

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
        'Dim str3 As String
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


        oPoint2d = GetPointInDrawing("单击确定插入位置。") ' ThisApplication.TransientGeometry.CreatePoint2d(ModelPosition.X, ModelPosition.Y)

        Dim oGeneralNote As GeneralNote

        Dim douLineSpacing As Double
        douLineSpacing = Val(间距ToolStripTextBox.Text)

        oGeneralNote = oGeneralNotes.AddFitted(oPoint2d, strFormattedText)
        oGeneralNote.LineSpacing = douLineSpacing

        FormManager.CloseAndDisposeForm(Of FormSpecification)()


    End Sub

    Private Sub 配置文件ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 配置文件ToolStripButton.Click
        Process.Start("NOTEPAD.EXE", strSpecificationIni)
    End Sub

    Private Sub 上移ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 上移ToolStripButton.Click
        If ListBoxUp(lst技术要求文本) = True Then
            boolIsUserChange = True
        End If
    End Sub

    Private Sub 下移ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 下移ToolStripButton.Click
        If ListBoxDown(lst技术要求文本) = True Then
            boolIsUserChange = True
        End If
    End Sub

    Private Sub 导入文本ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 导输入文本ToolStripMenuItem.Click
        txt导入文本.Clear()
        GroupBox导入自定义.Visible = True
    End Sub

    Private Sub 导入文件ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 导入文件ToolStripMenuItem.Click
        Dim strFilter As String = "文本文档(*.txt)|*.txt" '添加过滤文件

        Dim strFile = IO.Path.Combine(Microsoft.VisualBasic.FileIO.SpecialDirectories.Desktop, "选择导入的文本文件")

        Dim oFileList As List(Of String)
        oFileList = OpenFileDialog(strFilter, False, strFile)

        If oFileList Is Nothing Then
            Exit Sub
        End If

        Dim strTextFileFullName As String
        strTextFileFullName = oFileList.Item(0).ToString

        Using oStreamReader As New StreamReader(strTextFileFullName, Encoding.UTF8)
            While Not oStreamReader.EndOfStream
                Dim strFileName As String
                strFileName = oStreamReader.ReadLine()

                lst技术要求文本.Items.Add(strFileName)

            End While
        End Using

        boolIsUserChange = True

    End Sub

    Private Sub Btn确定导入_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn确定导入.Click
        For Each stringReader As String In txt导入文本.Lines
            If stringReader.Length > 0 Then
                lst技术要求文本.Items.Add(stringReader)
            End If
        Next

        boolIsUserChange = True

        txt导入文本.Clear()
        GroupBox导入自定义.Visible = False
    End Sub

    Private Sub Btn取消导入_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn取消导入.Click
        txt导入文本.Clear()
        GroupBox导入自定义.Visible = False
    End Sub
End Class