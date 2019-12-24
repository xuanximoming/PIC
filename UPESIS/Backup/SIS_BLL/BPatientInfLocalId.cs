using System;
using System.Collections.Generic;
using System.Text;
using ILL;
using System.Data;

namespace SIS_BLL
{
    /// <summary>
    /// PATIENT_INF_LOCAL_ID业务类，操作SIS和PACS的病人信息与本地检查号对照表
    /// </summary>
    public class BPatientInfLocalId
    {
        public BPatientInfLocalId()
        {
        }
        private static IPatientInfLocalId dal = DALFactory.DAL.CreateDPatientInfLocalId();

        /// <summary>
        /// Add插入一条病人信息与本地ID对照记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update更新指定的病人信息与本地ID对照记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Delete删除符合条件的病人信息与本地ID对照记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在指定的病人信息与本地ID对照记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的病人信息与本地ID对照记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel获取指定病人ID、本地ID类别的病人信息与本地ID对照记录
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="localIdClass"></param>
        /// <returns></returns>
        public IModel GetModel(string patientId,string localIdClass)
        {
            return dal.GetModel(patientId, localIdClass);
        }
    }
}