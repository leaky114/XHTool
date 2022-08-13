Imports System.Windows.Forms
Imports Inventor.DocumentTypeEnum

Public Class frmSaveAll
    Dim RadioState As Short

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        For Each oInventorDocument As Inventor.Document In ThisApplication.Documents.VisibleDocuments
            If IsFileExsts(oInventorDocument.FullDocumentName) = False Then
                Continue For
            End If

            Select Case oInventorDocument.DocumentType
                Case kAssemblyDocumentObject
                    If chkAsm.Checked = True Then
                        Select Case RadioState
                            Case 1    '全部保存
                                oInventorDocument.Save2(True)
                            Case 2    '全部保存关闭
                                oInventorDocument.Save2(True)
                                oInventorDocument.Close()
                            Case 3   '全部关闭
                                oInventorDocument.Close(True)
                        End Select
                    End If
                Case kPartDocumentObject
                    If chkPart.Checked = True Then
                        Select Case RadioState
                            Case 1    '全部保存
                                oInventorDocument.Save2(True)
                            Case 2    '全部保存关闭
                                oInventorDocument.Save2(True)
                                oInventorDocument.Close()
                            Case 3   '全部关闭
                                oInventorDocument.Close(True)
                        End Select
                    End If
                Case kDrawingDocumentObject
                    If chkIdw.Checked = True Then
                        Select Case RadioState
                            Case 1    '全部保存
                                oInventorDocument.Save2(True)
                            Case 2    '全部保存关闭
                                oInventorDocument.Save2(True)
                                oInventorDocument.Close()
                            Case 3   '全部关闭
                                oInventorDocument.Close(True)
                        End Select
                    End If
            End Select
        Next


        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub rdoSaveAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoSaveAll.CheckedChanged
        RadioState = 1
    End Sub

    Private Sub rdoAllSaveClose_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoAllSaveClose.CheckedChanged
        RadioState = 2
    End Sub

    Private Sub rdoAllClose_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoAllClose.CheckedChanged
        RadioState = 3
    End Sub
End Class
