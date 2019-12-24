using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace ILL
{
    /// <summary>
    /// 继承DBControl的抽象类ChargeItemClassDict,操作Charge_Item_Class_Dict，价格项目分类字典
    /// </summary>
    public abstract class IChargeItemClassDict : DBControl
    {
        public IChargeItemClassDict(ConParam cps)
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
        public virtual int Delete(string where)
        {
            return -1;
        }
    }
}
