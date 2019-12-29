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
    /// ��дϵͳ�����ļ�
    /// </summary>
    public sealed class GetConfig
    {
        public static ApiIni ini = new ApiIni(Application.StartupPath + @"\Settings.ini");    //��������Ŀ¼�е�Setting.ini�ļ�
        public static Phoneticize phone = new Phoneticize(Application.StartupPath + @"\PHONEA.txt");    //��������Ŀ¼�е�PHONEA.txt�ļ�
        private static ConParam cp = new ConParam();

        /// <summary>
        /// ���캯��
        /// </summary>
        public GetConfig()
        {
        }

        //ʵ����SIS���ݿ������ַ������ֶ�
        public static ConParam GetSisConnStr()
        {
            cp.DBType = SisType;
            cp.Server = SisServer;
            cp.Uid = SisUid;
            cp.Pwd = SisPwd;
            cp.Database = SisDatabase;
            return cp;
        }

        //ʵ����HIS���ݿ������ַ������ֶ�
        public static ConParam GetHisConnStr()
        {
            cp.DBType = hisType;
            cp.Server = hisServer;
            cp.Uid = hisUid;
            cp.Pwd = hisPwd;
            cp.Database = hisDatabase;
            return cp;
        }

        //ʵ����PACS���ݿ������ַ������ֶ�
        public static ConParam GetPacsConnStr()
        {
            cp.DBType = PacsType;
            cp.Server = PacsServer;
            cp.Uid = PacsUid;
            cp.Pwd = PacsPwd;
            cp.Database = PacsDatabase;
            return cp;
        }
        //ʵ����LIS���ݿ������ַ������ֶ�
        public static ConParam GetLisConnStr()
        {
            return null;
        }

        #region ��ȡ�����ļ�
        //HisConnectoinSetting HIS�������ֶζ�ȡ
        public static bool hisVisit = bool.Parse(ini.IniReadValue("HisConnectionString", "Visit"));			// �Ƿ�����HIS
        public static bool IsSendTohis = bool.Parse(ini.IniReadValue("HisConnectionString", "IsSendToHIS"));	    //�Ƿ��ͱ��浽HIS
        private static string hisType = ini.IniReadValue("HisConnectionString", "DbType");		// ����HIS����
        private static string hisDatabase = ini.IniReadValue("HisConnectionString", "Database");		// ���ݿ�HIS����
        private static string hisUid = ini.IniReadValue("HisConnectionString", "Uid");			// HIS�û���
        private static string hisPwd = ini.IniReadValue("HisConnectionString", "Pwd");			// HIS���ݿ�����
        private static string hisServer = ini.IniReadValue("HisConnectionString", "Server");    //
        public static string hisVender = ini.IniReadValue("HisConnectionString", "Vender");    //����
        private static string hisDriver = ini.IniReadValue("HisConnectionString", "Driver");


        //PacsConnectionSettion PACS�������ֶζ�ȡ
        public static string DcmServerAE = ini.IniReadValue("PacsConnectionString", "ServerAE");
        public static string DcmIp = ini.IniReadValue("PacsConnectionString", "DicomIP");
        public static int DcmPort = int.Parse(ini.IniReadValue("PacsConnectionString", "DicomPort"));
        public static string LocalAE = ini.IniReadValue("PacsConnectionString", "LocalAE");
        public static string LocalIp = ini.IniReadValue("PacsConnectionString", "LocalIP");		// ����HIS����
        public static bool IsConnectPax = bool.Parse(ini.IniReadValue("PacsConnectionString", "IsConnectPax"));		// ���ݿ�HIS����
        public static bool SendCheckImage = bool.Parse(ini.IniReadValue("PacsConnectionString", "UPUnCheckPicture"));//ֻ���ʹ򹴵�ͼ��
        public static string PacsType = ini.IniReadValue("PacsConnectionString", "DbType");		// ����HIS����
        public static string PacsDatabase = ini.IniReadValue("PacsConnectionString", "Database");		// ���ݿ�HIS����
        public static string PacsUid = ini.IniReadValue("PacsConnectionString", "Uid");			// HIS�û���
        public static string PacsPwd = ini.IniReadValue("PacsConnectionString", "Pwd");			// HIS���ݿ�����
        public static string PacsServer = ini.IniReadValue("PacsConnectionString", "Server");    //
        public static string PacsDriver = ini.IniReadValue("PacsConnectionString", "Driver");

        //systemsetting ϵͳ���ö�ȡ
        public static string ExamClass = ini.IniReadValue("SYSTEMSETTING", "EXAM_CLASS");
        public static string Modality = ini.IniReadValue("SYSTEMSETTING", "Modality");
        //public static string IsMutex = ini.IniReadValue("SYSTEMSETTING", "isMutex");
        public static string ModalityName = ini.IniReadValue("SYSTEMSETTING", "ModalityName");
        public static string DALAndModel = ini.IniReadValue("SYSTEMSETTING", "DALAndModel").ToUpper();                            //DAL��Model�������ռ�
        public static string Group = ini.IniReadValue("SYSTEMSETTING", "Group");
        //public static string Model = ini.IniReadValue("SYSTEMSETTING", "");                                               //�������ռ�
        public static string ExamDeptCode = ini.IniReadValue("SYSTEMSETTING", "ExamDeptCode");                              //ϵͳ�����Ҵ���
        public static string ExamDeptName = ini.IniReadValue("SYSTEMSETTING", "ExamDeptName");                              //ϵͳ����������
        public static string SystemType = ini.IniReadValue("SYSTEMSETTING", "SystemType");                                  //����ƿ��ҹ���
        //public static string IsSelectCharge = ini.IniReadValue("SYSTEMSETTING", "IsSelectCharge");                           //�Ƿ�ѡ���շ�
        public static string IsSelectDB = ini.IniReadValue("SYSTEMSETTING", "IsSelectDB");                                 //�Ƿ�����ݿ���ѡ��
        public static string DefaltDeptName = ini.IniReadValue("SYSTEMSETTING", "ExamDeptName");                               //Ĭ�ϼ�������
        //public static string PatientSource = ini.IniReadValue("SYSTEMSETTING", "PatientSource");                           //������Դ
        public static bool IsAddLocMap = bool.Parse(ini.IniReadValue("SYSTEMSETTING", "IsAddLocMap"));                     //�Ƿ���ض�λͼ
        public static bool IsQuickReg = bool.Parse(ini.IniReadValue("SYSTEMSETTING", "IsQuickReg"));                       //�Ƿ���ؿ��ٵǼ�
        public static bool QueryGroup = bool.Parse(ini.IniReadValue("SYSTEMSETTING", "QueryGroup"));                       //���ٲ�ѯ�Ƿ�Ĭ�ϲ�ѯ��ǰ����
        public static string ChargeItemClass = ini.IniReadValue("SYSTEMSETTING", "ChargeItemClass");                       //�ÿ��Ҷ�Ӧ�ļ۱���Ŀ����

        // public static string ExamSubClass = ini.IniReadValue("SYSTEMSETTING", "EXAM_SUB_CLASS");
        // public static string PatientSourceCode = ini.IniReadValue("SYSTEMSETTING", "PatientSourceCode");

        //SisConnectionString SIS���������ֶζ�ȡ
        public static string SisOdbcMode = ini.IniReadValue("SisConnectionString", "OdbcMode");
        // public static string SisRegister = ini.IniReadValue("SisConnectionString", "Register");                       //;0:���صǼ� 1:HIS�Ǽ� 2:PACS�Ǽ�
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
        public static string ServerImgDir = ini.IniReadValue("Directory", "ServerImgDir");//�������ļ�Ŀ¼
        //public static string TemplatePath = ini.IniReadValue("Directory", "TemplatePath");
        public static string Dynamic = ini.IniReadValue("Directory", "Dynamic");
        //public static string ImageDirectory = ini.IniReadValue("Directory", "ImageDirectory");
        //public static string BackPath = ini.IniReadValue("Directory", "BackPath");
        public static string HospitalName = ini.IniReadValue("HospitalInformation", "HospitalName");
        public static string ImgEquipment = ini.IniReadValue("HospitalInformation", "ImgEquipment");

        //RegisterMode �ǼǷ�ʽ��ȡ
        public static int RM_RegisterMode = int.Parse(ini.IniReadValue("RegisterMode", "RegisterMode"));              // 0:�̶�����(��ExamClass�ĵ�һ������ΪĬ��) 1:�û�����(User_Exam_Class) 2:ȫ������
        public static string RM_ExamClass = ini.IniReadValue("RegisterMode", "ExamClass");                            // �ɵǼǵļ�����
        public static bool RM_HisApply = bool.Parse(ini.IniReadValue("RegisterMode", "HisApply"));                    // ��ѯHIS����
        public static string RM_PatientIdHeader = ini.IniReadValue("RegisterMode", "PatientIdHeader");		          // ��ID�Ǽ��Զ����ɵ�IDͷ
        //public static bool RM_StatAll = bool.Parse(ini.IniReadValue("RegisterMode", "StatAll"));		              // �Ƿ�ͳ�����п���
        public static string RM_DefaultExamClass = ini.IniReadValue("RegisterMode", "DefaultExamClass");              // Ĭ�ϼ�����
        public static string RM_DefaultExamSubClass = ini.IniReadValue("RegisterMode", "DefaultExamSubClass");	      // Ĭ�ϼ������
        //public static int RM_ExamVsCharge = int.Parse(ini.IniReadValue("RegisterMode", "ExamVsCharge"));		      // ������Ŀ��۱����ȡ�� 0:PACS;1:HIS
        public static bool RM_OPDIsConfirmed = bool.Parse(ini.IniReadValue("RegisterMode", "OPDIsConfirmed"));		  // סԺ�Ǽ��Ƿ��Զ����ȷ�� false:��;true:��
        public static bool RM_INPIsConfirmed = bool.Parse(ini.IniReadValue("RegisterMode", "INPIsConfirmed"));		  // ����Ǽ��Ƿ��Զ����ȷ�� false:��;true:��
        //public static bool RM_ShowQueryStatus = bool.Parse(ini.IniReadValue("RegisterMode", "ShowQueryStatus"));      // ��ʾ�ָ�״̬��ť 0:��;1:��         
        public static bool RM_CheckReportStatus = bool.Parse(ini.IniReadValue("RegisterMode", "CheckReportStatus"));  // ��֤����״̬ 0:��;1:��
        public static bool RM_IsSelectOutpDesc = bool.Parse(ini.IniReadValue("RegisterMode", "IsSelectOutpDesc"));	  // ��ѯ�����շ�������ȡ������Ϣ false:��;true:��
        // public static bool RM_IsFastRegEmpId = bool.Parse(ini.IniReadValue("RegisterMode", "IsFastRegEmpId"));	      // �Ƿ�������ID���ٵǼ� false:��;true:��
        // public static string RM_FastRegDep = ini.IniReadValue("RegisterMode", "FastRegDep");			              // ��ID���ٵǼǵ��������
        public static bool RM_ExamItemSort = bool.Parse(ini.IniReadValue("RegisterMode", "ExamItemSort"));            // �Ƿ�����������Ŀ�������� false:��;true:��
        public static int RM_SortDays = int.Parse(ini.IniReadValue("RegisterMode", "SortDays"));                      // ���������ͳ������
        public static string RM_CheckField = ini.IniReadValue("RegisterMode", "CheckField");                          // ����֤�Ƿ�¼����ֶ�
        public static string RM_DefaultSex = ini.IniReadValue("RegisterMode", "DefaultSex");	                      // Ĭ�ϲ����Ա�
        public static bool RM_SavedOpenRpt = bool.Parse(ini.IniReadValue("RegisterMode", "SavedOpenRpt"));	          // ������Ƿ�򿪱���

        //LocalIdMode ����ID��ʽ
        //public static int LM_LocalIdClass = int.Parse(ini.IniReadValue("LocalIdMode", "LocalIdClass"));               // ��������;0:1001 1:CT1001 2:CT0000001001
        public static int LM_LocalIdMode = int.Parse(ini.IniReadValue("LocalIdMode", "LocalIdMode"));                 // ����ģʽ;0:�벡�˰�  1:��ˮ��  2:xxxx���꣩+��ˮ��  3:str(Header)+xxxx���꣩+��ˮ��  4:str(ExamClass)+xxxx���꣩+��ˮ�� 
        public static int LM_IsLocalMode = int.Parse(ini.IniReadValue("LocalIdMode", "IsLocalMode"));                 // ;0:�����(��ˮ�ŶϺ�)  1:������(��ˮ������)
        public static int LM_NumberBits = int.Parse(ini.IniReadValue("LocalIdMode", "NumberBits"));                   // ��ˮ��λ��
        public static string LM_LocalIdSubClass = ini.IniReadValue("LocalIdMode", "LocalIdSubClass");		          // ���Ŷ�Ӧ�ļ������
        public static string LM_LocalIdHeader = ini.IniReadValue("LocalIdMode", "LocalIdHeader");		              // ��Ӧ�ļ������ļ��ű�ͷ
        public static string LM_LocalIdMax = ini.IniReadValue("LocalIdMode", "LocalIdMax");                           // ��Ӧ�ļ������ļ������ֵ
        public static int LM_LocalIdYear = int.Parse(ini.IniReadValue("LocalIdMode", "LocalIdYear"));	              // ���ͷ�ĸ�ʽ;1:xx���꣩2:xxxx���꣩
        public static string LM_LocalYear = ini.IniReadValue("LocalIdMode", "LocalYear");		                      // ��ǰ��

        //ImgCardSetting   Ӱ���豸���ö�ȡ
        public static string IMS_CardProduct = ini.IniReadValue("ImgCardSetting", "CardProduct");	                  // �ɼ�������
        public static string IMS_CardType = ini.IniReadValue("ImgCardSetting", "CardType").ToUpper();		          // �ɼ����ͺ�
        public static string IMS_CardExe = ini.IniReadValue("ImgCardSetting", "CardExe");		                      // �ɼ������ó���
        public static int IMS_Quality = int.Parse(ini.IniReadValue("ImgCardSetting", "Quality"));		              // �ɼ�����
        public static bool IMS_IsUseRect = bool.Parse(ini.IniReadValue("ImgCardSetting", "IsUseRect"));               // �Ƿ��޶��ɼ�����
        public static string[] IMS_Rect = ini.IniReadValue("ImgCardSetting", "Rect").Split(',');                      // �ɼ�����:Left,Top,Width,Height

        //CommSetting    COMM���ö�ȡ
        public static bool COS_IsUse = bool.Parse(ini.IniReadValue("CommSetting", "IsUse"));	                       // �Ƿ�ʹ�ô���
        public static string COS_CommMode = ini.IniReadValue("CommSetting", "CommMode");		                       // ���ڲɼ���ʽ��0����̤��1����ť
        public static string COS_Port = ini.IniReadValue("CommSetting", "Port");	                                   // ���ڶ˿�
        public static int COS_BaudRate = int.Parse(ini.IniReadValue("CommSetting", "BaudRate"));		               // ������
        public static int COS_DataBits = int.Parse(ini.IniReadValue("CommSetting", "DataBits"));	                   // ����λ
        public static bool COS_IsPerlinNoise = bool.Parse(ini.IniReadValue("CommSetting", "IsPerlinNoise"));	       // �Ƿ�ȥ��
        public static string COS_ButtonCatch = ini.IniReadValue("CommSetting", "ButtonCatch");	                       // ��ť�ɼ���Ӧ��˳��0 ��֡�ɼ���1 ��̬�ɼ���2 ��̨��֡�� 3 ��̨��̬��

        //CameraSetting     ��������ö�ȡ
        public static string CS_CameraMode = ini.IniReadValue("CameraSetting", "CameraMode").ToUpper();	              //����ͷ��׽��

        //LockSetting     �������ö�ȡ
        public static bool LS_AutoLock = bool.Parse(ini.IniReadValue("LockSetting", "AutoLock"));                     //ϵͳ�Զ���������
        public static int LS_LockMinute = int.Parse(ini.IniReadValue("LockSetting", "LockMinute"));

        //[CallSetting]   �������ö�ȡ
        public static string CallServIp = ini.IniReadValue("CallSetting", "ServIP");
        public static int CallServPort = int.Parse(ini.IniReadValue("CallSetting", "ServPort"));

        //[ReportSetting]     ͼ�ı������ö�ȡ
        public static int RS_ImgWidth = int.Parse(ini.IniReadValue("ReportSetting", "ImgWidth"));                             //WordͼƬ���
        public static int RS_ImgHeight = int.Parse(ini.IniReadValue("ReportSetting", "ImgHeight"));                           //WordͼƬ�߶�
        public static int RS_LocMapWidth = int.Parse(ini.IniReadValue("ReportSetting", "LocMapWidth"));                       //Word��λͼ���
        public static int RS_LocMapHeight = int.Parse(ini.IniReadValue("ReportSetting", "LocMapHeight"));                     //Word��λͼ�߶�
        public static bool RS_IsCheckPageHF = bool.Parse(ini.IniReadValue("ReportSetting", "IsCheckPageHF"));                 //Wordģ���Ƿ�ȡҳͷ��ҳ�ŵ��ֶ���Ϣ
        public static bool RS_PrintClose = bool.Parse(ini.IniReadValue("ReportSetting", "PrintClose"));                       //�����ӡ��رձ���༭����
        public static string RS_ImgLocation = ini.IniReadValue("ReportSetting", "ImgLocation");                               //����ʵʱ��ʾͼ��Ĵ���λ�����С
        public static string RS_DefPrintTemp = ini.IniReadValue("ReportSetting", "DefPrintTemp");                             //Ĭ�ϴ�ӡģ������
        public static string RS_HistoryRpt = ini.IniReadValue("ReportSetting", "HistoryRpt");                                 //��ʷ����ȡ��PACS��SIS
        public static bool RS_OpenWord = bool.Parse(ini.IniReadValue("ReportSetting", "OpenWord"));                           //�ǣ�Ĭ�ϴ�word����༭ģʽ����Ĭ�ϴ���ͨ�༭ģʽ
        public static string RS_TempExamClass = ini.IniReadValue("ReportSetting", "TempExamClass");                           //���ظü�����ı���ģ��
        public static string RS_HistoryRptLocation = ini.IniReadValue("ReportSetting", "HistoryRptLocation");                 //��ʷ����Ĵ���λ�����С
        public static int DefaultAbnormal = int.Parse(ini.IniReadValue("ReportSetting", "DefaultABNORMAL"));                  //Ĭ��������
        public static string ReportDateFormat = ini.IniReadValue("ReportSetting", "ReportDateFormat");                        //����ʱ�����ڸ�ʽ

        //[ListCellColor]     LCC���ö�ȡ
        public static string LCC_ChargeType = ini.IniReadValue("ListCellColor", "ChargeType");                                //����б�ĸ����շ�����Ӧ����ɫ
        public static string LCC_PatientSource = ini.IniReadValue("ListCellColor", "PatientSource");                          //����б�ĸ��ֲ�����Դ��Ӧ����ɫ

        //[UserGroup]    �û����ȡ
        public static string UG_DbUser = ini.IniReadValue("UserGroup", "DbUser");                                             //Ĭ�ϵ�¼�û�ID
        //public static bool UG_IsCheckKey = bool.Parse(ini.IniReadValue("UserGroup", "IsCheckKey"));                           //�Ƿ�����û�����
        //[DefaultDays]
        public static int DD_DefaultExamListDays = int.Parse(ini.IniReadValue("DefaultDays", "DefaultExamListDays"));         //Ĭ�ϲ�ѯ����
        #endregion ��ȡ�����ļ�

        #region д�������ļ�
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
        #endregion д�������ļ�
    }
}
