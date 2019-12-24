using System;
using System.Collections.Generic;
using System.Text;
using ILL;
using System.Windows.Forms;
using System.Data;

namespace SIS.RegisterCls
{
    public class BindData
    {
        //private SIS.Register.Register reg;
        private RegCls_HT regHT;
        private RegCls_JW regJW;
        private RegCls_Pacs regPacs;
        private RegCls_UPE regUPE;

        public BindData()
        {
            this.regHT = new RegCls_HT();
            this.regJW = new RegCls_JW();
            this.regPacs = new RegCls_Pacs();
            this.regUPE = new RegCls_UPE();
        }

        public void BindRegDatas(SIS.frmRegister reg)
        {
            reg.Mode = "6";
            if (GetConfig.hisVisit)
            {
                switch (GetConfig.hisVender)
                {
                    case "JW":
                        reg.computeCharge.DT_VS = this.regJW.Bind_ExamVsCharge();
                        reg.dt_ReferDept = this.regJW.Bind_ReferDept(reg.cmb_ReferDept);
                        this.regJW.Bind_ChargeType(reg.cmb_ChargeType);
                        break;
                    case "HT":
                        break;
                }
            }
            else
            {
                switch (GetConfig.DALAndModel)
                {
                    case "SIS":
                        reg.computeCharge.DT_VS = this.regUPE.Bind_ExamVsCharge();
                        reg.dt_ReferDept = this.regUPE.Bind_ReferDept(reg.cmb_ReferDept);
                        this.regUPE.Bind_ChargeType(reg.cmb_ChargeType);
                        break;
                    case "PACS":
                        reg.computeCharge.DT_VS = this.regPacs.Bind_ExamVsCharge();
                        reg.dt_ReferDept = this.regPacs.Bind_ReferDept(reg.cmb_ReferDept);
                        this.regPacs.Bind_ChargeType(reg.cmb_ChargeType);
                        break;
                }
            }
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    this.regUPE.Bind_ImgEquipment(reg.cmb_ImgEquipment,frmMainForm.iUser);
                    this.regUPE.Bind_ExamDept(reg.cmb_ExamDept);
                    this.regUPE.Bind_PatientSource(reg.cmb_PatientSource);
                    reg.dt_AREA = this.regUPE.Bind_AreaDict(reg.cmb_BirthPlace);
                    this.regUPE.Bind_ExamClass(reg.cmb_ExamClass, GetConfig.RM_RegisterMode);
                    this.regUPE.Bind_ExamGroup(reg.cmb_ExamGroup, reg.iUser,false);
                    break;
                case "PACS":
                    this.regPacs.Bind_ExamDept(reg.cmb_ExamDept);
                    this.regPacs.Bind_PatientSource(reg.cmb_PatientSource);
                    reg.dt_AREA = this.regPacs.Bind_AreaDict(reg.cmb_BirthPlace);
                    PACS_Model.MUser mUser = (PACS_Model.MUser)reg.iUser;
                    this.regPacs.Bind_ExamClass(mUser.DB_USER, reg.cmb_ExamClass, GetConfig.RM_RegisterMode);
                    this.regPacs.Bind_ExamGroup(reg.cmb_ExamGroup, reg.iUser,false);
                    break;
            }
            if (GetConfig.LM_IsLocalMode == 1 && GetConfig.LM_LocalIdMode != 0)
                reg.dud_PatientLocalId.ShowUpDownButton = true;
            else
                reg.dud_PatientLocalId.ShowUpDownButton = false;
        }

        /// <summary>
        /// 绑定诊室
        /// </summary>
        /// <param name="cmb_ExamGroup"></param>
        public void BindExamGroup(ComboBox cmb_ExamGroup)
        {
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    this.regUPE.Bind_ExamGroup(cmb_ExamGroup, frmMainForm.iUser,true);
                    break;
                case "PACS":
                    this.regPacs.Bind_ExamGroup(cmb_ExamGroup, frmMainForm.iUser,true);
                    break;
            }
        }

        /// <summary>
        /// 收费类别
        /// </summary>
        public void BindChargeType(ComboBox cmb_ChargeType)
        {
            if (GetConfig.hisVisit)
                switch (GetConfig.hisVender)
                {
                    case "JW":
                        this.regJW.Bind_ChargeType(cmb_ChargeType);
                        break;
                    case "HT":
                        break;
                }
            else
                switch (GetConfig.DALAndModel)
                {
                    case "SIS":
                        this.regUPE.Bind_ChargeType(cmb_ChargeType);
                        break;
                    case "PACS":
                        this.regPacs.Bind_ChargeType(cmb_ChargeType);
                        break;
                }
        }

        /// <summary>
        /// 病人来源
        /// </summary>
        public void BindPatientSource(ComboBox cmb_PatientSource)
        {
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    this.regUPE.Bind_PatientSource(cmb_PatientSource);
                    break;
                case "PACS":
                    this.regPacs.Bind_PatientSource(cmb_PatientSource);
                    break;
            }
        }

        /// <summary>
        /// 申请科室
        /// </summary>
        public DataTable BindReferDept(ComboBox cmb_ReferDept)
        {
            DataTable dt = new DataTable();
            if (GetConfig.hisVisit)
                switch (GetConfig.hisVender)
                {
                    case "JW":
                        dt = this.regJW.Bind_ReferDept(cmb_ReferDept);
                        break;
                    case "HT":
                        break;
                }
            else
                switch (GetConfig.DALAndModel)
                {
                    case "SIS":
                        dt = this.regUPE.Bind_ReferDept(cmb_ReferDept);
                        break;
                    case "PACS":
                        dt = this.regPacs.Bind_ReferDept(cmb_ReferDept);
                        break;
                }
            return dt;
        }

        /// <summary>
        /// 申请医生
        /// </summary>
        public void BindReferDoctor(string ReferDept,ComboBox cmb_ReferDoctor)
        {
            if (GetConfig.RM_HisApply)
                switch (GetConfig.hisVender)
                {
                    case "JW":
                        this.regJW.Bind_ReferDoctor(ReferDept, cmb_ReferDoctor);
                        break;
                    case "HT":
                        break;
                }
            else
                switch (GetConfig.DALAndModel)
                {
                    case "SIS":
                        this.regUPE.Bind_ReferDoctor(ReferDept, cmb_ReferDoctor);//2010-03-18
                        break;
                    case "PACS":
                        this.regPacs.Bind_ReferDoctor(ReferDept, cmb_ReferDoctor);
                        break;
                }
        }

        /// <summary>
        /// 检查类别
        /// </summary>
        public void BindExamClass(ComboBox cmb_ExamClass,int mode)
        {
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    this.regUPE.Bind_ExamClass(cmb_ExamClass,mode);
                    break;
                case "PACS":
                    PACS_Model.MUser mUser = (PACS_Model.MUser)frmMainForm.iUser;
                    this.regPacs.Bind_ExamClass(mUser.DB_USER, cmb_ExamClass,mode);
                    break;
            }
        }

        /// <summary>
        /// 绑定检查子类
        /// </summary>
        public void BindExamSubClass(string ExamClass,ComboBox cmb_ExamSubClass)
        {
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    this.regUPE.Bind_ExamSubClass(ExamClass, cmb_ExamSubClass);
                    break;
                case "PACS":
                    PACS_Model.MUser pmUser = (PACS_Model.MUser)frmMainForm.iUser;
                    this.regPacs.Bind_ExamSubClass(pmUser.DB_USER, ExamClass, cmb_ExamSubClass);
                    break;
            }
        }

        /// <summary>
        /// 绑定检查项目
        /// </summary>
        public DataTable BindExamItems(string ExamClass, string ExamSubClass, ComboBox cmb_ExamItems)
        {
            DataTable dt = new DataTable();
            switch (GetConfig.DALAndModel)
            {
                case "PACS":
                    if (GetConfig.hisVisit)
                        switch (GetConfig.hisVender)
                        {
                            case "JW":
                                dt = this.regJW.Bind_ExamItem(ExamClass, ExamSubClass, cmb_ExamItems);
                                break;
                            case "HT":
                                break;
                        }
                    else
                        dt = this.regPacs.Bind_ExamItem(ExamClass, ExamSubClass, cmb_ExamItems);
                    break;
                case "SIS":
                    if (GetConfig.hisVisit)
                        switch (GetConfig.hisVender)
                        {
                            case "JW":
                                dt = this.regJW.Bind_ExamItem(ExamClass, ExamSubClass, cmb_ExamItems);
                                break;
                            case "HT":
                                break;
                        }
                    else
                        dt = this.regUPE.Bind_ExamItem(ExamClass, ExamSubClass, cmb_ExamItems);
                    break;
            }
            return dt;
        }

        /// <summary>
        /// 绑定检查医生
        /// </summary>
        public void BindExamDoctor(string ExamDept,ComboBox cmb_ExamDoctor)
        {
            
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    this.regUPE.Bind_ExamDoctor(ExamDept, cmb_ExamDoctor);

                    break;
                case "PACS":
                    this.regPacs.Bind_ExamDoctor(ExamDept, cmb_ExamDoctor);
                    break;
            }
        }
        /// <summary>
        /// 显检查类别检查子类绑定设备
        /// </summary>
        public void BindDevice(string Exam_class, string Exam_sub_class, ComboBox cmb_ImgEquitment)
        {
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    this.regUPE.Bind_ImgEquipment(cmb_ImgEquitment,frmMainForm.iUser);
                    break;
                case "PACS":
                    this.regPacs.Bind_ImgEquipment(Exam_class, Exam_sub_class, cmb_ImgEquitment);
                    break;
            }
        }

        /// <summary>
        /// 获取检查项目与价表项目的对照表
        /// </summary>
        public DataTable BindExamVsCharge()
        {
            DataTable DT_VS = new DataTable();
            if (GetConfig.hisVisit)
            {
                switch (GetConfig.hisVender)
                {
                    case "JW":
                        DT_VS = this.regJW.Bind_ExamVsCharge();
                        break;
                    case "HT":
                        break;
                }
            }
            else
            {
                switch (GetConfig.DALAndModel)
                {
                    case "SIS":
                        DT_VS = this.regUPE.Bind_ExamVsCharge();
                        break;
                    case "PACS":
                        DT_VS = this.regPacs.Bind_ExamVsCharge();
                        break;
                }
            }
            return DT_VS;
        }
    }
}
