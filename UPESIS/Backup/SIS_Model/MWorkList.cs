using System;
namespace SIS_Model
{
    /// <summary>
    /// 实体类WORKLIST，工作列表
    /// </summary>
    [Serializable]
    public class MWorkList : ILL.IModel
    {
        public MWorkList()
        { }
        #region Model
        private string _exam_accession_num;     //检查申请号
        private int? _accession_no;             //检查流水号
        private string _patient_id;             //病人ID
        private string _patient_name;           //姓名
        private string _patient_phonetic;       //姓名拼音
        private string _patient_sex;            //性别
        private DateTime? _patient_birth;       //出生日期
        private int? _patient_age;              //年龄
        private string _patient_age_unit;       //年龄单位
        private string _patient_identity;       //身份
        private string _patient_local_id;       //本地ID
        private string _local_id_class;         //本地ID类别
        private string _inp_no;                 //住院号
        private string _bed_num;                //床号
        private string _opd_no;                 //门诊号
        private string _birth_place;            //出生地
        private int? _charge_type;              //收费类别
        private string _mailing_address;        //通信地址
        private string _zip_code;               //邮政编码
        private string _telephone_num;          //电话号码
        private string _patient_source;         //病人来源
        private string _exam_class;             //检查类别
        private string _exam_sub_class;         //检查子类
        private string _exam_items;             //检查项目
        private string _exam_dept;              //检查科室代码
        private string _exam_dept_name;         //检查科室名称
        private string _exam_mode;              //检查方式
        private string _exam_group;             //检查诊室名称
        private string _exam_doctor;            //检查医生姓名
        private string _exam_no;                //检查顺序号
        private int? _exam_index;               //检查累计
        private decimal? _exam_intradayseq_no;  //当天流水号
        private string _study_instance_uid;     //检查实例UID
        private string _study_path;             //检查图像目录路径
        private string _report_doctor;          //报告医生
        private string _device;                 //设备名
        private DateTime? _study_date_time;     //检查日期时间
        private int? _exam_step_status;         //检查完成标志
        private int? _report_status;            //报告状态
        private int? _is_confirmed;             //收费确认标志 0.未确认1.已确认收费2.表示退费默认为0
        private int? _match_status;             //匹配标志
        private int? _is_temporary;             //绿色通道标志
        private int? _vip_indicator;            //VIP标志
        private int? _image_archived;           //入库标志
        private int? _pre_fetch;                //预取状态标志
        private int? _dispatch_status;          //分发标志
        private int? _query_status;             //轮询状态
        private DateTime? _query_time;          //轮询时间
        private int? _patient_class;            //入院方式
        private int? _image_counts;             //图像总数
        private DateTime? _scheduled_date;      //预约时间
        private string _sch_operator;           //登记员
        private string _refer_doctor;           //申请医生
        private string _refer_dept;             //申请科室代码
        private DateTime? _req_date_time;       //申请日期时间
        private string _req_dept_name;          //申请科室名称
        private string _req_memo;               //申请备注
        private string _clin_symp;              //临床症状
        private string _phys_sign;              //体征
        private string _relevant_lab_test;      //相关检查
        private string _relevant_diag;          //相关诊断
        private string _clin_diag;              //临床诊断
        private string _facility;               //设备名
        private string _out_med_institution;    //外来单位名称
        private decimal? _costs;                //计价
        private decimal? _charges;              //收费
        private int? _visit_id;                 //住院次数
        private int? _is_inquiry;               //随访标志
        private int? _is_back_inq;              //回访标志
        private int? _is_online;                //在线状态
        private int? _is_packprocess;           //打包标志
        private string _volumn_key;             //卷标值
        private string _jzh;           //add by liukun at 2010-7-13 临床记账号

        /// <summary>
        /// 记账号
        /// </summary>
        public string JZH
        {
            set { _jzh = value; }
            get { return _jzh; }
        }   //add by liukun at 2010-7-13 临床记账号 

        /// <summary>
        /// 检查申请号
        /// </summary>
        public string EXAM_ACCESSION_NUM
        {
            set { _exam_accession_num = value; }
            get { return _exam_accession_num; }
        }

        /// <summary>
        /// 检查流水号
        /// </summary>
        public int? ACCESSION_NO
        {
            set { _accession_no = value; }
            get { return _accession_no; }
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
        /// 姓名拼音
        /// </summary>
        public string PATIENT_PHONETIC
        {
            set { _patient_phonetic = value; }
            get { return _patient_phonetic; }
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
        /// 出生日期
        /// </summary>
        public DateTime? PATIENT_BIRTH
        {
            set { _patient_birth = value; }
            get { return _patient_birth; }
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
        /// 身份
        /// </summary>
        public string PATIENT_IDENTITY
        {
            set { _patient_identity = value; }
            get { return _patient_identity; }
        }

        /// <summary>
        /// 本地ID
        /// </summary>
        public string PATIENT_LOCAL_ID
        {
            set { _patient_local_id = value; }
            get { return _patient_local_id; }
        }

        /// <summary>
        /// 本地ID类别
        /// </summary>
        public string LOCAL_ID_CLASS
        {
            set { _local_id_class = value; }
            get { return _local_id_class; }
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
        /// 床号
        /// </summary>
        public string BED_NUM
        {
            set { _bed_num = value; }
            get { return _bed_num; }
        }

        /// <summary>
        /// 门诊号
        /// </summary>
        public string OPD_NO
        {
            set { _opd_no = value; }
            get { return _opd_no; }
        }

        /// <summary>
        /// 出生地
        /// </summary>
        public string BIRTH_PLACE
        {
            set { _birth_place = value; }
            get { return _birth_place; }
        }

        /// <summary>
        /// 收费类别
        /// </summary>
        public int? CHARGE_TYPE
        {
            set { _charge_type = value; }
            get { return _charge_type; }
        }

        /// <summary>
        /// 通信地址
        /// </summary>
        public string MAILING_ADDRESS
        {
            set { _mailing_address = value; }
            get { return _mailing_address; }
        }

        /// <summary>
        /// 邮政编码
        /// </summary>
        public string ZIP_CODE
        {
            set { _zip_code = value; }
            get { return _zip_code; }
        }

        /// <summary>
        /// 电话号码
        /// </summary>
        public string TELEPHONE_NUM
        {
            set { _telephone_num = value; }
            get { return _telephone_num; }
        }

        /// <summary>
        /// 病人来源
        /// </summary>
        public string PATIENT_SOURCE
        {
            set { _patient_source = value; }
            get { return _patient_source; }
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
        /// 检查项目
        /// </summary>
        public string EXAM_ITEMS
        {
            set { _exam_items = value; }
            get { return _exam_items; }
        }

        /// <summary>
        /// 检查科室代码
        /// </summary>
        public string EXAM_DEPT
        {
            set { _exam_dept = value; }
            get { return _exam_dept; }
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
        /// 检查方式
        /// </summary>
        public string EXAM_MODE
        {
            set { _exam_mode = value; }
            get { return _exam_mode; }
        }

        /// <summary>
        /// 检查诊室
        /// </summary>
        public string EXAM_GROUP
        {
            set { _exam_group = value; }
            get { return _exam_group; }
        }

        /// <summary>
        /// 检查医生
        /// </summary>
        public string EXAM_DOCTOR
        {
            set { _exam_doctor = value; }
            get { return _exam_doctor; }
        }

        /// <summary>
        /// 检查顺序号
        /// </summary>
        public string EXAM_NO
        {
            set { _exam_no = value; }
            get { return _exam_no; }
        }

        /// <summary>
        /// 检查累计
        /// </summary>
        public int? EXAM_INDEX
        {
            set { _exam_index = value; }
            get { return _exam_index; }
        }

        /// <summary>
        /// 当天流水号
        /// </summary>
        public decimal? EXAM_INTRADAYSEQ_NO
        {
            set { _exam_intradayseq_no = value; }
            get { return _exam_intradayseq_no; }
        }

        /// <summary>
        /// 检查实例UID
        /// </summary>
        public string STUDY_INSTANCE_UID
        {
            set { _study_instance_uid = value; }
            get { return _study_instance_uid; }
        }

        /// <summary>
        /// 检查图像路径
        /// </summary>
        public string STUDY_PATH
        {
            set { _study_path = value; }
            get { return _study_path; }
        }

        /// <summary>
        /// 报告医生
        /// </summary>
        public string REPORT_DOCTOR
        {
            set { _report_doctor = value; }
            get { return _report_doctor; }
        }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string DEVICE
        {
            set { _device = value; }
            get { return _device; }
        }

        /// <summary>
        /// 检查日期时间
        /// </summary>
        public DateTime? STUDY_DATE_TIME
        {
            set { _study_date_time = value; }
            get { return _study_date_time; }
        }

        /// <summary>
        /// 检查完成状态
        /// </summary>
        public int? EXAM_STEP_STATUS
        {
            set { _exam_step_status = value; }
            get { return _exam_step_status; }
        }

        /// <summary>
        /// 报告状态
        /// </summary>
        public int? REPORT_STATUS
        {
            set { _report_status = value; }
            get { return _report_status; }
        }

        /// <summary>
        /// 收费确认标志
        /// </summary>
        public int? IS_CONFIRMED
        {
            set { _is_confirmed = value; }
            get { return _is_confirmed; }
        }

        /// <summary>
        /// 匹配标志
        /// </summary>
        public int? MATCH_STATUS
        {
            set { _match_status = value; }
            get { return _match_status; }
        }
        
        /// <summary>
        /// 绿色通道标志
        /// </summary>
        public int? IS_TEMPORARY
        {
            set { _is_temporary = value; }
            get { return _is_temporary; }
        }

        /// <summary>
        /// VIP标志
        /// </summary>
        public int? VIP_INDICATOR
        {
            set { _vip_indicator = value; }
            get { return _vip_indicator; }
        }

        /// <summary>
        /// 图像入库标志
        /// </summary>
        public int? IMAGE_ARCHIVED
        {
            set { _image_archived = value; }
            get { return _image_archived; }
        }

        /// <summary>
        /// 预取状态标志
        /// </summary>
        public int? PRE_FETCH
        {
            set { _pre_fetch = value; }
            get { return _pre_fetch; }
        }

        /// <summary>
        /// 分发状态
        /// </summary>
        public int? DISPATCH_STATUS
        {
            set { _dispatch_status = value; }
            get { return _dispatch_status; }
        }

        /// <summary>
        /// 轮询状态标志
        /// </summary>
        public int? QUERY_STATUS
        {
            set { _query_status = value; }
            get { return _query_status; }
        }

        /// <summary>
        /// 轮询时间
        /// </summary>
        public DateTime? QUERY_TIME
        {
            set { _query_time = value; }
            get { return _query_time; }
        }

        /// <summary>
        /// 入院方式
        /// </summary>
        public int? PATIENT_CLASS
        {
            set { _patient_class = value; }
            get { return _patient_class; }
        }

        /// <summary>
        /// 图像总数
        /// </summary>
        public int? IMAGE_COUNTS
        {
            set { _image_counts = value; }
            get { return _image_counts; }
        }

        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime? SCHEDULED_DATE
        {
            set { _scheduled_date = value; }
            get { return _scheduled_date; }
        }

        /// <summary>
        /// 登记员
        /// </summary>
        public string SCH_OPERATOR
        {
            set { _sch_operator = value; }
            get { return _sch_operator; }
        }

        /// <summary>
        /// 申请医生
        /// </summary>
        public string REFER_DOCTOR
        {
            set { _refer_doctor = value; }
            get { return _refer_doctor; }
        }

        /// <summary>
        /// 申请科室
        /// </summary>
        public string REFER_DEPT
        {
            set { _refer_dept = value; }
            get { return _refer_dept; }
        }

        /// <summary>
        /// 申请日期时间
        /// </summary>
        public DateTime? REQ_DATE_TIME
        {
            set { _req_date_time = value; }
            get { return _req_date_time; }
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
        /// 申请备注
        /// </summary>
        public string REQ_MEMO
        {
            set { _req_memo = value; }
            get { return _req_memo; }
        }

        /// <summary>
        /// 临床症状
        /// </summary>
        public string CLIN_SYMP
        {
            set { _clin_symp = value; }
            get { return _clin_symp; }
        }

        /// <summary>
        /// 体征
        /// </summary>
        public string PHYS_SIGN
        {
            set { _phys_sign = value; }
            get { return _phys_sign; }
        }

        /// <summary>
        /// 相关检查
        /// </summary>
        public string RELEVANT_LAB_TEST
        {
            set { _relevant_lab_test = value; }
            get { return _relevant_lab_test; }
        }

        /// <summary>
        /// 相关诊断
        /// </summary>
        public string RELEVANT_DIAG
        {
            set { _relevant_diag = value; }
            get { return _relevant_diag; }
        }

        /// <summary>
        /// 临床诊断
        /// </summary>
        public string CLIN_DIAG
        {
            set { _clin_diag = value; }
            get { return _clin_diag; }
        }

        /// <summary>
        /// 设备名
        /// </summary>
        public string FACILITY
        {
            set { _facility = value; }
            get { return _facility; }
        }

        /// <summary>
        /// 外来单位机构名称
        /// </summary>
        public string OUT_MED_INSTITUTION
        {
            set { _out_med_institution = value; }
            get { return _out_med_institution; }
        }

        /// <summary>
        /// 计价
        /// </summary>
        public decimal? COSTS
        {
            set { _costs = value; }
            get { return _costs; }
        }

        /// <summary>
        /// 收费
        /// </summary>
        public decimal? CHARGES
        {
            set { _charges = value; }
            get { return _charges; }
        }

        /// <summary>
        /// 检查累计
        /// </summary>
        public int? VISIT_ID
        {
            set { _visit_id = value; }
            get { return _visit_id; }
        }

        /// <summary>
        /// 随访标志
        /// </summary>
        public int? IS_INQUIRY
        {
            set { _is_inquiry = value; }
            get { return _is_inquiry; }
        }

        /// <summary>
        /// 回访标志
        /// </summary>
        public int? IS_BACK_INQ
        {
            set { _is_back_inq = value; }
            get { return _is_back_inq; }
        }

        /// <summary>
        /// 在线标志
        /// </summary>
        public int? IS_ONLINE
        {
            set { _is_online = value; }
            get { return _is_online; }
        }

        /// <summary>
        /// 打包标志
        /// </summary>
        public int? IS_PACKPROCESS
        {
            set { _is_packprocess = value; }
            get { return _is_packprocess; }
        }

        /// <summary>
        /// 卷标key
        /// </summary>
        public string VOLUMN_KEY
        {
            set { _volumn_key = value; }
            get { return _volumn_key; }
        }
        #endregion Model

    }
}