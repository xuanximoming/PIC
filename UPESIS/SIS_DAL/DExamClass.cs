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
    /// 对EXAM_CLASS，检查类别表
    /// </summary>
    public class DExamClass : IExamClass
    {
        private string strSql;
        private string TableName = "EXAM_CLASS";
        public DExamClass()
            : base(GetConfig.GetSisConnStr())
        {
        }

        /// <summary>
        /// 插入一条检查类别记录
        /// </summary>
        /// <param name="iexamClass"></param>
        /// <returns></returns>
        public override int Add(IModel iexamClass)
        {
            MExamClass examClass = (MExamClass)iexamClass;
            Hashtable ht = new Hashtable();
            ht.Add("EXAM_CLASS", examClass.EXAM_CLASS);
            ht.Add("EXAM_SUB_CLASS", examClass.EXAM_SUB_CLASS);
            ht.Add("DICOM_MODALITY", examClass.DICOM_MODALITY);
            ht.Add("LOCAL_ID_CLASS", examClass.LOCAL_ID_CLASS);
            ht.Add("TAG_IMAGE_NAME", examClass.TAG_IMAGE_NAME);
            ht.Add("DEVICE", examClass.DEVICE);
            ht.Add("SORT_ID", examClass.SORT_ID);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 批量插入检查类别记录
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int AddMore(Hashtable ht2)
        {
            MExamClass examClass = new MExamClass();
            Hashtable ht = new Hashtable();
            Hashtable htstr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    examClass = (MExamClass)ht2[i];
                    ht.Add("EXAM_CLASS", examClass.EXAM_CLASS);
                    ht.Add("EXAM_SUB_CLASS", examClass.EXAM_SUB_CLASS);
                    ht.Add("DICOM_MODALITY", examClass.DICOM_MODALITY);
                    ht.Add("LOCAL_ID_CLASS", examClass.LOCAL_ID_CLASS);
                    ht.Add("TAG_IMAGE_NAME", examClass.TAG_IMAGE_NAME);
                    ht.Add("DEVICE", examClass.DEVICE);
                    ht.Add("SORT_ID", examClass.SORT_ID);
                    htstr.Add(i, StringConstructor.InsertSql(TableName, ht).ToString());
                }
                return ExecuteNonSql(htstr);

            }
            else
                return 0;
        }

        /// <summary>
        /// 查询是否存在指定的检查类别记录
        /// </summary>
        /// <param name="iexamClass"></param>
        /// <returns></returns>
        public override bool Exists(IModel iexamClass)
        {
            MExamClass examClass = (MExamClass)iexamClass;
            strSql = "select * from " + TableName + " where EXAM_CLASS='" + examClass.EXAM_CLASS + "' and " +
                     "EXAM_SUB_CLASS = '" + examClass.EXAM_SUB_CLASS + "'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取指定检查类别名称、检查子类名称的检查类别记录
        /// </summary>
        /// <param name="EXAM_CLASS"></param>
        /// <param name="EXAM_SUB_CLASS"></param>
        /// <returns></returns>
        public override IModel GetModel(string EXAM_CLASS, string EXAM_SUB_CLASS)
        {
            strSql = "select * from " + TableName + " where Exam_Class = '" + EXAM_CLASS + "' and EXAM_SUB_CLASS = '" + EXAM_SUB_CLASS + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MExamClass examClass = new MExamClass();
            examClass.EXAM_CLASS = dt.Rows[0]["EXAM_CLASS"].ToString();
            examClass.EXAM_SUB_CLASS = dt.Rows[0]["EXAM_SUB_CLASS"].ToString();
            examClass.DICOM_MODALITY = dt.Rows[0]["DICOM_MODALITY"].ToString();
            examClass.LOCAL_ID_CLASS = dt.Rows[0]["LOCAL_ID_CLASS"].ToString();
            examClass.TAG_IMAGE_NAME = dt.Rows[0]["TAG_IMAGE_NAME"].ToString();
            examClass.DEVICE = dt.Rows[0]["DEVICE"].ToString();
            if (dt.Rows[0]["SORT_ID"] == null)
                examClass.SORT_ID = null;
            else
                examClass.SORT_ID = Convert.ToInt32(dt.Rows[0]["SORT_ID"].ToString());
            return examClass;
        }

        /// <summary>
        /// 获取符合条件的检查类别列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 获取符合条件的检查类别字段
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetExamClass(string where)
        {
            strSql = " select  exam_class from " + TableName + " "+where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定的检查类别记录
        /// </summary>
        /// <param name="iexamClass"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel iexamClass, string where)
        {
            MExamClass examClass = (MExamClass)iexamClass;
            Hashtable ht = new Hashtable();
            ht.Add("EXAM_CLASS", examClass.EXAM_CLASS);
            ht.Add("EXAM_SUB_CLASS", examClass.EXAM_SUB_CLASS);
            ht.Add("DICOM_MODALITY", examClass.DICOM_MODALITY);
            ht.Add("LOCAL_ID_CLASS", examClass.LOCAL_ID_CLASS);
            ht.Add("TAG_IMAGE_NAME", examClass.TAG_IMAGE_NAME);
            ht.Add("DEVICE", examClass.DEVICE);
            ht.Add("SORT_ID", examClass.SORT_ID);
            return (ExecuteSql(StringConstructor.UpdateSql(TableName, ht,where).ToString()));
        }

        /// <summary>
        /// 批量更新检查类别记录
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int UpdateMore(Hashtable ht2)
        {
            MExamClass examClass = new MExamClass();
            Hashtable ht = new Hashtable();
            Hashtable htStr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    examClass = (MExamClass)ht2[i];
                    ht.Add("EXAM_CLASS", examClass.EXAM_CLASS);
                    ht.Add("EXAM_SUB_CLASS", examClass.EXAM_SUB_CLASS);
                    ht.Add("DICOM_MODALITY", examClass.DICOM_MODALITY);
                    ht.Add("LOCAL_ID_CLASS", examClass.LOCAL_ID_CLASS);
                    ht.Add("TAG_IMAGE_NAME", examClass.TAG_IMAGE_NAME);
                    ht.Add("DEVICE", examClass.DEVICE);
                    ht.Add("SORT_ID", examClass.SORT_ID);
                    htStr.Add(i, StringConstructor.UpdateSql(TableName, ht, " where EXAM_CLASS='" + examClass.EXAM_CLASS + "' and EXAM_SUB_CLASS='" + examClass.EXAM_SUB_CLASS + "'"));
                }

                return ExecuteNonSql(htStr);
            }
            return 0;
        }

        /// <summary>
        /// 删除符合条件的检查类别记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }

        /// <summary>
        /// 获取所有检查类别名称
        /// </summary>
        /// <returns></returns>
        public override DataSet GetData()
        {
            strSql = " select exam_class from  " + TableName + " group by exam_class ";
            return GetDataSet(strSql);
        }
    }
}