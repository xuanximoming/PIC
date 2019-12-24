using System;
namespace SIS_Model
{
    /// <summary>
    /// ʵ����REPORT_RELATION�����˱���һ�廯
    /// </summary>
    [Serializable]
    public class MReportRelation : ILL.IModel
    {
        public MReportRelation()
        { }
        #region Model
        private string _exam_accession_num;     //��������
        private string _exam_accession_num_ex;  //������������

        /// <summary>
        ///�������� 
        /// </summary>
        public string EXAM_ACCESSION_NUM
        {
            set { _exam_accession_num = value; }
            get { return _exam_accession_num; }
        }

        /// <summary>
        /// ������������
        /// </summary>
        public string EXAM_ACCESSION_NUM_EX
        {
            set { _exam_accession_num_ex = value; }
            get { return _exam_accession_num_ex; }
        }
        #endregion Model

    }
}