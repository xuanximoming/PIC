using System;
using System.Collections.Generic;
using System.Text;

namespace Update
{
    public class DBGetter
    {
        private string DBType;    //  ���ݿ�����
        private DBFactory dbF;    //  ���ݿ�ӿ�
        public string StrConn;    //  ���ݿ������ַ���
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
        /// ����app.config�������������ݿ����
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
            this.DBType = ini.IniReadValue("PacsConnectionString", "DbType");		// ����HIS����
            string server =  ini.IniReadValue("PacsConnectionString", "Server");    //
            string uid = ini.IniReadValue("PacsConnectionString", "Uid");			// HIS�û���
            string pwd = ini.IniReadValue("PacsConnectionString", "Pwd");			// HIS���ݿ�����
            string database = ini.IniReadValue("PacsConnectionString", "Database");		// ���ݿ�HIS����

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
