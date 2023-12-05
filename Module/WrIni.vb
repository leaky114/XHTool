Module WrIni
    Public Sub InAISettingIniWriteSetting()
        'Save Settings
        On Error Resume Next

        ini.WriteStrINI("iProperty", "MapStochNum", Map_DrawingNnumber, IniFile)
        ini.WriteStrINI("iProperty", "MapPartName", Map_PartName, IniFile)
        ini.WriteStrINI("iProperty", "MapPartNum", Map_ERPCode, IniFile)
        ini.WriteStrINI("iProperty", "Map_Vendor", Map_Vendor, IniFile)
        ini.WriteStrINI("iProperty", "MapMirStochNum", Map_Mir_StochNum, IniFile)
        ini.WriteStrINI("iProperty", "MapMirPartName", Map_Mir_PartName, IniFile)

        ini.WriteStrINI("比例质量", "MapDrawingScale", Map_DrawingScale, IniFile)
        ini.WriteStrINI("比例质量", "IsSetDrawingScale", IsSetDrawingScale, IniFile)
        ini.WriteStrINI("比例质量", "MapMass", Map_Mass, IniFile)
        ini.WriteStrINI("比例质量", "IsSetMass", IsSetMass, IniFile)

        ini.WriteStrINI("精度", "Mass_Accuracy", Mass_Accuracy, IniFile)
        ini.WriteStrINI("精度", "Area_Accuracy", Area_Accuracy, IniFile)


        ini.WriteStrINI("BOM", "BOMTiTle", BOMTiTle, IniFile)
        ini.WriteStrINI("BOM", "BasicExcelFullFileName", BasicExcelFullFileName, IniFile)
        ini.WriteStrINI("BOM", "Sheet_Name", SheetName, IniFile)
        ini.WriteStrINI("BOM", "Table_Array", TableArrays, IniFile)
        ini.WriteStrINI("BOM", "Col_Index_Num", ColIndexNum, IniFile)

        ini.WriteStrINI("打印", "MapPrintDay", Map_PrintDay, IniFile)
        ini.WriteStrINI("打印", "IsOpenPrint", IsOpenPrint, IniFile)
        ini.WriteStrINI("打印", "EngineerName", EngineerName, IniFile)
        ini.WriteStrINI("打印", "IsDayAndName", IsDayAndName, IniFile)
        ini.WriteStrINI("打印", "Printer", Printer, IniFile)
        ini.WriteStrINI("打印", "IsPaperA3", IsPaperA3, IniFile)
        ini.WriteStrINI("打印", "IsSign", IsSign, IniFile)
        ini.WriteStrINI("打印", "SaveAsDwgPdf", SaveAsDawAndPdf, IniFile)
        ini.WriteStrINI("打印", "PrintSetting", PrintSetting, IniFile)

        ini.WriteStrINI("更新", "CheckUpdate", CheckUpdate, IniFile)
        ini.WriteStrINI("更新", "Server", Server, IniFile)
        ini.WriteStrINI("更新", "ServerExcelFileName", ServerExcelFileName, IniFile)
        ini.WriteStrINI("更新", "SimpleUpdater", SimpleUpdater, IniFile)
        ini.WriteStrINI("更新", "NewVersionTxt", NewVersionTxt, IniFile)

        ini.WriteStrINI("工程图", "TitleBlockIdwDoc", TitleBlockIdwDoc, IniFile)
    End Sub

    Public Sub InAISettingIniReadSetting()
        'On Error Resume Next
        Map_DrawingNnumber = ini.GetStrFromINI("iProperty", "MapStochNum", "库存编号", IniFile)
        Map_PartName = ini.GetStrFromINI("iProperty", "MapPartName", "零件代号", IniFile)
        Map_ERPCode = ini.GetStrFromINI("iProperty", "MapPartNum", "成本中心", IniFile)
        Map_Vendor = ini.GetStrFromINI("iProperty", "Map_Vendor", "供应商", IniFile)
        Map_Mir_StochNum = ini.GetStrFromINI("iProperty", "MapMirStochNum", "对称件代号", IniFile)
        Map_Mir_PartName = ini.GetStrFromINI("iProperty", "MapMirPartName", "对称件名称", IniFile)

        Map_DrawingScale = ini.GetStrFromINI("比例质量", "MapDrawingScale", "比例", IniFile)
        IsSetDrawingScale = ini.GetStrFromINI("比例质量", "IsSetDrawingScale", "1", IniFile)
        Map_Mass = ini.GetStrFromINI("比例质量", "MapMass", "质量", IniFile)
        IsSetMass = ini.GetStrFromINI("比例质量", "IsSetMass", "-1", IniFile)

        Mass_Accuracy = ini.GetStrFromINI("精度", "Mass_Accuracy", "2", IniFile)
        Area_Accuracy = ini.GetStrFromINI("精度", "Area_Accuracy", "4", IniFile)

        BOMTiTle = ini.GetStrFromINI("BOM", "BOMTiTle", "库存编号|成本中心|零件代号|材料|质量|所属装配代号|数量|总数量|描述|供应商", IniFile)
        BasicExcelFullFileName = ini.GetStrFromINI("BOM", "BasicExcelFullFileName", "", IniFile)
        'CustomExcelFullFileName = ini.GetStrFromINI("", "Map_DrawingNnumber", ""
        SheetName = ini.GetStrFromINI("BOM", "Sheet_Name", "物料", IniFile)
        TableArrays = ini.GetStrFromINI("BOM", "Table_Array", "D,E,F", IniFile)
        ColIndexNum = ini.GetStrFromINI("BOM", "Col_Index_Num", "C", IniFile)

        Map_PrintDay = ini.GetStrFromINI("打印", "MapPrintDay", "打印日期", IniFile)
        IsOpenPrint = ini.GetStrFromINI("打印", "IsOpenPrint", "-1", IniFile)
        EngineerName = ini.GetStrFromINI("打印", "EngineerName", "", IniFile)
        IsDayAndName = ini.GetStrFromINI("打印", "IsDayAndName", "-1", IniFile)
        Printer = ini.GetStrFromINI("打印", "Printer", "", IniFile)
        IsPaperA3 = ini.GetStrFromINI("打印", "IsPaperA3", "1", IniFile)
        IsSign = ini.GetStrFromINI("打印", "IsSign", "1", IniFile)
        SaveAsDawAndPdf = ini.GetStrFromINI("打印", "SaveAsDawAndPdf", "不另存", IniFile)
        PrintSetting = ini.GetStrFromINI("打印", "PrintSetting", "1101111001", IniFile)


        CheckUpdate = ini.GetStrFromINI("更新", "CheckUpdate", "1", IniFile)
        Server = ini.GetStrFromINI("更新", "Server", "\\Likai-pc\发行版\更新包\", IniFile)
        ServerExcelFileName = ini.GetStrFromINI("更新", "ServerExcelFileName", "最新物料编码.xlsx", IniFile)
        SimpleUpdater = ini.GetStrFromINI("更新", "SimpleUpdater", "SimpleUpdater.exe", IniFile)
        NewVersionTxt = ini.GetStrFromINI("更新", "NewVersionTxt", "NewVersion.txt", IniFile)

        TitleBlockIdwDoc = ini.GetStrFromINI("工程图", "TitleBlockIdwDoc", My.Application.Info.DirectoryPath & "\模板.idw", IniFile)

    End Sub

    'Public Sub InAISettingDefaultValue()
    '    On Error Resume Next
    '    Map_DrawingNnumber = "库存编号"
    '    Map_PartName = "零件代号"
    '    Map_ERPCode = "成本中心"
    '    Map_Vendor = "供应商"
    '    Map_Mir_StochNum = "对称件代号"
    '    Map_Mir_PartName = "对称件名称"

    '    Map_DrawingScale = "比例"
    '    IsSetDrawingScale = "1"
    '    Map_Mass = "质量"
    '    IsSetMass = "-1"

    '    Map_PrintDay = "打印日期"
    '    IsOpenPrint = "-1"
    '    EngineerName = ""
    '    IsDayAndName = "-1"
    '    BOMTiTle = "库存编号|成本中心|零件代号|材料|质量|所属装配代号|数量|总数量|描述|供应商"
    '    Mass_Accuracy = "2"
    '    Area_Accuracy = "4"
    '    CheckUpdate = "1"
    '    BasicExcelFullFileName = ""
    '    'CustomExcelFullFileName = ""
    '    SheetName = "物料"
    '    TableArrays = "D,E,F"
    '    ColIndexNum = "C"
    '    IsPaperA3 = "1"
    '    IsSign = "1"
    '    SaveAsDawAndPdf = "不另存"

    '    Server = "\\Likai-pc\发行版\更新包\"
    '    ServerExcelFileName = "最新物料编码.xlsx"
    '    SimpleUpdater = "SimpleUpdater.exe"
    '    NewVersionTxt = "NewVersion.txt"

    '    TitleBlockIdwDoc = My.Application.Info.DirectoryPath & "\模板.idw"

    '    PrintSetting = "1101111001"

    'End Sub
End Module
