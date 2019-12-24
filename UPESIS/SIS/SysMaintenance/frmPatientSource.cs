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
using SIS.Function;

namespace SIS.SysMaintenance
{
    public partial class frmPatientSource : Form
    {
        private BGetSeqValue ID = new BGetSeqValue("SIS", "SEQ_PATIENT_SOURCE_ID");
        private BPatientSource BPatientSour = new BPatientSource();
        private Hashtable htRow = new Hashtable();//��¼�޸ĵ��к�
        private int i = 0;
        private int rowcount;

        public frmPatientSource()
        {
            InitializeComponent();
            this.dgv_PatientSour.AutoGenerateColumns = false;
        }
        private void PatientSource_Load(object sender, EventArgs e)
        {
            BindPatientSour();
        }

        private void BindPatientSour()//�󶨲�����Դ��Ϣ
        {
            DataTable dt = BPatientSour.GetList(" 1=1 ORDER BY PATIENT_SOURCE_ID ");
            this.dgv_PatientSour.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                this.dgv_PatientSour.Visible = true;
                this.gb_PromptInfo.Visible = false;
            }
            else
            {
                this.dgv_PatientSour.Visible = false;
                this.gb_PromptInfo.Visible = true;
            }
            rowcount = this.dgv_PatientSour.Rows.Count;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            this.dgv_PatientSour.Visible = true;
            this.gb_PromptInfo.Visible = false;
            dgv_PatientSour.CurrentCell = dgv_PatientSour.Rows[dgv_PatientSour.Rows.Count - 1].Cells["PATIENT_SOURCE"];
            dgv_PatientSour.Rows[dgv_PatientSour.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Linen;
            dgv_PatientSour.BeginEdit(false);
        }

        private void dgv_PatientSour_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["PATIENT_SOURCE_ID"].Value = Convert.ToInt32(ID.GetSeqValue());
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (SaveData() && EditData())
            {
                BindPatientSour();
            }
        }

        private bool SaveData()//��������
        {
            Hashtable ht = new Hashtable();
            if (dgv_PatientSour.Rows.Count > rowcount)//˵����������
            {
                for (int i = rowcount, j = 0; i < dgv_PatientSour.Rows.Count && j < dgv_PatientSour.Rows.Count; i++, j++)//�ӵ�rowcount����ʼ����
                {
                    MPatientSource MPatientSour = new MPatientSource();
                    MPatientSour.PATIENT_SOURCE_ID = Convert.ToInt32(dgv_PatientSour.Rows[i - 1].Cells["PATIENT_SOURCE_ID"].Value.ToString());
                    if (!string.IsNullOrEmpty((dgv_PatientSour.Rows[i - 1].Cells["PATIENT_SOURCE"]).FormattedValue.ToString()))
                        MPatientSour.PATIENT_SOURCE = dgv_PatientSour.Rows[i - 1].Cells["PATIENT_SOURCE"].Value.ToString();
                    ht.Add(j, MPatientSour);
                }
            }
            if (ht.Count > 0)
            {
                if (BPatientSour.AddMore(ht) > 0)
                    MessageBoxEx.Show("��ӳɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBoxEx.Show("���ʧ�ܣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private bool EditData()//�����޸�
        {
            Hashtable htEdit = new Hashtable();
            int r = 0;
            if (htRow.Count > 0)
            {
                for (int k = 0; k < htRow.Count; k++)
                {
                    r = Convert.ToInt32(htRow[k].ToString());
                    MPatientSource MPatientSour = new MPatientSource();
                    MPatientSour.PATIENT_SOURCE_ID = Convert.ToInt32(dgv_PatientSour.Rows[r].Cells["PATIENT_SOURCE_ID"].Value.ToString());
                    if (!string.IsNullOrEmpty((dgv_PatientSour.Rows[r].Cells["PATIENT_SOURCE"]).FormattedValue.ToString()))
                        MPatientSour.PATIENT_SOURCE = dgv_PatientSour.Rows[r].Cells["PATIENT_SOURCE"].Value.ToString();
                    htEdit.Add(k, MPatientSour);

                }
                if (BPatientSour.UpdateMore(htEdit) >= 0)
                    MessageBoxEx.Show("�޸ĳɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBoxEx.Show("�޸�ʧ�ܣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            htRow.Clear();
            i = 0;
            return true;
        }

        private void PatientSource_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmDeptManage.forDm.BindPatientSource();
        }

        private void dgv_PatientSour_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gv = (DataGridView)sender;
            if (gv.Columns[e.ColumnIndex].Name == "Operate")
            {
                if (e.RowIndex < rowcount - 1)
                {
                    if (DialogResult.OK == MessageBoxEx.Show("ȷ��Ҫɾ��" + gv.Rows[e.RowIndex].Cells["PATIENT_SOURCE"].Value + "��", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk))
                        if (BPatientSour.Delete(" where PATIENT_SOURCE_ID=" + Convert.ToInt32(gv.Rows[e.RowIndex].Cells["PATIENT_SOURCE_ID"].Value.ToString())) >= 0)
                        {
                            BindPatientSour();//ˢ�±��
                        }
                        else
                        {
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
                if (e.RowIndex < rowcount - 1)
                {
                    gv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
                    gv.Rows[e.RowIndex].ReadOnly = false;
                    htRow.Add(i++, e.RowIndex.ToString());

                }
            }
        }


    }
}