using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SIS_BLL;
using SIS_Model;
using System.Data.OracleClient;
using System.Data.OleDb;
using SIS.Function;
using ILL;
using SIS_Function;

namespace SIS.SysMaintenance
{
    public partial class frmRoleInfo : Form
    {
        private BSystemFun BSysFun = new BSystemFun();
        private BUsersRole BUserRol = new BUsersRole();
        private MUsersRole MUserRol = new MUsersRole();
        public frmRoleInfo()
        {
            InitializeComponent();
           
        }
        public frmRoleInfo(int _RoleId, string _FunModel)
        {
            InitializeComponent();
            MUserRol.ROLE_ID = _RoleId;
            MUserRol.FUN_MODEL = _FunModel;
        }

        private void RoleInfo_Load(object sender, EventArgs e)
        { 
            BindSysFunTo();
            BindSystemName();
           
        }

        private void BindSystemName()//绑定一级模块名称
        {
            DataTable dt = BSysFun.GetList(" MODEL_CLASS='1' ");
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            dr[0] = 0;
            if (dt.Rows.Count > 0)
            {

                this.CbSystemName.DataSource = dt.DefaultView;
                this.CbSystemName.DisplayMember = "MODEL_NAME";
                this.CbSystemName.ValueMember = "MODEL_ID";
            }
        }

        private void CbSystemName_SelectedValueChanged(object sender, EventArgs e)
        {
            BindSysFunFrom();
        }

        private int GetWhereStr()//
        {

            if (this.CbSystemName.SelectedIndex != 0)
                return Convert.ToInt32(this.CbSystemName.SelectedValue.ToString());
            else
                return 0;
        }

        private void BindSysFunFrom()//绑定待选模块
        { 
            DataTable dt =null;
            if(MUserRol.FUN_MODEL!=",")
             dt = BSysFun.GetListChild(" start with model_id=" + GetWhereStr() + " connect by prior model_id = up_model_id  and instr('"+MUserRol.FUN_MODEL+"',','||model_id||',')<=0");
            else
             dt = BSysFun.GetListChild(" start with model_id=" + GetWhereStr() + " connect by prior model_id = up_model_id ");

            lv_From.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count;i++ )
                {
                    ListViewItem li = new ListViewItem(dt.Rows[i]["MODEL_ID"].ToString());
                    li.SubItems.Add(dt.Rows[i]["MODEL_NAME"].ToString());
                    this.lv_From.Items.Add(li);
                }

            }
        }

        private void BindSysFunTo()//已选模块
        {
            lv_To.Items.Clear();
            DataTable dt = BSysFun.GetList( " instr('"+MUserRol.FUN_MODEL+"',','||model_id||',')>0");
            if(dt!=null)
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem li = new ListViewItem(dt.Rows[i]["MODEL_ID"].ToString());
                    li.SubItems.Add(dt.Rows[i]["MODEL_NAME"].ToString());
                    this.lv_To.Items.Add(li);
                }

            }
        }

        private void MoveListView(ListView fro,ListView to,int type)
        {

            for (int i = 0; i < fro.Items.Count; )
            {
                if (fro.Items[i].Selected|| type==1)
                {
                    ListViewItem li = fro.Items[i];
                    fro.Items.Remove(li);
                    to.Items.Add(li);
                    continue;
                }
                i++;
            }
        }

        private void btn_ResSendToLeft_Click(object sender, EventArgs e)//向左移
        {
            MoveListView(lv_To, lv_From,0);
        }

        private void btn_ResSendToRight_Click(object sender, EventArgs e)//右移
        {
            MoveListView(lv_From,lv_To,0);
        }

        private void btn_SrcSendAllToLeft_Click(object sender, EventArgs e)//全部左移
        {
            MoveListView(lv_To, lv_From, 1);
        }

        private void btn_ResSendAllToRight_Click(object sender, EventArgs e)//全部右移
        {
            MoveListView(lv_From, lv_To, 1);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {

            string strFuns = ",";
            for (int i = 0; i < lv_To.Items.Count; i++)
            {
                strFuns += this.lv_To.Items[i].SubItems[0].Text.ToString()+",";
            }
            MUserRol.FUN_MODEL = strFuns;
            if (BUserRol.Update(MUserRol, "where ROLE_ID=" + MUserRol.ROLE_ID) > 0)
                MessageBoxEx.Show("保存成功！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            else
                MessageBoxEx.Show("保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            frmUserRoleManage.UserRoleMana.ElseFromUse();
            this.Close();
        }

        private void RoleInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmUserRoleManage.UserRoleMana.ElseFromUse();
        }


    }
}