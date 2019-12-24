using System;
using System.Collections.Generic;
using System.Text;
using ILL;
using System.Data;
using System.Collections;

namespace SIS_BLL
{
    /// <summary>
    /// USER_ROLE业务类，操作SIS的用户角色表
    /// </summary>
    public class BUsersRole
    {
        public BUsersRole()
        {
        }
        private static IUsersRole dal = DALFactory.DAL.CreateDUsersRole();

        /// <summary>
        /// Add插入一条用户角色记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// AddMore批量插入用户角色记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Update更新指定的用户角色记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Update2更新指定用户角色记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update2(IModel model, string where)
        {
            return dal.Update2(model, where);
        }

        /// <summary>
        /// UpdateMore批量更新用户角色记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int UpdateMore(Hashtable ht)
        {
            return dal.UpdateMore(ht);
        }

        /// <summary>
        /// Delete删除符合条件的用户角色记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// DeleteMore批量删除用户角色记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int DeleteMore(Hashtable ht)
        {
            return dal.DeleteMore(ht );
        }

        /// <summary>
        /// Exists查询是否存在指定的用户角色记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的用户角色记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel获取指定角色ID的用户角色记录
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public IModel GetModel(string roleId)
        {
            return dal.GetModel(roleId);
        }
    }
}