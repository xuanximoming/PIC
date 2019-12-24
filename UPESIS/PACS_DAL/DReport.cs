using System;
using System.Collections.Generic;
using System.Text;
using PACS_Model;
using System.Data;
using System.Collections;
using ILL;

namespace PACS_DAL
{
    /// <summary>
    /// 操作REPORT,即检查报告表
    /// </summary>
    public class DReport :IReport
    {
        private string strSql;
        private string TableName = "REPORT";
        public DReport()
            : base(GetConfig.GetPacsConnStr())
        {
        }
        

        /// <summary>
        /// 插入一条报告记录
        /// </summary>
        /// <param name="ireport"></param>
        /// <returns></returns>
        public override int Add(IModel ireport)
        {
            MReport report = (MReport)ireport;
            Hashtable ht = new Hashtable();
            ht.Add("EXAM_ACCESSION_NUM", report.EXAM_NO);
            ht.Add("EXAM_PARA", report.EXAM_PARA);
            ht.Add("DESCRIPTION", report.DESCRIPTION);
            ht.Add("IMPRESSION", report.IMPRESSION);
            ht.Add("RECOMMENDATION", report.RECOMMENDATION);
            ht.Add("DICTATOR", report.DICTATOR);
            ht.Add("TRANSCRIBER", report.TRANSCRIBER);
            ht.Add("APPROVER", report.APPROVER);
            ht.Add("APPROVE_DATE_TIME", report.APPROVE_DATE_TIME);
            ht.Add("REPORT_DATE_TIME", report.REPORT_DATE_TIME);
            ht.Add("AFFIRMANT", report.AFFIRMANT);
            ht.Add("AFFIRM_DATE_TIME", report.AFFIRM_DATE_TIME);
            ht.Add("IS_ABNORMAL", report.IS_ABNORMAL);
            ht.Add("REPORT_TYPE", report.REPORT_TYPE);
            ht.Add("PRINT_TEMPLATE", report.PRINT_TEMPLATE);
            ht.Add("PRINT_COUNT", report.PRINT_COUNT);
            ht.Add("REPORT_NAME", report.REPORT_NAME);
            ht.Add("FIELD_INF", report.FIELD_INF);
            int i = ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString(),ht);
            return i;

        }

        /// <summary>
        /// 查询是否存在指定的报告记录
        /// </summary>
        /// <param name="ireport"></param>
        /// <returns></returns>
        public override bool Exists(IModel ireport)
        {
            MReport report = (MReport)ireport;
            strSql = "select * from " + TableName + " where EXAM_ACCESSION_NUM='" + report.EXAM_NO + "'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取指定检查申请号的报告记录
        /// </summary>
        /// <param name="EXAM_NO"></param>
        /// <returns></returns>
        public override IModel GetModel(string EXAM_NO)
        {
            strSql = "select * from " + TableName + " where EXAM_NO = '" + EXAM_NO + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MReport report = new MReport();

            report.EXAM_NO = dt.Rows[0]["EXAM_NO"].ToString();
            report.EXAM_PARA = dt.Rows[0]["EXAM_PARA"].ToString();
            report.DESCRIPTION = dt.Rows[0]["DESCRIPTION"].ToString();
            report.IMPRESSION = dt.Rows[0]["IMPRESSION"].ToString();
            report.RECOMMENDATION = dt.Rows[0]["RECOMMENDATION"].ToString();
            report.DICTATOR = dt.Rows[0]["DICTATOR"].ToString();
            report.TRANSCRIBER = dt.Rows[0]["TRANSCRIBER"].ToString();

            if (dt.Rows[0]["IS_ABNORMAL"].ToString() == "")
                report.IS_ABNORMAL = null;
            else
                report.IS_ABNORMAL = Convert.ToInt32(dt.Rows[0]["IS_ABNORMAL"].ToString());

            if (dt.Rows[0]["REPORT_TYPE"].ToString() == "")
                report.REPORT_TYPE = null;
            else
                report.REPORT_TYPE = Convert.ToInt32(dt.Rows[0]["REPORT_TYPE"].ToString());

            if (dt.Rows[0]["PRINT_COUNT"].ToString() == "")
                report.PRINT_COUNT = null;
            else
                report.PRINT_COUNT = Convert.ToInt32(dt.Rows[0]["PRINT_COUNT"].ToString());

            if (dt.Rows[0]["APPROVE_DATE_TIME"].ToString() == "")
                report.APPROVE_DATE_TIME = null;
            else
                report.APPROVE_DATE_TIME = Convert.ToDateTime(dt.Rows[0]["APPROVE_DATE_TIME"].ToString());

            if (dt.Rows[0]["REPORT_DATE_TIME"].ToString() == "")
                report.REPORT_DATE_TIME = null;
            else
                report.REPORT_DATE_TIME = Convert.ToDateTime(dt.Rows[0]["REPORT_DATE_TIME"].ToString());

            if (dt.Rows[0]["AFFIRM_DATE_TIME"].ToString() == "")
                report.AFFIRM_DATE_TIME = null;
            else
                report.AFFIRM_DATE_TIME = Convert.ToDateTime(dt.Rows[0]["AFFIRM_DATE_TIME"].ToString());

            report.APPROVER = dt.Rows[0]["APPROVER"].ToString();
            report.AFFIRMANT = dt.Rows[0]["AFFIRMANT"].ToString();
            report.PRINT_TEMPLATE = dt.Rows[0]["PRINT_TEMPLATE"].ToString();
            report.REPORT_NAME = (byte[])(dt.Rows[0]["REPORT_NAME"]);
            report.FIELD_INF = dt.Rows[0]["FIELD_INF"].ToString(); 
            return report;
        }

        /// <summary>
        /// 获取符合条件的报告列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where ;
            return GetDataTable(strSql);
           
        }

        /// <summary>
        /// 更新指定报告记录
        /// </summary>
        /// <param name="ireport"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel ireport, string where)
        {
            MReport report = (MReport)ireport;
            Hashtable ht = new Hashtable();
            ht.Add("EXAM_ACCESSION_NUM", report.EXAM_NO);
            ht.Add("EXAM_PARA", report.EXAM_PARA);
            ht.Add("DESCRIPTION", report.DESCRIPTION);
            ht.Add("IMPRESSION", report.IMPRESSION);
            ht.Add("RECOMMENDATION", report.RECOMMENDATION);
            ht.Add("DICTATOR", report.DICTATOR);
            ht.Add("TRANSCRIBER", report.TRANSCRIBER);
            ht.Add("APPROVER", report.APPROVER);
            ht.Add("APPROVE_DATE_TIME", report.APPROVE_DATE_TIME);
            ht.Add("REPORT_DATE_TIME", report.REPORT_DATE_TIME);
            ht.Add("AFFIRMANT", report.AFFIRMANT);
            ht.Add("AFFIRM_DATE_TIME", report.AFFIRM_DATE_TIME);
            ht.Add("IS_ABNORMAL", report.IS_ABNORMAL);
            ht.Add("REPORT_TYPE", report.REPORT_TYPE);
            ht.Add("PRINT_TEMPLATE", report.PRINT_TEMPLATE);
            ht.Add("PRINT_COUNT", report.PRINT_COUNT);
            ht.Add("REPORT_NAME", report.REPORT_NAME);
            ht.Add("FIELD_INF", report.FIELD_INF);
            int i = ExecuteSql(StringConstructor.UpdateSql(TableName, ht,where).ToString(),ht);
            return i;
        }

        /// <summary>
        /// 批量更新符合条件的报告记录
        /// </summary>
        /// <param name="where"></param>
        /// <param name="dt_Report"></param>
        /// <param name="sda"></param>
        /// <returns></returns>
        public override int UpdateTable(string where,System.Data.DataTable dt_Report, System.Data.Odbc.OdbcDataAdapter sda)
        {
            string sql = "select * from " + TableName + where + "'";
            return UpdateDataTable(sql, dt_Report, sda);
        }

        /// <summary>
        /// 删除符合条件的报告记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}