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
using SIS.Function;

namespace SIS.SysMaintenance
{
    public partial class frmUserRoleManage : Form
    {
        private BGetSeqValue ID = new BGetSeqValue("SIS", "SEQ_USERS_ROLE_ID");
        private Hashtable htRow = new Hashtable();//记录修改的行号
        private int i = 0;
        private int rowcount;
        private BExamClass BExamCla = new BExamClass();
        private BUsersRole BUserRol = new BUsersRole();
        public static frmUserRoleManage UserRoleMana;

        public frmUserRoleManage()
        {
            InitializeComponent();
            UserRoleMana = this;
            this.dgv_GroupManage.AutoGenerateColumns = false;
        }

        private void UserRoleManage_Load(object sender, EventArgs e)
        {
            this.btn_FunName.Text = this.Text;
            //BindUserRole("");
            BindExamClass();
            dgv_GroupManage.ReadOnly = true;
        }

        public void BindExamClass()
        {
            string[] ArrayExamClass = ILL.GetConfig.ExamClass.Split(',');
            DataTable dt = new DataTable();
            dt.Columns.Add("EXAM_CLASS", typeof(string));
            foreach (string s in ArrayExamClass)
            {
                DataRow dr = dt.NewRow();
                dr["EXAM_CLASS"] = s;
                dt.Rows.Add(dr);
            }

            //DataTable dt = BExamCla.GetExamClass("  group by exam_class");
            if (dt.Rows.Count > 0)
            {
                ((DataGridViewComboBoxColumn)this.dgv_GroupManage.Columns["exam_class"]).DataSource = dt;
                ((DataGridViewComboBoxColumn)this.dgv_GroupManage.Columns["exam_class"]).DisplayMember = "exam_class";
                ((DataGridViewComboBoxColumn)this.dgv_GroupManage.Columns["exam_class"]).ValueMember = "exam_class";

                cmb_EXAM_CLASS.DataSource = dt;
                cmb_EXAM_CLASS.DisplayMember = "exam_class";
                cmb_EXAM_CLASS.ValueMember = "exam_class";
            }             

            DataTable dt2 = BExamCla.GetList("EXAM_CLASS='" + cmb_EXAM_CLASS.Text + "' AND  1=1 ");
            if (dt2.Rows.Count > 0)
            {
                ((DataGridViewComboBoxColumn)this.dgv_GroupManage.Columns["exam_sub_class"]).DataSource = dt2;
                ((DataGridViewComboBoxColumn)this.dgv_GroupManage.Columns["exam_sub_class"]).DisplayMember = "exam_sub_class";
                ((DataGridViewComboBoxColumn)this.dgv_GroupManage.Columns["exam_sub_class"]).ValueMember = "exam_sub_class";
            }
        }

        private void Bind_Exam_Sub_Class_Cmb(string sqlstr)
        {
            DataTable dt = BExamCla.GetList(sqlstr + " 1=1 ");
            if (dt.Rows.Count > 0)
            {
                cmb_EXAM_SUB_CLASS.DataSource = dt;
                cmb_EXAM_SUB_CLASS.DisplayMember = "exam_sub_class";
                cmb_EXAM_SUB_CLASS.ValueMember = "exam_sub_class";
            }
        }

        //查询角色信息
        private void BindUserRole()
        {

            string sqlstr = "";
            if (cmb_EXAM_CLASS.Text != "")
            {
                if (cmb_EXAM_SUB_CLASS.Text != "")
                    sqlstr = " EXAM_CLASS ='" + cmb_EXAM_CLASS.Text.Trim() + "' and EXAM_SUB_CLASS='" + cmb_EXAM_SUB_CLASS.Text.Trim() + "' and ";
                else
                    sqlstr = " EXAM_CLASS ='" + cmb_EXAM_CLASS.Text.Trim() + "' and ";
            }
            else
            {
                if (cmb_EXAM_SUB_CLASS.Text != "")
                    sqlstr = " EXAM_SUB_CLASS='" + cmb_EXAM_SUB_CLASS.Text.Trim() + "' and ";
            }

            DataTable dt = BUserRol.GetList(sqlstr + " 1=1 order by role_id ");
            this.dgv_GroupManage.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                this.dgv_GroupManage.Visible = true;
                this.gb_PromptInfo.Visible = false;
            }
            else
            {
                this.dgv_GroupManage.Visible = false;
                this.gb_PromptInfo.Visible = true;
            }
            rowcount = this.dgv_GroupManage.Rows.Count + 1;
        }

        public void ElseFromUse()
        {
            cmb_EXAM_SUB_CLASS_SelectedIndexChanged(null,null);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            this.dgv_GroupManage.Visible = true;
            this.gb_PromptInfo.Visible = false;

            DataTable dt = (DataTable)dgv_GroupManage.DataSource;
            if (dt == null)
                dgv_GroupManage.Rows.Add();
            else
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                dgv_GroupManage.DataSource = dt;
            }
            this.dgv_GroupManage.CurrentCell = dgv_GroupManage.Rows[dgv_GroupManage.Rows.Count - 1].Cells["ROLE_NAME"];
            dgv_GroupManage.Rows[dgv_GroupManage.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Linen;
            dgv_GroupManage.Rows[dgv_GroupManage.Rows.Count - 1].Cells["ROLE_ID"].Value = ID.GetSeqValue();

            SetDataGridViewRowEditModel(dgv_GroupManage.Rows.Count - 1);
            dgv_GroupManage.BeginEdit(false);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveData();
            EditData();
            BindUserRole();//刷新表格
            dgv_GroupManage.ReadOnly = true;
        }

        private void SaveData()//批量保存
        {
            Hashtable ht = new Hashtable();
            if (dgv_GroupManage.Rows.Count > rowcount - 1)//说明有新增行
            {
                for (int i = rowcount, j = 0; i <= dgv_GroupManage.Rows.Count && j < dgv_GroupManage.Rows.Count; i++, j++)//从第rowcount个开始保存
                {
                    MUsersRole MUserRol = new MUsersRole();
                    MUserRol.ROLE_ID = Convert.ToInt32(dgv_GroupManage.Rows[i - 1].Cells["ROLE_ID"].Value.ToString());
                    if (!string.IsNullOrEmpty(dgv_GroupManage.Rows[i - 1].Cells["ROLE_NAME"].FormattedValue.ToString()))
                        MUserRol.ROLE_NAME = dgv_GroupManage.Rows[i - 1].Cells["ROLE_NAME"].Value.ToString();
                    if (!string.IsNullOrEmpty(dgv_GroupManage.Rows[i - 1].Cells["EXAM_CLASS"].FormattedValue.ToString()))
                        MUserRol.EXAM_CLASS = dgv_GroupManage.Rows[i - 1].Cells["EXAM_CLASS"].Value.ToString();
                    if (!string.IsNullOrEmpty(dgv_GroupManage.Rows[i - 1].Cells["EXAM_SUB_CLASS"].FormattedValue.ToString()))
                        MUserRol.EXAM_SUB_CLASS = dgv_GroupManage.Rows[i - 1].Cells["EXAM_SUB_CLASS"].Value.ToString();
                    MUserRol.FUN_MODEL = ",";
                    ht.Add(j, MUserRol);
                }
            }
            if (ht.Count > 0)
            {
                if (BUserRol.AddMore(ht) > 0)
                    MessageBoxEx.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else

                    MessageBoxEx.Show("添加失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditData()//批量修改
        {
            Hashtable htEdit = new Hashtable();
            int r = 0;
            if (htRow.Count > 0)
            {
                for (int k = 0; k < htRow.Count; k++)
                {
                    r = Convert.ToInt32(htRow[k].ToString());
                    MUsersRole MUserRol = new MUsersRole();
                    MUserRol.ROLE_ID = Convert.ToInt32(dgv_GroupManage.Rows[r].Cells["ROLE_ID"].Value.ToString());
                    if (!string.IsNullOrEmpty(dgv_GroupManage.Rows[r].Cells["ROLE_NAME"].FormattedValue.ToString()))
                        MUserRol.ROLE_NAME = dgv_GroupManage.Rows[r].Cells["ROLE_NAME"].Value.ToString();
                    if (!string.IsNullOrEmpty(dgv_GroupManage.Rows[r].Cells["EXAM_CLASS"].FormattedValue.ToString()))
                        MUserRol.EXAM_CLASS = dgv_GroupManage.Rows[r].Cells["EXAM_CLASS"].Value.ToString();
                    if (!string.IsNullOrEmpty(dgv_GroupManage.Rows[r].Cells["EXAM_SUB_CLASS"].FormattedValue.ToString()))
                        MUserRol.EXAM_SUB_CLASS = dgv_GroupManage.Rows[r].Cells["EXAM_SUB_CLASS"].Value.ToString();
                    htEdit.Add(k, MUserRol);

                }
                if (BUserRol.UpdateMore(htEdit) >= 0)
                    MessageBoxEx.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBoxEx.Show("修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            htRow.Clear();
            i = 0;
        }

        private void dgv_GroupManage_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            if (dg.Columns[e.ColumnIndex].Name.Equals("EXAM_CLASS"))
            {
                DataTable dt = BExamCla.GetList(" exam_class='" + dg.Rows[e.RowIndex].Cells["EXAM_CLASS"].Value.ToString() + "'");
                if (dt.Rows.Count > 0)
                {
                    ((DataGridViewComboBoxCell)this.dgv_GroupManage.Rows[e.RowIndex].Cells["EXAM_SUB_CLASS"]).DataSource = dt;
                    ((DataGridViewComboBoxCell)this.dgv_GroupManage.Rows[e.RowIndex].Cells["EXAM_SUB_CLASS"]).DisplayMember = "EXAM_SUB_CLASS";
                    ((DataGridViewComboBoxCell)this.dgv_GroupManage.Rows[e.RowIndex].Cells["EXAM_SUB_CLASS"]).ValueMember = "EXAM_SUB_CLASS";
                }
            }
        }

        private void dgv_GroupManage_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgv_GroupManage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gv = (DataGridView)sender;
            if (gv.Columns[e.ColumnIndex].Name == "Operate")
            {
                if (e.RowIndex < rowcount - 1)
                {
                    if (DialogResult.OK == MessageBoxEx.Show("确认要删除吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk))
                    {
                        if (BUserRol.Delete(" where ROLE_ID=" + Convert.ToInt32(gv.Rows[e.RowIndex].Cells["ROLE_ID"].Value.ToString())) >= 0)
                            BindUserRole();//刷新表格
                        else
                            MessageBoxEx.Show("删除失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (!gv.Rows[e.RowIndex].IsNewRow)
                        gv.Rows.RemoveAt(e.RowIndex);
                }
            }

            if (gv.Columns[e.ColumnIndex].Name == "Edit")//修改历史数据
            {
                gv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
                htRow.Add(i++, e.RowIndex.ToString());
                SetDataGridViewRowEditModel(e.RowIndex);
            }
            if (gv.Columns[e.ColumnIndex].Name == "ROLE_SET")
            {
                DataTable dt = (DataTable)dgv_GroupManage.DataSource;
                string RoleName = ",";
                if (dt != null)
                {
                    DataRow[] dr = dt.Select("ROLE_ID='" + gv.Rows[e.RowIndex].Cells["ROLE_ID"].Value.ToString() + "'");
                    if (dr.Length > 0)
                        RoleName = dr[0]["FUN_MODEL"].ToString();
                    else
                    {
                        MessageBoxEx.Show("请保存角色后再对其设置权限!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                frmRoleInfo RolInfo = new frmRoleInfo(Convert.ToInt32(gv.Rows[e.RowIndex].Cells["ROLE_ID"].Value.ToString()), RoleName);
                RolInfo.ShowDialog();
            }
        }

        //设置网格中行的编辑状态
        //输入参数:Index-可编辑行的索引;
        private void SetDataGridViewRowEditModel(int Index)
        {
            dgv_GroupManage.ReadOnly = false;
            foreach (DataGridViewRow dr in dgv_GroupManage.Rows)
                dr.ReadOnly = true;

            if (Index >= 0)
            {
                dgv_GroupManage.Rows[Index].ReadOnly = false;
                dgv_GroupManage.Rows[Index].Cells["ROLE_ID"].ReadOnly = true;
            }
        }

        private void cmb_EXAM_CLASS_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind_Exam_Sub_Class_Cmb(" EXAM_CLASS ='" + cmb_EXAM_CLASS.Text.Trim() + "' and ");

            BindUserRole();
        }

        private void cmb_EXAM_SUB_CLASS_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindUserRole();
        }
    }
}