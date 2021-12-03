Imports System.Windows.Forms
Imports Inventor
Imports Inventor.DocumentTypeEnum

Public Class SignDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            SetStatusBarText()

            If IsInventorOpenDoc() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocument.DocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim IdwDoc As DrawingDocument
            IdwDoc = ThisApplication.ActiveDocument

            Dim Print_Date As String

            Print_Date = DateTimePicker1.Value.Date.Year & "." & DateTimePicker1.Value.Date.Month & "." & DateTimePicker1.Value.Date.Day

            Select Case CheckBox1.CheckState
                Case CheckState.Unchecked
                    IsOpenPrint = -1
                Case CheckState.Indeterminate
                    IsOpenPrint = 0
                Case CheckState.Checked
                    IsOpenPrint = 1
            End Select

            If SetSign(IdwDoc, TextBox1.Text, Print_Date, True) Then
                SetStatusBarText("设置工程图属性：签字完成")
            Else
                SetStatusBarText("错误")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SignDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = EngineerName
        DateTimePicker1.Value = Today.Date
        Select Case IsOpenPrint
            Case -1
                CheckBox1.CheckState = CheckState.Unchecked
            Case 0
                CheckBox1.CheckState = CheckState.Indeterminate
            Case 1
                CheckBox1.CheckState = CheckState.Checked
        End Select

    End Sub
End Class