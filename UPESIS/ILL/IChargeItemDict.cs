using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace ILL
{
    /// <summary>
    /// �̳�DBControl�ĳ�����IChargeItemDict������Charge_Item_Dict���۸���Ŀ�ֵ�
    /// </summary>
    public abstract class IChargeItemDict : DBControl
    {
        public IChargeItemDict(ConParam cps)
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

        public virtual bool ExistsWhere(string sql)
        {
            return false;
        }

        public virtual int Update(IModel iModel, string where)
        {
            return -1;
        }
        public virtual int UpdateMore(Hashtable ht)//��������
        {
            return -1;
        }
        public virtual DataTable GetList(string where)
        {
            return null;
        }

        public virtual DataTable GetListMore(string where)
        {
            return null;
        }

        public virtual IModel GetModel(IModel imodel)
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


    }
}
