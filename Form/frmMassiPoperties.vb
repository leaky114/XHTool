Imports Inventor
Imports System.Windows.Forms

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

        For Each oInventorDocDocument In ThisApplication.Documents
            Select Case oInventorDocDocument.DocumentType
                Case DocumentTypeEnum.kDrawingDocumentObject, DocumentTypeEnum.kAssemblyDocumentObject, DocumentTypeEnum.kPartDocumentObject
                    lst文件列表.Items.Add(oInventorDocDocument.FullDocumentName)
            End Select
        Next

        if lst文件列表.Items.Count = 0 Then
            MsgBox("未有打开的工程图文件。", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "量产")
            Exit Sub
        End if

        btn确定.Enabled = False
        'ThisApplication.Cursor  = Cursors.WaitCursor

        Select Case tab1.SelectedIndex

            Case 0

                For i = 0 To lst文件列表.Items.Count - 1
                    lst文件列表.SelectedIndex = i
                    '打开文件
                    oInventorDocDocument = ThisApplication.Documents.ItemByName(lst文件列表.Items(i).ToString)
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
                        if oProperty.DisplayName = cbo项目名.Text Then
                            '项目名对应，设置数据
                            oProperty.Value = txt数据.Text.ToString
                        End if
                    Next

                    '保存到文件
                    'InventorDoc.PropertySets.FlushToFile()
                    '关闭文件
                    'InventorDoc.Close()

                Next

            Case 1

                if txt特性名.Text = "" Then
                    MsgBox("请输入新特性的名字！")
                    Exit Sub
                End if

                For i = 0 To lst文件列表.Items.Count - 1
                    lst文件列表.SelectedIndex = i
                    '打开文件
                    oInventorDocDocument = ThisApplication.Documents.ItemByName(lst文件列表.Items(i).ToString)
                    '打开 项目 选项卡
                    'Dim oDTProps As PropertySet = thisApprenticeDoc.PropertySets.Item("User Defined Properties")

                    Dim oProperty As Inventor.Property

                    'Try
                    '    '若该iProperty已经存在，则直接修改其值

                    '    pEachScale = IdwDoc.PropertySets.Item("User Defined Properties").Item(Map_PrintDay)
                    '    pEachScale.Value = Print_Day
                    'Catch
                    '    ' 若该iProperty不存在，则添加一个
                    '    IdwDoc.PropertySets.Item("User Defined Properties").Add(Print_Day, Map_PrintDay)
                    'End Try

                    'Try
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

                    'Catch
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
                    'End Try

                    '保存到文件
                    oInventorDocDocument.PropertySets.FlushToFile()
                    '关闭文件
                    'InventorDoc.Close()
                Next

        End Select

        btn确定.Enabled = True
        'ThisApplication.Cursor  = Cursors.Default
        MsgBox("量产工程图文件完成。", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "量产")

    End Sub

    Private Sub btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub frmiPoperties_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        '打开文件
        Dim oOpenFileDialog As New OpenFileDialog '声名新open 窗口

        With oOpenFileDialog
            .Filter = "AutoCAD Inventor 文件(*.idw;*.iam;*.ipt)|*.idw;*.iam;*.ipt" '添加过滤文件
            .Title = "打开"
            .Multiselect = True '多开文件打开
            if .ShowDialog = System.Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                if .FileName <> "" Then '如果有选中文件
                    For Each strFullFileName As String In .FileNames
                        lst文件列表.Items.Add(strFullFileName)
                    Next

                End if
            End if
        End With
    End Sub

    '清空文件列表
    Private Sub btn清除列表_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn清除列表.Click
        lst文件列表.Items.Clear()
    End Sub

End Class