using System;
using System.Collections.Generic;
using System.Text;
using ILL;

namespace PACS_Model
{
    /// <summary>
    /// 实体类PATIENT_INF--病人信息表
    /// </summary>
    public class MArchives : IModel
    {
        #region Model
        private string _patient_id;             //病人ID
        private string _opd_no;                 //门诊号
        private string _inp_no;                 //住院号
        private string _patient_name;           //病人姓名
        private string _patient_english_name;   //姓名拼音
        private string _patient_sex;            //性别
        private DateTime? _patient_birth;       //出生日期
        private string _identity_card_no;       //身份证号
        private string _native_place;           //籍贯
        private string _birth_place;            //出生地
        private string _habitation;             //现住址
        private string _mailing_address;        //通信地址
        private string _zip_code;               //邮政编码
        private string _telephone_number;       //电话号码
        private int? _patient_class;            //入院方式
        private int? _visit_times;              //住院次数

        /// <summary>
        /// 病人ID
        /// </summary>
        public string PATIENT_ID
        {
            set { _patient_id = value; }
            get { return _patient_id; }
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
        /// 住院号
        /// </summary>
        public string INP_NO
        {
            set { _inp_no = value; }
            get { return _inp_no; }
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
        /// 姓名拼音
        /// </summary>
        public string PATIENT_ENGLISH_NAME
        {
            set { _patient_english_name = value; }
            get { return _patient_english_name; }
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
        /// 出生日期
        /// </summary>
        public DateTime? PATIENT_BIRTH
        {
            set { _patient_birth = value; }
            get { return _patient_birth; }
        }

        /// <summary>
        /// 身份证号
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
        /// 现住址
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
        /// 电话号码
        /// </summary>
        public string TELEPHONE_NUMBER
        {
            set { _telephone_number = value; }
            get { return _telephone_number; }
        }

        /// <summary>
        /// 入院方式
        /// </summary>
        public int? PATIENT_CLASS
        {
            set { _patient_class = value; }
            get { return _patient_class; }
        }

        /// <summary>
        /// 住院次数
        /// </summary>
        public int? VISIT_TIMES
        {
            set { _visit_times = value; }
            get { return _visit_times; }
        }

        #endregion Model
    }
}
