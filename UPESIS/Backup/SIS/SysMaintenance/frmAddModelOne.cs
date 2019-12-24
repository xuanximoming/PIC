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
        private Hashtable htRow = new Hashtable();//��¼�޸ĵ��к�
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

        private void GetClassOneModel()//��ȡ��һ��ģ��
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

        private bool SaveData()//��������
        {
            Hashtable ht = new Hashtable();
            if (GvFunClassOne.Rows.Count > rowcount-1)//˵����������
            {
                for (int i = rowcount, j = 0; i <= GvFunClassOne.Rows.Count && j < GvFunClassOne.Rows.Count; i++, j++)//�ӵ�rowcount����ʼ����
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
                        MessageBoxEx.Show("ϵͳ���Ʋ���Ϊ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (!string.IsNullOrEmpty(GvFunClassOne.Rows[i - 1].Cells["MODEL_PLACE"].FormattedValue.ToString()))
                    {
                        MSysFunChi.MODEL_PLACE = GvFunClassOne.Rows[i - 1].Cells["MODEL_PLACE"].Value.ToString();
                    }
                    else
                    {
                        MessageBoxEx.Show("����������Ʋ���Ϊ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (ExpressionValidat.IsInt(GvFunClassOne.Rows[i - 1].Cells["SORT_FLAG"].FormattedValue.ToString()))
                        MSysFunChi.SORT_FLAG = Convert.ToInt32(GvFunClassOne.Rows[i - 1].Cells["SORT_FLAG"].Value.ToString());
                    else
                    {
                        MessageBoxEx.Show("����ű���Ϊ���֣�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MSystemFun MSysFun = new MSystemFun();
                    MSysFun.MODEL_ID = Convert.ToInt32(GvFunClassOne.Rows[r].Cells["MODEL_ID"].Value.ToString());
                    if (!string.IsNullOrEmpty(GvFunClassOne.Rows[r].Cells["MODEL_NAME"].FormattedValue.ToString()))
                    {
                        MSysFun.MODEL_NAME = GvFunClassOne.Rows[r].Cells["MODEL_NAME"].Value.ToString();
                    }
                    else
                    {
                        MessageBoxEx.Show("ϵͳ���Ʋ���Ϊ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (!string.IsNullOrEmpty(GvFunClassOne.Rows[r].Cells["MODEL_PLACE"].FormattedValue.ToString()))
                    {
                        MSysFun.MODEL_PLACE = GvFunClassOne.Rows[r].Cells["MODEL_PLACE"].Value.ToString();
                    }
                    else
                    {
                        MessageBoxEx.Show("����������Ʋ���Ϊ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (ExpressionValidat.IsInt(GvFunClassOne.Rows[r].Cells["SORT_FLAG"].FormattedValue.ToString()))
                        MSysFun.SORT_FLAG = Convert.ToInt32(GvFunClassOne.Rows[r].Cells["SORT_FLAG"].Value.ToString());
                    else
                    {
                        MessageBoxEx.Show("����ű���Ϊ���֣�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (!string.IsNullOrEmpty(GvFunClassOne.Rows[r].Cells["IMAGE_ADDRESS"].FormattedValue.ToString()))
                        MSysFun.IMAGE_ADDRESS = GvFunClassOne.Rows[r].Cells["IMAGE_ADDRESS"].Value.ToString();
                    htEdit.Add(k, MSysFun);

                }
                if (BSysFun.UpdateMore(htEdit) >= 0)
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

        private void GvFunClassOne_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gv = (DataGridView)sender;
            if (gv.Columns[e.ColumnIndex].Name == "Operate")
            {
                if (e.RowIndex < rowcount - 1)
                {
                    if (DialogResult.OK == MessageBoxEx.Show("��ɾ����ģ���µ�������ģ�飬ȷ��Ҫɾ��" + gv.Rows[e.RowIndex].Cells["MODEL_NAME"].Value + "��", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk))
                    {
                        if (BSysFun.Delete("  where model_id in( select model_id from SYSTEM_FUNCTION start with MODEL_ID=" + Convert.ToInt32(gv.Rows[e.RowIndex].Cells["MODEL_ID"].Value.ToString()) + " connect by prior model_id = up_model_id )") >= 0)
                        {
                            MessageBoxEx.Show("ɾ���ɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GetClassOneModel();//ˢ�±��
                        }
                        else
                            MessageBoxEx.Show("ɾ��ʧ�ܣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void btnGoUpModel_Click(object sender, EventArgs e)
        {
            frmMainForm.myMainForm.SetFormHidden();//��ʾ����ǰӰ�����д���

            frmMainForm.myMainForm.SetFormDisplay("ϵͳ����", "SIS.SysMaintenance.AddModelOne");
        }

        //private void GvFunClassOne_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        //    switch (GvFunClassOne.Columns[e.ColumnIndex].Name)
        //    {
        //        case "MODEL_NAME":
        //            if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
        //            {
        //                MessageBoxEx.Show("ģ�����Ʋ���Ϊ�գ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                e.Cancel = true;
        //            }
        //            break;

        //        case "MODEL_PLACE":
        //            if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
        //            {
        //                MessageBoxEx.Show("����������Ʋ���Ϊ�գ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                e.Cancel = true;
        //            }
        //            break;
        //        case "SORT_FLAG":

        //             if (!ExpressionValidat.IsNumeric(e.FormattedValue.ToString()))
        //            {
        //                MessageBoxEx.Show("����ű���Ϊ���֣�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //            break;

        //    }
        //}

        //�����������еı༭״̬
        //�������:Index-�ɱ༭�е�����;

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