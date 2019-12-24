using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using ILL;
using PACS_Model;

namespace PACS_DAL
{
    public class DQcMri : IQcMri
    {
        private string strSql;
        private string TableName = "QC_MRI";
        public DQcMri()
            : base(GetConfig.GetPacsConnStr())
        {
        }

        public override int Add(IModel iQcMri)
        {
            MQcMri qcMri = (MQcMri)iQcMri;
            Hashtable ht = new Hashtable();
            ht.Add("BASE_ASH_FOG_VALUE", qcMri.BASE_ASH_FOG_VALUE);
            ht.Add("BRIM_BACKGROUND_DENSITY", qcMri.BRIM_BACKGROUND_DENSITY);
            ht.Add("DEVICE_SHADOW", qcMri.DEVICE_SHADOW);
            ht.Add("DISTINCTION", qcMri.DISTINCTION);
            ht.Add("EXAM_ACCESSION_NUM", qcMri.EXAM_ACCESSION_NUM);
            ht.Add("EXTERNA_METAL_SHADOW", qcMri.EXTERNA_METAL_SHADOW);
            ht.Add("FAST_CONSULT", qcMri.FAST_CONSULT);
            ht.Add("FILM_FORMAT", qcMri.FILM_FORMAT);
            ht.Add("HIST_CONTRAST", qcMri.HIST_CONTRAST);
            ht.Add("INF_CRITERION", qcMri.INF_CRITERION);
            ht.Add("NUMBER_KEY", qcMri.NUMBER_KEY);
            ht.Add("OPE_RESULT", qcMri.OPE_RESULT);
            ht.Add("PATIENT_ID", qcMri.PATIENT_ID);
            ht.Add("PATIENT_LOCAL_ID", qcMri.PATIENT_LOCAL_ID);
            ht.Add("PATIENT_NAME", qcMri.PATIENT_NAME);
            ht.Add("PATIENT_SEX", qcMri.PATIENT_SEX);
            ht.Add("POSTURE_CHOICE", qcMri.POSTURE_CHOICE);
            ht.Add("QC_DATE", qcMri.QC_DATE);
            ht.Add("RESOLUTION", qcMri.RESOLUTION);
            ht.Add("SCANNING_MODE", qcMri.SCANNING_MODE);
            ht.Add("SCANNING_SCOPE", qcMri.SCANNING_SCOPE);
            ht.Add("SERIES_LEVEL_NUMBER", qcMri.SERIES_LEVEL_NUMBER);
            ht.Add("STRUCTURE_RESOLUTION", qcMri.STRUCTURE_RESOLUTION);
            ht.Add("STUDY_DATE_TIME", qcMri.STUDY_DATE_TIME);
            ht.Add("TOTAL_SCORE", qcMri.TOTAL_SCORE);
            ht.Add("VISCERA_SCANNING", qcMri.VISCERA_SCANNING);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }


        public override int AddMore(Hashtable ht2)//批量插入
        {
            MQcMri qcMri = new MQcMri();
            Hashtable ht = new Hashtable();
            Hashtable htstr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    qcMri = (MQcMri)ht2[i];
                    ht.Add("BASE_ASH_FOG_VALUE", qcMri.BASE_ASH_FOG_VALUE);
                    ht.Add("BRIM_BACKGROUND_DENSITY", qcMri.BRIM_BACKGROUND_DENSITY);
                    ht.Add("DEVICE_SHADOW", qcMri.DEVICE_SHADOW);
                    ht.Add("DISTINCTION", qcMri.DISTINCTION);
                    ht.Add("EXAM_ACCESSION_NUM", qcMri.EXAM_ACCESSION_NUM);
                    ht.Add("EXTERNA_METAL_SHADOW", qcMri.EXTERNA_METAL_SHADOW);
                    ht.Add("FAST_CONSULT", qcMri.FAST_CONSULT);
                    ht.Add("FILM_FORMAT", qcMri.FILM_FORMAT);
                    ht.Add("HIST_CONTRAST", qcMri.HIST_CONTRAST);
                    ht.Add("INF_CRITERION", qcMri.INF_CRITERION);
                    ht.Add("NUMBER_KEY", qcMri.NUMBER_KEY);
                    ht.Add("OPE_RESULT", qcMri.OPE_RESULT);
                    ht.Add("PATIENT_ID", qcMri.PATIENT_ID);
                    ht.Add("PATIENT_LOCAL_ID", qcMri.PATIENT_LOCAL_ID);
                    ht.Add("PATIENT_NAME", qcMri.PATIENT_NAME);
                    ht.Add("PATIENT_SEX", qcMri.PATIENT_SEX);
                    ht.Add("POSTURE_CHOICE", qcMri.POSTURE_CHOICE);
                    ht.Add("QC_DATE", qcMri.QC_DATE);
                    ht.Add("RESOLUTION", qcMri.RESOLUTION);
                    ht.Add("SCANNING_MODE", qcMri.SCANNING_MODE);
                    ht.Add("SCANNING_SCOPE", qcMri.SCANNING_SCOPE);
                    ht.Add("SERIES_LEVEL_NUMBER", qcMri.SERIES_LEVEL_NUMBER);
                    ht.Add("STRUCTURE_RESOLUTION", qcMri.STRUCTURE_RESOLUTION);
                    ht.Add("STUDY_DATE_TIME", qcMri.STUDY_DATE_TIME);
                    ht.Add("TOTAL_SCORE", qcMri.TOTAL_SCORE);
                    ht.Add("VISCERA_SCANNING", qcMri.VISCERA_SCANNING);
                    htstr.Add(i, StringConstructor.InsertSql(TableName, ht).ToString());
                }
                return ExecuteNonSql(htstr);

            }
            else
                return 0;
        }

        public override bool Exists(IModel iQcMri)
        {
            MQcMri qcMri = (MQcMri)iQcMri;
            strSql = "select * from " + TableName + " where EXAM_ACCESSION_NUM='" + qcMri.EXAM_ACCESSION_NUM + "'";
            return recordIsExist(strSql);
        }

        public override IModel GetModel(string EXAM_ACCESSION_NUM)
        {
            strSql = "select * from " + TableName + "  where EXAM_ACCESSION_NUM='" + EXAM_ACCESSION_NUM + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MQcMri qcMri = new MQcMri();
            if (dt.Rows[0]["BASE_ASH_FOG_VALUE"] == null)
                qcMri.BASE_ASH_FOG_VALUE = null;
            else
                qcMri.BASE_ASH_FOG_VALUE = Convert.ToInt32(dt.Rows[0]["BASE_ASH_FOG_VALUE"].ToString());
            if (dt.Rows[0]["BRIM_BACKGROUND_DENSITY"] == null)
                qcMri.BRIM_BACKGROUND_DENSITY = null;
            else
                qcMri.BRIM_BACKGROUND_DENSITY = Convert.ToInt32(dt.Rows[0]["BRIM_BACKGROUND_DENSITY"].ToString());
            if (dt.Rows[0]["DEVICE_SHADOW"] == null)
                qcMri.DEVICE_SHADOW = null;
            else
                qcMri.DEVICE_SHADOW = Convert.ToInt32(dt.Rows[0]["DEVICE_SHADOW"].ToString());
            if (dt.Rows[0]["DISTINCTION"] == null)
                qcMri.DISTINCTION = null;
            else
                qcMri.DISTINCTION = Convert.ToInt32(dt.Rows[0]["DISTINCTION"].ToString());

            qcMri.EXAM_ACCESSION_NUM = dt.Rows[0]["EXAM_ACCESSION_NUM"].ToString();

            if (dt.Rows[0]["EXTERNA_METAL_SHADOW"] == null)
                qcMri.EXTERNA_METAL_SHADOW = null;
            else
                qcMri.EXTERNA_METAL_SHADOW = Convert.ToInt32(dt.Rows[0]["EXTERNA_METAL_SHADOW"].ToString());
            if (dt.Rows[0]["FAST_CONSULT"] == null)
                qcMri.FAST_CONSULT = null;
            else
                qcMri.FAST_CONSULT = Convert.ToInt32(dt.Rows[0]["FAST_CONSULT"].ToString());
            if (dt.Rows[0]["FILM_FORMAT"] == null)
                qcMri.FILM_FORMAT = null;
            else
                qcMri.FILM_FORMAT = Convert.ToInt32(dt.Rows[0]["FILM_FORMAT"].ToString());
            if (dt.Rows[0]["HIST_CONTRAST"] == null)
                qcMri.HIST_CONTRAST = null;
            else
                qcMri.HIST_CONTRAST = Convert.ToInt32(dt.Rows[0]["HIST_CONTRAST"].ToString());
            if (dt.Rows[0]["INF_CRITERION"] == null)
                qcMri.INF_CRITERION = null;
            else
                qcMri.INF_CRITERION = Convert.ToInt32(dt.Rows[0]["INF_CRITERION"].ToString());
            if (dt.Rows[0]["NUMBER_KEY"] == null)
                qcMri.NUMBER_KEY = null;
            else
                qcMri.NUMBER_KEY = Convert.ToInt32(dt.Rows[0]["NUMBER_KEY"].ToString());
            if (dt.Rows[0]["OPE_RESULT"] == null)
                qcMri.OPE_RESULT = null;
            else
                qcMri.OPE_RESULT = Convert.ToInt32(dt.Rows[0]["OPE_RESULT"].ToString());

            qcMri.PATIENT_ID =dt.Rows[0]["PATIENT_ID"].ToString();
            qcMri.PATIENT_LOCAL_ID = dt.Rows[0]["PATIENT_LOCAL_ID"].ToString();
            qcMri.PATIENT_NAME = dt.Rows[0]["PATIENT_NAME"].ToString();
            qcMri.PATIENT_SEX = dt.Rows[0]["PATIENT_SEX"].ToString();

            if (dt.Rows[0]["POSTURE_CHOICE"] == null)
                qcMri.POSTURE_CHOICE = null;
            else
                qcMri.POSTURE_CHOICE = Convert.ToInt32(dt.Rows[0]["POSTURE_CHOICE"].ToString());
            if (dt.Rows[0]["QC_DATE"] == null)
                qcMri.QC_DATE = null;
            else
                qcMri.QC_DATE = Convert.ToDateTime(dt.Rows[0]["QC_DATE"].ToString());
            if (dt.Rows[0]["RESOLUTION"] == null)
                qcMri.RESOLUTION = null;
            else
                qcMri.RESOLUTION = Convert.ToInt32(dt.Rows[0]["RESOLUTION"].ToString());
            if (dt.Rows[0]["SCANNING_MODE"] == null)
                qcMri.SCANNING_MODE = null;
            else
                qcMri.SCANNING_MODE = Convert.ToInt32(dt.Rows[0]["SCANNING_MODE"].ToString());
            if (dt.Rows[0]["SCANNING_SCOPE"] == null)
                qcMri.SCANNING_SCOPE = null;
            else
                qcMri.SCANNING_SCOPE = Convert.ToInt32(dt.Rows[0]["SCANNING_SCOPE"].ToString());
            if (dt.Rows[0]["SERIES_LEVEL_NUMBER"] == null)
                qcMri.SERIES_LEVEL_NUMBER = null;
            else
                qcMri.SERIES_LEVEL_NUMBER = Convert.ToInt32(dt.Rows[0]["SERIES_LEVEL_NUMBER"].ToString());
            if (dt.Rows[0]["STRUCTURE_RESOLUTION"] == null)
                qcMri.STRUCTURE_RESOLUTION = null;
            else
                qcMri.STRUCTURE_RESOLUTION = Convert.ToInt32(dt.Rows[0]["STRUCTURE_RESOLUTION"].ToString());
            if (dt.Rows[0]["STUDY_DATE_TIME"] == null)
                qcMri.STUDY_DATE_TIME = null;
            else
                qcMri.STUDY_DATE_TIME = Convert.ToDateTime(dt.Rows[0]["STUDY_DATE_TIME"].ToString());
            if (dt.Rows[0]["TOTAL_SCORE"] == null)
                qcMri.TOTAL_SCORE = null;
            else
                qcMri.TOTAL_SCORE = Convert.ToInt32(dt.Rows[0]["TOTAL_SCORE"].ToString());
            if (dt.Rows[0]["VISCERA_SCANNING"] == null)
                qcMri.VISCERA_SCANNING = null;
            else
                qcMri.VISCERA_SCANNING = Convert.ToInt32(dt.Rows[0]["VISCERA_SCANNING"].ToString());
           
            return qcMri;
        }

        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        public override int Update(IModel iQcMri, string where)
        {
            MQcMri qcMri = (MQcMri)iQcMri;
            Hashtable ht = new Hashtable();
            ht.Add("BASE_ASH_FOG_VALUE", qcMri.BASE_ASH_FOG_VALUE);
            ht.Add("BRIM_BACKGROUND_DENSITY", qcMri.BRIM_BACKGROUND_DENSITY);
            ht.Add("DEVICE_SHADOW", qcMri.DEVICE_SHADOW);
            ht.Add("DISTINCTION", qcMri.DISTINCTION);
            ht.Add("EXAM_ACCESSION_NUM", qcMri.EXAM_ACCESSION_NUM);
            ht.Add("EXTERNA_METAL_SHADOW", qcMri.EXTERNA_METAL_SHADOW);
            ht.Add("FAST_CONSULT", qcMri.FAST_CONSULT);
            ht.Add("FILM_FORMAT", qcMri.FILM_FORMAT);
            ht.Add("HIST_CONTRAST", qcMri.HIST_CONTRAST);
            ht.Add("INF_CRITERION", qcMri.INF_CRITERION);
            ht.Add("NUMBER_KEY", qcMri.NUMBER_KEY);
            ht.Add("OPE_RESULT", qcMri.OPE_RESULT);
            ht.Add("PATIENT_ID", qcMri.PATIENT_ID);
            ht.Add("PATIENT_LOCAL_ID", qcMri.PATIENT_LOCAL_ID);
            ht.Add("PATIENT_NAME", qcMri.PATIENT_NAME);
            ht.Add("PATIENT_SEX", qcMri.PATIENT_SEX);
            ht.Add("POSTURE_CHOICE", qcMri.POSTURE_CHOICE);
            ht.Add("QC_DATE", qcMri.QC_DATE);
            ht.Add("RESOLUTION", qcMri.RESOLUTION);
            ht.Add("SCANNING_MODE", qcMri.SCANNING_MODE);
            ht.Add("SCANNING_SCOPE", qcMri.SCANNING_SCOPE);
            ht.Add("SERIES_LEVEL_NUMBER", qcMri.SERIES_LEVEL_NUMBER);
            ht.Add("STRUCTURE_RESOLUTION", qcMri.STRUCTURE_RESOLUTION);
            ht.Add("STUDY_DATE_TIME", qcMri.STUDY_DATE_TIME);
            ht.Add("TOTAL_SCORE", qcMri.TOTAL_SCORE);
            ht.Add("VISCERA_SCANNING", qcMri.VISCERA_SCANNING);
            return ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString());
        }

        public override int UpdateMore(Hashtable ht2)
        {
            MQcMri qcMri = new MQcMri();
            Hashtable ht = new Hashtable();
            Hashtable htStr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    qcMri = (MQcMri)ht2[i];
                    ht.Add("BASE_ASH_FOG_VALUE", qcMri.BASE_ASH_FOG_VALUE);
                    ht.Add("BRIM_BACKGROUND_DENSITY", qcMri.BRIM_BACKGROUND_DENSITY);
                    ht.Add("DEVICE_SHADOW", qcMri.DEVICE_SHADOW);
                    ht.Add("DISTINCTION", qcMri.DISTINCTION);
                    ht.Add("EXAM_ACCESSION_NUM", qcMri.EXAM_ACCESSION_NUM);
                    ht.Add("EXTERNA_METAL_SHADOW", qcMri.EXTERNA_METAL_SHADOW);
                    ht.Add("FAST_CONSULT", qcMri.FAST_CONSULT);
                    ht.Add("FILM_FORMAT", qcMri.FILM_FORMAT);
                    ht.Add("HIST_CONTRAST", qcMri.HIST_CONTRAST);
                    ht.Add("INF_CRITERION", qcMri.INF_CRITERION);
                    ht.Add("NUMBER_KEY", qcMri.NUMBER_KEY);
                    ht.Add("OPE_RESULT", qcMri.OPE_RESULT);
                    ht.Add("PATIENT_ID", qcMri.PATIENT_ID);
                    ht.Add("PATIENT_LOCAL_ID", qcMri.PATIENT_LOCAL_ID);
                    ht.Add("PATIENT_NAME", qcMri.PATIENT_NAME);
                    ht.Add("PATIENT_SEX", qcMri.PATIENT_SEX);
                    ht.Add("POSTURE_CHOICE", qcMri.POSTURE_CHOICE);
                    ht.Add("QC_DATE", qcMri.QC_DATE);
                    ht.Add("RESOLUTION", qcMri.RESOLUTION);
                    ht.Add("SCANNING_MODE", qcMri.SCANNING_MODE);
                    ht.Add("SCANNING_SCOPE", qcMri.SCANNING_SCOPE);
                    ht.Add("SERIES_LEVEL_NUMBER", qcMri.SERIES_LEVEL_NUMBER);
                    ht.Add("STRUCTURE_RESOLUTION", qcMri.STRUCTURE_RESOLUTION);
                    ht.Add("STUDY_DATE_TIME", qcMri.STUDY_DATE_TIME);
                    ht.Add("TOTAL_SCORE", qcMri.TOTAL_SCORE);
                    ht.Add("VISCERA_SCANNING", qcMri.VISCERA_SCANNING);
                    htStr.Add(i, StringConstructor.UpdateSql(TableName, ht, " where EXAM_ACCESSION_NUM='" + qcMri.EXAM_ACCESSION_NUM + "'"));
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
