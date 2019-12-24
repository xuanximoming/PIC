using System;
using System.Collections.Generic;
using System.Text;

namespace SIS_Model
{
    /// <summary>
    /// ʵ����KNOWLEDGE_BASE��֪ʶ��
    /// </summary>
    [Serializable]
    public class MKnowledgeBase : ILL.IModel
    {
        public MKnowledgeBase()
        {

        }
        #region Model
        private string _visc_name;          //����
        private string _desc_name;          //����
        private string _image_name;         //ͼ������
        private byte[] _image_data;         //ͼ������
        private int? _index;                //����
        private string _image_comment;      //ͼ��˵��
        private string _clinic_office_code; //���Ҵ���

        /// <summary>
        /// ����
        /// </summary>
        public string VISC_NAME
        {
            set { _visc_name = value; }
            get { return _visc_name; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string DESC_NAME
        {
            set { _desc_name = value; }
            get { return _desc_name; }
        }

        /// <summary>
        /// ͼ������
        /// </summary>
        public string IMAGE_NAME
        {
            set { _image_name = value; }
            get { return _image_name; }
        }

        /// <summary>
        /// ͼ������
        /// </summary>
        public byte[] IMAGE_DATA
        {
            set { _image_data = value; }
            get { return _image_data; }
        }

        /// <summary>
        /// ͼ�����
        /// </summary>
        public int? IMAGE_INDEX
        {
            set { _index = value; }
            get { return _index; }
        }

        /// <summary>
        /// ͼ��˵��
        /// </summary>
        public string IMAGE_COMMENT
        {
            set { _image_comment = value; }
            get { return _image_comment; }
        }

        /// <summary>
        /// �ٴ����Ҵ���
        /// </summary>
        public string CLINIC_OFFICE_CODE
        {
            set { _clinic_office_code = value; }
            get { return _clinic_office_code; }
        }
        #endregion Model

    }
}