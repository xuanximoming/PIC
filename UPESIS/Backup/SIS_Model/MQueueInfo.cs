using System;
namespace SIS_Model
{
    /// <summary>
    /// 实体类QUEUE_INFO，队列信息
    /// </summary>
    [Serializable]
    public class MQueueInfo : ILL.IModel
    {
        public MQueueInfo()
        { }
        #region Model
        private string _exam_accession_num; //检查申请号
        private string _patient_id;         //病人ID
        private string _patient_name;       //姓名
        private string _patient_sex;        //性别
        private string _clinic_lable;       //门诊号别
        private string _doctor;             //医生姓名
        private int? _serial_no;            //流水号
        private DateTime? _visit_date;      //挂号日期
        private int? _diag_flag;            //就诊标志 0：未检查；1：已检查；9：已删除
        private string _visit_dept;         //就诊科室名称
        private decimal? _order_no;         //队列序号
        private int? _visit_no;             //就诊号
        private DateTime? _reg_date;        //登记日期
        private string _is_rediag;          //复诊标识 默认为0
        private string _queue_name;         //队列名称，对应诊室名称
        private int? _print_no;             //打印号
        private int? _passed;               //特殊标志 默认为0.该标识0-正常;1-过号;2-优先

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
        /// 门诊号别
        /// </summary>
        public string CLINIC_LABLE
        {
            set { _clinic_lable = value; }
            get { return _clinic_lable; }
        }

        /// <summary>
        /// 医生姓名
        /// </summary>
        public string DOCTOR
        {
            set { _doctor = value; }
            get { return _doctor; }
        }

        /// <summary>
        /// 流水号
        /// </summary>
        public int? SERIAL_NO
        {
            set { _serial_no = value; }
            get { return _serial_no; }
        }

        /// <summary>
        /// 挂号日期
        /// </summary>
        public DateTime? VISIT_DATE
        {
            set { _visit_date = value; }
            get { return _visit_date; }
        }

        /// <summary>
        /// 就诊标志
        /// </summary>
        public int? DIAG_FLAG
        {
            set { _diag_flag = value; }
            get { return _diag_flag; }
        }

        /// <summary>
        /// 就诊科室
        /// </summary>
        public string VISIT_DEPT
        {
            set { _visit_dept = value; }
            get { return _visit_dept; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ORDER_NO
        {
            set { _order_no = value; }
            get { return _order_no; }
        }

        /// <summary>
        /// 就诊号
        /// </summary>
        public int? VISIT_NO
        {
            set { _visit_no = value; }
            get { return _visit_no; }
        }

        /// <summary>
        /// 登记日期
        /// </summary>
        public DateTime? REG_DATE
        {
            set { _reg_date = value; }
            get { return _reg_date; }
        }

        /// <summary>
        /// 复诊标识
        /// </summary>
        public string IS_REDIAG
        {
            set { _is_rediag = value; }
            get { return _is_rediag; }
        }

        /// <summary>
        /// 队列名称，即诊室
        /// </summary>
        public string QUEUE_NAME
        {
            set { _queue_name = value; }
            get { return _queue_name; }
        }

        /// <summary>
        /// 打印号
        /// </summary>
        public int? PRINT_NO
        {
            set { _print_no = value; }
            get { return _print_no; }
        }

        /// <summary>
        /// 特殊标识
        /// </summary>
        public int? PASSED
        {
            set { _passed = value; }
            get { return _passed; }
        }
        #endregion Model

    }
}