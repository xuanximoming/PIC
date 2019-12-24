using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SIS_BLL;
using SIS_Model;

namespace SIS
{
    public partial class frmPacsReport : Form
    {
        private FileOperator FileOp = new FileOperator();
        private SIS_Model.MReport mReport = null;
        private SIS_Model.MStudy mStudy;
        private WordClass word;
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public void Closefrm()
        {
            this.wwc_Report.QuitWord();
        }

        public frmPacsReport()
        {
            InitializeComponent();
            word = new WordClass(this.wwc_Report);
        }

        public void InitForm(MReport mReport,MStudy mStudy,string Path)
        {
            this.mStudy = mStudy;
            this.mReport = mReport;
            DisplayWord(Path);
            FillData();
            this.Text = "申请序号：" + mStudy.EXAM_ACCESSION_NUM;
        }

        private bool DisplayWord(string Path)
        {
            if (word.PacsWordInit(this.mReport,this.mStudy, Path) == -1)
            {
                MessageBoxEx.Show("打开报告失败，请重新打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Visible = false;
                return false;
            }
            else
            {
                this.Visible = true;
                return true;
            }
        }

        private void FillData()
        {
            this.txt_BedNum.Text = this.mStudy.BED_NUM;
            this.txt_ExamClass.Text = this.mStudy.EXAM_CLASS;
            this.txt_ExamItem.Text = this.mStudy.EXAM_ITEM;
            this.txt_ExamSubClass.Text = this.mStudy.EXAM_SUB_CLASS;
            this.txt_InpNo.Text = this.mStudy.INP_NO;
            this.txt_PatientAge.Text = this.mStudy.PATIENT_AGE.ToString() + " " + this.mStudy.PATIENT_AGE_UNIT.ToString();
            this.txt_PatientID.Text = this.mStudy.PATIENT_ID;
            this.txt_PatientName.Text = this.mStudy.PATIENT_NAME;
            this.txt_PatientSex.Text = this.mStudy.PATIENT_SEX;
            this.txt_PatientSource.Text = this.mStudy.PATIENT_SOURCE;
            this.txt_StudyDateTime.Text = this.mStudy.STUDY_DATE_TIME.ToString();

            this.txt_ReportDateTime.Text = this.mReport.REPORT_DATE_TIME.ToString();
            this.txt_Transcriber.Text = this.mReport.TRANSCRIBER;
            this.txt_ApproveDateTime.Text = this.mReport.APPROVE_DATE_TIME.ToString();
            this.txt_Approver.Text = this.mReport.APPROVER;
            if (this.mReport.IS_ABNORMAL == 0)
                this.rb_NoAbnormal.Checked = true;
            if (this.mReport.IS_ABNORMAL == 1)
                this.rb_Abnormal.Checked = true;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

    }
}