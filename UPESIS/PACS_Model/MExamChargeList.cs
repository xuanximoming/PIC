using System;
namespace PACS_Model
{
    /// <summary>
    /// 实体类EXAM_CHARGE_LIST，检查收费明细表
    /// </summary>
    [Serializable]
    public class MExamChargeList : ILL.IModel
    {
        public MExamChargeList()
        { }
        #region Model
        private string _exam_no;                //检查申请号
        private string _patient_id;             //病人ID
        private DateTime? _exam_confirm_time;   //检查确认时间
        private string _exam_item_code;         //检查项目代码
        private string _charge_item_code;       //收费项目代码
        private string _charge_item_spec;       //收费项目规格
        private int? _amount;                   //数量
        private string _units;                  //单位
        private decimal? _cost;                 //计价
        private decimal? _charge;               //收费
        private int? _charge_item_no;           //收费项目序号
        private string _charge_item_class;      //收费项目类别
        private string _charge_class_name;      //收费类别名称
        private int? _item_no;                  //费用项目号
        private string _charge_item_name;       //收费项目名
        private decimal? _price;                //单价
        private int? _exam_item_no;             //检查项目序号

        /// <summary>
        /// 检查申请号
        /// </summary>
        public string EXAM_NO
        {
            set { _exam_no = value; }
            get { return _exam_no; }
        }

        /// <summary>
        /// 病人ID
        /// </summary>
        public string PATIENT_ID
        {
            set { _patient_id = value; }
            get { return _patient_id; }
        }

        /// <summary>
        /// 检查确认时间
        /// </summary>
        public DateTime? EXAM_CONFIRM_TIME
        {
            set { _exam_confirm_time = value; }
            get { return _exam_confirm_time; }
        }

        /// <summary>
        /// 检查项目代码
        /// </summary>
        public string EXAM_ITEM_CODE
        {
            set { _exam_item_code = value; }
            get { return _exam_item_code; }
        }

        /// <summary>
        /// 收费项目代码
        /// </summary>
        public string CHARGE_ITEM_CODE
        {
            set { _charge_item_code = value; }
            get { return _charge_item_code; }
        }

        /// <summary>
        /// 收费项目规格
        /// </summary>
        public string CHARGE_ITEM_SPEC
        {
            set { _charge_item_spec = value; }
            get { return _charge_item_spec; }
        }

        /// <summary>
        /// 数量
        /// </summary>
        public int? AMOUNT
        {
            set { _amount = value; }
            get { return _amount; }
        }

        /// <summary>
        /// 单位
        /// </summary>
        public string UNITS
        {
            set { _units = value; }
            get { return _units; }
        }

        /// <summary>
        /// 计价
        /// </summary>
        public decimal ? COST
        {
            set { _cost = value; }
            get { return _cost; }
        }

        /// <summary>
        /// 收费
        /// </summary>
        public decimal? CHARGE
        {
            set { _charge = value; }
            get { return _charge; }
        }

        /// <summary>
        /// 收费项目序号
        /// </summary>
        public int? CHARGE_ITEM_NO
        {
            set { _charge_item_no = value; }
            get { return _charge_item_no; }
        }

        /// <summary>
        /// 检查项目序号
        /// </summary>
        public int? EXAM_ITEM_NO
        {
            set { _exam_item_no = value; }
            get { return _exam_item_no; }
        }

        /// <summary>
        /// 收费项目类别
        /// </summary>
        public string CHARGE_ITEM_CLASS
        {
            set { _charge_item_class = value; }
            get { return _charge_item_class; }
        }

        /// <summary>
        /// 收费类别名称
        /// </summary>
        public string CHARGE_CLASS_NAME
        {
            set { _charge_class_name = value; }
            get { return _charge_class_name; }
        }


        /// <summary>
        /// 费用项目序号
        /// </summary>
        public int? ITEM_NO
        {
            set { _item_no = value; }
            get { return _item_no; }
        }

        /// <summary>
        /// 收费项目名称
        /// </summary>
        public string CHARGE_ITEM_NAME
        {
            set { _charge_item_name = value; }
            get { return _charge_item_name; }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal? PRICE
        {
            set { _price = value; }
            get { return _price; }
        }

        #endregion Model
    }
}