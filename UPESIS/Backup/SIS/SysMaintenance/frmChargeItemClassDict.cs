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
    public partial class frmChargeItemClassDict : Form
    {
        private BChargeItemClassDict BChgItmClsDit = new BChargeItemClassDict();

        private int RowCount; //记录未新增前网格的行数
        private Hashtable htRow = new Hashtable();//记录修改的行号
        private int i = 0; //记录一次性修改的行数

        public frmChargeItemClassDict()
        {
            InitializeComponent();
        }

        private void ChargeItemClassDict_Load(object sender, EventArgs e)
        {
            this.btn_FunName.Text = this.Text.ToString();
            dgv_ChargeItemClassDict.AutoGenerateColumns = false;

            BindChargeItemClassDict("");

            if (dgv_ChargeItemClassDict.Rows.Count > 0)
                gb_PromptInfo.Visible = false;
            else
                gb_PromptInfo.Visible = true;

            dgv_ChargeItemClassDict.ReadOnly = true;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            CreateNewRow();
        }

        private void CreateNewRow()
        {
            this.dgv_ChargeItemClassDict.Visible = true;
            this.gb_PromptInfo.Visible = false;
            DataTable dt = (DataTable)dgv_ChargeItemClassDict.DataSource;
            if (dt == null)
                dgv_ChargeItemClassDict.Rows.Add();
            else
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                dgv_ChargeItemClassDict.DataSource = dt;
            }

            this.dgv_ChargeItemClassDict.CurrentCell = dgv_ChargeItemClassDict.Rows[dgv_ChargeItemClassDict.Rows.Count - 1].Cells["CLASS_CODE"];
            dgv_ChargeItemClassDict.Rows[dgv_ChargeItemClassDict.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Linen;
            SetDataGridViewRowEditModel(dgv_ChargeItemClassDict.Rows.Count - 1);
            dgv_ChargeItemClassDict.Rows[dgv_ChargeItemClassDict.Rows.Count - 1].Cells["CLASS_CODE"].ReadOnly = false;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            bool bl1 = SaveData();
            bool bl2 = EditData();
            
            if (bl1 | bl2)
                BindChargeItemClassDict("");

            dgv_ChargeItemClassDict.ReadOnly = true;
        }


        private bool SaveData()
        {
            Hashtable ht = new Hashtable();
            if (dgv_ChargeItemClassDict.Rows.Count > RowCount-1)//说明有新增行
            {
                for (int i = RowCount, j = 0; i <= dgv_ChargeItemClassDict.Rows.Count && j < dgv_ChargeItemClassDict.Rows.Count; i++, j++)//从第rowcount个开始保存
                {
                    MChargeItemClassDict MchgItmClsDit = new MChargeItemClassDict();
                    MchgItmClsDit.CLASS_CODE = dgv_ChargeItemClassDict.Rows[i - 1].Cells["CLASS_CODE"].Value.ToString().Trim();
                    MchgItmClsDit.CLASS_NAME = dgv_ChargeItemClassDict.Rows[i - 1].Cells["CLASS_NAME"].Value.ToString().Trim();
                    ht.Add(j, MchgItmClsDit);
                }
            }
            if (ht.Count > 0)
            {
                if (BChgItmClsDit.AddMore(ht) > 0)
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

        /// <summary>
        /// 批量修改
        /// </summary>
        private bool EditData()
        {
            Hashtable htEdit = new Hashtable();
            int k = 0;
            if (htRow.Count > 0)
            {
                foreach (DictionaryEntry myDE in htRow)
                {
                    int r = Convert.ToInt32(myDE.Value);
                    MChargeItemClassDict MchgItmClsDit = new MChargeItemClassDict();
                    MchgItmClsDit.CLASS_CODE = dgv_ChargeItemClassDict.Rows[r].Cells["CLASS_CODE"].Value.ToString().Trim();
                    MchgItmClsDit.CLASS_NAME = dgv_ChargeItemClassDict.Rows[r].Cells["CLASS_NAME"].Value.ToString().Trim();
                    htEdit.Add(k, MchgItmClsDit);
                    k += 1;
                }

                htRow.Clear();
                i = 0;

                if (BChgItmClsDit.UpdateMore(htEdit) >= 0)
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

        private void dgv_ChargeItemClassDict_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv_ImgEqument = (DataGridView)sender;
            if (dgv_ImgEqument.Columns[e.ColumnIndex].Name == "Operate")
            {
                if (e.RowIndex < RowCount - 1)
                {
                    if (DialogResult.OK == MessageBoxEx.Show("确认要删除" + dgv_ImgEqument.Rows[e.RowIndex].Cells["CLASS_NAME"].Value + "吗", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk))
                    {
                        if (BChgItmClsDit.Delete(" where CLASS_CODE='" + dgv_ImgEqument.Rows[e.RowIndex].Cells["CLASS_CODE"].Value.ToString() + "'") >= 0)
                            BindChargeItemClassDict("");//刷新表格
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

        private void dgv_ChargeItemClassDict_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void BindChargeItemClassDict(string strConDiTion)
        {
            DataTable dt = BChgItmClsDit.GetList(strConDiTion + "1=1 order by CLASS_CODE");
            if (dt != null)
                dgv_ChargeItemClassDict.DataSource = dt;

            RowCount = dt.Rows.Count + 1;
        }

        private void SetDataGridViewRowEditModel(int Index)
        {
            dgv_ChargeItemClassDict.ReadOnly = false;
            foreach (DataGridViewRow dr in dgv_ChargeItemClassDict.Rows)
                dr.ReadOnly = true;

            if (Index >= 0)
            {
                dgv_ChargeItemClassDict.Rows[Index].ReadOnly = false;
                dgv_ChargeItemClassDict.Rows[Index].Cells["CLASS_CODE"].ReadOnly = true;
            }
        }

    }
}