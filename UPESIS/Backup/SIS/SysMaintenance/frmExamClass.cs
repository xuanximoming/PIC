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
namespace SIS.SysMaintenance
{
    public partial class frmExamClass : Form
    {
        private BExamClass BExamCla = new BExamClass();
        private Hashtable htRow = new Hashtable();//记录修改的行号
        private int i = 0;
        private int rowcount;

        public frmExamClass()
        {
            InitializeComponent();
            this.dgv_ExamClass.AutoGenerateColumns = false;
        }

        private void ExamClass_Load(object sender, EventArgs e)
        {
            this.btnFunName.Text = this.Text;
            Find_EXAM_CLASS();
            dgv_ExamClass.ReadOnly = true;
        }

        private void Find_EXAM_CLASS()
        {
            string sql = "";
            if (txt_EXAM_CLASS.Text.Trim() != "")
            {
                if (txt_EXAM_SUB_CLASS.Text.Trim() != "")
                    sql = " EXAM_CLASS like '%" + txt_EXAM_CLASS.Text.Trim() + "%' and EXAM_SUB_CLASS like '%" + txt_EXAM_SUB_CLASS.Text.Trim() + "%' and ";
                else
                    sql = " EXAM_CLASS like '%" + txt_EXAM_CLASS.Text.Trim() + "%' and ";
            }
            else
            {
                if (txt_EXAM_SUB_CLASS.Text.Trim() != "")
                    sql = " EXAM_SUB_CLASS like '%" + txt_EXAM_SUB_CLASS.Text.Trim() + "%' and ";
            }
            sql += " EXAM_CLASS in ('" + ILL.GetConfig.ExamClass.Replace(",", "','") + "') and";

            DataTable dt = BExamCla.GetList(sql + " 1=1 ORDER BY SORT_ID");
            this.dgv_ExamClass.DataSource = dt;

            if (dt.Rows.Count > 0)
            {                
                this.dgv_ExamClass.Visible = true;
                this.gb_PromptInfo.Visible = false;
            }
            else
            {
                this.dgv_ExamClass.Visible = false;
                this.gb_PromptInfo.Visible = true;
            }
            rowcount = this.dgv_ExamClass.Rows.Count +1;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            dgv_ExamClass.Visible = true;
            gb_PromptInfo.Visible = false;

            DataTable dt = (DataTable)dgv_ExamClass.DataSource;
            if (dt == null)
                dgv_ExamClass.Rows.Add();
            else
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                dgv_ExamClass.DataSource = dt;
            }
            dgv_ExamClass.CurrentCell = dgv_ExamClass.Rows[dgv_ExamClass.Rows.Count - 1].Cells["EXAM_CLASS"];
            dgv_ExamClass.Rows[dgv_ExamClass.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Linen;
            SetDataGridViewRowEditModel(dgv_ExamClass.Rows.Count - 1);
            dgv_ExamClass.Rows[dgv_ExamClass.Rows.Count - 1].Cells["EXAM_CLASS"].ReadOnly = false;
            dgv_ExamClass.Rows[dgv_ExamClass.Rows.Count - 1].Cells["EXAM_SUB_CLASS"].ReadOnly = false;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveData();
            EditData();
            Find_EXAM_CLASS();//刷新表格
            dgv_ExamClass.ReadOnly = true;
        }

        private void SaveData()//批量保存
        {
            Hashtable ht = new Hashtable();
            if (dgv_ExamClass.Rows.Count > rowcount-1)//说明有新增行
            {
                for (int i = rowcount, j = 0; i <= dgv_ExamClass.Rows.Count && j < dgv_ExamClass.Rows.Count; i++, j++)//从第rowcount个开始保存
                {
                    MExamClass MExamCla = new MExamClass();
                    if (!string.IsNullOrEmpty(dgv_ExamClass.Rows[i - 1].Cells["EXAM_CLASS"].FormattedValue.ToString()))
                    {
                        MExamCla.EXAM_CLASS = dgv_ExamClass.Rows[i - 1].Cells["EXAM_CLASS"].Value.ToString();
                    }
                    else
                    {
                        MessageBoxEx.Show("项目类别不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (!string.IsNullOrEmpty(dgv_ExamClass.Rows[i - 1].Cells["EXAM_SUB_CLASS"].FormattedValue.ToString()))
                    {
                        MExamCla.EXAM_SUB_CLASS = dgv_ExamClass.Rows[i - 1].Cells["EXAM_SUB_CLASS"].Value.ToString();
                    }
                    else
                    {
                        MessageBoxEx.Show("检查子类不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (!string.IsNullOrEmpty(dgv_ExamClass.Rows[i - 1].Cells["DICOM_MODALITY"].FormattedValue.ToString()))
                        MExamCla.DICOM_MODALITY = dgv_ExamClass.Rows[i - 1].Cells["DICOM_MODALITY"].Value.ToString();
                    if (!string.IsNullOrEmpty(dgv_ExamClass.Rows[i - 1].Cells["LOCAL_ID_CLASS"].FormattedValue.ToString()))
                        MExamCla.LOCAL_ID_CLASS = dgv_ExamClass.Rows[i - 1].Cells["LOCAL_ID_CLASS"].Value.ToString();
                    if (!string.IsNullOrEmpty(dgv_ExamClass.Rows[i - 1].Cells["TAG_IMAGE_NAME"].FormattedValue.ToString()))
                        MExamCla.TAG_IMAGE_NAME = dgv_ExamClass.Rows[i - 1].Cells["TAG_IMAGE_NAME"].Value.ToString();
                    if (!string.IsNullOrEmpty(dgv_ExamClass.Rows[i - 1].Cells["DEVICE"].FormattedValue.ToString()))
                        MExamCla.DEVICE = dgv_ExamClass.Rows[i - 1].Cells["DEVICE"].Value.ToString();
                    if (!string.IsNullOrEmpty(dgv_ExamClass.Rows[i - 1].Cells["SORT_ID"].FormattedValue.ToString()))
                        MExamCla.SORT_ID =Convert.ToInt16( dgv_ExamClass.Rows[i - 1].Cells["SORT_ID"].Value);

                    bool BL = BExamCla.Exists(MExamCla);
                    if (BL)
                    {
                        MessageBoxEx.Show("存在相同的检查类别和子类！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    ht.Add(j, MExamCla);
                }
            }
            if (ht.Count > 0)
            {
                if (BExamCla.AddMore(ht) > 0)
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
                    MExamClass MExamCla = new MExamClass();

                    if (!string.IsNullOrEmpty(dgv_ExamClass.Rows[r].Cells["EXAM_CLASS"].FormattedValue.ToString()))
                    {
                        MExamCla.EXAM_CLASS = dgv_ExamClass.Rows[r].Cells["EXAM_CLASS"].Value.ToString();
                    }
                    else
                    {
                        MessageBoxEx.Show("项目类别不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (!string.IsNullOrEmpty(dgv_ExamClass.Rows[r].Cells["EXAM_SUB_CLASS"].FormattedValue.ToString()))
                    {
                        MExamCla.EXAM_SUB_CLASS = dgv_ExamClass.Rows[r].Cells["EXAM_SUB_CLASS"].Value.ToString();
                    }
                    else
                    {
                        MessageBoxEx.Show("检查子类不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (!string.IsNullOrEmpty(dgv_ExamClass.Rows[r].Cells["DICOM_MODALITY"].FormattedValue.ToString()))
                        MExamCla.DICOM_MODALITY = dgv_ExamClass.Rows[r].Cells["DICOM_MODALITY"].Value.ToString();
                    if (!string.IsNullOrEmpty(dgv_ExamClass.Rows[r].Cells["LOCAL_ID_CLASS"].FormattedValue.ToString()))
                        MExamCla.LOCAL_ID_CLASS = dgv_ExamClass.Rows[r].Cells["LOCAL_ID_CLASS"].Value.ToString();
                    if (!string.IsNullOrEmpty(dgv_ExamClass.Rows[r].Cells["TAG_IMAGE_NAME"].FormattedValue.ToString()))
                        MExamCla.TAG_IMAGE_NAME = dgv_ExamClass.Rows[r].Cells["TAG_IMAGE_NAME"].Value.ToString();
                    if (!string.IsNullOrEmpty(dgv_ExamClass.Rows[r].Cells["DEVICE"].FormattedValue.ToString()))
                        MExamCla.DEVICE = dgv_ExamClass.Rows[r].Cells["DEVICE"].Value.ToString();
                    if (!string.IsNullOrEmpty(dgv_ExamClass.Rows[r].Cells["SORT_ID"].FormattedValue.ToString()))
                        MExamCla.SORT_ID = Convert.ToInt16(dgv_ExamClass.Rows[r].Cells["SORT_ID"].Value);

                    htEdit.Add(k, MExamCla);
                }
                if (BExamCla.UpdateMore(htEdit) >= 0)
                    MessageBoxEx.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBoxEx.Show("修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            htRow.Clear();
            i = 0;
        }

        //private void dgv_ExamClass_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        //    DataGridView dgv_ExamClass = (DataGridView)sender;

        //    switch (dgv_ExamClass.Columns[e.ColumnIndex].Name)
        //    {
        //        case "EXAM_SUB_CLASS":

        //            if (!String.IsNullOrEmpty(e.FormattedValue.ToString()))
        //            {
        //                DataTable dt = (DataTable)dgv_ExamClass.DataSource;
        //                if (dt != null)
        //                {
        //                    DataRow[] dr = dt.Select("EXAM_CLASS='" + dgv_ExamClass.Rows[e.RowIndex].Cells["EXAM_CLASS"].Value.ToString().Trim() + "' and EXAM_SUB_CLASS='" + e.FormattedValue.ToString().Trim() + "'");
        //                    if (dr.Length > 0)
        //                    {
        //                        MessageBoxEx.Show("存在相同的检查类别和子类！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        e.Cancel = true;
        //                    }

        //                    //for (int i = 0; i < dt.Rows.Count; i++)
        //                    //{
        //                    //    if (dt.Rows[i]["EXAM_CLASS"].ToString().Trim() == dgv_ExamClass.Rows[e.RowIndex].Cells["EXAM_CLASS"].Value.ToString().Trim() && dt.Rows[i]["EXAM_SUB_CLASS"].ToString().Trim() == e.FormattedValue.ToString().Trim())
        //                    //    {
        //                    //        MessageBoxEx.Show("存在相同的检查类别和子类！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    //        e.Cancel = true;
        //                    //        break;
        //                    //    }
        //                }
        //            }
        //            break;
        //    }
        //}

        private void dgv_ExamClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gv = (DataGridView)sender;
            if (gv.Columns[e.ColumnIndex].Name == "Operate")
            {
                if (e.RowIndex < rowcount - 1)
                {
                    if (DialogResult.OK == MessageBoxEx.Show("确认要删除吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk))
                    {
                        if (BExamCla.Delete(" where EXAM_CLASS='" + gv.Rows[e.RowIndex].Cells["EXAM_CLASS"].Value.ToString() + "' and EXAM_SUB_CLASS='" + gv.Rows[e.RowIndex].Cells["EXAM_SUB_CLASS"].Value.ToString() + "'") >= 0)
                        {
                            MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Find_EXAM_CLASS();//刷新表格
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

        private void txt_EXAM_CLASS_TextChanged(object sender, EventArgs e)
        {
            Find_EXAM_CLASS();
        }

        private void txt_EXAM_SUB_CLASS_TextChanged(object sender, EventArgs e)
        {
            Find_EXAM_CLASS();
        }


        //设置网格中行的编辑状态
        //输入参数:Index-可编辑行的索引;
        private void SetDataGridViewRowEditModel(int Index)
        {
            dgv_ExamClass.ReadOnly = false;
            foreach (DataGridViewRow dr in dgv_ExamClass.Rows)
                dr.ReadOnly = true;

            if (Index >= 0)
            {
                dgv_ExamClass.Rows[Index].ReadOnly = false;
                dgv_ExamClass.Rows[Index].Cells["EXAM_CLASS"].ReadOnly = true;
                dgv_ExamClass.Rows[Index].Cells["EXAM_SUB_CLASS"].ReadOnly = true;
            }
        }
    }
}