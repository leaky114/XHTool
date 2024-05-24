Imports Inventor
Imports Inventor.DocumentTypeEnum
Imports Inventor.SelectionFilterEnum
Imports Inventor.SelectTypeEnum
Imports System.Windows.Forms

Public Class frmStatisticalWelds
    Private dou长度系数 As Double

    'Private Sub AddWelds(ByVal dou长度系数 As Double, ByVal lvw As ListView)
    '    'Try
    '    SetStatusBarText()

    '    If IsInventorOpenDocument() = False Then
    '        Exit Sub
    '    End If

    '    Dim oInventorDocument As Inventor.Document
    '    oInventorDocument = ThisApplication.ActiveDocument

    '    If oInventorDocument.DocumentType <> kAssemblyDocumentObject Then
    '        MsgBox("该功能仅适用于部件", MsgBoxStyle.Information, "统计质量面积")
    '        Exit Sub
    '    End If


    '    Dim oSelectSet As SelectSet = oInventorDocument.SelectSet


    '    Dim Types As ObjectTypeEnum() = [Enum].GetValues(GetType(ObjectTypeEnum))

    '    If oSelectSet.Count = 0 Then
    '        MsgBox("请先选择边", MsgBoxStyle.OkOnly, "统计质量面积")
    '        Exit Sub
    '    End If

    '    Dim oEdge As Edge

    '    For Each oSelect As Object In oSelectSet
    '        For Each Type As ObjectTypeEnum In Types
    '            If oSelect.Type = Inventor.ObjectTypeEnum.kEdgeProxyObject Then

    '                Dim oListViewItem As ListViewItem

    '                oEdge = oSelect

    '                Dim oEval As CurveEvaluator = oEdge.Evaluator
    '                Dim oMin, oMax, oLength As Double
    '                oEval.GetParamExtents(oMin, oMax)
    '                oEval.GetLengthAtParam(oMin, oMax, oLength)

    '                Dim UoM As UnitsOfMeasure = ThisApplication.ActiveDocument.UnitsOfMeasure
    '                'MsgBox(UoM.GetStringFromValue(oLength, UoM.LengthUnits))

    '                Dim dou边长度 = UoM.GetStringFromValue(oLength, UoM.LengthUnits)
    '                Dim dou焊缝长度 = Val(dou边长度) * dou长度系数

    '                Dim oSurfaceBodyProxy As SurfaceBodyProxy
    '                oSurfaceBodyProxy = oEdge.Parent

    '                Dim oComponentOccurrence As ComponentOccurrence
    '                oComponentOccurrence = oSurfaceBodyProxy.Parent


    '                oListViewItem = lvw文件列表.Items.Add(oComponentOccurrence.Name)
    '                oListViewItem.SubItems.Add(dou边长度.ToString)
    '                oListViewItem.SubItems.Add(dou长度系数.ToString)
    '                oListViewItem.SubItems.Add(dou焊缝长度.ToString)

    '                Exit For

    '            End If
    '        Next
    '    Next

    '    Dim dbl焊缝总长度 As Double = 0

    '    For Each LVI As ListViewItem In lvw文件列表.Items
    '        dbl焊缝总长度 = dbl焊缝总长度 + LVI.SubItems(3).Text
    '    Next

    '    txt焊缝长度.Text = dbl焊缝总长度.ToString

    '    ThisApplication.ActiveDocument.Update2()


    '    'Catch ex As Exception
    '    '    MsgBox(ex.Message)
    '    'End Try
    'End Sub


    '移出
    Private Sub btn移出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn移出.Click
        ListViewDel(lvw文件列表)
        Dim dbl焊缝总长度 As Double = 0

        For Each oListViewItem As ListViewItem In lvw文件列表.Items
            dbl焊缝总长度 = dbl焊缝总长度 + oListViewItem.SubItems(3).Text
        Next

        txt焊缝长度.Text = dbl焊缝总长度.ToString

    End Sub

    '退出
    Private Sub btn关闭_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn关闭.Click
        lvw文件列表.Items.Clear()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    '清空
    Private Sub btn清空_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn清空.Click
        lvw文件列表.Items.Clear()
        txt焊缝长度.Clear()

    End Sub

    '复制总质量到剪贴板
    Private Sub btn复制质量_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn复制焊缝长度.Click
        My.Computer.Clipboard.SetText(txt焊缝长度.Text)
    End Sub

    Private Sub frmStatisticalWelds_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim toolTip As New ToolTip()
        toolTip.AutoPopDelay = 0
        toolTip.InitialDelay = 0
        toolTip.ReshowDelay = 500
        toolTip.SetToolTip(btn复制焊缝长度, "复制焊缝长度")
        toolTip.SetToolTip(btn选择面和边, "选择面和边")



        btn复制焊缝长度.Image = My.Resources.复制16.ToBitmap
        btn选择面和边.Image = My.Resources.选择面和边32.ToBitmap

        RadioButton10.Checked = True
        dou长度系数 = 1

        '选择切换到 选择面和边
        'ThisApplication.UserInterfaceManager.Ribbons("Assembly").QuickAccessControls.Item("ID_QAT_Assembly_Select").ChildControls.Item("PartSelectFacesAndEdgePriorityCmd").ControlDefinition.Execute()

    End Sub

    Private Sub btn选择面和边_Click(sender As Object, e As EventArgs) Handles btn选择面和边.Click
        'For Each oCommandControl As CommandControl In ThisApplication.UserInterfaceManager.Ribbons("Assembly").QuickAccessControls

        '    Debug.Print(oCommandControl.DisplayName & "-------" & oCommandControl.InternalName)

        '    If oCommandControl.InternalName = "ID_QAT_Assembly_Select" Then

        '        For Each o As CommandControl In oCommandControl.ChildControls

        '            Debug.Print(o.DisplayName & "-------" & o.InternalName)

        '        Next
        '    End If
        'Next

        'ThisApplication.UserInterfaceManager.Ribbons("Assembly").QuickAccessControls.Item("ID_QAT_Assembly_Select").ChildControls.Item("PartSelectFacesAndEdgePriorityCmd").ControlDefinition.Execute()



        'For Each oContrl In Me.GroupBox1.Controls
        '    If TypeOf oContrl Is RadioButton Then
        '        Dim oRadioButton As RadioButton = CType(oContrl, RadioButton)
        '        ' 检查RadioButton是否被选中
        '        If oRadioButton.Checked Then
        '            dou长度系数 = Val(oRadioButton.Text)
        '            Exit For
        '        End If
        '    End If
        'Next

        Dim dbl焊缝总长度 As Double

        Try
            Dim oedge As Edge
            Do
                oedge = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kPartEdgeFilter, "选择一条边，ESC键取消")


                Dim oListViewItem As ListViewItem


                Dim oEval As CurveEvaluator = oedge.Evaluator
                Dim oMin, oMax, oLength As Double
                oEval.GetParamExtents(oMin, oMax)
                oEval.GetLengthAtParam(oMin, oMax, oLength)

                Dim UoM As UnitsOfMeasure = ThisApplication.ActiveDocument.UnitsOfMeasure
                'MsgBox(UoM.GetStringFromValue(oLength, UoM.LengthUnits))

                Dim dou边长度 = UoM.GetStringFromValue(oLength, UoM.LengthUnits)
                Dim dou焊缝长度 = Val(dou边长度) * dou长度系数

                Dim oSurfaceBodyProxy As SurfaceBodyProxy
                oSurfaceBodyProxy = oedge.Parent

                Dim oComponentOccurrence As ComponentOccurrence
                oComponentOccurrence = oSurfaceBodyProxy.Parent


                oListViewItem = lvw文件列表.Items.Add(oComponentOccurrence.Name)
                oListViewItem.SubItems.Add(dou边长度.ToString)
                oListViewItem.SubItems.Add(dou长度系数.ToString)
                oListViewItem.SubItems.Add(dou焊缝长度.ToString)

                For Each LVI As ListViewItem In lvw文件列表.Items
                    dbl焊缝总长度 = dbl焊缝总长度 + LVI.SubItems(3).Text
                Next

                txt焊缝长度.Text = dbl焊缝总长度.ToString

            Loop While True
        Catch ex As Exception


        End Try

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        dou长度系数 = 0.3
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        dou长度系数 = 0.5
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        dou长度系数 = 0.7
    End Sub

    Private Sub RadioButton10_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton10.CheckedChanged
        dou长度系数 = 1
    End Sub

End Class