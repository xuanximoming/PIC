using System;
namespace SIS_Model
{
	/// <summary>
	/// 实体类--CHARGE_CLASS，收费类别
	/// </summary>
	[Serializable]
    public class MChargeClass : ILL.IModel
	{
		public MChargeClass()
		{}
		#region Model
		private int? _charge_class_id;  //收费类别ID
		private string _charge_class;   //收费类别名
        private decimal? _charge_ratio; //收费百分比

		/// <summary>
		/// 收费类别ID
		/// </summary>
		public int? CHARGE_CLASS_ID
		{
			set{ _charge_class_id=value;}
			get{return _charge_class_id;}
		}

		/// <summary>
		/// 收费类别名
		/// </summary>
		public string CHARGE_CLASS
		{
			set{ _charge_class=value;}
			get{return _charge_class;}
		}

        /// <summary>
		///收费百分比 
		/// </summary>
        public decimal? CHARGE_RATIO
		{
            set { _charge_ratio = value; }
            get { return _charge_ratio; }
		} 
		#endregion Model

	}
}