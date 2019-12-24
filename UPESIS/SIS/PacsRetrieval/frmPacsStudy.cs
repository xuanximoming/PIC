using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SIS_BLL;
using ILL;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace SIS
{
    public partial class frmPacsStudy : Form
    {
        private BStudy bStudy = new BStudy();
        private SIS.RegisterCls.BindData bindData;
        private bool isInit = true;
        private string CacheDir = Application.StartupPath + "\\PacsTemp";//临时缓存路径（单击列表时保存）
        private ImageCopy imgCopy;
        private SIS_Model.MStudy mStudy;
        private SIS_Model.MReport mReport;
        private frmPacsReport PacsRpt;
        private string Path = "";

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll ")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public frmPacsStudy()
        {
            InitializeComponent();
        }

        //没有收费状态字段
        private void tsb_Find_Click(object sender, EventArgs e)
        {
            FindStudy();
        }

        private void FindStudy()
        {
            StringBuilder bldSql = new StringBuilder();

            if (txt_ExamAccessionNum.Text != "")
                bldSql.Append(" and a.exam_accession_num='" + txt_ExamAccessionNum.Text.Trim().ToUpper() + "'");//Add at 2010-09-14
            if (txt_PatientID.Text != "")
                bldSql.Append(" and a.patient_id='" + txt_PatientID.Text.Trim() + "'");
            if (txt_Name.Text != "")
                bldSql.Append(" and a.patient_name like '%" + txt_Name.Text.Trim() + "%'");
            if (txt_PatientLocalId.Text != "")
                bldSql.Append(" and a.study_id='" + txt_PatientLocalId.Text.Trim() + "'"); //Edit at 2010-09-01 study表的检查号
            if (txt_InpNo.Text != "")
                bldSql.Append(" and a.inp_no='" + txt_InpNo.Text.Trim() + "'");
            if (cmb_ChargeType.SelectedValue != null)
                bldSql.Append(" and a.CHARGE_TYPE ='" + cmb_ChargeType.SelectedValue.ToString() + "'");

            if (cmb_IsOnline.Text == "在线")
                bldSql.Append(" and a.IS_ONLINE ='1'");
            else if (cmb_IsOnline.Text == "离线")
                bldSql.Append(" and a.IS_ONLINE ='0'");
            
            if (cmb_ExamClass.Text != "")
                bldSql.Append(" and a.EXAM_CLASS ='" + cmb_ExamClass.Text.Trim() + "'");
            if (cmb_ExamItem.Text != "")
                bldSql.Append(" and a.EXAM_ITEM like '%" + cmb_ExamItem.Text + "%'");   //Edit at 2010-11-18
            if (cmb_ExamSubClass.Text != "")
                bldSql.Append(" and a.EXAM_SUB_CLASs = '" + cmb_ExamSubClass.Text + "'");
            if (cmb_PatientSource.Text != "")
                bldSql.Append(" and a.PATIENT_SOURCE = '" + cmb_PatientSource.Text.Trim() + "'"); //Edit at 2010-09-01
            if (cmb_ReferDept.Text != "")
                bldSql.Append(" and a.REQ_DEPT_NAME = '" + cmb_ReferDept.Text + "'");
            if (cmb_ReferDoctor.Text != "")
                bldSql.Append(" and a.REFER_DOCTOR ='" + cmb_ReferDoctor.Text + "'");
            if (cmb_ReportType.Text != "")
                bldSql.Append(" and b.REPORT_TYPE ='" + (cmb_ReportType.SelectedIndex - 1).ToString() + "'");

            if (txt_ExamDoctor.Text != "")
                bldSql.Append(" and a.exam_doctor='" + txt_ExamDoctor.Text.Trim() + "'");    //Add at 2010-09-14
            if (txt_ExamGroup.Text != "")
                bldSql.Append(" and a.exam_group='" + txt_ExamGroup.Text.Trim() + "'");    //Add at 2010-09-14
            if (txt_DiagImpression.Text != "")
                bldSql.Append("and b.impression like '%" + txt_DiagImpression.Text.Trim() + "%'"); //Add at 2010-09-14

            if (this.dtp_From.Checked || this.dtp_To.Checked)
            {
                string DateFrom = "", DateTo = "";
                if (this.dtp_From.Checked)
                    DateFrom = this.dtp_From.Text;
                else
                    DateFrom = this.dtp_From.MinDate.ToShortDateString();
                if (this.dtp_To.Checked)
                    DateTo = this.dtp_To.Value.AddDays(1).ToShortDateString();
                else
                    DateTo = System.DateTime.Now.AddMonths(1).ToShortDateString();
                bldSql.Append(DateTimeSql(DateFrom, DateTo));
            }
            DataTable dt = bStudy.GetList1("1=1 " + bldSql.ToString() + " order by a.STUDY_DATE_TIME DESC ");
            dgv_Study.DataSource = dt;
        }

        private string DateTimeSql(string DateFrom, string DateTo)
        {
            string sql = "";
            switch (GetConfig.SisOdbcMode)
            {
                case "ACCESS":
                    switch (cmb_DateType.SelectedIndex)
                    {
                        case 0:
                            sql += " and REQ_DATE_TIME between #" + DateFrom + "# and #" + DateTo + "#";
                            break;
                        case 1:
                            sql += " and STUDY_DATE_TIME between #" + DateFrom + "# and #" + DateTo + "#";
                            break;
                        case 2:
                            sql += " and REPORT_DATE_TIME between #" + DateFrom + "# and #" + DateTo + "#";
                            break;
                        default:
                            break;
                    }
                    break;
                case "ORACLE":
                    switch (cmb_DateType.SelectedIndex)
                    {
                        case 0:
                            sql += " and REQ_DATE_TIME >= to_date('" + DateFrom + "','yyyy-mm-dd HH24:MI:SS') and REQ_DATE_TIME <= to_date('" + DateTo + "','yyyy-mm-dd HH24:MI:SS')";
                            break;
                        case 1:
                            sql += " and STUDY_DATE_TIME >= to_date('" + DateFrom + "','yyyy-mm-dd HH24:MI:SS') and REQ_DATE_TIME <= to_date('" + DateTo + "','yyyy-mm-dd HH24:MI:SS')";
                            break;
                        case 2:
                            sql += " and REPORT_DATE_TIME >= to_date('" + DateFrom + "','yyyy-mm-dd HH24:MI:SS') and REQ_DATE_TIME <= to_date('" + DateTo + "','yyyy-mm-dd HH24:MI:SS')";
                            break;
                        default:
                            break;
                    }
                    break;
            }
            return sql;
        }

        private void frmPacsStudy_Load(object sender, EventArgs e)
        {
            this.isInit = true;
            this.bindData = new SIS.RegisterCls.BindData();
            this.bindData.BindChargeType(this.cmb_ChargeType);
            this.bindData.BindExamClass(this.cmb_ExamClass, 2);
            this.bindData.BindPatientSource(this.cmb_PatientSource);
            this.bindData.BindReferDept(this.cmb_ReferDept);
            this.cmb_ChargeType.SelectedIndex = -1;
            this.cmb_ExamClass.SelectedIndex = -1;
            this.cmb_PatientSource.SelectedValue = -1;
            this.cmb_ReferDept.SelectedIndex = -1;
            this.cmb_DateType.SelectedIndex = 1;
            this.txt_ExamAccessionNum.Focus();
            this.isInit = false;
            this.dgv_Study.XmlFile = Application.StartupPath + "\\STUDY.xml";
            this.dgv_Study.AddViewColumns();
            this.dgv_Study.AutoGenerateColumns = false;
            FindStudy();
        }

        private void cmb_ExamClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            this.bindData.BindExamSubClass(this.cmb_ExamClass.Text, this.cmb_ExamSubClass);
            this.cmb_ExamSubClass.SelectedIndex = -1;
        }

        private void cmb_ExamSubClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            this.bindData.BindExamItems(this.cmb_ExamClass.Text, this.cmb_ExamSubClass.Text, this.cmb_ExamItem);
            this.cmb_ExamItem.SelectedIndex = -1;
        }

        private void cmb_ReferDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.isInit)
                return;
            string referDept = this.cmb_ReferDept.SelectedValue == null ? "" : this.cmb_ReferDept.SelectedValue.ToString();
            this.bindData.BindReferDoctor(referDept, this.cmb_ReferDoctor);
            this.cmb_ReferDoctor.SelectedIndex = -1;
        }

        private void tsb_Clear_Click(object sender, EventArgs e)
        {
            this.txt_ExamAccessionNum.Text = "";
            this.txt_InpNo.Text = "";
            this.txt_Name.Text = "";
            this.txt_PatientID.Text = "";
            this.txt_PatientLocalId.Text = "";
            this.txt_ExamDoctor.Text = "";
            this.txt_ExamGroup.Text = "";
            this.txt_DiagImpression.Text = "";
            this.cmb_ChargeType.SelectedIndex = -1;
            this.cmb_ExamClass.SelectedIndex = -1;
            this.cmb_PatientSource.SelectedValue = -1;
            this.cmb_ReferDept.SelectedIndex = -1;
            this.cmb_DateType.SelectedIndex = 1;
            this.cmb_ExamItem.DataSource = null;
            this.cmb_ExamSubClass.DataSource = null;
            this.cmb_ReferDoctor.DataSource = null;
            this.cmb_IsOnline.SelectedIndex = -1;
            this.cmb_ReportType.SelectedIndex = -1;
            this.txt_ExamAccessionNum.Focus();
        }

        private void tsb_OpenRpt_Click(object sender, EventArgs e)
        {
            if (dgv_Study.SelectedRows.Count <= 0)
            {
                MessageBoxEx.Show("请选择需要打开报告的用户记录!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.OpenReport();
        }

        private void dgv_Study_Click(object sender, EventArgs e)
        {
            if (dgv_Study.SelectedRows.Count <= 0)
                return;
            string ExamAccessionNum = dgv_Study.SelectedRows[0].Cells["EXAM_ACCESSION_NUM"].Value.ToString().Trim();
            if (!Directory.Exists(CacheDir))
                Directory.CreateDirectory(CacheDir);
            imgCopy = new ImageCopy();
            this.mStudy = (SIS_Model.MStudy)bStudy.GetModel(ExamAccessionNum);
            this.mReport = imgCopy.PacsReportDownLoad(this.mStudy, CacheDir);
            this.Path = CacheDir + "\\" + ExamAccessionNum + ".doc";
            this.txt_Description.Text = "检查所见：" + Environment.NewLine + dgv_Study.SelectedRows[0].Cells["DESCRIPTION"].Value.ToString();
            this.txt_Impression.Text = "诊断意见：" + Environment.NewLine + dgv_Study.SelectedRows[0].Cells["IMPRESSION"].Value.ToString();
        }

        public void OpenReport()
        {
            if (this.mReport == null)
            {
                MessageBoxEx.Show("此次检查报告未写或不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.PacsRpt == null)
                PacsRpt = new frmPacsReport();
            PacsRpt.InitForm(this.mReport,this.mStudy, Path);
        }

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
            IntPtr hwnd = FindWindow(null,"图像工作站");
            if (hwnd.ToInt32() != 0)
            {
                SetForegroundWindow(hwnd);
            }
        }

        private void tsb_OpenImg_Click(object sender, EventArgs e)
        {
            OpenImg();
        }

        private void dgv_Study_DoubleClick(object sender, EventArgs e)
        {
            OpenImg();
        }

        private void frmPacsStudy_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.PacsRpt != null)
                this.PacsRpt.Closefrm();
            //获得进程对象，以用来操作   
            System.Diagnostics.Process myproc = new System.Diagnostics.Process();
            //得到所有打开的进程    
            try
            {
                //获得需要杀死的进程名   
                foreach (System.Diagnostics.Process thisproc in System.Diagnostics.Process.GetProcesses())
                {
                    if (thisproc.ProcessName == "SimpleViewer"||thisproc.ProcessName=="DicomGateway")
                        thisproc.Kill();
                }
            }
            catch (Exception Exc)
            {
                throw new Exception("", Exc);
            }
            if (Directory.Exists(CacheDir))
                Directory.Delete(CacheDir, true);
            Directory.CreateDirectory(CacheDir);
        }

        private void tsmi_ChangeList_Click(object sender, EventArgs e)
        {
            frmSetDataView sdv = new frmSetDataView(this.dgv_Study.GetViewColumns(), this.dgv_Study.XmlFile);
            sdv.ShowDialog();
        }

        //Add at 2010-09-01
        #region 回车检索
        private void txt_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                tsb_Find_Click(null, null);
        }

        private void txt_PatientID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                tsb_Find_Click(null, null);
        }

        private void txt_PatientLocalId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                tsb_Find_Click(null, null);
        }

        private void txt_InpNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                tsb_Find_Click(null, null);
        }

        private void txt_ExamAccessionNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                tsb_Find_Click(null, null);
        }

        private void txt_ExamDoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                tsb_Find_Click(null, null);
        }

        private void txt_ExamGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                tsb_Find_Click(null, null);
        }

        private void txt_DiagImpression_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                tsb_Find_Click(null, null);
        }
        #endregion
    }
}