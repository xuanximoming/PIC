using System;
namespace SIS_Model
{
    /// <summary>
    /// 实体类REPORT，病人报告表
    /// </summary>
    [Serializable]
    public class MReport : ILL.IModel
    {
        public MReport()
        { }
        #region Model
        private string _exam_no;                //检查申请号
        private string _exam_para;              //检查参数
        private string _description;            //检查所见
        private string _impression;             //诊断意见，即印象
        private string _recommendation;         //意见
        private string _dictator;               //口述者
        private string _transcriber;            //记录者
        private string _approver;               //报告者
        private DateTime? _approve_date_time;   //报告确认时间
        private DateTime? _report_date_time;    //报告时间
        private string _affirmant;              //报告提交者
        private DateTime? _affirm_date_time;    //提交时间
        private int? _is_abnormal;              //阴阳性 0：阴性  1：阳性
        private int? _report_type;              //报告类型 0：初步报告；1：提交待审核;2:审核报告;3:冻结报告
        private string _print_template;         //打印模板名称
        private int? _print_count;              //打印次数，即打印标识  空值：未打印   1：已打印
        private byte[] _report_name;            //报告名称
        private string _field_inf;              //模板字段信息

        /// <summary>
        /// 检查申请号
        /// </summary>
        public string EXAM_NO
        {
            set { _exam_no = value; }
            get { return _exam_no; }
        }

        /// <summary>
        /// 检查参数
        /// </summary>
        public string EXAM_PARA
        {
            set { _exam_para = value; }
            get { return _exam_para; }
        }

        /// <summary>
        /// 检查所见
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
        /// 意见
        /// </summary>
        public string RECOMMENDATION
        {
            set { _recommendation = value; }
            get { return _recommendation; }
        }

        /// <summary>
        /// 口述者
        /// </summary>
        public string DICTATOR
        {
            set { _dictator = value; }
            get { return _dictator; }
        }

        /// <summary>
        /// 记录者
        /// </summary>
        public string TRANSCRIBER
        {
            set { _transcriber = value; }
            get { return _transcriber; }
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
        /// 报告确认时间
        /// </summary>
        public DateTime? APPROVE_DATE_TIME
        {
            set { _approve_date_time = value; }
            get { return _approve_date_time; }
        }

        /// <summary>
        /// 报告时间
        /// </summary>
        public DateTime? REPORT_DATE_TIME
        {
            set { _report_date_time = value; }
            get { return _report_date_time; }
        }

        /// <summary>
        /// 报告提交者
        /// </summary>
        public string AFFIRMANT
        {
            set { _affirmant = value; }
            get { return _affirmant; }
        }

        /// <summary>
        /// 报告提交时间
        /// </summary>
        public DateTime? AFFIRM_DATE_TIME
        {
            set { _affirm_date_time = value; }
            get { return _affirm_date_time; }
        }

        /// <summary>
        /// 阴阳性
        /// </summary>
        public int? IS_ABNORMAL
        {
            set { _is_abnormal = value; }
            get { return _is_abnormal; }
        }

        /// <summary>
        /// 报告类型
        /// </summary>
        public int? REPORT_TYPE
        {
            set { _report_type = value; }
            get { return _report_type; }
        }

        /// <summary>
        /// 打印模板名称
        /// </summary>
        public string PRINT_TEMPLATE
        {
            set { _print_template = value; }
            get { return _print_template; }
        }

        /// <summary>
        /// 打印次数
        /// </summary>
        public int? PRINT_COUNT
        {
            set { _print_count = value; }
            get { return _print_count; }
        }

        /// <summary>
        /// 报告名称
        /// </summary>
        public byte[] REPORT_NAME
        {
            set { _report_name = value; }
            get { return _report_name; }
        }

        /// <summary>
        /// 模板字段信息
        /// </summary>
        public string FIELD_INF
        {
            set { _field_inf = value; }
            get { return _field_inf; }
        }
        #endregion Model
        #region Model
        //private string _exam_accession_num;
        private string _a1;
        private int? _a2;
        private int? _a3;
        private int? _a4;
        private string _a5;
        private string _a6;
        /// <summary>
        /// 
        /// </summary>
        //public string EXAM_ACCESSION_NUM
        //{
        //	set{ _exam_accession_num=value;}
        //	get{return _exam_accession_num;}
        //}
        /// <summary>
        /// 
        /// </summary>
        public string A1
        {
            set { _a1 = value; }
            get { return _a1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? A2
        {
            set { _a2 = value; }
            get { return _a2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? A3
        {
            set { _a3 = value; }
            get { return _a3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? A4
        {
            set { _a4 = value; }
            get { return _a4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string A5
        {
            set { _a5 = value; }
            get { return _a5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string A6
        {
            set { _a6 = value; }
            get { return _a6; }
        }
        #endregion Model
    }
}

