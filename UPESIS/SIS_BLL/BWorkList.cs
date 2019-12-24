using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;

namespace SIS_BLL
{
    /// <summary>
    /// WORKLIST业务类，操作SIS和PACS的工作表
    /// </summary>
    public class BWorkList
    {
        public BWorkList()
        {
        }

        private static IWorkList dal = DALFactory.DAL.CreateDWorkList();

        /// <summary>
        /// Add插入一条工作记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update更新指定的工作记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Delete删除符合条件的工作记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在指定的工作记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的工作记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetList2获取符合条件和指定字段的工作记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList2(string where)
        {
            return dal.GetList2(where);
        }

        /// <summary>
        /// GetWorkListReport获取包括病人报告在内的工作记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetWorkListReport(string where)
        {
            return dal.GetWorkListReport(where);
        }

        /// <summary>
        /// GetModel获取指定检查申请号的工作记录
        /// </summary>
        /// <param name="ExamAccessionNum"></param>
        /// <returns></returns>
        public IModel GetModel(string ExamAccessionNum)
        {
            return dal.GetModel(ExamAccessionNum);
        }
    }
}