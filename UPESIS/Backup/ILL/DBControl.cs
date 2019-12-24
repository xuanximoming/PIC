using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Collections;

namespace ILL
{
    /// <summary>
    /// DBControl 的摘要说明；本类为接口逻辑层的数据访问控制类，DBControl获取配置文件，DBGetter获取数据库对象，DBFactory生产数据库，
    /// </summary>
    public abstract class DBControl
    {
        protected DBFactory dbF;
        protected IDbConnection dbConn;
        protected DBGetter dbg;
        protected ConParam cp;

        //由系统类型：SIS、PACS、HIS和LIS，决定获取配置文件的数据连接信息，形成数据库对象
        public DBControl(string conn)
        {
            switch (conn)
            {
                case "SIS":
                    cp = GetConfig.GetSisConnStr();
                    break;
                case "PACS":
                    cp = GetConfig.GetPacsConnStr();
                    break;
                case "HIS":
                    cp = GetConfig.GetHisConnStr();
                    break;
                case "LIS":
                    cp = GetConfig.GetLisConnStr();
                    break;
            }
            this.dbF = new DBGetter(cp).getDatabase();
            this.dbg = new DBGetter(cp);
        }

        //由数据库连接信息形成数据库对象
        public DBControl(ConParam cps)
        {
            cp = cps;
            this.dbF = new DBGetter(cp).getDatabase();
            this.dbg = new DBGetter(cp);
        }

        public DBFactory DBF
        {
            get
            {
                return this.dbF;
            }
        }

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        /// <param name="strConn">连接字符串</param>
        /// <returns></returns>
        public bool Open()
        {
            dbConn = dbF.getDBConnection();
            try
            {
                if (dbConn != null && dbConn.State != ConnectionState.Closed)
                    dbConn.Close();
                dbConn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            return dbConn.State == ConnectionState.Open ? true : false;
        }


        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void Close()
        {
            try
            {
                if (this.dbConn != null && this.dbConn.State == ConnectionState.Closed) return;
                this.dbConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 执行改变数据的Sql语句
        /// </summary>
        /// <param name="sqlText"></param>
        private int ExecuteNonSQL(string sql)
        {
            IDbCommand dbCom = dbF.getDBCommand();
            dbCom.Connection = this.dbConn;
            dbCom.CommandText = sql;
            try
            {

                return dbCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + sql + ex.Message);
            }
            return 0;
        }
        /// <summary>
        /// 执行一组SQL语句
        /// </summary>
        /// <param name="ht">Hashtable</param>
        /// <returns>成功执行的数量</returns>
        public int ExecuteNonSql(Hashtable ht)
        {

            this.Open();
            IDbCommand dbCom = dbF.getDBCommand();
            dbCom.Connection = this.dbConn;
            IDbTransaction tran = dbF.getTransaction(this.dbConn);
            dbCom.Transaction = tran;
            dbCom.CommandType = CommandType.Text;
            string sql = "";
            try
            {
                foreach (DictionaryEntry item in ht)
                {
                    sql = item.Value.ToString();
                    dbCom.CommandText = item.Value.ToString();

                    dbCom.ExecuteNonQuery();
                }
                tran.Commit();
                return ht.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + sql + ex.Message);
                tran.Rollback();
                MessageBox.Show("数据库事物处理错误！");
                return -1;
            }
            finally
            {
                this.Close();
            }
        }
        /// <summary>
        /// 获得第一行第一列数据值
        /// </summary>
        /// <param name="sqlText"></param>
        /// <returns></returns>
        public string ExecuteScalar(string sql)
        {
            this.Open();
            IDbCommand dbCom = dbF.getDBCommand();
            dbCom.Connection = this.dbConn;
            dbCom.CommandText = sql;
            string value = "";
            try
            {
                object obj = dbCom.ExecuteScalar();
                if (obj != null)
                    value = obj.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + sql + ex.Message);
            }
            return value;
        }

        /// <summary>
        /// 判断在记录是否唯一
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool recordIsExist(string sql)
        {
            int i = 0;
            this.Open();
            if (GetDataTable(sql).Rows.Count > 0)
            {
                return true;
            }
            else
            { return false; }
        }

        /// <summary>
        /// 执行影响SQL语句（静态方法）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>受影响的行数</returns>
        public int ExecuteSql(string sql)
        {
            try
            {
                this.Open();
                int i = ExecuteNonSQL(sql);
                this.Close();
                return i;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + sql + ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// 获取数据行
        /// </summary>
        /// <returns></returns>
        public DataRow GetDataRow(string sql)
        {
            DataTable dt = GetDataTable(sql);
            if (dt != null && dt.Rows.Count > 0)
                return dt.Rows[0];
            else
                return null;
        }

        /// <summary>
        /// 获取数据集Table
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql)
        {
            DataSet ds = GetDataSet(sql);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }

        /// <summary>
        /// 获取数据集DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string sql)
        {
            try
            {
                DataSet ds = new DataSet();
                this.Open();
                IDbCommand com = DBF.getDBCommand();
                com.CommandText = sql;
                com.Connection = DBF.getDBConnection();
                IDataAdapter sda = DBF.getDataAdapter(com);
                sda.Fill(ds);
                this.Close();
                return ds;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error:" + sql + ex.Message);
                return null;
            }
        }
        public DataSet GetDataSet(string sql, ref System.Data.Odbc.OdbcDataAdapter sda)
        {
            try
            {
                DataSet ds = new DataSet();
                this.Open();
                IDbCommand com = DBF.getDBCommand();
                com.CommandText = sql;
                com.Connection = DBF.getDBConnection();
                sda = (System.Data.Odbc.OdbcDataAdapter)DBF.getDataAdapter(com);
                sda.Fill(ds);
                this.Close();
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + sql + ex.Message);
                return null;
            }
        }
        public DataSet GetDataSet1(string sql, ref System.Data.OracleClient.OracleDataAdapter sda)
        {
            try
            {
                DataSet ds = new DataSet();
                this.Open();
                IDbCommand com = DBF.getDBCommand();
                com.CommandText = sql;
                com.Connection = DBF.getDBConnection();
                sda = (System.Data.OracleClient.OracleDataAdapter)DBF.getDataAdapter(com);
                sda.Fill(ds);
                this.Close();
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + sql + ex.Message);
                return null;
            }
        }
        public int UpdateDataTable(string sql, System.Data.DataTable dt, System.Data.Odbc.OdbcDataAdapter sda)
        {
            int i = 0;
            try
            {
                System.Data.Odbc.OdbcCommandBuilder builder = new System.Data.Odbc.OdbcCommandBuilder(sda);
                sda.UpdateCommand = builder.GetUpdateCommand();
                if (dt.GetChanges() != null)
                {
                    i = sda.Update(dt);
                    dt = GetDataTable(sql);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message.ToString());
                return -1;
            }
            return i;
        }
        public int UpdateDataTable1(string sql, System.Data.DataTable dt, System.Data.OracleClient.OracleDataAdapter sda)
        {
            int i = 0;
            try
            {
                System.Data.OracleClient.OracleCommandBuilder builder = new System.Data.OracleClient.OracleCommandBuilder(sda);
                sda.UpdateCommand = builder.GetUpdateCommand();
                if (dt.GetChanges() != null)
                {
                    i = sda.Update(dt);
                    dt = GetDataTable(sql);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message.ToString());
                return -1;
            }
            return i;
        }
        //*************************************************************************************************
        //针对Blob字段的处理

        /// <summary>
        /// 执行影响SQL语句（静态方法）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>受影响的行数</returns>
        public int ExecuteSql(string sql, Hashtable ht)
        {
            int i = ExecuteNonSQL(sql, ht);
            return i;
        }
        /// <summary>
        /// 执行改变数据的Sql语句
        /// </summary>
        /// <param name="sqlText"></param>
        private int ExecuteNonSQL(string sqlText, Hashtable ht)
        {
            this.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = sqlText;
            cmd.Connection = (OracleConnection)this.dbConn;
            int i = 0;
            foreach (DictionaryEntry item in ht)
            {
                if (item.Value != null)
                {
                    if (item.Value.GetType().ToString() == "System.Byte[]")
                    {
                        byte[] bt = (byte[])item.Value;
                        cmd.Parameters.Add(item.Key.ToString(), OracleType.Blob, bt.Length);
                        cmd.Parameters[i].Value = bt;
                        i++;
                    }
                }

            }
            int j = cmd.ExecuteNonQuery();
            this.Close();
            return j;
        }

        #region 执行存储过程
        public int ExecutePro(string ProName, params object[] paraValues)
        {
            try
            {
                using (IDbConnection con = dbF.getDBConnection())
                {
                    IDbCommand comm = dbF.getDBCommand();
                    comm.CommandType = CommandType.StoredProcedure;

                    AddInParaValues(comm, paraValues);
                    con.Open();
                    comm.ExecuteNonQuery();
                    con.Close();
                    return 1;
                }
            }
            catch
            {
                MessageBox.Show("执行存储过程" + ProName + "出错!");
                return -1;
            }
        }
        public DataSet GetDataSetByPro(string ProName, params object[] paraValues)
        {
            try
            {
                using (IDbConnection conn = dbF.getDBConnection())
                {
                    conn.Open();
                    IDbCommand comm = dbF.getDBCommand();
                    comm.Connection = conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.CommandText = ProName;
                    AddInParaValues(comm, paraValues);
                    IDataAdapter sda = DBF.getDataAdapter(comm);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    return ds;
                }
            }
            catch
            {
                MessageBox.Show("执行存储过程" + ProName + "出错!");
                return null;
            }
        }

        private void AddInParaValues(IDbCommand comm, object[] paraValues)
        {
            //comm.Parameters.Add(new IDbDataParameter("@RETURN_VALUE", SqlDbType.Int));
            // comm.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;
            if (paraValues != null)
            {
                //ArrayList al = GetParas();
                for (int i = 0; i < paraValues.Length; i++)
                {
                    comm.Parameters.Add(paraValues[i]);
                }
            }

        }
        #endregion 执行存储过程
    }

}