using System;
namespace SIS_Model
{
    /// <summary>
    /// 实体类INTEREST_PATIENT，感兴趣病人
    /// </summary>
    [Serializable]
    public class MInterestPatient : ILL.IModel
    {
        public MInterestPatient()
        { }
        #region Model
        private int? _note_id;              //编号
        private string _note_name;          //分类
        private int? _parent_note_id;       //父节点编号
        private int? _is_note;              //记录标志
        private string _doctor_id;          //医生ID号
        private string _patient_id;         //病人ID号
        private string _exam_accession_num; //检查申请号
        private string _memo;               //备注

        /// <summary>
        ///编号 
        /// </summary>
        public int? NOTE_ID
        {
            set { _note_id = value; }
            get { return _note_id; }
        }

        /// <summary>
        /// 分类
        /// </summary>
        public string NOTE_NAME
        {
            set { _note_name = value; }
            get { return _note_name; }
        }

        /// <summary>
        /// 父节点编号
        /// </summary>
        public int? PARENT_NOTE_ID
        {
            set { _parent_note_id = value; }
            get { return _parent_note_id; }
        }

        /// <summary>
        /// 记录标志
        /// </summary>
        public int? IS_NOTE
        {
            set { _is_note = value; }
            get { return _is_note; }
        }

        /// <summary>
        /// 医生ID号
        /// </summary>
        public string DOCTOR_ID
        {
            set { _doctor_id = value; }
            get { return _doctor_id; }
        }

        /// <summary>
        /// 病人ID号
        /// </summary>
        public string PATIENT_ID
        {
            set { _patient_id = value; }
            get { return _patient_id; }
        }

        /// <summary>
        /// 检查申请号
        /// </summary>
        public string EXAM_ACCESSION_NUM
        {
            set { _exam_accession_num = value; }
            get { return _exam_accession_num; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string MEMO
        {
            set { _memo = value; }
            get { return _memo; }
        }
        #endregion Model

    }
}