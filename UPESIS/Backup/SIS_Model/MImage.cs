using System;
namespace SIS_Model
{
    /// <summary>
    /// ʵ����IMAGE��ͼ���
    /// </summary>
    [Serializable]
    public class MImage : ILL.IModel
    {
        public MImage()
        { }
        #region Model
        private int? _image_id;             //ͼ���ʶ
        private string _exam_accession_num; //��������
        private string _image_path;         //ͼ��·��
        private string _image_type;         //ͼ������
        private int? _back_id;              //���ݱ�ʶ
        private string _volumn_key;         //���Key
        private int? _online_id;            //���߱�ʶ
        private string _image_class;        //ͼ�����
        private string _image_explain;      //ͼ��˵��
        private int? _is_print;             //��ӡ��ʶ
        private int? _page_order;           //��ӡ˳��
        private string _mark_inf;           //��ע��Ϣ
        private DateTime? _image_date;      //ͼ��ʱ��
        private string _mark_image_path;    //��עͼ��·��

        /// <summary>
        ///ͼ���ʶ 
        /// </summary>
        public int? IMAGE_ID
        {
            set { _image_id = value; }
            get { return _image_id; }
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
        /// ͼ��·��
        /// </summary>
        public string IMAGE_PATH
        {
            set { _image_path = value; }
            get { return _image_path; }
        }

        /// <summary>
        /// ͼ������
        /// </summary>
        public string IMAGE_TYPE
        {
            set { _image_type = value; }
            get { return _image_type; }
        }

        /// <summary>
        /// ���ݱ�ʶ
        /// </summary>
        public int? BACK_ID
        {
            set { _back_id = value; }
            get { return _back_id; }
        }

        /// <summary>
        /// ���key
        /// </summary>
        public string VOLUMN_KEY
        {
            set { _volumn_key = value; }
            get { return _volumn_key; }
        }

        /// <summary>
        /// ���߱�ʶ
        /// </summary>
        public int? ONLINE_ID
        {
            set { _online_id = value; }
            get { return _online_id; }
        }

        /// <summary>
        /// ͼ�����
        /// </summary>
        public string IMAGE_CLASS
        {
            set { _image_class = value; }
            get { return _image_class; }
        }

        /// <summary>
        /// ͼ��˵��
        /// </summary>
        public string IMAGE_EXPLAIN
        {
            set { _image_explain = value; }
            get { return _image_explain; }
        }

        /// <summary>
        /// ��ӡ��ʶ
        /// </summary>
        public int? IS_PRINT
        {
            set { _is_print = value; }
            get { return _is_print; }
        }

        /// <summary>
        /// ��ӡ˳��
        /// </summary>
        public int? PAGE_ORDER
        {
            set { _page_order = value; }
            get { return _page_order; }
        }

        /// <summary>
        /// ��ע��Ϣ
        /// </summary>
        public string MARK_INF
        {
            set { _mark_inf = value; }
            get { return _mark_inf; }
        }

        /// <summary>
        /// ͼ��ʱ��
        /// </summary>
        public DateTime? IMAGE_DATE
        {
            set { _image_date = value; }
            get { return _image_date; }
        }

        /// <summary>
        /// ��עͼ��·��
        /// </summary>
        public string MARK_IMAGE_PATH
        {
            set { _mark_image_path = value; }
            get { return _mark_image_path; }
        }
        #endregion Model

    }
}