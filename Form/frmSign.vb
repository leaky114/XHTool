Imports System.Windows.Forms
Imports Inventor
Imports Inventor.DocumentTypeEnum

Public Class frmSign

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            Dim oInventorDocument As Inventor.Document
            oInventorDocument = ThisApplication.ActiveDocument

            If oInventorDocument.DocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = oInventorDocument

            Dim strPrintDate As String

            strPrintDate = dtpDate.Value.Date.Year & "." & dtpDate.Value.Date.Month & "." & dtpDate.Value.Date.Day

            Select Case chkSignPrint.Checked
                Case True
                    IsOpenPrint = 1
                Case False
                    IsOpenPrint = 0
            End Select

            If SetSign(oInventorDrawingDocument, txtEngineer.Text, strPrintDate, True) Then
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
            Case 0
                chkSignPrint.Checked = False
            Case 1
                chkSignPrint.Checked = True

        End Select

    End Sub
End Class