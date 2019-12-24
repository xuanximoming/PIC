using System;
using System.Collections.Generic;
using System.Text;

namespace SIS_Model
{
    /// <summary>
    /// 实体类KNOWLEDGE_BASE，知识库
    /// </summary>
    [Serializable]
    public class MKnowledgeBase : ILL.IModel
    {
        public MKnowledgeBase()
        {

        }
        #region Model
        private string _visc_name;          //脏器
        private string _desc_name;          //病种
        private string _image_name;         //图像名称
        private byte[] _image_data;         //图像数据
        private int? _index;                //次序
        private string _image_comment;      //图像说明
        private string _clinic_office_code; //科室代码

        /// <summary>
        /// 脏器
        /// </summary>
        public string VISC_NAME
        {
            set { _visc_name = value; }
            get { return _visc_name; }
        }

        /// <summary>
        /// 病种
        /// </summary>
        public string DESC_NAME
        {
            set { _desc_name = value; }
            get { return _desc_name; }
        }

        /// <summary>
        /// 图像名称
        /// </summary>
        public string IMAGE_NAME
        {
            set { _image_name = value; }
            get { return _image_name; }
        }

        /// <summary>
        /// 图像数据
        /// </summary>
        public byte[] IMAGE_DATA
        {
            set { _image_data = value; }
            get { return _image_data; }
        }

        /// <summary>
        /// 图像次序
        /// </summary>
        public int? IMAGE_INDEX
        {
            set { _index = value; }
            get { return _index; }
        }

        /// <summary>
        /// 图像说明
        /// </summary>
        public string IMAGE_COMMENT
        {
            set { _image_comment = value; }
            get { return _image_comment; }
        }

        /// <summary>
        /// 临床科室代码
        /// </summary>
        public string CLINIC_OFFICE_CODE
        {
            set { _clinic_office_code = value; }
            get { return _clinic_office_code; }
        }
        #endregion Model

    }
}