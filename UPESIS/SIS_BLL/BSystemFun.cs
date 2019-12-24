using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using ILL;

namespace SIS_BLL
{
    /// <summary>
    /// SYSTEM_FUNCTION业务类，操作SIS的系统功能表
    /// </summary>
    public class BSystemFun
    {
        public BSystemFun()
        {
        }

        private static ISystemFun dal = DALFactory.DAL.CreateDSystemFun();

        /// <summary>
        /// Add插入一条系统功能记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }


        /// <summary>
        /// AddMore批量插入系统功能记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int  AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Update更新指定的系统功能记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// UpdateMore批量更新系统功能记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int UpdateMore(Hashtable ht)
        {
            return dal.UpdateMore(ht);
        }

        /// <summary>
        /// Delete删除符合条件的系统功能记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在指定的系统功能记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的系统功能记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetList获取指定ID的系统功能记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetList(int id)
        {
            return dal.GetList(id);
        }

        /// <summary>
        /// GetListChild获取符合条件的系统功能记录子列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetListChild(string where)
        {
            return dal.GetListChild(where);
        }

        /// <summary>
        /// GetModel获取指定MODEL_ID的系统功能记录
        /// </summary>
        /// <param name="MODEL_ID"></param>
        /// <returns></returns>
        public IModel GetModel(string MODEL_ID)
        {
            return dal.GetModel(MODEL_ID);
        }

    }
}