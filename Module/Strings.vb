Imports System.Text.RegularExpressions
Imports System.Windows.Forms

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
                    Case 215
                        Return "×"
                    Case Else
                        Return "Unicode字符"
                End Select
            Case Else
                Return "未知"
        End Select
    End Function

    '获取文件名和图号
    Public Function GetStockNumPartName(ByVal strFullFileName As String) As StockNumPartName
        Dim i As Integer
        Dim strChr As String
        Dim FileName As String

        FileName = GetFileNameInfo(strFullFileName).OnlyName
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
                GetStockNumPartName.StockNum = ""
                GetStockNumPartName.PartName = Strings.Trim(FileName)
                GetStockNumPartName.ERPCode = ""
                'MsgBox(FullFileName & "  无图号！", MsgBoxStyle.Information)
            Case strChr = ""  '无汉字
                GetStockNumPartName.IsGet = False
                GetStockNumPartName.StockNum = Strings.Trim(FileName)
                GetStockNumPartName.PartName = ""
                GetStockNumPartName.ERPCode = ""
                'MsgBox(FullFileName & "  无零件名！", MsgBoxStyle.Information)
            Case Else       '正常情况
                GetStockNumPartName.IsGet = True
                GetStockNumPartName.StockNum = Strings.Trim(Left(FileName, i - 2))
                GetStockNumPartName.PartName = Strings.Trim(Mid(FileName, i - 1, Len(FileName) - i + 2))
                GetStockNumPartName.ERPCode = ""
        End Select

    End Function

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

    'ListView上移
    Public Sub ListViewUp(ByVal oListView As ListView)
        If oListView.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = oListView.SelectedItems(0)
            Dim selectedIndex As Integer = oListView.Items.IndexOf(selectedItem)

            If selectedIndex > 0 Then
                oListView.Items.RemoveAt(selectedIndex)
                oListView.Items.Insert(selectedIndex - 1, selectedItem)
                oListView.Items(selectedIndex - 1).Selected = True
            End If
        End If

    End Sub

    'ListView下移
    Public Sub ListViewDown(ByVal oListView As ListView)
        If oListView.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = oListView.SelectedItems(0)
            Dim selectedIndex As Integer = oListView.Items.IndexOf(selectedItem)

            If selectedIndex < oListView.Items.Count - 1 Then
                oListView.Items.RemoveAt(selectedIndex)
                oListView.Items.Insert(selectedIndex + 1, selectedItem)
                oListView.Items(selectedIndex + 1).Selected = True
            End If
        End If

    End Sub

    'Listbox上移
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

    'Listbox下移
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
End Module