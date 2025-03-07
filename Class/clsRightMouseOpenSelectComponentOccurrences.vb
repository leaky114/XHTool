Imports Inventor

Public Class ClsRightMouseOpenSelectComponentOccurrences
    Private m_打开选择的组件_Buttondef As ButtonDefinition

    Public Sub New()

        Dim smallPicture As IPictureDisp
        Dim largePicture As IPictureDisp

        smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.打开文件16.ToBitmap)
        largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.打开文件32.ToBitmap)

        m_打开选择的组件_Buttondef = ThisApplication.CommandManager.ControlDefinitions.AddButtonDefinition(
           "打开多选", "InName打开组件", CommandTypesEnum.kFileOperationsCmdType,
            ClientID, "", , smallPicture, , ButtonDisplayEnum.kDisplayTextInLearningMode)

        AddHandler m_打开选择的组件_Buttondef.OnExecute, AddressOf OnCLick
        AddHandler ThisApplication.CommandManager.UserInputEvents.OnContextMenu, AddressOf OnContextMenu
    End Sub

    Private Sub OnContextMenu(SelectionDevice As SelectionDeviceEnum, AdditionalInfo As NameValueMap, CommandBar As CommandBar)
        Dim oInventorDocument As Inventor.Document = ThisApplication.ActiveDocument

        If TypeOf oInventorDocument IsNot AssemblyDocument Then Return '不是组件退出
        If oInventorDocument.SelectSet.Count = 0 Then Return '未选择零部件退出

        CommandBar.Controls.AddButton(m_打开选择的组件_Buttondef, 2)

    End Sub

    Private Sub OnCLick()
        OpenSelectComponentOccurrences()
    End Sub
End Class
