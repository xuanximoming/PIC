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
    /// 对LOCATION_MAP，定位图像表
    /// </summary>
    public class DLocationMap : ILocationMap
    {
        private string strSql;
        private string TableName = "LOCATION_MAP";
        public DLocationMap()
            : base(GetConfig.GetSisConnStr())
        { 
        }

        /// <summary>
        /// 插入一条定位图像记录
        /// </summary>
        /// <param name="imodel"></param>
        /// <returns></returns>
        public override int Add(IModel imodel)
        {
            MLocationMap model = (MLocationMap)imodel;
            Hashtable ht = new Hashtable();
            ht.Add("MAP_ID", model.MAP_ID);
            ht.Add("EXAM_ACCESSION_NUM", model.EXAM_ACCESSION_NUM);
            ht.Add("MAP_PATH", model.MAP_PATH);
            ht.Add("MAP_PART", model.MAP_PART);
            ht.Add("MAP_EXPLAIN", model.MAP_EXPLAIN);
            ht.Add("IS_PRINT", model.IS_PRINT);
            ht.Add("PAGE_ORDER", model.PAGE_ORDER);
            ht.Add("MARK_INF", model.MARK_INF);
            ht.Add("MAP_TIME", model.MAP_TIME);
            ht.Add("MAP_NAME", model.MAP_NAME);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 查询是否存在指定的定位图像记录
        /// </summary>
        /// <param name="imodel"></param>
        /// <returns></returns>
        public override bool Exists(IModel imodel)
        {
            MLocationMap model = (MLocationMap)imodel;
            strSql = "select * from " + TableName + " where MAP_ID='" + model.MAP_ID + "'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取指定ID的定位图像记录
        /// </summary>
        /// <param name="MAP_ID"></param>
        /// <returns></returns>
        public override IModel GetModel(string MAP_ID)
        {
            strSql = "select * from " + TableName + " where MAP_ID='" + MAP_ID + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MLocationMap model = new MLocationMap();
            model.EXAM_ACCESSION_NUM=dt.Rows[0]["EXAM_ACCESSION_NUM"].ToString();
            model.MAP_EXPLAIN = dt.Rows[0]["MAP_EXPLAIN"].ToString();
            model.MAP_PATH = dt.Rows[0]["MAP_PATH"].ToString();
            model.MAP_NAME = dt.Rows[0]["MAP_NAME"].ToString();
            //if (dt.Rows[0]["MAP_ID"].ToString() == "")
            //    model.MAP_ID = null;
            //else
                model.MAP_ID =Convert.ToInt32(dt.Rows[0]["MAP_ID"].ToString()); 
            model.MAP_PART = dt.Rows[0]["MAP_PART"].ToString();
            if (dt.Rows[0]["MAP_TIME"].ToString() == "")
                model.MAP_TIME = null;
            else
                model.MAP_TIME =Convert.ToDateTime(dt.Rows[0]["MAP_TIME"].ToString());
            model.MARK_INF = dt.Rows[0]["MARK_INF"].ToString(); 
            return model;
        }

        /// <summary>
        /// 获取指定行的定位图像记录
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public override IModel GetModel(DataRow dr)
        {
            MLocationMap model = new MLocationMap();
            model.EXAM_ACCESSION_NUM = dr["EXAM_ACCESSION_NUM"].ToString();
            model.MAP_EXPLAIN = dr["MAP_EXPLAIN"].ToString();
            model.MAP_PATH = dr["MAP_PATH"].ToString();
            model.MAP_NAME = dr["MAP_NAME"].ToString();
            //if (dr["MAP_ID"].ToString() == "")
            //    model.MAP_ID = null;
            //else
            model.MAP_ID = Convert.ToInt32(dr["MAP_ID"].ToString());
            model.MAP_PART = dr["MAP_PART"].ToString();
            if (dr["MAP_TIME"].ToString() == "")
                model.MAP_TIME = null;
            else
                model.MAP_TIME = Convert.ToDateTime(dr["MAP_TIME"].ToString());
            model.MARK_INF = dr["MARK_INF"].ToString();
            return model;
        }

        /// <summary>
        /// 获取符合条件的定位图像列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定的定位图像记录
        /// </summary>
        /// <param name="imodel"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel imodel, string where)
        {
            MLocationMap model = (MLocationMap)imodel;
            Hashtable ht = new Hashtable();
            ht.Add("MAP_ID", model.MAP_ID);
            ht.Add("EXAM_ACCESSION_NUM", model.EXAM_ACCESSION_NUM);
            ht.Add("MAP_PATH", model.MAP_PATH);
            ht.Add("MAP_PART", model.MAP_PART);
            ht.Add("MAP_EXPLAIN", model.MAP_EXPLAIN);
            ht.Add("IS_PRINT", model.IS_PRINT);
            ht.Add("PAGE_ORDER", model.PAGE_ORDER);
            ht.Add("MARK_INF", model.MARK_INF);
            ht.Add("MAP_TIME", model.MAP_TIME);
            ht.Add("MAP_NAME", model.MAP_NAME);
            return ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString());
        }

        /// <summary>
        /// 删除符合条件的定位图像记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}