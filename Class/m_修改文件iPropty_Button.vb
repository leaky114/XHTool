'Imports Inventor
'Imports System.Drawing
'Imports System.Windows.Forms

'Friend Class 修改文件iPropty_Button
'    Inherits Button

'#Region "Methods"

'    Public Sub New(ByVal displayName As String, _
'                    ByVal internalName As String, _
'                    ByVal commandType As CommandTypesEnum, _
'                    ByVal clientId As String, _
'                    Optional ByVal description As String = "", _
'                    Optional ByVal tooltip As String = "", _
'                    Optional ByVal standardIcon As Icon = Nothing, _
'                    Optional ByVal largeIcon As Icon = Nothing, _
'                    Optional ByVal buttonDisplayType As ButtonDisplayEnum = ButtonDisplayEnum.kDisplayTextInLearningMode)

'        MyBase.New(displayName, internalName, commandType, clientId, description, tooltip, standardIcon, largeIcon, buttonDisplayType)

'    End Sub

'    Protected Overrides Sub ButtonDefinition_OnExecute(ByVal context As Inventor.NameValueMap)

'        Try
'            MsgBox("")

'        Catch ex As Exception
'            MessageBox.Show(ex.ToString)
'        End Try

'    End Sub

'#End Region

'End Class
