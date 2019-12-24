using System;
using System.Text;
using System.Collections.Generic;

namespace SIS
{
    /// <summary>
    /// EXAM_INF类，主要作用显示主窗体上方栏的病人信息，主要包括姓名、ID、性别、检查申请号；
    /// 其他还有申请时间、图像、检查类别和检查子类
    /// </summary>
    public  class ExamInf
    {
        public ExamInf()
        {
        }

        /// <summary>
        /// EXAM_INF类的构造函数
        /// </summary>
        /// <param name="mWorkList">WorkList实例</param>
        /// <param name="ArrayImages">图像列表</param>
        public ExamInf(SIS_Model.MWorkList mWorkList, List<ImgObj> ArrayImages)
        {
            this.patientName = mWorkList.PATIENT_NAME;
            this.patientId = mWorkList.PATIENT_ID;
            this.patientSex = mWorkList.PATIENT_SEX;
            this.examAccessionNum = mWorkList.EXAM_ACCESSION_NUM;
            this.reqDateTime = Convert.ToDateTime(mWorkList.REQ_DATE_TIME).ToString("yyyyMMdd");
            this.arrayImages = ArrayImages;
            this.examClass = mWorkList.EXAM_CLASS;
            this.examSubClass = mWorkList.EXAM_SUB_CLASS;
        }

        //字段
        private string patientName = "";
        private string patientId = "";
        private string patientSex = "";
        private string examAccessionNum = "";
        private string reqDateTime = "";
        private List<ImgObj> arrayImages = new List<ImgObj>();
        private string examClass = "";
        private string examSubClass = "";

        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatientName
        {
            get { return this.patientName; }
            set { this.patientName = value; }
        }

        /// <summary>
        /// 病人ID
        /// </summary>
        public string PatientId
        {
            get { return this.patientId; }
            set { this.patientId = value; }
        }

        /// <summary>
        /// 病人性别
        /// </summary>
        public string PatientSex
        {
            get { return this.patientSex; }
            set { this.patientSex = value; }
        }

        /// <summary>
        /// 检查申请号
        /// </summary>
        public string ExamAccessionNum
        {
            get { return this.examAccessionNum; }
            set { this.examAccessionNum = value; }
        }

        /// <summary>
        /// 申请时间
        /// </summary>
        public string ReqDateTime
        {
            get { return this.reqDateTime; }
            set { this.reqDateTime = value; }
        }

        /// <summary>
        /// 图像列表
        /// </summary>
        public List<ImgObj> ArrayImages
        {
            get { return this.arrayImages; }
            set { this.arrayImages = value; }
        }

        /// <summary>
        /// 检查类别
        /// </summary>
        public string ExamClass
        {
            get { return this.examClass; }
            set { this.examClass = value; }
        }

        /// <summary>
        /// 检查子类
        /// </summary>
        public string ExamSubClass
        {
            get { return this.examSubClass; }
            set { this.examSubClass = value; }
        }

    }
}