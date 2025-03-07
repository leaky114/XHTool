Imports stdole

Friend Class ClsPictureConverter
    Inherits System.Windows.Forms.AxHost

    Private Sub New()
        MyBase.New(String.Empty)
    End Sub

    Public Shared Function ImageToPictureDisp(ByVal oimage As System.Drawing.Image) As IPictureDisp
        Return CType(GetIPictureDispFromPicture(oimage), IPictureDisp)
    End Function

    Public Shared Function PictureDispToImage(ByVal oIPictureDisp As IPictureDisp) As System.Drawing.Image
        Return CType(GetPictureFromIPicture(oIPictureDisp), System.Drawing.Image)
    End Function

End Class