using System;
using System.Collections.Generic;
using System.Text;

using PACS_Model;
using ILL;
using System.Data;
using System.Collections;

namespace PACS_DAL
{
    /// <summary>
    /// 操作INSTANCE，即图像字典
    /// </summary>
    public class DInstance : IInstance
    {
        private string strSql;
        private string TableName = "INSTANCE";
        public DInstance()
            : base(GetConfig.GetPacsConnStr())
        {
        }

        /// <summary>
        /// 插入一条图像记录
        /// </summary>
        /// <param name="imodel"></param>
        /// <returns></returns>
        public override int Add(IModel imodel)
        {
            MInstance model = (MInstance)imodel;
            Hashtable ht = new Hashtable();
            ht.Add("INSTANCE_KEY", model.INSTANCE_KEY);
            ht.Add("SOP_INSTANCE_UID", model.SOP_INSTANCE_UID);
            ht.Add("SOP_CLASS_UID", model.SOP_CLASS_UID);
            ht.Add("SERIES_KEY", model.SERIES_KEY);
            ht.Add("STUDY_KEY", model.STUDY_KEY);
            ht.Add("ORIGIN_AETITLE", model.ORIGIN_AETITLE);
            ht.Add("KEY_MARK", model.KEY_MARK);
            ht.Add("ORDINAL", model.ORDINAL);
            ht.Add("VOLUME_KEY", model.VOLUME_KEY);
            ht.Add("HOST_NAME", model.HOST_NAME);
            ht.Add("PATH_NAME", model.PATH_NAME);
            ht.Add("FILE_NAME", model.FILE_NAME);
            ht.Add("FORMAT", model.FORMAT);
            ht.Add("CHECKED", model.CHECKED);
            ht.Add("INSTANCE_NO", model.INSTANCE_NO);
            ht.Add("INSTANCE_INDEX", model.INSTANCE_INDEX);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 查询是否存在指定的图像记录
        /// </summary>
        /// <param name="imodel"></param>
        /// <returns></returns>
        public override bool Exists(IModel imodel)
        {
            MInstance model = (MInstance)imodel;
            strSql = "select * from " + TableName + " where  INSTANCE _KEY='" + model.INSTANCE_KEY + "'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取指定图像主键的图像记录
        /// </summary>
        /// <param name="INSTANCE_KEY"></param>
        /// <returns></returns>
        public override IModel GetModel(string INSTANCE_KEY)
        {
            strSql = "select * from " + TableName + "  where INSTANCE _KEY='" + INSTANCE_KEY + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MInstance model = new MInstance();
            model.INSTANCE_KEY = Convert.ToInt32(dt.Rows[0]["INSTANCE_KEY"]);
            model.SOP_INSTANCE_UID = dt.Rows[0]["SOP_INSTANCE_UID"].ToString();
            model.SOP_CLASS_UID = dt.Rows[0]["SOP_CLASS_UID"].ToString();
            model.SERIES_KEY = Convert.ToInt32(dt.Rows[0]["SERIES_KEY"]);
            model.STUDY_KEY = Convert.ToInt32(dt.Rows[0]["STUDY_KEY"]);
            model.ORIGIN_AETITLE = dt.Rows[0]["ORIGIN_AETITLE"].ToString();
            model.KEY_MARK = Convert.ToInt32(dt.Rows[0]["KEY_MARK"]);
            model.ORDINAL = Convert.ToInt32(dt.Rows[0]["ORDINAL"]);
            model.VOLUME_KEY = Convert.ToInt32(dt.Rows[0]["VOLUME_KEY"]);
            model.HOST_NAME = dt.Rows[0]["HOST_NAME"].ToString();
            model.PATH_NAME = dt.Rows[0]["PATH_NAME"].ToString();
            model.FILE_NAME = dt.Rows[0]["FILE_NAME"].ToString();
            model.FORMAT = dt.Rows[0]["FORMAT"].ToString();
            model.CHECKED = Convert.ToInt32(dt.Rows[0]["AMOUNT"]);
            model.INSTANCE_NO = Convert.ToInt32(dt.Rows[0]["AMOUNT"]);
            model.INSTANCE_INDEX = Convert.ToInt32(dt.Rows[0]["AMOUNT"]);
            return model;
        }

        /// <summary>
        /// 获取符合条件的图像记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定的图像记录
        /// </summary>
        /// <param name="imodel"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel imodel, string where)
        {
            MInstance model = (MInstance)imodel;
            Hashtable ht = new Hashtable();
            ht.Add("INSTANCE_KEY", model.INSTANCE_KEY);
            ht.Add("SOP_INSTANCE_UID", model.SOP_INSTANCE_UID);
            ht.Add("SOP_CLASS_UID", model.SOP_CLASS_UID);
            ht.Add("SERIES_KEY", model.SERIES_KEY);
            ht.Add("STUDY_KEY", model.STUDY_KEY);
            ht.Add("ORIGIN_AETITLE", model.ORIGIN_AETITLE);
            ht.Add("KEY_MARK", model.KEY_MARK);
            ht.Add("ORDINAL", model.ORDINAL);
            ht.Add("VOLUME_KEY", model.VOLUME_KEY);
            ht.Add("HOST_NAME", model.HOST_NAME);
            ht.Add("PATH_NAME", model.PATH_NAME);
            ht.Add("FILE_NAME", model.FILE_NAME);
            ht.Add("FORMAT", model.FORMAT);
            ht.Add("CHECKED", model.CHECKED);
            ht.Add("INSTANCE_NO", model.INSTANCE_NO);
            ht.Add("INSTANCE_INDEX", model.INSTANCE_INDEX);
            return ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString());
        }

        /// <summary>
        /// 删除符合条件的图像记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}
