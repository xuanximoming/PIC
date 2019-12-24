using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;
using System.Collections;

namespace SIS_BLL
{
    /// <summary>
    /// USER业务类，操作SIS的SYSTEM_USERS表和PACS的FPAX_USERS表
    /// </summary>
    public class BUser
    {

        public BUser()
        {
        }
        private static IUser dal = DALFactory.DAL.CreateDUser();

        /// <summary>
        /// Add插入一条用户记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// AddMore批量插入用户记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Update更新指定的用户记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// UpdateMore批量更新用户记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int UpdateMore(Hashtable ht)
        {
            return dal.UpdateMore(ht);
        }

        /// <summary>
        /// Delete删除符合条件的用户记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// DeleteMore批量删除用户记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int DeleteMore(Hashtable ht)
        {
            return dal.DeleteMore(ht);
        }

        /// <summary>
        /// Exists查询是否存在指定的用户记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的用户记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetListMultiRole获取符合条件的多角色用户记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetListMultiRole(string where)
        {
            return dal.GetListMultiRole(where);
        }

        /// <summary>
        /// GetModel获取指定医生ID的用户记录
        /// </summary>
        /// <param name="DoctorID"></param>
        /// <returns></returns>
        public IModel GetModel(string DoctorID)
        {
            return dal.GetModel(DoctorID);
        }

        /// <summary>
        /// GetData获取符合条件的无重复用户记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet GetData(string where)
        {
            return dal.GetData(where);
        }
    }
}
