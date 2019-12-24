using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;
using System.Collections;
namespace SIS_BLL
{
    /// <summary>
    /// EXAM_ITEM_DICT业务类，操作SIS和PACS的检查项目字典表
    /// </summary>
    public class BExamItemDict
    {
        public BExamItemDict()
        {
        }
        private static IExamItemDict dal = DALFactory.DAL.CreateDExamItemDict();

        /// <summary>
        /// Add插入一条检查项目字典记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// AddMore批量插入检查项目字典记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Update更新指定的检查项目字典记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// UpdateMore批量更新检查项目字典记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int UpdateMore(Hashtable ht)
        {
            return dal.UpdateMore(ht);
        }

        /// <summary>
        /// Delete删除符合条件的检查项目字典记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在指定的检查项目字典记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的检查项目字典记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel获取指定检查项目CODE和检查子类的检查项目字典记录
        /// </summary>
        /// <param name="ExamItemCode"></param>
        /// <param name="ExamSubClass"></param>
        /// <returns></returns>
        public IModel GetModel(string ExamItemCode, string ExamSubClass)
        {
            return dal.GetModel(ExamItemCode, ExamSubClass);
        }

    }
}
