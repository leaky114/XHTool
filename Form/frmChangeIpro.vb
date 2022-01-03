Imports Inventor
Imports System.Windows.Forms

Public Class frmChangeIpro

    Private Sub btn确定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn确定.Click
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        SetPropitem(oInventorDocument, Map_DrawingNnumber, txt图号.Text)
        SetPropitem(oInventorDocument, Map_PartName, txt文件名.Text)
        SetPropitem(oInventorDocument, Map_Describe, cmb描述.Text)
        SetPropitem(oInventorDocument, Map_ERPCode, txtERPCode.Text)
        SetPropitem(oInventorDocument, Map_Vendor, cmb供应商.Text)

        If oInventorDocument.DocumentType = Inventor.DocumentTypeEnum.kPartDocumentObject Then
            Dim oPartDocument As Inventor.PartDocument = oInventorDocument

            Dim strMaterialName As String
            strMaterialName = cmb材料.Text.ToString

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

    Private Sub btn取消_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn取消.Click
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
                    txt图号.Text = propitem.Value
                Case Map_PartName
                    txt文件名.Text = propitem.Value
                Case Map_Describe
                    cmb描述.Text = propitem.Value
                Case Map_ERPCode
                    txtERPCode.Text = propitem.Value
                Case Map_Vendor
                    cmb供应商.Text = propitem.Value
            End Select
        Next

        If oInventorDocument.DocumentType = Inventor.DocumentTypeEnum.kPartDocumentObject Then
            Dim oPartDocument As Inventor.PartDocument = oInventorDocument
            cmb材料.Items.Clear()

            For Each oMaterial In oPartDocument.Materials
                cmb材料.Items.Add(oMaterial.Name)
            Next
            cmb材料.DropDownStyle = ComboBoxStyle.DropDownList
            cmb材料.Text = oPartDocument.ComponentDefinition.Material.Name.ToString
        Else
            cmb材料.Enabled = False
        End If

    End Sub

    Private Sub btn向上1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn向上1.Click
        Dim strTemp As String
        strTemp = txt图号.Text
        txt图号.Text = txt文件名.Text
        txt文件名.Text = strTemp
    End Sub

    Private Sub btn向上2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn向上2.Click
        Dim strTemp As String
        strTemp = txt文件名.Text
        txt文件名.Text = cmb描述.Text
        cmb描述.Text = strTemp
    End Sub

    Private Sub btn查询_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn查询.Click
        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        btn查询.Enabled = False

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

        strStochNum = txt图号.Text

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
        btn查询.Enabled = True

    End Sub

    Private Sub chk只读_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class