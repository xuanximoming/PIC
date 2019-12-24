using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Collections;
using SIS_Model;
using ILL;

using System.Windows.Forms;

namespace SIS_DAL
{
    /// <summary>
    /// 对KNOWLEDGE_BASE，知识库
    /// </summary>
    public class DKnowledgeBase : IKnowledgeBase
    {
        private string strSql;
        private string TableName = "KNOWLEDGE_BASE";
        public DKnowledgeBase()
            : base(GetConfig.GetSisConnStr())
        {
        }

        /// <summary>
        /// 插入一条知识库记录
        /// </summary>
        /// <param name="iknowledgeBase"></param>
        /// <returns></returns>
        public override int Add(IModel iknowledgeBase)
        {
            MKnowledgeBase mKnowledgeBase = (MKnowledgeBase)iknowledgeBase;
            Hashtable ht = new Hashtable();
            ht.Add("CLINIC_OFFICE_CODE", mKnowledgeBase.CLINIC_OFFICE_CODE);
            ht.Add("IMAGE_COMMENT", mKnowledgeBase.IMAGE_COMMENT);
            ht.Add("DESC_NAME", mKnowledgeBase.DESC_NAME);
            ht.Add("IMAGE_NAME", mKnowledgeBase.IMAGE_NAME);
            ht.Add("IMAGE_DATA", mKnowledgeBase.IMAGE_DATA);
            ht.Add("IMAGE_INDEX", mKnowledgeBase.IMAGE_INDEX);
            ht.Add("VISC_NAME", mKnowledgeBase.VISC_NAME);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString(),ht ));
        }

        /// <summary>
        /// 查询是否存在指定的知识库记录
        /// </summary>
        /// <param name="iknowledgeBase"></param>
        /// <returns></returns>
        public override bool Exists(IModel iknowledgeBase)
        {
            MKnowledgeBase mKnowledgeBase = (MKnowledgeBase)iknowledgeBase;
            strSql = "select * from " + TableName + " where VISC_NAME='" + mKnowledgeBase.VISC_NAME + "' and DESC_NAME = '" + mKnowledgeBase.DESC_NAME + "' and IMAGE_NAME ='" + mKnowledgeBase.IMAGE_NAME + "'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取指定的条件的知识库记录
        /// </summary>
        /// <param name="VISC_NAME"></param>
        /// <param name="DESC_NAME"></param>
        /// <param name="IMAGE_NAME"></param>
        /// <returns></returns>
        public override IModel GetModel(string VISC_NAME, string DESC_NAME, string IMAGE_NAME)
        {
            strSql = "select * from " + TableName + " where VISC_NAME='" + VISC_NAME + "' and DESC_NAME = '" + DESC_NAME + "' and IMAGE_NAME ='" + IMAGE_NAME + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MKnowledgeBase mKnowledgeBase = new MKnowledgeBase();
            mKnowledgeBase.CLINIC_OFFICE_CODE = dt.Rows[0]["CLINIC_OFFICE_CODE"].ToString();
            mKnowledgeBase.IMAGE_COMMENT = dt.Rows[0]["IMAGE_COMMENT"].ToString();
            mKnowledgeBase.DESC_NAME = dt.Rows[0]["DESC_NAME"].ToString();
            mKnowledgeBase.IMAGE_NAME = dt.Rows[0]["IMAGE_NAME"].ToString();
            mKnowledgeBase.IMAGE_DATA = (byte[])dt.Rows[0]["IMAGE_DATA"];
            mKnowledgeBase.VISC_NAME = dt.Rows[0]["VISC_NAME"].ToString();

            if (dt.Rows[0]["IMAGE_INDEX"].ToString() == "")
                mKnowledgeBase.IMAGE_INDEX  = null;
            else
                mKnowledgeBase.IMAGE_INDEX = Convert.ToInt32(dt.Rows[0]["IMAGE_INDEX"].ToString());
            return mKnowledgeBase;
        }

        /// <summary>
        /// 获取符合条件的知识库记录的列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 获取无重复的符合条件的知识库记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList2(string where)
        {
            strSql = "select distinct " + where + " from " + TableName;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定知识库记录
        /// </summary>
        /// <param name="iknowledgeBase"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel iknowledgeBase, string where)
        {
            MKnowledgeBase mKnowledgeBase = (MKnowledgeBase)iknowledgeBase;
            Hashtable ht = new Hashtable();
            ht.Add("CLINIC_OFFICE_CODE", mKnowledgeBase.CLINIC_OFFICE_CODE);
            ht.Add("IMAGE_COMMENT", mKnowledgeBase.IMAGE_COMMENT);
            ht.Add("DESC_NAME", mKnowledgeBase.DESC_NAME);
            ht.Add("IMAGE_NAME", mKnowledgeBase.IMAGE_NAME);
            ht.Add("IMAGE_DATA", mKnowledgeBase.IMAGE_DATA);
            ht.Add("IMAGE_INDEX", mKnowledgeBase.IMAGE_INDEX);
            ht.Add("VISC_NAME", mKnowledgeBase.VISC_NAME);
            return (ExecuteSql(StringConstructor.UpdateSql(TableName, ht,where).ToString(),ht));
        }
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }

        /// <summary>
        /// 批量删除知识库记录
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
                    dbCom.CommandText = "Delete " + TableName + " where " + item.Value.ToString();

                    dbCom.ExecuteNonQuery();
                }
                tran.Commit();
                return ht.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                tran.Rollback();
                MessageBox.Show("数据库事物处理错误！");
                return 0;
            }
            finally
            {
                this.Close();
            }
        }

    }
}