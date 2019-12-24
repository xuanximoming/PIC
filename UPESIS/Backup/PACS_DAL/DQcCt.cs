using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using ILL;
using PACS_Model;

namespace PACS_DAL
{
    public class DQcCt : IQcCt
    {
        private string strSql;
        private string TableName = "QC_CT";
        public DQcCt()
            : base(GetConfig.GetPacsConnStr())
        {
        }

        public override int Add(IModel iQcCt)
        {
            MQcCt qcCt = (MQcCt)iQcCt;
            Hashtable ht = new Hashtable();
            ht.Add("BASE_ASH_FOG_VALUE", qcCt.BASE_ASH_FOG_VALUE);
            ht.Add("BLANK_EXPOSAL_DENSITY", qcCt.BLANK_EXPOSAL_DENSITY);
            ht.Add("CTN", qcCt.CTN);
            ht.Add("DEVICE_SHADOW", qcCt.DEVICE_SHADOW);
            ht.Add("DISTINCTION", qcCt.DISTINCTION);
            ht.Add("EXAM_ACCESSION_NUM", qcCt.EXAM_ACCESSION_NUM);
            ht.Add("EXTERNA_BREATH_SHADOW", qcCt.EXTERNA_BREATH_SHADOW);
            ht.Add("FAST_CONSULT", qcCt.FAST_CONSULT);
            ht.Add("FILM_FORMAT", qcCt.FILM_FORMAT);
            ht.Add("FINGER_MARK", qcCt.FINGER_MARK);
            ht.Add("INF_CRITERION", qcCt.INF_CRITERION);
            ht.Add("LIGHT_LEAK", qcCt.LIGHT_LEAK);
            ht.Add("NICK", qcCt.NICK);
            ht.Add("NUMBER_KEY", qcCt.NUMBER_KEY);
            ht.Add("PATIENT_ID", qcCt.PATIENT_ID);
            ht.Add("PATIENT_LOCAL_ID", qcCt.PATIENT_LOCAL_ID);
            ht.Add("PATIENT_NAME", qcCt.PATIENT_NAME);
            ht.Add("PATIENT_SEX", qcCt.PATIENT_SEX);
            ht.Add("POSTURE_CHOICE", qcCt.POSTURE_CHOICE);
            ht.Add("QC_DATE", qcCt.QC_DATE);
            ht.Add("RESOLUTION", qcCt.RESOLUTION);
            ht.Add("SCANNING_MODE", qcCt.SCANNING_MODE);
            ht.Add("SCANNING_SCOPE", qcCt.SCANNING_SCOPE);
            ht.Add("STATIC_SHADOW", qcCt.STATIC_SHADOW);
            ht.Add("STRIP_SHADOW", qcCt.STRIP_SHADOW);
            ht.Add("STUDY_DATE_TIME", qcCt.STUDY_DATE_TIME);
            ht.Add("TOTAL_SCORE", qcCt.TOTAL_SCORE);
            ht.Add("VISCERA_SCANNING", qcCt.VISCERA_SCANNING);
            ht.Add("WATER_MARK", qcCt.WATER_MARK);
            ht.Add("WL_WWIDTH", qcCt.WL_WWIDTH);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        public override int AddMore(Hashtable ht2)//批量插入
        {
            MQcCt qcCt = new MQcCt();
            Hashtable ht = new Hashtable();
            Hashtable htstr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    qcCt = (MQcCt)ht2[i];
                    ht.Add("BASE_ASH_FOG_VALUE", qcCt.BASE_ASH_FOG_VALUE);
                    ht.Add("BLANK_EXPOSAL_DENSITY", qcCt.BLANK_EXPOSAL_DENSITY);
                    ht.Add("CTN", qcCt.CTN);
                    ht.Add("DEVICE_SHADOW", qcCt.DEVICE_SHADOW);
                    ht.Add("DISTINCTION", qcCt.DISTINCTION);
                    ht.Add("EXAM_ACCESSION_NUM", qcCt.EXAM_ACCESSION_NUM);
                    ht.Add("EXTERNA_BREATH_SHADOW", qcCt.EXTERNA_BREATH_SHADOW);
                    ht.Add("FAST_CONSULT", qcCt.FAST_CONSULT);
                    ht.Add("FILM_FORMAT", qcCt.FILM_FORMAT);
                    ht.Add("FINGER_MARK", qcCt.FINGER_MARK);
                    ht.Add("INF_CRITERION", qcCt.INF_CRITERION);
                    ht.Add("LIGHT_LEAK", qcCt.LIGHT_LEAK);
                    ht.Add("NICK", qcCt.NICK);
                    ht.Add("NUMBER_KEY", qcCt.NUMBER_KEY);
                    ht.Add("PATIENT_ID", qcCt.PATIENT_ID);
                    ht.Add("PATIENT_LOCAL_ID", qcCt.PATIENT_LOCAL_ID);
                    ht.Add("PATIENT_NAME", qcCt.PATIENT_NAME);
                    ht.Add("PATIENT_SEX", qcCt.PATIENT_SEX);
                    ht.Add("POSTURE_CHOICE", qcCt.POSTURE_CHOICE);
                    ht.Add("QC_DATE", qcCt.QC_DATE);
                    ht.Add("RESOLUTION", qcCt.RESOLUTION);
                    ht.Add("SCANNING_MODE", qcCt.SCANNING_MODE);
                    ht.Add("SCANNING_SCOPE", qcCt.SCANNING_SCOPE);
                    ht.Add("STATIC_SHADOW", qcCt.STATIC_SHADOW);
                    ht.Add("STRIP_SHADOW", qcCt.STRIP_SHADOW);
                    ht.Add("STUDY_DATE_TIME", qcCt.STUDY_DATE_TIME);
                    ht.Add("TOTAL_SCORE", qcCt.TOTAL_SCORE);
                    ht.Add("VISCERA_SCANNING", qcCt.VISCERA_SCANNING);
                    ht.Add("WATER_MARK", qcCt.WATER_MARK);
                    ht.Add("WL_WWIDTH", qcCt.WL_WWIDTH);
                    htstr.Add(i, StringConstructor.InsertSql(TableName, ht).ToString());
                }
                return ExecuteNonSql(htstr);

            }
            else
                return 0;
        }

        public override bool Exists(IModel iQcCt)
        {
            MQcCt qcCt = (MQcCt)iQcCt;
            strSql = "select * from " + TableName + " where EXAM_ACCESSION_NUM='" + qcCt.EXAM_ACCESSION_NUM + "'";
            return recordIsExist(strSql);
        }

        public override IModel GetModel(string EXAM_ACCESSION_NUM)
        {
            strSql = "select * from " + TableName + "  where EXAM_ACCESSION_NUM='" + EXAM_ACCESSION_NUM + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MQcCt qcCt = new MQcCt();
            if (dt.Rows[0]["BASE_ASH_FOG_VALUE"] == null)
                qcCt.BASE_ASH_FOG_VALUE = null;
            else
                qcCt.BASE_ASH_FOG_VALUE = Convert.ToInt32(dt.Rows[0]["BASE_ASH_FOG_VALUE"].ToString());
            if (dt.Rows[0]["BLANK_EXPOSAL_DENSITY"] == null)
                qcCt.BLANK_EXPOSAL_DENSITY = null;
            else
                qcCt.BLANK_EXPOSAL_DENSITY = Convert.ToInt32(dt.Rows[0]["BLANK_EXPOSAL_DENSITY"].ToString());
            if (dt.Rows[0]["CTN"] == null)
                qcCt.CTN = null;
            else
                qcCt.CTN = Convert.ToInt32(dt.Rows[0]["CTN"].ToString());
            if (dt.Rows[0]["DEVICE_SHADOW"] == null)
                qcCt.DEVICE_SHADOW = null;
            else
                qcCt.DEVICE_SHADOW = Convert.ToInt32(dt.Rows[0]["DEVICE_SHADOW"].ToString());
            if (dt.Rows[0]["DISTINCTION"] == null)
                qcCt.DISTINCTION = null;
            else
                qcCt.DISTINCTION = Convert.ToInt32(dt.Rows[0]["DISTINCTION"].ToString());

            qcCt.EXAM_ACCESSION_NUM = dt.Rows[0]["EXAM_ACCESSION_NUM"].ToString();

            if (dt.Rows[0]["EXTERNA_BREATH_SHADOW"] == null)
                qcCt.EXTERNA_BREATH_SHADOW = null;
            else
                qcCt.EXTERNA_BREATH_SHADOW = Convert.ToInt32(dt.Rows[0]["EXTERNA_BREATH_SHADOW"].ToString());
            if (dt.Rows[0]["FAST_CONSULT"] == null)
                qcCt.FAST_CONSULT = null;
            else
                qcCt.FAST_CONSULT = Convert.ToInt32(dt.Rows[0]["FAST_CONSULT"].ToString());
            if (dt.Rows[0]["FILM_FORMAT"] == null)
                qcCt.FILM_FORMAT = null;
            else
                qcCt.FILM_FORMAT = Convert.ToInt32(dt.Rows[0]["FILM_FORMAT"].ToString());
            if (dt.Rows[0]["FINGER_MARK"] == null)
                qcCt.FINGER_MARK = null;
            else
                qcCt.FINGER_MARK = Convert.ToInt32(dt.Rows[0]["FINGER_MARK"].ToString());
            if (dt.Rows[0]["INF_CRITERION"] == null)
                qcCt.INF_CRITERION = null;
            else
                qcCt.INF_CRITERION = Convert.ToInt32(dt.Rows[0]["INF_CRITERION"].ToString());
            if (dt.Rows[0]["LIGHT_LEAK"] == null)
                qcCt.LIGHT_LEAK = null;
            else
                qcCt.LIGHT_LEAK = Convert.ToInt32(dt.Rows[0]["LIGHT_LEAK"].ToString());
            if (dt.Rows[0]["NICK"] == null)
                qcCt.NICK = null;
            else
                qcCt.NICK = Convert.ToInt32(dt.Rows[0]["NICK"].ToString());
            if (dt.Rows[0]["NUMBER_KEY"] == null)
                qcCt.NUMBER_KEY = null;
            else
                qcCt.NUMBER_KEY = Convert.ToInt32(dt.Rows[0]["NUMBER_KEY"].ToString());

            qcCt.PATIENT_ID =dt.Rows[0]["PATIENT_ID"].ToString();
            qcCt.PATIENT_LOCAL_ID = dt.Rows[0]["PATIENT_LOCAL_ID"].ToString();
            qcCt.PATIENT_NAME = dt.Rows[0]["PATIENT_NAME"].ToString();
            qcCt.PATIENT_SEX = dt.Rows[0]["PATIENT_SEX"].ToString();

            if (dt.Rows[0]["POSTURE_CHOICE"] == null)
                qcCt.POSTURE_CHOICE = null;
            else
                qcCt.POSTURE_CHOICE = Convert.ToInt32(dt.Rows[0]["POSTURE_CHOICE"].ToString());
            if (dt.Rows[0]["QC_DATE"] == null)
                qcCt.QC_DATE = null;
            else
                qcCt.QC_DATE = Convert.ToDateTime(dt.Rows[0]["QC_DATE"].ToString());
            if (dt.Rows[0]["RESOLUTION"] == null)
                qcCt.RESOLUTION = null;
            else
                qcCt.RESOLUTION = Convert.ToInt32(dt.Rows[0]["RESOLUTION"].ToString());
            if (dt.Rows[0]["SCANNING_MODE"] == null)
                qcCt.SCANNING_MODE = null;
            else
                qcCt.SCANNING_MODE = Convert.ToInt32(dt.Rows[0]["SCANNING_MODE"].ToString());
            if (dt.Rows[0]["SCANNING_SCOPE"] == null)
                qcCt.SCANNING_SCOPE = null;
            else
                qcCt.SCANNING_SCOPE = Convert.ToInt32(dt.Rows[0]["SCANNING_SCOPE"].ToString());
            if (dt.Rows[0]["STATIC_SHADOW"] == null)
                qcCt.STATIC_SHADOW = null;
            else
                qcCt.STATIC_SHADOW = Convert.ToInt32(dt.Rows[0]["STATIC_SHADOW"].ToString());
            if (dt.Rows[0]["STRIP_SHADOW"] == null)
                qcCt.STRIP_SHADOW = null;
            else
                qcCt.STRIP_SHADOW = Convert.ToInt32(dt.Rows[0]["STRIP_SHADOW"].ToString());
            if (dt.Rows[0]["STUDY_DATE_TIME"] == null)
                qcCt.STUDY_DATE_TIME = null;
            else
                qcCt.STUDY_DATE_TIME = Convert.ToDateTime(dt.Rows[0]["STUDY_DATE_TIME"].ToString());
            if (dt.Rows[0]["TOTAL_SCORE"] == null)
                qcCt.TOTAL_SCORE = null;
            else
                qcCt.TOTAL_SCORE = Convert.ToInt32(dt.Rows[0]["TOTAL_SCORE"].ToString());
            if (dt.Rows[0]["VISCERA_SCANNING"] == null)
                qcCt.VISCERA_SCANNING = null;
            else
                qcCt.VISCERA_SCANNING = Convert.ToInt32(dt.Rows[0]["VISCERA_SCANNING"].ToString());
            if (dt.Rows[0]["WATER_MARK"] == null)
                qcCt.WATER_MARK = null;
            else
                qcCt.WATER_MARK = Convert.ToInt32(dt.Rows[0]["WATER_MARK"].ToString());
            if (dt.Rows[0]["WL_WWIDTH"] == null)
                qcCt.WL_WWIDTH = null;
            else
                qcCt.WL_WWIDTH = Convert.ToInt32(dt.Rows[0]["WL_WWIDTH"].ToString());
            return qcCt;
        }

        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        public override int Update(IModel iQcCt, string where)
        {
            MQcCt qcCt = (MQcCt)iQcCt;
            Hashtable ht = new Hashtable();
            ht.Add("BASE_ASH_FOG_VALUE", qcCt.BASE_ASH_FOG_VALUE);
            ht.Add("BLANK_EXPOSAL_DENSITY", qcCt.BLANK_EXPOSAL_DENSITY);
            ht.Add("CTN", qcCt.CTN);
            ht.Add("DEVICE_SHADOW", qcCt.DEVICE_SHADOW);
            ht.Add("DISTINCTION", qcCt.DISTINCTION);
            ht.Add("EXAM_ACCESSION_NUM", qcCt.EXAM_ACCESSION_NUM);
            ht.Add("EXTERNA_BREATH_SHADOW", qcCt.EXTERNA_BREATH_SHADOW);
            ht.Add("FAST_CONSULT", qcCt.FAST_CONSULT);
            ht.Add("FILM_FORMAT", qcCt.FILM_FORMAT);
            ht.Add("FINGER_MARK", qcCt.FINGER_MARK);
            ht.Add("INF_CRITERION", qcCt.INF_CRITERION);
            ht.Add("LIGHT_LEAK", qcCt.LIGHT_LEAK);
            ht.Add("NICK", qcCt.NICK);
            ht.Add("NUMBER_KEY", qcCt.NUMBER_KEY);
            ht.Add("PATIENT_ID", qcCt.PATIENT_ID);
            ht.Add("PATIENT_LOCAL_ID", qcCt.PATIENT_LOCAL_ID);
            ht.Add("PATIENT_NAME", qcCt.PATIENT_NAME);
            ht.Add("PATIENT_SEX", qcCt.PATIENT_SEX);
            ht.Add("POSTURE_CHOICE", qcCt.POSTURE_CHOICE);
            ht.Add("QC_DATE", qcCt.QC_DATE);
            ht.Add("RESOLUTION", qcCt.RESOLUTION);
            ht.Add("SCANNING_MODE", qcCt.SCANNING_MODE);
            ht.Add("SCANNING_SCOPE", qcCt.SCANNING_SCOPE);
            ht.Add("STATIC_SHADOW", qcCt.STATIC_SHADOW);
            ht.Add("STRIP_SHADOW", qcCt.STRIP_SHADOW);
            ht.Add("STUDY_DATE_TIME", qcCt.STUDY_DATE_TIME);
            ht.Add("TOTAL_SCORE", qcCt.TOTAL_SCORE);
            ht.Add("VISCERA_SCANNING", qcCt.VISCERA_SCANNING);
            ht.Add("WATER_MARK", qcCt.WATER_MARK);
            ht.Add("WL_WWIDTH", qcCt.WL_WWIDTH);
            return ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString());
        }

        public override int UpdateMore(Hashtable ht2)
        {
            MQcCt qcCt = new MQcCt();
            Hashtable ht = new Hashtable();
            Hashtable htStr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    qcCt = (MQcCt)ht2[i];
                    ht.Add("BASE_ASH_FOG_VALUE", qcCt.BASE_ASH_FOG_VALUE);
                    ht.Add("BLANK_EXPOSAL_DENSITY", qcCt.BLANK_EXPOSAL_DENSITY);
                    ht.Add("CTN", qcCt.CTN);
                    ht.Add("DEVICE_SHADOW", qcCt.DEVICE_SHADOW);
                    ht.Add("DISTINCTION", qcCt.DISTINCTION);
                    ht.Add("EXAM_ACCESSION_NUM", qcCt.EXAM_ACCESSION_NUM);
                    ht.Add("EXTERNA_BREATH_SHADOW", qcCt.EXTERNA_BREATH_SHADOW);
                    ht.Add("FAST_CONSULT", qcCt.FAST_CONSULT);
                    ht.Add("FILM_FORMAT", qcCt.FILM_FORMAT);
                    ht.Add("FINGER_MARK", qcCt.FINGER_MARK);
                    ht.Add("INF_CRITERION", qcCt.INF_CRITERION);
                    ht.Add("LIGHT_LEAK", qcCt.LIGHT_LEAK);
                    ht.Add("NICK", qcCt.NICK);
                    ht.Add("NUMBER_KEY", qcCt.NUMBER_KEY);
                    ht.Add("PATIENT_ID", qcCt.PATIENT_ID);
                    ht.Add("PATIENT_LOCAL_ID", qcCt.PATIENT_LOCAL_ID);
                    ht.Add("PATIENT_NAME", qcCt.PATIENT_NAME);
                    ht.Add("PATIENT_SEX", qcCt.PATIENT_SEX);
                    ht.Add("POSTURE_CHOICE", qcCt.POSTURE_CHOICE);
                    ht.Add("QC_DATE", qcCt.QC_DATE);
                    ht.Add("RESOLUTION", qcCt.RESOLUTION);
                    ht.Add("SCANNING_MODE", qcCt.SCANNING_MODE);
                    ht.Add("SCANNING_SCOPE", qcCt.SCANNING_SCOPE);
                    ht.Add("STATIC_SHADOW", qcCt.STATIC_SHADOW);
                    ht.Add("STRIP_SHADOW", qcCt.STRIP_SHADOW);
                    ht.Add("STUDY_DATE_TIME", qcCt.STUDY_DATE_TIME);
                    ht.Add("TOTAL_SCORE", qcCt.TOTAL_SCORE);
                    ht.Add("VISCERA_SCANNING", qcCt.VISCERA_SCANNING);
                    ht.Add("WATER_MARK", qcCt.WATER_MARK);
                    ht.Add("WL_WWIDTH", qcCt.WL_WWIDTH);
                    htStr.Add(i, StringConstructor.UpdateSql(TableName, ht, " where EXAM_ACCESSION_NUM='" + qcCt.EXAM_ACCESSION_NUM + "'"));
                }

                return ExecuteNonSql(htStr);
            }
            return 0;
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
