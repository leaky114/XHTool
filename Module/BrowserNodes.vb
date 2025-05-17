Imports System.Windows.Forms
Imports Inventor

Module BrowserNodes
    ''' <summary>
    ''' 获取所选线的零件节点
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SelectPartNodeInBrowserNode()
        'On Error Resume Next

        Dim oInventorDrawingDocument As Inventor.DrawingDocument
        oInventorDrawingDocument = ThisApplication.ActiveEditDocument

        Dim strOldInventorDocumentFullName As String
        strOldInventorDocumentFullName = oInventorDrawingDocument.AllReferencedDocuments(1).FullDocumentName

        If GetFileExtensionLCase(strOldInventorDocumentFullName) <> IAM Then
            MessageBox.Show("不支持非部件工程图。"， XHTool， MessageBoxButtons.OK， MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim oDrawingCurveSegment As DrawingCurveSegment = Nothing

        If oInventorDrawingDocument.SelectSet.Count <> 0 Then
            If oInventorDrawingDocument.SelectSet.Item(1).Type = ObjectTypeEnum.kDrawingCurveSegmentObject Then

                oDrawingCurveSegment = CType(oInventorDrawingDocument.SelectSet.Item(1), DrawingCurveSegment)
            End If
        Else
            oDrawingCurveSegment = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kDrawingCurveSegmentFilter, "选择边，ESC键取消")
            If oDrawingCurveSegment Is Nothing Then       '取消选择
                Exit Sub
            End If
        End If


        Dim oDrawingCurve As DrawingCurve
        oDrawingCurve = oDrawingCurveSegment.Parent

        Dim oSelectDrawingView As Inventor.DrawingView
        oSelectDrawingView = oDrawingCurve.Parent

        Dim strSelectDrawingViewName As String = oSelectDrawingView.Name

        Debug.Print("选择的视图  " & strSelectDrawingViewName & vbCrLf)
        '  MessageBox.Show("选择的视图  " & oSelectDrawingView.Name)

        '===================================
        ' Set a reference to the parent component occurrence
        Dim oOcc As ComponentOccurrence
        Try
            oOcc = oDrawingCurve.ModelGeometry.ContainingOccurrence
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try


        Dim strPartName As String = oOcc.Name
        Debug.Print(" 选择的零件   " & strPartName & vbCrLf)
        ' MessageBox.Show(" 选择的零件   " & strPartName)


        '===============================

        Dim oTopBrowserNode As Inventor.BrowserNode
        oTopBrowserNode = oInventorDrawingDocument.BrowserPanes.ActivePane.TopNode      '顶级node

        Dim oChildBrowserNode As BrowserNode

        '获取选择的图纸的 BrowserNode
        Dim oSelectSheetBrowserNode As BrowserNode = Nothing

        For Each oChildBrowserNode In oTopBrowserNode.BrowserNodes
            'Debug.Print(oChildBrowserNode.FullPath)
            'Debug.Print(TypeName(oChildBrowserNode))

            If TypeName(oChildBrowserNode.NativeObject) = "Sheet" Then
                If oChildBrowserNode.BrowserNodeDefinition.Label = oInventorDrawingDocument.ActiveSheet.Name Then
                    oSelectSheetBrowserNode = oChildBrowserNode
                    Exit For
                End If
            End If
        Next

        Debug.Print("选择的图纸： " & oSelectSheetBrowserNode.FullPath & vbCrLf)

        '===========================
        Dim oSelectDrawingViewBrowserNode As BrowserNode
        If oSelectSheetBrowserNode IsNot Nothing Then
            oSelectDrawingViewBrowserNode = GetSelectDrawingViewBrowserNode(oSelectSheetBrowserNode, strSelectDrawingViewName)
            Debug.Print("选择的视图 node： " & oSelectDrawingViewBrowserNode.FullPath & vbCrLf)
        Else
            Exit Sub
        End If


        Dim oSelecttAssemblyBrowserNode As BrowserNode
        If oSelectDrawingViewBrowserNode IsNot Nothing Then
            oSelecttAssemblyBrowserNode = GetSelecttAssemblyBrowserNode(oSelectDrawingViewBrowserNode)
            Debug.Print("选择的组件 node： " & oSelecttAssemblyBrowserNode.FullPath & vbCrLf)
        Else
            Exit Sub
        End If

        Dim oSelecttParBrowserNode As BrowserNode = Nothing
        If oSelecttAssemblyBrowserNode IsNot Nothing Then
            oSelecttParBrowserNode = GetSelectPartInBrowserNode(oSelecttAssemblyBrowserNode, strPartName)     '获取选择的零件 node
            Debug.Print("选择的零件 node： " & oSelecttParBrowserNode.FullPath & vbCrLf)
        End If

        If oSelecttParBrowserNode IsNot Nothing Then
            oSelecttParBrowserNode.Parent.Expanded = True
            oSelecttParBrowserNode.DoSelect()
        End If
    End Sub

    ''' <summary>
    ''' 获取被选择的视图
    ''' </summary>
    ''' <param name="oSheetBrowserNode">被选择的图纸节点</param>
    ''' <param name="strDrawingViewName">被选择的图纸对象</param>
    ''' <returns></returns>
    Private Function GetSelectDrawingViewBrowserNode(ByVal oSheetBrowserNode As BrowserNode,
                                                     ByVal strDrawingViewName As String) As BrowserNode

        Dim oChildBrowserNode As BrowserNode

        Dim oSelectDrawingViewBrowserNode As BrowserNode

        For Each oChildBrowserNode In oSheetBrowserNode.BrowserNodes

            If Right(oChildBrowserNode.FullPath, 2) = "修剪" Then
                Continue For
            End If

            Dim strTypeName As String

            strTypeName = TypeName(oChildBrowserNode.NativeObject)

            Debug.Print(strTypeName)
            Debug.Print(oChildBrowserNode.BrowserNodeDefinition.Label)
            Debug.Print("----------------")

            Select Case strTypeName
                Case "DrawingView", "SectionDrawingView", "DetailDrawingView"   '视图，剖视图，局部视图
                    'If strSelectBrowserNodeLabel = oChildBrowserNode.BrowserNodeDefinition.Label Then    '是选中的视图

                    If InStr(oChildBrowserNode.BrowserNodeDefinition.Label, strDrawingViewName) <> 0 Then    '是选中的视图
                        oSelectDrawingViewBrowserNode = oChildBrowserNode
                        Return oSelectDrawingViewBrowserNode
                    End If

                    If oChildBrowserNode.BrowserNodes IsNot Nothing Then
                        oSelectDrawingViewBrowserNode = GetSelectDrawingViewBrowserNode(oChildBrowserNode, strDrawingViewName)

                        If oSelectDrawingViewBrowserNode IsNot Nothing Then
                            Return oSelectDrawingViewBrowserNode
                        End If

                    End If
            End Select

        Next
        Return Nothing
    End Function

    ''' <summary>
    ''' 获取被选择的 组件节点
    ''' </summary>
    ''' <param name="oSelectDrawingViewBrowserNode">被选择的视图节点</param>
    ''' <returns></returns>
    Private Function GetSelecttAssemblyBrowserNode（ByVal oSelectDrawingViewBrowserNode As BrowserNode） As BrowserNode
        Dim oChildBrowserNode As BrowserNode

        Dim oGetSelecttAssemblyBrowserNode As BrowserNode

        For Each oChildBrowserNode In oSelectDrawingViewBrowserNode.BrowserNodes

            If Right(oChildBrowserNode.FullPath, 2) = "修剪" Then
                Continue For
            End If

            Dim strTypeName As String
            strTypeName = TypeName(oChildBrowserNode.NativeObject)

            Debug.Print(strTypeName)
            Debug.Print(oChildBrowserNode.BrowserNodeDefinition.Label)
            Debug.Print("----------------")

            If strTypeName = "AssemblyComponentDefinition" Then
                oGetSelecttAssemblyBrowserNode = oChildBrowserNode
                Return oGetSelecttAssemblyBrowserNode
            End If
        Next

        Return Nothing
    End Function


    ''' <summary>
    ''' 获取被选中的view的 node
    ''' </summary>
    ''' <param name="oParentBrowserNode">最顶端的node</param>
    ''' <param name="oDrawingView">被选中的视图</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetViewInBrowserNode(ByVal oParentBrowserNode As BrowserNode, ByVal oDrawingView As Inventor.DrawingView) As BrowserNode
        Dim oChildBrowserNode As BrowserNode
        Dim oSelectViewBrowserNode As BrowserNode = Nothing

        Dim strInventorAssemblyDocumentDisplayName As String = oDrawingView.ReferencedDocumentDescriptor.DisplayName
        Dim strSelectBrowserNodeLabel As String = oDrawingView.Name    ' & ":" & strInventorAssemblyDocumentDisplayName

        For Each oChildBrowserNode In oParentBrowserNode.BrowserNodes
            'Debug.Print(oChildBrowserNode.FullPath)

            If Right(oChildBrowserNode.FullPath, 2) = "修剪" Then
                Continue For
            End If

            Dim strTypeName As String

            '如果是 修剪 视图，会出错
            'Try
            '    strTypeName = TypeName(oChildBrowserNode.NativeObject)
            '    Debug.Print(TypeName(oChildBrowserNode.NativeObject))
            '    Debug.Print(oChildBrowserNode.BrowserNodeDefinition.Label)

            'Catch ex As Exception

            '    Debug.Print("----------------")

            '    Continue For
            'End Try

            strTypeName = TypeName(oChildBrowserNode.NativeObject)

            Debug.Print(strTypeName)
            Debug.Print(oChildBrowserNode.BrowserNodeDefinition.Label)
            Debug.Print("----------------")

            'If strTypeName Is Nothing Then
            '    Continue For
            'End If

            Select Case strTypeName
                Case "DrawingView", "SectionDrawingView", "DetailDrawingView"   '视图，剖视图，局部视图
                    'If strSelectBrowserNodeLabel = oChildBrowserNode.BrowserNodeDefinition.Label Then    '是选中的视图

                    If InStr(oChildBrowserNode.BrowserNodeDefinition.Label, strSelectBrowserNodeLabel) <> 0 Then    '是选中的视图
                        oSelectViewBrowserNode = oChildBrowserNode
                        Return oSelectViewBrowserNode
                    Else                            '不是选中的视图
                        oSelectViewBrowserNode = GetViewInBrowserNode(oChildBrowserNode, oDrawingView)
                        If oSelectViewBrowserNode IsNot Nothing Then
                            Return oSelectViewBrowserNode
                        End If
                    End If
            End Select
        Next
        Return oSelectViewBrowserNode
    End Function

    ''' <summary>
    ''' 获取被选择的组件节点
    ''' </summary>
    ''' <param name="oParentBrowserNode">部件所在视图的 node</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetAssemblyInBrowserNode(ByVal oParentBrowserNode As BrowserNode) As BrowserNode
        'On Error Resume Next

        ' MessageBox.Show("要获取  " & oParentBrowserNode.FullPath)

        Dim oChildBrowserNode As BrowserNode
        Dim oSelectBrowserNode As BrowserNode = Nothing

        For Each oChildBrowserNode In oParentBrowserNode.BrowserNodes

            Debug.Print(oChildBrowserNode.FullPath)

            'oChildBrowserNode.DoSelect()

            If oChildBrowserNode.BrowserNodeDefinition.Label = "修剪" Then
                Continue For
            End If

            'Try
            Debug.Print(TypeName(oChildBrowserNode.NativeObject))
            Debug.Print(oChildBrowserNode.BrowserNodeDefinition.Label)
            'Catch ex As Exception

            'End Try

            Debug.Print("----------------")

            Dim strTypeName As String = TypeName(oChildBrowserNode.NativeObject)

            Select Case strTypeName
                Case "DrawingView"

                Case "WeldmentComponentDefinition", "AssemblyComponentDefinition"， "DetailDrawingView"      '焊接件 ， 部件
                    oSelectBrowserNode = oChildBrowserNode
                    Return oSelectBrowserNode
                    Exit For
                Case "DetailDrawingView"       '局部视图
                    oSelectBrowserNode = oChildBrowserNode
                    Return oSelectBrowserNode
                    Exit For
            End Select


        Next

        Return oSelectBrowserNode
    End Function

    ''' <summary>
    ''' 获取被选择的零件节点
    ''' </summary>
    ''' <param name="oParentBrowserNode">零件所在组件的 node</param>
    ''' <param name="strPartName">零件名称</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSelectPartInBrowserNode(ByVal oParentBrowserNode As BrowserNode, ByVal strPartName As String) As BrowserNode
        'On Error Resume Next

        ' MessageBox.Show("要获取 " & oParentBrowserNode.FullPath & "   下的  " & strPartName)

        Dim oChildBrowserNode As BrowserNode
        Dim oSelectBrowserNode As BrowserNode = Nothing

        For Each oChildBrowserNode In oParentBrowserNode.BrowserNodes
            Debug.Print(oChildBrowserNode.FullPath)

            'oChildBrowserNode.DoSelect()

            If Right(oChildBrowserNode.FullPath, 2) = "修剪" Then
                Continue For
            End If

            Dim strTypeName As String
            'Try
            '    Debug.Print(TypeName(oChildBrowserNode.NativeObject))
            '    Debug.Print(oChildBrowserNode.BrowserNodeDefinition.Label)

            '    strTypeName = TypeName(oChildBrowserNode.NativeObject)

            'Catch ex As Exception
            '    Continue For
            'End Try

            Debug.Print(TypeName(oChildBrowserNode.NativeObject))
            Debug.Print(oChildBrowserNode.BrowserNodeDefinition.Label)

            strTypeName = TypeName(oChildBrowserNode.NativeObject)

            If strTypeName Is Nothing Then
                Continue For
            End If
            Debug.Print("----------------")


            Select Case strTypeName
                Case "BrowserFolder"       '文件夹
                    oSelectBrowserNode = GetSelectPartInBrowserNode(oChildBrowserNode, strPartName)
                    If oSelectBrowserNode IsNot Nothing Then
                        Return oSelectBrowserNode
                        Exit For
                    End If


                Case "ComponentOccurrence"   '组件

                    Dim oComponentOccurrence As Inventor.ComponentOccurrence
                    oComponentOccurrence = oChildBrowserNode.NativeObject

                    Select Case oComponentOccurrence.DefinitionDocumentType    '判断node对应的文件类型

                        Case DocumentTypeEnum.kAssemblyDocumentObject   '是部件
                            oSelectBrowserNode = GetSelectPartInBrowserNode(oChildBrowserNode, strPartName)
                            If oSelectBrowserNode IsNot Nothing Then
                                Return oSelectBrowserNode
                                Exit For
                            End If

                        Case DocumentTypeEnum.kPartDocumentObject    '是零件
                            If oChildBrowserNode.BrowserNodeDefinition.Label = strPartName Then
                                oSelectBrowserNode = oChildBrowserNode
                                Return oSelectBrowserNode
                                Exit For
                            End If

                    End Select

                Case "RectangularOccurrencePattern", "CircularOccurrencePattern"    '矩形阵列 ，环形阵列
                    oSelectBrowserNode = GetSelectPartInOccurrencePattern(oChildBrowserNode, strPartName)

                    If oSelectBrowserNode IsNot Nothing Then
                        Return oSelectBrowserNode
                    End If
            End Select

        Next

        Return oSelectBrowserNode
    End Function


    Private Function GetSelectPartInOccurrencePattern(ByVal oOccurrencePatternBrowserNode As BrowserNode,
                                                      ByVal strPartName As String) As BrowserNode
        Dim oChildBrowserNode As BrowserNode
        Dim oSelectBrowserNode As BrowserNode

        For Each oChildBrowserNode In oOccurrencePatternBrowserNode.BrowserNodes

            Debug.Print(oChildBrowserNode.FullPath)
            Debug.Print(TypeName(oChildBrowserNode.NativeObject))
            Debug.Print(oChildBrowserNode.BrowserNodeDefinition.Label)


            Dim strTypeName As String



            strTypeName = TypeName(oChildBrowserNode.NativeObject)

            If strTypeName Is Nothing Then
                Continue For
            End If
            Debug.Print("----------------")

            Select Case strTypeName
                Case "ComponentOccurrence"   '组件

                    Dim oComponentOccurrence As Inventor.ComponentOccurrence
                    oComponentOccurrence = oChildBrowserNode.NativeObject

                    Select Case oComponentOccurrence.DefinitionDocumentType    '判断node对应的文件类型

                        Case DocumentTypeEnum.kAssemblyDocumentObject   '是部件
                            oSelectBrowserNode = GetSelectPartInBrowserNode(oChildBrowserNode, strPartName)
                            If oSelectBrowserNode IsNot Nothing Then
                                Return oSelectBrowserNode
                                Exit For
                            End If

                        Case DocumentTypeEnum.kPartDocumentObject    '是零件
                            If oChildBrowserNode.BrowserNodeDefinition.Label = strPartName Then
                                oSelectBrowserNode = oChildBrowserNode
                                Return oSelectBrowserNode
                                Exit For
                            End If

                    End Select

                Case "RectangularOccurrencePattern", "CircularOccurrencePattern", "OccurrencePatternElement" '矩形阵列 ，环形阵列
                    oSelectBrowserNode = GetSelectPartInOccurrencePattern(oChildBrowserNode, strPartName)

                    If oSelectBrowserNode IsNot Nothing Then
                        Return oSelectBrowserNode
                    End If

                    'Case 
                    '    oSelectBrowserNode = GetSelectPartInOccurrencePatternElement(oChildBrowserNode, strPartName)

                    '    If oSelectBrowserNode IsNot Nothing Then
                    '        Return oSelectBrowserNode
                    '    End If
            End Select

        Next
        Return Nothing

    End Function

    Private Function GetSelectPartInOccurrencePatternElement(ByVal oOccurrencePatternBrowserNode As BrowserNode,
                                                    ByVal strPartName As String) As BrowserNode


        Dim oChildBrowserNode As BrowserNode
        Dim oSelectBrowserNode As BrowserNode

        For Each oChildBrowserNode In oOccurrencePatternBrowserNode.BrowserNodes

            Debug.Print(oChildBrowserNode.FullPath)
            Debug.Print(TypeName(oChildBrowserNode.NativeObject))
            Debug.Print(oChildBrowserNode.BrowserNodeDefinition.Label)

            Dim strTypeName As String
            strTypeName = TypeName(oChildBrowserNode.NativeObject)

            If strTypeName Is Nothing Then
                Continue For
            End If
            Debug.Print("----------------")

            Select Case strTypeName
                Case "ComponentOccurrence"   '组件

                    Dim oComponentOccurrence As Inventor.ComponentOccurrence
                    oComponentOccurrence = oChildBrowserNode.NativeObject

                    Select Case oComponentOccurrence.DefinitionDocumentType    '判断node对应的文件类型

                        Case DocumentTypeEnum.kAssemblyDocumentObject   '是部件
                            oSelectBrowserNode = GetSelectPartInBrowserNode(oChildBrowserNode, strPartName)
                            If oSelectBrowserNode IsNot Nothing Then
                                Return oSelectBrowserNode
                                Exit For
                            End If

                        Case DocumentTypeEnum.kPartDocumentObject    '是零件
                            If oChildBrowserNode.BrowserNodeDefinition.Label = strPartName Then
                                oSelectBrowserNode = oChildBrowserNode
                                Return oSelectBrowserNode
                                Exit For
                            End If
                    End Select
            End Select
        Next

        Return Nothing
    End Function
End Module
