using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SIS_BLL;
using SIS_Model;
using SIS.Function;
using System.Collections;
using ILL;

namespace SIS.SysMaintenance
{
    public partial class frmUserManage : Form
    {
        private BClinicOfficeDict BOfficeDict = new BClinicOfficeDict();
        private BClinicDoctorDict BDoctorDict = new BClinicDoctorDict();
        private BUser BUse = new BUser();
        private BUsersRole BUserRol = new BUsersRole();
        private Hashtable htRow = new Hashtable();  //��¼�޸ĵ��к�
        private int i = 0;
        private int rowcount;
        private int currentRowCount;

        public frmUserManage()
        {
            InitializeComponent();
        }

        private void UserManage_Load(object sender, EventArgs e)
        {
            this.btn_FunName.Text = this.Text;
            this.dgv_UserManage.AutoGenerateColumns = false;

            BindDoctorLevel();
            Bind_CLINIC_OFFICE();
            BindRole();
            FindUserInfo("");
            dgv_UserManage.ReadOnly = true;
        }

        /// <summary>
        /// ��ҽ������
        /// </summary>
        private void BindDoctorLevel()
        {
            DataTable dtDoctorLevel = new DataTable();
            //dtDoctorLevel.TableName = "Table";
            DataRow dr1, dr2, dr3;
            dtDoctorLevel.Columns.Add(new DataColumn("DOCTOR_LEVEL_NAME", typeof(string)));
            dtDoctorLevel.Columns.Add(new DataColumn("DOCTOR_LEVEL", typeof(decimal)));
            dr1 = dtDoctorLevel.NewRow(); dr2 = dtDoctorLevel.NewRow(); dr3 = dtDoctorLevel.NewRow();
            dr1["DOCTOR_LEVEL_NAME"] = "����,������ҽʦ";
            dr1["DOCTOR_LEVEL"] = 9;
            dr2["DOCTOR_LEVEL_NAME"] = "����ҽʦ";
            dr2["DOCTOR_LEVEL"] = 6;
            dr3["DOCTOR_LEVEL_NAME"] = "��ͨҽʦ";
            dr3["DOCTOR_LEVEL"] = 4;
            dtDoctorLevel.Rows.Add(dr1);
            dtDoctorLevel.Rows.Add(dr2);
            dtDoctorLevel.Rows.Add(dr3);
            ((DataGridViewComboBoxColumn)dgv_UserManage.Columns["DOCTOR_LEVEL"]).DataSource = dtDoctorLevel;
            ((DataGridViewComboBoxColumn)dgv_UserManage.Columns["DOCTOR_LEVEL"]).DisplayMember = "DOCTOR_LEVEL_NAME";
            ((DataGridViewComboBoxColumn)dgv_UserManage.Columns["DOCTOR_LEVEL"]).ValueMember = "DOCTOR_LEVEL";
        }

        private void BindRole()
        {
            DataTable dt = BUserRol.GetList(" 1=1");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem li = new ListViewItem(dt.Rows[i]["ROLE_NAME"].ToString());
                    li.SubItems.Add(dt.Rows[i]["ROLE_NAME"].ToString());
                    this.lv_role.Items.Add(dt.Rows[i]["ROLE_NAME"].ToString());
                }
            }
        }

        //�󶨿���
        private void Bind_CLINIC_OFFICE()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CLINIC_OFFICE", typeof(string));
            dt.Columns.Add("CLINIC_OFFICE_CODE", typeof(string));
            DataRow dr = dt.NewRow();
            dr["CLINIC_OFFICE"] = ILL.GetConfig.ExamDeptName;
            dr["CLINIC_OFFICE_CODE"] = ILL.GetConfig.ExamDeptCode;
            dt.Rows.Add(dr);
            ((DataGridViewComboBoxColumn)dgv_UserManage.Columns["CLINIC_OFFICE"]).DataSource = dt;
            ((DataGridViewComboBoxColumn)dgv_UserManage.Columns["CLINIC_OFFICE"]).DisplayMember = "CLINIC_OFFICE";
            ((DataGridViewComboBoxColumn)dgv_UserManage.Columns["CLINIC_OFFICE"]).ValueMember = "CLINIC_OFFICE_CODE";
        }

        private void FindUserInfo(string strWhere)//�����û���Ϣ
        {
            DataTable dt = BUse.GetList(strWhere + " CLINIC_OFFICE_CODE = '"+GetConfig.ExamDeptCode +"' order by DOCTOR_ID ");
            if (dt.Rows.Count > 0)
                this.dgv_UserManage.DataSource = dt;
            this.gb_PromptInfo.Visible = false;

            rowcount = this.dgv_UserManage.Rows.Count + 1;
        }

        private void dgv_UserManage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gv = (DataGridView)sender;
            if (gv.Columns[e.ColumnIndex].Name == "Operate")
            {
                if (e.RowIndex < rowcount - 1)
                {
                    if (DialogResult.OK == MessageBoxEx.Show("ȷ��Ҫɾ����?", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk))
                    {
                        if (BUse.Delete(" where DOCTOR_ID=" + Convert.ToInt32(gv.Rows[e.RowIndex].Cells["DOCTOR_ID"].Value.ToString())) >= 0)
                            FindUserInfo("");//ˢ�±��
                        else
                            MessageBoxEx.Show("ɾ��ʧ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (!gv.Rows[e.RowIndex].IsNewRow)
                        gv.Rows.RemoveAt(e.RowIndex);
                }
            }
            if (gv.Columns[e.ColumnIndex].Name == "Edit")//�޸���ʷ����
            {
                SetDataGridViewRowEditModel(e.RowIndex);
                gv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
                htRow.Add(i++, e.RowIndex.ToString());
            }
            if (gv.Columns[e.ColumnIndex].Name == "Choose")
            {
                string[] strArray = gv.Rows[e.RowIndex].Cells[e.ColumnIndex-1].Value.ToString().Split(',');

                if (strArray.Length > 0)
                {
                    for (int i = 0; i < lv_role.Items.Count; i++)
                    {
                        int j = Array.IndexOf(strArray, lv_role.Items[i].Text);
                        if (j >= 0)
                            lv_role.Items[i].Checked = true;
                        else
                            lv_role.Items[i].Checked = false;
                    }
                }
                this.p_role.Visible = true;
                this.p_role.Location = new Point(MousePosition.X - this.p_role.Width, MousePosition.Y - 90);
                currentRowCount = e.RowIndex;

            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            this.gb_PromptInfo.Visible = false;
            DataTable dt = (DataTable)dgv_UserManage.DataSource;
            if (dt == null)
                dgv_UserManage.Rows.Add();
            else
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                dgv_UserManage.DataSource = dt;
            }
            
            if (dgv_UserManage.Rows.Count > 1)
                dgv_UserManage.Rows[dgv_UserManage.Rows.Count - 1].Cells["DOCTOR_ID"].Value  = Convert.ToInt16(dgv_UserManage.Rows[dgv_UserManage.Rows.Count - 2].Cells["DOCTOR_ID"].Value) + 1;
            else
                dgv_UserManage.Rows[dgv_UserManage.Rows.Count - 1].Cells["DOCTOR_ID"].Value  = 1;

            this.dgv_UserManage.CurrentCell = dgv_UserManage.Rows[dgv_UserManage.Rows.Count - 1].Cells["DOCTOR_ID"];
            dgv_UserManage.Rows[dgv_UserManage.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Linen;
            SetDataGridViewRowEditModel(dgv_UserManage.Rows.Count - 1);
        }

        /// <summary>
        /// ȷ����ȷ��ѡ����û���ɫ��Edit at 2010-11-22
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            //StringBuilder strRoles = new StringBuilder("");
            //foreach (ListViewItem lvi in lv_role.Items)
            //{
            //    if (lvi.Checked == true)
            //        strRoles.Append(lvi.Text.ToString() + ",");
            //}
            //dgv_UserManage.Rows[currentRowCount].Cells["role_names"].Value = strRoles.ToString();

            int selectCount = 0;
            //���
            foreach (ListViewItem lvi in lv_role.Items)
            {
                if (lvi.Checked == true)
                    selectCount++;
            }
            if (selectCount == 0)
                MessageBoxEx.Show("��ѡ��һ����ɫ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (selectCount > 1)
                MessageBoxEx.Show("ֻ��ѡ��һ����ɫ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                foreach (ListViewItem lvi in lv_role .Items )
                    if (lvi.Checked == true)
                    {
                        switch (lvi.SubItems[0].Text.ToString ())
                        {
                            case "��ͨ�û�":
                                dgv_UserManage.Rows[currentRowCount].Cells["role_names"].Value = "1";
                                break ;
                            case "����Ա":
                                dgv_UserManage.Rows[currentRowCount].Cells["role_names"].Value = "2";
                                break;
                        }
                    }
                btn_close_Click(null, null);
            }
        }

        /// <summary>
        /// �رգ��ر�ѡ���ɫ�Ĵ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.p_role.Visible = false;
        }

        private void dgv_UserManage_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (SaveData() && EditData())
            {
                FindUserInfo("");//ˢ�±��
                dgv_UserManage.ReadOnly = true;
            }
        }

        /// <summary>
        /// ��������û�
        /// </summary>
        /// <returns></returns>
        private bool CheckAdd()
        {
            bool checkAdd = false;
            string str = "";
            for (int i = rowcount; i <= dgv_UserManage.Rows.Count; i++)
            {
                if (BUse.GetModel(dgv_UserManage.Rows[i - 1].Cells["DOCTOR_ID"].Value.ToString().Trim()) != null)
                    str += dgv_UserManage.Rows[i - 1].Cells["DOCTOR_ID"].Value.ToString().Trim() + " ";
            }
            if (str == "")
                checkAdd = true;
            else
                MessageBoxEx.Show("���Ϊ " + str + " ���û��Ѵ��ڣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return checkAdd;
        }

        /// <summary>
        /// �����������û�,���ȱ�����֤���û��Ƿ����
        /// </summary>
        /// <returns></returns>
        private bool SaveData()
        {
            bool saveAdd = true;
            Hashtable ht = new Hashtable(); //����û�
            if (dgv_UserManage.Rows.Count > rowcount - 1)    //˵����������
            {
                if (CheckAdd())
                {
                    for (int i = rowcount, j = 0; i <= dgv_UserManage.Rows.Count && j < dgv_UserManage.Rows.Count; i++, j++)//�ӵ�rowcount����ʼ����
                    {
                        MUser mu = new MUser();
                        mu.DOCTOR_ID = dgv_UserManage.Rows[i - 1].Cells["DOCTOR_ID"].Value.ToString().Trim();
                        if (!string.IsNullOrEmpty(dgv_UserManage.Rows[i - 1].Cells["DOCTOR_NAME"].Value.ToString().Trim()))
                            mu.DOCTOR_NAME = dgv_UserManage.Rows[i - 1].Cells["DOCTOR_NAME"].FormattedValue.ToString();
                        if (!string.IsNullOrEmpty(dgv_UserManage.Rows[i - 1].Cells["CLINIC_OFFICE"].Value.ToString().Trim()))
                            mu.CLINIC_OFFICE_CODE = dgv_UserManage.Rows[i - 1].Cells["CLINIC_OFFICE"].Value.ToString().Trim();
                        if (!string.IsNullOrEmpty(dgv_UserManage.Rows[i - 1].Cells["CLINIC_OFFICE"].Value.ToString().Trim()))
                            mu.CLINIC_OFFICE = dgv_UserManage.Rows[i - 1].Cells["CLINIC_OFFICE"].FormattedValue.ToString();
                        if (!string.IsNullOrEmpty(dgv_UserManage.Rows[i - 1].Cells["role_names"].Value.ToString().Trim()))
                            mu.DOCTOR_ROLE = dgv_UserManage.Rows[i - 1].Cells["role_names"].Value.ToString().Trim();
                        if (!string.IsNullOrEmpty(dgv_UserManage.Rows[i - 1].Cells["DOCTOR_LEVEL"].Value.ToString()))
                            mu.DOCTOR_LEVEL = Convert.ToInt32(dgv_UserManage.Rows[i - 1].Cells["DOCTOR_LEVEL"].Value.ToString());
                        if (!string.IsNullOrEmpty(dgv_UserManage.Rows[i - 1].Cells["DOCTOR_PWD"].Value.ToString().Trim()))
                            mu.DOCTOR_PWD = dgv_UserManage.Rows[i - 1].Cells["DOCTOR_PWD"].Value.ToString().Trim();
                        mu.CREATE_DATE = DateTime.Now;
                        ht.Add(j, mu);
                    }

                    if (ht.Count > 0)
                    {
                        if (BUse.AddMore(ht) > 0)
                        {
                            MessageBoxEx.Show("��ӳɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBoxEx.Show("���ʧ�ܣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            saveAdd = false;
                        }
                    }
                }
                else
                    saveAdd = false;
            }
            return saveAdd;
        }

        /// <summary>
        /// �����޸ĵ��û�
        /// </summary>
        /// <returns></returns>
        private bool EditData()//�����޸�
        {
            bool saveEdit = true;
            Hashtable htEdit = new Hashtable();
            int r = 0;
            if (htRow.Count > 0)
            {
                for (int k = 0; k < htRow.Count; k++)
                {
                    r = Convert.ToInt32(htRow[k].ToString());
                    MUser mu = new MUser();
                    mu.DOCTOR_ID = dgv_UserManage.Rows[r].Cells["DOCTOR_ID"].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(dgv_UserManage.Rows[r].Cells["DOCTOR_NAME"].Value.ToString().Trim()))
                        mu.DOCTOR_NAME = dgv_UserManage.Rows[r].Cells["DOCTOR_NAME"].FormattedValue.ToString();
                    if (!string.IsNullOrEmpty(dgv_UserManage.Rows[r].Cells["CLINIC_OFFICE"].Value.ToString().Trim()))
                        mu.CLINIC_OFFICE_CODE = dgv_UserManage.Rows[r].Cells["CLINIC_OFFICE"].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(dgv_UserManage.Rows[r].Cells["CLINIC_OFFICE"].Value.ToString().Trim()))
                        mu.CLINIC_OFFICE = dgv_UserManage.Rows[r].Cells["CLINIC_OFFICE"].FormattedValue.ToString();
                    if (!string.IsNullOrEmpty(dgv_UserManage.Rows[r].Cells["role_names"].Value.ToString().Trim()))
                        mu.DOCTOR_ROLE = dgv_UserManage.Rows[r].Cells["role_names"].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(dgv_UserManage.Rows[r].Cells["DOCTOR_LEVEL"].Value.ToString()))
                        mu.DOCTOR_LEVEL = Convert.ToInt32(dgv_UserManage.Rows[r].Cells["DOCTOR_LEVEL"].Value.ToString());
                    if (!string.IsNullOrEmpty(dgv_UserManage.Rows[r].Cells["DOCTOR_PWD"].Value.ToString().Trim()))
                        mu.DOCTOR_PWD = dgv_UserManage.Rows[r].Cells["DOCTOR_PWD"].Value.ToString().Trim();
                    htEdit.Add(k, mu);
                }
                if (BUse.UpdateMore(htEdit) >= 0)
                {
                    MessageBoxEx.Show("�޸ĳɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    htRow.Clear();
                    i = 0;
                }
                else
                {
                    MessageBoxEx.Show("�޸�ʧ�ܣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    saveEdit = false;
                }
            }
            return saveEdit;
        }

        private void txt_DoctorId_TextChanged(object sender, EventArgs e)
        {
            string sql = "";
            if (txt_DoctorId.Text.Trim() != "")
                sql = "DOCTOR_ID like '%" + txt_DoctorId.Text.Trim() + "%' and";
            FindUserInfo(sql);
        }

        private void cmb_CLINIC_OFFICE_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_Doctor_Name_TextChanged(null, null);
        }

        private void txt_Doctor_Name_TextChanged(object sender, EventArgs e)
        {
            string sql = "";
            if (txt_Doctor_Name.Text.Trim() != "")
                sql = " DOCTOR_NAME like '%" + txt_Doctor_Name.Text.Trim() + "%' and ";

            FindUserInfo(sql);
        }

        //�����������еı༭״̬
        //�������:Index-�ɱ༭�е�����;
        private void SetDataGridViewRowEditModel(int Index)
        {
            dgv_UserManage.ReadOnly = false;
            foreach (DataGridViewRow dr in dgv_UserManage.Rows)
                dr.ReadOnly = true;


            if (Index >= 0)
            {
                dgv_UserManage.Rows[Index].ReadOnly = false;
                dgv_UserManage.Rows[Index].Cells["DOCTOR_ID"].ReadOnly = false;
            }
        }

    }
}