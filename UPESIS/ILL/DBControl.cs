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
    /// DBControl ��ժҪ˵��������Ϊ�ӿ��߼�������ݷ��ʿ����࣬DBControl��ȡ�����ļ���DBGetter��ȡ���ݿ����DBFactory�������ݿ⣬
    /// </summary>
    public abstract class DBControl
    {
        protected DBFactory dbF;
        protected IDbConnection dbConn;
        protected DBGetter dbg;
        protected ConParam cp;

        //��ϵͳ���ͣ�SIS��PACS��HIS��LIS��������ȡ�����ļ�������������Ϣ���γ����ݿ����
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

        //�����ݿ�������Ϣ�γ����ݿ����
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
        /// �����ݿ�����
        /// </summary>
        /// <param name="strConn">�����ַ���</param>
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
        /// �ر����ݿ�����
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
        /// ִ�иı����ݵ�Sql���
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
        /// ִ��һ��SQL���
        /// </summary>
        /// <param name="ht">Hashtable</param>
        /// <returns>�ɹ�ִ�е�����</returns>
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
                MessageBox.Show("���ݿ����ﴦ�����");
                return -1;
            }
            finally
            {
                this.Close();
            }
        }
        /// <summary>
        /// ��õ�һ�е�һ������ֵ
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
        /// �ж��ڼ�¼�Ƿ�Ψһ
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
        /// ִ��Ӱ��SQL��䣨��̬������
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>��Ӱ�������</returns>
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
        /// ��ȡ������
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
        /// ��ȡ���ݼ�Table
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
        /// ��ȡ���ݼ�DataSet
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
        //���Blob�ֶεĴ���

        /// <summary>
        /// ִ��Ӱ��SQL��䣨��̬������
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>��Ӱ�������</returns>
        public int ExecuteSql(string sql, Hashtable ht)
        {
            int i = ExecuteNonSQL(sql, ht);
            return i;
        }
        /// <summary>
        /// ִ�иı����ݵ�Sql���
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

        #region ִ�д洢����
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
                MessageBox.Show("ִ�д洢����" + ProName + "����!");
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
                MessageBox.Show("ִ�д洢����" + ProName + "����!");
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
        #endregion ִ�д洢����
    }

}