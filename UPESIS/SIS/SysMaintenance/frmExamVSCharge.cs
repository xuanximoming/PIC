using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SIS_Model;
using ILL;
using SIS_BLL;

namespace SIS.SysMaintenance
{
    public partial class frmExamVSCharge : Form
    {
        private BExamItemDict bExamItem = new BExamItemDict();
        private BChargeItemDict bChargeItem = new BChargeItemDict();
        private BExamVsCharge bExamCharge = new BExamVsCharge();

        public frmExamVSCharge()
        {
            InitializeComponent();
        }

        private void frmExamVSCharge_Load(object sender, EventArgs e)
        {
            this.btnFunName.Text = this.Text;
            this.dgv_Exam_Item.AutoGenerateColumns = false;
            dgv_Charge_Item_Dic.AutoGenerateColumns = false;
            Bind_Exam_Class();  //查找检查类别
            Find_Charge_Item_Dic();     //查找B超类别(类别由配置文件决定)的价表项目        
        }

        /// <summary>
        /// 绑定检查类别下拉框
        /// </summary>
        private void Bind_Exam_Class()
        {
            string[] ArrayStr = ILL.GetConfig.ExamClass.Split(',');
            foreach (string s in ArrayStr)
                cmb_Exam_Class.Items.Add(s);
            cmb_Exam_Class.SelectedIndex = 0;
        }
      
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            Find_Charge_Item_Dic();
            if (txt_AMOUNT.Text == "")
                txt_AMOUNT.Text = "1";
        }
        //根据配置文件查找某检查科室的价表项目
        private void Find_Charge_Item_Dic()
        {
            DataTable dt = bChargeItem.GetList(" CHARGE_ITEM_CLASS = '" + GetConfig.ChargeItemClass.Substring(0, 1) + "' Order by CHARGE_ITEM_CODE");
            dgv_Charge_Item_Dic.DataSource = dt;
        }

        /// <summary>
        /// 保存修改检查项目对应的价表对照关系
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvsrCharge = dgv_Charge_Item_Dic.SelectedRows;
            DataGridViewSelectedRowCollection dgvsrExamItem = dgv_Exam_Item.SelectedRows;

            if (dgvsrCharge.Count <= 0)
            {
                MessageBoxEx.Show("请选择需要对应的价表项目!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!SIS.Function.ExpressionValidat.IsNumeric(txt_AMOUNT.Text))
            {
                MessageBoxEx.Show("请输入对应的数量!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Hashtable ht = new Hashtable();
            Hashtable nht = new Hashtable();
            int m = 0;
            int n = 0;
            string exitcd = "";
            foreach (DataGridViewRow dr in dgvsrExamItem)
            {
                int i = 0;
                exitcd = dr.Cells["EXAM_ITEM_CODE"].Value.ToString();
                nht.Add(m, dr.Cells["EXAM_ITEM_CODE"].Value.ToString());
                foreach (DataGridViewRow ndr in dgvsrCharge)
                {
                    MExamVsCharge mevc = new MExamVsCharge();
                    mevc.AMOUNT = Convert.ToInt16(txt_AMOUNT.Text);
                    mevc.EXAM_ITEM_CODE = dr.Cells["EXAM_ITEM_CODE"].Value.ToString();
                    mevc.CHARGE_ITEM_NO = i++;
                    mevc.CHARGE_ITEM_SPEC = ndr.Cells["CHARGE_ITEM_SPEC"].Value.ToString();
                    mevc.CHARGE_ITEM_CODE = ndr.Cells["CHARGE_ITEM_CODE"].Value.ToString();
                    mevc.UNITS = ndr.Cells["UNITS"].Value.ToString();
                    ht.Add(n, mevc);
                    n++;
                }
                m++;
            }
            int j = bExamCharge.DeleteMore(nht);
            j = bExamCharge.AddMore(ht);
            if (j > 0)
            {
                txt_AMOUNT.Text = "";
                MessageBox.Show("保存成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Find_Exam_vs_CHarge("EXAM_ITEM_CODE='" + exitcd + "' And ");
            }
            else
            {
                MessageBox.Show("保存失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 单击检查项目表，查找该检查项目对应的价表项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Exam_Item_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string exitcd = dgv_Exam_Item.Rows[e.RowIndex].Cells["EXAM_ITEM_CODE"].Value.ToString();
            Find_Exam_vs_CHarge("EXAM_ITEM_CODE='" + exitcd + "' And ");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlstr"></param>
        private void Find_Exam_vs_CHarge(string sqlstr)
        {
            DataTable dt = bExamCharge.GetList2(sqlstr + "1=1 order by CHARGE_ITEM_NO");
            dgv_Charge_Item_Dic.DataSource = dt;
            if (dt.Rows.Count > 0)
                txt_AMOUNT.Text = dt.Rows[0]["AMOUNT"].ToString();
            else
                txt_AMOUNT.Text = "";
        }

        /// <summary>
        /// 根据检查类别检索属于该检查类别的检查项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_Exam_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            Find_Exam_Item("EXAM_CLASS='" + cmb_Exam_Class.Text + "' And ");
        }

        //查找某一检查类别下的项目表
        private void Find_Exam_Item(string sqlstr)
        {
            DataTable dt = bExamItem.GetList(sqlstr + " 1=1 Order by SORT_ID");
            if (dt == null)
                return;
            else
                dgv_Exam_Item.DataSource = dt;
        }
    }
}