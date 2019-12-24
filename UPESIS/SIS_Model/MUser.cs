using System;
using System.Collections.Generic;
using System.Text;

namespace SIS_Model
{
    /// <summary>
    /// 实体类SYSTEM_USERS，系统用户
    /// </summary>
    public class MUser : ILL.IModel
    {
        private string DoctorId;        //医生ID
        private string DoctorName;      //医生姓名
        private string ClinicOfficeCode;//临床科室代码
        private string ClinicOffice;    //临床科室名称
        private string DoctorRole;      //医生角色
        private string DoctorPwd;       //医生登陆密码
        private DateTime? CreateDate;   //创建日期
        private int? DoctorLevel;       //医生级别：9：主任，副主任医师 6：主治医师 4：普通医师）

        /// <summary>
        /// 医生ID，即工号
        /// </summary>
        public string DOCTOR_ID
        {
            get { return this.DoctorId; }
            set { this.DoctorId = value; }
        }

        /// <summary>
        /// 医生姓名
        /// </summary>
        public string DOCTOR_NAME
        {
            get { return this.DoctorName; }
            set { this.DoctorName = value; }
        }

        /// <summary>
        /// 临床科室代码
        /// </summary>
        public string CLINIC_OFFICE_CODE
        {
            get { return this.ClinicOfficeCode; }
            set { this.ClinicOfficeCode = value; }
        }

        /// <summary>
        /// 临床科室名称
        /// </summary>
        public string CLINIC_OFFICE
        {
            get { return this.ClinicOffice; }
            set { this.ClinicOffice = value; }
        }

        /// <summary>
        /// 医生角色
        /// </summary>
        public string DOCTOR_ROLE
        {
            get { return this.DoctorRole; }
            set { this.DoctorRole = value; }
        }

        /// <summary>
        /// 医生登陆密码
        /// </summary>
        public string DOCTOR_PWD
        {
            get { return this.DoctorPwd; }
            set { this.DoctorPwd = value; }
        }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CREATE_DATE
        {
            get { return this.CreateDate; }
            set { this.CreateDate = value; }
        }

        /// <summary>
        /// 医生级别
        /// </summary>
        public int? DOCTOR_LEVEL
        {
            get { return this.DoctorLevel; }
            set { this.DoctorLevel = value; }
        }

        /// <summary>
        /// 无参构造方法
        /// </summary>
        public MUser()
        {
        }

    }
}