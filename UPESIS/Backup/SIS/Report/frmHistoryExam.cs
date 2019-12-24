using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SIS_Model;
using SIS_BLL;
using System.IO;
using SIS.Query;

namespace SIS
{
    public partial class frmHistoryExam : BaseControls.Docking.DockContent
    {
        private string TemDir = Application.StartupPath + "\\temp\\";
        private string Path = "";
        private FileOperator fOpe;
        private MReport mrpt;
        private frmHistoryRpt frmHRpt;
        private frmReportEdit.PicBoxClick pbClick;
        private DataChange dc;
        public Panel panel;

        public frmHistoryExam(frmReportEdit.PicBoxClick pbClick)
        {
            InitializeComponent();
            fOpe = new FileOperator();
            dc = new DataChange();
            this.pbClick = pbClick;
            this.dgv_WorkList.AutoGenerateColumns = false;
        }
        public void FindWorkList()
        {
            string where = "1=1";
            if (this.txt_PatientId.Text.Trim() != "")
                where += " AND PATIENT_ID = '" + this.txt_PatientId.Text.Trim() + "'";
            if (this.txt_PatientLocalId.Text.Trim() != "")
                where += " AND PATIENT_LOCAL_ID = '" + this.txt_PatientLocalId.Text.Trim() + "'";
            if (this.txt_PatientName.Text.Trim() != "")
                where += " AND PATIENT_NAME = '" + this.txt_PatientName.Text.Trim() + "'";
            BWorkList bw = new BWorkList();
            DataTable dt = bw.GetList2(where);
            this.dgv_WorkList.DataSource = dt;
            if (this.dgv_WorkList.Rows.Count == 0)
                this.gb_PromptInfo.Visible = true;
            else
                this.gb_PromptInfo.Visible = false;
            this.l_Count.Text = "共 " + dgv_WorkList.Rows.Count + " 条记录";
        }
        private void tsb_Find_Click(object sender, EventArgs e)
        {
            this.FindWorkList();
        }

        private void dgv_WorkList_Click(object sender, EventArgs e)
        {
            if (this.dgv_WorkList.Rows.Count == 0 || this.dgv_WorkList.SelectedRows.Count == 0)
                return;
            string ExamAccessionNum = this.dgv_WorkList.CurrentRow.Cells["EXAM_ACCESSION_NUM"].Value.ToString();
            BReport br = new BReport();
            mrpt = (MReport)br.GetModel(ExamAccessionNum);
            Path = TemDir + ExamAccessionNum + ".doc";
            if (!File.Exists(Path))
                fOpe.FileSave(mrpt.REPORT_NAME, Path);
        }

        private void dgv_WorkList_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgv_WorkList.Rows.Count == 0 || this.dgv_WorkList.SelectedRows.Count == 0)
                return;
            if (this.mrpt == null)
            {
                this.l_RptInfo.Text = "此次检查报告未写或已不存在！";
                this.gb_HistoryRptInfo.Visible = true;
                return;
            }
            if (frmHRpt == null)
                frmHRpt = new frmHistoryRpt();
            if (frmHRpt.OpenRpt(this.mrpt, Path) == -1)
            {
                this.l_RptInfo.Text = "历史报告打开失败，请重新打开！";
                this.gb_HistoryRptInfo.Visible = true;
            }
            else
                this.gb_HistoryRptInfo.Visible = false;
        }

        private void tsb_CopyToRpt_ButtonClick(object sender, EventArgs e)
        {
            if (this.mrpt == null)
                return;
            pbClick("1", this.mrpt.DESCRIPTION);
            pbClick("2", this.mrpt.IMPRESSION);
            pbClick("3", this.mrpt.EXAM_PARA);
            pbClick("4", this.mrpt.RECOMMENDATION);
        }

        private void tsmi_ExamPara_Click(object sender, EventArgs e)
        {
            if (this.mrpt == null)
                return;
            pbClick("3", this.mrpt.EXAM_PARA);
        }

        private void tsmi_Description_Click(object sender, EventArgs e)
        {
            if (this.mrpt == null)
                return;
            pbClick("1", this.mrpt.DESCRIPTION);
        }

        private void tsmi_Impression_Click(object sender, EventArgs e)
        {
            if (this.mrpt == null)
                return;
            pbClick("2", this.mrpt.IMPRESSION);
        }

        private void tsmi_Recommendation_Click(object sender, EventArgs e)
        {
            if (this.mrpt == null)
                return;
            pbClick("4", this.mrpt.RECOMMENDATION);
        }

        private void txt_PatientName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                FindWorkList();
        }

        private void txt_PatientId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                FindWorkList();
        }

        private void txt_PatientLocalId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                FindWorkList();
        }

        private void frmHistoryExam_DockStateChanged(object sender, EventArgs e)
        {
            panel.BringToFront();
        }

        private void dgv_WorkList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == this.dgv_WorkList.Columns["REPORT_STATUS"].Index)
                e = dc.ChangeReportStatus(e);
        }

    }
}