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
    /// PACS的检查类别管理
    /// </summary>
    public partial class frmExamClass : Form
    {
        private MExamClass mExCls = new MExamClass();
        private BExamClass bExCls = new BExamClass();

        public frmExamClass()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 界面加载时，更改button1的文本为窗体名；列表设置为不自动创建行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExamClass_Load(object sender, EventArgs e)
        {

            this.btn_FunName.Text = this.Text;
            this.dgv_ExamClass.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 当界面可见性改变时，绑定检查类别和检查科室号类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExamClass_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                Bind_ExamClass();
                Bind_LocalIDClass();
            }
        }

        /// <summary>
        /// 绑定检查类型
        /// </summary>
        private void Bind_ExamClass()
        {
            DataTable dt = bExCls.GetList2("EXAM_CLASS");
            if (dt != null)
            {
                cmb_ExamClass.DataSource = dt;
                cmb_ExamClass.DisplayMember = "EXAM_CLASS";
            }
        }

        /// <summary>
        /// 绑定检查科室号类型
        /// </summary>
        private void Bind_LocalIDClass()
        {
            DataTable dt = bExCls.GetList2("LOCAL_ID_CLASS");
            if (dt != null)
            {
                cmb_LocalIdClass.DataSource = dt;
                cmb_LocalIdClass.DisplayMember = "LOCAL_ID_CLASS";
            }
        }

        /// <summary>
        /// 检查类别选择改变时，绑定检查子类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_ExamClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind_ExamSubClass(cmb_ExamClass.Text.Trim());
        }

        /// <summary>
        /// 绑定检查子类
        /// </summary>
        /// <param name="where"></param>
        private void Bind_ExamSubClass(string where )
        {
            DataTable dt = bExCls.GetList(" EXAM_CLASS='" + cmb_ExamClass.Text.Trim() + "' order by EXAM_SUB_CLASS");
            if (dt != null)
            {
                cmb_ExamSubClass.DataSource = dt;
                cmb_ExamSubClass.DisplayMember = "EXAM_SUB_CLASS";
            }
        }

        /// <summary>
        /// 当单击查找按钮时，执行检查类别查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Find_Click(object sender, EventArgs e)
        {
            StringBuilder sgbd=new StringBuilder ();
            if (cmb_ExamClass.Text.Trim()!="")
                sgbd.Append(" EXAM_CLASS LIKE '%" + cmb_ExamClass.Text.Trim() + "%' And ");
            if (cmb_ExamSubClass.Text.Trim() != "")
                sgbd.Append(" EXAM_SUB_CLASS LIKE '%" + cmb_ExamSubClass.Text.Trim() + "%' And ");

            FindData(sgbd.ToString());
            btn_Clean_Click(null, null);
        }

        /// <summary>
        /// 函数FindData负责执行数据库查找
        /// </summary>
        /// <param name="condition"></param>
        private void FindData(string condition)
        {
            DataTable dt = bExCls.GetList(condition + " 1=1 ORDER BY EXAM_CLASS");

            if (dt != null)
            {
                dgv_ExamClass.DataSource = dt;
            }
            else
            {
                dgv_ExamClass.DataSource = null;
            }
        }

        /// <summary>
        /// 当单击保存按钮时，执行检查类别保存；若存在则执行更新，否则执行增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            bool bl = GetData();
            if (!bl) return;

            bool bll = bExCls.Exists(mExCls);

            if (bll)
            {
                int i = bExCls.Update(mExCls, " where EXAM_CLASS='" + mExCls.EXAM_CLASS + "' and " +
                     "EXAM_SUB_CLASS = '" + mExCls.EXAM_SUB_CLASS + "'");
                if (i > 0)
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
            else
            {
                int j = bExCls.Add(mExCls);
                if (j > 0)
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
        }

        /// <summary>
        /// 检查检查类别、子类和检查号，都不为空，则赋值，返回true；否则返回false，不往下执行
        /// </summary>
        /// <returns></returns>
        private bool GetData()
        {
            if (cmb_ExamClass.Text.Trim() != "")
            {
                mExCls.EXAM_CLASS = cmb_ExamClass.Text.Trim();
            }
            else
            {
                MessageBoxEx.Show("检查类别不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cmb_ExamSubClass.Text.Trim() != "")
            {
                mExCls.EXAM_SUB_CLASS = cmb_ExamSubClass.Text.Trim();
            }
            else
            {
                MessageBoxEx.Show("检查子类不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cmb_LocalIdClass.Text.Trim() != "")
            {
                mExCls.LOCAL_ID_CLASS = cmb_LocalIdClass.Text.Trim();
            }
            else
            {
                MessageBoxEx.Show("科室检查号类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txt_Device.Text.Trim() != "")
                mExCls.DEVICE = txt_Device.Text.Trim();
            if (txt_Dicom.Text.Trim() != "")
                mExCls.DICOM_MODALITY = txt_Dicom.Text.Trim();
            if (txt_PrintPatternClass.Text.Trim() != "")
                mExCls.PRINT_PATTERN_CLASS = txt_PrintPatternClass.Text.Trim();

            return true;
        }

        /// <summary>
        /// 当单击清空时，清空对应的内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Clean_Click(object sender, EventArgs e)
        {
            cmb_ExamClass.Text = "";
            cmb_ExamSubClass.Text = "";
            cmb_LocalIdClass.Text = "";
            txt_Device.Text = "";
            txt_Dicom.Text = "";
            txt_PrintPatternClass.Text = "";
        }

        /// <summary>
        /// 当单击删除时，执行删除选中记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Del_Click(object sender, EventArgs e)
        {
            DialogResult dlrs = MessageBoxEx.Show("确认删除选中的记录!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dlrs == DialogResult.No) return;

            DataGridViewSelectedRowCollection src = dgv_ExamClass.SelectedRows;
            if (src != null)
            {
                Hashtable ht = new Hashtable();

                for (int i = 0; i < src.Count; i++)
                {
                    ht.Add(i.ToString(), src[i].Cells["EXAM_CLASS"].Value.ToString().Trim() + ";" + src[i].Cells["EXAM_SUB_CLASS"].Value.ToString().Trim());
                }

                int j = bExCls.DeleteMore(ht);

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
        /// 当单击检查类别列表时，将选中行的单元内容赋值到上面的对应的位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_ExamClass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmb_ExamClass.Text = dgv_ExamClass.Rows[e.RowIndex].Cells["EXAM_CLASS"].Value.ToString().Trim();
            cmb_ExamSubClass.Text = dgv_ExamClass.Rows[e.RowIndex].Cells["EXAM_SUB_CLASS"].Value.ToString().Trim();
            cmb_LocalIdClass.Text = dgv_ExamClass.Rows[e.RowIndex].Cells["LOCAL_ID_CLASS"].Value.ToString().Trim();
            txt_Device.Text = dgv_ExamClass.Rows[e.RowIndex].Cells["DEVICE"].Value.ToString().Trim();
            txt_Dicom.Text = dgv_ExamClass.Rows[e.RowIndex].Cells["DICOM_MODALITY"].Value.ToString().Trim();
            txt_PrintPatternClass.Text = dgv_ExamClass.Rows[e.RowIndex].Cells["PRINT_PATTERN_CLASS"].Value.ToString().Trim();

        }

    }
}