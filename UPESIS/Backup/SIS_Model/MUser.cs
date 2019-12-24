using System;
using System.Collections.Generic;
using System.Text;

namespace SIS_Model
{
    /// <summary>
    /// ʵ����SYSTEM_USERS��ϵͳ�û�
    /// </summary>
    public class MUser : ILL.IModel
    {
        private string DoctorId;        //ҽ��ID
        private string DoctorName;      //ҽ������
        private string ClinicOfficeCode;//�ٴ����Ҵ���
        private string ClinicOffice;    //�ٴ���������
        private string DoctorRole;      //ҽ����ɫ
        private string DoctorPwd;       //ҽ����½����
        private DateTime? CreateDate;   //��������
        private int? DoctorLevel;       //ҽ������9�����Σ�������ҽʦ 6������ҽʦ 4����ͨҽʦ��

        /// <summary>
        /// ҽ��ID��������
        /// </summary>
        public string DOCTOR_ID
        {
            get { return this.DoctorId; }
            set { this.DoctorId = value; }
        }

        /// <summary>
        /// ҽ������
        /// </summary>
        public string DOCTOR_NAME
        {
            get { return this.DoctorName; }
            set { this.DoctorName = value; }
        }

        /// <summary>
        /// �ٴ����Ҵ���
        /// </summary>
        public string CLINIC_OFFICE_CODE
        {
            get { return this.ClinicOfficeCode; }
            set { this.ClinicOfficeCode = value; }
        }

        /// <summary>
        /// �ٴ���������
        /// </summary>
        public string CLINIC_OFFICE
        {
            get { return this.ClinicOffice; }
            set { this.ClinicOffice = value; }
        }

        /// <summary>
        /// ҽ����ɫ
        /// </summary>
        public string DOCTOR_ROLE
        {
            get { return this.DoctorRole; }
            set { this.DoctorRole = value; }
        }

        /// <summary>
        /// ҽ����½����
        /// </summary>
        public string DOCTOR_PWD
        {
            get { return this.DoctorPwd; }
            set { this.DoctorPwd = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public DateTime? CREATE_DATE
        {
            get { return this.CreateDate; }
            set { this.CreateDate = value; }
        }

        /// <summary>
        /// ҽ������
        /// </summary>
        public int? DOCTOR_LEVEL
        {
            get { return this.DoctorLevel; }
            set { this.DoctorLevel = value; }
        }

        /// <summary>
        /// �޲ι��췽��
        /// </summary>
        public MUser()
        {
        }

    }
}