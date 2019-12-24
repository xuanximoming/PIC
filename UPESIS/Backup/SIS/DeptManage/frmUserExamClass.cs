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
    /// PACS的用户与检查类别对照管理
    /// </summary>
    public partial class frmUserExamClass : Form
    {
        private BUser buser = new BUser();
        private BExamClass bemCls = new BExamClass();
        private BUsersRole burRl = new BUsersRole();
      
        private int NowClickRowIndex = -1; //记录当前单击的行
        private int NowDoubleClickIndex = -1;   //记录当前双击的行

        public frmUserExamClass()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 绑定左边对照列表的权限级别
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

            ((DataGridViewComboBoxColumn)dgv_USER_EXAM_CLASS_User.Columns["CAPABILITY"]).DataSource = dt;
            ((DataGridViewComboBoxColumn)dgv_USER_EXAM_CLASS_User.Columns["CAPABILITY"]).DisplayMember = "nLabel";
            ((DataGridViewComboBoxColumn)dgv_USER_EXAM_CLASS_User.Columns["CAPABILITY"]).ValueMember = "nType";
        }

        /// <summary>
        /// 查找用户信息填充到左边的网格中
        /// </summary>
        /// <param name="contidion"></param>
        private void Bind_USER_EXAM_CLASS_User(string contidion)
        {
            DataTable dt = buser.GetList(contidion + " 1=1 order by DB_USER");
            if (dt !=null )
            {
                dgv_USER_EXAM_CLASS_User.DataSource=dt;
            }
            txt_DB_USER.Text = "";
            txt_USER_NAME.Text  = "";
        }

        /// <summary>
        /// 绑定检查类别表
        /// </summary>
        private void Bind_USER_EXAM_CLASS_Exam()
        {
            dgv_User_Exam_Class.Visible = false;
            dgv_USER_EXAM_CLASS_Exam.Visible = true;

            DataTable dt = bemCls.GetList2("EXAM_CLASS");
            dgv_USER_EXAM_CLASS_Exam.DataSource = dt;
        }
        
        /// <summary>
        /// 绑定用户设定的检查类型
        /// </summary>
        /// <param name="condition"></param>
        private void Bind_User_Exam_Class(string condition)
        {
            dgv_User_Exam_Class.Visible = true;
            dgv_USER_EXAM_CLASS_Exam.Visible = false;

            DataTable dt = burRl.GetList(" DB_USER='" + condition + "'");
            dgv_User_Exam_Class.DataSource = dt;
        }

        /// <summary>
        /// 绑定左边列表的报告权限列
        /// </summary>
        private void Bind_REPORT_CAPABILITY()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("nType", typeof(decimal)));
            dt.Columns.Add(new DataColumn("nLabel", typeof(string)));
            
            DataRow NodeDr1 = dt.NewRow();
            DataRow NodeDr2 = dt.NewRow();
            DataRow NodeDr3 = dt.NewRow();
            NodeDr1["nType"] = 0; NodeDr1["nLabel"] = "只能看报告";
            NodeDr2["nType"] = 1; NodeDr2["nLabel"] = "可写报告";
            NodeDr3["nType"] = 2; NodeDr3["nLabel"] = "可审核报告";
            dt.Rows.Add(NodeDr1);
            dt.Rows.Add(NodeDr2);
            dt.Rows.Add(NodeDr3);
            ((DataGridViewComboBoxColumn)dgv_User_Exam_Class.Columns["REPORT_CAPABILITY"]).DataSource = dt;
            ((DataGridViewComboBoxColumn)dgv_User_Exam_Class.Columns["REPORT_CAPABILITY"]).DisplayMember = "nLabel";
            ((DataGridViewComboBoxColumn)dgv_User_Exam_Class.Columns["REPORT_CAPABILITY"]).ValueMember = "nType";

            DataTable ndt = dt.Copy();
            //DataRow NodeDr = ndt.NewRow();
            //ndt.Rows.Add(NodeDr);
            cmb_REPORT_CAPABILITY.DataSource = ndt;
            cmb_REPORT_CAPABILITY.DisplayMember = "nLabel";
            cmb_REPORT_CAPABILITY.ValueMember = "nType";
        }

        /// <summary>
        /// 界面加载时，执行初始化：标注类别对照；设置列表属性；绑定权限级别；绑定报告权限；绑定用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserExamClass_Load(object sender, EventArgs e)
        {
            this.btn_FunName.Text = this.Text;
            this.dgv_USER_EXAM_CLASS_User.AutoGenerateColumns = false;
            this.dgv_USER_EXAM_CLASS_Exam.AutoGenerateColumns = false;
            this.dgv_User_Exam_Class.AutoGenerateColumns = false;

            BindContro_Capability();
            Bind_REPORT_CAPABILITY();

            Bind_USER_EXAM_CLASS_User("");
        }

        /// <summary>
        /// 输入用户代码时，执行即时查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_DB_USER_TextChanged(object sender, EventArgs e)
        {
            StringBuilder sgbd=new StringBuilder ();
            if (txt_DB_USER.Text.Trim() != "")
                sgbd.Append(" DB_USER LIKE '%" + txt_DB_USER.Text.Trim() + "%' AND ");
            if (txt_USER_NAME.Text.Trim() != "")
                sgbd.Append(" USER_NAME LIKE '%" + txt_USER_NAME.Text.Trim() + "%' AND ");

            Bind_USER_EXAM_CLASS_User(sgbd.ToString());
            
        }

        /// <summary>
        /// 输入用户代码改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_USER_NAME_TextChanged(object sender, EventArgs e)
        {
            txt_DB_USER_TextChanged(null, null);
        }

        /// <summary>
        /// 对照列表任意单元格发生单击时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_USER_EXAM_CLASS_User_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NowClickRowIndex = e.RowIndex;
            NowDoubleClickIndex = -1;

            Bind_User_Exam_Class(dgv_USER_EXAM_CLASS_User.Rows[e.RowIndex].Cells["DB_USER"].Value.ToString());

        }

        /// <summary>
        /// 对照列表任意单元格发生双击时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_USER_EXAM_CLASS_User_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            NowClickRowIndex = -1;
            NowDoubleClickIndex = e.RowIndex;

            Bind_USER_EXAM_CLASS_Exam();
        }

        /// <summary>
        /// 单击保存时，执行新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvsr = dgv_USER_EXAM_CLASS_Exam.SelectedRows;
            if (dgvsr == null)
            {
                MessageBoxEx.Show("没有选中的记录!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (NowDoubleClickIndex<0) return;
            Hashtable ht = new Hashtable();
            for (int i = 0; i < dgvsr.Count; i++)
            {
                MUserExamClass muec = new MUserExamClass();
                muec.DB_USER = dgv_USER_EXAM_CLASS_User.Rows[NowDoubleClickIndex].Cells["DB_USER"].Value.ToString();
                muec.DEPT_NAME = dgv_USER_EXAM_CLASS_User.Rows[NowDoubleClickIndex].Cells["DEPT_NAME"].Value.ToString();
                muec.USER_DEPT = dgv_USER_EXAM_CLASS_User.Rows[NowDoubleClickIndex].Cells["USER_DEPT"].Value.ToString();
                muec.EXAM_CLASS =dgvsr[i].Cells["EXAM_CLASS"].Value.ToString();
                muec.REPORT_CAPABILITY = Convert.ToInt32(cmb_REPORT_CAPABILITY.SelectedValue);
                ht.Add(i, muec);
            }
            int j = burRl.AddMore(ht);

            if (j > 0)
            {
                MessageBoxEx.Show("新增报告类别成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Bind_User_Exam_Class(dgv_USER_EXAM_CLASS_User.Rows[NowDoubleClickIndex].Cells["DB_USER"].Value.ToString());
            }
            else
                MessageBoxEx.Show("新增报告类别失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        /// <summary>
        /// 当单击修改报告权限时，执行修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Mondify_Click(object sender, EventArgs e)
        {
            if (NowClickRowIndex < 0)
            {
                MessageBoxEx.Show("请双击选中需要修改的用户!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dgv_User_Exam_Class.Rows.Count < 1)
            {
                MessageBoxEx.Show("此用户还未绑定报告类别!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MUserExamClass muec = new MUserExamClass();
            muec.DB_USER = dgv_USER_EXAM_CLASS_User.Rows[NowClickRowIndex].Cells["DB_USER"].Value.ToString();
            muec.DEPT_NAME = dgv_USER_EXAM_CLASS_User.Rows[NowClickRowIndex].Cells["DEPT_NAME"].Value.ToString();
            muec.USER_DEPT = dgv_USER_EXAM_CLASS_User.Rows[NowClickRowIndex].Cells["USER_DEPT"].Value.ToString();
            muec.REPORT_CAPABILITY = Convert.ToInt32(cmb_REPORT_CAPABILITY.SelectedValue);

            int i = burRl.Update2(muec, " DB_USER='" + muec.DB_USER + "'");

            if (i > 0)
            {
                MessageBoxEx.Show("修改报告权限成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Bind_User_Exam_Class(muec.DB_USER);
            }
            else
                MessageBoxEx.Show("修改报告权限失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 当单击清空时，将用户名和用户代码清空，以及加载对照表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Clean_Click(object sender, EventArgs e)
        {
            txt_USER_NAME.Text = "";
            txt_DB_USER.Text = "";

            Bind_USER_EXAM_CLASS_Exam();
        }

        /// <summary>
        /// 当单击删除时，执行删除记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Del_Click(object sender, EventArgs e)
        {
            if (NowClickRowIndex < 0) return;
            DataGridViewSelectedRowCollection dgvsr = dgv_User_Exam_Class.SelectedRows;

            if (dgvsr != null)
            {
                DialogResult dlrs = MessageBoxEx.Show("确认删除选中的记录!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dlrs == DialogResult.No) return;

                Hashtable ht = new Hashtable();
                for (int i = 0; i < dgvsr.Count; i++)
                {
                    ht.Add(i.ToString(), dgv_USER_EXAM_CLASS_User.Rows[NowClickRowIndex].Cells["DB_USER"].Value.ToString() + ";" + dgvsr[i].Cells["EXAM_CLASS1"].Value.ToString().Trim());
                }

                int j = burRl.DeleteMore(ht);
                if (j > 0)
                {
                    MessageBoxEx.Show("删除成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Bind_User_Exam_Class(dgv_USER_EXAM_CLASS_User.Rows[NowClickRowIndex].Cells["DB_USER"].Value.ToString());
                }
                else
                    MessageBoxEx.Show("删除失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBoxEx.Show("没有选中的记录!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UserExamClass_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void dgv_USER_EXAM_CLASS_User_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void myDataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgv_User_Exam_Class_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

    }
}