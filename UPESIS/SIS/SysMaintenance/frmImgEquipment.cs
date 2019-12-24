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
    public partial class frmImgEquipment : Form
    {
        private BGetSeqValue ID = new BGetSeqValue("SIS", "SEQ_IMG_EQUIPMENT_ID");
        private BImgEquipment BigEquMent = new BImgEquipment();

        private int rowcount; //记录未新增前网格的行数
        private Hashtable htRow = new Hashtable();//记录修改的行号
        private int i = 0; //记录一次性修改的行数
        private DataTable dt_CliniCofficeID = new DataTable();  //记录科室信息表

        public frmImgEquipment()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 绑定所属科室
        /// </summary>
        private void BindCliniCofficeID()
        {
            //BClinicOfficeDict BClOff = new BClinicOfficeDict();

            //dt_CliniCofficeID = BClOff.GetList("1=1 order by CLINIC_OFFICE_ID asc");
            //DataTable dt = dt_CliniCofficeID.Copy();

            //DataRow dr = dt_CliniCofficeID.NewRow();
            //dt_CliniCofficeID.Rows.InsertAt(dr, 0);
            //dr["CLINIC_OFFICE_ID"] = -1;
            //dr["CLINIC_OFFICE"] = "";

            //if (dt_CliniCofficeID.Rows.Count > 0)
            //{
            //    cmb_CLINIC_OFFICE.DataSource = dt_CliniCofficeID;
            //    cmb_CLINIC_OFFICE.DisplayMember = "CLINIC_OFFICE";
            //    cmb_CLINIC_OFFICE.ValueMember = "CLINIC_OFFICE_ID";

            //    ((DataGridViewComboBoxColumn)dgv_ImgEquipment.Columns["CLINIC_OFFICE_ID"]).DataSource = dt ;
            //    ((DataGridViewComboBoxColumn)dgv_ImgEquipment.Columns["CLINIC_OFFICE_ID"]).DisplayMember = "CLINIC_OFFICE";
            //    ((DataGridViewComboBoxColumn)dgv_ImgEquipment.Columns["CLINIC_OFFICE_ID"]).ValueMember = "CLINIC_OFFICE_ID";
            //}
            //else
            //{
            //    cmb_CLINIC_OFFICE.DataSource = null;
            //    ((DataGridViewComboBoxColumn)dgv_ImgEquipment.Columns["CLINIC_OFFICE_ID"]).DataSource = null;
            //}
            DataTable dt = new DataTable();
            dt.Columns.Add("CLINIC_OFFICE", typeof(string));
            dt.Columns.Add("CLINIC_OFFICE_ID", typeof(string));
            DataRow dr = dt.NewRow();
            dr["CLINIC_OFFICE"] = ILL.GetConfig.ExamDeptName;
            dr["CLINIC_OFFICE_ID"] = ILL.GetConfig.ExamDeptCode;
            dt.Rows.Add(dr);
            ((DataGridViewComboBoxColumn)dgv_ImgEquipment.Columns["CLINIC_OFFICE_ID"]).DataSource = dt;
            ((DataGridViewComboBoxColumn)dgv_ImgEquipment.Columns["CLINIC_OFFICE_ID"]).DisplayMember = "CLINIC_OFFICE";
            ((DataGridViewComboBoxColumn)dgv_ImgEquipment.Columns["CLINIC_OFFICE_ID"]).ValueMember = "CLINIC_OFFICE_ID";
        }

        /// <summary>
        /// 填充设备状态
        /// </summary>
        private void BindEquipmentState()
        {
            cmb_EQUIPMENT_STATE.Items.Add("");
            cmb_EQUIPMENT_STATE.Items.Add("在用");
            cmb_EQUIPMENT_STATE.Items.Add("空闲");
            cmb_EQUIPMENT_STATE.Items.Add("等待");

            ((DataGridViewComboBoxColumn)dgv_ImgEquipment.Columns["EQUIPMENT_STATE"]).Items.Add("在用");
            ((DataGridViewComboBoxColumn)dgv_ImgEquipment.Columns["EQUIPMENT_STATE"]).Items.Add("空闲");
            ((DataGridViewComboBoxColumn)dgv_ImgEquipment.Columns["EQUIPMENT_STATE"]).Items.Add("等待");
        }

        private void ImgEquipment_Load(object sender, EventArgs e)
        {
            this.btn_FunName.Text = this.Text.ToString();
            rowcount = this.dgv_ImgEquipment.Rows.Count;
            dgv_ImgEquipment.AutoGenerateColumns = false;

            BindCliniCofficeID();       //绑定所属科室
            BindEquipmentState();       //填充设备状态下拉列表

            BindDoctorInfo();
            if (dgv_ImgEquipment.Rows.Count > 0)
                gb_PromptInfo.Visible = false;
            else
                gb_PromptInfo.Visible = true;
            dgv_ImgEquipment.ReadOnly = true;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            CreateNewRow();
        }

        private void CreateNewRow()
        {
            this.dgv_ImgEquipment.Visible = true;
            this.gb_PromptInfo.Visible = false;
            DataTable dt = (DataTable)dgv_ImgEquipment.DataSource;
            if (dt == null)
                dgv_ImgEquipment.Rows.Add();
            else
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                dgv_ImgEquipment.DataSource = dt;
            }
            dgv_ImgEquipment.Rows[dgv_ImgEquipment.Rows.Count - 1].Cells["IMG_EQUIPMENT_ID"].Value = ID.GetSeqValue();
            this.dgv_ImgEquipment.CurrentCell = dgv_ImgEquipment.Rows[dgv_ImgEquipment.Rows.Count - 1].Cells["IMG_EQUIPMENT_NAME"];
            dgv_ImgEquipment.Rows[dgv_ImgEquipment.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Linen;
            SetDataGridViewRowEditModel(dgv_ImgEquipment.Rows.Count - 1);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (SaveData() && EditData())
            {
                BindDoctorInfo();
                dgv_ImgEquipment.ReadOnly = true;
            }
        }

        private bool SaveData()
        {
            Hashtable ht = new Hashtable();
            if (dgv_ImgEquipment.Rows.Count > rowcount - 1)//说明有新增行
            {
                for (int i = rowcount, j = 0; i <= dgv_ImgEquipment.Rows.Count && j < dgv_ImgEquipment.Rows.Count; i++, j++)//从第rowcount个开始保存
                {
                    MImgEquipment MigEquMent = new MImgEquipment();
                    MigEquMent.IMG_EQUIPMENT_ID = Convert.ToInt32(dgv_ImgEquipment.Rows[i - 1].Cells["IMG_EQUIPMENT_ID"].Value.ToString().Trim());
                    if (!string.IsNullOrEmpty(dgv_ImgEquipment.Rows[i - 1].Cells["IMG_EQUIPMENT_NAME"].Value.ToString().Trim()))
                        MigEquMent.IMG_EQUIPMENT_NAME = dgv_ImgEquipment.Rows[i - 1].Cells["IMG_EQUIPMENT_NAME"].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(dgv_ImgEquipment.Rows[i - 1].Cells["CLINIC_OFFICE_ID"].Value.ToString().Trim()))
                        MigEquMent.CLINIC_OFFICE_ID = Convert.ToInt32(((DataGridViewComboBoxCell)dgv_ImgEquipment.Rows[i - 1].Cells["CLINIC_OFFICE_ID"]).Value.ToString());
                    if (!string.IsNullOrEmpty(dgv_ImgEquipment.Rows[i - 1].Cells["OFFICE"].Value.ToString().Trim()))
                        MigEquMent.OFFICE = dgv_ImgEquipment.Rows[i - 1].Cells["OFFICE"].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(dgv_ImgEquipment.Rows[i - 1].Cells["SERIAL_CLASS"].Value.ToString().Trim()))
                        MigEquMent.SERIAL_CLASS = dgv_ImgEquipment.Rows[i - 1].Cells["SERIAL_CLASS"].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(dgv_ImgEquipment.Rows[i - 1].Cells["OPERATOR_DOCTOR"].Value.ToString().Trim()))
                        MigEquMent.OPERATOR_DOCTOR = dgv_ImgEquipment.Rows[i - 1].Cells["OPERATOR_DOCTOR"].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(dgv_ImgEquipment.Rows[i - 1].Cells["EQUIPMENT_STATE"].Value.ToString().Trim()))
                        MigEquMent.EQUIPMENT_STATE = dgv_ImgEquipment.Rows[i - 1].Cells["EQUIPMENT_STATE"].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(dgv_ImgEquipment.Rows[i - 1].Cells["IP"].Value.ToString().Trim()))
                        MigEquMent.IP = dgv_ImgEquipment.Rows[i - 1].Cells["IP"].Value.ToString().Trim();
                    try
                    {
                        MigEquMent.LAST_CALL = Convert.ToDateTime(dgv_ImgEquipment.Rows[i - 1].Cells["LAST_CALL"].Value.ToString());
                    }
                    catch
                    {
                    }
                    MigEquMent.EQU_GUID = dgv_ImgEquipment.Rows[i - 1].Cells["EQU_GUID"].Value.ToString().Trim();
                    ht.Add(j, MigEquMent);
                }
            }
            if (ht.Count > 0)
            {
                if (BigEquMent.AddMore(ht) > 0)
                    MessageBoxEx.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBoxEx.Show("添加失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
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
                    MImgEquipment MigEquMent = new MImgEquipment();
                    MigEquMent.IMG_EQUIPMENT_ID = Convert.ToInt32(dgv_ImgEquipment.Rows[r].Cells["IMG_EQUIPMENT_ID"].Value.ToString().Trim());
                    if (!string.IsNullOrEmpty(dgv_ImgEquipment.Rows[r].Cells["IMG_EQUIPMENT_NAME"].Value.ToString().Trim()))
                        MigEquMent.IMG_EQUIPMENT_NAME = dgv_ImgEquipment.Rows[r].Cells["IMG_EQUIPMENT_NAME"].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(dgv_ImgEquipment.Rows[r].Cells["CLINIC_OFFICE_ID"].Value.ToString().Trim()))
                        MigEquMent.CLINIC_OFFICE_ID = Convert.ToInt32(((DataGridViewComboBoxCell)dgv_ImgEquipment.Rows[r].Cells["CLINIC_OFFICE_ID"]).Value.ToString().Trim());
                    if (!string.IsNullOrEmpty(dgv_ImgEquipment.Rows[r].Cells["OFFICE"].Value.ToString().Trim()))
                        MigEquMent.OFFICE = dgv_ImgEquipment.Rows[r].Cells["OFFICE"].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(dgv_ImgEquipment.Rows[r].Cells["SERIAL_CLASS"].Value.ToString().Trim()))
                        MigEquMent.SERIAL_CLASS = dgv_ImgEquipment.Rows[r].Cells["SERIAL_CLASS"].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(dgv_ImgEquipment.Rows[r].Cells["OPERATOR_DOCTOR"].Value.ToString().Trim()))
                        MigEquMent.OPERATOR_DOCTOR = dgv_ImgEquipment.Rows[r].Cells["OPERATOR_DOCTOR"].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(dgv_ImgEquipment.Rows[r].Cells["EQUIPMENT_STATE"].Value.ToString().Trim()))
                        MigEquMent.EQUIPMENT_STATE = dgv_ImgEquipment.Rows[r].Cells["EQUIPMENT_STATE"].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(dgv_ImgEquipment.Rows[r].Cells["IP"].Value.ToString().Trim()))
                        MigEquMent.IP = dgv_ImgEquipment.Rows[r].Cells["IP"].Value.ToString().Trim();
                    try
                    {
                        MigEquMent.LAST_CALL = Convert.ToDateTime(dgv_ImgEquipment.Rows[r].Cells["LAST_CALL"].Value.ToString());
                    }
                    catch
                    {
                    }
                    MigEquMent.EQU_GUID = dgv_ImgEquipment.Rows[r].Cells["EQU_GUID"].Value.ToString().Trim();
                    htEdit.Add(k, MigEquMent);
                    k += 1;
                }

                if (BigEquMent.UpdateMore(htEdit) >= 0)
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

        /// <summary>
        /// 判断必需输入项是否有为空的
        /// </summary>
        /// <param name="RowIndex">当前定位网格的行</param>
        /// <returns>true-说明有为空的项</returns>
        private bool ChgNull(int RowIndex)
        {
            if (string.IsNullOrEmpty(dgv_ImgEquipment.Rows[RowIndex].Cells["IMG_EQUIPMENT_ID"].Value.ToString().Trim()))
            {
                MessageBoxEx.Show("影像设备标识不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            if (string.IsNullOrEmpty(dgv_ImgEquipment.Rows[RowIndex].Cells["EQUIPMENT_STATE"].Value.ToString().Trim()))
            {
                MessageBoxEx.Show("设备状态不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;

        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            BindDoctorInfo();
        }

        private void BindDoctorInfo()
        {
            StringBuilder strBuild = new StringBuilder();
            strBuild.Append("CLINIC_OFFICE_CODE='" + ILL.GetConfig.ExamDeptCode + "' and ");
            if (txt_IMG_EQUIPMENT_NAME.Text.Trim() != "")
                strBuild.Append("IMG_EQUIPMENT_NAME like '%" + txt_IMG_EQUIPMENT_NAME.Text.Trim() + "%' and ");
            //if (cmb_CLINIC_OFFICE.Text != "")
            //    strBuild.Append("CLINIC_OFFICE_ID =" + cmb_CLINIC_OFFICE.SelectedValue + " and ");
            if (txt_OFFICE.Text.Trim() != "")
                strBuild.Append("OFFICE like '%" + txt_OFFICE.Text.Trim() + "%' and ");
            if (cmb_EQUIPMENT_STATE.Text != "")
                strBuild.Append("EQUIPMENT_STATE like '%" + cmb_EQUIPMENT_STATE.Text.Trim() + "%' and ");

            DataTable dt = BigEquMent.GetList(strBuild.ToString() + " 1=1 order by IMG_EQUIPMENT_ID");

            if (dt != null)
            {
                dgv_ImgEquipment.DataSource = dt;
                rowcount = dt.Rows.Count + 1;
            }
        }

        private void dgv_ImgEquipment_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgv_ImgEquipment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv_ImgEqument = (DataGridView)sender;
            if (dgv_ImgEqument.Columns[e.ColumnIndex].Name == "Operate")
            {
                if (e.RowIndex < rowcount - 1)
                {
                    if (DialogResult.OK == MessageBoxEx.Show("确认要删除" + dgv_ImgEqument.Rows[e.RowIndex].Cells["IMG_EQUIPMENT_NAME"].Value + "吗", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk))
                    {
                        if (BigEquMent.Delete(" where IMG_EQUIPMENT_ID = " + dgv_ImgEqument.Rows[e.RowIndex].Cells["IMG_EQUIPMENT_ID"].Value.ToString()) >= 0)
                            BindDoctorInfo();//刷新表格
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


        //设置网格中行的编辑状态
        //输入参数:Index-可编辑行的索引;
        private void SetDataGridViewRowEditModel(int Index)
        {
            dgv_ImgEquipment.ReadOnly = false;
            foreach (DataGridViewRow dr in dgv_ImgEquipment.Rows)
                dr.ReadOnly = true;


            if (Index >= 0)
            {
                dgv_ImgEquipment.Rows[Index].ReadOnly = false;
                dgv_ImgEquipment.Rows[Index].Cells["IMG_EQUIPMENT_ID"].ReadOnly = true;
            }
        }


    }
}