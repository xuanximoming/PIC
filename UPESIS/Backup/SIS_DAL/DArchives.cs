using System;
using System.Collections.Generic;
using System.Text;
using SIS_Model;
using System.Data;
using System.Collections;
using ILL;

namespace SIS_DAL
{
    /// <summary>
    /// 对ARCHIVES，即SIS的病人档案表
    /// </summary>
    public class DArchives : IArchives
    {
        private string strSql;
        private string TableName = "ARCHIVES", TableName_Sub = "ARCHIVES_SUB";
        public DArchives()
            : base(GetConfig.GetSisConnStr())
        {
        }

        /// <summary>
        /// 插入一条病人档案记录
        /// </summary>
        /// <param name="iarchives"></param>
        /// <returns></returns>
        public override int Add(IModel iarchives)
        {
            MArchives archives = (MArchives)iarchives;
            Hashtable ht = new Hashtable();
            ht.Add("PATIENT_ID", archives.PATIENT_ID);
            ht.Add("PATIENT_NAME", archives.PATIENT_NAME);
            ht.Add("PATIENT_SEX", archives.PATIENT_SEX);
            ht.Add("PATIENT_AGE", archives.PATIENT_AGE);
            ht.Add("PATIENT_AGE_UNIT", archives.PATIENT_AGE_UNIT);
            ht.Add("PATIENT_BIRTH", archives.PATIENT_BIRTH);
            ht.Add("TELEPHONE_NUM", archives.TELEPHONE_NUM);
            ht.Add("IDENTITY_CARD_NO", archives.IDENTITY_CARD_NO);
            ht.Add("NATIVE_PLACE", archives.NATIVE_PLACE);
            ht.Add("BIRTH_PLACE", archives.BIRTH_PLACE);
            ht.Add("HABITATION", archives.HABITATION);
            ht.Add("MAILING_ADDRESS", archives.MAILING_ADDRESS);
            ht.Add("ZIP_CODE", archives.ZIP_CODE);
            ht.Add("INSURANCE_NO", archives.INSURANCE_NO);
            ht.Add("BESPEAK_TIME", archives.BESPEAK_TIME);
            ht.Add("CHARGE_CLASS", archives.CHARGE_CLASS);
            ht.Add("INP_NO", archives.INP_NO);
            ht.Add("OPD_NO", archives.OPD_NO);
            ht.Add("PATIENT_IDENTITY", archives.PATIENT_IDENTITY);
            int i=ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString());
            ht = new Hashtable();
            ht.Add("PATIENT_ID", archives.PATIENT_ID);
            ht.Add("A1", archives.A1);
            ht.Add("A2", archives.A2);
            ht.Add("A3", archives.A3);
            ht.Add("A4", archives.A4);
            i += ExecuteSql(StringConstructor.InsertSql(TableName_Sub, ht).ToString());
            return i;
        }

        /// <summary>
        /// 查询是否存在指定的档案记录
        /// </summary>
        /// <param name="iarchives"></param>
        /// <returns></returns>
        public override bool Exists(IModel iarchives)
        {
            MArchives archives = (MArchives)iarchives;
            strSql = "select PATIENT_ID from " + TableName + " where PATIENT_ID = '" + archives.PATIENT_ID + "'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取符合条件的档案记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where 1=1 " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 获取指定病人ID的档案记录
        /// </summary>
        /// <param name="PATIENT_ID"></param>
        /// <returns></returns>
        public override IModel GetModel(string PATIENT_ID)
        {
            strSql = "select * from " + TableName + " where PATIENT_ID = '" + PATIENT_ID +"'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MArchives archives = new MArchives();
            archives.PATIENT_ID = dt.Rows[0]["PATIENT_ID"].ToString();
            archives.PATIENT_NAME = dt.Rows[0]["PATIENT_NAME"].ToString();
            archives.PATIENT_SEX = dt.Rows[0]["PATIENT_SEX"].ToString();
            archives.PATIENT_AGE_UNIT = dt.Rows[0]["PATIENT_AGE_UNIT"].ToString();
            archives.BIRTH_PLACE = dt.Rows[0]["BIRTH_PLACE"].ToString();
            archives.HABITATION = dt.Rows[0]["HABITATION"].ToString();
            archives.IDENTITY_CARD_NO = dt.Rows[0]["IDENTITY_CARD_NO"].ToString();
            archives.INSURANCE_NO = dt.Rows[0]["INSURANCE_NO"].ToString();
            archives.MAILING_ADDRESS = dt.Rows[0]["MAILING_ADDRESS"].ToString();
            archives.NATIVE_PLACE = dt.Rows[0]["NATIVE_PLACE"].ToString();
            archives.TELEPHONE_NUM = dt.Rows[0]["TELEPHONE_NUM"].ToString();
            archives.ZIP_CODE = dt.Rows[0]["ZIP_CODE"].ToString();
            archives.INP_NO = dt.Rows[0]["INP_NO"].ToString();
            archives.OPD_NO = dt.Rows[0]["OPD_NO"].ToString();
            archives.PATIENT_IDENTITY = dt.Rows[0]["PATIENT_IDENTITY"].ToString();

            if (dt.Rows[0]["PATIENT_AGE"].ToString() == "")
                archives.PATIENT_AGE = null;
            else
                archives.PATIENT_AGE = Convert.ToInt32(dt.Rows[0]["PATIENT_AGE"].ToString());

            if (dt.Rows[0]["PATIENT_BIRTH"].ToString() == "")
                archives.PATIENT_BIRTH = null;
            else
                archives.PATIENT_BIRTH = Convert.ToDateTime(dt.Rows[0]["PATIENT_BIRTH"].ToString());

            if (dt.Rows[0]["CHARGE_CLASS"].ToString() == "")
                archives.CHARGE_CLASS = null;
            else
                archives.CHARGE_CLASS = Convert.ToInt32(dt.Rows[0]["CHARGE_CLASS"].ToString());

            if (dt.Rows[0]["BESPEAK_TIME"].ToString() == "")
                archives.BESPEAK_TIME = null;
            else
                archives.BESPEAK_TIME = Convert.ToDateTime(dt.Rows[0]["BESPEAK_TIME"].ToString());

            strSql = "select * from " + TableName_Sub + " where PATIENT_ID = '" + PATIENT_ID + "'";
            dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return archives;
            archives.A1 = dt.Rows[0]["A1"].ToString();
            archives.A4 = dt.Rows[0]["A4"].ToString();

            if (dt.Rows[0]["A2"].ToString() == "")
                archives.A2 = null;
            else
                archives.A2 = Convert.ToInt32(dt.Rows[0]["A2"].ToString());

            if (dt.Rows[0]["A3"].ToString() == "")
                archives.A3 = null;
            else
                archives.A3 = Convert.ToInt32(dt.Rows[0]["A3"].ToString());

            return archives;
        }

        /// <summary>
        /// 更新指定的档案记录
        /// </summary>
        /// <param name="iarchives"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel iarchives, string where)
        {
            MArchives archives = (MArchives)iarchives;
            Hashtable ht = new Hashtable();
            ht.Add("PATIENT_ID", archives.PATIENT_ID);
            ht.Add("PATIENT_NAME", archives.PATIENT_NAME);
            ht.Add("PATIENT_SEX", archives.PATIENT_SEX);
            ht.Add("PATIENT_AGE", archives.PATIENT_AGE);
            ht.Add("PATIENT_AGE_UNIT", archives.PATIENT_AGE_UNIT);
            ht.Add("PATIENT_BIRTH", archives.PATIENT_BIRTH);
            ht.Add("TELEPHONE_NUM", archives.TELEPHONE_NUM);
            ht.Add("IDENTITY_CARD_NO", archives.IDENTITY_CARD_NO);
            ht.Add("NATIVE_PLACE", archives.NATIVE_PLACE);
            ht.Add("BIRTH_PLACE", archives.BIRTH_PLACE);
            ht.Add("HABITATION", archives.HABITATION);
            ht.Add("MAILING_ADDRESS", archives.MAILING_ADDRESS);
            ht.Add("ZIP_CODE", archives.ZIP_CODE);
            ht.Add("INSURANCE_NO", archives.INSURANCE_NO);
            ht.Add("BESPEAK_TIME", archives.BESPEAK_TIME);
            ht.Add("CHARGE_CLASS", archives.CHARGE_CLASS);
            ht.Add("INP_NO", archives.INP_NO);
            ht.Add("OPD_NO", archives.OPD_NO);
            ht.Add("PATIENT_IDENTITY", archives.PATIENT_IDENTITY);
            int i = ExecuteSql(StringConstructor.UpdateSql(TableName, ht,where).ToString());
            ht = new Hashtable();
            ht.Add("PATIENT_ID", archives.PATIENT_ID);
            ht.Add("A1", archives.A1);
            ht.Add("A2", archives.A2);
            ht.Add("A3", archives.A3);
            ht.Add("A4", archives.A4);
            i += ExecuteSql(StringConstructor.UpdateSql(TableName_Sub, ht, where).ToString());
            return i;
        }

        /// <summary>
        /// 删除符合条件的档案记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}