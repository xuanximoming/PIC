using System;
using ILL;
namespace PACS_Model
{
	/// <summary>
	/// 实体类DEPT_DATA_DICT，科室数据字典，关联与质控方面的
	/// </summary>
	[Serializable]
    public class MDeptDataDict : IModel
	{
        public MDeptDataDict()
		{}
		#region Model
		private string _dept_code;              //科室代码
		private string _data_type;              //数据类型
		private string _data_name;              //数据名称
		private DateTime? _modify_date_time;    //修改日期时间
		private DateTime? _create_date_time;    //创建日期时间
		private string _author;                 //作者
        private string _data;                   //数据

		/// <summary>
		///科室代码 
		/// </summary>
		public string DEPT_CODE
		{
			set{ _dept_code=value;}
			get{return _dept_code;}
		}

		/// <summary>
		/// 数据类型
		/// </summary>
		public string DATA_TYPE
		{
			set{ _data_type=value;}
			get{return _data_type;}
		}

		/// <summary>
		/// 数据名称
		/// </summary>
		public string DATA_NAME
		{
			set{ _data_name=value;}
			get{return _data_name;}
		}

		/// <summary>
		/// 修改日期时间
		/// </summary>
		public DateTime? MODIFY_DATE_TIME
		{
			set{ _modify_date_time=value;}
			get{return _modify_date_time;}
		}

		/// <summary>
		/// 创建日期时间
		/// </summary>
		public DateTime? CREATE_DATE_TIME
		{
			set{ _create_date_time=value;}
			get{return _create_date_time;}
		}

		/// <summary>
		/// 作者
		/// </summary>
		public string AUTHOR
		{
			set{ _author=value;}
			get{return _author;}
		}

		/// <summary>
		/// 数据
		/// </summary>
		public string  DATA
		{
			set{ _data=value;}
			get{return _data;}
		}

		#endregion Model
	}
}