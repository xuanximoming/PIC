using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace ILL
{
    /// <summary>
    /// 继承DBControl的抽象类IReportTempDict,操作Report_Temp_Dict，SIS的报告模板字典
    /// </summary>
    public abstract class IReportTempDict : DBControl
    {
        public IReportTempDict(ConParam cps)
            : base(cps)
        {
        }
        public virtual int Add(IModel iModel)
        {
            return -1;
        }
        public virtual int AddMore(Hashtable ht)
        {
            return -1;
        }
        public virtual bool Exists(IModel iModel)
        {
            return false;
        }
        public virtual int Update(IModel iModel, string where)
        {
            return -1;
        }
        public virtual int UpdateMore(Hashtable ht)//批量更新
        {
            return -1;
        }
        public virtual DataTable GetList(string where)
        {
            return null;
        }
        public virtual DataTable GetList2(string where)
        {
            return null;
        }
        public virtual DataSet GetTable(string sql)
        {
            return null;
        }
        public virtual IModel GetModel(string PrimaryKey)
        {
            return null;
        }
        public virtual int Delete(string where)
        {
            return -1;
        }
        public virtual int DeleteMore(Hashtable ht)
        {
            return -1;
        }

        public virtual IModel[] GetModels(string NODE_ID)
        {
            return null;
        }

        public virtual int AddMore(object rptTemps)
        {
            return -1;
        }
    }
}
