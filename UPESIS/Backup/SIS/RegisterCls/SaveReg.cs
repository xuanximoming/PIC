using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using ILL;
using SIS_BLL;

namespace SIS.RegisterCls
{
    public class SaveReg
    {
        private int chargeItemNo;
        private SIS.frmRegister reg;

        public SaveReg(SIS.frmRegister ss)
        {
            this.reg = ss;
        }

        public bool Save()
        {
            //登记模式: 00:门诊登记; 01:门诊检查申请; 10:住院登记; 
            //11:住院检查申请; 4:绿色通道登记; 5:编辑模式 6:初始化状态; 7:录入状态  
            bool success = false;
            switch (this.reg.Mode)
            {
                case "00":
                    success = this.Save00();//
                    break;
                case "01":
                    success = this.Save01();
                    break;
                case "10":
                    success = this.Save10();
                    break;
                case "11":
                    success = this.Save11();
                    break;
                case "4":
                    success = this.Save4();
                    break;
                case "5":
                    success = this.Save5();
                    break;
            }
            return success;
        }
        /// <summary>
        /// 00:门诊登记
        /// </summary>
        /// <returns></returns>
        private bool Save00()
        {
            if (!this.reg.localIdCreater.UpdatePatientInfLocalId(this.reg.iPatientInfLocalId))
                return false;
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    if (!SaveSIS())
                        return false;
                    break;
                case "PACS":
                    if (!SavePacs())
                        return false;
                    break;
            }
            this.reg.localIdCreater.ReSetLocalIdMax();
            return true;
        }
        /// <summary>
        ///  01:门诊检查申请;
        /// </summary>
        /// <returns></returns>
        private bool Save01()
        {
            if (!this.reg.localIdCreater.UpdatePatientInfLocalId(this.reg.iPatientInfLocalId))
                return false;
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    if (!SaveSIS())
                        return false;
                    break;
                case "PACS":
                    if (!SavePacs())
                        return false;
                    break;
            }
            if (GetConfig.hisVisit)
            {
                switch (GetConfig.hisVender)
                {
                    case "JW":
                        switch (GetConfig.DALAndModel)
                        {
                            case "SIS":
                                SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.reg.iWorkList;
                                this.reg.regJW.DeleteExamAppoints(smWorkList.EXAM_NO);//删除EXAM_APPOINTS表记录
                                break;
                            case "PACS":
                                PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.reg.iWorkList;
                                this.reg.regJW.DeleteExamAppoints(pmWorkList.EXAM_NO);//删除EXAM_APPOINTS表记录
                                break;
                        }
                        break;
                    case "HT":
                        break;
                }
            }
            this.reg.localIdCreater.ReSetLocalIdMax();
            return true;
        }
        /// <summary>
        ///  10:住院登记; 
        /// </summary>
        /// <returns></returns>
        private bool Save10()
        {
            if (GetConfig.hisVisit)
            {
                switch (GetConfig.hisVender)
                {
                    case "JW":
                        switch (GetConfig.DALAndModel)
                        {
                            case "SIS":
                                SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.reg.iWorkList;
                                this.chargeItemNo = this.reg.regJW.GetChargeItemNo(smWorkList.PATIENT_ID, smWorkList.VISIT_ID);
                                if (GetConfig.RM_INPIsConfirmed)
                                    if (!this.reg.regJW.AddInpBillDetail(this.reg.computeCharge.Now_DT_VS_Group, this.chargeItemNo, smWorkList.EXAM_DEPT, smWorkList.REFER_DEPT,
                                                                         this.reg.computeCharge.chargeRatio, smWorkList.PATIENT_ID, smWorkList.VISIT_ID, smWorkList.SCH_OPERATOR))
                                        return false;
                                break;
                            case "PACS":
                                PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.reg.iWorkList;
                                this.chargeItemNo = this.reg.regJW.GetChargeItemNo(pmWorkList.PATIENT_ID, pmWorkList.VISIT_ID);
                                if (GetConfig.RM_INPIsConfirmed)
                                    if (!this.reg.regJW.AddInpBillDetail(this.reg.computeCharge.Now_DT_VS_Group, this.chargeItemNo, pmWorkList.EXAM_DEPT, pmWorkList.REFER_DEPT,
                                                                         this.reg.computeCharge.chargeRatio, pmWorkList.PATIENT_ID, pmWorkList.VISIT_ID, pmWorkList.SCH_OPERATOR))
                                        return false;
                                break;
                        }
                        break;
                    case "HT":
                        break;
                }
            }
            if (!this.reg.localIdCreater.UpdatePatientInfLocalId(this.reg.iPatientInfLocalId))
                return false;
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    if (!SaveSIS())
                        return false;
                    break;
                case "PACS":
                    if (!SavePacs())
                        return false;
                    break;
            }
            this.reg.localIdCreater.ReSetLocalIdMax();
            return true;
        }
        /// <summary>
        /// 11:住院检查申请;
        /// </summary>
        /// <returns></returns>
        private bool Save11()
        {
            if (GetConfig.hisVisit)
            {
                switch (GetConfig.hisVender)
                {
                    case "JW":
                        switch (GetConfig.DALAndModel)
                        {
                            case "SIS":
                                SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.reg.iWorkList;
                                this.chargeItemNo = this.reg.regJW.GetChargeItemNo(smWorkList.PATIENT_ID, smWorkList.VISIT_ID);
                                if (GetConfig.RM_INPIsConfirmed)
                                    if (!this.reg.regJW.AddInpBillDetail(this.reg.computeCharge.Now_DT_VS_Group, this.chargeItemNo, smWorkList.EXAM_DEPT, smWorkList.REFER_DEPT,
                                                                         this.reg.computeCharge.chargeRatio, smWorkList.PATIENT_ID, smWorkList.VISIT_ID, smWorkList.SCH_OPERATOR))
                                        return false;
                                break;
                            case "PACS":
                                PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.reg.iWorkList;
                                this.chargeItemNo = this.reg.regJW.GetChargeItemNo(pmWorkList.PATIENT_ID, pmWorkList.VISIT_ID);
                                if (GetConfig.RM_INPIsConfirmed)
                                    if (!this.reg.regJW.AddInpBillDetail(this.reg.computeCharge.Now_DT_VS_Group, this.chargeItemNo, pmWorkList.EXAM_DEPT, pmWorkList.REFER_DEPT,
                                                                         this.reg.computeCharge.chargeRatio, pmWorkList.PATIENT_ID, pmWorkList.VISIT_ID, pmWorkList.SCH_OPERATOR))
                                        return false;
                                break;
                        }
                        break;
                    case "HT":
                        break;
                }
            }
            if (!this.reg.localIdCreater.UpdatePatientInfLocalId(this.reg.iPatientInfLocalId))
                return false;
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    if (!SaveSIS())
                        return false;
                    break;
                case "PACS":
                    if (!SavePacs())
                        return false;
                    break;
            }
            if (GetConfig.hisVisit)
            {
                switch (GetConfig.hisVender)
                {
                    case "JW":
                        switch (GetConfig.DALAndModel)
                        {
                            case "SIS":
                                SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.reg.iWorkList;
                                this.reg.regJW.DeleteExamAppoints(smWorkList.EXAM_NO);//删除EXAM_APPOINTS表记录
                                break;
                            case "PACS":
                                PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.reg.iWorkList;
                                this.reg.regJW.DeleteExamAppoints(pmWorkList.EXAM_NO);//删除EXAM_APPOINTS表记录
                                break;
                        }
                        break;
                    case "HT":
                        break;
                }
            }
            this.reg.localIdCreater.ReSetLocalIdMax();
            return true;
        }
       
        /// <summary>
        /// 4:绿色通道登记;
        /// </summary>
        /// <returns>是否保存成功</returns>
        private bool Save4()
        {
            if (!this.reg.localIdCreater.UpdatePatientInfLocalId(this.reg.iPatientInfLocalId))
                return false;
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    if (!SaveSIS())
                        return false;
                    break;
                case "PACS":
                    if (!SavePacs())
                        return false;
                    break;
            }
            this.reg.localIdCreater.ReSetLocalIdMax();
            return true;
        }

        private bool SaveSIS()
        {
            if (!this.reg.regUPE.SetPatientInf(this.reg.iArchives))
                return false;
            if (!this.reg.regUPE.AddExamChargeList(this.reg.computeCharge.Now_DT_VS_Group, this.chargeItemNo, this.reg.iWorkList, this.reg.computeCharge.chargeRatio))
                return false;
            if (!this.reg.regUPE.AddWorkList(this.reg.iWorkList))
                return false;
            return true;
        }

        private bool SavePacs()
        {
            if (!this.reg.regPacs.SetPatientInf(this.reg.iArchives))
                return false;
            if (!this.reg.regPacs.AddExamChargeList(this.reg.computeCharge.Now_DT_VS_Group, this.chargeItemNo, this.reg.iWorkList, this.reg.computeCharge.chargeRatio))
                return false;
            if (!this.reg.regPacs.AddWorkList(this.reg.iWorkList))
                return false;
            return true;
        }
        /// <summary>
        /// 修改时调用,对应保存模式5
        /// </summary>
        /// <returns>是否保存成功</returns>
        public bool Save5()
        {
            if (!this.reg.localIdCreater.UpdatePatientInfLocalId(this.reg.iPatientInfLocalId))
                return false;
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    if (!this.reg.regUPE.SetPatientInf(this.reg.iArchives))
                        return false;
                    if (!this.reg.regUPE.UpdateWorkList(this.reg.iWorkList))
                        return false;
                    if (!this.reg.regUPE.SetExamChargeList(this.reg.iWorkList, this.reg.computeCharge.Now_DT_VS_Old, this.reg.computeCharge.Now_DT_VS_Group, this.reg.computeCharge.chargeRatio))
                        return false;
                    break;
                case "PACS":
                    if (!this.reg.regPacs.SetPatientInf(this.reg.iArchives))
                        return false;
                    if (!this.reg.regPacs.UpdateWorkList(this.reg.iWorkList))
                        return false;
                    if (!this.reg.regPacs.SetExamChargeList(this.reg.iWorkList, this.reg.computeCharge.Now_DT_VS_Old, this.reg.computeCharge.Now_DT_VS_Group, this.reg.computeCharge.chargeRatio))
                        return false;
                    break;
            }
            this.reg.localIdCreater.ReSetLocalIdMax();
            return true;
        }
        /// <summary>
        /// 保存申请单图片
        /// </summary>
        /// <returns>是否保存成功</returns>
        public bool SaveReqScanImages()
        {
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.reg.iWorkList;
                    SIS_Model.MUser smUser = (SIS_Model.MUser)this.reg.iUser;
                    return this.reg.reqScanImage.SaveScanImg(smWorkList.EXAM_ACCESSION_NUM, smUser.DOCTOR_ID);
                case "PACS":
                    PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.reg.iWorkList;
                    PACS_Model.MUser pmUser = (PACS_Model.MUser)this.reg.iUser;
                    return this.reg.reqScanImage.SaveScanImg(pmWorkList.EXAM_ACCESSION_NUM, pmUser.DB_USER);
                default:
                    return false;
            }
        }

    }
}
