using System;
using System.Text;

namespace SIS_Model
{
    /// <summary>
	/// ʵ����AREA_DICT����������
	/// </summary>
	[Serializable]
    public class MAreaDict : ILL.IModel
	{
        public MAreaDict()
		{}
		#region Model
		private string _area_code;  //����������
		private string _area_name;  //����������
		private string _input_code; //�������

		/// <summary>
		/// ����������
		/// </summary>
		public string AREA_CODE
		{
			set{ _area_code=value;}
			get{return _area_code;}
		}

		/// <summary>
		/// ����������
		/// </summary>
		public string AREA_NAME
		{
			set{ _area_name=value;}
			get{return _area_name;}
		}

		/// <summary>
		/// �������
		/// </summary>
		public string INPUT_CODE
		{
			set{ _input_code=value;}
			get{return _input_code;}
		}
		#endregion Model
    }

}