using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;

namespace SIS_BLL
{
    /// <summary>
    /// ARCHIVES业务类，对包括SIS的Archives和PACS的Patient_inf表进行操作
    /// </summary>
    public class BArchives
    {
        public BArchives()
        {
        }       
        private IArchives dal = DALFactory.DAL.CreateDArchives();

        /// <summary>
        /// Add插入一条病人记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update更新指定的病人记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model,where);
        }

        /// <summary>
        /// Delete删除符合条件的病人记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在指定的病人记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的病人记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel获取指定病人ID号的病人记录
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public IModel GetModel(string patientID)
        {
            return dal.GetModel(patientID);
        }
    }
}
