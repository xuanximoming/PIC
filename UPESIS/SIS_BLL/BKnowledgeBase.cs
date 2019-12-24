using System;
using System.Collections.Generic;
using System.Text;
using ILL;
using System.Collections;
using System.Data;

namespace SIS_BLL
{
    /// <summary>
    /// KNOWLEDGE_BASE业务类，操作SIS的知识库
    /// </summary>
    public class BKnowledgeBase
    {
        public BKnowledgeBase()
        {
        }
        private static IKnowledgeBase dal = DALFactory.DAL.CreateDKnowledgeBase();

        /// <summary>
        /// Add插入一条知识库记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// AddMore批量插入知识库记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Update更新指定的知识库记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// UpdateMore批量更新知识库记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int UpdateMore(Hashtable ht)
        {
            return dal.UpdateMore(ht);
        }

        /// <summary>
        /// Delete删除符合条件的知识库记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// DeleteMore批量删除知识库记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int DeleteMore(Hashtable ht)
        {
            return dal.DeleteMore(ht);
        }

        /// <summary>
        /// Exists查询是否存在指定的知识库记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的知识库记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetList2获取符合条件的知识库记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList2(string where)
        {
            return dal.GetList2(where);
        }

        /// <summary>
        /// GetModel获取指定脏器、病种和图像名的知识库记录
        /// </summary>
        /// <param name="VISC_NAME"></param>
        /// <param name="DESC_NAME"></param>
        /// <param name="IMAGE_NAME"></param>
        /// <returns></returns>
        public IModel GetModel(string VISC_NAME, string DESC_NAME, string IMAGE_NAME)
        {
            return dal.GetModel(VISC_NAME, DESC_NAME, IMAGE_NAME);
        }
    }
}
