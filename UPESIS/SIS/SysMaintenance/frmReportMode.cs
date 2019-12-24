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
using ILL;

namespace SIS.SysMaintenance
{
    public partial class frmReportMode : Form
    {
        private BReportTempDict BReportTpDct = new BReportTempDict();
        private BGetSeqValue ID = new BGetSeqValue("SIS", "SEQ_REPORT_TEMPLATE_NODE_ID");
        private BClinicOfficeDict BClOff = new BClinicOfficeDict();
        private string Now_Add_NodeID = "";     //记录当前新增的项目的NODE_ID
        private string Now_Modify_NodeID = "";  //记录当前修改的项目的NODE_ID
        private Point pi;                   //记录TreeView时鼠标点击的坐标
        private delegate void RefTv(int tsLevel, string tsfKey, string tssKey, string tsnKey, string tsViewTxt);    //线程中异步刷新树

        public frmReportMode()
        {
            InitializeComponent();
        }

        ///// <summary>
        ///// 绑定科室标识下拉列表框
        ///// </summary>
        //private void BindCliniCofficeID()
        //{
        //    BClinicOfficeDict BClOff = new BClinicOfficeDict();
        //    DataTable dt = BClOff.GetList("1=1 order by CLINIC_OFFICE_ID asc");

        //    DataRow dr = dt.NewRow();
        //    dt.Rows.InsertAt(dr, 0);

        //    if (dt!=null)
        //    {
        //        //科室标识
        //        cmb_CLINIC_OFFICE_ID.DataSource = dt ;
        //        cmb_CLINIC_OFFICE_ID.DisplayMember = "CLINIC_OFFICE";
        //        cmb_CLINIC_OFFICE_ID.ValueMember = "CLINIC_OFFICE_ID";
                
        //    }
        //}

        /// <summary>
        /// 绑定网格中的科室ID下拉框
        /// </summary>
        private void BindViewCliniCofficeID()
        {
            BClinicOfficeDict BClOff = new BClinicOfficeDict();
            DataTable dt_CliniCofficeID = BClOff.GetList("1=1 order by CLINIC_OFFICE_CODE asc");

            if (dt_CliniCofficeID.Rows.Count > 0)
            {
                ((DataGridViewComboBoxColumn)dgv_ReportTempDict.Columns["CLINIC_OFFICE_CODE"]).DataSource = dt_CliniCofficeID;
                ((DataGridViewComboBoxColumn)dgv_ReportTempDict.Columns["CLINIC_OFFICE_CODE"]).DisplayMember = "CLINIC_OFFICE";
                ((DataGridViewComboBoxColumn)dgv_ReportTempDict.Columns["CLINIC_OFFICE_CODE"]).ValueMember = "CLINIC_OFFICE_CODE";
            }
        }

        /// <summary>
        /// 绑定结点标志
        /// </summary>
        /// <param name="Level">当前对应的级数</param>
        private void BindSign(int Level)
        {
            cmb_NODE_SIGN.DataSource = null;
            DataTable NodeDt = new DataTable();
            NodeDt.Columns.Add(new DataColumn("nType", typeof(string)));
            NodeDt.Columns.Add(new DataColumn("nLabel", typeof(string)));
            DataRow NodeDr = NodeDt.NewRow();
            NodeDt.Rows.Add(NodeDr);
            if (Level == 0)
            {
                DataRow NodeDr1 = NodeDt.NewRow();
                DataRow NodeDr2 = NodeDt.NewRow();
                NodeDr1["nType"] = "P"; NodeDr1["nLabel"] = "父节点";
                NodeDr2["nType"] = "N"; NodeDr2["nLabel"] = "子节点";
                NodeDt.Rows.Add(NodeDr1);
                NodeDt.Rows.Add(NodeDr2);
            }
            if (Level == 1)
            {
                DataRow NodeDr1 = NodeDt.NewRow();
                DataRow NodeDr2 = NodeDt.NewRow();
                DataRow NodeDr3 = NodeDt.NewRow();
                DataRow NodeDr4 = NodeDt.NewRow();
                DataRow NodeDr5 = NodeDt.NewRow();
                NodeDr1["nType"] = "N"; NodeDr1["nLabel"] = "子节点";
                NodeDr2["nType"] = "1"; NodeDr2["nLabel"] = "诊断意见";
                NodeDr3["nType"] = "2"; NodeDr3["nLabel"] = "检查所见";
                NodeDr4["nType"] = "3"; NodeDr4["nLabel"] = "检查内容";
                NodeDr5["nType"] = "4"; NodeDr5["nLabel"] = "附注";
                NodeDt.Rows.Add(NodeDr1);
                NodeDt.Rows.Add(NodeDr2);
                NodeDt.Rows.Add(NodeDr3);
                NodeDt.Rows.Add(NodeDr4);
                NodeDt.Rows.Add(NodeDr5);
            }
            else if (Level == 2)
            {
                DataRow NodeDr1 = NodeDt.NewRow();
                DataRow NodeDr2 = NodeDt.NewRow();
                DataRow NodeDr3 = NodeDt.NewRow();
                DataRow NodeDr4 = NodeDt.NewRow();
                NodeDr1["nType"] = "1"; NodeDr1["nLabel"] = "诊断意见";
                NodeDr2["nType"] = "2"; NodeDr2["nLabel"] = "检查所见";
                NodeDr3["nType"] = "3"; NodeDr3["nLabel"] = "检查内容";
                NodeDr4["nType"] = "4"; NodeDr4["nLabel"] = "附注";
                NodeDt.Rows.Add(NodeDr1);
                NodeDt.Rows.Add(NodeDr2);
                NodeDt.Rows.Add(NodeDr3);
                NodeDt.Rows.Add(NodeDr4);
            }
            cmb_NODE_SIGN.DataSource = NodeDt;
            cmb_NODE_SIGN.DisplayMember = "nLabel";
            cmb_NODE_SIGN.ValueMember = "nType";
        }

        /// <summary>
        /// 绑定网格中的结点标志下拉框
        /// </summary>
        private void BindViewSign()
        {
            DataTable NodeDt = new DataTable();
            NodeDt.Columns.Add(new DataColumn("nType", typeof(string)));
            NodeDt.Columns.Add(new DataColumn("nLabel", typeof(string)));
            DataRow NodeDr1 = NodeDt.NewRow();
            DataRow NodeDr2 = NodeDt.NewRow();
            DataRow NodeDr3 = NodeDt.NewRow();
            DataRow NodeDr4 = NodeDt.NewRow();
            DataRow NodeDr5 = NodeDt.NewRow();
            DataRow NodeDr6 = NodeDt.NewRow();
            NodeDr1["nType"] = "P"; NodeDr1["nLabel"] = "父节点";
            NodeDr2["nType"] = "N"; NodeDr2["nLabel"] = "子节点";
            NodeDr3["nType"] = "1"; NodeDr3["nLabel"] = "诊断意见";
            NodeDr4["nType"] = "2"; NodeDr4["nLabel"] = "检查所见";
            NodeDr5["nType"] = "3"; NodeDr5["nLabel"] = "检查内容";
            NodeDr6["nType"] = "4"; NodeDr6["nLabel"] = "附注";

            NodeDt.Rows.Add(NodeDr1);
            NodeDt.Rows.Add(NodeDr2);
            NodeDt.Rows.Add(NodeDr3);
            NodeDt.Rows.Add(NodeDr4);
            NodeDt.Rows.Add(NodeDr5);
            NodeDt.Rows.Add(NodeDr6);

            ((DataGridViewComboBoxColumn)dgv_ReportTempDict.Columns["NODE_SIGN"]).DataSource = NodeDt;
            ((DataGridViewComboBoxColumn)dgv_ReportTempDict.Columns["NODE_SIGN"]).DisplayMember = "nLabel";
            ((DataGridViewComboBoxColumn)dgv_ReportTempDict.Columns["NODE_SIGN"]).ValueMember = "nType";
        }

        /// <summary>
        /// 绑定网格的医生标识
        /// </summary>
        private void BindViewDoctorName()
        {
            BClinicDoctorDict bcdd = new BClinicDoctorDict();
            DataTable dt = bcdd.GetList("1=1 order by CLINIC_DOCTOR_ID asc");

            if (dt.Rows.Count > 0)
            {
                ((DataGridViewComboBoxColumn)dgv_ReportTempDict.Columns["DOCTOR_ID"]).DataSource = dt;
                ((DataGridViewComboBoxColumn)dgv_ReportTempDict.Columns["DOCTOR_ID"]).DisplayMember = "CLINIC_DOCTOR";
                ((DataGridViewComboBoxColumn)dgv_ReportTempDict.Columns["DOCTOR_ID"]).ValueMember = "CLINIC_DOCTOR_ID";
            }
        }

        /// <summary>
        /// 绑定网格私有性下拉列表
        /// </summary>
        private void BindViewIsPrivate()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("nType", typeof(decimal)));
            dt.Columns.Add(new DataColumn("nLabel", typeof(string)));
            DataRow dr1 = dt.NewRow(); DataRow dr2 = dt.NewRow();
            dr1["nType"] = 0; dr1["nLabel"] = "公共";
            dr2["nType"] = 1; dr2["nLabel"] = "私有";
            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);
            ((DataGridViewComboBoxColumn)dgv_ReportTempDict.Columns["IS_PRIVATE"]).DataSource = dt;
            ((DataGridViewComboBoxColumn)dgv_ReportTempDict.Columns["IS_PRIVATE"]).DisplayMember = "nLabel";
            ((DataGridViewComboBoxColumn)dgv_ReportTempDict.Columns["IS_PRIVATE"]).ValueMember = "nType";

        }

        /// <summary>
        /// 填充树形列表
        /// </summary>
        /// <param name="parentid"></param>
        private void FileeTrview(object tpArray)
        {
            string[] strArray = (string[])tpArray;
            string fKey = strArray[0];
            string sKey = strArray[1];
            int parentid = Convert.ToInt32(strArray[2]);

            DataTable dt = BReportTpDct.GetList(" NODE_PARENT_ID=" + parentid + " and EXAM_CLASS = '" + GetConfig.RS_TempExamClass + "'  Order by NODE_ID");

            //if (dt.Rows.Count == 0) return;

            foreach (DataRow dr in dt.Rows)
            {
                string ViewTxt = dr["NODE_NAME"].ToString().Trim();
                string nKey = dr["NODE_ID"].ToString();
                if (fKey == "")
                {
                    RefTv dlg = new RefTv(Del_FillTrv);       //创建委托,填充树
                    this.BeginInvoke(dlg, new object[] { 0,fKey ,sKey,nKey, ViewTxt });
                    //trv_ReportTempDict.Nodes.Add(nKey, ViewTxt);
                    FileeTrview(new string[3] { nKey, "", nKey });
                }
                else
                {
                    if (sKey == "")
                    {
                        RefTv dlg1 = new RefTv(Del_FillTrv);       //创建委托,填充树
                        this.BeginInvoke(dlg1, new object[] { 1,fKey ,sKey, nKey, ViewTxt });
                        // trv_ReportTempDict.Nodes[fKey].Nodes.Add(nKey, ViewTxt);
                        FileeTrview(new string[] { fKey, nKey, nKey });
                    }
                    else
                    {
                        RefTv dlg2 = new RefTv(Del_FillTrv);       //创建委托,填充树
                        this.BeginInvoke(dlg2, new object[] { 2,fKey,sKey, nKey, ViewTxt });
                        //trv_ReportTempDict.Nodes[fKey].Nodes[sKey].Nodes.Add(nKey, ViewTxt);
                    }
                }
            }
        }

        private void Del_FillTrv(int Level, string fKey, string sKey, string nKey, string ViewTxt)
        {
            switch (Level)
            {
                case 0:
                    trv_ReportTempDict.Nodes.Add(nKey, ViewTxt);
                    break;
                case 1:
                    trv_ReportTempDict.Nodes[fKey].Nodes.Add(nKey, ViewTxt);
                    break;
                case 2:
                    trv_ReportTempDict.Nodes[fKey].Nodes[sKey].Nodes.Add(nKey, ViewTxt);
                    break;
            }
        }

        private void ReportMode_Load(object sender, EventArgs e)
        {
            this.btn_FunName.Text = this.Text.ToString();
            dgv_ReportTempDict.AutoGenerateColumns = false;

            //FileeTrview("","",0);
            NewThreadFill("", "", 0);

            cmb_IS_PRIVATE.Items.Add("");
            cmb_IS_PRIVATE.Items.Add("公共");
            cmb_IS_PRIVATE.Items.Add("私有");
        }

        private void btn_Clean_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in myPnl.Controls)
            {
                if (ctr is TextBox)
                    ctr.Text = "";
                else if (ctr is ComboBox)
                    ctr.Text = "";
            }
        }

        /// <summary>
        /// 检查必需输入内容是否为空
        /// </summary>
        /// <returns>true-代表必填内容有为空</returns>
        private bool ChgNull()
        {
            if (cmb_IS_PRIVATE.Text.Trim() == "")
            {
                MessageBoxEx.Show("私有性不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;

        }

        private void ReportMode_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                //BindCliniCofficeID();
                BindViewCliniCofficeID();
                BindViewDoctorName();
                //BindViewSign();
                BindViewIsPrivate();
            }
        }

        private void trv_ReportTempDict_DoubleClick(object sender, EventArgs e)
        {
            TreeNode tn = trv_ReportTempDict.GetNodeAt(pi);
            if (tn != null)
            {
                //节点标志只能为当前和下一级
                BindSign(tn.Level);

                Now_Modify_NodeID = tn.Name;

                DataTable dt = BReportTpDct.GetList(" NODE_ID=" + tn.Name);
                DataTable ndt = BReportTpDct.GetList2(" start with NODE_PARENT_ID =" + tn.Name + " CONNECT BY PRIOR NODE_ID=NODE_PARENT_ID order by NODE_ID");
                if (dt == null) { btn_Clean_Click(null, null); dgv_ReportTempDict.DataSource = null; return; }
                dt.Merge(ndt);
                
                DataRow[] dr = dt.Select("NODE_ID=" + tn.Name);
                if (dr.Length < 1) { btn_Clean_Click(null, null); dgv_ReportTempDict.DataSource = null; return; }

                //cmb_CLINIC_OFFICE_ID.SelectedValue = dr[0]["CLINIC_OFFICE_ID"].ToString();
                
                cmb_NODE_SIGN.SelectedValue  =dr[0]["NODE_SIGN"].ToString();
                if (dr[0]["IS_PRIVATE"].ToString().Trim() == "0")
                    cmb_IS_PRIVATE.Text  = "公共";
                else if (dr[0]["IS_PRIVATE"].ToString().Trim() == "1")
                    cmb_IS_PRIVATE.Text = "私有";
                else
                    cmb_IS_PRIVATE.Text = "";

                txt_INPUT_CODE.Text = dr[0]["INPUT_CODE"].ToString().Trim();
                txt_Icdcode.Text = dr[0]["ICD10_CODE"].ToString().Trim();
                txt_SORT_FLAG.Text = dr[0]["SORT_FLAG"].ToString().Trim();
                txt_NODE_NAME.Text = dr[0]["NODE_NAME"].ToString().Trim();
                if (tn.Level < 2)
                    txt_NODE_NAME.Enabled = true;
                else
                {
                    //txt_NODE_NAME.Enabled = false;
                }
                txt_NODE_DEPICT.Text = dr[0]["NODE_DEPICT"].ToString().Trim();

                dgv_ReportTempDict.DataSource = dt;
            }
        }

        private void cms_Add_Click(object sender, EventArgs e)
        {
            

        }

        private void cms_Delete_Click(object sender, EventArgs e)
        {
            DialogResult dlrs = MessageBoxEx.Show("确认删除选中的记录!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dlrs == DialogResult.No) return;

            TreeNode tr = trv_ReportTempDict.SelectedNode;
            if (tr != null)
            {
                string sKey = tr.Name;
                if (sKey == Now_Add_NodeID)
                {
                    Now_Add_NodeID = "";
                    Now_Modify_NodeID = "";
                    trv_ReportTempDict.Nodes.Remove(tr);
                }
                else
                {
                    int j = BReportTpDct.Delete(" where NODE_ID=" + sKey);

                    if (j >= 0)
                    {
                        MessageBoxEx.Show("删除成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        trv_ReportTempDict.Nodes.Remove(tr);
                        Now_Modify_NodeID = "";
                    }
                    else
                        MessageBoxEx.Show("删除失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsm_li_Click(object sender, EventArgs e)
        {
            trv_ReportTempDict.CollapseAll();
        }

        private void trv_ReportTempDict_MouseDown(object sender, MouseEventArgs e)
        {
            pi = new Point(e.X, e.Y);
            trv_ReportTempDict.SelectedNode = trv_ReportTempDict.GetNodeAt(pi);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (Now_Modify_NodeID == "") return;

            if (ChgNull()) return;

            MReportTempDict MRptTemp = new MReportTempDict();
            MRptTemp.NODE_ID = Convert.ToInt32(Now_Modify_NodeID);

            if (txt_SORT_FLAG.Text.Trim() != "")
            {
                if (!ExpressionValidat.IsNumeric(txt_SORT_FLAG.Text.Trim()))
                {
                    MessageBoxEx.Show("请输入数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MRptTemp.SORT_FLAG = Convert.ToInt32(txt_SORT_FLAG.Text.Trim());
            }

            TreeNode[] tn = trv_ReportTempDict.Nodes.Find(Now_Modify_NodeID, true);
            if (tn[0].Level == 0)
                MRptTemp.NODE_PARENT_ID = 0;
            else
                MRptTemp.NODE_PARENT_ID =Convert.ToInt32(tn[0].Parent.Name);

            MRptTemp.NODE_NAME = txt_NODE_NAME.Text.Trim();
            MRptTemp.NODE_DEPICT = txt_NODE_DEPICT.Text.Trim();
            MRptTemp.NODE_SIGN = cmb_NODE_SIGN.SelectedValue.ToString();
            MRptTemp.INPUT_CODE = txt_INPUT_CODE.Text.ToString().Trim();
            MUser user = (MUser)frmMainForm.iUser;
            MRptTemp.DOCTOR_ID = user.DOCTOR_ID;
            MRptTemp.EXAM_CLASS = GetConfig.RS_TempExamClass;
            MRptTemp.ICD10_CODE = txt_Icdcode.Text.Trim();

            if (cmb_IS_PRIVATE.Text.Trim() == "公共")
                MRptTemp.IS_PRIVATE = 0;
            else if (cmb_IS_PRIVATE.Text.Trim() == "私有")
                MRptTemp.IS_PRIVATE = 1;
            
            bool bl = BReportTpDct.Exists(MRptTemp);
            if (bl)
            {
                int i = BReportTpDct.Update(MRptTemp, " where  NODE_ID=" + MRptTemp.NODE_ID);
                if (i >= 0)
                {
                    tn[0].Text = txt_NODE_NAME.Text;
                    MessageBoxEx.Show("修改成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_Clean_Click(null, null);
                    Now_Add_NodeID = "";
                    Now_Modify_NodeID = "";

                }
                else
                    MessageBoxEx.Show("修改失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int i = BReportTpDct.Add(MRptTemp);

                if (i > 0)
                {
                    tn[0].Text = txt_NODE_NAME.Text;
                    MessageBoxEx.Show("添加成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_Clean_Click(null, null);
                    Now_Add_NodeID = "";
                    Now_Modify_NodeID = "";
                }
                else
                    MessageBoxEx.Show("添加失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_ReportTempDict_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void cms_Add_Equ_Click(object sender, EventArgs e)
        {
            if (Now_Add_NodeID != "")
            {
                MessageBoxEx.Show("有新增项未保存!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Now_Add_NodeID = ID.GetSeqValue().ToString();
            TreeNode TR = trv_ReportTempDict.SelectedNode;
            if (TR == null)
            {
                trv_ReportTempDict.Nodes.Insert(0, Now_Add_NodeID, "双击进行修改");
            }
            else
            {
                switch (TR.Level)
                {
                    case 0:
                        trv_ReportTempDict.Nodes.Insert(0, Now_Add_NodeID, "双击进行修改");
                        break;
                    case 1:
                        TR.Parent.Nodes.Insert(TR.Index - 1, Now_Add_NodeID, "双击进行修改");
                        break;
                    case 2:
                        TR.Parent.Nodes.Insert(TR.Index - 1, Now_Add_NodeID, "双击进行修改");
                        break;
                }
            }
            trv_ReportTempDict.SelectedNode = trv_ReportTempDict.Nodes.Find(Now_Add_NodeID, true)[0];
        }

        private void cms_Add_Next_Click(object sender, EventArgs e)
        {
            if (Now_Add_NodeID != "")
            {
                MessageBoxEx.Show("有新增项未保存!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Now_Add_NodeID = ID.GetSeqValue().ToString();
            TreeNode TR = trv_ReportTempDict.SelectedNode;
            if (TR == null)
            {
                trv_ReportTempDict.Nodes.Insert(0, Now_Add_NodeID, "双击进行修改");
            }
            else
            {
                if (TR.Level == 2) { Now_Add_NodeID = ""; return; }
                TR.Nodes.Insert(0 , Now_Add_NodeID, "双击进行修改");
            }
            trv_ReportTempDict.SelectedNode = trv_ReportTempDict.Nodes.Find(Now_Add_NodeID, true)[0];
        }

        private void cmb_NODE_SIGN_SelectedIndexChanged(object sender, EventArgs e)
        {
            TreeNode[] tr = trv_ReportTempDict.Nodes.Find(Now_Modify_NodeID, true);

            if (tr != null)
            {
                if (tr.Length > 0)
                {
                    if (tr[0].Level == 2)
                    {
                        txt_NODE_NAME.Text = cmb_NODE_SIGN.Text;
                        //txt_NODE_NAME.Enabled = false;
                    }
                    else
                        txt_NODE_NAME.Enabled = true;
                }
            }
        }

        private void NewThreadFill(string strF, string strS, int Flag)
        {
            trv_ReportTempDict.Nodes.Clear();

            string[] strArray = new string[3];
            strArray[0] = strF;
            strArray[1] = strS;
            strArray[2] = Flag.ToString();
            FileeTrview(strArray);
            //Thread nThead = new Thread(new ParameterizedThreadStart(FileeTrview));
            //nThead.IsBackground = true;
            //nThead.Start(strArray);
        }

    }
}