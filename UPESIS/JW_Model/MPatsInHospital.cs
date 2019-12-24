using System;
namespace JW_Model
{
    /// <summary>
    /// 实体类PATS_IN_HOSPITAL 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class MPatsInHospital : ILL.IModel
    {
        public MPatsInHospital()
        { }
        #region Model
        private string _patient_id;
        private int _visit_id;
        private string _ward_code;
        private string _dept_code;
        private int _bed_no;
        private DateTime _admission_date_time;
        private DateTime _adm_ward_date_time;
        private string _diagnosis;
        private string _patient_condition;
        private string _nursing_class;
        private string _doctor_in_charge;
        private DateTime _operating_date;
        private DateTime _billing_date_time;
        private int _prepayments;
        private int _total_costs;
        private int _total_charges;
        private string _guarantor;
        private string _guarantor_org;
        private string _guarantor_phone_num;
        private DateTime _bill_checked_date_time;
        private int _settled_indicator;
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
        public string WARD_CODE
        {
            set { _ward_code = value; }
            get { return _ward_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DEPT_CODE
        {
            set { _dept_code = value; }
            get { return _dept_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int BED_NO
        {
            set { _bed_no = value; }
            get { return _bed_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ADMISSION_DATE_TIME
        {
            set { _admission_date_time = value; }
            get { return _admission_date_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ADM_WARD_DATE_TIME
        {
            set { _adm_ward_date_time = value; }
            get { return _adm_ward_date_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DIAGNOSIS
        {
            set { _diagnosis = value; }
            get { return _diagnosis; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PATIENT_CONDITION
        {
            set { _patient_condition = value; }
            get { return _patient_condition; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NURSING_CLASS
        {
            set { _nursing_class = value; }
            get { return _nursing_class; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DOCTOR_IN_CHARGE
        {
            set { _doctor_in_charge = value; }
            get { return _doctor_in_charge; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime OPERATING_DATE
        {
            set { _operating_date = value; }
            get { return _operating_date; }
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
        public int PREPAYMENTS
        {
            set { _prepayments = value; }
            get { return _prepayments; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TOTAL_COSTS
        {
            set { _total_costs = value; }
            get { return _total_costs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TOTAL_CHARGES
        {
            set { _total_charges = value; }
            get { return _total_charges; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GUARANTOR
        {
            set { _guarantor = value; }
            get { return _guarantor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GUARANTOR_ORG
        {
            set { _guarantor_org = value; }
            get { return _guarantor_org; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GUARANTOR_PHONE_NUM
        {
            set { _guarantor_phone_num = value; }
            get { return _guarantor_phone_num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime BILL_CHECKED_DATE_TIME
        {
            set { _bill_checked_date_time = value; }
            get { return _bill_checked_date_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SETTLED_INDICATOR
        {
            set { _settled_indicator = value; }
            get { return _settled_indicator; }
        }
        #endregion Model

    }
}






















