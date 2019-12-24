using System;
using System.Collections.Generic;
using System.Text;
using ILL;
namespace PACS_Model
{
	/// <summary>
	/// ʵ����QC_DIGITAL_IMAGE ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
    public class MQcDigitalImage : IModel
	{
		public MQcDigitalImage()
		{}
		#region Model
		private string _exam_accession_num;
		private string _patient_local_id;
		private DateTime? _qc_date;
		private string _patient_id;
		private string _patient_name;
		private string _patient_sex;
		private DateTime? _study_date_time;
        private decimal? _sternum_breast = 10;                  //�ز�Ͷ��
        private decimal? _sternum_bladebone = 5;                //���ι�Ͷ��
        private decimal? _sternum_board = 7;                     //�粿����֯
        private decimal? _sternum_image_distortion = 8;         //Ӱ��ʧ�����
        private decimal? _sternum_arrangement_focus = 10;       //�������
        private decimal? _sternum_lung_markings = 10;           //������
        private decimal? _sternum_device_shadow = 5;            //�豸αӰ
        private decimal? _ugi_projection_case = 5;              //Ͷ�����
        private decimal? _ugi_indication_range = 5;             //��ʾ��Χ
        private decimal? _ugi_photographs_enough = 15;          //��Ƭ����ȫ
        private decimal? _ugi_cavity_line = 5;                  //ǻ����
        private decimal? _ugi_bleb = 5;                         //����
        private decimal? _ugi_flocculence = 5;                  //����
        private decimal? _ugi_mucosal_fold = 5;                 //ճĤ����
        private decimal? _ugi_contrast = 5;                     //�Աȶ�
        private decimal? _ugi_device_shadow = 5;                //�豸αӰ
        private decimal? _ivp_film_posture_place = 10;          //��Ӱ��λ��λ��
        private decimal? _ivp_projection_centrage = 5;          //Ͷ��������
        private decimal? _ivp_photographs_enough = 10;          //��Ƭ����ȫ
        private decimal? _ivp_resolution = 10;              //�ֱ��
        private decimal? _ivp_hist_contrast = 10;           //��֯�Աȶ�
        private decimal? _ivp_device_shadow = 5;            //�豸αӰ 
        private decimal? _knuckle_projection = 10;          //ϥ�ؽ�Ͷ��
        private decimal? _knuckle_long_axis_parallel = 7;   //����ƽ��
        private decimal? _knuckle_wrap = 5;                 //�ص�
        private decimal? _knuckle_image_distortion = 8;     //Ӱ��ʧ�����
        private decimal? _knuckle_resolution = 10;          //�ֱ��
        private decimal? _knuckle_arrangement_focus = 10;   //�������
        private decimal? _knuckle_device_shadow = 5;        //�豸αӰ
        private decimal? _exposure_dose = 20;               //�ع����
        private decimal? _flag_content = 10;                 //��ʶ����
        private decimal? _flag_place_arrange = 10;          //��ʶλ�ú�����
        private decimal? _externa_shadow = 5;               //����αӰ
		private decimal? _total_score=100;
        private int ? _distinction = 1;
		private decimal? _number_key;
             
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
		public decimal? STERNUM_LUNG_MARKINGS
		{
			set{ _sternum_lung_markings=value;}
			get{return _sternum_lung_markings;}
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
		public decimal? IVP_RESOLUTION
		{
			set{ _ivp_resolution=value;}
			get{return _ivp_resolution;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? IVP_HIST_CONTRAST
		{
			set{ _ivp_hist_contrast=value;}
			get{return _ivp_hist_contrast;}
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
		public decimal? EXPOSURE_DOSE
		{
			set{ _exposure_dose=value;}
			get{return _exposure_dose;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? FLAG_CONTENT
		{
			set{ _flag_content=value;}
			get{return _flag_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? FLAG_PLACE_ARRANGE
		{
			set{ _flag_place_arrange=value;}
			get{return _flag_place_arrange;}
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
		public decimal? STERNUM_DEVICE_SHADOW
		{
			set{ _sternum_device_shadow=value;}
			get{return _sternum_device_shadow;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? UGI_DEVICE_SHADOW
		{
			set{ _ugi_device_shadow=value;}
			get{return _ugi_device_shadow;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? IVP_DEVICE_SHADOW
		{
			set{ _ivp_device_shadow=value;}
			get{return _ivp_device_shadow;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? KNUCKLE_DEVICE_SHADOW
		{
			set{ _knuckle_device_shadow=value;}
			get{return _knuckle_device_shadow;}
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

