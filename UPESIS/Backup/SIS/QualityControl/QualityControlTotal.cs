using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SIS_BLL;
using System.Collections;
using PACS_Model;

namespace SIS.QualityControl
{
    public partial class QualityControlTotal : Form
    {
        private BStudy bsty = new BStudy();

        private string[] tpArray = null;

        public QualityControlTotal()
        {
            InitializeComponent();
        }

        private void Bind_Report_STATUS()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("index", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Metxt", typeof(string)));

            DataRow dr0 = dt.NewRow();
            DataRow dr1 = dt.NewRow();
            DataRow dr2 = dt.NewRow();
            DataRow dr3 = dt.NewRow();

            dr1["index"] = 0; dr1["Metxt"] = "未写";
            dr2["index"] = 1; dr2["Metxt"] = "已写";
            dr3["index"] = 2; dr3["Metxt"] = "正在写";
            dt.Rows.Add(dr0);
            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);
            dt.Rows.Add(dr3);            

            ((DataGridViewComboBoxColumn)this.dgv_study.Columns["REPORT_STATUS"]).DataSource = dt;
            ((DataGridViewComboBoxColumn)this.dgv_study.Columns["REPORT_STATUS"]).DisplayMember = "Metxt";
            ((DataGridViewComboBoxColumn)this.dgv_study.Columns["REPORT_STATUS"]).ValueMember = "index";
        }

        //方法填充检查类别下拉框
        private void Bind_EXAM_CLASS()
        {
            SIS_Function.ApiIni AI = new SIS_Function.ApiIni(Application.StartupPath + @"\Settings.ini");
            String tp = AI.IniReadValue("RegisterMode", "ExamClass");
            string[] ArrStrList = tp.Split(',');
            cmb_EXAM_CLASS.Items.Clear();
            cmb_EXAM_CLASS.Items.Add("");
            foreach (string s in ArrStrList)
            {
                cmb_EXAM_CLASS.Items.Add(s);
            }
        }

        //填充申请科室下拉框
        private void Bind_REQ_DEPT_NAME()
        {
            BClinicOfficeDict bNam = new BClinicOfficeDict();
            DataTable dt = bNam.GetList(" 1=1 order by DEPT_CODE");

            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);

            cmb_REQ_DEPT_NAME.DataSource = dt;
            cmb_REQ_DEPT_NAME.DisplayMember = "DEPT_NAME";
            cmb_REQ_DEPT_NAME.ValueMember = "DEPT_CODE";
        }

        private void FindData(string where)
        {
            DataTable dt = bsty.GetList(where + " 1=1 Order by STUDY_KEY");
            if (dt != null)
            {
                dgv_study.DataSource = dt;
            }
        }

        private void QualityControlTotal_Load(object sender, EventArgs e)
        {
            this.btn_FunName.Text = this.Text.ToString();
            this.dgv_study.AutoGenerateColumns = false;

            dtp_STUDY_DATE_TIME_Begin.Value = DateTime.Now.AddDays(-1);
            dtp_STUDY_DATE_TIME_End.Value = DateTime.Now;

            Bind_Report_STATUS();
            Bind_EXAM_CLASS();
            Bind_REQ_DEPT_NAME();

            tpArray = SIS.frmDockForm.QualityControlFlag.Split(';');
            if (tpArray == null) return;

            btn_Find_Click(null, null);
        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            StringBuilder StrQueue = new StringBuilder();

            if (txt_PATIENT_AGE.Text.Trim()!="")
                StrQueue.Append("PATIENT_AGE='" + txt_PATIENT_AGE.Text.Trim() + "' and ");
            if (cmb_PATIENT_SEX.Text!="")
                StrQueue.Append("PATIENT_SEX='" + cmb_PATIENT_SEX.Text.Trim() + "' and ");
            if (cmb_EXAM_CLASS.Text != "")
                StrQueue.Append("EXAM_CLASS='" + cmb_EXAM_CLASS.Text + "' and ");
            if (cmb_EXAM_SUB_CLASS.Text != "")
                StrQueue.Append("EXAM_SUB_CLASS='" + cmb_EXAM_SUB_CLASS.Text + "' and ");
            if (txt_INP_NO.Text.Trim()!="")
                StrQueue.Append("INP_NO='" + txt_INP_NO.Text.Trim() + "' and ");
            if (txt_PATIENT_ID.Text.Trim()!="")
                StrQueue.Append("PATIENT_ID like '%" + txt_PATIENT_ID.Text.Trim() + "%' and ");
            if (txt_STUDY_ID.Text.Trim() != "")
                StrQueue.Append("STUDY_ID='" + txt_STUDY_ID.Text.Trim() + "' and ");
            if (txt_PATIENT_NAME.Text.Trim() != "")
                StrQueue.Append("PATIENT_NAME like '%" + txt_PATIENT_NAME.Text.Trim() + "%' and ");
            if (cmb_PATIENT_SOURCE.Text.Trim() != "")
                StrQueue.Append("PATIENT_SOURCE='" + cmb_PATIENT_SOURCE.Text.Trim() + "' and ");
            if (cmb_PATIENT_SEX.Text.Trim() != "")
                StrQueue.Append("PATIENT_SEX='" + cmb_PATIENT_SEX.Text.Trim() + "' and ");
            if (cmb_REQ_DEPT_NAME.Text.Trim() != "")
                StrQueue.Append("REQ_DEPT_NAME='" + cmb_REQ_DEPT_NAME.Text.Trim() + "' and ");
            if (cmb_REFER_DOCTOR.Text.Trim() != "")
                StrQueue.Append("REFER_DOCTOR='" + cmb_REFER_DOCTOR.Text.Trim() + "' and ");
            if (txt_MODALITY.Text.Trim()!="")
                StrQueue.Append("MODALITY like '%" + cmb_REFER_DOCTOR.Text.Trim() + "%' and ");

            SIS_Function.ApiIni AI;
            switch (tpArray[2])
            {
                case "正位胸片统计":
                    AI = new SIS_Function.ApiIni(Application.StartupPath + @"\Settings.ini");
                    string Sternum = AI.IniReadValue("QC_Name", "Sternum");

                    StrQueue.Append("EXAM_ITEM='" + Sternum + "' and ");
                    break;
                case "膝关节统计":
                    AI = new SIS_Function.ApiIni(Application.StartupPath + @"\Settings.ini");
                    string Knuckle = AI.IniReadValue("QC_Name", "Knuckle");

                    StrQueue.Append("EXAM_ITEM='" + Knuckle + "' and ");
                    break;
                case "上消化道统计":
                    AI = new SIS_Function.ApiIni(Application.StartupPath + @"\Settings.ini");
                    string UGI = AI.IniReadValue("QC_Name", "UGI");

                    StrQueue.Append("EXAM_ITEM='" + UGI + "' and ");
                    break;
                case "静脉肾孟统计":
                    AI = new SIS_Function.ApiIni(Application.StartupPath + @"\Settings.ini");
                    string IVP = AI.IniReadValue("QC_Name", "IVP");

                    StrQueue.Append("EXAM_ITEM='" + IVP + "' and ");
                    break;
                case "CT统计":
                    StrQueue.Append("EXAM_CLASS='CT' and ");
                    break;
                case "MRI统计":
                    StrQueue.Append("EXAM_CLASS='MRI' and ");
                    break;
                case "放射诊断统计":
                    StrQueue.Append("EXAM_CLASS='放射' and ");
                    break;
            }
            if (comb_RPTStatus.Text != "")
            {
                switch (comb_RPTStatus.Text)
                {
                    case "未写":
                        StrQueue.Append("REPORT_STATUS=0 and ");
                        break;
                    case "已写":
                        StrQueue.Append("REPORT_STATUS=1 and ");
                        break;
                    case "正在写":
                        StrQueue.Append("REPORT_STATUS=2 and ");
                        break;
                    default:
                        break;
                }
            }

            if (dtp_STUDY_DATE_TIME_Begin.Checked)
            {
                if (dtp_STUDY_DATE_TIME_End.Checked)
                    StrQueue.Append("STUDY_DATE_TIME between to_date('" + dtp_STUDY_DATE_TIME_Begin.Value.ToString() +
                        "','YYYY-MM-DD HH24:MI:SS') AND TO_DATE('" + dtp_STUDY_DATE_TIME_End.Value.ToString() + "','YYYY-MM-DD HH24:MI:SS') AND ");
                else
                    StrQueue.Append("STUDY_DATE_TIME >= to_date('" + dtp_STUDY_DATE_TIME_Begin.Value.ToString() + "','YYYY-MM-DD HH24:MI:SS') AND ");
            }
            else
            {
                if (dtp_STUDY_DATE_TIME_End.Checked)
                    StrQueue.Append("STUDY_DATE_TIME <= TO_DATE('" + dtp_STUDY_DATE_TIME_End.Value.ToString() + "','YYYY-MM-DD HH24:MI:SS') AND ");
            }

            FindData(StrQueue.ToString());
        }

        private void btn_Clean_Click(object sender, EventArgs e)
        {
            foreach (Control crl in myPnl.Controls)
            {
                if (crl is TextBox)
                    crl.Text = "";
                else if (crl is ComboBox)
                    crl.Text = "";
            }
            dtp_STUDY_DATE_TIME_Begin.Value = DateTime.Now.AddDays(-1);
            dtp_STUDY_DATE_TIME_End.Value = DateTime.Now;
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvSelRowArray = dgv_study.SelectedRows;

            if (dgvSelRowArray.Count > 10)
            {
                MessageBoxEx.Show("一次选择的记录不能超过10条!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                ArrayList ExamAccessionNum = new ArrayList();
                bool bl;
                switch (tpArray[2])
                {
                    case "正位胸片统计":
                        bl = SelectFilmAndDI(ref ExamAccessionNum); //去除选中记录中已经统计过的记录

                        QC_Sternum frm_sternum = new QC_Sternum();
                        bl = frm_sternum.InitForm(ExamAccessionNum);
                        if (bl)
                            frm_sternum.ShowDialog();

                        break;
                    case "膝关节统计":
                        bl = SelectFilmAndDI(ref ExamAccessionNum);

                        QC_Knuckle frm_knuckle = new QC_Knuckle();
                        bl = frm_knuckle.InitForm(ExamAccessionNum);
                        if (bl)
                            frm_knuckle.ShowDialog();

                        break;
                    case "上消化道统计":
                        bl = SelectFilmAndDI(ref ExamAccessionNum);

                        QC_UGI frm_ugi = new QC_UGI();
                        bl=frm_ugi.InitForm(ExamAccessionNum);
                        if (bl )
                            frm_ugi.ShowDialog();   

                        break;
                    case "静脉肾孟统计":
                        bl = SelectFilmAndDI(ref ExamAccessionNum);

                        QC_IVP frm_ivp = new QC_IVP();
                        bl= frm_ivp.InitForm(ExamAccessionNum);
                        if (bl )
                            frm_ivp.ShowDialog();

                        break;
                    case "CT统计":
                        bl = SelectCT(ref ExamAccessionNum);

                        QC_CT frm_ct = new QC_CT();
                        bl=frm_ct.InitForm(ExamAccessionNum);
                        if (bl )
                        frm_ct.ShowDialog();

                        break;
                    case "MRI统计":
                        bl = SelectMRI(ref ExamAccessionNum);

                        QC_MRI frm_mri = new QC_MRI();
                        bl=frm_mri.InitForm(ExamAccessionNum);
                        if (bl)
                            frm_mri.ShowDialog();

                        break;
                    case "放射诊断统计":
                        bl = SelectRY_DIAG_DICT(ref ExamAccessionNum);

                        QC_RY_DIAG_DICT frm_rydtagdict = new QC_RY_DIAG_DICT();
                        bl=frm_rydtagdict.InitForm(ExamAccessionNum);
                        if (bl)
                        frm_rydtagdict.ShowDialog();

                        break;
                    case "统计管理":
                        QC_ImageManage frm_imageManage = new QC_ImageManage();
                        frm_imageManage.ShowDialog();

                        break;
                    case "科室管理统计":
                        QC_DEPT_MAN_DICT frm_deptmandict = new QC_DEPT_MAN_DICT();
                        frm_deptmandict.ShowDialog();

                        break;
                    default:
                        break;
                }
            }
        }

        private bool SelectFilmAndDI(ref ArrayList ExamAccessionNum)
        {
            BQcFilm bqcflm = new BQcFilm();
            BQcDigitalImage bqcdtimg = new BQcDigitalImage();
            bool bl = false;

            for (int i = 0; i < this.dgv_study.SelectedRows.Count; i++)
            {
                MQcFilm mqcflm = new MQcFilm();
                MQcDigitalImage mqcdtimg = new MQcDigitalImage();
                mqcflm.EXAM_ACCESSION_NUM = dgv_study.SelectedRows[i].Cells["EXAM_ACCESSION_NUM"].Value.ToString();
                mqcdtimg.EXAM_ACCESSION_NUM = dgv_study.SelectedRows[i].Cells["EXAM_ACCESSION_NUM"].Value.ToString();

                bool bl1 = bqcflm.Exists(mqcflm);
                bool bl2 = bqcdtimg.Exists(mqcdtimg);

                if (!bl1 && !bl2)
                {
                    MQcInformation mqcInfor = new MQcInformation();
                    mqcInfor.EXAM_ACCESSION_NUM = this.dgv_study.SelectedRows[i].Cells["EXAM_ACCESSION_NUM"].Value.ToString();
                    mqcInfor.LOCAL_ID = this.dgv_study.SelectedRows[i].Cells["STUDY_ID"].Value.ToString();
                    mqcInfor.NAME = this.dgv_study.SelectedRows[i].Cells["PATIENT_NAME"].Value.ToString();
                    mqcInfor.SEX = this.dgv_study.SelectedRows[i].Cells["PATIENT_SEX"].Value.ToString();
                    mqcInfor.STUDY_DATE_TIME = this.dgv_study.SelectedRows[i].Cells["STUDY_DATE_TIME"].Value.ToString();
                    mqcInfor.PATIENT_ID = this.dgv_study.SelectedRows[i].Cells["PATIENT_ID"].Value.ToString();
                    ExamAccessionNum.Add(mqcInfor);
                }
                else
                {
                    bl = true;
                }
            }
            return bl;
        }

        private bool  SelectCT(ref ArrayList ExamAccessionNum)
        {
            BQcCt bqcct = new BQcCt();
            bool bl = false;

            for (int i = 0; i < this.dgv_study.SelectedRows.Count; i++)
            {
                MQcCt mqcct = new MQcCt();
                mqcct.EXAM_ACCESSION_NUM = dgv_study.SelectedRows[i].Cells["EXAM_ACCESSION_NUM"].Value.ToString();
                bool bl1 = bqcct.Exists(mqcct);

                if (!bl1)
                {
                    MQcInformation mqcInfor = new MQcInformation();
                    mqcInfor.EXAM_ACCESSION_NUM = this.dgv_study.SelectedRows[i].Cells["EXAM_ACCESSION_NUM"].Value.ToString();
                    mqcInfor.LOCAL_ID = this.dgv_study.SelectedRows[i].Cells["STUDY_ID"].Value.ToString();
                    mqcInfor.NAME = this.dgv_study.SelectedRows[i].Cells["PATIENT_NAME"].Value.ToString();
                    mqcInfor.SEX = this.dgv_study.SelectedRows[i].Cells["PATIENT_SEX"].Value.ToString();
                    mqcInfor.STUDY_DATE_TIME = this.dgv_study.SelectedRows[i].Cells["STUDY_DATE_TIME"].Value.ToString();
                    mqcInfor.PATIENT_ID = this.dgv_study.SelectedRows[i].Cells["PATIENT_ID"].Value.ToString();
                    ExamAccessionNum.Add(mqcInfor);
                }
                else
                {
                    bl = true;
                }
            }
            return bl;
        }

        private bool  SelectMRI(ref ArrayList ExamAccessionNum)
        {
            BQcMri bqcmri = new BQcMri();
            bool bl = false;

            for (int i = 0; i < this.dgv_study.SelectedRows.Count; i++)
            {
                MQcMri mqcmri = new MQcMri();
                mqcmri.EXAM_ACCESSION_NUM = dgv_study.SelectedRows[i].Cells["EXAM_ACCESSION_NUM"].Value.ToString();
                bool bl1 = bqcmri.Exists(mqcmri);

                if (!bl1)
                {
                    MQcInformation mqcInfor = new MQcInformation();
                    mqcInfor.EXAM_ACCESSION_NUM = this.dgv_study.SelectedRows[i].Cells["EXAM_ACCESSION_NUM"].Value.ToString();
                    mqcInfor.LOCAL_ID = this.dgv_study.SelectedRows[i].Cells["STUDY_ID"].Value.ToString();
                    mqcInfor.NAME = this.dgv_study.SelectedRows[i].Cells["PATIENT_NAME"].Value.ToString();
                    mqcInfor.SEX = this.dgv_study.SelectedRows[i].Cells["PATIENT_SEX"].Value.ToString();
                    mqcInfor.STUDY_DATE_TIME = this.dgv_study.SelectedRows[i].Cells["STUDY_DATE_TIME"].Value.ToString();
                    mqcInfor.PATIENT_ID = this.dgv_study.SelectedRows[i].Cells["PATIENT_ID"].Value.ToString();
                    ExamAccessionNum.Add(mqcInfor);
                }
                else
                {
                    bl = true;
                }
            }
            return bl;
        }

        private bool  SelectRY_DIAG_DICT(ref ArrayList ExamAccessionNum)
        {
            BQcRyDiagDict bqrd = new BQcRyDiagDict();
            bool bl = false;

            for (int i = 0; i < this.dgv_study.SelectedRows.Count; i++)
            {
                MQcRyDiagDict mqrd = new MQcRyDiagDict();
                mqrd.EXAM_ACCESSION_NUM = dgv_study.SelectedRows[i].Cells["EXAM_ACCESSION_NUM"].Value.ToString();
                bool bl1 = bqrd.Exists(mqrd);

                if (!bl1)
                {
                    MQcInformation mqcInfor = new MQcInformation();
                    mqcInfor.EXAM_ACCESSION_NUM = this.dgv_study.SelectedRows[i].Cells["EXAM_ACCESSION_NUM"].Value.ToString();
                    mqcInfor.LOCAL_ID = this.dgv_study.SelectedRows[i].Cells["STUDY_ID"].Value.ToString();
                    mqcInfor.NAME = this.dgv_study.SelectedRows[i].Cells["PATIENT_NAME"].Value.ToString();
                    mqcInfor.SEX = this.dgv_study.SelectedRows[i].Cells["PATIENT_SEX"].Value.ToString();
                    mqcInfor.STUDY_DATE_TIME = this.dgv_study.SelectedRows[i].Cells["STUDY_DATE_TIME"].Value.ToString();
                    mqcInfor.PATIENT_ID = this.dgv_study.SelectedRows[i].Cells["PATIENT_ID"].Value.ToString();
                    ExamAccessionNum.Add(mqcInfor);
                }
                else
                {
                    bl = true;
                }
            }
            return bl;
        }

        private void dgv_study_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        //改变时填充检查子类下拉框
        private void cmb_EXAM_CLASS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_EXAM_CLASS.Text == "") return;

            BExamClass bem = new BExamClass();
            DataTable dt = bem.GetList(" EXAM_CLASS='" + cmb_EXAM_CLASS.Text + "' ORDER BY EXAM_SUB_CLASS");

            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            cmb_EXAM_SUB_CLASS.DataSource = dt;
            cmb_EXAM_SUB_CLASS.DisplayMember = "EXAM_SUB_CLASS";
            cmb_EXAM_SUB_CLASS.ValueMember = "EXAM_SUB_CLASS";
        }

        //申请科室改变时填充申请医生下拉框
        private void cmb_REQ_DEPT_NAME_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_REQ_DEPT_NAME.Text == "") return;

            BUser bu = new BUser();
            DataTable dt = bu.GetList("DEPT_NAME='" + cmb_REQ_DEPT_NAME.Text + "'");
            DataRow DR = dt.NewRow();
            dt.Rows.InsertAt(DR,0);

            cmb_REFER_DOCTOR.DataSource = dt;
            cmb_REFER_DOCTOR.DisplayMember = "USER_NAME";
            cmb_REFER_DOCTOR.ValueMember = "USER_NAME";
        }


    }
}