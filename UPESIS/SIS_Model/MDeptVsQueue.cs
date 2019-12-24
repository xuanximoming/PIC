using System;
namespace SIS_Model
{
	/// <summary>
	/// 实体类DEPT_ VS_QUEUE，排队与科室对照
	/// </summary>
	[Serializable]
    public class MDeptVsQueue : ILL.IModel
	{
		public MDeptVsQueue()
		{}
		#region Model
		private int? _queue_id;     //队列ID
		private string _dept_code;  //所属科室代码
		private string _queue_name; //队列名，对应诊室名

		/// <summary>
		///队列ID 
		/// </summary>
		public int? QUEUE_ID
		{
			set{ _queue_id=value;}
			get{return _queue_id;}
		}

		/// <summary>
		/// 所属科室代码
		/// </summary>
		public string DEPT_CODE
		{
			set{ _dept_code=value;}
			get{return _dept_code;}
		}

		/// <summary>
		/// 队列名
		/// </summary>
		public string QUEUE_NAME
		{
			set{ _queue_name=value;}
			get{return _queue_name;}
		}
		#endregion Model

	}
}