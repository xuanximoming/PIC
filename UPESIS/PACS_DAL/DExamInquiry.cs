using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Collections;
using PACS_Model;
using ILL;

namespace PACS_DAL
{
    /// <summary>
    /// 操作EXAM_INQUIRY，即检查随访记录表
    /// </summary>
    public class DExamInquiry : IExamInquiry
    {
        private string strSql;
        private string TableName = "EXAM_INQUIRY";
        public DExamInquiry()
            : base(GetConfig.GetSisConnStr())
        {
        }

        /// <summary>
        /// 插入一条随访记录
        /// </summary>
        /// <param name="imodel"></param>
        /// <returns></returns>
        public override int Add(IModel imodel)
        {
            MExamInquiry model = (MExamInquiry)imodel;
            Hashtable ht = new Hashtable();
            ht.Add("EXAM_ACCESSION_NUM", model.EXAM_ACCESSION_NUM);
            ht.Add("PATIENT_ID", model.PATIENT_ID);
            ht.Add("PATIENT_NAME", model.PATIENT_NAME);
            ht.Add("PATIENT_SEX", model.PATIENT_SEX);
            ht.Add("PATIENT_AGE", model.PATIENT_AGE);
            ht.Add("PATIENT_AGE_UNIT", model.PATIENT_AGE_UNIT);
            ht.Add("INP_NO", model.INP_NO);
            ht.Add("VISIT_ID", model.VISIT_ID);
            ht.Add("OPER_ID", model.OPER_ID);
            ht.Add("REQ_DEPT_NAME", model.REQ_DEPT_NAME);
            ht.Add("EXAM_DEPT_NAME", model.EXAM_DEPT_NAME);
            ht.Add("EXAM_CLASS", model.EXAM_CLASS);
            ht.Add("EXAM_SUB_CLASS", model.EXAM_SUB_CLASS);
            ht.Add("PATIENT_LOCAL_ID", model.PATIENT_LOCAL_ID);
            ht.Add("PATH_NO", model.PATH_NO);
            ht.Add("CLIN_DATA", model.CLIN_DATA);
            ht.Add("DESCRIPTION", model.DESCRIPTION);
            ht.Add("IMPRESSION", model.IMPRESSION);
            ht.Add("APPROVER", model.APPROVER);
            ht.Add("TRANSCRIBER", model.TRANSCRIBER);
            ht.Add("OPER_DEPT_NAME", model.OPER_DEPT_NAME);
            ht.Add("SURGEON", model.SURGEON);
            ht.Add("OPER_DATE", model.OPER_DATE);
            ht.Add("OPER_NAME", model.OPER_NAME);
            ht.Add("OPER_DESCRIPTION", model.OPER_DESCRIPTION);
            ht.Add("OPER_DIAGNOSIS", model.OPER_DIAGNOSIS);
            ht.Add("PATH_DIAGNOSIS", model.PATH_DIAG_DOCTOR);
            ht.Add("PATH_DIAG_DOCTOR", model.PATH_DIAG_DOCTOR);
            ht.Add("QUALITATIVE", model.QUALITATIVE);
            ht.Add("PITCH", model.PITCH);
            ht.Add("INQU_DOCTOR", model.INQU_DOCTOR);
            ht.Add("INQU_DATE_TIME", model.INQU_DATE_TIME);
            ht.Add("INQU_DEPT_CODE", model.INQU_DEPT_CODE);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 查询是否存在指定的随访记录
        /// </summary>
        /// <param name="imodel"></param>
        /// <returns></returns>
        public override bool Exists(IModel imodel)
        {
            MExamInquiry model = (MExamInquiry)imodel;
            strSql = "select * from " + TableName + " where EXAM_ACCESSION_NUM='"+model.EXAM_ACCESSION_NUM+"'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取指定检查申请号的随访记录
        /// </summary>
        /// <param name="ExamAccessionNum"></param>
        /// <returns></returns>
        public override IModel GetModel(string ExamAccessionNum)
        {
            strSql = "select * from " + TableName + " where EXAM_ACCESSION_NUM='" + ExamAccessionNum + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MExamInquiry model = new MExamInquiry();
            model.EXAM_ACCESSION_NUM = dt.Rows[0]["EXAM_ACCESSION_NUM"].ToString();
            model.PATIENT_ID = dt.Rows[0]["PATIENT_ID"].ToString();
            model.PATIENT_NAME = dt.Rows[0]["PATIENT_NAME"].ToString();
            model.PATIENT_SEX = dt.Rows[0]["PATIENT_SEX"].ToString();
            if (dt.Rows[0]["PATIENT_AGE"].ToString() == "")
                model.PATIENT_AGE = null;
            else
                model.PATIENT_AGE =Convert.ToInt32(dt.Rows[0]["PATIENT_AGE"].ToString());
            model.PATIENT_AGE_UNIT = dt.Rows[0]["PATIENT_AGE_UNIT"].ToString();
            model.INP_NO = dt.Rows[0]["INP_NO"].ToString();
            if (dt.Rows[0]["VISIT_ID"].ToString() == "")
                model.VISIT_ID = null;
            else
                model.VISIT_ID =Convert.ToInt32(dt.Rows[0]["VISIT_ID"].ToString());
            if (dt.Rows[0]["OPER_ID"].ToString() == "")
                model.OPER_ID = null;
            else
                model.OPER_ID =Convert.ToInt32(dt.Rows[0]["OPER_ID"].ToString());
            model.REQ_DEPT_NAME = dt.Rows[0]["REQ_DEPT_NAME"].ToString();
            model.EXAM_DEPT_NAME = dt.Rows[0]["EXAM_DEPT_NAME"].ToString();
            model.EXAM_CLASS = dt.Rows[0]["EXAM_CLASS"].ToString();
            model.EXAM_SUB_CLASS = dt.Rows[0]["EXAM_SUB_CLASS"].ToString();
            model.PATIENT_LOCAL_ID = dt.Rows[0]["PATIENT_LOCAL_ID"].ToString();
            model.PATH_NO = dt.Rows[0]["PATH_NO"].ToString();
            model.CLIN_DATA = dt.Rows[0]["CLIN_DATA"].ToString();
            model.DESCRIPTION = dt.Rows[0]["DESCRIPTION"].ToString();
            model.IMPRESSION = dt.Rows[0]["IMPRESSION"].ToString();
            model.APPROVER = dt.Rows[0]["APPROVER"].ToString();
            model.TRANSCRIBER = dt.Rows[0]["TRANSCRIBER"].ToString();
            model.OPER_DEPT_NAME = dt.Rows[0]["OPER_DEPT_NAME"].ToString();
            model.SURGEON = dt.Rows[0]["SURGEON"].ToString();
            if (dt.Rows[0]["OPER_DATE"].ToString() == "")
                model.OPER_DATE = null;
            else
                model.OPER_DATE =Convert.ToDateTime(dt.Rows[0]["OPER_DATE"].ToString());
            model.OPER_NAME = dt.Rows[0]["OPER_NAME"].ToString();
            model.OPER_DESCRIPTION = dt.Rows[0]["OPER_DESCRIPTION"].ToString();
            model.OPER_DIAGNOSIS = dt.Rows[0]["OPER_DIAGNOSIS"].ToString();
            model.PATH_DIAGNOSIS = dt.Rows[0]["PATH_DIAGNOSIS"].ToString();
            model.PATH_DIAG_DOCTOR = dt.Rows[0]["PATH_DIAG_DOCTOR"].ToString();
            if (dt.Rows[0]["QUALITATIVE"].ToString() == "")
                model.QUALITATIVE = null;
            else
                model.QUALITATIVE = Convert.ToInt32(dt.Rows[0]["QUALITATIVE"].ToString());
            if (dt.Rows[0]["PITCH"].ToString() == "")
                model.PITCH = null;
            else
                model.PITCH =Convert.ToInt32(dt.Rows[0]["PITCH"].ToString());
            model.INQU_DOCTOR = dt.Rows[0]["INQU_DOCTOR"].ToString();
            model.INQU_DEPT_CODE = dt.Rows[0]["INQU_DEPT_CODE"].ToString();
            if (dt.Rows[0]["INQU_DATE_TIME"].ToString() == "")
                model.INQU_DATE_TIME = null;
            else
                model.INQU_DATE_TIME =Convert.ToDateTime(dt.Rows[0]["INQU_DATE_TIME"].ToString());
            return model;
        }

        /// <summary>
        /// 获取符合条件的随访记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定的随访记录
        /// </summary>
        /// <param name="iimage"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel iimage, string where)
        {
            MExamInquiry model = (MExamInquiry)iimage;
            Hashtable ht = new Hashtable();
            ht.Add("EXAM_ACCESSION_NUM", model.EXAM_ACCESSION_NUM);
            ht.Add("PATIENT_ID", model.PATIENT_ID);
            ht.Add("PATIENT_NAME", model.PATIENT_NAME);
            ht.Add("PATIENT_SEX", model.PATIENT_SEX);
            ht.Add("PATIENT_AGE", model.PATIENT_AGE);
            ht.Add("PATIENT_AGE_UNIT", model.PATIENT_AGE_UNIT);
            ht.Add("INP_NO", model.INP_NO);
            ht.Add("VISIT_ID", model.VISIT_ID);
            ht.Add("OPER_ID", model.OPER_ID);
            ht.Add("REQ_DEPT_NAME", model.REQ_DEPT_NAME);
            ht.Add("EXAM_DEPT_NAME", model.EXAM_DEPT_NAME);
            ht.Add("EXAM_CLASS", model.EXAM_CLASS);
            ht.Add("EXAM_SUB_CLASS", model.EXAM_SUB_CLASS);
            ht.Add("PATIENT_LOCAL_ID", model.PATIENT_LOCAL_ID);
            ht.Add("PATH_NO", model.PATH_NO);
            ht.Add("CLIN_DATA", model.CLIN_DATA);
            ht.Add("DESCRIPTION", model.DESCRIPTION);
            ht.Add("IMPRESSION", model.IMPRESSION);
            ht.Add("APPROVER", model.APPROVER);
            ht.Add("TRANSCRIBER", model.TRANSCRIBER);
            ht.Add("OPER_DEPT_NAME", model.OPER_DEPT_NAME);
            ht.Add("SURGEON", model.SURGEON);
            ht.Add("OPER_DATE", model.OPER_DATE);
            ht.Add("OPER_NAME", model.OPER_NAME);
            ht.Add("OPER_DESCRIPTION", model.OPER_DESCRIPTION);
            ht.Add("OPER_DIAGNOSIS", model.OPER_DIAGNOSIS);
            ht.Add("PATH_DIAGNOSIS", model.PATH_DIAG_DOCTOR);
            ht.Add("PATH_DIAG_DOCTOR", model.PATH_DIAG_DOCTOR);
            ht.Add("QUALITATIVE", model.QUALITATIVE);
            ht.Add("PITCH", model.PITCH);
            ht.Add("INQU_DOCTOR", model.INQU_DOCTOR);
            ht.Add("INQU_DATE_TIME", model.INQU_DATE_TIME);
            ht.Add("INQU_DEPT_CODE", model.INQU_DEPT_CODE);
            return ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString());
        }

        /// <summary>
        /// 删除符合条件的随访记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}
