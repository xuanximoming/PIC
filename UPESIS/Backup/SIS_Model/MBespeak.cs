using System;
namespace SIS_Model
{
	/// <summary>
	/// 实体类--BESPEAK，预约表
	/// </summary>
	[Serializable]
    public class MBespeak : ILL.IModel
	{
		public MBespeak()
		{}
		#region Model
		private int? _bespeak_id;           //预约ID
		private string _patient_id;         //病人ID
		private string _patient_name;       //姓名
		private string _patient_sex;        //性别
		private int? _patient_age;          //年龄
		private string _patient_age_unit;   //年龄单位
		private string _is_marriage;        //婚姻标志
		private string _patient_source;     //病人来源
		private string _inp_no;             //住院号
		private string _bed_no;             //床号
		private decimal? _charges;          //费用
		private string _reg_doctor;         //登记医生
		private int? _queue_no;             //排队流水号
		private DateTime? _bespeak_time;    //预约时间
		private string _exam_part;          //检查部位
		private string _exam_class;         //检查类别
		private int? _pregnancy;            //孕期
		private string _req_dept;           //申请科室
		private string _req_doctor;         //申请医生
		private string _relation;           //联系方式
		private string _charge_class;       //收费类别
		private string _insurance_no;       //医保号
		private DateTime? _last_catamenia;  //最后月经
		private string _clinic_diag;        //临床诊断
        private int? _flag;                 //标志：是否到达(0:未到达;1:已到达)

		/// <summary>
		/// 预约ID
		/// </summary>
		public int? BESPEAK_ID
		{
			set{ _bespeak_id=value;}
			get{return _bespeak_id;}
		}

		/// <summary>
		/// 病人ID
		/// </summary>
		public string PATIENT_ID
		{
			set{ _patient_id=value;}
			get{return _patient_id;}
		}

		/// <summary>
		/// 姓名
		/// </summary>
		public string PATIENT_NAME
		{
			set{ _patient_name=value;}
			get{return _patient_name;}
		}

		/// <summary>
		/// 性别
		/// </summary>
		public string PATIENT_SEX
		{
			set{ _patient_sex=value;}
			get{return _patient_sex;}
		}

		/// <summary>
		/// 年龄
		/// </summary>
		public int? PATIENT_AGE
		{
			set{ _patient_age=value;}
			get{return _patient_age;}
		}

		/// <summary>
		/// 年龄单位
		/// </summary>
		public string PATIENT_AGE_UNIT
		{
			set{ _patient_age_unit=value;}
			get{return _patient_age_unit;}
		}

		/// <summary>
		/// 婚姻标志
		/// </summary>
		public string IS_MARRIAGE
		{
			set{ _is_marriage=value;}
			get{return _is_marriage;}
		}

		/// <summary>
		/// 病人来源
		/// </summary>
		public string PATIENT_SOURCE
		{
			set{ _patient_source=value;}
			get{return _patient_source;}
		}

		/// <summary>
		/// 住院号
		/// </summary>
		public string INP_NO
		{
			set{ _inp_no=value;}
			get{return _inp_no;}
		}

		/// <summary>
		/// 床号
		/// </summary>
		public string BED_NO
		{
			set{ _bed_no=value;}
			get{return _bed_no;}
		}

		/// <summary>
		/// 费用
		/// </summary>
		public decimal? CHARGES
		{
			set{ _charges=value;}
			get{return _charges;}
		}

		/// <summary>
		/// 登记医生
		/// </summary>
		public string REG_DOCTOR
		{
			set{ _reg_doctor=value;}
			get{return _reg_doctor;}
		}

		/// <summary>
		/// 排队流水号
		/// </summary>
		public int? QUEUE_NO
		{
			set{ _queue_no=value;}
			get{return _queue_no;}
		}

		/// <summary>
		/// 预约时间
		/// </summary>
		public DateTime? BESPEAK_TIME
		{
			set{ _bespeak_time=value;}
			get{return _bespeak_time;}
		}

		/// <summary>
		/// 检查部位
		/// </summary>
		public string EXAM_PART
		{
			set{ _exam_part=value;}
			get{return _exam_part;}
		}

		/// <summary>
		/// 检查类别
		/// </summary>
		public string EXAM_CLASS
		{
			set{ _exam_class=value;}
			get{return _exam_class;}
		}

		/// <summary>
		/// 孕期
		/// </summary>
		public int? PREGNANCY
		{
			set{ _pregnancy=value;}
			get{return _pregnancy;}
		}

		/// <summary>
		/// 申请科室
		/// </summary>
		public string REQ_DEPT
		{
			set{ _req_dept=value;}
			get{return _req_dept;}
		}

		/// <summary>
		/// 申请医生
		/// </summary>
		public string REQ_DOCTOR
		{
			set{ _req_doctor=value;}
			get{return _req_doctor;}
		}

		/// <summary>
		/// 联系方式
		/// </summary>
		public string RELATION
		{
			set{ _relation=value;}
			get{return _relation;}
		}

		/// <summary>
		/// 收费类别
		/// </summary>
		public string CHARGE_CLASS
		{
			set{ _charge_class=value;}
			get{return _charge_class;}
		}

		/// <summary>
		/// 医保号
		/// </summary>
		public string INSURANCE_NO
		{
			set{ _insurance_no=value;}
			get{return _insurance_no;}
		}

		/// <summary>
		/// 最后月经
		/// </summary>
		public DateTime? LAST_CATAMENIA
		{
			set{ _last_catamenia=value;}
			get{return _last_catamenia;}
		}

		/// <summary>
		/// 临床诊断
		/// </summary>
		public string CLINIC_DIAG
		{
			set{ _clinic_diag=value;}
			get{return _clinic_diag;}
		}

		/// <summary>
		/// 标志
		/// </summary>
		public int? FLAG
		{
			set{ _flag=value;}
			get{return _flag;}
		}
		#endregion Model

	}
}