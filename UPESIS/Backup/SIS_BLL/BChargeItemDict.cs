using System;
using System.Collections.Generic;
using System.Text;
using ILL;
using System.Data;

using System.Collections;

namespace SIS_BLL
{
    /// <summary>
    /// CHARGE_ITEM_DICT，操作SIS和PACS的
    /// </summary>
    public class BChargeItemDict
    {
        public BChargeItemDict()
        { }
        private static IChargeItemDict dal = DALFactory.DAL.CreateDChargeItemDict();

        /// <summary>
        /// Add插入一条收费项目字典记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update更新指定的收费项目字典记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Delete删除符合条件的收费项目字典记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// DeleteMore批量删除收费项目字典记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int DeleteMore(Hashtable ht)
        {
            return dal.DeleteMore(ht );
        }

        /// <summary>
        /// Exists查询是否存在指定的收费项目字典记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// ExistWhere查询是否存在符合指定sql语句的收费项目字典记录
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool ExistsWhere(string sql)
        {
            return dal.ExistsWhere (sql);
        }

        /// <summary>
        /// GetList获取符合条件的收费项目字典记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetListMore批量获取符合条件的收费项目字典记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetListMore(string where)
        {
            return dal.GetListMore(where);
        }

        /// <summary>
        /// 获取指定收费项目字典记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IModel GetModel(IModel model)
        {
            return dal.GetModel(model);
        }
    }
}
