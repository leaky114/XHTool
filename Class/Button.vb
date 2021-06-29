'Imports Inventor
'Imports System.Drawing
'Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6

'Friend MustInherit Class Button

'#Region "Data Members"

'    Private Shared m_inventorApplication As Inventor.Application

'    Private m_buttonDefinition As ButtonDefinition

'#End Region

'#Region "Properties"

'    Public Shared Property InventorApplication() As Inventor.Application
'        Get
'            InventorApplication = m_inventorApplication
'        End Get

'        Set(ByVal Value As Inventor.Application)
'            m_inventorApplication = Value
'        End Set
'    End Property

'    Public ReadOnly Property ButtonDefinition() As Inventor.ButtonDefinition
'        Get
'            ButtonDefinition = m_buttonDefinition
'        End Get
'    End Property

'#End Region

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

'        Try
'            'get IPictureDisp for icons
'            Dim stdIconIPictureDisp As Object = System.Type.Missing
'            Dim largeIconIPictureDisp As Object = System.Type.Missing

'            If Not standardIcon Is Nothing Then
'                stdIconIPictureDisp = Microsoft.VisualBasic.Compatibility.VB6.Support.IconToIPicture(standardIcon)
'            End If

'            If Not largeIcon Is Nothing Then
'                largeIconIPictureDisp = Microsoft.VisualBasic.Compatibility.VB6.Support.IconToIPicture(largeIcon)
'            End If

'            'create button definition
'            m_buttonDefinition = m_inventorApplication.CommandManager.ControlDefinitions.AddButtonDefinition(displayName, internalName, commandType, clientId, description, tooltip, stdIconIPictureDisp, largeIconIPictureDisp, buttonDisplayType)

'            'enable the button
'            m_buttonDefinition.Enabled = True

'            'connect the button event sink
'            AddHandler m_buttonDefinition.OnExecute, AddressOf Me.ButtonDefinition_OnExecute

'        Catch ex As Exception
'            MessageBox.Show(ex.ToString)
'        End Try

'    End Sub

'    Protected MustOverride Sub ButtonDefinition_OnExecute(ByVal context As NameValueMap)

'#End Region

'End Class
