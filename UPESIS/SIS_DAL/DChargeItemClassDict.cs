using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using ILL;
using SIS_Model;

namespace SIS_DAL
{
    /// <summary>
    /// 对CHARGE_ITEM_CLASS_DICT，价格项目分类
    /// </summary>
    public class DChargeItemClassDict : IChargeItemClassDict
    {
        private string strSql;
        private string TableName = "CHARGE_ITEM_CLASS_DICT";
        public DChargeItemClassDict()
            : base(GetConfig.GetSisConnStr())
        {
        }

        /// <summary>
        /// 插入一条收费分类记录
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
        /// 批量插入收费分类记录
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int AddMore(Hashtable ht2)
        {
            MChargeItemClassDict chargeItemClassDict = new MChargeItemClassDict();
            Hashtable ht = new Hashtable();
            Hashtable htstr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    chargeItemClassDict = (MChargeItemClassDict)ht2[i];
                    ht.Add("CLASS_CODE", chargeItemClassDict.CLASS_CODE);
                    ht.Add("CLASS_NAME", chargeItemClassDict.CLASS_NAME);
                    htstr.Add(i, StringConstructor.InsertSql(TableName, ht).ToString());
                }
                return ExecuteNonSql(htstr);

            }
            else
                return 0;
        }

        /// <summary>
        /// 查询是否存在指定的收费分类记录
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
        /// 获取指定分类代码的收费分类记录
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
        /// 获取符合条件的收费分类的列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定的收费分类记录
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
        /// 批量更新收费分类记录
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int UpdateMore(Hashtable ht2)
        {
            MChargeItemClassDict chargeItemClassDict = new MChargeItemClassDict();
            Hashtable ht = new Hashtable();
            Hashtable htStr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    chargeItemClassDict = (MChargeItemClassDict)ht2[i];
                    ht.Add("CLASS_CODE", chargeItemClassDict.CLASS_CODE);
                    ht.Add("CLASS_NAME", chargeItemClassDict.CLASS_NAME);
                    htStr.Add(i, StringConstructor.UpdateSql(TableName, ht, " where CLASS_CODE='" + chargeItemClassDict.CLASS_CODE + "'"));
                }

                return ExecuteNonSql(htStr);
            }
            return 0;
        }

        /// <summary>
        /// 删除符合条件的收费分类记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }

    }
}