using System;
using System.Collections.Generic;
using System.Text;
using ILL;

namespace PACS_Model
{
	/// <summary>
	/// ʵ����QC_MRI ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
    public class MQcMri : IModel
	{
        public MQcMri()
		{}
		#region Model
		private string _exam_accession_num;
		private string _patient_local_id;
		private DateTime? _qc_date;
		private string _patient_id;
		private string _patient_name;
		private string _patient_sex;
		private DateTime? _study_date_time;
        private decimal? _posture_choice = 10;     //��λѡ��
        private decimal? _scanning_scope = 10;        //ɨ�跶Χ
        private decimal? _viscera_scanning = 10;      //����ɨ��
        private decimal? _resolution = 15;        //������
        private decimal? _inf_criterion = 5;           //��Ϣ�淶
        private decimal? _series_level_number = 10;    //���в���
        private decimal? _externa_metal_shadow = 5;       //�������αӰ
        private decimal? _total_score = 100;      //�ܷ�
		private int? _distinction=1;
		private int? _number_key;
        private decimal? _base_ash_fog_value = 10;        //���������ܶ�
        private decimal? _brim_background_density = 10;       //��Ե�������ܶ�
        private decimal? _film_format = 5;         //��Ƭ��ʽ
        private decimal? _ope_result = 5;         //�������
        private decimal? _structure_resolution = 10;  //�ṹ����
        private decimal? _hist_contrast = 10;      //��֯�Աȶ�
        private decimal? _fast_consult = 5;        //���ٵ���
        private decimal? _device_shadow = 5;      //�豸αӰ
        private decimal? _scanning_mode = 5;   //ɨ�跽ʽ
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
		public decimal? SERIES_LEVEL_NUMBER
		{
			set{ _series_level_number=value;}
			get{return _series_level_number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? EXTERNA_METAL_SHADOW
		{
			set{ _externa_metal_shadow=value;}
			get{return _externa_metal_shadow;}
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
		public decimal? BRIM_BACKGROUND_DENSITY
		{
			set{ _brim_background_density=value;}
			get{return _brim_background_density;}
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
		public decimal? OPE_RESULT
		{
			set{ _ope_result=value;}
			get{return _ope_result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? STRUCTURE_RESOLUTION
		{
			set{ _structure_resolution=value;}
			get{return _structure_resolution;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? HIST_CONTRAST
		{
			set{ _hist_contrast=value;}
			get{return _hist_contrast;}
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
		public decimal? SCANNING_MODE
		{
			set{ _scanning_mode=value;}
			get{return _scanning_mode;}
		}
		#endregion Model

	}
}

