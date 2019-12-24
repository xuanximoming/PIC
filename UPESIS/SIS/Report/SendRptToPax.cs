using System;
using System.Collections.Generic;
using System.Text;
using SIS_Model;
using System.Collections;
using SIS_BLL;
using System.Windows.Forms;

namespace SIS
{
    public class SendRptToPax
    {
        private MWorkList mWorklist;
        private MReport mReport;
        private string ImgSave;
        private BStudy bStudy = new BStudy();
        public MStudy mStudy = new MStudy();
        public SendRptToPax(MWorkList mWorklist, MReport mReport, string ImgSave)
        {
            this.mWorklist = mWorklist;
            this.mReport = mReport;
            this.ImgSave = ImgSave;
            WriteToPax();
        }
        public string Exam_Accession_Num = "";
        private string Study_Instance_Uid = "";
        public void WriteToPax()
        {
            WriteToStudy();
            //WriteToReport(userinfo, reportinfo);
            //updatePAXDBWorkListState();
            SendImgToPax();

        }

        private void WriteToStudy()
        {
            mStudy= new MStudy();
            mStudy.PATIENT_ID = mWorklist.PATIENT_ID;
            mStudy.PATIENT_NAME = mWorklist.PATIENT_NAME;
            mStudy.PATIENT_SEX = mWorklist.PATIENT_SEX;
            mStudy.PATIENT_BIRTH = mWorklist.PATIENT_BIRTH;
            mStudy.PATIENT_AGE = mWorklist.PATIENT_AGE;
            mStudy.PATIENT_AGE_UNIT = mWorklist.PATIENT_AGE_UNIT;
            BPatientSource bps = new BPatientSource();
            MPatientSource mps = (MPatientSource)bps.GetModel(mWorklist.PATIENT_SOURCE);
            mStudy.PATIENT_SOURCE = mps.PATIENT_SOURCE;
            mStudy.BIRTH_PLACE = mWorklist.BIRTH_PLACE;
            mStudy.IDENTITY = mWorklist.PATIENT_IDENTITY;
            mStudy.CHARGE_TYPE = mWorklist.CHARGE_TYPE.ToString();
            mStudy.VISIT_ID = mWorklist.VISIT_ID;
            mStudy.INP_NO = mWorklist.INP_NO;
            mStudy.BED_NUM = mWorklist.BED_NUM;
            mStudy.ZIP_CODE = mWorklist.ZIP_CODE;
            mStudy.MAILING_ADDRESS = mWorklist.MAILING_ADDRESS;
            mStudy.TELEPHONE_NUMBER = mWorklist.TELEPHONE_NUM;
            mStudy.STUDY_ID = mWorklist.PATIENT_LOCAL_ID;
            mStudy.STUDY_INSTANCE_UID = mWorklist.STUDY_INSTANCE_UID + ".1985.7.5";//创建
            mStudy.STUDY_DATE_TIME = DateTime.Now;
            mStudy.SERIES_COUNT = 0;
            mStudy.INSTANCE_COUNT = 0;
            mStudy.MODALITY = ILL.GetConfig.Modality;//配置文件中读取
            mStudy.FACILITY = "";//登陆时取得设备名
            mStudy.REFER_DOCTOR = mWorklist.REFER_DOCTOR;
            mStudy.REFER_DEPT = mWorklist.REFER_DEPT;
            mStudy.REQ_MEMO = mWorklist.REQ_MEMO;
            mStudy.REQ_DATE_TIME = mWorklist.REQ_DATE_TIME;
            mStudy.REQ_DEPT_NAME = mWorklist.REQ_DEPT_NAME;
            mStudy.SCHEDULED_DATE = mWorklist.SCHEDULED_DATE;
            mStudy.SCH_OPERATOR = mWorklist.SCH_OPERATOR;
            mStudy.EXAM_NO = mWorklist.EXAM_NO;
            mStudy.EXAM_ACCESSION_NUM = mWorklist.EXAM_ACCESSION_NUM;
            mStudy.EXAM_CLASS = mWorklist.EXAM_CLASS;
            mStudy.EXAM_SUB_CLASS = mWorklist.EXAM_SUB_CLASS;
            mStudy.EXAM_ITEM = mWorklist.EXAM_ITEMS;
            mStudy.EXAM_MODE = mWorklist.EXAM_MODE;
            mStudy.EXAM_GROUP = mWorklist.EXAM_GROUP;
            mStudy.EXAM_DEPT_NAME = mWorklist.EXAM_DEPT_NAME;
            mStudy.EXAM_DOCTOR = mWorklist.EXAM_DOCTOR;
            mStudy.EXAM_INDEX = mWorklist.EXAM_INDEX;
            mStudy.IS_ONLINE = 1;
            mStudy.IS_MATCHED = 1;
            mStudy.IS_PACKPROCESS = 1;
            mStudy.REPORT_STATUS = 1;
            mStudy.APPROVER = "";//报告人--登陆者
            mStudy.CLIN_DIAG = mWorklist.CLIN_DIAG;
            mStudy.CLIN_SYMP = mWorklist.CLIN_SYMP;
            mStudy.RELEVANT_DIAG = mWorklist.RELEVANT_DIAG;
            mStudy.RELEVANT_LAB_TEST = mWorklist.RELEVANT_LAB_TEST;
            mStudy.PHYS_SIGN = mWorklist.PHYS_SIGN;
            mStudy.DEVICE = mWorklist.DEVICE;
            if (!bStudy.Exists(mStudy))
            {
                //bStudy.Update(mStudy, " Where EXAM_ACCESSION_NUM='" + mStudy.EXAM_ACCESSION_NUM + "'");
                bStudy.Add(mStudy);
            }
            else
            {
                //bStudy.Update(mStudy, "EXAM_ACCESSION_NUM='" + mWorklist.EXAM_ACCESSION_NUM + "'");
            }
            
        }

        private void SendImgToPax()
        {

            DcmStudy stu = new DcmStudy();
            stu.strExamAccessionNum = mStudy.EXAM_ACCESSION_NUM;
            stu.strStudyUID = mStudy.STUDY_INSTANCE_UID;
            stu.strPatientID = mStudy.PATIENT_ID;
            stu.strPatientLocalID = mStudy.STUDY_ID;
            stu.strPatientName = mStudy.PATIENT_NAME;
            stu.strPatientSex = mStudy.PATIENT_SEX;
            stu.nPatientAge = (int)mStudy.PATIENT_AGE;
            stu.strPatientAgeUnit = mStudy.PATIENT_AGE_UNIT;
            stu.nSeriesNum = 1;
            stu.nInstanceNum = 0;
            stu.strStudyDate = ((DateTime)mStudy.STUDY_DATE_TIME).ToString("yyyyMMdd");//
            stu.strStudyTime = ((DateTime)mStudy.STUDY_DATE_TIME).ToString("hhmmss.0");
            stu.strInputFileList = this.ImgSave;//
            stu.strOutputFileList = GetDcmOutFile(this.ImgSave);//
            stu.strOutputFilePath = Application.StartupPath + "\\DCM\\";
            stu.strModality = mStudy.MODALITY;
            stu.strManufacturer = "EC";
            stu.strAppVersionName = "E-Charm";
            stu.nTransferSyntaxUID = 0;//0,DCM默认语法;1:
            stu.bHaltOnEncounteredUnsucc = false;//遇到失败,是否退出
            DcmInterface dcm = new DcmInterface();
            dcm.JPGToDCM(stu);
        }
        private string GetDcmOutFile(string ImgPath)
        {
            string outFiles = "";
            for (int i = 0; i < ImgPath.Split(';').Length; i++)
            {
                outFiles += i.ToString() + ".dcm;";
            }
           return outFiles.TrimEnd(';');
        }
        private string GetDcmPath1(string OutFiles)
        {
            string SaveDcmDic = Application.StartupPath + "\\DCM\\";
            string DcmPath = SaveDcmDic + OutFiles.TrimEnd(';').Replace(".dcm;", ".dcm;" + SaveDcmDic) + ";";
            return DcmPath;
        }
      
    }
}
