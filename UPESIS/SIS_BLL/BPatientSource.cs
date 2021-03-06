using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using ILL;

namespace SIS_BLL
{
    /// <summary>
    /// PATIENT_SOURCE业务类，操作SIS和PACS的病人来源表
    /// </summary>
    public class BPatientSource
    {
        public BPatientSource()
        {
        }
        private static IPatientSource dal = DALFactory.DAL.CreateDPatientSource();

        /// <summary>
        /// Add插入一条指定的病人来源记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// AddMore批量插入病人来源记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Update更新指定的病人来源记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// UpdageMore批量更新病人来源记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int UpdateMore(Hashtable ht)
        {
            return dal.UpdateMore(ht);
        }

        /// <summary>
        /// Delete删除符合条件的病人来源记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在指定的病人来源记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的病人来源记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel获取指定病人来源ID的病人来源记录
        /// </summary>
        /// <param name="PatientSourceID"></param>
        /// <returns></returns>
        public IModel GetModel(string PatientSourceID)
        {
            return dal.GetModel(PatientSourceID);
        }
    }
}