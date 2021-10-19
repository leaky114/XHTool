Imports System.Windows.Forms

Public Class OptionDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If ComboBox1.Text = ComboBox2.Text Then
            MsgBox("映射设置相同！", MsgBoxStyle.Exclamation, "设置")
            Exit Sub
        End If

        Map_StochNum = ComboBox1.Text
        Map_PartName = ComboBox2.Text
        Map_PartNum = ComboBox6.Text
        Map_Mir_StochNum = TextBox1.Text
        Map_Mir_PartName = TextBox2.Text
        Map_DrawingScale = TextBox3.Text
        Map_PrintDay = TextBox4.Text
        EngineerName = TextBox5.Text
        BOMTiTle = TextBox6.Text
        Map_Mass = TextBox7.Text


        '打印签字
        Select Case CheckBox1.CheckState
            Case CheckState.Unchecked
                IsOpenPrint = -1
            Case CheckState.Indeterminate
                IsOpenPrint = 0
            Case CheckState.Checked
                IsOpenPrint = 1
        End Select

        '同时签字
        Select Case CheckBox2.CheckState
            Case CheckState.Unchecked
                IsDayAndName = -1
            Case CheckState.Indeterminate
                IsDayAndName = 0
            Case CheckState.Checked
                IsDayAndName = 1
        End Select

        '打开工程图时写入
        Select Case CheckBox3.CheckState
            Case CheckState.Unchecked
                IsSetDrawingScale = -1
            Case CheckState.Indeterminate
                IsSetDrawingScale = 0
            Case CheckState.Checked
                IsSetDrawingScale = 1
        End Select

        '打开工程图时写入
        Select Case CheckBox4.CheckState
            Case CheckState.Unchecked
                IsSetMass = -1
            Case CheckState.Indeterminate
                IsSetMass = 0
            Case CheckState.Checked
                IsSetMass = 1
        End Select


        '启动检查更新
        Select Case CheckBox5.CheckState
            Case CheckState.Unchecked
                CheckUpdate = -1
            Case CheckState.Indeterminate
                CheckUpdate = 0
            Case CheckState.Checked
                CheckUpdate = 1
        End Select

        '质量精度：
        Select Case ComboBox4.Text
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
        Select Case ComboBox5.Text
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

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub frmoption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '初始化映射
        ComboBox1.Text = Map_StochNum
        ComboBox2.Text = Map_PartName
        ComboBox6.Text = Map_PartNum
        ComboBox3.Text = ComboBox3.Items(0)

        Select Case Mass_Accuracy
            Case "0"
                ComboBox4.Text = "0"
            Case "1"
                ComboBox4.Text = "0.1"
            Case "2"
                ComboBox4.Text = "0.01"
            Case "3"
                ComboBox4.Text = "0.001"
        End Select

        Select Case Area_Accuracy
            Case "0"
                ComboBox5.Text = "0"
            Case "1"
                ComboBox5.Text = "0.1"
            Case "2"
                ComboBox5.Text = "0.01"
            Case "3"
                ComboBox5.Text = "0.001"
            Case "4"
                ComboBox5.Text = "0.0001"
            Case "5"
                ComboBox5.Text = "0.00001"
            Case "6"
                ComboBox5.Text = "0.000001"
        End Select


        TextBox1.Text = Map_Mir_StochNum
        TextBox2.Text = Map_Mir_PartName
        TextBox3.Text = Map_DrawingScale
        TextBox4.Text = Map_PrintDay
        TextBox5.Text = EngineerName
        TextBox6.Text = BOMTiTle
        TextBox7.Text = Map_Mass

        Select Case IsOpenPrint
            Case -1
                CheckBox1.CheckState = CheckState.Unchecked
            Case 0
                CheckBox1.CheckState = CheckState.Indeterminate
            Case 1
                CheckBox1.CheckState = CheckState.Checked
        End Select

        Select Case IsDayAndName
            Case -1
                CheckBox2.CheckState = CheckState.Unchecked
            Case 0
                CheckBox2.CheckState = CheckState.Indeterminate
            Case 1
                CheckBox2.CheckState = CheckState.Checked
        End Select

        Select Case IsSetDrawingScale
            Case -1
                CheckBox3.CheckState = CheckState.Unchecked
            Case 0
                CheckBox3.CheckState = CheckState.Indeterminate
            Case 1
                CheckBox3.CheckState = CheckState.Checked
        End Select

        Select Case IsSetMass
            Case -1
                CheckBox4.CheckState = CheckState.Unchecked
            Case 0
                CheckBox4.CheckState = CheckState.Indeterminate
            Case 1
                CheckBox4.CheckState = CheckState.Checked
        End Select

        Select Case CheckUpdate
            Case -1
                CheckBox5.CheckState = CheckState.Unchecked
            Case 0
                CheckBox5.CheckState = CheckState.Indeterminate
            Case 1
                CheckBox5.CheckState = CheckState.Checked
        End Select

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button添加.Click

        If TextBox6.Text = "" Then
            TextBox6.Text = ComboBox3.Text
        Else
            TextBox6.Text = TextBox6.Text & "|" & ComboBox3.Text
        End If

    End Sub

    Private Sub Button清除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button清除.Click
        TextBox6.Clear()
    End Sub

    Private Sub Button还原_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button还原.Click
        TextBox6.Text = BOMTiTle
    End Sub

End Class
