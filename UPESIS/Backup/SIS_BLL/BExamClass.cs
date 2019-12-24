using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;
using System.Collections;

namespace SIS_BLL
{
    /// <summary>
    /// EXAM_CLASS业务类，操作SIS和PACS的检查类别表
    /// </summary>
    public class BExamClass
    {
        public BExamClass()
        {
        }
        private static IExamClass dal = DALFactory.DAL.CreateDExamClass();

        /// <summary>
        /// Add插入一条检查类别记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// AddMore批量插入检查类别记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Update更新指定的检查类别记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// UpdateMore批量更新检查类别记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int UpdateMore(Hashtable ht)
        {
            return dal.UpdateMore(ht);
        }

        /// <summary>
        /// Delete删除符合条件的检查类别记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// DeleteMore批量删除检查类别记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int DeleteMore(Hashtable ht)
        {
            return dal.DeleteMore(ht);
        }

        /// <summary>
        /// Exists查询是否存在指定的检查类别记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的检查类别记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetList2获取符合条件的检查类别记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList2(string where)
        {
            return dal.GetList2(where);
        }

        /// <summary>
        /// GetExamClass获取符合条件的检查类别记录的检查类别名
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetExamClass(string where)
        {
            return dal.GetExamClass(where);
        }

        /// <summary>
        /// GetModel获取指定检查类别名称、检查子类的检查类别记录
        /// </summary>
        /// <param name="examClass"></param>
        /// <param name="examSubClass"></param>
        /// <returns></returns>
        public IModel GetModel(string examClass, string examSubClass)
        {
            return dal.GetModel(examClass, examSubClass);
        }

        /// <summary>
        /// GetData获取所有检查类别记录
        /// </summary>
        /// <returns></returns>
        public DataSet GetData()
        {
            return dal.GetData();
        }
    }
}
