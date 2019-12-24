using System;
using System.Collections.Generic;
using System.Text;

namespace SIS_Model
{
    /// <summary>
    /// ʵ����--ARCHIVES�����˵���
    /// </summary>
    [Serializable]
    public class MArchives : ILL.IModel
    {
        public MArchives()
        {

        }
        #region Model
        private string _patient_id;         //����ID
        private string _patient_name;       //��������
        private string _patient_sex;        //�Ա�
        private int? _patient_age;          //����
        private string _patient_age_unit;   //���䵥λ
        private DateTime? _patient_birth;   //��������
        private string _telephone_num;      //�绰����
        private string _identity_card_no;   //���֤����
        private string _native_place;       //����
        private string _birth_place;        //������
        private string _habitation;         //��ס��
        private string _mailing_address;    //ͨ�ŵ�ַ
        private string _zip_code;           //��������
        private string _insurance_no;       //ҽ����
        private DateTime? _bespeak_time;    //��������
        private int? _charge_class;         //�շ����
        private string _inp_no;             //סԺ��
        private string _opd_no;             //�����
        private string _patient_identity;   //���

        /// <summary>
        /// ����ID
        /// </summary>
        public string PATIENT_ID
        {
            set { _patient_id = value; }
            get { return _patient_id; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string PATIENT_NAME
        {
            set { _patient_name = value; }
            get { return _patient_name; }
        }

        /// <summary>
        /// �Ա�
        /// </summary>
        public string PATIENT_SEX
        {
            set { _patient_sex = value; }
            get { return _patient_sex; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public int? PATIENT_AGE
        {
            set { _patient_age = value; }
            get { return _patient_age; }
        }

        /// <summary>
        /// ���䵥λ
        /// </summary>
        public string PATIENT_AGE_UNIT
        {
            set { _patient_age_unit = value; }
            get { return _patient_age_unit; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public DateTime? PATIENT_BIRTH
        {
            set { _patient_birth = value; }
            get { return _patient_birth; }
        }

        /// <summary>
        /// �绰����
        /// </summary>
        public string TELEPHONE_NUM
        {
            set { _telephone_num = value; }
            get { return _telephone_num; }
        }

        /// <summary>
        /// ���֤����
        /// </summary>
        public string IDENTITY_CARD_NO
        {
            set { _identity_card_no = value; }
            get { return _identity_card_no; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string NATIVE_PLACE
        {
            set { _native_place = value; }
            get { return _native_place; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public string BIRTH_PLACE
        {
            set { _birth_place = value; }
            get { return _birth_place; }
        }

        /// <summary>
        /// ��ס��
        /// </summary>
        public string HABITATION
        {
            set { _habitation = value; }
            get { return _habitation; }
        }

        /// <summary>
        /// ͨ�ŵ�ַ
        /// </summary>
        public string MAILING_ADDRESS
        {
            set { _mailing_address = value; }
            get { return _mailing_address; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string ZIP_CODE
        {
            set { _zip_code = value; }
            get { return _zip_code; }
        }

        /// <summary>
        /// ҽ����
        /// </summary>
        public string INSURANCE_NO
        {
            set { _insurance_no = value; }
            get { return _insurance_no; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public DateTime? BESPEAK_TIME
        {
            set { _bespeak_time = value; }
            get { return _bespeak_time; }
        }

        /// <summary>
        /// �շ����
        /// </summary>
        public int? CHARGE_CLASS
        {
            set { _charge_class = value; }
            get { return _charge_class; }
        }

        /// <summary>
        /// סԺ��
        /// </summary>
        public string INP_NO
        {
            set { _inp_no = value; }
            get { return _inp_no; }
        }

        /// <summary>
        /// �����
        /// </summary>
        public string OPD_NO
        {
            set { _opd_no = value; }
            get { return _opd_no; }
        }

        /// <summary>
        /// ���
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
