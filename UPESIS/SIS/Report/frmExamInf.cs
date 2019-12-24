using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SIS_Model;
using SIS.Function;
using ILL;
using SIS.RegisterCls;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace SIS
{
    public partial class frmExamInf : BaseControls.Docking.DockContent
    {
        public MWorkList mworklist;
        private MArchives mArchives;
        public MReport mrpt;
        private WordClass word;
        private BindData bd;
        private ComputeCharge computeCharge;
        private LocalIdCreater localIdCreater;
        private RegCls_Pacs regPacs;
        private RegCls_UPE regUPE;
        private RegCls_JW regJW;
        private RegCls_HT regHT;
        private bool isInit = false;
        private System.Data.DataTable dt_ExamItems;
        private System.Data.DataTable dt_ReferDept;
        private string[] Exam_Class = GetConfig.RM_DefaultExamClass.Split(',');
        private string[] Exam_Sub_Class = GetConfig.RM_DefaultExamSubClass.Split(',');
        public Panel panel;

        public frmExamInf()
        {
            InitializeComponent();
            regHT = new RegCls_HT();
            regJW = new RegCls_JW();
            regPacs = new RegCls_Pacs();
            regUPE = new RegCls_UPE();
            computeCharge = new ComputeCharge();
            localIdCreater = new LocalIdCreater();
            dt_ExamItems = new System.Data.DataTable();
            dt_ReferDept = new System.Data.DataTable();
            this.BindData();
        }

        #region 初始化

        public void init(MWorkList mWorkList, MReport mReport, WordClass word)
        {
            this.mworklist = mWorkList;
            this.mrpt = mReport;
            this.word = word;
            computeCharge.Init();
            this.SetData();
        }

        private void BindData()
        {
            this.isInit = true;
            bd = new SIS.RegisterCls.BindData();
            bd.BindExamClass(this.cmb_ExamClass, 0);
            bd.BindPatientSource(this.cmb_PatientSource);
            bd.BindReferDept(this.cmb_ReferDept);
            bd.BindChargeType(this.cmb_ChargeType);
            bd.BindExamGroup(this.cmb_ExamGroup);
            bd.BindExamDoctor(GetConfig.ExamDeptCode, this.cmb_Transcriber);
            regUPE.Bind_ImgEquipment(this.cmb_ImgEquipment, frmMainForm.iUser);
            this.computeCharge.DT_VS = bd.BindExamVsCharge();
            this.isInit = false;
        }

        private void SetData()
        {
            this.isInit = true;
            this.mArchives = (MArchives)this.regUPE.GetArchives(mworklist.PATIENT_ID);
            this.txt_BedNum.Text = mworklist.BED_NUM;
            this.txt_ClinDiag.Text = mworklist.CLIN_DIAG;
            this.txt_ClinSymp.Text = this.mworklist.CLIN_SYMP;
            this.txt_InpNo.Text = this.mworklist.INP_NO;
            this.txt_OpdNo.Text = this.mworklist.OPD_NO;
            this.txt_PatientAge.Text = this.mworklist.PATIENT_AGE.ToString();
            this.cmb_AgeUnit.Text = this.mworklist.PATIENT_AGE_UNIT;
            this.cmb_Sex.Text = this.mworklist.PATIENT_SEX;
            this.txt_Costs.Text = this.mworklist.COSTS.ToString();
            this.txt_Charges.Text = this.mworklist.CHARGES.ToString();
            this.txt_PatientId.Text = this.mworklist.PATIENT_ID;
            this.txt_PatientName.Text = this.mworklist.PATIENT_NAME;
            this.txt_PhysSign.Text = this.mworklist.PHYS_SIGN;
            this.txt_RelevantDiag.Text = this.mworklist.RELEVANT_DIAG;
            this.txt_RelevantLabTest.Text = this.mworklist.RELEVANT_LAB_TEST;
            this.txt_ReqMemo.Text = this.mworklist.REQ_MEMO;
            this.txt_TelephoneNum.Text = this.mworklist.TELEPHONE_NUM;
            this.dud_PatientLocalId.Text = this.mworklist.PATIENT_LOCAL_ID;

            this.cmb_ReferDept.SelectedValue = mworklist.REFER_DEPT == null ? "" : mworklist.REFER_DEPT;
            this.cmb_ReferDept.Text = mworklist.REQ_DEPT_NAME;
            bd.BindReferDoctor(mworklist.REFER_DEPT, this.cmb_ReferDoctor);
            CtlComboBox.SetDisplay(mworklist.REFER_DOCTOR, this.cmb_ReferDoctor);    //申请医生
            CtlComboBox.SetValue(mworklist.CHARGE_TYPE.ToString(), this.cmb_ChargeType);        //费别
            this.GetRegChargeRatio(mworklist.CHARGE_TYPE);
            CtlComboBox.SetValue(mworklist.PATIENT_SOURCE, this.cmb_PatientSource);  //病人来源
            CtlComboBox.SetDisplay(mworklist.EXAM_CLASS, this.cmb_ExamClass);        //检查类别
            bd.BindExamSubClass(mworklist.EXAM_CLASS, this.cmb_ExamSubClass);        //绑定子类
            CtlComboBox.SetDisplay(mworklist.EXAM_SUB_CLASS, this.cmb_ExamSubClass); //检查子类
            bd.BindExamItems(mworklist.EXAM_CLASS, mworklist.EXAM_SUB_CLASS, this.cmb_ExamItems);

            CtlComboBox.SetDisplay(mworklist.DEVICE, this.cmb_ImgEquipment);         //检查设备
            CtlComboBox.SetDisplay(mworklist.EXAM_GROUP, this.cmb_ExamGroup);        //检查组

            if (mworklist.IS_INQUIRY == null)
                this.cb_IsInquiry.Checked = false;
            else
                this.cb_IsInquiry.Checked = mworklist.IS_INQUIRY == 0 ? false : true;

            if (mrpt.IS_ABNORMAL == null)
            {
                switch (GetConfig.DefaultAbnormal)
                {
                    case 0:
                        this.rb_NoAbnormal.Checked = true;
                        break;
                    case 1:
                        this.rb_Abnormal.Checked = true;
                        break;
                    default:
                        this.rb_NoAbnormal.Checked = this.rb_Abnormal.Checked = false;
                        break;
                }
            }
            else
            {
                if (mrpt.IS_ABNORMAL == 0)
                {
                    this.rb_NoAbnormal.Checked = true;
                }
                else
                {
                    this.rb_Abnormal.Checked = true;
                }
            }

            if (mrpt.TRANSCRIBER == null)
                this.cmb_Transcriber.Text = ((MUser)frmMainForm.iUser).DOCTOR_NAME;
            else
                CtlComboBox.SetDisplay(mrpt.TRANSCRIBER, this.cmb_Transcriber);          //报告医生 
            if (this.mrpt.REPORT_DATE_TIME == null)
                this.txt_ReportDateTime.Text = System.DateTime.Now.ToString();
            else
                this.txt_ReportDateTime.Text = this.mrpt.REPORT_DATE_TIME.ToString();

            this.SetExamItems();
            this.GetReqScanImages(this.mworklist.EXAM_ACCESSION_NUM);
            this.cmb_ExamItems.Text = "";
            this.isInit = false;
        }

        private void SetExamItems()
        {
            this.lv_ExamItem.Items.Clear();
            System.Data.DataTable dt_ExamChargeList = new System.Data.DataTable();
            System.Data.DataTable dt_ExamItems = this.GetExamItems(this.mworklist.EXAM_ACCESSION_NUM, ref dt_ExamChargeList);
            this.computeCharge.Now_DT_VS_Old = dt_ExamChargeList;
            if (dt_ExamItems.Rows.Count > 0)
            {
                for (int j = 0; j < dt_ExamItems.Rows.Count; j++)
                {
                    System.Data.DataView dv = this.computeCharge.Now_DT_VS_Old.DefaultView;
                    dv.RowFilter = " EXAM_ITEM_CODE = '" + dt_ExamItems.Rows[j]["EXAM_ITEM_CODE"].ToString() + "' and EXAM_ITEM_NO = " + dt_ExamItems.Rows[j]["EXAM_ITEM_NO"].ToString();
                    this.computeCharge.Now_DT_VS_Group.Add(dv.ToTable());
                }
               // InitExamItemsList(m);
            }
                InitExamItemsList(mworklist.EXAM_ITEMS);//初始化所有检查项目到项目列表中
        }

        /// <summary>
        /// 编辑时初始化检查项目表
        /// </summary>
        private void InitExamItemsList(string items)
        {
            string[] Items = items.TrimEnd(';').Split(';');
            for (int i = 0; i < Items.Length; i++)
            {
                this.AddExamItemList(Items[i],false);
            }
            this.txt_Charges.Text = this.mworklist.CHARGES.ToString();
            this.txt_Costs.Text = this.mworklist.COSTS.ToString();
        }
        private System.Data.DataTable GetExamItems(string ExamAccessionNum, ref System.Data.DataTable dt_ExamChargeList)
        {
            System.Data.DataTable dt_ExamItems = new System.Data.DataTable();
            dt_ExamItems = this.regUPE.GetExamItems(ExamAccessionNum);
            dt_ExamChargeList = this.regUPE.GetExamChargeList(ExamAccessionNum);
            this.lv_ExamItem.BeginUpdate();
            System.Data.DataSet ds = new System.Data.DataSet();
            for (int i = 0; i < dt_ExamItems.Rows.Count; i++)
            {
                string[] lvitem = new string[3];
                lvitem[0] = dt_ExamItems.Rows[i]["EXAM_ITEM"].ToString();
                decimal ItemCosts = 0;
                System.Data.DataRow[] drs = dt_ExamChargeList.Select("EXAM_ITEM_CODE = '" + dt_ExamItems.Rows[i]["EXAM_ITEM_CODE"].ToString() + "' and EXAM_ITEM_NO = " + dt_ExamItems.Rows[i]["EXAM_ITEM_NO"].ToString());
                for (int j = 0; j < drs.Length; j++)
                {
                    string price = drs[j]["PRICE"].ToString();
                    string Amount = (drs[j]["AMOUNT"].ToString() == "") ? "0" : drs[j]["AMOUNT"].ToString();
                    ItemCosts += Convert.ToDecimal(price) * Convert.ToDecimal(Amount);
                }
                decimal ItemCharges = ItemCosts * this.computeCharge.chargeRatio;
                lvitem[1] = ItemCosts.ToString();
                lvitem[2] = ItemCharges.ToString();
                ListViewItem lvi = new ListViewItem(lvitem);
                this.lv_ExamItem.Items.Add(lvi);
            }
            this.lv_ExamItem.EndUpdate();
            return dt_ExamItems;
        }

        private void GetReqScanImages(string ExamAccessionNum)
        {
            SIS_BLL.BReqScanImage bReqScanImage = new SIS_BLL.BReqScanImage();
            System.Data.DataTable dt_ReqScanImage = bReqScanImage.GetList(" EXAM_NO = '" + ExamAccessionNum + "'");
            FileOperator fileOpe = new FileOperator();
            string dir = Application.StartupPath + "//ScanImages//";
            for (int i = 0; i < dt_ReqScanImage.Rows.Count; i++)
            {
                fileOpe.FileSave((byte[])dt_ReqScanImage.Rows[i]["IMAGE_FILE"], dir + dt_ReqScanImage.Rows[i]["IMAGE_INDEX"].ToString() + ".bmp");
            }
        }

        public void AddExamItemList(string itemName,bool isAdd)
        {
            for (int i = 0; i < lv_ExamItem.Items.Count; i++)
            {
                if (lv_ExamItem.Items[i].SubItems[0].Text.Trim() == itemName)
                    return;
            }
            this.lv_ExamItem.BeginUpdate();
            string[] lvitem = new string[3];
            lvitem[0] = itemName;
            lvitem[1] = this.computeCharge.ItemCosts.ToString();
            lvitem[2] = this.computeCharge.ItemCharges.ToString();
            ListViewItem lvi = new ListViewItem(lvitem);
            this.lv_ExamItem.Items.Add(lvi);
            this.lv_ExamItem.EndUpdate();
            if (isAdd)
                this.mworklist.EXAM_ITEMS += this.cmb_ExamItems.Text + ";";
            this.computeCharge.GetCostsCharges();
            this.txt_Charges.Text = this.computeCharge.charges.ToString();
            this.txt_Costs.Text = this.computeCharge.costs.ToString();
            this.cmb_ExamItems.Text = "";
        }
        private void btn_AddExamItem_Click(object sender, EventArgs e)
        {
            if (cmb_ExamItems.Text.Trim() != "")
            {
                AddExamItemList(this.cmb_ExamItems.Text, true);
            }
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
            {
                mArchives.CHARGE_CLASS = ChargeType;
                this.computeCharge.chargeRatio = this.regUPE.GetChargeRatio(ChargeType.ToString());
            }

        }

        #endregion

        #region 调整界面

        private void frmExamInf_DockStateChanged(object sender, EventArgs e)
        {
            panel.BringToFront();
            switch (this.DockState)
            {
                case BaseControls.Docking.DockState.DockBottom:
                    this.SetCtlToHorizontal();
                    break;
                case BaseControls.Docking.DockState.DockBottomAutoHide:
                    this.SetCtlToHorizontal();
                    break;
                case BaseControls.Docking.DockState.DockLeft:
                    this.SetCtlToVertical();
                    break;
                case BaseControls.Docking.DockState.DockLeftAutoHide:
                    this.SetCtlToVertical();
                    break;
                case BaseControls.Docking.DockState.DockRight:
                    this.SetCtlToVertical();
                    break;
                case BaseControls.Docking.DockState.DockRightAutoHide:
                    this.SetCtlToVertical();
                    break;
                case BaseControls.Docking.DockState.DockTop:
                    this.SetCtlToHorizontal();
                    break;
                case BaseControls.Docking.DockState.DockTopAutoHide:
                    this.SetCtlToHorizontal();
                    break;
                case BaseControls.Docking.DockState.Float:
                    this.SetCtlToVertical();
                    break;
            }
        }
        /// <summary>
        /// 竖排
        /// </summary>
        private void SetCtlToVertical()
        {
            this.btn_AddExamItem.Location = new Point(197, 280);

            this.cmb_AgeUnit.Location = new System.Drawing.Point(174, 63);
            this.cmb_AgeUnit.Size = new System.Drawing.Size(39, 20);

            this.cmb_ExamSubClass.Location = new System.Drawing.Point(77, 249);
            this.cmb_ExamSubClass.Size = new System.Drawing.Size(136, 20);

            this.cmb_ExamClass.Location = new System.Drawing.Point(77, 218);
            this.cmb_ExamClass.Size = new System.Drawing.Size(136, 20);

            this.cmb_PatientSource.Location = new System.Drawing.Point(77, 94);
            this.cmb_PatientSource.Size = new System.Drawing.Size(136, 20);

            this.cmb_Sex.Location = new System.Drawing.Point(77, 63);
            this.cmb_Sex.Size = new System.Drawing.Size(38, 20);

            this.cmb_Transcriber.Location = new System.Drawing.Point(77, 520);
            this.cmb_Transcriber.Size = new System.Drawing.Size(136, 20);

            this.lv_ExamItem.Location = new System.Drawing.Point(15, 313);
            this.lv_ExamItem.Size = new System.Drawing.Size(198, 101);

            this.cmb_ExamItems.Location = new System.Drawing.Point(77, 280);
            this.cmb_ExamItems.Size = new System.Drawing.Size(118, 20);

            this.txt_Costs.Location = new System.Drawing.Point(77, 430);
            this.txt_Costs.Size = new System.Drawing.Size(136, 21);

            this.label26.Location = new System.Drawing.Point(13, 433);
            this.label26.Size = new System.Drawing.Size(53, 12);

            this.cmb_ReferDoctor.Location = new System.Drawing.Point(77, 187);
            this.cmb_ReferDoctor.Size = new System.Drawing.Size(136, 20);

            this.rb_Abnormal.Location = new System.Drawing.Point(81, 485);
            this.rb_Abnormal.Size = new System.Drawing.Size(47, 16);

            this.cmb_ReferDept.Location = new System.Drawing.Point(77, 156);
            this.cmb_ReferDept.Size = new System.Drawing.Size(136, 20);

            this.rb_NoAbnormal.Location = new System.Drawing.Point(25, 485);
            this.rb_NoAbnormal.Size = new System.Drawing.Size(47, 16);

            this.txt_PatientAge.Location = new System.Drawing.Point(148, 62);
            this.txt_PatientAge.Size = new System.Drawing.Size(25, 21);

            this.txt_PatientName.Location = new System.Drawing.Point(77, 32);
            this.txt_PatientName.Size = new System.Drawing.Size(136, 21);

            this.cb_IsInquiry.Location = new System.Drawing.Point(135, 485);
            this.cb_IsInquiry.Size = new System.Drawing.Size(72, 16);

            this.myLabel4.Location = new System.Drawing.Point(13, 523);
            this.myLabel4.Size = new System.Drawing.Size(53, 12);

            this.txt_ReportDateTime.Location = new System.Drawing.Point(77, 554);
            this.txt_ReportDateTime.Size = new System.Drawing.Size(136, 21);

            this.txt_InpNo.Location = new System.Drawing.Point(77, 125);
            this.txt_InpNo.Size = new System.Drawing.Size(66, 21);

            this.txt_BedNum.Location = new System.Drawing.Point(175, 125);
            this.txt_BedNum.Size = new System.Drawing.Size(38, 21);

            this.myLabel2.Location = new System.Drawing.Point(13, 557);
            this.myLabel2.Size = new System.Drawing.Size(53, 12);

            this.myLabel14.Location = new System.Drawing.Point(13, 66);
            this.myLabel14.Size = new System.Drawing.Size(53, 12);

            this.myLabel8.Location = new System.Drawing.Point(146, 128);
            this.myLabel8.Size = new System.Drawing.Size(29, 12);

            this.myLabel6.Location = new System.Drawing.Point(120, 66);
            this.myLabel6.Size = new System.Drawing.Size(29, 12);

            this.myLabel5.Location = new System.Drawing.Point(13, 35);
            this.myLabel5.Size = new System.Drawing.Size(53, 12);

            this.label47.Location = new System.Drawing.Point(13, 159);
            this.label47.Size = new System.Drawing.Size(53, 12);

            this.label48.Location = new System.Drawing.Point(13, 190);
            this.label48.Size = new System.Drawing.Size(53, 12);

            this.myLabel11.Location = new System.Drawing.Point(13, 283);
            this.myLabel11.Size = new System.Drawing.Size(53, 12);

            this.myLabel7.Location = new System.Drawing.Point(13, 128);
            this.myLabel7.Size = new System.Drawing.Size(53, 12);

            this.myLabel10.Location = new System.Drawing.Point(13, 252);
            this.myLabel10.Size = new System.Drawing.Size(53, 12);

            this.myLabel9.Location = new System.Drawing.Point(13, 97);
            this.myLabel9.Size = new System.Drawing.Size(53, 12);

            this.myLabel13.Location = new System.Drawing.Point(13, 221);
            this.myLabel13.Size = new System.Drawing.Size(53, 12);

            this.gb_ClinicInf.Location = new System.Drawing.Point(3, 397);
            this.gb_ClinicInf.Size = new System.Drawing.Size(226, 221);

            this.label38.Location = new System.Drawing.Point(11, 132);
            this.label38.Size = new System.Drawing.Size(53, 12);
            this.label38.Text = "临床诊断";

            this.txt_ClinDiag.Location = new System.Drawing.Point(13, 148);
            this.txt_ClinDiag.Size = new System.Drawing.Size(197, 65);

            this.label34.Location = new System.Drawing.Point(11, 79);
            this.label34.Size = new System.Drawing.Size(53, 12);
            this.label34.Text = "临床症状";

            this.txt_ClinSymp.Location = new System.Drawing.Point(13, 95);
            this.txt_ClinSymp.Size = new System.Drawing.Size(197, 33);

            this.label40.Location = new System.Drawing.Point(11, 25);
            this.label40.Size = new System.Drawing.Size(29, 12);
            this.label40.Text = "体征";

            this.txt_PhysSign.Location = new System.Drawing.Point(13, 41);
            this.txt_PhysSign.Size = new System.Drawing.Size(197, 34);

            this.gb_TestInf.Location = new System.Drawing.Point(3, 188);
            this.gb_TestInf.Size = new System.Drawing.Size(226, 209);

            this.txt_ReqMemo.Location = new System.Drawing.Point(13, 161);
            this.txt_ReqMemo.Size = new System.Drawing.Size(197, 42);

            this.label35.Location = new System.Drawing.Point(11, 145);
            this.label35.Size = new System.Drawing.Size(53, 12);
            this.label35.Text = "申请备注";

            this.txt_RelevantDiag.Location = new System.Drawing.Point(13, 100);
            this.txt_RelevantDiag.Size = new System.Drawing.Size(197, 41);

            this.label33.Location = new System.Drawing.Point(11, 84);
            this.label33.Size = new System.Drawing.Size(53, 12);
            this.label33.Text = "其他诊断";

            this.txt_RelevantLabTest.Location = new System.Drawing.Point(13, 41);
            this.txt_RelevantLabTest.Size = new System.Drawing.Size(197, 39);

            this.label32.Location = new System.Drawing.Point(11, 25);
            this.label32.Size = new System.Drawing.Size(53, 12);
            this.label32.Text = "相关化验";

            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Size = new System.Drawing.Size(226, 185);

            this.cmb_ExamGroup.Location = new System.Drawing.Point(92, 67);
            this.cmb_ExamGroup.Size = new System.Drawing.Size(109, 20);

            this.label4.Location = new System.Drawing.Point(21, 70);
            this.label4.Size = new System.Drawing.Size(53, 12);

            this.label23.Location = new System.Drawing.Point(21, 154);
            this.label23.Size = new System.Drawing.Size(53, 12);

            

            this.cmb_ImgEquipment.Location = new System.Drawing.Point(92, 39);
            this.cmb_ImgEquipment.Size = new System.Drawing.Size(109, 20);

            this.txt_PatientId.Location = new System.Drawing.Point(92, 11);
            this.txt_PatientId.Size = new System.Drawing.Size(109, 21);

            this.txt_TelephoneNum.Location = new System.Drawing.Point(92, 151);
            this.txt_TelephoneNum.Size = new System.Drawing.Size(109, 21);

            this.txt_OpdNo.Location = new System.Drawing.Point(92, 123);
            this.txt_OpdNo.Size = new System.Drawing.Size(109, 21);

            this.myLabel15.Location = new System.Drawing.Point(21, 14);
            this.myLabel15.Size = new System.Drawing.Size(41, 12);

            this.label45.Location = new System.Drawing.Point(13, 463);
            this.label45.Size = new System.Drawing.Size(53, 12);
            this.dud_PatientLocalId.Location = new System.Drawing.Point(77, 460);
            this.dud_PatientLocalId.Size = new System.Drawing.Size(136, 21);
            this.label42.Location = new System.Drawing.Point(21, 42);
            this.label42.Size = new System.Drawing.Size(53, 12);

            this.myLabel1.Location = new System.Drawing.Point(21, 126);
            this.myLabel1.Size = new System.Drawing.Size(53, 12);
        }
        /// <summary>
        /// 横排
        /// </summary>
        private void SetCtlToHorizontal()
        {
            this.btn_AddExamItem.Location = new Point(585,73);

            this.txt_Costs.Size = new System.Drawing.Size(55, 21);
            this.txt_Costs.Location = new System.Drawing.Point(227, 97);
            this.txt_Costs.Size = new System.Drawing.Size(55, 21);

            this.label26.Location = new System.Drawing.Point(171, 101);
            this.label26.Size = new System.Drawing.Size(53, 12);

            this.txt_Charges.Location = new System.Drawing.Point(279, -5);
            this.txt_Charges.Size = new System.Drawing.Size(62, 21);

            this.label27.Location = new System.Drawing.Point(220, -2);
            this.label27.Size = new System.Drawing.Size(59, 12);

            this.cmb_ChargeType.Location = new System.Drawing.Point(71, -5);
            this.cmb_ChargeType.Size = new System.Drawing.Size(141, 20);

            this.label49.Location = new System.Drawing.Point(10, -2);
            this.label49.Size = new System.Drawing.Size(59, 12);

            this.cmb_AgeUnit.Location = new System.Drawing.Point(351, 16);
            this.cmb_AgeUnit.Size = new System.Drawing.Size(39, 20);

            this.cmb_ExamSubClass.Location = new System.Drawing.Point(227, 72);
            this.cmb_ExamSubClass.Size = new System.Drawing.Size(89, 20);

            this.cmb_ExamClass.Location = new System.Drawing.Point(72, 70);
            this.cmb_ExamClass.Size = new System.Drawing.Size(89, 20);

            this.cmb_PatientSource.Location = new System.Drawing.Point(72, 43);
            this.cmb_PatientSource.Size = new System.Drawing.Size(89, 20);

            this.cmb_Sex.Location = new System.Drawing.Point(227, 15);
            this.cmb_Sex.Size = new System.Drawing.Size(55, 20);

            this.cmb_Transcriber.Location = new System.Drawing.Point(72, 124);
            this.cmb_Transcriber.Size = new System.Drawing.Size(89, 20);

            this.lv_ExamItem.Location = new System.Drawing.Point(330, 93);
            this.lv_ExamItem.Size = new System.Drawing.Size(269, 77);

            this.cmb_ExamItems.Location = new System.Drawing.Point(382, 72);
            this.cmb_ExamItems.Size = new System.Drawing.Size(201, 20);

            this.cmb_ReferDoctor.Location = new System.Drawing.Point(382, 43);
            this.cmb_ReferDoctor.Size = new System.Drawing.Size(70, 20);

            //modify by liukun at 2010-6-22 begin 
            //修改记录：应用户要求将“随访标志”放置于“阴性”“阳性”后面
            //this.rb_Abnormal.Location = new System.Drawing.Point(495, 46);
            //this.rb_Abnormal.Size = new System.Drawing.Size(47, 16);
            this.rb_Abnormal.Location = new System.Drawing.Point(505, 46);
            this.rb_Abnormal.Size = new System.Drawing.Size(45, 16);

            this.cmb_ReferDept.Location = new System.Drawing.Point(227, 43);
            this.cmb_ReferDept.Size = new System.Drawing.Size(89, 20);

            //this.rb_NoAbnormal.Location = new System.Drawing.Point(551, 46);
            //this.rb_NoAbnormal.Size = new System.Drawing.Size(47, 16);
            this.rb_NoAbnormal.Location = new System.Drawing.Point(455, 46);
            this.rb_NoAbnormal.Size = new System.Drawing.Size(45, 16);

            this.txt_PatientAge.Location = new System.Drawing.Point(325, 16);
            this.txt_PatientAge.Size = new System.Drawing.Size(25, 21);

            this.txt_PatientName.Location = new System.Drawing.Point(72, 15);
            this.txt_PatientName.Size = new System.Drawing.Size(89, 21);

            //this.cb_IsInquiry.Location = new System.Drawing.Point(227, 154);
            //this.cb_IsInquiry.Size = new System.Drawing.Size(72, 16);
            this.cb_IsInquiry.Location = new System.Drawing.Point(555, 46);
            this.cb_IsInquiry.Size = new System.Drawing.Size(48, 16);
            //modify by liukun at 2010-6-22 end 

            this.myLabel4.Location = new System.Drawing.Point(16, 127);
            this.myLabel4.Size = new System.Drawing.Size(53, 12);

            this.txt_ReportDateTime.Location = new System.Drawing.Point(227, 124);
            this.txt_ReportDateTime.Size = new System.Drawing.Size(89, 21);

            this.txt_InpNo.Location = new System.Drawing.Point(463, 16);
            this.txt_InpNo.Size = new System.Drawing.Size(66, 21);

            this.txt_BedNum.Location = new System.Drawing.Point(561, 16);
            this.txt_BedNum.Size = new System.Drawing.Size(38, 21);

            this.myLabel2.Location = new System.Drawing.Point(171, 127);
            this.myLabel2.Size = new System.Drawing.Size(53, 12);

            this.myLabel14.Location = new System.Drawing.Point(171, 19);

            this.myLabel14.Size = new System.Drawing.Size(53, 12);

            this.myLabel8.Location = new System.Drawing.Point(535, 19);
            this.myLabel8.Size = new System.Drawing.Size(29, 12);
            this.myLabel6.Location = new System.Drawing.Point(297, 19);
            this.myLabel6.Size = new System.Drawing.Size(29, 12);

            this.myLabel5.Location = new System.Drawing.Point(16, 19);
            this.myLabel5.Size = new System.Drawing.Size(53, 12);

            this.label47.Location = new System.Drawing.Point(171, 46);
            this.label47.Size = new System.Drawing.Size(53, 12);

            this.label48.Location = new System.Drawing.Point(328, 46);
            this.label48.Size = new System.Drawing.Size(53, 12);

            this.myLabel11.Location = new System.Drawing.Point(328, 75);
            this.myLabel11.Size = new System.Drawing.Size(53, 12);

            this.myLabel7.Location = new System.Drawing.Point(400, 19);
            this.myLabel7.Size = new System.Drawing.Size(53, 12);

            this.myLabel10.Location = new System.Drawing.Point(171, 75);
            this.myLabel10.Size = new System.Drawing.Size(53, 12);

            this.myLabel9.Location = new System.Drawing.Point(16, 46);
            this.myLabel9.Size = new System.Drawing.Size(53, 12);

            this.myLabel13.Location = new System.Drawing.Point(16, 73);
            this.myLabel13.Size = new System.Drawing.Size(53, 12);

            this.gb_ClinicInf.Location = new System.Drawing.Point(3, 134);
            this.gb_ClinicInf.Size = new System.Drawing.Size(678, 71);

            this.label38.Location = new System.Drawing.Point(455, 17);
            this.label38.Size = new System.Drawing.Size(17, 48);
            this.label38.Text = "临\r\n床\r\n诊\r\n断";
 
            this.txt_ClinDiag.Location = new System.Drawing.Point(480, 17);
            this.txt_ClinDiag.Size = new System.Drawing.Size(174, 50);

            this.label34.Location = new System.Drawing.Point(236, 17);
            this.label34.Size = new System.Drawing.Size(17, 48);
            this.label34.Text = "临\r\n床\r\n症\r\n状";

            this.txt_ClinSymp.Location = new System.Drawing.Point(256, 18);
            this.txt_ClinSymp.Size = new System.Drawing.Size(179, 48);

            this.label40.Location = new System.Drawing.Point(11, 17);
            this.label40.Size = new System.Drawing.Size(17, 24);
            this.label40.Text = "体\r\n征";

            this.txt_PhysSign.Location = new System.Drawing.Point(36, 18);
            this.txt_PhysSign.Size = new System.Drawing.Size(174, 49);

            this.gb_TestInf.Location = new System.Drawing.Point(3, 61);
            this.gb_TestInf.Size = new System.Drawing.Size(678, 73);

            this.txt_ReqMemo.Location = new System.Drawing.Point(480, 21);
            this.txt_ReqMemo.Size = new System.Drawing.Size(174, 43);

            this.label35.Location = new System.Drawing.Point(455, 18);
            this.label35.Size = new System.Drawing.Size(17, 48);
            this.label35.Text = "申\r\n请\r\n备\r\n注";

            this.txt_RelevantDiag.Location = new System.Drawing.Point(256, 21);
            this.txt_RelevantDiag.Size = new System.Drawing.Size(179, 43);

            this.label33.Location = new System.Drawing.Point(236, 18);
            this.label33.Size = new System.Drawing.Size(17, 48);
            this.label33.Text = "其\r\n他\r\n诊\r\n断";

            this.txt_RelevantLabTest.Location = new System.Drawing.Point(36, 21);
            this.txt_RelevantLabTest.Size = new System.Drawing.Size(174, 43);

            this.label32.Location = new System.Drawing.Point(11, 18);
            this.label32.Size = new System.Drawing.Size(17, 48);
            this.label32.Text = "相\r\n关\r\n化\r\n验";

            this.panel3.Size = new System.Drawing.Size(678, 58);
            this.panel3.TabIndex = 140;

            this.cmb_ExamGroup.Location = new System.Drawing.Point(307, 32);
            this.cmb_ExamGroup.Size = new System.Drawing.Size(109, 20);

            this.label4.Location = new System.Drawing.Point(236, 34);
            this.label4.Size = new System.Drawing.Size(53, 12);

            this.label23.Location = new System.Drawing.Point(455, 34);
            this.label23.Size = new System.Drawing.Size(53, 12);

            this.label45.Location = new System.Drawing.Point(16, 101);
            this.label45.Size = new System.Drawing.Size(53, 12);

            this.cmb_ImgEquipment.Location = new System.Drawing.Point(307, 8);
            this.cmb_ImgEquipment.Size = new System.Drawing.Size(109, 20);

            this.txt_PatientId.Location = new System.Drawing.Point(92, 8);
            this.txt_PatientId.Size = new System.Drawing.Size(109, 21);
 
            this.txt_TelephoneNum.Location = new System.Drawing.Point(526, 32);
            this.txt_TelephoneNum.Size = new System.Drawing.Size(109, 21);

            this.txt_OpdNo.Location = new System.Drawing.Point(526, 8);
            this.txt_OpdNo.Size = new System.Drawing.Size(109, 21);

            this.myLabel15.Location = new System.Drawing.Point(21, 11);
            this.myLabel15.Size = new System.Drawing.Size(41, 12);

            this.dud_PatientLocalId.Location = new System.Drawing.Point(72, 97);
            this.dud_PatientLocalId.Size = new System.Drawing.Size(89, 21);

            this.label42.Location = new System.Drawing.Point(236, 11);
            this.label42.Size = new System.Drawing.Size(53, 12);

            this.myLabel1.Location = new System.Drawing.Point(455, 11);
            this.myLabel1.Size = new System.Drawing.Size(53, 12);
        }

        #endregion

        #region 修改值刷新word内容

        private void txt_PatientName_TextChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            word.SetValue(FieldDict.PATIENT_NAME, this.txt_PatientName.Text.Trim());
        }

        private void cmb_PatientSource_TextChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            word.SetValue(FieldDict.PATIENT_SOURCE, this.cmb_PatientSource.Text.Trim());
        }

        private void cmb_ReferDept_TextChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            word.SetValue(FieldDict.REQ_DEPT_NAME, this.cmb_ReferDept.Text.Trim());
        }

        private void cmb_Sex_TextChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            word.SetValue(FieldDict.PATIENT_SEX, this.cmb_Sex.Text.Trim());
        }

        private void txt_PatientAge_TextChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            word.SetValue(FieldDict.PATIENT_AGE, this.txt_PatientAge.Text.Trim() + this.cmb_AgeUnit.Text.ToString());
        }

        private void cmb_AgeUnit_TextChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            word.SetValue(FieldDict.PATIENT_AGE, this.txt_PatientAge.Text.Trim() + this.cmb_AgeUnit.Text.ToString());
        }

        private void txt_InpNo_TextChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            word.SetValue(FieldDict.INP_NO, this.txt_InpNo.Text.Trim());
        }

        private void txt_BedNum_TextChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            word.SetValue(FieldDict.BED_NUM, this.txt_BedNum.Text.Trim());
        }

        private void cmb_ReferDoctor_TextChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            word.SetValue(FieldDict.REFER_DOCTOR, this.cmb_ReferDoctor.Text.Trim());
        }

        private void cmb_ExamClass_TextChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            word.SetValue(FieldDict.EXAM_CLASS, this.cmb_ExamClass.Text.Trim());
        }

        private void cmb_ExamSubClass_TextChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            word.SetValue(FieldDict.EXAM_SUB_CLASS, this.cmb_ExamSubClass.Text.Trim());
        }

        private void txt_PatientID_TextChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            word.SetValue(FieldDict.PATIENT_ID, this.txt_PatientId.Text.Trim());
        }

        private void dud_PatientLocalId_TextChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            word.SetValue(FieldDict.PATIENT_LOCAL_ID, this.dud_PatientLocalId.Text.Trim());
        }

        private void cmb_ImgEquipment_TextChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            word.SetValue(FieldDict.DEVICE, this.cmb_ImgEquipment.Text.Trim());
        }

        private void cmb_ExamGroup_TextChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            word.SetValue(FieldDict.EXAM_GROUP, this.cmb_ExamGroup.Text.Trim());
        }

        private void txt_TelephoneNum_TextChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            word.SetValue(FieldDict.TELEPHONE_NUM, this.txt_TelephoneNum.Text.Trim());
        }

        private void txt_ClinSymp_TextChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            word.SetValue(FieldDict.CLIN_SYMP, this.txt_ClinSymp.Text.Trim());
        }

        private void txt_ClinDiag_TextChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            word.SetValue(FieldDict.CLIN_DIAG, this.txt_ClinDiag.Text.Trim());
        }

        private void cmb_Transcriber_TextChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            word.SetValue(FieldDict.TRANSCRIBER, this.cmb_Transcriber.Text.Trim());
        }
        #endregion

        private void cmb_ExamClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            this.dt_ExamItems = null;
            this.cmb_ExamItems.DataSource = null;
            this.lv_ExamItem.Items.Clear();
            this.cmb_ExamItems.Text = "";
            this.txt_Charges.Text = "0";
            this.txt_Costs.Text = "0";
            this.dud_PatientLocalId.Text = "";
            bd.BindExamSubClass(this.cmb_ExamClass.Text, this.cmb_ExamSubClass);

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
        }

        /// <summary>
        /// 选择检查子类后的处理方法
        /// </summary>
        public void ExamSubClassSelectoionCommitted()
        {
            if (this.cmb_ExamSubClass.SelectedItem != null)
            {
                if (this.isInit)
                    return;
                System.Data.DataRow dr = (this.cmb_ExamSubClass.SelectedItem as System.Data.DataRowView).Row;
                this.cmb_ExamSubClass.Text = dr[this.cmb_ExamSubClass.DisplayMember].ToString().Trim();
                this.dt_ExamItems = bd.BindExamItems(this.cmb_ExamClass.Text, this.cmb_ExamSubClass.Text, this.cmb_ExamItems);
                this.txt_Charges.Text = "0";
                this.txt_Costs.Text = "0";
                this.cmb_ExamItems.Text = "";
                if (this.txt_PatientId.Text.Trim() == "")
                    MessageBoxEx.Show("病人ID为空!请输入病人ID.", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    GetLocalId();
            }
        }

        private void txt_PatientId_Leave(object sender, EventArgs e)
        {
            if (this.txt_PatientId.Text != this.mworklist.PATIENT_ID)
                this.GetLocalId();
        }

        private void GetLocalId()
        {
            this.localIdCreater.ExamClass = this.cmb_ExamClass.Text.ToString().Trim();
            this.localIdCreater.ExamSubClass = this.cmb_ExamSubClass.Text.ToString().Trim();
            this.localIdCreater.PatientId = this.txt_PatientId.Text.ToString().Trim();
            this.localIdCreater.GetPatientLocalID("5");//修改模式
            this.dud_PatientLocalId.Text = ((MPatientInfLocalId)this.localIdCreater.iPatientInfLocalId).PATIENT_LOCAL_ID;
        }

        private void cmb_ExamSubClass_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ExamSubClassSelectoionCommitted();
        }

        private void cmb_ExamItems_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cmb_ExamItems.SelectedItem == null)
                return;
            System.Data.DataRow dr = (this.cmb_ExamItems.SelectedItem as System.Data.DataRowView).Row;
            this.cmb_ExamItems.Text = dr[this.cmb_ExamItems.DisplayMember].ToString().Trim();
            
            this.computeCharge.AddExamItem(this.cmb_ExamItems.SelectedValue.ToString(), this.cmb_ExamItems.Text, this.lv_ExamItem.Items.Count + 1);
            AddExamItemList(this.cmb_ExamItems.Text,true);
            word.SetValue(FieldDict.EXAM_ITEMS, this.GetExamItems());
            this.cmb_ExamItems.SelectedIndex = -1;//选择后消除检查项目下拉框文本
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
            this.txt_Charges.Text = this.computeCharge.charges.ToString();
            this.txt_Costs.Text = this.computeCharge.costs.ToString();
            word.SetValue(FieldDict.EXAM_ITEMS, this.GetExamItems());
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

        private void cmb_ReferDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            string referDept = this.cmb_ReferDept.SelectedValue == null ? "" : this.cmb_ReferDept.SelectedValue.ToString();
            bd.BindReferDoctor(referDept, this.cmb_ReferDoctor);
        }

        private void GetData()
        {
            this.mworklist.PATIENT_ID = txt_PatientId.Text.Trim();
            this.mworklist.PATIENT_NAME = this.txt_PatientName.Text.Trim();
            this.mworklist.PATIENT_SEX = this.cmb_Sex.Text;
            this.mworklist.PATIENT_SOURCE = this.cmb_PatientSource.SelectedValue == null ? "" : this.cmb_PatientSource.SelectedValue.ToString();
            this.mworklist.PHYS_SIGN = this.txt_PhysSign.Text.Trim();
            this.mworklist.PATIENT_PHONETIC = GetConfig.phone.Convert(txt_PatientName.Text.Trim(), true);
            this.mworklist.PATIENT_LOCAL_ID = this.dud_PatientLocalId.Text.Trim();
            this.mworklist.PATIENT_AGE = Convert.ToInt32(this.txt_PatientAge.Text);
            this.mworklist.PATIENT_AGE_UNIT = this.cmb_AgeUnit.Text;
            AgeBirth ageBirth = new AgeBirth();
            this.mworklist.PATIENT_BIRTH = ageBirth.AgeToBirth(this.txt_PatientAge.Text.ToString(), this.cmb_AgeUnit.SelectedIndex, System.DateTime.Now, Convert.ToDateTime("1753-1-1"));
            this.mworklist.BED_NUM = this.txt_BedNum.Text.Trim();
            this.mworklist.CLIN_DIAG = this.txt_ClinDiag.Text.Trim();
            this.mworklist.CLIN_SYMP = this.txt_ClinSymp.Text.Trim();
            if (this.cmb_ChargeType.SelectedValue == null)
                this.mworklist.CHARGE_TYPE = null;
            else
                this.mworklist.CHARGE_TYPE = Convert.ToInt32(this.cmb_ChargeType.SelectedValue.ToString());
            this.mworklist.DEVICE = this.cmb_ImgEquipment.Text;
            this.mworklist.EXAM_CLASS = this.cmb_ExamClass.Text;
            this.mworklist.EXAM_GROUP = this.cmb_ExamGroup.Text;
            this.mworklist.EXAM_ITEMS = this.GetExamItems();
            this.mworklist.EXAM_SUB_CLASS = this.cmb_ExamSubClass.Text;
            this.mworklist.INP_NO = this.txt_InpNo.Text.Trim();
            this.mworklist.OPD_NO = this.txt_OpdNo.Text.Trim();
            this.mworklist.REFER_DEPT = this.cmb_ReferDept.SelectedValue == null ? "" : this.cmb_ReferDept.SelectedValue.ToString();
            this.mworklist.REFER_DOCTOR = this.cmb_ReferDoctor.Text.Trim();
            this.mworklist.RELEVANT_DIAG = this.txt_RelevantDiag.Text.Trim();
            this.mworklist.RELEVANT_LAB_TEST = this.txt_RelevantLabTest.Text.Trim();
            this.mworklist.REQ_DEPT_NAME = this.cmb_ReferDept.Text;
            this.mworklist.REQ_MEMO = this.txt_ReqMemo.Text.Trim();
            this.mworklist.TELEPHONE_NUM = this.txt_TelephoneNum.Text.Trim();
            this.mworklist.COSTS = decimal.Parse(this.txt_Costs.Text.Trim());
            this.mworklist.CHARGES = decimal.Parse(this.txt_Charges.Text.Trim());
            this.mworklist.IS_INQUIRY = this.cb_IsInquiry.Checked == true ? 1 : 0;
            this.mArchives.CHARGE_CLASS = this.mworklist.CHARGE_TYPE;
            this.mArchives.INP_NO = this.txt_InpNo.Text.Trim();
            this.mArchives.PATIENT_AGE = this.mworklist.PATIENT_AGE;
            this.mArchives.PATIENT_AGE_UNIT = this.cmb_AgeUnit.Text;
            this.mArchives.PATIENT_BIRTH = this.mworklist.PATIENT_BIRTH;
            this.mArchives.PATIENT_ID = this.txt_PatientId.Text.Trim();
            this.mArchives.PATIENT_NAME = this.txt_PatientName.Text.Trim();
            this.mArchives.PATIENT_SEX = this.cmb_Sex.Text;
            this.mArchives.TELEPHONE_NUM = this.txt_TelephoneNum.Text.Trim();

            this.mrpt.IS_ABNORMAL = this.rb_Abnormal.Checked == true ? 1 : 0;
            this.mrpt.TRANSCRIBER = this.cmb_Transcriber.Text;
        }

        public bool Save()
        {
            this.GetData();
            if (!this.localIdCreater.UpdatePatientInfLocalId(this.localIdCreater.iPatientInfLocalId))
                return false;
            if (!this.regUPE.SetPatientInf(this.mArchives))
                return false;
            if (!this.regUPE.UpdateWorkList(this.mworklist))
                return false;
            if (!this.regUPE.SetExamChargeList(this.mworklist, this.computeCharge.Now_DT_VS_Old, this.computeCharge.Now_DT_VS_Group, this.computeCharge.chargeRatio))
                return false;
            this.localIdCreater.ReSetLocalIdMax();
            return true;
        }

        private void txt_Costs_TextChanged(object sender, EventArgs e)
        {
            this.txt_Charges.Text = this.txt_Costs.Text;
        }

        private void frmExamInf_Load(object sender, EventArgs e)
        {
            clsIme.SetIme(this);//设置输入法为半角
        }

        /// <summary>
        /// 查看检查申请单
        /// add by liukun at 20100528 begin 
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
        //private IntPtr farProc = IntPtr.Zero;
        
        private delegate IntPtr HLoginProc([MarshalAs(UnmanagedType.SysInt)] IntPtr aAppHandle, [MarshalAs(UnmanagedType.SysInt)] IntPtr aCallWinHandle, [MarshalAs(UnmanagedType.SysInt)] IntPtr aPluginHandle, 
            [MarshalAs(UnmanagedType.LPTStr)]  string aBqno, [MarshalAs(UnmanagedType.LPTStr)] string aEmpno, [MarshalAs(UnmanagedType.LPTStr)] string aPatno);

        private Delegate GetFunctionAddress(IntPtr dllModule, string functionName, Type t)
        {
            IntPtr address = GetProcAddress(dllModule, functionName);
            if (address == IntPtr.Zero )
                return null ;
            else
                return Marshal.GetDelegateForFunctionPointer(address, t);                
        }

        private void button_CheckList_Click(object sender, EventArgs e)
        {
            try
            {
                string strNo = this.mworklist.INP_NO.ToString();// "861565";
                if (strNo.Trim() == "")
                {
                    strNo = this.mworklist.OPD_NO.ToString();
                }
                if (strNo.Trim() == "")
                {
                    MessageBox.Show("无法获取患者ID，请确认该患者资料是否已录入HIS系统");
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
                    return ;
                }
                farProc(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, "", "", strNo);
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
        /// 查看LIS检验报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_LISReport_Click(object sender, EventArgs e)
        {
            try
            {   
                if (this.mworklist.INP_NO == null || this.mworklist.INP_NO.ToString().Trim() == "")
                {
                    MessageBox.Show("无法获取患者ID，请确认该患者资料是否已录入HIS系统");
                    return;
                }
                string strNo = this.mworklist.INP_NO.ToString();// "00091355";
                string strFilePath = Environment.CurrentDirectory;
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = strFilePath + "\\HuiTong\\LisReport\\lisreport.exe";
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.Arguments = strNo ;//启动参数: "00091355"
                proc.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }

        /// <summary>
        /// 查看门诊病历
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_mzbl_Click(object sender, EventArgs e)
        {
            try
            {
                string strFilePath = Environment.CurrentDirectory;
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = strFilePath + "\\HuiTong\\Bingli_MZ\\receive.exe";
                //MessageBox.Show(this.mworklist.INP_NO.ToString()); 
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.Arguments = this.mworklist.OPD_NO.ToString();//启动参数: "00230189"
                if (this.mworklist.OPD_NO == null || this.mworklist.OPD_NO.ToString().Trim() == "")
                {
                    if (mworklist.PATIENT_SOURCE.ToString() == "2")
                    {
                        MessageBox.Show("该患者属住院病人，请查看住院病历！");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("无法获取该患者的门诊号，请确认该患者资料是否已录入HIS系统");
                        return;
                    }
                }
                proc.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }

        // add by liukun at 20100528 end 
        
        /// <summary>
        /// 调用慧通接口程序查看住院病历
        /// add by liukun at 2010-06-11 begin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr PostMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        //        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        //       private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, string lParam);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint RegisterWindowMessage(string lpString);

        private void button_zybl_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = FindWindow(null, "HuiTongZYBL");
            if (hWnd.Equals(IntPtr.Zero))
            {
                //运行接口程序
                try
                {
                    string strFilePath = Environment.CurrentDirectory;
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = strFilePath + "\\HuiTong\\Bingli_ZY\\VCTest.exe";
                    //MessageBox.Show(this.mworklist.INP_NO.ToString()); 
                    proc.StartInfo.CreateNoWindow = true;
                    proc.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    return;
                }
            }
            else
            {
                try
                {
                    //if (this.mworklist.INPATIENTNO == null || this.mworklist.INPATIENTNO.ToString().Trim() == "")
                    if (this.mworklist.JZH == null || this.mworklist.JZH.ToString().Trim() == "")
                    {
                        if (this.mworklist.PATIENT_SOURCE.ToString() == "1")
                        {
                            MessageBox.Show("该患者属门诊病人，请查看门诊病历！");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("无法获取该患者的住院号，请确认该患者资料是否已录入HIS系统");
                            return;
                        }
                    }
                    hWnd = FindWindow(null, "HuiTongZYBL");//查找标题为HuiTongZYBL的窗体句柄
                    uint App2_GenerateEvent = RegisterWindowMessage("Message"); //Message为约定的消息名称
                    //SendMessage(hwnd_win, (int)App2_GenerateEvent, new IntPtr(12345), "");
                    //Message msg = Message.Create(hWnd, (int)App2_GenerateEvent, new IntPtr(0), new IntPtr(Convert.ToInt32(this.mworklist.INPATIENTNO)));//创建消息, 发送高位0,低位113848(住院号)的数据
                    Message msg = Message.Create(hWnd, (int)App2_GenerateEvent, new IntPtr(0), new IntPtr(Convert.ToInt32(this.mworklist.JZH)));//创建消息, 发送高位0,低位113848(住院号)的数据
                    //MessageBox.Show(this.mworklist.INP_NO.ToString());
                    PostMessage(msg.HWnd, msg.Msg, msg.WParam, msg.LParam);//发送消息
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    return;
                }
            }
        }
        //add by liukun at 2010-06-11 end 
       

    }
}