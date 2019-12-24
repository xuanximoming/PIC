using System;

namespace SIS_Model
{
    /// <summary>
    /// ʵ����EXAM_INQUIRY�������ü�¼��
    /// </summary>
    [Serializable]
    public class MExamInquiry:ILL.IModel
    {
        public MExamInquiry()
        {
        }
        #region Model
        private string _exam_accession_num; //��������
        private string _patient_id;         //����ID    
        private string _patient_name;       //����
        private string _patient_sex;        //�Ա�
        private int? _patient_age;          //����
        private string _patient_age_unit;   //���䵥λ
        private string _inp_no;             //סԺ��
        private int? _visit_id;             //����סԺ��־
        private int? _oper_id;              //����������ʶ
        private string _req_dept_name;      //�����������
        private string _exam_dept_name;     //����������
        private string _exam_class;         //������
        private string _exam_sub_class;     //�������
        private string _patient_local_id;   //���˱���ID
        private string _path_no;            //�����
        private string _clin_data;          //�ٴ�����
        private string _description;        //Ӱ��ѧ����
        private string _impression;         //Ӱ��
        private string _approver;           //���ҽ��
        private string _transcriber;        //����ҽ��
        private string _oper_dept_name;     //������������
        private string _surgeon;            //����ҽ��
        private DateTime? _oper_date;       //��������
        private string _oper_name;          //��������
        private string _oper_description;   //��������
        private string _oper_diagnosis;     //�������
        private string _path_diagnosis;     //����(���)
        private string _path_diag_doctor;   //������ҽ��
        private int? _qualitative;          //����
        private int? _pitch;                //��λ
        private string _inqu_doctor;        //���ҽ��
        private DateTime? _inqu_date_time;  //�������
        private string _inqu_dept_code;     //���ҽ�����Ҵ���

        /// <summary>
        ///�������� 
        /// </summary>
        public string EXAM_ACCESSION_NUM
        {
            set { _exam_accession_num = value; }
            get { return _exam_accession_num; }
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
        /// �Ա�
        /// </summary>
        public string PATIENT_SEX
        {
            set { _patient_sex = value; }
            get { return _patient_sex; }
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
        /// סԺ��
        /// </summary>
        public string INP_NO
        {
            set { _inp_no = value; }
            get { return _inp_no; }
        }

        /// <summary>
        /// ����סԺ��ʶ
        /// </summary>
        public int? VISIT_ID
        {
            set { _visit_id = value; }
            get { return _visit_id; }
        }

        /// <summary>
        /// ����������ʶ
        /// </summary>
        public int? OPER_ID
        {
            set { _oper_id = value; }
            get { return _oper_id; }
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
        /// ����������
        /// </summary>
        public string EXAM_DEPT_NAME
        {
            set { _exam_dept_name = value; }
            get { return _exam_dept_name; }
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
        /// ���˱���ID
        /// </summary>
        public string PATIENT_LOCAL_ID
        {
            set { _patient_local_id = value; }
            get { return _patient_local_id; }
        }

        /// <summary>
        /// �����
        /// </summary>
        public string PATH_NO
        {
            set { _path_no = value; }
            get { return _path_no; }
        }

        /// <summary>
        /// �ٴ�����
        /// </summary>
        public string CLIN_DATA
        {
            set { _clin_data = value; }
            get { return _clin_data; }
        }

        /// <summary>
        /// Ӱ��ѧ����
        /// </summary>
        public string DESCRIPTION
        {
            set { _description = value; }
            get { return _description; }
        }

        /// <summary>
        /// ӡ��
        /// </summary>
        public string IMPRESSION
        {
            set { _impression = value; }
            get { return _impression; }
        }

        /// <summary>
        /// ���ҽ��
        /// </summary>
        public string APPROVER
        {
            set { _approver = value; }
            get { return _approver; }
        }

        /// <summary>
        /// ����ҽ��
        /// </summary>
        public string TRANSCRIBER
        {
            set { _transcriber = value; }
            get { return _transcriber; }
        }

        /// <summary>
        /// ������������
        /// </summary>
        public string OPER_DEPT_NAME
        {
            set { _oper_dept_name = value; }
            get { return _oper_dept_name; }
        }

        /// <summary>
        /// ����ҽ��
        /// </summary>
        public string SURGEON
        {
            set { _surgeon = value; }
            get { return _surgeon; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public DateTime? OPER_DATE
        {
            set { _oper_date = value; }
            get { return _oper_date; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string OPER_NAME
        {
            set { _oper_name = value; }
            get { return _oper_name; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string OPER_DESCRIPTION
        {
            set { _oper_description = value; }
            get { return _oper_description; }
        }

        /// <summary>
        /// �������
        /// </summary>
        public string OPER_DIAGNOSIS
        {
            set { _oper_diagnosis = value; }
            get { return _oper_diagnosis; }
        }

        /// <summary>
        /// ����(���)
        /// </summary>
        public string PATH_DIAGNOSIS
        {
            set { _path_diagnosis = value; }
            get { return _path_diagnosis; }
        }

        /// <summary>
        /// ������ҽ��
        /// </summary>
        public string PATH_DIAG_DOCTOR
        {
            set { _path_diag_doctor = value; }
            get { return _path_diag_doctor; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public int? QUALITATIVE
        {
            set { _qualitative = value; }
            get { return _qualitative; }
        }

        /// <summary>
        /// ��λ
        /// </summary>
        public int? PITCH
        {
            set { _pitch = value; }
            get { return _pitch; }
        }

        /// <summary>
        /// ���ҽ��
        /// </summary>
        public string INQU_DOCTOR
        {
            set { _inqu_doctor = value; }
            get { return _inqu_doctor; }
        }

        /// <summary>
        /// �������ʱ��
        /// </summary>
        public DateTime? INQU_DATE_TIME
        {
            set { _inqu_date_time = value; }
            get { return _inqu_date_time; }
        }

        /// <summary>
        /// ��ÿ��Ҵ���
        /// </summary>
        public string INQU_DEPT_CODE
        {
            set { _inqu_dept_code = value; }
            get { return _inqu_dept_code; }
        }
        #endregion Model

    }
}