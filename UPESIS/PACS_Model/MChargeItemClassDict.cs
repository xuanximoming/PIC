using System;
namespace PACS_Model
{
    /// <summary>
    /// 实体类--CHARGE_ITEM_CLASS_DICT ，价表项目分类字典
    /// </summary>
    [Serializable]
    public class MChargeItemClassDict : ILL.IModel
    {
        public MChargeItemClassDict()
        { }
        #region Model
        private string _class_code; //类别代码
        private string _class_name; //类别名称

        /// <summary>
        /// 类别代码
        /// </summary>
        public string CLASS_CODE
        {
            set { _class_code = value; }
            get { return _class_code; }
        }

        /// <summary>
        /// 类别名称
        /// </summary>
        public string CLASS_NAME
        {
            set { _class_name = value; }
            get { return _class_name; }
        }

        #endregion Model
    }
}