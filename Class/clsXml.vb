Imports System.Xml

Public Class clsXml
    Private XmlDoc As XmlDocument
    Private XmlFile As String

    Public ReadOnly Property XmlFileName() As String
        Get
            Return XmlFile
        End Get
    End Property

    Public ReadOnly Property XmlText() As String
        Get
            Return XmlDoc.InnerXml
        End Get
    End Property

    Sub New(ByVal FileName As String, Optional ByVal CreateNew As Boolean = True, Optional ByVal Root As String = "XML", Optional ByRef IsOK As Boolean = False)
        IsOK = False
        XmlFile = ""

        Dim reader As System.Xml.XmlReader = Nothing
        Try
            reader = New System.Xml.XmlTextReader(FileName)
            reader.Read()
        Catch ex As Exception
            if Not (reader Is Nothing) Then
                reader.Close()
            End if
            Debug.Print("New - " & ex.Message)
            if Not Create(FileName, Root) Then
                Return
            End if
        Finally
            if Not (reader Is Nothing) Then
                reader.Close()
            End if
        End Try
        IsOK = True
        XmlFile = FileName
        XmlDoc = New XmlDocument
        XmlDoc.Load(XmlFile)
    End Sub

    Public Function Create(ByVal FileName As String, Optional ByVal Root As String = "XML") As Boolean
        Dim NewXML As XmlTextWriter = Nothing

        Try
            NewXML = New XmlTextWriter(FileName, Nothing)

            NewXML.Formatting = Formatting.Indented
            NewXML.WriteStartDocument()
            NewXML.WriteComment(My.Application.Info.AssemblyName & " Settings")

            NewXML.WriteStartElement(Root)

            NewXML.WriteAttributeString("Powered", "Null")

            NewXML.WriteEndElement()
            NewXML.WriteEndDocument()

            NewXML.Flush()
            NewXML.Close()
        Catch ex As Exception
            Debug.Print("Create - " & ex.Message)
            Return False
        Finally
            if NewXML IsNot Nothing Then
                NewXML.Close()
                NewXML = Nothing
            End if

        End Try

        Return True
    End Function

    Public Function Save(ByVal aSection As String, ByVal aKey As String, ByVal aValue As String) As Boolean
        Dim Paths() As String
        Dim n As Integer

        Dim Node, Node2 As XmlNode
        Dim Ele As XmlElement

        While Strings.Left(aSection, 1) = "/"
            aSection = Strings.Mid(aSection, 2)
        End While

        '段名是否为空
        if aSection = "" Then
            XmlDoc.DocumentElement.RemoveAll()
        Else

            Paths = Strings.Split(aSection, "/")
            Try
                Node = XmlDoc.DocumentElement.SelectSingleNode(Paths(n))

                if Node Is Nothing Then
                    Ele = XmlDoc.CreateElement(Paths(n))
                    Node = XmlDoc.DocumentElement.AppendChild(Ele)
                End if

                For n = 1 To Paths.Length - 1
                    if Paths(n) = "" Then Continue For

                    Node2 = Node.SelectSingleNode(Paths(n))
                    if Node2 Is Nothing Then
                        Ele = XmlDoc.CreateElement(Paths(n))
                        Node2 = Node.AppendChild(Ele)
                    End if
                    Node = Node2
                Next
                '键名是否为空
                if aKey = "" Then
                    Node.RemoveAll()
                Else
                    Ele = Node.Item(aKey)

                    if Ele Is Nothing Then
                        Ele = XmlDoc.CreateElement(aKey)
                        Node.AppendChild(Ele)
                    End if
                    '值是否为空
                    if aValue = "" Then
                        Node.RemoveChild(Ele)
                    Else
                        Ele.InnerText = aValue
                    End if
                End if
            Catch ex As Exception
                Debug.Print(ex.Message)
                Return False
            End Try
        End if

        XmlDoc.Save(XmlFile)
        Return True
    End Function

    Public Function Read(ByVal aSection As String, ByVal aKey As String, Optional ByVal aDefaultValue As String = "") As String
        Dim Node As XmlNode
        Node = (XmlDoc.DocumentElement).SelectSingleNode(aSection & "/" & aKey)
        if Node Is Nothing Then Return aDefaultValue
        Return Node.InnerText
    End Function
End Class