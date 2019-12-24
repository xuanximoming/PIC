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
using SIS_Function;
using ILL;
namespace SIS.SysMaintenance
{
    public partial class frmExamItem : Form
    {
        private BExamItemDict BExamItemDi = new BExamItemDict();
        private Hashtable htRow = new Hashtable();//记录修改的行号
        private int i = 0;
        private int rowcount;
        private BExamClass BExamCla = new BExamClass();
        public frmExamItem()
        {
            InitializeComponent();
            this.dgv_ExamItem.AutoGenerateColumns = false;

        }

        private void ExamItem_Load(object sender, EventArgs e)
        {
            this.btn_FunName.Text = this.Text.ToString();

            Bind_Exam_Class();
            Bind_Exam_Sub_Class("");
            dgv_ExamItem.ReadOnly = true;
        }

        private void Bind_Exam_Class()
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
            ((DataGridViewComboBoxColumn)this.dgv_ExamItem.Columns["exam_class"]).DataSource = dt;
            ((DataGridViewComboBoxColumn)this.dgv_ExamItem.Columns["exam_class"]).DisplayMember = "EXAM_CLASS";
            ((DataGridViewComboBoxColumn)this.dgv_ExamItem.Columns["exam_class"]).ValueMember = "EXAM_CLASS";
            DataTable dtExamClass = dt.Copy();
            cmb_EXAM_CLASS.DataSource = dtExamClass;
            cmb_EXAM_CLASS.DisplayMember = "EXAM_CLASS";
            cmb_EXAM_CLASS.ValueMember = "EXAM_CLASS";
        }

        public void Bind_Exam_Sub_Class(String where)
        {
            DataTable dt2 = BExamCla.GetList(where +" 1=1 ");
            if (dt2.Rows.Count > 0)
            {
                ((DataGridViewComboBoxColumn)this.dgv_ExamItem.Columns["exam_sub_class"]).DataSource = dt2;
                ((DataGridViewComboBoxColumn)this.dgv_ExamItem.Columns["exam_sub_class"]).DisplayMember = "exam_sub_class";
                ((DataGridViewComboBoxColumn)this.dgv_ExamItem.Columns["exam_sub_class"]).ValueMember = "exam_sub_class";
            }
        }

        public void Bind_Exam_Sub_ClassL(string where)
        {
            DataTable dt = BExamCla.GetList(where + " 1=1 ");
            cmb_EXAM_SUB_CLASS.DataSource = dt;
            cmb_EXAM_SUB_CLASS.DisplayMember = "exam_sub_class";
            cmb_EXAM_SUB_CLASS.ValueMember = "exam_sub_class";
        }

        //查找检查项目
        public void BindExamItem()
        {
            StringBuilder strBuild = new StringBuilder();

            if (cmb_EXAM_CLASS.Text != "")
                strBuild.Append(" EXAM_CLASS ='" + cmb_EXAM_CLASS.Text.Trim() + "' and ");
            if (cmb_EXAM_SUB_CLASS.Text != "")
                strBuild.Append(" EXAM_SUB_CLASS ='" + cmb_EXAM_SUB_CLASS.Text.Trim() + "' and ");
            if (txt_INPUT_CODE.Text.Trim() != "")
                strBuild.Append(" INPUT_CODE  like '%" + txt_INPUT_CODE.Text.Trim() + "%' and ");

          //  DataTable dt = BExamItemDi.GetList(strBuild.ToString() + " 1=1 ORDER BY EXAM_ITEM_CODE ,EXAM_SUB_CLASS ");
            DataTable dt = BExamItemDi.GetList(strBuild.ToString() + " 1=1 ORDER BY SORT_ID ");
            this.dgv_ExamItem.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                this.dgv_ExamItem.Visible = true;
                this.gb_PromptInfo.Visible = false;
            }
            else
            {
                this.dgv_ExamItem.Visible = false;
                this.gb_PromptInfo.Visible = true;
            }
            rowcount = dgv_ExamItem.Rows.Count + 1;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            dgv_ExamItem.Visible = true;
            gb_PromptInfo.Visible = false;

            DataTable dt = (DataTable)dgv_ExamItem.DataSource;
            if (dt == null)
                dgv_ExamItem.Rows.Add();
            else
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                dgv_ExamItem.DataSource = dt;
            }

            dgv_ExamItem.CurrentCell = dgv_ExamItem.Rows[dgv_ExamItem.Rows.Count - 1].Cells["EXAM_ITEM_CODE"];
            dgv_ExamItem.Rows[dgv_ExamItem.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Linen;
            SetDataGridViewRowEditModel(dgv_ExamItem.Rows.Count - 1);
            dgv_ExamItem.Rows[dgv_ExamItem.Rows.Count - 1].Cells["EXAM_ITEM_CODE"].ReadOnly = false;
            dgv_ExamItem.Rows[dgv_ExamItem.Rows.Count - 1].Cells["EXAM_CLASS"].Value = this.cmb_EXAM_CLASS.Text;
            dgv_ExamItem.Rows[dgv_ExamItem.Rows.Count - 1].Cells["EXAM_SUB_CLASS"].Value = this.cmb_EXAM_SUB_CLASS.Text;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (SaveData() && EditData())
            {
                BindExamItem();
                dgv_ExamItem.ReadOnly = true;
            }
        }

        private bool SaveData()//批量保存
        {
            Hashtable ht = new Hashtable();
            if (dgv_ExamItem.Rows.Count > rowcount-1)//说明有新增行
            {
                for (int i = rowcount, j = 0; i <= dgv_ExamItem.Rows.Count && j < dgv_ExamItem.Rows.Count; i++, j++)//从第rowcount个开始保存
                {
                    MExamItemDict MExamItemDi = new MExamItemDict();
                    if (!string.IsNullOrEmpty(dgv_ExamItem.Rows[i - 1].Cells["EXAM_ITEM_CODE"].FormattedValue.ToString()))
                    {
                        MExamItemDi.EXAM_ITEM_CODE = dgv_ExamItem.Rows[i - 1].Cells["EXAM_ITEM_CODE"].Value.ToString();
                    }
                    else
                    {
                        MessageBoxEx.Show("项目代码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    if (!string.IsNullOrEmpty(dgv_ExamItem.Rows[i - 1].Cells["EXAM_SUB_CLASS"].FormattedValue.ToString()))
                    {
                        MExamItemDi.EXAM_SUB_CLASS = dgv_ExamItem.Rows[i - 1].Cells["EXAM_SUB_CLASS"].Value.ToString();
                    }
                    else
                    {
                        MessageBoxEx.Show("检查子类不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (!string.IsNullOrEmpty(dgv_ExamItem.Rows[i - 1].Cells["EXAM_ITEM_NAME"].FormattedValue.ToString()))
                        MExamItemDi.EXAM_ITEM_NAME = dgv_ExamItem.Rows[i - 1].Cells["EXAM_ITEM_NAME"].Value.ToString();
                    if (!string.IsNullOrEmpty(dgv_ExamItem.Rows[i - 1].Cells["INPUT_CODE"].FormattedValue.ToString()))
                        MExamItemDi.INPUT_CODE = dgv_ExamItem.Rows[i - 1].Cells["INPUT_CODE"].Value.ToString();
                    if (!string.IsNullOrEmpty(dgv_ExamItem.Rows[i - 1].Cells["EXAM_CLASS"].FormattedValue.ToString()))
                    {
                        MExamItemDi.EXAM_CLASS = dgv_ExamItem.Rows[i - 1].Cells["EXAM_CLASS"].Value.ToString();
                    }
                    else
                    {
                        MessageBoxEx.Show("检查类别不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (!string.IsNullOrEmpty(dgv_ExamItem.Rows[i - 1].Cells["SORT_ID"].FormattedValue.ToString()))
                        MExamItemDi.SORT_ID = Convert.ToInt32(dgv_ExamItem.Rows[i - 1].Cells["SORT_ID"].Value.ToString());

                    bool bl = BExamItemDi.Exists(MExamItemDi);
                    if (bl)
                    {
                        MessageBoxEx.Show("存在相同的项目代码、检查类别和检查子类！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    ht.Add(j, MExamItemDi);
                }
            }
            if (ht.Count > 0)
            {
                if (BExamItemDi.AddMore(ht) > 0)
                    MessageBoxEx.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBoxEx.Show("添加失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private bool EditData()//批量修改
        {
            Hashtable htEdit = new Hashtable();
            int r = 0;
            if (htRow.Count > 0)
            {
                for (int k = 0; k < htRow.Count; k++)
                {
                    r = Convert.ToInt32(htRow[k].ToString());
                    if (r >= dgv_ExamItem.Rows.Count)
                        continue;
                    MExamItemDict MExamItemDi = new MExamItemDict();
                    if (!string.IsNullOrEmpty(dgv_ExamItem.Rows[r].Cells["EXAM_ITEM_CODE"].FormattedValue.ToString()))
                    {
                        MExamItemDi.EXAM_ITEM_CODE = dgv_ExamItem.Rows[r].Cells["EXAM_ITEM_CODE"].Value.ToString();
                    }
                    else
                    {
                        MessageBoxEx.Show("项目代码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    if (!string.IsNullOrEmpty(dgv_ExamItem.Rows[r].Cells["EXAM_SUB_CLASS"].FormattedValue.ToString()))
                    {
                        MExamItemDi.EXAM_SUB_CLASS = dgv_ExamItem.Rows[r].Cells["EXAM_SUB_CLASS"].Value.ToString();
                    }
                    else
                    {
                        MessageBoxEx.Show("检查子类不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false ;
                    }
                    if (!string.IsNullOrEmpty(dgv_ExamItem.Rows[r].Cells["EXAM_ITEM_NAME"].FormattedValue.ToString()))
                        MExamItemDi.EXAM_ITEM_NAME = dgv_ExamItem.Rows[r].Cells["EXAM_ITEM_NAME"].Value.ToString();
                    if (!string.IsNullOrEmpty(dgv_ExamItem.Rows[r].Cells["INPUT_CODE"].FormattedValue.ToString()))
                        MExamItemDi.INPUT_CODE = dgv_ExamItem.Rows[r].Cells["INPUT_CODE"].Value.ToString();
                    if (!string.IsNullOrEmpty(dgv_ExamItem.Rows[r].Cells["EXAM_CLASS"].FormattedValue.ToString()))
                        MExamItemDi.EXAM_CLASS = dgv_ExamItem.Rows[r].Cells["EXAM_CLASS"].Value.ToString();
                    else
                    {
                        MessageBoxEx.Show("检查类别不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false ;
                    }
                    if (!string.IsNullOrEmpty(dgv_ExamItem.Rows[r].Cells["SORT_ID"].FormattedValue.ToString()))
                        MExamItemDi.SORT_ID = Convert.ToInt32(dgv_ExamItem.Rows[r].Cells["SORT_ID"].Value.ToString());
                    
                    htEdit.Add(k, MExamItemDi);

                }
                if (BExamItemDi.UpdateMore(htEdit) >= 0)
                    MessageBoxEx.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBoxEx.Show("修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            htRow.Clear();
            i = 0;
            return true;
        }

        private void dgv_ExamItem_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dgv_ExamItem = (DataGridView)sender;

            switch (dgv_ExamItem.Columns[e.ColumnIndex].Name)
            {
                case "EXAM_ITEM_NAME":
                    dgv_ExamItem.Rows[e.RowIndex].Cells["INPUT_CODE"].Value = GetConfig.phone.Convert(e.FormattedValue.ToString(), false);//string kk= Pht.Convert("加快了撒地方",false);
                    break;
            }

        }

        private void dgv_ExamItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gv = (DataGridView)sender;
            if (gv.Columns[e.ColumnIndex].Name == "Operate")
            {
                if (e.RowIndex < rowcount - 1)
                {
                    if (DialogResult.OK == MessageBoxEx.Show("确认要删除吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk))
                    {
                        if (BExamItemDi.Delete(" where EXAM_ITEM_CODE='" + gv.Rows[e.RowIndex].Cells["EXAM_ITEM_CODE"].Value.ToString() + "' and EXAM_SUB_CLASS='" + gv.Rows[e.RowIndex].Cells["EXAM_SUB_CLASS"].Value.ToString() + "'") >= 0)
                            BindExamItem();//刷新表格
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
                SetDataGridViewRowEditModel(e.RowIndex);
                gv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
                htRow.Add(i++, e.RowIndex.ToString());
            }
        }

        private void dgv_ExamItem_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgv_ExamItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            if (dg.Columns[e.ColumnIndex].Name.Equals("EXAM_CLASS"))
            {
                DataTable dt = BExamCla.GetList(" exam_class='" + dg.Rows[e.RowIndex].Cells["EXAM_CLASS"].Value.ToString() + "'");
                if (dt.Rows.Count > 0)
                {
                    ((DataGridViewComboBoxCell)this.dgv_ExamItem.Rows[e.RowIndex].Cells["EXAM_SUB_CLASS"]).DataSource = dt;
                    ((DataGridViewComboBoxCell)this.dgv_ExamItem.Rows[e.RowIndex].Cells["EXAM_SUB_CLASS"]).DisplayMember = "EXAM_SUB_CLASS";
                    ((DataGridViewComboBoxCell)this.dgv_ExamItem.Rows[e.RowIndex].Cells["EXAM_SUB_CLASS"]).ValueMember = "EXAM_SUB_CLASS";
                }
            }
        }

        private void cmb_EXAM_CLASS_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind_Exam_Sub_ClassL("EXAM_CLASS='" + cmb_EXAM_CLASS.Text + "' AND ");
            BindExamItem();
        }

        private void cmb_EXAM_SUB_CLASS_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindExamItem();
        }

        private void txt_INPUT_CODE_TextChanged(object sender, EventArgs e)
        {
            cmb_EXAM_CLASS_SelectedIndexChanged(null, null);
        }


        //设置网格中行的编辑状态
        //输入参数:Index-可编辑行的索引;
        private void SetDataGridViewRowEditModel(int Index)
        {
            dgv_ExamItem.ReadOnly = false;
            foreach (DataGridViewRow dr in dgv_ExamItem.Rows)
                dr.ReadOnly = true;

            if (Index >= 0)
            {
                dgv_ExamItem.Rows[Index].ReadOnly = false;
                dgv_ExamItem.Rows[Index].Cells["EXAM_ITEM_CODE"].ReadOnly = true;
            }
        }
    }
}