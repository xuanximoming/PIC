using System;
using System.Collections.Generic;
using System.Text;
using ILL;

namespace PACS_Model
{
    /// <summary>
    /// ʵ����--USER_EXAM_CLASS���û�����������
    /// </summary>
    public class MUserExamClass : IModel
    {
        #region Model
        private string _db_user;            //�����û���
        private string _user_dept;          //�û���������
        private string _dept_name;          //��������
        private string _exam_class;         //������
        private int? _report_capability;    //����Ȩ��0Ϊֻ�ܿ����棻1Ϊ��д���棻2Ϊ����˱���

        /// <summary>
        /// ���ݿ��û���
        /// </summary>
        public string DB_USER
        {
            set { _db_user = value; }
            get { return _db_user; }
        }

        /// <summary>
        /// �û���������
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
        /// ������
        /// </summary>
        public string EXAM_CLASS
        {
            set { _exam_class = value; }
            get { return _exam_class; }
        }

        /// <summary>
        /// ����Ȩ��
        /// </summary>
        public int? REPORT_CAPABILITY
        {
            set { _report_capability = value; }
            get { return _report_capability; }
        }
        #endregion Model
    }
}
