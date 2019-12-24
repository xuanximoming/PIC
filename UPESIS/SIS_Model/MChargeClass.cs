using System;
namespace SIS_Model
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
		private int? _charge_class_id;  //�շ����ID
		private string _charge_class;   //�շ������
        private decimal? _charge_ratio; //�շѰٷֱ�

		/// <summary>
		/// �շ����ID
		/// </summary>
		public int? CHARGE_CLASS_ID
		{
			set{ _charge_class_id=value;}
			get{return _charge_class_id;}
		}

		/// <summary>
		/// �շ������
		/// </summary>
		public string CHARGE_CLASS
		{
			set{ _charge_class=value;}
			get{return _charge_class;}
		}

        /// <summary>
		///�շѰٷֱ� 
		/// </summary>
        public decimal? CHARGE_RATIO
		{
            set { _charge_ratio = value; }
            get { return _charge_ratio; }
		} 
		#endregion Model

	}
}