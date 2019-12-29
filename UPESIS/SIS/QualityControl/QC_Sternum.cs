using CrystalDecisions.CrystalReports.Engine;
using PACS_Model;
using SIS_BLL;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;


namespace SIS.QualityControl
{
    public partial class QC_Sternum : Form
    {
        private BQcFilm bFilm = new BQcFilm();
        private BQcDigitalImage bdgImg = new BQcDigitalImage();
        private MQcFilm mFilm = new MQcFilm();
        private MQcDigitalImage mdtImg = new MQcDigitalImage();
        private ReportDocument rptDocument;
        private DataTable dtFilm = new DataTable();
        private DataTable dtImage = new DataTable();
        private int NowRow = -1;        //返回操作的行
        private int FirstTopType = -1;  //返回第一行记录的类型　
        private bool isModify = true;  //如果由查询界面进入此窗体,则点保存时为修改否则为新增;默认为修改
        private string path = Application.StartupPath + "\\CrystalReports\\";

        public QC_Sternum()
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
                            FirstTopType = 0;

                        FillDataTableFromTable(dttp.Rows[0], 0);
                    }
                }
                else if (mqcInfor.Type.ToString() == "1")
                {
                    DataTable dttpL = bdgImg.GetList("EXAM_ACCESSION_NUM='" + mqcInfor.EXAM_ACCESSION_NUM + "'");
                    if (dttpL.Rows.Count > 0)
                    {
                        if (i == 0 && FirstTopType == -1)
                            FirstTopType = 1;

                        FillDataTableFromTable(dttpL.Rows[0], 1);
                    }
                }
                else
                {
                    isModify = false;   //为新增
                    SIS_Function.ApiIni AI = new SIS_Function.ApiIni(Application.StartupPath + @"\Settings.ini");
                    string temp = AI.IniReadValue("FilmOrDI", "Sternum_FilmOrDI");

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

                dr["STERNUM_BREAST"] = dttp["STERNUM_BREAST"];
                dr["STERNUM_BOARD"] = dttp["STERNUM_BOARD"];
                dr["STERNUM_BLADEBONE"] = dttp["STERNUM_BLADEBONE"];
                dr["STERNUM_IMAGE_DISTORTION"] = dttp["STERNUM_IMAGE_DISTORTION"];
                dr["BASE_ASH_FOG_VALUE"] = dttp["BASE_ASH_FOG_VALUE"];
                dr["BLANK_EXPOSAL_DENSITY"] = dttp["BLANK_EXPOSAL_DENSITY"];
                dr["DIAGNOSE_AREA_VALUE"] = dttp["DIAGNOSE_AREA_VALUE"];
                dr["STERNUM_ARRANGEMENT_FOCUS"] = dttp["STERNUM_ARRANGEMENT_FOCUS"];
                dr["STERNUM_FIRST_FORTH_WHETTLE"] = dttp["STERNUM_FIRST_FORTH_WHETTLE"];
                dr["STERNUM_LETTER_NO"] = dttp["STERNUM_LETTER_NO"];
                dr["DIRT"] = dttp["DIRT"];
                dr["ADHIBIT"] = dttp["ADHIBIT"];
                dr["FINGER_MARK"] = dttp["FINGER_MARK"];
                dr["STATIC_SHADOW"] = dttp["STATIC_SHADOW"];
                dr["STERNUM_LETTER_ARRANGE"] = dttp["STERNUM_LETTER_ARRANGE"];
                dr["NICK"] = dttp["NICK"];
                dr["WATER_MARK"] = dttp["WATER_MARK"];
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

                dr1["STERNUM_BREAST"] = dttp["STERNUM_BREAST"];
                dr1["STERNUM_BLADEBONE"] = dttp["STERNUM_BLADEBONE"];
                dr1["STERNUM_BOARD"] = dttp["STERNUM_BOARD"];
                dr1["KNUCKLE_IMAGE_DISTORTION"] = dttp["KNUCKLE_IMAGE_DISTORTION"];
                dr1["EXPOSURE_DOSE"] = dttp["EXPOSURE_DOSE"];
                dr1["STERNUM_ARRANGEMENT_FOCUS"] = dttp["STERNUM_ARRANGEMENT_FOCUS"];
                dr1["STERNUM_LUNG_MARKINGS"] = dttp["STERNUM_LUNG_MARKINGS"];
                dr1["FLAG_CONTENT"] = dttp["FLAG_CONTENT"];
                dr1["FLAG_PLACE_ARRANGE"] = dttp["FLAG_PLACE_ARRANGE"];
                dr1["STERNUM_DEVICE_SHADOW"] = dttp["STERNUM_DEVICE_SHADOW"];
                dr1["EXTERNA_SHADOW"] = dttp["EXTERNA_SHADOW"];
                dr1["TOTAL_SCORE"] = dttp["TOTAL_SCORE"];
                dr1["DISTINCTION"] = dttp["DISTINCTION"];
                dtImage.Rows.Add(dr1);
            }
        }

        private void FillDataTableFromClass(ref DataRow dr, MQcInformation minfor, int flag)
        {
            if (flag == 0)
            {
                dr["EXAM_ACCESSION_NUM"] = minfor.EXAM_ACCESSION_NUM;
                dr["PATIENT_ID"] = minfor.PATIENT_ID;
                dr["PATIENT_LOCAL_ID"] = minfor.LOCAL_ID;
                dr["PATIENT_NAME"] = minfor.NAME;
                dr["PATIENT_SEX"] = minfor.SEX;
                dr["STUDY_DATE_TIME"] = minfor.STUDY_DATE_TIME;

                dr["STERNUM_BREAST"] = (decimal)mFilm.STERNUM_BREAST;
                dr["STERNUM_BOARD"] = (decimal)mFilm.STERNUM_BOARD;
                dr["STERNUM_BLADEBONE"] = (decimal)mFilm.STERNUM_BLADEBONE;
                dr["STERNUM_IMAGE_DISTORTION"] = (decimal)mFilm.STERNUM_IMAGE_DISTORTION;
                dr["BASE_ASH_FOG_VALUE"] = (decimal)mFilm.BASE_ASH_FOG_VALUE;
                dr["BLANK_EXPOSAL_DENSITY"] = (decimal)mFilm.BLANK_EXPOSAL_DENSITY;
                dr["DIAGNOSE_AREA_VALUE"] = (decimal)mFilm.DIAGNOSE_AREA_VALUE;
                dr["STERNUM_ARRANGEMENT_FOCUS"] = (decimal)mFilm.STERNUM_ARRANGEMENT_FOCUS;
                dr["STERNUM_FIRST_FORTH_WHETTLE"] = (decimal)mFilm.STERNUM_FIRST_FORTH_WHETTLE;
                dr["STERNUM_LETTER_NO"] = (decimal)mFilm.STERNUM_LETTER_NO;
                dr["DIRT"] = (decimal)mFilm.DIRT;
                dr["ADHIBIT"] = (decimal)mFilm.ADHIBIT;
                dr["FINGER_MARK"] = (decimal)mFilm.FINGER_MARK;
                dr["STATIC_SHADOW"] = (decimal)mFilm.STATIC_SHADOW;
                dr["STERNUM_LETTER_ARRANGE"] = (decimal)mFilm.STERNUM_LETTER_ARRANGE;
                dr["NICK"] = (decimal)mFilm.NICK;
                dr["WATER_MARK"] = (decimal)mFilm.WATER_MARK;
                dr["LIGHT_LEAK"] = (decimal)mFilm.LIGHT_LEAK;
                dr["EXTERNA_SHADOW"] = (decimal)mFilm.EXTERNA_SHADOW;
                dr["TOTAL_SCORE"] = (decimal)mFilm.TOTAL_SCORE;
                dr["DISTINCTION"] = (int)mFilm.DISTINCTION;
            }
            else
            {
                dr["EXAM_ACCESSION_NUM"] = minfor.EXAM_ACCESSION_NUM;
                dr["PATIENT_ID"] = minfor.PATIENT_ID;
                dr["PATIENT_LOCAL_ID"] = minfor.LOCAL_ID;
                dr["PATIENT_NAME"] = minfor.NAME;
                dr["PATIENT_SEX"] = minfor.SEX;
                dr["STUDY_DATE_TIME"] = minfor.STUDY_DATE_TIME;

                dr["STERNUM_BREAST"] = (decimal)mdtImg.STERNUM_BREAST;
                dr["STERNUM_BLADEBONE"] = (decimal)mdtImg.STERNUM_BLADEBONE;
                dr["STERNUM_BOARD"] = (decimal)mdtImg.STERNUM_BOARD;
                dr["KNUCKLE_IMAGE_DISTORTION"] = (decimal)mdtImg.KNUCKLE_IMAGE_DISTORTION;
                dr["EXPOSURE_DOSE"] = (decimal)mdtImg.EXPOSURE_DOSE;
                dr["STERNUM_ARRANGEMENT_FOCUS"] = (decimal)mdtImg.STERNUM_ARRANGEMENT_FOCUS;
                dr["STERNUM_LUNG_MARKINGS"] = (decimal)mdtImg.STERNUM_LUNG_MARKINGS;
                dr["FLAG_CONTENT"] = (decimal)mdtImg.FLAG_CONTENT;
                dr["FLAG_PLACE_ARRANGE"] = (decimal)mdtImg.FLAG_PLACE_ARRANGE;
                dr["STERNUM_DEVICE_SHADOW"] = (decimal)mdtImg.STERNUM_DEVICE_SHADOW;
                dr["EXTERNA_SHADOW"] = (decimal)mdtImg.EXTERNA_SHADOW;
                dr["TOTAL_SCORE"] = (decimal)mdtImg.TOTAL_SCORE;
                dr["DISTINCTION"] = (int)mdtImg.DISTINCTION;
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

                N_STERNUM_BREAST.Value = (decimal)nDr["STERNUM_BREAST"];
                N_STERNUM_BOARD.Value = (decimal)nDr["STERNUM_BOARD"];
                N_STERNUM_BLADEBONE.Value = (decimal)nDr["STERNUM_BLADEBONE"];
                N_STERNUM_IMAGE_DISTORTION.Value = (decimal)nDr["STERNUM_IMAGE_DISTORTION"];

                N_BASE_ASH_FOG_VALUE.Value = (decimal)nDr["BASE_ASH_FOG_VALUE"];
                N_BLANK_EXPOSAL_DENSITY.Value = (decimal)nDr["BLANK_EXPOSAL_DENSITY"];
                N_DIAGNOSE_AREA_VALUE.Value = (decimal)nDr["DIAGNOSE_AREA_VALUE"];

                N_STERNUM_ARRANGEMENT_FOCUS.Value = (decimal)nDr["STERNUM_ARRANGEMENT_FOCUS"];
                N_STERNUM_FIRST_FORTH_WHETTLE.Value = (decimal)nDr["STERNUM_FIRST_FORTH_WHETTLE"];
                N_STERNUM_LETTER_NO.Value = (decimal)nDr["STERNUM_LETTER_NO"];
                N_STERNUM_BOARD.Value = (decimal)nDr["STERNUM_BOARD"];
                N_DIRT.Value = (decimal)nDr["DIRT"];
                N_ADHIBIT.Value = (decimal)nDr["ADHIBIT"];
                N_FINGER_MARK.Value = (decimal)nDr["FINGER_MARK"];
                N_STATIC_SHADOW.Value = (decimal)nDr["STATIC_SHADOW"];
                N_STERNUM_LETTER_ARRANGE.Value = (decimal)nDr["STERNUM_LETTER_ARRANGE"];
                N_NICK.Value = (decimal)nDr["NICK"];
                N_WATER_MARK.Value = (decimal)nDr["WATER_MARK"];
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

                D_STERNUM_BREAST.Value = (decimal)nDr1["STERNUM_BREAST"];
                D_STERNUM_BLADEBONE.Value = (decimal)nDr1["STERNUM_BLADEBONE"];
                D_STERNUM_BOARD.Value = (decimal)nDr1["STERNUM_BOARD"];
                D_KNUCKLE_IMAGE_DISTORTION.Value = (decimal)nDr1["KNUCKLE_IMAGE_DISTORTION"];
                D_EXPOSURE_DOSE.Value = (decimal)nDr1["EXPOSURE_DOSE"];
                D_STERNUM_ARRANGEMENT_FOCUS.Value = (decimal)nDr1["STERNUM_ARRANGEMENT_FOCUS"];
                D_STERNUM_LUNG_MARKINGS.Value = (decimal)nDr1["STERNUM_LUNG_MARKINGS"];
                D_FLAG_CONTENT.Value = (decimal)nDr1["FLAG_CONTENT"];
                D_FLAG_PLACE_ARRANGE.Value = (decimal)nDr1["FLAG_PLACE_ARRANGE"];
                D_STERNUM_DEVICE_SHADOW.Value = (decimal)nDr1["STERNUM_DEVICE_SHADOW"];
                nud_EXTERNA_SHADOW.Value = (decimal)nDr1["EXTERNA_SHADOW"];
                txt_TOTAL_SCORE.Text = nDr1["TOTAL_SCORE"].ToString();
                cmb_DISTINCTION.SelectedIndex = Convert.ToInt32(nDr1["DISTINCTION"]) - 1;
            }
        }

        private void QC_Sternum_Load(object sender, EventArgs e)
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
                mf.STERNUM_BREAST = Convert.ToDecimal(dtFilm.Rows[i]["STERNUM_BREAST"]);
                mf.STERNUM_BOARD = Convert.ToDecimal(dtFilm.Rows[i]["STERNUM_BOARD"]);
                mf.STERNUM_BLADEBONE = Convert.ToDecimal(dtFilm.Rows[i]["STERNUM_BLADEBONE"]);
                mf.STERNUM_IMAGE_DISTORTION = Convert.ToDecimal(dtFilm.Rows[i]["STERNUM_IMAGE_DISTORTION"]);
                mf.BASE_ASH_FOG_VALUE = Convert.ToDecimal(dtFilm.Rows[i]["BASE_ASH_FOG_VALUE"]);
                mf.DIAGNOSE_AREA_VALUE = Convert.ToDecimal(dtFilm.Rows[i]["DIAGNOSE_AREA_VALUE"]);
                mf.BLANK_EXPOSAL_DENSITY = Convert.ToDecimal(dtFilm.Rows[i]["BLANK_EXPOSAL_DENSITY"]);
                mf.STERNUM_ARRANGEMENT_FOCUS = Convert.ToDecimal(dtFilm.Rows[i]["STERNUM_ARRANGEMENT_FOCUS"]);
                mf.STERNUM_FIRST_FORTH_WHETTLE = Convert.ToDecimal(dtFilm.Rows[i]["STERNUM_FIRST_FORTH_WHETTLE"]);
                mf.STERNUM_LETTER_NO = Convert.ToDecimal(dtFilm.Rows[i]["STERNUM_LETTER_NO"]);
                mf.STERNUM_LETTER_ARRANGE = Convert.ToDecimal(dtFilm.Rows[i]["STERNUM_LETTER_ARRANGE"]);
                mf.DIRT = Convert.ToDecimal(dtFilm.Rows[i]["DIRT"]);
                mf.ADHIBIT = Convert.ToDecimal(dtFilm.Rows[i]["ADHIBIT"]);
                mf.FINGER_MARK = Convert.ToDecimal(dtFilm.Rows[i]["FINGER_MARK"]);
                mf.STATIC_SHADOW = Convert.ToDecimal(dtFilm.Rows[i]["STATIC_SHADOW"]);
                mf.NICK = Convert.ToDecimal(dtFilm.Rows[i]["NICK"]);
                mf.WATER_MARK = Convert.ToDecimal(dtFilm.Rows[i]["WATER_MARK"]);
                mf.LIGHT_LEAK = Convert.ToDecimal(dtFilm.Rows[i]["LIGHT_LEAK"]);
                mf.EXTERNA_SHADOW = Convert.ToDecimal(dtFilm.Rows[i]["EXTERNA_SHADOW"]);
                mf.TOTAL_SCORE = Convert.ToDecimal(dtFilm.Rows[i]["TOTAL_SCORE"]);
                mf.DISTINCTION = Convert.ToInt32(dtFilm.Rows[i]["DISTINCTION"]);

                mf.KNUCKLE_PROJECTION = null;
                mf.UGI_PROJECTION_CASE = null;      //将膝关节,上消化道，静脉的标志清空
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

                mi.STERNUM_BREAST = Convert.ToDecimal(dtImage.Rows[m]["STERNUM_BREAST"]);
                mi.STERNUM_BLADEBONE = Convert.ToDecimal(dtImage.Rows[m]["STERNUM_BLADEBONE"]);
                mi.STERNUM_BOARD = Convert.ToDecimal(dtImage.Rows[m]["STERNUM_BOARD"]);
                mi.KNUCKLE_IMAGE_DISTORTION = Convert.ToDecimal(dtImage.Rows[m]["KNUCKLE_IMAGE_DISTORTION"]);
                mi.EXPOSURE_DOSE = Convert.ToDecimal(dtImage.Rows[m]["EXPOSURE_DOSE"]);
                mi.STERNUM_ARRANGEMENT_FOCUS = Convert.ToDecimal(dtImage.Rows[m]["STERNUM_ARRANGEMENT_FOCUS"]);
                mi.STERNUM_LUNG_MARKINGS = Convert.ToDecimal(dtImage.Rows[m]["STERNUM_LUNG_MARKINGS"]);

                mi.FLAG_CONTENT = Convert.ToDecimal(dtImage.Rows[m]["FLAG_CONTENT"]);
                mi.FLAG_PLACE_ARRANGE = Convert.ToDecimal(dtImage.Rows[m]["FLAG_PLACE_ARRANGE"]);
                mi.STERNUM_DEVICE_SHADOW = Convert.ToDecimal(dtImage.Rows[m]["STERNUM_DEVICE_SHADOW"]);
                mi.EXTERNA_SHADOW = Convert.ToDecimal(dtImage.Rows[m]["EXTERNA_SHADOW"]);
                mi.TOTAL_SCORE = Convert.ToDecimal(dtImage.Rows[m]["TOTAL_SCORE"]);
                mi.DISTINCTION = Convert.ToInt32(dtImage.Rows[m]["DISTINCTION"]);

                mi.KNUCKLE_PROJECTION = null;
                mi.UGI_PROJECTION_CASE = null;//将膝关节,上消化道，静脉的标志清空
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

        #region 数字图像值变写入datatable

        private void D_STERNUM_BREAST_ValueChanged(object sender, EventArgs e)
        {
            dtImage.Rows[NowRow]["STERNUM_BREAST"] = D_STERNUM_BREAST.Value;

            decimal dcl = D_STERNUM_BREAST.Value + D_STERNUM_BLADEBONE.Value + D_STERNUM_BOARD.Value + D_KNUCKLE_IMAGE_DISTORTION.Value +
                            D_EXPOSURE_DOSE.Value +
                            D_STERNUM_ARRANGEMENT_FOCUS.Value + D_STERNUM_LUNG_MARKINGS.Value +
                            D_FLAG_CONTENT.Value + D_FLAG_PLACE_ARRANGE.Value + D_STERNUM_DEVICE_SHADOW.Value +
                            nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_STERNUM_BLADEBONE_ValueChanged(object sender, EventArgs e)
        {
            dtImage.Rows[NowRow]["STERNUM_BLADEBONE"] = D_STERNUM_BLADEBONE.Value;
            decimal dcl = D_STERNUM_BREAST.Value + D_STERNUM_BLADEBONE.Value + D_STERNUM_BOARD.Value + D_KNUCKLE_IMAGE_DISTORTION.Value +
                           D_EXPOSURE_DOSE.Value +
                           D_STERNUM_ARRANGEMENT_FOCUS.Value + D_STERNUM_LUNG_MARKINGS.Value +
                           D_FLAG_CONTENT.Value + D_FLAG_PLACE_ARRANGE.Value + D_STERNUM_DEVICE_SHADOW.Value +
                           nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_STERNUM_BOARD_ValueChanged(object sender, EventArgs e)
        {
            dtImage.Rows[NowRow]["STERNUM_BOARD"] = D_STERNUM_BOARD.Value;
            decimal dcl = D_STERNUM_BREAST.Value + D_STERNUM_BLADEBONE.Value + D_STERNUM_BOARD.Value + D_KNUCKLE_IMAGE_DISTORTION.Value +
                           D_EXPOSURE_DOSE.Value +
                           D_STERNUM_ARRANGEMENT_FOCUS.Value + D_STERNUM_LUNG_MARKINGS.Value +
                           D_FLAG_CONTENT.Value + D_FLAG_PLACE_ARRANGE.Value + D_STERNUM_DEVICE_SHADOW.Value +
                           nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_KNUCKLE_IMAGE_DISTORTION_ValueChanged(object sender, EventArgs e)
        {
            dtImage.Rows[NowRow]["KNUCKLE_IMAGE_DISTORTION"] = D_KNUCKLE_IMAGE_DISTORTION.Value;
            decimal dcl = D_STERNUM_BREAST.Value + D_STERNUM_BLADEBONE.Value + D_STERNUM_BOARD.Value + D_KNUCKLE_IMAGE_DISTORTION.Value +
                           D_EXPOSURE_DOSE.Value +
                           D_STERNUM_ARRANGEMENT_FOCUS.Value + D_STERNUM_LUNG_MARKINGS.Value +
                           D_FLAG_CONTENT.Value + D_FLAG_PLACE_ARRANGE.Value + D_STERNUM_DEVICE_SHADOW.Value +
                           nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_EXPOSURE_DOSE_ValueChanged(object sender, EventArgs e)
        {
            dtImage.Rows[NowRow]["EXPOSURE_DOSE"] = D_EXPOSURE_DOSE.Value;
            decimal dcl = D_STERNUM_BREAST.Value + D_STERNUM_BLADEBONE.Value + D_STERNUM_BOARD.Value + D_KNUCKLE_IMAGE_DISTORTION.Value +
                           D_EXPOSURE_DOSE.Value +
                           D_STERNUM_ARRANGEMENT_FOCUS.Value + D_STERNUM_LUNG_MARKINGS.Value +
                           D_FLAG_CONTENT.Value + D_FLAG_PLACE_ARRANGE.Value + D_STERNUM_DEVICE_SHADOW.Value +
                           nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_STERNUM_ARRANGEMENT_FOCUS_ValueChanged(object sender, EventArgs e)
        {
            dtImage.Rows[NowRow]["STERNUM_ARRANGEMENT_FOCUS"] = D_STERNUM_ARRANGEMENT_FOCUS.Value;
            decimal dcl = D_STERNUM_BREAST.Value + D_STERNUM_BLADEBONE.Value + D_STERNUM_BOARD.Value + D_KNUCKLE_IMAGE_DISTORTION.Value +
                           D_EXPOSURE_DOSE.Value +
                           D_STERNUM_ARRANGEMENT_FOCUS.Value + D_STERNUM_LUNG_MARKINGS.Value +
                           D_FLAG_CONTENT.Value + D_FLAG_PLACE_ARRANGE.Value + D_STERNUM_DEVICE_SHADOW.Value +
                           nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_STERNUM_LUNG_MARKINGS_ValueChanged(object sender, EventArgs e)
        {
            dtImage.Rows[NowRow]["STERNUM_LUNG_MARKINGS"] = D_STERNUM_LUNG_MARKINGS.Value;
            decimal dcl = D_STERNUM_BREAST.Value + D_STERNUM_BLADEBONE.Value + D_STERNUM_BOARD.Value + D_KNUCKLE_IMAGE_DISTORTION.Value +
                           D_EXPOSURE_DOSE.Value +
                           D_STERNUM_ARRANGEMENT_FOCUS.Value + D_STERNUM_LUNG_MARKINGS.Value +
                           D_FLAG_CONTENT.Value + D_FLAG_PLACE_ARRANGE.Value + D_STERNUM_DEVICE_SHADOW.Value +
                           nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_FLAG_CONTENT_ValueChanged(object sender, EventArgs e)
        {
            dtImage.Rows[NowRow]["FLAG_CONTENT"] = D_FLAG_CONTENT.Value;
            decimal dcl = D_STERNUM_BREAST.Value + D_STERNUM_BLADEBONE.Value + D_STERNUM_BOARD.Value + D_KNUCKLE_IMAGE_DISTORTION.Value +
                           D_EXPOSURE_DOSE.Value +
                           D_STERNUM_ARRANGEMENT_FOCUS.Value + D_STERNUM_LUNG_MARKINGS.Value +
                           D_FLAG_CONTENT.Value + D_FLAG_PLACE_ARRANGE.Value + D_STERNUM_DEVICE_SHADOW.Value +
                           nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_FLAG_PLACE_ARRANGE_ValueChanged(object sender, EventArgs e)
        {
            dtImage.Rows[NowRow]["FLAG_PLACE_ARRANGE"] = D_FLAG_PLACE_ARRANGE.Value;
            decimal dcl = D_STERNUM_BREAST.Value + D_STERNUM_BLADEBONE.Value + D_STERNUM_BOARD.Value + D_KNUCKLE_IMAGE_DISTORTION.Value +
                           D_EXPOSURE_DOSE.Value +
                           D_STERNUM_ARRANGEMENT_FOCUS.Value + D_STERNUM_LUNG_MARKINGS.Value +
                           D_FLAG_CONTENT.Value + D_FLAG_PLACE_ARRANGE.Value + D_STERNUM_DEVICE_SHADOW.Value +
                           nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void D_STERNUM_DEVICE_SHADOW_ValueChanged(object sender, EventArgs e)
        {
            dtImage.Rows[NowRow]["STERNUM_DEVICE_SHADOW"] = D_STERNUM_DEVICE_SHADOW.Value;
            decimal dcl = D_STERNUM_BREAST.Value + D_STERNUM_BLADEBONE.Value + D_STERNUM_BOARD.Value + D_KNUCKLE_IMAGE_DISTORTION.Value +
                           D_EXPOSURE_DOSE.Value +
                           D_STERNUM_ARRANGEMENT_FOCUS.Value + D_STERNUM_LUNG_MARKINGS.Value +
                           D_FLAG_CONTENT.Value + D_FLAG_PLACE_ARRANGE.Value + D_STERNUM_DEVICE_SHADOW.Value +
                           nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }
        #endregion

        private void cmb_DISTINCTION_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Style.SelectedIndex == 0)
                dtFilm.Rows[NowRow]["DISTINCTION"] = cmb_DISTINCTION.SelectedIndex + 1;
            else
                dtImage.Rows[NowRow]["DISTINCTION"] = cmb_DISTINCTION.SelectedIndex + 1;
        }

        private void nud_EXTERNA_SHADOW_ValueChanged(object sender, EventArgs e)
        {
            decimal dcl = 0;
            if (cmb_Style.SelectedIndex == 0)
            {
                dtFilm.Rows[NowRow]["EXTERNA_SHADOW"] = nud_EXTERNA_SHADOW.Value;
                dcl = N_STERNUM_BREAST.Value + N_STERNUM_BOARD.Value + N_STERNUM_BLADEBONE.Value + N_STERNUM_IMAGE_DISTORTION.Value +
                                N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value + N_DIAGNOSE_AREA_VALUE.Value +
                                N_STERNUM_ARRANGEMENT_FOCUS.Value + N_STERNUM_FIRST_FORTH_WHETTLE.Value +
                                N_STERNUM_LETTER_NO.Value + N_STERNUM_LETTER_ARRANGE.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value + N_STATIC_SHADOW.Value +
                                nud_EXTERNA_SHADOW.Value;
            }
            else
            {
                dtImage.Rows[NowRow]["EXTERNA_SHADOW"] = nud_EXTERNA_SHADOW.Value;
                dcl = D_STERNUM_BREAST.Value + D_STERNUM_BLADEBONE.Value + D_STERNUM_BOARD.Value + D_KNUCKLE_IMAGE_DISTORTION.Value +
                          D_EXPOSURE_DOSE.Value +
                          D_STERNUM_ARRANGEMENT_FOCUS.Value + D_STERNUM_LUNG_MARKINGS.Value +
                          D_FLAG_CONTENT.Value + D_FLAG_PLACE_ARRANGE.Value + D_STERNUM_DEVICE_SHADOW.Value +
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

        #region 胶片值改变时改变datatable
        private void N_STERNUM_BREAST_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["STERNUM_BREAST"] = N_STERNUM_BREAST.Value;
            decimal dcl = N_STERNUM_BREAST.Value + N_STERNUM_BOARD.Value + N_STERNUM_BLADEBONE.Value + N_STERNUM_IMAGE_DISTORTION.Value +
                                N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value + N_DIAGNOSE_AREA_VALUE.Value +
                                N_STERNUM_ARRANGEMENT_FOCUS.Value + N_STERNUM_FIRST_FORTH_WHETTLE.Value +
                                N_STERNUM_LETTER_NO.Value + N_STERNUM_LETTER_ARRANGE.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value + N_STATIC_SHADOW.Value +
                                nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_STERNUM_BOARD_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["STERNUM_BOARD"] = N_STERNUM_BOARD.Value;
            decimal dcl = N_STERNUM_BREAST.Value + N_STERNUM_BOARD.Value + N_STERNUM_BLADEBONE.Value + N_STERNUM_IMAGE_DISTORTION.Value +
                                N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value + N_DIAGNOSE_AREA_VALUE.Value +
                                N_STERNUM_ARRANGEMENT_FOCUS.Value + N_STERNUM_FIRST_FORTH_WHETTLE.Value +
                                N_STERNUM_LETTER_NO.Value + N_STERNUM_LETTER_ARRANGE.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value + N_STATIC_SHADOW.Value +
                                nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_BASE_ASH_FOG_VALUE_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["BASE_ASH_FOG_VALUE"] = N_BASE_ASH_FOG_VALUE.Value;
            decimal dcl = N_STERNUM_BREAST.Value + N_STERNUM_BOARD.Value + N_STERNUM_BLADEBONE.Value + N_STERNUM_IMAGE_DISTORTION.Value +
                                N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value + N_DIAGNOSE_AREA_VALUE.Value +
                                N_STERNUM_ARRANGEMENT_FOCUS.Value + N_STERNUM_FIRST_FORTH_WHETTLE.Value +
                                N_STERNUM_LETTER_NO.Value + N_STERNUM_LETTER_ARRANGE.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value + N_STATIC_SHADOW.Value +
                                nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_BLANK_EXPOSAL_DENSITY_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["BLANK_EXPOSAL_DENSITY"] = N_BLANK_EXPOSAL_DENSITY.Value;
            decimal dcl = N_STERNUM_BREAST.Value + N_STERNUM_BOARD.Value + N_STERNUM_BLADEBONE.Value + N_STERNUM_IMAGE_DISTORTION.Value +
                                N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value + N_DIAGNOSE_AREA_VALUE.Value +
                                N_STERNUM_ARRANGEMENT_FOCUS.Value + N_STERNUM_FIRST_FORTH_WHETTLE.Value +
                                N_STERNUM_LETTER_NO.Value + N_STERNUM_LETTER_ARRANGE.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value + N_STATIC_SHADOW.Value +
                                nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_KNUCKLE_ARRANGEMENT_FOCUS_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["STERNUM_ARRANGEMENT_FOCUS"] = N_STERNUM_ARRANGEMENT_FOCUS.Value;
            decimal dcl = N_STERNUM_BREAST.Value + N_STERNUM_BOARD.Value + N_STERNUM_BLADEBONE.Value + N_STERNUM_IMAGE_DISTORTION.Value +
                                N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value + N_DIAGNOSE_AREA_VALUE.Value +
                                N_STERNUM_ARRANGEMENT_FOCUS.Value + N_STERNUM_FIRST_FORTH_WHETTLE.Value +
                                N_STERNUM_LETTER_NO.Value + N_STERNUM_LETTER_ARRANGE.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value + N_STATIC_SHADOW.Value +
                                nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_STERNUM_LETTER_NO_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["STERNUM_LETTER_NO"] = N_STERNUM_LETTER_NO.Value;
            decimal dcl = N_STERNUM_BREAST.Value + N_STERNUM_BOARD.Value + N_STERNUM_BLADEBONE.Value + N_STERNUM_IMAGE_DISTORTION.Value +
                                N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value + N_DIAGNOSE_AREA_VALUE.Value +
                                N_STERNUM_ARRANGEMENT_FOCUS.Value + N_STERNUM_FIRST_FORTH_WHETTLE.Value +
                                N_STERNUM_LETTER_NO.Value + N_STERNUM_LETTER_ARRANGE.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value + N_STATIC_SHADOW.Value +
                                nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_STERNUM_LETTER_ARRANGE_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["STERNUM_LETTER_ARRANGE"] = N_STERNUM_LETTER_ARRANGE.Value;
            decimal dcl = N_STERNUM_BREAST.Value + N_STERNUM_BOARD.Value + N_STERNUM_BLADEBONE.Value + N_STERNUM_IMAGE_DISTORTION.Value +
                                N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value + N_DIAGNOSE_AREA_VALUE.Value +
                                N_STERNUM_ARRANGEMENT_FOCUS.Value + N_STERNUM_FIRST_FORTH_WHETTLE.Value +
                                N_STERNUM_LETTER_NO.Value + N_STERNUM_LETTER_ARRANGE.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value + N_STATIC_SHADOW.Value +
                                nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_DIRT_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["DIRT"] = N_DIRT.Value;
            decimal dcl = N_STERNUM_BREAST.Value + N_STERNUM_BOARD.Value + N_DIAGNOSE_AREA_VALUE.Value +
                                N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value + N_STERNUM_BLADEBONE.Value + N_STERNUM_IMAGE_DISTORTION.Value +
                                N_STERNUM_ARRANGEMENT_FOCUS.Value + N_STERNUM_FIRST_FORTH_WHETTLE.Value +
                                N_STERNUM_LETTER_NO.Value + N_STERNUM_LETTER_ARRANGE.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value + N_STATIC_SHADOW.Value +
                                nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_NICK_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["NICK"] = N_NICK.Value;
            decimal dcl = N_STERNUM_BREAST.Value + N_STERNUM_BOARD.Value + N_DIAGNOSE_AREA_VALUE.Value +
                                N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value + N_STERNUM_BLADEBONE.Value + N_STERNUM_IMAGE_DISTORTION.Value +
                                N_STERNUM_ARRANGEMENT_FOCUS.Value + N_STERNUM_FIRST_FORTH_WHETTLE.Value +
                                N_STERNUM_LETTER_NO.Value + N_STERNUM_LETTER_ARRANGE.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value + N_STATIC_SHADOW.Value +
                                nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_ADHIBIT_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["ADHIBIT"] = N_ADHIBIT.Value;
            decimal dcl = N_STERNUM_BREAST.Value + N_STERNUM_BOARD.Value + N_DIAGNOSE_AREA_VALUE.Value +
                                N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value + N_STERNUM_BLADEBONE.Value + N_STERNUM_IMAGE_DISTORTION.Value +
                                N_STERNUM_ARRANGEMENT_FOCUS.Value + N_STERNUM_FIRST_FORTH_WHETTLE.Value +
                                N_STERNUM_LETTER_NO.Value + N_STERNUM_LETTER_ARRANGE.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value + N_STATIC_SHADOW.Value +
                                nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_WATER_MARK_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["WATER_MARK"] = N_WATER_MARK.Value;
            decimal dcl = N_STERNUM_BREAST.Value + N_STERNUM_BOARD.Value + N_DIAGNOSE_AREA_VALUE.Value +
                                N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value + N_STERNUM_BLADEBONE.Value + N_STERNUM_IMAGE_DISTORTION.Value +
                                N_STERNUM_ARRANGEMENT_FOCUS.Value + N_STERNUM_FIRST_FORTH_WHETTLE.Value +
                                N_STERNUM_LETTER_NO.Value + N_STERNUM_LETTER_ARRANGE.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value + N_STATIC_SHADOW.Value +
                                nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_FINGER_MARK_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["FINGER_MARK"] = N_FINGER_MARK.Value;
            decimal dcl = N_STERNUM_BREAST.Value + N_STERNUM_BOARD.Value + N_DIAGNOSE_AREA_VALUE.Value +
                                N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value + N_STERNUM_BLADEBONE.Value + N_STERNUM_IMAGE_DISTORTION.Value +
                                N_STERNUM_ARRANGEMENT_FOCUS.Value + N_STERNUM_FIRST_FORTH_WHETTLE.Value +
                                N_STERNUM_LETTER_NO.Value + N_STERNUM_LETTER_ARRANGE.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value + N_STATIC_SHADOW.Value +
                                nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_LIGHT_LEAK_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["LIGHT_LEAK"] = N_LIGHT_LEAK.Value;
            decimal dcl = N_STERNUM_BREAST.Value + N_STERNUM_BOARD.Value + N_DIAGNOSE_AREA_VALUE.Value +
                                N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value + N_STERNUM_BLADEBONE.Value + N_STERNUM_IMAGE_DISTORTION.Value +
                                N_STERNUM_ARRANGEMENT_FOCUS.Value + N_STERNUM_FIRST_FORTH_WHETTLE.Value +
                                N_STERNUM_LETTER_NO.Value + N_STERNUM_LETTER_ARRANGE.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value + N_STATIC_SHADOW.Value +
                                nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_STATIC_SHADOW_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["STATIC_SHADOW"] = N_STATIC_SHADOW.Value;
            decimal dcl = N_STERNUM_BREAST.Value + N_STERNUM_BOARD.Value + N_DIAGNOSE_AREA_VALUE.Value +
                                N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value + N_STERNUM_BLADEBONE.Value + N_STERNUM_IMAGE_DISTORTION.Value +
                                N_STERNUM_ARRANGEMENT_FOCUS.Value + N_STERNUM_FIRST_FORTH_WHETTLE.Value +
                                N_STERNUM_LETTER_NO.Value + N_STERNUM_LETTER_ARRANGE.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value + N_STATIC_SHADOW.Value +
                                nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_STERNUM_BLADEBONE_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["STERNUM_BLADEBONE"] = N_STERNUM_BLADEBONE.Value;
            decimal dcl = N_STERNUM_BREAST.Value + N_STERNUM_BOARD.Value + N_DIAGNOSE_AREA_VALUE.Value +
                                N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value + N_STERNUM_BLADEBONE.Value + N_STERNUM_IMAGE_DISTORTION.Value +
                                N_STERNUM_ARRANGEMENT_FOCUS.Value + N_STERNUM_FIRST_FORTH_WHETTLE.Value +
                                N_STERNUM_LETTER_NO.Value + N_STERNUM_LETTER_ARRANGE.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value + N_STATIC_SHADOW.Value +
                                nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_STERNUM_IMAGE_DISTORTION_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["STERNUM_IMAGE_DISTORTION"] = N_STERNUM_IMAGE_DISTORTION.Value;
            decimal dcl = N_STERNUM_BREAST.Value + N_STERNUM_BOARD.Value + N_STERNUM_BLADEBONE.Value + N_STERNUM_IMAGE_DISTORTION.Value +
                                N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value + N_DIAGNOSE_AREA_VALUE.Value +
                                N_STERNUM_ARRANGEMENT_FOCUS.Value + N_STERNUM_FIRST_FORTH_WHETTLE.Value +
                                N_STERNUM_LETTER_NO.Value + N_STERNUM_LETTER_ARRANGE.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value + N_STATIC_SHADOW.Value +
                                nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }

        private void N_DIAGNOSE_AREA_VALUE_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["DIAGNOSE_AREA_VALUE"] = N_DIAGNOSE_AREA_VALUE.Value;
            decimal dcl = N_STERNUM_BREAST.Value + N_STERNUM_BOARD.Value + N_STERNUM_BLADEBONE.Value + N_STERNUM_IMAGE_DISTORTION.Value +
                                N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value + N_DIAGNOSE_AREA_VALUE.Value +
                                N_STERNUM_ARRANGEMENT_FOCUS.Value + N_STERNUM_FIRST_FORTH_WHETTLE.Value +
                                N_STERNUM_LETTER_NO.Value + N_STERNUM_LETTER_ARRANGE.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value + N_STATIC_SHADOW.Value +
                                nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }
        private void N_STERNUM_FIRST_FORTH_WHETTLE_ValueChanged(object sender, EventArgs e)
        {
            dtFilm.Rows[NowRow]["STERNUM_FIRST_FORTH_WHETTLE"] = N_STERNUM_FIRST_FORTH_WHETTLE.Value;
            decimal dcl = N_STERNUM_BREAST.Value + N_STERNUM_BOARD.Value + N_STERNUM_BLADEBONE.Value + N_STERNUM_IMAGE_DISTORTION.Value +
                                N_BASE_ASH_FOG_VALUE.Value + N_BLANK_EXPOSAL_DENSITY.Value + N_DIAGNOSE_AREA_VALUE.Value +
                                N_STERNUM_ARRANGEMENT_FOCUS.Value + N_STERNUM_FIRST_FORTH_WHETTLE.Value +
                                N_STERNUM_LETTER_NO.Value + N_STERNUM_LETTER_ARRANGE.Value + N_DIRT.Value + N_NICK.Value + N_ADHIBIT.Value + N_WATER_MARK.Value + N_FINGER_MARK.Value + N_LIGHT_LEAK.Value + N_STATIC_SHADOW.Value +
                                nud_EXTERNA_SHADOW.Value;
            txt_TOTAL_SCORE.Text = dcl.ToString();
        }
        #endregion

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
            rptDocument.Load(path + "CR_Sternum.rpt");
            int DISTINCTION_1 = 0, DISTINCTION_2 = 0, DISTINCTION_3 = 0;
            decimal Total_Score_All = 0;

            DataTable dtSernum = MeregeDataTableData(ref DISTINCTION_1, ref DISTINCTION_2, ref DISTINCTION_3, ref Total_Score_All);
            this.rptDocument.SetDataSource(dtSernum);

            SIS_Function.ApiIni AI = new SIS_Function.ApiIni(Application.StartupPath + @"\Settings.ini");
            string Hosiptal_Name = AI.IniReadValue("bcOffice", "HospitalName");
            //this.rptDocument.SetParameterValue("Hospital_Name", Hosiptal_Name);
            //this.rptDocument.SetParameterValue("DISTINCTION_1", DISTINCTION_1);
            //this.rptDocument.SetParameterValue("DISTINCTION_2", DISTINCTION_2);
            //this.rptDocument.SetParameterValue("DISTINCTION_3", DISTINCTION_3);
            //this.rptDocument.SetParameterValue("Total_Score_All", Total_Score_All);
            //this.rptDocument.SetParameterValue("Year", System.DateTime.Now.Year);
            //this.rptDocument.SetParameterValue("Month", System.DateTime.Now.Month);
            this.crv_Sternum.ReportSource = this.rptDocument;
            this.crv_Sternum.Controls[0].Controls[0].Controls[0].Text = "胸部正位片";
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
            dtTpTable.Columns.Add(new DataColumn("STERNUM_BREAST", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("STERNUM_BOARD", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("STERNUM_BLADEBONE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("STERNUM_IMAGE_DISTORTION", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("STERNUM_FIRST_FORTH_WHETTLE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("STERNUM_ARRANGEMENT_FOCUS", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("STERNUM_LETTER_NO", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("STERNUM_LETTER_ARRANGE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("BASE_ASH_FOG_VALUE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("BLANK_EXPOSAL_DENSITY", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("DIAGNOSE_AREA_VALUE", typeof(string)));
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

            dtTpTable.Columns.Add(new DataColumn("D_STERNUM_ARRANGEMENT_FOCUS", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("D_STERNUM_LUNG_MARKINGS", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("D_EXPOSURE_DOSE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("D_FLAG_CONTENT", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("D_FLAG_PLACE_ARRANGE", typeof(string)));
            dtTpTable.Columns.Add(new DataColumn("D_DEVICE_SHADOW", typeof(string)));

            DataRow nDr = dtTpTable.NewRow();

            foreach (DataRow dr in dtFilm.Rows)
            {
                nDr["PATIENT_LOCAL_ID"] += dr["PATIENT_LOCAL_ID"].ToString().PadRight(7, ' ');

                nDr["STERNUM_BREAST"] += dr["STERNUM_BREAST"].ToString().PadRight(6, ' ');
                nDr["STERNUM_BOARD"] += dr["STERNUM_BOARD"].ToString().PadRight(6, ' ');
                nDr["STERNUM_BLADEBONE"] += dr["STERNUM_BLADEBONE"].ToString().PadRight(6, ' ');
                nDr["STERNUM_IMAGE_DISTORTION"] += dr["STERNUM_IMAGE_DISTORTION"].ToString().PadRight(6, ' ');
                nDr["STERNUM_FIRST_FORTH_WHETTLE"] += dr["STERNUM_FIRST_FORTH_WHETTLE"].ToString().PadRight(6, ' ');
                nDr["STERNUM_ARRANGEMENT_FOCUS"] += dr["STERNUM_ARRANGEMENT_FOCUS"].ToString().PadRight(6, ' ');
                nDr["STERNUM_LETTER_NO"] += dr["STERNUM_LETTER_NO"].ToString().PadRight(6, ' ');
                nDr["STERNUM_LETTER_ARRANGE"] += dr["STERNUM_LETTER_ARRANGE"].ToString().PadRight(6, ' ');
                nDr["BLANK_EXPOSAL_DENSITY"] += dr["BLANK_EXPOSAL_DENSITY"].ToString().PadRight(6, ' ');
                nDr["BASE_ASH_FOG_VALUE"] += dr["BASE_ASH_FOG_VALUE"].ToString().PadRight(6, ' ');
                nDr["DIAGNOSE_AREA_VALUE"] += dr["DIAGNOSE_AREA_VALUE"].ToString().PadRight(6, ' ');
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
                nDr["D_STERNUM_ARRANGEMENT_FOCUS"] += s.PadRight(6, ' ');
                nDr["D_STERNUM_LUNG_MARKINGS"] += s.PadRight(6, ' ');
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

                nDr["STERNUM_BREAST"] += dr1["STERNUM_BREAST"].ToString().PadRight(6, ' ');
                nDr["STERNUM_BOARD"] += dr1["STERNUM_BOARD"].ToString().PadRight(6, ' ');
                nDr["STERNUM_BLADEBONE"] += dr1["STERNUM_BLADEBONE"].ToString().PadRight(6, ' ');
                nDr["STERNUM_IMAGE_DISTORTION"] += s.PadRight(6, ' ');
                nDr["STERNUM_FIRST_FORTH_WHETTLE"] += s.PadRight(6, ' ');
                nDr["STERNUM_ARRANGEMENT_FOCUS"] += s.PadRight(6, ' ');
                nDr["STERNUM_LETTER_NO"] += s.PadRight(6, ' ');
                nDr["STERNUM_LETTER_ARRANGE"] += s.PadRight(6, ' ');
                nDr["BASE_ASH_FOG_VALUE"] += s.PadRight(6, ' ');
                nDr["BLANK_EXPOSAL_DENSITY"] += s.PadRight(6, ' ');
                nDr["DIAGNOSE_AREA_VALUE"] += s.PadRight(6, ' ');
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
                nDr["D_STERNUM_ARRANGEMENT_FOCUS"] += dr1["STERNUM_ARRANGEMENT_FOCUS"].ToString().PadRight(6, ' ');
                nDr["D_STERNUM_LUNG_MARKINGS"] += dr1["STERNUM_LUNG_MARKINGS"].ToString().PadRight(6, ' ');
                nDr["D_EXPOSURE_DOSE"] += dr1["EXPOSURE_DOSE"].ToString().PadRight(6, ' ');
                nDr["D_FLAG_CONTENT"] += dr1["FLAG_CONTENT"].ToString().PadRight(6, ' ');
                nDr["D_FLAG_PLACE_ARRANGE"] += dr1["FLAG_PLACE_ARRANGE"].ToString().PadRight(6, ' ');
                nDr["D_DEVICE_SHADOW"] += dr1["STERNUM_DEVICE_SHADOW"].ToString().PadRight(6, ' ');

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