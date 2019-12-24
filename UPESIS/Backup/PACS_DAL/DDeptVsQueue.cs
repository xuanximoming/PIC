using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Collections;
using ILL;
using PACS_Model;

namespace PACS_DAL
{
    /// <summary>
    /// DEPT_VS_QUEUE�����Ŷӿ��������Ҷ���
    /// </summary>
    public class DDeptVsQueue : IDeptVsQueue
    {
        private string strSql;
        private string TableName = "DEPT_VS_QUEUE";
        public DDeptVsQueue()
            : base(GetConfig.GetPacsConnStr())
        {
        }

        /// <summary>
        /// ����һ�����м�¼
        /// </summary>
        /// <param name="ideptVsQueue"></param>
        /// <returns></returns>
        public override int Add(IModel ideptVsQueue)
        {
            MDeptVsQueue deptVsQueue = (MDeptVsQueue)ideptVsQueue;
            Hashtable ht = new Hashtable();
            ht.Add("QUEUE_ID", deptVsQueue.QUEUE_ID);
            ht.Add("DEPT_CODE", deptVsQueue.DEPT_CODE);
            ht.Add("QUEUE_NAME", deptVsQueue.QUEUE_NAME);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// ��ѯ�Ƿ����ָ���Ķ��м�¼
        /// </summary>
        /// <param name="ideptVsQueue"></param>
        /// <returns></returns>
        public override bool Exists(IModel ideptVsQueue)
        {
            MDeptVsQueue deptVsQueue = (MDeptVsQueue)ideptVsQueue;
            strSql = "select * from " + TableName + " where QUEUE_ID=" + deptVsQueue.QUEUE_ID;
            return recordIsExist(strSql);
        }

        /// <summary>
        /// ��ȡָ������ID�Ķ��м�¼
        /// </summary>
        /// <param name="QUEUE_ID"></param>
        /// <returns></returns>
        public override IModel GetModel(string QUEUE_ID)
        {
            strSql = "select * from " + TableName + " where QUEUE_ID = " + QUEUE_ID;
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MDeptVsQueue deptVsQueue = new MDeptVsQueue();
            deptVsQueue.QUEUE_ID = Convert.ToInt32(dt.Rows[0]["QUEUE_ID"].ToString());
            deptVsQueue.DEPT_CODE = dt.Rows[0]["DEPT_CODE"].ToString();
            deptVsQueue.QUEUE_NAME = dt.Rows[0]["QUEUE_NAME"].ToString();
            return deptVsQueue;
        }

        /// <summary>
        /// ��ȡ���������Ķ����б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// ����ָ���Ķ���
        /// </summary>
        /// <param name="ideptVsQueue"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel ideptVsQueue, string where)
        {
            MDeptVsQueue deptVsQueue = (MDeptVsQueue)ideptVsQueue;
            Hashtable ht = new Hashtable();
            ht.Add("QUEUE_ID", deptVsQueue.QUEUE_ID);
            ht.Add("DEPT_CODE", deptVsQueue.DEPT_CODE);
            ht.Add("QUEUE_NAME", deptVsQueue.QUEUE_NAME);
            return (ExecuteSql(StringConstructor.UpdateSql(TableName, ht,where).ToString()));
        }

        /// <summary>
        /// ɾ�����������Ķ���
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}
