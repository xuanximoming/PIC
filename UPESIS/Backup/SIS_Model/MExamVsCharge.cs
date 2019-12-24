using System;
using System.Text;

namespace SIS_Model
{
    /// <summary>
    /// ʵ����EXAM_VS_CHARGE�������Ŀ��۱���Ŀ����
    /// </summary>
    [Serializable]
    public class MExamVsCharge:ILL.IModel
    {
        public MExamVsCharge()
        { 
        }
        #region Model
        private string _exam_item_code;     //�����Ŀ����
        private int? _charge_item_no;       //�շ���Ŀ���
        private string _charge_item_code;   //�շ���Ŀ����
        private string _charge_item_spec;   //�շ���Ŀ���
        private int? _amount;               //����
        private string _units;              //��λ

        /// <summary>
        /// �����Ŀ����
        /// </summary>
        public string EXAM_ITEM_CODE
        {
            set { _exam_item_code = value; }
            get { return _exam_item_code; }
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
        #endregion Model
    }
}