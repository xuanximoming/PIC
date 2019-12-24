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
    /// 对INTEREST_PATIENT，感兴趣病人表
    /// </summary>
    public class DInterestPatient :IInterestPatient
    {
        private string strSql;
        private string TableName = "INTEREST_PATIENT";
        public DInterestPatient()
            : base(GetConfig.GetSisConnStr())
        {
        }

        /// <summary>
        /// 插入一条感兴趣病人记录
        /// </summary>
        /// <param name="iinterestPatient"></param>
        /// <returns></returns>
        public override int Add(IModel iinterestPatient)
        {
            MInterestPatient interestPatient=(MInterestPatient)iinterestPatient;
            Hashtable ht = new Hashtable();
            ht.Add("NOTE_ID", interestPatient. NOTE_ID);
            ht.Add("NOTE_NAME", interestPatient.NOTE_NAME);
            ht.Add("PARENT_NOTE_ID", interestPatient.PARENT_NOTE_ID);
            ht.Add("IS_NOTE", interestPatient.IS_NOTE);
            ht.Add("DOCTOR_ID", interestPatient.DOCTOR_ID);
            ht.Add("PATIENT_ID", interestPatient.PATIENT_ID);
            ht.Add("EXAM_ACCESSION_NUM", interestPatient.EXAM_ACCESSION_NUM);
            ht.Add("MEMO", interestPatient.MEMO);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 查询是否存在指定的感兴趣病人记录
        /// </summary>
        /// <param name="iinterestPatient"></param>
        /// <returns></returns>
        public override bool Exists(IModel iinterestPatient)
        {
            MInterestPatient interestPatient = (MInterestPatient)iinterestPatient;
            strSql = "select * from " + TableName + " where NOTE_ID=" + interestPatient.NOTE_ID;
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取指定的NOTE_ID的记录
        /// </summary>
        /// <param name="NOTE_ID"></param>
        /// <returns></returns>
        public override IModel GetModel(string NOTE_ID)
        {
            strSql = "select * from " + TableName + " where NOTE_ID = " + NOTE_ID;
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MInterestPatient interestPatient = new MInterestPatient();
            interestPatient.NOTE_ID = Convert.ToInt32(dt.Rows[0]["NOTE_ID"].ToString());
            interestPatient.NOTE_NAME = dt.Rows[0]["NOTE_NAME"].ToString();

            if (dt.Rows[0]["PARENT_NOTE_ID"].ToString() == "")
                interestPatient.PARENT_NOTE_ID = null;
            else
                interestPatient.PARENT_NOTE_ID = Convert.ToInt32(dt.Rows[0]["PARENT_NOTE_ID"].ToString());

            if (dt.Rows[0]["IS_NOTE"].ToString() == "")
                interestPatient.IS_NOTE = null;
            else
                interestPatient.IS_NOTE = Convert.ToInt32(dt.Rows[0]["IS_NOTE"].ToString());

            interestPatient.DOCTOR_ID = dt.Rows[0]["DOCTOR_ID"].ToString();
            interestPatient.PATIENT_ID = dt.Rows[0]["PATIENT_ID"].ToString();

            interestPatient.EXAM_ACCESSION_NUM = dt.Rows[0]["EXAM_ACCESSION_NUM"].ToString();
            interestPatient.MEMO = dt.Rows[0]["MEMO"].ToString();
            return interestPatient;
        }

        /// <summary>
        /// 获取符合条件的记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 获取符合条件的记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList2(string where)
        {
            strSql = "select * from " + TableName + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定的病人记录
        /// </summary>
        /// <param name="iinterestPatient"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel iinterestPatient, string where)
        {
            MInterestPatient interestPatient = (MInterestPatient)iinterestPatient;
            Hashtable ht = new Hashtable();
            ht.Add("NOTE_ID", interestPatient.NOTE_ID);
            ht.Add("NOTE_NAME", interestPatient.NOTE_NAME);
            ht.Add("PARENT_NOTE_ID", interestPatient.PARENT_NOTE_ID);
            ht.Add("IS_NOTE", interestPatient.IS_NOTE);
            ht.Add("DOCTOR_ID", interestPatient.DOCTOR_ID);
            ht.Add("PATIENT_ID", interestPatient.PATIENT_ID);
            ht.Add("EXAM_ACCESSION_NUM", interestPatient.EXAM_ACCESSION_NUM);
            ht.Add("MEMO", interestPatient.MEMO);
            return ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString());
        }

        /// <summary>
        /// 删除符合条件的病人记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}