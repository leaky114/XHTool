Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.IO

Module StringsModel

    'Public HelpMessage As String = "窗口在左和上边缘自动隐藏      当前版本：" & Application.ProductVersion

    ''' <summary>
    ''' 获取字符的类型
    ''' </summary>
    ''' <param name="a">被获取的字符</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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
                    Case 215
                        Return "×"
                    Case Else
                        Return "Unicode字符"
                End Select
            Case Else
                Return "未知"
        End Select
    End Function


    ''' <summary>
    ''' 获取文件名和图号
    ''' </summary>
    ''' <param name="strFullFileName">文件名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetStockNumPartName(ByVal strFullFileName As String) As StockNumPartName
        Dim i As Integer
        Dim strChr As String
        Dim FileName As String

        FileName = GetFileNameInfo(strFullFileName).OnlyName

        If str去除后缀表 <> "" Then
            Dim strArray去除后缀表() As String = Strings.Split(str去除后缀表, ",")

            For Each str去除后缀 As String In strArray去除后缀表
                FileName = Strings.Replace(FileName, str去除后缀, "")
            Next
        End If

        Dim spaceIndex As Integer

        If char连接符 = “” Then
            ' 调用函数检测首先出现的字符类型
            Dim firstCharType As String = FindFirstCharacterType(FileName)
            Select Case firstCharType
                Case "汉字"


                Case " ", "-", "_"
                    '按空格分割文件名
                    spaceIndex = InStr(FileName, firstCharType)

                    If spaceIndex > 0 Then
                        GetStockNumPartName.IsGet = True
                        GetStockNumPartName.图号 = Strings.Trim(Left(FileName, spaceIndex - 1))
                        GetStockNumPartName.零件名称 = Strings.Trim(Mid(FileName, spaceIndex + 1))
                        GetStockNumPartName.ERP编码 = ""
                        GetStockNumPartName.价格 = ""

                        Return GetStockNumPartName
                    End If
            End Select
        Else
            '按空格分割文件名
            spaceIndex = InStr(FileName, char连接符)

            If spaceIndex > 0 Then
                GetStockNumPartName.IsGet = True
                GetStockNumPartName.图号 = Strings.Trim(Left(FileName, spaceIndex - 1))
                GetStockNumPartName.零件名称 = Strings.Trim(Mid(FileName, spaceIndex + 1))
                GetStockNumPartName.ERP编码 = ""
                GetStockNumPartName.价格 = ""

                Return GetStockNumPartName
            End If
        End If

        '按汉字分割文件名
        i = 1
        Do
            strChr = Mid(FileName, i, 1)
            i = i + 1
            If strChr = "" Then
                Exit Do
            End If
        Loop Until (CheckCharType(strChr) = "Unicode字符")

        '判断图号情况
        Select Case True       '第一个字符为汉字
            Case i = 2
                GetStockNumPartName.IsGet = False
                GetStockNumPartName.图号 = ""
                GetStockNumPartName.零件名称 = Strings.Trim(FileName)
                GetStockNumPartName.ERP编码 = ""
                GetStockNumPartName.价格 = ""
                ' MessageBox.Show(FullFileName & "  无图号！", MsgBoxStyle.Information)
            Case strChr = ""  '无汉字
                GetStockNumPartName.IsGet = False
                GetStockNumPartName.图号 = Strings.Trim(FileName)
                GetStockNumPartName.零件名称 = ""
                GetStockNumPartName.ERP编码 = ""
                GetStockNumPartName.价格 = ""
                ' MessageBox.Show(FullFileName & "  无零件名！", MsgBoxStyle.Information)
            Case Else       '正常情况
                GetStockNumPartName.IsGet = True
                GetStockNumPartName.图号 = Strings.Trim(Left(FileName, i - 2))
                GetStockNumPartName.零件名称 = Strings.Trim(Mid(FileName, i - 1, Len(FileName) - i + 2))
                GetStockNumPartName.ERP编码 = ""
                GetStockNumPartName.价格 = ""
        End Select

        Return GetStockNumPartName
    End Function

    ''' <summary>
    ''' 调用函数检测首先出现的字符类型
    ''' </summary>
    ''' <param name="input"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function FindFirstCharacterType(input As String) As String
        ' 遍历字符串中的每个字符
        For Each c As Char In input
            ' 检测字符是否为汉字
            If IsChineseCharacter(c) Then
                Return "汉字"
            End If

            ' 检测字符是否为空格
            If c = " "c Then
                Return " "
            End If

            ' 检测字符是否为 '-'
            If c = "_"c Then
                Return "_"
            End If
        Next

        '若找不到   汉字 空格  _  就找是否有  -
        For Each c As Char In input
            ' 检测字符是否为 '-'
            If c = "-"c Then
                Return "-"
            End If
        Next

        ' 如果没有找到任何符合条件的字符，返回提示信息
        Return "NULL"
    End Function


    ''' <summary>
    ''' 检测字符是否为汉字
    ''' </summary>
    ''' <param name="c"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function IsChineseCharacter(c As Char) As Boolean
        Dim codePoint As Integer = Convert.ToInt32(c)
        Return (codePoint >= &H4E00 AndAlso codePoint <= &H9FFF) OrElse
               (codePoint >= &H3400 AndAlso codePoint <= &H4DBF) OrElse
               (codePoint >= &H20000 AndAlso codePoint <= &H2A6DF) OrElse
               (codePoint >= &H2A700 AndAlso codePoint <= &H2B73F) OrElse
               (codePoint >= &H2B740 AndAlso codePoint <= &H2B81F) OrElse
               (codePoint >= &H2B820 AndAlso codePoint <= &H2CEAF) OrElse
               (codePoint >= &H2CEB0 AndAlso codePoint <= &H2EBEF) OrElse
               (codePoint >= &HF900 AndAlso codePoint <= &HFAFF) OrElse
               (codePoint >= &H2F800 AndAlso codePoint <= &H2FA1F)
    End Function

    ''' <summary>
    '''   ListView上移
    ''' </summary>
    ''' <param name="oListView">ListView对象</param>
    ''' <remarks></remarks>
    Public Sub ListViewUp(ByVal oListView As ListView)
        If oListView.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = oListView.SelectedItems(0)
            Dim selectedIndex As Integer = oListView.Items.IndexOf(selectedItem)

            If selectedIndex > 0 Then
                oListView.BeginUpdate()

                oListView.Items.RemoveAt(selectedIndex)
                oListView.Items.Insert(selectedIndex - 1, selectedItem)

                oListView.EndUpdate()

                oListView.Items(selectedIndex - 1).Selected = True


            End If
        End If

    End Sub

    ''' <summary>
    ''' ListView下移
    ''' </summary>
    ''' <param name="oListView">ListView对象</param>
    ''' <remarks></remarks>
    Public Sub ListViewDown(ByVal oListView As ListView)
        If oListView.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = oListView.SelectedItems(0)
            Dim selectedIndex As Integer = oListView.Items.IndexOf(selectedItem)

            If selectedIndex < oListView.Items.Count - 1 Then
                oListView.BeginUpdate()

                oListView.Items.RemoveAt(selectedIndex)
                oListView.Items.Insert(selectedIndex + 1, selectedItem)

                oListView.EndUpdate()

                oListView.Items(selectedIndex + 1).Selected = True


            End If
        End If

    End Sub

    ''' <summary>
    ''' Listbox上移
    ''' </summary>
    ''' <param name="oListBox">Listbox对象</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListBoxUp(ByVal oListBox As ListBox) As Boolean

        If oListBox.SelectedItems.Count > 0 Then
            Dim selectedIndex As Integer = oListBox.SelectedIndex

            If selectedIndex > 0 Then
                Dim selectedItem As Object = oListBox.SelectedItem
                oListBox.Items.RemoveAt(selectedIndex)
                oListBox.Items.Insert(selectedIndex - 1, selectedItem)
                oListBox.SetSelected(selectedIndex - 1, True)
            End If
        End If

    End Function


    ''' <summary>
    ''' Listbox下移
    ''' </summary>
    ''' <param name="oListBox">Listbox对象</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListBoxDown(ByVal oListBox As ListBox) As Boolean

        If oListBox.SelectedItems.Count > 0 Then
            Dim selectedIndex As Integer = oListBox.SelectedIndex

            If selectedIndex < oListBox.Items.Count - 1 Then
                Dim selectedItem As Object = oListBox.SelectedItem
                oListBox.Items.RemoveAt(selectedIndex)
                oListBox.Items.Insert(selectedIndex + 1, selectedItem)
                oListBox.SetSelected(selectedIndex + 1, True)
            End If
        End If

    End Function

    ''' <summary>
    ''' 使用TrimEnd方法去除字符串末尾的所有0
    ''' </summary>
    ''' <param name="str">被去0的字符串</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function RemoveTrailingZeros(ByVal str As String) As String
        Return str.TrimEnd("0"c)
    End Function



    ''' <summary>
    ''' 去除文件名中的非法字符
    ''' </summary>
    ''' <param name="strFullFileName">文件名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function RemoveInvalidFileNameChars(ByVal strFullFileName As String) As String
        ' 获取系统不支持的文件名字符
        Dim invalidChars As Char() = Path.GetInvalidFileNameChars()

        ' 移除不支持的字符
        For Each c As Char In invalidChars
            strFullFileName = strFullFileName.Replace(c, String.Empty)
        Next
        Return strFullFileName
    End Function
End Module