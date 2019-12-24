using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SIS_BLL;
using SIS_Model;
using BaseControls.PictureBoxs;
using SIS.comm;
using ILL;

namespace SIS
{
    /// <summary>
    /// 停靠窗口
    /// </summary>
    public partial class frmDockForm : BaseControls.Docking.DockContent
    {
        BSystemFun BSysFun = new BSystemFun();
        private int y_Two = 0, y_Three = 0;
        public Panel p;
        public static string QualityControlFlag = "";
        private bool isDockStateChanged = false;
        private bool isDockTop = false;

        public frmDockForm()
        {
            InitializeComponent();
        }

        #region -超声科菜单设置-
        /// <summary>
        /// 获取三级菜单
        /// </summary>
        /// <param name="id">模型ID</param>
        /// <param name="isCreate">是否创建标志</param>
        /// <returns></returns>
        public bool GetThreeModel(int id,bool isCreate)
        {
            bool isHas = false;
            System.Data.DataTable dt_Three = BSysFun.GetList(" MODEL_CLASS='3' and UP_MODEL_ID=" + id + " ORDER BY SORT_FLAG");
            if (dt_Three.Rows.Count > 0)
            {
                isHas = true;
                if (isCreate)
                {
                    for (int i = 0; i < dt_Three.Rows.Count; i++)
                    {
                        NewButton(dt_Three.Rows[i], this.p_Three,ref this.y_Three);
                    }
                }
            }
            return isHas;
        }

        private void NewButton(System.Data.DataRow dr,Panel p,ref int y)
        {
            SIS.comm.DockButton dButton = GetNewButton(dr["MODEL_NAME"].ToString(), dr["MODEL_PLACE"].ToString(), dr["MODEL_ID"].ToString());
            p.Controls.Add(dButton);
        }

        /// <summary>
        /// 超声科类获取二级菜单，获取二级及三级的级联菜单
        /// </summary>
        private void GetTwoModel()
        {
           System.Data.DataTable dt = BSysFun.GetList(" MODEL_CLASS='2' and UP_MODEL_ID=" + this.Name + " ORDER BY SORT_FLAG desc");
            if (dt.Rows.Count > 0)
            {
                bool isHasThree = false, isAllThree = true;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (GetThreeModel(Convert.ToInt16(dt.Rows[i]["MODEL_ID"].ToString()),false))
                    {
                        BaseControls.OutlookBarButton outButton = new BaseControls.OutlookBarButton();
                        outButton.Text = dt.Rows[i]["MODEL_NAME"].ToString();
                        outButton.Tag = Convert.ToInt16(dt.Rows[i]["MODEL_ID"].ToString());
                        outButton.Enabled = true;
                        this.outlookBar.Buttons.Add(outButton);
                        this.outlookBar.Size = new Size(this.outlookBar.Width, this.outlookBar.Height + this.outlookBar.ButtonHeight);
                        isHasThree = true;
                    }
                    else
                    {
                        isAllThree = false;
                        NewButton(dt.Rows[i], this.p_Two,ref this.y_Two);
                    }
                }
                if (isHasThree && isAllThree)
                {
                    this.p_Two.Visible = false;
                    this.p_TwoAndThree.Dock = DockStyle.Fill;
                    this.p_Three.Controls.Clear();
                    this.y_Three = 0;
                    this.outlookBar.SelectedButton = this.outlookBar.Buttons[0];
                    GetThreeModel(Convert.ToInt16(this.outlookBar.SelectedButton.Tag), true);  
                }
                if (!isHasThree)
                    this.p_TwoAndThree.Visible = false;
            }

        }
        #endregion

        /// <summary>
        /// 获取新按钮
        /// </summary>
        /// <param name="ButtonText">按钮显示文本</param>
        /// <param name="Tag">用户定义数据</param>
        /// <param name="Name">按钮名称</param>
        /// <returns></returns>
        private SIS.comm.DockButton GetNewButton(string ButtonText, string Tag, string Name)
        {
            DockButton dButton = new DockButton();
            dButton.vistaButton.ButtonText = ButtonText;
            dButton.vistaButton.Tag = Tag;
            dButton.vistaButton.Name = Name;
            dButton.vistaButton.MouseDown += new MouseEventHandler(vistaButton_MouseDown);
            if (this.isDockTop)
            {
                dButton.Height = 60;
                dButton.Dock = DockStyle.Top;
            }
            else
            {
                dButton.Width = 120;
                dButton.Dock = DockStyle.Left;
            }
            return dButton;
        }

        /// <summary>
        /// AddPACS的功能按钮
        /// </summary>
        private void AddButtonPacs()
        {
            string[] Name = new string[] { "报表统计", "排队分诊", "检查登记", "检查记录" };
            string[] Place = new string[] { "SIS.frmStat", "SIS.frmSubArea", "SIS.frmRegister", "SIS.frmQuickQuery" };
            for (int i = 0; i < Name.Length; i++)
            {
                DockButton db = GetNewButton(Name[i], Place[i], Name[i]);
                this.p_Two.Controls.Add(db);
            }
            this.p_TwoAndThree.Visible = false;
        }

        /// <summary>
        /// 加载科室管理按钮
        /// </summary>
        private void AddButtonPacsDeptManage()
        {
            string[] Name = new string[] { "类别对照", "检查类别", "用户管理" };
            string[] Place = new string[] {  "SIS.DeptManage.frmUserExamClass", "SIS.DeptManage.frmExamClass" ,"SIS.DeptManage.frmFpaxUsers"};
            for (int i = 0; i < Name.Length; i++)
            {
                 DockButton dButton =  GetNewButton(Name[i], Place[i], Name[i]);
                this.p_Two.Controls.Add(dButton);
            }
            this.p_TwoAndThree.Visible = false;
        }

        #region -质控菜单设置-
        /// <summary>
        /// 质量管理系统二级导航加载
        /// </summary>
        private void GetTwo_QualityControl()
        {
            this.p_Two.Visible = false;
            this.p_TwoAndThree.Dock = DockStyle.Fill;
            switch (this.Tag.ToString())
            {
                case "QualityControl_PACS_Information":  //科室资料
                    BaseControls.OutlookBarButton outButton = new BaseControls.OutlookBarButton();
                    outButton.Text = "操作常规";
                    outButton.Tag = "DeptInformation1";
                    outButton.Enabled = true;
                    this.outlookBar.Buttons.Add(outButton);
                    this.outlookBar.Size = new Size(this.outlookBar.Width, this.outlookBar.Height + this.outlookBar.ButtonHeight);
                    GetThree_QualityControl("DeptInformation1");

                    BaseControls.OutlookBarButton outButton1 = new BaseControls.OutlookBarButton();
                    outButton1.Text = "岗位分布";
                    outButton1.Tag = "DeptInformation2";
                    outButton1.Enabled = true;
                    this.outlookBar.Buttons.Add(outButton1);
                    this.outlookBar.Size = new Size(this.outlookBar.Width, this.outlookBar.Height + this.outlookBar.ButtonHeight);

                    BaseControls.OutlookBarButton outButton2 = new BaseControls.OutlookBarButton();
                    outButton2.Text = "岗位职责";
                    outButton2.Tag = "DeptInformation3";
                    outButton2.Enabled = true;
                    this.outlookBar.Buttons.Add(outButton2);
                    this.outlookBar.Size = new Size(this.outlookBar.Width, this.outlookBar.Height + this.outlookBar.ButtonHeight);

                    break;
                case "QualityControl_PACS_Total": //质控统计
                    BaseControls.OutlookBarButton ToutButton = new BaseControls.OutlookBarButton();
                    ToutButton.Text = "普通摄片";
                    ToutButton.Tag = "QualityControlTotal1";
                    ToutButton.Enabled = true;
                    this.outlookBar.Buttons.Add(ToutButton);
                    this.outlookBar.Size = new Size(this.outlookBar.Width, this.outlookBar.Height + this.outlookBar.ButtonHeight);
                    GetThree_QualityControl("QualityControlTotal1");

                    BaseControls.OutlookBarButton ToutButton1 = new BaseControls.OutlookBarButton();
                    ToutButton1.Text = "照影";
                    ToutButton1.Tag = "QualityControlTotal2";
                    ToutButton1.Enabled = true;
                    this.outlookBar.Buttons.Add(ToutButton1);
                    this.outlookBar.Size = new Size(this.outlookBar.Width, this.outlookBar.Height + this.outlookBar.ButtonHeight);

                    BaseControls.OutlookBarButton ToutButton2 = new BaseControls.OutlookBarButton();
                    ToutButton2.Text = "统计管理";
                    ToutButton2.Tag = "QualityControlTotal3";
                    ToutButton2.Enabled = true;
                    this.outlookBar.Buttons.Add(ToutButton2);
                    this.outlookBar.Size = new Size(this.outlookBar.Width, this.outlookBar.Height + this.outlookBar.ButtonHeight);
                    break;
                case "QualityControl_PACS_Office":    //质控管理文档
                    BaseControls.OutlookBarButton HoutButton = new BaseControls.OutlookBarButton();
                    HoutButton.Text = "培训制度";
                    HoutButton.Tag = "QualityControlOffice1";
                    HoutButton.Enabled = true;
                    this.outlookBar.Buttons.Add(HoutButton);
                    this.outlookBar.Size = new Size(this.outlookBar.Width, this.outlookBar.Height + this.outlookBar.ButtonHeight);
                    GetThree_QualityControl("QualityControlOffice1");

                    BaseControls.OutlookBarButton HoutButton1 = new BaseControls.OutlookBarButton();
                    HoutButton1.Text = "规章制度";
                    HoutButton1.Tag = "QualityControlOffice2";
                    HoutButton1.Enabled = true;
                    this.outlookBar.Buttons.Add(HoutButton1);
                    this.outlookBar.Size = new Size(this.outlookBar.Width, this.outlookBar.Height + this.outlookBar.ButtonHeight);

                    BaseControls.OutlookBarButton HoutButton2 = new BaseControls.OutlookBarButton();
                    HoutButton2.Text = "质控标准";
                    HoutButton2.Tag = "QualityControlOffice3";
                    HoutButton2.Enabled = true;
                    this.outlookBar.Buttons.Add(HoutButton2);
                    this.outlookBar.Size = new Size(this.outlookBar.Width, this.outlookBar.Height + this.outlookBar.ButtonHeight);

                    break;
            }
        }

        /// <summary>
        /// 质量管理系统三级导航加载
        /// </summary>
        /// <param name="Flag"></param>
        private void GetThree_QualityControl(string Flag)
        {
            SIS.comm.DockButton dButton;
            switch (Flag)
            {
                case "DeptInformation1":  //科室资料
                    Get_Pacs_Quality_DeptInfor("操作常规", "SIS.QualityControl.DeptInfor");
                    break;
                case "DeptInformation2":
                    Get_Pacs_Quality_DeptInfor("岗位分布", "SIS.QualityControl.DeptInfor");
                    break;
                case "DeptInformation3":
                    Get_Pacs_Quality_DeptInfor("岗位职责", "SIS.QualityControl.DeptInfor");
                    break;
                case "QualityControlTotal1":
                    dButton = GetNewButton("正位胸片统计", "SIS.QualityControl.QualityControlTotal", "");
                    this.p_Three.Controls.Add(dButton);

                    dButton = GetNewButton("膝关节统计", "SIS.QualityControl.QualityControlTotal", "");
                    this.p_Three.Controls.Add(dButton);
                    break;
                case "QualityControlTotal2":
                    dButton = GetNewButton("上消化道统计", "SIS.QualityControl.QualityControlTotal", "");
                    this.p_Three.Controls.Add(dButton);

                    dButton = GetNewButton("静脉肾孟统计", "SIS.QualityControl.QualityControlTotal", "");
                    this.p_Three.Controls.Add(dButton);
                    break;
                case "QualityControlTotal3":
                    dButton = GetNewButton("CT统计", "SIS.QualityControl.QualityControlTotal", "ff1");
                    this.p_Three.Controls.Add(dButton);

                    dButton = GetNewButton("MRI统计", "SIS.QualityControl.QualityControlTotal", "ff");
                    this.p_Three.Controls.Add(dButton);

                    dButton = GetNewButton("放射诊断统计", "SIS.QualityControl.QualityControlTotal", "ff1");
                    this.p_Three.Controls.Add(dButton);

                    dButton = GetNewButton("统计管理", "SIS.QualityControl.QC_ImageManage", "ff");
                    this.p_Three.Controls.Add(dButton);

                    dButton = GetNewButton("科室管理统计", "SIS.QualityControl.QC_DEPT_MAN_DICT", "ff");
                    this.p_Three.Controls.Add(dButton);
                    break;
                case "QualityControlOffice1":
                    Get_Pacs_Quality_DeptInfor("培训制度", "SIS.QualityControl.DeptInfor");
                    break;
                case "QualityControlOffice2":
                    Get_Pacs_Quality_DeptInfor("规章制度", "SIS.QualityControl.DeptInfor");
                    break;
                case "QualityControlOffice3":
                    Get_Pacs_Quality_DeptInfor("质控标准", "SIS.QualityControl.DeptInfor");
                    break;
            }
        }

        /// <summary>
        /// 获取Pacs质控科室信息
        /// </summary>
        /// <param name="where"></param>
        /// <param name="ClassName"></param>
        public void Get_Pacs_Quality_DeptInfor(string where, string ClassName)
        {
            BDeptDataDict bDeptDtDic = new BDeptDataDict();
            DataTable dt = bDeptDtDic.GetList(" DATA_TYPE='" + where + "'");
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow DR = dt.Rows[i];
                    SIS.comm.DockButton dButton = GetNewButton(DR["DATA_NAME"].ToString(), ClassName, "");
                    this.p_Three.Controls.Add(dButton);
                }
            }
        }
        #endregion

        /// <summary>
        /// vista按钮鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vistaButton_MouseDown(object sender, MouseEventArgs e)
        {
            BaseControls.Buttons.VistaButton bt = (BaseControls.Buttons.VistaButton)sender;
            if (bt.Tag.ToString().Contains("frmReportEdit"))
            {
                if (frmMainForm.examInf.ExamAccessionNum == "")
                {
                    MessageBoxEx.Show("请先选择检查记录！", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                frmMainForm.myMainForm.qQuery.GetWorkLisReport(frmMainForm.examInf.ExamAccessionNum);
                frmMainForm.myMainForm.qQuery.OpenReport(ILL.GetConfig.RS_OpenWord);
                if (!frmMainForm.myMainForm.qQuery.Visible)
                {
                    frmMainForm.myMainForm.SetFormHidden();//显示窗体前影藏所有窗体
                    frmMainForm.myMainForm.SetFormDisplay("快速查询", "SIS.frmQuickQuery");
                }
                return;
            }
            if(this.outlookBar.SelectedButton!=null)
                QualityControlFlag = this.Name + ";" + this.outlookBar.SelectedButton.Text + ";" + bt.ButtonText; ;
            frmMainForm.myMainForm.SetFormHidden();//显示窗体前影藏所有窗体
            frmMainForm.myMainForm.SetFormDisplay(bt.ButtonText, bt.Tag.ToString());
        }

        /// <summary>
        /// 加载可停靠窗口，根据配置信息生成功能按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DockForm_Load(object sender, EventArgs e)
        {
            if (ILL.GetConfig.DALAndModel == "SIS")
            {
                if (GetConfig.SystemType.ToUpper() == "REGISTER")
                {
                    AddButtonPacs();
                }
                else
                {
                    GetTwoModel();
                }
            }
            else
            {
                switch (ILL.GetConfig.SystemType)
                {
                    case "DeptManage":
                        AddButtonPacsDeptManage();
                        break;
                    case "Register":
                        AddButtonPacs();
                        break;
                    case "QualityControl":
                        GetTwo_QualityControl();
                        break;
                }

            }
        }

        /// <summary>
        /// outlookBar单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void outlookBar_Click(object sender, BaseControls.OutlookBar.ButtonClickEventArgs e)
        {
            this.p_Three.Controls.Clear();
            this.y_Three = 0;
            string s = this.Tag.ToString().Substring(0, 20);
            if (s == "QualityControl_PACS_")
                GetThree_QualityControl(e.SelectedButton.Tag.ToString());
            else
                GetThreeModel(Convert.ToInt16(e.SelectedButton.Tag), true);
        }

        /// <summary>
        /// 停靠窗口状态改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DockForm_DockStateChanged(object sender, EventArgs e)
        {
            p.BringToFront();
            this.isDockStateChanged = true;
        }

        /// <summary>
        /// 窗口大小改变事件，设置收缩时的图片和停靠设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDockForm_SizeChanged(object sender, EventArgs e)
        {
            switch (this.DockState)
            {
                case BaseControls.Docking.DockState.DockBottom:
                    this.isDockTop = false;
                    SetImages();
                    break;
                case BaseControls.Docking.DockState.DockBottomAutoHide:
                    this.isDockTop = false;
                    SetImages();
                    break;
                case BaseControls.Docking.DockState.DockLeft:
                    this.isDockTop = true;
                    SetImages();
                    break;
                case BaseControls.Docking.DockState.DockLeftAutoHide:
                    this.isDockTop = true;
                    SetImages();
                    break;
                case BaseControls.Docking.DockState.DockRight:
                    this.isDockTop = true;
                    SetImages();
                    break;
                case BaseControls.Docking.DockState.DockRightAutoHide:
                    this.isDockTop = true;
                    SetImages();
                    break;
                case BaseControls.Docking.DockState.DockTop:
                    this.isDockTop = false;
                    SetImages();
                    break;
                case BaseControls.Docking.DockState.DockTopAutoHide:
                    this.isDockTop = false;
                    SetImages();
                    break;
                case BaseControls.Docking.DockState.Float:
                    this.isDockTop = true;
                    SetImages();
                    break;
            }
        }

        /// <summary>
        /// 设置图片
        /// </summary>
        private void SetImages()
        {
            bool isSetDock = false;
            try
            {
                if (isDockTop)
                {
                    for (int i = 0; i < this.p_Two.Controls.Count; i++)
                    {
                        DockButton ctl = (DockButton)this.p_Two.Controls[i];
                        if (isDockStateChanged)
                        {
                            ctl.Height = 60;
                            ctl.Dock = DockStyle.Top;
                            isSetDock = true;
                        }
                    }
                    for (int i = 0; i < this.p_Three.Controls.Count; i++)
                    {
                        DockButton ctl = (DockButton)this.p_Three.Controls[i];
                        if (isDockStateChanged)
                        {
                            ctl.Height = 60;
                            ctl.Dock = DockStyle.Top;
                            isSetDock = true;
                        }
                    }
                    this.outlookBar.Height = 120;
                    this.outlookBar.Dock = DockStyle.Bottom ;
                }
                else
                {
                    for (int i = 0; i < this.p_Two.Controls.Count; i++)
                    {
                        DockButton ctl = (DockButton)this.p_Two.Controls[i];
                        if (isDockStateChanged)
                        {
                            ctl.Width = 120;
                            ctl.Dock = DockStyle.Left;
                            isSetDock = true;
                        }
                    }
                    for (int i = 0; i < this.p_Three.Controls.Count; i++)
                    {
                        DockButton ctl = (DockButton)this.p_Three.Controls[i];
                        if (isDockStateChanged)
                        {
                            ctl.Width = 120;
                            ctl.Dock = DockStyle.Left;
                            isSetDock = true;
                        }
                    }
                    this.outlookBar.Width = 120;
                    this.outlookBar.Dock = DockStyle.Right;
                }
            }
            catch { }
            if (isSetDock)
                this.isDockStateChanged = false;
        }

    }
}