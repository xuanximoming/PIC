using System;
using System.Collections.Generic;
using System.Text;
using ILL;
using System.Data;


namespace SIS_BLL
{
    public class BLocationMapInf
    {
        /// <summary>
        /// LOCATION_MAP_INF业务类，操作SIS的定位图像信息表
        /// </summary>
        public BLocationMapInf()
        {
        }
        private static ILocationMapInf dal = DALFactory.DAL.CreateDLocationMapInf();

        /// <summary>
        /// Add插入一条定位图像信息记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update更新指定的定位图像信息记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Delete删除符合条件的定位图像信息记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在指定的定位图像信息记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的定位图像信息记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel获取指定定位图像信息ID的定位图像信息记录
        /// </summary>
        /// <param name="LOATION_MAP_INF_ID"></param>
        /// <returns></returns>
        public IModel GetModel(string LOATION_MAP_INF_ID)
        {
            return dal.GetModel(LOATION_MAP_INF_ID);
        }
    }
}