Imports Inventor
Imports Microsoft.VisualBasic

Public Class frmTable

    Private Sub frmTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        Dim oThumbnail As IPictureDisp
        oThumbnail = oInventorDocument.Thumbnail

        PictureBox1.Image = PictureConverter.ImageToPictureDisp()

    End Sub
End Class