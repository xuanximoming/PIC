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
    public partial class frmAddModelOne : Form
    {
        private BSystemFun BSysFun = new BSystemFun();
        private MSystemFun MSysFun = new MSystemFun();
        private MSystemFun MSysFun2 = new MSystemFun();
        private BGetSeqValue ID = new BGetSeqValue("SIS", "SEQ_SYSTEM_FUN_MODEL_ID");
        private Hashtable htRow = new Hashtable();//记录修改的行号
        private int i = 0;
        private DataTable dt;
        private int rowcount;
        public frmAddModelOne()
        {
            InitializeComponent();
            this.GvFunClassOne.AutoGenerateColumns = false;

        }

        private void AddSysFun_Load(object sender, EventArgs e)
        {
            this.btnFunName.Text = this.Text.ToString();
            GetClassOneModel();
            GvFunClassOne.ReadOnly = true;
        }

        private void GetClassOneModel()//获取第一级模块
        {
            dt = BSysFun.GetList(" MODEL_CLASS = '1' ORDER BY MODEL_ID");
            this.GvFunClassOne.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                this.GvFunClassOne.Visible = true;
                this.gb_PromptInfo.Visible = false;
            }
            else
            {
                this.GvFunClassOne.Visible = false;
                this.gb_PromptInfo.Visible = true;
            }
            rowcount = GvFunClassOne.Rows.Count + 1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.GvFunClassOne.Visible = true;
            this.gb_PromptInfo.Visible = false;

            DataTable dt = (DataTable)GvFunClassOne.DataSource;
            if (dt == null)
                GvFunClassOne.Rows.Add();
            else
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                GvFunClassOne.DataSource = dt;
            }

            GvFunClassOne.Rows[GvFunClassOne.Rows.Count - 1].Cells["MODEL_ID"].Value = Convert.ToInt32(ID.GetSeqValue());
            GvFunClassOne.CurrentCell = GvFunClassOne.Rows[GvFunClassOne.Rows.Count - 1].Cells["MODEL_NAME"];
            GvFunClassOne.Rows[GvFunClassOne.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Linen;
            SetDataGridViewRowEditModel(GvFunClassOne.Rows.Count - 1);
        }


        //private void AddSysFun_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter && e.Control)
        //    {
        //        CreateNewRow();
        //    }
        //}

        private void btnCancle_Click(object sender, EventArgs e)
        {
            if (SaveData() && EditData())
            {
                GetClassOneModel();
                GvFunClassOne.ReadOnly = true;
            }
        }

        private bool SaveData()//批量保存
        {
            Hashtable ht = new Hashtable();
            if (GvFunClassOne.Rows.Count > rowcount-1)//说明有新增行
            {
                for (int i = rowcount, j = 0; i <= GvFunClassOne.Rows.Count && j < GvFunClassOne.Rows.Count; i++, j++)//从第rowcount个开始保存
                {
                    MSystemFun MSysFunChi = new MSystemFun();
                    MSysFunChi.MODEL_ID = Convert.ToInt32(GvFunClassOne.Rows[i - 1].Cells["MODEL_ID"].Value.ToString());
                    MSysFunChi.UP_MODEL_ID = 0;
                    MSysFunChi.MODEL_CLASS = "1";
                    MSysFunChi.DEL_FLAG = 0;
                    if (!string.IsNullOrEmpty(GvFunClassOne.Rows[i - 1].Cells["MODEL_NAME"].FormattedValue.ToString()))
                    {
                        MSysFunChi.MODEL_NAME = GvFunClassOne.Rows[i - 1].Cells["MODEL_NAME"].Value.ToString();
                    }
                    else
                    {
                        MessageBoxEx.Show("系统名称不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (!string.IsNullOrEmpty(GvFunClassOne.Rows[i - 1].Cells["MODEL_PLACE"].FormattedValue.ToString()))
                    {
                        MSysFunChi.MODEL_PLACE = GvFunClassOne.Rows[i - 1].Cells["MODEL_PLACE"].Value.ToString();
                    }
                    else
                    {
                        MessageBoxEx.Show("窗体对象名称不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (ExpressionValidat.IsInt(GvFunClassOne.Rows[i - 1].Cells["SORT_FLAG"].FormattedValue.ToString()))
                        MSysFunChi.SORT_FLAG = Convert.ToInt32(GvFunClassOne.Rows[i - 1].Cells["SORT_FLAG"].Value.ToString());
                    else
                    {
                        MessageBoxEx.Show("排序号必须为数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (!string.IsNullOrEmpty(GvFunClassOne.Rows[i - 1].Cells["IMAGE_ADDRESS"].FormattedValue.ToString()))
                        MSysFunChi.IMAGE_ADDRESS = GvFunClassOne.Rows[i - 1].Cells["IMAGE_ADDRESS"].Value.ToString();
                    ht.Add(j, MSysFunChi);
                }
            }
            if (ht.Count > 0)
            {
                if (BSysFun.AddMore(ht) > 0)
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
                    MSystemFun MSysFun = new MSystemFun();
                    MSysFun.MODEL_ID = Convert.ToInt32(GvFunClassOne.Rows[r].Cells["MODEL_ID"].Value.ToString());
                    if (!string.IsNullOrEmpty(GvFunClassOne.Rows[r].Cells["MODEL_NAME"].FormattedValue.ToString()))
                    {
                        MSysFun.MODEL_NAME = GvFunClassOne.Rows[r].Cells["MODEL_NAME"].Value.ToString();
                    }
                    else
                    {
                        MessageBoxEx.Show("系统名称不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (!string.IsNullOrEmpty(GvFunClassOne.Rows[r].Cells["MODEL_PLACE"].FormattedValue.ToString()))
                    {
                        MSysFun.MODEL_PLACE = GvFunClassOne.Rows[r].Cells["MODEL_PLACE"].Value.ToString();
                    }
                    else
                    {
                        MessageBoxEx.Show("窗体对象名称不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (ExpressionValidat.IsInt(GvFunClassOne.Rows[r].Cells["SORT_FLAG"].FormattedValue.ToString()))
                        MSysFun.SORT_FLAG = Convert.ToInt32(GvFunClassOne.Rows[r].Cells["SORT_FLAG"].Value.ToString());
                    else
                    {
                        MessageBoxEx.Show("排序号必须为数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (!string.IsNullOrEmpty(GvFunClassOne.Rows[r].Cells["IMAGE_ADDRESS"].FormattedValue.ToString()))
                        MSysFun.IMAGE_ADDRESS = GvFunClassOne.Rows[r].Cells["IMAGE_ADDRESS"].Value.ToString();
                    htEdit.Add(k, MSysFun);

                }
                if (BSysFun.UpdateMore(htEdit) >= 0)
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

        private void GvFunClassOne_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gv = (DataGridView)sender;
            if (gv.Columns[e.ColumnIndex].Name == "Operate")
            {
                if (e.RowIndex < rowcount - 1)
                {
                    if (DialogResult.OK == MessageBoxEx.Show("将删除该模块下的所有子模块，确认要删除" + gv.Rows[e.RowIndex].Cells["MODEL_NAME"].Value + "吗", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk))
                    {
                        if (BSysFun.Delete("  where model_id in( select model_id from SYSTEM_FUNCTION start with MODEL_ID=" + Convert.ToInt32(gv.Rows[e.RowIndex].Cells["MODEL_ID"].Value.ToString()) + " connect by prior model_id = up_model_id )") >= 0)
                        {
                            MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GetClassOneModel();//刷新表格
                        }
                        else
                            MessageBoxEx.Show("删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnGoUpModel_Click(object sender, EventArgs e)
        {
            frmMainForm.myMainForm.SetFormHidden();//显示窗体前影藏所有窗体

            frmMainForm.myMainForm.SetFormDisplay("系统功能", "SIS.SysMaintenance.AddModelOne");
        }

        //private void GvFunClassOne_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        //    switch (GvFunClassOne.Columns[e.ColumnIndex].Name)
        //    {
        //        case "MODEL_NAME":
        //            if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
        //            {
        //                MessageBoxEx.Show("模块名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                e.Cancel = true;
        //            }
        //            break;

        //        case "MODEL_PLACE":
        //            if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
        //            {
        //                MessageBoxEx.Show("窗体对象名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                e.Cancel = true;
        //            }
        //            break;
        //        case "SORT_FLAG":

        //             if (!ExpressionValidat.IsNumeric(e.FormattedValue.ToString()))
        //            {
        //                MessageBoxEx.Show("排序号必须为数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //            break;

        //    }
        //}

        //设置网格中行的编辑状态
        //输入参数:Index-可编辑行的索引;

        private void SetDataGridViewRowEditModel(int Index)
        {
            GvFunClassOne.ReadOnly = false;
            foreach (DataGridViewRow dr in GvFunClassOne.Rows)
                dr.ReadOnly = true;

            if (Index >= 0)
            {
                GvFunClassOne.Rows[Index].ReadOnly = false;
                GvFunClassOne.Rows[Index].Cells["MODEL_ID"].ReadOnly = true;
            }
        }
    }
}