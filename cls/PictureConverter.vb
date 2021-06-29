
Friend Class PictureConverter
    Inherits System.Windows.Forms.AxHost

    Private Sub New()
        MyBase.New(String.Empty)
    End Sub

    Public Shared Function ImageToPictureDisp( _
                           ByVal image As System.Drawing.Image) As stdole.IPictureDisp
        Return CType(GetIPictureDispFromPicture(image), stdole.IPictureDisp)
    End Function
End Class
