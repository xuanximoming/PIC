using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ILL;
using SIS_BLL;
using SIS_Model;
using System.Data.OracleClient;
using System.Data.OleDb;
using SIS.Function;

namespace SIS.SysMaintenance
{
    public partial class frmDeptManage : Form
    {
        private BGetSeqValue ID = new BGetSeqValue("SIS", "SEQ_CLINIC_OFFICE_ID");
        private Hashtable htRow = new Hashtable();//记录修改的行号
        private int i = 0;
        private DataTable dt;
        private int rowcount;
        private BClinicOfficeDict BOfficeDict = new BClinicOfficeDict();
        private BPatientSource BPatientSou = new BPatientSource();
        public static frmDeptManage forDm;
        public frmDeptManage()
        {
            InitializeComponent();
            this.GvDept.AutoGenerateColumns = false;
        }

        private void DeptManage_Load(object sender, EventArgs e)
        {
            this.btnFunName.Text = this.Text.ToString();
            BindDept();
            forDm = this;
            BindPatientSource();
            GvDept.ReadOnly = true;
        }

        public void BindPatientSource()
        {
            dt = BPatientSou.GetList("  1=1 ");
            DataRow dr = dt.NewRow();
            //dr[0] = 0;
            dr["PATIENT_SOURCE"] ="\t";
            dr["PATIENT_SOURCE_ID"] =0;
            dt.Rows.InsertAt(dr, 0);
            if (dt.Rows.Count > 0)
            {
                ((DataGridViewComboBoxColumn)this.GvDept.Columns["PATIENT_SOURCE_ID"]).DataSource = dt;
                ((DataGridViewComboBoxColumn)this.GvDept.Columns["PATIENT_SOURCE_ID"]).DisplayMember = "PATIENT_SOURCE";
                ((DataGridViewComboBoxColumn)this.GvDept.Columns["PATIENT_SOURCE_ID"]).ValueMember = "PATIENT_SOURCE_ID";
            }
        }

        public void BindDept()//绑定科室
        {
            DataTable dt = BOfficeDict.GetList(" 1=1 ORDER BY CLINIC_OFFICE_ID ");
            this.GvDept.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                this.GvDept.Visible = true;
                this.gb_PromptInfo.Visible = false;
            }
            else
            {
                this.GvDept.Visible = false;
                this.gb_PromptInfo.Visible = true;
            }
            rowcount = GvDept.Rows.Count + 1;
        }

        private void GvDept_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            switch (GvDept.Columns[e.ColumnIndex].Name)
            {
                case "DEPT_CODE":
                    if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                    {
                        MessageBoxEx.Show("科室编码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                    }
                    break;
                case "CLINIC_OFFICE":
                    if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                    {
                        MessageBoxEx.Show("科室名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                    }
                    break;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData() && EditData())
            {
                BindDept();
                GvDept.ReadOnly = true;
            }
        }

        private bool SaveData()//批量保存
        {
            Hashtable ht = new Hashtable();
            if (GvDept.Rows.Count > rowcount-1)//说明有新增行
            {
                for (int i = rowcount, j = 0; i <= GvDept.Rows.Count && j < GvDept.Rows.Count; i++, j++)//从第rowcount个开始保存
                {
                    MClinicOfficeDict MOfficeDict = new MClinicOfficeDict();
                    MOfficeDict.CLINIC_OFFICE_ID = Convert.ToInt32(GvDept.Rows[i - 1].Cells["CLINIC_OFFICE_ID"].Value.ToString());
                    if (!string.IsNullOrEmpty(GvDept.Rows[i - 1].Cells["CLINIC_OFFICE"].Value.ToString().Trim()))
                        MOfficeDict.CLINIC_OFFICE = GvDept.Rows[i - 1].Cells["CLINIC_OFFICE"].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(GvDept.Rows[i - 1].Cells["PATIENT_SOURCE_ID"].Value.ToString()))
                        MOfficeDict.PATIENT_SOURCE_ID = Convert.ToInt32(((DataGridViewComboBoxCell)GvDept.Rows[i - 1].Cells["PATIENT_SOURCE_ID"]).Value.ToString());
                    if (!string.IsNullOrEmpty(GvDept.Rows[i - 1].Cells["CLINIC_OFFICE_CODE"].Value.ToString().Trim()))
                        MOfficeDict.CLINIC_OFFICE_CODE = GvDept.Rows[i - 1].Cells["CLINIC_OFFICE_CODE"].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(GvDept.Rows[i - 1].Cells["CLINIC_OFFICE_FLAG"].Value.ToString().Trim()))
                        MOfficeDict.CLINIC_OFFICE_FLAG = GvDept.Rows[i - 1].Cells["CLINIC_OFFICE_FLAG"].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(GvDept.Rows[i - 1].Cells["STUDY_UID_HEADER"].Value.ToString().Trim()))
                        MOfficeDict.STUDY_UID_HEADER = GvDept.Rows[i - 1].Cells["STUDY_UID_HEADER"].Value.ToString().Trim();
                    if (ExpressionValidat.IsNumeric(GvDept.Rows[i - 1].Cells["CUR_SERIAL_NUM"].Value.ToString()))
                        MOfficeDict.CUR_SERIAL_NUM = Convert.ToInt32(GvDept.Rows[i - 1].Cells["CUR_SERIAL_NUM"].Value.ToString());
                    if (!string.IsNullOrEmpty(GvDept.Rows[i - 1].Cells["CLINIC_OFFICE_PYCODE"].Value.ToString()))
                        MOfficeDict.CLINIC_OFFICE_PYCODE = GvDept.Rows[i - 1].Cells["CLINIC_OFFICE_PYCODE"].Value.ToString().Trim();

                    ht.Add(j, MOfficeDict);
                }
            }
            if (ht.Count > 0)
            {
                if (BOfficeDict.AddMore(ht) > 0)
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
                    MClinicOfficeDict MOfficeDict = new MClinicOfficeDict();
                    MOfficeDict.CLINIC_OFFICE_ID = Convert.ToInt32(GvDept.Rows[r].Cells["CLINIC_OFFICE_ID"].Value.ToString());
                    if (!string.IsNullOrEmpty(GvDept.Rows[r].Cells["CLINIC_OFFICE"].Value.ToString().Trim()))
                        MOfficeDict.CLINIC_OFFICE = GvDept.Rows[r].Cells["CLINIC_OFFICE"].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(GvDept.Rows[r].Cells["PATIENT_SOURCE_ID"].Value.ToString()))
                        MOfficeDict.PATIENT_SOURCE_ID = Convert.ToInt32(((DataGridViewComboBoxCell)GvDept.Rows[r].Cells["PATIENT_SOURCE_ID"]).Value.ToString());
                    if (!string.IsNullOrEmpty(GvDept.Rows[r].Cells["CLINIC_OFFICE_CODE"].Value.ToString().Trim()))
                        MOfficeDict.CLINIC_OFFICE_CODE = GvDept.Rows[r].Cells["CLINIC_OFFICE_CODE"].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(GvDept.Rows[r].Cells["CLINIC_OFFICE_FLAG"].Value.ToString().Trim()))
                        MOfficeDict.CLINIC_OFFICE_FLAG = GvDept.Rows[r].Cells["CLINIC_OFFICE_FLAG"].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(GvDept.Rows[r].Cells["STUDY_UID_HEADER"].Value.ToString().Trim()))
                        MOfficeDict.STUDY_UID_HEADER = GvDept.Rows[r].Cells["STUDY_UID_HEADER"].Value.ToString().Trim();
                    if (ExpressionValidat.IsNumeric(GvDept.Rows[r].Cells["CUR_SERIAL_NUM"].Value.ToString()))
                        MOfficeDict.CUR_SERIAL_NUM = Convert.ToInt32(GvDept.Rows[r].Cells["CUR_SERIAL_NUM"].Value.ToString());
                    if (!string.IsNullOrEmpty(GvDept.Rows[r].Cells["CLINIC_OFFICE_PYCODE"].Value.ToString()))
                        MOfficeDict.CLINIC_OFFICE_PYCODE = GvDept.Rows[r].Cells["CLINIC_OFFICE_PYCODE"].Value.ToString().Trim();

                    htEdit.Add(k, MOfficeDict);
                }
                if (BOfficeDict.UpdateMore(htEdit) >= 0)
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

        private void GvDept_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gv = (DataGridView)sender;
            if (gv.Columns[e.ColumnIndex].Name == "Operate")
            {
                if (e.RowIndex < rowcount - 1)
                {
                    if (DialogResult.OK == MessageBoxEx.Show("确认要删除" + gv.Rows[e.RowIndex].Cells["CLINIC_OFFICE"].Value + "吗", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk))
                    {
                        if (BOfficeDict.Delete(" where CLINIC_OFFICE_ID=" + Convert.ToInt32(gv.Rows[e.RowIndex].Cells["CLINIC_OFFICE_ID"].Value.ToString())) >= 0)
                            BindDept();//刷新表格
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

        private void GvDept_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GvDept.Visible = true;
            gb_PromptInfo.Visible = false;

            DataTable dt = (DataTable)GvDept.DataSource;
            if (dt == null)
                GvDept.Rows.Add();
            else
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                GvDept.DataSource = dt;
            }
            GvDept.Rows[GvDept.Rows.Count - 1].Cells["CLINIC_OFFICE_ID"].Value = ID.GetSeqValue();
            GvDept.CurrentCell = GvDept.Rows[GvDept.Rows.Count - 1].Cells["CLINIC_OFFICE_ID"];
            GvDept.Rows[GvDept.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Linen;
            SetDataGridViewRowEditModel(GvDept.Rows.Count - 1);
        }

        private void btn_NewPatientSou_Click(object sender, EventArgs e)
        {
            frmPatientSource forPS = new frmPatientSource();
            forPS.ShowDialog();
        }

        //设置网格中行的编辑状态
        //输入参数:Index-可编辑行的索引;
        private void SetDataGridViewRowEditModel(int Index)
        {
            GvDept.ReadOnly = false;
            foreach (DataGridViewRow dr in GvDept.Rows)
                dr.ReadOnly = true;

            if (Index >= 0)
            {
                GvDept.Rows[Index].ReadOnly = false;
                GvDept.Rows[Index].Cells["CLINIC_OFFICE_ID"].ReadOnly = true;
            }
        }

    }

}