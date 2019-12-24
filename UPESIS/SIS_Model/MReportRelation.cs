using System;
namespace SIS_Model
{
    /// <summary>
    /// 实体类REPORT_RELATION，病人报告一体化
    /// </summary>
    [Serializable]
    public class MReportRelation : ILL.IModel
    {
        public MReportRelation()
        { }
        #region Model
        private string _exam_accession_num;     //检查申请号
        private string _exam_accession_num_ex;  //其他科室主键

        /// <summary>
        ///检查申请号 
        /// </summary>
        public string EXAM_ACCESSION_NUM
        {
            set { _exam_accession_num = value; }
            get { return _exam_accession_num; }
        }

        /// <summary>
        /// 其他科室主键
        /// </summary>
        public string EXAM_ACCESSION_NUM_EX
        {
            set { _exam_accession_num_ex = value; }
            get { return _exam_accession_num_ex; }
        }
        #endregion Model

    }
}