Imports Inventor
Imports Inventor.SelectionFilterEnum
Imports Inventor.DocumentTypeEnum
Imports Inventor.DrawingViewTypeEnum
Imports Inventor.PropertyTypeEnum

Module Test
 '测试
 Public Function Test() As Boolean
 	
 	
 End Function
 
 '遍历组件下的文件，将其对应的工程图另存为dwg或Pdf
 Public  function SaveIdwInAsmAsDwgOrPdf()  As Boolean 
        Dim AssDoc As AssemblyDocument
'        Dim i As Integer

        If ThisInventorApplication.ActiveDocument.DocumentType <> kAssemblyDocumentObject Then
            MsgBox("该功能仅适用于部件")
            Return False
            Exit Function
        End If

        AssDoc = ThisInventorApplication.ActiveDocument
        
          ' 获取所有引用文档 
        'Dim RefDocs As DocumentsEnumerator
        Dim FirstLevelOnly As Boolean

        Select Case MsgBox("模式：是-仅修改第一级零件   否-修改所有级别零件 ", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, "修改模式")
            Case MsgBoxResult.Yes
                'RefDocs = AssDoc.ReferencedDocuments
                FirstLevelOnly = True
            Case MsgBoxResult.No
                'RefDocs = AssDoc.AllReferencedDocuments
                FirstLevelOnly = False
            Case Else
                Return True
        End Select
        
        Dim DwgOrPdf As String
        If MsgBox ("批量另存工程图文件为 Dwg或 Pdf 格式？ Dwg （是 Yes） ， Pdf（否 No）",MsgBoxStyle .YesNo,"批量另存工程图文件" )=MsgBoxResult .Yes Then
        	DwgOrPdf="DWG"
        Else 
        	DwgOrPdf ="PDF"
        End If
        
        '
        '==============================================================================================
        '基于bom结构化数据，可跳过参考的文件
        ' Set a reference to the BOM
        Dim oBOM As BOM
        oBOM = AssDoc.ComponentDefinition.BOM
        oBOM.StructuredViewEnabled = True

        'Set a reference to the "Structured" BOMView
        Dim oBOMView As BOMView
       
        '获取结构化的bom页面
        For Each oBOMView In oBOM.BOMViews
            If oBOMView.ViewType = BOMViewTypeEnum.kStructuredBOMViewType Then

                '遍历这个bom页面
                QueryBOMRowToSaveAs(oBOMView.BOMRows, FirstLevelOnly,DwgOrPdf )
            End If
        Next

        '==============================================================================================
   Return True 
    End Function
        
         '遍历BOM结构，查询row文件.打开对应的idw，另存为dwg 或 Pdf
    Public Sub QueryBOMRowToSaveAs(ByVal oBOMRows As BOMRowsEnumerator, ByVal FirstLevelOnly As Boolean,CADorPDF as string)
        Dim i As Integer

        Dim iStepCount As Short
        iStepCount = oBOMRows.Count

        'Create a new ProgressBar object.
        Dim oProgressBar As Inventor.ProgressBar

        oProgressBar = ThisInventorApplication.CreateProgressBar(False, iStepCount, "当前文件： ")

        For i = 1 To oBOMRows.Count
            ' Get the current row.
            Dim oRow As BOMRow
            oRow = oBOMRows.Item(i)

            Dim FileFullName As String

            FileFullName = oRow.ReferencedFileDescriptor.FullFileName

            '测试文件
            Debug.Print(FileFullName)

            ' Set the message for the progress bar
            oProgressBar.Message = FileFullName

            If IsFileExsts(FileFullName) = False Then   '跳过不存在的文件
                GoTo 999
            End If

            If InStr(FileFullName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                GoTo 999
            End If
		
    	Dim IdwFileFullName As String  '工程图全文件名
        

		IdwFileFullName=Strings.Replace (FileFullName ,LCaseGetFileExtension( FileFullName),".idw")
		If IsFileExsts (IdwFileFullName )= True Then 
			Dim DwgPdfFullFileName As String        'dwgpdf 文件全文件名
			
			Select  Case  CADorPDF 
			Case "DWG"
		        DwgPdfFullFileName = Strings.Replace(IdwFileFullName, LCaseGetFileExtension(IdwFileFullName), ".dwg")
			Case "PDF"
				DwgPdfFullFileName = Strings.Replace(IdwFileFullName, LCaseGetFileExtension(IdwFileFullName), ".pdf")
			End Select 
		
		 	Dim IdwDoc As DrawingDocument
		 	IdwDoc = ThisInventorApplication.Documents.Open (IdwFileFullName , False  )
		 	IdwDoc.SaveAs(DwgPdfFullFileName, True)
		 	IdwDoc .Close (True )
		 	
            '遍历下一级
            If (Not oRow.ChildRows Is Nothing) And FirstLevelOnly = False Then
                Call   QueryBOMRowToSaveAs(oRow.ChildRows, FirstLevelOnly,CADorPDF )
            End If
		End If
999:
            oProgressBar.UpdateProgress()
        Next

        oProgressBar.Close()

    End Sub
    
    
 End Module 