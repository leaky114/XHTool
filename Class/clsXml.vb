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
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
            Debug.Print("New - " & ex.Message)
            If Not Create(FileName, Root) Then
                Return
            End If
        Finally
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
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
            If NewXML IsNot Nothing Then
                NewXML.Close()
                NewXML = Nothing
            End If

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
        If aSection = "" Then
            XmlDoc.DocumentElement.RemoveAll()
        Else

            Paths = Strings.Split(aSection, "/")
            Try
                Node = XmlDoc.DocumentElement.SelectSingleNode(Paths(n))

                If Node Is Nothing Then
                    Ele = XmlDoc.CreateElement(Paths(n))
                    Node = XmlDoc.DocumentElement.AppendChild(Ele)
                End If

                For n = 1 To Paths.Length - 1
                    If Paths(n) = "" Then Continue For

                    Node2 = Node.SelectSingleNode(Paths(n))
                    If Node2 Is Nothing Then
                        Ele = XmlDoc.CreateElement(Paths(n))
                        Node2 = Node.AppendChild(Ele)
                    End If
                    Node = Node2
                Next
                '键名是否为空
                If aKey = "" Then
                    Node.RemoveAll()
                Else
                    Ele = Node.Item(aKey)

                    If Ele Is Nothing Then
                        Ele = XmlDoc.CreateElement(aKey)
                        Node.AppendChild(Ele)
                    End If
                    '值是否为空
                    If aValue = "" Then
                        Node.RemoveChild(Ele)
                    Else
                        Ele.InnerText = aValue
                    End If
                End If
            Catch ex As Exception
                Debug.Print(ex.Message)
                Return False
            End Try
        End If

        XmlDoc.Save(XmlFile)
        Return True
    End Function

    Public Function Read(ByVal aSection As String, ByVal aKey As String, Optional ByVal aDefaultValue As String = "") As String
        Dim Node As XmlNode
        Node = (XmlDoc.DocumentElement).SelectSingleNode(aSection & "/" & aKey)
        If Node Is Nothing Then Return aDefaultValue
        Return Node.InnerText
    End Function
End Class


