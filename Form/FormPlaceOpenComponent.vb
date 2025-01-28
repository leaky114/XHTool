Imports System.ComponentModel
Imports System.Windows.Forms
Imports Inventor

Public Class FormPlaceOpenComponent

    Public strSelectFileFullName As String
    Private Sub FormPlaceOpenComponent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48
        Me.TopMost = True



        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        Dim strInventorAssemblyDocumentFullFileName As String
        oInventorAssemblyDocument = ThisApplication.ActiveDocument
        strInventorAssemblyDocumentFullFileName = oInventorAssemblyDocument.FullDocumentName

        Dim oInventorDocument As Inventor.Document

        For Each oInventorDocument In ThisApplication.Documents.VisibleDocuments
            If oInventorDocument.FullDocumentName <> strInventorAssemblyDocumentFullFileName Then
                ListBox零部件.Items.Add(GetFileNameWithExtension(oInventorDocument.FullFileName))
            End If
        Next

    End Sub

    Private Sub ListBox零部件_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox零部件.SelectedIndexChanged
        If ListBox零部件.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        Dim strFillName As String = ListBox零部件.SelectedItem.ToString()

        Dim oInventorDocument As Inventor.Document
        Dim strInventorDocumentFullFileName As String

        For Each oInventorDocument In ThisApplication.Documents.VisibleDocuments
            strInventorDocumentFullFileName = oInventorDocument.FullDocumentName
            If GetFileNameWithExtension(strInventorDocumentFullFileName) = strFillName Then
                strSelectFileFullName = strInventorDocumentFullFileName

                Dim img As System.Drawing.Image
                img = GetImageFromView(oInventorDocument)
                PictureBox缩略图.SizeMode = PictureBoxSizeMode.StretchImage
                PictureBox缩略图.Image = img

                Exit For
            End If
        Next

    End Sub

    Private Sub btn插入到部件_Click(sender As Object, e As EventArgs) Handles btn插入到部件.Click

        Me.TopMost = False

        If ThisApplication.ActiveDocumentType <> DocumentTypeEnum.kAssemblyDocumentObject Then
            Exit Sub
        End If

        If ThisApplication.ActiveDocument.FullDocumentName = strSelectFileFullName Then
            Exit Sub
        End If

        ThisApplication.CommandManager.PostPrivateEvent(PrivateEventTypeEnum.kFileNameEvent, strSelectFileFullName)
        ThisApplication.CommandManager.ControlDefinitions.Item("AssemblyPlaceComponentCmd").Execute()

        FormManager.CloseAndDisposeForm(Of FormPlaceOpenComponent)()

    End Sub

    Private Sub FormPlaceOpenComponent_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        FormManager.CloseAndDisposeForm(Of FormPlaceOpenComponent)()
    End Sub
End Class