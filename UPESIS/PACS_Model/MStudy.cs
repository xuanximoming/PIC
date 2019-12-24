using System;
using System.Collections.Generic;
using System.Text;

namespace PACS_Model
{
    /// <summary>
    /// 实体类STUDY，检查记录表，永久保存检查记录
    /// </summary>
    [Serializable]
    public class MStudy : ILL.IModel
    {
        public MStudy()
        { }
        #region Model
        private int _study_key;             //检查主键，数据自动产生
        private string _patient_id;         //病人ID
        private string _patient_name;       //病人姓名
        private string _patient_sex;        //病人姓名
        private DateTime? _patient_birth;   //出生日期
        private int? _patient_age;          //年龄
        private string _patient_age_unit;   //年龄单位
        private string _patient_source;     //病人来源
        private string _birth_place;        //出生地
        private string _identity;           //身份
        private int? _security;             //密级：大于2禁止访问
        private string _charge_type;        //费别
        private int? _visit_id;             //住院次数
        private string _inp_no;             //住院号
        private string _bed_num;            //床号
        private string _zip_code;           //邮政编码
        private string _mailing_address;    //通信地址
        private string _telephone_number;   //电话
        private string _study_id;           //本次检查号
        private string _study_desc;         //检查描述
        private string _study_instance_uid; //检查实例UID
        private DateTime? _study_date_time; //检查日期时间
        private string _access_no;          //检查顺序号
        private string _body_part;          //检查部位
        private int? _series_count;         //检查序列总数
        private int? _instance_count;　　　 //本次检查实例总数
        private string _modality;           //检查设备
        private string _facility;           //外来单位名称        
        private string _refer_doctor;       //申请医生
        private string _refer_dept;         //申请科室代码
        private string _req_memo;           //申请备注
        private string _req_dept_name;      //申请科室名称
        private DateTime? _req_date_time;   //申请时间日期
        private DateTime? _scheduled_date;  //预约时间
        private string _sch_operator;       //登记员
        private string _exam_no;            //检查号
        private string _exam_accession_num; //检查申请号
        private string _exam_class;         //检查类别
        private string _exam_sub_class;     //检查子类
        private string _exam_item;          //检查项目  
        private string _exam_mode;          //检查方式
        private string _exam_group;         //检查诊室
        private string _exam_dept_name;     //检查科室名称  
        private string _exam_doctor;        //检查医生
        private int? _exam_index;           //检查序号，即检查总数
        private int? _is_online;            //在线标志
        private int? _is_matched;           //匹配标志
        private int? _is_packprocess;       //打包标志
        private int? _report_status;        //报告状态
        private int? _verified;             //验证标志
        private string _approver;           //报告者
        private string _clin_diag;          //临床诊断
        private string _clin_symp;          //临床症状
        private string _relevant_lab_test;  //相关检查
        private string _relevant_diag;      //相关诊断
        private string _phys_sign;          //体征
        private string _study_path;         //检查目录路径
        private string _volume_key;         //卷标值
        private string _device;             //设备型号

        /// <summary>
        /// 检查主键，数据库自动产生
        /// </summary>
        public int STUDY_KEY
        {
            set { _study_key = value; }
            get { return _study_key; }
        }

        /// <summary>
        /// 病人ID号，登记时产生
        /// </summary>
        public string PATIENT_ID
        {
            set { _patient_id = value; }
            get { return _patient_id; }
        }

        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PATIENT_NAME
        {
            set { _patient_name = value; }
            get { return _patient_name; }
        }

        /// <summary>
        /// 病人性别
        /// </summary>
        public string PATIENT_SEX
        {
            set { _patient_sex = value; }
            get { return _patient_sex; }
        }

        /// <summary>
        /// 病人出生日期
        /// </summary>
        public DateTime? PATIENT_BIRTH
        {
            set { _patient_birth = value; }
            get { return _patient_birth; }
        }

        /// <summary>
        ///病人年龄 
        /// </summary>
        public int? PATIENT_AGE
        {
            set { _patient_age = value; }
            get { return _patient_age; }
        }

        /// <summary>
        /// 病人年龄单位
        /// </summary>
        public string PATIENT_AGE_UNIT
        {
            set { _patient_age_unit = value; }
            get { return _patient_age_unit; }
        }

        /// <summary>
        ///病人来源，一般分门诊和住院 
        /// </summary>
        public string PATIENT_SOURCE
        {
            set { _patient_source = value; }
            get { return _patient_source; }
        }

        /// <summary>
        ///出生地 
        /// </summary>
        public string BIRTH_PLACE
        {
            set { _birth_place = value; }
            get { return _birth_place; }
        }

        /// <summary>
        /// 身份
        /// </summary>
        public string IDENTITY
        {
            set { _identity = value; }
            get { return _identity; }
        }

        /// <summary>
        /// 密级
        /// </summary>
        public int? SECURITY
        {
            set { _security = value; }
            get { return _security; }
        }

        /// <summary>
        /// 费别，自费还是公费
        /// </summary>
        public string CHARGE_TYPE
        {
            set { _charge_type = value; }
            get { return _charge_type; }
        }

        /// <summary>
        /// 住院次数
        /// </summary>
        public int? VISIT_ID
        {
            set { _visit_id = value; }
            get { return _visit_id; }
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
        /// 邮政编码
        /// </summary>
        public string ZIP_CODE
        {
            set { _zip_code = value; }
            get { return _zip_code; }
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
        /// 电话号码
        /// </summary>
        public string TELEPHONE_NUMBER
        {
            set { _telephone_number = value; }
            get { return _telephone_number; }
        }

        /// <summary>
        /// 本次检查号
        /// </summary>
        public string STUDY_ID
        {
            set { _study_id = value; }
            get { return _study_id; }
        }

        /// <summary>
        /// 检查描述
        /// </summary>
        public string STUDY_DESC
        {
            set { _study_desc = value; }
            get { return _study_desc; }
        }

        /// <summary>
        /// 检查实例ID
        /// </summary>
        public string STUDY_INSTANCE_UID
        {
            set { _study_instance_uid = value; }
            get { return _study_instance_uid; }
        }

        /// <summary>
        ///检查日期时间 
        /// </summary>
        public DateTime? STUDY_DATE_TIME
        {
            set { _study_date_time = value; }
            get { return _study_date_time; }
        }

        /// <summary>
        ///检查顺序号
        /// </summary>
        public string ACCESS_NO
        {
            set { _access_no = value; }
            get { return _access_no; }
        }
        /// <summary>
        /// 检查部位
        /// </summary>
        public string BODY_PART
        {
            set { _body_part = value; }
            get { return _body_part; }
        }

        /// <summary>
        /// 图像序列总数
        /// </summary>
        public int? SERIES_COUNT
        {
            set { _series_count = value; }
            get { return _series_count; }
        }

        /// <summary>
        /// 本次检查实例总数
        /// </summary>
        public int? INSTANCE_COUNT
        {
            set { _instance_count = value; }
            get { return _instance_count; }
        }

        /// <summary>
        /// 设备名
        /// </summary>
        public string MODALITY
        {
            set { _modality = value; }
            get { return _modality; }
        }

        /// <summary>
        /// 外来单位名称
        /// </summary>
        public string FACILITY
        {
            set { _facility = value; }
            get { return _facility; }
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
        /// 申请科室代码
        /// </summary>
        public string REFER_DEPT
        {
            set { _refer_dept = value; }
            get { return _refer_dept; }
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
        /// 申请科室名称
        /// </summary>
        public string REQ_DEPT_NAME
        {
            set { _req_dept_name = value; }
            get { return _req_dept_name; }
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
        /// 预约时间
        /// </summary>
        public DateTime? SCHEDULED_DATE
        {
            set { _scheduled_date = value; }
            get { return _scheduled_date; }
        }

        /// <summary>
        /// 登记员工号
        /// </summary>
        public string SCH_OPERATOR
        {
            set { _sch_operator = value; }
            get { return _sch_operator; }
        }

        /// <summary>
        /// 检查号，一般是申请单号
        /// </summary>
        public string EXAM_NO
        {
            set { _exam_no = value; }
            get { return _exam_no; }
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
        public string EXAM_ITEM
        {
            set { _exam_item = value; }
            get { return _exam_item; }
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
        /// 检查科室名称
        /// </summary>
        public string EXAM_DEPT_NAME
        {
            set { _exam_dept_name = value; }
            get { return _exam_dept_name; }
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
        /// 检查总数
        /// </summary>
        public int? EXAM_INDEX
        {
            set { _exam_index = value; }
            get { return _exam_index; }
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
        /// 匹配标志
        /// </summary>
        public int? IS_MATCHED
        {
            set { _is_matched = value; }
            get { return _is_matched; }
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
        /// 报告状态
        /// </summary>
        public int? REPORT_STATUS
        {
            set { _report_status = value; }
            get { return _report_status; }
        }

        /// <summary>
        /// 验证标志
        /// </summary>
        public int? VERIFIED
        {
            set { _verified = value; }
            get { return _verified; }
        }

        /// <summary>
        /// 报告者
        /// </summary>
        public string APPROVER
        {
            set { _approver = value; }
            get { return _approver; }
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
        /// 临床症状
        /// </summary>
        public string CLIN_SYMP
        {
            set { _clin_symp = value; }
            get { return _clin_symp; }
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
        /// 体征
        /// </summary>
        public string PHYS_SIGN
        {
            set { _phys_sign = value; }
            get { return _phys_sign; }
        }

        /// <summary>
        /// 检查目录路径
        /// </summary>
        public string STUDY_PATH
        {
            set { _study_path = value; }
            get { return _study_path; }
        }

        /// <summary>
        /// 卷标值
        /// </summary>
        public string VOLUME_KEY
        {
            set { _volume_key = value; }
            get { return _volume_key; }
        }

        /// <summary>
        /// 设备型号
        /// </summary>
        public string DEVICE
        {
            set { _device = value; }
            get { return _device; }
        }
        #endregion Model
    }
}