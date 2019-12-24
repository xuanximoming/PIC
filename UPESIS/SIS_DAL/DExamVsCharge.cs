using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using SIS_Model;
using ILL;

namespace SIS_DAL
{
    /// <summary>
    /// ��EXAM_VS_CHARGE�������Ŀ��۱���Ŀ����
    /// </summary>
    public class DExamVsCharge:IExamVsCharge
    {
        private string strSql;
        private string TableName = "EXAM_VS_CHARGE";
        public DExamVsCharge()
            : base(GetConfig.GetSisConnStr())
        {
        }

        /// <summary>
        /// ����һ�����ռ�¼
        /// </summary>
        /// <param name="imodel"></param>
        /// <returns></returns>
        public override int Add(IModel imodel)
        {
            MExamVsCharge model = (MExamVsCharge)imodel;
            Hashtable ht = new Hashtable();
            ht.Add("EXAM_ITEM_CODE", model.EXAM_ITEM_CODE);
            ht.Add("CHARGE_ITEM_NO", model.CHARGE_ITEM_NO);
            ht.Add("CHARGE_ITEM_CODE", model.CHARGE_ITEM_CODE);
            ht.Add("CHARGE_ITEM_SPEC", model.CHARGE_ITEM_SPEC);
            ht.Add("AMOUNT", model.AMOUNT);
            ht.Add("UNITS", model.UNITS);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// ����������ռ�¼
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int AddMore(Hashtable ht2)
        {
            MExamVsCharge model = new MExamVsCharge();
            Hashtable ht = new Hashtable();
            Hashtable htstr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    model = (MExamVsCharge)ht2[i];
                    ht.Add("EXAM_ITEM_CODE", model.EXAM_ITEM_CODE);
                    ht.Add("CHARGE_ITEM_NO", model.CHARGE_ITEM_NO);
                    ht.Add("CHARGE_ITEM_CODE", model.CHARGE_ITEM_CODE);
                    ht.Add("CHARGE_ITEM_SPEC", model.CHARGE_ITEM_SPEC);
                    ht.Add("AMOUNT", model.AMOUNT);
                    ht.Add("UNITS", model.UNITS);
                    htstr.Add(i, StringConstructor.InsertSql(TableName, ht).ToString());
                }
                return ExecuteNonSql(htstr);
            }
            else
                return 0;
        }

        /// <summary>
        /// ��ѯ�Ƿ����ָ���Ķ��ռ�¼
        /// </summary>
        /// <param name="imodel"></param>
        /// <returns></returns>
        public override bool Exists(IModel imodel)
        {
            MExamVsCharge model = (MExamVsCharge)imodel;
            strSql = "select * from " + TableName + " where EXAM_ITEM_CODE='" + model.EXAM_ITEM_CODE + "' and CHARGE_ITEM_NO="+model.CHARGE_ITEM_NO;
            return recordIsExist(strSql);
        }

        /// <summary>
        /// ��ȡָ�������Ŀ���롢�շ���Ŀ��ŵĶ��ռ�¼
        /// </summary>
        /// <param name="ExamItemCode"></param>
        /// <param name="ChargeItemNo"></param>
        /// <returns></returns>
        public override IModel GetModel(string ExamItemCode,string ChargeItemNo)
        {
            strSql = "select * from " + TableName + "  where EXAM_ITEM_CODE='" + ExamItemCode + "' and CHARGE_ITEM_NO=" + ChargeItemNo;
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MExamVsCharge model = new MExamVsCharge();
            if (dt.Rows[0]["CHARGE_ITEM_NO"].ToString() == "")
                model.CHARGE_ITEM_NO = null;
            else
                model.CHARGE_ITEM_NO =Convert.ToInt32(dt.Rows[0]["CHARGE_ITEM_NO"].ToString());
            model.CHARGE_ITEM_CODE= dt.Rows[0]["CHARGE_ITEM_CODE"].ToString();
            if (dt.Rows[0]["AMOUNT"].ToString() == "")
                model.AMOUNT = null;
            else
                model.AMOUNT =Convert.ToInt32(dt.Rows[0]["AMOUNT"].ToString());
            model.CHARGE_ITEM_SPEC= dt.Rows[0]["CHARGE_ITEM_SPEC"].ToString();
            model.EXAM_ITEM_CODE= dt.Rows[0]["EXAM_ITEM_CODE"].ToString();
            model.UNITS = dt.Rows[0]["UNITS"].ToString();
            return model;
        }

        /// <summary>
        /// ��ȡ���������Ķ��ռ�¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// ��ȡ���������Ķ��ռ�¼��ָ���ֶ�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList2(string where)
        {
            strSql = "select a.*,b.PRICE,b.CHARGE_ITEM_NAME from " + TableName + " a,CHARGE_ITEM_DICT b where a.CHARGE_ITEM_CODE = b.CHARGE_ITEM_CODE and a.CHARGE_ITEM_SPEC = b.CHARGE_ITEM_SPEC and a.UNITS = b.UNITS and " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// ����ָ�����ռ�¼
        /// </summary>
        /// <param name="imodel"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel imodel, string where)
        {
            MExamVsCharge model = (MExamVsCharge)imodel;
            Hashtable ht = new Hashtable();
            ht.Add("EXAM_ITEM_CODE", model.EXAM_ITEM_CODE);
            ht.Add("CHARGE_ITEM_NO", model.CHARGE_ITEM_NO);
            ht.Add("CHARGE_ITEM_CODE", model.CHARGE_ITEM_CODE);
            ht.Add("CHARGE_ITEM_SPEC", model.CHARGE_ITEM_SPEC);
            ht.Add("AMOUNT", model.AMOUNT);
            ht.Add("UNITS", model.UNITS);
            return ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString());
        }

        /// <summary>
        /// ɾ�����������Ķ��ռ�¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }

        /// <summary>
        ///����������ɾ�����ռ�¼����֤ԭ����
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
                    dbCom.CommandText = "Delete " + TableName + " where EXAM_ITEM_CODE='" + item.Value.ToString() + "'";
                    dbCom.ExecuteNonQuery();
                }
                tran.Commit();
                return ht.Count;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                return 0;
            }
            finally
            {
                this.Close();//ע��Ҫ�ֶ��ͷŵ����ݿ�������Դ
            }
        }
    }
}