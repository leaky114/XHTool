Imports Inventor

Public Class ClsRightMouseShowAll

    Private m_全部显示_Buttondef As ButtonDefinition

    Public Sub New()

        Dim smallPicture As IPictureDisp

        'Dim largePicture As stdole.IPictureDisp
        smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.可见16.ToBitmap)
        'largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.可见32.ToBitmap)

        Me.m_全部显示_Buttondef = ThisApplication.CommandManager.ControlDefinitions.AddButtonDefinition(
            "全部显示", "InName全部显示", CommandTypesEnum.kShapeEditCmdType,
            ClientID, "", , smallPicture, , ButtonDisplayEnum.kDisplayTextInLearningMode)

        AddHandler m_全部显示_Buttondef.OnExecute, AddressOf OnCLick
        AddHandler ThisApplication.CommandManager.UserInputEvents.OnContextMenu, AddressOf OnContextMenu
    End Sub

    Private Sub OnContextMenu(SelectionDevice As SelectionDeviceEnum, AdditionalInfo As NameValueMap, CommandBar As CommandBar)
        Dim oInventorDocument As Inventor.Document = ThisApplication.ActiveDocument

        If TypeOf oInventorDocument IsNot AssemblyDocument Then Return '不是组件退出
        If oInventorDocument.SelectSet.Count <> 0 Then Return '未选择零部件退出



        CommandBar.Controls.AddButton(m_全部显示_Buttondef, 13)    '位置在 全部隐藏下面

        'Dim intCount As Integer
        'intCount = CommandBar.Controls.Item("AssemblyHideAllRelationshipsCmd ").Index + 1
        ' MessageBox.Show(intCount)


        ' MessageBox.Show(CommandBar.Controls.Count)

        'For Each obutton As ButtonDefinition In CommandBar.Controls
        '     MessageBox.Show(obutton.InternalName.ToString)
        'Next

    End Sub

    Private Sub OnCLick()
        OneKeyShowAll()
    End Sub
End Class


