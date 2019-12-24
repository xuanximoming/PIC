using System;

namespace SIS_Model
{
    /// <summary>
    /// 实体类LOCATION_MAP,定位图像表
    /// </summary>
    [Serializable]
    public class MLocationMap:ILL.IModel
    {
        public MLocationMap()
        {
        }
        #region Model
        private int? _map_id;               //图像标识
        private string _exam_accession_num; //检查申请号
        private string _map_path;           //图像路径
        private string _map_part;           //图像部位
        private string _map_explain;        //图像说明
        private int? _is_print;             //打印标识
        private int? _page_order;           //打印顺序
        private string _mark_inf;           //标注信息
        private DateTime? _map_time;        //标注时间
        private string _map_name;           //图像名称

        /// <summary>
        /// 图像标识
        /// </summary>
        public int? MAP_ID
        {
            set { _map_id = value; }
            get { return _map_id; }
        }

        /// <summary>
        /// 检查申请号
        /// </summary>
        public string EXAM_ACCESSION_NUM
        {
            set { _exam_accession_num = value; }
            get { return _exam_accession_num; }
        }

        /// <summary>
        /// 图像路径
        /// </summary>
        public string MAP_PATH
        {
            set { _map_path = value; }
            get { return _map_path; }
        }

        /// <summary>
        /// 图像部位
        /// </summary>
        public string MAP_PART
        {
            set { _map_part = value; }
            get { return _map_part; }
        }

        /// <summary>
        /// 图像说明
        /// </summary>
        public string MAP_EXPLAIN
        {
            set { _map_explain = value; }
            get { return _map_explain; }
        }

        /// <summary>
        /// 打印标识
        /// </summary>
        public int? IS_PRINT
        {
            set { _is_print = value; }
            get { return _is_print; }
        }

        /// <summary>
        /// 打印顺序
        /// </summary>
        public int? PAGE_ORDER
        {
            set { _page_order = value; }
            get { return _page_order; }
        }

        /// <summary>
        /// 标注信息
        /// </summary>
        public string MARK_INF
        {
            set { _mark_inf = value; }
            get { return _mark_inf; }
        }

        /// <summary>
        /// 图像时间
        /// </summary>
        public DateTime? MAP_TIME
        {
            set { _map_time = value; }
            get { return _map_time; }
        }

        /// <summary>
        /// 图像名称
        /// </summary>
        public string MAP_NAME
        {
            set { _map_name = value; }
            get { return _map_name; }
        }
        #endregion Model
    }
}