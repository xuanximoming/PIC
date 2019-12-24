using System;
namespace SIS_Model
{
    /// <summary>
    /// 实体类--CHARGE_ITEM_CLASS_DICT，价表项目分类字典
    /// </summary>
    [Serializable]
    public class MChargeItemClassDict : ILL.IModel
    {
        public MChargeItemClassDict()
        { }
        #region Model
        private string _class_code; //项目分类代码
        private string _class_name; //项目分类名称

        /// <summary>
        ///项目分类代码 
        /// </summary>
        public string CLASS_CODE
        {
            set { _class_code = value; }
            get { return _class_code; }
        }

        /// <summary>
        ///项目分类名称 
        /// </summary>
        public string CLASS_NAME
        {
            set { _class_name = value; }
            get { return _class_name; }
        }
        #endregion Model

    }
}