using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Collections;
using PACS_Model;
using ILL;

namespace PACS_DAL
{
    /// <summary>
    /// ��CHARGE_TYPE_DICT�����շ�����
    /// </summary>
    public class DChargeClass : IChargeClass
    {
        private string strSql;
        private string TableName = "CHARGE_TYPE_DICT";
        public DChargeClass()
            : base(GetConfig.GetPacsConnStr())
        {
        }

        /// <summary>
        /// ����һ���շ�����¼
        /// </summary>
        /// <param name="ichargeclass"></param>
        /// <returns></returns>
        public override int Add(IModel ichargeclass)
        {
            MChargeClass chargeclass = (MChargeClass)ichargeclass;
            Hashtable ht = new Hashtable();
            ht.Add("CHARGE_TYPE_CODE", chargeclass.CHARGE_TYPE_CODE);
            ht.Add("CHARGE_TYPE", chargeclass.CHARGE_TYPE);
            ht.Add("CHARGE_RATIO", chargeclass.CHARGE_RATIO);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// ��ѯ�Ƿ����ָ�����շ�����¼
        /// </summary>
        /// <param name="ichargeclass"></param>
        /// <returns></returns>
        public override bool Exists(IModel ichargeclass)
        {
            MChargeClass chargeclass = (MChargeClass)ichargeclass;
            strSql = "select * from " + TableName + " where CHARGE_TYPE_CODE=" + chargeclass.CHARGE_TYPE_CODE;
            return recordIsExist(strSql);
        }

        /// <summary>
        /// ��ȡָ���ķѱ�ID���շ�����¼
        /// </summary>
        /// <param name="CHARGE_CLASS_ID"></param>
        /// <returns></returns>
        public override IModel GetModel(string CHARGE_CLASS_ID)
        {
            strSql = "select * from " + TableName + " where CHARGE_TYPE_CODE = " + CHARGE_CLASS_ID;
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MChargeClass chargeclass = new MChargeClass();

            if (dt.Rows[0]["CHARGE_TYPE_CODE"].ToString() == "")
                chargeclass.CHARGE_TYPE_CODE = null;
            else
                chargeclass.CHARGE_TYPE_CODE = Convert.ToInt32(dt.Rows[0]["CHARGE_TYPE_CODE"].ToString());

            chargeclass.CHARGE_TYPE = dt.Rows[0]["CHARGE_TYPE"].ToString();

            if (dt.Rows[0]["CHARGE_RATIO"].ToString() == "")
                chargeclass.CHARGE_RATIO = null;
            else
                chargeclass.CHARGE_RATIO = Convert.ToDecimal(dt.Rows[0]["CHARGE_RATIO"].ToString());

            return chargeclass;
        }

        /// <summary>
        /// ��ȡָ���������շ�����б��¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// ����ָ���������շ�����¼
        /// </summary>
        /// <param name="ichargeclass"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel ichargeclass, string where)
        {
            MChargeClass chargeclass = (MChargeClass)ichargeclass;
            Hashtable ht = new Hashtable();
            ht.Add("CHARGE_TYPE_CODE", chargeclass.CHARGE_TYPE_CODE);
            ht.Add("CHARGE_TYPE", chargeclass.CHARGE_TYPE);
            ht.Add("CHARGE_RATIO", chargeclass.CHARGE_RATIO);
            return (ExecuteSql(StringConstructor.UpdateSql(TableName, ht,where).ToString()));
        }

        /// <summary>
        /// ɾ��ָ���������շ�����¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}
