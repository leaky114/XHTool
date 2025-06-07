Imports Inventor
Imports Inventor.DocumentTypeEnum
Imports System.Windows.Forms

Public Class FormCustomSignature

    Private Sub Btn确定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn确定.Click
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            Dim oInventorDocument As Inventor.Document
            oInventorDocument = ThisApplication.ActiveDocument

            If oInventorDocument.DocumentType <> kDrawingDocumentObject Then
                MessageBox.Show(”该功能仅适用于工程图。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = oInventorDocument

            Dim strPrintDate As String

            If IsShortData = 1 Then
                strPrintDate = Strings.Mid(dtp日期.Value.Year, 3, 2) & "." & dtp日期.Value.Month & "." & dtp日期.Value.Day
            Else
                strPrintDate = dtp日期.Value.Year & "." & dtp日期.Value.Month & "." & dtp日期.Value.Day
            End If

            Select Case chk签字后打印.Checked
                Case True
                    IsOpenPrint = 1
                Case False
                    IsOpenPrint = 0
            End Select

            If SetSign(oInventorDrawingDocument, txt工程师.Text, strPrintDate, True) Then
                SetStatusBarText("设置工程图属性：签字完成")
            Else
                SetStatusBarText(XHTool)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, xhtool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        FormManager.CloseAndDisposeForm(Of FormCustomSignature)()
    End Sub

    Private Sub Btn关闭_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click, Me.Closing
        FormManager.CloseAndDisposeForm(Of FormCustomSignature)()
    End Sub

    Private Sub FrmSign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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