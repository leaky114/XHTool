Imports System.Text.RegularExpressions

Module StringsModel

    'Public HelpMessage As String = "窗口在左和上边缘自动隐藏      当前版本：" & Application.ProductVersion

    '获取字符的类型
    Public Function CheckCharType(ByVal a As Object) As String
        Select Case TypeName(a)
            Case "Integer", "Byte", "Long"
                Return "整数"
            Case "Double", "Single"
                Return "小数"
            Case "String"
                Select Case AscW(Left(a, 1))
                    Case 65 To 90
                        Return "大写字母"
                    Case 97 To 122
                        Return "小写字母"
                    Case 48 To 57
                        Return "数字字符"
                    Case 32 To 126 '如果a是字母则不会执行此判断
                        Return "其它非字母汉字字符"
                    Case 0 To 31, 127
                        Return "控制字符"
                    Case Else
                        Return "Unicode字符"
                End Select
            Case Else
                Return "未知"
        End Select
    End Function

    '获取文件名和图号
    Public Function GetStockNumPartName(ByVal FullFileName As String) As StockNumPartName
        Dim i As Integer
        Dim s As String
        Dim FileName As String

        FileName = GetFileNameInfo(FullFileName).ONlyName
        i = 1
        Do
            s = Mid(FileName, i, 1)
            i = i + 1
            If s = "" Then
                Exit Do
            End If
        Loop Until (CheckCharType(s) = "Unicode字符")

        '判断图号情况
        Select Case True       '第一个字符为汉字
            Case i = 2
                GetStockNumPartName.IsGet = False
                GetStockNumPartName.StockNum = ""
                GetStockNumPartName.PartName = FileName
                GetStockNumPartName.PartNum = ""
                'MsgBox(FullFileName & "  无图号！", MsgBoxStyle.Information)
            Case s = ""  '无汉字
                GetStockNumPartName.IsGet = False
                GetStockNumPartName.StockNum = FileName
                GetStockNumPartName.PartName = ""
                GetStockNumPartName.PartNum = ""
                'MsgBox(FullFileName & "  无零件名！", MsgBoxStyle.Information)
            Case Else       '正常情况
                GetStockNumPartName.IsGet = True
                GetStockNumPartName.StockNum = Left(FileName, i - 2)
                GetStockNumPartName.PartName = Mid(FileName, i - 1, Len(FileName) - i + 2)
                GetStockNumPartName.PartNum = ""
        End Select
    End Function

    'Public Function GetNumbers(ByVal str As String) As String
    '    Return Regex.Replace(str, "[a-z]", "", RegexOptions.IgnoreCase).Trim()

    'End Function

    Public Function GetNumbers(ByVal strp As String) As String
        Dim strReturn As String = String.Empty
        If strp Is Nothing OrElse strp.Trim() = "" Then
            strReturn = ""
        End If
        For Each chrTemp As Char In strp
            If [Char].IsNumber(chrTemp) Then
                strReturn += chrTemp.ToString()
            End If
        Next
        Return strReturn
    End Function

End Module