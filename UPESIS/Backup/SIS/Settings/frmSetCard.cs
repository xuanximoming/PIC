using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ILL;

namespace SIS
{
    public partial class frmSetCard : Form
    {
        public frmSetCard()
        {
            InitializeComponent();
        }

        private void InitControl()
        {
            cmb_CardProduct.Items.Clear();
            cmb_CardProduct.Items.Add("MV");
            cmb_CardProduct.Items.Add("OK");

            cb_CommMode.Items.Clear();
            cb_CommMode.Items.Add("���ڽ�̤");
            cb_CommMode.Items.Add("���ڰ�ť");
            cb_CommMode.Items.Add("USB����");

            cb_Port.Items.Clear();
            for (int i = 1; i < 10; i++)
            {
                string s="COM" + i.ToString();
                cb_Port.Items.Add(s);
            }

            cmb_PressA.Items.Clear();
            cmb_PressA.Items.Add("��֡�ɼ�");
            cmb_PressA.Items.Add("��̬�ɼ�");
            cmb_PressA.Items.Add("��̨��֡");
            cmb_PressA.Items.Add("��̨��̬");

            cmb_PressB.Items.Clear();
            cmb_PressB.Items.Add("��֡�ɼ�");
            cmb_PressB.Items.Add("��̬�ɼ�");
            cmb_PressB.Items.Add("��̨��֡");
            cmb_PressB.Items.Add("��̨��̬");

            cmb_PressC.Items.Clear();
            cmb_PressC.Items.Add("��֡�ɼ�");
            cmb_PressC.Items.Add("��̬�ɼ�");
            cmb_PressC.Items.Add("��̨��֡");
            cmb_PressC.Items.Add("��̨��̬");

            cmb_PressD.Items.Clear();
            cmb_PressD.Items.Add("��֡�ɼ�");
            cmb_PressD.Items.Add("��̬�ɼ�");
            cmb_PressD.Items.Add("��̨��֡");
            cmb_PressD.Items.Add("��̨��̬");
        }

        private void ReadConfig()
        {
            cmb_CardProduct.Text = GetConfig.IMS_CardProduct;
            txt_CardType.Text = GetConfig.IMS_CardType;
            txt_CardExe.Text = GetConfig.IMS_CardExe;
            txt_Quality.Text = GetConfig.IMS_Quality.ToString();

            bool bl = GetConfig.COS_IsUse;
            cb_IsUse_Yes.Checked = bl;
            cb_IsUse_No.Checked = !bl;

            bool BL1=GetConfig.COS_IsPerlinNoise;
            cb_PerlinNoise_Yes.Checked = BL1;
            cb_PerlinNoise_No.Checked = !BL1;

            string ComMode = GetConfig.COS_CommMode;
            cb_CommMode.SelectedIndex = int.Parse(ComMode);

            string Port = GetConfig.COS_Port;
            cb_Port.SelectedIndex = int.Parse(Port)-1;

            txt_BaudRate.Text = GetConfig.COS_BaudRate.ToString();
            txt_DataBits.Text = GetConfig.COS_DataBits.ToString();
            string[] aystr = GetConfig.COS_ButtonCatch.Split(',');

            cmb_PressA.SelectedIndex = int.Parse(aystr[0])-1;
            cmb_PressB.SelectedIndex = int.Parse(aystr[1])-1;
            cmb_PressC.SelectedIndex = int.Parse(aystr[2])-1;
            cmb_PressD.SelectedIndex = int.Parse(aystr[3])-1;
        }

        private void frmSetCard_Load(object sender, EventArgs e)
        {
            InitControl();
            ReadConfig();

        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            opFileDlg.Filter = "*.EXE(*.exe)|*.EXE";
            opFileDlg.InitialDirectory = Application.StartupPath;

            if (opFileDlg.ShowDialog() == DialogResult.OK)
            {
                txt_CardExe.Text = opFileDlg.FileName;
            }
        }

        private void cb_IsUse_Yes_CheckedChanged(object sender, EventArgs e)
        {
            cb_IsUse_No.Checked = !cb_IsUse_Yes.Checked;
        }

        private void cb_IsUse_No_CheckedChanged(object sender, EventArgs e)
        {
            cb_IsUse_Yes.Checked = !cb_IsUse_No.Checked;
        }

        private void cb_PerlinNoise_Yes_CheckedChanged(object sender, EventArgs e)
        {
            cb_PerlinNoise_No.Checked = !cb_PerlinNoise_Yes.Checked;
        }

        private void cb_PerlinNoise_No_CheckedChanged(object sender, EventArgs e)
        {
            cb_PerlinNoise_Yes.Checked = !cb_PerlinNoise_No.Checked;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void SaveConfig()
        {
            GetConfig.ini.IniWriteValue("ImgCardSetting", "CardProduct", cmb_CardProduct.Text);
            GetConfig.ini.IniWriteValue("ImgCardSetting", "CardType", txt_CardType.Text);
            GetConfig.ini.IniWriteValue("ImgCardSetting", "CardExe", txt_CardExe.Text);
            GetConfig.ini.IniWriteValue("ImgCardSetting", "Quality", txt_Quality.Text);


            GetConfig.ini.IniWriteValue("CommSetting", "IsUse", Convert.ToString(cb_IsUse_Yes.Checked));
            GetConfig.ini.IniWriteValue("CommSetting", "CommMode", cb_CommMode.SelectedIndex.ToString());
            GetConfig.ini.IniWriteValue("CommSetting", "Port", Convert.ToString(cb_Port.SelectedIndex + 1));
            GetConfig.ini.IniWriteValue("CommSetting", "BaudRate", txt_BaudRate.Text);
            GetConfig.ini.IniWriteValue("CommSetting", "DataBits", txt_DataBits.Text);
            GetConfig.ini.IniWriteValue("CommSetting", "IsPerlinNoise", Convert.ToString(cb_PerlinNoise_Yes.Checked));

            string KeyPre = cmb_PressA.SelectedIndex.ToString() + "," + cmb_PressB.SelectedIndex.ToString() + "," + cmb_PressC.SelectedIndex.ToString() + "," + cmb_PressD.SelectedIndex.ToString();
            GetConfig.ini.IniWriteValue("CommSetting", "ButtonCatch", KeyPre);
        }

    }
}