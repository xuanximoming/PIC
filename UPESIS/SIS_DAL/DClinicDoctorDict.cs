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
    /// 对Clinic_Doctor_Dict，临床医生字典
    /// </summary>
    public class DClinicDoctorDict : IClinicDoctorDict
    {
        private string strSql;
        private string TableName = "Clinic_Doctor_Dict";
        public DClinicDoctorDict()
            : base(GetConfig.GetSisConnStr())
        {
        }
        
        /// <summary>
        /// 插入一条临床医生记录
        /// </summary>
        /// <param name="iclinicDoctorDict"></param>
        /// <returns></returns>
        public override int Add(IModel iclinicDoctorDict)
        {
            MClinicDoctorDict clinicDoctorDict = (MClinicDoctorDict)iclinicDoctorDict;
            Hashtable ht = new Hashtable();
            ht.Add("CLINIC_DOCTOR_ID", clinicDoctorDict.CLINIC_DOCTOR_ID);
            ht.Add("CLINIC_DOCTOR", clinicDoctorDict.CLINIC_DOCTOR);
            ht.Add("CLINIC_OFFICE_ID", clinicDoctorDict.CLINIC_OFFICE_ID);
            ht.Add("CLINIC_DOCTOR_PYCODE",clinicDoctorDict.CLINIC_DOCTOR_PYCODE);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 批量插入临床医生记录
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int AddMore(Hashtable ht2)
        {
            MClinicDoctorDict MDoctorDict = new MClinicDoctorDict();
            Hashtable ht = new Hashtable();
            Hashtable htstr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    MDoctorDict = (MClinicDoctorDict)ht2[i];
                    ht.Add("CLINIC_DOCTOR_ID", MDoctorDict.CLINIC_DOCTOR_ID);
                    ht.Add("CLINIC_DOCTOR", MDoctorDict.CLINIC_DOCTOR);
                    ht.Add("CLINIC_OFFICE_ID", MDoctorDict.CLINIC_OFFICE_ID);
                    ht.Add("CLINIC_DOCTOR_PYCODE",MDoctorDict.CLINIC_DOCTOR_PYCODE);
                    htstr.Add(i, StringConstructor.InsertSql(TableName, ht).ToString());
                }
                return ExecuteNonSql(htstr);

            }
            else
                return 0;
        }

        /// <summary>
        /// 查询是否存在指定的临床医生记录
        /// </summary>
        /// <param name="iclinicDoctorDict"></param>
        /// <returns></returns>
        public override bool Exists(IModel iclinicDoctorDict)
        {
            MClinicDoctorDict clinicDoctorDict = (MClinicDoctorDict)iclinicDoctorDict;
            strSql = "select * from " + TableName + " where CLINIC_DOCTOR_ID='" + clinicDoctorDict.CLINIC_DOCTOR_ID + "'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取指定的临床医生ID的临床医生记录
        /// </summary>
        /// <param name="CLINC_DOCTOR_ID"></param>
        /// <returns></returns>
        public override IModel GetModel(string CLINC_DOCTOR_ID)
        {
            strSql = "select * from " + TableName + " where CLINIC_DOCTOR_ID ='" + CLINC_DOCTOR_ID + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MClinicDoctorDict clinicDoctorDict = new MClinicDoctorDict();
            clinicDoctorDict.CLINIC_DOCTOR_ID = dt.Rows[0]["CLINIC_DOCTOR_ID"].ToString();
            clinicDoctorDict.CLINIC_DOCTOR = dt.Rows[0]["CLINIC_DOCTOR"].ToString();

            if (dt.Rows[0]["CLINIC_OFFICE_ID"].ToString() == "")
                clinicDoctorDict.CLINIC_OFFICE_ID = null;
            else
                clinicDoctorDict.CLINIC_OFFICE_ID = Convert.ToInt32(dt.Rows[0]["CLINIC_OFFICE_ID"].ToString());
            clinicDoctorDict.CLINIC_DOCTOR_PYCODE = dt.Rows[0]["CLINIC_DOCTOR_PYCODE"].ToString();

            return clinicDoctorDict;
        }

        /// <summary>
        /// 获取符合条件的临床医生列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 联合临床科室表查询符合条件的临床医生
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList2(string where)
        {
            strSql = "select a.* from " + TableName + " a, CLINIC_OFFICE_DICT b where a.CLINIC_OFFICE_ID = b.CLINIC_OFFICE_ID and " + where;
            return GetDataTable(strSql);
        }
        /// <summary>
        /// 更新指定的临床医生记录
        /// </summary>
        /// <param name="iclinicDoctorDict"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel iclinicDoctorDict, string where)
        {
            MClinicDoctorDict clinicDoctorDict = (MClinicDoctorDict)iclinicDoctorDict;
            Hashtable ht = new Hashtable();
            ht.Add("CLINIC_DOCTOR_ID", clinicDoctorDict.CLINIC_DOCTOR_ID);
            ht.Add("CLINIC_DOCTOR", clinicDoctorDict.CLINIC_DOCTOR);
            ht.Add("CLINIC_OFFICE_ID", clinicDoctorDict.CLINIC_OFFICE_ID);
            ht.Add("CLINIC_DOCTOR_PYCODE",clinicDoctorDict.CLINIC_DOCTOR_PYCODE);
            
            return (ExecuteSql(StringConstructor.UpdateSql(TableName, ht,where).ToString()));
        }

        /// <summary>
        /// 批量更新临床医生记录
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int UpdateMore(Hashtable ht2)
        {
            MClinicDoctorDict MDoctorDict = new MClinicDoctorDict();
            Hashtable ht = new Hashtable();
            Hashtable htStr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    MDoctorDict = (MClinicDoctorDict)ht2[i];
                    ht.Add("CLINIC_DOCTOR", MDoctorDict.CLINIC_DOCTOR);
                    ht.Add("CLINIC_OFFICE_ID", MDoctorDict.CLINIC_OFFICE_ID);
                    ht.Add("CLINIC_DOCTOR_PYCODE",MDoctorDict.CLINIC_DOCTOR_PYCODE);
                    htStr.Add(i, StringConstructor.UpdateSql(TableName, ht, " where CLINIC_DOCTOR_ID=" + MDoctorDict.CLINIC_DOCTOR_ID));
                }

                return ExecuteNonSql(htStr);
            }
            return 0;
        }

        /// <summary>
        /// 删除符合条件的临床医生记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}