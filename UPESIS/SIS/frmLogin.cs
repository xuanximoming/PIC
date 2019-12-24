using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Xml;
using System.IO;

using SIS_BLL;
using SIS_Model;
using SIS.Function;
using DALFactory;
using ILL;

namespace SIS
{
    /// <summary>
    /// 登录界面，用于登录系统和锁定解锁
    /// </summary>
    public partial class frmLogin : Form
    {
        private BImgEquipment BImgEqu = new BImgEquipment();
        private DataTable dt = new DataTable();
        private MImgEquipment MimgEqu = (MImgEquipment)Model.CreateMImgEquipment();
        public IModel user;
        public bool isAutoLock = true;

        //无框窗体移动所需windows 的API，在响应MouseMove事件
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

    
        /// <summary>
        /// 作用：双击登录图标，显示的登录界面初始化,构造函数1；不含参数。
        /// 思路：SIS：绑定检查设备；PACS：隐藏设备选择栏和标签，调整密码栏位置。
        /// </summary>
        public frmLogin()
        {
            InitializeComponent();
            this.lbHospitalName.Text = GetConfig.HospitalName;
            this.user =Model.CreateMUser();
            if (GetConfig.DALAndModel == "SIS")
                BindCbMachineName();
            else
            {
                this.txt_Pwd.Location = new Point(this.txt_Pwd.Location.X, this.txt_Pwd.Location.Y + 15);
                this.l_Pwd.Location = new Point(this.l_Pwd.Location.X, this.l_Pwd.Location.Y + 15);
                this.cmb_ImgEquipment.Visible = false;
                this.l_ImgEquipment.Visible = false;
            }
        }

        /// <summary>
        /// 作用：用户单击主界面的锁定按钮时，模式显示的解锁界面初始化，构造函数2；含参数IUSER，即用户。
        /// 思路：不显示在任务栏；调整密码栏位置；隐藏设备栏；医生ID为只读；显示“已登录”；显示解锁面板；隐藏登录面板；显示医生ID。
        /// </summary>
        /// <param name="iuser"></param>
        public frmLogin(IModel iuser)
        {
            InitializeComponent();
            this.lbHospitalName.Text = GetConfig.HospitalName;
            this.ShowInTaskbar = false;
            this.txt_Pwd.Location = new Point(this.txt_Pwd.Location.X, this.txt_Pwd.Location.Y + 15);
            this.l_Pwd.Location = new Point(this.l_Pwd.Location.X, this.l_Pwd.Location.Y + 15);
            this.cmb_ImgEquipment.Visible = false;
            this.l_ImgEquipment.Visible = false;
            this.txt_DoctorId.ReadOnly = true;
            this.l_Notice.Visible = true;
            this.p_Lock.Visible = true;
            this.p_LoginButtons.Visible = false;
            this.initData(iuser);
        }

        /// <summary>
        /// 作用：用户单击锁定界面的设置按钮，进入设置自动锁定功能设置初始化，构造函数3。
        /// 思路：不显示在任务栏；调整密码栏位置；隐藏设备栏；医生ID为只读；显示“已登录”；显示解锁面板；隐藏登录面板；显示医生ID。
        /// </summary>
        /// <param name="iuser"></param>
        /// <param name="ShowValidity"></param>
        public frmLogin(IModel iuser,bool ShowValidity)
        {
            InitializeComponent();
            this.lbHospitalName.Text = GetConfig.HospitalName;
            this.ShowInTaskbar = false;
            this.txt_Pwd.Location = new Point(this.txt_Pwd.Location.X, this.txt_Pwd.Location.Y + 15);
            this.l_Pwd.Location = new Point(this.l_Pwd.Location.X, this.l_Pwd.Location.Y + 15);
            this.cmb_ImgEquipment.Visible = false;
            this.l_ImgEquipment.Visible = false;
            this.txt_DoctorId.ReadOnly = true;
            this.l_Notice.Visible = true;
            this.p_Validity.Visible = true;
            this.p_LoginButtons.Visible = false;
            this.initData(iuser);
        }

        /// <summary>
        /// 作用：进入锁定界面后，对工号和密码的初始化。
        /// 思路：将当前登录用户的ID赋值，密码清空。
        /// </summary>
        /// <param name="iuser"></param>
        public void initData(IModel iuser)
        {
            this.user = iuser;
            if (GetConfig.DALAndModel == "SIS")
            {
                SIS_Model.MUser muser = (SIS_Model.MUser)iuser;
                this.txt_DoctorId.Text = muser.DOCTOR_ID;
            }
            else
            {
                PACS_Model.MUser muser = (PACS_Model.MUser)iuser;
                this.txt_DoctorId.Text = muser.DB_USER;
            }
            this.txt_Pwd.Text = "";
        }

        /// <summary>
        /// 作用：在登录界面,绑定影像机器名。
        /// 思路：根据配置文件的检查科室代码，获取该科室所有设备；显示的为设备名，属性为设备ID。
        /// </summary>
        private void BindCbMachineName()
        {    
            try
            {
                dt = BImgEqu.GetList(" CLINIC_OFFICE_CODE = '" + GetConfig.ExamDeptCode + "'");
                this.cmb_ImgEquipment.DataSource = dt;
                this.cmb_ImgEquipment.DisplayMember = "IMG_EQUIPMENT_NAME";
                this.cmb_ImgEquipment.ValueMember = "IMG_EQUIPMENT_ID";               
            }
            catch(Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
            }
            if (dt == null)
            {
                MessageBoxEx.Show("请检查网络连接！");     //如果无法获取科室代码，则为网络问题，提示错误
                this.Close();
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["IMG_EQUIPMENT_NAME"].ToString() == GetConfig.ImgEquipment)     //选中默认的机器名
                {
                    this.cmb_ImgEquipment.SelectedIndex = i;
                    break;
                }
                else
                    this.cmb_ImgEquipment.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// 作用：当单击登录界面的登录按钮，响应事件。
        /// 思路：如果用户身份合法，则给予登录，关闭当前界面并打开主界面；否则提示用户名、密码错误。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
 
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (CheckText())
            {
                if (this.cmb_ImgEquipment.Text.ToString() != GetConfig.ImgEquipment)
                {
                   GetConfig.SetImgEquipment(this.cmb_ImgEquipment.Text.ToString());        //回写配置文件默认的机器名
                   GetConfig.ImgEquipment = this.cmb_ImgEquipment.Text.ToString();
                }
                if (CheckUser())
                {
                    try
                    {
                        BUser buser = new BUser();
                        this.user = buser.GetModel(this.txt_DoctorId.Text.Trim().ToString());    //获取该用户信息
                    }
                    catch (Exception ex)
                    {
                        MessageBoxEx.Show(ex.Message);
                    }
                    this.Visible = false;
                    frmMainForm fp = new frmMainForm(this.user);
                    fp.Show();
                }
                else
                {
                    MessageBoxEx.Show("用户名、密码不正确，请重新输入！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    this.txt_Pwd.Text = "";
                    this.txt_Pwd.Focus();
                }
            }
        }

        /// <summary>
        ///  作用：检查用户输入信息。
        /// 思路：如输入为空，则将提示警告，光标置于为空的输入文本框；并返回。
        /// </summary>
        /// <returns></returns>

        private bool  CheckText()
        {
            if (this.txt_DoctorId.Text == "")
            {
                MessageBoxEx.Show("工号不能为空，请重新输入！","提示！",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                this.txt_DoctorId.Focus();
                return false;
            }
            if (this.txt_Pwd.Text == "")
            {
                MessageBoxEx.Show("密码不能为空，请重新输入！","提示！",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                this.txt_Pwd.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 作用：对登录用户的身份验证。
        /// 思路：对输入的用户工号和密码，实例化一个用户，并查询数据库用户表
        /// </summary>
        /// <returns></returns>
        private bool CheckUser()
        {
            if (GetConfig.DALAndModel == "SIS")
            {
                SIS_Model.MUser muser = (SIS_Model.MUser)user;
                muser.DOCTOR_ID = this.txt_DoctorId.Text.Trim().ToString();
                muser.DOCTOR_PWD = this.txt_Pwd.Text.Trim().ToString();
            }
            else
            {
                PACS_Model.MUser muser = (PACS_Model.MUser)user;
                muser.DB_USER = this.txt_DoctorId.Text.Trim().ToString();
                muser.USER_PWD = this.txt_Pwd.Text.Trim().ToString();
            }
            try
            {
                return new BUser().Exists(user);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 作用：用户单击取消按钮，相应单击事件。
        /// 思路：对工号和密码的内容进行输入清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.txt_DoctorId.Text = "";
            this.txt_Pwd.Text = "";
            
        }

        /// <summary>
        /// 作用：鼠标左键按下，并移动；响应窗体移动；
        /// 思路：调用API，实现无框窗体移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        /// <summary>
        /// 光标于设备处，回车事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{tab}");
        }

        /// <summary>
        /// 作用：单击设置按钮，布局界面。
        /// 思路：隐藏登录输入栏；隐藏锁定栏；显示设置栏。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btn_LockSetting_Click(object sender, EventArgs e)
        {
            this.p_LoginMain.Visible = false;
            this.p_Lock.Visible = false;
            this.p_Setting.Visible = true;
            this.txt_Minute.Enabled = false;
            if (GetConfig.LS_AutoLock)
            {
                this.cb_AutoLock.Checked = true;
                this.txt_Minute.Text = GetConfig.LS_LockMinute.ToString();
            }
            else
                this.cb_AutoLock.Checked = false;
        }

        /// <summary>
        /// 作用：单击退出按钮，退出登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 作用：单击解锁按钮，执行解锁验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_UnLock_Click(object sender, EventArgs e)
        {
            this.Check();
        }

        /// <summary>
        /// 作用：执行解锁验证。
        /// 思路：将登录成功的用户信息与输入的密码判断。
        /// </summary>
        private void Check()
        {
            string pwd = "";
            if (GetConfig.DALAndModel == "SIS")
            {
                SIS_Model.MUser muser = (SIS_Model.MUser)user;
                pwd = muser.DOCTOR_PWD;
            }
            else
            {
                PACS_Model.MUser muser = (PACS_Model.MUser)user;
                pwd = muser.USER_PWD;
            }
            if (this.txt_Pwd.Text == pwd)
                this.DialogResult = DialogResult.OK;
            else
                MessageBoxEx.Show("密码错", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 作用：最右上角的关闭按钮，单击关闭按钮，退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 作用：单击保存按钮，执行对设置自动锁定条件的保存。
        /// 思路：保存成功，则显示登录输入栏；锁定栏；隐藏锁定设置栏。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cb_AutoLock.Checked)
                {
                    GetConfig.SetLS_AutoLock(true);
                    GetConfig.SetLS_LockMinute(int.Parse(this.txt_Minute.Text.ToString()));
                    this.isAutoLock = true;
                }
                else
                {
                    GetConfig.SetLS_AutoLock(false);
                    GetConfig.SetLS_LockMinute(0);
                    this.isAutoLock = false;
                }
                MessageBoxEx.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.p_Setting.Visible = false;
                this.p_LoginMain.Visible = true;
                this.p_Lock.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message.ToString(), "异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 作用：单击解锁的取消按钮，返回锁定解锁界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.p_Setting.Visible = false;
            this.p_LoginMain.Visible = true;
            this.p_Lock.Visible = true;
        }

        /// <summary>
        /// 作用：响应自动锁定复选框的选择事件 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_AutoLock_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cb_AutoLock.Checked)
                this.txt_Minute.Enabled = true;
            else
                this.txt_Minute.Enabled = false;
        }

        /// <summary>
        /// 作用：登录界面显示时，光标落到工号输入文本框中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            this.txt_DoctorId.Focus();
        }

        //登陆按钮
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            this.Check();
        }

        //取消按钮
        private void btn_Cancel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 单击修改密码动态链接，模式打开修改密码界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void llb_ChangePwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmChangePwd pwd = new frmChangePwd();
            pwd.ShowDialog();
        }
    }
}