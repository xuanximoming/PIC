using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;
using SIS_Function;

namespace ILL
{
    /// <summary>
    /// 读写系统配置文件
    /// </summary>
    public sealed class GetConfig
    {
        public static ApiIni ini = new ApiIni(Application.StartupPath + @"\Settings.ini");    //程序启动目录中的Setting.ini文件
        public static Phoneticize phone = new Phoneticize(Application.StartupPath + @"\PHONEA.txt");    //程序启动目录中的PHONEA.txt文件
        private static ConParam cp = new ConParam();

        /// <summary>
        /// 构造函数
        /// </summary>
        public GetConfig()
        {
        }

        //实例化SIS数据库连接字符串的字段
        public static ConParam GetSisConnStr()
        {
            cp.DBType = SisType;
            cp.Server = SisServer;
            cp.Uid = SisUid;
            cp.Pwd = SisPwd;
            cp.Database = SisDatabase;
            return cp;
        }

        //实例化HIS数据库连接字符串的字段
        public static ConParam GetHisConnStr()
        {
            cp.DBType = hisType;
            cp.Server = hisServer;
            cp.Uid = hisUid;
            cp.Pwd = hisPwd;
            cp.Database = hisDatabase;
            return cp;
        }

        //实例化PACS数据库连接字符串的字段
        public static ConParam GetPacsConnStr()
        {
            cp.DBType = PacsType;
            cp.Server = PacsServer;
            cp.Uid = PacsUid;
            cp.Pwd = PacsPwd;
            cp.Database = PacsDatabase;
            return cp;
        }
        //实例化LIS数据库连接字符串的字段
        public static ConParam GetLisConnStr()
        {
            return null;
        }

        #region 读取设置文件
        //HisConnectoinSetting HIS的连接字段读取
        public static bool hisVisit = bool.Parse(ini.IniReadValue("HisConnectionString", "Visit"));			// 是否连接HIS
        public static bool IsSendTohis = bool.Parse(ini.IniReadValue("HisConnectionString", "IsSendToHIS"));	    //是否发送报告到HIS
        private static string hisType = ini.IniReadValue("HisConnectionString", "DbType");		// 连接HIS类型
        private static string hisDatabase = ini.IniReadValue("HisConnectionString", "Database");		// 数据库HIS类型
        private static string hisUid = ini.IniReadValue("HisConnectionString", "Uid");			// HIS用户名
        private static string hisPwd = ini.IniReadValue("HisConnectionString", "Pwd");			// HIS数据库密码
        private static string hisServer = ini.IniReadValue("HisConnectionString", "Server");    //
        public static string hisVender = ini.IniReadValue("HisConnectionString", "Vender");    //厂家
        private static string hisDriver = ini.IniReadValue("HisConnectionString", "Driver");


        //PacsConnectionSettion PACS的连接字段读取
        public static string DcmServerAE = ini.IniReadValue("PacsConnectionString", "ServerAE");
        public static string DcmIp = ini.IniReadValue("PacsConnectionString", "DicomIP");
        public static int DcmPort = int.Parse(ini.IniReadValue("PacsConnectionString", "DicomPort"));
        public static string LocalAE = ini.IniReadValue("PacsConnectionString", "LocalAE");
        public static string LocalIp = ini.IniReadValue("PacsConnectionString", "LocalIP");		// 连接HIS类型
        public static bool IsConnectPax = bool.Parse(ini.IniReadValue("PacsConnectionString", "IsConnectPax"));		// 数据库HIS类型
        public static bool SendCheckImage = bool.Parse(ini.IniReadValue("PacsConnectionString", "UPUnCheckPicture"));//只发送打勾的图像
        public static string PacsType = ini.IniReadValue("PacsConnectionString", "DbType");		// 连接HIS类型
        public static string PacsDatabase = ini.IniReadValue("PacsConnectionString", "Database");		// 数据库HIS类型
        public static string PacsUid = ini.IniReadValue("PacsConnectionString", "Uid");			// HIS用户名
        public static string PacsPwd = ini.IniReadValue("PacsConnectionString", "Pwd");			// HIS数据库密码
        public static string PacsServer = ini.IniReadValue("PacsConnectionString", "Server");    //
        public static string PacsDriver = ini.IniReadValue("PacsConnectionString", "Driver");

        //systemsetting 系统设置读取
        public static string ExamClass = ini.IniReadValue("SYSTEMSETTING", "EXAM_CLASS");
        public static string Modality = ini.IniReadValue("SYSTEMSETTING", "Modality");
        //public static string IsMutex = ini.IniReadValue("SYSTEMSETTING", "isMutex");
        public static string ModalityName = ini.IniReadValue("SYSTEMSETTING", "ModalityName");
        public static string DALAndModel = ini.IniReadValue("SYSTEMSETTING", "DALAndModel").ToUpper();                            //DAL和Model层命名空间
        public static string Group = ini.IniReadValue("SYSTEMSETTING", "Group");
        //public static string Model = ini.IniReadValue("SYSTEMSETTING", "");                                               //层命名空间
        public static string ExamDeptCode = ini.IniReadValue("SYSTEMSETTING", "ExamDeptCode");                              //系统检查科室代码
        public static string ExamDeptName = ini.IniReadValue("SYSTEMSETTING", "ExamDeptName");                              //系统检查科室名称
        public static string SystemType = ini.IniReadValue("SYSTEMSETTING", "SystemType");                                  //放射科科室管理
        //public static string IsSelectCharge = ini.IniReadValue("SYSTEMSETTING", "IsSelectCharge");                           //是否选择收费
        public static string IsSelectDB = ini.IniReadValue("SYSTEMSETTING", "IsSelectDB");                                 //是否从数据库中选择
        public static string DefaltDeptName = ini.IniReadValue("SYSTEMSETTING", "ExamDeptName");                               //默认检查科室名
        //public static string PatientSource = ini.IniReadValue("SYSTEMSETTING", "PatientSource");                           //病人来源
        public static bool IsAddLocMap = bool.Parse(ini.IniReadValue("SYSTEMSETTING", "IsAddLocMap"));                     //是否加载定位图
        public static bool IsQuickReg = bool.Parse(ini.IniReadValue("SYSTEMSETTING", "IsQuickReg"));                       //是否加载快速登记
        public static bool QueryGroup = bool.Parse(ini.IniReadValue("SYSTEMSETTING", "QueryGroup"));                       //快速查询是否默认查询当前诊室
        public static string ChargeItemClass = ini.IniReadValue("SYSTEMSETTING", "ChargeItemClass");                       //该科室对应的价表项目分类

        // public static string ExamSubClass = ini.IniReadValue("SYSTEMSETTING", "EXAM_SUB_CLASS");
        // public static string PatientSourceCode = ini.IniReadValue("SYSTEMSETTING", "PatientSourceCode");

        //SisConnectionString SIS连接设置字段读取
        public static string SisOdbcMode = ini.IniReadValue("SisConnectionString", "OdbcMode");
        // public static string SisRegister = ini.IniReadValue("SisConnectionString", "Register");                       //;0:本地登记 1:HIS登记 2:PACS登记
        public static string SisType = ini.IniReadValue("SisConnectionString", "DbType");
        public static string SisServer = ini.IniReadValue("SisConnectionString", "Server");
        public static string SisUid = ini.IniReadValue("SisConnectionString", "Uid");
        public static string SisPwd = ini.IniReadValue("SisConnectionString", "Pwd");
        public static string SisDatabase = ini.IniReadValue("SisConnectionString", "Database");
        //public static string Modality = ini.IniReadValue("SisConnectionString", "Modality");
        public static string SisDriver = ini.IniReadValue("SisConnectionString", "Driver");


        //public static string TempPath = ini.IniReadValue("Directory", "TempPath");
        // public static string SisDatabase = ini.IniReadValue("Directory", "Database");
        public static string ServerIp = ini.IniReadValue("Directory", "ServerIp");
        public static int ServerPort = int.Parse(ini.IniReadValue("Directory", "ServerPort"));
        public static string ServerImgDir = ini.IniReadValue("Directory", "ServerImgDir");//服务器文件目录
        //public static string TemplatePath = ini.IniReadValue("Directory", "TemplatePath");
        public static string Dynamic = ini.IniReadValue("Directory", "Dynamic");
        //public static string ImageDirectory = ini.IniReadValue("Directory", "ImageDirectory");
        //public static string BackPath = ini.IniReadValue("Directory", "BackPath");
        public static string HospitalName = ini.IniReadValue("HospitalInformation", "HospitalName");
        public static string ImgEquipment = ini.IniReadValue("HospitalInformation", "ImgEquipment");

        //RegisterMode 登记方式读取
        public static int RM_RegisterMode = int.Parse(ini.IniReadValue("RegisterMode", "RegisterMode"));              // 0:固定类型(以ExamClass的第一个类型为默认) 1:用户类型(User_Exam_Class) 2:全部类型
        public static string RM_ExamClass = ini.IniReadValue("RegisterMode", "ExamClass");                            // 可登记的检查类别
        public static bool RM_HisApply = bool.Parse(ini.IniReadValue("RegisterMode", "HisApply"));                    // 查询HIS申请
        public static string RM_PatientIdHeader = ini.IniReadValue("RegisterMode", "PatientIdHeader");		          // 无ID登记自动生成的ID头
        //public static bool RM_StatAll = bool.Parse(ini.IniReadValue("RegisterMode", "StatAll"));		              // 是否统计所有科室
        public static string RM_DefaultExamClass = ini.IniReadValue("RegisterMode", "DefaultExamClass");              // 默认检查类别
        public static string RM_DefaultExamSubClass = ini.IniReadValue("RegisterMode", "DefaultExamSubClass");	      // 默认检查子类
        //public static int RM_ExamVsCharge = int.Parse(ini.IniReadValue("RegisterMode", "ExamVsCharge"));		      // 诊疗项目与价表对照取自 0:PACS;1:HIS
        public static bool RM_OPDIsConfirmed = bool.Parse(ini.IniReadValue("RegisterMode", "OPDIsConfirmed"));		  // 住院登记是否自动检查确认 false:否;true:是
        public static bool RM_INPIsConfirmed = bool.Parse(ini.IniReadValue("RegisterMode", "INPIsConfirmed"));		  // 门诊登记是否自动检查确认 false:否;true:是
        //public static bool RM_ShowQueryStatus = bool.Parse(ini.IniReadValue("RegisterMode", "ShowQueryStatus"));      // 显示恢复状态按钮 0:否;1:是         
        public static bool RM_CheckReportStatus = bool.Parse(ini.IniReadValue("RegisterMode", "CheckReportStatus"));  // 验证报告状态 0:否;1:是
        public static bool RM_IsSelectOutpDesc = bool.Parse(ini.IniReadValue("RegisterMode", "IsSelectOutpDesc"));	  // 查询门诊收费资料提取病人信息 false:否;true:是
        // public static bool RM_IsFastRegEmpId = bool.Parse(ini.IniReadValue("RegisterMode", "IsFastRegEmpId"));	      // 是否启动无ID快速登记 false:否;true:是
        // public static string RM_FastRegDep = ini.IniReadValue("RegisterMode", "FastRegDep");			              // 无ID快速登记的申请科室
        public static bool RM_ExamItemSort = bool.Parse(ini.IniReadValue("RegisterMode", "ExamItemSort"));            // 是否启动诊疗项目智能排序 false:否;true:是
        public static int RM_SortDays = int.Parse(ini.IniReadValue("RegisterMode", "SortDays"));                      // 智能排序的统计天数
        public static string RM_CheckField = ini.IniReadValue("RegisterMode", "CheckField");                          // 需验证是否录入的字段
        public static string RM_DefaultSex = ini.IniReadValue("RegisterMode", "DefaultSex");	                      // 默认病人性别
        public static bool RM_SavedOpenRpt = bool.Parse(ini.IniReadValue("RegisterMode", "SavedOpenRpt"));	          // 保存后是否打开报告

        //LocalIdMode 本地ID方式
        //public static int LM_LocalIdClass = int.Parse(ini.IniReadValue("LocalIdMode", "LocalIdClass"));               // 检查号类型;0:1001 1:CT1001 2:CT0000001001
        public static int LM_LocalIdMode = int.Parse(ini.IniReadValue("LocalIdMode", "LocalIdMode"));                 // 检查号模式;0:与病人绑定  1:流水号  2:xxxx（年）+流水号  3:str(Header)+xxxx（年）+流水号  4:str(ExamClass)+xxxx（年）+流水号 
        public static int LM_IsLocalMode = int.Parse(ini.IniReadValue("LocalIdMode", "IsLocalMode"));                 // ;0:网络版(流水号断号)  1:单机版(流水号连续)
        public static int LM_NumberBits = int.Parse(ini.IniReadValue("LocalIdMode", "NumberBits"));                   // 流水号位数
        public static string LM_LocalIdSubClass = ini.IniReadValue("LocalIdMode", "LocalIdSubClass");		          // 检查号对应的检查子类
        public static string LM_LocalIdHeader = ini.IniReadValue("LocalIdMode", "LocalIdHeader");		              // 对应的检查子类的检查号标头
        public static string LM_LocalIdMax = ini.IniReadValue("LocalIdMode", "LocalIdMax");                           // 对应的检查子类的检查号最大值
        public static int LM_LocalIdYear = int.Parse(ini.IniReadValue("LocalIdMode", "LocalIdYear"));	              // 年标头的格式;1:xx（年）2:xxxx（年）
        public static string LM_LocalYear = ini.IniReadValue("LocalIdMode", "LocalYear");		                      // 当前年

        //ImgCardSetting   影像设备设置读取
        public static string IMS_CardProduct = ini.IniReadValue("ImgCardSetting", "CardProduct");	                  // 采集卡厂家
        public static string IMS_CardType = ini.IniReadValue("ImgCardSetting", "CardType").ToUpper();		          // 采集卡型号
        public static string IMS_CardExe = ini.IniReadValue("ImgCardSetting", "CardExe");		                      // 采集卡设置程序
        public static int IMS_Quality = int.Parse(ini.IniReadValue("ImgCardSetting", "Quality"));		              // 采集质量
        public static bool IMS_IsUseRect = bool.Parse(ini.IniReadValue("ImgCardSetting", "IsUseRect"));               // 是否限定采集区域
        public static string[] IMS_Rect = ini.IniReadValue("ImgCardSetting", "Rect").Split(',');                      // 采集区域:Left,Top,Width,Height

        //CommSetting    COMM设置读取
        public static bool COS_IsUse = bool.Parse(ini.IniReadValue("CommSetting", "IsUse"));	                       // 是否使用串口
        public static string COS_CommMode = ini.IniReadValue("CommSetting", "CommMode");		                       // 串口采集方式：0：脚踏；1：按钮
        public static string COS_Port = ini.IniReadValue("CommSetting", "Port");	                                   // 串口端口
        public static int COS_BaudRate = int.Parse(ini.IniReadValue("CommSetting", "BaudRate"));		               // 比特率
        public static int COS_DataBits = int.Parse(ini.IniReadValue("CommSetting", "DataBits"));	                   // 数据位
        public static bool COS_IsPerlinNoise = bool.Parse(ini.IniReadValue("CommSetting", "IsPerlinNoise"));	       // 是否去噪
        public static string COS_ButtonCatch = ini.IniReadValue("CommSetting", "ButtonCatch");	                       // 按钮采集对应的顺序：0 单帧采集；1 动态采集；2 后台单帧； 3 后台动态；

        //CameraSetting     摄像机设置读取
        public static string CS_CameraMode = ini.IniReadValue("CameraSetting", "CameraMode").ToUpper();	              //摄像头捕捉类

        //LockSetting     锁定设置读取
        public static bool LS_AutoLock = bool.Parse(ini.IniReadValue("LockSetting", "AutoLock"));                     //系统自动锁定设置
        public static int LS_LockMinute = int.Parse(ini.IniReadValue("LockSetting", "LockMinute"));

        //[CallSetting]   呼叫设置读取
        public static string CallServIp = ini.IniReadValue("CallSetting", "ServIP");
        public static int CallServPort = int.Parse(ini.IniReadValue("CallSetting", "ServPort"));

        //[ReportSetting]     图文报告设置读取
        public static int RS_ImgWidth = int.Parse(ini.IniReadValue("ReportSetting", "ImgWidth"));                             //Word图片宽度
        public static int RS_ImgHeight = int.Parse(ini.IniReadValue("ReportSetting", "ImgHeight"));                           //Word图片高度
        public static int RS_LocMapWidth = int.Parse(ini.IniReadValue("ReportSetting", "LocMapWidth"));                       //Word定位图宽度
        public static int RS_LocMapHeight = int.Parse(ini.IniReadValue("ReportSetting", "LocMapHeight"));                     //Word定位图高度
        public static bool RS_IsCheckPageHF = bool.Parse(ini.IniReadValue("ReportSetting", "IsCheckPageHF"));                 //Word模板是否取页头或页脚的字段信息
        public static bool RS_PrintClose = bool.Parse(ini.IniReadValue("ReportSetting", "PrintClose"));                       //报告打印后关闭报告编辑界面
        public static string RS_ImgLocation = ini.IniReadValue("ReportSetting", "ImgLocation");                               //报告实时显示图像的窗口位置与大小
        public static string RS_DefPrintTemp = ini.IniReadValue("ReportSetting", "DefPrintTemp");                             //默认打印模板名称
        public static string RS_HistoryRpt = ini.IniReadValue("ReportSetting", "HistoryRpt");                                 //历史报告取自PACS或SIS
        public static bool RS_OpenWord = bool.Parse(ini.IniReadValue("ReportSetting", "OpenWord"));                           //是：默认打开word报告编辑模式；否：默认打开普通编辑模式
        public static string RS_TempExamClass = ini.IniReadValue("ReportSetting", "TempExamClass");                           //加载该检查类别的报告模板
        public static string RS_HistoryRptLocation = ini.IniReadValue("ReportSetting", "HistoryRptLocation");                 //历史报告的窗口位置与大小
        public static int DefaultAbnormal = int.Parse(ini.IniReadValue("ReportSetting", "DefaultABNORMAL"));                  //默认阴阳性
        public static string ReportDateFormat = ini.IniReadValue("ReportSetting", "ReportDateFormat");                        //报告时间日期格式

        //[ListCellColor]     LCC设置读取
        public static string LCC_ChargeType = ini.IniReadValue("ListCellColor", "ChargeType");                                //检查列表的各种收费类别对应的颜色
        public static string LCC_PatientSource = ini.IniReadValue("ListCellColor", "PatientSource");                          //检查列表的各种病人来源对应的颜色

        //[UserGroup]    用户组读取
        public static string UG_DbUser = ini.IniReadValue("UserGroup", "DbUser");                                             //默认登录用户ID
        //public static bool UG_IsCheckKey = bool.Parse(ini.IniReadValue("UserGroup", "IsCheckKey"));                           //是否检验用户密码
        //[DefaultDays]
        public static int DD_DefaultExamListDays = int.Parse(ini.IniReadValue("DefaultDays", "DefaultExamListDays"));         //默认查询天数
        #endregion 读取设置文件

        #region 写入配置文件
        public static void SethisVisit(bool value)
        {
            ini.IniWriteValue("HisConnectionString", "Visit", value.ToString());
        }
        public static void SetIsSendTohis(bool value)
        {
            ini.IniWriteValue("HisConnectionString", "IsSendToHIS", value.ToString());
        }
        public static void SethisType(string value)
        {
            ini.IniWriteValue("HisConnectionString", "DbType", value);
        }
        public static void SethisDatabase(string value)
        {
            ini.IniWriteValue("HisConnectionString", "Database", value);
        }
        public static void SethisUid(string value)
        {
            ini.IniWriteValue("HisConnectionString", "Uid", value);
        }
        public static void SethisPwd(string value)
        {
            ini.IniWriteValue("HisConnectionString", "Pwd", value);
        }
        public static void SethisServer(string value)
        {
            ini.IniWriteValue("HisConnectionString", "Server", value);
        }
        public static void SetDcmServerAE(string value)
        {
            ini.IniWriteValue("PacsConnectionString", "ServerAE", value);
        }
        public static void SetDcmIp(string value)
        {
            ini.IniWriteValue("PacsConnectionString", "DicomIP", value);
        }
        public static void SetDcmPort(int value)
        {
            ini.IniWriteValue("PacsConnectionString", "DicomPort", value.ToString());
        }
        public static void SetLocalAE(string value)
        {
            ini.IniWriteValue("PacsConnectionString", "LocalAE", value);
        }
        public static void SetLocalIp(string value)
        {
            ini.IniWriteValue("PacsConnectionString", "LocalIP", value);
        }
        public static void SetIsConnectPax(bool value)
        {
            ini.IniWriteValue("PacsConnectionString", "IsConnectPax", value.ToString());
        }
        public static void SetSendCheckImage(bool value)
        {
            ini.IniWriteValue("PacsConnectionString", "UPUnCheckPicture", value.ToString());
        }
        public static void SetPacsType(string value)
        {
            ini.IniWriteValue("PacsConnectionString", "DbType", value);
        }
        public static void SetPacsDatabase(string value)
        {
            ini.IniWriteValue("PacsConnectionString", "Database", value);
        }
        public static void SetPacsUid(string value)
        {
            ini.IniWriteValue("PacsConnectionString", "Uid", value);
        }
        public static void SetPacsPwd(string value)
        {
            ini.IniWriteValue("PacsConnectionString", "Pwd", value);
        }
        public static void SetPacsServer(string value)
        {
            ini.IniWriteValue("PacsConnectionString", "Server", value);
        }
        public static void SetExamClass(string value)
        {
            ini.IniWriteValue("SYSTEMSETTING", "EXAM_CLASS", value);
        }
        public static void SetModality(string value)
        {
            ini.IniWriteValue("SYSTEMSETTING", "Modality", value);
        }
        public static void SetIsMutex(string value)
        {
            ini.IniWriteValue("SYSTEMSETTING", "IsMutex", value);
        }
        public static void SetModalityName(string value)
        {
            ini.IniWriteValue("SYSTEMSETTING", "ModalityName", value);
        }
        public static void SetDAL(string value)
        {
            ini.IniWriteValue("SYSTEMSETTING", "DAL", value);
        }
        public static void SetModel(string value)
        {
            ini.IniWriteValue("SYSTEMSETTING", "Model", value);
        }
        public static void SetSisLocal(string value)
        {
            ini.IniWriteValue("SisConnectionString", "Local", value);
        }
        public static void SetSisRegister(string value)
        {
            ini.IniWriteValue("SisConnectionString", "Register", value);
        }
        public static void SetSisType(string value)
        {
            ini.IniWriteValue("SisConnectionString", "DbType", value);
        }
        public static void SetSisServer(string value)
        {
            ini.IniWriteValue("SisConnectionString", "Server", value);
        }
        public static void SetSisUid(string value)
        {
            ini.IniWriteValue("SisConnectionString", "Uid", value);
        }
        public static void SetSisPwd(string value)
        {
            ini.IniWriteValue("SisConnectionString", "Pwd", value);
        }
        public static void SetSisDatabase(string value)
        {
            ini.IniWriteValue("SisConnectionString", "Database", value);
        }
        public static void SetTempPath(string value)
        {
            ini.IniWriteValue("Directory", "TempPath", value);
        }
        public static void SetServerIp(string value)
        {
            ini.IniWriteValue("Directory", "ServerIp", value);
        }
        public static void SetServerPort(int value)
        {
            ini.IniWriteValue("Directory", "ServerPort", value.ToString());
        }
        public static void SetTemplatePath(string value)
        {
            ini.IniWriteValue("Directory", "TemplatePath", value);
        }
        public static void SetDynamic(string value)
        {
            ini.IniWriteValue("Directory", "Dynamic", value);
        }
        public static void SetImageDirectory(string value)
        {
            ini.IniWriteValue("Directory", "ImageDirectory", value);
        }
        public static void SetHospitalName(string value)
        {
            ini.IniWriteValue("HospitalInformation", "HospitalName", value);
        }
        public static void SetImgEquipment(string value)
        {
            ini.IniWriteValue("HospitalInformation", "ImgEquipment", value);
        }
        public static void SetRM_RegisterMode(int value)
        {
            ini.IniWriteValue("RegisterMode", "RegisterMode", value.ToString());
        }
        public static void SetRM_ExamClass(string value)
        {
            ini.IniWriteValue("RegisterMode", "ExamClass", value.ToString());
        }
        public static void SetRM_HisApply(bool value)
        {
            ini.IniWriteValue("RegisterMode", "HisApply", value.ToString());
        }
        public static void SetRM_PatientIdHeader(string value)
        {
            ini.IniWriteValue("RegisterMode", "PatientIdHeader", value);
        }
        public static void SetRM_StatAll(bool value)
        {
            ini.IniWriteValue("RegisterMode", "StatAll", value.ToString());
        }
        public static void SetRM_DefaultExamClass(string value)
        {
            ini.IniWriteValue("RegisterMode", "DefaultExamClass", value);
        }
        public static void SetRM_DefaultExamSubClass(string value)
        {
            ini.IniWriteValue("RegisterMode", "DefaultExamSubClass", value);
        }
        public static void SetRM_ExamVsCharge(int value)
        {
            ini.IniWriteValue("RegisterMode", "ExamVsCharge", value.ToString());
        }
        public static void SetRM_OPDIsConfirmed(bool value)
        {
            ini.IniWriteValue("RegisterMode", "OPDIsConfirmed", value.ToString());
        }
        public static void SetRM_INPIsConfirmed(bool value)
        {
            ini.IniWriteValue("RegisterMode", "INPIsConfirmed", value.ToString());
        }
        public static void SetRM_ShowQueryStatus(bool value)
        {
            ini.IniWriteValue("RegisterMode", "ShowQueryStatus", value.ToString());
        }
        public static void SetRM_CheckReportStatus(bool value)
        {
            ini.IniWriteValue("RegisterMode", "CheckReportStatus", value.ToString());
        }
        public static void SetRM_IsSelectOutpDesc(bool value)
        {
            ini.IniWriteValue("RegisterMode", "IsSelectOutpDesc", value.ToString());
        }
        public static void SetRM_IsFastRegEmpId(bool value)
        {
            ini.IniWriteValue("RegisterMode", "IsFastRegEmpId", value.ToString());
        }
        public static void SetRM_FastRegDep(string value)
        {
            ini.IniWriteValue("RegisterMode", "FastRegDep", value);
        }
        public static void SetRM_ExamItemSort(bool value)
        {
            ini.IniWriteValue("RegisterMode", "ExamItemSort", value.ToString());
        }
        public static void SetRM_SortDays(int value)
        {
            ini.IniWriteValue("RegisterMode", "SortDays", value.ToString());
        }
        public static void SetLM_LocalIdClass(int value)
        {
            ini.IniWriteValue("LocalIdMode", "LocalIdClass", value.ToString());
        }
        public static void SetLM_LocalIdMode(int value)
        {
            ini.IniWriteValue("LocalIdMode", "LocalIdMode", value.ToString());
        }
        public static void SetLM_IsLocalMode(int value)
        {
            ini.IniWriteValue("LocalIdMode", "IsLocalMode", value.ToString());
        }
        public static void SetLM_NumberBits(int value)
        {
            ini.IniWriteValue("LocalIdMode", "NumberBits", value.ToString());
        }
        public static void SetLM_LocalIdSubClass(string value)
        {
            ini.IniWriteValue("LocalIdMode", "LocalIdSubClass", value);
        }
        public static void SetLM_LocalIdHeader(string value)
        {
            ini.IniWriteValue("LocalIdMode", "LocalIdHeader", value);
        }
        public static void SetLM_LocalIdMax(string value)
        {
            ini.IniWriteValue("LocalIdMode", "LocalIdMax", value);
        }
        public static string ReSetLM_LocalIdMax()
        {
            return ini.IniReadValue("LocalIdMode", "LocalIdMax");
        }
        public static void SetLM_LocalIdYear(int value)
        {
            ini.IniWriteValue("LocalIdMode", "LocalIdYear", value.ToString());
        }
        public static void SetLM_LocalYear(string value)
        {
            ini.IniWriteValue("LocalIdMode", "LocalYear", value);
        }

        public static void SetLS_AutoLock(bool value)
        {
            ini.IniWriteValue("LockSetting", "AutoLock", value.ToString());
        }
        public static void SetLS_LockMinute(int value)
        {
            ini.IniWriteValue("LockSetting", "LockMinute", value.ToString());
        }
        public static void SetUG_DbUser(string value)
        {
            ini.IniWriteValue("UserGroup", "DbUser", value);
        }
        public static void SetUG_IsCheckKey(bool value)
        {
            ini.IniWriteValue("UserGroup", "IsCheckKey", value.ToString());
        }
        public static void SetRS_ImgLocation(string value)
        {
            ini.IniWriteValue("ReportSetting", "ImgLocation", value.ToString());
        }

        public static void SetRS_DefPrintTemp(string value)
        {
            ini.IniWriteValue("ReportSetting", "DefPrintTemp", value.ToString());
        }

        public static void SetRS_HistoryRptLocation(string value)
        {
            ini.IniWriteValue("ReportSetting", "HistoryRptLocation", value.ToString());
        }
        #endregion 写入配置文件
    }
}
