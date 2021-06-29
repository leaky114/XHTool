Module WindowsClass
    Public Declare Function SetWindowText Lib "user32" Alias "SetWindowTextA" (ByVal hwnd As Short, ByVal lpString As String) As Short
    Public Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Short
    Public Declare Function FindWindowEx Lib "user32" Alias "FindWindowExA" (ByVal hwnd1 As Short, ByVal hWnd2 As Short, ByVal lpsz1 As String, ByVal lpsz2 As String) As Short
    Public Declare Function SendMessage Lib "user32.dll" Alias "SendMessageA" (ByVal hWnd As Short, ByVal wMsg As Short, ByVal wParam As Short, ByVal lParam As Short) As Short
    Public Declare Function PostMessage Lib "user32" Alias "PostMessageA" (ByVal hwnd As Long, ByVal wMsg As Long, ByVal wParam As Long, ByVal lParam As Long) As Long

    Public Const WM_KEYDOWN = &H100
    Public Const WM_KEYUP = &H101
    Public Const WM_SYSKEYDOWN = &H104
    Public Const WM_SYSKEYUP = &H105


End Module
