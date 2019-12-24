using System;

namespace SIS_Model
{
    /// <summary>
    /// ʵ����--CHARGE_ITEM_DICT���۱���Ŀ�ֵ�
    /// </summary>
    public class MChargeItemDict:ILL.IModel
    {
        public MChargeItemDict()
        {
        }
        #region Model
        private string _charge_item_code;   //�շ���Ŀ����
        private string _charge_item_spec;   //�շ���Ŀ���
        private string _units;              //��λ
        private DateTime? _start_date;      //��������
        private string _charge_item_name;   //�շ���Ŀ����
        private string _input_code;         //�������
        private decimal? _price;            //����
        private DateTime? _stop_date;       //ͣ������
        private string _operator;           //����Ա
        private DateTime? _enter_date;      //¼������
        private string _memo;               //��ע
        private string _Charge_Item_Class;  //��Ŀ�����룬��Ӧ�շ���Ŀ�����ֵ��CLASS_CODE

        /// <summary>
        /// �շ���Ŀ����
        /// </summary>
        public string CHARGE_ITEM_CODE
        {
            set { _charge_item_code = value; }
            get { return _charge_item_code; }
        }

        /// <summary>
        /// �շ���Ŀ������
        /// </summary>
        public string CHARGE_ITEM_CLASS
        {
            set {_Charge_Item_Class =value ;}
            get {return _Charge_Item_Class;}
        }

        /// <summary>
        /// �շѹ��
        /// </summary>
        public string CHARGE_ITEM_SPEC
        {
            set { _charge_item_spec = value; }
            get { return _charge_item_spec; }
        }

        /// <summary>
        /// ��λ
        /// </summary>
        public string UNITS
        {
            set { _units = value; }
            get { return _units; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public DateTime? START_DATE
        {
            set { _start_date = value; }
            get { return _start_date; }
        }

        /// <summary>
        /// �շ���Ŀ����
        /// </summary>
        public string CHARGE_ITEM_NAME
        {
            set { _charge_item_name = value; }
            get { return _charge_item_name; }
        }

        /// <summary>
        /// �������
        /// </summary>
        public string INPUT_CODE
        {
            set { _input_code = value; }
            get { return _input_code; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public decimal? PRICE
        {
            set { _price = value; }
            get { return _price; }
        }

        /// <summary>
        /// ͣ������
        /// </summary>
        public DateTime? STOP_DATE
        {
            set { _stop_date = value; }
            get { return _stop_date; }
        }

        /// <summary>
        /// ����Ա
        /// </summary>
        public string OPERATOR
        {
            set { _operator = value; }
            get { return _operator; }
        }

        /// <summary>
        /// ¼������
        /// </summary>
        public DateTime? ENTER_DATE
        {
            set { _enter_date = value; }
            get { return _enter_date; }
        }

        /// <summary>
        /// ��ע
        /// </summary>
        public string MEMO
        {
            set { _memo = value; }
            get { return _memo; }
        }
        #endregion Model
    }
}
