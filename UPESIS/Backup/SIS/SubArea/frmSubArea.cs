using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SIS_BLL;
using SIS_Model;
using System.Collections;
using ILL;

namespace SIS
{
    public partial class frmSubArea : Form
    {
        public frmSubArea()
        {
            InitializeComponent();
        }
        private BQueueInfo bQueueInfo = new BQueueInfo();
        private BClinicOfficeDict bDept = new BClinicOfficeDict();
        private BDeptVsQueue bGroup = new BDeptVsQueue();
        private IModel iUser,iQueueInfo;
        private void frmSubArea_Load(object sender, EventArgs e)
        {
            InitData();
        }
        /// <summary>
        /// 初始化窗体
        /// </summary>
        private void InitData()
        {
            this.iUser = frmMainForm.iUser;
            initCmbExamStatus();
            DeptBind();
            GroupBind();
        }

        private void initCmbExamStatus()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("value"));
            dt.Columns.Add(new DataColumn("Text"));
            DataRow dw = dt.NewRow();
            dw[0] = "0";
            dw[1] = "未检查";
            dt.Rows.Add(dw);
            DataRow dw2 = dt.NewRow();
            dw2[0] = "1";
            dw2[1] = "已检查";
            dt.Rows.Add(dw2);
            this.cmb_ExamStatus.DataSource = dt;
            this.cmb_ExamStatus.DisplayMember = "Text";
            this.cmb_ExamStatus.ValueMember = "value";
           // this.cmb_ExamStatus.Items.Add(new string[] { "9", "已删除" });
            this.cmb_ExamStatus.SelectedIndex = 0;
        }
        /// <summary>
        /// 绑定登记列表
        /// </summary>
        private void ListBind()
        {
            string where = "";
            switch (GetConfig.SisOdbcMode)
            {
                case "ACCESS":
                    where = "VISIT_DATE>=date()  ";
                    break;
                case "ORACLE":
                    where = "VISIT_DATE>=trunc(sysdate)  ";
                    break;
                case "SQL":
                    break;
            }
            if (tx_PatientID.Text != "")
            {
                where += "and PATIENT_ID='"+tx_PatientID.Text.Trim()+"'";
            }
            if (tx_PatientName.Text != "")
            {
                where += " and PATIENT_NAME like '%"+tx_PatientName.Text.Trim()+"%'";
            }
            if (cmb_ExamStatus.Text == "未检查")
            {
                where += " and DIAG_FLAG in (0,2)";
            }
            else
            {
                where += " and DIAG_FLAG=1";
            }
            where += " and QUEUE_NAME='" + cmb_Group.Text + "'";
            where += "  order by QUEUE_NAME,ORDER_NO";
            this.dgv_RegistInfo.DataSource = bQueueInfo.GetList(where);
        }
        /// <summary>
        /// 绑定检查组
        /// </summary>
        private void GroupBind()
        {
            DataTable dt = bGroup.GetList(" 1=1 and DEPT_CODE='" + this.cmb_Dept.SelectedValue.ToString() + "' ");
            this.cmb_Group.DataSource = dt; 
            this.cmb_Group.DisplayMember = "QUEUE_NAME";
            this.cmb_Group.ValueMember = "QUEUE_ID";
            DataTable dt2 = dt.Copy();
            this.cmb_Group2.DataSource = dt2;
            this.cmb_Group2.DisplayMember = "QUEUE_NAME";
            this.cmb_Group2.ValueMember = "QUEUE_NAME";
        }
        /// <summary>
        /// 绑定科室
        /// </summary>
        private void DeptBind()
        {
            this.cmb_Dept.DataSource = bDept.GetList(" 1=1 ");
            string ExamDept = "";
            if (GetConfig.DALAndModel == "SIS")
            {
                this.cmb_Dept.DisplayMember = "CLINIC_OFFICE";
                this.cmb_Dept.ValueMember = "CLINIC_OFFICE_CODE";
                SIS_Model.MUser smUser = (SIS_Model.MUser)this.iUser;
                ExamDept = smUser.CLINIC_OFFICE_CODE;
            }
            else
            {
                this.cmb_Dept.DisplayMember = "DEPT_NAME";
                this.cmb_Dept.ValueMember = "DEPT_CODE";
                PACS_Model.MUser pmUser = (PACS_Model.MUser)this.iUser;
                ExamDept = pmUser.USER_DEPT;
            }
            this.cmb_Dept.SelectedValue = ExamDept;
        }

        private void cmb_Dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupBind();
        }

        private void cmb_Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBind();
        }

        private void btn_First_Click(object sender, EventArgs e)
        {
            try
            {
                MoveTo(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }
        /// <summary>
        /// 更新排队号ORDER_NO
        /// </summary>
        /// <param name="orderno">新排队号</param>
        private void ChangeOrderNo(double orderno)
        {
            this.iQueueInfo = GetModel();
            if (GetConfig.DALAndModel == "SIS")
            {
                SIS_Model.MQueueInfo smQinfo = (SIS_Model.MQueueInfo)this.iQueueInfo;
                smQinfo.ORDER_NO = Convert.ToDecimal(orderno);
                bQueueInfo.Update(smQinfo, "where EXAM_ACCESSION_NUM='" + smQinfo.EXAM_ACCESSION_NUM + "'");
            }
            else
            {
                PACS_Model.MQueueInfo pmQinfo = (PACS_Model.MQueueInfo)this.iQueueInfo;
                pmQinfo.ORDER_NO = Convert.ToDecimal(orderno);
                bQueueInfo.Update(pmQinfo, "where EXAM_ACCESSION_NUM='" + pmQinfo.EXAM_ACCESSION_NUM + "'");
            }
           // ListBind();
        }
        /// <summary>
        /// 获取QUEUE_INFO model
        /// </summary>
        /// <returns></returns>
        private IModel GetModel()
        {
            return bQueueInfo.GetModel(this.dgv_QueueInfo.SelectedRows[0].Cells["EXAM_ACCESSION_NUM_2"].Value.ToString());
        }
        private IModel GetModel(string ExamAccessionNum)
        {
            return bQueueInfo.GetModel(ExamAccessionNum);
        }
        // 最后按钮
        private void btn_Last_Click(object sender, EventArgs e)
        {
            try
            {
                MoveTo(this.dgv_QueueInfo.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }
      
        // 调前
        private void btn_Pre_Click(object sender, EventArgs e)
        {
            try
            {
                int position = this.dgv_QueueInfo.SelectedRows[0].Index;
                MoveTo(position);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }
        //调后
        private void btn_Next_Click(object sender, EventArgs e)
        {
            try
            {
                int position = this.dgv_QueueInfo.SelectedRows[0].Index + 2;
                MoveTo(position);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }
        /// <summary>
        /// 插到按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_InsertTo_Click(object sender, EventArgs e)
        {
            try
            {
                frmDiagInsertTo diag = new frmDiagInsertTo();
                diag.ShowDialog();
                if (diag.DialogResult == DialogResult.OK)
                {
                    if (0 < diag.InsertNo && diag.InsertNo <= this.dgv_QueueInfo.Rows.Count)
                        MoveTo(diag.InsertNo);
                    else
                        MessageBoxEx.Show("您输入的位置超出范围！");
                }
                diag.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }
       /// <summary>
       /// 根据要插到的位置生成新的排队号ORDER_NO
       /// </summary>
       /// <param name="Position">第几位</param>
       /// <returns></returns>
        private double GetOrderNo(int Position)
        {
            double OrderNo = -1;
            int Index = this.dgv_QueueInfo.SelectedRows[0].Index;
            if (this.dgv_QueueInfo.Rows.Count == Position)
            {
                OrderNo = double.Parse(this.dgv_QueueInfo.Rows[Position - 1].Cells["ORDER_NO_2"].Value.ToString()) + 0.01d;
                return OrderNo;
            }
            if (Position == 1)
            {
                OrderNo = double.Parse(this.dgv_QueueInfo.Rows[Position - 1].Cells["ORDER_NO_2"].Value.ToString()) - 0.01d;
                return OrderNo;
            }
            if (Index > Position - 1)
            {
                OrderNo = (double.Parse(this.dgv_QueueInfo.Rows[Position - 1].Cells["ORDER_NO_2"].Value.ToString()) +
                    double.Parse(this.dgv_QueueInfo.Rows[Position - 2].Cells["ORDER_NO_2"].Value.ToString())) / 2.0;
            }
            else if (Index < Position - 1)
            {
                OrderNo = (double.Parse(this.dgv_QueueInfo.Rows[Position].Cells["ORDER_NO_2"].Value.ToString()) +
                    double.Parse(this.dgv_QueueInfo.Rows[Position - 1].Cells["ORDER_NO_2"].Value.ToString())) / 2.0;
            }
            return OrderNo;
        }
        /// <summary>
        /// 插入到队列的第几位
        /// </summary>
        /// <param name="Position"></param>
        private void MoveTo(int Position)
        {
            if (Position > this.dgv_QueueInfo.Rows.Count || Position < 1 || Position == this.dgv_QueueInfo.SelectedRows[0].Index + 1)
                return;
            ChangeOrderNo(GetOrderNo(Position));
            cmb_Group2_SelectedIndexChanged(null, null);
            this.dgv_QueueInfo.Rows[Position - 1].Selected = true;
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            try
            {
                //将该条记录标识为删除状态即字段DIAG_FLAG修改为9
                if (MessageBox.Show(null, "是否要删除此记录！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    this.iQueueInfo = GetModel();
                    if (GetConfig.DALAndModel == "SIS")
                    {
                        SIS_Model.MQueueInfo smQinfo = (SIS_Model.MQueueInfo)this.iQueueInfo;
                        smQinfo.DIAG_FLAG = 9;
                        bQueueInfo.Update(smQinfo, "where EXAM_ACCESSION_NUM='" + smQinfo.EXAM_ACCESSION_NUM + "'");
                    }
                    else
                    {
                        PACS_Model.MQueueInfo pmQinfo = (PACS_Model.MQueueInfo)this.iQueueInfo;
                        pmQinfo.DIAG_FLAG = 9;
                        bQueueInfo.Update(pmQinfo, "where EXAM_ACCESSION_NUM='" + pmQinfo.EXAM_ACCESSION_NUM + "'");
                    }
                    ListBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }

        private void btn_ChangeGroup_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)this.cmb_Group.DataSource;
                frmDiagChangeGroup diag = new frmDiagChangeGroup(dt, this.cmb_Group.SelectedIndex);
                diag.ShowDialog();
                if (diag.DialogResult == DialogResult.OK)
                {
                    this.iQueueInfo = GetModel();
                    if (GetConfig.DALAndModel == "SIS")
                    {
                        SIS_Model.MQueueInfo smQinfo = (SIS_Model.MQueueInfo)this.iQueueInfo;
                        cmb_Group.SelectedIndex = diag.Value;
                        smQinfo.QUEUE_NAME = cmb_Group.Text;
                        bQueueInfo.Update(smQinfo, "where EXAM_ACCESSION_NUM='" + smQinfo.EXAM_ACCESSION_NUM + "'");
                        //this.cmb_Group.SelectedText = diag.Value;
                        ListBind();
                        FindInfo(smQinfo.PATIENT_ID);
                    }
                    else
                    {
                        PACS_Model.MQueueInfo pmQinfo = (PACS_Model.MQueueInfo)this.iQueueInfo;
                        cmb_Group.SelectedIndex = diag.Value;
                        pmQinfo.QUEUE_NAME = cmb_Group.Text;
                        bQueueInfo.Update(pmQinfo, "where EXAM_ACCESSION_NUM='" + pmQinfo.EXAM_ACCESSION_NUM + "'");
                        //this.cmb_Group.SelectedText = diag.Value;
                        ListBind();
                        FindInfo(pmQinfo.PATIENT_ID);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }

        private void cmb_ExamStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBind();
        }
        private void FindInfo(string PatientID)
        {
            for (int i = 0; i < dgv_RegistInfo.Rows.Count; i++)
            {
                if (dgv_RegistInfo.Rows[i].Cells["Patient_Id"].Value.ToString() == PatientID)
                {
                    this.dgv_RegistInfo.Rows[i].Selected = true;
                    break;
                }
            }
        }

        private void tx_PatientID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListBind();
            }
        }
        private void tx_PatientName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListBind();
            }
        }
        private void cmb_Group2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dgv_QueueInfo.DataSource = bQueueInfo.GetList(GetQueueInfoWhereStr());
            if (this.dgv_QueueInfo.Rows.Count > 0)
                this.dgv_QueueInfo.SelectedRows[0].Selected = false;
        }
        private string GetQueueInfoWhereStr()
        {
            string where = "";
            switch (GetConfig.SisOdbcMode)
            {
                case "ACCESS":
                    where = "VISIT_DATE>=date() and 1=1 and DIAG_FLAG=0 and QUEUE_NAME='" + cmb_Group2.Text + "'  order by QUEUE_NAME,ORDER_NO ";
                    break;
                case "ORACLE":
                    where = " VISIT_DATE>=trunc(sysdate) and 1=1 and DIAG_FLAG=0 and QUEUE_NAME='" + cmb_Group2.Text + "'  order by QUEUE_NAME,ORDER_NO ";
                    break;
                case "SQL":
                    break;
            }
            return where;
        }

        private void dgv_RegistInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //MQueueInfo info=bQueueInfo.GetModel(this.dgv_QueueInfo.SelectedRows[0].Cells["EXAM_ACCESSION_NUM"].Value.ToString());
            if (this.dgv_RegistInfo.SelectedRows.Count > 0)
            {
                this.cmb_Group2.SelectedValue = this.dgv_RegistInfo.SelectedRows[0].Cells["QUEUE_NAME"].Value.ToString();
                FindPatientInDgvQueueInfo(this.dgv_RegistInfo.SelectedRows[0].Cells["EXAM_ACCESSION_NUM"].Value.ToString());
            }
        }
        /// <summary>
        /// 根据检查号在排队表中锁定病人
        /// </summary>
        /// <param name="exam_accession_num"></param>
        private void FindPatientInDgvQueueInfo(string exam_accession_num)
        {
            for (int i = 0; i < dgv_QueueInfo.Rows.Count; i++)
            {
                if (dgv_QueueInfo.Rows[i].Cells["EXAM_ACCESSION_NUM_2"].Value.ToString() == exam_accession_num)
                {
                    this.dgv_QueueInfo.Rows[i].Selected = true;
                    break;
                }
                else
                {
                    this.dgv_QueueInfo.Rows[i].Selected = false;
                }
            }
        }

        private void dgv_QueueInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            for (int i = dgv_RegistInfo.SelectedRows.Count - 1; i >= 0; i--)
            {
                string ExamAccessionNum = dgv_RegistInfo.SelectedRows[i].Cells["EXAM_ACCESSION_NUM"].Value.ToString();
                if (dgv_RegistInfo.SelectedRows[i].Cells["QUEUE_NAME"].Value.ToString() != cmb_Group2.SelectedValue.ToString())
                {
                    this.iQueueInfo = GetModel(ExamAccessionNum);
                    if (GetConfig.DALAndModel == "SIS")
                    {
                        SIS_Model.MQueueInfo smQinfo = (SIS_Model.MQueueInfo)this.iQueueInfo;
                        smQinfo.QUEUE_NAME = cmb_Group2.SelectedValue.ToString();
                        bQueueInfo.Update(smQinfo, "where EXAM_ACCESSION_NUM='" + smQinfo.EXAM_ACCESSION_NUM + "'");
                    }
                    else
                    {
                        PACS_Model.MQueueInfo pmQinfo = (PACS_Model.MQueueInfo)this.iQueueInfo;
                        pmQinfo.QUEUE_NAME = cmb_Group2.SelectedValue.ToString();
                        bQueueInfo.Update(pmQinfo, "where EXAM_ACCESSION_NUM='" + pmQinfo.EXAM_ACCESSION_NUM + "'");
                    }
                    cmb_Group2_SelectedIndexChanged(null, null);
                    FindPatientInDgvQueueInfo(ExamAccessionNum);
                    btn_Last_Click(null, null);
                }

            }
            ListBind();
        }

        private void dgv_RegistInfo_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dgv_RegistInfo_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dgv_RegistInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == this.dgv_RegistInfo.Columns["DIAG_FLAG"].Index)
            {
                switch (e.Value.ToString())
                {
                    case "0":
                        e.Value = "未检查";
                        break;
                    case "1":
                        e.Value = "已检查";
                        break;
                    case "2":
                        e.Value = "未检查";
                        break;
                    case "9":
                        e.Value = "已删除";
                        break;
                    default :
                        e.Value = "未检查";
                        break;
                }
            }
        }

    }
}