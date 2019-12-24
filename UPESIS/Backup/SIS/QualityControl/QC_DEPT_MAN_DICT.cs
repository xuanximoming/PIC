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
    public partial class QC_DEPT_MAN_DICT : Form
    {
        private MQcDeptManDict mMan = new MQcDeptManDict();
        private BQcDeptManDict bMan = new BQcDeptManDict();
        private DataTable dtMan = new DataTable();
        private ReportDocument rptDocument;
        private string path = Application.StartupPath + "\\CrystalReports\\";

        public QC_DEPT_MAN_DICT()
        {
            InitializeComponent();
            rptDocument = new ReportDocument();
        }

        private void FillDataTableFromTable(DataRow dttp)
        {
            DataRow dr = dtMan.NewRow();

            dr["RY_LICENCE"] = dttp["RY_LICENCE"];
            dr["DEDU_GIST_RY_LICENCE"] = dttp["DEDU_GIST_RY_LICENCE"];
            dr["TITLES"] = dttp["TITLES"];
            dr["DEDU_GIST_TITLES"] = dttp["DEDU_GIST_TITLES"];
            dr["POST_TRAIN"] = dttp["POST_TRAIN"];
            dr["DEDU_GIST_POST_TRAIN"] = dttp["DEDU_GIST_POST_TRAIN"];

            dr["CRITERION_INTEGRALITY"] = dttp["CRITERION_INTEGRALITY"];
            dr["DEDU_GIST_CRI_INT"] = dttp["DEDU_GIST_CRI_INT"];
            dr["MANAGEMENT_SYSTEM"] = dttp["MANAGEMENT_SYSTEM"];
            dr["DEDU_GIST_MAN_SYS"] = dttp["DEDU_GIST_MAN_SYS"];
            dr["IMAGE_SYSTEM"] = dttp["IMAGE_SYSTEM"];
            dr["DEDU_GIST_IMAGE_SYS"] = dttp["DEDU_GIST_IMAGE_SYS"];
            dr["PREVENTIVE_MEASURE"] = dttp["PREVENTIVE_MEASURE"];
            dr["DEDU_GIST_PRE_MEA"] = dttp["DEDU_GIST_PRE_MEA"];

            dr["SERVICES_ITEMS"] = dttp["SERVICES_ITEMS"];
            dr["DEDU_GIST_SER_ITEMS"] = dttp["DEDU_GIST_SER_ITEMS"];
            dr["EMERGENCY_EXAM"] = dttp["EMERGENCY_EXAM"];
            dr["DEDU_GIST_EME_EXAM"] = dttp["DEDU_GIST_EME_EXAM"];
            dr["DIAG_REPORT"] = dttp["DIAG_REPORT"];
            dr["DEDU_GIST_DIAG_RPT"] = dttp["DEDU_GIST_DIAG_RPT"];

            dr["MANAGEMENT"] = dttp["MANAGEMENT"];
            dr["DEDU_GIST_MANAGEMENT"] = dttp["DEDU_GIST_MANAGEMENT"];
            dr["REGISTER_STAT"] = dttp["REGISTER_STAT"];
            dr["DEDU_GIST_REG_STAT"] = dttp["DEDU_GIST_REG_STAT"];
            dr["OVERSEE_RESULT"] = dttp["OVERSEE_RESULT"];
            dr["DEDU_GIST_OS_RES"] = dttp["DEDU_GIST_OS_RES"];

            dtMan.Rows.Add(dr);
        }

        private void FillDataTableFromClass(ref DataRow dr)
        {
            dr["RY_LICENCE"] = mMan.RY_LICENCE;
            dr["DEDU_GIST_RY_LICENCE"] = mMan.DEDU_GIST_RY_LICENCE;
            dr["TITLES"] = mMan.TITLES;
            dr["DEDU_GIST_TITLES"] = mMan.DEDU_GIST_TITLES;
            dr["POST_TRAIN"] = mMan.POST_TRAIN;
            dr["DEDU_GIST_POST_TRAIN"] = mMan.DEDU_GIST_POST_TRAIN;

            dr["CRITERION_INTEGRALITY"] = mMan.CRITERION_INTEGRALITY;
            dr["DEDU_GIST_CRI_INT"] = mMan.DEDU_GIST_CRI_INT;
            dr["MANAGEMENT_SYSTEM"] = mMan.MANAGEMENT_SYSTEM;
            dr["DEDU_GIST_MAN_SYS"] = mMan.DEDU_GIST_MAN_SYS;
            dr["IMAGE_SYSTEM"] = mMan.IMAGE_SYSTEM;
            dr["DEDU_GIST_IMAGE_SYS"] = mMan.DEDU_GIST_IMAGE_SYS;
            dr["PREVENTIVE_MEASURE"] = mMan.PREVENTIVE_MEASURE;
            dr["DEDU_GIST_PRE_MEA"] = mMan.DEDU_GIST_PRE_MEA;

            dr["SERVICES_ITEMS"] = mMan.SERVICES_ITEMS;
            dr["DEDU_GIST_SER_ITEMS"] = mMan.DEDU_GIST_SER_ITEMS;
            dr["EMERGENCY_EXAM"] = mMan.EMERGENCY_EXAM;
            dr["DEDU_GIST_EME_EXAM"] = mMan.DEDU_GIST_EME_EXAM;
            dr["DIAG_REPORT"] = mMan.DIAG_REPORT;
            dr["DEDU_GIST_DIAG_RPT"] = mMan.DEDU_GIST_DIAG_RPT;

            dr["MANAGEMENT"] = mMan.MANAGEMENT;
            dr["DEDU_GIST_MANAGEMENT"] = mMan.DEDU_GIST_MANAGEMENT;
            dr["REGISTER_STAT"] = mMan.REGISTER_STAT;
            dr["DEDU_GIST_REG_STAT"] = mMan.DEDU_GIST_REG_STAT;
            dr["OVERSEE_RESULT"] = mMan.OVERSEE_RESULT;
            dr["DEDU_GIST_OS_RES"] = mMan.DEDU_GIST_OS_RES;
        }

        private void FillControl(DataRow dr)
        {
            N_RY_LICENCE.Value = (decimal)dr["RY_LICENCE"];
            txt_DEDU_GIST_RY_LICENCE.Text = dr["DEDU_GIST_RY_LICENCE"].ToString();
            N_TITLES.Value = (decimal)dr["TITLES"];
            txt_DEDU_GIST_TITLES.Text = dr["DEDU_GIST_TITLES"].ToString();
            N_POST_TRAIN.Value = (decimal)dr["POST_TRAIN"];
            txt_DEDU_GIST_POST_TRAIN.Text = dr["DEDU_GIST_POST_TRAIN"].ToString();

            N_CRITERION_INTEGRALITY.Value = (decimal)dr["CRITERION_INTEGRALITY"];
            txt_DEDU_GIST_CRI_INT.Text = dr["DEDU_GIST_CRI_INT"].ToString();
            N_MANAGEMENT_SYSTEM.Value = (decimal)dr["MANAGEMENT_SYSTEM"];
            txt_DEDU_GIST_MAN_SYS.Text = dr["DEDU_GIST_MAN_SYS"].ToString();
            N_IMAGE_SYSTEM.Value = (decimal)dr["IMAGE_SYSTEM"];
            txt_DEDU_GIST_IMAGE_SYS.Text = dr["DEDU_GIST_IMAGE_SYS"].ToString();
            N_PREVENTIVE_MEASURE.Value = (decimal)dr["PREVENTIVE_MEASURE"];
            txt_DEDU_GIST_PRE_MEA.Text = dr["DEDU_GIST_PRE_MEA"].ToString();

            N_SERVICES_ITEMS.Value = (decimal)dr["SERVICES_ITEMS"];
            txt_DEDU_GIST_SER_ITEMS.Text = dr["DEDU_GIST_SER_ITEMS"].ToString();
            N_EMERGENCY_EXAM.Value = (decimal)dr["EMERGENCY_EXAM"];
            txt_DEDU_GIST_EME_EXAM.Text = dr["DEDU_GIST_EME_EXAM"].ToString();
            N_DIAG_REPORT.Value = (decimal)dr["DIAG_REPORT"];
            txt_DEDU_GIST_DIAG_RPT.Text = dr["DEDU_GIST_DIAG_RPT"].ToString();

            N_MANAGEMENT.Value = (decimal)dr["MANAGEMENT"];
            txt_DEDU_GIST_MANAGEMENT.Text = dr["DEDU_GIST_MANAGEMENT"].ToString();
            N_REGISTER_STAT.Value = (decimal)dr["REGISTER_STAT"];
            txt_DEDU_GIST_REG_STAT.Text = dr["DEDU_GIST_REG_STAT"].ToString();
            N_OVERSEE_RESULT.Value = (decimal)dr["OVERSEE_RESULT"];
            txt_DEDU_GIST_OS_RES.Text = dr["DEDU_GIST_OS_RES"].ToString();
        }

        private void QC_DEPT_MAN_DICT_Load(object sender, EventArgs e)
        {
            DT_QCDate.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-01"));
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            MQcDeptManDict mqcMan = new MQcDeptManDict();
            DataRow dr = dtMan.Rows[0];
            mqcMan.QC_DATE = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-01"));
            BGetSeqValue ID = new BGetSeqValue("PACS", "SEQ_DEPT_MAN_KEY");
            mqcMan.DEPT_MAN_KEY = ID.GetSeqValue();

            mqcMan.RY_LICENCE = N_RY_LICENCE.Value;
            if (txt_DEDU_GIST_RY_LICENCE.Text.Trim() != "")
                mqcMan.DEDU_GIST_RY_LICENCE = txt_DEDU_GIST_RY_LICENCE.Text.Trim();
            mqcMan.TITLES = N_TITLES.Value;
            if (txt_DEDU_GIST_TITLES.Text.Trim() != "")
                mqcMan.DEDU_GIST_TITLES = txt_DEDU_GIST_TITLES.Text.Trim();
            mqcMan.POST_TRAIN = N_POST_TRAIN.Value;
            if (txt_DEDU_GIST_POST_TRAIN.Text.Trim() != "")
                mqcMan.DEDU_GIST_POST_TRAIN = txt_DEDU_GIST_POST_TRAIN.Text.Trim();

            mqcMan.CRITERION_INTEGRALITY = N_CRITERION_INTEGRALITY.Value;
            if (txt_DEDU_GIST_CRI_INT.Text.Trim() != "")
                mqcMan.DEDU_GIST_CRI_INT = txt_DEDU_GIST_CRI_INT.Text.Trim();
            mqcMan.MANAGEMENT_SYSTEM = N_MANAGEMENT_SYSTEM.Value;
            if (txt_DEDU_GIST_MAN_SYS.Text.Trim() != "")
                mqcMan.DEDU_GIST_MAN_SYS = txt_DEDU_GIST_MAN_SYS.Text.Trim();
            mqcMan.IMAGE_SYSTEM = N_IMAGE_SYSTEM.Value;
            if (txt_DEDU_GIST_IMAGE_SYS.Text.Trim() != "")
                mqcMan.DEDU_GIST_IMAGE_SYS = txt_DEDU_GIST_IMAGE_SYS.Text.Trim();
            mqcMan.PREVENTIVE_MEASURE = N_PREVENTIVE_MEASURE.Value;
            if (txt_DEDU_GIST_PRE_MEA.Text.Trim() != "")
                mqcMan.DEDU_GIST_PRE_MEA = txt_DEDU_GIST_PRE_MEA.Text.Trim();

            mqcMan.SERVICES_ITEMS = N_SERVICES_ITEMS.Value;
            if (txt_DEDU_GIST_SER_ITEMS.Text.Trim() != "")
                mqcMan.DEDU_GIST_SER_ITEMS = txt_DEDU_GIST_SER_ITEMS.Text.Trim();
            mqcMan.EMERGENCY_EXAM = N_EMERGENCY_EXAM.Value;
            if (txt_DEDU_GIST_EME_EXAM.Text.Trim() != "")
                mqcMan.DEDU_GIST_EME_EXAM = txt_DEDU_GIST_EME_EXAM.Text.Trim();
            mqcMan.DIAG_REPORT = N_DIAG_REPORT.Value;
            if (txt_DEDU_GIST_DIAG_RPT.Text.Trim() != "")
                mqcMan.DEDU_GIST_DIAG_RPT = txt_DEDU_GIST_DIAG_RPT.Text.Trim();

            mqcMan.MANAGEMENT = N_MANAGEMENT.Value;
            if (txt_DEDU_GIST_MANAGEMENT.Text.Trim() != "")
                mqcMan.DEDU_GIST_MANAGEMENT = txt_DEDU_GIST_MANAGEMENT.Text.Trim();
            mqcMan.REGISTER_STAT = N_REGISTER_STAT.Value;
            if (txt_DEDU_GIST_REG_STAT.Text.Trim() != "")
                mqcMan.DEDU_GIST_REG_STAT = txt_DEDU_GIST_REG_STAT.Text.Trim();
            mqcMan.OVERSEE_RESULT = N_OVERSEE_RESULT.Value;
            if (txt_DEDU_GIST_OS_RES.Text.Trim() != "")
                mqcMan.DEDU_GIST_OS_RES = txt_DEDU_GIST_OS_RES.Text.Trim();

            bool bl = bMan.Exists(mqcMan);
            if (bl)
            {
                int i = bMan.Update(mqcMan, " where  QC_DATE = to_date('" + this.DT_QCDate.Value.ToShortDateString() + "','yyyy-mm-dd')");
                if (i > 0)
                    MessageBoxEx.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBoxEx.Show("修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int j = bMan.Add(mqcMan);
                if (j > 0)
                    MessageBoxEx.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBoxEx.Show("添加失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Return_Click(object sender, EventArgs e)
        {
            DataRow dr = dtMan.Rows[0];
            FillDataTableFromClass(ref dr);
            FillControl(dr);
        }

        private void DT_QCDate_ValueChanged(object sender, EventArgs e)
        {
            dtMan = bMan.GetList(" QC_DATE = to_date('" + this.DT_QCDate.Value.ToShortDateString() + "','yyyy-mm-dd')");
            DataRow dr = null;
            if (dtMan.Rows.Count > 0)
            {
                dr = dtMan.Rows[0];
                //FillDataTableFromTable(dr);
            }
            else
            {
                dr = dtMan.NewRow();
                FillDataTableFromClass(ref dr);
                dtMan.Rows.Add(dr);
            }
            FillControl(dr);
        }

        private void btn_PrintView_Click(object sender, EventArgs e)
        {
            if (!this.crv_Sternum.Visible)
            {
                SetReportVisible(true);
                this.SetView();
                btn_PrintView.Text = "退出预览";
            }
            else
            {
                SetReportVisible(false);
                btn_PrintView.Text = "打印预览";
            }
        }

        private void SetReportVisible(bool bl)
        {
            crv_Sternum.Visible = bl;
            myPnl.Visible = !bl;
            myGroupBox1.Visible = !bl;
            myGroupBox2.Visible = !bl;
            myGroupBox3.Visible = !bl;
            myGroupBox4.Visible = !bl;
        }

        private void SetView()
        {
            rptDocument.Load(path + "CR_DEPT_MAN_DICT.rpt");
            decimal Total_Score_All = 0;
            Total_Score_All = N_RY_LICENCE.Value + N_TITLES.Value + N_POST_TRAIN.Value +
                        N_CRITERION_INTEGRALITY.Value + N_MANAGEMENT_SYSTEM.Value + N_IMAGE_SYSTEM.Value + N_PREVENTIVE_MEASURE.Value +
                        N_MANAGEMENT.Value + N_REGISTER_STAT.Value + N_OVERSEE_RESULT.Value;

            DataTable dt = MeregeDataTableData();
            this.rptDocument.SetDataSource(dt);

            SIS_Function.ApiIni AI = new SIS_Function.ApiIni(Application.StartupPath + @"\Settings.ini");
            string Hosiptal_Name = AI.IniReadValue("bcOffice", "HospitalName");
            this.rptDocument.SetParameterValue("Hospital_Name", Hosiptal_Name);

            this.rptDocument.SetParameterValue("Total_Score_All", Total_Score_All);
            this.rptDocument.SetParameterValue("Year", System.DateTime.Now.Year);
            this.rptDocument.SetParameterValue("Month", System.DateTime.Now.Month);
            this.crv_Sternum.ReportSource = this.rptDocument;
            this.crv_Sternum.Controls[0].Controls[0].Controls[0].Text = "上消化道钡餐造影";
        }

        //将胶片表和数据图像表里的记录合并到一张新表中
        private DataTable MeregeDataTableData()
        {
            DataTable dtTpTable = new DataTable();
            dtTpTable.Columns.Add(new DataColumn("DEPT_MAN_KEY", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("QC_DATE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("RY_LICENCE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DEDU_GIST_RY_LICENCE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("TITLES", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DEDU_GIST_TITLES", typeof(string)));

            dtTpTable.Columns.Add(new DataColumn("POST_TRAIN", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DEDU_GIST_POST_TRAIN", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("CRITERION_INTEGRALITY", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DEDU_GIST_CRI_INT", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("MANAGEMENT_SYSTEM", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DEDU_GIST_MAN_SYS", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("IMAGE_SYSTEM", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DEDU_GIST_IMAGE_SYS", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("PREVENTIVE_MEASURE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DEDU_GIST_PRE_MEA", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("SERVICES_ITEMS", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DEDU_GIST_SER_ITEMS", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("EMERGENCY_EXAM", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DEDU_GIST_EME_EXAM", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DIAG_REPORT", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DEDU_GIST_DIAG_RPT", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("MANAGEMENT", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DEDU_GIST_MANAGEMENT", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("REGISTER_STAT", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DEDU_GIST_REG_STAT", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("OVERSEE_RESULT", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DEDU_GIST_OS_RES", typeof(string)));

            DataRow nDr = dtTpTable.NewRow();

            DataRow dr = dtMan.Rows[0];
            //foreach (DataRow dr in dtMan.Rows)
            //{
            nDr["DEPT_MAN_KEY"] = dr["DEPT_MAN_KEY"].ToString();
            nDr["QC_DATE"] = dr["QC_DATE"].ToString();
            nDr["RY_LICENCE"] = dr["RY_LICENCE"].ToString();
            nDr["DEDU_GIST_RY_LICENCE"] = dr["DEDU_GIST_RY_LICENCE"].ToString();
            nDr["TITLES"] = dr["TITLES"].ToString();
            nDr["DEDU_GIST_TITLES"] = dr["DEDU_GIST_TITLES"].ToString();
            nDr["POST_TRAIN"] = dr["POST_TRAIN"].ToString();
            nDr["DEDU_GIST_POST_TRAIN"] = dr["DEDU_GIST_POST_TRAIN"].ToString();
            nDr["CRITERION_INTEGRALITY"] = dr["CRITERION_INTEGRALITY"].ToString();
            nDr["DEDU_GIST_CRI_INT"] = dr["DEDU_GIST_CRI_INT"].ToString();
            nDr["MANAGEMENT_SYSTEM"] = dr["MANAGEMENT_SYSTEM"].ToString();
            nDr["DEDU_GIST_MAN_SYS"] = dr["DEDU_GIST_MAN_SYS"].ToString();
            nDr["IMAGE_SYSTEM"] = dr["IMAGE_SYSTEM"].ToString();
            nDr["DEDU_GIST_IMAGE_SYS"] = dr["DEDU_GIST_IMAGE_SYS"].ToString();
            nDr["PREVENTIVE_MEASURE"] = dr["PREVENTIVE_MEASURE"].ToString();
            nDr["DEDU_GIST_PRE_MEA"] = dr["DEDU_GIST_PRE_MEA"].ToString();
            nDr["SERVICES_ITEMS"] = dr["SERVICES_ITEMS"].ToString();
            nDr["DEDU_GIST_SER_ITEMS"] = dr["DEDU_GIST_SER_ITEMS"].ToString();
            nDr["EMERGENCY_EXAM"] = dr["EMERGENCY_EXAM"].ToString();
            nDr["DEDU_GIST_EME_EXAM"] = dr["DEDU_GIST_EME_EXAM"].ToString();
            nDr["DIAG_REPORT"] = dr["DIAG_REPORT"].ToString();
            nDr["DEDU_GIST_DIAG_RPT"] = dr["DEDU_GIST_DIAG_RPT"].ToString();
            nDr["MANAGEMENT"] = dr["MANAGEMENT"].ToString();
            nDr["DEDU_GIST_MANAGEMENT"] = dr["DEDU_GIST_MANAGEMENT"].ToString();
            nDr["REGISTER_STAT"] = dr["REGISTER_STAT"].ToString();
            nDr["DEDU_GIST_REG_STAT"] = dr["DEDU_GIST_REG_STAT"].ToString();
            nDr["OVERSEE_RESULT"] = dr["OVERSEE_RESULT"].ToString();
            nDr["DEDU_GIST_OS_RES"] = dr["DEDU_GIST_OS_RES"].ToString();
            //}
            dtTpTable.Rows.Add(nDr);
            return dtTpTable;
        }

        #region 控件值改变
        private void N_RY_LICENCE_ValueChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["RY_LICENCE"] = N_RY_LICENCE.Value;
        }

        private void txt_DEDU_GIST_RY_LICENCE_TextChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["DEDU_GIST_RY_LICENCE"] = txt_DEDU_GIST_RY_LICENCE.Text.Trim();
        }

        private void N_TITLES_ValueChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["TITLES"] = N_TITLES.Value;
        }

        private void txt_DEDU_GIST_TITLES_TextChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["DEDU_GIST_TITLES"] = txt_DEDU_GIST_TITLES.Text.Trim();
        }

        private void N_POST_TRAIN_ValueChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["POST_TRAIN"] = N_POST_TRAIN.Value;
        }

        private void txt_DEDU_GIST_POST_TRAIN_TextChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["DEDU_GIST_POST_TRAIN"] = txt_DEDU_GIST_POST_TRAIN.Text.Trim();
        }

        private void N_CRITERION_INTEGRALITY_ValueChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["CRITERION_INTEGRALITY"] = N_CRITERION_INTEGRALITY.Value;
        }

        private void txt_DEDU_GIST_CRI_INT_TextChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["DEDU_GIST_CRI_INT"] = txt_DEDU_GIST_CRI_INT.Text.Trim();
        }

        private void N_MANAGEMENT_SYSTEM_ValueChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["MANAGEMENT_SYSTEM"] = N_MANAGEMENT_SYSTEM.Value;
        }

        private void txt_DEDU_GIST_MAN_SYS_TextChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["DEDU_GIST_MAN_SYS"] = txt_DEDU_GIST_MAN_SYS.Text.Trim();
        }

        private void N_IMAGE_SYSTEM_ValueChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["IMAGE_SYSTEM"] = N_IMAGE_SYSTEM.Value;
        }

        private void txt_DEDU_GIST_IMAGE_SYS_TextChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["DEDU_GIST_IMAGE_SYS"] = txt_DEDU_GIST_IMAGE_SYS.Text.Trim();
        }

        private void N_PREVENTIVE_MEASURE_ValueChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["PREVENTIVE_MEASURE"] = N_PREVENTIVE_MEASURE.Value;
        }

        private void txt_DEDU_GIST_PRE_MEA_TextChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["DEDU_GIST_PRE_MEA"] = txt_DEDU_GIST_PRE_MEA.Text.Trim();
        }

        private void N_SERVICES_ITEMS_ValueChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["SERVICES_ITEMS"] = N_SERVICES_ITEMS.Value;
        }

        private void txt_DEDU_GIST_SER_ITEMS_TextChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["DEDU_GIST_SER_ITEMS"] = txt_DEDU_GIST_SER_ITEMS.Text.Trim();
        }

        private void N_EMERGENCY_EXAM_ValueChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["EMERGENCY_EXAM"] = N_EMERGENCY_EXAM.Value;
        }

        private void txt_DEDU_GIST_EME_EXAM_TextChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["DEDU_GIST_EME_EXAM"] = txt_DEDU_GIST_EME_EXAM.Text.Trim();
        }

        private void N_DIAG_REPORT_ValueChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["DIAG_REPORT"] = N_DIAG_REPORT.Value;
        }

        private void txt_DEDU_GIST_DIAG_RPT_TextChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["DEDU_GIST_DIAG_RPT"] = txt_DEDU_GIST_DIAG_RPT.Text.Trim();
        }

        private void N_MANAGEMENT_ValueChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["MANAGEMENT"] = N_MANAGEMENT.Value;
        }

        private void txt_DEDU_GIST_MANAGEMENT_TextChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["DEDU_GIST_MANAGEMENT"] = txt_DEDU_GIST_MANAGEMENT.Text.Trim();
        }

        private void N_REGISTER_STAT_ValueChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["REGISTER_STAT"] = N_REGISTER_STAT.Value;
        }

        private void txt_DEDU_GIST_REG_STAT_TextChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["DEDU_GIST_REG_STAT"] = txt_DEDU_GIST_REG_STAT.Text.Trim();
        }

        private void N_OVERSEE_RESULT_ValueChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["OVERSEE_RESULT"] = N_OVERSEE_RESULT.Value;
        }

        private void txt_DEDU_GIST_OS_RES_TextChanged(object sender, EventArgs e)
        {
            dtMan.Rows[0]["DEDU_GIST_OS_RES"] = txt_DEDU_GIST_OS_RES.Text.Trim();
        }
        #endregion

        private void btn_Out_Click(object sender, EventArgs e)
        {
            if (!this.crv_Sternum.Visible)
            {
                this.SetView();
            }
            this.crv_Sternum.ExportReport();
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            if (!this.crv_Sternum.Visible)
            {
                this.SetView();
            }
            this.crv_Sternum.PrintReport();
        }



    }
}