using System;
namespace PACS_Model
{
	/// <summary>
	/// ʵ����DEPT_ VS_QUEUE���Ŷ�����Ҷ��ձ�
	/// </summary>
	[Serializable]
    public class MDeptVsQueue : ILL.IModel
	{
		public MDeptVsQueue()
		{}
		#region Model
		private int? _queue_id;     //����ID
		private string _dept_code;  //���Ҵ���
		private string _queue_name; //������������Ӧ����

		/// <summary>
		/// ����ID
		/// </summary>
		public int? QUEUE_ID
		{
			set{ _queue_id=value;}
			get{return _queue_id;}
		}

		/// <summary>
		/// ���Ҵ���
		/// </summary>
		public string DEPT_CODE
		{
			set{ _dept_code=value;}
			get{return _dept_code;}
		}

		/// <summary>
		/// ��������������
		/// </summary>
		public string QUEUE_NAME
		{
			set{ _queue_name=value;}
			get{return _queue_name;}
		}

		#endregion Model
	}
}