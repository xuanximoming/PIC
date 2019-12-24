using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;

using System.Collections;

namespace SIS_BLL
{
    /// <summary>
    /// INSTANCE业务类，操作PACS的图像表
    /// </summary>
    public class BInstance
    {
        private IInstance dal = DALFactory.DAL.CreateDInstance();

        public BInstance()
        {

        }

        /// <summary>
        /// Add插入一条图像记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// AddMore批量插入图像记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Update更新指定的图像记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// UpdateMore批量更新图像记录
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public int UpdateMore(Hashtable ht2)
        {
            return dal.UpdateMore(ht2);
        }

        /// <summary>
        /// Delete删除符合条件的图像记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在指定的图像记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的图像记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel获取指定图像KEY的图像记录
        /// </summary>
        /// <param name="IMG_EQUIPMENT_ID"></param>
        /// <returns></returns>
        public IModel GetModel(string INSTANCE_KEY)
        {
            return dal.GetModel(INSTANCE_KEY);
        }

    }
}
