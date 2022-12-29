Imports System.Windows.Forms
Imports Inventor

Public Class frmChangeIpro

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        SetPropitem(oInventorDocument, Map_DrawingNnumber, txtNum.Text)
        SetPropitem(oInventorDocument, Map_PartName, txtFileName.Text)
        SetPropitem(oInventorDocument, Map_Describe, cmbDescribe.Text)
        SetPropitem(oInventorDocument, Map_ERPCode, txtERPCode.Text)
        SetPropitem(oInventorDocument, Map_Vendor, cmbSupplier.Text)

        If oInventorDocument.DocumentType = Inventor.DocumentTypeEnum.kPartDocumentObject Then
            Dim oPartDocument As Inventor.PartDocument = oInventorDocument

            Dim strMaterialName As String
            strMaterialName = cmbMaterialName.Text.ToString

            Dim oMaterial As Inventor.Material
            oMaterial = oPartDocument.Materials.Item(strMaterialName)

            oPartDocument.ComponentDefinition.Material = oMaterial
            'Else
            ''MsgBox("该功能仅适用于零件！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "更改材料")
            'Exit Sub
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub frmChangeIpro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        Dim oPropSets As PropertySets
        Dim oPropSet As PropertySet
        Dim propitem As [Property]

        oPropSets = oInventorDocument.PropertySets
        oPropSet = oPropSets.Item(3)

        '获取iproperty
        ''Dim oStockNumPartName As StockNumPartName = Nothing
        For Each propitem In oPropSet
            Select Case propitem.DisplayName
                Case Map_DrawingNnumber
                    txtNum.Text = propitem.Value
                Case Map_PartName
                    txtFileName.Text = propitem.Value
                Case Map_Describe
                    cmbDescribe.Text = propitem.Value
                Case Map_ERPCode
                    txtERPCode.Text = propitem.Value
                Case Map_Vendor
                    cmbSupplier.Text = propitem.Value
            End Select
        Next

        If oInventorDocument.DocumentType = Inventor.DocumentTypeEnum.kPartDocumentObject Then
            Dim oPartDocument As Inventor.PartDocument = oInventorDocument
            cmbMaterialName.Items.Clear()

            For Each oMaterial In oPartDocument.Materials
                cmbMaterialName.Items.Add(oMaterial.name)
            Next
            cmbMaterialName.DropDownStyle = ComboBoxStyle.DropDownList
            cmbMaterialName.Text = oPartDocument.ComponentDefinition.Material.Name.ToString
        Else
            cmbMaterialName.Enabled = False
            Exit Sub
        End If

    End Sub

    Private Sub btnUp1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp1.Click
        Dim strTemp As String
        strTemp = txtNum.Text
        txtNum.Text = txtFileName.Text
        txtFileName.Text = strTemp
    End Sub

    Private Sub btnUp2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp2.Click
        Dim strTemp As String
        strTemp = txtFileName.Text
        txtFileName.Text = cmbDescribe.Text
        cmbDescribe.Text = strTemp
    End Sub

    Private Sub btnSearchERPCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchERPCode.Click
        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        btnSearchERPCode.Enabled = False

        'Dim oInteraction As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
        'oInteraction.Start()
        'oInteraction.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)
        'System.Threading.Thread.Sleep(5000)
        'oInteraction.Stop()

        Dim oInventorDocument As Inventor.Document      '当前文件
        oInventorDocument = ThisApplication.ActiveEditDocument

        'Dim oPropSets As PropertySets
        'Dim oPropSet As PropertySet
        'Dim propitem As [Property]

        'oPropSets = oInventorDocument.PropertySets
        'oPropSet = oPropSets.Item(3)

        ''获取iproperty
        'Dim oStockNumPartName As StockNumPartName = Nothing
        Dim strStochNum As String = Nothing
        Dim strPartNum As String = Nothing

        'For Each propitem In oPropSet
        '    Select Case propitem.DisplayName
        '        Case Map_DrawingNnumber
        '            strStochNum = propitem.Value
        '            'PartNum = VLookUpValue(Excel_File_Name, StochNum, Sheet_Name, Table_Array, Col_Index_Num, 0)
        '            Exit For
        '    End Select
        'Next

        strStochNum = txtNum.Text

        strPartNum = FindSrtingInSheet(BasicExcelFullFileName, strStochNum, SheetName, TableArrays, ColIndexNum, 0)
        If strPartNum <> 0 Then
            'MsgBox("查询到ERP编码：" & strPartNum, MsgBoxStyle.OkOnly, "查询ERP编码")
            'SetPropitem(oInventorDocument, Map_ERPCode, strPartNum)
            Select Case txtERPCode.Text
                Case ""
                    txtERPCode.Text = strPartNum
                Case Else
                    If txtERPCode.Text <> strPartNum Then
                        If MsgBox("查询到不同的ERP编码：" & strPartNum & "，是否更新？", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "") = MsgBoxResult.Yes Then
                            txtERPCode.Text = strPartNum
                        End If
                    End If
            End Select
        Else

            MsgBox("未查询到ERP编码。", MsgBoxStyle.OkOnly, "查询ERP编码")
        End If

        'oInteraction.Stop()
        btnSearchERPCode.Enabled = True

    End Sub

End Class