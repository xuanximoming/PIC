using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace ILL
{
    /// <summary>
    /// 继承DBConctrol的抽象类IClinicOfficeDict，操作Clinic_Office_Dict，SIS的临床科室表
    /// </summary>
    public abstract class IClinicOfficeDict : DBControl
    {
        public IClinicOfficeDict(ConParam cps)
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

        public virtual IModel GetModel(string PrimaryKey)
        {
            return null;
        }
        public virtual IModel GetModel2(string Key)
        {
            return null;
        }
        public virtual int Delete(string where)
        {
            return -1;
        }
        public virtual DataSet GetData(string where)
        {
            return null;
        }
    }
}
