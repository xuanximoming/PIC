using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace Update
{
    /// <summary>
    /// DBControl ��ժҪ˵����
    /// </summary>
    public class DBControl
    {
        private DBFactory dbF;
        private IDbConnection dbConn;


        public DBControl(DBFactory dbf)
        {
            this.dbF = dbf;

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
        /// 
        public bool Open()
        {
            dbConn = dbF.getDBConnection();
            try
            {
                if (dbConn != null && dbConn.State != ConnectionState.Closed) dbConn.Close();
                dbConn.Open();
            }
            catch (Exception e)
            {
                System.Console.Write(e.StackTrace);
                return false;
            }
            return dbConn.State == ConnectionState.Open ? true : false;
        }


        /// <summary>
        /// �ر�����
        /// </summary>
        public void Close()
        {
            if (this.dbConn != null && this.dbConn.State == ConnectionState.Closed) return;
            this.dbConn.Close();
        }


        /// <summary>
        /// ִ��sql��������ݼ�
        /// </summary>
        /// <param name="sqlText">sql���</param>
        /// <returns>���ݼ���</returns>
        public DataSet ExecuteSQL(string sqlText)
        {
            IDbCommand dbCom = dbF.getDBCommand();
            dbCom.Connection = this.dbConn;
            dbCom.CommandText = sqlText;
            IDataAdapter iDA = dbF.getDataAdapter(dbCom);
            DataSet ds = new DataSet();
            iDA.Fill(ds);
            return ds;
        }

        /// <summary>
        /// ִ�иı����ݵ�Sql���
        /// </summary>
        /// <param name="sqlText"></param>
        public int ExecuteNonSQL(string sqlText)
        {
            IDbCommand dbCom = dbF.getDBCommand();
            dbCom.Connection = this.dbConn;
            dbCom.CommandText = sqlText;
            try
            {
                return dbCom.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Console.Write("ִ��������!" + e);
                return -1;
            }
        }

        /// <summary>
        /// ��õ�һ�е�һ������ֵ
        /// </summary>
        /// <param name="sqlText"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sqlText)
        {
            IDbCommand dbCom = dbF.getDBCommand();
            dbCom.Connection = this.dbConn;
            dbCom.CommandText = sqlText;
            object obj = null;
            try
            {
                obj = dbCom.ExecuteScalar();
            }
            catch (Exception e)
            {
                System.Console.Write("ִ��������!" + e);
            }
            return obj;
        }

        /// <summary>
        /// �ж��ڼ�¼�Ƿ�Ψһ
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool recordIsExist(string sql)
        {
            int i;
            DBGetter dbg = new DBGetter();
            DBControl dbc = new DBControl(dbg.getDatabase());
            dbc.Open();
            i = (int)dbc.ExecuteScalar(sql);
            dbc.Close();
            return i == 1 ? true : false;
        }

        /// �������ݿ⣨��̬������
        /// </summary>
        /// <param name="sql"></param>
        public static int updateDatabase(string sql)
        {
            DBGetter dbg = new DBGetter();
            DBControl dbc = new DBControl(dbg.getDatabase());
            dbc.Open();
            int i = dbc.ExecuteNonSQL(sql);
            dbc.Close();
            return i;
        }

        /// <summary>
        /// �������ݿ⣨��̬������
        /// </summary>
        /// <param name="sql"></param>
        public static int insertDatabase(string sql)
        {
            DBGetter dbg = new DBGetter();
            DBControl dbc = new DBControl(dbg.getDatabase());
            dbc.Open();
            int i = dbc.ExecuteNonSQL(sql);
            dbc.Close();
            return i;
        }

        ///// <summary>
        ///// �����ݵ�GridControl��
        ///// </summary>
        ///// <param name="sql">��ѯ���</param>
        ///// <param name="gc">GridControl����</param>
        ///// <param name="ds">���ݼ���</param>
        //public static IDataAdapter setBindings(string sql, DevExpress.XtraGrid.GridControl gc, DataSet ds)
        //{
        //    DBGetter dbg = new DBGetter();
        //    DBOperator.DBControl dbc = new DBControl(dbg.getDatabase());
        //    dbc.Open();
        //    IDbCommand com = dbc.DBF.getDBCommand();
        //    com.CommandText = sql;
        //    com.Connection = dbc.DBF.getDBConnection();
        //    IDataAdapter sda = dbc.DBF.getDataAdapter(com);
        //    sda.Fill(ds);
        //    gc.DataSource = ds.Tables[0].DefaultView;
        //    dbc.Close();
        //    return sda;
        //}

        ///// <summary>
        ///// �����ݵ�DataGrid�ؼ���
        ///// </summary>
        ///// <param name="sql">��ѯ���</param>
        ///// <param name="dg">DataGrid�ؼ�</param>
        ///// <param name="ds">���ݼ�</param>
        //public static IDataAdapter setBindings(string sql, System.Windows.Forms.DataGrid dg, DataSet ds)
        //{
        //    DBGetter dbg = new DBGetter();
        //    DBOperator.DBControl dbc = new DBControl(dbg.getDatabase());
        //    dbc.Open();
        //    IDbCommand com = dbc.DBF.getDBCommand();
        //    com.CommandText = sql;
        //    com.Connection = dbc.DBF.getDBConnection();
        //    IDataAdapter sda = dbc.DBF.getDataAdapter(com);
        //    sda.Fill(ds);
        //    dg.DataSource = ds.Tables[0].DefaultView;
        //    dbc.Close();
        //    return sda;
        //}

        /// <summary>
        /// ��ȡ������
        /// </summary>
        /// <returns></returns>
        public static DataRow getDataRow(string sql)
        {
            DataSet ds = new DataSet();
            DBGetter dbg = new DBGetter();
            DBControl dbc = new DBControl(dbg.getDatabase());
            dbc.Open();
            IDbCommand com = dbc.DBF.getDBCommand();
            com.CommandText = sql;
            com.Connection = dbc.DBF.getDBConnection();
            IDataAdapter sda = dbc.DBF.getDataAdapter(com);
            sda.Fill(ds);
            dbc.Close();
            return ds.Tables[0].Rows[0];
        }


        /// <summary>
        /// ��ȡ���ݼ�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet getDataSet(string sql)
        {
            DataSet ds = new DataSet();
            DBGetter dbg = new DBGetter();
            DBControl dbc = new DBControl(dbg.getDatabase());
            dbc.Open();
            IDbCommand com = dbc.DBF.getDBCommand();
            com.CommandText = sql;
            com.Connection = dbc.DBF.getDBConnection();
            IDataAdapter sda = dbc.DBF.getDataAdapter(com);
            sda.Fill(ds);
            dbc.Close();
            return ds;
        }


        //      ɾ�����ݿⷽʽ
        //		public static bool deleteDatabase(string sql)
        //		{
        //			DataSet ds = new DataSet();
        //			DBGetter dbg = new DBGetter("SqlServer","����");
        //			DBOperator.DBControl dbc = new DBControl(dbg.getDatabase());
        //			dbc.Open();c
        //			SqlCommand com = new SqlCommand(sql,(SqlConnection)dbc.DBF.getDBConnection());
        //			SqlDataAdapter sda = new SqlDataAdapter(com);
        //			sda.Fill(ds);
        //			dbc.Close();
        //			return ds;
        //		}
        //
        //
        //		���Է�ʽ
        //		private void button1_Click(object sender, System.EventArgs e)
        //		{
        //			string strCon = "server=(local);uid=sa;pwd=123;database=test";
        //			SqlConnection con= new SqlConnection(strCon);
        //			SqlCommand com = new SqlCommand("select Max(productID) from idhao",con);
        //			com.Connection.Open();
        //			string str = (string)com.ExecuteScalar();
        //			this.textBox1.Text = this.buildString(str);
        //		}
        //
        //		Oracle���ӷ�ʽ
        //		һ.OleDb����Oracle   (�������ĸ�Oracle�汾������ʾ����)
        //		1.private static string strConnect ="Provider=OraOLEDB.Oracle.1;Persist Security Info=False;" + "User ID=system;Password=manager;Data Source=dbserver;";
        //		2.OleDbConnection conConnection= new OleDbConnection(strConnect);
        //		3.string strCommand = "select * from users";
        //		4.OleDbDataReader reader;
        //		5.conConnection.Open();
        //		6.OleDbCommand cmd = new OleDbCommand(strCommand,conConnection);
        //		7.reader = cmd.ExecuteReader();
        //		8.DataSet tempmyDataSet=new DataSet();
        //
        //
        //		Oracle���ӷ�ʽ
        //
        //		string sql = "Driver={Microsoft ODBC for Oracle};Server=bcdb;Uid=bcuser;Pwd=123";
        //		OdbcConnection con = new OdbcConnection(sql);
        //		try
        //		{
        //			con.Open();
        //			DataSet ds = new DataSet();
        //			System.Data.Odbc.OdbcCommand com = new OdbcCommand("select * from TAB_PATIENT_SOURCE",con);
        //			OdbcDataAdapter oda = new OdbcDataAdapter(com);
        //			oda.Fill(ds);
        //			this.gc_Patient_Source.DataSource = ds.Tables[0].DefaultView;
        //			con.Close();
        //		}
        //		catch(Exception ex)
        //		{
        //			MessageBox.Show(ex.StackTrace.ToString());
        //		}

    }
}
