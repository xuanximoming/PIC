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
    /// 对REPORT_TEMPLATE_DICT，报告模板字典
    /// </summary>
    public class DReportTempDict : IReportTempDict
    {
        private string strSql;
        private string TableName = "REPORT_TEMPLATE_DICT";
        public DReportTempDict()
            : base(GetConfig.GetSisConnStr())
        {
        }

        /// <summary>
        /// 插入一条报告模板字典
        /// </summary>
        /// <param name="ireportTempDict"></param>
        /// <returns></returns>
        public override int Add(IModel ireportTempDict)
        {
            MReportTempDict reportTempDict = (MReportTempDict)ireportTempDict;
            Hashtable ht = new Hashtable();
            ht.Add("NODE_ID", reportTempDict.NODE_ID);
            ht.Add("NODE_PARENT_ID", reportTempDict.NODE_PARENT_ID);
            ht.Add("NODE_NAME", reportTempDict.NODE_NAME);
            ht.Add("NODE_DEPICT", reportTempDict.NODE_DEPICT);
            ht.Add("NODE_SIGN", reportTempDict.NODE_SIGN);
            ht.Add("EXAM_CLASS", reportTempDict.EXAM_CLASS);
            ht.Add("INPUT_CODE", reportTempDict.INPUT_CODE);
            ht.Add("DOCTOR_ID", reportTempDict.DOCTOR_ID);
            ht.Add("IS_PRIVATE", reportTempDict.IS_PRIVATE);
            ht.Add("SORT_FLAG", reportTempDict.SORT_FLAG);
            ht.Add("ICD10_CODE", reportTempDict.ICD10_CODE);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 批量插入报告模板字典
        /// </summary>
        /// <param name="rptTemp"></param>
        /// <returns></returns>
        public override int AddMore(object rptTemp)
        {
            Hashtable ht = new Hashtable();
            Hashtable htstr = new Hashtable();
            MReportTempDict[] rptTemps = (MReportTempDict[])rptTemp;
            for (int i = 0; i < rptTemps.Length; i++)
            {
                ht.Clear();
                ht.Add("NODE_ID", rptTemps[i].NODE_ID);
                ht.Add("NODE_PARENT_ID", rptTemps[i].NODE_PARENT_ID);
                ht.Add("NODE_NAME", rptTemps[i].NODE_NAME);
                ht.Add("NODE_DEPICT", rptTemps[i].NODE_DEPICT);
                ht.Add("NODE_SIGN", rptTemps[i].NODE_SIGN);
                ht.Add("EXAM_CLASS", rptTemps[i].EXAM_CLASS);
                ht.Add("INPUT_CODE", rptTemps[i].INPUT_CODE);
                ht.Add("DOCTOR_ID", rptTemps[i].DOCTOR_ID);
                ht.Add("IS_PRIVATE", rptTemps[i].IS_PRIVATE);
                ht.Add("SORT_FLAG", rptTemps[i].SORT_FLAG);
                ht.Add("ICD10_CODE", rptTemps[i].ICD10_CODE);
                htstr.Add(i, StringConstructor.InsertSql(TableName, ht).ToString());
            }
            return ExecuteNonSql(htstr);
        }

        /// <summary>
        /// 查询是否存在指定的报告模板
        /// </summary>
        /// <param name="ireportTempDict"></param>
        /// <returns></returns>
        public override bool Exists(IModel ireportTempDict)
        {
            MReportTempDict reportTempDict = (MReportTempDict)ireportTempDict;
            strSql = "select * from " + TableName + " where NODE_ID=" + reportTempDict.NODE_ID;
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取指定ID的报告模板
        /// </summary>
        /// <param name="NODE_ID"></param>
        /// <returns></returns>
        public override IModel GetModel(string NODE_ID)
        {
            strSql = "select * from " + TableName + " where NODE_ID = " + NODE_ID;
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MReportTempDict reportTempDict = new MReportTempDict();
            reportTempDict.NODE_ID = Convert.ToInt32(dt.Rows[0]["NODE_ID"].ToString());
            reportTempDict.NODE_NAME = dt.Rows[0]["NODE_NAME"].ToString();
            reportTempDict.NODE_DEPICT = dt.Rows[0]["NODE_DEPICT"].ToString();
            reportTempDict.NODE_SIGN = dt.Rows[0]["NODE_SIGN"].ToString();
            reportTempDict.INPUT_CODE = dt.Rows[0]["INPUT_CODE"].ToString();
            reportTempDict.ICD10_CODE = dt.Rows[0]["ICD10_CODE"].ToString();
            reportTempDict.DOCTOR_ID = dt.Rows[0]["DOCTOR_ID"].ToString();

            if (dt.Rows[0]["NODE_PARENT_ID"].ToString() == "")
                reportTempDict.NODE_PARENT_ID = null;
            else
                reportTempDict.NODE_PARENT_ID = Convert.ToInt32(dt.Rows[0]["NODE_PARENT_ID"].ToString());

            if (dt.Rows[0]["IS_PRIVATE"].ToString() == "")
                reportTempDict.IS_PRIVATE = null;
            else
                reportTempDict.IS_PRIVATE = Convert.ToInt32(dt.Rows[0]["IS_PRIVATE"].ToString());

            if (dt.Rows[0]["SORT_FLAG"].ToString() == "")
                reportTempDict.SORT_FLAG = null;
            else
                reportTempDict.SORT_FLAG = Convert.ToInt32(dt.Rows[0]["SORT_FLAG"].ToString());

            reportTempDict.EXAM_CLASS = dt.Rows[0]["EXAM_CLASS"].ToString();

            return reportTempDict;
        }

        /// <summary>
        /// 批量获取指定ID的模板
        /// </summary>
        /// <param name="NODE_ID"></param>
        /// <returns></returns>
        public override IModel[] GetModels(string NODE_ID)
        {
            strSql = "select * from " + TableName + " where NODE_PARENT_ID = " + NODE_ID;
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MReportTempDict[] rptTempDict = new MReportTempDict[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                rptTempDict[i] = new MReportTempDict();
                rptTempDict[i].NODE_ID = Convert.ToInt32(dt.Rows[i]["NODE_ID"].ToString());
                rptTempDict[i].NODE_NAME = dt.Rows[i]["NODE_NAME"].ToString();
                rptTempDict[i].NODE_DEPICT = dt.Rows[i]["NODE_DEPICT"].ToString();
                rptTempDict[i].NODE_SIGN = dt.Rows[i]["NODE_SIGN"].ToString();
                rptTempDict[i].INPUT_CODE = dt.Rows[i]["INPUT_CODE"].ToString();
                rptTempDict[i].ICD10_CODE = dt.Rows[i]["ICD10_CODE"].ToString();
                rptTempDict[i].DOCTOR_ID = dt.Rows[i]["DOCTOR_ID"].ToString();

                if (dt.Rows[i]["NODE_PARENT_ID"].ToString() == "")
                    rptTempDict[i].NODE_PARENT_ID = null;
                else
                    rptTempDict[i].NODE_PARENT_ID = Convert.ToInt32(dt.Rows[i]["NODE_PARENT_ID"].ToString());

                if (dt.Rows[i]["IS_PRIVATE"].ToString() == "")
                    rptTempDict[i].IS_PRIVATE = null;
                else
                    rptTempDict[i].IS_PRIVATE = Convert.ToInt32(dt.Rows[i]["IS_PRIVATE"].ToString());

                if (dt.Rows[i]["SORT_FLAG"].ToString() == "")
                    rptTempDict[i].SORT_FLAG = null;
                else
                    rptTempDict[i].SORT_FLAG = Convert.ToInt32(dt.Rows[i]["SORT_FLAG"].ToString());

                rptTempDict[i].EXAM_CLASS = dt.Rows[i]["EXAM_CLASS"].ToString();
            }
            return rptTempDict;
        }

        /// <summary>
        /// 获取符合条件的模板列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 获取符合条件的模板列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList2(string where)
        {
            strSql = "select * from " + TableName + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 获取指定的SQL语句的模板列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override DataSet GetTable(string sql)
        {
            return GetDataSet(sql);
        }

        /// <summary>
        /// 更新指定的打印模板记录
        /// </summary>
        /// <param name="ireportTempDict"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel ireportTempDict, string where)
        {
            MReportTempDict reportTempDict = (MReportTempDict)ireportTempDict;
            Hashtable ht = new Hashtable();
            ht.Add("NODE_ID", reportTempDict.NODE_ID);
            ht.Add("NODE_PARENT_ID", reportTempDict.NODE_PARENT_ID);
            ht.Add("NODE_NAME", reportTempDict.NODE_NAME);
            ht.Add("NODE_DEPICT", reportTempDict.NODE_DEPICT);
            ht.Add("NODE_SIGN", reportTempDict.NODE_SIGN);
            ht.Add("EXAM_CLASS", reportTempDict.EXAM_CLASS);
            ht.Add("INPUT_CODE", reportTempDict.INPUT_CODE);
            ht.Add("DOCTOR_ID", reportTempDict.DOCTOR_ID);
            ht.Add("IS_PRIVATE", reportTempDict.IS_PRIVATE);
            ht.Add("SORT_FLAG", reportTempDict.SORT_FLAG);
            ht.Add("ICD10_CODE", reportTempDict.ICD10_CODE);
            return (ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString()));
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

        /// <summary>
        /// 批量删除打印模板记录
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
                    dbCom.CommandText = "Delete REPORT_TEMPLATE_DICT where NODE_ID=" + item.Value.ToString();

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