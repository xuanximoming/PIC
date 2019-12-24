using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace ILL
{
    /// <summary>
    /// 数据库连接字符串获取类，由DBControl获取ConParam的基本字段数据，形成字符串
    /// </summary>
    public class DBGetter
    {
        private DBFactory dbF;    //  数据库接口
        public string StrConn;    //  数据库连接字符串
        private ConParam cp;

        public DBGetter(ConParam cp)
        {
            this.cp = cp;
            this.createConStr();
        }
        /// <summary>
        /// 根据连接数据库字符串进行生成数据库对象
        /// </summary>
        /// <returns></returns>
        public DBFactory getDatabase()
        {
            switch (cp.DBType.ToUpper())
            {
                case "SQLSERVER":
                    this.dbF = new SqlDBFactory(this.StrConn); break;
                case "ORACLE":
                    this.dbF = new OracleDBFactory(this.StrConn); break;
                case "ODBC":
                    this.dbF = new OdbcDBFactory(this.StrConn); break;
                case "ACCESS":
                    this.dbF = new AccessDBFactory(this.StrConn); break;
            }

            return this.dbF;
        }

        /// <summary>
        /// 连接数据库字符串
        /// </summary>
        public void createConStr()
        {
            switch (cp.DBType.ToUpper())
            {
                case "SQLSERVER":
                    this.StrConn = @"server=" + cp.Server + ";uid=" + cp.Uid + ";pwd=" + cp.Pwd + ";database=" + cp.Database; 
                    break;
                case "ORACLE":
                    this.StrConn = @"User ID=" + cp.Uid + ";Password=" + cp.Pwd + ";Data Source=" + cp.Database; 
                    break;
                case "ODBC":
                    this.StrConn = @"DRIVER={" + cp.Driver + "};Server=" + cp.Database + ";Uid=" + cp.Uid + ";Pwd=" + cp.Pwd;
                    break;
                case "ACCESS":
                    this.StrConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + cp.Database; 
                    break;
            }
        }
    }
}