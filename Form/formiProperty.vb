Imports Inventor
Imports System.Windows.Forms

Public Class FormiProperty

    Private Sub Btn确定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn确定.Click
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        SetPropitem(oInventorDocument, Map_DrawingNnumber, txt图号.Text)
        SetPropitem(oInventorDocument, Map_PartName, txt文件名.Text)
        SetPropitem(oInventorDocument, Map_Describe, cmb描述.Text)
        SetPropitem(oInventorDocument, Map_ERPCode, txtERP编码.Text)
        SetPropitem(oInventorDocument, Map_Vendor, cmb供应商.Text)
        SetPropitem(oInventorDocument, Map_Price, IIf(txt价格.Text = "", "0", txt价格.Text))

        If oInventorDocument.DocumentType = Inventor.DocumentTypeEnum.kPartDocumentObject Then
            Dim oPartDocument As Inventor.PartDocument = oInventorDocument

            Dim strMaterialName As String
            strMaterialName = cmb材料.Text.ToString

            Dim oMaterial As Inventor.Material
            oMaterial = oPartDocument.Materials.Item(strMaterialName)

            oPartDocument.ComponentDefinition.Material = oMaterial
            'Else
            '' MessageBox.Show("该功能仅适用于零件！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "更改材料")
            'Exit Sub
        End If

        If InStr(oInventorDocument.File.FullFileName, ContentCenterFiles) > 0 Then    '零件库文件自动保存
            oInventorDocument.Save2(True)
        End If

        FormManager.CloseAndDisposeForm(Of FormiProperty)()
    End Sub

    Private Sub Btn取消_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn取消.Click, Me.Closing
        FormManager.CloseAndDisposeForm(Of FormiProperty)()
    End Sub

    Private Sub FrmChangeIpro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48
        Me.TopMost = True

        '加载自定义描述
        LoadCustomDescription(cmb描述)

        Dim toolTip As New ToolTip With {
            .AutoPopDelay = 0,
            .InitialDelay = 0,
            .ReshowDelay = 500
        }
        toolTip.SetToolTip(btn向上1, "交换 图号-文件名")
        toolTip.SetToolTip(btn向上2, "交换 文件名-描述")
        toolTip.SetToolTip(btn查询, "查询ERP编码")
        toolTip.SetToolTip(btn保存描述, "保存描述到配置文件")

        btn向上1.Image = My.Resources.交换16.ToBitmap
        btn向上2.Image = My.Resources.交换16.ToBitmap
        btn查询.Image = My.Resources.查询16.ToBitmap
        btn保存描述.Image = My.Resources.保存关闭16.ToBitmap

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        Me.Text = "iProperty+  " & GetFileNameInfo(oInventorDocument.File.FullFileName).OnlyName

        txt位置.Text = oInventorDocument.File.FullFileName

        Dim oPropertySets As PropertySets
        Dim oPropertySet As PropertySet
        Dim propitem As [Property]

        '=============================================================================
        '采用学徒服务器, 速度更快
        'Dim apprentice As Inventor.ApprenticeServerComponent
        'apprentice = New Inventor.ApprenticeServerComponent

        'Dim apprenticeDoc As Inventor.ApprenticeServerDocument
        'apprenticeDoc = apprentice.Open(oInventorDocument.FullDocumentName)

        'oPropertySets = apprenticeDoc.PropertySets

        '=============================================================================

        oPropertySets = oInventorDocument.PropertySets

        '获取iproperty

        For Each oPropertySet In oPropertySets
            For Each propitem In oPropertySet
                Select Case propitem.DisplayName
                    Case Map_DrawingNnumber
                        txt图号.Text = propitem.Value
                    Case Map_PartName
                        txt文件名.Text = propitem.Value
                    Case Map_Describe
                        cmb描述.Text = propitem.Value
                    Case Map_ERPCode
                        txtERP编码.Text = propitem.Value
                    Case Map_Vendor
                        cmb供应商.Text = propitem.Value
                    Case Map_Price
                        txt价格.Text = propitem.Value
                    Case "质量"
                        txt质量.Text = FourFive(propitem.Value * 0.001, Mass_Accuracy) & "Kg"
                End Select
            Next
        Next

        If oInventorDocument.DocumentType = Inventor.DocumentTypeEnum.kPartDocumentObject Then
            Dim oInventorPartDocument As Inventor.PartDocument = oInventorDocument
            cmb材料.Items.Clear()

            For Each oMaterial In oInventorPartDocument.Materials
                cmb材料.Items.Add(oMaterial.Name)
            Next
            cmb材料.DropDownStyle = ComboBoxStyle.DropDownList
            cmb材料.Text = oInventorPartDocument.ComponentDefinition.Material.Name.ToString
        Else
            cmb材料.Enabled = False
        End If

    End Sub

    Private Sub Btn向上1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn向上1.Click
        Dim strTemp As String
        strTemp = txt图号.Text
        txt图号.Text = txt文件名.Text
        txt文件名.Text = strTemp
    End Sub

    Private Sub Btn向上2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn向上2.Click
        Dim strTemp As String
        strTemp = txt文件名.Text
        txt文件名.Text = cmb描述.Text
        cmb描述.Text = strTemp
    End Sub

    Private Sub Btn查询_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn查询.Click
        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        btn查询.Enabled = False

        Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        OInteractionEvents.Start()
        OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        ThisApplication.UserInterfaceManager.DoEvents()


        Dim oInventorDocument As Inventor.Document      '当前文件
        oInventorDocument = ThisApplication.ActiveEditDocument

        Dim strStochNum As String
        Dim strPartNum As String

        strStochNum = txt图号.Text

        strPartNum = FindSrtingInSheet(BasicExcelFullFileName, strStochNum, SheetName, TableArrays, ColIndexNum, 0)
        If strPartNum <> 0 Then
            ' MessageBox.Show("查询到ERP编码：" & strPartNum, MsgBoxStyle.OkOnly, "查询ERP编码")
            'SetPropitem(oInventorDocument, Map_ERPCode, strPartNum)
            Select Case txtERP编码.Text
                Case ""
                    txtERP编码.Text = strPartNum
                Case Else
                    If txtERP编码.Text <> strPartNum Then
                        If MessageBox.Show($"查询到不同的ERP编码：{strPartNum}，是否更新？", XHTool，
                                           MessageBoxButtons.YesNo， MessageBoxIcon.Question） = DialogResult.Yes Then
                            txtERP编码.Text = strPartNum
                        End If
                    End If
            End Select
        Else
            Me.TopMost = False
            MessageBox.Show(”未查询到ERP编码。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TopMost = True
        End If

        btn查询.Enabled = True

        'OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeDefault)
        OInteractionEvents.Stop()

    End Sub

    Private Sub Txt价格_MouseClick(sender As Object, e As MouseEventArgs) Handles txt价格.MouseClick
        txt价格.SelectAll()
    End Sub

    Private Sub TxtERP编码_MouseClick(sender As Object, e As MouseEventArgs) Handles txtERP编码.MouseClick
        txtERP编码.SelectAll()
    End Sub



    ''' <summary>
    ''' 从配置文件加载自定义描述
    ''' </summary>
    ''' <param name="oComboBox">ComboBox对象</param>
    ''' <remarks></remarks>
    Private Sub LoadCustomDescription(oComboBox As ComboBox)
        Dim strDescriptions As String
        Dim arrayDescriptions() As String
        Dim strDescription As String

        strDescriptions = GetStrFromINI("自定义描述", "自定义描述", "", IniFile)

        arrayDescriptions = Strings.Split(strDescriptions, "|")

        For Each strDescription In arrayDescriptions
            If oComboBox.Items.Contains(strDescription) = False Then
                oComboBox.Items.Add(strDescription)
            End If
        Next

    End Sub

    ''' <summary>
    ''' 保存自定义描述到配置文件
    ''' </summary>
    ''' <param name="oComboBox">ComboBox</param>
    ''' <remarks></remarks>
    Private Sub SaveCustomDescription(oComboBox As ComboBox)
        Dim strDescriptions As String = Nothing
        Dim i As Integer

        For i = 1 To oComboBox.Items.Count - 1
            strDescriptions = strDescriptions & "|" & oComboBox.Items(i)
        Next

        WriteStrINI("自定义描述", "自定义描述", strDescriptions, IniFile)

    End Sub

    Private Sub Btn提取文件名_Click(sender As Object, e As EventArgs) Handles btn提取文件名.Click
        Dim oInventorDocument As Inventor.Document      '当前文件
        oInventorDocument = ThisApplication.ActiveEditDocument

        Dim strInventorDocumentFullFileName As String
        strInventorDocumentFullFileName = oInventorDocument.File.FullFileName

        Dim oStockNumPartName As StockNumPartName
        oStockNumPartName = GetStockNumPartName(strInventorDocumentFullFileName)

        SetPropitem(oInventorDocument, Map_DrawingNnumber, oStockNumPartName.图号)
        SetPropitem(oInventorDocument, Map_PartName, oStockNumPartName.零件名称)

        txt图号.Text = oStockNumPartName.图号
        txt文件名.Text = oStockNumPartName.零件名称

    End Sub

End Class