using System;
namespace PACS_Model
{
    /// <summary>
    /// ʵ����QUEUE_INFO����ӡģ���
    /// </summary>
    [Serializable]
    public class MPrintTemplateDict : ILL.IModel
    {
        public MPrintTemplateDict()
        { }
        #region Model
        private string _exam_class;         //������
        private string _exam_sub_class;     //�������
        private byte[] _file_name;          //�ļ���
        private string _print_template;     //��ӡģ������
        private int _print_template_id;     //��ӡģ��ID
        private string _field_inf;          //ģ���ֶ���Ϣ
        private DateTime _file_date_time;   //�ļ�ʱ��

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
        /// �ļ���
        /// </summary>
        public byte[] FILE_NAME
        {
            set { _file_name = value; }
            get { return _file_name; }
        }

        /// <summary>
        /// ��ӡģ����
        /// </summary>
        public string PRINT_TEMPLATE
        {
            set { _print_template = value; }
            get { return _print_template; }
        }

        /// <summary>
        /// ��ӡģ��ID
        /// </summary>
        public int PRINT_TEMPLATE_ID
        {
            set { _print_template_id = value; }
            get { return _print_template_id; }
        }

        /// <summary>
        /// ģ���ֶ���Ϣ
        /// </summary>
        public string FIELD_INF
        {
            set { _field_inf = value; }
            get { return _field_inf; }
        }

        /// <summary>
        /// �ļ�����ʱ��
        /// </summary>
        public DateTime FILE_DATE_TIME
        {
            set { _file_date_time = value; }
            get { return _file_date_time; }
        }
        #endregion Model

    }
}

