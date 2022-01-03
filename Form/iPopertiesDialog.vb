Imports System.Windows.Forms
Imports Inventor

Public Class iPopertiesDialog

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
        Dim oP As Inventor.Property
        For Each oP In oUserPropertySet
            If oP.PropId > PropID Then
                PropID = oP.PropId
            End If
        Next

        '可接受的PropID范围是: 2 ~ 254 , 256 ~ 0x80000000
        If PropID < 2 Then
            PropID = 2
        End If
    End Sub

    '量产开始
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'Dim thisApprenticeApp = New Inventor.ApprenticeServerComponent()
        'Dim thisApprenticeDoc As Inventor.ApprenticeServerDocument
        Dim oInventorDocDocument As Inventor.Document

        For Each oInventorDocDocument In ThisApplication.Documents
            Select Case oInventorDocDocument.DocumentType
                Case DocumentTypeEnum.kDrawingDocumentObject, DocumentTypeEnum.kAssemblyDocumentObject, DocumentTypeEnum.kPartDocumentObject
                    ListBox1.Items.Add(oInventorDocDocument.FullDocumentName)
            End Select
        Next

        If ListBox1.Items.Count = 0 Then
            MsgBox("未有打开的工程图文件。", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "量产")
            Exit Sub
        End If

        Select Case TabControl1.SelectedIndex

            Case 0

                For i = 0 To ListBox1.Items.Count - 1
                    ListBox1.SelectedIndex = i
                    '打开文件
                    oInventorDocDocument = ThisApplication.Documents.ItemByName(ListBox1.Items(i).ToString)
                    '打开 项目 选项卡
                    Dim oDTProps As PropertySet = oInventorDocDocument.PropertySets.Item("Design Tracking Properties")

                    '用内部定义名的代码
                    'Dim oDesignerProp As Inventor.Property = oDTProps.ItemByPropId(Inventor.PropertiesForDesignTrackingPropertiesEnum.kDesignerDesignTrackingProperties)
                    'oDesignerProp = oDTProps.Item("Designer")
                    'Debug.Print(oDesignerProp.DisplayName & " = " & oDesignerProp.Value)

                    '用显示名 displayname 的代码
                    '定义单个项目
                    Dim oDesignerProp As Inventor.Property

                    '遍历选项卡下的每个单项目
                    For Each oDesignerProp In oDTProps
                        If oDesignerProp.DisplayName = ComboBox1.Text Then
                            '项目名对应，设置数据
                            oDesignerProp.Value = TextBox1.Text.ToString
                        End If
                    Next

                    '保存到文件
                    'InventorDoc.PropertySets.FlushToFile()
                    '关闭文件
                    'InventorDoc.Close()

                Next

            Case 1

                If PropertyName.Text = "" Then
                    MsgBox("请输入新特性的名字！")
                    Exit Sub
                End If

                For i = 0 To ListBox1.Items.Count - 1
                    ListBox1.SelectedIndex = i
                    '打开文件
                    oInventorDocDocument = ThisApplication.Documents.ItemByName(ListBox1.Items(i).ToString)
                    '打开 项目 选项卡
                    'Dim oDTProps As PropertySet = thisApprenticeDoc.PropertySets.Item("User Defined Properties")

                    Dim pEachScale As Inventor.Property

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
                    pEachScale = oInventorDocDocument.PropertySets.Item("User Defined Properties").Item(PropertyName.Text)
                    Select Case oOption
                        Case enumPType.eString
                            pEachScale.Value = StringP.Text
                        Case enumPType.eBool
                            pEachScale.Value = BoolP.Checked
                        Case enumPType.eDouble
                            pEachScale.Value = Convert.ToDouble(DoubleP.Text)
                        Case enumPType.eDate
                            pEachScale.Value = DateTimeP.Value
                    End Select

                    'Catch
                    ' 若该iProperty不存在，则添加一个
                    Select Case oOption
                        Case enumPType.eString
                            oInventorDocDocument.PropertySets.Item("User Defined Properties").Add(StringP.Text, PropertyName.Text, PropID)
                        Case enumPType.eBool
                            oInventorDocDocument.PropertySets.Item("User Defined Properties").Add(BoolP.Checked, PropertyName.Text, PropID)
                        Case enumPType.eDouble
                            oInventorDocDocument.PropertySets.Item("User Defined Properties").Add(Convert.ToDouble(DoubleP.Text), PropertyName.Text, PropID)
                        Case enumPType.eDate
                            oInventorDocDocument.PropertySets.Item("User Defined Properties").Add(DateTimeP.Value, PropertyName.Text, PropID)
                    End Select
                    'End Try

                    '保存到文件
                    oInventorDocDocument.PropertySets.FlushToFile()
                    '关闭文件
                    'InventorDoc.Close()
                Next
        End Select
        MsgBox("量产工程图文件完成。", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "量产")
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub AddNewPDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Text = "工程师"
        StringRadioButton.Checked = True
    End Sub

    Private Sub StringRadioButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StringRadioButton.Click
        oOption = enumPType.eString
    End Sub

    Private Sub BoolRadioButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoolRadioButton.Click
        oOption = enumPType.eBool
    End Sub

    Private Sub DoubleRadioButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoubleRadioButton.Click
        oOption = enumPType.eDouble
    End Sub

    Private Sub DateRadioButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateRadioButton.Click
        oOption = enumPType.eDate
    End Sub

    '添加文件
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addfile.Click
        '打开文件
        Dim NewOpenFileDialog As New OpenFileDialog '声名新open 窗口

        With NewOpenFileDialog
            .Title = "打开"
            .Filter = "AutoCAD Inventor 文件(*.idw;*.iam;*.ipt)|*.idw;*.iam;*.ipt" '添加过滤文件
            .Multiselect = True '多开文件打开
            If .ShowDialog = Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                If .FileName <> "" Then '如果有选中文件
                    For Each FullFileName As String In .FileNames
                        ListBox1.Items.Add(FullFileName)
                    Next

                End If
            End If
        End With
    End Sub

    '清空文件列表
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clearlist.Click
        ListBox1.Items.Clear()
    End Sub
End Class