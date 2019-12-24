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
    /// ����PATIENT_SOURCE_DICT����������Դ�ֵ�
    /// </summary>
    public class DPatientSource :IPatientSource
    {
        private string strSql;
        private string TableName = "PATIENT_SOURCE_DICT";
        public DPatientSource()
            : base(GetConfig.GetPacsConnStr())
        {
        }

        /// <summary>
        /// ����һ��������Դ��¼
        /// </summary>
        /// <param name="ipatientSource"></param>
        /// <returns></returns>
        public override int Add(IModel ipatientSource)
        {
            MPatientSource patientSource = (MPatientSource)ipatientSource;
            Hashtable ht = new Hashtable();
            ht.Add(" PATIENT_SOURCE_ID", patientSource.PATIENT_SOURCE_ID);
            ht.Add("PATIENT_SOURCE", patientSource.PATIENT_SOURCE);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// ��ѯ�Ƿ����ָ���Ĳ�����Դ��¼
        /// </summary>
        /// <param name="ipatientSource"></param>
        /// <returns></returns>
        public override bool Exists(IModel ipatientSource)
        {
            MPatientSource patientSource = (MPatientSource)ipatientSource;
            strSql = "select * from " + TableName + " where PATIENT_SOURCE_ID=" + patientSource.PATIENT_SOURCE_ID;
            return recordIsExist(strSql);
        }

        /// <summary>
        /// ��ȡָ��������ԴID�ļ�¼
        /// </summary>
        /// <param name="PATIENT_SOURCE_ID"></param>
        /// <returns></returns>
        public override IModel GetModel(string PATIENT_SOURCE_ID)
        {
            strSql = "select * from " + TableName + " where PATIENT_SOURCE_ID = " + PATIENT_SOURCE_ID;
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MPatientSource patientSource = new MPatientSource();
            patientSource.PATIENT_SOURCE_ID = Convert.ToInt32(dt.Rows[0]["PATIENT_SOURCE_ID"].ToString());
            patientSource.PATIENT_SOURCE = dt.Rows[0]["PATIENT_SOURCE"].ToString();
            return patientSource;
        }

        /// <summary>
        /// ��ȡ���������Ĳ�����Դ�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// ����ָ���Ĳ�����Դ��¼
        /// </summary>
        /// <param name="ipatientSource"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel ipatientSource, string where)
        {
            MPatientSource patientSource = (MPatientSource)ipatientSource;
            Hashtable ht = new Hashtable();
            ht.Add(" PATIENT_SOURCE_ID", patientSource.PATIENT_SOURCE_ID);
            ht.Add("PATIENT_SOURCE", patientSource.PATIENT_SOURCE);
            return ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString());
        }

        /// <summary>
        /// ɾ�����������Ĳ�����Դ��¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}
