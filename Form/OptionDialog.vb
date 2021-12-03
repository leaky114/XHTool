Imports System.Windows.Forms

Public Class OptionDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If cbo图号.Text = cbo文件名.Text Then
            MsgBox("映射设置相同！", MsgBoxStyle.Exclamation, "设置")
            Exit Sub
        End If

        Map_StochNum = cbo图号.Text
        Map_PartName = cbo文件名.Text
        Map_PartNum = cbo存货编码.Text
        Map_Mir_StochNum = txt图号映射.Text
        Map_Mir_PartName = txt文件名映射.Text
        Map_DrawingScale = txt比例.Text
        Map_PrintDay = txt打印日期.Text
        EngineerName = txt工程师.Text
        BOMTiTle = txtBOM导出项.Text
        Map_Mass = txt图号.Text

        Excel_File_Name = txtexcel文件.Text
        Sheet_Name = txt数据表.Text
        Table_Array = txt查找范围.Text
        Col_Index_Num = txt查询列.Text

        '打印签字
        Select Case chk签字后打印.Checked
            Case False
                IsOpenPrint = "-1"
            Case True
                IsOpenPrint = "1"
        End Select

        '同时签字
        Select Case chk签字.Checked
            Case False
                IsDayAndName = "-1"

            Case True
                IsDayAndName = "1"
        End Select

        '打开工程图时写入
        Select Case CheckBox3.Checked
            Case False
                IsSetDrawingScale = "-1"
            Case True
                IsSetDrawingScale = "1"
        End Select

        '打开工程图时写入
        Select Case CheckBox4.Checked
            Case False
                IsSetMass = "-1"
            Case True
                IsSetMass = "1"
        End Select

        '启动检查更新
        Select Case chk检查更新.Checked
            Case False
                CheckUpdate = "-1"
            Case True
                CheckUpdate = "1"
        End Select

        '质量精度：
        Select Case cbo质量精度.Text
            Case "", "0"
                Mass_Accuracy = "0"
            Case "0.1"
                Mass_Accuracy = "1"
            Case "0.01"
                Mass_Accuracy = "2"
            Case "0.001"
                Mass_Accuracy = "3"
        End Select

        '面积精度：
        Select Case cbo面积精度.Text
            Case "", "0"
                Area_Accuracy = "0"
            Case "0.1"
                Area_Accuracy = "1"
            Case "0.01"
                Area_Accuracy = "2"
            Case "0.001"
                Area_Accuracy = "3"
            Case "0.0001"
                Area_Accuracy = "4"
            Case "0.00001"
                Area_Accuracy = "5"
            Case "0.000001"
                Area_Accuracy = "6"
        End Select

        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapStochNum", Map_StochNum)
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapPartName", Map_PartName)
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapPartNum", Map_PartNum)

        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapMirStochNum", Map_Mir_StochNum)
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapMirPartName", Map_Mir_PartName)

        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapDrawingScale", Map_DrawingScale)
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "IsSetDrawingScale", IsSetDrawingScale)

        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", " MapMass", Map_Mass)
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "IsSetMass", IsSetMass)

        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "MapPrintDay", Map_PrintDay)
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "IsOpenPrint", IsOpenPrint)

        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "EngineerName", EngineerName)
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "IsDayAndName", IsDayAndName)

        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "BOMTiTle", BOMTiTle)
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "Mass_Accuracy", Mass_Accuracy)
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "Area_Accuracy", Area_Accuracy)

        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "CheckUpdate", CheckUpdate)

        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "Excel_File_Name", Excel_File_Name)
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "Sheet_Name", Sheet_Name)
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "Table_Array", Table_Array)
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorTool", "Col_Index_Num", Col_Index_Num)

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub frmoption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '初始化映射
        cbo图号.Text = Map_StochNum
        cbo文件名.Text = Map_PartName
        cbo存货编码.Text = Map_PartNum
        cbo添加.Text = cbo添加.Items(0)

        Select Case Mass_Accuracy
            Case "0"
                cbo质量精度.Text = "0"
            Case "1"
                cbo质量精度.Text = "0.1"
            Case "2"
                cbo质量精度.Text = "0.01"
            Case "3"
                cbo质量精度.Text = "0.001"
        End Select

        Select Case Area_Accuracy
            Case "0"
                cbo面积精度.Text = "0"
            Case "1"
                cbo面积精度.Text = "0.1"
            Case "2"
                cbo面积精度.Text = "0.01"
            Case "3"
                cbo面积精度.Text = "0.001"
            Case "4"
                cbo面积精度.Text = "0.0001"
            Case "5"
                cbo面积精度.Text = "0.00001"
            Case "6"
                cbo面积精度.Text = "0.000001"
        End Select

        txt图号映射.Text = Map_Mir_StochNum
        txt文件名映射.Text = Map_Mir_PartName
        txt比例.Text = Map_DrawingScale
        txt打印日期.Text = Map_PrintDay
        txt工程师.Text = EngineerName
        txtBOM导出项.Text = BOMTiTle
        txt图号.Text = Map_Mass

        Select Case IsOpenPrint
            Case "-1"
                chk签字后打印.Checked = False
            Case "1"
                chk签字后打印.Checked = True
        End Select

        Select Case IsDayAndName
            Case "-1"
                chk签字.Checked = False
            Case "1"
                chk签字.Checked = True
        End Select

        Select Case IsSetDrawingScale
            Case "-1"
                CheckBox3.Checked = False
            Case "1"
                CheckBox3.Checked = True
        End Select

        Select Case IsSetMass
            Case "-1"
                CheckBox4.Checked = False
            Case "1"
                CheckBox4.Checked = True
        End Select

        Select Case CheckUpdate
            Case "-1"
                chk检查更新.Checked = False
            Case "1"
                chk检查更新.Checked = True
        End Select

        txtexcel文件.Text = Excel_File_Name
        txt数据表.Text = Sheet_Name
        txt查找范围.Text = Table_Array
        txt查询列.Text = Col_Index_Num

    End Sub

    Private Sub btn添加_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn添加.Click

        If txtBOM导出项.Text = "" Then
            txtBOM导出项.Text = cbo添加.Text
        Else
            txtBOM导出项.Text = txtBOM导出项.Text & "|" & cbo添加.Text
        End If

    End Sub

    Private Sub Bbtn清除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn清除.Click
        txtBOM导出项.Clear()
    End Sub

    Private Sub btn还原_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn还原.Click
        txtBOM导出项.Text = BOMTiTle
    End Sub

    Private Sub btnexcel文件_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexcel文件.Click
        Dim NewOpenFileDialog As New OpenFileDialog

        With NewOpenFileDialog
            .Title = "打开"
            .FileName = ""
            '.Filter = "AutoDesk Inventor 工程图文件(*.idw)|*.idw" '添加过滤文件
            .Multiselect = True '多开文件打开
            If .ShowDialog = Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                If .FileName <> "" Then '如果有选中文件
                    txtexcel文件.Text = .FileName
                End If
            Else
                Exit Sub
            End If
        End With
    End Sub
End Class