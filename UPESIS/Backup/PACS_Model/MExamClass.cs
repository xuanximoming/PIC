using System;
namespace PACS_Model
{
    /// <summary>
    /// ʵ����EXAM_CLASS���������
    /// </summary>
    [Serializable]
    public class MExamClass : ILL.IModel
    {
        public MExamClass()
        { }
        #region Model
        private string _exam_class;             //������
        private string _exam_sub_class;         //�������
        private string _dicom_modality;         //DICOM��׼����
        private string _local_id_class;         //������ID
        private string _print_pattern_class;    //��ӡģ�����
        private string _device;                 //�豸��
        private int? _sort_id;                  //�����

        /// <summary>
        /// ������
        /// </summary>
        public string EXAM_CLASS
        {
            set { _exam_class = value; }
            get { return _exam_class; }
        }

        /// <summary>
        /// �������
        /// </summary>
        public string EXAM_SUB_CLASS
        {
            set { _exam_sub_class = value; }
            get { return _exam_sub_class; }
        }

        /// <summary>
        /// DICOM��׼����
        /// </summary>
        public string DICOM_MODALITY
        {
            set { _dicom_modality = value; }
            get { return _dicom_modality; }
        }

        /// <summary>
        /// ����ID���
        /// </summary>
        public string LOCAL_ID_CLASS
        {
            set { _local_id_class = value; }
            get { return _local_id_class; }
        }

        /// <summary>
        /// ��ӡģ�����
        /// </summary>
        public string PRINT_PATTERN_CLASS
        {
            set { _print_pattern_class = value; }
            get { return _print_pattern_class; }
        }

        /// <summary>
        /// �豸����
        /// </summary>
        public string DEVICE
        {
            set { _device = value; }
            get { return _device; }
        }

        /// <summary>
        /// �����
        /// </summary>
        public int? SORT_ID
        {
            set { _sort_id = value; }
            get { return _sort_id; }
        }
        #endregion Model

    }
}

