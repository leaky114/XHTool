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

            if IsInventorOpenDocument() = False Then
                Exit Sub
            End if

            if ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
                Exit Sub
            End if

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

            if IsInventorOpenDocument() = False Then
                Exit Sub
            End if

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

            if IsInventorOpenDocument() = False Then
                Exit Sub
            End if

            if ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            End if

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

            if IsInventorOpenDocument() = False Then
                Exit Sub
            End if

            if ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            End if

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
            frmImportCodeToBomExcel.ShowInTaskbar = False
            frmImportCodeToBomExcel.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'm_打开ERP数据文件_Buttondef_OnExecute
    Public Sub OpenBasicExcel()
        Try
            if IsFileExsts(BasicExcelFullFileName) Then
                Process.Start(BasicExcelFullFileName)
            Else
                Process.Start(My.Application.Info.DirectoryPath)
            End if
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

            if IsInventorOpenDocument() = False Then
                Exit Sub
            End if

            Dim frmChangeIpro As New frmiProperty
            frmChangeIpro.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '打开iproperty量产窗口
    Public Sub frmMassiPopertiesshow()
        Try
            SetStatusBarText()

            if IsInventorOpenDocument() = False Then
                Exit Sub
            End if

            Dim frmMassiPoperties As New frmMassiPoperties
            frmMassiPoperties.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '打开统计面积质量窗口
    'Public Sub frmStatisticalWeightShow()
    '    Try
    '        SetStatusBarText()

    '        if IsInventorOpenDocument() = False Then
    '            Exit Sub
    '        End if

    '        if ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
    '            MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
    '            Exit Sub
    '        End if

    '        Dim frmStatisticalWeight As New frmStatisticalWeight
    '        frmStatisticalWeight.Show()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub

    '打开统计窗口
    Public Sub FrmStatisticalShow()
        Try
            SetStatusBarText()

            if IsInventorOpenDocument() = False Then
                Exit Sub
            End if

            if ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            End if

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

            if IsInventorOpenDocument() = False Then
                Exit Sub
            End if

            if ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            End if

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

            if IsInventorOpenDocument() = False Then
                Exit Sub
            End if

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

            if IsInventorOpenDocument() = False Then
                Exit Sub
            End if

            if ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            End if

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

End Module