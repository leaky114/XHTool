Imports Inventor
Imports Inventor.AssetTypeEnum
Imports Inventor.BOMStructureEnum
Imports Inventor.DocumentTypeEnum
Imports Inventor.DrawingViewTypeEnum
Imports Inventor.IOMechanismEnum
Imports Inventor.PrintOrientationEnum
Imports Inventor.PropertyTypeEnum
Imports Inventor.SelectionFilterEnum

Module PublicParameters
    Public Structure StockNumPartName
        Dim IsGet As Boolean
        Dim 图号 As String    '
        Dim 零件名称 As String      '
        Dim ERP编码 As String
        Dim 价格 As String
    End Structure

    Public Structure BalloonDate
        Dim Balloon As Balloon
        Dim Position As Point2d
    End Structure

    Public ThisApplication As Inventor.Application

    'Public ThisApprenticeApp As Inventor.ApprenticeServerComponent   '学徒服务器

    Public WithEvents ThisApplicationEvents As ApplicationEvents

    Public ClientID As String

    Public DWG As String = ".dwg"
    Public IAM As String = ".iam"
    Public IPT As String = ".ipt"
    Public IDW As String = ".idw"
    Public OLD As String = ".old"
    Public PDF As String = ".pdf"
    Public STP As String = ".stp"

    Public ContentCenterFiles As String  '零件库文件夹

    Public DisplayVersion As String

    Public IsAutoSetPartName As Boolean  'true 为进行中，false则退出进程

    Public str查找文件夹层数 As Integer = "2" '返回父文件夹的层数

    Public Is检查重复图号 As Integer   '重命名时是否检查图号重复  '1为检查，0为不检查

    Public Map_DrawingNnumber As String   '映射图号
    Public Map_PartName As String   '映射文件名
    Public Map_ERPCode As String    '映射存货编码
    Public Map_Describe As String = "描述"     '映射描述

    Public Map_Mir_StochNum As String   '映射对称件图号
    Public Map_Mir_PartName As String   '映射对称件文件名

    Public Map_DrawingScale As String '映射比例
    Public Map_Mass As String '映射质量

    Public Map_PrintDay As String '映射打印时间
    Public IsOpenPrint As String    '设置打印时间后是否进入打印预览
    Public IsDayAndName As String   '同时签字

    Public EngineerName As String '工程师

    Public Map_Vendor As String '供应商

    Public Map_Price As String = "成本" '价格

    Public BOMTiTle As String       '导出BOM用的项目

    Public Mass_Accuracy As String '质量精度
    Public Area_Accuracy As String  '面积精度

    Public IsSetDrawingScale As String    '打开工程图时是否写 比例 到ipro   是赋值为1
    Public IsSetMass As String   '打开工程图时是否写 质量 到ipro  是赋值为1

    Public CheckUpdate As String    '启动检查更新

    Public TotalItem As Integer 'BOM序号

    Public OPosition(9) As Point   '点
    Public TempPoint(9) As SketchPoint   '临时绘制的点

    Public IsShowUpdateMsg As Boolean    '检查更新时是否显示是最新版本的msgbox

    Public str模型匹配检查 As String   '工程图是否检查模型名
    Public int模型匹配检查标记 As Integer  '标记打开工程图时，是否检查模型匹配：0为要检查，1为不检查

    '默认打印设值
    Public Printer As String   '默认打印机

    Public IsPaperA3 As Integer   '1：匹配A3纸，0：按原图纸大小打印
    Public IsSign As Integer       '1：签字，0：不签字
    Public SaveAsDawAndPdf As String



    '批量打印设置
    Public PrintSetting As String

    '快速打开选择的文件
    Public strQuitOpenSelectFileFullName As String


    '展开图设置
    Public str向上线型 As String
    Public str向上线宽 As String
    Public str向上颜色 As String

    Public str向下线型 As String
    Public str向下线宽 As String
    Public str向下颜色 As String

    Public str展开图标注 As String



    '工程图模板
    Public str工程图模板 As String

    '展开图模板
    Public str展开图模板 As String

    Public str自动展开图 As String
    Public str第三视角 As String
    Public str相切边 As String
    Public str螺纹特征 As String
    Public str样式 As String   '0 显示隐藏线,1 不显示隐藏线,2着色
    Public str标注尺寸 As String


    '工程图图框
    Public str部件图框 As String
    Public str零件图框 As String


    '变更工程图扩展名

    Public str变更工程图扩展名 As String

    Public Structure 选择视图
        Dim str左视图 As String
        Dim str右视图 As String
        Dim str俯视图 As String
        Dim str仰视图 As String
    End Structure

    Public Structure 页边距
        Dim short上边距 As Double
        Dim short下边距 As Double
        Dim short左边距 As Double
        Dim short右边距 As Double
    End Structure

    Public str页边距 As 页边距
    Public str选择视图 As 选择视图

    Public str另存到子文件夹 As String
    Public str逆时针序号 As String

    '声明并初始化变量
    Public _ListViewSorter As clsListViewSorter.EnumSortOrder = clsListViewSorter.EnumSortOrder.Ascending

    '-------------------------------------------------------------------------------------------------------

    '保存文件时的事件
    'Public Sub ThisApplicationEvents_OnOnSaveDocument(ByVal DocumentObject As Inventor._Document, _
    '                                                ByVal BeforeOrAfter As Inventor.EventTimingEnum, _
    '                                                 ByVal Context As Inventor.NameValueMap, _
    '                                                 ByRef HandlingCode As Inventor.HandlingCodeEnum) Handles ThisApplicationEvents.OnSaveDocument

    'End Sub

    '打开文件时的事件
    Public Sub ThisApplicationEvents_OnOpenDocument(ByVal oInventorDocument As Inventor.Document, _
                                    ByVal FullDocumentName As String, _
                                   ByVal BeforeOrAfter As Inventor.EventTimingEnum, _
                                  ByVal Context As Inventor.NameValueMap, _
                                  ByRef HandlingCode As Inventor.HandlingCodeEnum) Handles ThisApplicationEvents.OnOpenDocument


        '视图全部缩放，这个功能有问题，取消
        'ThisApplication.CommandManager.ControlDefinitions.Item("AppZoomAllCmd").Execute()

        if BeforeOrAfter = EventTimingEnum.kBefore Then
            'MsgBox("before")

        Else

            '当打开文件为工程图()
            if oInventorDocument.DocumentType = kDrawingDocumentObject Then
                '写入主视图比例
                'if IsSetDrawingScale = 1 Then
                SetDrawingScale(oInventorDocument)
                'End if

                '写入零部件质量
                'if IsSetMass = 1 Then
                SetMass(oInventorDocument)
                'End if

                if str模型匹配检查 = 1 Then
                    Select Case int模型匹配检查标记
                        Case Is = 0
                            if CheckDrawingDocumentNameToReferencedDocument(oInventorDocument) = False Then
                                MsgBox("本文件名与模型参考不匹配！", MsgBoxStyle.Information, "检查模型参考")
                            End if
                            int模型匹配检查标记 = 1
                        Case Is = 1
                            int模型匹配检查标记 = 0
                        Case Is = 2

                    End Select
                End if

            End if

            End if

    End Sub

    '激活一个文档时的事件
    Public Sub ThisApplicationEvents_OnActivateDocument(ByVal oInventorDocument As Inventor.Document, _
                                                        ByVal BeforeOrAfter As Inventor.EventTimingEnum, _
                                                        ByVal Context As Inventor.NameValueMap, _
                                                        ByRef HandlingCode As Inventor.HandlingCodeEnum) Handles ThisApplicationEvents.OnActivateDocument
        if BeforeOrAfter = EventTimingEnum.kAfter Then

            '在标题栏中显示当前文档路径()
            ThisApplication.Caption = GetFileNameInfo(oInventorDocument.FullDocumentName).Folder & "\"


            '获取文件只读属性
            Dim oDef1 As ButtonDefinition
            oDef1 = ThisApplication.CommandManager.ControlDefinitions.Item("InName文件只读")

            oDef1.Pressed = GetFileReadOnly(oInventorDocument.FullDocumentName)
        Else

        End if

    End Sub


End Module
