using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using SIS_BLL;
using System.Collections;
using SIS_Model;
using System.Threading;

namespace SIS
{
    public partial class frmInterestPatientL : Form
    {
        private BInterestPatient bItPt = new BInterestPatient();
        private delegate TreeNode delFiilTree(TreeNode tnd, string sKey, string ViewTxt);    //线程中异步刷新树
        private Point pi;                   //记录TreeView时鼠标点击的坐标
        private string NowDoctorID;         //当前登陆医生id
        private MInterestPatient mip = new MInterestPatient();
        private BGetSeqValue ID = new BGetSeqValue("SIS", "SEQ_INTEREST_PATIENT_NOTE_ID");
        private string Now_Add_NodeID="";
        private string Now_Modify_NodeID = "";  //记录当前修改的项目的NOTE_ID

        public frmInterestPatientL()
        {
            InitializeComponent();
        }

        #region 同步委托加载树
        /// <summary>
        /// 同步委托加载树
        /// </summary>
        private void FileeTrview(object nHt)
        {
            TreeNode tn = (TreeNode)((Hashtable)nHt)["a"];
            string sKey = ((Hashtable)nHt)["b"].ToString();

            DataTable dt = bItPt.GetList(" PARENT_NOTE_ID=" + sKey + "  and DOCTOR_ID='" + NowDoctorID + "' Order by NOTE_ID");

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["IS_NOTE"].ToString()=="1") return;

                string ViewTxt = dr["NOTE_NAME"].ToString().Trim();
                string nKey = dr["NOTE_ID"].ToString();

                delFiilTree dlg = new delFiilTree(DelFiilTreeview);       //创建委托,填充树
                TreeNode treenode = (TreeNode)this.Invoke(dlg, new object[] { tn, nKey, ViewTxt });

                Hashtable trht = new Hashtable();
                trht.Add("a", treenode);
                trht.Add("b", nKey);
                FileeTrview(trht);
            }
        }

        private TreeNode DelFiilTreeview(TreeNode tn, string sKey, string ViewTxt)
        {
            if (tn == null)
            {
                trv_InterestPatient.Nodes.Add(sKey, ViewTxt);
                return trv_InterestPatient.Nodes[sKey];
            }
            else
            {
                tn.Nodes.Add(sKey, ViewTxt);
                return tn.Nodes[sKey];
            }
        }
        #endregion

        private void NewThreadFill(TreeNode trnd, string strK)
        {
            trv_InterestPatient.Nodes.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("a", trnd);
            ht.Add("b", strK);

            Thread nThead = new Thread(new ParameterizedThreadStart(FileeTrview));
            nThead.IsBackground = true;
            nThead.Start(ht);
        }

        public void InitForm(string sPATIENT_ID, string sEXAM_ACCESSION_NUM)
        {
            mip.NOTE_ID = Convert.ToInt32(ID.GetSeqValue());
            mip.PATIENT_ID = sPATIENT_ID;
            mip.EXAM_ACCESSION_NUM = sEXAM_ACCESSION_NUM;
            MUser user = (MUser)frmMainForm.iUser;
            NowDoctorID = user.DOCTOR_ID;
            mip.DOCTOR_ID = NowDoctorID;
        }

        private void frmInterestPatientL_Load(object sender, EventArgs e)
        {
            chk_EXAM_ACCESSION_NUM.Checked = true;
            chk_PATIENT_ID.Checked = true;

            NewThreadFill(null, "0");
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            TreeNode tr = trv_InterestPatient.SelectedNode;
            if (tr == null)
            {
                MessageBoxEx.Show("请选择需要保存到的分类!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_NOTE_NAME.Text.Trim() == "")
            {
                MessageBoxEx.Show("请输入分类名!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            mip.NOTE_NAME = txt_NOTE_NAME.Text.Trim();

            mip.PARENT_NOTE_ID =Convert.ToInt32( tr.Name);

            if (!chk_PATIENT_ID.Checked)
                mip.PATIENT_ID = null;
            if (!chk_EXAM_ACCESSION_NUM.Checked)
                mip.EXAM_ACCESSION_NUM = null;

            if (txt_MEMO.Text.Trim() != "")
                mip.MEMO = txt_MEMO.Text.Trim();

            if (string.IsNullOrEmpty(mip.EXAM_ACCESSION_NUM) && string.IsNullOrEmpty(mip.PATIENT_ID))
                mip.IS_NOTE = 0;
            else
                mip.IS_NOTE = 1;

            int i = bItPt.Add(mip);
            if (i > 0)
            {
                MessageBoxEx.Show("新增感兴趣病人成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBoxEx.Show("新增感兴趣病人失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trv_InterestPatient_MouseDown(object sender, MouseEventArgs e)
        {
            pi = new Point(e.X, e.Y);
            trv_InterestPatient.SelectedNode = trv_InterestPatient.GetNodeAt(pi);
            if (trv_InterestPatient.SelectedNode != null)
                Now_Modify_NodeID = trv_InterestPatient.SelectedNode.Name;
        }

        private void cms_Add_Click(object sender, EventArgs e)
        {
            if (Now_Add_NodeID != "")
            {
                MessageBoxEx.Show("有新增项未保存!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            TreeNode treenode = null;
            Now_Add_NodeID = ID.GetSeqValue().ToString();
            TreeNode TR = trv_InterestPatient.SelectedNode;
            if (TR == null)
            {
                trv_InterestPatient.Nodes.Insert(0, Now_Add_NodeID, "双击进行修改");
            }
            else
            {
                if (TR.Level == 0)
                    treenode = trv_InterestPatient.Nodes.Insert(0, Now_Add_NodeID, "双击进行修改");
                else
                    treenode = TR.Parent.Nodes.Insert(TR.Index - 1, Now_Add_NodeID, "双击进行修改");
            }
            trv_InterestPatient.SelectedNode = treenode;
        }

        private void tsm_li_Click(object sender, EventArgs e)
        {
            trv_InterestPatient.CollapseAll();
        }

        private void btn_SaveNoteName_Click(object sender, EventArgs e)
        {
            if (Now_Add_NodeID == "")
                return;
            if (txt_NOTE_NAME.Text.Trim() == "")
            {
                MessageBoxEx.Show("请输入分类名!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //if (Now_Modify_NodeID == "" && Now_Add_NodeID != "")
                Now_Modify_NodeID = Now_Add_NodeID;
            TreeNode[] tr = trv_InterestPatient.Nodes.Find(Now_Modify_NodeID, true);
            if (tr.Length > 0)
            {
                MInterestPatient mip = new MInterestPatient();
                mip.NOTE_ID = Convert.ToInt32(ID.GetSeqValue());
                mip.NOTE_NAME = txt_NOTE_NAME.Text.Trim();
                mip.DOCTOR_ID = NowDoctorID;

                TreeNode ntr = tr[0];
                if (ntr.Level == 0)
                    mip.PARENT_NOTE_ID = 0;
                else
                    mip.PARENT_NOTE_ID = Convert.ToInt32(ntr.Parent.Name);

                mip.MEMO = txt_MEMO.Text.Trim();
                mip.IS_NOTE = 0;
                int i = bItPt.Add(mip);
                if (i > 0)
                {
                    MessageBoxEx.Show("新增分类成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ntr.Text = mip.NOTE_NAME;
                }
                else
                {
                    MessageBoxEx.Show("新增分类失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Now_Modify_NodeID = "";
                Now_Add_NodeID = "";
            }
        }



    }
}