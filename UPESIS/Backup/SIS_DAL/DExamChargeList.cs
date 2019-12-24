using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Collections;
using SIS_Model;
using ILL;

namespace SIS_DAL
{
    /// <summary>
    /// 对EXAM_CHARGE_LIST，检查收费明细表
    /// </summary>
    public class DExamChargeList : IExamChargeList
    {
        private string strSql;
        private string TableName = "EXAM_CHARGE_LIST";
        public DExamChargeList()
            : base(GetConfig.GetSisConnStr())
        {
        }

        /// <summary>
        /// 插入一条检查明细记录
        /// </summary>
        /// <param name="iexamChargeList"></param>
        /// <returns></returns>
        public override int Add(IModel iexamChargeList)
        {
            MExamChargeList examChargeList = (MExamChargeList)iexamChargeList;
            Hashtable ht = new Hashtable();
            ht.Add("EXAM_NO", examChargeList.EXAM_NO);
            ht.Add("PATIENT_ID", examChargeList.PATIENT_ID);
            ht.Add("EXAM_CONFIRM_TIME", examChargeList.EXAM_CONFIRM_TIME);
            ht.Add("EXAM_ITEM_CODE", examChargeList.EXAM_ITEM_CODE);
            ht.Add("CHARGE_ITEM_CODE", examChargeList.CHARGE_ITEM_CODE);
            ht.Add("CHARGE_ITEM_SPEC", examChargeList.CHARGE_ITEM_SPEC);
            ht.Add("AMOUNT", examChargeList.AMOUNT);
            ht.Add("UNITS", examChargeList.UNITS);
            ht.Add("COST", examChargeList.COST);
            ht.Add("CHARGE", examChargeList.CHARGE);
            ht.Add("CHARGE_ITEM_NO", examChargeList.CHARGE_ITEM_NO);
            ht.Add("CHARGE_ITEM_CLASS", examChargeList.CHARGE_ITEM_CLASS);
            ht.Add("CHARGE_CLASS_NAME", examChargeList.CHARGE_CLASS_NAME);
            ht.Add("ITEM_NO", examChargeList.ITEM_NO);
            ht.Add("CHARGE_ITEM_NAME", examChargeList.CHARGE_ITEM_NAME);
            ht.Add("PRICE", examChargeList.PRICE);
            ht.Add("EXAM_ITEM_NO", examChargeList.EXAM_ITEM_NO);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 批量插入检查明细记录
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int AddMore(Hashtable ht2)
        {
            MExamChargeList examChargeList = new MExamChargeList();
            Hashtable ht = new Hashtable();
            Hashtable htstr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    examChargeList = (MExamChargeList)ht2[i];
                    ht.Add("EXAM_NO", examChargeList.EXAM_NO);
                    ht.Add("PATIENT_ID", examChargeList.PATIENT_ID);
                    ht.Add("EXAM_CONFIRM_TIME", examChargeList.EXAM_CONFIRM_TIME);
                    ht.Add("EXAM_ITEM_CODE", examChargeList.EXAM_ITEM_CODE);
                    ht.Add("CHARGE_ITEM_CODE", examChargeList.CHARGE_ITEM_CODE);
                    ht.Add("CHARGE_ITEM_SPEC", examChargeList.CHARGE_ITEM_SPEC);
                    ht.Add("AMOUNT", examChargeList.AMOUNT);
                    ht.Add("UNITS", examChargeList.UNITS);
                    ht.Add("COST", examChargeList.COST);
                    ht.Add("CHARGE", examChargeList.CHARGE);
                    ht.Add("CHARGE_ITEM_NO", examChargeList.CHARGE_ITEM_NO);
                    ht.Add("CHARGE_ITEM_CLASS", examChargeList.CHARGE_ITEM_CLASS);
                    ht.Add("CHARGE_CLASS_NAME", examChargeList.CHARGE_CLASS_NAME);
                    ht.Add("ITEM_NO", examChargeList.ITEM_NO);
                    ht.Add("CHARGE_ITEM_NAME", examChargeList.CHARGE_ITEM_NAME);
                    ht.Add("PRICE", examChargeList.PRICE);
                    ht.Add("EXAM_ITEM_NO", examChargeList.EXAM_ITEM_NO);
                    htstr.Add(i, StringConstructor.InsertSql(TableName, ht).ToString());
                }
                return ExecuteNonSql(htstr);

            }
            else
                return 0;
        }

        /// <summary>
        /// 查询是否存在指定的检查明细记录
        /// </summary>
        /// <param name="iexamChargeList"></param>
        /// <returns></returns>
        public override bool Exists(IModel iexamChargeList)
        {
            MExamChargeList examChargeList = (MExamChargeList)iexamChargeList;
            strSql = "select * from " + TableName + " where EXAM_NO='" + examChargeList.EXAM_NO + "' and " +
                     "EXAM_ITEM_CODE = '" + examChargeList.EXAM_ITEM_CODE + "' and " +
                     "CHARGE_ITEM_CODE = '" + examChargeList.CHARGE_ITEM_CODE + "' and " +
                     "CHARGE_ITEM_SPEC= '" + examChargeList.CHARGE_ITEM_SPEC + "' and " +
                     "EXAM_ITEM_NO= " + examChargeList.EXAM_ITEM_NO + " and " +
                     "CHARGE_ITEM_NO= " + examChargeList.CHARGE_ITEM_NO + "";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取指定主键的检查明细记录
        /// </summary>
        /// <param name="PrimaryKey"></param>
        /// <returns></returns>
        public override IModel GetModel(string PrimaryKey)
        {
            return null;
        }

        /// <summary>
        /// 获取符合条件的检查明细列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定的检查明细记录
        /// </summary>
        /// <param name="iexamChargeList"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel iexamChargeList, string where)
        {
            MExamChargeList examChargeList = (MExamChargeList)iexamChargeList;
            Hashtable ht = new Hashtable();
            ht.Add("EXAM_NO", examChargeList.EXAM_NO);
            ht.Add("PATIENT_ID", examChargeList.PATIENT_ID);
            ht.Add("EXAM_CONFIRM_TIME", examChargeList.EXAM_CONFIRM_TIME);
            ht.Add("EXAM_ITEM_CODE", examChargeList.EXAM_ITEM_CODE);
            ht.Add("CHARGE_ITEM_CODE", examChargeList.CHARGE_ITEM_CODE);
            ht.Add("CHARGE_ITEM_SPEC", examChargeList.CHARGE_ITEM_SPEC);
            ht.Add("AMOUNT", examChargeList.AMOUNT);
            ht.Add("UNITS", examChargeList.UNITS);
            ht.Add("COST", examChargeList.COST);
            ht.Add("CHARGE", examChargeList.CHARGE);
            ht.Add("CHARGE_ITEM_NO", examChargeList.CHARGE_ITEM_NO);
            ht.Add("CHARGE_ITEM_CLASS", examChargeList.CHARGE_ITEM_CLASS);
            ht.Add("CHARGE_CLASS_NAME", examChargeList.CHARGE_CLASS_NAME);
            ht.Add("ITEM_NO", examChargeList.ITEM_NO);
            ht.Add("CHARGE_ITEM_NAME", examChargeList.CHARGE_ITEM_NAME);
            ht.Add("PRICE", examChargeList.PRICE);
            ht.Add("EXAM_ITEM_NO", examChargeList.EXAM_ITEM_NO);
            return (ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString()));
        }

        /// <summary>
        /// 删除符合条件的检查明细记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}