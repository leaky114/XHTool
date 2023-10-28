Imports Inventor
Imports Inventor.AssetTypeEnum
Imports Inventor.BOMStructureEnum
Imports Inventor.DocumentTypeEnum
Imports Inventor.DrawingViewTypeEnum
Imports Inventor.IOMechanismEnum
Imports Inventor.PropertyTypeEnum
Imports Inventor.SelectionFilterEnum

Module OpenFrom

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
            frmSaveAll.ShowDialog()
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

            'If IsInventorOpenDocument() = False Then
            '    Exit Sub
            'End If

            'If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
            '    MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            Dim frmSpecification As New frmSpecification
            frmSpecification.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '打开批量打印窗口
    Public Sub FrmBulkPrintShow()
        Try
            SetStatusBarText()
            Dim frmPrint As New frmPrint
            frmPrint.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '打开查询erp编码窗口
    Public Sub FrmQueryERPcodeshow()
        Try
            SetStatusBarText()
            Dim frmSearchERPCode As New frmSearchERPCode
            frmSearchERPCode.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '打开反查erp编码
    Public Sub ReverseCheckERPCodesshow()
        Try
            SetStatusBarText()
            Dim frmERPCodeSearch As New frmERPCodeSearch
            frmERPCodeSearch.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '导入ERP编码到excel文件
    Public Sub FrmImportCodeToIamShow()
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
            frmImportCodeToIam.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '导入ERP编码到excel文件
    Public Sub FrmImportERPCodeToExcelshow()
        Try
            SetStatusBarText()

            'If IsInventorOpenDocument() = False Then
            '    Exit Sub
            'End If

            Dim frmImportCodeToBomExcel As New frmImportCodeToBomExcel
            frmImportCodeToBomExcel.ShowDialog()
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
        frmOption.ShowDialog()

    End Sub

    '打开全部另存为
    Public Sub FrmAllSaveAsShow()

        Dim SaveAsDialog As New frmSaveAs
        SaveAsDialog.ShowDialog()

    End Sub

    '打开iproperty窗口
    Public Sub FrmChangeIproShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            Dim frmChangeIpro As New frmChangeIpro
            frmChangeIpro.ShowDialog()
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
            frmMassiPoperties.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '打开统计面积质量窗口
    Public Sub frmGetPartshow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim frmGetPart As New frmGetPart
            frmGetPart.ShowDialog()
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

            Dim frmSetWriteOnly As New frmSetWriteOnly
            frmSetWriteOnly.ShowDialog()
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

            If ThisApplication.ActiveEditDocument.DocumentType <> kPartDocumentObject Then
                MsgBox("该功能仅适用于零件。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim frmEditDimension As New frmEditDimension
            frmEditDimension.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Module