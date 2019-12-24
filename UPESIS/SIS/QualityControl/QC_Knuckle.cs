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
    public partial class QC_Knuckle : Form
    {
        private BQcFilm bFilm = new BQcFilm();
        private BQcDigitalImage bdgImg = new BQcDigitalImage();
        private MQcFilm mFilm = new MQcFilm();
        private MQcDigitalImage mImage = new MQcDigitalImage();
        private ReportDocument rptDocument;
        private DataTable dtFilm = new DataTable();
        private DataTable dtImage = new DataTable();
        private int NowRow = -1;        //返回操作的行
        private int FirstTopType = -1;  //返回第一行记录的类型　
        private bool isModify = true;  //如果由查询界面进入此窗体,则点保存时为修改否则为新增;默认为修改
        private string path = Application.StartupPath + "\\CrystalReports\\";

        public QC_Knuckle()
        {
            InitializeComponent();

            dtFilm = bFilm.GetList("EXAM_ACCESSION_NUM=''");
            dtFilm.PrimaryKey = new System.Data.DataColumn[] { dtFilm.Columns["EXAM_ACCESSION_NUM"] };

            dtImage = bdgImg.GetList("EXAM_ACCESSION_NUM=''");
            dtImage.PrimaryKey = new System.Data.DataColumn[] { dtImage.Columns["EXAM_ACCESSION_NUM"] };
            rptDocument = new ReportDocument();
        }

        //填充listview下拉列表框
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
                    DataTable dttp = bFilm.GetList("EXAM_ACCESSION_NUM='" + mqcInfor.EXAM_ACCESSION_NUM + "'");
                    if (dttp.Rows.Count > 0)
                    {
                        if (i == 0 && FirstTopType == -1)
                            FirstTopType = (int)mqcInfor.Type;
                        FillDataTableFromTable(dttp.Rows[0], (int)mqcInfor.Type);
                    }
                }
                else if (mqcInfor.Type.ToString() == "1")
                {
                    DataTable dttpL = bdgImg.GetList("EXAM_ACCESSION_NUM='" + mqcInfor.EXAM_ACCESSION_NUM + "'");
                    if (dttpL.Rows.Count > 0)
                    {
                        if (i == 0 && FirstTopType == -1)
                            FirstTopType = (int)mqcInfor.Type;
                        FillDataTableFromTable(dttpL.Rows[0], (int)mqcInfor.Type);
                    }
                }

                else
                {
                    isModify = false;

                    SIS_Function.ApiIni AI = new SIS_Function.ApiIni(Application.StartupPath + @"\Settings.ini");
                    string temp = AI.IniReadValue("FilmOrDI", "Knuckle_FilmOrDI");

                    if (i == 0 && FirstTopType == -1)
                        FirstTopType = int.Parse(temp);

                    DataRow dr = null;
                    if (FirstTopType == 0)
                    {
                        dr = dtFilm.NewRow();
                        FillDataTableFromClass(ref  dr, mqcInfor, int.Parse(temp));
                        dtFilm.Rows.Add(dr);
                    }
                    else
                    {
                        dr = dtImage.NewRow();
                        FillDataTableFromClass(ref  dr, mqcInfor, int.Parse(temp));
                        dtImage.Rows.Add(dr);
                    }
                }
            }
            return true;
        }

        private void FillDataTableFromTable(DataRow dttp, int flag)
        {
            if (flag == 0)
            {
                DataRow dr = dtFilm.NewRow();
                dr["EXAM_ACCESSION_NUM"] = dttp["EXAM_ACCESSION_NUM"];
                dr["PATIENT_ID"] = dttp["PATIENT_ID"];
                dr["PATIENT_LOCAL_ID"] = dttp["PATIENT_LOCAL_ID"];
                dr["PATIENT_NAME"] = dttp["PATIENT_NAME"];
                dr["PATIENT_SEX"] = dttp["PATIENT_SEX"];
                dr["STUDY_DATE_TIME"] = dttp["STUDY_DATE_TIME"];

                dr["KNUCKLE_PROJECTION"] = dttp["KNUCKLE_PROJECTION"];
                dr["KNUCKLE_LONG_AXIS_PARALLEL"] = dttp["KNUCKLE_LONG_AXIS_PARALLEL"];
                dr["KNUCKLE_WRAP"] = dttp["KNUCKLE_WRAP"];
                dr["KNUCKLE_IMAGE_DISTORTION"] = dttp["KNUCKLE_IMAGE_DISTORTION"];
                dr["BASE_ASH_FOG_VALUE"] = dttp["BASE_ASH_FOG_VALUE"];
                dr["DIAGNOSE_AREA_VALUE"] = dttp["DIAGNOSE_AREA_VALUE"];
                dr["BLANK_EXPOSAL_DENSITY"] = dttp["BLANK_EXPOSAL_DENSITY"];
                dr["KNUCKLE_RESOLUTION"] = dttp["KNUCKLE_RESOLUTION"];
                dr["KNUCKLE_ARRANGEMENT_FOCUS"] = dttp["KNUCKLE_ARRANGEMENT_FOCUS"];
                dr["KNUCKLE_LETTER_ARRANGE"] = dttp["KNUCKLE_LETTER_ARRANGE"];
                dr["STATIC_SHADOW"] = dttp["STATIC_SHADOW"];
                dr["DIRT"] = dttp["DIRT"];
                dr["NICK"] = dttp["NICK"];
                dr["ADHIBIT"] = dttp["ADHIBIT"];
                dr["WATER_MARK"] = dttp["WATER_MARK"];
                dr["FINGER_MARK"] = dttp["FINGER_MARK"];
                dr["LIGHT_LEAK"] = dttp["LIGHT_LEAK"];

                dr["EXTERNA_SHADOW"] = dttp["EXTERNA_SHADOW"];
                dr["TOTAL_SCORE"] = dttp["TOTAL_SCORE"];
                dr["DISTINCTION"] = dttp["DISTINCTION"];
                dtFilm.Rows.Add(dr);
            }
            else
            {
                DataRow dr1 = dtImage.NewRow();
                dr1["EXAM_ACCESSION_NUM"] = dttp["EXAM_ACCESSION_NUM"];
                dr1["PATIENT_ID"] = dttp["PATIENT_ID"];
                dr1["PATIENT_LOCAL_ID"] = dttp["PATIENT_LOCAL_ID"];
                dr1["PATIENT_NAME"] = dttp["PATIENT_NAME"];
                dr1["PATIENT_SEX"] = dttp["PATIENT_SEX"];
                dr1["STUDY_DATE_TIME"] = dttp["STUDY_DATE_TIME"];

                dr1["KNUCKLE_PROJECTION"] = dttp["KNUCKLE_PROJECTION"];
                dr1["KNUCKLE_LONG_AXIS_PARALLEL"] = dttp["KNUCKLE_LONG_AXIS_PARALLEL"];
                dr1["KNUCKLE_WRAP"] = dttp["KNUCKLE_WRAP"];
                dr1["KNUCKLE_IMAGE_DISTORTION"] = dttp["KNUCKLE_IMAGE_DISTORTION"];
                dr1["EXPOSURE_DOSE"] = dttp["EXPOSURE_DOSE"];
                dr1["KNUCKLE_RESOLUTION"] = dttp["KNUCKLE_RESOLUTION"];
                dr1["KNUCKLE_ARRANGEMENT_FOCUS"] = dttp["KNUCKLE_ARRANGEMENT_FOCUS"];
                dr1["FLAG_CONTENT"] = dttp["FLAG_CONTENT"];
                dr1["FLAG_PLACE_ARRANGE"] = dttp["FLAG_PLACE_ARRANGE"];
                dr1["KNUCKLE_DEVICE_SHADOW"] = dttp["KNUCKLE_DEVICE_SHADOW"];

                dr1["EXTERNA_SHADOW"] = dttp["EXTERNA_SHADOW"];
                dr1["TOTAL_SCORE"] = dttp["TOTAL_SCORE"];
                dr1["DISTINCTION"] = dttp["DISTINCTION"];
                dtImage.Rows.Add(dr1);
            }
        }

        //使用默认值填充datatable
        private void FillDataTableFromClass(ref DataRow dr,MQcInformation minfor, int flag)
        {
            if (flag == 0)
            {
                dr["EXAM_ACCESSION_NUM"] = minfor.EXAM_ACCESSION_NUM;
                dr["PATIENT_ID"] = minfor.PATIENT_ID;
                dr["PATIENT_LOCAL_ID"] = minfor.LOCAL_ID;
                dr["PATIENT_NAME"] = minfor.NAME;
                dr["PATIENT_SEX"] = minfor.SEX;
                dr["STUDY_DATE_TIME"] = minfor.STUDY_DATE_TIME;

                dr["KNUCKLE_PROJECTION"] = (decimal)mFilm.KNUCKLE_PROJECTION;
                dr["KNUCKLE_LONG_AXIS_PARALLEL"] = (decimal)mFilm.KNUCKLE_LONG_AXIS_PARALLEL;
                dr["KNUCKLE_WRAP"] = (decimal)mFilm.KNUCKLE_WRAP;
                dr["KNUCKLE_IMAGE_DISTORTION"] = (decimal)mFilm.KNUCKLE_IMAGE_DISTORTION;
                dr["BASE_ASH_FOG_VALUE"] = (decimal)mFilm.BASE_ASH_FOG_VALUE;
                dr["DIAGNOSE_AREA_VALUE"] = (decimal)mFilm.DIAGNOSE_AREA_VALUE;
                dr["BLANK_EXPOSAL_DENSITY"] = (decimal)mFilm.BLANK_EXPOSAL_DENSITY;
                dr["KNUCKLE_RESOLUTION"] = (decimal)mFilm.KNUCKLE_RESOLUTION;
                dr["KNUCKLE_ARRANGEMENT_FOCUS"] = (decimal)mFilm.KNUCKLE_ARRANGEMENT_FOCUS;
                dr["KNUCKLE_LETTER_ARRANGE"] = (decimal)mFilm.KNUCKLE_LETTER_ARRANGE;
                dr["STATIC_SHADOW"] = (decimal)mFilm.STATIC_SHADOW;
                dr["DIRT"] = (decimal)mFilm.DIRT;
                dr["NICK"] = (decimal)mFilm.NICK;
                dr["ADHIBIT"] = (decimal)mFilm.ADHIBIT;
                dr["WATER_MARK"] = (decimal)mFilm.WATER_MARK;
                dr["FINGER_MARK"] = (decimal)mFilm.FINGER_MARK;
                dr["LIGHT_LEAK"] = (decimal)mFilm.LIGHT_LEAK;

                dr["EXTERNA_SHADOW"] = (decimal)mFilm.EXTERNA_SHADOW;
                dr["TOTAL_SCORE"] = mFilm.TOTAL_SCORE.ToString();
                dr["DISTINCTION"] = Convert.ToInt32(mFilm.DISTINCTION);
            }
            else
            {
                dr["EXAM_ACCESSION_NUM"] = minfor.EXAM_ACCESSION_NUM;
                dr["PATIENT_ID"] = minfor.PATIENT_ID;
                dr["PATIENT_LOCAL_ID"] = minfor.LOCAL_ID;
                dr["PATIENT_NAME"] = minfor.NAME;
                dr["PATIENT_SEX"] = minfor.SEX;
                dr["STUDY_DATE_TIME"] = minfor.STUDY_DATE_TIME;

                dr["KNUCKLE_PROJECTION"] = (decimal)mImage.STERNUM_BREAST;
                dr["KNUCKLE_LONG_AXIS_PARALLEL"] = (decimal)mImage.KNUCKLE_LONG_AXIS_PARALLEL;
                dr["KNUCKLE_WRAP"] = (decimal)mImage.KNUCKLE_WRAP;
                dr["KNUCKLE_IMAGE_DISTORTION"] = (decimal)mImage.KNUCKLE_IMAGE_DISTORTION;
                dr["EXPOSURE_DOSE"] = (decimal)mImage.EXPOSURE_DOSE;
                dr["KNUCKLE_RESOLUTION"] = (decimal)mImage.KNUCKLE_RESOLUTION;
                dr["KNUCKLE_ARRANGEMENT_FOCUS"] = (decimal)mImage.KNUCKLE_ARRANGEMENT_FOCUS;
                dr["FLAG_CONTENT"] = (decimal)mImage.FLAG_CONTENT;
                dr["FLAG_PLACE_ARRANGE"] = (decimal)mImage.FLAG_PLACE_ARRANGE;
                dr["KNUCKLE_DEVICE_SHADOW"] = (decimal)mImage.KNUCKLE_DEVICE_SHADOW;

                dr["EXTERNA_SHADOW"] = (decimal)mImage.EXTERNA_SHADOW;
                dr["TOTAL_SCORE"] = mImage.TOTAL_SCORE.ToString();
                dr["DISTINCTION"] = Convert.ToInt32(mImage.DISTINCTION);
            }
        }

        //使用默认值填充各项控件属性
        private void FillDefalutData(int lvSelectIndex, int flag)
        {
            txt_PATIENT_LOCAL_ID.Text = lv_Sternum.Items[lvSelectIndex].Text;
            txt_PATIENT_NAME.Text = lv_Sternum.Items[lvSelectIndex].SubItems[1].Text;
            txt_PATIENT_SEX.Text = lv_Sternum.Items[lvSelectIndex].SubItems[2].Text;
            txt_STUDY_DATE_TIME.Text = lv_Sternum.Items[lvSelectIndex].SubItems[3].Text;

            if (flag == 0) //默认为显示胶片信息
            {
                DataRow nDr = dtFilm.Rows.Find(lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems["EXAM_ACCESSION_NUM"].Text);
                NowRow = dtFilm.Rows.IndexOf(nDr);
                gb_DI.Enabled = false;
                gb_Film.Enabled = true;

                N_KNUCKLE_PROJECTION.Value = (decimal)nDr["KNUCKLE_PROJECTION"];
                N_KNUCKLE_LONG_AXIS_PARALLEL.Value = (decimal)nDr["KNUCKLE_LONG_AXIS_PARALLEL"];
                N_KNUCKLE_WRAP.Value = (decimal)nDr["KNUCKLE_WRAP"];
                N_KNUCKLE_IMAGE_DISTORTION.Value = (decimal)nDr["KNUCKLE_IMAGE_DISTORTION"];
                N_BASE_ASH_FOG_VALUE.Value = (decimal)nDr["BASE_ASH_FOG_VALUE"];
                N_DIAGNOSE_AREA_VALUE.Value = (decimal)nDr["DIAGNOSE_AREA_VALUE"];
                N_BLANK_EXPOSAL_DENSITY.Value = (decimal)nDr["BLANK_EXPOSAL_DENSITY"];
                N_KNUCKLE_RESOLUTION.Value = (decimal)nDr["KNUCKLE_RESOLUTION"];
                N_KNUCKLE_ARRANGEMENT_FOCUS.Value = (decimal)nDr["KNUCKLE_ARRANGEMENT_FOCUS"];
                N_KNUCKLE_LETTER_ARRANGE.Value = (decimal)nDr["KNUCKLE_LETTER_ARRANGE"];
                N_STATIC_SHADOW.Value = (decimal)nDr["STATIC_SHADOW"];
                N_DIRT.Value = (decimal)nDr["DIRT"];
                N_NICK.Value = (decimal)nDr["NICK"];
                N_ADHIBIT.Value = (decimal)nDr["ADHIBIT"];
                N_WATER_MARK.Value = (decimal)nDr["WATER_MARK"];
                N_FINGER_MARK.Value = (decimal)nDr["FINGER_MARK"];
                N_LIGHT_LEAK.Value = (decimal)nDr["LIGHT_LEAK"];

                nud_EXTERNA_SHADOW.Value = (decimal)nDr["EXTERNA_SHADOW"];
                txt_TOTAL_SCORE.Text = nDr["TOTAL_SCORE"].ToString();
                cmb_DISTINCTION.SelectedIndex = Convert.ToInt32(nDr["DISTINCTION"]) - 1;
            }
            else
            {
                DataRow nDr1 = dtImage.Rows.Find(lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems["EXAM_ACCESSION_NUM"].Text);
                NowRow = dtImage.Rows.IndexOf(nDr1);
                gb_DI.Enabled = true;
                gb_Film.Enabled = false;

                D_KNUCKLE_PROJECTION.Value = (decimal)nDr1["KNUCKLE_PROJECTION"];
                D_KNUCKLE_LONG_AXIS_PARALLEL.Value = (decimal)nDr1["KNUCKLE_LONG_AXIS_PARALLEL"];
                D_KNUCKLE_WRAP.Value = (decimal)nDr1["KNUCKLE_WRAP"];
                D_KNUCKLE_IMAGE_DISTORTION.Value = (decimal)nDr1["KNUCKLE_IMAGE_DISTORTION"];
                D_EXPOSURE_DOSE.Value = (decimal)nDr1["EXPOSURE_DOSE"];
                D_KNUCKLE_RESOLUTION.Value = (decimal)nDr1["KNUCKLE_RESOLUTION"];
                D_KNUCKLE_ARRANGEMENT_FOCUS.Value = (decimal)nDr1["KNUCKLE_ARRANGEMENT_FOCUS"];
                D_FLAG_CONTENT.Value = (decimal)nDr1["FLAG_CONTENT"];
                D_FLAG_PLACE_ARRANGE.Value = (decimal)nDr1["FLAG_PLACE_ARRANGE"];
                D_KNUCKLE_DEVICE_SHADOW.Value = (decimal)nDr1["KNUCKLE_DEVICE_SHADOW"];

                nud_EXTERNA_SHADOW.Value = (decimal)nDr1["EXTERNA_SHADOW"];
                txt_TOTAL_SCORE.Text = nDr1["TOTAL_SCORE"].ToString();
                cmb_DISTINCTION.SelectedIndex = Convert.ToInt32(nDr1["DISTINCTION"]) - 1;
            }
        }

        private void QC_Knuckle_Load(object sender, EventArgs e)
        {
            this.btn_FunName.Text = this.Text;
            cmb_Style.Items.Clear();
            cmb_Style.Items.Add("胶片图像");
            cmb_Style.Items.Add("数字图像");

            lv_Sternum.TopItem.Selected = true;
            cmb_Style.SelectedIndex = FirstTopType;
            lv_Sternum.Focus();
            lv_Sternum.TopItem.Focused = true;
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

            if (cmb_Style.SelectedIndex == 0)
            {
                DataRow dr = dtImage.Rows.Find(lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems["EXAM_ACCESSION_NUM"].Text);
                if (dr != null)
                {
                    dtImage.Rows.Remove(dr);
                    DataRow ndr = dtFilm.NewRow();
                    FillDataTableFromClass(ref ndr, minf, 0);
                    dtFilm.Rows.Add(ndr);
                }
                FillDefalutData(lv_Sternum.SelectedItems[0].Index, 0);
            }
            else
            {
                DataRow dr1 = dtFilm.Rows.Find(lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems["EXAM_ACCESSION_NUM"].Text);
                if (dr1 != null)
                {
                    dtFilm.Rows.Remove(dr1);
                    DataRow ndr1 = dtImage.NewRow();
                    FillDataTableFromClass(ref ndr1, minf, 1);
                    dtImage.Rows.Add(ndr1);
                }
                FillDefalutData(lv_Sternum.SelectedItems[0].Index, 1);
            }
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

            if (cmb_Style.SelectedIndex == 0)
            {
                DataRow dr = dtFilm.Rows.Find(lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems["EXAM_ACCESSION_NUM"].Text);
                if (dr != null)
                {
                    FillDataTableFromClass(ref dr, minf, 0);
                }
                FillDefalutData(lv_Sternum.SelectedItems[0].Index, 0);
            }
            else
            {
                DataRow dr1 = dtImage.Rows.Find(lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems["EXAM_ACCESSION_NUM"].Text);
                if (dr1 != null)
                {
                    FillDataTableFromClass(ref dr1, minf, 1);
                }
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

            DataRow dr = dtFilm.Rows.Find(lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems["EXAM_ACCESSION_NUM"].Text);
            if (dr != null)
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

            DataRow dr1 = dtImage.Rows.Find(lv_Sternum.Items[lv_Sternum.SelectedItems[0].Index].SubItems["EXAM_ACCESSION_NUM"].Text);
            if (dr1 != null)
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

        #region  胶片属性控件值改变
        private void N_KNUCKLE_PROJECTION_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["KNUCKLE_PROJECTION"] = N_KNUCKLE_PROJECTION.Value;
            decimal dcl = N_KNUCKLE_PROJECTION.Value + N_KNUCKLE_LONG_AXIS_PARALLEL.Value + N_KNUCKLE_WRAP.Value + N_KNUCKLE_IMAGE_DISTORTION.Value +
                        N_BASE_ASH_FOG_VALUE.Value + N_DIAGNOSE_AREA_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                        N_KNUCKLE_RESOLUTION.Value + N_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        N_KNUCKLE_LETTER_ARRANGE.Value + N_STATIC_SHADOW.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_KNUCKLE_LONG_AXIS_PARALLEL_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["KNUCKLE_LONG_AXIS_PARALLEL"] = N_KNUCKLE_LONG_AXIS_PARALLEL.Value;
            decimal dcl = N_KNUCKLE_PROJECTION.Value + N_KNUCKLE_LONG_AXIS_PARALLEL.Value + N_KNUCKLE_WRAP.Value + N_KNUCKLE_IMAGE_DISTORTION.Value +
                        N_BASE_ASH_FOG_VALUE.Value + N_DIAGNOSE_AREA_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                        N_KNUCKLE_RESOLUTION.Value + N_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        N_KNUCKLE_LETTER_ARRANGE.Value + N_STATIC_SHADOW.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_KNUCKLE_WRAP_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["KNUCKLE_WRAP"] = N_KNUCKLE_WRAP.Value;
            decimal dcl = N_KNUCKLE_PROJECTION.Value + N_KNUCKLE_LONG_AXIS_PARALLEL.Value + N_KNUCKLE_WRAP.Value + N_KNUCKLE_IMAGE_DISTORTION.Value +
                        N_BASE_ASH_FOG_VALUE.Value + N_DIAGNOSE_AREA_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                        N_KNUCKLE_RESOLUTION.Value + N_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        N_KNUCKLE_LETTER_ARRANGE.Value + N_STATIC_SHADOW.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_KNUCKLE_IMAGE_DISTORTION_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["KNUCKLE_IMAGE_DISTORTION"] = N_KNUCKLE_IMAGE_DISTORTION.Value;
            decimal dcl = N_KNUCKLE_PROJECTION.Value + N_KNUCKLE_LONG_AXIS_PARALLEL.Value + N_KNUCKLE_WRAP.Value + N_KNUCKLE_IMAGE_DISTORTION.Value +
                        N_BASE_ASH_FOG_VALUE.Value + N_DIAGNOSE_AREA_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                        N_KNUCKLE_RESOLUTION.Value + N_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        N_KNUCKLE_LETTER_ARRANGE.Value + N_STATIC_SHADOW.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_BASE_ASH_FOG_VALUE_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["BASE_ASH_FOG_VALUE"] = N_BASE_ASH_FOG_VALUE.Value;
            decimal dcl = N_KNUCKLE_PROJECTION.Value + N_KNUCKLE_LONG_AXIS_PARALLEL.Value + N_KNUCKLE_WRAP.Value + N_KNUCKLE_IMAGE_DISTORTION.Value +
                        N_BASE_ASH_FOG_VALUE.Value + N_DIAGNOSE_AREA_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                        N_KNUCKLE_RESOLUTION.Value + N_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        N_KNUCKLE_LETTER_ARRANGE.Value + N_STATIC_SHADOW.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_DIAGNOSE_AREA_VALUE_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["DIAGNOSE_AREA_VALUE"] = N_DIAGNOSE_AREA_VALUE.Value;
            decimal dcl = N_KNUCKLE_PROJECTION.Value + N_KNUCKLE_LONG_AXIS_PARALLEL.Value + N_KNUCKLE_WRAP.Value + N_KNUCKLE_IMAGE_DISTORTION.Value +
                        N_BASE_ASH_FOG_VALUE.Value + N_DIAGNOSE_AREA_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                        N_KNUCKLE_RESOLUTION.Value + N_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        N_KNUCKLE_LETTER_ARRANGE.Value + N_STATIC_SHADOW.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_BLANK_EXPOSAL_DENSITY_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["BLANK_EXPOSAL_DENSITY"] = N_BLANK_EXPOSAL_DENSITY.Value;
            decimal dcl = N_KNUCKLE_PROJECTION.Value + N_KNUCKLE_LONG_AXIS_PARALLEL.Value + N_KNUCKLE_WRAP.Value + N_KNUCKLE_IMAGE_DISTORTION.Value +
                        N_BASE_ASH_FOG_VALUE.Value + N_DIAGNOSE_AREA_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                        N_KNUCKLE_RESOLUTION.Value + N_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        N_KNUCKLE_LETTER_ARRANGE.Value + N_STATIC_SHADOW.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_KNUCKLE_RESOLUTION_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["KNUCKLE_RESOLUTION"] = N_KNUCKLE_RESOLUTION.Value;
            decimal dcl = N_KNUCKLE_PROJECTION.Value + N_KNUCKLE_LONG_AXIS_PARALLEL.Value + N_KNUCKLE_WRAP.Value + N_KNUCKLE_IMAGE_DISTORTION.Value +
                        N_BASE_ASH_FOG_VALUE.Value + N_DIAGNOSE_AREA_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                        N_KNUCKLE_RESOLUTION.Value + N_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        N_KNUCKLE_LETTER_ARRANGE.Value + N_STATIC_SHADOW.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_KNUCKLE_ARRANGEMENT_FOCUS_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["KNUCKLE_ARRANGEMENT_FOCUS"] = N_KNUCKLE_ARRANGEMENT_FOCUS.Value;
            decimal dcl = N_KNUCKLE_PROJECTION.Value + N_KNUCKLE_LONG_AXIS_PARALLEL.Value + N_KNUCKLE_WRAP.Value + N_KNUCKLE_IMAGE_DISTORTION.Value +
                        N_BASE_ASH_FOG_VALUE.Value + N_DIAGNOSE_AREA_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                        N_KNUCKLE_RESOLUTION.Value + N_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        N_KNUCKLE_LETTER_ARRANGE.Value + N_STATIC_SHADOW.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_KNUCKLE_LETTER_ARRANGE_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["KNUCKLE_LETTER_ARRANGE"] = N_KNUCKLE_LETTER_ARRANGE.Value;
            decimal dcl = N_KNUCKLE_PROJECTION.Value + N_KNUCKLE_LONG_AXIS_PARALLEL.Value + N_KNUCKLE_WRAP.Value + N_KNUCKLE_IMAGE_DISTORTION.Value +
                        N_BASE_ASH_FOG_VALUE.Value + N_DIAGNOSE_AREA_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                        N_KNUCKLE_RESOLUTION.Value + N_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        N_KNUCKLE_LETTER_ARRANGE.Value + N_STATIC_SHADOW.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_STATIC_SHADOW_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["STATIC_SHADOW"] = N_STATIC_SHADOW.Value;
            decimal dcl = N_KNUCKLE_PROJECTION.Value + N_KNUCKLE_LONG_AXIS_PARALLEL.Value + N_KNUCKLE_WRAP.Value + N_KNUCKLE_IMAGE_DISTORTION.Value +
                        N_BASE_ASH_FOG_VALUE.Value + N_DIAGNOSE_AREA_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                        N_KNUCKLE_RESOLUTION.Value + N_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        N_KNUCKLE_LETTER_ARRANGE.Value + N_STATIC_SHADOW.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_DIRT_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["DIRT"] = N_DIRT.Value;
            decimal dcl = N_KNUCKLE_PROJECTION.Value + N_KNUCKLE_LONG_AXIS_PARALLEL.Value + N_KNUCKLE_WRAP.Value + N_KNUCKLE_IMAGE_DISTORTION.Value +
                        N_BASE_ASH_FOG_VALUE.Value + N_DIAGNOSE_AREA_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                        N_KNUCKLE_RESOLUTION.Value + N_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        N_KNUCKLE_LETTER_ARRANGE.Value + N_STATIC_SHADOW.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_NICK_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["NICK"] = N_NICK.Value;
            decimal dcl = N_KNUCKLE_PROJECTION.Value + N_KNUCKLE_LONG_AXIS_PARALLEL.Value + N_KNUCKLE_WRAP.Value + N_KNUCKLE_IMAGE_DISTORTION.Value +
                        N_BASE_ASH_FOG_VALUE.Value + N_DIAGNOSE_AREA_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                        N_KNUCKLE_RESOLUTION.Value + N_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        N_KNUCKLE_LETTER_ARRANGE.Value + N_STATIC_SHADOW.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_ADHIBIT_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["ADHIBIT"] = N_ADHIBIT.Value;
            decimal dcl = N_KNUCKLE_PROJECTION.Value + N_KNUCKLE_LONG_AXIS_PARALLEL.Value + N_KNUCKLE_WRAP.Value + N_KNUCKLE_IMAGE_DISTORTION.Value +
                        N_BASE_ASH_FOG_VALUE.Value + N_DIAGNOSE_AREA_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                        N_KNUCKLE_RESOLUTION.Value + N_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        N_KNUCKLE_LETTER_ARRANGE.Value + N_STATIC_SHADOW.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_WATER_MARK_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["WATER_MARK"] = N_WATER_MARK.Value;
            decimal dcl = N_KNUCKLE_PROJECTION.Value + N_KNUCKLE_LONG_AXIS_PARALLEL.Value + N_KNUCKLE_WRAP.Value + N_KNUCKLE_IMAGE_DISTORTION.Value +
                        N_BASE_ASH_FOG_VALUE.Value + N_DIAGNOSE_AREA_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                        N_KNUCKLE_RESOLUTION.Value + N_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        N_KNUCKLE_LETTER_ARRANGE.Value + N_STATIC_SHADOW.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_FINGER_MARK_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["FINGER_MARK"] = N_FINGER_MARK.Value;
            decimal dcl = N_KNUCKLE_PROJECTION.Value + N_KNUCKLE_LONG_AXIS_PARALLEL.Value + N_KNUCKLE_WRAP.Value + N_KNUCKLE_IMAGE_DISTORTION.Value +
                        N_BASE_ASH_FOG_VALUE.Value + N_DIAGNOSE_AREA_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                        N_KNUCKLE_RESOLUTION.Value + N_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        N_KNUCKLE_LETTER_ARRANGE.Value + N_STATIC_SHADOW.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_LIGHT_LEAK_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["LIGHT_LEAK"] = N_LIGHT_LEAK.Value;
            decimal dcl = N_KNUCKLE_PROJECTION.Value + N_KNUCKLE_LONG_AXIS_PARALLEL.Value + N_KNUCKLE_WRAP.Value + N_KNUCKLE_IMAGE_DISTORTION.Value +
                        N_BASE_ASH_FOG_VALUE.Value + N_DIAGNOSE_AREA_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                        N_KNUCKLE_RESOLUTION.Value + N_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        N_KNUCKLE_LETTER_ARRANGE.Value + N_STATIC_SHADOW.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }
        #endregion

        private void nud_EXTERNA_SHADOW_ValueChanged(object sender, EventArgs e)
        {
            decimal dcl = 0;
            if (cmb_Style.SelectedIndex == 0)
            {
                dtFilm.Rows[NowRow]["EXTERNA_SHADOW"] = nud_EXTERNA_SHADOW.Value;
                dcl = N_KNUCKLE_PROJECTION.Value + N_KNUCKLE_LONG_AXIS_PARALLEL.Value + N_KNUCKLE_WRAP.Value + N_KNUCKLE_IMAGE_DISTORTION.Value +
                        N_BASE_ASH_FOG_VALUE.Value + N_DIAGNOSE_AREA_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value +
                        N_KNUCKLE_RESOLUTION.Value + N_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        N_KNUCKLE_LETTER_ARRANGE.Value + N_STATIC_SHADOW.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value +
                        nud_EXTERNA_SHADOW.Value;
            }
            else
            {
                dtImage.Rows[NowRow]["EXTERNA_SHADOW"] = nud_EXTERNA_SHADOW.Value;
                dcl = D_KNUCKLE_PROJECTION.Value + D_KNUCKLE_LONG_AXIS_PARALLEL.Value + D_KNUCKLE_WRAP.Value + D_KNUCKLE_IMAGE_DISTORTION.Value +
                        D_EXPOSURE_DOSE.Value +
                        D_KNUCKLE_RESOLUTION.Value + D_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        D_FLAG_CONTENT.Value + D_FLAG_PLACE_ARRANGE.Value + D_KNUCKLE_DEVICE_SHADOW.Value +
                        nud_EXTERNA_SHADOW.Value;
            }

            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void txt_TOTAL_SCORE_TextChanged(object sender, EventArgs e)
        {
            if (cmb_Style.SelectedIndex == 0)
                dtFilm.Rows[NowRow]["TOTAL_SCORE"] = Convert.ToDecimal(txt_TOTAL_SCORE.Text);
            else
                dtImage.Rows[NowRow]["TOTAL_SCORE"] = Convert.ToDecimal(txt_TOTAL_SCORE.Text);
        }

        private void cmb_DISTINCTION_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Style.SelectedIndex == 0)
                dtFilm.Rows[NowRow]["DISTINCTION"] = cmb_DISTINCTION.SelectedIndex + 1;
            else
                dtImage.Rows[NowRow]["DISTINCTION"] = cmb_DISTINCTION.SelectedIndex + 1;
        }

        #region 数据图像属性值改变
        private void D_KNUCKLE_PROJECTION_ValueChanged(object sender, EventArgs e)
        {
            dtImage.Rows[NowRow]["KNUCKLE_PROJECTION"] = D_KNUCKLE_PROJECTION.Value;
            decimal dcl = D_KNUCKLE_PROJECTION.Value + D_KNUCKLE_LONG_AXIS_PARALLEL.Value + D_KNUCKLE_WRAP.Value + D_KNUCKLE_IMAGE_DISTORTION.Value +
                        D_EXPOSURE_DOSE.Value +
                        D_KNUCKLE_RESOLUTION.Value + D_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        D_FLAG_CONTENT.Value + D_FLAG_PLACE_ARRANGE.Value + D_KNUCKLE_DEVICE_SHADOW.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_KNUCKLE_LONG_AXIS_PARALLEL_ValueChanged(object sender, EventArgs e)
        {
            dtImage.Rows[NowRow]["KNUCKLE_LONG_AXIS_PARALLEL"] = D_KNUCKLE_LONG_AXIS_PARALLEL.Value;
            decimal dcl = D_KNUCKLE_PROJECTION.Value + D_KNUCKLE_LONG_AXIS_PARALLEL.Value + D_KNUCKLE_WRAP.Value + D_KNUCKLE_IMAGE_DISTORTION.Value +
                        D_EXPOSURE_DOSE.Value +
                        D_KNUCKLE_RESOLUTION.Value + D_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        D_FLAG_CONTENT.Value + D_FLAG_PLACE_ARRANGE.Value + D_KNUCKLE_DEVICE_SHADOW.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_KNUCKLE_WRAP_ValueChanged(object sender, EventArgs e)
        {
            dtImage.Rows[NowRow]["KNUCKLE_WRAP"] = D_KNUCKLE_WRAP.Value;
            decimal dcl = D_KNUCKLE_PROJECTION.Value + D_KNUCKLE_LONG_AXIS_PARALLEL.Value + D_KNUCKLE_WRAP.Value + D_KNUCKLE_IMAGE_DISTORTION.Value +
                        D_EXPOSURE_DOSE.Value +
                        D_KNUCKLE_RESOLUTION.Value + D_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        D_FLAG_CONTENT.Value + D_FLAG_PLACE_ARRANGE.Value + D_KNUCKLE_DEVICE_SHADOW.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_KNUCKLE_IMAGE_DISTORTION_ValueChanged(object sender, EventArgs e)
        {
            dtImage.Rows[NowRow]["KNUCKLE_IMAGE_DISTORTION"] = D_KNUCKLE_IMAGE_DISTORTION.Value;
            decimal dcl = D_KNUCKLE_PROJECTION.Value + D_KNUCKLE_LONG_AXIS_PARALLEL.Value + D_KNUCKLE_WRAP.Value + D_KNUCKLE_IMAGE_DISTORTION.Value +
                        D_EXPOSURE_DOSE.Value +
                        D_KNUCKLE_RESOLUTION.Value + D_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        D_FLAG_CONTENT.Value + D_FLAG_PLACE_ARRANGE.Value + D_KNUCKLE_DEVICE_SHADOW.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_EXPOSURE_DOSE_ValueChanged(object sender, EventArgs e)
        {
            dtImage.Rows[NowRow]["EXPOSURE_DOSE"] = D_EXPOSURE_DOSE.Value;
            decimal dcl = D_KNUCKLE_PROJECTION.Value + D_KNUCKLE_LONG_AXIS_PARALLEL.Value + D_KNUCKLE_WRAP.Value + D_KNUCKLE_IMAGE_DISTORTION.Value +
                        D_EXPOSURE_DOSE.Value +
                        D_KNUCKLE_RESOLUTION.Value + D_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        D_FLAG_CONTENT.Value + D_FLAG_PLACE_ARRANGE.Value + D_KNUCKLE_DEVICE_SHADOW.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_KNUCKLE_RESOLUTION_ValueChanged(object sender, EventArgs e)
        {
            dtImage.Rows[NowRow]["KNUCKLE_RESOLUTION"] = D_KNUCKLE_RESOLUTION.Value;
            decimal dcl = D_KNUCKLE_PROJECTION.Value + D_KNUCKLE_LONG_AXIS_PARALLEL.Value + D_KNUCKLE_WRAP.Value + D_KNUCKLE_IMAGE_DISTORTION.Value +
                        D_EXPOSURE_DOSE.Value +
                        D_KNUCKLE_RESOLUTION.Value + D_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        D_FLAG_CONTENT.Value + D_FLAG_PLACE_ARRANGE.Value + D_KNUCKLE_DEVICE_SHADOW.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_KNUCKLE_ARRANGEMENT_FOCUS_ValueChanged(object sender, EventArgs e)
        {
            dtImage.Rows[NowRow]["KNUCKLE_ARRANGEMENT_FOCUS"] = D_KNUCKLE_ARRANGEMENT_FOCUS.Value;
            decimal dcl = D_KNUCKLE_PROJECTION.Value + D_KNUCKLE_LONG_AXIS_PARALLEL.Value + D_KNUCKLE_WRAP.Value + D_KNUCKLE_IMAGE_DISTORTION.Value +
                        D_EXPOSURE_DOSE.Value +
                        D_KNUCKLE_RESOLUTION.Value + D_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        D_FLAG_CONTENT.Value + D_FLAG_PLACE_ARRANGE.Value + D_KNUCKLE_DEVICE_SHADOW.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_FLAG_CONTENT_ValueChanged(object sender, EventArgs e)
        {
            dtImage.Rows[NowRow]["FLAG_CONTENT"] = D_FLAG_CONTENT.Value;
            decimal dcl = D_KNUCKLE_PROJECTION.Value + D_KNUCKLE_LONG_AXIS_PARALLEL.Value + D_KNUCKLE_WRAP.Value + D_KNUCKLE_IMAGE_DISTORTION.Value +
                        D_EXPOSURE_DOSE.Value +
                        D_KNUCKLE_RESOLUTION.Value + D_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        D_FLAG_CONTENT.Value + D_FLAG_PLACE_ARRANGE.Value + D_KNUCKLE_DEVICE_SHADOW.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_FLAG_PLACE_ARRANGE_ValueChanged(object sender, EventArgs e)
        {
            dtImage.Rows[NowRow]["FLAG_PLACE_ARRANGE"] = D_FLAG_PLACE_ARRANGE.Value;
            decimal dcl = D_KNUCKLE_PROJECTION.Value + D_KNUCKLE_LONG_AXIS_PARALLEL.Value + D_KNUCKLE_WRAP.Value + D_KNUCKLE_IMAGE_DISTORTION.Value +
                        D_EXPOSURE_DOSE.Value +
                        D_KNUCKLE_RESOLUTION.Value + D_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        D_FLAG_CONTENT.Value + D_FLAG_PLACE_ARRANGE.Value + D_KNUCKLE_DEVICE_SHADOW.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_KNUCKLE_DEVICE_SHADOW_ValueChanged(object sender, EventArgs e)
        {
            dtImage.Rows[NowRow]["KNUCKLE_DEVICE_SHADOW"] = D_KNUCKLE_DEVICE_SHADOW.Value;
            decimal dcl = D_KNUCKLE_PROJECTION.Value + D_KNUCKLE_LONG_AXIS_PARALLEL.Value + D_KNUCKLE_WRAP.Value + D_KNUCKLE_IMAGE_DISTORTION.Value +
                        D_EXPOSURE_DOSE.Value +
                        D_KNUCKLE_RESOLUTION.Value + D_KNUCKLE_ARRANGEMENT_FOCUS.Value +
                        D_FLAG_CONTENT.Value + D_FLAG_PLACE_ARRANGE.Value + D_KNUCKLE_DEVICE_SHADOW.Value +
                        nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }
        #endregion

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            for (int i = 0; i < dtFilm.Rows.Count; i++)
            {
                if (dtFilm.Rows[i]["EXAM_ACCESSION_NUM"].ToString() == "" || dtFilm.Rows[i]["PATIENT_LOCAL_ID"].ToString() == "") continue;

                MQcFilm mf = new MQcFilm();
                mf.EXAM_ACCESSION_NUM = dtFilm.Rows[i]["EXAM_ACCESSION_NUM"].ToString();
                mf.PATIENT_ID = dtFilm.Rows[i]["PATIENT_ID"].ToString();
                mf.PATIENT_LOCAL_ID = dtFilm.Rows[i]["PATIENT_LOCAL_ID"].ToString();
                mf.PATIENT_NAME = dtFilm.Rows[i]["PATIENT_NAME"].ToString();
                mf.PATIENT_SEX = dtFilm.Rows[i]["PATIENT_SEX"].ToString();
                mf.STUDY_DATE_TIME = Convert.ToDateTime(dtFilm.Rows[i]["STUDY_DATE_TIME"]);
                mf.QC_DATE = DateTime.Now;

                mf.KNUCKLE_PROJECTION = (decimal)dtFilm.Rows[i]["KNUCKLE_PROJECTION"];
                mf.KNUCKLE_LONG_AXIS_PARALLEL = (decimal)dtFilm.Rows[i]["KNUCKLE_LONG_AXIS_PARALLEL"];
                mf.KNUCKLE_WRAP = (decimal)dtFilm.Rows[i]["KNUCKLE_WRAP"];
                mf.KNUCKLE_IMAGE_DISTORTION = (decimal)dtFilm.Rows[i]["KNUCKLE_IMAGE_DISTORTION"];
                mf.BASE_ASH_FOG_VALUE = (decimal)dtFilm.Rows[i]["BASE_ASH_FOG_VALUE"];
                mf.DIAGNOSE_AREA_VALUE = (decimal)dtFilm.Rows[i]["DIAGNOSE_AREA_VALUE"];
                mf.BLANK_EXPOSAL_DENSITY = (decimal)dtFilm.Rows[i]["BLANK_EXPOSAL_DENSITY"];
                mf.KNUCKLE_RESOLUTION = (decimal)dtFilm.Rows[i]["KNUCKLE_RESOLUTION"];
                mf.KNUCKLE_ARRANGEMENT_FOCUS = (decimal)dtFilm.Rows[i]["KNUCKLE_ARRANGEMENT_FOCUS"];
                mf.KNUCKLE_LETTER_ARRANGE = (decimal)dtFilm.Rows[i]["KNUCKLE_LETTER_ARRANGE"];
                mf.STATIC_SHADOW = (decimal)dtFilm.Rows[i]["STATIC_SHADOW"];
                mf.DIRT = (decimal)dtFilm.Rows[i]["DIRT"];
                mf.NICK = (decimal)dtFilm.Rows[i]["NICK"];
                mf.ADHIBIT = (decimal)dtFilm.Rows[i]["ADHIBIT"];
                mf.WATER_MARK = (decimal)dtFilm.Rows[i]["WATER_MARK"];
                mf.FINGER_MARK = (decimal)dtFilm.Rows[i]["FINGER_MARK"];
                mf.LIGHT_LEAK = (decimal)dtFilm.Rows[i]["LIGHT_LEAK"];

                mf.EXTERNA_SHADOW = (decimal)dtFilm.Rows[i]["EXTERNA_SHADOW"];
                mf.TOTAL_SCORE = Convert.ToDecimal(dtFilm.Rows[i]["TOTAL_SCORE"]);
                mf.DISTINCTION = Convert.ToInt32(dtFilm.Rows[i]["DISTINCTION"]);

                mf.STERNUM_BREAST = null;
                mf.UGI_PROJECTION_CASE = null;      //将胸部正位片,上消化道，静脉的标志清空
                mf.IVP_FILM_POSTURE_PLACE = null;
                ht.Add(i, mf);
            }

            Hashtable ht2 = new Hashtable();
            for (int m = 0; m < dtImage.Rows.Count; m++)
            {
                if (dtImage.Rows[m]["EXAM_ACCESSION_NUM"].ToString() == "" || dtImage.Rows[m]["PATIENT_LOCAL_ID"].ToString() == "") continue;

                MQcDigitalImage mi = new MQcDigitalImage();
                mi.EXAM_ACCESSION_NUM = dtImage.Rows[m]["EXAM_ACCESSION_NUM"].ToString();
                mi.PATIENT_ID = dtImage.Rows[m]["PATIENT_ID"].ToString();
                mi.PATIENT_LOCAL_ID = dtImage.Rows[m]["PATIENT_LOCAL_ID"].ToString();
                mi.PATIENT_NAME = dtImage.Rows[m]["PATIENT_NAME"].ToString();
                mi.PATIENT_SEX = dtImage.Rows[m]["PATIENT_SEX"].ToString();
                mi.STUDY_DATE_TIME = Convert.ToDateTime(dtImage.Rows[m]["STUDY_DATE_TIME"]);
                mi.QC_DATE = DateTime.Now;

                mi.KNUCKLE_PROJECTION = (decimal)dtImage.Rows[m]["KNUCKLE_PROJECTION"];
                mi.KNUCKLE_LONG_AXIS_PARALLEL = (decimal)dtImage.Rows[m]["KNUCKLE_LONG_AXIS_PARALLEL"];
                mi.KNUCKLE_WRAP = (decimal)dtImage.Rows[m]["KNUCKLE_WRAP"];
                mi.KNUCKLE_IMAGE_DISTORTION = (decimal)dtImage.Rows[m]["KNUCKLE_IMAGE_DISTORTION"];
                mi.EXPOSURE_DOSE = (decimal)dtImage.Rows[m]["EXPOSURE_DOSE"];
                mi.KNUCKLE_RESOLUTION = (decimal)dtImage.Rows[m]["KNUCKLE_RESOLUTION"];
                mi.KNUCKLE_ARRANGEMENT_FOCUS = (decimal)dtImage.Rows[m]["KNUCKLE_ARRANGEMENT_FOCUS"];
                mi.FLAG_CONTENT = (decimal)dtImage.Rows[m]["FLAG_CONTENT"];
                mi.FLAG_PLACE_ARRANGE = (decimal)dtImage.Rows[m]["FLAG_PLACE_ARRANGE"];
                mi.KNUCKLE_DEVICE_SHADOW = (decimal)dtImage.Rows[m]["KNUCKLE_DEVICE_SHADOW"];

                mi.EXTERNA_SHADOW = (decimal)dtImage.Rows[m]["EXTERNA_SHADOW"];
                mi.TOTAL_SCORE = Convert.ToDecimal(dtImage.Rows[m]["TOTAL_SCORE"]);
                mi.DISTINCTION = Convert.ToInt32(dtImage.Rows[m]["DISTINCTION"]);

                mi.STERNUM_BREAST = null;
                mi.UGI_PROJECTION_CASE = null;      //将胸部正位片,上消化道，静脉的标志清空
                mi.IVP_FILM_POSTURE_PLACE = null;
                ht2.Add(m, mi);
            }

            int j = 0;
            int n = 0;
            if (isModify)
            {
                if (ht.Count > 0)
                    j = bFilm.UpdateMore(ht);
                if (ht2.Count > 0)
                    n = bdgImg.UpdateMore(ht2);
                if (j >= 0 && n >= 0)
                    MessageBoxEx.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBoxEx.Show("修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (ht.Count > 0)
                    j = bFilm.AddMore(ht);
                if (ht2.Count > 0)
                    n = bdgImg.AddMore(ht2);

                if (j >= 0 && n >= 0)
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
            rptDocument.Load(path + "CR_Knuckle.rpt");
            int DISTINCTION_1 = 0, DISTINCTION_2 = 0, DISTINCTION_3 = 0;
            decimal Total_Score_All = 0;

            DataTable dtSernum = MeregeDataTableData(ref DISTINCTION_1,ref DISTINCTION_2,ref DISTINCTION_3,ref Total_Score_All);
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
            this.crv_Sternum.Controls[0].Controls[0].Controls[0].Text = "膝关节";
        }

        //将胶片表和数据图像表里的记录合并到一张新表中
        private DataTable MeregeDataTableData(ref int DISTINCTION_1, ref int DISTINCTION_2, ref int DISTINCTION_3, ref decimal Total_Score_All)
        {
            string s = "";
            DataTable dtTpTable = new DataTable();
            dtTpTable.Columns.Add(new DataColumn("EXAM_ACCESSION_NUM", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("PATIENT_LOCAL_ID", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("QC_DATE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("PATIENT_ID", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("PATIENT_NAME", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("PATIENT_SEX", typeof(string)));

            dtTpTable.Columns.Add(new DataColumn("STUDY_DATE_TIME", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("KNUCKLE_PROJECTION", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("KNUCKLE_LONG_AXIS_PARALLEL", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("KNUCKLE_WRAP", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("KNUCKLE_IMAGE_DISTORTION", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("KNUCKLE_RESOLUTION", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("KNUCKLE_ARRANGEMENT_FOCUS", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("KNUCKLE_LETTER_ARRANGE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("BASE_ASH_FOG_VALUE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DIAGNOSE_AREA_VALUE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("BLANK_EXPOSAL_DENSITY", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DIRT", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("NICK", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("ADHIBIT", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("WATER_MARK", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("FINGER_MARK", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("LIGHT_LEAK", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("STATIC_SHADOW", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("EXTERNA_SHADOW", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("TOTAL_SCORE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DISTINCTION", typeof(string)));
            //dtTpTable.Columns.Add(new DataColumn("NUMBER_KEY", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("D_EXPOSURE_DOSE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("D_FLAG_CONTENT", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("D_FLAG_PLACE_ARRANGE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("D_DEVICE_SHADOW", typeof(string)));

            DataRow nDr = dtTpTable.NewRow();

            foreach (DataRow dr in dtFilm.Rows)
            {
                nDr["PATIENT_LOCAL_ID"] += dr["PATIENT_LOCAL_ID"].ToString().PadRight(7, ' ');

                nDr["KNUCKLE_PROJECTION"] += dr["KNUCKLE_PROJECTION"].ToString().PadRight(6, ' ');
                nDr["KNUCKLE_LONG_AXIS_PARALLEL"] += dr["KNUCKLE_LONG_AXIS_PARALLEL"].ToString().PadRight(6, ' ');
                nDr["KNUCKLE_WRAP"] += dr["KNUCKLE_WRAP"].ToString().PadRight(6, ' ');
                nDr["KNUCKLE_IMAGE_DISTORTION"] += dr["KNUCKLE_IMAGE_DISTORTION"].ToString().PadRight(6, ' ');
                nDr["KNUCKLE_RESOLUTION"] += dr["KNUCKLE_RESOLUTION"].ToString().PadRight(6, ' ');
                nDr["KNUCKLE_ARRANGEMENT_FOCUS"] += dr["KNUCKLE_ARRANGEMENT_FOCUS"].ToString().PadRight(6, ' ');
                nDr["KNUCKLE_LETTER_ARRANGE"] += dr["KNUCKLE_LETTER_ARRANGE"].ToString().PadRight(6, ' ');
                nDr["BASE_ASH_FOG_VALUE"] += dr["BASE_ASH_FOG_VALUE"].ToString().PadRight(6, ' ');
                nDr["DIAGNOSE_AREA_VALUE"] += dr["DIAGNOSE_AREA_VALUE"].ToString().PadRight(6, ' ');
                nDr["BLANK_EXPOSAL_DENSITY"] += dr["BLANK_EXPOSAL_DENSITY"].ToString().PadRight(6, ' ');
                nDr["DIRT"] += dr["DIRT"].ToString().PadRight(6, ' ');
                nDr["NICK"] += dr["NICK"].ToString().PadRight(6, ' ');
                nDr["ADHIBIT"] += dr["ADHIBIT"].ToString().PadRight(6, ' ');
                nDr["WATER_MARK"] += dr["WATER_MARK"].ToString().PadRight(6, ' ');
                nDr["FINGER_MARK"] += dr["FINGER_MARK"].ToString().PadRight(6, ' ');
                nDr["LIGHT_LEAK"] += dr["LIGHT_LEAK"].ToString().PadRight(6, ' ');
                nDr["STATIC_SHADOW"] += dr["STATIC_SHADOW"].ToString().PadRight(6, ' ');
                nDr["EXTERNA_SHADOW"] += dr["EXTERNA_SHADOW"].ToString().PadRight(6, ' ');
                nDr["TOTAL_SCORE"] += dr["TOTAL_SCORE"].ToString().PadRight(6, ' ');
                nDr["DISTINCTION"] += dr["DISTINCTION"].ToString().PadRight(6, ' ');
                
                nDr["D_EXPOSURE_DOSE"] += s.PadRight(6, ' ');
                nDr["D_FLAG_CONTENT"] += s.PadRight(6, ' ');
                nDr["D_FLAG_PLACE_ARRANGE"] += s.PadRight(6, ' ');
                nDr["D_DEVICE_SHADOW"] += s.PadRight(6, ' ');


                Total_Score_All += Convert.ToDecimal(dr["TOTAL_SCORE"]);
                if (dr["DISTINCTION"].ToString() == "1")
                    DISTINCTION_1 += 1;
                else if (dr["DISTINCTION"].ToString() == "2")
                    DISTINCTION_2 += 1;
                else if (dr["DISTINCTION"].ToString() == "3")
                    DISTINCTION_3 += 1;
            }

            foreach (DataRow dr1 in dtImage.Rows)
            {
                nDr["PATIENT_LOCAL_ID"] += dr1["PATIENT_LOCAL_ID"].ToString().PadRight(7, ' ');

                nDr["KNUCKLE_PROJECTION"] += dr1["KNUCKLE_PROJECTION"].ToString().PadRight(6, ' ');
                nDr["KNUCKLE_LONG_AXIS_PARALLEL"] += dr1["KNUCKLE_LONG_AXIS_PARALLEL"].ToString().PadRight(6, ' ');
                nDr["KNUCKLE_WRAP"] += dr1["KNUCKLE_WRAP"].ToString().PadRight(6, ' ');
                nDr["KNUCKLE_IMAGE_DISTORTION"] += dr1["KNUCKLE_IMAGE_DISTORTION"].ToString().PadRight(6, ' ');
                nDr["KNUCKLE_RESOLUTION"] += dr1["KNUCKLE_RESOLUTION"].ToString().PadRight(6, ' ');
                nDr["KNUCKLE_ARRANGEMENT_FOCUS"] += dr1["KNUCKLE_ARRANGEMENT_FOCUS"].ToString().PadRight(6, ' ');
                nDr["KNUCKLE_LETTER_ARRANGE"] += s.PadRight(6, ' ');
                nDr["BASE_ASH_FOG_VALUE"] += s.PadRight(6, ' ');
                nDr["DIAGNOSE_AREA_VALUE"] += s.PadRight(6, ' ');
                nDr["BLANK_EXPOSAL_DENSITY"] += s.PadRight(6, ' ');
                nDr["DIRT"] += s.PadRight(6, ' ');
                nDr["NICK"] += s.PadRight(6, ' ');
                nDr["ADHIBIT"] += s.PadRight(6, ' ');
                nDr["WATER_MARK"] += s.PadRight(6, ' ');
                nDr["FINGER_MARK"] += s.PadRight(6, ' ');
                nDr["LIGHT_LEAK"] += s.PadRight(6, ' ');
                nDr["STATIC_SHADOW"] += s.PadRight(6, ' ');
                nDr["EXTERNA_SHADOW"] += dr1["EXTERNA_SHADOW"].ToString().PadRight(6, ' ');
                nDr["TOTAL_SCORE"] += dr1["TOTAL_SCORE"].ToString().PadRight(6, ' ');
                nDr["DISTINCTION"] += dr1["DISTINCTION"].ToString().PadRight(6, ' ');

                nDr["D_EXPOSURE_DOSE"] += dr1["EXPOSURE_DOSE"].ToString().PadRight(6, ' ');
                nDr["D_FLAG_CONTENT"] += dr1["FLAG_CONTENT"].ToString().PadRight(6, ' ');
                nDr["D_FLAG_PLACE_ARRANGE"] += dr1["FLAG_PLACE_ARRANGE"].ToString().PadRight(6, ' ');
                nDr["D_DEVICE_SHADOW"] += dr1["KNUCKLE_DEVICE_SHADOW"].ToString().PadRight(6, ' ');

                Total_Score_All += Convert.ToDecimal(dr1["TOTAL_SCORE"]);
                if (dr1["DISTINCTION"].ToString() == "1")
                    DISTINCTION_1 += 1;
                else if (dr1["DISTINCTION"].ToString() == "2")
                    DISTINCTION_2 += 1;
                else if (dr1["DISTINCTION"].ToString() == "3")
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