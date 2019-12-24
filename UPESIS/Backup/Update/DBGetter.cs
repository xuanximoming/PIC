using System;
using System.Collections.Generic;
using System.Text;

namespace Update
{
    public class DBGetter
    {
        private string DBType;    //  数据库类型
        private DBFactory dbF;    //  数据库接口
        public string StrConn;    //  数据库连接字符串
        private ClsIni ini = new ClsIni(@System.Windows.Forms.Application.StartupPath + @"\Settings.ini");

        public DBGetter()
        {
            this.createConStr();
        }

        public string DBTYPE
        {
            get { return this.DBType; }
        }

        /// <summary>
        /// 根据app.config的配置生成数据库对象
        /// </summary>
        /// <returns></returns>
        public DBFactory getDatabase()
        {
            switch (this.DBType.ToUpper())
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

        public void createConStr()
        {
            this.DBType = ini.IniReadValue("PacsConnectionString", "DbType");		// 连接HIS类型
            string server =  ini.IniReadValue("PacsConnectionString", "Server");    //
            string uid = ini.IniReadValue("PacsConnectionString", "Uid");			// HIS用户名
            string pwd = ini.IniReadValue("PacsConnectionString", "Pwd");			// HIS数据库密码
            string database = ini.IniReadValue("PacsConnectionString", "Database");		// 数据库HIS类型

            switch (this.DBType)
            {
                case "SQLSERVER":
                    this.StrConn = @"server=" + server.Trim() + ";uid=" + uid.Trim() + ";pwd=" + pwd.Trim() + ";database=" + database.Trim(); break;
                case "ORACLE":
                    this.StrConn = @"User ID=" + uid + ";Password=" + pwd + ";Data Source=" + database + ";"; break;
                case "ODBC":
                    this.StrConn = @"Driver={Microsoft ODBC for Oracle};Server=" + database + ";Uid=" + uid + ";Pwd=" + pwd; break;
                case "ACCESS":
                    this.StrConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + database; break;

            }
        }
    }
}
