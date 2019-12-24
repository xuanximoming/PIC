using System;
using System.Collections.Generic;
using System.Text;
using ILL;
using System.Data;

using System.Collections;

namespace SIS_BLL
{
    /// <summary>
    /// CHARGE_CLASS_DICT业务类，操作SIS和PACS的CHARGE_CLASS_DICT表
    /// </summary>
    public class BChargeItemClassDict
    {
        public BChargeItemClassDict()
        {
        }
        private static IChargeItemClassDict dal = DALFactory.DAL.CreateDChargeItemClassDict();

        /// <summary>
        /// Add插入一条收费项目分类记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// AddMore批量插入收费项目分类记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Update更新指定的收费项目分类记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// UpdateMore批量更新收费项目分类记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int UpdateMore(Hashtable ht)
        {
            return dal.UpdateMore(ht);
        }

        /// <summary>
        /// Delete删除符合条件的收费项目分类记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在指定的收费项目分类记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GeList获取符合条件的收费项目分类列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GeModel获取指定类别代码的收费项目分类记录
        /// </summary>
        /// <param name="classCode"></param>
        /// <returns></returns>
        public IModel GetModel(string classCode)
        {
            return dal.GetModel(classCode);
        }
    }
}
