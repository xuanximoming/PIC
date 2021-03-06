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
    /// 数据库抽象工厂,负责数据库的制造
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
    /// Sql数据库工厂，从中获得sql数据连接，sql命令，sql适配器
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
    /// Oracle数据库工厂，从中获得Oracle数据连接，Oracle命令，Oracle适配器，此为 OleDB连接方式
    /// </summary>
    public class OracleDBFactory : DBFactory
    {
        public OracleDBFactory(string strConn)
        {
            this.strConn = strConn;
        }

        //	获得ORACLE的连接
        public override IDbConnection getDBConnection()
        {
            return new OracleConnection(strConn);
        }

        //	获取ORACLE的连接命令
        public override IDbCommand getDBCommand()
        {
            return new OracleCommand();
        }

        //	获取ORACLE连接方式的适配器
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
    ///  ODBC连接数据库
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
    /// Access连接数据库
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
