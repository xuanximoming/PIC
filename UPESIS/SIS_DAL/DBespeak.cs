using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Collections;

using ILL;
using SIS_Model;

namespace SIS_DAL
{
    /// <summary>
    /// 对Bespeak,预约病人表
    /// </summary>
    public class DBespeak : IBespeak
    {
        private string strSql;
        private string TableName = "Bespeak";
        public DBespeak()
            : base(GetConfig.GetSisConnStr())
        {
        }

        /// <summary>
        /// 插入一条预约记录
        /// </summary>
        /// <param name="ibespeak"></param>
        /// <returns></returns>
        public override int Add(IModel ibespeak)
        {
            MBespeak bespeak = (MBespeak)ibespeak;
            Hashtable ht = new Hashtable();
            ht.Add("BESPEAK_ID", bespeak.BESPEAK_ID);
            ht.Add("PATIENT_ID", bespeak.PATIENT_ID);
            ht.Add("PATIENT_NAME", bespeak.PATIENT_NAME);
            ht.Add("PATIENT_SEX", bespeak.PATIENT_SEX);
            ht.Add("PATIENT_AGE", bespeak.PATIENT_AGE);
            ht.Add("PATIENT_AGE_UNIT", bespeak.PATIENT_AGE_UNIT);
            ht.Add("IS_MARRIAGE", bespeak.IS_MARRIAGE);
            ht.Add("PATIENT_SOURCE", bespeak.PATIENT_SOURCE);
            ht.Add("INP_NO", bespeak.INP_NO);
            ht.Add("BED_NO", bespeak.BED_NO);
            ht.Add("CHARGES", bespeak.CHARGES);
            ht.Add("CHARGE_CLASS", bespeak.CHARGE_CLASS);
            ht.Add("REG_DOCTOR", bespeak.REG_DOCTOR);
            ht.Add("QUEUE_NO", bespeak.QUEUE_NO);
            ht.Add("BESPEAK_TIME", bespeak.BESPEAK_TIME);
            ht.Add("EXAM_PART", bespeak.EXAM_PART);
            ht.Add("EXAM_CLASS", bespeak.EXAM_CLASS);
            ht.Add("PREGNANCY", bespeak.PREGNANCY);
            ht.Add("REQ_DEPT", bespeak.REQ_DEPT);
            ht.Add("REQ_DOCTOR", bespeak.REQ_DOCTOR);
            ht.Add("RELATION", bespeak.RELATION);
            ht.Add("CLINC_DIAG", bespeak.CLINIC_DIAG);
            ht.Add("INSURANCE_NO", bespeak.INSURANCE_NO);
            ht.Add("LAST_CATAMENIA", bespeak.LAST_CATAMENIA);
            ht.Add("FLAG", bespeak.FLAG);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 查询是否存在指定的预约记录
        /// </summary>
        /// <param name="ibespeak"></param>
        /// <returns></returns>
        public override bool Exists(IModel ibespeak)
        {
            MBespeak bespeak = (MBespeak)ibespeak;
            strSql = "select BESPEAK_ID from " + TableName + " where BESPEAK_ID = " + bespeak.BESPEAK_ID;
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取指定预约ID的预约记录
        /// </summary>
        /// <param name="BESPEAK_ID"></param>
        /// <returns></returns>
        public override IModel GetModel(string BESPEAK_ID)
        {
            strSql = "select * from " + TableName + " where BESPEAK_ID = " + BESPEAK_ID;
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MBespeak bespeak = new MBespeak();

            if (dt.Rows[0]["BESPEAK_ID"].ToString() == "")
                bespeak.BESPEAK_ID = null;
            else
                bespeak.BESPEAK_ID = Convert.ToInt32(dt.Rows[0]["BESPEAK_ID"].ToString());

            bespeak.PATIENT_ID = dt.Rows[0]["PATIENT_ID"].ToString();
            bespeak.PATIENT_NAME = dt.Rows[0]["PATIENT_NAME"].ToString();
            bespeak.PATIENT_SEX = dt.Rows[0]["PATIENT_SEX"].ToString();

            if (dt.Rows[0]["PATIENT_AGE"].ToString() == "")
                bespeak.PATIENT_AGE = null;
            else
                bespeak.PATIENT_AGE = Convert.ToInt32(dt.Rows[0]["PATIENT_AGE"].ToString());

            bespeak.PATIENT_AGE_UNIT = dt.Rows[0]["PATIENT_AGE_UNIT"].ToString();
            bespeak.IS_MARRIAGE = dt.Rows[0]["IS_MARRIAGE"].ToString();
            bespeak.PATIENT_SOURCE = dt.Rows[0]["PATIENT_SOURCE"].ToString();
            bespeak.INP_NO = dt.Rows[0]["INP_NO"].ToString();
            bespeak.BED_NO = dt.Rows[0]["BED_NO"].ToString();

            if (dt.Rows[0]["CHARGES"].ToString() == "")
                bespeak.CHARGES = null;
            else
                bespeak.CHARGES = Convert.ToDecimal(dt.Rows[0]["CHARGES"].ToString());
            bespeak.CHARGE_CLASS = dt.Rows[0]["CHARGE_CLASS"].ToString();

            bespeak.REG_DOCTOR = dt.Rows[0]["REG_DOCTOR"].ToString();

            if (dt.Rows[0]["QUEUE_NO"].ToString() == "")
                bespeak.QUEUE_NO = null;
            else
                bespeak.QUEUE_NO = Convert.ToInt32(dt.Rows[0]["QUEUE_NO"].ToString());

            if (dt.Rows[0]["BESPEAK_TIME"].ToString() == "")
                bespeak.BESPEAK_TIME = null;
            else
                bespeak.BESPEAK_TIME = Convert.ToDateTime(dt.Rows[0]["BESPEAK_TIME"].ToString());

            bespeak.EXAM_PART = dt.Rows[0]["EXAM_PART"].ToString();
            bespeak.EXAM_CLASS = dt.Rows[0]["EXAM_CLASS"].ToString();

            if (dt.Rows[0]["PREGNANCY"].ToString() == "")
                bespeak.PREGNANCY = null;
            else
                bespeak.PREGNANCY = Convert.ToInt32(dt.Rows[0]["PREGNANCY"].ToString());

            bespeak.REQ_DEPT = dt.Rows[0]["REQ_DEPT"].ToString();
            bespeak.REQ_DOCTOR = dt.Rows[0]["REQ_DOCTOR"].ToString();
            bespeak.RELATION = dt.Rows[0]["RELATION"].ToString();
            bespeak.CLINIC_DIAG = dt.Rows[0]["CLINC_DIAG"].ToString();
            bespeak.INSURANCE_NO = dt.Rows[0]["INSURANCE_NO"].ToString();

            if (dt.Rows[0]["LAST_CATAMENIA"].ToString() == "")
                bespeak.LAST_CATAMENIA = null;
            else
                bespeak.LAST_CATAMENIA = Convert.ToDateTime(dt.Rows[0]["LAST_CATAMENIA"].ToString());

            if (dt.Rows[0]["FLAG"].ToString() == "")
                bespeak.FLAG = null;
            else
                bespeak.FLAG = Convert.ToInt32(dt.Rows[0]["FLAG"].ToString());

            return bespeak;
        }

        /// <summary>
        /// 获取符合条件的预约列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定预约记录
        /// </summary>
        /// <param name="ibespeak"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel ibespeak, string where)
        {
            MBespeak bespeak = (MBespeak)ibespeak;
            Hashtable ht = new Hashtable();
            ht.Add("BESPEAK_ID", bespeak.BESPEAK_ID);
            ht.Add("PATIENT_ID", bespeak.PATIENT_ID);
            ht.Add("PATIENT_NAME", bespeak.PATIENT_NAME);
            ht.Add("PATIENT_SEX", bespeak.PATIENT_SEX);
            ht.Add("PATIENT_AGE", bespeak.PATIENT_AGE);
            ht.Add("PATIENT_AGE_UNIT", bespeak.PATIENT_AGE_UNIT);
            ht.Add("IS_MARRIAGE", bespeak.IS_MARRIAGE);
            ht.Add("PATIENT_SOURCE", bespeak.PATIENT_SOURCE);
            ht.Add("INP_NO", bespeak.INP_NO);
            ht.Add("BED_NO", bespeak.BED_NO);
            ht.Add("CHARGES", bespeak.CHARGES);
            ht.Add("CHARGE_CLASS", bespeak.CHARGE_CLASS);
            ht.Add("REG_DOCTOR", bespeak.REG_DOCTOR);
            ht.Add("QUEUE_NO", bespeak.QUEUE_NO);
            ht.Add("BESPEAK_TIME", bespeak.BESPEAK_TIME);
            ht.Add("EXAM_PART", bespeak.EXAM_PART);
            ht.Add("EXAM_CLASS", bespeak.EXAM_CLASS);
            ht.Add("PREGNANCY", bespeak.PREGNANCY);
            ht.Add("REQ_DEPT", bespeak.REQ_DEPT);
            ht.Add("REQ_DOCTOR", bespeak.REQ_DOCTOR);
            ht.Add("RELATION", bespeak.RELATION);
            ht.Add("CLINC_DIAG", bespeak.CLINIC_DIAG);
            ht.Add("INSURANCE_NO", bespeak.INSURANCE_NO);
            ht.Add("LAST_CATAMENIA", bespeak.LAST_CATAMENIA);
            ht.Add("FLAG", bespeak.FLAG);
            return (ExecuteSql(StringConstructor.UpdateSql(TableName, ht,where).ToString()));
        }

        /// <summary>
        /// 删除符合条件的预约记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}