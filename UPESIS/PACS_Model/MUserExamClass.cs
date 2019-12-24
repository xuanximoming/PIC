using System;
using System.Collections.Generic;
using System.Text;
using ILL;

namespace PACS_Model
{
    /// <summary>
    /// 实体类--USER_EXAM_CLASS，用户与检查类别对照
    /// </summary>
    public class MUserExamClass : IModel
    {
        #region Model
        private string _db_user;            //数据用户名
        private string _user_dept;          //用户所属科室
        private string _dept_name;          //科室名称
        private string _exam_class;         //检查类别
        private int? _report_capability;    //报告权限0为只能看报告；1为可写报告；2为可审核报告

        /// <summary>
        /// 数据库用户名
        /// </summary>
        public string DB_USER
        {
            set { _db_user = value; }
            get { return _db_user; }
        }

        /// <summary>
        /// 用户所属科室
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
        /// 检查类别
        /// </summary>
        public string EXAM_CLASS
        {
            set { _exam_class = value; }
            get { return _exam_class; }
        }

        /// <summary>
        /// 报告权限
        /// </summary>
        public int? REPORT_CAPABILITY
        {
            set { _report_capability = value; }
            get { return _report_capability; }
        }
        #endregion Model
    }
}
