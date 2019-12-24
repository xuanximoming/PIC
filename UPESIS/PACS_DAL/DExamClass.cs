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
    /// ����EXAM_CLASS�����������
    /// </summary>
    public class DExamClass : IExamClass
    {
        private string strSql;
        private string TableName = "EXAM_CLASS";
        public DExamClass()
            : base(GetConfig.GetPacsConnStr())
        {
        }

        /// <summary>
        /// ����һ���������¼
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
            ht.Add("PRINT_PATTERN_CLASS", examClass.PRINT_PATTERN_CLASS);
            ht.Add("DEVICE", examClass.DEVICE);
            ht.Add("SORT_ID", examClass.SORT_ID);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// ��ѯ�Ƿ����ָ���ļ������¼
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
        /// ��ȡ���ϼ����𡢼������ļ������¼
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
            examClass.PRINT_PATTERN_CLASS = dt.Rows[0]["PRINT_PATTERN_CLASS"].ToString();
            examClass.DEVICE = dt.Rows[0]["DEVICE"].ToString();
            if (dt.Rows[0]["SORT_ID"] == null || dt.Rows[0]["SORT_ID"].ToString()=="")
                examClass.SORT_ID = null;
            else
                examClass.SORT_ID = int.Parse(dt.Rows[0]["SORT_ID"].ToString());
            return examClass;
        }

        /// <summary>
        /// ��ȡ���������ļ�������б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// ��ȡ���������ļ�������б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList2(string where)
        {
            strSql = "select distinct " + where + " from " + TableName + " order by " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// ����ָ���ļ�����ļ�¼
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
            ht.Add("PRINT_PATTERN_CLASS", examClass.PRINT_PATTERN_CLASS);
            ht.Add("DEVICE", examClass.DEVICE);
            ht.Add("SORT_ID", examClass.SORT_ID);
            return (ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString()));
        }

        /// <summary>
        /// ɾ�����������ļ�����
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }

        /// <summary>
        /// ����ɾ�����������ļ������¼
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public override int DeleteMore(Hashtable ht)
        {
            this.Open();
            IDbCommand dbCom = dbF.getDBCommand();
            dbCom.Connection = this.dbConn;
            IDbTransaction tran = dbF.getTransaction(this.dbConn);
            dbCom.Transaction = tran;
            dbCom.CommandType = CommandType.Text;
            try
            {
                foreach (DictionaryEntry item in ht)
                {
                    string[] sArray = item.Value.ToString().Split(';');
                    dbCom.CommandText = "Delete EXAM_CLASS where Exam_Class = '" + sArray[0] + "' and EXAM_SUB_CLASS = '" + sArray[1] + "'";
                    dbCom.ExecuteNonQuery();
                }
                tran.Commit();
                return ht.Count;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                return 0;
            }
            finally
            {
                this.Close();
            }
        }

        /// <summary>
        /// ��ȡ���м������¼
        /// </summary>
        /// <returns></returns>
        public override DataSet GetData()
        {
            strSql = " select exam_class from " + TableName + " group by exam_class ";
            return GetDataSet(strSql);
        }
    }
}
