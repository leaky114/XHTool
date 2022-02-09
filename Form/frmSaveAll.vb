Imports System.Windows.Forms
Imports Inventor.DocumentTypeEnum

Public Class frmSaveAll
    Dim RadioState As Short

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        SetStatusBarText()

        If IsInventorOpenDoc() = False Then
            Exit Sub
        End If

        If chkAsm.Checked = True Then    '部件
            For Each oInventorDocument As Inventor.Document In ThisApplication.Documents.VisibleDocuments
                If oInventorDocument.DocumentType = kAssemblyDocumentObject Then
                    With oInventorDocument
                        If IsFileExsts(.FullDocumentName) = True Then
                            Select Case RadioState
                                Case 1    '全部保存
                                    .Save2(True)
                                Case 2    '全部保存关闭
                                    .Save2(True)
                                    .Close()
                                Case 3   '全部关闭
                                    .Close(True)
                            End Select
                        End If
                    End With
                End If
            Next
        End If

        If chkPart.Checked = True Then     '零件
            For Each oInventorDocument As Inventor.Document In ThisApplication.Documents.VisibleDocuments
                If oInventorDocument.DocumentType = kPartDocumentObject Then
                    With oInventorDocument
                        If IsFileExsts(.FullDocumentName) = True Then
                            Select Case RadioState
                                Case 1    '全部保存
                                    .Save2(True)
                                Case 2    '全部保存关闭
                                    .Save2(True)
                                    .Close()
                                Case 3   '全部关闭
                                    .Close(True)
                            End Select
                        End If
                    End With
                End If
            Next
        End If

        If chkIdw.Checked = True Then    '工程图
            For Each oInventorDocument As Inventor.Document In ThisApplication.Documents.VisibleDocuments
                If oInventorDocument.DocumentType = kDrawingDocumentObject Then
                    With oInventorDocument
                        If IsFileExsts(.FullDocumentName) = True Then
                            Select Case RadioState
                                Case 1    '全部保存
                                    .Save2(True)
                                Case 2    '全部保存关闭
                                    .Save2(True)
                                    .Close()
                                Case 3   '全部关闭
                                    .Close(True)
                            End Select
                        End If
                    End With
                End If
            Next
        End If

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
