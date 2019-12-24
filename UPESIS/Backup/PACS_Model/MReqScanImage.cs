using System;
using System.Collections.Generic;
using System.Text;

namespace PACS_Model
{
    /// <summary>
    /// ʵ����--REQ_SCAN_IMAGE�����뵥ͼ��
    /// </summary>
    public class MReqScanImage:ILL.IModel
    {
        public MReqScanImage()
        {
        }
        #region Model                       
        private string _exam_accession_num; //��������
        private int? _image_index;          //ͼ������˳���
        private byte[] _image_file;         //�ļ�����·��
        private string _operator;           //����Ա

        /// <summary>
        /// ��������
        /// </summary>
        public string EXAM_ACCESSION_NUM
        {
            set { _exam_accession_num = value; }
            get { return _exam_accession_num; }
        }

        /// <summary>
        /// �����鵥˳���
        /// </summary>
        public int? IMAGE_INDEX
        {
            set { _image_index = value; }
            get { return _image_index; }
        }

        /// <summary>
        /// �ļ�����·��
        /// </summary>
        public byte[] IMAGE_FILE
        {
            set { _image_file = value; }
            get { return _image_file; }
        }

        /// <summary>
        /// ����Ա
        /// </summary>
        public string OPERATOR
        {
            set { _operator = value; }
            get { return _operator; }
        }
        #endregion Model
    }
}
