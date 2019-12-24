using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace ILL
{
    /// <summary>
    /// �̳�DBControl�ĳ�����IKnowledgeBase������Knowledge_Base,SIS��֪ʶ��
    /// </summary>
    public abstract class IKnowledgeBase : DBControl
    {
        public IKnowledgeBase(ConParam cps)
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
        public virtual int UpdateMore(Hashtable ht)//��������
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

        public virtual IModel GetModel(string PrimaryKey1, string PrimaryKey2, string PrimaryKey3)
        {
            return null;
        }
        public virtual int Delete(string where)
        {
            return -1;
        }
        public virtual int DeleteMore(Hashtable ht)//��������
        {
            return -1;
        }
    }
}
