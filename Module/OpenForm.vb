Imports Inventor
Imports Inventor.AssetTypeEnum
Imports Inventor.BOMStructureEnum
Imports Inventor.DocumentTypeEnum
Imports Inventor.DrawingViewTypeEnum
Imports Inventor.IOMechanismEnum
Imports Inventor.PropertyTypeEnum
Imports Inventor.SelectionFilterEnum
Imports System.Windows.Forms
Imports System.Drawing

Module OpenForm

    ''' <summary>
    ''' 定义一个函数来设置窗口大小并居中显示
    ''' </summary>
    ''' <param name="douWidthRatio"></param>
    ''' <param name="douHeightRatio"></param>
    ''' <remarks></remarks>
    Public Sub SetWindowSizeAndCenter(ByVal oForm As Form, Optional ByVal douWidthRatio As Double = 0.5, Optional ByVal douHeightRatio As Double = 0.5)
        ' 获取显示器的分辨率
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height

        ' 根据比例计算窗口的长和高
        Dim windowWidth As Integer = CInt(screenWidth * douWidthRatio)
        Dim windowHeight As Integer = CInt(screenHeight * douHeightRatio)

        ' 设置窗口的大小
        oForm.Size = New Size(windowWidth, windowHeight)

        ' 将窗口居中显示
        oForm.StartPosition = FormStartPosition.CenterScreen
    End Sub


    '打开关于窗口
    Public Sub FormAboutShow()
        Try
            SetStatusBarText()

            Dim FormAbout As New formAbout
            FormManager.ShowForm(Of formAbout)(True)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '打开自定义签字窗口
    Public Sub FormCustomSignatureShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim formSign As New FormCustomSignature
            FormManager.ShowForm(Of FormCustomSignature)()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '保存关闭所有部件
    Public Sub FormSaveCloseAllDocumentShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            Dim FormSaveCloseAllDocument As New FormSaveCloseAllDocument
            FormManager.ShowForm(Of FormSaveCloseAllDocument)()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '打开生成图号窗口
    Public Sub FormAutoPartNumberShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim formAutoPartNumber As New formAutoPartNumber
            FormManager.ShowForm(Of formAutoPartNumber)()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '打开技术要求窗口
    Public Sub FormSpecificationShow()
        Try
            SetStatusBarText()

            Dim formSpecification As New formSpecification

            If ThisApplication.FileManager.Files.Count = 0 Then
                FormManager.ShowForm(Of formSpecification)()
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType = kDrawingDocumentObject Then
                FormManager.ShowForm(Of formSpecification)()
            Else
                MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '打开文件替换配置窗口
    Public Sub FormBorderTitleShow()
        Try
            SetStatusBarText()

            Dim formBorderTitle As New formBorderTitle
            FormManager.ShowForm(Of formBorderTitle)(True)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    '打开批量打印窗口
    Public Sub FormBulkPrintShow()
        Try
            SetStatusBarText()

            Dim formPrint As New FormBulkPrint
            FormManager.ShowForm(Of FormBulkPrint)()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '打开查询erp编码窗口
    Public Sub FormSearchERPCodeShow()
        Try
            SetStatusBarText()

            Dim formSearchERPCode As New formSearchERPCode
            FormManager.ShowForm(Of formSearchERPCode)()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '打开反查erp编码
    Public Sub FormReverseCheckERPCodesShow()
        Try
            SetStatusBarText()

            Dim FormReverseCheckERPCodes As New FormReverseCheckERPCodes
            FormManager.ShowForm(Of FormReverseCheckERPCodes)()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '导入ERP编码到 部件
    Public Sub FormImportERPCodeToIamShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim formImportCodeToIam As New formImportCodeToIam
            FormManager.ShowForm(Of formImportCodeToIam)()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '导入ERP编码到excel文件
    Public Sub FormImportERPCodeToExcelshow()
        Try
            SetStatusBarText()

            Dim formImportCodeToBomExcel As New formImportCodeToBomExcel
            FormManager.ShowForm(Of formImportCodeToBomExcel)()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'm_打开ERP数据文件 
    Public Sub OpenBasicExcel()
        Try
            SetStatusBarText()

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
    Public Sub FormOptionshow()
        Try
            SetStatusBarText()

            Dim formOption As New formOption

            If ThisApplication.FileManager.Files.Count = 0 Then
                FormManager.ShowForm(Of formOption)(True) '  formOption.ShowDialog()
            Else
                FormManager.ShowForm(Of formOption)()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '格式转化
    Public Sub formFormatConversionShow()
        Try
            SetStatusBarText()

            Dim formFormatConversion As New formFormatConversion
            FormManager.ShowForm(Of formFormatConversion)()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '打开iproperty窗口
    Public Sub FormiPropertyShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            Dim formiProperty As New FormiProperty
            FormManager.ShowForm(Of FormiProperty)(True)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    '打开自定义iproperty窗口
    Public Sub FormUseriPropertyShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            Dim formUseriProperty As New FormUseriProperty
            FormManager.ShowForm(Of FormUseriProperty)(True)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '打开iproperty量产窗口
    Public Sub formMassiPopertiesshow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            Dim formMassiPoperties As New formMassiPoperties
            FormManager.ShowForm(Of formMassiPoperties)()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '打开统计窗口
    Public Sub formStatisticalShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim formStatistical As New formStatistical
            FormManager.ShowForm(Of formStatistical)()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    '打开设置文件属性窗口
    Public Sub formSetReadOnlyShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim formSetReadOnly As New formSetReadOnly
            FormManager.ShowForm(Of formSetReadOnly)()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    '打开编辑尺寸窗口
    Public Sub formEditDimensionShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            'if (ThisApplication.ActiveEditDocument.DocumentType <> kPartDocumentObject Then
            '    MsgBox("该功能仅适用于零件。", MsgBoxStyle.Information)
            '    Exit Sub
            'End if

            Dim formEditDimension As New formEditDimension
            FormManager.ShowForm(Of formEditDimension)()

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub

    '打开驱动测量窗口
    Public Sub formDim2ObjectShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim formDim2Object As New formDim2Object
            FormManager.ShowForm(Of formDim2Object)()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '打开动画窗口
    Public Sub formPlayerShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim formPlayer As New formPlayer
            FormManager.ShowForm(Of formPlayer)()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '打开切换文档窗口
    Public Sub formSwitchLablesShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.Documents.VisibleDocuments.Count = 1 Then
                Exit Sub
            End If


            Dim formSwitchLables As New formSwitchLables
            FormManager.ShowForm(Of formSwitchLables)()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '打开展开图工艺窗口
    Public Sub formFlatPatternShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MsgBox("该功能仅适用于工程图。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim formFlatPattern As New formFlatPattern
            FormManager.ShowForm(Of formFlatPattern)()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '打开移动文件窗口
    Public Sub formMovesSpecifiedFileShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim formMovesSpecifiedFile As New formMovesSpecifiedFile
            FormManager.ShowForm(Of formMovesSpecifiedFile)()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    '打开批量修改文件名窗口
    Public Sub formBatchChangeFileNamesShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim formBatchChangeFileNames As New formBatchChangeFileNames
            FormManager.ShowForm(Of formBatchChangeFileNames)(True)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '打插入打开的零部件
    Public Sub FormPlaceOpenComponentShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MsgBox("该功能仅适用于部件。", MsgBoxStyle.Information)
                Exit Sub
            End If

            If ThisApplication.Documents.VisibleDocuments.Count = 1 Then
                MsgBox("无已打开的其他零部件。", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim FormPlaceOpenComponent As New FormPlaceOpenComponent
            FormManager.ShowForm(Of FormPlaceOpenComponent)(True)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


End Module