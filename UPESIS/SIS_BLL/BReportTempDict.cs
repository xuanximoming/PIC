using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;
using System.Collections;

namespace SIS_BLL
{
    /// <summary>
    /// REPORT_TEMP_DICT业务类，操作SIS的报告模板字典表
    /// </summary>
    public class BReportTempDict
    {
        public BReportTempDict()
        {
        }

        private static IReportTempDict dal = DALFactory.DAL.CreateDReportTempDict();

        /// <summary>
        /// Add插入一条报告模板字典记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update更新指定的报告模板字典记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Delte删除符合条件的报告模板字典记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在着指定的报告模板字典记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的报告模板字典记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetList2获取符合条件的报告模板字典记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList2(string where)
        {
            return dal.GetList2(where);
        }

        /// <summary>
        /// GetTabel获取指定SQL语句的报告模板字典记录列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet GetTable(string sql)
        {
            return dal.GetTable(sql);
        }

        /// <summary>
        /// GetModel获取指定节点ID的报告模板字典记录
        /// </summary>
        /// <param name="nodeid"></param>
        /// <returns></returns>
        public IModel GetModel(string nodeid)
        {
            return dal.GetModel(nodeid);
        }

        /// <summary>
        /// DeleteMore批量删除报告模板字典记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int DeleteMore(Hashtable ht)
        {
            return dal.DeleteMore(ht);
        }

        /// <summary>
        /// GetModels批量获取报告模板字典记录
        /// </summary>
        /// <param name="NODE_ID"></param>
        /// <returns></returns>
        public IModel[] GetModels(string NODE_ID)
        {
            return dal.GetModels(NODE_ID);
        }

        /// <summary>
        /// AddMore批量插入报告模板字典记录
        /// </summary>
        /// <param name="rptTemp"></param>
        /// <returns></returns>
        public int AddMore(object rptTemp)
        {
            return dal.AddMore(rptTemp);
        }
    }
}