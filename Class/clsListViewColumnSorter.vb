Imports System.Windows.Forms

Public Class ListViewColumnSorter
    Implements IComparer

    Private ReadOnly _columnIndex As Integer
    Private ReadOnly _sortOrder As SortOrder

    Public Sub New(columnIndex As Integer, sortOrder As SortOrder)
        _columnIndex = columnIndex
        _sortOrder = sortOrder
    End Sub

    Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
        Dim itemX = CType(x, ListViewItem)
        Dim itemY = CType(y, ListViewItem)

        ' 获取要比较的文本
        Dim textX = If(itemX.SubItems.Count > _columnIndex, itemX.SubItems(_columnIndex).Text, "")
        Dim textY = If(itemY.SubItems.Count > _columnIndex, itemY.SubItems(_columnIndex).Text, "")

        ' 尝试数值比较
        Dim result As Integer
        If Double.TryParse(textX, Nothing) AndAlso Double.TryParse(textY, Nothing) Then
            Dim numX = Double.Parse(textX)
            Dim numY = Double.Parse(textY)
            result = numX.CompareTo(numY)
        Else ' 文本比较
            result = String.Compare(textX, textY, StringComparison.CurrentCultureIgnoreCase)
        End If

        ' 应用排序方向
        Return If(_sortOrder = SortOrder.Ascending, result, -result)
    End Function
End Class
