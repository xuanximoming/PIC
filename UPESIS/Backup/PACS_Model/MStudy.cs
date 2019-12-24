using System;
using System.Collections.Generic;
using System.Text;

namespace PACS_Model
{
    /// <summary>
    /// ʵ����STUDY������¼�����ñ������¼
    /// </summary>
    [Serializable]
    public class MStudy : ILL.IModel
    {
        public MStudy()
        { }
        #region Model
        private int _study_key;             //��������������Զ�����
        private string _patient_id;         //����ID
        private string _patient_name;       //��������
        private string _patient_sex;        //��������
        private DateTime? _patient_birth;   //��������
        private int? _patient_age;          //����
        private string _patient_age_unit;   //���䵥λ
        private string _patient_source;     //������Դ
        private string _birth_place;        //������
        private string _identity;           //���
        private int? _security;             //�ܼ�������2��ֹ����
        private string _charge_type;        //�ѱ�
        private int? _visit_id;             //סԺ����
        private string _inp_no;             //סԺ��
        private string _bed_num;            //����
        private string _zip_code;           //��������
        private string _mailing_address;    //ͨ�ŵ�ַ
        private string _telephone_number;   //�绰
        private string _study_id;           //���μ���
        private string _study_desc;         //�������
        private string _study_instance_uid; //���ʵ��UID
        private DateTime? _study_date_time; //�������ʱ��
        private string _access_no;          //���˳���
        private string _body_part;          //��鲿λ
        private int? _series_count;         //�����������
        private int? _instance_count;������ //���μ��ʵ������
        private string _modality;           //����豸
        private string _facility;           //������λ����        
        private string _refer_doctor;       //����ҽ��
        private string _refer_dept;         //������Ҵ���
        private string _req_memo;           //���뱸ע
        private string _req_dept_name;      //�����������
        private DateTime? _req_date_time;   //����ʱ������
        private DateTime? _scheduled_date;  //ԤԼʱ��
        private string _sch_operator;       //�Ǽ�Ա
        private string _exam_no;            //����
        private string _exam_accession_num; //��������
        private string _exam_class;         //������
        private string _exam_sub_class;     //�������
        private string _exam_item;          //�����Ŀ  
        private string _exam_mode;          //��鷽ʽ
        private string _exam_group;         //�������
        private string _exam_dept_name;     //����������  
        private string _exam_doctor;        //���ҽ��
        private int? _exam_index;           //�����ţ����������
        private int? _is_online;            //���߱�־
        private int? _is_matched;           //ƥ���־
        private int? _is_packprocess;       //�����־
        private int? _report_status;        //����״̬
        private int? _verified;             //��֤��־
        private string _approver;           //������
        private string _clin_diag;          //�ٴ����
        private string _clin_symp;          //�ٴ�֢״
        private string _relevant_lab_test;  //��ؼ��
        private string _relevant_diag;      //������
        private string _phys_sign;          //����
        private string _study_path;         //���Ŀ¼·��
        private string _volume_key;         //���ֵ
        private string _device;             //�豸�ͺ�

        /// <summary>
        /// ������������ݿ��Զ�����
        /// </summary>
        public int STUDY_KEY
        {
            set { _study_key = value; }
            get { return _study_key; }
        }

        /// <summary>
        /// ����ID�ţ��Ǽ�ʱ����
        /// </summary>
        public string PATIENT_ID
        {
            set { _patient_id = value; }
            get { return _patient_id; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string PATIENT_NAME
        {
            set { _patient_name = value; }
            get { return _patient_name; }
        }

        /// <summary>
        /// �����Ա�
        /// </summary>
        public string PATIENT_SEX
        {
            set { _patient_sex = value; }
            get { return _patient_sex; }
        }

        /// <summary>
        /// ���˳�������
        /// </summary>
        public DateTime? PATIENT_BIRTH
        {
            set { _patient_birth = value; }
            get { return _patient_birth; }
        }

        /// <summary>
        ///�������� 
        /// </summary>
        public int? PATIENT_AGE
        {
            set { _patient_age = value; }
            get { return _patient_age; }
        }

        /// <summary>
        /// �������䵥λ
        /// </summary>
        public string PATIENT_AGE_UNIT
        {
            set { _patient_age_unit = value; }
            get { return _patient_age_unit; }
        }

        /// <summary>
        ///������Դ��һ��������סԺ 
        /// </summary>
        public string PATIENT_SOURCE
        {
            set { _patient_source = value; }
            get { return _patient_source; }
        }

        /// <summary>
        ///������ 
        /// </summary>
        public string BIRTH_PLACE
        {
            set { _birth_place = value; }
            get { return _birth_place; }
        }

        /// <summary>
        /// ���
        /// </summary>
        public string IDENTITY
        {
            set { _identity = value; }
            get { return _identity; }
        }

        /// <summary>
        /// �ܼ�
        /// </summary>
        public int? SECURITY
        {
            set { _security = value; }
            get { return _security; }
        }

        /// <summary>
        /// �ѱ��Էѻ��ǹ���
        /// </summary>
        public string CHARGE_TYPE
        {
            set { _charge_type = value; }
            get { return _charge_type; }
        }

        /// <summary>
        /// סԺ����
        /// </summary>
        public int? VISIT_ID
        {
            set { _visit_id = value; }
            get { return _visit_id; }
        }

        /// <summary>
        /// סԺ��
        /// </summary>
        public string INP_NO
        {
            set { _inp_no = value; }
            get { return _inp_no; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string BED_NUM
        {
            set { _bed_num = value; }
            get { return _bed_num; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string ZIP_CODE
        {
            set { _zip_code = value; }
            get { return _zip_code; }
        }

        /// <summary>
        /// ͨ�ŵ�ַ
        /// </summary>
        public string MAILING_ADDRESS
        {
            set { _mailing_address = value; }
            get { return _mailing_address; }
        }

        /// <summary>
        /// �绰����
        /// </summary>
        public string TELEPHONE_NUMBER
        {
            set { _telephone_number = value; }
            get { return _telephone_number; }
        }

        /// <summary>
        /// ���μ���
        /// </summary>
        public string STUDY_ID
        {
            set { _study_id = value; }
            get { return _study_id; }
        }

        /// <summary>
        /// �������
        /// </summary>
        public string STUDY_DESC
        {
            set { _study_desc = value; }
            get { return _study_desc; }
        }

        /// <summary>
        /// ���ʵ��ID
        /// </summary>
        public string STUDY_INSTANCE_UID
        {
            set { _study_instance_uid = value; }
            get { return _study_instance_uid; }
        }

        /// <summary>
        ///�������ʱ�� 
        /// </summary>
        public DateTime? STUDY_DATE_TIME
        {
            set { _study_date_time = value; }
            get { return _study_date_time; }
        }

        /// <summary>
        ///���˳���
        /// </summary>
        public string ACCESS_NO
        {
            set { _access_no = value; }
            get { return _access_no; }
        }
        /// <summary>
        /// ��鲿λ
        /// </summary>
        public string BODY_PART
        {
            set { _body_part = value; }
            get { return _body_part; }
        }

        /// <summary>
        /// ͼ����������
        /// </summary>
        public int? SERIES_COUNT
        {
            set { _series_count = value; }
            get { return _series_count; }
        }

        /// <summary>
        /// ���μ��ʵ������
        /// </summary>
        public int? INSTANCE_COUNT
        {
            set { _instance_count = value; }
            get { return _instance_count; }
        }

        /// <summary>
        /// �豸��
        /// </summary>
        public string MODALITY
        {
            set { _modality = value; }
            get { return _modality; }
        }

        /// <summary>
        /// ������λ����
        /// </summary>
        public string FACILITY
        {
            set { _facility = value; }
            get { return _facility; }
        }

        /// <summary>
        /// ����ҽ��
        /// </summary>
        public string REFER_DOCTOR
        {
            set { _refer_doctor = value; }
            get { return _refer_doctor; }
        }

        /// <summary>
        /// ������Ҵ���
        /// </summary>
        public string REFER_DEPT
        {
            set { _refer_dept = value; }
            get { return _refer_dept; }
        }

        /// <summary>
        /// ���뱸ע
        /// </summary>
        public string REQ_MEMO
        {
            set { _req_memo = value; }
            get { return _req_memo; }
        }

        /// <summary>
        /// �����������
        /// </summary>
        public string REQ_DEPT_NAME
        {
            set { _req_dept_name = value; }
            get { return _req_dept_name; }
        }

        /// <summary>
        /// ��������ʱ��
        /// </summary>
        public DateTime? REQ_DATE_TIME
        {
            set { _req_date_time = value; }
            get { return _req_date_time; }
        }

        /// <summary>
        /// ԤԼʱ��
        /// </summary>
        public DateTime? SCHEDULED_DATE
        {
            set { _scheduled_date = value; }
            get { return _scheduled_date; }
        }

        /// <summary>
        /// �Ǽ�Ա����
        /// </summary>
        public string SCH_OPERATOR
        {
            set { _sch_operator = value; }
            get { return _sch_operator; }
        }

        /// <summary>
        /// ���ţ�һ�������뵥��
        /// </summary>
        public string EXAM_NO
        {
            set { _exam_no = value; }
            get { return _exam_no; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string EXAM_ACCESSION_NUM
        {
            set { _exam_accession_num = value; }
            get { return _exam_accession_num; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public string EXAM_CLASS
        {
            set { _exam_class = value; }
            get { return _exam_class; }
        }

        /// <summary>
        /// �������
        /// </summary>
        public string EXAM_SUB_CLASS
        {
            set { _exam_sub_class = value; }
            get { return _exam_sub_class; }
        }

        /// <summary>
        /// �����Ŀ
        /// </summary>
        public string EXAM_ITEM
        {
            set { _exam_item = value; }
            get { return _exam_item; }
        }

        /// <summary>
        /// ��鷽ʽ
        /// </summary>
        public string EXAM_MODE
        {
            set { _exam_mode = value; }
            get { return _exam_mode; }
        }

        /// <summary>
        /// �������
        /// </summary>
        public string EXAM_GROUP
        {
            set { _exam_group = value; }
            get { return _exam_group; }
        }

        /// <summary>
        /// ����������
        /// </summary>
        public string EXAM_DEPT_NAME
        {
            set { _exam_dept_name = value; }
            get { return _exam_dept_name; }
        }

        /// <summary>
        /// ���ҽ��
        /// </summary>
        public string EXAM_DOCTOR
        {
            set { _exam_doctor = value; }
            get { return _exam_doctor; }
        }

        /// <summary>
        /// �������
        /// </summary>
        public int? EXAM_INDEX
        {
            set { _exam_index = value; }
            get { return _exam_index; }
        }

        /// <summary>
        /// ���߱�־
        /// </summary>
        public int? IS_ONLINE
        {
            set { _is_online = value; }
            get { return _is_online; }
        }

        /// <summary>
        /// ƥ���־
        /// </summary>
        public int? IS_MATCHED
        {
            set { _is_matched = value; }
            get { return _is_matched; }
        }

        /// <summary>
        /// �����־
        /// </summary>
        public int? IS_PACKPROCESS
        {
            set { _is_packprocess = value; }
            get { return _is_packprocess; }
        }

        /// <summary>
        /// ����״̬
        /// </summary>
        public int? REPORT_STATUS
        {
            set { _report_status = value; }
            get { return _report_status; }
        }

        /// <summary>
        /// ��֤��־
        /// </summary>
        public int? VERIFIED
        {
            set { _verified = value; }
            get { return _verified; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public string APPROVER
        {
            set { _approver = value; }
            get { return _approver; }
        }

        /// <summary>
        /// �ٴ����
        /// </summary>
        public string CLIN_DIAG
        {
            set { _clin_diag = value; }
            get { return _clin_diag; }
        }

        /// <summary>
        /// �ٴ�֢״
        /// </summary>
        public string CLIN_SYMP
        {
            set { _clin_symp = value; }
            get { return _clin_symp; }
        }

        /// <summary>
        /// ��ؼ��
        /// </summary>
        public string RELEVANT_LAB_TEST
        {
            set { _relevant_lab_test = value; }
            get { return _relevant_lab_test; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public string RELEVANT_DIAG
        {
            set { _relevant_diag = value; }
            get { return _relevant_diag; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string PHYS_SIGN
        {
            set { _phys_sign = value; }
            get { return _phys_sign; }
        }

        /// <summary>
        /// ���Ŀ¼·��
        /// </summary>
        public string STUDY_PATH
        {
            set { _study_path = value; }
            get { return _study_path; }
        }

        /// <summary>
        /// ���ֵ
        /// </summary>
        public string VOLUME_KEY
        {
            set { _volume_key = value; }
            get { return _volume_key; }
        }

        /// <summary>
        /// �豸�ͺ�
        /// </summary>
        public string DEVICE
        {
            set { _device = value; }
            get { return _device; }
        }
        #endregion Model
    }
}