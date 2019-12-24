using System;

namespace SIS_Model
{
    /// <summary>
    /// 实体类--CHARGE_ITEM_DICT，价表项目字典
    /// </summary>
    public class MChargeItemDict:ILL.IModel
    {
        public MChargeItemDict()
        {
        }
        #region Model
        private string _charge_item_code;   //收费项目代码
        private string _charge_item_spec;   //收费项目规格
        private string _units;              //单位
        private DateTime? _start_date;      //启用日期
        private string _charge_item_name;   //收费项目名称
        private string _input_code;         //输入简码
        private decimal? _price;            //单价
        private DateTime? _stop_date;       //停用日期
        private string _operator;           //操作员
        private DateTime? _enter_date;      //录入日期
        private string _memo;               //备注
        private string _Charge_Item_Class;  //项目类别代码，对应收费项目分类字典的CLASS_CODE

        /// <summary>
        /// 收费项目代码
        /// </summary>
        public string CHARGE_ITEM_CODE
        {
            set { _charge_item_code = value; }
            get { return _charge_item_code; }
        }

        /// <summary>
        /// 收费项目类别代码
        /// </summary>
        public string CHARGE_ITEM_CLASS
        {
            set {_Charge_Item_Class =value ;}
            get {return _Charge_Item_Class;}
        }

        /// <summary>
        /// 收费规格
        /// </summary>
        public string CHARGE_ITEM_SPEC
        {
            set { _charge_item_spec = value; }
            get { return _charge_item_spec; }
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
        /// 启用日期
        /// </summary>
        public DateTime? START_DATE
        {
            set { _start_date = value; }
            get { return _start_date; }
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
        /// 输入简码
        /// </summary>
        public string INPUT_CODE
        {
            set { _input_code = value; }
            get { return _input_code; }
        }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal? PRICE
        {
            set { _price = value; }
            get { return _price; }
        }

        /// <summary>
        /// 停用日期
        /// </summary>
        public DateTime? STOP_DATE
        {
            set { _stop_date = value; }
            get { return _stop_date; }
        }

        /// <summary>
        /// 操作员
        /// </summary>
        public string OPERATOR
        {
            set { _operator = value; }
            get { return _operator; }
        }

        /// <summary>
        /// 录入日期
        /// </summary>
        public DateTime? ENTER_DATE
        {
            set { _enter_date = value; }
            get { return _enter_date; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string MEMO
        {
            set { _memo = value; }
            get { return _memo; }
        }
        #endregion Model
    }
}
