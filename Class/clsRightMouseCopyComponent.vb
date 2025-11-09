Imports Inventor

Public Class ClsRightMouseCopyComponent
    Private m_复制组件_Buttondef As ButtonDefinition

    Public Sub New()

        Dim smallPicture As IPictureDisp
        Dim largePicture As IPictureDisp

        smallPicture = ClsPictureConverter.ImageToPictureDisp(My.Resources.复制16.ToBitmap)
        largePicture = ClsPictureConverter.ImageToPictureDisp(My.Resources.复制32.ToBitmap)

        m_复制组件_Buttondef = ThisApplication.CommandManager.ControlDefinitions.AddButtonDefinition(
           "复制组件", "InName复制组件", CommandTypesEnum.kFileOperationsCmdType,
            ClientID, "", , smallPicture, , ButtonDisplayEnum.kDisplayTextInLearningMode)

        AddHandler m_复制组件_Buttondef.OnExecute, AddressOf OnCLick
        AddHandler ThisApplication.CommandManager.UserInputEvents.OnContextMenu, AddressOf OnContextMenu
    End Sub

    Private Sub OnContextMenu(SelectionDevice As SelectionDeviceEnum, AdditionalInfo As NameValueMap, CommandBar As CommandBar)
        Dim oInventorDocument As Inventor.Document = ThisApplication.ActiveDocument

        If TypeOf oInventorDocument IsNot AssemblyDocument Then Return '不是组件退出
        If oInventorDocument.SelectSet.Count = 0 Then Return '未选择零部件退出

        CommandBar.Controls.AddButton(m_复制组件_Buttondef, 5)

    End Sub

    Private Sub OnCLick()
        CopyComponent()
    End Sub
End Class
