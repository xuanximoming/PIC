using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;

namespace SIS_BLL
{
    /// <summary>
    /// REPORT业务类，操作SIS和PACS的报告表
    /// </summary>
    public class BReport
    {
        public BReport()
        {
        }

        private static IReport dal = DALFactory.DAL.CreateDReport();

        /// <summary>
        /// Add插入一条指定的报告记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update更新指定的报告记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Update指定Adapter的报告记录
        /// </summary>
        /// <param name="where"></param>
        /// <param name="dt_Report"></param>
        /// <param name="sda"></param>
        /// <returns></returns>
        public int Update(string where, System.Data.DataTable dt_Report, System.Data.Odbc.OdbcDataAdapter sda)
        {
            return dal.UpdateTable(where, dt_Report, sda);
        }

        /// <summary>
        /// Delete删除符合条件的报告记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在指定的报告记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的报告记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetList获取指定Adapter的报告记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <param name="sda"></param>
        /// <returns></returns>
        public DataTable GetList(string where, ref  System.Data.Odbc.OdbcDataAdapter sda)
        {
            return dal.GetList(where, ref sda);
        }

        /// <summary>
        /// GetModel获取指定检查申请号的报告记录
        /// </summary>
        /// <param name="ExamAccessionNum"></param>
        /// <returns></returns>
        public IModel GetModel(string ExamAccessionNum)
        {
            return dal.GetModel(ExamAccessionNum);
        }

    }
}