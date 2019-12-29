using BaseControls.Docking;
using ILL;
using SIS_BLL;
using SIS_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SIS
{
    /// <summary>
    /// 主界面
    /// </summary>
    public partial class frmMainForm : Form
    {
        public static ExamInf examInf = new ExamInf();
        public static frmMainForm myMainForm = null;
        public static IModel iUser;
        private Form FormFun = new Form();
        private bool isLogout = false;
        private bool isAutoLock = true;
        private bool LockBegin = false;
        private frmLogin lo;
        public frmQuickQuery qQuery;
        public frmImageGather iGather;
        public frmImgView iView;
        private DeserializeDockContent m_deserializeDockContent;
        public static int GatherOrRpt = -1;
        public static bool isClose = false;
        private struct DockForm
        {
            public frmDockForm frmDock;
            public bool isShow;
        }
        private List<DockForm> frmDockList;

        public frmMainForm()
        {
            InitializeComponent();
            myMainForm = this;
        }

        /// <summary>
        /// 主界面构造函数1，根据配置文件的设置，初始化可停靠窗体
        /// </summary>
        /// <param name="user"></param>
        public frmMainForm(IModel user)
        {
            InitializeComponent();
            this.Text = GetConfig.HospitalName;
            this.frmDockList = new List<DockForm>();
            myMainForm = this;
            iUser = user;
            Extender.SetSchema(this.dockPanel, BaseControls.Docking.Extender.Schema.FromBase);
            m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
            if (GetConfig.DALAndModel == "SIS")
            {
                SIS_Model.MUser muser = (SIS_Model.MUser)iUser;
                this.tssl_User.Text = muser.DOCTOR_NAME;
                this.tssl_Dept.Text = muser.CLINIC_OFFICE;
                BuildStruct();
                this.initExamInfText();
                iGather = (frmImageGather)this.SetFormDisplay("图像采集", "SIS.frmImageGather");
                qQuery = (frmQuickQuery)this.SetFormDisplay("快速查询", "SIS.frmQuickQuery");
            }
            else
            {
                PACS_Model.MUser muser = (PACS_Model.MUser)iUser;
                this.tssl_User.Text = muser.USER_NAME;
                this.tssl_Dept.Text = muser.DEPT_NAME;
                this.p_Patient.Visible = false;
                switch (GetConfig.SystemType)
                {
                    case "DeptManage":
                        BuildStructPacsDeptManage();
                        break;
                    case "Register":
                        BuildStructPacs();
                        qQuery = (frmQuickQuery)this.SetFormDisplay("快速查询", "SIS.frmQuickQuery");
                        break;
                    case "QualityControl":
                        BuildStructPacsQualityControl();
                        break;
                }
            }
            this.timer_Main.Start();
            string configFile = Application.StartupPath + "\\Config\\MainDockPanel.config";
            if (File.Exists(configFile))
                dockPanel.LoadFromXml(configFile, m_deserializeDockContent);
            for (int i = 0; i < this.frmDockList.Count; i++)
            {
                if (!frmDockList[i].isShow)
                    frmDockList[i].frmDock.Show(this.dockPanel, BaseControls.Docking.DockState.DockLeft);
            }
        }

        /// <summary>
        /// 初始化病人信息栏
        /// </summary>
        public void initExamInfText()
        {
            this.l_ExamAccessionNum.Text = examInf.ExamAccessionNum;
            this.l_PatientId.Text = examInf.PatientId;
            this.l_PatientName.Text = examInf.PatientName;
            this.l_PatientSex.Text = examInf.PatientSex;
        }

        private IDockContent GetContentFromPersistString(string persistString)
        {
            for (int i = 0; i < this.frmDockList.Count; i++)
            {
                if (frmDockList[i].frmDock.Name == persistString)
                {
                    DockForm df = (DockForm)frmDockList[i];
                    df.isShow = true;
                    frmDockList[i] = df;
                    return frmDockList[i].frmDock;
                }
            }
            return null;
        }

        /// <summary>
        /// 主界面正在关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string configFile = Application.StartupPath + "\\Config\\MainDockPanel.config";
            if (this.isLogout)
            {
                dockPanel.SaveAsXml(configFile);
                return;
            }
            if (DialogResult.Cancel == MessageBoxEx.Show("确认要退出系统吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                e.Cancel = true;
            else
            {
                dockPanel.SaveAsXml(configFile);
                switch (GetConfig.DALAndModel)
                {
                    case "SIS":
                        if (Directory.Exists(Application.StartupPath + "\\SimpleViewer\\Reledatabase\\images"))
                            Directory.Delete(Application.StartupPath + "\\SimpleViewer\\Reledatabase\\images", true);
                        GetConfig.SetUG_DbUser(((SIS_Model.MUser)frmMainForm.iUser).DOCTOR_ID);
                        break;
                    case "PACS":
                        GetConfig.SetUG_DbUser(((PACS_Model.MUser)frmMainForm.iUser).DB_USER);
                        break;
                }

                if (this.iView != null)
                {
                    string location = this.iView.Location.X.ToString() + "," + this.iView.Location.Y.ToString() + "," + this.iView.Size.Width.ToString() + "," + this.iView.Size.Height.ToString();
                    GetConfig.SetRS_ImgLocation(location);
                }
                if (this.iGather != null)
                {
                    iGather.Close();
                }
                isClose = true;
                this.timer_Close.Enabled = true;
                this.timer_Close.Interval = 700;
                this.timer_Close.Start();
            }
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.timer_Close.Stop();
            try
            {
                Application.Exit();
            }
            catch
            {
                Environment.Exit(0);
            }

        }
        private void timer_Close_Tick(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// 动态夹杂着子系统模块,超声科
        /// </summary>
        private void BuildStruct()//动态加载子系统模块
        {
            if (GetConfig.SystemType.ToUpper() == "REGISTER")
            {
                BuildStructPacs();
            }
            else
            {
                BSystemFun BSysFun = new BSystemFun();
                MSystemFun MsysFun = new MSystemFun();

                DataTable dt = new DataTable();
                SIS_Model.MUser muser = (SIS_Model.MUser)iUser;

                switch (muser.DOCTOR_ROLE)
                {
                    case "1":
                        dt = BSysFun.GetList(" MODEL_CLASS='1' AND UP_MODEL_ID=0 AND MODEL_NAME ='检查登记' ORDER BY SORT_FLAG ");
                        break;
                    case "2":
                        dt = BSysFun.GetList(" MODEL_CLASS='1' AND UP_MODEL_ID=0 ORDER BY SORT_FLAG ");
                        break;
                }
                if (dt.Rows.Count > 0)
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        frmDockForm tsl = new frmDockForm();
                        tsl.DockHandler.GetPersistStringCallback = null;
                        tsl.DockHandler.PersistString = dt.Rows[i]["MODEL_ID"].ToString();
                        tsl.Name = dt.Rows[i]["MODEL_ID"].ToString();//将目录ID设置为名称
                        tsl.Tag = "SIS.comm.ToolboxPanel";
                        tsl.Text = dt.Rows[i]["MODEL_NAME"].ToString();
                        if (dt.Rows[i]["IMAGE_ADDRESS"].ToString() != "")
                            tsl.Icon = new Icon(Application.StartupPath + "\\images\\" + dt.Rows[i]["IMAGE_ADDRESS"].ToString());
                        tsl.p = this.p_Sub;
                        DockForm df = new DockForm();
                        df.frmDock = tsl;
                        df.isShow = false;
                        this.frmDockList.Add(df);
                    }
            }
        }

        /// <summary>
        /// 设置放射科登记系统的可停靠窗体
        /// </summary>
        private void BuildStructPacs()
        {
            frmDockForm tsl = new frmDockForm();
            tsl.DockHandler.GetPersistStringCallback = null;
            tsl.DockHandler.PersistString = "登记系统";
            tsl.Name = "登记系统";
            tsl.Tag = "frmRegister";
            tsl.Text = "登记系统";
            tsl.p = this.p_Sub;
            DockForm df = new DockForm();
            df.frmDock = tsl;
            df.isShow = false;
            this.frmDockList.Add(df);
        }

        /// <summary>
        /// 设定放射科科室管理左边导航条
        /// </summary>
        private void BuildStructPacsDeptManage()
        {
            frmDockForm tsl = new frmDockForm();
            tsl.DockHandler.GetPersistStringCallback = null;
            tsl.DockHandler.PersistString = "科室管理";
            tsl.Name = "科室管理";
            tsl.Tag = "frmDeptManage";
            tsl.Text = "科室管理";
            tsl.p = this.p_Sub;
            DockForm df = new DockForm();
            df.frmDock = tsl;
            df.isShow = false;
            this.frmDockList.Add(df);
        }

        /// <summary>
        /// 质控管理系统左边导航条
        /// </summary>
        private void BuildStructPacsQualityControl()
        {
            frmDockForm tsl = new frmDockForm();
            tsl.DockHandler.GetPersistStringCallback = null;
            tsl.DockHandler.PersistString = "科室资料";
            tsl.Name = "科室资料";
            tsl.Tag = "QualityControl_PACS_Information";
            tsl.Text = "科室资料";
            tsl.p = this.p_Sub;
            DockForm df = new DockForm();
            df.frmDock = tsl;
            df.isShow = false;
            this.frmDockList.Add(df);
            frmDockForm ts2 = new frmDockForm();
            ts2.DockHandler.GetPersistStringCallback = null;
            ts2.DockHandler.PersistString = "质控统计";
            ts2.Name = "质控统计";
            ts2.Tag = "QualityControl_PACS_Total";
            ts2.Text = "质控统计";
            ts2.p = this.p_Sub;
            df = new DockForm();
            df.frmDock = ts2;
            df.isShow = false;
            this.frmDockList.Add(df);
            frmDockForm ts3 = new frmDockForm();
            ts3.DockHandler.GetPersistStringCallback = null;
            ts3.DockHandler.PersistString = "质控管理文档";
            ts3.Name = "质控管理文档";
            ts3.Tag = "QualityControl_PACS_Office";
            ts3.Text = "质控管理文档";
            ts3.p = this.p_Sub;
            df = new DockForm();
            df.frmDock = ts3;
            df.isShow = false;
            this.frmDockList.Add(df);
        }

        /// <summary>
        /// 隐藏窗体
        /// </summary>
        public void SetFormHidden()
        {
            for (int j = 0; j < frmMainForm.myMainForm.p_Sub.Controls.Count; j++)//显示窗体前影藏所有窗体
            {
                if ((Control)frmMainForm.myMainForm.p_Sub.Controls[j] is Form)
                    ((Form)(Control)frmMainForm.myMainForm.p_Sub.Controls[j]).Visible = false;
            }
        }

        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="FormName"></param>
        /// <param name="FormPlace"></param>
        /// <returns></returns>
        public Form SetFormDisplay(string FormName, string FormPlace)
        {
            for (int K = 0; K < frmMainForm.myMainForm.p_Sub.Controls.Count; K++)
            {
                if (((Control)frmMainForm.myMainForm.p_Sub.Controls[K]).Text.ToString() == FormName)
                {
                    FormFun = (Form)(Control)frmMainForm.myMainForm.p_Sub.Controls[K];
                    FormFun.Visible = true;
                    return FormFun;
                }
            }
            try
            {
                FormFun = CreateForm(FormName, FormPlace);
                FormFun.BringToFront();
                FormFun.Show();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
                return null;
            }
            return FormFun;
        }

        /// <summary>
        /// 创建加载窗体
        /// </summary>
        /// <param name="FormName"></param>
        /// <param name="FormPlace"></param>
        /// <returns></returns>
        private Form CreateForm(string FormName, string FormPlace)
        {
            Type ty = Type.GetType(FormPlace);
            Form FormFun = (Form)Activator.CreateInstance(ty);    //否则创建 
            FormFun.TopLevel = false;
            FormFun.FormBorderStyle = FormBorderStyle.None;
            FormFun.Text = FormName;
            frmMainForm.myMainForm.p_Sub.Controls.Add(FormFun);
            FormFun.Dock = DockStyle.Fill;
            return FormFun;
        }

        /// <summary>
        /// 单击主界面的退出按钮，退出界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 单击注销按钮，切换用户登录，重新打开登录界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Logout_Click(object sender, EventArgs e)
        {
            this.isLogout = true;

            Application.Restart();
        }

        #region 自动锁定屏幕
        private void timer_Main_Tick(object sender, EventArgs e)
        {
            this.tssl_Time.Text = DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString();
            if (GetConfig.LS_AutoLock)
            {
                if (this.isAutoLock)
                {
                    this.timer_Lock.Interval = GetConfig.LS_LockMinute * 60000;
                    this.timer_Lock.Enabled = true;
                    this.timer_Lock.Tick += new EventHandler(timer_Lock_Tick);
                    this.isAutoLock = false;
                    this.LockBegin = true;
                }
            }
            else
            {
                this.timer_Lock.Enabled = false;
            }
        }

        private void timer_Lock_Tick(object sender, EventArgs e)
        {
            if (this.LockBegin)
                this.Lock();
        }
        private void Lock()
        {
            if (this.lo == null)
                this.lo = new frmLogin(iUser);
            else
                this.lo.initData(iUser);
            if (!this.lo.Visible)
                this.timer_Lock.Enabled = false;
            if (this.lo.ShowDialog() == DialogResult.Cancel)
            {
                this.isLogout = true;
                this.Close();
            }
            else
            {
                this.timer_Lock.Enabled = true;
                this.LockBegin = false;
            }
            this.isAutoLock = lo.isAutoLock;
        }

        private void btn_Lock_Click(object sender, EventArgs e)
        {
            this.Lock();
        }
        #endregion

        /// <summary>
        /// 主界面激活事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMainForm_Activated(object sender, EventArgs e)
        {
            frmMainForm.GatherOrRpt = 0;//0代表？；1代表？；
        }

        /// <summary>
        /// 单击设置，模式加载打开设置界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Settings_Click(object sender, EventArgs e)
        {
            frmSettings frmSet = new frmSettings();
            frmSet.ShowDialog();
        }
    }
}