using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SIS_BLL;
using SIS_Model;
using ILL;

namespace SIS
{
    public partial class frmPrintTemplate : Form
    {
        public MPrintTemplateDict mpt;
        private Template temp;
        public struct Template
        {
            public string ExamClass;
            public string ExamSubClass;
            public string TemplateName;
        }

        public frmPrintTemplate(Template t)
        {
            InitializeComponent();
            this.temp = t;
            this.dgv_PrintTemplate.AutoGenerateColumns = false;
            this.BindPrintTemplate();
        }

        private void BindPrintTemplate()
        {
            BPrintTemplateDict bpt = new BPrintTemplateDict();
            string[] ExamClass = GetConfig.ExamClass.Split(',');
            string s = "";
            foreach (string str in ExamClass)
            {
                s += "'" + str + "',";
            }
            string where = "";
            if (this.chk_ShowAll.Checked)
            {
                where = " EXAM_CLASS in (" + s.TrimEnd(',') + ")  order by EXAM_CLASS ";
            }
            else
            {
                where=" EXAM_CLASS in (" + s.TrimEnd(',') + ") and EXAM_SUB_CLASS='"+this.temp.ExamSubClass+"' order by EXAM_CLASS ";
            }
            DataTable dt = bpt.GetList(where);
            dt.Columns.Add("IS_DEFAULT", typeof(string));
             Template[] ts;
            if (GetConfig.RS_DefPrintTemp == "")
            {
                ts = new Template[1];
                ts[0] = new Template();
                ts[0].ExamClass = "";
                ts[0].ExamSubClass = "";
                ts[0].TemplateName = "";
            }
            else
            {
                string[] temps = GetConfig.RS_DefPrintTemp.Split('|');
                ts = new Template[temps.Length];
                for (int i = 0; i < temps.Length; i++)
                {
                    string[] t = temps[i].Split(',');
                    ts[i] = new Template();
                    ts[i].ExamClass = t[0];
                    ts[i].ExamSubClass = t[1];
                    ts[i].TemplateName = t[2];
                }
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool isDefault = false;
                for (int j = 0; j < ts.Length; j++)
                {
                    if (dt.Rows[i]["EXAM_CLASS"].ToString() == ts[j].ExamClass && 
                        dt.Rows[i]["EXAM_SUB_CLASS"].ToString() == ts[j].ExamSubClass && 
                        dt.Rows[i]["PRINT_TEMPLATE"].ToString() == ts[j].TemplateName)
                    {
                        dt.Rows[i]["IS_DEFAULT"] = "是";
                        isDefault = true;
                        break;
                    }
                }
                if (!isDefault)
                    dt.Rows[i]["IS_DEFAULT"] = "否";
            }
            this.dgv_PrintTemplate.DataSource = dt;

        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            string temps = "";
            for (int i = 0; i < this.dgv_PrintTemplate.Rows.Count; i++)
            {
                if (this.dgv_PrintTemplate.Rows[i].Cells["IS_DEFAULT"].Value.ToString() == "是")
                    temps += this.dgv_PrintTemplate.Rows[i].Cells["EXAM_CLASS"].Value.ToString() + "," + this.dgv_PrintTemplate.Rows[i].Cells["EXAM_SUB_CLASS"].Value.ToString() + "," + this.dgv_PrintTemplate.Rows[i].Cells["PRINT_TEMPLATE"].Value.ToString() + "|";
            }
            GetConfig.SetRS_DefPrintTemp(temps.TrimEnd('|'));
            if (this.dgv_PrintTemplate.SelectedRows.Count > 0)
            {
                //if (this.dgv_PrintTemplate.SelectedRows[0].Cells["EXAM_CLASS"].Value.ToString() == this.temp.ExamClass &&
                //       this.dgv_PrintTemplate.SelectedRows[0].Cells["EXAM_SUB_CLASS"].Value.ToString() == this.temp.ExamSubClass &&
                //       this.dgv_PrintTemplate.SelectedRows[0].Cells["PRINT_TEMPLATE"].Value.ToString() != this.temp.TemplateName)
                if (this.dgv_PrintTemplate.SelectedRows[0].Cells["EXAM_CLASS"].Value.ToString() == this.temp.ExamClass &&
                       this.dgv_PrintTemplate.SelectedRows[0].Cells["EXAM_SUB_CLASS"].Value.ToString() == this.temp.ExamSubClass)
                {
                    string filter="PRINT_TEMPLATE_ID="+this.dgv_PrintTemplate.SelectedRows[0].Cells["PRINT_TEMPLATE_ID"].Value.ToString();
                    DataRow dr = ((DataTable)this.dgv_PrintTemplate.DataSource).Select(filter)[0];
                    BPrintTemplateDict bpt = new BPrintTemplateDict();
                    this.mpt = (MPrintTemplateDict)bpt.GetModel(dr);
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn_Default_Click(object sender, EventArgs e)
        {
            if (this.dgv_PrintTemplate.SelectedRows.Count <= 0)
                return;
            this.dgv_PrintTemplate.SelectedRows[0].Cells["IS_DEFAULT"].Value = "是";
            for (int i = 0; i < this.dgv_PrintTemplate.Rows.Count; i++)
            {
                if (this.dgv_PrintTemplate.Rows[i].Cells["EXAM_CLASS"].Value.ToString() == this.dgv_PrintTemplate.SelectedRows[0].Cells["EXAM_CLASS"].Value.ToString() &&
                    this.dgv_PrintTemplate.Rows[i].Cells["EXAM_SUB_CLASS"].Value.ToString() == this.dgv_PrintTemplate.SelectedRows[0].Cells["EXAM_SUB_CLASS"].Value.ToString() &&
                    this.dgv_PrintTemplate.Rows[i].Cells["PRINT_TEMPLATE"].Value.ToString() != this.dgv_PrintTemplate.SelectedRows[0].Cells["PRINT_TEMPLATE"].Value.ToString())
                    this.dgv_PrintTemplate.Rows[i].Cells["IS_DEFAULT"].Value = "否";
            }
        }

        private void dgv_PrintTemplate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btn_Ok_Click(null, null);
        }

        private void dgv_PrintTemplate_DoubleClick(object sender, EventArgs e)
        {

        }

        private void chk_ShowAll_CheckedChanged(object sender, EventArgs e)
        {
            BindPrintTemplate();
        }
    }
}