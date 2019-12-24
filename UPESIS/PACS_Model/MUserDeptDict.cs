using System;
using System.Collections.Generic;
using System.Text;
using ILL;

namespace PACS_Model
{
    /// <summary>
    /// ʵ����--USER_DEPT_DICT���û������ֵ�
    /// </summary>
    public class MUserDeptDict : IModel
    {
        #region Model
        private string _dept_code;          //���Ҵ���
        private string _dept_name;          //��������
        private int? _rpt_handup_style;     //�����ύ��ʽ
        private int? _rpt_issuance_style;   //���淢����ʽ
        private string _dept_area;          //��������CDΪ������ң�RYΪ������
        private string _study_uid_header;   //���UIDͷ

        /// <summary>
        /// ���Ҵ���
        /// </summary>
        public string DEPT_CODE
        {
            set { _dept_code = value; }
            get { return _dept_code; }
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
        /// �����ύ��ʽ
        /// </summary>
        public int? RPT_HANDUP_STYLE
        {
            set { _rpt_handup_style = value; }
            get { return _rpt_handup_style; }
        }

        /// <summary>
        /// ���淢����ʽ
        /// </summary>
        public int? RPT_ISSUANCE_STYLE
        {
            set { _rpt_issuance_style = value; }
            get { return _rpt_issuance_style; }
        }

        /// <summary>
        /// ��������CDΪ���룬RYΪ���
        /// </summary>
        public string DEPT_AREA
        {
            set { _dept_area = value; }
            get { return _dept_area; }
        }

        /// <summary>
        /// ���UIDͷ
        /// </summary>
        public string STUDY_UID_HEADER
        {
            set { _study_uid_header = value; }
            get { return _study_uid_header; }
        }
        #endregion Model
    }
}
