using System;
namespace PACS_Model
{
    /// <summary>
    /// ʵ����PATIENT_SOURCE��������Դ��
    /// </summary>
    [Serializable]
    public class MPatientSource : ILL.IModel
    {
        public MPatientSource()
        { }
        #region Model
        private int? _patient_source_id;    //������ԴID
        private string _patient_source;     //������Դ����

        /// <summary>
        /// ������ԴID
        /// </summary>
        public int? PATIENT_SOURCE_ID
        {
            set { _patient_source_id = value; }
            get { return _patient_source_id; }
        }

        /// <summary>
        /// ������Դ����
        /// </summary>
        public string PATIENT_SOURCE
        {
            set { _patient_source = value; }
            get { return _patient_source; }
        }
        #endregion Model

    }
}

