Imports System.Windows.Forms
Imports Inventor
Imports Inventor.DocumentTypeEnum

Public Class frmSign

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            SetStatusBarText()

            If IsInventorOpenDoc() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocument.DocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            Dim Print_Date As String

            Print_Date = dtpDate.Value.Date.Year & "." & dtpDate.Value.Date.Month & "." & dtpDate.Value.Date.Day

            Select Case chkSignPrint.CheckState
                Case CheckState.Unchecked
                    IsOpenPrint = -1
                Case CheckState.Indeterminate
                    IsOpenPrint = 0
                Case CheckState.Checked
                    IsOpenPrint = 1
            End Select

            If SetSign(oInventorDrawingDocument, txtEngineer.Text, Print_Date, True) Then
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

    Private Sub btnCancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmSign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtEngineer.Text = EngineerName
        dtpDate.Value = Today.Date
        Select Case IsOpenPrint
            Case -1
                chkSignPrint.CheckState = CheckState.Unchecked
            Case 0
                chkSignPrint.CheckState = CheckState.Indeterminate
            Case 1
                chkSignPrint.CheckState = CheckState.Checked
        End Select

    End Sub
End Class