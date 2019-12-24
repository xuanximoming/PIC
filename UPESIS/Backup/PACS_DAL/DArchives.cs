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
    /// 对表PATIENT_INF，即病人信息表相关操作
    /// </summary>
    public class DArchives : IArchives
    {
        private string strSql;
        private string TableName = "PATIENT_INF";
        public DArchives()
            : base(GetConfig.GetPacsConnStr())
        {
        }

        /// <summary>
        /// 插入一条新病人纪录
        /// </summary>
        /// <param name="ipatientInf"></param>
        /// <returns></returns>
        public override int Add(IModel ipatientInf)
        {
            MArchives patientInf = (MArchives)ipatientInf;
            Hashtable ht = new Hashtable();
            ht.Add("BIRTH_PLACE", patientInf.BIRTH_PLACE);
            ht.Add("HABITATION", patientInf.HABITATION);
            ht.Add("IDENTITY_CARD_NO", patientInf.IDENTITY_CARD_NO);
            ht.Add("INP_NO", patientInf.INP_NO);
            ht.Add("MAILING_ADDRESS", patientInf.MAILING_ADDRESS);
            ht.Add("NATIVE_PLACE", patientInf.NATIVE_PLACE);
            ht.Add("OPD_NO", patientInf.OPD_NO);
            ht.Add("PATIENT_BIRTH", patientInf.PATIENT_BIRTH);
            ht.Add("PATIENT_CLASS", patientInf.PATIENT_CLASS);
            ht.Add("PATIENT_ENGLISH_NAME", patientInf.PATIENT_ENGLISH_NAME);
            ht.Add("PATIENT_ID", patientInf.PATIENT_ID);
            ht.Add("PATIENT_NAME", patientInf.PATIENT_NAME);
            ht.Add("PATIENT_SEX", patientInf.PATIENT_SEX);
            ht.Add("TELEPHONE_NUMBER", patientInf.TELEPHONE_NUMBER);
            ht.Add("VISIT_TIMES", patientInf.VISIT_TIMES);
            ht.Add("ZIP_CODE", patientInf.ZIP_CODE);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 查询是否存在某个病人记录
        /// </summary>
        /// <param name="ipatientInf"></param>
        /// <returns></returns>
        public override bool Exists(IModel ipatientInf)
        {
            MArchives patientInf = (MArchives)ipatientInf;
            strSql = "select * from " + TableName + " where PATIENT_ID='" + patientInf.PATIENT_ID + "'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取特定ID的病人记录，返回的是Patient_inf的Model实体
        /// </summary>
        /// <param name="PATIENT_ID"></param>
        /// <returns></returns>
        public override IModel GetModel(string PATIENT_ID)
        {
            strSql = "select * from " + TableName + " where PATIENT_ID ='" + PATIENT_ID + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MArchives patientInf = new MArchives();
            patientInf.BIRTH_PLACE = dt.Rows[0]["BIRTH_PLACE"].ToString();
            patientInf.HABITATION = dt.Rows[0]["HABITATION"].ToString();
            patientInf.IDENTITY_CARD_NO = dt.Rows[0]["IDENTITY_CARD_NO"].ToString();
            patientInf.INP_NO = dt.Rows[0]["INP_NO"].ToString();
            patientInf.MAILING_ADDRESS = dt.Rows[0]["MAILING_ADDRESS"].ToString();
            patientInf.NATIVE_PLACE = dt.Rows[0]["NATIVE_PLACE"].ToString();
            patientInf.OPD_NO = dt.Rows[0]["OPD_NO"].ToString();
            patientInf.PATIENT_ENGLISH_NAME = dt.Rows[0]["PATIENT_ENGLISH_NAME"].ToString();
            patientInf.PATIENT_ID = dt.Rows[0]["PATIENT_ID"].ToString();
            patientInf.PATIENT_NAME = dt.Rows[0]["PATIENT_NAME"].ToString();
            patientInf.PATIENT_SEX = dt.Rows[0]["PATIENT_SEX"].ToString();
            patientInf.TELEPHONE_NUMBER = dt.Rows[0]["TELEPHONE_NUMBER"].ToString();
            patientInf.ZIP_CODE = dt.Rows[0]["ZIP_CODE"].ToString();

            if (dt.Rows[0]["VISIT_TIMES"].ToString() == "")
                patientInf.VISIT_TIMES = null;
            else
                patientInf.VISIT_TIMES = Convert.ToInt32(dt.Rows[0]["VISIT_TIMES"].ToString());

            if (dt.Rows[0]["PATIENT_BIRTH"].ToString() == "")
                patientInf.PATIENT_BIRTH = null;
            else
                patientInf.PATIENT_BIRTH = Convert.ToDateTime(dt.Rows[0]["PATIENT_BIRTH"].ToString());

            return patientInf;
        }

        /// <summary>
        /// 获取病人列表记录，返回DataTable数据表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定病人记录
        /// </summary>
        /// <param name="ipatientInf"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel ipatientInf, string where)
        {
            MArchives patientInf = (MArchives)ipatientInf;
            Hashtable ht = new Hashtable();
            ht.Add("BIRTH_PLACE", patientInf.BIRTH_PLACE);
            ht.Add("HABITATION", patientInf.HABITATION);
            ht.Add("IDENTITY_CARD_NO", patientInf.IDENTITY_CARD_NO);
            ht.Add("INP_NO", patientInf.INP_NO);
            ht.Add("MAILING_ADDRESS", patientInf.MAILING_ADDRESS);
            ht.Add("NATIVE_PLACE", patientInf.NATIVE_PLACE);
            ht.Add("OPD_NO", patientInf.OPD_NO);
            ht.Add("PATIENT_BIRTH", patientInf.PATIENT_BIRTH);
            ht.Add("PATIENT_CLASS", patientInf.PATIENT_CLASS);
            ht.Add("PATIENT_ENGLISH_NAME", patientInf.PATIENT_ENGLISH_NAME);
            ht.Add("PATIENT_ID", patientInf.PATIENT_ID);
            ht.Add("PATIENT_NAME", patientInf.PATIENT_NAME);
            ht.Add("PATIENT_SEX", patientInf.PATIENT_SEX);
            ht.Add("TELEPHONE_NUMBER", patientInf.TELEPHONE_NUMBER);
            ht.Add("VISIT_TIMES", patientInf.VISIT_TIMES);
            ht.Add("ZIP_CODE", patientInf.ZIP_CODE);
            return (ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString()));
        }
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}
