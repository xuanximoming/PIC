using System;
namespace PACS_Model
{
    /// <summary>
    /// ʵ����EXAM_ITEM_DICT�������Ŀ�ֵ�
    /// </summary>
    [Serializable]
    public class MExamItemDict : ILL.IModel
    {
        public MExamItemDict()
        { }
        #region Model
        private string _exam_item_code; //�����Ŀ����
        private string _exam_item_name; //�����Ŀ����
        private string _input_code;     //�������
        private string _exam_class;     //������
        private string _exam_sub_class; //�������
        private int? _sort_id;          //�����

        /// <summary>
        ///�����Ŀ���� 
        /// </summary>
        public string EXAM_ITEM_CODE
        {
            set { _exam_item_code = value; }
            get { return _exam_item_code; }
        }

        /// <summary>
        ///�����Ŀ���� 
        /// </summary>
        public string EXAM_ITEM_NAME
        {
            set { _exam_item_name = value; }
            get { return _exam_item_name; }
        }

        /// <summary>
        /// �������
        /// </summary>
        public string INPUT_CODE
        {
            set { _input_code = value; }
            get { return _input_code; }
        }

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