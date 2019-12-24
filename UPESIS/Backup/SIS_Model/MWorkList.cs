using System;
namespace SIS_Model
{
    /// <summary>
    /// ʵ����WORKLIST�������б�
    /// </summary>
    [Serializable]
    public class MWorkList : ILL.IModel
    {
        public MWorkList()
        { }
        #region Model
        private string _exam_accession_num;     //��������
        private int? _accession_no;             //�����ˮ��
        private string _patient_id;             //����ID
        private string _patient_name;           //����
        private string _patient_phonetic;       //����ƴ��
        private string _patient_sex;            //�Ա�
        private DateTime? _patient_birth;       //��������
        private int? _patient_age;              //����
        private string _patient_age_unit;       //���䵥λ
        private string _patient_identity;       //���
        private string _patient_local_id;       //����ID
        private string _local_id_class;         //����ID���
        private string _inp_no;                 //סԺ��
        private string _bed_num;                //����
        private string _opd_no;                 //�����
        private string _birth_place;            //������
        private int? _charge_type;              //�շ����
        private string _mailing_address;        //ͨ�ŵ�ַ
        private string _zip_code;               //��������
        private string _telephone_num;          //�绰����
        private string _patient_source;         //������Դ
        private string _exam_class;             //������
        private string _exam_sub_class;         //�������
        private string _exam_items;             //�����Ŀ
        private string _exam_dept;              //�����Ҵ���
        private string _exam_dept_name;         //����������
        private string _exam_mode;              //��鷽ʽ
        private string _exam_group;             //�����������
        private string _exam_doctor;            //���ҽ������
        private string _exam_no;                //���˳���
        private int? _exam_index;               //����ۼ�
        private decimal? _exam_intradayseq_no;  //������ˮ��
        private string _study_instance_uid;     //���ʵ��UID
        private string _study_path;             //���ͼ��Ŀ¼·��
        private string _report_doctor;          //����ҽ��
        private string _device;                 //�豸��
        private DateTime? _study_date_time;     //�������ʱ��
        private int? _exam_step_status;         //�����ɱ�־
        private int? _report_status;            //����״̬
        private int? _is_confirmed;             //�շ�ȷ�ϱ�־ 0.δȷ��1.��ȷ���շ�2.��ʾ�˷�Ĭ��Ϊ0
        private int? _match_status;             //ƥ���־
        private int? _is_temporary;             //��ɫͨ����־
        private int? _vip_indicator;            //VIP��־
        private int? _image_archived;           //����־
        private int? _pre_fetch;                //Ԥȡ״̬��־
        private int? _dispatch_status;          //�ַ���־
        private int? _query_status;             //��ѯ״̬
        private DateTime? _query_time;          //��ѯʱ��
        private int? _patient_class;            //��Ժ��ʽ
        private int? _image_counts;             //ͼ������
        private DateTime? _scheduled_date;      //ԤԼʱ��
        private string _sch_operator;           //�Ǽ�Ա
        private string _refer_doctor;           //����ҽ��
        private string _refer_dept;             //������Ҵ���
        private DateTime? _req_date_time;       //��������ʱ��
        private string _req_dept_name;          //�����������
        private string _req_memo;               //���뱸ע
        private string _clin_symp;              //�ٴ�֢״
        private string _phys_sign;              //����
        private string _relevant_lab_test;      //��ؼ��
        private string _relevant_diag;          //������
        private string _clin_diag;              //�ٴ����
        private string _facility;               //�豸��
        private string _out_med_institution;    //������λ����
        private decimal? _costs;                //�Ƽ�
        private decimal? _charges;              //�շ�
        private int? _visit_id;                 //סԺ����
        private int? _is_inquiry;               //��ñ�־
        private int? _is_back_inq;              //�طñ�־
        private int? _is_online;                //����״̬
        private int? _is_packprocess;           //�����־
        private string _volumn_key;             //���ֵ
        private string _jzh;           //add by liukun at 2010-7-13 �ٴ����˺�

        /// <summary>
        /// ���˺�
        /// </summary>
        public string JZH
        {
            set { _jzh = value; }
            get { return _jzh; }
        }   //add by liukun at 2010-7-13 �ٴ����˺� 

        /// <summary>
        /// ��������
        /// </summary>
        public string EXAM_ACCESSION_NUM
        {
            set { _exam_accession_num = value; }
            get { return _exam_accession_num; }
        }

        /// <summary>
        /// �����ˮ��
        /// </summary>
        public int? ACCESSION_NO
        {
            set { _accession_no = value; }
            get { return _accession_no; }
        }

        /// <summary>
        /// ����ID
        /// </summary>
        public string PATIENT_ID
        {
            set { _patient_id = value; }
            get { return _patient_id; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string PATIENT_NAME
        {
            set { _patient_name = value; }
            get { return _patient_name; }
        }

        /// <summary>
        /// ����ƴ��
        /// </summary>
        public string PATIENT_PHONETIC
        {
            set { _patient_phonetic = value; }
            get { return _patient_phonetic; }
        }

        /// <summary>
        /// �Ա�
        /// </summary>
        public string PATIENT_SEX
        {
            set { _patient_sex = value; }
            get { return _patient_sex; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public DateTime? PATIENT_BIRTH
        {
            set { _patient_birth = value; }
            get { return _patient_birth; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public int? PATIENT_AGE
        {
            set { _patient_age = value; }
            get { return _patient_age; }
        }

        /// <summary>
        /// ���䵥λ
        /// </summary>
        public string PATIENT_AGE_UNIT
        {
            set { _patient_age_unit = value; }
            get { return _patient_age_unit; }
        }

        /// <summary>
        /// ���
        /// </summary>
        public string PATIENT_IDENTITY
        {
            set { _patient_identity = value; }
            get { return _patient_identity; }
        }

        /// <summary>
        /// ����ID
        /// </summary>
        public string PATIENT_LOCAL_ID
        {
            set { _patient_local_id = value; }
            get { return _patient_local_id; }
        }

        /// <summary>
        /// ����ID���
        /// </summary>
        public string LOCAL_ID_CLASS
        {
            set { _local_id_class = value; }
            get { return _local_id_class; }
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
        /// �����
        /// </summary>
        public string OPD_NO
        {
            set { _opd_no = value; }
            get { return _opd_no; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public string BIRTH_PLACE
        {
            set { _birth_place = value; }
            get { return _birth_place; }
        }

        /// <summary>
        /// �շ����
        /// </summary>
        public int? CHARGE_TYPE
        {
            set { _charge_type = value; }
            get { return _charge_type; }
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
        /// ��������
        /// </summary>
        public string ZIP_CODE
        {
            set { _zip_code = value; }
            get { return _zip_code; }
        }

        /// <summary>
        /// �绰����
        /// </summary>
        public string TELEPHONE_NUM
        {
            set { _telephone_num = value; }
            get { return _telephone_num; }
        }

        /// <summary>
        /// ������Դ
        /// </summary>
        public string PATIENT_SOURCE
        {
            set { _patient_source = value; }
            get { return _patient_source; }
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
        public string EXAM_ITEMS
        {
            set { _exam_items = value; }
            get { return _exam_items; }
        }

        /// <summary>
        /// �����Ҵ���
        /// </summary>
        public string EXAM_DEPT
        {
            set { _exam_dept = value; }
            get { return _exam_dept; }
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
        /// ���ҽ��
        /// </summary>
        public string EXAM_DOCTOR
        {
            set { _exam_doctor = value; }
            get { return _exam_doctor; }
        }

        /// <summary>
        /// ���˳���
        /// </summary>
        public string EXAM_NO
        {
            set { _exam_no = value; }
            get { return _exam_no; }
        }

        /// <summary>
        /// ����ۼ�
        /// </summary>
        public int? EXAM_INDEX
        {
            set { _exam_index = value; }
            get { return _exam_index; }
        }

        /// <summary>
        /// ������ˮ��
        /// </summary>
        public decimal? EXAM_INTRADAYSEQ_NO
        {
            set { _exam_intradayseq_no = value; }
            get { return _exam_intradayseq_no; }
        }

        /// <summary>
        /// ���ʵ��UID
        /// </summary>
        public string STUDY_INSTANCE_UID
        {
            set { _study_instance_uid = value; }
            get { return _study_instance_uid; }
        }

        /// <summary>
        /// ���ͼ��·��
        /// </summary>
        public string STUDY_PATH
        {
            set { _study_path = value; }
            get { return _study_path; }
        }

        /// <summary>
        /// ����ҽ��
        /// </summary>
        public string REPORT_DOCTOR
        {
            set { _report_doctor = value; }
            get { return _report_doctor; }
        }

        /// <summary>
        /// �豸����
        /// </summary>
        public string DEVICE
        {
            set { _device = value; }
            get { return _device; }
        }

        /// <summary>
        /// �������ʱ��
        /// </summary>
        public DateTime? STUDY_DATE_TIME
        {
            set { _study_date_time = value; }
            get { return _study_date_time; }
        }

        /// <summary>
        /// ������״̬
        /// </summary>
        public int? EXAM_STEP_STATUS
        {
            set { _exam_step_status = value; }
            get { return _exam_step_status; }
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
        /// �շ�ȷ�ϱ�־
        /// </summary>
        public int? IS_CONFIRMED
        {
            set { _is_confirmed = value; }
            get { return _is_confirmed; }
        }

        /// <summary>
        /// ƥ���־
        /// </summary>
        public int? MATCH_STATUS
        {
            set { _match_status = value; }
            get { return _match_status; }
        }
        
        /// <summary>
        /// ��ɫͨ����־
        /// </summary>
        public int? IS_TEMPORARY
        {
            set { _is_temporary = value; }
            get { return _is_temporary; }
        }

        /// <summary>
        /// VIP��־
        /// </summary>
        public int? VIP_INDICATOR
        {
            set { _vip_indicator = value; }
            get { return _vip_indicator; }
        }

        /// <summary>
        /// ͼ������־
        /// </summary>
        public int? IMAGE_ARCHIVED
        {
            set { _image_archived = value; }
            get { return _image_archived; }
        }

        /// <summary>
        /// Ԥȡ״̬��־
        /// </summary>
        public int? PRE_FETCH
        {
            set { _pre_fetch = value; }
            get { return _pre_fetch; }
        }

        /// <summary>
        /// �ַ�״̬
        /// </summary>
        public int? DISPATCH_STATUS
        {
            set { _dispatch_status = value; }
            get { return _dispatch_status; }
        }

        /// <summary>
        /// ��ѯ״̬��־
        /// </summary>
        public int? QUERY_STATUS
        {
            set { _query_status = value; }
            get { return _query_status; }
        }

        /// <summary>
        /// ��ѯʱ��
        /// </summary>
        public DateTime? QUERY_TIME
        {
            set { _query_time = value; }
            get { return _query_time; }
        }

        /// <summary>
        /// ��Ժ��ʽ
        /// </summary>
        public int? PATIENT_CLASS
        {
            set { _patient_class = value; }
            get { return _patient_class; }
        }

        /// <summary>
        /// ͼ������
        /// </summary>
        public int? IMAGE_COUNTS
        {
            set { _image_counts = value; }
            get { return _image_counts; }
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
        /// �Ǽ�Ա
        /// </summary>
        public string SCH_OPERATOR
        {
            set { _sch_operator = value; }
            get { return _sch_operator; }
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
        /// �������
        /// </summary>
        public string REFER_DEPT
        {
            set { _refer_dept = value; }
            get { return _refer_dept; }
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
        /// �����������
        /// </summary>
        public string REQ_DEPT_NAME
        {
            set { _req_dept_name = value; }
            get { return _req_dept_name; }
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
        /// �ٴ�֢״
        /// </summary>
        public string CLIN_SYMP
        {
            set { _clin_symp = value; }
            get { return _clin_symp; }
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
        /// �ٴ����
        /// </summary>
        public string CLIN_DIAG
        {
            set { _clin_diag = value; }
            get { return _clin_diag; }
        }

        /// <summary>
        /// �豸��
        /// </summary>
        public string FACILITY
        {
            set { _facility = value; }
            get { return _facility; }
        }

        /// <summary>
        /// ������λ��������
        /// </summary>
        public string OUT_MED_INSTITUTION
        {
            set { _out_med_institution = value; }
            get { return _out_med_institution; }
        }

        /// <summary>
        /// �Ƽ�
        /// </summary>
        public decimal? COSTS
        {
            set { _costs = value; }
            get { return _costs; }
        }

        /// <summary>
        /// �շ�
        /// </summary>
        public decimal? CHARGES
        {
            set { _charges = value; }
            get { return _charges; }
        }

        /// <summary>
        /// ����ۼ�
        /// </summary>
        public int? VISIT_ID
        {
            set { _visit_id = value; }
            get { return _visit_id; }
        }

        /// <summary>
        /// ��ñ�־
        /// </summary>
        public int? IS_INQUIRY
        {
            set { _is_inquiry = value; }
            get { return _is_inquiry; }
        }

        /// <summary>
        /// �طñ�־
        /// </summary>
        public int? IS_BACK_INQ
        {
            set { _is_back_inq = value; }
            get { return _is_back_inq; }
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
        /// �����־
        /// </summary>
        public int? IS_PACKPROCESS
        {
            set { _is_packprocess = value; }
            get { return _is_packprocess; }
        }

        /// <summary>
        /// ���key
        /// </summary>
        public string VOLUMN_KEY
        {
            set { _volumn_key = value; }
            get { return _volumn_key; }
        }
        #endregion Model

    }
}