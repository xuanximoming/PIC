using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SIS.Settings
{
    public partial class frmSetFont : Form
    {
        private struct FontStu
        {
            public Font f;
            public Color fc;
            public string type;
        }
        private List<FontStu> fs;
        private int OldIndex = -1;

        public frmSetFont()
        {
            InitializeComponent();
            this.init();
        }

        private void init()
        {
            fs = new List<FontStu>();
            for (int i = 0; i < this.lv_Settings.Items.Count; i++)
            {
                switch (this.lv_Settings.Items[i].Text)
                {
                    case "按钮":
                        fs.Add(NewFontStu("VistaButton"));
                        break;
                    case "列表":
                        fs.Add(NewFontStu("MyDataGridView"));
                        break;
                    case "文本框":
                        fs.Add(NewFontStu("userTextBox"));
                        break;
                    case "标签":
                        fs.Add(NewFontStu("MyLabel"));
                        break;
                    case "模板树形控件":
                        fs.Add(NewFontStu("MyTreeView"));
                        break;
                    case "模板显示控件":
                        fs.Add(NewFontStu("RichTextBoxEx"));
                        break;
                    case "标注":
                        fs.Add(NewFontStu("XTextBox"));
                        break;
                }
            }
            this.lv_Settings.Items[0].Selected = true;
        }

        private FontStu NewFontStu(string type)
        {
            FontStu fstu = new FontStu();
            fstu.f = BaseControls.CtlSettings.GetFontValue(type);
            fstu.fc = BaseControls.CtlSettings.GetForeColorValue(type);
            fstu.type = type;
            return fstu;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.fs.Count; i++)
            {
                switch (fs[i].type)
                {
                    case "VistaButton":
                        BaseControls.CtlSettings.SetFont(fs[i].f, "VistaButton");
                        BaseControls.CtlSettings.SetForeColor(fs[i].fc, "VistaButton");
                        break;
                    case "MyDataGridView":
                        BaseControls.CtlSettings.SetFont(fs[i].f, "MyDataGridView");
                        BaseControls.CtlSettings.SetForeColor(fs[i].fc, "MyDataGridView");
                        break;
                    case "userTextBox":
                        BaseControls.CtlSettings.SetFont(fs[i].f, "userTextBox");
                        BaseControls.CtlSettings.SetForeColor(fs[i].fc, "userTextBox");
                        break;
                    case "MyLabel":
                        BaseControls.CtlSettings.SetFont(fs[i].f, "MyLabel");
                        BaseControls.CtlSettings.SetForeColor(fs[i].fc, "MyLabel");
                        break;
                    case "MyTreeView":
                        BaseControls.CtlSettings.SetFont(fs[i].f, "MyTreeView");
                        BaseControls.CtlSettings.SetForeColor(fs[i].fc, "MyTreeView");
                        break;
                    case "RichTextBoxEx":
                        BaseControls.CtlSettings.SetFont(fs[i].f, "RichTextBoxEx");
                        BaseControls.CtlSettings.SetForeColor(fs[i].fc, "RichTextBoxEx");
                        break;
                    case "XTextBox":
                        BaseControls.CtlSettings.SetFont(fs[i].f, "XTextBox");
                        BaseControls.CtlSettings.SetForeColor(fs[i].fc, "XTextBox");
                        break;
                }
            }
            MessageBoxEx.Show("请重启程序以确保所保存的设置生效！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void lv_Settings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lv_Settings.SelectedIndices.Count == 0)
                return;
            this.pg_Font.SelectedObject = this.fs[this.lv_Settings.SelectedIndices[0]].f;
            this.cmb_ForeColor.SelectedItem = this.fs[this.lv_Settings.SelectedIndices[0]].fc;
            this.cmb_ForeColor.Refresh();
            this.OldIndex = this.lv_Settings.SelectedIndices[0];
            this.lb_Display.Font = this.fs[this.lv_Settings.SelectedIndices[0]].f;
            this.lb_Display.ForeColor = this.fs[this.lv_Settings.SelectedIndices[0]].fc;
        }

        private void pg_Font_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            FontStu fstu = this.fs[this.OldIndex];
            fstu.f = (Font)this.pg_Font.SelectedObject;
            this.fs[this.OldIndex] = fstu;
            this.lb_Display.Font = fstu.f;
        }

        private void pg_Font_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            switch (e.NewSelection.Label)
            {
                case "Name":
                    this.lb_Explain.Text = "字体类型" + Environment.NewLine + "可选择已安装的字体";
                    break;
                case "Size":
                    this.lb_Explain.Text = "字体大小" + Environment.NewLine + "可选择已安装的字体";
                    break;
                case "Unit":
                    this.lb_Explain.Text = "Unit" + Environment.NewLine + "";
                    break;
                case "Bold":
                    this.lb_Explain.Text = "粗体" + Environment.NewLine + "是否加粗";
                    break;
                case "GdiCharSet":
                    this.lb_Explain.Text = "GdiCharSet" + Environment.NewLine + "";
                    break;
                case "GdiVerticalFont":
                    this.lb_Explain.Text = "GdiVerticalFont" + Environment.NewLine + "";
                    break;
                case "Italic":
                    this.lb_Explain.Text = "斜体" + Environment.NewLine + "";
                    break;
                case "Strikeout":
                    this.lb_Explain.Text = "删除线" + Environment.NewLine + "是否显示删除线";
                    break;
                case "Underline":
                    this.lb_Explain.Text = "下划线" + Environment.NewLine + "是否显示下划线";
                    break;

            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cmb_ForeColor_SelectItemChanged(object sender, EventArgs e)
        {
            FontStu fstu = this.fs[this.OldIndex];
            fstu.fc = this.cmb_ForeColor.SelectedItem;
            this.fs[this.OldIndex] = fstu;
            this.lb_Display.ForeColor = this.cmb_ForeColor.SelectedItem;
        }
    }
}