using System;
using System.Collections.Generic;
using System.Text;
using ILL;

namespace SIS.RegisterCls
{
    public class SetData
    {

        public void SetWorkListData(string Field,object Value,IModel iWorkList)
        {
            switch (GetConfig.DALAndModel)
            {
                case "PACS":
                    PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)iWorkList;
                    switch (Field)
                    {
                        case "ACCESSION_NO":
                            pmWorkList.ACCESSION_NO = Convert.ToInt32(Value);
                            break;
                        case "BED_NUM":
                            pmWorkList.BED_NUM = Value.ToString();
                            break;
                        case "BIRTH_PLACE":
                            pmWorkList.BIRTH_PLACE = Value.ToString();
                            break;
                        case "CHARGE_TYPE":
                            pmWorkList.CHARGE_TYPE = Convert.ToInt32(Value);
                            break;
                        case "CHARGES":
                            pmWorkList.CHARGES = Convert.ToDecimal(Value);
                            break;
                        case "CLIN_DIAG":
                            pmWorkList.CLIN_DIAG = Value.ToString();
                            break;
                        case "CLIN_SYMP":
                            pmWorkList.CLIN_SYMP = Value.ToString();
                            break;
                        case "COSTS":
                            pmWorkList.COSTS = Convert.ToDecimal(Value);
                            break;
                        case "DEVICE":
                            pmWorkList.DEVICE = Value.ToString();
                            break;
                        case "DISPATCH_STATUS":
                            pmWorkList.DISPATCH_STATUS = Convert.ToInt32(Value);
                            break;
                        case "EXAM_ACCESSION_NUM":
                            pmWorkList.EXAM_ACCESSION_NUM = Value.ToString();
                            break;
                        case "EXAM_CLASS":
                            pmWorkList.EXAM_CLASS = Value.ToString();
                            break;
                        case "EXAM_DEPT":
                            pmWorkList.EXAM_DEPT = Value.ToString();
                            break;
                        case "EXAM_DEPT_NAME":
                            pmWorkList.EXAM_DEPT_NAME = Value.ToString();
                            break;
                        case "EXAM_DOCTOR":
                            pmWorkList.EXAM_DOCTOR = Value.ToString();
                            break;
                        case "EXAM_GROUP":
                            pmWorkList.EXAM_GROUP = Value.ToString();
                            break;
                        case "EXAM_INDEX":
                            pmWorkList.EXAM_INDEX = Convert.ToInt32(Value);
                            break;
                        case "EXAM_INTRADAYSEQ_NO":
                            pmWorkList.EXAM_INTRADAYSEQ_NO = Convert.ToDecimal(Value);
                            break;
                        case "EXAM_ITEMS":
                            pmWorkList.EXAM_ITEMS = Value.ToString();
                            break;
                        case "EXAM_MODE":
                            pmWorkList.EXAM_MODE = Value.ToString();
                            break;
                        case "EXAM_NO":
                            pmWorkList.EXAM_NO = Value.ToString();
                            break;
                        case "EXAM_STEP_STATUS":
                            pmWorkList.EXAM_STEP_STATUS = Convert.ToInt32(Value);
                            break;
                        case "EXAM_SUB_CLASS":
                            pmWorkList.EXAM_SUB_CLASS = Value.ToString();
                            break;
                        case "FACILITY":
                            pmWorkList.FACILITY = Value.ToString();
                            break;
                        case "IMAGE_ARCHIVED":
                            pmWorkList.IMAGE_ARCHIVED = Convert.ToInt32(Value);
                            break;
                        case "IMAGE_COUNTS":
                            pmWorkList.IMAGE_COUNTS = Convert.ToInt32(Value);
                            break;
                        case "INP_NO":
                            pmWorkList.INP_NO = Value.ToString();
                            break;
                        case "IS_CONFIRMED":
                            pmWorkList.IS_CONFIRMED = Convert.ToInt32(Value);
                            break;
                        case "IS_TEMPORARY":
                            pmWorkList.IS_TEMPORARY = Convert.ToInt32(Value);
                            break;
                        case "LOCAL_ID_CLASS":
                            pmWorkList.LOCAL_ID_CLASS = Value.ToString();
                            break;
                        case "MAILING_ADDRESS":
                            pmWorkList.MAILING_ADDRESS = Value.ToString();
                            break;
                        case "MATCH_STATUS":
                            pmWorkList.MATCH_STATUS = Convert.ToInt32(Value);
                            break;
                        case "OPD_NO":
                            pmWorkList.OPD_NO = Value.ToString();
                            break;
                        case "OUT_MED_INSTITUTION":
                            pmWorkList.OUT_MED_INSTITUTION = Value.ToString();
                            break;
                        case "PATIENT_AGE":
                            pmWorkList.PATIENT_AGE = Convert.ToInt32(Value);
                            break;
                        case "PATIENT_AGE_UNIT":
                            pmWorkList.PATIENT_AGE_UNIT = Value.ToString();
                            break;
                        case "PATIENT_BIRTH":
                            pmWorkList.PATIENT_BIRTH = Convert.ToDateTime(Value);
                            break;
                        case "PATIENT_CLASS":
                            pmWorkList.PATIENT_CLASS = Convert.ToInt32(Value);
                            break;
                        case "PATIENT_ID":
                            pmWorkList.PATIENT_ID = Value.ToString();
                            break;
                        case "PATIENT_IDENTITY":
                            pmWorkList.PATIENT_IDENTITY = Value.ToString();
                            break;
                        case "PATIENT_LOCAL_ID":
                            pmWorkList.PATIENT_LOCAL_ID = Value.ToString();
                            break;
                        case "PATIENT_NAME":
                            pmWorkList.PATIENT_NAME = Value.ToString();
                            break;
                        case "PATIENT_PHONETIC":
                            pmWorkList.PATIENT_PHONETIC = Value.ToString();
                            break;
                        case "PATIENT_SEX":
                            pmWorkList.PATIENT_SEX = Value.ToString();
                            break;
                        case "PATIENT_SOURCE":
                            pmWorkList.PATIENT_SOURCE = Value.ToString();
                            break;
                        case "PHYS_SIGN":
                            pmWorkList.PHYS_SIGN = Value.ToString();
                            break;
                        case "PRE_FETCH":
                            pmWorkList.PRE_FETCH = Convert.ToInt32(Value);
                            break;
                        case "QUERY_STATUS":
                            pmWorkList.QUERY_STATUS = Convert.ToInt32(Value);
                            break;
                        case "QUERY_TIME":
                            pmWorkList.QUERY_TIME = Convert.ToDateTime(Value);
                            break;
                        case "REFER_DEPT":
                            pmWorkList.REFER_DEPT = Value.ToString();
                            break;
                        case "REFER_DOCTOR":
                            pmWorkList.REFER_DOCTOR = Value.ToString();
                            break;
                        case "RELEVANT_DIAG":
                            pmWorkList.RELEVANT_DIAG = Value.ToString();
                            break;
                        case "RELEVANT_LAB_TEST":
                            pmWorkList.RELEVANT_LAB_TEST = Value.ToString();
                            break;
                        case "REPORT_DOCTOR":
                            pmWorkList.REPORT_DOCTOR = Value.ToString();
                            break;
                        case "REPORT_STATUS":
                            pmWorkList.REPORT_STATUS = Convert.ToInt32(Value);
                            break;
                        case "REQ_DATE_TIME":
                            pmWorkList.REQ_DATE_TIME = Convert.ToDateTime(Value);
                            break;
                        case "REQ_DEPT_NAME":
                            pmWorkList.REQ_DEPT_NAME = Value.ToString();
                            break;
                        case "REQ_MEMO":
                            pmWorkList.REQ_MEMO = Value.ToString();
                            break;
                        case "SCH_OPERATOR":
                            pmWorkList.SCH_OPERATOR = Value.ToString();
                            break;
                        case "SCHEDULED_DATE":
                            // modify by liukun at 2010-6-30 begin 
                            //修改记录：传入的预约时间为空时，保存到后台数据库的数据也为空，
                            //如果不按如下的方法处理，则Convert.ToDateTime(null)的返回值为：0001-1-1,而不是为空
                            Nullable<DateTime> nulldate = null;
                            pmWorkList.SCHEDULED_DATE = (Value == null ? nulldate : Convert.ToDateTime(Value));
                            // modify by liukun at 2010-6-30 end  
                            break;
                        case "STUDY_DATE_TIME":
                            pmWorkList.STUDY_DATE_TIME = Convert.ToDateTime(Value);
                            break;
                        case "STUDY_INSTANCE_UID":
                            pmWorkList.STUDY_INSTANCE_UID = Value.ToString();
                            break;
                        case "STUDY_PATH":
                            pmWorkList.STUDY_PATH = Value.ToString();
                            break;
                        case "TELEPHONE_NUM":
                            pmWorkList.TELEPHONE_NUM = Value.ToString();
                            break;
                        case "VIP_INDICATOR":
                            pmWorkList.VIP_INDICATOR = Convert.ToInt32(Value);
                            break;
                        case "VISIT_ID":
                            pmWorkList.VISIT_ID = Convert.ToInt32(Value);
                            break;
                        case "ZIP_CODE":
                            pmWorkList.ZIP_CODE = Value.ToString();
                            break;
                    }
                    break;
                case "SIS":
                    SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)iWorkList;
                    switch (Field)
                    {
                        case "ACCESSION_NO":
                            smWorkList.ACCESSION_NO = Convert.ToInt32(Value);
                            break;
                        case "BED_NUM":
                            smWorkList.BED_NUM = Value.ToString();
                            break;
                        case "BIRTH_PLACE":
                            smWorkList.BIRTH_PLACE = Value.ToString();
                            break;
                        case "CHARGE_TYPE":
                            smWorkList.CHARGE_TYPE = Convert.ToInt32(Value);
                            break;
                        case "CHARGES":
                            smWorkList.CHARGES = Convert.ToDecimal(Value);
                            break;
                        case "CLIN_DIAG":
                            smWorkList.CLIN_DIAG = Value.ToString();
                            break;
                        case "CLIN_SYMP":
                            smWorkList.CLIN_SYMP = Value.ToString();
                            break;
                        case "COSTS":
                            smWorkList.COSTS = Convert.ToDecimal(Value);
                            break;
                        case "DEVICE":
                            smWorkList.DEVICE = Value.ToString();
                            break;
                        case "DISPATCH_STATUS":
                            smWorkList.DISPATCH_STATUS = Convert.ToInt32(Value);
                            break;
                        case "EXAM_ACCESSION_NUM":
                            smWorkList.EXAM_ACCESSION_NUM = Value.ToString();
                            break;
                        case "EXAM_CLASS":
                            smWorkList.EXAM_CLASS = Value.ToString();
                            break;
                        case "EXAM_DEPT":
                            smWorkList.EXAM_DEPT = Value.ToString();
                            break;
                        case "EXAM_DEPT_NAME":
                            smWorkList.EXAM_DEPT_NAME = Value.ToString();
                            break;
                        case "EXAM_DOCTOR":
                            smWorkList.EXAM_DOCTOR = Value.ToString();
                            break;
                        case "EXAM_GROUP":
                            smWorkList.EXAM_GROUP = Value.ToString();
                            break;
                        case "EXAM_INDEX":
                            smWorkList.EXAM_INDEX = Convert.ToInt32(Value);
                            break;
                        case "EXAM_INTRADAYSEQ_NO":
                            smWorkList.EXAM_INTRADAYSEQ_NO = Convert.ToDecimal(Value);
                            break;
                        case "EXAM_ITEMS":
                            smWorkList.EXAM_ITEMS = Value.ToString();
                            break;
                        case "EXAM_MODE":
                            smWorkList.EXAM_MODE = Value.ToString();
                            break;
                        case "EXAM_NO":
                            smWorkList.EXAM_NO = Value.ToString();
                            break;
                        case "EXAM_STEP_STATUS":
                            smWorkList.EXAM_STEP_STATUS = Convert.ToInt32(Value);
                            break;
                        case "EXAM_SUB_CLASS":
                            smWorkList.EXAM_SUB_CLASS = Value.ToString();
                            break;
                        case "FACILITY":
                            smWorkList.FACILITY = Value.ToString();
                            break;
                        case "IMAGE_ARCHIVED":
                            smWorkList.IMAGE_ARCHIVED = Convert.ToInt32(Value);
                            break;
                        case "IMAGE_COUNTS":
                            smWorkList.IMAGE_COUNTS = Convert.ToInt32(Value);
                            break;
                        case "INP_NO":
                            smWorkList.INP_NO = Value.ToString();
                            break;
                        case "IS_CONFIRMED":
                            smWorkList.IS_CONFIRMED = Convert.ToInt32(Value);
                            break;
                        case "IS_TEMPORARY":
                            smWorkList.IS_TEMPORARY = Convert.ToInt32(Value);
                            break;
                        case "LOCAL_ID_CLASS":
                            smWorkList.LOCAL_ID_CLASS = Value.ToString();
                            break;
                        case "MAILING_ADDRESS":
                            smWorkList.MAILING_ADDRESS = Value.ToString();
                            break;
                        case "MATCH_STATUS":
                            smWorkList.MATCH_STATUS = Convert.ToInt32(Value);
                            break;
                        case "OPD_NO":
                            smWorkList.OPD_NO = Value.ToString();
                            break;
                        case "OUT_MED_INSTITUTION":
                            smWorkList.OUT_MED_INSTITUTION = Value.ToString();
                            break;
                        case "PATIENT_AGE":
                            smWorkList.PATIENT_AGE = Convert.ToInt32(Value);
                            break;
                        case "PATIENT_AGE_UNIT":
                            smWorkList.PATIENT_AGE_UNIT = Value.ToString();
                            break;
                        case "PATIENT_BIRTH":
                            smWorkList.PATIENT_BIRTH = Convert.ToDateTime(Value);
                            break;
                        case "PATIENT_CLASS":
                            smWorkList.PATIENT_CLASS = Convert.ToInt32(Value);
                            break;
                        case "PATIENT_ID":
                            smWorkList.PATIENT_ID = Value.ToString();
                            break;
                        case "PATIENT_IDENTITY":
                            smWorkList.PATIENT_IDENTITY = Value.ToString();
                            break;
                        case "PATIENT_LOCAL_ID":
                            smWorkList.PATIENT_LOCAL_ID = Value.ToString();
                            break;
                        case "PATIENT_NAME":
                            smWorkList.PATIENT_NAME = Value.ToString();
                            break;
                        case "PATIENT_PHONETIC":
                            smWorkList.PATIENT_PHONETIC = Value.ToString();
                            break;
                        case "PATIENT_SEX":
                            smWorkList.PATIENT_SEX = Value.ToString();
                            break;
                        case "PATIENT_SOURCE":
                            smWorkList.PATIENT_SOURCE = Value.ToString();
                            break;
                        case "PHYS_SIGN":
                            smWorkList.PHYS_SIGN = Value.ToString();
                            break;
                        case "PRE_FETCH":
                            smWorkList.PRE_FETCH = Convert.ToInt32(Value);
                            break;
                        case "QUERY_STATUS":
                            smWorkList.QUERY_STATUS = Convert.ToInt32(Value);
                            break;
                        case "QUERY_TIME":
                            smWorkList.QUERY_TIME = Convert.ToDateTime(Value);
                            break;
                        case "REFER_DEPT":
                            smWorkList.REFER_DEPT = Value.ToString();
                            break;
                        case "REFER_DOCTOR":
                            smWorkList.REFER_DOCTOR = Value.ToString();
                            break;
                        case "RELEVANT_DIAG":
                            smWorkList.RELEVANT_DIAG = Value.ToString();
                            break;
                        case "RELEVANT_LAB_TEST":
                            smWorkList.RELEVANT_LAB_TEST = Value.ToString();
                            break;
                        case "REPORT_DOCTOR":
                            smWorkList.REPORT_DOCTOR = Value.ToString();
                            break;
                        case "REPORT_STATUS":
                            smWorkList.REPORT_STATUS = Convert.ToInt32(Value);
                            break;
                        case "REQ_DATE_TIME":
                            smWorkList.REQ_DATE_TIME = Convert.ToDateTime(Value);
                            break;
                        case "REQ_DEPT_NAME":
                            smWorkList.REQ_DEPT_NAME = Value.ToString();
                            break;
                        case "REQ_MEMO":
                            smWorkList.REQ_MEMO = Value.ToString();
                            break;
                        case "SCH_OPERATOR":
                            smWorkList.SCH_OPERATOR = Value.ToString();
                            break;
                        case "SCHEDULED_DATE":
                            // modify by liukun at 2010-6-30 begin 
                            //修改记录：传入的预约时间为空时，保存到后台数据库的数据也为空，
                            //如果不按如下的方法处理，则Convert.ToDateTime(null)的返回值为：0001-1-1,而不是为空
                            Nullable<DateTime> nulldate = null;
                            smWorkList.SCHEDULED_DATE = (Value == null ? nulldate : Convert.ToDateTime(Value));
                            // modify by liukun at 2010-6-30 end 
                            break;
                        case "STUDY_DATE_TIME":
                            smWorkList.STUDY_DATE_TIME = Convert.ToDateTime(Value);
                            break;
                        case "STUDY_INSTANCE_UID":
                            smWorkList.STUDY_INSTANCE_UID = Value.ToString();
                            break;
                        case "STUDY_PATH":
                            smWorkList.STUDY_PATH = Value.ToString();
                            break;
                        case "TELEPHONE_NUM":
                            smWorkList.TELEPHONE_NUM = Value.ToString();
                            break;
                        case "VIP_INDICATOR":
                            smWorkList.VIP_INDICATOR = Convert.ToInt32(Value);
                            break;
                        case "VISIT_ID":
                            smWorkList.VISIT_ID = Convert.ToInt32(Value);
                            break;
                        case "ZIP_CODE":
                            smWorkList.ZIP_CODE = Value.ToString();
                            break;
                    }
                    break;
            }
        }

        public void SetArchivesData(string Field, object Value, IModel iArchives)
        {
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    SIS_Model.MArchives mArchives = (SIS_Model.MArchives)iArchives;
                    switch (Field)
                    {
                        case "A1":
                            mArchives.A1 = Value.ToString();
                            break;
                        case "A2":
                            mArchives.A2 = Convert.ToInt32(Value);
                            break;
                        case "A3":
                            mArchives.A3 = Convert.ToInt32(Value);
                            break;
                        case "A4":
                            mArchives.A4 = Value.ToString();
                            break;
                        case "BESPEAK_TIME":
                            mArchives.BESPEAK_TIME = Convert.ToDateTime(Value);
                            break;
                        case "BIRTH_PLACE":
                            mArchives.BIRTH_PLACE = Value.ToString();
                            break;
                        case "CHARGE_CLASS":
                            mArchives.CHARGE_CLASS = Convert.ToInt32(Value);
                            break;
                        case "HABITATION":
                            mArchives.HABITATION = Value.ToString();
                            break;
                        case "IDENTITY_CARD_NO":
                            mArchives.IDENTITY_CARD_NO = Value.ToString();
                            break;
                        case "INP_NO":
                            mArchives.INP_NO = Value.ToString();
                            break;
                        case "INSURANCE_NO":
                            mArchives.INSURANCE_NO = Value.ToString();
                            break;
                        case "MAILING_ADDRESS":
                            mArchives.MAILING_ADDRESS = Value.ToString();
                            break;
                        case "NATIVE_PLACE":
                            mArchives.NATIVE_PLACE = Value.ToString();
                            break;
                        case "OPD_NO":
                            mArchives.OPD_NO = Value.ToString();
                            break;
                        case "PATIENT_AGE":
                            mArchives.PATIENT_AGE = Convert.ToInt32(Value);
                            break;
                        case "PATIENT_AGE_UNIT":
                            mArchives.PATIENT_AGE_UNIT = Value.ToString();
                            break;
                        case "PATIENT_BIRTH":
                            mArchives.PATIENT_BIRTH = Convert.ToDateTime(Value);
                            break;
                        case "PATIENT_ID":
                            mArchives.PATIENT_ID = Value.ToString();
                            break;
                        case "PATIENT_IDENTITY":
                            mArchives.PATIENT_IDENTITY = Value.ToString();
                            break;
                        case "PATIENT_NAME":
                            mArchives.PATIENT_NAME = Value.ToString();
                            break;
                        case "PATIENT_SEX":
                            mArchives.PATIENT_SEX = Value.ToString();
                            break;
                        case "TELEPHONE_NUM":
                            mArchives.TELEPHONE_NUM = Value.ToString();
                            break;
                        case "ZIP_CODE":
                            mArchives.ZIP_CODE = Value.ToString();
                            break;
                    }
                    break;
                case "PACS":
                    PACS_Model.MArchives mPatientInf = (PACS_Model.MArchives)iArchives;
                    switch (Field)
                    {
                        case "BIRTH_PLACE":
                            mPatientInf.BIRTH_PLACE = Value.ToString();
                            break;
                        case "HABITATION":
                            mPatientInf.HABITATION = Value.ToString();
                            break;
                        case "IDENTITY_CARD_NO":
                            mPatientInf.IDENTITY_CARD_NO = Value.ToString();
                            break;
                        case "INP_NO":
                            mPatientInf.INP_NO = Value.ToString();
                            break;
                        case "MAILING_ADDRESS":
                            mPatientInf.MAILING_ADDRESS = Value.ToString();
                            break;
                        case "NATIVE_PLACE":
                            mPatientInf.NATIVE_PLACE = Value.ToString();
                            break;
                        case "OPD_NO":
                            mPatientInf.OPD_NO = Value.ToString();
                            break;
                        case "PATIENT_BIRTH":
                            mPatientInf.PATIENT_BIRTH = Convert.ToDateTime(Value);
                            break;
                        case "PATIENT_CLASS":
                            mPatientInf.PATIENT_CLASS = Convert.ToInt32(Value);
                            break;
                        case "PATIENT_ENGLISH_NAME":
                            mPatientInf.PATIENT_ENGLISH_NAME = Value.ToString();
                            break;
                        case "PATIENT_ID":
                            mPatientInf.PATIENT_ID = Value.ToString();
                            break;
                        case "PATIENT_NAME":
                            mPatientInf.PATIENT_NAME = Value.ToString();
                            break;
                        case "PATIENT_SEX":
                            mPatientInf.PATIENT_SEX = Value.ToString();
                            break;
                        case "TELEPHONE_NUM":
                            mPatientInf.TELEPHONE_NUMBER = Value.ToString();
                            break;
                        case "VISIT_TIMES":
                            mPatientInf.VISIT_TIMES = Convert.ToInt32(Value);
                            break;
                        case "ZIP_CODE":
                            mPatientInf.ZIP_CODE = Value.ToString();
                            break;
                    }
                    break;
            }
        }

        public void SetPatientInfLocalIdData(string Field, object Value, IModel iPatientInfLocalId)
        {
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    SIS_Model.MPatientInfLocalId smPatientInfLocalId = (SIS_Model.MPatientInfLocalId)iPatientInfLocalId;
                    switch (Field)
                    {
                        case "EXAM_TIMES":
                            smPatientInfLocalId.EXAM_TIMES = Convert.ToInt32(Value);
                            break;
                        case "PATIENT_LOCAL_ID":
                            smPatientInfLocalId.PATIENT_LOCAL_ID = Value.ToString();
                            break;
                        case "LOCAL_ID_CLASS":
                            smPatientInfLocalId.LOCAL_ID_CLASS = Value.ToString();
                            break;
                    }
                    break;
                case "PACS":
                    PACS_Model.MPatientInfLocalId pmPatientInfLocalId = (PACS_Model.MPatientInfLocalId)iPatientInfLocalId;
                    switch (Field)
                    {
                        case "EXAM_TIMES":
                            pmPatientInfLocalId.EXAM_TIMES = Convert.ToInt32(Value);
                            break;
                        case "PATIENT_LOCAL_ID":
                            pmPatientInfLocalId.PATIENT_LOCAL_ID = Value.ToString();
                            break;
                        case "LOCAL_ID_CLASS":
                            pmPatientInfLocalId.LOCAL_ID_CLASS = Value.ToString();
                            break;
                    }
                    break;
            }
        }
    }
}
