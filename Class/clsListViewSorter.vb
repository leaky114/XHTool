Imports System.Windows.Forms

Public Class clsListViewSorter
    Implements System.Collections.IComparer

    Public Enum EnumSortOrder As Integer
        Ascending = 0
        Descending = 1
    End Enum

    Public SortOrder As EnumSortOrder
    Public SortColumn As Integer

    Public Sub New(ByVal SortColumn As Integer, ByVal SortOrder As EnumSortOrder)
        Me.SortColumn = SortColumn
        Me.SortOrder = SortOrder
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        On Error Resume Next

        Dim xString As String
        Dim YString As String
        ' Convert the two passed values to listview items
        Dim l1 As ListViewItem
        Dim l2 As ListViewItem

        l1 = CType(x, ListViewItem)
        l2 = CType(y, ListViewItem)

        ' Get the appropriate text values depending on whether we are being asked
        ' to sort on the first column (0) or subitem columns (>0)
        If SortColumn = 0 Then
            ' SortColumn is 0, we need to compare the
            ' Text property of the Item itself
            xString = l1.Text
            YString = l2.Text
        Else
            ' SortColumn is not 0, so we need to compare the Text
            ' property of the SubItem
            xString = l1.SubItems(SortColumn).ToString
            YString = l2.SubItems(SortColumn).ToString
        End If

        ' Do the comparison
        If xString = YString Then
            ' Values are equal
            Return 0
        ElseIf xString > YString Then
            ' X is greater than Y
            If SortOrder = EnumSortOrder.Ascending Then
                Return 1
            Else
                Return -1
            End If
        ElseIf xString < YString Then
            ' Y is greater than X
            If SortOrder = EnumSortOrder.Ascending Then
                Return -1
            Else
                Return 1
            End If
        End If
    End Function
End Class