using System;

namespace PACS_Model
{
    /// <summary>
    /// 实体类--EXAM_VS_CHARGE，检查项目与价表项目对照
    /// </summary>
    [Serializable]
    public class MExamVsCharge:ILL.IModel
    {
        public MExamVsCharge()
        { }
        #region Model
        private string _exam_item_code;     //检查项目代码
        private int? _charge_item_no;       //价表项目序号
        private string _charge_item_code;   //价表项目代码
        private string _charge_item_spec;   //价表项目规格，此项若为空，则表示规格不确定
        private int? _amount;               //对应价表项目数
        private string _units;              //价表项目单位

        /// <summary>
        /// 检查项目代码
        /// </summary>
        public string EXAM_ITEM_CODE
        {
            set { _exam_item_code = value; }
            get { return _exam_item_code; }
        }

        /// <summary>
        /// 价表项目序号
        /// </summary>
        public int? CHARGE_ITEM_NO
        {
            set { _charge_item_no = value; }
            get { return _charge_item_no; }
        }

        /// <summary>
        /// 价表项目代码
        /// </summary>
        public string CHARGE_ITEM_CODE
        {
            set { _charge_item_code = value; }
            get { return _charge_item_code; }
        }

        /// <summary>
        /// 价表项目规格
        /// </summary>
        public string CHARGE_ITEM_SPEC
        {
            set { _charge_item_spec = value; }
            get { return _charge_item_spec; }
        }

        /// <summary>
        /// 对应价表项目数
        /// </summary>
        public int? AMOUNT
        {
            set { _amount = value; }
            get { return _amount; }
        }

        /// <summary>
        /// 价表项目单位
        /// </summary>
        public string UNITS
        {
            set { _units = value; }
            get { return _units; }
        }
        #endregion Model
    }
}
