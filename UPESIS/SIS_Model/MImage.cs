using System;
namespace SIS_Model
{
    /// <summary>
    /// 实体类IMAGE，图像表
    /// </summary>
    [Serializable]
    public class MImage : ILL.IModel
    {
        public MImage()
        { }
        #region Model
        private int? _image_id;             //图像标识
        private string _exam_accession_num; //检查申请号
        private string _image_path;         //图像路径
        private string _image_type;         //图像类型
        private int? _back_id;              //备份标识
        private string _volumn_key;         //卷标Key
        private int? _online_id;            //在线标识
        private string _image_class;        //图像分类
        private string _image_explain;      //图像说明
        private int? _is_print;             //打印标识
        private int? _page_order;           //打印顺序
        private string _mark_inf;           //标注信息
        private DateTime? _image_date;      //图像时间
        private string _mark_image_path;    //标注图像路径

        /// <summary>
        ///图像标识 
        /// </summary>
        public int? IMAGE_ID
        {
            set { _image_id = value; }
            get { return _image_id; }
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
        public string IMAGE_PATH
        {
            set { _image_path = value; }
            get { return _image_path; }
        }

        /// <summary>
        /// 图像类型
        /// </summary>
        public string IMAGE_TYPE
        {
            set { _image_type = value; }
            get { return _image_type; }
        }

        /// <summary>
        /// 备份标识
        /// </summary>
        public int? BACK_ID
        {
            set { _back_id = value; }
            get { return _back_id; }
        }

        /// <summary>
        /// 卷标key
        /// </summary>
        public string VOLUMN_KEY
        {
            set { _volumn_key = value; }
            get { return _volumn_key; }
        }

        /// <summary>
        /// 在线标识
        /// </summary>
        public int? ONLINE_ID
        {
            set { _online_id = value; }
            get { return _online_id; }
        }

        /// <summary>
        /// 图像分类
        /// </summary>
        public string IMAGE_CLASS
        {
            set { _image_class = value; }
            get { return _image_class; }
        }

        /// <summary>
        /// 图像说明
        /// </summary>
        public string IMAGE_EXPLAIN
        {
            set { _image_explain = value; }
            get { return _image_explain; }
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
        public DateTime? IMAGE_DATE
        {
            set { _image_date = value; }
            get { return _image_date; }
        }

        /// <summary>
        /// 标注图像路径
        /// </summary>
        public string MARK_IMAGE_PATH
        {
            set { _mark_image_path = value; }
            get { return _mark_image_path; }
        }
        #endregion Model

    }
}