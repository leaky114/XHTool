Imports System.Windows.Forms
Imports Inventor
Imports Inventor.DocumentTypeEnum
Imports Inventor.SelectionFilterEnum
Imports Inventor.SelectTypeEnum
Imports Inventor.ObjectTypeEnum

Imports System.Drawing
Imports System.ComponentModel
Imports System.IO

Public Class FormDim2Object
    Private oSelect1 As Object
    Private oSelect2 As Object
    Private oHSet1 As HighlightSet
    Private oHSet2 As HighlightSet
    Private IsStop As Boolean

    Private Sub Btn选择一_Click(sender As Object, e As EventArgs) Handles btn选择一项.Click
        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveEditDocument

        If oHSet1.Count <> 0 Then
            oHSet1.Clear()
        End If

        oSelect1 = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kAllEntitiesFilter, "选择第一个项，ESC键取消")
        If oSelect1 Is Nothing Then       '取消选择
            Exit Sub
        End If

        oHSet1.AddItem(oSelect1)

        If (oSelect1 Is Nothing) Or (oSelect2 Is Nothing) Then
            Exit Sub
        End If

        If RadioButton距离.Checked = True Then
            Dim douDistance As Double
            douDistance = ThisApplication.MeasureTools.GetMinimumDistance(oSelect1, oSelect2)
            douDistance = Math.Round(ThisApplication.ActiveDocument.UnitsOfMeasure.ConvertUnits(douDistance, "cm", "mm"), 3)
            lbl距离.Text = "距离：" & douDistance.ToString
        Else
            Dim douAngle As Double
            douAngle = FourFive(ThisApplication.MeasureTools.GetAngle(oSelect1, oSelect2) * 180 / Math.PI, 3)
            lbl距离.Text = "角度：" & douAngle.ToString
        End If

    End Sub

    Private Sub Btn选择二_Click(sender As Object, e As EventArgs) Handles btn选择二项.Click
        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveEditDocument

        If oHSet2.Count <> 0 Then
            oHSet2.Clear()
        End If

        'oInventorAssemblyDocument.Update()

        oSelect2 = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kAllEntitiesFilter, "选择第二个项，ESC键取消")
        If oSelect2 Is Nothing Then       '取消选择
            Exit Sub
        End If

        oHSet2.AddItem(oSelect2)

        If (oSelect1 Is Nothing) Or (oSelect2 Is Nothing) Then
            Exit Sub
        End If

        If RadioButton距离.Checked = True Then
            Dim douDistance As Double
            douDistance = ThisApplication.MeasureTools.GetMinimumDistance(oSelect1, oSelect2)
            douDistance = Math.Round(ThisApplication.ActiveDocument.UnitsOfMeasure.ConvertUnits(douDistance, "cm", "mm"), 3)
            lbl距离.Text = "距离：" & douDistance.ToString
        Else
            Dim douAngle As Double
            douAngle = FourFive(ThisApplication.MeasureTools.GetAngle(oSelect1, oSelect2) * 180 / Math.PI, 3)
            lbl距离.Text = "角度：" & douAngle.ToString
        End If

    End Sub

    Private Sub FrmDim2Object_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        On Error Resume Next
        If oHSet1.Count <> 0 Then oHSet1.Clear()
        If oHSet2.Count <> 0 Then oHSet2.Clear()

    End Sub

    Private Sub FrmDim2Object_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.XHTool48
        ' 创建ToolTip控件并设置相关属性
        Dim toolTip As New ToolTip With {
            .AutoPopDelay = 0,
            .InitialDelay = 0,
            .ReshowDelay = 500
        }
        toolTip.SetToolTip(btn选择一项, "选择第一个项")
        toolTip.SetToolTip(btn选择二项, "选择第二个项")
        toolTip.SetToolTip(btn确定约束, "选择驱动约束")
        toolTip.SetToolTip(btn正向, "正向")
        toolTip.SetToolTip(btn反向, "反向")
        toolTip.SetToolTip(btn暂停, "暂停")
        toolTip.SetToolTip(btn导出, "导出数据到Excel文件")
        toolTip.SetToolTip(btn最大值, "最大值")
        toolTip.SetToolTip(btn最小值, "最小值")

        ' 从资源文件中加载图标并设置到Button控件的Image属性中
        btn选择一项.Image = My.Resources.选择一32.ToBitmap
        btn选择二项.Image = My.Resources.选择二32.ToBitmap
        btn确定约束.Image = My.Resources.配合16.ToBitmap
        btn正向.Image = My.Resources.前进24.ToBitmap
        btn反向.Image = My.Resources.后退24.ToBitmap
        btn暂停.Image = My.Resources.暂停24.ToBitmap
        btn最大值.Image = My.Resources.最大值24.ToBitmap
        btn最小值.Image = My.Resources.最小值24.ToBitmap

        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveEditDocument

        oHSet1 = oInventorAssemblyDocument.CreateHighlightSet()
        oHSet1.Color = ThisApplication.TransientObjects.CreateColor(58, 107, 114)
        oHSet1.Clear()

        oHSet2 = oInventorAssemblyDocument.CreateHighlightSet()
        oHSet2.Color = ThisApplication.TransientObjects.CreateColor(114, 114, 69)
        oHSet2.Clear()

        Me.TopMost = True
    End Sub

    Private Sub Btn确定约束_Click(sender As Object, e As EventArgs) Handles btn确定约束.Click
        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument

        Dim oselect As Object
        Dim oAssemblyConstraint As AssemblyConstraint

        If oInventorAssemblyDocument.SelectSet.Count <> 0 Then
            'For Each oSelect As Object In InventorDoc.SelectSet
            oselect = oInventorAssemblyDocument.SelectSet(1)
            Select Case oselect.type
                Case kAngleConstraintObject, kAssemblySymmetryConstraintObject, kCompositeConstraintObject, kCustomConstraintObject,
                    kFlushConstraintObject, kInsertConstraintObject, kMateConstraintObject, kTangentConstraintObject, kTransitionalConstraintObject
                    oAssemblyConstraint = oselect
                Case Else
                    MessageBox.Show(”选择一个约束。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
            End Select
        Else
            MessageBox.Show(”选择一个约束。“, XHTool, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        GroupBox设置约束.Text = "设置约束：  " & oAssemblyConstraint.Name

        txt开始.Text = Val(oAssemblyConstraint.DriveSettings.StartValue).ToString
        txt结束.Text = Val(oAssemblyConstraint.DriveSettings.EndValue).ToString

        If Val(txt开始.Text) < Val(txt结束.Text) Then
            txt步长.Text = "1"
        Else
            txt步长.Text = "-1"
        End If

        Select Case oselect.type
            Case kAngleConstraintObject
                lbl位置.Text = "参数：" & oAssemblyConstraint.Angle.name & "，位置=" & oAssemblyConstraint.Angle.value * 180 / Math.PI
            Case kAssemblySymmetryConstraintObject, kCompositeConstraintObject, kCustomConstraintObject,
                                kFlushConstraintObject, kInsertConstraintObject, kMateConstraintObject, kTangentConstraintObject, kTransitionalConstraintObject
                lbl位置.Text = "参数：" & oAssemblyConstraint.offset.name & "，位置=" & oAssemblyConstraint.offset.value * 10
        End Select
    End Sub

    Private Sub Btn正向_Click(sender As Object, e As EventArgs) Handles btn正向.Click
        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument

        lvw列表.Items.Clear()
        IsStop = False

        Dim oAssemblyConstraint As AssemblyConstraint
        For Each oAssemblyConstraint In oInventorAssemblyDocument.ComponentDefinition.Constraints
            If Strings.InStr(GroupBox设置约束.Text, oAssemblyConstraint.Name) <> 0 Then
                Dim douValue As Double
                Dim douStart As Double
                Dim douEnd As Double
                Dim douStep As Double

                Dim douDistance As Double
                Dim douAngle As Double


                Dim oListViewItem As ListViewItem
                douStart = Val(txt开始.Text.ToString)
                douEnd = Val(txt结束.Text.ToString)
                douStep = Val(txt步长.Text.ToString)

                For douValue = douStart To douEnd Step douStep
                    System.Windows.Forms.Application.DoEvents()

                    If IsStop = True Then
                        Exit Sub
                    End If

                    Select Case oAssemblyConstraint.Type
                        Case kAngleConstraintObject
                            oAssemblyConstraint.angle.value = douValue * Math.PI / 180
                            lbl位置.Text = "参数：" & oAssemblyConstraint.angle.name & "，位置=" & douValue


                        Case kAssemblySymmetryConstraintObject, kCompositeConstraintObject, kCustomConstraintObject,
                                            kFlushConstraintObject, kInsertConstraintObject, kMateConstraintObject, kTangentConstraintObject, kTransitionalConstraintObject
                            oAssemblyConstraint.offset.value = douValue * 0.1
                            lbl位置.Text = "参数：" & oAssemblyConstraint.offset.name & "，位置=" & douValue
                    End Select

                    If RadioButton距离.Checked = True Then
                        douDistance = ThisApplication.MeasureTools.GetMinimumDistance(oSelect1, oSelect2)
                        douDistance = Math.Round(ThisApplication.ActiveDocument.UnitsOfMeasure.ConvertUnits(douDistance, "cm", "mm"), 3)
                        lbl距离.Text = "距离：" & douDistance.ToString

                        oListViewItem = lvw列表.Items.Add(douValue)
                        oListViewItem.SubItems.Add(douDistance)
                    Else

                        douAngle = FourFive(ThisApplication.MeasureTools.GetAngle(oSelect1, oSelect2) * 180 / Math.PI, 3)
                        lbl距离.Text = "角度：" & douAngle.ToString

                        oListViewItem = lvw列表.Items.Add(douValue)
                        oListViewItem.SubItems.Add(douAngle)
                    End If

                    ThisApplication.ActiveDocument.Update()
                Next

                Select Case oAssemblyConstraint.Type
                    Case kAngleConstraintObject
                        oAssemblyConstraint.angle.value = douEnd * Math.PI / 180
                        lbl位置.Text = "参数：" & oAssemblyConstraint.angle.name & "，位置=" & douEnd

                    Case kAssemblySymmetryConstraintObject, kCompositeConstraintObject, kCustomConstraintObject,
                                        kFlushConstraintObject, kInsertConstraintObject, kMateConstraintObject, kTangentConstraintObject, kTransitionalConstraintObject

                        oAssemblyConstraint.offset.value = douEnd * 0.1
                        lbl位置.Text = "参数：" & oAssemblyConstraint.offset.name & "，位置=" & douEnd
                End Select

                If RadioButton距离.Checked = True Then
                    douDistance = ThisApplication.MeasureTools.GetMinimumDistance(oSelect1, oSelect2)
                    douDistance = Math.Round(ThisApplication.ActiveDocument.UnitsOfMeasure.ConvertUnits(douDistance, "cm", "mm"), 3)
                    lbl距离.Text = "距离：" & douDistance.ToString

                    oListViewItem = lvw列表.Items.Add(douEnd)
                    oListViewItem.SubItems.Add(douDistance)
                Else
                    douAngle = FourFive(ThisApplication.MeasureTools.GetAngle(oSelect1, oSelect2) * 180 / Math.PI, 3)
                    lbl距离.Text = "角度：" & douAngle.ToString

                    oListViewItem = lvw列表.Items.Add(douEnd)
                    oListViewItem.SubItems.Add(douAngle)
                End If

                ThisApplication.ActiveDocument.Update()

                oHSet1.Clear()
                oHSet2.Clear()
                oHSet1.AddItem(oSelect1)
                oHSet2.AddItem(oSelect2)

                Exit Sub
            End If
        Next
    End Sub

    Private Sub Btn反向_Click(sender As Object, e As EventArgs) Handles btn反向.Click
        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument

        lvw列表.Items.Clear()
        IsStop = False

        Dim oAssemblyConstraint As AssemblyConstraint
        For Each oAssemblyConstraint In oInventorAssemblyDocument.ComponentDefinition.Constraints
            If Strings.InStr(GroupBox设置约束.Text, oAssemblyConstraint.Name) <> 0 Then
                Dim douValue As Double
                Dim douStart As Double
                Dim douEnd As Double
                Dim douStep As Double

                Dim douDistance As Double
                Dim douAngle As Double

                Dim oListViewItem As ListViewItem

                douStart = Val(txt开始.Text.ToString)
                douEnd = Val(txt结束.Text.ToString)
                douStep = -Val(txt步长.Text.ToString)

                'With oAssemblyConstraint.DriveSettings
                '    .StartValue = txt开始.Text.ToString
                '    .EndValue = txt结束.Text.ToString
                '    .GoToStart()
                '    .PlayForward()
                'End With

                For douValue = douEnd To douStart Step douStep
                    System.Windows.Forms.Application.DoEvents()

                    If IsStop = True Then
                        Exit Sub
                    End If

                    Select Case oAssemblyConstraint.Type
                        Case kAngleConstraintObject
                            oAssemblyConstraint.angle.value = douValue * Math.PI / 180
                            lbl位置.Text = "参数：" & oAssemblyConstraint.angle.name & "，位置=" & douValue


                        Case kAssemblySymmetryConstraintObject, kCompositeConstraintObject, kCustomConstraintObject,
                                            kFlushConstraintObject, kInsertConstraintObject, kMateConstraintObject, kTangentConstraintObject, kTransitionalConstraintObject
                            oAssemblyConstraint.offset.value = douValue * 0.1
                            lbl位置.Text = "参数：" & oAssemblyConstraint.offset.name & "，位置=" & douValue
                    End Select


                    If RadioButton距离.Checked = True Then
                        douDistance = ThisApplication.MeasureTools.GetMinimumDistance(oSelect1, oSelect2)
                        douDistance = Math.Round(ThisApplication.ActiveDocument.UnitsOfMeasure.ConvertUnits(douDistance, "cm", "mm"), 3)
                        lbl距离.Text = "距离：" & douDistance.ToString

                        oListViewItem = lvw列表.Items.Add(douValue)
                        oListViewItem.SubItems.Add(douDistance)
                    Else
                        douAngle = FourFive(ThisApplication.MeasureTools.GetAngle(oSelect1, oSelect2) * 180 / Math.PI, 3)
                        lbl距离.Text = "角度：" & douAngle.ToString

                        oListViewItem = lvw列表.Items.Add(douValue)
                        oListViewItem.SubItems.Add(douAngle)
                    End If

                    ThisApplication.ActiveDocument.Update()
                Next

                Select Case oAssemblyConstraint.Type
                    Case kAngleConstraintObject
                        oAssemblyConstraint.angle.value = douStart * Math.PI / 180
                        lbl位置.Text = "参数：" & oAssemblyConstraint.angle.name & "，位置=" & douStart

                    Case kAssemblySymmetryConstraintObject, kCompositeConstraintObject, kCustomConstraintObject,
                                        kFlushConstraintObject, kInsertConstraintObject, kMateConstraintObject, kTangentConstraintObject, kTransitionalConstraintObject

                        oAssemblyConstraint.offset.value = douStart * 0.1
                        lbl位置.Text = "参数：" & oAssemblyConstraint.offset.name & "，位置=" & douStart
                End Select

                If RadioButton距离.Checked = True Then
                    douDistance = ThisApplication.MeasureTools.GetMinimumDistance(oSelect1, oSelect2)
                    douDistance = Math.Round(ThisApplication.ActiveDocument.UnitsOfMeasure.ConvertUnits(douDistance, "cm", "mm"), 3)
                    lbl距离.Text = "距离：" & douDistance.ToString

                    oListViewItem = lvw列表.Items.Add(douStart)
                    oListViewItem.SubItems.Add(douDistance)
                Else
                    douAngle = FourFive(ThisApplication.MeasureTools.GetAngle(oSelect1, oSelect2) * 180 / Math.PI, 3)
                    lbl距离.Text = "角度：" & douAngle.ToString

                    oListViewItem = lvw列表.Items.Add(douStart)
                    oListViewItem.SubItems.Add(douAngle)
                End If

                ThisApplication.ActiveDocument.Update()

                oHSet1.Clear()
                oHSet2.Clear()
                oHSet1.AddItem(oSelect1)
                oHSet2.AddItem(oSelect2)

                Exit Sub
            End If
        Next
    End Sub

    Private Sub Btn暂停_Click(sender As Object, e As EventArgs) Handles btn暂停.Click
        IsStop = True
    End Sub

    Private Sub Btn导出_Click(sender As Object, e As EventArgs) Handles btn导出.Click
        Dim strLineDate As String
        Dim strCsvFullFileName As String

        Dim now As DateTimeOffset = DateTimeOffset.Now
        Dim epoch As New DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)
        Dim timestamp As Long = Convert.ToInt64((now - epoch).TotalSeconds)

        strCsvFullFileName = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop, "驱动测量" & timestamp & ".csv")

        DeleteFile2(strCsvFullFileName, FileIO.RecycleOption.SendToRecycleBin)

        Using oStreamWriter As New StreamWriter(strCsvFullFileName, False, oEncoding)   ' Encoding.Default)
            strLineDate = "位置,距离"
            oStreamWriter.WriteLine(strLineDate)

            For Each oListViewitem As ListViewItem In lvw列表.Items
                strLineDate = oListViewitem.Text & "," & oListViewitem.SubItems(1).Text
                oStreamWriter.WriteLine(strLineDate)
            Next

        End Using

        If MessageBox.Show("数据文件导出完成，是否打开？", XHTool, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
          ProcessStart(strCsvFullFileName)
        End If

    End Sub

    Private Sub OListView_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvw列表.MouseDoubleClick
        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        oInventorAssemblyDocument = ThisApplication.ActiveDocument

        IsStop = False

        Dim douValue As Double

        douValue = lvw列表.SelectedItems(0).Text

        SetValueToAssemblyConstraint(ThisApplication.ActiveDocument, douValue)

    End Sub

    Private Sub SetValueToAssemblyConstraint(ByVal oInventorAssemblyDocument As AssemblyDocument, ByVal douValue As Double)

        Dim douDistance As Double

        Dim oAssemblyConstraint As AssemblyConstraint
        For Each oAssemblyConstraint In oInventorAssemblyDocument.ComponentDefinition.Constraints
            If Strings.InStr(GroupBox设置约束.Text, oAssemblyConstraint.Name) <> 0 Then

                'With oAssemblyConstraint.DriveSettings
                '    .StartValue = txt开始.Text.ToString
                '    .EndValue = txt结束.Text.ToString
                '    .GoToStart()
                '    .PlayForward()
                'End With

                Select Case oAssemblyConstraint.Type
                    Case kAngleConstraintObject
                        oAssemblyConstraint.angle.value = douValue * Math.PI / 180
                        lbl位置.Text = "参数：" & oAssemblyConstraint.angle.name & "，位置=" & douValue

                    Case kAssemblySymmetryConstraintObject, kCompositeConstraintObject, kCustomConstraintObject,
                kFlushConstraintObject, kInsertConstraintObject, kMateConstraintObject, kTangentConstraintObject, kTransitionalConstraintObject

                        oAssemblyConstraint.offset.value = douValue * 0.1
                        lbl位置.Text = "参数：" & oAssemblyConstraint.offset.name & "，位置=" & douValue
                End Select

                douDistance = ThisApplication.MeasureTools.GetMinimumDistance(oSelect1, oSelect2)
                douDistance = Math.Round(ThisApplication.ActiveDocument.UnitsOfMeasure.ConvertUnits(douDistance, "cm", "mm"), 3)
                lbl距离.Text = "距离：" & douDistance.ToString

                ThisApplication.ActiveDocument.Update()

                Exit Sub
            End If

        Next

    End Sub

    Private Sub RadioButton距离_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton距离.CheckedChanged
        If oHSet1 Is Nothing Then
            Exit Sub
        End If

        If oHSet2 Is Nothing Then
            Exit Sub
        End If

        If oHSet1.Count <> 0 Then
            oHSet1.Clear()
        End If

        If oHSet2.Count <> 0 Then
            oHSet2.Clear()
        End If
    End Sub

    Private Sub RadioButton角度_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton角度.CheckedChanged
        If oHSet1 Is Nothing Then
            Exit Sub
        End If

        If oHSet2 Is Nothing Then
            Exit Sub
        End If

        If oHSet1.Count <> 0 Then
            oHSet1.Clear()
        End If

        If oHSet2.Count <> 0 Then
            oHSet2.Clear()
        End If
    End Sub

    Private Sub Btn最大值_Click(sender As Object, e As EventArgs) Handles btn最大值.Click
        Dim maxValue As Decimal = Decimal.MinValue
        Dim maxItem As ListViewItem = Nothing

        If lvw列表.Items.Count = 0 Then
            Exit Sub
        End If

        For Each item As ListViewItem In lvw列表.Items
            Dim value As Decimal
            If Decimal.TryParse(item.SubItems(1).Text, value) Then
                If value > maxValue Then
                    maxValue = value
                    maxItem = item
                End If
            End If
        Next

        SetValueToAssemblyConstraint(ThisApplication.ActiveDocument, maxItem.Text)

        If maxItem IsNot Nothing Then
            maxItem.ForeColor = Drawing.Color.Red
            lvw列表.SelectedItems.Clear() ' 清除当前选择
            maxItem.Selected = True ' 选择最大值行
            lvw列表.EnsureVisible(maxItem.Index) ' 确保该行可见
        End If

    End Sub

    Private Sub Btn最小值_Click(sender As Object, e As EventArgs) Handles btn最小值.Click
        Dim minValue As Decimal = Decimal.MaxValue
        Dim minItem As ListViewItem = Nothing

        If lvw列表.Items.Count = 0 Then
            Exit Sub
        End If

        For Each item As ListViewItem In lvw列表.Items
            Dim value As Decimal
            If Decimal.TryParse(item.SubItems(1).Text, value) Then
                If value < minValue Then
                    minValue = value
                    minItem = item
                End If
            End If
        Next

        SetValueToAssemblyConstraint(ThisApplication.ActiveDocument, minItem.Text)

        If minItem IsNot Nothing Then
            minItem.ForeColor = Drawing.Color.Red
            lvw列表.SelectedItems.Clear() ' 清除当前选择
            minItem.Selected = True ' 选择最大值行
            lvw列表.EnsureVisible(minItem.Index) ' 确保该行可见
        End If

    End Sub

    Private Sub FormDim2Object_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        FormManager.CloseAndDisposeForm(Of FormDim2Object)()
    End Sub


End Class