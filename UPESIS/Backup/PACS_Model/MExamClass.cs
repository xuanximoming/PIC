using System;
namespace PACS_Model
{
    /// <summary>
    /// 实体类EXAM_CLASS，检查类别表
    /// </summary>
    [Serializable]
    public class MExamClass : ILL.IModel
    {
        public MExamClass()
        { }
        #region Model
        private string _exam_class;             //检查类别
        private string _exam_sub_class;         //检查子类
        private string _dicom_modality;         //DICOM标准名称
        private string _local_id_class;         //检查类别ID
        private string _print_pattern_class;    //打印模板类别
        private string _device;                 //设备名
        private int? _sort_id;                  //排序号

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
        /// DICOM标准名称
        /// </summary>
        public string DICOM_MODALITY
        {
            set { _dicom_modality = value; }
            get { return _dicom_modality; }
        }

        /// <summary>
        /// 本地ID类别
        /// </summary>
        public string LOCAL_ID_CLASS
        {
            set { _local_id_class = value; }
            get { return _local_id_class; }
        }

        /// <summary>
        /// 打印模板类别
        /// </summary>
        public string PRINT_PATTERN_CLASS
        {
            set { _print_pattern_class = value; }
            get { return _print_pattern_class; }
        }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string DEVICE
        {
            set { _device = value; }
            get { return _device; }
        }

        /// <summary>
        /// 排序号
        /// </summary>
        public int? SORT_ID
        {
            set { _sort_id = value; }
            get { return _sort_id; }
        }
        #endregion Model

    }
}

