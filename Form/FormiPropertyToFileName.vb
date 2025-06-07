Imports System.Windows.Forms
Imports Inventor
Imports Microsoft
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic.FileIO
Imports FileSystem = Microsoft.VisualBasic.FileSystem
Imports System.Collections.Generic

Public Class FormiPropertyToFileName

    Public intSelectIndex As Integer    '被选中的一行

    Private Sub FormiPropertyToFileName_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48
        Me.TopMost = True

        Dim toolTip As New ToolTip With {
            .AutoPopDelay = 0,
            .InitialDelay = 0,
            .ReshowDelay = 500
        }
        toolTip.SetToolTip(btn确定新文件名, "确定新文件名")
        toolTip.SetToolTip(btn交换, "交换 图号-名称")
        toolTip.SetToolTip(btn导出BOM, "导出为Excel文件")
        toolTip.SetToolTip（btn导入BOM, "导入Excel文件"）


        btn确定新文件名.Image = My.Resources.确定16.ToBitmap
        btn交换.Image = My.Resources.左右交换16.ToBitmap


        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument

        LoadBOM(oInventorAssemblyDocument, lvw文件列表)

        SetWindowSizeAndCenter(Me, 0.6, 0.5)
    End Sub


    ''' <summary>
    ''' 载入数据函数
    ''' </summary>
    ''' <param name="oInventorAssemblyDocument">被载入的部件</param>
    ''' <param name="oListView">加载到ListView控件</param>
    ''' <remarks></remarks>
    Private Sub LoadBOM(ByVal oInventorAssemblyDocument As Inventor.AssemblyDocument, ByVal oListView As ListView)
        On Error Resume Next

        Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        OInteractionEvents.Start()
        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        ThisApplication.UserInterfaceManager.DoEvents()

        oListView.Items.Clear()
        oListView.BeginUpdate()

        Dim oBOM As BOM
        oBOM = oInventorAssemblyDocument.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True

        '获取结构化的bom页面
        For Each oBOMView As BOMView In oBOM.BOMViews
            '基于bom结构化数据，可跳过参考的文件
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then

                For Each oBOMRow As BOMRow In oBOMView.BOMRows
                    Dim strDocumentFullFileName As String = oBOMRow.ComponentDefinitions(1).Document.FullFileName
                    '测试文件
                    'Debug.Print(strDocumentFullFileName)

                    If InStr(strDocumentFullFileName, ContentCenterFiles) > 0 Then         '跳过零件库文件

                    Else
                        Dim oFileNameInfo As FileNameInfo
                        oFileNameInfo = GetFileNameInfo(strDocumentFullFileName)

                        Dim oInventorDocument As Inventor.Document
                        oInventorDocument = ThisApplication.Documents.ItemByName(strDocumentFullFileName)

                        Dim oPropertySets As PropertySets
                        Dim oPropertySet As PropertySet
                        Dim propitem As [Property]

                        oPropertySets = oInventorDocument.PropertySets

                        Dim strDrawingNnumber As String = ""
                        Dim strPartName As String = ""


                        For Each oPropertySet In oPropertySets
                            For Each propitem In oPropertySet
                                Select Case propitem.DisplayName
                                    Case Map_DrawingNnumber
                                        strDrawingNnumber = propitem.Value
                                    Case Map_PartName
                                        strPartName = propitem.Value
                                End Select
                            Next
                        Next

                        Dim strOldFileName As String = oFileNameInfo.FileName
                        Dim strNewFileName As String = strDrawingNnumber & strPartName & oFileNameInfo.ExtensionName

                        Dim oListViewItem As ListViewItem
                        oListViewItem = oListView.Items.Add(strOldFileName)

                        With oListViewItem
                            .SubItems.Add(strDrawingNnumber)
                            .SubItems.Add(strPartName)
                            .SubItems.Add(strNewFileName)
                            .SubItems.Add(strDocumentFullFileName)

                            If Strings.LCase(strOldFileName) = Strings.LCase(strNewFileName) Then

                            Else
                                .UseItemStyleForSubItems = False
                                .SubItems(3).ForeColor = Drawing.Color.Red
                            End If

                        End With
                    End If

                Next

                Exit For
            End If
        Next

        oListView.EndUpdate()

        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        OInteractionEvents.Stop()
    End Sub


    Private Sub Btn关闭_Click(sender As Object, e As EventArgs) Handles btn关闭.Click
        FormManager.CloseAndDisposeForm(Of FormiPropertyToFileName)()
    End Sub

    Private Sub Lvw文件列表_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvw文件列表.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim strInventorFullFileName As String
            strInventorFullFileName = lvw文件列表.SelectedItems(0).SubItems(4).Text
            ThisApplication.Documents.Open(strInventorFullFileName)
        End If
    End Sub

    Private Sub Lvw文件列表_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvw文件列表.SelectedIndexChanged
        Try
            If lvw文件列表.SelectedIndices.Count > 0 Then
                intSelectIndex = lvw文件列表.SelectedIndices(0)  '选中行的下一行索引

                If intSelectIndex < lvw文件列表.Items.Count Then

                    Dim oListViewItem As ListViewItem = lvw文件列表.Items(intSelectIndex)
                    Dim strInventorDocumentFullFileName As String  '文件全名
                    strInventorDocumentFullFileName = oListViewItem.SubItems(4).Text

                    SelectAssemblyComponentDefinition(strInventorDocumentFullFileName)

                    txt图号.Text = oListViewItem.SubItems(1).Text
                    txt文件名.Text = oListViewItem.SubItems(2).Text

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, xhtool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Btn确定新文件名_Click(sender As Object, e As EventArgs) Handles btn确定新文件名.Click
        Dim oListViewItem As ListViewItem = lvw文件列表.Items(intSelectIndex)

        Dim strNewFileName As String = txt图号.Text & txt文件名.Text & GetFileExtensionLCase(oListViewItem.SubItems(4).Text)

        oListViewItem.SubItems(1).Text = txt图号.Text
        oListViewItem.SubItems(2).Text = txt文件名.Text
        oListViewItem.SubItems(3).Text = strNewFileName


    End Sub

    Private Sub Btn开始_Click(sender As Object, e As EventArgs) Handles btn开始.Click
        Dim strOldFullFileName As String
        Dim strNewFullFileName As String
        Dim strNewFileName As String

        If ThisApplication.ActiveDocumentType <> DocumentTypeEnum.kAssemblyDocumentObject Then
            MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument = ThisApplication.ActiveDocument

        ' 获取装配定义
        Dim oAssemblyComponentDefinition As Inventor.AssemblyComponentDefinition
        oAssemblyComponentDefinition = oInventorAssemblyDocument.ComponentDefinition

        ' 获取装配子集
        Dim oComponentOccurrences As ComponentOccurrences
        oComponentOccurrences = oAssemblyComponentDefinition.Occurrences

        Dim oInventorDocument As Inventor.Document

        Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        OInteractionEvents.Start()
        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        ThisApplication.UserInterfaceManager.DoEvents()

        For Each oListViewItem As ListViewItem In lvw文件列表.Items
            strNewFileName = GetFileNameInfo(oListViewItem.SubItems(3).Text).OnlyName

            strOldFullFileName = oListViewItem.SubItems(4).Text
            strNewFullFileName = GetChangeFileName(strOldFullFileName, strNewFileName)

            oListViewItem.SubItems(4).Text = strNewFullFileName

            If strOldFullFileName <> strNewFullFileName Then   '未更名就不进行查询组件，跳过

                '遍历
                For Each oComponentOccurrence As ComponentOccurrence In oComponentOccurrences
                    If oComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName = strOldFullFileName Then         '查询旧文件名的组件

                        '打开旧文件,不显示
                        SetStatusBarText("打开" & strOldFullFileName)
                        Dim oOldInventorDocument As Inventor.Document
                        oOldInventorDocument = ThisApplication.Documents.ItemByName(strOldFullFileName)

                        '关闭存在的新文件
                        CloseFile(strNewFullFileName)

                        '另存为新文件
                        SetStatusBarText("保存" & strNewFullFileName)
                        oOldInventorDocument.SaveAs(strNewFullFileName, True)

                        '关闭旧图
                        oOldInventorDocument.Close()

                        '全部替换为新文件
                        SetStatusBarText("替换文件")

                        'If  MessageBox.Show("是否替换全部零件？", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton1) = MsgBoxResult.Yes Then

                        oComponentOccurrence.Replace(strNewFullFileName, True)

                        'Else
                        '    oOldComponentOccurrence.Replace(strNewFullFileName, False)
                        'End If

                        ThisApplication.Documents.ItemByName(strOldFullFileName).Close()


                        '后台打开文件，修改ipro
                        oInventorDocument = ThisApplication.Documents.Open(strNewFullFileName, False)  '打开文件，不显示

                        SetStatusBarText("设置新文件 IProperty。")

                        SetPropitem(oInventorDocument, Map_ERPCode, "")
                        SetDocumentIpropertyFromFileNameSub(oInventorDocument, True) '设置Iproperty，打开文件后需关闭

                        'Dim IsSaveAsOld As MsgBoxResult
                        'IsSaveAsOld =  MessageBox.Show("是否更改原文件为备份文件，扩展名增加 .old ？", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)

                        '是否有对应的工程图文件，同时复制后修改文件名和模型链接
                        Dim strOldIdwFullFileName As String

                        'Dim strTempFullFileName As String       '更改旧模型文件的名字存档

                        strOldIdwFullFileName = GetChangeExtension(strOldFullFileName, IDW)   '旧工程图

                        If IsFileExIsts(strOldIdwFullFileName) = False Then
                            strOldIdwFullFileName = GetChangeExtensionDocument(oInventorDocument.FullDocumentName, IDW)
                        End If

                        If IsFileExIsts(strOldIdwFullFileName) = True Then

                            SetStatusBarText("复制新工程图。")

                            Dim strNewIdwFullFileName As String
                            strNewIdwFullFileName = GetChangeExtension(strNewFullFileName, IDW)   '新工程图

                            'If IsFileExIsts(strNewIdwFullFileName) = True Then
                            '    If  MessageBox.Show("存在旧的工程图：" & vbCrLf & vbCrLf & strNewIdwFullFileName & "，是否重新生成?",
                            '          MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then  '选择覆盖

                            DeleteFile2(strNewIdwFullFileName, FileIO.RecycleOption.SendToRecycleBin)   '删除旧的新文件名 文件
                            FileSystem.FileCopy(strOldIdwFullFileName, strNewIdwFullFileName)             '复制为新工程图

                            '    Else
                            '        '不复制为新文件，用旧文件
                            '    End If
                            'Else
                            '    FileSystem.FileCopy(strOldIdwFullFileName, strNewIdwFullFileName)             '复制为新工程图
                            'End If

                            '替换工程图模型参考
                            ReplaceFileReference(strNewIdwFullFileName, strOldFullFileName, strNewFullFileName)

                            'If (IsSaveAsOld = MsgBoxResult.Yes) And (str变更工程图扩展名 = "1") Then
                            '    AddOldExtension(strOldIdwFullFileName)
                            'End If

                        End If

                        Exit For
                    End If
                Next

            End If
        Next

        OInteractionEvents.Stop()

        Me.TopMost = False

        MessageBox.Show("按iProperty更改文件名完成。", XHTool, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.Close()

    End Sub

    Private Sub Btn导出_Click(sender As Object, e As EventArgs) Handles btn导出BOM.Click
        Dim strLineDate As String = ""
        Dim strCsvFullFileName As String

        strCsvFullFileName = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop, ThisApplication.ActiveDocument.DisplayName & "-BOM.csv")

        DeleteFile2(strCsvFullFileName, FileIO.RecycleOption.SendToRecycleBin)

        Try
            ' 创建 StreamWriter 写入文件
            Using oStreamWriter As New StreamWriter(strCsvFullFileName, False, oEncoding)
                ' 写入列名
                Dim ColumnNames As New List(Of String)

                For Each oColumnHeader As ColumnHeader In lvw文件列表.Columns
                    ColumnNames.Add(EscapeCsvValue(oColumnHeader.Text))
                Next
                oStreamWriter.WriteLine(String.Join(",", ColumnNames))

                ' 写入每行数据
                For Each oListViewItem As ListViewItem In lvw文件列表.Items
                    Dim rowData As New List(Of String)
                    For Each oListViewSubItem As ListViewItem.ListViewSubItem In oListViewItem.SubItems
                        rowData.Add(EscapeCsvValue(oListViewSubItem.Text))
                    Next
                    oStreamWriter.WriteLine(String.Join(",", rowData))
                Next
            End Using

            If MessageBox.Show("数据文件导出完成，是否打开？", XHTool, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
              ProcessStart(strCsvFullFileName)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub Btn导入_Click(sender As Object, e As EventArgs) Handles btn导入BOM.Click
        ' 设置打开文件对话框
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "CSV 文件 (*.csv)|*.csv"
            openFileDialog.Title = "导入 CSV 文件"

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Try

                    ' 使用 TextFieldParser 读取 CSV 文件
                    Using oTextFieldParser As New TextFieldParser(openFileDialog.FileName, oEncoding)
                        oTextFieldParser.TextFieldType = FieldType.Delimited
                        oTextFieldParser.Delimiters = New String() {","}
                        oTextFieldParser.HasFieldsEnclosedInQuotes = True ' 自动处理双引号包裹的字段

                        ' 步骤1：读取列名
                        If oTextFieldParser.EndOfData Then
                            MessageBox.Show("CSV 文件为空。", XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If
                        Dim csvHeaders As String() = oTextFieldParser.ReadFields()

                        ' 步骤2：验证列名和列数是否与 ListView 匹配
                        If csvHeaders.Length <> lvw文件列表.Columns.Count Then
                            MessageBox.Show("CSV 列数不匹配。", XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If

                        For i As Integer = 0 To csvHeaders.Length - 1
                            If csvHeaders(i) <> lvw文件列表.Columns(i).Text Then
                                MessageBox.Show($"列名不匹配：第 {i + 1} 列应为 [{lvw文件列表.Columns(i).Text}]", XHTool,
                                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return
                            End If
                        Next

                        ' 步骤3：清空 ListView 现有数据

                        lvw文件列表.BeginUpdate()
                        lvw文件列表.Items.Clear()

                        ' 步骤4：逐行读取数据并填充到 ListView
                        While Not oTextFieldParser.EndOfData
                            Dim fields As String() = oTextFieldParser.ReadFields()

                            ' 跳过字段数不匹配的行
                            If fields.Length <> lvw文件列表.Columns.Count Then
                                Continue While
                            End If

                            ' 创建 ListViewItem 并添加子项
                            Dim newItem As New ListViewItem(fields(0))
                            For i As Integer = 1 To fields.Length - 1
                                newItem.SubItems.Add(fields(i))
                            Next
                            lvw文件列表.Items.Add(newItem)
                        End While
                    End Using

                    For Each oListViewItem As ListViewItem In lvw文件列表.Items

                        With oListViewItem
                            Dim strDrawingNnumber As String = oListViewItem.SubItems(1).Text
                            Dim strPartName As String = oListViewItem.SubItems(2).Text
                            Dim strOldFileName As String = oListViewItem.SubItems(4).Text

                            Dim strNewFileName As String = strDrawingNnumber & strPartName & GetFileExtensionLCase(strOldFileName)

                            oListViewItem.SubItems(3).Text = strNewFileName

                        End With

                    Next

                    lvw文件列表.EndUpdate()
                    MessageBox.Show("CSV 文件导入成功。", XHTool, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub Btn交换_Click(sender As Object, e As EventArgs) Handles btn交换.Click
        Dim strTemp As String
        strTemp = txt图号.Text
        txt图号.Text = txt文件名.Text
        txt文件名.Text = strTemp
    End Sub

    Private Sub Btn加载BOM_Click(sender As Object, e As EventArgs) Handles 加载BOM.Click
        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument

        LoadBOM(oInventorAssemblyDocument, lvw文件列表)
    End Sub
End Class