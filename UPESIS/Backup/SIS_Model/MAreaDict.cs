using System;
using System.Text;

namespace SIS_Model
{
    /// <summary>
	/// 实体类AREA_DICT，行政区表
	/// </summary>
	[Serializable]
    public class MAreaDict : ILL.IModel
	{
        public MAreaDict()
		{}
		#region Model
		private string _area_code;  //行政区代码
		private string _area_name;  //行政区名称
		private string _input_code; //输入简码

		/// <summary>
		/// 行政区代码
		/// </summary>
		public string AREA_CODE
		{
			set{ _area_code=value;}
			get{return _area_code;}
		}

		/// <summary>
		/// 行政区名称
		/// </summary>
		public string AREA_NAME
		{
			set{ _area_name=value;}
			get{return _area_name;}
		}

		/// <summary>
		/// 输入简码
		/// </summary>
		public string INPUT_CODE
		{
			set{ _input_code=value;}
			get{return _input_code;}
		}
		#endregion Model
    }

}