Imports Inventor
Imports Inventor.DocumentTypeEnum
Imports Inventor.SelectionFilterEnum
Imports Inventor.SelectTypeEnum
Imports Inventor.ObjectTypeEnum

Imports System.Windows.Forms

Public Class frmPlayer

    Private IsAddNew As Boolean

    '添加
    Private Sub btn添加_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn添加.Click
        'Try
        SetStatusBarText()

        if IsInventorOpenDocument() = False Then
            Exit Sub
        End if

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        if oInventorDocument.DocumentType <> kAssemblyDocumentObject Then
            MsgBox("该功能仅适用于部件", MsgBoxStyle.Information)
            Exit Sub
        End if

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument

        oInventorAssemblyDocument = oInventorDocument


        Dim oselect As Object
        Dim oAssemblyConstraint As AssemblyConstraint = Nothing

        if oInventorAssemblyDocument.SelectSet.Count <> 0 Then
            'For Each oSelect As Object In InventorDoc.SelectSet
            oselect = oInventorAssemblyDocument.SelectSet(1)
            Select Case oselect.type
                Case kAngleConstraintObject, kAssemblySymmetryConstraintObject, kCompositeConstraintObject, kCustomConstraintObject, _
                    kFlushConstraintObject, kInsertConstraintObject, kMateConstraintObject, kTangentConstraintObject, kTransitionalConstraintObject
                    oAssemblyConstraint = oselect
                Case Else
                    MsgBox("选择一个约束。")
                    Exit Sub
            End Select
        Else
            MsgBox("选择一个约束。")
            Exit Sub
        End if


        if oAssemblyConstraint Is Nothing Then       '取消选择
            Exit Sub
        End if

        btn选择约束.Text = oAssemblyConstraint.Name
        txt开始.Text = oAssemblyConstraint.DriveSettings.StartValue
        txt结束.Text = oAssemblyConstraint.DriveSettings.EndValue
        txt步长.Text = oAssemblyConstraint.DriveSettings.FrameRate
        txt延时.Text = oAssemblyConstraint.DriveSettings.PauseDelay

        IsAddNew = True

    End Sub

    '移出
    Private Sub btn移出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn移出.Click
        ListViewDel(lvw文件列表)

    End Sub

    '退出
    Private Sub btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click
        lvw文件列表.Items.Clear()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    '清空
    Private Sub btn清空_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn清空.Click
        lvw文件列表.Items.Clear()

    End Sub


    Private Sub btn预览_Click(sender As Object, e As EventArgs) Handles btn预览.Click
        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument

        'Dim lvItem As ListViewItem
        'lvItem = lvw文件列表.SelectedItems(0)

        'if lvItem Is Nothing Then
        '    Exit Sub
        'End if

        Dim oAssemblyConstraint As AssemblyConstraint
        For Each oAssemblyConstraint In oInventorAssemblyDocument.ComponentDefinition.Constraints
            if oAssemblyConstraint.Name = btn选择约束.Text Then

                With oAssemblyConstraint.DriveSettings
                    .StartValue = txt开始.Text.ToString
                    .EndValue = txt结束.Text.ToString
                    .PauseDelay = txt延时.Text.ToString
                    .GoToStart()
                    .PlayForward()
                    .PlayReverse()
                End With

                Exit Sub
            End if

        Next

    End Sub

    Private Sub btn应用_Click(sender As Object, e As EventArgs) Handles btn应用.Click
        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument


        Dim oAssemblyConstraint As AssemblyConstraint

        For Each lvItem As ListViewItem In lvw文件列表.Items

            For Each oAssemblyConstraint In oInventorAssemblyDocument.ComponentDefinition.Constraints

                if oAssemblyConstraint.Name = lvItem.Text Then

                    if lvItem.SubItems(1).Text = True Then
                        oAssemblyConstraint.Suppressed = True
                    Else
                        With oAssemblyConstraint.DriveSettings
                            .StartValue = txt开始.Text.ToString
                            .EndValue = txt结束.Text.ToString
                            .PauseDelay = txt延时.Text.ToString
                            .GoToStart()
                            .PlayForward()
                            .PlayReverse()
                        End With
                    End if
                End if
            Next

        Next
    End Sub

    Private Sub btn确定编辑_Click(sender As Object, e As EventArgs) Handles btn确定编辑.Click
        Dim oListViewItem As ListViewItem

        if IsAddNew = True Then
            oListViewItem = lvw文件列表.Items.Add(btn选择约束.Text)
            With oListViewItem
                .SubItems.Add(CheckBox抑制.Checked)
                .SubItems.Add(txt开始.Text)
                .SubItems.Add(txt结束.Text)
                .SubItems.Add(txt步长.Text)
                .SubItems.Add(txt延时.Text)
            End With
            IsAddNew = False
        Else
            oListViewItem = lvw文件列表.SelectedItems(0)
            With oListViewItem
                .Text = btn选择约束.Text
                .SubItems(0).Text = CheckBox抑制.Checked
                .SubItems(1).Text = txt开始.Text
                .SubItems(2).Text = txt结束.Text
                .SubItems(3).Text = txt步长.Text
                .SubItems(4).Text = txt延时.Text

            End With

        End if
    End Sub

    Private Sub btn选择约束_Click(sender As Object, e As EventArgs) Handles btn选择约束.Click
        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument

        Dim oselect As Object
        Dim oAssemblyConstraint As AssemblyConstraint = Nothing

        if oInventorAssemblyDocument.SelectSet.Count <> 0 Then
            'For Each oSelect As Object In InventorDoc.SelectSet
            oselect = oInventorAssemblyDocument.SelectSet(1)
            Select Case oselect.type
                Case kAngleConstraintObject, kAssemblySymmetryConstraintObject, kCompositeConstraintObject, kCustomConstraintObject, _
                    kFlushConstraintObject, kInsertConstraintObject, kMateConstraintObject, kTangentConstraintObject, kTransitionalConstraintObject
                    oAssemblyConstraint = oselect
                Case Else
                    MsgBox("选择一个约束。")
                    Exit Sub
            End Select
        Else
            MsgBox("选择一个约束。")
            Exit Sub
        End if

        'if oAssemblyConstraint Is Nothing Then       '取消选择
        '    Exit Sub
        'End if

        btn选择约束.Text = oAssemblyConstraint.Name

        'Dim oComponentOccurrence As ComponentOccurrence   '选择的部件或零件

        'if oInventorAssemblyDocument.SelectSet.Count <> 0 Then
        '    'For Each oSelect As Object In InventorDoc.SelectSet
        '    oComponentOccurrence = oInventorAssemblyDocument.SelectSet(1)
        '    'Next
        'Else
        '    oComponentOccurrence = ThisApplication.CommandManager.Pick(kMateConstraintObject, "选择零件或部件")

        'End if

        'if oComponentOccurrence Is Nothing Then       '取消选择
        '    Exit Sub
        'End if

        'Dim oAssemblyConstraintsEnumerator As AssemblyConstraintsEnumerator
        'oAssemblyConstraintsEnumerator = oComponentOccurrence.Constraints

        'ComboBox约束列表.Items.Clear()

        'For Each oAssemblyConstraint As AssemblyConstraint In oAssemblyConstraintsEnumerator
        '    ComboBox约束列表.Items.Add(oAssemblyConstraint.Name)
        'Next

        'For Each constrt As Object In oInventorAssemblyDocument.SelectSet
        '    Select Case constrt.type
        '        Case kAngleConstraintObject, kAssemblySymmetryConstraintObject, kCompositeConstraintObject, kCustomConstraintObject, _
        '            kFlushConstraintObject, kInsertConstraintObject, kMateConstraintObject, kTangentConstraintObject, kTransitionalConstraintObject

        '            Dim oAssemblyConstraint As AssemblyConstraint
        '            oAssemblyConstraint = constrt

        '            btn选择约束.Text = oAssemblyConstraint.Name
        '            'txt开始.Text = oAssemblyConstraint.DriveSettings.StartValue
        '            'txt结束.Text = oAssemblyConstraint.DriveSettings.EndValue
        '            'txt步长.Text = oAssemblyConstraint.DriveSettings.FrameRate
        '        Case Else
        '            MsgBox("请选择一个约束。")
        '    End Select
        'Next

    End Sub

    Private Sub lvw文件列表_Click(sender As Object, e As EventArgs) Handles lvw文件列表.Click
        Dim oListViewItem As ListViewItem

        oListViewItem = lvw文件列表.SelectedItems(0)
        With oListViewItem
            btn选择约束.Text = .Text

            Select Case .SubItems(1).Text
                Case "True"
                    CheckBox抑制.Checked = True
                Case "False"
                    CheckBox抑制.Checked = False
            End Select
            txt开始.Text = .SubItems(2).Text
            txt结束.Text = .SubItems(3).Text
            txt步长.Text = .SubItems(4).Text
            txt延时.Text = .SubItems(5).Text
        End With



    End Sub
End Class