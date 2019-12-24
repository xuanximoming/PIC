using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ILL;
using SIS.Function;


namespace SIS.RegisterCls
{
    class Validity
    {
        /// <summary>
        /// 验证输入信息是否合法
        /// </summary>
        /// <returns>是否合法</returns>
        public bool CheckValidity(frmRegister reg)
        {
            string[] checkFields = GetConfig.RM_CheckField.Split(';');
            foreach (string field in checkFields)
            {
                switch (field)
                {
                    case "PATIENT_NAME":
                        if (reg.txt_PatientName.Text == null || reg.txt_PatientName.Text == "")
                        {
                            MessageBoxEx.Show("病人姓名不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        break;
                    case "PATIENT_ID":
                        if (reg.txt_PatientId.Text == null || reg.txt_PatientId.Text == "")
                        {
                            MessageBoxEx.Show("病人ID不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        break;
                    case "PATIENT_AGE":
                        if (reg.txt_Age.Text == "")
                        {
                            MessageBoxEx.Show("病人年龄不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        break;
                    case "PATIENT_AGE_UNIT":
                        if (reg.cmb_AgeUnit.Text == "")
                        {
                            MessageBoxEx.Show("病人年龄单位不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        break;
                    case "PATIENT_SEX":
                        if (reg.cmb_Sex.Text == "")
                        {
                            MessageBoxEx.Show("病人性别不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        break;
                    case "PATIENT_BIRTH":
                        if (reg.dtp_Birth.Text == "")
                        {
                            MessageBoxEx.Show("病人出生年龄不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        break;
                    case "PATIENT_PHONETIC":
                        if (reg.txt_PatientPhonetic.Text == "")
                        {
                            MessageBoxEx.Show("病人姓名拼音不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        break;
                    case "PATIENT_LOCAL_ID":
                        if (reg.dud_PatientLocalId.Text == "")
                        {
                            MessageBoxEx.Show("病人检查号不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        break;
                    case "CHARGE_TYPE":
                        if (reg.cmb_ChargeType.Text == "")
                        {
                            MessageBoxEx.Show("收费类别不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        break;
                    case "PATIENT_SOURCE":
                        if (reg.cmb_PatientSource.Text == "")
                        {
                            MessageBoxEx.Show("病人来源不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        break;
                    case "EXAM_CLASS":
                        if (reg.cmb_ExamClass.Text == "")
                        {
                            MessageBoxEx.Show("检查类别不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        break;
                    case "EXAM_SUB_CLASS":
                        if (reg.cmb_ExamSubClass.Text == "")
                        {
                            MessageBoxEx.Show("检查子类不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        break;
                    case "EXAM_ITEMS":
                        string examItems = "";
                        if (GetConfig.DALAndModel == "SIS")
                        {
                            SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)reg.iWorkList;
                            examItems = smWorkList.EXAM_ITEMS;
                        }
                        else
                        {
                            PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)reg.iWorkList;
                            examItems = pmWorkList.EXAM_ITEMS;
                        }
                        if (examItems == "")
                        {
                            MessageBoxEx.Show("检查项目不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        break;
                    case "EXAM_GROUP":
                        if (reg.cmb_ExamGroup.Text == "")
                        {
                            MessageBoxEx.Show("检查组不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        break;
                    case "DEVICE":
                        if (reg.cmb_ImgEquipment.Text == "")
                        {
                            MessageBoxEx.Show("检查设备不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        break;
                    case "REFER_DOCTOR":
                        if (reg.cmb_ReferDoctor.Text == "")
                        {
                            MessageBoxEx.Show("申请医生不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        break;
                    case "REFER_DEPT":
                        if (reg.cmb_ReferDept.Text == "")
                        {
                            MessageBoxEx.Show("申请科室不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        break;
                    case "COSTS":
                        if (reg.txt_Costs.Text == "")
                        {
                            MessageBoxEx.Show("标准收费不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        break;
                    case "CHARGES":
                        if (reg.txt_Charges.Text == "")
                        {
                            MessageBoxEx.Show("实收费用不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        break;
                }
            }
            return true;
        }

    }
}
