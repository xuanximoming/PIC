using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using PACS_Model;
using SIS_BLL;
using CrystalDecisions.CrystalReports.Engine;

namespace SIS.QualityControl
{
    public partial class QC_ImageManage : Form
    {
        private BQcCt bCt = new BQcCt();
        //private BQcDeptManDict bDeptManDict = new BQcDeptManDict();
        private BQcFilm bFilm=new BQcFilm ();
        private BQcDigitalImage bDigitalImage=new BQcDigitalImage ();
        private BQcRyDiagDict bRyDiagDict = new BQcRyDiagDict();
        private BQcMri bMri = new BQcMri();
        private DataTable dtStrenum = new DataTable();  //记录最终的结果

        public QC_ImageManage()
        {
            InitializeComponent();
        }

        private void BindDistinction()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID",typeof(int)));
            dt.Columns.Add(new DataColumn("DISTINCTION", typeof(string)));

            DataRow dr1 = dt.NewRow();
            dr1["ID"] = 1; dr1["DISTINCTION"] = "一级片";
            DataRow dr2 = dt.NewRow();
            dr2["ID"] = 2; dr2["DISTINCTION"] = "二级片";
            DataRow dr3 = dt.NewRow();
            dr3["ID"] = 3; dr3["DISTINCTION"] = "三级片";
            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);
            dt.Rows.Add(dr3);

            ((DataGridViewComboBoxColumn)this.dgv_ImageManage.Columns["DISTINCTION"]).DataSource = dt;
            ((DataGridViewComboBoxColumn)this.dgv_ImageManage.Columns["DISTINCTION"]).DisplayMember = "DISTINCTION";
            ((DataGridViewComboBoxColumn)this.dgv_ImageManage.Columns["DISTINCTION"]).ValueMember = "ID";
        }

        private void QC_ImageManage_Load(object sender, EventArgs e)
        {
            this.btn_FunName.Text = this.Text;
            this.dgv_ImageManage.AutoGenerateColumns = false;
            
            InitCmb();
            cmb_Type.SelectedIndex = 0;

            dtStrenum.Columns.Add(new DataColumn("EXAM_ACCESSION_NUM", typeof(decimal)));   //检查申请号
            dtStrenum.Columns.Add(new DataColumn("PATIENT_LOCAL_ID", typeof(string)));   //检查号
            dtStrenum.Columns.Add(new DataColumn("PATIENT_ID", typeof(string)));   //病人ID
            dtStrenum.Columns.Add(new DataColumn("TYPE", typeof(string)));   //图像类型
            dtStrenum.Columns.Add(new DataColumn("PATIENT_NAME", typeof(string )));   //病人姓名
            dtStrenum.Columns.Add(new DataColumn("PATIENT_SEX", typeof(string )));   //性别
            dtStrenum.Columns.Add(new DataColumn("STUDY_DATE_TIME", typeof(DateTime)));   //检查时间
            dtStrenum.Columns.Add(new DataColumn("QC_DATE", typeof(DateTime)));   //质控时间
            dtStrenum.Columns.Add(new DataColumn("TOTAL_SCORE", typeof(decimal)));   //总分
            dtStrenum.Columns.Add(new DataColumn("DISTINCTION", typeof(int)));   //级别 

            BindDistinction();
        }

        private void InitCmb()
        {
            SIS_Function.ApiIni AI = new SIS_Function.ApiIni(Application.StartupPath + @"\Settings.ini");

            string Sternum = AI.IniReadValue("QC_Name", "Sternum");
            string UGI = AI.IniReadValue("QC_Name", "UGI");
            string IVP = AI.IniReadValue("QC_Name", "IVP");
            string Knuckle = AI.IniReadValue("QC_Name", "Knuckle");

            cmb_Type.Items.Add(Sternum);
            cmb_Type.Items.Add(Knuckle);
            cmb_Type.Items.Add(UGI);
            cmb_Type.Items.Add(IVP);
            cmb_Type.Items.Add("CT");
            cmb_Type.Items.Add("MRI");
            cmb_Type.Items.Add("放射诊断");
        }

        private void FindData()
        {
            switch (cmb_Type.SelectedIndex)
            {
                case 0:
                    Find_FilmAndDI(0);
                    break;
                case 1:
                    Find_FilmAndDI(1);
                    break;
                case 2:
                    Find_FilmAndDI(2);
                    break;
                case 3:
                    Find_FilmAndDI(3);
                    break;
                case 4:
                    Find_CT();
                    break;
                case 5:
                    Find_MRI();
                    break;
                case 6:
                    Find_RY();
                    break;
            }
        }

        private void Find_FilmAndDI(int flag)
        {
            StringBuilder strBld = new StringBuilder();
            switch (flag)
            {
                case 0:
                    strBld.Append(" QC_DATE Between to_date('" + dtp_QC_DATE.Value.AddDays(-dtp_QC_DATE.Value.Day + 1).ToShortDateString() +
                        "','yyyy-mm-dd') and to_date('" + dtp_QC_DATE.Value.AddDays(-dtp_QC_DATE.Value.Day + 1).AddMonths(1).ToShortDateString() +
                        "','yyyy-mm-dd') and STERNUM_BREAST is not null and ");
                    break;
                case 1:
                    strBld.Append(" QC_DATE Between to_date('" + dtp_QC_DATE.Value.AddDays(-dtp_QC_DATE.Value.Day + 1).ToShortDateString() +
                        "','yyyy-mm-dd') and to_date('" + dtp_QC_DATE.Value.AddDays(-dtp_QC_DATE.Value.Day + 1).AddMonths(1).ToShortDateString() +
                        "','yyyy-mm-dd') and KNUCKLE_PROJECTION is not null and ");
                    break;
                case 2:
                    strBld.Append(" QC_DATE Between to_date('" + dtp_QC_DATE.Value.AddDays(-dtp_QC_DATE.Value.Day + 1).ToShortDateString() +
                        "','yyyy-mm-dd') and to_date('" + dtp_QC_DATE.Value.AddDays(-dtp_QC_DATE.Value.Day + 1).AddMonths(1).ToShortDateString() +
                        "','yyyy-mm-dd') and UGI_PROJECTION_CASE is not null and ");
                    break;
                case 3:
                    strBld.Append(" QC_DATE Between to_date('" + dtp_QC_DATE.Value.AddDays(-dtp_QC_DATE.Value.Day + 1).ToShortDateString() +
                        "','yyyy-mm-dd') and to_date('" + dtp_QC_DATE.Value.AddDays(-dtp_QC_DATE.Value.Day + 1).AddMonths(1).ToShortDateString() +
                        "','yyyy-mm-dd') and IVP_FILM_POSTURE_PLACE is not null and ");
                    break;
                default:
                    break;
            }

            DataTable dt =bFilm.GetList(strBld.ToString() + " 1=1");
            DataTable dt1 = bDigitalImage.GetList(strBld.ToString() + " 1=1");

            dtStrenum.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                DataRow NewDr = dtStrenum.NewRow();
                NewDr["EXAM_ACCESSION_NUM"] = dr["EXAM_ACCESSION_NUM"];
                NewDr["PATIENT_LOCAL_ID"] = dr["PATIENT_LOCAL_ID"];
                NewDr["PATIENT_ID"] = dr["PATIENT_ID"];
                NewDr["TYPE"] = "胶片";
                NewDr["PATIENT_NAME"] = dr["PATIENT_NAME"];
                NewDr["PATIENT_SEX"] = dr["PATIENT_SEX"];
                NewDr["STUDY_DATE_TIME"] = dr["STUDY_DATE_TIME"];
                NewDr["QC_DATE"] = dr["QC_DATE"];
                NewDr["TOTAL_SCORE"] = dr["TOTAL_SCORE"];
                NewDr["DISTINCTION"] = dr["DISTINCTION"];
                dtStrenum.Rows.Add(NewDr);
            }
            foreach (DataRow drL in dt1.Rows)
            {
                DataRow NewDrL = dtStrenum.NewRow();
                NewDrL["EXAM_ACCESSION_NUM"] = drL["EXAM_ACCESSION_NUM"];
                NewDrL["PATIENT_LOCAL_ID"] = drL["PATIENT_LOCAL_ID"];
                NewDrL["PATIENT_ID"] = drL["PATIENT_ID"];
                NewDrL["TYPE"] = "数字图像";
                NewDrL["PATIENT_NAME"] = drL["PATIENT_NAME"];
                NewDrL["PATIENT_SEX"] = drL["PATIENT_SEX"];
                NewDrL["STUDY_DATE_TIME"] = drL["STUDY_DATE_TIME"];
                NewDrL["QC_DATE"] = drL["QC_DATE"];
                NewDrL["TOTAL_SCORE"] = drL["TOTAL_SCORE"];
                NewDrL["DISTINCTION"] = drL["DISTINCTION"];
                dtStrenum.Rows.Add(NewDrL);
            }
            dgv_ImageManage.DataSource = dtStrenum;
        }

        private void Find_CT()
        {
            StringBuilder strBld = new StringBuilder();
            strBld.Append(" QC_DATE Between to_date('" + dtp_QC_DATE.Value.AddDays(-dtp_QC_DATE.Value.Day + 1).ToShortDateString() +
                        "','yyyy-mm-dd') and to_date('" + dtp_QC_DATE.Value.AddDays(-dtp_QC_DATE.Value.Day + 1).AddMonths(1).ToShortDateString() +
                        "','yyyy-mm-dd') and ");
            DataTable  dt = bCt.GetList(strBld.ToString() + " 1=1");

            dtStrenum.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                DataRow NewDr = dtStrenum.NewRow();
                NewDr["EXAM_ACCESSION_NUM"] = dr["EXAM_ACCESSION_NUM"];
                NewDr["PATIENT_LOCAL_ID"] = dr["PATIENT_LOCAL_ID"];
                NewDr["PATIENT_ID"] = dr["PATIENT_ID"];
                if (dr["BASE_ASH_FOG_VALUE"].ToString()!="")
                    NewDr["TYPE"] = "胶片";
                else 
                    NewDr["TYPE"] = "数字图像";
                NewDr["PATIENT_NAME"] = dr["PATIENT_NAME"];
                NewDr["PATIENT_SEX"] = dr["PATIENT_SEX"];
                NewDr["STUDY_DATE_TIME"] = dr["STUDY_DATE_TIME"];
                NewDr["QC_DATE"] = dr["QC_DATE"];
                NewDr["TOTAL_SCORE"] = dr["TOTAL_SCORE"];
                NewDr["DISTINCTION"] = dr["DISTINCTION"];
                dtStrenum.Rows.Add(NewDr);
            }

            dgv_ImageManage.DataSource = dtStrenum;
        }

        private void Find_MRI()
        {
            StringBuilder strBld = new StringBuilder();
            strBld.Append(" QC_DATE Between to_date('" + dtp_QC_DATE.Value.AddDays(-dtp_QC_DATE.Value.Day + 1).ToShortDateString() +
                        "','yyyy-mm-dd') and to_date('" + dtp_QC_DATE.Value.AddDays(-dtp_QC_DATE.Value.Day + 1).AddMonths(1).ToShortDateString() +
                        "','yyyy-mm-dd') and ");
            DataTable dt =bMri.GetList(strBld.ToString() + " 1=1");

            dtStrenum.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                DataRow NewDr = dtStrenum.NewRow();
                NewDr["EXAM_ACCESSION_NUM"] = dr["EXAM_ACCESSION_NUM"];
                NewDr["PATIENT_LOCAL_ID"] = dr["PATIENT_LOCAL_ID"];
                NewDr["PATIENT_ID"] = dr["PATIENT_ID"];
                if (dr["BASE_ASH_FOG_VALUE"].ToString() != "")
                    NewDr["TYPE"] = "胶片";
                else
                    NewDr["TYPE"] = "数字图像";
                NewDr["PATIENT_NAME"] = dr["PATIENT_NAME"];
                NewDr["PATIENT_SEX"] = dr["PATIENT_SEX"];
                NewDr["STUDY_DATE_TIME"] = dr["STUDY_DATE_TIME"];
                NewDr["QC_DATE"] = dr["QC_DATE"];
                NewDr["TOTAL_SCORE"] = dr["TOTAL_SCORE"];
                NewDr["DISTINCTION"] = dr["DISTINCTION"];
                dtStrenum.Rows.Add(NewDr);
            }

            dgv_ImageManage.DataSource = dtStrenum;
        }

        private void Find_RY()
        {
            StringBuilder strBld = new StringBuilder();
            strBld.Append(" QC_DATE Between to_date('" + dtp_QC_DATE.Value.AddDays(-dtp_QC_DATE.Value.Day + 1).ToShortDateString() +
                        "','yyyy-mm-dd') and to_date('" + dtp_QC_DATE.Value.AddDays(-dtp_QC_DATE.Value.Day + 1).AddMonths(1).ToShortDateString() +
                        "','yyyy-mm-dd') and ");
            DataTable dt = bRyDiagDict.GetList(strBld.ToString() + " 1=1");

            dtStrenum.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                DataRow NewDr = dtStrenum.NewRow();
                NewDr["EXAM_ACCESSION_NUM"] = dr["EXAM_ACCESSION_NUM"];
                NewDr["PATIENT_LOCAL_ID"] = dr["PATIENT_LOCAL_ID"];
                NewDr["PATIENT_ID"] = dr["PATIENT_ID"];
                NewDr["TYPE"] = "";
                NewDr["PATIENT_NAME"] = dr["PATIENT_NAME"];
                NewDr["PATIENT_SEX"] = dr["PATIENT_SEX"];
                NewDr["STUDY_DATE_TIME"] = dr["STUDY_DATE_TIME"];
                NewDr["QC_DATE"] = dr["QC_DATE"];
                NewDr["TOTAL_SCORE"] = dr["TOTAL_SCORE"];
                NewDr["DISTINCTION"] = dr["DISTINCTION"];
                dtStrenum.Rows.Add(NewDr);
            }

            dgv_ImageManage.DataSource = dtStrenum;
        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            FindData();
        }

        private void btn_Show_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvSelRow = dgv_ImageManage.SelectedRows;
            if (dgvSelRow.Count == 1)
            {
                ArrayList ExamAccessionNum = new ArrayList();

                    MQcInformation mqcInfor = new MQcInformation();
                    mqcInfor.EXAM_ACCESSION_NUM = this.dgv_ImageManage.SelectedRows[0].Cells["EXAM_ACCESSION_NUM"].Value.ToString();
                    mqcInfor.LOCAL_ID = this.dgv_ImageManage.SelectedRows[0].Cells["PATIENT_LOCAL_ID"].Value.ToString();
                    mqcInfor.NAME = this.dgv_ImageManage.SelectedRows[0].Cells["PATIENT_NAME"].Value.ToString();
                    mqcInfor.SEX = this.dgv_ImageManage.SelectedRows[0].Cells["PATIENT_SEX"].Value.ToString();
                    mqcInfor.STUDY_DATE_TIME = this.dgv_ImageManage.SelectedRows[0].Cells["STUDY_DATE_TIME"].Value.ToString();
                    mqcInfor.PATIENT_ID = this.dgv_ImageManage.SelectedRows[0].Cells["PATIENT_ID"].Value.ToString();
                    if (this.dgv_ImageManage.SelectedRows[0].Cells["TYPE"].Value.ToString() == "胶片")
                        mqcInfor.Type = 0;
                    else if (this.dgv_ImageManage.SelectedRows[0].Cells["TYPE"].Value.ToString() == "数字图像")
                        mqcInfor.Type = 1;
                    else
                        mqcInfor.Type = null;
                    ExamAccessionNum.Add(mqcInfor);
                
                ShowFrom(ExamAccessionNum);
            }
        }

        private void btn_ShowTop_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvSelRow = dgv_ImageManage.SelectedRows;
            if (dgvSelRow.Count > 10)
            {
                MessageBoxEx.Show("一次选择的记录不能超过10条!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                ArrayList ExamAccessionNum = new ArrayList();
                for (int i = 0; i < this.dgv_ImageManage.SelectedRows.Count; i++)
                {
                    MQcInformation mqcInfor = new MQcInformation();
                    mqcInfor.EXAM_ACCESSION_NUM = this.dgv_ImageManage.SelectedRows[i].Cells["EXAM_ACCESSION_NUM"].Value.ToString();
                    mqcInfor.LOCAL_ID = this.dgv_ImageManage.SelectedRows[i].Cells["PATIENT_LOCAL_ID"].Value.ToString();
                    mqcInfor.NAME = this.dgv_ImageManage.SelectedRows[i].Cells["PATIENT_NAME"].Value.ToString();
                    mqcInfor.SEX = this.dgv_ImageManage.SelectedRows[i].Cells["PATIENT_SEX"].Value.ToString();
                    mqcInfor.STUDY_DATE_TIME = this.dgv_ImageManage.SelectedRows[i].Cells["STUDY_DATE_TIME"].Value.ToString();
                    mqcInfor.PATIENT_ID = this.dgv_ImageManage.SelectedRows[i].Cells["PATIENT_ID"].Value.ToString();
                    if (cmb_Type.SelectedIndex<6)
                    {
                        if (this.dgv_ImageManage.SelectedRows[i].Cells["TYPE"].Value.ToString() == "胶片")
                            mqcInfor.Type = 0;
                        else if (this.dgv_ImageManage.SelectedRows[i].Cells["TYPE"].Value.ToString() == "数字图像")
                            mqcInfor.Type = 1;
                        else
                            mqcInfor.Type = null;
                    }
                    else
                        mqcInfor.Type = null;
                    ExamAccessionNum.Add(mqcInfor);
                }
                ShowFrom(ExamAccessionNum);
            }
        }

        private void ShowFrom(ArrayList ExamAccessionNum)
        {
            switch (cmb_Type.SelectedIndex)
            {
                case 0:
                    QC_Sternum frm_sternum = new QC_Sternum();
                    bool bl = frm_sternum.InitForm(ExamAccessionNum);
                    if (bl)
                        frm_sternum.ShowDialog();

                    break;
                case 1:
                    QC_Knuckle frm_knuckle = new QC_Knuckle();
                    bl = frm_knuckle.InitForm(ExamAccessionNum);
                    if (bl)
                        frm_knuckle.ShowDialog();

                    break;
                case 2:
                    QC_UGI frm_ugi = new QC_UGI();
                    bl = frm_ugi.InitForm(ExamAccessionNum);
                    if (bl)
                        frm_ugi.ShowDialog();

                    break;
                case 3:
                    QC_IVP frm_ivp = new QC_IVP();
                    bl = frm_ivp.InitForm(ExamAccessionNum);
                    if (bl)
                        frm_ivp.ShowDialog();

                    break;
                case 4:
                    QC_CT frm_ct = new QC_CT();
                    bl = frm_ct.InitForm(ExamAccessionNum);
                    if (bl)
                        frm_ct.ShowDialog();

                    break;
                case 5:
                    QC_MRI frm_mri = new QC_MRI();
                    bl = frm_mri.InitForm(ExamAccessionNum);
                    if (bl)
                        frm_mri.ShowDialog();

                    break;
                case 6:
                    QC_RY_DIAG_DICT frm_rydtagdict = new QC_RY_DIAG_DICT();
                    bl = frm_rydtagdict.InitForm(ExamAccessionNum);
                    if (bl)
                        frm_rydtagdict.ShowDialog();

                    break;
                default:
                    break;
            }
        }

        private void cmb_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Type.SelectedIndex < 6)
                dgv_ImageManage.Columns["TYPE"].Visible = true;
            else
                dgv_ImageManage.Columns["TYPE"].Visible = false;
        }

        private void dgv_ImageManage_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvSelCon = dgv_ImageManage.SelectedRows;

            if (dgvSelCon.Count <= 0)
            {
                MessageBoxEx.Show("请选择需要删除的数据!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dlrs = MessageBoxEx.Show("确认删除选中的记录!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dlrs == DialogResult.No) return;

            Hashtable ht = new Hashtable();

            for (int m = 0; m < dgvSelCon.Count; m++)
            {
                ht.Add(m.ToString(), dgvSelCon[m].Cells["EXAM_ACCESSION_NUM"].Value.ToString());
            }

            int i = 0,j=0;

            switch (cmb_Type.SelectedIndex)
            {
                case 0:
                    i = bFilm.DeleteMore(ht);
                    j = bDigitalImage.DeleteMore(ht);
                    i = i + j;
                    break;
                case 1:
                    i = bFilm.DeleteMore(ht);
                    j = bDigitalImage.DeleteMore(ht);
                    i = i + j;
                    break;
                case 2:
                    i = bFilm.DeleteMore(ht);
                    j = bDigitalImage.DeleteMore(ht);
                    i = i + j;
                    break;
                case 3:
                    i = bFilm.DeleteMore(ht);
                    j = bDigitalImage.DeleteMore(ht);
                    i = i + j;
                    break;
                case 4:
                    i = bCt.DeleteMore(ht);
                    break;
                case 5:
                    i = bMri.DeleteMore(ht);
                    break;
                case 6:
                    i = bRyDiagDict.DeleteMore(ht);
                    break;
            }

            if (i >= 0)
            {
                MessageBoxEx.Show("删除成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FindData();
            }
            else
                MessageBoxEx.Show("删除失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);



        }


    }
}
