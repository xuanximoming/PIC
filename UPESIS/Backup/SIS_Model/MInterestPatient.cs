using System;
namespace SIS_Model
{
    /// <summary>
    /// ʵ����INTEREST_PATIENT������Ȥ����
    /// </summary>
    [Serializable]
    public class MInterestPatient : ILL.IModel
    {
        public MInterestPatient()
        { }
        #region Model
        private int? _note_id;              //���
        private string _note_name;          //����
        private int? _parent_note_id;       //���ڵ���
        private int? _is_note;              //��¼��־
        private string _doctor_id;          //ҽ��ID��
        private string _patient_id;         //����ID��
        private string _exam_accession_num; //��������
        private string _memo;               //��ע

        /// <summary>
        ///��� 
        /// </summary>
        public int? NOTE_ID
        {
            set { _note_id = value; }
            get { return _note_id; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string NOTE_NAME
        {
            set { _note_name = value; }
            get { return _note_name; }
        }

        /// <summary>
        /// ���ڵ���
        /// </summary>
        public int? PARENT_NOTE_ID
        {
            set { _parent_note_id = value; }
            get { return _parent_note_id; }
        }

        /// <summary>
        /// ��¼��־
        /// </summary>
        public int? IS_NOTE
        {
            set { _is_note = value; }
            get { return _is_note; }
        }

        /// <summary>
        /// ҽ��ID��
        /// </summary>
        public string DOCTOR_ID
        {
            set { _doctor_id = value; }
            get { return _doctor_id; }
        }

        /// <summary>
        /// ����ID��
        /// </summary>
        public string PATIENT_ID
        {
            set { _patient_id = value; }
            get { return _patient_id; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string EXAM_ACCESSION_NUM
        {
            set { _exam_accession_num = value; }
            get { return _exam_accession_num; }
        }

        /// <summary>
        /// ��ע
        /// </summary>
        public string MEMO
        {
            set { _memo = value; }
            get { return _memo; }
        }
        #endregion Model

    }
}