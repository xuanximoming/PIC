using System;
using System.Collections.Generic;
using System.Text;
using ILL;

namespace PACS_Model
{
    /// <summary>
    /// 实体类--FPAX_USERS，FPAX用户列表
    /// </summary>
    [Serializable]
    public class MUser : IModel
    {
        #region Model
        private string _db_user;            //数据库用户名
        private string _user_pwd;           //用户密码
        private string _user_id;            //用户标识
        private string _user_name;          //用户姓名
        private string _user_dept;          //用户科室代码
        private string _dept_name;          //科室名称
        private int? _capability;           //应用权限
        private string _application;        //报告权限 9：主任，副主任医师6：主治医师4：普通医师3：技师1：临床医生
        private string _module_capability;  //功能名称
        private int? _user_handup_style;    //用户提交报告设置0：手动提交；1：默认为0
        private int? _user_report_style;    //用户报告风格
        private int? _user_skin_style;      //用户界面风格
        private DateTime? _create_date;     //创建日期
        private int? _user_chat_capability; //即时通用户级别
        private int? _user_header_icon;     //用户头像
        private string _user_custom_data;   //用户习惯数据

        /// <summary>
        /// 数据库用户名
        /// </summary>
        public string DB_USER
        {
            set { _db_user = value; }
            get { return _db_user; }
        }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string USER_PWD
        {
            set { _user_pwd = value; }
            get { return _user_pwd; }
        }

        /// <summary>
        /// 用户工号
        /// </summary>
        public string USER_ID
        {
            set { _user_id = value; }
            get { return _user_id; }
        }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string USER_NAME
        {
            set { _user_name = value; }
            get { return _user_name; }
        }

        /// <summary>
        /// 用户所属科室代码
        /// </summary>
        public string USER_DEPT
        {
            set { _user_dept = value; }
            get { return _user_dept; }
        }

        /// <summary>
        /// 科室名称
        /// </summary>
        public string DEPT_NAME
        {
            set { _dept_name = value; }
            get { return _dept_name; }
        }

        /// <summary>
        /// 报告权限
        /// </summary>
        public int? CAPABILITY
        {
            set { _capability = value; }
            get { return _capability; }
        }

        /// <summary>
        /// 应用权限
        /// </summary>
        public string APPLICATION
        {
            set { _application = value; }
            get { return _application; }
        }

        /// <summary>
        /// 功能
        /// </summary>
        public string MODULE_CAPABILITY
        {
            set { _module_capability = value; }
            get { return _module_capability; }
        }

        /// <summary>
        /// 用户报告提交设置
        /// </summary>
        public int? USER_HANDUP_STYLE
        {
            set { _user_handup_style = value; }
            get { return _user_handup_style; }
        }

        /// <summary>
        /// 用户报告风格
        /// </summary>
        public int? USER_REPORT_STYLE
        {
            set { _user_report_style = value; }
            get { return _user_report_style; }
        }

        /// <summary>
        /// 用户界面风格
        /// </summary>
        public int? USER_SKIN_STYLE
        {
            set { _user_skin_style = value; }
            get { return _user_skin_style; }
        }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CREATE_DATE
        {
            set { _create_date = value; }
            get { return _create_date; }
        }

        /// <summary>
        /// 即时通级别
        /// </summary>
        public int? USER_CHAT_CAPABILITY
        {
            set { _user_chat_capability = value; }
            get { return _user_chat_capability; }
        }

        /// <summary>
        /// 用户头像
        /// </summary>
        public int? USER_HEADER_ICON
        {
            set { _user_header_icon = value; }
            get { return _user_header_icon; }
        }

        /// <summary>
        /// 用户习惯数据
        /// </summary>
        public string USER_CUSTOM_DATA
        {
            set { _user_custom_data = value; }
            get { return _user_custom_data; }
        }

        #endregion Model
    }
}
