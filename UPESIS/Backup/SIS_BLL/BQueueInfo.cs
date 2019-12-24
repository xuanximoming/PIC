using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;

namespace SIS_BLL
{
    /// <summary>
    /// QUEUE_INFO业务类，操作SIS和PACS的队列信息表
    /// </summary>
    public class BQueueInfo
    {
        public BQueueInfo()
        {
        }
        private static IQueueInfo dal = DALFactory.DAL.CreateDQueueInfo();

        /// <summary>
        /// Add插入一条队列信息病人记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update更新指定的队列信息病人记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Delete删除符合条件的队列信息病人记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在指定的队列信息病人记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的队列信息病人记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel获取指定的检查申请号的队列信息病人记录
        /// </summary>
        /// <param name="ExamAccessionNum"></param>
        /// <returns></returns>
        public IModel GetModel(string ExamAccessionNum)
        {
            return dal.GetModel(ExamAccessionNum);
        }

        /// <summary>
        /// GetQueue获取获取无重复的符合条件的队列信息病人记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetQueue(string where)
        {
            return dal.GetQueue(where);
        }
    }
}