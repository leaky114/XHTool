Imports System.Windows.Forms

Public Class ClsWindowWrapper
    Implements IWin32Window

    Private ReadOnly _hwnd As IntPtr

    Public Sub New(handle As IntPtr)
        _hwnd = handle
    End Sub

    Public ReadOnly Property Handle As IntPtr Implements IWin32Window.Handle
        Get
            Return _hwnd
        End Get
    End Property
End Class
