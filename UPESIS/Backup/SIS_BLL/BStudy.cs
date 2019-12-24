using System;
using System.Collections.Generic;
using System.Text;
using ILL;
using System.Data;

namespace SIS_BLL
{
    /// <summary>
    /// STUDY业务类，操作SIS和PACS的检查记录表
    /// </summary>
    public class BStudy
    {
        public BStudy()
        {
        }
        private static IStudy dal = DALFactory.DAL.CreateDStudy();

        /// <summary>
        /// Add插入一条检查记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update更新指定的检查记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Delete删除符合条件的检查记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在指定的检查记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的检查记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetList1获取指定字段的检查记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList1(string where)
        {
            return dal.GetList1(where);
        }

        /// <summary>
        /// GetList2获取符合条件的所有检查记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList2(string where)
        {
            return dal.GetList2(where);
        }

        /// <summary>
        /// GetModel获取指定检查申请号的检查记录
        /// </summary>
        /// <param name="ExamAccessionNum"></param>
        /// <returns></returns>
        public IModel GetModel(string ExamAccessionNum)
        {
            return dal.GetModel(ExamAccessionNum);
        }
    }
}