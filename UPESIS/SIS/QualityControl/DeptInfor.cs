using Microsoft.Office.Interop.Word;
using PACS_Model;
using SIS_BLL;
using System;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Windows.Forms;

namespace SIS.QualityControl
{
    public partial class DeptInfor : Form
    {
        private BDeptDataDict BDDD = new BDeptDataDict();
        private OracleDataAdapter orclDataAda = new OracleDataAdapter();
        private string[] tpArray;
        private int checkPrint;

        public DeptInfor()
        {
            InitializeComponent();
        }

        private void DeptInfor_Load(object sender, EventArgs e)
        {
            this.btn_FunName.Text = this.Text.ToString();
            InitForm();

            DTP_MODIFY_DATE_TIME.Value = DateTime.Now;

            DataSet ds = BDDD.GetList1(" DATA_NAME='" + this.Text + "' And DATA_TYPE='" + tpArray[1] + "'", ref  orclDataAda);
            if (ds != null)
            {
                System.Data.DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txt_DATA_NAME.Text = dt.Rows[0]["DATA_NAME"].ToString();
                    cmb_DATA_TYPE.Text = dt.Rows[0]["DATA_TYPE"].ToString();
                    txt_AUTHOR.Text = dt.Rows[0]["AUTHOR"].ToString();
                    txt_CREATE_DATE_TIME.Text = dt.Rows[0]["CREATE_DATE_TIME"].ToString();
                    DTP_MODIFY_DATE_TIME.Text = dt.Rows[0]["MODIFY_DATE_TIME"].ToString();
                    rtb_DATA.Rtf = dt.Rows[0]["DATA"].ToString();
                }
            }
        }

        private void btn_Clean_Click(object sender, EventArgs e)
        {
            txt_DATA_NAME.Text = "";
            cmb_DATA_TYPE.Text = "";
            txt_AUTHOR.Text = "";
            txt_CREATE_DATE_TIME.Text = "";
            DTP_MODIFY_DATE_TIME.Value = DateTime.Now;
            rtb_DATA.Rtf = "";
        }

        private void btn_Pic_Click(object sender, EventArgs e)
        {
            opFileDlg.Filter = "bmp文件 (*.bmp)|*.bmp|jpg 文件 (*.jpg)|*.jpg|gif 文件 (*.gif) |*.gif";

            if (opFileDlg.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(opFileDlg.FileName);
                Clipboard.SetDataObject(bmp, false);
                if (this.rtb_DATA.CanPaste(DataFormats.GetFormat(DataFormats.Bitmap)))
                {
                    this.rtb_DATA.Paste();
                }
            }
        }

        private void btn_Word_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFilDlg = new SaveFileDialog();
            saveFilDlg.FileName = this.txt_DATA_NAME.Text;
            saveFilDlg.DefaultExt = "*.rtf";
            saveFilDlg.Filter = "RTF 文档(*.rtf)|*.rtf|Word 文档 (*.doc)|*.doc";

            if (saveFilDlg.ShowDialog() == DialogResult.OK && saveFilDlg.FileName.Length > 0)
            {
                try
                {
                    if (saveFilDlg.FileName.Contains(".rtf"))
                    {
                        this.rtb_DATA.SaveFile(saveFilDlg.FileName);
                    }
                    if (saveFilDlg.FileName.Contains(".doc"))
                    {

                        ApplicationClass MyWord = new ApplicationClass();
                        Document MyDoc;
                        Object Nothing = System.Reflection.Missing.Value;
                        MyDoc = MyWord.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);
                        MyWord.Selection.Text = this.rtb_DATA.Text;
                        //MyDoc.Paragraphs.Last.Range.Text = this.rtb_DATA.Text;
                        object MyFileName = saveFilDlg.FileName;
                        //将WordDoc文档对象的内容保存为DOC文档 
                        MyDoc.SaveAs(ref MyFileName, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing);
                        //关闭WordDoc文档对象 
                        MyDoc.Close(ref Nothing, ref Nothing, ref Nothing);
                        //关闭WordApp组件对象 
                        MyWord.Quit(ref Nothing, ref Nothing, ref Nothing);

                    }
                    MessageBoxEx.Show("WORD文件保存成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception Err)
                {
                    MessageBoxEx.Show("WORD文件保存失败！" + Err.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            MDeptDataDict MDDD = new MDeptDataDict();

            if (txt_DATA_NAME.Text.Trim() != "")
                MDDD.DATA_NAME = txt_DATA_NAME.Text.Trim();
            else
            {
                MessageBoxEx.Show("资料名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MDDD.DATA_TYPE = cmb_DATA_TYPE.Text;
            if (txt_AUTHOR.Text.Trim() != "")
                MDDD.AUTHOR = txt_AUTHOR.Text.Trim();
            MDDD.CREATE_DATE_TIME = DateTime.Now;
            MDDD.MODIFY_DATE_TIME = DTP_MODIFY_DATE_TIME.Value;
            MDDD.DATA = rtb_DATA.Rtf;
            MUser user = (MUser)SIS.frmMainForm.iUser;
            MDDD.DEPT_CODE = user.USER_DEPT;
            bool bl = BDDD.Exists(MDDD);

            if (!bl)
            {
                int i = BDDD.Add1(MDDD, ref orclDataAda);
                if (i >= 0)
                    MessageBoxEx.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBoxEx.Show("添加失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int j = BDDD.Update1(MDDD, ref orclDataAda);
                if (j >= 0)
                    MessageBoxEx.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBoxEx.Show("修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            DialogResult dlrs = MessageBoxEx.Show("确认当前记录!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dlrs == DialogResult.No) return;

            MUser user = (MUser)SIS.frmMainForm.iUser;
            int i = BDDD.Delete(" WHERE DEPT_CODE='" + user.USER_DEPT + "' and DATA_NAME='" + tpArray[2] + "' AND DATA_TYPE='" + tpArray[1] + "'");
            if (i >= 0)
            {
                MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_Clean_Click(null, null);
                SIS.frmDockForm ndForm = new SIS.frmDockForm();
                ndForm.Get_Pacs_Quality_DeptInfor(this.Text, "SIS.QualityControl.DeptInfor");
            }
            else
                MessageBoxEx.Show("删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            try
            {
                if (printDlg.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.DocumentName = txt_DATA_NAME.Text;
                    printDocument1.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            checkPrint = rtb_DATA.Print(checkPrint, rtb_DATA.TextLength, e);

            if (checkPrint < rtb_DATA.TextLength)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        private void btn_PrintView_Click(object sender, EventArgs e)
        {
            try
            {
                printViewDlg.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void InitForm()
        {
            tpArray = SIS.frmDockForm.QualityControlFlag.Split(';');
            if (tpArray == null) return;
            cmb_DATA_TYPE.Items.Clear();
            if (tpArray[0] == "科室资料")
            {
                cmb_DATA_TYPE.Items.Add("操作常规");
                cmb_DATA_TYPE.Items.Add("岗位分布");
                cmb_DATA_TYPE.Items.Add("岗位职责");
            }
            else if (tpArray[0] == "质控管理文档")
            {
                cmb_DATA_TYPE.Items.Add("培训制度");
                cmb_DATA_TYPE.Items.Add("规章制度");
                cmb_DATA_TYPE.Items.Add("质控标准");
            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            checkPrint = 0;
        }


    }
}