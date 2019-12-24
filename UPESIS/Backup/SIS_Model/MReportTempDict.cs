using System;
namespace SIS_Model
{
    /// <summary>
    /// 实体类REPORT_TEMPLATE_DICT，报告模板字典
    /// </summary>
    [Serializable]
    public class MReportTempDict : ILL.IModel
    {
        public MReportTempDict()
        { }
        #region Model
        private int? _node_id;          //本节点标识
        private int? _node_parent_id;   //父节点标识
        private string _node_name;      //节点名称
        private string _node_depict;    //节点描述
        private string _node_sign;      //节点标志 P：根节点；N：子节点；Y：叶节点；1：检查所见；2：诊断意见；3：检查内容；4：附注；
        private string _exam_class;     //检查类别
        private string _input_code;     //输入简码
        private string _doctor_id;      //医生ID
        private int? _is_private;       //私有标志 0：公共；1：私有
        private int? _sort_flag;        //排序标志
        private string _icd10_code;     //ICD10疾病分类码

        /// <summary>
        /// 本节点标识
        /// </summary>
        public int? NODE_ID
        {
            set { _node_id = value; }
            get { return _node_id; }
        }

        /// <summary>
        /// 父节点标识
        /// </summary>
        public int? NODE_PARENT_ID
        {
            set { _node_parent_id = value; }
            get { return _node_parent_id; }
        }

        /// <summary>
        /// 节点名称
        /// </summary>
        public string NODE_NAME
        {
            set { _node_name = value; }
            get { return _node_name; }
        }

        /// <summary>
        /// 节点描述
        /// </summary>
        public string NODE_DEPICT
        {
            set { _node_depict = value; }
            get { return _node_depict; }
        }

        /// <summary>
        /// 节点标志
        /// </summary>
        public string NODE_SIGN
        {
            set { _node_sign = value; }
            get { return _node_sign; }
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
        /// 输入简码
        /// </summary>
        public string INPUT_CODE
        {
            set { _input_code = value; }
            get { return _input_code; }
        }

        /// <summary>
        /// 医生ID
        /// </summary>
        public string DOCTOR_ID
        {
            set { _doctor_id = value; }
            get { return _doctor_id; }
        }

        /// <summary>
        /// 私有标识
        /// </summary>
        public int? IS_PRIVATE
        {
            set { _is_private = value; }
            get { return _is_private; }
        }

        /// <summary>
        /// 排序号
        /// </summary>
        public int? SORT_FLAG
        {
            set { _sort_flag = value; }
            get { return _sort_flag; }
        }

        /// <summary>
        /// ICD10疾病分类码
        /// </summary>
        public string ICD10_CODE
        {
            set { _icd10_code = value; }
            get { return _icd10_code; }
        }
        #endregion Model

    }
}