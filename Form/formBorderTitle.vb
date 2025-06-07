Imports System.IO
Imports Inventor
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Text

Public Class FormBorderTitle

    Private Sub FormBorderTitle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48

        Dim strTitleBlock As String
        strTitleBlock = IO.Path.Combine(My.Application.Info.DirectoryPath, "TitleBlock.ini")

        If IsFileExists(strTitleBlock) = False Then
            MessageBox.Show(”无配置文件,请手动配置。”, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Using oStreamWriter As New StreamWriter(strTitleBlock, False, Encoding.Default)
                oStreamWriter.WriteLine("#号行勿修改")
                oStreamWriter.WriteLine("#Border 默认图框")
                oStreamWriter.WriteLine("#Border = NX")
                oStreamWriter.WriteLine("#Title旧的和新的对映表")
                oStreamWriter.WriteLine("#SH(-零件 = NX - 零件)")
            End Using
            Exit Sub
        End If



        Dim strLine As String

        Dim strNewBorder As String = Nothing
        Dim strNewTitleBlockName As String = Nothing
        Dim strOldTitleBlockName As String = Nothing

        Using oStreamReader As New StreamReader(strTitleBlock, Encoding.Default)

            Do While Not oStreamReader.EndOfStream
                strLine = oStreamReader.ReadLine()

                '跳过注释
                If Strings.Left(strLine, 1) = "#" Then
                    Continue Do
                End If

                '获取新的图框名
                If Strings.Left(strLine, 6) = "Border" Then
                    strNewBorder = Strings.Replace(strLine, "Border=", "")
                    cmb边框.Items.Add(strNewBorder)
                    cmb边框.SelectedIndex = 0
                    Continue Do
                End If

                '对比到旧的title

                Dim parts() As String = strLine.Split("="c)
                ' 硰保分割后的数组至少有两个元素
                If parts.Length >= 2 Then
                    ' 获取 "=" 前面的部分
                    strOldTitleBlockName = parts(0)
                    ' 获取 "=" 后面的部分
                    strNewTitleBlockName = parts(1)

                    Dim oListViewItem As ListViewItem = lvw标题栏对应表.Items.Add(strOldTitleBlockName)
                    oListViewItem.SubItems.Add(strNewTitleBlockName)
                End If
            Loop

        End Using

    End Sub

    Private Sub 打开旧模板ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开旧模板ToolStripMenuItem.Click
        Dim strFileName As String
        Dim strFilter As String = "Inventor工程图文件(*.idw;*.dwg)|*.idw;*.dwg" '添加过滤文件
        Dim strFile = IO.Path.Combine(ThisApplication.FileLocations.Workspace, "选择旧模板文件")

        Dim oFileList As List(Of String)
        oFileList = OpenFileDialog(strFilter, False, strFile)

        If oFileList Is Nothing Then
            Exit Sub
        Else
            strFileName = oFileList(0).ToString
        End If

        Dim oInventorDrawingDocument As Inventor.DrawingDocument

        str模型匹配检查 = 0

        oInventorDrawingDocument = ThisApplication.Documents.Open(strFileName, False)

        Dim oTitleBlockDefinitions As Inventor.TitleBlockDefinitions
        oTitleBlockDefinitions = oInventorDrawingDocument.TitleBlockDefinitions

        Dim strTitleName As String

        For Each oTitleBlockDefinition As Inventor.TitleBlockDefinition In oTitleBlockDefinitions
            strTitleName = oTitleBlockDefinition.Name
            If cmb旧标题栏.FindString(strTitleName) = -1 Then
                cmb旧标题栏.Items.Add(strTitleName)
            End If
        Next
        cmb旧标题栏.SelectedIndex = 0

        oInventorDrawingDocument.Close(True)

        str模型匹配检查 = 1
    End Sub

    Private Sub 打开新模板ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开新模板ToolStripMenuItem.Click
        Dim strFileName As String
        Dim strFilter As String = "Inventor工程图文件(*.idw;*.dwg)|*.idw;*.dwg" '添加过滤文件
        Dim strFile = IO.Path.Combine(ThisApplication.FileLocations.TemplatesPath, "选择新模板文件")

        Dim oFileList As List(Of String)
        oFileList = OpenFileDialog(strFilter, False, strFile)

        If oFileList Is Nothing Then
            Exit Sub
        Else
            strFileName = oFileList(0).ToString
        End If

        Dim oInventorDrawingDocument As Inventor.DrawingDocument

        str模型匹配检查 = 0

        oInventorDrawingDocument = ThisApplication.Documents.Open(strFileName, False)

        Dim oBorderDefinitions As BorderDefinitions
        oBorderDefinitions = oInventorDrawingDocument.BorderDefinitions

        Dim strBorderName As String

        For Each oBorderDefinition As BorderDefinition In oBorderDefinitions
            strBorderName = oBorderDefinition.Name
            If cmb边框.FindString(strBorderName) = -1 Then
                cmb边框.Items.Add(strBorderName)
            End If
        Next

        Dim oTitleBlockDefinitions As Inventor.TitleBlockDefinitions
        oTitleBlockDefinitions = oInventorDrawingDocument.TitleBlockDefinitions

        Dim strTitleName As String

        For Each oTitleBlockDefinition As Inventor.TitleBlockDefinition In oTitleBlockDefinitions
            strTitleName = oTitleBlockDefinition.Name
            If cmb新标题栏.FindString(strTitleName) = -1 Then
                cmb新标题栏.Items.Add(strTitleName)
            End If
        Next
        cmb新标题栏.SelectedIndex = 0

        oInventorDrawingDocument.Close(True)

        str模型匹配检查 = 1
    End Sub

    Private Sub 保存配置ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 保存配置ToolStripMenuItem.Click
        Dim strTitleBlock As String
        strTitleBlock = IO.Path.Combine(My.Application.Info.DirectoryPath, "TitleBlock.ini")

        Dim strLine As String

        Using oStreamWriter As New StreamWriter(strTitleBlock, False, Encoding.Default)
            oStreamWriter.WriteLine("#号行勿修改")
            oStreamWriter.WriteLine("#Border 默认图框")
            oStreamWriter.WriteLine("Border=" & cmb边框.Text)
            oStreamWriter.WriteLine("#Title旧的和新的对映表")

            For Each oListViewItem As ListViewItem In lvw标题栏对应表.Items
                strLine = oListViewItem.Text & "=" & oListViewItem.SubItems.Item(1).Text
                oStreamWriter.WriteLine(strLine)
            Next

        End Using
    End Sub

    Private Sub 删除ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 删除ToolStripMenuItem.Click
        ListViewDel(lvw标题栏对应表)
    End Sub

    Private Sub 添加ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 添加ToolStripMenuItem.Click
        Dim strOldTitleBlockName As String = cmb旧标题栏.Text
        Dim strNewTitleBlockName As String = cmb新标题栏.Text

        If Not String.IsNullOrEmpty(strNewTitleBlockName) And Not String.IsNullOrEmpty(strOldTitleBlockName) Then
            Dim oListViewItem As ListViewItem = lvw标题栏对应表.Items.Add(strOldTitleBlockName)
            oListViewItem.SubItems.Add(strNewTitleBlockName)
        End If
    End Sub

    Private Sub 打开配置文件ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开配置文件ToolStripMenuItem.Click
        Dim strTitleBlock As String
        strTitleBlock = IO.Path.Combine(My.Application.Info.DirectoryPath, "TitleBlock.ini")
        ProcessStart(strTitleBlock)
    End Sub


End Class