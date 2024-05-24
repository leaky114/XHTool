Module WrIni
    Public Sub InAISettingIniWriteSetting()
        'Save Settings
        On Error Resume Next

        ini.WriteStrINI("iProperty", "MapStochNum", Map_DrawingNnumber, Inifile)
        ini.WriteStrINI("iProperty", "MapPartName", Map_PartName, Inifile)
        ini.WriteStrINI("iProperty", "MapPartNum", Map_ERPCode, Inifile)
        ini.WriteStrINI("iProperty", "Map_Vendor", Map_Vendor, Inifile)
        ini.WriteStrINI("iProperty", "MapMirStochNum", Map_Mir_StochNum, Inifile)
        ini.WriteStrINI("iProperty", "MapMirPartName", Map_Mir_PartName, Inifile)

        ini.WriteStrINI("比例质量", "MapDrawingScale", Map_DrawingScale, Inifile)
        ini.WriteStrINI("比例质量", "IsSetDrawingScale", IsSetDrawingScale, Inifile)
        ini.WriteStrINI("比例质量", "MapMass", Map_Mass, Inifile)
        ini.WriteStrINI("比例质量", "IsSetMass", IsSetMass, Inifile)

        ini.WriteStrINI("精度", "Mass_Accuracy", Mass_Accuracy, Inifile)
        ini.WriteStrINI("精度", "Area_Accuracy", Area_Accuracy, Inifile)


        ini.WriteStrINI("BOM", "BOMTiTle", BOMTiTle, Inifile)
        ini.WriteStrINI("BOM", "BasicExcelFullFileName", BasicExcelFullFileName, Inifile)
        ini.WriteStrINI("BOM", "Sheet_Name", SheetName, Inifile)
        ini.WriteStrINI("BOM", "Table_Array", TableArrays, Inifile)
        ini.WriteStrINI("BOM", "Col_Index_Num", ColIndexNum, Inifile)

        ini.WriteStrINI("模型", "变更工程图扩展名", str变更工程图扩展名, Inifile)
        ini.WriteStrINI("模型", "另存到子文件夹", str另存到子文件夹, Inifile)
        ini.WriteStrINI("模型", "查找文件夹层数", str查找文件夹层数, Inifile)
        ini.WriteStrINI("模型", "检查重复图号", Is检查重复图号, Inifile)

        ini.WriteStrINI("打印", "MapPrintDay", Map_PrintDay, Inifile)
        ini.WriteStrINI("打印", "IsOpenPrint", IsOpenPrint, Inifile)
        ini.WriteStrINI("打印", "EngineerName", EngineerName, Inifile)
        ini.WriteStrINI("打印", "IsDayAndName", IsDayAndName, Inifile)
        ini.WriteStrINI("打印", "Printer", Printer, Inifile)
        ini.WriteStrINI("打印", "IsPaperA3", IsPaperA3, Inifile)
        ini.WriteStrINI("打印", "IsSign", IsSign, Inifile)
        ini.WriteStrINI("打印", "SaveAsDwgPdf", SaveAsDawAndPdf, Inifile)
        ini.WriteStrINI("打印", "PrintSetting", PrintSetting, Inifile)

        ini.WriteStrINI("更新", "CheckUpdate", CheckUpdate, Inifile)
        ini.WriteStrINI("更新", "Server", Server, Inifile)
        ini.WriteStrINI("更新", "ServerExcelFileName", ServerExcelFileName, Inifile)
        ini.WriteStrINI("更新", "SimpleUpdater", SimpleUpdater, Inifile)
        ini.WriteStrINI("更新", "NewVersionTxt", NewVersionTxt, Inifile)

        ini.WriteStrINI("展开图", "展开图模板", str展开图模板, Inifile)
        ini.WriteStrINI("展开图", "向上颜色", str向上颜色, Inifile)
        ini.WriteStrINI("展开图", "向下颜色", str向下颜色, Inifile)
        ini.WriteStrINI("展开图", "向上线型", str向上线型, Inifile)
        ini.WriteStrINI("展开图", "向下线型", str向下线型, Inifile)
        ini.WriteStrINI("展开图", "向上线宽", str向上线宽, Inifile)
        ini.WriteStrINI("展开图", "向下线宽", str向下线宽, Inifile)
        ini.WriteStrINI("展开图", "展开图标注", str展开图标注, Inifile)

        ini.WriteStrINI("工程图", "工程图模板", str工程图模板, Inifile)
        ini.WriteStrINI("工程图", "自动展开图", str自动展开图, Inifile)
        ini.WriteStrINI("工程图", "第三视角", str第三视角, Inifile)
        ini.WriteStrINI("工程图", "相切边", str相切边, Inifile)
        ini.WriteStrINI("工程图", "螺纹特征", str螺纹特征, Inifile)
        ini.WriteStrINI("工程图", "标注尺寸", str标注尺寸, Inifile)
        ini.WriteStrINI("工程图", "样式", str样式, Inifile)

        ini.WriteStrINI("工程图", "左视图", str选择视图.str左视图, Inifile)
        ini.WriteStrINI("工程图", "右视图", str选择视图.str右视图, Inifile)
        ini.WriteStrINI("工程图", "俯视图", str选择视图.str俯视图, Inifile)
        ini.WriteStrINI("工程图", "仰视图", str选择视图.str仰视图, Inifile)

        ini.WriteStrINI("工程图", "上边距", str页边距.short上边距, Inifile)
        ini.WriteStrINI("工程图", "下边距", str页边距.short下边距, Inifile)
        ini.WriteStrINI("工程图", "左边距", str页边距.short左边距, Inifile)
        ini.WriteStrINI("工程图", "右边距", str页边距.short右边距, Inifile)

        ini.WriteStrINI("工程图", "部件图框", str部件图框, Inifile)
        ini.WriteStrINI("工程图", "零件图框", str零件图框, Inifile)

        ini.WriteStrINI("工程图", "模型匹配检查", str模型匹配检查, Inifile)

        ini.WriteStrINI("工程图", "逆时针序号", str逆时针序号, Inifile)


    End Sub

    Public Sub InAISettingIniReadSetting()
        'On Error Resume Next
        Map_DrawingNnumber = ini.GetStrFromINI("iProperty", "MapStochNum", "库存编号", Inifile)
        Map_PartName = ini.GetStrFromINI("iProperty", "MapPartName", "零件代号", Inifile)
        Map_ERPCode = ini.GetStrFromINI("iProperty", "MapPartNum", "成本中心", Inifile)
        Map_Vendor = ini.GetStrFromINI("iProperty", "Map_Vendor", "供应商", Inifile)
        Map_Mir_StochNum = ini.GetStrFromINI("iProperty", "MapMirStochNum", "对称件代号", Inifile)
        Map_Mir_PartName = ini.GetStrFromINI("iProperty", "MapMirPartName", "对称件名称", Inifile)

        Map_DrawingScale = ini.GetStrFromINI("比例质量", "MapDrawingScale", "比例", Inifile)
        IsSetDrawingScale = ini.GetStrFromINI("比例质量", "IsSetDrawingScale", "1", Inifile)
        Map_Mass = ini.GetStrFromINI("比例质量", "MapMass", "质量", Inifile)
        IsSetMass = ini.GetStrFromINI("比例质量", "IsSetMass", "-1", Inifile)

        Mass_Accuracy = ini.GetStrFromINI("精度", "Mass_Accuracy", "2", Inifile)
        Area_Accuracy = ini.GetStrFromINI("精度", "Area_Accuracy", "4", Inifile)

        BOMTiTle = ini.GetStrFromINI("BOM", "BOMTiTle", "库存编号|成本中心|零件代号|材料|质量|所属装配代号|数量|总数量|描述|供应商", Inifile)
        BasicExcelFullFileName = ini.GetStrFromINI("BOM", "BasicExcelFullFileName", "", Inifile)
        'CustomExcelFullFileName = ini.GetStrFromINI("", "Map_DrawingNnumber", ""
        SheetName = ini.GetStrFromINI("BOM", "Sheet_Name", "物料", Inifile)
        TableArrays = ini.GetStrFromINI("BOM", "Table_Array", "D,E,F", Inifile)
        ColIndexNum = ini.GetStrFromINI("BOM", "Col_Index_Num", "C", Inifile)

        str变更工程图扩展名 = ini.GetStrFromINI("模型", "变更工程图扩展名", "-1", Inifile)
        str另存到子文件夹 = ini.GetStrFromINI("模型", "另存到子文件夹", "-1", Inifile)
        str查找文件夹层数 = ini.GetStrFromINI("模型", "查找文件夹层数", "2", Inifile)
        Is检查重复图号 = ini.GetStrFromINI("模型", "检查重复图号", "-1", Inifile)

        Map_PrintDay = ini.GetStrFromINI("打印", "MapPrintDay", "打印日期", Inifile)
        IsOpenPrint = ini.GetStrFromINI("打印", "IsOpenPrint", "-1", Inifile)
        EngineerName = ini.GetStrFromINI("打印", "EngineerName", "", Inifile)
        IsDayAndName = ini.GetStrFromINI("打印", "IsDayAndName", "-1", Inifile)
        Printer = ini.GetStrFromINI("打印", "Printer", "", Inifile)
        IsPaperA3 = ini.GetStrFromINI("打印", "IsPaperA3", "1", Inifile)
        IsSign = ini.GetStrFromINI("打印", "IsSign", "1", Inifile)
        SaveAsDawAndPdf = ini.GetStrFromINI("打印", "SaveAsDwgPdf", "不另存", Inifile)
        PrintSetting = ini.GetStrFromINI("打印", "PrintSetting", "1101111001", Inifile)


        CheckUpdate = ini.GetStrFromINI("更新", "CheckUpdate", "1", Inifile)
        Server = ini.GetStrFromINI("更新", "Server", "\\Likai-pc\发行版\更新包\", Inifile)
        ServerExcelFileName = ini.GetStrFromINI("更新", "ServerExcelFileName", "最新物料编码.xlsx", Inifile)
        SimpleUpdater = ini.GetStrFromINI("更新", "SimpleUpdater", "SimpleUpdater.exe", Inifile)
        NewVersionTxt = ini.GetStrFromINI("更新", "NewVersionTxt", "NewVersion.txt", Inifile)

        str展开图模板 = ini.GetStrFromINI("展开图", "展开图模板", My.Application.Info.DirectoryPath & "\模板.idw", Inifile)

        str向上颜色 = ini.GetStrFromINI("展开图", "向上颜色", "#0000FF", Inifile)
        str向下颜色 = ini.GetStrFromINI("展开图", "向下颜色", "#FF0000", Inifile)

        str向上线型 = ini.GetStrFromINI("展开图", "向上线型", "虚线", Inifile)
        str向下线型 = ini.GetStrFromINI("展开图", "向下线型", "点长画线", Inifile)

        str向上线宽 = ini.GetStrFromINI("展开图", "向上线宽", "0.18", Inifile)
        str向下线宽 = ini.GetStrFromINI("展开图", "向下线宽", "0.18", Inifile)

        str展开图标注 = ini.GetStrFromINI("展开图", "展开图标注", "1", Inifile)

        str工程图模板 = ini.GetStrFromINI("工程图", "工程图模板", My.Application.Info.DirectoryPath & "\模板.idw", Inifile)
        str自动展开图 = ini.GetStrFromINI("工程图", "自动展开图", "0", Inifile)
        str第三视角 = ini.GetStrFromINI("工程图", "第三视角", "0", Inifile)
        str相切边 = ini.GetStrFromINI("工程图", "相切边", "0", Inifile)
        str螺纹特征 = ini.GetStrFromINI("工程图", "螺纹特征", "1", Inifile)
        str标注尺寸 = ini.GetStrFromINI("工程图", "标注尺寸", "1", Inifile)
        str样式 = ini.GetStrFromINI("工程图", "样式", "1", Inifile)


        str选择视图.str左视图 = Val(ini.GetStrFromINI("工程图", "左视图", "1", Inifile))
        str选择视图.str右视图 = Val(ini.GetStrFromINI("工程图", "右视图", "0", Inifile))
        str选择视图.str俯视图 = Val(ini.GetStrFromINI("工程图", "俯视图", "1", Inifile))
        str选择视图.str仰视图 = Val(ini.GetStrFromINI("工程图", "仰视图", "0", Inifile))

        str页边距.short上边距 = Val(ini.GetStrFromINI("工程图", "上边距", "20", Inifile))
        str页边距.short下边距 = Val(ini.GetStrFromINI("工程图", "下边距", "50", Inifile))
        str页边距.short左边距 = Val(ini.GetStrFromINI("工程图", "左边距", "25", Inifile))
        str页边距.short右边距 = Val(ini.GetStrFromINI("工程图", "右边距", "10", Inifile))

        str部件图框 = ini.GetStrFromINI("工程图", "部件图框", "", Inifile)
        str零件图框 = ini.GetStrFromINI("工程图", "零件图框", "", Inifile)

        str模型匹配检查 = ini.GetStrFromINI("工程图", "模型匹配检查", "1", Inifile)
        str逆时针序号 = ini.GetStrFromINI("工程图", "逆时针序号", "1", Inifile)

    End Sub

End Module
