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
    public partial class frmKnowledgeBase : Form
    {

        private BKnowledgeBase bklBase = new BKnowledgeBase();
        private MKnowledgeBase mkb = new MKnowledgeBase();

        public frmKnowledgeBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 绑定脏器下拉列表框
        /// </summary>
        private void Bind_Visc_Name()
        {
            DataTable dt = bklBase.GetList2("VISC_NAME");
            if (dt != null)
            {
                cmb_VISC_NAME.DataSource = dt;
                cmb_VISC_NAME.DisplayMember = "VISC_NAME";
                cmb_VISC_NAME.ValueMember = "VISC_NAME";
            }
        }

        /// <summary>
        /// 绑定病种下拉列表框
        /// </summary>
        private void Bind_Desc_Name()
        {
            DataTable dt = bklBase.GetList2("DESC_NAME");
            if (dt != null)
            {
                cmb_DESC_NAME.DataSource = dt;
                cmb_DESC_NAME.DisplayMember = "DESC_NAME";
                cmb_DESC_NAME.ValueMember = "DESC_NAME";
            }

        }

        /// <summary>
        /// 绑定科室下拉列表框
        /// </summary>
        private void Bind_Clinic_Office_Code()
        {
            BClinicOfficeDict BCOD = new BClinicOfficeDict();

            DataTable dt = BCOD.GetList(" 1=1 ORDER BY CLINIC_OFFICE_ID");
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr,0);

            if (dt != null)
            {
                cmb_CLINIC_OFFICE_CODE.DataSource = dt;
                cmb_CLINIC_OFFICE_CODE.DisplayMember = "CLINIC_OFFICE";
                cmb_CLINIC_OFFICE_CODE.ValueMember = "CLINIC_OFFICE_CODE";
            }
        }

        private void KnowledgeBase_Load(object sender, EventArgs e)
        {
            this.btn_FunName.Text = this.Text.ToString();
            dgv_KnowledgeBase.AutoGenerateColumns = false;

        }

        private void KnowledgeBase_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                Bind_Visc_Name();
                Bind_Desc_Name();
                Bind_Clinic_Office_Code();
            }
        }

        private void cmb_VISC_NAME_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_VISC_NAME.Text != "" && cmb_DESC_NAME.Text != "")
            {
                DataTable dt = bklBase.GetList(" VISC_NAME='" + cmb_VISC_NAME.Text + "' AND DESC_NAME='" + cmb_DESC_NAME.Text + "' ORDER BY IMAGE_INDEX");
                dgv_KnowledgeBase.DataSource = dt;
            }
        }

        private void cmb_DESC_NAME_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_VISC_NAME.Text != "" && cmb_DESC_NAME.Text != "")
            {
                DataTable dt = bklBase.GetList(" VISC_NAME='" + cmb_VISC_NAME.Text + "' AND DESC_NAME='" + cmb_DESC_NAME.Text + "' ORDER BY IMAGE_INDEX");
                dgv_KnowledgeBase.DataSource = dt;
            }
        }

        private void dgv_KnowledgeBase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //string sql = " VISC_NAME='" + cmb_VISC_NAME.Text + "' AND DESC_NAME='" + cmb_DESC_NAME.Text + "' AND image_name='" + dgv_KnowledgeBase.Rows[e.RowIndex].Cells["IMAGE_NAME"].Value.ToString() + "' ORDER BY IMAGE_INDEX";
            //DataTable dt = bklBase.GetList(sql);
            if (e.RowIndex >= 0)
            {
                btn_Clean_Click(null, null);

                mkb = new MKnowledgeBase();
                mkb.VISC_NAME = cmb_VISC_NAME.Text;
                mkb.DESC_NAME = cmb_DESC_NAME.Text;

                txt_VISC_NAME.Text = cmb_VISC_NAME.Text;
                txt_DESC_NAME.Text = cmb_DESC_NAME.Text;

                txt_IMAGE_NAME.Text = dgv_KnowledgeBase.Rows[e.RowIndex].Cells["IMAGE_NAME"].Value.ToString();
                if (!string.IsNullOrEmpty(dgv_KnowledgeBase.Rows[e.RowIndex].Cells["IMAGE_DATA"].Value.ToString()))
                {
                  pb_Image.Image=SIS_Function.ImageOpe.ByteToImage((byte[])dgv_KnowledgeBase.Rows[e.RowIndex].Cells["IMAGE_DATA"].Value);
                   
                }
                if (!string.IsNullOrEmpty(dgv_KnowledgeBase.Rows[e.RowIndex].Cells["IMAGE_INDEX"].Value.ToString()))
                    nud_IMAGE_INDEX.Value = Convert.ToInt32(dgv_KnowledgeBase.Rows[e.RowIndex].Cells["IMAGE_INDEX"].Value.ToString());
                if (!string.IsNullOrEmpty(dgv_KnowledgeBase.Rows[e.RowIndex].Cells["IMAGE_COMMENT"].Value.ToString()))
                    txt_COMMENT.Text = dgv_KnowledgeBase.Rows[e.RowIndex].Cells["IMAGE_COMMENT"].Value.ToString();
                if (!string.IsNullOrEmpty(dgv_KnowledgeBase.Rows[e.RowIndex].Cells["CLINIC_OFFICE_CODE"].Value.ToString()))
                    cmb_CLINIC_OFFICE_CODE.SelectedValue = dgv_KnowledgeBase.Rows[e.RowIndex].Cells["CLINIC_OFFICE_CODE"].Value.ToString();
            }
        }

        private void btn_Clean_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in pl_Base.Controls)
            {
                if (ctr is TextBox  | ctr is ComboBox )
                 ctr.Text = "";
            }
            pb_Image.Image = null;
        }

        private void btn_SelPic_Click(object sender, EventArgs e)
        {
            ofd_SelPicture.Filter = "*.JPG(*.JPG)|*.JPG|*.BMP(*.BMP)|*.BMP|*.PNG(*.PNG)|*.PNG|*.GIF(*.GIF)|*.GIF";
            ofd_SelPicture.InitialDirectory = Application.StartupPath;
            ofd_SelPicture.FileName = "";
            DialogResult dlr= ofd_SelPicture.ShowDialog();
            if (dlr == DialogResult.Cancel) return;
            string sPath = ofd_SelPicture.FileName;
            if (System.IO.File.Exists(sPath))
                pb_Image.Image = Image.FromFile(sPath );


        }

        private MKnowledgeBase GetValue()
        {
            MKnowledgeBase MKB = new MKnowledgeBase();

            if (!string.IsNullOrEmpty(txt_VISC_NAME.Text.Trim()))
                MKB.VISC_NAME = txt_VISC_NAME.Text.Trim();
            else
            {
                MessageBoxEx.Show("脏器不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            if (!string.IsNullOrEmpty(txt_DESC_NAME.Text.Trim()))
                MKB.DESC_NAME = txt_DESC_NAME.Text.Trim();
            else
            {
                MessageBoxEx.Show("病种不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            MKB.IMAGE_INDEX = Convert.ToInt32(nud_IMAGE_INDEX.Text);
            if (!string.IsNullOrEmpty(txt_IMAGE_NAME.Text.Trim()))
                MKB.IMAGE_NAME = txt_IMAGE_NAME.Text.Trim();
            else
            {
                MessageBoxEx.Show("图像名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            if (!string.IsNullOrEmpty(cmb_CLINIC_OFFICE_CODE.SelectedValue.ToString()))
                MKB.CLINIC_OFFICE_CODE = cmb_CLINIC_OFFICE_CODE.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(txt_COMMENT.Text.Trim()))
                MKB.IMAGE_COMMENT = txt_COMMENT.Text.Trim();

            if (pb_Image.Image != null)
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pb_Image.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] ArrBy = ms.GetBuffer();
                MKB.IMAGE_DATA = ArrBy;
            }

            return MKB;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            MKnowledgeBase Imkb = GetValue();
            if (Imkb == null) return;

            bool bl = bklBase.Exists(Imkb);

            if (bl)
            {
                int i = bklBase.Update(Imkb ," where VISC_NAME='" + Imkb.VISC_NAME + "' and DESC_NAME='" + Imkb.DESC_NAME + "' and IMAGE_NAME='" + Imkb.IMAGE_NAME + "'");

                if (i >= 0)
                {
                    MessageBoxEx.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmb_VISC_NAME_SelectedIndexChanged(null, null);
                    btn_Clean_Click(null, null);
                }
                else
                    MessageBoxEx.Show("修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int i = bklBase.Add(Imkb);

                if (i > 0)
                {
                    MessageBoxEx.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmb_VISC_NAME_SelectedIndexChanged(null, null);
                    btn_Clean_Click(null, null);
                }
                else
                    MessageBoxEx.Show("添加失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvc = dgv_KnowledgeBase.SelectedRows;
            if (dgvc.Count <= 0)
            {
                MessageBoxEx.Show("请选择需要删除的记录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }

            if (DialogResult.Yes == MessageBoxEx.Show("是否删除选中的记录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                
                Hashtable ht = new Hashtable();
                for (int i = 0; i < dgvc.Count; i++)
                {
                    string sql = "VISC_NAME='" + cmb_VISC_NAME.Text + "' and DESC_NAME='" + cmb_DESC_NAME.Text + "' and IMAGE_NAME='" + dgvc[i].Cells["IMAGE_NAME"].Value.ToString() + "'";
                    ht.Add(i.ToString(), sql);
                }

                int m = bklBase.DeleteMore(ht);
                if (m >= 0)
                {
                    MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (cmb_VISC_NAME.Text != "" && cmb_DESC_NAME.Text != "")
                    {
                        DataTable dt = bklBase.GetList(" VISC_NAME='" + cmb_VISC_NAME.Text + "' AND DESC_NAME='" + cmb_DESC_NAME.Text + "' ORDER BY IMAGE_INDEX");
                        dgv_KnowledgeBase.DataSource = dt;
                    }
                }
                else
                {
                    MessageBoxEx.Show("删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // e.Cancel = true;
                }
            }
        }






    }
}