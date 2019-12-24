﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SIS_BLL;
using ILL;
using SIS_Model;
using System.Collections;
using System.Data;

namespace SIS.RegisterCls
{
    public class RegCls_UPE : DBControl 
    {
        public RegCls_UPE()
            : base(GetConfig.GetSisConnStr())
        {
        }
        /// <summary>
        /// 绑定申请科室
        /// </summary>
        public System.Data.DataTable Bind_ReferDept(ComboBox cmb_ReferDept)
        {
            string sql = "select CLINIC_OFFICE,CLINIC_OFFICE_CODE,CLINIC_OFFICE_PYCODE as INPUT_CODE from CLINIC_OFFICE_DICT where CLINIC_OFFICE_FLAG = 'CD'";
            System.Data.DataTable dt = GetDataSet(sql).Tables[0];
            cmb_ReferDept.DataSource = dt.DefaultView;
            cmb_ReferDept.DisplayMember = dt.Columns["CLINIC_OFFICE"].ColumnName;
            cmb_ReferDept.ValueMember = dt.Columns["CLINIC_OFFICE_CODE"].ColumnName;
            return dt;
        }

        /// <summary>
        /// 绑定费别
        /// </summary>
        public void Bind_ChargeType(ComboBox cmb_ChargeType)
        {
            BChargeClass bChargeClass = new BChargeClass();
            System.Data.DataTable dt = bChargeClass.GetList("1=1");
            cmb_ChargeType.DataSource = dt;
            cmb_ChargeType.DisplayMember = dt.Columns["CHARGE_CLASS"].ColumnName;
            cmb_ChargeType.ValueMember = dt.Columns["CHARGE_CLASS_ID"].ColumnName;
            //this.charge_ratio = 0;
            //Get_Charges();//当前选中的费别率×费用
        }

        /// <summary>
        /// 绑定检查科室
        /// </summary>
        public void Bind_ExamDept(ComboBox cmb_ExamDept)
        {
            BClinicOfficeDict bClinicOfficeDept = new BClinicOfficeDict();
            System.Data.DataTable dt = bClinicOfficeDept.GetList("CLINIC_OFFICE_FLAG = 'RY'");
            cmb_ExamDept.DataSource = dt;
            cmb_ExamDept.DisplayMember = dt.Columns["CLINIC_OFFICE"].ColumnName;
            cmb_ExamDept.ValueMember = dt.Columns["CLINIC_OFFICE_CODE"].ColumnName;
        }

        /// <summary>
        /// 绑定检查组(诊室)
        /// </summary>
        public void Bind_ExamGroup(ComboBox cmb_ExamGroup,IModel iUser,bool isAddBlank)
        {
            BDeptVsQueue bDeptVsQueue = new BDeptVsQueue();
            SIS_Model.MUser mUser = (SIS_Model.MUser)iUser;
            DataTable dt = bDeptVsQueue.GetList("DEPT_CODE = '"+mUser.CLINIC_OFFICE_CODE+"'");
            if (isAddBlank)
            {
                DataRow dr = dt.NewRow();
                dr["QUEUE_ID"] = 0;
                dr["DEPT_CODE"] = "";
                dr["QUEUE_NAME"] = "";
                dt.Rows.InsertAt(dr, 0);
            }
            cmb_ExamGroup.DataSource = dt;
            cmb_ExamGroup.DisplayMember = dt.Columns["QUEUE_NAME"].ColumnName;
        }

        /// <summary>
        /// 绑定病人来源
        /// </summary>
        public void Bind_PatientSource(ComboBox comb_PatientSource)
        {
            BPatientSource bPatientSource = new BPatientSource();
            System.Data.DataTable dt = bPatientSource.GetList("1=1");
            comb_PatientSource.DataSource = dt;
            comb_PatientSource.DisplayMember = dt.Columns["PATIENT_SOURCE"].ColumnName;
            comb_PatientSource.ValueMember = dt.Columns["PATIENT_SOURCE_ID"].ColumnName;
        }

        /// <summary>
        /// 绑定出生地
        /// </summary>
        public System.Data.DataTable Bind_AreaDict(ComboBox cmb_AreaDict)
        {
            BAreaDict bAreaDict = new BAreaDict();
            System.Data.DataTable dt = bAreaDict.GetList("1=1");
            cmb_AreaDict.DataSource = dt;
            cmb_AreaDict.DisplayMember = dt.Columns["AREA_NAME"].ColumnName;
            cmb_AreaDict.ValueMember = dt.Columns["AREA_CODE"].ColumnName;
            return dt;
        }

        /// <summary>
        /// 检查类别根据配置文件RegisterSettings.ini绑定
        /// </summary>
        public void Bind_ExamClass(ComboBox cmb_ExamClass,int mode)
        {
            System.Data.DataTable dt_ExamClass = new System.Data.DataTable();
            switch (mode)
            {
                case 0:
                    string ExamClass = GetConfig.RM_ExamClass;
                    string[] ary = ExamClass.Split(','); 
                    dt_ExamClass.Columns.Add("ExamClass");
                    for (int i = 0; i < ary.Length; i++)
                    {
                        System.Data.DataRow mydatarow = dt_ExamClass.NewRow();
                        mydatarow["ExamClass"] = ary[i];
                        dt_ExamClass.Rows.Add(mydatarow);
                    }
                    cmb_ExamClass.DataSource = dt_ExamClass;
                    cmb_ExamClass.DisplayMember = dt_ExamClass.Columns["ExamClass"].ColumnName;
                    break;
                case 1:
                    //IsMode1 = true;
                    //string ExamClass_sql = "select distinct EXAM_CLASS from USER_EXAM_CLASS where DB_USER='" + this.mainForm.userInf.DB_USER + "'";
                    //dt_ExamClass = DBoperate.OdbcDaAd(ExamClass_sql, this.connOdbc).Tables[0];
                    //comb_ExamClass.DataSource = dt_ExamClass;
                    break;
                case 2:
                    //检查类别
                    BExamClass bExamClass = new BExamClass();
                    System.Data.DataTable dt = bExamClass.GetList("1=1");
                    cmb_ExamClass.DataSource = dt;
                    cmb_ExamClass.DisplayMember = dt.Columns["EXAM_CLASS"].ColumnName;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 根据检查类别绑定检查子类
        /// </summary>
        public void Bind_ExamSubClass(string ExamClass, ComboBox cmb_ExamSubClass)
        {
            System.Data.DataTable dt;
            if (GetConfig.RM_RegisterMode == 1)
            {
                //string sql = "select distinct EXAM_SUB_CLASS from USER_EXAM_CLASS where DB_USER='" + this.mainForm.userInf.DB_USER + "' and EXAM_CLASS='" + comb_ExamClass.Text.ToString() + "'";
                //dt = DBoperate.OdbcDaAd(sql, this.connOdbc).Tables[0];
                //cmb_ExamSubClass.DataSource = dt;
                //cmb_ExamSubClass.DisplayMember = dt.Columns["EXAM_SUB_CLASS"].ColumnName;
            }
            else
            {
                BExamClass bExamClass = new BExamClass();
                dt = bExamClass.GetList(" EXAM_CLASS ='" + ExamClass + "' order by SORT_ID");
                cmb_ExamSubClass.DataSource = dt;
                cmb_ExamSubClass.DisplayMember = dt.Columns["EXAM_SUB_CLASS"].ColumnName;
            }
            //if (cmb_ExamSubClass.Items.Count == 1)
            //{
            //    this.cmb_ExamSubClass.SelectedIndex = 0;
            //    this.comb_Sub_Class_SelectionChangeCommitted(null, null);
            //}
            //else
            //{
            //    this.cmb_ExamSubClass.SelectedIndex = -1;
            //}
        }

        /// <summary>
        /// 绑定申请医生
        /// </summary>
        /// <returns></returns>
        public void Bind_ReferDoctor(string ReferDept, ComboBox cmb_ReferDoctor)
        {
            if (ReferDept!=null &&ReferDept != "")
            {
                BClinicDoctorDict bClinicDoctorDict = new BClinicDoctorDict();
                string strWhere="";
                if (GetConfig.DALAndModel == "SIS")
                    strWhere = " CLINIC_OFFICE_ID = " + ReferDept;
                else
                    strWhere = " USER_DEPT='" + ReferDept+"'";
                System.Data.DataTable dt = bClinicDoctorDict.GetList(strWhere);
                cmb_ReferDoctor.DataSource = dt;
                if (GetConfig.DALAndModel == "SIS")
                cmb_ReferDoctor.DisplayMember = dt.Columns["CLINIC_DOCTOR"].ColumnName;
                else
                cmb_ReferDoctor.DisplayMember = dt.Columns["USER_NAME"].ColumnName;
            }
        }

        /// <summary>
        /// 绑定检查医生
        /// </summary>
        /// <returns></returns>
        public void Bind_ExamDoctor(string ExamDept, ComboBox cmb_ExamDoctor)
        {
            BUser bUser = new BUser();
            System.Data.DataTable dt = bUser.GetList("CLINIC_OFFICE = '" + ExamDept + "'");
            cmb_ExamDoctor.DataSource = dt;
            cmb_ExamDoctor.DisplayMember = dt.Columns["DOCTOR_NAME"].ColumnName;
            cmb_ExamDoctor.ValueMember = dt.Columns["DOCTOR_ID"].ColumnName;
            cmb_ExamDoctor.SelectedIndex = -1;
        }

        /// <summary>
        /// 检查类别、检查子类检索表EXAM_ITEM_DICT得到数据集绑定至检查项目列表中
        /// </summary>
        public System.Data.DataTable Bind_ExamItem(string ExamClass, string ExamSubClass, ComboBox cmb_ExamItem)
        {
            BExamItemDict bExamItemDict = new BExamItemDict();
            System.Data.DataTable dt = bExamItemDict.GetList("EXAM_CLASS='" + ExamClass + "' and EXAM_SUB_CLASS='" + ExamSubClass + "' order by SORT_ID");
            if (GetConfig.RM_ExamItemSort)
                if (GetConfig.RM_ExamItemSort)
                {
                    ExamItemSorter examItemSorter = new ExamItemSorter();
                    dt = examItemSorter.ExamItemSort(ExamClass, ExamSubClass, dt);
                }
            cmb_ExamItem.DataSource = dt.DefaultView;
            cmb_ExamItem.DisplayMember = dt.Columns["EXAM_ITEM_NAME"].ColumnName;
            cmb_ExamItem.ValueMember = dt.Columns["EXAM_ITEM_CODE"].ColumnName;
            return dt;
            //this.Now_DT_VS_Group = new System.Data.DataTable[dt.Rows.Count];
        }

        /// <summary>
        /// 绑定影像设备
        /// </summary>
        /// <returns></returns>
        public void Bind_ImgEquipment(ComboBox cmb_ImgEquipment,IModel iUser)
        {
            BImgEquipment bImgEquipment = new BImgEquipment();
            MUser user = (MUser)iUser;
            System.Data.DataTable dt = bImgEquipment.GetList(" CLINIC_OFFICE_CODE = '" + user.CLINIC_OFFICE_CODE + "'");
            cmb_ImgEquipment.DataSource = dt.DefaultView;
            cmb_ImgEquipment.DisplayMember = dt.Columns["IMG_EQUIPMENT_NAME"].ColumnName;
            cmb_ImgEquipment.ValueMember = dt.Columns["IMG_EQUIPMENT_ID"].ColumnName;
        }

        /// <summary>
        /// 获取收费类别百分比
        /// </summary>
        public decimal GetChargeRatio(string ChargeClassID)
        {
            string sql = "select CHARGE_RATIO from CHARGE_CLASS where CHARGE_CLASS_ID  = '" + ChargeClassID + "'";
            string ratio = ExecuteScalar(sql);
            decimal chargeRatio = 1;
            if (ratio != "")
                chargeRatio = decimal.Parse(ratio);
            return chargeRatio;
        }

        /// <summary>
        /// 关联两表HIS价表和EXAM_VS_CHARGE取得数据集并填充Datatable
        /// </summary>
        public System.Data.DataTable Bind_ExamVsCharge_His(System.Data.DataTable dt_CurrentPriceList)
        {
            BExamVsCharge bExamVsCharge = new BExamVsCharge();
            System.Data.DataTable dt = new System.Data.DataTable();
            System.Data.DataTable dt_ExamVsCharge = bExamVsCharge.GetList("1=1");
            int i = 0;
            dt.Columns.Add(new System.Data.DataColumn("CLASS_NAME", dt_CurrentPriceList.Columns["CLASS_NAME"].DataType));
            dt.Columns.Add(new System.Data.DataColumn("ITEM_CLASS", dt_CurrentPriceList.Columns["ITEM_CLASS"].DataType));
            dt.Columns.Add(new System.Data.DataColumn("ITEM_NAME", dt_CurrentPriceList.Columns["ITEM_NAME"].DataType));
            dt.Columns.Add(new System.Data.DataColumn("ITEM_SPEC", dt_CurrentPriceList.Columns["ITEM_SPEC"].DataType));
            dt.Columns.Add(new System.Data.DataColumn("AMOUNT", dt_ExamVsCharge.Columns["AMOUNT"].DataType));
            dt.Columns.Add(new System.Data.DataColumn("UNITS", dt_CurrentPriceList.Columns["UNITS"].DataType));
            dt.Columns.Add(new System.Data.DataColumn("PRICE", dt_CurrentPriceList.Columns["PRICE"].DataType));
            dt.Columns.Add(new System.Data.DataColumn("EXAM_ITEM_CODE", dt_ExamVsCharge.Columns["EXAM_ITEM_CODE"].DataType));
            dt.Columns.Add(new System.Data.DataColumn("ITEM_CODE", dt_CurrentPriceList.Columns["ITEM_CODE"].DataType));
            dt.Columns.Add(new System.Data.DataColumn("COSTS", dt_CurrentPriceList.Columns["PRICE"].DataType));
            dt.Columns.Add(new System.Data.DataColumn("CHARGES", dt_CurrentPriceList.Columns["PRICE"].DataType));
            dt.Columns.Add(new System.Data.DataColumn("CHARGE_ITEM_NO", dt_ExamVsCharge.Columns["CHARGE_ITEM_NO"].DataType));
            dt.Columns.Add(new System.Data.DataColumn("INPUT_CODE", dt_CurrentPriceList.Columns["INPUT_CODE"].DataType));
            System.Data.DataRow[] Rows;
            for (i = 0; i < dt_ExamVsCharge.Rows.Count; i++)
            {
                Rows = dt_CurrentPriceList.Select("ITEM_CODE='" + dt_ExamVsCharge.Rows[i]["CHARGE_ITEM_CODE"].ToString() + "' and ITEM_SPEC = '" + dt_ExamVsCharge.Rows[i]["CHARGE_ITEM_SPEC"].ToString() + "' and UNITS ='" + dt_ExamVsCharge.Rows[i]["UNITS"].ToString() + "'");
                foreach (System.Data.DataRow drow in Rows)
                {
                    decimal amount = dt_ExamVsCharge.Rows[i]["AMOUNT"].ToString() == "" ? 0 : decimal.Parse(dt_ExamVsCharge.Rows[i]["AMOUNT"].ToString());
                    decimal costs = amount * decimal.Parse(drow["PRICE"].ToString());
                    dt.Rows.Add(new object[] { drow["CLASS_NAME"], drow["ITEM_CLASS"], drow["ITEM_NAME"], drow["ITEM_SPEC"], dt_ExamVsCharge.Rows[i]["AMOUNT"], drow["UNITS"], drow["PRICE"], dt_ExamVsCharge.Rows[i]["EXAM_ITEM_CODE"], drow["ITEM_CODE"], costs, costs, dt_ExamVsCharge.Rows[i]["CHARGE_ITEM_NO"], drow["INPUT_CODE"] });
                }
            }
            return dt;
        }

        /// <summary>
        /// 关联两表CHARGE_ITEM_DICT_VIEW和EXAM_VS_CHARGE取得数据集并填充Datatable
        /// </summary>
        public System.Data.DataTable Bind_ExamVsCharge()
        {
            string sql = "select " +
                         "c.CLASS_NAME," +
                         "CHARGE_ITEM_CLASS as ITEM_CLASS," +
                         "CHARGE_ITEM_NAME as ITEM_NAME," +
                         "b.CHARGE_ITEM_SPEC as ITEM_SPEC," +
                         "AMOUNT," +
                         "b.UNITS," +
                         "PRICE," +
                         "EXAM_ITEM_CODE," +
                         "b.CHARGE_ITEM_CODE as ITEM_CODE," +
                         "PRICE*AMOUNT as COSTS," +
                         "PRICE*AMOUNT as CHARGES," +
                         "b.CHARGE_ITEM_NO," +
                         "INPUT_CODE " +
                         "from CHARGE_ITEM_DICT_VIEW a,EXAM_VS_CHARGE b,CHARGE_ITEM_CLASS_DICT c " +
                         "where b.CHARGE_ITEM_CODE=a.CHARGE_ITEM_CODE " +
                         "and b.CHARGE_ITEM_SPEC=a.CHARGE_ITEM_SPEC " +
                         "and a.CHARGE_ITEM_CLASS=c.CLASS_CODE " +
                         "and b.UNITS=a.UNITS";
            System.Data.DataTable dt = GetDataSet(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 获取检查申请号
        /// </summary>
        /// <returns></returns>
        public string GetAccessionNo()
        {
            //生成ACCESSION_NO，EXAM_ACCESSION_NO，STUDY_INSTANCE_UID
            BGetSeqValue bGetSeqValue = new BGetSeqValue("SIS", "exam_accession_num_seq");
            return bGetSeqValue.GetSeqValue();
        }

        /// <summary>
        /// 生成新PATIENT_ID
        /// </summary>
        public string NewPatientID()
        {
            string NewPatientID = "";
            BGetSeqValue bGetSeqValue = new BGetSeqValue("SIS", "patient_id_seq");
            string P_seq_no= bGetSeqValue.GetSeqValue();
            NewPatientID = GetConfig.RM_PatientIdHeader + P_seq_no;
            return NewPatientID;
        }

        /// <summary>
        ///  更新检查费用明细表记录
        /// </summary>
        /// <param name="iWorklist"></param>
        /// <param name="Now_DT_VS_Old"></param>
        /// <param name="Now_DT_VS_Group"></param>
        /// <param name="chargeRatio"></param>
        /// <returns></returns>
        public bool SetExamChargeList(IModel iWorklist, System.Data.DataTable Now_DT_VS_Old, List<System.Data.DataTable> Now_DT_VS_Group, decimal chargeRatio)
        {
            MWorkList mWorkList = (MWorkList)iWorklist;
            int i = 0, j = 0;
            BExamChargeList bExamChargeList = new BExamChargeList();
            j = bExamChargeList.Delete(" where EXAM_NO ='" + mWorkList.EXAM_ACCESSION_NUM + "'");
            if (j < 0)
                return false;
            for (i = 0; i < Now_DT_VS_Group.Count; i++)
            {
                if (Now_DT_VS_Group[i] != null)
                {
                    Hashtable ht = new Hashtable();
                    for (j = 0; j < Now_DT_VS_Group[i].Rows.Count; j++)
                    {
                        MExamChargeList mExamChargeList = new MExamChargeList();
                        mExamChargeList.AMOUNT = Convert.ToInt32(Now_DT_VS_Group[i].Rows[j]["AMOUNT"].ToString());
                        mExamChargeList.CHARGE = Convert.ToDecimal(Now_DT_VS_Group[i].Rows[j]["COSTS"].ToString()) * chargeRatio;
                        mExamChargeList.CHARGE_CLASS_NAME = Now_DT_VS_Group[i].Rows[j]["CLASS_NAME"].ToString();
                        mExamChargeList.CHARGE_ITEM_CLASS = Now_DT_VS_Group[i].Rows[j]["ITEM_CLASS"].ToString();
                        mExamChargeList.CHARGE_ITEM_CODE = Now_DT_VS_Group[i].Rows[j]["ITEM_CODE"].ToString();
                        mExamChargeList.CHARGE_ITEM_NO = j + 1;
                        mExamChargeList.CHARGE_ITEM_SPEC = Now_DT_VS_Group[i].Rows[j]["ITEM_SPEC"].ToString();
                        mExamChargeList.COST = Convert.ToDecimal(Now_DT_VS_Group[i].Rows[j]["COSTS"].ToString());
                        mExamChargeList.PRICE = Convert.ToDecimal(Now_DT_VS_Group[i].Rows[j]["PRICE"].ToString());
                        mExamChargeList.EXAM_NO = mWorkList.EXAM_ACCESSION_NUM;
                        mExamChargeList.EXAM_CONFIRM_TIME = DateTime.Now;
                        mExamChargeList.EXAM_ITEM_CODE = Now_DT_VS_Group[i].Rows[j]["EXAM_ITEM_CODE"].ToString();
                        mExamChargeList.ITEM_NO = 0;
                        mExamChargeList.PATIENT_ID = mWorkList.PATIENT_ID;
                        mExamChargeList.UNITS = Now_DT_VS_Group[i].Rows[j]["UNITS"].ToString();
                        mExamChargeList.CHARGE_ITEM_NAME = Now_DT_VS_Group[i].Rows[j]["ITEM_NAME"].ToString();
                        mExamChargeList.EXAM_ITEM_NO = i + 1;
                        ht.Add(j, mExamChargeList);
                    }
                    if (ht.Count > 0)
                    {
                        int k = bExamChargeList.AddMore(ht);
                        if (k < 0)
                            return false;
                    }
                }
            }
            Now_DT_VS_Old.Rows.Clear();//清空旧选中检查项目与价表项目的对照表
            for (i = 0; i < Now_DT_VS_Group.Count; i++)
            {
                if (Now_DT_VS_Group[i] != null)
                {
                    for (j = 0; j < Now_DT_VS_Group[i].Rows.Count; j++)
                    {
                        Now_DT_VS_Old.Rows.Add(new object[] {
                            Now_DT_VS_Group[i].Rows[j]["CLASS_NAME"].ToString (),
                            Now_DT_VS_Group[i].Rows[j]["ITEM_CLASS"].ToString (),
                            Now_DT_VS_Group[i].Rows[j]["ITEM_NAME"].ToString (),
                            Now_DT_VS_Group[i].Rows[j]["ITEM_SPEC"].ToString (),
                            Now_DT_VS_Group[i].Rows[j]["AMOUNT"].ToString (),
                            Now_DT_VS_Group[i].Rows[j]["UNITS"].ToString (),
                            Now_DT_VS_Group[i].Rows[j]["PRICE"].ToString (),
                            Now_DT_VS_Group[i].Rows[j]["EXAM_ITEM_CODE"].ToString (),
                            Now_DT_VS_Group[i].Rows[j]["ITEM_CODE"].ToString (),
                            Now_DT_VS_Group[i].Rows[j]["COSTS"].ToString (),
                            Now_DT_VS_Group[i].Rows[j]["CHARGES"].ToString (),
                            Now_DT_VS_Group[i].Rows[j]["EXAM_ITEM_NO"].ToString (),
                            Now_DT_VS_Group[i].Rows[j]["CHARGE_ITEM_NO"].ToString ()});
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 获取检查申请号
        /// 注意：mWorkList.EXAM_ACCESSION_NUM = mUserDeptDict.DEPT_AREA + mWorkList.ACCESSION_NO;，即检查申请序号=科室域+检查流水号，科室域：检查科室：RY，申请科室：CD
        ///mWorkList.STUDY_INSTANCE_UID = mUserDeptDict.STUDY_UID_HEADER + mWorkList.ACCESSION_NO;，即检查实例UID=检查UID头+检查流水号，检查流水号为数据库自动生成，为当前最大值
        /// </summary>
        /// <param name="ACCESSION_NO"></param>
        /// <returns></returns>
        public bool GetExamAccessionNum(IModel iWorklist)
        {
            MWorkList mWorkList = (MWorkList)iWorklist;
            bool issuccess = true;
            BClinicOfficeDict bClinicOfficeDict = new BClinicOfficeDict();
            MClinicOfficeDict mClinicOfficeDict = (MClinicOfficeDict)bClinicOfficeDict.GetModel(mWorkList.EXAM_DEPT);
            if ((mWorkList.EXAM_ACCESSION_NUM == null || mWorkList.EXAM_ACCESSION_NUM == "" )&& mClinicOfficeDict!=null)
            {
                mWorkList.EXAM_ACCESSION_NUM = mClinicOfficeDict.CLINIC_OFFICE_FLAG + mWorkList.ACCESSION_NO;
                mWorkList.STUDY_INSTANCE_UID = mClinicOfficeDict.STUDY_UID_HEADER + mWorkList.ACCESSION_NO;
            }
            else
                issuccess = false;
            return issuccess;
        }

        /// <summary>
        /// 插入或更新病人资料
        /// </summary>
        public bool SetPatientInf(IModel iPatientInf)
        {
            MArchives mArchives=(MArchives)iPatientInf;
            BArchives bArchives = new BArchives();
            int i = 0;
            //if (IsNew)
            //{
            //    i = bArchives.Add(mArchives);
            //    //EXAM_TIMES = "1";
            //}
            //else
            //{
                if (!bArchives.Exists(mArchives))
                    i = bArchives.Add(mArchives);
                else
                    i = bArchives.Update(mArchives, "where PATIENT_ID ='" + mArchives.PATIENT_ID + "'");
            //}
            return i < 0 ? false : true;
        }


        public IModel GetArchives(string PatientId)
        {
            BArchives barchives = new BArchives();
            return barchives.GetModel(PatientId);
        }

        public System.Data.DataTable SelectPatientInf(string where)
        {
            string Sqlstr = "select a.PATIENT_ID,a.PATIENT_NAME,a.PATIENT_SEX,a.PATIENT_BIRTH,a.BIRTH_PLACE,a.MAILING_ADDRESS,a.TELEPHONE_NUM,a.ZIP_CODE,a.IDENTITY_CARD_NO,a.OPD_NO,a.INP_NO,a.NATIVE_PLACE,a.HABITATION,b.AREA_NAME,max(c.STUDY_DATE_TIME) as STUDY_DATE_TIME ";
            switch (GetConfig.SisOdbcMode)
            {
                case "ACCESS":
                    Sqlstr += "from ((ARCHIVES a left join AREA_DICT b on a.BIRTH_PLACE =b.AREA_CODE) left join SYUDY c on a.PATIENT_ID = c.PATIENT_ID) where 1=1 " + where;
                    break;
                case "ORACLE":
                    Sqlstr += "from ARCHIVES a,AREA_DICT b,WORKLIST c where 1=1 and a.BIRTH_PLACE =b.AREA_CODE(+) and a.PATIENT_ID =c.PATIENT_ID(+) " + where;
                    break;
                case "SQL":
                    break;
            }
            Sqlstr += " group by a.PATIENT_ID,a.PATIENT_NAME,a.PATIENT_SEX,a.PATIENT_BIRTH,a.BIRTH_PLACE,a.MAILING_ADDRESS,a.TELEPHONE_NUM,a.ZIP_CODE,a.IDENTITY_CARD_NO,a.OPD_NO,a.INP_NO,a.NATIVE_PLACE,a.HABITATION,b.AREA_NAME";
            System.Data.DataTable dt = GetDataSet(Sqlstr).Tables[0];
            AgeBirth ab = new AgeBirth();
            dt.Columns.Add("PATIENT_AGE", typeof(string));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["PATIENT_BIRTH"].ToString() != "")
                    dt.Rows[i]["PATIENT_AGE"] = ab.BirthToAge(0, Convert.ToDateTime(dt.Rows[i]["PATIENT_BIRTH"].ToString())) + "岁";
            }
            return dt;
        }

        public bool AddWorkList(IModel iWorkList)
        {
            BWorkList bWorkList = new BWorkList();
            int i = bWorkList.Add(iWorkList);
            return i < 0 ? false : true;
        }

        public bool UpdateWorkList(IModel iWorkList)
        {
            MWorkList mWorkList = (MWorkList)iWorkList;
            BWorkList bWorkList = new BWorkList();
            int i = bWorkList.Update(iWorkList, "where EXAM_ACCESSION_NUM = '" + mWorkList.EXAM_ACCESSION_NUM + "'");
            return i < 0 ? false : true;
        }

        /// <summary>
        /// 循环写进费用明细表
        /// </summary>
        public bool AddExamChargeList(List<System.Data.DataTable> Now_DT_VS_Group, int ChargeItemNo, IModel iWorklist, decimal chargeRatio)
        {
            BExamChargeList bExamChargeList = new BExamChargeList();
            MWorkList mWorkList = (MWorkList)iWorklist;
            int i, j;
            for (i = 0; i < Now_DT_VS_Group.Count; i++)
            {
                if (Now_DT_VS_Group[i] != null)
                {
                    Hashtable ht = new Hashtable();
                    for (j = 0; j < Now_DT_VS_Group[i].Rows.Count; j++)
                    {
                        MExamChargeList mExamChargeList = new MExamChargeList();
                        mExamChargeList.AMOUNT = Convert.ToInt32(Now_DT_VS_Group[i].Rows[j]["AMOUNT"].ToString());
                        mExamChargeList.CHARGE = Convert.ToDecimal(Now_DT_VS_Group[i].Rows[j]["COSTS"].ToString()) * chargeRatio;
                        mExamChargeList.CHARGE_CLASS_NAME = Now_DT_VS_Group[i].Rows[j]["CLASS_NAME"].ToString();
                        mExamChargeList.CHARGE_ITEM_CLASS = Now_DT_VS_Group[i].Rows[j]["ITEM_CLASS"].ToString();
                        mExamChargeList.CHARGE_ITEM_CODE = Now_DT_VS_Group[i].Rows[j]["ITEM_CODE"].ToString();
                        mExamChargeList.CHARGE_ITEM_NO = j + 1;
                        mExamChargeList.CHARGE_ITEM_SPEC = Now_DT_VS_Group[i].Rows[j]["ITEM_SPEC"].ToString();
                        mExamChargeList.COST = Convert.ToDecimal(Now_DT_VS_Group[i].Rows[j]["COSTS"].ToString());
                        mExamChargeList.PRICE = Convert.ToDecimal(Now_DT_VS_Group[i].Rows[j]["PRICE"].ToString());
                        mExamChargeList.EXAM_NO = mWorkList.EXAM_ACCESSION_NUM;
                        mExamChargeList.EXAM_CONFIRM_TIME = DateTime.Now;
                        mExamChargeList.EXAM_ITEM_CODE = Now_DT_VS_Group[i].Rows[j]["EXAM_ITEM_CODE"].ToString();
                        mExamChargeList.ITEM_NO = ChargeItemNo;
                        mExamChargeList.PATIENT_ID = mWorkList.PATIENT_ID;
                        mExamChargeList.UNITS = Now_DT_VS_Group[i].Rows[j]["UNITS"].ToString();
                        mExamChargeList.CHARGE_ITEM_NAME = Now_DT_VS_Group[i].Rows[j]["ITEM_NAME"].ToString();
                        mExamChargeList.EXAM_ITEM_NO = i + 1;
                        ChargeItemNo++;
                        if (bExamChargeList.Exists(mExamChargeList))
                            break;
                        ht.Add(j, mExamChargeList);
                    }
                    if (ht.Count > 0)
                        j = bExamChargeList.AddMore(ht);
                    else
                        return true;
                    if (j < 0)
                        return false;
                }
            }
            return true;
        }

        public System.Data.DataTable GetExamChargeList(string ExamAccessionNum)
        {
            string sql = "select CHARGE_CLASS_NAME as CLASS_NAME," +
                         "CHARGE_ITEM_CLASS as ITEM_CLASS," +
                         "CHARGE_ITEM_NAME as ITEM_NAME," +
                         "CHARGE_ITEM_SPEC as ITEM_SPEC," +
                         "AMOUNT," +
                         "UNITS," +
                         "PRICE," +
                         "EXAM_ITEM_CODE," +
                         "CHARGE_ITEM_CODE as ITEM_CODE," +
                         "COST as COSTS," +
                         "CHARGE as CHARGES," +
                         "EXAM_ITEM_NO,"+
                         "CHARGE_ITEM_NO " +
                "from EXAM_CHARGE_LIST where EXAM_NO = '" + ExamAccessionNum + "'";
            System.Data.DataTable dt = GetDataSet(sql).Tables[0];
            return dt;
        }

        public System.Data.DataTable GetExamItems(string ExamAccessionNum)
        {
            string sql = "select distinct a.EXAM_ITEM_CODE,a.EXAM_ITEM_NO,b.EXAM_ITEM_NAME as EXAM_ITEM from EXAM_CHARGE_LIST a ,EXAM_ITEM_DICT b where a.EXAM_ITEM_CODE = b.EXAM_ITEM_CODE and EXAM_NO = '" + ExamAccessionNum + "'";
            System.Data.DataTable dt = GetDataSet(sql).Tables[0];
            return dt;
        }

    }
}
