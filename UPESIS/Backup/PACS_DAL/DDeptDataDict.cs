using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using ILL;
using PACS_Model;

namespace PACS_DAL
{
    /// <summary>
    /// DEPT_DATA_DICT，即科室数据字典
    /// </summary>
    public class DDeptDataDict : IDeptDataDict
    {
        private string strSql;
        private string TableName = "DEPT_DATA_DICT";
        public DDeptDataDict()
            : base(GetConfig.GetPacsConnStr())
        {
        }

        /// <summary>
        /// 插入一条科室数据字典
        /// </summary>
        /// <param name="iDeptDataDict"></param>
        /// <returns></returns>
        public override int Add(IModel iDeptDataDict)
        {
            MDeptDataDict deptDataDict = (MDeptDataDict)iDeptDataDict;
            Hashtable ht = new Hashtable();
            ht.Add("AUTHOR", deptDataDict.AUTHOR);
            ht.Add("CREATE_DATE_TIME", deptDataDict.CREATE_DATE_TIME);
            ht.Add("DATA", deptDataDict.DATA);
            ht.Add("DATA_NAME", deptDataDict.DATA_NAME);
            ht.Add("DATA_TYPE", deptDataDict.DATA_TYPE);
            ht.Add("DEPT_CODE", deptDataDict.DEPT_CODE);
            ht.Add("MODIFY_DATE_TIME", deptDataDict.MODIFY_DATE_TIME);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 插入一条科室数据记录
        /// </summary>
        /// <param name="iDeptDataDict"></param>
        /// <param name="sda"></param>
        /// <returns></returns>
        public override int Add1(IModel iDeptDataDict, ref System.Data.OracleClient.OracleDataAdapter sda)
        {
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DataTable dt = ds.Tables[0];

            MDeptDataDict deptDataDict = (MDeptDataDict)iDeptDataDict;
            DataRow dr = dt.NewRow();
            dr["AUTHOR"] = deptDataDict.AUTHOR;
            dr["CREATE_DATE_TIME"] = deptDataDict.CREATE_DATE_TIME;
            dr["DATA"] = deptDataDict.DATA;
            dr["DATA_NAME"] = deptDataDict.DATA_NAME;
            dr["DATA_TYPE"] = deptDataDict.DATA_TYPE;
            dr["DEPT_CODE"] = deptDataDict.DEPT_CODE;
            dr["MODIFY_DATE_TIME"] = deptDataDict.MODIFY_DATE_TIME;
            dt.Rows.Add(dr);
            string strSql = "select * from " + TableName + " where DEPT_CODE='" + deptDataDict.DEPT_CODE +
                     "' and DATA_NAME = '" + deptDataDict.DATA_NAME +
                     "' and DATA_TYPE = '" + deptDataDict.DATA_TYPE + "'";
            return UpdateDataTable1(strSql, dt, sda);
        }

        /// <summary>
        /// 更新指定的科室数据字典记录
        /// </summary>
        /// <param name="iDeptDataDict"></param>
        /// <param name="sda"></param>
        /// <returns></returns>
        public override int Update1(IModel iDeptDataDict, ref System.Data.OracleClient.OracleDataAdapter sda)
        {
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DataTable dt = ds.Tables[0];

            MDeptDataDict deptDataDict = (MDeptDataDict)iDeptDataDict;
            DataRow[] dr = dt.Select("DATA_NAME='" + deptDataDict.DATA_NAME + "' AND DATA_TYPE='" + deptDataDict.DATA_TYPE + "' AND DEPT_CODE='" + deptDataDict.DEPT_CODE + "'");
            if (dr.Length > 1) return -1;
            dr[0]["AUTHOR"] = deptDataDict.AUTHOR;
            dr[0]["CREATE_DATE_TIME"] = deptDataDict.CREATE_DATE_TIME;
            dr[0]["DATA"] = deptDataDict.DATA;
            dr[0]["DATA_NAME"] = deptDataDict.DATA_NAME;
            dr[0]["DATA_TYPE"] = deptDataDict.DATA_TYPE;
            dr[0]["DEPT_CODE"] = deptDataDict.DEPT_CODE;
            dr[0]["MODIFY_DATE_TIME"] = deptDataDict.MODIFY_DATE_TIME;

            string strSql = "select * from " + TableName + " where DEPT_CODE='" + deptDataDict.DEPT_CODE +
                     "' and DATA_NAME = '" + deptDataDict.DATA_NAME +
                     "' and DATA_TYPE = '" + deptDataDict.DATA_TYPE + "'";
            return UpdateDataTable1(strSql, dt, sda);
        }

        /// <summary>
        /// 查询是否存在指定的科室数据记录
        /// </summary>
        /// <param name="iDeptDataDict"></param>
        /// <returns></returns>
        public override bool Exists(IModel iDeptDataDict)
        {
            MDeptDataDict deptDataDict = (MDeptDataDict)iDeptDataDict;
            strSql = "select * from " + TableName + " where DEPT_CODE='" + deptDataDict.DEPT_CODE +
                     "' and DATA_NAME = '" + deptDataDict.DATA_NAME +
                     "' and DATA_TYPE = '" + deptDataDict.DATA_TYPE +
                     "'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取符合条件的科室数据记录
        /// </summary>
        /// <param name="DEPT_CODE"></param>
        /// <param name="DATA_NAME"></param>
        /// <param name="DATA_TYPE"></param>
        /// <param name="MODIFY_DATE_TIME"></param>
        /// <returns></returns>
        public override IModel GetModel(string DEPT_CODE, string DATA_NAME, string DATA_TYPE, DateTime MODIFY_DATE_TIME)
        {
            strSql = "select * from " + TableName + "  where DEPT_CODE='" + DEPT_CODE + "' and DATA_NAME = '" + DATA_NAME +
                     "' and DATA_TYPE ='" + DATA_TYPE + "' and MODIFY_DATE_TIME= to_date('" + MODIFY_DATE_TIME + "','yyyy-mm-dd hh24:mi:ss')";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MDeptDataDict deptDataDict = new MDeptDataDict();
            deptDataDict.AUTHOR = dt.Rows[0]["AUTHOR"].ToString();
            deptDataDict.DATA = dt.Rows[0]["DATA"].ToString();
            deptDataDict.DATA_NAME = dt.Rows[0]["DATA_NAME"].ToString();
            deptDataDict.DATA_TYPE = dt.Rows[0]["DATA_TYPE"].ToString();
            deptDataDict.DEPT_CODE = dt.Rows[0]["DEPT_CODE"].ToString();

            if (dt.Rows[0]["CREATE_DATE_TIME"] == null)
                deptDataDict.CREATE_DATE_TIME = null;
            else
                deptDataDict.CREATE_DATE_TIME = Convert.ToDateTime(dt.Rows[0]["CREATE_DATE_TIME"].ToString());
            if (dt.Rows[0]["MODIFY_DATE_TIME"] == null)
                deptDataDict.MODIFY_DATE_TIME = null;
            else
                deptDataDict.MODIFY_DATE_TIME = Convert.ToDateTime(dt.Rows[0]["MODIFY_DATE_TIME"].ToString());
            return deptDataDict;
        }

        /// <summary>
        /// 获取符合条件的科室数据记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 获取符合条件的科室数据记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <param name="sda"></param>
        /// <returns></returns>
        public override DataSet GetList1(string where, ref System.Data.OracleClient.OracleDataAdapter sda)
        {

            strSql = "select * from " + TableName + " where " + where;
            return GetDataSet1(strSql, ref sda);
        }

        /// <summary>
        /// 更新指定的科室数据字典
        /// </summary>
        /// <param name="iDeptDataDict"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel iDeptDataDict, string where)
        {
            MDeptDataDict deptDataDict = (MDeptDataDict)iDeptDataDict;
            Hashtable ht = new Hashtable();
            ht.Add("AUTHOR", deptDataDict.AUTHOR);
            ht.Add("CREATE_DATE_TIME", deptDataDict.CREATE_DATE_TIME);
            ht.Add("DATA", deptDataDict.DATA);
            ht.Add("DATA_NAME", deptDataDict.DATA_NAME);
            ht.Add("DATA_TYPE", deptDataDict.DATA_TYPE);
            ht.Add("DEPT_CODE", deptDataDict.DEPT_CODE);
            ht.Add("MODIFY_DATE_TIME", deptDataDict.MODIFY_DATE_TIME);
            return ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString());
        }

        /// <summary>
        /// 删除符合条件的科室数据字典
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }

    }
}
