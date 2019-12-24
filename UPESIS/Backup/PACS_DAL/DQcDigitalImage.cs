using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using ILL;
using PACS_Model;

namespace PACS_DAL
{
    public class DQcDigitalImage : IQcDigitalImage
    {
        private string strSql;
        private string TableName = "QC_DIGITAL_IMAGE";
        public DQcDigitalImage()
            : base(GetConfig.GetPacsConnStr())
        {
        }

        public override int Add(IModel iQcDigitalImage)
        {
            MQcDigitalImage qcDigitalImage = (MQcDigitalImage)iQcDigitalImage;
            Hashtable ht = new Hashtable();
            ht.Add("DISTINCTION", qcDigitalImage.DISTINCTION);
            ht.Add("EXAM_ACCESSION_NUM", qcDigitalImage.EXAM_ACCESSION_NUM);
            ht.Add("EXPOSURE_DOSE", qcDigitalImage.EXPOSURE_DOSE);
            ht.Add("EXTERNA_SHADOW", qcDigitalImage.EXTERNA_SHADOW);
            ht.Add("FLAG_CONTENT", qcDigitalImage.FLAG_CONTENT);
            ht.Add("FLAG_PLACE_ARRANGE", qcDigitalImage.FLAG_PLACE_ARRANGE);
            ht.Add("IVP_DEVICE_SHADOW", qcDigitalImage.IVP_DEVICE_SHADOW);
            ht.Add("IVP_FILM_POSTURE_PLACE", qcDigitalImage.IVP_FILM_POSTURE_PLACE);
            ht.Add("IVP_HIST_CONTRAST", qcDigitalImage.IVP_HIST_CONTRAST);
            ht.Add("IVP_PHOTOGRAPHS_ENOUGH", qcDigitalImage.IVP_PHOTOGRAPHS_ENOUGH);
            ht.Add("IVP_PROJECTION_CENTRAGE", qcDigitalImage.IVP_PROJECTION_CENTRAGE);
            ht.Add("IVP_RESOLUTION", qcDigitalImage.IVP_RESOLUTION);
            ht.Add("KNUCKLE_ARRANGEMENT_FOCUS", qcDigitalImage.KNUCKLE_ARRANGEMENT_FOCUS);
            ht.Add("KNUCKLE_DEVICE_SHADOW", qcDigitalImage.KNUCKLE_DEVICE_SHADOW);
            ht.Add("KNUCKLE_IMAGE_DISTORTION", qcDigitalImage.KNUCKLE_IMAGE_DISTORTION);
            ht.Add("KNUCKLE_LONG_AXIS_PARALLEL", qcDigitalImage.KNUCKLE_LONG_AXIS_PARALLEL);
            ht.Add("KNUCKLE_PROJECTION", qcDigitalImage.KNUCKLE_PROJECTION);
            ht.Add("KNUCKLE_RESOLUTION", qcDigitalImage.KNUCKLE_RESOLUTION);
            ht.Add("KNUCKLE_WRAP", qcDigitalImage.KNUCKLE_WRAP);
            ht.Add("NUMBER_KEY", qcDigitalImage.NUMBER_KEY);
            ht.Add("PATIENT_ID", qcDigitalImage.PATIENT_ID);
            ht.Add("PATIENT_LOCAL_ID", qcDigitalImage.PATIENT_LOCAL_ID);
            ht.Add("PATIENT_NAME", qcDigitalImage.PATIENT_NAME);
            ht.Add("PATIENT_SEX", qcDigitalImage.PATIENT_SEX);
            ht.Add("QC_DATE", qcDigitalImage.QC_DATE);
            ht.Add("STERNUM_ARRANGEMENT_FOCUS", qcDigitalImage.STERNUM_ARRANGEMENT_FOCUS);
            ht.Add("STERNUM_BLADEBONE", qcDigitalImage.STERNUM_BLADEBONE);
            ht.Add("STERNUM_BOARD", qcDigitalImage.STERNUM_BOARD);
            ht.Add("STERNUM_BREAST", qcDigitalImage.STERNUM_BREAST);
            ht.Add("STERNUM_DEVICE_SHADOW", qcDigitalImage.STERNUM_DEVICE_SHADOW);
            ht.Add("STERNUM_IMAGE_DISTORTION", qcDigitalImage.STERNUM_IMAGE_DISTORTION);
            ht.Add("STERNUM_LUNG_MARKINGS", qcDigitalImage.STERNUM_LUNG_MARKINGS);
            ht.Add("STUDY_DATE_TIME", qcDigitalImage.STUDY_DATE_TIME);
            ht.Add("TOTAL_SCORE", qcDigitalImage.TOTAL_SCORE);
            ht.Add("UGI_BLEB", qcDigitalImage.UGI_BLEB);
            ht.Add("UGI_CAVITY_LINE", qcDigitalImage.UGI_CAVITY_LINE);
            ht.Add("UGI_CONTRAST", qcDigitalImage.UGI_CONTRAST);
            ht.Add("UGI_DEVICE_SHADOW", qcDigitalImage.UGI_DEVICE_SHADOW);
            ht.Add("UGI_FLOCCULENCE", qcDigitalImage.UGI_FLOCCULENCE);
            ht.Add("UGI_INDICATION_RANGE", qcDigitalImage.UGI_INDICATION_RANGE);
            ht.Add("UGI_MUCOSAL_FOLD", qcDigitalImage.UGI_MUCOSAL_FOLD);
            ht.Add("UGI_PATIENT_TYPE", qcDigitalImage.UGI_PATIENT_TYPE);
            ht.Add("UGI_PHOTOGRAPHS_ENOUGH", qcDigitalImage.UGI_PHOTOGRAPHS_ENOUGH);
            ht.Add("UGI_PROJECTION_CASE", qcDigitalImage.UGI_PROJECTION_CASE);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        public override int AddMore(Hashtable ht2)//批量插入
        {
            MQcDigitalImage qcDigitalImage = new MQcDigitalImage();
            Hashtable ht = new Hashtable();
            Hashtable htstr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    qcDigitalImage = (MQcDigitalImage)ht2[i];
                    ht.Add("DISTINCTION", qcDigitalImage.DISTINCTION);
                    ht.Add("EXAM_ACCESSION_NUM", qcDigitalImage.EXAM_ACCESSION_NUM);
                    ht.Add("EXPOSURE_DOSE", qcDigitalImage.EXPOSURE_DOSE);
                    ht.Add("EXTERNA_SHADOW", qcDigitalImage.EXTERNA_SHADOW);
                    ht.Add("FLAG_CONTENT", qcDigitalImage.FLAG_CONTENT);
                    ht.Add("FLAG_PLACE_ARRANGE", qcDigitalImage.FLAG_PLACE_ARRANGE);
                    ht.Add("IVP_DEVICE_SHADOW", qcDigitalImage.IVP_DEVICE_SHADOW);
                    ht.Add("IVP_FILM_POSTURE_PLACE", qcDigitalImage.IVP_FILM_POSTURE_PLACE);
                    ht.Add("IVP_HIST_CONTRAST", qcDigitalImage.IVP_HIST_CONTRAST);
                    ht.Add("IVP_PHOTOGRAPHS_ENOUGH", qcDigitalImage.IVP_PHOTOGRAPHS_ENOUGH);
                    ht.Add("IVP_PROJECTION_CENTRAGE", qcDigitalImage.IVP_PROJECTION_CENTRAGE);
                    ht.Add("IVP_RESOLUTION", qcDigitalImage.IVP_RESOLUTION);
                    ht.Add("KNUCKLE_ARRANGEMENT_FOCUS", qcDigitalImage.KNUCKLE_ARRANGEMENT_FOCUS);
                    ht.Add("KNUCKLE_DEVICE_SHADOW", qcDigitalImage.KNUCKLE_DEVICE_SHADOW);
                    ht.Add("KNUCKLE_IMAGE_DISTORTION", qcDigitalImage.KNUCKLE_IMAGE_DISTORTION);
                    ht.Add("KNUCKLE_LONG_AXIS_PARALLEL", qcDigitalImage.KNUCKLE_LONG_AXIS_PARALLEL);
                    ht.Add("KNUCKLE_PROJECTION", qcDigitalImage.KNUCKLE_PROJECTION);
                    ht.Add("KNUCKLE_RESOLUTION", qcDigitalImage.KNUCKLE_RESOLUTION);
                    ht.Add("KNUCKLE_WRAP", qcDigitalImage.KNUCKLE_WRAP);
                    ht.Add("NUMBER_KEY", qcDigitalImage.NUMBER_KEY);
                    ht.Add("PATIENT_ID", qcDigitalImage.PATIENT_ID);
                    ht.Add("PATIENT_LOCAL_ID", qcDigitalImage.PATIENT_LOCAL_ID);
                    ht.Add("PATIENT_NAME", qcDigitalImage.PATIENT_NAME);
                    ht.Add("PATIENT_SEX", qcDigitalImage.PATIENT_SEX);
                    ht.Add("QC_DATE", qcDigitalImage.QC_DATE);
                    ht.Add("STERNUM_ARRANGEMENT_FOCUS", qcDigitalImage.STERNUM_ARRANGEMENT_FOCUS);
                    ht.Add("STERNUM_BLADEBONE", qcDigitalImage.STERNUM_BLADEBONE);
                    ht.Add("STERNUM_BOARD", qcDigitalImage.STERNUM_BOARD);
                    ht.Add("STERNUM_BREAST", qcDigitalImage.STERNUM_BREAST);
                    ht.Add("STERNUM_DEVICE_SHADOW", qcDigitalImage.STERNUM_DEVICE_SHADOW);
                    ht.Add("STERNUM_IMAGE_DISTORTION", qcDigitalImage.STERNUM_IMAGE_DISTORTION);
                    ht.Add("STERNUM_LUNG_MARKINGS", qcDigitalImage.STERNUM_LUNG_MARKINGS);
                    ht.Add("STUDY_DATE_TIME", qcDigitalImage.STUDY_DATE_TIME);
                    ht.Add("TOTAL_SCORE", qcDigitalImage.TOTAL_SCORE);
                    ht.Add("UGI_BLEB", qcDigitalImage.UGI_BLEB);
                    ht.Add("UGI_CAVITY_LINE", qcDigitalImage.UGI_CAVITY_LINE);
                    ht.Add("UGI_CONTRAST", qcDigitalImage.UGI_CONTRAST);
                    ht.Add("UGI_DEVICE_SHADOW", qcDigitalImage.UGI_DEVICE_SHADOW);
                    ht.Add("UGI_FLOCCULENCE", qcDigitalImage.UGI_FLOCCULENCE);
                    ht.Add("UGI_INDICATION_RANGE", qcDigitalImage.UGI_INDICATION_RANGE);
                    ht.Add("UGI_MUCOSAL_FOLD", qcDigitalImage.UGI_MUCOSAL_FOLD);
                    ht.Add("UGI_PATIENT_TYPE", qcDigitalImage.UGI_PATIENT_TYPE);
                    ht.Add("UGI_PHOTOGRAPHS_ENOUGH", qcDigitalImage.UGI_PHOTOGRAPHS_ENOUGH);
                    ht.Add("UGI_PROJECTION_CASE", qcDigitalImage.UGI_PROJECTION_CASE);
                    htstr.Add(i, StringConstructor.InsertSql(TableName, ht).ToString());
                }
                return ExecuteNonSql(htstr);

            }
            else
                return 0;
        }

        public override bool Exists(IModel iQcDigitalImage)
        {
            MQcDigitalImage qcDigitalImage = (MQcDigitalImage)iQcDigitalImage;
            strSql = "select * from " + TableName + " where EXAM_ACCESSION_NUM='" + qcDigitalImage.EXAM_ACCESSION_NUM + "'";
            return recordIsExist(strSql);
        }

        public override IModel GetModel(string EXAM_ACCESSION_NUM)
        {
            strSql = "select * from " + TableName + "  where EXAM_ACCESSION_NUM='" + EXAM_ACCESSION_NUM + "'";
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MQcDigitalImage qcDigitalImage = new MQcDigitalImage();
            if (dt.Rows[0]["DISTINCTION"] == null)
                qcDigitalImage.DISTINCTION = null;
            else
                qcDigitalImage.DISTINCTION = Convert.ToInt32(dt.Rows[0]["DISTINCTION"].ToString());
            qcDigitalImage.EXAM_ACCESSION_NUM = dt.Rows[0]["EXAM_ACCESSION_NUM"].ToString();

            if (dt.Rows[0]["EXPOSURE_DOSE"] == null)
                qcDigitalImage.EXPOSURE_DOSE = null;
            else
                qcDigitalImage.EXPOSURE_DOSE = Convert.ToInt32(dt.Rows[0]["EXPOSURE_DOSE"].ToString());
            if (dt.Rows[0]["EXTERNA_SHADOW"] == null)
                qcDigitalImage.EXTERNA_SHADOW = null;
            else
                qcDigitalImage.EXTERNA_SHADOW = Convert.ToInt32(dt.Rows[0]["EXTERNA_SHADOW"].ToString());
            if (dt.Rows[0]["FLAG_CONTENT"] == null)
                qcDigitalImage.FLAG_CONTENT = null;
            else
                qcDigitalImage.FLAG_CONTENT = Convert.ToInt32(dt.Rows[0]["FLAG_CONTENT"].ToString());

            if (dt.Rows[0]["FLAG_PLACE_ARRANGE"] == null)
                qcDigitalImage.FLAG_PLACE_ARRANGE = null;
            else
                qcDigitalImage.FLAG_PLACE_ARRANGE = Convert.ToInt32(dt.Rows[0]["FLAG_PLACE_ARRANGE"].ToString());
            if (dt.Rows[0]["IVP_DEVICE_SHADOW"] == null)
                qcDigitalImage.IVP_DEVICE_SHADOW = null;
            else
                qcDigitalImage.IVP_DEVICE_SHADOW = Convert.ToInt32(dt.Rows[0]["IVP_DEVICE_SHADOW"].ToString());
            if (dt.Rows[0]["IVP_FILM_POSTURE_PLACE"] == null)
                qcDigitalImage.IVP_FILM_POSTURE_PLACE = null;
            else
                qcDigitalImage.IVP_FILM_POSTURE_PLACE = Convert.ToInt32(dt.Rows[0]["IVP_FILM_POSTURE_PLACE"].ToString());
            if (dt.Rows[0]["IVP_HIST_CONTRAST"] == null)
                qcDigitalImage.IVP_HIST_CONTRAST = null;
            else
                qcDigitalImage.IVP_HIST_CONTRAST = Convert.ToInt32(dt.Rows[0]["IVP_HIST_CONTRAST"].ToString());
            if (dt.Rows[0]["IVP_PHOTOGRAPHS_ENOUGH"] == null)
                qcDigitalImage.IVP_PHOTOGRAPHS_ENOUGH = null;
            else
                qcDigitalImage.IVP_PHOTOGRAPHS_ENOUGH = Convert.ToInt32(dt.Rows[0]["IVP_PHOTOGRAPHS_ENOUGH"].ToString());
            if (dt.Rows[0]["IVP_PROJECTION_CENTRAGE"] == null)
                qcDigitalImage.IVP_PROJECTION_CENTRAGE = null;
            else
                qcDigitalImage.IVP_PROJECTION_CENTRAGE = Convert.ToInt32(dt.Rows[0]["IVP_PROJECTION_CENTRAGE"].ToString());
            if (dt.Rows[0]["IVP_RESOLUTION"] == null)
                qcDigitalImage.IVP_RESOLUTION = null;
            else
                qcDigitalImage.IVP_RESOLUTION = Convert.ToInt32(dt.Rows[0]["IVP_RESOLUTION"].ToString());
            if (dt.Rows[0]["KNUCKLE_ARRANGEMENT_FOCUS"] == null)
                qcDigitalImage.KNUCKLE_ARRANGEMENT_FOCUS = null;
            else
                qcDigitalImage.KNUCKLE_ARRANGEMENT_FOCUS = Convert.ToInt32(dt.Rows[0]["KNUCKLE_ARRANGEMENT_FOCUS"].ToString());
            if (dt.Rows[0]["KNUCKLE_DEVICE_SHADOW"] == null)
                qcDigitalImage.KNUCKLE_DEVICE_SHADOW = null;
            else
                qcDigitalImage.KNUCKLE_DEVICE_SHADOW = Convert.ToInt32(dt.Rows[0]["KNUCKLE_DEVICE_SHADOW"].ToString());
            if (dt.Rows[0]["KNUCKLE_IMAGE_DISTORTION"] == null)
                qcDigitalImage.KNUCKLE_IMAGE_DISTORTION = null;
            else
                qcDigitalImage.KNUCKLE_IMAGE_DISTORTION = Convert.ToInt32(dt.Rows[0]["KNUCKLE_IMAGE_DISTORTION"].ToString());
            if (dt.Rows[0]["KNUCKLE_LONG_AXIS_PARALLEL"] == null)
                qcDigitalImage.KNUCKLE_LONG_AXIS_PARALLEL = null;
            else
                qcDigitalImage.KNUCKLE_LONG_AXIS_PARALLEL = Convert.ToInt32(dt.Rows[0]["KNUCKLE_LONG_AXIS_PARALLEL"].ToString());
            if (dt.Rows[0]["KNUCKLE_PROJECTION"] == null)
                qcDigitalImage.KNUCKLE_PROJECTION = null;
            else
                qcDigitalImage.KNUCKLE_PROJECTION = Convert.ToInt32(dt.Rows[0]["KNUCKLE_PROJECTION"].ToString());
            if (dt.Rows[0]["KNUCKLE_RESOLUTION"] == null)
                qcDigitalImage.KNUCKLE_RESOLUTION = null;
            else
                qcDigitalImage.KNUCKLE_RESOLUTION = Convert.ToInt32(dt.Rows[0]["KNUCKLE_RESOLUTION"].ToString());
            if (dt.Rows[0]["KNUCKLE_WRAP"] == null)
                qcDigitalImage.KNUCKLE_WRAP = null;
            else
                qcDigitalImage.KNUCKLE_WRAP = Convert.ToInt32(dt.Rows[0]["KNUCKLE_WRAP"].ToString());
            if (dt.Rows[0]["NUMBER_KEY"] == null)
                qcDigitalImage.NUMBER_KEY = null;
            else
                qcDigitalImage.NUMBER_KEY = Convert.ToInt32(dt.Rows[0]["NUMBER_KEY"].ToString());

            qcDigitalImage.PATIENT_ID = dt.Rows[0]["PATIENT_ID"].ToString();
            qcDigitalImage.PATIENT_LOCAL_ID = dt.Rows[0]["PATIENT_LOCAL_ID"].ToString();
            qcDigitalImage.PATIENT_NAME = dt.Rows[0]["PATIENT_NAME"].ToString();
            qcDigitalImage.PATIENT_SEX = dt.Rows[0]["PATIENT_SEX"].ToString();

            if (dt.Rows[0]["QC_DATE"] == null)
                qcDigitalImage.QC_DATE = null;
            else
                qcDigitalImage.QC_DATE = Convert.ToDateTime(dt.Rows[0]["QC_DATE"].ToString());

            if (dt.Rows[0]["STERNUM_ARRANGEMENT_FOCUS"] == null)
                qcDigitalImage.STERNUM_ARRANGEMENT_FOCUS = null;
            else
                qcDigitalImage.STERNUM_ARRANGEMENT_FOCUS = Convert.ToInt32(dt.Rows[0]["STERNUM_ARRANGEMENT_FOCUS"].ToString());
            if (dt.Rows[0]["STERNUM_BLADEBONE"] == null)
                qcDigitalImage.STERNUM_BLADEBONE = null;
            else
                qcDigitalImage.STERNUM_BLADEBONE = Convert.ToInt32(dt.Rows[0]["STERNUM_BLADEBONE"].ToString());
            if (dt.Rows[0]["STERNUM_BOARD"] == null)
                qcDigitalImage.STERNUM_BOARD = null;
            else
                qcDigitalImage.STERNUM_BOARD = Convert.ToInt32(dt.Rows[0]["STERNUM_BOARD"].ToString());
            if (dt.Rows[0]["STERNUM_BREAST"] == null)
                qcDigitalImage.STERNUM_BREAST = null;
            else
                qcDigitalImage.STERNUM_BREAST = Convert.ToInt32(dt.Rows[0]["STERNUM_BREAST"].ToString());
            if (dt.Rows[0]["STERNUM_DEVICE_SHADOW"] == null)
                qcDigitalImage.STERNUM_DEVICE_SHADOW = null;
            else
                qcDigitalImage.STERNUM_DEVICE_SHADOW = Convert.ToInt32(dt.Rows[0]["STERNUM_DEVICE_SHADOW"].ToString());
            if (dt.Rows[0]["STERNUM_IMAGE_DISTORTION"] == null)
                qcDigitalImage.STERNUM_IMAGE_DISTORTION = null;
            else
                qcDigitalImage.STERNUM_IMAGE_DISTORTION = Convert.ToInt32(dt.Rows[0]["STERNUM_IMAGE_DISTORTION"].ToString());
            if (dt.Rows[0]["STERNUM_LUNG_MARKINGS"] == null)
                qcDigitalImage.STERNUM_LUNG_MARKINGS = null;
            else
                qcDigitalImage.STERNUM_LUNG_MARKINGS = Convert.ToInt32(dt.Rows[0]["STERNUM_LUNG_MARKINGS"].ToString());
            if (dt.Rows[0]["STUDY_DATE_TIME"] == null)
                qcDigitalImage.STUDY_DATE_TIME = null;
            else
                qcDigitalImage.STUDY_DATE_TIME = Convert.ToDateTime(dt.Rows[0]["STUDY_DATE_TIME"].ToString());
            if (dt.Rows[0]["TOTAL_SCORE"] == null)
                qcDigitalImage.TOTAL_SCORE = null;
            else
                qcDigitalImage.TOTAL_SCORE = Convert.ToInt32(dt.Rows[0]["TOTAL_SCORE"].ToString());
            if (dt.Rows[0]["UGI_BLEB"] == null)
                qcDigitalImage.UGI_BLEB = null;
            else
                qcDigitalImage.UGI_BLEB = Convert.ToInt32(dt.Rows[0]["UGI_BLEB"].ToString());
            if (dt.Rows[0]["UGI_CAVITY_LINE"] == null)
                qcDigitalImage.UGI_CAVITY_LINE = null;
            else
                qcDigitalImage.UGI_CAVITY_LINE = Convert.ToInt32(dt.Rows[0]["UGI_CAVITY_LINE"].ToString());
            if (dt.Rows[0]["UGI_CONTRAST"] == null)
                qcDigitalImage.UGI_CONTRAST = null;
            else
                qcDigitalImage.UGI_CONTRAST = Convert.ToInt32(dt.Rows[0]["UGI_CONTRAST"].ToString());
            if (dt.Rows[0]["UGI_DEVICE_SHADOW"] == null)
                qcDigitalImage.UGI_DEVICE_SHADOW = null;
            else
                qcDigitalImage.UGI_DEVICE_SHADOW = Convert.ToInt32(dt.Rows[0]["UGI_DEVICE_SHADOW"].ToString());
            if (dt.Rows[0]["UGI_FLOCCULENCE"] == null)
                qcDigitalImage.UGI_FLOCCULENCE = null;
            else
                qcDigitalImage.UGI_FLOCCULENCE = Convert.ToInt32(dt.Rows[0]["UGI_FLOCCULENCE"].ToString());
            if (dt.Rows[0]["UGI_INDICATION_RANGE"] == null)
                qcDigitalImage.UGI_INDICATION_RANGE = null;
            else
                qcDigitalImage.UGI_INDICATION_RANGE = Convert.ToInt32(dt.Rows[0]["UGI_INDICATION_RANGE"].ToString());
            if (dt.Rows[0]["UGI_MUCOSAL_FOLD"] == null)
                qcDigitalImage.UGI_MUCOSAL_FOLD = null;
            else
                qcDigitalImage.UGI_MUCOSAL_FOLD = Convert.ToInt32(dt.Rows[0]["UGI_MUCOSAL_FOLD"].ToString());
            if (dt.Rows[0]["UGI_PATIENT_TYPE"] == null)
                qcDigitalImage.UGI_PATIENT_TYPE = null;
            else
                qcDigitalImage.UGI_PATIENT_TYPE = Convert.ToInt32(dt.Rows[0]["UGI_PATIENT_TYPE"].ToString());
            if (dt.Rows[0]["UGI_PHOTOGRAPHS_ENOUGH"] == null)
                qcDigitalImage.UGI_PHOTOGRAPHS_ENOUGH = null;
            else
                qcDigitalImage.UGI_PHOTOGRAPHS_ENOUGH = Convert.ToInt32(dt.Rows[0]["UGI_PHOTOGRAPHS_ENOUGH"].ToString());
            if (dt.Rows[0]["UGI_PROJECTION_CASE"] == null)
                qcDigitalImage.UGI_PROJECTION_CASE = null;
            else
                qcDigitalImage.UGI_PROJECTION_CASE = Convert.ToInt32(dt.Rows[0]["UGI_PROJECTION_CASE"].ToString());
            return qcDigitalImage;
        }

        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        public override int Update(IModel iQcDigitalImage, string where)
        {
            MQcDigitalImage qcDigitalImage = (MQcDigitalImage)iQcDigitalImage;
            Hashtable ht = new Hashtable();
            ht.Add("DISTINCTION", qcDigitalImage.DISTINCTION);
            ht.Add("EXAM_ACCESSION_NUM", qcDigitalImage.EXAM_ACCESSION_NUM);
            ht.Add("EXPOSURE_DOSE", qcDigitalImage.EXPOSURE_DOSE);
            ht.Add("EXTERNA_SHADOW", qcDigitalImage.EXTERNA_SHADOW);
            ht.Add("FLAG_CONTENT", qcDigitalImage.FLAG_CONTENT);
            ht.Add("FLAG_PLACE_ARRANGE", qcDigitalImage.FLAG_PLACE_ARRANGE);
            ht.Add("IVP_DEVICE_SHADOW", qcDigitalImage.IVP_DEVICE_SHADOW);
            ht.Add("IVP_FILM_POSTURE_PLACE", qcDigitalImage.IVP_FILM_POSTURE_PLACE);
            ht.Add("IVP_HIST_CONTRAST", qcDigitalImage.IVP_HIST_CONTRAST);
            ht.Add("IVP_PHOTOGRAPHS_ENOUGH", qcDigitalImage.IVP_PHOTOGRAPHS_ENOUGH);
            ht.Add("IVP_PROJECTION_CENTRAGE", qcDigitalImage.IVP_PROJECTION_CENTRAGE);
            ht.Add("IVP_RESOLUTION", qcDigitalImage.IVP_RESOLUTION);
            ht.Add("KNUCKLE_ARRANGEMENT_FOCUS", qcDigitalImage.KNUCKLE_ARRANGEMENT_FOCUS);
            ht.Add("KNUCKLE_DEVICE_SHADOW", qcDigitalImage.KNUCKLE_DEVICE_SHADOW);
            ht.Add("KNUCKLE_IMAGE_DISTORTION", qcDigitalImage.KNUCKLE_IMAGE_DISTORTION);
            ht.Add("KNUCKLE_LONG_AXIS_PARALLEL", qcDigitalImage.KNUCKLE_LONG_AXIS_PARALLEL);
            ht.Add("KNUCKLE_PROJECTION", qcDigitalImage.KNUCKLE_PROJECTION);
            ht.Add("KNUCKLE_RESOLUTION", qcDigitalImage.KNUCKLE_RESOLUTION);
            ht.Add("KNUCKLE_WRAP", qcDigitalImage.KNUCKLE_WRAP);
            ht.Add("NUMBER_KEY", qcDigitalImage.NUMBER_KEY);
            ht.Add("PATIENT_ID", qcDigitalImage.PATIENT_ID);
            ht.Add("PATIENT_LOCAL_ID", qcDigitalImage.PATIENT_LOCAL_ID);
            ht.Add("PATIENT_NAME", qcDigitalImage.PATIENT_NAME);
            ht.Add("PATIENT_SEX", qcDigitalImage.PATIENT_SEX);
            ht.Add("QC_DATE", qcDigitalImage.QC_DATE);
            ht.Add("STERNUM_ARRANGEMENT_FOCUS", qcDigitalImage.STERNUM_ARRANGEMENT_FOCUS);
            ht.Add("STERNUM_BLADEBONE", qcDigitalImage.STERNUM_BLADEBONE);
            ht.Add("STERNUM_BOARD", qcDigitalImage.STERNUM_BOARD);
            ht.Add("STERNUM_BREAST", qcDigitalImage.STERNUM_BREAST);
            ht.Add("STERNUM_DEVICE_SHADOW", qcDigitalImage.STERNUM_DEVICE_SHADOW);
            ht.Add("STERNUM_IMAGE_DISTORTION", qcDigitalImage.STERNUM_IMAGE_DISTORTION);
            ht.Add("STERNUM_LUNG_MARKINGS", qcDigitalImage.STERNUM_LUNG_MARKINGS);
            ht.Add("STUDY_DATE_TIME", qcDigitalImage.STUDY_DATE_TIME);
            ht.Add("TOTAL_SCORE", qcDigitalImage.TOTAL_SCORE);
            ht.Add("UGI_BLEB", qcDigitalImage.UGI_BLEB);
            ht.Add("UGI_CAVITY_LINE", qcDigitalImage.UGI_CAVITY_LINE);
            ht.Add("UGI_CONTRAST", qcDigitalImage.UGI_CONTRAST);
            ht.Add("UGI_DEVICE_SHADOW", qcDigitalImage.UGI_DEVICE_SHADOW);
            ht.Add("UGI_FLOCCULENCE", qcDigitalImage.UGI_FLOCCULENCE);
            ht.Add("UGI_INDICATION_RANGE", qcDigitalImage.UGI_INDICATION_RANGE);
            ht.Add("UGI_MUCOSAL_FOLD", qcDigitalImage.UGI_MUCOSAL_FOLD);
            ht.Add("UGI_PATIENT_TYPE", qcDigitalImage.UGI_PATIENT_TYPE);
            ht.Add("UGI_PHOTOGRAPHS_ENOUGH", qcDigitalImage.UGI_PHOTOGRAPHS_ENOUGH);
            ht.Add("UGI_PROJECTION_CASE", qcDigitalImage.UGI_PROJECTION_CASE);
            return ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString());
        }

        public override int UpdateMore(Hashtable ht2)
        {
            MQcDigitalImage qcDigitalImage = new MQcDigitalImage();
            Hashtable ht = new Hashtable();
            Hashtable htStr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    qcDigitalImage = (MQcDigitalImage)ht2[i];
                    ht.Add("DISTINCTION", qcDigitalImage.DISTINCTION);
                    ht.Add("EXAM_ACCESSION_NUM", qcDigitalImage.EXAM_ACCESSION_NUM);
                    ht.Add("EXPOSURE_DOSE", qcDigitalImage.EXPOSURE_DOSE);
                    ht.Add("EXTERNA_SHADOW", qcDigitalImage.EXTERNA_SHADOW);
                    ht.Add("FLAG_CONTENT", qcDigitalImage.FLAG_CONTENT);
                    ht.Add("FLAG_PLACE_ARRANGE", qcDigitalImage.FLAG_PLACE_ARRANGE);
                    ht.Add("IVP_DEVICE_SHADOW", qcDigitalImage.IVP_DEVICE_SHADOW);
                    ht.Add("IVP_FILM_POSTURE_PLACE", qcDigitalImage.IVP_FILM_POSTURE_PLACE);
                    ht.Add("IVP_HIST_CONTRAST", qcDigitalImage.IVP_HIST_CONTRAST);
                    ht.Add("IVP_PHOTOGRAPHS_ENOUGH", qcDigitalImage.IVP_PHOTOGRAPHS_ENOUGH);
                    ht.Add("IVP_PROJECTION_CENTRAGE", qcDigitalImage.IVP_PROJECTION_CENTRAGE);
                    ht.Add("IVP_RESOLUTION", qcDigitalImage.IVP_RESOLUTION);
                    ht.Add("KNUCKLE_ARRANGEMENT_FOCUS", qcDigitalImage.KNUCKLE_ARRANGEMENT_FOCUS);
                    ht.Add("KNUCKLE_DEVICE_SHADOW", qcDigitalImage.KNUCKLE_DEVICE_SHADOW);
                    ht.Add("KNUCKLE_IMAGE_DISTORTION", qcDigitalImage.KNUCKLE_IMAGE_DISTORTION);
                    ht.Add("KNUCKLE_LONG_AXIS_PARALLEL", qcDigitalImage.KNUCKLE_LONG_AXIS_PARALLEL);
                    ht.Add("KNUCKLE_PROJECTION", qcDigitalImage.KNUCKLE_PROJECTION);
                    ht.Add("KNUCKLE_RESOLUTION", qcDigitalImage.KNUCKLE_RESOLUTION);
                    ht.Add("KNUCKLE_WRAP", qcDigitalImage.KNUCKLE_WRAP);
                    ht.Add("NUMBER_KEY", qcDigitalImage.NUMBER_KEY);
                    ht.Add("PATIENT_ID", qcDigitalImage.PATIENT_ID);
                    ht.Add("PATIENT_LOCAL_ID", qcDigitalImage.PATIENT_LOCAL_ID);
                    ht.Add("PATIENT_NAME", qcDigitalImage.PATIENT_NAME);
                    ht.Add("PATIENT_SEX", qcDigitalImage.PATIENT_SEX);
                    ht.Add("QC_DATE", qcDigitalImage.QC_DATE);
                    ht.Add("STERNUM_ARRANGEMENT_FOCUS", qcDigitalImage.STERNUM_ARRANGEMENT_FOCUS);
                    ht.Add("STERNUM_BLADEBONE", qcDigitalImage.STERNUM_BLADEBONE);
                    ht.Add("STERNUM_BOARD", qcDigitalImage.STERNUM_BOARD);
                    ht.Add("STERNUM_BREAST", qcDigitalImage.STERNUM_BREAST);
                    ht.Add("STERNUM_DEVICE_SHADOW", qcDigitalImage.STERNUM_DEVICE_SHADOW);
                    ht.Add("STERNUM_IMAGE_DISTORTION", qcDigitalImage.STERNUM_IMAGE_DISTORTION);
                    ht.Add("STERNUM_LUNG_MARKINGS", qcDigitalImage.STERNUM_LUNG_MARKINGS);
                    ht.Add("STUDY_DATE_TIME", qcDigitalImage.STUDY_DATE_TIME);
                    ht.Add("TOTAL_SCORE", qcDigitalImage.TOTAL_SCORE);
                    ht.Add("UGI_BLEB", qcDigitalImage.UGI_BLEB);
                    ht.Add("UGI_CAVITY_LINE", qcDigitalImage.UGI_CAVITY_LINE);
                    ht.Add("UGI_CONTRAST", qcDigitalImage.UGI_CONTRAST);
                    ht.Add("UGI_DEVICE_SHADOW", qcDigitalImage.UGI_DEVICE_SHADOW);
                    ht.Add("UGI_FLOCCULENCE", qcDigitalImage.UGI_FLOCCULENCE);
                    ht.Add("UGI_INDICATION_RANGE", qcDigitalImage.UGI_INDICATION_RANGE);
                    ht.Add("UGI_MUCOSAL_FOLD", qcDigitalImage.UGI_MUCOSAL_FOLD);
                    ht.Add("UGI_PATIENT_TYPE", qcDigitalImage.UGI_PATIENT_TYPE);
                    ht.Add("UGI_PHOTOGRAPHS_ENOUGH", qcDigitalImage.UGI_PHOTOGRAPHS_ENOUGH);
                    ht.Add("UGI_PROJECTION_CASE", qcDigitalImage.UGI_PROJECTION_CASE);
                    htStr.Add(i, StringConstructor.UpdateSql(TableName, ht, " where EXAM_ACCESSION_NUM='" + qcDigitalImage.EXAM_ACCESSION_NUM + "'"));
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
