using System;
namespace SIS_Model
{
    /// <summary>
    /// 实体类CLINC_OFFICE_DICT，临床科室表
    /// </summary>
    [Serializable]
    public class MClinicOfficeDict : ILL.IModel
    {
        public MClinicOfficeDict()
        { }
        #region Model
        private int? _clinic_office_id;         //临床科室ID
        private string _clinic_office;          //临床科室名称
        private int? _patient_source_id;        //病人来源ID 0：门诊 1：住院
        private string _clinic_office_code;     //临床科室代码
        private string _clinic_office_flag;     //临床科室标志 CD:申请科室 RY：检查科室
        private int? _cur_serial_num;           //当日流水号
        private string _study_uid_header;       //检查UID头
        private string _clinic_office_pycode;   //临床科室名称简码

        /// <summary>
        ///临床科室ID 
        /// </summary>
        public int? CLINIC_OFFICE_ID
        {
            set { _clinic_office_id = value; }
            get { return _clinic_office_id; }
        }

        /// <summary>
        /// 临床科室名称
        /// </summary>
        public string CLINIC_OFFICE
        {
            set { _clinic_office = value; }
            get { return _clinic_office; }
        }

        /// <summary>
        /// 病人来源ID
        /// </summary>
        public int? PATIENT_SOURCE_ID
        {
            set { _patient_source_id = value; }
            get { return _patient_source_id; }
        }

        /// <summary>
        /// 临床科室代码
        /// </summary>
        public string CLINIC_OFFICE_CODE
        {
            set { _clinic_office_code = value; }
            get { return _clinic_office_code; }
        }

        /// <summary>
        /// 临床科室标志
        /// </summary>
        public string CLINIC_OFFICE_FLAG
        {
            set { _clinic_office_flag = value; }
            get { return _clinic_office_flag; }
        }

        /// <summary>
        /// 当日流水号
        /// </summary>
        public int? CUR_SERIAL_NUM
        {
            set { _cur_serial_num = value; }
            get { return _cur_serial_num; }
        }

        /// <summary>
        /// 检查UID头
        /// </summary>
        public string STUDY_UID_HEADER
        {
            set { _study_uid_header = value; }
            get { return _study_uid_header; }
        }

        /// <summary>
        /// 临床科室拼音简码
        /// </summary>
        public string CLINIC_OFFICE_PYCODE
        {
            set { _clinic_office_pycode = value; }
            get { return _clinic_office_pycode; }
        }
        #endregion Model

    }
}