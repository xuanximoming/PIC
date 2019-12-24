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
using System.Runtime.InteropServices;
using ILL;
using SIS.Query;

namespace SIS
{
    public partial class frmPacsHistory : BaseControls.Docking.DockContent
    {
        private string TemDir = Application.StartupPath + "\\temp\\";
        private FileOperator fOpe;
        private frmHistoryRpt frmHRpt;
        private SIS_Model.MStudy mStudy;
        private SIS_Model.MReport mReport;
        private string Path = "";
        private ImageCopy imgCopy;
        private BStudy bs;
        private string CacheDir;//临时缓存路径（单击列表时保存）
        private DataChange dc;
        private frmReportEdit.PicBoxClick pbClick;
        public Panel panel;

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll ")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public frmPacsHistory(frmReportEdit.PicBoxClick pbClick)
        {
            InitializeComponent();
            fOpe = new FileOperator();
            this.pbClick = pbClick;
            CacheDir = Application.StartupPath + "\\PacsTemp";
            bs = new BStudy();
            dc = new DataChange();
            this.dgv_Study.AutoGenerateColumns = false;
        }
        /// <summary>
        /// 搜索STUDY表
        /// </summary>
        public void FindStudy()
        {
            string where = "1=1";
            if (this.txt_PatientId.Text.Trim() != "")
                where += " AND PATIENT_ID = '" + this.txt_PatientId.Text.Trim() + "'";
            if (this.txt_PatientLocalId.Text.Trim() != "")
                where += " AND PATIENT_LOCAL_ID = '" + this.txt_PatientLocalId.Text.Trim() + "'";
            if (this.txt_PatientName.Text.Trim() != "")
                where += " AND PATIENT_NAME = '" + this.txt_PatientName.Text.Trim() + "'";
            DataTable dt = bs.GetList2(where);
            this.dgv_Study.DataSource = dt;
            if (this.dgv_Study.Rows.Count == 0)
                this.gb_PromptInfo.Visible = true;
            else
                this.gb_PromptInfo.Visible = false;
            this.l_Count.Text = "共 " + dgv_Study.Rows.Count + " 条记录";
        }
        private void tsb_Find_Click(object sender, EventArgs e)
        {
            this.FindStudy();
        }

        //列表双击
        private void dgv_WorkList_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgv_Study.Rows.Count == 0 || this.dgv_Study.SelectedRows.Count == 0)
                return;
            if (this.mReport == null)
            {
                this.l_RptInfo.Text ="此次检查报告未写或已不存在！";
                this.gb_HistoryRptInfo.Visible = true;
                return;
            }
            if (frmHRpt == null)
                frmHRpt = new frmHistoryRpt();
            if (frmHRpt.OpenRpt(this.mReport, this.mStudy, Path) == -1)
            {
                this.l_RptInfo.Text = "历史报告打开失败，请重新打开！";
                this.gb_HistoryRptInfo.Visible = true;
            }
            else
            {
                this.gb_HistoryRptInfo.Visible = false;
                this.frmHRpt.Show();
            }
        }

        //复制报告
        private void tsb_CopyToRpt_ButtonClick(object sender, EventArgs e)
        {
            if (this.mReport == null)
                return;
            pbClick("1", this.mReport.DESCRIPTION);
            pbClick("2", this.mReport.IMPRESSION);
            pbClick("3", this.mReport.EXAM_PARA);
            pbClick("4", this.mReport.RECOMMENDATION);
        }

        //复制检查参数
        private void tsmi_ExamPara_Click(object sender, EventArgs e)
        {
            if (this.mReport == null)
                return;
            pbClick("3", this.mReport.EXAM_PARA);
        }

        //复制检查所见
        private void tsmi_Description_Click(object sender, EventArgs e)
        {
            if (this.mReport == null)
                return;
            pbClick("1", this.mReport.DESCRIPTION);
        }

        //复制印象(诊断)
        private void tsmi_Impression_Click(object sender, EventArgs e)
        {
            if (this.mReport == null)
                return;
            pbClick("2", this.mReport.IMPRESSION);
        }

        //复制建议
        private void tsmi_Recommendation_Click(object sender, EventArgs e)
        {
            if (this.mReport == null)
                return;
            pbClick("4", this.mReport.RECOMMENDATION);
        }

        private void txt_PatientName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                FindStudy();
        }

        private void txt_PatientId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                FindStudy();
        }

        private void txt_PatientLocalId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                FindStudy();
        }

        private void tsb_OpenImg_Click(object sender, EventArgs e)
        {
            OpenImg();
        }

        //打开图像
        private void OpenImg()
        {
            if (dgv_Study.SelectedRows.Count <= 0)
            {
                MessageBoxEx.Show("请选择需要打开图像的检查记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string uid = dgv_Study.SelectedRows[0].Cells["STUDY_INSTANCE_UID"].Value.ToString();
            if (uid == "")
            {
                MessageBoxEx.Show("图像不存在！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            System.Diagnostics.Process.Start(Application.StartupPath+"\\simpleviewer\\SimpleViewer.exe", "D241,1," + uid);
            IntPtr hwnd = FindWindow(null, "图像工作站");
            if (hwnd.ToInt32() != 0)
            {
                SetForegroundWindow(hwnd);
            }
        }

        private void dgv_Study_Click(object sender, EventArgs e)
        {
            if (dgv_Study.SelectedRows.Count <= 0)
                return;
            string ExamAccessionNum = dgv_Study.SelectedRows[0].Cells["EXAM_ACCESSION_NUM"].Value.ToString().Trim();

            if (!Directory.Exists(TemDir))
                Directory.CreateDirectory(TemDir);
            imgCopy = new ImageCopy();
            this.mStudy = (SIS_Model.MStudy)bs.GetModel(ExamAccessionNum);
            this.mReport = imgCopy.PacsReportDownLoad(this.mStudy, TemDir);
            this.Path = TemDir + "\\" + ExamAccessionNum + ".doc";
            this.gb_HistoryRptInfo.Visible = false;
        }

        private void frmPacsHistory_DockStateChanged(object sender, EventArgs e)
        {
            panel.BringToFront();
        }

        private void dgv_Study_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == this.dgv_Study.Columns["REPORT_STATUS"].Index)
                e = dc.ChangeReportStatus(e);
        }

    }
}