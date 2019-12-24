using System;
using System.Collections.Generic;
using System.Text;

namespace SIS_Model
{
    /// <summary>
    /// 实体类--ARCHIVES，病人档案
    /// </summary>
    [Serializable]
    public class MArchives : ILL.IModel
    {
        public MArchives()
        {

        }
        #region Model
        private string _patient_id;         //病人ID
        private string _patient_name;       //病人姓名
        private string _patient_sex;        //性别
        private int? _patient_age;          //年龄
        private string _patient_age_unit;   //年龄单位
        private DateTime? _patient_birth;   //出生日期
        private string _telephone_num;      //电话号码
        private string _identity_card_no;   //身份证号码
        private string _native_place;       //籍贯
        private string _birth_place;        //出生地
        private string _habitation;         //现住地
        private string _mailing_address;    //通信地址
        private string _zip_code;           //邮政编码
        private string _insurance_no;       //医保号
        private DateTime? _bespeak_time;    //建档日期
        private int? _charge_class;         //收费类别
        private string _inp_no;             //住院号
        private string _opd_no;             //门诊号
        private string _patient_identity;   //身份

        /// <summary>
        /// 病人ID
        /// </summary>
        public string PATIENT_ID
        {
            set { _patient_id = value; }
            get { return _patient_id; }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string PATIENT_NAME
        {
            set { _patient_name = value; }
            get { return _patient_name; }
        }

        /// <summary>
        /// 性别
        /// </summary>
        public string PATIENT_SEX
        {
            set { _patient_sex = value; }
            get { return _patient_sex; }
        }

        /// <summary>
        /// 年龄
        /// </summary>
        public int? PATIENT_AGE
        {
            set { _patient_age = value; }
            get { return _patient_age; }
        }

        /// <summary>
        /// 年龄单位
        /// </summary>
        public string PATIENT_AGE_UNIT
        {
            set { _patient_age_unit = value; }
            get { return _patient_age_unit; }
        }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? PATIENT_BIRTH
        {
            set { _patient_birth = value; }
            get { return _patient_birth; }
        }

        /// <summary>
        /// 电话号码
        /// </summary>
        public string TELEPHONE_NUM
        {
            set { _telephone_num = value; }
            get { return _telephone_num; }
        }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IDENTITY_CARD_NO
        {
            set { _identity_card_no = value; }
            get { return _identity_card_no; }
        }

        /// <summary>
        /// 籍贯
        /// </summary>
        public string NATIVE_PLACE
        {
            set { _native_place = value; }
            get { return _native_place; }
        }

        /// <summary>
        /// 出生地
        /// </summary>
        public string BIRTH_PLACE
        {
            set { _birth_place = value; }
            get { return _birth_place; }
        }

        /// <summary>
        /// 现住地
        /// </summary>
        public string HABITATION
        {
            set { _habitation = value; }
            get { return _habitation; }
        }

        /// <summary>
        /// 通信地址
        /// </summary>
        public string MAILING_ADDRESS
        {
            set { _mailing_address = value; }
            get { return _mailing_address; }
        }

        /// <summary>
        /// 邮政编码
        /// </summary>
        public string ZIP_CODE
        {
            set { _zip_code = value; }
            get { return _zip_code; }
        }

        /// <summary>
        /// 医保号
        /// </summary>
        public string INSURANCE_NO
        {
            set { _insurance_no = value; }
            get { return _insurance_no; }
        }

        /// <summary>
        /// 建档日期
        /// </summary>
        public DateTime? BESPEAK_TIME
        {
            set { _bespeak_time = value; }
            get { return _bespeak_time; }
        }

        /// <summary>
        /// 收费类别
        /// </summary>
        public int? CHARGE_CLASS
        {
            set { _charge_class = value; }
            get { return _charge_class; }
        }

        /// <summary>
        /// 住院号
        /// </summary>
        public string INP_NO
        {
            set { _inp_no = value; }
            get { return _inp_no; }
        }

        /// <summary>
        /// 门诊号
        /// </summary>
        public string OPD_NO
        {
            set { _opd_no = value; }
            get { return _opd_no; }
        }

        /// <summary>
        /// 身份
        /// </summary>
        public string PATIENT_IDENTITY
        {
            set { _patient_identity = value; }
            get { return _patient_identity; }
        }
        #endregion Model
        
        #region ArchiveSubModel
        //private string _patient_id;
        private string _a1;
        private int? _a2;
        private int? _a3;
        private string _a4;
        /// <summary>
        /// 
        /// </summary>
        //public string PATIENT_ID
        //{
        //    set { _patient_id = value; }
        //    get { return _patient_id; }
        //}
        /// <summary>
        /// 
        /// </summary>
        public string A1
        {
            set { _a1 = value; }
            get { return _a1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? A2
        {
            set { _a2 = value; }
            get { return _a2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? A3
        {
            set { _a3 = value; }
            get { return _a3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string A4
        {
            set { _a4 = value; }
            get { return _a4; }
        }
        #endregion Model
    }
}
