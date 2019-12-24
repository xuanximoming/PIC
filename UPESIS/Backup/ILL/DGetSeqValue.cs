using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ILL
{
   public  class DGetSeqValue:DBControl
    {
       private string SequenceName;
       private string value;
       public DGetSeqValue()
           : base(GetConfig.GetSisConnStr())
       {
       }
       public DGetSeqValue(string ConnectionType,string SequenceName)
           : base(ConnectionType)
       {
           this.SequenceName = SequenceName;
       }
       public string GetSeqValue()
       {
           string strSql = "";
           switch (GetConfig.SisOdbcMode)
           {
               case "ACCESS":
                   strSql = "select  " + SequenceName + " from sequence";
                   value = ExecuteScalar(strSql);
                   int v = int.Parse(value) + 1;
                   strSql = "update sequence set " + SequenceName + " = " + v.ToString();
                   ExecuteSql(strSql);
                   value = v.ToString();
                   break;
               case "ORACLE":
                   strSql = "select  " + SequenceName + ".nextval  from dual";
                   value = ExecuteScalar(strSql);
                   break;
               case "SQL":
                   break;
           }
           return value;
       }
       public bool UpdateSeq(string value)
       {
           string strSql = "update sequence set " + SequenceName + " = " + value;
           int i = ExecuteSql(strSql);
           return i >= 0 ? true : false;
       }
    }

}
