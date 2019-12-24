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
    /// ��PATIENT_SOURCE��������Դ��
    /// </summary>
    public class DPatientSource :IPatientSource
    {
        private string strSql;
        private string TableName = "PATIENT_SOURCE";
        public DPatientSource()
            : base(GetConfig.GetSisConnStr())
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
        /// �������벡����Դ��¼
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int AddMore(Hashtable ht2)
        {
            MPatientSource patientSource = new MPatientSource();
            Hashtable ht = new Hashtable();
            Hashtable htstr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    patientSource = (MPatientSource)ht2[i];
                    ht.Add("PATIENT_SOURCE_ID", patientSource.PATIENT_SOURCE_ID);
                    ht.Add("PATIENT_SOURCE", patientSource.PATIENT_SOURCE);
                    htstr.Add(i, StringConstructor.InsertSql(TableName, ht).ToString());
                }
                return ExecuteNonSql(htstr);

            }
            else
                return 0;
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
        /// ��ȡָ��ID�Ĳ�����Դ��¼
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
        /// �������²�����Դ��¼
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int UpdateMore(Hashtable ht2)
        {
            MPatientSource patientSource = new MPatientSource();
            Hashtable htStr = new Hashtable();
            Hashtable ht = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    patientSource = (MPatientSource)ht2[i];
                    ht.Add(" PATIENT_SOURCE_ID", patientSource.PATIENT_SOURCE_ID);
                    ht.Add("PATIENT_SOURCE", patientSource.PATIENT_SOURCE);
                    htStr.Add(i, StringConstructor.UpdateSql(TableName, ht, " where PATIENT_SOURCE_ID=" + Convert.ToInt32( patientSource.PATIENT_SOURCE_ID)));
                }

                return ExecuteNonSql(htStr);
            }
            return 0;
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