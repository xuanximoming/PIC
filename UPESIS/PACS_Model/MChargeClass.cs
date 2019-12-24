using System;
namespace PACS_Model
{
	/// <summary>
	/// ʵ����--CHARGE_CLASS���շ����
	/// </summary>
	[Serializable]
    public class MChargeClass : ILL.IModel
	{
		public MChargeClass()
		{}
		#region Model
		private int? _charge_type_code; //�շ����ʹ���
		private string _charge_type;    //�շ���������
        private decimal? _charge_ratio; //
		/// <summary>
		/// 
		/// </summary>
		public int? CHARGE_TYPE_CODE
		{
			set{ _charge_type_code=value;}
			get{return _charge_type_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CHARGE_TYPE
		{
			set{ _charge_type=value;}
			get{return _charge_type;}
		}
        /// <summary>
		/// 
		/// </summary>
        public decimal? CHARGE_RATIO
		{
            set { _charge_ratio = value; }
            get { return _charge_ratio; }
		} 
		#endregion Model

	}
}