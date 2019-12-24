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
        #region �ӿڶ���1
        /// <summary>
        /// ��ָ��·����DCM�ļ����͵��ṩCStore�����SCP DICOM�ڵ�
        /// </summary>
        /// <param name="strStoreFileList">�����ݵ�DCM�ļ��б�,�����ļ�֮����";"����</param>
        /// <param name="strRemoteAE">SCP AE title</param>
        /// <param name="strRemoteIp">Զ��SCP IP��ַ</param>
        /// <param name="nRemotePort">SCP�����˿�</param>
        /// <param name="strLocalAE">����AE</param>
        /// <param name="strLocalIP">����IP</param>
        /// <param name="bBlockSock">�Ƿ�����ģʽ,�����������ģʽ</param>
        /// <param name="nTimeOut">������ģʽ�µĳ�ʱ�趨</param>
        /// <param name="m_bHaltOnUnsuccStore">����ʧ�ܵĹ鵵�Ƿ�����,TRUE����ֹ鵵ʧ��ʱ������,FALSE�����������ļ�,������һ��</param>
        /// <param name="m_bShowStatusMsg">�Ƿ������ʾ��Ϣ</param>
        /// <param name="m_bAbortAssociation">�Ƿ��ڴ������ʱ,�����ж�����</param>
        /// <param name="nTransferSyntaxUID">0:DCMĬ���﷨EXS_LittleEndianImplicit,����ʹ�ñ��﷨;1:JPEGProcess14SV1TransferSyntax;2:JPEGProcess1TransferSyntax;</param>
        /// <param name="pCallback">�ص�����,������½���,����ΪNULL</param>
        /// <param name="callbackData">�ص�����ָ���Ͳ���,����Ϊ��,�û��Լ�����</param>
        /// <returns>����:
        ///         1>	[sReturnInfItem].m_nReturnCode=1,	���ͳɹ�;
        ///             [sReturnInfItem].m_nImgIndex,    	���ͳɹ����ļ�����;
        ///
        ///         2>	[sReturnInfItem].m_nReturnCode=0,	���û��ڻص�����ֹ;
        ///             [sReturnInfItem].m_nImgIndex,    	��ֹ��ԭ��(��С��0�ĸ���m_nReturnCode);
        ///
        ///         3>	[sReturnInfItem].m_nReturnCode=-8,	û�пɹ��洢���ļ�;
        ///             [sReturnInfItem].m_nImgIndex,    	������;
        ///
        ///         4>	[sReturnInfItem].m_nReturnCode=-7,	ĳһ�洢�ļ�������;
        ///             [sReturnInfItem].m_nImgIndex,    	�����ڵ��ļ����;
        ///
        ///         5>	[sReturnInfItem].m_nReturnCode=-6,	��ʼ������;
        ///             [sReturnInfItem].m_nImgIndex,    	1:Content:Initialize Network Bad;
        ///                                                 2:Content:Create Association Parameters Bad;
        ///                                                 3:Content:Set Transport Layer Type Bad;
        ///                                                 4:Content:Add Storage Presentation Contexts Bad
        ///
        ///         6>	[sReturnInfItem].m_nReturnCode=-5,	����Э����̴���;
        ///             [sReturnInfItem].m_nImgIndex,    	1:Content:Association Rejected;
        ///                                                 2:Content:Association Request Failed;
        ///                                                 3:Content:No Acceptable Presentation Contexts;
        ///                                                 4:Content:Association Abort Failed;
        ///                                                 5:Content:Association Release Failed;
        ///                                                 6:Content:Destroy Association Failed;
        ///
        ///         7>	[sReturnInfItem].m_nReturnCode=-4,	��ʼ������;
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
        #endregion �ӿڶ���1

        #region �ӿڶ���2
        /// <summary>
        /// ��ָ��·����ͼ���ļ�(��jpg/bmp/tiff/png��ת��Ϊָ�����Ƶ�DICOMͼ��
        /// </summary>
        /// <param name="strExamAccessionNum">Worklist����õ�</param>
        /// <param name="strStudyUID">����¼��STUDY_INSTANCE_UID,���ɹ����Ѷ�</param>
        /// <param name="strPatientID">����ID��</param>
        /// <param name="strPatientLocalID">���˼���,��ӦWORKLIST��Patient_Local_ID,��ӦStudy��Study_Id</param>
        /// <param name="strPatientName">��������</param>
        /// <param name="strPatientSex">�����Ա�,�޶�"��/Ů/����"</param>
        /// <param name="nPatientAge">������������</param>
        /// <param name="strPatientAgeUnit">���˵����䵥λ,�޶�"��/��/��/��"</param>
        /// <param name="nSeriesNum">���к�,���ӿڽ������ڵ�������DCM�ļ���ת��</param>
        /// <param name="nInstanceNum">��ʼ��ͼ�����</param>
        /// <param name="strStudyDate">��ʽΪ:%.4d%.2d%.2d,��2002��11��5��Ϊ20021105</param>
        /// <param name="strStudyTime">��ʽΪ:%.2d%.2d%.2d.0,��11��5��17��Ϊ110517.0</param>
        /// <param name="strInputFileList">�����ļ�·��,�����ļ���";"�ֿ�</param>
        /// <param name="strOutputFileList">����ļ���(����·����Ϣ),�����ļ���";"�ֿ�</param>
        /// <param name="strOutputFilePath">����ļ��ı���·��,ע�������"\"��β</param>
        /// <param name="strModality">�γ�DCM�ļ���Modality,����US/�ھ�ES/����PS</param>
        /// <param name="strManufacturer">���ɸ��ļ��ĳ�����Ϣ,����ʹ��"E-Charm"</param>
        /// <param name="strAppVersionName"></param>
        /// <param name="nTransferSyntaxUID">�����﷨0:DCMĬ���﷨EXS_LittleEndianImplicit,����ʹ�ñ��﷨;1:JPEGProcess14SV1TransferSyntax;2:JPEGProcess1TransferSyntax;</param>
        /// <param name="bHaltOnEncounteredUnsucc">����ʧ���Ƿ��˳�</param>
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
                                                                    string strStudyDate,//���ڸ�ʽΪToString("yyyyMMdd")
                                                                    string strStudyTime,//ʱ���ʽΪ��ToString("hhmmss.0")
                                                                    string strInputFileList,//
                                                                    string strOutputFileList,//
                                                                    string strOutputFilePath,
                                                                    string strModality,
                                                                    string strManufacturer,
                                                                    string strAppVersionName,
                                                                    int nTransferSyntaxUID,//0,DCMĬ���﷨;1:
                                                                    bool bHaltOnEncounteredUnsucc//����ʧ��,�Ƿ��˳�
                                                                );//Ŀǰ��������RGBͼ��
        #endregion �ӿڶ���2

        #region �ص���������
        /// <summary>
        /// �ڴ洢�����еĻص�����
        /// </summary>
        /// <param name="callbackData"></param>
        /// <param name="nEventCode"></param>
        /// <param name="nFileName"></param>
        /// <param name="nFileIndex"></param>
        /// <param name="pHaltOn"></param>
        public delegate byte FPax_StoreUserCallback(IntPtr callbackData, int nEventCode, string nFileName, int nFileIndex);
        #endregion �ص���������

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
                                                                    dcm.nTransferSyntaxUID,//0,DCMĬ���﷨;1:
                                                                    dcm.bHaltOnEncounteredUnsucc//����ʧ��,�Ƿ��˳�
                                                                );//Ŀǰ��������RGBͼ��
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
                MessageBoxEx.Show("����ͼƬ��PACSʧ�ܣ�������������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (dcm.strInputFileList.Split(';').Length > m_sReturnItem.m_nImgIndex)
                {
                    int failCount = dcm.strInputFileList.Split(';').Length - m_sReturnItem.m_nImgIndex;
                    MessageBoxEx.Show(failCount.ToString() + "��ͼ���͵�PACSʧ�ܣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public int nTransferSyntaxUID;//0,DCMĬ���﷨;1:
        public bool bHaltOnEncounteredUnsucc;//����ʧ��,�Ƿ��˳�
    }
}
