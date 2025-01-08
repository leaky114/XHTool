Imports Inventor

Module BrowserNodes

    ''' <summary>
    ''' 获取所选 线 的 node
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SelectPartNodeInBrowserNode()
        'On Error Resume Next

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveEditDocument

        Dim oSelectSet1 As Object = Nothing

        oSelectSet1 = oInventorDocument.SelectSet.Item(1)

        If Not TypeOf oSelectSet1 Is DrawingCurveSegment Then
            Exit Sub
        End If

        Dim oDrawingCurveSegment As DrawingCurveSegment
        oDrawingCurveSegment = CType(oSelectSet1, DrawingCurveSegment)

        Dim oDrawingCurve As DrawingCurve
        oDrawingCurve = oDrawingCurveSegment.Parent

        Dim oSelectDrawingView As Inventor.DrawingView
        oSelectDrawingView = oDrawingCurve.Parent

        'MsgBox("选择的视图  " & oSelectDrawingView.Name)

        ' Set a reference to the parent component occurrence
        Dim oOcc As ComponentOccurrence
        oOcc = oDrawingCurve.ModelGeometry.ContainingOccurrence


        Dim strPartName As String = oOcc.Name

        'MsgBox(" 选择的零件   " & strPartName)

        Dim oTopBrowserNode As Inventor.BrowserNode
        oTopBrowserNode = oInventorDocument.BrowserPanes.ActivePane.TopNode      '顶级node


        'MsgBox(oTopBrowserNode.FullPath)
        'oTopBrowserNode.DoSelect()

        Dim oChildBrowserNode As BrowserNode = Nothing

        Dim oViewBrowserNode As BrowserNode = Nothing


        For Each oChildBrowserNode In oTopBrowserNode.BrowserNodes
            Debug.Print(oChildBrowserNode.FullPath)
            Debug.Print(TypeName(oChildBrowserNode))

            'MsgBox(oChildBrowserNode.FullPath)
            'oChildBrowserNode.DoSelect()

            If TypeName(oChildBrowserNode.NativeObject) = "Sheet" Then        '获取图纸 node
                oViewBrowserNode = GetViewInBrowserNode(oChildBrowserNode, oSelectDrawingView)     '获取被选中的视图 node

                If Not oViewBrowserNode Is Nothing Then
                    'oViewBrowserNode.DoSelect()

                    ''MsgBox(" 获取到被选中的视图     " & oViewBrowserNode.FullPath)

                    Exit For
                End If
            End If
        Next

        Dim oAssemblyBrowserNode As BrowserNode = Nothing

        If Not oViewBrowserNode Is Nothing Then
            oAssemblyBrowserNode = GetAssemblyInBrowserNode(oViewBrowserNode)         '获取视图链接的部件 node
            'oAssemblyBrowserNode.DoSelect()

            'MsgBox(oAssemblyBrowserNode.FullPath)

        End If

        Dim oPartBrowserNode As BrowserNode = Nothing

        If Not oAssemblyBrowserNode Is Nothing Then
            oPartBrowserNode = GetPartInBrowserNode(oAssemblyBrowserNode, strPartName)     '获取选择的零件 node

            'MsgBox(oPartBrowserNode.FullPath)

        End If

        If Not oPartBrowserNode Is Nothing Then
            oPartBrowserNode.Parent.Expanded = True
            oPartBrowserNode.DoSelect()
        End If

    End Sub

    ''' <summary>
    ''' 获取被选中的view的 node
    ''' </summary>
    ''' <param name="oParentBrowserNode">最顶端的node</param>
    ''' <param name="oDrawingView">被选中的视图</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetViewInBrowserNode(ByVal oParentBrowserNode As BrowserNode, ByVal oDrawingView As Inventor.DrawingView) As BrowserNode
        'On Error Resume Next

        'MsgBox("要获取  " & oParentBrowserNode.FullPath & "  下的   " & oDrawingView.Name)

        Dim oChildBrowserNode As BrowserNode = Nothing
        Dim oSelectViewBrowserNode As BrowserNode = Nothing

        Dim strInventorAssemblyDocumentDisplayName As String = oDrawingView.ReferencedDocumentDescriptor.DisplayName
        Dim strSelectBrowserNodeLabel As String = oDrawingView.Name    ' & ":" & strInventorAssemblyDocumentDisplayName

        For Each oChildBrowserNode In oParentBrowserNode.BrowserNodes
            'Debug.Print(oChildBrowserNode.FullPath)

            'oChildBrowserNode.DoSelect()

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
                        If Not oSelectViewBrowserNode Is Nothing Then
                            Return oSelectViewBrowserNode
                        End If
                    End If
            End Select
        Next
        Return oSelectViewBrowserNode
    End Function


    ''' <summary>
    ''' 获取组件node
    ''' </summary>
    ''' <param name="oParentBrowserNode">部件所在视图的 node</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAssemblyInBrowserNode(ByVal oParentBrowserNode As BrowserNode) As BrowserNode
        'On Error Resume Next

        'MsgBox("要获取  " & oParentBrowserNode.FullPath)

        Dim oChildBrowserNode As BrowserNode = Nothing
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

                Case "WeldmentComponentDefinition", "AssemblyComponentDefinition"      '焊接件 ， 部件
                    oSelectBrowserNode = oChildBrowserNode
                    Return oSelectBrowserNode
                    Exit For
            End Select


        Next

        Return oSelectBrowserNode
    End Function

    ''' <summary>
    ''' 获取 part 的node
    ''' </summary>
    ''' <param name="oParentBrowserNode">零件所在组件的 node</param>
    ''' <param name="strPartName">零件名称</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPartInBrowserNode(ByVal oParentBrowserNode As BrowserNode, ByVal strPartName As String) As BrowserNode
        'On Error Resume Next

        'MsgBox("要获取 " & oParentBrowserNode.FullPath & "   下的  " & strPartName)

        Dim oChildBrowserNode As BrowserNode = Nothing
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
                    oSelectBrowserNode = GetPartInBrowserNode(oChildBrowserNode, strPartName)
                    If Not oSelectBrowserNode Is Nothing Then
                        Return oSelectBrowserNode
                        Exit For
                    End If


                Case "ComponentOccurrence"   '组件

                    Dim oComponentOccurrence As Inventor.ComponentOccurrence
                    oComponentOccurrence = oChildBrowserNode.NativeObject

                    Select Case oComponentOccurrence.DefinitionDocumentType    '判断node对应的文件类型

                        Case DocumentTypeEnum.kAssemblyDocumentObject   '是部件
                            oSelectBrowserNode = GetPartInBrowserNode(oChildBrowserNode, strPartName)
                            If Not oSelectBrowserNode Is Nothing Then
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

                    For Each oOccurrencePatternBrowserNode As BrowserNode In oChildBrowserNode.BrowserNodes

                        Debug.Print(oOccurrencePatternBrowserNode.FullPath)
                        Debug.Print(TypeName(oOccurrencePatternBrowserNode.NativeObject))
                        Debug.Print(oOccurrencePatternBrowserNode.BrowserNodeDefinition.Label)

                        For Each oOccurrencePatternChildBrowserNode As BrowserNode In oOccurrencePatternBrowserNode.BrowserNodes
                            If oOccurrencePatternChildBrowserNode.BrowserNodeDefinition.Label = strPartName Then
                                oSelectBrowserNode = oOccurrencePatternChildBrowserNode
                                Return oSelectBrowserNode
                                Exit For
                            End If
                        Next

                    Next
            End Select

        Next

        Return oSelectBrowserNode
    End Function


End Module
