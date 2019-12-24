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
    /// 对PATIENT_INF_LOCAL_ID，病人信息与检查号对照
    /// </summary>
    public class DPatientInfLocalId : IPatientInfLocalId
    {
        private string strSql;
        private string TableName = "PATIENT_INF_LOCAL_ID";
        public DPatientInfLocalId()
            : base(GetConfig.GetSisConnStr())
        {
        }

        /// <summary>
        /// 插入一条病人信息与本地ID对照记录
        /// </summary>
        /// <param name="ipatientInfLocalId"></param>
        /// <returns></returns>
        public override int Add(IModel ipatientInfLocalId)
        {
            MPatientInfLocalId patientInfLocalId = (MPatientInfLocalId)ipatientInfLocalId;
            Hashtable ht = new Hashtable();
            ht.Add("PATIENT_ID", patientInfLocalId.PATIENT_ID);
            ht.Add("LOCAL_ID_CLASS", patientInfLocalId.LOCAL_ID_CLASS);
            ht.Add("PATIENT_LOCAL_ID", patientInfLocalId.PATIENT_LOCAL_ID);
            ht.Add("EXAM_TIMES", patientInfLocalId.EXAM_TIMES);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 查询是否存在指定ID的记录
        /// </summary>
        /// <param name="ipatientInfLocalId"></param>
        /// <returns></returns>
        public override bool Exists(IModel ipatientInfLocalId)
        {
            MPatientInfLocalId patientInfLocalId = (MPatientInfLocalId)ipatientInfLocalId;
            strSql = "select * from " + TableName + " where PATIENT_ID='" + patientInfLocalId.PATIENT_ID + "' and " +
                     "LOCAL_ID_CLASS = '" + patientInfLocalId.LOCAL_ID_CLASS + "'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取指定病人ID、本地ID类别的对照记录
        /// </summary>
        /// <param name="PATIENT_ID"></param>
        /// <param name="LOCAL_ID_CLASS"></param>
        /// <returns></returns>
        public override IModel GetModel(string PATIENT_ID, string LOCAL_ID_CLASS)
        {
            strSql = "select * from " + TableName + " where PATIENT_ID = '" + PATIENT_ID + "' and LOCAL_ID_CLASS = '" + LOCAL_ID_CLASS + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MPatientInfLocalId mPatientInfLocalId = new MPatientInfLocalId();
            mPatientInfLocalId.PATIENT_ID = dt.Rows[0]["PATIENT_ID"].ToString();
            mPatientInfLocalId.PATIENT_LOCAL_ID = dt.Rows[0]["PATIENT_LOCAL_ID"].ToString();
            mPatientInfLocalId.LOCAL_ID_CLASS = dt.Rows[0]["LOCAL_ID_CLASS"].ToString();
            if (dt.Rows[0]["EXAM_TIMES"].ToString() == "")
                mPatientInfLocalId.EXAM_TIMES = null;
            else
                mPatientInfLocalId.EXAM_TIMES = Convert.ToInt32(dt.Rows[0]["EXAM_TIMES"].ToString());
            return mPatientInfLocalId;
        }

        /// <summary>
        /// 获取符合条件的对照记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定的记录
        /// </summary>
        /// <param name="ipatientInfLocalId"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel ipatientInfLocalId, string where)
        {
            MPatientInfLocalId patientInfLocalId = (MPatientInfLocalId)ipatientInfLocalId;
            Hashtable ht = new Hashtable();
            ht.Add("PATIENT_ID", patientInfLocalId.PATIENT_ID);
            ht.Add("LOCAL_ID_CLASS", patientInfLocalId.LOCAL_ID_CLASS);
            ht.Add("PATIENT_LOCAL_ID", patientInfLocalId.PATIENT_LOCAL_ID);
            ht.Add("EXAM_TIMES", patientInfLocalId.EXAM_TIMES);
            return (ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString()));
        }

        /// <summary>
        /// 删除符合条件的记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}