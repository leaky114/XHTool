Module Calc
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


End Module
