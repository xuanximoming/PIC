using System;
namespace SIS_Model
{
    /// <summary>
    /// ʵ����REPORT_TRACK_INF������켣��Ϣ
    /// </summary>
    [Serializable]
    public class MReportTrackInf : ILL.IModel
    {
        public MReportTrackInf()
        { }
        #region Model
        private string _exam_accession_num;     //��������
        private DateTime? _report_modify_time;  //�޸�ʱ��
        private string _exam_para;              //������
        private string _description;            //�������
        private string _impression;             //ӡ��
        private string _recommendation;         //����
        private string _dictator;               //������
        private string _transcriber;            //��¼��
        private string _approver;               //������
        private string _affirmant;              //ȷ����
        private string _operator;               //������
        private int? _is_abnormal;              //������
        private int? _report_type;              //�������� 0���������棻1��ȷ�ϱ���

        /// <summary>
        /// ��������
        /// </summary>
        public string EXAM_ACCESSION_NUM
        {
            set { _exam_accession_num = value; }
            get { return _exam_accession_num; }
        }

        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        public DateTime? REPORT_MODIFY_TIME
        {
            set { _report_modify_time = value; }
            get { return _report_modify_time; }
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
        /// ����
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
        /// ȷ����
        /// </summary>
        public string AFFIRMANT
        {
            set { _affirmant = value; }
            get { return _affirmant; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public string OPERATOR
        {
            set { _operator = value; }
            get { return _operator; }
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
        #endregion Model

    }
}