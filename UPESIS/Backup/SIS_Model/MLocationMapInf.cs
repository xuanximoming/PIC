using System;

namespace SIS_Model
{
    /// <summary>
    /// ʵ����LOCATION_MAP_INF����λͼ����Ϣ��
    /// </summary>
    [Serializable]
    public class MLocationMapInf:ILL.IModel
    {
        public MLocationMapInf()
        {
        }
        #region Model
        private int _location_map_inf_id;   //��λͼ����ϢID
        private string _map_filename;       //ͼ������
        private string _map_part;           //ͼ��λ
        private string _map_explain;        //ͼ��˵��

        /// <summary>
        /// ��λͼ����ϢID
        /// </summary>
        public int LOATION_MAP_INF_ID
        {
            set { _location_map_inf_id = value; }
            get { return _location_map_inf_id; }
        }

        /// <summary>
        /// ͼ������
        /// </summary>
        public string MAP_FILENAME
        {
            set { _map_filename = value; }
            get { return _map_filename; }
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
        #endregion Model
    }
}