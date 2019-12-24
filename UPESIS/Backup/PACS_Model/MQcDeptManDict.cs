using System;
using ILL;
namespace PACS_Model
{
	/// <summary>
	/// 实体类QC_DEPT_MAN_DICT 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public class MQcDeptManDict : IModel
	{
        public MQcDeptManDict()
		{}
		#region Model
		private string _dept_man_key;
		private DateTime? _qc_date;
        private decimal? _ry_licence = 10;                        //放射科许可证
		private string _dedu_gist_ry_licence;
        private decimal? _titles = 5;                             //职称
		private string _dedu_gist_titles;
        private decimal? _post_train = 5;                     //岗位培训
		private string _dedu_gist_post_train;
        private decimal? _criterion_integrality = 10;             //规范完整性
		private string _dedu_gist_cri_int;
        private decimal? _management_system = 10;                 //管理制度
		private string _dedu_gist_man_sys;
        private decimal? _image_system = 10;                      //影像制度
		private string _dedu_gist_image_sys;
        private decimal? _preventive_measure = 10;             //防护措施
		private string _dedu_gist_pre_mea;
        private decimal? _services_items = 5;                              //服务项目
		private string _dedu_gist_ser_items;
        private decimal? _emergency_exam = 5;                          //急诊检查
		private string _dedu_gist_eme_exam;
        private decimal? _diag_report = 10;                   //诊断报告
		private string _dedu_gist_diag_rpt;
        private decimal? _management = 5;                     //管理小组
		private string _dedu_gist_management;
        private decimal? _register_stat = 10;                      //记录统计
		private string _dedu_gist_reg_stat;
        private decimal? _oversee_result = 5;                 //督查结果
		private string _dedu_gist_os_res;
		/// <summary>
		/// 
		/// </summary>
		public string DEPT_MAN_KEY
		{
			set{ _dept_man_key=value;}
			get{return _dept_man_key;}
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
		public decimal? RY_LICENCE
		{
			set{ _ry_licence=value;}
			get{return _ry_licence;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DEDU_GIST_RY_LICENCE
		{
			set{ _dedu_gist_ry_licence=value;}
			get{return _dedu_gist_ry_licence;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TITLES
		{
			set{ _titles=value;}
			get{return _titles;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DEDU_GIST_TITLES
		{
			set{ _dedu_gist_titles=value;}
			get{return _dedu_gist_titles;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? POST_TRAIN
		{
			set{ _post_train=value;}
			get{return _post_train;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DEDU_GIST_POST_TRAIN
		{
			set{ _dedu_gist_post_train=value;}
			get{return _dedu_gist_post_train;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? CRITERION_INTEGRALITY
		{
			set{ _criterion_integrality=value;}
			get{return _criterion_integrality;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DEDU_GIST_CRI_INT
		{
			set{ _dedu_gist_cri_int=value;}
			get{return _dedu_gist_cri_int;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MANAGEMENT_SYSTEM
		{
			set{ _management_system=value;}
			get{return _management_system;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DEDU_GIST_MAN_SYS
		{
			set{ _dedu_gist_man_sys=value;}
			get{return _dedu_gist_man_sys;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? IMAGE_SYSTEM
		{
			set{ _image_system=value;}
			get{return _image_system;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DEDU_GIST_IMAGE_SYS
		{
			set{ _dedu_gist_image_sys=value;}
			get{return _dedu_gist_image_sys;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PREVENTIVE_MEASURE
		{
			set{ _preventive_measure=value;}
			get{return _preventive_measure;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DEDU_GIST_PRE_MEA
		{
			set{ _dedu_gist_pre_mea=value;}
			get{return _dedu_gist_pre_mea;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SERVICES_ITEMS
		{
			set{ _services_items=value;}
			get{return _services_items;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DEDU_GIST_SER_ITEMS
		{
			set{ _dedu_gist_ser_items=value;}
			get{return _dedu_gist_ser_items;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? EMERGENCY_EXAM
		{
			set{ _emergency_exam=value;}
			get{return _emergency_exam;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DEDU_GIST_EME_EXAM
		{
			set{ _dedu_gist_eme_exam=value;}
			get{return _dedu_gist_eme_exam;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DIAG_REPORT
		{
			set{ _diag_report=value;}
			get{return _diag_report;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DEDU_GIST_DIAG_RPT
		{
			set{ _dedu_gist_diag_rpt=value;}
			get{return _dedu_gist_diag_rpt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MANAGEMENT
		{
			set{ _management=value;}
			get{return _management;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DEDU_GIST_MANAGEMENT
		{
			set{ _dedu_gist_management=value;}
			get{return _dedu_gist_management;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? REGISTER_STAT
		{
			set{ _register_stat=value;}
			get{return _register_stat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DEDU_GIST_REG_STAT
		{
			set{ _dedu_gist_reg_stat=value;}
			get{return _dedu_gist_reg_stat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OVERSEE_RESULT
		{
			set{ _oversee_result=value;}
			get{return _oversee_result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DEDU_GIST_OS_RES
		{
			set{ _dedu_gist_os_res=value;}
			get{return _dedu_gist_os_res;}
		}
		#endregion Model

	}
}

