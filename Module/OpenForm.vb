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
        If windowHeight * windowWidth <> 0 Then
            oForm.Size = New Size(windowWidth, windowHeight)
        End If
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
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                MessageBox.Show("该功能仅适用于工程图。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）
                Exit Sub
            End If

            Dim formSign As New FormCustomSignature
            FormManager.ShowForm(Of FormCustomSignature)()
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）
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
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim formAutoPartNumber As New FormAutoPartNumber
            FormManager.ShowForm(Of FormAutoPartNumber)()
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '打开技术要求窗口
    Public Sub FormSpecificationShow()
        Try
            SetStatusBarText()

            Dim formSpecification As New FormSpecification

            If ThisApplication.FileManager.Files.Count = 0 Then
                FormManager.ShowForm(Of FormSpecification)()
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType = kDrawingDocumentObject Then
                FormManager.ShowForm(Of FormSpecification)()
            Else
                MessageBox.Show("该功能仅适用于工程图。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）
        End Try

    End Sub

    '打开文件替换配置窗口
    Public Sub FormBorderTitleShow()
        Try
            SetStatusBarText()

            'Dim formBorderTitle As New FormBorderTitle
            'formBorderTitle.Show()

            FormManager.ShowForm(Of FormBorderTitle)(False)

        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    '打开批量打印窗口
    Public Sub FormBulkPrintShow()
        Try
            SetStatusBarText()

            Dim FormBatchPrint As New FormBatchPrint
            FormManager.ShowForm(Of FormBatchPrint)()
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub FormBatchCommandShow()
        Try
            SetStatusBarText()

            Dim FormBatchCommand As New FormBatchCommand
            FormManager.ShowForm(Of FormBatchCommand)()
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '打开查询erp编码窗口
    Public Sub FormSearchERPCodeShow()
        Try
            SetStatusBarText()

            Dim formSearchERPCode As New FormSearchERPCode
            FormManager.ShowForm(Of FormSearchERPCode)()
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '打开反查erp编码
    Public Sub FormReverseCheckERPCodesShow()
        Try
            SetStatusBarText()

            Dim FormReverseCheckERPCodes As New FormReverseCheckERPCodes
            FormManager.ShowForm(Of FormReverseCheckERPCodes)()
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim formImportCodeToIam As New FormImportCodeToIam
            FormManager.ShowForm(Of FormImportCodeToIam)()
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '导入ERP编码到excel文件
    Public Sub FormImportERPCodeToExcelshow()
        Try
            SetStatusBarText()

            Dim formImportCodeToBomExcel As New FormImportCodeToBomExcel
            FormManager.ShowForm(Of FormImportCodeToBomExcel)()
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'm_打开ERP数据文件 
    Public Sub OpenBasicExcel()
        Try
            SetStatusBarText()

            If IsFileExists(BasicExcelFullFileName) Then
              ProcessStart(BasicExcelFullFileName)
            Else
                'ProcessStart(My.Application.Info.DirectoryPath)
                MessageBox.Show($"未找到文件： {BasicExcelFullFileName} ，请重新设置。", XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '打开设置窗口
    Public Sub FormOptionshow()
        Try
            SetStatusBarText()

            Dim formOption As New FormOption

            If ThisApplication.FileManager.Files.Count = 0 Then
                FormManager.ShowForm(Of FormOption)(True) '  formOption.ShowDialog()
            Else
                FormManager.ShowForm(Of FormOption)()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '格式转化
    Public Sub FormFormatConversionShow()
        Try
            SetStatusBarText()

            Dim formFormatConversion As New FormFormatConversion
            FormManager.ShowForm(Of FormFormatConversion)()
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '打开iproperty量产窗口
    Public Sub FormMassiPopertiesshow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            Dim formMassiPoperties As New formBatchiPoperties
            FormManager.ShowForm(Of formBatchiPoperties)()
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '打开统计窗口
    Public Sub FormStatisticalShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType = DocumentTypeEnum.kDrawingDocumentObject Then
                MessageBox.Show(”该功能仅适用于零部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim formStatistical As New FormStatistical
            FormManager.ShowForm(Of FormStatistical)()
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    '打开设置文件属性窗口
    Public Sub FormSetReadOnlyShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim formSetReadOnly As New FormSetReadOnly
            FormManager.ShowForm(Of FormSetReadOnly)()
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    '打开编辑尺寸窗口
    Public Sub FormEditDimensionShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            'if (ThisApplication.ActiveEditDocument.DocumentType <> kPartDocumentObject Then
            '      MessageBox.Show(”该功能仅适用于零件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Exit Sub
            'End if

            Dim formEditDimension As New FormEditDimension
            FormManager.ShowForm(Of FormEditDimension)()

        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
        End Try

    End Sub

    '打开驱动测量窗口
    Public Sub FormDim2ObjectShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim formDim2Object As New FormDim2Object
            FormManager.ShowForm(Of FormDim2Object)()

        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    '打开动画窗口
    Public Sub FormPantoneShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kPartDocumentObject Then
                MessageBox.Show(”该功能仅适用于零件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim FormPantone As New FormPantone
            FormManager.ShowForm(Of FormPantone)()

        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '打开动画窗口
    Public Sub FormPlayerShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim formPlayer As New FormPlayer
            FormManager.ShowForm(Of FormPlayer)()

        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '打开切换文档窗口
    Public Sub FormSwitchLablesShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.Documents.VisibleDocuments.Count = 1 Then
                Exit Sub
            End If


            Dim formSwitchLables As New FormSwitchLables
            FormManager.ShowForm(Of FormSwitchLables)()

        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub FormExplorerShow()
        Try
            SetStatusBarText()

            Dim FormExplorer As New FormExplorer

            If ThisApplication.Documents.Count = 0 Then
                FormManager.ShowForm(Of FormExplorer)(True)
            Else
                FormManager.ShowForm(Of FormExplorer)()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '打开展开图工艺窗口
    Public Sub FormFlatPatternShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MessageBox.Show("该功能仅适用于工程图。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）
                Exit Sub
            End If

            Dim formFlatPattern As New FormFlatPattern
            FormManager.ShowForm(Of FormFlatPattern)()
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '打开移动文件窗口
    Public Sub FormMovesSpecifiedFileShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim formMovesSpecifiedFile As New FormMovesSpecifiedFile
            FormManager.ShowForm(Of FormMovesSpecifiedFile)()
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    '打开iProperty重命名窗口
    Public Sub FormiPropertyToFileNameShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim FormiPropertyToFileName As New FormiPropertyToFileName
            FormManager.ShowForm(Of FormiPropertyToFileName)()
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '打开批量修改文件名窗口
    Public Sub FormBatchChangeFileNamesShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim formBatchChangeFileNames As New FormBatchChangeFileNames
            FormManager.ShowForm(Of FormBatchChangeFileNames)(True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    '打开油路块着色窗口
    Public Sub FormOilBlockHoleColoringShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> DocumentTypeEnum.kPartDocumentObject Then
                MessageBox.Show(”该功能仅适用于零件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim FormOilBlockHoleColoring As New FormOilBlockHoleColoring
            FormManager.ShowForm(Of FormOilBlockHoleColoring)()
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    ''打开面着色窗口
    Public Sub FormFaceColoringShow()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> DocumentTypeEnum.kPartDocumentObject Then
                MessageBox.Show(”该功能仅适用于零件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim FormFaceColoring As New FormFaceColoring
            FormManager.ShowForm(Of FormFaceColoring)()
        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


End Module