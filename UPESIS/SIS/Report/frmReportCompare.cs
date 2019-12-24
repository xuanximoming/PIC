using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SIS_BLL;

namespace SIS
{
    public partial class frmReportCompare : Form
    {
        private string ExamAccessionNum;
        private BReportTrackInf bRepTrack = new BReportTrackInf();
        private DataTable dt;
        private RichTextBox richTextBox2=new RichTextBox();
        private string rpt1;
        private string rpt2;
        public frmReportCompare()
        {
            InitializeComponent();
        }
        public void InitData(string Exam_Accession_num)
        {
            this.ExamAccessionNum = Exam_Accession_num;
            if (GetReports())
            {
                CmbBind();
                this.splitContainer1.Visible = true;
                this.gb_PromptInfo.Visible = false;
            }
            else
            {
                this.gb_PromptInfo.Visible = true;
                this.splitContainer1.Visible = false;
            }
        }
        private void frmReportCompare_Load(object sender, EventArgs e)
        {
            this.ExamAccessionNum = "RY46";
            InitData(ExamAccessionNum);
            GetReports();
            CmbBind();
        }
        private bool GetReports()
        {
             dt = bRepTrack.GetList(" EXAM_NO='"+ExamAccessionNum+"' order by REPORT_MODIFY_TIME DESC");
             if (dt.Rows.Count > 1)
                 return true;
             else
                 return false;
        }
        private void CmbBind()
        {
            cmb_Rpt1.DataSource = dt;
            cmb_Rpt1.DisplayMember = "REPORT_MODIFY_TIME";
            cmb_Rpt1.ValueMember = "REPORT_MODIFY_TIME";
            cmb_Rpt1.SelectedIndex=0;
            DataTable dt2 = dt.Copy();
            cmb_Rpt2.DataSource = dt2;
            cmb_Rpt2.DisplayMember = "REPORT_MODIFY_TIME";
            cmb_Rpt2.ValueMember = "REPORT_MODIFY_TIME";
            if (dt2.Rows.Count > 1)
                cmb_Rpt2.SelectedIndex = 1;
        }
        private void cmb_Rpt1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Compare();
        }
        private void cmb_Rpt2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Compare();

        }
        private void compare_str(string str1, string str2, RichTextBox richTextBox)
        {
            while (str1.Length > 0 && str2.Length > 0)
            {
                ArrayList arr = new ArrayList(); ArrayList tmp = new ArrayList(); ArrayList arr2 = new ArrayList();
                arr = find_max_pos(str1, str2);
                tmp = find_match_pos(str1, str2, arr2);

                if (tmp.Count > 0)
                {
                    if (int.Parse(arr[0].ToString()) > int.Parse(tmp[0].ToString()) && int.Parse(arr[1].ToString()) > int.Parse(tmp[1].ToString()))
                    {
                        arr = tmp;
                    }
                }
                if (arr.Count > 0)
                {
                    AppentRichText4(new RichText(str1.Substring(0, int.Parse(arr[0].ToString())), "宋体", 11f, false, false, false, true, Color.Blue), richTextBox);
                    AppentRichText4(new RichText(str2.Substring(0, int.Parse(arr[1].ToString())), "宋体", 11f, false, false, true, false, Color.Red), richTextBox);
                    AppentRichText4(new RichText(str2.Substring(int.Parse(arr[1].ToString()), int.Parse(arr[2].ToString())), 11f, Color.Black), richTextBox);
                    str1 = str1.Substring(int.Parse(arr[0].ToString()) + int.Parse(arr[2].ToString()));
                    str2 = str2.Substring(int.Parse(arr[1].ToString()) + int.Parse(arr[2].ToString()));
                }
            }
        }
        public void AppentRichText4(RichText RichText, RichTextBox richTextBox)
        {
            int start = this.rtb_Rpt2.TextLength;
            richTextBox.AppendText(RichText.Text);
            richTextBox.SelectionStart = start;
            richTextBox.SelectionLength = RichText.Text.Length;
            richTextBox.SelectionFont = RichText.Font;
            richTextBox.SelectionColor = RichText.Color;
            richTextBox.SelectionStart = this.richTextBox2.TextLength;
        }
        //从串2查找对串1从第N个字符开始前N个字符的首次匹配 
        private ArrayList find_match_pos(string str1, string str2, ArrayList arr)
        {
            int len = 1, pos1 = 0, pos2 = 0, _pos2;
            bool ffind = false;
            ArrayList ret = new ArrayList();

            if (arr.Count > 0)
            {
                pos1 = int.Parse(arr[0].ToString()); pos2 = int.Parse(arr[1].ToString());
            }
            while ((pos1 + len) < str1.Length)
            {
                string str = str1.Substring(pos1, len);
                _pos2 = str2.IndexOf(str);

                if (_pos2 != -1)
                {
                    ffind = true; len++; pos2 = _pos2;
                }
                else
                {

                    if (ffind)
                    {
                        len--; break;
                    }
                    else
                    {
                        pos1 += len; len = 1;
                    }
                }
            }

            if (ffind)
            {
                ret.Clear();
                ret.Add(pos1);
                ret.Add(pos2);
                ret.Add(len);

            }
            else
            {
                ret.Clear();
            }

            return ret;
        }


        //查找两个字串的字符数目最大匹配 
        private ArrayList find_max_pos(string str1, string str2)
        {
            ArrayList ret = new ArrayList(); ArrayList arr = new ArrayList();
            ArrayList res = new ArrayList();
            int max = 0;
            do
            {
                ret = find_match_pos(str1, str2, arr);
                if (ret.Count > 0)
                {
                    if (int.Parse(ret[2].ToString()) > max)
                    {
                        res = ret;
                        max = int.Parse(ret[2].ToString());
                    }

                    // arr = new int(ret[0]+1,ret[1]);
                    arr.Clear();
                    arr.Add(int.Parse(ret[0].ToString()) + 1);
                    //MessageBox.Show(arr[0]);
                    arr.Add(int.Parse(ret[1].ToString()));
                    //arr = new ArrayList(int.Parse(ret[0].ToString()) + 1, int.Parse(ret[1].ToString()));

                }
            }
            while (ret.Count > 0);

            return res;
        }

       
        private string GetSimpleReport(int index)
        {
            try
            {
                string NewLine = "\r\n";
                string str = "【检查参数】" + NewLine;
                str += dt.Rows[index]["EXAM_PARA"].ToString().TrimEnd('\a')+ NewLine;
                str += "【检查所见】" + NewLine;
                str += dt.Rows[index]["DESCRIPTION"].ToString().TrimEnd('\a') + NewLine;
                str += "【印象(诊断)】" + NewLine;
                str += dt.Rows[index]["IMPRESSION"].ToString().TrimEnd('\a') + NewLine;
                str += "【建议】" + NewLine;
                str += dt.Rows[index]["RECOMMENDATION"].ToString().TrimEnd('\a') + NewLine;
                return str;
            }
            catch
            { return ""; }
        }
        private void Compare()
        {
            this.rtb_Rpt1.Text = this.rtb_Rpt2.Text = ""; ;
            this.rpt1 = GetSimpleReport(this.cmb_Rpt1.SelectedIndex);
            this.rtb_Rpt1.Text = rpt1;
            this.rpt2 = GetSimpleReport(this.cmb_Rpt2.SelectedIndex);
            compare_str(rpt1, rpt2, this.rtb_Rpt2);
        }

        private void faTabStrip_Edit_TabStripItemSelectionChanged(BaseControls.TabControl.TabStripItemChangedEventArgs e)
        {

        }

        private void frmReportCompare_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

    }
    public class RichText
    {
        public string Text;

        public Font Font;

        public Color Color;



        public RichText(string Text)
            : this(Text, 12f, Color.Black)
        {
        }

        public RichText(string Text, float Size, Color Color)
            : this(Text, "宋体", Size, false, false, false, false, Color)
        {

        }

        public RichText(string Text, string FontName, float Size, bool Bold, bool Italic, bool Underline, bool selstrikethru, Color Color)
        {
            this.Text = Text;
            this.Color = Color;
            FontStyle style = FontStyle.Regular;

            if (Bold)
                style |= FontStyle.Bold;
            if (Italic)
                style |= FontStyle.Italic;
            if (Underline)
                style |= FontStyle.Underline;
            if (selstrikethru)
                style |= FontStyle.Strikeout;
            this.Font = new Font(FontName, Size, style);
        }



    }
}