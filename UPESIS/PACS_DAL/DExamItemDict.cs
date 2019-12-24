using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Collections;
using PACS_Model;
using ILL;

namespace PACS_DAL
{
    /// <summary>
    /// 操作EXAM_ITEM_DICT，即检查项目字典
    /// </summary>
    public class DExamItemDict : IExamItemDict
    {
        private string strSql;
        private string TableName = "EXAM_ITEM_DICT";
        public DExamItemDict()
            : base(GetConfig.GetPacsConnStr())
        {
        }

        /// <summary>
        /// 插入一条检查项目记录
        /// </summary>
        /// <param name="iexamItemDict"></param>
        /// <returns></returns>
        public override int Add(IModel iexamItemDict)
        {
            MExamItemDict examItemDict = (MExamItemDict)iexamItemDict;
            Hashtable ht = new Hashtable();
            ht.Add("EXAM_ITEM_CODE", examItemDict.EXAM_ITEM_CODE);
            ht.Add("EXAM_ITEM_NAME", examItemDict.EXAM_ITEM_NAME);
            ht.Add("INPUT_CODE", examItemDict.INPUT_CODE);
            ht.Add("EXAM_CLASS", examItemDict.EXAM_CLASS);
            ht.Add("EXAM_SUB_CLASS", examItemDict.EXAM_SUB_CLASS);
            ht.Add("SORT_ID", examItemDict.SORT_ID);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 批量插入检查项目记录
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int AddMore(Hashtable ht2)
        {
            MExamItemDict examItemDict = new MExamItemDict();
            Hashtable ht = new Hashtable();
            Hashtable htstr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    examItemDict = (MExamItemDict)ht2[i];
                    ht.Add("EXAM_ITEM_CODE", examItemDict.EXAM_ITEM_CODE);
                    ht.Add("EXAM_ITEM_NAME", examItemDict.EXAM_ITEM_NAME);
                    ht.Add("INPUT_CODE", examItemDict.INPUT_CODE);
                    ht.Add("EXAM_CLASS", examItemDict.EXAM_CLASS);
                    ht.Add("EXAM_SUB_CLASS", examItemDict.EXAM_SUB_CLASS);
                    ht.Add("SORT_ID", examItemDict.SORT_ID);
                    htstr.Add(i, StringConstructor.InsertSql(TableName, ht).ToString());
                }
                return ExecuteNonSql(htstr);

            }
            else
                return 0;
        }

        /// <summary>
        /// 查询是否存在指定的检查项目记录
        /// </summary>
        /// <param name="iexamItemDict"></param>
        /// <returns></returns>
        public override bool Exists(IModel iexamItemDict)
        {
            MExamItemDict examItemDict = (MExamItemDict)iexamItemDict;
            strSql = "select * from " + TableName + " where EXAM_ITEM_CODE='" + examItemDict.EXAM_ITEM_CODE + "' and " +
                     "EXAM_SUB_CLASS = '" + examItemDict.EXAM_SUB_CLASS + "'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取指定检查项目代码、检查项目子类的检查项目记录
        /// </summary>
        /// <param name="EXAM_ITEM_CODE"></param>
        /// <param name="EXAM_SUB_CLASS"></param>
        /// <returns></returns>
        public override IModel GetModel(string EXAM_ITEM_CODE, string EXAM_SUB_CLASS)
        {
            strSql = "select * from " + TableName + " where EXAM_ITEM_CODE = '" + EXAM_ITEM_CODE + "' and EXAM_SUB_CLASS = '" + EXAM_SUB_CLASS + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MExamItemDict examItemDict = new MExamItemDict();
            examItemDict.EXAM_ITEM_CODE = dt.Rows[0]["EXAM_ITEM_CODE"].ToString();
            examItemDict.EXAM_ITEM_NAME = dt.Rows[0]["EXAM_ITEM_NAME"].ToString();
            examItemDict.INPUT_CODE = dt.Rows[0]["INPUT_CODE"].ToString();
            examItemDict.EXAM_CLASS = dt.Rows[0]["EXAM_CLASS"].ToString();
            examItemDict.EXAM_SUB_CLASS = dt.Rows[0]["EXAM_SUB_CLASS"].ToString();

            if (dt.Rows[0]["SORT_ID"].ToString() == "")
                examItemDict.SORT_ID = null;
            else
                examItemDict.SORT_ID = Convert.ToInt32(dt.Rows[0]["SORT_ID"].ToString());

            return examItemDict;
        }

        /// <summary>
        /// 获取符合条件的检查项目列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }
        public override int Update(IModel iexamItemDict, string where)
        {
            MExamItemDict examItemDict = (MExamItemDict)iexamItemDict;
            Hashtable ht = new Hashtable();
            ht.Add("EXAM_ITEM_CODE", examItemDict.EXAM_ITEM_CODE);
            ht.Add("EXAM_ITEM_NAME", examItemDict.EXAM_ITEM_NAME);
            ht.Add("INPUT_CODE", examItemDict.INPUT_CODE);
            ht.Add("EXAM_CLASS", examItemDict.EXAM_CLASS);
            ht.Add("EXAM_SUB_CLASS", examItemDict.EXAM_SUB_CLASS);
            ht.Add("SORT_ID", examItemDict.SORT_ID);
            return (ExecuteSql(StringConstructor.UpdateSql(TableName, ht,where).ToString()));
        }

        /// <summary>
        /// 批量更新检查项目记录
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int UpdateMore(Hashtable ht2)
        {
            MExamItemDict examItemDict = new MExamItemDict();
            Hashtable htStr = new Hashtable();
            Hashtable ht = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    examItemDict = (MExamItemDict)ht2[i];
                    ht.Add("EXAM_ITEM_CODE", examItemDict.EXAM_ITEM_CODE);
                    ht.Add("EXAM_ITEM_NAME", examItemDict.EXAM_ITEM_NAME);
                    ht.Add("INPUT_CODE", examItemDict.INPUT_CODE);
                    ht.Add("EXAM_CLASS", examItemDict.EXAM_CLASS);
                    ht.Add("EXAM_SUB_CLASS", examItemDict.EXAM_SUB_CLASS);
                    ht.Add("SORT_ID", examItemDict.SORT_ID);
                    htStr.Add(i, StringConstructor.UpdateSql(TableName, ht, " where  EXAM_ITEM_CODE = '" + examItemDict.EXAM_ITEM_CODE + "' and EXAM_SUB_CLASS = '" + examItemDict.EXAM_SUB_CLASS + "'"));
                }

                return ExecuteNonSql(htStr);
            }
            return 0;
        }

        /// <summary>
        /// 删除符合条件的检查项目记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}
