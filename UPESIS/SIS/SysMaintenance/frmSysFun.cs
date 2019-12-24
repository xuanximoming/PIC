using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using SIS_BLL;
using SIS_Model;
using System.Data.OracleClient;
using System.Data.OleDb;
using SIS.Function;
using ILL;

namespace SIS.SysMaintenance
{
    public partial class frmSysFun : Form
    {
        private BSystemFun BSysFun = new BSystemFun();
        public frmSysFun()
        {
            InitializeComponent();
            this.GvSysFun.AutoGenerateColumns = false;
            this.btnFunName.Text = this.Text.ToString();
        }

        private void SysFun_Load(object sender, EventArgs e)
        { 
            BindSystemName();
            BindSysFun();
        }

        private void BindSystemName()//��һ��ģ������
        {
            DataTable dt = BSysFun.GetList(" MODEL_CLASS='1' ");
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr,0);
            dr[0] = 0;
            if (dt.Rows.Count > 0)
            {
              
                this.CbSystemName.DataSource = dt.DefaultView;
                this.CbSystemName.DisplayMember = "MODEL_NAME";
                this.CbSystemName.ValueMember = "MODEL_ID";
            }

        }

        private int GetWhereStr()//
        {

            if (this.CbSystemName.SelectedIndex != 0)
                return Convert.ToInt32(this.CbSystemName.SelectedValue.ToString());
            else
                return 0;         
        }

        private void BindSysFun()//�󶨶�����ģ��
        {
            DataTable dt = BSysFun.GetListChild(" start with model_id=" + GetWhereStr() + " connect by prior model_id=up_model_id ");
              if (dt.Rows.Count > 0)
              {
                  this.GvSysFun.DataSource = dt;
                  this.GvSysFun.Visible = true;
                  this.gb_PromptInfo.Visible = false;
              }
              else
              {
                  this.GvSysFun.DataSource = null;
                  this.GvSysFun.Visible = false;
                  this.gb_PromptInfo.Visible = true;
              }
        }

        private void btnAddSysFun_Click(object sender, EventArgs e)
        {
            frmMainForm.myMainForm.SetFormHidden();//��ʾ����ǰӰ�����д���

            frmMainForm.myMainForm.SetFormDisplay("һ��ģ�����", "SIS.SysMaintenance.frmAddModelOne");
              
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMainForm.myMainForm.SetFormHidden();//��ʾ����ǰӰ�����д���

            frmMainForm.myMainForm.SetFormDisplay("����ģ�����", "SIS.SysMaintenance.frmAddModelTwo");
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            frmMainForm.myMainForm.SetFormHidden();//��ʾ����ǰӰ�����д���

            frmMainForm.myMainForm.SetFormDisplay("����ģ�����", "SIS.SysMaintenance.frmAddModelThree");
        }

        private void CbSystemName_SelectedValueChanged(object sender, EventArgs e)
        {
            BindSysFun();
        }
    }
}