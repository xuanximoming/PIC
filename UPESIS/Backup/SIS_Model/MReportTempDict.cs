using System;
namespace SIS_Model
{
    /// <summary>
    /// ʵ����REPORT_TEMPLATE_DICT������ģ���ֵ�
    /// </summary>
    [Serializable]
    public class MReportTempDict : ILL.IModel
    {
        public MReportTempDict()
        { }
        #region Model
        private int? _node_id;          //���ڵ��ʶ
        private int? _node_parent_id;   //���ڵ��ʶ
        private string _node_name;      //�ڵ�����
        private string _node_depict;    //�ڵ�����
        private string _node_sign;      //�ڵ��־ P�����ڵ㣻N���ӽڵ㣻Y��Ҷ�ڵ㣻1�����������2����������3��������ݣ�4����ע��
        private string _exam_class;     //������
        private string _input_code;     //�������
        private string _doctor_id;      //ҽ��ID
        private int? _is_private;       //˽�б�־ 0��������1��˽��
        private int? _sort_flag;        //�����־
        private string _icd10_code;     //ICD10����������

        /// <summary>
        /// ���ڵ��ʶ
        /// </summary>
        public int? NODE_ID
        {
            set { _node_id = value; }
            get { return _node_id; }
        }

        /// <summary>
        /// ���ڵ��ʶ
        /// </summary>
        public int? NODE_PARENT_ID
        {
            set { _node_parent_id = value; }
            get { return _node_parent_id; }
        }

        /// <summary>
        /// �ڵ�����
        /// </summary>
        public string NODE_NAME
        {
            set { _node_name = value; }
            get { return _node_name; }
        }

        /// <summary>
        /// �ڵ�����
        /// </summary>
        public string NODE_DEPICT
        {
            set { _node_depict = value; }
            get { return _node_depict; }
        }

        /// <summary>
        /// �ڵ��־
        /// </summary>
        public string NODE_SIGN
        {
            set { _node_sign = value; }
            get { return _node_sign; }
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
        public string INPUT_CODE
        {
            set { _input_code = value; }
            get { return _input_code; }
        }

        /// <summary>
        /// ҽ��ID
        /// </summary>
        public string DOCTOR_ID
        {
            set { _doctor_id = value; }
            get { return _doctor_id; }
        }

        /// <summary>
        /// ˽�б�ʶ
        /// </summary>
        public int? IS_PRIVATE
        {
            set { _is_private = value; }
            get { return _is_private; }
        }

        /// <summary>
        /// �����
        /// </summary>
        public int? SORT_FLAG
        {
            set { _sort_flag = value; }
            get { return _sort_flag; }
        }

        /// <summary>
        /// ICD10����������
        /// </summary>
        public string ICD10_CODE
        {
            set { _icd10_code = value; }
            get { return _icd10_code; }
        }
        #endregion Model

    }
}