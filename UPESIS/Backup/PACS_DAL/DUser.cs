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
    /// 操作FPAX_USERS,即FPAX用户表
    /// </summary>
    public class DUser : IUser
    {
        private string strSql;
        private string TableName = "FPAX_USERS";
        public DUser()
            : base(GetConfig.GetPacsConnStr())
        {
        }

        /// <summary>
        /// 插入一条用户记录
        /// </summary>
        /// <param name="ifpaxUsers"></param>
        /// <returns></returns>
        public override int Add(IModel ifpaxUsers)
        {
            MUser fpaxUsers = (MUser)ifpaxUsers;
            Hashtable ht = new Hashtable();
            ht.Add("APPLICATION", fpaxUsers.APPLICATION);
            ht.Add("CAPABILITY", fpaxUsers.CAPABILITY);
            ht.Add("CREATE_DATE", fpaxUsers.CREATE_DATE);
            //ht.Add("APPLICATION", fpaxUsers.APPLICATION);
            ht.Add("DB_USER", fpaxUsers.DB_USER);
            ht.Add("DEPT_NAME", fpaxUsers.DEPT_NAME);
            ht.Add("MODULE_CAPABILITY", fpaxUsers.MODULE_CAPABILITY);
            ht.Add("USER_CHAT_CAPABILITY", fpaxUsers.USER_CHAT_CAPABILITY);
            ht.Add("USER_CUSTOM_DATA", fpaxUsers.USER_CUSTOM_DATA);
            ht.Add("USER_DEPT", fpaxUsers.USER_DEPT);
            ht.Add("USER_HANDUP_STYLE", fpaxUsers.USER_HANDUP_STYLE);
            ht.Add("USER_HEADER_ICON", fpaxUsers.USER_HEADER_ICON);
            ht.Add("USER_ID", fpaxUsers.USER_ID);
            ht.Add("USER_NAME", fpaxUsers.USER_NAME);
            ht.Add("USER_PWD", fpaxUsers.USER_PWD);
            ht.Add("USER_REPORT_STYLE", fpaxUsers.USER_REPORT_STYLE);
            ht.Add("USER_SKIN_STYLE", fpaxUsers.USER_SKIN_STYLE);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 查询是否存在指定的用户记录
        /// </summary>
        /// <param name="ifpaxUsers"></param>
        /// <returns></returns>
        public override bool Exists(IModel ifpaxUsers)
        {
            MUser fpaxUsers = (MUser)ifpaxUsers;
            strSql = "select * from " + TableName + " where DB_USER='" + fpaxUsers.DB_USER + "' and USER_PWD='"+fpaxUsers .USER_PWD+"'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取指定DB_USER的用户记录
        /// </summary>
        /// <param name="DB_USER"></param>
        /// <returns></returns>
        public override IModel GetModel(string DB_USER)
        {
            strSql = "select * from " + TableName + " where DB_USER ='" + DB_USER + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MUser fpaxUsers = new MUser();
            fpaxUsers.APPLICATION = dt.Rows[0]["APPLICATION"].ToString();
            fpaxUsers.DB_USER = dt.Rows[0]["DB_USER"].ToString();
            fpaxUsers.DEPT_NAME = dt.Rows[0]["DEPT_NAME"].ToString();
            fpaxUsers.MODULE_CAPABILITY = dt.Rows[0]["MODULE_CAPABILITY"].ToString();
            fpaxUsers.USER_CUSTOM_DATA = dt.Rows[0]["USER_CUSTOM_DATA"].ToString();
            fpaxUsers.USER_DEPT = dt.Rows[0]["USER_DEPT"].ToString();
            fpaxUsers.USER_ID = dt.Rows[0]["USER_ID"].ToString();
            fpaxUsers.USER_NAME = dt.Rows[0]["USER_NAME"].ToString();
            fpaxUsers.USER_PWD = dt.Rows[0]["USER_PWD"].ToString();

            if (dt.Rows[0]["CAPABILITY"].ToString() == "")
                fpaxUsers.CAPABILITY = null;
            else
                fpaxUsers.CAPABILITY = Convert.ToInt32(dt.Rows[0]["CAPABILITY"].ToString());

            if (dt.Rows[0]["USER_CHAT_CAPABILITY"].ToString() == "")
                fpaxUsers.USER_CHAT_CAPABILITY = null;
            else
                fpaxUsers.USER_CHAT_CAPABILITY = Convert.ToInt32(dt.Rows[0]["USER_CHAT_CAPABILITY"].ToString());

            if (dt.Rows[0]["USER_HANDUP_STYLE"].ToString() == "")
                fpaxUsers.USER_HANDUP_STYLE = null;
            else
                fpaxUsers.USER_HANDUP_STYLE = Convert.ToInt32(dt.Rows[0]["USER_HANDUP_STYLE"].ToString());

            if (dt.Rows[0]["USER_HEADER_ICON"].ToString() == "")
                fpaxUsers.USER_HEADER_ICON = null;
            else
                fpaxUsers.USER_HEADER_ICON = Convert.ToInt32(dt.Rows[0]["USER_HEADER_ICON"].ToString());

            if (dt.Rows[0]["USER_REPORT_STYLE"].ToString() == "")
                fpaxUsers.USER_REPORT_STYLE = null;
            else
                fpaxUsers.USER_REPORT_STYLE = Convert.ToInt32(dt.Rows[0]["USER_REPORT_STYLE"].ToString());

            if (dt.Rows[0]["USER_SKIN_STYLE"].ToString() == "")
                fpaxUsers.USER_SKIN_STYLE = null;
            else
                fpaxUsers.USER_SKIN_STYLE = Convert.ToInt32(dt.Rows[0]["USER_SKIN_STYLE"].ToString());

            if (dt.Rows[0]["CREATE_DATE"].ToString() == "")
                fpaxUsers.CREATE_DATE = null;
            else
                fpaxUsers.CREATE_DATE = Convert.ToDateTime(dt.Rows[0]["CREATE_DATE"].ToString());

            return fpaxUsers;
        }

        /// <summary>
        /// 获取符合条件的用户列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定的用户记录
        /// </summary>
        /// <param name="ifpaxUsers"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel ifpaxUsers, string where)
        {
            MUser fpaxUsers = (MUser)ifpaxUsers;
            Hashtable ht = new Hashtable();
            ht.Add("APPLICATION", fpaxUsers.APPLICATION);
            ht.Add("CAPABILITY", fpaxUsers.CAPABILITY);
            ht.Add("CREATE_DATE", fpaxUsers.CREATE_DATE);
            //ht.Add("APPLICATION", fpaxUsers.APPLICATION);
            ht.Add("DB_USER", fpaxUsers.DB_USER);
            ht.Add("DEPT_NAME", fpaxUsers.DEPT_NAME);
            ht.Add("MODULE_CAPABILITY", fpaxUsers.MODULE_CAPABILITY);
            ht.Add("USER_CHAT_CAPABILITY", fpaxUsers.USER_CHAT_CAPABILITY);
            ht.Add("USER_CUSTOM_DATA", fpaxUsers.USER_CUSTOM_DATA);
            ht.Add("USER_DEPT", fpaxUsers.USER_DEPT);
            ht.Add("USER_HANDUP_STYLE", fpaxUsers.USER_HANDUP_STYLE);
            ht.Add("USER_HEADER_ICON", fpaxUsers.USER_HEADER_ICON);
            ht.Add("USER_ID", fpaxUsers.USER_ID);
            ht.Add("USER_NAME", fpaxUsers.USER_NAME);
            ht.Add("USER_PWD", fpaxUsers.USER_PWD);
            ht.Add("USER_REPORT_STYLE", fpaxUsers.USER_REPORT_STYLE);
            ht.Add("USER_SKIN_STYLE", fpaxUsers.USER_SKIN_STYLE);
            return (ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString()));
        }

        /// <summary>
        /// 删除符合条件的用户记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }

        /// <summary>
        /// 批量删除符合条件的用户记录
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
                    dbCom.CommandText = "Delete FPAX_USERS where DB_USER='" + item.Value.ToString() + "'";

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
        /// 获取符合条件的所有用户记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataSet GetData(string where)
        {
            strSql = "select distinct user_name from " + TableName + " where " + where;
            return GetDataSet(strSql);
        }
    }
}