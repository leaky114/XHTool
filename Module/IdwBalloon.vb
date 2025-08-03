Imports System.Windows.Forms
Imports Inventor
Imports Inventor.DocumentTypeEnum
Imports Inventor.SelectionFilterEnum

Module IdwBalloon

    ''' <summary>
    ''' 检查序号完整性
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Function CheckSerialNumber() As Boolean
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Function
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MessageBox.Show(”该功能仅适用于工程图。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            Dim oActiveSheet As Sheet
            oActiveSheet = oInventorDrawingDocument.ActiveSheet

            If oActiveSheet.Balloons.Count = 0 Then
                MessageBox.Show("该工程图无序号，请添加【序号】。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）
                Exit Function
            End If

            If oActiveSheet.PartsLists.Count = 0 Then
                MessageBox.Show("该工程图无明细表，请插入一个【明细表】。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）
                Exit Function
            End If

            Dim oPartsListRows As PartsListRows = oActiveSheet.PartsLists.Item(1).PartsListRows

            Dim strList As String = ""

            '撤销功能
            Dim oTransaction As Transaction
            oTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "My Transaction")

            Dim OInteractionEvents As InteractionEvents = ThisApplication.CommandManager.CreateInteractionEvents
            OInteractionEvents.Start()
            OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeWindows, 32514)


            '新建颜色
            Dim oColor As Color
            oColor = ThisApplication.TransientObjects.CreateColor(255, 0, 128)

            'ThisApplication.ScreenUpdating = False

            Dim strPartName As String
            For Each oPartsListRow As Inventor.PartsListRow In oPartsListRows
                If oPartsListRow.Ballooned = False Then
                    strList = strList & oPartsListRow.Item(1).Value & " , "
                End If

                If oPartsListRow.ReferencedFiles.Count <> 0 Then
                    '零件名用 文档的文件名
                    strPartName = GetFileNameInfo(oPartsListRow.ReferencedFiles(1).FullFileName).OnlyName

                    '零件名用 iproporty 的数据
                    'strPartName = GetPropitem(oPartsListRow.ReferencedFiles(1).ReferencedDocument, Map_DrawingNnumber) & GetPropitem(oPartsListRow.ReferencedFiles(1).ReferencedDocument, Map_PartName)

                    SetStatusBarText("正在描绘：" & oPartsListRow.ReferencedFiles(1).FullFileName)
                    '设置颜色
                    SetPartCorlor(oInventorDrawingDocument, strPartName, oColor, oPartsListRow.Ballooned)
                End If
            Next


            'ThisApplication.ScreenUpdating = True

            OInteractionEvents.SetCursor(CursorTypeEnum.kCursorTypeDefault)
            OInteractionEvents.Stop()

            oTransaction.End() '事务结束，完成修改操作

            If Strings.Len(strList) > 1 Then
                MessageBox.Show($"明细表：{strList} 无序号。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information）
            Else
                MessageBox.Show("检查序号完成。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Information)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



        'Return True
    End Function

    ''' <summary>
    ''' 设置工程图零件颜色
    ''' </summary>
    ''' <param name="oInventorDrawingDocument">工程图</param>
    ''' <param name="partStr">零件</param>
    ''' <param name="oColor">颜色</param>
    ''' <param name="oPartsListRowBallooned">是否有序号</param>
    ''' <remarks></remarks>

    Public Sub SetPartCorlor(ByVal oInventorDrawingDocument As Inventor.DrawingDocument, ByVal partStr As String,
                             ByVal oColor As Color, ByVal oPartsListRowBallooned As Boolean)

        'Dim oTransaction As Transaction
        Dim refAssyDef As ComponentDefinition = Nothing

        'oTransaction = ThisApplication.TransactionManager.StartTransaction(oInventorDrawingDocument, "Colorize [PART]")

        '遍历图纸
        For Each oSheet As Sheet In oInventorDrawingDocument.Sheets
            '遍历视图
            For Each oDrawingView As DrawingView In oSheet.DrawingViews

                If oDrawingView.ReferencedDocumentDescriptor.ReferencedDocumentType = DocumentTypeEnum.kPresentationDocumentObject Then
                    refAssyDef = oDrawingView.ReferencedDocumentDescriptor.ReferencedDocument.ReferencedDocuments(1).ComponentDefinition
                ElseIf oDrawingView.ReferencedFile.DocumentType = DocumentTypeEnum.kAssemblyDocumentObject Then
                    refAssyDef = oDrawingView.ReferencedFile.DocumentDescriptor.ReferencedDocument.ComponentDefinition
                End If

                If (refAssyDef Is Nothing) Then
                    Continue For
                End If

                For Each oComponentOccurrence As ComponentOccurrence In refAssyDef.Occurrences
                    If oComponentOccurrence.Name.ToLower() Like partStr.ToLower() & ":*" Then
                        ThisApplication.ScreenUpdating = False
                        Try
                            Dim ViewCurves As DrawingCurvesEnumerator = oDrawingView.DrawingCurves(oComponentOccurrence)

                            Dim oDrawingCurve As DrawingCurve

                            If oPartsListRowBallooned = True Then
                                '已有序号，判断颜色属性
                                '设置颜色
                                Dim oBlackColor As Color = ThisApplication.TransientObjects.CreateColor(0, 0, 0)

                                For Each oDrawingCurve In ViewCurves
                                    Select Case oDrawingCurve.Color.ColorSourceType
                                        Case ColorSourceTypeEnum.kAutomaticColorSource, ColorSourceTypeEnum.kLayerColorSource
                                            Exit For
                                        Case ColorSourceTypeEnum.kOverrideColorSource
                                            oDrawingCurve.Color = Nothing
                                            oDrawingCurve.Color.ColorSourceType = ColorSourceTypeEnum.kLayerColorSource
                                            oDrawingCurve.LineWeight = oDrawingCurve.Segments(1).Layer.LineWeight
                                            'c.Color = oBlackColor
                                    End Select
                                Next
                            Else
                                '没有序号，设置彩色
                                For Each oDrawingCurve In ViewCurves
                                    oDrawingCurve.Color = oColor
                                    oDrawingCurve.LineWeight = oDrawingCurve.Segments(1).Layer.LineWeight
                                Next
                            End If
                        Catch ex As Exception
                        End Try
                        ThisApplication.ScreenUpdating = True
                    End If
                Next
            Next
        Next
        'oTransaction.End()
    End Sub


    ''' <summary>
    ''' 自动重建序号
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RebuildRingSerialNumber() As Boolean
        'Try
        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Function
        End If

        If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
            MessageBox.Show(”该功能仅适用于工程图。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        End If

        Dim oInventorDrawingDocument As Inventor.DrawingDocument
        oInventorDrawingDocument = ThisApplication.ActiveDocument

        '设置为一个动作，可一次撤销
        Dim transientGeometry As TransientGeometry
        transientGeometry = ThisApplication.TransientGeometry
        'start a transaction so the slot will be within a single undo step

        '撤销功能
        Dim oTransaction As Transaction
        oTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "My Transaction")

        Dim oActiveSheet As Sheet
        oActiveSheet = oInventorDrawingDocument.ActiveSheet

        If oActiveSheet.PartsLists.Count = 0 Then
            MessageBox.Show("该工程图无明细表。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）
            Return False
            Exit Function
        End If

        Dim userInput As String = InputBox("输入第一个序号", XHTool, 1)

        Dim intFirstBalloonNumber As Integer
        If String.IsNullOrEmpty(userInput) Then
            Return False
            Exit Function
        Else
            Integer.TryParse(userInput, intFirstBalloonNumber)
        End If

        '开始设置序号

        Dim intBalloonNumber As Integer
        intBalloonNumber = intFirstBalloonNumber

        '获取当前balloonstyle
        Dim oActiveBalloonStyle As BalloonStyle = oInventorDrawingDocument.StylesManager.ActiveStandardStyle.ActiveObjectDefaults.BalloonStyle


        '获取当前balloonstyle的name
        Dim strOldBalloonTextStyleName As String = oActiveBalloonStyle.Name
        '获取旧的 TextStyle
        Dim oOldBalloonTextStyle As TextStyle = oActiveBalloonStyle.TextStyle

        '新建 ZeroBalloonText

        Dim oZeroBalloonTextStyle As TextStyle = Nothing

        Try
            If oInventorDrawingDocument.StylesManager.TextStyles.Item("ZeroBalloonText") Is Nothing Then

            Else
                oZeroBalloonTextStyle = oInventorDrawingDocument.StylesManager.TextStyles.Item("ZeroBalloonText")
            End If
        Catch ex As Exception
            oZeroBalloonTextStyle = oOldBalloonTextStyle.Copy("ZeroBalloonText")

            Dim oZeroBalloonTextColor As Color = ThisApplication.TransientObjects.CreateColor(255, 0, 128)
            oZeroBalloonTextStyle.Color = oZeroBalloonTextColor
        End Try

        '设置当前balloon style 为新的 zeroballoonstyle
        oActiveBalloonStyle.TextStyle = oZeroBalloonTextStyle ' oInventorDrawingDocument.StylesManager.TextStyles.Item("ZeroBalloonText")


        Try
            Dim oDrawingView As DrawingView
            Do

                Dim ofirstballoon As Balloon
                ofirstballoon = ThisApplication.CommandManager.Pick(kDrawingBalloonFilter, "选择一个序号，ESC键取消")

                oDrawingView = ofirstballoon.ParentView

                'oDrawingView = ThisApplication.CommandManager.Pick(kDrawingViewFilter, "选择一个视图，ESC键取消")

                '100个临时balloon
                Dim arrayTempBalloonDate(99) As BalloonDate
                ' MessageBox.Show(oDrawingView.Name)

                '视图中心点
                Dim oCenterPoint2d As Point2d
                oCenterPoint2d = oDrawingView.Position

                Dim i As Integer = 0

                '获取当前视图中的balloon
                Dim oBalloon As Balloon
                For Each oBalloon In oActiveSheet.Balloons

                    ThisApplication.ScreenUpdating = False

                    For Each oBalloonValueSet As BalloonValueSet In oBalloon.BalloonValueSets
                        If oBalloonValueSet.Value >= intBalloonNumber Then
                            oBalloonValueSet.Value = 0
                        End If
                    Next

                    ThisApplication.ScreenUpdating = True

                    If oBalloon.ParentView Is oDrawingView Then

                        arrayTempBalloonDate(i).Balloon = oBalloon
                        arrayTempBalloonDate(i).Position = oBalloon.Position
                        arrayTempBalloonDate(i).Position.X = oBalloon.Position.X - oCenterPoint2d.X
                        arrayTempBalloonDate(i).Position.Y = oBalloon.Position.Y - oCenterPoint2d.Y
                        i = i + 1
                    End If

                Next

                '获取视图包含的balloon个数
                Dim intArrayBalloonDateLength As Integer
                intArrayBalloonDateLength = Array.IndexOf(arrayTempBalloonDate, Nothing)

                '重新定义balloon数组
                Array.Resize(arrayTempBalloonDate, intArrayBalloonDateLength)

                ' MessageBox.Show(“”)

                '计算角度
                For i = 0 To intArrayBalloonDateLength - 1
                    'Debug.Print(arrayTempBalloonDate(i).Position.X & "       " & arrayTempBalloonDate(i).Position.Y)
                    arrayTempBalloonDate(i).Angles = FourFive(arrayTempBalloonDate(i).Position.X / arrayTempBalloonDate(i).Position.Y, 6)
                Next

                'Debug.Print("")

                Dim j As Integer
                Dim tempBalloondate As BalloonDate

                '=============================================
                '按X值开始排序

                'For i = 0 To intArrayBalloonDateLength - 1
                '    For j = 0 To intArrayBalloonDateLength - 2
                '        if arrayTempBalloonDate(j).Position.X > arrayTempBalloonDate(j + 1).Position.X Then
                '            tempBalloondate = arrayTempBalloonDate(j)
                '            arrayTempBalloonDate(j) = arrayTempBalloonDate(j + 1)
                '            arrayTempBalloonDate(j + 1) = tempBalloondate
                '        End if
                '    Next
                'Next
                '=============================================
                '按极角排序

                Select Case str逆时针序号
                    Case "-1"
                        For i = 0 To intArrayBalloonDateLength - 1
                            For j = 0 To intArrayBalloonDateLength - 2
                                If Math.Atan2(arrayTempBalloonDate(j).Position.Y, arrayTempBalloonDate(j).Position.X) <
                                        Math.Atan2(arrayTempBalloonDate(j + 1).Position.Y, arrayTempBalloonDate(j + 1).Position.X) Then
                                    tempBalloondate = arrayTempBalloonDate(j)
                                    arrayTempBalloonDate(j) = arrayTempBalloonDate(j + 1)
                                    arrayTempBalloonDate(j + 1) = tempBalloondate
                                End If
                            Next
                        Next
                    Case "1"     '顺时针序号
                        For i = 0 To intArrayBalloonDateLength - 1
                            For j = 0 To intArrayBalloonDateLength - 2
                                If Math.Atan2(arrayTempBalloonDate(j).Position.Y, arrayTempBalloonDate(j).Position.X) >
                                        Math.Atan2(arrayTempBalloonDate(j + 1).Position.Y, arrayTempBalloonDate(j + 1).Position.X) Then
                                    tempBalloondate = arrayTempBalloonDate(j)
                                    arrayTempBalloonDate(j) = arrayTempBalloonDate(j + 1)
                                    arrayTempBalloonDate(j + 1) = tempBalloondate
                                End If
                            Next
                        Next
                End Select
                '=============================================
                'For i = 0 To intArrayBalloonDateLength - 1
                '    Debug.Print(arrayTempBalloonDate(i).Position.X & "       " & arrayTempBalloonDate(i).Position.Y)
                'Next

                '重新写序号
                'Dim ofirstballoon As Balloon
                'ofirstballoon = ThisApplication.CommandManager.Pick(kDrawingBalloonFilter, "选择第一个序号，ESC键取消")

                '选择的balloon在数组中的位置
                Dim intfirstballoon As Integer

                For j = 0 To intArrayBalloonDateLength - 1
                    If arrayTempBalloonDate(j).Balloon Is ofirstballoon Then
                        intfirstballoon = j
                    End If
                Next

                For j = intfirstballoon To intArrayBalloonDateLength - 1
                    oBalloon = arrayTempBalloonDate(j).Balloon
                    For Each oBalloonValueSet As BalloonValueSet In oBalloon.BalloonValueSets
                        If oBalloonValueSet.Value = 0 Then
                            oBalloonValueSet.Value = intBalloonNumber
                            intBalloonNumber = intBalloonNumber + 1
                        End If
                    Next
                Next j

                For j = 0 To intfirstballoon
                    oBalloon = arrayTempBalloonDate(j).Balloon
                    For Each oBalloonValueSet As BalloonValueSet In oBalloon.BalloonValueSets
                        If oBalloonValueSet.Value = 0 Then
                            oBalloonValueSet.Value = intBalloonNumber
                            intBalloonNumber = intBalloonNumber + 1
                        End If
                    Next
                Next j

                'end the transactio

            Loop While True

        Catch ex As Exception

            'esc 退出后，还原balloon style

            oActiveBalloonStyle.TextStyle = oOldBalloonTextStyle
            'oActiveBalloonStyle.SaveToGlobal()

            ''要暂停，不然报错
            'Threading.Thread.Sleep(3000)

        End Try


        SetStatusBarText("重建序号完成")
        ' MessageBox.Show("设置工程图自定义属性：比例完成", MsgBoxStyle.Information)

        'If  MessageBox.Show("明细栏是否排序？", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then

        ReWriteBOM()


        'End If

        '事务结束，完成修改操作
        oTransaction.End()
        'Catch ex As Exception
        '       MessageBox.Show(ex.Message, xhtool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

    End Function


    ''' <summary>
    ''' 新建序号
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CreateNewSequenceNumber()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MessageBox.Show(”该功能仅适用于工程图。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            '撤销功能
            Dim oTransaction As Transaction
            oTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "My Transaction")

            Dim oActiveSheet As Sheet
            oActiveSheet = oInventorDrawingDocument.ActiveSheet

            If oActiveSheet.PartsLists.Count = 0 Then
                MessageBox.Show("该工程图无明细表", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）
                Exit Sub
            End If

            Dim strFirstBalloonNumber As String = InputBox("输入第一个序号", XHTool, 1)
            Dim intFirstBalloonNumber As Integer

            If String.IsNullOrEmpty(strFirstBalloonNumber) Then
                Exit Sub
            Else
                Integer.TryParse(strFirstBalloonNumber, intFirstBalloonNumber)
            End If

            Dim intBalloonNumber As Integer
            intBalloonNumber = intFirstBalloonNumber

            '        '设置序号为0
            'Dim partslistrow As Inventor.PartsListRow

            ThisApplication.ScreenUpdating = False

            For Each oPartsListRow As Inventor.PartsListRow In oActiveSheet.PartsLists.Item(1).PartsListRows
                If oPartsListRow.Item(1).Value >= intFirstBalloonNumber Then
                    oPartsListRow.Item(1).Value = 0
                End If
            Next

            ThisApplication.ScreenUpdating = True

            '获取当前序号样式
            Dim oActiveBalloonStyle As BalloonStyle = oInventorDrawingDocument.StylesManager.ActiveStandardStyle.ActiveObjectDefaults.BalloonStyle


            '获取当前序号样式名称
            Dim strOldBalloonTextStyleName As String = oActiveBalloonStyle.Name

            '保存当前序号文字样式
            Dim oOldBalloonTextStyle As TextStyle = oActiveBalloonStyle.TextStyle

            '新建 ZeroBalloonText

            Dim oZeroBalloonTextStyle As TextStyle = Nothing

            Try
                If oInventorDrawingDocument.StylesManager.TextStyles.Item("ZeroBalloonText") Is Nothing Then

                Else
                    oZeroBalloonTextStyle = oInventorDrawingDocument.StylesManager.TextStyles.Item("ZeroBalloonText")
                End If
            Catch ex As Exception

                '  oZeroBalloonText = oInventorDrawingDocument.StylesManager.TextStyles.Item(strOldBalloonTextStyleName).Copy("ZeroBalloonText")

                oZeroBalloonTextStyle = oOldBalloonTextStyle.Copy("ZeroBalloonText")

                Dim oZeroBalloonTextColor As Color = ThisApplication.TransientObjects.CreateColor(255, 0, 128)
                oZeroBalloonTextStyle.Color = oZeroBalloonTextColor
            End Try

            '设置当前balloonstyle 的  文字样式 为新的 ZeroBalloonText
            oActiveBalloonStyle.TextStyle = oZeroBalloonTextStyle   ' oInventorDrawingDocument.StylesManager.TextStyles.Item("ZeroBalloonText")

            '点击每个序号组

            '点击每个序号组
            Try
                Dim oBalloon As Balloon
                Do
                    oBalloon = ThisApplication.CommandManager.Pick(kDrawingBalloonFilter, "选择引出序号，ESC键取消")

                    If oBalloon Is Nothing Then
                        Exit Do
                    End If

                    For Each oBalloonValueSet As BalloonValueSet In oBalloon.BalloonValueSets
                        'if (oBalloonValueSet.Value >= FirstBalloonNumber) Then
                        If oBalloonValueSet.Value = 0 Then
                            oBalloonValueSet.Value = intBalloonNumber
                            intBalloonNumber = intBalloonNumber + 1
                        End If
                    Next
                Loop While True
            Catch ex As Exception


            End Try

            oActiveBalloonStyle.TextStyle = oOldBalloonTextStyle

            'If MessageBox.Show("是否重写BOM序号？", XHTool, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            '                   MessageBoxDefaultButton.Button1) = vbYes Then
            '    'Threading.Thread.Sleep(2000)
            ReWriteBOM()
            'End If



            oTransaction.End() '事务结束，完成修改操作
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 重写BOM序号
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ReWriteBOM()
        Try
            SetStatusBarText()

            If IsInventorOpenDocument() = False Then
                Exit Sub
            End If

            If ThisApplication.ActiveDocumentType <> kDrawingDocumentObject Then
                MessageBox.Show(”该功能仅适用于工程图。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim oInventorDrawingDocument As Inventor.DrawingDocument
            oInventorDrawingDocument = ThisApplication.ActiveDocument

            Dim oActiveSheet As Sheet
            oActiveSheet = oInventorDrawingDocument.ActiveSheet

            If oActiveSheet.PartsLists.Count = 0 Then
                MessageBox.Show("该工程图无明细表。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）
                Exit Sub
            End If

            Dim oPartsList As PartsList
            oPartsList = oActiveSheet.PartsLists.Item(1)
            oPartsList.SaveItemOverridesToBOM()
            oPartsList.Sort("序号", True)

        Catch ex As Exception
            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ''' <summary>
    ''' 修改序号，选择一个 Balloon，输入修改后的序号
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ModifySerialNumber()


        SetStatusBarText()

        If IsInventorOpenDocument() = False Then
            Exit Sub
        End If

        Dim oInventorDocument As Inventor.Document
        oInventorDocument = ThisApplication.ActiveDocument

        If oInventorDocument.DocumentType <> kDrawingDocumentObject Then
            MessageBox.Show(”该功能仅适用于工程图。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim oInventorDrawingDocument As Inventor.DrawingDocument
        oInventorDrawingDocument = oInventorDocument

        '设置为一个动作，可一次撤销
        Dim oTransientGeometry As TransientGeometry
        oTransientGeometry = ThisApplication.TransientGeometry
        'start a transaction so the slot will be within a single undo step

        Dim oTransaction As Transaction
        oTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "修改序号")

        Dim oActiveSheet As Sheet
        oActiveSheet = oInventorDrawingDocument.ActiveSheet

        If oActiveSheet.PartsLists.Count = 0 Then
            MessageBox.Show("该工程图无明细表。", XHTool， MessageBoxButtons.OK， MessageBoxIcon.Error）
            Exit Sub
        End If

        Dim partsList As Inventor.PartsList = oActiveSheet.PartsLists.Item(1)

        Try
            Dim txtOldNumber As String = Nothing

            If oInventorDrawingDocument.SelectSet.Count <> 0 Then
                For Each oSelectSet As Object In oInventorDrawingDocument.SelectSet
                    If oSelectSet.Type = ObjectTypeEnum.kBalloonObject Then
                        Dim oBalloon As Balloon = CType(oSelectSet, Balloon)

                        If oBalloon.BalloonValueSets.Count = 1 Then
                            txtOldNumber = oBalloon.BalloonValueSets.Item(1).Value
                        Else
                            txtOldNumber = InputBox("选择的序号有附着序号，输入目标序号：")
                        End If
                    End If
                Next
            Else
                txtOldNumber = InputBox("输入目标序号：")
            End If

            Dim inputNumber As Integer = Integer.Parse(txtOldNumber) ' 替换为实际输入源

            ' 查找目标行
            Dim targetRow As Inventor.PartsListRow = FindRowByNumber(partsList, inputNumber)

            ' 用户输入的新序号

            Dim txtNewNumber As String = InputBox("输入新的序号:")
            Dim newNumber As Integer = Integer.Parse(txtNewNumber) ' 替换为实际输入源

            ' 执行修改
            UpdatePartNumber(targetRow, newNumber)

            ReWriteBOM()

            oTransaction.End()
        Catch ex As FormatException
            MessageBox.Show(”请输入有效的数字格式“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As ArgumentException

            MessageBox.Show(ex.Message, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        'Try
        '    SetStatusBarText()

        '    If IsInventorOpenDocument() = False Then
        '        Exit Sub
        '    End If

        '    Dim oInventorDocument As Inventor.Document
        '    oInventorDocument = ThisApplication.ActiveDocument

        '    If oInventorDocument.DocumentType <> kDrawingDocumentObject Then
        '         MessageBox.Show("该功能仅适用于工程图。", MsgBoxStyle.Information)
        '        Exit Sub
        '    End If

        '    Dim oInventorDrawingDocument As Inventor.DrawingDocument
        '    oInventorDrawingDocument = oInventorDocument

        '    '设置为一个动作，可一次撤销
        '    Dim oTransientGeometry As TransientGeometry
        '    oTransientGeometry = ThisApplication.TransientGeometry
        '    'start a transaction so the slot will be within a single undo step

        '    Dim oTransaction As Transaction
        '    oTransaction = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "修改序号")

        '    Dim oActiveSheet As Sheet
        '    oActiveSheet = oInventorDrawingDocument.ActiveSheet

        '    If oActiveSheet.PartsLists.Count = 0 Then
        '         MessageBox.Show("该工程图无明细表。", MsgBoxStyle.Critical)
        '        Exit Sub
        '    End If

        '    '点击被插入的序号标识
        '    Dim oBalloon As Balloon
        '    oBalloon = ThisApplication.CommandManager.Pick(kDrawingBalloonFilter, "选择被修改的序号标识，ESC取消。")

        '    If oBalloon Is Nothing Then
        '        Exit Sub
        '    End If

        '    Dim intOldBalloonValue As Integer

        '    If oBalloon.BalloonValueSets.Count = 1 Then
        '        intOldBalloonValue = oBalloon.BalloonValueSets.Item(1).Value
        '    Else


        '    End If



        '    Dim intNewBalloonValue As Integer
        '    intNewBalloonValue = InputBox("输入新的序号。")

        '    Dim oPartsListRow As Inventor.PartsListRow = Nothing

        '    If intOldBalloonValue < intNewBalloonValue Then     '序号变大
        '        For Each oPartsListRow In oActiveSheet.PartsLists.Item(1).PartsListRows

        '            If oPartsListRow.Item(1).Value = intOldBalloonValue Then
        '                oPartsListRow.Item(1).Value = intNewBalloonValue
        '            End If


        '            If oPartsListRow.Item(1).Value > intOldBalloonValue And oPartsListRow.Item(1).Value < intNewBalloonValue Then
        '                oPartsListRow.Item(1).Value = oPartsListRow.Item(1).Value + 1
        '            End If

        '            If oPartsListRow.Item(1).Value = intNewBalloonValue Then
        '                oPartsListRow.Item(1).Value = intOldBalloonValue
        '            End If



        '            'oBalloon.BalloonValueSets.Item(1).Value = intNewBalloonValue

        '        Next
        '    ElseIf intOldBalloonValue > intNewBalloonValue Then   '序号变小
        '        For Each oPartsListRow In oActiveSheet.PartsLists.Item(1).PartsListRows
        '            If oPartsListRow.Item(1).Value >= intNewBalloonValue And oPartsListRow.Item(1).Value <= intOldBalloonValue Then
        '                oPartsListRow.Item(1).Value = oPartsListRow.Item(1).Value + 1
        '            End If
        '        Next

        '        If oPartsListRow.Item(1).Value = intNewBalloonValue Then
        '            oPartsListRow.Item(1).Value = intOldBalloonValue
        '        End If

        '        ' oBalloon.BalloonValueSets.Item(1).Value = intNewBalloonValue

        '    Else
        '        Exit Sub
        '    End If

        '    ReWriteBOM()

        ''    oTransaction.End()
        'Catch ex As Exception
        '    ' MessageBox.Show(ex.Message)
        'End Try
    End Sub

    ''' <summary>
    ''' 调整明细栏行的序号
    ''' </summary>
    ''' <param name="targetRow">被调整的明细栏列对象</param>
    ''' <param name="newNum">新的序号</param>
    Public Sub UpdatePartNumber(ByVal targetRow As Inventor.PartsListRow, ByVal newNum As Integer)
        Dim oldNum As Integer = targetRow.Item(1).Value

        If oldNum = newNum Then
            Return ' 无需修改
        End If

        Dim oPartsListRows As Inventor.PartsListRows = targetRow.Parent.PartsListRows

        ' 调整其他行的序号
        If newNum > oldNum Then
            ' 处理比旧序号大但不超过新序号的行，排除目标行
            For Each oPartsListRow As Inventor.PartsListRow In oPartsListRows
                If oPartsListRow IsNot targetRow AndAlso oPartsListRow.Item(1).Value > oldNum AndAlso
                    oPartsListRow.Item(1).Value <= newNum Then
                    oPartsListRow.Item(1).Value -= 1
                End If
            Next
        Else
            ' 处理比新序号大但小于旧序号的行，排除目标行
            For Each oPartsListRow As Inventor.PartsListRow In oPartsListRows
                If oPartsListRow IsNot targetRow AndAlso oPartsListRow.Item(1).Value >= newNum AndAlso
                    oPartsListRow.Item(1).Value < oldNum Then
                    oPartsListRow.Item(1).Value += 1
                End If
            Next
        End If

        ' 最后更新目标行的序号
        targetRow.Item(1).Value = newNum
    End Sub

    ''' <summary>
    ''' 根据序号查找目标行
    ''' </summary>
    ''' <param name="partsList">明细栏对象</param>
    ''' <param name="targetNumber">被查找的序号</param>
    ''' <returns>返回被找到的明细栏 列</returns>
    Public Function FindRowByNumber(ByVal partsList As Inventor.PartsList, ByVal targetNumber As Integer) As Inventor.PartsListRow
        For Each oPartsListRow As Inventor.PartsListRow In partsList.PartsListRows
            If oPartsListRow.Item(1).Value = targetNumber Then
                Return oPartsListRow
            End If
        Next
        Throw New ArgumentException($"未找到序号为 {targetNumber} 的行。")
    End Function

    ''' <summary>
    ''' 创建工程图明细表
    ''' </summary>
    Public Sub CreatePartsList(oInventorDrawingDocument As Inventor.DrawingDocument)
        Dim osheet As Sheet
        osheet = oInventorDrawingDocument.ActiveSheet

        Dim oBorder As Border = osheet.Border
        Dim oTitleBlock As TitleBlock = osheet.TitleBlock
        Dim oPlacementPoint As Point2d

        'If oBorder IsNot Nothing Then
        '    If oTitleBlock IsNot Nothing Then
        '    oPlacementPoint = ThisApplication.TransientGeometry.CreatePoint2d(oTitleBlock.RangeBox.MaxPoint.X, oTitleBlock.RangeBox.MaxPoint.Y)
        'Else
        '        oPlacementPoint = oBorder.RangeBox.MinPoint
        '    End If
        'Else
        'there is no border. The placement point
        'is the top-right corner of the sheet
        ' oPlacementPoint = ThisApplication.TransientGeometry.CreatePoint2d(osheet.Width, osheet.Height)

        oPlacementPoint = ThisApplication.TransientGeometry.CreatePoint2d(0, 0)

        'End If

        Dim oDrawingView As DrawingView = oInventorDrawingDocument.ActiveSheet.DrawingViews.Item(1)
        Dim oPartsList As PartsList
        Try
            oPartsList = oInventorDrawingDocument.ActiveSheet.PartsLists.Add(oDrawingView, oPlacementPoint, PartsListLevelEnum.kStructured, Nothing, 1, True)
        Catch
            oPartsList = oInventorDrawingDocument.ActiveSheet.PartsLists.Add(oDrawingView, oPlacementPoint, PartsListLevelEnum.kStructuredAllLevels, Nothing, 1, True)
        End Try

        Try
            oPartsList.Position = ThisApplication.TransientGeometry.CreatePoint2d(
            oTitleBlock.RangeBox.MinPoint.X + oPartsList.RangeBox.MaxPoint.X - oPartsList.RangeBox.MinPoint.X,
            oTitleBlock.RangeBox.MaxPoint.Y + oPartsList.RangeBox.MaxPoint.Y - oPartsList.RangeBox.MinPoint.Y)
        Catch
            oPartsList.Position = ThisApplication.TransientGeometry.CreatePoint2d(0, 0)
        End Try

        oPartsList.Sort("序号")
        oPartsList.Renumber()
        oPartsList.SaveItemOverridesToBOM()

    End Sub

End Module
