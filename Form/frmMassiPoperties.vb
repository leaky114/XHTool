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

Public Class frmMassiPoperties

    Enum enumPType
        eString = 0
        eBool = 1
        eDouble = 2
        eDate = 3
    End Enum

    Private oOption As enumPType = enumPType.eString

    Private oUserPropertySet As Inventor.PropertySet
    Private PropID As Long = 0

    Public Sub getUserPropertySet(ByVal oUSet As Inventor.PropertySet)

        '获得缺省的自定义特性集
        oUserPropertySet = oUSet

        '获取最大PropID
        For Each oProperty As Inventor.Property In oUserPropertySet
            if oProperty.PropId > PropID Then
                PropID = oProperty.PropId
            End if
        Next

        '可接受的PropID范围是: 2 ~ 254 , 256 ~ 0x80000000
        if PropID < 2 Then
            PropID = 2
        End if
    End Sub

    '量产开始
    Private Sub btn确定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn确定.Click

        Dim oInventorDocDocument As Inventor.Document

        'For Each oInventorDocDocument In ThisApplication.Documents.VisibleDocuments
        '    Select Case oInventorDocDocument.DocumentType
        '        Case DocumentTypeEnum.kDrawingDocumentObject, DocumentTypeEnum.kAssemblyDocumentObject, DocumentTypeEnum.kPartDocumentObject
        '            lvw文件列表.Items.Add(oInventorDocDocument.FullDocumentName)
        '    End Select
        'Next

        If lvw文件列表.Items.Count = 0 Then
            MsgBox("未有打开的工程图文件。", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        btn确定.Enabled = False

        Dim oInteraction As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        oInteraction.Start()
        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        ThisApplication.UserInterfaceManager.DoEvents()

        Select Case tab1.SelectedIndex

            Case 0


                For Each oListViewItem As ListViewItem In lvw文件列表.Items
                    oListViewItem.Selected = True

                    '打开文件
                    oInventorDocDocument = ThisApplication.Documents.ItemByName(oListViewItem.Text)
                    '打开 项目 选项卡
                    Dim oPropertySet As PropertySet = oInventorDocDocument.PropertySets.Item("Design Tracking Properties")

                    '用内部定义名的代码
                    'Dim oDesignerProp As Inventor.Property = oDTProps.ItemByPropId(Inventor.PropertiesForDesignTrackingPropertiesEnum.kDesignerDesignTrackingProperties)
                    'oDesignerProp = oDTProps.Item("Designer")
                    'Debug.Print(oDesignerProp.DisplayName & " = " & oDesignerProp.Value)

                    '用显示名 displayname 的代码
                    '定义单个项目
                    'Dim oProperty As Inventor.Property

                    '遍历选项卡下的每个单项目
                    For Each oProperty As Inventor.Property In oPropertySet
                        If oProperty.DisplayName = cbo项目名.Text Then
                            '项目名对应，设置数据
                            oProperty.Value = txt数据.Text.ToString
                        End If
                    Next

                    '保存到文件
                    'InventorDoc.PropertySets.FlushToFile()
                    '关闭文件
                    'InventorDoc.Close()

                Next

            Case 1

                If txt特性名.Text = "" Then
                    MsgBox("请输入新特性的名字！")
                    Exit Sub
                End If

                For Each oListViewItem As ListViewItem In lvw文件列表.Items
                    oListViewItem.Selected = True
                    '打开文件
                    oInventorDocDocument = ThisApplication.Documents.Open(oListViewItem.Text)
                    '打开 项目 选项卡
                    'Dim oDTProps As PropertySet = thisApprenticeDoc.PropertySets.Item("User Defined Properties")

                    Dim oProperty As Inventor.Property

                    Try
                        '若该iProperty已经存在，则直接修改其值

                        oProperty = oInventorDocDocument.PropertySets.Item("User Defined Properties").Item(txt特性名.Text)
                        Select Case oOption
                            Case enumPType.eString
                                oProperty.Value = txt字符串.Text
                            Case enumPType.eBool
                                oProperty.Value = Bool布尔值.Checked
                            Case enumPType.eDouble
                                oProperty.Value = Convert.ToDouble(txt实数.Text)
                            Case enumPType.eDate
                                oProperty.Value = dtp日期.Value
                        End Select

                    Catch
                        ' 若该iProperty不存在，则添加一个
                        Select Case oOption
                            Case enumPType.eString
                                oInventorDocDocument.PropertySets.Item("User Defined Properties").Add(txt字符串.Text, txt特性名.Text, PropID)
                            Case enumPType.eBool
                                oInventorDocDocument.PropertySets.Item("User Defined Properties").Add(Bool布尔值.Checked, txt特性名.Text, PropID)
                            Case enumPType.eDouble
                                oInventorDocDocument.PropertySets.Item("User Defined Properties").Add(Convert.ToDouble(txt实数.Text), txt特性名.Text, PropID)
                            Case enumPType.eDate
                                oInventorDocDocument.PropertySets.Item("User Defined Properties").Add(dtp日期.Value, txt特性名.Text, PropID)
                        End Select
                    End Try

                    '保存到文件
                    'oInventorDocDocument.PropertySets.FlushToFile()
                    '关闭文件
                    'InventorDoc.Close()
                Next

        End Select

        btn确定.Enabled = True

        oInteraction.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        oInteraction.Stop()

        MsgBox("量产工程图文件完成。", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

    End Sub

    Private Sub btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub frmiPoperties_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48

        cbo项目名.Text = EngineerName
        rdo字符串.Checked = True
    End Sub

    Private Sub rdo字符串_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo字符串.Click
        oOption = enumPType.eString
    End Sub

    Private Sub rdo布尔值_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo布尔值.Click
        oOption = enumPType.eBool
    End Sub

    Private Sub rdo实数_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo实数.Click
        oOption = enumPType.eDouble
    End Sub

    Private Sub rdo日期_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo日期.Click
        oOption = enumPType.eDate
    End Sub

    '添加文件
    Private Sub btn添加文件_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn添加文件.Click
        Dim strFilter As String = "AutoCAD Inventor 文件(*.idw;*.iam;*.ipt)|*.idw;*.iam;*.ipt"

        Dim arrayFullFileName As List(Of String)

        arrayFullFileName = OpenFileDialog(strFilter, True)

        If arrayFullFileName Is Nothing Then
            Exit Sub
        End If

        For Each strFullFileName In arrayFullFileName
            If IsItemInListView(lvw文件列表, strFullFileName) = False Then
                lvw文件列表.Items.Add(strFullFileName)
            End If
        Next

    End Sub

    '清空文件列表
    Private Sub btn清除列表_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn清除列表.Click
        lvw文件列表.Items.Clear()
    End Sub

    '添加文件夹
    Private Sub btn添加文件夹_Click(sender As Object, e As EventArgs) Handles btn添加文件夹.Click
        Dim strDestinationFolder As String = Nothing
        strDestinationFolder = OpenFolderDialog()

        If strDestinationFolder Is Nothing Then
            Exit Sub
        End If

        btn添加文件夹.Enabled = False

        GetAllFile(strDestinationFolder, lvw文件列表, IDW)
        GetAllFile(strDestinationFolder, lvw文件列表, IPT)
        GetAllFile(strDestinationFolder, lvw文件列表, IAM)

        btn添加文件夹.Enabled = True

    End Sub

    Private Sub btn导入已打开文件_Click(sender As Object, e As EventArgs) Handles btn导入已打开文件.Click
        For Each oInventorDocument As Inventor.Document In ThisApplication.Documents.VisibleDocuments
            lvw文件列表.Items.Add(oInventorDocument.FullDocumentName)
        Next
    End Sub

    '移除
    Private Sub tsmi移出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi移出.Click
        ListViewDel(lvw文件列表)
    End Sub

    '筛选移除
    Private Sub tsmi筛选移出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi筛选移出.Click
        Me.TopMost = False
        Dim strFilter As String
        Dim frmInputBox As New frmInputBox
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
            Dim strInventorDrawingFullFileName As String  '工程图全文件名
            strInventorDrawingFullFileName = oListViewItem.Text

            Dim strInventorDrawingFileOnlyName As String
            strInventorDrawingFileOnlyName = GetFileNameInfo(strInventorDrawingFullFileName).OnlyName

            If InStr(strInventorDrawingFileOnlyName, strFilter) <> 0 Then
                oListViewItem.Remove()
            End If
        Next


    End Sub

    '筛选保留
    Private Sub tsmi筛选保留_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi筛选保留.Click
        Me.TopMost = False
        Dim strFilter As String
        Dim frmInputBox As New frmInputBox
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
            Dim strInventorDrawingFullFileName As String  '工程图全文件名
            strInventorDrawingFullFileName = oListViewItem.Text

            Dim strInventorDrawingFileOnlyName As String
            strInventorDrawingFileOnlyName = GetFileNameInfo(strInventorDrawingFullFileName).OnlyName

            If InStr(strInventorDrawingFileOnlyName, strFilter) = 0 Then
                oListViewItem.Remove()
            End If

        Next

    End Sub
End Class