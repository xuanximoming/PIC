using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using SIS_BLL;
using ILL;
using SIS_Function;
using BaseControls.PictureBoxs;
using SIS.Query;
using System.Threading;
using BaseControls;
using SIS.Function;

namespace SIS
{
    public partial class frmQuickQuery : Form
    {
        private BWorkList Bworklist = new BWorkList();
        private BImage Bimage = new BImage();
        private BReport bReport=new BReport();
        private BQueueInfo bQInfo = new BQueueInfo();
        private BPrintTemplateDict bPrint = new BPrintTemplateDict();
        private IModel iWorkList,iUser,iQinfo,iReport;
        private SIS_Model.MImage Mimage;
        private delegate void LoadBackImags();
        //public delegate void DbClick(clsFImgBackPic cls);
        private ImageCopy imgCopy;
        private List<ImgObj> arrayImage = new List<ImgObj>();
        public frmReportEdit frm = null;
        private frmImgQuickView queryView;
        private string ExamDept="";
        private int ReportStat = 0;//报告状态标识，列表选择改变时更新
        private SIS.RegisterCls.BindData bindData;
        private bool isInit = true;
        private string CurrentDir;//保存当前报告路径
        private string CacheDir;//临时缓存路径（单击列表时保存）
        private DataChange dc;
        private List<DataChange.DataBlock> lDB_ChargeType;
        private List<DataChange.DataBlock> lDB_PatientSource;

        public frmQuickQuery()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            iWorkList = DALFactory.Model.CreateMWorkList();
            this.iUser = frmMainForm.iUser;
            CurrentDir = Application.StartupPath + "\\temp";
            CacheDir = Application.StartupPath + "\\ReportCache";
            Mimage = new SIS_Model.MImage();
            dc = new DataChange();
            this.BindDataToCtl();
            this.NewDataChange();
            if (GetConfig.DALAndModel == "SIS")
            {

                SIS_Model.MUser smUser = (SIS_Model.MUser)this.iUser;
                ExamDept = smUser.CLINIC_OFFICE_CODE;
                if (GetConfig.SystemType.ToUpper() == "REGISTER")
                {
                    SetRegisterType();
                }
                else
                {
                    imgCopy = new ImageCopy();
                }
            }
            else
            {
                PACS_Model.MUser pmUser = (PACS_Model.MUser)this.iUser;
                ExamDept = pmUser.USER_DEPT;
                SetRegisterType();
            }
            this.dtp_From.Value = System.DateTime.Now.AddDays(GetConfig.DD_DefaultExamListDays);
            
        }
        private void SetRegisterType()
        {
            this.p_Buttom.Visible = false;
            this.tsb_BackImg.Visible = false;
            this.tsb_CallNext.Visible = false;
            this.tsb_OpenRpt.Visible = false;
            this.tsb_QueueInf.Visible = false;
            this.tss4.Visible = false;
            this.tss5.Visible = false;
            this.tss6.Visible = false;
            this.tss7.Visible = false;
            this.tsmi_Unlock.Visible = false;

            this.tsb_View.Visible = false;   //Add at 2010-08-19  由于浏览按钮在放射科登记中，没用途，暂时不显示

        }
        #region 绑定数据

        private void BindDataToCtl()
        {
            this.isInit = true;
            this.bindData = new SIS.RegisterCls.BindData();
            this.bindData.BindChargeType(this.cmb_ChargeType);
            this.bindData.BindExamClass(this.cmb_ExamClass, GetConfig.RM_RegisterMode);
            this.bindData.BindPatientSource(this.cmb_PatientSource);
            this.bindData.BindReferDept(this.cmb_ReferDept);
            this.bindData.BindExamGroup(this.cmb_ExamGroup);
            if (GetConfig.QueryGroup)
                CtlComboBox.SetDisplay(GetConfig.Group, this.cmb_ExamGroup);
            this.cmb_ChargeType.SelectedIndex = -1;
            this.cmb_ExamClass.SelectedIndex = -1;
            this.cmb_PatientSource.SelectedValue = -1;
            this.cmb_ReferDept.SelectedIndex = -1;
            this.isInit = false;
        }

        private void NewDataChange()
        {
            DataTable dt_ChargeType = (DataTable)this.cmb_ChargeType.DataSource;
            lDB_ChargeType = new List<DataChange.DataBlock>();
            List<DataChange.DataBlock> ChargeTypeSet = dc.GetDataColor(GetConfig.LCC_ChargeType);
            for (int i = 0; i < dt_ChargeType.Rows.Count; i++)
            {
                DataChange.DataBlock db = new DataChange.DataBlock();
                db.Code = dt_ChargeType.Rows[i][this.cmb_ChargeType.ValueMember].ToString();
                db.Name = dt_ChargeType.Rows[i][this.cmb_ChargeType.DisplayMember].ToString();
                for (int j = 0; j < ChargeTypeSet.Count; j++)
                {
                    if (db.Name == ChargeTypeSet[j].Name)
                        db.Color = ChargeTypeSet[j].Color;
                }
                lDB_ChargeType.Add(db);
            }
            DataTable dt_PatientSource = (DataTable)this.cmb_PatientSource.DataSource;
            lDB_PatientSource = new List<DataChange.DataBlock>();
            List<DataChange.DataBlock> PatientSourceSet = dc.GetDataColor(GetConfig.LCC_PatientSource);
            for (int i = 0; i < dt_PatientSource.Rows.Count; i++)
            {
                DataChange.DataBlock db = new DataChange.DataBlock();
                db.Code = dt_PatientSource.Rows[i][this.cmb_PatientSource.ValueMember].ToString();
                db.Name = dt_PatientSource.Rows[i][this.cmb_PatientSource.DisplayMember].ToString();
                for (int j = 0; j < PatientSourceSet.Count; j++)
                {
                    if (db.Name == PatientSourceSet[j].Name)
                        db.Color = PatientSourceSet[j].Color;
                }
                lDB_PatientSource.Add(db);
            }
        }

        private void cmb_ExamClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            this.bindData.BindExamSubClass(this.cmb_ExamClass.Text, this.cmb_ExamSubClass);
            this.cmb_ExamSubClass.SelectedIndex = -1;
        }

        private void cmb_ExamSubClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            this.bindData.BindExamItems(this.cmb_ExamClass.Text, this.cmb_ExamSubClass.Text, this.cmb_ExamItem);
            this.cmb_ExamItem.SelectedIndex = -1;
        }

        private void cmb_ReferDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            string referDept = this.cmb_ReferDept.SelectedValue == null ? "" : this.cmb_ReferDept.SelectedValue.ToString();
            this.bindData.BindReferDoctor(referDept, this.cmb_ReferDoctor);
            this.cmb_ReferDoctor.SelectedIndex = -1;
            //this.cmb_ReferDoctor.MaxDropDownItems = this.cmb_ReferDoctor.Items.Count;
        }
        #endregion

        #region 图像

        /// <summary>
        /// 显示图片
        /// </summary>
        /// <param name="array">图片Array</param>
        private void DisplayImages()
        {
            this.p_Control.Controls.Clear();
            for (int i = this.arrayImage.Count;i>0; i--)
            {
                ImgObj imgObj = (ImgObj)this.arrayImage[i-1];
                this.AddImageCtl(imgObj);
            }
        }

        private void AddImageCtl(ImgObj imgObj)
        {
            userCtrPictureEx ctl = new userCtrPictureEx();
            ctl.Picture.SetCheckBoxReadOnly(true);
            ctl.Picture.SetDoubleClick(false);
            ctl.Picture.SetCheckBoxVisible(true);

            ctl.Picture.SetCheck(imgObj.IsCheck);
            ctl.Picture.MouseDown += new MouseEventHandler(Picture_MouseDown);
            ctl.Picture.MouseUp += new MouseEventHandler(Picture_MouseUp);
            if (imgObj.MarkImgPath == "")
                ctl.Picture.LoadFile(imgObj.ImagePath);
            else
            {
                ctl.Picture.LoadFile(imgObj.MarkImgPath);
                ctl.Picture.IsMark = true;
            }
            ctl.Picture.ImgObj = imgObj;
            ctl.Name = ctl.Picture.Name;
            ctl.LabelBorderStyle = userCtrPictureEx.LBorderStyle.All;
            ctl.LabelBorder = 3;
            this.p_Control.Controls.Add(ctl);
            ctl.Dock = DockStyle.Left;

        }

        private void Picture_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (queryView != null)
                    queryView.Hide();
            }
        }

        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (queryView == null)
                        queryView = new frmImgQuickView();
                    queryView.BackgroundImage = (Image)((userCtrPicture)sender).Image.Clone();
                    queryView.Show();
                }
            }
            catch
            {
            }
        }

        private ImgObj SavetoServer(string LocalPath)
        {
            FileOperator ope = new FileOperator();
            string newFileName = ope.GetNewFileName(CacheDir, frmMainForm.examInf.ExamAccessionNum, ".jpg");
            //CacheDir += "\\" + newFileName;
            ImgObj obj = this.AddImgObj(newFileName, LocalPath);
            if (obj != null)
                arrayImage.Add(obj);
            return obj;
        }

        private ImgObj AddImgObj(string newFileName,string path)
        {
            SIS_Model.MImage Mimage = new SIS_Model.MImage();
            Mimage.EXAM_ACCESSION_NUM = frmMainForm.examInf.ExamAccessionNum;
            Mimage.IMAGE_PATH = GetConfig.ServerImgDir + "/" + frmMainForm.examInf.ReqDateTime + "/" + frmMainForm.examInf.ExamAccessionNum + "/" + newFileName;//linux上文件保存路径
            ImageCopy imgCopy = new ImageCopy();
            if(imgCopy.FileUpLoad(Mimage, path,false)!=1)
                return null;
            //上传成功,复制到ReportCache文件夹中2010-01-07修改.
            string newFilePath = CacheDir + "\\" + newFileName;//上传后另存一份到REPORTCACHE中的文件路径
            File.Copy(path, newFilePath, true);
            
            //if (ILL.GetConfig.IsConnectPax)
            //{
            //    SendRptToPax SendToPax = new SendRptToPax((SIS_Model.MWorkList)iWorkList, (SIS_Model.MReport)iReport, path.TrimEnd(';'));//与PACS接口，
            //}
            ImgObj imgObj = new ImgObj(newFilePath, false, Mimage);
            return imgObj;
        }

        /// <summary>
        /// 加载后台采集的图片
        /// </summary>
        private void loadBackImages()
        {
            if (!System.IO.Directory.Exists(GetConfig.Dynamic))
                System.IO.Directory.CreateDirectory(GetConfig.Dynamic);
            string[] imgs=new FileOperator().GetFiles(GetConfig.Dynamic,"*.jpg");
            //imgs = System.IO.Directory.GetFiles(GetConfig.Dynamic, "*.jpg");
            this.p_PicControl.Controls.Clear();
            List<Control> ctls = new List<Control>();
            for (int i = 0; i < imgs.Length; i++)
            {
                if (!imgs[i].ToString().Contains("Mark"))
                {
                    userCtrPictureEx ctl = new userCtrPictureEx();
                    ctl.Picture.SetCheckBoxVisible(false);
                    ctl.LabelBorderStyle = userCtrPictureEx.LBorderStyle.All;
                    ctl.Picture.SetDoubleClick(false);
                    ctl.Visible = true;
                    ctl.Picture.MouseDown += new MouseEventHandler(Picture_MouseDown);
                    ctl.Picture.MouseUp += new MouseEventHandler(Picture_MouseUp);
                    ctl.Picture.MouseDoubleClick += new MouseEventHandler(Picture_MouseDoubleClick);
                    string fileName = imgs[i].ToString().Substring(imgs[i].LastIndexOf("\\") + 1);
                    if (ExitesMark(fileName))
                    {
                        ctl.Picture.LoadFile(GetConfig.Dynamic + "\\Mark" + fileName);
                        ctl.Picture.IsMark = true;
                    }
                    else
                    {
                        ctl.Picture.LoadFile(imgs[i].ToString());
                        ctl.Picture.IsMark = false;
                    }
                    ctl.Name = ctl.Picture.FileName;
                    ctl.l_Buttom.Text = ctl.Name;
                    ctl.Dock = DockStyle.Left;
                    ctls.Add(ctl);
                }
            }
            this.p_PicControl.Controls.AddRange(ctls.ToArray());
            this.lb_ImgCount.Text = string.Format("共{0}张后台图像", this.p_PicControl.Controls.Count);
        }

        private bool ExitesMark(string name)
        {
            string[] names = System.IO.Directory.GetFiles(GetConfig.Dynamic, "Mark" + name);
            if (names.Length > 0)
                return true;
            else
                return false;
        }

        
        // 委托 图像双击事件|说明：分三种状态：a.预约、b.已检查-上传图片到服务器并保存至本地TEPM中并显示出来；c.编辑-不做任何操作
        private void Picture_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (GetConfig.DALAndModel == "SIS" && dgv_ExamList.Rows.Count > 0 && dgv_ExamList.SelectedRows.Count > 0)
            {
                userCtrPicture ctl = (userCtrPicture)sender;
                SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.iWorkList;
                if (smWorkList.REPORT_STATUS == 0 || smWorkList.REPORT_STATUS == 1)
                {
                    ImgObj obj = SavetoServer(ctl.FilePath);
                    if (obj != null)
                        this.AddImageCtl(obj);
                }
                else
                    MessageBoxEx.Show("该检查正在编辑报告，不能操作！", "警告");
            }
        }

        private void tsb_BackImg_Click(object sender, EventArgs e)
        {
            this.splitter_Pic.Visible = !this.splitter_Pic.Visible;
            this.p_PicControl1.Visible = !this.p_PicControl1.Visible;
            if (this.p_PicControl.Visible)
            {
                LoadBackImags load = new LoadBackImags(loadBackImages);
                this.Invoke(load);
            }
        }


        private void tsmi_Del_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBoxEx.Show("是否删除所选图像？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
            {
                ArrayList arrayDel = new ArrayList();
                if (this.p_PicControl.Controls.Count > 0)
                {
                    //bool isDelete = false;
                    for (int i = 0; i < this.p_PicControl.Controls.Count; i++)
                    {
                        Control con = this.p_PicControl.Controls[i];

                        
                        userCtrPictureEx axf = (userCtrPictureEx)con;
                        if (axf.Picture.IsSelecting)
                        {
                            arrayDel.Add(axf);
                            //System.IO.File.Delete(axf.Picture.FilePath);
                            //this.p_PicControl.Controls.Remove(axf);
                            //isDelete = true;
                            //this.p_PicControl.Controls.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < arrayDel.Count; i++)
                    {
                        userCtrPictureEx axf = (userCtrPictureEx)arrayDel[i];
                        System.IO.File.Delete(axf.Picture.FilePath);
                        this.p_PicControl.Controls.Remove(axf);
                    }
                    //if (isDelete)
                    //    this.loadBackImages();
                }
                this.lb_ImgCount.Text = string.Format("共{0}张后台图像", this.p_PicControl.Controls.Count);
            }
        }

        private void tsmi_DelAll_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBoxEx.Show("是否删除所有后台图像？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
            {
                if (this.p_PicControl.Controls.Count > 0)
                    if (System.IO.Directory.Exists(GetConfig.Dynamic))
                    {
                        System.IO.Directory.Delete(GetConfig.Dynamic, true);
                        Directory.CreateDirectory(GetConfig.Dynamic);
                        this.p_PicControl.Controls.Clear();
                    }
                this.lb_ImgCount.Text = string.Format("共{0}张后台图像", this.p_PicControl.Controls.Count);
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.p_PicControl.Visible)
            {
                switch (keyData)
                {
                    case Keys.Delete:
                        this.tsmi_Del_Click(null, null);
                        break;
                }
            }
            return base.ProcessDialogKey(keyData);
        }


        private void Explorer(Panel p)
        {
            List<string> filePaths = new List<string>();
            for (int i = 0; i < p.Controls.Count; i++)
            {
                userCtrPictureEx ctl = (userCtrPictureEx)p.Controls[i];
                filePaths.Add(ctl.Picture.FilePath);
            }
            ImageViewer iViewer = new ImageViewer();
            iViewer.init(filePaths.ToArray());
            iViewer.ShowDialog();
        }

        private void tsb_View_ButtonClick(object sender, EventArgs e)
        {
            if (this.p_Control.Controls.Count > 0)
                Explorer(this.p_Control);
        }

        private void tsmi_ViewBackImgs_Click(object sender, EventArgs e)
        {
            if (this.p_PicControl.Controls.Count > 0)
                Explorer(this.p_PicControl);
        }

        #endregion

        #region 排队叫号

        private void LockWorklist(string exam_accession_num)
        {
            for (int i = 0; i < this.dgv_ExamList.Rows.Count; i++)
            {
                if (this.dgv_ExamList.Rows[i].Cells["EXAM_ACCESSION_NUM"].Value.ToString() == exam_accession_num)
                {
                    this.dgv_ExamList.Rows[i].Selected = true;
                    return;
                }
            }
        }

        public  void QueueInfoBind()
        {
            string where = "";
            switch (GetConfig.SisOdbcMode)
            {
                case "ACCESS":
                    where = " QUEUE_NAME='" + GetConfig.Group + "'  and Diag_flag=0 and REG_DATE >= date() order by ORDER_NO,REG_DATE";
                    break;
                case "ORACLE":
                    where = " QUEUE_NAME='" + GetConfig.Group + "'  and Diag_flag=0 and REG_DATE>=trunc(sysdate) and REG_DATE<trunc(sysdate+1) order by ORDER_NO,REG_DATE";
                    break;
                case "SQL":
                    break;
            }
            dgv_QueueInfo.DataSource = bQInfo.GetList(where);
        }

        // 呼叫
        private bool CallThePatient()
        {
           // this.dgv_QueueInfo.Rows[0].Selected = true;
            //this.iQinfo = bQInfo.GetModel(this.dgv_QueueInfo.Rows[0].Cells["EXAM_ACCESSION_NUM"].Value.ToString());
            CallPatient call = new CallPatient();//呼叫
            if (call.Send(this.iQinfo) == -1)
            {
                MessageBoxEx.Show("排队叫号系统出现错误，可能由于网络不通引起，请与系统管理员联系！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
           // DelInfo(this.iQinfo);
            if (GetConfig.DALAndModel == "SIS")
            {
                //SIS_Model.MQueueInfo smQinfo = (SIS_Model.MQueueInfo)this.iQinfo;
                //smQinfo.DIAG_FLAG = 1;
                //bQInfo.Update(smQinfo, " where EXAM_ACCESSION_NUM='" + smQinfo.EXAM_ACCESSION_NUM + "'");
            }
            else
            {
                //PACS_Model.MQueueInfo pmQinfo = (PACS_Model.MQueueInfo)this.iQinfo;
                //pmQinfo.DIAG_FLAG = 1;
                //bQInfo.Update(pmQinfo, " where EXAM_ACCESSION_NUM='" + pmQinfo.EXAM_ACCESSION_NUM + "'");
            }
            return true;
        }

        //标识排队为已就诊并刷新列表
        private void DelInfo(IModel iModel)
        {
            if (GetConfig.DALAndModel == "SIS")
            {
                SIS_Model.MQueueInfo smQinfo = (SIS_Model.MQueueInfo)iModel;
                smQinfo.DIAG_FLAG = 1;
                bQInfo.Update(smQinfo, " where EXAM_ACCESSION_NUM='" + smQinfo.EXAM_ACCESSION_NUM + "'");
            }
            else
            {
                PACS_Model.MQueueInfo pmQinfo = (PACS_Model.MQueueInfo)iModel;
                pmQinfo.DIAG_FLAG = 1;
                bQInfo.Update(pmQinfo, " where EXAM_ACCESSION_NUM='" + pmQinfo.EXAM_ACCESSION_NUM + "'");
            }
            QueueInfoBind();
        }
        private void tsb_QueueInf_Click(object sender, EventArgs e)
        {
            this.gb_QueueInfo.Visible = !this.gb_QueueInfo.Visible;
            if (this.gb_QueueInfo.Visible)
            {
                this.tsb_QueueInf.Text = "隐藏排队信息";
                QueueInfoBind();
            }
            else
                this.tsb_QueueInf.Text = "显示排队信息";
        }

        private void tsb_CallNext_Click(object sender, EventArgs e)
        {
            QueueInfoBind();
            if (this.dgv_QueueInfo.Rows.Count > 0)
            {
                this.dgv_QueueInfo.Rows[0].Selected = true;
                ExecCall();
            }
            
        }

        private void ExecCall()
        {
            if (this.dgv_QueueInfo.SelectedRows.Count > 0)
            {
                this.iQinfo = bQInfo.GetModel(this.dgv_QueueInfo.SelectedRows[0].Cells["EXAM_ACCESSION_NUM"].Value.ToString());
                if (CallThePatient())
                {
                    string ExamAccessionNum = "";
                    if (GetConfig.DALAndModel == "SIS")
                    {
                        SIS_Model.MQueueInfo smQinfo = (SIS_Model.MQueueInfo)this.iQinfo;
                        ExamAccessionNum = smQinfo.EXAM_ACCESSION_NUM;
                    }
                    else
                    {
                        PACS_Model.MQueueInfo pmQinfo = (PACS_Model.MQueueInfo)this.iQinfo;
                        ExamAccessionNum = pmQinfo.EXAM_ACCESSION_NUM;
                    }

                    QueryWorklist(ExamAccessionNum);
                    LockWorklist(ExamAccessionNum);
                    dgv_ExamList_Click(null, null);
                }
            }
            else
                MessageBoxEx.Show("已无候诊病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        private void frmQuickQuery_Load(object sender, EventArgs e)
        {
            clsIme.SetIme(this);//设置全部控件输入时为半角
            initForm();
        }

        //初始化窗体
        private void initForm()
        {
            this.cmb_DateType.SelectedIndex = 0;
            this.dgv_ExamList.XmlFile = Application.StartupPath + "\\ExamColumn.xml";
            this.dgv_ExamList.AddViewColumns();
            this.dgv_ExamList.AutoGenerateColumns = false;
            QueryWorklist();
            QueueInfoBind();
        }
        /// <summary>
        /// 检索WORKLIST条件为：本科室--EXAM_DEPT字段
        /// </summary>
        public void QueryWorklist()
        {
            string where = " 1=1 and EXAM_DEPT=" + this.ExamDept;
            if (txt_PatientID.Text != "")
                where += " and patient_id='" + txt_PatientID.Text.Trim() + "'";
            if (txt_Name.Text != "")
                where += " and patient_name like '%" + txt_Name.Text.Trim() + "%'";
            if (txt_PatientLocalId.Text != "")
                where += " and patient_local_id='" + txt_PatientLocalId.Text.Trim() + "'";  //worklist中的检查号
            if (txt_InpNo.Text != "")
                where += " and inp_no='" + txt_InpNo.Text.Trim() + "'";
            if (cmb_ChargeType.SelectedValue != null)
                where += " and CHARGE_TYPE = " + cmb_ChargeType.SelectedValue.ToString();
            if (cmb_Confirmed.Text != "")
                where += " and IS_CONFIRMED =" + (cmb_Confirmed.SelectedIndex + 1).ToString();
            if (cmb_ExamClass.Text != "")
                where += " and EXAM_CLASS ='" + cmb_ExamClass.Text.Trim() + "'";
            if (cmb_ExamItem.Text != "")
                where += " and EXAM_ITEMS like '%" + cmb_ExamItem.Text + "%'";
            if (cmb_ExamSubClass.Text != "")
                where += " and EXAM_SUB_CLASS = '" + cmb_ExamSubClass.Text + "'";
            if (cmb_PatientSource.SelectedValue != null)
                where += " and PATIENT_SOURCE = '" + cmb_PatientSource.SelectedValue + "'";
            if (cmb_ReferDept.Text != "")
                where += " and REQ_DEPT_NAME = '" + cmb_ReferDept.Text + "'";
            if (cmb_ReferDoctor.Text != "")
                where += " and REFER_DOCTOR ='" + cmb_ReferDoctor.Text + "'";
            if (cmb_ExamGroup.Text != "")
                where += " and EXAM_GROUP ='" + cmb_ExamGroup.Text + "'";
            if(cmb_ReportType.Text!="")
                where += " and REPORT_TYPE = " + (cmb_ReportType.SelectedIndex + 1).ToString();
            if (this.dtp_From.Checked || this.dtp_To.Checked)
            {
                string DateFrom = "", DateTo = "";
                if (this.dtp_From.Checked)
                    DateFrom = this.dtp_From.Text;
                else
                    DateFrom = this.dtp_From.MinDate.ToShortDateString();
                if (this.dtp_To.Checked)
                    DateTo = this.dtp_To.Value.AddDays(1).ToShortDateString();
                else
                    DateTo = System.DateTime.Now.AddMonths(1).ToShortDateString();
                where += DateTimeSql(DateFrom, DateTo);
            }
            if (tx_DiagImpression.Text != "")
            {
                where += " and IMPRESSION like '%" + tx_DiagImpression.Text + "%'";
            }

            //add at 2010-08-31 增加随访标志,和阴阳性查询条件
            if (this.cmb_isInquiry.Text != "")
            {
                switch (cmb_isInquiry.Text.Trim())
                {
                    case "未标志":
                        where += " and IS_INQUIRY = 0"; break;
                    case "已标志":
                        where += " and IS_INQUIRY = 1"; break;
                    default :
                        this.cmb_isInquiry.Text = ""; break;
                }
            }
            if (this.cmb_isAbnormal.Text != "")
            {
                switch (cmb_isAbnormal.Text.Trim())
                {
                    case "阴性":
                        where += " and IS_ABNORMAL = 0"; break;
                    case "阳性":
                        where += " and IS_ABNORMAL = 1"; break;
                    default :
                        this.cmb_isAbnormal.Text = ""; break;

                }
            }

            //Add at 2010-09-13 增加报告状态,打印状态和检查申请序号
            if (this.cmb_ReportStatus.Text != "")
            {
                switch (cmb_ReportStatus.Text.Trim())
                {
                    case "未写":
                        where += " and REPORT_STATUS = 0"; break;
                    case "已写":
                        where += " and REPORT_STATUS = 1"; break;
                    case "正在写":
                        where += " and REPORT_STATUS = 2"; break;
                    default :
                        this.cmb_ReportStatus.Text = ""; break;
                }
                    
            }
            if (this.cmb_IsPrinted.Text != "")
            {
                switch (cmb_IsPrinted.Text.Trim())
                {
                    case "未打印":
                        where += " and PRINT_COUNT is null"; break;
                    case "已打印":
                        where += " and PRINT_COUNT = 1"; break;
                    default :
                        this.cmb_IsPrinted.Text = ""; break;
                }
            }
            if (this.txt_ExamAccessionNum.Text != "")
            {
                where += " and EXAM_ACCESSION_NUM = '" + this.txt_ExamAccessionNum.Text.Trim().ToUpper() + "'";
            }
            
            where += " order by REQ_DATE_TIME DESC";
            DataTable dt = Bworklist.GetWorkListReport(where);
            dgv_ExamList.DataSource = dt;
            if (dt.Rows.Count > 0)
                dgv_ExamList.Rows[0].Selected = false;
            this.l_Count.Text = "共 " + dgv_ExamList.Rows.Count + " 条记录";
            this.p_Control.Controls.Clear();
            this.txt_Impression.Text = "";
            this.txt_Description.Text = "";
        }
        /// <summary>
        /// 排队模式时用的查询WL
        /// </summary>
        /// <param name="EXAM_ACCESSION_NUM"></param>
        private void QueryWorklist(string EXAM_ACCESSION_NUM)
        {
            string where = "";
            switch (GetConfig.SisOdbcMode)
            {
                case "ACCESS":
                    where = " 1=1 and REQ_DATE_TIME between date() and date()+1 and EXAM_DEPT=" + this.ExamDept + " ";
                    break;
                case "ORACLE":
                    where = " EXAM_GROUP='"+GetConfig.Group+"' and REQ_DATE_TIME>=trunc(sysdate) and REQ_DATE_TIME<trunc(sysdate+1) and EXAM_DEPT=" + this.ExamDept + " ";
                   
                   // where = " QUEUE_NAME='" + GetConfig.Group + "'  and Diag_flag=0 and REG_DATE>=trunc(sysdate) order by ORDER_NO,REG_DATE";
                    break;
                case "SQL":
                    break;
            }
            where += " order by REQ_DATE_TIME DESC";
            dgv_ExamList.DataSource = Bworklist.GetWorkListReport(where);
            //LockWorklist(EXAM_ACCESSION_NUM);
        }

        //构造时间查询语句
        private string DateTimeSql(string DateFrom,string DateTo)
        {
            string sql = "";
            switch (GetConfig.SisOdbcMode)     
            {
                case "ACCESS":
                    switch (cmb_DateType.SelectedIndex)
                    {
                        case 0:
                            sql += " and REQ_DATE_TIME between #" + DateFrom + "# and #" + DateTo + "#";
                            break;
                        case 1:
                            sql += " and STUDY_DATE_TIME between #" + DateFrom + "# and #" + DateTo + "#";
                            break;
                        case 2:
                            sql += " and REPORT_DATE_TIME between #" + DateFrom + "# and #" + DateTo + "#";
                            break;
                        case 3:
                            sql += " and SCHEDULED_DATE between #" + DateFrom + "# and #" + DateTo + "#";
                            break;
                        default:
                            break;
                    }
                    break;
                case "ORACLE":
                    switch (cmb_DateType.SelectedIndex)
                    {
                        case 0:
                            sql += " and REQ_DATE_TIME >= to_date('" + DateFrom + "','yyyy-mm-dd HH24:MI:SS') and REQ_DATE_TIME <= to_date('" + DateTo + "','yyyy-mm-dd HH24:MI:SS')";
                            break;
                        case 1:
                            sql += " and STUDY_DATE_TIME >= to_date('" + DateFrom + "','yyyy-mm-dd HH24:MI:SS') and REQ_DATE_TIME <= to_date('" + DateTo + "','yyyy-mm-dd HH24:MI:SS')";
                            break;
                        case 2:
                            sql += " and REPORT_DATE_TIME >= to_date('" + DateFrom + "','yyyy-mm-dd HH24:MI:SS') and REQ_DATE_TIME <= to_date('" + DateTo + "','yyyy-mm-dd HH24:MI:SS')";
                            break;
                        case 3:
                            sql += " and SCHEDULED_DATE >= to_date('" + DateFrom + "','yyyy-mm-dd HH24:MI:SS') and REQ_DATE_TIME <= to_date('" + DateTo + "','yyyy-mm-dd HH24:MI:SS')";
                            break;
                        default:
                            break;
                    }
                    break;
            }
            return sql;
        }

        

        private void dgv_ExamList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.SetIdeaCellValue(e);
        }
        private void SetIdeaCellValue(DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == this.dgv_ExamList.Columns["REPORT_STATUS"].Index)
                e = dc.ChangeReportStatus(e);
            if (e.ColumnIndex == this.dgv_ExamList.Columns["IS_CONFIRMED"].Index)
                e = dc.ChangeIsConfirmed(e);
            if (e.ColumnIndex == this.dgv_ExamList.Columns["MATCH_STATUS"].Index)
                e = dc.ChangeMatchStatus(e);
            if (e.ColumnIndex == this.dgv_ExamList.Columns["IS_TEMPORARY"].Index)
                e = dc.ChangeIsTemporary(e);
            if (e.ColumnIndex == this.dgv_ExamList.Columns["PATIENT_SOURCE"].Index)
                e = dc.ChangeData(e, lDB_PatientSource);
            if (e.ColumnIndex == this.dgv_ExamList.Columns["CHARGE_TYPE"].Index)
                e = dc.ChangeData(e, lDB_ChargeType);
            if (e.ColumnIndex == this.dgv_ExamList.Columns["IS_INQUIRY"].Index)
                e = dc.ChangeIsInQuiry(e);
            if (e.ColumnIndex == this.dgv_ExamList.Columns["PRINT_COUNT"].Index)
                e = dc.ChangeIsPrinted(e);
            if (e.ColumnIndex == this.dgv_ExamList.Columns["IS_ONLINE"].Index)
                e = dc.ChangeIsOnline(e);
            if (e.ColumnIndex == this.dgv_ExamList.Columns["IS_PACKPROCESS"].Index)
                e = dc.ChangeIsPackprocess(e);
            if (e.ColumnIndex == this.dgv_ExamList.Columns["REPORT_TYPE"].Index)
                e = dc.ChangeReportType(e);
            if (e.ColumnIndex == this.dgv_ExamList.Columns["EXAM_ACCESSION_NUM"].Index)
            {

            }
        }

        

        /// <summary>
        /// WORKLIST列表单击事件
        /// </summary>
        private void dgv_ExamList_Click(object sender, EventArgs e)
        {
            if (GetConfig.SystemType.ToUpper() == "REGISTER")
                return;
            if (GetConfig.DALAndModel == "SIS"&& dgv_ExamList.SelectedRows.Count>0 )
            {
                
                string ExamAccessionNum = dgv_ExamList.SelectedRows[0].Cells["EXAM_ACCESSION_NUM"].Value.ToString().Trim();
               // if(frmMainForm.examInf.ExamAccessionNum==ExamAccessionNum)
                //    return ;
                //ReportStat = GetReportStat(ExamAccessionNum);
                //string temppath = Application.StartupPath + "\\temp";
                if (Directory.Exists(CacheDir))
                    Directory.Delete(CacheDir, true);
                Directory.CreateDirectory(CacheDir);
                this.GetWorkLisReport(ExamAccessionNum);
                arrayImage = imgCopy.LoadImages((SIS_Model.MWorkList)this.iWorkList,CacheDir);
                //this.iReport = imgCopy.ReportDownLoad(this.iWorkList, CacheDir);
                DisplayImages();
                frmMainForm.examInf = new ExamInf((SIS_Model.MWorkList)this.iWorkList, arrayImage);
                frmMainForm.myMainForm.initExamInfText();
                frmMainForm.myMainForm.iGather.preferImages.LoadImages();
                this.txt_Description.Text = "检查所见：" + Environment.NewLine + dgv_ExamList.SelectedRows[0].Cells["DESCRIPTION"].Value.ToString();
                this.txt_Impression.Text = "诊断意见：" + Environment.NewLine + dgv_ExamList.SelectedRows[0].Cells["IMPRESSION"].Value.ToString();
            }
        }

        public void GetWorkLisReport(string ExamAccessionNum)
        {
            this.iWorkList = Bworklist.GetModel(ExamAccessionNum);
            this.iReport = imgCopy.ReportDownLoad(this.iWorkList, CacheDir);
        }

        private int GetReportStat()
        {
            int ReportStat = -1;
            if (GetConfig.DALAndModel == "SIS")
            {
                SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.iWorkList;
                ReportStat = Convert.ToInt32(smWorkList.REPORT_STATUS);
            }
            else
            {
                PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.iWorkList;
                ReportStat = Convert.ToInt32(pmWorkList.REPORT_STATUS);
            }
            return ReportStat;
        }

        private void dgv_ExamList_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgv_ExamList.SelectedRows.Count > 0)
            {
                if (GetConfig.DALAndModel == "SIS" && GetConfig.SystemType.ToUpper()!="REGISTER")
                {
                   // GetConfig.RS_TempExamClass = this.dgv_ExamList.SelectedRows[0].Cells["EXAM_CLASS"].Value.ToString();
                        OpenReport(GetConfig.RS_OpenWord);
                    //Thread thread = new Thread(new ThreadStart(OpenReport));
                    //thread.IsBackground = true;
                    //thread.Start();
                }
                else
                {
                    this.EditWorkList();
                }
            }
        }

        public void OpenReport(IModel iWorkList)
        {
            if (Directory.Exists(CacheDir))
                Directory.Delete(CacheDir, true);
            Directory.CreateDirectory(CacheDir);
            this.iWorkList = iWorkList;
            this.iReport = imgCopy.ReportDownLoad(this.iWorkList, CacheDir);
            arrayImage = imgCopy.LoadImages((SIS_Model.MWorkList)this.iWorkList, CacheDir);
            //this.iReport = imgCopy.ReportDownLoad(this.iWorkList, CacheDir);
            DisplayImages();
            frmMainForm.examInf = new ExamInf((SIS_Model.MWorkList)this.iWorkList, arrayImage);
            frmMainForm.myMainForm.initExamInfText();
            frmMainForm.myMainForm.iGather.preferImages.LoadImages();
            if (frm == null)
                frm = new frmReportEdit(this);
            SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.iWorkList;
            frm.initForm(smWorkList, (SIS_Model.MReport)this.iReport,GetConfig.RS_OpenWord);
        }

        public void OpenReport(bool isShowWord)
        {
            if (frm == null)
                frm = new frmReportEdit(this);
            SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.iWorkList;
            frm.initForm(smWorkList, (SIS_Model.MReport)this.iReport,isShowWord);
        }

        private void tsmi_ChangeList_Click(object sender, EventArgs e)
        {
            frmSetDataView sdv=new frmSetDataView (this.dgv_ExamList.GetViewColumns(),this.dgv_ExamList.XmlFile);
            sdv.ShowDialog();
        }
        private void tsmi_DelWorklist_Click(object sender, EventArgs e)
        {
            tsb_Del_Click(null, null);
        }
        private void EditWorkList()
        {
            string ExamAccessionNum = dgv_ExamList.SelectedRows[0].Cells["EXAM_ACCESSION_NUM"].Value.ToString().Trim();
            this.iWorkList = Bworklist.GetModel(ExamAccessionNum);
            if (GetConfig.RM_CheckReportStatus)
            {
               // string ExamAccessionNum = dgv_ExamList.SelectedRows[0].Cells["EXAM_ACCESSION_NUM"].Value.ToString().Trim();
                //this.iWorkList = Bworklist.GetModel(ExamAccessionNum);
                if (this.GetReportStat() == 0)
                    this.Edit_All();
                else
                    MessageBoxEx.Show("该检查记录正在写或已写报告,不能编辑该检查记录信息!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                this.Edit_All();
        }

        private void Edit_All()
        {
            int Confirmed = -1;
            if (GetConfig.DALAndModel == "SIS")
            {
                SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.iWorkList;
                Confirmed = Convert.ToInt32(smWorkList.IS_CONFIRMED);
            }
            else
            {
                PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.iWorkList;
                Confirmed = Convert.ToInt32(pmWorkList.IS_CONFIRMED);
            }
            switch (Confirmed)
            {
                case 0:
                    if (this.dgv_ExamList.CurrentRow.Cells["PATIENT_SOURCE"].Value.ToString() == "病房")
                        this.ShowRegMode5(false,true);
                    else
                        this.ShowRegMode5(false,false);
                    break;
                case 1:
                    if (this.dgv_ExamList.CurrentRow.Cells["PATIENT_SOURCE"].Value.ToString() == "病房")
                        this.ShowRegMode5(true,true);
                    else
                        this.ShowRegMode5(true,false);
                    break;
                case 2:
                    MessageBoxEx.Show("该检查记录已退费,不能编辑该检查记录信息!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        /// <summary>
        /// 以模式5初始化登记界面
        /// </summary>
        /// <param name="isTrue"></param>
        public void ShowRegMode5(bool isConfirmed,bool isSickRoom)
        {
            frmMainForm.myMainForm.SetFormHidden();//显示窗体前影藏所有窗体
            frmRegister reg = (frmRegister)frmMainForm.myMainForm.SetFormDisplay("检查登记", "SIS.frmRegister");
            reg.newReg.NewExam();
            reg.initReg.initMode5(this.iWorkList, isConfirmed, isSickRoom);
        }

        #region 回车检索区

        private void txt_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                QueryWorklist();
        }

        private void txt_PatientID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                QueryWorklist();
        }

        private void txt_PatientLocalId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                QueryWorklist();
        }

        private void cmb_ExamClass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                QueryWorklist();
        }

        private void cmb_ExamSubClass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                QueryWorklist();
        }

        private void cmb_ExamItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                QueryWorklist();
        }

        private void txt_InpNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                QueryWorklist();
        }

        private void cmb_ReferDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                QueryWorklist();
        }

        private void cmb_PatientSource_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                QueryWorklist();
        }

        private void cmb_ChargeType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                QueryWorklist();
        }

        private void cmb_Confirmed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                QueryWorklist();
        }

        private void cmb_ReportType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                QueryWorklist();
        }

        private void cmb_ReferDoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                QueryWorklist();
        }

        private void dtp_From_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                QueryWorklist();
        }

        private void dtp_To_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                QueryWorklist();
        }
        //add at 2010-08-31
        private void cmb_isInquiry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                QueryWorklist();
        }

        private void cmb_isAbnormal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                QueryWorklist();
        }

        private void tx_DiagImpression_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                QueryWorklist();
        }

        private void txt_ExamAccessionNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                QueryWorklist();
        }
        #endregion

        private void tsb_Find_Click(object sender, EventArgs e)
        {
            QueryWorklist();
        }

        private void tsb_Clear_Click(object sender, EventArgs e)
        {
            this.isInit = true;
            this.txt_ExamAccessionNum.Text = "";
            this.txt_InpNo.Text = "";
            this.txt_Name.Text = "";
            this.txt_PatientID.Text = "";
            this.txt_PatientLocalId.Text = "";
            this.tx_DiagImpression.Text = "";
            this.cmb_ChargeType.SelectedIndex = -1;
            this.cmb_Confirmed.SelectedIndex = -1;
            this.cmb_DateType.SelectedIndex = 0;
            this.cmb_ExamClass.SelectedIndex = -1;
            this.cmb_ExamSubClass.DataSource = null;
            this.cmb_PatientSource.SelectedValue = -1;
            this.cmb_ReferDept.SelectedIndex = -1;
            this.cmb_ReferDoctor.DataSource = null;
            this.cmb_ExamItem.DataSource = null;
            this.cmb_ReportType.SelectedIndex = -1;
            this.isInit = false;

            this.cmb_isInquiry.SelectedIndex = -1;    //add at 2010-08-31  清空时，也将随访标志选择清空
            this.cmb_isAbnormal.SelectedIndex = -1;   //add at 2010-08-31  清空时，也将阴阳性选择清空
            this.txt_ExamAccessionNum.Focus();        //Add at 2010-09-13
            this.cmb_ExamGroup.SelectedIndex = -1;
            this.cmb_ReportStatus.SelectedIndex = -1;
            this.cmb_IsPrinted.SelectedIndex = -1;    //Add at 2010-09-13
            this.txt_ExamAccessionNum.Focus();
        }

        private void tsb_Edit_Click(object sender, EventArgs e)
        {
            if (this.dgv_ExamList.SelectedRows.Count == 0)
            {
                MessageBoxEx.Show("未选中检查记录!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.EditWorkList();
        }

        private void tsb_OpenRpt_Click(object sender, EventArgs e)
        {
            if (this.dgv_ExamList.SelectedRows.Count == 0)
            {
                MessageBoxEx.Show("未选中检查记录!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenReport(GetConfig.RS_OpenWord);
        }


        private void tsb_Del_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgv_ExamList.SelectedRows.Count == 0)
                {
                    MessageBoxEx.Show("未选中检查记录!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (MessageBoxEx.Show("确定删除此检查记录？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        string ExamAccessionNum = dgv_ExamList.SelectedRows[0].Cells["EXAM_ACCESSION_NUM"].Value.ToString().Trim();
                        this.iWorkList = Bworklist.GetModel(ExamAccessionNum);
                        if (this.GetReportStat() == 0)
                            DeleteWorklist(ExamAccessionNum);
                        else
                        {
                            string RptDoctorId = dgv_ExamList.SelectedRows[0].Cells["REPORT_DOCTOR"].Value.ToString().Trim();
                            if (RptDoctorId != "")
                            {
                                BUser buser = new BUser();
                                //modify by liukun at 2010-7-8 begin 
                                //修改记录：放射科在删除已写报告时，会报错并导致程序崩溃，经查是此处的类型不对，当登录科室为放射科时，mu的类型应为PACS_Model.MUser
                                //SIS_Model.MUser mu = (SIS_Model.MUser)buser.GetModel(RptDoctorId);
                                IModel mu = buser.GetModel(RptDoctorId);
                                //modify by liukun at 2010-7-8 end 
                                frmLogin frmlog = new frmLogin(mu, true);
                                if (frmlog.ShowDialog() == DialogResult.OK)
                                {
                                    DeleteWorklist(ExamAccessionNum);
                                    if (GetConfig.IsConnectPax)
                                    {
                                        BStudy bstudy = new BStudy();
                                        bstudy.Delete(" where EXAM_ACCESSION_NUM ='" + ExamAccessionNum + "'");
                                    }

                                }
                                //MessageBoxEx.Show("该检查记录正在写或已写报告,不能删除!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        QueryWorklist();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }

        private void DeleteWorklist(string ExamAccessionNum)
        {
            Bworklist.Delete(" where EXAM_ACCESSION_NUM='" + ExamAccessionNum + "'");
        }

        private void dgv_ExamList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //0未写，1已写，2正在写System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))))
            foreach (DataGridViewRow DGVRow in this.dgv_ExamList.Rows)
            {
                if (DGVRow != null)
                {
                    switch (DGVRow.Cells["REPORT_STATUS"].Value.ToString())
                    {
                        case "0":
                            DGVRow.DefaultCellStyle.BackColor = Color.LightGreen;
                            break;
                        case "1":
                            //DGVRow.DefaultCellStyle.ForeColor = Color.Red;
                            break;
                        case "2":
                            DGVRow.DefaultCellStyle.BackColor = Color.LightGray;
                            break;
                        default:
                            break;
                    }
                    switch (DGVRow.Cells["PRINT_COUNT"].Value.ToString())
                    {
                        case "0":
                            //e.Value = "未打印";
                            DGVRow.Cells["EXAM_ACCESSION_NUM"].Style.ForeColor = System.Drawing.Color.BlueViolet;
                            break;
                        case "":
                            //e.Value = "未打印";
                            DGVRow.Cells["EXAM_ACCESSION_NUM"].Style.ForeColor = System.Drawing.Color.BlueViolet;
                            break;
                        default:
                           // e.Value = "已打印";
                            DGVRow.Cells["EXAM_ACCESSION_NUM"].Style.ForeColor = System.Drawing.Color.DeepSkyBlue;
                            break;
                    }
                }
            }
        }

        private void txt_Name_Enter(object sender, EventArgs e)
        {
            SetImeMode.SetHalfShape(this.txt_Name, true);
        }

        private void txt_PatientID_Enter(object sender, EventArgs e)
        {
            SetImeMode.SetHalfShape(this.txt_PatientID, false);
        }

        private void txt_PatientLocalId_Enter(object sender, EventArgs e)
        {
            SetImeMode.SetHalfShape(this.txt_PatientLocalId, false);
        }

        private void tsmi_Unlock_Click(object sender, EventArgs e)
        {
            if (this.dgv_ExamList.SelectedRows.Count == 0)
            {
                MessageBoxEx.Show("未选中检查记录!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SIS_Model.MWorkList mw = (SIS_Model.MWorkList)this.iWorkList;
            SIS_Model.MReport mr = (SIS_Model.MReport)this.iReport;
            if (mr.EXAM_NO == null || mr.EXAM_NO != "")
                mw.REPORT_STATUS = 1;
            else
                mw.REPORT_STATUS = 0;
            if (Bworklist.Update(mw, " where EXAM_ACCESSION_NUM ='" + mw.EXAM_ACCESSION_NUM + "'") < 0)
                MessageBoxEx.Show("解锁失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                this.dgv_ExamList.SelectedRows[0].Cells["REPORT_STATUS"].Value = mw.REPORT_STATUS;
                this.dgv_ExamList.SelectedRows[0].DefaultCellStyle.BackColor = SystemColors.Window;
            }
        }

        private void tsmi_OpenWordRpt_Click(object sender, EventArgs e)
        {
            if (this.dgv_ExamList.SelectedRows.Count == 0)
            {
                MessageBoxEx.Show("未选中检查记录!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenReport(true);
        }

        private void tsmi_OpenNormalRpt_Click(object sender, EventArgs e)
        {
            if (this.dgv_ExamList.SelectedRows.Count == 0)
            {
                MessageBoxEx.Show("未选中检查记录!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenReport(false);
        }

        private void dgv_ExamList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    this.dgv_ExamList.Rows[e.RowIndex].Selected = true;
                    dgv_ExamList_Click(null, null);
                    if (GetConfig.DALAndModel == "SIS" && dgv_ExamList.SelectedRows.Count > 0)
                    {
                        if (dgv_ExamList.SelectedRows[0].Cells["REPORT_STATUS"].Value.ToString() == "2")
                            this.tsmi_Unlock.Enabled = true;
                        else
                            this.tsmi_Unlock.Enabled = false;
                    }
                }
            }
            catch
            {
                this.dgv_ExamList.Rows[0].Selected = false;
            }
        }
        //刷新后台图像
        private void tsmi_ReflashBackImg_Click(object sender, EventArgs e)
        {
            this.loadBackImages();
        }

        private void tsmi_ExportExcel_Click(object sender, EventArgs e)
        {
            SIS_Function.Excel ex = new Excel();
            ex.ExportTOExcel(this.dgv_ExamList);
        }

        #region 排队表右键菜单
        private void toolStrip_DelInfo_Click(object sender, EventArgs e)
        {
            if (this.dgv_QueueInfo.SelectedRows.Count > 0)
            {
                if (MessageBoxEx.Show("确定删除此检查记录？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    this.iQinfo = bQInfo.GetModel(this.dgv_QueueInfo.SelectedRows[0].Cells["EXAM_ACCESSION_NUM"].Value.ToString());
                    DelInfo(this.iQinfo);
                }
            }
        }
        private void toolStrip_ReflashInfo_Click(object sender, EventArgs e)
        {
            QueueInfoBind();
        }
        #endregion 排队表右键菜单

        private void toolStrip_CallQueueInfo_Click(object sender, EventArgs e)
        {
            ExecCall();
        }
        //右键锁定行
        private void dgv_QueueInfo_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    this.dgv_QueueInfo.Rows[e.RowIndex].Selected = true;
                }
            }
            catch
            {
            }
        }

        private void toolStrip_CallNext_Click(object sender, EventArgs e)
        {
            this.tsb_CallNext_Click(null, null);
        }
    }
}