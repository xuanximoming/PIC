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
    /// 对SYSTEM_USERS，系统用户表
    /// </summary>
    public class DUser :IUser
    {
        private string strSql;
        private string TableName = "SYSTEM_USERS";
        public DUser()
            : base(GetConfig.GetSisConnStr())
        {
        }

        /// <summary>
        /// 插入一条用户记录
        /// </summary>
        /// <param name="iuser"></param>
        /// <returns></returns>
        public override int Add(IModel iuser)
        {
            MUser user = (MUser)iuser;
            Hashtable ht = new Hashtable();
            ht.Add("DOCTOR_ID", user.DOCTOR_ID);
            ht.Add("DOCTOR_NAME", user.DOCTOR_NAME);
            ht.Add("CLINIC_OFFICE_CODE", user.CLINIC_OFFICE_CODE);
            ht.Add("CLINIC_OFFICE", user.CLINIC_OFFICE);
            ht.Add("DOCTOR_ROLE", user.DOCTOR_ROLE);
            ht.Add("DOCTOR_PWD", user.DOCTOR_PWD);
            ht.Add("CREATE_DATE", user.CREATE_DATE);
            ht.Add("DOCTOR_LEVEL", user.DOCTOR_LEVEL);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 批量插入用户记录
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int AddMore(Hashtable ht2)
        {
            MUser user = new MUser();
            Hashtable ht = new Hashtable();
            Hashtable htstr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    user = (MUser)ht2[i];
                    ht.Add("DOCTOR_ID", user.DOCTOR_ID);
                    ht.Add("DOCTOR_NAME", user.DOCTOR_NAME);
                    ht.Add("CLINIC_OFFICE_CODE", user.CLINIC_OFFICE_CODE);
                    ht.Add("CLINIC_OFFICE", user.CLINIC_OFFICE);
                    ht.Add("DOCTOR_ROLE", user.DOCTOR_ROLE);
                    ht.Add("DOCTOR_PWD", user.DOCTOR_PWD);
                    ht.Add("CREATE_DATE", user.CREATE_DATE);
                    ht.Add("DOCTOR_LEVEL", user.DOCTOR_LEVEL);
                    htstr.Add(i, StringConstructor.InsertSql(TableName, ht).ToString());
                }
                return ExecuteNonSql(htstr);

            }
            else
                return 0;
        }

        /// <summary>
        /// 查询是否存在指定的用户记录
        /// </summary>
        /// <param name="iuser"></param>
        /// <returns></returns>
        public override bool Exists(IModel iuser)
        {
            MUser user = (MUser)iuser;
            strSql = "select * from " + TableName + " where DOCTOR_ID='" + user.DOCTOR_ID + "' and DOCTOR_PWD='" + user.DOCTOR_PWD + "'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取指定医生ID的用户记录
        /// </summary>
        /// <param name="DOCTOR_ID"></param>
        /// <returns></returns>
        public override IModel GetModel(string DOCTOR_ID)
        {
            strSql = "select * from " + TableName + " where DOCTOR_ID = '" + DOCTOR_ID + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MUser user = new MUser();
            user.DOCTOR_ID = dt.Rows[0]["DOCTOR_ID"].ToString();
            user.DOCTOR_NAME = dt.Rows[0]["DOCTOR_NAME"].ToString();
            user.CLINIC_OFFICE = dt.Rows[0]["CLINIC_OFFICE"].ToString();
            user.DOCTOR_ROLE = dt.Rows[0]["DOCTOR_ROLE"].ToString();
            user.DOCTOR_PWD = dt.Rows[0]["DOCTOR_PWD"].ToString();
            user.CLINIC_OFFICE_CODE = dt.Rows[0]["CLINIC_OFFICE_CODE"].ToString();

            if (dt.Rows[0]["DOCTOR_LEVEL"].ToString() == "")
                user.DOCTOR_LEVEL = null;
            else
                user.DOCTOR_LEVEL = Convert.ToInt32(dt.Rows[0]["DOCTOR_LEVEL"].ToString());

            if (dt.Rows[0]["CREATE_DATE"].ToString() == "")
                user.CREATE_DATE = null;
            else
                user.CREATE_DATE = Convert.ToDateTime(dt.Rows[0]["CREATE_DATE"].ToString());

            return user;
        }

        /// <summary>
        /// 获取符合条件的用户列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 获取符合条件的多角色的用户列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetListMultiRole(string where)
        {
            strSql = "select  a.DOCTOR_ID,a.CLINIC_OFFICE, a.CLINIC_OFFICE_CODE,a.DOCTOR_PWD,a.DOCTOR_LEVEL,wmsys.WM_CONCAT(b.ROLE_NAME) as ROLE_NAMES from system_users a ,USERS_ROLE b"
            + " where instr(a.DOCTOR_ROLE,',' ||b.ROLE_ID||',')>0 group by a.DOCTOR_ID,a.CLINIC_OFFICE, a.CLINIC_OFFICE_CODE,a.DOCTOR_PWD,a.DOCTOR_LEVEL " +where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定的用户
        /// </summary>
        /// <param name="iuser"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel iuser, string where)
        {
            MUser user = (MUser)iuser;
            Hashtable ht = new Hashtable();
            ht.Add("DOCTOR_ID", user.DOCTOR_ID);
            ht.Add("DOCTOR_NAME", user.DOCTOR_NAME);
            ht.Add("CLINIC_OFFICE_CODE", user.CLINIC_OFFICE_CODE);
            ht.Add("CLINIC_OFFICE", user.CLINIC_OFFICE);
            ht.Add("DOCTOR_ROLE", user.DOCTOR_ROLE);
            ht.Add("DOCTOR_PWD", user.DOCTOR_PWD);
            ht.Add("CREATE_DATE", user.CREATE_DATE);
            ht.Add("DOCTOR_LEVEL", user.DOCTOR_LEVEL);
            return ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString());
        }

        /// <summary>
        /// 批量更新用户记录
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int UpdateMore(Hashtable ht2)
        {
            MUser user = new MUser();
            Hashtable ht = new Hashtable();
            Hashtable htStr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    user = (MUser)ht2[i];
                    ht.Add("DOCTOR_ID", user.DOCTOR_ID);
                    ht.Add("DOCTOR_NAME", user.DOCTOR_NAME);
                    ht.Add("CLINIC_OFFICE_CODE", user.CLINIC_OFFICE_CODE);
                    ht.Add("CLINIC_OFFICE", user.CLINIC_OFFICE);
                    ht.Add("DOCTOR_ROLE", user.DOCTOR_ROLE);
                    ht.Add("DOCTOR_PWD", user.DOCTOR_PWD);
                    ht.Add("CREATE_DATE", user.CREATE_DATE);
                    ht.Add("DOCTOR_LEVEL", user.DOCTOR_LEVEL);
                    htStr.Add(i, StringConstructor.UpdateSql(TableName, ht, " where DOCTOR_ID='" + user.DOCTOR_ID + "'"));
                }

                return ExecuteNonSql(htStr);
            }
            return 0;
        }

        /// <summary>
        /// 删除符合条件的用户记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }

        /// <summary>
        /// 获取无重复用户记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataSet GetData(string where)
        {
            strSql = " select distinct doctor_name from " + TableName + " where " + where;
            return GetDataSet(strSql);
        }
    }
}
