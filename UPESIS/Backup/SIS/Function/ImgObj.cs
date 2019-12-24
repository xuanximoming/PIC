using System;
using System.Collections.Generic;
using System.Text;

namespace SIS
{
    /// <summary>
    /// ͼƬ������
    /// </summary>
    public class ImgObj
    {

        private string imagePath = "";
        private bool isCheck = true;
        private bool isReport = false;
        private string changeImagePath = "";
        private bool isSaved = false;
        private string serverpath = "";
        private object model = "";
        private bool isDel = false;
        private string inf = "";
        private string locMapPath = "";
        private object locMapObj;
        private string markImgPath = "";
        private string markInf = "";

        public ImgObj(string localPath, bool isCheck, object model)
        {
            this.imagePath = localPath;
            this.isCheck = isCheck;
            //this.serverpath = serverpath;
            //this.imageID = imageid;
            this.model = model;
        }

        public ImgObj()
        {
        }

        /// <summary>
        /// ���ݿ��е�model
        /// </summary>
        public object MImage
        {
            set { this.model = value; }
            get { return this.model; }
        }

        /// <summary>
        /// ͼƬID
        /// </summary>
        //public string ImageID
        //{
        //    set { this.imageID = value; }
        //    get { return this.imageID; }
        //}

        /// <summary>
        /// δ���ã��ı�ͼƬ·����
        /// </summary>
        public string ChangeImagePath
        {
            get { return this.changeImagePath; }
            set { this.changeImagePath = value; }
        }

        /// <summary>
        /// ͼ�񱾵�·��
        /// </summary>
        public string ImagePath
        {
            get { return this.imagePath.Trim(); }
            set { this.imagePath = value.Trim(); }
        }

        /// <summary>
        /// ��ʾ�Ƿ�ѡ��
        /// </summary>
        public bool IsCheck
        {
            get { return this.isCheck; }
            set { this.isCheck = value; }
        }
        /// <summary>
        /// �Ƿ��ѱ���
        /// </summary>
        public bool IsReport
        {
            get { return this.isReport; }
            set { this.isReport = value; }
        }

        /// <summary>
        /// ��ʾͼ���ѱ���
        /// </summary>
        public bool IsSaved
        {
            get { return this.isSaved; }
            set { this.isSaved = true; }
        }
        /// <summary>
        /// ͼƬ�������ϵ�·��
        /// </summary>
        public string ServerPath
        {
            get { return this.serverpath; }
            set { this.serverpath = value; }
        }
        /// <summary>
        /// ͼƬ�Ƿ�ɾ��
        /// </summary>
        public bool IsDeleted
        {
            set { this.isDel = value; }
            get { return this.isDel; }
        }
        /// <summary>
        /// ���ݿ���LOCATION_MAP��model
        /// </summary>
        public object MLocationMap
        {
            set { this.locMapObj = value; }
            get { return this.locMapObj; }
        }

        /// <summary>
        /// ��λͼ����·��
        /// </summary>
        public string LocMapPath
        {
            get { return this.locMapPath.Trim(); }
            set { this.locMapPath = value.Trim(); }
        }
        /// <summary>
        /// ��λͼ����
        /// </summary>
        public string Inf
        {
            get { return this.inf; }
            set { this.inf = value; }
        }
        /// <summary>
        /// ������ͼ��·��
        /// </summary>
        public string MarkImgPath
        {
            get { return this.markImgPath; }
            set { this.markImgPath = value; }
        }
        /// <summary>
        /// ������Ϣ
        /// </summary>
        public string MarkInf
        {
            get { return this.markInf; }
            set { this.markInf = value; }
        }

        public ImgObj Copy()
        {
            ImgObj ob = new ImgObj();
            ob.ImagePath = this.imagePath;
            ob.inf = this.inf;
            ob.isCheck = this.isCheck;
            ob.isDel = this.isDel;
            ob.isReport = this.isReport;
            ob.isSaved = this.isSaved;
            ob.locMapObj = this.locMapObj;
            ob.locMapPath = this.locMapPath;
            ob.model = this.model; ob.serverpath = this.serverpath;
            ob.changeImagePath = this.changeImagePath;
            ob.markImgPath = this.markImgPath;
            ob.markInf = this.markInf;
            return ob;
        }
    }
}