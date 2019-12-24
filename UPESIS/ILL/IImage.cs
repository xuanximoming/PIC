using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace ILL
{
    /// <summary>
    /// 继承DBControl的抽象类IImage，操作Image，SIS的图像表
    /// </summary>
    public abstract class IImage : DBControl
    {
        public IImage(ConParam cps)
            : base(cps)
        {
        }
        public virtual int Add(IModel iModel)
        {
            return -1;
        }
        public virtual int Add(IModel iModel,ref int imageId)
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

        public virtual IModel GetModel(string PrimaryKey1)
        {
            return null;
        }
        public virtual IModel GetModel(DataRow dr)
        {
            return null;
        }
        public virtual int Delete(string where)
        {
            return -1;
        }
    }
}
