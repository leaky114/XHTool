Imports Inventor

Public Class ClsRightMouseSetDrawingSize
    Private SizeA0, SizeA1, SizeA2, SizeA3, SizeA4 As ButtonDefinition
    Private CommandBarSheetSize As CommandBar

    Public Sub New()
        'If SharedVariable.Exists("Drawingsize") Then Return
        'SharedVariable("Drawingsize") = 1

        'If ThisApplication.UserInterfaceManager.CommandBars("InName图纸尺寸") Is Nothing Then
        Me.CommandBarSheetSize = ThisApplication.UserInterfaceManager.CommandBars.Add("图纸尺寸", "InName图纸尺寸", CommandBarTypeEnum.kPopUpCommandBar)

        'Else
        '    Me.CommandBarSheetSize = ThisApplication.UserInterfaceManager.CommandBars("InName图纸尺寸")
        'End If


        Dim oControls = ThisApplication.CommandManager.ControlDefinitions
        SizeA0 = oControls.AddButtonDefinition("A0", "ChangeSheetSizeA0Cmd", CommandTypesEnum.kShapeEditCmdType)
        SizeA1 = oControls.AddButtonDefinition("A1", "ChangeSheetSizeA1Cmd", CommandTypesEnum.kShapeEditCmdType)
        SizeA2 = oControls.AddButtonDefinition("A2", "ChangeSheetSizeA2Cmd", CommandTypesEnum.kShapeEditCmdType)
        SizeA3 = oControls.AddButtonDefinition("A3", "ChangeSheetSizeA3Cmd", CommandTypesEnum.kShapeEditCmdType)
        SizeA4 = oControls.AddButtonDefinition("A4", "ChangeSheetSizeA4Cmd", CommandTypesEnum.kShapeEditCmdType)
        CommandBarSheetSize.Controls.AddButton(SizeA0)
        CommandBarSheetSize.Controls.AddButton(SizeA1)
        CommandBarSheetSize.Controls.AddButton(SizeA2)
        CommandBarSheetSize.Controls.AddButton(SizeA3)
        CommandBarSheetSize.Controls.AddButton(SizeA4)

        AddHandler SizeA0.OnExecute, AddressOf OnCLickA0
        AddHandler SizeA1.OnExecute, AddressOf OnCLickA1
        AddHandler SizeA2.OnExecute, AddressOf OnCLickA2
        AddHandler SizeA3.OnExecute, AddressOf OnCLickA3
        AddHandler SizeA4.OnExecute, AddressOf OnCLickA4
        AddHandler ThisApplication.CommandManager.UserInputEvents.OnContextMenu, AddressOf OnContextMenu
    End Sub

    Private Sub OnContextMenu(SelectionDevice As SelectionDeviceEnum, AdditionalInfo As NameValueMap, CommandBar As CommandBar)
        Dim oInventorDocument As Inventor.Document = ThisApplication.ActiveDocument
        If TypeOf oInventorDocument IsNot DrawingDocument Then Return
        If oInventorDocument.SelectSet.Count <> 1 Then Return
        If oInventorDocument.SelectSet(1) IsNot oInventorDocument.ActiveSheet Then Return
        CommandBar.Controls.AddPopup(CommandBarSheetSize, 3)
    End Sub

    Private Sub OnCLickA0()
        SetDrawingSize(DrawingSheetSizeEnum.kA0DrawingSheetSize)
    End Sub

    Private Sub OnCLickA1()
        SetDrawingSize(DrawingSheetSizeEnum.kA1DrawingSheetSize)
    End Sub

    Private Sub OnCLickA2()
        SetDrawingSize(DrawingSheetSizeEnum.kA2DrawingSheetSize)
    End Sub

    Private Sub OnCLickA3()
        SetDrawingSize(DrawingSheetSizeEnum.kA3DrawingSheetSize)
    End Sub

    Private Sub OnCLickA4()
        SetDrawingSize(DrawingSheetSizeEnum.kA4DrawingSheetSize)
    End Sub

End Class
