using System;
using System.Text;

namespace SIS_Model
{
    /// <summary>
    /// 实体类USERS_ROLE ，用户角色
    /// </summary>
    [Serializable]
    public class MUsersRole : ILL.IModel
    {
        public MUsersRole()
        { }
        #region Model
        private int _role_id;           //角色ID
        private string _role_name;      //角色名称
        private string _exam_class;     //检查类别
        private string _exam_sub_class; //检查子类
        private string _fun_model;      //功能模块

        /// <summary>
        /// 角色ID
        /// </summary>
        public int ROLE_ID
        {
            set { _role_id = value; }
            get { return _role_id; }
        }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string ROLE_NAME
        {
            set { _role_name = value; }
            get { return _role_name; }
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
        /// 检查子类
        /// </summary>
        public string EXAM_SUB_CLASS
        {
            set { _exam_sub_class = value; }
            get { return _exam_sub_class; }
        }

        /// <summary>
        /// 功能模块
        /// </summary>
        public string FUN_MODEL
        {
            set { _fun_model = value; }
            get { return _fun_model; }
        }
        #endregion Model
    }
}