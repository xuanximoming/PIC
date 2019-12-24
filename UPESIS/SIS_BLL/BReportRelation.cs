using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL; 

namespace SIS_BLL
{
    /// <summary>
    /// REPORT_RELATION业务类，操作SIS的一体化报告表
    /// </summary>
    public class BReportRelation
    {
        public BReportRelation()
        {
        }

        private static IReportRelation dal = DALFactory.DAL.CreateDReportRelation();

        /// <summary>
        /// Add插入一条一体化报告记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update指定的一体化报告记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Delete删除符合条件的一体化报告记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在指定的一体化报告记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的一体化报告记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }
    }
}