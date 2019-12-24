using System;
namespace PACS_Model
{
    /// <summary>
    /// 实体类PATIENT_SOURCE，病人来源表
    /// </summary>
    [Serializable]
    public class MPatientSource : ILL.IModel
    {
        public MPatientSource()
        { }
        #region Model
        private int? _patient_source_id;    //病人来源ID
        private string _patient_source;     //病人来源名称

        /// <summary>
        /// 病人来源ID
        /// </summary>
        public int? PATIENT_SOURCE_ID
        {
            set { _patient_source_id = value; }
            get { return _patient_source_id; }
        }

        /// <summary>
        /// 病人来源名称
        /// </summary>
        public string PATIENT_SOURCE
        {
            set { _patient_source = value; }
            get { return _patient_source; }
        }
        #endregion Model

    }
}

