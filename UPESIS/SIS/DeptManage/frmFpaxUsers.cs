using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using PACS_Model;
using SIS_BLL;
using System.Collections;


namespace SIS.DeptManage
{
    /// <summary>
    /// PACS的用户管理
    /// </summary>
    public partial class frmFpaxUsers : Form
    {
        private MUser muser = new MUser();
        private BUser buser = new BUser();

        public frmFpaxUsers()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 界面加载时，初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FpaxUsers_Load(object sender, EventArgs e)
        {
            this.btn_FunName.Text = this.Text;
            this.dgv_ImgEquipment.AutoGenerateColumns = false;

            BindContro_ReportStyle();
            //BindContro_ReportCapability();
            BindContro_Handup_Style();

            BindContro_Capability();
            BindContro_Chat_Capability();
            BindContro_Skin_Style();
        }
        #region -页面加载数据绑定-
        /// <summary>
        /// 绑定报告风格
        /// </summary>
        private void BindContro_ReportStyle()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("nType", typeof(decimal)));
            dt.Columns.Add(new DataColumn("nLabel", typeof(string)));

            DataRow NodeDr1 = dt.NewRow();
            DataRow NodeDr2 = dt.NewRow();
            NodeDr1["nType"] = 0; NodeDr1["nLabel"] = "标准型";
            NodeDr2["nType"] = 1; NodeDr2["nLabel"] = "简易型";
            dt.Rows.Add(NodeDr1);
            dt.Rows.Add(NodeDr2);

            ((DataGridViewComboBoxColumn)dgv_ImgEquipment.Columns["USER_REPORT_STYLE"]).DataSource = dt;
            ((DataGridViewComboBoxColumn)dgv_ImgEquipment.Columns["USER_REPORT_STYLE"]).DisplayMember = "nLabel";
            ((DataGridViewComboBoxColumn)dgv_ImgEquipment.Columns["USER_REPORT_STYLE"]).ValueMember = "nType";

            DataTable dtl = dt.Copy();
            DataRow NodeDr = dtl.NewRow();
            dtl.Rows.InsertAt(NodeDr, 0);
            cmb_ReportStyle.DataSource = dtl;
            cmb_ReportStyle.DisplayMember = "nLabel";
            cmb_ReportStyle.ValueMember = "nType";
        }

        /// <summary>
        /// 绑定报告能力
        /// </summary>
        private void BindContro_ReportCapability()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("nType", typeof(Int32)));
            dt.Columns.Add(new DataColumn("nLabel", typeof(string)));
            DataRow NodeDr = dt.NewRow();
            dt.Rows.Add(NodeDr);

            DataRow NodeDr1 = dt.NewRow();
            DataRow NodeDr2 = dt.NewRow();
            NodeDr1["nType"] = 0; NodeDr1["nLabel"] = "只能看报告";
            NodeDr2["nType"] = 1; NodeDr2["nLabel"] = "可写报告";
            dt.Rows.Add(NodeDr1);
            dt.Rows.Add(NodeDr2);
            cmb_ReportCapability.DataSource = dt;
            cmb_ReportCapability.DisplayMember = "nLabel";
            cmb_ReportCapability.ValueMember = "nType";
        }

        /// <summary>
        /// 绑定报告提交设置
        /// </summary>
        private void BindContro_Handup_Style()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("nType", typeof(decimal)));
            dt.Columns.Add(new DataColumn("nLabel", typeof(string)));

            DataRow NodeDr1 = dt.NewRow();
            DataRow NodeDr2 = dt.NewRow();
            NodeDr1["nType"] = 0; NodeDr1["nLabel"] = "手动提交";
            NodeDr2["nType"] = 1; NodeDr2["nLabel"] = "自动提交";
            dt.Rows.Add(NodeDr1);
            dt.Rows.Add(NodeDr2);

            ((DataGridViewComboBoxColumn)dgv_ImgEquipment.Columns["USER_HANDUP_STYLE"]).DataSource = dt;
            ((DataGridViewComboBoxColumn)dgv_ImgEquipment.Columns["USER_HANDUP_STYLE"]).DisplayMember = "nLabel";
            ((DataGridViewComboBoxColumn)dgv_ImgEquipment.Columns["USER_HANDUP_STYLE"]).ValueMember = "nType";

            DataTable dtl = dt.Copy();
            DataRow NodeDr = dtl.NewRow();
            dtl.Rows.InsertAt(NodeDr, 0);

            cmb_Handup_Style.DataSource = dtl;
            cmb_Handup_Style.DisplayMember = "nLabel";
            cmb_Handup_Style.ValueMember = "nType";
        }

        /// <summary>
        /// 绑定权限级别
        /// </summary>
        private void BindContro_Capability()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("nType", typeof(decimal)));
            dt.Columns.Add(new DataColumn("nLabel", typeof(string)));

            DataRow NodeDr1 = dt.NewRow();
            DataRow NodeDr2 = dt.NewRow();
            DataRow NodeDr3 = dt.NewRow();
            DataRow NodeDr4 = dt.NewRow();
            DataRow NodeDr5 = dt.NewRow();
            NodeDr1["nType"] = 9; NodeDr1["nLabel"] = "主任，副主任医师";
            NodeDr2["nType"] = 6; NodeDr2["nLabel"] = "主治医师";
            NodeDr3["nType"] = 4; NodeDr3["nLabel"] = "普通医师";
            NodeDr4["nType"] = 3; NodeDr4["nLabel"] = "技师";
            NodeDr5["nType"] = 1; NodeDr5["nLabel"] = "临床医生";
            dt.Rows.Add(NodeDr1);
            dt.Rows.Add(NodeDr2);
            dt.Rows.Add(NodeDr3);
            dt.Rows.Add(NodeDr4);
            dt.Rows.Add(NodeDr5);

            ((DataGridViewComboBoxColumn)dgv_ImgEquipment.Columns["CAPABILITY"]).DataSource = dt;
            ((DataGridViewComboBoxColumn)dgv_ImgEquipment.Columns["CAPABILITY"]).DisplayMember = "nLabel";
            ((DataGridViewComboBoxColumn)dgv_ImgEquipment.Columns["CAPABILITY"]).ValueMember = "nType";

            DataTable dtl = dt.Copy();
            DataRow NodeDr = dtl.NewRow();
            dtl.Rows.InsertAt(NodeDr, 0);
            cmb_Capability.DataSource = dtl;
            cmb_Capability.DisplayMember = "nLabel";
            cmb_Capability.ValueMember = "nType";
        }

        /// <summary>
        /// 绑写即时通级别
        /// </summary>
        private void BindContro_Chat_Capability()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("nType", typeof(Int32)));
            dt.Columns.Add(new DataColumn("nLabel", typeof(string)));
            DataRow NodeDr = dt.NewRow();
            dt.Rows.Add(NodeDr);

            DataRow NodeDr1 = dt.NewRow();
            DataRow NodeDr2 = dt.NewRow();
            DataRow NodeDr3 = dt.NewRow();
            DataRow NodeDr4 = dt.NewRow();
            DataRow NodeDr5 = dt.NewRow();
            DataRow NodeDr6 = dt.NewRow();
            DataRow NodeDr7 = dt.NewRow();
            DataRow NodeDr8 = dt.NewRow();
            DataRow NodeDr9 = dt.NewRow();
            NodeDr1["nType"] = 1; NodeDr1["nLabel"] = "一级";
            NodeDr2["nType"] = 2; NodeDr2["nLabel"] = "二级";
            NodeDr3["nType"] = 3; NodeDr3["nLabel"] = "三级";
            NodeDr4["nType"] = 4; NodeDr4["nLabel"] = "四级";
            NodeDr5["nType"] = 5; NodeDr5["nLabel"] = "五级";
            NodeDr6["nType"] = 6; NodeDr6["nLabel"] = "六级";
            NodeDr7["nType"] = 7; NodeDr7["nLabel"] = "七级";
            NodeDr8["nType"] = 8; NodeDr8["nLabel"] = "八级";
            NodeDr9["nType"] = 9; NodeDr9["nLabel"] = "九级";
            dt.Rows.Add(NodeDr1);
            dt.Rows.Add(NodeDr2);
            dt.Rows.Add(NodeDr3);
            dt.Rows.Add(NodeDr4);
            dt.Rows.Add(NodeDr5);
            dt.Rows.Add(NodeDr6);
            dt.Rows.Add(NodeDr7);
            dt.Rows.Add(NodeDr8);
            dt.Rows.Add(NodeDr9);
            cmb_Chat_Capability.DataSource = dt;
            cmb_Chat_Capability.DisplayMember = "nLabel";
            cmb_Chat_Capability.ValueMember = "nType";
        }

        /// <summary>
        /// 绑定界面风格
        /// </summary>
        private void BindContro_Skin_Style()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("nType", typeof(decimal)));
            dt.Columns.Add(new DataColumn("nLabel", typeof(string)));

            DataRow NodeDr1 = dt.NewRow();
            DataRow NodeDr2 = dt.NewRow();
            DataRow NodeDr3 = dt.NewRow();
            DataRow NodeDr4 = dt.NewRow();
            NodeDr1["nType"] = 0; NodeDr1["nLabel"] = "系统默认";
            NodeDr2["nType"] = 1; NodeDr2["nLabel"] = "Blue";
            NodeDr3["nType"] = 2; NodeDr3["nLabel"] = "MSN";
            NodeDr4["nType"] = 3; NodeDr4["nLabel"] = "DiamondBlue";
            dt.Rows.Add(NodeDr1);
            dt.Rows.Add(NodeDr2);
            dt.Rows.Add(NodeDr3);
            dt.Rows.Add(NodeDr4);

            ((DataGridViewComboBoxColumn)dgv_ImgEquipment.Columns["USER_SKIN_STYLE"]).DataSource = dt;
            ((DataGridViewComboBoxColumn)dgv_ImgEquipment.Columns["USER_SKIN_STYLE"]).DisplayMember = "nLabel";
            ((DataGridViewComboBoxColumn)dgv_ImgEquipment.Columns["USER_SKIN_STYLE"]).ValueMember = "nType";

            DataTable dtl = dt.Copy();
            DataRow NodeDr = dtl.NewRow();
            dtl.Rows.InsertAt(NodeDr, 0);

            cmb_Skin_Style.DataSource = dtl;
            cmb_Skin_Style.DisplayMember = "nLabel";
            cmb_Skin_Style.ValueMember = "nType";
        }
        #endregion

        /// <summary>
        /// 界面可视改变时，执行的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FpaxUsers_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                BindContro_DeptName();
                FindData("");
            }
        }

        /// <summary>
        /// 绑定科室名称
        /// </summary>
        private void BindContro_DeptName()
        {
            BClinicOfficeDict bclOff = new BClinicOfficeDict();
            DataTable dt = bclOff.GetList(" 1=1 order by DEPT_CODE");

            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);

                cmb_DeptName.DataSource = dt;
                cmb_DeptName.DisplayMember = "DEPT_NAME";
                cmb_DeptName.ValueMember = "DEPT_CODE";
            }
        }

        /// <summary>
        /// 获取PACS用户列表并填充
        /// </summary>
        /// <param name="strWhere"></param>
        private void FindData(string strWhere)
        {
            DataTable dt = buser.GetList(strWhere + " 1=1 order by DB_USER");
            if (dt != null)
            {
                dgv_ImgEquipment.DataSource = dt;
            }

        }

        /// <summary>
        /// 当单击查找时，执行按条件查找用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Find_Click(object sender, EventArgs e)
        {
            StringBuilder sgbd = new StringBuilder();

            if (txt_DbUser.Text.Trim() != "")
                sgbd.Append(" DB_USER Like '%" + txt_DbUser.Text.Trim() + "%' and ");
            if (txt_UserName.Text.Trim() != "")
                sgbd.Append(" USER_NAME like '%" + txt_UserName.Text.Trim() + "%' and ");
            if (txt_UserId.Text.Trim() != "")
                sgbd.Append(" USER_ID like '%" + txt_UserId.Text.Trim() + "%' and ");
            if (cmb_DeptName.Text.Trim() != "")
                sgbd.Append(" DEPT_NAME like '%" + cmb_DeptName.Text.Trim() + "%' and ");

            FindData(sgbd.ToString());
        }

        /// <summary>
        /// 保存时，获取输入内容
        /// </summary>
        /// <returns></returns>
        private bool GetControlData()
        {
            if (txt_DbUser.Text.Trim() == "")
            {
                MessageBoxEx.Show("用户代码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txt_UserId.Text.Trim() == "")
            {
                MessageBoxEx.Show("用户ID不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txt_UserName.Text.Trim() == "")
            {
                MessageBoxEx.Show("用户名不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txt_UserPwd.Text.Trim() == "")
            {
                MessageBoxEx.Show("用户密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cmb_ReportStyle.Text == "")
            {
                MessageBoxEx.Show("报告风格不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cmb_Handup_Style.Text == "")
            {
                MessageBoxEx.Show("提交报告设置不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cmb_DeptName.Text == "")
            {
                MessageBoxEx.Show("科室名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cmb_Capability.Text == "")
            {
                MessageBoxEx.Show("仅限级别不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cmb_Chat_Capability.Text == "")
            {
                MessageBoxEx.Show("即时通讯级别不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cmb_Skin_Style.Text == "")
            {
                MessageBoxEx.Show("界面风格不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            muser.DB_USER = txt_DbUser.Text.Trim();
            muser.USER_NAME = txt_UserName.Text.Trim();
            muser.USER_PWD = txt_UserPwd.Text.Trim();
            muser.USER_ID = txt_UserId.Text.Trim();
            muser.USER_REPORT_STYLE = Convert.ToInt32(cmb_ReportStyle.SelectedValue);

            //muser.USER_REPORT_STYLE = Convert.ToInt32(cmb_ReportCapability.SelectedValue);
            muser.USER_HANDUP_STYLE = Convert.ToInt32(cmb_Handup_Style.SelectedValue);
            muser.DEPT_NAME = cmb_DeptName.Text;
            muser.USER_DEPT = cmb_ReportStyle.SelectedValue.ToString();
            muser.CAPABILITY = Convert.ToInt32(cmb_Capability.SelectedValue);
            muser.USER_CHAT_CAPABILITY = Convert.ToInt32(cmb_Chat_Capability.SelectedValue);
            muser.USER_SKIN_STYLE = Convert.ToInt32(cmb_Skin_Style.SelectedValue);
            muser.CREATE_DATE = DateTime.Now;

            StringBuilder strBuild = new StringBuilder();
            for (int i = 0; i < cLB_Application.Items.Count; i++)
            {
                if (cLB_Application.GetItemChecked(i))
                    strBuild.Append(cLB_Application.Items[i].ToString() + ";");
            }
            if (strBuild.Length > 0)
                muser.APPLICATION = strBuild.ToString();

            if (!string.IsNullOrEmpty(txt_UserCustomData.Text.Trim()))
                muser.USER_CUSTOM_DATA = txt_UserCustomData.Text.Trim();

            StringBuilder strBuild1 = new StringBuilder();
            for (int i = 0; i < cLB_Module_Capability.Items.Count; i++)
            {
                if (cLB_Module_Capability.GetItemChecked(i))
                    strBuild1.Append(cLB_Module_Capability.Items[i].ToString() + ";");
            }
            if (strBuild.Length > 0)
                muser.MODULE_CAPABILITY = strBuild1.ToString();

            //string Sqlstr = "select " +
            //           "db_user ," +
            //           "user_id ," +
            //           "user_name ," +
            //           "user_pwd ," +
            //           "dept_name ," +
            //           "user_dept,"+
            //           "decode(capability,1,'临床医生',3,'技师',4,'普通医师',6,'主治医师',9,'主任，副主任医师') as capability ," +
            //           "module_capability ," +
            //           "decode(user_handup_style,0,'手动提交',1,'自动提交') as user_handup_style," +
            //           "decode(user_report_style,0,'标准型',1,'简易型') as user_report_style," +
            //           "decode(user_skin_style,0,'系统默认',1,'Blue',2,'MSN',3,'DiamondBlue') as user_skin_style," +
            //           "create_date ," +
            //           "application ,"+
            //           "decode(user_chat_capability,1,'一级',2,'二级',3,'三级',4,'四级',5,'五级',6,'六级',7,'七级',8,'八级',9,'九级') as user_chat_capability," +
            //           "user_custom_data " +
            //           " from fpax_users ";
            return true;
        }

        /// <summary>
        /// 当单击保存时，执行增加或更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            bool bl = GetControlData();
            if (!bl) return;

            bool bol = buser.Exists(muser);
            if (!bl)
            {
                int i = buser.Add(muser);
                if (i > 0)
                {
                    MessageBoxEx.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FindData("");
                    btn_Clean_Click(null, null);
                }
                else
                {
                    MessageBoxEx.Show("添加失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                int j = buser.Update(muser, " where DB_USER='" + muser.DB_USER + "'");
                if (j > 0)
                {
                    MessageBoxEx.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FindData("");
                    btn_Clean_Click(null, null);
                }
                else
                {
                    MessageBoxEx.Show("修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        /// <summary>
        /// 当单击清空时，对上部分的内容清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Clean_Click(object sender, EventArgs e)
        {
            foreach (Control crl in pl_Top.Controls)
            {
                if (crl is TextBox)
                    crl.Text = "";
                else if (crl is ComboBox)
                    crl.Text = "";
                else if (crl is CheckedListBox)
                {
                    CheckedListBox clb = (CheckedListBox)crl;
                    for (int i = 0; i < clb.Items.Count; i++)
                        clb.SetItemChecked(i, false);
                }
            }
        }

        /// <summary>
        /// 当单击删除时，执行PACS用户删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Del_Click(object sender, EventArgs e)
        {
            DialogResult dlrs = MessageBoxEx.Show("确认删除选中的记录!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dlrs == DialogResult.No) return;

            DataGridViewSelectedRowCollection src = dgv_ImgEquipment.SelectedRows;
            if (src != null)
            {
                Hashtable ht = new Hashtable();

                for (int i = 0; i < src.Count; i++)
                {
                    ht.Add(i.ToString(), src[i].Cells["DB_USER"].Value.ToString().Trim());
                }

                int j = buser.DeleteMore(ht);
                if (j > 0)
                {
                    MessageBoxEx.Show("删除成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FindData("");
                }
                else
                    MessageBoxEx.Show("删除失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 当用户列表中，产生单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_ImgEquipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_Clean_Click(null, null);

            txt_DbUser.Text = dgv_ImgEquipment.Rows[e.RowIndex].Cells["DB_USER"].Value.ToString();
            txt_UserName.Text = dgv_ImgEquipment.Rows[e.RowIndex].Cells["USER_NAME"].Value.ToString();
            txt_UserPwd.Text = dgv_ImgEquipment.Rows[e.RowIndex].Cells["USER_PWD"].Value.ToString();//对应网格隐藏
            txt_UserId.Text = dgv_ImgEquipment.Rows[e.RowIndex].Cells["USER_ID"].Value.ToString();
            cmb_DeptName.SelectedValue = dgv_ImgEquipment.Rows[e.RowIndex].Cells["USER_DEPT"].Value.ToString();//对应网格隐藏
            cmb_ReportStyle.SelectedValue = dgv_ImgEquipment.Rows[e.RowIndex].Cells["USER_REPORT_STYLE"].Value.ToString();
            cmb_Handup_Style.SelectedValue = dgv_ImgEquipment.Rows[e.RowIndex].Cells["USER_HANDUP_STYLE"].Value.ToString();
            cmb_Skin_Style.SelectedValue = dgv_ImgEquipment.Rows[e.RowIndex].Cells["USER_SKIN_STYLE"].Value.ToString();
            cmb_Capability.SelectedValue = dgv_ImgEquipment.Rows[e.RowIndex].Cells["CAPABILITY"].Value.ToString();
            cmb_Chat_Capability.SelectedValue = dgv_ImgEquipment.Rows[e.RowIndex].Cells["USER_CHAT_CAPABILITY"].Value.ToString();//对应网格隐藏
            txt_UserCreatDate.Text = dgv_ImgEquipment.Rows[e.RowIndex].Cells["CREATE_DATE"].Value.ToString();

            string strApplication = dgv_ImgEquipment.Rows[e.RowIndex].Cells["APPLICATION"].Value.ToString();
            string[] sArray = strApplication.Split(';');
            foreach (string s in sArray)
            {
                for (int i = 0; i < cLB_Application.Items.Count; i++)
                {
                    if (cLB_Application.Items[i].ToString() == s)
                    {
                        cLB_Application.SetItemChecked(i, true);
                        break;
                    }

                }
            }

            strApplication = dgv_ImgEquipment.Rows[e.RowIndex].Cells["MODULE_CAPABILITY"].Value.ToString();
            sArray = strApplication.Split(';');
            foreach (string s in sArray)
            {
                for (int i = 0; i < cLB_Module_Capability.Items.Count; i++)
                {
                    if (cLB_Module_Capability.Items[i].ToString() == s)
                    {
                        cLB_Module_Capability.SetItemChecked(i, true);
                        break;
                    }

                }
            }
            txt_UserCustomData.Text = dgv_ImgEquipment.Rows[e.RowIndex].Cells["USER_CUSTOM_DATA"].Value.ToString();
        }

        private void dgv_ImgEquipment_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

    }
}