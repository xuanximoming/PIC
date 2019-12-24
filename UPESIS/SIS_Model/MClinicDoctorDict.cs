using System;
namespace SIS_Model
{
	/// <summary>
	/// 实体类-CLINC_DOCTOR_DICT，临床医生字典
	/// </summary>
	[Serializable]
    public class MClinicDoctorDict : ILL.IModel
	{
		public MClinicDoctorDict()
		{}
		#region Model
		private string _clinic_doctor;          //临床医生姓名
		private int? _clinic_office_id;         //临床科室代码，对应临床科室表的CLINIC_OFFICE_CODE
        private string _clinic_doctor_id;       //临床医生ID
        private string _clinic_doctor_pycode;   //临床医生姓名简码

		/// <summary>
		/// 临床医生姓名
		/// </summary>
		public string CLINIC_DOCTOR
		{
			set{ _clinic_doctor=value;}
			get{return _clinic_doctor;}
		}

		/// <summary>
		/// 所属科室ID
		/// </summary>
		public int? CLINIC_OFFICE_ID
		{
			set{ _clinic_office_id=value;}
			get{return _clinic_office_id;}
		}

        /// <summary>
        /// 临床医生ID
        /// </summary>
        public string CLINIC_DOCTOR_ID
        {
            set { _clinic_doctor_id = value; }
            get { return _clinic_doctor_id; }
        }

        /// <summary>
        /// 临床医生姓名简码
        /// </summary>
        public string CLINIC_DOCTOR_PYCODE
        {
            set { _clinic_doctor_pycode = value; }
            get { return _clinic_doctor_pycode; }
        }
		#endregion Model

	}
}