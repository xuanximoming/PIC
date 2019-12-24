using System;

namespace SIS_Model
{
    /// <summary>
    /// 实体类LOCATION_MAP_INF，定位图像信息表
    /// </summary>
    [Serializable]
    public class MLocationMapInf:ILL.IModel
    {
        public MLocationMapInf()
        {
        }
        #region Model
        private int _location_map_inf_id;   //定位图像信息ID
        private string _map_filename;       //图像名称
        private string _map_part;           //图像部位
        private string _map_explain;        //图像说明

        /// <summary>
        /// 定位图像信息ID
        /// </summary>
        public int LOATION_MAP_INF_ID
        {
            set { _location_map_inf_id = value; }
            get { return _location_map_inf_id; }
        }

        /// <summary>
        /// 图像名称
        /// </summary>
        public string MAP_FILENAME
        {
            set { _map_filename = value; }
            get { return _map_filename; }
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
        #endregion Model
    }
}