using System;
namespace SIS_Model
{
    /// <summary>
    /// ʵ����REPORT�����˱����
    /// </summary>
    [Serializable]
    public class MReport : ILL.IModel
    {
        public MReport()
        { }
        #region Model
        private string _exam_no;                //��������
        private string _exam_para;              //������
        private string _description;            //�������
        private string _impression;             //����������ӡ��
        private string _recommendation;         //���
        private string _dictator;               //������
        private string _transcriber;            //��¼��
        private string _approver;               //������
        private DateTime? _approve_date_time;   //����ȷ��ʱ��
        private DateTime? _report_date_time;    //����ʱ��
        private string _affirmant;              //�����ύ��
        private DateTime? _affirm_date_time;    //�ύʱ��
        private int? _is_abnormal;              //������ 0������  1������
        private int? _report_type;              //�������� 0���������棻1���ύ�����;2:��˱���;3:���ᱨ��
        private string _print_template;         //��ӡģ������
        private int? _print_count;              //��ӡ����������ӡ��ʶ  ��ֵ��δ��ӡ   1���Ѵ�ӡ
        private byte[] _report_name;            //��������
        private string _field_inf;              //ģ���ֶ���Ϣ

        /// <summary>
        /// ��������
        /// </summary>
        public string EXAM_NO
        {
            set { _exam_no = value; }
            get { return _exam_no; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public string EXAM_PARA
        {
            set { _exam_para = value; }
            get { return _exam_para; }
        }

        /// <summary>
        /// �������
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
        /// ���
        /// </summary>
        public string RECOMMENDATION
        {
            set { _recommendation = value; }
            get { return _recommendation; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public string DICTATOR
        {
            set { _dictator = value; }
            get { return _dictator; }
        }

        /// <summary>
        /// ��¼��
        /// </summary>
        public string TRANSCRIBER
        {
            set { _transcriber = value; }
            get { return _transcriber; }
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
        /// ����ȷ��ʱ��
        /// </summary>
        public DateTime? APPROVE_DATE_TIME
        {
            set { _approve_date_time = value; }
            get { return _approve_date_time; }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? REPORT_DATE_TIME
        {
            set { _report_date_time = value; }
            get { return _report_date_time; }
        }

        /// <summary>
        /// �����ύ��
        /// </summary>
        public string AFFIRMANT
        {
            set { _affirmant = value; }
            get { return _affirmant; }
        }

        /// <summary>
        /// �����ύʱ��
        /// </summary>
        public DateTime? AFFIRM_DATE_TIME
        {
            set { _affirm_date_time = value; }
            get { return _affirm_date_time; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public int? IS_ABNORMAL
        {
            set { _is_abnormal = value; }
            get { return _is_abnormal; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public int? REPORT_TYPE
        {
            set { _report_type = value; }
            get { return _report_type; }
        }

        /// <summary>
        /// ��ӡģ������
        /// </summary>
        public string PRINT_TEMPLATE
        {
            set { _print_template = value; }
            get { return _print_template; }
        }

        /// <summary>
        /// ��ӡ����
        /// </summary>
        public int? PRINT_COUNT
        {
            set { _print_count = value; }
            get { return _print_count; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public byte[] REPORT_NAME
        {
            set { _report_name = value; }
            get { return _report_name; }
        }

        /// <summary>
        /// ģ���ֶ���Ϣ
        /// </summary>
        public string FIELD_INF
        {
            set { _field_inf = value; }
            get { return _field_inf; }
        }
        #endregion Model
        #region Model
        //private string _exam_accession_num;
        private string _a1;
        private int? _a2;
        private int? _a3;
        private int? _a4;
        private string _a5;
        private string _a6;
        /// <summary>
        /// 
        /// </summary>
        //public string EXAM_ACCESSION_NUM
        //{
        //	set{ _exam_accession_num=value;}
        //	get{return _exam_accession_num;}
        //}
        /// <summary>
        /// 
        /// </summary>
        public string A1
        {
            set { _a1 = value; }
            get { return _a1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? A2
        {
            set { _a2 = value; }
            get { return _a2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? A3
        {
            set { _a3 = value; }
            get { return _a3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? A4
        {
            set { _a4 = value; }
            get { return _a4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string A5
        {
            set { _a5 = value; }
            get { return _a5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string A6
        {
            set { _a6 = value; }
            get { return _a6; }
        }
        #endregion Model
    }
}

