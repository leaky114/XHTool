Imports Inventor

Public Class clsRightMouse

    Private button_showall As ButtonDefinition
    Private ThisApplication As Inventor.Application

    Public Sub New(ThisApplication As Inventor.Application)
        Me.ThisApplication = ThisApplication
        Me.button_showall = ThisApplication.CommandManager.ControlDefinitions.AddButtonDefinition(
            "全部显示",
            "IneternalName_showall",
            CommandTypesEnum.kShapeEditCmdType)
        AddHandler button_showall.OnExecute, AddressOf OnCLick
        AddHandler ThisApplication.CommandManager.UserInputEvents.OnContextMenu, AddressOf OnContextMenu
    End Sub

    Private Sub OnContextMenu(SelectionDevice As SelectionDeviceEnum, AdditionalInfo As NameValueMap, CommandBar As CommandBar)
        If (ThisApplication.ActiveDocument.DocumentType <> DocumentTypeEnum.kAssemblyDocumentObject) Then Return
        If ThisApplication.ActiveDocument.SelectSet.Count <> 0 Then Return
        CommandBar.Controls.AddButton(button_showall, 2)
    End Sub

    Private Sub OnCLick()
        Dim oAssyDoc As AssemblyDocument
        oAssyDoc = ThisApplication.ActiveDocument

        Dim oAssyDef As AssemblyComponentDefinition
        oAssyDef = oAssyDoc.ComponentDefinition

        Dim oMgr As RepresentationsManager
        oMgr = oAssyDef.RepresentationsManager

        Dim oViewRep As DesignViewRepresentation
        oViewRep = oMgr.ActiveDesignViewRepresentation
        oViewRep.ShowAll()
    End Sub
End Class


