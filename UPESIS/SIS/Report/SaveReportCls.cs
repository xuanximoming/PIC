using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using ILL;
using SIS_BLL;
using SIS_Model;
using System.Windows.Forms;
using System.Data;

namespace SIS
{
    public class SaveReportCls
    {
        private BImage bImage = new BImage();
        private string ServerPath="";
        //private AxDSOFramer.AxFramerControl xFramerControl1;
        private MReport mReport;
        private BReport bReport = new BReport();
        public ImageCopy imgCopy = new ImageCopy();

        private MWorkList mWorkList;
        public SaveReportCls()
        {
        }
        public SaveReportCls(SIS_Model.MWorkList worklist, SIS_Model.MReport mReport, List<ImgObj> arrayImg)
        {
            this.mWorkList = worklist;
            this.mReport = mReport;
            //this.xFramerControl1 = xFramerControl1;
            ServerPath = GetConfig.ServerImgDir + "/" + Convert.ToDateTime(worklist.REQ_DATE_TIME).ToString("yyyyMMdd") + "/" + worklist.EXAM_ACCESSION_NUM;
            //SaveReport();
            //SaveImage(arrayImg,worklist);
        }
        /// <summary>
        /// 保存报告内容
        /// </summary>
        /// <param name="worklist"></param>
        /// <param name="xFramerControl1"></param>
        public bool SaveReport()
        {
            FileOperator FileOp = new FileOperator();
            string ReportPath = System.Windows.Forms.Application.StartupPath + "\\temp\\NewReport.doc";
            mReport.REPORT_NAME = FileOp.FileByte(ReportPath);
            int i = 0;
            if (bReport.Exists(mReport))
                i = bReport.Update(mReport, " where EXAM_NO='" + mReport.EXAM_NO + "'");
            else
            {
                i = bReport.Add(mReport);
                if (i < 0)
                    return false;
                this.mWorkList.STUDY_DATE_TIME = System.DateTime.Now;
            }
            this.mWorkList.REPORT_DOCTOR = ((SIS_Model.MUser)frmMainForm.iUser).DOCTOR_ID;
            BWorkList bw = new BWorkList();
            i = bw.Update(this.mWorkList, "where EXAM_ACCESSION_NUM = '" + this.mWorkList.EXAM_ACCESSION_NUM + "'");
            return i < 0 ? false : true;
        }
        /// <summary>
        /// 保存图片并记录入图片表(注意是否打勾)
        /// </summary>
        /// <param name="arrayImg"></param>
        public bool SaveImage(List<ImgObj> arrayImg, SIS_Model.MWorkList worklist)
        {
            bool isSuccess = true;
            int j = 0;
            for (int i = 0; i < arrayImg.Count; i++)
            {
                ImgObj obj = (ImgObj)arrayImg[i];
                MImage model = (MImage)obj.MImage;
                if (model == null)
                {
                    model = new MImage();
                    model.IMAGE_PATH = CreateServerPath(obj.ImagePath);
                    model.EXAM_ACCESSION_NUM = worklist.EXAM_ACCESSION_NUM;
                }
                else
                    model.IMAGE_PATH = CreateServerPath(obj.ImagePath);
                model.IS_PRINT = (obj.IsCheck == true ? 1 : 0);
                model.IMAGE_DATE = System.DateTime.Now;
                if (obj.IsDeleted)
                {
                    imgCopy.DeleteImg(model);
                }
                else
                {
                    if (imgCopy.FileUpLoad(model, obj.ImagePath, false) != 1)
                    {
                       // MessageBox.Show("图片" + obj.ImagePath + "保存失败,请检查网络连接情况", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        isSuccess = false;
                    }
                    else
                        j++;
                }
            }
            worklist.IMAGE_COUNTS = j;
            return isSuccess;
        }

        private string CreateServerPath(string LocalPath)
        {
            string path = this.ServerPath + "/" + LocalPath.Substring(LocalPath.LastIndexOf("\\") + 1);
            return path;
        }
        //public ArrayList ReGetImg()
        //{
        //    mWorkList.REPORT_DOCTOR = 1;
        //    return imgCopy.LoadImages(mWorkList);
        //}
       
    }
}
