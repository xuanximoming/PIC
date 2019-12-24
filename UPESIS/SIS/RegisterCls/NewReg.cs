using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ILL;
using SIS.Function;

namespace SIS.RegisterCls
{
    public class NewReg
    {
        private SIS.frmRegister reg;

        public NewReg(SIS.frmRegister ss)
        {
            this.reg = ss;
            this.reg.dtp_ScheduledDate.Checked = false;  //默认不选中
        }
        /// <summary>
        /// 是否有改动需要保存
        /// </summary>
        /// <returns></returns>
        public bool IsNeedSave()
        {
            if (this.reg.isAdd)
            {
                DialogResult dr = MessageBoxEx.Show("已录入病人检查登记信息,是否保存?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    if (!this.reg.Save(true))
                        return false;
                }
            }
            if (!this.reg.isUpload)
            {
                DialogResult dr = MessageBoxEx.Show("申请单尚未上传,是否上传?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    if (!this.reg.saveReg.SaveReqScanImages())
                        return false;
                }
            }
            if (this.reg.isChange)
            {
                DialogResult dr = MessageBoxEx.Show("已修改检查登记信息,是否保存?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    if (!this.reg.saveReg.Save5())
                        return false;
                }
            }
            this.reg.isAdd = false;
            this.reg.isChange = false;
            return true;
        }
        /// <summary>
        /// 退出系统时判断是否需要保存
        /// </summary>
        /// <returns></returns>
        public bool IsNeedSave2()
        {
            bool isCancel = true;
            if (this.reg.isAdd)
            {
                DialogResult dr = MessageBoxEx.Show("已录入病人检查登记信息,是否保存?", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                switch (dr)
                {
                    case DialogResult.Yes:
                        if (!this.reg.saveReg.Save())
                            isCancel = false;
                        break;
                    case DialogResult.No:
                        isCancel = true;
                        break;
                    case DialogResult.Cancel:
                        isCancel = false;
                        break;
                }
            }
            if (this.reg.isUpload)
            {
                DialogResult dr = MessageBoxEx.Show("申请单尚未上传,是否上传?", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                switch (dr)
                {
                    case DialogResult.Yes:
                        if (!this.reg.saveReg.SaveReqScanImages())
                            isCancel = false;
                        break;
                    case DialogResult.No:
                        isCancel = true;
                        break;
                    case DialogResult.Cancel:
                        isCancel = false;
                        break;
                }
            }
            if (this.reg.isChange)
            {
                DialogResult dr = MessageBoxEx.Show("已修改检查登记信息,是否保存?", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                switch (dr)
                {
                    case DialogResult.Yes:
                        if (!this.reg.saveReg.Save5())
                        {
                            isCancel = false;
                        }
                        break;
                    case DialogResult.No:
                        isCancel = true;
                        break;
                    case DialogResult.Cancel:
                        isCancel = false;
                        break;
                }
            }
            return isCancel;
        }

        /// <summary>
        /// 开始新的检查登记
        /// </summary>
        public bool NewExam()
        {
            if (!this.IsNeedSave())
                return false ;
            this.reg.Mode = "6";
            TextBoxClear();
            this.reg.reqScanImage.NewScan();
            this.reg.Mode = "7";
            this.reg.localIdCreater.Init();
            
            this.reg.iWorkList = DALFactory.Model.CreateMWorkList();
            this.reg.iPatientInfLocalId = DALFactory.Model.CreateMPatientInfLocalId();
            this.reg.iArchives = DALFactory.Model.CreateMArchives();

            this.reg.IsNew = false;
            this.reg.computeCharge.Init();

            this.reg.cmb_AgeUnit.SelectedIndex = 0;
            this.reg.cmb_ExamClass.SelectedIndex = 0;
            this.reg.cmb_Sex.SelectedIndex = 0;
            this.reg.cmb_ExamDept.Text = GetConfig.ExamDeptName;
            this.reg.cmb_ExamDept.SelectedValue = GetConfig.ExamDeptCode;
            CtlComboBox.SetDisplay("标准", this.reg.cmb_ChargeType);
            CtlComboBox.SetDisplay(GetConfig.RM_DefaultSex, this.reg.cmb_Sex);

            this.reg.dtp_Birth.Value = DateTime.Now;
            this.reg.dtp_ReqDateTime.Value = System.DateTime.Now;
            this.reg.dtp_ScheduledDate.Value = System.DateTime.Now;
            this.reg.dtp_ScheduledDate.Checked = false; //add by liu kun at 2010-6-30 默认不选中
            CtlComboBox.SetDisplay(GetConfig.Group, this.reg.cmb_ExamGroup);
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    SIS_Model.MUser smUser = (SIS_Model.MUser)this.reg.iUser;
                    SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.reg.iWorkList;
                    smWorkList.SCH_OPERATOR = smUser.DOCTOR_ID;
                    smWorkList.EXAM_DEPT = smUser.CLINIC_OFFICE_CODE;
                    smWorkList.EXAM_DEPT_NAME = smUser.CLINIC_OFFICE;
                    smWorkList.IS_BACK_INQ = 0;
                    smWorkList.IS_CONFIRMED = 1;
                    smWorkList.IS_INQUIRY = 0;
                    smWorkList.IS_TEMPORARY = 0;
                    smWorkList.REPORT_STATUS = 0;
                    smWorkList.IS_ONLINE = 1;
                    smWorkList.IS_PACKPROCESS = 0;
                    smWorkList.IMAGE_COUNTS = 0;
                    CtlComboBox.SetDisplay(GetConfig.ImgEquipment, this.reg.cmb_ImgEquipment);
                    CtlComboBox.SetDisplay(smUser.DOCTOR_NAME, this.reg.cmb_ExamDoctor);
                    break;
                case "PACS":
                    PACS_Model.MUser pmUser = (PACS_Model.MUser)this.reg.iUser;
                    PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.reg.iWorkList;
                    pmWorkList.SCH_OPERATOR = pmUser.DB_USER;
                    pmWorkList.EXAM_DEPT = pmUser.USER_DEPT;
                    pmWorkList.EXAM_DEPT_NAME = pmUser.DEPT_NAME;
                    pmWorkList.IS_CONFIRMED = 1;
                    pmWorkList.IS_TEMPORARY = 0;
                    pmWorkList.REPORT_STATUS = 0;
                    break;
            }
            if (!this.NewExamAccessionNum())
            {
                MessageBoxEx.Show("无法生成检查申请序号，不能进行登记！", "错误");
                return false;
            }
            this.reg.btn_OpenRpt.Enabled = false;
            this.reg.lb_Notice.Text = "新检查登记：请在红色输入框中输入病人信息,查找检查申请记录！";
            this.reg.dtp_ScheduledDate.Checked = false;     //add by liukun at 2010-7-30 预约时间默认为不选中
            this.reg.groupBox_OrderNotice.Enabled = false;  //add by liukun at 2010-7-30 预约注意事项默认为不编辑
            return true;
        }

        private bool NewExamAccessionNum()
        {
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.reg.iWorkList;
                    string sAccessionNo = this.reg.regUPE.GetAccessionNo();    //通过数据库的自动产生序号函数，获取当前检查流水号最大值
                    if (sAccessionNo == "")
                        return false;
                    else
                        smWorkList.ACCESSION_NO = Convert.ToInt32(sAccessionNo);
                    if (!this.reg.regUPE.GetExamAccessionNum(this.reg.iWorkList))
                        return false;
                    else
                        return true;
                case "PACS":
                    PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.reg.iWorkList;
                    string pAccessionNo = this.reg.regPacs.GetAccessionNo();    //通过数据库的自动产生序号函数，获取当前检查流水号最大值
                    if (pAccessionNo == "")
                        return false;
                    else
                        pmWorkList.ACCESSION_NO = Convert.ToInt32(pAccessionNo);
                    if (!this.reg.regPacs.GetExamAccessionNum(this.reg.iWorkList))
                        return false;
                    else
                        return true;
                default :
                    return false;
            }  
        }

        /// <summary>
        /// 清除TextBox
        /// </summary>
        private void TextBoxClear()
        {
            this.reg.txt_PatientId.Text = "";
            this.reg.txt_PatientName.Text = "";
            this.reg.txt_PatientPhonetic.Text = "";
            this.reg.txt_Age.Text = "";
            this.reg.txt_OpdNo.Text = "";
            this.reg.txt_BedNum.Text = "";
            this.reg.txt_InpNo.Text = "";
            this.reg.txt_PatientIdentity.Text = "";
            this.reg.txt_IdentityCardNo.Text = "";
            this.reg.txt_Costs.Text = "";
            this.reg.txt_Charges.Text = "";
            this.reg.txt_TelephoneNum.Text = "";
            this.reg.txt_ZipCode.Text = "";
            this.reg.txt_MailingAddress.Text = "";
            this.reg.txt_OutMedInstitution.Text = "";
            //6个--临床信息和检验信息
            this.reg.txt_PhysSign.Text = "";
            this.reg.txt_RelevantDiag.Text = "";
            this.reg.txt_RelevantLabTest.Text = "";
            this.reg.txt_ReqMemo.Text = "";
            this.reg.txt_ClinDiag.Text = "";
            this.reg.txt_ClinSymp.Text = "";

            this.reg.dud_PatientLocalId.Text = "";

            this.reg.cmb_ExamItems.Text = "";
            this.reg.cmb_ReferDoctor.Text = "";
            this.reg.cmb_ExamDoctor.Text = "";
            this.reg.cmb_BirthPlace.SelectedIndex = -1;
            this.reg.cmb_AgeUnit.SelectedIndex = -1;
            this.reg.cmb_Sex.SelectedIndex = -1;
            this.reg.cmb_PatientClass.SelectedIndex = -1;
            this.reg.cmb_ChargeType.SelectedIndex = -1;
            this.reg.cmb_ExamDept.SelectedIndex = -1;
            this.reg.cmb_ReferDept.Text = "";//2010-03-18添加清除申请科室
            this.reg.cmb_ReferDept.SelectedIndex = -1;
            this.reg.cmb_ExamClass.SelectedIndex = -1;
            this.reg.cmb_ExamSubClass.SelectedIndex = -1;
            this.reg.cmb_PatientSource.SelectedIndex = -1;
            this.reg.cmb_ImgEquipment.SelectedIndex = -1;
            this.reg.cmb_ExamGroup.SelectedIndex = -1;

            this.reg.dtp_ReqDateTime.Value = this.reg.dtp_ReqDateTime.MinDate;
            this.reg.dtp_ScheduledDate.Value = this.reg.dtp_ScheduledDate.MinDate;
            this.reg.dtp_Birth.Value = this.reg.dtp_Birth.MinDate;
            this.reg.tcl_Sub.SelectedIndex = 0;

            this.reg.btn_NewPatientId.Enabled = true;
            this.reg.dtp_ReqDateTime.Enabled = true;
            this.reg.dtp_ScheduledDate.Enabled = true;
            this.reg.btn_Save.Enabled = true;
            this.reg.cmb_PatientSource.Enabled = true;
            //变量初始化
            //this.BIRTH_PLACE_CODE = "";
            //this.Charge_Item_No = 0;
        }

        /// <summary>
        /// 设置控件的可编辑性
        /// </summary>
        public void SetEnable(bool isEnable, bool isSickRoom)
        {
            if (isEnable)
            {
                this.reg.cmb_ExamClass.Enabled = true;
                this.reg.cmb_ExamSubClass.Enabled = true;
                this.reg.cmb_ExamItems.Enabled = true;
                this.reg.cmb_ChargeType.Enabled = true;
            }
            else
            {
                //this.reg.cmb_ExamClass.Enabled = false;
                //this.reg.cmb_ExamSubClass.Enabled = false;
                //this.reg.cmb_ExamItems.Enabled = false;
                //this.reg.cmb_ChargeType.Enabled = false;
            }
            //if (isSickRoom)
            //    this.reg.cmb_PatientSource.Enabled = false;
            //else
            //    this.reg.cmb_PatientSource.Enabled = true;
        }

    }
}
