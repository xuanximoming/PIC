using System;

namespace SIS_Model
{
    /// <summary>
    /// ʵ����LOCATION_MAP,��λͼ���
    /// </summary>
    [Serializable]
    public class MLocationMap:ILL.IModel
    {
        public MLocationMap()
        {
        }
        #region Model
        private int? _map_id;               //ͼ���ʶ
        private string _exam_accession_num; //��������
        private string _map_path;           //ͼ��·��
        private string _map_part;           //ͼ��λ
        private string _map_explain;        //ͼ��˵��
        private int? _is_print;             //��ӡ��ʶ
        private int? _page_order;           //��ӡ˳��
        private string _mark_inf;           //��ע��Ϣ
        private DateTime? _map_time;        //��עʱ��
        private string _map_name;           //ͼ������

        /// <summary>
        /// ͼ���ʶ
        /// </summary>
        public int? MAP_ID
        {
            set { _map_id = value; }
            get { return _map_id; }
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
        public string MAP_PATH
        {
            set { _map_path = value; }
            get { return _map_path; }
        }

        /// <summary>
        /// ͼ��λ
        /// </summary>
        public string MAP_PART
        {
            set { _map_part = value; }
            get { return _map_part; }
        }

        /// <summary>
        /// ͼ��˵��
        /// </summary>
        public string MAP_EXPLAIN
        {
            set { _map_explain = value; }
            get { return _map_explain; }
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
        public DateTime? MAP_TIME
        {
            set { _map_time = value; }
            get { return _map_time; }
        }

        /// <summary>
        /// ͼ������
        /// </summary>
        public string MAP_NAME
        {
            set { _map_name = value; }
            get { return _map_name; }
        }
        #endregion Model
    }
}