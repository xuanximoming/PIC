﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace ILL
{
    /// <summary>
    /// 继承DBControl的抽象类IPatientInfLocalId,操作Patient_Inf_LocalId,病人信息与检查号对照表
    /// </summary>
    public abstract class IPatientInfLocalId : DBControl
    {
        public IPatientInfLocalId(ConParam cps)
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

        public virtual IModel GetModel(string PrimaryKey1,string PrimaryKey2)
        {
            return null;
        }
        public virtual int Delete(string where)
        {
            return -1;
        }
    }
}
