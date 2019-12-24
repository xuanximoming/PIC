using System;
using System.Collections.Generic;
using System.Text;

namespace SIS
{
    public class FieldDict
    {
        #region 来源STUDY

        public const string EXAM_ITEM = "$EXAM_ITEM";               //检查项目..来源STUDY表
        public const string STUDY_ID = "$STUDY_ID";                 //study_id检查号只有STUDY才有
        public const string STUDY_DATE_TIME = "$STUDY_DATE_TIME";   //STUDY_DATE_TIME

        # endregion 来源STUDY

        #region 来源REPORT
        public const string DESCRIPTION = "$DESCRIPTION";            //检查描述
        public const string EXAM_PARA = "$EXAM_PARA";                //检查内容
        public const string IMPRESSION = "$IMPRESSION";              //印象
        public const string RECOMMENDATION = "$RECOMMENDATION";      //附注
        public const string REPORT_DATE_TIME = "$REPORT_DATE_TIME";  //报告时间

        public const string BL_DIAG = "$BL_DIAG";                     //病理学诊断
        public const string XB_DIAG = "$XB_DIAG";                     //细胞学诊断
        # endregion 来源REPORT

        #region 来源WORKLIST
        public const string PATIENT_NAME = "$PATIENT_NAME";            //病人姓名
        public const string PATIENT_ID = "$PATIENT_ID";                //病人ID
        public const string PATIENT_SEX = "$PATIENT_SEX";              //姓别
        public const string PATIENT_AGE = "$PATIENT_AGE";              //年龄
        public const string EXAM_NO = "$EXAM_NO";                      //检查号
        public const string EXAM_ITEMS = "$EXAM_ITEMS";                //检查项目
        public const string REQ_DEPT_NAME = "$REQ_DEPT_NAME";          //申请科室
        public const string EXAM_GROUP = "$EXAM_GROUP";                //检查组
        public const string BED_NUM = "$BED_NUM";                      //床号
        public const string INP_NO = "$INP_NO";                        //住院号
        public const string DEVICE = "$DEVICE";                        //设备

        public const string EXAM_CLASS = "$EXAM_CLASS";                //检查类别
        public const string EXAM_SUB_CLASS = "$EXAM_SUB_CLASS";        //检查子类

        public const string PATIENT_SOURCE = "$PATIENT_SOURCE";        //病人来源
        public const string CHARGE_TYPE = "$CHARGE_TYPE";              //收费类别(注:未启用)
        public const string TELEPHONE_NUM = "$TELEPHONE_NUM";          //联系电话
        public const string CLIN_SYMP = "$CLIN_SYMP";                  //临床症状
        public const string CLIN_DIAG = "$CLIN_DIAG";                  //临床诊断
        public const string APPROVE_DATE_TIME = "$APPROVE_DATE_TIME";  //审核时间
        public const string REQ_DATE_TIME = "$REQ_DATE_TIME";          //申请时间
        public const string REFER_DOCTOR = "$REFER_DOCTOR";            //申请医生
        public const string PATIENT_LOCAL_ID = "$PATIENT_LOCAL_ID";    //检查号
        public const string OUT_MED_INSTITUTION = "$OUT_MED_INSTITUTION";    //外来单位
        public const string MAILING_ADDRESS = "$MAILING_ADDRESS";      //通讯地址

        # endregion 来源WORKLIST

        #region 用户
        public const string TRANSCRIBER = "$TRANSCRIBER";              //报告医生
        # endregion 用户
        #region 其它
        public const string DATE_TIME_NOW = "$DATE_TIME_NOW";            //当前时间
        #endregion 其它
        public const string IMAGE = "$IMAGE";                          //图像
        //combox
        public const string cmbAPPROVER = "cmb_APPROVER";              //下拉选项-报告医生
        public const string cmbSex = "cmb_Sex";                        //下拉选项-性别

    }
}
