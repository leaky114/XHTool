Imports Inventor.DocumentTypeEnum
Imports System.Windows.Forms

Public Class FormSaveCloseAllDocument
    Dim RadioState As Short

    Private Sub Btn确定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn确定.Click

        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        Me.Hide()

        Dim strInventorDocumentFullFileName As String

        For Each oInventorDocument As Inventor.Document In ThisApplication.Documents.VisibleDocuments
            strInventorDocumentFullFileName = oInventorDocument.FullDocumentName
            If IsFileExsts(strInventorDocumentFullFileName) = False Then
                Continue For
            End If

            Select Case oInventorDocument.DocumentType
                Case kAssemblyDocumentObject
                    If chk部件.Checked = True Then
                        Select Case RadioState
                            Case 1    '全部保存
                                If GetFileReadOnly(strInventorDocumentFullFileName) = False Then
                                    oInventorDocument.Save2(True)
                                End If
                            Case 2    '全部保存关闭
                                If GetFileReadOnly(strInventorDocumentFullFileName) = False Then
                                    oInventorDocument.Save2(True)
                                End If
                                oInventorDocument.Close()
                            Case 3   '全部关闭
                                oInventorDocument.Close(True)
                        End Select
                    End If
                Case kPartDocumentObject
                    If chk零件图.Checked = True Then
                        Select Case RadioState
                            Case 1    '全部保存
                                If GetFileReadOnly(strInventorDocumentFullFileName) = False Then
                                    oInventorDocument.Save2(True)
                                End If
                            Case 2    '全部保存关闭
                                If GetFileReadOnly(strInventorDocumentFullFileName) = False Then
                                    oInventorDocument.Save2(True)
                                End If
                                oInventorDocument.Close()
                            Case 3   '全部关闭
                                oInventorDocument.Close(True)
                        End Select
                    End If
                Case kDrawingDocumentObject
                    If chk工程图.Checked = True Then
                        Select Case RadioState
                            Case 1    '全部保存
                                If GetFileReadOnly(strInventorDocumentFullFileName) = False Then
                                    oInventorDocument.Save2(True)
                                End If
                            Case 2    '全部保存关闭
                                If GetFileReadOnly(strInventorDocumentFullFileName) = False Then
                                    oInventorDocument.Save2(True)
                                End If
                                oInventorDocument.Close()
                            Case 3   '全部关闭
                                oInventorDocument.Close(True)
                        End Select
                    End If
            End Select
        Next

        FormManager.CloseAndDisposeForm(Of FormSaveCloseAllDocument)()
    End Sub

    Private Sub Btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click, Me.Closing
        FormManager.CloseAndDisposeForm(Of FormSaveCloseAllDocument)()
    End Sub

    Private Sub Rdo全部保存_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo全部保存.CheckedChanged
        RadioState = 1
    End Sub

    Private Sub Rdo全部保存并关闭_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo全部保存并关闭.CheckedChanged
        RadioState = 2
    End Sub

    Private Sub Rdo全部关闭_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo全部关闭.CheckedChanged
        RadioState = 3
    End Sub

    Private Sub FrmSaveAll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48
    End Sub
End Class