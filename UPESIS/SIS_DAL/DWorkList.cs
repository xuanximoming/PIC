using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using SIS_Model;
using System.Data;
using ILL;

namespace SIS_DAL
{
    /// <summary>
    /// 对WORKLIST，工作列表
    /// </summary>
    public class DWorkList : IWorkList
    {
        private string strSql;
        private string TableName = "WORKLIST";
        public DWorkList()
            : base(GetConfig.GetSisConnStr())
        {
        }

        /// <summary>
        /// 插入一条工作记录
        /// </summary>
        /// <param name="iworklist"></param>
        /// <returns></returns>
        public override int Add(IModel iworklist)
        {
            MWorkList worklist = (MWorkList)iworklist;
            Hashtable ht = new Hashtable();
            ht.Add("PATIENT_ID", worklist.PATIENT_ID);
            ht.Add("PATIENT_NAME", worklist.PATIENT_NAME);
            ht.Add("PATIENT_PHONETIC", worklist.PATIENT_PHONETIC);
            ht.Add("PATIENT_SEX", worklist.PATIENT_SEX);
            ht.Add("PATIENT_BIRTH", worklist.PATIENT_BIRTH);
            ht.Add("PATIENT_AGE", worklist.PATIENT_AGE);
            ht.Add("PATIENT_AGE_UNIT", worklist.PATIENT_AGE_UNIT);
            ht.Add("PATIENT_LOCAL_ID", worklist.PATIENT_LOCAL_ID);
            ht.Add("LOCAL_ID_CLASS", worklist.LOCAL_ID_CLASS);
            ht.Add("INP_NO", worklist.INP_NO);
            ht.Add("OPD_NO", worklist.OPD_NO);
            ht.Add("BIRTH_PLACE", worklist.BIRTH_PLACE);
            ht.Add("PATIENT_IDENTITY", worklist.PATIENT_IDENTITY);
            ht.Add("CHARGE_TYPE", worklist.CHARGE_TYPE);
            ht.Add("BED_NUM", worklist.BED_NUM);
            ht.Add("MAILING_ADDRESS", worklist.MAILING_ADDRESS);
            ht.Add("ZIP_CODE", worklist.ZIP_CODE);
            ht.Add("TELEPHONE_NUM", worklist.TELEPHONE_NUM);
            ht.Add("PATIENT_SOURCE", worklist.PATIENT_SOURCE);
            ht.Add("EXAM_CLASS", worklist.EXAM_CLASS);
            ht.Add("EXAM_SUB_CLASS", worklist.EXAM_SUB_CLASS);
            ht.Add("EXAM_ITEMS", worklist.EXAM_ITEMS);
            ht.Add("EXAM_DEPT", worklist.EXAM_DEPT);
            ht.Add("EXAM_DEPT_NAME", worklist.EXAM_DEPT_NAME);
            ht.Add("EXAM_NO", worklist.EXAM_NO);
            ht.Add("ACCESSION_NO", worklist.ACCESSION_NO);
            ht.Add("EXAM_ACCESSION_NUM ", worklist.EXAM_ACCESSION_NUM);
            ht.Add("STUDY_INSTANCE_UID", worklist.STUDY_INSTANCE_UID);
            ht.Add("EXAM_DOCTOR", worklist.EXAM_DOCTOR);
            ht.Add("REPORT_DOCTOR", worklist.REPORT_DOCTOR);
            ht.Add("SCH_OPERATOR", worklist.SCH_OPERATOR);
            ht.Add("STUDY_PATH", worklist.STUDY_PATH);
            ht.Add("EXAM_MODE", worklist.EXAM_MODE);
            ht.Add("EXAM_INDEX", worklist.EXAM_INDEX);
            ht.Add("DEVICE", worklist.DEVICE);
            ht.Add("EXAM_INTRADAYSEQ_NO", worklist.EXAM_INTRADAYSEQ_NO);
            ht.Add("EXAM_GROUP", worklist.EXAM_GROUP);
            ht.Add("STUDY_DATE_TIME", worklist.STUDY_DATE_TIME);
            ht.Add("EXAM_STEP_STATUS", worklist.EXAM_STEP_STATUS);
            ht.Add("REPORT_STATUS", worklist.REPORT_STATUS);
            ht.Add("IS_CONFIRMED", worklist.IS_CONFIRMED);
            ht.Add("MATCH_STATUS", worklist.MATCH_STATUS);
            ht.Add("IS_TEMPORARY", worklist.IS_TEMPORARY);
            ht.Add("VIP_INDICATOR", worklist.VIP_INDICATOR);
            ht.Add("IMAGE_ARCHIVED", worklist.IMAGE_ARCHIVED);
            ht.Add("PRE_FETCH", worklist.PRE_FETCH);
            ht.Add("QUERY_STATUS", worklist.QUERY_STATUS);
            ht.Add("DISPATCH_STATUS", worklist.DISPATCH_STATUS);
            ht.Add("PATIENT_CLASS", worklist.PATIENT_CLASS);
            ht.Add("QUERY_TIME", worklist.QUERY_TIME);
            ht.Add("IMAGE_COUNTS", worklist.IMAGE_COUNTS);
            ht.Add("SCHEDULED_DATE", worklist.SCHEDULED_DATE);
            ht.Add("REFER_DOCTOR", worklist.REFER_DOCTOR);
            ht.Add("REFER_DEPT", worklist.REFER_DEPT);
            ht.Add("REQ_DATE_TIME", worklist.REQ_DATE_TIME);
            ht.Add("REQ_DEPT_NAME", worklist.REQ_DEPT_NAME);
            ht.Add("REQ_MEMO", worklist.REQ_MEMO);
            ht.Add("CLIN_SYMP", worklist.CLIN_SYMP);
            ht.Add("PHYS_SIGN", worklist.PHYS_SIGN);
            ht.Add("RELEVANT_LAB_TEST", worklist.RELEVANT_LAB_TEST);
            ht.Add("RELEVANT_DIAG", worklist.RELEVANT_DIAG);
            ht.Add("CLIN_DIAG", worklist.CLIN_DIAG);
            ht.Add("FACILITY", worklist.FACILITY);
            ht.Add("OUT_MED_INSTITUTION", worklist.OUT_MED_INSTITUTION);
            ht.Add("VISIT_ID", worklist.VISIT_ID);
            ht.Add("COSTS", worklist.COSTS);
            ht.Add("CHARGES", worklist.CHARGES);
            ht.Add("IS_INQUIRY", worklist.IS_INQUIRY);
            ht.Add("IS_BACK_INQ", worklist.IS_BACK_INQ);
            ht.Add("IS_ONLINE", worklist.IS_ONLINE);
            ht.Add("IS_PACKPROCESS", worklist.IS_PACKPROCESS);
            ht.Add("VOLUMN_KEY", worklist.VOLUMN_KEY);
            ht.Add("JZH", worklist.JZH);    //记账号　　add by liukun at 2010-7-13
            return ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString());
        }

        /// <summary>
        /// 更新指定的工作记录
        /// </summary>
        /// <param name="iworklist"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel iworklist, string where)
        {
            MWorkList worklist = (MWorkList)iworklist;
            Hashtable ht = new Hashtable();
            ht.Add("PATIENT_ID", worklist.PATIENT_ID);
            ht.Add("PATIENT_NAME", worklist.PATIENT_NAME);
            ht.Add("PATIENT_PHONETIC", worklist.PATIENT_PHONETIC);
            ht.Add("PATIENT_SEX", worklist.PATIENT_SEX);
            ht.Add("PATIENT_BIRTH", worklist.PATIENT_BIRTH);
            ht.Add("PATIENT_AGE", worklist.PATIENT_AGE);
            ht.Add("PATIENT_AGE_UNIT", worklist.PATIENT_AGE_UNIT);
            ht.Add("PATIENT_LOCAL_ID", worklist.PATIENT_LOCAL_ID);
            ht.Add("LOCAL_ID_CLASS", worklist.LOCAL_ID_CLASS);
            ht.Add("INP_NO", worklist.INP_NO);
            ht.Add("OPD_NO", worklist.OPD_NO);
            ht.Add("BIRTH_PLACE", worklist.BIRTH_PLACE);
            ht.Add("PATIENT_IDENTITY", worklist.PATIENT_IDENTITY);
            ht.Add("CHARGE_TYPE", worklist.CHARGE_TYPE);
            ht.Add("BED_NUM", worklist.BED_NUM);
            ht.Add("MAILING_ADDRESS", worklist.MAILING_ADDRESS);
            ht.Add("ZIP_CODE", worklist.ZIP_CODE);
            ht.Add("TELEPHONE_NUM", worklist.TELEPHONE_NUM);
            ht.Add("PATIENT_SOURCE", worklist.PATIENT_SOURCE);
            ht.Add("EXAM_CLASS", worklist.EXAM_CLASS);
            ht.Add("EXAM_SUB_CLASS", worklist.EXAM_SUB_CLASS);
            ht.Add("EXAM_ITEMS", worklist.EXAM_ITEMS);
            ht.Add("EXAM_DEPT", worklist.EXAM_DEPT);
            ht.Add("EXAM_DEPT_NAME", worklist.EXAM_DEPT_NAME);
            ht.Add("EXAM_NO", worklist.EXAM_NO);
            ht.Add("ACCESSION_NO", worklist.ACCESSION_NO);
            ht.Add("EXAM_ACCESSION_NUM ", worklist.EXAM_ACCESSION_NUM);
            ht.Add("STUDY_INSTANCE_UID", worklist.STUDY_INSTANCE_UID);
            ht.Add("EXAM_DOCTOR", worklist.EXAM_DOCTOR);
            ht.Add("REPORT_DOCTOR", worklist.REPORT_DOCTOR);
            ht.Add("SCH_OPERATOR", worklist.SCH_OPERATOR);
            ht.Add("STUDY_PATH", worklist.STUDY_PATH);
            ht.Add("EXAM_MODE", worklist.EXAM_MODE);
            ht.Add("EXAM_INDEX", worklist.EXAM_INDEX);
            ht.Add("DEVICE", worklist.DEVICE);
            ht.Add("EXAM_INTRADAYSEQ_NO", worklist.EXAM_INTRADAYSEQ_NO);
            ht.Add("EXAM_GROUP", worklist.EXAM_GROUP);
            ht.Add("STUDY_DATE_TIME", worklist.STUDY_DATE_TIME);
            ht.Add("EXAM_STEP_STATUS", worklist.EXAM_STEP_STATUS);
            ht.Add("REPORT_STATUS", worklist.REPORT_STATUS);
            ht.Add("IS_CONFIRMED", worklist.IS_CONFIRMED);
            ht.Add("MATCH_STATUS", worklist.MATCH_STATUS);
            ht.Add("IS_TEMPORARY", worklist.IS_TEMPORARY);
            ht.Add("VIP_INDICATOR", worklist.VIP_INDICATOR);
            ht.Add("IMAGE_ARCHIVED", worklist.IMAGE_ARCHIVED);
            ht.Add("PRE_FETCH", worklist.PRE_FETCH);
            ht.Add("QUERY_STATUS", worklist.QUERY_STATUS);
            ht.Add("DISPATCH_STATUS", worklist.DISPATCH_STATUS);
            ht.Add("PATIENT_CLASS", worklist.PATIENT_CLASS);
            ht.Add("QUERY_TIME", worklist.QUERY_TIME);
            ht.Add("IMAGE_COUNTS", worklist.IMAGE_COUNTS);
            ht.Add("SCHEDULED_DATE", worklist.SCHEDULED_DATE);
            ht.Add("REFER_DOCTOR", worklist.REFER_DOCTOR);
            ht.Add("REFER_DEPT", worklist.REFER_DEPT);
            ht.Add("REQ_DATE_TIME", worklist.REQ_DATE_TIME);
            ht.Add("REQ_DEPT_NAME", worklist.REQ_DEPT_NAME);
            ht.Add("REQ_MEMO", worklist.REQ_MEMO);
            ht.Add("CLIN_SYMP", worklist.CLIN_SYMP);
            ht.Add("PHYS_SIGN", worklist.PHYS_SIGN);
            ht.Add("RELEVANT_LAB_TEST", worklist.RELEVANT_LAB_TEST);
            ht.Add("RELEVANT_DIAG", worklist.RELEVANT_DIAG);
            ht.Add("CLIN_DIAG", worklist.CLIN_DIAG);
            ht.Add("FACILITY", worklist.FACILITY);
            ht.Add("OUT_MED_INSTITUTION", worklist.OUT_MED_INSTITUTION);
            ht.Add("VISIT_ID", worklist.VISIT_ID);
            ht.Add("COSTS", worklist.COSTS);
            ht.Add("CHARGES", worklist.CHARGES);
            ht.Add("IS_INQUIRY", worklist.IS_INQUIRY);
            ht.Add("IS_BACK_INQ", worklist.IS_BACK_INQ);
            ht.Add("IS_ONLINE", worklist.IS_ONLINE);
            ht.Add("IS_PACKPROCESS", worklist.IS_PACKPROCESS);
            ht.Add("VOLUMN_KEY", worklist.VOLUMN_KEY);
            ht.Add("JZH", worklist.JZH);    //记账号　　add by liukun at 2010-7-13
            return ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString());
        }

        /// <summary>
        /// 查询是否存在指定的工作记录
        /// </summary>
        /// <param name="iworklist"></param>
        /// <returns></returns>
        public override bool Exists(IModel iworklist)
        {
            MWorkList worklist = (MWorkList)iworklist;
            strSql = "select EXAM_ACCESSION_NUM from " + TableName + " where EXAM_ACCESSION_NUM = '" + worklist.EXAM_ACCESSION_NUM + "'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取符合条件的工作记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 获取指定字段的工作记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList2(string where)
        {
            strSql = "select EXAM_ACCESSION_NUM,PATIENT_ID,PATIENT_AGE,PATIENT_SEX,PATIENT_NAME,EXAM_CLASS,"+
                "EXAM_SUB_CLASS,EXAM_ITEMS,REQ_DATE_TIME,REPORT_STATUS from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 获取包括报告在内的工作记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetWorkListReport(string where)
        {
            switch (GetConfig.SisOdbcMode)
            {
                case "ACCESS":
                    strSql = "select a.*," +
                   "b.EXAM_PARA,b.DESCRIPTION,b.IMPRESSION,b.RECOMMENDATION,b.DICTATOR,b.TRANSCRIBER,b.APPROVER,b.APPROVE_DATE_TIME,"+
                   "b.REPORT_DATE_TIME,b.IS_ABNORMAL,b.REPORT_TYPE,b.PRINT_COUNT,b.PRINT_TEMPLATE,b.FIELD_INF,c.AREA_NAME " +
                   "from ((" + TableName + " a left join Report b on a.EXAM_ACCESSION_NUM = b.EXAM_NO) left join area_dict c on a.BIRTH_PLACE=c.AREA_CODE) " +
                   "where " + where;
                    break;
                case "ORACLE":
                    strSql = "select a.*," +
                   "b.EXAM_PARA,b.DESCRIPTION,b.IMPRESSION,b.RECOMMENDATION,b.DICTATOR,b.TRANSCRIBER,b.APPROVER,b.APPROVE_DATE_TIME,"+
                   "b.REPORT_DATE_TIME,b.IS_ABNORMAL,b.REPORT_TYPE,b.PRINT_COUNT,b.PRINT_TEMPLATE,b.FIELD_INF,c.AREA_NAME " +
                   "from " + TableName + " a,Report b,area_dict c " +
                   "where a.BIRTH_PLACE=c.AREA_CODE(+) and a.EXAM_ACCESSION_NUM = b.EXAM_NO(+) and " + where;
                    break;
                case "SQL":
                    break;
            }      
            DataTable dt = GetDataTable(strSql);
            return dt;
        }

        /// <summary>
        /// 删除符合条件的工作记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }

        /// <summary>
        /// 获取指定检查申请号的工作记录
        /// </summary>
        /// <param name="exam_accession_num"></param>
        /// <returns></returns>
        public override IModel GetModel(string exam_accession_num)
        {
            strSql = "select * from " + TableName + " where EXAM_ACCESSION_NUM = '" + exam_accession_num + "'";
            DataSet ds = GetDataSet(strSql);
            if (ds.Tables[0].Rows.Count == 0)
                return null;
            MWorkList model = new MWorkList();
            model.EXAM_ACCESSION_NUM = ds.Tables[0].Rows[0]["EXAM_ACCESSION_NUM"].ToString();
            model.PATIENT_ID = ds.Tables[0].Rows[0]["PATIENT_ID"].ToString();
            model.PATIENT_NAME = ds.Tables[0].Rows[0]["PATIENT_NAME"].ToString();
            model.PATIENT_PHONETIC = ds.Tables[0].Rows[0]["PATIENT_PHONETIC"].ToString();
            model.PATIENT_SEX = ds.Tables[0].Rows[0]["PATIENT_SEX"].ToString();
            model.PATIENT_AGE_UNIT = ds.Tables[0].Rows[0]["PATIENT_AGE_UNIT"].ToString();
            model.PATIENT_IDENTITY = ds.Tables[0].Rows[0]["PATIENT_IDENTITY"].ToString();
            model.PATIENT_LOCAL_ID = ds.Tables[0].Rows[0]["PATIENT_LOCAL_ID"].ToString();
            model.LOCAL_ID_CLASS = ds.Tables[0].Rows[0]["LOCAL_ID_CLASS"].ToString();
            model.INP_NO = ds.Tables[0].Rows[0]["INP_NO"].ToString();
            model.BED_NUM = ds.Tables[0].Rows[0]["BED_NUM"].ToString();
            model.OPD_NO = ds.Tables[0].Rows[0]["OPD_NO"].ToString();
            model.BIRTH_PLACE = ds.Tables[0].Rows[0]["BIRTH_PLACE"].ToString();
            model.MAILING_ADDRESS = ds.Tables[0].Rows[0]["MAILING_ADDRESS"].ToString();
            model.ZIP_CODE = ds.Tables[0].Rows[0]["ZIP_CODE"].ToString();
            model.TELEPHONE_NUM = ds.Tables[0].Rows[0]["TELEPHONE_NUM"].ToString();
            model.PATIENT_SOURCE = ds.Tables[0].Rows[0]["PATIENT_SOURCE"].ToString();
            model.EXAM_CLASS = ds.Tables[0].Rows[0]["EXAM_CLASS"].ToString();
            model.EXAM_SUB_CLASS = ds.Tables[0].Rows[0]["EXAM_SUB_CLASS"].ToString();
            model.EXAM_ITEMS = ds.Tables[0].Rows[0]["EXAM_ITEMS"].ToString();
            model.EXAM_DEPT = ds.Tables[0].Rows[0]["EXAM_DEPT"].ToString();
            model.EXAM_DEPT_NAME = ds.Tables[0].Rows[0]["EXAM_DEPT_NAME"].ToString();
            model.EXAM_MODE = ds.Tables[0].Rows[0]["EXAM_MODE"].ToString();
            model.EXAM_GROUP = ds.Tables[0].Rows[0]["EXAM_GROUP"].ToString();
            model.EXAM_DOCTOR = ds.Tables[0].Rows[0]["EXAM_DOCTOR"].ToString();
            model.EXAM_NO = ds.Tables[0].Rows[0]["EXAM_NO"].ToString();
            model.STUDY_INSTANCE_UID = ds.Tables[0].Rows[0]["STUDY_INSTANCE_UID"].ToString();
            model.STUDY_PATH = ds.Tables[0].Rows[0]["STUDY_PATH"].ToString();
            model.REPORT_DOCTOR = ds.Tables[0].Rows[0]["REPORT_DOCTOR"].ToString();//
            model.DEVICE = ds.Tables[0].Rows[0]["DEVICE"].ToString();
            model.SCH_OPERATOR = ds.Tables[0].Rows[0]["SCH_OPERATOR"].ToString();//
            model.REFER_DOCTOR = ds.Tables[0].Rows[0]["REFER_DOCTOR"].ToString();
            model.REFER_DEPT = ds.Tables[0].Rows[0]["REFER_DEPT"].ToString();
            model.REQ_DEPT_NAME = ds.Tables[0].Rows[0]["REQ_DEPT_NAME"].ToString();
            model.REQ_MEMO = ds.Tables[0].Rows[0]["REQ_MEMO"].ToString();
            model.CLIN_SYMP = ds.Tables[0].Rows[0]["CLIN_SYMP"].ToString();
            model.PHYS_SIGN = ds.Tables[0].Rows[0]["PHYS_SIGN"].ToString();
            model.RELEVANT_LAB_TEST = ds.Tables[0].Rows[0]["RELEVANT_LAB_TEST"].ToString();
            model.RELEVANT_DIAG = ds.Tables[0].Rows[0]["RELEVANT_DIAG"].ToString();
            model.CLIN_DIAG = ds.Tables[0].Rows[0]["CLIN_DIAG"].ToString();
            model.FACILITY = ds.Tables[0].Rows[0]["FACILITY"].ToString();
            model.OUT_MED_INSTITUTION = ds.Tables[0].Rows[0]["OUT_MED_INSTITUTION"].ToString();//
            model.VOLUMN_KEY = ds.Tables[0].Rows[0]["VOLUMN_KEY"].ToString();//
            model.JZH = ds.Tables[0].Rows[0]["JZH"].ToString();  //记账号　　add by liukun at 2010-7-13　

            if (ds.Tables[0].Rows[0]["ACCESSION_NO"].ToString() == "")
                model.ACCESSION_NO = null;
            else
                model.ACCESSION_NO = int.Parse(ds.Tables[0].Rows[0]["ACCESSION_NO"].ToString());

            if (ds.Tables[0].Rows[0]["PATIENT_BIRTH"].ToString() == "")
                model.PATIENT_BIRTH = null;
            else
                model.PATIENT_BIRTH = DateTime.Parse(ds.Tables[0].Rows[0]["PATIENT_BIRTH"].ToString());

            if (ds.Tables[0].Rows[0]["PATIENT_AGE"].ToString() == "")
                model.PATIENT_AGE = null;
            else
                model.PATIENT_AGE = int.Parse(ds.Tables[0].Rows[0]["PATIENT_AGE"].ToString());

            if (ds.Tables[0].Rows[0]["CHARGE_TYPE"].ToString() == "")
                model.CHARGE_TYPE = null;
            else
                model.CHARGE_TYPE = int.Parse(ds.Tables[0].Rows[0]["CHARGE_TYPE"].ToString());

            if (ds.Tables[0].Rows[0]["EXAM_INDEX"].ToString() == "")
                model.EXAM_INDEX = null;
            else
                model.EXAM_INDEX = int.Parse(ds.Tables[0].Rows[0]["EXAM_INDEX"].ToString());

            if (ds.Tables[0].Rows[0]["EXAM_INTRADAYSEQ_NO"].ToString() == "")
                model.EXAM_INTRADAYSEQ_NO = null;
            else
                model.EXAM_INTRADAYSEQ_NO = decimal.Parse(ds.Tables[0].Rows[0]["EXAM_INTRADAYSEQ_NO"].ToString());

            if (ds.Tables[0].Rows[0]["STUDY_DATE_TIME"].ToString() == "")
                model.STUDY_DATE_TIME = null;
            else
                model.STUDY_DATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["STUDY_DATE_TIME"].ToString());

            if (ds.Tables[0].Rows[0]["EXAM_STEP_STATUS"].ToString() == "")
                model.EXAM_STEP_STATUS = null;
            else
                model.EXAM_STEP_STATUS = int.Parse(ds.Tables[0].Rows[0]["EXAM_STEP_STATUS"].ToString());

            if (ds.Tables[0].Rows[0]["REPORT_STATUS"].ToString() == "")
                model.REPORT_STATUS = null;
            else
                model.REPORT_STATUS = int.Parse(ds.Tables[0].Rows[0]["REPORT_STATUS"].ToString());

            if (ds.Tables[0].Rows[0]["IS_CONFIRMED"].ToString() == "")
                model.IS_CONFIRMED = null;
            else
                model.IS_CONFIRMED = int.Parse(ds.Tables[0].Rows[0]["IS_CONFIRMED"].ToString());

            if (ds.Tables[0].Rows[0]["MATCH_STATUS"].ToString() == "")
                model.MATCH_STATUS = null;
            else
                model.MATCH_STATUS = int.Parse(ds.Tables[0].Rows[0]["MATCH_STATUS"].ToString());

            if (ds.Tables[0].Rows[0]["IS_TEMPORARY"].ToString() == "")
                model.IS_TEMPORARY = null;
            else
                model.IS_TEMPORARY = int.Parse(ds.Tables[0].Rows[0]["IS_TEMPORARY"].ToString());

            if (ds.Tables[0].Rows[0]["VIP_INDICATOR"].ToString() == "")
                model.VIP_INDICATOR = null;
            else
                model.VIP_INDICATOR = int.Parse(ds.Tables[0].Rows[0]["VIP_INDICATOR"].ToString());

            if (ds.Tables[0].Rows[0]["IMAGE_ARCHIVED"].ToString() == "")
                model.IMAGE_ARCHIVED = null;
            else
                model.IMAGE_ARCHIVED = int.Parse(ds.Tables[0].Rows[0]["IMAGE_ARCHIVED"].ToString());

            if (ds.Tables[0].Rows[0]["PRE_FETCH"].ToString() == "")
                model.PRE_FETCH = null;
            else
                model.PRE_FETCH = int.Parse(ds.Tables[0].Rows[0]["PRE_FETCH"].ToString());

            if (ds.Tables[0].Rows[0]["DISPATCH_STATUS"].ToString() == "")
                model.DISPATCH_STATUS = null;
            else
                model.DISPATCH_STATUS = int.Parse(ds.Tables[0].Rows[0]["DISPATCH_STATUS"].ToString());

            if (ds.Tables[0].Rows[0]["QUERY_STATUS"].ToString() == "")
                model.QUERY_STATUS = null;
            else
                model.QUERY_STATUS = int.Parse(ds.Tables[0].Rows[0]["QUERY_STATUS"].ToString());

            if (ds.Tables[0].Rows[0]["QUERY_TIME"].ToString() == "")
                model.QUERY_TIME = null;
            else
                model.QUERY_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["QUERY_TIME"].ToString());

            if (ds.Tables[0].Rows[0]["PATIENT_CLASS"].ToString() == "")
                model.PATIENT_CLASS = null;
            else
                model.PATIENT_CLASS = int.Parse(ds.Tables[0].Rows[0]["PATIENT_CLASS"].ToString());

            if (ds.Tables[0].Rows[0]["IMAGE_COUNTS"].ToString() == "")
                model.IMAGE_COUNTS = null;
            else
                model.IMAGE_COUNTS = int.Parse(ds.Tables[0].Rows[0]["IMAGE_COUNTS"].ToString());

            if (ds.Tables[0].Rows[0]["SCHEDULED_DATE"].ToString() == "")
                model.SCHEDULED_DATE = null;
            else
                model.SCHEDULED_DATE = DateTime.Parse(ds.Tables[0].Rows[0]["SCHEDULED_DATE"].ToString());

            if (ds.Tables[0].Rows[0]["REQ_DATE_TIME"].ToString() == "")
                model.REQ_DATE_TIME = null;
            else
                model.REQ_DATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["REQ_DATE_TIME"].ToString());

            if (ds.Tables[0].Rows[0]["COSTS"].ToString() == "")
                model.COSTS = null;
            else
                model.COSTS = decimal.Parse(ds.Tables[0].Rows[0]["COSTS"].ToString());

            if (ds.Tables[0].Rows[0]["CHARGES"].ToString() == "")
                model.CHARGES = null;
            else
                model.CHARGES = decimal.Parse(ds.Tables[0].Rows[0]["CHARGES"].ToString());

            if (ds.Tables[0].Rows[0]["IS_INQUIRY"].ToString() == "")
                model.IS_INQUIRY = null;
            else
                model.IS_INQUIRY = int.Parse(ds.Tables[0].Rows[0]["IS_INQUIRY"].ToString());

            if (ds.Tables[0].Rows[0]["IS_BACK_INQ"].ToString() == "")
                model.IS_BACK_INQ = null;
            else
                model.IS_BACK_INQ = int.Parse(ds.Tables[0].Rows[0]["IS_BACK_INQ"].ToString());

            if (ds.Tables[0].Rows[0]["VISIT_ID"].ToString() == "")
                model.VISIT_ID = null;
            else
                model.VISIT_ID = int.Parse(ds.Tables[0].Rows[0]["VISIT_ID"].ToString());

            if (ds.Tables[0].Rows[0]["IS_ONLINE"].ToString() == "")
                model.IS_ONLINE = null;
            else
                model.IS_ONLINE = int.Parse(ds.Tables[0].Rows[0]["IS_ONLINE"].ToString());

            if (ds.Tables[0].Rows[0]["IS_PACKPROCESS"].ToString() == "")
                model.IS_PACKPROCESS = null;
            else
                model.IS_PACKPROCESS = int.Parse(ds.Tables[0].Rows[0]["IS_PACKPROCESS"].ToString());

            return model;
        }
    }
}