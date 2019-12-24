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

namespace SIS.SysMaintenance
{
    public partial class frmChargeItemDict : Form
    {
        private BChargeItemDict BChrgItDit = new BChargeItemDict();
        private BChargeItemClassDict BChrgItClsDit = new BChargeItemClassDict();    //价表项目分类字典类，用来查询分类代码
        private DataTable DT_CHhargeItemClass= new DataTable();  //记录项目分类代码与其它名称的表
        private string RowTxt = "";         //记录当前双击行的项目代码
        private string RowItemName = "";    //记录当前双击行的项目名称

        public frmChargeItemDict()
        {
            InitializeComponent();
        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            StringBuilder strCon = new StringBuilder();

            if (cmb_CHARGE_ITEM_CLASS.Text.Trim() != "")
                strCon.Append("CHARGE_ITEM_CLASS= '" + cmb_CHARGE_ITEM_CLASS.SelectedValue.ToString()+ "' and ");
            if (txt_CHARGE_ITEM_CODE.Text.Trim()!="")
                strCon.Append("CHARGE_ITEM_CODE like '%" + txt_CHARGE_ITEM_CODE.Text.Trim() + "%' and ");
            if (txt_CHARGE_ITEM_NAME.Text.Trim()!="")
                strCon.Append("CHARGE_ITEM_NAME like '%" + txt_CHARGE_ITEM_NAME.Text.Trim() + "%' and ");
            if (txt_OPERATOR.Text.Trim()!="")
                strCon.Append("OPERATOR='" + txt_OPERATOR.Text.Trim() + "' and ");

            FindData(strCon.ToString() );

            if (dgv_ChargeItemDict.Rows.Count > 0) return;
            gb_PromptInfo.Visible = true;
        }

        /// <summary>
        /// 绑定项目分类下拉列表框
        /// </summary>
        private void CHhargeItemClassDict()
        {
            //BClinicOfficeDict BClOff = new BClinicOfficeDict();
            //DT_CHhargeItemClass = BChrgItClsDit.GetList("1=1 order by CLASS_CODE asc");
            string[] ArrayItemName = ILL.GetConfig.ChargeItemClass.Split(':');
            DataTable DT_CHhargeItemClass = new DataTable();
            DT_CHhargeItemClass.Columns.Add("CLASS_CODE", typeof(string));
            DT_CHhargeItemClass.Columns.Add("CLASS_NAME", typeof(string));
            DataRow dr = DT_CHhargeItemClass.NewRow();
            dr["CLASS_CODE"] = ArrayItemName[0];
            dr["CLASS_NAME"] = ArrayItemName[1];
            DT_CHhargeItemClass.Rows.Add(dr);

            if (DT_CHhargeItemClass.Rows.Count > 0)
            {
                cmb_CHARGE_ITEM_CLASS.DataSource = DT_CHhargeItemClass;
                cmb_CHARGE_ITEM_CLASS.DisplayMember = "CLASS_NAME";
                cmb_CHARGE_ITEM_CLASS.ValueMember = "CLASS_CODE";
            }            
        }

        private void ChargeItemDict_Load(object sender, EventArgs e)
        {
            this.btn_FunName.Text = this.Text.ToString();
            dgv_ChargeItemDict.AutoGenerateColumns = false;  //防止自动添加新列
            dtp_ENTER_DATE.Value = DateTime.Now;
            dtp_START_DATE.Value = DateTime.Now;

            CHhargeItemClassDict();

            FindData("");

            if (dgv_ChargeItemDict.Rows.Count > 0)
                gb_PromptInfo.Visible = false;
            else
                gb_PromptInfo.Visible = true;

            cmb_CHARGE_ITEM_CLASS.Focus();
        }

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="sct">查找的条件</param>
        private void FindData(string sct)
        {
            DataTable dt = BChrgItDit.GetList(sct + "CHARGE_ITEM_CLASS='" + cmb_CHARGE_ITEM_CLASS.SelectedValue.ToString() + "' order by ENTER_DATE");
            dgv_ChargeItemDict.DataSource = dt;

            if (dt.Rows.Count > 0)
            {
                gb_PromptInfo.Visible = false;
                
                if (RowTxt != "")
                {
                    for (int i = 0; i < dgv_ChargeItemDict.Rows.Count; i++)
                    {
                        if (dgv_ChargeItemDict.Rows[i].Cells["CHARGE_ITEM_CODE"].Value.ToString() == RowTxt)
                        {
                            dgv_ChargeItemDict.CurrentCell = dgv_ChargeItemDict.Rows[i].Cells[0];
                            break;
                        }
                    }
                }
            }

            RowItemName="";
            RowTxt = "";
            btn_Clean_Click(null, null);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            MChargeItemDict mcid = ChgNull(0);
            if (mcid == null) return;

            int i = BChrgItDit.Add(mcid);

            if (i > 0)
            {
                MessageBoxEx.Show("添加成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FindData(""); ;
            }
            else
                MessageBoxEx.Show("添加失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 判断输入的条件是否为正确的,Flag-0:新增;1:修改
        /// </summary>
        /// <returns>返回null说明输入有误</returns>
        private MChargeItemDict ChgNull(int Flag)
        {
            MChargeItemDict mChrItmDit = new MChargeItemDict();
            mChrItmDit.CHARGE_ITEM_CLASS = cmb_CHARGE_ITEM_CLASS.SelectedValue.ToString();
            //if (cmb_CHARGE_ITEM_CLASS.Text.Trim() == "")
            //{
            //    MessageBoxEx.Show("项目分类不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return null;
            //}
            //else
            //{
            //    DataRow[] dr = DT_CHhargeItemClass.Select("CLASS_NAME='" + cmb_CHARGE_ITEM_CLASS.Text + "'");
            //    if (dr.Length > 0)
            //        mChrItmDit.CHARGE_ITEM_CLASS = dr[0]["CLASS_CODE"].ToString();
            //    else
            //    {
            //        MessageBoxEx.Show("项目分类设置错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return null;
            //    }
            //}
                


            if (txt_CHARGE_ITEM_CODE.Text.Trim() == "")
            {
                MessageBoxEx.Show("项目代码不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            else
            {
                mChrItmDit.CHARGE_ITEM_CODE = txt_CHARGE_ITEM_CODE.Text.Trim();
                bool bl = BChrgItDit.ExistsWhere("CHARGE_ITEM_CODE ='" + mChrItmDit.CHARGE_ITEM_CODE + "'");
                if (bl)
                {
                    if (Flag == 0)
                    {
                        MessageBoxEx.Show("项目代码已经存在,请重新设定!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return null;
                    }
                    else
                    {
                        if (RowTxt != mChrItmDit.CHARGE_ITEM_CODE)
                        {
                            MessageBoxEx.Show("修改后的项目代码已经存在,请重新设定!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return null;
                        }
                    }
                }
                else
                {
                    if (Flag == 1)
                    {
                        MessageBoxEx.Show("未能找到此项目代码的记录," + "\r\n" + "请注意:项目代码为不可修改内容!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return null;
                    }
                }
            }

            if (txt_CHARGE_ITEM_SPEC.Text.Trim() == "")
            {
                MessageBoxEx.Show("项目规格不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            else 
                mChrItmDit.CHARGE_ITEM_SPEC = txt_CHARGE_ITEM_SPEC.Text.Trim();


            if (txt_CHARGE_ITEM_NAME.Text.Trim() == "")
            {
                MessageBoxEx.Show("项目名称不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            mChrItmDit.CHARGE_ITEM_NAME = txt_CHARGE_ITEM_NAME.Text.Trim();
            //else
            //{
            //    mChrItmDit.CHARGE_ITEM_NAME = txt_CHARGE_ITEM_NAME.Text.Trim();
            //    bool bl1 = BChrgItDit.ExistsWhere("CHARGE_ITEM_NAME='" + mChrItmDit.CHARGE_ITEM_NAME + "'");

            //    if (bl1)
            //    {
            //        if (Flag == 0)
            //        {
            //            MessageBoxEx.Show("项目名称已经存在,请重新设定!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            return null;
            //        }
            //        else
            //        {
            //            if (RowItemName != mChrItmDit.CHARGE_ITEM_NAME)
            //           {
            //               MessageBoxEx.Show("修改后的项目名称已经存在,请重新设定!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //               return null;
            //           }
            //        }
            //    }
            //}

            if (txt_INPUT_CODE.Text.Trim() != "")
                mChrItmDit.INPUT_CODE = txt_INPUT_CODE.Text.Trim();

            if (txt_PRICE.Text.Trim() != "")
            {
                try
                {
                    mChrItmDit.PRICE = Convert.ToDecimal(txt_PRICE.Text.Trim());
                }
                catch
                {
                    MessageBoxEx.Show("价格输入错误,请重新输入!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
            }
            else
            {
                MessageBoxEx.Show("价格不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            if (txt_UNITS.Text.Trim() == "")
            {
                MessageBoxEx.Show("单位不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            else 
                mChrItmDit.UNITS = txt_UNITS.Text.Trim();


            if (txt_OPERATOR.Text.Trim() != "")
                mChrItmDit.OPERATOR = txt_OPERATOR.Text.Trim();

            mChrItmDit.ENTER_DATE = dtp_ENTER_DATE.Value;

             mChrItmDit.START_DATE = dtp_START_DATE.Value;


            if (txt_STOP_DATE.Text.Trim() != "")
            {
                try
                {
                    mChrItmDit.STOP_DATE = Convert.ToDateTime(txt_STOP_DATE.Text.Trim());
                }
                catch
                {
                    MessageBoxEx.Show("停止日期输入格式错误,不是正确的日期!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
            }

            if (txt_MEMO.Text.Trim() != "")
                mChrItmDit.MEMO = txt_MEMO.Text.Trim();

            return mChrItmDit;

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
            dtp_ENTER_DATE.Value = DateTime.Now;
            dtp_START_DATE.Value = DateTime.Now;
            RowItemName="";
            RowTxt = "";
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            if (RowTxt == "") return;

            MChargeItemDict mcid = ChgNull(1);
            if (mcid == null) return;

            int i = BChrgItDit.Update(mcid, " where CHARGE_ITEM_CODE='" + mcid.CHARGE_ITEM_CODE + "'");


            if (i >= 0)
            {
                MessageBoxEx.Show("修改成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FindData(""); ;
            }
            else
                MessageBoxEx.Show("修改失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            RowTxt = "";
            RowItemName="";

            DialogResult dlrs = MessageBoxEx.Show("确认删除选中的记录!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dlrs == DialogResult.No) return;

            DataGridViewSelectedRowCollection dtGrView = dgv_ChargeItemDict.SelectedRows;

            Hashtable ht = new Hashtable();

            for (int i = 0; i < dtGrView.Count; i++)
            {
                ht.Add(i.ToString(), dtGrView[i].Cells["CHARGE_ITEM_CODE"].Value.ToString());
            }

            int j = BChrgItDit.DeleteMore(ht);

            if (j >= 0)
            {
                MessageBoxEx.Show("删除成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FindData("");
            }
            else
                MessageBoxEx.Show("删除失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void ChargeItemDict_VisibleChanged(object sender, EventArgs e)
        {
            CHhargeItemClassDict();
        }

        private void dgv_ChargeItemDict_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow dr = dgv_ChargeItemDict.Rows[e.RowIndex];

            cmb_CHARGE_ITEM_CLASS.SelectedValue  = dr.Cells["CHARGE_ITEM_CLASS"].Value.ToString();
            txt_CHARGE_ITEM_CODE.Text = dr.Cells["CHARGE_ITEM_CODE"].Value.ToString().Trim();
            txt_CHARGE_ITEM_SPEC.Text = dr.Cells["CHARGE_ITEM_SPEC"].Value.ToString().Trim();
            txt_CHARGE_ITEM_NAME.Text = dr.Cells["CHARGE_ITEM_NAME"].Value.ToString().Trim();
            txt_INPUT_CODE.Text = dr.Cells["INPUT_CODE"].Value.ToString().Trim();
            txt_PRICE.Text = dr.Cells["PRICE"].Value.ToString().Trim();
            txt_UNITS.Text = dr.Cells["UNITS"].Value.ToString().Trim();
            txt_OPERATOR.Text = dr.Cells["OPERATOR"].Value.ToString();
            dtp_ENTER_DATE.Text = string.Format(dr.Cells["ENTER_DATE"].Value.ToString(), "yyyy-MM-dd HH:MM:ss");
            dtp_START_DATE.Text = dr.Cells["START_DATE"].Value.ToString();
            txt_STOP_DATE.Text = dr.Cells["STOP_DATE"].Value.ToString().Trim();
            txt_MEMO.Text = dr.Cells["MEMO"].Value.ToString().Trim();

            RowTxt = txt_CHARGE_ITEM_CODE.Text;
            RowItemName = txt_CHARGE_ITEM_NAME.Text;
        }


    }
}