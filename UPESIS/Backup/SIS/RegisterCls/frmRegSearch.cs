using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ILL;
using SIS_BLL;
using System.Collections;

namespace SIS.RegisterCls
{
    public partial class frmRegSearch : Form
    {
        private string mode;
        private string ExamClass;
        private System.Data.DataTable DT_EXAM = new DataTable();
        private RegCls_Pacs regPacs;
        private RegCls_UPE regUPE;
        private RegCls_JW regJW;
        private RegCls_HT regHT;
        private IModel iArchives, iWorkList;
        private InitReg initReg;
        private Hashtable ht;
        private string sqlHis, sqlPacs;

        private BindData bindData = new BindData();
        public frmRegSearch(InitReg initReg, IModel iWorkList, IModel iArchives, Hashtable ht)
        {
            InitializeComponent();
            this.iWorkList = iWorkList;
            this.iArchives = iArchives;
            this.initReg = initReg;
            this.ht = ht;
            regPacs = new RegCls_Pacs();
            regUPE = new RegCls_UPE();
            regJW = new RegCls_JW();
            regHT = new RegCls_HT();
            this.sqlHis = this.GetHisWhereStr();
            this.sqlPacs = this.GetPacsWhereStr();
            this.txt_PatientId.Text = GetParamByHt(ht, "PATIENT_ID");
            this.txt_PatientName.Text = GetParamByHt(ht, "PATIENT_NAME");
            bindData.BindPatientSource(this.cmb_PatientSource);
            if(GetParamByHt(ht, "PATIENT_SOURCE")=="")
            {
                this.cmb_PatientSource.SelectedIndex = -1;
            }
            else
            {
                this.cmb_PatientSource.SelectedValue = GetParamByHt(ht, "PATIENT_SOURCE");
            }
        }
        private string GetParamByHt(Hashtable ht, string Key)
        {
            if (ht.ContainsKey(Key))
            {
                return ht[Key].ToString();
            }
            else
            {
                return "";
            }
        }
        private string SetExamClass()
        {
            string[] ExamClass = GetConfig.RM_ExamClass.Split(',');
            string Str = "";
            if (ExamClass.Length > 0)
            {
                Str += " and (";
                foreach (string ss in ExamClass)
                {
                    Str += " EXAM_CLASS = '" + ss + "' or";
                    //Str += "'" + ss + "',";
                }
                if (Str.Length > 6)
                {
                    Str = Str.Substring(0, Str.Length - 2) + ")";
                }
                else
                {
                    Str = "";
                }
            }
            return Str;
        }

        /// <summary>
        /// 查询病人检查申请记录或资料
        /// </summary>
        public int Search()
        {
           // if (GetConfig.RM_HisApply && GetConfig.hisVisit)
           if (GetConfig.RM_HisApply)//是否连接HIS查询申请信息
            {
                if (SearchExamAppoints())//先查询His检查申请记录,找到则返回true
                {
                    this.p_His.Visible = true;
                    this.p_His.Dock = DockStyle.Fill;
                   // if (this.dgv_ExamAppoints.Rows.Count > 0)
                     //   this.dgv_ExamAppoints.Rows[0].Selected = true;
                    return 1;
                }
                else
                {
                    if (SearchPatMasterIndex())//再查询His病人资料库记录,找到则返回true
                    {
                        this.l_NoticeM.Visible = true;
                        this.p_His.Visible = false;
                        this.p_PatMasterIndex.Dock = DockStyle.Fill;
                        this.p_PatMasterIndex.Visible = true;
                        this.mode = "00";
                        return 2;
                    }
                    else
                    {
                        if (SearchPatientInf())//最后查询系统病人资料库记录,找到则返回true
                        {
                            this.l_NoticeP.Visible = true;
                            this.p_PatientInf.Visible = true;
                            this.p_His.Visible = false;
                            this.p_PatientInf.Dock = DockStyle.Fill;
                            this.mode = "00";
                            return 3;
                        }
                        //else
                        //    return -1;
                    }
                }
            }
            else
            {
                if (SearchPatientInf())//查询系统病人资料库记录,找到则返回true
                {
                    this.p_PatientInf.Visible = true;
                    this.p_PatientInf.Dock = DockStyle.Fill;
                    this.mode = "00";
                    return 3;
                }
                //else
                //    return -1;
            }
            return -1;
        }

        /// <summary>
        /// 查询HIS检查申请记录
        /// </summary>
        private bool SearchExamAppoints()
        {
            switch (GetConfig.hisVender)
            {
                case "JW":       
                    //this.dgv_ExamAppoints.DataSource = regJW.SelectExamAppoints(this.ExamClass,this.sqlHis);
                    break;
                case "HT":
                    this.dgv_ExamAppoints.DataSource = regHT.GetQPInfo(this.ht);
                    
                    break;
            }
            this.lb_PatientInf.Text = "共检索到: " + this.dgv_ExamAppoints.Rows.Count + " 条记录  ";
            if (this.dgv_ExamAppoints.Rows.Count >0)
            {
                //this.dgv_ExamAppoints.Focus();
                //this.dgv_ExamAppoints.Rows[0].Selected = true;
                return true;
            }
            return false;
        }
        /// <summary>
        /// 获取查询His数据库的where子句
        /// </summary>
        private string GetHisWhereStr()
        {
            string sql = "";
            switch (GetConfig.hisVender)
            {
                case "JW":
                    foreach (DictionaryEntry item in this.ht)
                    {
                        switch (item.Key.ToString())
                        {
                            case "PATIENT_ID":
                                sql += " and a.PATIENT_ID = '" + item.Value.ToString() + "' ";
                                break;
                            case "PATIENT_NAME":
                                sql += "and a.NAME = '" + item.Value.ToString() + "' ";
                                break;
                            case "INP_NO": 
                                sql += "and a.INP_NO = '" + item.Value.ToString() + "' ";
                                break;
                        }
                    }
                    break;
                case "HT":
                    foreach (DictionaryEntry item in this.ht)
                    {
                        switch (item.Key.ToString())
                        {
                            case "PATIENT_ID":
                                break;
                            case "PATIENT_NAME":
                                break;
                            case "INP_NO":
                                break;
                        }
                    }
                    break;
            }
            return sql;
        }

        /// <summary>
        /// 获取查询Pacs数据库的where子句
        /// </summary>
        private string GetPacsWhereStr()
        {
            string sql = "";
            foreach (DictionaryEntry item in this.ht)
            {
                switch (item.Key.ToString())
                {
                    case "PATIENT_ID":
                        sql += "and a.PATIENT_ID = '" + item.Value.ToString() + "' ";
                        break;
                    case "PATIENT_NAME":
                        sql += "and a.PATIENT_NAME = '" + item.Value.ToString() + "' ";
                        break;
                    case "INP_NO":
                        sql += "and a.INP_NO = '" + item.Value.ToString() + "' ";
                        break;
                }
            }
            return sql;
        }
        
        /// <summary>
        /// 查询PACS系统病人资料库
        /// </summary>
        private bool SearchPatientInf()
        {
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    this.dgv_PatientInf.DataSource = regUPE.SelectPatientInf(this.sqlPacs);
                    break;
                case "PACS":
                    this.dgv_PatientInf.DataSource = regPacs.SelectPatientInf(this.sqlPacs);
                    break;
            }
            this.lb_PatientInf.Text = "共检索到: " + this.dgv_PatientInf.Rows.Count + " 条记录  ";
            if (this.dgv_PatientInf.Rows.Count != 0)
                return true;
            return false;
        }

        /// <summary>
        /// 查询HIS系统病人资料库
        /// </summary>
        private bool SearchPatMasterIndex()
        {
            switch (GetConfig.hisVender)
            {
                case "JW":
                    this.dgv_PatMasterIndex.DataSource = regJW.SelectPatMasterIndex(this.sqlHis);
                    break;
                case "HT":
                    break;
            }
            this.lb_PatMasterIndex.Text = "共检索到: " + this.dgv_PatMasterIndex.Rows.Count + " 条记录  ";
            if (this.dgv_PatMasterIndex.Rows.Count != 0)
                return true;
            return false;
        }

        /// <summary>
        /// 双击PACS系统病人列表记录
        /// </summary>
        private void dgv_PatientInf_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgv_PatientInf.SelectedRows.Count > 0)
            {
                SelectPatientInf();
                if (GetConfig.RM_IsSelectOutpDesc&&GetConfig.hisVisit)
                    switch (GetConfig.DALAndModel)
                    {
                        case "SIS":
                            SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.iWorkList;
                            System.Data.DataTable dt_S = regJW.SelectOutpOrderDesc("b.patient_id ='" + smWorkList.PATIENT_ID + "'  and a.performed_by ='" + smWorkList.EXAM_DEPT + "'");
                            if (dt_S.Rows.Count != 0)
                            {
                                smWorkList.REFER_DEPT = dt_S.Rows[0]["ORDERED_BY_DEPT"].ToString();
                                smWorkList.REQ_DEPT_NAME = dt_S.Rows[0]["DEPT_NAME"].ToString();
                                smWorkList.REFER_DOCTOR = dt_S.Rows[0]["ORDERED_BY_DOCTOR"].ToString();
                            }
                            break;
                        case "PACS":
                            PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.iWorkList;
                            System.Data.DataTable dt_P = regJW.SelectOutpOrderDesc("b.patient_id ='" + pmWorkList.PATIENT_ID + "'  and a.performed_by ='" + pmWorkList.EXAM_DEPT + "'");
                            if (dt_P.Rows.Count != 0)
                            {
                                pmWorkList.REFER_DEPT = dt_P.Rows[0]["ORDERED_BY_DEPT"].ToString();
                                pmWorkList.REQ_DEPT_NAME = dt_P.Rows[0]["DEPT_NAME"].ToString();
                                pmWorkList.REFER_DOCTOR = dt_P.Rows[0]["ORDERED_BY_DOCTOR"].ToString();
                            }
                            break;
                    }
                //if (IsSelectOutpDesc == "3")
                //this.OutpView();
                this.initReg.initMode0(this.iWorkList,this.iArchives,this.mode);
            }
            this.Close();
        }

        /// <summary>
        /// 双击HIS检查申请列表记录
        /// </summary>
        private void dgv_ExamAppoints_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgv_ExamAppoints.SelectedRows.Count > 0)
            {
                SelectExamAppoints();
                if (this.mode == "01" || this.mode == "11")
                {
                    this.initReg.initMode2(this.iWorkList, this.mode, this.DT_EXAM);
                }
            //    switch (GetConfig.DALAndModel)
            //    {
            //        case "SIS":
            //            SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.iWorkList;
            //           // this.DT_EXAM = regJW.SelectExamItems(smWorkList.EXAM_NO);
            //           // smWorkList.INP_NO = regJW.SelectInp(smWorkList.PATIENT_ID);
            //            switch (this.mode)
            //            {
            //                case "01":
            //                    this.initReg.initMode2(this.iWorkList, this.mode, this.DT_EXAM);
            //                    break;
            //                case "11":
            //                    this.initReg.initMode2(this.iWorkList, this.mode, this.DT_EXAM);
            //                    break;
            //            }
            //            break;
            //        case "PACS":
            //            PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.iWorkList;
            //            switch (this.mode)
            //            {
            //                case "01":
            //                    this.initReg.initMode2(this.iWorkList, this.mode, this.DT_EXAM);
            //                    break;
            //                case "11":
            //                    this.initReg.initMode2(this.iWorkList, this.mode, this.DT_EXAM);
            //                    break;
            //            }
            //            break;
            //    }
            }
            this.Close();
        }

        /// <summary>
        /// 双击HIS系统病人资料列表记录
        /// </summary>
        private void dgv_PatMasterIndex_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgv_PatMasterIndex.SelectedRows.Count > 0)
            {
                SelectPatMasterIndex();
                //if (GetConfig.RM_IsSelectOutpDesc)
                //{
                //    switch (GetConfig.DALAndModel)
                //    {
                //        case "SIS":
                //            SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.iWorkList;
                //            System.Data.DataTable dt_S = regJW.SelectOutpOrderDesc("b.patient_id ='" + smWorkList.PATIENT_ID + "'  and a.performed_by ='" + smWorkList.EXAM_DEPT + "'");
                //            if (dt_S.Rows.Count != 0)
                //            {
                //                smWorkList.REFER_DEPT = dt_S.Rows[0]["ORDERED_BY_DEPT"].ToString();
                //                smWorkList.REQ_DEPT_NAME = dt_S.Rows[0]["DEPT_NAME"].ToString();
                //                smWorkList.REFER_DOCTOR = dt_S.Rows[0]["ORDERED_BY_DOCTOR"].ToString();
                //            }
                //            break;
                //        case "PACS":
                //            PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.iWorkList;
                //            System.Data.DataTable dt_P = regJW.SelectOutpOrderDesc("b.patient_id ='" + pmWorkList.PATIENT_ID + "'  and a.performed_by ='" + pmWorkList.EXAM_DEPT + "'");
                //            if (dt_P.Rows.Count != 0)
                //            {
                //                pmWorkList.REFER_DEPT = dt_P.Rows[0]["ORDERED_BY_DEPT"].ToString();
                //                pmWorkList.REQ_DEPT_NAME = dt_P.Rows[0]["DEPT_NAME"].ToString();
                //                pmWorkList.REFER_DOCTOR = dt_P.Rows[0]["ORDERED_BY_DOCTOR"].ToString();
                //            }
                //            break;
                //    }
                //}
                ////if (IsSelectOutpDesc == "3")
                ////    this.OutpView();
                this.initReg.initMode1(this.iWorkList,this.iArchives, this.mode);
            }
            this.Close();
        }

        /// <summary>
        /// 选中HIS检查申请记录
        /// </summary>
        private void SelectExamAppoints()
        {
            DataGridViewRow dr = this.dgv_ExamAppoints.SelectedRows[0];
            switch (GetConfig.DALAndModel)
            {
                case "SIS":

                    SIS_Model.MArchives mArchives = (SIS_Model.MArchives)this.iArchives;
                   
                    mArchives.PATIENT_NAME = dr.Cells["C_NAME_HIS"].Value.ToString();
                    mArchives.PATIENT_SEX = dr.Cells["SEX"].Value.ToString();
                    if (dr.Cells["BIRTHDATE"].Value.ToString() != "")
                        mArchives.PATIENT_BIRTH = Convert.ToDateTime(dr.Cells["BIRTHDATE"].Value.ToString());
                    
                    mArchives.IDENTITY_CARD_NO = dr.Cells["PATSTACODE"].Value.ToString();
                    mArchives.MAILING_ADDRESS = dr.Cells["ADDRESS"].Value.ToString();
                   
                    mArchives.TELEPHONE_NUM = dr.Cells["TELEPHONE"].Value.ToString();
                     //mArchives.PATIENT_ID = dr.Cells["C_PATIENT_ID"].Value.ToString();
                     //mArchives.NATIVE_PLACE = dr.Cells["C_PATIENT_BIRTH"].Value.ToString();
                     //mArchives.HABITATION = dr.Cells["C_HABITATION"].Value.ToString();
                     //mArchives.OPD_NO = dr.Cells["C_OPD_NO"].Value.ToString();床号
                     //mArchives.INP_NO = dr.Cells["C_INP_NO"].Value.ToString(); 住院号
                     //mArchives.ZIP_CODE = dr.Cells["C_ZIP_CODE"].Value.ToString();
                     //mArchives.BIRTH_PLACE = dr.Cells["C_BIRTH_PLACE"].Value.ToString();
                     //mPatientInf.BIRTH_PLACE_CODE = dr.Cells["C_BIRTH_PLACE_CODE"].Value.ToString();
                    SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.iWorkList;
                    smWorkList.PATIENT_NAME = dr.Cells["C_NAME_HIS"].Value.ToString();
                    smWorkList.PATIENT_SEX = dr.Cells["SEX"].Value.ToString();
                    if (dr.Cells["BIRTHDATE"].Value.ToString() != "")
                        smWorkList.PATIENT_BIRTH = Convert.ToDateTime(dr.Cells["BIRTHDATE"].Value.ToString());
                    if (dr.Cells["SOURCE"].Value.ToString() == "住院")
                    {
                        smWorkList.INP_NO = dr.Cells["INHOSPITALNO"].Value.ToString();//住院号
                    }
                    else
                    {
                        smWorkList.OPD_NO = dr.Cells["INHOSPITALNO"].Value.ToString();//门诊号
                    }
                    // smWorkList.dr.Cells["PATSTACODE"].Value.ToString()         //身份证号
                    smWorkList.BED_NUM = dr.Cells["BEDNO"].Value.ToString();      //床号
                    smWorkList.MAILING_ADDRESS = dr.Cells["ADDRESS"].Value.ToString();//地址
                    smWorkList.TELEPHONE_NUM = dr.Cells["TELEPHONE"].Value.ToString();//电话
                    smWorkList.PATIENT_SOURCE = dr.Cells["CLIISINPAT"].Value.ToString(); //病人来源
                    smWorkList.REFER_DEPT = dr.Cells["LODGESECTION"].Value.ToString(); //申请科室
                    smWorkList.REFER_DOCTOR = dr.Cells["LODGEDOCTOR"].Value.ToString(); //申请医生
                        smWorkList.CLIN_DIAG = dr.Cells["DIAGNOSIS"].Value.ToString();    //诊断
                    //smWorkList.EXAM_ITEMS=dr.Cells[""]                              //检查项目

                    smWorkList.EXAM_NO = dr.Cells["ApplyNo"].Value.ToString();    //申请单号
                    //smWorkList.INPATIENTNO = dr.Cells["INPATIENTNO"].Value.ToString();//记账号
                    smWorkList.JZH = dr.Cells["INPATIENTNO"].Value.ToString();//记账号


                   
                    break;
                case "PACS":
                    PACS_Model.MArchives PArchives = (PACS_Model.MArchives)this.iArchives;
                    // mArchives.PATIENT_ID = dr.Cells["C_PATIENT_ID"].Value.ToString();
                    PArchives.PATIENT_NAME = dr.Cells["C_NAME_HIS"].Value.ToString();
                    PArchives.PATIENT_SEX = dr.Cells["SEX"].Value.ToString();
                    if (dr.Cells["BIRTHDATE"].Value.ToString() != "")
                        PArchives.PATIENT_BIRTH = Convert.ToDateTime(dr.Cells["BIRTHDATE"].Value.ToString());
                    //mArchives.BIRTH_PLACE = dr.Cells["C_BIRTH_PLACE"].Value.ToString();
                    //mPatientInf.BIRTH_PLACE_CODE = dr.Cells["C_BIRTH_PLACE_CODE"].Value.ToString();
                    PArchives.IDENTITY_CARD_NO = dr.Cells["PATSTACODE"].Value.ToString();
                    PArchives.MAILING_ADDRESS = dr.Cells["ADDRESS"].Value.ToString();
                    //mArchives.ZIP_CODE = dr.Cells["C_ZIP_CODE"].Value.ToString();
                  //  PArchives.TELEPHONE_NUM = dr.Cells["TELEPHONE"].Value.ToString();
                    //mArchives.NATIVE_PLACE = dr.Cells["C_PATIENT_BIRTH"].Value.ToString();
                    // mArchives.HABITATION = dr.Cells["C_HABITATION"].Value.ToString();
                    // mArchives.OPD_NO = dr.Cells["C_OPD_NO"].Value.ToString();床号
                    //  mArchives.INP_NO = dr.Cells["C_INP_NO"].Value.ToString(); 住院号


                    PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.iWorkList;
                    pmWorkList.PATIENT_NAME = dr.Cells["C_NAME_HIS"].Value.ToString();
                    pmWorkList.PATIENT_SEX = dr.Cells["SEX"].Value.ToString();
                    if (dr.Cells["BIRTHDATE"].Value.ToString() != "")
                        pmWorkList.PATIENT_BIRTH = Convert.ToDateTime(dr.Cells["BIRTHDATE"].Value.ToString());
                    if (dr.Cells["SOURCE"].Value.ToString() == "住院")
                    {
                        pmWorkList.INP_NO = dr.Cells["INHOSPITALNO"].Value.ToString();//住院号
                    }
                    else
                    {
                        pmWorkList.OPD_NO = dr.Cells["INHOSPITALNO"].Value.ToString();//门诊号
                    }
                    // smWorkList.dr.Cells["PATSTACODE"].Value.ToString()         //身份证号
                    pmWorkList.BED_NUM = dr.Cells["BEDNO"].Value.ToString();      //床号
                    pmWorkList.MAILING_ADDRESS = dr.Cells["ADDRESS"].Value.ToString();//地址
                    pmWorkList.TELEPHONE_NUM = dr.Cells["TELEPHONE"].Value.ToString();//电话
                    pmWorkList.PATIENT_SOURCE = dr.Cells["CLIISINPAT"].Value.ToString(); //病人来源
                    pmWorkList.REFER_DEPT = dr.Cells["LODGESECTION"].Value.ToString(); //申请科室
                    pmWorkList.REFER_DOCTOR = dr.Cells["LODGEDOCTOR"].Value.ToString(); //申请医生
                    pmWorkList.CLIN_DIAG = dr.Cells["DIAGNOSIS"].Value.ToString();    //诊断
                    //smWorkList.EXAM_ITEMS=dr.Cells[""]                              //检查项目
                    pmWorkList.EXAM_NO = dr.Cells["ApplyNo"].Value.ToString();      //申请单号
                    //pmWorkList.INPATIENTNO = dr.Cells["INPATIENTNO"].Value.ToString();//记账号
                    pmWorkList.JZH = dr.Cells["INPATIENTNO"].Value.ToString();//记账号
                    break;
            }

            if (dr.Cells["CLIISINPAT"].Value.ToString() == "2")
                this.mode = "11";
            else
                this.mode = "01";

            this.Close();
            }
       /* private void SelectExamAppoints1()
        {
            DataGridViewRow dr = this.dgv_ExamAppoints.CurrentRow;
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.iWorkList;
                    smWorkList.EXAM_NO = dr.Cells["C_EXAM_NO_HIS"].Value.ToString();
                    smWorkList.PATIENT_ID = dr.Cells["C_PATIENT_ID_HIS"].Value.ToString();
                    if (dr.Cells["C_VISIT_ID_HIS"].Value.ToString() != "")
                        smWorkList.VISIT_ID = Convert.ToInt32(dr.Cells["C_VISIT_ID_HIS"].Value.ToString());
                    smWorkList.LOCAL_ID_CLASS = dr.Cells["C_LOCAL_ID_CLASS_HIS"].Value.ToString();
                    smWorkList.PATIENT_LOCAL_ID = dr.Cells["C_PATIENT_LOCAL_ID_HIS"].Value.ToString();
                    smWorkList.PATIENT_NAME = dr.Cells["C_NAME_HIS"].Value.ToString();
                    smWorkList.PATIENT_PHONETIC = dr.Cells["C_NAME_PHONETIC_HIS"].Value.ToString();
                    smWorkList.PATIENT_SEX = dr.Cells["C_SEX_HIS"].Value.ToString();
                    if (dr.Cells["C_DATE_OF_BIRTH_HIS"].Value.ToString() != "")
                        smWorkList.PATIENT_BIRTH = Convert.ToDateTime(dr.Cells["C_DATE_OF_BIRTH_HIS"].Value.ToString());
                    smWorkList.BIRTH_PLACE = dr.Cells["C_BIRTH_PLACE_HIS"].Value.ToString();
                    //smWorkList.BIRTH_PLACE_CODE = dr.Cells["C_BIRTH_PLACE_CODE_HIS"].Value.ToString();
                    smWorkList.PATIENT_IDENTITY = dr.Cells["C_IDENTITY_HIS"].Value.ToString();
                    if (dr.Cells["C_CHARGE_TYPE_HIS"].Value.ToString() != "")
                        smWorkList.CHARGE_TYPE = Convert.ToInt32(dr.Cells["C_CHARGE_TYPE_HIS"].Value.ToString());
                    smWorkList.MAILING_ADDRESS = dr.Cells["C_MAILING_ADDRESS_HIS"].Value.ToString();
                    smWorkList.ZIP_CODE = dr.Cells["C_ZIP_CODE_HIS"].Value.ToString();
                    smWorkList.TELEPHONE_NUM = dr.Cells["C_PHONE_NUMBER_HIS"].Value.ToString();
                    smWorkList.EXAM_CLASS = dr.Cells["C_EXAM_CLASS_HIS"].Value.ToString();
                    smWorkList.EXAM_SUB_CLASS = dr.Cells["C_EXAM_SUB_CLASS_HIS"].Value.ToString();
                    smWorkList.CLIN_SYMP = dr.Cells["C_CLIN_SYMP_HIS"].Value.ToString();
                    smWorkList.PHYS_SIGN = dr.Cells["C_PHYS_SIGN_HIS"].Value.ToString();
                    smWorkList.RELEVANT_LAB_TEST = dr.Cells["C_RELEVANT_LAB_TEST_HIS"].Value.ToString();
                    smWorkList.RELEVANT_DIAG = dr.Cells["C_RELEVANT_DIAG_HIS"].Value.ToString();
                    smWorkList.CLIN_DIAG = dr.Cells["C_CLIN_DIAG_HIS"].Value.ToString();
                    smWorkList.EXAM_MODE = dr.Cells["C_EXAM_MODE_HIS"].Value.ToString();
                    smWorkList.EXAM_GROUP = dr.Cells["C_EXAM_GROUP_HIS"].Value.ToString();
                    smWorkList.EXAM_DEPT = dr.Cells["C_PERFORMED_BY_HIS"].Value.ToString();
                    smWorkList.PATIENT_SOURCE = dr.Cells["C_PATIENT_SOURCE_HIS"].Value.ToString();
                    smWorkList.OUT_MED_INSTITUTION = dr.Cells["C_FACILITY_HIS"].Value.ToString();
                    if (dr.Cells["C_REQ_DATE_TIME_HIS"].Value.ToString() != "")
                        smWorkList.REQ_DATE_TIME = Convert.ToDateTime(dr.Cells["C_REQ_DATE_TIME_HIS"].Value.ToString());
                    smWorkList.REFER_DEPT = dr.Cells["C_REQ_DEPT_HIS"].Value.ToString();
                    smWorkList.REFER_DOCTOR = dr.Cells["C_REQ_PHYSICIAN_HIS"].Value.ToString();
                    smWorkList.REQ_MEMO = dr.Cells["C_REQ_MEMO_HIS"].Value.ToString();
                    if (dr.Cells["C_SCHEDULED_DATE_HIS"].Value.ToString() != "")
                        smWorkList.SCHEDULED_DATE = Convert.ToDateTime(dr.Cells["C_SCHEDULED_DATE_HIS"].Value.ToString());
                    //smWorkList.NOTICE = dr.Cells["C_NOTICE_HIS"].Value.ToString();
                    if (dr.Cells["C_COSTS_HIS"].Value.ToString() != "")
                        smWorkList.COSTS = Convert.ToDecimal(dr.Cells["C_COSTS_HIS"].Value.ToString());
                    if (dr.Cells["C_CHARGES_HIS"].Value.ToString() != "")
                        smWorkList.CHARGES = Convert.ToDecimal(dr.Cells["C_CHARGES_HIS"].Value.ToString());
                    break;
                case "PACS":
                    PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.iWorkList;
                    pmWorkList.EXAM_NO = dr.Cells["C_EXAM_NO_HIS"].Value.ToString();
                    smWorkList.PATIENT_ID = dr.Cells["C_PATIENT_ID_HIS"].Value.ToString();
                    if (dr.Cells["C_VISIT_ID_HIS"].Value.ToString() != "")
                        smWorkList.VISIT_ID = Convert.ToInt32(dr.Cells["C_VISIT_ID_HIS"].Value.ToString());
                    smWorkList.LOCAL_ID_CLASS = dr.Cells["C_LOCAL_ID_CLASS_HIS"].Value.ToString();
                    smWorkList.PATIENT_LOCAL_ID = dr.Cells["C_PATIENT_LOCAL_ID_HIS"].Value.ToString();
                    smWorkList.PATIENT_NAME = dr.Cells["C_NAME_HIS"].Value.ToString();
                    smWorkList.PATIENT_PHONETIC = dr.Cells["C_NAME_PHONETIC_HIS"].Value.ToString();
                    smWorkList.PATIENT_SEX = dr.Cells["C_SEX_HIS"].Value.ToString();
                    if (dr.Cells["C_DATE_OF_BIRTH_HIS"].Value.ToString() != "")
                        smWorkList.PATIENT_BIRTH = Convert.ToDateTime(dr.Cells["C_DATE_OF_BIRTH_HIS"].Value.ToString());
                    smWorkList.BIRTH_PLACE = dr.Cells["C_BIRTH_PLACE_HIS"].Value.ToString();
                    //smWorkList.BIRTH_PLACE_CODE = dr.Cells["C_BIRTH_PLACE_CODE_HIS"].Value.ToString();
                    smWorkList.PATIENT_IDENTITY = dr.Cells["C_IDENTITY_HIS"].Value.ToString();
                    if (dr.Cells["C_CHARGE_TYPE_HIS"].Value.ToString() != "")
                        smWorkList.CHARGE_TYPE = Convert.ToInt32(dr.Cells["C_CHARGE_TYPE_HIS"].Value.ToString());
                    smWorkList.MAILING_ADDRESS = dr.Cells["C_MAILING_ADDRESS_HIS"].Value.ToString();
                    smWorkList.ZIP_CODE = dr.Cells["C_ZIP_CODE_HIS"].Value.ToString();
                    smWorkList.TELEPHONE_NUM = dr.Cells["C_PHONE_NUMBER_HIS"].Value.ToString();
                    smWorkList.EXAM_CLASS = dr.Cells["C_EXAM_CLASS_HIS"].Value.ToString();
                    smWorkList.EXAM_SUB_CLASS = dr.Cells["C_EXAM_SUB_CLASS_HIS"].Value.ToString();
                    smWorkList.CLIN_SYMP = dr.Cells["C_CLIN_SYMP_HIS"].Value.ToString();
                    smWorkList.PHYS_SIGN = dr.Cells["C_PHYS_SIGN_HIS"].Value.ToString();
                    smWorkList.RELEVANT_LAB_TEST = dr.Cells["C_RELEVANT_LAB_TEST_HIS"].Value.ToString();
                    smWorkList.RELEVANT_DIAG = dr.Cells["C_RELEVANT_DIAG_HIS"].Value.ToString();
                    smWorkList.CLIN_DIAG = dr.Cells["C_CLIN_DIAG_HIS"].Value.ToString();
                    smWorkList.EXAM_MODE = dr.Cells["C_EXAM_MODE_HIS"].Value.ToString();
                    smWorkList.EXAM_GROUP = dr.Cells["C_EXAM_GROUP_HIS"].Value.ToString();
                    smWorkList.EXAM_DEPT = dr.Cells["C_PERFORMED_BY_HIS"].Value.ToString();
                    smWorkList.PATIENT_SOURCE = dr.Cells["C_PATIENT_SOURCE_HIS"].Value.ToString();
                    smWorkList.OUT_MED_INSTITUTION = dr.Cells["C_FACILITY_HIS"].Value.ToString();
                    if (dr.Cells["C_REQ_DATE_TIME_HIS"].Value.ToString() != "")
                        smWorkList.REQ_DATE_TIME = Convert.ToDateTime(dr.Cells["C_REQ_DATE_TIME_HIS"].Value.ToString());
                    smWorkList.REFER_DEPT = dr.Cells["C_REQ_DEPT_HIS"].Value.ToString();
                    smWorkList.REFER_DOCTOR = dr.Cells["C_REQ_PHYSICIAN_HIS"].Value.ToString();
                    smWorkList.REQ_MEMO = dr.Cells["C_REQ_MEMO_HIS"].Value.ToString();
                    if (dr.Cells["C_SCHEDULED_DATE_HIS"].Value.ToString() != "")
                        smWorkList.SCHEDULED_DATE = Convert.ToDateTime(dr.Cells["C_SCHEDULED_DATE_HIS"].Value.ToString());
                    //smWorkList.NOTICE = dr.Cells["C_NOTICE_HIS"].Value.ToString();
                    if (dr.Cells["C_COSTS_HIS"].Value.ToString() != "")
                        smWorkList.COSTS = Convert.ToDecimal(dr.Cells["C_COSTS_HIS"].Value.ToString());
                    if (dr.Cells["C_CHARGES_HIS"].Value.ToString() != "")
                        smWorkList.CHARGES = Convert.ToDecimal(dr.Cells["C_CHARGES_HIS"].Value.ToString());
                    break;
            }

            if (dr.Cells["C_PATIENT_SOURCE_NAME_HIS"].Value.ToString() == "病房")
                this.mode = "11";
            else
                this.mode = "01";
        }*/
        /// <summary>
        /// 选中PACS系统病人资料库记录
        /// </summary>
        private void SelectPatientInf()
        {
            DataGridViewRow dr = this.dgv_PatientInf.CurrentRow;
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    SIS_Model.MArchives mArchives = (SIS_Model.MArchives)this.iArchives;
                    mArchives.PATIENT_ID = dr.Cells["C_PATIENT_ID"].Value.ToString();
                    mArchives.PATIENT_NAME = dr.Cells["C_PATIENT_NAME"].Value.ToString();
                    mArchives.PATIENT_SEX = dr.Cells["C_PATIENT_SEX"].Value.ToString();
                    if (dr.Cells["C_PATIENT_BIRTH"].Value.ToString() != "")
                        mArchives.PATIENT_BIRTH = Convert.ToDateTime(dr.Cells["C_PATIENT_BIRTH"].Value.ToString());
                    mArchives.BIRTH_PLACE = dr.Cells["C_BIRTH_PLACE"].Value.ToString();
                    //mPatientInf.BIRTH_PLACE_CODE = dr.Cells["C_BIRTH_PLACE_CODE"].Value.ToString();
                    mArchives.IDENTITY_CARD_NO = dr.Cells["C_IDENTITY_CARD_NO"].Value.ToString();
                    mArchives.MAILING_ADDRESS = dr.Cells["C_MAILING_ADDRESS"].Value.ToString();
                    mArchives.ZIP_CODE = dr.Cells["C_ZIP_CODE"].Value.ToString();
                    mArchives.TELEPHONE_NUM = dr.Cells["C_TELEPHONE_NUMBER"].Value.ToString();
                    mArchives.NATIVE_PLACE = dr.Cells["C_PATIENT_BIRTH"].Value.ToString();
                    mArchives.HABITATION = dr.Cells["C_HABITATION"].Value.ToString();
                    mArchives.OPD_NO = dr.Cells["C_OPD_NO"].Value.ToString();
                    mArchives.INP_NO = dr.Cells["C_INP_NO"].Value.ToString();
                    SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.iWorkList;
                    if (GetConfig.hisVisit)
                    {
                        switch (GetConfig.hisVender)
                        {
                            case "JW":
                                smWorkList.EXAM_NO = this.regJW.GetExamNo();
                                break;
                            case "HT":
                                break;
                        }
                    }
                    if (dr.Cells["C_PATIENT_CLASS"].Value != null && dr.Cells["C_PATIENT_CLASS"].Value.ToString() != "")
                        smWorkList.PATIENT_CLASS = Convert.ToInt32(dr.Cells["C_PATIENT_CLASS"].Value.ToString());
                    //smWorkList.PATIENT_PHONETIC = dr.Cells["C_PATIENT_ENGLISH_NAME"].Value.ToString();
                    smWorkList.OPD_NO = dr.Cells["C_OPD_NO"].Value.ToString();
                    smWorkList.INP_NO = dr.Cells["C_INP_NO"].Value.ToString();
                    smWorkList.PATIENT_ID = dr.Cells["C_PATIENT_ID"].Value.ToString();
                    smWorkList.PATIENT_NAME = dr.Cells["C_PATIENT_NAME"].Value.ToString();
                    smWorkList.PATIENT_SEX = dr.Cells["C_PATIENT_SEX"].Value.ToString();
                    if (dr.Cells["C_PATIENT_BIRTH"].Value.ToString() != "")
                        smWorkList.PATIENT_BIRTH = Convert.ToDateTime(dr.Cells["C_PATIENT_BIRTH"].Value.ToString());
                    smWorkList.BIRTH_PLACE = dr.Cells["C_BIRTH_PLACE"].Value.ToString();
                    smWorkList.MAILING_ADDRESS = dr.Cells["C_MAILING_ADDRESS"].Value.ToString();
                    smWorkList.ZIP_CODE = dr.Cells["C_ZIP_CODE"].Value.ToString();
                    smWorkList.TELEPHONE_NUM = dr.Cells["C_TELEPHONE_NUMBER"].Value.ToString();
                    break;
                case "PACS":
                    PACS_Model.MArchives mPatientInf = (PACS_Model.MArchives)this.iArchives;
                    mPatientInf.PATIENT_ID = dr.Cells["C_PATIENT_ID"].Value.ToString();
                    mPatientInf.PATIENT_NAME = dr.Cells["C_PATIENT_NAME"].Value.ToString();
                    mPatientInf.PATIENT_SEX = dr.Cells["C_PATIENT_SEX"].Value.ToString();
                    if (dr.Cells["C_PATIENT_BIRTH"].Value.ToString() != "")
                        mPatientInf.PATIENT_BIRTH = Convert.ToDateTime(dr.Cells["C_PATIENT_BIRTH"].Value.ToString());
                    mPatientInf.BIRTH_PLACE = dr.Cells["C_BIRTH_PLACE"].Value.ToString();
                    //mPatientInf.BIRTH_PLACE_CODE = dr.Cells["C_BIRTH_PLACE_CODE"].Value.ToString();
                    mPatientInf.IDENTITY_CARD_NO = dr.Cells["C_IDENTITY_CARD_NO"].Value.ToString();
                    mPatientInf.MAILING_ADDRESS = dr.Cells["C_MAILING_ADDRESS"].Value.ToString();
                    mPatientInf.ZIP_CODE = dr.Cells["C_ZIP_CODE"].Value.ToString();
                    mPatientInf.TELEPHONE_NUMBER = dr.Cells["C_TELEPHONE_NUMBER"].Value.ToString();
                    mPatientInf.NATIVE_PLACE = dr.Cells["C_PATIENT_BIRTH"].Value.ToString();
                    mPatientInf.HABITATION = dr.Cells["C_HABITATION"].Value.ToString();
                    mPatientInf.OPD_NO = dr.Cells["C_OPD_NO"].Value.ToString();
                    mPatientInf.INP_NO = dr.Cells["C_INP_NO"].Value.ToString();
                    PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.iWorkList;
                    if (GetConfig.hisVisit)
                    {
                        switch (GetConfig.hisVender)
                        {
                            case "JW":
                                pmWorkList.EXAM_NO = this.regJW.GetExamNo();
                                break;
                            case "HT":
                                break;
                        }
                    }
                    if (dr.Cells["C_PATIENT_CLASS"].Value != null && dr.Cells["C_PATIENT_CLASS"].Value.ToString() != "")
                        pmWorkList.PATIENT_CLASS = Convert.ToInt32(dr.Cells["C_PATIENT_CLASS"].Value.ToString());
                    //pmWorkList.PATIENT_PHONETIC = dr.Cells["C_PATIENT_ENGLISH_NAME"].Value.ToString();
                    pmWorkList.OPD_NO = dr.Cells["C_OPD_NO"].Value.ToString();
                    pmWorkList.INP_NO = dr.Cells["C_INP_NO"].Value.ToString();
                    pmWorkList.PATIENT_ID = dr.Cells["C_PATIENT_ID"].Value.ToString();
                    pmWorkList.PATIENT_NAME = dr.Cells["C_PATIENT_NAME"].Value.ToString();
                    pmWorkList.PATIENT_SEX = dr.Cells["C_PATIENT_SEX"].Value.ToString();
                    if (dr.Cells["C_PATIENT_BIRTH"].Value.ToString() != "")
                        pmWorkList.PATIENT_BIRTH = Convert.ToDateTime(dr.Cells["C_PATIENT_BIRTH"].Value.ToString());
                    pmWorkList.BIRTH_PLACE = dr.Cells["C_BIRTH_PLACE"].Value.ToString();
                    pmWorkList.MAILING_ADDRESS = dr.Cells["C_MAILING_ADDRESS"].Value.ToString();
                    pmWorkList.ZIP_CODE = dr.Cells["C_ZIP_CODE"].Value.ToString();
                    pmWorkList.TELEPHONE_NUM = dr.Cells["C_TELEPHONE_NUMBER"].Value.ToString();
                    break;
            }
        }

        /// <summary>
        /// 选中HIS病人资料库记录
        /// </summary>
        private void SelectPatMasterIndex()
        {
            DataGridViewRow dr = this.dgv_PatMasterIndex.CurrentRow;
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.iWorkList;
                    smWorkList.PATIENT_ID = dr.Cells["C_PATIENT_ID_PAT"].Value.ToString();
                    smWorkList.PATIENT_NAME = dr.Cells["C_NAME_PAT"].Value.ToString();
                    smWorkList.PATIENT_SEX = dr.Cells["C_SEX_PAT"].Value.ToString();
                    if (dr.Cells["C_DATE_OF_BIRTH_PAT"].Value.ToString() != "")
                        smWorkList.PATIENT_BIRTH = Convert.ToDateTime(dr.Cells["C_DATE_OF_BIRTH_PAT"].Value.ToString());
                    smWorkList.BIRTH_PLACE = dr.Cells["C_BIRTH_PLACE_PAT"].Value.ToString();
                    //smWorkList.BIRTH_PLACE_CODE = dr.Cells["C_BIRTH_PLACE_CODE_PAT"].Value.ToString();
                    if (dr.Cells["C_CHARGE_TYPE_PAT"].Value.ToString() != "")
                        smWorkList.CHARGE_TYPE = Convert.ToInt32(dr.Cells["C_CHARGE_TYPE_PAT"].Value.ToString());
                    smWorkList.MAILING_ADDRESS = dr.Cells["C_MAILING_ADDRESS_PAT"].Value.ToString();
                    smWorkList.ZIP_CODE = dr.Cells["C_ZIP_CODE_PAT"].Value.ToString();
                    smWorkList.TELEPHONE_NUM = dr.Cells["C_PHONE_NUMBER_HOME_PAT"].Value.ToString();
                    smWorkList.INP_NO = dr.Cells["C_INP_NO_PAT"].Value.ToString();
                    smWorkList.PATIENT_IDENTITY = dr.Cells["C_IDENTITY_PAT"].Value.ToString();
                    smWorkList.PATIENT_PHONETIC = dr.Cells["C_NAME_PHONETIC_PAT"].Value.ToString();
                    switch (GetConfig.hisVender)
                    {
                        case "JW":
                            smWorkList.EXAM_NO = this.regJW.GetExamNo();
                            break;
                        case "HT":
                            break;
                    }
                    SIS_Model.MArchives mArchives = (SIS_Model.MArchives)this.iArchives;
                    mArchives.IDENTITY_CARD_NO = dr.Cells["C_ID_NO_PAT"].Value.ToString();
                    break;
                case "PACS":
                    PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.iWorkList;
                    pmWorkList.PATIENT_ID = dr.Cells["C_PATIENT_ID_PAT"].Value.ToString();
                    pmWorkList.PATIENT_NAME = dr.Cells["C_NAME_PAT"].Value.ToString();
                    pmWorkList.PATIENT_SEX = dr.Cells["C_SEX_PAT"].Value.ToString();
                    if (dr.Cells["C_DATE_OF_BIRTH_PAT"].Value.ToString() != "")
                        pmWorkList.PATIENT_BIRTH = Convert.ToDateTime(dr.Cells["C_DATE_OF_BIRTH_PAT"].Value.ToString());
                    pmWorkList.BIRTH_PLACE = dr.Cells["C_BIRTH_PLACE_PAT"].Value.ToString();
                    //pmWorkList.BIRTH_PLACE_CODE = dr.Cells["C_BIRTH_PLACE_CODE_PAT"].Value.ToString();
                    if (dr.Cells["C_CHARGE_TYPE_PAT"].Value.ToString() != "")
                        pmWorkList.CHARGE_TYPE = Convert.ToInt32(dr.Cells["C_CHARGE_TYPE_PAT"].Value.ToString());
                    pmWorkList.MAILING_ADDRESS = dr.Cells["C_MAILING_ADDRESS_PAT"].Value.ToString();
                    pmWorkList.ZIP_CODE = dr.Cells["C_ZIP_CODE_PAT"].Value.ToString();
                    pmWorkList.TELEPHONE_NUM = dr.Cells["C_PHONE_NUMBER_HOME_PAT"].Value.ToString();
                    pmWorkList.INP_NO = dr.Cells["C_INP_NO_PAT"].Value.ToString();
                    pmWorkList.PATIENT_IDENTITY = dr.Cells["C_IDENTITY_PAT"].Value.ToString();
                    pmWorkList.PATIENT_PHONETIC = dr.Cells["C_NAME_PHONETIC_PAT"].Value.ToString();
                    switch (GetConfig.hisVender)
                    {
                        case "JW":
                            pmWorkList.EXAM_NO = this.regJW.GetExamNo();
                            break;
                        case "HT":
                            break;
                    }
                    PACS_Model.MArchives mPatientInf = (PACS_Model.MArchives)this.iArchives;
                    mPatientInf.IDENTITY_CARD_NO = dr.Cells["C_ID_NO_PAT"].Value.ToString();
                    break;
            }
        }

        private void RegSearch_Load(object sender, EventArgs e)
        {
            if (this.dgv_PatMasterIndex.Rows.Count != 0)
                this.dgv_PatMasterIndex.Rows[0].Selected = false;
            if (this.dgv_PatientInf.Rows.Count != 0)
            {
                this.dgv_PatientInf.Focus();
                this.dgv_PatientInf.Rows[0].Selected = true;
            }
            if (this.dgv_ExamAppoints.Rows.Count != 0)
                this.dgv_ExamAppoints.Rows[0].Selected = true;
        }

        private void frmRegSearch_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Enter:
                    dgv_PatientInf_DoubleClick(null, null);
                    break;
                default:
                    break;
            }
        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            this.sqlHis = this.GetHisWhereStr();
            this.sqlPacs = this.GetPacsWhereStr();
            Search();
        }
        private void ClearResult()
        {
            this.dgv_ExamAppoints.DataSource = null;
            this.dgv_PatientInf.DataSource = null;
            this.dgv_PatMasterIndex.DataSource = null;
            this.p_His.Visible = false;
            this.p_PatMasterIndex.Visible = false;
            this.p_PatsInHospital.Visible = false;
        }

        private void dgv_ExamAppoints_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Enter:
                    this.dgv_ExamAppoints_DoubleClick(null, null);
                    break;
                default:
                    break;
            }
        }
        //private void dataGridView_patient_inf_DataSourceChanged(object sender, EventArgs e)
        //{
        //    if (this.dataGridView_PATIENT_INF.DataSource != null)
        //    {
        //        for (int i = 0; i < this.dataGridView_PATIENT_INF.Rows.Count; i++)
        //        {
        //            string birth = this.dataGridView_PATIENT_INF.Rows[i].Cells["C_PATIENT_BIRTH"].Value.ToString();
        //            this.dataGridView_PATIENT_INF.Rows[i].Cells["C_PATIENT_AGE"].Value = System.DateTime.Now.Year - Convert.ToInt32(birth.Substring(0, 4));
        //        }
        //    }
        //}

    }
}
