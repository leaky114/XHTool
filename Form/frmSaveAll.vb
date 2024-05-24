Imports Inventor.DocumentTypeEnum
Imports System.Windows.Forms

Public Class frmSaveAll
    Dim RadioState As Short

    Private Sub btn确定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn确定.Click

        SetStatusBarText()

        if IsInventorOpenDocument() = False Then
            Exit Sub
        End if

        Me.TopMost = False

        For Each oInventorDocument As Inventor.Document In ThisApplication.Documents.VisibleDocuments
            if IsFileExsts(oInventorDocument.FullDocumentName) = False Then
                Continue For
            End if

            Select Case oInventorDocument.DocumentType
                Case kAssemblyDocumentObject
                    if chk部件.Checked = True Then
                        Select Case RadioState
                            Case 1    '全部保存
                                oInventorDocument.Save2(True)
                            Case 2    '全部保存关闭
                                oInventorDocument.Save2(True)
                                oInventorDocument.Close()
                            Case 3   '全部关闭
                                oInventorDocument.Close(True)
                        End Select
                    End if
                Case kPartDocumentObject
                    if chk零件图.Checked = True Then
                        Select Case RadioState
                            Case 1    '全部保存
                                oInventorDocument.Save2(True)
                            Case 2    '全部保存关闭
                                oInventorDocument.Save2(True)
                                oInventorDocument.Close()
                            Case 3   '全部关闭
                                oInventorDocument.Close(True)
                        End Select
                    End if
                Case kDrawingDocumentObject
                    if chk工程图.Checked = True Then
                        Select Case RadioState
                            Case 1    '全部保存
                                oInventorDocument.Save2(True)
                            Case 2    '全部保存关闭
                                oInventorDocument.Save2(True)
                                oInventorDocument.Close()
                            Case 3   '全部关闭
                                oInventorDocument.Close(True)
                        End Select
                    End if
            End Select
        Next

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub rdo全部保存_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo全部保存.CheckedChanged
        RadioState = 1
    End Sub

    Private Sub rdo全部保存并关闭_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo全部保存并关闭.CheckedChanged
        RadioState = 2
    End Sub

    Private Sub rdo全部关闭_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo全部关闭.CheckedChanged
        RadioState = 3
    End Sub

End Class