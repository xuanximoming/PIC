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
using System.Threading;

namespace SIS.SysMaintenance
{
    public partial class frmInterestPatient : Form
    {
        private BInterestPatient bItPt = new BInterestPatient();
        private string NowDoctorID = "";        //当前登陆医生的ID
        private delegate TreeNode delFiilTree(TreeNode tnd, string sKey, string ViewTxt);    //线程中异步刷新树
        private BGetSeqValue ID = new BGetSeqValue("SIS", "SEQ_INTEREST_PATIENT_NOTE_ID");
        private string Now_Add_NodeID = "";     //记录当前新增的项目的NOTE_ID
        private string Now_Modify_NodeID = "";  //记录当前修改的项目的NOTE_ID
        private Point pi;                   //记录TreeView时鼠标点击的坐标

        public frmInterestPatient()
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
                if (dr["IS_NOTE"].ToString() == "1") return;
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

        private void InterestPatient_Load(object sender, EventArgs e)
        {
            this.btn_FunName.Text = this.Text.ToString();
            MUser user = (MUser)frmMainForm.iUser;
            NowDoctorID = user.DOCTOR_ID;


            NewThreadFill(null, "0");

        }

        private void cms_Add_Equ_Click(object sender, EventArgs e)
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

        private void cms_Add_Next_Click(object sender, EventArgs e)
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
                treenode = trv_InterestPatient.Nodes.Insert(0, Now_Add_NodeID, "双击进行修改");
            else
                treenode = TR.Nodes.Insert(0, Now_Add_NodeID, "双击进行修改");

            trv_InterestPatient.SelectedNode = treenode;
        }

        private void cms_Delete_Click(object sender, EventArgs e)
        {
            DialogResult dlrs = MessageBoxEx.Show("确认删除选中的记录!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dlrs == DialogResult.No) return;

            TreeNode tr = trv_InterestPatient.SelectedNode;
            if (tr != null)
            {
                string sKey = tr.Name;
                if (sKey == Now_Add_NodeID)
                {
                    Now_Add_NodeID = "";
                    Now_Modify_NodeID = "";
                    trv_InterestPatient.Nodes.Remove(tr);
                }
                else
                {
                    int j = bItPt.Delete(" where NOtE_ID=" + sKey);

                    if (j >= 0)
                    {
                        MessageBoxEx.Show("删除成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        trv_InterestPatient.Nodes.Remove(tr);
                        Now_Modify_NodeID = "";
                    }
                    else
                        MessageBoxEx.Show("删除失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsm_li_Click(object sender, EventArgs e)
        {
            trv_InterestPatient.CollapseAll();
        }

        private void trv_InterestPatient_DoubleClick(object sender, EventArgs e)
        {
            TreeNode tn = trv_InterestPatient.GetNodeAt(pi);
            if (tn != null)
            {
                Now_Modify_NodeID = tn.Name;
                lv_Patient.Items.Clear();

                DataTable dt = bItPt.GetList(" NOTE_ID=" + Convert.ToInt32(tn.Name));
                DataTable ndt = bItPt.GetList2("  start with PARENT_NOTE_ID =" + tn.Name + " CONNECT BY PRIOR NOTE_ID=PARENT_NOTE_ID order by NOTE_ID");
                dt.Merge(ndt);

                DataRow[] dr = dt.Select("NOTE_ID=" + tn.Name);
                if (dr.Length < 1) { btn_Clean_Click(null, null); return; }

                txt_NOTE_NAME.Text = dr[0]["NOTE_NAME"].ToString();
                txt_MEMO.Text = dr[0]["MEMO"].ToString();

                foreach (DataRow orDr in dt.Rows)
                {
                    if (orDr["IS_NOTE"].ToString() == "0")
                        lv_Patient.Items.Add(orDr["NOTE_ID"].ToString(), orDr["NOTE_NAME"].ToString(), 0);
                    else if (orDr["IS_NOTE"].ToString() == "1")
                        lv_Patient.Items.Add(orDr["NOTE_ID"].ToString(), orDr["NOTE_NAME"].ToString(), 1);
                    else
                        lv_Patient.Items.Add(orDr["NOTE_ID"].ToString(), orDr["NOTE_NAME"].ToString(), null);

                    lv_Patient.Items[orDr["NOTE_ID"].ToString()].Tag = orDr["EXAM_ACCESSION_NUM"].ToString();  //记录其对应的检查申请号
                }
            }
        }

        private void trv_InterestPatient_MouseDown(object sender, MouseEventArgs e)
        {
            pi = new Point(e.X, e.Y);
            trv_InterestPatient.SelectedNode = trv_InterestPatient.GetNodeAt(pi);
        }

        private void btn_Clean_Click(object sender, EventArgs e)
        {
            txt_NOTE_NAME.Text = "";
            txt_MEMO.Text = "";
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (Now_Modify_NodeID == "" && Now_Add_NodeID == "") return;

            if (Now_Modify_NodeID == "" && Now_Add_NodeID != "")
                Now_Modify_NodeID = Now_Add_NodeID;
            TreeNode[] tr = trv_InterestPatient.Nodes.Find(Now_Modify_NodeID, true);
            if (tr.Length > 0)
            {
                TreeNode ntr = tr[0];
                MInterestPatient mip = new MInterestPatient();
                mip.NOTE_ID = Convert.ToInt32(ntr.Name);
                mip.NOTE_NAME = txt_NOTE_NAME.Text.Trim();
                if (ntr.Level == 0)
                    mip.PARENT_NOTE_ID = 0;
                else
                    mip.PARENT_NOTE_ID = Convert.ToInt32(ntr.Parent.Name);

                mip.DOCTOR_ID = NowDoctorID;
                mip.MEMO = txt_MEMO.Text.Trim();
                mip.IS_NOTE = 0;
                bool bl = bItPt.Exists(mip);

                if (bl)
                {
                    int i = bItPt.Update(mip, " where NOTE_ID=" + mip.NOTE_ID);
                    if (i >= 0)
                    {
                        MessageBoxEx.Show("修改成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ntr.Text = txt_NOTE_NAME.Text.Trim();
                        Now_Add_NodeID = "";
                        Now_Modify_NodeID = "";
                        btn_Clean_Click(null, null);
                    }
                    else
                    {
                        MessageBoxEx.Show("修改失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    int i = bItPt.Add(mip);
                    if (i > 0)
                    {
                        MessageBoxEx.Show("新增成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ntr.Text = txt_NOTE_NAME.Text.Trim();
                        Now_Add_NodeID = "";
                        Now_Modify_NodeID = "";
                        btn_Clean_Click(null, null);
                    }
                    else
                    {
                        MessageBoxEx.Show("新增失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

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

        private void lv_Patient_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem lvi = lv_Patient.GetItemAt(e.X, e.Y);
            if (lvi == null) return;
            if (lvi.ImageIndex != 1) return;

            BWorkList bwk = new BWorkList();
            MWorkList mwk = (MWorkList)bwk.GetModel(lvi.Tag.ToString());

            BReport brt = new BReport();
            MReport mrt = (MReport)brt.GetModel(lvi.Tag.ToString());

            ImageCopy ic = new ImageCopy();
            string saveDir = System.Windows.Forms.Application.StartupPath + "\\temp";
            List<ImgObj> arrayImg = ic.LoadImages(mwk, saveDir);
            frmReportEdit frmRE = new frmReportEdit();
            frmRE.initForm(mwk, mrt,ILL.GetConfig.RS_OpenWord);
            frmRE.ShowDialog();
        }

        private void lv_Patient_KeyDown(object sender, KeyEventArgs e)
        {
            ListView.SelectedListViewItemCollection LstSelColl = lv_Patient.SelectedItems;
            if (LstSelColl.Count > 0)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DialogResult dlrs = MessageBoxEx.Show("确认删除选中的记录!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dlrs == DialogResult.No) return;

                    string Name=LstSelColl[0].Name;
                    int j = bItPt.Delete(" where NOtE_ID=" + Name);
                    if (j >= 0)
                    {
                        Now_Add_NodeID = "";
                        Now_Modify_NodeID = "";
                        MessageBoxEx.Show("删除成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lv_Patient.Items.Remove(LstSelColl[0]);
                       TreeNode[] tr= trv_InterestPatient.Nodes.Find(Name, true);
                       if (tr.Length > 0)
                       {
                           trv_InterestPatient.Nodes.Remove(tr[0]);
                       }
                    }
                    else
                    {
                        MessageBoxEx.Show("删除失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}