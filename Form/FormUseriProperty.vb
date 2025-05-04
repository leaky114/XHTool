Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Public Class FormUseriProperty


    ' 创建TextBox数组
    Private textBoxes() As TextBox

    ' 创建ComboBox数组
    Private comboBoxes() As ComboBox

    Private Sub Btn确定_Click(sender As Object, e As EventArgs) Handles btn确定.Click
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        For i = 0 To Me.textBoxes.Length - 1
            If Me.textBoxes(i).Text = "" Then

            Else
                SetUserPropitem(oInventorDocument, Me.textBoxes(i).Text, Me.comboBoxes(i).Text)
            End If
        Next

        FormManager.CloseAndDisposeForm(Of FormUseriProperty)()
    End Sub

    Private Sub Btn关闭_Click(sender As Object, e As EventArgs) Handles btn关闭.Click, Me.Closing
        FormManager.CloseAndDisposeForm(Of FormUseriProperty)()
    End Sub

    Private Sub 重新读取_Click(sender As Object, e As EventArgs) Handles 重新读取.Click
        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        For intControl = 0 To Me.textBoxes.Length - 1
            Me.comboBoxes(intControl).Text = GetUserPropitem(oInventorDocument, Me.textBoxes(intControl).Text)
        Next

    End Sub

    Private Sub FormUseriProperty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48
        Me.TopMost = True

        Dim toolTip As New ToolTip With {
            .AutoPopDelay = 0,
            .InitialDelay = 0,
            .ReshowDelay = 500
        }
        toolTip.SetToolTip(btn配置文件, "打开配置文件 UseriProperty.ini 。")

        btn配置文件.Image = My.Resources.文件txt16.ToBitmap

        LoadiPropertyData()

    End Sub


    ''' <summary>
    ''' 提取 {} 之前的字符串
    ''' </summary>
    ''' <param name="input"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ExtractPrefix(input As String) As String
        Dim startIndex As Integer = input.IndexOf("{")
        If startIndex <> -1 Then
            Return input.Substring(0, startIndex).Trim()
        Else
            Return input.Trim()
        End If
    End Function


    ''' <summary>
    ''' 提取 {} 里面的字符串并按逗号分割成数组
    ''' </summary>
    ''' <param name="input"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ExtractItems(input As String) As String()
        Dim startIndex As Integer = input.IndexOf("{")
        Dim endIndex As Integer = input.IndexOf("}")
        If startIndex <> -1 AndAlso endIndex <> -1 Then
            Dim itemsString As String = input.Substring(startIndex + 1, endIndex - startIndex - 1)
            Return itemsString.Split(New Char() {","}, StringSplitOptions.RemoveEmptyEntries).Select(Function(s) s.Trim()).ToArray()
        Else
            Return New String() {}
        End If
    End Function

    ''' <summary>
    ''' 加载自定义数据
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadiPropertyData()
        Dim strUseriPropertyIniFile As String
        strUseriPropertyIniFile = IO.Path.Combine(My.Application.Info.DirectoryPath, "UseriProperty.ini")

        If IsFileExists(strUseriPropertyIniFile) = False Then
            MessageBox.Show("无配置文件,请手动配置！", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning)

            Using oStreamWriter As New StreamWriter(strUseriPropertyIniFile, False, Encoding.Default)
                oStreamWriter.WriteLine("#不要修改#号行。")
                oStreamWriter.WriteLine("#数据结构为  自定义=自定义iproperty名称{列表数据}，若无列表数组则不设置{}内列表数据。")
                oStreamWriter.WriteLine("#自定义=输入数量{1,2,3,4,5,6,7,8,9,10}")
                oStreamWriter.WriteLine("数量=0")
            End Using

            Exit Sub
        End If

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        Dim intFreeFile As Integer
        intFreeFile = FreeFile()

        Dim strLine As String

        Dim strNewTitleBlockName As String = Nothing
        Dim strOldTitleBlockName As String = Nothing

        Using oStreamReader As New System.IO.StreamReader(strUseriPropertyIniFile, Encoding.Default)
            ' 定义控件的数量
            Dim intControlCount As Integer
            '当前控件指针
            Dim intControl As Integer = 0

            While oStreamReader.Peek() >= 0
                strLine = oStreamReader.ReadLine()

                '跳过注释
                If strLine.StartsWith("#") Then
                    Continue While
                End If

                '获取自定义数量
                If strLine.StartsWith("数量=") Then
                    Integer.TryParse(strLine.Replace("数量=", ""), intControlCount)
                    If intControlCount = 0 Then
                        Exit Sub
                    Else
                        Continue While
                    End If
                End If

                If textBoxes Is Nothing Then
                    CreateControls(intControlCount)
                End If

                '获取自定义数据
                If strLine.StartsWith("自定义=") Then
                    Dim InputString As String = strLine.Replace("自定义=", "")

                    ' 提取 {} 之前的字符串
                    Dim striPropertyName As String = ExtractPrefix(InputString)

                    ' 提取 {} 里面的字符串并按逗号分割成数组
                    Dim striPropertyVales As String() = ExtractItems(InputString)

                    Me.textBoxes(intControl).Text = striPropertyName

                    For Each striPropertyVale As String In striPropertyVales
                        Me.comboBoxes(intControl).Items.Add(striPropertyVale)
                    Next

                    Me.comboBoxes(intControl).Text = GetUserPropitem(oInventorDocument, Me.textBoxes(intControl).Text)

                    intControl += 1

                    If intControl = intControlCount Then
                        Exit While
                    End If

                    Continue While
                End If
            End While
        End Using
    End Sub


    ''' <summary>
    ''' 创建textbox 和 combox 数组
    ''' </summary>
    ''' <param name="controlCount">数组数量</param>
    ''' <remarks></remarks>
    Private Sub CreateControls(ByVal controlCount As Integer)

        ' 设置初始位置
        Dim leftMarginTextBox As Integer = 12
        Dim leftMarginComboBox As Integer = 132
        Dim topMargin As Integer = 16
        Dim widthTextBox As Integer = 110
        Dim widthComboBox As Integer = 160
        Dim height As Integer = 20
        Dim verticalSpacing As Integer = 10  ' 垂直间距

        ' 创建TextBox数组
        ReDim textBoxes(controlCount - 1)

        ' 创建ComboBox数组
        ReDim comboBoxes(controlCount - 1)


        ' 循环创建TextBox和ComboBox
        For i As Integer = 0 To controlCount - 1
            ' 创建TextBox
            textBoxes(i) = New TextBox()
            With textBoxes(i)
                .Left = leftMarginTextBox
                .Top = topMargin + (i * (height + verticalSpacing))
                .Width = widthTextBox
                .Height = height
            End With
            Me.Controls.Add(textBoxes(i))

            ' 创建ComboBox
            comboBoxes(i) = New ComboBox()
            With comboBoxes(i)
                .Left = leftMarginComboBox
                .Top = topMargin + (i * (height + verticalSpacing))
                .Width = widthComboBox
                .Height = height
            End With
            Me.Controls.Add(comboBoxes(i))
        Next

        Me.Height = textBoxes(controlCount - 1).Top + height + 84

        Me.Show()
    End Sub

    Private Sub Btn配置文件_Click(sender As Object, e As EventArgs) Handles btn配置文件.Click
        Dim strUseriPropertyIniFile As String
        strUseriPropertyIniFile = IO.Path.Combine(My.Application.Info.DirectoryPath, "UseriProperty.ini")

        If IsFileExists(strUseriPropertyIniFile) = False Then
            MessageBox.Show("无配置文件,请手动配置！", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning)

            Dim file As New StreamWriter(strUseriPropertyIniFile)
            file.WriteLine("#不要修改#号行。")
            file.WriteLine("#数据结构为  自定义=自定义iproperty名称{列表数据}，若无列表数组则不设置{}内列表数据。")
            file.WriteLine("#自定义=输入数量{1,2,3,4,5,6,7,8,9,10}")
            file.WriteLine("数量=0")
            file.Close()
            Exit Sub
        End If
        Process.Start(strUseriPropertyIniFile)

    End Sub
End Class