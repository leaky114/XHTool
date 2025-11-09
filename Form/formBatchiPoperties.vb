Imports Inventor
Imports System.Windows.Forms
Imports Inventor.DocumentTypeEnum
Imports Microsoft
Imports Microsoft.VisualBasic
Imports stdole
Imports System
Imports System.Collections.ObjectModel
Imports System.Drawing
Imports System.IO
Imports System.Xml
Imports System.Collections.Generic

Public Class formBatchiPoperties
    Public Enum EnumPType
        eString = 0
        eBool = 1
        eDouble = 2
        eDate = 3
    End Enum

    Private oOption As enumPType = enumPType.eString

    Private oUserPropertySet As Inventor.PropertySet
    Private PropID As Long = 0

    Public Sub GetUserPropertySet(ByVal oUSet As Inventor.PropertySet)

        '获得缺省的自定义特性集
        oUserPropertySet = oUSet

        '获取最大PropID
        For Each oProperty As Inventor.Property In oUserPropertySet
            If oProperty.PropId > PropID Then
                PropID = oProperty.PropId
            End If
        Next

        '可接受的PropID范围是: 2 ~ 254 , 256 ~ 0x80000000
        If PropID < 2 Then
            PropID = 2
        End If
    End Sub

    '量产开始
    Private Sub Btn确定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn确定.Click

        Dim oInventorDocDocument As Inventor.Document

        If lvw文件列表.Items.Count = 0 Then
            MessageBox.Show(”未添加文件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'btn确定.Enabled = False

        Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        OInteractionEvents.Start()
        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        ThisApplication.UserInterfaceManager.DoEvents()


        Dim strInventorDocumentFullFileName As String

        Select Case tab1.SelectedIndex

            Case 0
                If cmb项目名.Text = "" Then
                    MessageBox.Show(”请选择项目。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    OInteractionEvents.Stop()
                    btn确定.Enabled = True
                    Exit Sub
                End If


                For Each oListViewItem As ListViewItem In lvw文件列表.Items
                    'oListViewItem.Selected = True

                    '打开文件
                    strInventorDocumentFullFileName = oListViewItem.Text
                    oInventorDocDocument = ThisApplication.Documents.Open(strInventorDocumentFullFileName, False)
                    '打开 项目 选项卡



                    'Dim oPropertySet As PropertySet = oInventorDocDocument.PropertySets.Item("Design Tracking Properties")

                    '用内部定义名的代码
                    'Dim oDesignerProp As Inventor.Property = oDTProps.ItemByPropId(Inventor.PropertiesForDesignTrackingPropertiesEnum.kDesignerDesignTrackingProperties)
                    'oDesignerProp = oDTProps.Item("Designer")
                    'Debug.Print(oDesignerProp.DisplayName & " = " & oDesignerProp.Value)

                    '用显示名 displayname 的代码
                    '定义单个项目
                    'Dim oProperty As Inventor.Property
                    Try
                        For Each oPropertySet As PropertySet In oInventorDocDocument.PropertySets
                            '遍历选项卡下的每个单项目
                            For Each oProperty As Inventor.Property In oPropertySet

                                'If oProperty.DisplayName <> "缩略图" Then
                                '    Debug.Print(oProperty.DisplayName & "----------" & oProperty.Value)
                                'End If

                                If oProperty.DisplayName = cmb项目名.Text Then
                                    '项目名对应，设置数据
                                    oProperty.Value = txt数据.Text.ToString
                                End If
                            Next

                            '保存到文件
                            'InventorDoc.PropertySets.FlushToFile()
                            '关闭文件
                            'InventorDoc.Close()

                        Next
                    Catch ex As Exception
                        OInteractionEvents.Stop()
                    End Try


                Next
            Case 1

                If txt特性名.Text = "" Then
                    MessageBox.Show(”请输入新特性的名字。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    OInteractionEvents.Stop()
                    btn确定.Enabled = True
                    Exit Sub
                End If

                For Each oListViewItem As ListViewItem In lvw文件列表.Items
                    oListViewItem.Selected = True

                    '打开文件
                    strInventorDocumentFullFileName = oListViewItem.Text
                    oInventorDocDocument = ThisApplication.Documents.Open(strInventorDocumentFullFileName, False)
                    '打开 项目 选项卡
                    'Dim oDTProps As PropertySet = thisApprenticeDoc.PropertySets.Item("User Defined Properties")

                    Dim oProperty As Inventor.Property

                    If chk删除自定义.Checked = True Then
                        Try
                            oProperty = oInventorDocDocument.PropertySets.Item("User Defined Properties").Item(txt特性名.Text)
                            oProperty.Delete()
                        Catch ex As Exception

                        End Try
                    Else
                        Try
                            '若该iProperty已经存在，则直接修改其值

                            oProperty = oInventorDocDocument.PropertySets.Item("User Defined Properties").Item(txt特性名.Text)
                            Select Case oOption
                                Case EnumPType.eString
                                    oProperty.Value = txt字符串.Text
                                Case EnumPType.eBool
                                    oProperty.Value = Bool布尔值.Checked
                                Case EnumPType.eDouble
                                    If txt实数.Text = "" Then
                                        Exit Sub
                                    End If
                                    oProperty.Value = Convert.ToDouble(txt实数.Text)

                                Case EnumPType.eDate
                                    oProperty.Value = dtp日期.Value
                            End Select

                        Catch
                            ' 若该iProperty不存在，则添加一个
                            Select Case oOption
                                Case EnumPType.eString
                                    oInventorDocDocument.PropertySets.Item("User Defined Properties").Add(txt字符串.Text, txt特性名.Text, PropID)
                                Case EnumPType.eBool
                                    oInventorDocDocument.PropertySets.Item("User Defined Properties").Add(Bool布尔值.Checked, txt特性名.Text, PropID)
                                Case EnumPType.eDouble
                                    If txt实数.Text = "" Then
                                        Exit Sub
                                    End If
                                    oInventorDocDocument.PropertySets.Item("User Defined Properties").Add(Convert.ToDouble(txt实数.Text), txt特性名.Text, PropID)
                                Case EnumPType.eDate
                                    oInventorDocDocument.PropertySets.Item("User Defined Properties").Add(dtp日期.Value, txt特性名.Text, PropID)
                            End Select
                        End Try

                    End If
                    '保存到文件
                    'oInventorDocDocument.PropertySets.FlushToFile()
                    '关闭文件
                    'InventorDoc.Close()
                Next

        End Select

        'btn确定.Enabled = True

        'OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        OInteractionEvents.Stop()

        MessageBox.Show(”量产iProperty完成。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click, Me.Closing
        FormManager.CloseAndDisposeForm(Of formBatchiPoperties)()
    End Sub

    Private Sub FrmiPoperties_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48

        Dim items As String() = {"标题", "主题", "作者", "主管", "单位", "类别", "关键词", "注释", "零件代号", "库存编号", "描述",
            "修订号", "项目", "设计人", "工程师", "批准人", "成本中心", "成本", "供应商", "目录 Web 链接", "检测人",
            "工程核准人", "制造核准人"}

        ' 将数组添加到ComboBox
        cmb项目名.Items.AddRange(items)
        cmb项目名.DropDownStyle = ComboBoxStyle.DropDownList
        cmb项目名.Sorted = True    ' 保持原始顺序
        cmb项目名.SelectedIndex = 0   ' 默认选择第一项

        cmb项目名.Text = EngineerName
        rdo字符串.Checked = True
    End Sub

    Private Sub Rdo字符串_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo字符串.Click
        oOption = EnumPType.eString
    End Sub

    Private Sub Rdo布尔值_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo布尔值.Click
        oOption = EnumPType.eBool
    End Sub

    Private Sub Rdo实数_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo实数.Click
        oOption = EnumPType.eDouble
    End Sub

    Private Sub Rdo日期_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo日期.Click
        oOption = EnumPType.eDate
    End Sub

    '添加文件
    Private Sub Btn添加文件_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn添加文件.Click
        Dim strFilter As String = BasicFilter

        Dim strFile = IO.Path.Combine(ThisApplication.FileLocations.Workspace, "选择文件")

        Dim oFileList As List(Of String)

        oFileList = OpenFileDialog(strFilter, True, strFile)

        If oFileList Is Nothing Then
            Exit Sub
        End If

        For Each strInventorDocumentFullFileName As String In oFileList
            If IsItemInListView(lvw文件列表, strInventorDocumentFullFileName) = False Then
                lvw文件列表.Items.Add(strInventorDocumentFullFileName)
            End If
        Next

    End Sub

    '清空文件列表
    Private Sub Btn清空列表_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn清空列表.Click
        lvw文件列表.Items.Clear()
    End Sub

    '添加文件夹
    Private Sub Btn添加文件夹_Click(sender As Object, e As EventArgs) Handles btn添加文件夹.Click

        Dim strFile = IO.Path.Combine(ThisApplication.FileLocations.Workspace, "选择一个文件确定文件夹")
        Dim strDestinationFolder As String = OpenFolderDialog(strFile)

        If strDestinationFolder Is Nothing Then
            Exit Sub
        End If

        btn添加文件夹.Enabled = False

        GetAllFile(strDestinationFolder, lvw文件列表, IDW)
        GetAllFile(strDestinationFolder, lvw文件列表, IPT)
        GetAllFile(strDestinationFolder, lvw文件列表, IAM)

        btn添加文件夹.Enabled = True

    End Sub

    Private Sub Btn导入已打开文件_Click(sender As Object, e As EventArgs) Handles btn导入已打开文件.Click
        Dim strInventorDocumentFullFileName As String
        For Each oInventorDocument As Inventor.Document In ThisApplication.Documents.VisibleDocuments
            strInventorDocumentFullFileName = oInventorDocument.File.FullFileName
            If strInventorDocumentFullFileName = "" Then
                Continue For
            End If

            If IsItemInListView(lvw文件列表, strInventorDocumentFullFileName) = False Then
                lvw文件列表.Items.Add(strInventorDocumentFullFileName)
            End If

        Next
    End Sub

    '移除
    Private Sub Tsmi移出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi移出.Click
        ListViewDel(lvw文件列表)
    End Sub

    '筛选移除
    Private Sub Tsmi筛选移出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi筛选移出.Click
        Me.TopMost = False
        Dim strFilter As String
        Dim frmInputBox As New FormInputBox
999:
        With frmInputBox
            .txt输入.Text = ""
            .Text = "筛选文件"
            .lbl描述.Text = "输入需要移除的筛选字段，将移除包含字段的工程图。"
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With

        If (frmInputBox.DialogResult = Windows.Forms.DialogResult.OK) And (frmInputBox.txt输入.Text <> "") Then
            strFilter = frmInputBox.txt输入.Text
        Else
            Me.TopMost = True
            Exit Sub
        End If

        For Each oListViewItem As ListViewItem In lvw文件列表.Items
            Dim strInventorDocumentFullFileName As String  ' 全文件名
            strInventorDocumentFullFileName = oListViewItem.Text

            Dim strFileName As String
            strFileName = GetFileNameInfo(strInventorDocumentFullFileName).OnlyName

            If InStr(strFileName, strFilter) <> 0 Then
                oListViewItem.Remove()
            End If
        Next

    End Sub

    '筛选保留
    Private Sub Tsmi筛选保留_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi筛选保留.Click
        Me.TopMost = False
        Dim strFilter As String
        Dim frmInputBox As New FormInputBox
999:
        With frmInputBox
            .txt输入.Text = ""
            .Text = "筛选文件"
            .lbl描述.Text = "输入需要保留的筛选字段，将保留包含字段的工程图。"
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With

        If (frmInputBox.DialogResult = Windows.Forms.DialogResult.OK) And (frmInputBox.txt输入.Text <> "") Then
            strFilter = frmInputBox.txt输入.Text
        Else
            Me.TopMost = True
            Exit Sub
        End If

        For Each oListViewItem As ListViewItem In lvw文件列表.Items
            Dim strInventorDocumentFullFileName As String  '工程图全文件名
            strInventorDocumentFullFileName = oListViewItem.Text

            Dim strFileName As String
            strFileName = GetFileNameInfo(strInventorDocumentFullFileName).OnlyName

            If InStr(strFileName, strFilter) = 0 Then
                oListViewItem.Remove()
            End If

        Next

    End Sub

End Class