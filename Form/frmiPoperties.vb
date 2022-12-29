Imports System.Windows.Forms
Imports Inventor

Public Class frmiPoperties

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
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        'Dim thisApprenticeApp = New Inventor.ApprenticeServerComponent()
        'Dim thisApprenticeDoc As Inventor.ApprenticeServerDocument
        Dim oInventorDocDocument As Inventor.Document

        For Each oInventorDocDocument In ThisApplication.Documents
            Select Case oInventorDocDocument.DocumentType
                Case DocumentTypeEnum.kDrawingDocumentObject, DocumentTypeEnum.kAssemblyDocumentObject, DocumentTypeEnum.kPartDocumentObject
                    lstFileLIst.Items.Add(oInventorDocDocument.FullDocumentName)
            End Select
        Next

        If lstFileLIst.Items.Count = 0 Then
            MsgBox("未有打开的工程图文件。", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "量产")
            Exit Sub
        End If

        btnStart.Enabled = False
        'ThisApplication.Cursor  = Cursors.WaitCursor

        Select Case tab1.SelectedIndex

            Case 0

                For i = 0 To lstFileLIst.Items.Count - 1
                    lstFileLIst.SelectedIndex = i
                    '打开文件
                    oInventorDocDocument = ThisApplication.Documents.ItemByName(lstFileLIst.Items(i).ToString)
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
                        If oProperty.DisplayName = cmbProject.Text Then
                            '项目名对应，设置数据
                            oProperty.Value = txtData.Text.ToString
                        End If
                    Next

                    '保存到文件
                    'InventorDoc.PropertySets.FlushToFile()
                    '关闭文件
                    'InventorDoc.Close()

                Next

            Case 1

                If txtProperty.Text = "" Then
                    MsgBox("请输入新特性的名字！")
                    Exit Sub
                End If

                For i = 0 To lstFileLIst.Items.Count - 1
                    lstFileLIst.SelectedIndex = i
                    '打开文件
                    oInventorDocDocument = ThisApplication.Documents.ItemByName(lstFileLIst.Items(i).ToString)
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
                    oProperty = oInventorDocDocument.PropertySets.Item("User Defined Properties").Item(txtProperty.Text)
                    Select Case oOption
                        Case enumPType.eString
                            oProperty.Value = txtString.Text
                        Case enumPType.eBool
                            oProperty.Value = BoolP.Checked
                        Case enumPType.eDouble
                            oProperty.Value = Convert.ToDouble(txtDouble.Text)
                        Case enumPType.eDate
                            oProperty.Value = dtpDate.Value
                    End Select

                    'Catch
                    ' 若该iProperty不存在，则添加一个
                    Select Case oOption
                        Case enumPType.eString
                            oInventorDocDocument.PropertySets.Item("User Defined Properties").Add(txtString.Text, txtProperty.Text, PropID)
                        Case enumPType.eBool
                            oInventorDocDocument.PropertySets.Item("User Defined Properties").Add(BoolP.Checked, txtProperty.Text, PropID)
                        Case enumPType.eDouble
                            oInventorDocDocument.PropertySets.Item("User Defined Properties").Add(Convert.ToDouble(txtDouble.Text), txtProperty.Text, PropID)
                        Case enumPType.eDate
                            oInventorDocDocument.PropertySets.Item("User Defined Properties").Add(dtpDate.Value, txtProperty.Text, PropID)
                    End Select
                    'End Try

                    '保存到文件
                    oInventorDocDocument.PropertySets.FlushToFile()
                    '关闭文件
                    'InventorDoc.Close()
                Next

        End Select

        btnStart.Enabled = True
        'ThisApplication.Cursor  = Cursors.Default
        MsgBox("量产工程图文件完成。", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "量产")

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub frmiPoperties_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbProject.Text = EngineerName
        rdoString.Checked = True
    End Sub

    Private Sub rdoString_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoString.Click
        oOption = enumPType.eString
    End Sub

    Private Sub rdoBool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoBool.Click
        oOption = enumPType.eBool
    End Sub

    Private Sub rdoDouble_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoDouble.Click
        oOption = enumPType.eDouble
    End Sub

    Private Sub rdoDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoDate.Click
        oOption = enumPType.eDate
    End Sub

    '添加文件
    Private Sub btnAddFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFile.Click
        '打开文件
        Dim oOpenFileDialog As New OpenFileDialog '声名新open 窗口

        With oOpenFileDialog
            .Title = "打开"
            .Filter = "AutoCAD Inventor 文件(*.idw;*.iam;*.ipt)|*.idw;*.iam;*.ipt" '添加过滤文件
            .Multiselect = True '多开文件打开
            If .ShowDialog = System.Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                If .FileName <> "" Then '如果有选中文件
                    For Each strFullFileName As String In .FileNames
                        lstFileLIst.Items.Add(strFullFileName)
                    Next

                End If
            End If
        End With
    End Sub

    '清空文件列表
    Private Sub btnClearList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearList.Click
        lstFileLIst.Items.Clear()
    End Sub
End Class