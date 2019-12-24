using System;
namespace JW_Model
{
    /// <summary>
    /// 实体类PAT_MASTER_INDEX 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class MPatMasterIndex : ILL.IModel
    {
        public MPatMasterIndex()
        { }
        #region Model
        private string _patient_id;
        private string _inp_no;
        private string _name;
        private string _name_phonetic;
        private string _sex;
        private DateTime _date_of_birth;
        private string _birth_place;
        private string _citizenship;
        private string _nation;
        private string _id_no;
        private string _identity;
        private string _charge_type;
        private string _unit_in_contract;
        private string _mailing_address;
        private string _zip_code;
        private string _phone_number_home;
        private string _phone_number_business;
        private string _next_of_kin;
        private string _relationship;
        private string _next_of_kin_addr;
        private string _next_of_kin_zip_code;
        private string _next_of_kin_phone;
        private DateTime _last_visit_date;
        private int _vip_indicator;
        private DateTime _create_date;
        private string _operator;
        private string _card_status;
        private string _rundcode;
        private string _cardno;
        private string _id;
        private string _zylsh;
        private string _insur_no;
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
        public string INP_NO
        {
            set { _inp_no = value; }
            get { return _inp_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NAME
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NAME_PHONETIC
        {
            set { _name_phonetic = value; }
            get { return _name_phonetic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SEX
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DATE_OF_BIRTH
        {
            set { _date_of_birth = value; }
            get { return _date_of_birth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BIRTH_PLACE
        {
            set { _birth_place = value; }
            get { return _birth_place; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CITIZENSHIP
        {
            set { _citizenship = value; }
            get { return _citizenship; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NATION
        {
            set { _nation = value; }
            get { return _nation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ID_NO
        {
            set { _id_no = value; }
            get { return _id_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IDENTITY
        {
            set { _identity = value; }
            get { return _identity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CHARGE_TYPE
        {
            set { _charge_type = value; }
            get { return _charge_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UNIT_IN_CONTRACT
        {
            set { _unit_in_contract = value; }
            get { return _unit_in_contract; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MAILING_ADDRESS
        {
            set { _mailing_address = value; }
            get { return _mailing_address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZIP_CODE
        {
            set { _zip_code = value; }
            get { return _zip_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PHONE_NUMBER_HOME
        {
            set { _phone_number_home = value; }
            get { return _phone_number_home; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PHONE_NUMBER_BUSINESS
        {
            set { _phone_number_business = value; }
            get { return _phone_number_business; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NEXT_OF_KIN
        {
            set { _next_of_kin = value; }
            get { return _next_of_kin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RELATIONSHIP
        {
            set { _relationship = value; }
            get { return _relationship; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NEXT_OF_KIN_ADDR
        {
            set { _next_of_kin_addr = value; }
            get { return _next_of_kin_addr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NEXT_OF_KIN_ZIP_CODE
        {
            set { _next_of_kin_zip_code = value; }
            get { return _next_of_kin_zip_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NEXT_OF_KIN_PHONE
        {
            set { _next_of_kin_phone = value; }
            get { return _next_of_kin_phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LAST_VISIT_DATE
        {
            set { _last_visit_date = value; }
            get { return _last_visit_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int VIP_INDICATOR
        {
            set { _vip_indicator = value; }
            get { return _vip_indicator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CREATE_DATE
        {
            set { _create_date = value; }
            get { return _create_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OPERATOR
        {
            set { _operator = value; }
            get { return _operator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CARD_STATUS
        {
            set { _card_status = value; }
            get { return _card_status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RUNDCODE
        {
            set { _rundcode = value; }
            get { return _rundcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CARDNO
        {
            set { _cardno = value; }
            get { return _cardno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZYLSH
        {
            set { _zylsh = value; }
            get { return _zylsh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string INSUR_NO
        {
            set { _insur_no = value; }
            get { return _insur_no; }
        }
        #endregion Model

    }
}




















