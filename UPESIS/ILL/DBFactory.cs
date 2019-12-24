using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.Odbc;

namespace ILL
{
    /// <summary>
    /// ���ݿ���󹤳�,�������ݿ������
    /// </summary>
    public abstract class DBFactory
    {
        public abstract IDbConnection getDBConnection();
        public abstract IDbCommand getDBCommand();
        public abstract IDataAdapter getDataAdapter(IDbCommand idCom);
        public abstract IDbTransaction getTransaction(IDbConnection idCon);
        public abstract IDbDataParameter getParameter();
        protected string strConn;
    }

    /// <summary>
    /// Sql���ݿ⹤�������л��sql�������ӣ�sql���sql������
    /// </summary>
    public class SqlDBFactory : DBFactory
    {
        public SqlDBFactory(string strConn)
        {
            this.strConn = strConn;

        }

        public override IDbConnection getDBConnection()
        {
            return new SqlConnection(this.strConn);
        }

        public override IDbCommand getDBCommand()
        {
            return new SqlCommand();
        }

        public override IDataAdapter getDataAdapter(IDbCommand idCom)
        {
            return new SqlDataAdapter((SqlCommand)idCom);
        }

        public override IDbTransaction getTransaction(IDbConnection idCon)
        {
            return (SqlTransaction)idCon.BeginTransaction();

        }
        public override IDbDataParameter getParameter()
        {
            return new SqlParameter();
        }

    }


    /// <summary>
    /// Oracle���ݿ⹤�������л��Oracle�������ӣ�Oracle���Oracle����������Ϊ OleDB���ӷ�ʽ
    /// </summary>
    public class OracleDBFactory : DBFactory
    {
        public OracleDBFactory(string strConn)
        {
            this.strConn = strConn;
        }

        //	���ORACLE������
        public override IDbConnection getDBConnection()
        {
            return new OracleConnection(strConn);
        }

        //	��ȡORACLE����������
        public override IDbCommand getDBCommand()
        {
            return new OracleCommand();
        }

        //	��ȡORACLE���ӷ�ʽ��������
        public override IDataAdapter getDataAdapter(IDbCommand idCom)
        {
            return new OracleDataAdapter((OracleCommand)idCom);
        }

        public override IDbTransaction getTransaction(IDbConnection idCon)
        {
            return (OracleTransaction)idCon.BeginTransaction();
            //throw new Exception("The method or operation is not implemented.");
        }
        public override IDbDataParameter getParameter()
        {
            return new OracleParameter();
        }
    }

    /// <summary>
    ///  ODBC�������ݿ�
    /// </summary>
    public class OdbcDBFactory : DBFactory
    {
        public OdbcDBFactory(string strConn)
        {
            this.strConn = strConn;
        }

        public override IDbConnection getDBConnection()
        {
            return new OdbcConnection(strConn);
        }

        public override IDbCommand getDBCommand()
        {
            return new OdbcCommand();
        }

        public override IDataAdapter getDataAdapter(IDbCommand idCom)
        {
            return new OdbcDataAdapter((OdbcCommand)idCom);
        }

        public override IDbTransaction getTransaction(IDbConnection idCon)
        {
            return (OdbcTransaction)idCon.BeginTransaction();

            //throw new Exception("The method or operation is not implemented.");
        }
        public override IDbDataParameter getParameter()
        {
            return new OdbcParameter();
        }
    }

    /// <summary>
    /// Access�������ݿ�
    /// </summary>
    public class AccessDBFactory : DBFactory
    {
        public AccessDBFactory(string strConn)
        {
            this.strConn = strConn;
        }
        public override IDbConnection getDBConnection()
        {
            return new OleDbConnection(strConn);
        }
        public override IDbCommand getDBCommand()
        {
            return new OleDbCommand();
        }
        public override IDataAdapter getDataAdapter(IDbCommand idCom)
        {
            return new OleDbDataAdapter((OleDbCommand)idCom);
        }

        public override IDbTransaction getTransaction(IDbConnection idCon)
        {
            return (OleDbTransaction)idCon.BeginTransaction();
            //throw new Exception("The method or operation is not implemented.");
        }
        public override IDbDataParameter getParameter()
        {
            return new OleDbParameter();
        }
    }
}
