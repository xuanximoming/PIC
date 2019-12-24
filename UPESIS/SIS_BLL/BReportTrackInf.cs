using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;

namespace SIS_BLL
{
    /// <summary>
    /// REPORT_TRACK_INF业务类，操作SIS的报告轨迹表
    /// </summary>
    public class BReportTrackInf
    {
        public BReportTrackInf()
        {
        }

        private static IReportTrackInf dal = DALFactory.DAL.CreateDReportTrackInf();

        /// <summary>
        /// Add插入一条报告轨迹记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update更新指定的报告轨迹记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Delete删除符合条件的报告轨迹记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// GetList获取符合条件的报告轨迹记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }
    }
}