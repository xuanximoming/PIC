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
    /// 对PRINT_TEMPLATE_DICT，打印模板字典
    /// </summary>
    public class DPrintTemplateDict : IPrintTemplateDict
    {
        private string strSql;
        private string TableName = "PRINT_TEMPLATE_DICT";
        public DPrintTemplateDict()
            : base(GetConfig.GetSisConnStr())
        {
        }

        /// <summary>
        /// 插入一条打印模板记录
        /// </summary>
        /// <param name="iPrintTemplateDict"></param>
        /// <returns></returns>
        public override int Add(IModel iPrintTemplateDict)
        {
            MPrintTemplateDict mPrintTemplateDict = (MPrintTemplateDict)iPrintTemplateDict;
            Hashtable ht = new Hashtable();
            ht.Add("EXAM_CLASS", mPrintTemplateDict.EXAM_CLASS);
            ht.Add("EXAM_SUB_CLASS", mPrintTemplateDict.EXAM_SUB_CLASS);
            ht.Add("FILE_NAME", mPrintTemplateDict.FILE_NAME);
            ht.Add("PRINT_TEMPLATE", mPrintTemplateDict.PRINT_TEMPLATE);
            ht.Add("PRINT_TEMPLATE_ID", mPrintTemplateDict.PRINT_TEMPLATE_ID);
            ht.Add("FIELD_INF", mPrintTemplateDict.FIELD_INF);
            ht.Add("FILE_DATE_TIME", mPrintTemplateDict.FILE_DATE_TIME);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht), ht));
        }

        /// <summary>
        /// 查询是否存在指定的打印模板记录
        /// </summary>
        /// <param name="iPrintTemplateDict"></param>
        /// <returns></returns>
        public override bool Exists(IModel iPrintTemplateDict)
        {
            MPrintTemplateDict mPrintTemplateDict = (MPrintTemplateDict)iPrintTemplateDict;
            strSql = "select PRINT_TEMPLATE_ID from " + TableName + " where PRINT_TEMPLATE_ID=" + mPrintTemplateDict.PRINT_TEMPLATE_ID;
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取指定ID的打印模板记录
        /// </summary>
        /// <param name="PRINT_TEMPLATE_ID"></param>
        /// <returns></returns>
        public override IModel GetModel(string PRINT_TEMPLATE_ID)
        {
            strSql = "select * from " + TableName + " where PRINT_TEMPLATE_ID = " + PRINT_TEMPLATE_ID ;
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MPrintTemplateDict mPrintTemplateDict = new MPrintTemplateDict();
            mPrintTemplateDict.EXAM_CLASS = dt.Rows[0]["EXAM_CLASS"].ToString();
            mPrintTemplateDict.EXAM_SUB_CLASS = dt.Rows[0]["EXAM_SUB_CLASS"].ToString();
            mPrintTemplateDict.FILE_NAME =(byte[])dt.Rows[0]["FILE_NAME"];
            mPrintTemplateDict.PRINT_TEMPLATE = dt.Rows[0]["PRINT_TEMPLATE"].ToString();
            mPrintTemplateDict.FIELD_INF = dt.Rows[0]["FIELD_INF"].ToString();
            mPrintTemplateDict.PRINT_TEMPLATE_ID = Convert.ToInt32(dt.Rows[0]["PRINT_TEMPLATE_ID"].ToString());
            mPrintTemplateDict.FILE_DATE_TIME = Convert.ToDateTime(dt.Rows[0]["FILE_DATE_TIME"].ToString());
            return mPrintTemplateDict;
        }

        /// <summary>
        /// 获取指定检查类别、检查子类的打印模板记录
        /// </summary>
        /// <param name="EXAM_CLASS"></param>
        /// <param name="EXAM_SUB_CLASS"></param>
        /// <returns></returns>
        public override IModel GetModel(string EXAM_CLASS, string EXAM_SUB_CLASS)
        {
            strSql = "select * from " + TableName + " where EXAM_CLASS = '" + EXAM_CLASS + "' and EXAM_SUB_CLASS='" + EXAM_SUB_CLASS + "' order by sord_id desc";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MPrintTemplateDict mPrintTemplateDict = new MPrintTemplateDict();
            mPrintTemplateDict.EXAM_CLASS = dt.Rows[0]["EXAM_CLASS"].ToString();
            mPrintTemplateDict.EXAM_SUB_CLASS = dt.Rows[0]["EXAM_SUB_CLASS"].ToString();
            mPrintTemplateDict.FILE_NAME = (byte[])dt.Rows[0]["FILE_NAME"];
            mPrintTemplateDict.PRINT_TEMPLATE = dt.Rows[0]["PRINT_TEMPLATE"].ToString();
            mPrintTemplateDict.FIELD_INF = dt.Rows[0]["FIELD_INF"].ToString();
            mPrintTemplateDict.PRINT_TEMPLATE_ID = Convert.ToInt32(dt.Rows[0]["PRINT_TEMPLATE_ID"].ToString());
            mPrintTemplateDict.FILE_DATE_TIME = Convert.ToDateTime(dt.Rows[0]["FILE_DATE_TIME"].ToString());
            return mPrintTemplateDict;
        }

        /// <summary>
        /// 获取指定行的打印模板记录
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public override IModel GetModel(DataRow dr)
        {
            MPrintTemplateDict mPrintTemplateDict = new MPrintTemplateDict();
            mPrintTemplateDict.EXAM_CLASS = dr["EXAM_CLASS"].ToString();
            mPrintTemplateDict.EXAM_SUB_CLASS = dr["EXAM_SUB_CLASS"].ToString();
            mPrintTemplateDict.FILE_NAME = (byte[])dr["FILE_NAME"];
            mPrintTemplateDict.PRINT_TEMPLATE = dr["PRINT_TEMPLATE"].ToString();
            mPrintTemplateDict.FIELD_INF = dr["FIELD_INF"].ToString();
            mPrintTemplateDict.PRINT_TEMPLATE_ID = Convert.ToInt32(dr["PRINT_TEMPLATE_ID"].ToString());
            mPrintTemplateDict.FILE_DATE_TIME = Convert.ToDateTime(dr["FILE_DATE_TIME"].ToString());
            return mPrintTemplateDict;
        }

        /// <summary>
        /// 获取符合条件的打印模板列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定的打印模板记录
        /// </summary>
        /// <param name="iPrintTemplateDict"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel iPrintTemplateDict, string where)
        {
            MPrintTemplateDict mPrintTemplateDict = (MPrintTemplateDict)iPrintTemplateDict;
            Hashtable ht = new Hashtable();
            ht.Add("EXAM_CLASS", mPrintTemplateDict.EXAM_CLASS);
            ht.Add("EXAM_SUB_CLASS", mPrintTemplateDict.EXAM_SUB_CLASS);
            ht.Add("FILE_NAME", mPrintTemplateDict.FILE_NAME);
            ht.Add("PRINT_TEMPLATE", mPrintTemplateDict.PRINT_TEMPLATE);
            ht.Add("PRINT_TEMPLATE_ID", mPrintTemplateDict.PRINT_TEMPLATE_ID);
            ht.Add("FIELD_INF", mPrintTemplateDict.FIELD_INF);
            ht.Add("FILE_DATE_TIME", mPrintTemplateDict.FILE_DATE_TIME);
            return (ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString(),ht));
        }

        /// <summary>
        /// 删除符合条件的打印模板记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}