Imports Inventor
Imports Inventor.DocumentTypeEnum
Imports System.Windows.Forms

Public Class FormBatchChangeFileNames

    Private Sub Btn确定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn确定.Click

        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kAssemblyDocumentObject Then
                MessageBox.Show(”该功能仅适用于部件。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim strSearch As String = txt搜索字符串.Text
            Dim strReplace As String = txt替换为.Text
            Dim strPrefix = txt添加前缀.Text
            Dim strSuffix = txt添加后缀.Text

            'OldName = "GT140"
            'NewName = "GT240"

            Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
            oInventorAssemblyDocument = ThisApplication.ActiveDocument

            Dim IsSaveAsOld As Boolean
            'IsSaveAsOld =  MessageBox.Show("是否更改原文件为备份文件，扩展名增加 .old ？", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)

            IsSaveAsOld = chk备份文件.Checked

            ThisApplication.SilentOperation = True

            ReplaceNameInAsmSub(oInventorAssemblyDocument, strSearch, strReplace, strPrefix, strSuffix, IsSaveAsOld)

            RefreshTreeNodeNameSub(oInventorAssemblyDocument)

            ThisApplication.SilentOperation = False

            Me.TopMost = False

            MessageBox.Show(“部件替换文件名完成。", XHTool, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, xhtool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click
        FormManager.CloseAndDisposeForm(Of FormBatchChangeFileNames)()
    End Sub

    Private Sub FrmChangeIpro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48
        Me.TopMost = True
    End Sub


    ''' <summary>
    ''' 批量替换部件下子集的名字子过程
    ''' </summary>
    ''' <param name="oInventorAssemblyDocument">组件</param>
    ''' <param name="strSearch">搜索的字符串</param>
    ''' <param name="strReplace">替换的字符串</param>
    ''' <param name="strPrefix">前缀</param>
    ''' <param name="strSuffix">后缀</param>
    ''' <param name="IsSaveAsOld">旧文件是否更改为.old</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReplaceNameInAsmSub(ByVal oInventorAssemblyDocument As Inventor.AssemblyDocument, ByVal strSearch As String, _
                                       ByVal strReplace As String, ByVal strPrefix As String, ByVal strSuffix As String, _
                                       ByVal IsSaveAsOld As Boolean) As Boolean

        'Dim strTempFullFileName As String       '更改旧模型文件的名字存档

        For Each oInventorDocument As Inventor.Document In oInventorAssemblyDocument.ReferencedDocuments
            Dim strOldFullFileName As String   '被替换的旧文件全名
            Dim strOldFileName As String   '被替换的旧文件仅文件名

            Dim strNewFullFileName As String   '新文件全名
            Dim strNewFileName As String   '新文件名

            'InventorDoc = ThisApplication.Documents.ItemByName(OldFullFileName)

            strOldFullFileName = oInventorDocument.FullDocumentName

            If IsFileExists(strOldFullFileName) = False Then   '跳过不存在的文件
                Continue For
            End If

            If InStr(strOldFullFileName, ContentCenterFiles) > 0 Then    '跳过零件库文件
                Continue For
            End If

            strOldFileName = GetFileNameInfo(strOldFullFileName).FileName

            strNewFileName = GetNewFileNameByReplacePrefixSuffix(strOldFileName, strSearch, strReplace, strPrefix, strSuffix)

            strNewFullFileName = IO.Path.Combine(GetFileNameInfo(strOldFullFileName).Folder, strNewFileName)


            If strOldFileName = strNewFileName Then
                Continue For
            End If

            '打开旧文件,不显示
            Dim OldInventorDocument As Inventor.Document
            OldInventorDocument = ThisApplication.Documents.Open(strOldFullFileName, False)

            '另存为新文件
            OldInventorDocument.SaveAs(strNewFullFileName, False)

            '关闭旧图
            OldInventorDocument.Close()

            '后台打开文件，修改ipro
            Dim oNewInventorDocument As Inventor.Document
            oNewInventorDocument = ThisApplication.Documents.Open(strNewFullFileName, False)  '打开文件，不显示
            SetDocumentIpropertyFromFileNameSub(oNewInventorDocument, True) '设置Iproperty，打开文件后需关闭

            Dim oCO As Inventor.ComponentOccurrences
            oCO = oInventorAssemblyDocument.ComponentDefinition.Occurrences

            '全部替换为新文件
            For Each ooCO As ComponentOccurrence In oCO
                If ooCO.ReferencedDocumentDescriptor.FullDocumentName = strOldFullFileName Then
                    ooCO.Replace(strNewFullFileName, True)
                    Exit For
                End If
            Next

            '是否有对应的工程图文件，同时复制后修改文件名和模型链接
            Dim oOldIdwFullFileName As String
            oOldIdwFullFileName = GetChangeExtension(strOldFullFileName, IDW)   '旧工程图

            'Dim TempFullFileName As String       '更改旧模型文件的名字存档

            If IsFileExists(oOldIdwFullFileName) = True Then
                Dim oNewIdwFullFileName As String
                oNewIdwFullFileName = GetChangeExtension(strNewFullFileName, IDW)   '新工程图
                FileSystem.FileCopy(oOldIdwFullFileName, oNewIdwFullFileName)             '复制为新工程图

                ' MessageBox.Show("找到有对应的旧工程图，生成新的工程图，将打开，请链接到文件：" & vbCrLf & NewFullFileName & vbCrLf & "该文件名已复制，粘贴到对话框即可。", MsgBoxStyle.Information)
                'Windows.Forms.Clipboard.SetText(NewFullFileName)
                'ThisApplication.Documents.Open(NewIdwFullFileName, False)      '打开新的工程图，使其手动链接零件或部件
                'ThisApplication.Documents.ItemByName(NewIdwFullFileName).Save2() '保存链接并关闭工程图
                'ThisApplication.Documents.ItemByName(NewIdwFullFileName).Close()

                oInventorDocument = ThisApplication.Documents.Open(oNewIdwFullFileName, False)  '打开文件，不显示
                oInventorDocument.ReferencedDocumentDescriptors(1).ReferencedFileDescriptor.ReplaceReference(strNewFullFileName)
                oInventorDocument.Save2()
                oInventorDocument.Close()

                If IsSaveAsOld = True Then  '暂时更改旧工程图文件的名字存档
                    AddOldExtension(oOldIdwFullFileName)
                End If
            End If

            If IsSaveAsOld = True Then
                    AddOldExtension(strOldFullFileName)
                End If

                '是部件的遍历新文件的子集
                oNewInventorDocument = ThisApplication.Documents.Open(strNewFullFileName, False)
                If oNewInventorDocument.DocumentType = kAssemblyDocumentObject Then
                    ReplaceNameInAsmSub(oNewInventorDocument, strSearch, strReplace, strPrefix, strSuffix, IsSaveAsOld)
                End If
                oNewInventorDocument.Close(True)

        Next

        '保存主部件文件
        'oInventorAssemblyDocument.Save2(True)

        Return True

    End Function

    ''' <summary>
    ''' 替换、增加前缀，后缀
    ''' </summary>
    ''' <param name="strOldFileName">旧文件名</param>
    ''' <param name="strSearch">搜索的字符串</param>
    ''' <param name="strReplace">替换的字符串</param>
    ''' <param name="strPrefix">前缀</param>
    ''' <param name="strSuffix">后缀</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetNewFileNameByReplacePrefixSuffix(strOldFileName As String, strSearch As String, strReplace As String, strPrefix As String, strSuffix As String) As String
        ' 检查输入参数
        If String.IsNullOrEmpty(strOldFileName) Then
            Throw New ArgumentException("Old file name cannot be null or empty.")
        End If

        ' 1. 处理搜索和替换字符串的情况
        Dim tempFileName As String = strOldFileName
        If Not String.IsNullOrEmpty(strSearch) Then
            If String.IsNullOrEmpty(strReplace) Then
                ' 如果 replaceStr 为空，则保留 searchStr
                ' 不需要进行任何替换操作
            Else
                tempFileName = tempFileName.Replace(strSearch, strReplace)
            End If
        End If

        ' 2. 分离文件名与扩展名
        Dim fileNameWithoutExt As String
        Dim fileExt As String = Nothing
        If tempFileName.Contains(".") Then
            Dim parts() As String = tempFileName.Split(".")
            fileNameWithoutExt = parts(0)
            For i As Integer = 1 To parts.Length - 1
                If i > 1 Then fileExt &= "."
                fileExt &= parts(i)
            Next
        Else
            fileNameWithoutExt = tempFileName
            fileExt = ""  ' 如果没有扩展名，则设置为空
        End If

        ' 3. 添加前缀和后缀
        Dim newFileNameWithoutExt As String = strPrefix & fileNameWithoutExt & strSuffix

        ' 4. 重新组合文件名和扩展名
        Dim newFileName As String
        If Not String.IsNullOrEmpty(fileExt) Then
            newFileName = newFileNameWithoutExt & "." & fileExt
        Else
            newFileName = newFileNameWithoutExt
        End If

        Return newFileName
    End Function



End Class