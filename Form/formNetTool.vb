Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Inventor
Public Class FormNetTool

    ' 此函数用于从IPictureDisp获取Image
    Private Function PictureDispToImage(ByVal pictureDisp As IPictureDisp) As Image
        Dim hdc As IntPtr = GetDC(0)
        Dim bmp As Bitmap = Bitmap.FromHicon(pictureDisp.Handle)
        ReleaseDC(0, hdc)
        Return bmp
    End Function

    ' 模拟获取IPictureDisp对象的函数
    Private Function GetPictureDisp() As IPictureDisp
        ' 这里应该添加实际获取IPictureDisp对象的代码
        Return Nothing
    End Function

    ' API函数声明
    Private Declare Auto Function GetDC Lib "user32" (ByVal hwnd As IntPtr) As IntPtr
    Private Declare Auto Function ReleaseDC Lib "user32" (ByVal hwnd As IntPtr, ByVal hdc As IntPtr) As Integer


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        On Error Resume Next
        ComboBox2.Items.Clear()
        Dim partRibbon As Ribbon = ThisApplication.UserInterfaceManager.Ribbons(ComboBox1.Text)

        For Each toolsTab As RibbonTab In partRibbon.RibbonTabs
            ComboBox2.Items.Add(toolsTab.InternalName)
        Next

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        On Error Resume Next
        ComboBox3.Items.Clear()
        Dim toolsTab As RibbonTab = ThisApplication.UserInterfaceManager.Ribbons(ComboBox1.Text).RibbonTabs.Item(ComboBox2.Text)

        TextBox1.Text = toolsTab.DisplayName

        For Each Ribbon_Panel As RibbonPanel In toolsTab.RibbonPanels
            ComboBox3.Items.Add(Ribbon_Panel.InternalName)
        Next
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        On Error Resume Next
        ComboBox4.Items.Clear()
        Dim Ribbon_Panel As RibbonPanel = ThisApplication.UserInterfaceManager.Ribbons(ComboBox1.Text).RibbonTabs.Item(ComboBox2.Text).RibbonPanels.Item(ComboBox3.Text)
        TextBox2.Text = Ribbon_Panel.DisplayName

        For Each commandcontrol As CommandControl In Ribbon_Panel.CommandControls
            ComboBox4.Items.Add(commandcontrol.InternalName)
        Next
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        On Error Resume Next
        ComboBox5.Items.Clear()

        Dim commandcontrol As CommandControl = ThisApplication.UserInterfaceManager.Ribbons(ComboBox1.Text).RibbonTabs.Item(ComboBox2.Text).RibbonPanels.Item(ComboBox3.Text).CommandControls.Item(ComboBox4.Text)
        TextBox3.Text = commandcontrol.DisplayName

        If commandcontrol.ChildControls Is Nothing Then

            'Dim oimage As System.Drawing.Image = clsPictureConverter.PictureDispToImage(commandcontrol.ControlDefinition.StandardIcon)
            'PictureBox1.Image = oimage

            Dim oDef1 As ButtonDefinition
            oDef1 = ThisApplication.CommandManager.ControlDefinitions.Item(ComboBox4.Text)

            'Dim oIcon As IPictureDisp
            'oIcon = oDef1.LargeIco

            'SavePicture(oIcon, "C:\temp\Fillet.bmp")
        Else
            For Each commandchildcontrol As CommandControl In commandcontrol.ChildControls
                ComboBox5.Items.Add(commandchildcontrol.InternalName)
            Next
        End If


    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        On Error Resume Next
        Dim commandcontrol As CommandControl = ThisApplication.UserInterfaceManager.Ribbons(ComboBox1.Text).RibbonTabs.Item(ComboBox2.Text).RibbonPanels.Item(ComboBox3.Text).CommandControls.Item(ComboBox4.Text).ChildControls.Item(ComboBox5.Text)

        TextBox4.Text = commandcontrol.DisplayName

        Dim oimage As System.Drawing.Image = clsPictureConverter.PictureDispToImage(commandcontrol.ControlDefinition.LargeIcon)

    End Sub

    Private Sub FrmNetTool_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next

        For Each partRibbon As Inventor.Ribbon In ThisApplication.UserInterfaceManager.Ribbons
            ComboBox1.Items.Add(partRibbon.InternalName)
        Next

        For Each oCommandControl As CommandControl In ThisApplication.UserInterfaceManager.FileBrowserControls
            ComboBox6.Items.Add(oCommandControl.InternalName)
        Next

        For Each oControlDefinition As ControlDefinition In ThisApplication.CommandManager.ControlDefinitions
            ComboBox8.Items.Add(oControlDefinition.InternalName)
        Next
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged
        On Error Resume Next
        ComboBox7.Items.Clear()

        Dim oCommandcontrol As CommandControl = ThisApplication.UserInterfaceManager.FileBrowserControls.Item(ComboBox6.Text)
        TextBox6.Text = oCommandcontrol.DisplayName

        For Each oChildCommandControl As CommandControl In oCommandcontrol.ChildControls
            ComboBox7.Items.Add(oChildCommandControl.ControlDefinition.InternalName)
        Next

    End Sub

    Private Sub ComboBox7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox7.SelectedIndexChanged
        On Error Resume Next
        TextBox7.Text = ThisApplication.UserInterfaceManager.FileBrowserControls.Item(ComboBox6.Text).ChildControls.Item(ComboBox7.Text).ControlDefinition.DisplayName
    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox8.SelectedIndexChanged
        Dim oControlDefinition As ControlDefinition = ThisApplication.CommandManager.ControlDefinitions.Item(ComboBox8.Text)
        TextBox8.Text = oControlDefinition.DisplayName

    End Sub

    Private Sub TextBox8_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox8.MouseDoubleClick
        ThisApplication.CommandManager.ControlDefinitions.Item(ComboBox8.Text).Execute2(True)
    End Sub

    Private Sub TextBox7_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox7.MouseDoubleClick
        ThisApplication.UserInterfaceManager.FileBrowserControls.Item(ComboBox6.Text).ChildControls.Item(ComboBox7.Text).ControlDefinition.Execute2(True)
    End Sub

    Private Sub TextBox4_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox4.MouseDoubleClick
        ThisApplication.UserInterfaceManager.Ribbons(ComboBox1.Text).RibbonTabs.Item(ComboBox2.Text).RibbonPanels.Item(ComboBox3.Text).CommandControls.Item(ComboBox4.Text).ChildControls.Item(ComboBox5.Text).ControlDefinition.Execute2(True)
    End Sub

    Private Sub FormNetTool_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        FormManager.CloseAndDisposeForm(Of FormNetTool)()
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub
End Class