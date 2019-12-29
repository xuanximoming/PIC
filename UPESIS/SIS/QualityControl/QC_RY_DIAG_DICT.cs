using CrystalDecisions.CrystalReports.Engine;
using PACS_Model;
using SIS_BLL;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace SIS.QualityControl
{
    public partial class QC_RY_DIAG_DICT : Form
    {
        private BQcRyDiagDict bqrdDct = new BQcRyDiagDict();
        private MQcRyDiagDict mqrdDct = new MQcRyDiagDict();
        private ReportDocument rptDocument;
        private DataTable dtrdDct = new DataTable();
        private int NowRow = -1;        //返回操作的行
        private bool isModify = true;  //如果由查询界面进入此窗体,则点保存时为修改否则为新增;默认为修改
        private string path = Application.StartupPath + "\\CrystalReports\\";

        public QC_RY_DIAG_DICT()
        {
            InitializeComponent();

            dtrdDct = bqrdDct.GetList("EXAM_ACCESSION_NUM=''");
            dtrdDct.PrimaryKey = new System.Data.DataColumn[] { dtrdDct.Columns["EXAM_ACCESSION_NUM"] };
            rptDocument = new ReportDocument();
        }
        public bool InitForm(ArrayList ExamAccessionNum)
        {
            if (ExamAccessionNum.Count == 0) return false;

            lv_Sternum.Items.Clear();
            for (int i = 0; i < ExamAccessionNum.Count; i++)
            {
                MQcInformation mqcInfor = (MQcInformation)ExamAccessionNum[i];
                ListViewItem lvItem = new ListViewItem(mqcInfor.LOCAL_ID);
                lvItem.SubItems.Add(mqcInfor.NAME);
                lvItem.SubItems.Add(mqcInfor.SEX);
                lvItem.SubItems.Add(mqcInfor.STUDY_DATE_TIME);
                ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem();
                subItem.Name = "EXAM_ACCESSION_NUM";
                subItem.Text = mqcInfor.EXAM_ACCESSION_NUM;
                lvItem.SubItems.Add(subItem);
                ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem();
                subItem1.Name = "PATIENT_ID";
                subItem1.Text = mqcInfor.PATIENT_ID;
                lvItem.SubItems.Add(subItem1);
                lv_Sternum.Items.Add(lvItem);

                DataTable dt = bqrdDct.GetList("EXAM_ACCESSION_NUM='" + mqcInfor.EXAM_ACCESSION_NUM + "'");
                if (dt.Rows.Count > 0)
                {
                    FillDataTableFromTable(dt.Rows[0]);
                }
                else
                {
                    isModify = false;
                    DataRow dr = dtrdDct.NewRow();
                    FillDataTableFromClass(ref  dr, mqcInfor);
                    dtrdDct.Rows.Add(dr);
                }
            }
            return true;
        }

        private void FillDataTableFromTable(DataRow dttp)
        {
            DataRow dr = dtrdDct.NewRow();
            dr["EXAM_ACCESSION_NUM"] = dttp["EXAM_ACCESSION_NUM"];
            dr["PATIENT_ID"] = dttp["PATIENT_ID"];
            dr["PATIENT_LOCAL_ID"] = dttp["PATIENT_LOCAL_ID"];
            dr["PATIENT_NAME"] = dttp["PATIENT_NAME"];
            dr["PATIENT_SEX"] = dttp["PATIENT_SEX"];
            dr["STUDY_DATE_TIME"] = dttp["STUDY_DATE_TIME"];

            dr["DRPT_NAME"] = dttp["DRPT_NAME"];
            dr["DRPT_SEX"] = dttp["DRPT_SEX"];
            dr["DRPT_AGE"] = dttp["DRPT_AGE"];
            dr["DRPT_NUMBER"] = dttp["DRPT_NUMBER"];
            dr["DRPT_LOCAL_ID"] = dttp["DRPT_LOCAL_ID"];
            dr["DRPT_FILM_DATE"] = dttp["DRPT_FILM_DATE"];
            dr["DRPT_RPT_DATE"] = dttp["DRPT_RPT_DATE"];
            dr["DRPT_APP_DATE"] = dttp["DRPT_APP_DATE"];
            dr["DRPT_CLIN_DIAG"] = dttp["DRPT_CLIN_DIAG"];
            dr["DRPT_EXAM_ITEM"] = dttp["DRPT_EXAM_ITEM"];
            dr["DRPT_EXAM_TEC"] = dttp["DRPT_EXAM_TEC"];
            dr["DRPT_DESCRIPTION"] = dttp["DRPT_DESCRIPTION"];
            dr["DRPT_IMPRESSION"] = dttp["DRPT_IMPRESSION"];
            dr["DRPT_TRANSCRIBER"] = dttp["DRPT_TRANSCRIBER"];
            dr["DRPT_APPROVER"] = dttp["DRPT_APPROVER"];
            dr["INQ_NAME"] = dttp["INQ_NAME"];
            dr["INQ_SEX"] = dttp["INQ_SEX"];
            dr["INQ_AGE"] = dttp["INQ_AGE"];
            dr["INQ_NUMBER"] = dttp["INQ_NUMBER"];
            dr["INQ_LOCAL_ID"] = dttp["INQ_LOCAL_ID"];
            dr["INQ_PATH_NO"] = dttp["INQ_PATH_NO"];
            dr["INQ_OPE_DATE"] = dttp["INQ_OPE_DATE"];
            dr["INQ_EXAM_ITEM_DIAG"] = dttp["INQ_EXAM_ITEM_DIAG"];
            dr["INQ_OPERATION"] = dttp["INQ_OPERATION"];
            dr["INQ_PATH_DESCRIPTION"] = dttp["INQ_PATH_DESCRIPTION"];
            dr["INQ_PATH_DOCTOR"] = dttp["INQ_PATH_DOCTOR"];
            dr["INQ_DOCTOR"] = dttp["INQ_DOCTOR"];

            dr["PITCH"] = dttp["PITCH"];
            dr["TOTAL_SCORE"] = dttp["TOTAL_SCORE"];
            dr["QUALITATIVE"] = dttp["QUALITATIVE"];
            dr["DISTINCTION"] = dttp["DISTINCTION"];
            dtrdDct.Rows.Add(dr);
        }

        private void FillDataTableFromClass(ref DataRow dr, MQcInformation minfor)
        {
            dr["EXAM_ACCESSION_NUM"] = minfor.EXAM_ACCESSION_NUM;
            dr["PATIENT_ID"] = minfor.PATIENT_ID;
            dr["PATIENT_LOCAL_ID"] = minfor.LOCAL_ID;
            dr["PATIENT_NAME"] = minfor.NAME;
            dr["PATIENT_SEX"] = minfor.SEX;
            dr["STUDY_DATE_TIME"] = minfor.STUDY_DATE_TIME;

            dr["DRPT_NAME"] = (decimal)mqrdDct.DRPT_NAME;
            dr["DRPT_SEX"] = (decimal)mqrdDct.DRPT_SEX;
            dr["DRPT_AGE"] = (decimal)mqrdDct.DRPT_AGE;
            dr["DRPT_NUMBER"] = (decimal)mqrdDct.DRPT_NUMBER;
            dr["DRPT_LOCAL_ID"] = (decimal)mqrdDct.DRPT_LOCAL_ID;
            dr["DRPT_FILM_DATE"] = (decimal)mqrdDct.DRPT_FILM_DATE;
            dr["DRPT_RPT_DATE"] = (decimal)mqrdDct.DRPT_RPT_DATE;
            dr["DRPT_APP_DATE"] = (decimal)mqrdDct.DRPT_APP_DATE;
            dr["DRPT_CLIN_DIAG"] = (decimal)mqrdDct.DRPT_CLIN_DIAG;
            dr["DRPT_EXAM_ITEM"] = (decimal)mqrdDct.DRPT_EXAM_ITEM;
            dr["DRPT_EXAM_TEC"] = (decimal)mqrdDct.DRPT_EXAM_TEC;
            dr["DRPT_DESCRIPTION"] = (decimal)mqrdDct.DRPT_DESCRIPTION;
            dr["DRPT_IMPRESSION"] = (decimal)mqrdDct.DRPT_IMPRESSION;
            dr["DRPT_TRANSCRIBER"] = (decimal)mqrdDct.DRPT_TRANSCRIBER;
            dr["DRPT_APPROVER"] = (decimal)mqrdDct.DRPT_APPROVER;
            dr["INQ_NAME"] = (decimal)mqrdDct.INQ_NAME;
            dr["INQ_SEX"] = (decimal)mqrdDct.INQ_SEX;
            dr["INQ_AGE"] = (decimal)mqrdDct.INQ_AGE;
            dr["INQ_NUMBER"] = (decimal)mqrdDct.INQ_NUMBER;
            dr["INQ_LOCAL_ID"] = (decimal)mqrdDct.INQ_LOCAL_ID;
            dr["INQ_PATH_NO"] = (decimal)mqrdDct.INQ_PATH_NO;
            dr["INQ_OPE_DATE"] = (decimal)mqrdDct.INQ_OPE_DATE;
            dr["INQ_EXAM_ITEM_DIAG"] = (decimal)mqrdDct.INQ_EXAM_ITEM_DIAG;
            dr["INQ_OPERATION"] = (decimal)mqrdDct.INQ_OPERATION;
            dr["INQ_PATH_DESCRIPTION"] = (decimal)mqrdDct.INQ_PATH_DESCRIPTION;
            dr["INQ_PATH_DOCTOR"] = (decimal)mqrdDct.INQ_PATH_DOCTOR;
            dr["INQ_DOCTOR"] = (decimal)mqrdDct.INQ_DOCTOR;

            dr["PITCH"] = (decimal)mqrdDct.PITCH;
            dr["TOTAL_SCORE"] = mqrdDct.TOTAL_SCORE.ToString();
            dr["QUALITATIVE"] = (decimal)mqrdDct.QUALITATIVE;
            dr["DISTINCTION"] = Convert.ToInt32(mqrdDct.DISTINCTION);
        }

        private void FillDefalutData(int lvSelectIndex)
        {
            txt_PATIENT_LOCAL_ID.Text = lv_Sternum.Items[lvSelectIndex].Text;
            txt_PATIENT_NAME.Text = lv_Sternum.Items[lvSelectIndex].SubItems[1].Text;
            txt_PATIENT_SEX.Text = lv_Sternum.Items[lvSelectIndex].SubItems[2].Text;
            txt_STUDY_DATE_TIME.Text = lv_Sternum.Items[lvSelectIndex].SubItems[3].Text;

            DataRow nDr = dtrdDct.Rows.Find(lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems["EXAM_ACCESSION_NUM"].Text);
            NowRow = dtrdDct.Rows.IndexOf(nDr);

            N_DRPT_NAME.Value = (decimal)nDr["DRPT_NAME"];
            N_DRPT_SEX.Value = (decimal)nDr["DRPT_SEX"];
            N_DRPT_AGE.Value = (decimal)nDr["DRPT_AGE"];
            N_DRPT_NUMBER.Value = (decimal)nDr["DRPT_NUMBER"];
            N_DRPT_LOCAL_ID.Value = (decimal)nDr["DRPT_LOCAL_ID"];
            N_DRPT_FILM_DATE.Value = (decimal)nDr["DRPT_FILM_DATE"];
            N_DRPT_RPT_DATE.Value = (decimal)nDr["DRPT_RPT_DATE"];
            N_DRPT_APP_DATE.Value = (decimal)nDr["DRPT_APP_DATE"];
            N_DRPT_CLIN_DIAG.Value = (decimal)nDr["DRPT_CLIN_DIAG"];
            N_DRPT_EXAM_ITEM.Value = (decimal)nDr["DRPT_EXAM_ITEM"];
            N_DRPT_EXAM_TEC.Value = (decimal)nDr["DRPT_EXAM_TEC"];
            N_DRPT_DESCRIPTION.Value = (decimal)nDr["DRPT_DESCRIPTION"];
            N_DRPT_IMPRESSION.Value = (decimal)nDr["DRPT_IMPRESSION"];
            N_DRPT_TRANSCRIBER.Value = (decimal)nDr["DRPT_TRANSCRIBER"];
            N_DRPT_APPROVER.Value = (decimal)nDr["DRPT_APPROVER"];
            N_INQ_NAME.Value = (decimal)nDr["INQ_NAME"];
            N_INQ_SEX.Value = (decimal)nDr["INQ_SEX"];
            N_INQ_AGE.Value = (decimal)nDr["INQ_AGE"];
            N_INQ_NUMBER.Value = (decimal)nDr["INQ_NUMBER"];
            N_INQ_LOCAL_ID.Value = (decimal)nDr["INQ_LOCAL_ID"];
            N_INQ_PATH_NO.Value = (decimal)nDr["INQ_PATH_NO"];
            N_INQ_OPE_DATE.Value = (decimal)nDr["INQ_OPE_DATE"];
            N_INQ_EXAM_ITEM_DIAG.Value = (decimal)nDr["INQ_EXAM_ITEM_DIAG"];
            N_INQ_OPERATION.Value = (decimal)nDr["INQ_OPERATION"];
            N_INQ_PATH_DESCRIPTION.Value = (decimal)nDr["INQ_PATH_DESCRIPTION"];
            N_INQ_PATH_DOCTOR.Value = (decimal)nDr["INQ_PATH_DOCTOR"];
            N_INQ_DOCTOR.Value = (decimal)nDr["INQ_DOCTOR"];

            N_PITCH.Value = (decimal)nDr["PITCH"];
            txt_TOTAL_SCORE.Text = nDr["TOTAL_SCORE"].ToString();
            N_QUALITATIVE.Value = (decimal)nDr["QUALITATIVE"];
            N_DISTINCTION.SelectedIndex = Convert.ToInt32(nDr["DISTINCTION"]) - 1;
        }

        private void QC_RY_DIAG_DICT_Load(object sender, EventArgs e)
        {
            this.btn_FunName.Text = this.Text;
            lv_Sternum.Focus();
            lv_Sternum.TopItem.Selected = true;
            lv_Sternum.TopItem.Focused = true;

            lv_Sternum_Click(null, null);
        }

        private void btn_Return_Click(object sender, EventArgs e)
        {
            MQcInformation minf = new MQcInformation();
            minf.LOCAL_ID = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].Text;
            minf.NAME = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems[1].Text;
            minf.SEX = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems[2].Text;
            minf.STUDY_DATE_TIME = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems[3].Text;
            minf.EXAM_ACCESSION_NUM = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems["EXAM_ACCESSION_NUM"].Text;
            minf.PATIENT_ID = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems["PATIENT_ID"].Text;

            DataRow dr = dtrdDct.Rows.Find(lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems["EXAM_ACCESSION_NUM"].Text);
            FillDataTableFromClass(ref dr, minf);

            FillDefalutData(lv_Sternum.SelectedItems[0].Index);
        }

        private void lv_Sternum_Click(object sender, EventArgs e)
        {
            txt_PATIENT_LOCAL_ID.Text = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].Text;
            txt_PATIENT_NAME.Text = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems[1].Text;
            txt_PATIENT_SEX.Text = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems[2].Text;
            txt_STUDY_DATE_TIME.Text = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems[3].Text;

            FillDefalutData(lv_Sternum.SelectedItems[0].Index);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            for (int i = 0; i < dtrdDct.Rows.Count; i++)
            {
                if (dtrdDct.Rows[i]["EXAM_ACCESSION_NUM"].ToString() == "" || dtrdDct.Rows[i]["PATIENT_LOCAL_ID"].ToString() == "") continue;

                MQcRyDiagDict mf = new MQcRyDiagDict();

                mf.EXAM_ACCESSION_NUM = dtrdDct.Rows[i]["EXAM_ACCESSION_NUM"].ToString();
                mf.PATIENT_ID = dtrdDct.Rows[i]["PATIENT_ID"].ToString();
                mf.PATIENT_LOCAL_ID = dtrdDct.Rows[i]["PATIENT_LOCAL_ID"].ToString();
                mf.PATIENT_NAME = dtrdDct.Rows[i]["PATIENT_NAME"].ToString();
                mf.PATIENT_SEX = dtrdDct.Rows[i]["PATIENT_SEX"].ToString();
                mf.STUDY_DATE_TIME = Convert.ToDateTime(dtrdDct.Rows[i]["STUDY_DATE_TIME"]);
                mf.QC_DATE = DateTime.Now;

                mf.DRPT_NAME = (decimal)dtrdDct.Rows[i]["DRPT_NAME"];
                mf.DRPT_SEX = (decimal)dtrdDct.Rows[i]["DRPT_SEX"];
                mf.DRPT_AGE = (decimal)dtrdDct.Rows[i]["DRPT_AGE"];
                mf.DRPT_NUMBER = (decimal)dtrdDct.Rows[i]["DRPT_NUMBER"];
                mf.DRPT_LOCAL_ID = (decimal)dtrdDct.Rows[i]["DRPT_LOCAL_ID"];
                mf.DRPT_FILM_DATE = (decimal)dtrdDct.Rows[i]["DRPT_FILM_DATE"];
                mf.DRPT_RPT_DATE = (decimal)dtrdDct.Rows[i]["DRPT_RPT_DATE"];
                mf.DRPT_APP_DATE = (decimal)dtrdDct.Rows[i]["DRPT_APP_DATE"];
                mf.DRPT_CLIN_DIAG = (decimal)dtrdDct.Rows[i]["DRPT_CLIN_DIAG"];
                mf.DRPT_EXAM_ITEM = (decimal)dtrdDct.Rows[i]["DRPT_EXAM_ITEM"];
                mf.DRPT_EXAM_TEC = (decimal)dtrdDct.Rows[i]["DRPT_EXAM_TEC"];
                mf.DRPT_DESCRIPTION = (decimal)dtrdDct.Rows[i]["DRPT_DESCRIPTION"];
                mf.DRPT_IMPRESSION = (decimal)dtrdDct.Rows[i]["DRPT_IMPRESSION"];
                mf.DRPT_TRANSCRIBER = (decimal)dtrdDct.Rows[i]["DRPT_TRANSCRIBER"];
                mf.DRPT_APPROVER = (decimal)dtrdDct.Rows[i]["DRPT_APPROVER"];
                mf.INQ_NAME = (decimal)dtrdDct.Rows[i]["INQ_NAME"];
                mf.INQ_SEX = (decimal)dtrdDct.Rows[i]["INQ_SEX"];
                mf.INQ_AGE = (decimal)dtrdDct.Rows[i]["INQ_AGE"];
                mf.INQ_NUMBER = (decimal)dtrdDct.Rows[i]["INQ_NUMBER"];
                mf.INQ_LOCAL_ID = (decimal)dtrdDct.Rows[i]["INQ_LOCAL_ID"];
                mf.INQ_PATH_NO = (decimal)dtrdDct.Rows[i]["INQ_PATH_NO"];
                mf.INQ_OPE_DATE = (decimal)dtrdDct.Rows[i]["INQ_OPE_DATE"];
                mf.INQ_EXAM_ITEM_DIAG = (decimal)dtrdDct.Rows[i]["INQ_EXAM_ITEM_DIAG"];
                mf.INQ_OPERATION = (decimal)dtrdDct.Rows[i]["INQ_OPERATION"];
                mf.INQ_PATH_DESCRIPTION = (decimal)dtrdDct.Rows[i]["INQ_PATH_DESCRIPTION"];
                mf.INQ_PATH_DOCTOR = (decimal)dtrdDct.Rows[i]["INQ_PATH_DOCTOR"];
                mf.INQ_DOCTOR = (decimal)dtrdDct.Rows[i]["INQ_DOCTOR"];

                mf.PITCH = (decimal)dtrdDct.Rows[i]["PITCH"];
                mf.TOTAL_SCORE = Convert.ToDecimal(dtrdDct.Rows[i]["TOTAL_SCORE"]);
                mf.QUALITATIVE = (decimal)dtrdDct.Rows[i]["QUALITATIVE"];
                mf.DISTINCTION = Convert.ToInt32(dtrdDct.Rows[i]["DISTINCTION"]);

                ht.Add(i, mf);
            }

            int j = 0;
            if (isModify)
            {
                j = bqrdDct.UpdateMore(ht);
                if (j >= 0)
                    MessageBoxEx.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBoxEx.Show("修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                j = bqrdDct.AddMore(ht);
                if (j >= 0)
                {
                    MessageBoxEx.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isModify = true;
                }
                else
                    MessageBoxEx.Show("添加失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region 控件值改变
        private void N_DRPT_NAME_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["DRPT_NAME"] = N_DRPT_NAME.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_DRPT_SEX_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["DRPT_SEX"] = N_DRPT_SEX.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_DRPT_AGE_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["DRPT_AGE"] = N_DRPT_AGE.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_DRPT_NUMBER_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["DRPT_NUMBER"] = N_DRPT_NUMBER.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_DRPT_LOCAL_ID_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["DRPT_LOCAL_ID"] = N_DRPT_LOCAL_ID.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_DRPT_FILM_DATE_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["DRPT_FILM_DATE"] = N_DRPT_FILM_DATE.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_DRPT_RPT_DATE_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["DRPT_RPT_DATE"] = N_DRPT_RPT_DATE.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_DRPT_APP_DATE_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["DRPT_APP_DATE"] = N_DRPT_APP_DATE.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_DRPT_CLIN_DIAG_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["DRPT_CLIN_DIAG"] = N_DRPT_CLIN_DIAG.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_DRPT_EXAM_ITEM_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["DRPT_EXAM_ITEM"] = N_DRPT_EXAM_ITEM.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_DRPT_EXAM_TEC_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["DRPT_EXAM_TEC"] = N_DRPT_EXAM_TEC.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_DRPT_DESCRIPTION_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["DRPT_DESCRIPTION"] = N_DRPT_DESCRIPTION.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_DRPT_IMPRESSION_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["DRPT_IMPRESSION"] = N_DRPT_IMPRESSION.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_DRPT_TRANSCRIBER_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["DRPT_TRANSCRIBER"] = N_DRPT_TRANSCRIBER.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_DRPT_APPROVER_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["DRPT_APPROVER"] = N_DRPT_APPROVER.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_INQ_NAME_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["INQ_NAME"] = N_INQ_NAME.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_INQ_SEX_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["INQ_SEX"] = N_INQ_SEX.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_INQ_AGE_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["INQ_AGE"] = N_INQ_AGE.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_INQ_NUMBER_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["INQ_NUMBER"] = N_INQ_NUMBER.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_INQ_LOCAL_ID_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["INQ_LOCAL_ID"] = N_INQ_LOCAL_ID.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_INQ_PATH_NO_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["INQ_PATH_NO"] = N_INQ_PATH_NO.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_INQ_OPE_DATE_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["INQ_OPE_DATE"] = N_INQ_OPE_DATE.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_INQ_EXAM_ITEM_DIAG_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["INQ_EXAM_ITEM_DIAG"] = N_INQ_EXAM_ITEM_DIAG.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_INQ_OPERATION_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["INQ_OPERATION"] = N_INQ_OPERATION.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_INQ_PATH_DESCRIPTION_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["INQ_PATH_DESCRIPTION"] = N_INQ_PATH_DESCRIPTION.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_INQ_PATH_DOCTOR_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["INQ_PATH_DOCTOR"] = N_INQ_PATH_DOCTOR.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_INQ_DOCTOR_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["INQ_DOCTOR"] = N_INQ_DOCTOR.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_PITCH_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["PITCH"] = N_PITCH.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_QUALITATIVE_ValueChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["QUALITATIVE"] = N_QUALITATIVE.Value;
            decimal dcl = N_DRPT_NAME.Value + N_DRPT_SEX.Value + N_DRPT_AGE.Value + N_DRPT_NUMBER.Value + N_DRPT_LOCAL_ID.Value + N_DRPT_FILM_DATE.Value + N_DRPT_RPT_DATE.Value + N_DRPT_APP_DATE.Value + N_DRPT_CLIN_DIAG.Value +
                    N_DRPT_EXAM_ITEM.Value + N_DRPT_EXAM_TEC.Value + N_DRPT_DESCRIPTION.Value + N_DRPT_IMPRESSION.Value + N_DRPT_TRANSCRIBER.Value + N_DRPT_APPROVER.Value +
                    N_INQ_NAME.Value + N_INQ_SEX.Value + N_INQ_AGE.Value + N_INQ_NUMBER.Value + N_INQ_LOCAL_ID.Value + N_INQ_PATH_NO.Value + N_INQ_OPE_DATE.Value +
                    N_INQ_EXAM_ITEM_DIAG.Value + N_INQ_OPERATION.Value + N_INQ_PATH_DESCRIPTION.Value + N_INQ_PATH_DOCTOR.Value + N_INQ_DOCTOR.Value +
                    N_PITCH.Value + N_QUALITATIVE.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        #endregion

        private void N_DISTINCTION_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["DISTINCTION"] = N_DISTINCTION.SelectedIndex + 1;
        }

        private void txt_TOTAL_SCORE_TextChanged(object sender, EventArgs e)
        {
            dtrdDct.Rows[NowRow]["TOTAL_SCORE"] = Convert.ToDecimal(txt_TOTAL_SCORE.Text);
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
            panel1.Visible = !bl;
            gb_Film.Visible = !bl;
            gb_DI.Visible = !bl;
            myPanel1.Visible = !bl;
        }

        private void SetView()
        {
            rptDocument.Load(path + "CR_RY_DIAG_DICT.rpt");
            int DISTINCTION_1 = 0, DISTINCTION_2 = 0, DISTINCTION_3 = 0;
            decimal Total_Score_All = 0;

            DataTable dtSernum = MeregeDataTableData(ref DISTINCTION_1, ref DISTINCTION_2, ref DISTINCTION_3, ref Total_Score_All);
            this.rptDocument.SetDataSource(dtSernum);

            SIS_Function.ApiIni AI = new SIS_Function.ApiIni(Application.StartupPath + @"\Settings.ini");
            string Hosiptal_Name = AI.IniReadValue("bcOffice", "HospitalName");
            //this.rptDocument.SetParameterValue("Hospital_Name", Hosiptal_Name);
            //this.rptDocument.SetParameterValue("DISTINCTION_1", DISTINCTION_1);
            // this.rptDocument.SetParameterValue("DISTINCTION_2", DISTINCTION_2);
            // this.rptDocument.SetParameterValue("DISTINCTION_3", DISTINCTION_3);
            // this.rptDocument.SetParameterValue("Total_Score_All", Total_Score_All);
            // this.rptDocument.SetParameterValue("Year", System.DateTime.Now.Year);
            //this.rptDocument.SetParameterValue("Month", System.DateTime.Now.Month);
            this.crv_Sternum.ReportSource = this.rptDocument;
            this.crv_Sternum.Controls[0].Controls[0].Controls[0].Text = "放射诊断";
        }

        private DataTable MeregeDataTableData(ref int DISTINCTION_1, ref int DISTINCTION_2, ref int DISTINCTION_3, ref decimal Total_Score_All)
        {
            DataTable dtTpTable = new DataTable();
            dtTpTable.Columns.Add(new DataColumn("EXAM_ACCESSION_NUM", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("PATIENT_LOCAL_ID", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("QC_DATE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("PATIENT_ID", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("PATIENT_NAME", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("PATIENT_SEX", typeof(string)));

            dtTpTable.Columns.Add(new DataColumn("STUDY_DATE_TIME", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DRPT_NAME", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DRPT_SEX", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DRPT_AGE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DRPT_NUMBER", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DRPT_LOCAL_ID", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DRPT_FILM_DATE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DRPT_APP_DATE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DRPT_CLIN_DIAG", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DRPT_EXAM_ITEM", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DRPT_EXAM_TEC", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DRPT_DESCRIPTION", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DRPT_IMPRESSION", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DRPT_TRANSCRIBER", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DRPT_APPROVER", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("INQ_NAME", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("INQ_SEX", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("INQ_AGE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("INQ_NUMBER", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("INQ_LOCAL_ID", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("INQ_PATH_NO", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("INQ_OPE_DATE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("INQ_EXAM_ITEM_DIAG", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("INQ_OPERATION", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("INQ_PATH_DESCRIPTION", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("INQ_PATH_DOCTOR", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("INQ_DOCTOR", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("QUALITATIVE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("PITCH", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("XR_POSITIVE_RATE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("CT_POSITIVE_RATE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("MR_POSITIVE_RATE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("TOTAL_SCORE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DISTINCTION", typeof(string)));
            //dtTpTable.Columns.Add(new DataColumn("NUMBER_KEY", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DRPT_RPT_DATE", typeof(string)));

            DataRow nDr = dtTpTable.NewRow();

            foreach (DataRow dr in dtrdDct.Rows)
            {
                if (dr["PATIENT_NAME"].ToString().Length == 4)
                    nDr["PATIENT_NAME"] += dr["PATIENT_NAME"].ToString().PadRight(3, ' ');
                else if (dr["PATIENT_NAME"].ToString().Length == 2)
                    nDr["PATIENT_NAME"] += dr["PATIENT_NAME"].ToString().PadRight(6, ' ');
                else
                    nDr["PATIENT_NAME"] += dr["PATIENT_NAME"].ToString().PadRight(4, ' ');

                nDr["DRPT_NAME"] += dr["DRPT_NAME"].ToString().PadRight(6, ' ');
                nDr["DRPT_SEX"] += dr["DRPT_SEX"].ToString().PadRight(6, ' ');
                nDr["DRPT_AGE"] += dr["DRPT_AGE"].ToString().PadRight(6, ' ');
                nDr["DRPT_NUMBER"] += dr["DRPT_NUMBER"].ToString().PadRight(6, ' ');
                nDr["DRPT_LOCAL_ID"] += dr["DRPT_LOCAL_ID"].ToString().PadRight(6, ' ');
                nDr["DRPT_FILM_DATE"] += dr["DRPT_FILM_DATE"].ToString().PadRight(6, ' ');
                nDr["DRPT_APP_DATE"] += dr["DRPT_APP_DATE"].ToString().PadRight(6, ' ');
                nDr["DRPT_CLIN_DIAG"] += dr["DRPT_CLIN_DIAG"].ToString().PadRight(6, ' ');
                nDr["DRPT_EXAM_ITEM"] += dr["DRPT_EXAM_ITEM"].ToString().PadRight(6, ' ');
                nDr["DRPT_EXAM_TEC"] += dr["DRPT_EXAM_TEC"].ToString().PadRight(6, ' ');
                nDr["DRPT_DESCRIPTION"] += dr["DRPT_DESCRIPTION"].ToString().PadRight(6, ' ');
                nDr["DRPT_IMPRESSION"] += dr["DRPT_IMPRESSION"].ToString().PadRight(6, ' ');
                nDr["DRPT_TRANSCRIBER"] += dr["DRPT_TRANSCRIBER"].ToString().PadRight(6, ' ');
                nDr["DRPT_APPROVER"] += dr["DRPT_APPROVER"].ToString().PadRight(6, ' ');
                nDr["INQ_NAME"] += dr["INQ_NAME"].ToString().PadRight(6, ' ');
                nDr["INQ_SEX"] += dr["INQ_SEX"].ToString().PadRight(6, ' ');
                nDr["INQ_AGE"] += dr["INQ_AGE"].ToString().PadRight(6, ' ');
                nDr["INQ_NUMBER"] += dr["INQ_NUMBER"].ToString().PadRight(6, ' ');
                nDr["INQ_LOCAL_ID"] += dr["INQ_LOCAL_ID"].ToString().PadRight(6, ' ');
                nDr["INQ_PATH_NO"] += dr["INQ_PATH_NO"].ToString().PadRight(6, ' ');
                nDr["INQ_OPE_DATE"] += dr["INQ_OPE_DATE"].ToString().PadRight(6, ' ');
                nDr["INQ_EXAM_ITEM_DIAG"] += dr["INQ_EXAM_ITEM_DIAG"].ToString().PadRight(6, ' ');
                nDr["INQ_OPERATION"] += dr["INQ_OPERATION"].ToString().PadRight(6, ' ');
                nDr["INQ_PATH_DESCRIPTION"] += dr["INQ_PATH_DESCRIPTION"].ToString().PadRight(6, ' ');
                nDr["INQ_PATH_DOCTOR"] += dr["INQ_PATH_DOCTOR"].ToString().PadRight(6, ' ');
                nDr["INQ_DOCTOR"] += dr["INQ_DOCTOR"].ToString().PadRight(6, ' ');
                nDr["QUALITATIVE"] += dr["QUALITATIVE"].ToString().PadRight(6, ' ');
                nDr["PITCH"] += dr["PITCH"].ToString().PadRight(6, ' ');
                nDr["XR_POSITIVE_RATE"] += dr["XR_POSITIVE_RATE"].ToString().PadRight(6, ' ');
                nDr["CT_POSITIVE_RATE"] += dr["CT_POSITIVE_RATE"].ToString().PadRight(6, ' ');
                nDr["MR_POSITIVE_RATE"] += dr["MR_POSITIVE_RATE"].ToString().PadRight(6, ' ');

                nDr["TOTAL_SCORE"] += dr["TOTAL_SCORE"].ToString().PadRight(6, ' ');
                nDr["DISTINCTION"] += dr["DISTINCTION"].ToString().PadRight(6, ' ');
                nDr["DRPT_RPT_DATE"] += dr["DRPT_RPT_DATE"].ToString().PadRight(6, ' ');

                Total_Score_All += Convert.ToDecimal(dr["TOTAL_SCORE"]);
                if (dr["DISTINCTION"].ToString() == "1")
                    DISTINCTION_1 += 1;
                else if (dr["DISTINCTION"].ToString() == "2")
                    DISTINCTION_2 += 1;
                else if (dr["DISTINCTION"].ToString() == "3")
                    DISTINCTION_3 += 1;
            }

            dtTpTable.Rows.Add(nDr);
            return dtTpTable;
        }

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