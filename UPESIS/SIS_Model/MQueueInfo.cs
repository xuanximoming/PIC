using System;
namespace SIS_Model
{
    /// <summary>
    /// ʵ����QUEUE_INFO��������Ϣ
    /// </summary>
    [Serializable]
    public class MQueueInfo : ILL.IModel
    {
        public MQueueInfo()
        { }
        #region Model
        private string _exam_accession_num; //��������
        private string _patient_id;         //����ID
        private string _patient_name;       //����
        private string _patient_sex;        //�Ա�
        private string _clinic_lable;       //����ű�
        private string _doctor;             //ҽ������
        private int? _serial_no;            //��ˮ��
        private DateTime? _visit_date;      //�Һ�����
        private int? _diag_flag;            //�����־ 0��δ��飻1���Ѽ�飻9����ɾ��
        private string _visit_dept;         //�����������
        private decimal? _order_no;         //�������
        private int? _visit_no;             //�����
        private DateTime? _reg_date;        //�Ǽ�����
        private string _is_rediag;          //�����ʶ Ĭ��Ϊ0
        private string _queue_name;         //�������ƣ���Ӧ��������
        private int? _print_no;             //��ӡ��
        private int? _passed;               //�����־ Ĭ��Ϊ0.�ñ�ʶ0-����;1-����;2-����

        /// <summary>
        /// ��������
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
        /// ����ű�
        /// </summary>
        public string CLINIC_LABLE
        {
            set { _clinic_lable = value; }
            get { return _clinic_lable; }
        }

        /// <summary>
        /// ҽ������
        /// </summary>
        public string DOCTOR
        {
            set { _doctor = value; }
            get { return _doctor; }
        }

        /// <summary>
        /// ��ˮ��
        /// </summary>
        public int? SERIAL_NO
        {
            set { _serial_no = value; }
            get { return _serial_no; }
        }

        /// <summary>
        /// �Һ�����
        /// </summary>
        public DateTime? VISIT_DATE
        {
            set { _visit_date = value; }
            get { return _visit_date; }
        }

        /// <summary>
        /// �����־
        /// </summary>
        public int? DIAG_FLAG
        {
            set { _diag_flag = value; }
            get { return _diag_flag; }
        }

        /// <summary>
        /// �������
        /// </summary>
        public string VISIT_DEPT
        {
            set { _visit_dept = value; }
            get { return _visit_dept; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ORDER_NO
        {
            set { _order_no = value; }
            get { return _order_no; }
        }

        /// <summary>
        /// �����
        /// </summary>
        public int? VISIT_NO
        {
            set { _visit_no = value; }
            get { return _visit_no; }
        }

        /// <summary>
        /// �Ǽ�����
        /// </summary>
        public DateTime? REG_DATE
        {
            set { _reg_date = value; }
            get { return _reg_date; }
        }

        /// <summary>
        /// �����ʶ
        /// </summary>
        public string IS_REDIAG
        {
            set { _is_rediag = value; }
            get { return _is_rediag; }
        }

        /// <summary>
        /// �������ƣ�������
        /// </summary>
        public string QUEUE_NAME
        {
            set { _queue_name = value; }
            get { return _queue_name; }
        }

        /// <summary>
        /// ��ӡ��
        /// </summary>
        public int? PRINT_NO
        {
            set { _print_no = value; }
            get { return _print_no; }
        }

        /// <summary>
        /// �����ʶ
        /// </summary>
        public int? PASSED
        {
            set { _passed = value; }
            get { return _passed; }
        }
        #endregion Model

    }
}