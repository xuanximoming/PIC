using System;
using System.Collections.Generic;
using System.Text;
using ILL;
using System.Data;

namespace SIS_BLL
{
    /// <summary>
    /// AREA_DICT业务类，操作SIS和PACS的Area_dict表
    /// </summary>
    public class BAreaDict
    {
        public BAreaDict()
        {
        }
        private static IAreaDict dal = DALFactory.DAL.CreateDAreaDict();

        /// <summary>
        /// Add插入一条行政区记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update更新指定的行政区记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Delete删除符合条件的行政区记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在指定的行政区记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的行政区记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel获取符合指定AREA_CODE的行政区记录
        /// </summary>
        /// <param name="areaCode"></param>
        /// <returns></returns>
        public IModel GetModel(string areaCode)
        {
            return dal.GetModel(areaCode);
        } 
    }
}
