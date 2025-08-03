Imports System.Windows.Forms

Public Class FormManager
    ' 字典用于存储窗口类型及其对应的实例
    Private Shared ReadOnly _formInstances As New Generic.Dictionary(Of Type, Form)

    ' 私有构造函数防止实例化
    Private Sub New()
    End Sub

    ' 泛型方法，用于显示或激活指定类型的窗口实例
    ''' <summary>
    ''' 如果实例存在但被隐藏，则显示它
    ''' </summary>
    ''' <typeparam name="T">是否用showdialog，True为是，默认为False</typeparam>
    ''' <param name="IsDialog"></param>
    Public Shared Sub ShowForm(Of T As {New, Form})(Optional ByVal IsDialog As Integer = False)
        Dim formType As Type = GetType(T)


        Dim wrapper = New ClsWindowWrapper(ThisApplication.MainFrameHWND)

        ' 检查字典中是否存在该类型的实例
        If Not _formInstances.ContainsKey(formType) OrElse _formInstances(formType).IsDisposed Then
            ' 如果不存在或被销毁，则创建新实例并添加到字典中
            Dim newForm As New T()
            _formInstances(formType) = newForm
            AddHandler newForm.FormClosing, AddressOf Form_FormClosing

            'FormCloneComponent.Show(wrapper)

            If IsDialog = True Then
                newForm.ShowDialog(wrapper)
            Else
                newForm.Show(wrapper)
            End If


            newForm.WindowState = FormWindowState.Normal
            'newForm.KeyPreview = True

        Else
            ' 如果实例存在，检查它是否可见
            Dim existingForm As Form = _formInstances(formType)
            If Not existingForm.Visible Then
                ' 如果不可见，则显示它

                existingForm.Show(wrapper)
                existingForm.WindowState = FormWindowState.Normal
            End If
            ' 实例已经可见，不需要进一步操作
        End If
    End Sub

    ' 泛型方法，用于隐藏指定类型的窗口实例
    Public Shared Sub HideForm(Of T As Form)()
        Dim formType As Type = GetType(T)

        ' 检查字典中是否存在该类型的实例且未被销毁
        If _formInstances.ContainsKey(formType) AndAlso Not _formInstances(formType).IsDisposed Then
            ' 如果存在且未被销毁，则隐藏它
            _formInstances(formType).Hide()
        End If
    End Sub

    ' 处理窗体关闭事件，取消关闭并隐藏窗体
    ' 同时移除事件处理程序以避免内存泄漏
    Private Shared Sub Form_FormClosing(sender As Object, e As FormClosingEventArgs)
        ' 隐藏窗体而不是关闭它
        e.Cancel = True
        Dim form As Form = DirectCast(sender, Form)
        form.Hide()
        ' 移除事件处理程序
        RemoveHandler form.FormClosing, AddressOf Form_FormClosing
    End Sub

    ' 泛型方法，用于关闭并销毁指定类型的窗口实例
    Public Shared Sub CloseAndDisposeForm(Of T As Form)()
        On Error Resume Next
        Dim formType As Type = GetType(T)

        '' 检查字典中是否存在该类型的实例且未被销毁
        'If _formInstances.ContainsKey(formType) AndAlso Not _formInstances(formType).IsDisposed Then
        '    ' 如果存在且未被销毁，则关闭并销毁它
        Dim formToClose As Form = _formInstances(formType)
        ' 从字典中移除实例引用（可选，但推荐在销毁前做）
        _formInstances.Remove(formType)
        ' 关闭并释放窗体资源
        formToClose.Close()
        formToClose.Dispose() ' 通常Close方法会调用Dispose，但明确调用以确保资源释放
        'End If
    End Sub
End Class