using System;
using System.Collections.Generic;
using System.Text;

namespace SIS
{
    /// <summary>
    /// 图片对象类
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
        /// 数据库中的model
        /// </summary>
        public object MImage
        {
            set { this.model = value; }
            get { return this.model; }
        }

        /// <summary>
        /// 图片ID
        /// </summary>
        //public string ImageID
        //{
        //    set { this.imageID = value; }
        //    get { return this.imageID; }
        //}

        /// <summary>
        /// 未启用（改变图片路径）
        /// </summary>
        public string ChangeImagePath
        {
            get { return this.changeImagePath; }
            set { this.changeImagePath = value; }
        }

        /// <summary>
        /// 图像本地路径
        /// </summary>
        public string ImagePath
        {
            get { return this.imagePath.Trim(); }
            set { this.imagePath = value.Trim(); }
        }

        /// <summary>
        /// 表示是否选择
        /// </summary>
        public bool IsCheck
        {
            get { return this.isCheck; }
            set { this.isCheck = value; }
        }
        /// <summary>
        /// 是否已报告
        /// </summary>
        public bool IsReport
        {
            get { return this.isReport; }
            set { this.isReport = value; }
        }

        /// <summary>
        /// 表示图像已保存
        /// </summary>
        public bool IsSaved
        {
            get { return this.isSaved; }
            set { this.isSaved = true; }
        }
        /// <summary>
        /// 图片服务器上的路径
        /// </summary>
        public string ServerPath
        {
            get { return this.serverpath; }
            set { this.serverpath = value; }
        }
        /// <summary>
        /// 图片是否删除
        /// </summary>
        public bool IsDeleted
        {
            set { this.isDel = value; }
            get { return this.isDel; }
        }
        /// <summary>
        /// 数据库中LOCATION_MAP的model
        /// </summary>
        public object MLocationMap
        {
            set { this.locMapObj = value; }
            get { return this.locMapObj; }
        }

        /// <summary>
        /// 定位图本地路径
        /// </summary>
        public string LocMapPath
        {
            get { return this.locMapPath.Trim(); }
            set { this.locMapPath = value.Trim(); }
        }
        /// <summary>
        /// 定位图描述
        /// </summary>
        public string Inf
        {
            get { return this.inf; }
            set { this.inf = value; }
        }
        /// <summary>
        /// 处理后的图像路径
        /// </summary>
        public string MarkImgPath
        {
            get { return this.markImgPath; }
            set { this.markImgPath = value; }
        }
        /// <summary>
        /// 处理信息
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