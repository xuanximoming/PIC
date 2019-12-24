using System;
namespace SIS_Model
{
	/// <summary>
	/// ʵ����--BESPEAK��ԤԼ��
	/// </summary>
	[Serializable]
    public class MBespeak : ILL.IModel
	{
		public MBespeak()
		{}
		#region Model
		private int? _bespeak_id;           //ԤԼID
		private string _patient_id;         //����ID
		private string _patient_name;       //����
		private string _patient_sex;        //�Ա�
		private int? _patient_age;          //����
		private string _patient_age_unit;   //���䵥λ
		private string _is_marriage;        //������־
		private string _patient_source;     //������Դ
		private string _inp_no;             //סԺ��
		private string _bed_no;             //����
		private decimal? _charges;          //����
		private string _reg_doctor;         //�Ǽ�ҽ��
		private int? _queue_no;             //�Ŷ���ˮ��
		private DateTime? _bespeak_time;    //ԤԼʱ��
		private string _exam_part;          //��鲿λ
		private string _exam_class;         //������
		private int? _pregnancy;            //����
		private string _req_dept;           //�������
		private string _req_doctor;         //����ҽ��
		private string _relation;           //��ϵ��ʽ
		private string _charge_class;       //�շ����
		private string _insurance_no;       //ҽ����
		private DateTime? _last_catamenia;  //����¾�
		private string _clinic_diag;        //�ٴ����
        private int? _flag;                 //��־���Ƿ񵽴�(0:δ����;1:�ѵ���)

		/// <summary>
		/// ԤԼID
		/// </summary>
		public int? BESPEAK_ID
		{
			set{ _bespeak_id=value;}
			get{return _bespeak_id;}
		}

		/// <summary>
		/// ����ID
		/// </summary>
		public string PATIENT_ID
		{
			set{ _patient_id=value;}
			get{return _patient_id;}
		}

		/// <summary>
		/// ����
		/// </summary>
		public string PATIENT_NAME
		{
			set{ _patient_name=value;}
			get{return _patient_name;}
		}

		/// <summary>
		/// �Ա�
		/// </summary>
		public string PATIENT_SEX
		{
			set{ _patient_sex=value;}
			get{return _patient_sex;}
		}

		/// <summary>
		/// ����
		/// </summary>
		public int? PATIENT_AGE
		{
			set{ _patient_age=value;}
			get{return _patient_age;}
		}

		/// <summary>
		/// ���䵥λ
		/// </summary>
		public string PATIENT_AGE_UNIT
		{
			set{ _patient_age_unit=value;}
			get{return _patient_age_unit;}
		}

		/// <summary>
		/// ������־
		/// </summary>
		public string IS_MARRIAGE
		{
			set{ _is_marriage=value;}
			get{return _is_marriage;}
		}

		/// <summary>
		/// ������Դ
		/// </summary>
		public string PATIENT_SOURCE
		{
			set{ _patient_source=value;}
			get{return _patient_source;}
		}

		/// <summary>
		/// סԺ��
		/// </summary>
		public string INP_NO
		{
			set{ _inp_no=value;}
			get{return _inp_no;}
		}

		/// <summary>
		/// ����
		/// </summary>
		public string BED_NO
		{
			set{ _bed_no=value;}
			get{return _bed_no;}
		}

		/// <summary>
		/// ����
		/// </summary>
		public decimal? CHARGES
		{
			set{ _charges=value;}
			get{return _charges;}
		}

		/// <summary>
		/// �Ǽ�ҽ��
		/// </summary>
		public string REG_DOCTOR
		{
			set{ _reg_doctor=value;}
			get{return _reg_doctor;}
		}

		/// <summary>
		/// �Ŷ���ˮ��
		/// </summary>
		public int? QUEUE_NO
		{
			set{ _queue_no=value;}
			get{return _queue_no;}
		}

		/// <summary>
		/// ԤԼʱ��
		/// </summary>
		public DateTime? BESPEAK_TIME
		{
			set{ _bespeak_time=value;}
			get{return _bespeak_time;}
		}

		/// <summary>
		/// ��鲿λ
		/// </summary>
		public string EXAM_PART
		{
			set{ _exam_part=value;}
			get{return _exam_part;}
		}

		/// <summary>
		/// ������
		/// </summary>
		public string EXAM_CLASS
		{
			set{ _exam_class=value;}
			get{return _exam_class;}
		}

		/// <summary>
		/// ����
		/// </summary>
		public int? PREGNANCY
		{
			set{ _pregnancy=value;}
			get{return _pregnancy;}
		}

		/// <summary>
		/// �������
		/// </summary>
		public string REQ_DEPT
		{
			set{ _req_dept=value;}
			get{return _req_dept;}
		}

		/// <summary>
		/// ����ҽ��
		/// </summary>
		public string REQ_DOCTOR
		{
			set{ _req_doctor=value;}
			get{return _req_doctor;}
		}

		/// <summary>
		/// ��ϵ��ʽ
		/// </summary>
		public string RELATION
		{
			set{ _relation=value;}
			get{return _relation;}
		}

		/// <summary>
		/// �շ����
		/// </summary>
		public string CHARGE_CLASS
		{
			set{ _charge_class=value;}
			get{return _charge_class;}
		}

		/// <summary>
		/// ҽ����
		/// </summary>
		public string INSURANCE_NO
		{
			set{ _insurance_no=value;}
			get{return _insurance_no;}
		}

		/// <summary>
		/// ����¾�
		/// </summary>
		public DateTime? LAST_CATAMENIA
		{
			set{ _last_catamenia=value;}
			get{return _last_catamenia;}
		}

		/// <summary>
		/// �ٴ����
		/// </summary>
		public string CLINIC_DIAG
		{
			set{ _clinic_diag=value;}
			get{return _clinic_diag;}
		}

		/// <summary>
		/// ��־
		/// </summary>
		public int? FLAG
		{
			set{ _flag=value;}
			get{return _flag;}
		}
		#endregion Model

	}
}