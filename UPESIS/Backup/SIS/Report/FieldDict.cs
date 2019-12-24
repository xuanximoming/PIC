using System;
using System.Collections.Generic;
using System.Text;

namespace SIS
{
    public class FieldDict
    {
        #region ��ԴSTUDY

        public const string EXAM_ITEM = "$EXAM_ITEM";               //�����Ŀ..��ԴSTUDY��
        public const string STUDY_ID = "$STUDY_ID";                 //study_id����ֻ��STUDY����
        public const string STUDY_DATE_TIME = "$STUDY_DATE_TIME";   //STUDY_DATE_TIME

        # endregion ��ԴSTUDY

        #region ��ԴREPORT
        public const string DESCRIPTION = "$DESCRIPTION";            //�������
        public const string EXAM_PARA = "$EXAM_PARA";                //�������
        public const string IMPRESSION = "$IMPRESSION";              //ӡ��
        public const string RECOMMENDATION = "$RECOMMENDATION";      //��ע
        public const string REPORT_DATE_TIME = "$REPORT_DATE_TIME";  //����ʱ��

        public const string BL_DIAG = "$BL_DIAG";                     //����ѧ���
        public const string XB_DIAG = "$XB_DIAG";                     //ϸ��ѧ���
        # endregion ��ԴREPORT

        #region ��ԴWORKLIST
        public const string PATIENT_NAME = "$PATIENT_NAME";            //��������
        public const string PATIENT_ID = "$PATIENT_ID";                //����ID
        public const string PATIENT_SEX = "$PATIENT_SEX";              //�ձ�
        public const string PATIENT_AGE = "$PATIENT_AGE";              //����
        public const string EXAM_NO = "$EXAM_NO";                      //����
        public const string EXAM_ITEMS = "$EXAM_ITEMS";                //�����Ŀ
        public const string REQ_DEPT_NAME = "$REQ_DEPT_NAME";          //�������
        public const string EXAM_GROUP = "$EXAM_GROUP";                //�����
        public const string BED_NUM = "$BED_NUM";                      //����
        public const string INP_NO = "$INP_NO";                        //סԺ��
        public const string DEVICE = "$DEVICE";                        //�豸

        public const string EXAM_CLASS = "$EXAM_CLASS";                //������
        public const string EXAM_SUB_CLASS = "$EXAM_SUB_CLASS";        //�������

        public const string PATIENT_SOURCE = "$PATIENT_SOURCE";        //������Դ
        public const string CHARGE_TYPE = "$CHARGE_TYPE";              //�շ����(ע:δ����)
        public const string TELEPHONE_NUM = "$TELEPHONE_NUM";          //��ϵ�绰
        public const string CLIN_SYMP = "$CLIN_SYMP";                  //�ٴ�֢״
        public const string CLIN_DIAG = "$CLIN_DIAG";                  //�ٴ����
        public const string APPROVE_DATE_TIME = "$APPROVE_DATE_TIME";  //���ʱ��
        public const string REQ_DATE_TIME = "$REQ_DATE_TIME";          //����ʱ��
        public const string REFER_DOCTOR = "$REFER_DOCTOR";            //����ҽ��
        public const string PATIENT_LOCAL_ID = "$PATIENT_LOCAL_ID";    //����
        public const string OUT_MED_INSTITUTION = "$OUT_MED_INSTITUTION";    //������λ
        public const string MAILING_ADDRESS = "$MAILING_ADDRESS";      //ͨѶ��ַ

        # endregion ��ԴWORKLIST

        #region �û�
        public const string TRANSCRIBER = "$TRANSCRIBER";              //����ҽ��
        # endregion �û�
        #region ����
        public const string DATE_TIME_NOW = "$DATE_TIME_NOW";            //��ǰʱ��
        #endregion ����
        public const string IMAGE = "$IMAGE";                          //ͼ��
        //combox
        public const string cmbAPPROVER = "cmb_APPROVER";              //����ѡ��-����ҽ��
        public const string cmbSex = "cmb_Sex";                        //����ѡ��-�Ա�

    }
}
