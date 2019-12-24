using System;
using ILL;
namespace PACS_Model
{
	/// <summary>
	/// ʵ����DEPT_DATA_DICT�����������ֵ䣬�������ʿط����
	/// </summary>
	[Serializable]
    public class MDeptDataDict : IModel
	{
        public MDeptDataDict()
		{}
		#region Model
		private string _dept_code;              //���Ҵ���
		private string _data_type;              //��������
		private string _data_name;              //��������
		private DateTime? _modify_date_time;    //�޸�����ʱ��
		private DateTime? _create_date_time;    //��������ʱ��
		private string _author;                 //����
        private string _data;                   //����

		/// <summary>
		///���Ҵ��� 
		/// </summary>
		public string DEPT_CODE
		{
			set{ _dept_code=value;}
			get{return _dept_code;}
		}

		/// <summary>
		/// ��������
		/// </summary>
		public string DATA_TYPE
		{
			set{ _data_type=value;}
			get{return _data_type;}
		}

		/// <summary>
		/// ��������
		/// </summary>
		public string DATA_NAME
		{
			set{ _data_name=value;}
			get{return _data_name;}
		}

		/// <summary>
		/// �޸�����ʱ��
		/// </summary>
		public DateTime? MODIFY_DATE_TIME
		{
			set{ _modify_date_time=value;}
			get{return _modify_date_time;}
		}

		/// <summary>
		/// ��������ʱ��
		/// </summary>
		public DateTime? CREATE_DATE_TIME
		{
			set{ _create_date_time=value;}
			get{return _create_date_time;}
		}

		/// <summary>
		/// ����
		/// </summary>
		public string AUTHOR
		{
			set{ _author=value;}
			get{return _author;}
		}

		/// <summary>
		/// ����
		/// </summary>
		public string  DATA
		{
			set{ _data=value;}
			get{return _data;}
		}

		#endregion Model
	}
}