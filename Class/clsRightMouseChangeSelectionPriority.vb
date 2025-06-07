Imports System.Windows.Forms
Imports Inventor

Public Class ClsRightMouseChangeSelectionPriority

    Private m_切换选择_Buttondef As ButtonDefinition

    Public Sub New()

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument


        Dim smallPicture As IPictureDisp

        'Try
        '    If oInventorAssemblyDocument.SelectionPriority = SelectionPriorityEnum.kPartSelectionPriority Then
        smallPicture = ClsPictureConverter.ImageToPictureDisp(My.Resources.选择实体16.ToBitmap)
        '    Else
        '        smallPicture = ClsPictureConverter.ImageToPictureDisp(My.Resources.选择实体16.ToBitmap)
        '    End If
        'Catch ex As Exception

        'End Try


        'smallPicture = ClsPictureConverter.ImageToPictureDisp(My.Resources.选择零部件16.ToBitmap)

        'largePicture = clsPictureConverter.ImageToPictureDisp(My.Resources.可见32.ToBitmap)

        Me.m_切换选择_Buttondef = ThisApplication.CommandManager.ControlDefinitions.AddButtonDefinition(
            "切换选择", "InName切换选择", CommandTypesEnum.kShapeEditCmdType,
            ClientID, "", , smallPicture, , ButtonDisplayEnum.kDisplayTextInLearningMode)

        AddHandler m_切换选择_Buttondef.OnExecute, AddressOf OnCLick
        AddHandler ThisApplication.CommandManager.UserInputEvents.OnContextMenu, AddressOf OnContextMenu
    End Sub

    Private Sub OnContextMenu(SelectionDevice As SelectionDeviceEnum, AdditionalInfo As NameValueMap, CommandBar As CommandBar)
        Dim oInventorDocument As Inventor.Document = ThisApplication.ActiveDocument

        If TypeOf oInventorDocument IsNot AssemblyDocument Then Return '不是组件退出
        If oInventorDocument.SelectSet.Count <> 0 Then Return '未选择零部件退出



        CommandBar.Controls.AddButton(m_切换选择_Buttondef, 2)

        'Dim intCount As Integer
        'intCount = CommandBar.Controls.Item("AssemblyHideAllRelationshipsCmd ").Index + 1
        ' MessageBox.Show(intCount)


        ' MessageBox.Show(CommandBar.Controls.Count)

        'For Each obutton As ButtonDefinition In CommandBar.Controls
        '     MessageBox.Show(obutton.InternalName.ToString)
        'Next

    End Sub

    Private Sub OnCLick()
        ChangeSelectionPriority()
    End Sub

    ''' <summary>
    ''' 切换部件的选择方式，在部件和零件之间切换
    ''' </summary>
    Public Sub ChangeSelectionPriority()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> DocumentTypeEnum.kAssemblyDocumentObject Then
                MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Return False
                Exit Sub
            End If

            Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
            oInventorAssemblyDocument = ThisApplication.ActiveDocument


            Dim smallPicture As IPictureDisp
            Dim strCommand As String = “切换选择”

            If oInventorAssemblyDocument.SelectionPriority = SelectionPriorityEnum.kComponentSelectionPriority Then
                oInventorAssemblyDocument.SelectionPriority = SelectionPriorityEnum.kPartSelectionPriority
                smallPicture = ClsPictureConverter.ImageToPictureDisp(My.Resources.选择零部件16.ToBitmap)
            Else
                oInventorAssemblyDocument.SelectionPriority = SelectionPriorityEnum.kComponentSelectionPriority
                smallPicture = ClsPictureConverter.ImageToPictureDisp(My.Resources.选择实体16.ToBitmap)
            End If

            m_切换选择_Buttondef.StandardIcon = smallPicture


        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class


