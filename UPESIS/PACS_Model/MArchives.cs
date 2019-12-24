using System;
using System.Collections.Generic;
using System.Text;
using ILL;

namespace PACS_Model
{
    /// <summary>
    /// ʵ����PATIENT_INF--������Ϣ��
    /// </summary>
    public class MArchives : IModel
    {
        #region Model
        private string _patient_id;             //����ID
        private string _opd_no;                 //�����
        private string _inp_no;                 //סԺ��
        private string _patient_name;           //��������
        private string _patient_english_name;   //����ƴ��
        private string _patient_sex;            //�Ա�
        private DateTime? _patient_birth;       //��������
        private string _identity_card_no;       //���֤��
        private string _native_place;           //����
        private string _birth_place;            //������
        private string _habitation;             //��סַ
        private string _mailing_address;        //ͨ�ŵ�ַ
        private string _zip_code;               //��������
        private string _telephone_number;       //�绰����
        private int? _patient_class;            //��Ժ��ʽ
        private int? _visit_times;              //סԺ����

        /// <summary>
        /// ����ID
        /// </summary>
        public string PATIENT_ID
        {
            set { _patient_id = value; }
            get { return _patient_id; }
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
        /// סԺ��
        /// </summary>
        public string INP_NO
        {
            set { _inp_no = value; }
            get { return _inp_no; }
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
        /// ����ƴ��
        /// </summary>
        public string PATIENT_ENGLISH_NAME
        {
            set { _patient_english_name = value; }
            get { return _patient_english_name; }
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
        /// ��������
        /// </summary>
        public DateTime? PATIENT_BIRTH
        {
            set { _patient_birth = value; }
            get { return _patient_birth; }
        }

        /// <summary>
        /// ���֤��
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
        /// ��סַ
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
        /// �绰����
        /// </summary>
        public string TELEPHONE_NUMBER
        {
            set { _telephone_number = value; }
            get { return _telephone_number; }
        }

        /// <summary>
        /// ��Ժ��ʽ
        /// </summary>
        public int? PATIENT_CLASS
        {
            set { _patient_class = value; }
            get { return _patient_class; }
        }

        /// <summary>
        /// סԺ����
        /// </summary>
        public int? VISIT_TIMES
        {
            set { _visit_times = value; }
            get { return _visit_times; }
        }

        #endregion Model
    }
}
