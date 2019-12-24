using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SIS_Model;
using ILL;

namespace SIS
{
    public struct sReturnInfItem
    {
        public int m_nReturnCode;
        public int m_nImgIndex;
    }
    public class DcmInterface
    {
        #region 接口定义1
        /// <summary>
        /// 将指定路径的DCM文件传送到提供CStore服务的SCP DICOM节点
        /// </summary>
        /// <param name="strStoreFileList">待传递的DCM文件列表,单个文件之间以";"隔开</param>
        /// <param name="strRemoteAE">SCP AE title</param>
        /// <param name="strRemoteIp">远程SCP IP地址</param>
        /// <param name="nRemotePort">SCP侦听端口</param>
        /// <param name="strLocalAE">本地AE</param>
        /// <param name="strLocalIP">本地IP</param>
        /// <param name="bBlockSock">是否阻塞模式,建议采用阻塞模式</param>
        /// <param name="nTimeOut">非阻塞模式下的超时设定</param>
        /// <param name="m_bHaltOnUnsuccStore">遇到失败的归档是否跳出,TRUE则出现归档失败时即跳出,FALSE则跳过问题文件,继续下一个</param>
        /// <param name="m_bShowStatusMsg">是否出现提示信息</param>
        /// <param name="m_bAbortAssociation">是否在传输完成时,主动中断连接</param>
        /// <param name="nTransferSyntaxUID">0:DCM默认语法EXS_LittleEndianImplicit,建议使用本语法;1:JPEGProcess14SV1TransferSyntax;2:JPEGProcess1TransferSyntax;</param>
        /// <param name="pCallback">回调函数,详见以下介绍,可以为NULL</param>
        /// <param name="callbackData">回调函数指针型参数,可以为空,用户自己定义</param>
        /// <returns>返回:
        ///         1>	[sReturnInfItem].m_nReturnCode=1,	传送成功;
        ///             [sReturnInfItem].m_nImgIndex,    	传送成功的文件数量;
        ///
        ///         2>	[sReturnInfItem].m_nReturnCode=0,	被用户在回调中中止;
        ///             [sReturnInfItem].m_nImgIndex,    	中止的原因(即小于0的各种m_nReturnCode);
        ///
        ///         3>	[sReturnInfItem].m_nReturnCode=-8,	没有可供存储的文件;
        ///             [sReturnInfItem].m_nImgIndex,    	无意义;
        ///
        ///         4>	[sReturnInfItem].m_nReturnCode=-7,	某一存储文件不存在;
        ///             [sReturnInfItem].m_nImgIndex,    	不存在的文件序号;
        ///
        ///         5>	[sReturnInfItem].m_nReturnCode=-6,	初始化错误;
        ///             [sReturnInfItem].m_nImgIndex,    	1:Content:Initialize Network Bad;
        ///                                                 2:Content:Create Association Parameters Bad;
        ///                                                 3:Content:Set Transport Layer Type Bad;
        ///                                                 4:Content:Add Storage Presentation Contexts Bad
        ///
        ///         6>	[sReturnInfItem].m_nReturnCode=-5,	连接协议过程错误;
        ///             [sReturnInfItem].m_nImgIndex,    	1:Content:Association Rejected;
        ///                                                 2:Content:Association Request Failed;
        ///                                                 3:Content:No Acceptable Presentation Contexts;
        ///                                                 4:Content:Association Abort Failed;
        ///                                                 5:Content:Association Release Failed;
        ///                                                 6:Content:Destroy Association Failed;
        ///
        ///         7>	[sReturnInfItem].m_nReturnCode=-4,	初始化错误;
        ///             [sReturnInfItem].m_nImgIndex,    	1:Content:Drop Network Bad;
        ///</returns>
        [DllImport("FPaxDCMInterface.dll")]
        public static extern sReturnInfItem FpaxStoreDCMSToOneSCP(string strStoreFileList,
                                                                    string strRemoteAE,
                                                                    string strRemoteIp,
                                                                    int nRemotePort,
                                                                    string strLocalAE,
                                                                    string strLocalIP,
                                                                    bool bBlockSock,
                                                                    int nTimeOut,
                                                                    bool m_bHaltOnUnsuccStore,
                                                                    bool m_bShowStatusMsg,
                                                                    bool m_bAbortAssociation,
                                                                    int nTransferSyntaxUID,
                                                                    FPax_StoreUserCallback pCallback,
                                                                    IntPtr callbackData
                                                                   );
        #endregion 接口定义1

        #region 接口定义2
        /// <summary>
        /// 将指定路径的图像文件(如jpg/bmp/tiff/png等转化为指定名称的DICOM图像
        /// </summary>
        /// <param name="strExamAccessionNum">Worklist申请得到</param>
        /// <param name="strStudyUID">检查记录的STUDY_INSTANCE_UID,生成规则已定</param>
        /// <param name="strPatientID">病人ID号</param>
        /// <param name="strPatientLocalID">病人检查号,对应WORKLIST表Patient_Local_ID,对应Study表Study_Id</param>
        /// <param name="strPatientName">病人姓名</param>
        /// <param name="strPatientSex">病人性别,限定"男/女/其他"</param>
        /// <param name="nPatientAge">病人年龄数字</param>
        /// <param name="strPatientAgeUnit">病人的年龄单位,限定"岁/月/天/周"</param>
        /// <param name="nSeriesNum">序列号,本接口仅适用于单个序列DCM文件的转化</param>
        /// <param name="nInstanceNum">开始的图像序号</param>
        /// <param name="strStudyDate">格式为:%.4d%.2d%.2d,例2002年11月5日为20021105</param>
        /// <param name="strStudyTime">格式为:%.2d%.2d%.2d.0,例11点5分17秒为110517.0</param>
        /// <param name="strInputFileList">输入文件路径,单个文件以";"分开</param>
        /// <param name="strOutputFileList">输出文件串(不含路径信息),单个文件以";"分开</param>
        /// <param name="strOutputFilePath">输出文件的保存路径,注意最后以"\"结尾</param>
        /// <param name="strModality">形成DCM文件的Modality,超声US/内镜ES/病理PS</param>
        /// <param name="strManufacturer">生成该文件的厂商信息,可以使用"E-Charm"</param>
        /// <param name="strAppVersionName"></param>
        /// <param name="nTransferSyntaxUID">传输语法0:DCM默认语法EXS_LittleEndianImplicit,建议使用本语法;1:JPEGProcess14SV1TransferSyntax;2:JPEGProcess1TransferSyntax;</param>
        /// <param name="bHaltOnEncounteredUnsucc">遭遇失败是否退出</param>
        /// <returns>
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// </returns>
        [DllImport("FPaxDCMInterface.dll")]
        public static extern sReturnInfItem FpaxConvertImagesToDCM(string strExamAccessionNum,
                                                                    string strStudyUID,
                                                                    string strPatientID,
                                                                    string strPatientLocalID,
                                                                    string strPatientName,
                                                                    string strPatientSex,
                                                                    int nPatientAge,
                                                                    string strPatientAgeUnit,
                                                                    int nSeriesNum,
                                                                    int nInstanceNum,
                                                                    string strStudyDate,//日期格式为ToString("yyyyMMdd")
                                                                    string strStudyTime,//时间格式为：ToString("hhmmss.0")
                                                                    string strInputFileList,//
                                                                    string strOutputFileList,//
                                                                    string strOutputFilePath,
                                                                    string strModality,
                                                                    string strManufacturer,
                                                                    string strAppVersionName,
                                                                    int nTransferSyntaxUID,//0,DCM默认语法;1:
                                                                    bool bHaltOnEncounteredUnsucc//遇到失败,是否退出
                                                                );//目前仅适用于RGB图像
        #endregion 接口定义2

        #region 回调函数声明
        /// <summary>
        /// 在存储过程中的回调函数
        /// </summary>
        /// <param name="callbackData"></param>
        /// <param name="nEventCode"></param>
        /// <param name="nFileName"></param>
        /// <param name="nFileIndex"></param>
        /// <param name="pHaltOn"></param>
        public delegate byte FPax_StoreUserCallback(IntPtr callbackData, int nEventCode, string nFileName, int nFileIndex);
        #endregion 回调函数声明

        private sReturnInfItem m_sReturnItem;
        private FPax_StoreUserCallback m_pCallBack;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paths">path1;path2;path3</param>
        /// <param name="dcm"></param>
        /// <returns></returns>
        public bool JPGToDCM(DcmStudy dcm)
        {
            //string SaveDcmDic = Application.StartupPath + "\\DCM\\";
            //string outFiles = "";
            //for (int i = 0; i < paths.Split(';').Length; i++)
            //{
            //    outFiles += i.ToString() + ".dcm;";
            //}
            //outFiles.TrimEnd(';');
          sReturnInfItem result=  FpaxConvertImagesToDCM(dcm.strExamAccessionNum,
                                                                    dcm.strStudyUID,
                                                                    dcm.strPatientID,
                                                                    dcm.strPatientLocalID,
                                                                    dcm.strPatientName,
                                                                    dcm.strPatientSex,
                                                                    dcm.nPatientAge,
                                                                    dcm.strPatientAgeUnit,
                                                                    dcm.nSeriesNum,
                                                                    dcm.nInstanceNum,
                                                                    dcm.strStudyDate,//
                                                                    dcm.strStudyTime,//
                                                                    dcm.strInputFileList,//
                                                                    dcm.strOutputFileList,//
                                                                    dcm.strOutputFilePath,
                                                                    dcm.strModality,
                                                                    dcm.strManufacturer,
                                                                    dcm.strAppVersionName,
                                                                    dcm.nTransferSyntaxUID,//0,DCM默认语法;1:
                                                                    dcm.bHaltOnEncounteredUnsucc//遇到失败,是否退出
                                                                );//目前仅适用于RGB图像
            //FpaxConvertImagesToDCM(dt.Rows[0]["Exam_accession_num"].ToString(), dt.Rows[0]["study_instance_uid"].ToString(),
            //                        dt.Rows[0]["patient_id"].ToString(),dt.Rows[0]["study_id"].ToString(),
            //                        dt.Rows[0]["patient_name"].ToString(), dt.Rows[0]["patient_sex"].ToString(),
            //                        int.Parse(dt.Rows[0]["patient_age"].ToString()), dt.Rows[0]["patient_age_unit"].ToString(),
            //                        1, 0,
            //                        Convert.ToDateTime(dt.Rows[0]["study_date_time"].ToString()).ToString("yyyyMMdd"),Convert.ToDateTime(dt.Rows[0]["study_date_time"].ToString()).ToString("hhmmss.0"),
            //                        paths, outFiles, SaveDcmDic,
            //                    GetConfig.Modality, "EC",
            //                        "E-Charm", 0, false);
            //string DcmPath = SaveDcmDic + outFiles.TrimEnd(';').Replace(".dcm;", ".dcm;" + SaveDcmDic) + ";";
            //DcmPath = SaveDcmDic + "4.dcm";
            IntPtr pInt = (IntPtr)0;
            string DcmPaths = dcm.strOutputFilePath + dcm.strOutputFileList.TrimEnd(';').Replace(".dcm;", ".dcm;" + dcm.strOutputFilePath) + ";";
            m_sReturnItem = FpaxStoreDCMSToOneSCP(DcmPaths, GetConfig.DcmServerAE, GetConfig.DcmIp, GetConfig.DcmPort, GetConfig.LocalAE, GetConfig.LocalIp, true, 20, false, false, false, 0, m_pCallBack, pInt);
            if (m_sReturnItem.m_nReturnCode != 1)
            {
                MessageBoxEx.Show("传送图片到PACS失败！请检查网络连接", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (dcm.strInputFileList.Split(';').Length > m_sReturnItem.m_nImgIndex)
                {
                    int failCount = dcm.strInputFileList.Split(';').Length - m_sReturnItem.m_nImgIndex;
                    MessageBoxEx.Show(failCount.ToString() + "个图象传送到PACS失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return true;
        }
    }
    public struct DcmStudy
    {
        public string strExamAccessionNum;
        public string strStudyUID;
        public string strPatientID;
        public string strPatientLocalID;
        public string strPatientName;
        public string strPatientSex;
        public int nPatientAge;
        public string strPatientAgeUnit;
        public int nSeriesNum;
        public int nInstanceNum;
        public string strStudyDate;//
        public string strStudyTime;//
        public string strInputFileList;//
        public string strOutputFileList;//
        public string strOutputFilePath;
        public string strModality;
        public string strManufacturer;
        public string strAppVersionName;
        public int nTransferSyntaxUID;//0,DCM默认语法;1:
        public bool bHaltOnEncounteredUnsucc;//遇到失败,是否退出
    }
}
