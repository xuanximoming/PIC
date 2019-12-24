using System;
using System.Collections.Generic;
using System.Text;

namespace SIS_Model
{
    /// <summary>
    /// 实体类SYSTEM_FUN，系统功能表，关联于主界面可停靠窗
    /// </summary>
    public class MSystemFun : ILL.IModel
    {

       private int? modelId;        //模块ID
       private int? upModelId;      //上级模块ID
       private string modelClass;   //模块级别
       private int? delFlag;        //删除标志 1：表示删除
       private int? sortFlag;       //排序标识
       private string modelPlace;   //最终目录位置
       private string modelName;    //模块名称
       private string image_address;//图像名称

        /// <summary>
        /// 模块ID
        /// </summary>
       public int? MODEL_ID
       {
           get{ return this.modelId; }
           set{ this.modelId = value;}
       }

        /// <summary>
        /// 上级模块ID
        /// </summary>
       public int? UP_MODEL_ID
       {
           get { return this.upModelId; }
           set { this.upModelId = value; }
       }
        
        /// <summary>
        /// 模块级别
        /// </summary>
       public string MODEL_CLASS
       {
           get{return this.modelClass;}
           set{this.modelClass = value;}
       }

        /// <summary>
        /// 删除标志
        /// </summary>
       public int?  DEL_FLAG
       {
           get { return this.delFlag; }
           set { this.delFlag = value; }
       }

        /// <summary>
        /// 排序标志
        /// </summary>
       public int? SORT_FLAG
       {
           get { return this.sortFlag; }
           set { this.sortFlag = value; }
       }

        /// <summary>
        /// 最终模块位置
        /// </summary>
       public string MODEL_PLACE
       {
           get { return this.modelPlace; }
           set { this.modelPlace = value; }
       }

        /// <summary>
        /// 模块名称
        /// </summary>
       public string MODEL_NAME
       {
           get { return this.modelName; }
           set { this.modelName = value; }
       }

        /// <summary>
        /// 图像名称
        /// </summary>
        public string IMAGE_ADDRESS
        {
            get { return this.image_address; }
            set { this.image_address = value; }
        }

        /// <summary>
        /// 无参构造方法
        /// </summary>
       public MSystemFun()
       {
       }

        /// <summary>
        /// 含参构造方法
        /// </summary>
        /// <param name="MModelId"></param>
        /// <param name="MUpModelId"></param>
        /// <param name="MModelClass"></param>
        /// <param name="MDelFlag"></param>
        /// <param name="MSortFlag"></param>
        /// <param name="MModelPlace"></param>
        /// <param name="MModelName"></param>
       public MSystemFun(int? MModelId,int? MUpModelId,string MModelClass,int? MDelFlag,int? MSortFlag,string MModelPlace,string MModelName )
       {
           this.modelId = MODEL_ID;
           this.upModelId = UP_MODEL_ID;
           this.modelClass = MODEL_CLASS;
           this.delFlag = DEL_FLAG;
           this.sortFlag = SORT_FLAG;
           this.modelPlace = MODEL_PLACE;
           this.modelName = MODEL_NAME;
       }

    }
}