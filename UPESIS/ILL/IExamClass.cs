using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace ILL
{
    /// <summary>
    /// 继承DBControl的抽象类IExamClass，操作Exam_Class，检查类别表
    /// </summary
    public abstract class IExamClass : DBControl
    {
        public IExamClass(ConParam cps)
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
        public virtual DataTable GetExamClass(string where)
        {
            return null;
        }
        public virtual IModel GetModel(string PrimaryKey1, string PrimaryKey2)
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
        public virtual DataSet GetData()
        {
            return null;
        }
    }
}
