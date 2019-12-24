using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;

using System.Collections;

namespace SIS_BLL
{
    /// <summary>
    /// CHARGE_CLASS业务类，操作SIS和PACS的CHARGE_CLASS表
    /// </summary>
    public class BChargeClass
    {
        public BChargeClass()
        {
        }
        private static IChargeClass dal = DALFactory.DAL.CreateDChargeClass();

        /// <summary>
        /// Add插入一条收费类别记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// AddMore批量插入收费类别记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public  int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Updage更新指定的收费类别记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// UpdateMore批量更新收费类别记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public  int UpdateMore(Hashtable ht)
        {
            return dal.UpdateMore(ht);
        }

        /// <summary>
        /// Delete删除符合条件的收费类别记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在指定的收费类别记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的收费类别记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel获取指定收费类别ID的类别记录
        /// </summary>
        /// <param name="CHARGE_CLASS_ID"></param>
        /// <returns></returns>
        public IModel GetModel(string CHARGE_CLASS_ID)
        {
            return dal.GetModel(CHARGE_CLASS_ID);
        }
    }
}
