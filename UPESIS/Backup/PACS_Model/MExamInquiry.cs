using System;

namespace PACS_Model
{
    /// <summary>
    /// 实体类--EXAM_INQUIRY，检查随访记录表
    /// </summary>
    [Serializable]
    public class MExamInquiry:ILL.IModel
    {
        public MExamInquiry()
        {
        }
        #region Model
        private string _exam_accession_num; //检查申请号
        private string _patient_id;         //病人ID
        private string _patient_name;       //病人姓名
        private string _patient_sex;        //性别
        private int? _patient_age;          //年龄
        private string _patient_age_unit;   //单位
        private string _inp_no;             //住院号
        private int? _visit_id;             //检查序数
        private int? _oper_id;              //本次手术标识
        private string _req_dept_name;      //申请科室名
        private string _exam_dept_name;     //检查科室名
        private string _exam_class;         //检查类别
        private string _exam_sub_class;     //检查子类
        private string _patient_local_id;   //病人本地ID
        private string _path_no;            //病理号
        private string _clin_data;          //临床资料
        private string _description;        //影像学表现
        private string _impression;         //印象
        private string _approver;           //审核医生
        private string _transcriber;        //报告医生
        private string _oper_dept_name;     //手术科室名
        private string _surgeon;            //手术者
        private DateTime? _oper_date;       //手术时间
        private string _oper_name;          //手术名称
        private string _oper_description;   //手术所见
        private string _oper_diagnosis;     //手术诊断
        private string _path_diagnosis;     //病理（活检）
        private string _path_diag_doctor;   //病理报告医生
        private int? _qualitative;          //定性
        private int? _pitch;                //定位
        private string _inqu_doctor;        //随访者
        private DateTime? _inqu_date_time;  //随访日期时间
        private string _inqu_dept_code;     //随访科室代码

        /// <summary>
        /// 检查申请号
        /// </summary>
        public string EXAM_ACCESSION_NUM
        {
            set { _exam_accession_num = value; }
            get { return _exam_accession_num; }
        }

        /// <summary>
        /// 病人ID
        /// </summary>
        public string PATIENT_ID
        {
            set { _patient_id = value; }
            get { return _patient_id; }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string PATIENT_NAME
        {
            set { _patient_name = value; }
            get { return _patient_name; }
        }

        /// <summary>
        /// 性别
        /// </summary>
        public string PATIENT_SEX
        {
            set { _patient_sex = value; }
            get { return _patient_sex; }
        }

        /// <summary>
        /// 年龄
        /// </summary>
        public int? PATIENT_AGE
        {
            set { _patient_age = value; }
            get { return _patient_age; }
        }

        /// <summary>
        /// 年龄单位
        /// </summary>
        public string PATIENT_AGE_UNIT
        {
            set { _patient_age_unit = value; }
            get { return _patient_age_unit; }
        }

        /// <summary>
        /// 住院号
        /// </summary>
        public string INP_NO
        {
            set { _inp_no = value; }
            get { return _inp_no; }
        }

        /// <summary>
        /// 本次住院标识
        /// </summary>
        public int? VISIT_ID
        {
            set { _visit_id = value; }
            get { return _visit_id; }
        }

        /// <summary>
        /// 本次手术标识
        /// </summary>
        public int? OPER_ID
        {
            set { _oper_id = value; }
            get { return _oper_id; }
        }

        /// <summary>
        /// 申请科室名称
        /// </summary>
        public string REQ_DEPT_NAME
        {
            set { _req_dept_name = value; }
            get { return _req_dept_name; }
        }

        /// <summary>
        /// 检查科室名称
        /// </summary>
        public string EXAM_DEPT_NAME
        {
            set { _exam_dept_name = value; }
            get { return _exam_dept_name; }
        }

        /// <summary>
        /// 检查类别
        /// </summary>
        public string EXAM_CLASS
        {
            set { _exam_class = value; }
            get { return _exam_class; }
        }

        /// <summary>
        /// 检查子类
        /// </summary>
        public string EXAM_SUB_CLASS
        {
            set { _exam_sub_class = value; }
            get { return _exam_sub_class; }
        }

        /// <summary>
        /// 病人本地ID
        /// </summary>
        public string PATIENT_LOCAL_ID
        {
            set { _patient_local_id = value; }
            get { return _patient_local_id; }
        }

        /// <summary>
        /// 病理号
        /// </summary>
        public string PATH_NO
        {
            set { _path_no = value; }
            get { return _path_no; }
        }

        /// <summary>
        /// 临床资料
        /// </summary>
        public string CLIN_DATA
        {
            set { _clin_data = value; }
            get { return _clin_data; }
        }

        /// <summary>
        /// 影像学表现
        /// </summary>
        public string DESCRIPTION
        {
            set { _description = value; }
            get { return _description; }
        }

        /// <summary>
        /// 印象
        /// </summary>
        public string IMPRESSION
        {
            set { _impression = value; }
            get { return _impression; }
        }

        /// <summary>
        /// 审核医生
        /// </summary>
        public string APPROVER
        {
            set { _approver = value; }
            get { return _approver; }
        }

        /// <summary>
        /// 报告者
        /// </summary>
        public string TRANSCRIBER
        {
            set { _transcriber = value; }
            get { return _transcriber; }
        }

        /// <summary>
        /// 手术科室名称
        /// </summary>
        public string OPER_DEPT_NAME
        {
            set { _oper_dept_name = value; }
            get { return _oper_dept_name; }
        }

        /// <summary>
        /// 手术医生
        /// </summary>
        public string SURGEON
        {
            set { _surgeon = value; }
            get { return _surgeon; }
        }

        /// <summary>
        /// 手术时间
        /// </summary>
        public DateTime? OPER_DATE
        {
            set { _oper_date = value; }
            get { return _oper_date; }
        }

        /// <summary>
        /// 手术名称
        /// </summary>
        public string OPER_NAME
        {
            set { _oper_name = value; }
            get { return _oper_name; }
        }

        /// <summary>
        /// 手术所见
        /// </summary>
        public string OPER_DESCRIPTION
        {
            set { _oper_description = value; }
            get { return _oper_description; }
        }

        /// <summary>
        /// 手术诊断
        /// </summary>
        public string OPER_DIAGNOSIS
        {
            set { _oper_diagnosis = value; }
            get { return _oper_diagnosis; }
        }

        /// <summary>
        /// 病理（活检）
        /// </summary>
        public string PATH_DIAGNOSIS
        {
            set { _path_diagnosis = value; }
            get { return _path_diagnosis; }
        }

        /// <summary>
        /// 病理报告医生
        /// </summary>
        public string PATH_DIAG_DOCTOR
        {
            set { _path_diag_doctor = value; }
            get { return _path_diag_doctor; }
        }

        /// <summary>
        /// 定性
        /// </summary>
        public int? QUALITATIVE
        {
            set { _qualitative = value; }
            get { return _qualitative; }
        }

        /// <summary>
        /// 定位
        /// </summary>
        public int? PITCH
        {
            set { _pitch = value; }
            get { return _pitch; }
        }

        /// <summary>
        /// 随访者
        /// </summary>
        public string INQU_DOCTOR
        {
            set { _inqu_doctor = value; }
            get { return _inqu_doctor; }
        }

        /// <summary>
        /// 随访日期时间
        /// </summary>
        public DateTime? INQU_DATE_TIME
        {
            set { _inqu_date_time = value; }
            get { return _inqu_date_time; }
        }

        /// <summary>
        /// 随访科室代码
        /// </summary>
        public string INQU_DEPT_CODE
        {
            set { _inqu_dept_code = value; }
            get { return _inqu_dept_code; }
        }

        #endregion Model
    }
}
