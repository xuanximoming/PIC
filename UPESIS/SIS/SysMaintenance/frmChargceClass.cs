using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using System.Collections;
using SIS_BLL;
using SIS.Function;
using SIS_Model;

namespace SIS.SysMaintenance
{
    public partial class frmChargeClass : Form
    {

        private BGetSeqValue ID = new BGetSeqValue("SIS", "SEQ_CHARGE_CLASS_ID");
        private BChargeClass bChgCls = new BChargeClass();

        private int RowCount; //记录未新增前网格的行数
        private Hashtable htRow = new Hashtable();//记录修改的行号
        private int i = 0; //记录一次性修改的行数

        public frmChargeClass()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            CreateNewRow();
        }

        private void CreateNewRow()
        {
            this.dgv_ChargeClass.Visible = true;
            this.gb_PromptInfo.Visible = false;
            DataTable dt = (DataTable)dgv_ChargeClass.DataSource;
            if (dt == null)
                dgv_ChargeClass.Rows.Add();
            else
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                dgv_ChargeClass.DataSource = dt;
            }
            dgv_ChargeClass.Rows[dgv_ChargeClass.Rows.Count - 1].Cells["CHARGE_CLASS_ID"].Value = ID.GetSeqValue();
            this.dgv_ChargeClass.CurrentCell = dgv_ChargeClass.Rows[dgv_ChargeClass.Rows.Count - 1].Cells["CHARGE_CLASS_ID"];
            dgv_ChargeClass.Rows[dgv_ChargeClass.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Linen;
            SetDataGridViewRowEditModel(dgv_ChargeClass.Rows.Count - 1);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

            bool bl1 = SaveData();
            bool bl2 = EditData();

            if (bl1 | bl2) BindCharge("");
            dgv_ChargeClass.ReadOnly = true;
        }

        private bool SaveData()
        {
            Hashtable ht = new Hashtable();
            if (dgv_ChargeClass.Rows.Count > RowCount-1)//说明有新增行
            {
                for (int i = RowCount, j = 0; i <= dgv_ChargeClass.Rows.Count && j < dgv_ChargeClass.Rows.Count; i++, j++)//从第rowcount个开始保存
                {
                    MChargeClass MchgCls = new MChargeClass();
                    MchgCls.CHARGE_CLASS_ID = Convert.ToInt32(dgv_ChargeClass.Rows[i - 1].Cells["CHARGE_CLASS_ID"].Value.ToString());
                    MchgCls.CHARGE_CLASS = dgv_ChargeClass.Rows[i - 1].Cells["CHARGE_CLASS"].Value.ToString().Trim();

                    try
                    {
                        MchgCls.CHARGE_RATIO = Convert.ToInt32(dgv_ChargeClass.Rows[i - 1].Cells["CHARGE_RATIO"].Value.ToString());
                    }
                    catch
                    {
                    }
                    ht.Add(j, MchgCls);
                }
            }
            if (ht.Count > 0)
            {
                if (bChgCls.AddMore(ht) > 0)
                {
                    MessageBoxEx.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBoxEx.Show("添加失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
                return false;
        }

        private bool EditData()
        {
            Hashtable htEdit = new Hashtable();
            int k = 0;
            if (htRow.Count > 0)
            {
                foreach (DictionaryEntry myDE in htRow)
                {
                    int r = Convert.ToInt32(myDE.Value);
                    MChargeClass MchgCls = new MChargeClass();
                    MchgCls.CHARGE_CLASS_ID = Convert.ToInt32(dgv_ChargeClass.Rows[r].Cells["CHARGE_CLASS_ID"].Value.ToString());
                    MchgCls.CHARGE_CLASS = dgv_ChargeClass.Rows[r].Cells["CHARGE_CLASS"].Value.ToString().Trim();

                    try
                    {
                        MchgCls.CHARGE_RATIO = Convert.ToInt32(dgv_ChargeClass.Rows[r].Cells["CHARGE_RATIO"].Value.ToString());
                    }
                    catch
                    {
                    }
                    htEdit.Add(k, MchgCls);
                    k += 1;
                }

                htRow.Clear();
                i = 0;

                if (bChgCls.UpdateMore(htEdit) >= 0)
                {
                    MessageBoxEx.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBoxEx.Show("修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
                return false;
                
        }

        private void dgv_ChargceClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv_ImgEqument = (DataGridView)sender;
            if (dgv_ImgEqument.Columns[e.ColumnIndex].Name == "Operate")
            {
                if (e.RowIndex < RowCount - 1)
                {
                    if (DialogResult.OK == MessageBoxEx.Show("确认要删除" + dgv_ImgEqument.Rows[e.RowIndex].Cells["CHARGE_CLASS"].Value + "吗", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk))
                    {
                        if (bChgCls.Delete(" where CHARGE_CLASS_ID=" + dgv_ImgEqument.Rows[e.RowIndex].Cells["CHARGE_CLASS_ID"].Value.ToString()) >= 0)
                            BindCharge("");//刷新表格
                        else
                            MessageBoxEx.Show("删除失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (!dgv_ImgEqument.Rows[e.RowIndex].IsNewRow)
                        dgv_ImgEqument.Rows.RemoveAt(e.RowIndex);
                }
            }

            if (dgv_ImgEqument.Columns[e.ColumnIndex].Name == "Edit")//修改历史数据
            {
                SetDataGridViewRowEditModel(e.RowIndex);
                dgv_ImgEqument.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
                htRow.Add(i++, e.RowIndex.ToString());
            }
        }

        private void dgv_ChargceClass_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void BindCharge(string strConDiTion)
        {
            DataTable dt = bChgCls.GetList(strConDiTion + "1=1 order by CHARGE_CLASS_ID");
            if (dt != null)
            {
                dgv_ChargeClass.DataSource = dt;
                RowCount = dt.Rows.Count + 1;
            }
        }

        private void ChargeClass_Load(object sender, EventArgs e)
        {
            this.btn_FunName.Text = this.Text.ToString();
            RowCount = this.dgv_ChargeClass.Rows.Count;
            dgv_ChargeClass.AutoGenerateColumns = false;

            BindCharge("");

            if (dgv_ChargeClass.Rows.Count > 0)
                gb_PromptInfo.Visible = false;
            else
                gb_PromptInfo.Visible = true;

            dgv_ChargeClass.ReadOnly = true;
        }

        //设置网格中行的编辑状态
        //输入参数:Index-可编辑行的索引;
        private void SetDataGridViewRowEditModel(int Index)
        {
            dgv_ChargeClass.ReadOnly = false;
            foreach (DataGridViewRow dr in dgv_ChargeClass.Rows)
                dr.ReadOnly = true;


            if (Index >= 0)
            {
                dgv_ChargeClass.Rows[Index].ReadOnly = false;
                dgv_ChargeClass.Rows[Index].Cells["CHARGE_CLASS_ID"].ReadOnly = true;
            }
        }

        private void txt_CHARGE_CLASS_TextChanged(object sender, EventArgs e)
        {
            if (txt_CHARGE_CLASS.Text == "")
                BindCharge("");
            else
                BindCharge("CHARGE_CLASS like '%" + txt_CHARGE_CLASS.Text + "%'and ");
        }
    }
}