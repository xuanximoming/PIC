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
    public partial class frmDoctorInfo : Form
    {
        private BGetSeqValue ID = new BGetSeqValue("SIS", "SEQ_CLINIC_DOCTOR_ID");
        private BClinicOfficeDict BOfficeDict = new BClinicOfficeDict();
        private BClinicDoctorDict BDoctorDict = new BClinicDoctorDict();
        private int rowcount;
        private Hashtable htRow = new Hashtable();//记录修改的行号
        private int i = 0;

        public frmDoctorInfo()
        {
            InitializeComponent();
            this.dgv_Doctor.AutoGenerateColumns = false;
        }

        private void DoctorInfo_Load(object sender, EventArgs e)
        {
            this.btnFunName.Text = this.Text.ToString();
            BindDept();
            BindDoctorInfo();
        }

        private void BindDept()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CLINIC_OFFICE", typeof(string));
            dt.Columns.Add("CLINIC_OFFICE_CODE", typeof(decimal));
            DataRow dr = dt.NewRow();
            dr["CLINIC_OFFICE"] = ILL.GetConfig.ExamDeptName;
            dr["CLINIC_OFFICE_CODE"] = Convert.ToDecimal(ILL.GetConfig.ExamDeptCode);
            dt.Rows.Add(dr);
            ((DataGridViewComboBoxColumn)dgv_Doctor.Columns["CLINIC_OFFICE_ID"]).DataSource = dt;
            ((DataGridViewComboBoxColumn)dgv_Doctor.Columns["CLINIC_OFFICE_ID"]).DisplayMember = "CLINIC_OFFICE";
            ((DataGridViewComboBoxColumn)dgv_Doctor.Columns["CLINIC_OFFICE_ID"]).ValueMember = "CLINIC_OFFICE_CODE";
        }

        private void BindDoctorInfo()
        {
            string sqlstr;
            if (txt_Doctor_Name.Text.Trim() == "")
                sqlstr = " b.CLINIC_OFFICE_CODE='" + ILL.GetConfig.ExamDeptCode + "' ORDER BY CLINIC_DOCTOR_ID";
            else
                sqlstr = " a.CLINIC_DOCTOR like '%" + txt_Doctor_Name.Text.Trim() + "%' and b.CLINIC_OFFICE_CODE='" + ILL.GetConfig.ExamDeptCode + "' ORDER BY CLINIC_DOCTOR_ID";
            DataTable dt = BDoctorDict.GetList2(sqlstr);
            this.dgv_Doctor.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                this.dgv_Doctor.Visible = true;
                this.gb_PromptInfo.Visible = false;
            }
            else
            {
                this.dgv_Doctor.Visible = false;
                this.gb_PromptInfo.Visible = true;
            }
            rowcount = this.dgv_Doctor.Rows.Count + 1;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            dgv_Doctor.Visible = true;
            this.gb_PromptInfo.Visible = false;
            DataTable dt = (DataTable)dgv_Doctor.DataSource;
            if (dt == null)
                dgv_Doctor.Rows.Add();
            else
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                dgv_Doctor.DataSource = dt;
            }

            dgv_Doctor.Rows[dgv_Doctor.Rows.Count - 1].Cells["CLINIC_DOCTOR_ID"].Value = ID.GetSeqValue(); ;

            this.dgv_Doctor.CurrentCell = dgv_Doctor.Rows[dgv_Doctor.Rows.Count - 1].Cells["CLINIC_DOCTOR"];
            dgv_Doctor.Rows[dgv_Doctor.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Linen;
            SetDataGridViewRowEditModel(dgv_Doctor.Rows.Count - 1);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (SaveData() && EditData())
            {
                BindDoctorInfo();//刷新表格
                dgv_Doctor.ReadOnly = true;
            }
        }

        private bool SaveData()
        {
            Hashtable ht = new Hashtable();
            if (dgv_Doctor.Rows.Count > rowcount - 1)//说明有新增行
            {
                for (int i = rowcount, j = 0; i < dgv_Doctor.Rows.Count + 1 && j < dgv_Doctor.Rows.Count; i++, j++)//从第rowcount个开始保存
                {
                    MClinicDoctorDict MDoctorDict = new MClinicDoctorDict();
                    MDoctorDict.CLINIC_DOCTOR_ID = dgv_Doctor.Rows[i - 1].Cells["CLINIC_DOCTOR_ID"].Value.ToString();
                    if (!string.IsNullOrEmpty(dgv_Doctor.Rows[i - 1].Cells["CLINIC_DOCTOR"].FormattedValue.ToString()))
                        MDoctorDict.CLINIC_DOCTOR = dgv_Doctor.Rows[i - 1].Cells["CLINIC_DOCTOR"].Value.ToString();
                    if (!string.IsNullOrEmpty(dgv_Doctor.Rows[i - 1].Cells["CLINIC_OFFICE_ID"].FormattedValue.ToString()))
                        MDoctorDict.CLINIC_OFFICE_ID = Convert.ToInt32(dgv_Doctor.Rows[i - 1].Cells["CLINIC_OFFICE_ID"].Value.ToString());
                    if (!string.IsNullOrEmpty(dgv_Doctor.Rows[i - 1].Cells["CLINIC_DOCTOR_PYCODE"].FormattedValue.ToString()))
                        MDoctorDict.CLINIC_DOCTOR_PYCODE = dgv_Doctor.Rows[i - 1].Cells["CLINIC_DOCTOR_PYCODE"].Value.ToString();

                    ht.Add(j, MDoctorDict);
                }
            }
            if (ht.Count > 0)
            {
                if (BDoctorDict.AddMore(ht) > 0)
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
                    MClinicDoctorDict MDoctorDict = new MClinicDoctorDict();
                    MDoctorDict.CLINIC_DOCTOR_ID = dgv_Doctor.Rows[r].Cells["CLINIC_DOCTOR_ID"].Value.ToString();
                    if (!string.IsNullOrEmpty(dgv_Doctor.Rows[r].Cells["CLINIC_DOCTOR"].Value.ToString()))
                        MDoctorDict.CLINIC_DOCTOR = dgv_Doctor.Rows[r].Cells["CLINIC_DOCTOR"].Value.ToString();
                    if (!string.IsNullOrEmpty(dgv_Doctor.Rows[r].Cells["CLINIC_OFFICE_ID"].FormattedValue.ToString()))
                        MDoctorDict.CLINIC_OFFICE_ID = Convert.ToInt32(dgv_Doctor.Rows[r].Cells["CLINIC_OFFICE_ID"].Value.ToString());
                    if (!string.IsNullOrEmpty(dgv_Doctor.Rows[r].Cells["CLINIC_DOCTOR_PYCODE"].FormattedValue.ToString()))
                        MDoctorDict.CLINIC_DOCTOR_PYCODE = dgv_Doctor.Rows[r].Cells["CLINIC_DOCTOR_PYCODE"].Value.ToString();
                    htEdit.Add(k, MDoctorDict);
                }
                if (BDoctorDict.UpdateMore(htEdit) >= 0)
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

        private void dgv_Doctor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv_Doctor = (DataGridView)sender;
            if (dgv_Doctor.Columns[e.ColumnIndex].Name == "Operate")
            {
                if (e.RowIndex < rowcount - 1)
                {
                    if (DialogResult.OK == MessageBoxEx.Show("确认要删除" + dgv_Doctor.Rows[e.RowIndex].Cells["CLINIC_DOCTOR"].Value + "吗", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk))
                    {
                        if (BDoctorDict.Delete(" where CLINIC_DOCTOR_ID=" + dgv_Doctor.Rows[e.RowIndex].Cells["CLINIC_DOCTOR_ID"].Value.ToString()) >= 0)
                            BindDoctorInfo();//刷新表格
                        else
                            MessageBoxEx.Show("删除失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (!dgv_Doctor.Rows[e.RowIndex].IsNewRow)
                        dgv_Doctor.Rows.RemoveAt(e.RowIndex);
                }
            }

            if (dgv_Doctor.Columns[e.ColumnIndex].Name == "Edit")//修改历史数据
            {
                SetDataGridViewRowEditModel(e.RowIndex);
                dgv_Doctor.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
                htRow.Add(i++, e.RowIndex.ToString());
            }
        }

        private void dgv_Doctor_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgv_Doctor_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            switch (dgv.Columns[e.ColumnIndex].Name)
            {
                case "CLINIC_DOCTOR":
                    dgv.Rows[e.RowIndex].Cells["CLINIC_DOCTOR_PYCODE"].Value = GetConfig.phone.Convert(dgv.Rows[e.RowIndex].Cells["CLINIC_DOCTOR"].Value.ToString(), false);//string kk= Pht.Convert("加快了撒地方",false);
                    break;
            }
        }

        private void txt_Doctor_Name_TextChanged(object sender, EventArgs e)
        {
            BindDoctorInfo();
        }

        //设置网格中行的编辑状态
        //输入参数:Index-可编辑行的索引;
        private void SetDataGridViewRowEditModel(int Index)
        {
            dgv_Doctor.ReadOnly = false;
            foreach (DataGridViewRow dr in dgv_Doctor.Rows)
                dr.ReadOnly = true;

            if (Index >= 0)
            {
                dgv_Doctor.Rows[Index].ReadOnly = false;
                //dgv_Doctor.Rows[Index].Cells["DOCTOR_ID"].ReadOnly = true;
            }
        }
    }
}