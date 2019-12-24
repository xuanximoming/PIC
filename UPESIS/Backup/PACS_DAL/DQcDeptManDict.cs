using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using ILL;
using PACS_Model;

namespace PACS_DAL
{
    public class DQcDeptManDict : IQcDeptManDict
    {
        private string strSql;
        private string TableName = "QC_DEPT_MAN_DICT";
        public DQcDeptManDict()
            : base(GetConfig.GetPacsConnStr())
        {
        }

        public override int Add(IModel iQcDeptManDict)
        {
            MQcDeptManDict qcDeptManDict = (MQcDeptManDict)iQcDeptManDict;
            Hashtable ht = new Hashtable();
            ht.Add("CRITERION_INTEGRALITY", qcDeptManDict.CRITERION_INTEGRALITY);
            ht.Add("DEDU_GIST_CRI_INT", qcDeptManDict.DEDU_GIST_CRI_INT);
            ht.Add("DEDU_GIST_DIAG_RPT", qcDeptManDict.DEDU_GIST_DIAG_RPT);
            ht.Add("DEDU_GIST_EME_EXAM", qcDeptManDict.DEDU_GIST_EME_EXAM);
            ht.Add("DEDU_GIST_IMAGE_SYS", qcDeptManDict.DEDU_GIST_IMAGE_SYS);
            ht.Add("DEDU_GIST_MAN_SYS", qcDeptManDict.DEDU_GIST_MAN_SYS);
            ht.Add("DEDU_GIST_MANAGEMENT", qcDeptManDict.DEDU_GIST_MANAGEMENT);
            ht.Add("DEDU_GIST_OS_RES", qcDeptManDict.DEDU_GIST_OS_RES);
            ht.Add("DEDU_GIST_POST_TRAIN", qcDeptManDict.DEDU_GIST_POST_TRAIN);
            ht.Add("DEDU_GIST_PRE_MEA", qcDeptManDict.DEDU_GIST_PRE_MEA);
            ht.Add("DEDU_GIST_REG_STAT", qcDeptManDict.DEDU_GIST_REG_STAT);
            ht.Add("DEDU_GIST_RY_LICENCE", qcDeptManDict.DEDU_GIST_RY_LICENCE);
            ht.Add("DEDU_GIST_SER_ITEMS", qcDeptManDict.DEDU_GIST_SER_ITEMS);
            ht.Add("DEDU_GIST_TITLES", qcDeptManDict.DEDU_GIST_TITLES);
            ht.Add("DEPT_MAN_KEY", qcDeptManDict.DEPT_MAN_KEY);
            ht.Add("DIAG_REPORT", qcDeptManDict.DIAG_REPORT);
            ht.Add("EMERGENCY_EXAM", qcDeptManDict.EMERGENCY_EXAM);
            ht.Add("IMAGE_SYSTEM", qcDeptManDict.IMAGE_SYSTEM);
            ht.Add("MANAGEMENT", qcDeptManDict.MANAGEMENT);
            ht.Add("MANAGEMENT_SYSTEM", qcDeptManDict.MANAGEMENT_SYSTEM);
            ht.Add("OVERSEE_RESULT", qcDeptManDict.OVERSEE_RESULT);
            ht.Add("POST_TRAIN", qcDeptManDict.POST_TRAIN);
            ht.Add("PREVENTIVE_MEASURE", qcDeptManDict.PREVENTIVE_MEASURE);
            ht.Add("QC_DATE", qcDeptManDict.QC_DATE);
            ht.Add("REGISTER_STAT", qcDeptManDict.REGISTER_STAT);
            ht.Add("RY_LICENCE", qcDeptManDict.RY_LICENCE);
            ht.Add("SERVICES_ITEMS", qcDeptManDict.SERVICES_ITEMS);
            ht.Add("TITLES", qcDeptManDict.TITLES);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        public override bool Exists(IModel iQcDeptManDict )
        {
            MQcDeptManDict qcDeptManDict = (MQcDeptManDict)iQcDeptManDict;
            strSql = "select * from " + TableName + " where QC_DATE=to_date('" + qcDeptManDict.QC_DATE.Value.ToShortDateString() + "','yyyy-mm-dd')";
            return recordIsExist(strSql);
        }

        public override IModel GetModel(string DEPT_MAN_KEY)
        {
            strSql = "select * from " + TableName + "  where DEPT_MAN_KEY='" + DEPT_MAN_KEY + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MQcDeptManDict qcDeptManDict = new MQcDeptManDict();
            if (dt.Rows[0]["CRITERION_INTEGRALITY"] == null)
                qcDeptManDict.CRITERION_INTEGRALITY = null;
            else
                qcDeptManDict.CRITERION_INTEGRALITY = Convert.ToInt32(dt.Rows[0]["CRITERION_INTEGRALITY"].ToString());
            qcDeptManDict.DEDU_GIST_CRI_INT = dt.Rows[0]["DEDU_GIST_CRI_INT"].ToString();
            qcDeptManDict.DEDU_GIST_DIAG_RPT = dt.Rows[0]["DEDU_GIST_DIAG_RPT"].ToString();
            qcDeptManDict.DEDU_GIST_EME_EXAM = dt.Rows[0]["DEDU_GIST_EME_EXAM"].ToString();
            qcDeptManDict.DEDU_GIST_IMAGE_SYS = dt.Rows[0]["DEDU_GIST_IMAGE_SYS"].ToString();
            qcDeptManDict.DEDU_GIST_MAN_SYS = dt.Rows[0]["DEDU_GIST_MAN_SYS"].ToString();
            qcDeptManDict.DEDU_GIST_MANAGEMENT = dt.Rows[0]["DEDU_GIST_MANAGEMENT"].ToString();
            qcDeptManDict.DEDU_GIST_OS_RES = dt.Rows[0]["DEDU_GIST_OS_RES"].ToString();
            qcDeptManDict.DEDU_GIST_POST_TRAIN = dt.Rows[0]["DEDU_GIST_POST_TRAIN"].ToString();
            qcDeptManDict.DEDU_GIST_PRE_MEA = dt.Rows[0]["DEDU_GIST_PRE_MEA"].ToString();
            qcDeptManDict.DEDU_GIST_REG_STAT = dt.Rows[0]["DEDU_GIST_REG_STAT"].ToString();
            qcDeptManDict.DEDU_GIST_RY_LICENCE = dt.Rows[0]["DEDU_GIST_RY_LICENCE"].ToString();
            qcDeptManDict.DEDU_GIST_SER_ITEMS = dt.Rows[0]["DEDU_GIST_SER_ITEMS"].ToString();
            qcDeptManDict.DEDU_GIST_TITLES = dt.Rows[0]["DEDU_GIST_TITLES"].ToString();
            qcDeptManDict.DEPT_MAN_KEY = dt.Rows[0]["DEPT_MAN_KEY"].ToString();

            if (dt.Rows[0]["DIAG_REPORT"] == null)
                qcDeptManDict.DIAG_REPORT = null;
            else
                qcDeptManDict.DIAG_REPORT = Convert.ToInt32(dt.Rows[0]["DIAG_REPORT"].ToString());
            if (dt.Rows[0]["EMERGENCY_EXAM"] == null)
                qcDeptManDict.EMERGENCY_EXAM = null;
            else
                qcDeptManDict.EMERGENCY_EXAM = Convert.ToInt32(dt.Rows[0]["EMERGENCY_EXAM"].ToString());
            if (dt.Rows[0]["IMAGE_SYSTEM"] == null)
                qcDeptManDict.IMAGE_SYSTEM = null;
            else
                qcDeptManDict.IMAGE_SYSTEM = Convert.ToInt32(dt.Rows[0]["IMAGE_SYSTEM"].ToString());

            if (dt.Rows[0]["MANAGEMENT"] == null)
                qcDeptManDict.MANAGEMENT = null;
            else
                qcDeptManDict.MANAGEMENT = Convert.ToInt32(dt.Rows[0]["MANAGEMENT"].ToString());
            if (dt.Rows[0]["MANAGEMENT_SYSTEM"] == null)
                qcDeptManDict.MANAGEMENT_SYSTEM = null;
            else
                qcDeptManDict.MANAGEMENT_SYSTEM = Convert.ToInt32(dt.Rows[0]["MANAGEMENT_SYSTEM"].ToString());
            if (dt.Rows[0]["OVERSEE_RESULT"] == null)
                qcDeptManDict.OVERSEE_RESULT = null;
            else
                qcDeptManDict.OVERSEE_RESULT = Convert.ToInt32(dt.Rows[0]["OVERSEE_RESULT"].ToString());
            if (dt.Rows[0]["POST_TRAIN"] == null)
                qcDeptManDict.POST_TRAIN = null;
            else
                qcDeptManDict.POST_TRAIN = Convert.ToInt32(dt.Rows[0]["POST_TRAIN"].ToString());
            if (dt.Rows[0]["PREVENTIVE_MEASURE"] == null)
                qcDeptManDict.PREVENTIVE_MEASURE = null;
            else
                qcDeptManDict.PREVENTIVE_MEASURE = Convert.ToInt32(dt.Rows[0]["PREVENTIVE_MEASURE"].ToString());
            if (dt.Rows[0]["QC_DATE"] == null)
                qcDeptManDict.QC_DATE = null;
            else
                qcDeptManDict.QC_DATE = Convert.ToDateTime(dt.Rows[0]["QC_DATE"].ToString());
            if (dt.Rows[0]["REGISTER_STAT"] == null)
                qcDeptManDict.REGISTER_STAT = null;
            else
                qcDeptManDict.REGISTER_STAT = Convert.ToInt32(dt.Rows[0]["REGISTER_STAT"].ToString());
            if (dt.Rows[0]["RY_LICENCE"] == null)
                qcDeptManDict.RY_LICENCE = null;
            else
                qcDeptManDict.RY_LICENCE = Convert.ToInt32(dt.Rows[0]["RY_LICENCE"].ToString());

            if (dt.Rows[0]["SERVICES_ITEMS"] == null)
                qcDeptManDict.SERVICES_ITEMS = null;
            else
                qcDeptManDict.SERVICES_ITEMS = Convert.ToInt32(dt.Rows[0]["SERVICES_ITEMS"].ToString());
            if (dt.Rows[0]["TITLES"] == null)
                qcDeptManDict.TITLES = null;
            else
                qcDeptManDict.TITLES = Convert.ToInt32(dt.Rows[0]["TITLES"].ToString());  
            return qcDeptManDict;
        }

        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        public override int Update(IModel iQcCt, string where)
        {
            MQcDeptManDict qcDeptManDict = (MQcDeptManDict)iQcCt;
            Hashtable ht = new Hashtable();
            ht.Add("CRITERION_INTEGRALITY", qcDeptManDict.CRITERION_INTEGRALITY);
            ht.Add("DEDU_GIST_CRI_INT", qcDeptManDict.DEDU_GIST_CRI_INT);
            ht.Add("DEDU_GIST_DIAG_RPT", qcDeptManDict.DEDU_GIST_DIAG_RPT);
            ht.Add("DEDU_GIST_EME_EXAM", qcDeptManDict.DEDU_GIST_EME_EXAM);
            ht.Add("DEDU_GIST_IMAGE_SYS", qcDeptManDict.DEDU_GIST_IMAGE_SYS);
            ht.Add("DEDU_GIST_MAN_SYS", qcDeptManDict.DEDU_GIST_MAN_SYS);
            ht.Add("DEDU_GIST_MANAGEMENT", qcDeptManDict.DEDU_GIST_MANAGEMENT);
            ht.Add("DEDU_GIST_OS_RES", qcDeptManDict.DEDU_GIST_OS_RES);
            ht.Add("DEDU_GIST_POST_TRAIN", qcDeptManDict.DEDU_GIST_POST_TRAIN);
            ht.Add("DEDU_GIST_PRE_MEA", qcDeptManDict.DEDU_GIST_PRE_MEA);
            ht.Add("DEDU_GIST_REG_STAT", qcDeptManDict.DEDU_GIST_REG_STAT);
            ht.Add("DEDU_GIST_RY_LICENCE", qcDeptManDict.DEDU_GIST_RY_LICENCE);
            ht.Add("DEDU_GIST_SER_ITEMS", qcDeptManDict.DEDU_GIST_SER_ITEMS);
            ht.Add("DEDU_GIST_TITLES", qcDeptManDict.DEDU_GIST_TITLES);
            ht.Add("DEPT_MAN_KEY", qcDeptManDict.DEPT_MAN_KEY);
            ht.Add("DIAG_REPORT", qcDeptManDict.DIAG_REPORT);
            ht.Add("EMERGENCY_EXAM", qcDeptManDict.EMERGENCY_EXAM);
            ht.Add("IMAGE_SYSTEM", qcDeptManDict.IMAGE_SYSTEM);
            ht.Add("MANAGEMENT", qcDeptManDict.MANAGEMENT);
            ht.Add("MANAGEMENT_SYSTEM", qcDeptManDict.MANAGEMENT_SYSTEM);
            ht.Add("OVERSEE_RESULT", qcDeptManDict.OVERSEE_RESULT);
            ht.Add("POST_TRAIN", qcDeptManDict.POST_TRAIN);
            ht.Add("PREVENTIVE_MEASURE", qcDeptManDict.PREVENTIVE_MEASURE);
            ht.Add("QC_DATE", qcDeptManDict.QC_DATE);
            ht.Add("REGISTER_STAT", qcDeptManDict.REGISTER_STAT);
            ht.Add("RY_LICENCE", qcDeptManDict.RY_LICENCE);
            ht.Add("SERVICES_ITEMS", qcDeptManDict.SERVICES_ITEMS);
            ht.Add("TITLES", qcDeptManDict.TITLES);
            return ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString());
        }

        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }

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
                    dbCom.CommandText = "Delete " + TableName + " where EXAM_ACCESSION_NUM='" + item.Value.ToString() + "'";
                    dbCom.ExecuteNonQuery();
                }
                tran.Commit();
                return ht.Count;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                tran.Rollback();
                //MessageBox.Show("数据库事物处理错误！");
                return 0;
            }
            finally
            {
                this.Close();
            }
        }
    }
}
