Imports Inventor
Imports Inventor.AssetTypeEnum
Imports Inventor.BOMStructureEnum
Imports Inventor.DocumentTypeEnum
Imports Inventor.DrawingViewTypeEnum
Imports Inventor.IOMechanismEnum
Imports Inventor.PropertyTypeEnum
Imports Inventor.SelectionFilterEnum

Module OpenForm

    '打开自定义签字窗口
    Public Sub FrmCustomSignatureShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim frmSign As New frmSign
            frmSign.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '保存关闭所有部件
    Public Sub FrmSaveCloseAllDocumentShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            Dim frmSaveAll As New frmSaveAll
            frmSaveAll.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '打开生成图号窗口
    Public Sub FrmAutoPartNumberShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim AutoPartNumber As New frmAutoPartNumber
            AutoPartNumber.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '打开技术要求窗口
    Public Sub FrmSpecificationShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim frmSpecification As New frmSpecification
            frmSpecification.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '打开批量打印窗口
    Public Sub FrmBulkPrintShow()
        Try
            SetStatusBarText()
            Dim frmPrint As New frmPrint
            frmPrint.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '打开查询erp编码窗口
    Public Sub FrmSearchERPCodeShow()
        Try
            SetStatusBarText()
            Dim frmSearchERPCode As New frmSearchERPCode
            frmSearchERPCode.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '打开反查erp编码
    Public Sub FrmReverseCheckERPCodesShow()
        Try
            SetStatusBarText()
            Dim frmERPCodeSearch As New frmERPCodeSearch
            frmERPCodeSearch.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '导入ERP编码到excel文件
    Public Sub FrmImportERPCodeToIamShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim frmImportCodeToIam As New frmImportCodeToIam
            frmImportCodeToIam.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '导入ERP编码到excel文件
    Public Sub FrmImportERPCodeToExcelshow()
        Try
            SetStatusBarText()

            'if IsInventorOpenDocument() = False Then
            '    Exit Sub
            'End if

            Dim frmImportCodeToBomExcel As New frmImportCodeToBomExcel
            frmImportCodeToBomExcel.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'm_打开ERP数据文件_Buttondef_OnExecute
    Public Sub OpenBasicExcel()
        Try
            If IsFileExsts(BasicExcelFullFileName) Then
                Process.Start(BasicExcelFullFileName)
            Else
                Process.Start(My.Application.Info.DirectoryPath)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '打开设置窗口
    Public Sub FrmOptionshow()
        Dim frmOption As New frmOption
        frmOption.Show()

    End Sub

    '打开全部另存为
    Public Sub FrmAllSaveAsShow()

        Dim frmFormatConversion As New frmFormatConversion
        frmFormatConversion.Show()

    End Sub

    '打开iproperty窗口
    Public Sub FrmChangeIproShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            Dim frmiProperty As New frmiProperty
            frmiProperty.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '打开iproperty量产窗口
    Public Sub frmMassiPopertiesshow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            Dim frmMassiPoperties As New frmMassiPoperties
            frmMassiPoperties.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '打开统计窗口
    Public Sub FrmStatisticalShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim frmStatistical As New frmStatistical
            frmStatistical.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    '打开设置文件属性窗口
    Public Sub FrmSetWriteOnlyShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim frmSetWrite As New frmSetWrite
            frmSetWrite.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    '打开编辑尺寸窗口
    Public Sub FrmEditDimensionShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            'if (ThisApplication.ActiveEditDocument.DocumentType <> kPartDocumentObject Then
            '    MsgBox("该功能仅适用于零件。", MsgBoxStyle.Information)
            '    Exit Sub
            'End if

            Dim frmEditDimension As New frmEditDimension
            frmEditDimension.Show()

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub

    '打开驱动测量窗口
    Public Sub FrmDim2ObjectShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim FrmDim2Object As New frmDim2Object
            FrmDim2Object.Show()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '打开动画窗口
    Public Sub FrmPlayerShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim frmPlayer As New frmPlayer
            frmPlayer.Show()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '打开切换文档窗口
    Public Sub FrmSwitchLablesShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.Documents.VisibleDocuments.Count = 1 Then
                Exit Sub
            End If

            For Each openForm As System.Windows.Forms.Form In System.Windows.Forms.Application.OpenForms
                If openForm.Name = "切换文档" Then
                    ' 如果找到了，就激活这个窗口
                    openForm.Activate()
                    Exit Sub
                End If
            Next

            Dim frmSwitchLables As New frmSwitchLables
            frmSwitchLables.Show()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


End Module