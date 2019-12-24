using System;
using System.Collections.Generic;
using System.Text;

namespace ILL
{
    /// <summary>
    /// 数据库连接实体类，包括数据类型，服务器名，连接用户名，连接密码，数据库名和驱动器
    /// </summary>
     public class ConParam
    {
         private string dbtype;
         private string server;
         private string uid;
         private string pwd;
         private string database;
         private string driver;

         public string DBType
         {
             set { this.dbtype = value; }
             get { return this.dbtype; }
         }
         public string Server
         {
             set { this.server = value; }
             get { return this.server; }
         }
         public string Uid
         {
             set { this.uid = value; }
             get { return this.uid; }
         }
         public string Pwd
         {
             set { this.pwd = value; }
             get { return this.pwd; }
         }
         public string Database
         {
             set { this.database = value; }
             get { return this.database; }
         }
         public string Driver
         {
             set { this.driver = value; }
             get { return this.driver; }
         }
    }
}
