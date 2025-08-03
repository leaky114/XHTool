Imports Inventor


Public Class ClsRightMouseOpenParentAssembly
    Private m_打开父部件_Buttondef As ButtonDefinition

    Public Sub New()

        Dim smallPicture As IPictureDisp

        'Dim largePicture As stdole.IPictureDisp
        smallPicture = ClsPictureConverter.ImageToPictureDisp(My.Resources.打开父部件16.ToBitmap)
        'largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.打开父部件32.ToBitmap)

        Me.m_打开父部件_Buttondef = ThisApplication.CommandManager.ControlDefinitions.AddButtonDefinition(
            "打开父部件", "InName打开父部件", CommandTypesEnum.kShapeEditCmdType,
            ClientID, "", , smallPicture, , ButtonDisplayEnum.kDisplayTextInLearningMode)

        AddHandler m_打开父部件_Buttondef.OnExecute, AddressOf OnCLick
        AddHandler ThisApplication.CommandManager.UserInputEvents.OnContextMenu, AddressOf OnContextMenu
    End Sub

    Private Sub OnContextMenu(SelectionDevice As SelectionDeviceEnum, AdditionalInfo As NameValueMap, CommandBar As CommandBar)
        If (ThisApplication.ActiveDocument.DocumentType <> DocumentTypeEnum.kAssemblyDocumentObject) Then Return
        If ThisApplication.ActiveDocument.SelectSet.Count <> 0 Then Return

        CommandBar.Controls.AddButton(m_打开父部件_Buttondef, 15)

        'Dim intCount As Integer
        'intCount = CommandBar.Controls.Item("AssemblyHideAllRelationshipsCmd ").Index + 1
        ' MessageBox.Show(intCount)

        ' MessageBox.Show(CommandBar.Controls.Count)

        'For Each obutton As ButtonDefinition In CommandBar.Controls
        '     MessageBox.Show(obutton.InternalName.ToString)
        'Next

    End Sub

    Private Sub OnCLick()
        OpenParentAssembly()
    End Sub
End Class
