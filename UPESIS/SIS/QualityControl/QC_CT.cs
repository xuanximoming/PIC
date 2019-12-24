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
    public partial class QC_CT : Form
    {
        private BQcCt bqCT = new BQcCt();
        private MQcCt mqCT = new MQcCt();
        private ReportDocument rptDocument;
        private DataTable dtCT = new DataTable();
        private int NowRow = -1;        //返回操作的行
        private int FirstTopType = -1;  //返回第一行记录的类型　
        private bool isModify = true;  //如果由查询界面进入此窗体,则点保存时为修改否则为新增;默认为修改
        private string path = Application.StartupPath + "\\CrystalReports\\";

        public QC_CT()
        {
            InitializeComponent();

            dtCT = bqCT.GetList("EXAM_ACCESSION_NUM=''");
            dtCT.PrimaryKey = new System.Data.DataColumn[] { dtCT.Columns["EXAM_ACCESSION_NUM"] };
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
                    DataTable dt = bqCT.GetList("EXAM_ACCESSION_NUM='" + mqcInfor.EXAM_ACCESSION_NUM + "'");
                    if (dt.Rows.Count > 0)
                    {
                        if (i == 0 && FirstTopType == -1)
                            FirstTopType = 0;

                        FillDataTableFromTable(dt.Rows[0], 0);
                    }
                }
                else if (mqcInfor.Type.ToString() == "1")
                {
                    DataTable dt = bqCT.GetList("EXAM_ACCESSION_NUM='" + mqcInfor.EXAM_ACCESSION_NUM + "'");
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
                    string temp = AI.IniReadValue("FilmOrDI", "CT_FilmOrDI");

                    if (i == 0 && FirstTopType == -1)
                        FirstTopType = int.Parse(temp);

                    DataRow dr = dtCT.NewRow();
                    FillDataTableFromClass(ref  dr, mqcInfor, int.Parse(temp));
                    dtCT.Rows.Add(dr);
                }
            }
            return true;
        }

        private void FillDataTableFromTable(DataRow dttp,int flag)
        {
            DataRow dr = dtCT.NewRow();
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
                dr["SCANNING_MODE"] = dttp["SCANNING_MODE"];
                dr["BASE_ASH_FOG_VALUE"] = dttp["BASE_ASH_FOG_VALUE"];
                dr["BLANK_EXPOSAL_DENSITY"] = dttp["BLANK_EXPOSAL_DENSITY"];
                dr["RESOLUTION"] = dttp["RESOLUTION"];
                dr["INF_CRITERION"] = dttp["INF_CRITERION"];
                dr["WL_WWIDTH"] = dttp["WL_WWIDTH"];
                dr["FILM_FORMAT"] = dttp["FILM_FORMAT"];
                dr["STATIC_SHADOW"] = dttp["STATIC_SHADOW"];
                dr["NICK"] = dttp["NICK"];
                dr["WATER_MARK"] = dttp["WATER_MARK"];
                dr["FINGER_MARK"] = dttp["FINGER_MARK"];
                dr["LIGHT_LEAK"] = dttp["LIGHT_LEAK"];
                dr["EXTERNA_BREATH_SHADOW"] = dttp["EXTERNA_BREATH_SHADOW"];

                dr["STRIP_SHADOW"] = DBNull.Value;      //判断是否为胶片或是数字图像标志列需要删除
                dr["CTN"] = DBNull.Value;
                dr["FAST_CONSULT"] = DBNull.Value;
                dr["DEVICE_SHADOW"] = DBNull.Value;
            }
            else
            {
                dr["POSTURE_CHOICE"] = dttp["POSTURE_CHOICE"];
                dr["SCANNING_SCOPE"] = dttp["SCANNING_SCOPE"];
                dr["VISCERA_SCANNING"] = dttp["VISCERA_SCANNING"];
                dr["SCANNING_MODE"] = dttp["SCANNING_MODE"];
                dr["STRIP_SHADOW"] = dttp["STRIP_SHADOW"];
                dr["CTN"] = dttp["CTN"];
                dr["FAST_CONSULT"] = dttp["FAST_CONSULT"];
                dr["RESOLUTION"] = dttp["RESOLUTION"];
                dr["INF_CRITERION"] = dttp["INF_CRITERION"];
                dr["WL_WWIDTH"] = dttp["WL_WWIDTH"];
                dr["DEVICE_SHADOW"] = dttp["DEVICE_SHADOW"];

                dr["BASE_ASH_FOG_VALUE"] = DBNull.Value;
                dr["BLANK_EXPOSAL_DENSITY"] = DBNull.Value;
                dr["FILM_FORMAT"] = DBNull.Value;
                dr["NICK"] = DBNull.Value;
                dr["WATER_MARK"] = DBNull.Value;
                dr["FINGER_MARK"] = DBNull.Value;
                dr["LIGHT_LEAK"] = DBNull.Value;
                dr["STATIC_SHADOW"] = DBNull.Value;
            }
            dr["EXTERNA_BREATH_SHADOW"] = dttp["EXTERNA_BREATH_SHADOW"];
            dr["TOTAL_SCORE"] = dttp["TOTAL_SCORE"];
            dr["DISTINCTION"] = dttp["DISTINCTION"];
            dtCT.Rows.Add(dr);
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
                dr["POSTURE_CHOICE"] = (decimal)mqCT.POSTURE_CHOICE;
                dr["SCANNING_SCOPE"] = (decimal)mqCT.SCANNING_SCOPE;
                dr["VISCERA_SCANNING"] = (decimal)mqCT.VISCERA_SCANNING;
                dr["SCANNING_MODE"] = (decimal)mqCT.SCANNING_MODE;
                dr["RESOLUTION"] = (decimal)mqCT.RESOLUTION;
                dr["INF_CRITERION"] = (decimal)mqCT.INF_CRITERION;
                dr["WL_WWIDTH"] = (decimal)mqCT.WL_WWIDTH;

                dr["BASE_ASH_FOG_VALUE"] = (decimal)mqCT.BASE_ASH_FOG_VALUE;
                dr["BLANK_EXPOSAL_DENSITY"] = (decimal)mqCT.BLANK_EXPOSAL_DENSITY;
                dr["FILM_FORMAT"] = (decimal)mqCT.FILM_FORMAT;
                dr["STATIC_SHADOW"] = (decimal)mqCT.STATIC_SHADOW;
                dr["NICK"] = (decimal)mqCT.NICK;
                dr["WATER_MARK"] = (decimal)mqCT.WATER_MARK;
                dr["FINGER_MARK"] = (decimal)mqCT.FINGER_MARK;
                dr["LIGHT_LEAK"] = (decimal)mqCT.LIGHT_LEAK;

                dr["STRIP_SHADOW"] = DBNull.Value;      //判断是否为胶片或是数字图像标志列需要删除
                dr["CTN"] = DBNull.Value;
                dr["FAST_CONSULT"] = DBNull.Value;
                dr["DEVICE_SHADOW"] = DBNull.Value;
            }
            else
            {
                dr["POSTURE_CHOICE"] = (decimal)mqCT.POSTURE_CHOICE;
                dr["SCANNING_SCOPE"] = (decimal)mqCT.SCANNING_SCOPE;
                dr["VISCERA_SCANNING"] = (decimal)mqCT.VISCERA_SCANNING;
                dr["SCANNING_MODE"] = (decimal)mqCT.SCANNING_MODE;
                dr["STRIP_SHADOW"] = (decimal)mqCT.STRIP_SHADOW;
                dr["CTN"] = (decimal)mqCT.CTN;
                dr["FAST_CONSULT"] = (decimal)mqCT.FAST_CONSULT;
                dr["RESOLUTION"] = (decimal)mqCT.RESOLUTION;
                dr["INF_CRITERION"] = (decimal)mqCT.INF_CRITERION;
                dr["WL_WWIDTH"] = (decimal)mqCT.WL_WWIDTH;
                dr["DEVICE_SHADOW"] = (decimal)mqCT.DEVICE_SHADOW;

                dr["BASE_ASH_FOG_VALUE"] = DBNull.Value;
                dr["BLANK_EXPOSAL_DENSITY"] = DBNull.Value;
                dr["FILM_FORMAT"] = DBNull.Value;
                dr["NICK"] = DBNull.Value;
                dr["WATER_MARK"] = DBNull.Value;
                dr["FINGER_MARK"] = DBNull.Value;
                dr["LIGHT_LEAK"] = DBNull.Value;
                dr["STATIC_SHADOW"] = DBNull.Value;
            }
            dr["EXTERNA_BREATH_SHADOW"] = (decimal)mqCT.EXTERNA_BREATH_SHADOW;
            dr["TOTAL_SCORE"] = (decimal)mqCT.TOTAL_SCORE;
            dr["DISTINCTION"] = (int)mqCT.DISTINCTION;
        }

        private void FillDefalutData(int lvSelectIndex, int flag)
        {
            txt_PATIENT_LOCAL_ID.Text = lv_Sternum.Items[lvSelectIndex].Text;
            txt_PATIENT_NAME.Text = lv_Sternum.Items[lvSelectIndex].SubItems[1].Text;
            txt_PATIENT_SEX.Text = lv_Sternum.Items[lvSelectIndex].SubItems[2].Text;
            txt_STUDY_DATE_TIME.Text = lv_Sternum.Items[lvSelectIndex].SubItems[3].Text;

            DataRow nDr = dtCT.Rows.Find(lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems["EXAM_ACCESSION_NUM"].Text);
            NowRow = dtCT.Rows.IndexOf(nDr);

            if (flag == 0) //默认为显示胶片信息
            {
                gb_DI.Enabled = false;
                gb_Film.Enabled = true;

                if (string.IsNullOrEmpty(nDr["BASE_ASH_FOG_VALUE"].ToString()))
                {
                    nDr["POSTURE_CHOICE"] = (decimal)mqCT.POSTURE_CHOICE;
                    nDr["SCANNING_SCOPE"] = (decimal)mqCT.SCANNING_SCOPE;
                    nDr["VISCERA_SCANNING"] = (decimal)mqCT.VISCERA_SCANNING;
                    nDr["SCANNING_MODE"] = (decimal)mqCT.SCANNING_MODE;
                    nDr["BASE_ASH_FOG_VALUE"] = (decimal)mqCT.BASE_ASH_FOG_VALUE;
                    nDr["BLANK_EXPOSAL_DENSITY"] = (decimal)mqCT.BLANK_EXPOSAL_DENSITY;
                    nDr["RESOLUTION"] = (decimal)mqCT.RESOLUTION;
                    nDr["INF_CRITERION"] = (decimal)mqCT.INF_CRITERION;
                    nDr["WL_WWIDTH"] = (decimal)mqCT.WL_WWIDTH;
                    nDr["FILM_FORMAT"] = (decimal)mqCT.FILM_FORMAT;
                    nDr["STATIC_SHADOW"] = (decimal)mqCT.STATIC_SHADOW;
                    nDr["NICK"] = (decimal)mqCT.NICK;
                    nDr["WATER_MARK"] = (decimal)mqCT.WATER_MARK;
                    nDr["FINGER_MARK"] = (decimal)mqCT.FINGER_MARK;
                    nDr["LIGHT_LEAK"] = (decimal)mqCT.LIGHT_LEAK;
                }
                N_POSTURE_CHOICE.Value = (decimal)nDr["POSTURE_CHOICE"];
                N_SCANNING_SCOPE.Value = (decimal)nDr["SCANNING_SCOPE"];
                N_VISCERA_SCANNING.Value = (decimal)nDr["VISCERA_SCANNING"];
                N_SCANNING_MODE.Value = (decimal)nDr["SCANNING_MODE"];
                N_BASE_ASH_FOG_VALUE.Value = (decimal)nDr["BASE_ASH_FOG_VALUE"];
                N_BLANK_EXPOSAL_DENSITY.Value = (decimal)nDr["BLANK_EXPOSAL_DENSITY"];
                N_RESOLUTION.Value = (decimal)nDr["RESOLUTION"];
                N_INF_CRITERION.Value = (decimal)nDr["INF_CRITERION"];
                N_WL_WWIDTH.Value = (decimal)nDr["WL_WWIDTH"];
                N_FILM_FORMAT.Value = (decimal)nDr["FILM_FORMAT"];
                N_STATIC_SHADOW.Value = (decimal)nDr["STATIC_SHADOW"];
                N_NICK.Value = (decimal)nDr["NICK"];
                N_WATER_MARK.Value = (decimal)nDr["WATER_MARK"];
                N_FINGER_MARK.Value = (decimal)nDr["FINGER_MARK"];
                N_LIGHT_LEAK.Value = (decimal)nDr["LIGHT_LEAK"];
            }
            else
            {
                gb_DI.Enabled = true;
                gb_Film.Enabled = false;

                if (string.IsNullOrEmpty(nDr["STRIP_SHADOW"].ToString()))
                {
                    nDr["POSTURE_CHOICE"] = (decimal)mqCT.POSTURE_CHOICE;
                    nDr["SCANNING_SCOPE"] = (decimal)mqCT.SCANNING_SCOPE;
                    nDr["VISCERA_SCANNING"] = (decimal)mqCT.VISCERA_SCANNING;
                    nDr["SCANNING_MODE"] = (decimal)mqCT.SCANNING_MODE;
                    nDr["STRIP_SHADOW"] = (decimal)mqCT.STRIP_SHADOW;
                    nDr["CTN"] = (decimal)mqCT.CTN;
                    nDr["FAST_CONSULT"] = (decimal)mqCT.FAST_CONSULT;
                    nDr["RESOLUTION"] = (decimal)mqCT.RESOLUTION;
                    nDr["INF_CRITERION"] = (decimal)mqCT.INF_CRITERION;
                    nDr["WL_WWIDTH"] = (decimal)mqCT.WL_WWIDTH;
                    nDr["DEVICE_SHADOW"] = (decimal)mqCT.DEVICE_SHADOW;
                }
                D_POSTURE_CHOICE.Value = (decimal)nDr["POSTURE_CHOICE"];
                D_SCANNING_SCOPE.Value = (decimal)nDr["SCANNING_SCOPE"];
                D_VISCERA_SCANNING.Value = (decimal)nDr["VISCERA_SCANNING"];
                D_SCANNING_MODE.Value = (decimal)nDr["SCANNING_MODE"];
                D_STRIP_SHADOW.Value = (decimal)nDr["STRIP_SHADOW"];
                D_CTN.Value = (decimal)nDr["CTN"];
                D_FAST_CONSULT.Value = (decimal)nDr["FAST_CONSULT"];
                D_RESOLUTION.Value = (decimal)nDr["RESOLUTION"];
                D_INF_CRITERION.Value = (decimal)nDr["INF_CRITERION"];
                D_WL_WWIDTH.Value = (decimal)nDr["WL_WWIDTH"];
                D_DEVICE_SHADOW.Value = (decimal)nDr["DEVICE_SHADOW"];
            }
            nud_EXTERNA_BREATH_SHADOW.Value = (decimal)nDr["EXTERNA_BREATH_SHADOW"];
            txt_TOTAL_SCORE.Text = nDr["TOTAL_SCORE"].ToString();
            cmb_DISTINCTION.SelectedIndex = Convert.ToInt32(nDr["DISTINCTION"]) - 1;
        }

        private void QC_CT_Load(object sender, EventArgs e)
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

            DataRow dr = dtCT.Rows.Find(lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems["EXAM_ACCESSION_NUM"].Text);
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
            MQcInformation minf = new MQcInformation();
            minf.LOCAL_ID = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].Text;
            minf.NAME = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems[1].Text;
            minf.SEX = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems[2].Text;
            minf.STUDY_DATE_TIME = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems[3].Text;
            minf.EXAM_ACCESSION_NUM = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems["EXAM_ACCESSION_NUM"].Text;
            minf.PATIENT_ID = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems["PATIENT_ID"].Text;

            DataRow dr = dtCT.Rows.Find(lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems["EXAM_ACCESSION_NUM"].Text);
            if (dr != null)
            {
                FillDataTableFromClass(ref dr, minf, cmb_Style.SelectedIndex );
            }
            FillDefalutData(lv_Sternum.SelectedItems[0].Index, cmb_Style.SelectedIndex);
        }

        private void lv_Sternum_Click(object sender, EventArgs e)
        {
            if (lv_Sternum.SelectedItems.Count <= 0) return;
            txt_PATIENT_LOCAL_ID.Text = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].Text;
            txt_PATIENT_NAME.Text = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems[1].Text;
            txt_PATIENT_SEX.Text = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems[2].Text;
            txt_STUDY_DATE_TIME.Text = lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems[3].Text;


            DataRow dr = dtCT.Rows.Find(lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems["EXAM_ACCESSION_NUM"].Text);
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
            dtCT.Rows[NowRow]["POSTURE_CHOICE"] = N_POSTURE_CHOICE.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value + N_SCANNING_MODE.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_WL_WWIDTH.Value + N_FILM_FORMAT.Value + N_STATIC_SHADOW.Value + N_NICK.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
                    
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_SCANNING_SCOPE_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["SCANNING_SCOPE"] = N_SCANNING_SCOPE.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value + N_SCANNING_MODE.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_WL_WWIDTH.Value + N_FILM_FORMAT.Value + N_STATIC_SHADOW.Value + N_NICK.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_VISCERA_SCANNING_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["VISCERA_SCANNING"] = N_VISCERA_SCANNING.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value + N_SCANNING_MODE.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_WL_WWIDTH.Value + N_FILM_FORMAT.Value + N_STATIC_SHADOW.Value + N_NICK.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_SCANNING_MODE_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["SCANNING_MODE"] = N_SCANNING_MODE.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value + N_SCANNING_MODE.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_WL_WWIDTH.Value + N_FILM_FORMAT.Value + N_STATIC_SHADOW.Value + N_NICK.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_BASE_ASH_FOG_VALUE_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["BASE_ASH_FOG_VALUE"] = N_BASE_ASH_FOG_VALUE.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value + N_SCANNING_MODE.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_WL_WWIDTH.Value + N_FILM_FORMAT.Value + N_STATIC_SHADOW.Value + N_NICK.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_BLANK_EXPOSAL_DENSITY_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["BLANK_EXPOSAL_DENSITY"] = N_BLANK_EXPOSAL_DENSITY.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value + N_SCANNING_MODE.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_WL_WWIDTH.Value + N_FILM_FORMAT.Value + N_STATIC_SHADOW.Value + N_NICK.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_RESOLUTION_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["RESOLUTION"] = N_RESOLUTION.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value + N_SCANNING_MODE.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_WL_WWIDTH.Value + N_FILM_FORMAT.Value + N_STATIC_SHADOW.Value + N_NICK.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_INF_CRITERION_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["INF_CRITERION"] = N_INF_CRITERION.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value + N_SCANNING_MODE.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_WL_WWIDTH.Value + N_FILM_FORMAT.Value + N_STATIC_SHADOW.Value + N_NICK.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_WL_WWIDTH_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["WL_WWIDTH"] = N_WL_WWIDTH.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value + N_SCANNING_MODE.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_WL_WWIDTH.Value + N_FILM_FORMAT.Value + N_STATIC_SHADOW.Value + N_NICK.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_FILM_FORMAT_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["FILM_FORMAT"] = N_FILM_FORMAT.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value + N_SCANNING_MODE.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_WL_WWIDTH.Value + N_FILM_FORMAT.Value + N_STATIC_SHADOW.Value + N_NICK.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_STATIC_SHADOW_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["STATIC_SHADOW"] = N_STATIC_SHADOW.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value + N_SCANNING_MODE.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_WL_WWIDTH.Value + N_FILM_FORMAT.Value + N_STATIC_SHADOW.Value + N_NICK.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_NICK_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["NICK"] = N_NICK.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value + N_SCANNING_MODE.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_WL_WWIDTH.Value + N_FILM_FORMAT.Value + N_STATIC_SHADOW.Value + N_NICK.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_WATER_MARK_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["WATER_MARK"] = N_WATER_MARK.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value + N_SCANNING_MODE.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_WL_WWIDTH.Value + N_FILM_FORMAT.Value + N_STATIC_SHADOW.Value + N_NICK.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_FINGER_MARK_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["FINGER_MARK"] = N_FINGER_MARK.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value + N_SCANNING_MODE.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_WL_WWIDTH.Value + N_FILM_FORMAT.Value + N_STATIC_SHADOW.Value + N_NICK.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_LIGHT_LEAK_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["LIGHT_LEAK"] = N_LIGHT_LEAK.Value;
            decimal dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value + N_SCANNING_MODE.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_WL_WWIDTH.Value + N_FILM_FORMAT.Value + N_STATIC_SHADOW.Value + N_NICK.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }
        #endregion

        private void nud_EXTERNA_BREATH_SHADOW_ValueChanged(object sender, EventArgs e)
        {
            decimal dcl = 0;
            dtCT.Rows[NowRow]["EXTERNA_BREATH_SHADOW"] = nud_EXTERNA_BREATH_SHADOW.Value;
            if (cmb_Style.SelectedIndex == 0)
            {

                dcl = N_POSTURE_CHOICE.Value + N_SCANNING_SCOPE.Value + N_VISCERA_SCANNING.Value + N_SCANNING_MODE.Value +
                    N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                    N_RESOLUTION.Value +
                    N_INF_CRITERION.Value + N_WL_WWIDTH.Value + N_FILM_FORMAT.Value + N_STATIC_SHADOW.Value + N_NICK.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            }
            else
            {
                dcl = D_POSTURE_CHOICE.Value + D_SCANNING_SCOPE.Value + D_VISCERA_SCANNING.Value + D_SCANNING_MODE.Value +
                    D_STRIP_SHADOW.Value + D_CTN.Value +
                    D_RESOLUTION.Value +
                    D_INF_CRITERION.Value + D_WL_WWIDTH.Value + D_FAST_CONSULT.Value + D_DEVICE_SHADOW.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            }

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void cmb_DISTINCTION_SelectedIndexChanged(object sender, EventArgs e)
        {
                dtCT.Rows[NowRow]["DISTINCTION"] = cmb_DISTINCTION.SelectedIndex + 1;
        }

        private void txt_TOTAL_SCORE_TextChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["TOTAL_SCORE"] = Convert.ToDecimal(txt_TOTAL_SCORE.Text);
        }

        #region 数字图像控件值改变
        private void D_POSTURE_CHOICE_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["POSTURE_CHOICE"] = D_POSTURE_CHOICE.Value;
            decimal dcl = D_POSTURE_CHOICE.Value + D_SCANNING_SCOPE.Value + D_VISCERA_SCANNING.Value + D_SCANNING_MODE.Value +
                    D_STRIP_SHADOW.Value + D_CTN.Value +
                    D_RESOLUTION.Value +
                    D_INF_CRITERION.Value + D_WL_WWIDTH.Value + D_FAST_CONSULT.Value + D_DEVICE_SHADOW.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_SCANNING_SCOPE_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["SCANNING_SCOPE"] = D_SCANNING_SCOPE.Value;
            decimal dcl = D_POSTURE_CHOICE.Value + D_SCANNING_SCOPE.Value + D_VISCERA_SCANNING.Value + D_SCANNING_MODE.Value +
                    D_STRIP_SHADOW.Value + D_CTN.Value +
                    D_RESOLUTION.Value +
                    D_INF_CRITERION.Value + D_WL_WWIDTH.Value + D_FAST_CONSULT.Value + D_DEVICE_SHADOW.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_VISCERA_SCANNING_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["VISCERA_SCANNING"] = D_VISCERA_SCANNING.Value;
            decimal dcl = D_POSTURE_CHOICE.Value + D_SCANNING_SCOPE.Value + D_VISCERA_SCANNING.Value + D_SCANNING_MODE.Value +
                    D_STRIP_SHADOW.Value + D_CTN.Value +
                    D_RESOLUTION.Value +
                    D_INF_CRITERION.Value + D_WL_WWIDTH.Value + D_FAST_CONSULT.Value + D_DEVICE_SHADOW.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_SCANNING_MODE_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["SCANNING_MODE"] = D_SCANNING_MODE.Value;
            decimal dcl = D_POSTURE_CHOICE.Value + D_SCANNING_SCOPE.Value + D_VISCERA_SCANNING.Value + D_SCANNING_MODE.Value +
                    D_STRIP_SHADOW.Value + D_CTN.Value +
                    D_RESOLUTION.Value +
                    D_INF_CRITERION.Value + D_WL_WWIDTH.Value + D_FAST_CONSULT.Value + D_DEVICE_SHADOW.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_STRIP_SHADOW_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["STRIP_SHADOW"] = D_STRIP_SHADOW.Value;
            decimal dcl = D_POSTURE_CHOICE.Value + D_SCANNING_SCOPE.Value + D_VISCERA_SCANNING.Value + D_SCANNING_MODE.Value +
                    D_STRIP_SHADOW.Value + D_CTN.Value +
                    D_RESOLUTION.Value +
                    D_INF_CRITERION.Value + D_WL_WWIDTH.Value + D_FAST_CONSULT.Value + D_DEVICE_SHADOW.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_CTN_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["CTN"] = D_CTN.Value;
            decimal dcl = D_POSTURE_CHOICE.Value + D_SCANNING_SCOPE.Value + D_VISCERA_SCANNING.Value + D_SCANNING_MODE.Value +
                    D_STRIP_SHADOW.Value + D_CTN.Value +
                    D_RESOLUTION.Value +
                    D_INF_CRITERION.Value + D_WL_WWIDTH.Value + D_FAST_CONSULT.Value + D_DEVICE_SHADOW.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_RESOLUTION_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["RESOLUTION"] = D_RESOLUTION.Value;
            decimal dcl = D_POSTURE_CHOICE.Value + D_SCANNING_SCOPE.Value + D_VISCERA_SCANNING.Value + D_SCANNING_MODE.Value +
                    D_STRIP_SHADOW.Value + D_CTN.Value +
                    D_RESOLUTION.Value +
                    D_INF_CRITERION.Value + D_WL_WWIDTH.Value + D_FAST_CONSULT.Value + D_DEVICE_SHADOW.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_INF_CRITERION_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["INF_CRITERION"] = D_INF_CRITERION.Value;
            decimal dcl = D_POSTURE_CHOICE.Value + D_SCANNING_SCOPE.Value + D_VISCERA_SCANNING.Value + D_SCANNING_MODE.Value +
                    D_STRIP_SHADOW.Value + D_CTN.Value +
                    D_RESOLUTION.Value +
                    D_INF_CRITERION.Value + D_WL_WWIDTH.Value + D_FAST_CONSULT.Value + D_DEVICE_SHADOW.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_WL_WWIDTH_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["WL_WWIDTH"] = D_WL_WWIDTH.Value;
            decimal dcl = D_POSTURE_CHOICE.Value + D_SCANNING_SCOPE.Value + D_VISCERA_SCANNING.Value + D_SCANNING_MODE.Value +
                    D_STRIP_SHADOW.Value + D_CTN.Value +
                    D_RESOLUTION.Value +
                    D_INF_CRITERION.Value + D_WL_WWIDTH.Value + D_FAST_CONSULT.Value + D_DEVICE_SHADOW.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_FAST_CONSULT_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["FAST_CONSULT"] = D_FAST_CONSULT.Value;
            decimal dcl = D_POSTURE_CHOICE.Value + D_SCANNING_SCOPE.Value + D_VISCERA_SCANNING.Value + D_SCANNING_MODE.Value +
                    D_STRIP_SHADOW.Value + D_CTN.Value +
                    D_RESOLUTION.Value +
                    D_INF_CRITERION.Value + D_WL_WWIDTH.Value + D_FAST_CONSULT.Value + D_DEVICE_SHADOW.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_DEVICE_SHADOW_ValueChanged(object sender, EventArgs e)
        {
            dtCT.Rows[NowRow]["DEVICE_SHADOW"] = D_DEVICE_SHADOW.Value;
            decimal dcl = D_POSTURE_CHOICE.Value + D_SCANNING_SCOPE.Value + D_VISCERA_SCANNING.Value + D_SCANNING_MODE.Value +
                    D_STRIP_SHADOW.Value + D_CTN.Value +
                    D_RESOLUTION.Value +
                    D_INF_CRITERION.Value + D_WL_WWIDTH.Value + D_FAST_CONSULT.Value + D_DEVICE_SHADOW.Value +
                    nud_EXTERNA_BREATH_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }
        #endregion

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            for (int i = 0; i < dtCT.Rows.Count; i++)
            {
                if (dtCT.Rows[i]["EXAM_ACCESSION_NUM"].ToString() == "" || dtCT.Rows[i]["PATIENT_LOCAL_ID"].ToString()=="") continue;

                MQcCt mf = new MQcCt();

                mf.EXAM_ACCESSION_NUM = dtCT.Rows[i]["EXAM_ACCESSION_NUM"].ToString();
                mf.PATIENT_ID = dtCT.Rows[i]["PATIENT_ID"].ToString();
                mf.PATIENT_LOCAL_ID = dtCT.Rows[i]["PATIENT_LOCAL_ID"].ToString();
                mf.PATIENT_NAME = dtCT.Rows[i]["PATIENT_NAME"].ToString();
                mf.PATIENT_SEX = dtCT.Rows[i]["PATIENT_SEX"].ToString();
                mf.STUDY_DATE_TIME = Convert.ToDateTime(dtCT.Rows[i]["STUDY_DATE_TIME"]);
                mf.QC_DATE = DateTime.Now;

                mf.POSTURE_CHOICE = (decimal)dtCT.Rows[i]["POSTURE_CHOICE"];
                mf.SCANNING_SCOPE = (decimal)dtCT.Rows[i]["SCANNING_SCOPE"];
                mf.VISCERA_SCANNING = (decimal)dtCT.Rows[i]["VISCERA_SCANNING"];
                mf.SCANNING_MODE = (decimal)dtCT.Rows[i]["SCANNING_MODE"];
                mf.RESOLUTION = (decimal)dtCT.Rows[i]["RESOLUTION"];
                mf.INF_CRITERION = (decimal)dtCT.Rows[i]["INF_CRITERION"];
                mf.WL_WWIDTH = (decimal)dtCT.Rows[i]["WL_WWIDTH"];

                if (!string.IsNullOrEmpty(dtCT.Rows[i]["BASE_ASH_FOG_VALUE"].ToString()))
                {
                    mf.BASE_ASH_FOG_VALUE = (decimal)dtCT.Rows[i]["BASE_ASH_FOG_VALUE"];
                    mf.BLANK_EXPOSAL_DENSITY = (decimal)dtCT.Rows[i]["BLANK_EXPOSAL_DENSITY"];
                    mf.FILM_FORMAT = (decimal)dtCT.Rows[i]["FILM_FORMAT"];
                    mf.STATIC_SHADOW = (decimal)dtCT.Rows[i]["STATIC_SHADOW"];
                    mf.NICK = (decimal)dtCT.Rows[i]["NICK"];
                    mf.WATER_MARK = (decimal)dtCT.Rows[i]["WATER_MARK"];
                    mf.FINGER_MARK = (decimal)dtCT.Rows[i]["FINGER_MARK"];
                    mf.LIGHT_LEAK = (decimal)dtCT.Rows[i]["LIGHT_LEAK"];

                    mf.STRIP_SHADOW = null;
                    mf.CTN = null;
                    mf.FAST_CONSULT = null;
                    mf.DEVICE_SHADOW = null;
                }
                else
                {
                    mf.STRIP_SHADOW = (decimal)dtCT.Rows[i]["STRIP_SHADOW"];
                    mf.CTN = (decimal)dtCT.Rows[i]["CTN"];
                    mf.FAST_CONSULT = (decimal)dtCT.Rows[i]["FAST_CONSULT"];
                    mf.DEVICE_SHADOW = (decimal)dtCT.Rows[i]["DEVICE_SHADOW"];

                    mf.BASE_ASH_FOG_VALUE = null;
                    mf.BLANK_EXPOSAL_DENSITY = null;
                    mf.FILM_FORMAT = null;
                    mf.STATIC_SHADOW = null;
                    mf.NICK = null;
                    mf.WATER_MARK = null;
                    mf.FINGER_MARK = null;
                    mf.LIGHT_LEAK = null;
                }

                mf.EXTERNA_BREATH_SHADOW = Convert.ToDecimal(dtCT.Rows[i]["EXTERNA_BREATH_SHADOW"]);
                mf.TOTAL_SCORE = Convert.ToDecimal(dtCT.Rows[i]["TOTAL_SCORE"]);
                mf.DISTINCTION = Convert.ToInt32(dtCT.Rows[i]["DISTINCTION"]);
                ht.Add(i, mf);
            }

            int j = 0;
            if (isModify)
            {
                j = bqCT.UpdateMore(ht);
                if (j >= 0)
                    MessageBoxEx.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBoxEx.Show("修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                j = bqCT.AddMore(ht);
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
            rptDocument.Load(path + "CR_CT.rpt");
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
            this.crv_Sternum.Controls[0].Controls[0].Controls[0].Text = "CT";
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

            dtTpTable.Columns.Add(new DataColumn("POSTURE_CHOICE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("SCANNING_SCOPE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("VISCERA_SCANNING", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("SCANNING_MODE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("RESOLUTION", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("INF_CRITERION", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("WL_WWIDTH", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("EXTERNA_BREATH_SHADOW", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("BASE_ASH_FOG_VALUE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("FILM_FORMAT", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("BLANK_EXPOSAL_DENSITY", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("NICK", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("WATER_MARK", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("FINGER_MARK", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("LIGHT_LEAK", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("STATIC_SHADOW", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("TOTAL_SCORE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DISTINCTION", typeof(string)));
            //dtTpTable.Columns.Add(new DataColumn("NUMBER_KEY", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("D_STRIP_SHADOW", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("D_CTN", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("D_FAST_CONSULT", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("D_DEVICE_SHADOW", typeof(string)));

            DataRow nDr = dtTpTable.NewRow();

            foreach (DataRow dr in dtCT.Rows)
            {
                nDr["PATIENT_LOCAL_ID"] += dr["PATIENT_LOCAL_ID"].ToString().PadRight(7, ' ');

                nDr["POSTURE_CHOICE"] += dr["POSTURE_CHOICE"].ToString().PadRight(6, ' ');
                nDr["SCANNING_SCOPE"] += dr["SCANNING_SCOPE"].ToString().PadRight(6, ' ');
                nDr["VISCERA_SCANNING"] += dr["VISCERA_SCANNING"].ToString().PadRight(6, ' ');
                nDr["SCANNING_MODE"] += dr["SCANNING_MODE"].ToString().PadRight(6, ' ');
                nDr["RESOLUTION"] += dr["RESOLUTION"].ToString().PadRight(6, ' ');
                nDr["INF_CRITERION"] += dr["INF_CRITERION"].ToString().PadRight(6, ' ');
                nDr["WL_WWIDTH"] += dr["WL_WWIDTH"].ToString().PadRight(6, ' ');
                nDr["EXTERNA_BREATH_SHADOW"] += dr["EXTERNA_BREATH_SHADOW"].ToString().PadRight(6, ' ');
                nDr["BASE_ASH_FOG_VALUE"] += dr["BASE_ASH_FOG_VALUE"].ToString().PadRight(6, ' ');
                nDr["FILM_FORMAT"] += dr["FILM_FORMAT"].ToString().PadRight(6, ' ');
                nDr["BLANK_EXPOSAL_DENSITY"] += dr["BLANK_EXPOSAL_DENSITY"].ToString().PadRight(6, ' ');
                nDr["NICK"] += dr["NICK"].ToString().PadRight(6, ' ');
                nDr["WATER_MARK"] += dr["WATER_MARK"].ToString().PadRight(6, ' ');
                nDr["FINGER_MARK"] += dr["FINGER_MARK"].ToString().PadRight(6, ' ');
                nDr["LIGHT_LEAK"] += dr["LIGHT_LEAK"].ToString().PadRight(6, ' ');
                nDr["STATIC_SHADOW"] += dr["STATIC_SHADOW"].ToString().PadRight(6, ' ');
                nDr["TOTAL_SCORE"] += dr["TOTAL_SCORE"].ToString().PadRight(6, ' ');
                nDr["DISTINCTION"] += dr["DISTINCTION"].ToString().PadRight(6, ' ');

                nDr["D_STRIP_SHADOW"] += dr["STRIP_SHADOW"].ToString().PadRight(6, ' ');
                nDr["D_CTN"] += dr["CTN"].ToString().PadRight(6, ' ');
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