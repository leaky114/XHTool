Imports System.Windows.Forms
Imports Inventor
Imports System
Imports System.IO
Imports Microsoft
Imports Microsoft.VisualBasic
Imports System.Collections.ObjectModel
Imports stdole
Imports System.Drawing

Public Class PrintIPWDialog

    '批量打印开始
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If ListView1.Items.Count = 0 Then
            MsgBox("未添加工程图文件。", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "批量另存为")
            Exit Sub
        End If

        Dim sPrinterName As String = ""
        sPrinterName = ComboBox1.Text

        For i = 0 To ListView1.Items.Count - 1
            ListView1.Items(i).Selected = True
            '打开文件
            Dim InvDocFullFileName As String  '工程图全文件名

            InvDocFullFileName = ListView1.Items(i).Text

            If IsFileExsts(InvDocFullFileName) = False Then   '跳过不存在的文件
                GoTo 999
            End If

            'If InStr(InvDocFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
            '    GoTo 999
            'End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            '打开工程图
            oInventorDrawingDocument = ThisApplication.Documents.Open(InvDocFullFileName, True)

            '保存文件
            If CheckBox5.Checked = True Then
                oInventorDrawingDocument.Save2(True)
            End If

            '设置签字
            Dim Print_Day As String
            Print_Day = Today.Year & "." & Today.Month & "." & Today.Day
            If CheckBox2.CheckState = CheckState.Checked Then
                SetSign(oInventorDrawingDocument, EngineerName, Print_Day, False)
            End If

            '打印文件
            PrintDrawing(oInventorDrawingDocument, sPrinterName)

            '关闭文件
            If CheckBox4.Checked = True Then
                oInventorDrawingDocument.Close(True)
            End If

999:
        Next
        'MsgBox("批量打印工程图完成", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "批量打印")

        ListView1.Items.Clear()
        SetStatusBarText("批量打印工程图完成")

    End Sub

    '关闭
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        ListView1.Items.Clear()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    '添加文件
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addfile.Click

        Dim NewOpenFileDialog As New OpenFileDialog

        Label1.Visible = False

        With NewOpenFileDialog
            .Title = "打开"
            .FileName = ""
            .Filter = "AutoDesk Inventor 工程图文件(*.idw)|*.idw" '添加过滤文件
            .Multiselect = True '多开文件打开
            If .ShowDialog = Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                If .FileName <> "" Then '如果有选中文件
                    For Each FullFileName As String In .FileNames
                        ListView1.Items.Add(FullFileName)
                    Next
                End If
            Else
                Exit Sub
            End If
        End With
    End Sub

    '清空文件列表
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clearlist.Click
        ListView1.Items.Clear()
    End Sub

    '添加文件夹
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addfolder.Click
        Dim destinationFolder As String = Nothing
        Dim inf As FileAttributes
        Dim Present_Folder As String = Nothing
        Dim oFolderBrowserDialog As New FolderBrowserDialog

        Label1.Visible = False

        With oFolderBrowserDialog
            .ShowNewFolderButton = False
            .Description = "添加文件夹"
            .RootFolder = System.Environment.SpecialFolder.Desktop
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                destinationFolder = .SelectedPath
            Else
                Exit Sub
            End If
        End With

        '是否为文件夹，在其后添加 \，得到父文件夹
        inf = FileSystem.GetAttr(destinationFolder)

        If inf = FileAttributes.Directory Then
            destinationFolder = destinationFolder + "\"
            Present_Folder = My.Computer.FileSystem.GetParentPath(destinationFolder)
        End If

        GetAllFile(Present_Folder, destinationFolder, ListView1)

    End Sub

    '打印文档，打印机名称
    Private Sub PrintDrawing(ByVal oInventorDrawingDocument As Inventor.DrawingDocument, ByVal sPrinterName As String)

        ' Set a reference to the print manager object of the active document.
        ' This will fail if a drawing document is not active.
        Dim oPrintMgr As DrawingPrintManager

        oPrintMgr = oInventorDrawingDocument.PrintManager

        With oPrintMgr
            ' Get the name of the printer that will be used.
            .Printer = sPrinterName

            '所有颜色打印为黑色
            If CheckBox1.Checked = True Then
                .AllColorsAsBlack = True
            Else
                .AllColorsAsBlack = False
            End If

            .ColorMode = PrintColorModeEnum.kPrintDefaultColorMode

            '份数
            .NumberOfCopies = NumericUpDown1.Value

            ' Set to print using portrait orientation.
            .Orientation = PrintOrientationEnum.kDefaultOrientation

            '最佳比例
            .ScaleMode = PrintScaleModeEnum.kPrintBestFitScale

            '设置为默认纸张大小

            ' 如果是打印到打印机，修正为A3
            If CheckBox3.Checked = True Then
                Select Case oInventorDrawingDocument.ActiveSheet.Size
                    Case DrawingSheetSizeEnum.kA4DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA4
                    Case DrawingSheetSizeEnum.kA3DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA3
                    Case DrawingSheetSizeEnum.kA2DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA3
                    Case DrawingSheetSizeEnum.kA1DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA3
                    Case DrawingSheetSizeEnum.kA0DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA3
                End Select
            Else
                '设置为默认纸张大小
                Select Case oInventorDrawingDocument.ActiveSheet.Size
                    Case DrawingSheetSizeEnum.kA4DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA4
                    Case DrawingSheetSizeEnum.kA3DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA3
                    Case DrawingSheetSizeEnum.kA2DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA2
                    Case DrawingSheetSizeEnum.kA1DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA1
                    Case DrawingSheetSizeEnum.kA0DrawingSheetSize
                        .PaperSize = PaperSizeEnum.kPaperSizeA0
                End Select

            End If

            '最佳比例
            .ScaleMode = PrintScaleModeEnum.kPrintBestFitScale

            '设置方向
            Select Case oInventorDrawingDocument.ActiveSheet.Orientation
                Case PageOrientationTypeEnum.kLandscapePageOrientation
                    .Orientation = PrintOrientationEnum.kLandscapeOrientation
                Case PageOrientationTypeEnum.kPortraitPageOrientation
                    .Orientation = PrintOrientationEnum.kPortraitOrientation
            End Select

            ' Set to print all sheets.
            .PrintRange = PrintRangeEnum.kPrintAllSheets

            ' 打印
            .SubmitPrint()

        End With
    End Sub

    Private Sub PrintIPWDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim prtdoc As New Printing.PrintDocument
        Dim strDefaultPrinter As String = prtdoc.PrinterSettings.PrinterName

        Dim strPrinter As String
        For Each strPrinter In Printing.PrinterSettings.InstalledPrinters
            ComboBox1.Items.Add(strPrinter)
            If strPrinter = strDefaultPrinter Then
                ComboBox1.SelectedIndex = ComboBox1.Items.IndexOf(strPrinter)
            End If
        Next strPrinter
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loadasm.Click
        Dim oOpenFileDialog As New OpenFileDialog
        Dim AssDoc As AssemblyDocument = Nothing

        Label1.Visible = False

        With oOpenFileDialog
            .Title = "打开"
            .Filter = "AutoDesk Inventor 部件(*.iam)|*.iam" '添加过滤文件
            .Multiselect = False  '多开文件打开
            .FileName = ""
            If .ShowDialog = Windows.Forms.DialogResult.OK Then '如果打开窗口OK
                If .FileName <> "" Then '如果有选中文件
                    AssDoc = ThisApplication.Documents.Open(.FileName)
                End If
            Else
                Exit Sub
            End If
        End With

        ' 获取所有引用文档
        Dim oAllReferencedDocuments As DocumentsEnumerator
        oAllReferencedDocuments = AssDoc.AllReferencedDocuments

        ' 遍历这些文档

        For Each ReferencedDocument As Inventor.Document In oAllReferencedDocuments

            Dim FullFileName As String
            FullFileName = ReferencedDocument.FullDocumentName

            Dim IdwFullFileName As String
            IdwFullFileName = GetNewExtensionFileName(FullFileName, ".idw")

            If IsFileExsts(IdwFullFileName) = False Then   '跳过不存在的文件
                GoTo 999
            End If

            If InStr(FullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                GoTo 999
            End If

            ListView1.Items.Add(IdwFullFileName)

999:
        Next

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles remove.Click
        ListViewDel(ListView1)
    End Sub

    '移出项
    Private Sub ListViewDel(ByVal ListView As ListView)
        For i As Integer = ListView.SelectedIndices.Count - 1 To 0 Step -1
            ListView.Items.RemoveAt(ListView.SelectedIndices(i))
        Next
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loadidw.Click



        Try
            Label1.Visible = False

            SetStatusBarText()

            If IsInventorOpenDoc() = False Then
                Exit Sub
            End If

            For Each oInventorDocument As Inventor.Document In ThisApplication.Documents
                If oInventorDocument.DocumentType = DocumentTypeEnum.kDrawingDocumentObject Then
                    ListView1.Items.Add(oInventorDocument.FullDocumentName)
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class