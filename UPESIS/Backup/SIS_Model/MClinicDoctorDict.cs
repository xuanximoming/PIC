using System;
namespace SIS_Model
{
	/// <summary>
	/// ʵ����-CLINC_DOCTOR_DICT���ٴ�ҽ���ֵ�
	/// </summary>
	[Serializable]
    public class MClinicDoctorDict : ILL.IModel
	{
		public MClinicDoctorDict()
		{}
		#region Model
		private string _clinic_doctor;          //�ٴ�ҽ������
		private int? _clinic_office_id;         //�ٴ����Ҵ��룬��Ӧ�ٴ����ұ��CLINIC_OFFICE_CODE
        private string _clinic_doctor_id;       //�ٴ�ҽ��ID
        private string _clinic_doctor_pycode;   //�ٴ�ҽ����������

		/// <summary>
		/// �ٴ�ҽ������
		/// </summary>
		public string CLINIC_DOCTOR
		{
			set{ _clinic_doctor=value;}
			get{return _clinic_doctor;}
		}

		/// <summary>
		/// ��������ID
		/// </summary>
		public int? CLINIC_OFFICE_ID
		{
			set{ _clinic_office_id=value;}
			get{return _clinic_office_id;}
		}

        /// <summary>
        /// �ٴ�ҽ��ID
        /// </summary>
        public string CLINIC_DOCTOR_ID
        {
            set { _clinic_doctor_id = value; }
            get { return _clinic_doctor_id; }
        }

        /// <summary>
        /// �ٴ�ҽ����������
        /// </summary>
        public string CLINIC_DOCTOR_PYCODE
        {
            set { _clinic_doctor_pycode = value; }
            get { return _clinic_doctor_pycode; }
        }
		#endregion Model

	}
}