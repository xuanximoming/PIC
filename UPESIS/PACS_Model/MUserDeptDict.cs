using System;
using System.Collections.Generic;
using System.Text;
using ILL;

namespace PACS_Model
{
    /// <summary>
    /// 实体类--USER_DEPT_DICT，用户科室字典
    /// </summary>
    public class MUserDeptDict : IModel
    {
        #region Model
        private string _dept_code;          //科室代码
        private string _dept_name;          //科室名称
        private int? _rpt_handup_style;     //报告提交方式
        private int? _rpt_issuance_style;   //报告发布方式
        private string _dept_area;          //科室领域：CD为申请科室，RY为检查科室
        private string _study_uid_header;   //检查UID头

        /// <summary>
        /// 科室代码
        /// </summary>
        public string DEPT_CODE
        {
            set { _dept_code = value; }
            get { return _dept_code; }
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
        /// 报告提交方式
        /// </summary>
        public int? RPT_HANDUP_STYLE
        {
            set { _rpt_handup_style = value; }
            get { return _rpt_handup_style; }
        }

        /// <summary>
        /// 报告发布方式
        /// </summary>
        public int? RPT_ISSUANCE_STYLE
        {
            set { _rpt_issuance_style = value; }
            get { return _rpt_issuance_style; }
        }

        /// <summary>
        /// 科室领域：CD为申请，RY为检查
        /// </summary>
        public string DEPT_AREA
        {
            set { _dept_area = value; }
            get { return _dept_area; }
        }

        /// <summary>
        /// 检查UID头
        /// </summary>
        public string STUDY_UID_HEADER
        {
            set { _study_uid_header = value; }
            get { return _study_uid_header; }
        }
        #endregion Model
    }
}
