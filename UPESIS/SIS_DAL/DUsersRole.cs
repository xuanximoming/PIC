using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using ILL;
using SIS_Model;

namespace SIS_DAL
{
    /// <summary>
    /// 对USERS_ROLE，用户角色表
    /// </summary>
    public class DUsersRole : IUsersRole
    {
        private string strSql;
        private string TableName = "USERS_ROLE";
        public DUsersRole()
            : base(GetConfig.GetSisConnStr())
        {
        }

        /// <summary>
        /// 插入一条用户角色记录
        /// </summary>
        /// <param name="iusers_role"></param>
        /// <returns></returns>
        public override int Add(IModel iusers_role)
        {
            MUsersRole users_role = (MUsersRole)iusers_role;
            Hashtable ht = new Hashtable();
            ht.Add("ROLE_ID", users_role.ROLE_ID);
            ht.Add("ROLE_NAME", users_role.ROLE_NAME);
            ht.Add("EXAM_CLASS", users_role.EXAM_CLASS);
            ht.Add("EXAM_SUB_CLASS", users_role.EXAM_SUB_CLASS);
            ht.Add("FUN_MODEL", users_role.FUN_MODEL);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 批量插入用户角色记录
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int AddMore(Hashtable ht2)
        {
            MUsersRole MUserRol = new MUsersRole();
            Hashtable ht = new Hashtable();
            Hashtable htstr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    MUserRol = (MUsersRole)ht2[i];
                    ht.Add("ROLE_ID", MUserRol.ROLE_ID);
                    ht.Add("ROLE_NAME", MUserRol.ROLE_NAME);
                    ht.Add("EXAM_CLASS", MUserRol.EXAM_CLASS);
                    ht.Add("EXAM_SUB_CLASS", MUserRol.EXAM_SUB_CLASS);
                    ht.Add("FUN_MODEL", MUserRol.FUN_MODEL);
                    htstr.Add(i, StringConstructor.InsertSql(TableName, ht).ToString());
                }
                return ExecuteNonSql(htstr);

            }
            else
                return 0;
        }

        /// <summary>
        /// 查询是否存在指定角色记录
        /// </summary>
        /// <param name="iusers_role"></param>
        /// <returns></returns>
        public override bool Exists(IModel iusers_role)
        {
            MUsersRole users_role = (MUsersRole)iusers_role;
            strSql = "select * from " + TableName + " where ROLE_ID='" + users_role.ROLE_ID + "'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取指定ID的角色记录
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public override IModel GetModel(string roleId)
        {
            strSql = "select * from " + TableName + "  where ROLE_ID='" + roleId + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MUsersRole users_role = new MUsersRole();
            users_role.ROLE_ID = Convert.ToInt32(dt.Rows[0]["ROLE_ID"].ToString());
            users_role.ROLE_NAME = dt.Rows[0]["ROLE_NAME"].ToString();
            users_role.EXAM_CLASS = dt.Rows[0]["EXAM_CLASS"].ToString();
            users_role.EXAM_SUB_CLASS = dt.Rows[0]["EXAM_SUB_CLASS"].ToString();
            users_role.FUN_MODEL = dt.Rows[0]["FUN_MODEL"].ToString();
            return users_role;
        }

        /// <summary>
        /// 获取符合条件的角色列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定角色记录
        /// </summary>
        /// <param name="iusers_role"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel iusers_role, string where)
        {
            MUsersRole users_role = (MUsersRole)iusers_role;
            Hashtable ht = new Hashtable();
            ht.Add("FUN_MODEL", users_role.FUN_MODEL);
            return ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString());
        }

        /// <summary>
        /// 批量更新角色记录
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int UpdateMore(Hashtable ht2)
        {
            MUsersRole MUserRol = new MUsersRole();
            Hashtable ht = new Hashtable();
            Hashtable htStr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    MUserRol = (MUsersRole)ht2[i];
                    ht.Add("ROLE_NAME", MUserRol.ROLE_NAME);
                    ht.Add("EXAM_CLASS", MUserRol.EXAM_CLASS);
                    ht.Add("EXAM_SUB_CLASS", MUserRol.EXAM_SUB_CLASS);
                    htStr.Add(i, StringConstructor.UpdateSql(TableName, ht, " where ROLE_ID=" + MUserRol.ROLE_ID));
                }

                return ExecuteNonSql(htStr);
            }
            return 0;
        }

        /// <summary>
        /// 删除符合条件的角色记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}