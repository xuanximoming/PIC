using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace ILL
{
    /// <summary>
    /// 继承DBControl的抽象类IKnowledgeBase，操作Knowledge_Base,SIS的知识库
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

        public virtual IModel GetModel(string PrimaryKey1, string PrimaryKey2, string PrimaryKey3)
        {
            return null;
        }
        public virtual int Delete(string where)
        {
            return -1;
        }
        public virtual int DeleteMore(Hashtable ht)//批量更新
        {
            return -1;
        }
    }
}
