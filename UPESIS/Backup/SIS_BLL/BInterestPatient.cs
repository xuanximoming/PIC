using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;

namespace SIS_BLL
{
    /// <summary>
    /// INTEREST_PATIENT业务类，操作SIS的感兴趣病人列表
    /// </summary>
    public class BInterestPatient
    {
        public BInterestPatient()
        {
        }

        private static IInterestPatient dal = DALFactory.DAL.CreateDInterestPatient();

        /// <summary>
        /// Add插入一条感兴趣病人记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update指定的感兴趣病人记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Delete删除符合条件的感兴趣病人记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists差学校是否存在指定的感兴趣病人记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的感兴趣病人记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetList2获取符合条件的感兴趣病人记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList2(string where)
        {
            return dal.GetList2(where);
        }

        /// <summary>
        /// GetModel获取指定节点ID的感兴趣病人记录
        /// </summary>
        /// <param name="nodeid"></param>
        /// <returns></returns>
        public IModel GetModel(string nodeid)
        {
            return dal.GetModel(nodeid);
        }
    }
}