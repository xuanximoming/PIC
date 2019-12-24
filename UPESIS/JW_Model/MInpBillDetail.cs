using System;
namespace JW_Model
{
    /// <summary>
    /// 实体类INP_BILL_DETAIL 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class MInpBillDetail : ILL.IModel
    {
        public MInpBillDetail()
        { }
        #region Model
        private string _patient_id;
        private int _visit_id;
        private int _item_no;
        private string _item_class;
        private string _item_name;
        private string _item_code;
        private string _item_spec;
        private int _amount;
        private string _units;
        private string _ordered_by;
        private string _performed_by;
        private int _costs;
        private int _charges;
        private DateTime _billing_date_time;
        private string _operator_no;
        private string _rcpt_no;
        private int _price;
        /// <summary>
        /// 
        /// </summary>
        public string PATIENT_ID
        {
            set { _patient_id = value; }
            get { return _patient_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int VISIT_ID
        {
            set { _visit_id = value; }
            get { return _visit_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ITEM_NO
        {
            set { _item_no = value; }
            get { return _item_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ITEM_CLASS
        {
            set { _item_class = value; }
            get { return _item_class; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ITEM_NAME
        {
            set { _item_name = value; }
            get { return _item_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ITEM_CODE
        {
            set { _item_code = value; }
            get { return _item_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ITEM_SPEC
        {
            set { _item_spec = value; }
            get { return _item_spec; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AMOUNT
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UNITS
        {
            set { _units = value; }
            get { return _units; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ORDERED_BY
        {
            set { _ordered_by = value; }
            get { return _ordered_by; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PERFORMED_BY
        {
            set { _performed_by = value; }
            get { return _performed_by; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int COSTS
        {
            set { _costs = value; }
            get { return _costs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CHARGES
        {
            set { _charges = value; }
            get { return _charges; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime BILLING_DATE_TIME
        {
            set { _billing_date_time = value; }
            get { return _billing_date_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OPERATOR_NO
        {
            set { _operator_no = value; }
            get { return _operator_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RCPT_NO
        {
            set { _rcpt_no = value; }
            get { return _rcpt_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PRICE
        {
            set { _price = value; }
            get { return _price; }
        }
        #endregion Model

    }
}

