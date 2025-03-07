Imports Inventor

Public Class ClsRightMouseSelectPartInBrowser
    Private m_在浏览器中查找_Buttondef As ButtonDefinition

    Public Sub New()

        Dim smallPicture As IPictureDisp

        'Dim largePicture As stdole.IPictureDisp

        smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.在浏览器中查找16.ToBitmap)
        'largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.编辑尺寸32.ToBitmap)

        m_在浏览器中查找_Buttondef = ThisApplication.CommandManager.ControlDefinitions.AddButtonDefinition(
           "在浏览器中查找", "InNameRightMouse在浏览器中查找", CommandTypesEnum.kFileOperationsCmdType,
            ClientID, "", , smallPicture, , ButtonDisplayEnum.kDisplayTextInLearningMode)

        AddHandler m_在浏览器中查找_Buttondef.OnExecute, AddressOf OnCLick
        AddHandler ThisApplication.CommandManager.UserInputEvents.OnContextMenu, AddressOf OnContextMenu
    End Sub

    Private Sub OnContextMenu(SelectionDevice As SelectionDeviceEnum, AdditionalInfo As NameValueMap, CommandBar As CommandBar)
        Dim oInventorDocument As Inventor.Document = ThisApplication.ActiveDocument

        If TypeOf oInventorDocument IsNot DrawingDocument Then Return '不是工程图退出

        If TypeOf oInventorDocument.SelectSet.Item(1) IsNot DrawingCurveSegment Then Return '未选择图形线

        CommandBar.Controls.AddButton(m_在浏览器中查找_Buttondef, 5)

    End Sub

    Private Sub OnCLick()
        SelectPartNodeInBrowserNode()
    End Sub
End Class
