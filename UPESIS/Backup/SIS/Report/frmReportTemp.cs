using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SIS_BLL;
using SIS_Model;
using BaseControls;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using ILL;

namespace SIS
{
    public partial class frmReportTemp : BaseControls.Docking.DockContent
    {
        private delegate void GetTreeNode(TreeNode[] RootTree, bool isExpand);
        private BReportTempDict BReportTemp = new BReportTempDict();
        //private DataSet rootDs;
        public SIS.frmReportEdit.PicBoxClick pbClick;
        private MReportTempDict MReporttemp;             //当前选中的树节点Model
        private MReportTempDict NewMReporttemp;          //记录当前新增的报告模板Model
        private MReportTempDict CopyMReporttemp;         //记录当前新增的报告模板Model
        private string[] splitresults;
        public EditRTBox[] eRTBoxs;
        private bool isEdit = false;
        private BGetSeqValue ID;
        private WordClass word;
        public bool isSendToRpt = true; //是否双击典型病历或模板图片按钮就提取模板内容并填充到报告中
        private bool isDelete = false;
        private DataSet rootDs;
        private bool isInit = false;

        public DataTable dtDeptNodes; //属于该科室的模板节点标识
        public frmReportTemp(frmReportEdit.PicBoxClick picClick,WordClass Word)
        {
            InitializeComponent();
            pbClick = picClick;
            this.word = Word;
            ID = new BGetSeqValue("SIS", "SEQ_REPORT_TEMPLATE_NODE_ID");
            dtDeptNodes = GetNodesDt();
        }

        #region 模板加载
        /// <summary>
        /// 搜索根结点
        /// </summary>
        public void RootSearch()
        {
           
            this.isInit = true;
            this.tree_Template.Nodes.Clear();
            NewMReporttemp = null;
            CopyMReporttemp = null;
            this.cmb_Part.DataSource = null;
            GetTreeNode gettreenode = new GetTreeNode(addTreeNode);
            //string sql = "select * from report_template_dict where EXAM_CLASS  = '" + GetConfig.RS_TempExamClass + "' " +
            //    "and (IS_PRIVATE = 0 or (IS_PRIVATE =1 and DOCTOR_ID = '" + ((SIS_Model.MUser)frmMainForm.iUser).DOCTOR_ID + "')) order by SORT_FLAG asc,NODE_ID asc";
            string sql = "select * from report_template_dict where(EXAM_CLASS  = '" + GetConfig.RS_TempExamClass + "' " +
                " and IS_PRIVATE=0) or (IS_PRIVATE =1 and DOCTOR_ID = '" + ((SIS_Model.MUser)frmMainForm.iUser).DOCTOR_ID + "') order by SORT_FLAG asc,NODE_ID asc";//可实现跨科显示个人模板
            rootDs = BReportTemp.GetTable(sql);// this.operate.getDataSet(, this.conn);
            
            DataRow[] dr = rootDs.Tables[0].Select("NODE_PARENT_ID = 0 ");
            DataSet dsRoot = new DataSet();
            dsRoot.Merge(dr);
            if (dsRoot.Tables.Count > 0)
            {
                TreeNode[] RootTree = new TreeNode[dsRoot.Tables[0].Rows.Count];
                for (int i = 0; i < dsRoot.Tables[0].Rows.Count; i++)
                {
                    RootTree[i] = new TreeNode(dsRoot.Tables[0].Rows[i]["NODE_NAME"].ToString().Trim());
                    RootTree[i].Name = dsRoot.Tables[0].Rows[i]["NODE_ID"].ToString().Trim();
                    this.searchNode(dsRoot.Tables[0].Rows[i]["NODE_ID"].ToString().Trim(), RootTree[i]);
                }
                this.tree_Template.BeginInvoke(gettreenode, new object[] { RootTree, false });
                DataRow newdr = dsRoot.Tables[0].NewRow();
                dsRoot.Tables[0].Rows.InsertAt(newdr, 0);
                this.cmb_Part.DataSource = dsRoot.Tables[0];
                this.cmb_Part.DisplayMember = "NODE_NAME";
                this.cmb_Part.ValueMember = "NODE_ID";
            }
            else
            {
                TreeNode[] RootTree = new TreeNode[1];
                MReporttemp = new MReportTempDict();
                MReporttemp.EXAM_CLASS = GetConfig.RS_TempExamClass;
                MReporttemp.IS_PRIVATE = 0;
                MReporttemp.NODE_DEPICT = "";
                MReporttemp.NODE_ID = Convert.ToInt32(ID.GetSeqValue());
                MReporttemp.NODE_NAME = "新增部位分类";
                MReporttemp.NODE_PARENT_ID = 0;
                MReporttemp.NODE_SIGN = "P";
                BReportTemp.Add(MReporttemp);
                RootTree[0] = new TreeNode(MReporttemp.NODE_NAME);
                RootTree[0].Name = MReporttemp.NODE_ID.ToString();
                this.tree_Template.BeginInvoke(gettreenode, new object[] { RootTree, false });
            }
            this.isInit = false;
        }
        /// <summary>
        /// 搜索子结点
        /// </summary>
        public void searchNode(string parentid, System.Windows.Forms.TreeNode treenode)
        {
            DataSet templateDs = new DataSet();
            DataRow[] dr = this.rootDs.Tables[0].Select("NODE_PARENT_ID = '" + parentid + "'");
            templateDs.Merge(dr);
            if (templateDs.Tables.Count > 0)
            {
                for (int j = 0; j < templateDs.Tables[0].Rows.Count; j++)
                {
                    treenode.Nodes.Add(templateDs.Tables[0].Rows[j]["NODE_ID"].ToString().Trim(), templateDs.Tables[0].Rows[j]["NODE_NAME"].ToString().Trim());
                    this.searchNode(templateDs.Tables[0].Rows[j]["NODE_ID"].ToString().Trim(), treenode.Nodes[j]);
                }
            }
        }

        private void cmb_Part_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.isInit||this.cmb_Part.SelectedItem == null)
                return;
            this.tree_Template.Nodes.Clear();
            NewMReporttemp = null;
            CopyMReporttemp = null;
            GetTreeNode gettreenode = new GetTreeNode(addTreeNode);
            System.Data.DataRow cmbdr = (cmb_Part.SelectedItem as System.Data.DataRowView).Row;
            DataRow[] dr;
            if(cmbdr["NODE_ID"].ToString()=="")
                dr = rootDs.Tables[0].Select("NODE_PARENT_ID = 0 ");
            else
                dr = rootDs.Tables[0].Select("NODE_PARENT_ID = " + cmbdr["NODE_ID"].ToString());
            DataSet dsRoot = new DataSet();
            dsRoot.Merge(dr);
            List<TreeNode> RootTree = new List<TreeNode>();
            if (dsRoot.Tables.Count > 0)
            {
                for (int i = 0; i < dsRoot.Tables[0].Rows.Count; i++)
                {
                    RootTree.Add(new TreeNode(dsRoot.Tables[0].Rows[i]["NODE_NAME"].ToString().Trim()));
                    RootTree[i].Name = dsRoot.Tables[0].Rows[i]["NODE_ID"].ToString().Trim();
                    this.searchNode(dsRoot.Tables[0].Rows[i]["NODE_ID"].ToString().Trim(), RootTree[i]);
                }
            }
            this.tree_Template.BeginInvoke(gettreenode, new object[] { RootTree.ToArray(), false });
        }
        private void addTreeNode(TreeNode[] RootTree, bool isExpand)
        {
            try
            {
                this.tree_Template.Nodes.AddRange(RootTree);
                if (isExpand)
                {
                    this.tree_Template.ExpandAll();
                    this.tree_Template.SelectedNode = this.tree_Template.Nodes[0];
                }
            }
            catch { }
        }
        #endregion 模板加载

        #region 获取报告模板内容

        private void tree_Template_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.tree_Template.SelectedNode == null || this.tree_Template.Nodes.Count == 0 || this.tree_Template.SelectedNode.Name == "")
                return;
            this.GetNode(tree_Template.SelectedNode);
        }

        private void GetNode(TreeNode treenode)
        {
            this.p_Content.Controls.Clear();
            eRTBoxs = null;
            if (NewMReporttemp != null && treenode.Name == NewMReporttemp.NODE_ID.ToString())
                MReporttemp = NewMReporttemp;
            else
                MReporttemp = (MReportTempDict)BReportTemp.GetModel(treenode.Name);
            splitresults = null;
            if (MReporttemp != null)
            {
                if (MReporttemp.NODE_DEPICT != "" && treenode.GetNodeCount(true) == 0)
                {
                    string str = MReporttemp.NODE_DEPICT;
                    splitresults = str.Split('&');
                    eRTBoxs = new EditRTBox[splitresults.Length];
                    this.reportContext(splitresults);
                }
                if (this.isEdit)
                    this.EditTem();
            }
        }

        /// <summary>
        /// 填充报告模板内容
        /// </summary>
        private void reportContext(string[] Split)
        {
            for (int i = 0; i < Split.Length; i++)
            {
                string text = Split[i].ToString().Trim();
                eRTBoxs[i] = new EditRTBox();
                eRTBoxs[i].pictureBox.Name = "pb" + i;
                eRTBoxs[i].pictureBox.Image = imageList.Images[0];
                eRTBoxs[i].pictureBox.Click += new EventHandler(pb_Click);
                eRTBoxs[i].richTextBox.Name = "linkedit" + i;
                eRTBoxs[i].richTextBox.Font = new System.Drawing.Font("宋体", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                eRTBoxs[i].richTextBox.ReadOnly = true;
                eRTBoxs[i].SetLinkText(text);
                eRTBoxs[i].Dock = DockStyle.Top;
                this.p_Content.Controls.Add(eRTBoxs[i]);
            }
        }

        /// <summary>
        /// 图片单击事件
        /// </summary>
        private void pb_Click(object sender, System.EventArgs e)
        {
            if (!this.isSendToRpt)
                return;
            int count = Convert.ToInt32(((Control)sender).Name.Substring(2));
            string txt = eRTBoxs[count].richTextBox.Text.Trim();
            this.pbClick(MReporttemp.NODE_SIGN, txt);
        }

        private void tree_Template_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (tree_Template.SelectedNode != null && MReporttemp != null&&this.isSendToRpt)
                GetTemplate();
        }


        #region menu_Context

        /// <summary>
        /// 获取术语
        /// </summary>
        private void GetTemplate()
        {
            DataTable dt = this.BReportTemp.GetList(" NODE_PARENT_ID= " + MReporttemp.NODE_ID);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    pbClick(dt.Rows[i]["NODE_SIGN"].ToString(), dt.Rows[i]["NODE_DEPICT"].ToString());
                }
            }
        }

        #endregion

        #endregion

        #region 编辑报告模板

        /// <summary>
        /// 绑定结点标志
        /// </summary>
        /// <param name="Level">当前对应的级数</param>
        private void BindSign(string sign)
        {
            try
            {
                cmb_NodeSign.Items.Clear();
                switch (sign.Trim())
                {
                    case "P":
                        cmb_NodeSign.Items.Add("部位分类");
                        break;
                    case "N":
                        cmb_NodeSign.Items.Add("其它分类");
                        break;
                    case "Y":
                        cmb_NodeSign.Items.Add("典型病历");
                        break;
                    default:
                        cmb_NodeSign.Items.Add(FindNode(sign.Trim())["TYPE_NAME"].ToString());
                        break;
                }
                cmb_NodeSign.SelectedIndex = 0;
            }
            catch
            {
            }
        }

        public DataRow FindNode(string NodeSign)
        {
            DataTable dt = dtDeptNodes;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (NodeSign.Trim() == dt.Rows[i]["NODE_SIGN"].ToString().Trim())
                    return dt.Rows[i];
            }
            return null;
        }
        /// <summary>
        /// 保存报告模板
        /// </summary>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            bool isNeedUpdate = false;
            if (txt_NodeName.Text.Contains("新增") &&NodeSignExist(MReporttemp.NODE_SIGN))
                MReporttemp.NODE_NAME = txt_NodeName.Text.Replace("新增", "");
            else
                MReporttemp.NODE_NAME = txt_NodeName.Text.Trim();
            if (MReporttemp.IS_PRIVATE == 0 && cmb_IsPrivate.SelectedIndex == 1 || MReporttemp.IS_PRIVATE == 1 && cmb_IsPrivate.SelectedIndex == 0)
                isNeedUpdate = true;
            MReporttemp.IS_PRIVATE = cmb_IsPrivate.SelectedIndex;
            if (cmb_IsPrivate.SelectedIndex == 1)
                MReporttemp.DOCTOR_ID = ((MUser)frmMainForm.iUser).DOCTOR_ID;
            else
                MReporttemp.DOCTOR_ID = "";
            MReporttemp.ICD10_CODE = txt_Icdcode.Text.Trim();
            MReporttemp.INPUT_CODE = txt_InputCode.Text.Trim();
            if (txt_SortFlag.Text.Trim() != "")
                MReporttemp.SORT_FLAG = Convert.ToInt32(txt_SortFlag.Text);
            int i = 0;
            if (eRTBoxs != null)
            {
                MReporttemp.NODE_DEPICT = "";
                for (i = 0; i < eRTBoxs.Length; i++)
                {
                    if (this.eRTBoxs[i].richTextBox.Text.Trim() != "")
                        MReporttemp.NODE_DEPICT += eRTBoxs[i].richTextBox.Text.Trim() + "&";
                }
                MReporttemp.NODE_DEPICT = MReporttemp.NODE_DEPICT.TrimEnd('&');
            }
            i = -1;
            if (BReportTemp.Exists(MReporttemp))
                i = BReportTemp.Update(MReporttemp, " where NODE_ID =" + MReporttemp.NODE_ID);
            else
                i = BReportTemp.Add(MReporttemp);
            if (i < 0)
                MessageBoxEx.Show("保存失败！", "警告");
            else
            {
                if (isNeedUpdate)
                    UpdateNode(MReporttemp, MReporttemp.IS_PRIVATE, MReporttemp.DOCTOR_ID);
                this.tree_Template.SelectedNode.Text = MReporttemp.NODE_NAME;
                if (NewMReporttemp != null && this.tree_Template.SelectedNode.Name == NewMReporttemp.NODE_ID.ToString())
                    NewMReporttemp = null;
            }
        }

        private void UpdateNode(MReportTempDict tem, int? IsPrivate, string DoctorId)
        {
            MReportTempDict[] rptTemp = (MReportTempDict[])BReportTemp.GetModels(tem.NODE_ID.ToString());
            if (rptTemp == null)
                return;
            for (int i = 0; i < rptTemp.Length; i++)
            {
                rptTemp[i].IS_PRIVATE = IsPrivate;
                rptTemp[i].DOCTOR_ID = DoctorId;
                BReportTemp.Update(rptTemp[i], " where NODE_ID = " + rptTemp[i].NODE_ID.ToString());
                UpdateNode(rptTemp[i], IsPrivate, DoctorId);
            }
        }

        /// <summary>
        /// 修改报告模板
        /// </summary>
        private void tsmi_Edit_Click(object sender, EventArgs e)
        {
            if (this.tree_Template.SelectedNode == null || MReporttemp == null)
                return;
            this.EditTem();
        }

        /// <summary>
        /// 给修改模板控件赋值
        /// </summary>
        private void EditTem()
        {
            if (MReporttemp.NODE_SIGN != "P" && MReporttemp.NODE_SIGN != "N" && MReporttemp.NODE_SIGN != "Y")
            {
                this.txt_NodeName.ReadOnly = false ;
                this.txt_NodeName.BackColor = Color.LightGray;
            }
            else
            {
                this.txt_NodeName.ReadOnly = false;
                this.txt_NodeName.BackColor = Color.White;
            }
            BindSign(MReporttemp.NODE_SIGN);
            this.txt_NodeName.Text = MReporttemp.NODE_NAME;
            this.txt_InputCode.Text = MReporttemp.INPUT_CODE;
            this.txt_Icdcode.Text = MReporttemp.ICD10_CODE;
            if (MReporttemp.SORT_FLAG != null)
                this.txt_SortFlag.Text = MReporttemp.SORT_FLAG.ToString();
            else
                this.txt_SortFlag.Text = "";
            this.cmb_IsPrivate.SelectedIndex = Convert.ToInt32(MReporttemp.IS_PRIVATE);
            if (MReporttemp.NODE_SIGN == "P")
                this.cmb_IsPrivate.Enabled = true;
            else
            {
                if (NodeSignExist(MReporttemp.NODE_SIGN))
                    this.cmb_IsPrivate.Enabled = false;
                else
                    this.cmb_IsPrivate.Enabled = ((MReportTempDict)BReportTemp.GetModel(MReporttemp.NODE_PARENT_ID.ToString())).IS_PRIVATE == 0 ? true : false;
            }
            if (!this.isEdit)
            {
                this.p_Edit.Visible = true;
                this.isEdit = true;
                this.tsmi_Edit.Enabled = false;
            }
            if (this.eRTBoxs == null)
            {
                if (NodeSignExist(MReporttemp.NODE_SIGN))
                {
                    string str = MReporttemp.NODE_DEPICT;
                    splitresults = str.Split('&');
                    eRTBoxs = new EditRTBox[1];
                    this.reportContext(splitresults);
                    this.eRTBoxs[0].richTextBox.BorderStyle = BorderStyle.Fixed3D;
                    this.eRTBoxs[0].richTextBox.ReadOnly = false;
                }
            }
            else
            {
                for (int i = 0; i < this.eRTBoxs.Length; i++)
                {
                    this.eRTBoxs[i].richTextBox.BorderStyle = BorderStyle.Fixed3D;
                    this.eRTBoxs[i].richTextBox.ReadOnly = false;
                    this.eRTBoxs[i].richTextBox.Text = this.eRTBoxs[i].GetLinkText();
                }
            }
        }

        private MReportTempDict NewRptTempDict()
        {
            string NewNodeID = ID.GetSeqValue().ToString();
            MReportTempDict temp = new MReportTempDict();
            temp.NODE_ID = Convert.ToInt32(NewNodeID);
            if (MReporttemp.IS_PRIVATE == null)
                temp.IS_PRIVATE = 0;
            else
                temp.IS_PRIVATE = MReporttemp.IS_PRIVATE;
            temp.SORT_FLAG = 0;
            temp.EXAM_CLASS = GetConfig.RS_TempExamClass;
            temp.ICD10_CODE = "";
            temp.INPUT_CODE = "";
            temp.NODE_DEPICT = "";
            return temp;
        }

        private void tsmi_Delete_Click(object sender, EventArgs e)
        {
            DialogResult dlrs;
            TreeNode tr = tree_Template.SelectedNode;
            if (tr == null)
                return;
            string sKey = tr.Name;
            DataTable dt = BReportTemp.GetList(" NODE_PARENT_ID = " + sKey);
            if (dt != null && dt.Rows.Count > 0)
            {
                dlrs = MessageBoxEx.Show("该报告模板有级联子模板，是否级联删除！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dlrs == DialogResult.No) return;
            }
            else
            {
                dlrs = MessageBoxEx.Show("确认删除选中的报告模板！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dlrs == DialogResult.No) return;
            }
            this.isDelete = false;
            if (NewMReporttemp != null)
            {
                if (sKey == NewMReporttemp.NODE_ID.ToString() || sKey == NewMReporttemp.NODE_PARENT_ID.ToString())
                {
                    NewMReporttemp = null;
                    MReporttemp = null;
                    tree_Template.Nodes.Remove(tr);
                    this.isDelete = true;
                }
                else
                    DeleteNode(tr,sKey, NewMReporttemp.NODE_PARENT_ID.ToString());
            }
            if (!this.isDelete)
            {
                Delete(tr);
                this.isDelete = true;
            }
        }

        //递归查找新增的结点是否在要删除的结点下
        private void DeleteNode(TreeNode tr,string NodeId,string NewNodeId)
        {
            if (this.isDelete)
                return;
            DataTable dt = BReportTemp.GetList(" NODE_PARENT_ID = " + NodeId);
            if (dt.Rows.Count == 0)
                return;
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (NewNodeId == dt.Rows[i]["NODE_ID"].ToString())
                    {
                        NewMReporttemp = null;
                        MReporttemp = null;
                        Delete(tr);
                        this.isDelete = true;
                        return;
                    }
                    else
                        DeleteNode(tr, dt.Rows[i]["NODE_ID"].ToString(),NewNodeId);
                }
            }

        }

        private void Delete(TreeNode tr)
        {
            int j = BReportTemp.Delete(" where NODE_ID = " + tr.Name + " or NODE_PARENT_ID = " + tr.Name);
            if (j >= 0)
            {
                //MessageBoxEx.Show("删除成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tree_Template.Nodes.Remove(tr);
                MReporttemp = null;
            }
            else
                MessageBoxEx.Show("删除失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Exit(bool isClear)
        {
            this.p_Edit.Visible = false;
            this.isEdit = false;
            this.tsmi_Edit.Enabled = true;
            if (this.eRTBoxs == null)
                return;
            string t = "";
            for (int i = 0; i < this.eRTBoxs.Length; i++)
            {
                if (this.eRTBoxs[i].richTextBox.Text.Trim() != "")
                    t += this.eRTBoxs[i].richTextBox.Text + "&";
            }
            this.p_Content.Controls.Clear();
            if (isClear)
                return;
            splitresults = t.TrimEnd('&').Split('&');
            eRTBoxs = new EditRTBox[splitresults.Length];
            this.reportContext(splitresults);
        }


        /// <summary>
        /// 退出编辑报告模板
        /// </summary>
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Exit(false);
        }
        #endregion

        private void tree_Template_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    TreeView tv = sender as TreeView;
                    TreeNode select = tv.GetNodeAt(e.Location);
                    if (select != null)
                    {
                        tv.SelectedNode = select;
                    }
                }
                catch (Exception ex)
                {
                    //异常处理
                }
                dtDeptNodes = GetNodesDt();//加载本科室节点标识
                if (this.tree_Template.SelectedNode != null && MReporttemp != null)
                {
                    tsmi_Add_Equ.DropDownItems.Clear();
                    tsmi_Add_Next.DropDownItems.Clear();
                    switch (MReporttemp.NODE_SIGN)
                    {
                        case "P":
                            tsmi_Add_Equ.Enabled = true;
                            tsmi_Add_Next.Enabled = true;
                            this.CreateP(this.tsmi_Add_Equ);
                            this.CreateNextNY(this.tsmi_Add_Next);
                            if (CopyMReporttemp != null && (CopyMReporttemp.NODE_SIGN == "P" || CopyMReporttemp.NODE_SIGN == "N"))
                                this.tsmi_PasteEqu.Enabled = true;
                            else
                                this.tsmi_PasteEqu.Enabled = false;
                            if (CopyMReporttemp != null && (CopyMReporttemp.NODE_SIGN == "P" || CopyMReporttemp.NODE_SIGN == "N" || CopyMReporttemp.NODE_SIGN == "Y"))
                                this.tsmi_PasteNext.Enabled = true;
                            else
                                this.tsmi_PasteNext.Enabled = false;
                            this.tsmi_ImportRptTem.Enabled = true;
                            break;
                        case "N":
                            tsmi_Add_Equ.Enabled = true;
                            tsmi_Add_Next.Enabled = true;
                            this.CreateNextNY(this.tsmi_Add_Next);
                            this.CreateEquNY(this.tsmi_Add_Equ);
                            if (CopyMReporttemp != null && (CopyMReporttemp.NODE_SIGN != "P" && CopyMReporttemp.NODE_SIGN != "N" && CopyMReporttemp.NODE_SIGN != "Y"))
                            {
                                this.tsmi_PasteEqu.Enabled = false;
                                this.tsmi_PasteNext.Enabled = false;
                            }
                            else
                            {
                                this.tsmi_PasteEqu.Enabled = true;
                                this.tsmi_PasteNext.Enabled = true;
                            }
                            this.tsmi_ImportRptTem.Enabled = true;
                            break;
                        case "Y":
                            tsmi_Add_Equ.Enabled = true;
                            tsmi_Add_Next.Enabled = true;
                            this.CreateEquNY(this.tsmi_Add_Equ);
                            this.CreateMI(this.tsmi_Add_Next, MReporttemp.NODE_ID.ToString());
                            if (CopyMReporttemp != null && (CopyMReporttemp.NODE_SIGN == "N" || CopyMReporttemp.NODE_SIGN == "Y"))
                                this.tsmi_PasteEqu.Enabled = true;
                            else
                                this.tsmi_PasteEqu.Enabled = false;
                            if (CopyMReporttemp != null && NodeSignExist(CopyMReporttemp.NODE_SIGN))
                                this.tsmi_PasteNext.Enabled = true;
                            else
                                this.tsmi_PasteNext.Enabled = false;
                            this.tsmi_ImportRptTem.Enabled = false;
                            break;
                        default:
                            tsmi_Add_Equ.Enabled = false;
                            tsmi_Add_Next.Enabled = false;
                            tsmi_PasteEqu.Enabled = false;
                            tsmi_PasteNext.Enabled = false;
                            tsmi_ImportRptTem.Enabled = false;
                            break;
                    }
                }
            }
        }
        //判断本科室中是否存在该结点标志
        private bool NodeSignExist(string NodeSign)
        {
            DataTable dt = dtDeptNodes;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (NodeSign == dt.Rows[i]["NODE_SIGN"].ToString().Trim())
                    return true;
            }
            return false;
        }
        #region 新增报告模板

        private void CreateP(ToolStripMenuItem tsmi)
        {
            ToolStripMenuItem tsmiP = new ToolStripMenuItem();
            tsmiP.Name = "tsmi_P";
            tsmiP.Text = "部位分类";
            tsmiP.Click += new EventHandler(tsmiP_Click);
            tsmi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiP });
        }

        private void tsmiP_Click(object sender, EventArgs e)
        {
            if (!this.Check())
                return;
            NewMReporttemp = NewRptTempDict();
            NewMReporttemp.NODE_NAME = "新增部位";
            NewMReporttemp.NODE_SIGN = "P";
            NewMReporttemp.NODE_PARENT_ID = 0;
            AddNew(NewMReporttemp, false);
        }

        private bool Check()
        {
            if (NewMReporttemp != null)
            {
                MessageBoxEx.Show("有新增项未保存!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tree_Template.SelectedNode = this.tree_Template.Nodes.Find(NewMReporttemp.NODE_ID.ToString(), true)[0];
                return false;
            }
            if (this.tree_Template.SelectedNode == null || MReporttemp == null)
                return false;
            return true;
        }
        private void AddNew(MReportTempDict tem, bool isNext)
        {
            MReporttemp = tem;
            this.EditTem();
            TreeNode TR = tree_Template.SelectedNode;
            if (TR == null)
            {
                tree_Template.Nodes.Insert(0, tem.NODE_ID.ToString(), tem.NODE_NAME);
            }
            else
            {
                if (isNext)
                    TR.Nodes.Insert(0, tem.NODE_ID.ToString(), tem.NODE_NAME);
                else
                {
                    if (TR.Level == 0)
                        tree_Template.Nodes.Insert(0, tem.NODE_ID.ToString(), tem.NODE_NAME);
                    else
                        TR.Parent.Nodes.Insert(TR.Index - 1, tem.NODE_ID.ToString(), tem.NODE_NAME);
                }
            }
            tree_Template.SelectedNode = tree_Template.Nodes.Find(tem.NODE_ID.ToString(), true)[0];
        }

        private void CreateEquNY(ToolStripMenuItem tsmi)
        {
            ToolStripMenuItem tsmiEquN = new ToolStripMenuItem();
            tsmiEquN.Name = "tsmi_EquN";
            tsmiEquN.Text = "其他分类";
            tsmiEquN.Click += new EventHandler(tsmiEquN_Click);
            ToolStripMenuItem tsmiEquY = new ToolStripMenuItem();
            tsmiEquY.Name = "tsmi_EquY";
            tsmiEquY.Text = "典型病历";
            tsmiEquY.Click += new EventHandler(tsmiEquY_Click);
            tsmi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiEquN, tsmiEquY });
        }

        private void tsmiEquY_Click(object sender, EventArgs e)
        {
            if (!this.Check())
                return;
            NewMReporttemp = NewRptTempDict();
            NewMReporttemp.NODE_NAME = "新增病历";
            NewMReporttemp.NODE_SIGN = "Y";
            NewMReporttemp.NODE_PARENT_ID = MReporttemp.NODE_PARENT_ID;
            AddNew(NewMReporttemp, false);
        }

        private void tsmiEquN_Click(object sender, EventArgs e)
        {
            if (!this.Check())
                return;
            NewMReporttemp = NewRptTempDict();
            NewMReporttemp.NODE_NAME = "新增分类";
            NewMReporttemp.NODE_SIGN = "N";
            NewMReporttemp.NODE_PARENT_ID = MReporttemp.NODE_PARENT_ID;
            AddNew(NewMReporttemp, false);
            this.txt_NodeName.Focus();
        }

        private void CreateNextNY(ToolStripMenuItem tsmi)
        {
            ToolStripMenuItem tsmiNextN = new ToolStripMenuItem();
            tsmiNextN.Name = "tsmi_NextN";
            tsmiNextN.Text = "其他分类";
            tsmiNextN.Click += new EventHandler(tsmiNextN_Click);
            ToolStripMenuItem tsmiNextY = new ToolStripMenuItem();
            tsmiNextY.Name = "tsmi_NextY";
            tsmiNextY.Text = "典型病历";
            tsmiNextY.Click += new EventHandler(tsmiNextY_Click);
            tsmi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiNextN, tsmiNextY });
        }
        private void tsmiNextY_Click(object sender, EventArgs e)
        {
            if (!this.Check())
                return;
            NewMReporttemp = NewRptTempDict();
            NewMReporttemp.NODE_NAME = "新增病历";
            NewMReporttemp.NODE_SIGN = "Y";
            NewMReporttemp.NODE_PARENT_ID = MReporttemp.NODE_ID;
            AddNew(NewMReporttemp, true);
            this.txt_NodeName.Focus();
        }

        private void tsmiNextN_Click(object sender, EventArgs e)
        {
            if (!this.Check())
                return;
            NewMReporttemp = NewRptTempDict();
            NewMReporttemp.NODE_NAME = "新增分类";
            NewMReporttemp.NODE_SIGN = "N";
            NewMReporttemp.NODE_PARENT_ID = MReporttemp.NODE_ID;
            AddNew(NewMReporttemp, true);
            this.txt_NodeName.Focus();
        }
        private DataTable GetNodesDt()
        {
            string sql = "select * from TEMPLATE_TYPE_DICT where DEPT_CODE='" + ((MUser)frmMainForm.iUser).CLINIC_OFFICE_CODE + "'";
            DataTable dt = new ILL.DGetSeqValue().GetDataTable(sql);
            return dt;
        }
        private void CreateMI(ToolStripMenuItem tsmi, string nodeId)
        {

            DataTable dt = dtDeptNodes;
            DataTable dtNodes=BReportTemp.GetList(" NODE_PARENT_ID = " + nodeId + " and EXAM_CLASS='"+GetConfig.RS_TempExamClass+"'");
            ToolStripItem[] ToolItems = new ToolStripItem[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ToolStripMenuItem tsmi1 = new ToolStripMenuItem();
                tsmi1.Name = dt.Rows[i]["NODE_SIGN"].ToString().Trim();
                tsmi1.Text = dt.Rows[i]["TYPE_NAME"].ToString().Trim();
                tsmi1.Enabled = true;
                for (int j = 0; j < dtNodes.Rows.Count; j++)
                {
                    if (dt.Rows[i]["NODE_SIGN"].ToString().Trim() == dtNodes.Rows[j]["NODE_SIGN"].ToString().Trim())
                    {
                        tsmi1.Enabled = false;
                        break;
                    }
                }
                tsmi1.Click += new EventHandler(tsmi1_Click);
                ToolItems[i] = tsmi1;
            }
            tsmi.DropDownItems.AddRange(ToolItems);
            
        }
        private void tsmi1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            if (!this.Check())
                return;
            NewMReporttemp = NewRptTempDict();
            NewMReporttemp.NODE_NAME = "新增"+tsmi.Text;
            NewMReporttemp.NODE_SIGN = tsmi.Name;
            NewMReporttemp.NODE_PARENT_ID = MReporttemp.NODE_ID;
            AddNew(NewMReporttemp, true);
            this.eRTBoxs[0].richTextBox.Focus();
        }

        #endregion

        private void tsmi_Copy_Click(object sender, EventArgs e)
        {
            if (tree_Template.SelectedNode != null && MReporttemp != null)
            {
                CopyMReporttemp = MReporttemp;
            }
        }

        private void PasteNode(MReportTempDict tem, int? ParentId, int? IsPrivate, string DoctorId, TreeNode node, bool isNext, ref List<MReportTempDict> AddTem)
        {
            int OldNodeId = Convert.ToInt32(tem.NODE_ID);
            tem.NODE_ID = Convert.ToInt32(ID.GetSeqValue());
            tem.NODE_PARENT_ID = ParentId;
            tem.IS_PRIVATE = IsPrivate;
            tem.DOCTOR_ID = DoctorId;
            if (ParentId != 0 && tem.NODE_SIGN == "P")
                tem.NODE_SIGN = "N";
            if (ParentId == 0)
                tem.NODE_SIGN = "P";
            AddTem.Add(tem);

            if (node == null)
            {
                tree_Template.Nodes.Insert(0, tem.NODE_ID.ToString(), tem.NODE_NAME);
            }
            else
            {
                if (isNext)
                    node.Nodes.Insert(0, tem.NODE_ID.ToString(), tem.NODE_NAME);
                else
                {
                    if (node.Level == 0)
                        tree_Template.Nodes.Insert(0, tem.NODE_ID.ToString(), tem.NODE_NAME);
                    else
                        node.Parent.Nodes.Insert(node.Index - 1, tem.NODE_ID.ToString(), tem.NODE_NAME);
                }
            }
            TreeNode newNode = tree_Template.Nodes.Find(tem.NODE_ID.ToString(), true)[0];

            MReportTempDict[] rptTemp = (MReportTempDict[])BReportTemp.GetModels(OldNodeId.ToString());
            if (rptTemp == null)
                return;
            for (int i = 0; i < rptTemp.Length; i++)
            {
                PasteNode(rptTemp[i], tem.NODE_ID, IsPrivate, DoctorId, newNode, true, ref AddTem);
            }
        }

        private void tsmi_PasteEqu_Click(object sender, EventArgs e)
        {
            if (CopyMReporttemp != null && this.tree_Template.SelectedNode != null)
            {
                MReportTempDict copyTem = (MReportTempDict)BReportTemp.GetModel(CopyMReporttemp.NODE_ID.ToString());
                List<MReportTempDict> AddTem = new List<MReportTempDict>();
                if (MReporttemp.NODE_PARENT_ID != 0)
                {
                    MReportTempDict temP = (MReportTempDict)BReportTemp.GetModel(MReporttemp.NODE_PARENT_ID.ToString());
                    PasteNode(copyTem, temP.NODE_ID, temP.IS_PRIVATE, temP.DOCTOR_ID, tree_Template.SelectedNode, false, ref AddTem);
                }
                else
                    PasteNode(copyTem, 0, 0, "", null, false, ref  AddTem);
                BReportTemp.AddMore(AddTem.ToArray());
            }
        }

        private void tsmi_PasteNext_Click(object sender, EventArgs e)
        {
            if (CopyMReporttemp != null && this.tree_Template.SelectedNode != null)
            {
                List<MReportTempDict> AddTem = new List<MReportTempDict>();
                MReportTempDict copyTem = (MReportTempDict)BReportTemp.GetModel(CopyMReporttemp.NODE_ID.ToString());
                PasteNode(copyTem, MReporttemp.NODE_ID, MReporttemp.IS_PRIVATE, MReporttemp.DOCTOR_ID, tree_Template.SelectedNode, true, ref AddTem);
                BReportTemp.AddMore(AddTem.ToArray());
            }
        }

        private void tsmi_li_Click(object sender, EventArgs e)
        {
            if (this.tree_Template.SelectedNode == null)
                this.tree_Template.CollapseAll();
            else
                this.tree_Template.SelectedNode.Collapse();
        }

        private void tsmi_ImportRptTem_Click(object sender, EventArgs e)
        {
            if (this.tree_Template.SelectedNode == null)
                return;
            WordClass.Template tem = word.GetTemplate();
            frmImpRptToTem imp = new frmImpRptToTem(tem, MReporttemp);
            if (imp.ShowDialog() == DialogResult.OK)
            {
                MReportTempDict[] NewTemps = imp.NewTems;
                this.tree_Template.SelectedNode.Nodes.Insert(0, NewTemps[0].NODE_ID.ToString(), NewTemps[0].NODE_NAME);
                TreeNode newNode = tree_Template.Nodes.Find(NewTemps[0].NODE_ID.ToString(), true)[0];
                newNode.Nodes.Insert(0, NewTemps[1].NODE_ID.ToString(), NewTemps[1].NODE_NAME);
                newNode.Nodes.Insert(1, NewTemps[2].NODE_ID.ToString(), NewTemps[2].NODE_NAME);
            }

        }

        private void tsmi_Refresh_Click(object sender, EventArgs e)
        {
            this.RootSearch();
        }

        private void frmReportTemp_Load(object sender, EventArgs e)
        {
            clsIme.SetIme(this);
        }

    }
}