Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Inventor
Public Class FormBatchCommand


    Private Sub FormBatchCommand_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Lvw文件列表_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvw文件列表.MouseDoubleClick
        ThisApplication.Documents.Open(lvw文件列表.SelectedItems(0).Text)
    End Sub

    Private Sub 添加文件ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 添加文件ToolStripMenuItem.Click
        Dim strFilter As String = "Autodesk Inventor 零件(*.ipt)|*.ipt" '添加过滤文件

        Dim strFile = IO.Path.Combine(ThisApplication.FileLocations.Workspace, "选择文件")

        Dim oFileList As List(Of String)
        oFileList = OpenFileDialog(strFilter, True, strFile)

        If oFileList Is Nothing Then
            Exit Sub
        End If

        lvw文件列表.BeginUpdate()

        For Each strInventorDrawingDocumentFullFileName In oFileList
            If IsItemInListView(lvw文件列表, strInventorDrawingDocumentFullFileName) = False Then
                lvw文件列表.Items.Add(strInventorDrawingDocumentFullFileName)
            End If
        Next

        lvw文件列表.EndUpdate()

    End Sub

    Private Sub 添加文件夹ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 添加文件夹ToolStripMenuItem.Click
        Dim strFile = IO.Path.Combine(ThisApplication.FileLocations.Workspace, "选择一个文件确定文件夹")
        Dim strDestinationFolder As String = OpenFolderDialog(strFile)

        If strDestinationFolder Is Nothing Then
            Exit Sub
        End If

        Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        OInteractionEvents.Start()
        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        ThisApplication.UserInterfaceManager.DoEvents()

        GetAllFile(strDestinationFolder, lvw文件列表, IPT)

        OInteractionEvents.Stop()

    End Sub

    Private Sub 已打开文件ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 已打开文件ToolStripMenuItem.Click
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            lvw文件列表.BeginUpdate()
            For Each oInventorDocument As Inventor.Document In ThisApplication.Documents.VisibleDocuments
                If oInventorDocument.DocumentType = DocumentTypeEnum.kPartDocumentObject Then
                    If IsItemInListView(lvw文件列表, oInventorDocument.FullDocumentName) = False Then
                        lvw文件列表.Items.Add(oInventorDocument.FullDocumentName)
                    End If
                End If
            Next
            lvw文件列表.EndUpdate()

        Catch ex As Exception
            MessageBox.Show(ex.Message, xhtool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub 当前部件ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 当前部件ToolStripMenuItem.Click

        On Error Resume Next

        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        If ThisApplication.ActiveDocumentType <> DocumentTypeEnum.kAssemblyDocumentObject Then
            MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument


        ' 获取装配定义
        Dim oAssemblyComponentDefinition As AssemblyComponentDefinition
        oAssemblyComponentDefinition = oInventorAssemblyDocument.ComponentDefinition

        ' 获取装配子集
        Dim oComponentOccurrences As ComponentOccurrences
        oComponentOccurrences = oAssemblyComponentDefinition.Occurrences

        '遍历

        Dim oInventorPartDocument As Inventor.PartDocument
        Dim strInventorPartDocumentFullFileName As String

        lvw文件列表.BeginUpdate()

        For Each oComponentOccurrence As ComponentOccurrence In oComponentOccurrences.AllLeafOccurrences
            strInventorPartDocumentFullFileName = oComponentOccurrence.ReferencedDocumentDescriptor.FullDocumentName
            'Debug.Print(strInventorPartDocumentFullFileName)

            If IsFileExists(strInventorPartDocumentFullFileName) = True Then
                If IsItemInListView(lvw文件列表, strInventorPartDocumentFullFileName) = False Then
                    lvw文件列表.Items.Add(strInventorPartDocumentFullFileName)
                End If
            End If
        Next
        lvw文件列表.EndUpdate()
    End Sub

    Private Sub 清空列表ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 清空列表ToolStripMenuItem.Click
        lvw文件列表.Items.Clear()
    End Sub

    ''' <summary>
    ''' 运行命令
    ''' </summary>
    ''' <param name="oListView">文件列表</param>
    ''' <param name="strControlDefinitionInNames">命令内部名称</param>
    Private Sub ControlDefinitionExecute(ByVal oListView As ListView, ByVal strControlDefinitionInNames As List(Of String))
        On Error Resume Next

        If oListView.Items.Count = 0 Then
            Exit Sub
        End If

        ThisApplication.SilentOperation = True
        ThisApplication.UserInterfaceManager.DoEvents()
        Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        OInteractionEvents.Start()
        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        System.Windows.Forms.Application.DoEvents()

        For Each oListViewItem As ListViewItem In oListView.Items
            oListViewItem.ForeColor = Drawing.Color.BlueViolet

            '打开文件
            Dim strInventorPartDocumentFullFileName As String
            strInventorPartDocumentFullFileName = oListViewItem.Text

            If IsFileExists(strInventorPartDocumentFullFileName) = False Then   '跳过不存在的文件
                Continue For
            End If

            Dim oInventorPartDocument As Inventor.PartDocument
            oInventorPartDocument = ThisApplication.Documents.Open(strInventorPartDocumentFullFileName, True)

            Dim oControlDefinition As ControlDefinition
            For Each strControlDefinitionInName In strControlDefinitionInNames
                oControlDefinition = ThisApplication.CommandManager.ControlDefinitions.Item(strControlDefinitionInName)
                oControlDefinition.Execute()
            Next
        Next

        ThisApplication.SilentOperation = False
        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        OInteractionEvents.Stop()
    End Sub

    Private Sub 转换为钣金ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 转换为钣金ToolStripMenuItem.Click
        Dim strControlDefinitionInNames As New List(Of String) From {
            "PartConvertToSheetMetalCmd"
        }

        ControlDefinitionExecute(lvw文件列表, strControlDefinitionInNames)
    End Sub

    Private Sub 转换为零件ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 转换为零件ToolStripMenuItem.Click
        Dim strControlDefinitionInNames As New List(Of String) From {
            "PartConvertToStandardPartCmd"
        }
        ControlDefinitionExecute(lvw文件列表, strControlDefinitionInNames)
    End Sub

    Private Sub 创建展开ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 创建展开ToolStripMenuItem.Click
        Dim strControlDefinitionInNames As New List(Of String) From {
            "AppZoomAllCmd", "SheetMetalFlatPatternCmd", "PartSwitchRepresentationCmd"
        }
        ControlDefinitionExecute(lvw文件列表, strControlDefinitionInNames)
    End Sub

    Private Sub 获取钣金厚度ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 获取钣金厚度ToolStripMenuItem.Click
        On Error Resume Next

        If lvw文件列表.Items.Count = 0 Then
            Exit Sub
        End If

        ThisApplication.SilentOperation = True
        ThisApplication.UserInterfaceManager.DoEvents()
        Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        OInteractionEvents.Start()
        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        System.Windows.Forms.Application.DoEvents()


        Dim minThickness As Double

        For Each oListViewItem As ListViewItem In lvw文件列表.Items
            oListViewItem.ForeColor = Drawing.Color.BlueViolet

            '打开文件
            Dim strInventorPartDocumentFullFileName As String
            strInventorPartDocumentFullFileName = oListViewItem.Text

            If IsFileExists(strInventorPartDocumentFullFileName) = False Then   '跳过不存在的文件
                Continue For
            End If

            Dim oInventorPartDocument As Inventor.PartDocument
            oInventorPartDocument = ThisApplication.Documents.Open(strInventorPartDocumentFullFileName, True)
            minThickness = GetSheetThickness(oInventorPartDocument)

            ' MessageBox.Show(minThickness)
            Debug.Print(minThickness & vbCrLf)

            Dim compDef As ComponentDefinition
            compDef = oInventorPartDocument.ComponentDefinition

            Dim sheetMetalDef As SheetMetalComponentDefinition
            sheetMetalDef = compDef
            sheetMetalDef.UseSheetMetalStyleThickness = False
            sheetMetalDef.Thickness.Value = minThickness

        Next

        ThisApplication.SilentOperation = False
        'OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        OInteractionEvents.Stop()
    End Sub

    ''' <summary>
    '''获取钣金厚度 
    ''' </summary>
    ''' <param name="oInventorPartDocument">零件对象</param>
    ''' <returns></returns>
    Public Function GetSheetThickness(ByVal oInventorPartDocument As PartDocument) As Double
        Dim minThickness As Double

        Dim compDef As ComponentDefinition
        compDef = oInventorPartDocument.ComponentDefinition

        Dim sheetMetalDef As SheetMetalComponentDefinition
        sheetMetalDef = compDef

        Dim boundingBox As Box
        boundingBox = sheetMetalDef.RangeBox
        Dim dx As Double, dy As Double, dz As Double
        dx = boundingBox.MaxPoint.X - boundingBox.MinPoint.X
        dy = boundingBox.MaxPoint.Y - boundingBox.MinPoint.Y
        dz = boundingBox.MaxPoint.Z - boundingBox.MinPoint.Z
        minThickness = Math.Min(Math.Min(dx, dy), dz)

        If minThickness < 100000 Then
            Return minThickness
        Else
            Return 0
        End If

    End Function

End Class