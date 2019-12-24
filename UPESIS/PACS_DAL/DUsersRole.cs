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
    /// 操作USER_EXAM_CLASS，即用户与检查类别对照
    /// </summary>
    public class DUsersRole : IUsersRole
    {
        private string strSql;
        private string TableName = "USER_EXAM_CLASS";
        public DUsersRole()
            : base(GetConfig.GetPacsConnStr())
        {
        }

        /// <summary>
        /// 插入一条对照记录
        /// </summary>
        /// <param name="iuserExamClass"></param>
        /// <returns></returns>
        public override int Add(IModel iuserExamClass)
        {
            MUserExamClass userExamClass = (MUserExamClass)iuserExamClass;
            Hashtable ht = new Hashtable();
            ht.Add("DB_USER", userExamClass.DB_USER);
            ht.Add("DEPT_NAME", userExamClass.DEPT_NAME);
            ht.Add("EXAM_CLASS", userExamClass.EXAM_CLASS);
            ht.Add("USER_DEPT", userExamClass.USER_DEPT);
            ht.Add("REPORT_CAPABILITY", userExamClass.REPORT_CAPABILITY);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 批量插入对照列表
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int AddMore(Hashtable ht2)
        {
            MUserExamClass MUserRol = new MUserExamClass();
            Hashtable ht = new Hashtable();
            Hashtable htstr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    MUserRol = ((MUserExamClass)ht2[i]);
                    ht.Add("DB_USER", MUserRol.DB_USER);
                    ht.Add("DEPT_NAME", MUserRol.DEPT_NAME);
                    ht.Add("EXAM_CLASS", MUserRol.EXAM_CLASS);
                    ht.Add("USER_DEPT", MUserRol.USER_DEPT);
                    ht.Add("REPORT_CAPABILITY", MUserRol.REPORT_CAPABILITY);

                    bool bl = Exists(MUserRol);
                    if (bl) continue;   //如果存在则不添加
                    htstr.Add(i, StringConstructor.InsertSql(TableName, ht).ToString());
                }
                return ExecuteNonSql(htstr);

            }
            else
                return 0;
        }

        /// <summary>
        /// 查询是否存在指定的对照记录
        /// </summary>
        /// <param name="iuserExamClass"></param>
        /// <returns></returns>
        public override bool Exists(IModel iuserExamClass)
        {
            MUserExamClass userExamClass = (MUserExamClass)iuserExamClass;
            strSql = "select * from " + TableName + " where DB_USER='" + userExamClass.DB_USER + "' and EXAM_CLASS = '" + userExamClass.EXAM_CLASS + "'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取指定DB_USER、检查类别的对照记录
        /// </summary>
        /// <param name="DB_USER"></param>
        /// <param name="EXAM_CLASS"></param>
        /// <returns></returns>
        public override IModel GetModel(string DB_USER, string EXAM_CLASS)
        {
            strSql = "select * from " + TableName + "  where DB_USER='" + DB_USER + "' and EXAM_CLASS = '" + EXAM_CLASS + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MUserExamClass userExamClass = new MUserExamClass();
            userExamClass.DB_USER =dt.Rows[0]["DB_USER"].ToString();
            userExamClass.DEPT_NAME = dt.Rows[0]["DEPT_NAME"].ToString();
            userExamClass.EXAM_CLASS = dt.Rows[0]["EXAM_CLASS"].ToString();
            userExamClass.USER_DEPT = dt.Rows[0]["USER_DEPT"].ToString();
            if (dt.Rows[0]["REPORT_CAPABILITY"] == null)
                userExamClass.REPORT_CAPABILITY = null;
            else
                userExamClass.REPORT_CAPABILITY = Convert.ToInt32(dt.Rows[0]["REPORT_CAPABILITY"].ToString());
            return userExamClass;
        }

        /// <summary>
        /// 获取符合条件的对照列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定的对照记录
        /// </summary>
        /// <param name="iuserExamClass"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel iuserExamClass, string where)
        {
            MUserExamClass userExamClass = (MUserExamClass)iuserExamClass;
            Hashtable ht = new Hashtable();
            ht.Add("DB_USER", userExamClass.DB_USER);
            ht.Add("DEPT_NAME", userExamClass.DEPT_NAME);
            ht.Add("EXAM_CLASS", userExamClass.EXAM_CLASS);
            ht.Add("USER_DEPT", userExamClass.USER_DEPT);
            ht.Add("REPORT_CAPABILITY", userExamClass.REPORT_CAPABILITY);
            return ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString());
        }

        /// <summary>
        /// 更新指定对照记录的报告权限
        /// </summary>
        /// <param name="iuserExamClass"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update2(IModel iuserExamClass, string where)
        {
            MUserExamClass userExamClass = (MUserExamClass)iuserExamClass;
            string sql = "Update USER_EXAM_CLASS set REPORT_CAPABILITY='" + userExamClass.REPORT_CAPABILITY + "' Where " + where;
            return ExecuteSql(sql);
        }

        /// <summary>
        /// 删除符合条件的对照记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }

        /// <summary>
        /// 批量删除对照记录
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
                    dbCom.CommandText = "Delete USER_EXAM_CLASS where DB_USER = '" + sArray[0] + "' and EXAM_CLASS = '" + sArray[1] + "'";
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
    }
}
