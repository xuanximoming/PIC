using System;

namespace PACS_Model
{
    /// <summary>
    /// ʵ����--EXAM_VS_CHARGE�������Ŀ��۱���Ŀ����
    /// </summary>
    [Serializable]
    public class MExamVsCharge:ILL.IModel
    {
        public MExamVsCharge()
        { }
        #region Model
        private string _exam_item_code;     //�����Ŀ����
        private int? _charge_item_no;       //�۱���Ŀ���
        private string _charge_item_code;   //�۱���Ŀ����
        private string _charge_item_spec;   //�۱���Ŀ��񣬴�����Ϊ�գ����ʾ���ȷ��
        private int? _amount;               //��Ӧ�۱���Ŀ��
        private string _units;              //�۱���Ŀ��λ

        /// <summary>
        /// �����Ŀ����
        /// </summary>
        public string EXAM_ITEM_CODE
        {
            set { _exam_item_code = value; }
            get { return _exam_item_code; }
        }

        /// <summary>
        /// �۱���Ŀ���
        /// </summary>
        public int? CHARGE_ITEM_NO
        {
            set { _charge_item_no = value; }
            get { return _charge_item_no; }
        }

        /// <summary>
        /// �۱���Ŀ����
        /// </summary>
        public string CHARGE_ITEM_CODE
        {
            set { _charge_item_code = value; }
            get { return _charge_item_code; }
        }

        /// <summary>
        /// �۱���Ŀ���
        /// </summary>
        public string CHARGE_ITEM_SPEC
        {
            set { _charge_item_spec = value; }
            get { return _charge_item_spec; }
        }

        /// <summary>
        /// ��Ӧ�۱���Ŀ��
        /// </summary>
        public int? AMOUNT
        {
            set { _amount = value; }
            get { return _amount; }
        }

        /// <summary>
        /// �۱���Ŀ��λ
        /// </summary>
        public string UNITS
        {
            set { _units = value; }
            get { return _units; }
        }
        #endregion Model
    }
}
