using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SIS_BLL;
using ILL;

namespace SIS
{
    /// <summary>
    /// 修改密码
    /// </summary>
    public partial class frmChangePwd : Form
    {
        public frmChangePwd()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 单击取消按钮，关闭界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region -确定按钮，执行修改密码-
        /// <summary>
        /// 单击确定，进行修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInput())
                {
                    UpdatePwd();
                }
            }
            catch(Exception ex)
            {
                MessageBoxEx.Show("出现错误\r\n"+ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 作用：检查用户的输入。
        /// 思路：工号、旧密码、新密码输入不能为空，且两次输入的新密码必须一致。
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            if (tx_LoginName.Text.Trim() == "")
            {
                MessageBoxEx.Show("请输入工号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (tx_OldPwd.Text.Trim() == "")
            {
                MessageBoxEx.Show("请输入旧密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (tx_NewPwd.Text.Trim() == "")
            {
                MessageBoxEx.Show("请输入新密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (tx_ConfirmPwd.Text.Trim() != tx_NewPwd.Text.Trim())
            {
                MessageBoxEx.Show("两次输入的新密码不一致！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 作用：执行更新用户密码。
        /// 思路：首先由工号获取指定的用户记录，如果不存在该工号，则提示；如果工号和旧密码不匹配，则提示；否则执行修改更新。
        /// </summary>
        private void UpdatePwd()
        {
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    UpdateSISUser();
                    break;
                case "PACS":
                    UpdatePACSUser();
                    break;
            }
        }

        /// <summary>
        /// 更新超声科的用户信息
        /// </summary>
        private void UpdateSISUser()
        {
            BUser buser = new BUser();
            SIS_Model.MUser user = (SIS_Model.MUser)buser.GetModel(this.tx_LoginName.Text.Trim());
            if (user == null)
            {
                MessageBoxEx.Show("输入的工号不存在，请检查！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (user.DOCTOR_PWD != this.tx_OldPwd.Text.Trim())
                {
                    MessageBoxEx.Show("旧密码不正确！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    user.DOCTOR_PWD = this.tx_NewPwd.Text.Trim();
                    buser.Update((ILL.IModel)user, " where DOCTOR_ID='" + user.DOCTOR_ID + "'");
                    MessageBoxEx.Show("修改密码成功，请记住您的新密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
        }

        /// <summary>
        /// 更新放射科的用户信息
        /// </summary>
        private void UpdatePACSUser()
        {
            BUser buser = new BUser();
            PACS_Model.MUser user = (PACS_Model.MUser)buser.GetModel(this.tx_LoginName.Text.Trim());
            if (user == null)
            {
                MessageBoxEx.Show("输入的工号不存在，请检查！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (user.USER_PWD != this.tx_OldPwd.Text.Trim())
                {
                    MessageBoxEx.Show("旧密码不正确！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    user.USER_PWD = this.tx_NewPwd.Text.Trim();
                    buser.Update((ILL.IModel)user, " where DB_USER='" + user.DB_USER + "'");
                    MessageBoxEx.Show("修改密码成功，请记住您的新密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
        }
        #endregion 
    }
}