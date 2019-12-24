using System;
using ILL;
namespace PACS_Model
{
	/// <summary>
	/// 实体类QC_CT 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public class MQcCt : IModel
	{
		public MQcCt()
		{}
		#region Model
		private string _exam_accession_num;
		private string _patient_local_id;
		private DateTime? _qc_date;
		private string _patient_id;
		private string _patient_name;
		private string _patient_sex;
		private DateTime? _study_date_time;
        private decimal? _posture_choice = 5;           //体位选择
        private decimal? _scanning_scope = 10;          //扫描范围
        private decimal? _viscera_scanning = 10;        //脏器扫描
        private decimal? _scanning_mode = 5;            //扫描方式
        private decimal? _resolution = 15;              //清晰度
        private decimal? _inf_criterion = 10;           //信息规范
        private decimal? _wl_wwidth = 5;                //窗位窗宽
        private decimal? _externa_breath_shadow = 5;    //体外呼吸伪影
        private decimal? _total_score = 100;            //总分
		private int? _distinction=1;
		private int? _number_key;
        private decimal? _base_ash_fog_value = 10;      //基础灰雾密度
        private decimal? _blank_exposal_density = 10;   //空曝射区密度
        private decimal? _film_format = 5;              //胶片格式
        private decimal? _light_leak = 2;               //漏光
        private decimal? _strip_shadow = 10;            //条状伪影
        private decimal? _ctn = 10;                     //CT值
        private decimal? _fast_consult = 8;             //快速调阅
        private decimal? _device_shadow = 7;            //设备伪影
        private decimal? _nick = 2;                     //划痕
        private decimal? _water_mark = 2;               //水迹
        private decimal? _finger_mark = 2;              //指纹
        private decimal? _static_shadow = 2;            //静电阴影
		/// <summary>
		/// 
		/// </summary>
		public string EXAM_ACCESSION_NUM
		{
			set{ _exam_accession_num=value;}
			get{return _exam_accession_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PATIENT_LOCAL_ID
		{
			set{ _patient_local_id=value;}
			get{return _patient_local_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? QC_DATE
		{
			set{ _qc_date=value;}
			get{return _qc_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PATIENT_ID
		{
			set{ _patient_id=value;}
			get{return _patient_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PATIENT_NAME
		{
			set{ _patient_name=value;}
			get{return _patient_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PATIENT_SEX
		{
			set{ _patient_sex=value;}
			get{return _patient_sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? STUDY_DATE_TIME
		{
			set{ _study_date_time=value;}
			get{return _study_date_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? POSTURE_CHOICE
		{
			set{ _posture_choice=value;}
			get{return _posture_choice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SCANNING_SCOPE
		{
			set{ _scanning_scope=value;}
			get{return _scanning_scope;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? VISCERA_SCANNING
		{
			set{ _viscera_scanning=value;}
			get{return _viscera_scanning;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SCANNING_MODE
		{
			set{ _scanning_mode=value;}
			get{return _scanning_mode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? RESOLUTION
		{
			set{ _resolution=value;}
			get{return _resolution;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? INF_CRITERION
		{
			set{ _inf_criterion=value;}
			get{return _inf_criterion;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? WL_WWIDTH
		{
			set{ _wl_wwidth=value;}
			get{return _wl_wwidth;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? EXTERNA_BREATH_SHADOW
		{
			set{ _externa_breath_shadow=value;}
			get{return _externa_breath_shadow;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TOTAL_SCORE
		{
			set{ _total_score=value;}
			get{return _total_score;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DISTINCTION
		{
			set{ _distinction=value;}
			get{return _distinction;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? NUMBER_KEY
		{
			set{ _number_key=value;}
			get{return _number_key;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? BASE_ASH_FOG_VALUE
		{
			set{ _base_ash_fog_value=value;}
			get{return _base_ash_fog_value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? BLANK_EXPOSAL_DENSITY
		{
			set{ _blank_exposal_density=value;}
			get{return _blank_exposal_density;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? FILM_FORMAT
		{
			set{ _film_format=value;}
			get{return _film_format;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? LIGHT_LEAK
		{
			set{ _light_leak=value;}
			get{return _light_leak;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? STRIP_SHADOW
		{
			set{ _strip_shadow=value;}
			get{return _strip_shadow;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? CTN
		{
			set{ _ctn=value;}
			get{return _ctn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? FAST_CONSULT
		{
			set{ _fast_consult=value;}
			get{return _fast_consult;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DEVICE_SHADOW
		{
			set{ _device_shadow=value;}
			get{return _device_shadow;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? NICK
		{
			set{ _nick=value;}
			get{return _nick;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? WATER_MARK
		{
			set{ _water_mark=value;}
			get{return _water_mark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? FINGER_MARK
		{
			set{ _finger_mark=value;}
			get{return _finger_mark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? STATIC_SHADOW
		{
			set{ _static_shadow=value;}
			get{return _static_shadow;}
		}
		#endregion Model

	}
}

