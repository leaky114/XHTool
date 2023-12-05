Option Strict Off
Option Explicit On
Module ini

    Public IniFile As String


    '//声明从INI配置文件中获取类型为Int的配置项的值的系统函数
    Public Declare Function GetPrivateProfileInt Lib "kernel32" Alias "GetPrivateProfileIntA" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal nDefault As Integer, ByVal lpFileName As String) As Integer

    '//声明从INI配置文件中获取类型为string的配置项的值的系统函数
    Public Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer

    '//声明向INI配置文件中写入类型为string的配置项的值的系统函数

    Public Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer

    '//从INI配置文件中获取类型为Int的配置项的值
    Public Function GetIntFromINI(ByVal sectionName As String, ByVal keyName As String, ByVal defaultValue As Integer, ByVal iniPath As String) As Integer

        GetIntFromINI = GetPrivateProfileInt(sectionName, keyName, defaultValue, iniPath)
    End Function

    '//删除节点
    Public Sub EraseSection(ByVal Section As String, ByVal FileName As String)
        WritePrivateProfileString(Section, Nothing, Nothing, FileName)
    End Sub

    '//从INI配置文件中获取类型为string的配置项的值
    Public Function GetStrFromINI(ByVal sectionName As String, ByVal keyName As String, ByVal defaultValue As String, ByVal iniPath As String) As String
        Dim buffer As String

        Dim rc As Integer
        buffer = Space(256)
        rc = GetPrivateProfileString(sectionName, keyName, defaultValue, buffer, buffer.Length, iniPath)
        GetStrFromINI = Left(buffer, InStr(buffer, vbNullChar) - 1)
    End Function

    '//向INI配置文件中写入类型为string的配置项的值
    Public Function WriteStrINI(ByVal sectionName As String, ByVal keyName As String, ByVal setValue As String, ByVal iniPath As String) As Integer
        Dim rc As Integer
        rc = WritePrivateProfileString(sectionName, keyName, setValue, iniPath)
        If rc Then
            rc = 1
        End If
        WriteStrINI = rc
    End Function

End Module