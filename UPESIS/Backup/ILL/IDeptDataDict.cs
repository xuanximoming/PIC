using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace ILL
{
    /// <summary>
    /// 继承DBControl的抽象类IDeptDataDict,操作Dept_Data_Dict，PACS的科室数据字典
    /// </summary>
    public abstract class IDeptDataDict : DBControl
    {
        public IDeptDataDict(ConParam cps)
            : base(cps)
        {
        }
        public virtual int Add(IModel iModel)
        {
            return -1;
        }

        public virtual int Add1(IModel iModel, ref System.Data.OracleClient.OracleDataAdapter sda)
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
        public virtual int Update1(IModel iModel, ref System.Data.OracleClient.OracleDataAdapter sda)
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

        public virtual DataSet GetList1(string where, ref System.Data.OracleClient.OracleDataAdapter sda)
        {
            return null;
        }

        public virtual IModel GetModel(string DEPT_CODE, string DATA_NAME, string DATA_TYPE, DateTime MODIFY_DATE_TIME)
        {
            return null;
        }
        public virtual int Delete(string where)
        {
            return -1;
        }
    }
}
