using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ILL;
using SIS_DAL;
using SIS_BLL;
using SIS_Model;
using SIS_Function;

using PACS_Model;
using System.Collections;
using SIS.Function;
using SIS.RegisterCls;
using System.Runtime.InteropServices;
using System.IO;
using System.Data.OracleClient;

namespace SIS
{
    public partial class frmRegister : Form
    {
        public string Mode = "-1"; //登记模式: 00:门诊登记; 01:门诊检查申请; 10:住院登记; 11:住院检查申请; 4:绿色通道登记; 5:编辑模式 6:初始化状态; 7:录入状态  
        //private bool success7 = true;                                        //申请单保存成功与否标志
        public bool isAdd = false;                                             //是否正在添加检查登记信息
        public bool isChange = false;                                          //是否已改变检查登记信息
        public bool isUpload = true;                                          //是否上传申请单成功
        public bool IsNew = false;                                             //Patient_ID是否是自动生成标志
        public bool IsCreated = false;                                           //是否已创建该病人信息

        private bool isBlfy = false;     //Add at 2010-08-27   标志是否需填入补录费用

        public System.Data.DataTable dt_AREA = new System.Data.DataTable();
        public System.Data.DataTable dt_ExamItems = new System.Data.DataTable();
        public System.Data.DataTable dt_ReferDept = new System.Data.DataTable();

        public string[] Exam_Class = GetConfig.RM_DefaultExamClass.Split(',');
        public string[] Exam_Sub_Class = GetConfig.RM_DefaultExamSubClass.Split(',');

        public IModel iUser, iArchives, iWorkList, iPatientInfLocalId;
        public SaveReg saveReg;
        public InitReg initReg;
        public NewReg newReg;
        public SetData setData;
        public BindData bindData;
        public RegCls_Pacs regPacs;
        public RegCls_UPE regUPE;
        public RegCls_JW regJW;
        public RegCls_HT regHT;
        public LocalIdCreater localIdCreater;
        public ComputeCharge computeCharge;
        public ReqScanImage reqScanImage;

        private OracleCommand oraCmd;
        private System.Data.DataTable DT_EXAM = new DataTable();

        public frmRegister()
        {
            InitializeComponent();
        }
        private void frmRegister_Load(object sender, EventArgs e)
        {
            clsIme.SetIme(this);//设置所有控件输入法为半角
            this.iUser = frmMainForm.iUser;
            this.initReg = new InitReg(this);
            this.newReg = new NewReg(this);
            this.setData = new SetData();
            this.bindData = new BindData();
            this.regHT = new RegCls_HT();
            this.regJW = new RegCls_JW();
            this.regPacs = new RegCls_Pacs();
            this.regUPE = new RegCls_UPE();
            this.localIdCreater = new LocalIdCreater();
            this.computeCharge = new ComputeCharge();
            this.computeCharge.Init();
            this.reqScanImage = new ReqScanImage(ref this.ptb_ReqImage, this.p_AllView, this.p_Camera, ref this.isUpload);
            this.bindData.BindRegDatas(this);
            this.newReg.NewExam();
            this.reqScanImage.Start();
            if (GetConfig.SystemType.ToUpper() == "REGISTER" || GetConfig.DALAndModel == "PACS")
                this.btn_OpenRpt.Visible = false;
            this.SetDisable(false);
            this.saveReg = new SaveReg(this);
            Init_OrderExamClass();  //初始化预约检查类别及注意事项
            this.groupBox_OrderNotice.Enabled = false;
            this.txt_blfy.Enabled = false;   //add at 2010-08-27  只有在选中预约时间，才给予可填
            Init_Yuyueshijianduan();
        }

        //保存按钮
        private void btn_Save_Click(object sender, EventArgs e)
        {
            //回写申请单状态，即为3或4
            if (this.dtp_ScheduledDate.Checked == false)
            {
                // add by liukun at 2010-6-30 begin 
                if (this.dtp_ScheduledDate.Checked == true)     //选中时，表示进行预约
                {
                    this.setData.SetWorkListData("SCHEDULED_DATE", this.dtp_ScheduledDate.Value, this.iWorkList);
                }
                else  //不选中时，表示不进行预约，设置预约时间为空(null)
                {
                    this.setData.SetWorkListData("SCHEDULED_DATE", null, this.iWorkList);
                }
                // add by liukun at 2010-6-30 end 

                if (this.Mode != "7")
                    if (this.Save(false) && frmMainForm.myMainForm.qQuery != null)
                    {
                        if (GetConfig.QueryGroup)
                            CtlComboBox.SetDisplay(GetConfig.Group, frmMainForm.myMainForm.qQuery.cmb_ExamGroup);
                        System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(frmMainForm.myMainForm.qQuery.QueryWorklist));
                        thread.IsBackground = true;
                        thread.Start();
                        //frmMainForm.myMainForm.qQuery.QueryWorklist();
                        //调用预约时间回写过程，将预约时间回写到HIS系统．将PACS
                        //SaveYuyueshijianToHIS("", "3");
                        UpdateApplyStatus("4");
                    }
            }
            else
            {
                //调用预约时间回写过程，将预约时间回写到HIS系统，惠通HIS接口存储过程将自动将该申请单的状态转为3，即改为已预约申请单
                //保存前先判断预约时间段是否已选择
                if (comboBox_yyqzsjd.Text.ToString().Trim() == "")
                {
                    MessageBox.Show("请录入预约时间段后再点保存");
                    return;
                }
                SaveYuyueshijianToHIS();
                //Edit at 2010-08-27 修改提示显示信息
                if (isBlfy)
                {
                    this.lb_Notice.Text = "预约补录费用";
                    this.isBlfy = false;
                }
                else

                    this.lb_Notice.Text = "保存成功！";
            }
        }
        /// <summary>
        /// 保存登记信息
        /// </summary>
        /// <param name="AddMore">是否点击新增,是由新增按钮触发,否由保存按键触发</param>
        /// <returns></returns>
        public bool Save(bool AddMore)
        {
            Validity check = new Validity();            
            if (check.CheckValidity(this))
            {
                this.saveReg = new SaveReg(this);
                SetWorklistValues();     //补充未保存的Worklist项
                if (this.saveReg.Save())
                {
                    if (this.saveReg.SaveReqScanImages())
                    {
                        if (this.Mode == "5")
                        {
                            this.lb_Notice.Text = "修改成功！";
                            this.isChange = false;
                        }
                        else
                        {
                            this.lb_Notice.Text = "登记成功！";
                            this.btn_Save.Enabled = false;
                            this.isAdd = false;
                            if (GetConfig.RM_SavedOpenRpt && !AddMore && GetConfig.SystemType.ToUpper() != "REGISTER")
                                frmMainForm.myMainForm.qQuery.OpenReport(this.iWorkList);
                        }
                    }
                    else
                    {
                        if (this.Mode == "5")
                        {
                            this.lb_Notice.Text = "修改成功！申请单上传失败~~~";
                            this.isChange = false;
                        }
                        else
                        {
                            this.lb_Notice.Text = "登记成功！申请单上传失败~~~";
                            this.btn_Save.Enabled = false;
                            this.isAdd = false;
                            if (GetConfig.RM_SavedOpenRpt && !AddMore)
                                frmMainForm.myMainForm.qQuery.OpenReport(this.iWorkList);
                        }
                    }

                    //add at 2010-08-24 对于新增时，选择保存时，同时回写申请单状态到HIS系统，为登记状态
                    if (this.Mode != "7")
                        if (AddMore && frmMainForm.myMainForm.qQuery != null)
                        {
                            if (GetConfig.QueryGroup)
                                CtlComboBox.SetDisplay(GetConfig.Group, frmMainForm.myMainForm.qQuery.cmb_ExamGroup);
                            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(frmMainForm.myMainForm.qQuery.QueryWorklist));
                            thread.IsBackground = true;
                            thread.Start();

                            UpdateApplyStatus("4");
                        }
                    //end at 2010-08-24

                    this.btn_OpenRpt.Enabled = true;
                    return true;
                }
                else
                {
                    if (this.Mode == "5")
                        this.lb_Notice.Text = "修改失败！";
                    else
                        this.lb_Notice.Text = "登记失败！";
                    return false;
                }
            }
            return false;
        }

        //补充未保存的WORKLIST项
        private void SetWorklistValues()
        {
            this.setData.SetWorkListData("DEVICE", this.cmb_ImgEquipment.Text, this.iWorkList);
            this.setData.SetWorkListData("CHARGES", this.txt_Charges.Text, this.iWorkList);
            this.setData.SetWorkListData("BED_NUM", this.txt_BedNum.Text, this.iWorkList);
            this.setData.SetWorkListData("COSTS", this.txt_Costs.Text, this.iWorkList);
            this.setData.SetWorkListData("REFER_DOCTOR", this.cmb_ReferDoctor.Text, this.iWorkList);
            this.setData.SetWorkListData("EXAM_DOCTOR", this.cmb_ExamDoctor.Text, this.iWorkList);
            this.setData.SetWorkListData("OPD_NO", this.txt_OpdNo.Text, this.iWorkList);//门诊号
            //this.setData.SetWorkListData("EXAM_DOCTOR", this.cmb_ExamDoctor.Text, this.iWorkList);//病人来源
            this.setData.SetWorkListData("EXAM_ITEMS", GetExamItems(), this.iWorkList);
            this.setData.SetWorkListData("REQ_DEPT_NAME", this.cmb_ReferDept.Text, this.iWorkList);//申请科室
        }
        //检查类别下拉触发
        private void cmb_ExamClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6" || this.cmb_ExamClass.Text == "")
                return;
            this.dt_ExamItems = null;
            this.cmb_ExamItems.DataSource = null;
            this.lv_ExamItem.Items.Clear();
            this.cmb_ExamItems.Text = "";
            this.txt_Charges.Text = "0";
            this.txt_Costs.Text = "0";
            this.dud_PatientLocalId.Text = "";
            this.bindData.BindExamSubClass(this.cmb_ExamClass.Text, this.cmb_ExamSubClass);
            this.setData.SetWorkListData("EXAM_CLASS", this.cmb_ExamClass.Text, this.iWorkList);
            this.setData.SetWorkListData("EXAM_SUB_CLASS", "", this.iWorkList);

            this.setData.SetWorkListData("EXAM_ITEMS", "", this.iWorkList);

            if (this.cmb_ExamSubClass.Items.Count == 1)
            {
                this.cmb_ExamSubClass.SelectedIndex = 0;
                this.ExamSubClassSelectoionCommitted();
            }
            else
                this.cmb_ExamSubClass.SelectedIndex = -1;
            for (int i = 0; i < this.Exam_Class.Length; i++)
            {
                if (this.cmb_ExamClass.Text == this.Exam_Class[i])
                {
                    CtlComboBox.SetDisplay(this.Exam_Sub_Class[i], this.cmb_ExamSubClass);
                    this.ExamSubClassSelectoionCommitted();
                }
            }
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void cmb_ExamSubClass_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.ExamSubClassSelectoionCommitted();
            decimal costs = 0;
            for (int i = 0; i < this.lv_ExamItem.Items.Count; i++)
            {
                costs += Convert.ToDecimal(this.lv_ExamItem.Items[i].SubItems[1].Text);

            }
            this.txt_Costs.Text = costs.ToString();
        }
        /// <summary>
        /// 选择检查子类后的处理方法
        /// </summary>
        public void ExamSubClassSelectoionCommitted()
        {
            if (this.cmb_ExamSubClass.SelectedItem != null)
            {
                //this.lv_ExamItem.Items.Clear();
                if (this.Mode == "6")
                    return;
                string mode = this.Mode;
                this.Mode = "6";
                System.Data.DataRow dr = (this.cmb_ExamSubClass.SelectedItem as System.Data.DataRowView).Row;
                this.cmb_ExamSubClass.Text = dr[this.cmb_ExamSubClass.DisplayMember].ToString().Trim();
                this.dt_ExamItems = this.bindData.BindExamItems(this.cmb_ExamClass.Text, this.cmb_ExamSubClass.Text, this.cmb_ExamItems);
                if (GetConfig.DALAndModel == "PACS")
                    this.regPacs.Bind_ImgEquipment(this.cmb_ExamClass.Text, this.cmb_ExamSubClass.Text, this.cmb_ImgEquipment);
                this.setData.SetWorkListData("EXAM_ITEMS", "", this.iWorkList);
                this.setData.SetWorkListData("COSTS", 0, this.iWorkList);
                this.setData.SetWorkListData("CHARGES", 0, this.iWorkList);
                this.setData.SetWorkListData("EXAM_SUB_CLASS", this.cmb_ExamSubClass.Text, this.iWorkList);
                this.txt_Charges.Text = "0";
                this.txt_Costs.Text = "0";
                this.cmb_ExamItems.Text = "";
                this.Mode = mode;
                if (this.Mode == "7")
                    return;
                if (this.txt_PatientId.Text.Trim() == "")
                    MessageBoxEx.Show("病人ID为空!请输入病人ID.", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    GetLocalId();
                if (this.Mode == "5")
                    this.isChange = true;
            }
        }

        private void GetLocalId()
        {
            this.localIdCreater.ExamClass = this.cmb_ExamClass.Text.ToString().Trim();
            this.localIdCreater.ExamSubClass = this.cmb_ExamSubClass.Text.ToString().Trim();
            this.localIdCreater.PatientId = this.txt_PatientId.Text.ToString().Trim();
            this.localIdCreater.GetPatientLocalID(this.Mode);
            this.iPatientInfLocalId = this.localIdCreater.iPatientInfLocalId;
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.iWorkList;
                    SIS_Model.MPatientInfLocalId smPatientInfLocalId = (SIS_Model.MPatientInfLocalId)this.iPatientInfLocalId;
                    smWorkList.LOCAL_ID_CLASS = smPatientInfLocalId.LOCAL_ID_CLASS;
                    smWorkList.EXAM_INDEX = smPatientInfLocalId.EXAM_TIMES;
                    smWorkList.PATIENT_LOCAL_ID = smPatientInfLocalId.PATIENT_LOCAL_ID;
                    this.dud_PatientLocalId.Text = smWorkList.PATIENT_LOCAL_ID;
                    break;
                case "PACS":
                    PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.iWorkList;
                    PACS_Model.MPatientInfLocalId pmPatientInfLocalId = (PACS_Model.MPatientInfLocalId)this.iPatientInfLocalId;
                    pmWorkList.LOCAL_ID_CLASS = pmPatientInfLocalId.LOCAL_ID_CLASS;
                    pmWorkList.EXAM_INDEX = pmPatientInfLocalId.EXAM_TIMES;
                    pmWorkList.PATIENT_LOCAL_ID = pmPatientInfLocalId.PATIENT_LOCAL_ID;
                    this.dud_PatientLocalId.Text = pmWorkList.PATIENT_LOCAL_ID;
                    break;
            }
        }

        private void cmb_PatientSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            if (this.cmb_PatientSource.Text == "病房" || this.cmb_PatientSource.Text == "住院")
            {
                if (GetConfig.hisVisit)
                {
                    SelInpPat selnpPat = new SelInpPat();
                    if (selnpPat.SearchPatsInHospital("PATIENT_ID ='" + this.txt_PatientId.Text.ToString().Trim() + "'", this.iWorkList))
                        this.initReg.initMode3(this.iWorkList, this.Mode);
                    else
                        MessageBoxEx.Show("查找不到该病人的在院记录，将不能进行划价处理！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    this.lb_Notice.Text = "住院病人登记";
            }
            this.setData.SetWorkListData("PATIENT_SOURCE", this.cmb_PatientSource.SelectedValue == null ? "" : this.cmb_PatientSource.SelectedValue.ToString(), this.iWorkList);
            if (this.Mode == "5")
                this.isChange = true;
        }

        #region 检索区
        private void txt_PatientId_KeyDown(object sender, KeyEventArgs e)
        {
            SearchHisExam_KeyDown(sender, e);
        }

        private void txt_PatientName_KeyDown(object sender, KeyEventArgs e)
        {
            SearchHisExam_KeyDown(sender, e);
        }
        private void txt_InpNo_KeyDown(object sender, KeyEventArgs e)
        {
            SearchHisExam_KeyDown(sender, e);
        }
        /// <summary>
        /// 回车查病人历史信息,公共
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchHisExam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && this.Mode != "5")
            {
                this.SearchHisExam();

                if (txt_InpNo.Text != "" && txt_PatientId.Text !="")            //Edit at 2010-08-17
                    MessageBox.Show("住院病人，如需登记，请确认是否已预约！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (txt_InpNo.Text != "")
            {
                this.cmb_PatientSource.SelectedValue = "2";
            }

            SendTab_KeyDown(sender, e);
        }
        /// <summary>
        /// 回车传{tab}键,公共
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendTab_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{tab}");
        }
        private void txt_BedNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.cmb_ExamClass.Focus();
        }
        private void btn_Find_Click(object sender, EventArgs e)
        {
            this.SearchHisExam();
        }
        /// <summary>
        /// 检索HIS检查信息中是否有该病人信息
        /// </summary>
        private void SearchHisExam()
        {
            if (this.IsCreated)
                return;
            Hashtable ht = new Hashtable();
            if (this.txt_PatientId.Text.ToString().Trim() != "")
                ht.Add("PATIENT_ID", this.txt_PatientId.Text.ToString().Trim());
            if (this.txt_PatientName.Text.ToString().Trim() != "")
                ht.Add("PATIENT_NAME", this.txt_PatientName.Text.ToString().Trim());
            if (this.txt_InpNo.Text.ToString().Trim() != "")
                ht.Add("INP_NO", this.txt_InpNo.Text.ToString().Trim());
            if(this.cmb_PatientSource.SelectedIndex!=-1)
                ht.Add("PATIENT_SOURCE",this.cmb_PatientSource.SelectedValue);
            if (ht.Count >0)
            {
                frmRegSearch regSearch = new frmRegSearch(this.initReg, this.iWorkList, this.iArchives, ht);
                if (regSearch.Search() > 0)
                    //regSearch.Show();
                 regSearch.ShowDialog();
                else
                    if (DialogResult.Yes == MessageBoxEx.Show("无该病人的资料信息,是否创建？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                        this.initReg.initMode4(this.txt_PatientId.Text.Trim());
            }
        }

        private void cmb_ExamItems_TextChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            string mode = this.Mode;
            string text = cmb_ExamItems.Text;
            this.Mode = "6";
            if (CtlComboBox.FindMember("INPUT_CODE like '%" + cmb_ExamItems.Text.ToString().Trim().ToUpper() + "%'", cmb_ExamItems, dt_ExamItems, "SORT_ID"))
            {
                cmb_ExamItems.DroppedDown = true;
                cmb_ExamItems.MaxDropDownItems = cmb_ExamItems.Items.Count;
                cmb_ExamItems.Text = text;
                cmb_ExamItems.SelectionStart = cmb_ExamItems.Text.Length;
            }
            this.Mode = mode;
        }

        private void cmb_ReferDept_TextChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            string mode = this.Mode;
            string text = cmb_ReferDept.Text;
            this.Mode = "6";
            if (CtlComboBox.FindMember("INPUT_CODE like '%" + cmb_ReferDept.Text.ToString().Trim().ToUpper() + "%'", cmb_ReferDept, dt_ReferDept))
            {
                cmb_ReferDept.DroppedDown = true;
                cmb_ReferDept.MaxDropDownItems = cmb_ReferDept.Items.Count;
                cmb_ReferDept.Text = text;
                cmb_ReferDept.SelectionStart = cmb_ReferDept.Text.Length;
            }
            this.Mode = mode;
        }

        private void cmb_BirthPlace_TextChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            string mode = this.Mode;
            string text = cmb_BirthPlace.Text;
            this.Mode = "6";
            if (CtlComboBox.FindMember("INPUT_CODE like '%" + cmb_BirthPlace.Text.ToString().Trim().ToUpper() + "%'", cmb_BirthPlace, dt_AREA))
            {
                cmb_BirthPlace.DroppedDown = true;
                cmb_BirthPlace.Text = text;
                cmb_BirthPlace.SelectionStart = cmb_BirthPlace.Text.Length;
                //cmb_BirthPlace.MaxDropDownItems = cmb_BirthPlace.Items.Count;
            }
            this.Mode = mode;
        }
        #endregion

        #region 对象赋值区
        private void txt_PatientName_TextChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.txt_PatientPhonetic.Text = GetConfig.phone.Convert(txt_PatientName.Text.Trim(), true);
            this.setData.SetWorkListData("PATIENT_NAME", this.txt_PatientName.Text, this.iWorkList);
            this.setData.SetArchivesData("PATIENT_NAME", this.txt_PatientName.Text, this.iArchives);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void txt_PatientPhonetic_TextChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("PATIENT_PHONETIC", this.txt_PatientPhonetic.Text, this.iWorkList);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void cmb_Sex_TextChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("PATIENT_SEX", this.cmb_Sex.Text, this.iWorkList);
            this.setData.SetArchivesData("PATIENT_SEX", this.cmb_Sex.Text, this.iArchives);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void txt_Age_TextChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.iWorkList;
                    SIS_Model.MArchives mArchives = (SIS_Model.MArchives)this.iArchives;
                    if (this.txt_Age.Text.ToString() == "")
                    {
                        this.dtp_Birth.Value = System.DateTime.Now;
                        smWorkList.PATIENT_AGE = null;
                        mArchives.PATIENT_AGE = null;
                    }
                    else
                    {
                        AgeBirth ageBirth = new AgeBirth();
                        this.dtp_Birth.Value = ageBirth.AgeToBirth(this.txt_Age.Text.ToString(), this.cmb_AgeUnit.SelectedIndex, this.dtp_Birth.Value, this.dtp_Birth.MinDate);
                        smWorkList.PATIENT_AGE = Convert.ToInt32(this.txt_Age.Text.ToString());
                        mArchives.PATIENT_AGE = Convert.ToInt32(this.txt_Age.Text.ToString());
                    }
                    break;
                case "PACS":
                    PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.iWorkList;
                    if (this.txt_Age.Text.ToString() == "")
                    {
                        this.dtp_Birth.Value = System.DateTime.Now;
                        pmWorkList.PATIENT_AGE = null;
                    }
                    else
                    {
                        AgeBirth ageBirth = new AgeBirth();
                        this.dtp_Birth.Value = ageBirth.AgeToBirth(this.txt_Age.Text.ToString(), this.cmb_AgeUnit.SelectedIndex, this.dtp_Birth.Value, this.dtp_Birth.MinDate);
                        pmWorkList.PATIENT_AGE = Convert.ToInt32(this.txt_Age.Text.ToString());
                    }
                    break;
            }
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void cmb_AgeUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("PATIENT_AGE_UNIT", this.cmb_AgeUnit.Text, this.iWorkList);
            this.setData.SetArchivesData("PATIENT_AGE_UNIT", this.cmb_AgeUnit.Text, this.iArchives);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void dtp_Birth_ValueChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            if (txt_Age.Focused)
                return;
            if (this.dtp_Birth.Value != System.DateTime.Now)
            {
                AgeBirth ageBirth = new AgeBirth();
                this.txt_Age.Text = ageBirth.BirthToAge(this.cmb_AgeUnit.SelectedIndex, this.dtp_Birth.Value);
            }
            this.setData.SetWorkListData("PATIENT_BIRTH", this.dtp_Birth.Value, this.iWorkList);
            this.setData.SetArchivesData("PATIENT_BIRTH", this.dtp_Birth.Value, this.iArchives);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void txt_PatientId_TextChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("PATIENT_ID", this.txt_PatientId.Text, this.iWorkList);
            this.setData.SetArchivesData("PATIENT_ID", this.txt_PatientId.Text, this.iArchives);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void txt_PatientId_Leave(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            if (this.txt_PatientId.Text != "" && this.cmb_ExamClass.Text != "" && this.cmb_ExamSubClass.Text != "" && this.dud_PatientLocalId.Text == "")
                this.GetLocalId();
        }

        private void cmb_ExamGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("EXAM_GROUP", this.cmb_ExamGroup.Text, this.iWorkList);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void dud_PatientLocalId_TextChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("PATIENT_LOCAL_ID", this.dud_PatientLocalId.Text, this.iWorkList);
            this.setData.SetPatientInfLocalIdData("PATIENT_LOCAL_ID", this.dud_PatientLocalId.Text, this.iPatientInfLocalId);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void dud_PatientLocalId_UpButtonClicked(object sender, EventArgs e)
        {
            this.dud_PatientLocalId.Text = this.localIdCreater.UpPatientLocalId();
        }

        private void dud_PatientLocalId_DownButtonClicked(object sender, EventArgs e)
        {
            this.dud_PatientLocalId.Text = this.localIdCreater.DownPatientLocalId();
        }

        private void cmb_ImgEquipment_TextChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("DEVICE", this.cmb_ImgEquipment.Text, this.iWorkList);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void cmb_ReferDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("REQ_DEPT_NAME", this.cmb_ReferDept.Text, this.iWorkList);
            string referDept = this.cmb_ReferDept.SelectedValue == null ? "" : this.cmb_ReferDept.SelectedValue.ToString();
            this.setData.SetWorkListData("REFER_DEPT", referDept, this.iWorkList);
            this.bindData.BindReferDoctor(referDept, this.cmb_ReferDoctor);
            if (this.cmb_ReferDoctor.Items.Count != 0)
                this.cmb_ReferDoctor.MaxDropDownItems = this.cmb_ReferDoctor.Items.Count;
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void cmb_ReferDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("REFER_DOCTOR", this.cmb_ReferDoctor.Text, this.iWorkList);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void cmb_ChargeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    SIS_Model.MArchives mArchives = (SIS_Model.MArchives)this.iArchives;
                    SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.iWorkList;
                    if (this.cmb_ChargeType.SelectedValue == null)
                    {
                        smWorkList.CHARGE_TYPE = null;
                        mArchives.CHARGE_CLASS = null;
                        this.computeCharge.chargeRatio = 1;
                    }
                    else
                    {
                        smWorkList.CHARGE_TYPE = Convert.ToInt32(this.cmb_ChargeType.SelectedValue.ToString());
                        this.GetRegChargeRatio(smWorkList.CHARGE_TYPE);
                        mArchives.CHARGE_CLASS = Convert.ToInt32(this.cmb_ChargeType.SelectedValue.ToString());
                    }
                    break;
                case "PACS":
                    PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.iWorkList;
                    if (this.cmb_ChargeType.SelectedValue == null)
                    {
                        pmWorkList.CHARGE_TYPE = null;
                        this.computeCharge.chargeRatio = 1;
                    }
                    else
                    {
                        pmWorkList.CHARGE_TYPE = Convert.ToInt32(this.cmb_ChargeType.SelectedValue.ToString());
                        this.GetRegChargeRatio(pmWorkList.CHARGE_TYPE);
                    }
                    break;
            }
            this.computeCharge.GetCostsCharges();
            this.txt_Charges.Text = this.computeCharge.charges.ToString();
            this.txt_Costs.Text = this.computeCharge.costs.ToString();
            if (this.Mode == "5")
                this.isChange = true;
        }

        public void GetRegChargeRatio(int? ChargeType)
        {
            if (GetConfig.hisVisit)
                switch (GetConfig.hisVender)
                {
                    case "JW":
                        this.computeCharge.chargeRatio = this.regJW.GetChargeRatio(this.cmb_ChargeType.Text);
                        break;
                    case "HT":
                        break;
                }
            else
                switch (GetConfig.DALAndModel)
                {
                    case "SIS":
                        SIS_Model.MArchives mArchives = (SIS_Model.MArchives)this.iArchives;
                        mArchives.CHARGE_CLASS = ChargeType;
                        this.computeCharge.chargeRatio = this.regUPE.GetChargeRatio(ChargeType.ToString());
                        break;
                    case "PACS":
                        this.computeCharge.chargeRatio = this.regPacs.GetChargeRatio(ChargeType.ToString());
                        break;
                }
        }

        private void txt_Costs_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (this.Mode == "6")
                    return;
                if (this.txt_Costs.Text.ToString() == "")
                    this.setData.SetWorkListData("COSTS", null, this.iWorkList);
                else
                    this.setData.SetWorkListData("COSTS", Convert.ToDecimal(this.txt_Costs.Text.ToString()), this.iWorkList);
                if (this.Mode == "5")
                    this.isChange = true;
                this.txt_Charges.Text = this.txt_Costs.Text;
            }
            catch
            {
                MessageBoxEx.Show("只能输入数字！");
            }

        }

        private void txt_Charges_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Mode == "6")
                    return;
                if (this.txt_Charges.Text.ToString() == "")
                    this.setData.SetWorkListData("CHARGES", null, this.iWorkList);
                else
                    this.setData.SetWorkListData("CHARGES", Convert.ToDecimal(this.txt_Charges.Text.ToString()), this.iWorkList);
                if (this.Mode == "5")
                    this.isChange = true;
            }
            catch
            {
                MessageBoxEx.Show("只能输入数字！");
            }
        }

        private void cmb_ExamDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            string examDept = this.cmb_ExamDept.SelectedValue == null ? "" : this.cmb_ExamDept.SelectedValue.ToString();
            this.setData.SetWorkListData("EXAM_DEPT", examDept, this.iWorkList);
            this.setData.SetWorkListData("EXAM_DEPT_NAME", this.cmb_ExamDept.Text, this.iWorkList);
            this.bindData.BindExamDoctor(this.cmb_ExamDept.Text, this.cmb_ExamDoctor);//传部门名
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void cmb_ExamDoctor_TextChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("EXAM_DOCTOR", this.cmb_ExamDoctor.Text, this.iWorkList);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void txt_OutMedInstitution_TextChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("OUT_MED_INSTITUTION", this.txt_OutMedInstitution.Text, this.iWorkList);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void cmb_PatientClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            if (this.cmb_PatientClass.Text == "")
                this.setData.SetWorkListData("PATIENT_CLASS", null, this.iWorkList);
            else
                this.setData.SetWorkListData("PATIENT_CLASS", this.cmb_PatientClass.SelectedIndex, this.iWorkList);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void dtp_ReqDateTime_ValueChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("REQ_DATE_TIME", this.dtp_ReqDateTime.Value, this.iWorkList);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void dtp_ScheduledDate_ValueChanged(object sender, EventArgs e)
        {
            if (this.dtp_ScheduledDate.Checked == true)
            {
                this.groupBox_OrderNotice.Enabled = true;
                this.txt_blfy.Enabled = true;     //add at 2010-08-27 使补录费用可填
            }
            else
            {
                this.groupBox_OrderNotice.Enabled = false;
                this.txt_blfy.Enabled = false;
            }
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("SCHEDULED_DATE", this.dtp_ScheduledDate.Value, this.iWorkList);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void txt_OpdNo_TextChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("OPD_NO", this.txt_OpdNo.Text, this.iWorkList);
            this.setData.SetArchivesData("OPD_NO", this.txt_OpdNo.Text, this.iArchives);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void txt_InpNo_TextChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("INP_NO", this.txt_InpNo.Text, this.iWorkList);
            this.setData.SetArchivesData("INP_NO", this.txt_InpNo.Text, this.iArchives);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void txt_BedNum_TextChanged(object sender, EventArgs e)
        {

            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("BED_NUM", this.txt_BedNum.Text, this.iWorkList);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void cmb_BirthPlace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            if (this.cmb_BirthPlace.SelectedValue != null)
            {
                this.setData.SetWorkListData("BIRTH_PLACE", this.cmb_BirthPlace.SelectedValue.ToString(), this.iWorkList);
                this.setData.SetArchivesData("BIRTH_PLACE", this.cmb_BirthPlace.Text, this.iArchives);
            }
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void txt_PatientIdentity_TextChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("PATIENT_IDENTITY", this.txt_PatientIdentity.Text, this.iWorkList);
            this.setData.SetArchivesData("PATIENT_IDENTITY", this.txt_PatientIdentity.Text, this.iArchives);
            if (this.Mode == "5")
                this.isChange = true;
        }


        private void txt_ZipCode_TextChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("ZIP_CODE", this.txt_ZipCode.Text, this.iWorkList);
            this.setData.SetArchivesData("ZIP_CODE", this.txt_ZipCode.Text, this.iArchives);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void txt_TelephoneNum_TextChanged(object sender, EventArgs e)
        {
            if (txt_TelephoneNum.Text.Length > 16)
                txt_TelephoneNum.Text = txt_TelephoneNum.Text.Substring(0, 16);
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("TELEPHONE_NUM", this.txt_TelephoneNum.Text, this.iWorkList);
            this.setData.SetArchivesData("TELEPHONE_NUM", this.txt_TelephoneNum.Text, this.iArchives);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void txt_MailingAddress_TextChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("MAILING_ADDRESS", this.txt_MailingAddress.Text, this.iWorkList);
            this.setData.SetArchivesData("MAILING_ADDRESS", this.txt_MailingAddress.Text, this.iArchives);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void txt_PhysSign_TextChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("PHYS_SIGN", this.txt_PhysSign.Text, this.iWorkList);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void txt_ClinSymp_TextChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("CLIN_SYMP", this.txt_ClinSymp.Text, this.iWorkList);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void txt_ClinDiag_TextChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("CLIN_DIAG", this.txt_ClinDiag.Text, this.iWorkList);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void txt_RelevantLabTest_TextChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("RELEVANT_LAB_TEST", this.txt_RelevantLabTest.Text, this.iWorkList);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void txt_RelevantDiag_TextChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("RELEVANT_DIAG", this.txt_RelevantDiag.Text, this.iWorkList);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void txt_ReqMemo_TextChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.setData.SetWorkListData("REQ_MEMO", this.txt_ReqMemo.Text, this.iWorkList);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void txt_IdentityCardNo_TextChanged(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            this.setData.SetArchivesData("IDENTITY_CARD_NO", this.txt_IdentityCardNo.Text, this.iArchives);
            if (this.Mode == "5")
                this.isChange = true;
        }

        private void cmb_ExamItems_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cmb_ExamItems.SelectedItem == null)
                return;
            System.Data.DataRow dr = (this.cmb_ExamItems.SelectedItem as System.Data.DataRowView).Row;
            //this.cmb_ExamItems.Text = dr[this.cmb_ExamItems.DisplayMember].ToString().Trim();
            //this.computeCharge.AddExamItem(this.cmb_ExamItems.SelectedValue.ToString(), this.cmb_ExamItems.Text, this.lv_ExamItem.Items.Count + 1);
            //AddExamItemList(this.cmb_ExamItems.Text);
            AddExamItem(dr[this.cmb_ExamItems.DisplayMember].ToString().Trim(), this.cmb_ExamItems.SelectedValue.ToString(), this.lv_ExamItem.Items.Count + 1);
            this.cmb_ExamItems.SelectedIndex = -1;//选择后清空
        }
        /// <summary>
        /// 添加检查项目列表
        /// </summary>
        /// <param name="ItemName">项目名称</param>
        /// <param name="ItemCode">项目代码</param>
        /// <param name="ItemCount">第几项</param>
        //modify by liukun at 2010-06-10 begin 
        //修改原因：登记时如果重复选择某一检查项目后引起金额出错及“检查项目列”表的列表项目重复。
        //修改记录：将this.computeCharge.AddExamItem(ItemCode, itemName, ItemCount)放到 AddExamItemList(string itemName, string ItemCode, int ItemCount)方法体内部。
        //          当且仅当检查项目添加成功后才调用执行。
        private void AddExamItem(string ItemName, string ItemCode, int ItemCount)
        {
            this.cmb_ExamItems.Text = ItemName;
            //this.computeCharge.AddExamItem(ItemCode, itemName, ItemCount); comment by liukun at 2010-06-10
            AddExamItemList(ItemName,ItemCode,ItemCount);
        }
        public void AddExamItemList(string itemName, string ItemCode, int ItemCount)
        {
            for (int i = 0; i < lv_ExamItem.Items.Count; i++)
            {
                if (lv_ExamItem.Items[i].SubItems[0].Text.Trim() == itemName)
                    return;
            }
            this.computeCharge.AddExamItem(ItemCode, itemName, ItemCount);//add by liukun at 2010-06-10
            this.lv_ExamItem.BeginUpdate();
            string[] lvitem = new string[3];
            lvitem[0] = itemName;
            lvitem[1] = this.computeCharge.ItemCosts.ToString();
            lvitem[2] = this.computeCharge.ItemCharges.ToString();
            ListViewItem lvi = new ListViewItem(lvitem);
            this.lv_ExamItem.Items.Add(lvi);
            this.lv_ExamItem.EndUpdate();
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.iWorkList;
                    smWorkList.EXAM_ITEMS += this.cmb_ExamItems.Text + ";";
                    break;
                case "PACS":
                    PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.iWorkList;
                    pmWorkList.EXAM_ITEMS += this.cmb_ExamItems.Text + ";";
                    break;
            }
            this.txt_Charges.Text = this.computeCharge.charges.ToString();
            this.txt_Costs.Text = this.computeCharge.costs.ToString();
            string mode = this.Mode;
            this.Mode = "6";
            this.cmb_ExamItems.Text = "";
            this.Mode = mode;
        }
        //modify by liukun at 2010-06-10 end 
        #endregion

        public void btn_NewPatientId_Click(object sender, EventArgs e)
        {
            this.initReg.initMode4("");
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            if (this.newReg.NewExam())
            {
                SetDisable(false);
            }
        }

        private void btn_DeleteExamItem_Click(object sender, EventArgs e)
        {
            this.DeleteExamItem();
        }

        private void DeleteExamItem()
        {
            if (this.lv_ExamItem.SelectedItems.Count == 0)
                return;
            this.computeCharge.RemoveExamItem(this.lv_ExamItem.SelectedItems[0].Index);
            this.lv_ExamItem.Items.RemoveAt(this.lv_ExamItem.SelectedItems[0].Index);
            string items = "";
            for (int i = 0; i < this.lv_ExamItem.Items.Count; i++)
            {
                items += this.lv_ExamItem.Items[i].Text + ";";
            }
            items = items.TrimEnd(';');
            this.setData.SetWorkListData("EXAM_ITEMS", GetExamItems(), this.iWorkList);
            this.txt_Charges.Text = this.computeCharge.charges.ToString();
            this.txt_Costs.Text = this.computeCharge.costs.ToString();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Delete:
                    this.DeleteExamItem();
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }
        /// <summary>
        /// 取得所有检查类别，中间以分号隔开
        /// </summary>
        /// <returns></returns>
        private string GetExamItems()
        {
            string items = "";
            for (int i = 0; i < this.lv_ExamItem.Items.Count; i++)
            {
                items += this.lv_ExamItem.Items[i].Text + ";";
            }
            items = items.TrimEnd(';');
            return items;
        }
        private void btn_CatchReqImage_Click(object sender, EventArgs e)
        {
            this.reqScanImage.GrabImage();
        }

        private void btn_OpenCamera_Click(object sender, EventArgs e)
        {
            this.reqScanImage.Start();
        }

        private void btn_CloseCamera_Click(object sender, EventArgs e)
        {
            this.reqScanImage.Close();
        }

        private void btn_DeleteScanImg_Click(object sender, EventArgs e)
        {
            this.reqScanImage.DeleteImage();
        }

        private void frmRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.reqScanImage.Close();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            frmMainForm.myMainForm.SetFormHidden();//显示窗体前影藏所有窗体
            frmMainForm.myMainForm.SetFormDisplay("快速查询", "SIS.frmQuickQuery");
        }

        private void btn_AddExamItem_Click(object sender, EventArgs e)
        {
            if (cmb_ExamItems.Text.Trim() != "")
            {
                AddExamItem(this.cmb_ExamItems.Text, "QT", lv_ExamItem.Items.Count + 1);
            }
        }

        private void btn_Deal_Click(object sender, EventArgs e)
        {

        }
        #region 设置全角半角
        private void txt_PatientName_Enter(object sender, EventArgs e)
        {
            SetImeMode.SetHalfShape(this.txt_PatientName, true);
        }

        private void txt_PatientId_Enter(object sender, EventArgs e)
        {
            SetImeMode.SetHalfShape(this.txt_PatientId, false);
        }

        private void txt_PhysSign_Enter(object sender, EventArgs e)
        {
            SetImeMode.SetHalfShape(this.txt_PhysSign, true);
        }

        private void txt_ClinSymp_Enter(object sender, EventArgs e)
        {
            SetImeMode.SetHalfShape(this.txt_ClinSymp, true);
        }

        private void txt_RelevantLabTest_Enter(object sender, EventArgs e)
        {
            SetImeMode.SetHalfShape(this.txt_RelevantLabTest, true);
        }

        private void txt_RelevantDiag_Enter(object sender, EventArgs e)
        {
            SetImeMode.SetHalfShape(this.txt_RelevantDiag, true);
        }

        private void txt_ClinDiag_Enter(object sender, EventArgs e)
        {
            SetImeMode.SetHalfShape(this.txt_ClinDiag, true);
        }

        private void txt_ReqMemo_Enter(object sender, EventArgs e)
        {
            SetImeMode.SetHalfShape(this.txt_ReqMemo, true);
        }

        private void txt_OutMedInstitution_Enter(object sender, EventArgs e)
        {
            SetImeMode.SetHalfShape(this.txt_OutMedInstitution, true);
        }

        private void txt_MailingAddress_Enter(object sender, EventArgs e)
        {
            SetImeMode.SetHalfShape(this.txt_MailingAddress, true);
        }

        private void txt_PatientIdentity_Enter(object sender, EventArgs e)
        {
            SetImeMode.SetHalfShape(this.txt_PatientIdentity, true);
        }
        #endregion 设置全角半角

        //相同病人按钮
        private void btn_SamePatient_Click(object sender, EventArgs e)
        {


            if (this.txt_PatientId.Text.Trim() == "")
                return;

            IModel oldWorkList = this.iWorkList;
            IModel oldArchives = this.iArchives;
            string PatientId = this.txt_PatientId.Text.ToString().Trim();
            this.newReg.NewExam();

            this.initReg.initMode6(oldWorkList, oldArchives);
            this.isAdd = true;
        }

        #region WIN消息
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessage(int hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);

        const int WM_COPYDATA = 0x004A;
        [StructLayout(LayoutKind.Sequential)]
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }
        private int SendMsg(String msg, int WINDOW_HANDLER)
        {
            if (WINDOW_HANDLER != 0)
            {
                byte[] sarr = System.Text.Encoding.Default.GetBytes(msg);
                int len = sarr.Length;
                COPYDATASTRUCT cds;
                cds.dwData = (IntPtr)100;
                cds.lpData = msg;
                cds.cbData = len + 1;
                IntPtr result = SendMessage(WINDOW_HANDLER, WM_COPYDATA, 1, ref cds);
                string s1 = Marshal.PtrToStringAnsi(result);
                result.GetType();
                // return int.presult.ToString();
                //DefWndProc(SendMessage(WINDOW_HANDLER, WM_COPYDATA, 0, ref cds));
                //result.ToString();
                return 1;
            }
            else
            {
                return -1;
            }
        }
        #endregion Win消息

        private void btn_OpenRpt_Click(object sender, EventArgs e)
        {
            frmMainForm.myMainForm.qQuery.OpenReport(this.iWorkList);
        }

        private void frmRegister_LocationChanged(object sender, EventArgs e)
        {
            this.btn_Form.Text = this.Text;
        }

        private void txt_PatientName_Leave(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            if (this.txt_PatientId.Text != "" && this.cmb_ExamClass.Text != "" && this.cmb_ExamSubClass.Text != "" && this.dud_PatientLocalId.Text == "")
                this.GetLocalId();
        }

        private void txt_InpNo_Leave(object sender, EventArgs e)
        {
            if (this.Mode == "6")
                return;
            if (this.txt_PatientId.Text != "" && this.cmb_ExamClass.Text != "" && this.cmb_ExamSubClass.Text != "" && this.dud_PatientLocalId.Text == "")
                this.GetLocalId();
        }
        public void SetDisable(bool Enable)
        {
            this.IsCreated = Enable;
            this.p_ExamInf.Enabled = Enable;
        }

        private void tap_OtherInf_Click(object sender, EventArgs e)
        {

        }
        #region 添加输入框字典
        private Control FocusTxt;
        
        public DataTable GetDict(string DictName)
        {
            try
            {
                string DictPath = Application.StartupPath + "\\TxtDict\\" + DictName;
                this.CMS_Dict.Items.Clear();
                StreamReader fileRead = new StreamReader(DictPath, System.Text.Encoding.Default);
                for (string str = fileRead.ReadLine(); str != null; str = fileRead.ReadLine())
                {
                    ToolStripMenuItem tsmi = new ToolStripMenuItem(str);
                    tsmi.Click += new EventHandler(tsmi_Click);
                    this.CMS_Dict.Items.Add(tsmi);

                }
                fileRead.Close();
                FocusTxt.ContextMenuStrip = CMS_Dict;
            }
            catch{}
            return null;
        }
        void tsmi_Click(object sender, EventArgs e)
        {
            FocusTxt.Text += sender.ToString();
        }
        
        //体征
        private void txt_PhysSign_MouseDown(object sender, MouseEventArgs e)
        {
            FocusTxt = (Control)sender;
            FocusTxt.Focus();
            GetDict("体征.txt");
        }
        //临床症状
        private void txt_ClinSymp_MouseDown(object sender, MouseEventArgs e)
        {

            FocusTxt = (Control)sender;
            FocusTxt.Focus();
            GetDict("临床症状.txt");
        }

        //临床诊断
        private void txt_ClinDiag_MouseDown(object sender, MouseEventArgs e)
        {

            FocusTxt = (Control)sender;
            FocusTxt.Focus();
            GetDict("临床诊断.txt");

        }

        //相关化验
        private void txt_RelevantLabTest_MouseDown(object sender, MouseEventArgs e)
        {

            FocusTxt = (Control)sender;
            FocusTxt.Focus();
            GetDict("相关化验.txt");

        }

        //其它诊断
        private void txt_RelevantDiag_MouseDown(object sender, MouseEventArgs e)
        {
            FocusTxt = (Control)sender;
            FocusTxt.Focus();
            GetDict("其它诊断.txt");

        }

        //申请备注
        private void txt_ReqMemo_MouseDown(object sender, MouseEventArgs e)
        {
            FocusTxt = (Control)sender;
            FocusTxt.Focus();
            GetDict("申请备注.txt");
        }

        #endregion 添加输入框字典
        //
        private void cmb_ReferDept_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                FocusTxt = (Control)sender;
                FocusTxt.Focus();
                GetDict("申请科室.txt");
            }
        }

        private void cmb_ReferDoctor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                FocusTxt = (Control)sender;
                FocusTxt.Focus();
                GetDict("申请医生.txt");
            }
        }
        /// <summary>
        /// add by liukun at 20100603 begin 
        /// 调用慧通接口程序进行费用补录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_fybl_Click(object sender, EventArgs e)
        {
            try
            {
                //Edit at 2010-08-17
                //if ((this.Mode == "4" || this.Mode == "00" || this.Mode == "11") && (btn_Save.Enabled == true && this.lb_Notice .Text != "保存成功！"))
                //{
                //    MessageBox.Show("请先保存登记数据后再进行费用补录！");
                //    return;
                //}
                //if (this.Mode == "5" && (this.lb_Notice.Text != "修改成功！" && this.lb_Notice.Text != "编辑病人登记信息"))
                //{
                //    MessageBox.Show("请先保存登记数据后再进行费用补录！");
                //    return;
                //}
                string strFilePath = Environment.CurrentDirectory;
                if (GetConfig.DALAndModel == "PACS")
                {
                    PACS_Model.MUser muser = (PACS_Model.MUser)iUser;
                    PACS_Model.MWorkList smWorkList = (PACS_Model.MWorkList)this.iWorkList;
                    //启动参数:执行科室代码+执行科室名称+用户名+申请单号 00@放射科@6666@10051968772
                    string strArgs = muser.USER_DEPT + "@" + muser.DEPT_NAME + "@" + muser.DB_USER + "@" + smWorkList.EXAM_NO;
                    //strArgs = "00@放射科@6666@10051968772";
                    //MessageBox.Show(strArgs);
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = strFilePath + "\\HuiTong\\FeiYongBuLu\\bfy_main.exe";
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.Arguments = strArgs;
                    proc.Start();
                }
                if (GetConfig.DALAndModel == "SIS")
                {
                    SIS_Model.MUser muser = (SIS_Model.MUser)iUser;
                    SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.iWorkList;
                    //启动参数:执行科室代码+执行科室名称+用户名+申请单号 00@放射科@6666@10051968772
                    string strArgs = muser.CLINIC_OFFICE_CODE + "@" + muser.CLINIC_OFFICE + "@" + muser.DOCTOR_ID + "@" + smWorkList.EXAM_NO;
                    //strArgs = "00@放射科@6666@10051968772";
                    //MessageBox.Show(strArgs);
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = strFilePath + "\\HuiTong\\FeiYongBuLu\\bfy_main.exe";
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.Arguments = strArgs;
                    proc.Start();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }
        /// add by liukun at 20100603 end 
        /// 

        /// <summary>
        /// 执行后台数据库存储过程
        /// add by liukun at 20100604 begin 增加预约时间回写功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExecuteProcedure(string strSystemName, string ProcName, OracleParameter[] parms)
        {
            string strConnection = "";
            switch (strSystemName)
            {
                case "HIS":
                    strConnection = "Data Source=WISETOP;Integrated Security=false;User ID=HT;Password=HT";
                    break;
                case "SIS":
                    strConnection = "Data Source=PAXDBSRV;Integrated Security=false;User ID=UPEDB;Password=UPEDB";
                    break;
            }
            
            try
            {
                OracleConnection conn = new OracleConnection(strConnection);
                OracleCommand cmd = new OracleCommand(ProcName , conn);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < parms.Length; i++)
                {
                    cmd.Parameters.Add(parms[i]);
                }
                this.oraCmd = cmd; 
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }

        /// <summary>
        /// "预约时间"回写到HIS系统
        /// </summary>
        private void SaveYuyueshijianToHIS()
        {
            try
            {
                string strErroMsg = "";
                string strOthers = "" ;
                string strNotice = "" ;
                string strYysjBegin = "";
                string strYysjEnd = "";
                int inum = 0;
                if (this.cmb_ExamClass.Text.Trim() != "")
                {
                    strOthers += ", EXAM_CLASS = '" + this.cmb_ExamClass.Text.Trim() + "' ";

                }
                if (this.cmb_ExamGroup.Text.Trim() != "")
                {
                    strOthers += ", EXAM_GROUP = '" + this.cmb_ExamGroup.Text.Trim() + "' ";
                }
                if (this.comboBox_OrderExamClass.Text.Trim() != "")
                {
                    strOthers += ", ORDER_EXAM_CLASS = '" + this.comboBox_OrderExamClass.Text.Trim() + "' ";
                }
                //Add at 2010-08-27 增加一个字段FSUM，用于更新预约申请单的补录收费金额，并更新到HIS中
                if (this.txt_blfy.Text.Trim() == "")
                {
                    DialogResult result;
                    result = MessageBox.Show("补录费用尚未填写，请确认是否需要补录费用", "补录费用提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        this.isBlfy = true;
                        return;
                    }
                }
                else
                {
                    strOthers += ", FSUM = '" + this.txt_blfy.Text.Trim() + "'";
                }
                //End at 2010-08-27

                strYysjBegin = this.dtp_ScheduledDate.Text + " " + this.comboBox_yyqzsjd.Text.Substring(0, 5);
                strYysjEnd = this.dtp_ScheduledDate.Text + " " + this.comboBox_yyqzsjd.Text.Substring(8);
                strOthers += ", FBOOKTIMEEND= to_date('" + strYysjEnd + "','YYYY-MM-DD HH24:MI:SS') ";
                foreach (int indexChecked in this.clb_OrderNotice.CheckedIndices)
                {
                    inum++;
                    strNotice += inum.ToString () + "、" + this.clb_OrderNotice.GetItemText(this.clb_OrderNotice.Items[indexChecked]).ToString() + "\r\n";
                }
                

                if (GetConfig.DALAndModel == "SIS")
                {
                    SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.iWorkList;
                    OracleParameter[] parms = new OracleParameter[7];
                    parms[0] = new OracleParameter("aSource", OracleType.VarChar);
                    parms[1] = new OracleParameter("aApplyNo", OracleType.VarChar);
                    parms[2] = new OracleParameter("aDate", OracleType.VarChar);
                    parms[3] = new OracleParameter("aBooker", OracleType.VarChar);
                    parms[4] = new OracleParameter("aNote", OracleType.VarChar);
                    parms[5] = new OracleParameter("aOthers", OracleType.VarChar);
                    parms[6] = new OracleParameter("aResult", OracleType.VarChar, 20);
                    parms[0].Direction = ParameterDirection.Input;
                    parms[0].Value = smWorkList.PATIENT_SOURCE;
                    parms[1].Direction = ParameterDirection.Input;
                    parms[1].Value = smWorkList.EXAM_NO;
                    parms[2].Direction = ParameterDirection.Input;
                    //parms[2].Value = strYysjBegin;//(smWorkList.SCHEDULED_DATE == null ? "" : strYysjBegin);
                    parms[2].Value = (smWorkList.SCHEDULED_DATE == null ? "" : strYysjBegin);
                    parms[3].Direction = ParameterDirection.Input;
                    parms[3].Value = smWorkList.SCH_OPERATOR;
                    parms[4].Direction = ParameterDirection.Input;//预约注意事项
                    parms[4].Value = strNotice;
                    parms[5].Direction = ParameterDirection.Input;//其它字段
                    parms[5].Value = strOthers;
                    parms[6].Direction = ParameterDirection.Output;
                    if (smWorkList.EXAM_NO == null || smWorkList.EXAM_NO.Trim() == "")
                    {
                        //MessageBox.Show("登记信息已保存成功！\r\n无法获取检查申请单号，不能向HIS系统回填预约时间，\r\n请确认临床医生是否是开出检查申请单！");
                        return;
                    }
                    ExecuteProcedure("HIS", "H6JGETJCAPPLY.SetApplyBookTime", parms);
                    if (parms[6].Value.ToString() != "1")
                    {
                        for (int i = 0; i < parms.Length - 1; i++)
                        {
                            strErroMsg += parms[i] + "=" + parms[i].Value + "\r\n";
                        }
                        MessageBox.Show("预约时间回填到HIS系统失败!传入参数为:\r\n" + strErroMsg);
                        return;
                    }
                }
                if (GetConfig.DALAndModel == "PACS")
                {
                    PACS_Model.MWorkList smWorkList = (PACS_Model.MWorkList)this.iWorkList;
                    OracleParameter[] parms = new OracleParameter[7];
                    parms[0] = new OracleParameter("aSource", OracleType.VarChar);
                    parms[1] = new OracleParameter("aApplyNo", OracleType.VarChar);
                    parms[2] = new OracleParameter("aDate", OracleType.VarChar);
                    parms[3] = new OracleParameter("aBooker", OracleType.VarChar);
                    parms[4] = new OracleParameter("aNote", OracleType.VarChar);
                    parms[5] = new OracleParameter("aOthers", OracleType.VarChar);
                    parms[6] = new OracleParameter("aResult", OracleType.VarChar, 20);
                    parms[0].Direction = ParameterDirection.Input;
                    parms[0].Value = smWorkList.PATIENT_SOURCE;
                    parms[1].Direction = ParameterDirection.Input;
                    parms[1].Value = smWorkList.EXAM_NO;
                    parms[2].Direction = ParameterDirection.Input;
                    parms[2].Value = (smWorkList.SCHEDULED_DATE == null ? "" : strYysjBegin);
                    parms[3].Direction = ParameterDirection.Input;
                    parms[3].Value = smWorkList.SCH_OPERATOR;
                    parms[4].Direction = ParameterDirection.Input;//预约注意事项
                    parms[4].Value = strNotice;
                    parms[5].Direction = ParameterDirection.Input;//其它字段
                    parms[5].Value = strOthers;
                    parms[6].Direction = ParameterDirection.Output;
                    if (smWorkList.EXAM_NO == null || smWorkList.EXAM_NO.Trim() == "")
                    {
                        //MessageBox.Show("登记信息已保存成功！\r\n无法获取检查申请单号，不能向HIS系统回填预约时间，\r\n请确认临床医生是否是开出检查申请单！");
                        return;
                    }
                    ExecuteProcedure("HIS", "H6JGETJCAPPLY.SetApplyBookTime", parms);
                    if (parms[6].Value.ToString() != "1")
                    {
                        for (int i = 0; i < parms.Length - 1; i++)
                        {
                            strErroMsg += parms[i] + "=" + parms[i].Value + "\r\n";
                        }
                        MessageBox.Show("预约时间回填到HIS系统失败!传入参数为:\r\n" + strErroMsg);
                        return;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        
        }
        // add by liukun at 20100604 end

        /// <summary>
        /// 取申请单检查补记账总金额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_GetSumCosts_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetConfig.DALAndModel == "SIS")
                {
                    SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.iWorkList;
                    OracleParameter[] parms = new OracleParameter[2];
                    parms[0] = new OracleParameter("aApplyNo", OracleType.VarChar);
                    parms[0].Direction = ParameterDirection.Input;
                    parms[0].Value = smWorkList.EXAM_NO;
                    parms[1] = new OracleParameter("iSum", OracleType.Number);
                    parms[1].Direction = ParameterDirection.ReturnValue;
                    if (smWorkList.EXAM_NO == null || smWorkList.EXAM_NO.Trim() == "")
                    {
                        MessageBox.Show("无法获取检查申请单号，请确认临床医生是否是开出检查申请单！");
                        return;
                    }
                    ExecuteProcedure("HIS", "H6JGETJCAPPLY.GetApplySumJine", parms);
                    MessageBox.Show("申请单检查补记账总金额为：" + parms[1].Value.ToString() + "元");
                }
                if (GetConfig.DALAndModel == "PACS")
                {
                    PACS_Model.MWorkList smWorkList = (PACS_Model.MWorkList)this.iWorkList;
                    OracleParameter[] parms = new OracleParameter[2];
                    parms[0] = new OracleParameter("aApplyNo", OracleType.VarChar);
                    parms[0].Direction = ParameterDirection.Input;
                    parms[0].Value = smWorkList.EXAM_NO;
                    parms[1] = new OracleParameter("iSum", OracleType.Number);
                    parms[1].Direction = ParameterDirection.ReturnValue;
                    if (smWorkList.EXAM_NO == null || smWorkList.EXAM_NO.Trim() == "")
                    {
                        MessageBox.Show("无法获取检查申请单号，请确认临床医生是否是开出检查申请单！");
                        return;
                    }
                    ExecuteProcedure("HIS", "H6JGETJCAPPLY.GetApplySumJine", parms);
                    MessageBox.Show("申请单检查补记账总金额为：" + parms[1].Value.ToString() + "元");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
            
        }

        //add by liukun at 2010-6-25 begin 
        //增加查看并预约与HIS系统临床医生开出的电子检查申请单
        /// <summary>
        /// 根据执行科室查询临床医生开出的电子检查申请单
        /// </summary>
        /// <param name="dgv_DataGrid_View"></param>
        /// <param name="bs_BindingSource"></param>
        /// <param name="strHisSatus"></param>
        /// <param name="strPacsSatus"></param>
        /// <param name="strBeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="strOtherWhere"></param>
        /// <returns></returns>
        private int SearchHisExamList(ref DataGridView dgv_DataGrid_View,ref BindingSource bs_BindingSource, string strHisSatus,string strBeginDate,string EndDate,string strOtherWhere)
        {
            try
            {
                //执行后台数据库存储过程并绑定到DataGridView数据源
                OracleParameter[] parms = new OracleParameter[11];
                parms[0] = new OracleParameter("aApplyNo", OracleType.VarChar);
                parms[1] = new OracleParameter("aSource", OracleType.VarChar);
                parms[2] = new OracleParameter("aPatNoType", OracleType.VarChar);
                parms[3] = new OracleParameter("aPatNo", OracleType.VarChar);
                parms[4] = new OracleParameter("aCheckType", OracleType.VarChar);
                parms[5] = new OracleParameter("aExecuteDptNo", OracleType.VarChar);
                parms[6] = new OracleParameter("aBeginDate", OracleType.VarChar);
                parms[7] = new OracleParameter("aEndDate", OracleType.VarChar);
                parms[8] = new OracleParameter("aStatus", OracleType.VarChar);
                parms[9] = new OracleParameter("aExeSql", OracleType.VarChar, 2000);
                parms[10] = new OracleParameter("aReturnSet", OracleType.Cursor);

                parms[0].Direction = ParameterDirection.Input;//aApplyNo
                parms[0].Value = ""; //默认为空
                parms[1].Direction = ParameterDirection.Input;//aSource
                parms[1].Value = "2";//1:门诊、2:住院
                parms[2].Direction = ParameterDirection.Input;//aPatNoType
                parms[2].Value = ""; //默认为空
                parms[3].Direction = ParameterDirection.Input;//aPatNo
                parms[3].Value = ""; //默认为空
                parms[4].Direction = ParameterDirection.Input;//aCheckType
                parms[4].Value = ""; //默认为空
                parms[5].Direction = ParameterDirection.Input;//aExecuteDptNo
                parms[6].Direction = ParameterDirection.Input ;//aBeginDate
                parms[6].Value = strBeginDate;
                parms[7].Direction = ParameterDirection.Input;//aEndDate
                parms[7].Value = EndDate;
                parms[8].Direction = ParameterDirection.Input;//aStatus
                parms[8].Value = strHisSatus;//根据HIS的字典参数设置，3：已预约未报到登记；4：已报到登记未完成；5：已检查完成
                parms[9].Direction = ParameterDirection.InputOutput;//aExeSql 其它Where查询条件，格式：and field1=value1 and field2 = value2
                parms[9].Value = strOtherWhere;
                parms[10].Direction = ParameterDirection.Output;//aReturnSet

                //取执行检查申请单的执行科室(即检查科室)代码
                if (GetConfig.DALAndModel == "SIS")
                {
                    SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.iWorkList;
                    parms[5].Value = smWorkList.EXAM_DEPT;
                }
                else if (GetConfig.DALAndModel == "PACS")
                {
                    PACS_Model.MWorkList smWorkList = (PACS_Model.MWorkList)this.iWorkList;
                    parms[5].Value = smWorkList.EXAM_DEPT;
                }
                //执行后台存储过程
                ExecuteProcedure("HIS", "H6JGETJCAPPLY.GetApplyPatList", parms);
                OracleDataAdapter dataAdapter = new OracleDataAdapter(this.oraCmd );

                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bs_BindingSource.DataSource = table;
                dgv_DataGrid_View.DataSource = bs_BindingSource;
                SetDgvDisplyColomnIndex(ref dgv_DataGrid_View);
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return -1;
            }
        }

        /// <summary>
        /// 选中HIS检查申请记录
        /// </summary>
        /// <param name="dgv_DataGridView"></param>
        private void SelectExamAppoints(ref DataGridView dgv_DataGridView )
        {
            try
            {
                DataGridViewRow dr = dgv_DataGridView.SelectedRows[0];
                switch (dgv_DataGridView.Name)
                {
                    case "dgv_UnorderApplicationForm":  //未预约申请单
                        switch (GetConfig.DALAndModel)
                        {
                            case "SIS":

                                SIS_Model.MArchives mArchives = (SIS_Model.MArchives)this.iArchives;

                                mArchives.PATIENT_NAME = dr.Cells["NAME_Unorder"].Value.ToString();
                                mArchives.PATIENT_SEX = dr.Cells["SEX_Unorder"].Value.ToString();
                                if (dr.Cells["BIRTHDATE_Unorder"].Value.ToString() != "")
                                    mArchives.PATIENT_BIRTH = Convert.ToDateTime(dr.Cells["BIRTHDATE_Unorder"].Value.ToString());
                                mArchives.IDENTITY_CARD_NO = dr.Cells["PATSTACODE_Unorder"].Value.ToString();
                                mArchives.MAILING_ADDRESS = dr.Cells["ADDRESS_Unorder"].Value.ToString();
                                mArchives.TELEPHONE_NUM = dr.Cells["TELEPHONE_Unorder"].Value.ToString();
                                SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.iWorkList;
                                smWorkList.PATIENT_NAME = dr.Cells["NAME_Unorder"].Value.ToString();
                                smWorkList.PATIENT_SEX = dr.Cells["SEX_Unorder"].Value.ToString();
                                if (dr.Cells["BIRTHDATE_Unorder"].Value.ToString() != "")
                                    smWorkList.PATIENT_BIRTH = Convert.ToDateTime(dr.Cells["BIRTHDATE_Unorder"].Value.ToString());
                                if (dr.Cells["SOURCE_Unorder"].Value.ToString() == "住院")
                                {
                                    smWorkList.INP_NO = dr.Cells["INHOSPITALNO_Unorder"].Value.ToString();//住院号
                                }
                                else
                                {
                                    smWorkList.OPD_NO = dr.Cells["INHOSPITALNO_Unorder"].Value.ToString();//门诊号
                                }
                                smWorkList.BED_NUM = dr.Cells["BEDNO_Unorder"].Value.ToString();      //床号
                                smWorkList.MAILING_ADDRESS = dr.Cells["ADDRESS_Unorder"].Value.ToString();//地址
                                smWorkList.TELEPHONE_NUM = dr.Cells["TELEPHONE_Unorder"].Value.ToString();//电话
                                smWorkList.PATIENT_SOURCE = dr.Cells["CLIISINPAT_Unorder"].Value.ToString(); //病人来源
                                smWorkList.REFER_DEPT = dr.Cells["LODGESECTION_Unorder"].Value.ToString(); //申请科室
                                smWorkList.REFER_DOCTOR = dr.Cells["LODGEDOCTOR_Unorder"].Value.ToString(); //申请医生
                                smWorkList.CLIN_DIAG = dr.Cells["DIAGNOSIS_Unorder"].Value.ToString();    //诊断
                                smWorkList.EXAM_NO = dr.Cells["ApplyNo_Unorder"].Value.ToString();    //申请单号
                                //smWorkList.INPATIENTNO = dr.Cells["INPATIENTNO_Unorder"].Value.ToString();//记账号
                                smWorkList.JZH  = dr.Cells["INPATIENTNO_Unorder"].Value.ToString();//临床记账号
                                break;
                            case "PACS":
                                PACS_Model.MArchives PArchives = (PACS_Model.MArchives)this.iArchives;
                                PArchives.PATIENT_NAME = dr.Cells["NAME_Unorder"].Value.ToString();
                                PArchives.PATIENT_SEX = dr.Cells["SEX_Unorder"].Value.ToString();
                                if (dr.Cells["BIRTHDATE_Unorder"].Value.ToString() != "")
                                    PArchives.PATIENT_BIRTH = Convert.ToDateTime(dr.Cells["BIRTHDATE_Unorder"].Value.ToString());
                                PArchives.IDENTITY_CARD_NO = dr.Cells["PATSTACODE_Unorder"].Value.ToString();
                                PArchives.MAILING_ADDRESS = dr.Cells["ADDRESS_Unorder"].Value.ToString();
                                PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.iWorkList;
                                pmWorkList.PATIENT_NAME = dr.Cells["NAME_Unorder"].Value.ToString();
                                pmWorkList.PATIENT_SEX = dr.Cells["SEX_Unorder"].Value.ToString();
                                if (dr.Cells["BIRTHDATE_Unorder"].Value.ToString() != "")
                                    pmWorkList.PATIENT_BIRTH = Convert.ToDateTime(dr.Cells["BIRTHDATE_Unorder"].Value.ToString());
                                if (dr.Cells["SOURCE_Unorder"].Value.ToString() == "住院")
                                {
                                    pmWorkList.INP_NO = dr.Cells["INHOSPITALNO_Unorder"].Value.ToString();//住院号
                                }
                                else
                                {
                                    pmWorkList.OPD_NO = dr.Cells["INHOSPITALNO_Unorder"].Value.ToString();//门诊号
                                }
                                pmWorkList.BED_NUM = dr.Cells["BEDNO_Unorder"].Value.ToString();      //床号
                                pmWorkList.MAILING_ADDRESS = dr.Cells["ADDRESS_Unorder"].Value.ToString();//地址
                                pmWorkList.TELEPHONE_NUM = dr.Cells["TELEPHONE_Unorder"].Value.ToString();//电话
                                pmWorkList.PATIENT_SOURCE = dr.Cells["CLIISINPAT_Unorder"].Value.ToString(); //病人来源
                                pmWorkList.REFER_DEPT = dr.Cells["LODGESECTION_Unorder"].Value.ToString(); //申请科室
                                pmWorkList.REFER_DOCTOR = dr.Cells["LODGEDOCTOR_Unorder"].Value.ToString(); //申请医生
                                pmWorkList.CLIN_DIAG = dr.Cells["DIAGNOSIS_Unorder"].Value.ToString();    //诊断
                                pmWorkList.EXAM_NO = dr.Cells["ApplyNo_Unorder"].Value.ToString();
                                //pmWorkList.INPATIENTNO = dr.Cells["INPATIENTNO_Unorder"].Value.ToString();//记账号 
                                pmWorkList.JZH  = dr.Cells["INPATIENTNO_Unorder"].Value.ToString();//临床记账号 
                                break;
                        }

                        if (dr.Cells["CLIISINPAT_Unorder"].Value.ToString() == "2")
                            this.Mode = "11";
                        else
                            this.Mode = "01";
                        break;
                    case "dgv_OrderedApplicationForm":      //已预约申请单
                        switch (GetConfig.DALAndModel)
                        {
                            case "SIS":

                                SIS_Model.MArchives mArchives = (SIS_Model.MArchives)this.iArchives;

                                mArchives.PATIENT_NAME = dr.Cells["NAME_Ordered"].Value.ToString();
                                mArchives.PATIENT_SEX = dr.Cells["SEX_Ordered"].Value.ToString();
                                if (dr.Cells["BIRTHDATE_Ordered"].Value.ToString() != "")
                                    mArchives.PATIENT_BIRTH = Convert.ToDateTime(dr.Cells["BIRTHDATE_Ordered"].Value.ToString());
                                mArchives.IDENTITY_CARD_NO = dr.Cells["PATSTACODE_Ordered"].Value.ToString();
                                mArchives.MAILING_ADDRESS = dr.Cells["ADDRESS_Ordered"].Value.ToString();
                                mArchives.TELEPHONE_NUM = dr.Cells["TELEPHONE_Ordered"].Value.ToString();
                                SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.iWorkList;
                                smWorkList.PATIENT_NAME = dr.Cells["NAME_Ordered"].Value.ToString();
                                smWorkList.PATIENT_SEX = dr.Cells["SEX_Ordered"].Value.ToString();
                                if (dr.Cells["BIRTHDATE_Ordered"].Value.ToString() != "")
                                    smWorkList.PATIENT_BIRTH = Convert.ToDateTime(dr.Cells["BIRTHDATE_Ordered"].Value.ToString());
                                if (dr.Cells["SOURCE_Ordered"].Value.ToString() == "住院")
                                {
                                    smWorkList.INP_NO = dr.Cells["INHOSPITALNO_Ordered"].Value.ToString();//住院号
                                }
                                else
                                {
                                    smWorkList.OPD_NO = dr.Cells["INHOSPITALNO_Ordered"].Value.ToString();//门诊号
                                }
                                smWorkList.BED_NUM = dr.Cells["BEDNO_Ordered"].Value.ToString();      //床号
                                smWorkList.MAILING_ADDRESS = dr.Cells["ADDRESS_Ordered"].Value.ToString();//地址
                                smWorkList.TELEPHONE_NUM = dr.Cells["TELEPHONE_Ordered"].Value.ToString();//电话
                                smWorkList.PATIENT_SOURCE = dr.Cells["CLIISINPAT_Ordered"].Value.ToString(); //病人来源
                                smWorkList.REFER_DEPT = dr.Cells["LODGESECTION_Ordered"].Value.ToString(); //申请科室
                                smWorkList.REFER_DOCTOR = dr.Cells["LODGEDOCTOR_Ordered"].Value.ToString(); //申请医生
                                smWorkList.CLIN_DIAG = dr.Cells["DIAGNOSIS_Ordered"].Value.ToString();    //诊断
                                smWorkList.EXAM_NO = dr.Cells["ApplyNo_Ordered"].Value.ToString();    //申请单号
                                //smWorkList.INPATIENTNO = dr.Cells["INPATIENTNO_Ordered"].Value.ToString();//记账号
                                smWorkList.JZH = dr.Cells["INPATIENTNO_Ordered"].Value.ToString();//临床记账号 
                                smWorkList.EXAM_CLASS = dr.Cells["EXAM_CLASS_Ordered"].Value.ToString();//检查类别
                                smWorkList.EXAM_GROUP = dr.Cells["EXAM_GROUP_Ordered"].Value.ToString();//诊室名
                                break;
                            case "PACS":
                                PACS_Model.MArchives PArchives = (PACS_Model.MArchives)this.iArchives;
                                PArchives.PATIENT_NAME = dr.Cells["NAME_Ordered"].Value.ToString();
                                PArchives.PATIENT_SEX = dr.Cells["SEX_Ordered"].Value.ToString();
                                if (dr.Cells["BIRTHDATE_Ordered"].Value.ToString() != "")
                                    PArchives.PATIENT_BIRTH = Convert.ToDateTime(dr.Cells["BIRTHDATE_Ordered"].Value.ToString());
                                PArchives.IDENTITY_CARD_NO = dr.Cells["PATSTACODE_Ordered"].Value.ToString();
                                PArchives.MAILING_ADDRESS = dr.Cells["ADDRESS_Ordered"].Value.ToString();
                                PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.iWorkList;
                                pmWorkList.PATIENT_NAME = dr.Cells["NAME_Ordered"].Value.ToString();
                                pmWorkList.PATIENT_SEX = dr.Cells["SEX_Ordered"].Value.ToString();
                                if (dr.Cells["BIRTHDATE_Ordered"].Value.ToString() != "")
                                    pmWorkList.PATIENT_BIRTH = Convert.ToDateTime(dr.Cells["BIRTHDATE_Ordered"].Value.ToString());
                                if (dr.Cells["SOURCE_Ordered"].Value.ToString() == "住院")
                                {
                                    pmWorkList.INP_NO = dr.Cells["INHOSPITALNO_Ordered"].Value.ToString();//住院号
                                }
                                else
                                {
                                    pmWorkList.OPD_NO = dr.Cells["INHOSPITALNO_Ordered"].Value.ToString();//门诊号
                                }
                                pmWorkList.BED_NUM = dr.Cells["BEDNO_Ordered"].Value.ToString();      //床号
                                pmWorkList.MAILING_ADDRESS = dr.Cells["ADDRESS_Ordered"].Value.ToString();//地址
                                pmWorkList.TELEPHONE_NUM = dr.Cells["TELEPHONE_Ordered"].Value.ToString();//电话
                                pmWorkList.PATIENT_SOURCE = dr.Cells["CLIISINPAT_Ordered"].Value.ToString(); //病人来源
                                pmWorkList.REFER_DEPT = dr.Cells["LODGESECTION_Ordered"].Value.ToString(); //申请科室
                                pmWorkList.REFER_DOCTOR = dr.Cells["LODGEDOCTOR_Ordered"].Value.ToString(); //申请医生
                                pmWorkList.CLIN_DIAG = dr.Cells["DIAGNOSIS_Ordered"].Value.ToString();    //诊断
                                pmWorkList.EXAM_NO = dr.Cells["ApplyNo_Ordered"].Value.ToString();
                                //pmWorkList.INPATIENTNO = dr.Cells["INPATIENTNO_Ordered"].Value.ToString();//记账号
                                pmWorkList.JZH = dr.Cells["INPATIENTNO_Ordered"].Value.ToString();//临床记账号 
                                pmWorkList.EXAM_CLASS = dr.Cells["EXAM_CLASS_Ordered"].Value.ToString();//检查类别
                                pmWorkList.EXAM_GROUP = dr.Cells["EXAM_GROUP_Ordered"].Value.ToString();//诊室名
                                break;
                        }

                        if (dr.Cells["CLIISINPAT_Ordered"].Value.ToString() == "2")
                            this.Mode = "11";
                        else
                            this.Mode = "01";
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }

        /// <summary>
        /// 点击“临床检查申请单”的Tab页时执行查询操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tcl_Sub_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strFilePath = Environment.CurrentDirectory ;
            try
            {
                if (this.tcl_Sub.SelectedIndex == 1)    //Tab页为“扫描申请单”调用扫描接口；这里只实现放射科的---Add at 2010-10-21
                {
                    switch (GetConfig.DALAndModel)
                    {
                        case "SIS":
                            break;
                        case "PACS":
                            PACS_Model.MWorkList smWorklist = (PACS_Model.MWorkList)this.iWorkList;
                            //启动参数：病人ID+病人本地ID+检查申请序号，如：114125,30781,RY531822
                            string strArgs = smWorklist.PATIENT_ID + "," + smWorklist.PATIENT_LOCAL_ID + "," + smWorklist.EXAM_ACCESSION_NUM;
                            System.Diagnostics.Process proc = new System.Diagnostics.Process();
                            proc.StartInfo.FileName = strFilePath + "\\RegScan\\ScanImg.exe";
                            proc.StartInfo.CreateNoWindow = true;
                            proc.StartInfo.Arguments = strArgs;
                            proc.Start();
                            break;
                    }
                }
                if (this.tcl_Sub.SelectedIndex == 2)//Tab页为“未预约申请单”
                {
                    SearchHisExamList(ref this.dgv_UnorderApplicationForm, ref this.bindingSource_HISApplicationForm, "2", "", "", "");
                    this.label_UnorderCount.Text = "共" + this.dgv_UnorderApplicationForm.RowCount.ToString() + "条记录";　　//显示查询出的记录数
                }
                if (this.tcl_Sub.SelectedIndex == 3) //Tab页为“已预约申请单”
                {
                    SearchHisExamList(ref this.dgv_OrderedApplicationForm, ref this.bindingSource_HISApplicationForm, "3", "", "", "");
                    this.label_OrderedCount.Text = "共" + this.dgv_OrderedApplicationForm.RowCount.ToString() + "条记录";　　//显示查询出的记录数
                    //设置“检查类别”和“诊室名”的下拉列表
                    if (GetConfig.DALAndModel == "SIS")
                    {
                        this.regUPE.Bind_ExamClass(this.comboBox_ExamClass_OrderedApplication, GetConfig.RM_RegisterMode);
                        this.regUPE.Bind_ExamGroup(this.comboBox_ExamGroup_OrderedApplication, this.iUser, false);
                    }
                    else if (GetConfig.DALAndModel == "PACS")//
                    {
                        PACS_Model.MUser mUser = (PACS_Model.MUser)this.iUser;
                        this.regPacs.Bind_ExamClass(mUser.DB_USER, this.comboBox_ExamClass_OrderedApplication, GetConfig.RM_RegisterMode);
                        this.regPacs.Bind_ExamGroup(this.comboBox_ExamGroup_OrderedApplication, this.iUser, false);
                    }
                    //默认不选择任何下拉项
                    this.comboBox_ExamClass_OrderedApplication.SelectedIndex = -1;
                    this.comboBox_ExamGroup_OrderedApplication.SelectedIndex = -1;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }

        //add by liukun at 2010-6-25 end 


        /// <summary>
        /// 查看检查申请单
        /// add by liukun at 2010-06-30 begin 
        /// </summary>
        /// <param name="lpFileName"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32", EntryPoint = "FreeLibrary", SetLastError = true)]
        static extern bool FreeLibrary(IntPtr hModule);

        private IntPtr hModule = IntPtr.Zero;

        //申明委托
        private delegate IntPtr HLoginProc(IntPtr aAppHandle,  IntPtr aCallWinHandle,  IntPtr aPluginHandle,
              string aBqno, string aEmpno, string aPatno, string aExeDptno );

        private Delegate GetFunctionAddress(IntPtr dllModule, string functionName, Type t)
        {
            IntPtr address = GetProcAddress(dllModule, functionName);
            if (address == IntPtr.Zero)
                return null;
            else
                return Marshal.GetDelegateForFunctionPointer(address, t);
        }

        /// <summary>
        /// 调阅HIS接口程序查看电子检查申请单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_CheckList_Click(object sender, EventArgs e)
        {
            try
            {
                SIS_Model.MWorkList smWorkList;
                PACS_Model.MWorkList pmWorkList;
                string strNo = "";
                string strExeDptNo = "";
                switch (GetConfig.DALAndModel)
                {
                    case "SIS":
                        smWorkList = (SIS_Model.MWorkList)this.iWorkList;
                        //strNo = (smWorkList.INPATIENTNO == null ? "" : smWorkList.INPATIENTNO.ToString());// 病人记账号 "875624";
                        strNo = (smWorkList.JZH == null ? "" : smWorkList.JZH.ToString());// 病人记账号 "875624";
                        strExeDptNo = (smWorkList.EXAM_DEPT == null ? "" : smWorkList.EXAM_DEPT.ToString());
                        break;
                    case "PACS":
                        pmWorkList = (PACS_Model.MWorkList)this.iWorkList;
                        //strNo = (pmWorkList.INPATIENTNO == null ? "" : pmWorkList.INPATIENTNO.ToString());// 病人记账号 "875624";
                        strNo = (pmWorkList.JZH == null ? "" : pmWorkList.JZH.ToString());// 病人记账号 "875624";
                        strExeDptNo = (pmWorkList.EXAM_DEPT == null ? "" : pmWorkList.EXAM_DEPT.ToString());
                        break;
                }
                
                if (strNo.Trim() == "")
                {
                    MessageBox.Show("无法获取患者ID，请确认操作步骤是否正确");
                    return;
                }

                try
                {
                    string strDLLPath = Environment.CurrentDirectory + "\\HuiTong\\JianChaShenQingDan\\H62AppQueryToPacs.dll";
                    hModule = LoadLibrary(strDLLPath);
                    if (hModule.Equals(IntPtr.Zero))
                    {
                        MessageBox.Show("导入DLL失败");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    FreeLibrary(hModule);
                    hModule = IntPtr.Zero;
                    return;
                }
                HLoginProc farProc = (HLoginProc)this.GetFunctionAddress(hModule, "HLoginProc", typeof(HLoginProc));
                if (farProc == null)
                {
                    FreeLibrary(hModule);
                    hModule = IntPtr.Zero;
                    return;
                }
                farProc(hModule, IntPtr.Zero, IntPtr.Zero, null, null, strNo,strExeDptNo );
                FreeLibrary(hModule);
                hModule = IntPtr.Zero;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                FreeLibrary(hModule);
                hModule = IntPtr.Zero;
                return;
            }
        }
        
        /// <summary>
        /// 设置dgv_ExamApplicationForm各列的显示顺序
        /// </summary>
        /// <param name="dgv_DataGrid_View"></param>
        private void SetDgvDisplyColomnIndex(ref DataGridView dgv_DataGrid_View)
        {
            try
            {
                switch (dgv_DataGrid_View.Name)
                {
                    case "dgv_UnorderApplicationForm":
                        dgv_DataGrid_View.Columns["ApplyNo_Unorder"].DisplayIndex = 0;
                        dgv_DataGrid_View.Columns["SOURCE_Unorder"].DisplayIndex = 1;
                        dgv_DataGrid_View.Columns["INHOSPITALNO_Unorder"].DisplayIndex = 2;
                        dgv_DataGrid_View.Columns["INPATIENTNO_Unorder"].DisplayIndex = 3;
                        dgv_DataGrid_View.Columns["NAME_Unorder"].DisplayIndex = 4;
                        dgv_DataGrid_View.Columns["SEX_Unorder"].DisplayIndex = 5;
                        dgv_DataGrid_View.Columns["BEDNO_Unorder"].DisplayIndex = 6;
                        dgv_DataGrid_View.Columns["ItemName_Unorder"].DisplayIndex = 7;
                        dgv_DataGrid_View.Columns["LODGESECTION_Unorder"].DisplayIndex = 8;
                        dgv_DataGrid_View.Columns["LODGEDOCTOR_Unorder"].DisplayIndex = 9;
                        dgv_DataGrid_View.Columns["SSYSDATE_Unorder"].DisplayIndex = 10;
                        dgv_DataGrid_View.Columns["DIAGNOSIS_Unorder"].DisplayIndex = 11;
                        dgv_DataGrid_View.Columns["PATSTACODE_Unorder"].DisplayIndex = 12;
                        dgv_DataGrid_View.Columns["TELEPHONE_Unorder"].DisplayIndex = 13;
                        dgv_DataGrid_View.Columns["PERFORMED_BY_Unorder"].DisplayIndex = 14;    
                        break;
                    case "dgv_OrderedApplicationForm":
                        dgv_DataGrid_View.Columns["ApplyNo_Ordered"].DisplayIndex = 0;
                        dgv_DataGrid_View.Columns["SOURCE_Ordered"].DisplayIndex = 1;
                        dgv_DataGrid_View.Columns["INHOSPITALNO_Ordered"].DisplayIndex = 2;
                        dgv_DataGrid_View.Columns["INPATIENTNO_Ordered"].DisplayIndex = 3;
                        dgv_DataGrid_View.Columns["NAME_Ordered"].DisplayIndex = 4;
                        dgv_DataGrid_View.Columns["SEX_Ordered"].DisplayIndex = 5;
                        dgv_DataGrid_View.Columns["BEDNO_Ordered"].DisplayIndex = 6;
                        dgv_DataGrid_View.Columns["ItemName_Ordered"].DisplayIndex = 7;
                        dgv_DataGrid_View.Columns["LODGESECTION_Ordered"].DisplayIndex = 11;
                        dgv_DataGrid_View.Columns["LODGEDOCTOR_Ordered"].DisplayIndex = 12;
                        dgv_DataGrid_View.Columns["SSYSDATE_Ordered"].DisplayIndex = 13;
                        dgv_DataGrid_View.Columns["DIAGNOSIS_Ordered"].DisplayIndex = 14;
                        dgv_DataGrid_View.Columns["PATSTACODE_Ordered"].DisplayIndex = 15;
                        dgv_DataGrid_View.Columns["TELEPHONE_Ordered"].DisplayIndex = 16;
                        dgv_DataGrid_View.Columns["PERFORMED_BY_Ordered"].DisplayIndex = 17;
                        //当显示已预约列表时，增加“预约检查类别”、“预约检查诊室”、“预约时间”两列
                        dgv_DataGrid_View.Columns["EXAM_CLASS_Ordered"].DisplayIndex = 8;
                        dgv_DataGrid_View.Columns["EXAM_CLASS_Ordered"].HeaderText = "预约检查类别";
                        dgv_DataGrid_View.Columns["EXAM_CLASS_Ordered"].Visible = true;
                        dgv_DataGrid_View.Columns["EXAM_GROUP_Ordered"].DisplayIndex = 9;
                        dgv_DataGrid_View.Columns["EXAM_GROUP_Ordered"].HeaderText = "预约检查诊室";
                        dgv_DataGrid_View.Columns["EXAM_GROUP_Ordered"].Visible = true;
                        dgv_DataGrid_View.Columns["OrderDateTime_Ordered"].DisplayIndex = 10;//预约时间
                        dgv_DataGrid_View.Columns["OrderDateTime_Ordered"].Visible = true;
                        break;
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }

        /// <summary>
        /// 查询未预约申请单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_QueryUnorderApplicationForm_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert .ToDateTime ( this.dtp_UnorderBeginDate.Text .Trim ())>Convert .ToDateTime (this.dtp_UnorderEndDate .Text.Trim ()))
                {
                    MessageBox .Show ("终止日期不能早于起始日期,请重新选择日期！");
                    return;
                }
                SearchHisExamList(ref this.dgv_UnorderApplicationForm, ref this.bindingSource_HISApplicationForm, "2", this.dtp_UnorderBeginDate.Text, this.dtp_UnorderEndDate.Text, "");
                this.label_UnorderCount.Text = "共" + this.dgv_UnorderApplicationForm.RowCount.ToString() + "条记录";　　//显示查询出的记录数
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }

        /// <summary>
        /// 查询已预约申请单  Edit at 2010-08-17
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_QueryOrderedApplicationForm_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDateTime(this.dtp_OrderedBeginDate.Text.Trim()) > Convert.ToDateTime(this.dtp_OrderedEndDate.Text.Trim()))
                {
                    MessageBox.Show("终止日期不能早于起始日期，请重新选择日期！");
                    return;
                }
                string strOthersWhere = "";
                if (this.comboBox_ExamClass_OrderedApplication.Text != null && this.comboBox_ExamClass_OrderedApplication.Text.Trim() != "")
                {
                    strOthersWhere += " and EXAM_CLASS = '" + this.comboBox_ExamClass_OrderedApplication.Text.Trim() + "'";
                }
                if (this.comboBox_ExamGroup_OrderedApplication.Text != null && this.comboBox_ExamGroup_OrderedApplication.Text.Trim() != "")
                {
                    strOthersWhere += " and EXAM_GROUP = '" + this.comboBox_ExamGroup_OrderedApplication.Text.Trim() + "'";
                }
                SearchHisExamList(ref this.dgv_OrderedApplicationForm, ref this.bindingSource_HISApplicationForm, "3", this.dtp_OrderedBeginDate.Text, this.dtp_OrderedEndDate.Text, strOthersWhere);

                //由于惠通那边的接口问题，以下对已预约申请单进行过滤　　Add at 2010-08-17
                //根据检查类别的输入，对已预约申请单进行筛选
                if (this.comboBox_ExamClass_OrderedApplication.Text != null && this.comboBox_ExamClass_OrderedApplication.Text.Trim() != "")
                {
                    MatchExamClass();
                }
                //根据诊室名的输入，对已预约申请单进行筛选
                if (this.comboBox_ExamGroup_OrderedApplication.Text != null && this.comboBox_ExamGroup_OrderedApplication.Text.Trim() != "")
                {
                    MatchExamGroup();
                }
                //根据终止日期的选择，对已预约申请单进行筛选
                MatchEndDate();
                //End at 2010-08-17

                //Add at 2010-08-26 增加一个住院号，更加简化查询
                if (this.txt_InpNo2.Text != null && this.txt_InpNo2.Text.Trim() != "")
                {
                    MatchInpNo2();
                }
                //End at 2010-08-26

                
                this.label_OrderedCount.Text = "共" + this.dgv_OrderedApplicationForm.RowCount.ToString() + "条记录";　　//显示查询出的记录数
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }

        //Add at 2010-08-17
        /// <summary>
        /// 根据检查类别的输入，对已预约申请单进行筛选
        /// </summary>
        private void MatchExamClass()
        {
            int rowIndex = 0;
            while (rowIndex != this.dgv_OrderedApplicationForm.RowCount)
            {
                if (dgv_OrderedApplicationForm.Rows[rowIndex].Cells["EXAM_CLASS_Ordered"].Value .ToString () != this.comboBox_ExamClass_OrderedApplication.Text.Trim())
                {
                    this.dgv_OrderedApplicationForm.Rows.RemoveAt(rowIndex);
                }
                else
                    rowIndex++;
            }
        }
        /// <summary>
        /// 根据诊室名的输入，对已预约申请单进行筛选
        /// </summary>
        private void MatchExamGroup()
        {
            int rowIndex = 0;
            while (rowIndex != this.dgv_OrderedApplicationForm.RowCount)
            {
                if (dgv_OrderedApplicationForm.Rows[rowIndex].Cells["EXAM_GROUP_Ordered"].Value.ToString() != this.comboBox_ExamGroup_OrderedApplication.Text.Trim())
                {
                    this.dgv_OrderedApplicationForm.Rows.RemoveAt(rowIndex);
                }
                else
                    rowIndex++;
            }
            
        }
        /// <summary>
        /// 根据终止日期的选择，对已预约申请单进行筛选
        /// </summary>
        private void MatchEndDate()
        {
            int rowIndex = 0;
            while (rowIndex != this.dgv_OrderedApplicationForm.RowCount)
            {
                if (Convert .ToDateTime ( Convert.ToDateTime(dgv_OrderedApplicationForm.Rows[rowIndex].Cells["OrderDateTime_Ordered"].Value.ToString()).ToShortDateString ()) >
                    Convert.ToDateTime(Convert.ToDateTime(dtp_OrderedEndDate.Text.Trim()).ToShortDateString()))
                {
                    this.dgv_OrderedApplicationForm.Rows.RemoveAt(rowIndex);
                }
                else
                    rowIndex++;
            }
        }
        //End at 2010-08-17

        //Add at 2010-08-26
        /// <summary>
        /// 根据住院号，进一步筛选记录
        /// </summary>
        private void MatchInpNo2()
        {
            int rowIndex = 0;
            while (rowIndex != this.dgv_OrderedApplicationForm.RowCount)
            {
                if (dgv_OrderedApplicationForm.Rows[rowIndex].Cells["INHOSPITALNO_Ordered"].Value.ToString() != this.txt_InpNo2.Text.Trim ())
                {
                    this.dgv_OrderedApplicationForm.Rows.RemoveAt(rowIndex);              
                }
                else
                    rowIndex++;
            }
        }
        //End at 2010-08-26

        /// <summary>
        /// 未预约检查申请单列表双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_UnorderApplicationForm_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.dgv_UnorderApplicationForm.SelectedRows.Count > 0)
                {
                    SelectExamAppoints(ref this.dgv_UnorderApplicationForm);  //查询由临床医生在HIS系统中开出的检查申请单
                    if(this.Mode == "01" || this.Mode == "11")
                    {
                        this.initReg.initMode2(this.iWorkList, this.Mode, this.DT_EXAM);
                    }
                    this.tcl_Sub.SelectTab(0);

                    //初始化预约注意事项 Add at 2010-08-19
                    for (int index = 0; index < this.clb_OrderNotice.Items.Count; index++)
                    {
                        this.clb_OrderNotice.SetItemChecked(index, false);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }

        /// <summary>
        /// 已预约检查申请单列表双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_OrderedApplicationForm_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.dgv_OrderedApplicationForm.SelectedRows.Count > 0)
                {
                    //add at 2010-08-19  实现连续登记
                    this.isAdd = false;
                    if (this.newReg.NewExam())
                    {
                        SetDisable(false);
                    }
                    //end at 2010-08-19

                    SelectExamAppoints(ref this.dgv_OrderedApplicationForm);  //查询由临床医生在HIS系统中开出的检查申请单
                    if (this.Mode == "01" || this.Mode == "11")
                    {
                        this.initReg.initMode2(this.iWorkList, this.Mode, this.DT_EXAM);
                    }
                    this.tcl_Sub.SelectTab(0);
                    DataGridViewRow dr = this.dgv_OrderedApplicationForm.SelectedRows[0];
                    string strNotice = dr.Cells["NOTICE_Ordered"].Value.ToString();
                    string strExamClass = dr.Cells["OrderExamClass_Ordered"].Value.ToString();
                    this.comboBox_OrderExamClass.Text = strExamClass;
                    string[] stringSeparators = new string[] { "\r\n" };
                    string[] strNoticeArray = strNotice.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string strTempNotice in strNoticeArray)
                    {
                        for (int index = 0; index < this.clb_OrderNotice.Items.Count; index++)
                        {
                            //因在保存注意事项时，在各注意事项前加上了形如：“1、”之类的编号，所以这里应截掉前面的编号。
                            if (strTempNotice.Substring(2).Trim() == this.clb_OrderNotice.GetItemText(this.clb_OrderNotice.Items[index]).ToString().Trim())
                            {
                                this.clb_OrderNotice.SetItemChecked(index, true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }

        //add by liukun at 2010-7-5 end 

        //add by liukun at 2010-7-6 begin 
        //修改记录：增加提供预约检查的注意事项功能

        /// <summary>
        /// 初始化预约检查类别/项目
        /// </summary>
        public void Init_OrderExamClass()
        {
            try
            {
                SIS_Model.MWorkList smWorkList;
                PACS_Model.MWorkList pmWorkList;
                string strExamDept = "";
                switch (GetConfig.DALAndModel)
                {
                    case "SIS":
                        smWorkList = (SIS_Model.MWorkList)this.iWorkList;
                        strExamDept = (smWorkList.EXAM_DEPT == null ? "" : smWorkList.EXAM_DEPT.ToString());    // 检查科室ID
                        break;
                    case "PACS":
                        pmWorkList = (PACS_Model.MWorkList)this.iWorkList;
                        strExamDept = (pmWorkList.EXAM_DEPT == null ? "" : pmWorkList.EXAM_DEPT.ToString());    // 检查科室ID
                        break;
                }
                System.Data.DataTable dt_OrderExamClass = new System.Data.DataTable();
                RegCls_UPE dbc = new RegCls_UPE();
                string sql = "select distinct ORDER_EXAM_CLASS from ORDER_EXAM_NOTICE where EXAM_DEPT_ID='" + strExamDept + "' and xsbz = '1' order by ORDER_EXAM_CLASS ";
                dt_OrderExamClass = dbc.GetDataSet(sql).Tables[0];
                comboBox_OrderExamClass.DataSource = dt_OrderExamClass;
                comboBox_OrderExamClass.DisplayMember = dt_OrderExamClass.Columns["ORDER_EXAM_CLASS"].ColumnName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }

        /// <summary>
        /// 预约检查类别/项目改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_OrderExamClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SIS_Model.MWorkList smWorkList;
                PACS_Model.MWorkList pmWorkList;
                string strExamDept = "";
                switch (GetConfig.DALAndModel)
                {
                    case "SIS":
                        smWorkList = (SIS_Model.MWorkList)this.iWorkList;
                        strExamDept = (smWorkList.EXAM_DEPT == null ? "" : smWorkList.EXAM_DEPT.ToString());    // 检查科室ID
                        break;
                    case "PACS":
                        pmWorkList = (PACS_Model.MWorkList)this.iWorkList;
                        strExamDept = (pmWorkList.EXAM_DEPT == null ? "" : pmWorkList.EXAM_DEPT.ToString());    // 检查科室ID
                        break;
                }
                System.Data.DataTable dt_OrderExamClass = new System.Data.DataTable();
                RegCls_UPE dbc = new RegCls_UPE();
                string sql = "select distinct EXAM_NOTICE,XSSX from ORDER_EXAM_NOTICE where EXAM_DEPT_ID='" + strExamDept + "' and ORDER_EXAM_CLASS = '" + this.comboBox_OrderExamClass.Text.ToString().Trim() + "' and xsbz = '1' order by xssx ";
                dt_OrderExamClass = dbc.GetDataSet(sql).Tables[0];
                clb_OrderNotice.DataSource = dt_OrderExamClass;
                clb_OrderNotice.DisplayMember = dt_OrderExamClass.Columns["EXAM_NOTICE"].ColumnName;
                //取消所有项目的选中状态
                this.clb_OrderNotice.ClearSelected();
                for (int index = 0; index < this.clb_OrderNotice.Items.Count; index++)
                {
                    this.clb_OrderNotice.SetItemChecked(index, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }

        /// <summary>
        /// 调用HIS接口程序更新申请单状态:3：已预约未报到；4：已报到登记；5：已检查完成
        /// </summary>
        /// <param name="aStatus"></param>
        /// <returns></returns>
        private bool UpdateApplyStatus(string strStatus)
        {
            try
            {
                string strSource = "";
                string strApplyNo = "";
                if (GetConfig.DALAndModel == "SIS")
                {
                    SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.iWorkList;
                    strSource = smWorkList.PATIENT_SOURCE;
                    strApplyNo = smWorkList.EXAM_NO;
                }
                else if (GetConfig.DALAndModel == "PACS")
                {
                    PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.iWorkList;
                    strSource = pmWorkList.PATIENT_SOURCE;
                    strApplyNo = pmWorkList.EXAM_NO;
                }
                if (strApplyNo.Trim() == "")     //如果申请单号为空，则直接返回，不进行下面的处理，以提高效率
                {
                    return false;
                }
                OracleParameter[] parms = new OracleParameter[4];
                parms[0] = new OracleParameter("aSource", OracleType.VarChar);
                parms[1] = new OracleParameter("aApplyNo", OracleType.VarChar);
                parms[2] = new OracleParameter("aStatus", OracleType.VarChar);
                parms[3] = new OracleParameter("aResult", OracleType.VarChar,20);
                parms[0].Direction = ParameterDirection.Input;
                parms[0].Value = strSource;
                parms[1].Direction = ParameterDirection.Input;
                parms[1].Value = strApplyNo;
                parms[2].Direction = ParameterDirection.Input;
                parms[2].Value = strStatus;
                parms[3].Direction = ParameterDirection.Output;
                ExecuteProcedure("HIS", "H6JGETJCAPPLY.UpdateApplyStatus", parms);
                if (parms[3].Value.ToString() != "1")
                {
                    MessageBox.Show("更新申请单状态失败");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }

        /// <summary>
        /// 初始化预约时间段
        /// </summary>
        private void Init_Yuyueshijianduan()
        {
            string strYYSJD = "";
            DateTime dt = Convert.ToDateTime("08:00");//中医院从早上8:00开始上班
            //超声科的预约时间段以每半小时(30分钟)为预约单位
            if (GetConfig.DALAndModel == "SIS")
            {
                for (; dt < Convert.ToDateTime("11:30");)
                {
                    strYYSJD += dt.Hour.ToString("#00") + ":" + dt.Minute.ToString("#00") + " - " + dt.AddMinutes(30).Hour.ToString("#00") + ":" + dt.AddMinutes(30).Minute.ToString("#00") + "\r\n";
                    dt = dt.AddMinutes(30);
                }
                dt = Convert.ToDateTime("14:30");
                for (; dt < Convert.ToDateTime("16:30"); )
                {
                    strYYSJD += dt.Hour.ToString("#00") + ":" + dt.Minute.ToString("#00") + " - " + dt.AddMinutes(30).Hour.ToString("#00") + ":" + dt.AddMinutes(30).Minute.ToString("#00") + "\r\n";
                    dt = dt.AddMinutes(30);
                }
            }
            //放射科的预约时间段以每1小时(60分钟)为预约单位
            else if (GetConfig.DALAndModel == "PACS")
            {
                dt = Convert.ToDateTime("08:30");//放射科的要求为8:30开始
                for (; dt < Convert.ToDateTime("9:00"); )
                {
                    strYYSJD += dt.Hour.ToString("#00") + ":" + dt.Minute.ToString("#00") + " - " + dt.AddMinutes(30).Hour.ToString("#00") + ":" + dt.AddMinutes(30).Minute.ToString("#00") + "\r\n";
                    dt = dt.AddMinutes(30);
                }
                for (; dt < Convert.ToDateTime("12:00"); )
                {
                    strYYSJD += dt.Hour.ToString("#00") + ":" + dt.Minute.ToString("#00") + " - " + dt.AddMinutes(60).Hour.ToString("#00") + ":" + dt.AddMinutes(60).Minute.ToString("#00") + "\r\n";
                    dt = dt.AddMinutes(60);
                }
                dt = Convert.ToDateTime("14:30");
                for (; dt < Convert.ToDateTime("17:30"); )
                {
                    strYYSJD += dt.Hour.ToString("#00") + ":" + dt.Minute.ToString("#00") + " - " + dt.AddMinutes(60).Hour.ToString("#00") + ":" + dt.AddMinutes(60).Minute.ToString("#00") + "\r\n";
                    dt = dt.AddMinutes(60);
                }
            }
            string[] stringSeparators = new string[] { "\r\n" };
            string[] strSJDArray = strYYSJD.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            comboBox_yyqzsjd.Items.AddRange(strSJDArray);
        }

        /// <summary>
        /// 已预约申请单住院号回车查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_InpNo2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                button_QueryOrderedApplicationForm_Click(null, null);
        }

        /// <summary>
        /// 手工删除未预约申请单，同时刷新当前未预约申请单列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_DelUnorder_Click(object sender, EventArgs e)
        {
            if (dgv_UnorderApplicationForm.SelectedRows.Count == 0)
            {
                MessageBoxEx.Show("未选中未预约申请单记录！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if ((MessageBoxEx.Show("是否删除该未预约申请单？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.No)
                    return;
                else
                {
                    try
                    {
                        //删除，通过回写HIS数据库，使之状态从2直接到4，即尚未预约就假登记
                        SelectExamAppoints(ref dgv_UnorderApplicationForm);
                        UpdateApplyStatus("4");
                        //刷新列表，执行存储过程
                        button_QueryUnorderApplicationForm_Click(null, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBoxEx.Show("删除失败！\n" + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 手工删除已预约申请单,同时刷新当前已预约申请单列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_DelOrder_Click(object sender, EventArgs e)
        {
            if (dgv_OrderedApplicationForm.SelectedRows.Count == 0)
            {
                MessageBoxEx.Show("未选中已预约申请单记录！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if ((MessageBoxEx.Show("是否删除该已预约申请单？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.No)
                    return;
                else
                {
                    try
                    {
                        //删除，通过回写HIS数据库表，使之状态从3到4，即假登记
                        SelectExamAppoints(ref dgv_OrderedApplicationForm);
                        UpdateApplyStatus("4");
                        //刷新列表，执行查询按钮操作
                        button_QueryOrderedApplicationForm_Click(null, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBoxEx.Show("删除失败！\n" + ex.Message);
                    }
                }
            }
        }

    }
}