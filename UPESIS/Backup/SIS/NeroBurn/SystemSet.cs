using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SIS.NeroBurn
{
    public partial class SystemSet : Form
    {
        private SIS_Function.ApiIni opini;

        public SystemSet()
        {
            InitializeComponent();
        }

        private void VolumeKeySetting_Load(object sender, EventArgs e)
        {
            opini = new SIS_Function.ApiIni(Application.StartupPath + @"\Settings.ini");

            for (int i = 1; i < 20; i++)
            {
                int j = i * 5;
                cmb_DayNum.Items.Add(j.ToString());
            }

            txt_VKheader.Text = opini.IniReadValue("NeroBurn", "VKhead");
            cmb_Number.Text = opini.IniReadValue("NeroBurn", "VKdiqit");
            cmb_DayNum.Text = opini.IniReadValue("NeroBurn", "DefaultDay");            
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_VKheader.Text.Trim() == "")
            {
                MessageBoxEx.Show("��������ͷ!", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                opini.IniWriteValue("NeroBurn", "VKhead", txt_VKheader.Text.Trim());
                opini.IniWriteValue("NeroBurn", "VKdiqit", cmb_Number.Text);
                opini.IniWriteValue("NeroBurn", "DefaultDay", cmb_DayNum.Text);
                MessageBoxEx.Show("����ɹ�!", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBoxEx.Show("����ʧ��!", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Default_Click(object sender, EventArgs e)
        {
            txt_VKheader.Text = opini.IniReadValue("NeroBurn", "VKhead");
            cmb_Number.Text = opini.IniReadValue("NeroBurn", "VKdiqit");
            cmb_DayNum.Text = opini.IniReadValue("NeroBurn", "DefaultDay");
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}