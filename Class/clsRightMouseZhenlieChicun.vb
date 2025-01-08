Imports Inventor

Public Class clsRightMouseZhenlieChicun
    Private m_阵列尺寸_Buttondef As ButtonDefinition

    Public Sub New()

        Dim smallPicture As IPictureDisp
        Dim largePicture As IPictureDisp

        smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.编辑尺寸16.ToBitmap)
        largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.编辑尺寸32.ToBitmap)

        m_阵列尺寸_Buttondef = ThisApplication.CommandManager.ControlDefinitions.AddButtonDefinition(
           "数量×尺寸", "InNameRightMouse阵列尺寸", CommandTypesEnum.kFileOperationsCmdType, _
            ClientID, "", , smallPicture, , ButtonDisplayEnum.kDisplayTextInLearningMode)

        AddHandler m_阵列尺寸_Buttondef.OnExecute, AddressOf OnCLick
        AddHandler ThisApplication.CommandManager.UserInputEvents.OnContextMenu, AddressOf OnContextMenu
    End Sub

    Private Sub OnContextMenu(SelectionDevice As SelectionDeviceEnum, AdditionalInfo As NameValueMap, CommandBar As CommandBar)
        Dim oInventorDocument As Inventor.Document = ThisApplication.ActiveDocument

        If Not TypeOf oInventorDocument Is DrawingDocument Then Return '不是组件退出

        If Not TypeOf oInventorDocument.SelectSet.Item(1) Is DrawingDimension Then Return '未选择尺寸退出

        CommandBar.Controls.AddButton(m_阵列尺寸_Buttondef, 9)

    End Sub

    Private Sub OnCLick()
        AddArrayDimension()
    End Sub

    
End Class
