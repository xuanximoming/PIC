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
    /// 对CLINIC_OFFICE_DICT，临床科室字典
    /// </summary>
    public class DClinicOfficeDict : IClinicOfficeDict
    {
        private string strSql;
        private string TableName = "CLINIC_OFFICE_DICT";
        public DClinicOfficeDict()
            : base(GetConfig.GetSisConnStr())
        {
        }
        
        /// <summary>
        /// 插入一条临床科室记录
        /// </summary>
        /// <param name="iclinicOfficeDept"></param>
        /// <returns></returns>
        public override int Add(IModel iclinicOfficeDept)
        {
            MClinicOfficeDict clinicOfficeDept=(MClinicOfficeDict)iclinicOfficeDept;
            Hashtable ht = new Hashtable();
            ht.Add("CLINC_OFFICE_ID", clinicOfficeDept.CLINIC_OFFICE_ID);
            ht.Add("CLINC_OFFICE", clinicOfficeDept.CLINIC_OFFICE);
            ht.Add("PATIENT_SOURCE_ID", clinicOfficeDept.PATIENT_SOURCE_ID);
            ht.Add("CLINIC_OFFICE_CODE", clinicOfficeDept.CLINIC_OFFICE_CODE);
            ht.Add("CLINIC_OFFICE_FLAG", clinicOfficeDept.CLINIC_OFFICE_FLAG);
            ht.Add("CUR_SERIAL_NUM", clinicOfficeDept.CUR_SERIAL_NUM);
            ht.Add("STUDY_UID_HEADER", clinicOfficeDept.STUDY_UID_HEADER);
            ht.Add("CLINIC_OFFICE_PYCODE", clinicOfficeDept.CLINIC_OFFICE_PYCODE);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 批量插入临床科室记录
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int AddMore(Hashtable ht2)
        {
            MClinicOfficeDict MOfficeDict = new MClinicOfficeDict();
            Hashtable ht = new Hashtable();
            Hashtable htstr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    MOfficeDict = (MClinicOfficeDict)ht2[i];
                    ht.Add("CLINIC_OFFICE_ID", MOfficeDict.CLINIC_OFFICE_ID);
                    ht.Add("CLINIC_OFFICE", MOfficeDict.CLINIC_OFFICE);
                    ht.Add("PATIENT_SOURCE_ID", MOfficeDict.PATIENT_SOURCE_ID);
                    ht.Add("CLINIC_OFFICE_CODE", MOfficeDict.CLINIC_OFFICE_CODE);
                    ht.Add("CLINIC_OFFICE_FLAG", MOfficeDict.CLINIC_OFFICE_FLAG);
                    ht.Add("CUR_SERIAL_NUM", MOfficeDict.CUR_SERIAL_NUM);
                    ht.Add("STUDY_UID_HEADER", MOfficeDict.STUDY_UID_HEADER);
                    ht.Add("CLINIC_OFFICE_PYCODE", MOfficeDict.CLINIC_OFFICE_PYCODE);
                    htstr.Add(i, StringConstructor.InsertSql(TableName, ht).ToString());
                }
                return ExecuteNonSql(htstr);

            }
            else
                return 0;
        }

        /// <summary>
        /// 查询是否存在指定的临床科室记录
        /// </summary>
        /// <param name="iclinicOfficeDept"></param>
        /// <returns></returns>
        public override bool Exists(IModel iclinicOfficeDept)
        {
            MClinicOfficeDict clinicOfficeDict = (MClinicOfficeDict)iclinicOfficeDept;
            strSql = "select * from " + TableName + " where CLINC_OFFICE_ID=" + clinicOfficeDict.CLINIC_OFFICE_ID;
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取指定临床科室ID的临床科室记录
        /// </summary>
        /// <param name="CLINC_OFFICE_ID"></param>
        /// <returns></returns>
        public override IModel GetModel2(string CLINC_OFFICE_ID)
        {
            strSql = "select * from " + TableName + " where CLINC_OFFICE_ID = " + CLINC_OFFICE_ID;
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MClinicOfficeDict clinicOfficeDict = new MClinicOfficeDict();
            clinicOfficeDict.CLINIC_OFFICE_ID = Convert.ToInt32(dt.Rows[0]["CLINC_OFFICE_ID"].ToString());
            clinicOfficeDict.CLINIC_OFFICE = dt.Rows[0]["CLINC_OFFICE"].ToString();
            clinicOfficeDict.CLINIC_OFFICE_FLAG = dt.Rows[0]["CLINIC_OFFICE_FLAG"].ToString();
            clinicOfficeDict.STUDY_UID_HEADER = dt.Rows[0]["STUDY_UID_HEADER"].ToString();
            clinicOfficeDict.CLINIC_OFFICE_PYCODE = dt.Rows[0]["CLINIC_OFFICE_PYCODE"].ToString();

            if (dt.Rows[0]["PATIENT_SOURCE_ID"].ToString() == "")
                clinicOfficeDict.PATIENT_SOURCE_ID = null;
            else
                clinicOfficeDict.PATIENT_SOURCE_ID = Convert.ToInt32(dt.Rows[0]["PATIENT_SOURCE_ID"].ToString());

            if (dt.Rows[0]["CUR_SERIAL_NUM"].ToString() == "")
                clinicOfficeDict.CUR_SERIAL_NUM = null;
            else
                clinicOfficeDict.CUR_SERIAL_NUM = Convert.ToInt32(dt.Rows[0]["CUR_SERIAL_NUM"].ToString());

            clinicOfficeDict.CLINIC_OFFICE_CODE = dt.Rows[0]["CLINIC_OFFICE_CODE"].ToString();
            return clinicOfficeDict;
        }

        /// <summary>
        /// 获取指定临床科室代码的临床科室记录
        /// </summary>
        /// <param name="ClinicOfficeCode"></param>
        /// <returns></returns>
        public override IModel GetModel(string ClinicOfficeCode)
        {
            strSql = "select * from " + TableName + " where CLINIC_OFFICE_CODE = '" + ClinicOfficeCode + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MClinicOfficeDict clinicOfficeDict = new MClinicOfficeDict();
            clinicOfficeDict.CLINIC_OFFICE_ID = Convert.ToInt32(dt.Rows[0]["CLINIC_OFFICE_ID"].ToString());
            clinicOfficeDict.CLINIC_OFFICE = dt.Rows[0]["CLINIC_OFFICE"].ToString();
            clinicOfficeDict.CLINIC_OFFICE_FLAG = dt.Rows[0]["CLINIC_OFFICE_FLAG"].ToString();
            clinicOfficeDict.STUDY_UID_HEADER = dt.Rows[0]["STUDY_UID_HEADER"].ToString();
            clinicOfficeDict.CLINIC_OFFICE_PYCODE = dt.Rows[0]["CLINIC_OFFICE_PYCODE"].ToString();

            if (dt.Rows[0]["PATIENT_SOURCE_ID"].ToString() == "")
                clinicOfficeDict.PATIENT_SOURCE_ID = null;
            else
                clinicOfficeDict.PATIENT_SOURCE_ID = Convert.ToInt32(dt.Rows[0]["PATIENT_SOURCE_ID"].ToString());

            if (dt.Rows[0]["CUR_SERIAL_NUM"].ToString() == "")
                clinicOfficeDict.CUR_SERIAL_NUM = null;
            else
                clinicOfficeDict.CUR_SERIAL_NUM = Convert.ToInt32(dt.Rows[0]["CUR_SERIAL_NUM"].ToString());

            clinicOfficeDict.CLINIC_OFFICE_CODE = dt.Rows[0]["CLINIC_OFFICE_CODE"].ToString();
            return clinicOfficeDict;
        }

        /// <summary>
        /// 获取符合条件的临床科室列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定的临床科室记录
        /// </summary>
        /// <param name="iclinicOfficeDict"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel iclinicOfficeDict, string where)
        {
            MClinicOfficeDict clinicOfficeDict = (MClinicOfficeDict)iclinicOfficeDict;
            Hashtable ht = new Hashtable();
            ht.Add("CLINC_OFFICE_ID", clinicOfficeDict.CLINIC_OFFICE_ID);
            ht.Add("CLINC_OFFICE", clinicOfficeDict.CLINIC_OFFICE);
            ht.Add("PATIENT_SOURCE_ID", clinicOfficeDict.PATIENT_SOURCE_ID);
            ht.Add("CLINIC_OFFICE_CODE", clinicOfficeDict.CLINIC_OFFICE_CODE);
            ht.Add("CLINIC_OFFICE_FLAG", clinicOfficeDict.CLINIC_OFFICE_FLAG);
            ht.Add("CUR_SERIAL_NUM", clinicOfficeDict.CUR_SERIAL_NUM);
            ht.Add("STUDY_UID_HEADER", clinicOfficeDict.STUDY_UID_HEADER);
            ht.Add("CLINIC_OFFICE_PYCODE", clinicOfficeDict.CLINIC_OFFICE_PYCODE);
            return (ExecuteSql(StringConstructor.UpdateSql(TableName, ht,where).ToString()));
        }

        /// <summary>
        /// 批量更新临床科室记录
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int UpdateMore(Hashtable ht2)
        {
            MClinicOfficeDict MOfficeDict = new MClinicOfficeDict();
            Hashtable htStr = new Hashtable();
            Hashtable ht = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    MOfficeDict = (MClinicOfficeDict)ht2[i];
                    ht.Add("CLINIC_OFFICE", MOfficeDict.CLINIC_OFFICE);
                    ht.Add("PATIENT_SOURCE_ID", MOfficeDict.PATIENT_SOURCE_ID);
                    ht.Add("CLINIC_OFFICE_CODE", MOfficeDict.CLINIC_OFFICE_CODE);
                    ht.Add("CLINIC_OFFICE_FLAG", MOfficeDict.CLINIC_OFFICE_FLAG);
                    ht.Add("CUR_SERIAL_NUM", MOfficeDict.CUR_SERIAL_NUM);
                    ht.Add("STUDY_UID_HEADER", MOfficeDict.STUDY_UID_HEADER);
                    ht.Add("CLINIC_OFFICE_PYCODE", MOfficeDict.CLINIC_OFFICE_PYCODE);
                    htStr.Add(i, StringConstructor.UpdateSql(TableName, ht, " where CLINIC_OFFICE_ID=" + MOfficeDict.CLINIC_OFFICE_ID));
                }
                return ExecuteNonSql(htStr);
            }
            return 0;
        }

        /// <summary>
        /// 删除符合条件的临床科室记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }

        /// <summary>
        /// 获取所有符合条件的临床记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataSet GetData(string where)
        {
            strSql = "select clinic_offic,clinic_office_code from " + TableName + " where " + where;
            return GetDataSet(strSql);
        }
    }
}