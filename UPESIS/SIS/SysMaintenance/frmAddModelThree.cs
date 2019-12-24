using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using BaseControls;
using SIS_BLL;
using SIS_Model;
using System.Data.OracleClient;
using System.Data.OleDb;
using SIS.Function;
using ILL;

namespace SIS.SysMaintenance
{
    public partial class frmAddModelThree : Form
    {
        private BSystemFun BSysFun = new BSystemFun();
        private MSystemFun MSysFun = new MSystemFun();
        private MSystemFun MSysFun2 = new MSystemFun();
        private BGetSeqValue ID = new BGetSeqValue("SIS", "SEQ_SYSTEM_FUN_MODEL_ID");
        private Hashtable htRow = new Hashtable();//记录修改的行号
        private int i = 0;
        private int rowcount;

        public frmAddModelThree()
        {
            InitializeComponent();
            this.GvFunClassThree.AutoGenerateColumns = false;
        }

        private void AddModelThree_Load(object sender, EventArgs e)
        {
            this.btnFunName.Text = this.Text.ToString();
            GetClassThreeModel();
            GvFunClassThree.ReadOnly = true;
        }

        private void GetClassThreeModel()//获取第三级模块
        {
            DataTable dt = new DataTable();
            dt = BSysFun.GetList(3);
            GvFunClassThree.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                this.GvFunClassThree.Visible = true;
                this.gb_PromptInfo.Visible = false;
            }
            else
            {
                this.GvFunClassThree.Visible = false;
                this.gb_PromptInfo.Visible = true;
            }
            rowcount = this.GvFunClassThree.Rows.Count + 1; ;
        }

        private void btnGoUpModel_Click(object sender, EventArgs e)
        {
            frmMainForm.myMainForm.SetFormHidden();//显示窗体前影藏所有窗体

            frmMainForm.myMainForm.SetFormDisplay("系统功能", "SIS.SysMaintenance.AddModelThree");
        }

        private void GvFunClassThree_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTreeViewEditingControl dgvTree = e.Control as DataGridViewTreeViewEditingControl;
            if (dgvTree != null)
            {
                DataTable dt = BSysFun.GetList(" MODEL_CLASS='1'");
                DataTable dt2 = new DataTable();
                if (dt.Rows.Count > 0)
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //  dgvTree.TreeView.ImageList = this.imageList1;
                        TreeNode root = new TreeNode(dt.Rows[i]["MODEL_NAME"].ToString(), 0, 0);
                        dt2 = BSysFun.GetList(" MODEL_CLASS = '2' and UP_MODEL_ID = " + dt.Rows[i]["MODEL_ID"]);
                        if (dt2.Rows.Count > 0)
                            for (int k = 0; k < dt2.Rows.Count; k++)
                                root.Nodes.Add(dt2.Rows[k]["MODEL_NAME"].ToString());
                        dgvTree.TreeView.Nodes.Add(root);
                    }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.GvFunClassThree.Visible = true;
            this.gb_PromptInfo.Visible = false;
            DataTable dt = (DataTable)GvFunClassThree.DataSource;
            if (dt == null)
                GvFunClassThree.Rows.Add();
            else
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                GvFunClassThree.DataSource = dt;
            }
            GvFunClassThree.Rows[GvFunClassThree.Rows.Count - 1].Cells["MODEL_ID"].Value = Convert.ToInt32(ID.GetSeqValue());
            GvFunClassThree.CurrentCell = GvFunClassThree.Rows[GvFunClassThree.Rows.Count - 1].Cells["UP_MODEL_NAME"];
            GvFunClassThree.Rows[GvFunClassThree.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Linen;
            SetDataGridViewRowEditModel(GvFunClassThree.Rows.Count - 1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData() && EditData())
            {
                GetClassThreeModel();
                GvFunClassThree.ReadOnly = true;
            }
        }

        private bool SaveData()//批量保存
        {
            Hashtable ht = new Hashtable();
            if (GvFunClassThree.Rows.Count > rowcount-1)//说明有新增行
            {
                for (int i = rowcount, j = 0; i <= GvFunClassThree.Rows.Count && j < GvFunClassThree.Rows.Count; i++, j++)//从第rowcount个开始保存
                {
                    MSystemFun MSysFunChi = new MSystemFun();
                    MSysFunChi.MODEL_ID = Convert.ToInt32(GvFunClassThree.Rows[i - 1].Cells["MODEL_ID"].Value.ToString());
                    if (!string.IsNullOrEmpty(GvFunClassThree.Rows[i - 1].Cells["UP_MODEL_NAME"].FormattedValue.ToString()))
                    {
                        MSysFunChi.UP_MODEL_ID = Convert.ToInt32(BSysFun.GetList(" MODEL_NAME='" + GvFunClassThree.Rows[i - 1].Cells["UP_MODEL_NAME"].Value.ToString() + "'").Rows[0]["MODEL_ID"].ToString());
                    }
                    else
                    {
                        MessageBoxEx.Show("二级模块不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    MSysFunChi.MODEL_CLASS = "3";
                    MSysFunChi.DEL_FLAG = 0;
                    if (ExpressionValidat.IsInt(GvFunClassThree.Rows[i - 1].Cells["SORT_FLAG"].FormattedValue.ToString()))
                        MSysFunChi.SORT_FLAG = Convert.ToInt32(GvFunClassThree.Rows[i - 1].Cells["SORT_FLAG"].Value.ToString());
                    else
                    {
                        MessageBoxEx.Show("排序号必须为整数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    MSysFunChi.MODEL_ID = Convert.ToInt32(GvFunClassThree.Rows[i - 1].Cells["MODEL_ID"].Value.ToString());
                    if (!string.IsNullOrEmpty(GvFunClassThree.Rows[i - 1].Cells["MODEL_NAME"].FormattedValue.ToString()))
                    {
                        MSysFunChi.MODEL_NAME = GvFunClassThree.Rows[i - 1].Cells["MODEL_NAME"].Value.ToString();
                    }
                    else
                    {
                        MessageBoxEx.Show("三级模块不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (!string.IsNullOrEmpty(GvFunClassThree.Rows[i - 1].Cells["MODEL_PLACE"].FormattedValue.ToString()))
                    {
                        MSysFunChi.MODEL_PLACE = GvFunClassThree.Rows[i - 1].Cells["MODEL_PLACE"].Value.ToString();
                    }
                    else
                    {
                        MessageBoxEx.Show("系统对象名称不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }


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
                    MSysFun.MODEL_ID = Convert.ToInt32(GvFunClassThree.Rows[r].Cells["MODEL_ID"].Value.ToString());
                    if (!string.IsNullOrEmpty(((DataGridViewTreeViewCell)GvFunClassThree.Rows[r].Cells["UP_MODEL_NAME"]).FormattedValue.ToString()))
                        if (!string.IsNullOrEmpty(GvFunClassThree.Rows[r].Cells["UP_MODEL_NAME"].FormattedValue.ToString()))
                        {
                            MSysFun.UP_MODEL_ID = Convert.ToInt32(BSysFun.GetList(" MODEL_NAME='" + GvFunClassThree.Rows[r].Cells["UP_MODEL_NAME"].Value.ToString() + "'").Rows[0]["MODEL_ID"].ToString());
                        }
                        else
                        {
                            MessageBoxEx.Show("二级模块不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false; ;
                        }

                    if (!string.IsNullOrEmpty(GvFunClassThree.Rows[r].Cells["MODEL_NAME"].FormattedValue.ToString()))
                    {
                        MSysFun.MODEL_NAME = GvFunClassThree.Rows[r].Cells["MODEL_NAME"].Value.ToString();
                    }
                    else
                    {
                        MessageBoxEx.Show("三级模块不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false ;
                    }
                    if (!string.IsNullOrEmpty(GvFunClassThree.Rows[r].Cells["MODEL_PLACE"].FormattedValue.ToString()))
                    {
                        MSysFun.MODEL_PLACE = GvFunClassThree.Rows[r].Cells["MODEL_PLACE"].Value.ToString();
                    }
                    else
                    {
                        MessageBoxEx.Show("系统对象名称不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false ;
                    }
                    if (ExpressionValidat.IsInt(GvFunClassThree.Rows[r].Cells["SORT_FLAG"].Value.ToString()))
                        MSysFun.SORT_FLAG = Convert.ToInt32(GvFunClassThree.Rows[r].Cells["SORT_FLAG"].Value.ToString());
                    else
                    {
                        MessageBoxEx.Show("排序号必须为数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false ;
                    }
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

        //private void GvFunClassThree_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        //    switch (GvFunClassThree.Columns[e.ColumnIndex].Name)
        //    {

        //        case "UP_MODEL_NAME":
        //            if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
        //            {
        //                MessageBoxEx.Show("请选择上级模块！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                e.Cancel = true;
        //            }
        //            break;

        //        case "MODEL_NAME":
        //            if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
        //            {
        //                MessageBoxEx.Show("三级模块名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        //            if (!ExpressionValidat.IsNumeric(e.FormattedValue.ToString()))
        //            {
        //                MessageBoxEx.Show("排序号必须为数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //            break;
        //    }

        //}

        private void GvFunClassThree_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gv = (DataGridView)sender;
            if (gv.Columns[e.ColumnIndex].Name == "Operate")
            {
                if (e.RowIndex < rowcount - 1)
                {
                    if (DialogResult.OK == MessageBoxEx.Show(" 确认要删除" + gv.Rows[e.RowIndex].Cells["MODEL_NAME"].Value + "吗", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk))
                    {
                        if (BSysFun.Delete(" where MODEL_ID='" + gv.Rows[e.RowIndex].Cells["MODEL_ID"].Value.ToString() + "'") >= 0)
                        {
                            MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GetClassThreeModel();//刷新表格
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

        private void SetDataGridViewRowEditModel(int Index)
        {
            GvFunClassThree.ReadOnly = false;
            foreach (DataGridViewRow dr in GvFunClassThree.Rows)
                dr.ReadOnly = true;

            if (Index >= 0)
            {
                GvFunClassThree.Rows[Index].ReadOnly = false;
                GvFunClassThree.Rows[Index].Cells["MODEL_ID"].ReadOnly = true;
            }
        }
    }
}