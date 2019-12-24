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
    /// USER_DEPT_DICT,即用户科室表
    /// </summary>
    public class DClinicOfficeDict : IClinicOfficeDict
    {
        private string strSql;
        private string TableName = "USER_DEPT_DICT";
        public DClinicOfficeDict()
            : base(GetConfig.GetPacsConnStr())
        {
        }

        /// <summary>
        /// 插入一条用户科室记录
        /// </summary>
        /// <param name="iuserDeptDict"></param>
        /// <returns></returns>
        public override int Add(IModel iuserDeptDict)
        {
            MUserDeptDict userDeptDict = (MUserDeptDict)iuserDeptDict;
            Hashtable ht = new Hashtable();
            ht.Add("DEPT_AREA", userDeptDict.DEPT_AREA);
            ht.Add("DEPT_CODE", userDeptDict.DEPT_CODE);
            ht.Add("DEPT_NAME", userDeptDict.DEPT_NAME);
            ht.Add("RPT_HANDUP_STYLE", userDeptDict.RPT_HANDUP_STYLE);
            ht.Add("RPT_ISSUANCE_STYLE", userDeptDict.RPT_ISSUANCE_STYLE);
            ht.Add("STUDY_UID_HEADER", userDeptDict.STUDY_UID_HEADER);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 查询是否存在指定的用户科室记录
        /// </summary>
        /// <param name="iuserDeptDict"></param>
        /// <returns></returns>
        public override bool Exists(IModel iuserDeptDict)
        {
            MUserDeptDict userDeptDict = (MUserDeptDict)iuserDeptDict;
            strSql = "select * from " + TableName + " where DEPT_CODE='" + userDeptDict.DEPT_CODE + "'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取符合条件的用户科室列表
        /// </summary>
        /// <param name="DEPT_CODE"></param>
        /// <returns></returns>
        public override IModel GetModel(string DEPT_CODE)
        {
            strSql = "select * from " + TableName + " where DEPT_CODE = '" + DEPT_CODE + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MUserDeptDict userDeptDict = new MUserDeptDict();
            userDeptDict.DEPT_AREA =dt.Rows[0]["DEPT_AREA"].ToString();
            userDeptDict.DEPT_CODE = dt.Rows[0]["DEPT_CODE"].ToString();
            userDeptDict.DEPT_NAME = dt.Rows[0]["DEPT_NAME"].ToString();
            userDeptDict.STUDY_UID_HEADER = dt.Rows[0]["STUDY_UID_HEADER"].ToString();

            if (dt.Rows[0]["RPT_HANDUP_STYLE"].ToString() == "")
                userDeptDict.RPT_HANDUP_STYLE = null;
            else
                userDeptDict.RPT_HANDUP_STYLE = Convert.ToInt32(dt.Rows[0]["RPT_HANDUP_STYLE"].ToString());

            if (dt.Rows[0]["RPT_ISSUANCE_STYLE"].ToString() == "")
                userDeptDict.RPT_ISSUANCE_STYLE = null;
            else
                userDeptDict.RPT_ISSUANCE_STYLE = Convert.ToInt32(dt.Rows[0]["RPT_ISSUANCE_STYLE"].ToString());

            return userDeptDict;
        }

        /// <summary>
        /// 获取符合条件的用户科室列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定的用户科室记录
        /// </summary>
        /// <param name="iuserDeptDict"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel iuserDeptDict, string where)
        {
            MUserDeptDict userDeptDict = (MUserDeptDict)iuserDeptDict;
            Hashtable ht = new Hashtable();
            ht.Add("DEPT_AREA", userDeptDict.DEPT_AREA);
            ht.Add("DEPT_CODE", userDeptDict.DEPT_CODE);
            ht.Add("DEPT_NAME", userDeptDict.DEPT_NAME);
            ht.Add("RPT_HANDUP_STYLE", userDeptDict.RPT_HANDUP_STYLE);
            ht.Add("RPT_ISSUANCE_STYLE", userDeptDict.RPT_ISSUANCE_STYLE);
            ht.Add("STUDY_UID_HEADER", userDeptDict.STUDY_UID_HEADER);
            return (ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString()));
        }

        /// <summary>
        /// 删除符合条件的用户科室记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }

        /// <summary>
        /// 获取符合条件的用户科室记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataSet GetData(string where)
        {
            strSql = "select dept_name,dept_code " + TableName + " where " + where;
            return GetDataSet(strSql);
        }
    }
}
