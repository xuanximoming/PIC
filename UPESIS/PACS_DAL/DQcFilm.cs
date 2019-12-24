using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using ILL;
using PACS_Model;

namespace PACS_DAL
{
    public class DQcFilm : IQcFilm
    {
        private string strSql;
        private string TableName = "QC_FILM";
        public DQcFilm()
            : base(GetConfig.GetPacsConnStr())
        {
        }

        public override int Add(IModel iQcFilm)
        {
            MQcFilm qcFilm = (MQcFilm)iQcFilm;
            Hashtable ht = new Hashtable();
            ht.Add("ADHIBIT", qcFilm.ADHIBIT);
            ht.Add("BASE_ASH_FOG_VALUE", qcFilm.BASE_ASH_FOG_VALUE);
            ht.Add("BLANK_EXPOSAL_DENSITY", qcFilm.BLANK_EXPOSAL_DENSITY);
            ht.Add("DIAGNOSE_AREA_VALUE", qcFilm.DIAGNOSE_AREA_VALUE);
            ht.Add("DIRT", qcFilm.DIRT);
            ht.Add("DISTINCTION", qcFilm.DISTINCTION);
            ht.Add("EXAM_ACCESSION_NUM", qcFilm.EXAM_ACCESSION_NUM);
            ht.Add("EXTERNA_SHADOW", qcFilm.EXTERNA_SHADOW);
            ht.Add("FINGER_MARK", qcFilm.FINGER_MARK);
            ht.Add("IVP_CONTRAST", qcFilm.IVP_CONTRAST);
            ht.Add("IVP_DEVELOP", qcFilm.IVP_DEVELOP);
            ht.Add("IVP_FILM_POSTURE_PLACE", qcFilm.IVP_FILM_POSTURE_PLACE);
            ht.Add("IVP_LETTER_ARRANGE", qcFilm.IVP_LETTER_ARRANGE);
            ht.Add("IVP_LETTER_NO", qcFilm.IVP_LETTER_NO);
            ht.Add("IVP_PHOTOGRAPHS_ENOUGH", qcFilm.IVP_PHOTOGRAPHS_ENOUGH);
            ht.Add("IVP_PROJECTION_CENTRAGE", qcFilm.IVP_PROJECTION_CENTRAGE);
            ht.Add("KNUCKLE_ARRANGEMENT_FOCUS", qcFilm.KNUCKLE_ARRANGEMENT_FOCUS);
            ht.Add("KNUCKLE_IMAGE_DISTORTION", qcFilm.KNUCKLE_IMAGE_DISTORTION);
            ht.Add("KNUCKLE_LETTER_ARRANGE", qcFilm.KNUCKLE_LETTER_ARRANGE);
            ht.Add("KNUCKLE_LONG_AXIS_PARALLEL", qcFilm.KNUCKLE_LONG_AXIS_PARALLEL);
            ht.Add("KNUCKLE_PROJECTION", qcFilm.KNUCKLE_PROJECTION);
            ht.Add("KNUCKLE_RESOLUTION", qcFilm.KNUCKLE_RESOLUTION);
            ht.Add("KNUCKLE_WRAP", qcFilm.KNUCKLE_WRAP);
            ht.Add("LIGHT_LEAK", qcFilm.LIGHT_LEAK);
            ht.Add("NICK", qcFilm.NICK);
            ht.Add("NUMBER_KEY", qcFilm.NUMBER_KEY);
            ht.Add("PATIENT_ID", qcFilm.PATIENT_ID);
            ht.Add("PATIENT_LOCAL_ID", qcFilm.PATIENT_LOCAL_ID);
            ht.Add("PATIENT_NAME", qcFilm.PATIENT_NAME);
            ht.Add("PATIENT_SEX", qcFilm.PATIENT_SEX);
            ht.Add("QC_DATE", qcFilm.QC_DATE);
            ht.Add("STATIC_SHADOW", qcFilm.STATIC_SHADOW);
            ht.Add("STERNUM_ARRANGEMENT_FOCUS", qcFilm.STERNUM_ARRANGEMENT_FOCUS);
            ht.Add("STERNUM_BLADEBONE", qcFilm.STERNUM_BLADEBONE);
            ht.Add("STERNUM_BOARD", qcFilm.STERNUM_BOARD);
            ht.Add("STERNUM_BREAST", qcFilm.STERNUM_BREAST);
            ht.Add("STERNUM_FIRST_FORTH_WHETTLE", qcFilm.STERNUM_FIRST_FORTH_WHETTLE);
            ht.Add("STERNUM_IMAGE_DISTORTION", qcFilm.STERNUM_IMAGE_DISTORTION);
            ht.Add("STERNUM_LETTER_ARRANGE", qcFilm.STERNUM_LETTER_ARRANGE);
            ht.Add("STERNUM_LETTER_NO", qcFilm.STERNUM_LETTER_NO);
            ht.Add("STUDY_DATE_TIME", qcFilm.STUDY_DATE_TIME);
            ht.Add("TOTAL_SCORE", qcFilm.TOTAL_SCORE);
            ht.Add("UGI_BLEB", qcFilm.UGI_BLEB);
            ht.Add("UGI_CAVITY_LINE", qcFilm.UGI_CAVITY_LINE);
            ht.Add("UGI_CONTRAST", qcFilm.UGI_CONTRAST);
            ht.Add("UGI_FLOCCULENCE", qcFilm.UGI_FLOCCULENCE);
            ht.Add("UGI_INDICATION_RANGE", qcFilm.UGI_INDICATION_RANGE);
            ht.Add("UGI_INF_CRITERION", qcFilm.UGI_INF_CRITERION);
            ht.Add("UGI_MUCOSAL_FOLD", qcFilm.UGI_MUCOSAL_FOLD);
            ht.Add("UGI_PATIENT_TYPE", qcFilm.UGI_PATIENT_TYPE);
            ht.Add("UGI_PHOTOGRAPHS_ENOUGH", qcFilm.UGI_PHOTOGRAPHS_ENOUGH);
            ht.Add("UGI_PROJECTION_CASE", qcFilm.UGI_PROJECTION_CASE);
            ht.Add("WATER_MARK", qcFilm.WATER_MARK);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        public override int AddMore(Hashtable ht2)//批量插入
        {
            MQcFilm qcFilm = new MQcFilm();
            Hashtable ht = new Hashtable();
            Hashtable htstr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    qcFilm = (MQcFilm)ht2[i];
                    ht.Add("ADHIBIT", qcFilm.ADHIBIT);
                    ht.Add("BASE_ASH_FOG_VALUE", qcFilm.BASE_ASH_FOG_VALUE);
                    ht.Add("BLANK_EXPOSAL_DENSITY", qcFilm.BLANK_EXPOSAL_DENSITY);
                    ht.Add("DIAGNOSE_AREA_VALUE", qcFilm.DIAGNOSE_AREA_VALUE);
                    ht.Add("DIRT", qcFilm.DIRT);
                    ht.Add("DISTINCTION", qcFilm.DISTINCTION);
                    ht.Add("EXAM_ACCESSION_NUM", qcFilm.EXAM_ACCESSION_NUM);
                    ht.Add("EXTERNA_SHADOW", qcFilm.EXTERNA_SHADOW);
                    ht.Add("FINGER_MARK", qcFilm.FINGER_MARK);
                    ht.Add("IVP_CONTRAST", qcFilm.IVP_CONTRAST);
                    ht.Add("IVP_DEVELOP", qcFilm.IVP_DEVELOP);
                    ht.Add("IVP_FILM_POSTURE_PLACE", qcFilm.IVP_FILM_POSTURE_PLACE);
                    ht.Add("IVP_LETTER_ARRANGE", qcFilm.IVP_LETTER_ARRANGE);
                    ht.Add("IVP_LETTER_NO", qcFilm.IVP_LETTER_NO);
                    ht.Add("IVP_PHOTOGRAPHS_ENOUGH", qcFilm.IVP_PHOTOGRAPHS_ENOUGH);
                    ht.Add("IVP_PROJECTION_CENTRAGE", qcFilm.IVP_PROJECTION_CENTRAGE);
                    ht.Add("KNUCKLE_ARRANGEMENT_FOCUS", qcFilm.KNUCKLE_ARRANGEMENT_FOCUS);
                    ht.Add("KNUCKLE_IMAGE_DISTORTION", qcFilm.KNUCKLE_IMAGE_DISTORTION);
                    ht.Add("KNUCKLE_LETTER_ARRANGE", qcFilm.KNUCKLE_LETTER_ARRANGE);
                    ht.Add("KNUCKLE_LONG_AXIS_PARALLEL", qcFilm.KNUCKLE_LONG_AXIS_PARALLEL);
                    ht.Add("KNUCKLE_PROJECTION", qcFilm.KNUCKLE_PROJECTION);
                    ht.Add("KNUCKLE_RESOLUTION", qcFilm.KNUCKLE_RESOLUTION);
                    ht.Add("KNUCKLE_WRAP", qcFilm.KNUCKLE_WRAP);
                    ht.Add("LIGHT_LEAK", qcFilm.LIGHT_LEAK);
                    ht.Add("NICK", qcFilm.NICK);
                    ht.Add("NUMBER_KEY", qcFilm.NUMBER_KEY);
                    ht.Add("PATIENT_ID", qcFilm.PATIENT_ID);
                    ht.Add("PATIENT_LOCAL_ID", qcFilm.PATIENT_LOCAL_ID);
                    ht.Add("PATIENT_NAME", qcFilm.PATIENT_NAME);
                    ht.Add("PATIENT_SEX", qcFilm.PATIENT_SEX);
                    ht.Add("QC_DATE", qcFilm.QC_DATE);
                    ht.Add("STATIC_SHADOW", qcFilm.STATIC_SHADOW);
                    ht.Add("STERNUM_ARRANGEMENT_FOCUS", qcFilm.STERNUM_ARRANGEMENT_FOCUS);
                    ht.Add("STERNUM_BLADEBONE", qcFilm.STERNUM_BLADEBONE);
                    ht.Add("STERNUM_BOARD", qcFilm.STERNUM_BOARD);
                    ht.Add("STERNUM_BREAST", qcFilm.STERNUM_BREAST);
                    ht.Add("STERNUM_FIRST_FORTH_WHETTLE", qcFilm.STERNUM_FIRST_FORTH_WHETTLE);
                    ht.Add("STERNUM_IMAGE_DISTORTION", qcFilm.STERNUM_IMAGE_DISTORTION);
                    ht.Add("STERNUM_LETTER_ARRANGE", qcFilm.STERNUM_LETTER_ARRANGE);
                    ht.Add("STERNUM_LETTER_NO", qcFilm.STERNUM_LETTER_NO);
                    ht.Add("STUDY_DATE_TIME", qcFilm.STUDY_DATE_TIME);
                    ht.Add("TOTAL_SCORE", qcFilm.TOTAL_SCORE);
                    ht.Add("UGI_BLEB", qcFilm.UGI_BLEB);
                    ht.Add("UGI_CAVITY_LINE", qcFilm.UGI_CAVITY_LINE);
                    ht.Add("UGI_CONTRAST", qcFilm.UGI_CONTRAST);
                    ht.Add("UGI_FLOCCULENCE", qcFilm.UGI_FLOCCULENCE);
                    ht.Add("UGI_INDICATION_RANGE", qcFilm.UGI_INDICATION_RANGE);
                    ht.Add("UGI_INF_CRITERION", qcFilm.UGI_INF_CRITERION);
                    ht.Add("UGI_MUCOSAL_FOLD", qcFilm.UGI_MUCOSAL_FOLD);
                    ht.Add("UGI_PATIENT_TYPE", qcFilm.UGI_PATIENT_TYPE);
                    ht.Add("UGI_PHOTOGRAPHS_ENOUGH", qcFilm.UGI_PHOTOGRAPHS_ENOUGH);
                    ht.Add("UGI_PROJECTION_CASE", qcFilm.UGI_PROJECTION_CASE);
                    ht.Add("WATER_MARK", qcFilm.WATER_MARK);
                    htstr.Add(i, StringConstructor.InsertSql(TableName, ht).ToString());
                }
                return ExecuteNonSql(htstr);

            }
            else
                return 0;
        }

        public override bool Exists(IModel iQcFilm)
        {
            MQcFilm qcFilm = (MQcFilm)iQcFilm;
            strSql = "select * from " + TableName + " where EXAM_ACCESSION_NUM='" + qcFilm.EXAM_ACCESSION_NUM + "'";
            return recordIsExist(strSql);
        }

        public override IModel GetModel(string EXAM_ACCESSION_NUM)
        {
            strSql = "select * from " + TableName + "  where EXAM_ACCESSION_NUM='" + EXAM_ACCESSION_NUM + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MQcFilm qcFilm = new MQcFilm();
            if (dt.Rows[0]["ADHIBIT"] == null)
                qcFilm.ADHIBIT = null;
            else
                qcFilm.ADHIBIT = Convert.ToInt32(dt.Rows[0]["ADHIBIT"].ToString());

            if (dt.Rows[0]["BASE_ASH_FOG_VALUE"] == null)
                qcFilm.BASE_ASH_FOG_VALUE = null;
            else
                qcFilm.BASE_ASH_FOG_VALUE = Convert.ToInt32(dt.Rows[0]["BASE_ASH_FOG_VALUE"].ToString());
            if (dt.Rows[0]["BLANK_EXPOSAL_DENSITY"] == null)
                qcFilm.BLANK_EXPOSAL_DENSITY = null;
            else
                qcFilm.BLANK_EXPOSAL_DENSITY = Convert.ToInt32(dt.Rows[0]["BLANK_EXPOSAL_DENSITY"].ToString());
            if (dt.Rows[0]["DIAGNOSE_AREA_VALUE"] == null)
                qcFilm.DIAGNOSE_AREA_VALUE = null;
            else
                qcFilm.DIAGNOSE_AREA_VALUE = Convert.ToInt32(dt.Rows[0]["DIAGNOSE_AREA_VALUE"].ToString());

            if (dt.Rows[0]["DIRT"] == null)
                qcFilm.DIRT = null;
            else
                qcFilm.DIRT = Convert.ToInt32(dt.Rows[0]["DIRT"].ToString());
            if (dt.Rows[0]["DISTINCTION"] == null)
                qcFilm.DISTINCTION = null;
            else
                qcFilm.DISTINCTION = Convert.ToInt32(dt.Rows[0]["DISTINCTION"].ToString());

            qcFilm.EXAM_ACCESSION_NUM = dt.Rows[0]["EXAM_ACCESSION_NUM"].ToString();

            if (dt.Rows[0]["EXTERNA_SHADOW"] == null)
                qcFilm.EXTERNA_SHADOW = null;
            else
                qcFilm.EXTERNA_SHADOW = Convert.ToInt32(dt.Rows[0]["EXTERNA_SHADOW"].ToString());
            if (dt.Rows[0]["FINGER_MARK"] == null)
                qcFilm.FINGER_MARK = null;
            else
                qcFilm.FINGER_MARK = Convert.ToInt32(dt.Rows[0]["FINGER_MARK"].ToString());
            if (dt.Rows[0]["IVP_CONTRAST"] == null)
                qcFilm.IVP_CONTRAST = null;
            else
                qcFilm.IVP_CONTRAST = Convert.ToInt32(dt.Rows[0]["IVP_CONTRAST"].ToString());
            if (dt.Rows[0]["IVP_DEVELOP"] == null)
                qcFilm.IVP_DEVELOP = null;
            else
                qcFilm.IVP_DEVELOP = Convert.ToInt32(dt.Rows[0]["IVP_DEVELOP"].ToString());
            if (dt.Rows[0]["IVP_FILM_POSTURE_PLACE"] == null)
                qcFilm.IVP_FILM_POSTURE_PLACE = null;
            else
                qcFilm.IVP_FILM_POSTURE_PLACE = Convert.ToInt32(dt.Rows[0]["IVP_FILM_POSTURE_PLACE"].ToString());
            if (dt.Rows[0]["IVP_LETTER_ARRANGE"] == null)
                qcFilm.IVP_LETTER_ARRANGE = null;
            else
                qcFilm.IVP_LETTER_ARRANGE = Convert.ToInt32(dt.Rows[0]["IVP_LETTER_ARRANGE"].ToString());
            if (dt.Rows[0]["IVP_LETTER_NO"] == null)
                qcFilm.IVP_LETTER_NO = null;
            else
                qcFilm.IVP_LETTER_NO = Convert.ToInt32(dt.Rows[0]["IVP_LETTER_NO"].ToString());
            if (dt.Rows[0]["IVP_PHOTOGRAPHS_ENOUGH"] == null)
                qcFilm.IVP_PHOTOGRAPHS_ENOUGH = null;
            else
                qcFilm.IVP_PHOTOGRAPHS_ENOUGH = Convert.ToInt32(dt.Rows[0]["IVP_PHOTOGRAPHS_ENOUGH"].ToString());
            if (dt.Rows[0]["IVP_PROJECTION_CENTRAGE"] == null)
                qcFilm.IVP_PROJECTION_CENTRAGE = null;
            else
                qcFilm.IVP_PROJECTION_CENTRAGE = Convert.ToInt32(dt.Rows[0]["IVP_PROJECTION_CENTRAGE"].ToString());
            if (dt.Rows[0]["KNUCKLE_ARRANGEMENT_FOCUS"] == null)
                qcFilm.KNUCKLE_ARRANGEMENT_FOCUS = null;
            else
                qcFilm.KNUCKLE_ARRANGEMENT_FOCUS = Convert.ToInt32(dt.Rows[0]["KNUCKLE_ARRANGEMENT_FOCUS"].ToString());
            if (dt.Rows[0]["KNUCKLE_IMAGE_DISTORTION"] == null)
                qcFilm.KNUCKLE_IMAGE_DISTORTION = null;
            else
                qcFilm.KNUCKLE_IMAGE_DISTORTION = Convert.ToInt32(dt.Rows[0]["KNUCKLE_IMAGE_DISTORTION"].ToString());
            if (dt.Rows[0]["KNUCKLE_LETTER_ARRANGE"] == null)
                qcFilm.KNUCKLE_LETTER_ARRANGE = null;
            else
                qcFilm.KNUCKLE_LETTER_ARRANGE = Convert.ToInt32(dt.Rows[0]["KNUCKLE_LETTER_ARRANGE"].ToString());
            if (dt.Rows[0]["KNUCKLE_LONG_AXIS_PARALLEL"] == null)
                qcFilm.KNUCKLE_LONG_AXIS_PARALLEL = null;
            else
                qcFilm.KNUCKLE_LONG_AXIS_PARALLEL = Convert.ToInt32(dt.Rows[0]["KNUCKLE_LONG_AXIS_PARALLEL"].ToString());
            if (dt.Rows[0]["KNUCKLE_PROJECTION"] == null)
                qcFilm.KNUCKLE_PROJECTION = null;
            else
                qcFilm.KNUCKLE_PROJECTION = Convert.ToInt32(dt.Rows[0]["KNUCKLE_PROJECTION"].ToString());
            if (dt.Rows[0]["KNUCKLE_RESOLUTION"] == null)
                qcFilm.KNUCKLE_RESOLUTION = null;
            else
                qcFilm.KNUCKLE_RESOLUTION = Convert.ToInt32(dt.Rows[0]["KNUCKLE_RESOLUTION"].ToString());
            if (dt.Rows[0]["KNUCKLE_WRAP"] == null)
                qcFilm.KNUCKLE_WRAP = null;
            else
                qcFilm.KNUCKLE_WRAP = Convert.ToInt32(dt.Rows[0]["KNUCKLE_WRAP"].ToString());
            if (dt.Rows[0]["LIGHT_LEAK"] == null)
                qcFilm.LIGHT_LEAK = null;
            else
                qcFilm.LIGHT_LEAK = Convert.ToInt32(dt.Rows[0]["LIGHT_LEAK"].ToString());
            if (dt.Rows[0]["NICK"] == null)
                qcFilm.NICK = null;
            else
                qcFilm.NICK = Convert.ToInt32(dt.Rows[0]["NICK"].ToString());
            if (dt.Rows[0]["NUMBER_KEY"] == null)
                qcFilm.NUMBER_KEY = null;
            else
                qcFilm.NUMBER_KEY = Convert.ToInt32(dt.Rows[0]["NUMBER_KEY"].ToString());

            qcFilm.PATIENT_ID = dt.Rows[0]["PATIENT_ID"].ToString();
            qcFilm.PATIENT_LOCAL_ID = dt.Rows[0]["PATIENT_LOCAL_ID"].ToString();
            qcFilm.PATIENT_NAME = dt.Rows[0]["PATIENT_NAME"].ToString();
            qcFilm.PATIENT_SEX = dt.Rows[0]["PATIENT_SEX"].ToString();

            if (dt.Rows[0]["QC_DATE"] == null)
                qcFilm.QC_DATE = null;
            else
                qcFilm.QC_DATE = Convert.ToDateTime(dt.Rows[0]["QC_DATE"].ToString());

            if (dt.Rows[0]["STATIC_SHADOW"] == null)
                qcFilm.STATIC_SHADOW = null;
            else
                qcFilm.STATIC_SHADOW = Convert.ToInt32(dt.Rows[0]["STATIC_SHADOW"].ToString());
            if (dt.Rows[0]["STERNUM_ARRANGEMENT_FOCUS"] == null)
                qcFilm.STERNUM_ARRANGEMENT_FOCUS = null;
            else
                qcFilm.STERNUM_ARRANGEMENT_FOCUS = Convert.ToInt32(dt.Rows[0]["STERNUM_ARRANGEMENT_FOCUS"].ToString());
            if (dt.Rows[0]["STERNUM_BLADEBONE"] == null)
                qcFilm.STERNUM_BLADEBONE = null;
            else
                qcFilm.STERNUM_BLADEBONE = Convert.ToInt32(dt.Rows[0]["STERNUM_BLADEBONE"].ToString());
            if (dt.Rows[0]["STERNUM_BOARD"] == null)
                qcFilm.STERNUM_BOARD = null;
            else
                qcFilm.STERNUM_BOARD = Convert.ToInt32(dt.Rows[0]["STERNUM_BOARD"].ToString());
            if (dt.Rows[0]["STERNUM_BREAST"] == null)
                qcFilm.STERNUM_BREAST = null;
            else
                qcFilm.STERNUM_BREAST = Convert.ToInt32(dt.Rows[0]["STERNUM_BREAST"].ToString());
            if (dt.Rows[0]["STERNUM_FIRST_FORTH_WHETTLE"] == null)
                qcFilm.STERNUM_FIRST_FORTH_WHETTLE = null;
            else
                qcFilm.STERNUM_FIRST_FORTH_WHETTLE = Convert.ToInt32(dt.Rows[0]["STERNUM_FIRST_FORTH_WHETTLE"].ToString());
            if (dt.Rows[0]["STERNUM_IMAGE_DISTORTION"] == null)
                qcFilm.STERNUM_IMAGE_DISTORTION = null;
            else
                qcFilm.STERNUM_IMAGE_DISTORTION = Convert.ToInt32(dt.Rows[0]["STERNUM_IMAGE_DISTORTION"].ToString());
            if (dt.Rows[0]["STERNUM_LETTER_ARRANGE"] == null)
                qcFilm.STERNUM_LETTER_ARRANGE = null;
            else
                qcFilm.STERNUM_LETTER_ARRANGE = Convert.ToInt32(dt.Rows[0]["STERNUM_LETTER_ARRANGE"].ToString());
            if (dt.Rows[0]["STERNUM_LETTER_NO"] == null)
                qcFilm.STERNUM_LETTER_NO = null;
            else
                qcFilm.STERNUM_LETTER_NO = Convert.ToInt32(dt.Rows[0]["STERNUM_LETTER_NO"].ToString());
            if (dt.Rows[0]["STUDY_DATE_TIME"] == null)
                qcFilm.STUDY_DATE_TIME = null;
            else
                qcFilm.STUDY_DATE_TIME = Convert.ToDateTime(dt.Rows[0]["STUDY_DATE_TIME"].ToString());
            if (dt.Rows[0]["TOTAL_SCORE"] == null)
                qcFilm.TOTAL_SCORE = null;
            else
                qcFilm.TOTAL_SCORE = Convert.ToInt32(dt.Rows[0]["TOTAL_SCORE"].ToString());
            if (dt.Rows[0]["UGI_BLEB"] == null)
                qcFilm.UGI_BLEB = null;
            else
                qcFilm.UGI_BLEB = Convert.ToInt32(dt.Rows[0]["UGI_BLEB"].ToString());
            if (dt.Rows[0]["UGI_CAVITY_LINE"] == null)
                qcFilm.UGI_CAVITY_LINE = null;
            else
                qcFilm.UGI_CAVITY_LINE = Convert.ToInt32(dt.Rows[0]["UGI_CAVITY_LINE"].ToString());
            if (dt.Rows[0]["UGI_CONTRAST"] == null)
                qcFilm.UGI_CONTRAST = null;
            else
                qcFilm.UGI_CONTRAST = Convert.ToInt32(dt.Rows[0]["UGI_CONTRAST"].ToString());
            if (dt.Rows[0]["UGI_FLOCCULENCE"] == null)
                qcFilm.UGI_FLOCCULENCE = null;
            else
                qcFilm.UGI_FLOCCULENCE = Convert.ToInt32(dt.Rows[0]["UGI_FLOCCULENCE"].ToString());
            if (dt.Rows[0]["UGI_INDICATION_RANGE"] == null)
                qcFilm.UGI_INDICATION_RANGE = null;
            else
                qcFilm.UGI_INDICATION_RANGE = Convert.ToInt32(dt.Rows[0]["UGI_INDICATION_RANGE"].ToString());
            if (dt.Rows[0]["UGI_MUCOSAL_FOLD"] == null)
                qcFilm.UGI_INF_CRITERION = null;
            else
                qcFilm.UGI_INF_CRITERION = Convert.ToInt32(dt.Rows[0]["UGI_INF_CRITERION"].ToString());
            if (dt.Rows[0]["UGI_MUCOSAL_FOLD"] == null)
                qcFilm.UGI_MUCOSAL_FOLD = null;
            else
                qcFilm.UGI_MUCOSAL_FOLD = Convert.ToInt32(dt.Rows[0]["UGI_MUCOSAL_FOLD"].ToString());
            if (dt.Rows[0]["UGI_PATIENT_TYPE"] == null)
                qcFilm.UGI_PATIENT_TYPE = null;
            else
                qcFilm.UGI_PATIENT_TYPE = Convert.ToInt32(dt.Rows[0]["UGI_PATIENT_TYPE"].ToString());
            if (dt.Rows[0]["UGI_PHOTOGRAPHS_ENOUGH"] == null)
                qcFilm.UGI_PATIENT_TYPE = null;
            else
                qcFilm.UGI_PHOTOGRAPHS_ENOUGH = Convert.ToInt32(dt.Rows[0]["UGI_PHOTOGRAPHS_ENOUGH"].ToString());
            if (dt.Rows[0]["UGI_PROJECTION_CASE"] == null)
                qcFilm.UGI_PROJECTION_CASE = null;
            else
                qcFilm.UGI_PROJECTION_CASE = Convert.ToInt32(dt.Rows[0]["UGI_PROJECTION_CASE"].ToString());
            if (dt.Rows[0]["WATER_MARK"] == null)
                qcFilm.WATER_MARK = null;
            else
                qcFilm.WATER_MARK = Convert.ToInt32(dt.Rows[0]["WATER_MARK"].ToString());
            return qcFilm;
        }

        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        public override int Update(IModel iQcFilm, string where)
        {
            MQcFilm qcFilm = (MQcFilm)iQcFilm;
            Hashtable ht = new Hashtable();
            ht.Add("ADHIBIT", qcFilm.ADHIBIT);
            ht.Add("BASE_ASH_FOG_VALUE", qcFilm.BASE_ASH_FOG_VALUE);
            ht.Add("BLANK_EXPOSAL_DENSITY", qcFilm.BLANK_EXPOSAL_DENSITY);
            ht.Add("DIAGNOSE_AREA_VALUE", qcFilm.DIAGNOSE_AREA_VALUE);
            ht.Add("DIRT", qcFilm.DIRT);
            ht.Add("DISTINCTION", qcFilm.DISTINCTION);
            ht.Add("EXAM_ACCESSION_NUM", qcFilm.EXAM_ACCESSION_NUM);
            ht.Add("EXTERNA_SHADOW", qcFilm.EXTERNA_SHADOW);
            ht.Add("FINGER_MARK", qcFilm.FINGER_MARK);
            ht.Add("IVP_CONTRAST", qcFilm.IVP_CONTRAST);
            ht.Add("IVP_DEVELOP", qcFilm.IVP_DEVELOP);
            ht.Add("IVP_FILM_POSTURE_PLACE", qcFilm.IVP_FILM_POSTURE_PLACE);
            ht.Add("IVP_LETTER_ARRANGE", qcFilm.IVP_LETTER_ARRANGE);
            ht.Add("IVP_LETTER_NO", qcFilm.IVP_LETTER_NO);
            ht.Add("IVP_PHOTOGRAPHS_ENOUGH", qcFilm.IVP_PHOTOGRAPHS_ENOUGH);
            ht.Add("IVP_PROJECTION_CENTRAGE", qcFilm.IVP_PROJECTION_CENTRAGE);
            ht.Add("KNUCKLE_ARRANGEMENT_FOCUS", qcFilm.KNUCKLE_ARRANGEMENT_FOCUS);
            ht.Add("KNUCKLE_IMAGE_DISTORTION", qcFilm.KNUCKLE_IMAGE_DISTORTION);
            ht.Add("KNUCKLE_LETTER_ARRANGE", qcFilm.KNUCKLE_LETTER_ARRANGE);
            ht.Add("KNUCKLE_LONG_AXIS_PARALLEL", qcFilm.KNUCKLE_LONG_AXIS_PARALLEL);
            ht.Add("KNUCKLE_PROJECTION", qcFilm.KNUCKLE_PROJECTION);
            ht.Add("KNUCKLE_RESOLUTION", qcFilm.KNUCKLE_RESOLUTION);
            ht.Add("KNUCKLE_WRAP", qcFilm.KNUCKLE_WRAP);
            ht.Add("LIGHT_LEAK", qcFilm.LIGHT_LEAK);
            ht.Add("NICK", qcFilm.NICK);
            ht.Add("NUMBER_KEY", qcFilm.NUMBER_KEY);
            ht.Add("PATIENT_ID", qcFilm.PATIENT_ID);
            ht.Add("PATIENT_LOCAL_ID", qcFilm.PATIENT_LOCAL_ID);
            ht.Add("PATIENT_NAME", qcFilm.PATIENT_NAME);
            ht.Add("PATIENT_SEX", qcFilm.PATIENT_SEX);
            ht.Add("QC_DATE", qcFilm.QC_DATE);
            ht.Add("STATIC_SHADOW", qcFilm.STATIC_SHADOW);
            ht.Add("STERNUM_ARRANGEMENT_FOCUS", qcFilm.STERNUM_ARRANGEMENT_FOCUS);
            ht.Add("STERNUM_BLADEBONE", qcFilm.STERNUM_BLADEBONE);
            ht.Add("STERNUM_BOARD", qcFilm.STERNUM_BOARD);
            ht.Add("STERNUM_BREAST", qcFilm.STERNUM_BREAST);
            ht.Add("STERNUM_FIRST_FORTH_WHETTLE", qcFilm.STERNUM_FIRST_FORTH_WHETTLE);
            ht.Add("STERNUM_IMAGE_DISTORTION", qcFilm.STERNUM_IMAGE_DISTORTION);
            ht.Add("STERNUM_LETTER_ARRANGE", qcFilm.STERNUM_LETTER_ARRANGE);
            ht.Add("STERNUM_LETTER_NO", qcFilm.STERNUM_LETTER_NO);
            ht.Add("STUDY_DATE_TIME", qcFilm.STUDY_DATE_TIME);
            ht.Add("TOTAL_SCORE", qcFilm.TOTAL_SCORE);
            ht.Add("UGI_BLEB", qcFilm.UGI_BLEB);
            ht.Add("UGI_CAVITY_LINE", qcFilm.UGI_CAVITY_LINE);
            ht.Add("UGI_CONTRAST", qcFilm.UGI_CONTRAST);
            ht.Add("UGI_FLOCCULENCE", qcFilm.UGI_FLOCCULENCE);
            ht.Add("UGI_INDICATION_RANGE", qcFilm.UGI_INDICATION_RANGE);
            ht.Add("UGI_INF_CRITERION", qcFilm.UGI_INF_CRITERION);
            ht.Add("UGI_MUCOSAL_FOLD", qcFilm.UGI_MUCOSAL_FOLD);
            ht.Add("UGI_PATIENT_TYPE", qcFilm.UGI_PATIENT_TYPE);
            ht.Add("UGI_PHOTOGRAPHS_ENOUGH", qcFilm.UGI_PHOTOGRAPHS_ENOUGH);
            ht.Add("UGI_PROJECTION_CASE", qcFilm.UGI_PROJECTION_CASE);
            ht.Add("WATER_MARK", qcFilm.WATER_MARK);
            return ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString());
        }

        public override int UpdateMore(Hashtable ht2)
        {
            MQcFilm qcFilm = new MQcFilm();
            Hashtable ht = new Hashtable();
            Hashtable htStr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    qcFilm = (MQcFilm)ht2[i];
                    ht.Add("ADHIBIT", qcFilm.ADHIBIT);
                    ht.Add("BASE_ASH_FOG_VALUE", qcFilm.BASE_ASH_FOG_VALUE);
                    ht.Add("BLANK_EXPOSAL_DENSITY", qcFilm.BLANK_EXPOSAL_DENSITY);
                    ht.Add("DIAGNOSE_AREA_VALUE", qcFilm.DIAGNOSE_AREA_VALUE);
                    ht.Add("DIRT", qcFilm.DIRT);
                    ht.Add("DISTINCTION", qcFilm.DISTINCTION);
                    ht.Add("EXAM_ACCESSION_NUM", qcFilm.EXAM_ACCESSION_NUM);
                    ht.Add("EXTERNA_SHADOW", qcFilm.EXTERNA_SHADOW);
                    ht.Add("FINGER_MARK", qcFilm.FINGER_MARK);
                    ht.Add("IVP_CONTRAST", qcFilm.IVP_CONTRAST);
                    ht.Add("IVP_DEVELOP", qcFilm.IVP_DEVELOP);
                    ht.Add("IVP_FILM_POSTURE_PLACE", qcFilm.IVP_FILM_POSTURE_PLACE);
                    ht.Add("IVP_LETTER_ARRANGE", qcFilm.IVP_LETTER_ARRANGE);
                    ht.Add("IVP_LETTER_NO", qcFilm.IVP_LETTER_NO);
                    ht.Add("IVP_PHOTOGRAPHS_ENOUGH", qcFilm.IVP_PHOTOGRAPHS_ENOUGH);
                    ht.Add("IVP_PROJECTION_CENTRAGE", qcFilm.IVP_PROJECTION_CENTRAGE);
                    ht.Add("KNUCKLE_ARRANGEMENT_FOCUS", qcFilm.KNUCKLE_ARRANGEMENT_FOCUS);
                    ht.Add("KNUCKLE_IMAGE_DISTORTION", qcFilm.KNUCKLE_IMAGE_DISTORTION);
                    ht.Add("KNUCKLE_LETTER_ARRANGE", qcFilm.KNUCKLE_LETTER_ARRANGE);
                    ht.Add("KNUCKLE_LONG_AXIS_PARALLEL", qcFilm.KNUCKLE_LONG_AXIS_PARALLEL);
                    ht.Add("KNUCKLE_PROJECTION", qcFilm.KNUCKLE_PROJECTION);
                    ht.Add("KNUCKLE_RESOLUTION", qcFilm.KNUCKLE_RESOLUTION);
                    ht.Add("KNUCKLE_WRAP", qcFilm.KNUCKLE_WRAP);
                    ht.Add("LIGHT_LEAK", qcFilm.LIGHT_LEAK);
                    ht.Add("NICK", qcFilm.NICK);
                    ht.Add("NUMBER_KEY", qcFilm.NUMBER_KEY);
                    ht.Add("PATIENT_ID", qcFilm.PATIENT_ID);
                    ht.Add("PATIENT_LOCAL_ID", qcFilm.PATIENT_LOCAL_ID);
                    ht.Add("PATIENT_NAME", qcFilm.PATIENT_NAME);
                    ht.Add("PATIENT_SEX", qcFilm.PATIENT_SEX);
                    ht.Add("QC_DATE", qcFilm.QC_DATE);
                    ht.Add("STATIC_SHADOW", qcFilm.STATIC_SHADOW);
                    ht.Add("STERNUM_ARRANGEMENT_FOCUS", qcFilm.STERNUM_ARRANGEMENT_FOCUS);
                    ht.Add("STERNUM_BLADEBONE", qcFilm.STERNUM_BLADEBONE);
                    ht.Add("STERNUM_BOARD", qcFilm.STERNUM_BOARD);
                    ht.Add("STERNUM_BREAST", qcFilm.STERNUM_BREAST);
                    ht.Add("STERNUM_FIRST_FORTH_WHETTLE", qcFilm.STERNUM_FIRST_FORTH_WHETTLE);
                    ht.Add("STERNUM_IMAGE_DISTORTION", qcFilm.STERNUM_IMAGE_DISTORTION);
                    ht.Add("STERNUM_LETTER_ARRANGE", qcFilm.STERNUM_LETTER_ARRANGE);
                    ht.Add("STERNUM_LETTER_NO", qcFilm.STERNUM_LETTER_NO);
                    ht.Add("STUDY_DATE_TIME", qcFilm.STUDY_DATE_TIME);
                    ht.Add("TOTAL_SCORE", qcFilm.TOTAL_SCORE);
                    ht.Add("UGI_BLEB", qcFilm.UGI_BLEB);
                    ht.Add("UGI_CAVITY_LINE", qcFilm.UGI_CAVITY_LINE);
                    ht.Add("UGI_CONTRAST", qcFilm.UGI_CONTRAST);
                    ht.Add("UGI_FLOCCULENCE", qcFilm.UGI_FLOCCULENCE);
                    ht.Add("UGI_INDICATION_RANGE", qcFilm.UGI_INDICATION_RANGE);
                    ht.Add("UGI_INF_CRITERION", qcFilm.UGI_INF_CRITERION);
                    ht.Add("UGI_MUCOSAL_FOLD", qcFilm.UGI_MUCOSAL_FOLD);
                    ht.Add("UGI_PATIENT_TYPE", qcFilm.UGI_PATIENT_TYPE);
                    ht.Add("UGI_PHOTOGRAPHS_ENOUGH", qcFilm.UGI_PHOTOGRAPHS_ENOUGH);
                    ht.Add("UGI_PROJECTION_CASE", qcFilm.UGI_PROJECTION_CASE);
                    ht.Add("WATER_MARK", qcFilm.WATER_MARK);
                    htStr.Add(i, StringConstructor.UpdateSql(TableName, ht, " where EXAM_ACCESSION_NUM='" + qcFilm.EXAM_ACCESSION_NUM + "'"));
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
