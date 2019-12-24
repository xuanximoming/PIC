using System;
using System.Collections.Generic;
using System.Text;
using ILL;

namespace PACS_Model
{
    /// <summary>
    /// ʵ����--FPAX_USERS��FPAX�û��б�
    /// </summary>
    [Serializable]
    public class MUser : IModel
    {
        #region Model
        private string _db_user;            //���ݿ��û���
        private string _user_pwd;           //�û�����
        private string _user_id;            //�û���ʶ
        private string _user_name;          //�û�����
        private string _user_dept;          //�û����Ҵ���
        private string _dept_name;          //��������
        private int? _capability;           //Ӧ��Ȩ��
        private string _application;        //����Ȩ�� 9�����Σ�������ҽʦ6������ҽʦ4����ͨҽʦ3����ʦ1���ٴ�ҽ��
        private string _module_capability;  //��������
        private int? _user_handup_style;    //�û��ύ��������0���ֶ��ύ��1��Ĭ��Ϊ0
        private int? _user_report_style;    //�û�������
        private int? _user_skin_style;      //�û�������
        private DateTime? _create_date;     //��������
        private int? _user_chat_capability; //��ʱͨ�û�����
        private int? _user_header_icon;     //�û�ͷ��
        private string _user_custom_data;   //�û�ϰ������

        /// <summary>
        /// ���ݿ��û���
        /// </summary>
        public string DB_USER
        {
            set { _db_user = value; }
            get { return _db_user; }
        }

        /// <summary>
        /// �û�����
        /// </summary>
        public string USER_PWD
        {
            set { _user_pwd = value; }
            get { return _user_pwd; }
        }

        /// <summary>
        /// �û�����
        /// </summary>
        public string USER_ID
        {
            set { _user_id = value; }
            get { return _user_id; }
        }

        /// <summary>
        /// �û�����
        /// </summary>
        public string USER_NAME
        {
            set { _user_name = value; }
            get { return _user_name; }
        }

        /// <summary>
        /// �û��������Ҵ���
        /// </summary>
        public string USER_DEPT
        {
            set { _user_dept = value; }
            get { return _user_dept; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string DEPT_NAME
        {
            set { _dept_name = value; }
            get { return _dept_name; }
        }

        /// <summary>
        /// ����Ȩ��
        /// </summary>
        public int? CAPABILITY
        {
            set { _capability = value; }
            get { return _capability; }
        }

        /// <summary>
        /// Ӧ��Ȩ��
        /// </summary>
        public string APPLICATION
        {
            set { _application = value; }
            get { return _application; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string MODULE_CAPABILITY
        {
            set { _module_capability = value; }
            get { return _module_capability; }
        }

        /// <summary>
        /// �û������ύ����
        /// </summary>
        public int? USER_HANDUP_STYLE
        {
            set { _user_handup_style = value; }
            get { return _user_handup_style; }
        }

        /// <summary>
        /// �û�������
        /// </summary>
        public int? USER_REPORT_STYLE
        {
            set { _user_report_style = value; }
            get { return _user_report_style; }
        }

        /// <summary>
        /// �û�������
        /// </summary>
        public int? USER_SKIN_STYLE
        {
            set { _user_skin_style = value; }
            get { return _user_skin_style; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public DateTime? CREATE_DATE
        {
            set { _create_date = value; }
            get { return _create_date; }
        }

        /// <summary>
        /// ��ʱͨ����
        /// </summary>
        public int? USER_CHAT_CAPABILITY
        {
            set { _user_chat_capability = value; }
            get { return _user_chat_capability; }
        }

        /// <summary>
        /// �û�ͷ��
        /// </summary>
        public int? USER_HEADER_ICON
        {
            set { _user_header_icon = value; }
            get { return _user_header_icon; }
        }

        /// <summary>
        /// �û�ϰ������
        /// </summary>
        public string USER_CUSTOM_DATA
        {
            set { _user_custom_data = value; }
            get { return _user_custom_data; }
        }

        #endregion Model
    }
}
