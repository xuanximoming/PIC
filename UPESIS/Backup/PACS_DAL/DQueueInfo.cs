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
    /// 操作QUEUE_INFO，即排队信息
    /// </summary>
    public class DQueueInfo : IQueueInfo
    {
        private string strSql;
        private string TableName = "QUEUE_INFO";
        public DQueueInfo()
            : base(GetConfig.GetPacsConnStr())
        {
        }

        /// <summary>
        /// 插入一条队列信息记录
        /// </summary>
        /// <param name="iqueueInfo"></param>
        /// <returns></returns>
        public override int Add(IModel iqueueInfo)                                 
        {
            MQueueInfo queueInfo = (MQueueInfo)iqueueInfo;
            Hashtable ht = new Hashtable();
            ht.Add("EXAM_ACCESSION_NUM", queueInfo.EXAM_ACCESSION_NUM);
            ht.Add("PATIENT_ID", queueInfo.PATIENT_ID);
            ht.Add("PATIENT_NAME", queueInfo.PATIENT_NAME);
            ht.Add("PATIENT_SEX", queueInfo.PATIENT_SEX);
            ht.Add("CLINIC_LABLE", queueInfo.CLINIC_LABLE);
            ht.Add("DOCTOR", queueInfo.DOCTOR);
            ht.Add("SERIAL_NO", queueInfo.SERIAL_NO);
            ht.Add("VISIT_DATE", queueInfo.VISIT_DATE);
            ht.Add("DIAG_FLAG", queueInfo.DIAG_FLAG);
            ht.Add("VISIT_DEPT", queueInfo.VISIT_DEPT);
            ht.Add("ORDER_NO", queueInfo.ORDER_NO);
            ht.Add("VISIT_NO", queueInfo.VISIT_NO);
            ht.Add("REG_DATE", queueInfo.REG_DATE);
            ht.Add("IS_REDIAG", queueInfo.IS_REDIAG);
            ht.Add("QUEUE_NAME", queueInfo.QUEUE_NAME);
            ht.Add("PRINT_NO", queueInfo.PRINT_NO);
            ht.Add("PASSED", queueInfo.PASSED);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 查询是否存在指定队列记录的
        /// </summary>
        /// <param name="iqueueInfo"></param>
        /// <returns></returns>
        public override bool Exists(IModel iqueueInfo)
        {
            MQueueInfo queueInfo = (MQueueInfo)iqueueInfo;
            strSql = "select * from " + TableName + " where EXAM_ACCESSION_NUM='" + queueInfo.EXAM_ACCESSION_NUM + "'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取指定检查申请号的队列信息
        /// </summary>
        /// <param name="EXAM_ACCESSION_NUM"></param>
        /// <returns></returns>
        public override IModel GetModel(string EXAM_ACCESSION_NUM)
        {
            strSql = "select * from " + TableName + " where EXAM_ACCESSION_NUM = '" + EXAM_ACCESSION_NUM + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MQueueInfo queueInfo = new MQueueInfo();
            queueInfo.EXAM_ACCESSION_NUM = dt.Rows[0]["EXAM_ACCESSION_NUM"].ToString();
            queueInfo.PATIENT_ID = dt.Rows[0]["PATIENT_ID"].ToString();

            queueInfo.PATIENT_NAME = dt.Rows[0]["PATIENT_NAME"].ToString();
            queueInfo.PATIENT_SEX = dt.Rows[0]["PATIENT_SEX"].ToString();
            queueInfo.CLINIC_LABLE = dt.Rows[0]["CLINIC_LABLE"].ToString();
            queueInfo.DOCTOR = dt.Rows[0]["DOCTOR"].ToString();
            if (dt.Rows[0]["SERIAL_NO"].ToString() == "")
                queueInfo.SERIAL_NO = null;
            else

                queueInfo.SERIAL_NO = Convert.ToInt32(dt.Rows[0]["SERIAL_NO"].ToString());

            if (dt.Rows[0]["VISIT_DATE"].ToString() == "")
                queueInfo.VISIT_DATE = null;
            else
                queueInfo.VISIT_DATE = Convert.ToDateTime(dt.Rows[0]["VISIT_DATE"].ToString());

            if (dt.Rows[0]["DIAG_FLAG"].ToString() == "")
                queueInfo.DIAG_FLAG = null;
            else
                queueInfo.DIAG_FLAG = Convert.ToInt32(dt.Rows[0]["DIAG_FLAG"].ToString());

            if (dt.Rows[0]["ORDER_NO"].ToString() == "")
                queueInfo.ORDER_NO = null;
            else
                queueInfo.ORDER_NO = Convert.ToDecimal(dt.Rows[0]["ORDER_NO"].ToString());

            if (dt.Rows[0]["VISIT_NO"].ToString() == "")
                queueInfo.VISIT_NO = null;
            else
                queueInfo.VISIT_NO = Convert.ToInt32(dt.Rows[0]["VISIT_NO"].ToString());

            if (dt.Rows[0]["REG_DATE"].ToString() == "")
                queueInfo.REG_DATE = null;
            else
                queueInfo.REG_DATE = Convert.ToDateTime(dt.Rows[0]["REG_DATE"].ToString());

            if (dt.Rows[0]["PRINT_NO"].ToString() == "")
                queueInfo.PRINT_NO = null;
            else
                queueInfo.PRINT_NO = Convert.ToInt32(dt.Rows[0]["PRINT_NO"].ToString());

            if (dt.Rows[0]["PASSED"].ToString() == "")
                queueInfo.PASSED = null;
            else
                queueInfo.PASSED = Convert.ToInt32(dt.Rows[0]["PASSED"].ToString());

            queueInfo.VISIT_DEPT = dt.Rows[0]["VISIT_DEPT"].ToString();
            queueInfo.IS_REDIAG = dt.Rows[0]["IS_REDIAG"].ToString();
            queueInfo.QUEUE_NAME = dt.Rows[0]["QUEUE_NAME"].ToString();
            return queueInfo;
        }

        /// <summary>
        /// 获取符合条件的队列信息列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定队列信息记录
        /// </summary>
        /// <param name="iqueueInfo"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel iqueueInfo, string where)
        {
            MQueueInfo queueInfo = (MQueueInfo)iqueueInfo;
            Hashtable ht = new Hashtable();
            ht.Add("EXAM_ACCESSION_NUM", queueInfo.EXAM_ACCESSION_NUM);
            ht.Add("PATIENT_ID", queueInfo.PATIENT_ID);
            ht.Add("PATIENT_NAME", queueInfo.PATIENT_NAME);
            ht.Add("PATIENT_SEX", queueInfo.PATIENT_SEX);
            ht.Add("CLINIC_LABLE", queueInfo.CLINIC_LABLE);
            ht.Add("DOCTOR", queueInfo.DOCTOR);
            ht.Add("SERIAL_NO", queueInfo.SERIAL_NO);
            ht.Add("VISIT_DATE", queueInfo.VISIT_DATE);
            ht.Add("DIAG_FLAG", queueInfo.DIAG_FLAG);
            ht.Add("VISIT_DEPT", queueInfo.VISIT_DEPT);
            ht.Add("ORDER_NO", queueInfo.ORDER_NO);
            ht.Add("VISIT_NO", queueInfo.VISIT_NO);
            ht.Add("REG_DATE", queueInfo.REG_DATE);
            ht.Add("IS_REDIAG", queueInfo.IS_REDIAG);
            ht.Add("QUEUE_NAME", queueInfo.QUEUE_NAME);
            ht.Add("PRINT_NO", queueInfo.PRINT_NO);
            ht.Add("PASSED", queueInfo.PASSED);
            return ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString());
        }

        /// <summary>
        /// 删除符合条件的队列信息记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }

        /// <summary>
        /// 获取符合条件的所有队列信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetQueue(string where)
        {
            strSql = " select distinct queue_name from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }
    }
}
