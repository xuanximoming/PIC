using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SIS_BLL;
using SIS_Model;

namespace SIS
{
    public partial class frmTempManager : Form
    {
        private string path =Application.StartupPath+"\\template.doc";
        private WordClass word; //����Word����
        private BPrintTemplateDict bPrintTemp = new BPrintTemplateDict();
        private BPrintTemplateDict bPrint = new BPrintTemplateDict();
        private MPrintTemplateDict mPrint = new MPrintTemplateDict();
        private BExamClass bExamClass = new BExamClass();
        public frmTempManager()
        {
            InitializeComponent();
            word = new WordClass(this.winWordControl);
            this.dgv_Print.AutoGenerateColumns = false;
            
        }
        
        private void frmTempManager_Load(object sender, EventArgs e)
        {
            this.btn_FunName.Text = "��ӡģ�����";
            DataTable dt = bExamClass.GetExamClass(" where 1=1 group by EXAM_CLASS");
            DgvBind();
            cmbBind(dt);
        }

        private void cmbBind(DataTable dt)
        {
            this.cmb_ExamClass.DataSource = dt;
            this.cmb_ExamClass.DisplayMember = "EXAM_CLASS";
            this.cmb_ExamClass.ValueMember = "EXAM_CLASS";
        }

        private void DgvBind()
        {
            DataTable dt = bPrint.GetList(GetWhere());
           if (dt.Rows.Count > 0)
            {
                this.dgv_Print.DataSource = dt;
                this.gb_PromptInfo.Visible = false;
                this.dgv_Print.Visible = true;
            }
            else
            {
                this.dgv_Print.Visible = false;
                this.dgv_Print.DataSource = null;
                this.gb_PromptInfo.Visible = true;
            }
        }

        private string GetWhere()
        {
            string where = "";
            where += " 1=1 ";
            if (cmb_ExamClass.Text != "")
                where += " and Exam_class='"+cmb_ExamClass.Text+"'";
            if (cmb_ExamSubClass.Text != "")
                where += " and Exam_sub_class='"+cmb_ExamSubClass.Text+"'";
            if (tx_TempName.Text != "")
                where += " and PRINT_TEMPLATE like '%"+tx_TempName.Text+"%'";
            where += " order by exam_class,exam_sub_class";
            return where;
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
            //diag.Filter = "Word�ĵ�(*.dot,*.doc)|*.dot|*.doc"; //"Word�ļ�(*.dot,*.doc)|*.dot|*.doc";
            diag.ShowDialog();
            try
            {
                if (diag.FileName != "")
                   if( word.WordOpen(diag.FileName)==-1)
                       MessageBox.Show("��ģ��ʧ�ܣ������´򿪣�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {
                MessageBox.Show("ѡ����ļ���Word�ĵ���������ѡ��");
            }
        }
        private void btn_SaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog diag = new SaveFileDialog();
            diag.Filter = "Word   Files(*.doc)|*.doc";
            diag.ShowDialog();
            try
            {
                word.unProtectWord();
            }
            catch
            {
            }
            try
            {
                if (diag.FileName != "")
                    word.WordSaveAs(diag.FileName, path, false);
                MessageBox.Show("�����ļ��ɹ���");
            }
            catch
            {
                MessageBox.Show("�����ļ�ʱ����");
            }
        }
        private void btn_UnProtect_Click(object sender, EventArgs e)
        {
            try
            {
                word.unProtectWord();
            }
            catch  { }
        }
        private void btn_Protect_Click(object sender, EventArgs e)
        {
            try
            {
                word.ProtectWord();
            }
            catch { }
        }
        private void cmb_ExamClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmb_ExamSubClass.DataSource = bExamClass.GetList(" exam_class='" + this.cmb_ExamClass.Text + "'");
            this.cmb_ExamSubClass.DisplayMember = "EXAM_SUB_CLASS";
            this.cmb_ExamSubClass.ValueMember = "EXAM_SUB_CLASS";
            this.cmb_ExamSubClass.SelectedIndex = -1;
            this.mPrint = null;
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                return;
            }
            this.mPrint = new MPrintTemplateDict();
            try
            {
                word.ProtectWord();
            }
            catch
            {
            }
            try
            {
                mPrint.FIELD_INF = word.GetWordCells();
                mPrint.FILE_NAME = GetFile();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "Word�ĵ�����Ϊ�ջ򲻷��Ϲ淶���봴�����޸ģ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            mPrint.PRINT_TEMPLATE_ID = int.Parse(new ILL.DGetSeqValue("SIS", "SEQ_PRINT_TEMPLATE_ID").GetSeqValue());
            mPrint.EXAM_CLASS = cmb_ExamClass.Text;
            mPrint.EXAM_SUB_CLASS = cmb_ExamSubClass.Text;
            mPrint.FILE_DATE_TIME = DateTime.Now;
            
            mPrint.PRINT_TEMPLATE = tx_TempName.Text;
            bPrint.Add(mPrint);
            MessageBox.Show("��ӳɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DgvBind();
        }

        private byte[] GetFile()
        {
            string DescFile = Application.StartupPath + "\\template2.doc";
            this.word.WordSaveAs(DescFile,path, 0);
            FileStream fs = new FileStream(DescFile, FileMode.Open, FileAccess.Read);
            Byte[] bt = new Byte[fs.Length];//��ͼƬת�� Byte�� ��������   
            fs.Read(bt, 0, bt.Length);//�Ѷ����������뻺����   
            fs.Close();
            return bt;
        }

        private void dgv_Print_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgv_Print.SelectedRows.Count <= 0)
                return;
            cmb_ExamClass.SelectedValue = this.dgv_Print.SelectedRows[0].Cells["EXAM_CLASS"].Value.ToString();
            cmb_ExamSubClass.SelectedValue = this.dgv_Print.SelectedRows[0].Cells["EXAM_SUB_CLASS"].Value.ToString();
            mPrint =(MPrintTemplateDict)(bPrint.GetModel(this.dgv_Print.SelectedRows[0].Cells["PRINT_TEMPLATE_ID"].Value.ToString()));
            tx_TempName.Text = mPrint.PRINT_TEMPLATE;
            this.winWordControl.QuitWord();
            
            FileStream fs=new FileStream (path,FileMode.OpenOrCreate,FileAccess.Write);
            fs.Write(mPrint.FILE_NAME,0,mPrint.FILE_NAME.Length);
            fs.Close();
            if (word.WordOpen(path) == -1)
            {
                MessageBox.Show("��ģ��ʧ�ܣ������´򿪣�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (this.mPrint == null)
                return;
            if (!CheckInput())
            {
                return;
            }
            try
            {
                word.ProtectWord();
            }
            catch
            {
            }
            try
            {
                mPrint.FIELD_INF = word.GetWordCells();
                mPrint.FILE_NAME = GetFile();
            }
            catch
            {
                MessageBox.Show("Word�ĵ�����Ϊ�գ��봴����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            mPrint.EXAM_CLASS = cmb_ExamClass.Text;
            mPrint.EXAM_SUB_CLASS = cmb_ExamSubClass.Text;
            
            mPrint.PRINT_TEMPLATE = tx_TempName.Text;
            bPrint.Update(mPrint," where PRINT_TEMPLATE_ID="+mPrint.PRINT_TEMPLATE_ID);
            MessageBox.Show("����ɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DgvBind();
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            DgvBind();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBoxEx.Show("ȷ��Ҫɾ����?", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk))
            {
                bPrint.Delete(" where PRINT_TEMPLATE_ID=" + this.dgv_Print.SelectedRows[0].Cells["PRINT_TEMPLATE_ID"].Value.ToString());
                DgvBind();
            }
        }

        private void frmTempManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.winWordControl.QuitWord();
        }
        private bool CheckInput()
        {
            if (cmb_ExamClass.Text == "")
            {
                MessageBox.Show("��������Ϊ�գ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmb_ExamSubClass.Text == "")
            {
                MessageBox.Show("������಻��Ϊ�գ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (tx_TempName.Text == "")
            {
                MessageBox.Show("ģ�����Ʋ���Ϊ�գ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void cmb_ExamSubClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tx_TempName.Text = "";
            this.mPrint = null;
        }
    }
}