using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using ILL;

namespace SIS_BLL
{
    /// <summary>
    /// EXAM_CHARGE_LIST业务类，操作SIS和PACS的检查收费明细表
    /// </summary>
    public class BExamChargeList
    {
        public BExamChargeList()
        {
        }

        private static IExamChargeList dal = DALFactory.DAL.CreateDExamChargeList();

        /// <summary>
        /// Add插入一条指定的检查收费明细记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// AddMore批量插入检查收费明细记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Update指定的检查收费明细记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Delete符合条件的检查收费明细记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在指定的检查收费明细记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的检查收费明细记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

    }
}
