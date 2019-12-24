using System;
using System.Collections.Generic;
using System.Text;
using ILL;
using System.Data;
using System.Collections;

namespace SIS_BLL
{
    /// <summary>
    /// EXAM_VS_CHARGE业务类，操作SIS和PACS的检查收费对照表
    /// </summary>
    public class BExamVsCharge
    {
        private static IExamVsCharge dal = DALFactory.DAL.CreateDExamVsCharge();

        /// <summary>
        /// Add插入一条检查收费对照记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// AddMore批量插入检查收费对照记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Update更新指定的检查收费对照记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Delete删除符合条件的检查收费对照记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        public int DeleteMore(Hashtable ht)
        {
            return dal.DeleteMore(ht);
        }

        /// <summary>
        /// Exists查询是否存在的检查收费对照记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的检查收费对照记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetList2获取符合条件的检查收费对照记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList2(string where)
        {
            return dal.GetList2(where);
        }

        /// <summary>
        /// GetModel获取指定的检查项目Code和收费项目序号的检查收费对照记录
        /// </summary>
        /// <param name="ExamItemCode"></param>
        /// <param name="ChargeItemNo"></param>
        /// <returns></returns>
        public IModel GetModel(string ExamItemCode, string ChargeItemNo)
        {
            return dal.GetModel(ExamItemCode, ChargeItemNo);
        }
    }
}
