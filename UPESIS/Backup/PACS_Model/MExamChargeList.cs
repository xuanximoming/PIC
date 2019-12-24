using System;
namespace PACS_Model
{
    /// <summary>
    /// ʵ����EXAM_CHARGE_LIST������շ���ϸ��
    /// </summary>
    [Serializable]
    public class MExamChargeList : ILL.IModel
    {
        public MExamChargeList()
        { }
        #region Model
        private string _exam_no;                //��������
        private string _patient_id;             //����ID
        private DateTime? _exam_confirm_time;   //���ȷ��ʱ��
        private string _exam_item_code;         //�����Ŀ����
        private string _charge_item_code;       //�շ���Ŀ����
        private string _charge_item_spec;       //�շ���Ŀ���
        private int? _amount;                   //����
        private string _units;                  //��λ
        private decimal? _cost;                 //�Ƽ�
        private decimal? _charge;               //�շ�
        private int? _charge_item_no;           //�շ���Ŀ���
        private string _charge_item_class;      //�շ���Ŀ���
        private string _charge_class_name;      //�շ��������
        private int? _item_no;                  //������Ŀ��
        private string _charge_item_name;       //�շ���Ŀ��
        private decimal? _price;                //����
        private int? _exam_item_no;             //�����Ŀ���

        /// <summary>
        /// ��������
        /// </summary>
        public string EXAM_NO
        {
            set { _exam_no = value; }
            get { return _exam_no; }
        }

        /// <summary>
        /// ����ID
        /// </summary>
        public string PATIENT_ID
        {
            set { _patient_id = value; }
            get { return _patient_id; }
        }

        /// <summary>
        /// ���ȷ��ʱ��
        /// </summary>
        public DateTime? EXAM_CONFIRM_TIME
        {
            set { _exam_confirm_time = value; }
            get { return _exam_confirm_time; }
        }

        /// <summary>
        /// �����Ŀ����
        /// </summary>
        public string EXAM_ITEM_CODE
        {
            set { _exam_item_code = value; }
            get { return _exam_item_code; }
        }

        /// <summary>
        /// �շ���Ŀ����
        /// </summary>
        public string CHARGE_ITEM_CODE
        {
            set { _charge_item_code = value; }
            get { return _charge_item_code; }
        }

        /// <summary>
        /// �շ���Ŀ���
        /// </summary>
        public string CHARGE_ITEM_SPEC
        {
            set { _charge_item_spec = value; }
            get { return _charge_item_spec; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public int? AMOUNT
        {
            set { _amount = value; }
            get { return _amount; }
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
        /// �Ƽ�
        /// </summary>
        public decimal ? COST
        {
            set { _cost = value; }
            get { return _cost; }
        }

        /// <summary>
        /// �շ�
        /// </summary>
        public decimal? CHARGE
        {
            set { _charge = value; }
            get { return _charge; }
        }

        /// <summary>
        /// �շ���Ŀ���
        /// </summary>
        public int? CHARGE_ITEM_NO
        {
            set { _charge_item_no = value; }
            get { return _charge_item_no; }
        }

        /// <summary>
        /// �����Ŀ���
        /// </summary>
        public int? EXAM_ITEM_NO
        {
            set { _exam_item_no = value; }
            get { return _exam_item_no; }
        }

        /// <summary>
        /// �շ���Ŀ���
        /// </summary>
        public string CHARGE_ITEM_CLASS
        {
            set { _charge_item_class = value; }
            get { return _charge_item_class; }
        }

        /// <summary>
        /// �շ��������
        /// </summary>
        public string CHARGE_CLASS_NAME
        {
            set { _charge_class_name = value; }
            get { return _charge_class_name; }
        }


        /// <summary>
        /// ������Ŀ���
        /// </summary>
        public int? ITEM_NO
        {
            set { _item_no = value; }
            get { return _item_no; }
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
        /// ����
        /// </summary>
        public decimal? PRICE
        {
            set { _price = value; }
            get { return _price; }
        }

        #endregion Model
    }
}