using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;

namespace SIS_BLL
{
    /// <summary>
    /// DEPT_VS_QUEUE业务类，操作SIS和PACS的队列与诊室对照表
    /// </summary>
    public class BDeptVsQueue
    {
        public BDeptVsQueue()
        {
        }
        private static IDeptVsQueue dal = DALFactory.DAL.CreateDDeptVsQueue();

        /// <summary>
        /// Add插入队列与诊室对照记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update更新指定的队列与诊室对照记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Delete删除符合条件的队列与诊室对照记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在指定的队列与诊室对照记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的队列与诊室对照记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel获取指定队列ID的队列与诊室对照记录
        /// </summary>
        /// <param name="queueID"></param>
        /// <returns></returns>
        public IModel GetModel(string queueID)
        {
            return dal.GetModel(queueID);
        }

    }
}
