Imports Inventor
Imports Inventor.DocumentTypeEnum
Imports System.Windows.Forms

Public Class frmSign

    Private Sub btn确定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn确定.Click
        Try
            SetStatusBarText()

            if IsInventorOpenDocument() = False Then
                Exit Sub
            End if

            Dim oInventorDocument As Inventor.Document
            oInventorDocument = ThisApplication.ActiveDocument

            if oInventorDocument.DocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图", MsgBoxStyle.Information)
                Exit Sub
            End if

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = oInventorDocument

            Dim strPrintDate As String

            strPrintDate = dtp日期.Value.Date.Year & "." & dtp日期.Value.Date.Month & "." & dtp日期.Value.Date.Day

            Select Case chk签字后打印.Checked
                Case True
                    IsOpenPrint = 1
                Case False
                    IsOpenPrint = 0
            End Select

            if SetSign(oInventorDrawingDocument, txt工程师.Text, strPrintDate, True) Then
                SetStatusBarText("设置工程图属性：签字完成")
            Else
                SetStatusBarText("错误")
            End if

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btn关闭_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub frmSign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48

        txt工程师.Text = EngineerName
        dtp日期.Value = Today.Date
        Select Case IsOpenPrint
            Case 0
                chk签字后打印.Checked = False
            Case 1
                chk签字后打印.Checked = True

        End Select

    End Sub
End Class