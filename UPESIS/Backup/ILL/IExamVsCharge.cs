using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace ILL
{
    /// <summary>
    /// �̳�DBControl�ĳ�����IExamVsCharge������Exam_Vs_Charge�������Ŀ��۱����
    /// </summary>
    public abstract class IExamVsCharge : DBControl
    {
        public IExamVsCharge(ConParam cps)
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
    }
}
