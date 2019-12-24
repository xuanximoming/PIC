using System;
using System.Collections.Generic;
using System.Text;

namespace SIS_Model
{
    /// <summary>
    /// ʵ����SYSTEM_FUN��ϵͳ���ܱ��������������ͣ����
    /// </summary>
    public class MSystemFun : ILL.IModel
    {

       private int? modelId;        //ģ��ID
       private int? upModelId;      //�ϼ�ģ��ID
       private string modelClass;   //ģ�鼶��
       private int? delFlag;        //ɾ����־ 1����ʾɾ��
       private int? sortFlag;       //�����ʶ
       private string modelPlace;   //����Ŀ¼λ��
       private string modelName;    //ģ������
       private string image_address;//ͼ������

        /// <summary>
        /// ģ��ID
        /// </summary>
       public int? MODEL_ID
       {
           get{ return this.modelId; }
           set{ this.modelId = value;}
       }

        /// <summary>
        /// �ϼ�ģ��ID
        /// </summary>
       public int? UP_MODEL_ID
       {
           get { return this.upModelId; }
           set { this.upModelId = value; }
       }
        
        /// <summary>
        /// ģ�鼶��
        /// </summary>
       public string MODEL_CLASS
       {
           get{return this.modelClass;}
           set{this.modelClass = value;}
       }

        /// <summary>
        /// ɾ����־
        /// </summary>
       public int?  DEL_FLAG
       {
           get { return this.delFlag; }
           set { this.delFlag = value; }
       }

        /// <summary>
        /// �����־
        /// </summary>
       public int? SORT_FLAG
       {
           get { return this.sortFlag; }
           set { this.sortFlag = value; }
       }

        /// <summary>
        /// ����ģ��λ��
        /// </summary>
       public string MODEL_PLACE
       {
           get { return this.modelPlace; }
           set { this.modelPlace = value; }
       }

        /// <summary>
        /// ģ������
        /// </summary>
       public string MODEL_NAME
       {
           get { return this.modelName; }
           set { this.modelName = value; }
       }

        /// <summary>
        /// ͼ������
        /// </summary>
        public string IMAGE_ADDRESS
        {
            get { return this.image_address; }
            set { this.image_address = value; }
        }

        /// <summary>
        /// �޲ι��췽��
        /// </summary>
       public MSystemFun()
       {
       }

        /// <summary>
        /// ���ι��췽��
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