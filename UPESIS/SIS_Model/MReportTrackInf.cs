using System;
namespace SIS_Model
{
    /// <summary>
    /// 实体类REPORT_TRACK_INF，报告轨迹信息
    /// </summary>
    [Serializable]
    public class MReportTrackInf : ILL.IModel
    {
        public MReportTrackInf()
        { }
        #region Model
        private string _exam_accession_num;     //检查申请号
        private DateTime? _report_modify_time;  //修改时间
        private string _exam_para;              //检查参数
        private string _description;            //检查所见
        private string _impression;             //印象
        private string _recommendation;         //建议
        private string _dictator;               //口述者
        private string _transcriber;            //记录者
        private string _approver;               //报告者
        private string _affirmant;              //确认者
        private string _operator;               //操作者
        private int? _is_abnormal;              //阴阳性
        private int? _report_type;              //报告类型 0：初步报告；1：确认报告

        /// <summary>
        /// 检查申请号
        /// </summary>
        public string EXAM_ACCESSION_NUM
        {
            set { _exam_accession_num = value; }
            get { return _exam_accession_num; }
        }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? REPORT_MODIFY_TIME
        {
            set { _report_modify_time = value; }
            get { return _report_modify_time; }
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
        /// 建议
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
        /// 确认者
        /// </summary>
        public string AFFIRMANT
        {
            set { _affirmant = value; }
            get { return _affirmant; }
        }

        /// <summary>
        /// 操作者
        /// </summary>
        public string OPERATOR
        {
            set { _operator = value; }
            get { return _operator; }
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
        #endregion Model

    }
}