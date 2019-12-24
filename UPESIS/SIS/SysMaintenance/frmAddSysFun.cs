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
namespace SIS.SysMaintenance
{
    public partial class frmAddSysFun : Form
    {
        private BSystemFun BSysFun = new BSystemFun();
        private MSystemFun MSysFun = new MSystemFun();
        private MSystemFun MSysFun2 = new MSystemFun();
        private BGetSeqValue ID = new BGetSeqValue("SIS", "sysfunid");
        private DataTable dt;
        private Hashtable ht = new Hashtable();
        private int rowcount;
        public frmAddSysFun()
        {
            InitializeComponent();
            GetClassOneModel();
            rowcount = GvFunClassOne.Rows.Count;
        }

        private void GetClassOneModel()//��ȡ��һ��ģ��
        {
            try
            {
                dt = BSysFun.GetList("MODEL_ID = 1 and Up_MODEL_ID = 0");;
                if(dt.Rows.Count>0)
                this.GvFunClassOne.DataSource = dt.DefaultView;
                for (int i = 0; i < dt.Rows.Count; i++)
                GvFunClassOne.Rows[i].ReadOnly = true ;

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)//����һ��
        {
            CreateNewRow();
        }

        private void CreateNewRow()
        {
            if (CheckCellValue())
            {
                GvFunClassOne.CurrentCell = GvFunClassOne.Rows[GvFunClassOne.Rows.Count - 1].Cells["MODEL_ID"];
                GvFunClassOne.Rows[GvFunClassOne.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Linen;
                GvFunClassOne.BeginEdit(false);
            }   
        }

        private void AddSysFun_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control)
            {
                CreateNewRow();
            }
        }

        private bool CheckCellValue()//�ж����������Ƿ�Ϊ��
        {
            if (GvFunClassOne.Rows.Count >1)
            {
                for (int i = rowcount; i < GvFunClassOne.Rows.Count; i++)//�ӵ�rowcount����ʼ�ж�
                {
                    if (this.GvFunClassOne.Rows[i-1].Cells["MODEL_NAME"].Value.ToString() == "")
                    {
                        MessageBoxEx.Show("ϵͳ���Ʋ���Ϊ�գ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (this.GvFunClassOne.Rows[i-1].Cells["MODEL_PLACE"].Value.ToString() == "")
                    {
                        MessageBoxEx.Show("����������Ʋ���Ϊ�գ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        private void AddSysFun_Load(object sender, EventArgs e)
        {
            this.btnFunName.Text = this.Text.ToString();
        }

        private void btnCancle_Click(object sender, EventArgs e)//��������
        {
            ht.Clear();
            if (GvFunClassOne.Rows.Count > rowcount)//˵����������
            {
                for (int i =rowcount,j=0; i < GvFunClassOne.Rows.Count &&j<GvFunClassOne.Rows.Count; i++,j++)//�ӵ�rowcount����ʼ����
                {
                    MSystemFun MSysFunChi = new MSystemFun();
                    MSysFunChi.MODEL_ID = Convert.ToInt16(GvFunClassOne.Rows[i - 1].Cells["MODEL_ID"].Value.ToString());
                    MSysFunChi.UP_MODEL_ID = 0;
                    MSysFunChi.MODEL_CLASS = "1";
                    MSysFunChi.DEL_FLAG = 0;
                    MSysFunChi.SORT_FLAG = Convert.ToInt16(GvFunClassOne.Rows[i - 1].Cells["SORT_FLAG"].Value.ToString());
                    MSysFunChi.MODEL_PLACE = "SIS";
                    MSysFunChi.MODEL_NAME = GvFunClassOne.Rows[i - 1].Cells["MODEL_NAME"].Value.ToString();
                    ht.Add(j, MSysFunChi);
                }
            }
            if (CheckCellValue())
            {
                //if ((ht))
                //{
                //    rowcount = GvFunClassOne.Rows.Count;//��ʼ�������������
                //    MessageBoxEx.Show("����ɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    GetClassOneModel();//ˢ�±��

                //}
                //else

                //    MessageBoxEx.Show("����ʧ�ܣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GvFunClassOne_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gv = (DataGridView)sender;
            if (gv.Columns[e.ColumnIndex].Name == "Operate")
            {
                MessageBox.Show(e.RowIndex.ToString());
            }
        }

        private void GvFunClassOne_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["MODEL_ID"].Value = Convert.ToInt16(ID.GetSeqValue());
        }

        private void GvFunClassOne_CellDoubleClick(object sender, DataGridViewCellEventArgs e)//˫����Ԫ���޸�
        {
            MSysFun2 = null;
            DataGridView gv = new DataGridView();
            //if(gv.Rows[e.RowIndex]<rowcount)
            gv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MediumPurple;
            //MSysFun2.MModelId=Convert.ToInt16( gv.Rows[e.RowIndex].Cells["MODEL_ID"].Value.ToString());
            //MSysFun2.MModelName = gv.Rows[e.RowIndex].Cells["MODEL_NAME"].Value.ToString();
            //MSysFun2.MModelPlace = gv.Rows[e.RowIndex].Cells["MODEL_PLACE"].Value.ToString();
            //MSysFun2.MSortFlag =Convert.ToInt16( gv.Rows[e.RowIndex].Cells["SORT_FLAG"].Value.ToString());
          
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }


    }
}