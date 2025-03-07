Imports Inventor

Public Class ClsRightMouseTurnOffAdaptivity
    Private m_关闭自适应_Buttondef As ButtonDefinition

    Public Sub New()

        Dim smallPicture As IPictureDisp
        Dim largePicture As IPictureDisp

        smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.自适应16.ToBitmap)
        largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.自适应32.ToBitmap)

        m_关闭自适应_Buttondef = ThisApplication.CommandManager.ControlDefinitions.AddButtonDefinition(
           "关闭自适应", "InName关闭自适应", CommandTypesEnum.kFileOperationsCmdType,
            ClientID, "", , smallPicture, , ButtonDisplayEnum.kDisplayTextInLearningMode)

        AddHandler m_关闭自适应_Buttondef.OnExecute, AddressOf OnCLick
        AddHandler ThisApplication.CommandManager.UserInputEvents.OnContextMenu, AddressOf OnContextMenu
    End Sub

    Private Sub OnContextMenu(SelectionDevice As SelectionDeviceEnum, AdditionalInfo As NameValueMap, CommandBar As CommandBar)
        Dim oInventorDocument As Inventor.Document = ThisApplication.ActiveDocument

        If TypeOf oInventorDocument IsNot AssemblyDocument Then Return '不是组件退出
        If oInventorDocument.SelectSet.Count = 0 Then Return '未选择零部件退出

        CommandBar.Controls.AddButton(m_关闭自适应_Buttondef, 22)

    End Sub

    Private Sub OnCLick()
        Turn_Off_Adaptivity()
    End Sub
End Class
