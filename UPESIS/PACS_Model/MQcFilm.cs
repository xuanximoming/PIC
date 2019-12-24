using System;
using System.Collections.Generic;
using System.Text;
using ILL;

namespace PACS_Model
{
	/// <summary>
	/// 实体类QC_FILM 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public class MQcFilm : IModel
	{
        public MQcFilm()
		{}
		#region Model
		private string _exam_accession_num;
		private string _patient_local_id;
		private DateTime? _qc_date;
		private string _patient_id;
		private string _patient_name;
		private string _patient_sex;
		private DateTime? _study_date_time;
        private decimal? _sternum_breast = 10;                  //胸部投照
        private decimal? _sternum_bladebone = 5;                //肩胛骨投照
        private decimal? _sternum_board = 7;                    //肩部软组织
        private decimal? _sternum_image_distortion = 8;         //影像失真变形
        private decimal? _sternum_arrangement_focus = 10;       //层次清晰
        private decimal? _sternum_first_forth_whettle = 10;     //第1-4胸椎及心影后肋骨
        private decimal? _sternum_letter_no = 5;                //铅字号码
        private decimal? _sternum_letter_arrange = 5;           //铅字顺序
        private decimal? _ugi_projection_case = 5;              //投照情况
        private decimal? _ugi_indication_range = 5;             //显示范围
        private decimal? _ugi_photographs_enough = 15;          //摄片数齐全
        private decimal? _ugi_cavity_line=5;                    //腔壁线
        private decimal? _ugi_bleb = 5;                         //气泡
        private decimal? _ugi_flocculence = 5;                  //凝絮
        private decimal? _ugi_mucosal_fold = 5;                 //粘膜皱襞
        private decimal? _ugi_contrast = 5;                     //对比度
        private decimal? _ugi_inf_criterion = 5;               //信息规范
		private decimal? _ivp_film_posture_place=10;            //摄影体位及位置
        private decimal? _ivp_projection_centrage = 5;          //投照中心线
        private decimal? _ivp_photographs_enough = 10;          //摄片数齐全
        private decimal? _ivp_develop = 10;                     //显影
        private decimal? _ivp_contrast = 10;                    //对比度
        private decimal? _ivp_letter_no = 5;                    //铅字号码
        private decimal? _ivp_letter_arrange = 10;              //铅字顺序
        private decimal? _knuckle_projection = 10;              //膝关节投照
        private decimal? _knuckle_long_axis_parallel = 7;       //长轴平行
        private decimal? _knuckle_wrap = 5;                     //重叠
        private decimal? _knuckle_image_distortion = 8;         //影像失真变形
        private decimal? _knuckle_resolution = 10;              //分辨度
        private decimal? _knuckle_arrangement_focus = 10;       //层次清晰
        private decimal? _knuckle_letter_arrange = 10;          //铅字顺序
        private decimal? _base_ash_fog_value = 10;              //基础灰雾密度
        private decimal? _diagnose_area_value = 5;              //诊断区域密度
        private decimal? _blank_exposal_density = 5;            //空曝射区密度
        private decimal? _dirt=2;                       //污片
        private decimal? _nick = 2;                     //划痕
        private decimal? _adhibit = 2;                  //粘片
        private decimal? _water_mark = 2;               //水迹
        private decimal? _finger_mark = 2;              //指纹
        private decimal? _static_shadow = 2;            //静电阴影
        private decimal? _externa_shadow = 3;           //体外伪影
		private decimal? _total_score=100;
        private int? _distinction = 1;
		private decimal? _number_key;
        private decimal? _light_leak = 3;               //漏光
		private decimal? _ugi_patient_type;
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
		public decimal? STERNUM_BREAST
		{
			set{ _sternum_breast=value;}
			get{return _sternum_breast;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? STERNUM_BLADEBONE
		{
			set{ _sternum_bladebone=value;}
			get{return _sternum_bladebone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? STERNUM_BOARD
		{
			set{ _sternum_board=value;}
			get{return _sternum_board;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? STERNUM_IMAGE_DISTORTION
		{
			set{ _sternum_image_distortion=value;}
			get{return _sternum_image_distortion;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? STERNUM_ARRANGEMENT_FOCUS
		{
			set{ _sternum_arrangement_focus=value;}
			get{return _sternum_arrangement_focus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? STERNUM_FIRST_FORTH_WHETTLE
		{
			set{ _sternum_first_forth_whettle=value;}
			get{return _sternum_first_forth_whettle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? STERNUM_LETTER_NO
		{
			set{ _sternum_letter_no=value;}
			get{return _sternum_letter_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? STERNUM_LETTER_ARRANGE
		{
			set{ _sternum_letter_arrange=value;}
			get{return _sternum_letter_arrange;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? UGI_PROJECTION_CASE
		{
			set{ _ugi_projection_case=value;}
			get{return _ugi_projection_case;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? UGI_INDICATION_RANGE
		{
			set{ _ugi_indication_range=value;}
			get{return _ugi_indication_range;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? UGI_PHOTOGRAPHS_ENOUGH
		{
			set{ _ugi_photographs_enough=value;}
			get{return _ugi_photographs_enough;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? UGI_CAVITY_LINE
		{
			set{ _ugi_cavity_line=value;}
			get{return _ugi_cavity_line;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? UGI_BLEB
		{
			set{ _ugi_bleb=value;}
			get{return _ugi_bleb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? UGI_FLOCCULENCE
		{
			set{ _ugi_flocculence=value;}
			get{return _ugi_flocculence;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? UGI_MUCOSAL_FOLD
		{
			set{ _ugi_mucosal_fold=value;}
			get{return _ugi_mucosal_fold;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? UGI_CONTRAST
		{
			set{ _ugi_contrast=value;}
			get{return _ugi_contrast;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? UGI_INF_CRITERION
		{
			set{ _ugi_inf_criterion=value;}
			get{return _ugi_inf_criterion;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? IVP_FILM_POSTURE_PLACE
		{
			set{ _ivp_film_posture_place=value;}
			get{return _ivp_film_posture_place;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? IVP_PROJECTION_CENTRAGE
		{
			set{ _ivp_projection_centrage=value;}
			get{return _ivp_projection_centrage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? IVP_PHOTOGRAPHS_ENOUGH
		{
			set{ _ivp_photographs_enough=value;}
			get{return _ivp_photographs_enough;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? IVP_DEVELOP
		{
			set{ _ivp_develop=value;}
			get{return _ivp_develop;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? IVP_CONTRAST
		{
			set{ _ivp_contrast=value;}
			get{return _ivp_contrast;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? IVP_LETTER_NO
		{
			set{ _ivp_letter_no=value;}
			get{return _ivp_letter_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? IVP_LETTER_ARRANGE
		{
			set{ _ivp_letter_arrange=value;}
			get{return _ivp_letter_arrange;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? KNUCKLE_PROJECTION
		{
			set{ _knuckle_projection=value;}
			get{return _knuckle_projection;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? KNUCKLE_LONG_AXIS_PARALLEL
		{
			set{ _knuckle_long_axis_parallel=value;}
			get{return _knuckle_long_axis_parallel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? KNUCKLE_WRAP
		{
			set{ _knuckle_wrap=value;}
			get{return _knuckle_wrap;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? KNUCKLE_IMAGE_DISTORTION
		{
			set{ _knuckle_image_distortion=value;}
			get{return _knuckle_image_distortion;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? KNUCKLE_RESOLUTION
		{
			set{ _knuckle_resolution=value;}
			get{return _knuckle_resolution;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? KNUCKLE_ARRANGEMENT_FOCUS
		{
			set{ _knuckle_arrangement_focus=value;}
			get{return _knuckle_arrangement_focus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? KNUCKLE_LETTER_ARRANGE
		{
			set{ _knuckle_letter_arrange=value;}
			get{return _knuckle_letter_arrange;}
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
		public decimal? DIAGNOSE_AREA_VALUE
		{
			set{ _diagnose_area_value=value;}
			get{return _diagnose_area_value;}
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
		public decimal? DIRT
		{
			set{ _dirt=value;}
			get{return _dirt;}
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
		public decimal? ADHIBIT
		{
			set{ _adhibit=value;}
			get{return _adhibit;}
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
		/// <summary>
		/// 
		/// </summary>
		public decimal? EXTERNA_SHADOW
		{
			set{ _externa_shadow=value;}
			get{return _externa_shadow;}
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
		public decimal? NUMBER_KEY
		{
			set{ _number_key=value;}
			get{return _number_key;}
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
		public decimal? UGI_PATIENT_TYPE
		{
			set{ _ugi_patient_type=value;}
			get{return _ugi_patient_type;}
		}
		#endregion Model

	}
}

