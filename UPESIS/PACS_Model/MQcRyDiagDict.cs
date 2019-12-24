using System;
using System.Collections.Generic;
using System.Text;
using ILL;

namespace PACS_Model
{
	/// <summary>
	/// ʵ����QC_RY_DIAG_DICT ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
    public class MQcRyDiagDict : IModel
	{
        public MQcRyDiagDict()
		{}
		#region Model
		private string _exam_accession_num;
		private string _patient_local_id;
		private DateTime? _qc_date;
		private string _patient_id;
		private string _patient_name;
		private string _patient_sex;
		private DateTime? _study_date_time;
        private decimal? _drpt_name = 2;  //��ϲ�������
        private decimal? _drpt_sex = 2;   //����Ա�
        private decimal? _drpt_age = 2;       //�������
        private decimal? _drpt_number = 2;        //��Ϻű�
        private decimal? _drpt_local_id = 2;      //��ϼ���ʶ��
        private decimal? _drpt_film_date = 2;        //�����Ƭ����
        private decimal? _drpt_app_date = 2;          //��Ϻ�Ƭ����
        private decimal? _drpt_clin_diag = 2;         //����ٴ����
        private decimal? _drpt_exam_item = 2;         //��ϼ������
        private decimal? _drpt_exam_tec = 5;       //��ϼ�鷽��
        private decimal? _drpt_description = 5;       //���Ӱ��ѧ����
        private decimal? _drpt_impression = 5;         //���Ӱ��ѧ���
        private decimal? _drpt_transcriber = 5;       //��ϱ���ҽʦ
        private decimal? _inq_name = 1;       //��ò�������
        private decimal? _inq_sex = 1;         //����Ա�
        private decimal? _inq_age = 1;        //�������
        private decimal? _inq_number = 1;      //��úű�
        private decimal? _inq_local_id = 1;       //��ü���ʶ��
        private decimal? _inq_path_no = 2;        //��ò����
        private decimal? _inq_ope_date = 2;       //�����������
        private decimal? _inq_exam_item_diag = 6;     //��ü�����ƺ����
        private decimal? _inq_operation = 5;  //���������¼
        private decimal? _inq_path_description = 5;       //��ò�����������
        private decimal? _inq_path_doctor = 5;    //��ò���ҽʦ
        private decimal? _inq_doctor = 5; //�����
        private decimal? _qualitative = 10;     //����
        private decimal? _pitch = 10;     //��λ
        private decimal? _xr_positive_rate = 5;        //X�߻�������
        private decimal? _ct_positive_rate = 5;    //CT������
        private decimal? _mr_positive_rate = 5;   //MR������
        private decimal? _total_score = 100;    //�� ��
		private int? _distinction=1;
		private int? _number_key;
		private decimal? _drpt_rpt_date=2;      //��ϱ�������
        private decimal? _drpt_approver = 5;       //������ҽʦ
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
		public decimal? DRPT_NAME
		{
			set{ _drpt_name=value;}
			get{return _drpt_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DRPT_SEX
		{
			set{ _drpt_sex=value;}
			get{return _drpt_sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DRPT_AGE
		{
			set{ _drpt_age=value;}
			get{return _drpt_age;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DRPT_NUMBER
		{
			set{ _drpt_number=value;}
			get{return _drpt_number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DRPT_LOCAL_ID
		{
			set{ _drpt_local_id=value;}
			get{return _drpt_local_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DRPT_FILM_DATE
		{
			set{ _drpt_film_date=value;}
			get{return _drpt_film_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DRPT_APP_DATE
		{
			set{ _drpt_app_date=value;}
			get{return _drpt_app_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DRPT_CLIN_DIAG
		{
			set{ _drpt_clin_diag=value;}
			get{return _drpt_clin_diag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DRPT_EXAM_ITEM
		{
			set{ _drpt_exam_item=value;}
			get{return _drpt_exam_item;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DRPT_EXAM_TEC
		{
			set{ _drpt_exam_tec=value;}
			get{return _drpt_exam_tec;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DRPT_DESCRIPTION
		{
			set{ _drpt_description=value;}
			get{return _drpt_description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DRPT_IMPRESSION
		{
			set{ _drpt_impression=value;}
			get{return _drpt_impression;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DRPT_TRANSCRIBER
		{
			set{ _drpt_transcriber=value;}
			get{return _drpt_transcriber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? INQ_NAME
		{
			set{ _inq_name=value;}
			get{return _inq_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? INQ_SEX
		{
			set{ _inq_sex=value;}
			get{return _inq_sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? INQ_AGE
		{
			set{ _inq_age=value;}
			get{return _inq_age;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? INQ_NUMBER
		{
			set{ _inq_number=value;}
			get{return _inq_number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? INQ_LOCAL_ID
		{
			set{ _inq_local_id=value;}
			get{return _inq_local_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? INQ_PATH_NO
		{
			set{ _inq_path_no=value;}
			get{return _inq_path_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? INQ_OPE_DATE
		{
			set{ _inq_ope_date=value;}
			get{return _inq_ope_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? INQ_EXAM_ITEM_DIAG
		{
			set{ _inq_exam_item_diag=value;}
			get{return _inq_exam_item_diag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? INQ_OPERATION
		{
			set{ _inq_operation=value;}
			get{return _inq_operation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? INQ_PATH_DESCRIPTION
		{
			set{ _inq_path_description=value;}
			get{return _inq_path_description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? INQ_PATH_DOCTOR
		{
			set{ _inq_path_doctor=value;}
			get{return _inq_path_doctor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? INQ_DOCTOR
		{
			set{ _inq_doctor=value;}
			get{return _inq_doctor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? QUALITATIVE
		{
			set{ _qualitative=value;}
			get{return _qualitative;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PITCH
		{
			set{ _pitch=value;}
			get{return _pitch;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? XR_POSITIVE_RATE
		{
			set{ _xr_positive_rate=value;}
			get{return _xr_positive_rate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? CT_POSITIVE_RATE
		{
			set{ _ct_positive_rate=value;}
			get{return _ct_positive_rate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MR_POSITIVE_RATE
		{
			set{ _mr_positive_rate=value;}
			get{return _mr_positive_rate;}
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
		public decimal? DRPT_RPT_DATE
		{
			set{ _drpt_rpt_date=value;}
			get{return _drpt_rpt_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DRPT_APPROVER
		{
			set{ _drpt_approver=value;}
			get{return _drpt_approver;}
		}
		#endregion Model

	}
}

