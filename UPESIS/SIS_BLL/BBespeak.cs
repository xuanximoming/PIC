using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;


namespace SIS_BLL
{
    /// <summary>
    /// BESPEAK业务类，操作SIS的BESPEAK表
    /// </summary>
    public class BBespeak
    {
        public BBespeak()
        {
        }

        private static IBespeak dal = DALFactory.DAL.CreateDBespeak();

        /// <summary>
        /// Add插入一条预约病人记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update更新指定的预约病人记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Delete删除符合条件的预约病人记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在指定的预约病人记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取指定预约ID的预约病人记录列表
        /// </summary>
        /// <param name="BESPEAK_ID"></param>
        /// <returns></returns>
        public DataTable GetList(string BESPEAK_ID)
        {
            return dal.GetList(BESPEAK_ID);
        }

    }
}
