using BaseControls.Docking;
using ILL;
using SIS.ImgGather;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SIS
{
    public partial class frmImageGather : Form
    {
        [DllImport("kernel32.dll")]
        public static extern int Beep(int hz, int time);
        public bool isBack = true;
        private Gather gather;
        private frmBackImages backImages;
        public frmPreferImages preferImages;
        private MSComm msComm;
        private DeserializeDockContent m_deserializeDockContent;
        private frmQuickReg frmQuickReg;
        public delegate void GatherCallBack(Bitmap bt);
        private string[] buttons = GetConfig.COS_ButtonCatch.Split(',');

        public frmImageGather()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.p_Main.Dock = DockStyle.Fill;
            GatherCallBack gtb = new GatherCallBack(GetCallBack);
            gather = new Gather(gtb);
            gather.parentHwnd = this.Handle;
            m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
            this.msComm = new MSComm(this.axMSComm1);
            this.msComm.onCommGather = new SIS.ImgGather.MSComm.OnCommGather(GatherMultimedia);
            // UsbjoyStick.joySetCapture(this.Handle, UsbjoyStick.JOYSTICKID1, 100, false);//测试USE手柄
            if (gather.OpenCard())
            {
                gather.initCard();
                if (GetConfig.COS_IsUse)
                {
                    if (!this.msComm.OpenCom())
                        MessageBoxEx.Show("串行端口打开失败！请检查设置参数是否正确！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (GetConfig.COS_CommMode == "2")
                        UsbjoyStick.joySetCapture(this.Handle, UsbjoyStick.JOYSTICKID1, 100, false);
                }
            }
            else
                MessageBoxEx.Show("采集卡打开失败！请确保正确安装上采集卡！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //this.axHYImage1.OnEventCallback += new EventHandler(axHYImage1_OnEventCallback);
            //if (this.OpenCard())
            //{
            //    this.InitCard();
            //    if (GetConfig.COS_IsUse)
            //        if (!this.msComm.OpenCom())
            //            MessageBoxEx.Show("串行端口打开失败！请检查设置参数是否正确！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //    MessageBoxEx.Show("采集卡打开失败！请确保正确安装上采集卡！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            string configFile = Application.StartupPath + "\\Config\\ImgGatDockPanel.config";
            if (!dockPanel.LoadFromXml(configFile, m_deserializeDockContent))
            {
                backImages = new frmBackImages(this.p_Main);
                preferImages = new frmPreferImages(this.p_Main);
                backImages.dbClick = new frmBackImages.DbClick(PtbCtlDbClick);
                preferImages.dbClick = new frmPreferImages.DbClick(PtbCtlDbClick);
                backImages.Show(this.dockPanel, BaseControls.Docking.DockState.DockRight);
                preferImages.Show(this.dockPanel, BaseControls.Docking.DockState.DockRight);
                if (GetConfig.IsQuickReg)
                {
                    frmQuickReg = new frmQuickReg(this.p_Main);
                    frmQuickReg.Show(this.dockPanel, BaseControls.Docking.DockState.DockRight);
                }
            }
        }
        /// <summary>
        /// 重新打开采集卡
        /// </summary>
        /// <returns></returns>
        public bool ReSetCard()
        {
            if (GetConfig.IMS_CardProduct == "OK")
            {
                gather.CloseCard();
                gather.OpenCard();
                gather.initCard();
            }
            return true;
        }
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (GetConfig.COS_CommMode == "2")
            {
                switch (m.WParam.ToInt32())
                {
                    case UsbjoyStick.JOY_BUTTON1CHG:
                        this.Catch(buttons[0]);
                        break;
                    case UsbjoyStick.JOY_BUTTON2CHG:
                        this.Catch(buttons[1]);
                        break;
                    case UsbjoyStick.JOY_BUTTON3CHG:
                        this.Catch(buttons[2]);
                        break;
                    case UsbjoyStick.JOY_BUTTON4CHG:
                        this.Catch(buttons[3]);
                        break;
                }
            }
            base.WndProc(ref m);
        }

        private void GetCallBack(Bitmap bt)
        {
            this.ptb_Gather.Image = bt;
            if (frmMainForm.myMainForm.iView != null)
                frmMainForm.myMainForm.iView.pictureBox.Image = bt;
        }

        private IDockContent GetContentFromPersistString(string persistString)
        {
            switch (persistString)
            {
                case "SIS.frmBackImages":
                    backImages = new frmBackImages(this.p_Main);
                    backImages.dbClick = new frmBackImages.DbClick(PtbCtlDbClick);
                    return backImages;
                case "SIS.frmPreferImages":
                    preferImages = new frmPreferImages(this.p_Main);
                    preferImages.dbClick = new frmPreferImages.DbClick(PtbCtlDbClick);
                    return preferImages;
                case "SIS.frmQuickReg":
                    frmQuickReg = new frmQuickReg(this.p_Main);
                    frmQuickReg.Show(this.dockPanel, BaseControls.Docking.DockState.DockRightAutoHide);
                    return preferImages;
                default:
                    return null;
            }
        }

        private void PtbCtlDbClick(BaseControls.PictureBoxs.userCtrPicture ctl)
        {
            if (ctl == null)
            {
                this.ptb_View.Visible = false;
                this.ptb_View.Image = null;
            }
            else
            {
                this.ptb_View.Visible = true;
                this.ptb_View.Image = ctl.Image;
            }
        }

        private void GatherMultimedia(string GatherMode)
        {
            if (this.msComm.CommMode == "0")
            {
                if (this.backImages.Visible)
                    GatherMode = "3";
                if (this.preferImages.Visible || frmMainForm.GatherOrRpt == 1)
                    GatherMode = "1";
            }
            this.Catch(GatherMode);
        }

        private void Catch(string mode)
        {
            switch (mode)
            {
                case "1":// 单帧采集
                    this.PreferStaticCatch();
                    break;
                case "2":// 动态采集
                    this.PreferDinamicCatch();
                    //System.Media.SystemSounds.Beep.Play();
                    break;
                case "3":// 后台单帧
                    this.BackStaticCatch();
                    break;
                case "4": // 后台动态
                    this.BackDinamicCatch();
                    //System.Media.SystemSounds.Hand.Play();
                    break;
            }
            try
            {
                //MessageBox.Show("OK");
                PlaySound("alarm.wav", 0, 0);
            }
            catch
            {
                //MessageBox.Show("Error");
            }
        }
        [DllImport("Winmm.dll")]
        public static extern long PlaySound(string name, long module, long flag);
        private void PreferStaticCatch()
        {
            if (this.ptb_Gather.Image == null)
                return;
            try
            {
                Image img = (Image)this.ptb_Gather.Image.Clone();
                img = FileOperator.CutImg(img);
                if (frmMainForm.GatherOrRpt == 1)
                {
                    if (frmMainForm.myMainForm.qQuery.frm.isCanOpe)
                    {
                        FileOperator.BackCatchImg(img);
                        frmMainForm.myMainForm.qQuery.frm.frmRptImg.AddPreferImage(img);
                        frmMainForm.myMainForm.qQuery.frm.frmRptImg.Activate();
                        this.preferImages.LoadImages();
                        int i = Beep(1000, 500);
                        //System.Media.SystemSounds.Asterisk.Play();

                    }
                }
                if (frmMainForm.GatherOrRpt == 0 && this.Visible)
                {
                    FileOperator.BackCatchImg(img);
                    this.preferImages.AddPreferImage(img);
                    this.preferImages.Activate();
                    int i = Beep(1000, 500);

                    //System.Media.SystemSounds.Asterisk.Play();

                }

            }
            catch { }
        }
        ///// <summary>
        ///// 备份采集的图片
        ///// </summary>
        //private void BackCatchImg(Image img)
        //{
        //    //备份采集的图片
        //    if (frmMainForm.examInf.ExamAccessionNum != "" && frmMainForm.examInf.ReqDateTime != "")
        //    {
        //        string BackDir = string.Format(Application.StartupPath+"\\BCImages\\{0}\\{1}\\", DateTime.Now.ToString("yyyyMMdd"), frmMainForm.examInf.ExamAccessionNum);
        //        if (!Directory.Exists(BackDir))
        //            Directory.CreateDirectory(BackDir);
        //        string FileName = frmMainForm.examInf.ExamAccessionNum + DateTime.Now.ToString("yyyyMMddhhmmssfff") + ".jpg";
        //        FileOperator.SaveAsJPEG(img, BackDir+FileName, GetConfig.IMS_Quality);
        //    }
        //   // MessageBoxEx.Show("");
        //}
        private void PreferDinamicCatch()
        {
            Beep(2000, 500);
        }

        private void BackStaticCatch()
        {
            if (this.ptb_Gather.Image == null)
                return;
            try
            {
                Image img = (Image)this.ptb_Gather.Image.Clone();

                if (this.Visible)
                {
                    this.backImages.AddBackImage(img);
                    this.backImages.Activate();
                    Beep(3000, 500);
                    //System.Media.SystemSounds.Exclamation.Play();
                }
            }
            catch { }
        }

        private void BackDinamicCatch()
        {
            Beep(4000, 500);
        }

        //private void axHYImage1_OnEventCallback(object sender, EventArgs e)
        //{
        //    int size = this.axHYImage1.GetImgBufsize();
        //    byte[] data = new byte[size];
        //    int width = 768, height = 580,length=data.Length;
        //    this.axHYImage1.GetVideoData(data, ref length, ref width, ref height, 100);
        //    Bitmap bt = ImageOpe.ByteToImage(data);
        //    if (bt != null)
        //        this.ptb_Gather.Image = bt;
        //}

        private void btn_StaticCatch_Click(object sender, EventArgs e)
        {
            if (this.ptb_Gather.Image == null)
                return;
            Image img = FileOperator.CutImg(this.ptb_Gather.Image);
            if (this.rb_Back.Checked)
            {

                this.backImages.AddBackImage(img);
                this.backImages.Activate();
            }
            if (this.rb_Prefer.Checked)
            {
                FileOperator.BackCatchImg(img);//备份一份到本地
                this.preferImages.AddPreferImage(img);
                this.preferImages.Activate();
            }
        }

        public object GetCatch()
        {
            object obj = this.ptb_Gather.Image.Clone();
            return obj;
        }

        private void btn_DinamicCatch_Click(object sender, EventArgs e)
        {

        }

        private void btn_CardSetting_Click(object sender, EventArgs e)
        {
            this.ReSetCard();//初始化卡
            //System.Diagnostics.Process pr = new System.Diagnostics.Process();
            //pr.StartInfo.FileName = GetConfig.IMS_CardExe;
            //try { pr.Start(); }
            //catch { MessageBoxEx.Show("采集设置程序路径不对！", "错误"); }
        }

        private void rb_Prefer_CheckedChanged(object sender, EventArgs e)
        {
            this.preferImages.Activate();
        }

        private void rb_Back_CheckedChanged(object sender, EventArgs e)
        {
            this.backImages.Activate();
        }

        private void ImgGather_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (frmMainForm.examInf.ExamAccessionNum == "")
                {
                    this.rb_Back.Checked = true;
                    this.rb_Prefer.Enabled = false;
                }
                else
                {
                    this.rb_Prefer.Checked = true;
                    this.rb_Prefer.Enabled = true;
                }
            }
        }

        private void frmImageGather_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.CloseCard();
            string configFile = Application.StartupPath + "\\Config\\ImgGatDockPanel.config";
            dockPanel.SaveAsXml(configFile);
            this.gather.CloseCard();
            this.msComm.CloseComm();
        }

        private void vtn_ShowView_Click(object sender, EventArgs e)
        {
            this.ptb_View.Visible = false;
            //this.ReSetCard();//重新打开卡01-20
        }
    }
}