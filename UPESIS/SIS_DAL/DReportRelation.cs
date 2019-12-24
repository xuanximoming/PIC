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
    /// �� REPORT_RELATION������һ�廯
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
        /// ����һ������һ�廯��¼
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
        /// ��ѯ�Ƿ����ָ���ı���һ�廯��¼
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
        /// ��ȡ���������ı���һ�廯��¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// ����ָ���ı���һ�廯��¼
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
        /// ɾ�����������ı���һ�廯��¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}