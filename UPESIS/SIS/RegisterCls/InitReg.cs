using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ILL;
using SIS.Function;
using SIS_BLL;

namespace SIS.RegisterCls
{
    public class InitReg
    {
        private SIS.frmRegister reg;

        public InitReg(SIS.frmRegister ss)
        {
            this.reg = ss;
            this.reg.dtp_ScheduledDate.Checked = false;   //默认不选中
        }

        /// <summary>
        /// 初始化模式0:由PACS系统病人资料库提取信息
        /// </summary>
        public void initMode0(IModel iWorkList,IModel iArchives, string Mode)
        {
            this.reg.Mode = Mode;
            this.reg.iWorkList = iWorkList;
            this.reg.iArchives = iArchives;
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    SIS_Model.MArchives smArchives = (SIS_Model.MArchives)iArchives;
                    this.reg.txt_PatientId.Text = smArchives.PATIENT_ID;                 //病人ID
                    this.reg.txt_PatientName.Text = smArchives.PATIENT_NAME;             //姓名            
                    this.reg.cmb_BirthPlace.Text = smArchives.BIRTH_PLACE;               //出生地
                    //this.BIRTH_PLACE_CODE = this.reg.mArchives.BIRTH_PLACE_CODE;
                    this.reg.txt_MailingAddress.Text = smArchives.MAILING_ADDRESS;       //邮箱地址
                    this.reg.txt_ZipCode.Text = smArchives.ZIP_CODE;                     //邮编
                    this.reg.txt_TelephoneNum.Text = smArchives.TELEPHONE_NUM;           //电话
                    this.reg.txt_IdentityCardNo.Text = smArchives.IDENTITY_CARD_NO;      //身份证
                    this.reg.cmb_Sex.Text = smArchives.PATIENT_SEX;                      //性别
                    if (smArchives.PATIENT_BIRTH != null)
                        this.reg.dtp_Birth.Value = Convert.ToDateTime(smArchives.PATIENT_BIRTH); //出生日期
                    SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)iWorkList;
                    this.reg.txt_OpdNo.Text = smWorkList.OPD_NO;                         //门诊号
                    this.reg.txt_InpNo.Text = smWorkList.INP_NO;                         //住院号
                    //this.reg.txt_PatientPhonetic.Text = mWorkList.PATIENT_PHONETIC;     //姓名拼音
                    //this.reg.cmb_PatientClass.SelectedIndex = mWorkList.PATIENT_CLASS;           //入院方式
                    if (smWorkList.REFER_DEPT != null && smWorkList.REFER_DEPT != "")
                    {
                        this.reg.cmb_ReferDept.SelectedValue = smWorkList.REFER_DEPT;     //申请科室
                        this.reg.cmb_ReferDept.Text = smWorkList.REQ_DEPT_NAME;
                        if (GetConfig.hisVisit)
                            switch (GetConfig.hisVender)
                            {
                                case "JW":
                                    this.reg.regJW.Bind_ReferDoctor(smWorkList.REFER_DEPT, this.reg.cmb_ReferDoctor);
                                    break;
                                case "HT":
                                    break;
                            }
                        else
                            this.reg.regUPE.Bind_ReferDoctor(smWorkList.REFER_DEPT, this.reg.cmb_ReferDoctor);
                        CtlComboBox.SetDisplay(smWorkList.REFER_DOCTOR, this.reg.cmb_ReferDoctor);    //申请医生
                    }
                    break;
                case "PACS":
                    PACS_Model.MArchives pmArchives = (PACS_Model.MArchives)iArchives;
                    this.reg.txt_PatientId.Text = pmArchives.PATIENT_ID;                 //病人ID
                    this.reg.txt_PatientName.Text = pmArchives.PATIENT_NAME;             //姓名            
                    this.reg.cmb_BirthPlace.Text = pmArchives.BIRTH_PLACE;               //出生地
                    //this.BIRTH_PLACE_CODE = this.reg.mArchives.BIRTH_PLACE_CODE;
                    this.reg.txt_MailingAddress.Text = pmArchives.MAILING_ADDRESS;       //邮箱地址
                    this.reg.txt_ZipCode.Text = pmArchives.ZIP_CODE;                     //邮编
                    this.reg.txt_TelephoneNum.Text = pmArchives.TELEPHONE_NUMBER;           //电话
                    this.reg.txt_IdentityCardNo.Text = pmArchives.IDENTITY_CARD_NO;      //身份证
                    this.reg.cmb_Sex.Text = pmArchives.PATIENT_SEX;                      //性别
                    if (pmArchives.PATIENT_BIRTH != null)
                        this.reg.dtp_Birth.Value = Convert.ToDateTime(pmArchives.PATIENT_BIRTH); //出生日期
                    PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)iWorkList;
                    this.reg.txt_OpdNo.Text = pmWorkList.OPD_NO;                         //门诊号
                    this.reg.txt_InpNo.Text = pmWorkList.INP_NO;                         //住院号
                    //this.reg.txt_PatientPhonetic.Text = mWorkList.PATIENT_PHONETIC;     //姓名拼音
                    //this.reg.cmb_PatientClass.SelectedIndex = mWorkList.PATIENT_CLASS;           //入院方式
                    if (pmWorkList.REFER_DEPT != null && pmWorkList.REFER_DEPT != "")
                    {
                        this.reg.cmb_ReferDept.SelectedValue = pmWorkList.REFER_DEPT;     //申请科室
                        this.reg.cmb_ReferDept.Text = pmWorkList.REQ_DEPT_NAME;
                        if (GetConfig.hisVisit)
                            switch (GetConfig.hisVender)
                            {
                                case "JW":
                                    this.reg.regJW.Bind_ReferDoctor(pmWorkList.REFER_DEPT, this.reg.cmb_ReferDoctor);
                                    break;
                                case "HT":
                                    break;
                            }
                        else
                            this.reg.regPacs.Bind_ReferDoctor(pmWorkList.REFER_DEPT, this.reg.cmb_ReferDoctor);
                        CtlComboBox.SetDisplay(pmWorkList.REFER_DOCTOR, this.reg.cmb_ReferDoctor);    //申请医生
                    }
                    break;
            }
            this.reg.lb_Notice.Text = "门诊病人登记";
            this.reg.dtp_ReqDateTime.Enabled = true;
            CtlComboBox.SetDisplay("门诊", this.reg.cmb_PatientSource);
            this.reg.cmb_ExamClass.SelectedIndex = -1;
            if (this.reg.Exam_Class.Length != 0)
                CtlComboBox.SetDisplay(this.reg.Exam_Class[0], this.reg.cmb_ExamClass);
            if (this.reg.cmb_ExamClass.SelectedIndex == -1 && this.reg.cmb_ExamClass.Items.Count == 1)
                this.reg.cmb_ExamClass.SelectedIndex = 0;
            this.reg.isAdd = true;
            this.reg.SetDisable(true);
            this.reg.dtp_ScheduledDate.Checked = false;     //add by liukun at 2010-7-30 预约时间默认为不选中
            this.reg.groupBox_OrderNotice.Enabled = false;  //add by liukun at 2010-7-30 预约注意事项默认为不编辑
        }

        /// <summary>
        /// 初始化模式1:由HIS病人资料库提取信息
        /// </summary>
        public void initMode1(IModel iWorkList,IModel iArchives, string Mode)
        {
            this.reg.iWorkList = iWorkList;
            this.reg.iArchives = iArchives;
            this.reg.Mode = Mode;
            this.reg.lb_Notice.Text = "门诊病人登记";
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    SIS_Model.MArchives smArchives = (SIS_Model.MArchives)iArchives;
                    this.reg.txt_IdentityCardNo.Text = smArchives.IDENTITY_CARD_NO;      //身份证
                    SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.reg.iWorkList;
                    //this.reg.EXAM_NO = smWorkList.EXAM_NO;                          //检查序号  
                    this.reg.txt_PatientId.Text = smWorkList.PATIENT_ID;                 //病人ID
                    this.reg.txt_PatientPhonetic.Text = smWorkList.PATIENT_PHONETIC;     //姓名拼音
                    this.reg.txt_PatientName.Text = smWorkList.PATIENT_NAME;             //姓名            
                    this.reg.txt_InpNo.Text = smWorkList.INP_NO;                         //住院号
                    this.reg.cmb_BirthPlace.Text = smWorkList.BIRTH_PLACE;               //出生地
                    //this.BIRTH_PLACE_CODE = smWorkList.BIRTH_PLACE_CODE;
                    this.reg.txt_PatientIdentity.Text = smWorkList.PATIENT_IDENTITY;             //身份
                    this.reg.txt_MailingAddress.Text = smWorkList.MAILING_ADDRESS;       //邮箱地址
                    this.reg.txt_ZipCode.Text = smWorkList.ZIP_CODE;                     //邮编
                    this.reg.txt_TelephoneNum.Text = smWorkList.TELEPHONE_NUM;           //电话
                    this.reg.cmb_Sex.Text = smWorkList.PATIENT_SEX;                     //性别
                    this.reg.cmb_ChargeType.SelectedValue = smWorkList.CHARGE_TYPE;             //费别
                    if (smWorkList.REFER_DEPT != null && smWorkList.REFER_DEPT != "")
                    {
                        this.reg.cmb_ReferDept.SelectedValue = smWorkList.REFER_DEPT;     //申请科室
                        this.reg.cmb_ReferDept.Text = smWorkList.REQ_DEPT_NAME;
                        if (GetConfig.hisVisit)
                            switch (GetConfig.hisVender)
                            {
                                case "JW":
                                    this.reg.regJW.Bind_ReferDoctor(smWorkList.REFER_DEPT, this.reg.cmb_ReferDoctor);
                                    break;
                                case "HT":
                                    break;
                            }
                        else
                            this.reg.regUPE.Bind_ReferDoctor(smWorkList.REFER_DEPT, this.reg.cmb_ReferDoctor);
                        CtlComboBox.SetDisplay(smWorkList.REFER_DOCTOR, this.reg.cmb_ReferDoctor);    //申请医生
                    }
                    //出生日期
                    if (smWorkList.PATIENT_BIRTH != null)
                        this.reg.dtp_Birth.Value = Convert.ToDateTime(smWorkList.PATIENT_BIRTH);
                    break;
                case "PACS":
                    PACS_Model.MArchives pmArchives = (PACS_Model.MArchives)iArchives;
                    this.reg.txt_IdentityCardNo.Text = pmArchives.IDENTITY_CARD_NO;      //身份证
                    PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.reg.iWorkList;
                    //this.reg.EXAM_NO = mWorkList.EXAM_NO;                          //检查序号  
                    this.reg.txt_PatientId.Text = pmWorkList.PATIENT_ID;                 //病人ID
                    this.reg.txt_PatientPhonetic.Text = pmWorkList.PATIENT_PHONETIC;     //姓名拼音
                    this.reg.txt_PatientName.Text = pmWorkList.PATIENT_NAME;             //姓名            
                    this.reg.txt_InpNo.Text = pmWorkList.INP_NO;                         //住院号
                    this.reg.cmb_BirthPlace.Text = pmWorkList.BIRTH_PLACE;               //出生地
                    //this.BIRTH_PLACE_CODE = mWorkList.BIRTH_PLACE_CODE;
                    this.reg.txt_PatientIdentity.Text = pmWorkList.PATIENT_IDENTITY;             //身份
                    this.reg.txt_MailingAddress.Text = pmWorkList.MAILING_ADDRESS;       //邮箱地址
                    this.reg.txt_ZipCode.Text = pmWorkList.ZIP_CODE;                     //邮编
                    this.reg.txt_TelephoneNum.Text = pmWorkList.TELEPHONE_NUM;           //电话
                    this.reg.cmb_Sex.Text = pmWorkList.PATIENT_SEX;                     //性别
                    this.reg.cmb_ChargeType.SelectedValue = pmWorkList.CHARGE_TYPE;             //费别
                    if (pmWorkList.REFER_DEPT != null && pmWorkList.REFER_DEPT != "")
                    {
                        this.reg.cmb_ReferDept.SelectedValue = pmWorkList.REFER_DEPT;     //申请科室
                        this.reg.cmb_ReferDept.Text = pmWorkList.REQ_DEPT_NAME;
                        if (GetConfig.hisVisit)
                            switch (GetConfig.hisVender)
                            {
                                case "JW":
                                    this.reg.regJW.Bind_ReferDoctor(pmWorkList.REFER_DEPT, this.reg.cmb_ReferDoctor);
                                    break;
                                case "HT":
                                    break;
                            }
                        else
                            this.reg.regPacs.Bind_ReferDoctor(pmWorkList.REFER_DEPT, this.reg.cmb_ReferDoctor);
                        CtlComboBox.SetDisplay(pmWorkList.REFER_DOCTOR, this.reg.cmb_ReferDoctor);    //申请医生
                    }
                    //出生日期
                    if (pmWorkList.PATIENT_BIRTH != null)
                        this.reg.dtp_Birth.Value = Convert.ToDateTime(pmWorkList.PATIENT_BIRTH);
                    break;
            }
            this.reg.dtp_ReqDateTime.Enabled = true;
            CtlComboBox.SetDisplay("门诊", this.reg.cmb_PatientSource);
            this.reg.cmb_PatientClass.SelectedIndex = 0;
            if (this.reg.cmb_ExamClass.Items.Count == 1)
                this.reg.cmb_ExamClass.SelectedIndex = 0;
            if (this.reg.Exam_Class.Length != 0)
                CtlComboBox.SetDisplay(this.reg.Exam_Class[0], this.reg.cmb_ExamClass);
            this.reg.isAdd = true;
            this.reg.dtp_ScheduledDate.Checked = false;     //add by liukun at 2010-7-30 预约时间默认为不选中
            this.reg.groupBox_OrderNotice.Enabled = false;  //add by liukun at 2010-7-30 预约注意事项默认为不编辑
        }

        /// <summary>
        /// 初始化模式2:由HIS检查申请提取信息
        /// </summary>
        public void initMode2(IModel iWorkList, string Mode, System.Data.DataTable DT_EXAM)
        {
            this.reg.iWorkList = iWorkList;
            this.reg.Mode = Mode;

            this.reg.lv_ExamItem.Items.Clear();  //Add at 2010-08-19  初始化的同时将检查类别的选项清空
            this.reg.computeCharge.Init();

            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.reg.iWorkList;
                    this.reg.txt_PatientId.Text = this.reg.regUPE.NewPatientID();        //病人ID
                    this.reg.txt_OutMedInstitution.Text = smWorkList.OUT_MED_INSTITUTION;//外来医疗单位名称 
                    this.reg.txt_PatientPhonetic.Text = smWorkList.PATIENT_PHONETIC;     //姓名拼音
                    this.reg.txt_PatientName.Text = smWorkList.PATIENT_NAME;             //姓名            
                    this.reg.dud_PatientLocalId.Text = smWorkList.PATIENT_LOCAL_ID;      //检查标识号
                    this.reg.cmb_BirthPlace.Text = smWorkList.BIRTH_PLACE;               //出生地
                    this.reg.txt_PatientIdentity.Text = smWorkList.PATIENT_IDENTITY;     //身份
                    this.reg.txt_MailingAddress.Text = smWorkList.MAILING_ADDRESS;       //邮箱地址
                    this.reg.txt_ZipCode.Text = smWorkList.ZIP_CODE;                     //邮编
                    this.reg.txt_TelephoneNum.Text = smWorkList.TELEPHONE_NUM;           //电话
                    this.reg.txt_Costs.Text = smWorkList.COSTS.ToString();               //费用
                    this.reg.txt_Charges.Text = smWorkList.CHARGES.ToString();           //实收费用
                    this.reg.txt_BedNum.Text = smWorkList.BED_NUM;                       //床号
                    this.reg.txt_InpNo.Text = smWorkList.INP_NO;                         //住院号
                    this.reg.txt_OpdNo.Text = smWorkList.OPD_NO;                         //门诊号
                    this.reg.txt_PhysSign.Text = smWorkList.PHYS_SIGN;                   //体征
                    this.reg.txt_ClinDiag.Text = smWorkList.CLIN_DIAG;                   //临床诊断
                    this.reg.txt_ClinSymp.Text = smWorkList.CLIN_SYMP;                   //临床症状
                    this.reg.txt_ReqMemo.Text = smWorkList.REQ_MEMO;                     //申请备注
                    this.reg.txt_RelevantDiag.Text = smWorkList.RELEVANT_DIAG;           //其他诊断
                    this.reg.txt_RelevantLabTest.Text = smWorkList.RELEVANT_LAB_TEST;    //相关化验  
                    
                    this.reg.txt_TelephoneNum.Text = smWorkList.TELEPHONE_NUM;
                        this.reg.txt_MailingAddress.Text = smWorkList.MAILING_ADDRESS;
                    //申请时间
                    if (smWorkList.REQ_DATE_TIME != null)
                    {
                        this.reg.dtp_ReqDateTime.Value = Convert.ToDateTime(smWorkList.REQ_DATE_TIME);
                        this.reg.dtp_ScheduledDate.Value = Convert.ToDateTime(smWorkList.REQ_DATE_TIME);
                    }
                    //出生日期
                    if (smWorkList.PATIENT_BIRTH != null)
                        this.reg.dtp_Birth.Value = Convert.ToDateTime(smWorkList.PATIENT_BIRTH);
                    //预约时间
                    if (smWorkList.SCHEDULED_DATE != null)
                        this.reg.dtp_ScheduledDate.Value = Convert.ToDateTime(smWorkList.SCHEDULED_DATE);

                    this.reg.cmb_Sex.Text = smWorkList.PATIENT_SEX;                                     //性别
                    this.reg.cmb_ChargeType.Text = smWorkList.CHARGE_TYPE.ToString();                   //费别      
                    this.reg.cmb_PatientSource.Text=smWorkList.PATIENT_SOURCE;                          //病人来源
                    this.reg.cmb_ReferDept.Text = smWorkList.REFER_DEPT;                                //申请科室
                    this.reg.cmb_ReferDoctor.Text = smWorkList.REFER_DOCTOR;
                    CtlComboBox.SetValue(smWorkList.PATIENT_SOURCE, this.reg.cmb_PatientSource);        //病人来源
                    CtlComboBox.SetDisplay(smWorkList.EXAM_CLASS, this.reg.cmb_ExamClass);              //检查类别
                    this.reg.regUPE.Bind_ExamSubClass(smWorkList.EXAM_CLASS, this.reg.cmb_ExamSubClass);
                    CtlComboBox.SetDisplay(smWorkList.EXAM_SUB_CLASS, this.reg.cmb_ExamSubClass);       //检查子类
                    CtlComboBox.SetDisplay(smWorkList.EXAM_GROUP, this.reg.cmb_ExamGroup);     //诊室名　　add by liukun at 2010-7-5
                    this.reg.txt_blfy.Text = "";   //初始化补用费用   add at 2010-08-27
                    break;
                case "PACS":
                    PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.reg.iWorkList;
                    //this.reg.txt_PatientId.Text = this.reg.regPacs.NewPatientID();          //病人ID
                    this.reg.txt_OutMedInstitution.Text = pmWorkList.OUT_MED_INSTITUTION;  //外来医疗单位名称 
                    this.reg.txt_PatientPhonetic.Text = pmWorkList.PATIENT_PHONETIC;       //姓名拼音
                    this.reg.txt_PatientName.Text = pmWorkList.PATIENT_NAME;               //姓名            
                    this.reg.dud_PatientLocalId.Text = pmWorkList.PATIENT_LOCAL_ID;        //检查标识号
                    this.reg.cmb_BirthPlace.Text = pmWorkList.BIRTH_PLACE;                 //出生地
                    this.reg.txt_PatientIdentity.Text = pmWorkList.PATIENT_IDENTITY;       //身份
                    this.reg.txt_MailingAddress.Text = pmWorkList.MAILING_ADDRESS;         //邮箱地址
                    this.reg.txt_ZipCode.Text = pmWorkList.ZIP_CODE;                       //邮编
                    this.reg.txt_TelephoneNum.Text = pmWorkList.TELEPHONE_NUM;             //电话
                    this.reg.txt_Costs.Text = pmWorkList.COSTS.ToString();                 //费用
                    this.reg.txt_Charges.Text = pmWorkList.CHARGES.ToString();             //实收费用
                    this.reg.txt_BedNum.Text = pmWorkList.BED_NUM;                       //床号
                    this.reg.txt_InpNo.Text = pmWorkList.INP_NO;                         //住院号
                    this.reg.txt_OpdNo.Text = pmWorkList.OPD_NO;                         //门诊号
                    this.reg.txt_PhysSign.Text = pmWorkList.PHYS_SIGN;                   //体征
                    this.reg.txt_ClinDiag.Text = pmWorkList.CLIN_DIAG;                   //临床诊断
                    this.reg.txt_ClinSymp.Text = pmWorkList.CLIN_SYMP;                   //临床症状
                    this.reg.txt_ReqMemo.Text = pmWorkList.REQ_MEMO;                     //申请备注
                    this.reg.txt_RelevantDiag.Text = pmWorkList.RELEVANT_DIAG;           //其他诊断
                    this.reg.txt_RelevantLabTest.Text = pmWorkList.RELEVANT_LAB_TEST;    //相关化验  

                    this.reg.txt_TelephoneNum.Text = pmWorkList.TELEPHONE_NUM;
                    this.reg.txt_MailingAddress.Text = pmWorkList.MAILING_ADDRESS;
                    //申请时间
                    if (pmWorkList.REQ_DATE_TIME != null)
                    {
                        this.reg.dtp_ReqDateTime.Value = Convert.ToDateTime(pmWorkList.REQ_DATE_TIME);
                        this.reg.dtp_ScheduledDate.Value = Convert.ToDateTime(pmWorkList.REQ_DATE_TIME);
                    }
                    //出生日期
                    if (pmWorkList.PATIENT_BIRTH != null)
                        this.reg.dtp_Birth.Value = Convert.ToDateTime(pmWorkList.PATIENT_BIRTH);
                    //预约时间
                    if (pmWorkList.SCHEDULED_DATE != null)
                        this.reg.dtp_ScheduledDate.Value = Convert.ToDateTime(pmWorkList.SCHEDULED_DATE);

                    this.reg.cmb_Sex.Text = pmWorkList.PATIENT_SEX;                                   //性别
                    this.reg.cmb_ChargeType.Text = pmWorkList.CHARGE_TYPE.ToString();                 //费别      
                    this.reg.cmb_PatientSource.Text = pmWorkList.PATIENT_SOURCE;                      //病人来源
                    this.reg.cmb_ReferDept.Text = pmWorkList.REFER_DEPT;                              //申请科室
                    this.reg.cmb_ReferDoctor.Text = pmWorkList.REFER_DOCTOR;
                    CtlComboBox.SetValue(pmWorkList.PATIENT_SOURCE, this.reg.cmb_PatientSource);      //病人来源
                    CtlComboBox.SetDisplay(pmWorkList.EXAM_CLASS, this.reg.cmb_ExamClass);            //检查类别
                    this.reg.regUPE.Bind_ExamSubClass(pmWorkList.EXAM_CLASS, this.reg.cmb_ExamSubClass);
                    CtlComboBox.SetDisplay(pmWorkList.EXAM_SUB_CLASS, this.reg.cmb_ExamSubClass);     //检查子类
                    CtlComboBox.SetDisplay(pmWorkList.EXAM_GROUP, this.reg.cmb_ExamGroup);     //诊室名　　add by liukun at 2010-7-5
                    this.reg.txt_blfy.Text = "";     //初始化补用费用   add at 2010-08-27
                    break;
            }
            //2010-03-18申请单登记时病人ID＝门诊号/住院号
            if (this.reg.txt_InpNo.Text == "" && this.reg.txt_OpdNo.Text == "")
            {
                //自动生成ID号
                initMode4("");
            }
            else
            {
                if (this.reg.txt_OpdNo.Text != "")
                {
                    this.reg.txt_PatientId.Text = this.reg.txt_OpdNo.Text;
                }
                else
                {
                    this.reg.txt_PatientId.Text = this.reg.txt_InpNo.Text;
                }
            }
            this.reg.ExamSubClassSelectoionCommitted();
            if (this.reg.Mode == "11")
            {
                this.reg.lb_Notice.Text = "住院病人登记";
            }
            else
                this.reg.lb_Notice.Text = "门诊病人登记";
            this.reg.dtp_ReqDateTime.Enabled = true;
            this.reg.cmb_PatientClass.SelectedIndex = 1;
            this.reg.isAdd = true;
            this.reg.SetDisable(true);
            this.reg.dtp_ScheduledDate.Checked = false;     //add by liukun at 2010-7-30 预约时间默认为不选中
            this.reg.groupBox_OrderNotice.Enabled = false;  //add by liukun at 2010-7-30 预约注意事项默认为不编辑

            this.reg.btn_Save.Enabled = true;     //add at 2010-08-19 初始化的同时，将保存按钮设置为可操作   
            this.reg.txt_blfy.Enabled = false;    //add at 2010-08-27 将补录费用不可填
        }

        /// <summary>
        /// 初始化模式3:由HIS在院病人资料库提取信息
        /// </summary>
        public void initMode3(IModel iWorkList, string Mode)
        {
            this.reg.iWorkList = iWorkList;
            this.reg.Mode = Mode;
            this.reg.lb_Notice.Text = "住院病人登记";
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.reg.iWorkList;
                    //this.EXAM_NO = smWorkList.EXAM_NO;                                 //检查序号  
                    this.reg.txt_PatientId.Text = smWorkList.PATIENT_ID;                 //病人ID
                    this.reg.txt_BedNum.Text = smWorkList.BED_NUM;
                    this.reg.txt_PatientPhonetic.Text = smWorkList.PATIENT_PHONETIC;     //姓名拼音
                    this.reg.txt_PatientName.Text = smWorkList.PATIENT_NAME;             //姓名            
                    this.reg.txt_InpNo.Text = smWorkList.INP_NO;                         //住院号
                    //this.reg.txt_IdentityCardNo.Text = smWorkList.IDENTITY_CARD_NO;     //身份证号
                    this.reg.cmb_BirthPlace.Text = smWorkList.BIRTH_PLACE;               //出生地
                    //this.BIRTH_PLACE_CODE = smWorkList.BIRTH_PLACE_CODE;
                    this.reg.txt_PatientIdentity.Text = smWorkList.PATIENT_IDENTITY;     //身份
                    this.reg.txt_MailingAddress.Text = smWorkList.MAILING_ADDRESS;       //邮箱地址
                    this.reg.txt_ZipCode.Text = smWorkList.ZIP_CODE;                     //邮编
                    this.reg.txt_TelephoneNum.Text = smWorkList.TELEPHONE_NUM;           //电话
                    this.reg.cmb_Sex.Text = smWorkList.PATIENT_SEX;                      //性别
                    this.reg.cmb_ChargeType.SelectedValue = smWorkList.CHARGE_TYPE;      //费别
                    this.reg.txt_ClinDiag.Text = smWorkList.CLIN_DIAG;                   //临床诊断
                    this.reg.cmb_ReferDept.SelectedValue = smWorkList.REFER_DEPT;
                    this.reg.cmb_ReferDept.Text = smWorkList.REQ_DEPT_NAME;
                    if (GetConfig.hisVisit)
                        switch (GetConfig.hisVender)
                        {
                            case "JW":
                                this.reg.regJW.Bind_ReferDoctor(smWorkList.REFER_DEPT, this.reg.cmb_ReferDoctor);
                                break;
                            case "HT":
                                break;
                        }
                    else
                        this.reg.regUPE.Bind_ReferDoctor(smWorkList.REFER_DEPT, this.reg.cmb_ReferDoctor);
                    CtlComboBox.SetDisplay(smWorkList.REFER_DOCTOR, this.reg.cmb_ReferDoctor);    //申请医生
                    //出生日期
                    if (smWorkList.PATIENT_BIRTH != null)
                        this.reg.dtp_Birth.Value = Convert.ToDateTime(smWorkList.PATIENT_BIRTH);
                    break;
                case "PACS":
                    PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.reg.iWorkList;
                    //this.EXAM_NO = mWorkList.EXAM_NO;                                 //检查序号  
                    this.reg.txt_PatientId.Text = pmWorkList.PATIENT_ID;                 //病人ID
                    this.reg.txt_BedNum.Text = pmWorkList.BED_NUM;
                    this.reg.txt_PatientPhonetic.Text = pmWorkList.PATIENT_PHONETIC;     //姓名拼音
                    this.reg.txt_PatientName.Text = pmWorkList.PATIENT_NAME;             //姓名            
                    this.reg.txt_InpNo.Text = pmWorkList.INP_NO;                         //住院号
                    //this.reg.txt_IdentityCardNo.Text = pmWorkList.IDENTITY_CARD_NO;     //身份证号
                    this.reg.cmb_BirthPlace.Text = pmWorkList.BIRTH_PLACE;               //出生地
                    //this.BIRTH_PLACE_CODE = pmWorkList.BIRTH_PLACE_CODE;
                    this.reg.txt_PatientIdentity.Text = pmWorkList.PATIENT_IDENTITY;     //身份
                    this.reg.txt_MailingAddress.Text = pmWorkList.MAILING_ADDRESS;       //邮箱地址
                    this.reg.txt_ZipCode.Text = pmWorkList.ZIP_CODE;                     //邮编
                    this.reg.txt_TelephoneNum.Text = pmWorkList.TELEPHONE_NUM;           //电话
                    this.reg.cmb_Sex.Text = pmWorkList.PATIENT_SEX;                      //性别
                    this.reg.cmb_ChargeType.SelectedValue = pmWorkList.CHARGE_TYPE;      //费别
                    this.reg.txt_ClinDiag.Text = pmWorkList.CLIN_DIAG;                   //临床诊断
                    this.reg.cmb_ReferDept.SelectedValue = pmWorkList.REFER_DEPT;
                    this.reg.cmb_ReferDept.Text = pmWorkList.REQ_DEPT_NAME;
                    if (GetConfig.hisVisit)
                        switch (GetConfig.hisVender)
                        {
                            case "JW":
                                this.reg.regJW.Bind_ReferDoctor(pmWorkList.REFER_DEPT, this.reg.cmb_ReferDoctor);
                                break;
                            case "HT":
                                break;
                        }
                    else
                        this.reg.regPacs.Bind_ReferDoctor(pmWorkList.REFER_DEPT, this.reg.cmb_ReferDoctor);
                    CtlComboBox.SetDisplay(pmWorkList.REFER_DOCTOR, this.reg.cmb_ReferDoctor);    //申请医生
                    //出生日期
                    if (pmWorkList.PATIENT_BIRTH != null)
                        this.reg.dtp_Birth.Value = Convert.ToDateTime(pmWorkList.PATIENT_BIRTH);
                    break;
            }
            this.reg.dtp_ReqDateTime.Enabled = true;
            CtlComboBox.SetDisplay("病房", this.reg.cmb_PatientSource);
            this.reg.cmb_PatientClass.SelectedIndex = 1;
            this.reg.cmb_PatientSource.Enabled = false;
            if (this.reg.cmb_ExamClass.Items.Count == 1)
                this.reg.cmb_ExamClass.SelectedIndex = 0;
            if (this.reg.Exam_Class.Length != 0)
                CtlComboBox.SetDisplay(this.reg.Exam_Class[0], this.reg.cmb_ExamClass);
            this.reg.isAdd = true;
            this.reg.dtp_ScheduledDate.Checked = false;     //add by liukun at 2010-7-30 预约时间默认为不选中
            this.reg.groupBox_OrderNotice.Enabled = false;  //add by liukun at 2010-7-30 预约注意事项默认为不编辑
        }

        /// <summary>
        /// 初始化模式4:绿色通道登记
        /// </summary>
        public void initMode4(string PatientId)
        {
            this.reg.Mode = "4";
            if (PatientId == "")
            {
                this.reg.lb_Notice.Text = "无ID病人登记";
                switch (GetConfig.DALAndModel)
                {
                    case "SIS":
                        SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.reg.iWorkList;
                        smWorkList.PATIENT_ID = this.reg.regUPE.NewPatientID();
                        this.reg.txt_PatientId.Text = smWorkList.PATIENT_ID;
                        break;
                    case "PACS":
                        PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.reg.iWorkList;
                        pmWorkList.PATIENT_ID = this.reg.regPacs.NewPatientID();
                        this.reg.txt_PatientId.Text = pmWorkList.PATIENT_ID;
                        break;
                }
                
            }
            else
                this.reg.lb_Notice.Text = "新病人登记";
            if (GetConfig.hisVisit)
                switch (GetConfig.hisVender)
                {
                    case "JW":
                        this.reg.setData.SetWorkListData("EXAM_NO", this.reg.regJW.GetExamNo(), this.reg.iWorkList);                       
                        break;
                    case "HT":
                        break;
                }
            CtlComboBox.SetDisplay("门诊", this.reg.cmb_PatientSource);
            //if (this.reg.FastRegDep.Length == 2)
            //{
            //    this.reg.cmb_ReferDept.Text = this.reg.FastRegDep[0];
            //    this.reg.cmb_ReferDept.SelectedValue = this.reg.FastRegDep[1];
            //}
            //this.reg.cmb_PatientClass.SelectedIndex = 0;
            //if (this.reg.cmb_ExamClass.Items.Count == 1)
            //    this.reg.cmb_ExamClass.SelectedIndex = 0;
            //if (this.reg.Exam_Class.Length != 0)
            //    SetComboBoxValue.SetDisplay(this.reg.Exam_Class[0], this.reg.cmb_ExamClass);
            //this.comb_Resource.Enabled = false;
            this.reg.isAdd = true;
            this.reg.SetDisable(true);
            this.reg.dtp_ScheduledDate.Checked = false;     //add by liukun at 2010-7-30 预约时间默认为不选中
            this.reg.groupBox_OrderNotice.Enabled = false;  //add by liukun at 2010-7-30 预约注意事项默认为不编辑
        }

        /// <summary>
        /// 初始化模式5:编辑状态(修改时用)
        /// </summary>
        public void initMode5(IModel iWorkList, bool isConfirmed, bool isSickRoom)
        {
            string ExamItems = "";
            decimal? Costs = 0;
            decimal? Charges = 0;
            this.reg.Mode = "6";
            this.reg.lb_Notice.Text = "编辑病人登记信息";
            string ExamAccessionNum = "";
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)iWorkList;
                    ExamAccessionNum = smWorkList.EXAM_ACCESSION_NUM;
                    this.reg.iArchives = this.reg.regUPE.GetArchives(smWorkList.PATIENT_ID);
                    this.reg.txt_PatientId.Text = smWorkList.PATIENT_ID;                 //病人ID
                    this.reg.dud_PatientLocalId.Text = smWorkList.PATIENT_LOCAL_ID;
                    this.reg.txt_BedNum.Text = smWorkList.BED_NUM;
                    this.reg.txt_PatientPhonetic.Text = smWorkList.PATIENT_PHONETIC;     //姓名拼音
                    this.reg.txt_PatientName.Text = smWorkList.PATIENT_NAME;             //姓名            
                    this.reg.txt_Age.Text = smWorkList.PATIENT_AGE.ToString();
                    this.reg.cmb_AgeUnit.Text = smWorkList.PATIENT_AGE_UNIT;
                    this.reg.txt_InpNo.Text = smWorkList.INP_NO;                         //住院号
                    //this.reg.txt_IdentityCardNo.Text = smWorkList.IDENTITY_CARD_NO;    //身份证号
                    this.reg.cmb_BirthPlace.Text = smWorkList.BIRTH_PLACE;               //出生地
                    //this.BIRTH_PLACE_CODE = smWorkList.BIRTH_PLACE_CODE;
                    this.reg.txt_PatientIdentity.Text = smWorkList.PATIENT_IDENTITY;     //身份
                    this.reg.txt_MailingAddress.Text = smWorkList.MAILING_ADDRESS;       //邮箱地址
                    this.reg.txt_ZipCode.Text = smWorkList.ZIP_CODE;                     //邮编
                    this.reg.txt_TelephoneNum.Text = smWorkList.TELEPHONE_NUM;           //电话
                    this.reg.cmb_Sex.Text = smWorkList.PATIENT_SEX;                      //性别
                    this.reg.txt_ClinDiag.Text = smWorkList.CLIN_DIAG;                   //临床诊断
                    this.reg.txt_ClinSymp.Text = smWorkList.CLIN_SYMP;
                    this.reg.txt_PhysSign.Text = smWorkList.PHYS_SIGN;
                    this.reg.txt_RelevantDiag.Text = smWorkList.RELEVANT_DIAG;
                    this.reg.txt_RelevantLabTest.Text = smWorkList.RELEVANT_LAB_TEST;
                    this.reg.txt_ReqMemo.Text = smWorkList.REQ_MEMO;
                    this.reg.txt_OutMedInstitution.Text = smWorkList.OUT_MED_INSTITUTION;
                    this.reg.cmb_ReferDept.SelectedValue = smWorkList.REFER_DEPT == null ? "" : smWorkList.REFER_DEPT;
                    this.reg.cmb_ReferDept.Text = smWorkList.REQ_DEPT_NAME;
                    this.reg.bindData.BindReferDoctor(smWorkList.REFER_DEPT, this.reg.cmb_ReferDoctor);
                    CtlComboBox.SetDisplay(smWorkList.REFER_DOCTOR, this.reg.cmb_ReferDoctor);    //申请医生
                    CtlComboBox.SetValue(smWorkList.CHARGE_TYPE.ToString(), this.reg.cmb_ChargeType);        //费别
                    this.reg.GetRegChargeRatio(smWorkList.CHARGE_TYPE);
                    CtlComboBox.SetValue(smWorkList.PATIENT_SOURCE, this.reg.cmb_PatientSource);  //病人来源
                    CtlComboBox.SetDisplay(smWorkList.EXAM_CLASS, this.reg.cmb_ExamClass);        //检查类别
                    this.reg.bindData.BindExamSubClass(smWorkList.EXAM_CLASS, this.reg.cmb_ExamSubClass);//绑定子类
                    CtlComboBox.SetDisplay(smWorkList.EXAM_SUB_CLASS, this.reg.cmb_ExamSubClass); //检查子类
                    this.reg.bindData.BindExamItems(smWorkList.EXAM_CLASS, smWorkList.EXAM_SUB_CLASS, this.reg.cmb_ExamItems);

                    CtlComboBox.SetDisplay(smWorkList.DEVICE, this.reg.cmb_ImgEquipment);         //检查设备
                    CtlComboBox.SetDisplay(smWorkList.EXAM_GROUP, this.reg.cmb_ExamGroup);        //检查组
                    if (smWorkList.EXAM_DEPT != "" || smWorkList.EXAM_DEPT != null)
                        CtlComboBox.SetValue(smWorkList.EXAM_DEPT, this.reg.cmb_ExamDept);        //检查科室
                    else
                        CtlComboBox.SetDisplay(smWorkList.EXAM_DEPT_NAME, this.reg.cmb_ExamDept);
                    this.reg.bindData.BindExamDoctor(smWorkList.EXAM_DEPT_NAME, this.reg.cmb_ExamDoctor);
                    CtlComboBox.SetDisplay(smWorkList.EXAM_DOCTOR, this.reg.cmb_ExamDoctor);
                    //InitExamItemsList(smWorkList.EXAM_ITEMS);
                    this.reg.txt_Costs.Text = smWorkList.COSTS.ToString();
                    this.reg.txt_Charges.Text = smWorkList.CHARGES.ToString();

                    this.reg.txt_OpdNo.Text = smWorkList.OPD_NO;
                    ExamItems = smWorkList.EXAM_ITEMS;
                    Costs = smWorkList.COSTS;
                    Charges = smWorkList.CHARGES;
                    //出生日期
                    if (smWorkList.PATIENT_BIRTH != null)
                        this.reg.dtp_Birth.Value = Convert.ToDateTime(smWorkList.PATIENT_BIRTH);
                    //申请时间
                    if (smWorkList.REQ_DATE_TIME != null)
                        this.reg.dtp_ReqDateTime.Value = Convert.ToDateTime(smWorkList.REQ_DATE_TIME);
                    //预约时间
                    if (smWorkList.SCHEDULED_DATE != null)
                        this.reg.dtp_ScheduledDate.Value = Convert.ToDateTime(smWorkList.SCHEDULED_DATE);
                    break;
                case "PACS":
                    PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)iWorkList;
                    ExamAccessionNum = pmWorkList.EXAM_ACCESSION_NUM;
                    this.reg.iArchives = this.reg.regPacs.GetPatientInf(pmWorkList.PATIENT_ID);
                    this.reg.txt_PatientId.Text = pmWorkList.PATIENT_ID;                 //病人ID
                    this.reg.dud_PatientLocalId.Text = pmWorkList.PATIENT_LOCAL_ID;
                    this.reg.txt_BedNum.Text = pmWorkList.BED_NUM;
                    this.reg.txt_PatientPhonetic.Text = pmWorkList.PATIENT_PHONETIC;     //姓名拼音
                    this.reg.txt_PatientName.Text = pmWorkList.PATIENT_NAME;             //姓名            
                    this.reg.txt_Age.Text = pmWorkList.PATIENT_AGE.ToString();
                    this.reg.cmb_AgeUnit.Text = pmWorkList.PATIENT_AGE_UNIT;
                    this.reg.txt_InpNo.Text = pmWorkList.INP_NO;                         //住院号
                    //this.reg.txt_IdentityCardNo.Text = pmWorkList.IDENTITY_CARD_NO;    //身份证号
                    this.reg.cmb_BirthPlace.Text = pmWorkList.BIRTH_PLACE;               //出生地
                    //this.BIRTH_PLACE_CODE = pmWorkList.BIRTH_PLACE_CODE;
                    this.reg.txt_PatientIdentity.Text = pmWorkList.PATIENT_IDENTITY;     //身份
                    this.reg.txt_MailingAddress.Text = pmWorkList.MAILING_ADDRESS;       //邮箱地址
                    this.reg.txt_ZipCode.Text = pmWorkList.ZIP_CODE;                     //邮编
                    this.reg.txt_TelephoneNum.Text = pmWorkList.TELEPHONE_NUM;           //电话
                    this.reg.cmb_Sex.Text = pmWorkList.PATIENT_SEX;                      //性别
                    this.reg.txt_ClinDiag.Text = pmWorkList.CLIN_DIAG;                   //临床诊断
                    this.reg.txt_ClinSymp.Text = pmWorkList.CLIN_SYMP;
                    this.reg.txt_PhysSign.Text = pmWorkList.PHYS_SIGN;
                    this.reg.txt_RelevantDiag.Text = pmWorkList.RELEVANT_DIAG;
                    this.reg.txt_RelevantLabTest.Text = pmWorkList.RELEVANT_LAB_TEST;
                    this.reg.txt_ReqMemo.Text = pmWorkList.REQ_MEMO;
                    this.reg.txt_OutMedInstitution.Text = pmWorkList.OUT_MED_INSTITUTION;
                    this.reg.cmb_ReferDept.SelectedValue = pmWorkList.REFER_DEPT == null ? "" : pmWorkList.REFER_DEPT;
                    this.reg.cmb_ReferDept.Text = pmWorkList.REQ_DEPT_NAME == null ? "" : pmWorkList.REQ_DEPT_NAME;
                    this.reg.bindData.BindReferDoctor(pmWorkList.REFER_DEPT, this.reg.cmb_ReferDoctor);
                    CtlComboBox.SetDisplay(pmWorkList.REFER_DOCTOR, this.reg.cmb_ReferDoctor);    //申请医生
                    CtlComboBox.SetValue(pmWorkList.CHARGE_TYPE.ToString(), this.reg.cmb_ChargeType);        //费别
                    this.reg.GetRegChargeRatio(pmWorkList.CHARGE_TYPE);
                    CtlComboBox.SetValue(pmWorkList.PATIENT_SOURCE, this.reg.cmb_PatientSource);  //病人来源
                    CtlComboBox.SetDisplay(pmWorkList.EXAM_CLASS, this.reg.cmb_ExamClass);        //检查类别
                    this.reg.bindData.BindExamSubClass(pmWorkList.EXAM_CLASS, this.reg.cmb_ExamSubClass);//绑定子类
                    CtlComboBox.SetDisplay(pmWorkList.EXAM_SUB_CLASS, this.reg.cmb_ExamSubClass); //检查子类
                    this.reg.bindData.BindExamItems(pmWorkList.EXAM_CLASS, pmWorkList.EXAM_SUB_CLASS, this.reg.cmb_ExamItems);
                    this.reg.bindData.BindDevice(pmWorkList.EXAM_CLASS, pmWorkList.EXAM_SUB_CLASS, this.reg.cmb_ImgEquipment);
                    CtlComboBox.SetDisplay(pmWorkList.DEVICE, this.reg.cmb_ImgEquipment);         //检查设备
                    // this.reg.cmb_ImgEquipment.Text = pmWorkList.DEVICE;
                    //InitExamItemsList(pmWorkList.EXAM_ITEMS);//初始化所有检查项目到项目列表中

                    CtlComboBox.SetDisplay(pmWorkList.EXAM_GROUP, this.reg.cmb_ExamGroup);        //检查组
                    if (pmWorkList.EXAM_DEPT != "" || pmWorkList.EXAM_DEPT != null)
                        CtlComboBox.SetValue(pmWorkList.EXAM_DEPT, this.reg.cmb_ExamDept);        //检查科室
                    else
                        CtlComboBox.SetDisplay(pmWorkList.EXAM_DEPT_NAME, this.reg.cmb_ExamDept);
                    this.reg.bindData.BindExamDoctor(pmWorkList.EXAM_DEPT_NAME, this.reg.cmb_ExamDoctor);
                    CtlComboBox.SetDisplay(pmWorkList.EXAM_DOCTOR, this.reg.cmb_ExamDoctor);
                    this.reg.txt_Costs.Text = pmWorkList.COSTS.ToString();
                    this.reg.txt_Charges.Text = pmWorkList.CHARGES.ToString();
                    this.reg.txt_OpdNo.Text = pmWorkList.OPD_NO;
                    //this.reg.txt_IdentityCardNo.Text=
                    ExamItems = pmWorkList.EXAM_ITEMS;
                    Costs = pmWorkList.COSTS;
                    Charges = pmWorkList.CHARGES;
                    //出生日期
                    if (pmWorkList.PATIENT_BIRTH != null)
                        this.reg.dtp_Birth.Value = Convert.ToDateTime(pmWorkList.PATIENT_BIRTH);
                    //申请日期
                    if (pmWorkList.REQ_DATE_TIME != null)
                        //预约日期
                        if (pmWorkList.SCHEDULED_DATE != null)
                            this.reg.dtp_ScheduledDate.Value = Convert.ToDateTime(pmWorkList.SCHEDULED_DATE);
                    break;
            }
            //if (!isConfirmed)
            //{
            System.Data.DataTable dt_ExamChargeList = new System.Data.DataTable();
            System.Data.DataTable dt_ExamItems = this.GetExamItems(ExamAccessionNum, ref dt_ExamChargeList);
            this.reg.computeCharge.Now_DT_VS_Old = dt_ExamChargeList;
            if (dt_ExamItems.Rows.Count > 0)
            {
                for (int j = 0; j < dt_ExamItems.Rows.Count; j++)
                {
                    System.Data.DataView dv = this.reg.computeCharge.Now_DT_VS_Old.DefaultView;
                    dv.RowFilter = " EXAM_ITEM_CODE = '" + dt_ExamItems.Rows[j]["EXAM_ITEM_CODE"].ToString() + "' and EXAM_ITEM_NO = " + dt_ExamItems.Rows[j]["EXAM_ITEM_NO"].ToString();
                    this.reg.computeCharge.Now_DT_VS_Group.Add(dv.ToTable());
                }
                InitExamItemsList(ExamItems);
            }
            else
            {
                switch (GetConfig.DALAndModel)
                {
                    case "SIS":
                        SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)iWorkList;
                        InitExamItemsList(smWorkList.EXAM_ITEMS);//初始化所有检查项目到项目列表中
                        this.reg.txt_Charges.Text = smWorkList.CHARGES.ToString();
                        this.reg.txt_Costs.Text = smWorkList.COSTS.ToString();
                        break;
                    case "PACS":
                        PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)iWorkList;
                        InitExamItemsList(pmWorkList.EXAM_ITEMS);//初始化所有检查项目到项目列表中
                        this.reg.txt_Charges.Text = pmWorkList.CHARGES.ToString();
                        this.reg.txt_Costs.Text = pmWorkList.COSTS.ToString();
                        break;
                }
            }
            //}
            //else
            //{
            //this.GetExamItems(ExamAccessionNum,ref null);
            //this.reg.newReg.SetEnable(false, isSickRoom);
            //}
            this.reg.txt_Costs.Text = Costs.ToString();
            this.reg.txt_Charges.Text = Charges.ToString();
            this.GetReqScanImages(ExamAccessionNum);
            this.reg.reqScanImage.LoadImages();
            this.reg.dtp_ReqDateTime.Enabled = true;
            this.reg.btn_NewPatientId.Enabled = false;
            this.reg.dtp_ScheduledDate.Enabled = true;
            this.reg.dtp_ScheduledDate.Checked = false; // add by liukun at 2010-6-30  默认不选中
            this.reg.btn_OpenRpt.Enabled = true;
            this.reg.iWorkList = iWorkList;
            this.reg.Mode = "5"; //登记模式转变状态
            this.reg.SetDisable(true);
            this.reg.IsCreated = false;
            this.reg.cmb_ExamItems.SelectedIndex = -1;
            this.reg.dtp_ScheduledDate.Checked = false;     //add by liukun at 2010-7-30 预约时间默认为不选中
            this.reg.groupBox_OrderNotice.Enabled = false;  //add by liukun at 2010-7-30 预约注意事项默认为不编辑
        }


        /// <summary>
        /// 编辑时初始化检查项目表
        /// </summary>
        private void InitExamItemsList(string items)
        {
            string[] Items = items.TrimEnd(';').Split(';');
            for (int i = 0; i < Items.Length; i++)
            {
                this.reg.AddExamItemList(Items[i],null,0);  //modify by liukun at 2010-06-10 增加后面两个传入参数，增加的传入参数无任何实际意义。
            }

        }
        private System.Data.DataTable GetExamItems(string ExamAccessionNum, ref System.Data.DataTable dt_ExamChargeList)
        {
            System.Data.DataTable dt_ExamItems = new System.Data.DataTable();
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    dt_ExamItems = this.reg.regUPE.GetExamItems(ExamAccessionNum);
                    dt_ExamChargeList = this.reg.regUPE.GetExamChargeList(ExamAccessionNum);
                    break;
                case "PACS":
                    dt_ExamItems = this.reg.regPacs.GetExamItems(ExamAccessionNum);
                    dt_ExamChargeList = this.reg.regPacs.GetExamChargeList(ExamAccessionNum);
                    break;
            }
            this.reg.lv_ExamItem.BeginUpdate();
            System.Data.DataSet ds = new System.Data.DataSet();
            for (int i = 0; i < dt_ExamItems.Rows.Count; i++)
            {
                string[] lvitem = new string[3];
                lvitem[0] = dt_ExamItems.Rows[i]["EXAM_ITEM"].ToString();
                decimal ItemCosts = 0;
                System.Data.DataRow[] drs = dt_ExamChargeList.Select("EXAM_ITEM_CODE = '" + dt_ExamItems.Rows[i]["EXAM_ITEM_CODE"].ToString() + "' and EXAM_ITEM_NO = "+dt_ExamItems.Rows[i]["EXAM_ITEM_NO"].ToString());
                for (int j = 0; j < drs.Length; j++)
                {
                    string price = drs[j]["PRICE"].ToString();
                    string Amount = (drs[j]["AMOUNT"].ToString() == "") ? "0" : drs[j]["AMOUNT"].ToString();
                    ItemCosts += Convert.ToDecimal(price) * Convert.ToDecimal(Amount);
                }
                decimal ItemCharges = ItemCosts * this.reg.computeCharge.chargeRatio;
                lvitem[1] = ItemCosts.ToString();
                lvitem[2] = ItemCharges.ToString();
                ListViewItem lvi = new ListViewItem(lvitem);
                this.reg.lv_ExamItem.Items.Add(lvi);
            }
            this.reg.lv_ExamItem.EndUpdate();
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

        /// <summary>
        /// 初始化模式6:相同病人登记 
        /// 执行相同病人时，必须产生新的检查序号，检查申请序号和检查实例UID，并在初始化模式6中，将新的覆盖旧的
        /// </summary>
        public void initMode6(IModel iWorkList, IModel iArchives)
        {
            this.reg.Mode = "6";
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)iWorkList;
                    SIS_Model.MWorkList NewsmWorkList = (SIS_Model.MWorkList)this.reg.iWorkList;
                    smWorkList.REPORT_STATUS = 0;//相同病人时报告状态为未写
                    smWorkList.EXAM_ACCESSION_NUM = NewsmWorkList.EXAM_ACCESSION_NUM;  //检查申请序号，将新产生的赋值
                    
                    //Begin 鉴于相同病人登记回写报告问题，增加以下关键修改
                    smWorkList.ACCESSION_NO = NewsmWorkList.ACCESSION_NO;   //检查流水号  Add at 2010-09-06
                    smWorkList.STUDY_INSTANCE_UID = NewsmWorkList.STUDY_INSTANCE_UID;     //检查实例UID，将新产生的赋值  Add at 2010-09-06
                    //End

                    this.reg.txt_PatientId.Text = smWorkList.PATIENT_ID;                 //病人ID
                    this.reg.dud_PatientLocalId.Text = smWorkList.PATIENT_LOCAL_ID;
                    this.reg.txt_BedNum.Text = smWorkList.BED_NUM;
                    this.reg.txt_PatientPhonetic.Text = smWorkList.PATIENT_PHONETIC;     //姓名拼音
                    this.reg.txt_PatientName.Text = smWorkList.PATIENT_NAME;             //姓名            
                    this.reg.txt_Age.Text = smWorkList.PATIENT_AGE.ToString();
                    this.reg.cmb_AgeUnit.Text = smWorkList.PATIENT_AGE_UNIT;
                    this.reg.txt_InpNo.Text = smWorkList.INP_NO;                         //住院号
                    //this.reg.txt_IdentityCardNo.Text = smWorkList.IDENTITY_CARD_NO;    //身份证号
                    this.reg.cmb_BirthPlace.Text = smWorkList.BIRTH_PLACE;               //出生地
                    //this.BIRTH_PLACE_CODE = smWorkList.BIRTH_PLACE_CODE;
                    this.reg.txt_PatientIdentity.Text = smWorkList.PATIENT_IDENTITY;     //身份
                    this.reg.txt_MailingAddress.Text = smWorkList.MAILING_ADDRESS;       //邮箱地址
                    this.reg.txt_ZipCode.Text = smWorkList.ZIP_CODE;                     //邮编
                    this.reg.txt_TelephoneNum.Text = smWorkList.TELEPHONE_NUM;           //电话
                    this.reg.cmb_Sex.Text = smWorkList.PATIENT_SEX;                      //性别
                    this.reg.txt_ClinDiag.Text = smWorkList.CLIN_DIAG;                   //临床诊断
                    this.reg.txt_ClinSymp.Text = smWorkList.CLIN_SYMP;
                    this.reg.txt_PhysSign.Text = smWorkList.PHYS_SIGN;
                    this.reg.txt_RelevantDiag.Text = smWorkList.RELEVANT_DIAG;
                    this.reg.txt_RelevantLabTest.Text = smWorkList.RELEVANT_LAB_TEST;
                    this.reg.txt_ReqMemo.Text = smWorkList.REQ_MEMO;
                    this.reg.txt_OutMedInstitution.Text = smWorkList.OUT_MED_INSTITUTION;
                    this.reg.cmb_ReferDept.SelectedValue = smWorkList.REFER_DEPT == null ? "" : smWorkList.REFER_DEPT;
                    this.reg.cmb_ReferDept.Text = smWorkList.REQ_DEPT_NAME;
                    this.reg.bindData.BindReferDoctor(smWorkList.REFER_DEPT, this.reg.cmb_ReferDoctor);
                    CtlComboBox.SetDisplay(smWorkList.REFER_DOCTOR, this.reg.cmb_ReferDoctor);    //申请医生
                    CtlComboBox.SetValue(smWorkList.CHARGE_TYPE.ToString(), this.reg.cmb_ChargeType);        //费别
                    this.reg.GetRegChargeRatio(smWorkList.CHARGE_TYPE);
                    CtlComboBox.SetValue(smWorkList.PATIENT_SOURCE, this.reg.cmb_PatientSource);  //病人来源
                    CtlComboBox.SetDisplay(smWorkList.EXAM_CLASS, this.reg.cmb_ExamClass);        //检查类别
                    this.reg.bindData.BindExamSubClass(smWorkList.EXAM_CLASS, this.reg.cmb_ExamSubClass);//绑定子类
                    CtlComboBox.SetDisplay(smWorkList.EXAM_SUB_CLASS, this.reg.cmb_ExamSubClass); //检查子类
                    this.reg.bindData.BindExamItems(smWorkList.EXAM_CLASS, smWorkList.EXAM_SUB_CLASS, this.reg.cmb_ExamItems);

                    CtlComboBox.SetDisplay(smWorkList.DEVICE, this.reg.cmb_ImgEquipment);         //检查设备
                    CtlComboBox.SetDisplay(smWorkList.EXAM_GROUP, this.reg.cmb_ExamGroup);        //检查组
                    if (smWorkList.EXAM_DEPT != "" || smWorkList.EXAM_DEPT != null)
                        CtlComboBox.SetValue(smWorkList.EXAM_DEPT, this.reg.cmb_ExamDept);        //检查科室
                    else
                        CtlComboBox.SetDisplay(smWorkList.EXAM_DEPT_NAME, this.reg.cmb_ExamDept);
                    this.reg.bindData.BindExamDoctor(smWorkList.EXAM_DEPT_NAME, this.reg.cmb_ExamDoctor);
                    CtlComboBox.SetDisplay(smWorkList.EXAM_DOCTOR, this.reg.cmb_ExamDoctor);
                    this.reg.txt_Costs.Text = "";
                    this.reg.txt_Charges.Text = "";

                    this.reg.txt_OpdNo.Text = smWorkList.OPD_NO;

                    //出生日期
                    if (smWorkList.PATIENT_BIRTH != null)
                        this.reg.dtp_Birth.Value = Convert.ToDateTime(smWorkList.PATIENT_BIRTH); ;
                    break;
                case "PACS":
                    PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)iWorkList;
                    PACS_Model.MWorkList NewpmWorkList = (PACS_Model.MWorkList)this.reg.iWorkList;
                    pmWorkList.REPORT_STATUS = 0;//相同病人时报告状态为未写
                    pmWorkList.EXAM_ACCESSION_NUM = NewpmWorkList.EXAM_ACCESSION_NUM;

                    //Begin 鉴于相同病人登记回写报告问题，增加以下关键修改
                    pmWorkList.ACCESSION_NO = NewpmWorkList.ACCESSION_NO;    //检查流水号  Add at 2010-09-06
                    pmWorkList.STUDY_INSTANCE_UID = NewpmWorkList.STUDY_INSTANCE_UID;     //检查实例UID，将新产生的赋值  Add at 2010-09-06
                    //End

                    this.reg.txt_PatientId.Text = pmWorkList.PATIENT_ID;                 //病人ID
                    this.reg.dud_PatientLocalId.Text = pmWorkList.PATIENT_LOCAL_ID;
                    this.reg.txt_BedNum.Text = pmWorkList.BED_NUM;
                    this.reg.txt_PatientPhonetic.Text = pmWorkList.PATIENT_PHONETIC;     //姓名拼音
                    this.reg.txt_PatientName.Text = pmWorkList.PATIENT_NAME;             //姓名            
                    this.reg.txt_Age.Text = pmWorkList.PATIENT_AGE.ToString();
                    this.reg.cmb_AgeUnit.Text = pmWorkList.PATIENT_AGE_UNIT;
                    this.reg.txt_InpNo.Text = pmWorkList.INP_NO;                         //住院号
                    //this.reg.txt_IdentityCardNo.Text = pmWorkList.IDENTITY_CARD_NO;    //身份证号
                    this.reg.cmb_BirthPlace.Text = pmWorkList.BIRTH_PLACE;               //出生地
                    //this.BIRTH_PLACE_CODE = pmWorkList.BIRTH_PLACE_CODE;
                    this.reg.txt_PatientIdentity.Text = pmWorkList.PATIENT_IDENTITY;     //身份
                    this.reg.txt_MailingAddress.Text = pmWorkList.MAILING_ADDRESS;       //邮箱地址
                    this.reg.txt_ZipCode.Text = pmWorkList.ZIP_CODE;                     //邮编
                    this.reg.txt_TelephoneNum.Text = pmWorkList.TELEPHONE_NUM;           //电话
                    this.reg.cmb_Sex.Text = pmWorkList.PATIENT_SEX;                      //性别
                    this.reg.txt_ClinDiag.Text = pmWorkList.CLIN_DIAG;                   //临床诊断
                    this.reg.txt_ClinSymp.Text = pmWorkList.CLIN_SYMP;
                    this.reg.txt_PhysSign.Text = pmWorkList.PHYS_SIGN;
                    this.reg.txt_RelevantDiag.Text = pmWorkList.RELEVANT_DIAG;
                    this.reg.txt_RelevantLabTest.Text = pmWorkList.RELEVANT_LAB_TEST;
                    this.reg.txt_ReqMemo.Text = pmWorkList.REQ_MEMO;
                    this.reg.txt_OutMedInstitution.Text = pmWorkList.OUT_MED_INSTITUTION;
                    this.reg.cmb_ReferDept.SelectedValue = pmWorkList.REFER_DEPT == null ? "" : pmWorkList.REFER_DEPT;
                    this.reg.cmb_ReferDept.Text = pmWorkList.REQ_DEPT_NAME == null ? "" : pmWorkList.REQ_DEPT_NAME;
                    this.reg.bindData.BindReferDoctor(pmWorkList.REFER_DEPT, this.reg.cmb_ReferDoctor);
                    CtlComboBox.SetDisplay(pmWorkList.REFER_DOCTOR, this.reg.cmb_ReferDoctor);    //申请医生
                    CtlComboBox.SetValue(pmWorkList.CHARGE_TYPE.ToString(), this.reg.cmb_ChargeType);        //费别
                    this.reg.GetRegChargeRatio(pmWorkList.CHARGE_TYPE);
                    CtlComboBox.SetValue(pmWorkList.PATIENT_SOURCE, this.reg.cmb_PatientSource);  //病人来源
                    CtlComboBox.SetDisplay(pmWorkList.EXAM_CLASS, this.reg.cmb_ExamClass);        //检查类别
                    this.reg.bindData.BindExamSubClass(pmWorkList.EXAM_CLASS, this.reg.cmb_ExamSubClass);//绑定子类
                    CtlComboBox.SetDisplay(pmWorkList.EXAM_SUB_CLASS, this.reg.cmb_ExamSubClass); //检查子类
                    this.reg.bindData.BindExamItems(pmWorkList.EXAM_CLASS, pmWorkList.EXAM_SUB_CLASS, this.reg.cmb_ExamItems);
                    this.reg.bindData.BindDevice(pmWorkList.EXAM_CLASS, pmWorkList.EXAM_SUB_CLASS, this.reg.cmb_ImgEquipment);
                    CtlComboBox.SetDisplay(pmWorkList.DEVICE, this.reg.cmb_ImgEquipment);         //检查设备
                    // this.reg.cmb_ImgEquipment.Text = pmWorkList.DEVICE;

                    CtlComboBox.SetDisplay(pmWorkList.EXAM_GROUP, this.reg.cmb_ExamGroup);        //检查组
                    if (pmWorkList.EXAM_DEPT != "" || pmWorkList.EXAM_DEPT != null)
                        CtlComboBox.SetValue(pmWorkList.EXAM_DEPT, this.reg.cmb_ExamDept);        //检查科室
                    else
                        CtlComboBox.SetDisplay(pmWorkList.EXAM_DEPT_NAME, this.reg.cmb_ExamDept);
                    this.reg.bindData.BindExamDoctor(pmWorkList.EXAM_DEPT_NAME, this.reg.cmb_ExamDoctor);
                    CtlComboBox.SetDisplay(pmWorkList.EXAM_DOCTOR, this.reg.cmb_ExamDoctor);
                    this.reg.txt_Costs.Text = pmWorkList.COSTS.ToString();
                    this.reg.txt_Charges.Text = pmWorkList.CHARGES.ToString();
                    this.reg.txt_OpdNo.Text = pmWorkList.OPD_NO;
                    //this.reg.txt_IdentityCardNo.Text=

                    //出生日期
                    if (pmWorkList.PATIENT_BIRTH != null)
                        this.reg.dtp_Birth.Value = Convert.ToDateTime(pmWorkList.PATIENT_BIRTH);
                    break;
            }
            if (this.reg.cmb_PatientSource.Text == "病房")
            {
                if (GetConfig.hisVisit)
                {
                    SelInpPat selnpPat = new SelInpPat();
                    if (!selnpPat.SearchPatsInHospital("PATIENT_ID ='" + this.reg.txt_PatientId.Text.ToString().Trim() + "'", iWorkList))
                        MessageBoxEx.Show("查找不到该病人的在院记录，将不能进行划价处理！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.reg.lb_Notice.Text = "住院病人登记";
                this.reg.Mode = "10";
            }
            else
            {
                this.reg.lb_Notice.Text = "门诊病人登记";
                this.reg.Mode = "00";
            }
            this.reg.iArchives = iArchives;
            this.reg.iWorkList = iWorkList;
            this.reg.dtp_ReqDateTime.Value = System.DateTime.Now;
            this.reg.dtp_ScheduledDate.Value = System.DateTime.Now;
            this.reg.dtp_ScheduledDate.Checked = false;     //add by liukun at 2010-7-30 预约时间默认为不选中
            this.reg.groupBox_OrderNotice.Enabled = false;  //add by liukun at 2010-7-30 预约注意事项默认为不编辑
        }

    }
}
