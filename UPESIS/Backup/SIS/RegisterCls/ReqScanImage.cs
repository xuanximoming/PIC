using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using SIS_BLL;
using SIS_Function;
using ILL;
using BaseControls.PictureBoxs;
using System.Drawing;

namespace SIS.RegisterCls
{
    public class ReqScanImage
    {
        public Pick pick;
        public Camera camera;
        public int count = 0, p_Y = 0;
        private FileOperator fileOpe;
        private Panel p_Show;
        private PictureBox ptb;
        private bool isUplond;
        private string ImageDir = Application.StartupPath + "\\ScanImages";

        public ReqScanImage(ref PictureBox ptb,Panel p_show,Panel p_Camera,ref bool isUpload)
        {
            this.fileOpe = new FileOperator();
            this.p_Show = p_show;
            this.ptb = ptb;
            this.isUplond = isUpload;
            switch (GetConfig.CS_CameraMode)
            {
                case "CAMERA":
                    this.camera = new Camera(p_Camera.Handle, p_Camera.Width, p_Camera.Height);
                    this.camera.RecievedFrame += new Camera.RecievedFrameEventHandler(camera_RecievedFrame);
                    break;
                case "PICK":
                    this.pick = new Pick(ptb.Handle, ptb.Left, ptb.Top, ptb.Width, ptb.Height);
                    break;
                default:
                    break;
            }
        }

        private void camera_RecievedFrame(System.Drawing.Bitmap bm)
        {
            this.ptb.Image = bm;
        }

        public void Start()
        {
            switch (GetConfig.CS_CameraMode)
            {
                case "CAMERA":
                    this.camera.StartWebCam();
                    break;
                case "PICK":
                    this.pick.Start();
                    break;
                default:
                    break;
            }
        }

        public void NewScan()
        {
            if (System.IO.Directory.Exists(ImageDir))
                System.IO.Directory.Delete(ImageDir,true);
            System.IO.Directory.CreateDirectory(ImageDir);
            this.count = 0;
            //this.p_Y = 0;
            this.p_Show.Controls.Clear();
        }

        public void LoadImages()
        {
            string[] images = System.IO.Directory.GetFiles(ImageDir);
            foreach (string image in images)
            {
                AddImage(image);
            }
        }

        private void AddImage(string image)
        {
            userCtrPictureEx uptb = new userCtrPictureEx();
            uptb.Picture.SetCheckBoxVisible(false);
            uptb.LabelBorderStyle = userCtrPictureEx.LBorderStyle.All;
            uptb.LabelBorder = 3;
            uptb.Name = count.ToString(); 
            uptb.Size = new System.Drawing.Size(150, 150);
            uptb.Picture.LoadFile(image);
            if (uptb.Picture.Image != null)
            {
                this.p_Show.Controls.Add(uptb);
                uptb.Dock = DockStyle.Top;
                count++;
                this.isUplond = false;
            }
        }

        public void GrabImage()
        {
            switch (GetConfig.CS_CameraMode)
            {
                case "CAMERA":
                    if (ptb.Image != null)
                    {
                        Bitmap bmp = new Bitmap(ptb.Image);
                        bmp.Save(ImageDir+"\\" + count.ToString() + ".bmp");
                    }
                    break;
                case "PICK":
                    this.pick.GrabImage(ImageDir + "\\" + count.ToString() + ".bmp");
                    break;
                default:
                    break;
            }
            this.AddImage(ImageDir + "\\" + count.ToString() + ".bmp");
        }

        public void DeleteImage()
        {
            for (int i = 0; i < this.p_Show.Controls.Count;i++)
            {
                userCtrPictureEx ptb = (userCtrPictureEx)this.p_Show.Controls[i];
                if (ptb.Picture.IsSelecting)
                    this.p_Show.Controls.RemoveAt(i);
            }
        }

        public bool SaveScanImg(string ExamAccessionNum,string DBUser)
        {
            BReqScanImage bReqScanImage = new BReqScanImage();
            Hashtable ht = new Hashtable();
            for (int i = 0; i < this.count; i++)
            {
                switch (GetConfig.DALAndModel)
                {
                    case "SIS":
                        SIS_Model.MReqScanImage smReqScanImage = new SIS_Model.MReqScanImage();
                        smReqScanImage.EXAM_ACCESSION_NUM = ExamAccessionNum;
                        smReqScanImage.IMAGE_INDEX = i;
                        smReqScanImage.OPERATOR = DBUser;
                        smReqScanImage.IMAGE_FILE = this.fileOpe.FileByte(ImageDir + "\\" + i.ToString() + ".bmp");
                        ht.Add(i, smReqScanImage);
                        break;
                    case "PACS":
                        PACS_Model.MReqScanImage pmReqScanImage = new PACS_Model.MReqScanImage();
                        pmReqScanImage.EXAM_ACCESSION_NUM = ExamAccessionNum;
                        pmReqScanImage.IMAGE_INDEX = i;
                        pmReqScanImage.OPERATOR = DBUser;
                        pmReqScanImage.IMAGE_FILE = this.fileOpe.FileByte(ImageDir + "\\" + i.ToString() + ".bmp");
                        ht.Add(i, pmReqScanImage);
                        break;
                }
            }
            if (ht.Count == 0)
                return true;
            else
                if (bReqScanImage.AddMore(ht) > 0)
                {
                    this.isUplond = true;
                    return true;
                }
                else
                    return false;
        }

        public void Close()
        {
            switch (GetConfig.CS_CameraMode)
            {
                case "CAMERA":
                    this.camera.CloseWebcam();
                    break;
                case "PICK":
                    this.pick.Stop();
                    break;
                default:
                    break;
            }
            this.ptb.Image = null;
        }
    }
}
