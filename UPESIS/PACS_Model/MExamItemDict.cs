using System;
namespace PACS_Model
{
    /// <summary>
    /// 实体类EXAM_ITEM_DICT，检查项目字典
    /// </summary>
    [Serializable]
    public class MExamItemDict : ILL.IModel
    {
        public MExamItemDict()
        { }
        #region Model
        private string _exam_item_code; //检查项目代码
        private string _exam_item_name; //检查项目名称
        private string _input_code;     //输入简码
        private string _exam_class;     //检查类别
        private string _exam_sub_class; //检查子类
        private int? _sort_id;          //排序号

        /// <summary>
        ///检查项目代码 
        /// </summary>
        public string EXAM_ITEM_CODE
        {
            set { _exam_item_code = value; }
            get { return _exam_item_code; }
        }

        /// <summary>
        ///检查项目名称 
        /// </summary>
        public string EXAM_ITEM_NAME
        {
            set { _exam_item_name = value; }
            get { return _exam_item_name; }
        }

        /// <summary>
        /// 输入简码
        /// </summary>
        public string INPUT_CODE
        {
            set { _input_code = value; }
            get { return _input_code; }
        }

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