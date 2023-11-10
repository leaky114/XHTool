Imports System.Windows.Forms
Imports Inventor
Imports System.Drawing

Public Class frmEditDimension

    Private strDimensionConstraintFileName As String
    Private strDimensionConstraintName As String
    Private strDimensionConstraintValue As String
    Private oDimensionConstraint As DimensionConstraint

    Private Sub btn选择一_Click(sender As Object, e As EventArgs) Handles btn选择一.Click
        Dim oInventorPartDocument As Inventor.PartDocument
        oInventorPartDocument = ThisApplication.ActiveEditDocument

        oDimensionConstraint = ThisApplication.CommandManager.Pick(SelectionFilterEnum.kSketchDimConstraintFilter, "选择要编辑的尺寸，ESC键取消")
        If oDimensionConstraint Is Nothing Then       '取消选择
            Exit Sub
        End If

        If ThisApplication.ActiveDocumentType = DocumentTypeEnum.kAssemblyDocumentObject Then
            strDimensionConstraintFileName = oDimensionConstraint.ContainingOccurrence.ReferencedDocumentDescriptor.FullDocumentName

            If strDimensionConstraintFileName <> oInventorPartDocument.FullFileName Then
                MsgBox("请选择当前编辑零件。", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If

        strDimensionConstraintName = oDimensionConstraint.Parameter.Name
        strDimensionConstraintValue = oDimensionConstraint.Parameter.Expression

        Me.Text = "编辑尺寸：" & strDimensionConstraintName
        txt参数.Text = strDimensionConstraintValue

        Select Case oDimensionConstraint.Parameter.Units
            Case "mm"
                TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value * 10 - 50
                TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value * 10 + 50
                TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 10
            Case "cm"
                TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value - 5
                TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value + 5
                TrackBar参数一.Value = oDimensionConstraint.Parameter.Value
            Case "deg"
                TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value * 180 / Math.PI - 45
                TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value * 180 / Math.PI + 45
                TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 180 / Math.PI
        End Select

    End Sub

    Private Sub TrackBar参数一_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar参数一.Scroll
        On Error Resume Next
        Dim oInventorPartDocument As Inventor.PartDocument
        oInventorPartDocument = ThisApplication.ActiveEditDocument

        Select Case oDimensionConstraint.Parameter.Units
            Case "mm"
                oDimensionConstraint.Parameter.Value = TrackBar参数一.Value * 0.1
            Case "cm"
                oDimensionConstraint.Parameter.Value = TrackBar参数一.Value
            Case "deg"
                oDimensionConstraint.Parameter.Value = TrackBar参数一.Value * Math.PI / 180
        End Select

        txt参数.Text = TrackBar参数一.Value

        oInventorPartDocument.Update()
        ThisApplication.ActiveView.Update()

    End Sub

    Private Sub btn还原_Click(sender As Object, e As EventArgs) Handles btn还原.Click
        Dim oInventorPartDocument As Inventor.PartDocument
        oInventorPartDocument = ThisApplication.ActiveEditDocument

        oDimensionConstraint.Parameter.Expression = strDimensionConstraintValue
        txt参数.Text = strDimensionConstraintValue

        Select Case oDimensionConstraint.Parameter.Units
            Case "mm"
                TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value * 10 - 50
                TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value * 10 + 50
                TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 10
            Case "cm"
                TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value - 5
                TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value + 5
                TrackBar参数一.Value = oDimensionConstraint.Parameter.Value
            Case "deg"
                TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value * 180 / Math.PI - 45
                TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value * 180 / Math.PI + 45
                TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 180 / Math.PI
        End Select

        oInventorPartDocument.Update()
        ThisApplication.ActiveView.Update()

    End Sub

    Private Sub frmChangeValue_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        If oDimensionConstraint Is Nothing Then
            Exit Sub
        End If

        If ThisApplication.ActiveEditDocument.DocumentType = DocumentTypeEnum.kPartDocumentObject Then
            Dim oInventorPartDocument As Inventor.PartDocument
            oInventorPartDocument = ThisApplication.ActiveEditDocument
            oDimensionConstraint.Parameter.Expression = strDimensionConstraintValue
            oInventorPartDocument.Update()
            ThisApplication.ActiveView.Update()
        End If
    End Sub

    Private Sub btn确定_Click(sender As Object, e As EventArgs) Handles btn确定.Click
        strDimensionConstraintValue = txt参数.Text

        Select Case oDimensionConstraint.Parameter.Units
            Case "mm"
                TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value * 10 - 50
                TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value * 10 + 50
                TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 10
            Case "cm"
                TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value - 5
                TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value + 5
                TrackBar参数一.Value = oDimensionConstraint.Parameter.Value
            Case "deg"
                TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value * 180 / Math.PI - 45
                TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value * 180 / Math.PI + 45
                TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 180 / Math.PI
        End Select

    End Sub

    Private Sub frmChangeValue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'On Error Resume Next
        Dim oInventorAssemblyDocument As Inventor.AssemblyDocument
        Dim oInventorPartDocument As Inventor.PartDocument
        oInventorPartDocument = ThisApplication.ActiveEditDocument

        ' 是否已经选择了尺寸
        Dim oSelectSet As Object = Nothing

        '在组件中
        If ThisApplication.ActiveDocument.DocumentType = DocumentTypeEnum.kAssemblyDocumentObject Then
            oInventorAssemblyDocument = ThisApplication.ActiveDocument
            If oInventorAssemblyDocument.SelectSet.Count <> 0 Then
                oSelectSet = oInventorAssemblyDocument.SelectSet(1)
            End If
            '在零件中
        ElseIf ThisApplication.ActiveDocument.DocumentType = DocumentTypeEnum.kPartDocumentObject Then
            If oInventorPartDocument.SelectSet.Count <> 0 Then
                oSelectSet = oInventorPartDocument.SelectSet(1)
            End If
        End If

        If TypeOf oSelectSet Is DimensionConstraint Then
            oDimensionConstraint = oSelectSet
            strDimensionConstraintName = oDimensionConstraint.Parameter.Name
            strDimensionConstraintValue = oDimensionConstraint.Parameter.Expression

            Me.Text = "编辑尺寸：" & strDimensionConstraintName
            txt参数.Text = strDimensionConstraintValue

            Select Case oDimensionConstraint.Parameter.Units
                Case "mm"
                    TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value * 10 - 50
                    TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value * 10 + 50
                    TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 10

                Case "cm"
                    TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value - 5
                    TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value + 5
                    TrackBar参数一.Value = oDimensionConstraint.Parameter.Value
                Case "deg"
                    TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value * 180 / Math.PI - 45
                    TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value * 180 / Math.PI + 45
                    TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 180 / Math.PI
            End Select
        End If

        ' 创建ToolTip控件并设置相关属性
        Dim toolTip As New ToolTip()
        toolTip.AutoPopDelay = 0
        toolTip.InitialDelay = 0
        toolTip.ReshowDelay = 500
        toolTip.SetToolTip(btn选择一, "选择一个尺寸")
        toolTip.SetToolTip(btn还原, "还原为初始尺寸")
        toolTip.SetToolTip(btn确定, "修改为当前尺寸")

        ' 从资源文件中加载图标并设置到Button控件的Image属性中
        btn选择一.Image = My.Resources.选择161632.ToBitmap
        btn还原.Image = My.Resources.还原161632.ToBitmap
        btn确定.Image = My.Resources.确定161632.ToBitmap


    End Sub

    Private Sub txt参数_KeyDown(sender As Object, e As KeyEventArgs) Handles txt参数.KeyDown
        'MsgBox(e.KeyCode)

        If e.KeyCode = Keys.Enter Then

            Dim oInventorPartDocument As Inventor.PartDocument
            oInventorPartDocument = ThisApplication.ActiveEditDocument

            oDimensionConstraint.Parameter.Expression = txt参数.Text

            Select Case oDimensionConstraint.Parameter.Units
                Case "mm"
                    TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value * 10 - 50
                    TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value * 10 + 50
                    TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 10
                Case "cm"
                    TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value - 5
                    TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value + 5
                    TrackBar参数一.Value = oDimensionConstraint.Parameter.Value
                Case "deg"
                    TrackBar参数一.Minimum = oDimensionConstraint.Parameter.Value * 180 / Math.PI - 45
                    TrackBar参数一.Maximum = oDimensionConstraint.Parameter.Value * 180 / Math.PI + 45
                    TrackBar参数一.Value = oDimensionConstraint.Parameter.Value * 180 / Math.PI
            End Select

            oInventorPartDocument.Update()
            ThisApplication.ActiveView.Update()

        End If
    End Sub

End Class
