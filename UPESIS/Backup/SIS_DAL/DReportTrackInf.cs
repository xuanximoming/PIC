using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Collections;
using SIS_Model;
using ILL;

namespace SIS_DAL
{
    /// <summary>
    /// 对REPORT_TRACK_INF，报告轨迹信息表
    /// </summary>
    public class DReportTrackInf : IReportTrackInf
    {
        private string strSql;
        private string TableName = "REPORT_TRACK_INF";
        public DReportTrackInf()
            : base(GetConfig.GetSisConnStr())
        {
        }

        /// <summary>
        /// 插入一条报告轨迹记录
        /// </summary>
        /// <param name="ireportTrackInf"></param>
        /// <returns></returns>
        public override int Add(IModel ireportTrackInf)
        {
            MReportTrackInf reportTrackInf = (MReportTrackInf)ireportTrackInf;
            Hashtable ht = new Hashtable();
            ht.Add("EXAM_ACCESSION_NUM", reportTrackInf.EXAM_ACCESSION_NUM);
            ht.Add("REPORT_MODIFY_TIME", reportTrackInf.REPORT_MODIFY_TIME);
            ht.Add("EXAM_PARA", reportTrackInf.EXAM_PARA);
            ht.Add("DESCRIPTION", reportTrackInf.DESCRIPTION);
            ht.Add("IMPRESSION", reportTrackInf.IMPRESSION);
            ht.Add("RECOMMENDATION", reportTrackInf.RECOMMENDATION);
            ht.Add("DICTATOR", reportTrackInf.DICTATOR);
            ht.Add("TRANSCRIBER", reportTrackInf.TRANSCRIBER);
            ht.Add("APPROVER", reportTrackInf.APPROVER);
            ht.Add("AFFIRMANT", reportTrackInf.AFFIRMANT);
            ht.Add("OPERATOR", reportTrackInf.OPERATOR);
            ht.Add("IS_ABNORMAL", reportTrackInf.IS_ABNORMAL);
            ht.Add("REPORT_TYPE", reportTrackInf.REPORT_TYPE);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 获取符合条件的报告轨迹记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定的报告轨迹记录
        /// </summary>
        /// <param name="ireportTrackInf"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel ireportTrackInf, string where)
        {
            MReportTrackInf reportTrackInf = (MReportTrackInf)ireportTrackInf;
            Hashtable ht = new Hashtable();
            ht.Add("EXAM_ACCESSION_NUM", reportTrackInf.EXAM_ACCESSION_NUM);
            ht.Add("REPORT_MODIFY_TIME", reportTrackInf.REPORT_MODIFY_TIME);
            ht.Add("EXAM_PARA", reportTrackInf.EXAM_PARA);
            ht.Add("DESCRIPTION", reportTrackInf.DESCRIPTION);
            ht.Add("IMPRESSION", reportTrackInf.IMPRESSION);
            ht.Add("RECOMMENDATION", reportTrackInf.RECOMMENDATION);
            ht.Add("DICTATOR", reportTrackInf.DICTATOR);
            ht.Add("TRANSCRIBER", reportTrackInf.TRANSCRIBER);
            ht.Add("APPROVER", reportTrackInf.APPROVER);
            ht.Add("AFFIRMANT", reportTrackInf.AFFIRMANT);
            ht.Add("OPERATOR", reportTrackInf.OPERATOR);
            ht.Add("IS_ABNORMAL", reportTrackInf.IS_ABNORMAL);
            ht.Add("REPORT_TYPE", reportTrackInf.REPORT_TYPE);
            return (ExecuteSql(StringConstructor.UpdateSql(TableName, ht,where).ToString()));
        }

        /// <summary>
        /// 删除符合条件的报告轨迹记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}