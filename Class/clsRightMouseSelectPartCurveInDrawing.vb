Imports Inventor

Public Class ClsRightMouseSelectPartCurveInDrawing
    Private m_选择本零件_Buttondef As ButtonDefinition

    Public Sub New()

        Dim smallPicture As IPictureDisp
        Dim largePicture As IPictureDisp

        smallPicture = clsPictureConverter.ImageToPictureDisp(My.Resources.编辑尺寸16.ToBitmap)
        largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.编辑尺寸32.ToBitmap)

        m_选择本零件_Buttondef = ThisApplication.CommandManager.ControlDefinitions.AddButtonDefinition(
           "选择本零件", "InNameRightMouse选择本零件", CommandTypesEnum.kFileOperationsCmdType,
            ClientID, "", , , , ButtonDisplayEnum.kDisplayTextInLearningMode)

        AddHandler m_选择本零件_Buttondef.OnExecute, AddressOf OnCLick
        AddHandler ThisApplication.CommandManager.UserInputEvents.OnContextMenu, AddressOf OnContextMenu
    End Sub

    Private Sub OnContextMenu(SelectionDevice As SelectionDeviceEnum, AdditionalInfo As NameValueMap, CommandBar As CommandBar)
        Dim oInventorDocument As Inventor.Document = ThisApplication.ActiveDocument

        If TypeOf oInventorDocument IsNot DrawingDocument Then Return '不是工程图退出

        If TypeOf oInventorDocument.SelectSet.Item(1) IsNot DrawingCurveSegment Then Return '未选择图形线

        CommandBar.Controls.AddButton(m_选择本零件_Buttondef, 4)

    End Sub

    Private Sub OnCLick()
        SelectPartCurveInDrawing()
    End Sub
End Class
