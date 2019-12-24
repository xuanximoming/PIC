using System;
using System.Collections.Generic;
using System.Text;

namespace PACS_Model
{
    /// <summary>
    /// 实体类--REQ_SCAN_IMAGE，申请单图像
    /// </summary>
    public class MReqScanImage:ILL.IModel
    {
        public MReqScanImage()
        {
        }
        #region Model                       
        private string _exam_accession_num; //检查申请号
        private int? _image_index;          //图像索引顺序号
        private byte[] _image_file;         //文件名及路径
        private string _operator;           //操作员

        /// <summary>
        /// 检查申请号
        /// </summary>
        public string EXAM_ACCESSION_NUM
        {
            set { _exam_accession_num = value; }
            get { return _exam_accession_num; }
        }

        /// <summary>
        /// 多个检查单顺序号
        /// </summary>
        public int? IMAGE_INDEX
        {
            set { _image_index = value; }
            get { return _image_index; }
        }

        /// <summary>
        /// 文件名及路径
        /// </summary>
        public byte[] IMAGE_FILE
        {
            set { _image_file = value; }
            get { return _image_file; }
        }

        /// <summary>
        /// 操作员
        /// </summary>
        public string OPERATOR
        {
            set { _operator = value; }
            get { return _operator; }
        }
        #endregion Model
    }
}
