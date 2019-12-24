using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using ILL;
using PACS_Model;

namespace PACS_DAL
{
    public class DQcRyDiagDict : IQcRyDiagDict
    {
        private string strSql;
        private string TableName = "QC_RY_DIAG_DICT";
        public DQcRyDiagDict()
            : base(GetConfig.GetPacsConnStr())
        {
        }

        public override int Add(IModel iQcRyDiagDict)
        {
            MQcRyDiagDict qcRyDiagDict = (MQcRyDiagDict)iQcRyDiagDict;
            Hashtable ht = new Hashtable();
            ht.Add("CT_POSITIVE_RATE", qcRyDiagDict.CT_POSITIVE_RATE);
            ht.Add("DISTINCTION", qcRyDiagDict.DISTINCTION);
            ht.Add("DRPT_AGE", qcRyDiagDict.DRPT_AGE);
            ht.Add("DRPT_APP_DATE", qcRyDiagDict.DRPT_APP_DATE);
            ht.Add("DRPT_APPROVER", qcRyDiagDict.DRPT_APPROVER);
            ht.Add("DRPT_CLIN_DIAG", qcRyDiagDict.DRPT_CLIN_DIAG);
            ht.Add("DRPT_DESCRIPTION", qcRyDiagDict.DRPT_DESCRIPTION);
            ht.Add("DRPT_EXAM_ITEM", qcRyDiagDict.DRPT_EXAM_ITEM);
            ht.Add("DRPT_EXAM_TEC", qcRyDiagDict.DRPT_EXAM_TEC);
            ht.Add("DRPT_FILM_DATE", qcRyDiagDict.DRPT_FILM_DATE);
            ht.Add("DRPT_IMPRESSION", qcRyDiagDict.DRPT_IMPRESSION);
            ht.Add("DRPT_LOCAL_ID", qcRyDiagDict.DRPT_LOCAL_ID);
            ht.Add("DRPT_NAME", qcRyDiagDict.DRPT_NAME);
            ht.Add("DRPT_NUMBER", qcRyDiagDict.DRPT_NUMBER);
            ht.Add("DRPT_RPT_DATE", qcRyDiagDict.DRPT_RPT_DATE);
            ht.Add("DRPT_SEX", qcRyDiagDict.DRPT_SEX);
            ht.Add("DRPT_TRANSCRIBER", qcRyDiagDict.DRPT_TRANSCRIBER);
            ht.Add("EXAM_ACCESSION_NUM", qcRyDiagDict.EXAM_ACCESSION_NUM);
            ht.Add("INQ_AGE", qcRyDiagDict.INQ_AGE);
            ht.Add("INQ_DOCTOR", qcRyDiagDict.INQ_DOCTOR);
            ht.Add("INQ_EXAM_ITEM_DIAG", qcRyDiagDict.INQ_EXAM_ITEM_DIAG);
            ht.Add("INQ_LOCAL_ID", qcRyDiagDict.INQ_LOCAL_ID);
            ht.Add("INQ_NAME", qcRyDiagDict.INQ_NAME);
            ht.Add("INQ_NUMBER", qcRyDiagDict.INQ_NUMBER);
            ht.Add("INQ_OPE_DATE", qcRyDiagDict.INQ_OPE_DATE);
            ht.Add("INQ_OPERATION", qcRyDiagDict.INQ_OPERATION);
            ht.Add("INQ_PATH_DESCRIPTION", qcRyDiagDict.INQ_PATH_DESCRIPTION);
            ht.Add("INQ_PATH_DOCTOR", qcRyDiagDict.INQ_PATH_DOCTOR);
            ht.Add("INQ_PATH_NO", qcRyDiagDict.INQ_PATH_NO);
            ht.Add("INQ_SEX", qcRyDiagDict.INQ_SEX);
            ht.Add("MR_POSITIVE_RATE", qcRyDiagDict.MR_POSITIVE_RATE);
            ht.Add("NUMBER_KEY", qcRyDiagDict.NUMBER_KEY);
            ht.Add("PATIENT_ID", qcRyDiagDict.PATIENT_ID);
            ht.Add("PATIENT_LOCAL_ID", qcRyDiagDict.PATIENT_LOCAL_ID);
            ht.Add("PATIENT_NAME", qcRyDiagDict.PATIENT_NAME);
            ht.Add("PATIENT_SEX", qcRyDiagDict.PATIENT_SEX);
            ht.Add("PITCH", qcRyDiagDict.PITCH);
            ht.Add("QC_DATE", qcRyDiagDict.QC_DATE);
            ht.Add("QUALITATIVE", qcRyDiagDict.QUALITATIVE);
            ht.Add("STUDY_DATE_TIME", qcRyDiagDict.STUDY_DATE_TIME);
            ht.Add("TOTAL_SCORE", qcRyDiagDict.TOTAL_SCORE);
            ht.Add("XR_POSITIVE_RATE", qcRyDiagDict.XR_POSITIVE_RATE);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        public override int AddMore(Hashtable ht2)//批量插入
        {
            MQcRyDiagDict qcRyDiagDict = new MQcRyDiagDict();
            Hashtable ht = new Hashtable();
            Hashtable htstr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    qcRyDiagDict = (MQcRyDiagDict)ht2[i];
                    ht.Add("CT_POSITIVE_RATE", qcRyDiagDict.CT_POSITIVE_RATE);
                    ht.Add("DISTINCTION", qcRyDiagDict.DISTINCTION);
                    ht.Add("DRPT_AGE", qcRyDiagDict.DRPT_AGE);
                    ht.Add("DRPT_APP_DATE", qcRyDiagDict.DRPT_APP_DATE);
                    ht.Add("DRPT_APPROVER", qcRyDiagDict.DRPT_APPROVER);
                    ht.Add("DRPT_CLIN_DIAG", qcRyDiagDict.DRPT_CLIN_DIAG);
                    ht.Add("DRPT_DESCRIPTION", qcRyDiagDict.DRPT_DESCRIPTION);
                    ht.Add("DRPT_EXAM_ITEM", qcRyDiagDict.DRPT_EXAM_ITEM);
                    ht.Add("DRPT_EXAM_TEC", qcRyDiagDict.DRPT_EXAM_TEC);
                    ht.Add("DRPT_FILM_DATE", qcRyDiagDict.DRPT_FILM_DATE);
                    ht.Add("DRPT_IMPRESSION", qcRyDiagDict.DRPT_IMPRESSION);
                    ht.Add("DRPT_LOCAL_ID", qcRyDiagDict.DRPT_LOCAL_ID);
                    ht.Add("DRPT_NAME", qcRyDiagDict.DRPT_NAME);
                    ht.Add("DRPT_NUMBER", qcRyDiagDict.DRPT_NUMBER);
                    ht.Add("DRPT_RPT_DATE", qcRyDiagDict.DRPT_RPT_DATE);
                    ht.Add("DRPT_SEX", qcRyDiagDict.DRPT_SEX);
                    ht.Add("DRPT_TRANSCRIBER", qcRyDiagDict.DRPT_TRANSCRIBER);
                    ht.Add("EXAM_ACCESSION_NUM", qcRyDiagDict.EXAM_ACCESSION_NUM);
                    ht.Add("INQ_AGE", qcRyDiagDict.INQ_AGE);
                    ht.Add("INQ_DOCTOR", qcRyDiagDict.INQ_DOCTOR);
                    ht.Add("INQ_EXAM_ITEM_DIAG", qcRyDiagDict.INQ_EXAM_ITEM_DIAG);
                    ht.Add("INQ_LOCAL_ID", qcRyDiagDict.INQ_LOCAL_ID);
                    ht.Add("INQ_NAME", qcRyDiagDict.INQ_NAME);
                    ht.Add("INQ_NUMBER", qcRyDiagDict.INQ_NUMBER);
                    ht.Add("INQ_OPE_DATE", qcRyDiagDict.INQ_OPE_DATE);
                    ht.Add("INQ_OPERATION", qcRyDiagDict.INQ_OPERATION);
                    ht.Add("INQ_PATH_DESCRIPTION", qcRyDiagDict.INQ_PATH_DESCRIPTION);
                    ht.Add("INQ_PATH_DOCTOR", qcRyDiagDict.INQ_PATH_DOCTOR);
                    ht.Add("INQ_PATH_NO", qcRyDiagDict.INQ_PATH_NO);
                    ht.Add("INQ_SEX", qcRyDiagDict.INQ_SEX);
                    ht.Add("MR_POSITIVE_RATE", qcRyDiagDict.MR_POSITIVE_RATE);
                    ht.Add("NUMBER_KEY", qcRyDiagDict.NUMBER_KEY);
                    ht.Add("PATIENT_ID", qcRyDiagDict.PATIENT_ID);
                    ht.Add("PATIENT_LOCAL_ID", qcRyDiagDict.PATIENT_LOCAL_ID);
                    ht.Add("PATIENT_NAME", qcRyDiagDict.PATIENT_NAME);
                    ht.Add("PATIENT_SEX", qcRyDiagDict.PATIENT_SEX);
                    ht.Add("PITCH", qcRyDiagDict.PITCH);
                    ht.Add("QC_DATE", qcRyDiagDict.QC_DATE);
                    ht.Add("QUALITATIVE", qcRyDiagDict.QUALITATIVE);
                    ht.Add("STUDY_DATE_TIME", qcRyDiagDict.STUDY_DATE_TIME);
                    ht.Add("TOTAL_SCORE", qcRyDiagDict.TOTAL_SCORE);
                    ht.Add("XR_POSITIVE_RATE", qcRyDiagDict.XR_POSITIVE_RATE);
                    htstr.Add(i, StringConstructor.InsertSql(TableName, ht).ToString());
                }
                return ExecuteNonSql(htstr);

            }
            else
                return 0;
        }

        public override bool Exists(IModel iQcRyDiagDict)
        {
            MQcRyDiagDict qcRyDiagDict = (MQcRyDiagDict)iQcRyDiagDict;
            strSql = "select * from " + TableName + " where EXAM_ACCESSION_NUM='" + qcRyDiagDict.EXAM_ACCESSION_NUM + "'";
            return recordIsExist(strSql);
        }

        public override IModel GetModel(string EXAM_ACCESSION_NUM)
        {
            strSql = "select * from " + TableName + "  where EXAM_ACCESSION_NUM='" + EXAM_ACCESSION_NUM + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MQcRyDiagDict qcRyDiagDict = new MQcRyDiagDict();
            if (dt.Rows[0]["CT_POSITIVE_RATE"] == null)
                qcRyDiagDict.CT_POSITIVE_RATE = null;
            else
                qcRyDiagDict.CT_POSITIVE_RATE = Convert.ToInt32(dt.Rows[0]["CT_POSITIVE_RATE"].ToString());
            if (dt.Rows[0]["DISTINCTION"] == null)
                qcRyDiagDict.DISTINCTION = null;
            else
                qcRyDiagDict.DISTINCTION = Convert.ToInt32(dt.Rows[0]["DISTINCTION"].ToString());
            if (dt.Rows[0]["DRPT_AGE"] == null)
                qcRyDiagDict.DRPT_AGE = null;
            else
                qcRyDiagDict.DRPT_AGE = Convert.ToInt32(dt.Rows[0]["DRPT_AGE"].ToString());
            if (dt.Rows[0]["DRPT_APP_DATE"] == null)
                qcRyDiagDict.DRPT_APP_DATE = null;
            else
                qcRyDiagDict.DRPT_APP_DATE = Convert.ToInt32(dt.Rows[0]["DRPT_APP_DATE"].ToString());
            if (dt.Rows[0]["DRPT_APPROVER"] == null)
                qcRyDiagDict.DRPT_APPROVER = null;
            else
                qcRyDiagDict.DRPT_APPROVER = Convert.ToInt32(dt.Rows[0]["DRPT_APPROVER"].ToString());
            if (dt.Rows[0]["DRPT_CLIN_DIAG"] == null)
                qcRyDiagDict.DRPT_CLIN_DIAG = null;
            else
                qcRyDiagDict.DRPT_CLIN_DIAG = Convert.ToInt32(dt.Rows[0]["[DRPT_CLIN_DIAG"].ToString());
            if (dt.Rows[0]["DRPT_DESCRIPTION"] == null)
                qcRyDiagDict.DRPT_DESCRIPTION = null;
            else
                qcRyDiagDict.DRPT_DESCRIPTION = Convert.ToInt32(dt.Rows[0]["DRPT_DESCRIPTION"].ToString());
            if (dt.Rows[0]["DRPT_EXAM_ITEM"] == null)
                qcRyDiagDict.DRPT_EXAM_ITEM = null;
            else
                qcRyDiagDict.DRPT_EXAM_ITEM = Convert.ToInt32(dt.Rows[0]["DRPT_EXAM_ITEM"].ToString());
            if (dt.Rows[0]["DRPT_EXAM_TEC"] == null)
                qcRyDiagDict.DRPT_EXAM_TEC = null;
            else
                qcRyDiagDict.DRPT_EXAM_TEC = Convert.ToInt32(dt.Rows[0]["DRPT_EXAM_TEC"].ToString());
            if (dt.Rows[0]["DRPT_FILM_DATE"] == null)
                qcRyDiagDict.DRPT_FILM_DATE = null;
            else
                qcRyDiagDict.DRPT_FILM_DATE = Convert.ToInt32(dt.Rows[0]["DRPT_FILM_DATE"].ToString());
            if (dt.Rows[0]["DRPT_IMPRESSION"] == null)
                qcRyDiagDict.DRPT_IMPRESSION = null;
            else
                qcRyDiagDict.DRPT_IMPRESSION = Convert.ToInt32(dt.Rows[0]["DRPT_IMPRESSION"].ToString());
            if (dt.Rows[0]["DRPT_LOCAL_ID"] == null)
                qcRyDiagDict.DRPT_LOCAL_ID = null;
            else
                qcRyDiagDict.DRPT_LOCAL_ID = Convert.ToInt32(dt.Rows[0]["DRPT_LOCAL_ID"].ToString());
            if (dt.Rows[0]["DRPT_NAME"] == null)
                qcRyDiagDict.DRPT_NAME = null;
            else
                qcRyDiagDict.DRPT_NAME = Convert.ToInt32(dt.Rows[0]["DRPT_NAME"].ToString());
            if (dt.Rows[0]["DRPT_NUMBER"] == null)
                qcRyDiagDict.DRPT_NUMBER = null;
            else
                qcRyDiagDict.DRPT_NUMBER = Convert.ToInt32(dt.Rows[0]["DRPT_NUMBER"].ToString());
            if (dt.Rows[0]["DRPT_RPT_DATE"] == null)
                qcRyDiagDict.DRPT_RPT_DATE = null;
            else
                qcRyDiagDict.DRPT_RPT_DATE = Convert.ToInt32(dt.Rows[0]["DRPT_RPT_DATE"].ToString());
            if (dt.Rows[0]["DRPT_SEX"] == null)
                qcRyDiagDict.DRPT_SEX = null;
            else
                qcRyDiagDict.DRPT_SEX = Convert.ToInt32(dt.Rows[0]["DRPT_SEX"].ToString());
            if (dt.Rows[0]["DRPT_TRANSCRIBER"] == null)
                qcRyDiagDict.DRPT_TRANSCRIBER = null;
            else
                qcRyDiagDict.DRPT_TRANSCRIBER = Convert.ToInt32(dt.Rows[0]["DRPT_TRANSCRIBER"].ToString());

            qcRyDiagDict.EXAM_ACCESSION_NUM = dt.Rows[0]["EXAM_ACCESSION_NUM"].ToString();

            if (dt.Rows[0]["INQ_AGE"] == null)
                qcRyDiagDict.INQ_AGE = null;
            else
                qcRyDiagDict.INQ_AGE = Convert.ToInt32(dt.Rows[0]["INQ_AGE"].ToString());
            if (dt.Rows[0]["INQ_DOCTOR"] == null)
                qcRyDiagDict.INQ_DOCTOR = null;
            else
                qcRyDiagDict.INQ_DOCTOR = Convert.ToInt32(dt.Rows[0]["INQ_DOCTOR"].ToString());
            if (dt.Rows[0]["INQ_EXAM_ITEM_DIAG"] == null)
                qcRyDiagDict.INQ_EXAM_ITEM_DIAG = null;
            else
                qcRyDiagDict.INQ_EXAM_ITEM_DIAG = Convert.ToInt32(dt.Rows[0]["INQ_EXAM_ITEM_DIAG"].ToString());
            if (dt.Rows[0]["INQ_LOCAL_ID"] == null)
                qcRyDiagDict.INQ_LOCAL_ID = null;
            else
                qcRyDiagDict.INQ_LOCAL_ID = Convert.ToInt32(dt.Rows[0]["INQ_LOCAL_ID"].ToString());
            if (dt.Rows[0]["INQ_NAME"] == null)
                qcRyDiagDict.INQ_NAME = null;
            else
                qcRyDiagDict.INQ_NAME = Convert.ToInt32(dt.Rows[0]["INQ_NAME"].ToString());
            if (dt.Rows[0]["INQ_NUMBER"] == null)
                qcRyDiagDict.INQ_NUMBER = null;
            else
                qcRyDiagDict.INQ_NUMBER = Convert.ToInt32(dt.Rows[0]["INQ_NUMBER"].ToString());
            if (dt.Rows[0]["INQ_OPE_DATE"] == null)
                qcRyDiagDict.INQ_OPE_DATE = null;
            else
                qcRyDiagDict.INQ_OPE_DATE = Convert.ToInt32(dt.Rows[0]["INQ_OPE_DATE"].ToString());
            if (dt.Rows[0]["INQ_OPERATION"] == null)
                qcRyDiagDict.INQ_OPERATION = null;
            else
                qcRyDiagDict.INQ_OPERATION = Convert.ToInt32(dt.Rows[0]["INQ_OPERATION"].ToString());

            if (dt.Rows[0]["INQ_PATH_DESCRIPTION"] == null)
                qcRyDiagDict.INQ_PATH_DESCRIPTION = null;
            else
                qcRyDiagDict.INQ_PATH_DESCRIPTION = Convert.ToInt32(dt.Rows[0]["INQ_PATH_DESCRIPTION"].ToString());

            if (dt.Rows[0]["INQ_PATH_DOCTOR"] == null)
                qcRyDiagDict.INQ_PATH_DOCTOR = null;
            else
                qcRyDiagDict.INQ_PATH_DOCTOR = Convert.ToInt32(dt.Rows[0]["INQ_PATH_DOCTOR"].ToString());

            if (dt.Rows[0]["INQ_PATH_NO"] == null)
                qcRyDiagDict.INQ_PATH_NO = null;
            else
                qcRyDiagDict.INQ_PATH_NO = Convert.ToInt32(dt.Rows[0]["INQ_PATH_NO"].ToString());

            if (dt.Rows[0]["INQ_SEX"] == null)
                qcRyDiagDict.INQ_SEX = null;
            else
                qcRyDiagDict.INQ_SEX = Convert.ToInt32(dt.Rows[0]["INQ_SEX"].ToString());

            if (dt.Rows[0]["MR_POSITIVE_RATE"] == null)
                qcRyDiagDict.MR_POSITIVE_RATE = null;
            else
                qcRyDiagDict.MR_POSITIVE_RATE = Convert.ToInt32(dt.Rows[0]["MR_POSITIVE_RATE"].ToString());
            if (dt.Rows[0]["NUMBER_KEY"] == null)
                qcRyDiagDict.NUMBER_KEY = null;
            else
                qcRyDiagDict.NUMBER_KEY = Convert.ToInt32(dt.Rows[0]["NUMBER_KEY"].ToString());

            qcRyDiagDict.PATIENT_ID = dt.Rows[0]["PATIENT_ID"].ToString();
            qcRyDiagDict.PATIENT_LOCAL_ID = dt.Rows[0]["PATIENT_LOCAL_ID"].ToString();
            qcRyDiagDict.PATIENT_NAME = dt.Rows[0]["PATIENT_NAME"].ToString();
            qcRyDiagDict.PATIENT_SEX = dt.Rows[0]["PATIENT_SEX"].ToString();

            if (dt.Rows[0]["PITCH"] == null)
                qcRyDiagDict.PITCH = null;
            else
                qcRyDiagDict.PITCH = Convert.ToInt32(dt.Rows[0]["PITCH"].ToString());
            if (dt.Rows[0]["QC_DATE"] == null)
                qcRyDiagDict.QC_DATE = null;
            else
                qcRyDiagDict.QC_DATE = Convert.ToDateTime(dt.Rows[0]["QC_DATE"].ToString());
            if (dt.Rows[0]["QUALITATIVE"] == null)
                qcRyDiagDict.QUALITATIVE = null;
            else
                qcRyDiagDict.QUALITATIVE = Convert.ToInt32(dt.Rows[0]["QUALITATIVE"].ToString());

            if (dt.Rows[0]["STUDY_DATE_TIME"] == null)
                qcRyDiagDict.STUDY_DATE_TIME = null;
            else
                qcRyDiagDict.STUDY_DATE_TIME = Convert.ToDateTime(dt.Rows[0]["STUDY_DATE_TIME"].ToString());
            if (dt.Rows[0]["TOTAL_SCORE"] == null)
                qcRyDiagDict.TOTAL_SCORE = null;
            else
                qcRyDiagDict.TOTAL_SCORE = Convert.ToInt32(dt.Rows[0]["TOTAL_SCORE"].ToString());
            if (dt.Rows[0]["XR_POSITIVE_RATE"] == null)
                qcRyDiagDict.XR_POSITIVE_RATE = null;
            else
                qcRyDiagDict.XR_POSITIVE_RATE = Convert.ToInt32(dt.Rows[0]["XR_POSITIVE_RATE"].ToString());
            return qcRyDiagDict;
        }

        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        public override int Update(IModel iQcRyDiagDict, string where)
        {
            MQcRyDiagDict qcRyDiagDict = (MQcRyDiagDict)iQcRyDiagDict;
            Hashtable ht = new Hashtable();
            ht.Add("CT_POSITIVE_RATE", qcRyDiagDict.CT_POSITIVE_RATE);
            ht.Add("DISTINCTION", qcRyDiagDict.DISTINCTION);
            ht.Add("DRPT_AGE", qcRyDiagDict.DRPT_AGE);
            ht.Add("DRPT_APP_DATE", qcRyDiagDict.DRPT_APP_DATE);
            ht.Add("DRPT_APPROVER", qcRyDiagDict.DRPT_APPROVER);
            ht.Add("DRPT_CLIN_DIAG", qcRyDiagDict.DRPT_CLIN_DIAG);
            ht.Add("DRPT_DESCRIPTION", qcRyDiagDict.DRPT_DESCRIPTION);
            ht.Add("DRPT_EXAM_ITEM", qcRyDiagDict.DRPT_EXAM_ITEM);
            ht.Add("DRPT_EXAM_TEC", qcRyDiagDict.DRPT_EXAM_TEC);
            ht.Add("DRPT_FILM_DATE", qcRyDiagDict.DRPT_FILM_DATE);
            ht.Add("DRPT_IMPRESSION", qcRyDiagDict.DRPT_IMPRESSION);
            ht.Add("DRPT_LOCAL_ID", qcRyDiagDict.DRPT_LOCAL_ID);
            ht.Add("DRPT_NAME", qcRyDiagDict.DRPT_NAME);
            ht.Add("DRPT_NUMBER", qcRyDiagDict.DRPT_NUMBER);
            ht.Add("DRPT_RPT_DATE", qcRyDiagDict.DRPT_RPT_DATE);
            ht.Add("DRPT_SEX", qcRyDiagDict.DRPT_SEX);
            ht.Add("DRPT_TRANSCRIBER", qcRyDiagDict.DRPT_TRANSCRIBER);
            ht.Add("EXAM_ACCESSION_NUM", qcRyDiagDict.EXAM_ACCESSION_NUM);
            ht.Add("INQ_AGE", qcRyDiagDict.INQ_AGE);
            ht.Add("INQ_DOCTOR", qcRyDiagDict.INQ_DOCTOR);
            ht.Add("INQ_EXAM_ITEM_DIAG", qcRyDiagDict.INQ_EXAM_ITEM_DIAG);
            ht.Add("INQ_LOCAL_ID", qcRyDiagDict.INQ_LOCAL_ID);
            ht.Add("INQ_NAME", qcRyDiagDict.INQ_NAME);
            ht.Add("INQ_NUMBER", qcRyDiagDict.INQ_NUMBER);
            ht.Add("INQ_OPE_DATE", qcRyDiagDict.INQ_OPE_DATE);
            ht.Add("INQ_OPERATION", qcRyDiagDict.INQ_OPERATION);
            ht.Add("INQ_PATH_DESCRIPTION", qcRyDiagDict.INQ_PATH_DESCRIPTION);
            ht.Add("INQ_PATH_DOCTOR", qcRyDiagDict.INQ_PATH_DOCTOR);
            ht.Add("INQ_PATH_NO", qcRyDiagDict.INQ_PATH_NO);
            ht.Add("INQ_SEX", qcRyDiagDict.INQ_SEX);
            ht.Add("MR_POSITIVE_RATE", qcRyDiagDict.MR_POSITIVE_RATE);
            ht.Add("NUMBER_KEY", qcRyDiagDict.NUMBER_KEY);
            ht.Add("PATIENT_ID", qcRyDiagDict.PATIENT_ID);
            ht.Add("PATIENT_LOCAL_ID", qcRyDiagDict.PATIENT_LOCAL_ID);
            ht.Add("PATIENT_NAME", qcRyDiagDict.PATIENT_NAME);
            ht.Add("PATIENT_SEX", qcRyDiagDict.PATIENT_SEX);
            ht.Add("PITCH", qcRyDiagDict.PITCH);
            ht.Add("QC_DATE", qcRyDiagDict.QC_DATE);
            ht.Add("QUALITATIVE", qcRyDiagDict.QUALITATIVE);
            ht.Add("STUDY_DATE_TIME", qcRyDiagDict.STUDY_DATE_TIME);
            ht.Add("TOTAL_SCORE", qcRyDiagDict.TOTAL_SCORE);
            ht.Add("XR_POSITIVE_RATE", qcRyDiagDict.XR_POSITIVE_RATE);
            return ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString());
        }

        public override int UpdateMore(Hashtable ht2)
        {
            MQcRyDiagDict qcRyDiagDict = new MQcRyDiagDict();
            Hashtable ht = new Hashtable();
            Hashtable htStr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    qcRyDiagDict = (MQcRyDiagDict)ht2[i];
                    ht.Add("CT_POSITIVE_RATE", qcRyDiagDict.CT_POSITIVE_RATE);
                    ht.Add("DISTINCTION", qcRyDiagDict.DISTINCTION);
                    ht.Add("DRPT_AGE", qcRyDiagDict.DRPT_AGE);
                    ht.Add("DRPT_APP_DATE", qcRyDiagDict.DRPT_APP_DATE);
                    ht.Add("DRPT_APPROVER", qcRyDiagDict.DRPT_APPROVER);
                    ht.Add("DRPT_CLIN_DIAG", qcRyDiagDict.DRPT_CLIN_DIAG);
                    ht.Add("DRPT_DESCRIPTION", qcRyDiagDict.DRPT_DESCRIPTION);
                    ht.Add("DRPT_EXAM_ITEM", qcRyDiagDict.DRPT_EXAM_ITEM);
                    ht.Add("DRPT_EXAM_TEC", qcRyDiagDict.DRPT_EXAM_TEC);
                    ht.Add("DRPT_FILM_DATE", qcRyDiagDict.DRPT_FILM_DATE);
                    ht.Add("DRPT_IMPRESSION", qcRyDiagDict.DRPT_IMPRESSION);
                    ht.Add("DRPT_LOCAL_ID", qcRyDiagDict.DRPT_LOCAL_ID);
                    ht.Add("DRPT_NAME", qcRyDiagDict.DRPT_NAME);
                    ht.Add("DRPT_NUMBER", qcRyDiagDict.DRPT_NUMBER);
                    ht.Add("DRPT_RPT_DATE", qcRyDiagDict.DRPT_RPT_DATE);
                    ht.Add("DRPT_SEX", qcRyDiagDict.DRPT_SEX);
                    ht.Add("DRPT_TRANSCRIBER", qcRyDiagDict.DRPT_TRANSCRIBER);
                    ht.Add("EXAM_ACCESSION_NUM", qcRyDiagDict.EXAM_ACCESSION_NUM);
                    ht.Add("INQ_AGE", qcRyDiagDict.INQ_AGE);
                    ht.Add("INQ_DOCTOR", qcRyDiagDict.INQ_DOCTOR);
                    ht.Add("INQ_EXAM_ITEM_DIAG", qcRyDiagDict.INQ_EXAM_ITEM_DIAG);
                    ht.Add("INQ_LOCAL_ID", qcRyDiagDict.INQ_LOCAL_ID);
                    ht.Add("INQ_NAME", qcRyDiagDict.INQ_NAME);
                    ht.Add("INQ_NUMBER", qcRyDiagDict.INQ_NUMBER);
                    ht.Add("INQ_OPE_DATE", qcRyDiagDict.INQ_OPE_DATE);
                    ht.Add("INQ_OPERATION", qcRyDiagDict.INQ_OPERATION);
                    ht.Add("INQ_PATH_DESCRIPTION", qcRyDiagDict.INQ_PATH_DESCRIPTION);
                    ht.Add("INQ_PATH_DOCTOR", qcRyDiagDict.INQ_PATH_DOCTOR);
                    ht.Add("INQ_PATH_NO", qcRyDiagDict.INQ_PATH_NO);
                    ht.Add("INQ_SEX", qcRyDiagDict.INQ_SEX);
                    ht.Add("MR_POSITIVE_RATE", qcRyDiagDict.MR_POSITIVE_RATE);
                    ht.Add("NUMBER_KEY", qcRyDiagDict.NUMBER_KEY);
                    ht.Add("PATIENT_ID", qcRyDiagDict.PATIENT_ID);
                    ht.Add("PATIENT_LOCAL_ID", qcRyDiagDict.PATIENT_LOCAL_ID);
                    ht.Add("PATIENT_NAME", qcRyDiagDict.PATIENT_NAME);
                    ht.Add("PATIENT_SEX", qcRyDiagDict.PATIENT_SEX);
                    ht.Add("PITCH", qcRyDiagDict.PITCH);
                    ht.Add("QC_DATE", qcRyDiagDict.QC_DATE);
                    ht.Add("QUALITATIVE", qcRyDiagDict.QUALITATIVE);
                    ht.Add("STUDY_DATE_TIME", qcRyDiagDict.STUDY_DATE_TIME);
                    ht.Add("TOTAL_SCORE", qcRyDiagDict.TOTAL_SCORE);
                    ht.Add("XR_POSITIVE_RATE", qcRyDiagDict.XR_POSITIVE_RATE);
                    htStr.Add(i, StringConstructor.UpdateSql(TableName, ht, " where EXAM_ACCESSION_NUM='" + qcRyDiagDict.EXAM_ACCESSION_NUM + "'"));
                }

                return ExecuteNonSql(htStr);
            }
            return 0;
        }


        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }

        public override int DeleteMore(Hashtable ht)
        {
            this.Open();
            IDbCommand dbCom = dbF.getDBCommand();
            dbCom.Connection = this.dbConn;
            IDbTransaction tran = dbF.getTransaction(this.dbConn);
            dbCom.Transaction = tran;
            dbCom.CommandType = CommandType.Text;
            try
            {
                foreach (DictionaryEntry item in ht)
                {
                    dbCom.CommandText = "Delete " + TableName + " where EXAM_ACCESSION_NUM='" + item.Value.ToString() + "'";
                    dbCom.ExecuteNonQuery();
                }
                tran.Commit();
                return ht.Count;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                tran.Rollback();
                //MessageBox.Show("数据库事物处理错误！");
                return 0;
            }
            finally
            {
                this.Close();
            }
        }
    }
}
