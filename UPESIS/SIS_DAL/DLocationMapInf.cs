using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Collections;
using SIS_Model;
using ILL;

namespace SIS_DAL
{
    /// <summary>
    /// 对LOCATION_MAP_INF，定位图像信息表
    /// </summary>
    public class DLocationMapInf : ILocationMapInf
    {
        private string strSql;
        private string TableName = "LOCATION_MAP_INF";
        public DLocationMapInf()
            : base(GetConfig.GetSisConnStr())
        { 
        }

        /// <summary>
        /// 插入一条定位图像信息记录
        /// </summary>
        /// <param name="imodel"></param>
        /// <returns></returns>
        public override int Add(IModel imodel)
        {
            MLocationMapInf model = (MLocationMapInf)imodel;
            Hashtable ht = new Hashtable();
            ht.Add("LOATION_MAP_INF_ID", model.LOATION_MAP_INF_ID);
            ht.Add("MAP_FILENAME", model.MAP_FILENAME);
            ht.Add("MAP_PART", model.MAP_PART);
            ht.Add("MAP_EXPLAIN", model.MAP_EXPLAIN);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 查询是否存在指定的记录
        /// </summary>
        /// <param name="imodel"></param>
        /// <returns></returns>
        public override bool Exists(IModel imodel)
        {
            MLocationMapInf model = (MLocationMapInf)imodel;
            strSql = "select * from " + TableName + " where LOATION_MAP_INF_ID='" + model.LOATION_MAP_INF_ID + "'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取指定ID的记录
        /// </summary>
        /// <param name="LOATION_MAP_INF_ID"></param>
        /// <returns></returns>
        public override IModel GetModel(string LOATION_MAP_INF_ID)
        {
            strSql = "select * from " + TableName + " where MLocationMapInf='" + LOATION_MAP_INF_ID + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MLocationMapInf model = new MLocationMapInf();
            model.LOATION_MAP_INF_ID = Convert.ToInt32(dt.Rows[0]["LOATION_MAP_INF_ID"].ToString());
            model.MAP_EXPLAIN = dt.Rows[0]["MAP_EXPLAIN"].ToString(); 
            model.MAP_FILENAME = dt.Rows[0]["MAP_FILENAME"].ToString();
            model.MAP_PART = dt.Rows[0]["MAP_PART"].ToString();
            return model;
        }

        /// <summary>
        /// 获取符合条件的记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定的记录
        /// </summary>
        /// <param name="imodel"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel imodel, string where)
        {
            MLocationMapInf model = (MLocationMapInf)imodel;
            Hashtable ht = new Hashtable();
            ht.Add("LOATION_MAP_INF_ID", model.LOATION_MAP_INF_ID);
            ht.Add("MAP_FILENAME", model.MAP_FILENAME);
            ht.Add("MAP_PART", model.MAP_PART);
            ht.Add("MAP_EXPLAIN", model.MAP_EXPLAIN);
            return ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString());
        }

        /// <summary>
        /// 删除符合条件的记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}