using System;
namespace PACS_Model
{
    /// <summary>
    /// 实体类QUEUE_INFO，打印模板表
    /// </summary>
    [Serializable]
    public class MPrintTemplateDict : ILL.IModel
    {
        public MPrintTemplateDict()
        { }
        #region Model
        private string _exam_class;         //检查类别
        private string _exam_sub_class;     //检查子类
        private byte[] _file_name;          //文件名
        private string _print_template;     //打印模板名称
        private int _print_template_id;     //打印模板ID
        private string _field_inf;          //模板字段信息
        private DateTime _file_date_time;   //文件时间

        /// <summary>
        /// 检查类别
        /// </summary>
        public string EXAM_CLASS
        {
            set { _exam_class = value; }
            get { return _exam_class; }
        }

        /// <summary>
        /// 检查子类
        /// </summary>
        public string EXAM_SUB_CLASS
        {
            set { _exam_sub_class = value; }
            get { return _exam_sub_class; }
        }

        /// <summary>
        /// 文件名
        /// </summary>
        public byte[] FILE_NAME
        {
            set { _file_name = value; }
            get { return _file_name; }
        }

        /// <summary>
        /// 打印模板名
        /// </summary>
        public string PRINT_TEMPLATE
        {
            set { _print_template = value; }
            get { return _print_template; }
        }

        /// <summary>
        /// 打印模板ID
        /// </summary>
        public int PRINT_TEMPLATE_ID
        {
            set { _print_template_id = value; }
            get { return _print_template_id; }
        }

        /// <summary>
        /// 模板字段信息
        /// </summary>
        public string FIELD_INF
        {
            set { _field_inf = value; }
            get { return _field_inf; }
        }

        /// <summary>
        /// 文件日期时间
        /// </summary>
        public DateTime FILE_DATE_TIME
        {
            set { _file_date_time = value; }
            get { return _file_date_time; }
        }
        #endregion Model

    }
}

