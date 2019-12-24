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
    /// ��Charge_Class���շ�����
    /// </summary>
    public class DChargeClass : IChargeClass
    {
        private string strSql;
        private string TableName = "Charge_Class";
        public DChargeClass()
            : base(GetConfig.GetSisConnStr())
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
            ht.Add("CHARGE_CLASS_ID", chargeclass.CHARGE_CLASS_ID);
            ht.Add("CHARGE_CLASS", chargeclass.CHARGE_CLASS);
            ht.Add("CHARGE_RATIO", chargeclass.CHARGE_RATIO);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// ���������շ�����¼
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int AddMore(Hashtable ht2)
        {
            MChargeClass chargeclass = new MChargeClass();
            Hashtable ht = new Hashtable();
            Hashtable htstr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    chargeclass = (MChargeClass)ht2[i];
                    ht.Add("CHARGE_CLASS_ID", chargeclass.CHARGE_CLASS_ID);
                    ht.Add("CHARGE_CLASS", chargeclass.CHARGE_CLASS);
                    ht.Add("CHARGE_RATIO", chargeclass.CHARGE_RATIO);
                    htstr.Add(i, StringConstructor.InsertSql(TableName, ht).ToString());
                }
                return ExecuteNonSql(htstr);

            }
            else
                return 0;
        }

        /// <summary>
        /// ��ѯ�Ƿ����ָ�����շ����
        /// </summary>
        /// <param name="ichargeclass"></param>
        /// <returns></returns>
        public override bool Exists(IModel ichargeclass)
        {
            MChargeClass chargeclass = (MChargeClass)ichargeclass;
            strSql = "select * from " + TableName + " where CHARGE_CLASS_ID=" + chargeclass.CHARGE_CLASS_ID;
            return recordIsExist(strSql);
        }

        /// <summary>
        /// ��ȡָ���շ����ID���շ�����¼
        /// </summary>
        /// <param name="CHARGE_CLASS_ID"></param>
        /// <returns></returns>
        public override IModel GetModel(string CHARGE_CLASS_ID)
        {
            strSql = "select * from " + TableName + " where CHARGE_CLASS_ID = " + CHARGE_CLASS_ID;
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MChargeClass chargeclass = new MChargeClass();

            if (dt.Rows[0]["CHARGE_CLASS"].ToString() == "")
                chargeclass.CHARGE_CLASS_ID = null;
            else
                chargeclass.CHARGE_CLASS_ID = Convert.ToInt32(dt.Rows[0]["CHARGE_CLASS_ID"].ToString());

            chargeclass.CHARGE_CLASS = dt.Rows[0]["CHARGE_CLASS"].ToString();

            if (dt.Rows[0]["CHARGE_RATIO"].ToString() == "")
                chargeclass.CHARGE_RATIO = null;
            else
                chargeclass.CHARGE_RATIO = Convert.ToDecimal(dt.Rows[0]["CHARGE_RATIO"].ToString());

            return chargeclass;
        }

        /// <summary>
        /// ��ȡ�����������շ�����б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// ����ָ�����շ�����¼
        /// </summary>
        /// <param name="ichargeclass"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel ichargeclass, string where)
        {
            MChargeClass chargeclass = (MChargeClass)ichargeclass;
            Hashtable ht = new Hashtable();
            ht.Add("CHARGE_CLASS_ID", chargeclass.CHARGE_CLASS_ID);
            ht.Add("CHARGE_CLASS", chargeclass.CHARGE_CLASS);
            ht.Add("CHARGE_RATIO", chargeclass.CHARGE_RATIO);
            return (ExecuteSql(StringConstructor.UpdateSql(TableName, ht,where).ToString()));
        }

        /// <summary>
        /// ���������շ����
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int UpdateMore(Hashtable ht2)
        {
            MChargeClass chargeclass = new MChargeClass();
            Hashtable ht = new Hashtable();
            Hashtable htStr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    chargeclass = (MChargeClass)ht2[i];
                    ht.Add("CHARGE_CLASS_ID", chargeclass.CHARGE_CLASS_ID);
                    ht.Add("CHARGE_CLASS", chargeclass.CHARGE_CLASS);
                    ht.Add("CHARGE_RATIO", chargeclass.CHARGE_RATIO);
                    htStr.Add(i, StringConstructor.UpdateSql(TableName, ht, " where CHARGE_CLASS_ID=" + chargeclass.CHARGE_CLASS_ID));
                }

                return ExecuteNonSql(htStr);
            }
            return 0;
        }

        /// <summary>
        /// ɾ�������������շ�����¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}