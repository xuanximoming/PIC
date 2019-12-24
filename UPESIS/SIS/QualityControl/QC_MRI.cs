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
    public partial class QC_MRI : Form
    {
        private BQcMri bqMri = new BQcMri();
        private MQcMri mqMri = new MQcMri();
        private ReportDocument rptDocument;
        private DataTable dtMRI = new DataTable();
        private int NowRow = -1;        //返回操作的行
        private int FirstTopType = -1;  //返回第一行记录的类型　
        private bool isModify = true;  //如果由查询界面进入此窗体,则点保存时为修改否则为新增;默认为修改
        private string path = Application.StartupPath + "\\CrystalReports\\";

        public QC_MRI()
        {
            InitializeComponent();

            dtMRI = bqMri.GetList("EXAM_ACCESSION_NUM=''");
            dtMRI.PrimaryKey = new System.Data.DataColumn[] { dtMRI.Columns["EXAM_ACCESSION_NUM"] };
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

                if (mqcInfor.Type.ToString() == "0")
                {
                    DataTable dt = bqMri.GetList("EXAM_ACCESSION_NUM='" + mqcInfor.EXAM_ACCESSION_NUM + "'");
                    if (dt.Rows.Count > 0)
                    {
                        if (i == 0 && FirstTopType == -1)
                            FirstTopType = 0;

                        FillDataTableFromTable(dt.Rows[0], 0);
                    }
                }
                else if (mqcInfor.Type.ToString() == "1")
                {
                    DataTable dt = bqMri.GetList("EXAM_ACCESSION_NUM='" + mqcInfor.EXAM_ACCESSION_NUM + "'");
                    if (dt.Rows.Count > 0)
                    {
                        if (i == 0 && FirstTopType == -1)
                            FirstTopType = 1;

                        FillDataTableFromTable(dt.Rows[0], 1);
                    }
                }
                else
                {
                    isModify = false;
                    SIS_Function.ApiIni AI = new SIS_Function.ApiIni(Application.StartupPath + @"\Settings.ini");
                    string temp = AI.IniReadValue("FilmOrDI", "MRI_FilmOrDI");

                    if (i == 0 && FirstTopType == -1)
                        FirstTopType = int.Parse(temp);

                    DataRow dr = dtMRI.NewRow();
                    FillDataTableFromClass(ref  dr, mqcInfor, int.Parse(temp));
                    dtMRI.Rows.Add(dr);
                }
            }
            return true;
        }

        private void FillDataTableFromTable(DataRow dttp, int flag)
        {
            DataRow dr = dtMRI.NewRow();
            dr["EXAM_ACCESSION_NUM"] = dttp["EXAM_ACCESSION_NUM"];
            dr["PATIENT_ID"] = dttp["PATIENT_ID"];
            dr["PATIENT_LOCAL_ID"] = dttp["PATIENT_LOCAL_ID"];
            dr["PATIENT_NAME"] = dttp["PATIENT_NAME"];
            dr["PATIENT_SEX"] = dttp["PATIENT_SEX"];
            dr["STUDY_DATE_TIME"] = dttp["STUDY_DATE_TIME"];

            if (flag == 0)
            {
                dr["POSTURE_CHOICE"] = dttp["POSTURE_CHOICE"];
                dr["SCANNING_SCOPE"] = dttp["SCANNING_SCOPE"];
                dr["VISCERA_SCANNING"] = dttp["VISCERA_SCANNING"];
                dr["BASE_ASH_FOG_VALUE"] = dttp["BASE_ASH_FOG_VALUE"];
                dr["BRIM_BACKGROUND_DENSITY"] = dttp["BRIM_BACKGROUND_DENSITY"];
                dr["RESOLUTION"] = dttp["RESOLUTION"];
                dr["INF_CRITERION"] = dttp["INF_CRITERION"];
                dr["SCANNING_MODE"] = dttp["SCANNING_MODE"];
                dr["SERIES_LEVEL_NUMBER"] = dttp["SERIES_LEVEL_NUMBER"];
                dr["FILM_FORMAT"] = dttp["FILM_FORMAT"];
                dr["OPE_RESULT"] = dttp["OPE_RESULT"];

                dr["STRUCTURE_RESOLUTION"] = DBNull.Value;      //判断是否为胶片或是数字图像标志列需要删除
                dr["HIST_CONTRAST"] = DBNull.Value;
                dr["FAST_CONSULT"] = DBNull.Value;
                dr["DEVICE_SHADOW"] = DBNull.Value;
            }
            else
            {
                dr["POSTURE_CHOICE"] = dttp["POSTURE_CHOICE"];
                dr["SCANNING_SCOPE"] = dttp["SCANNING_SCOPE"];
                dr["VISCERA_SCANNING"] = dttp["VISCERA_SCANNING"];
                dr["STRUCTURE_RESOLUTION"] = dttp["STRUCTURE_RESOLUTION"];
                dr["HIST_CONTRAST"] = dttp["HIST_CONTRAST"];
                dr["RESOLUTION"] = dttp["RESOLUTION"];
                dr["INF_CRITERION"] = dttp["INF_CRITERION"];
                dr["SCANNING_MODE"] = dttp["SCANNING_MODE"];
                dr["SERIES_LEVEL_NUMBER"] = dttp["SERIES_LEVEL_NUMBER"];
                dr["FAST_CONSULT"] = dttp["FAST_CONSULT"];
                dr["DEVICE_SHADOW"] = dttp["DEVICE_SHADOW"];

                dr["BASE_ASH_FOG_VALUE"] = DBNull.Value;  //判断是否为胶片或是数字图像标志列需要删除
                dr["BRIM_BACKGROUND_DENSITY"] = DBNull.Value;
                dr["FILM_FORMAT"] = DBNull.Value;
                dr["OPE_RESULT"] = DBNull.Value;
            }
            dr["EXTERNA_METAL_SHADOW"] = dttp["EXTERNA_METAL_SHADOW"];
            dr["TOTAL_SCORE"] = dttp["TOTAL_SCORE"];
            dr["DISTINCTION"] = dttp["DISTINCTION"];
            dtMRI.Rows.Add(dr);
        }

        private void FillDataTableFromClass(ref DataRow dr, MQcInformation minfor, int flag)
        {
            dr["EXAM_ACCESSION_NUM"] = minfor.EXAM_ACCESSION_NUM;
            dr["PATIENT_ID"] = minfor.PATIENT_ID;
            dr["PATIENT_LOCAL_ID"] = minfor.LOCAL_ID;
            dr["PATIENT_NAME"] = minfor.NAME;
            dr["PATIENT_SEX"] = minfor.SEX;
            dr["STUDY_DATE_TIME"] = minfor.STUDY_DATE_TIME;

            if (flag == 0)
            {
                dr["POSTURE_CHOICE"] = (decimal)mqMri.POSTURE_CHOICE;
                dr["SCANNING_SCOPE"] = (decimal)mqMri.SCANNING_SCOPE;
                dr["VISCERA_SCANNING"] = (decimal)mqMri.VISCERA_SCANNING;
                dr["BASE_ASH_FOG_VALUE"] = (decimal)mqMri.BASE_ASH_FOG_VALUE;
                dr["BRIM_BACKGROUND_DENSITY"] = (decimal)mqMri.BRIM_BACKGROUND_DENSITY;
                dr["RESOLUTION"] = (decimal)mqMri.RESOLUTION;
                dr["INF_CRITERION"] = (decimal)mqMri.INF_CRITERION;
                dr["SCANNING_MODE"] = (decimal)mqMri.SCANNING_MODE;
                dr["SERIES_LEVEL_NUMBER"] = (decimal)mqMri.SERIES_LEVEL_NUMBER;
                dr["FILM_FORMAT"] = (decimal)mqMri.FILM_FORMAT;
                dr["OPE_RESULT"] = (decimal)mqMri.OPE_RESULT;

                dr["STRUCTURE_RESOLUTION"] = DBNull.Value;      //判断是否为胶片或是数字图像标志列需要删除
                dr["HIST_CONTRAST"] = DBNull.Value;
                dr["FAST_CONSULT"] = DBNull.Value;
                dr["DEVICE_SHADOW"] = DBNull.Value;
            }
            else
            {
                dr["POSTURE_CHOICE"] = (decimal)mqMri.POSTURE_CHOICE;
                dr["SCANNING_SCOPE"] = (decimal)mqMri.SCANNING_SCOPE;
                dr["VISCERA_SCANNING"] = (decimal)mqMri.VISCERA_SCANNING;
                dr["STRUCTURE_RESOLUTION"] = (decimal)mqMri.STRUCTURE_RESOLUTION;
                dr["HIST_CONTRAST"] = (decimal)mqMri.HIST_CONTRAST;
                dr["RESOLUTION"] = (decimal)mqMri.RESOLUTION;
                dr["INF_CRITERION"] = (decimal)mqMri.INF_CRITERION;
                dr["SCANNING_MODE"] = (decimal)mqMri.SCANNING_MODE;
                dr["SERIES_LEVEL_NUMBER"] = (decimal)mqMri.SERIES_LEVEL_NUMBER;
                dr["FAST_CONSULT"] = (decimal)mqMri.FAST_CONSULT;
                dr["DEVICE_SHADOW"] = (decimal)mqMri.DEVICE_SHADOW;

                dr["BASE_ASH_FOG_VALUE"] = DBNull.Value;  //判断是否为胶片或是数字图像标志列需要删除
                dr["BRIM_BACKGROUND_DENSITY"] = DBNull.Value;
                dr["FILM_FORMAT"] = DBNull.Value;
                dr["OPE_RESULT"] = DBNull.Value;
            }

            dr["EXTERNA_METAL_SHADOW"] = (decimal)mqMri.EXTERNA_METAL_SHADOW;
            dr["TOTAL_SCORE"] = (decimal)mqMri.TOTAL_SCORE;
            dr["DISTINCTION"] = (int)mqMri.DISTINCTION;
        }

        private void FillDefalutData(int lvSelectIndex, int flag)
        {
            txt_PATIENT_LOCAL_ID.Text = lv_Sternum.Items[lvSelectIndex].Text;
            txt_PATIENT_NAME.Text = lv_Sternum.Items[lvSelectIndex].SubItems[1].Text;
            txt_PATIENT_SEX.Text = lv_Sternum.Items[lvSelectIndex].SubItems[2].Text;
            txt_STUDY_DATE_TIME.Text = lv_Sternum.Items[lvSelectIndex].SubItems[3].Text;

            DataRow nDr = dtMRI.Rows.Find(lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems["EXAM_ACCESSION_NUM"].Text);
            NowRow = dtMRI.Rows.IndexOf(nDr);

            if (flag == 0) //默认为显示胶片信息
            {
                gb_DI.Enabled = false;
                gb_Film.Enabled = true;

                if (string.IsNullOrEmpty(nDr["BASE_ASH_FOG_VALUE"].ToString()))
                {
                    nDr["POSTURE_CHOICE"] = (decimal)mqMri.POSTURE_CHOICE;
                    nDr["SCANNING_SCOPE"] = (decimal)mqMri.SCANNING_SCOPE;
                    nDr["VISCERA_SCANNING"] = (decimal)mqMri.VISCERA_SCANNING;

                    nDr["RESOLUTION"] = (decimal)mqMri.RESOLUTION;
                    nDr["INF_CRITERION"] = (decimal)mqMri.INF_CRITERION;
                    nDr["SCANNING_MODE"] = (decimal)mqMri.SCANNING_MODE;
                    nDr["SERIES_LEVEL_NUMBER"] = (decimal)mqMri.SERIES_LEVEL_NUMBER;

                    nDr["BASE_ASH_FOG_VALUE"] = (decimal)mqMri.BASE_ASH_FOG_VALUE;
                    nDr["BRIM_BACKGROUND_DENSITY"] = (decimal)mqMri.BRIM_BACKGROUND_DENSITY;
                    nDr["FILM_FORMAT"] = (decimal)mqMri.FILM_FORMAT;
                    nDr["OPE_RESULT"] = (decimal)mqMri.OPE_RESULT;
                }
                N_POSTURE_CHOICE.Value = (decimal)nDr["POSTURE_CHOICE"];
                N_SCANNING_SCOPE.Value = (decimal)nDr["SCANNING_SCOPE"];
                N_VISCERA_SCANNING.Value = (decimal)nDr["VISCERA_SCANNING"];

                N_RESOLUTION.Value = (decimal)nDr["RESOLUTION"];
                N_INF_CRITERION.Value = (decimal)nDr["INF_CRITERION"];
                N_SCANNING_MODE.Value = (decimal)nDr["SCANNING_MODE"];
                N_SERIES_LEVEL_NUMBER.Value = (decimal)nDr["SERIES_LEVEL_NUMBER"];

                N_BASE_ASH_FOG_VALUE.Value = (decimal)nDr["BASE_ASH_FOG_VALUE"];
                N_BRIM_BACKGROUND_DENSITY.Value = (decimal)nDr["BRIM_BACKGROUND_DENSITY"];
                N_FILM_FORMAT.Value = (decimal)nDr["FILM_FORMAT"];
                N_OPE_RESULT.Value = (decimal)nDr["OPE_RESULT"];


            }
            else
            {
                gb_DI.Enabled = true;
                gb_Film.Enabled = false;
                if (string.IsNullOrEmpty(nDr["STRUCTURE_RESOLUTION"].ToString()))
                {
                    nDr["POSTURE_CHOICE"] = (decimal)mqMri.POSTURE_CHOICE;
                    nDr["SCANNING_SCOPE"] = (decimal)mqMri.SCANNING_SCOPE;
                    nDr["VISCERA_SCANNING"] = (decimal)mqMri.VISCERA_SCANNING;
                    nDr["RESOLUTION"] = (decimal)mqMri.RESOLUTION;
                    nDr["INF_CRITERION"] = (decimal)mqMri.INF_CRITERION;
                    nDr["SCANNING_MODE"] = (decimal)mqMri.SCANNING_MODE;
                    nDr["SERIES_LEVEL_NUMBER"] = (decimal)mqMri.SERIES_LEVEL_NUMBER;

                    nDr["STRUCTURE_RESOLUTION"] = (decimal)mqMri.STRUCTURE_RESOLUTION;
                    nDr["HIST_CONTRAST"] = (decimal)mqMri.HIST_CONTRAST;
                    nDr["FAST_CONSULT"] = (decimal)mqMri.FAST_CONSULT;
                    nDr["DEVICE_SHADOW"] = (decimal)mqMri.DEVICE_SHADOW;
                }
                D_POSTURE_CHOICE.Value = (decimal)nDr["POSTURE_CHOICE"];
                D_SCANNING_SCOPE.Value = (decimal)nDr["SCANNING_SCOPE"];
                D_VISCERA_SCANNING.Value = (decimal)nDr["VISCERA_SCANNING"];
                D_RESOLUTION.Value = (decimal)nDr["RESOLUTION"];
                D_INF_CRITERION.Value = (decimal)nDr["INF_CRITERION"];
                D_SCANNING_MODE.Value = (decimal)nDr["SCANNING_MODE"];
                D_SERIES_LEVEL_NUMBER.Value = (decimal)nDr["SERIES_LEVEL_NUMBER"];

                D_STRUCTURE_RESOLUTION.Value = (decimal)nDr["STRUCTURE_RESOLUTION"];
                D_HIST_CONTRAST.Value = (decimal)nDr["HIST_CONTRAST"];
                D_FAST_CONSULT.Value = (decimal)nDr["FAST_CONSULT"];
                D_DEVICE_SHADOW.Value = (decimal)nDr["DEVICE_SHADOW"];
            }
            nud_EXTERNA_METAL_SHADOW.Value = (decimal)nDr["EXTERNA_METAL_SHADOW"];
            txt_TOTAL_SCORE.Text = nDr["TOTAL_SCORE"].ToString();
            cmb_DISTINCTION.SelectedIndex = Convert.ToInt32(nDr["DISTINCTION"]) - 1;
        }

        private void QC_MRI_Load(object sender, EventArgs e)
        {
            this.btn_FunName.Text = this.Text;
            cmb_Style.Items.Clear();
            cmb_Style.Items.Add("胶片图像");
            cmb_Style.Items.Add("数字图像");

            lv_Sternum.Focus();
            lv_Sternum.TopItem.Selected = true;
            lv_Sternum.TopItem.Focused = true;
            cmb_Style.SelectedIndex = FirstTopType;    
        }

        private void cmb_Style_SelectedIndexChanged(object sender, EventArgs e)
        {

            MQcInformation minf = new MQcInformation();
            minf.LOCAL_ID = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].Text;
            minf.NAME = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems[1].Text;
            minf.SEX = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems[2].Text;
            minf.STUDY_DATE_TIME = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems[3].Text;
            minf.EXAM_ACCESSION_NUM = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems["EXAM_ACCESSION_NUM"].Text;
            minf.PATIENT_ID = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems["PATIENT_ID"].Text;

            DataRow dr = dtMRI.Rows.Find(lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems["EXAM_ACCESSION_NUM"].Text);
            if (cmb_Style.SelectedIndex == 0)
            {
                if (dr["BASE_ASH_FOG_VALUE"].ToString() == "")
                    FillDataTableFromClass(ref dr, minf, 0);
            }
            else
            {
                if (dr["BASE_ASH_FOG_VALUE"].ToString() != "")
                    FillDataTableFromClass(ref dr, minf, 1);
            }
            FillDefalutData(lv_Sternum.SelectedItems[0].Index, cmb_Style.SelectedIndex);
        }

        private void btn_Return_Click(object sender, EventArgs e)
        {
            DataRow nDr = dtMRI.Rows.Find(lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems["EXAM_ACCESSION_NUM"].Text);

            if (cmb_Style.Text == "胶片图像")
            {
                nDr["BASE_ASH_FOG_VALUE"] = DBNull.Value;
                FillDefalutData(lv_Sternum.SelectedItems[0].Index, 0);
            }
            else
            {
                nDr["STRUCTURE_RESOLUTION"] = DBNull.Value;
                FillDefalutData(lv_Sternum.SelectedItems[0].Index, 1);
            }
        }

        private void lv_Sternum_Click(object sender, EventArgs e)
        {
            if (lv_Sternum.SelectedItems.Count <= 0) return;
            txt_PATIENT_LOCAL_ID.Text = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].Text;
            txt_PATIENT_NAME.Text = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems[1].Text;
            txt_PATIENT_SEX.Text = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems[2].Text;
            txt_STUDY_DATE_TIME.Text = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems[3].Text;


            DataRow dr = dtMRI.Rows.Find(lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems["EXAM_ACCESSION_NUM"].Text);
            if (dr != null)
            {
                if (dr["BASE_ASH_FOG_VALUE"].ToString() != "")
                {
                    if (cmb_Style.SelectedIndex == 0)
                    {
                        FillDefalutData(lv_Sternum.SelectedItems[0].Index, 0);
                        return;
                    }
                    else
                    {
                        cmb_Style.SelectedIndex = 0;
                        return;
                    }
                }
                else
                {
                    if (cmb_Style.SelectedIndex == 1)
                    {
                        FillDefalutData(lv_Sternum.SelectedItems[0].Index, 1);
                        return;
                    }
                    else
                        cmb_Style.SelectedIndex = 1;
                }
            }
        }

        #region 胶片区控件值改变

        private void N_POSTURE_CHOICE_ValueChanged(object sender, EventArgs e)
        {
            dtMRI.Rows[NowRow]["POSTURE_CHOICE"] = N_POSTURE_CHOICE.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BRIM_BACKGROUND_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_SCANNING_MODE.Value + N_SERIES_LEVEL_NUMBER.Value + N_FILM_FORMAT.Value + N_OPE_RESULT.Value +
                    nud_EXTERNA_METAL_SHADOW.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_SCANNING_SCOPE_ValueChanged(object sender, EventArgs e)
        {
            dtMRI.Rows[NowRow]["SCANNING_SCOPE"] = N_SCANNING_SCOPE.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BRIM_BACKGROUND_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_SCANNING_MODE.Value + N_SERIES_LEVEL_NUMBER.Value + N_FILM_FORMAT.Value + N_OPE_RESULT.Value +
                    nud_EXTERNA_METAL_SHADOW.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_VISCERA_SCANNING_ValueChanged(object sender, EventArgs e)
        {
            dtMRI.Rows[NowRow]["VISCERA_SCANNING"] = N_VISCERA_SCANNING.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BRIM_BACKGROUND_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_SCANNING_MODE.Value + N_SERIES_LEVEL_NUMBER.Value + N_FILM_FORMAT.Value + N_OPE_RESULT.Value +
                    nud_EXTERNA_METAL_SHADOW.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_BASE_ASH_FOG_VALUE_ValueChanged(object sender, EventArgs e)
        {
            dtMRI.Rows[NowRow]["BASE_ASH_FOG_VALUE"] = N_BASE_ASH_FOG_VALUE.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BRIM_BACKGROUND_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_SCANNING_MODE.Value + N_SERIES_LEVEL_NUMBER.Value + N_FILM_FORMAT.Value + N_OPE_RESULT.Value +
                    nud_EXTERNA_METAL_SHADOW.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_BRIM_BACKGROUND_DENSITY_ValueChanged(object sender, EventArgs e)
        {
            dtMRI.Rows[NowRow]["BRIM_BACKGROUND_DENSITY"] = N_BRIM_BACKGROUND_DENSITY.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BRIM_BACKGROUND_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_SCANNING_MODE.Value + N_SERIES_LEVEL_NUMBER.Value + N_FILM_FORMAT.Value + N_OPE_RESULT.Value +
                    nud_EXTERNA_METAL_SHADOW.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_RESOLUTION_ValueChanged(object sender, EventArgs e)
        {
            dtMRI.Rows[NowRow]["RESOLUTION"] = N_RESOLUTION.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BRIM_BACKGROUND_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_SCANNING_MODE.Value + N_SERIES_LEVEL_NUMBER.Value + N_FILM_FORMAT.Value + N_OPE_RESULT.Value +
                    nud_EXTERNA_METAL_SHADOW.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_INF_CRITERION_ValueChanged(object sender, EventArgs e)
        {
            dtMRI.Rows[NowRow]["INF_CRITERION"] = N_INF_CRITERION.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BRIM_BACKGROUND_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_SCANNING_MODE.Value + N_SERIES_LEVEL_NUMBER.Value + N_FILM_FORMAT.Value + N_OPE_RESULT.Value +
                    nud_EXTERNA_METAL_SHADOW.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_SCANNING_MODE_ValueChanged(object sender, EventArgs e)
        {
            dtMRI.Rows[NowRow]["SCANNING_MODE"] = N_SCANNING_MODE.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BRIM_BACKGROUND_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_SCANNING_MODE.Value + N_SERIES_LEVEL_NUMBER.Value + N_FILM_FORMAT.Value + N_OPE_RESULT.Value +
                    nud_EXTERNA_METAL_SHADOW.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_SERIES_LEVEL_NUMBER_ValueChanged(object sender, EventArgs e)
        {
            dtMRI.Rows[NowRow]["SERIES_LEVEL_NUMBER"] = N_SERIES_LEVEL_NUMBER.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BRIM_BACKGROUND_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_SCANNING_MODE.Value + N_SERIES_LEVEL_NUMBER.Value + N_FILM_FORMAT.Value + N_OPE_RESULT.Value +
                    nud_EXTERNA_METAL_SHADOW.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_FILM_FORMAT_ValueChanged(object sender, EventArgs e)
        {
            dtMRI.Rows[NowRow]["FILM_FORMAT"] = N_FILM_FORMAT.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BRIM_BACKGROUND_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_SCANNING_MODE.Value + N_SERIES_LEVEL_NUMBER.Value + N_FILM_FORMAT.Value + N_OPE_RESULT.Value +
                    nud_EXTERNA_METAL_SHADOW.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_OPE_RESULT_ValueChanged(object sender, EventArgs e)
        {
            dtMRI.Rows[NowRow]["OPE_RESULT"] = N_OPE_RESULT.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BRIM_BACKGROUND_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_SCANNING_MODE.Value + N_SERIES_LEVEL_NUMBER.Value + N_FILM_FORMAT.Value + N_OPE_RESULT.Value +
                    nud_EXTERNA_METAL_SHADOW.Value;

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }
        #endregion

        private void nud_EXTERNA_METAL_SHADOW_ValueChanged(object sender, EventArgs e)
        {
            decimal dcl = 0;
            dtMRI.Rows[NowRow]["EXTERNA_METAL_SHADOW"] = nud_EXTERNA_METAL_SHADOW.Value;
            if (cmb_Style.SelectedIndex == 0)
            {
                dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value +
                   N_BASE_ASH_FOG_VALUE.Value + N_BRIM_BACKGROUND_DENSITY.Value +
                   N_RESOLUTION.Value +
                   N_INF_CRITERION.Value + N_SCANNING_MODE.Value + N_SERIES_LEVEL_NUMBER.Value + N_FILM_FORMAT.Value + N_OPE_RESULT.Value +
                   nud_EXTERNA_METAL_SHADOW.Value;
            }
            else
            {
                dcl = D_POSTURE_CHOICE.Value + D_SCANNING_SCOPE.Value + D_VISCERA_SCANNING.Value +
                    D_STRUCTURE_RESOLUTION.Value + D_HIST_CONTRAST.Value +
                    D_RESOLUTION.Value +
                    D_INF_CRITERION.Value + D_SCANNING_MODE.Value + D_SERIES_LEVEL_NUMBER.Value + D_FAST_CONSULT.Value + D_DEVICE_SHADOW.Value +
                    nud_EXTERNA_METAL_SHADOW.Value;
            }

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void txt_TOTAL_SCORE_TextChanged(object sender, EventArgs e)
        {
            dtMRI.Rows[NowRow]["TOTAL_SCORE"] = Convert.ToDecimal(txt_TOTAL_SCORE.Text);
        }

        private void cmb_DISTINCTION_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtMRI.Rows[NowRow]["DISTINCTION"] = cmb_DISTINCTION.SelectedIndex + 1;
        }

        #region 数字图像区控件值改变
        private void D_POSTURE_CHOICE_ValueChanged(object sender, EventArgs e)
        {
            dtMRI.Rows[NowRow]["POSTURE_CHOICE"] = D_POSTURE_CHOICE.Value;
            decimal dcl = D_POSTURE_CHOICE.Value + D_SCANNING_SCOPE.Value + D_VISCERA_SCANNING.Value +
                    D_STRUCTURE_RESOLUTION.Value + D_HIST_CONTRAST.Value +
                    D_RESOLUTION.Value +
                    D_INF_CRITERION.Value + D_SCANNING_MODE.Value + D_SERIES_LEVEL_NUMBER.Value + D_FAST_CONSULT.Value + D_DEVICE_SHADOW.Value +
                    nud_EXTERNA_METAL_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_SCANNING_SCOPE_ValueChanged(object sender, EventArgs e)
        {
            dtMRI.Rows[NowRow]["SCANNING_SCOPE"] = D_SCANNING_SCOPE.Value;
            decimal dcl = D_POSTURE_CHOICE.Value + D_SCANNING_SCOPE.Value + D_VISCERA_SCANNING.Value +
                    D_STRUCTURE_RESOLUTION.Value + D_HIST_CONTRAST.Value +
                    D_RESOLUTION.Value +
                    D_INF_CRITERION.Value + D_SCANNING_MODE.Value + D_SERIES_LEVEL_NUMBER.Value + D_FAST_CONSULT.Value + D_DEVICE_SHADOW.Value +
                    nud_EXTERNA_METAL_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_VISCERA_SCANNING_ValueChanged(object sender, EventArgs e)
        {
            dtMRI.Rows[NowRow]["VISCERA_SCANNING"] = D_VISCERA_SCANNING.Value;
            decimal dcl = D_POSTURE_CHOICE.Value + D_SCANNING_SCOPE.Value + D_VISCERA_SCANNING.Value +
                    D_STRUCTURE_RESOLUTION.Value + D_HIST_CONTRAST.Value +
                    D_RESOLUTION.Value +
                    D_INF_CRITERION.Value + D_SCANNING_MODE.Value + D_SERIES_LEVEL_NUMBER.Value + D_FAST_CONSULT.Value + D_DEVICE_SHADOW.Value +
                    nud_EXTERNA_METAL_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_STRUCTURE_RESOLUTION_ValueChanged(object sender, EventArgs e)
        {
            dtMRI.Rows[NowRow]["STRUCTURE_RESOLUTION"] = D_STRUCTURE_RESOLUTION.Value;
            decimal dcl = D_POSTURE_CHOICE.Value + D_SCANNING_SCOPE.Value + D_VISCERA_SCANNING.Value +
                    D_STRUCTURE_RESOLUTION.Value + D_HIST_CONTRAST.Value +
                    D_RESOLUTION.Value +
                    D_INF_CRITERION.Value + D_SCANNING_MODE.Value + D_SERIES_LEVEL_NUMBER.Value + D_FAST_CONSULT.Value + D_DEVICE_SHADOW.Value +
                    nud_EXTERNA_METAL_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_HIST_CONTRAST_ValueChanged(object sender, EventArgs e)
        {
            dtMRI.Rows[NowRow]["HIST_CONTRAST"] = D_HIST_CONTRAST.Value;
            decimal dcl = D_POSTURE_CHOICE.Value + D_SCANNING_SCOPE.Value + D_VISCERA_SCANNING.Value +
                    D_STRUCTURE_RESOLUTION.Value + D_HIST_CONTRAST.Value +
                    D_RESOLUTION.Value +
                    D_INF_CRITERION.Value + D_SCANNING_MODE.Value + D_SERIES_LEVEL_NUMBER.Value + D_FAST_CONSULT.Value + D_DEVICE_SHADOW.Value +
                    nud_EXTERNA_METAL_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_RESOLUTION_ValueChanged(object sender, EventArgs e)
        {
            dtMRI.Rows[NowRow]["RESOLUTION"] = D_RESOLUTION.Value;
            decimal dcl = D_POSTURE_CHOICE.Value + D_SCANNING_SCOPE.Value + D_VISCERA_SCANNING.Value +
                    D_STRUCTURE_RESOLUTION.Value + D_HIST_CONTRAST.Value +
                    D_RESOLUTION.Value +
                    D_INF_CRITERION.Value + D_SCANNING_MODE.Value + D_SERIES_LEVEL_NUMBER.Value + D_FAST_CONSULT.Value + D_DEVICE_SHADOW.Value +
                    nud_EXTERNA_METAL_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_INF_CRITERION_ValueChanged(object sender, EventArgs e)
        {
            dtMRI.Rows[NowRow]["INF_CRITERION"] = D_INF_CRITERION.Value;
            decimal dcl = D_POSTURE_CHOICE.Value + D_SCANNING_SCOPE.Value + D_VISCERA_SCANNING.Value +
                    D_STRUCTURE_RESOLUTION.Value + D_HIST_CONTRAST.Value +
                    D_RESOLUTION.Value +
                    D_INF_CRITERION.Value + D_SCANNING_MODE.Value + D_SERIES_LEVEL_NUMBER.Value + D_FAST_CONSULT.Value + D_DEVICE_SHADOW.Value +
                    nud_EXTERNA_METAL_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_SCANNING_MODE_ValueChanged(object sender, EventArgs e)
        {
            dtMRI.Rows[NowRow]["SCANNING_MODE"] = D_SCANNING_MODE.Value;
            decimal dcl = D_POSTURE_CHOICE.Value + D_SCANNING_SCOPE.Value + D_VISCERA_SCANNING.Value +
                    D_STRUCTURE_RESOLUTION.Value + D_HIST_CONTRAST.Value +
                    D_RESOLUTION.Value +
                    D_INF_CRITERION.Value + D_SCANNING_MODE.Value + D_SERIES_LEVEL_NUMBER.Value + D_FAST_CONSULT.Value + D_DEVICE_SHADOW.Value +
                    nud_EXTERNA_METAL_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_SERIES_LEVEL_NUMBER_ValueChanged(object sender, EventArgs e)
        {
            dtMRI.Rows[NowRow]["SERIES_LEVEL_NUMBER"] = D_SERIES_LEVEL_NUMBER.Value;
            decimal dcl = D_POSTURE_CHOICE.Value + D_SCANNING_SCOPE.Value + D_VISCERA_SCANNING.Value +
                    D_STRUCTURE_RESOLUTION.Value + D_HIST_CONTRAST.Value +
                    D_RESOLUTION.Value +
                    D_INF_CRITERION.Value + D_SCANNING_MODE.Value + D_SERIES_LEVEL_NUMBER.Value + D_FAST_CONSULT.Value + D_DEVICE_SHADOW.Value +
                    nud_EXTERNA_METAL_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_FAST_CONSULT_ValueChanged(object sender, EventArgs e)
        {
            dtMRI.Rows[NowRow]["FAST_CONSULT"] = D_FAST_CONSULT.Value;
            decimal dcl = D_POSTURE_CHOICE.Value + D_SCANNING_SCOPE.Value + D_VISCERA_SCANNING.Value +
                    D_STRUCTURE_RESOLUTION.Value + D_HIST_CONTRAST.Value +
                    D_RESOLUTION.Value +
                    D_INF_CRITERION.Value + D_SCANNING_MODE.Value + D_SERIES_LEVEL_NUMBER.Value + D_FAST_CONSULT.Value + D_DEVICE_SHADOW.Value +
                    nud_EXTERNA_METAL_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_DEVICE_SHADOW_ValueChanged(object sender, EventArgs e)
        {
            dtMRI.Rows[NowRow]["DEVICE_SHADOW"] = D_DEVICE_SHADOW.Value;
            decimal dcl = D_POSTURE_CHOICE.Value + D_SCANNING_SCOPE.Value + D_VISCERA_SCANNING.Value +
                    D_STRUCTURE_RESOLUTION.Value + D_HIST_CONTRAST.Value +
                    D_RESOLUTION.Value +
                    D_INF_CRITERION.Value + D_SCANNING_MODE.Value + D_SERIES_LEVEL_NUMBER.Value + D_FAST_CONSULT.Value + D_DEVICE_SHADOW.Value +
                    nud_EXTERNA_METAL_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }
        #endregion

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            for (int i = 0; i < dtMRI.Rows.Count; i++)
            {
                if (dtMRI.Rows[i]["EXAM_ACCESSION_NUM"].ToString() == "" || dtMRI.Rows[i]["PATIENT_LOCAL_ID"].ToString() == "") continue;

                MQcMri mf = new MQcMri();

                mf.EXAM_ACCESSION_NUM = dtMRI.Rows[i]["EXAM_ACCESSION_NUM"].ToString();
                mf.PATIENT_ID = dtMRI.Rows[i]["PATIENT_ID"].ToString();
                mf.PATIENT_LOCAL_ID = dtMRI.Rows[i]["PATIENT_LOCAL_ID"].ToString();
                mf.PATIENT_NAME = dtMRI.Rows[i]["PATIENT_NAME"].ToString();
                mf.PATIENT_SEX = dtMRI.Rows[i]["PATIENT_SEX"].ToString();
                mf.STUDY_DATE_TIME = Convert.ToDateTime(dtMRI.Rows[i]["STUDY_DATE_TIME"]);
                mf.QC_DATE = DateTime.Now;

                mf.POSTURE_CHOICE = (decimal)dtMRI.Rows[i]["POSTURE_CHOICE"];
                mf.SCANNING_SCOPE = (decimal)dtMRI.Rows[i]["SCANNING_SCOPE"];
                mf.VISCERA_SCANNING = (decimal)dtMRI.Rows[i]["VISCERA_SCANNING"];
                mf.RESOLUTION = (decimal)dtMRI.Rows[i]["RESOLUTION"];
                mf.INF_CRITERION = (decimal)dtMRI.Rows[i]["INF_CRITERION"];
                mf.SCANNING_MODE = (decimal)dtMRI.Rows[i]["SCANNING_MODE"];
                mf.SERIES_LEVEL_NUMBER = (decimal)dtMRI.Rows[i]["SERIES_LEVEL_NUMBER"];

                if (!string.IsNullOrEmpty(dtMRI.Rows[i]["BASE_ASH_FOG_VALUE"].ToString()))
                {
                    mf.BASE_ASH_FOG_VALUE = (decimal)dtMRI.Rows[i]["BASE_ASH_FOG_VALUE"];
                    mf.BRIM_BACKGROUND_DENSITY = (decimal)dtMRI.Rows[i]["BRIM_BACKGROUND_DENSITY"];
                    mf.FILM_FORMAT = (decimal)dtMRI.Rows[i]["FILM_FORMAT"];
                    mf.OPE_RESULT = (decimal)dtMRI.Rows[i]["OPE_RESULT"];

                    mf.STRUCTURE_RESOLUTION = null;
                    mf.HIST_CONTRAST = null;
                    mf.FAST_CONSULT = null;
                    mf.DEVICE_SHADOW = null;
                }
                else
                {
                    mf.STRUCTURE_RESOLUTION = (decimal)dtMRI.Rows[i]["STRUCTURE_RESOLUTION"];
                    mf.HIST_CONTRAST = (decimal)dtMRI.Rows[i]["HIST_CONTRAST"];
                    mf.FAST_CONSULT = (decimal)dtMRI.Rows[i]["FAST_CONSULT"];
                    mf.DEVICE_SHADOW = (decimal)dtMRI.Rows[i]["DEVICE_SHADOW"];

                    mf.BASE_ASH_FOG_VALUE = null;
                    mf.BRIM_BACKGROUND_DENSITY = null;
                    mf.FILM_FORMAT = null;
                    mf.OPE_RESULT = null;
                }

                mf.EXTERNA_METAL_SHADOW = Convert.ToDecimal(dtMRI.Rows[i]["EXTERNA_METAL_SHADOW"]);
                mf.TOTAL_SCORE = Convert.ToDecimal(dtMRI.Rows[i]["TOTAL_SCORE"]);
                mf.DISTINCTION = Convert.ToInt32(dtMRI.Rows[i]["DISTINCTION"]);
                ht.Add(i, mf);
            }

            int j = 0;
            if (isModify)
            {
                j = bqMri.UpdateMore(ht);
                if (j >= 0)
                    MessageBoxEx.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBoxEx.Show("修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                j = bqMri.AddMore(ht);
                if (j >= 0)
                {
                    MessageBoxEx.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isModify = true;
                }
                else
                    MessageBoxEx.Show("添加失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            rptDocument.Load(path + "CR_MRI.rpt");
            int DISTINCTION_1 = 0, DISTINCTION_2 = 0, DISTINCTION_3 = 0;
            decimal Total_Score_All = 0;

            DataTable dtSernum = MeregeDataTableData(ref DISTINCTION_1, ref DISTINCTION_2, ref DISTINCTION_3, ref Total_Score_All);
            this.rptDocument.SetDataSource(dtSernum);

            SIS_Function.ApiIni AI = new SIS_Function.ApiIni(Application.StartupPath + @"\Settings.ini");
            string Hosiptal_Name = AI.IniReadValue("bcOffice", "HospitalName");
            this.rptDocument.SetParameterValue("Hospital_Name", Hosiptal_Name);
            this.rptDocument.SetParameterValue("DISTINCTION_1", DISTINCTION_1);
            this.rptDocument.SetParameterValue("DISTINCTION_2", DISTINCTION_2);
            this.rptDocument.SetParameterValue("DISTINCTION_3", DISTINCTION_3);
            this.rptDocument.SetParameterValue("Total_Score_All", Total_Score_All);
            this.rptDocument.SetParameterValue("Year", System.DateTime.Now.Year);
            this.rptDocument.SetParameterValue("Month", System.DateTime.Now.Month);
            this.crv_Sternum.ReportSource = this.rptDocument;
            this.crv_Sternum.Controls[0].Controls[0].Controls[0].Text = "MRI";
        }

        //将胶片表和数据图像表里的记录合并到一张新表中
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
            dtTpTable.Columns.Add(new DataColumn("POSTURE_CHOICE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("SCANNING_SCOPE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("VISCERA_SCANNING", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("RESOLUTION", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("INF_CRITERION", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("SCANNING_MODE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("SERIES_LEVEL_NUMBER", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("EXTERNA_METAL_SHADOW", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("BASE_ASH_FOG_VALUE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("BRIM_BACKGROUND_DENSITY", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("FILM_FORMAT", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("OPE_RESULT", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("TOTAL_SCORE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DISTINCTION", typeof(string)));
            //dtTpTable.Columns.Add(new DataColumn("NUMBER_KEY", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("D_STRUCTURE_RESOLUTION", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("D_HIST_CONTRAST", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("D_FAST_CONSULT", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("D_DEVICE_SHADOW", typeof(string)));

            DataRow nDr = dtTpTable.NewRow();

            foreach (DataRow dr in dtMRI.Rows)
            {
                nDr["PATIENT_LOCAL_ID"] += dr["PATIENT_LOCAL_ID"].ToString().PadRight(7, ' ');

                nDr["POSTURE_CHOICE"] += dr["POSTURE_CHOICE"].ToString().PadRight(6, ' ');
                nDr["SCANNING_SCOPE"] += dr["SCANNING_SCOPE"].ToString().PadRight(6, ' ');
                nDr["VISCERA_SCANNING"] += dr["VISCERA_SCANNING"].ToString().PadRight(6, ' ');
                nDr["SCANNING_MODE"] += dr["SCANNING_MODE"].ToString().PadRight(6, ' ');
                nDr["RESOLUTION"] += dr["RESOLUTION"].ToString().PadRight(6, ' ');
                nDr["INF_CRITERION"] += dr["INF_CRITERION"].ToString().PadRight(6, ' ');
                nDr["SERIES_LEVEL_NUMBER"] += dr["SERIES_LEVEL_NUMBER"].ToString().PadRight(6, ' ');
                nDr["EXTERNA_METAL_SHADOW"] += dr["EXTERNA_METAL_SHADOW"].ToString().PadRight(6, ' ');
                nDr["BASE_ASH_FOG_VALUE"] += dr["BASE_ASH_FOG_VALUE"].ToString().PadRight(6, ' ');
                nDr["BRIM_BACKGROUND_DENSITY"] += dr["BRIM_BACKGROUND_DENSITY"].ToString().PadRight(6, ' ');
                nDr["FILM_FORMAT"] += dr["FILM_FORMAT"].ToString().PadRight(6, ' ');
                nDr["OPE_RESULT"] += dr["OPE_RESULT"].ToString().PadRight(6, ' ');
                nDr["TOTAL_SCORE"] += dr["TOTAL_SCORE"].ToString().PadRight(6, ' ');
                nDr["DISTINCTION"] += dr["DISTINCTION"].ToString().PadRight(6, ' ');

                nDr["D_STRUCTURE_RESOLUTION"] += dr["STRUCTURE_RESOLUTION"].ToString().PadRight(6, ' ');
                nDr["D_HIST_CONTRAST"] += dr["HIST_CONTRAST"].ToString().PadRight(6, ' ');
                nDr["D_FAST_CONSULT"] += dr["FAST_CONSULT"].ToString().PadRight(6, ' ');
                nDr["D_DEVICE_SHADOW"] += dr["DEVICE_SHADOW"].ToString().PadRight(6, ' ');

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