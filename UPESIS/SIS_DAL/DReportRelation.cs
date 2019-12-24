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
    /// 对 REPORT_RELATION，报告一体化
    /// </summary>
    public class DReportRelation : IReportRelation
    {
        private string strSql;
        private string TableName = "REPORT_RELATION";
        public DReportRelation()
            : base(GetConfig.GetSisConnStr())
        {
        }

        /// <summary>
        /// 插入一条报告一体化记录
        /// </summary>
        /// <param name="ireportRelation"></param>
        /// <returns></returns>
        public override int Add(IModel ireportRelation)
        {
            MReportRelation reportRelation = (MReportRelation)ireportRelation;
            Hashtable ht = new Hashtable();
            ht.Add("EXAM_ACCESSION_NUM", reportRelation.EXAM_ACCESSION_NUM);
            ht.Add("EXAM_ACCESSION_NUM_EX", reportRelation.EXAM_ACCESSION_NUM_EX);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 查询是否存在指定的报告一体化记录
        /// </summary>
        /// <param name="ireportRelation"></param>
        /// <returns></returns>
        public override bool Exists(IModel ireportRelation)
        {
            MReportRelation reportRelation = (MReportRelation)ireportRelation;
            strSql = "select * from " + TableName + " where EXAM_ACCESSION_NUM='" + reportRelation.EXAM_ACCESSION_NUM + "' and " +
                     "EXAM_ACCESSION_NUM_EX = '" + reportRelation.EXAM_ACCESSION_NUM_EX + "'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取符合条件的报告一体化记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定的报告一体化记录
        /// </summary>
        /// <param name="ireportRelation"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel ireportRelation, string where)
        {
            MReportRelation reportRelation = (MReportRelation)ireportRelation;
            Hashtable ht = new Hashtable();
            ht.Add("EXAM_ACCESSION_NUM", reportRelation.EXAM_ACCESSION_NUM);
            ht.Add("EXAM_ACCESSION_NUM_EX", reportRelation.EXAM_ACCESSION_NUM_EX);
            return (ExecuteSql(StringConstructor.UpdateSql(TableName, ht,where).ToString()));
        }

        /// <summary>
        /// 删除符合条件的报告一体化记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}