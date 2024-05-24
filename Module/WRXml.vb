Imports System.IO
Imports System.Xml

Module WrXml

    Public Sub InAISettingXmlWriteSetting()
        'Save Settings
        On Error Resume Next
        Dim FPath As String = My.Application.Info.DirectoryPath & Iif(Strings.Right(My.Application.Info.DirectoryPath, 1) = "\", "InAISetting.xml", "\InAISetting.xml")

        if File.Exists(FPath) = True Then
            File.Delete(FPath)
        End if

        Dim XWriter As New Xml.XmlTextWriter(FPath, System.Text.Encoding.GetEncoding("UTF-8"))

        XWriter.Formatting = Xml.Formatting.Indented
        XWriter.WriteRaw("<?xml version=""1.0"" encoding=""utf-8"" ?>")

        XWriter.WriteStartElement("InAISetting")

        XWriter.WriteElementString("MapStochNum", Map_DrawingNnumber)
        XWriter.WriteElementString("MapPartName", Map_PartName)
        XWriter.WriteElementString("MapPartNum", Map_ERPCode)
        XWriter.WriteElementString("Map_Vendor", Map_Vendor)

        XWriter.WriteElementString("MapMirStochNum", Map_Mir_StochNum)
        XWriter.WriteElementString("MapMirPartName", Map_Mir_PartName)

        XWriter.WriteElementString("MapDrawingScale", Map_DrawingScale)
        XWriter.WriteElementString("IsSetDrawingScale", IsSetDrawingScale)

        XWriter.WriteElementString("MapMass", Map_Mass)
        XWriter.WriteElementString("IsSetMass", IsSetMass)

        XWriter.WriteElementString("MapPrintDay", Map_PrintDay)
        XWriter.WriteElementString("IsOpenPrint", IsOpenPrint)

        XWriter.WriteElementString("EngineerName", EngineerName)
        XWriter.WriteElementString("IsDayAndName", IsDayAndName)

        XWriter.WriteElementString("BOMTiTle", BOMTiTle)
        XWriter.WriteElementString("Mass_Accuracy", Mass_Accuracy)
        XWriter.WriteElementString("Area_Accuracy", Area_Accuracy)

        XWriter.WriteElementString("CheckUpdate", CheckUpdate)

        XWriter.WriteElementString("BasicExcelFullFileName", BasicExcelFullFileName)
        'XWriter.WriteElementString("CustomExcelFullFileName", CustomExcelFullFileName)

        XWriter.WriteElementString("Sheet_Name", SheetName)
        XWriter.WriteElementString("Table_Array", TableArrays)
        XWriter.WriteElementString("Col_Index_Num", ColIndexNum)

        XWriter.WriteElementString("Printer", Printer)
        XWriter.WriteElementString("IsPaperA3", IsPaperA3)
        XWriter.WriteElementString("IsSign", IsSign)
        XWriter.WriteElementString("SaveAsDwgPdf", SaveAsDawAndPdf)

        XWriter.WriteElementString("Server", Server)
        XWriter.WriteElementString("ServerExcelFileName", ServerExcelFileName)
        XWriter.WriteElementString("SimpleUpdater", SimpleUpdater)
        XWriter.WriteElementString("NewVersionTxt", NewVersionTxt)

        XWriter.WriteElementString("工程图模板", str工程图模板)

        XWriter.WriteElementString("PrintSetting", PrintSetting)

        XWriter.WriteEndElement()

        XWriter.Close()

    End Sub

    Public Sub InAISettingXmlReadSetting()
        'Load Settings
        On Error Resume Next
        Dim FPath As String = My.Application.Info.DirectoryPath & Iif(Strings.Right(My.Application.Info.DirectoryPath, 1) = "\", "InAISetting.xml", "\InAISetting.xml")
        Dim txtReader As StreamReader = Nothing

        if File.Exists(FPath) = True Then

            Dim XDoc As New Xml.XmlDocument
            XDoc.Load(FPath)

            Dim XReader As New Xml.XmlNodeReader(XDoc)
            Dim ParaName As String = ""

            While XReader.Read
                Select Case XReader.NodeType
                    Case Xml.XmlNodeType.Element
                        ParaName = XReader.Name
                    Case Xml.XmlNodeType.Text
                        Select Case ParaName
                            Case "MapStochNum" : Map_DrawingNnumber = XReader.Value
                            Case "MapPartName" : Map_PartName = XReader.Value
                            Case "MapPartNum" : Map_ERPCode = XReader.Value
                            Case "Map_Vendor" : Map_Vendor = XReader.Value
                            Case "MapMirStochNum" : Map_Mir_StochNum = XReader.Value
                            Case "MapMirPartName" : Map_Mir_PartName = XReader.Value

                            Case "MapDrawingScale" : Map_DrawingScale = XReader.Value
                            Case "IsSetDrawingScale" : IsSetDrawingScale = XReader.Value

                            Case "MapMass" : Map_Mass = XReader.Value
                            Case "IsSetMass" : IsSetMass = XReader.Value

                            Case "MapPrintDay" : Map_PrintDay = XReader.Value
                            Case "IsOpenPrint" : IsOpenPrint = XReader.Value

                            Case "EngineerName" : EngineerName = XReader.Value
                            Case "IsDayAndName" : IsDayAndName = XReader.Value

                            Case "BOMTiTle" : BOMTiTle = XReader.Value
                            Case "Mass_Accuracy" : Mass_Accuracy = XReader.Value
                            Case "Area_Accuracy" : Area_Accuracy = XReader.Value

                            Case "CheckUpdate" : CheckUpdate = XReader.Value

                            Case "BasicExcelFullFileName" : BasicExcelFullFileName = XReader.Value
                                'Case "CustomExcelFullFileName" : CustomExcelFullFileName = XReader.Value

                            Case "Sheet_Name" : SheetName = XReader.Value
                            Case "Table_Array" : TableArrays = XReader.Value
                            Case "Col_Index_Num" : ColIndexNum = XReader.Value

                            Case "Printer" : Printer = XReader.Value
                            Case "IsPaperA3" : IsPaperA3 = XReader.Value
                            Case "IsSign" : IsSign = XReader.Value
                            Case "SaveAsDwgPdf" : SaveAsDawAndPdf = XReader.Value

                            Case "Server" : Server = XReader.Value
                            Case "ServerExcelFileName" : ServerExcelFileName = XReader.Value
                            Case "SimpleUpdater" : SimpleUpdater = XReader.Value
                            Case "NewVersionTxt" : NewVersionTxt = XReader.Value

                            Case "Drawing_Templates" : str工程图模板 = XReader.Value

                            Case "PrintSetting" : PrintSetting = XReader.Value

                        End Select
                End Select
            End While

        End if
    End Sub

    Public Sub InAISettingDefaultValue()
        On Error Resume Next
        Map_DrawingNnumber = "库存编号"
        Map_PartName = "零件代号"
        Map_ERPCode = "成本中心"
        Map_Vendor = "供应商"
        Map_Mir_StochNum = "对称件代号"
        Map_Mir_PartName = "对称件名称"
        Map_DrawingScale = "比例"
        IsSetDrawingScale = "1"
        Map_Mass = "质量"
        IsSetMass = "-1"
        Map_PrintDay = "打印日期"
        IsOpenPrint = "-1"
        EngineerName = ""
        IsDayAndName = "-1"
        BOMTiTle = "库存编号|成本中心|零件代号|材料|质量|所属装配代号|数量|总数量|描述|供应商"
        Mass_Accuracy = "2"
        Area_Accuracy = "4"
        CheckUpdate = "1"
        BasicExcelFullFileName = ""
        'CustomExcelFullFileName = ""
        SheetName = "物料"
        TableArrays = "D,E,F"
        ColIndexNum = "C"
        IsPaperA3 = "1"
        IsSign = "1"
        SaveAsDawAndPdf = "不另存"

        Server = "\\Likai-pc\发行版\更新包\"
        ServerExcelFileName = "最新物料编码.xlsx"
        SimpleUpdater = "SimpleUpdater.exe"
        NewVersionTxt = "NewVersion.txt"

        str工程图模板 = My.Application.Info.DirectoryPath & "\模板.idw"
        str展开图模板 = My.Application.Info.DirectoryPath & "\模板.idw"

        PrintSetting = "1101111001"

    End Sub

End Module