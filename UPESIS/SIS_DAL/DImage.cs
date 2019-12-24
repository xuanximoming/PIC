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
    /// 对IMAGE，图像表
    /// </summary>
    public class DImage : IImage
    {
        private string strSql;
        private string TableName = "IMAGE";
        public DImage()
            : base(GetConfig.GetSisConnStr())
        {
        }

        /// <summary>
        /// 插入一条图像记录
        /// </summary>
        /// <param name="iimage"></param>
        /// <returns></returns>
        public override int Add(IModel iimage)
        {
            MImage image = (MImage)iimage;
            image.IMAGE_ID = int.Parse(new DGetSeqValue("SIS", "SEQ_IMAGE_ID").GetSeqValue());
            Hashtable ht = new Hashtable();
            ht.Add("IMAGE_ID", image.IMAGE_ID);
            ht.Add("EXAM_ACCESSION_NUM", image.EXAM_ACCESSION_NUM);
            ht.Add("IMAGE_PATH", image.IMAGE_PATH);
            ht.Add("IMAGE_TYPE", image.IMAGE_TYPE);
            ht.Add("BACK_ID", image.BACK_ID);
            ht.Add("VOLUMN_KEY", image.VOLUMN_KEY);
            ht.Add("ONLINE_ID", image.ONLINE_ID);
            ht.Add("IMAGE_CLASS", image.IMAGE_CLASS);
            ht.Add("IMAGE_EXPLAIN", image.IMAGE_EXPLAIN);
            ht.Add("IS_PRINT", image.IS_PRINT);
            ht.Add("PAGE_ORDER", image.PAGE_ORDER);
            ht.Add("MARK_INF", image.MARK_INF);
            ht.Add("IMAGE_TIME", image.IMAGE_DATE);
            ht.Add("MARK_IMAGE_PATH", image.MARK_IMAGE_PATH);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 插入指定的图像记录
        /// </summary>
        /// <param name="iimage"></param>
        /// <param name="imageId"></param>
        /// <returns></returns>
        public override int Add(IModel iimage,ref int imageId)
        {
            MImage image = (MImage)iimage;
            imageId = int.Parse(new DGetSeqValue("SIS", "SEQ_IMAGE_ID").GetSeqValue());
            image.IMAGE_ID = imageId;
            Hashtable ht = new Hashtable();
            ht.Add("IMAGE_ID", image.IMAGE_ID);
            ht.Add("EXAM_ACCESSION_NUM", image.EXAM_ACCESSION_NUM);
            ht.Add("IMAGE_PATH", image.IMAGE_PATH);
            ht.Add("IMAGE_TYPE", image.IMAGE_TYPE);
            ht.Add("BACK_ID", image.BACK_ID);
            ht.Add("VOLUMN_KEY", image.VOLUMN_KEY);
            ht.Add("ONLINE_ID", image.ONLINE_ID);
            ht.Add("IMAGE_CLASS", image.IMAGE_CLASS);
            ht.Add("IMAGE_EXPLAIN", image.IMAGE_EXPLAIN);
            ht.Add("IS_PRINT", image.IS_PRINT);
            ht.Add("PAGE_ORDER", image.PAGE_ORDER);
            ht.Add("MARK_INF", image.MARK_INF);
            ht.Add("IMAGE_TIME", image.IMAGE_DATE);
            ht.Add("MARK_IMAGE_PATH", image.MARK_IMAGE_PATH);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 查询是否存在指定的图像记录
        /// </summary>
        /// <param name="iimage"></param>
        /// <returns></returns>
        public override bool Exists(IModel iimage)
        {
            MImage image = (MImage)iimage;
            strSql = "select * from " + TableName + " where IMAGE_ID=" + image.IMAGE_ID + "and EXAM_ACCESSION_NUM='" + image.EXAM_ACCESSION_NUM + "'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取指定图像ID的图像记录
        /// </summary>
        /// <param name="IMAGE_ID"></param>
        /// <returns></returns>
        public override IModel GetModel(string IMAGE_ID)
        {
            strSql = "select * from " + TableName + " where IMAGE_ID = " + IMAGE_ID;// +" and EXAM_ACCESSION_NUM = '" + EXAM_ACCESSION_NUM + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MImage image = new MImage();
            image.IMAGE_ID = Convert.ToInt32(dt.Rows[0]["IMAGE_ID"].ToString());
            image.EXAM_ACCESSION_NUM = dt.Rows[0]["EXAM_ACCESSION_NUM"].ToString();
            image.IMAGE_PATH = dt.Rows[0]["IMAGE_PATH"].ToString();
            image.IMAGE_TYPE = dt.Rows[0]["IMAGE_TYPE"].ToString();

            if (dt.Rows[0]["BACK_ID"].ToString() == "")
                image.BACK_ID = null;
            else
                image.BACK_ID = Convert.ToInt32(dt.Rows[0]["BACK_ID"].ToString());

            image.VOLUMN_KEY = dt.Rows[0]["VOLUMN_KEY"].ToString();

            if (dt.Rows[0]["ONLINE_ID"].ToString() == "")
                image.ONLINE_ID = null;
            else
                image.ONLINE_ID = Convert.ToInt32(dt.Rows[0]["ONLINE_ID"].ToString());

            image.IMAGE_CLASS = dt.Rows[0]["IMAGE_CLASS"].ToString();
            image.IMAGE_EXPLAIN = dt.Rows[0]["IMAGE_EXPLAIN"].ToString();

            if (dt.Rows[0]["IS_PRINT"].ToString() == "")
                image.IS_PRINT = null;
            else
                image.IS_PRINT = Convert.ToInt32(dt.Rows[0]["IS_PRINT"].ToString());

            if (dt.Rows[0]["PAGE_ORDER"].ToString() == "")
                image.PAGE_ORDER = null;
            else
                image.PAGE_ORDER = Convert.ToInt32(dt.Rows[0]["PAGE_ORDER"].ToString());

            image.MARK_INF = dt.Rows[0]["MARK_INF"].ToString();
            image.MARK_IMAGE_PATH = dt.Rows[0]["MARK_IMAGE_PATH"].ToString();
            if (dt.Rows[0]["IMAGE_TIME"].ToString() == "")
                image.IMAGE_DATE = null;
            else
                image.IMAGE_DATE = Convert.ToDateTime(dt.Rows[0]["IMAGE_TIME"].ToString());
            return image;
        }

        /// <summary>
        /// 获取指定行的图像记录
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public override IModel GetModel(DataRow dr)
        {
            MImage image = new MImage();
            image.IMAGE_ID = Convert.ToInt32(dr["IMAGE_ID"].ToString());
            image.EXAM_ACCESSION_NUM = dr["EXAM_ACCESSION_NUM"].ToString();
            image.IMAGE_PATH = dr["IMAGE_PATH"].ToString();
            image.IMAGE_TYPE = dr["IMAGE_TYPE"].ToString();

            if (dr["BACK_ID"].ToString() == "")
                image.BACK_ID = null;
            else
                image.BACK_ID = Convert.ToInt32(dr["BACK_ID"].ToString());

            image.VOLUMN_KEY = dr["VOLUMN_KEY"].ToString();

            if (dr["ONLINE_ID"].ToString() == "")
                image.ONLINE_ID = null;
            else
                image.ONLINE_ID = Convert.ToInt32(dr["ONLINE_ID"].ToString());

            image.IMAGE_CLASS = dr["IMAGE_CLASS"].ToString();
            image.IMAGE_EXPLAIN = dr["IMAGE_EXPLAIN"].ToString();

            if (dr["IS_PRINT"].ToString() == "")
                image.IS_PRINT = null;
            else
                image.IS_PRINT = Convert.ToInt32(dr["IS_PRINT"].ToString());

            if (dr["PAGE_ORDER"].ToString() == "")
                image.PAGE_ORDER = null;
            else
                image.PAGE_ORDER = Convert.ToInt32(dr["PAGE_ORDER"].ToString());

            image.MARK_INF = dr["MARK_INF"].ToString();
            image.MARK_IMAGE_PATH = dr["MARK_IMAGE_PATH"].ToString();
            if (dr["IMAGE_TIME"].ToString() == "")
                image.IMAGE_DATE = null;
            else
                image.IMAGE_DATE = Convert.ToDateTime(dr["IMAGE_TIME"].ToString());
            return image;
        }

        /// <summary>
        /// 获取符合条件的图像列表
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
        /// <param name="iimage"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel iimage, string where)
        {
            MImage image = (MImage)iimage;
            Hashtable ht = new Hashtable();
            ht.Add("IMAGE_ID", image.IMAGE_ID);
            ht.Add("EXAM_ACCESSION_NUM", image.EXAM_ACCESSION_NUM);
            ht.Add("IMAGE_PATH", image.IMAGE_PATH);
            ht.Add("IMAGE_TYPE", image.IMAGE_TYPE);
            ht.Add("BACK_ID", image.BACK_ID);
            ht.Add("VOLUMN_KEY", image.VOLUMN_KEY);
            ht.Add("ONLINE_ID", image.ONLINE_ID);
            ht.Add("IMAGE_CLASS", image.IMAGE_CLASS);
            ht.Add("IMAGE_EXPLAIN", image.IMAGE_EXPLAIN);
            ht.Add("IS_PRINT", image.IS_PRINT);
            ht.Add("PAGE_ORDER", image.PAGE_ORDER);
            ht.Add("MARK_INF", image.MARK_INF);
            ht.Add("IMAGE_TIME", image.IMAGE_DATE);
            ht.Add("MARK_IMAGE_PATH", image.MARK_IMAGE_PATH);
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