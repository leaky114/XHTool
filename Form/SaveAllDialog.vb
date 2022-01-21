Imports System.Windows.Forms
Imports Inventor.DocumentTypeEnum

Public Class SaveAllDialog
    Dim RadioState As Short

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        SetStatusBarText()

        If IsInventorOpenDoc() = False Then
            Exit Sub
        End If

        If CheckBox1.Checked = True Then    '部件
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

        If CheckBox2.Checked = True Then     '零件
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

        If CheckBox3.Checked = True Then    '工程图
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

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged
        RadioState = 1
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged
        RadioState = 2
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton3.CheckedChanged
        RadioState = 3
    End Sub
End Class
