using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using ILL;
using SIS_Model;
using System.Windows.Forms;

namespace SIS_DAL
{
    /// <summary>
    /// 对CHARGE_ITEM_DICT，价表项目字典
    /// </summary>
    public class DChargeItemDict : IChargeItemDict
    {
        private string strSql;
        private string TableName = "CHARGE_ITEM_DICT";
        public DChargeItemDict()
            : base(GetConfig.GetSisConnStr())
        {
        }

        /// <summary>
        /// 插入一条价表项目字典记录
        /// </summary>
        /// <param name="iChargeItemDict"></param>
        /// <returns></returns>
        public override int Add(IModel iChargeItemDict)
        {
            MChargeItemDict chargeItemDict = (MChargeItemDict)iChargeItemDict;
            Hashtable ht = new Hashtable();
            ht.Add("CHARGE_ITEM_CODE", chargeItemDict.CHARGE_ITEM_CODE);
            ht.Add("CHARGE_ITEM_SPEC", chargeItemDict.CHARGE_ITEM_SPEC);
            ht.Add("UNITS", chargeItemDict.UNITS);
            ht.Add("START_DATE", chargeItemDict.START_DATE);
            ht.Add("CHARGE_ITEM_NAME", chargeItemDict.CHARGE_ITEM_NAME);
            ht.Add("INPUT_CODE", chargeItemDict.INPUT_CODE);
            ht.Add("PRICE", chargeItemDict.PRICE);
            ht.Add("STOP_DATE", chargeItemDict.STOP_DATE);
            ht.Add("OPERATOR", chargeItemDict.OPERATOR);
            ht.Add("ENTER_DATE", chargeItemDict.ENTER_DATE);
            ht.Add("MEMO", chargeItemDict.MEMO);
            ht.Add("CHARGE_ITEM_CLASS", chargeItemDict.CHARGE_ITEM_CLASS);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 查询是否存在指定的价表项目记录
        /// </summary>
        /// <param name="iChargeItemDict"></param>
        /// <returns></returns>
        public override bool Exists(IModel iChargeItemDict)
        {
            MChargeItemDict chargeItemDict = (MChargeItemDict)iChargeItemDict;

            strSql = "select * from " + TableName + " where CHARGE_ITEM_CLASS = '"+ chargeItemDict.CHARGE_ITEM_CLASS+"' and CHARGE_ITEM_CODE='" + chargeItemDict.CHARGE_ITEM_CODE + "' and CHARGE_ITEM_SPEC='" + chargeItemDict.CHARGE_ITEM_SPEC+ "' and UNITS='"+chargeItemDict.UNITS+"' and START_DATE='"+chargeItemDict.START_DATE+"'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 查询否存在输入条件的价表项目记录
        /// </summary>
        /// <returns></returns>
        public override bool ExistsWhere(string StrWhe)
        {
            strSql = "select * from " + TableName + " where " + StrWhe;
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 重新获取指定价表项目记录
        /// </summary>
        /// <param name="iChargeItemDict"></param>
        /// <returns></returns>
        public override IModel GetModel(IModel iChargeItemDict)
        {
            MChargeItemDict chargeItemDict = (MChargeItemDict)iChargeItemDict;
            strSql = "select * from " + TableName + " where CHARGE_ITEM_CLASS = '" + chargeItemDict.CHARGE_ITEM_CLASS + "' and CHARGE_ITEM_CODE='" + chargeItemDict.CHARGE_ITEM_CODE + "' and CHARGE_ITEM_SPEC='" + chargeItemDict.CHARGE_ITEM_SPEC + "' and UNITS='" + chargeItemDict.UNITS + "' and START_DATE='" + chargeItemDict.START_DATE + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MChargeItemDict model = new MChargeItemDict();
            model.CHARGE_ITEM_CLASS = dt.Rows[0]["CHARGE_ITEM_CLASS"].ToString();
            model.CHARGE_ITEM_CODE = dt.Rows[0]["CHARGE_ITEM_CODE"].ToString();
            model.CHARGE_ITEM_SPEC = dt.Rows[0]["CHARGE_ITEM_SPEC"].ToString();
            model.UNITS = dt.Rows[0]["UNITS"].ToString();
            if (dt.Rows[0]["ENTER_DATE"].ToString() == "")
                model.ENTER_DATE = null;
            else
                model.ENTER_DATE = Convert.ToDateTime(dt.Rows[0]["ENTER_DATE"].ToString());

            model.CHARGE_ITEM_NAME = dt.Rows[0]["CHARGE_ITEM_NAME"].ToString();
            model.INPUT_CODE = dt.Rows[0]["INPUT_CODE"].ToString();

            if (dt.Rows[0]["PRICE"].ToString() == "")
                model.PRICE= null;
            else
                model.PRICE = Convert.ToDecimal(dt.Rows[0]["PRICE"].ToString());

            if (dt.Rows[0]["STOP_DATE"].ToString() == "")
                model.STOP_DATE = null;
            else
                model.STOP_DATE = Convert.ToDateTime(dt.Rows[0]["STOP_DATE"].ToString());

            model.OPERATOR = dt.Rows[0]["OPERATOR"].ToString();
            if (dt.Rows[0]["ENTER_DATE"].ToString() == "")
                model.ENTER_DATE = null;
            else
                model.ENTER_DATE = Convert.ToDateTime(dt.Rows[0]["ENTER_DATE"].ToString());
            model.MEMO = dt.Rows[0]["MEMO"].ToString();
            return model;
        }

        /// <summary>
        /// 获取符合条件的价表项目列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 批量获取符合条件的价表项目列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetListMore(string where)
        {
            if (where =="")
                strSql = "select a.CHARGE_ITEM_CLASS,a.CHARGE_ITEM_CODE,a.CHARGE_ITEM_SPEC,a.UNITS,a.START_DATE,a.CHARGE_ITEM_NAME,a.INPUT_CODE,a.PRICE,a.STOP_DATE,a.OPERATOR,a.ENTER_DATE,a.MEMO,b.CLASS_NAME " +
                            " from CHARGE_ITEM_DICT a,CHARGE_ITEM_CLASS_DICT b where a.CHARGE_ITEM_CLASS=b.CLASS_CODE order by a.CHARGE_ITEM_CLASS ,a.CHARGE_ITEM_CODE asc";
            else
                strSql = "select a.CHARGE_ITEM_CLASS,a.CHARGE_ITEM_CODE,a.CHARGE_ITEM_SPEC,a.UNITS,a.START_DATE,a.CHARGE_ITEM_NAME,a.INPUT_CODE,a.PRICE,a.STOP_DATE,a.OPERATOR,a.ENTER_DATE,a.MEMO,b.CLASS_NAME " +
                            " from CHARGE_ITEM_DICT a,CHARGE_ITEM_CLASS_DICT b where a.CHARGE_ITEM_CLASS=b.CLASS_CODE and " + where  + " 1=1 order by a.CHARGE_ITEM_CLASS ,a.CHARGE_ITEM_CODE asc";

            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定的价表项目记录
        /// </summary>
        /// <param name="iChargeItemDict"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel iChargeItemDict, string where)
        {
            MChargeItemDict chargeItemDict = (MChargeItemDict)iChargeItemDict;
            Hashtable ht = new Hashtable();
            ht.Add("CHARGE_ITEM_CODE", chargeItemDict.CHARGE_ITEM_CODE);
            ht.Add("CHARGE_ITEM_SPEC", chargeItemDict.CHARGE_ITEM_SPEC);
            ht.Add("UNITS", chargeItemDict.UNITS);
            ht.Add("START_DATE", chargeItemDict.START_DATE);
            ht.Add("CHARGE_ITEM_NAME", chargeItemDict.CHARGE_ITEM_NAME);
            ht.Add("INPUT_CODE", chargeItemDict.INPUT_CODE);
            ht.Add("PRICE", chargeItemDict.PRICE);
            ht.Add("STOP_DATE", chargeItemDict.STOP_DATE);
            ht.Add("OPERATOR", chargeItemDict.OPERATOR);
            ht.Add("ENTER_DATE", chargeItemDict.ENTER_DATE);
            ht.Add("MEMO", chargeItemDict.MEMO);
            ht.Add("CHARGE_ITEM_CLASS", chargeItemDict.CHARGE_ITEM_CLASS);
            return ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString());
        }

        /// <summary>
        /// 删除符合条件的价表项目记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }

        /// <summary>
        /// 批量删除价表项目记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public override int DeleteMore(Hashtable ht)
        {
            this.Open();
            IDbCommand dbCom = dbF.getDBCommand();
            dbCom.Connection = this.dbConn;
            IDbTransaction tran = dbF.getTransaction(this.dbConn);
            dbCom.Transaction = tran;
            dbCom.CommandType = CommandType.Text;
            try
            {
                foreach (DictionaryEntry item in ht)
                {
                    dbCom.CommandText = "Delete CHARGE_ITEM_DICT where CHARGE_ITEM_CODE='" + item.Value.ToString() + "'";

                    dbCom.ExecuteNonQuery();
                }
                tran.Commit();
                return ht.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                tran.Rollback();
                MessageBox.Show("数据库事物处理错误！");
                return 0;
            }
            finally
            {
                this.Close();
            }
        }
    }
}