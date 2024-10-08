﻿Module Calc
    '四则运算
    Public Function CalcStr(ByVal StrNum As String) As Double
        On Error Resume Next
        Dim MSSC = CreateObject("MSScriptControl.ScriptControl")
        MSSC.Language = "VBScript"
        CalcStr = MSSC.Eval(StrNum)
        MSSC = Nothing
    End Function

    '替换表达式
    'Public Function ReplaceFunction(ByVal Row As String, ByVal SldDrwFile As SLDDRW_File) As String
    '    Dim S As String
    '    Dim T As String
    '    Dim i As Short
    '    Dim j As Short
    '    Do
    '        i = InStr(Row, "#")
    '        T = Mid(Row, i + 1)
    '        j = InStr(T, "#")
    '        S = Mid(Row, i + 1, j - 1)
    '        Row = Strings.Replace(Row, "#" & S & "#", SearchInCsv(SldDrwFile, S))
    '    Loop Until (InStr(Row, "#") = 0)

    '    ReplaceFunction = Row
    'End Function


    '将布尔值转换为整数
    Public Function BoolToInt(ByVal boolValue As Boolean) As Integer
        if boolValue Then
            Return 1
        Else
            Return 0
        End if
    End Function

    '将整数转换为布尔值
    Public Function IntToBool(ByVal intValue As Integer) As Boolean
        if intValue = 0 Then
            Return False
        Elseif intValue = 1 Then
            Return True
        Else
            Throw New ArgumentException("输出参数需为 0 或 1")
        End if
    End Function

    '四舍五入
    Public Function FourFive(number As Double, decimalPlaces As Integer) As Double
        ' 使用Round函数进行四舍五入
        FourFive = Math.Round(number, decimalPlaces)
    End Function

End Module
