using System;
using System.Collections.Generic;
using System.Text;
using ILL;
using PACS_Model;
using System.Collections;
using System.Data;
namespace PACS_DAL
{
    /// <summary>
    /// 操作STUDY，即检查记录表
    /// </summary>
    public class DStudy:IStudy
    {
        private string strSql;
        private string TableName = "STUDY";
        public DStudy()
            : base(GetConfig.GetPacsConnStr())
        {
        }

        /// <summary>
        /// 插入一条检查记录表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override int Add(IModel model)
        {
            
            MStudy  m = (MStudy)model;
            m.STUDY_KEY = int.Parse(new DGetSeqValue("PACS", "STUDY_KEY_SEQ").GetSeqValue());
            m.MODALITY = GetConfig.Modality;
            m.FACILITY = "";
            m.APPROVER="";//报告人USERIINFO
            Hashtable ht = new Hashtable();
            ht.Add("study_key",m.STUDY_KEY );
            ht.Add("patient_id", m.PATIENT_ID);
            ht.Add("patient_name", m.PATIENT_NAME);
            ht.Add("patient_sex", m.PATIENT_SEX);
            ht.Add("patient_birth", m.PATIENT_BIRTH);//日期

            ht.Add("patient_age", m.PATIENT_AGE);    //N
            ht.Add("patient_age_unit", m.PATIENT_AGE_UNIT);
            ht.Add("patient_source", m.PATIENT_SOURCE);
            ht.Add("birth_place", m.BIRTH_PLACE);
            ht.Add("identity", m.IDENTITY);

            //ht.Add("security", "");//N
            ht.Add("charge_type", m.CHARGE_TYPE);
            ht.Add("visit_id", m.VISIT_ID);//N
            ht.Add("inp_no", m.INP_NO);
            ht.Add("bed_num", m.BED_NUM);

            ht.Add("zip_code", m.ZIP_CODE);
            ht.Add("mailing_address",m.MAILING_ADDRESS);
            ht.Add("telephone_number", m.TELEPHONE_NUMBER);
            ht.Add("study_id", m.STUDY_ID);      //??
            //ht.Add("study_desc", dt.Rows[0]["PATIENT_ID"].ToString());//取自DICOM文件X

            ht.Add("study_instance_uid", m.STUDY_INSTANCE_UID);//CreateStudy_Instance_Uid方法
            ht.Add("study_date_time", m.STUDY_DATE_TIME);//日期
            // ht.Add("access_no", dt.Rows[0]["PATIENT_ID"].ToString());//?X
            // ht.Add("body_part", dt.Rows[0]["PATIENT_ID"].ToString());//?X
            ht.Add("series_count", "0");//?X

            ht.Add("instance_count", "0");//?X
            ht.Add("modality", m.MODALITY);//
            ht.Add("facility", m.FACILITY);
            ht.Add("refer_doctor", m.REFER_DOCTOR);
            ht.Add("refer_dept", m.REFER_DEPT);

            ht.Add("req_memo",m.REQ_MEMO);
            ht.Add("req_dept_name", m.REQ_DEPT_NAME);
            ht.Add("req_date_time", m.REQ_DATE_TIME);//日期
            ht.Add("scheduled_date", m.SCHEDULED_DATE);//日期
            ht.Add("sch_operator", m.SCH_OPERATOR);

            ht.Add("exam_no",m.EXAM_NO);
            ht.Add("exam_accession_num", m.EXAM_ACCESSION_NUM);
            ht.Add("exam_class",m.EXAM_CLASS);
            ht.Add("exam_sub_class", m.EXAM_SUB_CLASS);
            ht.Add("exam_item", m.EXAM_ITEM);

            ht.Add("exam_mode", m.EXAM_MODE);
            ht.Add("exam_group", m.EXAM_GROUP);
            ht.Add("exam_dept_name",m.EXAM_DEPT_NAME);
            ht.Add("exam_doctor", m.EXAM_DOCTOR);
            ht.Add("exam_index", m.EXAM_INDEX);//N

            ht.Add("is_online", "1");//N
            ht.Add("is_matched", "1");//N
            ht.Add("is_packprocess", "0");//N
            ht.Add("report_status", "1");//N
            //  ht.Add("verified","0");//N

            ht.Add("approver", m.APPROVER);//报告人USERIINFO
            ht.Add("clin_diag", m.CLIN_DIAG);
            ht.Add("clin_symp", m.CLIN_SYMP);
            ht.Add("relevant_lab_test",m.RELEVANT_LAB_TEST);
            ht.Add("relevant_diag", m.RELEVANT_DIAG);

            ht.Add("phys_sign", m.PHYS_SIGN);
            //  ht.Add("study_path",dt.Rows[0]["PATIENT_ID"].ToString());
            // ht.Add("volume_key",dt.Rows[0]["PATIENT_ID"].ToString());// 不理
            ht.Add("device",m.DEVICE);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 查询是否存在指定的检查记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override bool Exists(IModel model)
        {
            MStudy m = (MStudy)model;
            strSql = "select * from " + TableName + " where EXAM_ACCESSION_NUM= '" + m.EXAM_ACCESSION_NUM + "'";
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取指定检查申请号的检查记录
        /// </summary>
        /// <param name="EXAM_ACCESSION_NUM"></param>
        /// <returns></returns>
        public override IModel GetModel(string EXAM_ACCESSION_NUM)
        {
            strSql = "select * from " + TableName + " where EXAM_ACCESSION_NUM = '" + EXAM_ACCESSION_NUM + "'";
            DataTable dt = GetDataTable(strSql);
            MStudy model = new MStudy();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["STUDY_KEY"].ToString() != "")
                {
                    model.STUDY_KEY = int.Parse(dt.Rows[0]["STUDY_KEY"].ToString());
                }
                model.PATIENT_ID = dt.Rows[0]["PATIENT_ID"].ToString();
                model.PATIENT_NAME = dt.Rows[0]["PATIENT_NAME"].ToString();
                model.PATIENT_SEX = dt.Rows[0]["PATIENT_SEX"].ToString();
                if (dt.Rows[0]["PATIENT_BIRTH"].ToString() != "")
                {
                    model.PATIENT_BIRTH = DateTime.Parse(dt.Rows[0]["PATIENT_BIRTH"].ToString());
                }
                if (dt.Rows[0]["PATIENT_AGE"].ToString() != "")
                {
                    model.PATIENT_AGE = int.Parse(dt.Rows[0]["PATIENT_AGE"].ToString());
                }
                model.PATIENT_AGE_UNIT = dt.Rows[0]["PATIENT_AGE_UNIT"].ToString();
                model.PATIENT_SOURCE = dt.Rows[0]["PATIENT_SOURCE"].ToString();
                model.BIRTH_PLACE = dt.Rows[0]["BIRTH_PLACE"].ToString();
                model.IDENTITY = dt.Rows[0]["IDENTITY"].ToString();
                if (dt.Rows[0]["SECURITY"].ToString() != "")
                {
                    model.SECURITY = int.Parse(dt.Rows[0]["SECURITY"].ToString());
                }
                model.CHARGE_TYPE = dt.Rows[0]["CHARGE_TYPE"].ToString();
                if (dt.Rows[0]["VISIT_ID"].ToString() != "")
                {
                    model.VISIT_ID = int.Parse(dt.Rows[0]["VISIT_ID"].ToString());
                }
                model.INP_NO = dt.Rows[0]["INP_NO"].ToString();
                model.BED_NUM = dt.Rows[0]["BED_NUM"].ToString();
                model.ZIP_CODE = dt.Rows[0]["ZIP_CODE"].ToString();
                model.MAILING_ADDRESS = dt.Rows[0]["MAILING_ADDRESS"].ToString();
                model.TELEPHONE_NUMBER = dt.Rows[0]["TELEPHONE_NUMBER"].ToString();
                model.STUDY_ID = dt.Rows[0]["STUDY_ID"].ToString();
                model.STUDY_DESC = dt.Rows[0]["STUDY_DESC"].ToString();
                model.STUDY_INSTANCE_UID = dt.Rows[0]["STUDY_INSTANCE_UID"].ToString();
                if (dt.Rows[0]["STUDY_DATE_TIME"].ToString() != "")
                {
                    model.STUDY_DATE_TIME = DateTime.Parse(dt.Rows[0]["STUDY_DATE_TIME"].ToString());
                }
                model.ACCESS_NO = dt.Rows[0]["ACCESS_NO"].ToString();
                model.BODY_PART = dt.Rows[0]["BODY_PART"].ToString();
                if (dt.Rows[0]["SERIES_COUNT"].ToString() != "")
                {
                    model.SERIES_COUNT = int.Parse(dt.Rows[0]["SERIES_COUNT"].ToString());
                }
                if (dt.Rows[0]["INSTANCE_COUNT"].ToString() != "")
                {
                    model.INSTANCE_COUNT = int.Parse(dt.Rows[0]["INSTANCE_COUNT"].ToString());
                }
                model.MODALITY = dt.Rows[0]["MODALITY"].ToString();
                model.FACILITY = dt.Rows[0]["FACILITY"].ToString();
                model.REFER_DOCTOR = dt.Rows[0]["REFER_DOCTOR"].ToString();
                model.REFER_DEPT = dt.Rows[0]["REFER_DEPT"].ToString();
                model.REQ_MEMO = dt.Rows[0]["REQ_MEMO"].ToString();
                model.REQ_DEPT_NAME = dt.Rows[0]["REQ_DEPT_NAME"].ToString();
                if (dt.Rows[0]["REQ_DATE_TIME"].ToString() != "")
                {
                    model.REQ_DATE_TIME = DateTime.Parse(dt.Rows[0]["REQ_DATE_TIME"].ToString());
                }
                if (dt.Rows[0]["SCHEDULED_DATE"].ToString() != "")
                {
                    model.SCHEDULED_DATE = DateTime.Parse(dt.Rows[0]["SCHEDULED_DATE"].ToString());
                }
                model.SCH_OPERATOR = dt.Rows[0]["SCH_OPERATOR"].ToString();
                model.EXAM_NO = dt.Rows[0]["EXAM_NO"].ToString();
                model.EXAM_ACCESSION_NUM = dt.Rows[0]["EXAM_ACCESSION_NUM"].ToString();
                model.EXAM_CLASS = dt.Rows[0]["EXAM_CLASS"].ToString();
                model.EXAM_SUB_CLASS = dt.Rows[0]["EXAM_SUB_CLASS"].ToString();
                model.EXAM_ITEM = dt.Rows[0]["EXAM_ITEM"].ToString();
                model.EXAM_MODE = dt.Rows[0]["EXAM_MODE"].ToString();
                model.EXAM_GROUP = dt.Rows[0]["EXAM_GROUP"].ToString();
                model.EXAM_DEPT_NAME = dt.Rows[0]["EXAM_DEPT_NAME"].ToString();
                model.EXAM_DOCTOR = dt.Rows[0]["EXAM_DOCTOR"].ToString();
                if (dt.Rows[0]["EXAM_INDEX"].ToString() != "")
                {
                    model.EXAM_INDEX = int.Parse(dt.Rows[0]["EXAM_INDEX"].ToString());
                }
                if (dt.Rows[0]["IS_ONLINE"].ToString() != "")
                {
                    model.IS_ONLINE = int.Parse(dt.Rows[0]["IS_ONLINE"].ToString());
                }
                if (dt.Rows[0]["IS_MATCHED"].ToString() != "")
                {
                    model.IS_MATCHED = int.Parse(dt.Rows[0]["IS_MATCHED"].ToString());
                }
                if (dt.Rows[0]["IS_PACKPROCESS"].ToString() != "")
                {
                    model.IS_PACKPROCESS = int.Parse(dt.Rows[0]["IS_PACKPROCESS"].ToString());
                }
                if (dt.Rows[0]["REPORT_STATUS"].ToString() != "")
                {
                    model.REPORT_STATUS = int.Parse(dt.Rows[0]["REPORT_STATUS"].ToString());
                }
                if (dt.Rows[0]["VERIFIED"].ToString() != "")
                {
                    model.VERIFIED = int.Parse(dt.Rows[0]["VERIFIED"].ToString());
                }
                model.APPROVER = dt.Rows[0]["APPROVER"].ToString();
                model.CLIN_DIAG = dt.Rows[0]["CLIN_DIAG"].ToString();
                model.CLIN_SYMP = dt.Rows[0]["CLIN_SYMP"].ToString();
                model.RELEVANT_LAB_TEST = dt.Rows[0]["RELEVANT_LAB_TEST"].ToString();
                model.RELEVANT_DIAG = dt.Rows[0]["RELEVANT_DIAG"].ToString();
                model.PHYS_SIGN = dt.Rows[0]["PHYS_SIGN"].ToString();
                model.STUDY_PATH = dt.Rows[0]["STUDY_PATH"].ToString();
                model.VOLUME_KEY = dt.Rows[0]["VOLUME_KEY"].ToString();
                model.DEVICE = dt.Rows[0]["DEVICE"].ToString();
                return (IModel)model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取符合条件的检查记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 获取符合条件的检查记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList1(string where)
        {
            strSql = " select *  from paxdb.STUDY a , paxdb.REPORT b where a.EXAM_ACCESSION_NUM =b.EXAM_NO  and " + where;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 更新指定的检查记录
        /// </summary>
        /// <param name="iStudy"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel iStudy, string where)
        {
            MStudy m = (MStudy)iStudy;
            Hashtable ht = new Hashtable();
            ht.Add("study_key", m.STUDY_KEY);
            ht.Add("patient_id", m.PATIENT_ID);
            ht.Add("patient_name", m.PATIENT_NAME);
            ht.Add("patient_sex", m.PATIENT_SEX);
            ht.Add("patient_birth", m.PATIENT_BIRTH);//日期

            ht.Add("patient_age", m.PATIENT_AGE);    //N
            ht.Add("patient_age_unit", m.PATIENT_AGE_UNIT);
            ht.Add("patient_source", m.PATIENT_SOURCE);
            ht.Add("birth_place", m.BIRTH_PLACE);
            ht.Add("identity", m.IDENTITY);

            //ht.Add("security", "");//N
            ht.Add("charge_type", m.CHARGE_TYPE);
            ht.Add("visit_id", m.VISIT_ID);//N
            ht.Add("inp_no", m.INP_NO);
            ht.Add("bed_num", m.BED_NUM);

            ht.Add("zip_code", m.ZIP_CODE);
            ht.Add("mailing_address", m.MAILING_ADDRESS);
            ht.Add("telephone_number", m.TELEPHONE_NUMBER);
            ht.Add("study_id", m.STUDY_ID);      //??
            //ht.Add("study_desc", dt.Rows[0]["PATIENT_ID"].ToString());//取自DICOM文件X

            ht.Add("study_instance_uid", m.STUDY_INSTANCE_UID);//CreateStudy_Instance_Uid方法
            ht.Add("study_date_time", m.STUDY_DATE_TIME);//日期
            // ht.Add("access_no", dt.Rows[0]["PATIENT_ID"].ToString());//?X
            // ht.Add("body_part", dt.Rows[0]["PATIENT_ID"].ToString());//?X
            ht.Add("series_count", "0");//?X

            ht.Add("instance_count", "0");//?X
            ht.Add("modality", m.MODALITY);//
            ht.Add("facility", m.FACILITY);
            ht.Add("refer_doctor", m.REFER_DOCTOR);
            ht.Add("refer_dept", m.REFER_DEPT);

            ht.Add("req_memo", m.REQ_MEMO);
            ht.Add("req_dept_name", m.REQ_DEPT_NAME);
            ht.Add("req_date_time", m.REQ_DATE_TIME);//日期
            ht.Add("scheduled_date", m.SCHEDULED_DATE);//日期
            ht.Add("sch_operator", m.SCH_OPERATOR);

            ht.Add("exam_no", m.EXAM_NO);
            ht.Add("exam_accession_num", m.EXAM_ACCESSION_NUM);
            ht.Add("exam_class", m.EXAM_CLASS);
            ht.Add("exam_sub_class", m.EXAM_SUB_CLASS);
            ht.Add("exam_item", m.EXAM_ITEM);

            ht.Add("exam_mode", m.EXAM_MODE);
            ht.Add("exam_group", m.EXAM_GROUP);
            ht.Add("exam_dept_name", m.EXAM_DEPT_NAME);
            ht.Add("exam_doctor", m.EXAM_DOCTOR);
            ht.Add("exam_index", m.EXAM_INDEX);//N

            ht.Add("is_online", "1");//N
            ht.Add("is_matched", "1");//N
            ht.Add("is_packprocess", "0");//N
            ht.Add("report_status", "1");//N
            //  ht.Add("verified","0");//N

            ht.Add("approver", m.APPROVER);//报告人USERIINFO
            ht.Add("clin_diag", m.CLIN_DIAG);
            ht.Add("clin_symp", m.CLIN_SYMP);
            ht.Add("relevant_lab_test", m.RELEVANT_LAB_TEST);
            ht.Add("relevant_diag", m.RELEVANT_DIAG);

            ht.Add("phys_sign", m.PHYS_SIGN);
            //  ht.Add("study_path",dt.Rows[0]["PATIENT_ID"].ToString());
            // ht.Add("volume_key",dt.Rows[0]["PATIENT_ID"].ToString());// 不理
            ht.Add("device", m.DEVICE);
            return (ExecuteSql(StringConstructor.UpdateSql(TableName, ht, where).ToString()));
        }

        /// <summary>
        /// 删除符合条件的检查记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}