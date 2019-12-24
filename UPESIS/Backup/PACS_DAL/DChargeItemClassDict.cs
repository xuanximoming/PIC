using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using ILL;
using PACS_Model;

namespace PACS_DAL
{
    /// <summary>
    /// CHARGE_ITEM_CLASS_DICT,即收费项目分类字典
    /// </summary>
    public class DChargeItemClassDict : IChargeItemClassDict
    {
        private string strSql;
        private string TableName = "CHARGE_ITEM_CLASS_DICT";
        public DChargeItemClassDict()
            : base(GetConfig.GetPacsConnStr())
        {
        }

        /// <summary>
        /// 插入一条收费项目字典记录
        /// </summary>
        /// <param name="ichargeItemClassDict"></param>
        /// <returns></returns>
        public override int Add(IModel ichargeItemClassDict)
        {
            MChargeItemClassDict chargeItemClassDict = (MChargeItemClassDict)ichargeItemClassDict;
            Hashtable ht = new Hashtable();
            ht.Add("CLASS_CODE", chargeItemClassDict.CLASS_CODE);
            ht.Add("CLASS_NAME", chargeItemClassDict.CLASS_NAME);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 查询指定的收费项目字典记录
        /// </summary>
        /// <param name="ichargeItemClassDict"></param>
        /// <returns></returns>
        public override bool Exists(IModel ichargeItemClassDict)
        {
            MChargeItemClassDict chargeItemClassDict = (MChargeItemClassDict)ichargeItemClassDict;
            strSql = "select * from " + TableName + " where CLASS_CODE='" + chargeItemClassDict.CLASS_CODE + "'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取一条符合条件的收费项目分类字典记录
        /// </summary>
        /// <param name="classCode"></param>
        /// <returns></returns>
        public override IModel GetModel(string classCode)
        {
            strSql = "select * from " + TableName + "  where CLASS_CODE='" + classCode + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MChargeItemClassDict chargeItemClassDict = new MChargeItemClassDict();
            chargeItemClassDict.CLASS_CODE = dt.Rows[0]["CLASS_CODE"].ToString();
            chargeItemClassDict.CLASS_NAME = dt.Rows[0]["CLASS_NAME"].ToString();
            return chargeItemClassDict;
        }

        /// <summary>
        /// 获取符合条件的收费项目分类的所有字典记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定的收费项目字典记录
        /// </summary>
        /// <param name="ichargeItemClassDict"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel ichargeItemClassDict, string where)
        {
            MChargeItemClassDict chargeItemClassDict = (MChargeItemClassDict)ichargeItemClassDict;
            Hashtable ht = new Hashtable();
            ht.Add("CLASS_CODE", chargeItemClassDict.CLASS_CODE);
            ht.Add("CLASS_NAME", chargeItemClassDict.CLASS_NAME);
            return ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString());
        }

        /// <summary>
        /// 删除符合条件的收费项目字典记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }

    }
}
